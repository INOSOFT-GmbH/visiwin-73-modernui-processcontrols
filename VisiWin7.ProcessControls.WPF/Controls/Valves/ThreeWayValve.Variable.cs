using VisiWin.DataAccess;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Represents a partial class for a ThreeWayValve control in a WPF application.
    /// Handles variable value changes and updates the corresponding dependency properties.
    /// </summary>
    public partial class ThreeWayValve
    {
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
                case nameof(this.ActualValuePortA):
                    this.SetCurrentValue(ActualValuePortAProperty, intVariableValue);
                    this.UpdateControlStates(intVariableValue, currentStateBrushPortAPropertyKey);
                    break;

                case nameof(this.ActualValuePortB):
                    this.SetCurrentValue(ActualValuePortBProperty, intVariableValue);
                    this.UpdateControlStates(intVariableValue, currentStateBrushPortBPropertyKey);
                    break;

                case nameof(this.ActualValuePortC):
                    this.SetCurrentValue(ActualValuePortCProperty, intVariableValue);
                    this.UpdateControlStates(intVariableValue, currentStateBrushPortCPropertyKey);
                    break;

                case nameof(this.SetValuePortA):
                    this.SetCurrentValue(SetValuePortAProperty, intVariableValue);
                    break;

                case nameof(this.SetValuePortB):
                    this.SetCurrentValue(SetValuePortBProperty, intVariableValue);
                    break;

                case nameof(this.SetValuePortC):
                    this.SetCurrentValue(SetValuePortCProperty, intVariableValue);
                    break;
            }
        }
    }
}