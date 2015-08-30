set w=getobject("winmgmts:")
set c=w.get ("win32_process.handle=1532")
f=c.description
wscript.echo "The free space on C: is "& f
