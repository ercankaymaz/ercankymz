using System;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;

namespace Org.BouncyCastle.X509;

public class X509V2AttributeCertificateGenerator
{
	private readonly X509ExtensionsGenerator extGenerator = new X509ExtensionsGenerator();

	private V2AttributeCertificateInfoGenerator acInfoGen;

	public IEnumerable<string> SignatureAlgNames => X509Utilities.GetAlgNames();

	public X509V2AttributeCertificateGenerator()
	{
		acInfoGen = new V2AttributeCertificateInfoGenerator();
	}

	public void Reset()
	{
		acInfoGen = new V2AttributeCertificateInfoGenerator();
		extGenerator.Reset();
	}

	public void SetHolder(AttributeCertificateHolder holder)
	{
		acInfoGen.SetHolder(holder.holder);
	}

	public void SetIssuer(AttributeCertificateIssuer issuer)
	{
		acInfoGen.SetIssuer(AttCertIssuer.GetInstance(issuer.form));
	}

	public void SetSerialNumber(BigInteger serialNumber)
	{
		acInfoGen.SetSerialNumber(new DerInteger(serialNumber));
	}

	public void SetNotBefore(DateTime date)
	{
		acInfoGen.SetStartDate(new Asn1GeneralizedTime(date));
	}

	public void SetNotAfter(DateTime date)
	{
		acInfoGen.SetEndDate(new Asn1GeneralizedTime(date));
	}

	public void AddAttribute(X509Attribute attribute)
	{
		acInfoGen.AddAttribute(AttributeX509.GetInstance(attribute.ToAsn1Object()));
	}

	public void SetIssuerUniqueId(bool[] iui)
	{
		throw new NotImplementedException("SetIssuerUniqueId()");
	}

	public void AddExtension(string oid, bool critical, Asn1Encodable extensionValue)
	{
		extGenerator.AddExtension(new DerObjectIdentifier(oid), critical, extensionValue);
	}

	public void AddExtension(string oid, bool critical, byte[] extensionValue)
	{
		extGenerator.AddExtension(new DerObjectIdentifier(oid), critical, extensionValue);
	}

	public X509V2AttributeCertificate Generate(ISignatureFactory signatureFactory)
	{
		AlgorithmIdentifier algorithmIdentifier = (AlgorithmIdentifier)signatureFactory.AlgorithmDetails;
		acInfoGen.SetSignature(algorithmIdentifier);
		if (!extGenerator.IsEmpty)
		{
			acInfoGen.SetExtensions(extGenerator.Generate());
		}
		AttributeCertificateInfo attributeCertificateInfo = acInfoGen.GenerateAttributeCertificateInfo();
		DerBitString signatureValue = X509Utilities.GenerateSignature(signatureFactory, attributeCertificateInfo);
		return new X509V2AttributeCertificate(new AttributeCertificate(attributeCertificateInfo, algorithmIdentifier, signatureValue));
	}
}
