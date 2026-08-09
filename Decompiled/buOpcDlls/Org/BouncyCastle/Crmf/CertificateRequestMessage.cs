using System;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.X509;

namespace Org.BouncyCastle.Crmf;

public class CertificateRequestMessage
{
	public static readonly int popRaVerified = 0;

	public static readonly int popSigningKey = 1;

	public static readonly int popKeyEncipherment = 2;

	public static readonly int popKeyAgreement = 3;

	private readonly CertReqMsg certReqMsg;

	private readonly Controls controls;

	public bool HasControls => controls != null;

	public bool HasProofOfPossession => certReqMsg.Popo != null;

	public int ProofOfPossession => certReqMsg.Popo.Type;

	public bool HasSigningKeyProofOfPossessionWithPkMac
	{
		get
		{
			ProofOfPossession popo = certReqMsg.Popo;
			if (popo.Type == popSigningKey)
			{
				return PopoSigningKey.GetInstance(popo.Object).PoposkInput.PublicKeyMac != null;
			}
			return false;
		}
	}

	private static CertReqMsg ParseBytes(byte[] encoding)
	{
		return CertReqMsg.GetInstance(encoding);
	}

	public CertificateRequestMessage(byte[] encoded)
		: this(CertReqMsg.GetInstance(encoded))
	{
	}

	public CertificateRequestMessage(CertReqMsg certReqMsg)
	{
		this.certReqMsg = certReqMsg;
		controls = certReqMsg.CertReq.Controls;
	}

	public CertReqMsg ToAsn1Structure()
	{
		return certReqMsg;
	}

	public CertTemplate GetCertTemplate()
	{
		return certReqMsg.CertReq.CertTemplate;
	}

	public bool HasControl(DerObjectIdentifier objectIdentifier)
	{
		return FindControl(objectIdentifier) != null;
	}

	public IControl GetControl(DerObjectIdentifier type)
	{
		AttributeTypeAndValue attributeTypeAndValue = FindControl(type);
		if (attributeTypeAndValue != null)
		{
			if (attributeTypeAndValue.Type.Equals(CrmfObjectIdentifiers.id_regCtrl_pkiArchiveOptions))
			{
				return new PkiArchiveControl(PkiArchiveOptions.GetInstance(attributeTypeAndValue.Value));
			}
			if (attributeTypeAndValue.Type.Equals(CrmfObjectIdentifiers.id_regCtrl_regToken))
			{
				return new RegTokenControl(DerUtf8String.GetInstance(attributeTypeAndValue.Value));
			}
			if (attributeTypeAndValue.Type.Equals(CrmfObjectIdentifiers.id_regCtrl_authenticator))
			{
				return new AuthenticatorControl(DerUtf8String.GetInstance(attributeTypeAndValue.Value));
			}
		}
		return null;
	}

	public AttributeTypeAndValue FindControl(DerObjectIdentifier type)
	{
		if (controls == null)
		{
			return null;
		}
		AttributeTypeAndValue[] array = controls.ToAttributeTypeAndValueArray();
		AttributeTypeAndValue result = null;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].Type.Equals(type))
			{
				result = array[i];
				break;
			}
		}
		return result;
	}

	public bool IsValidSigningKeyPop(IVerifierFactoryProvider verifierProvider)
	{
		ProofOfPossession popo = certReqMsg.Popo;
		if (popo.Type == popSigningKey)
		{
			PopoSigningKey instance = PopoSigningKey.GetInstance(popo.Object);
			if (instance.PoposkInput != null && instance.PoposkInput.PublicKeyMac != null)
			{
				throw new InvalidOperationException("verification requires password check");
			}
			return VerifySignature(verifierProvider, instance);
		}
		throw new InvalidOperationException("not Signing Key type of proof of possession");
	}

	private bool VerifySignature(IVerifierFactoryProvider verifierFactoryProvider, PopoSigningKey signKey)
	{
		IVerifierFactory verifierFactory = verifierFactoryProvider.CreateVerifierFactory(signKey.AlgorithmIdentifier);
		Asn1Encodable asn1Encodable = signKey.PoposkInput;
		if (asn1Encodable == null)
		{
			asn1Encodable = certReqMsg.CertReq;
		}
		return X509Utilities.VerifySignature(verifierFactory, asn1Encodable, signKey.Signature);
	}

	public byte[] GetEncoded()
	{
		return certReqMsg.GetEncoded();
	}
}
