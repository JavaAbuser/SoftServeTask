using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    internal class ViewResolver
    {
        public static void EnterNumOfEntities(Ocean ocean) {
            Console.Write("Enter the number of obstacles: ");
            ocean.setNumObstacles(Convert.ToInt32(Console.ReadLine()));

            Console.Write("Enter the number of predators: ");
            ocean.setNumPredators(Convert.ToInt32(Console.ReadLine()));

            Console.Write("Enter the number of prey: ");
            ocean.setNumPrey(Convert.ToInt32(Console.ReadLine()));
        }

        public static void PrintInfo(Ocean ocean) {
            Console.WriteLine("\nNumber of obstacles is " + ocean.getNumObstacles());
            Console.WriteLine("Number of predators is " + ocean.numPredators);
            Console.WriteLine("Number of prey is " + ocean.numPrey);
        }

        public static void EnterNumOfRowsAndColumns(Ocean ocean) {
            Console.Write("Enter the count of rows: ");
            ocean.setNumRows(Convert.ToInt32(Console.ReadLine()));

            Console.Write("Enter the count of columns: ");
            ocean.setNumColumns(Convert.ToInt32(Console.ReadLine()));
        }

        public static void EnterOperations(Ocean ocean) {
            Console.WriteLine("\nEnter the number of operations: ");
            ocean.setNumOperations(Convert.ToInt32(Console.ReadLine()));
        }

        public static void PrintNumOfOperations(Ocean ocean) {
            Console.WriteLine("The number of operations: " + ocean.getNumOperations());
        }
    }
}
