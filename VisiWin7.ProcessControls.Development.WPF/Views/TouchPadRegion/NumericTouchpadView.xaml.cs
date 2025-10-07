using System;
using System.Windows;
using System.Windows.Controls;
using VisiWin.Controls;
using VisiWin.ApplicationFramework;

namespace HMI
{
    /// <summary>
    /// Interaction logic for NumericTouchpadView.xaml
    /// </summary>
    [ExportView("NumericTouchpadView")]
    public partial class NumericTouchpadView :  VisiWin.Controls.View
    {
        public NumericTouchpadView()
        {
            this.InitializeComponent();
        }
    }
}