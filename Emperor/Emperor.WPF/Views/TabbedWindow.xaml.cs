using Emperor.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Emperor.WPF.Views
{
    /// <summary>
    /// Interaction logic for TabbedWindow.xaml
    /// </summary>
    public partial class TabbedWindow : Window
    {
        private GameVM _gameVM;
        private TradeVM _tradeVM;
        private BalancesVM _balancesVM;
        private RatesVM _ratesVM;
        public TabbedWindow()
        {
            InitializeComponent();
            _gameVM = new GameVM();

            _tradeVM = new TradeVM(_gameVM);
            _tradeVM.PropertyChanged += (sender, args) => { UpdateGameContext(); };

            _balancesVM = new BalancesVM(_gameVM);
            _ratesVM = new RatesVM(_gameVM);
            DataContext = _gameVM;

            tradeViewControl.DataContext = _tradeVM;
            ratesViewControl.DataContext = _ratesVM;
            buildingsViewControl.DataContext = _gameVM;
            balancesViewControl.DataContext = _balancesVM;
        }

        public void UpdateGameContext()
        {
            DataContext = null;
            DataContext = _gameVM;
        }


        private void BtnNextYear_OnClick(object sender, RoutedEventArgs e)
        {
            _gameVM.NextTurn();
            
            ratesViewControl.DataContext = null;
            ratesViewControl.DataContext = _ratesVM;

            balancesViewControl.DataContext = null;
            _balancesVM = new BalancesVM(_gameVM);
            balancesViewControl.DataContext = _balancesVM;
        }
    }
}
