Dim emailObj, emailConfig, oShell
Set emailObj = CreateObject("CDO.Message")
Set objArgs = WScript.Arguments
Set oShell = WScript.CreateObject("WScript.Shell")
If InStr(WScript.Arguments(0),"@") = 0 then 
	MsgBox "������ E-mail � ���� ����������� ����� �����"
else
	If objArgs.Count = 2 Then

		emailObj.From     = "motia256@gmail.com"
		emailObj.To       = WScript.Arguments(0)
		emailObj.Subject  = WScript.Arguments(1)
		emailObj.TextBody = Now&" ��������� ���⳺���"
		
		Set emailConfig = emailObj.Configuration
		emailConfig.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserver")       = "smtp.gmail.com"
		emailConfig.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport")   = 465
		emailConfig.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing")        = 2
		emailConfig.Fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1
		emailConfig.Fields("http://schemas.microsoft.com/cdo/configuration/smtpusessl")       = true
		emailConfig.Fields("http://schemas.microsoft.com/cdo/configuration/sendusername")     = "motia256@gmail.com"
		emailConfig.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword")     = "mobssmobss"
		emailConfig.Fields.Update
		
		emailObj.Send
		
		MsgBox "����������� ����������"
	Else
		MsgBox "������ E-mail � ���� ����������� ����� �����"
	End If
end if
