@ECHO OFF

REM The following directory is for .NET 4.0
set DOTNETFX2=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319
set PATH=%PATH%;%DOTNETFX2%

echo Installing WindowsService...
echo ---------------------------------------------------
InstallUtil /user=user /password=password ERPXL_MultiService.exe
echo ---------------------------------------------------
echo Done.