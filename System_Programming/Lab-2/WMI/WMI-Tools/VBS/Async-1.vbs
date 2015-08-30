set w=getobject("winmgmts:")
set m=wscript.createobject("wbemscripting.swbemsink","sink_")
e=w.instancesofasync(m,"win32_process")

sub ss(o,c)
 wscript.echo (o.name)
end sub

sub sc(r,e,c)
 wscript.echo "Done"
end sub

