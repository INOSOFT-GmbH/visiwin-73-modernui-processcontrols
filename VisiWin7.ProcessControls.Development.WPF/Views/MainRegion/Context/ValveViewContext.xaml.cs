using System;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;

namespace HMI
{
    /// <summary>
    /// Interaction logic for ValveViewContext.xaml
    /// </summary>
    [ExportView("ValveViewContext")]
    public partial class ValveViewContext : VisiWin.Controls.View
    {
        public ValveViewContext()
        {
            this.InitializeComponent();
        }
    }
}