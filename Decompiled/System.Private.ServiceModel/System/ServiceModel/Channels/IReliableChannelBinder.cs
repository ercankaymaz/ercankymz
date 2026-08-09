using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal interface IReliableChannelBinder
{
	IChannel Channel { get; }

	bool Connected { get; }

	TimeSpan DefaultSendTimeout { get; }

	bool HasSession { get; }

	EndpointAddress LocalAddress { get; }

	EndpointAddress RemoteAddress { get; }

	CommunicationState State { get; }

	event BinderExceptionHandler Faulted;

	event BinderExceptionHandler OnException;

	void Abort();

	Task CloseAsync(TimeSpan timeout);

	Task CloseAsync(TimeSpan timeout, MaskingMode maskingMode);

	Task OpenAsync(TimeSpan timeout);

	Task SendAsync(Message message, TimeSpan timeout);

	Task SendAsync(Message message, TimeSpan timeout, MaskingMode maskingMode);

	Task<(bool success, RequestContext requestContext)> TryReceiveAsync(TimeSpan timeout);

	Task<(bool success, RequestContext requestContext)> TryReceiveAsync(TimeSpan timeout, MaskingMode maskingMode);

	ISession GetInnerSession();

	void HandleException(Exception e);

	bool IsHandleable(Exception e);

	void SetMaskingMode(RequestContext context, MaskingMode maskingMode);

	RequestContext WrapRequestContext(RequestContext context);
}
