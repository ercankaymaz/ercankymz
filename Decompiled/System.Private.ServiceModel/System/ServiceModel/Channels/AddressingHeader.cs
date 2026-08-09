using System.Xml;

namespace System.ServiceModel.Channels;

internal abstract class AddressingHeader : DictionaryHeader, IMessageHeaderWithSharedNamespace
{
	internal AddressingVersion Version { get; }

	XmlDictionaryString IMessageHeaderWithSharedNamespace.SharedPrefix => XD.AddressingDictionary.Prefix;

	XmlDictionaryString IMessageHeaderWithSharedNamespace.SharedNamespace => Version.DictionaryNamespace;

	public override XmlDictionaryString DictionaryNamespace => Version.DictionaryNamespace;

	protected AddressingHeader(AddressingVersion version)
	{
		Version = version;
	}
}
