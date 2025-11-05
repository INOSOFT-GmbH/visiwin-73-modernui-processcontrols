using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for ThreeWayValve process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for ThreeWayValve controls.
    /// </remarks>
    public class ThreeWayValveInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for ThreeWayValve controls.
        /// </summary>
        public override string VariableMappingName => "ThreeWayValveMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreeWayValveInitializer"/> class.
        /// </summary>
        public ThreeWayValveInitializer() { }
    }
}
