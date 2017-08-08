using Frogger.Objects.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public interface IFrog : IObject
    {
        #region Props
        int Lives { get; }
        bool IsAlive { get; }
        #endregion
    }
}
