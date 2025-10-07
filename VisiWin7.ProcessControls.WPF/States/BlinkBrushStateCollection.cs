using System.Linq;
using System.Windows.Media;
using VisiWin.Controls;

namespace VisiWin7.ProcessControls.WPF.States
{
    /// <summary>
    /// Represents a collection of <see cref="BlinkBrushState"/> objects.
    /// Inherits from <see cref="ObservableStateCollection{T}"/> to provide collection change notifications and state management for blinking brush states.
    /// </summary>
    public class BlinkBrushStateCollection : ObservableStateCollection<BlinkBrushState>
    {
        /// <summary>
        /// Returns the first <see cref="BlinkBrushState"/> in the collection that matches the specified brush, or null if no match is found.
        /// </summary>
        /// <param name="brush">The brush to search for.</param>
        /// <returns>The first matching <see cref="BlinkBrushState"/>, or null if none is found.</returns>
        public BlinkBrushState FirstOrDefaultByBrush(Brush brush)
        {
            return this.FirstOrDefault(st => st.Brush == brush);
        }
    }
}