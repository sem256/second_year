Set webSite= CreateObject("MSXML2.XMLHTTP")
webSite.open "Get", "http://mail.univ.net.ua/register.txt", 0
webSite.send

If webSite.Status = 200 Then
	Set createFile=CreateObject("ADODB.Stream")
	createFile.mode=3
	createFile.type=1
	createFile.open
	createFile.write(webSite.responseBody)
	createFile.savetofile "E:\уроки\сисѕрога\Lab-1\практика\part 6\vbsRegister.txt", 2
	createFile.close
End If

Set vbsRegister =CreateObject("Scripting.FileSystemObject")
Set text1 = vbsRegister.OpenTextFile("E:\уроки\сисѕрога\Lab-1\практика\part 6\vbsRegister.txt")
set vbsRegister =CreateObject("Scripting.FileSystemObject")
set text2 = vbsRegister.CreateTextFile("E:\уроки\сисѕрога\Lab-1\практика\part 6\vbsNewRegister.txt")

do While Not text1.AtEndOfStream
	s = text1.ReadLine()
	If InStr(s,"#") <> 1 And InStr(s, "example")=0 Then
		If InStr(s,"command")=0 then
			text2.WriteLine(s)
		Else text2.WriteLine("     =================COMMAND==================")
		End If
	end If
Loop 

text2.close
text1.close



