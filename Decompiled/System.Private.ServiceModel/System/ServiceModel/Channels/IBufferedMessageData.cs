using System.Xml;

namespace System.ServiceModel.Channels;

internal interface IBufferedMessageData
{
	MessageEncoder MessageEncoder { get; }

	ArraySegment<byte> Buffer { get; }

	XmlDictionaryReaderQuotas Quotas { get; }

	void Close();

	void EnableMultipleUsers();

	XmlDictionaryReader GetMessageReader();

	void Open();

	void ReturnMessageState(RecycledMessageState messageState);

	RecycledMessageState TakeMessageState();
}
