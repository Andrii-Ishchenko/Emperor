using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core.States
{
    public abstract class TitleState
    {
        protected string _titleName;
        public int AssignYear { get; set; }

        public string TitleName
        {
            get { return _titleName; }
        }

        public abstract void HandleState(Game game); 
    }
}
