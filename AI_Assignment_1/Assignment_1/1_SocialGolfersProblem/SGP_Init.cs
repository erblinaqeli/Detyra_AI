using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_1._1_SocialGolfersProblem
{
    public class SGP_Init
    {
        public static void Drive()
        {
            Console.WriteLine("---the Social Game Player---");
            Console.WriteLine("Choose the method for trying to solve this social golfers game\n[1-BFS, 2-DFS, 3-BackTracking : ");
            var input = Console.ReadLine();
            Console.WriteLine("\n");
            var number = 0;
            if (Int32.TryParse(input, out number))
            {
                switch (number)
                {
                    case 1://BFS
                        SGP_BFS_Init.Init_Main();
                        break;
                    case 2://DFS
                        SGP_DFS_Init.Init_Main();
                        break;
                    case 3://Backtracking
                        SGP_Backtracking.Main_SGP_Backtracking();
                        break;
                   
                }
            }
            else
                Console.WriteLine("Please, choose any method!");
        }
    }
}
