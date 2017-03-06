'Import von Win32 für den Registry Zugriff
Imports Microsoft.Win32

Public Class Form1

    'String-Array mit allen Daten und mit nur den bevorstehenden
    Private lst_gebi(2000) As String, lst_gebi_comming(2000) As String

    'Globale Variablen
    Public gebi_melden As Integer = 3, start_at_system As Boolean = False, lang As String = "de", update_search_start As Boolean = True
    Public version As Double = 2, path As String = ""

    'Einstellungen in Registry schreiben wenn noch nicht vorhanden
    Public Function write_config()
        Try
            Dim regKey As RegistryKey
            regKey = Registry.CurrentUser.OpenSubKey("Software", True)
            regKey.CreateSubKey("Paul Biester")
            regKey = Nothing
            regKey = Registry.CurrentUser.OpenSubKey("Software\Paul Biester", True)
            regKey.CreateSubKey("GeburtstagsProgramm")
            regKey = Nothing
            regKey = Registry.CurrentUser.OpenSubKey("Software\Paul Biester\GeburtstagsProgramm", True)
            regKey.SetValue("melden", gebi_melden)
            regKey.SetValue("update_search_start", update_search_start.ToString)
            regKey = Nothing
            regKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)

            If start_at_system Then
                regKey.SetValue("GeburtstagsProgramm", path + "GeburtstagsProgramm.exe /boot")
            Else
                Try
                    regKey.DeleteValue("GeburtstagsProgramm")
                Catch ex As Exception
                End Try
            End If

            regKey.Close()
        Catch ex2 As Exception
            MsgBox("Fehler N°: " + Err.Number.ToString + vbCrLf + "Fehlerbeschreibung: " + ex2.Message + vbCrLf + vbCrLf + "Lösung: Deinstallieren Sie das Programm und installieren Sie es erneut.", MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, "Fehler N°: " + Err.Number.ToString)
        End Try

        Return True
    End Function

    'Einstelungen aus der Registry auslesen
    Private Function read_config(Optional ByVal load As Boolean = False)
        Dim regKey As RegistryKey
        Try

            regKey = Registry.CurrentUser.OpenSubKey("Software\Paul Biester\GeburtstagsProgramm", False)
            path = regKey.GetValue("path")
            gebi_melden = regKey.GetValue("melden")
            lang = ChangeLanguage(regKey.GetValue("lang", "de"))

            If regKey.GetValue("update_search_start", "True") = "False" Then
                update_search_start = False
            Else
                update_search_start = True
            End If

            regKey = Nothing
            regKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", False)
            If regKey.GetValue("GeburtstagsProgramm", "") = path + "GeburtstagsProgramm.exe /boot" Then
                start_at_system = True
            Else
                start_at_system = False
            End If

            regKey.Close()

        Catch ex As Exception
            If load = False Then
                write_config()
            End If

        End Try

        Return True
    End Function

    'Load Sub des ganzen Projektes, wird als erstes aufgerufen
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        read_config(True)                   'Globale Variablen aktualisieren

        If Command.Trim = "/boot" Then  'Bei Kommandozeilenparameter ="/boot" versteckt starten
            Me.Visible = False
            Me.ShowInTaskbar = False
            ni_1.Visible = True

            read_gebi_txt("gebi.txt")   '
            load_gebi()                 '
            load_dates()                'Daten auslesen
            dgv_gebi.ClearSelection()   '
            tmr_comming_gebi.Start()    '

        Else                            'Beim normalen aufruf

            Me.Visible = False          '
            Me.ShowInTaskbar = False    'Nichts sichtbar
            ni_1.Visible = False        '

            read_gebi_txt("gebi.txt")   '
            load_gebi()                 '
            load_dates()                'Daten auslesen
            dgv_gebi.ClearSelection()   '
            tmr_comming_gebi.Start()    '

            SplashScreen1.TopMost = True 'Andere Fenster überlagern
            SplashScreen1.ShowDialog()  'Splashscreen anzeigen und warten bis dieser geschlossen wird
            SplashScreen1.TopMost = False
            Me.Visible = True           '
            Me.ShowInTaskbar = True     'Form1 anzeigen
            ni_1.Visible = True         '
            Me.Show()                   '

        End If

        ni_1.BalloonTipIcon = ToolTipIcon.Info                  '
        ni_1.BalloonTipText = ss_status.Text                    'Geburtstage in nächster Zeit als PopUp anzeigen
        ni_1.BalloonTipTitle = "Geburtstage in nächster Zeit:"  '
        ni_1.ShowBalloonTip(1)                                  '

        '...
        Dim regKey As RegistryKey                                                                       '
        regKey = Registry.CurrentUser.OpenSubKey("Software\Paul Biester\GeburtstagsProgramm", False)    '
        Dim read_key As String = regKey.GetValue("firsttime")                                           '
        If read_key = "1" Then                                                                          'Überprüfen ob die Anwendung zum ersten Mal gestartet wird,
            Optionen.ShowDialog()                                                                       'wenn ja Optionen-Dialog anzeigen
            regKey = Nothing                                                                            '
            regKey = Registry.CurrentUser.OpenSubKey("Software\Paul Biester\GeburtstagsProgramm", True) '
            regKey.SetValue("firsttime", "0")                                                           '
        End If
        regKey.Close()
        '...

        '...
        If update_search_start = True Then                       'Nach Updates suchen wenn update_search_start=true
            tmr_update_search_start.Start()                      'Zum verzögerten Start wird zuerst ein timer gestartet
        End If
        '...

    End Sub

    'Programm beenden beim Klick auf MenuStrip_Beenden
    Private Sub ms_Beenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ms_Beenden.Click
        Me.Form1_FormClosing(Nothing, Nothing, False)
    End Sub

    'Markieren der Fettgedruckten Tage im Kalender
    Private Function load_gebi()

        'Einen Standard-Wert festlegen
        If lst_gebi(0) = "" Then
            lst_gebi(0) = "12.03.1993;Max Mustermann;Geschenk;"
        End If
        '...

        Dim current_gebi As Array, str_cut As String = "", current_year As Integer

        For i = 0 To UBound(lst_gebi)
            If lst_gebi(i) = "" Then
                Exit For
            End If
            current_gebi = Nothing
            current_year = Nothing
            str_cut = ""

            current_gebi = Split(lst_gebi(i), ";")
            str_cut = current_gebi(0).ToString.Substring(0, 5)
            mc_gebi.AddAnnuallyBoldedDate(str_cut)
        Next

        Return True
    End Function

    'Angezeigte Elemente aktualisieren beim Datumswechsel
    Private Sub mc_gebi_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mc_gebi.DateChanged
        load_dates() 'Daten aktualisieren
        dgv_gebi.ClearSelection()

        '<Einfügen der Daten zum ausgewählten Tag in die 2. Tabelle>
        dgv_gebi_selected.Rows.Clear()
        For j = 0 To UBound(lst_gebi)
            If lst_gebi(j) = "" Then
                Exit For
            End If
            Dim current_gebi As Array

            current_gebi = Split(lst_gebi(j), ";")

            If current_gebi(0).ToString.Substring(0, 5) = mc_gebi.SelectionRange.Start.ToString.Substring(0, 5) Then
                Dim n As Integer = dgv_gebi_selected.Rows.Add()
                dgv_gebi_selected.Rows.Item(n).Cells(0).Value = current_gebi(1)
                dgv_gebi_selected.Rows.Item(n).Cells(1).Value = current_gebi(2)
                dgv_gebi_selected.Rows.Item(n).Cells(2).Value = current_gebi(0)
            End If

        Next
        dgv_gebi_selected.ClearSelection()
        '</Einfügen der Daten zum ausgewählten Tag in die 2. Tabelle>

        '<Anklicken der passenden Daten in der Tabelle zum ausgewählten Tag>
        For i = 0 To UBound(mc_gebi.AnnuallyBoldedDates)

            If mc_gebi.AnnuallyBoldedDates(i).ToString.Substring(0, 5) = mc_gebi.SelectionRange.Start.ToString.Substring(0, 5) Then
                For j = 0 To dgv_gebi.Rows.Count - 2

                    If dgv_gebi.Rows.Item(j).Cells(2).Value.ToString.Substring(0, 5) = mc_gebi.AnnuallyBoldedDates(i).ToString.Substring(0, 5) Then
                        dgv_gebi.Rows.Item(j).Selected = True
                    End If
                Next
            End If
        Next
        '</Anklicken der passenden Daten in der Tabelle zum ausgewählten Tag>

    End Sub

    'Auslesen der Textdatei und Einlesen in den Array
    Private Function read_gebi_txt(ByVal path As String)
        If System.IO.File.Exists(path) Then
            Dim txt_content As String = "", txt_array(2000) As String
            txt_content = FileIO.FileSystem.ReadAllText(path)
            txt_array = Split(txt_content, vbCrLf)
            lst_gebi = txt_array
        End If
        Return True
    End Function

    'Textdatei schreiben mit Inghalt des lst_gebi Arrays
    Private Function write_gebi_txt(ByVal path As String)
        Dim txt_content As String = ""
        For i = 0 To UBound(lst_gebi)
            If lst_gebi(i) = "" Then
                Exit For
            End If
            txt_content += lst_gebi(i).ToString + vbCrLf
        Next
        Try
            FileIO.FileSystem.WriteAllText(path, txt_content, False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return True
    End Function

    'Datum-Sprung beim Datum direkt eingabe werkzeug
    Private Sub DateTimePicker1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtp_gebi.KeyPress
        mc_gebi.SetDate(dtp_gebi.Value)
    End Sub

    'Datum-Sprung beim Datum direkt eingabe werkzeug
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_gebi.ValueChanged
        mc_gebi.SetDate(dtp_gebi.Value)
    End Sub

    'Endgültiges Speichern aller vorgenommen Änderungen in die Textdatei
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Dim current_lst_gebi(0 To dgv_gebi.Rows.Count - 2) As String
        For i = 0 To dgv_gebi.Rows.Count - 2
            If IsDate(dgv_gebi.Rows.Item(i).Cells(2).Value) And dgv_gebi.Rows.Item(i).Cells(2).Value.ToString.Length = 10 Then
                mc_gebi.AddAnnuallyBoldedDate(dgv_gebi.Rows.Item(i).Cells(2).Value)
                current_lst_gebi(i) = ""

                current_lst_gebi(i) = dgv_gebi.Rows.Item(i).Cells(2).Value.ToString.Replace(";", "") + ";" + dgv_gebi.Rows.Item(i).Cells(0).Value.ToString.Replace(";", "") + ";" + dgv_gebi.Rows.Item(i).Cells(1).Value.ToString.Replace(";", "")
            Else
                MsgBox("Fehler:" + vbCrLf + "Bitte geben Sie anstatt von " + dgv_gebi.Rows.Item(i).Cells(2).Value + " ein Datum im Format dd.mm.yyyy ein.", MsgBoxStyle.Critical, "Fehler")
                dgv_gebi.ClearSelection()
                dgv_gebi.Rows.Item(i).Cells(2).Selected = True
            End If
        Next
        lst_gebi = Nothing
        lst_gebi = current_lst_gebi
        write_gebi_txt("gebi.txt")
    End Sub

    'Füllen der Tabelle N°1
    Private Function load_dates()
        dtp_gebi.Value = mc_gebi.SelectionRange.Start
        dgv_gebi.Rows.Clear()

        For j = 0 To UBound(lst_gebi)
            If lst_gebi(j) = "" Then
                Exit For
            End If
            Dim current_gebi As Array

            current_gebi = Split(lst_gebi(j), ";")
            Dim n As Integer = dgv_gebi.Rows.Add()
            dgv_gebi.Rows.Item(n).Cells(0).Value = current_gebi(1)
            dgv_gebi.Rows.Item(n).Cells(1).Value = current_gebi(2)
            dgv_gebi.Rows.Item(n).Cells(2).Value = current_gebi(0)

        Next

        Return True
    End Function

    'Funktion zum Vcard importieren
    Private Function vcard_read(ByVal path)
        Try
            Dim txt_content As String = "", txt_array(2000) As String, read_gebi As String = "", read_name As String = "", read_date As String = ""
            txt_content = FileIO.FileSystem.ReadAllText(path)
            txt_array = Split(txt_content, vbLf)

            For i = 0 To UBound(txt_array)
                If txt_array(i).Length >= 5 Then
                    If txt_array(i).Substring(0, 5) = "BDAY:" Then
                        read_date = txt_array(i).Substring(0, 13).Substring(11) & "." & txt_array(i).Substring(0, 11).Substring(9) & "." & txt_array(i).Substring(0, 9).Substring(5)
                    End If
                End If
                If txt_array(i).Length >= 2 Then
                    If txt_array(i).Substring(0, 2) = "N:" Then
                        read_name += txt_array(i).Substring(txt_array(i).IndexOf(";")).Replace(";", " ") & " " & txt_array(i).Substring(0, txt_array(i).IndexOf(";")).Substring(2).Replace(";", " ")
                    End If
                End If
            Next
            read_gebi = read_date.Trim + ";" + read_name.Trim
            Return read_gebi
        Catch ex2 As Exception
            MsgBox("Fehler N°: " + Err.Number.ToString + vbCrLf + "Fehlerbeschreibung: " + ex2.Message, MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, "Fehler N°: " + Err.Number.ToString)
            Return False
        End Try


    End Function

    'Aufruf Funktion zum Importieren von Vcards
    Private Sub ms_Importieren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ms_Importieren.Click
        Try
            Dim readed As String = "", path As String = "", dialog As New OpenFileDialog, current_gebi(1) As String
            dialog.AddExtension = True
            dialog.AutoUpgradeEnabled = True
            dialog.CheckFileExists = True
            dialog.CheckPathExists = True
            dialog.InitialDirectory = "C:\"
            dialog.Multiselect = False
            dialog.ReadOnlyChecked = True
            dialog.ShowReadOnly = True
            dialog.Title = "Vcards Importieren"
            dialog.ValidateNames = True
            dialog.Filter = "Vcard (*.vcf)|*.vcf"
            dialog.ShowDialog()
            path = dialog.FileName
            If (System.IO.File.Exists(path)) Then
                'File exists und weitere properities
                readed = vcard_read(path)

                If readed = False Then
                    Exit Sub
                End If
                current_gebi = Split(readed, ";")
                Dim n As Integer = dgv_gebi.Rows.Add()
                dgv_gebi.Rows.Item(n).Cells(0).Value = current_gebi(1)
                dgv_gebi.Rows.Item(n).Cells(2).Value = current_gebi(0)
                Dim current_lst_gebi(0 To dgv_gebi.Rows.Count - 1) As String
                For i = 0 To dgv_gebi.Rows.Count - 1
                    mc_gebi.AddAnnuallyBoldedDate(dgv_gebi.Rows.Item(i).Cells(2).Value)
                    current_lst_gebi(i) = ""
                    current_lst_gebi(i) = dgv_gebi.Rows.Item(i).Cells(2).Value + ";" + dgv_gebi.Rows.Item(i).Cells(0).Value + ";" + dgv_gebi.Rows.Item(i).Cells(1).Value
                Next
                lst_gebi = Nothing
                lst_gebi = current_lst_gebi
                write_gebi_txt("gebi.txt")
            Else
                MsgBox("Die Datei wurde nicht gefunden!", MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, "Datei nicht gefunden")
            End If
        Catch ex2 As Exception
            MsgBox("Fehler N°: " + Err.Number.ToString + vbCrLf + "Fehlerbeschreibung: " + ex2.Message + vbCrLf + vbCrLf + "Lösung: Wählen Sie eine Datei aus die dem Vcards-Format konform ist.", MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, "Fehler N°: " + Err.Number.ToString)
        End Try

    End Sub

    'Passendes Datum zu den Daten in Tabelle N°1 auswählen
    Private Sub dgv_gebi_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_gebi.CellClick
        On Error Resume Next
        mc_gebi.SelectionStart = dgv_gebi.Rows.Item(e.RowIndex).Cells(2).Value.ToString.Substring(0, 6) + DateTime.Now.Year.ToString
    End Sub

    'Optionen Dialog anzeigen
    Private Sub OptionenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ms_Optionen.Click
        ni_1.ContextMenuStrip = Nothing
        Optionen.ShowDialog()
        ni_1.ContextMenuStrip = cms_ni
    End Sub

    'Funktion zum erstellen des lst_gebi_comming arrays
    Private Function gebi_comming()

        Dim x As Date, daysinyear As Integer, dayofyear As Integer, lst_gebi_string As String = ""

        If Date.IsLeapYear(Now.Year) = True Then
            daysinyear = 366
        Else
            daysinyear = 365
        End If

        For j = 0 To UBound(lst_gebi)
            dayofyear = Nothing
            If lst_gebi(j) = "" Then
                Exit For
            End If
            Dim current_gebi As Array

            current_gebi = Split(lst_gebi(j), ";")

            x = current_gebi(0).ToString.Substring(0, 6) + Now.Year.ToString
            If (Now.DayOfYear + 30) > daysinyear And x.DayOfYear < gebi_melden Then
                dayofyear = (Now.DayOfYear + gebi_melden) - daysinyear
            Else
                dayofyear = (Now.DayOfYear + gebi_melden)
            End If

            If (x.DayOfYear <= dayofyear) And (x.DayOfYear >= dayofyear - gebi_melden) Then
                lst_gebi_string = lst_gebi_string + current_gebi(0) + ";" + current_gebi(1) + ";" + current_gebi(2) + ";" + "|"

            End If

        Next
        lst_gebi_comming = Split(lst_gebi_string, "|")

        Return True
    End Function

    'Aktualisieren der Statusleiste
    Private Sub tmr_comming_gebi_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_comming_gebi.Tick
        gebi_comming()
        Dim z As Array
        If lst_gebi_comming(0) = "" Then

            'Localization
            If lang = "de" Then
                ss_status.Text = "Niemand hat in nächster Zeit Geburtstag"
            ElseIf lang = "fr" Then
                ss_status.Text = "Aucun anniversaire aura lieu dans le prochain temps"
            ElseIf lang = "en" Then
                ss_status.Text = "In the near future are the birthdays of nobody"
            End If
            '...

        ElseIf UBound(lst_gebi_comming) - 1 = 0 Then
            z = lst_gebi_comming(0).Split(";")

            'Localization
            If lang = "de" Then
                ss_status.Text = "In nächster Zeit hat " + z(1) + " Geburtstag"
            ElseIf lang = "fr" Then
                ss_status.Text = "Dans le prochain temps c'est l'anniversaire de " + z(1) + " qui aurat lieu"
            ElseIf lang = "en" Then
                ss_status.Text = "In the near future is the birthday of" + z(1)
            End If
            '...

        Else

            'Localization
            If lang = "de" Then
                ss_status.Text = "In nächster Zeit haben " + UBound(lst_gebi_comming).ToString + " Personen Geburtstag"
            ElseIf lang = "fr" Then
                ss_status.Text = "Dans le prochain temps il y a " + UBound(lst_gebi_comming).ToString + " anniversaires"
            ElseIf lang = "en" Then
                ss_status.Text = "In the near future are the birthdays of " + UBound(lst_gebi_comming).ToString + " persons"
            End If
            '...

        End If
    End Sub

    'Beenden Button des Taskleistensymbols
    Private Sub cms_ni_Beenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cms_ni_Beenden.Click
        If Optionen.Visible = True Then
            Optionen.Activate()
        Else
            Me.Form1_FormClosing(Nothing, Nothing, False)
        End If
    End Sub

    'Show/Hide Funktion des Taskleistensymbols
    Private Sub cms_ni_ShowHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cms_ni_ShowHide.Click
        If Optionen.Visible = True Then
            Optionen.Activate()
        Else
            If Me.Visible = False Then
                Me.Visible = True
                Me.Show()
            Else
                Me.Hide()
                Me.Visible = False
                Me.WindowState = FormWindowState.Normal
            End If
        End If
    End Sub

    'Ein kleiner Sub zum sichern des Aufrufes des Optionen-Dialoges
    Private Sub ni_1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ni_1.Click
        If Optionen.Visible = True Then
            Optionen.Activate()
        End If
    End Sub

    'Show/Hide Funktion des Taskleistensymbols
    Private Sub ni_1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ni_1.MouseClick
        If Optionen.Visible = True Then
            Optionen.Activate()
        Else
            If e.Button = Windows.Forms.MouseButtons.Left Then
                If Me.Visible = False Then
                    Me.Visible = True
                    Me.Show()
                    Me.WindowState = FormWindowState.Normal
                Else
                    Me.Hide()
                    Me.Visible = False
                    Me.WindowState = FormWindowState.Normal
                End If
            End If
        End If
    End Sub

    'Totes Taskleistensymbol vor Beenden verstecken und minimieren des Programms
    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs, Optional ByVal minimize As Boolean = True) Handles MyBase.FormClosing
        If minimize = True Then
            If Me.Visible = False Then
                Me.Visible = True
                Me.Show()
            Else
                Me.Hide()
                Me.Visible = False
                Me.WindowState = FormWindowState.Normal
            End If
            e.Cancel = True
        Else
            ni_1.Visible = False
            End
        End If

    End Sub

    'Nach Updates Prüfen
    Private Sub ms_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ms_Update.Click
        Dim uri As New Uri("http://geburtstag.kilu.de/current.html")
        wc_update.DownloadStringAsync(uri)
        ss_pb_update.Visible = True
    End Sub

    'Informieren des Users und starten des Update Programms
    Private Sub wc_update_DownloadStringCompleted(ByVal sender As Object, ByVal e As System.Net.DownloadStringCompletedEventArgs) Handles wc_update.DownloadStringCompleted
        Dim result As Double = e.Result.Substring(0, e.Result.IndexOf(";"))
        ss_pb_update.Visible = False
        If result > version Then
            Dim x As MsgBoxResult

            'Localization
            If lang = "de" Then
                x = MsgBox("Es ist eine neue Version dieses Programms vorhanden." + vbCrLf + "Möchten Sie diese jetzt installieren?" + vbCrLf, MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1 + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxSetForeground + MsgBoxStyle.YesNo, "Update")
            ElseIf lang = "fr" Then
                x = MsgBox("Il existe une mise à jour pour ce programme." + vbCrLf + "Voulez vous l'installer maitenant?" + vbCrLf, MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1 + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxSetForeground + MsgBoxStyle.YesNo, "Mise à jour")
            ElseIf lang = "en" Then
                x = MsgBox("There is an update avaible for this program." + vbCrLf + "Do you want to install it now?" + vbCrLf, MsgBoxStyle.ApplicationModal + MsgBoxStyle.DefaultButton1 + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxSetForeground + MsgBoxStyle.YesNo, "Update")
            End If
            '...

            If x = MsgBoxResult.Yes Then
                ni_1.Visible = False
                Try
                    Diagnostics.Process.Start("update.exe")
                Catch ex As Exception

                    'Localization
                    If lang = "de" Then
                        MsgBox("Fehler N°: " + Err.Number.ToString + vbCrLf + "Fehlerbeschreibung: " + ex.Message + vbCrLf + vbCrLf + "Lösung: Deinstallieren Sie das Programm und installieren Sie es erneut.", MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, "Fehler N°: " + Err.Number.ToString)
                    ElseIf lang = "fr" Then
                        MsgBox("Numero d'erreur: " + Err.Number.ToString + vbCrLf + "Description d'erreur: " + ex.Message + vbCrLf + vbCrLf + "Solution: Deinstallez le programme et reinstallez le.", MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, "Numero d'erreur: " + Err.Number.ToString)
                    ElseIf lang = "en" Then
                        MsgBox("Errornumber: " + Err.Number.ToString + vbCrLf + "Errordescription: " + ex.Message + vbCrLf + vbCrLf + "Solution: Uninstall the program and reinstall it.", MsgBoxStyle.Critical + MsgBoxStyle.SystemModal, "Errornumber: " + Err.Number.ToString)
                    End If
                    '...

                    ni_1.Visible = False
                    End
                End Try

            End If
        Else

            'Localization
            If lang = "de" Then
                MsgBox("Es ist keine neue Version dieses Programms vorhanden." + vbCrLf, MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxSetForeground + MsgBoxStyle.OkOnly, "Update")
            ElseIf lang = "fr" Then
                MsgBox("Il n'existe pas de mise à jour pour ce programme." + vbCrLf, MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxSetForeground + MsgBoxStyle.OkOnly, "Mise à jour")
            ElseIf lang = "en" Then
                MsgBox("No update avaible." + vbCrLf, MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information + MsgBoxStyle.MsgBoxSetForeground + MsgBoxStyle.OkOnly, "Update")
            End If
            '...

        End If
    End Sub

    'Rückgängig Button
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_discard.Click
        load_gebi()
        load_dates()
        dgv_gebi.ClearSelection()
    End Sub

    'Zur deutschen Sprache wechseln
    Private Sub ms_Deutsch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ms_Deutsch.Click
        lang = ChangeLanguage("de")
    End Sub

    'Zur französischen Sprache wechseln
    Private Sub ms_French_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ms_French.Click
        lang = ChangeLanguage("fr")
    End Sub

    'Zur englischen Sprache wechseln
    Private Sub ms_English_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ms_English.Click
        lang = ChangeLanguage("en")
    End Sub

    'Function zum ändern von Form1.Language
    Public Function ChangeLanguage(ByVal lang As String)
        If lang = "en" Then

            'Englisch Lokalisieren

            'Lokalisieren der Buttons
            btn_save.Text = "Save changes"
            btn_discard.Text = "Discard changes"

            'Lokalisieren der Labels
            lbl_all.Text = "All Birthdays"
            lbl_selected.Text = "Selected Birthdays"

            'Lokalisieren von MenüStrip
            ms_about.Text = "About"
            ms_Anzeige.Text = "Sprache/ Langue/ Language"
            ms_Beenden.Text = "Close"
            ms_Datei.Text = "File"
            ms_Importieren.Text = "Import Vcards"
            ms_Optionen.Text = "Options"
            ms_Update.Text = "Search for updates"

            'Lokalisieren von DataGridView_all
            dgv_Geschenk.HeaderText = "Present"
            dgv_Datum.HeaderText = "Date"
            dgv_name.HeaderText = "Name"

            'Lokalisieren von DataGridView_selected
            dgv_gebi_selected_Geschenk.HeaderText = "Present"
            dgv_gebi_selected_Datum.HeaderText = "Date"
            dgv_gebi_selected_Name.HeaderText = "Name"

            'Lokalisieren von ContextMenuStrip_Ni_1
            cms_ni_Beenden.Text = "Close"
            cms_ni_ShowHide.Text = "Show/Hide"

            'Lokalisieren von Me.Text
            Me.Text = "Birthday Programm"

        ElseIf lang = "fr" Then

            'Französisch Lokalisieren

            'Lokalisieren der Buttons
            btn_save.Text = "Enregistrer les modifications"
            btn_discard.Text = "Anuller les modifications"

            'Lokalisieren der Labels
            lbl_all.Text = "Tout les anniversaires"
            lbl_selected.Text = "Tout les anniversaires selectionné"

            'Lokalisieren von MenüStrip
            ms_about.Text = "A propos de..."
            ms_Anzeige.Text = "Sprache/ Langue/ Language"
            ms_Beenden.Text = "Quitter"
            ms_Datei.Text = "Fichier"
            ms_Importieren.Text = "Importer des Vcards"
            ms_Optionen.Text = "Parametrès"
            ms_Update.Text = "Vérifier les mises a jours..."

            'Lokalisieren von DataGridView_all
            dgv_Geschenk.HeaderText = "Cadeau"
            dgv_Datum.HeaderText = "Date"
            dgv_name.HeaderText = "Nom"

            'Lokalisieren von DataGridView_selected
            dgv_gebi_selected_Geschenk.HeaderText = "Cadeau"
            dgv_gebi_selected_Datum.HeaderText = "Date"
            dgv_gebi_selected_Name.HeaderText = "Nom"

            'Lokalisieren von ContextMenuStrip_Ni_1
            cms_ni_Beenden.Text = "Quitter"
            cms_ni_ShowHide.Text = "Montrer/Cacher"

            'Lokalisieren von Me.Text
            Me.Text = "Programme d'Anniversaire"

        Else

            'Deutsch Lokalisieren

            'Lokalisieren der Buttons
            btn_save.Text = "Änderungen Speichern"
            btn_discard.Text = "Änderungen Verwerfen"

            'Lokalisieren der Labels
            lbl_all.Text = "Alle Geburtstage"
            lbl_selected.Text = "Ausgewählte Geburtstage"

            'Lokalisieren von MenüStrip
            ms_about.Text = "Über"
            ms_Anzeige.Text = "Sprache/ Langue/ Language"
            ms_Beenden.Text = "Beenden"
            ms_Datei.Text = "Datei"
            ms_Importieren.Text = "Importieren von Vcards"
            ms_Optionen.Text = "Optionen"
            ms_Update.Text = "Nach Updates suchen"

            'Lokalisieren von DataGridView_all
            dgv_Geschenk.HeaderText = "Geschenk"
            dgv_Datum.HeaderText = "Datum"
            dgv_name.HeaderText = "Name"

            'Lokalisieren von DataGridView_selected
            dgv_gebi_selected_Geschenk.HeaderText = "Geschenk"
            dgv_gebi_selected_Datum.HeaderText = "Datum"
            dgv_gebi_selected_Name.HeaderText = "Name"

            'Lokalisieren von ContextMenuStrip_Ni_1
            cms_ni_Beenden.Text = "Beenden"
            cms_ni_ShowHide.Text = "Zeigen/Verstecken"

            'Lokalisieren von Me.Text
            Me.Text = "Geburtstagsprogramm"

        End If

        'Änderungen in der Registry speichern
        Dim regKey As RegistryKey
        regKey = Registry.CurrentUser.OpenSubKey("Software\Paul Biester\GeburtstagsProgramm", True)
        regKey.SetValue("lang", lang)
        regKey.Close()
        '...

        Return lang
    End Function

    'Timer zum verzögerten starten der Suche nach Updates
    Private Sub tmr_update_search_start_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_update_search_start.Tick
        Dim uri As New Uri("http://geburtstag.kilu.de/current.html")
        wc_update.DownloadStringAsync(uri)
        ss_pb_update.Visible = True
        tmr_update_search_start.Stop()
    End Sub

End Class
