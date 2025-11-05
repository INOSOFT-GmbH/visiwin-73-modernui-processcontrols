using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for PistonValve process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for PistonValve controls.
    /// </remarks>
    public class PistonValveInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for PistonValve controls.
        /// </summary>
        public override string VariableMappingName => "PistonValveMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="PistonValveInitializer"/> class.
        /// </summary>
        public PistonValveInitializer() { }
    }
}