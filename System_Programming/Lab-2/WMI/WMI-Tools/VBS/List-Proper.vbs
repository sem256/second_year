set w=GetObject("WinMgmts:")
set p=w.get("win32_process")
set t=p.properties_
for each o in t
  S=S & o.name & vbcrlf 
Next
Wscript.echo s