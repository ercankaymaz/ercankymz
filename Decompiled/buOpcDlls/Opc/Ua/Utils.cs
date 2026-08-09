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
using Microsoft.Extensions.Logging;
using Opc.Ua.Security.Certificates;

namespace Opc.Ua;

[ComVisible(true)]
public static class Utils
{
	public enum TraceOutput
	{
		Off,
		FileOnly,
		DebugAndFile
	}

	public static class TraceMasks
	{
		public const int None = 0;

		public const int Error = 1;

		public const int Information = 2;

		public const int StackTrace = 4;

		public const int Service = 8;

		public const int ServiceDetail = 16;

		public const int Operation = 32;

		public const int OperationDetail = 64;

		public const int StartStop = 128;

		public const int ExternalSystem = 256;

		public const int Security = 512;

		public const int All = 1023;
	}

	public static class Nonce
	{
		private static readonly System.Security.Cryptography.RandomNumberGenerator m_rng = System.Security.Cryptography.RandomNumberGenerator.Create();

		public static byte[] CreateNonce(uint length)
		{
			byte[] array = new byte[length];
			m_rng.GetBytes(array);
			return array;
		}

		public static uint GetNonceLength(string securityPolicyUri)
		{
			switch (securityPolicyUri)
			{
			case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
				return 16u;
			case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
			case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
			case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
			case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
				return 32u;
			default:
				return 0u;
			}
		}

		public static bool ValidateNonce(byte[] nonce, MessageSecurityMode securityMode, string securityPolicyUri)
		{
			return ValidateNonce(nonce, securityMode, GetNonceLength(securityPolicyUri));
		}

		public static bool ValidateNonce(byte[] nonce, MessageSecurityMode securityMode, uint minNonceLength)
		{
			if (securityMode == MessageSecurityMode.None)
			{
				return true;
			}
			if (nonce == null || nonce.Length < minNonceLength)
			{
				return false;
			}
			for (int i = 0; i < nonce.Length; i++)
			{
				if (nonce[i] != 0)
				{
					return true;
				}
			}
			return false;
		}
	}

	public const string UriSchemeHttp = "http";

	public const string UriSchemeHttps = "https";

	public const string UriSchemeOpcHttps = "opc.https";

	public const string UriSchemeOpcTcp = "opc.tcp";

	public const string UriSchemeOpcWss = "opc.wss";

	public const string UriSchemeOpcUdp = "opc.udp";

	public const string UriSchemeMqtt = "mqtt";

	public const string UriSchemeMqtts = "mqtts";

	public static readonly string[] DefaultUriSchemes = new string[4] { "opc.tcp", "opc.https", "https", "opc.wss" };

	public const int UaTcpDefaultPort = 4840;

	public const int UaWebSocketsDefaultPort = 4843;

	public const int MqttDefaultPort = 1883;

	public static readonly string[] DiscoveryUrls = new string[4] { "opc.tcp://{0}:4840", "https://{0}:4843", "http://{0}:52601/UADiscovery", "http://{0}/UADiscovery/Default.svc" };

	public const string DefaultStoreType = "Directory";

	public static readonly string DefaultStorePath = Path.Combine("%CommonApplicationData%", "OPC Foundation", "pki", "own");

	public static readonly string DefaultLocalFolder = Directory.GetCurrentDirectory();

	public static readonly string DefaultOpcUaCoreAssemblyFullName = typeof(Utils).Assembly.GetName().FullName;

	public static readonly string DefaultOpcUaCoreAssemblyName = typeof(Utils).Assembly.GetName().Name;

	public static readonly ReadOnlyDictionary<string, string> DefaultBindings = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>
	{
		{ "https", "Opc.Ua.Bindings.Https" },
		{ "opc.https", "Opc.Ua.Bindings.Https" }
	});

	private static int s_traceOutput = 1;

	private static int s_traceMasks = 0;

	private static string s_traceFileName = string.Empty;

	private static readonly object s_traceFileLock = new object();

	private static readonly DateTime s_TimeBase = new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	private static readonly Lazy<bool> s_isRunningOnMonoValue = new Lazy<bool>(() => Type.GetType("Mono.Runtime") != null);

	internal static OpcUaCoreEventSource EventLog { get; } = new OpcUaCoreEventSource();

	public static ILogger Logger { get; private set; } = new TraceEventLogger();

	public static bool UseTraceEvent { get; set; } = true;

	public static int TraceMask => s_traceMasks;

	public static Tracing Tracing => Tracing.Instance;

	public static DateTime TimeBase => s_TimeBase;

	public static void SetLogLevel(LogLevel logLevel)
	{
		if (Logger is TraceEventLogger traceEventLogger)
		{
			traceEventLogger.LogLevel = logLevel;
		}
	}

	public static void SetLogger(ILogger logger)
	{
		Logger = logger;
		UseTraceEvent = false;
	}

	public static void LogCertificate(string message, X509Certificate2 certificate, params object[] args)
	{
		LogCertificate(LogLevel.Information, 0, message, certificate, args);
	}

	public static void LogCertificate(LogLevel logLevel, string message, X509Certificate2 certificate, params object[] args)
	{
		LogCertificate(logLevel, 0, message, certificate, args);
	}

	public static void LogCertificate(EventId eventId, string message, X509Certificate2 certificate, params object[] args)
	{
		LogCertificate(LogLevel.Information, eventId, message, certificate, args);
	}

	public static void LogCertificate(LogLevel logLevel, EventId eventId, string message, X509Certificate2 certificate, params object[] args)
	{
		if (!Logger.IsEnabled(logLevel))
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder().Append(message);
		if (certificate != null)
		{
			int num = args.Length;
			stringBuilder.Append(" [{");
			stringBuilder.Append(num);
			stringBuilder.Append("}] [{");
			stringBuilder.Append(num + 1);
			stringBuilder.Append("}]");
			object[] array = new object[num + 2];
			for (int i = 0; i < num; i++)
			{
				array[i] = args[i];
			}
			array[num] = certificate.Subject;
			array[num + 1] = certificate.Thumbprint;
			Log(logLevel, eventId, stringBuilder.ToString(), array);
		}
		else
		{
			stringBuilder.Append(" (none)");
			Log(logLevel, eventId, stringBuilder.ToString(), args);
		}
	}

	[Conditional("DEBUG")]
	public static void LogDebug(EventId eventId, Exception exception, string message, params object[] args)
	{
		Log(LogLevel.Debug, eventId, exception, message, args);
	}

	[Conditional("DEBUG")]
	public static void LogDebug(EventId eventId, string message, params object[] args)
	{
		Log(LogLevel.Debug, eventId, message, args);
	}

	[Conditional("DEBUG")]
	public static void LogDebug(Exception exception, string message, params object[] args)
	{
		Log(LogLevel.Debug, exception, message, args);
	}

	[Conditional("DEBUG")]
	public static void LogDebug(string message, params object[] args)
	{
		Log(LogLevel.Debug, message, args);
	}

	public static void LogTrace(EventId eventId, Exception exception, string message, params object[] args)
	{
		if (EventLog.IsEnabled())
		{
			EventLog.Log(LogLevel.Trace, eventId, exception, message, args);
		}
		else if (Logger.IsEnabled(LogLevel.Trace))
		{
			Log(LogLevel.Trace, eventId, exception, message, args);
		}
	}

	public static void LogTrace(EventId eventId, string message, params object[] args)
	{
		if (EventLog.IsEnabled())
		{
			EventLog.Log(LogLevel.Trace, eventId, message, args);
		}
		else if (Logger.IsEnabled(LogLevel.Trace))
		{
			Log(LogLevel.Trace, eventId, message, args);
		}
	}

	public static void LogTrace(Exception exception, string message, params object[] args)
	{
		if (EventLog.IsEnabled())
		{
			EventLog.Log(LogLevel.Trace, 0, exception, message, args);
		}
		else if (Logger.IsEnabled(LogLevel.Trace))
		{
			Log(LogLevel.Trace, 0, exception, message, args);
		}
	}

	public static void LogTrace(string message, params object[] args)
	{
		if (EventLog.IsEnabled())
		{
			EventLog.Log(LogLevel.Trace, 0, message, args);
		}
		else if (Logger.IsEnabled(LogLevel.Trace))
		{
			Log(LogLevel.Trace, 0, message, args);
		}
	}

	public static void LogInfo(EventId eventId, Exception exception, string message, params object[] args)
	{
		Log(LogLevel.Information, eventId, exception, message, args);
	}

	public static void LogInfo(EventId eventId, string message, params object[] args)
	{
		Log(LogLevel.Information, eventId, message, args);
	}

	public static void LogInfo(Exception exception, string message, params object[] args)
	{
		Log(LogLevel.Information, exception, message, args);
	}

	public static void LogInfo(string message, params object[] args)
	{
		Log(LogLevel.Information, message, args);
	}

	public static void LogWarning(EventId eventId, Exception exception, string message, params object[] args)
	{
		Log(LogLevel.Warning, eventId, exception, message, args);
	}

	public static void LogWarning(EventId eventId, string message, params object[] args)
	{
		Log(LogLevel.Warning, eventId, message, args);
	}

	public static void LogWarning(Exception exception, string message, params object[] args)
	{
		Log(LogLevel.Warning, exception, message, args);
	}

	public static void LogWarning(string message, params object[] args)
	{
		Log(LogLevel.Warning, message, args);
	}

	public static void LogError(EventId eventId, Exception exception, string message, params object[] args)
	{
		Log(LogLevel.Error, eventId, exception, message, args);
	}

	public static void LogError(EventId eventId, string message, params object[] args)
	{
		Log(LogLevel.Error, eventId, message, args);
	}

	public static void LogError(Exception exception, string message, params object[] args)
	{
		Log(LogLevel.Error, exception, message, args);
	}

	public static void LogError(string message, params object[] args)
	{
		Log(LogLevel.Error, message, args);
	}

	public static void LogCritical(EventId eventId, Exception exception, string message, params object[] args)
	{
		Log(LogLevel.Critical, eventId, exception, message, args);
	}

	public static void LogCritical(EventId eventId, string message, params object[] args)
	{
		Log(LogLevel.Critical, eventId, message, args);
	}

	public static void LogCritical(Exception exception, string message, params object[] args)
	{
		Log(LogLevel.Critical, exception, message, args);
	}

	public static void LogCritical(string message, params object[] args)
	{
		Log(LogLevel.Critical, message, args);
	}

	public static void Log(LogLevel logLevel, string message, params object[] args)
	{
		Log(logLevel, 0, null, message, args);
	}

	public static void Log(LogLevel logLevel, EventId eventId, string message, params object[] args)
	{
		if (EventLog.IsEnabled())
		{
			EventLog.Log(logLevel, eventId, null, message, args);
		}
		else
		{
			if (!Logger.IsEnabled(logLevel))
			{
				return;
			}
			if (UseTraceEvent && Tracing.IsEnabled())
			{
				int traceMask = GetTraceMask(eventId, logLevel);
				Tracing.Instance.RaiseTraceEvent(new TraceEventArgs(traceMask, message, string.Empty, null, args));
				if ((s_traceMasks & traceMask) == 0)
				{
					return;
				}
			}
			Logger.Log(logLevel, eventId, null, message, args);
		}
	}

	public static void Log(LogLevel logLevel, Exception exception, string message, params object[] args)
	{
		Log(logLevel, 0, exception, message, args);
	}

	public static void Log(LogLevel logLevel, EventId eventId, Exception exception, string message, params object[] args)
	{
		if (EventLog.IsEnabled())
		{
			EventLog.Log(logLevel, eventId, exception, message, args);
		}
		else
		{
			if (!Logger.IsEnabled(logLevel))
			{
				return;
			}
			if (UseTraceEvent && Tracing.IsEnabled())
			{
				int traceMask = GetTraceMask(eventId, logLevel);
				Tracing.Instance.RaiseTraceEvent(new TraceEventArgs(traceMask, message, string.Empty, exception, args));
				if ((s_traceMasks & traceMask) == 0)
				{
					return;
				}
			}
			Logger.Log(logLevel, eventId, exception, message, args);
		}
	}

	public static IDisposable BeginScope(string messageFormat, params object[] args)
	{
		if (EventLog.IsEnabled())
		{
			return EventLog.BeginScope(messageFormat, args);
		}
		return Logger.BeginScope(messageFormat, args);
	}

	internal static int GetTraceMask(EventId eventId, LogLevel logLevel)
	{
		int num = eventId.Id & 0x3FF;
		if (num == 0)
		{
			switch (logLevel)
			{
			case LogLevel.Warning:
			case LogLevel.Error:
			case LogLevel.Critical:
				num = 1;
				break;
			case LogLevel.Information:
				num = 2;
				break;
			case LogLevel.Trace:
				num = 32;
				break;
			}
		}
		return num;
	}

	public static bool IsUriHttpsScheme(string url)
	{
		if (!url.StartsWith("https", StringComparison.Ordinal))
		{
			return url.StartsWith("opc.https", StringComparison.Ordinal);
		}
		return true;
	}

	public static void SetTraceOutput(TraceOutput output)
	{
		lock (s_traceFileLock)
		{
			s_traceOutput = (int)output;
		}
	}

	public static void SetTraceMask(int masks)
	{
		s_traceMasks = masks;
	}

	private static void TraceWriteLine(string message, params object[] args)
	{
		if (string.IsNullOrEmpty(message))
		{
			return;
		}
		string output = message;
		if (args != null && args.Length != 0)
		{
			try
			{
				output = string.Format(CultureInfo.InvariantCulture, message, args);
			}
			catch (Exception)
			{
				output = message;
			}
		}
		TraceWriteLine(output);
	}

	private static void TraceWriteLine(string output)
	{
		lock (s_traceFileLock)
		{
			_ = s_traceOutput;
			_ = 2;
			string text = s_traceFileName;
			if (s_traceOutput == 0 || string.IsNullOrEmpty(text))
			{
				return;
			}
			try
			{
				FileInfo fileInfo = new FileInfo(text);
				bool flag = false;
				if (fileInfo.Exists && fileInfo.Length > 10000000)
				{
					fileInfo.Delete();
					flag = true;
				}
				using StreamWriter streamWriter = new StreamWriter(File.Open(fileInfo.FullName, FileMode.Append, FileAccess.Write, FileShare.Read));
				if (flag)
				{
					streamWriter.WriteLine("WARNING - LOG FILE TRUNCATED.");
				}
				streamWriter.WriteLine(output);
				streamWriter.Flush();
			}
			catch (Exception)
			{
			}
		}
	}

	public static void SetTraceLog(string filePath, bool deleteExisting)
	{
		lock (s_traceFileLock)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				s_traceFileName = null;
				return;
			}
			s_traceFileName = GetAbsoluteFilePath(filePath, checkCurrentDirectory: true, throwOnError: false, createAlways: true, writable: true);
			if (s_traceOutput == 0)
			{
				s_traceOutput = 1;
			}
			try
			{
				FileInfo fileInfo = new FileInfo(s_traceFileName);
				if (deleteExisting && fileInfo.Exists)
				{
					fileInfo.Delete();
				}
				TraceWriteLine(string.Empty);
				TraceWriteLine("{1} Logging started at {0}", DateTime.Now, new string('*', 25));
			}
			catch (Exception ex)
			{
				TraceWriteLine(ex.Message);
			}
		}
	}

	public static void Trace(string message)
	{
		LogInfo(message);
	}

	public static void Trace(string format, params object[] args)
	{
		LogInfo(format, args);
	}

	[Conditional("DEBUG")]
	public static void TraceDebug(string format, params object[] args)
	{
	}

	public static void Trace(Exception e, string message)
	{
		LogError(e, message);
	}

	public static void Trace(Exception e, string format, params object[] args)
	{
		LogError(e, format, args);
	}

	internal static StringBuilder TraceExceptionMessage(Exception e, string format, params object[] args)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (args != null && args.Length != 0)
		{
			try
			{
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, format, args);
				stringBuilder.AppendLine();
			}
			catch (Exception)
			{
				stringBuilder.AppendLine(format);
			}
		}
		else
		{
			stringBuilder.AppendLine(format);
		}
		if (e != null)
		{
			if (e is ServiceResultException ex2)
			{
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, " {0} '{1}'", StatusCodes.GetBrowseName(ex2.StatusCode), ex2.Message);
			}
			else
			{
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, " {0} '{1}'", e.GetType().Name, e.Message);
			}
			stringBuilder.AppendLine();
			if ((s_traceMasks & 4) != 0)
			{
				stringBuilder.AppendLine();
				stringBuilder.AppendLine();
				string value = new string('=', 40);
				stringBuilder.AppendLine(value);
				stringBuilder.AppendLine(new ServiceResult(e).ToLongString());
				stringBuilder.AppendLine(value);
			}
		}
		return stringBuilder;
	}

	public static void Trace(Exception e, string format, bool handled, params object[] args)
	{
		StringBuilder stringBuilder = TraceExceptionMessage(e, format, args);
		Trace(e, 1, stringBuilder.ToString(), handled, null);
	}

	public static void Trace(int traceMask, string format, params object[] args)
	{
		if ((traceMask & 5) != 0)
		{
			LogError(traceMask, format, args);
		}
		else if ((traceMask & 0x282) != 0)
		{
			LogInfo(traceMask, format, args);
		}
		else
		{
			LogTrace(traceMask, format, args);
		}
	}

	public static void Trace(int traceMask, string format, bool handled, params object[] args)
	{
		Trace(null, traceMask, format, handled, args);
	}

	public static void Trace<TState>(TState state, Exception exception, int traceMask, Func<TState, Exception, string> formatter)
	{
		bool flag = Tracing.IsEnabled();
		bool flag2 = (s_traceMasks & traceMask) != 0;
		if (!flag2 && !flag)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		try
		{
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:d} {0:HH:mm:ss.fff} ", DateTime.UtcNow.ToLocalTime());
			stringBuilder.Append(formatter(state, exception));
			if (exception != null)
			{
				stringBuilder.Append(TraceExceptionMessage(exception, string.Empty, null));
			}
		}
		catch (Exception)
		{
			return;
		}
		string text = stringBuilder.ToString();
		if (flag)
		{
			Tracing.Instance.RaiseTraceEvent(new TraceEventArgs(traceMask, text, string.Empty, exception, Array.Empty<object>()));
		}
		if (flag2)
		{
			TraceWriteLine(text);
		}
	}

	public static void Trace(Exception e, int traceMask, string format, bool handled, params object[] args)
	{
		if (!handled)
		{
			Tracing.Instance.RaiseTraceEvent(new TraceEventArgs(traceMask, format, string.Empty, e, args));
		}
		if ((s_traceMasks & traceMask) == 0)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:d} {0:HH:mm:ss.fff} ", DateTime.UtcNow.ToLocalTime());
		if (args != null && args.Length != 0)
		{
			try
			{
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, format, args);
			}
			catch (Exception)
			{
				stringBuilder.Append(format);
			}
		}
		else
		{
			stringBuilder.Append(format);
		}
		TraceWriteLine(stringBuilder.ToString());
	}

	public static bool IsPathRooted(string path)
	{
		if (!Path.IsPathRooted(path))
		{
			if (path.Length >= 2 && path[0] == '.')
			{
				return path[1] != '.';
			}
			return false;
		}
		return true;
	}

	private static string ReplaceSpecialFolderWithEnvVar(string input)
	{
		if (input == "CommonApplicationData")
		{
			return "ProgramData";
		}
		return input;
	}

	public static string ReplaceSpecialFolderNames(string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return null;
		}
		if (IsPathRooted(input))
		{
			return input;
		}
		if (input[0] != '%')
		{
			return input;
		}
		string text = null;
		string text2 = null;
		int num = input.IndexOf('%', 1);
		if (num == -1)
		{
			text = input.Substring(1);
			text2 = string.Empty;
		}
		else
		{
			text = input.Substring(1, num - 1);
			text2 = input.Substring(num + 1);
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (!Enum.TryParse<Environment.SpecialFolder>(text, out var result))
		{
			text = ReplaceSpecialFolderWithEnvVar(text);
			string environmentVariable = Environment.GetEnvironmentVariable(text);
			if (environmentVariable != null)
			{
				stringBuilder.Append(environmentVariable);
			}
			else if (text == "LocalFolder")
			{
				stringBuilder.Append(DefaultLocalFolder);
			}
		}
		else
		{
			stringBuilder.Append(Environment.GetFolderPath(result));
		}
		stringBuilder.Append(text2);
		return stringBuilder.ToString();
	}

	public static string FindInstalledFile(string fileName)
	{
		if (string.IsNullOrEmpty(fileName))
		{
			return null;
		}
		string text = null;
		for (DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory()); directoryInfo != null; directoryInfo = directoryInfo.Parent)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(directoryInfo.FullName);
			stringBuilder.Append(Path.DirectorySeparatorChar).Append("Bin").Append(Path.DirectorySeparatorChar);
			stringBuilder.Append(fileName);
			text = GetAbsoluteFilePath(stringBuilder.ToString(), checkCurrentDirectory: false, throwOnError: false, createAlways: false);
			if (text != null)
			{
				break;
			}
		}
		return text;
	}

	public static string GetAbsoluteFilePath(string filePath)
	{
		return GetAbsoluteFilePath(filePath, checkCurrentDirectory: false, throwOnError: true, createAlways: false);
	}

	public static string GetAbsoluteFilePath(string filePath, bool checkCurrentDirectory, bool throwOnError, bool createAlways, bool writable = false)
	{
		filePath = ReplaceSpecialFolderNames(filePath);
		if (!string.IsNullOrEmpty(filePath))
		{
			FileInfo fileInfo = new FileInfo(filePath);
			bool flag = IsPathRooted(filePath);
			if (flag)
			{
				if (fileInfo.Exists)
				{
					return filePath;
				}
				if (createAlways)
				{
					return CreateFile(fileInfo, filePath, throwOnError);
				}
			}
			if (!flag && checkCurrentDirectory)
			{
				FileInfo fileInfo2 = null;
				if (!writable)
				{
					fileInfo2 = new FileInfo(Format("{0}{1}{2}", Directory.GetCurrentDirectory(), Path.DirectorySeparatorChar, filePath));
					if (!fileInfo2.Exists)
					{
						FileInfo fileInfo3 = new FileInfo(Format("{0}{1}{2}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Path.DirectorySeparatorChar, filePath));
						if (fileInfo3.Exists)
						{
							fileInfo2 = fileInfo3;
						}
					}
				}
				else
				{
					fileInfo2 = new FileInfo(Format("{0}{1}{2}", Path.GetTempPath(), Path.DirectorySeparatorChar, filePath));
				}
				if (fileInfo2.Exists)
				{
					return fileInfo2.FullName;
				}
				if (fileInfo.Exists && !writable)
				{
					return fileInfo.FullName;
				}
				if (createAlways && writable)
				{
					return CreateFile(fileInfo2, fileInfo2.FullName, throwOnError);
				}
			}
		}
		if (throwOnError)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("File does not exist: {0}");
			stringBuilder.AppendLine("Current directory is: {1}");
			throw ServiceResultException.Create(2156462080u, stringBuilder.ToString(), filePath, Directory.GetCurrentDirectory());
		}
		return null;
	}

	private static string CreateFile(FileInfo file, string filePath, bool throwOnError)
	{
		try
		{
			if (!file.Directory.Exists)
			{
				Directory.CreateDirectory(file.DirectoryName);
			}
			using (file.Open(FileMode.CreateNew, FileAccess.ReadWrite))
			{
				return filePath;
			}
		}
		catch (Exception exception)
		{
			LogError(exception, "Could not create file: {0}", filePath);
			if (throwOnError)
			{
				throw;
			}
			return filePath;
		}
	}

	public static string GetAbsoluteDirectoryPath(string dirPath, bool checkCurrentDirectory, bool throwOnError)
	{
		return GetAbsoluteDirectoryPath(dirPath, checkCurrentDirectory, throwOnError, createAlways: false);
	}

	public static string GetAbsoluteDirectoryPath(string dirPath, bool checkCurrentDirectory, bool throwOnError, bool createAlways)
	{
		string text = dirPath;
		dirPath = ReplaceSpecialFolderNames(dirPath);
		if (!string.IsNullOrEmpty(dirPath))
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
			bool flag = IsPathRooted(dirPath);
			if (flag)
			{
				if (directoryInfo.Exists)
				{
					return dirPath;
				}
				if (createAlways && !directoryInfo.Exists)
				{
					directoryInfo = Directory.CreateDirectory(dirPath);
					return directoryInfo.FullName;
				}
			}
			if (!flag)
			{
				if (checkCurrentDirectory && !directoryInfo.Exists)
				{
					directoryInfo = new DirectoryInfo(Format("{0}{1}{2}", Directory.GetCurrentDirectory(), Path.DirectorySeparatorChar, dirPath));
					if (!directoryInfo.Exists)
					{
						DirectoryInfo directoryInfo2 = new DirectoryInfo(Format("{0}{1}{2}", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Path.DirectorySeparatorChar, dirPath));
						if (directoryInfo2.Exists)
						{
							directoryInfo = directoryInfo2;
						}
					}
				}
				if (directoryInfo.Exists)
				{
					return directoryInfo.FullName;
				}
				if (createAlways)
				{
					directoryInfo = Directory.CreateDirectory(directoryInfo.FullName);
					return directoryInfo.FullName;
				}
			}
		}
		if (throwOnError)
		{
			throw ServiceResultException.Create(2156462080u, "Directory does not exist: {0}\r\nCurrent directory is: {1}", text, Directory.GetCurrentDirectory());
		}
		return null;
	}

	public static string GetFilePathDisplayName(string filePath, int maxLength)
	{
		if (filePath == null || maxLength <= 0 || filePath.Length < maxLength)
		{
			return filePath;
		}
		int num = filePath.IndexOf(Path.DirectorySeparatorChar);
		if (num == -1)
		{
			return Format("{0}...", filePath.Substring(0, maxLength));
		}
		int num2 = filePath.LastIndexOf(Path.DirectorySeparatorChar);
		while (num2 > num && filePath.Length - num2 < maxLength)
		{
			num2 = filePath.LastIndexOf(Path.DirectorySeparatorChar, num2 - 1);
			if (filePath.Length - num2 > maxLength)
			{
				num2 = filePath.IndexOf(Path.DirectorySeparatorChar, num2 + 1);
				break;
			}
		}
		return Format("{0}...{1}", filePath.Substring(0, num + 1), filePath.Substring(num2));
	}

	public static void SilentDispose(object objectToDispose)
	{
		SilentDispose(objectToDispose as IDisposable);
	}

	public static void SilentDispose(IDisposable disposable)
	{
		try
		{
			disposable?.Dispose();
		}
		catch (Exception)
		{
		}
	}

	public static DateTime ToOpcUaUniversalTime(DateTime value)
	{
		if (value <= DateTime.MinValue)
		{
			return DateTime.MinValue;
		}
		if (value >= DateTime.MaxValue)
		{
			return DateTime.MaxValue;
		}
		if (value.Kind != DateTimeKind.Utc)
		{
			return value.ToUniversalTime();
		}
		return value;
	}

	public static DateTime GetDeadline(TimeSpan timeSpan)
	{
		DateTime utcNow = DateTime.UtcNow;
		if (DateTime.MaxValue.Ticks - utcNow.Ticks < timeSpan.Ticks)
		{
			return DateTime.MaxValue;
		}
		return utcNow + timeSpan;
	}

	public static int GetTimeout(TimeSpan timeSpan)
	{
		if (timeSpan.TotalMilliseconds > 2147483647.0)
		{
			return -1;
		}
		if (timeSpan.TotalMilliseconds < 0.0)
		{
			return 0;
		}
		return (int)timeSpan.TotalMilliseconds;
	}

	public static Task<IPAddress[]> GetHostAddressesAsync(string hostNameOrAddress)
	{
		return Dns.GetHostAddressesAsync(hostNameOrAddress);
	}

	public static IPAddress[] GetHostAddresses(string hostNameOrAddress)
	{
		return Dns.GetHostAddresses(hostNameOrAddress);
	}

	public static string GetHostName()
	{
		return Dns.GetHostName().Split('.')[0].ToLowerInvariant();
	}

	public static string GetFullQualifiedDomainName()
	{
		string text = null;
		try
		{
			text = Dns.GetHostEntry("localhost").HostName;
		}
		catch
		{
		}
		if (string.IsNullOrEmpty(text))
		{
			return Dns.GetHostName();
		}
		return text;
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
		{
			return uri;
		}
		if (!string.IsNullOrEmpty(hostname) && hostname.Contains(':'))
		{
			hostname = "[" + hostname + "]";
		}
		string text = "localhost";
		int num = uri.IndexOf(text, StringComparison.OrdinalIgnoreCase);
		if (num == -1)
		{
			return uri;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(uri.Substring(0, num)).Append(hostname ?? GetHostName()).Append(uri.Substring(num + text.Length));
		return stringBuilder.ToString();
	}

	public static string ReplaceDCLocalhost(string subjectName, string hostname = null)
	{
		if (string.IsNullOrEmpty(subjectName))
		{
			return subjectName;
		}
		if (!string.IsNullOrEmpty(hostname) && hostname.Contains(':'))
		{
			hostname = "[" + hostname + "]";
		}
		string text = "DC=localhost";
		int num = subjectName.IndexOf(text, StringComparison.OrdinalIgnoreCase);
		if (num == -1)
		{
			return subjectName;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(subjectName.Substring(0, num + 3)).Append(hostname ?? GetHostName()).Append(subjectName.Substring(num + text.Length));
		return stringBuilder.ToString();
	}

	public static Uri ParseUri(string uri)
	{
		try
		{
			if (string.IsNullOrEmpty(uri))
			{
				return null;
			}
			return new Uri(uri);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static bool AreDomainsEqual(Uri url1, Uri url2)
	{
		if (url1 == null || url2 == null)
		{
			return false;
		}
		try
		{
			string text = url1.DnsSafeHost;
			string text2 = url2.DnsSafeHost;
			if (text == "localhost")
			{
				text = GetHostName();
			}
			if (text2 == "localhost")
			{
				text2 = GetHostName();
			}
			if (AreDomainsEqual(text, text2))
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static bool AreDomainsEqual(string domain1, string domain2)
	{
		if (string.IsNullOrEmpty(domain1) || string.IsNullOrEmpty(domain2))
		{
			return false;
		}
		if (string.Equals(domain1, domain2, StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		return false;
	}

	public static string UpdateInstanceUri(string instanceUri)
	{
		if (string.IsNullOrEmpty(instanceUri))
		{
			return new UriBuilder
			{
				Scheme = "https",
				Host = GetHostName(),
				Port = -1,
				Path = Guid.NewGuid().ToString()
			}.Uri.ToString();
		}
		if (!instanceUri.StartsWith("https", StringComparison.Ordinal))
		{
			return new UriBuilder
			{
				Scheme = "https",
				Host = GetHostName(),
				Port = -1,
				Path = Uri.EscapeDataString(instanceUri)
			}.Uri.ToString();
		}
		Uri uri = ParseUri(instanceUri);
		if (uri != null && uri.DnsSafeHost == "localhost")
		{
			return new UriBuilder(uri)
			{
				Host = GetHostName()
			}.Uri.ToString();
		}
		return instanceUri;
	}

	public static uint LowerLimitIdentifier(ref long identifier, uint lowerLimit)
	{
		long num;
		long num2;
		do
		{
			num = Interlocked.Read(ref identifier);
			num2 = num;
			if (num < lowerLimit)
			{
				num2 = Interlocked.CompareExchange(ref identifier, lowerLimit, num);
			}
		}
		while (num2 != num);
		return (uint)Interlocked.Read(ref identifier);
	}

	public static uint IncrementIdentifier(ref long identifier)
	{
		Interlocked.CompareExchange(ref identifier, 0L, 4294967295L);
		return (uint)Interlocked.Increment(ref identifier);
	}

	public static int IncrementIdentifier(ref int identifier)
	{
		Interlocked.CompareExchange(ref identifier, 0, int.MaxValue);
		return Interlocked.Increment(ref identifier);
	}

	public static int ToInt32(uint identifier)
	{
		if (identifier <= int.MaxValue)
		{
			return (int)identifier;
		}
		return -(int)(4294967295L - (long)identifier + 1);
	}

	public static uint ToUInt32(int identifier)
	{
		if (identifier >= 0)
		{
			return (uint)identifier;
		}
		return (uint)(4294967296L + identifier);
	}

	public static Array FlattenArray(Array array)
	{
		Array array2 = Array.CreateInstance(array.GetType().GetElementType(), array.Length);
		int[] array3 = new int[array.Rank];
		int[] array4 = new int[array.Rank];
		for (int num = array.Rank - 1; num >= 0; num--)
		{
			array4[num] = array.GetLength(array.Rank - num - 1);
		}
		for (int i = 0; i < array.Length; i++)
		{
			array3[array.Rank - 1] = i % array4[0];
			for (int j = 1; j < array.Rank; j++)
			{
				int num2 = 1;
				for (int k = 0; k < j; k++)
				{
					num2 *= array4[k];
				}
				array3[array.Rank - j - 1] = i / num2 % array4[j];
			}
			array2.SetValue(array.GetValue(array3), i);
		}
		return array2;
	}

	public static string ToHexString(byte[] buffer, bool invertEndian = false)
	{
		if (buffer == null || buffer.Length == 0)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(buffer.Length * 2);
		if (invertEndian)
		{
			for (int num = buffer.Length - 1; num >= 0; num--)
			{
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", buffer[num]);
			}
		}
		else
		{
			for (int i = 0; i < buffer.Length; i++)
			{
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", buffer[i]);
			}
		}
		return stringBuilder.ToString();
	}

	public static byte[] FromHexString(string buffer)
	{
		if (buffer == null)
		{
			return null;
		}
		if (buffer.Length == 0)
		{
			return Array.Empty<byte>();
		}
		buffer.ToUpperInvariant();
		byte[] array = new byte[buffer.Length / 2 + buffer.Length % 2];
		for (int i = 0; i < array.Length * 2; i += 2)
		{
			int num = "0123456789ABCDEF".IndexOf(buffer[i]);
			if (num == -1)
			{
				break;
			}
			byte b = (byte)num;
			b <<= 4;
			if (i < buffer.Length - 1)
			{
				num = "0123456789ABCDEF".IndexOf(buffer[i + 1]);
				if (num == -1)
				{
					break;
				}
				b += (byte)num;
			}
			array[i / 2] = b;
		}
		return array;
	}

	public static string ToString(object source)
	{
		if (source != null)
		{
			return string.Format(CultureInfo.InvariantCulture, "{0}", source);
		}
		return string.Empty;
	}

	public static string Format(string text, params object[] args)
	{
		return string.Format(CultureInfo.InvariantCulture, text, args);
	}

	public static bool IsValidLocaleId(string localeId)
	{
		if (string.IsNullOrEmpty(localeId))
		{
			return false;
		}
		try
		{
			if (new CultureInfo(localeId) != null)
			{
				return true;
			}
		}
		catch (Exception)
		{
		}
		return false;
	}

	public static string GetLanguageId(string localeId)
	{
		if (localeId == null)
		{
			return string.Empty;
		}
		int num = localeId.IndexOf('-');
		if (num != -1)
		{
			return localeId.Substring(0, num);
		}
		return localeId;
	}

	public static LocalizedText SelectLocalizedText(IList<string> localeIds, IList<LocalizedText> names, LocalizedText defaultName)
	{
		if (localeIds == null || localeIds.Count == 0)
		{
			return defaultName;
		}
		if (names == null || names.Count == 0)
		{
			return defaultName;
		}
		for (int i = 0; i < localeIds.Count; i++)
		{
			for (int j = 0; j < names.Count; j++)
			{
				if (!LocalizedText.IsNullOrEmpty(names[j]) && string.Equals(names[j].Locale, localeIds[i], StringComparison.OrdinalIgnoreCase))
				{
					return names[j];
				}
			}
		}
		for (int k = 0; k < localeIds.Count; k++)
		{
			string languageId = GetLanguageId(localeIds[k]);
			for (int l = 0; l < names.Count; l++)
			{
				if (!LocalizedText.IsNullOrEmpty(names[l]))
				{
					string languageId2 = GetLanguageId(names[l].Locale);
					if (string.Equals(languageId, languageId2, StringComparison.OrdinalIgnoreCase))
					{
						return names[l];
					}
				}
			}
		}
		return defaultName;
	}

	public static object Clone(object value)
	{
		if (value == null)
		{
			return null;
		}
		Type type = value.GetType();
		if (type.GetTypeInfo().IsValueType)
		{
			return value;
		}
		if (type == typeof(string))
		{
			return value;
		}
		if (value is Array array)
		{
			if (array.Rank == 1)
			{
				Array array2 = Array.CreateInstance(type.GetElementType(), array.Length);
				for (int i = 0; i < array.Length; i++)
				{
					array2.SetValue(Clone(array.GetValue(i)), i);
				}
				return array2;
			}
			int[] array3 = new int[array.Rank];
			int[] array4 = new int[array.Rank];
			for (int j = 0; j < array.Rank; j++)
			{
				array3[j] = array.GetLength(j);
				array4[j] = 0;
			}
			Array array5 = Array.CreateInstance(type.GetElementType(), array3);
			for (int k = 0; k < array.Length; k++)
			{
				array5.SetValue(Clone(array.GetValue(array4)), array4);
				for (int l = 0; l < array.Rank; l++)
				{
					array4[l]++;
					if (array4[l] < array3[l])
					{
						break;
					}
					array4[l] = 0;
				}
			}
			return array5;
		}
		if (value is XmlNode xmlNode)
		{
			return xmlNode.CloneNode(deep: true);
		}
		if (value is ICloneable cloneable)
		{
			return cloneable.Clone();
		}
		MethodInfo method = type.GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.Public);
		if (method != null)
		{
			object obj = method.Invoke(value, null);
			if (obj != null)
			{
				LogTrace("MemberwiseClone without ICloneable in class '{0}'", type.FullName);
				return obj;
			}
		}
		MethodInfo method2 = type.GetMethod("Clone", BindingFlags.Instance | BindingFlags.Public);
		if (method2 != null)
		{
			object obj2 = method2.Invoke(value, null);
			if (obj2 != null)
			{
				LogTrace("Clone without ICloneable in class '{0}'", type.FullName);
				return obj2;
			}
		}
		throw new NotSupportedException(Format("Don't know how to clone objects of type '{0}'", type.FullName));
	}

	public static bool IsEqualUserIdentity(UserIdentityToken identity1, UserIdentityToken identity2)
	{
		if (identity1 == identity2)
		{
			return true;
		}
		if (identity1 == null || identity2 == null)
		{
			return false;
		}
		if (identity1 is AnonymousIdentityToken && identity2 is AnonymousIdentityToken)
		{
			return true;
		}
		if (identity1 is UserNameIdentityToken userNameIdentityToken && identity2 is UserNameIdentityToken userNameIdentityToken2)
		{
			return string.Equals(userNameIdentityToken.UserName, userNameIdentityToken2.UserName, StringComparison.Ordinal);
		}
		if (identity1 is X509IdentityToken x509IdentityToken && identity2 is X509IdentityToken x509IdentityToken2)
		{
			return IsEqual(x509IdentityToken.CertificateData, x509IdentityToken2.CertificateData);
		}
		if (identity1 is IssuedIdentityToken issuedIdentityToken && identity2 is IssuedIdentityToken issuedIdentityToken2)
		{
			return IsEqual(issuedIdentityToken.DecryptedTokenData, issuedIdentityToken2.DecryptedTokenData);
		}
		return false;
	}

	public static bool IsEqual(DateTime time1, DateTime time2)
	{
		DateTime dateTime = ToOpcUaUniversalTime(time1);
		DateTime dateTime2 = ToOpcUaUniversalTime(time2);
		if (dateTime <= TimeBase && dateTime2 <= TimeBase)
		{
			return true;
		}
		if (dateTime >= DateTime.MaxValue && dateTime2 >= DateTime.MaxValue)
		{
			return true;
		}
		return dateTime.CompareTo(dateTime2) == 0;
	}

	public static bool IsEqual(object value1, object value2)
	{
		if (value1 == value2)
		{
			return true;
		}
		if (value1 == null)
		{
			return value2?.Equals(value1) ?? true;
		}
		if (value2 == null)
		{
			return value1.Equals(value2);
		}
		if (value1.GetType() != value2.GetType())
		{
			return value1.Equals(value2);
		}
		if (value1 is DateTime time)
		{
			return IsEqual(time, (DateTime)value2);
		}
		if (value1 is IComparable comparable)
		{
			return comparable.CompareTo(value2) == 0;
		}
		if (value1 is IEncodeable encodeable)
		{
			if (!(value2 is IEncodeable encodeable2))
			{
				return false;
			}
			return encodeable.IsEqual(encodeable2);
		}
		if (value1 is XmlElement xmlElement)
		{
			if (!(value2 is XmlElement xmlElement2))
			{
				return false;
			}
			return xmlElement.OuterXml == xmlElement2.OuterXml;
		}
		if (value1 is Array array)
		{
			if (!(value2 is Array array2))
			{
				return false;
			}
			if (array.Length != array2.Length)
			{
				return false;
			}
			if (array.Rank != array2.Rank)
			{
				return false;
			}
			for (int i = 0; i < array.Rank; i++)
			{
				if (array.GetLowerBound(i) != array2.GetLowerBound(i) || array.GetUpperBound(i) != array2.GetUpperBound(i))
				{
					return false;
				}
			}
			IEnumerator enumerator = array.GetEnumerator();
			IEnumerator enumerator2 = array2.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator2.MoveNext();
				if (!IsEqual(enumerator.Current, enumerator2.Current))
				{
					return false;
				}
			}
			return true;
		}
		if (value1 is IEnumerable enumerable)
		{
			if (!(value2 is IEnumerable enumerable2))
			{
				return false;
			}
			IEnumerator enumerator3 = enumerable.GetEnumerator();
			IEnumerator enumerator4 = enumerable2.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				if (!enumerator4.MoveNext())
				{
					return false;
				}
				if (!IsEqual(enumerator3.Current, enumerator4.Current))
				{
					return false;
				}
			}
			if (enumerator4.MoveNext())
			{
				return false;
			}
			return true;
		}
		return value1.Equals(value2);
	}

	public static bool Match(string target, string pattern, bool caseSensitive)
	{
		if (string.IsNullOrEmpty(pattern))
		{
			return true;
		}
		if (string.IsNullOrEmpty(target))
		{
			return false;
		}
		if (caseSensitive)
		{
			if (target == pattern)
			{
				return true;
			}
		}
		else if (string.Equals(target, pattern, StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		int num = 0;
		int num2 = 0;
		while (num2 < target.Length && num < pattern.Length)
		{
			char c = ConvertCase(pattern[num++], caseSensitive);
			if (num > pattern.Length)
			{
				return num2 >= target.Length;
			}
			switch (c)
			{
			case '*':
				while (num2 < target.Length)
				{
					if (Match(target.Substring(num2++), pattern.Substring(num), caseSensitive))
					{
						return true;
					}
				}
				return Match(target, pattern.Substring(num), caseSensitive);
			case '?':
				if (num2 >= target.Length)
				{
					return false;
				}
				if (num >= pattern.Length && num2 < target.Length - 1)
				{
					return false;
				}
				num2++;
				break;
			case '[':
			{
				char c2 = ConvertCase(target[num2++], caseSensitive);
				if (num2 > target.Length)
				{
					return false;
				}
				char c3 = '\0';
				if (pattern[num] == '!')
				{
					num++;
					c = ConvertCase(pattern[num++], caseSensitive);
					while (num < pattern.Length && c != ']')
					{
						if (c == '-')
						{
							c = ConvertCase(pattern[num], caseSensitive);
							if (num > pattern.Length || c == ']')
							{
								return false;
							}
							if (c2 >= c3 && c2 <= c)
							{
								return false;
							}
						}
						c3 = c;
						if (c2 == c)
						{
							return false;
						}
						c = ConvertCase(pattern[num++], caseSensitive);
					}
					break;
				}
				c = ConvertCase(pattern[num++], caseSensitive);
				while (num < pattern.Length)
				{
					if (c == ']')
					{
						return false;
					}
					if (c == '-')
					{
						c = ConvertCase(pattern[num], caseSensitive);
						if (num > pattern.Length || c == ']')
						{
							return false;
						}
						if (c2 >= c3 && c2 <= c)
						{
							break;
						}
					}
					c3 = c;
					if (c2 == c)
					{
						break;
					}
					c = ConvertCase(pattern[num++], caseSensitive);
				}
				while (num < pattern.Length && c != ']')
				{
					c = pattern[num++];
				}
				break;
			}
			case '#':
			{
				char c2 = target[num2++];
				if (!char.IsDigit(c2))
				{
					return false;
				}
				break;
			}
			default:
			{
				char c2 = ConvertCase(target[num2++], caseSensitive);
				if (c2 != c)
				{
					return false;
				}
				if (num >= pattern.Length && num2 < target.Length - 1)
				{
					return false;
				}
				break;
			}
			}
		}
		if (num2 >= target.Length)
		{
			return num >= pattern.Length;
		}
		return true;
	}

	private static char ConvertCase(char c, bool caseSensitive)
	{
		if (!caseSensitive)
		{
			return char.ToUpperInvariant(c);
		}
		return c;
	}

	public static TimeZoneDataType GetTimeZoneInfo()
	{
		return new TimeZoneDataType
		{
			Offset = (short)TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).TotalMinutes,
			DaylightSavingInOffset = true
		};
	}

	public static T ParseExtension<T>(IList<XmlElement> extensions, XmlQualifiedName elementName)
	{
		if (extensions == null || extensions.Count == 0)
		{
			return default(T);
		}
		if (elementName == null)
		{
			XmlQualifiedName xmlName = EncodeableFactory.GetXmlName(typeof(T));
			if (xmlName == null)
			{
				throw new ArgumentException("Type does not seem to support DataContract serialization");
			}
			elementName = xmlName;
		}
		for (int i = 0; i < extensions.Count; i++)
		{
			XmlElement xmlElement = extensions[i];
			if (xmlElement.LocalName != elementName.Name || xmlElement.NamespaceURI != elementName.Namespace)
			{
				continue;
			}
			XmlReader xmlReader = XmlReader.Create(new StringReader(xmlElement.OuterXml), DefaultXmlReaderSettings());
			try
			{
				return (T)new DataContractSerializer(typeof(T)).ReadObject(xmlReader);
			}
			catch (Exception ex)
			{
				LogError("Exception parsing extension: " + ex.Message);
				throw;
			}
			finally
			{
				xmlReader.Dispose();
			}
		}
		return default(T);
	}

	public static void UpdateExtension<T>(ref XmlElementCollection extensions, XmlQualifiedName elementName, object value)
	{
		XmlDocument xmlDocument = new XmlDocument();
		StringBuilder stringBuilder = new StringBuilder();
		using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder))
		{
			if (value != null)
			{
				try
				{
					new DataContractSerializer(typeof(T)).WriteObject(xmlWriter, value);
				}
				finally
				{
					xmlWriter.Dispose();
				}
				xmlDocument.LoadInnerXml(stringBuilder.ToString());
			}
		}
		if (elementName == null)
		{
			XmlQualifiedName xmlName = EncodeableFactory.GetXmlName(typeof(T));
			if (xmlName == null)
			{
				throw new ArgumentException("Type does not seem to support DataContract serialization");
			}
			elementName = xmlName;
		}
		if (extensions != null)
		{
			for (int i = 0; i < extensions.Count; i++)
			{
				if (extensions[i] != null && extensions[i].LocalName == elementName.Name && extensions[i].NamespaceURI == elementName.Namespace)
				{
					if (value == null)
					{
						extensions.RemoveAt(i);
					}
					else
					{
						extensions[i] = xmlDocument.DocumentElement;
					}
					return;
				}
			}
		}
		if (value != null)
		{
			if (extensions == null)
			{
				extensions = new XmlElementCollection();
			}
			extensions.Add(xmlDocument.DocumentElement);
		}
	}

	public static string[] GetFieldNames(Type systemType)
	{
		FieldInfo[] fields = systemType.GetFields(BindingFlags.Static | BindingFlags.Public);
		int num = 0;
		string[] array = new string[fields.Length];
		FieldInfo[] array2 = fields;
		foreach (FieldInfo fieldInfo in array2)
		{
			array[num++] = fieldInfo.Name;
		}
		return array;
	}

	public static string GetDataMemberName(PropertyInfo property)
	{
		object[] array = property.GetCustomAttributes(typeof(DataMemberAttribute), inherit: true).ToArray();
		if (array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] is DataMemberAttribute dataMemberAttribute)
				{
					if (string.IsNullOrEmpty(dataMemberAttribute.Name))
					{
						return property.Name;
					}
					return dataMemberAttribute.Name;
				}
			}
		}
		return null;
	}

	public static uint GetIdentifier(string name, Type constants)
	{
		FieldInfo[] fields = constants.GetFields(BindingFlags.Static | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (fieldInfo.Name == name)
			{
				return (uint)fieldInfo.GetValue(constants);
			}
		}
		return 0u;
	}

	public static DateTime GetAssemblyTimestamp()
	{
		try
		{
			return File.GetLastWriteTimeUtc(typeof(Utils).GetTypeInfo().Assembly.Location);
		}
		catch
		{
		}
		return new DateTime(1970, 1, 1, 0, 0, 0);
	}

	public static string GetAssemblySoftwareVersion()
	{
		return typeof(Utils).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
	}

	public static string GetAssemblyBuildNumber()
	{
		return typeof(Utils).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
	}

	public static XmlReaderSettings DefaultXmlReaderSettings()
	{
		return new XmlReaderSettings
		{
			DtdProcessing = DtdProcessing.Prohibit,
			XmlResolver = null,
			ConformanceLevel = ConformanceLevel.Document
		};
	}

	public static XmlWriterSettings DefaultXmlWriterSettings()
	{
		return new XmlWriterSettings
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
		using StringReader input = new StringReader(xml);
		using XmlReader reader = XmlReader.Create(input, DefaultXmlReaderSettings());
		doc.XmlResolver = null;
		doc.Load(reader);
	}

	public static byte[] Append(params byte[][] arrays)
	{
		if (arrays == null)
		{
			return Array.Empty<byte>();
		}
		int num = 0;
		for (int i = 0; i < arrays.Length; i++)
		{
			if (arrays[i] != null)
			{
				num += arrays[i].Length;
			}
		}
		byte[] array = new byte[num];
		int num2 = 0;
		for (int j = 0; j < arrays.Length; j++)
		{
			if (arrays[j] != null)
			{
				Array.Copy(arrays[j], 0, array, num2, arrays[j].Length);
				num2 += arrays[j].Length;
			}
		}
		return array;
	}

	public static X509Certificate2 ParseCertificateBlob(byte[] certificateData)
	{
		bool flag = false;
		try
		{
			if (flag)
			{
				return CertificateFactory.Create(AsnUtils.ParseX509Blob(certificateData), useCache: true);
			}
			return CertificateFactory.Create(certificateData, useCache: true);
		}
		catch (Exception e)
		{
			throw new ServiceResultException(2148663296u, "Could not parse DER encoded form of a X509 certificate.", e);
		}
	}

	public static X509Certificate2Collection ParseCertificateChainBlob(byte[] certificateData)
	{
		X509Certificate2Collection x509Certificate2Collection = new X509Certificate2Collection();
		List<byte> list = new List<byte>(certificateData);
		bool flag = false;
		while (list.Count > 0)
		{
			X509Certificate2 x509Certificate;
			try
			{
				x509Certificate = ((!flag) ? CertificateFactory.Create(list.ToArray(), useCache: true) : CertificateFactory.Create(AsnUtils.ParseX509Blob(list.ToArray()), useCache: true));
			}
			catch (Exception e)
			{
				throw new ServiceResultException(2148663296u, "Could not parse DER encoded form of a X509 certificate.", e);
			}
			x509Certificate2Collection.Add(x509Certificate);
			list.RemoveRange(0, x509Certificate.RawData.Length);
		}
		return x509Certificate2Collection;
	}

	public static bool CompareNonce(byte[] a, byte[] b)
	{
		if (a == null || b == null)
		{
			return false;
		}
		if (a.Length != b.Length)
		{
			return false;
		}
		byte b2 = 0;
		for (int i = 0; i < a.Length; i++)
		{
			b2 |= (byte)(a[i] ^ b[i]);
		}
		return b2 == 0;
	}

	public static byte[] PSHA1(byte[] secret, string label, byte[] data, int offset, int length)
	{
		if (secret == null)
		{
			throw new ArgumentNullException("secret");
		}
		return PSHA(new HMACSHA1(secret), label, data, offset, length);
	}

	public static byte[] PSHA256(byte[] secret, string label, byte[] data, int offset, int length)
	{
		if (secret == null)
		{
			throw new ArgumentNullException("secret");
		}
		return PSHA(new HMACSHA256(secret), label, data, offset, length);
	}

	private static byte[] PSHA(HMAC hmac, string label, byte[] data, int offset, int length)
	{
		if (hmac == null)
		{
			throw new ArgumentNullException("hmac");
		}
		if (offset < 0)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		if (length < 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		byte[] array = null;
		if (!string.IsNullOrEmpty(label))
		{
			array = Encoding.UTF8.GetBytes(label);
		}
		if (data != null && data.Length != 0)
		{
			if (array != null)
			{
				byte[] array2 = new byte[array.Length + data.Length];
				array.CopyTo(array2, 0);
				data.CopyTo(array2, array.Length);
				array = array2;
			}
			else
			{
				array = data;
			}
		}
		if (array == null)
		{
			throw new ServiceResultException(2147549184u, "The HMAC algorithm requires a non-null seed.");
		}
		byte[] array3 = hmac.ComputeHash(array);
		byte[] array4 = new byte[hmac.HashSize / 8 + array.Length];
		Array.Copy(array3, array4, array3.Length);
		Array.Copy(array, 0, array4, array3.Length, array.Length);
		byte[] array5 = new byte[length];
		int num = 0;
		do
		{
			byte[] array6 = hmac.ComputeHash(array4);
			if (offset < array6.Length)
			{
				int num2 = offset;
				while (num < length && num2 < array6.Length)
				{
					array5[num++] = array6[num2];
					num2++;
				}
			}
			offset = ((offset > array6.Length) ? (offset - array6.Length) : 0);
			array3 = hmac.ComputeHash(array3);
			Array.Copy(array3, array4, array3.Length);
		}
		while (num < length);
		return array5;
	}

	public static bool FindStringIgnoreCase(IList<string> strings, string target)
	{
		if (strings == null || strings.Count == 0)
		{
			return false;
		}
		for (int i = 0; i < strings.Count; i++)
		{
			if (string.Equals(strings[i], target, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsRunningOnMono()
	{
		return s_isRunningOnMonoValue.Value;
	}
}
