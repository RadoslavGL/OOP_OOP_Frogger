using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Objects.Contracts
{
    public interface IObject
    {
        int X { get; }
        int Row { get; }
    } //тези две пропъртита, понеже са общи за жабата и колата ги изнесох в базов интерфейс
    
}
