// Decompiled with JetBrains decompiler
// Type: buPop3.Common.Logging.FileLogger
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;
using System.IO;

#nullable disable
namespace buPop3.Common.Logging;

public class FileLogger : ILog
{
  private static readonly object object_0;

  static FileLogger()
  {
    FileLogger.LogFile = new FileInfo("buPop3.log");
    FileLogger.Enabled = true;
    FileLogger.Verbose = false;
    FileLogger.object_0 = new object();
  }

  public static bool Enabled { get; set; }

  public static bool Verbose { get; set; }

  public static FileInfo LogFile { get; set; }

  private static void smethod_0(string string_0)
  {
    if (string_0 == null)
      throw new ArgumentNullException("text");
    lock (FileLogger.object_0)
    {
      using (StreamWriter streamWriter = FileLogger.LogFile.AppendText())
      {
        streamWriter.WriteLine($"{DateTime.Now.ToString()} {string_0}");
        streamWriter.Flush();
      }
    }
  }

  public void LogError(string message)
  {
    if (!FileLogger.Enabled)
      return;
    FileLogger.smethod_0(message);
  }

  public void LogDebug(string message)
  {
    if ((!FileLogger.Enabled ? 0 : (FileLogger.Verbose ? 1 : 0)) == 0)
      return;
    FileLogger.smethod_0("DEBUG: " + message);
  }
}
