namespace VisiWin7.ProcessControls.WPF.Mapping
{
    /// <summary>
    /// Represents a mapping between a variable name and a control property name.
    /// This class is used to associate process variable names with specific control properties in the application.
    /// </summary>
    public class VariableNameControlPropertyMapping
    {
        /// <summary>
        /// Gets or sets the name of the process variable.
        /// </summary>
        public string VariableName { get; set; }

        /// <summary>
        /// Gets or sets the name of the control property associated with the variable.
        /// </summary>
        public string ControlPropertyName { get; set; }
    }
}
