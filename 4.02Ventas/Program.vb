Imports System

Module Ventas
    Sub Main(args As String())
        Dim id_producto = New Integer() {1, 2, 3, 4, 5}
        Dim descripcion_producto = New String() {"arroz", "gaseosa", "pan", "fideo", "harina"}
        Dim precio_producto = New Decimal() {15.5, 80, 40, 50, 43.4}
        Dim codigo_producto, bandera, total_venta_producto, total_general, cantidad As Integer
        Do
            Console.Write("Ingrese el codigo del producto (0 para finalizar): ")
            codigo_producto = Console.ReadLine()
            If codigo_producto = 0 Then
                Exit Do
            End If
            bandera = 0
            For x = 0 To id_producto.Length - 1
                If codigo_producto = id_producto(x) Then
                    Console.WriteLine("Descripción: {0}", descripcion_producto(x))
                    Console.WriteLine("Precio unitario: {0}", precio_producto(x))
                    Console.Write("Ingrese cantidad: ")
                    cantidad = Console.ReadLine()
                    total_venta_producto = cantidad * precio_producto(x)
                    Console.WriteLine("Total por ese producto: {0}", total_venta_producto)
                    total_general += total_venta_producto
                    Console.WriteLine("Total general: {0}", total_general)
                    bandera = 1
                End If
            Next
            If bandera = 0 Then
                Console.WriteLine("Error, el producto ingresado no existe")
            End If
        Loop While codigo_producto
    End Sub
End Module
