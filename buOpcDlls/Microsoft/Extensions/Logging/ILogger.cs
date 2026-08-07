// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.ILogger
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Extensions.Logging;

[NullableContext(1)]
[ComVisible(true)]
public interface ILogger
{
  [NullableContext(2)]
  void Log<TState>(
    LogLevel logLevel,
    EventId eventId,
    [Nullable(1)] TState state,
    Exception exception,
    [Nullable(new byte[] {1, 1, 2, 1})] Func<TState, Exception, string> formatter);

  bool IsEnabled(LogLevel logLevel);

  IDisposable BeginScope<[Nullable(2)] TState>(TState state);
}
