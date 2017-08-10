using Frogger.Objects.Models;
using Frogger.Renderer.Abstract;
using Frogger.Renderer.Contracts;
using Frogger.Renderer.Enums;
using Frogger.Renderer.RowCollection;
using Frogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Renderer.Models
{
    public class LaneRow : BaseRow, ILaneRow
    {
        //няма да е VehichleX, защото нямам само едно Vehicle => трябва да ги държа или в колекция
        //или по-интелигентно във всеки LaneRow да има инстанция Vehicle, но по една, за това я правя readonly

        private readonly Vehicle vehicleOnTheRow; //ако има време може и vehicleLength

        public LaneRow(RowID initialRowID) : base(initialRowID)
        {
            this.vehicleOnTheRow = new Vehicle();
            //default-ен конструктор, ползвам го при инициализацията на модела
            //във всеки LaneRow има по една количка, където да и се пазят персонално стойностите
        }

        public IVehicle VehicleOnTheRow
        {
            get
            {
                return this.vehicleOnTheRow;
            }
        }

        public override string ToString()
        {
            if (base.HasFrog)
            {
                if (Swamp.Instance.X >
                    this.VehicleOnTheRow.X +
                    this.VehicleOnTheRow.ToString().Split('*')[0].Length)
                {
                    return string.Format("{0}{1}{2}{3}\n{0}{4}{2}{5}\n{0}{6}{2}{7}", //празно, кола, празно, жаба\n
                        new string(' ', this.VehicleOnTheRow.X),        //0
                        this.VehicleOnTheRow.ToString().Split('*')[0],      //1
                        new string(' ', Swamp.Instance.X - this.VehicleOnTheRow.X - this.VehicleOnTheRow.ToString().Split('*')[0].Length),    //2
                        Swamp.Instance.ToString().Split('*')[0],            //3
                        this.VehicleOnTheRow.ToString().Split('*')[1],      //4
                        Swamp.Instance.ToString().Split('*')[1],            //5
                        this.VehicleOnTheRow.ToString().Split('*')[2],      //6
                        Swamp.Instance.ToString().Split('*')[2]);           //7
                }
                else return "pesho";
                //else if ()
                //{
                //}



            }
            else
            {
                if (this.VehicleOnTheRow.X <= //ако Х на колата е по-малко или равно 
                (GlobalConstants.ScreenWidth - 1) - this.VehicleOnTheRow.VehicleLength) //на размера на екрана минус размера на колата, който се задава динамично от генератор
                {
                    return string.Format("{0}{1}\n{0}{2}\n{0}{3}",
                    new string(' ', this.VehicleOnTheRow.X),
                    this.VehicleOnTheRow.ToString().Split('*')[0],
                    this.VehicleOnTheRow.ToString().Split('*')[1],
                    this.VehicleOnTheRow.ToString().Split('*')[2]);
                }
                else //ако Х на колата е между размера на екрана минус дължината
                     //на колата (динамична) и размера на екрана => трябва да се отреже малко от края й,
                     //което става по следния начин:
                     //string pesho = "asdfghjkl";
                     //Console.WriteLine(pesho.Length); //9
                     //Console.WriteLine(pesho.Remove(5)); //"asdfg"
                {
                    return string.Format("{0}{1}\n{0}{2}\n{0}{3}",
                    new string(' ', this.VehicleOnTheRow.X), //това е така
                    this.VehicleOnTheRow.ToString().Split('*')[0].
                    Remove(GlobalConstants.ScreenWidth-this.VehicleOnTheRow.X),
                    this.VehicleOnTheRow.ToString().Split('*')[1].
                    Remove(GlobalConstants.ScreenWidth - this.VehicleOnTheRow.X),
                    this.VehicleOnTheRow.ToString().Split('*')[2].
                    Remove(GlobalConstants.ScreenWidth - this.VehicleOnTheRow.X));
                }
            }
        }
    }
}
