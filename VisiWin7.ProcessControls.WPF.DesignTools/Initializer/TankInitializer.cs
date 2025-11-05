using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for Tank process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for Tank controls.
    /// </remarks>
    public class TankInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for Tank controls.
        /// </summary>
        public override string VariableMappingName => "TankMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="TankInitializer"/> class.
        /// </summary>
        public TankInitializer() { }
    }
}