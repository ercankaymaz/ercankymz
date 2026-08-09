using System;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.X509;

namespace Org.BouncyCastle.Crmf;

public class ProofOfPossessionSigningKeyBuilder
{
	private CertRequest _certRequest;

	private SubjectPublicKeyInfo _pubKeyInfo;

	private GeneralName _name;

	private PKMacValue _publicKeyMAC;

	public ProofOfPossessionSigningKeyBuilder(CertRequest certRequest)
	{
		_certRequest = certRequest;
	}

	public ProofOfPossessionSigningKeyBuilder(SubjectPublicKeyInfo pubKeyInfo)
	{
		_pubKeyInfo = pubKeyInfo;
	}

	public ProofOfPossessionSigningKeyBuilder SetSender(GeneralName name)
	{
		_name = name;
		return this;
	}

	public ProofOfPossessionSigningKeyBuilder SetPublicKeyMac(PKMacBuilder generator, char[] password)
	{
		IMacFactory macFactory = generator.Build(password);
		return ImplSetPublicKeyMac(macFactory);
	}

	public PopoSigningKey Build(ISignatureFactory signer)
	{
		if (_name != null && _publicKeyMAC != null)
		{
			throw new InvalidOperationException("name and publicKeyMAC cannot both be set.");
		}
		PopoSigningKeyInput popoSigningKeyInput;
		Asn1Encodable asn1Encodable;
		if (_certRequest != null)
		{
			popoSigningKeyInput = null;
			asn1Encodable = _certRequest;
		}
		else if (_name != null)
		{
			popoSigningKeyInput = new PopoSigningKeyInput(_name, _pubKeyInfo);
			asn1Encodable = popoSigningKeyInput;
		}
		else
		{
			popoSigningKeyInput = new PopoSigningKeyInput(_publicKeyMAC, _pubKeyInfo);
			asn1Encodable = popoSigningKeyInput;
		}
		DerBitString signature = X509Utilities.GenerateSignature(signer, asn1Encodable);
		return new PopoSigningKey(popoSigningKeyInput, (AlgorithmIdentifier)signer.AlgorithmDetails, signature);
	}

	private ProofOfPossessionSigningKeyBuilder ImplSetPublicKeyMac(IMacFactory macFactory)
	{
		DerBitString macValue = X509Utilities.GenerateMac(macFactory, _pubKeyInfo);
		_publicKeyMAC = new PKMacValue((AlgorithmIdentifier)macFactory.AlgorithmDetails, macValue);
		return this;
	}
}
