set w=getobject("winmgmts:")
set l=w.execquery("select name, processid from win32_service where name='alerter'")
for each o in l
 msgbox o.name & o.processid
next

