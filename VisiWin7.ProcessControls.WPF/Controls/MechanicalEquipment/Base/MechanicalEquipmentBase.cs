using System.Windows;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Provides a base class for all mechanical equipment controls in the application.
    /// Inherits from <see cref="DefaultProcessControlBase"/> and sets the default style key for mechanical equipment.
    /// </summary>
    public abstract class MechanicalEquipmentBase : DefaultProcessControlBase
    {
        /// <summary>
        /// Static constructor to override the default style key property metadata for <see cref="MechanicalEquipmentBase"/>.
        /// </summary>
        static MechanicalEquipmentBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MechanicalEquipmentBase), new FrameworkPropertyMetadata(typeof(MechanicalEquipmentBase)));
        }
    }
}
