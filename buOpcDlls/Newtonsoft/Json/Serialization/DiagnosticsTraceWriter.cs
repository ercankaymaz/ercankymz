// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.DiagnosticsTraceWriter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Serialization;

public class DiagnosticsTraceWriter : ITraceWriter
{
  public TraceLevel LevelFilter { get; set; }

  private TraceEventType GetTraceEventType(TraceLevel level)
  {
    switch (level)
    {
      case TraceLevel.Error:
        return TraceEventType.Error;
      case TraceLevel.Warning:
        return TraceEventType.Warning;
      case TraceLevel.Info:
        return TraceEventType.Information;
      case TraceLevel.Verbose:
        return TraceEventType.Verbose;
      default:
        throw new ArgumentOutOfRangeException(nameof (level));
    }
  }

  [NullableContext(1)]
  public void Trace(TraceLevel level, string message, [Nullable(2)] Exception ex)
  {
    if (level == TraceLevel.Off)
      return;
    TraceEventCache eventCache = new TraceEventCache();
    TraceEventType traceEventType = this.GetTraceEventType(level);
    foreach (TraceListener listener in System.Diagnostics.Trace.Listeners)
    {
      if (!listener.IsThreadSafe)
      {
        lock (listener)
          listener.TraceEvent(eventCache, "Newtonsoft.Json", traceEventType, 0, message);
      }
      else
        listener.TraceEvent(eventCache, "Newtonsoft.Json", traceEventType, 0, message);
      if (System.Diagnostics.Trace.AutoFlush)
        listener.Flush();
    }
  }
}
