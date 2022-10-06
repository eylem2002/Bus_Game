using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project.classes
{
    public class games
    {
        private string _playername;
        private int _duration;
        private int _score;
        private int _level;
        private DateTime _date;

        public string playername
        {
            get
            {
                return this._playername;
            }
            set
            {
                this._playername = value;
            }
        }
        public int duration
        {
            get
            {
                return this._duration;
            }
            set
            {
                this._duration = value;
            }
        }
        public int score
        {
            set
            {
                this._score = value;
            }
            get
            {
                return this._score;
            }
        }
        public int level
        {
            set
            {
                this._level = value;
            }
            get
            {
                return this._level;
            }

        }
        public DateTime date
        {
            set
            {
                this._date = value;
            }
            get
            {
                return this._date;
            }
        }

        public games()
        {

        }
        public games(string playername, int duration, int score, int level, DateTime date)
        {
            this.playername = playername;
            this._duration = duration;
            this._score = score;
            this._level = level;    
            this.date = date;

        }
        public void increaseScore()
        {
            score += 10;
        }
        public void decreaseScore()
        {
            score -= 2;
        }

    }
}
