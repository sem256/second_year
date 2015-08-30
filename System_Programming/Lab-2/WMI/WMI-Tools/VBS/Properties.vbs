set w=getobject("winmgmts:")
set l=w.get("win32_logicaldisk.deviceid='C:'")
v=l.freespace
v=v & " bytes free on disk " & l.deviceid
msgbox v, , "Free Space"