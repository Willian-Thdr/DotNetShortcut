@ echo off
echo Caminho %1
cd /d "%~1"
dotnet clean
dotnet build
pause