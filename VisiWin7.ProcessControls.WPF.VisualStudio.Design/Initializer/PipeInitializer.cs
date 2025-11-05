using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for Pipe process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for Pipe controls.
    /// </remarks>
    public class PipeInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for Pipe controls.
        /// </summary>
        public override string VariableMappingName => "ThinPipePipeMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="PipeInitializer"/> class.
        /// </summary>
        public PipeInitializer() { }
    }
}