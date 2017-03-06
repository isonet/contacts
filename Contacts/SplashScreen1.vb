Public NotInheritable Class SplashScreen1

    'TODO: Dieses Formular kann einfach als Begrüßungsbildschirm für die Anwendung festgelegt werden, indem Sie zur Registerkarte "Anwendung"
    '  des Projekt-Designers wechseln (Menü "Projekt", Option "Eigenschaften").


    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Richten Sie den Dialogtext zur Laufzeit gemäß den Assemblyinformationen der Anwendung ein.  

        'TODO: Passen Sie die Assemblyinformationen der Anwendung im Bereich "Anwendung" des Dialogfelds für die 
        '  Projekteigenschaften (im Menü "Projekt") an.

        'Anwendungstitel
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            'Wenn der Anwendungstitel fehlt, Anwendungsnamen ohne Erweiterung verwenden
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Verwenden Sie zum Formatieren der Versionsinformationen den Text, der zur Entwurfszeit in der Versionskontrolle festgelegt wurde, als
        '  Formatierungszeichenfolge. Dies ermöglicht ggf. eine effektive Lokalisierung.
        '  Build- und Revisionsinformationen können durch Verwendung des folgenden Codes und durch Ändern 
        '  des Entwurfszeittexts der Versionskontrolle in "Version {0}.{1:00}.{2}.{3}" oder einen ähnlichen Text eingeschlossen werden. Weitere Informationen erhalten Sie unter
        '  String.Format() in der Hilfe.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        Version.Text = "1." + Form1.version.ToString 'System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Copyrightinformationen
        Copyright.Text = My.Application.Info.Copyright
    End Sub

    Private Sub tmr_close_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_close.Tick
        tmr_close.Stop()
        'tmr_hide.Enabled = True
        tmr_hide.Start()
    End Sub

    Private Sub tmr_load_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_load.Tick
        If Me.Opacity = 1 Then

            tmr_load.Stop()
            'tmr_close.Enabled = True
            tmr_close.Start()
            Exit Sub

        End If

        Me.Opacity = Me.Opacity + 0.01
    End Sub

    Private Sub tmr_hide_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_hide.Tick
        If Me.Opacity = 0 Then

            tmr_hide.Stop()
            tmr_closing.Start()
            Exit Sub

        End If

        Me.Opacity = Me.Opacity - 0.01
    End Sub

    Private Sub tmr_closing_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr_closing.Tick
        Me.Close()
    End Sub
End Class
