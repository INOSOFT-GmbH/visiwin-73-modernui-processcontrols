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
    /// Interaction logic for PasswordTouchpadView.xaml
    /// </summary>
    [ExportView("PasswordTouchpadView")]
    public partial class PasswordTouchpadView : VisiWin.Controls.View
    {
        public PasswordTouchpadView()
        {
            this.InitializeComponent();
        }
    }
}