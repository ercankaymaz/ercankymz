using System.Runtime.Serialization;
using System.Xml;

namespace System.ServiceModel.Channels;

public class XmlObjectSerializerFault : MessageFault
{
	private FaultCode _code;

	private FaultReason _reason;

	private string _actor;

	private string _node;

	private object _detail;

	private XmlObjectSerializer _serializer;

	public override string Actor => _actor;

	public override FaultCode Code => _code;

	public override bool HasDetail => _serializer != null;

	public override string Node => _node;

	public override FaultReason Reason => _reason;

	private object ThisLock => _code;

	public XmlObjectSerializerFault(FaultCode code, FaultReason reason, object detail, XmlObjectSerializer serializer, string actor, string node)
	{
		_code = code;
		_reason = reason;
		_detail = detail;
		_serializer = serializer;
		_actor = actor;
		_node = node;
	}

	protected override void OnWriteDetailContents(XmlDictionaryWriter writer)
	{
		if (_serializer != null)
		{
			lock (ThisLock)
			{
				_serializer.WriteObject(writer, _detail);
			}
		}
	}
}
