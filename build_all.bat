@echo off

call update_api.bat

echo Preparing API metadata...
docfx\docfx.exe metadata

echo Building site...
docfx\docfx.exe build
xcopy /Y favicon.ico _site

echo Done!