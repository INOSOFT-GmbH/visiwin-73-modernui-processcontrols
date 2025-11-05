using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for FlapValve process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for FlapValve controls.
    /// </remarks>
    public class FlapValveInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for FlapValve controls.
        /// </summary>
        public override string VariableMappingName => "FlapValveMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="FlapValveInitializer"/> class.
        /// </summary>
        public FlapValveInitializer() { }
    }
}