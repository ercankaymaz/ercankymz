// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.Logger`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Microsoft.Extensions.Internal;
using System;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Extensions.Logging;

[ComVisible(true)]
public class Logger<[Nullable(2)] T> : ILogger<T>, ILogger
{
  private readonly ILogger _logger;

  [NullableContext(1)]
  public Logger(ILoggerFactory factory)
  {
    this._logger = factory != null ? factory.CreateLogger(TypeNameHelper.GetTypeDisplayName(typeof (T), includeGenericParameters: false, nestedTypeDelimiter: '.')) : throw new ArgumentNullException(nameof (factory));
  }

  IDisposable ILogger.BeginScope<TState>(TState state) => this._logger.BeginScope<TState>(state);

  bool ILogger.IsEnabled(LogLevel logLevel) => this._logger.IsEnabled(logLevel);

  void ILogger.Log<TState>(
    LogLevel logLevel,
    EventId eventId,
    TState state,
    Exception exception,
    Func<TState, Exception, string> formatter)
  {
    this._logger.Log<TState>(logLevel, eventId, state, exception, formatter);
  }
}
