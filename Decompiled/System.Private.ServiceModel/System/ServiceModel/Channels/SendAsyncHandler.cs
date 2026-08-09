using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal delegate Task SendAsyncHandler(MessageAttemptInfo attemptInfo, TimeSpan timeout, bool maskUnhandledException);
