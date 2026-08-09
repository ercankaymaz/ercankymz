using System.Xml;

namespace System.ServiceModel.Channels;

internal static class EncoderHelpers
{
	internal static XmlDictionaryReaderQuotas GetBufferedReadQuotas(XmlDictionaryReaderQuotas encoderQuotas)
	{
		XmlDictionaryReaderQuotas xmlDictionaryReaderQuotas = new XmlDictionaryReaderQuotas();
		encoderQuotas.CopyTo(xmlDictionaryReaderQuotas);
		if (IsDefaultQuota(xmlDictionaryReaderQuotas, XmlDictionaryReaderQuotaTypes.MaxStringContentLength))
		{
			xmlDictionaryReaderQuotas.MaxStringContentLength = int.MaxValue;
		}
		if (IsDefaultQuota(xmlDictionaryReaderQuotas, XmlDictionaryReaderQuotaTypes.MaxArrayLength))
		{
			xmlDictionaryReaderQuotas.MaxArrayLength = int.MaxValue;
		}
		if (IsDefaultQuota(xmlDictionaryReaderQuotas, XmlDictionaryReaderQuotaTypes.MaxBytesPerRead))
		{
			xmlDictionaryReaderQuotas.MaxBytesPerRead = int.MaxValue;
		}
		if (IsDefaultQuota(xmlDictionaryReaderQuotas, XmlDictionaryReaderQuotaTypes.MaxNameTableCharCount))
		{
			xmlDictionaryReaderQuotas.MaxNameTableCharCount = int.MaxValue;
		}
		if (IsDefaultQuota(xmlDictionaryReaderQuotas, XmlDictionaryReaderQuotaTypes.MaxDepth))
		{
			xmlDictionaryReaderQuotas.MaxDepth = 128;
		}
		return xmlDictionaryReaderQuotas;
	}

	private static bool IsDefaultQuota(XmlDictionaryReaderQuotas quotas, XmlDictionaryReaderQuotaTypes quotaType)
	{
		switch (quotaType)
		{
		case XmlDictionaryReaderQuotaTypes.MaxDepth:
		case XmlDictionaryReaderQuotaTypes.MaxStringContentLength:
		case XmlDictionaryReaderQuotaTypes.MaxArrayLength:
		case XmlDictionaryReaderQuotaTypes.MaxBytesPerRead:
		case XmlDictionaryReaderQuotaTypes.MaxNameTableCharCount:
			return (quotas.ModifiedQuotas & quotaType) == 0;
		default:
			return false;
		}
	}
}
