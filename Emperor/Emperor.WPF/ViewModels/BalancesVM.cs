using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Emperor.Core;
using Emperor.WPF.Commands;
using Emperor.WPF.ViewModels.DataVM;

namespace Emperor.WPF.ViewModels
{
    public class BalancesVM :BaseVM
    {
        private GameVM _gameVM;

        public BalancesVM(GameVM gameVM)
        {
            _gameVM = gameVM;
            _selectedYear = 0;
            FetchBalanceHistory();

           

            SelectFirstCommand = new RelayCommand(SelectFirst);
            SelectLastCommand = new RelayCommand(SelectLast);
            SelectNextCommand = new RelayCommand(SelectNext, CanSelectNext);
            SelectPreviousCommand = new RelayCommand(SelectPrevious, CanSelectPrevious);
        }

        private int _selectedYear;

        public int SelectedYear
        {
            get { return _selectedYear; }
            set
            {
                _selectedYear = value;
                OnPropertyChanged("SelectedYear");
                OnPropertyChanged("SelectedBalance");
            }
        }

        public int MinLoggedYear { get; private set; }
        public int MaxLoggedYear { get; private set; }

        private Dictionary<int, YearlyBalanceVM> _balanceHistoryVM; 

        public List<int> Years { get { return _balanceHistoryVM.Keys.ToList(); }}
        
        public YearlyBalanceVM SelectedBalance
        {
            get { return _balanceHistoryVM.ContainsKey(SelectedYear)?_balanceHistoryVM[SelectedYear] :null; }

        }

        public ICommand SelectFirstCommand { get; set; }
        public ICommand SelectLastCommand { get; set; }
        public ICommand SelectPreviousCommand { get; set; }
        public ICommand SelectNextCommand { get; set; }

        public void SelectFirst(object parameter)
        {
            SelectedYear = MinLoggedYear;
        }

        public void SelectLast(object parameter)
        {
            SelectedYear = MaxLoggedYear;
        }

        public void SelectPrevious(object parameter)
        {
            SelectedYear--;
        }

        public void SelectNext(object parameter)
        {
            SelectedYear++;
        }

        public bool CanSelectPrevious(object parameter)
        {
            return SelectedYear > MinLoggedYear;
        }

        public bool CanSelectNext(object parameter)
        {
            return SelectedYear < MaxLoggedYear;
        }

        public void FetchBalanceHistory()
        {
            _balanceHistoryVM = _gameVM.BalanceHistory;
            if (_balanceHistoryVM.Keys.Count > 0)
            {
                MinLoggedYear = _balanceHistoryVM.Keys.OrderBy(x => x).First();
                MaxLoggedYear = _balanceHistoryVM.Keys.OrderBy(x => x).Last();
            }
            OnPropertyChanged("Years");
            OnPropertyChanged("MinLoggedYear");
            OnPropertyChanged("MaxLoggedYear");
        }
    }
}
