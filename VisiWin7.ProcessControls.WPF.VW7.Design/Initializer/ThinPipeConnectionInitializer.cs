using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for ThinPipeConnection process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for ThinPipeConnection controls.
    /// </remarks>
    public class ThinPipeConnectionInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for ThinPipeConnection controls.
        /// </summary>
        public override string VariableMappingName => "ThinPipeConnectionMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="ThinPipeConnectionInitializer"/> class.
        /// </summary>
        public ThinPipeConnectionInitializer() { }
    }
}
