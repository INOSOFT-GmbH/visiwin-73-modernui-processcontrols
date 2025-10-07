<!-- Readme for open source repositories -->
# VisiWin7.ProcessControls.ModernUI

This repository demonstrates how to create and extend process controls for the VisiWin7 IDE using ModernUI (WPF) technology. 
It provides a comprehensive set of reusable industrial process control components that can be easily integrated into VisiWin7 Runtime 7.3 projects.

The project serves as both a sample implementation and a foundation for developing custom process controls such as tanks, valves, pumps, conveyors, and other industrial automation components. 
Useful for UI developers and automation engineers working with the VisiWin7 IDE who need to create custom visual representations of industrial processes.

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

3. **Use controls in XAML with variable mapping**:

```xml
<controls:BeltConveyor x:Name="Conveyor1" 
                       StrokeThickness="2" 
                       Foreground="Blue" 
                       Background="LightGray">
    <controls:BeltConveyor.Mapping>
        <mapping:VariableNameMappingCollection>
            <mapping:VariableNameControlPropertyMapping 
                VariableName="PLC.Conveyor1.ActualValue" 
                ControlPropertyName="ActualValue"/>
            <mapping:VariableNameControlPropertyMapping 
                VariableName="PLC.Conveyor1.SetValue" 
                ControlPropertyName="SetValue"/>
        </mapping:VariableNameMappingCollection>
    </controls:BeltConveyor.Mapping>
</controls:BeltConveyor>
```

### Creating Custom Process Controls

1. **Inherit from base classes**:

```csharp
public class CustomTank : TankBase
{
    // Custom implementation
}

// Or for new categories:
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

## Details

This repository contains four main projects that work together to provide a complete process controls framework:

### [VisiWin7.ProcessControls.WPF](VisiWin7.ProcessControls.WPF/)

The **core logic project** containing all process control classes and business logic.

- **Purpose**: Contains class definitions and implementations for all process controls
- **Key Components**:
  - `DefaultProcessControlBase` - Base class for all process controls
  - Specialized base classes (`TankBase`, `ValveBase`, `PumpBase`, `ConveyorBase`, etc.)
  - Concrete implementations (e.g., `BeltConveyor`, `CentrifugalPump`)
  - Custom properties with dependency property support
  - Process-specific logic and behaviors

**Main Types**:
- `ProcessControlBase` - Root base class with basic properties
- `DefaultProcessControlBase` - Enhanced base with standard process control features
- Category-specific base classes for common control types

### [VisiWin7.ProcessControls.Styles.WPF](VisiWin7.ProcessControls.Styles.WPF/)

The **styling and visual representation project** containing all XAML styles and symbols.

- **Purpose**: Defines the visual appearance and symbols for process controls
- **Key Components**:
  - ResourceDictionaries with control styles
  - Path-based symbol definitions using WPF Path Markup syntax
  - Visual templates and indicators
  - Styling configurations for different control states

**Architecture**:
- Symbols defined as `<Style>` elements with `IndicatorTemplate` setters
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

The **design-time support project** for VisiWin7 IDE integration.

- **Purpose**: Provides metadata and design-time experience for the VisiWin7 IDE
- **Key Components**:
  - Property grid editors and selection editors
  - Design-time metadata for improved IDE experience
  - Custom property editors for process-specific properties
  - Integration with VisiWin7 development environment

## Process Control Development Guide

### Creating New Controls

1. **Define the Control Class**: Inherit from appropriate base class
2. **Implement Custom Logic**: Add dependency properties and business logic
3. **Create Visual Symbol**: Design the XAML symbol in the styles project
4. **Configure Variable Mapping**: Set up PLC variable connections
5. **Register in IDE**: Add configuration to make it available in toolbox
6. **Test Integration**: Verify functionality in VisiWin7 IDE and runtime

### Variable Mapping System

The process controls framework provides a powerful variable mapping system that connects control properties to PLC variables. This enables real-time data exchange between the HMI and automation systems.

#### Understanding VariableNameMappingCollection

The `Mapping` property of each process control contains a `VariableNameMappingCollection` that defines the relationships between PLC variables and control properties:

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
<controls:Tank x:Name="Tank1">
    <controls:Tank.Mapping>
        <mapping:VariableNameMappingCollection>
            <!-- Map PLC variable to control property -->
            <mapping:VariableNameControlPropertyMapping 
                VariableName="PLC.Tank1.FillLevel" 
                ControlPropertyName="ActualValue"/>
            <mapping:VariableNameControlPropertyMapping 
                VariableName="PLC.Tank1.SetPoint" 
                ControlPropertyName="SetValue"/>
            <mapping:VariableNameControlPropertyMapping 
                VariableName="PLC.Tank1.Alarms" 
                ControlPropertyName="Errors"/>
        </mapping:VariableNameMappingCollection>
    </controls:Tank.Mapping>
</controls:Tank>
```

**In Code-Behind:**
```csharp
// Create mapping collection
var mappingCollection = new VariableNameMappingCollection();

// Add individual mappings
mappingCollection.Add(new VariableNameControlPropertyMapping
{
    VariableName = "PLC.Tank1.FillLevel",
    ControlPropertyName = "ActualValue"
});

mappingCollection.Add(new VariableNameControlPropertyMapping
{
    VariableName = "PLC.Tank1.SetPoint", 
    ControlPropertyName = "SetValue"
});

// Assign to control
Tank1.Mapping = mappingCollection;