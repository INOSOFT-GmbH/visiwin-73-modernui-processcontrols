using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for CoolingTowerWithInlet process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for CoolingTowerWithInlet controls.
    /// </remarks>
    public class CoolingTowerWithInletInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for CoolingTowerWithInlet controls.
        /// </summary>
        public override string VariableMappingName => "CoolingTowerWithInletMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="CoolingTowerWithInletInitializer"/> class.
        /// </summary>
        public CoolingTowerWithInletInitializer() { }
    }
}