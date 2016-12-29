﻿Imports System.Xml

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
    '***********************'
    Const ADDIGNIDAD As Byte = 1
    Const ADCAND As Byte = 2
    Const ADRESUL As Byte = 3
    Const ADEXIT As Byte = 4

    '**********************'
    Const VPRESI As Byte = 1
    Const VASAN As Byte = 2
    Const VCON As Byte = 3
    Const VEXIT As Byte = 4

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
                    ManejarVotante()

                Case LOGADMIN
                    Console.WriteLine("2.- Login Usario")
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


    Public Sub Menuadmin()
        Console.WriteLine("{0}. Agregar dignidad ", ADDIGNIDAD)
        Console.WriteLine("{0}. Agregar candidato ", ADCAND)
        Console.WriteLine("{0}. Mostrar Resultados ", ADRESUL)
        Console.WriteLine("{0}. Salir", ADEXIT)
        Dim opcion As String = ""
        Dim op As Byte
        opcion = Console.ReadLine()
        op = CByte(opcion)


        Console.WriteLine("usted a ingresado{0}", opcion)
        Console.ReadLine()

        Select Case op

            Case ADDIGNIDAD
                Console.WriteLine("1.- Añadir dignidad")


            Case ADCAND
                Console.WriteLine("2.- Añadir candidato")


            Case ADRESUL

                Console.WriteLine("3.- consultar resultados")


            Case ADEXIT
                Console.WriteLine("4.- salir")
                'MenuUsario()
            Case Else
                Console.WriteLine("opcion invalida:{0}", op)

        End Select
    End Sub

    Public Sub MenuCand()
        Console.WriteLine("{0}. CANDIDATO ", LGUSER)
        Console.WriteLine("{0}. ADMINISTRADOR ", LGATRAS)
        Console.WriteLine("{0}. Regresar ", LGOUT)
        Dim opcion As String = ""
        Dim op As Byte
        opcion = Console.ReadLine()
        op = CByte(opcion)


        Console.WriteLine("usted a ingresado{0}", opcion)
        Console.ReadLine()

        Select Case op

            Case LGUSER
                Console.WriteLine("1.- Bienvendido Candidato")
                ManejarLoginUsario()

            Case LGATRAS
                Console.WriteLine("2.- Bienvenido Administrador")
                MenuCand()

            Case OUT

                Console.WriteLine("3.- Regresar")
                MenuUsario()
            Case Else
                Console.WriteLine("opcion invalida:{0}", op)

        End Select


    End Sub

    Public Sub Menuvotante()
        Console.WriteLine("{0}. Sufragar Presidente ", VPRESI)
        Console.WriteLine("{0}. Sufragar asambleista ", VASAN)
        Console.WriteLine("{0}. sufragar consejal ", VCON)
        Console.WriteLine("{0}. Salir", VEXIT)
        Dim opcion As String = ""
        Dim op As Byte
        opcion = Console.ReadLine()
        op = CByte(opcion)


        Console.WriteLine("usted a ingresado{0}", opcion)
        Console.ReadLine()

        Select Case op

            Case VPRESI
                Console.WriteLine("1.- elegir presidente")


            Case VASAN
                Console.WriteLine("2.- elegir asambleista")


            Case VCON

                Console.WriteLine("3.- elegir consejal")


            Case VEXIT
                Console.WriteLine("4.- salir")
                'MenuUsario()
            Case Else
                Console.WriteLine("opcion invalida:{0}", op)

        End Select
    End Sub

    Public Sub ManejarVotante()
        Dim cedula As String = ""



        Dim bandera As Boolean = True
        Dim patch As String = "C:\Users\Usuario\Documents\Visual Studio 2013\Projects\SistemaVotaciones\votaciones.xml"
        'CARGA DESDE USUARIOS.XML
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(patch)
        Dim lista_mesas As XmlNodeList = xmlDoc.GetElementsByTagName("padron")
        For Each padron As XmlNode In lista_mesas
            For Each Votante As XmlNode In padron.ChildNodes
                Do While bandera
                    Console.Write(" Ingrese su numero de cedula : ")
                    cedula = Console.ReadLine()
                    Try
                        If cedula = Votante.Attributes(0).Value Then
                            Console.WriteLine("Login correcto")
                            MsgBox("login correcto")
                            Console.WriteLine("bienvendio:" & Votante.InnerText)
                            bandera = False
                            Menuvotante()


                        Else
                            Console.WriteLine("Datos no validos")

                        End If
                    Catch ex As Exception
                        Console.WriteLine("Datos no validos")
                    End Try
                Loop
            Next
        Next

    End Sub

    Sub ManejarLoginCandidato()

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
                Loop
            Next
        Next

        'Console.WriteLine("Login correcto")
    End Sub

    Sub ManejarLoginAdmin()
        Dim user As String = ""
        Dim pass As String = ""
        Dim bandera As Boolean = True
        Dim patch As String = "C:\Users\Usuario\Documents\Visual Studio 2013\Projects\SistemaVotaciones\votaciones.xml"
        'CARGA DESDE USUARIOS.XML
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(patch)
        Dim admins As XmlNodeList = xmlDoc.GetElementsByTagName("administrador")
        For Each admin As XmlNode In admins
            'Console.WriteLine(admin.Name)
            Do While bandera
                Console.Write(" Ingrese USUARIO : ")
                user = Console.ReadLine()
                Console.Write(" Ingrese PASSWORD: ")
                pass = Console.ReadLine()
                Try
                    If user = admin.Attributes(0).Value And pass = admin.Attributes(1).Value Then
                        Console.WriteLine("Login correcto")
                        MsgBox("login correcto")
                        bandera = False
                        Menuadmin()
                    Else
                        Console.WriteLine("Datos no validos")

                    End If
                Catch ex As Exception
                    Console.WriteLine("Datos no validos")
                End Try
            Loop
        Next





    End Sub
End Class
