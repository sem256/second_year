set w=getobject("WinMgmts:")
set f=w.instancesof("win32_networkadapterconfiguration")
for each o in f
 s=s & o.caption & vbcrlf
Next
Wscript.echo "NetInterface:" & vbcrlf & "---------------" & vbcrlf & s