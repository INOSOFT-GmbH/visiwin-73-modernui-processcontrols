using System.Windows;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Provides an abstract base class for conveyor process controls.
    /// Inherits from <see cref="DefaultProcessControlBase"/> and sets the default style key for conveyor controls.
    /// </summary>
    public abstract class ConveyorBase : DefaultProcessControlBase
    {
        /// <summary>
        /// Static constructor to override the default style key property metadata for <see cref="ConveyorBase"/>.
        /// </summary>
        static ConveyorBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ConveyorBase), new FrameworkPropertyMetadata(typeof(ConveyorBase)));
        }
    }
}
