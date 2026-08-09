namespace System.Runtime;

internal struct TracePayload(string serializedException, string eventSource, string appDomainFriendlyName, string extendedData, string hostReference)
{
	private string _hostReference = hostReference;

	public string SerializedException { get; } = serializedException;

	public string EventSource { get; } = eventSource;

	public string AppDomainFriendlyName { get; } = appDomainFriendlyName;

	public string ExtendedData { get; } = extendedData;

	public string HostReference => _hostReference;
}
