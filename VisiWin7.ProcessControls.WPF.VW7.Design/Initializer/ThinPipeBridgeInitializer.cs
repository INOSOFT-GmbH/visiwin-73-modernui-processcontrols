using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for ThinPipeBridge process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for ThinPipeBridge controls.
    /// </remarks>
    public class ThinPipeBridgeInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for ThinPipeBridge controls.
        /// </summary>
        public override string VariableMappingName => "ThinPipeBridgeMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="ThinPipeBridgeInitializer"/> class.
        /// </summary>
        public ThinPipeBridgeInitializer() { }
    }
}