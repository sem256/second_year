set w=getobject("winmgmts:")
set c=w.get("win32_process")
p=c.create("calc.exe",null,null,pid)
wscript.echo pid