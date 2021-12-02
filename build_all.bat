@echo off

:: Get the Flax Engine source repo
if exist FlaxEngine\ (
  echo Updating Flax Engine...
  cd FlaxEngine
  git fetch
  cd ..
) else (
  echo Downloading Flax Engine...
  git version
  git clone https://github.com/FlaxEngine/FlaxEngine.git FlaxEngine
)
cd FlaxEngine

:: Go the revision specified in the config file
set /p Commit=<commit.txt
git lfs version
echo Checking out commit %Commit%...
git reset --hard %Commit%
if %errorlevel% neq 0 exit /b %errorlevel%
git lfs pull
if %errorlevel% neq 0 exit /b %errorlevel%

:: Build C# for metadata
echo Building Flax Editor...
call "Development\Scripts\Windows\CallBuildTool.bat" -log -arch=x64 -configuration=Development -platform=Windows -buildTargets=FlaxEditor -build -BuildBindingsOnly
if %errorlevel% neq 0 exit /b %errorlevel%
cd ..

echo Preparing C# API metadata...
docfx\docfx.exe metadata
if %errorlevel% neq 0 exit /b %errorlevel%

echo Preparing C++ API metadata...
code2yaml\code2yaml.exe code2yaml.json
if %errorlevel% neq 0 exit /b %errorlevel%

echo Building site...
docfx\docfx.exe build
xcopy /Y favicon.ico _site
xcopy /Y logo.svg _site
xcopy /Y logo.png _site

echo Done!
