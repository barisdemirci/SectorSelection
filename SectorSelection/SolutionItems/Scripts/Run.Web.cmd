@echo off
set PROJPATH=%~dp0\..\..\src
cd %PROJPATH%\FrontEndLayer\SectorSelection.Web
start "WebAPI - http://localhost:5000/" dotnet run
exit
