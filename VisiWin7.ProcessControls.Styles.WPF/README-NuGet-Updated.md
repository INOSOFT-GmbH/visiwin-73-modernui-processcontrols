# VisiWin7.ProcessControls.Styles.WPF NuGet Package

Dieses Verzeichnis enthält alle notwendigen Dateien zur Erstellung eines NuGet-Pakets für die VisiWin7 Process Controls Styles.

## ? Automatische NuGet-Paket-Erstellung

**Das Projekt ist jetzt so konfiguriert, dass automatisch ein NuGet-Paket erstellt wird, sobald du das Projekt im Release-Modus kompilierst!**

### Automatische Erstellung aktiviert
- **Release-Build**: Erstellt automatisch ein NuGet-Paket in `bin\Release\`
- **Debug-Build**: Keine NuGet-Paket-Erstellung (normal kompilieren)

## Dateien

- `VisiWin7.ProcessControls.Styles.WPF.csproj` - **Projektdatei mit automatischer NuGet-Generierung**
- `VisiWin7.ProcessControls.Styles.WPF.nuspec` - NuGet-Paketspezifikation mit Abhängigkeiten
- `build-nuget-msbuild.bat` - Manuelles Build-Skript (optional)
- `README-NuGet-Updated.md` - Diese Anleitung

## NuGet-Paket erstellen

### Option 1: Automatisch mit Visual Studio (Empfohlen)
1. Wähle **Release** Konfiguration in Visual Studio
2. **Build** ? **Rebuild Solution** oder **Build Project**
3. Das NuGet-Paket wird automatisch in `bin\Release\` erstellt

### Option 2: Automatisch mit MSBuild
```cmd
msbuild VisiWin7.ProcessControls.Styles.WPF.csproj /p:Configuration=Release /p:Platform=AnyCPU
```

### Option 3: Manuell mit Build-Skript
```cmd
.\build-nuget-msbuild.bat
```

## Automatisierung Details

Die Projektdatei enthält jetzt:

```xml
<!-- Automatische NuGet-Generierung nur für Release-Builds -->
<GeneratePackageOnBuild Condition="'$(Configuration)' == 'Release'">true</GeneratePackageOnBuild>

<!-- MSBuild Target für automatische Paketerstellung -->
<Target Name="CreateNuGetPackage" AfterTargets="Build" Condition="'$(Configuration)' == 'Release'">
  <Exec Command="nuget.exe pack VisiWin7.ProcessControls.Styles.WPF.nuspec -OutputDirectory bin\Release" 
        WorkingDirectory="$(MSBuildProjectDirectory)" />
</Target>
```

**Wichtige Abhängigkeiten:**

Das NuGet-Paket enthält die **korrekte Abhängigkeit** zu `VisiWin7.ProcessControls.WPF`:

```xml
<dependencies>
  <group targetFramework=".NETFramework4.8">
    <dependency id="VisiWin7.ProcessControls.WPF" version="1.0.0" />
  </group>
</dependencies>
```

## Voraussetzungen

1. **Visual Studio** oder **MSBuild** 
2. **NuGet CLI** (vorhanden in `nuget.exe`)

## Paketinhalt

Das automatisch erstellte NuGet-Paket enthält:

### Assembly
- `VisiWin7.ProcessControls.Styles.WPF.dll` (in `lib\net48\`)
- `VisiWin7.ProcessControls.Styles.WPF.pdb` (Debug-Symbole)

### XAML Style-Dateien
- `ConveyorStyles.xaml`
- `EngineStyles.xaml`
- `ExchangerStyles.xaml`
- `MechanicalEquipmentStyles.xaml`
- `PipeStyles.xaml`
- `ProcessControlStyles.xaml`
- `ProcessControlsVariableMapping.xaml`
- `PumpStyles.xaml`
- `Resources.xaml`
- `Styling.xaml`
- `TankStyles.xaml`
- `ValveStyles.xaml`

### Abhängigkeiten
- **VisiWin7.ProcessControls.WPF** (Version 1.0.0) für .NET Framework 4.8

### README
- Diese Dokumentation für NuGet.org

## Workflow

1. **Entwicklung**: Debug-Builds erstellen keine NuGet-Pakete
2. **Release**: Automatische NuGet-Paket-Erstellung bei jedem Release-Build
3. **Veröffentlichung**: Paket aus `bin\Release\` verwenden

## Paket veröffentlichen

Nach der automatischen Erstellung findest du die `.nupkg`-Datei im `bin\Release\` Verzeichnis.

### Lokale Veröffentlichung
```cmd
nuget sources add -name "Local" -source "C:\LocalNuGetFeed"
copy bin\Release\VisiWin7.ProcessControls.Styles.WPF.*.nupkg C:\LocalNuGetFeed\
```

### NuGet.org Veröffentlichung
```cmd
nuget push bin\Release\VisiWin7.ProcessControls.Styles.WPF.*.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey [YOUR_API_KEY]
```

### Private NuGet-Repository
```cmd
nuget push bin\Release\VisiWin7.ProcessControls.Styles.WPF.*.nupkg -Source [YOUR_PRIVATE_FEED_URL] -ApiKey [YOUR_API_KEY]
```

## Paket verwenden

Nach der Veröffentlichung kann das Paket in anderen Projekten installiert werden:

```cmd
# Package Manager Console
Install-Package VisiWin7.ProcessControls.Styles.WPF

# .NET CLI
dotnet add package VisiWin7.ProcessControls.Styles.WPF

# PackageReference in .csproj
<PackageReference Include="VisiWin7.ProcessControls.Styles.WPF" Version="1.0.0" />
```

**Wichtig:** Beim Installieren wird automatisch auch `VisiWin7.ProcessControls.WPF` als Abhängigkeit installiert.

## Anpassungen

### Version ändern
Bearbeite sowohl die `.csproj`- als auch die `.nuspec`-Datei:

**.csproj:**
```xml
<PackageVersion>1.0.1</PackageVersion>
```

**.nuspec:**
```xml
<version>1.0.1</version>
```

### Abhängigkeiten anpassen
Bearbeite den `<dependencies>`-Bereich in der `.nuspec`-Datei:
```xml
<dependencies>
  <group targetFramework=".NETFramework4.8">
    <dependency id="VisiWin7.ProcessControls.WPF" version="1.0.1" />
    <!-- Weitere Abhängigkeiten hier hinzufügen -->
  </group>
</dependencies>
```

## Troubleshooting

Falls die automatische Erstellung nicht funktioniert:
1. Stelle sicher, dass `nuget.exe` im Projektverzeichnis vorhanden ist
2. Überprüfe, dass die `.nuspec`-Datei korrekt ist
3. Verwende das manuelle Build-Skript: `.\build-nuget-msbuild.bat`