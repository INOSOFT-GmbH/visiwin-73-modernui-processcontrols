using System.ComponentModel;
using System.Windows;
using VisiWin.DataAccess;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Provides a default implementation for process control elements in WPF.
    /// This class exposes dependency properties for process values (ActualValue, SetValue, Errors)
    /// and handles variable mapping, state updates, and value change notifications.
    /// </summary>
    public class DefaultProcessControlBase : ProcessControlBase
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
            nameof(ActualValue),
            typeof(int),
            typeof(ProcessControlBase),
            new PropertyMetadata(0));

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
        public static readonly DependencyProperty SetValueProperty = DependencyProperty.Register(
            nameof(SetValue),
            typeof(int),
            typeof(ProcessControlBase),
            new PropertyMetadata(0));

        /// <summary>
        /// Gets or sets the error count or error state for the process variable.
        /// This property is mapped to a variable and can be used to display error information.
        /// </summary>
        [Category("Process")]
        public int Errors
        {
            get => (int)this.GetValue(ErrorsProperty);
            set => this.SetValue(ErrorsProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Errors"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ErrorsProperty = DependencyProperty.Register(
            nameof(Errors),
            typeof(int),
            typeof(ProcessControlBase),
            new PropertyMetadata(0));

        /// <summary>
        /// Called when the control's state collection changes.
        /// Updates the control's state based on the current value of the <see cref="ActualValue"/> variable.
        /// </summary>
        protected override void OnControlStatesChanges()
        {
            base.OnControlStatesChanges();

            if (!this.Variables.TryGetValue(nameof(this.ActualValue), out var variable))
            {
                return;
            }

            if (variable != null)
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

                case nameof(this.Errors):
                    this.SetCurrentValue(ErrorsProperty, intVariableValue);
                    break;
            }
        }
    }
}