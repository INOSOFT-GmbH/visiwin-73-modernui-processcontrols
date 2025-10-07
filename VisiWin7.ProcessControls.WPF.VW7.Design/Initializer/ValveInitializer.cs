using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for Valve process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for Valve controls.
    /// </remarks>
    public class ValveInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for Valve controls.
        /// </summary>
        public override string VariableMappingName => "ValveMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="ValveInitializer"/> class.
        /// </summary>
        public ValveInitializer() { }
    }
}