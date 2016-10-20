using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.WPF.ViewModels
{
    public class AdviceVM : BaseVM
    {
        private GameVM _gameVM;

        public AdviceVM(GameVM gameVM)
        {
            _gameVM = gameVM;        
        }

        public List<String> AdviceList { get { return _gameVM.TitleState.AdviceList; } }
    }
}
