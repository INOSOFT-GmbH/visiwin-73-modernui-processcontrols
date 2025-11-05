using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for PipeBridge process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for PipeBridge controls.
    /// </remarks>
    public class PipeBridgeInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for PipeBridge controls.
        /// </summary>
        public override string VariableMappingName => "ThinPipeBridgeMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="PipeBridgeInitializer"/> class.
        /// </summary>
        public PipeBridgeInitializer() { }
    }
}