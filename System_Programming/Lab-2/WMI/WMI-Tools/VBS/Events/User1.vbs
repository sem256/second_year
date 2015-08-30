set w=getobject("winmgmts:")
set e=w.execnotificationquery("select * from __instancecreationevent within 10 where targetinstance isa 'win32_useraccount'")
set ae=e.nextevent