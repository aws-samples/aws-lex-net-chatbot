%SystemRoot%\sysnative\WindowsPowerShell\v1.0\powershell.exe -File "%~dp0\before-install.ps1"
powershell.exe -Command "Invoke-WebRequest -Uri 'https://download.microsoft.com/download/D/0/2/D028801E-0802-43C8-9F9F-C7DB0A39B344/dotnet-win-x64.1.1.2.exe' -OutFile 'C:\Users\Administrator\Downloads\dotnet-install.exe'"
C:\Users\Administrator\Downloads\dotnet-install.exe /install /passive
powershell.exe -Command "Invoke-WebRequest -Uri 'https://go.microsoft.com/fwlink/?linkid=844461' -OutFile 'C:\Users\Administrator\Downloads\WindowsHostingBundle.exe'"
C:\Users\Administrator\Downloads\WindowsHostingBundle.exe /install /passive
