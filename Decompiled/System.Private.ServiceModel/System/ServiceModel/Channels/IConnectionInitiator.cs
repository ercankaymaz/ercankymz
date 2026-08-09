using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

public interface IConnectionInitiator
{
	IConnection Connect(Uri uri, TimeSpan timeout);

	Task<IConnection> ConnectAsync(Uri uri, TimeSpan timeout);
}
