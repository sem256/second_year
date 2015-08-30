set c=getobject("winmgmts:win32_logicaldisk.deviceid='c:'")
f=c.freespace
wscript.echo "The free space on C: is "& f
