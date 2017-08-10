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

            LaneRow pesho;


            while (true)
            {
                for (int i = (int)RowID.Zero; i <= (int)RowID.Fifteenth; i++)
                {
                    Swamp.Instance.Row = GenerateNum(randNum, 1, 15); //zaradi tova zabiva
                    Swamp.Instance.X = GenerateNum(randNum, 1, 35); //zaradi tova zabiva
                    if (i == (int)RowID.Zero || i == (int)RowID.First || i == (int)RowID.Eighth || i == (int)RowID.Fifteenth)
                    {
                    }
                    else
                    {
                        pesho = (LaneRow)RowCollection.Instance.Rows.ElementAt(i);

                        pesho.VehicleOnTheRow.X = VehicleMovement(pesho.VehicleOnTheRow.X);
                        pesho.VehicleOnTheRow.VehicleLength = GenerateNum(randNum, 1, 6);

                        //((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.X
                    }
                }

                Renderer.Renderer.Execute();
                //Thread.Sleep(1);
                //Console.Clear();
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
