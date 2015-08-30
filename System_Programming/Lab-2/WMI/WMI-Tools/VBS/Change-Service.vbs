set w=getobject("winmgmts:")
set s=w.get("win32_service.name='tlntsvr'")
x="manual"
e=s.changestartmode(x)
msgbox "The mode of service " & s.name & _
" is changed to " & x,vbinformation,"Information"
