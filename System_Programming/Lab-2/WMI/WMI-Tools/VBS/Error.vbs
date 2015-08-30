on error resume next
set w=getobject("winmgmts:")
set d=w.get("win32_logicaldisk.deviceid='c:'")
r=d.convert
wscript.echo err.number & vbcrlf & err.description & vbcrlf & err.source
