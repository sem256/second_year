Set read = CreateObject("Scripting.FileSystemObject")

Set load = CreateObject("MSXML2.XMLHTTP.3.0")
load.Open "GET", "http://ce.univ.kiev.ua", False
load.Send

If read.FileExists("E:\уроки\сисѕрога\Lab-1\практика\part_5\vbs_ce.html")Then 
	read.DeleteFile("E:\уроки\сисѕрога\Lab-1\практика\part_5\vbs_ce.html")
End If 

If load.Status = 200 Then
   Set file = CreateObject("ADODB.Stream")
   file.Open
   file.Type = 1
   file.Write(load.responseBody)
   file.SaveToFile("E:\уроки\сисѕрога\Lab-1\практика\part_5\vbs_ce.html") 
   file.Close
End If

lines = 0
Set count = read.OpenTextFile("E:\уроки\сисѕрога\Lab-1\практика\part_5\vbs_ce.html",1)
Do While count.AtEndOfStream <> True
   count.Readline
   lines = lines + 1
Loop
count.Close

URL = "file:///E:\уроки\сисѕрога\Lab-1\практика\part_5\vbs_ce.html"

Set objShell = CreateObject("Shell.Application")
objShell.ShellExecute "chrome.exe", URL, "", "", 1

Wscript.Echo lines
