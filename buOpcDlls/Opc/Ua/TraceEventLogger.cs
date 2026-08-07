// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TraceEventLogger
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Microsoft.Extensions.Logging;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class TraceEventLogger : ILogger
{
  public Microsoft.Extensions.Logging.LogLevel LogLevel { get; set; }

  public IDisposable BeginScope<TState>(TState state) => (IDisposable) null;

  public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel)
  {
    return logLevel >= this.LogLevel;
  }

  public void Log<TState>(
    Microsoft.Extensions.Logging.LogLevel logLevel,
    EventId eventId,
    TState state,
    Exception exception,
    Func<TState, Exception, string> formatter)
  {
    if (!this.IsEnabled(logLevel))
      return;
    int traceMask = Utils.GetTraceMask(eventId, logLevel);
    Utils.Trace<TState>(state, exception, traceMask, formatter);
  }
}
