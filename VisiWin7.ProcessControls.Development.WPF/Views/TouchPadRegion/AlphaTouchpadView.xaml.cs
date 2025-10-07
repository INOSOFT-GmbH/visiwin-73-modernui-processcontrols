using System;
using System.Windows;
using System.Windows.Controls;
using VisiWin.Controls;
using VisiWin.ApplicationFramework;
using System.Windows.Input;
using VisiWin.Commands;
using System.ComponentModel;
using System.Threading;

namespace HMI
{
    /// <summary>
    /// Interaction logic for AlphaTouchpadView.xaml
    /// </summary>
    [ExportView("AlphaTouchpadView")]
    public partial class AlphaTouchpadView : VisiWin.Controls.View
    {
        public AlphaTouchpadView()
        {
            this.InitializeComponent();
        }
    }
}