using System.Windows;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Provides a base class for valve process control elements in a WPF application.
    /// Inherits from <see cref="DefaultProcessControlBase"/> and sets up the default style key for derived valve controls.
    /// This class is intended to be used as a foundation for custom valve controls, enabling consistent styling and process control integration.
    /// </summary>
    public class ValveBase : DefaultProcessControlBase
    {
        /// <summary>
        /// Static constructor for the <see cref="ValveBase"/> class.
        /// Overrides the default style key property metadata to associate the control with its default style.
        /// </summary>
        static ValveBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ValveBase), new FrameworkPropertyMetadata(typeof(ValveBase)));
        }
        // No additional properties or methods are defined in this class.
        // All functionality is inherited from DefaultProcessControlBase.
    }
}