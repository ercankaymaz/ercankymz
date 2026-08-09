using System.Runtime.Serialization;
using System.Xml;

namespace System.ServiceModel.Channels;

internal class XmlObjectSerializerBodyWriter : BodyWriter
{
	private object _body;

	private XmlObjectSerializer _serializer;

	private object ThisLock => this;

	public XmlObjectSerializerBodyWriter(object body, XmlObjectSerializer serializer)
		: base(isBuffered: true)
	{
		_body = body;
		_serializer = serializer;
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		lock (ThisLock)
		{
			_serializer.WriteObject(writer, _body);
		}
	}
}
