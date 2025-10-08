using System.Windows;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Provides an abstract base class for exchanger process controls.
    /// Inherits from <see cref="DefaultProcessControlBase"/> and sets the default style key for exchanger controls.
    /// </summary>
    public abstract class ExchangerBase : DefaultProcessControlBase
    {
        /// <summary>
        /// Static constructor to override the default style key property metadata for <see cref="ExchangerBase"/>.
        /// </summary>
        static ExchangerBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExchangerBase), new FrameworkPropertyMetadata(typeof(ExchangerBase)));
        }
    }
}