// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.Abstractions.NullLogger
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
public class NullLogger : ILogger
{
  public static NullLogger Instance { get; } = new NullLogger();

  private NullLogger()
  {
  }

  public IDisposable BeginScope<[Nullable(2)] TState>(TState state)
  {
    return (IDisposable) NullScope.Instance;
  }

  public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel) => false;

  [NullableContext(2)]
  public void Log<TState>(
    Microsoft.Extensions.Logging.LogLevel logLevel,
    EventId eventId,
    [Nullable(1)] TState state,
    Exception exception,
    [Nullable(new byte[] {1, 1, 2, 1})] Func<TState, Exception, string> formatter)
  {
  }
}
