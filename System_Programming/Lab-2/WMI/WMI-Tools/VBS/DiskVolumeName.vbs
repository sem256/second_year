set w=getobject("winmgmts:")
set c=w.get("win32_logicaldisk.deviceid='d:'")
c.volumename="Good-disk"
c.put_
wscript.echo "OK"