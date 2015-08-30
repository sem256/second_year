	MyGrowth = InputBox("ббед╡рэ бюь гп╡яр б яюмрхлерпюу", "ббедеммъ гпнярс", 185)
	
	If MyGrowth = "" Then
		 WScript.Quit
	End If
	Do Until IsNumeric(MyGrowth)
		MyGrowth = InputBox("ббед╡рэ бюь гп╡яр б яюмрхлерпюу", "ббедеммъ гпнярс", 185)
	Loop
	If MyGrowth < 0 Then
		 MyGrowth = MyGrowth * -1
	End If


	MyWeight = InputBox("ббед╡рэ бюьс бюцс б й╡кнцпюлюу", "ббедеммъ бюцх", 80)
	
	If MyWeight = "" Then
		 WScript.Quit
	End If
	Do Until IsNumeric(MyWeight)
		MyWeight = InputBox("ббед╡рэ бюьс бюцс б й╡кнцпюлюу", "ббедеммъ бюцх", 80)
	Loop
	If MyWeight < 0 Then
		 MyWeight = MyWeight * -1
	End If

	Set WshShell = CreateObject("WScript.Shell")		
	Result = WshShell.Popup("рпхбю╙ навхякеммъ, вейюире пегскэрюр...", 10, "рпхбю╙ навхякеммъ", 0)
	
	If Result = -1 Then
		Answer = MyGrowth/MyWeight
		If Answer > 1.8 And Answer < 4  Then
			Result = WshShell.Popup("с бЮЯ ЯОНПРХБМЮ ТЁЦСПЮ, РЮЙ РПХЛЮРХ!", 15, "пегскэрюр навхякеммъ", 0) 
		End If 
		If Answer < 1.8 Then
			Result = WshShell.Popup("с БЮЯ МЮДЛЁПМЮ БЮЦЮ, ГЮИЛЮИРЕЯЭ ЯОНПРНЛ!", 15, "пегскэрюр навхякеммъ", 0)
		End If 
		If Answer > 4 Then
			Result = WshShell.Popup("с БЮЯ ДХЯРПНТЁЪ, АЁКЭЬЕ ©ФРЕ!", 15, "пегскэрюр навхякеммъ", 0)
		End If
	Else
		Result = WshShell.Popup("навхякеммъ яйюянбюме йнпхярсбювел", 5, "", 0)
	End If