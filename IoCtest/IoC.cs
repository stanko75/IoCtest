using System;
using System.Windows.Controls;

namespace IoCtest
{
  public interface IOutput
  {
    void Write(string content, object obj);
  }

  public class ConsoleOutput : IOutput
  {
    public void Write(string content, object obj)
    {
      var ioCmessageDisplayTextBox = (TextBox)obj;
      ioCmessageDisplayTextBox.Text = "Hello world! It is: " + content;
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
      _output.Write(DateTime.Today.ToShortDateString(), obj);
    }
  }
}