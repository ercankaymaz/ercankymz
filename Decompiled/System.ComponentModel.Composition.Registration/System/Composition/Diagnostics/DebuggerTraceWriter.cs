using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace System.Composition.Diagnostics;

internal sealed class DebuggerTraceWriter : System.Composition.Diagnostics.TraceWriter
{
	public enum TraceEventType
	{
		Error = 2,
		Warning = 4,
		Information = 8
	}

	private static readonly string s_sourceName = typeof(System.Composition.Diagnostics.DebuggerTraceWriter).Assembly.GetName().Name;

	public override bool CanWriteInformation => false;

	public override bool CanWriteWarning => Debugger.IsLogging();

	public override bool CanWriteError => Debugger.IsLogging();

	public override void WriteInformation(System.Composition.Diagnostics.CompositionTraceId traceId, string format, params object[] arguments)
	{
		WriteEvent(TraceEventType.Information, traceId, format, arguments);
	}

	public override void WriteWarning(System.Composition.Diagnostics.CompositionTraceId traceId, string format, params object[] arguments)
	{
		WriteEvent(TraceEventType.Warning, traceId, format, arguments);
	}

	public override void WriteError(System.Composition.Diagnostics.CompositionTraceId traceId, string format, params object[] arguments)
	{
		WriteEvent(TraceEventType.Error, traceId, format, arguments);
	}

	private static void WriteEvent(TraceEventType eventType, System.Composition.Diagnostics.CompositionTraceId traceId, string format, params object[] arguments)
	{
		if (Debugger.IsLogging())
		{
			string message = CreateLogMessage(eventType, traceId, format, arguments);
			Debugger.Log(0, null, message);
		}
	}

	private static string CreateLogMessage(TraceEventType eventType, System.Composition.Diagnostics.CompositionTraceId traceId, string format, params object[] arguments)
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = stringBuilder;
		StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(6, 3, stringBuilder2);
		handler.AppendFormatted(s_sourceName);
		handler.AppendLiteral(" ");
		handler.AppendFormatted(eventType);
		handler.AppendLiteral(": ");
		handler.AppendFormatted((int)traceId);
		handler.AppendLiteral(" : ");
		stringBuilder2.Append(ref handler);
		if (arguments == null)
		{
			stringBuilder.Append(format);
		}
		else
		{
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, format, arguments);
		}
		stringBuilder.AppendLine();
		return stringBuilder.ToString();
	}
}
