namespace System.Composition.Diagnostics;

internal static class CompositionTraceSource
{
	private static readonly System.Composition.Diagnostics.DebuggerTraceWriter s_source = new System.Composition.Diagnostics.DebuggerTraceWriter();

	public static bool CanWriteInformation => s_source.CanWriteInformation;

	public static bool CanWriteWarning => s_source.CanWriteWarning;

	public static bool CanWriteError => s_source.CanWriteError;

	public static void WriteInformation(System.Composition.Diagnostics.CompositionTraceId traceId, string format, params object[] arguments)
	{
		EnsureEnabled(CanWriteInformation);
		s_source.WriteInformation(traceId, format, arguments);
	}

	public static void WriteWarning(System.Composition.Diagnostics.CompositionTraceId traceId, string format, params object[] arguments)
	{
		EnsureEnabled(CanWriteWarning);
		s_source.WriteWarning(traceId, format, arguments);
	}

	public static void WriteError(System.Composition.Diagnostics.CompositionTraceId traceId, string format, params object[] arguments)
	{
		EnsureEnabled(CanWriteError);
		s_source.WriteError(traceId, format, arguments);
	}

	private static void EnsureEnabled(bool condition)
	{
		if (!condition)
		{
			throw new Exception(System.SR.Format(System.SR.Diagnostic_InternalExceptionMessage, System.SR.Diagnostic_TraceUnnecessaryWork));
		}
	}
}
