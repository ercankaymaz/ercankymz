// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.Abstractions.LogEntry`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Extensions.Logging.Abstractions;

[NullableContext(1)]
[Nullable(0)]
[ComVisible(true)]
public readonly struct LogEntry<[Nullable(2)] TState>(
  Microsoft.Extensions.Logging.LogLevel logLevel,
  string category,
  EventId eventId,
  TState state,
  [Nullable(2)] Exception exception,
  [Nullable(new byte[] {1, 1, 2, 1})] Func<TState, Exception, string> formatter)
{
  public Microsoft.Extensions.Logging.LogLevel LogLevel { get; } = logLevel;

  public string Category { get; } = category;

  public EventId EventId { get; } = eventId;

  public TState State { get; } = state;

  [Nullable(2)]
  public Exception Exception { [NullableContext(2)] get; } = exception;

  [Nullable(new byte[] {2, 1, 2, 1})]
  public Func<TState, Exception, string> Formatter { [return: Nullable(new byte[] {2, 1, 2, 1})] get; } = formatter;
}
