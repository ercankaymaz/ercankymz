using System.Diagnostics;
using System.Globalization;
using System.ServiceModel;
using System.Text;
using System.Xml;

namespace System.Runtime.Diagnostics;

internal abstract class DiagnosticTraceBase
{
	protected const string DefaultTraceListenerName = "Default";

	protected const string TraceRecordVersion = "http://schemas.microsoft.com/2004/10/E2ETraceEvent/TraceRecord";

	protected static string AppDomainFriendlyName = string.Empty;

	private const ushort TracingEventLogCategory = 4;

	private string _eventSourceName;

	protected string EventSourceName
	{
		get
		{
			return _eventSourceName;
		}
		set
		{
			_eventSourceName = value;
		}
	}

	public bool TracingEnabled => false;

	protected static string ProcessName => null;

	protected static int ProcessId => -1;

	public static Guid ActivityId
	{
		get
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		set
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
	}

	protected void AddDomainEventHandlersForCleanup()
	{
	}

	private void ExitOrUnloadEventHandler(object sender, EventArgs e)
	{
	}

	protected static string CreateSourceString(object source)
	{
		if (source is ITraceSourceStringProvider traceSourceStringProvider)
		{
			return traceSourceStringProvider.GetSourceString();
		}
		return CreateDefaultSourceString(source);
	}

	internal static string CreateDefaultSourceString(object source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		return string.Format(CultureInfo.CurrentCulture, "{0}/{1}", source.GetType().ToString(), source.GetHashCode());
	}

	protected static void AddExceptionToTraceString(XmlWriter xml, Exception exception)
	{
		xml.WriteElementString("ExceptionType", XmlEncode(exception.GetType().AssemblyQualifiedName));
		xml.WriteElementString("Message", XmlEncode(exception.Message));
		xml.WriteElementString("StackTrace", XmlEncode(StackTraceString(exception)));
		xml.WriteElementString("ExceptionString", XmlEncode(exception.ToString()));
		if (exception.Data != null && exception.Data.Count > 0)
		{
			xml.WriteStartElement("DataItems");
			foreach (object key in exception.Data.Keys)
			{
				xml.WriteStartElement("Data");
				xml.WriteElementString("Key", XmlEncode(key.ToString()));
				xml.WriteElementString("Value", XmlEncode(exception.Data[key].ToString()));
				xml.WriteEndElement();
			}
			xml.WriteEndElement();
		}
		if (exception.InnerException != null)
		{
			xml.WriteStartElement("InnerException");
			AddExceptionToTraceString(xml, exception.InnerException);
			xml.WriteEndElement();
		}
	}

	public abstract bool IsEnabled();

	public DiagnosticTraceBase()
	{
	}

	public static string XmlEncode(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		int length = text.Length;
		StringBuilder stringBuilder = new StringBuilder(length + 8);
		for (int i = 0; i < length; i++)
		{
			char c = text[i];
			switch (c)
			{
			case '<':
				stringBuilder.Append("&lt;");
				break;
			case '>':
				stringBuilder.Append("&gt;");
				break;
			case '&':
				stringBuilder.Append("&amp;");
				break;
			default:
				stringBuilder.Append(c);
				break;
			}
		}
		return stringBuilder.ToString();
	}

	protected static string StackTraceString(Exception exception)
	{
		string text = exception.StackTrace;
		if (string.IsNullOrEmpty(text))
		{
			StackTrace stackTrace = new StackTrace(fNeedFileInfo: false);
			StackFrame[] frames = stackTrace.GetFrames();
			int num = 0;
			bool flag = false;
			StackFrame[] array = frames;
			foreach (StackFrame stackFrame in array)
			{
				string name = stackFrame.GetMethod().Name;
				switch (name)
				{
				case "StackTraceString":
				case "AddExceptionToTraceString":
				case "BuildTrace":
				case "TraceEvent":
				case "TraceException":
				case "GetAdditionalPayload":
					num++;
					break;
				default:
					if (name.StartsWith("ThrowHelper", StringComparison.Ordinal))
					{
						num++;
					}
					else
					{
						flag = true;
					}
					break;
				}
				if (flag)
				{
					break;
				}
			}
			stackTrace = new StackTrace(num, fNeedFileInfo: false);
			text = stackTrace.ToString();
		}
		return text;
	}
}
