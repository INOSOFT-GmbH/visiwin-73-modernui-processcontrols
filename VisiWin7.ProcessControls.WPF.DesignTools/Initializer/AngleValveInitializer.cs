using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for AngleValve process control components in the VisiWin7 WPF design environment.
    /// This initializer sets up default property values and variable mappings specific to AngleValve controls.
    /// </summary>
    /// <remarks>
    /// Inherits from <see cref="ProcessControlBaseInitializer"/> to leverage base initialization logic for process controls.
    /// </remarks>
    public class AngleValveInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource to be used for the AngleValve control.
        /// This property overrides the base implementation to provide the specific mapping name for AngleValve.
        /// </summary>
        public override string VariableMappingName => "AngleValveMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="AngleValveInitializer"/> class.
        /// </summary>
        public AngleValveInitializer() { }
    }
}