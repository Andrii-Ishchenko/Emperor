using Emperor.Core;
using Emperor.WPF.ViewModels;
using Emperor.WPF.ViewModels.DataVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Emperor.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameVM _gameVM;

        public MainWindow()
        {
            InitializeComponent();
            _gameVM = new GameVM();
            DataContext = _gameVM;
        }

        private void btnLastReport_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow();
            reportWindow.ShowDialog();
        }

        private void btnGraph_Click(object sender, RoutedEventArgs e)
        {
            GraphWindow graphWindow = new GraphWindow();
            graphWindow.ShowDialog();
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            HistoryWindow historyWindow = new HistoryWindow();
            historyWindow.ShowDialog();
        }

        private void btnIncomeAndExpenses_Click(object sender, RoutedEventArgs e)
        {
            IncomeAndExpenseManageWindow window = new IncomeAndExpenseManageWindow();
            window.ShowDialog();
        }

        private void btnPromotionAdvice_Click(object sender, RoutedEventArgs e)
        {
            new AdviceWindow().ShowDialog();
        }

        private void btnBuildingsListBuy_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            BuildingVM building = button.DataContext as BuildingVM;
            _gameVM.Build(building, 1);
        }

        private void btnNextTurn_Click(object sender, RoutedEventArgs e)
        {
            var yearlyBalance = _gameVM.CalculateNextTurn();
            grReport.DataContext = yearlyBalance;
        }

        private void btnBuildingsListSell_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            BuildingVM building = button.DataContext as BuildingVM;
            _gameVM.Sell(building, 1);
        }
    }
}
