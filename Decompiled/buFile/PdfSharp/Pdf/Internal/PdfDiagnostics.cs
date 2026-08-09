namespace PdfSharp.Pdf.Internal;

internal class PdfDiagnostics
{
	private static bool _traceCompressedObjects = true;

	private static bool _traceXrefStreams = true;

	private static bool _traceObjectStreams = true;

	public static bool TraceCompressedObjects
	{
		get
		{
			return _traceCompressedObjects;
		}
		set
		{
			_traceCompressedObjects = value;
		}
	}

	public static bool TraceXrefStreams
	{
		get
		{
			return _traceXrefStreams && TraceCompressedObjects;
		}
		set
		{
			_traceXrefStreams = value;
		}
	}

	public static bool TraceObjectStreams
	{
		get
		{
			return _traceObjectStreams && TraceCompressedObjects;
		}
		set
		{
			_traceObjectStreams = value;
		}
	}
}
