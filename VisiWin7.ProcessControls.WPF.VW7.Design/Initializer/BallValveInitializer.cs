using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for BallValve process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for BallValve controls.
    /// </remarks>
    public class BallValveInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for BallValve controls.
        /// </summary>
        public override string VariableMappingName => "BallValveMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="BallValveInitializer"/> class.
        /// </summary>
        public BallValveInitializer() { }
    }
}