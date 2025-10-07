using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisiWin.ApplicationFramework;
using VisiWin.Async;
using VisiWin.Helper.Design;
using VisiWin.Project;
using VisiWin7.ProcessControls.WPF.Mapping;
using VisiWin7.ProcessControls.WPF.States;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Abstract base class for process control elements in WPF.
    /// Provides dependency properties, state management, and initialization logic for derived controls.
    /// Handles state brushes, variable mapping, orientation, error notification alignment, and stroke thickness.
    /// Supports asynchronous loading and unloading, and integrates with design-time and runtime services.
    /// </summary>
    [TemplatePart(Name = "PART_ContentPresenter", Type = typeof(ContentPresenter))]
    public abstract partial class ProcessControlBase : Control, INotifyPropertyChanged
    {
        /// <summary>
        /// TaskCompletionSource to signal when the control has finished loading.
        /// </summary>
        private readonly TaskCompletionSource<bool> loadedCompleted;

        /// <summary>
        /// Notifier for the loaded task, used for async property binding.
        /// </summary>
        private NotifyTask loadedNotifier;

        /// <summary>
        /// Gets or sets the collection of state brushes used for visual state representation.
        /// </summary>
        [Category("Process")]
        public BlinkBrushStateCollection StateBrushes
        {
            get => (BlinkBrushStateCollection)this.GetValue(StateBrushesProperty);
            set => this.SetValue(StateBrushesProperty, value);
        }

        /// <summary>
        /// Dependency property for <see cref="StateBrushes"/>.
        /// </summary>
        public static readonly DependencyProperty StateBrushesProperty = DependencyProperty.Register(nameof(StateBrushes), typeof(BlinkBrushStateCollection), typeof(ProcessControlBase),
            new PropertyMetadata(null, OnControlStatesChanged));

        /// <summary>
        /// Dependency property key for the current state brush.
        /// </summary>
        private static readonly DependencyPropertyKey currentStateBrushPropertyKey = DependencyProperty.RegisterReadOnly(nameof(CurrentStateBrush), typeof(BlinkBrushState),
            typeof(ProcessControlBase), new FrameworkPropertyMetadata(default(BlinkBrushState), FrameworkPropertyMetadataOptions.None));

        /// <summary>
        /// Dependency property for <see cref="CurrentStateBrush"/>.
        /// </summary>
        public static readonly DependencyProperty CurrentStateBrushProperty = currentStateBrushPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the current state brush, which reflects the current visual state of the control.
        /// </summary>
        [Category("Process")]
        public BlinkBrushState CurrentStateBrush
        {
            get => (BlinkBrushState)this.GetValue(CurrentStateBrushProperty);
            protected set => this.SetValue(currentStateBrushPropertyKey, value);
        }

        /// <summary>
        /// Gets or sets the collection of variable-to-property mappings for the control.
        /// </summary>
        [Category("Process")]
        public VariableNameMappingCollection Mapping
        {
            get => (VariableNameMappingCollection)this.GetValue(MappingProperty);
            set => this.SetValue(MappingProperty, value);
        }

        /// <summary>
        /// Dependency property for <see cref="Mapping"/>.
        /// </summary>
        public static readonly DependencyProperty MappingProperty = DependencyProperty.Register(nameof(Mapping), typeof(VariableNameMappingCollection),
            typeof(ProcessControlBase), new PropertyMetadata(default));

        /// <summary>
        /// Gets or sets the orientation (Dock) of the control.
        /// </summary>
        [Category("Process")]
        public Dock Orientation
        {
            get => (Dock)this.GetValue(OrientationProperty);
            set => this.SetValue(OrientationProperty, value);
        }

        /// <summary>
        /// Dependency property for <see cref="Orientation"/>.
        /// </summary>
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register(nameof(Orientation), typeof(Dock), typeof(ProcessControlBase), new PropertyMetadata(Dock.Top, OnOrientationChanged));

        /// <summary>
        /// Gets or sets the vertical alignment for error notifications.
        /// </summary>
        [Category("Process")]
        public VerticalAlignment ErrorNotificationVerticalAlignment
        {
            get => (VerticalAlignment)this.GetValue(ErrorNotificationVerticalAlignmentProperty);
            set => this.SetValue(ErrorNotificationVerticalAlignmentProperty, value);
        }

        /// <summary>
        /// Dependency property for <see cref="ErrorNotificationVerticalAlignment"/>.
        /// </summary>
        public static readonly DependencyProperty ErrorNotificationVerticalAlignmentProperty = DependencyProperty.Register(nameof(ErrorNotificationVerticalAlignment),
            typeof(VerticalAlignment), typeof(ProcessControlBase), new PropertyMetadata(VerticalAlignment.Top));

        /// <summary>
        /// Gets or sets the horizontal alignment for error notifications.
        /// </summary>
        [Category("Process")]
        public HorizontalAlignment ErrorNotificationHorizontalAlignment
        {
            get => (HorizontalAlignment)this.GetValue(ErrorNotificationHorizontalAlignmentProperty);
            set => this.SetValue(ErrorNotificationHorizontalAlignmentProperty, value);
        }

        /// <summary>
        /// Dependency property for <see cref="ErrorNotificationHorizontalAlignment"/>.
        /// </summary>
        public static readonly DependencyProperty ErrorNotificationHorizontalAlignmentProperty = DependencyProperty.Register(nameof(ErrorNotificationHorizontalAlignment),
            typeof(HorizontalAlignment), typeof(ProcessControlBase), new PropertyMetadata(HorizontalAlignment.Right));

        /// <summary>
        /// Gets or sets the stroke thickness for the control's visual elements.
        /// </summary>
        [Category("Process")]
        public double StrokeThickness
        {
            get => (double)this.GetValue(StrokeThicknessProperty);
            set => this.SetValue(StrokeThicknessProperty, value);
        }

        /// <summary>
        /// Dependency property for <see cref="StrokeThickness"/>.
        /// </summary>
        public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(nameof(StrokeThickness),
            typeof(double), typeof(ProcessControlBase), new PropertyMetadata(2.0));

        /// <summary>
        /// Gets the content presenter part from the control template.
        /// </summary>
        protected ContentPresenter PartContentPresenter { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessControlBase"/> class.
        /// Sets up default values, event handlers, and async loading notifier.
        /// </summary>
        private protected ProcessControlBase()
        {
            this.SetCurrentValue(MappingProperty, new VariableNameMappingCollection());
            this.SetCurrentValue(StateBrushesProperty, new BlinkBrushStateCollection());

            this.loadedCompleted = new TaskCompletionSource<bool>();
            if (!ApplicationService.IsInDesignMode)
            {
                this.LoadedNotifier = NotifyTask.Create((Task)this.loadedCompleted.Task);
            }

            this.Loaded += async (sender, e) => await this.OnInternalLoaded().LogPossibleExceptionAsync();
            this.Unloaded += async (sender, e) => await this.OnUnloaded().LogPossibleExceptionAsync();
        }

        /// <summary>
        /// Static constructor to override the default style key.
        /// </summary>
        static ProcessControlBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ProcessControlBase), new FrameworkPropertyMetadata(typeof(ProcessControlBase)));
        }

        /// <summary>
        /// Applies the control template and retrieves template parts.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.PartContentPresenter = this.GetTemplateChild("PART_ContentPresenter") as ContentPresenter;
        }

        /// <summary>
        /// Handles the internal loading logic and signals completion.
        /// </summary>
        private async Task OnInternalLoaded()
        {
            await this.OnLoaded();
            this.loadedCompleted.TrySetResult(true);
        }

        /// <summary>
        /// Called when the control is loaded. Initializes services and updates state.
        /// Can be overridden in derived classes.
        /// </summary>
        /// <returns>A task representing the async operation.</returns>
        protected virtual async Task OnLoaded()
        {
            if (ApplicationService.IsInDesignMode)
            {
                return;
            }

            this.InitializeBlinkService();
            await this.InitializeLanguageServiceAsync();
            await this.InitializeVariableServiceAsync();

            var projectService = ApplicationService.GetService<IProjectService>();
            if (projectService == null || !projectService.KeepViewsLoaded)
            {
                this.SetValue(IsAttachedProperty, true);
            }

            this.OnControlStatesChanges();
        }

        /// <summary>
        /// Called when the control is unloaded. Cleans up resources.
        /// Can be overridden in derived classes.
        /// </summary>
        /// <returns>A completed task.</returns>
        protected virtual Task OnUnloaded()
        {
            var projectService = ApplicationService.GetService<IProjectService>();
            if (projectService == null || !projectService.KeepViewsLoaded)
            {
                this.SetValue(IsAttachedProperty, false);
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets the task that completes when the control is loaded.
        /// </summary>
        public Task LoadedTask => this.LoadedNotifier?.Task;

        /// <summary>
        /// Gets or sets the loaded notifier for async property binding.
        /// </summary>
        public NotifyTask LoadedNotifier
        {
            get => this.loadedNotifier;
            protected set
            {
                if (Equals(value, this.loadedNotifier))
                {
                    return;
                }

                this.loadedNotifier = value;

                this.OnPropertyChanged();
                this.OnPropertyChanged(nameof(this.LoadedTask));
            }
        }

        /// <summary>
        /// Awaits the loaded task, ensuring the control is fully loaded.
        /// </summary>
        /// <returns>A task representing the async operation.</returns>
        protected async Task CheckLoadedAsync()
        {
            if (this.LoadedTask != null)
            {
                await this.LoadedTask.LogPossibleExceptionAsync();
            }
        }

        /// <summary>
        /// Called when the control's state collection changes.
        /// Can be overridden in derived classes to update visual states.
        /// </summary>
        protected virtual void OnControlStatesChanges() { }

        /// <summary>
        /// Updates the control's state based on a variable value.
        /// </summary>
        /// <param name="variableValue">The value to use for state selection.</param>
        protected void UpdateControlStates(object variableValue)
        {
            var typeChangedValue = Convert.ChangeType(variableValue, typeof(int));
            if (typeChangedValue != null)
            {
                this.UpdateControlStates((int)typeChangedValue);
            }
        }

        /// <summary>
        /// Called when the orientation property changes.
        /// Can be overridden in derived classes.
        /// </summary>
        /// <param name="e">The event args.</param>
        protected virtual void OnOrientationChanged(DependencyPropertyChangedEventArgs e)
        {
        }

        /// <summary>
        /// Coerces the label text for design-time or runtime localization.
        /// </summary>
        /// <param name="baseValue">The base value.</param>
        /// <returns>The coerced label text.</returns>
        protected virtual object OnCoerceLabelText(object baseValue)
        {
            if (ApplicationService.IsInDesignMode)
            {
                if (!string.IsNullOrEmpty(this.LocalizableLabelText))
                {
                    return DesignTimeHelper.GetText(this.LocalizableLabelText);
                }
            }
            else
            {
                if (this.LocalizedLabelText != null && !string.IsNullOrEmpty(this.LocalizableLabelText))
                {
                    return this.LocalizedLabelText.DisplayText;
                }
            }

            return baseValue;
        }

        /// <summary>
        /// Static handler for orientation property changes.
        /// </summary>
        private static void OnOrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ProcessControlBase controlBase)
            {
                controlBase.OnOrientationChanged(e);
            }
        }

        /// <summary>
        /// Static handler for state brushes property changes.
        /// </summary>
        private static void OnControlStatesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ProcessControlBase controlBase)
            {
                controlBase.OnControlStatesChanges();
            }
        }

        /// <summary>
        /// Updates the control's state based on an integer value.
        /// </summary>
        /// <param name="variableValue">The integer value representing the state.</param>
        private void UpdateControlStates(int variableValue)
        {
            if (this.StateBrushes == null)
            {
                return;
            }

            var currentState = this.StateBrushes.FirstOrDefaultByStateValue(variableValue);
            this.SetValue(currentStateBrushPropertyKey, currentState);
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets a field and raises the <see cref="PropertyChanged"/> event if the value changes.
        /// </summary>
        /// <typeparam name="T">The type of the field.</typeparam>
        /// <param name="field">The field to set.</param>
        /// <param name="value">The new value.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>True if the value was changed; otherwise, false.</returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }
}