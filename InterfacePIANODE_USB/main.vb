Imports System.Threading
Imports System
Imports System.IO.Ports
Imports System.Web.Script.Serialization


Public Class main
    Dim Th_serial_read As Thread 'Thread lié à un port série
    Dim is_serial_read As Boolean 'Flag pour continuer la lecture du port série
    Dim Json_serialiser As New JavaScriptSerializer()

    Dim Max_datas As Int32 = 1000

    '*********************
    '* FONCTIONS METIERS *
    '*********************

    ''' <summary>
    ''' Connecte le port série et execute un thread pour lecture
    ''' </summary>
    Public Sub Serial_connect()
        If Not is_serial_read Then
            Try
                SerialPort.Close()
            Catch ex As Exception
            End Try
            SerialPort.BaudRate = CInt(CB_baudrate.Text)
            SerialPort.PortName = CB_port.Text
            SerialPort.ReadTimeout = 5000
            SerialPort.WriteTimeout = 500
            SerialPort.Parity = Parity.None
            SerialPort.StopBits = StopBits.One
            SerialPort.DataBits = 8
            SerialPort.Handshake = Handshake.None
            SerialPort.Open()
            is_serial_read = True
            Th_serial_read = New Thread(AddressOf Serial_read)
            Th_serial_read.Start()
        End If
    End Sub
    ''' <summary>
    ''' Lecture en continue du port série
    ''' Cette Sub est() apellée via un Thread
    ''' </summary>
    Public Sub Serial_read()
        Dim message As String
        Dim dict As Object
        Dim date_last_mesure As Date

        message = ""
        ' Lecture de la première ligne (pas forcement lue entière)
        Try
            message = SerialPort.ReadLine()
        Catch generatedExceptionName As TimeoutException
        End Try
        date_last_mesure = DateAndTime.Now
        'Boucle tant connexion active
        While is_serial_read
            Try
                message = SerialPort.ReadLine()
                Console.WriteLine("Recept : " + message)
                'Si le max_rate n'est pas atteint, on prend en compte la mesure
                If DateDiff(DateInterval.Second, date_last_mesure, DateAndTime.Now) >= Convert.ToInt32(TB_max_rate.Text) Then
                    dict = Json_serialiser.Deserialize(Of Object)(message)
                    Try
                        Invoke(New Add_DGV_datas_delegate(AddressOf Add_DGV_datas), dict)
                    Catch ex2 As exception
                    End Try
                    date_last_mesure = DateAndTime.Now
                End If
            Catch generatedExceptionName As TimeoutException
            Catch generatedExceptionName As IO.IOException
            Catch ex As UnauthorizedAccessException
                Invoke(New Serial_close_delegate(AddressOf Serial_close))
            Catch ex As FormatException
                Console.WriteLine("Error during json parsing : " + ex.Message)
            End Try
        End While
    End Sub
    ''' <summary>
    ''' Close the serial communication
    ''' </summary>
    Public Delegate Sub Serial_close_delegate()
    Public Sub Serial_close()
        is_serial_read = False
        SerialPort.Close()
        BtConnect.Enabled = True
        Bt_disconnect.Enabled = False
        LB_modele.Text = "Aucun produit connecté"
    End Sub
    ''' <summary>
    ''' Lecture de l'objet reçu via json decoder
    ''' sous la forme {"MODELE"={"MODELE"=leModele,"VERSION"=laversion},{"DATAS"={"KEY1"="VAL1", .....}}
    ''' Construction du tableau de valeurs : chaque key du champ DATAS reçu est une colonne du tableau
    ''' Délégation pour utilisation via autre Thread
    ''' </summary>
    ''' <param name="dict"></param>
    Public Delegate Sub Add_DGV_datas_delegate(dict As Object)
    Private Sub Add_DGV_datas(dict As Object)
        Dim colonne As DataGridViewTextBoxColumn
        Dim datas As Object
        Dim modele As Object
        Dim indexColonne As Integer

        modele = dict("MODELE")
        LB_modele.Text = "Produit connecté : " + modele("MODELE") + " version " + modele("VERSION")
        datas = dict("DATAS")
        'Ajout de la date
        If Not datas.ContainsValue("date") Then
            datas.add("date", Date.Now)
        End If
        'Ajout des colonnes manquantes
        For Each pair In datas
            If Not DGV_datas.Columns.Contains(pair.key) Then
                colonne = New DataGridViewTextBoxColumn()
                colonne.Name = pair.key
                colonne.DataPropertyName = pair.key
                DGV_datas.Columns.Add(colonne)
                ' trie des colonnes
                For Each column In DGV_datas.Columns
                    If column.Name > colonne.Name And column.DisplayIndex < colonne.DisplayIndex Then
                        indexColonne = column.DisplayIndex
                        colonne.DisplayIndex = column.DisplayIndex
                        column.DisplayIndex = indexColonne + 1
                    End If
                Next
            End If
        Next
        'Insertion des données
        Dim row() As String = New String(DGV_datas.Columns.Count) {}
        For Each pair In datas
            row(DGV_datas.Columns.Item(pair.key).index) = pair.value
        Next
        'DGV_datas.Rows.Insert(0, row)
        DGV_datas.Rows.Add(row)

        'Si trop de donnée (max_value), supression des données en trop
        While DGV_datas.Rows.Count > Me.Max_datas
            DGV_datas.Rows.RemoveAt(DGV_datas.Rows.Count - 1)
        End While
    End Sub

    ''' <summary>
    ''' Détect les port série actifs et met à jour CB_port
    ''' </summary>
    Private Sub Serial_detect()
        Dim ports As String() = SerialPort.GetPortNames()
        Dim port_precedent = CB_port.Text
        CB_port.Items.Clear()
        For Each port In ports
            CB_port.Items.Add(port)
        Next port
        If port_precedent = "" Then
            If ports.Length > 0 Then
                CB_port.SelectedIndex = 0
            End If
        End If
    End Sub

    ''' <summary>
    '''  Envoie une ligne de text sur le port usb actif sous la forme :
    '''  "{"ACTION":cmd}"
    ''' </summary>
    ''' <param name="cmd"> la commande a envoyer</param>
    Private Sub Send_command_by_usb(cmd As String)
        Dim dict As New Dictionary(Of String, String)()
        Dim json As String
        dict.Add("ACTION", cmd)
        json = Json_serialiser.Serialize(dict)
        If SerialPort.IsOpen Then
            Try
                Console.WriteLine("Envoie : " + json)
                SerialPort.WriteLine(json)
                Console.WriteLine("Envoie ok")
            Catch generatedExceptionName As InvalidOperationException
            Catch generatedExceptionName As TimeoutException
            Catch generatedExceptionName As IO.IOException
            Catch ex As UnauthorizedAccessException
                Invoke(New Serial_close_delegate(AddressOf Serial_close))
            End Try
        End If
    End Sub


    '*****************************************
    '* INTERFACE : procédure événementielles *
    '*****************************************

    Private Sub TB_max_values_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_max_values.KeyPress
        'Interdit la saisie de caractères alpha
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TB_max_rate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TB_max_rate.KeyPress
        'Interdit la saisie de caractères alpha
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtConnect_Click(sender As Object, e As EventArgs) Handles BtConnect.Click
        Call Serial_connect()
        BtConnect.Enabled = False
        Bt_disconnect.Enabled = True
    End Sub

    Private Sub Bt_disconnect_Click(sender As Object, e As EventArgs) Handles Bt_disconnect.Click
        ' Bouton DISCONNECT
        Call Serial_close()
    End Sub

    Private Sub BT_detect_Click(sender As Object, e As EventArgs) Handles BT_detect.Click
        ' Bouton CONNECT
        Call Serial_detect()
    End Sub


    Private Sub main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Fermeture de l'application
        Try
            Th_serial_read.Abort()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Ouverture de l'application
        Call Serial_detect()
    End Sub

    Private Sub BT_raz_Click(sender As Object, e As EventArgs) Handles BT_raz.Click
        'Bouton RAZ
        DGV_datas.Rows.Clear()
        DGV_datas.Columns.Clear()
    End Sub

    Private Sub TB_max_rate_TextChanged(sender As Object, e As EventArgs) Handles TB_max_rate.TextChanged
        TRB_rate.Value = Convert.ToInt32(TB_max_rate.Text)
    End Sub

    Private Sub TB_max_values_TextChanged(sender As Object, e As EventArgs) Handles TB_max_values.TextChanged
        Me.Max_datas = Convert.ToInt32(TB_max_values.Text)
        TRB_max_datas.Value = Me.Max_datas
        PRB_nb_datas.Maximum = Me.Max_datas + 1
    End Sub

    Private Sub TRB_max_datas_Scroll(sender As Object, e As EventArgs) Handles TRB_max_datas.Scroll
        Me.Max_datas = TRB_max_datas.Value
        TB_max_values.Text = Convert.ToString(Me.Max_datas)
        PRB_nb_datas.Maximum = TRB_max_datas.Value + 1
    End Sub

    Private Sub TRB_rate_Scroll(sender As Object, e As EventArgs) Handles TRB_rate.Scroll
        TB_max_rate.Text = Convert.ToString(TRB_rate.Value)
    End Sub

    Private Sub DGV_datas_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DGV_datas.RowsAdded
        PRB_nb_datas.Value = DGV_datas.Rows.Count
        DGV_datas.FirstDisplayedScrollingRowIndex = DGV_datas.RowCount - 1
    End Sub

    Private Sub DGV_datas_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DGV_datas.RowsRemoved
        PRB_nb_datas.Value = DGV_datas.Rows.Count
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click
        End
    End Sub

    Private Sub RAZToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RAZToolStripMenuItem.Click
        DGV_datas.Rows.Clear()
        DGV_datas.Columns.Clear()
    End Sub

    Private Sub AProposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AProposToolStripMenuItem.Click
        AboutBox.Show()
    End Sub

    Private Sub EnvoieINITToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnvoieINITToolStripMenuItem.Click
        Send_command_by_usb("INIT")
    End Sub

    Private Sub EnvoieCALIBREToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnvoieCALIBREToolStripMenuItem.Click
        Send_command_by_usb("CALIBRE")
    End Sub

    Private Sub EnvoieToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnvoieToolStripMenuItem.Click
        Dim cmd As String
        cmd = InputBox("Commande ACTION à envoyer")
        If cmd <> "" Then
            Send_command_by_usb(cmd)
        End If
    End Sub


End Class
