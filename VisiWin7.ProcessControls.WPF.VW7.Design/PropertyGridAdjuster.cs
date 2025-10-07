// <copyright file="PropertyGridAdjuster.cs" company="INOSOFT GmbH">
//    Copyright (c) INOSOFT GmbH. All rights reserved.
// </copyright>

// #define DEBUGOUTPUT

namespace VisiWin7.ProcessControls.WPF.VW7.Design
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using System.Text;
    using System.Windows;
    using Microsoft.Windows.Design.Metadata;
    using VisiWin;
    using VisiWin.Controls.Design;
    using Microsoft.Windows.Design.PropertyEditing;

    /// <summary>
    /// This class sets the attributes for all dependency properties not listed in <see cref="GetControlDefinitionList"/> of all defined classes to <code>browsable=false</code>. Additionally the category for all listed dependency properties will be adjusted.
    /// </summary>
    /// <remarks>
    /// This class can neither deal with attached nor with common properties!
    /// </remarks>
    public static class PropertyGridAdjuster
    {

        /// <summary>
        /// Config all the properties which have to be removed from proertygrid
        /// 
        /// Returns the collection of all configured control classes.
        /// </summary>
        /// <returns>The collection of all configured control classes.</returns>
        private static ControlDefinitionCollection GetControlDefinitionList()
        {
            ControlDefinitionCollection cdc = new ControlDefinitionCollection();

            //Type type = typeof(ExtendedSwitch);

            //cdc.AddToWhiteList(type, "Background", "Brushes");
            //cdc.AddToWhiteList(type, "Foreground", "Brushes");
            //cdc.AddToWhiteList(type, "BlinkBrush", "Brushes");

            //cdc.AddToWhiteList(type, "Width", "Layout");
            //cdc.AddToWhiteList(type, "Height", "Layout");
            //cdc.AddToWhiteList(type, "HorizontalAlignment", "Layout");
            //cdc.AddToWhiteList(type, "VerticalAlignment", "Layout");
            //cdc.AddToWhiteList(type, "Margin", "Layout");

            //cdc.AddToWhiteList(type, "TextAlignment", "Common Properties");
            //cdc.AddToWhiteList(type, "IsEnabled", "Common Properties");
            //cdc.AddToWhiteList(type, "LabelText", "Common Properties");
            //cdc.AddToWhiteList(type, "LocalizableLabelText", "Common Properties");
            //cdc.AddToWhiteList(type, "UseVariableText", "Common Properties");
            //cdc.AddToWhiteList(type, "Visibility", "Common Properties");

            //cdc.AddToWhiteList(type, "AuthorizationMode", "Authorization");
            //cdc.AddToWhiteList(type, "AuthorizationRight", "Authorization");

            //cdc.AddToWhiteList(type, "BlinkCycle", "Blink");
            //cdc.AddToWhiteList(type, "BlinkMode", "Blink");
            //cdc.AddToWhiteList(type, "IsBlinkEnabled", "Blink");

            //cdc.AddToWhiteList(type, "Symbol", "Symbol");
            //cdc.AddToWhiteList(type, "HorizontalErrorNotificationAlignment", "Symbol");
            //cdc.AddToWhiteList(type, "SymbolMargin", "Symbol");
            //cdc.AddToWhiteList(type, "SymbolResourceKey", "Symbol");
            //cdc.AddToWhiteList(type, "VerticalErrorNotificationAlignment", "Symbol");

            //cdc.AddToWhiteList(type, "CanRecipeEdit", "Variable");
            //cdc.AddToWhiteList(type, "VariableName", "Variable");
            //cdc.AddToWhiteList(type, "VariableName2", "Variable");
            //cdc.AddToWhiteList(type, "Value2", "Variable");

            //cdc.AddToBlackList(type, "Resources");

            return cdc;
        }

        #region Private Fields

        /// <summary>
        /// The name of the topmost class whose dependency properties will be taken into account.
        /// </summary>
        private static readonly string BaseClassNameControlsTree = "System.Windows.DependencyObject";

        /// <summary>
        /// The name of the type this class cares about.
        /// </summary>
        private static readonly string DependencyPropertyTypeName = "DependencyProperty";

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// This method sets all not configured properties of all configured control classes to <code>browsable=false</code>. Additionally all configured properties will be assigned to the configured categories.
        /// </summary>
        /// <param name="builder">The <see cref="AttributeTableBuilder"/> instance to be used.</param>
        public static void SetPropertyAttributes(AttributeTableBuilder builder)
        {
#if DEBUGOUTPUT
            WriteLine("SetPropertyAttributes started.");
#endif
            ControlDefinitionCollection cdl = GetControlDefinitionList();

            foreach (ControlDefinition cd in cdl.Values)
            {
                SetBrowsableFalse(builder, cd);
                SetCategoryAndBrowsableTrue(builder, cd);
            }

#if DEBUGOUTPUT
            WriteLine("SetPropertyAttributes finished.");
#endif
        }

        #endregion
  
        #region Private Static Methods

        /// <summary>
        /// Adds the given string to the file <code>c:\temp\Designdll.log</code>.
        /// </summary>
        /// <param name="line">The string to be added.</param>
        private static void WriteLine(string line)
        {
#if DEBUGOUTPUT
            StreamWriter streamWriter = null;

            try
            {
                FileInfo fileInfo = new FileInfo(@"c:\temp\Designdll.log");
                Encoding utf8withoutBOM = new System.Text.UTF8Encoding(false);

                using (streamWriter = new StreamWriter(fileInfo.FullName, true, utf8withoutBOM))
                {
                    streamWriter.WriteLine(line);
                }

                streamWriter.Close();
            }
            catch (Exception)
            {
            }
#endif
        }

        /// <summary>
        /// Sets for all dependency properties, not included in the given control definition <code>browsable=false</code>.
        /// </summary>
        /// <param name="builder">The <see cref="AttributeTableBuilder"/> to be used.</param>
        /// <param name="cd">The control definition to be processed.</param>
        private static void SetBrowsableFalse(AttributeTableBuilder builder, ControlDefinition cd)
        {
#if DEBUGOUTPUT
            WriteLine("SetBrowsableAttribute started.");
#endif
            TypeCollection blackListDPs = GetDependencyPropertiesToBeHidden(cd);

#if DEBUGOUTPUT
            WriteLine("SetBrowsableAttribute now processing white list...");
#endif
            foreach (Type type in blackListDPs.Keys)
            {
                PropertyCollection dps = blackListDPs[type];

                foreach (DependencyProperty dp in dps.Values)
                {
                    if (cd.Type != null && !string.IsNullOrEmpty(dp.Name))
                    {
#if DEBUGOUTPUT
                        WriteLine(string.Format("builder.AddCustomAttributes(\"{0}\", \"{1}\", new BrowsableAttribute(false));", cd.Type, dp.Name));
#endif
                        builder.AddCustomAttributes(cd.Type, dp.Name, new BrowsableAttribute(false));
                    }
                }
            }

#if DEBUGOUTPUT
            WriteLine("SetBrowsableAttribute now processing black list...");
#endif
            if (cd.PropertyDefinitionsBlackList != null)
            {
                foreach (PropertyDefinition pd in cd.PropertyDefinitionsBlackList.Values)
                {
                    if (cd.Type != null && !string.IsNullOrEmpty(pd.Name))
                    {
#if DEBUGOUTPUT
                        WriteLine(string.Format("builder.AddCustomAttributes(\"{0}\", \"{1}\", new BrowsableAttribute(false));", cd.Type, pd.Name));
#endif
                        builder.AddCustomAttributes(cd.Type, pd.Name, new BrowsableAttribute(false));
                    }
                }
            }

#if DEBUGOUTPUT
            WriteLine("SetBrowsableAttribute finished.");
#endif
        }

        /// <summary>
        /// Sets for all dependency properties contained in the given control definition the configured category name.
        /// </summary>
        /// <param name="builder">The <see cref="AttributeTableBuilder"/> to be used.</param>
        /// <param name="cd">The control definition to be processed.</param>
        private static void SetCategoryAndBrowsableTrue(AttributeTableBuilder builder, ControlDefinition cd)
        {
#if DEBUGOUTPUT
            WriteLine("SetCategoryAttribute started.");
#endif
            foreach (PropertyDefinition pd in cd.PropertyDefinitionsWhiteList.Values)
            {
                if (cd.Type != null && !string.IsNullOrEmpty(pd.Name) && !string.IsNullOrEmpty(pd.Category))
                {
#if DEBUGOUTPUT
                    WriteLine(string.Format("builder.AddCustomAttributes(\"{0}\", \"{1}\", new BrowsableAttribute(true));", cd.Type, pd.Name));
                    WriteLine(string.Format("builder.AddCustomAttributes(\"{0}\", \"{1}\", new CategoryAttribute(\"{2}\"));", cd.Type, pd.Name, pd.Category));
#endif
                    builder.AddCustomAttributes(cd.Type, pd.Name, new BrowsableAttribute(true));
                    builder.AddCustomAttributes(cd.Type, pd.Name, new CategoryAttribute(pd.Category));

                    if (pd.HasVariableBrowser)
                    {
#if DEBUGOUTPUT
                        WriteLine(string.Format("builder.AddCustomAttributes(\"{0}\", \"{1}\", new EditorAttribute(typeof(VariableNameDialogPropertyEditor), typeof(DialogPropertyEditor)));", cd.Type, pd.Name));
#endif
                        builder.AddCustomAttributes(cd.Type, pd.Name, PropertyValueEditor.CreateEditorAttribute(typeof(VariableNameDialogPropertyEditor)));
                    }

                    if (pd.HasRightsBrowser)
                    {
#if DEBUGOUTPUT
                        WriteLine(string.Format("builder.AddCustomAttributes(\"{0}\", \"{1}\", new EditorAttribute(typeof(RightDialogPropertyEditor), typeof(DialogPropertyEditor)));", cd.Type, pd.Name));
#endif
                        builder.AddCustomAttributes(cd.Type, pd.Name, PropertyValueEditor.CreateEditorAttribute(typeof(RightDialogPropertyEditor)));

                    }
                }
            }

#if DEBUGOUTPUT
            WriteLine("SetCategoryAttribute finished.");
#endif
        }

        /// <summary>
        /// Returns a <see cref="TypeCollection"/> object containing all dependency properties not configured in the given control definition.
        /// </summary>
        /// <param name="controlDefinition">The control definition containing the while list of properties.</param>
        /// <returns>A <see cref="TypeCollection"/> object containing all dependency properties not configured in the given control definition.</returns>
        private static TypeCollection GetDependencyPropertiesToBeHidden(ControlDefinition controlDefinition)
        {
            TypeCollection ret = new TypeCollection();
            TypeCollection allDPs = GetDependencyProperties(controlDefinition.Type);

            if (allDPs != null)
            {
                foreach (Type type in allDPs.Keys)
                {
                    PropertyCollection dps = allDPs[type];
                    PropertyCollection currentType = new PropertyCollection();

                    foreach (DependencyProperty dp in dps.Values)
                    {
                        if (!controlDefinition.ContainsPropertyInWhiteList(dp.Name))
                        {
                            currentType.Add(dp.Name, dp);
                        }
                    }

                    ret.Add(type, currentType);
                }
            }

            return ret;
        }

        /// <summary>
        /// Returns a <see cref="TypeCollection"/> object containing all dependency properties for the given <see cref="Type"/> an all its base types up to the type named by <see cref="DependencyPropertyTypeName"/>.
        /// </summary>
        /// <param name="type">The type whose dependency properties should be returned.</param>
        /// <returns>A <see cref="TypeCollection"/> object containing all dependency properties for the given <see cref="Type"/> an all its base types up to the type named by <see cref="DependencyPropertyTypeName"/>.</returns>
        private static TypeCollection GetDependencyProperties(Type type)
        {
            TypeCollection ret = new TypeCollection();

            while (type != null)
            {
                PropertyCollection directDPs = GetDirectDependencyProperties(type);

                if (directDPs != null)
                {
                    ret.Add(type, directDPs);

                    type = type.BaseType;
                }
                else
                {
                    type = null;
                }
            }

            return ret;
        }

        /// <summary>
        /// Returns a <see cref="TypeCollection"/> object containing all dependency properties for the given <see cref="Type"/> as long as that type is a sub class of the type named by <see cref="DependencyPropertyTypeName"/>, or null.
        /// </summary>
        /// <param name="type">The type whose dependency properties should be returned.</param>
        /// <returns>A <see cref="TypeCollection"/> object containing all dependency properties for the given <see cref="Type"/> as long as that type is a sub class of the type named by <see cref="DependencyPropertyTypeName"/>, or null.</returns>
        private static PropertyCollection GetDirectDependencyProperties(Type type)
        {
            PropertyCollection ret = null;

            if (type != null)
            {
                if (IsInheritedFrom(type, BaseClassNameControlsTree))
                {
                    FieldInfo[] fieldInfoArray = type.GetFields();

                    ret = new PropertyCollection();

                    if (fieldInfoArray != null)
                    {
                        foreach (FieldInfo fieldInfo in fieldInfoArray)
                        {
                            if (fieldInfo.FieldType != null && fieldInfo.FieldType.Name.Equals(DependencyPropertyTypeName) && fieldInfo.IsPublic && fieldInfo.IsStatic && fieldInfo.IsInitOnly)
                            {
                                DependencyProperty dp = fieldInfo.GetValue(null) as DependencyProperty;

                                if (dp != null)
                                {
                                    ret.Add(dp.Name, dp);
                                }
                            }
                        }
                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// Returns true, IFF the given type is a sub class the the class named by fullNameBaseClass.
        /// </summary>
        /// <param name="type">The type to be checked.</param>
        /// <param name="fullNameBaseClass">The base class, the given type should inherit from.</param>
        /// <returns>True, IFF the given type is a sub class the the class named by fullNameBaseClass.</returns>
        private static bool IsInheritedFrom(Type type, string fullNameBaseClass)
        {
            bool ret = false;

            while (!ret && type != null)
            {
                if (type.FullName.Equals(fullNameBaseClass))
                {
                    ret = true;
                }
                else
                {
                    type = type.BaseType;
                }
            }

            return ret;
        }

        #endregion

        #endregion

        #region Sub-Classes

        /// <summary>
        /// This class implements a <see cref="Dictionary"/> whose key is a <see cref="Type"/> and whose value is a <see cref="PropertyCollection"/>.
        /// </summary>
        internal class TypeCollection : Dictionary<Type, PropertyCollection>
        {
        }

        /// <summary>
        /// This class implements a <see cref="Dictionary"/> whose key is a <see cref="string"/> and whose value is a <see cref="DependencyProperty"/>.
        /// </summary>
        internal class PropertyCollection : Dictionary<string, DependencyProperty>
        {
        }

        /// <summary>
        /// This class implements a <see cref="Dictionary"/> whose key is a <see cref="Type"/> and whose value is a <see cref="ControlDefinition"/>.
        /// </summary>
        internal class ControlDefinitionCollection : Dictionary<Type, ControlDefinition>
        {
            /// <summary>
            /// Adds the given <see cref="Type"/> to the <see cref="Dictionary"/> with an empty <see cref="PropertyCollection"/> as values to the collection.
            /// </summary>
            /// <param name="type">The type to be added.</param>
            public void Add(Type type)
            {
                ControlDefinition cd = this.GetNewOrExistingInstance(type);

                cd.AddEmptyPropertyCollectionWhiteList();
            }

            /// <summary>
            /// Adds the given <see cref="Type"/>, property name, category name combination to the collection.
            /// </summary>
            /// <param name="type">The type to be added.</param>
            /// <param name="propertyName">The property name to be added.</param>
            /// <param name="categoryName">The category name to be added.</param>
            /// <param name="hasVariableBrowser">true: it should be possible to open the variable browser dialog for this property.</param>
            /// <param name="hasRightsBrowser">true: it should be possible to open the rights browser dialog for this property.</param>
            public void AddToWhiteList(Type type, string propertyName, string categoryName, bool hasVariableBrowser = false, bool hasRightsBrowser = false, bool hasSymbolBrowser = false)
            {
                ControlDefinition cd = this.GetNewOrExistingInstance(type);

                if (cd != null)
                {
                    cd.AddOrUpdatePropertyWhiteList(propertyName, categoryName, hasVariableBrowser, hasRightsBrowser, hasSymbolBrowser);
                }
            }

            /// <summary>
            /// Adds the given <see cref="Type"/>, property name, category name combination to the collection.
            /// </summary>
            /// <param name="type">The type to be added.</param>
            /// <param name="propertyName">The property name to be added.</param>
            public void AddToBlackList(Type type, string propertyName)
            {
                ControlDefinition cd = this.GetNewOrExistingInstance(type);

                if (cd != null)
                {
                    cd.AddOrUpdatePropertyBlackList(propertyName);
                }
            }

            /// <summary>
            /// Returns the <see cref="ControlDefinition"/> representing the given <see cref="Type"/>
            /// </summary>
            /// <param name="type">The <see cref="Type"/> whose <see cref="ControlDefinition"/> is searched.</param>
            /// <returns>The <see cref="ControlDefinition"/> representing the given <see cref="Type"/></returns>
            private ControlDefinition GetNewOrExistingInstance(Type type)
            {
                ControlDefinition ret = null;

                if (this.ContainsKey(type))
                {
                    ret = this[type];
                }
                else
                {
                    ret = new ControlDefinition(type);

                    this.Add(ret.Type, ret);
                }

                return ret;
            }
        }

        /// <summary>
        /// This class implements a <see cref="Dictionary"/> whose key is a <see cref="string"/> and whose value is a <see cref="PropertyDefinition"/>.
        /// </summary>
        internal class PropertyDefinitionCollection : Dictionary<string, PropertyDefinition>
        {
            /// <summary>
            /// Adds a new or updates the existing <see cref="PropertyDefinition"/> object using the given values.
            /// </summary>
            /// <param name="propertyName">The property name to be added or updated.</param>
            /// <param name="categoryName">The category name to be added or updated.</param>
            /// <param name="hasVariableBrowser">true: it should be possible to open the variable browser dialog for this property.</param>
            /// <param name="hasRightsBrowser">true: it should be possible to open the rights browser dialog for this property.</param>
            public void AddOrUpdateProperty(string propertyName, string categoryName, bool hasVariableBrowser = false, bool hasRightsBrowser = false, bool hasSymbolBrowser = false)
            {
                PropertyDefinition pd = null;

                if (!this.ContainsProperty(propertyName))
                {
                    pd = new PropertyDefinition();
                    pd.Name = propertyName;

                    this.Add(propertyName, pd);
                }
                else
                {
                    pd = this.GetPropertyDefinition(propertyName);
                }

                pd.Category = categoryName;
                pd.HasVariableBrowser = hasVariableBrowser;
                pd.HasRightsBrowser = hasRightsBrowser;
                pd.HasSymbolBrowser = hasSymbolBrowser;
            }

            /// <summary>
            /// Adds a new or updates the existing <see cref="PropertyDefinition"/> object using the given values.
            /// </summary>
            /// <param name="propertyName">The property name to be added or updated.</param>
            /// <remarks>
            /// Here the field PropertyDefinition.Category is set to null.
            /// </remarks>
            public void AddOrUpdateProperty(string propertyName)
            {
                PropertyDefinition pd = null;

                if (!this.ContainsProperty(propertyName))
                {
                    pd = new PropertyDefinition();
                    pd.Name = propertyName;

                    this.Add(propertyName, pd);
                }
                else
                {
                    pd = this.GetPropertyDefinition(propertyName);
                }

                pd.Category = null;
                pd.HasVariableBrowser = false;
            }

            /// <summary>
            /// Returns the <see cref="PropertyDefinition"/> representing the given property name.
            /// </summary>
            /// <param name="propertyName">The property name whose <see cref="PropertyDefinition"/> is searched.</param>
            /// <returns>The <see cref="PropertyDefinition"/> representing the given property name.</returns>
            public PropertyDefinition GetPropertyDefinition(string propertyName)
            {
                return this.ContainsKey(propertyName) ? this[propertyName] : null;
            }

            /// <summary>
            /// Returns true, IFF the <see cref="PropertyDefinition"/> object representing the given property name is present.
            /// </summary>
            /// <param name="propertyName">The name of the dependency property whose existence will be checked.</param>
            /// <returns>True, IFF the <see cref="PropertyDefinition"/> object representing the given property name is present.</returns>
            public bool ContainsProperty(string propertyName)
            {
                return this.GetPropertyDefinition(propertyName) != null;
            }
        }

        /// <summary>
        /// This class implements a value object representing a control type having a collection of dependency properties to be visible in <code>VisiWin's</code> designer. (While List)
        /// </summary>
        internal class ControlDefinition
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ControlDefinition"/> class.
            /// </summary>
            /// <param name="typePar">The <see cref="Type"/> for this instance.</param>
            public ControlDefinition(Type typePar)
            {
                this.Type = typePar;
            }

            /// <summary>
            /// Gets this instance's type.
            /// </summary>
            public Type Type { get; private set; }

            /// <summary>
            /// Gets this instance's collection of property definitions. (White list)
            /// </summary>
            public PropertyDefinitionCollection PropertyDefinitionsWhiteList { get; private set; }

            /// <summary>
            /// Gets this instance's collection of property definitions. (Black list)
            /// </summary>
            public PropertyDefinitionCollection PropertyDefinitionsBlackList { get; private set; }

            /// <summary>
            /// Adds or updates a property- and category-name combination.
            /// </summary>
            /// <param name="propertyName">The property's name.</param>
            /// <param name="categoryName">The category's name.</param>
            /// <param name="hasVariableBrowser">true: it should be possible to open the variable browser dialog for this property.</param>
            /// <param name="hasRightsBrowser">true: it should be possible to open the rights browser dialog for this property.</param>
            public void AddOrUpdatePropertyWhiteList(string propertyName, string categoryName, bool hasVariableBrowser = false, bool hasRightsBrowser = false, bool hasSymbolBrowser = false)
            {
                this.AddEmptyPropertyCollectionWhiteList();

                this.PropertyDefinitionsWhiteList.AddOrUpdateProperty(propertyName, categoryName, hasVariableBrowser, hasRightsBrowser, hasSymbolBrowser);
            }

            /// <summary>
            /// Adds an empty property collection.
            /// </summary>
            public void AddEmptyPropertyCollectionWhiteList()
            {
                if (this.PropertyDefinitionsWhiteList == null)
                {
                    this.PropertyDefinitionsWhiteList = new PropertyDefinitionCollection();
                }
            }

            /// <summary>
            /// Returns true, IFF the property collection contains an object having the given name.
            /// </summary>
            /// <param name="propertyName">The name to be checked.</param>
            /// <returns>True, IFF the property collection contains an object having the given name.</returns>
            public bool ContainsPropertyInWhiteList(string propertyName)
            {
                return this.PropertyDefinitionsWhiteList != null && this.PropertyDefinitionsWhiteList.GetPropertyDefinition(propertyName) != null;
            }

            /// <summary>
            /// Adds or updates a property-name.
            /// </summary>
            /// <param name="propertyName">The property's name.</param>
            public void AddOrUpdatePropertyBlackList(string propertyName)
            {
                this.AddEmptyPropertyCollectionBlackList();

                this.PropertyDefinitionsBlackList.AddOrUpdateProperty(propertyName);
            }

            /// <summary>
            /// Adds an empty property collection.
            /// </summary>
            public void AddEmptyPropertyCollectionBlackList()
            {
                if (this.PropertyDefinitionsBlackList == null)
                {
                    this.PropertyDefinitionsBlackList = new PropertyDefinitionCollection();
                }
            }

            /// <summary>
            /// Returns true, IFF the property collection contains an object having the given name.
            /// </summary>
            /// <param name="propertyName">The name to be checked.</param>
            /// <returns>True, IFF the property collection contains an object having the given name.</returns>
            public bool ContainsPropertyInBlackList(string propertyName)
            {
                return this.PropertyDefinitionsBlackList != null && this.PropertyDefinitionsBlackList.GetPropertyDefinition(propertyName) != null;
            }
        }

        /// <summary>
        /// This class implements a value object representing a property, consisting of a name and a category.
        /// </summary>
        internal class PropertyDefinition
        {
            /// <summary>
            /// Gets or sets the property's name.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the category the property shall be a member of.
            /// </summary>
            public string Category { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether it should be possible to open the variable browser dialog for this property.
            /// </summary>
            public bool HasVariableBrowser { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether it should be possible to open the rights browser dialog for this property.
            /// </summary>
            public bool HasRightsBrowser { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether it should be possible to open the symbol browser dialog for this property.
            /// </summary>
            public bool HasSymbolBrowser { get; set; }
        }

        #endregion
    }
}
