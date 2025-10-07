using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for ThinPipe process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for ThinPipe controls.
    /// </remarks>
    public class ThinPipeInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for ThinPipe controls.
        /// </summary>
        public override string VariableMappingName => "ThinPipePipeMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="ThinPipeInitializer"/> class.
        /// </summary>
        public ThinPipeInitializer() { }
    }
}