using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for Compressor process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for Compressor controls.
    /// </remarks>
    public class CompressorInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for Compressor controls.
        /// </summary>
        public override string VariableMappingName => "CompressorMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="CompressorInitializer"/> class.
        /// </summary>
        public CompressorInitializer() { }
    }
}