using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.Buildings
{
    public class Academy : Building
    {
        //allow to learn new technologies
        //each lvl allow to learn new technology

        public Academy(Game game, int price, int startLevel) : base(game, "Academy", price, startLevel)
        {
            Description = "Allows to learn new technologies to boost productivity and warriors battle capability.";
            _buildRequirements.Add((g) => { return g.Buildings.FirstOrDefault(b => b.Name == "Farm")?.Level > 2; });
        }

        public override void Produce(YearlyBalance income)
        {
           
        }
    }
}
