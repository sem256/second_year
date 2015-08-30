For each obj in GetObject("WinMgmts:").instancesOf("win32_process")
 S=S & obj.name & vbcrlf
Next
Wscript.echo "Processes" & vbcrlf & "--------------------------" & vbcrlf & S