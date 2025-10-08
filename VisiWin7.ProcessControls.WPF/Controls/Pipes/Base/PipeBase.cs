using System.Windows;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Provides a base class for pipe process controls.
    /// Inherits from <see cref="DefaultProcessControlBase"/> and sets the default style key for pipe controls.
    /// </summary>
    public abstract class PipeBase : DefaultProcessControlBase
    {
        /// <summary>
        /// Static constructor to override the default style key property metadata for <see cref="PipeBase"/>.
        /// </summary>
        static PipeBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PipeBase), new FrameworkPropertyMetadata(typeof(PipeBase)));
        }
    }
}
