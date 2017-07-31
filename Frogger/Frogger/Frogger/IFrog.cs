using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public interface IFrog
    {

        #region Props
        int X
        {
            get;
        }

        int Row
        {
            get;
        }

        int Lives
        {
            get;
        }

        bool IsAlive
        {
            get;
        }
        #endregion

    }
}
