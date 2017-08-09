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

namespace Frogger.Tester
{
    public class Tester
    {
        public static void RunTest()
        {
            Random randNum = new Random();

            Renderer.Renderer.InitializeRenderer();
            //Console.WriteLine(Renderer.RowCollection.RowCollection.Instance.Rows.First().ToString()); //bah maamu
            
            while (true)
            {
                for (int i = (int)RowID.Zero; i <= (int)RowID.Fifteenth; i++)
                {
                    Swamp.Instance.Row = GenerateNum(randNum, 1, 15);
                    Swamp.Instance.X = GenerateNum(randNum, 1, 35);
                    if (i == (int)RowID.Zero || i == (int)RowID.First || i == (int)RowID.Eighth || i == (int)RowID.Fifteenth)
                    {
                    }
                    else
                    {
                        LaneRow pesho = (LaneRow)RowCollection.Instance.Rows.ElementAt(i);

                        pesho.VehicleOnTheRow.X = GenerateNum(randNum, 20, 30);
                        pesho.VehicleOnTheRow.VehicleLength = GenerateNum(randNum, 1, 6);
                    }
                } 

                Renderer.Renderer.Execute();
                //Thread.Sleep(60);
                //Console.Clear();
            }


        }
        public static int GenerateNum(Random randNum, int min, int max)
        {
            return randNum.Next(min, max);
        }
    }
}
