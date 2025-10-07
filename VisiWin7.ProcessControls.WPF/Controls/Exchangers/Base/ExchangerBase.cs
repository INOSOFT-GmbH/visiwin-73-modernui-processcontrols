using System.Windows;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Provides an abstract base class for exchanger process controls in WPF.
    /// Inherits from <see cref="DefaultProcessControlBase"/> and sets up the default style key for derived controls.
    /// 
    /// This class serves as a foundation for all exchanger controls, ensuring that the correct style is applied
    /// and providing a common type hierarchy for further specialization.
    /// </summary>
    /// <remarks>
    /// Derived classes should implement specific exchanger logic and may define additional dependency properties,
    /// methods, and visual states as required.
    /// </remarks>
    public abstract class ExchangerBase : DefaultProcessControlBase
    {
        /// <summary>
        /// Static constructor for the <see cref="ExchangerBase"/> class.
        /// Overrides the default style key property metadata to associate the control with its default style.
        /// </summary>
        /// <remarks>
        /// This ensures that when a control derived from <see cref="ExchangerBase"/> is used in XAML,
        /// the correct style is automatically applied from the resource dictionary.
        /// </remarks>
        static ExchangerBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExchangerBase), new FrameworkPropertyMetadata(typeof(ExchangerBase)));
        }
    }
}