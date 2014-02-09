using System;
using System.Net.Mime;
using System.Windows.Input;
using Autofac;
using Autofac.Core;

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
        var writer = scope.Resolve<IDateWriterToTextBox>();
        writer.WriteDate(obj);
      }
    }

    public static void MyWriteDate(object obj)
    {

      using (var scope = MainWindow.Container.BeginLifetimeScope())
      {
        var writer = scope.Resolve<IDateWriterToShowMessage>();
        writer.WriteDate(obj);
      }
    }

    public void TextBoxOutputMessage(object obj)
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<TextBoxOutput>().As<IOutput>();
      builder.RegisterType<TodayWriter>().As<IDateWriterToTextBox>();
      builder.Update(MainWindow.Container);
      WriteDate(obj);
    }

    public void ShowMessageOutputMessage(object obj)
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<ShowMessageOutput>().As<IOutput>();
      builder.RegisterType<TodayWriterToShowMessage>().As<IDateWriterToShowMessage>();
      builder.Update(MainWindow.Container);
      MyWriteDate(obj);
    }

    public ClickModel()
    {
      TextBoxOutputClick = new RelayCommand(new Action<object>(TextBoxOutputMessage));
      ShowMessageOutputClick = new RelayCommand(new Action<object>(ShowMessageOutputMessage));
    }
  }
}