intR = MsgBox("�� ��� �� �� ������� ��������?", vbYesNoCancel + vbQuestion + vbDefaultButton2, _ 
"������� �� �������:")

Select Case intR 
Case vbYes 
	MsgBox "���������! �������� ���� �������!",vbInformation,"�����"
Case vbNo
	MsgBox "���� ������:((,"& VbCrLf &"���������� ���� �� �������� ��� ��������!", _
	 vbExclamation, "������"
Case vbCancel
	MsgBox "�� ��������� �� ���������! ���� �� �� ������ ���� ��������, ...", _
	 vbCritical, "�������� �� ���������"
End Select