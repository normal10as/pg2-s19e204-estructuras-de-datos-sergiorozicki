Imports System

Module Chipas
    Private Nombre_Empleados As New SortedList(Of String, String)
    Private Sergio_Rozicki As New List(Of Integer)
    Private Karen_Molinos As New List(Of Integer)
    Private Roque_Gillalva As New List(Of Integer)
    Private clave_empleado As String
    Private cantida_chipas, produccion_sergio, produccion_karen, produccion_roque, total_sergio, total_karen, total_roque As UInteger
    Private dia_de_semana As Byte
    Sub Main(args As String())
        CargarNombreDeEmpleados()
        CargoDiasDeSemanas()
        IngresoDatosEmpleado()
    End Sub
    Sub CargarNombreDeEmpleados()
        Nombre_Empleados.Add("ser", "Sergio Rozicki")
        Nombre_Empleados.Add("kar", "Karen Molinos")
        Nombre_Empleados.Add("roq", "Roque Guillalva")
    End Sub
    Sub CargoDiasDeSemanas()
        For x = 0 To 6
            Sergio_Rozicki.Add(0)
            Karen_Molinos.Add(0)
            Roque_Gillalva.Add(0)
        Next
    End Sub
    Sub IngresoDatosEmpleado()
        Do
            Console.Write("Ingrese la clave del empleado (ENTER para salir): ")
            clave_empleado = Console.ReadLine
            If Nombre_Empleados.ContainsKey(clave_empleado) Then
                Console.Write("Nombre y apellido del empleado ingresado: {0}", Nombre_Empleados.Item(clave_empleado) & vbCrLf)
                CargarProduccion()
            Else
                Console.Clear()
                Console.WriteLine(vbTab & "No existe un cliente con esa clave")
            End If
        Loop While clave_empleado <> ""
    End Sub
    Sub CargarProduccion()
        Console.Write("Ingrese la cantidad de chipas producidas: ")
        cantida_chipas = Console.ReadLine
        Console.Write("Ingrese el dia de semana: ")
        dia_de_semana = Console.ReadLine
        Select Case clave_empleado
            Case "ser"
                produccion_sergio = cantida_chipas + Sergio_Rozicki.Item(dia_de_semana)
                Sergio_Rozicki.Insert(dia_de_semana, produccion_sergio)
            Case "kar"
                produccion_karen = cantida_chipas + Karen_Molinos.Item(dia_de_semana)
                Karen_Molinos.Insert(dia_de_semana, produccion_karen)
            Case "roq"
                produccion_roque = cantida_chipas + Roque_Gillalva.Item(dia_de_semana)
                Roque_Gillalva.Insert(dia_de_semana, produccion_roque)
        End Select
        Console.Clear()
        ImprimirProduccion()
    End Sub
    Sub ImprimirProduccion()
        total_sergio = 0
        total_karen = 0
        total_roque = 0
        Console.WriteLine(vbTab & "Producción por empleado")
        For Each sergio In Sergio_Rozicki
            total_sergio += sergio
        Next
        Console.Write("Empleado {0} con un total de {1} ", Nombre_Empleados.Values(2), total_sergio & vbCrLf)
        For Each karen In Karen_Molinos
            total_karen += karen
        Next
        Console.Write("Empleado {0} con un total de {1} ", Nombre_Empleados.Values(0), total_karen & vbCrLf)
        For Each roque In Roque_Gillalva
            total_roque += roque
        Next
        Console.Write("Empleado {0} con un total de {1} ", Nombre_Empleados.Values(1), total_roque & vbCrLf)
    End Sub
End Module
