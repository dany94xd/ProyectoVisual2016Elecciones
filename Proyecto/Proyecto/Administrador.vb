Public Class Administrador
    Inherits Persona

    Private _usuario As String
    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    Private _contraseña As String
    Public Property Contraseña() As String
        Get
            Return _Contraseña
        End Get
        Set(ByVal value As String)
            _Contraseña = value
        End Set
    End Property

   



    Public Sub New()

    End Sub

    Private Sub RealizarReporte()

    End Sub

End Class
