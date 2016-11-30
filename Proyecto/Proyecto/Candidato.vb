Public Class Candidato

    Private _nombrepartidopertenece As String
    Public Property NombrePartidoPertenece() As String
        Get
            Return _nombrepartidopertenece
        End Get
        Set(ByVal value As String)
            _nombrepartidopertenece = value
        End Set
    End Property

    Private _cargo As String
    Public Property Cargo() As String
        Get
            Return _cargo
        End Get
        Set(ByVal value As String)
            _cargo = value
        End Set
    End Property


    Private _numerovotos As Integer
    Public Property NumeroVotos() As Integer
        Get
            Return _numerovotos
        End Get
        Set(ByVal value As Integer)
            _numerovotos = value
        End Set
    End Property




End Class
