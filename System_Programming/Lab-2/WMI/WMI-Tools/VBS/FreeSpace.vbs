set W = getobject("winmgmts://10.25.2.7")
set L=W.get("win32_logicaldisk.deviceid='d:'")
s=L.freespace
wscript.echo "Free space on disk C:" & s