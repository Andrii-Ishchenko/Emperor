using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Emperor.Core.Managers;
using Emperor.WPF.Commands;

namespace Emperor.WPF.ViewModels
{
    public class ArmyVM : BaseVM
    {
        private GameVM _gameVM;
        private ArmyManager _armyManager;
        private long _recruits;

        public ArmyVM(GameVM gameVM)
        {
            _gameVM = gameVM;
            _armyManager = _gameVM.ArmyManager;
            RecruitCommand = new RelayCommand(Recruit,CanRecruit);
            FetchMaxRecruits();
            _gameVM.PropertyChanged += ParentChanged;
        }

        private long _maxRecruits;
        public long MaxRecruits { get { return _maxRecruits; } }

        public long Recruits
        {
            get  { return _recruits; }
            set
            {
                _recruits = value;
                OnPropertyChanged("Recruits");
            }
        }

        public ICommand RecruitCommand { get; private set; }


        private void Recruit(object parameter)
        {
            _armyManager.Recruit(Recruits);
            OnPropertyChanged(string.Empty);
            OnRecruitEvent();
        }

        private bool CanRecruit(object parameter)
        {
            return _armyManager.CanRecruit(Recruits);
        }

        private void FetchMaxRecruits()
        {
            _maxRecruits = _armyManager.GetMaxRecruits();
        }
        
        public void ParentChanged(object sender, PropertyChangedEventArgs eventArgs)
        {
            FetchMaxRecruits();
            OnPropertyChanged(string.Empty);
        }

        public event EventHandler RecruitEvent;

        private void OnRecruitEvent()
        {
            if (RecruitEvent!=null)
                RecruitEvent(this,new EventArgs());
        }
    }
}
