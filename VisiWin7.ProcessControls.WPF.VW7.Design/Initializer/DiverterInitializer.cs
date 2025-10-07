using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for Diverter process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for Diverter controls.
    /// </remarks>
    public class DiverterInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for Diverter controls.
        /// </summary>
        public override string VariableMappingName => "DiverterMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="DiverterInitializer"/> class.
        /// </summary>
        public DiverterInitializer() { }
    }
}