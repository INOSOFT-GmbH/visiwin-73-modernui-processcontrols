using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using VisiWin.Async;
using VisiWin.Controls;
using VisiWin7.ProcessControls.WPF.Async;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    public partial class ProcessControlBase
    {
        /// <summary>
        /// Identifies the <see cref="IsAttached"/> dependency property.
        /// This property indicates whether the control is currently attached.
        /// </summary>
        public static readonly DependencyProperty IsAttachedProperty = AttachController.IsAttachedProperty.AddOwner(typeof(ProcessControlBase),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits, IsAttachedPropertyChangedThunk));

        /// <summary>
        /// Gets a value indicating whether the control is currently attached.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsAttached => (bool)this.GetValue(IsAttachedProperty);

        /// <summary>
        /// Called when the control is attached.
        /// Override this method to implement custom attach logic.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        protected virtual async Task OnAttachAsync()
        {
            await this.AttachVariablesAsync();
        }

        /// <summary>
        /// Called when the control is detached.
        /// Override this method to implement custom detach logic.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        protected virtual async Task OnDetachAsync()
        {
            await this.DetachVariablesAsync();
        }

        /// <summary>
        /// An asynchronous lock to ensure that attach and detach operations are not executed concurrently.
        /// </summary>
        private readonly AsyncLock attachOrDetachLock = new AsyncLock();

        /// <summary>
        /// Handles changes to the <see cref="IsAttached"/> property asynchronously.
        /// Ensures the control is loaded before performing attach or detach operations.
        /// </summary>
        /// <param name="e">The event data for the property change.</param>
        protected virtual async void OnIsAttachedChangedAsync(DependencyPropertyChangedEventArgs e)
        {
            await this.CheckLoadedAsync();

            using (await this.attachOrDetachLock.LockAsync().LogPossibleExceptionAsync())
            {
                if ((bool)e.NewValue)
                {
                    await this.OnAttachAsync().LogPossibleExceptionAsync();
                }
                else
                {
                    await this.OnDetachAsync().LogPossibleExceptionAsync();
                }
            }
        }

        /// <summary>
        /// Static callback invoked when the <see cref="IsAttached"/> property changes.
        /// Calls <see cref="OnIsAttachedChangedAsync"/> on the instance.
        /// </summary>
        /// <param name="d">The dependency object on which the property changed.</param>
        /// <param name="e">The event data for the property change.</param>
        private static void IsAttachedPropertyChangedThunk(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (ProcessControlBase)d;
            instance.OnIsAttachedChangedAsync(e);
        }
    }
}