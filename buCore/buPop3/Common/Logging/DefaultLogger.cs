// Decompiled with JetBrains decompiler
// Type: buPop3.Common.Logging.DefaultLogger
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;

#nullable disable
namespace buPop3.Common.Logging;

public static class DefaultLogger
{
  public static ILog Log { get; private set; }

  static DefaultLogger() => DefaultLogger.Log = (ILog) new DiagnosticsLogger();

  public static void SetLog(ILog newLogger)
  {
    DefaultLogger.Log = newLogger != null ? newLogger : throw new ArgumentNullException(nameof (newLogger));
  }
}
