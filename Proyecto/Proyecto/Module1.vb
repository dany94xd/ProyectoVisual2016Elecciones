Module Module1

    Sub Main()


        Console.WriteLine("PROYECTO INICIALIZADO")

        Dim login As logeo = New logeo
        Dim mesa As Mesa = New Mesa("0001")
        mesa.cargarlistadevotantes()


        login.MenuUSER()


        Console.ReadLine()


    End Sub

End Module
