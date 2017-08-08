using Frogger.Renderer.Enums;
using Frogger.Renderer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Frogger.Renderer
{
    public static class Renderer
    {
        public static void Execute(int[] frogXRow, IDictionary<int, int> vehicleXRow)
        {
            //в калкулатора трябва да се правят сметките да не се застъпват жаба и vehicle.
            //в този метод трябва да влизат единствено валидни стойности за отпечатване на обектите
            //за бързина при рисуването ще пробвам с Console.SetCursorPosition(left, top);
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            for (int i = (int)RowID.Zero; i <= (int)RowID.Fifteenth; i++)
            {
                if (i == (int)RowID.Zero)
                {
                    //Заради шаренията по конзолата не съм го направил на ToString() от inforow-a
                    InfoRow inforow = (InfoRow)RowCollection.RowCollection.Instance.Rows.First();
                    int speed = inforow.Speed;
                    int lives = inforow.Lives;
                    int score = inforow.Score;
                    //тва ако е мега бавно, ще взимам от калкулатора направо:  public static void Execute(int[] frogXRow, IDictionary<int, int> vehicleXRow, int speed, int lives, int score)

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(10, 0);
                    Console.WriteLine("{0}{3}{1}{3}{1}{3}{2}", '┌', '┬', '┐', new string('─', 25));
                    Console.SetCursorPosition(10, 1);
                    
                    Console.SetCursorPosition(10, 2);
                    Console.WriteLine("{0}{3}{1}{3}{1}{3}{2}", '└', '┴', '┘', new string('─', 25));

                    //RowCollection.RowCollection.Instance.Rows.Add(new InfoRow());
                }
                else if (i == (int)RowID.First || i == (int)RowID.Eighth || i == (int)RowID.Fifteenth)
                {
                    if (i != frogXRow[1]) //демек реда в който я няма жабата => hasFrog = false;
                    {
                        if (i== (int)RowID.First)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine(string.Format("{0}\n{0}\n{0}\n", new string(' ',GlobalConstants.GlobalConstants.ScreenWidth))); //ako krashne -1
                            Console.BackgroundColor = ConsoleColor.Black; //reset-вам background-a
                        }
                        else if (i == (int)RowID.Eighth)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine(string.Format("Safe{0}Safe\n{1}\nZone!{2}Zone!\n",
                                new string(' ', 92),
                                new string(' ', GlobalConstants.GlobalConstants.ScreenWidth),
                                new string(' ', 90))); //ako krashne -1
                            Console.BackgroundColor = ConsoleColor.Black; //reset-вам background-a
                        }
                        //else за черния фон най долу не барам нищо
                    }
                    else //демек ако я има жабата
                    {

                    }
                    
                    //RowCollection.RowCollection.Instance.Rows.Add(new SafeZoneRow((RowID)i));
                }
                else
                {
                    //RowCollection.RowCollection.Instance.Rows.Add(new LaneRow((RowID)i));
                }
            }

            //StringBuilder render = new StringBuilder();
            //render.Append(string.Format());


            //Console.WriteLine(new InfoRow(speed, lives, score).ToString()); ////към няква променлива стрингбуилдер

            ////проверка if жабата е преди колата, след колата или не е на реда

            //RowCollection.RowCollection.Instance.Rows.

        }
        public static void InitializeRenderer()
        {
            //методът се вика само веднъж в Engine-a; задава размерите на прозорчето; зарежда в RAM-та колекцията с обекти от тип Row RowID = [0..15] = 16 броя, после в калкулатора им се променят стойностите във field-овете, тук се четат и визуализират

            // - задава размерите на прозорчето;
            Console.SetBufferSize(GlobalConstants.GlobalConstants.ScreenWidth, GlobalConstants.GlobalConstants.ScreenHeight);
            Console.SetWindowSize(GlobalConstants.GlobalConstants.ScreenWidth, GlobalConstants.GlobalConstants.ScreenHeight);

            // - зареждане на колекцията с обекти от тип Row RowID = [0..15] = 16 броя. По-долу има коментар относно
            for (int i = (int)RowID.Zero; i <= (int)RowID.Fifteenth; i++)
            {
                if (i == (int)RowID.Zero)
                {
                    RowCollection.RowCollection.Instance.Rows.Add(new InfoRow());
                }
                else if (i == (int)RowID.First || i == (int)RowID.Eighth || i == (int)RowID.Fifteenth)
                {
                    RowCollection.RowCollection.Instance.Rows.Add(new SafeZoneRow((RowID)i));
                }
                else
                {
                    RowCollection.RowCollection.Instance.Rows.Add(new LaneRow((RowID)i));
                }
            } //и никъде не се виждат числа
        }
    }
}
/*
Обекти Renderer няма да се генерират за това го правим статичен клас.

Да помисля какви са размерите на екрана и как се set-ват
* Готово:
* Относно размера на прозорчето:
Console.WindowWidth = 100;
Console.WindowHeight = 48; n
Console.BufferWidth = 100;
Console.BufferHeight = 48; n
* n = 3*(inforow + 3*safe + 2*6cars) = 3* (1+3+12) = 3* 16 = 48; (колкото в оригинала)
* те имат най-долу един ред празен, предполагам за естетика

Първо с началото на играта се създава колекция ICollection от обекти тип Row с пропъртита: x,row на жаба и x,row на кола
 *  те може би да имат методи   ToStringRow1
 *                              ToStringRow2
 *                              ToStringRow3
 *  Row-a проверява къде се намират по х по у и смята кое къде и изплюва къде и колко white space да сложи
 *  Renderer-a има методи ToStringRow1
 *                        ToStringRow2
 *                        ToStringRow3

   от калкулатора/engin-а ми трябват:
 * int[2] { int frogX, int frogRow},
 * IDictionary < ред на колата, координата по Х > //това dictionarу дава mnogo лесна възможност индивидуалната кола да се движи със собствена скорост
 * за InfoRow-а speed, lives и score
 

//да го тествам с hardcode-нати числа


    ето къде ще ползвам enum-а
    IDRow и кола<Row,x>
    */
// - понеже ги Add-вам последователно, ако искам после да достъпвам елементите по индекс
// трябва да направя записа по този грозен начин.
//алтернативно да измисля достъпване на елементите по RowID
//май го измислих, а именно с LINQ методите, което е още една точка от изискванията
//горното обаче, май ще е многократно по-бавно от сегашната имплементация и ще забави рендосването
// => за сега оставям
//update: индексите така или иначе не работят и пак трябва Linq: ProductDTO product = (ProductDTO)Products.ElementAt(0);
//update: мисля да ги достъпвам по RowID
//стар вариант:
//RowCollection.RowCollection.Instance.Rows.Add(new InfoRow());
//RowCollection.RowCollection.Instance.Rows.Add(new SafeZoneRow(RowID.First)); 
//for (int i = (int)RowID.Second; i <= (int)RowID.Seventh; i++)
//{
//    RowCollection.RowCollection.Instance.Rows.Add(new LaneRow((RowID)i));
//}
//RowCollection.RowCollection.Instance.Rows.Add(new SafeZoneRow(RowID.Eighth));
//for (int i = (int)RowID.Ninth; i <= (int)RowID.Fourteenth; i++)
//{
//    RowCollection.RowCollection.Instance.Rows.Add(new LaneRow((RowID)i));
//}
//RowCollection.RowCollection.Instance.Rows.Add(new SafeZoneRow(RowID.Fifteenth));

/* Защо да бъде просто, като може да е сложно
         * Една идея по-интелигентно. Правя Row-овете да имат енумерация RowID
         * После нещата които идват от калкулатора ще са
         * не
         * frogXRow / vehicleXRow
         * ами
         * frogXRowID / vehicleXRowID
         * печелим 1: че сме ползвали енумерация 2: някак си IDictionary<int,RowID> vehicleXRow е по - пригледно от IDictionary<int,int> vehicleXRow
         */
