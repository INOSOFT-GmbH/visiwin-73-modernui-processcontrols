using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using VisiWin.Controls;

namespace VisiWin7.ProcessControls.WPF.States
{
    /// <summary>
    /// Represents a state for a brush that supports blinking behavior in a WPF application.
    /// Inherits from <see cref="BrushState"/> and implements <see cref="INotifyPropertyChanged"/> to support data binding.
    /// </summary>
    public class BlinkBrushState : BrushState, INotifyPropertyChanged
    {
        private bool isBlinkEnabled;

        /// <summary>
        /// Gets or sets a value indicating whether blinking is enabled for this state.
        /// </summary>
        public bool IsBlinkEnabled
        {
            get => this.isBlinkEnabled;
            set => this.SetField(ref this.isBlinkEnabled, value);
        }

        /// <summary>
        /// Gets or sets the brush used for the blinking effect.
        /// </summary>
        public SolidColorBrush BlinkBrush
        {
            get => (SolidColorBrush)this.GetValue(BlinkBrushProperty);
            set => this.SetValue(BlinkBrushProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="BlinkBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BlinkBrushProperty =
            DependencyProperty.Register(nameof(BlinkBrush), typeof(SolidColorBrush), typeof(BlinkBrushState), new PropertyMetadata(Brushes.White));

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets the field and raises the <see cref="PropertyChanged"/> event if the value changes.
        /// </summary>
        /// <typeparam name="T">The type of the field.</typeparam>
        /// <param name="field">The field to set.</param>
        /// <param name="value">The new value.</param>
        /// <param name="propertyName">The name of the property. This is optional and is automatically provided by the compiler.</param>
        /// <returns>True if the value was changed; otherwise, false.</returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }
}