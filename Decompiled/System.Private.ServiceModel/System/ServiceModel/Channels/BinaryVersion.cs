using System.Xml;

namespace System.ServiceModel.Channels;

public class BinaryVersion
{
	public static readonly BinaryVersion Version1 = new BinaryVersion("application/soap+msbin1", "application/soap+msbinsession1", ServiceModelDictionary.Version1);

	public static readonly BinaryVersion GZipVersion1 = new BinaryVersion("application/soap+msbin1+gzip", "application/soap+msbinsession1+gzip", ServiceModelDictionary.Version1);

	public static readonly BinaryVersion DeflateVersion1 = new BinaryVersion("application/soap+msbin1+deflate", "application/soap+msbinsession1+deflate", ServiceModelDictionary.Version1);

	private IXmlDictionary _dictionary;

	public static BinaryVersion CurrentVersion => Version1;

	public string ContentType { get; }

	public string SessionContentType { get; }

	public IXmlDictionary Dictionary => _dictionary;

	private BinaryVersion(string contentType, string sessionContentType, IXmlDictionary dictionary)
	{
		ContentType = contentType;
		SessionContentType = sessionContentType;
		_dictionary = dictionary;
	}
}
