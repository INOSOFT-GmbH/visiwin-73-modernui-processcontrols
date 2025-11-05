using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for Burner process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for Burner controls.
    /// </remarks>
    public class BurnerInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for Burner controls.
        /// </summary>
        public override string VariableMappingName => "BurnerMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="BurnerInitializer"/> class.
        /// </summary>
        public BurnerInitializer() { }
    }
}