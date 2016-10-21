using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emperor.WPF.ViewModels.DataVM;

namespace Emperor.WPF.ViewModels
{
    public class BalancePopupWindowVM : BaseVM
    {
        private YearlyBalanceVM _balance;
        private readonly GameVM _gameVm;


        public BalancePopupWindowVM(YearlyBalanceVM balance, GameVM gameVm)
        {
            _balance = balance;
            _gameVm = gameVm;
          

        }

        public bool ShowPopup
        {
            get { return !_gameVm.ShowPopup; }
            set
            {
                _gameVm.ShowPopup = !value;
                OnPropertyChanged("ShowPopup");
            }
        }

        public YearlyBalanceVM Balance {get {return _balance;} }
    }
}
