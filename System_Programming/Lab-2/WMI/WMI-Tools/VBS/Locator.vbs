set l=createobject("wbemscripting.swbemlocator")
set s=l.connectserver()
set c=s.get("win32_logicaldisk.deviceid='c:'")
f=c.freespace
wscript.echo "The free space on C: is "& f