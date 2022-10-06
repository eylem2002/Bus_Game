using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace CS_Project.classes
{
    public class Player
    {
        private string name;
        private int age;
        private string gender;
        private string theme;
        private Image _image;

        private List<games> listOfGames = new List<games>();
        public List<games> gamesList()
        {
            List<games> newList = new List<games>();
            for (int i = 0; i < listOfGames.Count; i++)
            {
                newList[i] = listOfGames[i];
            }
            return newList;
        }
        public void addGame(games g)
        {
            listOfGames.Add(g);
        }
        public Player()
        {
         
        }
        public Player(string name, int age, string gender, string theme, Image image)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.theme = theme;
            this.image = image;

        }
        public Player(string name , int age , string gender , string theme)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.theme = theme;
            
        }
        public Image image
        {
            get { return this._image; }
            set { _image = value; }
        }
        public string Name {
            get { return this.name; }
            set { name = value; }
        }
        public int Age
        {
            set { this.age = value; }
            get { return this.age; }
        }
        public string Gender
        {
            set
            {
                this.gender = value;
            }
            get
            {
                return this.gender;
            }
        }
        public string Theme
        {
            set
            {
                this.theme = value;
            }
            get
            {
                return this.theme;
            }
        }


        public override string ToString()
        {
            return $"{name} {age} {gender} {theme}";
        }

    }
}
