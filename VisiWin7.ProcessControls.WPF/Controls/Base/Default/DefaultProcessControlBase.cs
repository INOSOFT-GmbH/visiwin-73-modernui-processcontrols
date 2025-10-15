using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using VisiWin.DataAccess;
using VisiWin7.ProcessControls.WPF.States;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Abstract base class that adds process value mapping and visual state selection to <see cref="ProcessControlBase"/>.
    /// </summary>
    /// <remarks>
    /// This class introduces the <see cref="ActualValue"/> and <see cref="SetValue"/> dependency properties that are
    /// intended to be mapped via <see cref="ProcessControlBase.Mapping"/> to process variables (e.g., measured value and setpoint).
    /// When a mapped variable changes, <see cref="OnVariableValueChanged(object,string,VariableEventArgs)"/> converts the new value
    /// to <see cref="int"/> and updates the corresponding dependency property using
    /// <see cref="FrameworkElement.SetCurrentValue(DependencyProperty, object)"/> to preserve existing bindings.
    /// For <see cref="ActualValue"/>, the method also selects the visual state from <see cref="ProcessControlBase.StateBrushes"/>
    /// (by matching the state value) and exposes it through the read-only <see cref="CurrentStateBrush"/> property. The visual state
    /// is additionally refreshed when the state collection changes via <see cref="OnControlStatesChanges"/>.
    /// The dependency properties are registered with the owner type <see cref="DefaultProcessControlBase"/> so they can be referenced and
    /// styled consistently across all derived controls.
    /// </remarks>
    public abstract class DefaultProcessControlBase : DefaultErrorProcessControlBase
    {
        /// <summary>
        /// Gets or sets the actual value of the process variable.
        /// This property is mapped to a variable and updates the control's state when changed.
        /// </summary>
        [Category("Process")]
        public int ActualValue
        {
            get => (int)this.GetValue(ActualValueProperty);
            set => this.SetValue(ActualValueProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ActualValue"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualValueProperty = DependencyProperty.Register(
            nameof(ActualValue), typeof(int), typeof(DefaultProcessControlBase), new PropertyMetadata(0, OnActualValueChanged));

        /// <summary>
        /// Static callback for changes to the <see cref="ActualValue"/> property.
        /// Invokes the instance method to handle the change.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The event data.</param>
        private static void OnActualValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DefaultProcessControlBase @this)
            {
                @this.OnActualValueChanged(e);
            }
        }

        /// <summary>
        /// Gets or sets the setpoint value for the process variable.
        /// This property is mapped to a variable and can be used to set a target value.
        /// </summary>
        [Category("Process")]
        public int SetValue
        {
            get => (int)this.GetValue(SetValueProperty);
            set => this.SetValue(SetValueProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="SetValue"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SetValueProperty = DependencyProperty.Register(nameof(SetValue), typeof(int), typeof(DefaultProcessControlBase), new PropertyMetadata(0));

        /// <summary>
        /// Dependency property key for the current state brush.
        /// </summary>
        private static readonly DependencyPropertyKey currentStateBrushPropertyKey = DependencyProperty.RegisterReadOnly(nameof(CurrentStateBrush), typeof(BlinkBrushState),
            typeof(DefaultProcessControlBase), new FrameworkPropertyMetadata(default(BlinkBrushState), FrameworkPropertyMetadataOptions.None));

        /// <summary>
        /// Dependency property for <see cref="CurrentStateBrush"/>.
        /// </summary>
        public static readonly DependencyProperty CurrentStateBrushProperty = currentStateBrushPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the current state brush, which reflects the current visual state of the control.
        /// </summary>
        [Category("Process")]
        public BlinkBrushState CurrentStateBrush
        {
            get => (BlinkBrushState)this.GetValue(CurrentStateBrushProperty);
            protected set => this.SetValue(currentStateBrushPropertyKey, value);
        }

        /// <summary>
        /// Called when the <see cref="ActualValue"/> property changes.
        /// Updates the control's state based on the new actual value.
        /// </summary>
        /// <param name="e">The event arguments containing the old and new values.</param>
        protected virtual void OnActualValueChanged(DependencyPropertyChangedEventArgs e)
        {
            this.UpdateControlStates(this.ActualValue);
        }

        /// <summary>
        /// Updates the control's state based on a variable value.
        /// </summary>
        /// <param name="variableValue">The value to use for state selection.</param>
        protected void UpdateControlStates(object variableValue)
        {
            var typeChangedValue = Convert.ChangeType(variableValue, typeof(int));
            if (typeChangedValue != null)
            {
                this.UpdateControlStates((int)typeChangedValue);
            }
        }

        /// <summary>
        /// Called when the control is loaded. 
        /// Initializes services and updates the control's state based on the current actual value.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        protected override async Task OnLoaded()
        {
            await base.OnLoaded();
            this.UpdateControlStates(this.ActualValue);
        }

        /// <summary>
        /// Called when the control's state collection changes.
        /// Updates the control's state based on the current value of the <see cref="ActualValue"/> variable.
        /// </summary>
        protected override void OnControlStatesChanges()
        {
            if (!this.Variables.TryGetValue(nameof(this.ActualValue), out var variable))
            {
                return;
            }

            if (variable?.Value != null)
            {
                this.UpdateControlStates(variable.Value);
            }
        }

        /// <summary>
        /// Called when a mapped variable's value changes.
        /// Updates the corresponding dependency property and, if applicable, the control's state.
        /// </summary>
        /// <param name="sender">The variable that triggered the event.</param>
        /// <param name="controlPropertyName">The name of the control property mapped to the variable.</param>
        /// <param name="variableEventArgs">The event arguments containing variable change information.</param>
        protected override void OnVariableValueChanged(object sender, string controlPropertyName, VariableEventArgs variableEventArgs)
        {
            base.OnVariableValueChanged(sender, controlPropertyName, variableEventArgs);
            if (this.IsAttaching)
            {
                return;
            }

            var variableValue = this.Variables[controlPropertyName].Value;

            var typeChangedValue = System.Convert.ChangeType(variableValue, typeof(int));
            if (typeChangedValue == null)
            {
                return;
            }

            var intVariableValue = (int)typeChangedValue;
            switch (controlPropertyName)
            {
                case nameof(this.ActualValue):
                    this.SetCurrentValue(ActualValueProperty, intVariableValue);
                    this.UpdateControlStates(intVariableValue);
                    break;

                case nameof(this.SetValue):
                    this.SetCurrentValue(SetValueProperty, intVariableValue);
                    break;
            }
        }

        /// <summary>
        /// Updates the control's state based on an integer value.
        /// </summary>
        /// <param name="variableValue">The integer value representing the state.</param>
        private void UpdateControlStates(int variableValue)
        {
            if (this.StateBrushes == null)
            {
                return;
            }

            var currentState = this.StateBrushes.FirstOrDefaultByStateValue(variableValue);
            this.SetValue(currentStateBrushPropertyKey, currentState);
        }
    }
}