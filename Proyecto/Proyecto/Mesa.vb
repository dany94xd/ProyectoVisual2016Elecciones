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
        Dim path As String = ""
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


End Class
