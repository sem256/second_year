set w=getobject("winmgmts:")
set s=w.get("win32_share")
j=s.create("c:\mib-s","mibs",0)
msgbox "Share created",,"Information"
