using Frogger.Objects.Models;
using Frogger.Renderer;
using Frogger.Renderer.Enums;
using Frogger.Renderer.Models;
using Frogger.Renderer.RowCollection;
using Frogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frogger.Engine.Screens;
using Frogger.Renderer;

namespace Frogger.Updater
{
    public static class Updater
    {
        public static void StartGame()
        {
<<<<<<< HEAD
=======
            ////казвам количките да тръгват от нулата (най-ляво)
            //short vehiclePosition = 0;
            int gameSpeed = ((InfoRow)RowCollection.Instance.Rows.ElementAt(0)).Speed;
>>>>>>> beb5c461bd383e18d336893f70a6caf11166266e
            while (Swamp.Instance.IsAlive)
            {
                gameSpeed = ((InfoRow)RowCollection.Instance.Rows.ElementAt(0)).Speed;
                Renderer.Renderer.Execute();
                //ConsoleKeyInfo stamat = Console.ReadKey();
                FroggerMover();

<<<<<<< HEAD
                //понеже има главно две групи редове с колички, режа for цикъла на два for цикъла, така, че да не правя
                //излишни обхождания и проверки, а и за мааалък микро performance boost
                for (int i = (int)RowID.Second; i <= (int)RowID.Seventh; i++)
                {
                    VehicleMover(i);
=======
                FroggerMover();
                ScoreUpdater();
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
                        //((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.VehicleLength = 2; //GenerateNum(randNum, 1, 4);

                        if (((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.X + 1 > 91)
                        {
                            VehicleSpeedModifier((LaneRow)RowCollection.Instance.Rows.ElementAt(i));
                            VehicleLengthModifier((LaneRow)RowCollection.Instance.Rows.ElementAt(i));
                            ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.X = 0; //GenerateNum(randNum, 0, 99);
                        }
                        else
                        {
                            int tempSpeed = ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.Speed;
                            int currentVehiclePosition = ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.X;
                            int currentVehicleLengt = ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.VehicleLength;

                            if ((currentVehiclePosition  + currentVehicleLengt + gameSpeed) <= 97)
                            {
                                ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.X += tempSpeed + gameSpeed;
                            }
                            
                        }

                        //беше бавно, написах това и стана бързо???
                    }
>>>>>>> beb5c461bd383e18d336893f70a6caf11166266e
                }
                for (int i = (int)RowID.Ninth; i <= (int)RowID.Fourteenth; i++)
                {
                    VehicleMover(i);
                }

                CollisionDetector();
                ScoreUpdater();
            }
            Console.Clear();
            Console.WriteLine(GlobalConstants.gameOverFrogger);
            Environment.Exit(0);
        }

        private static void FroggerMover()
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
                    Swamp.Instance.X < 93)
                {
                    Swamp.Instance.X += GlobalConstants.frogStepToTheSides;
                }
<<<<<<< HEAD
                else if (key.Key == ConsoleKey.OemMinus &&
=======
                else if (key.Key == ConsoleKey.OemMinus && 
>>>>>>> beb5c461bd383e18d336893f70a6caf11166266e
                        ((InfoRow)RowCollection.Instance.Rows.ElementAt(0)).Speed > 0)
                {
                    ((InfoRow)RowCollection.Instance.Rows.ElementAt(0)).Speed--;
                }
                else if (key.Key == ConsoleKey.OemPlus &&
                        ((InfoRow)RowCollection.Instance.Rows.ElementAt(0)).Speed < 4)
                {
                    ((InfoRow)RowCollection.Instance.Rows.ElementAt(0)).Speed++;
                }
            }
        }

<<<<<<< HEAD
        private static void CollisionDetector()
        {
            if ((Swamp.Instance.Row >= (int)RowID.Second && Swamp.Instance.Row <= (int)RowID.Seventh)
                ||
                (Swamp.Instance.Row >= (int)RowID.Ninth && Swamp.Instance.Row <= (int)RowID.Fourteenth))
            {
                int vehicleStart = ((LaneRow)RowCollection.Instance.Rows.ElementAt(Swamp.Instance.Row)).VehicleOnTheRow.X;
                int vehicleEnd = ((LaneRow)RowCollection.Instance.Rows.ElementAt(Swamp.Instance.Row)).VehicleOnTheRow.X +
                    ((LaneRow)RowCollection.Instance.Rows.ElementAt(Swamp.Instance.Row)).VehicleOnTheRow.ToString().Split('*')[0].Length - 1;

                int frogStart = Swamp.Instance.X;
                int frogEnd = Swamp.Instance.X + Swamp.Instance.ToString().Split('*')[0].Length - 1;

                if ((frogStart >= vehicleStart && frogStart <= vehicleEnd) || (frogEnd >= vehicleStart && frogEnd <= vehicleEnd))
                {
                    Swamp.Instance.Lives--;
                    ResetFrog();
                }
            }
        }

=======
>>>>>>> beb5c461bd383e18d336893f70a6caf11166266e
        private static void ScoreUpdater()
        {
            if (Swamp.Instance.Row == 1)
            {
<<<<<<< HEAD
                Swamp.Instance.Level++;
                ((InfoRow)RowCollection.Instance.Rows.ElementAt(0)).Score++;
                Renderer.Renderer.Execute();
                ConsoleKeyInfo stamat = Console.ReadKey();
                if (Swamp.Instance.Level == GlobalConstants.maxFrogLevel)
                {
                    Console.Clear();
                    Console.WriteLine(GlobalConstants.wellDoneFrogger);
                    Environment.Exit(0);
                }
                ResetFrog();
            }
        }

        private static void ResetFrog()
        {
            Swamp.Instance.X = GlobalConstants.initialFrogX;
            Swamp.Instance.Row = GlobalConstants.initialFrogRow;
        }

        private static void VehicleMover(int i)
        {
            int tempSpeed = ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.Speed;
            int currentVehiclePosition = ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.X;

            if (currentVehiclePosition + tempSpeed >= GlobalConstants.screenWidth - 1)
            {
                VehicleSpeedModifier((LaneRow)RowCollection.Instance.Rows.ElementAt(i));
                VehicleLengthModifier((LaneRow)RowCollection.Instance.Rows.ElementAt(i));
                ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.X = 0;
            }
            else
            {
                ((LaneRow)RowCollection.Instance.Rows.ElementAt(i)).VehicleOnTheRow.X += tempSpeed; //+ gameSpeed;
            }
        }

        private static void VehicleSpeedModifier(LaneRow currentVehicle)
        {
            currentVehicle.VehicleOnTheRow.Speed = RandomNumGenerator(2, 5);
=======
                ((InfoRow)RowCollection.Instance.Rows.ElementAt(0)).Score++;
                Swamp.Instance.Row = 15;
                Swamp.Instance.X = 47;
            }
        }

        private static void VehicleSpeedModifier(LaneRow currentVehicle)
        {
            currentVehicle.VehicleOnTheRow.Speed = RandomNumGenerator(2, 7);
>>>>>>> beb5c461bd383e18d336893f70a6caf11166266e
        }

        private static void VehicleLengthModifier(LaneRow currentVehicle)
        {
            currentVehicle.VehicleOnTheRow.VehicleLength = RandomNumGenerator(1, 5);
        }

        private static int RandomNumGenerator(int min, int max)
        {
            Random randNum = new Random();
            return randNum.Next(min, max);
        }
<<<<<<< HEAD
=======

>>>>>>> beb5c461bd383e18d336893f70a6caf11166266e
    }
}
/*
 * Upgrades
 * да рефактурирам public static void FroggerMover() от else if на switch
 */


