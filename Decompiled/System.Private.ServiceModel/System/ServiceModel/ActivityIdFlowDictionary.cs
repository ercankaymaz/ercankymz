using System.Xml;

namespace System.ServiceModel;

internal class ActivityIdFlowDictionary
{
	public XmlDictionaryString ActivityId;

	public XmlDictionaryString ActivityIdNamespace;

	public ActivityIdFlowDictionary(ServiceModelDictionary dictionary)
	{
		ActivityId = dictionary.CreateString("ActivityId", 425);
		ActivityIdNamespace = dictionary.CreateString("http://schemas.microsoft.com/2004/09/ServiceModel/Diagnostics", 426);
	}
}
