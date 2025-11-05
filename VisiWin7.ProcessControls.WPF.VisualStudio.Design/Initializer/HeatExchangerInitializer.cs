using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for HeatExchanger process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for HeatExchanger controls.
    /// </remarks>
    public class HeatExchangerInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for HeatExchanger controls.
        /// </summary>
        public override string VariableMappingName => "HeatExchangerMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="HeatExchangerInitializer"/> class.
        /// </summary>
        public HeatExchangerInitializer() { }
    }
}