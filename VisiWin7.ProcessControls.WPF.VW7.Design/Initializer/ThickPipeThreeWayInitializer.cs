using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for ThickPipeThreeWay process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for ThickPipeThreeWay controls.
    /// </remarks>
    public class ThickPipeThreeWayInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for ThickPipeThreeWay controls.
        /// </summary>
        public override string VariableMappingName => "ThickPipeThreeWayMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="ThickPipeThreeWayInitializer"/> class.
        /// </summary>
        public ThickPipeThreeWayInitializer() { }
    }
}