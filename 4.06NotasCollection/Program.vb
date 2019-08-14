Imports System

Module NotasCollection
    Private cantidad_notas, cantidad_alumnos, contador, contador2 As Integer
    Private bandera As Boolean
    Private nombre_alumno, condicion As String
    Private suma_notas, mejor_promedio As Decimal
    Private Nombres_Alumnos, Mejores_Alumnos, Promedios As New ArrayList
    Sub Main(args As String())

        CantidadAlumnos("Ingrese la cantidad de alumnos (no mas de 40): ")
        CantidadNotas("Ingrese la cantidad de notas (no mas de 4): ")
        Dim Notas_Alumnos(cantidad_alumnos, cantidad_notas) As Decimal
        contador = 0
        contador2 = 0
        Do
            NombreAlumno()
            NotaAlumno(Notas_Alumnos)
            contador += 1
        Loop Until contador = cantidad_alumnos

        CondicionAlumno(Notas_Alumnos)
        MejorPromedio()
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
    Sub NombreAlumno()
        Do
            bandera = False
            Console.Write("Ingrese el nombre del alumno {0} (debe tener 3 o mas caracteres, y sin repeticiones de nombres): ", contador + 1)
            nombre_alumno = Console.ReadLine
            If Nombres_Alumnos.Contains(nombre_alumno) Or nombre_alumno.Length < 3 Then
                bandera = True
            End If
            If bandera = False Then
                Nombres_Alumnos.Add(nombre_alumno)
            End If
        Loop While bandera = True
    End Sub
    Sub NotaAlumno(Notas_Alumnos As Array)
        contador2 = 0
        Do
            Console.Write("Ingrese la nota {0} del alumno {1} (debe estar en el rango de 0 y 10): ", contador2 + 1, Nombres_Alumnos.Item(contador))
            Notas_Alumnos(contador, contador2) = Console.ReadLine
            If Notas_Alumnos(contador, contador2) < 0 Or Notas_Alumnos(contador, contador2) > 10 Then
                Console.WriteLine("Error, debe respetar los siguientes terminos")
            Else
                contador2 += 1
            End If
        Loop Until contador2 = cantidad_notas
    End Sub
    Sub CondicionAlumno(Notas_Alumnos As Array)
        For x = 0 To cantidad_alumnos - 1
            suma_notas = 0
            For y = 0 To cantidad_notas - 1
                suma_notas += Notas_Alumnos(x, y)
            Next
            Promedios.Add(suma_notas / cantidad_notas)
            If Promedios.Item(x) >= 6 Then
                condicion = "Aprobado"
            Else
                condicion = "Desaprobado"
            End If
            Console.WriteLine("Alumno {0} con un promedio de {1} esta {2} ", Nombres_Alumnos.Item(x), Promedios.Item(x), condicion)
        Next
    End Sub
    Sub MejorPromedio()
        mejor_promedio = Promedios.Item(0)
        For x = 0 To cantidad_alumnos - 1
            If Promedios.Item(x) >= mejor_promedio Then
                mejor_promedio = Promedios.Item(x)
            End If
        Next
        For x = 0 To cantidad_alumnos - 1
            If Promedios.Item(x) = mejor_promedio Then
                Mejores_Alumnos.Add(Nombres_Alumnos.Item(x))
            End If
        Next
        For Each mejor_alumno In Mejores_Alumnos
            Console.WriteLine("Mejor alumno: {0} con un promedio de: {1}", mejor_alumno, mejor_promedio)
        Next
    End Sub
End Module