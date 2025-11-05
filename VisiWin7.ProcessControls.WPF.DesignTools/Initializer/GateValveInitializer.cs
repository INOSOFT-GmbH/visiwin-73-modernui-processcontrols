using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for GateValve process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for GateValve controls.
    /// </remarks>
    public class GateValveInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for GateValve controls.
        /// </summary>
        public override string VariableMappingName => "GateValveMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="GateValveInitializer"/> class.
        /// </summary>
        public GateValveInitializer() { }
    }
}