Imports System

Module Notas
    Private cantidad_notas, cantidad_alumnos, contador, contador2, bandera As Integer
    Private nombre_alumno, condicion As String
    Private suma_notas, mejor_promedio As Decimal
    Sub Main(args As String())

        CantidadAlumnos("Ingrese la cantidad de alumnos (no mas de 40): ")
        CantidadNotas("Ingrese la cantidad de notas (no mas de 4): ")

        Dim Nombres_Alumnos(cantidad_alumnos), Mejores_Alumnos(cantidad_alumnos) As String
        Dim Notas_Alumnos(cantidad_alumnos, cantidad_notas) As Decimal
        Dim Promedios(cantidad_alumnos) As Decimal

        contador = 0
        contador2 = 0
        Do
            NombreAlumno(Nombres_Alumnos)
            NotaAlumno(Nombres_Alumnos, Notas_Alumnos)
            contador += 1
        Loop Until contador = cantidad_alumnos

        CondicionAlumno(Nombres_Alumnos, Notas_Alumnos, Promedios)
        MejorPromedio(Nombres_Alumnos, Promedios, Mejores_Alumnos)
    End Sub
    Sub CantidadAlumnos(mensaje)
        Do
            Console.Write(mensaje)
            cantidad_alumnos = Console.ReadLine()
        Loop While cantidad_alumnos > 40
    End Sub
    Sub CantidadNotas(mensaje)
        Do
            Console.Write(mensaje)
            cantidad_notas = Console.ReadLine()
        Loop While cantidad_notas > 4
    End Sub
    Sub NombreAlumno(Nombres_Alumnos As Array)
        Do
            bandera = 0
            Console.Write("Ingrese el nombre del alumno {0} (debe tener 3 o mas caracteres, y sin repeticiones de nombres): ", contador + 1)
            Nombres_Alumnos(contador) = Console.ReadLine()
            nombre_alumno = Nombres_Alumnos(contador)
            For x = 0 To cantidad_alumnos
                If (Nombres_Alumnos(contador) = Nombres_Alumnos(x) And Nombres_Alumnos(contador) <> Nombres_Alumnos(contador)) Or (nombre_alumno.Length < 3) Then
                    bandera = 1
                    Exit For
                End If
            Next
        Loop While bandera = 1
    End Sub
    Sub NotaAlumno(Nombres_Alumnos As Array, Notas_Alumnos As Array)
        contador2 = 0
        Do
            Console.Write("Ingrese la nota {0} del alumno {1} (debe estar en el rango de 0 y 10): ", contador2 + 1, Nombres_Alumnos(contador))
            Notas_Alumnos(contador, contador2) = Console.ReadLine()
            If Notas_Alumnos(contador, contador2) < 0 Or Notas_Alumnos(contador, contador2) > 10 Then
                Console.WriteLine("Error, debe respetar los siguientes terminos")
            Else
                contador2 += 1
            End If
        Loop Until contador2 = cantidad_notas
    End Sub
    Sub CondicionAlumno(Nombres_Alumnos As Array, Notas_Alumnos As Array, Promedios As Array)
        For x = 0 To cantidad_alumnos - 1
            suma_notas = 0
            For y = 0 To cantidad_notas - 1
                suma_notas += Notas_Alumnos(x, y)
            Next
            Promedios(x) = suma_notas / cantidad_notas
            If Promedios(x) >= 6 Then
                condicion = "Aprobado"
            Else
                condicion = "Desaprobado"
            End If
            Console.WriteLine("Alumno {0} con un promedio de {1} esta {2} ", Nombres_Alumnos(x), Promedios(x), condicion)
        Next
    End Sub
    Sub MejorPromedio(Nombres_Alumnos As Array, Promedios As Array, Mejores_Alumnos As Array)
        mejor_promedio = Promedios(0)
        For x = 0 To cantidad_alumnos
            If Promedios(x) >= mejor_promedio Then
                mejor_promedio = Promedios(x)
            End If
        Next
        For x = 0 To cantidad_alumnos
            If Promedios(x) = mejor_promedio Then
                Mejores_Alumnos(x) = Nombres_Alumnos(x)
                Console.WriteLine("Mejor alumno: {0} con un promedio de: {1} ", Mejores_Alumnos(x), Promedios(x))
            End If
        Next
    End Sub
End Module
