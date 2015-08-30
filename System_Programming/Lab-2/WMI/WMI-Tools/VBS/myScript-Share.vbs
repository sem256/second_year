set W=GetObject("WinMgmts:").instancesOf("win32_share")
For each o in W
 S=S & o.name & vbcrlf
Next
Wscript.echo "Shares:" & vbcrlf & "--------------------------" & vbcrlf & S