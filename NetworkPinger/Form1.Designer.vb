<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        dgvDevices = New DataGridView()
        Label1 = New Label()
        txtIpAddress = New TextBox()
        Label2 = New Label()
        txtDescription = New TextBox()
        btnAdd = New Button()
        btnUpdate = New Button()
        btnDelete = New Button()
        btnPing = New Button()
        lbResults = New ListBox()
        pbPing = New ProgressBar()
        Button1 = New Button()
        btnExportDb = New Button()
        btnImportDb = New Button()
        Label3 = New Label()
        GroupBox1 = New GroupBox()
        Button2 = New Button()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        CType(dgvDevices, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvDevices
        ' 
        dgvDevices.BackgroundColor = SystemColors.ButtonFace
        dgvDevices.BorderStyle = BorderStyle.Fixed3D
        dgvDevices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDevices.Location = New Point(0, 44)
        dgvDevices.Name = "dgvDevices"
        dgvDevices.RowHeadersWidth = 82
        dgvDevices.Size = New Size(705, 847)
        dgvDevices.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(87, 35)
        Label1.Name = "Label1"
        Label1.Size = New Size(140, 32)
        Label1.TabIndex = 1
        Label1.Text = "Direccion IP"
        ' 
        ' txtIpAddress
        ' 
        txtIpAddress.BackColor = SystemColors.ControlLightLight
        txtIpAddress.BorderStyle = BorderStyle.FixedSingle
        txtIpAddress.Location = New Point(13, 70)
        txtIpAddress.Name = "txtIpAddress"
        txtIpAddress.Size = New Size(305, 39)
        txtIpAddress.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.Control
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(29, 137)
        Label2.Name = "Label2"
        Label2.Size = New Size(270, 32)
        Label2.TabIndex = 3
        Label2.Text = "Descripcion o Ubicacion"
        ' 
        ' txtDescription
        ' 
        txtDescription.BackColor = SystemColors.ControlLightLight
        txtDescription.BorderStyle = BorderStyle.FixedSingle
        txtDescription.Location = New Point(13, 172)
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(305, 39)
        txtDescription.TabIndex = 4
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = SystemColors.ButtonHighlight
        btnAdd.BackgroundImageLayout = ImageLayout.Center
        btnAdd.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), Image)
        btnAdd.ImageAlign = ContentAlignment.MiddleRight
        btnAdd.Location = New Point(13, 248)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(305, 60)
        btnAdd.TabIndex = 5
        btnAdd.Text = "Agregar Equipo"
        btnAdd.TextAlign = ContentAlignment.MiddleLeft
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = SystemColors.ButtonHighlight
        btnUpdate.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), Image)
        btnUpdate.ImageAlign = ContentAlignment.MiddleRight
        btnUpdate.Location = New Point(13, 314)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(305, 82)
        btnUpdate.TabIndex = 6
        btnUpdate.Text = "Actualizar Datos"
        btnUpdate.TextAlign = ContentAlignment.MiddleLeft
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = SystemColors.ButtonHighlight
        btnDelete.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        btnDelete.ForeColor = SystemColors.ActiveCaptionText
        btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), Image)
        btnDelete.ImageAlign = ContentAlignment.MiddleRight
        btnDelete.Location = New Point(13, 402)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(305, 62)
        btnDelete.TabIndex = 7
        btnDelete.Text = "Eliminar Equipo"
        btnDelete.TextAlign = ContentAlignment.MiddleLeft
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnPing
        ' 
        btnPing.BackColor = SystemColors.ButtonHighlight
        btnPing.BackgroundImageLayout = ImageLayout.Center
        btnPing.Font = New Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPing.ForeColor = SystemColors.ActiveCaptionText
        btnPing.Image = CType(resources.GetObject("btnPing.Image"), Image)
        btnPing.Location = New Point(13, 470)
        btnPing.Name = "btnPing"
        btnPing.Size = New Size(305, 69)
        btnPing.TabIndex = 8
        btnPing.UseVisualStyleBackColor = False
        ' 
        ' lbResults
        ' 
        lbResults.BackColor = SystemColors.InfoText
        lbResults.ForeColor = Color.Lime
        lbResults.FormattingEnabled = True
        lbResults.HorizontalScrollbar = True
        lbResults.Location = New Point(1058, 44)
        lbResults.Name = "lbResults"
        lbResults.Size = New Size(840, 836)
        lbResults.TabIndex = 9
        ' 
        ' pbPing
        ' 
        pbPing.Dock = DockStyle.Bottom
        pbPing.Location = New Point(0, 894)
        pbPing.Name = "pbPing"
        pbPing.Size = New Size(1900, 46)
        pbPing.Style = ProgressBarStyle.Continuous
        pbPing.TabIndex = 10
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.ButtonHighlight
        Button1.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Button1.Image = CType(resources.GetObject("Button1.Image"), Image)
        Button1.ImageAlign = ContentAlignment.MiddleRight
        Button1.Location = New Point(0, 778)
        Button1.Name = "Button1"
        Button1.Size = New Size(341, 69)
        Button1.TabIndex = 12
        Button1.Text = "Acerca de..."
        Button1.UseVisualStyleBackColor = False
        ' 
        ' btnExportDb
        ' 
        btnExportDb.BackColor = SystemColors.ButtonHighlight
        btnExportDb.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnExportDb.Image = CType(resources.GetObject("btnExportDb.Image"), Image)
        btnExportDb.ImageAlign = ContentAlignment.MiddleRight
        btnExportDb.Location = New Point(13, 545)
        btnExportDb.Name = "btnExportDb"
        btnExportDb.Size = New Size(305, 68)
        btnExportDb.TabIndex = 13
        btnExportDb.Text = "Exportar DB"
        btnExportDb.TextAlign = ContentAlignment.MiddleLeft
        btnExportDb.UseVisualStyleBackColor = False
        ' 
        ' btnImportDb
        ' 
        btnImportDb.BackColor = SystemColors.ButtonHighlight
        btnImportDb.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnImportDb.Image = CType(resources.GetObject("btnImportDb.Image"), Image)
        btnImportDb.ImageAlign = ContentAlignment.MiddleRight
        btnImportDb.Location = New Point(13, 626)
        btnImportDb.Name = "btnImportDb"
        btnImportDb.Size = New Size(305, 68)
        btnImportDb.TabIndex = 14
        btnImportDb.Text = "Importar DB"
        btnImportDb.TextAlign = ContentAlignment.MiddleLeft
        btnImportDb.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.Lime
        Label3.Location = New Point(250, 9)
        Label3.Name = "Label3"
        Label3.Size = New Size(165, 32)
        Label3.TabIndex = 15
        Label3.Text = "Base de Datos"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = SystemColors.Control
        GroupBox1.Controls.Add(Button2)
        GroupBox1.Controls.Add(txtDescription)
        GroupBox1.Controls.Add(txtIpAddress)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(btnImportDb)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(btnExportDb)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(btnAdd)
        GroupBox1.Controls.Add(btnUpdate)
        GroupBox1.Controls.Add(btnDelete)
        GroupBox1.Controls.Add(btnPing)
        GroupBox1.Location = New Point(711, 44)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(341, 844)
        GroupBox1.TabIndex = 18
        GroupBox1.TabStop = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = SystemColors.ButtonHighlight
        Button2.Font = New Font("Segoe UI", 9F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        Button2.Image = CType(resources.GetObject("Button2.Image"), Image)
        Button2.ImageAlign = ContentAlignment.MiddleRight
        Button2.Location = New Point(0, 700)
        Button2.Name = "Button2"
        Button2.Size = New Size(341, 72)
        Button2.TabIndex = 15
        Button2.Text = "AYUDA"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.Lime
        Label4.Location = New Point(1670, -1)
        Label4.Name = "Label4"
        Label4.Size = New Size(185, 45)
        Label4.TabIndex = 19
        Label4.Text = "Version: 3.6"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.ForeColor = Color.Lime
        Label5.Location = New Point(763, 9)
        Label5.Name = "Label5"
        Label5.Size = New Size(220, 32)
        Label5.TabIndex = 20
        Label5.Text = "Gestion de Equipos"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.Lime
        Label6.Location = New Point(1341, 12)
        Label6.Name = "Label6"
        Label6.Size = New Size(239, 32)
        Label6.TabIndex = 21
        Label6.Text = "Resultados del Ping"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaptionText
        ClientSize = New Size(1900, 940)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(GroupBox1)
        Controls.Add(Label3)
        Controls.Add(pbPing)
        Controls.Add(lbResults)
        Controls.Add(dgvDevices)
        HelpButton = True
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "Form1"
        Text = "Pingeador"
        CType(dgvDevices, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvDevices As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txtIpAddress As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnPing As Button
    Friend WithEvents lbResults As ListBox
    Friend WithEvents pbPing As ProgressBar
    Friend WithEvents Button1 As Button
    Friend WithEvents btnExportDb As Button
    Friend WithEvents btnImportDb As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label

End Class
