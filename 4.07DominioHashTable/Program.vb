Imports System

Module DominioHashTable
    Private Dominio_Paices As New Hashtable
    Private opcion, pais, dominio As String
    Private bandera As Boolean
    Sub Main(args As String())
        CargarDominios()
        Menu()
    End Sub
    Sub CargarDominios()
        Dominio_Paices.Add("ar", "Argrntina")
        Dominio_Paices.Add("br", "Brasil")
        Dominio_Paices.Add("py", "Paraguay")
        Dominio_Paices.Add("uy", "Uruguay")
        Dominio_Paices.Add("es", "España")
        Dominio_Paices.Add("bo", "Bolivia")
        Dominio_Paices.Add("co", "Colombia")
    End Sub
    Sub Menu()
        Do
            Console.WriteLine(vbTab & vbTab & vbTab & "Seleccione una opción")
            Console.WriteLine("Total de paices cargados: {0}", Dominio_Paices.Count)
            Console.Write("1-Agregar" & vbCrLf & "2-Editar" & vbCrLf & "3-Eliminar" & vbCrLf & "4-Mostrar nombre del país y su dominio " & vbCrLf & "(ENTER para salir): ")
            opcion = Console.ReadLine
            If opcion = "" Then
                Exit Sub
            ElseIf opcion = "1" Then
                AgregarPaisYDominio()
            ElseIf opcion = "2" Then
                EditarPaisYDominio()
            ElseIf opcion = "3" Then
                EliminarPaisYDominio()
            ElseIf opcion = "4" Then
                MostrarNombresDePaicesCargados()
            Else
                Console.WriteLine(vbTab & "Opción incorrecta")
            End If
        Loop Until opcion = ""
    End Sub
    Sub AgregarPaisYDominio()
        Do
            bandera = False
            Console.Write("Ingrese el dominio del país a agregar: ")
            dominio = Console.ReadLine
            If Dominio_Paices.Contains(dominio) Then
                bandera = True
                Console.WriteLine(vbTab & "Ya existe un país con ese dominio")
            Else
                Console.Write("Ingrese el nombre del país a agregar: ")
                pais = Console.ReadLine
                Dominio_Paices.Add(pais, dominio)
                Console.Clear()
                Console.WriteLine(vbTab & "El país y su dominio han sido agregados")
            End If
        Loop Until bandera = False
    End Sub
    Sub EditarPaisYDominio()
        Do
            bandera = True
            Console.Write("Ingrese el dominio del país a editar: ")
            dominio = Console.ReadLine
            If Dominio_Paices.Contains(dominio) Then
                Dominio_Paices.Remove(dominio)
                Console.Write("Ingrese el nombre del nuevo país: ")
                pais = Console.ReadLine
                Console.Write("Ingrese el dominio del nuevo país: ")
                dominio = Console.ReadLine
                Dominio_Paices.Add(pais, dominio)
                Console.Clear()
                Console.WriteLine(vbTab & "El país y su dominio han sido modificados")
            Else
                Console.WriteLine(vbTab & "No se encontro un país con ese dominio")
                bandera = False
            End If
        Loop Until bandera = True
    End Sub
    Sub EliminarPaisYDominio()
        Do
            bandera = True
            Console.Write("Ingrese el dominio del país a eliminar: ")
            dominio = Console.ReadLine
            If Dominio_Paices.Contains(dominio) Then
                Dominio_Paices.Remove(dominio)
                Console.Clear()
                Console.WriteLine(vbTab & "El país y su dominio han sido eliminados")
            Else
                Console.WriteLine(vbTab & "No se encontro un país con ese dominio")
                bandera = False
            End If
        Loop Until bandera = True
    End Sub
    Sub MostrarNombresDePaicesCargados()
        Console.Clear()
        Console.WriteLine(vbTab & "Paices cargados")
        For Each elemento As DictionaryEntry In Dominio_Paices
            Console.WriteLine(elemento.Key & " " & elemento.Value)
        Next
    End Sub
End Module
