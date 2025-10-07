using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Represents a tank process control element in a WPF application.
    /// Inherits from <see cref="DefaultProcessControlBase"/> and provides specialized properties and logic for tank-related process variables.
    /// </summary>
    public partial class Tank : DefaultProcessControlBase
    {
        /// <summary>
        /// Notifier for changes to the ActualValue property.
        /// </summary>
        private readonly PropertyChangeNotifier actualValuePropertyNotifier;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tank"/> class.
        /// Sets default values for ActualValue and Volume if not in design mode and subscribes to ActualValue changes.
        /// </summary>
        public Tank()
        {
            if (!ApplicationService.IsInDesignMode)
            {
                this.SetCurrentValue(ActualValueProperty, 0);
                this.SetCurrentValue(VolumeProperty, 0);
            }

            this.actualValuePropertyNotifier = new PropertyChangeNotifier(this, ActualValueProperty);
            this.actualValuePropertyNotifier.ValueChanged += OnActualValueChanged;
        }

        /// <summary>
        /// Static constructor for the <see cref="Tank"/> class.
        /// Sets up default style key and metadata for dependency properties.
        /// </summary>
        static Tank()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Tank), new FrameworkPropertyMetadata(typeof(Tank)));
            ActualValueProperty.OverrideMetadata(typeof(Tank), new PropertyMetadata(100));
        }

        /// <summary>
        /// Gets or sets the maximum volume for the tank.
        /// </summary>
        [Category("Process")]
        public int Volume
        {
            get => (int)this.GetValue(VolumeProperty);
            set => this.SetValue(VolumeProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="Volume"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VolumeProperty = DependencyProperty.Register(nameof(Volume), typeof(int), typeof(Tank), new PropertyMetadata(100, OnVolumeChanged));

        /// <summary>
        /// Key for the read-only <see cref="RectangleHeight"/> dependency property.
        /// </summary>
        private static readonly DependencyPropertyKey rectangleHeightPropertyKey = DependencyProperty.RegisterReadOnly(nameof(RectangleHeight), typeof(double),
            typeof(Tank), new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.None));

        /// <summary>
        /// Handles changes to the <see cref="Volume"/> property.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The event arguments.</param>
        private static void OnVolumeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Tank @this)
            {
                @this.OnVolumeChanged(e);
            }
        }
        
        /// <summary>
        /// Identifies the <see cref="RectangleHeight"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty RectangleHeightProperty = rectangleHeightPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the fill level of the tank as a height value.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double RectangleHeight
        {
            get => (double)this.GetValue(RectangleHeightProperty);
            protected set => this.SetValue(rectangleHeightPropertyKey, value);
        }

        /// <summary>
        /// Called when the <see cref="Volume"/> property changes.
        /// Updates the rectangle height.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnVolumeChanged(DependencyPropertyChangedEventArgs e)
        {
            this.SetRectangleHeight();
        }

        /// <summary>
        /// Called when the <see cref="ActualValue"/> property changes.
        /// Updates the rectangle height.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnActualValueChanged(object sender, EventArgs e)
        {
            this.SetRectangleHeight();
        }

        /// <summary>
        /// Called when the control is loaded.
        /// Ensures the rectangle height is set.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        protected override async Task OnLoaded()
        {
            await base.OnLoaded();
            this.SetRectangleHeight();
        }

        /// <summary>
        /// Called when the render size of the control changes.
        /// Updates the rectangle height.
        /// </summary>
        /// <param name="sizeInfo">The size change information.</param>
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            this.SetRectangleHeight();
        }

        /// <summary>
        /// Called when the orientation property changes.
        /// Updates the rectangle height.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnOrientationChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnOrientationChanged(e);
            this.SetRectangleHeight();
        }

        /// <summary>
        /// Calculates and sets the rectangle height based on the current value and volume.
        /// </summary>
        protected virtual void SetRectangleHeight()
        {
            if (this.PartContentPresenter == null)
            {
                return;
            }

            var parentHeight = this.PartContentPresenter.ActualHeight;

            if (this.Volume <= 0 || parentHeight == 0)
            {
                this.RectangleHeight = 0;
                return;
            }

            var factor = parentHeight / this.Volume;

            // The ActualValue of a tank is a settable current value.
            var currentHeight = factor * this.ActualValue;

            this.RectangleHeight = currentHeight <= parentHeight ? currentHeight : parentHeight;
        }
    }
}