@echo off

echo Building site...
docfx\docfx.exe build
xcopy /Y favicon.ico _site
xcopy /Y logo.svg _site
xcopy /Y logo.png _site

echo Done!
