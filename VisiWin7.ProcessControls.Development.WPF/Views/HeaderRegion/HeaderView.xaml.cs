using System;
using System.Windows;
using System.Windows.Controls;
using VisiWin.Controls;
using VisiWin.ApplicationFramework;

namespace HMI
{
    /// <summary>
    /// Interaction logic for HeaderView.xaml
    /// </summary>
    [ExportView("HeaderView")]
    public partial class HeaderView : VisiWin.Controls.View
    {
        public HeaderView()
        {
            this.InitializeComponent();
        }
    }
}