namespace System.Composition.Diagnostics;

internal abstract class TraceWriter
{
	public abstract bool CanWriteInformation { get; }

	public abstract bool CanWriteWarning { get; }

	public abstract bool CanWriteError { get; }

	public abstract void WriteInformation(System.Composition.Diagnostics.CompositionTraceId traceId, string format, params object[] arguments);

	public abstract void WriteWarning(System.Composition.Diagnostics.CompositionTraceId traceId, string format, params object[] arguments);

	public abstract void WriteError(System.Composition.Diagnostics.CompositionTraceId traceId, string format, params object[] arguments);
}
