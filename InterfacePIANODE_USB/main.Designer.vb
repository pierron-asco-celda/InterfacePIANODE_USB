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
        CType(Me.DGV_datas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtConnect
        '
        Me.BtConnect.Location = New System.Drawing.Point(370, 23)
        Me.BtConnect.Name = "BtConnect"
        Me.BtConnect.Size = New System.Drawing.Size(75, 23)
        Me.BtConnect.TabIndex = 0
        Me.BtConnect.Text = "Connect"
        Me.BtConnect.UseVisualStyleBackColor = True
        '
        'Bt_disconnect
        '
        Me.Bt_disconnect.Location = New System.Drawing.Point(475, 23)
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
        Me.CB_port.Location = New System.Drawing.Point(29, 25)
        Me.CB_port.Name = "CB_port"
        Me.CB_port.Size = New System.Drawing.Size(79, 21)
        Me.CB_port.TabIndex = 2
        '
        'CB_baudrate
        '
        Me.CB_baudrate.FormattingEnabled = True
        Me.CB_baudrate.Items.AddRange(New Object() {"9600", "115200"})
        Me.CB_baudrate.Location = New System.Drawing.Point(125, 25)
        Me.CB_baudrate.Name = "CB_baudrate"
        Me.CB_baudrate.Size = New System.Drawing.Size(73, 21)
        Me.CB_baudrate.TabIndex = 3
        Me.CB_baudrate.Text = "115200"
        '
        'BT_raz
        '
        Me.BT_raz.Location = New System.Drawing.Point(621, 23)
        Me.BT_raz.Name = "BT_raz"
        Me.BT_raz.Size = New System.Drawing.Size(75, 23)
        Me.BT_raz.TabIndex = 5
        Me.BT_raz.Text = "RAZ"
        Me.BT_raz.UseVisualStyleBackColor = True
        '
        'TB_max_rate
        '
        Me.TB_max_rate.Location = New System.Drawing.Point(465, 67)
        Me.TB_max_rate.Name = "TB_max_rate"
        Me.TB_max_rate.Size = New System.Drawing.Size(58, 20)
        Me.TB_max_rate.TabIndex = 6
        Me.TB_max_rate.Text = "3600"
        '
        'LB_max_rate
        '
        Me.LB_max_rate.AutoSize = True
        Me.LB_max_rate.Location = New System.Drawing.Point(355, 70)
        Me.LB_max_rate.Name = "LB_max_rate"
        Me.LB_max_rate.Size = New System.Drawing.Size(104, 13)
        Me.LB_max_rate.TabIndex = 7
        Me.LB_max_rate.Text = "Max rate (data/hour)"
        '
        'LB_max_values
        '
        Me.LB_max_values.AutoSize = True
        Me.LB_max_values.Location = New System.Drawing.Point(548, 70)
        Me.LB_max_values.Name = "LB_max_values"
        Me.LB_max_values.Size = New System.Drawing.Size(61, 13)
        Me.LB_max_values.TabIndex = 9
        Me.LB_max_values.Text = "Max values"
        '
        'TB_max_values
        '
        Me.TB_max_values.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TB_max_values.Location = New System.Drawing.Point(615, 63)
        Me.TB_max_values.MaxLength = 6
        Me.TB_max_values.Name = "TB_max_values"
        Me.TB_max_values.Size = New System.Drawing.Size(45, 20)
        Me.TB_max_values.TabIndex = 8
        Me.TB_max_values.Text = "1000"
        '
        'BT_detect
        '
        Me.BT_detect.Location = New System.Drawing.Point(228, 23)
        Me.BT_detect.Name = "BT_detect"
        Me.BT_detect.Size = New System.Drawing.Size(75, 23)
        Me.BT_detect.TabIndex = 10
        Me.BT_detect.Text = "Detect"
        Me.BT_detect.UseVisualStyleBackColor = True
        '
        'DGV_datas
        '
        Me.DGV_datas.AllowUserToAddRows = False
        Me.DGV_datas.AllowUserToOrderColumns = True
        Me.DGV_datas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_datas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGV_datas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DGV_datas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_datas.Location = New System.Drawing.Point(45, 101)
        Me.DGV_datas.MinimumSize = New System.Drawing.Size(700, 0)
        Me.DGV_datas.Name = "DGV_datas"
        Me.DGV_datas.ReadOnly = True
        Me.DGV_datas.Size = New System.Drawing.Size(700, 448)
        Me.DGV_datas.TabIndex = 11
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.DGV_datas)
        Me.Controls.Add(Me.BT_detect)
        Me.Controls.Add(Me.LB_max_values)
        Me.Controls.Add(Me.TB_max_values)
        Me.Controls.Add(Me.LB_max_rate)
        Me.Controls.Add(Me.TB_max_rate)
        Me.Controls.Add(Me.BT_raz)
        Me.Controls.Add(Me.CB_baudrate)
        Me.Controls.Add(Me.CB_port)
        Me.Controls.Add(Me.Bt_disconnect)
        Me.Controls.Add(Me.BtConnect)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "main"
        Me.Text = "PIERRON - USB"
        CType(Me.DGV_datas, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
