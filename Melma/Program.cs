using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melma
{
    class Program
    {        
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
