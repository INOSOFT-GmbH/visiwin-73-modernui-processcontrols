using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Represents a base dialog property that provides common functionality for process control dialog properties.
    /// This class implements INotifyPropertyChanged to support data binding in WPF applications.
    /// </summary>
    public class DialogProperty : INotifyPropertyChanged
    {
        private string propertyName;
        private string variableName;
        private string localizableLabelText;

        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        public string PropertyName
        {
            get => this.propertyName;
            set => this.SetField(ref this.propertyName, value);
        }

        /// <summary>
        /// Gets or sets the name of the associated process variable.
        /// </summary>
        public string VariableName
        {
            get => this.variableName;
            set => this.SetField(ref this.variableName, value);
        }

        /// <summary>
        /// Gets or sets the localizable label text for the property.
        /// </summary>
        public string LocalizableLabelText
        {
            get => this.localizableLabelText;
            set => this.SetField(ref this.localizableLabelText, value);
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event for the specified property.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed. This parameter is optional and can be automatically provided by the CallerMemberName attribute.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets the field value and raises the PropertyChanged event if the value has changed.
        /// </summary>
        /// <typeparam name="T">The type of the field.</typeparam>
        /// <param name="field">The field to update.</param>
        /// <param name="value">The new value to set.</param>
        /// <param name="propertyName">The name of the property. This parameter is optional and can be automatically provided by the CallerMemberName attribute.</param>
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