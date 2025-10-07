using System;
using VisiWin.DataAccess;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Represents a partial class for a Tank control in a WPF application.
    /// Handles variable value changes and updates the corresponding dependency properties.
    /// </summary>
    public partial class Tank
    {
        /// <summary>
        /// Called when the value of a bound variable changes.
        /// Updates the corresponding dependency property based on the control property name.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="controlPropertyName">The name of the control property that changed.</param>
        /// <param name="variableEventArgs">Event arguments containing variable change information.</param>
        protected override void OnVariableValueChanged(object sender, string controlPropertyName, VariableEventArgs variableEventArgs)
        {
            base.OnVariableValueChanged(sender, controlPropertyName, variableEventArgs);

            var variableValue = this.Variables[controlPropertyName].Value;

            var typeChangedValue = Convert.ChangeType(variableValue, typeof(int));
            if (typeChangedValue == null)
            {
                return;
            }

            var intVariableValue = (int)typeChangedValue;
            switch (controlPropertyName)
            {
                case nameof(this.Volume):
                    this.SetCurrentValue(VolumeProperty, intVariableValue);
                    break;
            }
        }
    }
}