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
            FetchAdviceList();
            _gameVM.PropertyChanged += ParentChanged;
        }

        private void FetchAdviceList()
        {
            _adviceList = _gameVM.TitleState.AdviceList;
        }

        private List<string> _adviceList; 
        public List<String> AdviceList { get { return _adviceList; } }

        public void ParentChanged(object sender, EventArgs args)
        {
            FetchAdviceList();
            OnPropertyChanged("AdviceList");
        }
    }
}
