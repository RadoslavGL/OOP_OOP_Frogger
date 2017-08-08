using Frogger.Renderer.Contracts;
using Frogger.Renderer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Renderer.Abstract
{
    public abstract class BaseSafeZoneRow : BaseRow
    {
        //може да има stuff за добавяне

        public BaseSafeZoneRow(RowID initialRowID) : base(initialRowID)
        {
        }

        public BaseSafeZoneRow(int frogX, bool hasFrog): base(frogX, hasFrog)
        {
        }
        
        
    }
}
