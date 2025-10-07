using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using VisiWin.ApplicationFramework;
using VisiWin.Async;
using VisiWin.Controls;
using VisiWin.Events;
using VisiWin.Language;
using VisiWin.Plugin;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    public partial class ProcessControlBase : ILabelTextProvider
    {
        /// <summary>
        /// Identifies the <see cref="LabelText"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register(
            nameof(LabelText),
            typeof(string),
            typeof(ProcessControlBase),
            new FrameworkPropertyMetadata(string.Empty, null, CoerceLabelTextProperty));

        /// <summary>
        /// Identifies the <see cref="LocalizableLabelText"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty LocalizableLabelTextProperty = DependencyProperty.Register(
            nameof(LocalizableLabelText),
            typeof(string),
            typeof(ProcessControlBase),
            new PropertyMetadata(string.Empty, OnLocalizableLabelTextPropertyChanged));

        /// <summary>
        /// Event sink for handling language changed events.
        /// </summary>
        private EventSink<LanguageChangedEventArgs> languageChangedEventSink;

        /// <summary>
        /// Gets or sets the label text displayed by the control.
        /// </summary>
        [Category("Label")]
        public string LabelText
        {
            get => (string)this.GetValue(LabelTextProperty);
            set => this.SetValue(LabelTextProperty, value);
        }

        /// <summary>
        /// Gets or sets the localizable label text key used for localization.
        /// </summary>
        [Category("Label")]
        public string LocalizableLabelText
        {
            get => (string)this.GetValue(LocalizableLabelTextProperty);
            set => this.SetValue(LocalizableLabelTextProperty, value);
        }

        /// <summary>
        /// Gets the language service used for localization.
        /// </summary>
        protected ILanguageService LanguageService { get; private set; }

        /// <summary>
        /// Gets the localized label text instance.
        /// </summary>
        protected ILocalizedText LocalizedLabelText { get; private set; }

        /// <summary>
        /// Initializes the language service and sets up localization for the label text.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        protected virtual async Task InitializeLanguageServiceAsync()
        {
            if (this.LanguageService == null)
            {
                this.LanguageService = ApplicationService.GetService<ILanguageService>();
            }

            if (this.LanguageService != null)
            {
                if (this.languageChangedEventSink == null)
                {
                    this.languageChangedEventSink = new EventSink<LanguageChangedEventArgs>((s, e) => this.OnLanguageChanged(e));
                    this.LanguageService.LanguageChanged += this.languageChangedEventSink.OnEvent;
                }

                if (this.LocalizedLabelText == null)
                {
                    this.LocalizedLabelText = await this.LanguageService.CreateLocalizedTextAsync();
                    if (this.LocalizedLabelText != null)
                    {
                        var pluginContext = (string)this.GetValue(View.PluginContextProperty);

                        var textKey = PluginReplacement.ReplacePlaceHolder(pluginContext, this.LocalizableLabelText);

                        if (!string.IsNullOrEmpty(textKey))
                        {
                            var textDefinition = await this.LanguageService.GetLocalizableTextDefinitionAsync(textKey);
                            await this.LocalizedLabelText.ConfigLocalizedTextAsync(textDefinition).LogPossibleExceptionAsync();
                        }
                        else
                        {
                            await this.LocalizedLabelText.ConfigLocalizedTextAsync(string.Empty, string.Empty);
                        }

                        this.LocalizedLabelText.Changed += (s, e) => this.OnLocalizedLabelTextChanged(e);

                        this.CoerceValue(ProcessControlBase.LabelTextProperty);
                    }
                }
            }
        }

        /// <summary>
        /// Called when the language has changed.
        /// Can be overridden in derived classes to handle language changes.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected virtual void OnLanguageChanged(LanguageChangedEventArgs e)
        {
        }

        /// <summary>
        /// Called when the localized label text has changed.
        /// Updates the <see cref="LabelText"/> property accordingly.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected virtual void OnLocalizedLabelTextChanged(LocalizedTextChangedEventArgs e)
        {
            // Check and update LabelText
            this.CoerceValue(ProcessControlBase.LabelTextProperty);
        }

        /// <summary>
        /// Called when the <see cref="LocalizableLabelText"/> property has changed.
        /// Updates the localized label text configuration.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected virtual async void OnLocalizableLabelTextChanged(DependencyPropertyChangedEventArgs e)
        {
            var localizedLabelText = this.LocalizedLabelText;

            await this.CheckLoadedAsync();

            if (ApplicationService.IsInDesignMode)
            {
                this.CoerceValue(ProcessControlBase.LabelTextProperty);
                return;
            }

            if (localizedLabelText != null)
            {
                var pluginContext = (string)this.GetValue(View.PluginContextProperty);
                var textKey = PluginReplacement.ReplacePlaceHolder(pluginContext, (string)e.NewValue);

                if (!string.IsNullOrEmpty(textKey))
                {
                    var textDefinition = await this.LanguageService.GetLocalizableTextDefinitionAsync(textKey);
                    await localizedLabelText.ConfigLocalizedTextAsync(textDefinition).LogPossibleExceptionAsync();
                }
                else
                {
                    await localizedLabelText.ConfigLocalizedTextAsync(string.Empty, string.Empty);
                }
            }

            this.CoerceValue(LabelTextProperty);
        }

        /// <summary>
        /// Coerces the value of the <see cref="LabelText"/> property.
        /// Can be overridden to provide custom coercion logic.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="baseValue">The base value.</param>
        /// <returns>The coerced value.</returns>
        private static object CoerceLabelTextProperty(DependencyObject d, object baseValue)
        {
            var instance = (ProcessControlBase)d;
            return instance.OnCoerceLabelText(baseValue);
        }

        /// <summary>
        /// Called when the <see cref="LocalizableLabelText"/> property has changed.
        /// Invokes the instance method to handle the change.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The event data.</param>
        private static void OnLocalizableLabelTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (ProcessControlBase)d;
            instance.OnLocalizableLabelTextChanged(e);
        }
    }
}
