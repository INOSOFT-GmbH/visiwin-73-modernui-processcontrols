using VisiWin.ApplicationFramework;

namespace HMI
{
    [ExportView("MessageBoxView")]
    public partial class MessageBoxView : VisiWin.Controls.View
    {
        public MessageBoxView()
        {
            this.InitializeComponent();
        }
    }
}