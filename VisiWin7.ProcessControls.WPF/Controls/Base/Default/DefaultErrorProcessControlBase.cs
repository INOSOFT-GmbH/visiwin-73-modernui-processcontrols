using System.ComponentModel;
using System.Windows;
using VisiWin.DataAccess;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Abstract base class that adds error reporting support to <see cref="ProcessControlBase"/>.
    /// </summary>
    /// <remarks>
    /// This class introduces the <see cref="Errors"/> dependency property intended to be mapped
    /// via the <see cref="ProcessControlBase.Mapping"/> mechanism to a process variable that
    /// represents either an error count or a compact error state value.
    /// When the mapped variable changes, <see cref="OnVariableValueChanged(object,string,VariableEventArgs)"/>
    /// converts the new value to <see cref="int"/> and updates the dependency property using
    /// <see cref="FrameworkElement.SetCurrentValue(DependencyProperty, object)"/> to preserve bindings.
    /// </remarks>
    public abstract class DefaultErrorProcessControlBase : ProcessControlBase
    {
        /// <summary>
        /// Gets or sets the error count or error state coming from the mapped process variable.
        /// </summary>
        /// <remarks>
        /// Bind this property in XAML or map it using <see cref="ProcessControlBase.Mapping"/> so that
        /// it reflects the current error information of the underlying process. The default value is 0.
        /// </remarks>
        [Category("Process")]
        public int Errors
        {
            get => (int)this.GetValue(ErrorsProperty);
            set => this.SetValue(ErrorsProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Errors"/> dependency property.
        /// </summary>
        /// <remarks>
        /// The property is registered with the owner type <see cref="ProcessControlBase"/> so that it
        /// can be referenced and styled consistently across all derived controls.
        /// The default metadata sets the initial value to <c>0</c>.
        /// </remarks>
        public static readonly DependencyProperty ErrorsProperty = DependencyProperty.Register(nameof(Errors), typeof(int), typeof(DefaultErrorProcessControlBase), new PropertyMetadata(0));

        /// <summary>
        /// Handles changes from mapped variables and updates the corresponding dependency properties.
        /// </summary>
        /// <param name="sender">The variable that raised the change event.</param>
        /// <param name="controlPropertyName">The name of the control property mapped to the variable.</param>
        /// <param name="variableEventArgs">The event arguments carrying change information.</param>
        /// <remarks>
        /// This override updates <see cref="Errors"/> when the mapped variable for this property changes.
        /// If the control is currently attaching variables (<see cref="ProcessControlBase.IsAttaching"/>),
        /// the update is ignored. Values that cannot be converted to <see cref="int"/> are skipped.
        /// </remarks>
        protected override void OnVariableValueChanged(object sender, string controlPropertyName, VariableEventArgs variableEventArgs)
        {
            base.OnVariableValueChanged(sender, controlPropertyName, variableEventArgs);

            var variableValue = this.Variables[controlPropertyName].Value;

            var typeChangedValue = System.Convert.ChangeType(variableValue, typeof(int));
            if (typeChangedValue == null)
            {
                return;
            }

            var intVariableValue = (int)typeChangedValue;
            switch (controlPropertyName)
            {
                case nameof(this.Errors):
                    this.SetCurrentValue(ErrorsProperty, intVariableValue);
                    break;
            }
        }
    }
}