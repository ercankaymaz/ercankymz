// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.LoggerExtensions
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
[ComVisible(true)]
public static class LoggerExtensions
{
  private static readonly Func<FormattedLogValues, Exception, string> _messageFormatter = new Func<FormattedLogValues, Exception, string>(LoggerExtensions.MessageFormatter);

  [NullableContext(2)]
  public static void LogDebug(
    [Nullable(1)] this ILogger logger,
    EventId eventId,
    Exception exception,
    string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Debug, eventId, exception, message, args);
  }

  public static void LogDebug(
    this ILogger logger,
    EventId eventId,
    [Nullable(2)] string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Debug, eventId, message, args);
  }

  [NullableContext(2)]
  public static void LogDebug(
    [Nullable(1)] this ILogger logger,
    Exception exception,
    string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Debug, exception, message, args);
  }

  public static void LogDebug(this ILogger logger, [Nullable(2)] string message, [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Debug, message, args);
  }

  [NullableContext(2)]
  public static void LogTrace(
    [Nullable(1)] this ILogger logger,
    EventId eventId,
    Exception exception,
    string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Trace, eventId, exception, message, args);
  }

  public static void LogTrace(
    this ILogger logger,
    EventId eventId,
    [Nullable(2)] string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Trace, eventId, message, args);
  }

  [NullableContext(2)]
  public static void LogTrace(
    [Nullable(1)] this ILogger logger,
    Exception exception,
    string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Trace, exception, message, args);
  }

  public static void LogTrace(this ILogger logger, [Nullable(2)] string message, [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Trace, message, args);
  }

  [NullableContext(2)]
  public static void LogInformation(
    [Nullable(1)] this ILogger logger,
    EventId eventId,
    Exception exception,
    string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Information, eventId, exception, message, args);
  }

  public static void LogInformation(
    this ILogger logger,
    EventId eventId,
    [Nullable(2)] string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Information, eventId, message, args);
  }

  [NullableContext(2)]
  public static void LogInformation(
    [Nullable(1)] this ILogger logger,
    Exception exception,
    string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Information, exception, message, args);
  }

  public static void LogInformation(this ILogger logger, [Nullable(2)] string message, [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Information, message, args);
  }

  [NullableContext(2)]
  public static void LogWarning(
    [Nullable(1)] this ILogger logger,
    EventId eventId,
    Exception exception,
    string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Warning, eventId, exception, message, args);
  }

  public static void LogWarning(
    this ILogger logger,
    EventId eventId,
    [Nullable(2)] string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Warning, eventId, message, args);
  }

  [NullableContext(2)]
  public static void LogWarning(
    [Nullable(1)] this ILogger logger,
    Exception exception,
    string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Warning, exception, message, args);
  }

  public static void LogWarning(this ILogger logger, [Nullable(2)] string message, [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Warning, message, args);
  }

  [NullableContext(2)]
  public static void LogError(
    [Nullable(1)] this ILogger logger,
    EventId eventId,
    Exception exception,
    string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Error, eventId, exception, message, args);
  }

  public static void LogError(
    this ILogger logger,
    EventId eventId,
    [Nullable(2)] string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Error, eventId, message, args);
  }

  [NullableContext(2)]
  public static void LogError(
    [Nullable(1)] this ILogger logger,
    Exception exception,
    string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Error, exception, message, args);
  }

  public static void LogError(this ILogger logger, [Nullable(2)] string message, [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Error, message, args);
  }

  [NullableContext(2)]
  public static void LogCritical(
    [Nullable(1)] this ILogger logger,
    EventId eventId,
    Exception exception,
    string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Critical, eventId, exception, message, args);
  }

  public static void LogCritical(
    this ILogger logger,
    EventId eventId,
    [Nullable(2)] string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Critical, eventId, message, args);
  }

  [NullableContext(2)]
  public static void LogCritical(
    [Nullable(1)] this ILogger logger,
    Exception exception,
    string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Critical, exception, message, args);
  }

  public static void LogCritical(this ILogger logger, [Nullable(2)] string message, [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(LogLevel.Critical, message, args);
  }

  public static void Log(
    this ILogger logger,
    LogLevel logLevel,
    [Nullable(2)] string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(logLevel, (EventId) 0, (Exception) null, message, args);
  }

  public static void Log(
    this ILogger logger,
    LogLevel logLevel,
    EventId eventId,
    [Nullable(2)] string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(logLevel, eventId, (Exception) null, message, args);
  }

  [NullableContext(2)]
  public static void Log(
    [Nullable(1)] this ILogger logger,
    LogLevel logLevel,
    Exception exception,
    string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    logger.Log(logLevel, (EventId) 0, exception, message, args);
  }

  [NullableContext(2)]
  public static void Log(
    [Nullable(1)] this ILogger logger,
    LogLevel logLevel,
    EventId eventId,
    Exception exception,
    string message,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    if (logger == null)
      throw new ArgumentNullException(nameof (logger));
    logger.Log<FormattedLogValues>(logLevel, eventId, new FormattedLogValues(message, args), exception, LoggerExtensions._messageFormatter);
  }

  public static IDisposable BeginScope(
    this ILogger logger,
    string messageFormat,
    [Nullable(new byte[] {1, 2})] params object[] args)
  {
    if (logger == null)
      throw new ArgumentNullException(nameof (logger));
    return logger.BeginScope<FormattedLogValues>(new FormattedLogValues(messageFormat, args));
  }

  private static string MessageFormatter(FormattedLogValues state, Exception error)
  {
    return state.ToString();
  }
}
