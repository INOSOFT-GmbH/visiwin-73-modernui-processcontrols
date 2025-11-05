using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for Stirer process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for Stirer controls.
    /// </remarks>
    public class StirerInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for Stirer controls.
        /// </summary>
        public override string VariableMappingName => "StirerMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="StirerInitializer"/> class.
        /// </summary>
        public StirerInitializer() { }
    }
}