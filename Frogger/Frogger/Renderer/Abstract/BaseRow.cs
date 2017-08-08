using Frogger.Renderer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frogger.Renderer.Enums;

namespace Frogger.Renderer.Abstract
{
    public abstract class BaseRow : IRow
    {
        private int frogX;
        private bool hasFrog;
        private readonly RowID rowID;
        //при инициализирането на обектите в колекцията им се слага rowID и повече не се бара.

        public BaseRow(RowID initialRowID)
        {
            this.FrogX = 0;
            this.HasFrog = false;
            this.rowID = initialRowID;
        }

        public BaseRow(int frogX, bool hasFrog)
        {
            this.FrogX = frogX;
            this.HasFrog = hasFrog;
        }

        public RowID RowID
        {
            get
            {
                return this.rowID;
            }
        }

        public int FrogX
        {
            get
            {
                return this.frogX;
            }
            private set
            {
                this.frogX = value;
            }
        }

        public bool HasFrog
        {
            get
            {
                return this.hasFrog;
            }
            private set
            {
                this.hasFrog = value;
            }
        }
    }
}
