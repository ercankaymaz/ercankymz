// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Utils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Microsoft.Extensions.Logging;
using Opc.Ua.Security.Certificates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public static class Utils
{
  public const string UriSchemeHttp = "http";
  public const string UriSchemeHttps = "https";
  public const string UriSchemeOpcHttps = "opc.https";
  public const string UriSchemeOpcTcp = "opc.tcp";
  public const string UriSchemeOpcWss = "opc.wss";
  public const string UriSchemeOpcUdp = "opc.udp";
  public const string UriSchemeMqtt = "mqtt";
  public const string UriSchemeMqtts = "mqtts";
  public static readonly string[] DefaultUriSchemes = new string[4]
  {
    "opc.tcp",
    "opc.https",
    "https",
    "opc.wss"
  };
  public const int UaTcpDefaultPort = 4840;
  public const int UaWebSocketsDefaultPort = 4843;
  public const int MqttDefaultPort = 1883;
  public static readonly string[] DiscoveryUrls = new string[4]
  {
    "opc.tcp://{0}:4840",
    "https://{0}:4843",
    "http://{0}:52601/UADiscovery",
    "http://{0}/UADiscovery/Default.svc"
  };
  public const string DefaultStoreType = "Directory";
  public static readonly string DefaultStorePath = Path.Combine("%CommonApplicationData%", "OPC Foundation", "pki", "own");
  public static readonly string DefaultLocalFolder = Directory.GetCurrentDirectory();
  public static readonly string DefaultOpcUaCoreAssemblyFullName = typeof (Utils).Assembly.GetName().FullName;
  public static readonly string DefaultOpcUaCoreAssemblyName = typeof (Utils).Assembly.GetName().Name;
  public static readonly ReadOnlyDictionary<string, string> DefaultBindings = new ReadOnlyDictionary<string, string>((IDictionary<string, string>) new Dictionary<string, string>()
  {
    {
      "https",
      "Opc.Ua.Bindings.Https"
    },
    {
      "opc.https",
      "Opc.Ua.Bindings.Https"
    }
  });
  private static int s_traceOutput = 1;
  private static int s_traceMasks = 0;
  private static string s_traceFileName = string.Empty;
  private static readonly object s_traceFileLock = new object();
  private static readonly DateTime s_TimeBase = new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc);
  private static readonly Lazy<bool> s_isRunningOnMonoValue = new Lazy<bool>((Func<bool>) (() => Type.GetType("Mono.Runtime") != (Type) null));

  internal static OpcUaCoreEventSource EventLog { get; } = new OpcUaCoreEventSource();

  public static ILogger Logger { get; private set; } = (ILogger) new TraceEventLogger();

  public static void SetLogLevel(Microsoft.Extensions.Logging.LogLevel logLevel)
  {
    if (!(Utils.Logger is TraceEventLogger logger))
      return;
    logger.LogLevel = logLevel;
  }

  public static void SetLogger(ILogger logger)
  {
    Utils.Logger = logger;
    Utils.UseTraceEvent = false;
  }

  public static bool UseTraceEvent { get; set; } = true;

  public static void LogCertificate(
    string message,
    X509Certificate2 certificate,
    params object[] args)
  {
    Utils.LogCertificate(Microsoft.Extensions.Logging.LogLevel.Information, (EventId) 0, message, certificate, args);
  }

  public static void LogCertificate(
    Microsoft.Extensions.Logging.LogLevel logLevel,
    string message,
    X509Certificate2 certificate,
    params object[] args)
  {
    Utils.LogCertificate(logLevel, (EventId) 0, message, certificate, args);
  }

  public static void LogCertificate(
    EventId eventId,
    string message,
    X509Certificate2 certificate,
    params object[] args)
  {
    Utils.LogCertificate(Microsoft.Extensions.Logging.LogLevel.Information, eventId, message, certificate, args);
  }

  public static void LogCertificate(
    Microsoft.Extensions.Logging.LogLevel logLevel,
    EventId eventId,
    string message,
    X509Certificate2 certificate,
    params object[] args)
  {
    if (!Utils.Logger.IsEnabled(logLevel))
      return;
    StringBuilder stringBuilder = new StringBuilder().Append(message);
    if (certificate != null)
    {
      int length = args.Length;
      stringBuilder.Append(" [{");
      stringBuilder.Append(length);
      stringBuilder.Append("}] [{");
      stringBuilder.Append(length + 1);
      stringBuilder.Append("}]");
      object[] objArray = new object[length + 2];
      for (int index = 0; index < length; ++index)
        objArray[index] = args[index];
      objArray[length] = (object) certificate.Subject;
      objArray[length + 1] = (object) certificate.Thumbprint;
      Utils.Log(logLevel, eventId, stringBuilder.ToString(), objArray);
    }
    else
    {
      stringBuilder.Append(" (none)");
      Utils.Log(logLevel, eventId, stringBuilder.ToString(), args);
    }
  }

  [Conditional("DEBUG")]
  public static void LogDebug(
    EventId eventId,
    Exception exception,
    string message,
    params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Debug, eventId, exception, message, args);
  }

  [Conditional("DEBUG")]
  public static void LogDebug(EventId eventId, string message, params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Debug, eventId, message, args);
  }

  [Conditional("DEBUG")]
  public static void LogDebug(Exception exception, string message, params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Debug, exception, message, args);
  }

  [Conditional("DEBUG")]
  public static void LogDebug(string message, params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Debug, message, args);
  }

  public static void LogTrace(
    EventId eventId,
    Exception exception,
    string message,
    params object[] args)
  {
    if (Utils.EventLog.IsEnabled())
    {
      Utils.EventLog.Log(Microsoft.Extensions.Logging.LogLevel.Trace, eventId, exception, message, args);
    }
    else
    {
      if (!Utils.Logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Trace))
        return;
      Utils.Log(Microsoft.Extensions.Logging.LogLevel.Trace, eventId, exception, message, args);
    }
  }

  public static void LogTrace(EventId eventId, string message, params object[] args)
  {
    if (Utils.EventLog.IsEnabled())
    {
      Utils.EventLog.Log(Microsoft.Extensions.Logging.LogLevel.Trace, eventId, message, args);
    }
    else
    {
      if (!Utils.Logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Trace))
        return;
      Utils.Log(Microsoft.Extensions.Logging.LogLevel.Trace, eventId, message, args);
    }
  }

  public static void LogTrace(Exception exception, string message, params object[] args)
  {
    if (Utils.EventLog.IsEnabled())
    {
      Utils.EventLog.Log(Microsoft.Extensions.Logging.LogLevel.Trace, (EventId) 0, exception, message, args);
    }
    else
    {
      if (!Utils.Logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Trace))
        return;
      Utils.Log(Microsoft.Extensions.Logging.LogLevel.Trace, (EventId) 0, exception, message, args);
    }
  }

  public static void LogTrace(string message, params object[] args)
  {
    if (Utils.EventLog.IsEnabled())
    {
      Utils.EventLog.Log(Microsoft.Extensions.Logging.LogLevel.Trace, (EventId) 0, message, args);
    }
    else
    {
      if (!Utils.Logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Trace))
        return;
      Utils.Log(Microsoft.Extensions.Logging.LogLevel.Trace, (EventId) 0, message, args);
    }
  }

  public static void LogInfo(
    EventId eventId,
    Exception exception,
    string message,
    params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Information, eventId, exception, message, args);
  }

  public static void LogInfo(EventId eventId, string message, params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Information, eventId, message, args);
  }

  public static void LogInfo(Exception exception, string message, params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Information, exception, message, args);
  }

  public static void LogInfo(string message, params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Information, message, args);
  }

  public static void LogWarning(
    EventId eventId,
    Exception exception,
    string message,
    params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Warning, eventId, exception, message, args);
  }

  public static void LogWarning(EventId eventId, string message, params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Warning, eventId, message, args);
  }

  public static void LogWarning(Exception exception, string message, params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Warning, exception, message, args);
  }

  public static void LogWarning(string message, params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Warning, message, args);
  }

  public static void LogError(
    EventId eventId,
    Exception exception,
    string message,
    params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Error, eventId, exception, message, args);
  }

  public static void LogError(EventId eventId, string message, params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Error, eventId, message, args);
  }

  public static void LogError(Exception exception, string message, params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Error, exception, message, args);
  }

  public static void LogError(string message, params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Error, message, args);
  }

  public static void LogCritical(
    EventId eventId,
    Exception exception,
    string message,
    params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Critical, eventId, exception, message, args);
  }

  public static void LogCritical(EventId eventId, string message, params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Critical, eventId, message, args);
  }

  public static void LogCritical(Exception exception, string message, params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Critical, exception, message, args);
  }

  public static void LogCritical(string message, params object[] args)
  {
    Utils.Log(Microsoft.Extensions.Logging.LogLevel.Critical, message, args);
  }

  public static void Log(Microsoft.Extensions.Logging.LogLevel logLevel, string message, params object[] args)
  {
    Utils.Log(logLevel, (EventId) 0, (Exception) null, message, args);
  }

  public static void Log(Microsoft.Extensions.Logging.LogLevel logLevel, EventId eventId, string message, params object[] args)
  {
    if (Utils.EventLog.IsEnabled())
    {
      Utils.EventLog.Log(logLevel, eventId, (Exception) null, message, args);
    }
    else
    {
      if (!Utils.Logger.IsEnabled(logLevel))
        return;
      if (Utils.UseTraceEvent && Tracing.IsEnabled())
      {
        int traceMask = Utils.GetTraceMask(eventId, logLevel);
        Tracing.Instance.RaiseTraceEvent(new TraceEventArgs(traceMask, message, string.Empty, (Exception) null, args));
        if ((Utils.s_traceMasks & traceMask) == 0)
          return;
      }
      Utils.Logger.Log(logLevel, eventId, (Exception) null, message, args);
    }
  }

  public static void Log(
    Microsoft.Extensions.Logging.LogLevel logLevel,
    Exception exception,
    string message,
    params object[] args)
  {
    Utils.Log(logLevel, (EventId) 0, exception, message, args);
  }

  public static void Log(
    Microsoft.Extensions.Logging.LogLevel logLevel,
    EventId eventId,
    Exception exception,
    string message,
    params object[] args)
  {
    if (Utils.EventLog.IsEnabled())
    {
      Utils.EventLog.Log(logLevel, eventId, exception, message, args);
    }
    else
    {
      if (!Utils.Logger.IsEnabled(logLevel))
        return;
      if (Utils.UseTraceEvent && Tracing.IsEnabled())
      {
        int traceMask = Utils.GetTraceMask(eventId, logLevel);
        Tracing.Instance.RaiseTraceEvent(new TraceEventArgs(traceMask, message, string.Empty, exception, args));
        if ((Utils.s_traceMasks & traceMask) == 0)
          return;
      }
      Utils.Logger.Log(logLevel, eventId, exception, message, args);
    }
  }

  public static IDisposable BeginScope(string messageFormat, params object[] args)
  {
    return Utils.EventLog.IsEnabled() ? Utils.EventLog.BeginScope(messageFormat, args) : Utils.Logger.BeginScope(messageFormat, args);
  }

  internal static int GetTraceMask(EventId eventId, Microsoft.Extensions.Logging.LogLevel logLevel)
  {
    int traceMask = eventId.Id & 1023 /*0x03FF*/;
    if (traceMask == 0)
    {
      switch (logLevel)
      {
        case Microsoft.Extensions.Logging.LogLevel.Trace:
          traceMask = 32 /*0x20*/;
          break;
        case Microsoft.Extensions.Logging.LogLevel.Information:
          traceMask = 2;
          break;
        case Microsoft.Extensions.Logging.LogLevel.Warning:
        case Microsoft.Extensions.Logging.LogLevel.Error:
        case Microsoft.Extensions.Logging.LogLevel.Critical:
          traceMask = 1;
          break;
      }
    }
    return traceMask;
  }

  public static bool IsUriHttpsScheme(string url)
  {
    return url.StartsWith("https", StringComparison.Ordinal) || url.StartsWith("opc.https", StringComparison.Ordinal);
  }

  public static void SetTraceOutput(Utils.TraceOutput output)
  {
    lock (Utils.s_traceFileLock)
      Utils.s_traceOutput = (int) output;
  }

  public static int TraceMask => Utils.s_traceMasks;

  public static void SetTraceMask(int masks) => Utils.s_traceMasks = masks;

  public static Tracing Tracing => Tracing.Instance;

  private static void TraceWriteLine(string message, params object[] args)
  {
    if (string.IsNullOrEmpty(message))
      return;
    string output = message;
    if (args != null)
    {
      if (args.Length != 0)
      {
        try
        {
          output = string.Format((IFormatProvider) CultureInfo.InvariantCulture, message, args);
        }
        catch (Exception ex)
        {
          output = message;
        }
      }
    }
    Utils.TraceWriteLine(output);
  }

  private static void TraceWriteLine(string output)
  {
    lock (Utils.s_traceFileLock)
    {
      string traceFileName = Utils.s_traceFileName;
      if (Utils.s_traceOutput == 0)
        return;
      if (string.IsNullOrEmpty(traceFileName))
        return;
      try
      {
        FileInfo fileInfo = new FileInfo(traceFileName);
        bool flag = false;
        if (fileInfo.Exists && fileInfo.Length > 10000000L)
        {
          fileInfo.Delete();
          flag = true;
        }
        using (StreamWriter streamWriter = new StreamWriter((Stream) System.IO.File.Open(fileInfo.FullName, FileMode.Append, FileAccess.Write, FileShare.Read)))
        {
          if (flag)
            streamWriter.WriteLine("WARNING - LOG FILE TRUNCATED.");
          streamWriter.WriteLine(output);
          streamWriter.Flush();
        }
      }
      catch (Exception ex)
      {
      }
    }
  }

  public static void SetTraceLog(string filePath, bool deleteExisting)
  {
    lock (Utils.s_traceFileLock)
    {
      if (!string.IsNullOrEmpty(filePath))
      {
        Utils.s_traceFileName = Utils.GetAbsoluteFilePath(filePath, true, false, true, true);
        if (Utils.s_traceOutput == 0)
          Utils.s_traceOutput = 1;
        try
        {
          FileInfo fileInfo = new FileInfo(Utils.s_traceFileName);
          if (deleteExisting && fileInfo.Exists)
            fileInfo.Delete();
          Utils.TraceWriteLine(string.Empty);
          Utils.TraceWriteLine("{1} Logging started at {0}", (object) DateTime.Now, (object) new string('*', 25));
        }
        catch (Exception ex)
        {
          Utils.TraceWriteLine(ex.Message);
        }
      }
      else
        Utils.s_traceFileName = (string) null;
    }
  }

  public static void Trace(string message) => Utils.LogInfo(message);

  public static void Trace(string format, params object[] args) => Utils.LogInfo(format, args);

  [Conditional("DEBUG")]
  public static void TraceDebug(string format, params object[] args)
  {
  }

  public static void Trace(Exception e, string message) => Utils.LogError(e, message);

  public static void Trace(Exception e, string format, params object[] args)
  {
    Utils.LogError(e, format, args);
  }

  internal static StringBuilder TraceExceptionMessage(
    Exception e,
    string format,
    params object[] args)
  {
    StringBuilder stringBuilder = new StringBuilder();
    if (args != null)
    {
      if (args.Length != 0)
      {
        try
        {
          stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, format, args);
          stringBuilder.AppendLine();
          goto label_5;
        }
        catch (Exception ex)
        {
          stringBuilder.AppendLine(format);
          goto label_5;
        }
      }
    }
    stringBuilder.AppendLine(format);
label_5:
    if (e != null)
    {
      if (e is ServiceResultException serviceResultException)
        stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, " {0} '{1}'", (object) StatusCodes.GetBrowseName(serviceResultException.StatusCode), (object) serviceResultException.Message);
      else
        stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, " {0} '{1}'", (object) e.GetType().Name, (object) e.Message);
      stringBuilder.AppendLine();
      if ((Utils.s_traceMasks & 4) != 0)
      {
        stringBuilder.AppendLine();
        stringBuilder.AppendLine();
        string str = new string('=', 40);
        stringBuilder.AppendLine(str);
        stringBuilder.AppendLine(new ServiceResult(e).ToLongString());
        stringBuilder.AppendLine(str);
      }
    }
    return stringBuilder;
  }

  public static void Trace(Exception e, string format, bool handled, params object[] args)
  {
    StringBuilder stringBuilder = Utils.TraceExceptionMessage(e, format, args);
    Utils.Trace(e, 1, stringBuilder.ToString(), handled, (object[]) null);
  }

  public static void Trace(int traceMask, string format, params object[] args)
  {
    if ((traceMask & 5) != 0)
      Utils.LogError((EventId) traceMask, format, args);
    else if ((traceMask & 642) != 0)
      Utils.LogInfo((EventId) traceMask, format, args);
    else
      Utils.LogTrace((EventId) traceMask, format, args);
  }

  public static void Trace(int traceMask, string format, bool handled, params object[] args)
  {
    Utils.Trace((Exception) null, traceMask, format, handled, args);
  }

  public static void Trace<TState>(
    TState state,
    Exception exception,
    int traceMask,
    Func<TState, Exception, string> formatter)
  {
    bool flag1 = Tracing.IsEnabled();
    bool flag2;
    if (!(flag2 = (Utils.s_traceMasks & traceMask) != 0) && !flag1)
      return;
    StringBuilder stringBuilder = new StringBuilder();
    try
    {
      stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "{0:d} {0:HH:mm:ss.fff} ", (object) DateTime.UtcNow.ToLocalTime());
      stringBuilder.Append(formatter(state, exception));
      if (exception != null)
        stringBuilder.Append((object) Utils.TraceExceptionMessage(exception, string.Empty, (object[]) null));
    }
    catch (Exception ex)
    {
      return;
    }
    string str = stringBuilder.ToString();
    if (flag1)
      Tracing.Instance.RaiseTraceEvent(new TraceEventArgs(traceMask, str, string.Empty, exception, Array.Empty<object>()));
    if (!flag2)
      return;
    Utils.TraceWriteLine(str);
  }

  public static void Trace(
    Exception e,
    int traceMask,
    string format,
    bool handled,
    params object[] args)
  {
    if (!handled)
      Tracing.Instance.RaiseTraceEvent(new TraceEventArgs(traceMask, format, string.Empty, e, args));
    if ((Utils.s_traceMasks & traceMask) == 0)
      return;
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "{0:d} {0:HH:mm:ss.fff} ", (object) DateTime.UtcNow.ToLocalTime());
    if (args != null)
    {
      if (args.Length != 0)
      {
        try
        {
          stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, format, args);
          goto label_8;
        }
        catch (Exception ex)
        {
          stringBuilder.Append(format);
          goto label_8;
        }
      }
    }
    stringBuilder.Append(format);
label_8:
    Utils.TraceWriteLine(stringBuilder.ToString());
  }

  public static bool IsPathRooted(string path)
  {
    if (Path.IsPathRooted(path))
      return true;
    return path.Length >= 2 && path[0] == '.' && path[1] != '.';
  }

  private static string ReplaceSpecialFolderWithEnvVar(string input)
  {
    return input == "CommonApplicationData" ? "ProgramData" : input;
  }

  public static string ReplaceSpecialFolderNames(string input)
  {
    if (string.IsNullOrEmpty(input))
      return (string) null;
    if (Utils.IsPathRooted(input) || input[0] != '%')
      return input;
    int num = input.IndexOf('%', 1);
    string input1;
    string str;
    if (num == -1)
    {
      input1 = input.Substring(1);
      str = string.Empty;
    }
    else
    {
      input1 = input.Substring(1, num - 1);
      str = input.Substring(num + 1);
    }
    StringBuilder stringBuilder = new StringBuilder();
    Environment.SpecialFolder result;
    if (!System.Enum.TryParse<Environment.SpecialFolder>(input1, out result))
    {
      string variable = Utils.ReplaceSpecialFolderWithEnvVar(input1);
      string environmentVariable = Environment.GetEnvironmentVariable(variable);
      if (environmentVariable != null)
        stringBuilder.Append(environmentVariable);
      else if (variable == "LocalFolder")
        stringBuilder.Append(Utils.DefaultLocalFolder);
    }
    else
      stringBuilder.Append(Environment.GetFolderPath(result));
    stringBuilder.Append(str);
    return stringBuilder.ToString();
  }

  public static string FindInstalledFile(string fileName)
  {
    if (string.IsNullOrEmpty(fileName))
      return (string) null;
    string installedFile = (string) null;
    for (DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory()); directoryInfo != null; directoryInfo = directoryInfo.Parent)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(directoryInfo.FullName);
      stringBuilder.Append(Path.DirectorySeparatorChar).Append("Bin").Append(Path.DirectorySeparatorChar);
      stringBuilder.Append(fileName);
      installedFile = Utils.GetAbsoluteFilePath(stringBuilder.ToString(), false, false, false);
      if (installedFile != null)
        break;
    }
    return installedFile;
  }

  public static string GetAbsoluteFilePath(string filePath)
  {
    return Utils.GetAbsoluteFilePath(filePath, false, true, false);
  }

  public static string GetAbsoluteFilePath(
    string filePath,
    bool checkCurrentDirectory,
    bool throwOnError,
    bool createAlways,
    bool writable = false)
  {
    filePath = Utils.ReplaceSpecialFolderNames(filePath);
    if (!string.IsNullOrEmpty(filePath))
    {
      FileInfo file1 = new FileInfo(filePath);
      bool flag;
      if (flag = Utils.IsPathRooted(filePath))
      {
        if (file1.Exists)
          return filePath;
        if (createAlways)
          return Utils.CreateFile(file1, filePath, throwOnError);
      }
      if (!flag && checkCurrentDirectory)
      {
        FileInfo file2;
        if (!writable)
        {
          file2 = new FileInfo(Utils.Format("{0}{1}{2}", (object) Directory.GetCurrentDirectory(), (object) Path.DirectorySeparatorChar, (object) filePath));
          if (!file2.Exists)
          {
            FileInfo fileInfo = new FileInfo(Utils.Format("{0}{1}{2}", (object) Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), (object) Path.DirectorySeparatorChar, (object) filePath));
            if (fileInfo.Exists)
              file2 = fileInfo;
          }
        }
        else
          file2 = new FileInfo(Utils.Format("{0}{1}{2}", (object) Path.GetTempPath(), (object) Path.DirectorySeparatorChar, (object) filePath));
        if (file2.Exists)
          return file2.FullName;
        if (file1.Exists && !writable)
          return file1.FullName;
        if (createAlways & writable)
          return Utils.CreateFile(file2, file2.FullName, throwOnError);
      }
    }
    if (throwOnError)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendLine("File does not exist: {0}");
      stringBuilder.AppendLine("Current directory is: {1}");
      throw ServiceResultException.Create(2156462080U /*0x80890000*/, stringBuilder.ToString(), (object) filePath, (object) Directory.GetCurrentDirectory());
    }
    return (string) null;
  }

  private static string CreateFile(FileInfo file, string filePath, bool throwOnError)
  {
    try
    {
      if (!file.Directory.Exists)
        Directory.CreateDirectory(file.DirectoryName);
      using ((Stream) file.Open(FileMode.CreateNew, FileAccess.ReadWrite))
        return filePath;
    }
    catch (Exception ex)
    {
      object[] objArray = new object[1]{ (object) filePath };
      Utils.LogError(ex, "Could not create file: {0}", objArray);
      if (!throwOnError)
        return filePath;
      throw;
    }
  }

  public static string GetAbsoluteDirectoryPath(
    string dirPath,
    bool checkCurrentDirectory,
    bool throwOnError)
  {
    return Utils.GetAbsoluteDirectoryPath(dirPath, checkCurrentDirectory, throwOnError, false);
  }

  public static string GetAbsoluteDirectoryPath(
    string dirPath,
    bool checkCurrentDirectory,
    bool throwOnError,
    bool createAlways)
  {
    string str = dirPath;
    dirPath = Utils.ReplaceSpecialFolderNames(dirPath);
    if (!string.IsNullOrEmpty(dirPath))
    {
      DirectoryInfo directoryInfo1 = new DirectoryInfo(dirPath);
      bool flag;
      if (flag = Utils.IsPathRooted(dirPath))
      {
        if (directoryInfo1.Exists)
          return dirPath;
        if (createAlways && !directoryInfo1.Exists)
          return Directory.CreateDirectory(dirPath).FullName;
      }
      if (!flag)
      {
        if (checkCurrentDirectory && !directoryInfo1.Exists)
        {
          directoryInfo1 = new DirectoryInfo(Utils.Format("{0}{1}{2}", (object) Directory.GetCurrentDirectory(), (object) Path.DirectorySeparatorChar, (object) dirPath));
          if (!directoryInfo1.Exists)
          {
            DirectoryInfo directoryInfo2 = new DirectoryInfo(Utils.Format("{0}{1}{2}", (object) Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), (object) Path.DirectorySeparatorChar, (object) dirPath));
            if (directoryInfo2.Exists)
              directoryInfo1 = directoryInfo2;
          }
        }
        if (directoryInfo1.Exists)
          return directoryInfo1.FullName;
        if (createAlways)
          return Directory.CreateDirectory(directoryInfo1.FullName).FullName;
      }
    }
    if (throwOnError)
      throw ServiceResultException.Create(2156462080U /*0x80890000*/, "Directory does not exist: {0}\r\nCurrent directory is: {1}", (object) str, (object) Directory.GetCurrentDirectory());
    return (string) null;
  }

  public static string GetFilePathDisplayName(string filePath, int maxLength)
  {
    if (filePath == null || maxLength <= 0 || filePath.Length < maxLength)
      return filePath;
    int num = filePath.IndexOf(Path.DirectorySeparatorChar);
    if (num == -1)
      return Utils.Format("{0}...", (object) filePath.Substring(0, maxLength));
    int startIndex = filePath.LastIndexOf(Path.DirectorySeparatorChar);
    while (startIndex > num && filePath.Length - startIndex < maxLength)
    {
      startIndex = filePath.LastIndexOf(Path.DirectorySeparatorChar, startIndex - 1);
      if (filePath.Length - startIndex > maxLength)
      {
        startIndex = filePath.IndexOf(Path.DirectorySeparatorChar, startIndex + 1);
        break;
      }
    }
    return Utils.Format("{0}...{1}", (object) filePath.Substring(0, num + 1), (object) filePath.Substring(startIndex));
  }

  public static void SilentDispose(object objectToDispose)
  {
    Utils.SilentDispose(objectToDispose as IDisposable);
  }

  public static void SilentDispose(IDisposable disposable)
  {
    try
    {
      disposable?.Dispose();
    }
    catch (Exception ex)
    {
    }
  }

  public static DateTime TimeBase => Utils.s_TimeBase;

  public static DateTime ToOpcUaUniversalTime(DateTime value)
  {
    if (value <= DateTime.MinValue)
      return DateTime.MinValue;
    if (value >= DateTime.MaxValue)
      return DateTime.MaxValue;
    return value.Kind != DateTimeKind.Utc ? value.ToUniversalTime() : value;
  }

  public static DateTime GetDeadline(TimeSpan timeSpan)
  {
    DateTime utcNow = DateTime.UtcNow;
    return DateTime.MaxValue.Ticks - utcNow.Ticks < timeSpan.Ticks ? DateTime.MaxValue : utcNow + timeSpan;
  }

  public static int GetTimeout(TimeSpan timeSpan)
  {
    if (timeSpan.TotalMilliseconds > (double) int.MaxValue)
      return -1;
    return timeSpan.TotalMilliseconds < 0.0 ? 0 : (int) timeSpan.TotalMilliseconds;
  }

  public static Task<IPAddress[]> GetHostAddressesAsync(string hostNameOrAddress)
  {
    return Dns.GetHostAddressesAsync(hostNameOrAddress);
  }

  public static IPAddress[] GetHostAddresses(string hostNameOrAddress)
  {
    return Dns.GetHostAddresses(hostNameOrAddress);
  }

  public static string GetHostName() => Dns.GetHostName().Split('.')[0].ToLowerInvariant();

  public static string GetFullQualifiedDomainName()
  {
    string str = (string) null;
    try
    {
      str = Dns.GetHostEntry("localhost").HostName;
    }
    catch
    {
    }
    return string.IsNullOrEmpty(str) ? Dns.GetHostName() : str;
  }

  public static string NormalizedIPAddress(string ipAddress)
  {
    try
    {
      return IPAddress.Parse(ipAddress).ToString();
    }
    catch
    {
      return ipAddress;
    }
  }

  public static string ReplaceLocalhost(string uri, string hostname = null)
  {
    if (string.IsNullOrEmpty(uri))
      return uri;
    if (!string.IsNullOrEmpty(hostname) && hostname.Contains<char>(':'))
      hostname = $"[{hostname}]";
    string str = "localhost";
    int length = uri.IndexOf(str, StringComparison.OrdinalIgnoreCase);
    if (length == -1)
      return uri;
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append(uri.Substring(0, length)).Append(hostname ?? Utils.GetHostName()).Append(uri.Substring(length + str.Length));
    return stringBuilder.ToString();
  }

  public static string ReplaceDCLocalhost(string subjectName, string hostname = null)
  {
    if (string.IsNullOrEmpty(subjectName))
      return subjectName;
    if (!string.IsNullOrEmpty(hostname) && hostname.Contains<char>(':'))
      hostname = $"[{hostname}]";
    string str = "DC=localhost";
    int num = subjectName.IndexOf(str, StringComparison.OrdinalIgnoreCase);
    if (num == -1)
      return subjectName;
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append(subjectName.Substring(0, num + 3)).Append(hostname ?? Utils.GetHostName()).Append(subjectName.Substring(num + str.Length));
    return stringBuilder.ToString();
  }

  public static Uri ParseUri(string uri)
  {
    try
    {
      return string.IsNullOrEmpty(uri) ? (Uri) null : new Uri(uri);
    }
    catch (Exception ex)
    {
      return (Uri) null;
    }
  }

  public static bool AreDomainsEqual(Uri url1, Uri url2)
  {
    if (!(url1 == (Uri) null))
    {
      if (!(url2 == (Uri) null))
      {
        try
        {
          string domain1 = url1.DnsSafeHost;
          string domain2 = url2.DnsSafeHost;
          if (domain1 == "localhost")
            domain1 = Utils.GetHostName();
          if (domain2 == "localhost")
            domain2 = Utils.GetHostName();
          return Utils.AreDomainsEqual(domain1, domain2);
        }
        catch (Exception ex)
        {
          return false;
        }
      }
    }
    return false;
  }

  public static bool AreDomainsEqual(string domain1, string domain2)
  {
    return !string.IsNullOrEmpty(domain1) && !string.IsNullOrEmpty(domain2) && string.Equals(domain1, domain2, StringComparison.OrdinalIgnoreCase);
  }

  public static string UpdateInstanceUri(string instanceUri)
  {
    if (string.IsNullOrEmpty(instanceUri))
      return new UriBuilder()
      {
        Scheme = "https",
        Host = Utils.GetHostName(),
        Port = -1,
        Path = Guid.NewGuid().ToString()
      }.Uri.ToString();
    if (!instanceUri.StartsWith("https", StringComparison.Ordinal))
      return new UriBuilder()
      {
        Scheme = "https",
        Host = Utils.GetHostName(),
        Port = -1,
        Path = Uri.EscapeDataString(instanceUri)
      }.Uri.ToString();
    Uri uri = Utils.ParseUri(instanceUri);
    if (!(uri != (Uri) null) || !(uri.DnsSafeHost == "localhost"))
      return instanceUri;
    return new UriBuilder(uri)
    {
      Host = Utils.GetHostName()
    }.Uri.ToString();
  }

  public static uint LowerLimitIdentifier(ref long identifier, uint lowerLimit)
  {
    long comparand;
    long num;
    do
    {
      comparand = Interlocked.Read(ref identifier);
      num = comparand;
      if (comparand < (long) lowerLimit)
        goto label_2;
label_1:
      continue;
label_2:
      num = Interlocked.CompareExchange(ref identifier, (long) lowerLimit, comparand);
      goto label_1;
    }
    while (num != comparand);
    return (uint) Interlocked.Read(ref identifier);
  }

  public static uint IncrementIdentifier(ref long identifier)
  {
    Interlocked.CompareExchange(ref identifier, 0L, (long) uint.MaxValue);
    return (uint) Interlocked.Increment(ref identifier);
  }

  public static int IncrementIdentifier(ref int identifier)
  {
    Interlocked.CompareExchange(ref identifier, 0, int.MaxValue);
    return Interlocked.Increment(ref identifier);
  }

  public static int ToInt32(uint identifier)
  {
    return identifier <= (uint) int.MaxValue ? (int) identifier : -(int) ((long) uint.MaxValue - (long) identifier + 1L);
  }

  public static uint ToUInt32(int identifier)
  {
    return identifier >= 0 ? (uint) identifier : (uint) (4294967296UL /*0x0100000000*/ + (ulong) identifier);
  }

  public static Array FlattenArray(Array array)
  {
    Array instance = Array.CreateInstance(array.GetType().GetElementType(), array.Length);
    int[] numArray1 = new int[array.Rank];
    int[] numArray2 = new int[array.Rank];
    for (int index = array.Rank - 1; index >= 0; --index)
      numArray2[index] = array.GetLength(array.Rank - index - 1);
    for (int index1 = 0; index1 < array.Length; ++index1)
    {
      numArray1[array.Rank - 1] = index1 % numArray2[0];
      for (int index2 = 1; index2 < array.Rank; ++index2)
      {
        int num = 1;
        for (int index3 = 0; index3 < index2; ++index3)
          num *= numArray2[index3];
        numArray1[array.Rank - index2 - 1] = index1 / num % numArray2[index2];
      }
      instance.SetValue(array.GetValue(numArray1), index1);
    }
    return instance;
  }

  public static string ToHexString(byte[] buffer, bool invertEndian = false)
  {
    if (buffer == null || buffer.Length == 0)
      return string.Empty;
    StringBuilder stringBuilder = new StringBuilder(buffer.Length * 2);
    if (invertEndian)
    {
      for (int index = buffer.Length - 1; index >= 0; --index)
        stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "{0:X2}", (object) buffer[index]);
    }
    else
    {
      for (int index = 0; index < buffer.Length; ++index)
        stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "{0:X2}", (object) buffer[index]);
    }
    return stringBuilder.ToString();
  }

  public static byte[] FromHexString(string buffer)
  {
    switch (buffer)
    {
      case null:
        return (byte[]) null;
      case "":
        return Array.Empty<byte>();
      default:
        buffer.ToUpperInvariant();
        byte[] numArray = new byte[buffer.Length / 2 + buffer.Length % 2];
        for (int index = 0; index < numArray.Length * 2; index += 2)
        {
          int num1 = "0123456789ABCDEF".IndexOf(buffer[index]);
          if (num1 != -1)
          {
            byte num2 = (byte) ((uint) (byte) num1 << 4);
            if (index < buffer.Length - 1)
            {
              int num3 = "0123456789ABCDEF".IndexOf(buffer[index + 1]);
              if (num3 != -1)
                num2 += (byte) num3;
              else
                break;
            }
            numArray[index / 2] = num2;
          }
          else
            break;
        }
        return numArray;
    }
  }

  public static string ToString(object source)
  {
    return source != null ? string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}", source) : string.Empty;
  }

  public static string Format(string text, params object[] args)
  {
    return string.Format((IFormatProvider) CultureInfo.InvariantCulture, text, args);
  }

  public static bool IsValidLocaleId(string localeId)
  {
    if (string.IsNullOrEmpty(localeId))
      return false;
    try
    {
      if (new CultureInfo(localeId) != null)
        return true;
    }
    catch (Exception ex)
    {
    }
    return false;
  }

  public static string GetLanguageId(string localeId)
  {
    if (localeId == null)
      return string.Empty;
    int length = localeId.IndexOf('-');
    return length != -1 ? localeId.Substring(0, length) : localeId;
  }

  public static LocalizedText SelectLocalizedText(
    IList<string> localeIds,
    IList<LocalizedText> names,
    LocalizedText defaultName)
  {
    if (localeIds == null || localeIds.Count == 0 || names == null || names.Count == 0)
      return defaultName;
    for (int index1 = 0; index1 < localeIds.Count; ++index1)
    {
      for (int index2 = 0; index2 < names.Count; ++index2)
      {
        if (!LocalizedText.IsNullOrEmpty(names[index2]) && string.Equals(names[index2].Locale, localeIds[index1], StringComparison.OrdinalIgnoreCase))
          return names[index2];
      }
    }
    for (int index3 = 0; index3 < localeIds.Count; ++index3)
    {
      string languageId1 = Utils.GetLanguageId(localeIds[index3]);
      for (int index4 = 0; index4 < names.Count; ++index4)
      {
        if (!LocalizedText.IsNullOrEmpty(names[index4]))
        {
          string languageId2 = Utils.GetLanguageId(names[index4].Locale);
          if (string.Equals(languageId1, languageId2, StringComparison.OrdinalIgnoreCase))
            return names[index4];
        }
      }
    }
    return defaultName;
  }

  public static object Clone(object value)
  {
    if (value == null)
      return (object) null;
    Type type = value.GetType();
    if (type.GetTypeInfo().IsValueType || type == typeof (string))
      return value;
    switch (value)
    {
      case Array array:
        if (array.Rank == 1)
        {
          Array instance = Array.CreateInstance(type.GetElementType(), array.Length);
          for (int index = 0; index < array.Length; ++index)
            instance.SetValue(Utils.Clone(array.GetValue(index)), index);
          return (object) instance;
        }
        int[] numArray1 = new int[array.Rank];
        int[] numArray2 = new int[array.Rank];
        for (int dimension = 0; dimension < array.Rank; ++dimension)
        {
          numArray1[dimension] = array.GetLength(dimension);
          numArray2[dimension] = 0;
        }
        Array instance1 = Array.CreateInstance(type.GetElementType(), numArray1);
        for (int index1 = 0; index1 < array.Length; ++index1)
        {
          instance1.SetValue(Utils.Clone(array.GetValue(numArray2)), numArray2);
          for (int index2 = 0; index2 < array.Rank; ++index2)
          {
            ++numArray2[index2];
            if (numArray2[index2] >= numArray1[index2])
              numArray2[index2] = 0;
            else
              break;
          }
        }
        return (object) instance1;
      case XmlNode xmlNode:
        return (object) xmlNode.CloneNode(true);
      case ICloneable cloneable:
        return cloneable.Clone();
      default:
        MethodInfo method1 = type.GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.Public);
        if (method1 != (MethodInfo) null)
        {
          object obj = method1.Invoke(value, (object[]) null);
          if (obj != null)
          {
            Utils.LogTrace("MemberwiseClone without ICloneable in class '{0}'", (object) type.FullName);
            return obj;
          }
        }
        MethodInfo method2 = type.GetMethod(nameof (Clone), BindingFlags.Instance | BindingFlags.Public);
        if (method2 != (MethodInfo) null)
        {
          object obj = method2.Invoke(value, (object[]) null);
          if (obj != null)
          {
            Utils.LogTrace("Clone without ICloneable in class '{0}'", (object) type.FullName);
            return obj;
          }
        }
        throw new NotSupportedException(Utils.Format("Don't know how to clone objects of type '{0}'", (object) type.FullName));
    }
  }

  public static bool IsEqualUserIdentity(UserIdentityToken identity1, UserIdentityToken identity2)
  {
    if (identity1 == identity2)
      return true;
    if (identity1 == null || identity2 == null)
      return false;
    switch (identity1)
    {
      case AnonymousIdentityToken _ when identity2 is AnonymousIdentityToken:
        return true;
      case UserNameIdentityToken nameIdentityToken2 when identity2 is UserNameIdentityToken nameIdentityToken1:
        return string.Equals(nameIdentityToken2.UserName, nameIdentityToken1.UserName, StringComparison.Ordinal);
      case X509IdentityToken x509IdentityToken2 when identity2 is X509IdentityToken x509IdentityToken1:
        return Utils.IsEqual((object) x509IdentityToken2.CertificateData, (object) x509IdentityToken1.CertificateData);
      case IssuedIdentityToken issuedIdentityToken2 when identity2 is IssuedIdentityToken issuedIdentityToken1:
        return Utils.IsEqual((object) issuedIdentityToken2.DecryptedTokenData, (object) issuedIdentityToken1.DecryptedTokenData);
      default:
        return false;
    }
  }

  public static bool IsEqual(DateTime time1, DateTime time2)
  {
    DateTime opcUaUniversalTime1 = Utils.ToOpcUaUniversalTime(time1);
    DateTime opcUaUniversalTime2 = Utils.ToOpcUaUniversalTime(time2);
    return opcUaUniversalTime1 <= Utils.TimeBase && opcUaUniversalTime2 <= Utils.TimeBase || opcUaUniversalTime1 >= DateTime.MaxValue && opcUaUniversalTime2 >= DateTime.MaxValue || opcUaUniversalTime1.CompareTo(opcUaUniversalTime2) == 0;
  }

  public static bool IsEqual(object value1, object value2)
  {
    if (value1 == value2)
      return true;
    if (value1 == null)
      return value2 == null || value2.Equals(value1);
    if (value2 == null || value1.GetType() != value2.GetType())
      return value1.Equals(value2);
    switch (value1)
    {
      case DateTime time1:
        return Utils.IsEqual(time1, (DateTime) value2);
      case IComparable comparable:
        return comparable.CompareTo(value2) == 0;
      case IEncodeable encodeable2:
        return value2 is IEncodeable encodeable1 && encodeable2.IsEqual(encodeable1);
      case XmlElement xmlElement2:
        return value2 is XmlElement xmlElement1 && xmlElement2.OuterXml == xmlElement1.OuterXml;
      case Array array2:
        if (!(value2 is Array array1) || array2.Length != array1.Length || array2.Rank != array1.Rank)
          return false;
        for (int dimension = 0; dimension < array2.Rank; ++dimension)
        {
          if (array2.GetLowerBound(dimension) != array1.GetLowerBound(dimension) || array2.GetUpperBound(dimension) != array1.GetUpperBound(dimension))
            return false;
        }
        IEnumerator enumerator1 = array2.GetEnumerator();
        IEnumerator enumerator2 = array1.GetEnumerator();
        while (enumerator1.MoveNext())
        {
          enumerator2.MoveNext();
          if (!Utils.IsEqual(enumerator1.Current, enumerator2.Current))
            return false;
        }
        return true;
      case IEnumerable enumerable2:
        if (!(value2 is IEnumerable enumerable1))
          return false;
        IEnumerator enumerator3 = enumerable2.GetEnumerator();
        IEnumerator enumerator4 = enumerable1.GetEnumerator();
        while (enumerator3.MoveNext())
        {
          if (!enumerator4.MoveNext() || !Utils.IsEqual(enumerator3.Current, enumerator4.Current))
            return false;
        }
        return !enumerator4.MoveNext();
      default:
        return value1.Equals(value2);
    }
  }

  public static bool Match(string target, string pattern, bool caseSensitive)
  {
    if (string.IsNullOrEmpty(pattern))
      return true;
    if (string.IsNullOrEmpty(target))
      return false;
    if (caseSensitive)
    {
      if (target == pattern)
        return true;
    }
    else if (string.Equals(target, pattern, StringComparison.OrdinalIgnoreCase))
      return true;
    int num1 = 0;
    int num2 = 0;
label_33:
    while (num2 < target.Length && num1 < pattern.Length)
    {
      char ch1 = Utils.ConvertCase(pattern[num1++], caseSensitive);
      if (num1 > pattern.Length)
        return num2 >= target.Length;
      switch (ch1)
      {
        case '#':
          if (!char.IsDigit(target[num2++]))
            return false;
          continue;
        case '*':
          while (num2 < target.Length)
          {
            if (Utils.Match(target.Substring(num2++), pattern.Substring(num1), caseSensitive))
              return true;
          }
          return Utils.Match(target, pattern.Substring(num1), caseSensitive);
        case '?':
          if (num2 >= target.Length || num1 >= pattern.Length && num2 < target.Length - 1)
            return false;
          ++num2;
          continue;
        case '[':
          char ch2 = Utils.ConvertCase(target[num2++], caseSensitive);
          if (num2 > target.Length)
            return false;
          char ch3 = char.MinValue;
          if (pattern[num1] == '!')
          {
            int num3 = num1 + 1;
            string str = pattern;
            int index = num3;
            num1 = index + 1;
            char ch4 = Utils.ConvertCase(str[index], caseSensitive);
            for (; num1 < pattern.Length; ch4 = Utils.ConvertCase(pattern[num1++], caseSensitive))
            {
              switch (ch4)
              {
                case '-':
                  ch4 = Utils.ConvertCase(pattern[num1], caseSensitive);
                  if (num1 > pattern.Length || ch4 == ']' || (int) ch2 >= (int) ch3 && (int) ch2 <= (int) ch4)
                    return false;
                  break;
                case ']':
                  goto label_33;
              }
              ch3 = ch4;
              if ((int) ch2 == (int) ch4)
                return false;
            }
            continue;
          }
          char ch5;
          for (ch5 = Utils.ConvertCase(pattern[num1++], caseSensitive); num1 < pattern.Length; ch5 = Utils.ConvertCase(pattern[num1++], caseSensitive))
          {
            switch (ch5)
            {
              case '-':
                ch5 = Utils.ConvertCase(pattern[num1], caseSensitive);
                if (num1 > pattern.Length || ch5 == ']')
                  return false;
                if ((int) ch2 < (int) ch3 || (int) ch2 > (int) ch5)
                  break;
                goto label_30;
              case ']':
                return false;
            }
            ch3 = ch5;
            if ((int) ch2 == (int) ch5)
              break;
          }
label_30:
          while (true)
          {
            if (num1 < pattern.Length && ch5 != ']')
              ch5 = pattern[num1++];
            else
              goto label_33;
          }
        default:
          if ((int) Utils.ConvertCase(target[num2++], caseSensitive) != (int) ch1 || num1 >= pattern.Length && num2 < target.Length - 1)
            return false;
          continue;
      }
    }
    return num2 < target.Length || num1 >= pattern.Length;
  }

  private static char ConvertCase(char c, bool caseSensitive)
  {
    return !caseSensitive ? char.ToUpperInvariant(c) : c;
  }

  public static TimeZoneDataType GetTimeZoneInfo()
  {
    return new TimeZoneDataType()
    {
      Offset = (short) TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).TotalMinutes,
      DaylightSavingInOffset = true
    };
  }

  public static T ParseExtension<T>(IList<XmlElement> extensions, XmlQualifiedName elementName)
  {
    if (extensions == null || extensions.Count == 0)
      return default (T);
    if (elementName == (XmlQualifiedName) null)
    {
      XmlQualifiedName xmlName = EncodeableFactory.GetXmlName(typeof (T));
      elementName = !(xmlName == (XmlQualifiedName) null) ? xmlName : throw new ArgumentException("Type does not seem to support DataContract serialization");
    }
    for (int index = 0; index < extensions.Count; ++index)
    {
      XmlElement extension = extensions[index];
      if (!(extension.LocalName != elementName.Name) && !(extension.NamespaceURI != elementName.Namespace))
      {
        XmlReader reader = XmlReader.Create((TextReader) new StringReader(extension.OuterXml), Utils.DefaultXmlReaderSettings());
        try
        {
          return (T) new DataContractSerializer(typeof (T)).ReadObject(reader);
        }
        catch (Exception ex)
        {
          Utils.LogError("Exception parsing extension: " + ex.Message);
          throw;
        }
        finally
        {
          reader.Dispose();
        }
      }
    }
    return default (T);
  }

  public static void UpdateExtension<T>(
    ref XmlElementCollection extensions,
    XmlQualifiedName elementName,
    object value)
  {
    XmlDocument doc = new XmlDocument();
    StringBuilder output = new StringBuilder();
    using (XmlWriter writer = XmlWriter.Create(output))
    {
      if (value != null)
      {
        try
        {
          new DataContractSerializer(typeof (T)).WriteObject(writer, value);
        }
        finally
        {
          writer.Dispose();
        }
        doc.LoadInnerXml(output.ToString());
      }
    }
    if (elementName == (XmlQualifiedName) null)
    {
      XmlQualifiedName xmlName = EncodeableFactory.GetXmlName(typeof (T));
      elementName = !(xmlName == (XmlQualifiedName) null) ? xmlName : throw new ArgumentException("Type does not seem to support DataContract serialization");
    }
    if (extensions != null)
    {
      for (int index = 0; index < extensions.Count; ++index)
      {
        if (extensions[index] != null && extensions[index].LocalName == elementName.Name && extensions[index].NamespaceURI == elementName.Namespace)
        {
          if (value == null)
          {
            extensions.RemoveAt(index);
            return;
          }
          extensions[index] = doc.DocumentElement;
          return;
        }
      }
    }
    if (value == null)
      return;
    if (extensions == null)
      extensions = new XmlElementCollection();
    extensions.Add(doc.DocumentElement);
  }

  public static string[] GetFieldNames(Type systemType)
  {
    FieldInfo[] fields = systemType.GetFields(BindingFlags.Static | BindingFlags.Public);
    int num = 0;
    string[] fieldNames = new string[fields.Length];
    foreach (FieldInfo fieldInfo in fields)
      fieldNames[num++] = fieldInfo.Name;
    return fieldNames;
  }

  public static string GetDataMemberName(PropertyInfo property)
  {
    object[] array = ((IEnumerable<object>) property.GetCustomAttributes(typeof (DataMemberAttribute), true)).ToArray<object>();
    if (array != null)
    {
      for (int index = 0; index < array.Length; ++index)
      {
        if (array[index] is DataMemberAttribute dataMemberAttribute)
          return string.IsNullOrEmpty(dataMemberAttribute.Name) ? property.Name : dataMemberAttribute.Name;
      }
    }
    return (string) null;
  }

  public static uint GetIdentifier(string name, Type constants)
  {
    foreach (FieldInfo field in constants.GetFields(BindingFlags.Static | BindingFlags.Public))
    {
      if (field.Name == name)
        return (uint) field.GetValue((object) constants);
    }
    return 0;
  }

  public static DateTime GetAssemblyTimestamp()
  {
    try
    {
      return System.IO.File.GetLastWriteTimeUtc(typeof (Utils).GetTypeInfo().Assembly.Location);
    }
    catch
    {
    }
    return new DateTime(1970, 1, 1, 0, 0, 0);
  }

  public static string GetAssemblySoftwareVersion()
  {
    return typeof (Utils).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
  }

  public static string GetAssemblyBuildNumber()
  {
    return typeof (Utils).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
  }

  public static XmlReaderSettings DefaultXmlReaderSettings()
  {
    return new XmlReaderSettings()
    {
      DtdProcessing = DtdProcessing.Prohibit,
      XmlResolver = (XmlResolver) null,
      ConformanceLevel = ConformanceLevel.Document
    };
  }

  public static XmlWriterSettings DefaultXmlWriterSettings()
  {
    return new XmlWriterSettings()
    {
      Encoding = Encoding.UTF8,
      Indent = true,
      ConformanceLevel = ConformanceLevel.Document,
      IndentChars = "  ",
      CloseOutput = false
    };
  }

  internal static void LoadInnerXml(this XmlDocument doc, string xml)
  {
    using (StringReader input = new StringReader(xml))
    {
      using (XmlReader reader = XmlReader.Create((TextReader) input, Utils.DefaultXmlReaderSettings()))
      {
        doc.XmlResolver = (XmlResolver) null;
        doc.Load(reader);
      }
    }
  }

  public static byte[] Append(params byte[][] arrays)
  {
    if (arrays == null)
      return Array.Empty<byte>();
    int length = 0;
    for (int index = 0; index < arrays.Length; ++index)
    {
      if (arrays[index] != null)
        length += arrays[index].Length;
    }
    byte[] destinationArray = new byte[length];
    int destinationIndex = 0;
    for (int index = 0; index < arrays.Length; ++index)
    {
      if (arrays[index] != null)
      {
        Array.Copy((Array) arrays[index], 0, (Array) destinationArray, destinationIndex, arrays[index].Length);
        destinationIndex += arrays[index].Length;
      }
    }
    return destinationArray;
  }

  public static X509Certificate2 ParseCertificateBlob(byte[] certificateData)
  {
    bool flag = false;
    try
    {
      return flag ? CertificateFactory.Create(AsnUtils.ParseX509Blob(certificateData), true) : CertificateFactory.Create(certificateData, true);
    }
    catch (Exception ex)
    {
      throw new ServiceResultException(2148663296U /*0x80120000*/, "Could not parse DER encoded form of a X509 certificate.", ex);
    }
  }

  public static X509Certificate2Collection ParseCertificateChainBlob(byte[] certificateData)
  {
    X509Certificate2Collection certificateChainBlob = new X509Certificate2Collection();
    List<byte> byteList = new List<byte>((IEnumerable<byte>) certificateData);
    bool flag = false;
    while (byteList.Count > 0)
    {
      X509Certificate2 certificate;
      try
      {
        certificate = !flag ? CertificateFactory.Create(byteList.ToArray(), true) : CertificateFactory.Create(AsnUtils.ParseX509Blob(byteList.ToArray()), true);
      }
      catch (Exception ex)
      {
        throw new ServiceResultException(2148663296U /*0x80120000*/, "Could not parse DER encoded form of a X509 certificate.", ex);
      }
      certificateChainBlob.Add(certificate);
      byteList.RemoveRange(0, certificate.RawData.Length);
    }
    return certificateChainBlob;
  }

  public static bool CompareNonce(byte[] a, byte[] b)
  {
    if (a == null || b == null || a.Length != b.Length)
      return false;
    byte num = 0;
    for (int index = 0; index < a.Length; ++index)
      num |= (byte) ((uint) a[index] ^ (uint) b[index]);
    return num == (byte) 0;
  }

  public static byte[] PSHA1(byte[] secret, string label, byte[] data, int offset, int length)
  {
    if (secret == null)
      throw new ArgumentNullException(nameof (secret));
    return Utils.PSHA((HMAC) new HMACSHA1(secret), label, data, offset, length);
  }

  public static byte[] PSHA256(byte[] secret, string label, byte[] data, int offset, int length)
  {
    if (secret == null)
      throw new ArgumentNullException(nameof (secret));
    return Utils.PSHA((HMAC) new HMACSHA256(secret), label, data, offset, length);
  }

  private static byte[] PSHA(HMAC hmac, string label, byte[] data, int offset, int length)
  {
    if (hmac == null)
      throw new ArgumentNullException(nameof (hmac));
    if (offset < 0)
      throw new ArgumentOutOfRangeException(nameof (offset));
    if (length < 0)
      throw new ArgumentOutOfRangeException(nameof (length));
    byte[] numArray1 = (byte[]) null;
    if (!string.IsNullOrEmpty(label))
      numArray1 = Encoding.UTF8.GetBytes(label);
    if (data != null && data.Length != 0)
    {
      if (numArray1 != null)
      {
        byte[] numArray2 = new byte[numArray1.Length + data.Length];
        numArray1.CopyTo((Array) numArray2, 0);
        data.CopyTo((Array) numArray2, numArray1.Length);
        numArray1 = numArray2;
      }
      else
        numArray1 = data;
    }
    byte[] numArray3 = numArray1 != null ? hmac.ComputeHash(numArray1) : throw new ServiceResultException(2147549184U /*0x80010000*/, "The HMAC algorithm requires a non-null seed.");
    byte[] numArray4 = new byte[hmac.HashSize / 8 + numArray1.Length];
    Array.Copy((Array) numArray3, (Array) numArray4, numArray3.Length);
    Array.Copy((Array) numArray1, 0, (Array) numArray4, numArray3.Length, numArray1.Length);
    byte[] numArray5 = new byte[length];
    int num = 0;
    do
    {
      byte[] hash = hmac.ComputeHash(numArray4);
      if (offset < hash.Length)
        goto label_19;
label_15:
      if (offset > hash.Length)
        offset -= hash.Length;
      else
        offset = 0;
      numArray3 = hmac.ComputeHash(numArray3);
      Array.Copy((Array) numArray3, (Array) numArray4, numArray3.Length);
      continue;
label_19:
      for (int index = offset; num < length && index < hash.Length; ++index)
        numArray5[num++] = hash[index];
      goto label_15;
    }
    while (num < length);
    return numArray5;
  }

  public static bool FindStringIgnoreCase(IList<string> strings, string target)
  {
    if (strings == null || strings.Count == 0)
      return false;
    for (int index = 0; index < strings.Count; ++index)
    {
      if (string.Equals(strings[index], target, StringComparison.OrdinalIgnoreCase))
        return true;
    }
    return false;
  }

  public static bool IsRunningOnMono() => Utils.s_isRunningOnMonoValue.Value;

  public enum TraceOutput
  {
    Off,
    FileOnly,
    DebugAndFile,
  }

  public static class TraceMasks
  {
    public const int None = 0;
    public const int Error = 1;
    public const int Information = 2;
    public const int StackTrace = 4;
    public const int Service = 8;
    public const int ServiceDetail = 16 /*0x10*/;
    public const int Operation = 32 /*0x20*/;
    public const int OperationDetail = 64 /*0x40*/;
    public const int StartStop = 128 /*0x80*/;
    public const int ExternalSystem = 256 /*0x0100*/;
    public const int Security = 512 /*0x0200*/;
    public const int All = 1023 /*0x03FF*/;
  }

  public static class Nonce
  {
    private static readonly System.Security.Cryptography.RandomNumberGenerator m_rng = System.Security.Cryptography.RandomNumberGenerator.Create();

    public static byte[] CreateNonce(uint length)
    {
      byte[] data = new byte[(int) length];
      Utils.Nonce.m_rng.GetBytes(data);
      return data;
    }

    public static uint GetNonceLength(string securityPolicyUri)
    {
      switch (securityPolicyUri)
      {
        case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
          return 16 /*0x10*/;
        case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
        case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
        case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
        case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
          return 32 /*0x20*/;
        default:
          return 0;
      }
    }

    public static bool ValidateNonce(
      byte[] nonce,
      MessageSecurityMode securityMode,
      string securityPolicyUri)
    {
      return Utils.Nonce.ValidateNonce(nonce, securityMode, Utils.Nonce.GetNonceLength(securityPolicyUri));
    }

    public static bool ValidateNonce(
      byte[] nonce,
      MessageSecurityMode securityMode,
      uint minNonceLength)
    {
      if (securityMode == MessageSecurityMode.None)
        return true;
      if (nonce == null || (long) nonce.Length < (long) minNonceLength)
        return false;
      for (int index = 0; index < nonce.Length; ++index)
      {
        if (nonce[index] != (byte) 0)
          return true;
      }
      return false;
    }
  }
}
