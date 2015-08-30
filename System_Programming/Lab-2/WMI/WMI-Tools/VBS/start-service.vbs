set w=getobject("winmgmts:")
set s=w.get("win32_service.name='tlntsvr'")
e=s.startservice()
if e=0 then 
 msgbox "OK",vbinformation,"Information"
 else msgbox "Error: " & e,vbcritical,"Information"
end if
