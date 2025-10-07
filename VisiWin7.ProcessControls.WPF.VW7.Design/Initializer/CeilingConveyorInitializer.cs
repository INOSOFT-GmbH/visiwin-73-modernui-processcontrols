using System;
using System.Windows;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.Model;
using VisiWin.WpfPropertyGrid;
using VisiWin7.ProcessControls.WPF.Controls;
using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for CeilingConveyor process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for CeilingConveyor controls.
    /// </remarks>
    public class CeilingConveyorInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for CeilingConveyor controls.
        /// </summary>
        public override string VariableMappingName => "CeilingConveyorMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="CeilingConveyorInitializer"/> class.
        /// </summary>
        public CeilingConveyorInitializer() { }
    }
}