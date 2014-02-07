using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCtest
{
  public interface IOutput
  {
    void Write(string content);
  }

  public class MemoOutput : IOutput
  {

    public void Write(string content)
    {
      //write to memo
      throw new NotImplementedException();
    }
  }

  public class ConsoleOutput : IOutput
  {
    public void Write(string content)
    {
      //write to console
      throw new NotImplementedException();
    }
  }

  class IoC
  {

  }
}