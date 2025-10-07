using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VisiWin.ApplicationFramework;

namespace HMI
{
	/// <summary>
	/// Interaction logic for ValveView.xaml
	/// </summary>
	[ExportView("ValveView")]
	public partial class ValveView : VisiWin.Controls.View
	{
		public ValveView()
		{
			this.InitializeComponent();
		}
	}
}