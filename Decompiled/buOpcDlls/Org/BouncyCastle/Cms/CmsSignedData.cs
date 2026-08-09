using System;
using System.Collections.Generic;
using System.IO;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;

namespace Org.BouncyCastle.Cms;

public class CmsSignedData
{
	private static readonly CmsSignedHelper Helper = CmsSignedHelper.Instance;

	private readonly CmsProcessable signedContent;

	private SignedData signedData;

	private ContentInfo contentInfo;

	private SignerInformationStore signerInfoStore;

	private IDictionary<string, byte[]> m_hashes;

	public int Version => signedData.Version.IntValueExact;

	public DerObjectIdentifier SignedContentType => signedData.EncapContentInfo.ContentType;

	public CmsProcessable SignedContent => signedContent;

	public ContentInfo ContentInfo => contentInfo;

	private CmsSignedData(CmsSignedData c)
	{
		signedData = c.signedData;
		contentInfo = c.contentInfo;
		signedContent = c.signedContent;
		signerInfoStore = c.signerInfoStore;
	}

	public CmsSignedData(byte[] sigBlock)
		: this(CmsUtilities.ReadContentInfo(new MemoryStream(sigBlock, writable: false)))
	{
	}

	public CmsSignedData(CmsProcessable signedContent, byte[] sigBlock)
		: this(signedContent, CmsUtilities.ReadContentInfo(new MemoryStream(sigBlock, writable: false)))
	{
	}

	public CmsSignedData(IDictionary<string, byte[]> hashes, byte[] sigBlock)
		: this(hashes, CmsUtilities.ReadContentInfo(sigBlock))
	{
	}

	public CmsSignedData(CmsProcessable signedContent, Stream sigData)
		: this(signedContent, CmsUtilities.ReadContentInfo(sigData))
	{
	}

	public CmsSignedData(Stream sigData)
		: this(CmsUtilities.ReadContentInfo(sigData))
	{
	}

	public CmsSignedData(CmsProcessable signedContent, ContentInfo sigData)
	{
		this.signedContent = signedContent;
		contentInfo = sigData;
		signedData = SignedData.GetInstance(contentInfo.Content);
	}

	public CmsSignedData(IDictionary<string, byte[]> hashes, ContentInfo sigData)
	{
		m_hashes = hashes;
		contentInfo = sigData;
		signedData = SignedData.GetInstance(contentInfo.Content);
	}

	public CmsSignedData(ContentInfo sigData)
	{
		contentInfo = sigData;
		signedData = SignedData.GetInstance(contentInfo.Content);
		if (signedData.EncapContentInfo.Content != null)
		{
			signedContent = new CmsProcessableByteArray(((Asn1OctetString)signedData.EncapContentInfo.Content).GetOctets());
		}
	}

	public SignerInformationStore GetSignerInfos()
	{
		if (signerInfoStore == null)
		{
			List<SignerInformation> list = new List<SignerInformation>();
			foreach (Asn1Encodable signerInfo in signedData.SignerInfos)
			{
				SignerInfo instance = SignerInfo.GetInstance(signerInfo);
				DerObjectIdentifier contentType = signedData.EncapContentInfo.ContentType;
				if (m_hashes == null)
				{
					list.Add(new SignerInformation(instance, contentType, signedContent, null));
					continue;
				}
				if (m_hashes.TryGetValue(instance.DigestAlgorithm.Algorithm.Id, out var value))
				{
					list.Add(new SignerInformation(instance, contentType, null, value));
					continue;
				}
				throw new InvalidOperationException();
			}
			signerInfoStore = new SignerInformationStore(list);
		}
		return signerInfoStore;
	}

	public IStore<X509V2AttributeCertificate> GetAttributeCertificates()
	{
		return Helper.GetAttributeCertificates(signedData.Certificates);
	}

	public IStore<X509Certificate> GetCertificates()
	{
		return Helper.GetCertificates(signedData.Certificates);
	}

	public IStore<X509Crl> GetCrls()
	{
		return Helper.GetCrls(signedData.CRLs);
	}

	public IStore<Asn1Encodable> GetOtherRevInfos(DerObjectIdentifier otherRevInfoFormat)
	{
		return Helper.GetOtherRevInfos(signedData.CRLs, otherRevInfoFormat);
	}

	public byte[] GetEncoded()
	{
		return contentInfo.GetEncoded();
	}

	public byte[] GetEncoded(string encoding)
	{
		return contentInfo.GetEncoded(encoding);
	}

	public static CmsSignedData ReplaceSigners(CmsSignedData signedData, SignerInformationStore signerInformationStore)
	{
		CmsSignedData cmsSignedData = new CmsSignedData(signedData);
		cmsSignedData.signerInfoStore = signerInformationStore;
		IList<SignerInformation> signers = signerInformationStore.GetSigners();
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector(signers.Count);
		Asn1EncodableVector asn1EncodableVector2 = new Asn1EncodableVector(signers.Count);
		foreach (SignerInformation item in signers)
		{
			asn1EncodableVector.Add(Helper.FixAlgID(item.DigestAlgorithmID));
			asn1EncodableVector2.Add(item.ToSignerInfo());
		}
		Asn1Set element = new DerSet(asn1EncodableVector);
		Asn1Set element2 = new DerSet(asn1EncodableVector2);
		Asn1Sequence asn1Sequence = (Asn1Sequence)signedData.signedData.ToAsn1Object();
		asn1EncodableVector2 = new Asn1EncodableVector(asn1Sequence.Count);
		asn1EncodableVector2.Add(asn1Sequence[0]);
		asn1EncodableVector2.Add(element);
		for (int i = 2; i != asn1Sequence.Count - 1; i++)
		{
			asn1EncodableVector2.Add(asn1Sequence[i]);
		}
		asn1EncodableVector2.Add(element2);
		cmsSignedData.signedData = SignedData.GetInstance(new BerSequence(asn1EncodableVector2));
		cmsSignedData.contentInfo = new ContentInfo(cmsSignedData.contentInfo.ContentType, cmsSignedData.signedData);
		return cmsSignedData;
	}

	public static CmsSignedData ReplaceCertificatesAndCrls(CmsSignedData signedData, IStore<X509Certificate> x509Certs, IStore<X509Crl> x509Crls)
	{
		return ReplaceCertificatesAndRevocations(signedData, x509Certs, x509Crls, null, null);
	}

	public static CmsSignedData ReplaceCertificatesAndCrls(CmsSignedData signedData, IStore<X509Certificate> x509Certs, IStore<X509Crl> x509Crls, IStore<X509V2AttributeCertificate> x509AttrCerts)
	{
		return ReplaceCertificatesAndRevocations(signedData, x509Certs, x509Crls, x509AttrCerts, null);
	}

	public static CmsSignedData ReplaceCertificatesAndRevocations(CmsSignedData signedData, IStore<X509Certificate> x509Certs, IStore<X509Crl> x509Crls, IStore<X509V2AttributeCertificate> x509AttrCerts, IStore<OtherRevocationInfoFormat> otherRevocationInfos)
	{
		CmsSignedData cmsSignedData = new CmsSignedData(signedData);
		Asn1Set certificates = null;
		Asn1Set crls = null;
		if (x509Certs != null || x509AttrCerts != null)
		{
			List<Asn1Encodable> list = new List<Asn1Encodable>();
			if (x509Certs != null)
			{
				list.AddRange(CmsUtilities.GetCertificatesFromStore(x509Certs));
			}
			if (x509AttrCerts != null)
			{
				list.AddRange(CmsUtilities.GetAttributeCertificatesFromStore(x509AttrCerts));
			}
			Asn1Set asn1Set = CmsUtilities.CreateBerSetFromList(list);
			if (asn1Set.Count > 0)
			{
				certificates = asn1Set;
			}
		}
		if (x509Crls != null || otherRevocationInfos != null)
		{
			List<Asn1Encodable> list2 = new List<Asn1Encodable>();
			if (x509Crls != null)
			{
				list2.AddRange(CmsUtilities.GetCrlsFromStore(x509Crls));
			}
			if (otherRevocationInfos != null)
			{
				list2.AddRange(CmsUtilities.GetOtherRevocationInfosFromStore(otherRevocationInfos));
			}
			Asn1Set asn1Set2 = CmsUtilities.CreateBerSetFromList(list2);
			if (asn1Set2.Count > 0)
			{
				crls = asn1Set2;
			}
		}
		SignedData signedData2 = signedData.signedData;
		cmsSignedData.signedData = new SignedData(signedData2.DigestAlgorithms, signedData2.EncapContentInfo, certificates, crls, signedData2.SignerInfos);
		cmsSignedData.contentInfo = new ContentInfo(cmsSignedData.contentInfo.ContentType, cmsSignedData.signedData);
		return cmsSignedData;
	}
}
