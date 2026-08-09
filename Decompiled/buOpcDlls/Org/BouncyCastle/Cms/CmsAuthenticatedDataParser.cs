using System.IO;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Cms;

public class CmsAuthenticatedDataParser : CmsContentInfoParser
{
	internal RecipientInformationStore _recipientInfoStore;

	internal AuthenticatedDataParser authData;

	private AlgorithmIdentifier macAlg;

	private byte[] mac;

	private Org.BouncyCastle.Asn1.Cms.AttributeTable authAttrs;

	private Org.BouncyCastle.Asn1.Cms.AttributeTable unauthAttrs;

	private bool authAttrNotRead;

	private bool unauthAttrNotRead;

	public AlgorithmIdentifier MacAlgorithmID => macAlg;

	public string MacAlgOid => macAlg.Algorithm.Id;

	public Asn1Object MacAlgParams => macAlg.Parameters?.ToAsn1Object();

	public CmsAuthenticatedDataParser(byte[] envelopedData)
		: this(new MemoryStream(envelopedData, writable: false))
	{
	}

	public CmsAuthenticatedDataParser(Stream envelopedData)
		: base(envelopedData)
	{
		authAttrNotRead = true;
		authData = new AuthenticatedDataParser((Asn1SequenceParser)contentInfo.GetContent(16));
		Asn1Set instance = Asn1Set.GetInstance(authData.GetRecipientInfos().ToAsn1Object());
		macAlg = authData.GetMacAlgorithm();
		CmsReadable readable = new CmsProcessableInputStream(((Asn1OctetStringParser)authData.GetEnapsulatedContentInfo().GetContent(4)).GetOctetStream());
		CmsSecureReadable secureReadable = new CmsEnvelopedHelper.CmsAuthenticatedSecureReadable(macAlg, readable);
		_recipientInfoStore = CmsEnvelopedHelper.BuildRecipientInformationStore(instance, secureReadable);
	}

	public RecipientInformationStore GetRecipientInfos()
	{
		return _recipientInfoStore;
	}

	public byte[] GetMac()
	{
		if (mac == null)
		{
			GetAuthAttrs();
			mac = authData.GetMac().GetOctets();
		}
		return Arrays.Clone(mac);
	}

	public Org.BouncyCastle.Asn1.Cms.AttributeTable GetAuthAttrs()
	{
		if (authAttrs == null && authAttrNotRead)
		{
			Asn1SetParser asn1SetParser = authData.GetAuthAttrs();
			authAttrNotRead = false;
			if (asn1SetParser != null)
			{
				authAttrs = CmsUtilities.ParseAttributeTable(asn1SetParser);
			}
		}
		return authAttrs;
	}

	public Org.BouncyCastle.Asn1.Cms.AttributeTable GetUnauthAttrs()
	{
		if (unauthAttrs == null && unauthAttrNotRead)
		{
			Asn1SetParser asn1SetParser = authData.GetUnauthAttrs();
			unauthAttrNotRead = false;
			if (asn1SetParser != null)
			{
				unauthAttrs = CmsUtilities.ParseAttributeTable(asn1SetParser);
			}
		}
		return unauthAttrs;
	}
}
