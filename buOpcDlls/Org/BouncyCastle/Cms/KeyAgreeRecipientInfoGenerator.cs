// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.KeyAgreeRecipientInfoGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.Cms.Ecc;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

internal class KeyAgreeRecipientInfoGenerator : RecipientInfoGenerator
{
  private static readonly CmsEnvelopedHelper Helper = CmsEnvelopedHelper.Instance;
  private readonly List<KeyAgreeRecipientIdentifier> m_recipientIDs = new List<KeyAgreeRecipientIdentifier>();
  private readonly List<AsymmetricKeyParameter> m_recipientKeys = new List<AsymmetricKeyParameter>();
  private DerObjectIdentifier m_keyAgreementOid;
  private DerObjectIdentifier m_keyEncryptionOid;
  private AsymmetricCipherKeyPair m_senderKeyPair;

  internal KeyAgreeRecipientInfoGenerator(IEnumerable<X509Certificate> recipientCerts)
  {
    foreach (X509Certificate recipientCert in recipientCerts)
    {
      this.m_recipientIDs.Add(new KeyAgreeRecipientIdentifier(CmsUtilities.GetIssuerAndSerialNumber(recipientCert)));
      this.m_recipientKeys.Add(recipientCert.GetPublicKey());
    }
  }

  internal KeyAgreeRecipientInfoGenerator(byte[] subjectKeyID, AsymmetricKeyParameter publicKey)
  {
    this.m_recipientIDs.Add(new KeyAgreeRecipientIdentifier(new RecipientKeyIdentifier(subjectKeyID)));
    this.m_recipientKeys.Add(publicKey);
  }

  internal DerObjectIdentifier KeyAgreementOid
  {
    set => this.m_keyAgreementOid = value;
  }

  internal DerObjectIdentifier KeyEncryptionOid
  {
    set => this.m_keyEncryptionOid = value;
  }

  internal AsymmetricCipherKeyPair SenderKeyPair
  {
    set => this.m_senderKeyPair = value;
  }

  public RecipientInfo Generate(KeyParameter contentEncryptionKey, SecureRandom random)
  {
    byte[] key = contentEncryptionKey.GetKey();
    AsymmetricKeyParameter publicKey = this.m_senderKeyPair.Public;
    ICipherParameters cipherParameters1 = (ICipherParameters) this.m_senderKeyPair.Private;
    OriginatorIdentifierOrKey originator;
    try
    {
      originator = new OriginatorIdentifierOrKey(KeyAgreeRecipientInfoGenerator.CreateOriginatorPublicKey(publicKey));
    }
    catch (IOException ex)
    {
      throw new InvalidKeyException("cannot extract originator public key: " + ex?.ToString());
    }
    Asn1OctetString ukm = (Asn1OctetString) null;
    if (this.m_keyAgreementOid.Id.Equals(CmsEnvelopedGenerator.ECMqvSha1Kdf))
    {
      try
      {
        IAsymmetricCipherKeyPairGenerator keyPairGenerator = GeneratorUtilities.GetKeyPairGenerator(this.m_keyAgreementOid);
        keyPairGenerator.Init((KeyGenerationParameters) ((ECKeyParameters) publicKey).CreateKeyGenerationParameters(random));
        AsymmetricCipherKeyPair keyPair = keyPairGenerator.GenerateKeyPair();
        ukm = (Asn1OctetString) new DerOctetString((Asn1Encodable) new MQVuserKeyingMaterial(KeyAgreeRecipientInfoGenerator.CreateOriginatorPublicKey(keyPair.Public), (Asn1OctetString) null));
        cipherParameters1 = (ICipherParameters) new MqvPrivateParameters((ECPrivateKeyParameters) cipherParameters1, (ECPrivateKeyParameters) keyPair.Private, (ECPublicKeyParameters) keyPair.Public);
      }
      catch (IOException ex)
      {
        throw new InvalidKeyException("cannot extract MQV ephemeral public key: " + ex?.ToString());
      }
      catch (SecurityUtilityException ex)
      {
        throw new InvalidKeyException("cannot determine MQV ephemeral key pair parameters from public key: " + ex?.ToString());
      }
    }
    AlgorithmIdentifier keyEncryptionAlgorithm = new AlgorithmIdentifier(this.m_keyAgreementOid, (Asn1Encodable) new DerSequence((Asn1Encodable) this.m_keyEncryptionOid, (Asn1Encodable) DerNull.Instance));
    Asn1EncodableVector elementVector = new Asn1EncodableVector(this.m_recipientIDs.Count);
    for (int index = 0; index < this.m_recipientIDs.Count; ++index)
    {
      KeyAgreeRecipientIdentifier recipientId = this.m_recipientIDs[index];
      ICipherParameters cipherParameters2 = (ICipherParameters) this.m_recipientKeys[index];
      if (this.m_keyAgreementOid.Id.Equals(CmsEnvelopedGenerator.ECMqvSha1Kdf))
        cipherParameters2 = (ICipherParameters) new MqvPublicParameters((ECPublicKeyParameters) cipherParameters2, (ECPublicKeyParameters) cipherParameters2);
      IBasicAgreement agreementWithKdf = AgreementUtilities.GetBasicAgreementWithKdf(this.m_keyAgreementOid, this.m_keyEncryptionOid.Id);
      agreementWithKdf.Init((ICipherParameters) new ParametersWithRandom(cipherParameters1, random));
      KeyParameter keyParameter = ParameterUtilities.CreateKeyParameter(this.m_keyEncryptionOid, X9IntegerConverter.IntegerToBytes(agreementWithKdf.CalculateAgreement(cipherParameters2), GeneratorUtilities.GetDefaultKeySize(this.m_keyEncryptionOid) / 8));
      IWrapper wrapper = WrapperUtilities.GetWrapper(this.m_keyEncryptionOid.Id);
      wrapper.Init(true, (ICipherParameters) new ParametersWithRandom((ICipherParameters) keyParameter, random));
      Asn1OctetString encryptedKey = (Asn1OctetString) new DerOctetString(wrapper.Wrap(key, 0, key.Length));
      elementVector.Add((Asn1Encodable) new RecipientEncryptedKey(recipientId, encryptedKey));
    }
    return new RecipientInfo(new KeyAgreeRecipientInfo(originator, ukm, keyEncryptionAlgorithm, (Asn1Sequence) new DerSequence(elementVector)));
  }

  private static OriginatorPublicKey CreateOriginatorPublicKey(AsymmetricKeyParameter publicKey)
  {
    SubjectPublicKeyInfo subjectPublicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKey);
    return new OriginatorPublicKey(new AlgorithmIdentifier(subjectPublicKeyInfo.AlgorithmID.Algorithm, (Asn1Encodable) DerNull.Instance), subjectPublicKeyInfo.PublicKeyData.GetBytes());
  }
}
