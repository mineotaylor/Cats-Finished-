using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cats
{
    public class PetCat
    {
        public enum Mood
        {
            tired,
            playful,
            hungry,
            sad,
            excited

        }

        #region FIELDS

        private string _name;
        private double _weight;
        private bool _catWasAdopted;
        private Mood _currentMood;
        private string _catBreed;

        #endregion
        

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public bool CatWasAdopted
        {
            get { return _catWasAdopted; }
            set { _catWasAdopted = value; }
        }
        public Mood CurrentMood
        {
            get { return _currentMood; }
            set { _currentMood = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public PetCat()
        {

        }

        public PetCat(string name)
        {
            _name = name;
        }

        #endregion

        #region METHODS

        public string CurrentEmotionInfo()
        {
            return _name + " is " + _currentMood + ".";
        }

        public string CatBreed
        {
            get { return _catBreed; }
            set { _catBreed = value; }
        }

        #endregion
    }
}
