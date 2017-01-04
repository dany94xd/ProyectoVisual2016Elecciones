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

    Public Sub Votacionpresidente()
        Dim votante As Persona = verificarVotante()
        If votante.Nombre = "" Then
            Console.WriteLine("NO SE ENCUENTRA EN LA LISTA")
            Exit Sub
        Else
            votante.mostrar()
        End If
        If votante.Sufrago Then
            Console.WriteLine("Usted ya a sufragado gracias por su colaboracion")
            Console.ReadLine()
            Exit Sub
        Else
            Dim partidos As ArrayList = CargarCandidatos()
            Dim tipo_cargo As Byte = 1
            Dim candidatos_ultimaver As ArrayList = New ArrayList()
            Dim candi_conse As ArrayList = New ArrayList()
            For Each part As PartidoPolitico In partidos
                For Each candi As Candidato In part.Candidatos
                    If candi.Dignidad = "Presidente" Then
                        candidatos_ultimaver.Add(candi)
                        'ElseIf candi.Dignidad = "Consejal" Then
                        '    candi_conse.Add(candi)
                    End If
                Next
            Next
            Dim opc As Byte = 0
            Do While opc <= 0 Or opc > candidatos_ultimaver.Count
                Console.WriteLine("Candidato a: ----------")
                For Each candi As Candidato In candidatos_ultimaver
                    candi.mostradatosCandi()
                    Console.WriteLine()
                Next
                Try
                    Console.Write("Escriba la opcion que desee:")
                    opc = Console.ReadLine()
                Catch ex As Exception
                    Console.WriteLine(vbNewLine & "ingrese solo numeros")
                End Try
            Loop
            Dim ca As Candidato = candidatos_ultimaver.Item(opc - 1)
            Console.WriteLine("UD ha elegio")
            ca.mostradatosCandi()

        End If


    End Sub
End Class
