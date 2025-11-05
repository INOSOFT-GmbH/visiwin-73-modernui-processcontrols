using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for Motor process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for Motor controls.
    /// </remarks>
    public class MotorInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for Motor controls.
        /// </summary>
        public override string VariableMappingName => "MotorMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="MotorInitializer"/> class.
        /// </summary>
        public MotorInitializer() { }
    }
}