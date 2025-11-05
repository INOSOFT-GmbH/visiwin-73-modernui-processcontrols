using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for SprayCoolingTower process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for SprayCoolingTower controls.
    /// </remarks>
    public class SprayCoolingTowerInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for SprayCoolingTower controls.
        /// </summary>
        public override string VariableMappingName => "SprayCoolingTowerMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="SprayCoolingTowerInitializer"/> class.
        /// </summary>
        public SprayCoolingTowerInitializer() { }
    }
}