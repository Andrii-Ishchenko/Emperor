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
using Emperor.WPF.ViewModels;
using Emperor.WPF.ViewModels.DataVM;

namespace Emperor.WPF.Views
{
    /// <summary>
    /// Interaction logic for BuildingsView.xaml
    /// </summary>
    public partial class BuildingsView : UserControl
    {
        private GameVM _gameVM;

        public BuildingsView()
        {
            InitializeComponent();
         //   DataContextChanged += BuildingsView_DataContextChanged;
        }

        void BuildingsView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _gameVM = e.NewValue as GameVM;
        }


        private void btnBuildingsListBuy_OnClick(object sender, RoutedEventArgs e)
        {
           // Button button = sender as Button;
           // BuildingVM building = button.DataContext as BuildingVM;
           //_gameVM.Build(building, 1);
     
        }

        private void BtnBuildingsListSell_OnClick(object sender, RoutedEventArgs e)
        {
            //Button button = sender as Button;
            //BuildingVM building = button.DataContext as BuildingVM;
            //_gameVM.Sell(building, 1);
        }
       
    }
}
