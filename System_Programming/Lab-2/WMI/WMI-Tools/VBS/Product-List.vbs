set w=getobject("winmgmts:")
set p=w.execquery("select * from win32_product")
if p.count<>0 then
 for each o in p
  m=m & o.name & vbcrlf
 next
 msgbox m,vbinformation,"Program List"
 else msgbox "There are no products"
end if 
