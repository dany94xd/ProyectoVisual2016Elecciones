Imports System.Xml

Public Class Mesa

    Private _numero As String
    Public Property Numero() As String
        Get
            Return _numero
        End Get
        Set(ByVal value As String)
            _numero = value
        End Set
    End Property

    Private _listavotantes As ArrayList
    Public Property ListaVotantes() As ArrayList
        Get
            Return _listavotantes
        End Get
        Set(ByVal value As ArrayList)
            _listavotantes = value
        End Set
    End Property

    Private _nvotos As ArrayList
    Public Property Nvotos() As ArrayList
        Get
            Return _nvotos
        End Get
        Set(ByVal value As ArrayList)
            _nvotos = value
        End Set
    End Property

    Public Sub New(numero As String)
        Me.Numero = numero
        Me.ListaVotantes = New ArrayList
        Me.Nvotos = New ArrayList

    End Sub

    Public Sub AgregarVotante(persona As Persona)
        Me._listavotantes.Add(persona)
    End Sub

    Public Sub cargarlistadevotantes()
        Dim path As String = "H:\SistemaVotaciones\SistemaVotaciones\votaciones.xml"
        Dim xmldoc As New XmlDocument()
        xmldoc.Load(path)
        Dim lista As XmlNodeList = xmldoc.GetElementsByTagName("votante")
        For Each Votante As XmlNode In lista
            Dim persona As Persona = New Persona(Votante.Attributes("cedula").Value)
            For Each nodo As XmlNode In Votante.ChildNodes
                Select Case nodo.Name
                    Case "nombre"
                        persona.Nombre = nodo.InnerText
                    Case "apellido"
                        persona.Apellido = nodo.InnerText
                    Case "sufrago"
                        persona.Sufrago = CBool(nodo.InnerText)
                    Case Else
                End Select

            Next
            AgregarVotante(persona)
        Next
    End Sub


    Public Sub listarvotadores()
        Console.WriteLine("")
        For Each persona As Persona In ListaVotantes
            persona.mostrar()
        Next
    End Sub


    Public Function verificarVotante() As Persona
        'Dim cki As ConsoleKeyInfo
        Dim cedula As String = ""
        'Dim car As Integer = 0
        Console.WriteLine("BIENVENIDO... INGRESE SU NUMERO DE CEDULA")
        cedula = Console.ReadLine()
        Console.WriteLine()
        Console.WriteLine("CONSULTANDO DATOS .....")
        Console.ReadLine()

        Dim vot As Persona = New Persona()
        For Each votante As Persona In Me.ListaVotantes
            'Console.Write(votante.Cedula)

            'votante.mostrar()

            If votante.Cedula = cedula Then
                vot = votante
            End If
        Next
        Return vot
    End Function

End Class
