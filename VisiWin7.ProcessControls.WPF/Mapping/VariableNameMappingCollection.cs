using System.Collections.ObjectModel;

namespace VisiWin7.ProcessControls.WPF.Mapping
{
    /// <summary>
    /// Represents a collection of <see cref="VariableNameControlPropertyMapping"/> objects.
    /// Inherits from <see cref="ObservableCollection{T}"/> to provide collection change notifications for data binding scenarios.
    /// </summary>
    public class VariableNameMappingCollection : ObservableCollection<VariableNameControlPropertyMapping>
    {
        // No additional properties or methods are defined in this class.
        // All functionality is inherited from ObservableCollection.
    }
}
