using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace CC.Service.Loader
{
  public class CCLogger
  {
    private readonly string _fileName;
    private TextWriter _writer;

    public CCLogger()
      : this ("")
    {
    }
    
    public CCLogger(string extra)
    {
      var name = Path.ChangeExtension(Application.ExecutablePath, "");
      if (!string.IsNullOrEmpty(extra)) name += extra + ".";
      _fileName = name + "log";
      _writer = new StreamWriter(_fileName, true);
    }

    public static void WriteLog(string data)
    {
      WriteLog(data, true);
    }

    public static void WriteLog(string data, bool newline)
    {
      string fileName = Path.ChangeExtension(Application.ExecutablePath, ".log");
      using (TextWriter tw = new StreamWriter(fileName, true))
      {
        if (newline)
          tw.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + ": " + data);
        else
          tw.Write(DateTime.Now.ToString(CultureInfo.CurrentCulture) + ": " + data);
        
        tw.Flush();
        tw.Close();
      }
    }

    public static void ClearLog()
    {
      var fileName = Path.ChangeExtension(Application.ExecutablePath, ".log");
      using (TextWriter tw = new StreamWriter(fileName, false))
      {
        tw.Write("");

        tw.Flush();
        tw.Close();
      }
    }

    public void Write(string data)
    {
      Write(data, true);
    }

    public void Write(string data, bool newline)
    {
      if (newline)
        _writer.WriteLine(DateTime.Now.ToString(CultureInfo.CurrentCulture) + ": " + data);
      else
        _writer.Write(DateTime.Now.ToString(CultureInfo.CurrentCulture) + ": " + data);
      
      _writer.Flush();
    }

    public void Clear()
    {
      // I don't want to DELETE the file, because I still want it there.
      _writer.Close();
      using (TextWriter tw = new StreamWriter(_fileName, false))
      {
        tw.Write("");

        tw.Flush();
        tw.Close();
      }
      _writer = new StreamWriter(_fileName, true);
    }

    public void Close()
    {
      _writer.Flush();
      _writer.Close();
    }
  }
}
