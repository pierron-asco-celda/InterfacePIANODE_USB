Imports System.Threading
Imports System
Imports System.IO.Ports
Imports System.Web.Script.Serialization


Public Class main
    Dim Th_serial_read As Thread 'Thread lié à un port série
    Dim is_serial_read As Boolean 'Flag pour continuer la lecture du port série
    Dim Json_serialiser As New JavaScriptSerializer()

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
            Catch generatedExceptionName As TimeoutException
            Catch generatedExceptionName As IO.IOException
            End Try
            'Si le max_rate n'est pas atteint, on prend en compte la mesure
            If DateDiff(DateInterval.Second, date_last_mesure, DateAndTime.Now) > 3600 / Convert.ToInt32(TB_max_rate.Text) Then
                Try
                    dict = Json_serialiser.Deserialize(Of Object)(message)
                    Invoke(New Add_DGV_datas_delegate(AddressOf Add_DGV_datas), dict)
                Catch ex As Exception
                End Try
                date_last_mesure = DateAndTime.Now
            End If
        End While
    End Sub
    ''' <summary>
    ''' Construction du tableau de valeurs : chaque key du json reçu est une colonne du tableau
    ''' Délégation pour utilisation via autre Thread
    ''' </summary>
    ''' <param name="dict"></param>
    Public Delegate Sub Add_DGV_datas_delegate(dict As Object)
    Private Sub Add_DGV_datas(dict As Object)
        Dim colonne As DataGridViewTextBoxColumn
        'Ajout de la date
        If Not dict.ContainsValue("date") Then
            dict.add("date", Date.Now)
        End If
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
        DGV_datas.Rows.Insert(0, row)

        'Si trop de donnée (max_value), supression des données en trop
        While DGV_datas.Rows.Count > Convert.ToInt32(TB_max_values.Text)
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
