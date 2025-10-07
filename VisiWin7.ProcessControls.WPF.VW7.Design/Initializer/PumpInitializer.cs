using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for Pump process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for Pump controls.
    /// </remarks>
    public class PumpInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for Pump controls.
        /// </summary>
        public override string VariableMappingName => "PumpMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="PumpInitializer"/> class.
        /// </summary>
        public PumpInitializer() { }
    }
}