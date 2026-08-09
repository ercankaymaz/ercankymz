namespace System.ServiceModel.Channels;

internal struct FaultState(RequestContext requestContext, Message faultMessage)
{
	public Message FaultMessage { get; } = faultMessage;

	public RequestContext RequestContext { get; } = requestContext;
}
