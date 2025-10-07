using System.Windows;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Provides an abstract base class for engine process controls in WPF.
    /// Inherits from <see cref="DefaultProcessControlBase"/> and sets up the default style key for derived controls.
    /// This class serves as a foundation for custom engine controls, enabling consistent styling and process control integration.
    /// </summary>
    public abstract class EngineBase : DefaultProcessControlBase
    {
        /// <summary>
        /// Static constructor for the <see cref="EngineBase"/> class.
        /// Overrides the default style key property metadata to associate the control with its default style.
        /// </summary>
        static EngineBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EngineBase), new FrameworkPropertyMetadata(typeof(EngineBase)));
        }
    }
}
