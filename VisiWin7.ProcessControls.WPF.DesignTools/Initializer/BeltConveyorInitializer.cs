using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for BeltConveyor process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for BeltConveyor controls.
    /// </remarks>
    public class BeltConveyorInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for BeltConveyor controls.
        /// </summary>
        public override string VariableMappingName => "BeltConveyorMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="BeltConveyorInitializer"/> class.
        /// </summary>
        public BeltConveyorInitializer() { }
    }
}