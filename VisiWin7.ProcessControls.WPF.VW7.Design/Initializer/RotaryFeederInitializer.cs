using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for RotaryFeeder process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for RotaryFeeder controls.
    /// </remarks>
    public class RotaryFeederInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for RotaryFeeder controls.
        /// </summary>
        public override string VariableMappingName => "RotaryFeederMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="RotaryFeederInitializer"/> class.
        /// </summary>
        public RotaryFeederInitializer() { }
    }
}