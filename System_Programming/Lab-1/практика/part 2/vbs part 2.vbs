	MyGrowth = InputBox("���Ĳ�� ��� �в�� � �����������", "�������� ������", 185)
	
	If MyGrowth = "" Then
		 WScript.Quit
	End If
	Do Until IsNumeric(MyGrowth)
		MyGrowth = InputBox("���Ĳ�� ��� �в�� � �����������", "�������� ������", 185)
	Loop
	If MyGrowth < 0 Then
		 MyGrowth = MyGrowth * -1
	End If


	MyWeight = InputBox("���Ĳ�� ���� ���� � ʲ��������", "�������� ����", 80)
	
	If MyWeight = "" Then
		 WScript.Quit
	End If
	Do Until IsNumeric(MyWeight)
		MyWeight = InputBox("���Ĳ�� ���� ���� � ʲ��������", "�������� ����", 80)
	Loop
	If MyWeight < 0 Then
		 MyWeight = MyWeight * -1
	End If

	Set WshShell = CreateObject("WScript.Shell")		
	Result = WshShell.Popup("������ ����������, ������� ���������...", 10, "������ ����������", 0)
	
	If Result = -1 Then
		Answer = MyGrowth/MyWeight
		If Answer > 1.8 And Answer < 4  Then
			Result = WshShell.Popup("� ��� ��������� ������, ��� �������!", 15, "��������� ����������", 0) 
		End If 
		If Answer < 1.8 Then
			Result = WshShell.Popup("� ��� ������� ����, ���������� �������!", 15, "��������� ����������", 0)
		End If 
		If Answer > 4 Then
			Result = WshShell.Popup("� ��� ���������, ����� ����!", 15, "��������� ����������", 0)
		End If
	Else
		Result = WshShell.Popup("���������� ��������� ������������", 5, "", 0)
	End If