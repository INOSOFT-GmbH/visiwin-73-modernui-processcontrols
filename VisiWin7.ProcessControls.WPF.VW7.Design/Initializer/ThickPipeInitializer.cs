using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for ThickPipe process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for ThickPipe controls.
    /// </remarks>
    public class ThickPipeInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for ThickPipe controls.
        /// </summary>
        public override string VariableMappingName => "ThickPipeMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="ThickPipeInitializer"/> class.
        /// </summary>
        public ThickPipeInitializer() { }
    }
}