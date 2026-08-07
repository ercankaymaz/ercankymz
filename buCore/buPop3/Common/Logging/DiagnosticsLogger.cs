// Decompiled with JetBrains decompiler
// Type: buPop3.Common.Logging.DiagnosticsLogger
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;
using System.Diagnostics;

#nullable disable
namespace buPop3.Common.Logging;

public class DiagnosticsLogger : ILog
{
  public void LogError(string message)
  {
    if (message == null)
      throw new ArgumentNullException(nameof (message));
    Trace.WriteLine("buPop3: " + message);
  }

  public void LogDebug(string message)
  {
    if (message == null)
      throw new ArgumentNullException(nameof (message));
    Trace.WriteLine("buPop3: (DEBUG) " + message);
  }
}
