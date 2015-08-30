set w=getobject("winmgmts://lima")
set c=w.execquery("select * from win32_networkadapterconfiguration")
for each o in c
 if o.macaddress="00:50:FC:91:1D:30" then
  i=array("10.25.2.7")
  s=array("255.255.255.0")
  r=o.enablestatic(i,s)
 end if
next
msgbox "Errors ... " & r
