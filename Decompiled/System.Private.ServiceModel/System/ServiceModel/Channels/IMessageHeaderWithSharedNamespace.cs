using System.Xml;

namespace System.ServiceModel.Channels;

internal interface IMessageHeaderWithSharedNamespace
{
	XmlDictionaryString SharedNamespace { get; }

	XmlDictionaryString SharedPrefix { get; }
}
