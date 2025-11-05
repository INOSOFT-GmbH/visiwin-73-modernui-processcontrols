using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for Cooler process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for Cooler controls.
    /// </remarks>
    public class CoolerInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for Cooler controls.
        /// </summary>
        public override string VariableMappingName => "CoolerMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="CoolerInitializer"/> class.
        /// </summary>
        public CoolerInitializer() { }
    }
}