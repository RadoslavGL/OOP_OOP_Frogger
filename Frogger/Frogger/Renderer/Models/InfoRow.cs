using Frogger.Renderer.Contracts;
using Frogger.Renderer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Renderer
{
    public class InfoRow : IInfoRow
    {
        //този ред е най горния и е със специална имплементация и не наследява никой
        //само трябва да вземе от някъде SPEED, LIVES и SCORE, които да display-ва
        private int speed;
        private int lives;
        private int score;
        private readonly RowID rowID = 0;

        public InfoRow()
        {
            //default-ен конструктор, ползвам го при инициализацията на модела
            this.Speed = 1;
            this.Lives = 3;
            this.Score = 0;
        }

        public InfoRow(int speed, int lives, int score)
        {
            this.Speed = speed;
            this.Lives = lives;
            this.Score = score;
        }

        public RowID RowID
        {
            get
            {
                return this.rowID;
            }
        }

        public int Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                this.speed = value;
            }
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

        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }

        //public override string ToString() //понеже InfoRow-а е цветен няма да се ползва, само ще се достъпват пропъртитата
        //{
        //    return string.Format("{0} {1} {2}", this.speed, this. lives, this.score);
        //}
    }
}
