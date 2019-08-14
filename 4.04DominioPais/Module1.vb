Module Module1
    Private Dominio_Paices As New Collection
    Private dominio As String
    Sub Main()
        CargarDominios()
        BuscarDominioDelPais("Ingrese el nombre del dominio de un pais para buscar (ENTER para salir): ")
    End Sub
    Sub CargarDominios()
        Dominio_Paices.Add("Argentina", "ar")
        Dominio_Paices.Add("Brasil", "br")
        Dominio_Paices.Add("Paraguay", "py")
        Dominio_Paices.Add("Uruguay", "uy")
        Dominio_Paices.Add("España", "es")
        Dominio_Paices.Add("Bolivia", "bo")
        Dominio_Paices.Add("Colombia", "co")
    End Sub
    Sub BuscarDominioDelPais(mensaje)
        Do
            Console.Write(mensaje)
            dominio = Console.ReadLine
            If dominio = "" Then
                Exit Sub
            ElseIf Dominio_Paices.Contains(dominio) Then
                Console.WriteLine("El nombre del país con ese dominio es : {0}", Dominio_Paices(dominio))
            Else
                Console.WriteLine("No existe un país con ese dominio.")
            End If
        Loop Until dominio = ""
    End Sub
End Module
