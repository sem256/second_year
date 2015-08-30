set w=getobject("winmgmts:")
set s=w.get("win32_share")
set i=s.methods_("create").inparameters.spawninstance_()
i.properties_.item("access")=20
i.properties_.item("description")="Good share"
i.properties_.item("name")="MIBs"
i.properties_.item("path")="c:\mib-s"
i.properties_.item("type")=0
set o=s.execmethod_("create",i)
msgbox "Share created",,"Information"


