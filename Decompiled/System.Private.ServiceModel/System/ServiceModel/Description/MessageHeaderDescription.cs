using System.ComponentModel;

namespace System.ServiceModel.Description;

public class MessageHeaderDescription : MessagePartDescription
{
	private bool _relay;

	private bool _isUnknownHeader;

	[DefaultValue(null)]
	public string Actor { get; set; }

	[DefaultValue(false)]
	public bool MustUnderstand { get; set; }

	[DefaultValue(false)]
	public bool Relay
	{
		get
		{
			return _relay;
		}
		set
		{
			_relay = value;
		}
	}

	[DefaultValue(false)]
	public bool TypedHeader { get; set; }

	internal bool IsUnknownHeaderCollection
	{
		get
		{
			return _isUnknownHeader;
		}
		set
		{
			_isUnknownHeader = value;
		}
	}

	public MessageHeaderDescription(string name, string ns)
		: base(name, ns)
	{
	}

	internal MessageHeaderDescription(MessageHeaderDescription other)
		: base(other)
	{
		MustUnderstand = other.MustUnderstand;
		Relay = other.Relay;
		Actor = other.Actor;
		TypedHeader = other.TypedHeader;
		IsUnknownHeaderCollection = other.IsUnknownHeaderCollection;
	}

	internal override MessagePartDescription Clone()
	{
		return new MessageHeaderDescription(this);
	}
}
