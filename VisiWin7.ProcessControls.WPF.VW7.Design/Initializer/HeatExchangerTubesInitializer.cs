using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for HeatExchangerTubes process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for HeatExchangerTubes controls.
    /// </remarks>
    public class HeatExchangerTubesInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for HeatExchangerTubes controls.
        /// </summary>
        public override string VariableMappingName => "HeatExchangerTubesMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="HeatExchangerTubesInitializer"/> class.
        /// </summary>
        public HeatExchangerTubesInitializer() { }
    }
}