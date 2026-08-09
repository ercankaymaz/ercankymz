using System.Xml;

namespace System.ServiceModel.Channels;

internal abstract class DictionaryHeader : MessageHeader
{
	public override string Name => DictionaryName.Value;

	public override string Namespace => DictionaryNamespace.Value;

	public abstract XmlDictionaryString DictionaryName { get; }

	public abstract XmlDictionaryString DictionaryNamespace { get; }

	protected override void OnWriteStartHeader(XmlDictionaryWriter writer, MessageVersion messageVersion)
	{
		writer.WriteStartElement(DictionaryName, DictionaryNamespace);
		WriteHeaderAttributes(writer, messageVersion);
	}
}
