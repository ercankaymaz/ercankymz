using System.Xml;

namespace System.ServiceModel;

internal class AddressingNoneDictionary
{
	public XmlDictionaryString Namespace;

	public AddressingNoneDictionary(ServiceModelDictionary dictionary)
	{
		Namespace = dictionary.CreateString("http://schemas.microsoft.com/ws/2005/05/addressing/none", 439);
	}
}
