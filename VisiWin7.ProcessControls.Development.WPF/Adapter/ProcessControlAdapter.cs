using System.ComponentModel.Composition;
using VisiWin.ApplicationFramework;

namespace HMI.Adapter
{
    /// <summary>
    /// Provides an adapter for process control functionality in the HMI application.
    /// Inherits from <see cref="AdapterBase"/> and manages frame template state for process controls.
    /// </summary>
    [Export]
    [ExportAdapter(nameof(ProcessControlAdapter))]
    public class ProcessControlAdapter : AdapterBase
    {
        private bool isFrameTemplateActive = true;

        /// <summary>
        /// Gets or sets a value indicating whether the frame template is currently active.
        /// </summary>
        /// <value>
        /// <c>true</c> if the frame template is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsFrameTemplateActive
        {
            get => this.isFrameTemplateActive;
            set
            {
                if (value == this.isFrameTemplateActive)
                {
                    return;
                }

                this.isFrameTemplateActive = value;
                this.OnPropertyChanged();
            }
        }
    }
}
