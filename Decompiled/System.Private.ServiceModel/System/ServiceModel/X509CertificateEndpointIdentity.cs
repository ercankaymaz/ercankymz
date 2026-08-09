using System.IdentityModel.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace System.ServiceModel;

public class X509CertificateEndpointIdentity : EndpointIdentity
{
	public X509Certificate2Collection Certificates { get; } = new X509Certificate2Collection();

	public X509CertificateEndpointIdentity(X509Certificate2 certificate)
	{
		if (certificate == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("certificate");
		}
		Initialize(new Claim(ClaimTypes.Thumbprint, certificate.GetCertHash(), Rights.PossessProperty));
		Certificates.Add(certificate);
	}

	public X509CertificateEndpointIdentity(X509Certificate2 primaryCertificate, X509Certificate2Collection supportingCertificates)
	{
		if (primaryCertificate == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("primaryCertificate");
		}
		if (supportingCertificates == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("supportingCertificates");
		}
		Initialize(new Claim(ClaimTypes.Thumbprint, primaryCertificate.GetCertHash(), Rights.PossessProperty));
		Certificates.Add(primaryCertificate);
		for (int i = 0; i < supportingCertificates.Count; i++)
		{
			Certificates.Add(supportingCertificates[i]);
		}
	}

	internal X509CertificateEndpointIdentity(XmlDictionaryReader reader)
	{
		if (reader == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
		}
		reader.MoveToContent();
		if (reader.IsEmptyElement)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnexpectedEmptyElementExpectingClaim, XD.AddressingDictionary.X509v3Certificate.Value, XD.AddressingDictionary.IdentityExtensionNamespace.Value)));
		}
		reader.ReadStartElement(XD.XmlSignatureDictionary.X509Data, XD.XmlSignatureDictionary.Namespace);
		while (reader.IsStartElement(XD.XmlSignatureDictionary.X509Certificate, XD.XmlSignatureDictionary.Namespace))
		{
			reader.MoveToContent();
			X509Certificate2 x509Certificate = new X509Certificate2(Convert.FromBase64String(reader.ReadContentAsString()));
			if (Certificates.Count == 0)
			{
				Initialize(new Claim(ClaimTypes.Thumbprint, x509Certificate.GetCertHash(), Rights.PossessProperty));
			}
			Certificates.Add(x509Certificate);
		}
		reader.ReadEndElement();
		if (Certificates.Count == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnexpectedEmptyElementExpectingClaim, XD.AddressingDictionary.X509v3Certificate.Value, XD.AddressingDictionary.IdentityExtensionNamespace.Value)));
		}
	}

	internal override void WriteContentsTo(XmlDictionaryWriter writer)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
		}
		writer.WriteStartElement(XD.XmlSignatureDictionary.Prefix.Value, XD.XmlSignatureDictionary.KeyInfo, XD.XmlSignatureDictionary.Namespace);
		writer.WriteStartElement(XD.XmlSignatureDictionary.Prefix.Value, XD.XmlSignatureDictionary.X509Data, XD.XmlSignatureDictionary.Namespace);
		for (int i = 0; i < Certificates.Count; i++)
		{
			writer.WriteElementString(XD.XmlSignatureDictionary.X509Certificate, XD.XmlSignatureDictionary.Namespace, Convert.ToBase64String(Certificates[i].RawData));
		}
		writer.WriteEndElement();
		writer.WriteEndElement();
	}
}
