using System.Collections.Concurrent;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using VisiWin.DataAccess;
using VisiWin.Plugin;

namespace VisiWin7.ProcessControls.WPF.Controls
{
    public partial class ProcessControlBase
    {
        /// <summary>
        /// Gets the variable service used to create and manage variables.
        /// </summary>
        protected IVariableService VariableService { get; private set; }

        /// <summary>
        /// Stores the variables mapped by their control property names.
        /// </summary>
        protected readonly ConcurrentDictionary<string, IVariable> Variables = new ConcurrentDictionary<string, IVariable>();

        /// <summary>
        /// Indicates whether the control is currently attaching variables.
        /// </summary>
        protected bool IsAttaching { get; private set; }

        /// <summary>
        /// Gets or sets the name of the struct variable to be used as a base for variable mapping.
        /// </summary>
        [Category("Process")]
        public string StructVariableName
        {
            get => (string)GetValue(StructVariableNameProperty);
            set => SetValue(StructVariableNameProperty, value);
        }

        /// <summary>
        /// Identifies the StructVariableName dependency property.
        /// </summary>
        public static readonly DependencyProperty StructVariableNameProperty =
            DependencyProperty.Register(nameof(StructVariableName), typeof(string), typeof(ProcessControlBase), new PropertyMetadata(default));

        /// <summary>
        /// Initializes the variable service and creates variables for each mapping.
        /// Sets up change event handlers for each variable.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        protected virtual async Task InitializeVariableServiceAsync()
        {
            if (this.VariableService == null)
            {
                this.VariableService = ApplicationService.GetService<IVariableService>();
            }

            if (this.Mapping == null || string.IsNullOrEmpty(this.StructVariableName))
            {
                return;
            }

            foreach (var mapping in this.Mapping)
            {
                var variable = await this.VariableService.CreateVariableAsync();
                var variableName = $"{this.StructVariableName}{{.{mapping.VariableName}}}";

                if (variable != null)
                {
                    var pluginContext = (string)this.GetValue(View.PluginContextProperty);
                    await variable.SetVariableNameAsync(PluginReplacement.ReplacePlaceHolder(pluginContext, variableName));
                    // TODO: Use weak event pattern to avoid memory leaks.
                    variable.Change += (o, e) => { this.OnVariableValueChanged(o, mapping.ControlPropertyName, e); };
                }

                this.Variables.TryAdd(mapping.ControlPropertyName, variable);
            }
        }

        /// <summary>
        /// Called when a variable's value changes.
        /// Can be overridden in derived classes to handle variable changes.
        /// </summary>
        /// <param name="sender">The variable that triggered the event.</param>
        /// <param name="controlPropertyName">The name of the control property mapped to the variable.</param>
        /// <param name="variableEventArgs">The event arguments containing variable change information.</param>
        protected virtual void OnVariableValueChanged(object sender, string controlPropertyName, VariableEventArgs variableEventArgs)
        {
        }

        /// <summary>
        /// Attaches all variables that are not currently attached.
        /// Sets the IsAttaching flag during the operation.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AttachVariablesAsync()
        {
            this.IsAttaching = true;
            try
            {
                if (this.Mapping == null || string.IsNullOrEmpty(this.StructVariableName))
                {
                    return;
                }

                foreach (var mapping in this.Mapping)
                {
                    var variable = this.Variables[mapping.ControlPropertyName];

                    if (variable != null && !variable.IsAttached)
                    {
                        await variable.AttachAsync();
                    }
                }
            }
            finally
            {
                this.IsAttaching = false;
            }
        }

        /// <summary>
        /// Detaches all variables that are currently attached.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DetachVariablesAsync()
        {
            if (this.Mapping == null || string.IsNullOrEmpty(this.StructVariableName))
            {
                return;
            }

            foreach (var mapping in this.Mapping)
            {
                var variable = this.Variables[mapping.ControlPropertyName];

                if (variable != null && variable.IsAttached)
                {
                    await variable.DetachAsync();
                }
            }
        }
    }
}