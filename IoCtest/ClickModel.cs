using System;
using System.Windows.Input;
using Autofac;

namespace IoCtest
{
  public class ClickModel
  {
    public ICommand TextBoxOutputClick { get; set; }
    public ICommand ShowMessageOutputClick { get; set; }

    public static void WriteDate(object obj)
    {
      using (var scope = MainWindow.Container.BeginLifetimeScope())
      {
        var writer = scope.Resolve<IDateWriter>();
        writer.WriteDate(obj);
      }
    }

    public void TextBoxOutputMessage(object obj)
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<TextBoxOutput>().As<IOutput>();
      builder.Update(MainWindow.Container);
      WriteDate(obj);
    }

    public void ShowMessageOutputMessage(object obj)
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<ShowMessageOutput>().As<IOutput>();
      builder.Update(MainWindow.Container);
      WriteDate(obj);
    }

    public ClickModel()
    {
      TextBoxOutputClick = new RelayCommand(new Action<object>(TextBoxOutputMessage));
      ShowMessageOutputClick = new RelayCommand(new Action<object>(ShowMessageOutputMessage));
    }
  }
}