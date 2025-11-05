using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for CoolingTower process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for CoolingTower controls.
    /// </remarks>
    public class CoolingTowerInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for CoolingTower controls.
        /// </summary>
        public override string VariableMappingName => "CoolingTowerMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="CoolingTowerInitializer"/> class.
        /// </summary>
        public CoolingTowerInitializer() { }
    }
}