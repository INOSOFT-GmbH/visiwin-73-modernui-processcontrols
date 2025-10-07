using System;
using System.Windows;
using System.Windows.Controls;
using VisiWin.Controls;
using VisiWin.ApplicationFramework;

namespace HMI
{
    /// <summary>
    /// Interaction logic for HelpView.xaml
    /// </summary>
    [ExportView("HelpView")]
    public partial class HelpView : VisiWin.Controls.View
    {
        public HelpView()
        {
            InitializeComponent();
        }
    }
}
