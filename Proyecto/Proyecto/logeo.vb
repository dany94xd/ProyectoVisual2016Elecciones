Imports System.Xml

Public Class logeo

    Private persona As Persona
    Const LOGVOTANTE As Byte = 1
    Const LOGADMIN As Byte = 2
    Const OUT As Byte = 3

    '****************************'

    Const LGUSER As Byte = 1
    Const LGATRAS As Byte = 2
    Const LGOUT As Byte = 3

    '**********************'
    Const CANUS As Byte = 1
    Const CANEXIT As Byte = 2

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
                    'ManejarLoginUsario()

                Case LOGADMIN
                    Console.WriteLine("2.- Login Uusario")
                    MenuCand()

                Case OUT

                    Console.WriteLine("3.- Salir")
                Case Else
                    Console.WriteLine("opcion invalida:{0}", op)

            End Select

        Loop Until OUT

        Console.WriteLine("gracias por su colaboracion")
        Console.ReadLine()

    End Sub

    Public Sub MenuUsario()
        Console.WriteLine("{0}. Iniciar Votante ", LOGVOTANTE)
        Console.WriteLine("{0}. Iniciar Usuario ", LOGADMIN)
        Console.WriteLine("{0}. Salir ", OUT)


    End Sub

    Public Sub opadmin()
        Console.WriteLine("{0}. Consultar Votos ", CANUS)
        Console.WriteLine("{0}. Salir ", CANEXIT)
    End Sub


    Public Sub MenuCand()
        Console.WriteLine("{0}. ADMINISTRADOR ", LGUSER)
        Console.WriteLine("{0}. CANDIDATO ", LGATRAS)
        Console.WriteLine("{0}. Regresar ", LGOUT)
        Dim opcion As String = ""
        Dim op As Byte
        opcion = Console.ReadLine()
        op = CByte(opcion)


        Console.WriteLine("usted a ingresado{0}", opcion)
        Console.ReadLine()

        Select Case op

            Case LGUSER
                Console.WriteLine("1.- Bienvendido Administrador")
                ManejarLoginUsario()

            Case LGATRAS
                Console.WriteLine("2.- Bienvenido Candidato")
                MenuCand()

            Case OUT

                Console.WriteLine("3.- Regresar")
                MenuUsario()
            Case Else
                Console.WriteLine("opcion invalida:{0}", op)

        End Select


    End Sub

    Sub ManejarLoginUsario()

        Dim user As String = ""
        Dim pass As String = ""


        Dim bandera As Boolean = True
        Dim patch As String = "C:\Users\Usuario\Documents\Visual Studio 2013\Projects\SistemaVotaciones\votaciones.xml"
        'CARGA DESDE USUARIOS.XML
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(patch)
        Dim lista_partidos As XmlNodeList = xmlDoc.GetElementsByTagName("partido")
        For Each partido As XmlNode In lista_partidos
            'el .name imprime el nombre de la etiqueta y el .attributes el atributo de la etiqueta segun la posicion 0 o 1 '
            'Console.WriteLine(partido.Name & partido.Attributes(0).Value)
            For Each candidato As XmlNode In partido.ChildNodes
                'Console.WriteLine(candidato.Name & candidato.Attributes(0).Value)
                Do While bandera
                    Console.Write(" Ingrese USUARIO : ")
                    user = Console.ReadLine()
                    Console.Write(" Ingrese PASSWORD: ")
                    pass = Console.ReadLine()

                    Try
                        If user = candidato.Attributes(1).Value And pass = candidato.Attributes(2).Value Then
                            Console.WriteLine("Login correcto")
                            MsgBox("login correcto")
                            bandera = False
                            opadmin()
                        Else
                            Console.WriteLine("Datos no validos")

                        End If
                    Catch ex As Exception
                        Console.WriteLine("Datos no validos")
                    End Try

                    'bandera = False
                Loop



                'bandera = True
            Next
        Next

        'Console.WriteLine("Login correcto")



    End Sub


End Class
