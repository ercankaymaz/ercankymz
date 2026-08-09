using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal delegate Task RetryHandler(MessageAttemptInfo attemptInfo);
