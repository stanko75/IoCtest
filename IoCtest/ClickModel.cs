using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IoCtest
{
  public class ClickModel
  {

    private ICommand _buttonCommand;

    public ICommand MyClick
    {
      get { return _buttonCommand; }
      set { _buttonCommand = value; }
    }

    public void ShowMessage(object obj)
    {
      TextBox IoCmessageDisplayTextBox = new TextBox();
      IoCmessageDisplayTextBox = (TextBox)obj;
      IoCmessageDisplayTextBox.Text = "Hello world!";
    }

    public ClickModel()
    {
      MyClick = new RelayCommand(new Action<object>(ShowMessage));
    }
  }
}