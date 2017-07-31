using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public interface IVehicle
    {
        int X
        {
            get;
        }
        int Row
        {
            get;
        }
        int Speed
        {
            get;
        }
        string Direction
        {
            get;
        }

    }
}
