set w=getobject("winmgmts:")
set s=w.get("win32_service.name='tlntsvr'")
e=s.stopservice()
If e=0 then 
 msgbox "OK",vbinformation,"Information"
 else msgbox "Error # " & e,vbcritical,"Error"
end if

