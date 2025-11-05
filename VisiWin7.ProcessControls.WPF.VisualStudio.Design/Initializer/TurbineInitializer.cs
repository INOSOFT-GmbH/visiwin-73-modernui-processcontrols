using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for Turbine process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for Turbine controls.
    /// </remarks>
    public class TurbineInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for Turbine controls.
        /// </summary>
        public override string VariableMappingName => "TurbineMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="TurbineInitializer"/> class.
        /// </summary>
        public TurbineInitializer() { }
    }
}