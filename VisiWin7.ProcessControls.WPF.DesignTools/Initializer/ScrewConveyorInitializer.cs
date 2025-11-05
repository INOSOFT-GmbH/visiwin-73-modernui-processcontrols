using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for ScrewConveyor process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for ScrewConveyor controls.
    /// </remarks>
    public class ScrewConveyorInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for ScrewConveyor controls.
        /// </summary>
        public override string VariableMappingName => "ScrewConveyorMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrewConveyorInitializer"/> class.
        /// </summary>
        public ScrewConveyorInitializer() { }
    }
}