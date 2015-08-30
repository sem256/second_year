set w=getobject("winmgmts://lima")
set c=w.get("win32_networkadapterconfiguration.index=0")
i=array("10.25.2.7")
s=array("255.255.255.0")
r=c.enablestatic(i,s)
msgbox "OK"
