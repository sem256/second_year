Dim emailObj, emailConfig, oShell
Set emailObj = CreateObject("CDO.Message")
Set objArgs = WScript.Arguments
Set oShell = WScript.CreateObject("WScript.Shell")
If InStr(WScript.Arguments(0),"@") = 0 then 
	MsgBox "Введіть E-mail і тему повідомлення через пробіл"
else
	If objArgs.Count = 2 Then

		emailObj.From     = "motia256@gmail.com"
		emailObj.To       = WScript.Arguments(0)
		emailObj.Subject  = WScript.Arguments(1)
		emailObj.TextBody = Now&" Александр Матвієнко"
		
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
		
		MsgBox "Повідомлення відправлено"
	Else
		MsgBox "Введіть E-mail і тему повідомлення через пробіл"
	End If
end if
