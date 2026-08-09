using System.IdentityModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;

namespace System.ServiceModel.Security;

internal class WSSecurityOneDotZeroReceiveSecurityHeader : ReceiveSecurityHeader
{
	public WSSecurityOneDotZeroReceiveSecurityHeader(Message message, string actor, bool mustUnderstand, bool relay, SecurityStandardsManager standardsManager, SecurityAlgorithmSuite algorithmSuite, int headerIndex, MessageDirection transferDirection)
		: base(message, actor, mustUnderstand, relay, standardsManager, algorithmSuite, headerIndex, transferDirection)
	{
	}

	protected override bool IsReaderAtReferenceList(XmlDictionaryReader reader)
	{
		return reader.IsStartElement(ReferenceList.ElementName, ReferenceList.NamespaceUri);
	}

	protected override bool IsReaderAtSignature(XmlDictionaryReader reader)
	{
		return reader.IsStartElement(XD.XmlSignatureDictionary.Signature, XD.XmlSignatureDictionary.Namespace);
	}

	protected override void EnsureDecryptionComplete()
	{
	}

	protected override bool IsReaderAtEncryptedKey(XmlDictionaryReader reader)
	{
		return reader.IsStartElement(System.IdentityModel.XD.XmlEncryptionDictionary.EncryptedKey, System.IdentityModel.XD.XmlEncryptionDictionary.Namespace);
	}

	protected override bool IsReaderAtEncryptedData(XmlDictionaryReader reader)
	{
		bool flag = reader.IsStartElement(System.IdentityModel.XD.XmlEncryptionDictionary.EncryptedData, System.IdentityModel.XD.XmlEncryptionDictionary.Namespace);
		if (flag)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		return flag;
	}

	protected override bool IsReaderAtSecurityTokenReference(XmlDictionaryReader reader)
	{
		return reader.IsStartElement(XD.SecurityJan2004Dictionary.SecurityTokenReference, XD.SecurityJan2004Dictionary.Namespace);
	}
}
