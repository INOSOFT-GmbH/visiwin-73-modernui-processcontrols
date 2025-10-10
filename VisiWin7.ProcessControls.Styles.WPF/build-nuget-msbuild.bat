@echo off
echo Building VisiWin7.ProcessControls.Styles.WPF NuGet Package using MSBuild...

REM Build the project in Release mode
echo Building project in Release mode...
msbuild VisiWin7.ProcessControls.Styles.WPF.csproj /p:Configuration=Release /p:Platform=AnyCPU

REM Check if build was successful
if %ERRORLEVEL% neq 0 (
    echo Build failed. Please fix build errors before creating NuGet package.
    pause
    exit /b 1
)

REM Check if nuget.exe exists, if not, download it
if not exist "nuget.exe" (
    echo Downloading nuget.exe...
    powershell -Command "Invoke-WebRequest -Uri 'https://dist.nuget.org/win-x86-commandline/latest/nuget.exe' -OutFile 'nuget.exe'"
    if %ERRORLEVEL% neq 0 (
        echo Failed to download nuget.exe
        pause
        exit /b 1
    )
)

REM Create NuGet package using .nuspec file (includes dependencies)
echo Creating NuGet package using .nuspec file with dependencies...
.\nuget.exe pack VisiWin7.ProcessControls.Styles.WPF.nuspec -OutputDirectory bin\Release

REM Check if pack was successful
if %ERRORLEVEL% neq 0 (
    echo NuGet pack failed. Please check the nuspec file.
    pause
    exit /b 1
)

echo NuGet package created successfully with dependencies!
echo Look for VisiWin7.ProcessControls.Styles.WPF.*.nupkg in the bin\Release\ directory.
echo.
echo The package includes:
echo - VisiWin7.ProcessControls.Styles.WPF assembly
echo - All XAML style files
echo - Dependency on VisiWin7.ProcessControls.WPF
echo.

REM Optionales Publishing zu GitHub Packages
set /p PUBLISH_CHOICE="Möchten Sie das Paket zu GitHub Packages hochladen? (y/n): "
if /i "%PUBLISH_CHOICE%"=="y" (
    echo.
    echo ?? Publishing to GitHub Packages...
    
    if "%GITHUB_TOKEN%"=="" (
        echo ? GITHUB_TOKEN environment variable is required!
        echo Please set it with: set GITHUB_TOKEN=your_token_here
        pause
        exit /b 1
    )
    
    REM GitHub Packages Source konfigurieren
    .\nuget.exe sources add -Name "github" -Source "https://nuget.pkg.github.com/INOSOFT-GmbH/index.json" -Username INOSOFT-GmbH -Password %GITHUB_TOKEN% -StorePasswordInClearText 2>nul
    
    REM Alle .nupkg Dateien hochladen
    for %%f in (bin\Release\*.nupkg) do (
        echo ?? Uploading %%f...
        .\nuget.exe push "%%f" -Source "github" -ApiKey %GITHUB_TOKEN% -SkipDuplicate
        if %ERRORLEVEL% equ 0 (
            echo ? Successfully published %%f
        ) else (
            echo ? Failed to publish %%f
        )
    )
    
    echo ? Publishing completed!
    echo ?? View packages at: https://github.com/INOSOFT-GmbH/visiwin-73-modernui-processcontrols/packages
)

pause