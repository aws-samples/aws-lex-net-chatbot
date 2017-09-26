If ( [IntPtr]::Size * 8 -ne 64 ) {
    Start-Process -Wait -File "C:\Windows\System32\WindowsPowerShell\v1.0\PowerShell.exe" -ArgumentList "$MyInvocation.MyCommand.Path"
} Else {
    $ErrorActionPreference = "Stop"
    Get-Module -ListAvailable > C:\temp\powershell.logs
    Import-Module -Name ServerManager >> C:\temp\powershell.logs
    Install-WindowsFeature Web-Server >> C:\temp\powershell.logs
    echo "Finished ps1 install" >> C:\temp\powershell.logs
}
