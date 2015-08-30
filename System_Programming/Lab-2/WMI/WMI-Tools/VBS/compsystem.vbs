dim system(2)

system(0)="10.25.2.7"
system(1)="10.25.2.8"

for i=0 to ubound(system)-1
 set s=getobject("winmgmts://" & system(i)).instancesof("win32_computersystem")
 for each t in s
  u=u & t.name & " has " & t.totalphysicalmemory & " bytes " & vbcrlf
 next
next
wscript.echo u