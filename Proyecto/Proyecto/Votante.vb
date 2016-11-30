Public Class Votante

    Private _residencia As String
    Public Property Residencia() As String
        Get
            Return _residencia
        End Get
        Set(ByVal value As String)
            _residencia = value
        End Set
    End Property

    Private _estadodevoto As Boolean
    Public Property EstadodeBoto() As Boolean
        Get
            Return _estadodevoto
        End Get
        Set(ByVal value As Boolean)
            _estadodevoto = value
        End Set
    End Property



End Class
