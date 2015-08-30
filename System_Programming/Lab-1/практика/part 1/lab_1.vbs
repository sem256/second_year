intR = MsgBox("Чи їли ви на сніданок морковку?", vbYesNoCancel + vbQuestion + vbDefaultButton2, _ 
"ПИТАННЯ НА ЗАСИПКУ:")

Select Case intR 
Case vbYes 
	MsgBox "Правильно! Морковка дуже корисна!",vbInformation,"Добре"
Case vbNo
	MsgBox "Дуже прикро:((,"& VbCrLf &"Наступного разу не забудьте про морковку!", _
	 vbExclamation, "Погано"
Case vbCancel
	MsgBox "Ви ухилились від запитання! Якщо ви не будете їсти морковку, ...", _
	 vbCritical, "Ухилення від запитання"
End Select