nowDate = Now
diff = DateDiff("d","23-03-2015",nowDate)

pi = 4 * Atn(1)
'MsgBox(pi)
x = CCur(pi * diff /182.5)
y = Ccur(Sin(x))

If y >= 0 Then
	y = y * 50 + 50
Else 
	y = (1 + y) * 50
End If

MsgBox"Поточна дата: " & nowDate  &VbCrLf& "Тривалість дня у відсотках: " & y & "%",,"Результат"