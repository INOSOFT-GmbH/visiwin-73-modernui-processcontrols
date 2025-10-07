using System;
using System.Windows;
using System.Windows.Controls;
using VisiWin.Controls;
using VisiWin.ApplicationFramework;

namespace HMI
{
    /// <summary>
    /// Interaction logic for GeneralShowcaseView.xaml
    /// </summary>
    [ExportView("GeneralShowcaseView")]
    public partial class GeneralShowcaseView : VisiWin.Controls.View
    {
        public GeneralShowcaseView()
        {
            InitializeComponent();
        }
    }
}
