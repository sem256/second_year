set w=getobject("winmgmts://lima")
set c=w.get("win32_computersystem.name='lima'")
m=c.totalphysicalmemory
wscript.echo "The memory is "& m
