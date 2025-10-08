using System;
using System.ComponentModel;
using System.Windows;
using VisiWin7.ProcessControls.WPF.States;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// The ThreeWayValve class is a specialized process control for three-way valves.
    /// Inherits from <see cref="DefaultErrorProcessControlBase"/> and provides specialized properties and logic for three-way valves related process variables.
    /// </summary>
    public partial class ThreeWayValve : DefaultErrorProcessControlBase
    {
        /// <summary>
        /// Static constructor for the <see cref="ThreeWayValve"/> class.
        /// Overrides the default style key property metadata to associate the control with its default style.
        /// </summary>
        static ThreeWayValve()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ThreeWayValve), new FrameworkPropertyMetadata(typeof(ThreeWayValve)));
        }

        /// <summary>
        /// Gets or sets the actual value (measured value) for port A.
        /// </summary>
        [Category("Process")]
        public int ActualValuePortA
        {
            get => (int)this.GetValue(ActualValuePortAProperty);
            set => this.SetValue(ActualValuePortAProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ActualValuePortA"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualValuePortAProperty = DependencyProperty.Register(
            nameof(ActualValuePortA), typeof(int), typeof(ThreeWayValve), new PropertyMetadata(0));

        /// <summary>
        /// Gets or sets the actual value (measured value) for port B.
        /// </summary>
        [Category("Process")]
        public int ActualValuePortB
        {
            get => (int)this.GetValue(ActualValuePortBProperty);
            set => this.SetValue(ActualValuePortBProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ActualValuePortB"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualValuePortBProperty = DependencyProperty.Register(
            nameof(ActualValuePortB), typeof(int), typeof(ThreeWayValve), new PropertyMetadata(0));

        /// <summary>
        /// Gets or sets the actual value (measured value) for port C.
        /// </summary>
        [Category("Process")]
        public int ActualValuePortC
        {
            get => (int)this.GetValue(ActualValuePortCProperty);
            set => this.SetValue(ActualValuePortCProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="ActualValuePortC"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualValuePortCProperty = DependencyProperty.Register(
            nameof(ActualValuePortC), typeof(int), typeof(ThreeWayValve), new PropertyMetadata(0));

        /// <summary>
        /// Gets or sets the setpoint value for port A.
        /// </summary>
        [Category("Process")]
        public int SetValuePortA
        {
            get => (int)this.GetValue(SetValuePortAProperty);
            set => this.SetValue(SetValuePortAProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="SetValuePortA"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SetValuePortAProperty = DependencyProperty.Register(nameof(SetValuePortA), typeof(int), typeof(ThreeWayValve), new PropertyMetadata(0));

        /// <summary>
        /// Gets or sets the setpoint value for port B.
        /// </summary>
        [Category("Process")]
        public int SetValuePortB
        {
            get => (int)this.GetValue(SetValuePortBProperty);
            set => this.SetValue(SetValuePortBProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="SetValuePortB"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SetValuePortBProperty = DependencyProperty.Register(nameof(SetValuePortB), typeof(int), typeof(ThreeWayValve), new PropertyMetadata(0));

        /// <summary>
        /// Gets or sets the setpoint value for port C.
        /// </summary>
        [Category("Process")]
        public int SetValuePortC
        {
            get => (int)this.GetValue(SetValuePortCProperty);
            set => this.SetValue(SetValuePortCProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="SetValuePortC"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SetValuePortCProperty = DependencyProperty.Register(nameof(SetValuePortC), typeof(int), typeof(ThreeWayValve), new PropertyMetadata(0));

        /// <summary>
        /// Dependency property key for the current state brush of port A.
        /// </summary>
        private static readonly DependencyPropertyKey currentStateBrushPortAPropertyKey = DependencyProperty.RegisterReadOnly(nameof(CurrentStateBrushPortA), typeof(BlinkBrushState),
            typeof(ThreeWayValve), new FrameworkPropertyMetadata(default(BlinkBrushState), FrameworkPropertyMetadataOptions.None));

        /// <summary>
        /// Dependency property for <see cref="CurrentStateBrushPortA"/>.
        /// </summary>
        public static readonly DependencyProperty CurrentStateBrushPortAProperty = currentStateBrushPortAPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the current state brush for port A, reflecting the visual state for the current value.
        /// </summary>
        [Category("Process")]
        public BlinkBrushState CurrentStateBrushPortA
        {
            get => (BlinkBrushState)this.GetValue(CurrentStateBrushPortAProperty);
            protected set => this.SetValue(currentStateBrushPortAPropertyKey, value);
        }

        /// <summary>
        /// Dependency property key for the current state brush of port B.
        /// </summary>
        private static readonly DependencyPropertyKey currentStateBrushPortBPropertyKey = DependencyProperty.RegisterReadOnly(nameof(CurrentStateBrushPortB), typeof(BlinkBrushState),
            typeof(ThreeWayValve), new FrameworkPropertyMetadata(default(BlinkBrushState), FrameworkPropertyMetadataOptions.None));

        /// <summary>
        /// Dependency property for <see cref="CurrentStateBrushPortB"/>.
        /// </summary>
        public static readonly DependencyProperty CurrentStateBrushPortBProperty = currentStateBrushPortBPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the current state brush for port B, reflecting the visual state for the current value.
        /// </summary>
        [Category("Process")]
        public BlinkBrushState CurrentStateBrushPortB
        {
            get => (BlinkBrushState)this.GetValue(CurrentStateBrushPortBProperty);
            protected set => this.SetValue(currentStateBrushPortBPropertyKey, value);
        }

        /// <summary>
        /// Dependency property key for the current state brush of port C.
        /// </summary>
        private static readonly DependencyPropertyKey currentStateBrushPortCPropertyKey = DependencyProperty.RegisterReadOnly(nameof(CurrentStateBrushPortC), typeof(BlinkBrushState),
            typeof(ThreeWayValve), new FrameworkPropertyMetadata(default(BlinkBrushState), FrameworkPropertyMetadataOptions.None));

        /// <summary>
        /// Dependency property for <see cref="CurrentStateBrushPortC"/>.
        /// </summary>
        public static readonly DependencyProperty CurrentStateBrushPortCProperty = currentStateBrushPortCPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the current state brush for port C, reflecting the visual state for the current value.
        /// </summary>
        [Category("Process")]
        public BlinkBrushState CurrentStateBrushPortC
        {
            get => (BlinkBrushState)this.GetValue(CurrentStateBrushPortCProperty);
            protected set => this.SetValue(currentStateBrushPortCPropertyKey, value);
        }

        /// <summary>
        /// Called when the control's state collection changes.
        /// Updates the per-port visual states based on the current values of
        /// <see cref="ActualValuePortA"/>, <see cref="ActualValuePortB"/> and <see cref="ActualValuePortC"/>.
        /// </summary>
        protected override void OnControlStatesChanges()
        {
            if (this.Variables.TryGetValue(nameof(this.ActualValuePortA), out var actualValuePortAVariable))
            {
                if (actualValuePortAVariable != null)
                {
                    this.UpdateControlStates(actualValuePortAVariable.Value, currentStateBrushPortAPropertyKey);
                }
            }

            if (this.Variables.TryGetValue(nameof(this.ActualValuePortB), out var actualValuePortBVariable))
            {
                if (actualValuePortBVariable != null)
                {
                    this.UpdateControlStates(actualValuePortBVariable.Value, currentStateBrushPortBPropertyKey);
                }
            }

            if (this.Variables.TryGetValue(nameof(this.ActualValuePortC), out var actualValuePortCVariable))
            {
                if (actualValuePortCVariable != null)
                {
                    this.UpdateControlStates(actualValuePortCVariable.Value, currentStateBrushPortCPropertyKey);
                }
            }
        }

        /// <summary>
        /// Updates the control's state for a port based on an object value by converting it to <see cref="int"/>.
        /// </summary>
        /// <param name="variableValue">The value to use for state selection.</param>
        /// <param name="propertyKey">The read-only dependency property key of the target port's state brush.</param>
        protected void UpdateControlStates(object variableValue, DependencyPropertyKey propertyKey)
        {
            var typeChangedValue = Convert.ChangeType(variableValue, typeof(int));
            if (typeChangedValue != null)
            {
                this.UpdateControlStates((int)typeChangedValue, propertyKey);
            }
        }

        /// <summary>
        /// Updates the control's state for a port based on an integer value.
        /// </summary>
        /// <param name="variableValue">The integer value representing the state.</param>
        /// <param name="propertyKey">The read-only dependency property key of the target port's state brush.</param>
        private void UpdateControlStates(int variableValue, DependencyPropertyKey propertyKey)
        {
            if (this.StateBrushes == null)
            {
                return;
            }

            var currentState = this.StateBrushes.FirstOrDefaultByStateValue(variableValue);
            this.SetValue(propertyKey, currentState);
        }
    }
}