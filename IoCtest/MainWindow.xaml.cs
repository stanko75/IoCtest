using System.Windows;
using Autofac;

namespace IoCtest
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public static IContainer Container { get; set; }
    public MainWindow()
    {
      InitializeComponent();

      var builder = new ContainerBuilder();
      Container = builder.Build();
    }
  }
}