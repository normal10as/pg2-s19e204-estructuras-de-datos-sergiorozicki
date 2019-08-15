Imports System

Module Bebidas
    Private OrdenarListaDescripcion As New SortedDictionary(Of String, String)
    Private OrdenarListaPrecios As New SortedDictionary(Of String, UInteger)
    Private Descripcion_Bebidas As New Dictionary(Of String, String)
    Private Precios_Bebidas As New Dictionary(Of String, UInteger)
    Private bandera As Boolean
    Private precio_bebida As UInteger
    Private descripcion_bebida, clave_bebida, opcion As String
    Sub Main(args As String())
        CargarDescripcionYClaveBebidas()
        CargarPrecioBebidas()
        Menu()
    End Sub
    Sub CargarDescripcionYClaveBebidas()
        Descripcion_Bebidas.Add("ga", "Gaseosa")
        Descripcion_Bebidas.Add("ce", "Cerveza")
        Descripcion_Bebidas.Add("vi", "Vino")
    End Sub
    Sub CargarPrecioBebidas()
        Precios_Bebidas.Add("ga", 50)
        Precios_Bebidas.Add("ce", 80)
        Precios_Bebidas.Add("vi", 70)
    End Sub
    Sub Menu()
        Do
            Console.Write("1-Agregar bebida" & vbCrLf & "2-Editar descripción de la bebida" & vbCrLf & "Editar precio de la bebida " & vbCrLf & "4-Eliminar" & vbCrLf & "5-Mostrar descripcion, clave y precio de bebidas " & vbCrLf & "(ENTER para salir): ")
            opcion = Console.ReadLine
            Select Case opcion
                Case 1
                    AgregaBebidasALaLista()
                Case 2
                    EditarDescripcionBebida()
                Case 3
                    EditarPrecioBebida()
                Case 4
                    EliminarBebida()
                Case 5
                    MostrarListadoOrdenadoDeBebidas()
                Case Else
                    Console.Clear()
                    Console.WriteLine(vbTab & "Opción incorrecta")
            End Select
        Loop While opcion <> ""
    End Sub
    Sub AgregaBebidasALaLista()
        Do
            bandera = False
            Console.Write("Ingrese la clave de la bebida a agregar: ")
            clave_bebida = Console.ReadLine
            If Descripcion_Bebidas.ContainsKey(clave_bebida) Then
                bandera = True
                Console.WriteLine(vbTab & "Ya existe una bebida con esa clave")
            Else
                Console.Write("Ingrese la descripción de la bebida a agregar: ")
                descripcion_bebida = Console.ReadLine
                Descripcion_Bebidas.Add(clave_bebida, descripcion_bebida)
                Console.Write("Ingrese el precio de la bebida: ")
                precio_bebida = Console.ReadLine
                Console.Clear()
                Console.WriteLine(vbTab & "Se agregó la bebida a la lista")
            End If
        Loop Until bandera = False
    End Sub
    Sub EditarDescripcionBebida()
        Do
            bandera = False
            Console.Write("Ingrese la clave de la bebida a editar: ")
            clave_bebida = Console.ReadLine
            If Descripcion_Bebidas.ContainsKey(clave_bebida) Then
                Descripcion_Bebidas.Remove(clave_bebida)
                Console.Write("Ingrese la nueva descripción: ")
                descripcion_bebida = Console.ReadLine
                Descripcion_Bebidas.Add(clave_bebida, descripcion_bebida)
                Console.Clear()
                Console.WriteLine(vbTab & "Se editó la descripción de la bebida con éxito")
            Else
                bandera = True
                Console.WriteLine(vbTab & "No existe una bebida con esa clave")
            End If
        Loop Until bandera = False
    End Sub
    Sub EditarPrecioBebida()
        Do
            bandera = False
            Console.Write("Ingrese la clave de la bebida a editar: ")
            clave_bebida = Console.ReadLine
            If Precios_Bebidas.ContainsKey(clave_bebida) Then
                Precios_Bebidas.Remove(clave_bebida)
                Console.Write("Ingrese el nuevo precio de la bebida: ")
                precio_bebida = Console.ReadLine
                Precios_Bebidas.Add(clave_bebida, precio_bebida)
                Console.Clear()
                Console.WriteLine(vbTab & "Se editó el precio de la bebida con éxito")
            Else
                bandera = True
                Console.WriteLine(vbTab & "No existe una bebida con esa clave")
            End If
        Loop Until bandera = False
    End Sub
    Sub EliminarBebida()
        Do
            bandera = False
            Console.Write("Ingrese la clave de la bebida a eliminar: ")
            clave_bebida = Console.ReadLine
            If Precios_Bebidas.ContainsKey(clave_bebida) Then
                Precios_Bebidas.Remove(clave_bebida)
                Descripcion_Bebidas.Remove(clave_bebida)
                Console.Clear()
                Console.WriteLine(vbTab & "Se eliminó la bebida con éxito")
            Else
                bandera = True
                Console.WriteLine(vbTab & "No existe una bebida con esa clave")
            End If
        Loop Until bandera = False
    End Sub
    Sub MostrarListadoOrdenadoDeBebidas()
        Console.Clear()
        Console.WriteLine(vbTab & "Bebidas cargadas")
        For Each elemento As KeyValuePair(Of String, String) In Descripcion_Bebidas
            OrdenarListaDescripcion(elemento.Key) = Descripcion_Bebidas(elemento.Key)
        Next
        For Each elemento As KeyValuePair(Of String, String) In OrdenarListaDescripcion
            Console.WriteLine("Codigo: {0} Descripción: {1}", elemento.Key, elemento.Value)
        Next
        For Each elemento As KeyValuePair(Of String, UInteger) In Precios_Bebidas
            OrdenarListaPrecios(elemento.Key) = Precios_Bebidas(elemento.Key)
        Next
        For Each elemento As KeyValuePair(Of String, UInteger) In OrdenarListaPrecios
            Console.WriteLine("Codigo: {0} Precio: {1}", elemento.Key, elemento.Value)
        Next
    End Sub
End Module
