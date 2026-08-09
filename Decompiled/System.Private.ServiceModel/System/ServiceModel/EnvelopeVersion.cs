using System.Xml;

namespace System.ServiceModel;

public sealed class EnvelopeVersion
{
	private string _ns;

	private string _toStringFormat;

	private string _receiverFaultName;

	private const string Soap11ToStringFormat = "Soap11 ({0})";

	private const string Soap12ToStringFormat = "Soap12 ({0})";

	private const string EnvelopeNoneToStringFormat = "EnvelopeNone ({0})";

	private static EnvelopeVersion s_soap12 = new EnvelopeVersion("http://www.w3.org/2003/05/soap-envelope/role/ultimateReceiver", "http://www.w3.org/2003/05/soap-envelope/role/next", "http://www.w3.org/2003/05/soap-envelope", XD.Message12Dictionary.Namespace, "role", XD.Message12Dictionary.Role, "Soap12 ({0})", "Sender", "Receiver");

	internal string Actor { get; }

	internal XmlDictionaryString DictionaryActor { get; }

	internal string Namespace => _ns;

	internal XmlDictionaryString DictionaryNamespace { get; }

	public string NextDestinationActorValue { get; }

	public static EnvelopeVersion None { get; } = new EnvelopeVersion(null, null, "http://schemas.microsoft.com/ws/2005/05/envelope/none", XD.MessageDictionary.Namespace, null, null, "EnvelopeNone ({0})", "Sender", "Receiver");

	public static EnvelopeVersion Soap11 { get; } = new EnvelopeVersion("", "http://schemas.xmlsoap.org/soap/actor/next", "http://schemas.xmlsoap.org/soap/envelope/", XD.Message11Dictionary.Namespace, "actor", XD.Message11Dictionary.Actor, "Soap11 ({0})", "Client", "Server");

	public static EnvelopeVersion Soap12 => s_soap12;

	internal string ReceiverFaultName => _receiverFaultName;

	internal string SenderFaultName { get; }

	internal string[] MustUnderstandActorValues { get; }

	internal string UltimateDestinationActor { get; }

	internal string[] UltimateDestinationActorValues { get; }

	private EnvelopeVersion(string ultimateReceiverActor, string nextDestinationActorValue, string ns, XmlDictionaryString dictionaryNs, string actor, XmlDictionaryString dictionaryActor, string toStringFormat, string senderFaultName, string receiverFaultName)
	{
		_toStringFormat = toStringFormat;
		UltimateDestinationActor = ultimateReceiverActor;
		NextDestinationActorValue = nextDestinationActorValue;
		_ns = ns;
		DictionaryNamespace = dictionaryNs;
		Actor = actor;
		DictionaryActor = dictionaryActor;
		SenderFaultName = senderFaultName;
		_receiverFaultName = receiverFaultName;
		if (ultimateReceiverActor != null)
		{
			if (ultimateReceiverActor.Length == 0)
			{
				MustUnderstandActorValues = new string[2] { "", nextDestinationActorValue };
				UltimateDestinationActorValues = new string[2] { "", nextDestinationActorValue };
			}
			else
			{
				MustUnderstandActorValues = new string[3] { "", ultimateReceiverActor, nextDestinationActorValue };
				UltimateDestinationActorValues = new string[3] { "", ultimateReceiverActor, nextDestinationActorValue };
			}
		}
	}

	public string[] GetUltimateDestinationActorValues()
	{
		return (string[])UltimateDestinationActorValues.Clone();
	}

	internal bool IsUltimateDestinationActor(string actor)
	{
		if (actor.Length != 0 && !(actor == UltimateDestinationActor))
		{
			return actor == NextDestinationActorValue;
		}
		return true;
	}

	public override string ToString()
	{
		return string.Format(_toStringFormat, Namespace);
	}
}
