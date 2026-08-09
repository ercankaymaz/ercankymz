using System.Xml;

namespace System.ServiceModel.Channels;

internal static class EncoderDefaults
{
	public const int MaxReadPoolSize = 64;

	public const int MaxWritePoolSize = 16;

	public const int MaxDepth = 32;

	public const int MaxStringContentLength = 8192;

	public const int MaxArrayLength = 16384;

	public const int MaxBytesPerRead = 4096;

	public const int MaxNameTableCharCount = 16384;

	public const int BufferedReadDefaultMaxDepth = 128;

	public const int BufferedReadDefaultMaxStringContentLength = int.MaxValue;

	public const int BufferedReadDefaultMaxArrayLength = int.MaxValue;

	public const int BufferedReadDefaultMaxBytesPerRead = int.MaxValue;

	public const int BufferedReadDefaultMaxNameTableCharCount = int.MaxValue;

	public const CompressionFormat DefaultCompressionFormat = CompressionFormat.None;

	public static readonly XmlDictionaryReaderQuotas ReaderQuotas = new XmlDictionaryReaderQuotas();

	public static bool IsDefaultReaderQuotas(XmlDictionaryReaderQuotas quotas)
	{
		return quotas.ModifiedQuotas == (XmlDictionaryReaderQuotaTypes)0;
	}
}
