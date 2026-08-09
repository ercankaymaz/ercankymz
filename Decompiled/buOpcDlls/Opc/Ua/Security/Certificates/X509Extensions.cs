using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public static class X509Extensions
{
	public static T FindExtension<T>(this X509Certificate2 certificate) where T : X509Extension
	{
		return certificate.Extensions.FindExtension<T>();
	}

	public static T FindExtension<T>(this X509ExtensionCollection extensions) where T : X509Extension
	{
		if (extensions == null)
		{
			throw new ArgumentNullException("extensions");
		}
		lock (extensions.SyncRoot)
		{
			if (typeof(T) == typeof(X509AuthorityKeyIdentifierExtension))
			{
				X509Extension x509Extension = extensions.Cast<X509Extension>().FirstOrDefault((X509Extension e) => e.Oid.Value == "2.5.29.1" || e.Oid.Value == "2.5.29.35");
				if (x509Extension != null)
				{
					return new X509AuthorityKeyIdentifierExtension(x509Extension, x509Extension.Critical) as T;
				}
			}
			if (typeof(T) == typeof(X509SubjectAltNameExtension))
			{
				X509Extension x509Extension2 = extensions.Cast<X509Extension>().FirstOrDefault((X509Extension e) => e.Oid.Value == "2.5.29.7" || e.Oid.Value == "2.5.29.17");
				if (x509Extension2 != null)
				{
					return new X509SubjectAltNameExtension(x509Extension2, x509Extension2.Critical) as T;
				}
			}
			if (typeof(T) == typeof(X509CrlNumberExtension))
			{
				X509Extension x509Extension3 = extensions.Cast<X509Extension>().FirstOrDefault((X509Extension e) => e.Oid.Value == "2.5.29.20");
				if (x509Extension3 != null)
				{
					return new X509CrlNumberExtension(x509Extension3, x509Extension3.Critical) as T;
				}
			}
			return extensions.OfType<T>().FirstOrDefault();
		}
	}

	public static X509Extension BuildX509AuthorityInformationAccess(string[] caIssuerUrls, string ocspResponder = null)
	{
		if (string.IsNullOrEmpty(ocspResponder) && (caIssuerUrls == null || caIssuerUrls.Length == 0))
		{
			throw new ArgumentNullException("caIssuerUrls", "One CA Issuer Url or OCSP responder is required for the extension.");
		}
		Asn1Tag value = new Asn1Tag(TagClass.ContextSpecific, 6);
		AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
		asnWriter.PushSequence();
		if (caIssuerUrls != null)
		{
			foreach (string value2 in caIssuerUrls)
			{
				asnWriter.PushSequence();
				asnWriter.WriteObjectIdentifier("1.3.6.1.5.5.7.48.2");
				asnWriter.WriteCharacterString(UniversalTagNumber.IA5String, value2, value);
				asnWriter.PopSequence();
			}
		}
		if (!string.IsNullOrEmpty(ocspResponder))
		{
			asnWriter.PushSequence();
			asnWriter.WriteObjectIdentifier("1.3.6.1.5.5.7.48.1");
			asnWriter.WriteCharacterString(UniversalTagNumber.IA5String, ocspResponder, value);
			asnWriter.PopSequence();
		}
		asnWriter.PopSequence();
		return new X509Extension("1.3.6.1.5.5.7.1.1", asnWriter.Encode(), critical: false);
	}

	public static X509Extension BuildX509CRLDistributionPoints(string distributionPoint)
	{
		return BuildX509CRLDistributionPoints(new string[1] { distributionPoint });
	}

	public static X509Extension BuildX509CRLDistributionPoints(IEnumerable<string> distributionPoints)
	{
		Asn1Tag value2;
		Asn1Tag value = (value2 = new Asn1Tag(TagClass.ContextSpecific, 0, isConstructed: true));
		Asn1Tag value3 = new Asn1Tag(TagClass.ContextSpecific, 6);
		AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
		asnWriter.PushSequence();
		asnWriter.PushSequence();
		asnWriter.PushSequence(value2);
		asnWriter.PushSequence(value);
		foreach (string distributionPoint in distributionPoints)
		{
			asnWriter.WriteCharacterString(UniversalTagNumber.IA5String, distributionPoint, value3);
		}
		asnWriter.PopSequence(value);
		asnWriter.PopSequence(value2);
		asnWriter.PopSequence();
		asnWriter.PopSequence();
		return new X509Extension("2.5.29.31", asnWriter.Encode(), critical: false);
	}

	public static X509Extension ReadExtension(this AsnReader reader)
	{
		if (reader.HasData)
		{
			Asn1Tag asn1Tag = new Asn1Tag(UniversalTagNumber.Boolean);
			AsnReader asnReader = reader.ReadSequence();
			string oid = asnReader.ReadObjectIdentifier();
			bool critical = false;
			if (asnReader.PeekTag() == asn1Tag)
			{
				critical = asnReader.ReadBoolean();
			}
			byte[] rawData = asnReader.ReadOctetString();
			asnReader.ThrowIfNotEmpty();
			return new X509Extension(new Oid(oid), rawData, critical);
		}
		return null;
	}

	public static void WriteExtension(this AsnWriter writer, X509Extension extension)
	{
		Asn1Tag sequence = Asn1Tag.Sequence;
		writer.PushSequence(sequence);
		writer.WriteObjectIdentifier(extension.Oid.Value);
		if (extension.Critical)
		{
			writer.WriteBoolean(extension.Critical);
		}
		writer.WriteOctetString(extension.RawData);
		writer.PopSequence(sequence);
	}

	public static X509Extension BuildX509CRLReason(CRLReason reason)
	{
		AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
		asnWriter.WriteEnumeratedValue(reason);
		return new X509Extension("2.5.29.21", asnWriter.Encode(), critical: false);
	}

	public static X509Extension BuildAuthorityKeyIdentifier(X509Certificate2 issuerCaCertificate)
	{
		return new X509AuthorityKeyIdentifierExtension(issuerCaCertificate.Extensions.OfType<X509SubjectKeyIdentifierExtension>().Single().SubjectKeyIdentifier.FromHexString(), issuerCaCertificate.IssuerName, issuerCaCertificate.GetSerialNumber());
	}

	public static X509Extension BuildCRLNumber(BigInteger crlNumber)
	{
		AsnWriter asnWriter = new AsnWriter(AsnEncodingRules.DER);
		asnWriter.WriteInteger(crlNumber);
		return new X509Extension("2.5.29.20", asnWriter.Encode(), critical: false);
	}

	public static string PatchExtensionUrl(string extensionUrl, byte[] serialNumber)
	{
		return PatchExtensionUrl(extensionUrl, serialNumber.ToHexString());
	}

	public static string PatchExtensionUrl(string extensionUrl, string serial)
	{
		return extensionUrl.Replace("%serial%", serial.ToLower());
	}
}
