using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Emperor.Core
{
    public abstract class Building
    {
         protected Game _game;

        protected Building(Game game, string name, int price, int startLevel)
        {
            _game = game;
            _price = price;
            _name = name;
            _level = startLevel;
            _buildRequirements = new List<Func<Game, bool>>();
            _names = new Dictionary<int, string>();
        }

        protected Dictionary<int,string> _names;
        protected List<Func<Game, bool>> _buildRequirements;

        public string Description
        {
            get { return _description; }
            protected set { _description = value; }
        }

        private bool _isBuildingAvailable = true;
        private string _name;
        private int _price;
        private int _level;
        private string _description;

        public string Name
        {
            get { return _name; }
            internal set
            {
                _name = value; 
                OnBuildingChanged();
            }
        }

        public int Price
        {
            get { return _price; }
            internal set
            {
                _price = value; 
                OnBuildingChanged();
            }
        }

        public int Level
        {
            get { return _level; }
            internal set
            {
                _level = value; 
                OnBuildingChanged();
            }
        }


        public bool IsBuildingAvailable
        {
            get { return _isBuildingAvailable; }
            internal set
            {
                if (_isBuildingAvailable != value)
                {
                    _isBuildingAvailable = value;
                    OnBuildingChanged();
                }
            }
        }

        public abstract void Produce(YearlyBalance income);

        //public bool CanBeBuilt(int quantity)
        //{
        //    return  BuildingAvailable() && (quantity*Price <= _game.Gold) ;
        //}

        public bool BuildingAvailable()
        {
            if (_buildRequirements == null || _buildRequirements.Count == 0)
                return true;
            IsBuildingAvailable = _buildRequirements.All(br => br.Invoke(_game));
            return IsBuildingAvailable;
        }

        //public virtual bool Build(int count)
        //{
        //    if (_game.Gold < count * Price)
        //        return false;

        //    _game.Gold -= count * Price;
        //    Level += count;          
        //    return true;
        //}

        public override string ToString()
        {
            return Name;
        }

        public event EventHandler BuildingChanged;

        protected void OnBuildingChanged()
        {
            if (BuildingChanged!=null)
                BuildingChanged(this,new EventArgs());
        }


    }
}
