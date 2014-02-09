﻿using System;
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
using Autofac;
using Autofac.Core;

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
      builder.RegisterType<TextBoxOutput>().As<IOutput>();
      builder.RegisterType<TodayWriter>().As<IDateWriterToTextBox>();

      Container = builder.Build();
    }
  }
}
