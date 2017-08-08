using Frogger.Renderer.Abstract;
using Frogger.Renderer.Contracts;
using Frogger.Renderer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Renderer
{
    public abstract class BaseLaneRow : BaseRow, ILaneRow
    {
        private int vehicleX;
        //ако има време може и vehicleLength

        public BaseLaneRow(RowID initialRowID) : base(initialRowID)
        {
            this.VehicleX = 0;
        }

        public BaseLaneRow(int frogX, int vehicleX, bool hasFrog) : base (frogX, hasFrog)
        {
            this.VehicleX = vehicleX;
        }
        
        public int VehicleX
        {
            get
            {
                return this.vehicleX;
            }
            private set
            {
                this.vehicleX = value;
            }
        }
        
    }
}
