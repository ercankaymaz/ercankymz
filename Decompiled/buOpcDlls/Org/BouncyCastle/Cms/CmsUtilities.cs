using System;
using System.Collections.Generic;
using System.IO;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.Utilities.IO;
using Org.BouncyCastle.X509;

namespace Org.BouncyCastle.Cms;

internal static class CmsUtilities
{
	internal static int MaximumMemory
	{
		get
		{
			long num = 2147483647L;
			if (num > int.MaxValue)
			{
				return int.MaxValue;
			}
			return (int)num;
		}
	}

	internal static ContentInfo ReadContentInfo(byte[] input)
	{
		using Asn1InputStream asn1In = new Asn1InputStream(input);
		return ReadContentInfo(asn1In);
	}

	internal static ContentInfo ReadContentInfo(Stream input)
	{
		using Asn1InputStream asn1In = new Asn1InputStream(input, MaximumMemory, leaveOpen: true);
		return ReadContentInfo(asn1In);
	}

	private static ContentInfo ReadContentInfo(Asn1InputStream asn1In)
	{
		try
		{
			return ContentInfo.GetInstance(asn1In.ReadObject());
		}
		catch (IOException innerException)
		{
			throw new CmsException("IOException reading content.", innerException);
		}
		catch (InvalidCastException innerException2)
		{
			throw new CmsException("Malformed content.", innerException2);
		}
		catch (ArgumentException innerException3)
		{
			throw new CmsException("Malformed content.", innerException3);
		}
	}

	internal static byte[] StreamToByteArray(Stream inStream)
	{
		return Streams.ReadAll(inStream);
	}

	internal static byte[] StreamToByteArray(Stream inStream, int limit)
	{
		return Streams.ReadAllLimited(inStream, limit);
	}

	internal static List<Asn1TaggedObject> GetAttributeCertificatesFromStore(IStore<X509V2AttributeCertificate> attrCertStore)
	{
		List<Asn1TaggedObject> list = new List<Asn1TaggedObject>();
		if (attrCertStore != null)
		{
			foreach (X509V2AttributeCertificate item in attrCertStore.EnumerateMatches(null))
			{
				list.Add(new DerTaggedObject(isExplicit: false, 2, item.AttributeCertificate));
			}
		}
		return list;
	}

	internal static List<X509CertificateStructure> GetCertificatesFromStore(IStore<X509Certificate> certStore)
	{
		List<X509CertificateStructure> list = new List<X509CertificateStructure>();
		if (certStore != null)
		{
			foreach (X509Certificate item in certStore.EnumerateMatches(null))
			{
				list.Add(item.CertificateStructure);
			}
		}
		return list;
	}

	internal static List<CertificateList> GetCrlsFromStore(IStore<X509Crl> crlStore)
	{
		List<CertificateList> list = new List<CertificateList>();
		if (crlStore != null)
		{
			foreach (X509Crl item in crlStore.EnumerateMatches(null))
			{
				list.Add(item.CertificateList);
			}
		}
		return list;
	}

	internal static List<Asn1TaggedObject> GetOtherRevocationInfosFromStore(IStore<OtherRevocationInfoFormat> otherRevocationInfoStore)
	{
		List<Asn1TaggedObject> list = new List<Asn1TaggedObject>();
		if (otherRevocationInfoStore != null)
		{
			foreach (OtherRevocationInfoFormat item in otherRevocationInfoStore.EnumerateMatches(null))
			{
				ValidateOtherRevocationInfo(item);
				list.Add(new DerTaggedObject(isExplicit: false, 1, item));
			}
		}
		return list;
	}

	internal static List<DerTaggedObject> GetOtherRevocationInfosFromStore(IStore<Asn1Encodable> otherRevInfoStore, DerObjectIdentifier otherRevInfoFormat)
	{
		List<DerTaggedObject> list = new List<DerTaggedObject>();
		if (otherRevInfoStore != null && otherRevInfoFormat != null)
		{
			foreach (Asn1Encodable item in otherRevInfoStore.EnumerateMatches(null))
			{
				OtherRevocationInfoFormat otherRevocationInfoFormat = new OtherRevocationInfoFormat(otherRevInfoFormat, item);
				ValidateOtherRevocationInfo(otherRevocationInfoFormat);
				list.Add(new DerTaggedObject(isExplicit: false, 1, otherRevocationInfoFormat));
			}
		}
		return list;
	}

	internal static Asn1Set CreateBerSetFromList(IEnumerable<Asn1Encodable> elements)
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector();
		foreach (Asn1Encodable element in elements)
		{
			asn1EncodableVector.Add(element);
		}
		return BerSet.FromVector(asn1EncodableVector);
	}

	internal static Asn1Set CreateDerSetFromList(IEnumerable<Asn1Encodable> elements)
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector();
		foreach (Asn1Encodable element in elements)
		{
			asn1EncodableVector.Add(element);
		}
		return DerSet.FromVector(asn1EncodableVector);
	}

	internal static TbsCertificateStructure GetTbsCertificateStructure(X509Certificate cert)
	{
		return cert.CertificateStructure.TbsCertificate;
	}

	internal static IssuerAndSerialNumber GetIssuerAndSerialNumber(X509Certificate cert)
	{
		TbsCertificateStructure tbsCertificateStructure = GetTbsCertificateStructure(cert);
		return new IssuerAndSerialNumber(tbsCertificateStructure.Issuer, tbsCertificateStructure.SerialNumber.Value);
	}

	internal static Org.BouncyCastle.Asn1.Cms.AttributeTable ParseAttributeTable(Asn1SetParser parser)
	{
		Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector();
		IAsn1Convertible asn1Convertible;
		while ((asn1Convertible = parser.ReadObject()) != null)
		{
			Asn1SequenceParser asn1SequenceParser = (Asn1SequenceParser)asn1Convertible;
			asn1EncodableVector.Add(asn1SequenceParser.ToAsn1Object());
		}
		return new Org.BouncyCastle.Asn1.Cms.AttributeTable(new DerSet(asn1EncodableVector));
	}

	internal static void ValidateOtherRevocationInfo(OtherRevocationInfoFormat otherRevocationInfo)
	{
		if (CmsObjectIdentifiers.id_ri_ocsp_response.Equals(otherRevocationInfo.InfoFormat))
		{
			OcspResponse instance = OcspResponse.GetInstance(otherRevocationInfo.Info);
			if (instance.ResponseStatus.IntValueExact != 0)
			{
				throw new ArgumentException("cannot add unsuccessful OCSP response to CMS SignedData");
			}
		}
	}
}
