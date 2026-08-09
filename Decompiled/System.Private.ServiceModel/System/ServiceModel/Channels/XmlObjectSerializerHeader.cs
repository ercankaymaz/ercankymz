using System.Runtime.Serialization;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace System.ServiceModel.Channels;

internal class XmlObjectSerializerHeader : MessageHeader
{
	private XmlObjectSerializer _serializer;

	private bool _mustUnderstand;

	private bool _relay;

	private bool _isOneTwoSupported;

	private bool _isOneOneSupported;

	private bool _isNoneSupported;

	private object _objectToSerialize;

	private string _name;

	private string _ns;

	private string _actor;

	private object _syncRoot = new object();

	public override string Name => _name;

	public override string Namespace => _ns;

	public override bool MustUnderstand => _mustUnderstand;

	public override bool Relay => _relay;

	public override string Actor => _actor;

	private XmlObjectSerializerHeader(XmlObjectSerializer serializer, bool mustUnderstand, string actor, bool relay)
	{
		_mustUnderstand = mustUnderstand;
		_relay = relay;
		_serializer = serializer;
		_actor = actor ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("actor");
		if (actor == EnvelopeVersion.Soap12.UltimateDestinationActor)
		{
			_isOneOneSupported = false;
			_isOneTwoSupported = true;
		}
		else if (actor == EnvelopeVersion.Soap12.NextDestinationActorValue)
		{
			_isOneOneSupported = false;
			_isOneTwoSupported = true;
		}
		else if (actor == EnvelopeVersion.Soap11.NextDestinationActorValue)
		{
			_isOneOneSupported = true;
			_isOneTwoSupported = false;
		}
		else
		{
			_isOneOneSupported = true;
			_isOneTwoSupported = true;
			_isNoneSupported = true;
		}
	}

	public XmlObjectSerializerHeader(string name, string ns, object objectToSerialize, XmlObjectSerializer serializer, bool mustUnderstand, string actor, bool relay)
		: this(serializer, mustUnderstand, actor, relay)
	{
		if (name == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("name"));
		}
		if (name.Length == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.SFXHeaderNameCannotBeNullOrEmpty, "name"));
		}
		if (ns == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("ns");
		}
		if (ns.Length > 0)
		{
			NamingHelper.CheckUriParameter(ns, "ns");
		}
		_objectToSerialize = objectToSerialize;
		_name = name;
		_ns = ns;
	}

	public override bool IsMessageVersionSupported(MessageVersion messageVersion)
	{
		if (messageVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("messageVersion");
		}
		if (messageVersion.Envelope == EnvelopeVersion.Soap12)
		{
			return _isOneTwoSupported;
		}
		if (messageVersion.Envelope == EnvelopeVersion.Soap11)
		{
			return _isOneOneSupported;
		}
		if (messageVersion.Envelope == EnvelopeVersion.None)
		{
			return _isNoneSupported;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.EnvelopeVersionUnknown, messageVersion.Envelope.ToString())));
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		lock (_syncRoot)
		{
			if (_serializer == null)
			{
				_serializer = DataContractSerializerDefaults.CreateSerializer((_objectToSerialize == null) ? typeof(object) : _objectToSerialize.GetType(), Name, Namespace, int.MaxValue);
			}
			_serializer.WriteObjectContent(writer, _objectToSerialize);
		}
	}
}
