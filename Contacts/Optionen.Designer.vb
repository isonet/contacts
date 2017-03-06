<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Optionen
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.lbl_melden = New System.Windows.Forms.Label
        Me.lbl_startup = New System.Windows.Forms.Label
        Me.lbl_lang = New System.Windows.Forms.Label
        Me.cb_lang = New System.Windows.Forms.ComboBox
        Me.lbl_updates = New System.Windows.Forms.Label
        Me.cb_startup = New System.Windows.Forms.ComboBox
        Me.cb_melden = New System.Windows.Forms.ComboBox
        Me.cb_update = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Location = New System.Drawing.Point(12, 194)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 1
        Me.OK_Button.Text = "Speichern"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(85, 194)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 2
        Me.Cancel_Button.Text = "Abbrechen"
        '
        'lbl_melden
        '
        Me.lbl_melden.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_melden.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_melden.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_melden.Location = New System.Drawing.Point(12, 9)
        Me.lbl_melden.Name = "lbl_melden"
        Me.lbl_melden.Size = New System.Drawing.Size(423, 20)
        Me.lbl_melden.TabIndex = 4
        Me.lbl_melden.Text = "Wie viele Tage im Voraus sollen Geburtstage gemeldet werden?"
        Me.lbl_melden.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_startup
        '
        Me.lbl_startup.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_startup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_startup.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_startup.Location = New System.Drawing.Point(12, 56)
        Me.lbl_startup.Name = "lbl_startup"
        Me.lbl_startup.Size = New System.Drawing.Size(423, 20)
        Me.lbl_startup.TabIndex = 5
        Me.lbl_startup.Text = "Programm beim Windowsstart starten?"
        Me.lbl_startup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_lang
        '
        Me.lbl_lang.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_lang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_lang.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_lang.Location = New System.Drawing.Point(12, 103)
        Me.lbl_lang.Name = "lbl_lang"
        Me.lbl_lang.Size = New System.Drawing.Size(423, 20)
        Me.lbl_lang.TabIndex = 8
        Me.lbl_lang.Text = "Welche Sprache soll verwendet werden?"
        Me.lbl_lang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cb_lang
        '
        Me.cb_lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_lang.Items.AddRange(New Object() {"Deutsch", "Francais", "English"})
        Me.cb_lang.Location = New System.Drawing.Point(309, 126)
        Me.cb_lang.Name = "cb_lang"
        Me.cb_lang.Size = New System.Drawing.Size(126, 21)
        Me.cb_lang.TabIndex = 9
        '
        'lbl_updates
        '
        Me.lbl_updates.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lbl_updates.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_updates.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_updates.Location = New System.Drawing.Point(12, 150)
        Me.lbl_updates.Name = "lbl_updates"
        Me.lbl_updates.Size = New System.Drawing.Size(423, 20)
        Me.lbl_updates.TabIndex = 10
        Me.lbl_updates.Text = "Beim Start nach Updates suchen?"
        Me.lbl_updates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cb_startup
        '
        Me.cb_startup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_startup.Items.AddRange(New Object() {"Ja", "Nein"})
        Me.cb_startup.Location = New System.Drawing.Point(309, 79)
        Me.cb_startup.Name = "cb_startup"
        Me.cb_startup.Size = New System.Drawing.Size(126, 21)
        Me.cb_startup.TabIndex = 11
        '
        'cb_melden
        '
        Me.cb_melden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_melden.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cb_melden.Location = New System.Drawing.Point(309, 32)
        Me.cb_melden.Name = "cb_melden"
        Me.cb_melden.Size = New System.Drawing.Size(126, 21)
        Me.cb_melden.TabIndex = 12
        '
        'cb_update
        '
        Me.cb_update.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_update.Items.AddRange(New Object() {"Ja", "Nein"})
        Me.cb_update.Location = New System.Drawing.Point(309, 173)
        Me.cb_update.Name = "cb_update"
        Me.cb_update.Size = New System.Drawing.Size(126, 21)
        Me.cb_update.TabIndex = 13
        '
        'Optionen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 227)
        Me.Controls.Add(Me.cb_update)
        Me.Controls.Add(Me.cb_melden)
        Me.Controls.Add(Me.cb_startup)
        Me.Controls.Add(Me.lbl_updates)
        Me.Controls.Add(Me.cb_lang)
        Me.Controls.Add(Me.lbl_lang)
        Me.Controls.Add(Me.lbl_startup)
        Me.Controls.Add(Me.lbl_melden)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Optionen"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Optionen"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lbl_melden As System.Windows.Forms.Label
    Friend WithEvents lbl_startup As System.Windows.Forms.Label
    Friend WithEvents lbl_lang As System.Windows.Forms.Label
    Friend WithEvents cb_lang As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_updates As System.Windows.Forms.Label
    Friend WithEvents cb_startup As System.Windows.Forms.ComboBox
    Friend WithEvents cb_melden As System.Windows.Forms.ComboBox
    Friend WithEvents cb_update As System.Windows.Forms.ComboBox

End Class
