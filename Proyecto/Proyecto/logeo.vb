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
    '***********************'
    Const ADDIGNIDAD As Byte = 1
    Const ADCAND As Byte = 2
    Const ADPATRON As Byte = 3
    Const ADRESUL As Byte = 4
    Const ADEXIT As Byte = 5


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
        Console.WriteLine("{0}. ver patron electoral ", ADPATRON)
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
                AgregarDignidad()

            Case ADCAND
                Console.WriteLine("2.- Añadir candidato")
                NuevoCandidato()

            Case ADPATRON

                Console.WriteLine("4.- consultar padron de votantes")
                Dim mesa As Mesa = New Mesa("0001")
                mesa.cargarlistadevotantes()
                mesa.listarvotadores()


            Case ADRESUL

                Console.WriteLine("4.- consultar resultados")
            Case ADEXIT
                Console.WriteLine("5.- salir")
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
                ManejarLoginCandidato()

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
            Console.WriteLine(admin.Name)
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


    Public Sub NuevoCandidato()

        Dim path As String = "C:\Users\Usuario\Documents\Visual Studio 2013\Projects\SistemaVotaciones\votaciones.xml"
        Dim xmldoc As New XmlDocument()
        xmldoc.Load(path)
        Dim lista As XmlNodeList = xmldoc.GetElementsByTagName("candidato")
        For Each candida As XmlNode In lista
            For i = 1 To 3
                candida.AppendChild(CrearCandidato(xmldoc))

            Next
            xmldoc.Save(path)
        Next


    End Sub






    Function CrearCandidato(xmldoc As XmlDocument)
        Dim candi As XmlElement = xmldoc.CreateElement("candidato")
        candi.SetAttribute("id", "7")
        candi.SetAttribute("user", "new")
        candi.SetAttribute("pass", "123")
        Dim nombre As XmlElement = xmldoc.CreateElement("nombre")
        nombre.InnerText = "nuevapersona"
        candi.AppendChild(nombre)

        Dim apellido As XmlElement = xmldoc.CreateElement("apellido")
        apellido.InnerText = "apellidonuevo"
        candi.AppendChild(apellido)


        Dim car As XmlElement = xmldoc.CreateElement("cargo")
        car.InnerText = "consejal"
        candi.AppendChild(car)


        Dim voto As XmlElement = xmldoc.CreateElement("voto")
        voto.InnerText = "0"
        candi.AppendChild(voto)


        Return candi
    End Function

    Public Sub AgregarDignidad()

        Dim path As String = "C:\Users\Usuario\Documents\Visual Studio 2013\Projects\SistemaVotaciones\votaciones.xml"
        Dim xmldoc As New XmlDocument()
        xmldoc.Load(path)
        Dim lista As XmlNodeList = xmldoc.GetElementsByTagName("candidato")
        Dim digni As XmlNode
        For Each candi As XmlNode In lista
            'Console.WriteLine(candi.Name & candi.Attributes(0).Value)
            For Each hijo As XmlNode In candi.ChildNodes
                If hijo.Name = "cargo" Then
                    digni = hijo
                End If
            Next
            If digni Is Nothing Then
                digni = xmldoc.CreateElement("cargo")
                candi.AppendChild(digni)
            End If
            digni.InnerText = "primer vocal"
            digni = Nothing
        Next
        xmldoc.Save(path)
    End Sub

End Class
