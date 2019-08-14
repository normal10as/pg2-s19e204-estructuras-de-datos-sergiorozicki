Imports System

Module Turnos
    Private opcion, nombre_cliente As String
    Private Turnos As New Queue
    Sub Main(args As String())
        Menu()
    End Sub
    Sub Menu()
        Do
            Console.WriteLine("Total de clientes en espera: {0}", Turnos.Count)
            Console.WriteLine(vbTab & vbTab & "Ingrese una opción")
            Console.Write("1- Agregar cliente a la lista" & vbCrLf & "2-Despachar cliente" & vbCrLf & "(ENTER para salir): ")
            opcion = Console.ReadLine
            If Turnos.Count > 0 And opcion <> "" Then
                Console.WriteLine("Los nombres de los clientes son")
                For Each clientes In Turnos
                    Console.WriteLine(clientes)
                Next
            Else
                Console.WriteLine("No hay clientes en espera")
            End If
            Select Case opcion
                Case ""
                    Exit Do
                Case "1"
                    AgregarClienteALaLista()
                Case "2"
                    DespacharCliente()
                Case Else
                    Console.WriteLine(vbTab & "Opción incorrecta")
            End Select
        Loop While opcion <> ""
    End Sub
    Sub AgregarClienteALaLista()
        Console.Clear()
        Console.Write("Ingrese el nombre del cliente: ")
        nombre_cliente = Console.ReadLine
        Turnos.Enqueue(nombre_cliente)
    End Sub
    Sub DespacharCliente()
        If Turnos.Count > 0 Then
            Console.Write("El siguiente turno es de: {0}", Turnos.Dequeue & vbCrLf & "Precine una tecla para continuar...")
            Console.ReadLine()
        Else
            Console.Clear()
            Console.WriteLine("No hay clientes en espera")
        End If
    End Sub
End Module
