Public Class Sistema

    Const LOGVOTANTE As Byte = 1
    Const LOGADMIN As Byte = 2
    Const LOGCANDI As Byte = 3
    'Const atras As Byte = 4
    Const OUT As Byte = 4
    Const LGUSER As Byte = 1
    Const LGATRAS As Byte = 2
    Const LGOUT As Byte = 3

    Public Function Menu_Principal() As Byte

        Dim opc As Byte = 99
        Do While opc < 0 Or opc > 1
            Console.WriteLine("SELECCIONE UNA ACCION")
            Console.WriteLine("1.- LOGIN")
            Console.WriteLine("0.- SALIR")
            Try
                opc = Console.ReadLine()
            Catch ex As Exception
                opc = 0
            End Try
        Loop
        Return opc



    End Function

    Public Sub MenuUSER()

        Dim opcion As String = ""
        Dim op As Byte

        Do

            Console.WriteLine("***********************************")

            MenuUsario()
            opcion = Console.ReadLine()
            op = CByte(opcion)


            Console.WriteLine("usted a ingresado{0}", opcion)
            Console.ReadLine()

            Select Case op
                Case LOGVOTANTE
                    Console.WriteLine("1.- Login Votante")
                    Menulogin()

                Case LOGADMIN
                    Console.WriteLine("2.- Login Administrador")
                    Menuadministrador()
                Case LOGCANDI

                    Console.WriteLine("3.- Login Candidato")
                    Menucandidato()
                    'Case atras

                    '    Console.WriteLine("4.- Regresar")
                    '    Menu_Principal()

                Case OUT

                    Console.WriteLine("4.- Salir")
                Case Else
                    Console.WriteLine("opcion invalida:{0}", op)

            End Select

        Loop Until OUT

        Console.WriteLine("gracias por su colaboracion")
        Console.ReadLine()

    End Sub

    Public Sub MenuUsario()
        Console.WriteLine("{0}. Login votante ", LOGVOTANTE)
        Console.WriteLine("{0}. Login administrador ", LOGADMIN)
        Console.WriteLine("{0}. Login Candidato ", LOGCANDI)
        'Console.WriteLine("{0}. Regresar ", atras)
        Console.WriteLine("{0}. Salir ", OUT)


    End Sub


    Public Sub Menulogin()
        Console.WriteLine("{0}. Login ", LGUSER)
        Console.WriteLine("{0}. Regresar ", LGATRAS)
        Console.WriteLine("{0}. Salir ", LGOUT)
    End Sub

    Public Sub Menuadministrador()
        Console.WriteLine("{0}. Login ", LGUSER)
        Console.WriteLine("{0}. Regresar ", LGATRAS)
        Console.WriteLine("{0}. Salir ", LGOUT)
    End Sub



    Public Sub Menucandidato()
        Console.WriteLine("{0}. Login ", LGUSER)
        Console.WriteLine("{0}. Regresar ", LGATRAS)
        Console.WriteLine("{0}. Salir.. ", LGOUT)
    End Sub


    Sub ManejarLogin()
        Dim opcion As String = ""
        Dim op As Byte

        Do
            Menulogin()
            opcion = Console.ReadLine()
            op = CByte(opcion)

            Console.WriteLine("usted a ingresado{0}", opcion)
            Console.ReadLine()
            Select Case op
                Case LGUSER
                    Console.WriteLine("Iniciar secion")
                Case LGATRAS
                    Console.WriteLine("regresar menu Usuario")
                    MenuUsario()
                Case LGOUT
                    Console.WriteLine("Salir")
                    Console.WriteLine("gracias por su colaboracion")
                Case Else
                    Console.WriteLine("vuelva a ingresa la opcion")

            End Select

        Loop Until LGOUT
    End Sub






End Class
