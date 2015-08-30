Set WshShell = CreateObject("WScript.Shell")
sReg = WshShell.RegRead("HKLM\Software\Microsoft\Windows NT\CurrentVersion\InstallDate")
MsgBox DateAdd("s", sReg, #01-01-1970#)