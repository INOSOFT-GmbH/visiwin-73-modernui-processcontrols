# VisiWin7.ProcessControls.WPF

[![NuGet Version](https://img.shields.io/nuget/v/VisiWin7.ProcessControls.WPF?style=flat-square)](https://www.nuget.org/packages/VisiWin7.ProcessControls.WPF)
[![.NET Framework 4.8](https://img.shields.io/badge/.NET%20Framework-4.8-blue?style=flat-square)](https://dotnet.microsoft.com/download/dotnet-framework/net48)

Modern WPF controls for industrial process visualization and automation systems. This package provides a comprehensive set of process control elements including valves, pumps, tanks, pipes, and other industrial equipment for use in VisiWin7 and general WPF applications.

## ?? Quick Start

### Installation

Install the package via NuGet Package Manager:

```powershell
Install-Package VisiWin7.ProcessControls.WPF
```

Or via .NET CLI:

```bash
dotnet add package VisiWin7.ProcessControls.WPF
```

Or add to your `.csproj` file:

```xml
<PackageReference Include="VisiWin7.ProcessControls.WPF" Version="1.0.0" />
```

### Basic Usage

1. **Add the namespace** to your XAML file:

```xml
<Window x:Class="YourApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:pc="http://inosoft.com/ProcessControls">
    <!-- Your content -->
</Window>
```

2. **Use process controls** in your layout:

```xml
<Grid>
    <!-- Tank with level indication -->
    <pc:Tank x:Name="Tank1" 
             Width="100" Height="150"
             ActualValue="75" Volume="100"
             Background="LightBlue" />
    
    <!-- Pump with status -->
    <pc:Pump x:Name="Pump1" 
             Width="80" Height="60"
             ActualValue="1"
             IsEnabled="True" />
    
    <!-- Valve with control -->
    <pc:Valve x:Name="Valve1"
              Width="60" Height="40"
              ActualValue="0" />
</Grid>
```

## ?? Available Controls

### Tanks & Vessels
- **`Tank`** - Rectangular tank with level indicator
- **`RoundTank`** - Circular tank with level indicator  
- **`Silo`** - Silo for bulk materials

### Pumps & Compressors
- **`Pump`** - Centrifugal pump
- **`Compressor`** - Gas compressor
- **`Fan`** - Ventilation fan

### Valves
- **`Valve`** - Generic valve
- **`BallValve`** - Ball valve
- **`GlobeValve`** - Globe valve
- **`MotorValve`** - Motor-operated valve
- **`AngleValve`** - Angle valve
- **`FlapValve`** - Butterfly valve
- **`GateValve`** - Gate valve
- **`PistonValve`** - Piston valve
- **`ThreeWayValve`** - Three-way valve

### Pipes & Connections
- **`Pipe`** - Process pipe
- **`PipeBridge`** - Pipe bridge/crossing
- **`PipeConnection`** - Pipe junction
- **`Arrow`** - Flow direction indicator

### Heat Exchangers
- **`HeatExchanger`** - Shell and tube heat exchanger
- **`HeatExchangerTubes`** - Tube bundle heat exchanger
- **`HeatExchangerWithoutCrossingFlow`** - Parallel flow heat exchanger
- **`Cooler`** - Cooling unit
- **`Burner`** - Heating burner
- **`CoolingTower`** - Cooling tower
- **`CoolingTowerWithInlet`** - Cooling tower with inlet
- **`SprayCoolingTower`** - Spray cooling tower

### Mechanical Equipment
- **`Motor`** - Electric motor
- **`Turbine`** - Steam/gas turbine
- **`RotaryFeeder`** - Rotary feeder
- **`Diverter`** - Material diverter
- **`Centrifugal`** - Centrifugal separator
- **`Stirer`** - Mixing agitator
- **`Scale`** - Weighing scale

### Conveyors
- **`BeltConveyor`** - Belt conveyor system
- **`ScrewConveyor`** - Screw conveyor
- **`CeilingConveyor`** - Overhead conveyor

## ?? Key Features

### Process Integration
- **Variable Mapping**: Bind controls to process variables
- **State Visualization**: Visual states based on process values
- **Error Indication**: Built-in error state display
- **Real-time Updates**: Automatic updates from data sources

### Customization
- **Styling**: Full WPF styling support
- **Orientation**: Rotate controls to any angle
- **Sizing**: Responsive scaling
- **Colors**: Customizable colors and brushes

### VisiWin7 Integration
- **Design-Time Support**: Full Visual Studio designer support
- **Variable Browser**: Integrated variable selection
- **Localization**: Multi-language support
- **Authorization**: Built-in access control

## ?? Data Binding Examples

### Simple Binding
```xml
<pc:Tank ActualValue="{Binding TankLevel}" 
         Volume="{Binding TankCapacity}" />
```

### Advanced Process Binding
```xml
<pc:Pump ActualValue="{Binding PumpStatus}"
         Errors="{Binding PumpErrors}"
         StructVariableName="Plant.PumpArea.Pump01" />
```

### State-Based Visualization
```xml
<pc:Valve ActualValue="{Binding ValvePosition}">
    <pc:Valve.StateBrushes>
        <pc:BlinkBrushStateCollection>
            <pc:BlinkBrushState StateValue="0" Brush="Red" />      <!-- Closed -->
            <pc:BlinkBrushState StateValue="1" Brush="Green" />    <!-- Open -->
            <pc:BlinkBrushState StateValue="2" Brush="Orange" />   <!-- Intermediate -->
        </pc:BlinkBrushStateCollection>
    </pc:Valve.StateBrushes>
</pc:Valve>
```

## ?? Styling

The controls support full WPF styling and can be customized using standard WPF techniques:

```xml
<Style x:Key="IndustrialTankStyle" TargetType="pc:Tank">
    <Setter Property="Background" Value="SteelBlue" />
    <Setter Property="BorderBrush" Value="DarkSlateGray" />
    <Setter Property="BorderThickness" Value="2" />
</Style>

<pc:Tank Style="{StaticResource IndustrialTankStyle}" />
```

## ?? Related Packages

- **[VisiWin7.ProcessControls.Styles.WPF](https://www.nuget.org/packages/VisiWin7.ProcessControls.Styles.WPF)** - Pre-built styles for enhanced appearance

## ?? Requirements

- **.NET Framework 4.8** or higher
- **WPF Application** (Windows Presentation Foundation)
- **Visual Studio 2019** or higher (recommended)

## ?? Use Cases

- **SCADA Systems** - Supervisory control and data acquisition
- **Process Visualization** - Industrial process monitoring
- **Plant Simulation** - Process flow simulation
- **Training Systems** - Operator training simulators
- **Engineering Tools** - Process design applications

## ?? Support

- **Documentation**: [VisiWin7 Documentation](https://github.com/INOSOFT-GmbH/visiwin-73-modernui-processcontrols)
- **Issues**: [GitHub Issues](https://github.com/INOSOFT-GmbH/visiwin-73-modernui-processcontrols/issues)
- **License**: MIT License

## ?? About INOSOFT

INOSOFT GmbH is a leading provider of industrial automation and visualization software solutions. VisiWin7 is our flagship HMI/SCADA platform for modern industrial applications.

---

**Copyright © 1994-2025 INOSOFT® GmbH. All rights reserved.**