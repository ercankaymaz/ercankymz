using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal delegate Task OperationWithTimeoutAsyncCallback(TimeSpan timeout);
