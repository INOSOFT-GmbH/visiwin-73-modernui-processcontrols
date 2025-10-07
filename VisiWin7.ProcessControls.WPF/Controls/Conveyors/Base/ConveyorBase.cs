using System.Windows;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Abstract base class for conveyor controls in WPF process control applications.
    /// <para>
    /// This class provides the foundation for all conveyor-related controls by inheriting from <see cref="DefaultProcessControlBase"/>.
    /// It ensures that the default style key is set to the type of the derived conveyor control, enabling custom styling and templating in XAML.
    /// </para>
    /// <remarks>
    /// Derive from this class to implement specific conveyor controls with custom behavior and appearance.
    /// </remarks>
    /// <example>
    /// <code>
    /// public class MyConveyor : ConveyorBase
    /// {
    ///     // Custom implementation
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public abstract class ConveyorBase : DefaultProcessControlBase
    {
        /// <summary>
        /// Static constructor for the <see cref="ConveyorBase"/> class.
        /// <para>
        /// Overrides the <see cref="FrameworkElement.DefaultStyleKeyProperty"/> metadata to associate the default style with this control type.
        /// This enables the use of custom control templates defined in XAML for all controls derived from <see cref="ConveyorBase"/>.
        /// </para>
        /// </summary>
        static ConveyorBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ConveyorBase), new FrameworkPropertyMetadata(typeof(ConveyorBase)));
        }
    }
}
