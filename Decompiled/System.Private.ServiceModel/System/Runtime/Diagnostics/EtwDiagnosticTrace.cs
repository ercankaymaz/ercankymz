using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace System.Runtime.Diagnostics;

internal sealed class EtwDiagnosticTrace : DiagnosticTraceBase
{
	private static class TraceCodes
	{
		public const string AppDomainUnload = "AppDomainUnload";

		public const string TraceHandledException = "TraceHandledException";

		public const string ThrowingException = "ThrowingException";

		public const string UnhandledException = "UnhandledException";
	}

	private static class EventIdsWithMsdnTraceCode
	{
		public const int AppDomainUnload = 57393;

		public const int ThrowingExceptionWarning = 57396;

		public const int ThrowingExceptionVerbose = 57407;

		public const int HandledExceptionInfo = 57394;

		public const int HandledExceptionWarning = 57404;

		public const int HandledExceptionError = 57405;

		public const int HandledExceptionVerbose = 57406;

		public const int UnhandledException = 57397;
	}

	private static class LegacyTraceEventIds
	{
		public const int Diagnostics = 131072;

		public const int AppDomainUnload = 131073;

		public const int EventLog = 131074;

		public const int ThrowingException = 131075;

		public const int TraceHandledException = 131076;

		public const int UnhandledException = 131077;
	}

	internal static class StringBuilderPool
	{
		private const int maxPooledStringBuilders = 64;

		private static readonly ConcurrentQueue<StringBuilder> s_freeStringBuilders = new ConcurrentQueue<StringBuilder>();

		public static StringBuilder Take()
		{
			StringBuilder result = null;
			if (s_freeStringBuilders.TryDequeue(out result))
			{
				return result;
			}
			return new StringBuilder();
		}

		public static void Return(StringBuilder sb)
		{
			if (s_freeStringBuilders.Count <= 64)
			{
				sb.Clear();
				s_freeStringBuilders.Enqueue(sb);
			}
		}
	}

	private const int MaxExceptionStringLength = 28672;

	private const int MaxExceptionDepth = 64;

	private const int XmlBracketsLength = 5;

	public bool IsEtwProviderEnabled => false;

	public bool IsEnd2EndActivityTracingEnabled
	{
		get
		{
			if (WcfEventSource.Instance.IsEnabled())
			{
				if (!WcfEventSource.Instance.ActionItemScheduledIsEnabled())
				{
					return WcfEventSource.Instance.ActionItemCallbackInvokedIsEnabled();
				}
				return true;
			}
			return false;
		}
	}

	private bool EtwTracingEnabled => false;

	public void SetEnd2EndActivityTracingEnabled(bool isEnd2EndTracingEnabled)
	{
	}

	public void Event(ref EventDescriptor eventDescriptor, string description)
	{
		if (base.TracingEnabled)
		{
			TracePayload serializedPayload = GetSerializedPayload(null, null, null);
			WriteTraceSource(ref eventDescriptor, description, serializedPayload);
		}
	}

	public void SetAndTraceTransfer(Guid newId, bool emitTransfer)
	{
		if (emitTransfer)
		{
			TraceTransfer(newId);
		}
		DiagnosticTraceBase.ActivityId = newId;
	}

	public void TraceTransfer(Guid newId)
	{
	}

	public void WriteTraceSource(ref EventDescriptor eventDescriptor, string description, TracePayload payload)
	{
	}

	private static string LookupChannel(TraceChannel traceChannel)
	{
		return traceChannel switch
		{
			TraceChannel.Admin => "Admin", 
			TraceChannel.Analytic => "Analytic", 
			TraceChannel.Application => "Application", 
			TraceChannel.Debug => "Debug", 
			TraceChannel.Operational => "Operational", 
			TraceChannel.Perf => "Perf", 
			_ => traceChannel.ToString(), 
		};
	}

	public TracePayload GetSerializedPayload(object source, TraceRecord traceRecord, Exception exception)
	{
		return GetSerializedPayload(source, traceRecord, exception, getServiceReference: false);
	}

	public TracePayload GetSerializedPayload(object source, TraceRecord traceRecord, Exception exception, bool getServiceReference)
	{
		string eventSource = null;
		string extendedData = null;
		string serializedException = null;
		if (source != null)
		{
			eventSource = DiagnosticTraceBase.CreateSourceString(source);
		}
		if (traceRecord != null)
		{
			StringBuilder stringBuilder = StringBuilderPool.Take();
			try
			{
				using StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.CurrentCulture);
				using XmlWriter xmlWriter = XmlWriter.Create(stringWriter);
				xmlWriter.WriteStartElement("ExtendedData");
				traceRecord.WriteTo(xmlWriter);
				xmlWriter.WriteEndElement();
				xmlWriter.Flush();
				stringWriter.Flush();
				extendedData = stringBuilder.ToString();
			}
			finally
			{
				StringBuilderPool.Return(stringBuilder);
			}
		}
		if (exception != null)
		{
			serializedException = ExceptionToTraceString(exception, 28672);
		}
		return new TracePayload(serializedException, eventSource, DiagnosticTraceBase.AppDomainFriendlyName, extendedData, string.Empty);
	}

	public bool IsEtwEventEnabled(ref EventDescriptor eventDescriptor)
	{
		return IsEtwEventEnabled(ref eventDescriptor, fullCheck: true);
	}

	public bool IsEtwEventEnabled(ref EventDescriptor eventDescriptor, bool fullCheck)
	{
		return false;
	}

	public override bool IsEnabled()
	{
		return false;
	}

	internal static string ExceptionToTraceString(Exception exception, int maxTraceStringLength)
	{
		StringBuilder stringBuilder = StringBuilderPool.Take();
		try
		{
			using StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.CurrentCulture);
			using XmlWriter xmlWriter = XmlWriter.Create(stringWriter);
			WriteExceptionToTraceString(xmlWriter, exception, maxTraceStringLength, 64);
			xmlWriter.Flush();
			stringWriter.Flush();
			return stringBuilder.ToString();
		}
		finally
		{
			StringBuilderPool.Return(stringBuilder);
		}
	}

	private static void WriteExceptionToTraceString(XmlWriter xml, Exception exception, int remainingLength, int remainingAllowedRecursionDepth)
	{
		if (remainingAllowedRecursionDepth < 1 || !WriteStartElement(xml, "Exception", ref remainingLength))
		{
			return;
		}
		try
		{
			IList<Tuple<string, string>> list = new List<Tuple<string, string>>
			{
				new Tuple<string, string>("ExceptionType", DiagnosticTraceBase.XmlEncode(exception.GetType().AssemblyQualifiedName)),
				new Tuple<string, string>("Message", DiagnosticTraceBase.XmlEncode(exception.Message)),
				new Tuple<string, string>("StackTrace", DiagnosticTraceBase.XmlEncode(DiagnosticTraceBase.StackTraceString(exception))),
				new Tuple<string, string>("ExceptionString", DiagnosticTraceBase.XmlEncode(exception.ToString()))
			};
			foreach (Tuple<string, string> item in list)
			{
				if (!WriteXmlElementString(xml, item.Item1, item.Item2, ref remainingLength))
				{
					return;
				}
			}
			if (exception.Data != null && exception.Data.Count > 0)
			{
				string exceptionData = GetExceptionData(exception);
				if (exceptionData.Length < remainingLength)
				{
					xml.WriteRaw(exceptionData);
					remainingLength -= exceptionData.Length;
				}
			}
			if (exception.InnerException != null)
			{
				string innerException = GetInnerException(exception, remainingLength, remainingAllowedRecursionDepth - 1);
				if (!string.IsNullOrEmpty(innerException) && innerException.Length < remainingLength)
				{
					xml.WriteRaw(innerException);
				}
			}
		}
		finally
		{
			xml.WriteEndElement();
		}
	}

	private static bool WriteStartElement(XmlWriter xml, string localName, ref int remainingLength)
	{
		int num = localName.Length * 2 + 5;
		if (num <= remainingLength)
		{
			xml.WriteStartElement(localName);
			remainingLength -= num;
			return true;
		}
		return false;
	}

	private static bool WriteXmlElementString(XmlWriter xml, string localName, string value, ref int remainingLength)
	{
		int num = localName.Length * 2 + 5 + (value?.Length ?? 0);
		if (num <= remainingLength)
		{
			xml.WriteElementString(localName, value);
			remainingLength -= num;
			return true;
		}
		return false;
	}

	private static string GetExceptionData(Exception exception)
	{
		StringBuilder stringBuilder = StringBuilderPool.Take();
		try
		{
			using StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.CurrentCulture);
			using XmlWriter xmlWriter = XmlWriter.Create(stringWriter);
			xmlWriter.WriteStartElement("DataItems");
			foreach (object key in exception.Data.Keys)
			{
				xmlWriter.WriteStartElement("Data");
				xmlWriter.WriteElementString("Key", DiagnosticTraceBase.XmlEncode(key.ToString()));
				if (exception.Data[key] == null)
				{
					xmlWriter.WriteElementString("Value", string.Empty);
				}
				else
				{
					xmlWriter.WriteElementString("Value", DiagnosticTraceBase.XmlEncode(exception.Data[key].ToString()));
				}
				xmlWriter.WriteEndElement();
			}
			xmlWriter.WriteEndElement();
			xmlWriter.Flush();
			stringWriter.Flush();
			return stringBuilder.ToString();
		}
		finally
		{
			StringBuilderPool.Return(stringBuilder);
		}
	}

	private static string GetInnerException(Exception exception, int remainingLength, int remainingAllowedRecursionDepth)
	{
		if (remainingAllowedRecursionDepth < 1)
		{
			return null;
		}
		StringBuilder stringBuilder = StringBuilderPool.Take();
		try
		{
			using StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.CurrentCulture);
			using XmlWriter xmlWriter = XmlWriter.Create(stringWriter);
			if (!WriteStartElement(xmlWriter, "InnerException", ref remainingLength))
			{
				return null;
			}
			WriteExceptionToTraceString(xmlWriter, exception.InnerException, remainingLength, remainingAllowedRecursionDepth);
			xmlWriter.WriteEndElement();
			xmlWriter.Flush();
			stringWriter.Flush();
			return stringBuilder.ToString();
		}
		finally
		{
			StringBuilderPool.Return(stringBuilder);
		}
	}
}
