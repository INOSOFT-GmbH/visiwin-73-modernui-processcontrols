# VisiWin7.ProcessControls.Styles.WPF

[![NuGet Version](https://img.shields.io/nuget/v/VisiWin7.ProcessControls.Styles.WPF?style=flat-square)](https://www.nuget.org/packages/VisiWin7.ProcessControls.Styles.WPF)
[![.NET Framework 4.8](https://img.shields.io/badge/.NET%20Framework-4.8-blue?style=flat-square)](https://dotnet.microsoft.com/download/dotnet-framework/net48)

Professional WPF styles and themes for VisiWin7 Process Controls. This package provides polished, industrial-grade visual styles that enhance the appearance and usability of process control elements in your WPF applications.

## ?? Quick Start

### Installation

Install the package via NuGet Package Manager:

```powershell
Install-Package VisiWin7.ProcessControls.Styles.WPF
```

Or via .NET CLI:

```bash
dotnet add package VisiWin7.ProcessControls.Styles.WPF
```

Or add to your `.csproj` file:

```xml
<PackageReference Include="VisiWin7.ProcessControls.Styles.WPF" Version="1.0.0" />
```

> **Note**: This package automatically includes `VisiWin7.ProcessControls.WPF` as a dependency.

### Basic Usage

1. **Add the style resources** to your application:

```xml
<Application x:Class="YourApp.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <!-- Include process control styles -->
                <ResourceDictionary Source="pack://application:,,,/VisiWin7.ProcessControls.Styles.WPF;component/ProcessControlStyles.xaml" />
                <ResourceDictionary Source="pack://application:,,,/VisiWin7.ProcessControls.Styles.WPF;component/ValveStyles.xaml" />
                <ResourceDictionary Source="pack://application:,,,/VisiWin7.ProcessControls.Styles.WPF;component/TankStyles.xaml" />
                <ResourceDictionary Source="pack://application:,,,/VisiWin7.ProcessControls.Styles.WPF;component/PumpStyles.xaml" />
                <!-- Add other style files as needed -->
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

2. **Use styled controls** in your layout:

```xml
<Window x:Class="YourApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:pc="http://inosoft.com/ProcessControls">
    <Grid>
        <!-- Controls automatically use the imported styles -->
        <pc:Tank x:Name="Tank1" Width="100" Height="150" ActualValue="75" Volume="100" />
        <pc:Pump x:Name="Pump1" Width="80" Height="60" ActualValue="1" />
        <pc:Valve x:Name="Valve1" Width="60" Height="40" ActualValue="0" />
    </Grid>
</Window>
```

## ?? Available Style Collections

### Core Styles
- **`ProcessControlStyles.xaml`** - Base styles for all process controls
- **`Resources.xaml`** - Common resources (brushes, converters, etc.)
- **`Styling.xaml`** - Global styling definitions

### Equipment-Specific Styles
- **`ValveStyles.xaml`** - Styles for all valve types (ball, globe, gate, etc.)
- **`TankStyles.xaml`** - Tank and vessel styling
- **`PumpStyles.xaml`** - Pump and compressor styles
- **`PipeStyles.xaml`** - Pipe and connection styling
- **`ExchangerStyles.xaml`** - Heat exchanger styles
- **`ConveyorStyles.xaml`** - Conveyor system styles
- **`EngineStyles.xaml`** - Motor and turbine styles
- **`MechanicalEquipmentStyles.xaml`** - General mechanical equipment

### Advanced Features
- **`ProcessControlsVariableMapping.xaml`** - Variable mapping templates

## ?? Style Features

### Professional Appearance
- **Modern Design**: Clean, contemporary industrial look
- **Consistent Theming**: Unified appearance across all controls
- **High Contrast**: Optimized for industrial environments
- **Scalable Graphics**: Vector-based designs that scale perfectly

### Interactive Elements
- **Hover Effects**: Visual feedback on mouse interaction
- **State Indicators**: Clear visual states (open/closed, running/stopped, etc.)
- **Animation Support**: Smooth transitions and state changes
- **Focus Indicators**: Clear keyboard navigation support

### Customization Options
- **Color Schemes**: Easy to customize color palettes
- **Size Variants**: Multiple size options for different use cases
- **Border Styles**: Various border and frame options
- **Background Patterns**: Industrial-appropriate background styles

## ?? Advanced Usage

### Custom Style Application

Apply specific styles to individual controls:

```xml
<pc:Tank Style="{StaticResource IndustrialTankStyle}" 
         ActualValue="75" Volume="100" />

<pc:Valve Style="{StaticResource ModernValveStyle}" 
          ActualValue="{Binding ValvePosition}" />
```

### Theme Switching

Switch between different visual themes:

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <!-- Light theme -->
            <ResourceDictionary Source="pack://application:,,,/VisiWin7.ProcessControls.Styles.WPF;component/Themes/LightTheme.xaml" />
            
            <!-- Or dark theme -->
            <!-- <ResourceDictionary Source="pack://application:,,,/VisiWin7.ProcessControls.Styles.WPF;component/Themes/DarkTheme.xaml" /> -->
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

### State-Based Styling

Configure visual states for process values:

```xml
<pc:Pump ActualValue="{Binding PumpStatus}">
    <pc:Pump.StateBrushes>
        <pc:BlinkBrushStateCollection>
            <pc:BlinkBrushState StateValue="0" Brush="#FF6B6B" />  <!-- Stopped - Red -->
            <pc:BlinkBrushState StateValue="1" Brush="#4ECDC4" />  <!-- Running - Green -->
            <pc:BlinkBrushState StateValue="2" Brush="#FFE66D" />  <!-- Warning - Yellow -->
        </pc:BlinkBrushStateCollection>
    </pc:Pump.StateBrushes>
</pc:Pump>
```

## ?? Customization Guide

### Override Default Colors

Create your own color scheme:

```xml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    
    <!-- Override default brushes -->
    <SolidColorBrush x:Key="ProcessControlPrimaryBrush" Color="#2E4057" />
    <SolidColorBrush x:Key="ProcessControlAccentBrush" Color="#F39C12" />
    <SolidColorBrush x:Key="ProcessControlBackgroundBrush" Color="#ECF0F1" />
    
    <!-- Include default styles -->
    <ResourceDictionary.MergedDictionaries>
        <ResourceDictionary Source="pack://application:,,,/VisiWin7.ProcessControls.Styles.WPF;component/ProcessControlStyles.xaml" />
    </ResourceDictionary.MergedDictionaries>
</ResourceDictionary>
```

### Create Custom Styles

Extend existing styles:

```xml
<Style x:Key="MyTankStyle" BasedOn="{StaticResource {x:Type pc:Tank}}" TargetType="pc:Tank">
    <Setter Property="BorderThickness" Value="3" />
    <Setter Property="BorderBrush" Value="DarkBlue" />
    <Setter Property="Background" Value="LightCyan" />
</Style>
```

## ?? Use Cases

- **SCADA Applications** - Professional process visualization
- **Control Panels** - Operator interface screens
- **Training Simulators** - Educational process simulation
- **Engineering Tools** - Process design and documentation
- **Monitoring Systems** - Real-time process monitoring

## ?? Package Contents

### Style Files
- Complete style definitions for all process controls
- Resource dictionaries with brushes, templates, and converters
- Theme definitions for consistent appearance
- Animation and transition definitions

### Variable Mapping
- Pre-configured variable mapping templates
- Common process variable bindings
- State mapping definitions

## ?? Requirements

- **VisiWin7.ProcessControls.WPF** (automatically installed)
- **.NET Framework 4.8** or higher
- **WPF Application** (Windows Presentation Foundation)

## ?? Related Packages

- **[VisiWin7.ProcessControls.WPF](https://www.nuget.org/packages/VisiWin7.ProcessControls.WPF)** - Core process control library (automatically included)

## ?? Support

- **Documentation**: [VisiWin7 Documentation](https://github.com/INOSOFT-GmbH/visiwin-73-modernui-processcontrols)
- **Issues**: [GitHub Issues](https://github.com/INOSOFT-GmbH/visiwin-73-modernui-processcontrols/issues)
- **License**: MIT License

## ?? About INOSOFT

INOSOFT GmbH is a leading provider of industrial automation and visualization software solutions. VisiWin7 is our flagship HMI/SCADA platform for modern industrial applications.

---

**Copyright © 1994-2025 INOSOFT® GmbH. All rights reserved.**