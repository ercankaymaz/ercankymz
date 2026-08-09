using System.IO;
using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel.Diagnostics;

internal static class MessageLogger
{
	public static bool LoggingEnabled => false;

	public static bool ShouldLogMalformed { get; set; }

	public static bool LogMessagesAtTransportLevel { get; set; }

	public static bool LogMessagesAtServiceLevel { get; set; }

	internal static void LogMessage(ref Message message, int arg1)
	{
		throw System.NotImplemented.ByDesign;
	}

	internal static void LogMessage(Stream stream, MessageLoggingSource messageLoggingSource)
	{
		throw System.NotImplemented.ByDesign;
	}

	internal static void LogMessage(ref Message message, MessageLoggingSource messageLoggingSource)
	{
		throw System.NotImplemented.ByDesign;
	}

	internal static void LogMessage(ArraySegment<byte> arraySegment, MessageLoggingSource messageLoggingSource)
	{
		throw System.NotImplemented.ByDesign;
	}

	internal static void LogMessage(ref Message message, XmlDictionaryReader xmlDictionaryReader, MessageLoggingSource messageLoggingSource)
	{
		throw System.NotImplemented.ByDesign;
	}
}
