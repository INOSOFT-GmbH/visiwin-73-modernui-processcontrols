using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.Model;

namespace VisiWin7.ProcessControls.WPF.VW7.Design
{
    public class SampleDefaultInitializer : DefaultInitializer
    {
        public override void InitializeDefaults(ModelItem item)
        {
            base.InitializeDefaults(item);

            //switch (item.ItemType.FullName)
            //{
            //    case "HMI.Components.Controls.CustomEditorControl":
            //        item.Properties[new PropertyIdentifier(typeof(CustomEditorControl), "Width")].SetValue(200.0);
            //        item.Properties[new PropertyIdentifier(typeof(CustomEditorControl), "Height")].SetValue(200.0);
            //        break;
            //}

  
        }
    }
}