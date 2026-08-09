using System.IO;

namespace System.ServiceModel.Channels;

internal interface IStreamedMessageEncoder
{
	Stream GetResponseMessageStream(Message message);
}
