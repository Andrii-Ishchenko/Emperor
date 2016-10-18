using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.States
{
    public abstract class TitleState : ICloneable
    {
        protected string _titleName;
        protected Game _game;
        private Dictionary<string, Func<Game, bool>> _promotionRequirements;
        
        public string TitleName
        {
            get { return _titleName; }
            protected set { _titleName = value; }
        }

        public Dictionary<string, Func<Game, bool>> PromotionRequirements
        {
            get
            {
                return _promotionRequirements;
            }

            private set
            {
                _promotionRequirements = value;
            }
        }

        public TitleState(Game game)
        {
            _game = game;
            _promotionRequirements = new Dictionary<string, Func<Game, bool>>();
        }

        public void HandleState()
        {
            if (CheckRequirements())
                Promote();
        }

        public List<string> GetAdvice()
        {
            List<string> advices = new List<string>();

            foreach(var keyValuePair in PromotionRequirements)
            {
                if (!keyValuePair.Value(_game))
                    advices.Add(keyValuePair.Key);
            }

            if (advices.Count == 0)
                advices.Add(@"Coming soon...:)");

            return advices;
        }

        public bool CheckRequirements()
        {
            return PromotionRequirements.All((kvp) => kvp.Value(_game));
        }

        public abstract void Promote();

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
