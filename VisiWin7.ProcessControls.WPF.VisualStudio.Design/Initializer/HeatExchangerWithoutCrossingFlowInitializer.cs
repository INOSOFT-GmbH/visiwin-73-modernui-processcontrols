using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for HeatExchangerWithoutCrossingFlow process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for HeatExchangerWithoutCrossingFlow controls.
    /// </remarks>
    public class HeatExchangerWithoutCrossingFlowInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for HeatExchangerWithoutCrossingFlow controls.
        /// </summary>
        public override string VariableMappingName => "HeatExchangerWithoutCrossingFlowMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="HeatExchangerWithoutCrossingFlowInitializer"/> class.
        /// </summary>
        public HeatExchangerWithoutCrossingFlowInitializer() { }
    }
}