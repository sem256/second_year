set W=getobject("winmgmts:").instancesof("__win32provider")
for each o in W
 r = r & o.name & vbcrlf
next
wscript.echo r