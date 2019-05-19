using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Name: Israel Torres
 * Class: Visual Frameworks - Online (MDV1830-O)
 * Term: C201905 01
 * Code Exercise: ListViews
 * Number: CE04
 */

namespace IsraelTorres_CE04
{
    public class Characters
    {
        private string _firstName;
        private string _lastName;
        private decimal _age;
        private string _gender;
        private bool _immortal;
        private string _class;
        private int _imageIndex;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public decimal Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public bool Immortal
        {
            get { return _immortal; }
            set { _immortal = value; }
        }
        public string Class
        {
            get { return _class; }
            set { _class = value; }
        }
        public int ImageIndex
        {
            get { return _imageIndex; }
            set { _imageIndex = value; }
        }

        public override string ToString()
        {
            string item = Class + ": " + FirstName + " " + LastName;

            return item;
        }

        public static readonly List<Characters> _Characters = new List<Characters>();

        public static List<Characters> CharactersList
        {
            get
            {
                if(_Characters.Count < 1)
                {
                    //Load Charaters data
                }
                return _Characters;
            }
        }
    }
}
