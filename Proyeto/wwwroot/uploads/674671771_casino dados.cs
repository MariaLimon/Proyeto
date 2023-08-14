using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicassssssss
{
    class Program
    {
        static void Main(string[] args)
        {
            int opc = 0;
            int cantidad = 0;
            int cantidad2;
            int bill200 = 0;
            int bill100 = 0;
            int bill50 = 0;

            do
            {

                Console.WriteLine("Seleccione la opcion a realizar: 1.- resalizar deposito, 2.- realizar retiro, 3.- consultar saldo, 4.- salir.");
                opc = Convert.ToInt32(Console.ReadLine());

                if (opc == 1)
                {
                    Console.WriteLine("Ingrese la cantidad a depositar");
                    cantidad2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("la cantidad depositada fue " + cantidad2);
                    cantidad = cantidad + cantidad2;
                }

                else if (opc == 2)
                {
                    Console.WriteLine("Ingrese la cantidad a retitar");
                    cantidad2 = Convert.ToInt32(Console.ReadLine());
                    bill200 = cantidad2 / 200;
                    int cantidadresi = cantidad2 % 200;

                    bill100 = cantidadresi / 100;
                    cantidadresi = cantidadresi % 100;

                    bill50 = cantidadresi / 50;
                    cantidadresi = cantidadresi % 50;

                    Console.WriteLine("la cantidad retirada es " + cantidad2 + " tome su dinero");
                    Console.WriteLine($"Billetes de $200 {bill200}, billetes de $100 {bill100}, billetes de $50 {bill50}");
                    cantidad = cantidad - cantidad2;
                }

                else if (opc == 3)
                {
                    Console.WriteLine("su saldo disponible es " + cantidad);
                }

                else if (opc == 4)
                {
                    Console.WriteLine("Saliendo del sistema, presione enter para finalizar");
                }

                else
                {
                    Console.WriteLine("Seleccione la opcion correcta");
                }
                Console.ReadLine();

            } while (opc != 4);
        }

    }
}
