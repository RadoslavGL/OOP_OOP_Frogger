﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Renderer.Contracts
{
    public interface ILaneRow : IRow
    {
        int VehicleX { get; set; }
    }
}