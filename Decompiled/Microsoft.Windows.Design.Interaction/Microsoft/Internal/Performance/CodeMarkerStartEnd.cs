using System;

namespace Microsoft.Internal.Performance;

internal sealed class CodeMarkerStartEnd : IDisposable
{
	private CodeMarkerEvent _end;

	public CodeMarkerStartEnd(CodeMarkerEvent begin, CodeMarkerEvent end)
	{
		CodeMarkers.Instance.CodeMarker(begin);
		_end = end;
	}

	public void Dispose()
	{
		if (_end != 0)
		{
			CodeMarkers.Instance.CodeMarker(_end);
			_end = (CodeMarkerEvent)0;
		}
	}
}
