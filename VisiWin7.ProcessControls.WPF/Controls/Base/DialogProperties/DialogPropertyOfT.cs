namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Represents a generic dialog property that holds a strongly-typed value.
    /// This class extends the base DialogProperty class to provide type-safe property values.
    /// </summary>
    /// <typeparam name="T">The type of the property value.</typeparam>
    public class DialogProperty<T>: DialogProperty
    {
        private T propertyValue;

        /// <summary>
        /// Gets or sets the typed value of the property.
        /// </summary>
        public T PropertyValue
        {
            get => this.propertyValue;
            set => this.SetField(ref this.propertyValue, value);
        }
    }
}