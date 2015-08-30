set w=getobject("winmgmts:")
set l=w.execquery _
("select * from win32_ntlogevent where logfile='Application'",,48)
for each o in l
 i=i+1
next
msgbox i