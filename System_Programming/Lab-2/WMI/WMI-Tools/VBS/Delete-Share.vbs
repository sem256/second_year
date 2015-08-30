set w=getobject("winmgmts:")
set s=w.get("win32_share.name='mibs'")
s.delete()
msgbox "Share deleted",,"Information"

