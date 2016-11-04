using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;

namespace Emperor.WPF.ViewModels
{
    public class GraphVM : BaseVM
    {

        public GraphVM(GameVM gameVM)
        {
            //this.CurrentGraph = new PlotModel { Title = "Example 1" };
            //this.CurrentGraph.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
        }


        public PlotModel CurrentGraph { get; set; }
    }
}
