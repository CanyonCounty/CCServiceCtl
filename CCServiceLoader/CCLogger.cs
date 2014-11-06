﻿using System;
using System.IO;
using System.Windows.Forms;

namespace CC.Common.Utils
{
  public class CCLogger
  {
    private string fileName;
    private TextWriter writer;

    public CCLogger()
      : this ("")
    {
    }
    
    public CCLogger(string extra)
    {
      string name = Path.ChangeExtension(Application.ExecutablePath, "");
      if (!String.IsNullOrEmpty(extra)) name += extra + ".";
      this.fileName = name + "log";
      this.writer = new StreamWriter(this.fileName, true);
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
          tw.WriteLine(DateTime.Now.ToString() + ": " + data);
        else
          tw.Write(DateTime.Now.ToString() + ": " + data);
        
        tw.Flush();
        tw.Close();
      }
    }

    public static void ClearLog()
    {
      string fileName = Path.ChangeExtension(Application.ExecutablePath, ".log");
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
        writer.WriteLine(DateTime.Now.ToString() + ": " + data);
      else
        writer.Write(DateTime.Now.ToString() + ": " + data);
      
      writer.Flush();
    }

    public void Clear()
    {
      // I don't want to DELETE the file, because I still want it there.
      writer.Close();
      using (TextWriter tw = new StreamWriter(fileName, false))
      {
        tw.Write("");

        tw.Flush();
        tw.Close();
      }
      this.writer = new StreamWriter(this.fileName, true);
    }

    public void Close()
    {
      writer.Flush();
      writer.Close();
    }
  }
}
