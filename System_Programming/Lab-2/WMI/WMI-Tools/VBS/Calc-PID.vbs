'Возвращение названия процесса с PID-ом 1532
'
set c=getobject("winmgmts:win32_process.handle=1532")
f=c.description
wscript.echo "The free space on C: is "& f
