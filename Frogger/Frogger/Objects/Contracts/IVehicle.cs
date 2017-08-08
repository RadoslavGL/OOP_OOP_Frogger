using Frogger.Objects.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public interface IVehicle : IObject

    {
        int Speed { get; }
        string Direction { get; }
    }
}
