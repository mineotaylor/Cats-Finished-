using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreedsOfCat
{
    public class CatBreed
    {
        public enum Mood
        {
            happy,
            sad,
            angry
        }

        #region FIELDS

        private string _name;
        private double _weight;
        private bool _wasAdopted;
        private Mood _currentMood;
        private string _favoriteTreat;

        #endregion

        #region
        public Mood CurrentMood
        {
            get { return _currentMood; }
            set { _currentMood = value; }
        }

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

        public bool Adopted
        {
            get { return _wasAdopted; }
            set { _wasAdopted = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public CatBreed()
        {

        }

        public CatBreed(string name)
        {
            _name = name;
        }

        #endregion

        #region METHODS

        public string CurrentEmotionInfo()
        {
            return _name + " is " + _currentMood + ".";
        }

        public string FavoriteTreat
        {
            get { return _favoriteTreat; }
            set { _favoriteTreat = value; }
        }

        #endregion
    }
}
