using System.Windows;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Provides an abstract base class for engine process controls.
    /// Inherits from <see cref="DefaultProcessControlBase"/> and sets the default style key for engine controls.
    /// </summary>
    public abstract class EngineBase : DefaultProcessControlBase
    {
        /// <summary>
        /// Static constructor to override the default style key property metadata for <see cref="EngineBase"/>.
        /// </summary>
        static EngineBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EngineBase), new FrameworkPropertyMetadata(typeof(EngineBase)));
        }
    }
}
