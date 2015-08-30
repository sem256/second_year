set w=getobject("winmgmts:")
set l=w.execquery("select * from win32_logicaldisk")
for each o in l
 i=i & o.name & vbcrlf
next
msgbox i