set w=getobject("winmgmts://lima")
set c=w.get("win32_product")
m=c.install("c:\vbs\swiadmle.msi")
wscript.echo "Done... " & m
