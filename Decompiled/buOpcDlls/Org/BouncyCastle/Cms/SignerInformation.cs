using System;
using System.Collections.Generic;
using System.IO;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;

namespace Org.BouncyCastle.Cms;

public class SignerInformation
{
	private static readonly CmsSignedHelper Helper = CmsSignedHelper.Instance;

	private SignerID sid;

	private CmsProcessable content;

	private byte[] signature;

	private DerObjectIdentifier contentType;

	private byte[] calculatedDigest;

	private byte[] resultDigest;

	private Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttributeTable;

	private Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttributeTable;

	private readonly bool isCounterSignature;

	protected Org.BouncyCastle.Asn1.Cms.SignerInfo info;

	protected AlgorithmIdentifier digestAlgorithm;

	protected AlgorithmIdentifier encryptionAlgorithm;

	protected readonly Asn1Set signedAttributeSet;

	protected readonly Asn1Set unsignedAttributeSet;

	public bool IsCounterSignature => isCounterSignature;

	public DerObjectIdentifier ContentType => contentType;

	public SignerID SignerID => sid;

	public int Version => info.Version.IntValueExact;

	public AlgorithmIdentifier DigestAlgorithmID => digestAlgorithm;

	public string DigestAlgOid => digestAlgorithm.Algorithm.Id;

	public Asn1Object DigestAlgParams => digestAlgorithm.Parameters?.ToAsn1Object();

	public AlgorithmIdentifier EncryptionAlgorithmID => encryptionAlgorithm;

	public string EncryptionAlgOid => encryptionAlgorithm.Algorithm.Id;

	public Asn1Object EncryptionAlgParams => encryptionAlgorithm.Parameters?.ToAsn1Object();

	public Org.BouncyCastle.Asn1.Cms.AttributeTable SignedAttributes
	{
		get
		{
			if (signedAttributeSet != null && signedAttributeTable == null)
			{
				signedAttributeTable = new Org.BouncyCastle.Asn1.Cms.AttributeTable(signedAttributeSet);
			}
			return signedAttributeTable;
		}
	}

	public Org.BouncyCastle.Asn1.Cms.AttributeTable UnsignedAttributes
	{
		get
		{
			if (unsignedAttributeSet != null && unsignedAttributeTable == null)
			{
				unsignedAttributeTable = new Org.BouncyCastle.Asn1.Cms.AttributeTable(unsignedAttributeSet);
			}
			return unsignedAttributeTable;
		}
	}

	internal SignerInformation(Org.BouncyCastle.Asn1.Cms.SignerInfo info, DerObjectIdentifier contentType, CmsProcessable content, byte[] calculatedDigest)
	{
		this.info = info;
		sid = new SignerID();
		this.contentType = contentType;
		isCounterSignature = contentType == null;
		try
		{
			SignerIdentifier signerID = info.SignerID;
			if (signerID.IsTagged)
			{
				Asn1OctetString instance = Asn1OctetString.GetInstance(signerID.ID);
				sid.SubjectKeyIdentifier = instance.GetEncoded();
			}
			else
			{
				Org.BouncyCastle.Asn1.Cms.IssuerAndSerialNumber instance2 = Org.BouncyCastle.Asn1.Cms.IssuerAndSerialNumber.GetInstance(signerID.ID);
				sid.Issuer = instance2.Name;
				sid.SerialNumber = instance2.SerialNumber.Value;
			}
		}
		catch (IOException)
		{
			throw new ArgumentException("invalid sid in SignerInfo");
		}
		digestAlgorithm = info.DigestAlgorithm;
		signedAttributeSet = info.AuthenticatedAttributes;
		unsignedAttributeSet = info.UnauthenticatedAttributes;
		encryptionAlgorithm = info.DigestEncryptionAlgorithm;
		signature = (byte[])info.EncryptedDigest.GetOctets().Clone();
		this.content = content;
		this.calculatedDigest = calculatedDigest;
	}

	protected SignerInformation(SignerInformation baseInfo)
	{
		info = baseInfo.info;
		content = baseInfo.content;
		contentType = baseInfo.contentType;
		isCounterSignature = baseInfo.IsCounterSignature;
		sid = baseInfo.sid;
		digestAlgorithm = info.DigestAlgorithm;
		signedAttributeSet = info.AuthenticatedAttributes;
		unsignedAttributeSet = info.UnauthenticatedAttributes;
		encryptionAlgorithm = info.DigestEncryptionAlgorithm;
		signature = (byte[])info.EncryptedDigest.GetOctets().Clone();
		calculatedDigest = baseInfo.calculatedDigest;
		signedAttributeTable = baseInfo.signedAttributeTable;
		unsignedAttributeTable = baseInfo.unsignedAttributeTable;
	}

	public byte[] GetContentDigest()
	{
		if (resultDigest == null)
		{
			throw new InvalidOperationException("method can only be called after verify.");
		}
		return (byte[])resultDigest.Clone();
	}

	public byte[] GetSignature()
	{
		return (byte[])signature.Clone();
	}

	public SignerInformationStore GetCounterSignatures()
	{
		Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttributes = UnsignedAttributes;
		if (unsignedAttributes == null)
		{
			return new SignerInformationStore(new List<SignerInformation>(0));
		}
		List<SignerInformation> list = new List<SignerInformation>();
		foreach (Org.BouncyCastle.Asn1.Cms.Attribute item in unsignedAttributes.GetAll(CmsAttributes.CounterSignature))
		{
			Asn1Set attrValues = item.AttrValues;
			_ = attrValues.Count;
			_ = 1;
			foreach (Asn1Encodable item2 in attrValues)
			{
				Org.BouncyCastle.Asn1.Cms.SignerInfo instance = Org.BouncyCastle.Asn1.Cms.SignerInfo.GetInstance(item2.ToAsn1Object());
				string digestAlgName = CmsSignedHelper.Instance.GetDigestAlgName(instance.DigestAlgorithm.Algorithm.Id);
				byte[] array = DigestUtilities.DoFinal(CmsSignedHelper.Instance.GetDigestInstance(digestAlgName), GetSignature());
				list.Add(new SignerInformation(instance, null, null, array));
			}
		}
		return new SignerInformationStore(list);
	}

	public virtual byte[] GetEncodedSignedAttributes()
	{
		if (signedAttributeSet != null)
		{
			return signedAttributeSet.GetEncoded("DER");
		}
		return null;
	}

	private bool DoVerify(AsymmetricKeyParameter key)
	{
		DerObjectIdentifier algorithm = encryptionAlgorithm.Algorithm;
		Asn1Encodable parameters = encryptionAlgorithm.Parameters;
		string digestAlgName = Helper.GetDigestAlgName(EncryptionAlgOid);
		if (digestAlgName.Equals(algorithm.Id))
		{
			digestAlgName = Helper.GetDigestAlgName(DigestAlgOid);
		}
		IDigest digestInstance = Helper.GetDigestInstance(digestAlgName);
		ISigner signer;
		if (algorithm.Equals(PkcsObjectIdentifiers.IdRsassaPss))
		{
			if (parameters == null)
			{
				throw new CmsException("RSASSA-PSS signature must specify algorithm parameters");
			}
			try
			{
				RsassaPssParameters instance = RsassaPssParameters.GetInstance(parameters.ToAsn1Object());
				if (!instance.HashAlgorithm.Algorithm.Equals(digestAlgorithm.Algorithm))
				{
					throw new CmsException("RSASSA-PSS signature parameters specified incorrect hash algorithm");
				}
				if (!instance.MaskGenAlgorithm.Algorithm.Equals(PkcsObjectIdentifiers.IdMgf1))
				{
					throw new CmsException("RSASSA-PSS signature parameters specified unknown MGF");
				}
				IDigest digest = DigestUtilities.GetDigest(instance.HashAlgorithm.Algorithm);
				int intValueExact = instance.SaltLength.IntValueExact;
				if (!RsassaPssParameters.DefaultTrailerField.Equals(instance.TrailerField))
				{
					throw new CmsException("RSASSA-PSS signature parameters must have trailerField of 1");
				}
				IAsymmetricBlockCipher cipher = new RsaBlindedEngine();
				signer = ((signedAttributeSet != null || calculatedDigest == null) ? new PssSigner(cipher, digest, intValueExact) : PssSigner.CreateRawSigner(cipher, digest, digest, intValueExact, 188));
			}
			catch (Exception innerException)
			{
				throw new CmsException("failed to set RSASSA-PSS signature parameters", innerException);
			}
		}
		else
		{
			string algorithm2 = digestAlgName + "with" + Helper.GetEncryptionAlgName(EncryptionAlgOid);
			signer = Helper.GetSignatureInstance(algorithm2);
		}
		try
		{
			if (calculatedDigest != null)
			{
				resultDigest = calculatedDigest;
			}
			else
			{
				if (content != null)
				{
					content.Write(new DigestSink(digestInstance));
				}
				else if (signedAttributeSet == null)
				{
					throw new CmsException("data not encapsulated in signature - use detached constructor.");
				}
				resultDigest = DigestUtilities.DoFinal(digestInstance);
			}
		}
		catch (IOException innerException2)
		{
			throw new CmsException("can't process mime object to create signature.", innerException2);
		}
		Asn1Object singleValuedSignedAttribute = GetSingleValuedSignedAttribute(CmsAttributes.ContentType, "content-type");
		if (singleValuedSignedAttribute == null)
		{
			if (!isCounterSignature && signedAttributeSet != null)
			{
				throw new CmsException("The content-type attribute type MUST be present whenever signed attributes are present in signed-data");
			}
		}
		else
		{
			if (isCounterSignature)
			{
				throw new CmsException("[For counter signatures,] the signedAttributes field MUST NOT contain a content-type attribute");
			}
			if (!((singleValuedSignedAttribute as DerObjectIdentifier) ?? throw new CmsException("content-type attribute value not of ASN.1 type 'OBJECT IDENTIFIER'")).Equals(contentType))
			{
				throw new CmsException("content-type attribute value does not match eContentType");
			}
		}
		Asn1Object singleValuedSignedAttribute2 = GetSingleValuedSignedAttribute(CmsAttributes.MessageDigest, "message-digest");
		if (singleValuedSignedAttribute2 == null)
		{
			if (signedAttributeSet != null)
			{
				throw new CmsException("the message-digest signed attribute type MUST be present when there are any signed attributes present");
			}
		}
		else
		{
			if (!(singleValuedSignedAttribute2 is Asn1OctetString asn1OctetString))
			{
				throw new CmsException("message-digest attribute value not of ASN.1 type 'OCTET STRING'");
			}
			if (!Arrays.AreEqual(resultDigest, asn1OctetString.GetOctets()))
			{
				throw new CmsException("message-digest attribute value does not match calculated value");
			}
		}
		Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttributes = SignedAttributes;
		if (signedAttributes != null && signedAttributes.GetAll(CmsAttributes.CounterSignature).Count > 0)
		{
			throw new CmsException("A countersignature attribute MUST NOT be a signed attribute");
		}
		Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttributes = UnsignedAttributes;
		if (unsignedAttributes != null)
		{
			foreach (Org.BouncyCastle.Asn1.Cms.Attribute item in unsignedAttributes.GetAll(CmsAttributes.CounterSignature))
			{
				if (item.AttrValues.Count < 1)
				{
					throw new CmsException("A countersignature attribute MUST contain at least one AttributeValue");
				}
			}
		}
		try
		{
			signer.Init(forSigning: false, key);
			if (signedAttributeSet == null)
			{
				if (calculatedDigest != null)
				{
					if (!(signer is PssSigner))
					{
						return VerifyDigest(resultDigest, key, GetSignature());
					}
					signer.BlockUpdate(resultDigest, 0, resultDigest.Length);
				}
				else if (content != null)
				{
					try
					{
						content.Write(new SignerSink(signer));
					}
					catch (SignatureException ex)
					{
						throw new CmsStreamException("signature problem: " + ex);
					}
				}
			}
			else
			{
				byte[] encodedSignedAttributes = GetEncodedSignedAttributes();
				signer.BlockUpdate(encodedSignedAttributes, 0, encodedSignedAttributes.Length);
			}
			return signer.VerifySignature(GetSignature());
		}
		catch (InvalidKeyException innerException3)
		{
			throw new CmsException("key not appropriate to signature in message.", innerException3);
		}
		catch (IOException innerException4)
		{
			throw new CmsException("can't process mime object to create signature.", innerException4);
		}
		catch (SignatureException ex2)
		{
			throw new CmsException("invalid signature format in message: " + ex2.Message, ex2);
		}
	}

	private bool IsNull(Asn1Encodable o)
	{
		if (!(o is Asn1Null))
		{
			return o == null;
		}
		return true;
	}

	private DigestInfo DerDecode(byte[] encoding)
	{
		if (encoding[0] != 48)
		{
			throw new IOException("not a digest info object");
		}
		DigestInfo instance = DigestInfo.GetInstance(Asn1Object.FromByteArray(encoding));
		if (instance.GetEncoded().Length != encoding.Length)
		{
			throw new CmsException("malformed RSA signature");
		}
		return instance;
	}

	private bool VerifyDigest(byte[] digest, AsymmetricKeyParameter key, byte[] signature)
	{
		string encryptionAlgName = Helper.GetEncryptionAlgName(EncryptionAlgOid);
		try
		{
			if (encryptionAlgName.Equals("RSA"))
			{
				IBufferedCipher cipher = CipherUtilities.GetCipher(PkcsObjectIdentifiers.RsaEncryption);
				cipher.Init(forEncryption: false, key);
				byte[] encoding = cipher.DoFinal(signature);
				DigestInfo digestInfo = DerDecode(encoding);
				if (!digestInfo.AlgorithmID.Algorithm.Equals(digestAlgorithm.Algorithm))
				{
					return false;
				}
				if (!IsNull(digestInfo.AlgorithmID.Parameters))
				{
					return false;
				}
				byte[] digest2 = digestInfo.GetDigest();
				return Arrays.FixedTimeEquals(digest, digest2);
			}
			if (encryptionAlgName.Equals("DSA"))
			{
				ISigner signer = SignerUtilities.GetSigner("NONEwithDSA");
				signer.Init(forSigning: false, key);
				signer.BlockUpdate(digest, 0, digest.Length);
				return signer.VerifySignature(signature);
			}
			throw new CmsException("algorithm: " + encryptionAlgName + " not supported in base signatures.");
		}
		catch (SecurityUtilityException)
		{
			throw;
		}
		catch (GeneralSecurityException ex2)
		{
			throw new CmsException("Exception processing signature: " + ex2, ex2);
		}
		catch (IOException ex3)
		{
			throw new CmsException("Exception decoding signature: " + ex3, ex3);
		}
	}

	public bool Verify(AsymmetricKeyParameter pubKey)
	{
		if (pubKey.IsPrivate)
		{
			throw new ArgumentException("Expected public key", "pubKey");
		}
		GetSigningTime();
		return DoVerify(pubKey);
	}

	public bool Verify(X509Certificate cert)
	{
		Org.BouncyCastle.Asn1.Cms.Time signingTime = GetSigningTime();
		if (signingTime != null)
		{
			cert.CheckValidity(signingTime.ToDateTime());
		}
		return DoVerify(cert.GetPublicKey());
	}

	public Org.BouncyCastle.Asn1.Cms.SignerInfo ToSignerInfo()
	{
		return info;
	}

	private Asn1Object GetSingleValuedSignedAttribute(DerObjectIdentifier attrOID, string printableName)
	{
		Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttributes = UnsignedAttributes;
		if (unsignedAttributes != null && unsignedAttributes.GetAll(attrOID).Count > 0)
		{
			throw new CmsException("The " + printableName + " attribute MUST NOT be an unsigned attribute");
		}
		Org.BouncyCastle.Asn1.Cms.AttributeTable signedAttributes = SignedAttributes;
		if (signedAttributes == null)
		{
			return null;
		}
		Asn1EncodableVector all = signedAttributes.GetAll(attrOID);
		switch (all.Count)
		{
		case 0:
			return null;
		case 1:
		{
			Asn1Set attrValues = ((Org.BouncyCastle.Asn1.Cms.Attribute)all[0]).AttrValues;
			if (attrValues.Count != 1)
			{
				throw new CmsException("A " + printableName + " attribute MUST have a single attribute value");
			}
			return attrValues[0].ToAsn1Object();
		}
		default:
			throw new CmsException("The SignedAttributes in a signerInfo MUST NOT include multiple instances of the " + printableName + " attribute");
		}
	}

	private Org.BouncyCastle.Asn1.Cms.Time GetSigningTime()
	{
		Asn1Object singleValuedSignedAttribute = GetSingleValuedSignedAttribute(CmsAttributes.SigningTime, "signing-time");
		if (singleValuedSignedAttribute == null)
		{
			return null;
		}
		try
		{
			return Org.BouncyCastle.Asn1.Cms.Time.GetInstance(singleValuedSignedAttribute);
		}
		catch (ArgumentException)
		{
			throw new CmsException("signing-time attribute value not a valid 'Time' structure");
		}
	}

	public static SignerInformation ReplaceUnsignedAttributes(SignerInformation signerInformation, Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttributes)
	{
		Org.BouncyCastle.Asn1.Cms.SignerInfo signerInfo = signerInformation.info;
		Asn1Set unauthenticatedAttributes = null;
		if (unsignedAttributes != null)
		{
			unauthenticatedAttributes = new DerSet(unsignedAttributes.ToAsn1EncodableVector());
		}
		return new SignerInformation(new Org.BouncyCastle.Asn1.Cms.SignerInfo(signerInfo.SignerID, signerInfo.DigestAlgorithm, signerInfo.AuthenticatedAttributes, signerInfo.DigestEncryptionAlgorithm, signerInfo.EncryptedDigest, unauthenticatedAttributes), signerInformation.contentType, signerInformation.content, null);
	}

	public static SignerInformation AddCounterSigners(SignerInformation signerInformation, SignerInformationStore counterSigners)
	{
		Org.BouncyCastle.Asn1.Cms.SignerInfo signerInfo = signerInformation.info;
		Org.BouncyCastle.Asn1.Cms.AttributeTable unsignedAttributes = signerInformation.UnsignedAttributes;
		Asn1EncodableVector asn1EncodableVector = ((unsignedAttributes == null) ? new Asn1EncodableVector(1) : unsignedAttributes.ToAsn1EncodableVector());
		IList<SignerInformation> signers = counterSigners.GetSigners();
		Asn1EncodableVector asn1EncodableVector2 = new Asn1EncodableVector(signers.Count);
		foreach (SignerInformation item in signers)
		{
			asn1EncodableVector2.Add(item.ToSignerInfo());
		}
		asn1EncodableVector.Add(new Org.BouncyCastle.Asn1.Cms.Attribute(CmsAttributes.CounterSignature, new DerSet(asn1EncodableVector2)));
		return new SignerInformation(new Org.BouncyCastle.Asn1.Cms.SignerInfo(signerInfo.SignerID, signerInfo.DigestAlgorithm, signerInfo.AuthenticatedAttributes, signerInfo.DigestEncryptionAlgorithm, signerInfo.EncryptedDigest, new DerSet(asn1EncodableVector)), signerInformation.contentType, signerInformation.content, null);
	}
}
