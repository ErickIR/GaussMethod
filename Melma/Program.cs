using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melma
{
    class Program
    {


        class GaussMatrix
        {
            public float[][] matrix { get; private set; }
            public float[] vector { get; private set; }
            public float[] solucion { get; private set; }
            private int tamMatriz;

            public GaussMatrix(int tamMatriz)
            {
                this.tamMatriz = tamMatriz;
                vector = new float[tamMatriz];
                solucion = new float[tamMatriz];
                
            }

            public void IntroducirElementos()
            {
                matrix = IniciarMatriz(tamMatriz);
                Console.WriteLine("Introduzca la matriz de coeficientes y el vector solucion: ");
                for(int i = 0;i < tamMatriz; i++)
                {
                    for(int j = 0;j < tamMatriz; j++)
                    {
                        Console.WriteLine("Introduzca el elemento [{0}], [{1}]: ", i.ToString(), j.ToString());
                        matrix[i][j] = int.Parse(Console.ReadLine());
                    }
                    Console.WriteLine("Introduzca el vector solucion: S[{0}]:", i.ToString());
                    vector[i] = int.Parse(Console.ReadLine());
                }
            }

            public float[] ObtenerSoluciones()
            {
                EliminacionGauss();
                SustitucionAtras();
                return solucion;
            }

            private void EliminacionGauss()
            {
                for(int i = 0;i < tamMatriz; i++)
                {
                    for(int j = i + 1;j < tamMatriz; j++)
                    {
                        float z = (matrix[j][i] / matrix[i][i]);
                        vector[j] -= (z * vector[i]);
                        for(int k = 0;k < tamMatriz; k++)
                        {
                            matrix[j][k] -= (z * matrix[i][k]);
                        }
                    }
                }
            }

            private void SustitucionAtras()
            {
                solucion[tamMatriz - 1] = vector[tamMatriz - 1] / matrix[tamMatriz - 1][tamMatriz - 1];
                for(int i = tamMatriz - 2;i > -1; i--)
                {
                    float suma = 0;
                    for(int c = 0;c < tamMatriz; c++)
                    {
                        suma += matrix[i][c] * solucion[c];
                    }
                    solucion[i] = (vector[i] - suma) / matrix[i][i];
                }
            }

            private float[][] IniciarMatriz(int n)
            {
                float[][] matrix = new float[n][];
                for (int i = 0; i < n; i++)
                    matrix[i] = new float[n];
                return matrix;
            }

            public void PrintMatriz()
            {
                for (int i = 0; i < tamMatriz; i++)
                {
                    Console.Write("[");
                    for (int j = 0; j < tamMatriz; j++)
                    {
                        Console.Write("{0},", matrix[i][j]);
                    }
                    Console.Write("]");
                    Console.Write("[{0}]", vector[i]);
                    Console.WriteLine("[{0}]", solucion[i]);
                }
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca el valor de tamMatriz: ");
            bool c = int.TryParse(Console.ReadLine(), out int tamMatriz);

            GaussMatrix matriz = new GaussMatrix(tamMatriz);
            matriz.IntroducirElementos();
            matriz.ObtenerSoluciones();
            matriz.PrintMatriz();
            
            Console.ReadLine();
        }
    }
}
