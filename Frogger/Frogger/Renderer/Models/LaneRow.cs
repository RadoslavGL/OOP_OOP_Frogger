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
                    this.VehicleOnTheRow.ToString().Split('*')[0].Length-1)
                {
                    return string.Format("{0}{1}{2}{3}\n{0}{4}{2}{5}\n{0}{6}{2}{7}", //празно, кола, празно, жаба\n
                        new string(' ', this.VehicleOnTheRow.X - 1),        //0
                        this.VehicleOnTheRow.ToString().Split('*')[0],      //1
                        new string(' ', Swamp.Instance.X - this.VehicleOnTheRow.X - this.VehicleOnTheRow.ToString().Split('*')[0].Length-1),    //2
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
                return string.Format("{0}{1}\n{0}{2}\n{0}{3}",
                    new string(' ', this.VehicleOnTheRow.X), //eventualno +/-1
                    this.VehicleOnTheRow.ToString().Split('*')[0],
                    this.VehicleOnTheRow.ToString().Split('*')[1],
                    this.VehicleOnTheRow.ToString().Split('*')[2]);
               // string joro = "";
                //
                // Summary:
                //     Returns a new string in which all the characters in the current instance, beginning
                //     at a specified position and continuing through the last position, have been deleted.
                //
                // Parameters:
                //   startIndex:
                //     The zero-based position to begin deleting characters.
                //
                // Returns:
                //     A new string that is equivalent to this string except for the removed characters.
                //
                // Exceptions:
                //   T:System.ArgumentOutOfRangeException:
                //     startIndex is less than zero.-or- startIndex specifies a position that is not
                //     within this string.
                //public String Remove(int startIndex);
                //joro.Remove();
                //GlobalConstants.ScreenWidth-this.VehicleOnTheRow.VehicleLength

            }
        }
    }
}
