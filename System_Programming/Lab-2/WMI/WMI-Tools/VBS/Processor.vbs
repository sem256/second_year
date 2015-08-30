set w=getobject("winmgmts://lima")
set c=w.get("win32_processor.deviceid='cpu0'")
s=c.currentclockspeed
wscript.echo s
