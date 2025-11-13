<!-- Readme for VisiWin7 Process Controls Development Project -->
# VisiWin7.ProcessControls.Development.WPF

This is the **example/development project** demonstrating how to create and extend process controls for the VisiWin7 IDE using ModernUI (WPF) technology. It provides a comprehensive set of reusable industrial process control components that can be easily integrated into VisiWin7 Runtime 7.3 projects.

The project serves as both a sample implementation and a foundation for developing custom process controls such as tanks, valves, pumps, conveyors, and other industrial automation components. Useful for UI developers and automation engineers working with the VisiWin7 IDE who need to create custom visual representations of industrial processes.

## Related packages

- VisiWin7 Runtime 7.3
- VisiWin7 IDE
- .NET Framework 4.8
- WPF (Windows Presentation Foundation)

## Prerequisites

- **VisiWin7 IDE** - Install VisiWin7 IDE to get the required dependencies in place
- **Visual Studio 2019/2022** - For development and compilation
- **.NET Framework 4.8** - Target framework for all projects
- **VisiWin7 Runtime 7.3** - Required for testing and deployment

If VisiWin7 is installed in another path than `C:\Program Files (x86)\INOSOFT GmbH\VisiWin 7\Development\bin`, you need to specify the path in the project files.

This sample works with and was tested with VisiWin 7 2025-1 and later.

## Solution Structure

This repository contains six main projects that work together to provide a complete process controls framework:

### [VisiWin7.ProcessControls.WPF](VisiWin7.ProcessControls.WPF/)

The **core logic project** containing all process control classes and business logic.

- **Purpose**: Contains class definitions and implementations for all process controls
- **Key Components**:
  - `ProcessControlBase` – Root base class (state brushes, mapping, orientation, async init)
  - `DefaultErrorProcessControlBase` – Adds `Errors` mapping support
  - `DefaultProcessControlBase` – Adds `ActualValue`, `SetValue` and exposes `CurrentStateBrush` selected from `StateBrushes`
  - Category base classes (`ConveyorBase`, `ValveBase`, `PumpBase`, `PipeBase`, `ExchangerBase`, `EngineBase`)
  - Concrete implementations (e.g., `BeltConveyor`, `Tank`, `ThreeWayValve`, `Centrifugal`)
  - Custom properties with dependency property support
  - Process-specific logic and behaviors

**Main Types**:
- `ProcessControlBase` – Root base with mapping (`StructVariableName` + `Mapping`), state system, orientation
- `DefaultErrorProcessControlBase` – Error value (`Errors`) handling
- `DefaultProcessControlBase` – Standard process values and visual state selection (`ActualValue`, `SetValue`, `CurrentStateBrush`)
- Category-specific base classes for common control types

### [VisiWin7.ProcessControls.Styles.WPF](VisiWin7.ProcessControls.Styles.WPF/)

The **styling and visual representation project** containing all XAML styles and symbols.

- **Purpose**: Defines the visual appearance and symbols for process controls
- **Key Components**:
  - ResourceDictionaries with control styles
  - Path-based symbol definitions using WPF Path Markup syntax
  - Visual templates and indicators bound to `StateBrushes` / `CurrentStateBrush`
  - Styling configurations for different control states

**Architecture**:
- Symbols defined as `<Style>` elements with data templates
- Path-based graphics using coordinates and geometric shapes
- Binding support for dynamic properties (stroke, fill, thickness)
- Support for special cases like tank fill level visualization

### [VisiWin7.ProcessControls.Development.WPF](VisiWin7.ProcessControls.Development.WPF/)

The **example/development project** demonstrating usage patterns.

- **Purpose**: Shows how to use process controls in a VisiWin7 ModernUI project
- **Configuration**: Single-project setup with VisiWin7 Runtime 7.3 and ModernUI (WPF)
- **Features**:
  - Example implementations of various process controls
  - Configuration examples for `AssetConfiguration.xaml`
  - Sample XAML usage patterns
  - Integration examples with VisiWin7 IDE toolbox

### [VisiWin7.ProcessControls.WPF.VW7.Design](VisiWin7.ProcessControls.WPF.VW7.Design/)

The **VisiWin7 IDE design-time support project** for enhanced development experience.

- **Purpose**: Provides metadata and design-time experience specifically for the VisiWin7 IDE
- **Key Components**:
- Property grid editors and selection editors (e.g., variable and rights pickers)
  - Design-time metadata for improved IDE experience
  - Custom property editors for process-specific properties
  - Integration with VisiWin7 development environment
  - Variable name dialog property editor
  - Text dialog property editor for localizable content

**Note**: This project uses VisiWin7-specific design-time APIs and is only active when working within the VisiWin7 IDE.

### [VisiWin7.ProcessControls.WPF.DesignTools](VisiWin7.ProcessControls.WPF.DesignTools/)

The **Microsoft Blend/Visual Studio design-time support project** for enhanced XAML designer experience.

- **Purpose**: Provides design-time metadata and initializers for Microsoft Blend and Visual Studio XAML designer
- **Key Components**:
  - Control initializers that set default values when controls are dropped onto the designer surface
  - Design-time metadata using Microsoft.VisualStudio.DesignTools.Extensibility
  - Custom attributes for property grid customization
  - Feature providers for enhanced designer interaction
  - Default size, stroke thickness, and orientation settings for each control type

**Architecture**:
- Implements `IProvideAttributeTable` for metadata registration
- Provides `FeatureProvider` implementations for each control type
- Initializers inherit from `ProcessControlBaseInitializer` base class
- Automatically registers with designers through `[ProvideMetadata]` assembly attribute

### [VisiWin7.ProcessControls.WPF.VisualStudio.Design](VisiWin7.ProcessControls.WPF.VisualStudio.Design/)

The **Visual Studio-specific design-time support project** for property grid and XAML designer integration.

- **Purpose**: Provides Visual Studio-specific design-time experience and property grid customization
- **Key Components**:
  - `PropertyGridAdjuster` for filtering and organizing properties in the Visual Studio property grid
  - Control initializers for Visual Studio designer
  - Design-time metadata using Microsoft.Windows.Design namespaces
  - Integration with Visual Studio XAML IntelliSense and property editors
  - Variable name and localizable text property editors

**Architecture**:
- Implements `IProvideAttributeTable` for Visual Studio metadata registration
- Uses Microsoft.Windows.Design APIs (different from Blend DesignTools)
- Provides property value editors for special property types
- Initializers set appropriate defaults when controls are added to the designer

**Design-Time Projects Comparison**:

| Feature | VW7.Design | DesignTools | VisualStudio.Design |
|---------|-----------|-------------|---------------------|
| Target Environment | VisiWin7 IDE | Microsoft Blend / VS Designer | Visual Studio XAML Designer |
| API Namespace | VisiWin.Controls.Design | Microsoft.VisualStudio.DesignTools | Microsoft.Windows.Design |
| Primary Purpose | VisiWin7 IDE integration | Blend designer experience | VS property grid & IntelliSense |
| Variable Pickers | VisiWin7-specific | Generic string editors | VS-compatible editors |
| Control Initializers | VisiWin7 defaults | Blend designer defaults | VS designer defaults |

## Getting started

### Basic Usage in VisiWin7 IDE

1. **Build the solution** to generate the process control assemblies
2. **Add process controls to your VisiWin7 project** by configuring the `AssetConfiguration.xaml`:

```xml
<dt:ControlAssetInfo Category="Conveyor" 
        Description="BeltConveyor" 
         Type="VisiWin7.ProcessControls.WPF.Controls.BeltConveyor" 
                ImageLarge="BeltConveyor.png" 
            ImageSmall="BeltConveyorSmall.png" 
   Assembly="VisiWin7.ProcessControls.WPF"/>
```

3. **Use controls in XAML with variable mapping (relative to a struct variable)**:

```xml
<controls:BeltConveyor x:Name="Conveyor1"
StrokeThickness="2"
       Foreground="Blue"
           Background="LightGray"
      StructVariableName="PLC.Conveyor1"> <!-- base path -->
    <controls:BeltConveyor.Mapping>
  <mapping:VariableNameMappingCollection>
            <!-- VariableName is relative to StructVariableName -->
            <mapping:VariableNameControlPropertyMapping 
 VariableName="ActualValue" 
        ControlPropertyName="ActualValue"/>
     <mapping:VariableNameControlPropertyMapping 
                VariableName="SetValue" 
    ControlPropertyName="SetValue"/>
        </mapping:VariableNameMappingCollection>
    </controls:BeltConveyor.Mapping>
</controls:BeltConveyor>
```

**Notes:**
- Set the control's `StructVariableName` to the base variable (e.g., a PLC structure). Each mapping's `VariableName` is the relative member name.
- Design-time pickers are provided for `StructVariableName` in the IDE.

### Creating Custom Process Controls

1. **Inherit from base classes (pick the closest category)**:

```csharp
public class CustomValve : ValveBase { }
public class CustomConveyor : ConveyorBase { }
public class CustomPump : PumpBase { }
public class CustomPipe : PipeBase { }
public class CustomExchanger : ExchangerBase { }
public class CustomEngine : EngineBase { }

// Or, if you create a completely new category, derive from DefaultProcessControlBase
public abstract class CustomBase : DefaultProcessControlBase
{
static CustomBase()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomBase),
            new FrameworkPropertyMetadata(typeof(CustomBase)));
    }
}
```

2. **Add custom properties** with proper attributes:

```csharp
[Category("Process")]
public double FillLevel
{
    get { return (double)GetValue(FillLevelProperty); }
    set { SetValue(FillLevelProperty, value); }
}

public static readonly DependencyProperty FillLevelProperty =
    DependencyProperty.Register("FillLevel", typeof(double),
    typeof(CustomTank), new PropertyMetadata(0.0));
```

3. **Implement Custom Variable Mapping Logic (Required for New Properties)**:

The `DefaultProcessControlBase` only automatically handles variable updates for `ActualValue` and `SetValue`. If you introduce any other custom dependency property and map a PLC variable to it (e.g., `FillLevel` or `IsTipped`), you **MUST** override `OnVariableValueChanged` to manually process the variable's value and assign it to the corresponding control property.

```csharp
protected override void OnVariableValueChanged(object sender, string controlPropertyName, VariableEventArgs variableEventArgs)
{
    // 1. Always call the base implementation first! 
    //    This ensures that ActualValue and SetValue (and Error in DefaultErrorProcessControlBase) 
    //are handled correctly by the base class logic.
    base.OnVariableValueChanged(sender, controlPropertyName, variableEventArgs);
    
    if (this.IsAttaching)
    {
        return;
    }

    // If the base class handled the property (e.g., ActualValue/SetValue), we stop here 
    // to avoid redundant processing, UNLESS we need side effects.
    
    var variableValue = this.Variables[controlPropertyName].Value;
    // Note: In the base implementation, value is converted to int. 
    // Here we must handle the specific type needed for our custom properties.
  
    // Example: Handling custom properties that are mapped and need processing.
    switch (controlPropertyName)
    {
        case nameof(this.FillLevel): // Example for mapping "FillLevel" from the PLC
          var fillLevelValue = System.Convert.ChangeType(variableValue, typeof(double));
     if (fillLevelValue is double doubleValue)
      {
   this.SetCurrentValue(FillLevelProperty, doubleValue);
        }
    break;
   
        case nameof(this.IsTipped): // Example for a custom boolean property
       var tippedValue = System.Convert.ChangeType(variableValue, typeof(bool));
if (tippedValue is bool boolValue)
   {
          this.SetCurrentValue(IsTippedProperty, boolValue);
 }
            break;
    }
}
```

**Key Takeaway for Custom Properties:** When you define a new Dependency Property (e.g., `FillLevel`, `IsTipped`) and configure a variable mapping for it, the `OnVariableValueChanged` override is **MANDATORY** to read the variable value and set the property.

4. **Create Visual Symbol**: Design the XAML symbol in the styles project

Every process control needs a visual style that defines its appearance. Create a style file:

**Basic Style Structure:**

```xml
<!--HeatExchanger-Style with multiple paths-->
    <Style TargetType="pc:CustomHeatExchanger" BasedOn="{StaticResource {x:Type pc:DefaultProcessControlBase}}">
        <Style.Resources>
            <DataTemplate x:Key="StyleTemplate">
           <Viewbox>
                    <Grid>
          <!--Main Circle-->
<Path StrokeThickness="{Binding StrokeThickness, RelativeSource={RelativeSource AncestorType={x:Type pc:DefaultProcessControlBase}}}" Stroke="{Binding Foreground, RelativeSource={RelativeSource AncestorType={x:Type pc:DefaultProcessControlBase}}}" Fill="{Binding Background, RelativeSource={RelativeSource AncestorType={x:Type pc:DefaultProcessControlBase}}}" Stretch="Uniform">
      <Path.Data>
   <EllipseGeometry Center="50,50" RadiusX="50" RadiusY="50"/>
       </Path.Data>
          </Path>
         <!--Internal Flow Lines-->
  <Path StrokeThickness="{Binding StrokeThickness, RelativeSource={RelativeSource AncestorType={x:Type pc:DefaultProcessControlBase}}}" Stroke="{Binding Foreground, RelativeSource={RelativeSource AncestorType={x:Type pc:DefaultProcessControlBase}}}" Stretch="Uniform">
          <Path.Data>
  <PathGeometry Figures="m 0,50 l 10,0 l 20,-25 l 40,50 l 20,-25 l 10,0"/>
          </Path.Data>
      </Path>
    </Grid>
      </Viewbox>
         </DataTemplate>
        </Style.Resources>
    </Style>
```

5. **Add Design-Time Support** (Optional but Recommended):

For the best development experience, add design-time support in the appropriate design projects:

**a) VisiWin7.ProcessControls.WPF.DesignTools** (for Blend/VS Designer):

Create an initializer:
```csharp
namespace VisiWin7.ProcessControls.WPF.VW7.Design.Initializer
{
    public class CustomControlInitializer : ProcessControlBaseInitializer
    {
        public override void InitializeDefaults(ModelItem item)
{
   base.InitializeDefaults(item);
    // Set default values
       item.Properties["Width"].SetValue(100.0);
   item.Properties["Height"].SetValue(100.0);
 }
    }
}
```

Register in `Metadata.cs`:
```csharp
this.SetCustomAttributes(builder, "VisiWin7.ProcessControls.WPF.Controls.CustomControl");
builder.AddCallback("VisiWin7.ProcessControls.WPF.Controls.CustomControl", 
    blder => blder.AddCustomAttributes(new FeatureAttribute(typeof(CustomControlInitializer))));
```

**b) VisiWin7.ProcessControls.WPF.VisualStudio.Design** (for VS Property Grid):

Create an initializer and register similarly:
```csharp
namespace VisiWin7.ProcessControls.WPF.VisualStudio.Design.Initializer
{
    public class CustomControlInitializer : ProcessControlBaseInitializer
    {
        // Similar to DesignTools but uses Microsoft.Windows.Design APIs
    }
}
```

**c) VisiWin7.ProcessControls.WPF.VW7.Design** (for VisiWin7 IDE):

Add VisiWin7-specific property editors and variable picker support.

6. **Register in IDE**: Add configuration to make it available in toolbox
7. **Test Integration**: Verify functionality in VisiWin7 IDE and runtime

## Process Control Development Guide

### Variable Mapping System

The process controls framework provides a variable mapping system that connects control properties to PLC variables. This enables real-time data exchange between the HMI and automation systems.

#### Understanding StructVariableName and VariableNameMappingCollection

- `StructVariableName` defines the base PLC variable (e.g., a structure or prefix).
- Each entry in `Mapping` specifies the relative member name (`VariableName`) and the target control property (`ControlPropertyName`).
- At runtime, variables are created by combining `StructVariableName` and the relative `VariableName`.

```csharp
[Category("Process")]
public VariableNameMappingCollection Mapping
{
    get => (VariableNameMappingCollection)this.GetValue(MappingProperty);
    set => this.SetValue(MappingProperty, value);
}
```

#### Basic Variable Mapping Configuration

**In XAML:**
```xml
<controls:Tank x:Name="Tank1"
        StructVariableName="PLC.Tank1">
    <controls:Tank.Mapping>
        <mapping:VariableNameMappingCollection>
    <!-- Map PLC struct member to control property -->
<mapping:VariableNameControlPropertyMapping 
    VariableName="ActualValue" 
       ControlPropertyName="ActualValue"/>
    <mapping:VariableNameControlPropertyMapping 
     VariableName="SetValue" 
     ControlPropertyName="SetValue"/>
  <mapping:VariableNameControlPropertyMapping 
            VariableName="Errors" 
      ControlPropertyName="Errors"/>
        </mapping:VariableNameMappingCollection>
    </controls:Tank.Mapping>
</controls:Tank>
```

**In Code-Behind:**
```csharp
// Create mapping collection
var mappingCollection = new VariableNameMappingCollection();

// Add individual mappings (relative names)
mappingCollection.Add(new VariableNameControlPropertyMapping
{
    VariableName = "ActualValue",
 ControlPropertyName = "ActualValue"
});

mappingCollection.Add(new VariableNameControlPropertyMapping
{
    VariableName = "SetValue",
    ControlPropertyName = "SetValue"
});

// Assign to control
Tank1.StructVariableName = "PLC.Tank1";
Tank1.Mapping = mappingCollection;
```

### Visual State System

- Bind `StateBrushes` on a control to define color/animation per state value.
- `DefaultProcessControlBase` selects the matching state as `CurrentStateBrush` when `ActualValue` changes.
- Styles can bind fills/strokes to the `CurrentStateBrush` to reflect the current state visually.

## Process Control Dialog Functionality

All process controls in this framework support built-in dialog functionality that allows operators to interact with process values at runtime. When a user clicks or taps on a process control, a dialog can be displayed to view and edit mapped properties.

### Dialog Architecture Overview

The dialog system consists of the following components:

1. **Touch/Mouse Interaction**: Built into `ProcessControlBase` to respond to user clicks
2. **Dialog Properties**: Type-safe property wrappers for dialog display and editing
3. **Dialog View**: XAML view that displays the properties in the client application
4. **Variable Mapping Integration**: Automatic synchronization between dialog inputs and PLC variables

### Required Implementation in Client Projects

**?? IMPORTANT**: To use the dialog functionality, your **client project MUST include a `ProcessControlDialogView`** implementation. Without this view, the controls will not be able to display the dialog when clicked.

#### Creating the Required ProcessControlDialogView

1. **Create the XAML View** (e.g., in `Views\DialogRegion\ProcessControlDialogView.xaml`):

```xml
<vw:View x:Class="HMI.ProcessControlDialogView"
         xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
         xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
         xmlns:vw="http://inosoft.com/visiwin7"
         MinWidth="380" MinHeight="140"
         Background="{DynamicResource ApplicationBackgroundBrush}">

    <Grid x:Name="LayoutRoot">
        <ItemsControl ItemsSource="{Binding Path=Values}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <StackPanel Orientation="Vertical" Margin="10" />
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>

            <ItemsControl.ItemContainerStyle>
                <Style>
                    <Setter Property="FrameworkElement.Margin" Value="0,0,0,10" />
                </Style>
            </ItemsControl.ItemContainerStyle>
        </ItemsControl>
    </Grid>
</vw:View>
```

2. **Create the Code-Behind** (`ProcessControlDialogView.xaml.cs`):

```csharp

namespace HMI
{
    /// <summary>
    /// Interaction logic for ProcessControlDialogView.xaml
    /// </summary>
    [ExportView("ProcessControlDialogView")]
    public partial class ProcessControlDialogView : VisiWin.Controls.View
    {
        public ProcessControlDialogView()
        {
            this.InitializeComponent();
        }
    }
}
```

**Key Requirements:**
- The class **MUST** be named `HMI.ProcessControlDialogView` (namespace and class name)
- The class **MUST** have the `[ExportView("ProcessControlDialogView")]` attribute
- The view name in the attribute must be `"ProcessControlDialogView"` to match the default `DialogViewName` property

### Enabling Dialog Properties in Variable Mappings

By default, all variable mappings are treated as dialog properties. To configure which properties appear in the dialog:

```xml
<controls:Tank x:Name="Tank1"
        StructVariableName="PLC.Tank1">
    <controls:Tank.Mapping>
        <mapping:VariableNameMappingCollection>
            <!-- This property WILL appear in the dialog (IsDialogProperty defaults to true) -->
            <mapping:VariableNameControlPropertyMapping 
                VariableName="SetValue" 
                ControlPropertyName="SetValue"/>
            
            <!-- This property will NOT appear in the dialog -->
            <mapping:VariableNameControlPropertyMapping 
                VariableName="ActualValue" 
                ControlPropertyName="ActualValue"
                IsDialogProperty="False"/>
            
            <!-- Error property typically excluded from dialog -->
            <mapping:VariableNameControlPropertyMapping 
                VariableName="Errors" 
                ControlPropertyName="Errors"
                IsDialogProperty="False"/>
        </mapping:VariableNameMappingCollection>
    </controls:Tank.Mapping>
</controls:Tank>
```

### Supported Dialog Property Types

The dialog system automatically creates appropriate input controls based on property types:

| Property Type | Dialog Property Class | Input Control |
|---------------|----------------------|---------------|
| `bool` | `BoolDialogProperty` | Checkbox or toggle |
| `string` | `StringDialogProperty` | Text input field |
| `int` | `IntDialogProperty` | Numeric input field |

**Example of automatic type mapping:**

```csharp
// In your custom control
[Category("Process")]
public bool IsEnabled
{
    get => (bool)GetValue(IsEnabledProperty);
    set => SetValue(IsEnabledProperty, value);
}

public static readonly DependencyProperty IsEnabledProperty =
    DependencyProperty.Register("IsEnabled", typeof(bool), 
        typeof(CustomControl), new PropertyMetadata(false));
```

When mapped with `IsDialogProperty="True"`, this boolean property will automatically appear as a checkbox in the dialog.

### Controlling Dialog Behavior

The `ProcessControlBase` class provides several properties to control dialog behavior:

```csharp
// Enable or disable the dialog functionality
control.CanShowDialog = true; // Default: true

// Change the dialog view name (if you create a custom dialog view)
control.DialogViewName = "CustomProcessControlDialogView";

// Access dialog properties programmatically
var dialogProps = control.DialogProperties;
```

**Disabling Dialog for Specific Controls:**

### Available Process Controls

The framework includes the following categories of process controls:

**Conveyors:**
- BeltConveyor
- ScrewConveyor
- CeilingConveyor

**Valves:**
- Valve (base)
- BallValve
- GlobeValve
- MotorValve
- AngleValve
- FlapValve
- GateValve
- PistonValve
- ThreeWayValve

**Pumps & Compressors:**
- Pump
- Compressor
- Fan

**Tanks & Containers:**
- Tank
- RoundTank
- Silo

**Heat Exchangers:**
- HeatExchanger
- HeatExchangerTubes
- HeatExchangerWithoutCrossingFlow
- Burner
- Cooler
- CoolingTower
- CoolingTowerWithInlet
- SprayCoolingTower

**Mechanical Equipment:**
- RotaryFeeder
- Diverter
- Centrifugal
- Stirer
- Scale

**Pipes & Connections:**
- Pipe
- PipeBridge
- PipeConnection
- Arrow

**Engines:**
- Motor
- Turbine

## License

This project is provided as a sample implementation for VisiWin7 development.