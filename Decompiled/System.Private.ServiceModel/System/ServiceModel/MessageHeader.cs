using System.ServiceModel.Channels;

namespace System.ServiceModel;

public class MessageHeader<T>
{
	private bool _relay;

	public string Actor { get; set; }

	public T Content { get; set; }

	public bool MustUnderstand { get; set; }

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

	public MessageHeader()
	{
	}

	public MessageHeader(T content)
		: this(content, false, "", false)
	{
	}

	public MessageHeader(T content, bool mustUnderstand, string actor, bool relay)
	{
		Content = content;
		MustUnderstand = mustUnderstand;
		Actor = actor;
		_relay = relay;
	}

	internal Type GetGenericArgument()
	{
		return typeof(T);
	}

	public MessageHeader GetUntypedHeader(string name, string ns)
	{
		return MessageHeader.CreateHeader(name, ns, Content, MustUnderstand, Actor, _relay);
	}
}
