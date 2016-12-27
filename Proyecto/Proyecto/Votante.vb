Public Class Votante

    Inherits Persona

    Private _residencia As String
    Public Property Residencia() As String
        Get
            Return _residencia
        End Get
        Set(ByVal value As String)
            _residencia = value
        End Set
    End Property

End Class
