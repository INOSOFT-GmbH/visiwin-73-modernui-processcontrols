using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for Fan process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for Fan controls.
    /// </remarks>
    public class FanInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for Fan controls.
        /// </summary>
        public override string VariableMappingName => "FanInitializerMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="FanInitializer"/> class.
        /// </summary>
        public FanInitializer() { }
    }
}