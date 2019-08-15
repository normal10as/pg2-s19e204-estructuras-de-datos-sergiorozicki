Imports System

Module Zeverla
    Private frase As String
    Private Invertir_Frase As New Stack
    Sub Main(args As String())
        IngresarFrase("Ingrese una palabra o frase: ")
        InvertirFrase()
    End Sub
    Sub IngresarFrase(mensaje)
        Console.Write(mensaje)
        frase = Console.ReadLine
    End Sub
    Sub InvertirFrase()
        For x = 0 To frase.Length - 1
            Invertir_Frase.Push(frase(x))
        Next
        Console.Write("La frase invertida es: ")
        For Each x In Invertir_Frase
            Console.Write(x)
        Next
    End Sub
End Module
