Set w=GetObject("winmgmts:\root\snmp\localhost")
set l=w.execquery("select * from SNMP_RFC1213_MIB_ipRouteTable")
for each o in l
 i=i & "Destination: " & o.ipRouteDest & " NextHop: " & o.ipRouteNextHop & " Route Mask: " & o.ipRouteMask & vbcrlf
Next
Wscript.echo i