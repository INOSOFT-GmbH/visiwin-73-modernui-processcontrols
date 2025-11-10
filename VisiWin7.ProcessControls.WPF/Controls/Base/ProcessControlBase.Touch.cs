using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisiWin.ApplicationFramework;
using VisiWin.ApplicationFramework.Dialogs;
using VisiWin.Async;
using VisiWin.Collections;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    /// <summary>
    /// Partial class for ProcessControlBase that handles touch and mouse interactions to display a dialog for editing process control properties.
    /// </summary>
    public partial class ProcessControlBase
    {
        private string dialogViewName = "ProcessControlDialogView";
        private bool canShowDialog = true;
        private ObservableDictionary<string, DialogProperty> dialogProperties = new ObservableDictionary<string, DialogProperty>();

        /// <summary>
        /// Gets the collection of dialog properties associated with the current instance.
        /// </summary>
        /// <remarks>The collection allows dynamic storage and retrieval of dialog-specific properties by
        /// name. Changes to the collection are observable, enabling UI or logic to react to property updates.</remarks>
        public ObservableDictionary<string, DialogProperty> DialogProperties
        {
            get => this.dialogProperties;
            set => this.SetField(ref this.dialogProperties, value);
        }

        /// <summary>
        /// Gets or sets the name of the dialog view to be used when displaying the process control dialog.
        /// </summary>
        public string DialogViewName
        {
            get => this.dialogViewName;
            set => this.SetField(ref this.dialogViewName, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the dialog can be shown in response to user interactions.
        /// </summary>
        public bool CanShowDialog
        {
            get => this.canShowDialog;
            set => this.SetField(ref this.canShowDialog, value);
        }

        /// <inheritdoc />
        protected override void OnTouchDown(TouchEventArgs e)
        {
            base.OnTouchDown(e);
        }

        /// <inheritdoc />
        protected override async void OnTouchUp(TouchEventArgs e)
        {
            base.OnTouchUp(e);

            var tp = e.GetTouchPoint(this);
            var bounds = new Rect(new Point(0, 0), this.RenderSize);
            if (bounds.Contains(tp.Position))
            {
                await this.ShowDialogAsync().LogPossibleExceptionAsync();
            }
        }

        /// <inheritdoc />
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            var stylusDevice = e.StylusDevice;
            if (stylusDevice != null && stylusDevice.TabletDevice != null && stylusDevice.TabletDevice.Type == TabletDeviceType.Touch)
            {
                e.Handled = true;
                return;
            }

            base.OnMouseLeftButtonDown(e);
        }

        /// <inheritdoc />
        protected override async void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            var stylusDevice = e.StylusDevice;
            if (stylusDevice != null && stylusDevice.TabletDevice != null && stylusDevice.TabletDevice.Type == TabletDeviceType.Touch)
            {
                e.Handled = true;
                return;
            }

            base.OnMouseLeftButtonUp(e);
            await this.ShowDialogAsync().LogPossibleExceptionAsync();
        }

        /// <summary>
        /// Displays a dialog asynchronously, allowing the user to edit dialog properties mapped to the current object,
        /// and updates the corresponding variables based on user input.
        /// </summary>
        /// <remarks>This method clears the current dialog properties, maps eligible properties to dialog
        /// fields, and updates variable values after the dialog is completed. Override this method to customize dialog
        /// behavior or property mapping in derived classes.</remarks>
        /// <returns>A task that represents the asynchronous operation of displaying the dialog and updating the variables.</returns>
        protected virtual async Task ShowDialogAsync()
        {
            if (!this.CanShowDialog)
            {
                return;
            }

            this.DialogProperties = new ObservableDictionary<string, DialogProperty>();

            foreach (var mappingEntry in this.Mapping)
            {
                if (!mappingEntry.IsDialogProperty)
                {
                    continue;
                }

                var propertyInfo = this.GetType().GetProperty(mappingEntry.ControlPropertyName);

                if (propertyInfo == null)
                {
                    continue;
                }

                switch (propertyInfo.PropertyType)
                {
                    case Type boolType when boolType == typeof(bool):
                        var boolVariableName = $"{this.StructVariableName}{{.{mappingEntry.VariableName}}}";
                        this.DialogProperties.Add(mappingEntry.ControlPropertyName,
                            new BoolDialogProperty
                                {
                                    PropertyName = mappingEntry.ControlPropertyName, PropertyValue = (bool)propertyInfo.GetValue(this), VariableName = boolVariableName,
                                    LocalizableLabelText = (await this.VariableService.GetVariableDefinitionAsync(boolVariableName)).LocalizableText
                            });
                        break;

                    case Type stringType when stringType == typeof(string):
                        var stringVariableName = $"{this.StructVariableName}{{.{mappingEntry.VariableName}}}";
                        this.DialogProperties.Add(mappingEntry.ControlPropertyName,
                            new StringDialogProperty
                                {
                                    PropertyName = mappingEntry.ControlPropertyName, PropertyValue = (string)propertyInfo.GetValue(this), VariableName = stringVariableName,
                                    LocalizableLabelText = (await this.VariableService.GetVariableDefinitionAsync(stringVariableName)).LocalizableText
                                });
                        break;

                    case Type intType when intType == typeof(int):
                        var intVariableName = $"{this.StructVariableName}{{.{mappingEntry.VariableName}}}";
                        this.DialogProperties.Add(mappingEntry.ControlPropertyName,
                            new IntDialogProperty
                                {
                                    PropertyName = mappingEntry.ControlPropertyName, PropertyValue = (int)propertyInfo.GetValue(this), VariableName = intVariableName,
                                    LocalizableLabelText = (await this.VariableService.GetVariableDefinitionAsync(intVariableName)).LocalizableText
                            });
                        break;
                }
            }

            var result = await ApplicationService.ShowDialogAsync(this.DialogViewName, this.LabelText, this.DialogProperties, (dialogResult, properties) => (dialogResult, properties));
            if (result.dialogResult != DialogResult.OK)
            {
                return;
            }

            foreach (KeyValuePair<string, DialogProperty> mappingEntry in result.properties)
            {
                switch (mappingEntry.Value)
                {
                    case BoolDialogProperty boolProperty:
                        {
                            await this.VariableService.SetValueAsync(boolProperty.VariableName, boolProperty.PropertyValue);
                        }
                        break;

                    case StringDialogProperty stringProperty:
                        {
                            await this.VariableService.SetValueAsync(stringProperty.VariableName, stringProperty.PropertyValue);
                        }
                        break;

                    case IntDialogProperty intProperty:
                        {
                            await this.VariableService.SetValueAsync(intProperty.VariableName, intProperty.PropertyValue);
                        }
                        break;
                }
            }
        }
    }
}