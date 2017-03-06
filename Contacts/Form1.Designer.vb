<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cms_1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ms_1 = New System.Windows.Forms.MenuStrip
        Me.ms_Datei = New System.Windows.Forms.ToolStripMenuItem
        Me.ms_Importieren = New System.Windows.Forms.ToolStripMenuItem
        Me.ms_Optionen = New System.Windows.Forms.ToolStripMenuItem
        Me.ms_Separator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ms_Beenden = New System.Windows.Forms.ToolStripMenuItem
        Me.ms_Anzeige = New System.Windows.Forms.ToolStripMenuItem
        Me.ms_Deutsch = New System.Windows.Forms.ToolStripMenuItem
        Me.ms_French = New System.Windows.Forms.ToolStripMenuItem
        Me.ms_English = New System.Windows.Forms.ToolStripMenuItem
        Me.ms_Help = New System.Windows.Forms.ToolStripMenuItem
        Me.ms_Update = New System.Windows.Forms.ToolStripMenuItem
        Me.ms_Separator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ms_about = New System.Windows.Forms.ToolStripMenuItem
        Me.mc_gebi = New System.Windows.Forms.MonthCalendar
        Me.dtp_gebi = New System.Windows.Forms.DateTimePicker
        Me.ss_bottom = New System.Windows.Forms.StatusStrip
        Me.ss_pb_update = New System.Windows.Forms.ToolStripProgressBar
        Me.ss_status = New System.Windows.Forms.ToolStripStatusLabel
        Me.dgv_gebi = New System.Windows.Forms.DataGridView
        Me.dgv_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgv_Geschenk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgv_Datum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btn_save = New System.Windows.Forms.Button
        Me.dgv_gebi_selected = New System.Windows.Forms.DataGridView
        Me.dgv_gebi_selected_Name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgv_gebi_selected_Geschenk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgv_gebi_selected_Datum = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lbl_all = New System.Windows.Forms.Label
        Me.lbl_selected = New System.Windows.Forms.Label
        Me.tmr_comming_gebi = New System.Windows.Forms.Timer(Me.components)
        Me.ni_1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cms_ni = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cms_ni_ShowHide = New System.Windows.Forms.ToolStripMenuItem
        Me.cms_ni_Separator1 = New System.Windows.Forms.ToolStripSeparator
        Me.cms_ni_Beenden = New System.Windows.Forms.ToolStripMenuItem
        Me.wc_update = New System.Net.WebClient
        Me.btn_discard = New System.Windows.Forms.Button
        Me.tmr_update_search_start = New System.Windows.Forms.Timer(Me.components)
        Me.ms_1.SuspendLayout()
        Me.ss_bottom.SuspendLayout()
        CType(Me.dgv_gebi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_gebi_selected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_ni.SuspendLayout()
        Me.SuspendLayout()
        '
        'cms_1
        '
        Me.cms_1.Name = "cms_1"
        resources.ApplyResources(Me.cms_1, "cms_1")
        '
        'ms_1
        '
        Me.ms_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_Datei, Me.ms_Anzeige, Me.ms_Help})
        resources.ApplyResources(Me.ms_1, "ms_1")
        Me.ms_1.Name = "ms_1"
        '
        'ms_Datei
        '
        Me.ms_Datei.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_Importieren, Me.ms_Optionen, Me.ms_Separator1, Me.ms_Beenden})
        Me.ms_Datei.Name = "ms_Datei"
        resources.ApplyResources(Me.ms_Datei, "ms_Datei")
        '
        'ms_Importieren
        '
        Me.ms_Importieren.Name = "ms_Importieren"
        resources.ApplyResources(Me.ms_Importieren, "ms_Importieren")
        '
        'ms_Optionen
        '
        Me.ms_Optionen.Name = "ms_Optionen"
        resources.ApplyResources(Me.ms_Optionen, "ms_Optionen")
        '
        'ms_Separator1
        '
        Me.ms_Separator1.Name = "ms_Separator1"
        resources.ApplyResources(Me.ms_Separator1, "ms_Separator1")
        '
        'ms_Beenden
        '
        Me.ms_Beenden.Name = "ms_Beenden"
        resources.ApplyResources(Me.ms_Beenden, "ms_Beenden")
        '
        'ms_Anzeige
        '
        Me.ms_Anzeige.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_Deutsch, Me.ms_French, Me.ms_English})
        Me.ms_Anzeige.Name = "ms_Anzeige"
        resources.ApplyResources(Me.ms_Anzeige, "ms_Anzeige")
        '
        'ms_Deutsch
        '
        Me.ms_Deutsch.Name = "ms_Deutsch"
        resources.ApplyResources(Me.ms_Deutsch, "ms_Deutsch")
        '
        'ms_French
        '
        Me.ms_French.Name = "ms_French"
        resources.ApplyResources(Me.ms_French, "ms_French")
        '
        'ms_English
        '
        Me.ms_English.Name = "ms_English"
        resources.ApplyResources(Me.ms_English, "ms_English")
        '
        'ms_Help
        '
        Me.ms_Help.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms_Update, Me.ms_Separator2, Me.ms_about})
        Me.ms_Help.Name = "ms_Help"
        resources.ApplyResources(Me.ms_Help, "ms_Help")
        '
        'ms_Update
        '
        Me.ms_Update.Name = "ms_Update"
        resources.ApplyResources(Me.ms_Update, "ms_Update")
        '
        'ms_Separator2
        '
        Me.ms_Separator2.Name = "ms_Separator2"
        resources.ApplyResources(Me.ms_Separator2, "ms_Separator2")
        '
        'ms_about
        '
        Me.ms_about.Name = "ms_about"
        resources.ApplyResources(Me.ms_about, "ms_about")
        '
        'mc_gebi
        '
        resources.ApplyResources(Me.mc_gebi, "mc_gebi")
        Me.mc_gebi.MaxSelectionCount = 1
        Me.mc_gebi.Name = "mc_gebi"
        '
        'dtp_gebi
        '
        resources.ApplyResources(Me.dtp_gebi, "dtp_gebi")
        Me.dtp_gebi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_gebi.Name = "dtp_gebi"
        Me.dtp_gebi.ShowUpDown = True
        '
        'ss_bottom
        '
        Me.ss_bottom.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ss_pb_update, Me.ss_status})
        resources.ApplyResources(Me.ss_bottom, "ss_bottom")
        Me.ss_bottom.Name = "ss_bottom"
        Me.ss_bottom.SizingGrip = False
        '
        'ss_pb_update
        '
        Me.ss_pb_update.MarqueeAnimationSpeed = 1
        Me.ss_pb_update.Name = "ss_pb_update"
        resources.ApplyResources(Me.ss_pb_update, "ss_pb_update")
        Me.ss_pb_update.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        '
        'ss_status
        '
        Me.ss_status.Name = "ss_status"
        resources.ApplyResources(Me.ss_status, "ss_status")
        Me.ss_status.Spring = True
        '
        'dgv_gebi
        '
        Me.dgv_gebi.AllowUserToOrderColumns = True
        Me.dgv_gebi.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgv_gebi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv_gebi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_gebi.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgv_name, Me.dgv_Geschenk, Me.dgv_Datum})
        resources.ApplyResources(Me.dgv_gebi, "dgv_gebi")
        Me.dgv_gebi.Name = "dgv_gebi"
        '
        'dgv_name
        '
        resources.ApplyResources(Me.dgv_name, "dgv_name")
        Me.dgv_name.Name = "dgv_name"
        '
        'dgv_Geschenk
        '
        resources.ApplyResources(Me.dgv_Geschenk, "dgv_Geschenk")
        Me.dgv_Geschenk.Name = "dgv_Geschenk"
        '
        'dgv_Datum
        '
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.dgv_Datum.DefaultCellStyle = DataGridViewCellStyle3
        resources.ApplyResources(Me.dgv_Datum, "dgv_Datum")
        Me.dgv_Datum.Name = "dgv_Datum"
        '
        'btn_save
        '
        resources.ApplyResources(Me.btn_save, "btn_save")
        Me.btn_save.Name = "btn_save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'dgv_gebi_selected
        '
        Me.dgv_gebi_selected.AllowUserToOrderColumns = True
        Me.dgv_gebi_selected.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgv_gebi_selected.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv_gebi_selected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_gebi_selected.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgv_gebi_selected_Name, Me.dgv_gebi_selected_Geschenk, Me.dgv_gebi_selected_Datum})
        resources.ApplyResources(Me.dgv_gebi_selected, "dgv_gebi_selected")
        Me.dgv_gebi_selected.Name = "dgv_gebi_selected"
        '
        'dgv_gebi_selected_Name
        '
        resources.ApplyResources(Me.dgv_gebi_selected_Name, "dgv_gebi_selected_Name")
        Me.dgv_gebi_selected_Name.Name = "dgv_gebi_selected_Name"
        '
        'dgv_gebi_selected_Geschenk
        '
        resources.ApplyResources(Me.dgv_gebi_selected_Geschenk, "dgv_gebi_selected_Geschenk")
        Me.dgv_gebi_selected_Geschenk.Name = "dgv_gebi_selected_Geschenk"
        '
        'dgv_gebi_selected_Datum
        '
        resources.ApplyResources(Me.dgv_gebi_selected_Datum, "dgv_gebi_selected_Datum")
        Me.dgv_gebi_selected_Datum.Name = "dgv_gebi_selected_Datum"
        '
        'lbl_all
        '
        resources.ApplyResources(Me.lbl_all, "lbl_all")
        Me.lbl_all.Name = "lbl_all"
        '
        'lbl_selected
        '
        resources.ApplyResources(Me.lbl_selected, "lbl_selected")
        Me.lbl_selected.Name = "lbl_selected"
        '
        'tmr_comming_gebi
        '
        '
        'ni_1
        '
        Me.ni_1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ni_1.ContextMenuStrip = Me.cms_ni
        resources.ApplyResources(Me.ni_1, "ni_1")
        '
        'cms_ni
        '
        Me.cms_ni.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cms_ni_ShowHide, Me.cms_ni_Separator1, Me.cms_ni_Beenden})
        Me.cms_ni.Name = "cms_ni"
        resources.ApplyResources(Me.cms_ni, "cms_ni")
        '
        'cms_ni_ShowHide
        '
        Me.cms_ni_ShowHide.Name = "cms_ni_ShowHide"
        resources.ApplyResources(Me.cms_ni_ShowHide, "cms_ni_ShowHide")
        '
        'cms_ni_Separator1
        '
        Me.cms_ni_Separator1.Name = "cms_ni_Separator1"
        resources.ApplyResources(Me.cms_ni_Separator1, "cms_ni_Separator1")
        '
        'cms_ni_Beenden
        '
        Me.cms_ni_Beenden.Name = "cms_ni_Beenden"
        resources.ApplyResources(Me.cms_ni_Beenden, "cms_ni_Beenden")
        '
        'wc_update
        '
        Me.wc_update.BaseAddress = ""
        Me.wc_update.CachePolicy = Nothing
        Me.wc_update.Credentials = Nothing
        Me.wc_update.Encoding = CType(resources.GetObject("wc_update.Encoding"), System.Text.Encoding)
        Me.wc_update.Headers = CType(resources.GetObject("wc_update.Headers"), System.Net.WebHeaderCollection)
        Me.wc_update.QueryString = CType(resources.GetObject("wc_update.QueryString"), System.Collections.Specialized.NameValueCollection)
        Me.wc_update.UseDefaultCredentials = False
        '
        'btn_discard
        '
        resources.ApplyResources(Me.btn_discard, "btn_discard")
        Me.btn_discard.Name = "btn_discard"
        Me.btn_discard.UseVisualStyleBackColor = True
        '
        'tmr_update_search_start
        '
        Me.tmr_update_search_start.Interval = 2000
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ContextMenuStrip = Me.cms_1
        Me.Controls.Add(Me.btn_discard)
        Me.Controls.Add(Me.lbl_all)
        Me.Controls.Add(Me.dgv_gebi_selected)
        Me.Controls.Add(Me.lbl_selected)
        Me.Controls.Add(Me.ss_bottom)
        Me.Controls.Add(Me.dgv_gebi)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.ms_1)
        Me.Controls.Add(Me.dtp_gebi)
        Me.Controls.Add(Me.mc_gebi)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.ms_1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.ms_1.ResumeLayout(False)
        Me.ms_1.PerformLayout()
        Me.ss_bottom.ResumeLayout(False)
        Me.ss_bottom.PerformLayout()
        CType(Me.dgv_gebi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_gebi_selected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_ni.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cms_1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ms_1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ms_Datei As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ms_Importieren As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ms_Separator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ms_Beenden As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ms_Anzeige As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ms_Help As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mc_gebi As System.Windows.Forms.MonthCalendar
    Friend WithEvents dtp_gebi As System.Windows.Forms.DateTimePicker
    Friend WithEvents ss_bottom As System.Windows.Forms.StatusStrip
    Friend WithEvents dgv_gebi As System.Windows.Forms.DataGridView
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents dgv_gebi_selected As System.Windows.Forms.DataGridView
    Friend WithEvents lbl_all As System.Windows.Forms.Label
    Friend WithEvents lbl_selected As System.Windows.Forms.Label
    Friend WithEvents ms_Optionen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ss_status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tmr_comming_gebi As System.Windows.Forms.Timer
    Friend WithEvents ni_1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents cms_ni As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cms_ni_ShowHide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cms_ni_Separator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cms_ni_Beenden As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ms_Update As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ms_Separator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ms_about As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents wc_update As System.Net.WebClient
    Friend WithEvents ss_pb_update As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents btn_discard As System.Windows.Forms.Button
    Friend WithEvents ms_Deutsch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ms_French As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ms_English As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgv_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgv_Geschenk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgv_Datum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgv_gebi_selected_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgv_gebi_selected_Geschenk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgv_gebi_selected_Datum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tmr_update_search_start As System.Windows.Forms.Timer

End Class
