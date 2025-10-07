using System;
using System.Windows;
using System.Windows.Controls;
using VisiWin.Controls;
using VisiWin.ApplicationFramework;

namespace HMI
{
    /// <summary>
    /// Interaction logic for FooterView.xaml
    /// </summary>
    [ExportView("FooterView")]
    public partial class FooterView : VisiWin.Controls.View
    {
        public FooterView()
        {
            this.InitializeComponent();
        }
    }
}