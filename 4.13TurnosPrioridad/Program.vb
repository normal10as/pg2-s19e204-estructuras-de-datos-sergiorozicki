Imports System

Module TurnosPrioridad
    Private Turnos As New LinkedList(Of String)
    Private opcion, nombre, ultima_embarazada, ultimo_anciano As String
    Sub Main(args As String())
        Menu()
    End Sub
    Sub Menu()
        Do
            Console.WriteLine("Total de clientes en espera: {0}", Turnos.Count)
            Console.WriteLine(vbTab & vbTab & "Ingrese una opción")
            Console.Write("1-Agregar cliente a la lista" & vbCrLf & "2-Despachar cliente" & vbCrLf & "(ENTER para salir): ")
            opcion = Console.ReadLine
            Select Case opcion
                Case 1
                    AgregarCienteALaLista()
                Case 2
                    DespacharCliente()
                Case Else
                    Exit Sub
            End Select
        Loop While opcion <> ""
    End Sub
    Sub DespacharCliente()
        If Turnos.Count > 0 Then
            Console.Clear()
            Console.WriteLine("El nombre del siguiente cliente a ser despachado es: {0}", Turnos(0))
            If Turnos(0) = ultimo_anciano Then
                ultimo_anciano = ""
            End If
            If Turnos(0) = ultima_embarazada Then
                ultima_embarazada = ""
            End If
            Turnos.RemoveFirst()
        Else
            Console.Clear()
            Console.WriteLine(vbTab & "No hay clientes en espera")
        End If
    End Sub
    Sub AgregarCienteALaLista()
        Console.WriteLine(vbTab & vbTab & "Ingrese la prioridad")
        Console.Write("1-Anciana/o" & vbCrLf & "2-Embarazada" & vbCrLf & "3-Sin prioridad: ")
        opcion = Console.ReadLine
        Select Case opcion
            Case 1
                Ancianos()
            Case 2
                Embarazadas()
            Case 3
                SinPrioridad()
            Case Else
                Console.Clear()
                Console.WriteLine(vbTab & vbTab & "Opción incorrecta")
        End Select
    End Sub
    Sub Ancianos()
        Console.Write("Ingrese el nombre del cliente: ")
        nombre = Console.ReadLine
        Turnos.AddFirst(nombre)
        ultimo_anciano = nombre
    End Sub
    Sub Embarazadas()
        Console.Write("Ingrese el nombre del cliente: ")
        nombre = Console.ReadLine
        If ultima_embarazada = "" Then
            ultima_embarazada = nombre
            If ultimo_anciano = "" Then
                Turnos.AddFirst(nombre)
            Else
                Turnos.AddAfter(Turnos.FindLast(ultimo_anciano), nombre)
            End If
        Else
            If ultimo_anciano = "" Then
                Turnos.AddFirst(nombre)
            Else
                Turnos.AddAfter(Turnos.FindLast(ultima_embarazada), nombre)
            End If
        End If
    End Sub
    Sub SinPrioridad()
        Console.Write("Ingrese el nombre del cliente: ")
        nombre = Console.ReadLine
        Turnos.AddLast(nombre)
    End Sub
End Module
