Set f=CreateObject("scripting.filesystemobject")
If f.folderExists(dir&"E:\�����\��������\Lab-1\��������\part 7\KI_vbs")Then 
	'MsgBox("yes")
Else
	'MsgBox("no")
	f.CreateFolder("E:\�����\��������\Lab-1\��������\part 7\KI_vbs")
End If
Set c=f.opentextfile("E:\�����\��������\Lab-1\��������\part 7\KI_vbs\Anninkov.Log",8,true)
c.writeline(now & " ����'���� ������ �����������")
c.close