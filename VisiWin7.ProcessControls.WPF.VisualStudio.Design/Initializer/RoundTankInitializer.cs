using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for RoundTank process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for RoundTank controls.
    /// </remarks>
    public class RoundTankInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for RoundTank controls.
        /// </summary>
        public override string VariableMappingName => "RoundTankMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="RoundTankInitializer"/> class.
        /// </summary>
        public RoundTankInitializer() { }
    }
}