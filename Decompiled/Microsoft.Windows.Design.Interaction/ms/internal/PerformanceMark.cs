using Microsoft.Internal.Performance;

namespace MS.Internal;

internal struct PerformanceMark(string description, CodeMarkerEvent beginEvent, CodeMarkerEvent endEvent)
{
	private string _description = description;

	private CodeMarkerEvent _beginEvent = beginEvent;

	private CodeMarkerEvent _endEvent = endEvent;

	public string Description => _description;

	public CodeMarkerEvent BeginEvent => _beginEvent;

	public CodeMarkerEvent EndEvent => _endEvent;
}
