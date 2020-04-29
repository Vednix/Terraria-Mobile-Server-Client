@echo off
setlocal enabledelayedexpansion

for /f "usebackq tokens=*" %%i in (`vswhere -latest -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe`) do (
  "%%i" src\TerrariaServer.sln /p:Configuration=Debug;Platform=x86
  exit /b !errorlevel!
)