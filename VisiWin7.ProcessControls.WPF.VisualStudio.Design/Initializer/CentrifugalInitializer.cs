using VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    /// <summary>
    /// Provides initialization logic for Centrifugal process control elements in the designer.
    /// </summary>
    /// <remarks>
    /// This initializer sets up default variable mapping and configuration for Centrifugal controls.
    /// </remarks>
    public class CentrifugalInitializer : ProcessControlBaseInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource for Centrifugal controls.
        /// </summary>
        public override string VariableMappingName => "CentrifugalMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="CentrifugalInitializer"/> class.
        /// </summary>
        public CentrifugalInitializer() { }
    }
}