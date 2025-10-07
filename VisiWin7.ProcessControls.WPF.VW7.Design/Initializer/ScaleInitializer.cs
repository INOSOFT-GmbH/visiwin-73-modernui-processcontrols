using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for Scale process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for Scale controls.
    /// </remarks>
    public class ScaleInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for Scale controls.
        /// </summary>
        public override string VariableMappingName => "ScaleMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="ScaleInitializer"/> class.
        /// </summary>
        public ScaleInitializer() { }
    }
}
