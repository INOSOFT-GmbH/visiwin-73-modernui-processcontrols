using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using VisiWin.Language;

namespace HMI
{
    /// <summary>
    /// Interaction logic for DateTimeTouchpadView.xaml
    /// </summary>
    [ExportView("DateTimeTouchpadView")]
    public partial class DateTimeTouchpadView : VisiWin.Controls.View
    {
        public DateTimeTouchpadView()
        {
            this.InitializeComponent();
        }
    }
}