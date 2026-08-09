using System.Xml;

namespace System.ServiceModel.Channels;

internal class ActionHeader : AddressingHeader
{
	internal class DictionaryActionHeader : ActionHeader
	{
		private XmlDictionaryString _dictionaryAction;

		public DictionaryActionHeader(XmlDictionaryString dictionaryAction, AddressingVersion version)
			: base(dictionaryAction.Value, version)
		{
			_dictionaryAction = dictionaryAction;
		}

		protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			writer.WriteString(_dictionaryAction);
		}
	}

	internal class FullActionHeader : ActionHeader
	{
		private string _actor;

		private bool _mustUnderstand;

		private bool _relay;

		public override string Actor => _actor;

		public override bool MustUnderstand => _mustUnderstand;

		public override bool Relay => _relay;

		public FullActionHeader(string action, string actor, bool mustUnderstand, bool relay, AddressingVersion version)
			: base(action, version)
		{
			_actor = actor;
			_mustUnderstand = mustUnderstand;
			_relay = relay;
		}
	}

	private const bool mustUnderstandValue = true;

	public string Action { get; }

	public override bool MustUnderstand => true;

	public override XmlDictionaryString DictionaryName => XD.AddressingDictionary.Action;

	private ActionHeader(string action, AddressingVersion version)
		: base(version)
	{
		Action = action;
	}

	public static ActionHeader Create(string action, AddressingVersion addressingVersion)
	{
		if (action == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("action"));
		}
		if (addressingVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("addressingVersion");
		}
		return new ActionHeader(action, addressingVersion);
	}

	public static ActionHeader Create(XmlDictionaryString dictionaryAction, AddressingVersion addressingVersion)
	{
		if (dictionaryAction == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("dictionaryAction"));
		}
		if (addressingVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("addressingVersion");
		}
		return new DictionaryActionHeader(dictionaryAction, addressingVersion);
	}

	protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		writer.WriteString(Action);
	}

	public static string ReadHeaderValue(XmlDictionaryReader reader, AddressingVersion addressingVersion)
	{
		string text = reader.ReadElementContentAsString();
		if (text.Length > 0 && (text[0] <= ' ' || text[text.Length - 1] <= ' '))
		{
			text = XmlUtil.Trim(text);
		}
		return text;
	}

	public static ActionHeader ReadHeader(XmlDictionaryReader reader, AddressingVersion version, string actor, bool mustUnderstand, bool relay)
	{
		string action = ReadHeaderValue(reader, version);
		if (actor.Length == 0 && mustUnderstand && !relay)
		{
			return new ActionHeader(action, version);
		}
		return new FullActionHeader(action, actor, mustUnderstand, relay, version);
	}
}
