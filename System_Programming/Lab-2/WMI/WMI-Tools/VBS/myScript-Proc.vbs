For each p in GetObject("WinMgmts:").instancesOf("win32_process")
 S=S & p.name & vbcrlf
Next
Wscript.echo "Processes" & vbcrlf & "--------------------------" & vbcrlf & S