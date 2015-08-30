set w=getobject("winmgmts:")
set l=w.execquery("select ipaddress from win32_networkadapterconfiguration where ipenabled=true")
for each o in l
if not isnull(o.ipaddress) then 
 for i=lbound(o.ipaddress) to ubound(o.ipaddress)
  msgbox o.ipaddress(i)
 next
end if
next