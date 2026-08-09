namespace System.ServiceModel.Channels;

internal interface IRequestReplyCorrelator
{
	void Add<T>(Message request, T state);

	T Find<T>(Message reply, bool remove);
}
