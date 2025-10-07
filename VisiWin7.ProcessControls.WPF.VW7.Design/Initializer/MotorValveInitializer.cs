using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for MotorValve process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for MotorValve controls.
    /// </remarks>
    public class MotorValveInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for MotorValve controls.
        /// </summary>
        public override string VariableMappingName => "MotorValveMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="MotorValveInitializer"/> class.
        /// </summary>
        public MotorValveInitializer() { }
    }
}