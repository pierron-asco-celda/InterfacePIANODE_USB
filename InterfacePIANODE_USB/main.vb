Imports System.Threading
Imports System
Imports System.IO.Ports
Imports System.Web.Script.Serialization


Public Class main
    Dim Th_serial_read As Thread 'Thread lié à un port série
    Dim is_serial_read As Boolean 'Flag pour continuer la lecture du port série

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
            SerialPort.ReadTimeout = 1000
            SerialPort.WriteTimeout = 1000
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
        ' Lecture de la première ligne (pas forcement lue entière)
        Try
            message = SerialPort.ReadLine()
        Catch generatedExceptionName As TimeoutException
        End Try
        'Boucle tant connexion active
        While is_serial_read
            Try
                message = SerialPort.ReadLine()
                Console.WriteLine(message, GetType(Message))
                Dim f = New Add_DGV_datas_delegate(AddressOf Me.Add_DGV_datas)
                Invoke(f, message)
            Catch generatedExceptionName As TimeoutException
            Catch generatedExceptionName As IO.IOException
                'Catch ex As Exception 'Un peu boeuf => évite tout plantage
            End Try
        End While
    End Sub
    ''' <summary>
    ''' Construction du tableau de valeurs : chaque key du json reçu est une colonne du tableau
    ''' Délégation pour utilisation via autre Thread
    ''' </summary>
    ''' <param name="json"></param>
    Public Delegate Sub Add_DGV_datas_delegate(ByVal message As String)
    Private Sub Add_DGV_datas(ByVal message As String)
        Dim colonne As DataGridViewTextBoxColumn
        Dim dict As Object
        Try
            dict = New JavaScriptSerializer().Deserialize(Of Object)(message)
        Catch ex As Exception
            dict = Nothing
        End Try
        If dict Then
            'Ajout de la date
            dict.add("date", Date.Now)
            'Ajout des colonnes manquantes
            For Each pair In dict
                If Not DGV_datas.Columns.Contains(pair.key) Then
                    colonne = New DataGridViewTextBoxColumn()
                    colonne.Name = pair.key
                    colonne.DataPropertyName = pair.key
                    DGV_datas.Columns.Add(colonne)
                End If
            Next
            'Insertion des données
            Dim row() As String = New String(DGV_datas.Columns.Count) {}
            For Each pair In dict
                row(DGV_datas.Columns.Item(pair.key).index) = pair.value
            Next
            DGV_datas.Rows.Add(row)
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
    End Sub





    Private Sub Bt_disconnect_Click(sender As Object, e As EventArgs) Handles Bt_disconnect.Click
        ' Bouton DISCONNECT
        is_serial_read = False
        SerialPort.Close()
    End Sub

    Private Sub BT_detect_Click(sender As Object, e As EventArgs) Handles BT_detect.Click
        ' Bouton CONNECT
        Call Serial_detect()
    End Sub

    Private Sub Serial_detect()
        'Détect les port série actifs
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
    End Sub
End Class
