// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.LoggerMessageAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Extensions.Logging;

[NullableContext(1)]
[Nullable(0)]
[AttributeUsage(AttributeTargets.Method)]
[ComVisible(true)]
public sealed class LoggerMessageAttribute : Attribute
{
  public LoggerMessageAttribute()
  {
  }

  public LoggerMessageAttribute(int eventId, LogLevel level, string message)
  {
    this.EventId = eventId;
    this.Level = level;
    this.Message = message;
  }

  public int EventId { get; set; } = -1;

  [Nullable(2)]
  public string EventName { [NullableContext(2)] get; [NullableContext(2)] set; }

  public LogLevel Level { get; set; } = LogLevel.None;

  public string Message { get; set; } = "";

  public bool SkipEnabledCheck { get; set; }
}
