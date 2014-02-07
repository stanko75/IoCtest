using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IoCtest
{
  public interface IOutput
  {
    void Write(string content);
  }

  public class TextBoxOutput : IOutput
  {

    public TextBox _textBox;

    public void Write(string content)
    {
      //write to memo
      _textBox.Text = content;
    }
  }

  public class ConsoleOutput : IOutput
  {
    public void Write(string content)
    {
      //write to console
      Console.WriteLine(content);
    }
  }

  class IoC
  {

  }
}