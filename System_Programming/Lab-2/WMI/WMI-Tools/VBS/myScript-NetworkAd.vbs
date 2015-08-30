set w=getobject("WinMgmts:")
set f=w.instancesof("win32_networkadapter")
for each o in f
 s=s & o.name & vbcrlf
Next
Wscript.echo "NetAdapters:" & vbcrlf & "--------------------------" & vbcrlf & s