using System;
using System.Windows;
using Microsoft.VisualStudio.DesignTools.Extensibility.Metadata;
using Microsoft.VisualStudio.DesignTools.Extensibility.Model;
using VisiWin.WPF.View.VisualStudio.Design;
using VisiWin7.ProcessControls.WPF.Controls;

namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer.Base
{
    /// <summary>
    /// Provides a base initializer for process control components in the VisiWin7 WPF design environment.
    /// This class is responsible for setting up default property values for controls derived from <see cref="ProcessControlBase"/>.
    /// </summary>
    public class ProcessControlBaseInitializer : DefaultInitializer
    {
        /// <summary>
        /// Gets the name of the variable mapping resource to be used for the control.
        /// Can be overridden in derived classes to provide a different mapping name.
        /// </summary>
        public virtual string VariableMappingName => "DefaultMapping";

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessControlBaseInitializer"/> class.
        /// </summary>
        public ProcessControlBaseInitializer()
        {

        }

        /// <summary>
        /// Sets the default values for the specified <see cref="ModelItem"/>.
        /// This includes assigning default resources for state brushes and variable mapping.
        /// </summary>
        /// <param name="item">The model item representing the control to initialize.</param>
        public override void InitializeDefaults(ModelItem item)
        {
            base.InitializeDefaults(item);

            try
            {
                // Set the default resource for the StateBrushes property using a dynamic resource reference.
                item.Properties[nameof(ProcessControlBase.StateBrushes)]
                    .SetValue(new ResourceValue("ProcessControlStates", null, ResourceValue.DynamicResourceExtensionType));

                // Set the default resource for the Mapping property using the specified variable mapping name.
                item.Properties[nameof(ProcessControlBase.Mapping)]
                    .SetValue(new ResourceValue(this.VariableMappingName, null, ResourceValue.DynamicResourceExtensionType));
            }
            catch (Exception ex)
            {
                // Show the exception in a message box and write it to the console for debugging purposes.
                MessageBox.Show(ex.ToString());
                Console.WriteLine(ex.ToString());
            }
        }
    }

    public class ResourceValue
    {
        public const string DynamicResourceExtensionType = "System.Windows.DynamicResourceExtension";
        public const string StaticResourceExtensionType = "System.Windows.StaticResourceExtension";

        public string Key { get; set; }
        public object Value { get; set; }
        public string MarkupExtensionFullName { get; set; } //Dynamic oder StaticResource

        public ResourceValue(string key, object value, string markupExtensionFullName)
        {
            this.Key = key;
            this.Value = value;
            this.MarkupExtensionFullName = markupExtensionFullName;
        }

        public string ResourceString
        {
            get
            {
                if (this.MarkupExtensionFullName.Equals(ResourceValue.DynamicResourceExtensionType))
                {
                    return "{DynamicResource " + this.Key + "}";
                }
                else
                {
                    return "{StaticResource " + this.Key + "}";
                }
            }
        }
    }
}