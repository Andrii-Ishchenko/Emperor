using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Emperor.WPF.ViewModels.DataVM;

namespace Emperor.WPF.Framework
{
    public class BuildingDetailsTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is BuildingVM)
            {
                BuildingVM building = item as BuildingVM;

                string templateName = building.Name + "Details";
            
                return element.TryFindResource(templateName) as DataTemplate;
            }

            return null;
        }
    }
}
