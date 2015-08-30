set w=getobject("winmgmts:")
set l=w.get("win32_logicaldisk.deviceid='C:'")
v=l.properties_.item("freespace").value
t=l.properties_.item("freespace").type
s=l.properties_.item("freespace").name
v=v & " bytes free on disk " & l.deviceid
msgbox v, , "Free Space"
msgbox t & " " & s