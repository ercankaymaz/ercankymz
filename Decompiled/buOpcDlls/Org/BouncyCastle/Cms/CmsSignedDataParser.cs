using System;
using System.Collections.Generic;
using System.IO;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.Utilities.IO;
using Org.BouncyCastle.X509;

namespace Org.BouncyCastle.Cms;

public class CmsSignedDataParser : CmsContentInfoParser
{
	private static readonly CmsSignedHelper Helper = CmsSignedHelper.Instance;

	private SignedDataParser _signedData;

	private DerObjectIdentifier _signedContentType;

	private CmsTypedStream _signedContent;

	private IDictionary<string, IDigest> m_digests;

	private HashSet<string> _digestOids;

	private SignerInformationStore _signerInfoStore;

	private Asn1Set _certSet;

	private Asn1Set _crlSet;

	private bool _isCertCrlParsed;

	public int Version => _signedData.Version.IntValueExact;

	public ISet<string> DigestOids => new HashSet<string>(_digestOids);

	public DerObjectIdentifier SignedContentType => _signedContentType;

	public CmsSignedDataParser(byte[] sigBlock)
		: this(new MemoryStream(sigBlock, writable: false))
	{
	}

	public CmsSignedDataParser(CmsTypedStream signedContent, byte[] sigBlock)
		: this(signedContent, new MemoryStream(sigBlock, writable: false))
	{
	}

	public CmsSignedDataParser(Stream sigData)
		: this(null, sigData)
	{
	}

	public CmsSignedDataParser(CmsTypedStream signedContent, Stream sigData)
		: base(sigData)
	{
		try
		{
			_signedContent = signedContent;
			_signedData = SignedDataParser.GetInstance(contentInfo.GetContent(16));
			m_digests = new Dictionary<string, IDigest>(StringComparer.OrdinalIgnoreCase);
			_digestOids = new HashSet<string>();
			Asn1SetParser digestAlgorithms = _signedData.GetDigestAlgorithms();
			IAsn1Convertible asn1Convertible;
			while ((asn1Convertible = digestAlgorithms.ReadObject()) != null)
			{
				AlgorithmIdentifier instance = AlgorithmIdentifier.GetInstance(asn1Convertible.ToAsn1Object());
				try
				{
					string id = instance.Algorithm.Id;
					string digestAlgName = Helper.GetDigestAlgName(id);
					if (!m_digests.ContainsKey(digestAlgName))
					{
						m_digests[digestAlgName] = Helper.GetDigestInstance(digestAlgName);
						_digestOids.Add(id);
					}
				}
				catch (SecurityUtilityException)
				{
				}
			}
			ContentInfoParser encapContentInfo = _signedData.GetEncapContentInfo();
			Asn1OctetStringParser asn1OctetStringParser = (Asn1OctetStringParser)encapContentInfo.GetContent(4);
			if (asn1OctetStringParser != null)
			{
				CmsTypedStream cmsTypedStream = new CmsTypedStream(encapContentInfo.ContentType.Id, asn1OctetStringParser.GetOctetStream());
				if (_signedContent == null)
				{
					_signedContent = cmsTypedStream;
				}
				else
				{
					cmsTypedStream.Drain();
				}
			}
			_signedContentType = ((_signedContent == null) ? encapContentInfo.ContentType : new DerObjectIdentifier(_signedContent.ContentType));
		}
		catch (IOException ex2)
		{
			throw new CmsException("io exception: " + ex2.Message, ex2);
		}
	}

	public SignerInformationStore GetSignerInfos()
	{
		if (_signerInfoStore == null)
		{
			PopulateCertCrlSets();
			List<SignerInformation> list = new List<SignerInformation>();
			Dictionary<string, byte[]> dictionary = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
			foreach (KeyValuePair<string, IDigest> digest in m_digests)
			{
				dictionary[digest.Key] = DigestUtilities.DoFinal(digest.Value);
			}
			try
			{
				Asn1SetParser signerInfos = _signedData.GetSignerInfos();
				IAsn1Convertible asn1Convertible;
				while ((asn1Convertible = signerInfos.ReadObject()) != null)
				{
					SignerInfo instance = SignerInfo.GetInstance(asn1Convertible.ToAsn1Object());
					string digestAlgName = Helper.GetDigestAlgName(instance.DigestAlgorithm.Algorithm.Id);
					byte[] calculatedDigest = dictionary[digestAlgName];
					list.Add(new SignerInformation(instance, _signedContentType, null, calculatedDigest));
				}
			}
			catch (IOException ex)
			{
				throw new CmsException("io exception: " + ex.Message, ex);
			}
			_signerInfoStore = new SignerInformationStore(list);
		}
		return _signerInfoStore;
	}

	public IStore<X509V2AttributeCertificate> GetAttributeCertificates()
	{
		PopulateCertCrlSets();
		return Helper.GetAttributeCertificates(_certSet);
	}

	public IStore<X509Certificate> GetCertificates()
	{
		PopulateCertCrlSets();
		return Helper.GetCertificates(_certSet);
	}

	public IStore<X509Crl> GetCrls()
	{
		PopulateCertCrlSets();
		return Helper.GetCrls(_crlSet);
	}

	public IStore<Asn1Encodable> GetOtherRevInfos(DerObjectIdentifier otherRevInfoFormat)
	{
		PopulateCertCrlSets();
		return Helper.GetOtherRevInfos(_crlSet, otherRevInfoFormat);
	}

	private void PopulateCertCrlSets()
	{
		if (_isCertCrlParsed)
		{
			return;
		}
		_isCertCrlParsed = true;
		try
		{
			_certSet = GetAsn1Set(_signedData.GetCertificates());
			_crlSet = GetAsn1Set(_signedData.GetCrls());
		}
		catch (IOException innerException)
		{
			throw new CmsException("problem parsing cert/crl sets", innerException);
		}
	}

	public CmsTypedStream GetSignedContent()
	{
		if (_signedContent == null)
		{
			return null;
		}
		Stream stream = _signedContent.ContentStream;
		foreach (IDigest value in m_digests.Values)
		{
			stream = new DigestStream(stream, value, null);
		}
		return new CmsTypedStream(_signedContent.ContentType, stream);
	}

	public static Stream ReplaceSigners(Stream original, SignerInformationStore signerInformationStore, Stream outStr)
	{
		CmsSignedDataStreamGenerator cmsSignedDataStreamGenerator = new CmsSignedDataStreamGenerator();
		CmsSignedDataParser cmsSignedDataParser = new CmsSignedDataParser(original);
		cmsSignedDataStreamGenerator.AddSigners(signerInformationStore);
		CmsTypedStream signedContent = cmsSignedDataParser.GetSignedContent();
		bool flag = signedContent != null;
		Stream stream = cmsSignedDataStreamGenerator.Open(outStr, cmsSignedDataParser.SignedContentType.Id, flag);
		if (flag)
		{
			Streams.PipeAll(signedContent.ContentStream, stream);
		}
		cmsSignedDataStreamGenerator.AddAttributeCertificates(cmsSignedDataParser.GetAttributeCertificates());
		cmsSignedDataStreamGenerator.AddCertificates(cmsSignedDataParser.GetCertificates());
		cmsSignedDataStreamGenerator.AddCrls(cmsSignedDataParser.GetCrls());
		stream.Dispose();
		return outStr;
	}

	public static Stream ReplaceCertificatesAndCrls(Stream original, IStore<X509Certificate> x509Certs, IStore<X509Crl> x509Crls, IStore<X509V2AttributeCertificate> x509AttrCerts, Stream outStr)
	{
		CmsSignedDataStreamGenerator cmsSignedDataStreamGenerator = new CmsSignedDataStreamGenerator();
		CmsSignedDataParser cmsSignedDataParser = new CmsSignedDataParser(original);
		cmsSignedDataStreamGenerator.AddDigests(cmsSignedDataParser.DigestOids);
		CmsTypedStream signedContent = cmsSignedDataParser.GetSignedContent();
		bool flag = signedContent != null;
		Stream stream = cmsSignedDataStreamGenerator.Open(outStr, cmsSignedDataParser.SignedContentType.Id, flag);
		if (flag)
		{
			Streams.PipeAll(signedContent.ContentStream, stream);
		}
		if (x509AttrCerts != null)
		{
			cmsSignedDataStreamGenerator.AddAttributeCertificates(x509AttrCerts);
		}
		if (x509Certs != null)
		{
			cmsSignedDataStreamGenerator.AddCertificates(x509Certs);
		}
		if (x509Crls != null)
		{
			cmsSignedDataStreamGenerator.AddCrls(x509Crls);
		}
		cmsSignedDataStreamGenerator.AddSigners(cmsSignedDataParser.GetSignerInfos());
		stream.Dispose();
		return outStr;
	}

	private static Asn1Set GetAsn1Set(Asn1SetParser asn1SetParser)
	{
		if (asn1SetParser != null)
		{
			return Asn1Set.GetInstance(asn1SetParser.ToAsn1Object());
		}
		return null;
	}
}
