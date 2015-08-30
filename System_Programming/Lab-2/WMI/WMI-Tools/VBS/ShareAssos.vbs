set w=getobject("winmgmts:")
set s=w.execquery("associators of {win32_share.name='Diamond'}")
for each o in s
 i=i & o.path_.relpath & vbcrlf
next 
msgbox i