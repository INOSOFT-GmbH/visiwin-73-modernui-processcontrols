using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for Arrow process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for Arrow controls.
    /// </remarks>
    public class ArrowInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for Arrow controls.
        /// </summary>
        public override string VariableMappingName => "ArrowMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrowInitializer"/> class.
        /// </summary>
        public ArrowInitializer() { }
    }
}