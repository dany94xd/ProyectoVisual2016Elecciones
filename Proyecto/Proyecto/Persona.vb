Public Class Persona

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _cedula As String
    Public Property Cedula() As String
        Get
            Return _cedula
        End Get
        Set(ByVal value As String)
            _cedula = value
        End Set
    End Property

    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _apellido As String
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Private _edad As Char
    Public Property Edad() As Char
        Get
            Return _edad
        End Get
        Set(ByVal value As Char)
            _edad = value
        End Set
    End Property

    Private _nacionalidad As String
    Public Property Nacionalidad() As String
        Get
            Return _nacionalidad
        End Get
        Set(ByVal value As String)
            _nacionalidad = value
        End Set
    End Property

    Private _user As String
    Public Property User() As String
        Get
            Return _user
        End Get
        Set(ByVal value As String)
            _user = value
        End Set
    End Property

    Private _paswword As String
    Public Property Paswword() As String
        Get
            Return _paswword
        End Get
        Set(ByVal value As String)
            _paswword = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(user As String, paswword As String, nombre As String)
        Me._user = user
        Me._paswword = paswword
        Me._nombre = nombre

    End Sub


End Class
