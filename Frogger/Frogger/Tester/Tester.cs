using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frogger;
using System.Threading;
using Frogger.Objects.Models;
using Frogger.Renderer.Enums;
using Frogger.Renderer.RowCollection;
using Frogger.Renderer.Contracts;
using Frogger.Renderer;
using Frogger.Renderer.Models;
using Frogger.Utils;

namespace Frogger.Tester
{
    public class Tester
    {
        public static void RunTest()
        {
            Random randNum = new Random();

            Renderer.Renderer.InitializeRenderer();

            while (true)
            {
                for (int i = (int)RowID.Zero; i <= (int)RowID.Fifteenth; i++)
                {
                    Swamp.Instance.Row = GenerateNum(randNum, 1, 16); //може да е на между редове с индекси 1 и 15
                    Swamp.Instance.X = GenerateNum(randNum, 0, 94); // може да е на позоция между 0 и 94 включително тя няма как със стрелките да излезе странично примерно извън екрана
                    
                    if (i == (int)RowID.Zero || i == (int)RowID.First || i == (int)RowID.Eighth || i == (int)RowID.Fifteenth)
                    {
                    }
                    else
                    {
                        ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.VehicleLength = GenerateNum(randNum, 1, 4);
                        ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.X = GenerateNum(randNum, 0, 99);
                    }
                }

                Renderer.Renderer.Execute();
                //Thread.Sleep(100);
                //break;
                
            }

            
                
                





        }
        public static int GenerateNum(Random randNum, int min, int max)
        {
            return randNum.Next(min, max);
        }

        private static int VehicleMovement(int input)
        {
            int result = input - GenerateNum(new Random(), 5, 15);
            if (input < 0)
            {
                result = 99;
            }
            else
            {
                return result;
            }
            return result;
        }

    }
}
