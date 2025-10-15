@echo off
echo ====================================================
echo  VisiWin7.ProcessControls.WPF - Build & Publish
echo ====================================================

REM Clean and rebuild the project in Release mode (ensures NuGet package generation)
echo ?? Cleaning previous build outputs...
msbuild VisiWin7.ProcessControls.WPF.csproj /p:Configuration=Release /p:Platform=AnyCPU /t:Clean

echo ?? Building project in Release mode (auto-generates NuGet package)...
msbuild VisiWin7.ProcessControls.WPF.csproj /p:Configuration=Release /p:Platform=AnyCPU /t:Rebuild

REM Check if build was successful
if %ERRORLEVEL% neq 0 (
    echo ? Build failed. Please fix build errors before creating NuGet package.
    pause
    exit /b 1
)

echo ? Build completed successfully!
echo.

REM Check if NuGet package was created
if not exist "bin\Release\*.nupkg" (
    echo ??  No NuGet package found in bin\Release\
    echo.
    echo ?? Trying to force NuGet package generation...
    
    REM For .NET Framework projects, we need to check if nuget.exe exists and use .nuspec
    if not exist "nuget.exe" (
        echo ?? Downloading nuget.exe for package creation...
        powershell -Command "Invoke-WebRequest -Uri 'https://dist.nuget.org/win-x86-commandline/latest/nuget.exe' -OutFile 'nuget.exe'"
        if %ERRORLEVEL% neq 0 (
            echo ? Failed to download nuget.exe
            pause
            exit /b 1
        )
    )
    
    REM Try using nuget pack with .nuspec if available
    if exist "VisiWin7.ProcessControls.WPF.nuspec" (
        echo ?? Creating package using .nuspec file...
        .\nuget.exe pack VisiWin7.ProcessControls.WPF.nuspec -OutputDirectory bin\Release
    ) else (
        echo ?? Creating package from .csproj file...
        .\nuget.exe pack VisiWin7.ProcessControls.WPF.csproj -Properties Configuration=Release -OutputDirectory bin\Release
    )
    
    if exist "bin\Release\*.nupkg" (
        echo ? NuGet package generated successfully!
    ) else (
        echo ? Still no NuGet package found. 
        echo.
        echo ?? Possible issues:
        echo 1. Missing PackageId, PackageVersion in .csproj
        echo 2. Missing .nuspec file
        echo 3. Build errors preventing package creation
        echo.
        echo ?? Try running: nuget pack VisiWin7.ProcessControls.WPF.csproj -Properties Configuration=Release
        echo.
        pause
        exit /b 1
    )
)

REM Show created packages
echo ?? Created NuGet packages:
for %%f in (bin\Release\*.nupkg) do (
    echo   - %%~nxf (%%~zf bytes)
)
echo.

REM Display package information
echo ?? Package includes:
echo   - VisiWin7.ProcessControls.WPF assembly
echo   - Process control library
echo   - README and package metadata
echo.

REM Check if nuget.exe exists, if not, download it (only needed for publishing)
if not exist "nuget.exe" (
    echo ?? Downloading nuget.exe for publishing...
    powershell -Command "Invoke-WebRequest -Uri 'https://dist.nuget.org/win-x86-commandline/latest/nuget.exe' -OutFile 'nuget.exe'"
    if %ERRORLEVEL% neq 0 (
        echo ? Failed to download nuget.exe
        echo You can still find the packages in bin\Release\ for manual publishing
        pause
        exit /b 0
    )
)

REM Optional publishing to GitHub Packages
echo.
set /p PUBLISH_CHOICE="?? Upload package to GitHub Packages? (y/n): "
if /i "%PUBLISH_CHOICE%"=="y" (
    echo.
    echo ?? Publishing to GitHub Packages...
    
    REM Check for GitHub token
    if "%GITHUB_TOKEN%"=="" (
        echo.
        echo ??  GITHUB_TOKEN environment variable not found!
        echo.
        echo Options to set the token:
        echo   1. Set permanently: setx GITHUB_TOKEN "your_token_here"
        echo   2. Set for this session: set GITHUB_TOKEN=your_token_here  
        echo   3. Enter manually below
        echo.
        set /p MANUAL_TOKEN="Enter GitHub Token (or press Enter to skip): "
        if "!MANUAL_TOKEN!"=="" (
            echo Skipping publishing. Packages are available in bin\Release\
            goto :skip_publish
        )
        set GITHUB_TOKEN=!MANUAL_TOKEN!
        echo ? Token set for this session
    ) else (
        echo ? Found GITHUB_TOKEN environment variable
    )
    
    echo.
    echo ?? Configuring GitHub Packages source...
    .\nuget.exe sources add -Name "github" -Source "https://nuget.pkg.github.com/INOSOFT-GmbH/index.json" -Username INOSOFT-GmbH -Password %GITHUB_TOKEN% -StorePasswordInClearText 2>nul
    
    if %ERRORLEVEL% neq 0 (
        echo ?? Updating existing GitHub source...
        .\nuget.exe sources update -Name "github" -Source "https://nuget.pkg.github.com/INOSOFT-GmbH/index.json" -Username INOSOFT-GmbH -Password %GITHUB_TOKEN% -StorePasswordInClearText 2>nul
    )
    
    echo.
    echo ?? Uploading packages...
    for %%f in (bin\Release\*.nupkg) do (
        echo   ?? Uploading %%~nxf...
        .\nuget.exe push "%%f" -Source "github" -ApiKey %GITHUB_TOKEN% -SkipDuplicate
        if %ERRORLEVEL% equ 0 (
            echo   ? Successfully published %%~nxf
        ) else (
            echo   ??  Failed to publish %%~nxf (might already exist)
        )
        echo.
    )
    
    echo ? Publishing completed!
    echo ?? View packages at: https://github.com/INOSOFT-GmbH/visiwin-73-modernui-processcontrols/packages
    echo.
) else (
    :skip_publish
    echo.
    echo ?? Packages are ready in: bin\Release\
    echo ?? You can publish them later using:
    echo    nuget push bin\Release\*.nupkg -Source github -ApiKey YOUR_TOKEN
    echo.
)

echo ?? All done!
pause