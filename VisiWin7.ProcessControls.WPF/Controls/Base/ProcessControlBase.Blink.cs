using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using VisiWin.ApplicationFramework;
using VisiWin.Blink;
using VisiWin.Controls;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    public partial class ProcessControlBase : IBlinkProvider
    {
        /// <summary>
        /// Identifies the <see cref="BlinkBrush"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BlinkBrushProperty = DependencyProperty.Register(nameof(BlinkBrush), typeof(Brush), typeof(ProcessControlBase), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the <see cref="BlinkCycle"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BlinkCycleProperty =
            DependencyProperty.Register(nameof(BlinkCycle), typeof(int), typeof(ProcessControlBase), new PropertyMetadata(1, OnBlinkCyclePropertyChanged));

        /// <summary>
        /// Identifies the <see cref="IsBlinkEnabled"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsBlinkEnabledProperty =
            DependencyProperty.Register(nameof(IsBlinkEnabled), typeof(bool), typeof(ProcessControlBase), new PropertyMetadata(false, OnIsBlinkEnabledPropertyChanged));

        /// <summary>
        /// Identifies the <see cref="BlinkMode"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BlinkModeProperty =
            DependencyProperty.Register(nameof(BlinkMode), typeof(BlinkMode), typeof(ProcessControlBase), new PropertyMetadata(BlinkMode.BlinkBrush));

        /// <summary>
        /// Identifies the <see cref="BlinkState"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty BlinkStateProperty = DependencyProperty.Register(nameof(BlinkState), typeof(bool), typeof(ProcessControlBase), new PropertyMetadata(false));

        /// <summary>
        /// Gets or sets the brush used for blinking effect.
        /// </summary>
        [Category("Brushes")]
        public Brush BlinkBrush
        {
            get => (Brush)this.GetValue(BlinkBrushProperty);
            set => this.SetValue(BlinkBrushProperty, value);
        }

        /// <summary>
        /// Gets or sets the blink cycle duration.
        /// </summary>
        [Category("Blink")]
        public int BlinkCycle
        {
            get => (int)this.GetValue(BlinkCycleProperty);
            set => this.SetValue(BlinkCycleProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether blinking is enabled.
        /// </summary>
        [Category("Blink")]
        public bool IsBlinkEnabled
        {
            get => (bool)this.GetValue(IsBlinkEnabledProperty);
            set => this.SetValue(IsBlinkEnabledProperty, value);
        }

        /// <summary>
        /// Gets or sets the mode of blinking.
        /// </summary>
        [Category("Blink")]
        public BlinkMode BlinkMode
        {
            get => (BlinkMode)this.GetValue(BlinkModeProperty);
            set => this.SetValue(BlinkModeProperty, value);
        }

        /// <summary>
        /// Gets the current state of the blink (on/off).
        /// </summary>
        [Category("Blink")]
        public bool BlinkState
        {
            get => (bool)this.GetValue(BlinkStateProperty);
            private set => this.SetValue(BlinkStateProperty, value);
        }

        /// <summary>
        /// Gets the blink service used to manage blinking timers.
        /// </summary>
        protected IBlinkService BlinkService { get; private set; }

        /// <summary>
        /// Gets the blink timer instance associated with this control.
        /// </summary>
        protected IBlinkTimer BlinkTimer { get; private set; }

        /// <summary>
        /// Initializes the blink service and timer if not already initialized.
        /// Subscribes to the blink timer event to update the blink state.
        /// </summary>
        protected virtual void InitializeBlinkService()
        {
            if (this.BlinkService == null)
            {
                // Get the BlinkService if not already set
                this.BlinkService = ApplicationService.GetService<IBlinkService>();
            }

            if (this.BlinkService != null)
            {
                if (this.BlinkTimer == null)
                {
                    this.BlinkTimer = this.BlinkService.GetBlinkTimer(this.BlinkCycle, this.IsBlinkEnabled);
                    if (this.BlinkTimer != null)
                    {
                        this.BlinkTimer.DoBlink += (s, e) => this.OnBlinkTimerDoBlink(e);

                        this.BlinkState = this.BlinkTimer.CurrentState;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the blink timer event and updates the <see cref="BlinkState"/> property.
        /// </summary>
        /// <param name="e">The <see cref="BlinkEventArgs"/> containing the new blink state.</param>
        protected virtual void OnBlinkTimerDoBlink(BlinkEventArgs e)
        {
            // Transfer the value from the BlinkTimer to the property
            this.BlinkState = e.BlinkState;
        }

        /// <summary>
        /// Handles changes to the <see cref="BlinkCycle"/> property.
        /// Updates the blink timer's cycle value.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected virtual async void OnBlinkCycleChanged(DependencyPropertyChangedEventArgs e)
        {
            var blinkTimer = this.BlinkTimer;

            await this.CheckLoadedAsync();

            // If BlinkTimer exists, update its BlinkCycle property
            if (blinkTimer != null)
            {
                blinkTimer.BlinkCycle = (int)e.NewValue;
            }
        }

        /// <summary>
        /// Handles changes to the <see cref="IsBlinkEnabled"/> property.
        /// Enables or disables the blink timer accordingly.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected virtual async void OnIsBlinkEnabledChanged(DependencyPropertyChangedEventArgs e)
        {
            var blinkTimer = this.BlinkTimer;

            await this.CheckLoadedAsync();

            if (blinkTimer != null)
            {
                blinkTimer.Enable = (bool)e.NewValue;

                if (!blinkTimer.Enable)
                {
                    this.BlinkState = false;
                }
            }
        }

        /// <summary>
        /// Static callback for changes to the <see cref="BlinkCycle"/> property.
        /// Invokes the instance method to handle the change.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The event data.</param>
        private static void OnBlinkCyclePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (ProcessControlBase)d;
            instance.OnBlinkCycleChanged(e);
        }

        /// <summary>
        /// Static callback for changes to the <see cref="IsBlinkEnabled"/> property.
        /// Invokes the instance method to handle the change.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The event data.</param>
        private static void OnIsBlinkEnabledPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (ProcessControlBase)d;
            instance.OnIsBlinkEnabledChanged(e);
        }
    }
}