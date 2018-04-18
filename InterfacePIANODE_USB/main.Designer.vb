<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.BtConnect = New System.Windows.Forms.Button()
        Me.Bt_disconnect = New System.Windows.Forms.Button()
        Me.CB_port = New System.Windows.Forms.ComboBox()
        Me.CB_baudrate = New System.Windows.Forms.ComboBox()
        Me.BT_raz = New System.Windows.Forms.Button()
        Me.TB_max_rate = New System.Windows.Forms.TextBox()
        Me.LB_max_rate = New System.Windows.Forms.Label()
        Me.LB_max_values = New System.Windows.Forms.Label()
        Me.TB_max_values = New System.Windows.Forms.TextBox()
        Me.BT_detect = New System.Windows.Forms.Button()
        Me.DGV_datas = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LB_baudrate = New System.Windows.Forms.Label()
        Me.LB_port = New System.Windows.Forms.Label()
        Me.GP_datas = New System.Windows.Forms.GroupBox()
        Me.TRB_rate = New System.Windows.Forms.TrackBar()
        Me.TRB_max_datas = New System.Windows.Forms.TrackBar()
        Me.PRB_nb_datas = New System.Windows.Forms.ProgressBar()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DonnéesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RAZToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AProposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PB_LogoPierron = New System.Windows.Forms.PictureBox()
        CType(Me.DGV_datas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GP_datas.SuspendLayout()
        CType(Me.TRB_rate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TRB_max_datas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_LogoPierron, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtConnect
        '
        Me.BtConnect.Location = New System.Drawing.Point(252, 21)
        Me.BtConnect.Name = "BtConnect"
        Me.BtConnect.Size = New System.Drawing.Size(75, 23)
        Me.BtConnect.TabIndex = 0
        Me.BtConnect.Text = "Connect"
        Me.BtConnect.UseVisualStyleBackColor = True
        '
        'Bt_disconnect
        '
        Me.Bt_disconnect.Enabled = False
        Me.Bt_disconnect.Location = New System.Drawing.Point(252, 48)
        Me.Bt_disconnect.Name = "Bt_disconnect"
        Me.Bt_disconnect.Size = New System.Drawing.Size(75, 23)
        Me.Bt_disconnect.TabIndex = 1
        Me.Bt_disconnect.Text = "Disconnect"
        Me.Bt_disconnect.UseVisualStyleBackColor = True
        '
        'CB_port
        '
        Me.CB_port.FormattingEnabled = True
        Me.CB_port.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10", "COM11", "COM12", "COM13", "COM14", "COM15"})
        Me.CB_port.Location = New System.Drawing.Point(74, 23)
        Me.CB_port.Name = "CB_port"
        Me.CB_port.Size = New System.Drawing.Size(79, 21)
        Me.CB_port.TabIndex = 2
        '
        'CB_baudrate
        '
        Me.CB_baudrate.FormattingEnabled = True
        Me.CB_baudrate.Items.AddRange(New Object() {"9600", "115200"})
        Me.CB_baudrate.Location = New System.Drawing.Point(74, 50)
        Me.CB_baudrate.Name = "CB_baudrate"
        Me.CB_baudrate.Size = New System.Drawing.Size(79, 21)
        Me.CB_baudrate.TabIndex = 3
        Me.CB_baudrate.Text = "115200"
        '
        'BT_raz
        '
        Me.BT_raz.Location = New System.Drawing.Point(278, 26)
        Me.BT_raz.Name = "BT_raz"
        Me.BT_raz.Size = New System.Drawing.Size(75, 23)
        Me.BT_raz.TabIndex = 5
        Me.BT_raz.Text = "RAZ"
        Me.BT_raz.UseVisualStyleBackColor = True
        '
        'TB_max_rate
        '
        Me.TB_max_rate.Location = New System.Drawing.Point(186, 55)
        Me.TB_max_rate.Name = "TB_max_rate"
        Me.TB_max_rate.Size = New System.Drawing.Size(45, 20)
        Me.TB_max_rate.TabIndex = 6
        Me.TB_max_rate.Text = "0"
        '
        'LB_max_rate
        '
        Me.LB_max_rate.AutoSize = True
        Me.LB_max_rate.Location = New System.Drawing.Point(6, 58)
        Me.LB_max_rate.Name = "LB_max_rate"
        Me.LB_max_rate.Size = New System.Drawing.Size(74, 13)
        Me.LB_max_rate.TabIndex = 7
        Me.LB_max_rate.Text = "sec. / donnée"
        '
        'LB_max_values
        '
        Me.LB_max_values.AutoSize = True
        Me.LB_max_values.Location = New System.Drawing.Point(9, 31)
        Me.LB_max_values.Name = "LB_max_values"
        Me.LB_max_values.Size = New System.Drawing.Size(61, 13)
        Me.LB_max_values.TabIndex = 9
        Me.LB_max_values.Text = "Max values"
        '
        'TB_max_values
        '
        Me.TB_max_values.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TB_max_values.Location = New System.Drawing.Point(186, 23)
        Me.TB_max_values.MaxLength = 6
        Me.TB_max_values.Name = "TB_max_values"
        Me.TB_max_values.Size = New System.Drawing.Size(45, 20)
        Me.TB_max_values.TabIndex = 8
        Me.TB_max_values.Text = "1000"
        '
        'BT_detect
        '
        Me.BT_detect.Location = New System.Drawing.Point(159, 23)
        Me.BT_detect.Name = "BT_detect"
        Me.BT_detect.Size = New System.Drawing.Size(57, 23)
        Me.BT_detect.TabIndex = 10
        Me.BT_detect.Text = "Detect"
        Me.BT_detect.UseVisualStyleBackColor = True
        '
        'DGV_datas
        '
        Me.DGV_datas.AccessibleDescription = "Données collectées"
        Me.DGV_datas.AccessibleName = "Données"
        Me.DGV_datas.AllowUserToAddRows = False
        Me.DGV_datas.AllowUserToOrderColumns = True
        Me.DGV_datas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_datas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGV_datas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGV_datas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_datas.Location = New System.Drawing.Point(17, 221)
        Me.DGV_datas.MinimumSize = New System.Drawing.Size(700, 0)
        Me.DGV_datas.Name = "DGV_datas"
        Me.DGV_datas.ReadOnly = True
        Me.DGV_datas.Size = New System.Drawing.Size(733, 328)
        Me.DGV_datas.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LB_baudrate)
        Me.GroupBox1.Controls.Add(Me.LB_port)
        Me.GroupBox1.Controls.Add(Me.CB_port)
        Me.GroupBox1.Controls.Add(Me.CB_baudrate)
        Me.GroupBox1.Controls.Add(Me.BT_detect)
        Me.GroupBox1.Controls.Add(Me.BtConnect)
        Me.GroupBox1.Controls.Add(Me.Bt_disconnect)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 136)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(356, 77)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Port"
        '
        'LB_baudrate
        '
        Me.LB_baudrate.AutoSize = True
        Me.LB_baudrate.Location = New System.Drawing.Point(7, 58)
        Me.LB_baudrate.Name = "LB_baudrate"
        Me.LB_baudrate.Size = New System.Drawing.Size(59, 13)
        Me.LB_baudrate.TabIndex = 5
        Me.LB_baudrate.Text = "Baud rate :"
        '
        'LB_port
        '
        Me.LB_port.AutoSize = True
        Me.LB_port.Location = New System.Drawing.Point(7, 31)
        Me.LB_port.Name = "LB_port"
        Me.LB_port.Size = New System.Drawing.Size(32, 13)
        Me.LB_port.TabIndex = 4
        Me.LB_port.Text = "Port :"
        '
        'GP_datas
        '
        Me.GP_datas.Controls.Add(Me.TRB_rate)
        Me.GP_datas.Controls.Add(Me.TRB_max_datas)
        Me.GP_datas.Controls.Add(Me.PRB_nb_datas)
        Me.GP_datas.Controls.Add(Me.BT_raz)
        Me.GP_datas.Controls.Add(Me.LB_max_values)
        Me.GP_datas.Controls.Add(Me.TB_max_rate)
        Me.GP_datas.Controls.Add(Me.LB_max_rate)
        Me.GP_datas.Controls.Add(Me.TB_max_values)
        Me.GP_datas.Location = New System.Drawing.Point(391, 136)
        Me.GP_datas.Name = "GP_datas"
        Me.GP_datas.Size = New System.Drawing.Size(359, 77)
        Me.GP_datas.TabIndex = 15
        Me.GP_datas.TabStop = False
        Me.GP_datas.Text = "Données"
        '
        'TRB_rate
        '
        Me.TRB_rate.Location = New System.Drawing.Point(76, 55)
        Me.TRB_rate.Maximum = 3600
        Me.TRB_rate.Name = "TRB_rate"
        Me.TRB_rate.Size = New System.Drawing.Size(104, 45)
        Me.TRB_rate.TabIndex = 8
        '
        'TRB_max_datas
        '
        Me.TRB_max_datas.Location = New System.Drawing.Point(76, 23)
        Me.TRB_max_datas.Maximum = 1000
        Me.TRB_max_datas.Name = "TRB_max_datas"
        Me.TRB_max_datas.Size = New System.Drawing.Size(104, 45)
        Me.TRB_max_datas.TabIndex = 7
        '
        'PRB_nb_datas
        '
        Me.PRB_nb_datas.Location = New System.Drawing.Point(237, 52)
        Me.PRB_nb_datas.Maximum = 1000
        Me.PRB_nb_datas.Name = "PRB_nb_datas"
        Me.PRB_nb_datas.Size = New System.Drawing.Size(116, 23)
        Me.PRB_nb_datas.TabIndex = 6
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichierToolStripMenuItem, Me.DonnéesToolStripMenuItem, Me.AideToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(760, 24)
        Me.MenuStrip1.TabIndex = 16
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitterToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        Me.FichierToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.FichierToolStripMenuItem.Text = "Fichier"
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.QuitterToolStripMenuItem.Text = "Quitter"
        '
        'DonnéesToolStripMenuItem
        '
        Me.DonnéesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RAZToolStripMenuItem})
        Me.DonnéesToolStripMenuItem.Name = "DonnéesToolStripMenuItem"
        Me.DonnéesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.DonnéesToolStripMenuItem.Text = "Données"
        '
        'RAZToolStripMenuItem
        '
        Me.RAZToolStripMenuItem.Name = "RAZToolStripMenuItem"
        Me.RAZToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.RAZToolStripMenuItem.Text = "RAZ"
        '
        'AideToolStripMenuItem
        '
        Me.AideToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AProposToolStripMenuItem})
        Me.AideToolStripMenuItem.Name = "AideToolStripMenuItem"
        Me.AideToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.AideToolStripMenuItem.Text = "Aide"
        '
        'AProposToolStripMenuItem
        '
        Me.AProposToolStripMenuItem.Name = "AProposToolStripMenuItem"
        Me.AProposToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AProposToolStripMenuItem.Text = "A propos"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.InterfacePIANODE_USB.My.Resources.Resources.picto
        Me.PictureBox1.Location = New System.Drawing.Point(359, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(391, 103)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'PB_LogoPierron
        '
        Me.PB_LogoPierron.Image = Global.InterfacePIANODE_USB.My.Resources.Resources.logo_pierron_bleu
        Me.PB_LogoPierron.Location = New System.Drawing.Point(12, 27)
        Me.PB_LogoPierron.Name = "PB_LogoPierron"
        Me.PB_LogoPierron.Size = New System.Drawing.Size(300, 103)
        Me.PB_LogoPierron.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PB_LogoPierron.TabIndex = 12
        Me.PB_LogoPierron.TabStop = False
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 561)
        Me.Controls.Add(Me.GP_datas)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PB_LogoPierron)
        Me.Controls.Add(Me.DGV_datas)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MinimumSize = New System.Drawing.Size(776, 600)
        Me.Name = "main"
        Me.Text = "PIERRON - USB"
        CType(Me.DGV_datas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GP_datas.ResumeLayout(False)
        Me.GP_datas.PerformLayout()
        CType(Me.TRB_rate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TRB_max_datas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_LogoPierron, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SerialPort As IO.Ports.SerialPort
    Friend WithEvents BtConnect As Button
    Friend WithEvents Bt_disconnect As Button
    Friend WithEvents CB_port As ComboBox
    Friend WithEvents CB_baudrate As ComboBox
    Friend WithEvents LB_valeurs As ListBox
    Friend WithEvents BT_raz As Button
    Friend WithEvents TB_max_rate As TextBox
    Friend WithEvents LB_max_rate As Label
    Friend WithEvents LB_max_values As Label
    Friend WithEvents TB_max_values As TextBox
    Friend WithEvents BT_detect As Button
    Friend WithEvents DGV_datas As DataGridView
    Friend WithEvents PB_LogoPierron As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LB_port As Label
    Friend WithEvents LB_baudrate As Label
    Friend WithEvents GP_datas As GroupBox
    Friend WithEvents TRB_rate As TrackBar
    Friend WithEvents TRB_max_datas As TrackBar
    Friend WithEvents PRB_nb_datas As ProgressBar
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FichierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DonnéesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RAZToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AideToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AProposToolStripMenuItem As ToolStripMenuItem
End Class
