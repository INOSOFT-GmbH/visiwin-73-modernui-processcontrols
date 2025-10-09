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
	/// Interaction logic for EngineViewContext.xaml
	/// </summary>
	[ExportView("EngineViewContext")]
	public partial class EngineViewContext : VisiWin.Controls.View
	{
		public EngineViewContext()
		{
			this.InitializeComponent();
		}
	}
}