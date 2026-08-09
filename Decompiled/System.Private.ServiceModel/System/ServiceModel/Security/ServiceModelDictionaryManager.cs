using System.IdentityModel;
using System.ServiceModel.Channels;

namespace System.ServiceModel.Security;

internal class ServiceModelDictionaryManager
{
	private static DictionaryManager s_dictionaryManager;

	public static DictionaryManager Instance
	{
		get
		{
			if (s_dictionaryManager == null)
			{
				s_dictionaryManager = new DictionaryManager(BinaryMessageEncoderFactory.XmlDictionary);
			}
			return s_dictionaryManager;
		}
	}
}
