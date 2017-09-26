icacls "C:\Users\Administrator\aspnetlexchatbot" /grant "IIS AppPool\DefaultAppPool":(OI)(CI)RX
SET appcmd=CALL %WINDIR%\system32\inetsrv\appcmd.exe
%appcmd% list site /name:"Default Web Site"
IF "%ERRORLEVEL%" EQU "0" (
    %appcmd% delete site "Default Web Site"
    %appcmd% add site /name:Chatbot /bindings:http://*:80 /physicalpath:"C:\Users\Administrator\aspnetlexchatbot"
)
