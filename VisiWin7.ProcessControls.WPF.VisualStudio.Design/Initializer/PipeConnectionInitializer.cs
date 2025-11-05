using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for PipeConnection process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for PipeConnection controls.
    /// </remarks>
    public class PipeConnectionInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for PipeConnection controls.
        /// </summary>
        public override string VariableMappingName => "ThinPipeConnectionMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="PipeConnectionInitializer"/> class.
        /// </summary>
        public PipeConnectionInitializer() { }
    }
}
