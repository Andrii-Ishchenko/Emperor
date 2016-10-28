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

        protected int _yearsToPromote = 3;
        protected int _ellapsedYears = 0;

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
            {
                _ellapsedYears++;
                if (_ellapsedYears == _yearsToPromote)
                    Promote();
            }
            else
            {
                _ellapsedYears = 0;
            }
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

        public virtual bool CheckEndGame()
        {
            return false;
        }

        public abstract void Promote();

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        protected void AddCastleRequirement(long castleLevel)
        {
            if (PromotionRequirements == null)
                PromotionRequirements = new Dictionary<string, Func<Game, bool>>();
            
            PromotionRequirements.Add("Castle", (g) =>
            {
                var castle = g.Buildings.FirstOrDefault(b => b.Name == "Castle");
                if (castle==null)
                    throw new Exception();
                return castle.Count >= castleLevel;
            });
        }

        protected void AddCitizenRequirement(long citizens)
        {
            if (PromotionRequirements == null)
                PromotionRequirements = new Dictionary<string, Func<Game, bool>>();

            PromotionRequirements.Add("Citizens", (g) => g.Citizens >= citizens);
        }

        protected void AddGoldRequirement(long gold)
        {
            if (PromotionRequirements == null)
                PromotionRequirements = new Dictionary<string, Func<Game, bool>>();

            PromotionRequirements.Add("Gold", (g) => g.Gold >= gold);
        }

        protected void AddArmyRequirement(long army)
        {
            if (PromotionRequirements == null)
                PromotionRequirements = new Dictionary<string, Func<Game, bool>>();

            PromotionRequirements.Add("Army", (g) => g.Soldiers >= army);
        }

        protected void AddHappinessRequirement(long happiness)
        {
            if (PromotionRequirements == null)
                PromotionRequirements = new Dictionary<string, Func<Game, bool>>();

            PromotionRequirements.Add("Happiness", (g) => g.Happiness >= happiness);
        }
        
    }
}
