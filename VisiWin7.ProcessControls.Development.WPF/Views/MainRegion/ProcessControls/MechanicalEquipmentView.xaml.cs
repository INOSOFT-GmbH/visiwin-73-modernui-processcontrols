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
	/// Interaction logic for View1.xaml
	/// </summary>
	[ExportView("MechanicalEquipmentView")]
	public partial class MechanicalEquipmentView : VisiWin.Controls.View
	{
		public MechanicalEquipmentView()
		{
			this.InitializeComponent();
		}
	}
}