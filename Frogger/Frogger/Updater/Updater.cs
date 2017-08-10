using Frogger.Objects.Models;
using Frogger.Renderer.Enums;
using Frogger.Renderer.Models;
using Frogger.Renderer.RowCollection;
using Frogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Updater
{
    public static class Updater
    {
        public static void StartGame()
        {
            ////казвам количките да тръгват от нулата (най-ляво)
            //short vehiclePosition = 0;

            while (Swamp.Instance.IsAlive)
            {
                Renderer.Renderer.Execute();

                Updater.FroggerMover();

                //smenqт се стойностите и евентиално IsAlive-а на жабата

                for (int i = (int)RowID.Zero; i <= (int)RowID.Fifteenth; i++)
                {
                    //Swamp.Instance.Row = GenerateNum(randNum, 1, 16); //може да е на между редове с индекси 1 и 15
                    //Swamp.Instance.X = GenerateNum(randNum, 0, 94); // може да е на позоция между 0 и 94 включително тя няма как със стрелките да излезе странично примерно извън екрана

                    if (i == (int)RowID.Zero || i == (int)RowID.First || i == (int)RowID.Eighth || i == (int)RowID.Fifteenth)
                    {
                    }
                    else
                    {
                        ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.VehicleLength = 2; //GenerateNum(randNum, 1, 4);

                        if (((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.X + 1 > 99)
                        {
                            ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.X = 0; //GenerateNum(randNum, 0, 99);
                        }
                        else
                        {
                            ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.X++;
                        }

                        //беше бавно, написах това и стана бързо???
                    }
                }
                //vehiclePosition++;
            }
        }

        public static void FroggerMover()
        {
            while (Console.KeyAvailable)
            {
                //reading the keys in the tester class, acknowledging the borders of the screen
                ConsoleKeyInfo key = Console.ReadKey();
                
                if (key.Key == ConsoleKey.UpArrow &&
                    Swamp.Instance.Row > 1) //so that it goes no further than the last safe zone
                {
                    Swamp.Instance.Row--;
                }
                else if (key.Key == ConsoleKey.DownArrow &&
                    Swamp.Instance.Row < 15)
                {
                    Swamp.Instance.Row++;
                }
                else if (key.Key == ConsoleKey.LeftArrow &&
                    Swamp.Instance.X > 2)
                {
                    Swamp.Instance.X -= GlobalConstants.frogStepToTheSides;
                }
                else if (key.Key == ConsoleKey.RightArrow &&
                    Swamp.Instance.X < 95)
                {
                    Swamp.Instance.X += GlobalConstants.frogStepToTheSides;
                }
            }
        }
    }
}
