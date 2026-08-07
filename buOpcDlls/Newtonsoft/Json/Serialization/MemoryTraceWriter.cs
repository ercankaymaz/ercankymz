// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.MemoryTraceWriter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Text;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(1)]
[Nullable(0)]
public class MemoryTraceWriter : ITraceWriter
{
  private readonly Queue<string> _traceMessages;
  private readonly object _lock;

  public TraceLevel LevelFilter { get; set; }

  public MemoryTraceWriter()
  {
    this.LevelFilter = TraceLevel.Verbose;
    this._traceMessages = new Queue<string>();
    this._lock = new object();
  }

  public void Trace(TraceLevel level, string message, [Nullable(2)] Exception ex)
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append(DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff", (IFormatProvider) CultureInfo.InvariantCulture));
    stringBuilder.Append(" ");
    stringBuilder.Append(level.ToString("g"));
    stringBuilder.Append(" ");
    stringBuilder.Append(message);
    string str = stringBuilder.ToString();
    lock (this._lock)
    {
      if (this._traceMessages.Count >= 1000)
        this._traceMessages.Dequeue();
      this._traceMessages.Enqueue(str);
    }
  }

  public IEnumerable<string> GetTraceMessages() => (IEnumerable<string>) this._traceMessages;

  public override string ToString()
  {
    lock (this._lock)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (string traceMessage in this._traceMessages)
      {
        if (stringBuilder.Length > 0)
          stringBuilder.AppendLine();
        stringBuilder.Append(traceMessage);
      }
      return stringBuilder.ToString();
    }
  }
}
