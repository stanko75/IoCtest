using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Autofac;
using Autofac.Core;

namespace IoCtest
{
  public class ClickModel
  {
    public ICommand MyClick { get; set; }

    public static void WriteDate(object obj)
    {

      using (var scope = MainWindow.Container.BeginLifetimeScope())
      {
        var writer = scope.Resolve<IDateWriter>();
        writer.WriteDate(obj);
      }
    }

    public void ShowMessage(object obj)
    {
      WriteDate(obj);
    }

    public ClickModel()
    {
      MyClick = new RelayCommand(new Action<object>(ShowMessage));
    }
  }
}