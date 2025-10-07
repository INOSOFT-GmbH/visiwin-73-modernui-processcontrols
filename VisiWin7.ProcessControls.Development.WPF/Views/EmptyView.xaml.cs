using System;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel.Composition;
using VisiWin.Controls;
using VisiWin.ApplicationFramework;

namespace HMI
{
    /// <summary>
    /// Interaction logic for EmptyView.xaml
    /// </summary>
    [ExportView("EmptyView")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class EmptyView : VisiWin.Controls.View
    {
        public EmptyView()
        {
            this.InitializeComponent();
        }
    }
}