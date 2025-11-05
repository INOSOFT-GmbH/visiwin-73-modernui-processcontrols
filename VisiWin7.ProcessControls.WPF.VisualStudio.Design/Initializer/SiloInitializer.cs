using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for Silo process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for Silo controls.
    /// </remarks>
    public class SiloInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for Silo controls.
        /// </summary>
        public override string VariableMappingName => "SiloMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="SiloInitializer"/> class.
        /// </summary>
        public SiloInitializer() { }
    }
}
