using Frogger.Objects.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Objects.Models
{
    public class Frog : Subject, IFrog
    {
        private int lives;
        private bool isAlive;

        public Frog() : base()
        {
            //жабата се създава само веднъж в блатото (Swamp)
            //при създаването не е необходимо въвеждане на стойности,
            //в калкулатора ще се сменят и без друго
        }

        public int Lives
        {
            get
            {
                return this.lives;
            }
            set
            {
                this.lives = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                return this.isAlive;
            }
            set
            {
                this.isAlive = value;
            }
        }
        
        public override string ToString()
        {
            return string.Format("{0}*{1}*{2}",
            " @ @ ",
            "\\(_)/",
            " \\ / ");
        }
    }
}
