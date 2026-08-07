// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsEnvelopedGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.Kisa;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Ntt;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Cms;

public abstract class CmsEnvelopedGenerator
{
  internal static readonly short[] rc2Table = new short[256 /*0x0100*/]
  {
    (short) 189,
    (short) 86,
    (short) 234,
    (short) 242,
    (short) 162,
    (short) 241,
    (short) 172,
    (short) 42,
    (short) 176 /*0xB0*/,
    (short) 147,
    (short) 209,
    (short) 156,
    (short) 27,
    (short) 51,
    (short) 253,
    (short) 208 /*0xD0*/,
    (short) 48 /*0x30*/,
    (short) 4,
    (short) 182,
    (short) 220,
    (short) 125,
    (short) 223,
    (short) 50,
    (short) 75,
    (short) 247,
    (short) 203,
    (short) 69,
    (short) 155,
    (short) 49,
    (short) 187,
    (short) 33,
    (short) 90,
    (short) 65,
    (short) 159,
    (short) 225,
    (short) 217,
    (short) 74,
    (short) 77,
    (short) 158,
    (short) 218,
    (short) 160 /*0xA0*/,
    (short) 104,
    (short) 44,
    (short) 195,
    (short) 39,
    (short) 95,
    (short) 128 /*0x80*/,
    (short) 54,
    (short) 62,
    (short) 238,
    (short) 251,
    (short) 149,
    (short) 26,
    (short) 254,
    (short) 206,
    (short) 168,
    (short) 52,
    (short) 169,
    (short) 19,
    (short) 240 /*0xF0*/,
    (short) 166,
    (short) 63 /*0x3F*/,
    (short) 216,
    (short) 12,
    (short) 120,
    (short) 36,
    (short) 175,
    (short) 35,
    (short) 82,
    (short) 193,
    (short) 103,
    (short) 23,
    (short) 245,
    (short) 102,
    (short) 144 /*0x90*/,
    (short) 231,
    (short) 232,
    (short) 7,
    (short) 184,
    (short) 96 /*0x60*/,
    (short) 72,
    (short) 230,
    (short) 30,
    (short) 83,
    (short) 243,
    (short) 146,
    (short) 164,
    (short) 114,
    (short) 140,
    (short) 8,
    (short) 21,
    (short) 110,
    (short) 134,
    (short) 0,
    (short) 132,
    (short) 250,
    (short) 244,
    (short) sbyte.MaxValue,
    (short) 138,
    (short) 66,
    (short) 25,
    (short) 246,
    (short) 219,
    (short) 205,
    (short) 20,
    (short) 141,
    (short) 80 /*0x50*/,
    (short) 18,
    (short) 186,
    (short) 60,
    (short) 6,
    (short) 78,
    (short) 236,
    (short) 179,
    (short) 53,
    (short) 17,
    (short) 161,
    (short) 136,
    (short) 142,
    (short) 43,
    (short) 148,
    (short) 153,
    (short) 183,
    (short) 113,
    (short) 116,
    (short) 211,
    (short) 228,
    (short) 191,
    (short) 58,
    (short) 222,
    (short) 150,
    (short) 14,
    (short) 188,
    (short) 10,
    (short) 237,
    (short) 119,
    (short) 252,
    (short) 55,
    (short) 107,
    (short) 3,
    (short) 121,
    (short) 137,
    (short) 98,
    (short) 198,
    (short) 215,
    (short) 192 /*0xC0*/,
    (short) 210,
    (short) 124,
    (short) 106,
    (short) 139,
    (short) 34,
    (short) 163,
    (short) 91,
    (short) 5,
    (short) 93,
    (short) 2,
    (short) 117,
    (short) 213,
    (short) 97,
    (short) 227,
    (short) 24,
    (short) 143,
    (short) 85,
    (short) 81,
    (short) 173,
    (short) 31 /*0x1F*/,
    (short) 11,
    (short) 94,
    (short) 133,
    (short) 229,
    (short) 194,
    (short) 87,
    (short) 99,
    (short) 202,
    (short) 61,
    (short) 108,
    (short) 180,
    (short) 197,
    (short) 204,
    (short) 112 /*0x70*/,
    (short) 178,
    (short) 145,
    (short) 89,
    (short) 13,
    (short) 71,
    (short) 32 /*0x20*/,
    (short) 200,
    (short) 79,
    (short) 88,
    (short) 224 /*0xE0*/,
    (short) 1,
    (short) 226,
    (short) 22,
    (short) 56,
    (short) 196,
    (short) 111,
    (short) 59,
    (short) 15,
    (short) 101,
    (short) 70,
    (short) 190,
    (short) 126,
    (short) 45,
    (short) 123,
    (short) 130,
    (short) 249,
    (short) 64 /*0x40*/,
    (short) 181,
    (short) 29,
    (short) 115,
    (short) 248,
    (short) 235,
    (short) 38,
    (short) 199,
    (short) 135,
    (short) 151,
    (short) 37,
    (short) 84,
    (short) 177,
    (short) 40,
    (short) 170,
    (short) 152,
    (short) 157,
    (short) 165,
    (short) 100,
    (short) 109,
    (short) 122,
    (short) 212,
    (short) 16 /*0x10*/,
    (short) 129,
    (short) 68,
    (short) 239,
    (short) 73,
    (short) 214,
    (short) 174,
    (short) 46,
    (short) 221,
    (short) 118,
    (short) 92,
    (short) 47,
    (short) 167,
    (short) 28,
    (short) 201,
    (short) 9,
    (short) 105,
    (short) 154,
    (short) 131,
    (short) 207,
    (short) 41,
    (short) 57,
    (short) 185,
    (short) 233,
    (short) 76,
    (short) byte.MaxValue,
    (short) 67,
    (short) 171
  };
  public static readonly string DesCbc = OiwObjectIdentifiers.DesCbc.Id;
  public static readonly string DesEde3Cbc = PkcsObjectIdentifiers.DesEde3Cbc.Id;
  public static readonly string RC2Cbc = PkcsObjectIdentifiers.RC2Cbc.Id;
  public const string IdeaCbc = "1.3.6.1.4.1.188.7.1.1.2";
  public const string Cast5Cbc = "1.2.840.113533.7.66.10";
  public static readonly string Aes128Cbc = NistObjectIdentifiers.IdAes128Cbc.Id;
  public static readonly string Aes192Cbc = NistObjectIdentifiers.IdAes192Cbc.Id;
  public static readonly string Aes256Cbc = NistObjectIdentifiers.IdAes256Cbc.Id;
  public static readonly string Aes128Ccm = NistObjectIdentifiers.IdAes128Ccm.Id;
  public static readonly string Aes192Ccm = NistObjectIdentifiers.IdAes192Ccm.Id;
  public static readonly string Aes256Ccm = NistObjectIdentifiers.IdAes256Ccm.Id;
  public static readonly string Aes128Gcm = NistObjectIdentifiers.IdAes128Gcm.Id;
  public static readonly string Aes192Gcm = NistObjectIdentifiers.IdAes192Gcm.Id;
  public static readonly string Aes256Gcm = NistObjectIdentifiers.IdAes256Gcm.Id;
  public static readonly string Camellia128Cbc = NttObjectIdentifiers.IdCamellia128Cbc.Id;
  public static readonly string Camellia192Cbc = NttObjectIdentifiers.IdCamellia192Cbc.Id;
  public static readonly string Camellia256Cbc = NttObjectIdentifiers.IdCamellia256Cbc.Id;
  public static readonly string SeedCbc = KisaObjectIdentifiers.IdSeedCbc.Id;
  public static readonly string DesEde3Wrap = PkcsObjectIdentifiers.IdAlgCms3DesWrap.Id;
  public static readonly string Aes128Wrap = NistObjectIdentifiers.IdAes128Wrap.Id;
  public static readonly string Aes192Wrap = NistObjectIdentifiers.IdAes192Wrap.Id;
  public static readonly string Aes256Wrap = NistObjectIdentifiers.IdAes256Wrap.Id;
  public static readonly string Camellia128Wrap = NttObjectIdentifiers.IdCamellia128Wrap.Id;
  public static readonly string Camellia192Wrap = NttObjectIdentifiers.IdCamellia192Wrap.Id;
  public static readonly string Camellia256Wrap = NttObjectIdentifiers.IdCamellia256Wrap.Id;
  public static readonly string SeedWrap = KisaObjectIdentifiers.IdNpkiAppCmsSeedWrap.Id;
  public static readonly string ECDHSha1Kdf = X9ObjectIdentifiers.DHSinglePassStdDHSha1KdfScheme.Id;
  public static readonly string ECMqvSha1Kdf = X9ObjectIdentifiers.MqvSinglePassSha1KdfScheme.Id;
  internal readonly IList<RecipientInfoGenerator> recipientInfoGenerators = (IList<RecipientInfoGenerator>) new List<RecipientInfoGenerator>();
  internal readonly SecureRandom m_random;
  internal CmsAttributeTableGenerator unprotectedAttributeGenerator;

  protected CmsEnvelopedGenerator()
    : this(CryptoServicesRegistrar.GetSecureRandom())
  {
  }

  protected CmsEnvelopedGenerator(SecureRandom random)
  {
    this.m_random = random != null ? random : throw new ArgumentNullException(nameof (random));
  }

  public CmsAttributeTableGenerator UnprotectedAttributeGenerator
  {
    get => this.unprotectedAttributeGenerator;
    set => this.unprotectedAttributeGenerator = value;
  }

  public void AddKeyTransRecipient(X509Certificate cert)
  {
    SubjectPublicKeyInfo subjectPublicKeyInfo = CmsUtilities.GetTbsCertificateStructure(cert).SubjectPublicKeyInfo;
    this.AddRecipientInfoGenerator((RecipientInfoGenerator) new KeyTransRecipientInfoGenerator(cert, (IKeyWrapper) new Asn1KeyWrapper(subjectPublicKeyInfo.AlgorithmID.Algorithm, subjectPublicKeyInfo.AlgorithmID.Parameters, cert)));
  }

  public void AddKeyTransRecipient(AsymmetricKeyParameter pubKey, byte[] subKeyId)
  {
    SubjectPublicKeyInfo subjectPublicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(pubKey);
    this.AddRecipientInfoGenerator((RecipientInfoGenerator) new KeyTransRecipientInfoGenerator(subKeyId, (IKeyWrapper) new Asn1KeyWrapper(subjectPublicKeyInfo.AlgorithmID.Algorithm, subjectPublicKeyInfo.AlgorithmID.Parameters, (ICipherParameters) pubKey)));
  }

  public void AddKekRecipient(string keyAlgorithm, KeyParameter key, byte[] keyIdentifier)
  {
    this.AddKekRecipient(keyAlgorithm, key, new KekIdentifier(keyIdentifier, (Asn1GeneralizedTime) null, (OtherKeyAttribute) null));
  }

  public void AddKekRecipient(string keyAlgorithm, KeyParameter key, KekIdentifier kekIdentifier)
  {
    this.recipientInfoGenerators.Add((RecipientInfoGenerator) new KekRecipientInfoGenerator()
    {
      KekIdentifier = kekIdentifier,
      KeyEncryptionKeyOID = keyAlgorithm,
      KeyEncryptionKey = key
    });
  }

  public void AddPasswordRecipient(CmsPbeKey pbeKey, string kekAlgorithmOid)
  {
    Pbkdf2Params parameters = new Pbkdf2Params(pbeKey.Salt, pbeKey.IterationCount);
    this.recipientInfoGenerators.Add((RecipientInfoGenerator) new PasswordRecipientInfoGenerator()
    {
      KeyDerivationAlgorithm = new AlgorithmIdentifier(PkcsObjectIdentifiers.IdPbkdf2, (Asn1Encodable) parameters),
      KeyEncryptionKeyOID = kekAlgorithmOid,
      KeyEncryptionKey = pbeKey.GetEncoded(kekAlgorithmOid)
    });
  }

  public void AddKeyAgreementRecipient(
    string agreementAlgorithm,
    AsymmetricKeyParameter senderPrivateKey,
    AsymmetricKeyParameter senderPublicKey,
    X509Certificate recipientCert,
    string cekWrapAlgorithm)
  {
    List<X509Certificate> recipientCerts = new List<X509Certificate>(1)
    {
      recipientCert
    };
    this.AddKeyAgreementRecipients(agreementAlgorithm, senderPrivateKey, senderPublicKey, (IEnumerable<X509Certificate>) recipientCerts, cekWrapAlgorithm);
  }

  public void AddKeyAgreementRecipients(
    string agreementAlgorithm,
    AsymmetricKeyParameter senderPrivateKey,
    AsymmetricKeyParameter senderPublicKey,
    IEnumerable<X509Certificate> recipientCerts,
    string cekWrapAlgorithm)
  {
    if (!senderPrivateKey.IsPrivate)
      throw new ArgumentException("Expected private key", nameof (senderPrivateKey));
    if (senderPublicKey.IsPrivate)
      throw new ArgumentException("Expected public key", nameof (senderPublicKey));
    this.recipientInfoGenerators.Add((RecipientInfoGenerator) new KeyAgreeRecipientInfoGenerator(recipientCerts)
    {
      KeyAgreementOid = new DerObjectIdentifier(agreementAlgorithm),
      KeyEncryptionOid = new DerObjectIdentifier(cekWrapAlgorithm),
      SenderKeyPair = new AsymmetricCipherKeyPair(senderPublicKey, senderPrivateKey)
    });
  }

  public void AddKeyAgreementRecipient(
    string agreementAlgorithm,
    AsymmetricKeyParameter senderPrivateKey,
    AsymmetricKeyParameter senderPublicKey,
    byte[] recipientKeyID,
    AsymmetricKeyParameter recipientPublicKey,
    string cekWrapAlgorithm)
  {
    if (!senderPrivateKey.IsPrivate)
      throw new ArgumentException("Expected private key", nameof (senderPrivateKey));
    if (senderPublicKey.IsPrivate)
      throw new ArgumentException("Expected public key", nameof (senderPublicKey));
    if (recipientPublicKey.IsPrivate)
      throw new ArgumentException("Expected public key", nameof (recipientPublicKey));
    this.recipientInfoGenerators.Add((RecipientInfoGenerator) new KeyAgreeRecipientInfoGenerator(recipientKeyID, recipientPublicKey)
    {
      KeyAgreementOid = new DerObjectIdentifier(agreementAlgorithm),
      KeyEncryptionOid = new DerObjectIdentifier(cekWrapAlgorithm),
      SenderKeyPair = new AsymmetricCipherKeyPair(senderPublicKey, senderPrivateKey)
    });
  }

  public void AddRecipientInfoGenerator(RecipientInfoGenerator recipientInfoGenerator)
  {
    this.recipientInfoGenerators.Add(recipientInfoGenerator);
  }

  protected internal virtual AlgorithmIdentifier GetAlgorithmIdentifier(
    string encryptionOid,
    KeyParameter encKey,
    Asn1Encodable asn1Params,
    out ICipherParameters cipherParameters)
  {
    Asn1Object asn1Object;
    if (asn1Params != null)
    {
      asn1Object = asn1Params.ToAsn1Object();
      cipherParameters = ParameterUtilities.GetCipherParameters(encryptionOid, (ICipherParameters) encKey, asn1Object);
    }
    else
    {
      asn1Object = (Asn1Object) DerNull.Instance;
      cipherParameters = (ICipherParameters) encKey;
    }
    return new AlgorithmIdentifier(new DerObjectIdentifier(encryptionOid), (Asn1Encodable) asn1Object);
  }

  protected internal virtual Asn1Encodable GenerateAsn1Parameters(
    string encryptionOid,
    byte[] encKeyBytes)
  {
    Asn1Encodable asn1Parameters = (Asn1Encodable) null;
    try
    {
      if (encryptionOid.Equals(CmsEnvelopedGenerator.RC2Cbc))
      {
        byte[] numArray = new byte[8];
        this.m_random.NextBytes(numArray);
        int index = encKeyBytes.Length * 8;
        asn1Parameters = (Asn1Encodable) new RC2CbcParameter(index >= 256 /*0x0100*/ ? index : (int) CmsEnvelopedGenerator.rc2Table[index], numArray);
      }
      else
        asn1Parameters = ParameterUtilities.GenerateParameters(encryptionOid, this.m_random);
    }
    catch (SecurityUtilityException ex)
    {
    }
    return asn1Parameters;
  }
}
