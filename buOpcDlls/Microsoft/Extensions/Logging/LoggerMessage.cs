// Decompiled with JetBrains decompiler
// Type: Microsoft.Extensions.Logging.LoggerMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices.Microsoft.Extensions.Logging.Abstractions;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.Extensions.Logging;

[NullableContext(2)]
[Nullable(0)]
[ComVisible(true)]
public static class LoggerMessage
{
  [NullableContext(1)]
  public static Func<ILogger, IDisposable> DefineScope(string formatString)
  {
    LoggerMessage.LogValues logValues = new LoggerMessage.LogValues(LoggerMessage.CreateLogValuesFormatter(formatString, 0));
    return (Func<ILogger, IDisposable>) (logger => logger.BeginScope<LoggerMessage.LogValues>(logValues));
  }

  [NullableContext(1)]
  public static Func<ILogger, T1, IDisposable> DefineScope<[Nullable(2)] T1>(string formatString)
  {
    LogValuesFormatter formatter = LoggerMessage.CreateLogValuesFormatter(formatString, 1);
    return (Func<ILogger, T1, IDisposable>) ((logger, arg1) => logger.BeginScope<LoggerMessage.LogValues<T1>>(new LoggerMessage.LogValues<T1>(formatter, arg1)));
  }

  [NullableContext(1)]
  public static Func<ILogger, T1, T2, IDisposable> DefineScope<[Nullable(2)] T1, [Nullable(2)] T2>(
    string formatString)
  {
    LogValuesFormatter formatter = LoggerMessage.CreateLogValuesFormatter(formatString, 2);
    return (Func<ILogger, T1, T2, IDisposable>) ((logger, arg1, arg2) => logger.BeginScope<LoggerMessage.LogValues<T1, T2>>(new LoggerMessage.LogValues<T1, T2>(formatter, arg1, arg2)));
  }

  [return: Nullable(1)]
  public static Func<ILogger, T1, T2, T3, IDisposable> DefineScope<T1, T2, T3>([Nullable(1)] string formatString)
  {
    LogValuesFormatter formatter = LoggerMessage.CreateLogValuesFormatter(formatString, 3);
    return (Func<ILogger, T1, T2, T3, IDisposable>) ((logger, arg1, arg2, arg3) => logger.BeginScope<LoggerMessage.LogValues<T1, T2, T3>>(new LoggerMessage.LogValues<T1, T2, T3>(formatter, arg1, arg2, arg3)));
  }

  [return: Nullable(1)]
  public static Func<ILogger, T1, T2, T3, T4, IDisposable> DefineScope<T1, T2, T3, T4>(
    [Nullable(1)] string formatString)
  {
    LogValuesFormatter formatter = LoggerMessage.CreateLogValuesFormatter(formatString, 4);
    return (Func<ILogger, T1, T2, T3, T4, IDisposable>) ((logger, arg1, arg2, arg3, arg4) => logger.BeginScope<LoggerMessage.LogValues<T1, T2, T3, T4>>(new LoggerMessage.LogValues<T1, T2, T3, T4>(formatter, arg1, arg2, arg3, arg4)));
  }

  [return: Nullable(1)]
  public static Func<ILogger, T1, T2, T3, T4, T5, IDisposable> DefineScope<T1, T2, T3, T4, T5>(
    [Nullable(1)] string formatString)
  {
    LogValuesFormatter formatter = LoggerMessage.CreateLogValuesFormatter(formatString, 5);
    return (Func<ILogger, T1, T2, T3, T4, T5, IDisposable>) ((logger, arg1, arg2, arg3, arg4, arg5) => logger.BeginScope<LoggerMessage.LogValues<T1, T2, T3, T4, T5>>(new LoggerMessage.LogValues<T1, T2, T3, T4, T5>(formatter, arg1, arg2, arg3, arg4, arg5)));
  }

  [return: Nullable(1)]
  public static Func<ILogger, T1, T2, T3, T4, T5, T6, IDisposable> DefineScope<T1, T2, T3, T4, T5, T6>(
    [Nullable(1)] string formatString)
  {
    LogValuesFormatter formatter = LoggerMessage.CreateLogValuesFormatter(formatString, 6);
    return (Func<ILogger, T1, T2, T3, T4, T5, T6, IDisposable>) ((logger, arg1, arg2, arg3, arg4, arg5, arg6) => logger.BeginScope<LoggerMessage.LogValues<T1, T2, T3, T4, T5, T6>>(new LoggerMessage.LogValues<T1, T2, T3, T4, T5, T6>(formatter, arg1, arg2, arg3, arg4, arg5, arg6)));
  }

  [NullableContext(1)]
  [return: Nullable(new byte[] {1, 1, 2})]
  public static Action<ILogger, Exception> Define(
    LogLevel logLevel,
    EventId eventId,
    string formatString)
  {
    return LoggerMessage.Define(logLevel, eventId, formatString, (LogDefineOptions) null);
  }

  [NullableContext(1)]
  [return: Nullable(new byte[] {1, 1, 2})]
  public static Action<ILogger, Exception> Define(
    LogLevel logLevel,
    EventId eventId,
    string formatString,
    [Nullable(2)] LogDefineOptions options)
  {
    LogValuesFormatter formatter = LoggerMessage.CreateLogValuesFormatter(formatString, 0);
    return options != null && options.SkipEnabledCheck ? new Action<ILogger, Exception>(Log) : (Action<ILogger, Exception>) ((logger, exception) =>
    {
      if (!logger.IsEnabled(logLevel))
        return;
      Log(logger, exception);
    });

    void Log(ILogger logger, Exception exception)
    {
      logger.Log<LoggerMessage.LogValues>(logLevel, eventId, new LoggerMessage.LogValues(formatter), exception, LoggerMessage.LogValues.Callback);
    }
  }

  [NullableContext(1)]
  [return: Nullable(new byte[] {1, 1, 1, 2})]
  public static Action<ILogger, T1, Exception> Define<[Nullable(2)] T1>(
    LogLevel logLevel,
    EventId eventId,
    string formatString)
  {
    return LoggerMessage.Define<T1>(logLevel, eventId, formatString, (LogDefineOptions) null);
  }

  [return: Nullable(new byte[] {1, 1, 1, 2})]
  public static Action<ILogger, T1, Exception> Define<T1>(
    LogLevel logLevel,
    EventId eventId,
    [Nullable(1)] string formatString,
    LogDefineOptions options)
  {
    LogValuesFormatter formatter = LoggerMessage.CreateLogValuesFormatter(formatString, 1);
    return options != null && options.SkipEnabledCheck ? new Action<ILogger, T1, Exception>(Log) : (Action<ILogger, T1, Exception>) ((logger, arg1, exception) =>
    {
      if (!logger.IsEnabled(logLevel))
        return;
      Log(logger, arg1, exception);
    });

    void Log(ILogger logger, T1 arg1, Exception exception)
    {
      logger.Log<LoggerMessage.LogValues<T1>>(logLevel, eventId, new LoggerMessage.LogValues<T1>(formatter, arg1), exception, LoggerMessage.LogValues<T1>.Callback);
    }
  }

  [return: Nullable(new byte[] {1, 1, 1, 1, 2})]
  public static Action<ILogger, T1, T2, Exception> Define<T1, T2>(
    LogLevel logLevel,
    EventId eventId,
    [Nullable(1)] string formatString)
  {
    return LoggerMessage.Define<T1, T2>(logLevel, eventId, formatString, (LogDefineOptions) null);
  }

  [return: Nullable(new byte[] {1, 1, 1, 1, 2})]
  public static Action<ILogger, T1, T2, Exception> Define<T1, T2>(
    LogLevel logLevel,
    EventId eventId,
    [Nullable(1)] string formatString,
    LogDefineOptions options)
  {
    LogValuesFormatter formatter = LoggerMessage.CreateLogValuesFormatter(formatString, 2);
    return options != null && options.SkipEnabledCheck ? new Action<ILogger, T1, T2, Exception>(Log) : (Action<ILogger, T1, T2, Exception>) ((logger, arg1, arg2, exception) =>
    {
      if (!logger.IsEnabled(logLevel))
        return;
      Log(logger, arg1, arg2, exception);
    });

    void Log(ILogger logger, T1 arg1, T2 arg2, Exception exception)
    {
      logger.Log<LoggerMessage.LogValues<T1, T2>>(logLevel, eventId, new LoggerMessage.LogValues<T1, T2>(formatter, arg1, arg2), exception, LoggerMessage.LogValues<T1, T2>.Callback);
    }
  }

  [return: Nullable(new byte[] {1, 1, 1, 1, 1, 2})]
  public static Action<ILogger, T1, T2, T3, Exception> Define<T1, T2, T3>(
    LogLevel logLevel,
    EventId eventId,
    [Nullable(1)] string formatString)
  {
    return LoggerMessage.Define<T1, T2, T3>(logLevel, eventId, formatString, (LogDefineOptions) null);
  }

  [return: Nullable(new byte[] {1, 1, 1, 1, 1, 2})]
  public static Action<ILogger, T1, T2, T3, Exception> Define<T1, T2, T3>(
    LogLevel logLevel,
    EventId eventId,
    [Nullable(1)] string formatString,
    LogDefineOptions options)
  {
    LogValuesFormatter formatter = LoggerMessage.CreateLogValuesFormatter(formatString, 3);
    return options != null && options.SkipEnabledCheck ? new Action<ILogger, T1, T2, T3, Exception>(Log) : (Action<ILogger, T1, T2, T3, Exception>) ((logger, arg1, arg2, arg3, exception) =>
    {
      if (!logger.IsEnabled(logLevel))
        return;
      Log(logger, arg1, arg2, arg3, exception);
    });

    void Log(ILogger logger, T1 arg1, T2 arg2, T3 arg3, Exception exception)
    {
      logger.Log<LoggerMessage.LogValues<T1, T2, T3>>(logLevel, eventId, new LoggerMessage.LogValues<T1, T2, T3>(formatter, arg1, arg2, arg3), exception, LoggerMessage.LogValues<T1, T2, T3>.Callback);
    }
  }

  [return: Nullable(new byte[] {1, 1, 1, 1, 1, 1, 2})]
  public static Action<ILogger, T1, T2, T3, T4, Exception> Define<T1, T2, T3, T4>(
    LogLevel logLevel,
    EventId eventId,
    [Nullable(1)] string formatString)
  {
    return LoggerMessage.Define<T1, T2, T3, T4>(logLevel, eventId, formatString, (LogDefineOptions) null);
  }

  [return: Nullable(new byte[] {1, 1, 1, 1, 1, 1, 2})]
  public static Action<ILogger, T1, T2, T3, T4, Exception> Define<T1, T2, T3, T4>(
    LogLevel logLevel,
    EventId eventId,
    [Nullable(1)] string formatString,
    LogDefineOptions options)
  {
    LogValuesFormatter formatter = LoggerMessage.CreateLogValuesFormatter(formatString, 4);
    return options != null && options.SkipEnabledCheck ? new Action<ILogger, T1, T2, T3, T4, Exception>(Log) : (Action<ILogger, T1, T2, T3, T4, Exception>) ((logger, arg1, arg2, arg3, arg4, exception) =>
    {
      if (!logger.IsEnabled(logLevel))
        return;
      Log(logger, arg1, arg2, arg3, arg4, exception);
    });

    void Log(ILogger logger, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Exception exception)
    {
      logger.Log<LoggerMessage.LogValues<T1, T2, T3, T4>>(logLevel, eventId, new LoggerMessage.LogValues<T1, T2, T3, T4>(formatter, arg1, arg2, arg3, arg4), exception, LoggerMessage.LogValues<T1, T2, T3, T4>.Callback);
    }
  }

  [return: Nullable(new byte[] {1, 1, 1, 1, 1, 1, 1, 2})]
  public static Action<ILogger, T1, T2, T3, T4, T5, Exception> Define<T1, T2, T3, T4, T5>(
    LogLevel logLevel,
    EventId eventId,
    [Nullable(1)] string formatString)
  {
    return LoggerMessage.Define<T1, T2, T3, T4, T5>(logLevel, eventId, formatString, (LogDefineOptions) null);
  }

  [return: Nullable(new byte[] {1, 1, 1, 1, 1, 1, 1, 2})]
  public static Action<ILogger, T1, T2, T3, T4, T5, Exception> Define<T1, T2, T3, T4, T5>(
    LogLevel logLevel,
    EventId eventId,
    [Nullable(1)] string formatString,
    LogDefineOptions options)
  {
    LogValuesFormatter formatter = LoggerMessage.CreateLogValuesFormatter(formatString, 5);
    return options != null && options.SkipEnabledCheck ? new Action<ILogger, T1, T2, T3, T4, T5, Exception>(Log) : (Action<ILogger, T1, T2, T3, T4, T5, Exception>) ((logger, arg1, arg2, arg3, arg4, arg5, exception) =>
    {
      if (!logger.IsEnabled(logLevel))
        return;
      Log(logger, arg1, arg2, arg3, arg4, arg5, exception);
    });

    void Log(ILogger logger, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Exception exception)
    {
      logger.Log<LoggerMessage.LogValues<T1, T2, T3, T4, T5>>(logLevel, eventId, new LoggerMessage.LogValues<T1, T2, T3, T4, T5>(formatter, arg1, arg2, arg3, arg4, arg5), exception, LoggerMessage.LogValues<T1, T2, T3, T4, T5>.Callback);
    }
  }

  [return: Nullable(new byte[] {1, 1, 1, 1, 1, 1, 1, 1, 2})]
  public static Action<ILogger, T1, T2, T3, T4, T5, T6, Exception> Define<T1, T2, T3, T4, T5, T6>(
    LogLevel logLevel,
    EventId eventId,
    [Nullable(1)] string formatString)
  {
    return LoggerMessage.Define<T1, T2, T3, T4, T5, T6>(logLevel, eventId, formatString, (LogDefineOptions) null);
  }

  [return: Nullable(new byte[] {1, 1, 1, 1, 1, 1, 1, 1, 2})]
  public static Action<ILogger, T1, T2, T3, T4, T5, T6, Exception> Define<T1, T2, T3, T4, T5, T6>(
    LogLevel logLevel,
    EventId eventId,
    [Nullable(1)] string formatString,
    LogDefineOptions options)
  {
    LogValuesFormatter formatter = LoggerMessage.CreateLogValuesFormatter(formatString, 6);
    return options != null && options.SkipEnabledCheck ? new Action<ILogger, T1, T2, T3, T4, T5, T6, Exception>(Log) : (Action<ILogger, T1, T2, T3, T4, T5, T6, Exception>) ((logger, arg1, arg2, arg3, arg4, arg5, arg6, exception) =>
    {
      if (!logger.IsEnabled(logLevel))
        return;
      Log(logger, arg1, arg2, arg3, arg4, arg5, arg6, exception);
    });

    void Log(
      ILogger logger,
      T1 arg1,
      T2 arg2,
      T3 arg3,
      T4 arg4,
      T5 arg5,
      T6 arg6,
      Exception exception)
    {
      logger.Log<LoggerMessage.LogValues<T1, T2, T3, T4, T5, T6>>(logLevel, eventId, new LoggerMessage.LogValues<T1, T2, T3, T4, T5, T6>(formatter, arg1, arg2, arg3, arg4, arg5, arg6), exception, LoggerMessage.LogValues<T1, T2, T3, T4, T5, T6>.Callback);
    }
  }

  private static LogValuesFormatter CreateLogValuesFormatter(
    string formatString,
    int expectedNamedParameterCount)
  {
    LogValuesFormatter logValuesFormatter = new LogValuesFormatter(formatString);
    int count = logValuesFormatter.ValueNames.Count;
    if (count != expectedNamedParameterCount)
      throw new ArgumentException(System.Microsoft.Extensions.Logging.Abstractions1462476.SR.Format(System.Microsoft.Extensions.Logging.Abstractions1462476.SR.UnexpectedNumberOfNamedParameters, (object) formatString, (object) expectedNamedParameterCount, (object) count));
    return logValuesFormatter;
  }

  private readonly struct LogValues(LogValuesFormatter formatter) : 
    IReadOnlyList<KeyValuePair<string, object>>,
    IReadOnlyCollection<KeyValuePair<string, object>>,
    IEnumerable<KeyValuePair<string, object>>,
    IEnumerable
  {
    public static readonly Func<LoggerMessage.LogValues, Exception, string> Callback = (Func<LoggerMessage.LogValues, Exception, string>) ((state, exception) => state.ToString());
    private readonly LogValuesFormatter _formatter = formatter;

    public KeyValuePair<string, object> this[int index]
    {
      get
      {
        if (index != 0)
          throw new IndexOutOfRangeException(nameof (index));
        return new KeyValuePair<string, object>("{OriginalFormat}", (object) this._formatter.OriginalFormat);
      }
    }

    public int Count => 1;

    public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    {
      yield return this[0];
    }

    public override string ToString() => this._formatter.Format();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }

  private readonly struct LogValues<T0>(LogValuesFormatter formatter, T0 value0) : 
    IReadOnlyList<KeyValuePair<string, object>>,
    IReadOnlyCollection<KeyValuePair<string, object>>,
    IEnumerable<KeyValuePair<string, object>>,
    IEnumerable
  {
    public static readonly Func<LoggerMessage.LogValues<T0>, Exception, string> Callback = (Func<LoggerMessage.LogValues<T0>, Exception, string>) ((state, exception) => state.ToString());
    private readonly LogValuesFormatter _formatter = formatter;
    private readonly T0 _value0 = value0;

    public KeyValuePair<string, object> this[int index]
    {
      get
      {
        if (index == 0)
          return new KeyValuePair<string, object>(this._formatter.ValueNames[0], (object) this._value0);
        if (index != 1)
          throw new IndexOutOfRangeException(nameof (index));
        return new KeyValuePair<string, object>("{OriginalFormat}", (object) this._formatter.OriginalFormat);
      }
    }

    public int Count => 2;

    public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    {
      for (int i = 0; i < this.Count; ++i)
        yield return this[i];
    }

    public override string ToString() => this._formatter.Format((object) this._value0);

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }

  private readonly struct LogValues<T0, T1>(LogValuesFormatter formatter, T0 value0, T1 value1) : 
    IReadOnlyList<KeyValuePair<string, object>>,
    IReadOnlyCollection<KeyValuePair<string, object>>,
    IEnumerable<KeyValuePair<string, object>>,
    IEnumerable
  {
    public static readonly Func<LoggerMessage.LogValues<T0, T1>, Exception, string> Callback = (Func<LoggerMessage.LogValues<T0, T1>, Exception, string>) ((state, exception) => state.ToString());
    private readonly LogValuesFormatter _formatter = formatter;
    private readonly T0 _value0 = value0;
    private readonly T1 _value1 = value1;

    public KeyValuePair<string, object> this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[0], (object) this._value0);
          case 1:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[1], (object) this._value1);
          case 2:
            return new KeyValuePair<string, object>("{OriginalFormat}", (object) this._formatter.OriginalFormat);
          default:
            throw new IndexOutOfRangeException(nameof (index));
        }
      }
    }

    public int Count => 3;

    public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    {
      for (int i = 0; i < this.Count; ++i)
        yield return this[i];
    }

    public override string ToString()
    {
      return this._formatter.Format((object) this._value0, (object) this._value1);
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }

  private readonly struct LogValues<T0, T1, T2>(
    LogValuesFormatter formatter,
    T0 value0,
    T1 value1,
    T2 value2) : 
    IReadOnlyList<KeyValuePair<string, object>>,
    IReadOnlyCollection<KeyValuePair<string, object>>,
    IEnumerable<KeyValuePair<string, object>>,
    IEnumerable
  {
    public static readonly Func<LoggerMessage.LogValues<T0, T1, T2>, Exception, string> Callback = (Func<LoggerMessage.LogValues<T0, T1, T2>, Exception, string>) ((state, exception) => state.ToString());
    private readonly LogValuesFormatter _formatter = formatter;
    private readonly T0 _value0 = value0;
    private readonly T1 _value1 = value1;
    private readonly T2 _value2 = value2;

    public int Count => 4;

    public KeyValuePair<string, object> this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[0], (object) this._value0);
          case 1:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[1], (object) this._value1);
          case 2:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[2], (object) this._value2);
          case 3:
            return new KeyValuePair<string, object>("{OriginalFormat}", (object) this._formatter.OriginalFormat);
          default:
            throw new IndexOutOfRangeException(nameof (index));
        }
      }
    }

    public override string ToString()
    {
      return this._formatter.Format((object) this._value0, (object) this._value1, (object) this._value2);
    }

    public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    {
      for (int i = 0; i < this.Count; ++i)
        yield return this[i];
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }

  private readonly struct LogValues<T0, T1, T2, T3>(
    LogValuesFormatter formatter,
    T0 value0,
    T1 value1,
    T2 value2,
    T3 value3) : 
    IReadOnlyList<KeyValuePair<string, object>>,
    IReadOnlyCollection<KeyValuePair<string, object>>,
    IEnumerable<KeyValuePair<string, object>>,
    IEnumerable
  {
    public static readonly Func<LoggerMessage.LogValues<T0, T1, T2, T3>, Exception, string> Callback = (Func<LoggerMessage.LogValues<T0, T1, T2, T3>, Exception, string>) ((state, exception) => state.ToString());
    private readonly LogValuesFormatter _formatter = formatter;
    private readonly T0 _value0 = value0;
    private readonly T1 _value1 = value1;
    private readonly T2 _value2 = value2;
    private readonly T3 _value3 = value3;

    public int Count => 5;

    public KeyValuePair<string, object> this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[0], (object) this._value0);
          case 1:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[1], (object) this._value1);
          case 2:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[2], (object) this._value2);
          case 3:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[3], (object) this._value3);
          case 4:
            return new KeyValuePair<string, object>("{OriginalFormat}", (object) this._formatter.OriginalFormat);
          default:
            throw new IndexOutOfRangeException(nameof (index));
        }
      }
    }

    private object[] ToArray()
    {
      return new object[4]
      {
        (object) this._value0,
        (object) this._value1,
        (object) this._value2,
        (object) this._value3
      };
    }

    public override string ToString() => this._formatter.FormatWithOverwrite(this.ToArray());

    public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    {
      for (int i = 0; i < this.Count; ++i)
        yield return this[i];
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }

  private readonly struct LogValues<T0, T1, T2, T3, T4>(
    LogValuesFormatter formatter,
    T0 value0,
    T1 value1,
    T2 value2,
    T3 value3,
    T4 value4) : 
    IReadOnlyList<KeyValuePair<string, object>>,
    IReadOnlyCollection<KeyValuePair<string, object>>,
    IEnumerable<KeyValuePair<string, object>>,
    IEnumerable
  {
    public static readonly Func<LoggerMessage.LogValues<T0, T1, T2, T3, T4>, Exception, string> Callback = (Func<LoggerMessage.LogValues<T0, T1, T2, T3, T4>, Exception, string>) ((state, exception) => state.ToString());
    private readonly LogValuesFormatter _formatter = formatter;
    private readonly T0 _value0 = value0;
    private readonly T1 _value1 = value1;
    private readonly T2 _value2 = value2;
    private readonly T3 _value3 = value3;
    private readonly T4 _value4 = value4;

    public int Count => 6;

    public KeyValuePair<string, object> this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[0], (object) this._value0);
          case 1:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[1], (object) this._value1);
          case 2:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[2], (object) this._value2);
          case 3:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[3], (object) this._value3);
          case 4:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[4], (object) this._value4);
          case 5:
            return new KeyValuePair<string, object>("{OriginalFormat}", (object) this._formatter.OriginalFormat);
          default:
            throw new IndexOutOfRangeException(nameof (index));
        }
      }
    }

    private object[] ToArray()
    {
      return new object[5]
      {
        (object) this._value0,
        (object) this._value1,
        (object) this._value2,
        (object) this._value3,
        (object) this._value4
      };
    }

    public override string ToString() => this._formatter.FormatWithOverwrite(this.ToArray());

    public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    {
      for (int i = 0; i < this.Count; ++i)
        yield return this[i];
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }

  private readonly struct LogValues<T0, T1, T2, T3, T4, T5>(
    LogValuesFormatter formatter,
    T0 value0,
    T1 value1,
    T2 value2,
    T3 value3,
    T4 value4,
    T5 value5) : 
    IReadOnlyList<KeyValuePair<string, object>>,
    IReadOnlyCollection<KeyValuePair<string, object>>,
    IEnumerable<KeyValuePair<string, object>>,
    IEnumerable
  {
    public static readonly Func<LoggerMessage.LogValues<T0, T1, T2, T3, T4, T5>, Exception, string> Callback = (Func<LoggerMessage.LogValues<T0, T1, T2, T3, T4, T5>, Exception, string>) ((state, exception) => state.ToString());
    private readonly LogValuesFormatter _formatter = formatter;
    private readonly T0 _value0 = value0;
    private readonly T1 _value1 = value1;
    private readonly T2 _value2 = value2;
    private readonly T3 _value3 = value3;
    private readonly T4 _value4 = value4;
    private readonly T5 _value5 = value5;

    public int Count => 7;

    public KeyValuePair<string, object> this[int index]
    {
      get
      {
        switch (index)
        {
          case 0:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[0], (object) this._value0);
          case 1:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[1], (object) this._value1);
          case 2:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[2], (object) this._value2);
          case 3:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[3], (object) this._value3);
          case 4:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[4], (object) this._value4);
          case 5:
            return new KeyValuePair<string, object>(this._formatter.ValueNames[5], (object) this._value5);
          case 6:
            return new KeyValuePair<string, object>("{OriginalFormat}", (object) this._formatter.OriginalFormat);
          default:
            throw new IndexOutOfRangeException(nameof (index));
        }
      }
    }

    private object[] ToArray()
    {
      return new object[6]
      {
        (object) this._value0,
        (object) this._value1,
        (object) this._value2,
        (object) this._value3,
        (object) this._value4,
        (object) this._value5
      };
    }

    public override string ToString() => this._formatter.FormatWithOverwrite(this.ToArray());

    public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    {
      for (int i = 0; i < this.Count; ++i)
        yield return this[i];
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }
}
