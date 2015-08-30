Set f=CreateObject("scripting.filesystemobject")
If f.folderExists(dir&"E:\уроки\сисПрога\Lab-1\практика\part 7\KI_vbs")Then 
	'MsgBox("yes")
Else
	'MsgBox("no")
	f.CreateFolder("E:\уроки\сисПрога\Lab-1\практика\part 7\KI_vbs")
End If
Set c=f.opentextfile("E:\уроки\сисПрога\Lab-1\практика\part 7\KI_vbs\Anninkov.Log",8,true)
c.writeline(now & " Комп'ютер успішно завантажено")
c.close