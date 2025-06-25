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
        Panel1 = New Panel()
        Button1 = New Button()
        btnExportDb = New Button()
        btnImportDb = New Button()
        CType(dgvDevices, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvDevices
        ' 
        dgvDevices.BackgroundColor = SystemColors.ButtonFace
        dgvDevices.BorderStyle = BorderStyle.Fixed3D
        dgvDevices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvDevices.Dock = DockStyle.Top
        dgvDevices.Location = New Point(0, 0)
        dgvDevices.Name = "dgvDevices"
        dgvDevices.RowHeadersWidth = 82
        dgvDevices.Size = New Size(705, 285)
        dgvDevices.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = Color.Lime
        Label1.Location = New Point(3, 120)
        Label1.Name = "Label1"
        Label1.Size = New Size(140, 32)
        Label1.TabIndex = 1
        Label1.Text = "Direccion IP"
        ' 
        ' txtIpAddress
        ' 
        txtIpAddress.Location = New Point(3, 155)
        txtIpAddress.Name = "txtIpAddress"
        txtIpAddress.Size = New Size(305, 39)
        txtIpAddress.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.ForeColor = Color.Lime
        Label2.Location = New Point(3, 17)
        Label2.Name = "Label2"
        Label2.Size = New Size(270, 32)
        Label2.TabIndex = 3
        Label2.Text = "Descripcion o Ubicacion"
        ' 
        ' txtDescription
        ' 
        txtDescription.Location = New Point(3, 52)
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(305, 39)
        txtDescription.TabIndex = 4
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(364, 430)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(298, 62)
        btnAdd.TabIndex = 5
        btnAdd.Text = "Agregar Equipo"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(364, 362)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(298, 62)
        btnUpdate.TabIndex = 6
        btnUpdate.Text = "Actualizar Equipo"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(364, 295)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(298, 62)
        btnDelete.TabIndex = 7
        btnDelete.Text = "Eliminar Equipo"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnPing
        ' 
        btnPing.BackColor = SystemColors.ActiveCaption
        btnPing.Location = New Point(12, 501)
        btnPing.Name = "btnPing"
        btnPing.Size = New Size(321, 69)
        btnPing.TabIndex = 8
        btnPing.Text = "Iniciar Ping"
        btnPing.UseVisualStyleBackColor = False
        ' 
        ' lbResults
        ' 
        lbResults.BackColor = SystemColors.InfoText
        lbResults.ForeColor = Color.Lime
        lbResults.FormattingEnabled = True
        lbResults.HorizontalScrollbar = True
        lbResults.Location = New Point(0, 670)
        lbResults.Name = "lbResults"
        lbResults.Size = New Size(705, 228)
        lbResults.TabIndex = 9
        lbResults.UseWaitCursor = True
        ' 
        ' pbPing
        ' 
        pbPing.Dock = DockStyle.Bottom
        pbPing.Location = New Point(0, 894)
        pbPing.Name = "pbPing"
        pbPing.Size = New Size(705, 46)
        pbPing.TabIndex = 10
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(txtDescription)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(txtIpAddress)
        Panel1.Location = New Point(12, 291)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(321, 204)
        Panel1.TabIndex = 11
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(364, 501)
        Button1.Name = "Button1"
        Button1.Size = New Size(298, 69)
        Button1.TabIndex = 12
        Button1.Text = "Acerca de..."
        Button1.UseVisualStyleBackColor = True
        ' 
        ' btnExportDb
        ' 
        btnExportDb.Location = New Point(15, 598)
        btnExportDb.Name = "btnExportDb"
        btnExportDb.Size = New Size(318, 46)
        btnExportDb.TabIndex = 13
        btnExportDb.Text = "Exportar DB"
        btnExportDb.UseVisualStyleBackColor = True
        ' 
        ' btnImportDb
        ' 
        btnImportDb.Location = New Point(364, 600)
        btnImportDb.Name = "btnImportDb"
        btnImportDb.Size = New Size(298, 44)
        btnImportDb.TabIndex = 14
        btnImportDb.Text = "Importar DB"
        btnImportDb.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaptionText
        ClientSize = New Size(705, 940)
        Controls.Add(btnImportDb)
        Controls.Add(btnExportDb)
        Controls.Add(Button1)
        Controls.Add(Panel1)
        Controls.Add(pbPing)
        Controls.Add(lbResults)
        Controls.Add(btnPing)
        Controls.Add(btnDelete)
        Controls.Add(btnUpdate)
        Controls.Add(btnAdd)
        Controls.Add(dgvDevices)
        HelpButton = True
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "Form1"
        Text = "Pingeador"
        CType(dgvDevices, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
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
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents btnExportDb As Button
    Friend WithEvents btnImportDb As Button

End Class
