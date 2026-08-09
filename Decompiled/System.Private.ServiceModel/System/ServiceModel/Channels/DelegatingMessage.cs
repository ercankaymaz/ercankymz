using System.Xml;

namespace System.ServiceModel.Channels;

internal abstract class DelegatingMessage : Message
{
	public override bool IsEmpty => InnerMessage.IsEmpty;

	public override bool IsFault => InnerMessage.IsFault;

	public override MessageHeaders Headers => InnerMessage.Headers;

	public override MessageProperties Properties => InnerMessage.Properties;

	public override MessageVersion Version => InnerMessage.Version;

	protected Message InnerMessage { get; }

	protected DelegatingMessage(Message innerMessage)
	{
		InnerMessage = innerMessage ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("innerMessage");
	}

	protected override void OnClose()
	{
		base.OnClose();
		InnerMessage.Close();
	}

	protected override void OnWriteStartEnvelope(XmlDictionaryWriter writer)
	{
		InnerMessage.WriteStartEnvelope(writer);
	}

	protected override void OnWriteStartHeaders(XmlDictionaryWriter writer)
	{
		InnerMessage.WriteStartHeaders(writer);
	}

	protected override void OnWriteStartBody(XmlDictionaryWriter writer)
	{
		InnerMessage.WriteStartBody(writer);
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		InnerMessage.WriteBodyContents(writer);
	}

	protected override string OnGetBodyAttribute(string localName, string ns)
	{
		return InnerMessage.GetBodyAttribute(localName, ns);
	}

	protected override void OnBodyToString(XmlDictionaryWriter writer)
	{
		InnerMessage.BodyToString(writer);
	}
}
