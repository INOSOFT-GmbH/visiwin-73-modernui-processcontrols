using System.Windows;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    public class PumpBase : DefaultProcessControlBase
    {
        static PumpBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PumpBase), new FrameworkPropertyMetadata(typeof(PumpBase)));
        }
    }
}
