Imports System

Module Medida
    Private Arreglo(4), sumatoria, desviacion, medida As Integer
    Sub Main(args As String())
        CargarDatos()
        CalcularMedida()
        ImprimirElementos()
    End Sub
    Sub CargarDatos()
        For x = 0 To Arreglo.Length - 1
            Console.Write("Ingrese un valor: ")
            Arreglo(x) = Console.ReadLine()
            sumatoria += Arreglo(x)
        Next
    End Sub
    Sub CalcularMedida()
        medida = sumatoria / Arreglo.Length
        Console.WriteLine("La medida de los elementos es: " & medida)
    End Sub
    Sub ImprimirElementos()
        For x = 0 To Arreglo.Length - 1
            Console.WriteLine("Elemento {0} su desviacion {1}", Arreglo(x), Arreglo(x) - medida)
        Next
    End Sub
End Module
