using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace A_Star
{
   
    class Program
    {
        static void Main(string[] args)
        {
            int[,] map = new int[,]
       {
                { 0, 0, 0, 1, 0, 0},
                { 0, 1, 1, 0, 0, 0},
                { 0, 0, 0, 1, 0, 0},
                { 0, 0, 1, 0, 0, 0},
                { 0, 0, 0, 0, 1, 0},
                { 0, 0, 0, 0, 1, 0}
       };

            PathFinding pathFinding = new PathFinding(map);
            List<Node> path = pathFinding.CalculatePath(0, 0, 5, 5);
            if(path.Count == 0)
            {
                Console.WriteLine("Khong tim duoc duong di");
            }   
            else
            {
                Console.WriteLine("Tim dc duong di "+path.Count);
                Console.WriteLine("Duong di :");
                foreach (Node node in path)
                {
                    Console.Write("(" + node.x + "," + node.y + ")=>");
                }    
            }    
        }
    }
}