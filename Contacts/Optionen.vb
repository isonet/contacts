
'Zum Aufruf von Form1
Imports System.Windows.Forms

Public Class Optionen

    'Daten Speichern
    Private Sub OK_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If cb_startup.SelectedIndex = 0 Then
            Form1.start_at_system = True
        ElseIf cb_startup.SelectedIndex = 1 Then
            Form1.start_at_system = False
        End If
        Form1.gebi_melden = cb_melden.SelectedIndex + 1

        If cb_update.SelectedIndex = 0 Then
            Form1.update_search_start = True
        Else
            Form1.update_search_start = False
        End If

        Form1.write_config()

        If cb_lang.SelectedIndex = 2 Then
            Form1.lang = Form1.ChangeLanguage("en")
        ElseIf cb_lang.SelectedIndex = 1 Then
            Form1.lang = Form1.ChangeLanguage("fr")
        Else
            Form1.lang = Form1.ChangeLanguage("de")
        End If

        Me.Close()
    End Sub

    'Aktualisieren der Daten auf der Form
    Private Sub Optionen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Form1.start_at_system Then
            cb_startup.SelectedIndex = 0
        ElseIf Form1.start_at_system = False Then
            cb_startup.SelectedIndex = 1
        End If
        cb_melden.SelectedIndex = Form1.gebi_melden - 1

        If Form1.lang = "en" Then
            cb_lang.SelectedIndex = 2
        ElseIf Form1.lang = "fr" Then
            cb_lang.SelectedIndex = 1
        Else
            cb_lang.SelectedIndex = 0
        End If

        If Form1.update_search_start = True Then
            cb_update.SelectedIndex = 0
        Else
            cb_update.SelectedIndex = 1
        End If
    End Sub

End Class
