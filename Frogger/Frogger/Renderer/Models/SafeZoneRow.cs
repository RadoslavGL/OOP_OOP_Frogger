﻿using Frogger.Renderer.Abstract;
using Frogger.Renderer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Renderer.Models
{
    public class SafeZoneRow : BaseRow
    {
        public SafeZoneRow(RowID initialRowID) : base(initialRowID)
        {
            //default-ен конструктор, ползвам го при инициализацията на модела
        }

        public override string ToString()
        {
            if (base.HasFrog)
            {
                return string.Format("{0}{1}\n{0}{2}\n{0}{3}",
                    new string(' ', Objects.Models.Swamp.Instance.X), //eventualno +/-1
                    Objects.Models.Swamp.Instance.ToString().Split('*')[0],
                    Objects.Models.Swamp.Instance.ToString().Split('*')[1],
                    Objects.Models.Swamp.Instance.ToString().Split('*')[2]);
            }
            else
            {
                return "\n*\n";
            }
        }
    }
}
