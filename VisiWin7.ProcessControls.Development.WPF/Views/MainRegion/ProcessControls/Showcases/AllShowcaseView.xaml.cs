using System;
using System.Windows;
using System.Windows.Controls;
using VisiWin.Controls;
using VisiWin.ApplicationFramework;

namespace HMI
{
    /// <summary>
    /// Interaction logic for AllShowcaseView.xaml
    /// </summary>
    [ExportView("AllShowcaseView")]
    public partial class AllShowcaseView : VisiWin.Controls.View
    {
        public AllShowcaseView()
        {
            InitializeComponent();
        }
    }
}
