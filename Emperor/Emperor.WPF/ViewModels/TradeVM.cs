using Emperor.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Emperor.WPF.ViewModels
{
    public class TradeVM : BaseVM
    {
        private GameVM _gameVM;

        public TradeVM(GameVM gameVM)
        {
            _gameVM = gameVM;
            Multiplicator = 1;
            IncreaseMultiplicatorCommand = new RelayCommand(IncreaseMultiplicator, CanIncreaseMultiplicator);
            DecreaseMultiplicatorCommand = new RelayCommand(DecreaseMultiplicator, CanDecreaseMultiplicator);
        }

        private long _multiplicator;
        private ICommand _increaseMultiplicatorCommand;
        private ICommand _decreaseMultiplicatorCommand;

        public long Multiplicator
        {
            get
            {
                return _multiplicator;
            }

            set
            {
                _multiplicator = value;
                OnPropertyChanged("Multiplicator");
            }
        }

        public GameVM Game { get { return _gameVM; } }

        public ICommand IncreaseMultiplicatorCommand
        {
            get
            {
                return _increaseMultiplicatorCommand;
            }

            set
            {
                _increaseMultiplicatorCommand = value;
            }
        }

        public ICommand DecreaseMultiplicatorCommand
        {
            get
            {
                return _decreaseMultiplicatorCommand;
            }

            set
            {
                _decreaseMultiplicatorCommand = value;
            }
        }

        public bool CanIncreaseMultiplicator(object parameter)
        {
            return Multiplicator < long.MaxValue / 10;
        }
        public void IncreaseMultiplicator(object parameter)
        {
            
            Multiplicator *=  10;
        }

        public bool CanDecreaseMultiplicator(object parameter)
        {
            return Multiplicator >= 10;
        }
        public void DecreaseMultiplicator(object parameter)
        {
            Multiplicator /= 10;
        }



    }
}
