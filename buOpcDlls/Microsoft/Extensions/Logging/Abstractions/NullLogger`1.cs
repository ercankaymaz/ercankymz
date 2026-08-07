// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.Abstractions.NullLogger`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Extensions.Logging.Abstractions;

[ComVisible(true)]
public class NullLogger<[Nullable(2)] T> : ILogger<T>, ILogger
{
  [Nullable(1)]
  public static readonly NullLogger<T> Instance = new NullLogger<T>();

  [NullableContext(1)]
  public IDisposable BeginScope<[Nullable(2)] TState>(TState state)
  {
    return (IDisposable) NullScope.Instance;
  }

  [NullableContext(2)]
  public void Log<TState>(
    Microsoft.Extensions.Logging.LogLevel logLevel,
    EventId eventId,
    [Nullable(1)] TState state,
    Exception exception,
    [Nullable(new byte[] {1, 1, 2, 1})] Func<TState, Exception, string> formatter)
  {
  }

  public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel) => false;
}
