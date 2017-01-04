Public Class Candidato
    Inherits Persona



    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property


    'dignidad cargo por el cual postula: Presidente,asambleista,consejal'
    Private _dignidad As String
    Public Property Dignidad() As String
        Get
            Return _dignidad
        End Get
        Set(ByVal value As String)
            _dignidad = value
        End Set
    End Property

    Private _numerodevotos As Integer
    Public Property NumerodeVotos() As Integer
        Get
            Return _numerodevotos
        End Get
        Set(ByVal value As Integer)
            _numerodevotos = value
        End Set
    End Property


    Public Sub New(id As String, cargo As String)
        Me.ID = id
        Me.Dignidad = cargo

    End Sub




    Public Sub mostradatosCandi()
        Console.WriteLine(Me.Nombre & vbTab & Me.Apellido & vbTab & Me.Dignidad)

    End Sub
End Class

