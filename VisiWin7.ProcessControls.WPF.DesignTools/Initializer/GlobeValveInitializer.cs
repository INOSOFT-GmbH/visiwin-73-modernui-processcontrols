using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for GlobeValve process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for GlobeValve controls.
    /// </remarks>
    public class GlobeValveInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for GlobeValve controls.
        /// </summary>
        public override string VariableMappingName => "GlobeValveMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobeValveInitializer"/> class.
        /// </summary>
        public GlobeValveInitializer() { }
    }
}