using Emperor.Core.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.WPF.ViewModels.DataVM
{
    public class TitleStateVM : BaseVM
    {
        private TitleState _titleState;

        public TitleStateVM(TitleState titleState)
        {
            _titleState = titleState;
        }

        public string TitleName { get { return _titleState.TitleName; } }

        public List<string> AdviceList { get { return _titleState.GetAdvice(); } }
    }
}
