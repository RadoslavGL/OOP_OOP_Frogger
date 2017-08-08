﻿using Frogger.Renderer.Abstract;
using Frogger.Renderer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Renderer.Models
{
    public class SafeZoneRow : BaseSafeZoneRow
    {
        public SafeZoneRow(RowID initialRowID) : base(initialRowID)
        {
            //default-ен конструктор, ползвам го при инициализацията на модела
        }
    }
}