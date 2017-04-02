@echo off

echo Building site...
docfx\docfx.exe build
xcopy /Y favicon.ico _site

echo Done!
