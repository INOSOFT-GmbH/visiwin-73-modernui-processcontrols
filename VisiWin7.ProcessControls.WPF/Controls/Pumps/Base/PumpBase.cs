using System.Windows;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Provides a base class for pump process controls.
    /// Inherits from <see cref="DefaultProcessControlBase"/> and sets the default style key for pump controls.
    /// </summary>
    public class PumpBase : DefaultProcessControlBase
    {
        /// <summary>
        /// Static constructor to override the default style key property metadata for <see cref="PumpBase"/>.
        /// </summary>
        static PumpBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PumpBase), new FrameworkPropertyMetadata(typeof(PumpBase)));
        }
    }
}
