using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PruebaCSharpJunior
{
    public class Matriz
    {
        public readonly int[][] arreglo = new int[0][];

        public List<string> tamaño(string inputFile)
        {
            List<string> lineas = new List<string>();
            using (var lector = new StreamReader(inputFile))
            {
                while (!lector.EndOfStream)
                {
                    var linea = lector.ReadLine();
                    if (!string.IsNullOrWhiteSpace(linea))
                    {
                        lineas.Add(linea);
                    }
                }
            }
            return lineas;
        }

        public int[][] leerMatriz(string archivo)
        {
            var lineas = tamaño(archivo);
            if (lineas.Count == 0) return arreglo;
            int[][] matriz = new int[lineas.Count][];
            for (int i = 0; i < lineas.Count; i++)
            {
                var linea = lineas[i];
                matriz[i] = linea.Split(',').Select(x => x.Trim()).Select(x => int.Parse(x)).ToArray();
            }
            return matriz;
        }

        public int[][] transponer(int[][] matriz)
        {
            if (matriz.Length == 0) return arreglo;
            int filas = matriz.Length; int columnas = matriz[0].Length;
            int[][] transpuesta = new int[columnas][];
            for (int columna = 0; columna < columnas; columna++)
            {
                transpuesta[columna] = new int[filas];
                for (int fila = 0; fila < filas; fila++)
                {
                    transpuesta[columna][fila] = matriz[fila][columna];
                }
            }
            return transpuesta;
        }

        public void escribirMatriz(int[][] matriz, string archivoSalida)
        {
            using (var escritor = new StreamWriter(archivoSalida))
            {
                for (int fila = 0; fila < matriz.Length; fila++)
                {
                    escritor.WriteLine(string.Join(",", matriz[fila]));
                }
            }
        }

    }
}
