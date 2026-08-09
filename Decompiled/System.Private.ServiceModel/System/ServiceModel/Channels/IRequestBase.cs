namespace System.ServiceModel.Channels;

public interface IRequestBase
{
	void Abort(RequestChannel requestChannel);

	void Fault(RequestChannel requestChannel);

	void OnReleaseRequest();
}
