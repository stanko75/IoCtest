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

  public class ConsoleOutput : IOutput
  {
    public void Write(string content)
    {
      Console.WriteLine(content);
    }
  }

  public interface IDateWriter
  {
    void WriteDate(object obj);
  }

  public class TodayWriter : IDateWriter
  {
    private IOutput _output;
    public TodayWriter(IOutput output)
    {
      this._output = output;
    }

    public void WriteDate(object obj)
    {
      var ioCmessageDisplayTextBox = (TextBox)obj;
      ioCmessageDisplayTextBox.Text = "Hello world!";
      this._output.Write(DateTime.Today.ToShortDateString());
    }
  }
}