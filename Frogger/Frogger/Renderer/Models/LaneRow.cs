using Frogger.Renderer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Renderer.Models
{
    public class LaneRow : BaseLaneRow
    {

        public LaneRow(RowID initialRowID) : base(initialRowID)
        {
            //default-ен конструктор, ползвам го при инициализацията на модела
        }

        public LaneRow(int frogX, int vehicleX, bool hasFrog) : base(frogX, vehicleX, hasFrog)
        {
        }//twa maj nema da trea


        
    }
}
