// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.OpenSsl.MiscPemGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.Utilities.IO.Pem;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.OpenSsl;

public class MiscPemGenerator : PemObjectGenerator
{
  private readonly object obj;
  private readonly string algorithm;
  private readonly char[] password;
  private readonly SecureRandom random;

  public MiscPemGenerator(object obj)
    : this(obj, (string) null, (char[]) null, (SecureRandom) null)
  {
  }

  public MiscPemGenerator(object obj, string algorithm, char[] password, SecureRandom random)
  {
    this.obj = obj;
    this.algorithm = algorithm;
    this.password = password;
    this.random = random;
  }

  private static PemObject CreatePemObject(object obj)
  {
    string keyType;
    byte[] content;
    switch (obj)
    {
      case null:
        throw new ArgumentNullException(nameof (obj));
      case AsymmetricCipherKeyPair asymmetricCipherKeyPair:
        return MiscPemGenerator.CreatePemObject((object) asymmetricCipherKeyPair.Private);
      case PemObject pemObject:
        return pemObject;
      case PemObjectGenerator pemObjectGenerator:
        return pemObjectGenerator.Generate();
      case X509Certificate x509Certificate:
        keyType = "CERTIFICATE";
        try
        {
          content = x509Certificate.GetEncoded();
          break;
        }
        catch (CertificateEncodingException ex)
        {
          throw new IOException("Cannot Encode object: " + ex.ToString());
        }
      case X509Crl x509Crl:
        keyType = "X509 CRL";
        try
        {
          content = x509Crl.GetEncoded();
          break;
        }
        catch (CrlException ex)
        {
          throw new IOException("Cannot Encode object: " + ex.ToString());
        }
      case AsymmetricKeyParameter akp:
        content = !akp.IsPrivate ? MiscPemGenerator.EncodePublicKey(akp, out keyType) : MiscPemGenerator.EncodePrivateKey(akp, out keyType);
        break;
      case PrivateKeyInfo info1:
        content = MiscPemGenerator.EncodePrivateKeyInfo(info1, out keyType);
        break;
      case SubjectPublicKeyInfo info2:
        content = MiscPemGenerator.EncodePublicKeyInfo(info2, out keyType);
        break;
      case X509V2AttributeCertificate attributeCertificate:
        keyType = "ATTRIBUTE CERTIFICATE";
        content = attributeCertificate.GetEncoded();
        break;
      case Pkcs8EncryptedPrivateKeyInfo encryptedPrivateKeyInfo:
        keyType = "ENCRYPTED PRIVATE KEY";
        content = encryptedPrivateKeyInfo.GetEncoded();
        break;
      case Pkcs10CertificationRequest certificationRequest:
        keyType = "CERTIFICATE REQUEST";
        content = certificationRequest.GetEncoded();
        break;
      case Org.BouncyCastle.Asn1.Cms.ContentInfo contentInfo1:
        keyType = "PKCS7";
        content = contentInfo1.GetEncoded();
        break;
      case Org.BouncyCastle.Asn1.Pkcs.ContentInfo contentInfo2:
        keyType = "PKCS7";
        content = contentInfo2.GetEncoded();
        break;
      default:
        throw new PemGenerationException("Object type not supported: " + Platform.GetTypeName(obj));
    }
    return new PemObject(keyType, content);
  }

  private static PemObject CreatePemObject(
    object obj,
    string algorithm,
    char[] password,
    SecureRandom random)
  {
    if (obj == null)
      throw new ArgumentNullException(nameof (obj));
    if (algorithm == null)
      throw new ArgumentNullException(nameof (algorithm));
    if (password == null)
      throw new ArgumentNullException(nameof (password));
    if (random == null)
      throw new ArgumentNullException(nameof (random));
    if (obj is AsymmetricCipherKeyPair asymmetricCipherKeyPair)
      return MiscPemGenerator.CreatePemObject((object) asymmetricCipherKeyPair.Private, algorithm, password, random);
    string keyType = (string) null;
    byte[] bytes = (byte[]) null;
    if (obj is AsymmetricKeyParameter akp && akp.IsPrivate)
      bytes = MiscPemGenerator.EncodePrivateKey(akp, out keyType);
    if (keyType == null || bytes == null)
      throw new PemGenerationException("Object type not supported: " + Platform.GetTypeName(obj));
    string str = algorithm.ToUpperInvariant();
    if (str == "DESEDE")
      str = "DES-EDE3-CBC";
    byte[] numArray = new byte[Platform.StartsWith(str, "AES-") ? 16 /*0x10*/ : 8];
    random.NextBytes(numArray);
    byte[] content = PemUtilities.Crypt(true, bytes, password, str, numArray);
    return new PemObject(keyType, (IList<PemHeader>) new List<PemHeader>(2)
    {
      new PemHeader("Proc-Type", "4,ENCRYPTED"),
      new PemHeader("DEK-Info", $"{str},{Hex.ToHexString(numArray, true)}")
    }, content);
  }

  public PemObject Generate()
  {
    try
    {
      return this.algorithm != null ? MiscPemGenerator.CreatePemObject(this.obj, this.algorithm, this.password, this.random) : MiscPemGenerator.CreatePemObject(this.obj);
    }
    catch (IOException ex)
    {
      throw new PemGenerationException("encoding exception", (Exception) ex);
    }
  }

  private static byte[] EncodePrivateKey(AsymmetricKeyParameter akp, out string keyType)
  {
    return MiscPemGenerator.EncodePrivateKeyInfo(PrivateKeyInfoFactory.CreatePrivateKeyInfo(akp), out keyType);
  }

  private static byte[] EncodePrivateKeyInfo(PrivateKeyInfo info, out string keyType)
  {
    AlgorithmIdentifier privateKeyAlgorithm = info.PrivateKeyAlgorithm;
    DerObjectIdentifier algorithm = privateKeyAlgorithm.Algorithm;
    if (algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.RsaEncryption))
    {
      keyType = "RSA PRIVATE KEY";
      return info.ParsePrivateKey().GetEncoded();
    }
    if (!algorithm.Equals((Asn1Object) X9ObjectIdentifiers.IdECPublicKey) && !algorithm.Equals((Asn1Object) CryptoProObjectIdentifiers.GostR3410x2001))
    {
      if (!algorithm.Equals((Asn1Object) X9ObjectIdentifiers.IdDsa) && !algorithm.Equals((Asn1Object) OiwObjectIdentifiers.DsaWithSha1))
      {
        keyType = "PRIVATE KEY";
        return info.GetEncoded();
      }
      keyType = "DSA PRIVATE KEY";
      DsaParameter instance = DsaParameter.GetInstance((object) privateKeyAlgorithm.Parameters);
      BigInteger e = DerInteger.GetInstance((object) info.ParsePrivateKey()).Value;
      BigInteger bigInteger = instance.G.ModPow(e, instance.P);
      return new DerSequence(new Asn1Encodable[6]
      {
        (Asn1Encodable) new DerInteger(0),
        (Asn1Encodable) new DerInteger(instance.P),
        (Asn1Encodable) new DerInteger(instance.Q),
        (Asn1Encodable) new DerInteger(instance.G),
        (Asn1Encodable) new DerInteger(bigInteger),
        (Asn1Encodable) new DerInteger(e)
      }).GetEncoded();
    }
    keyType = "EC PRIVATE KEY";
    return info.ParsePrivateKey().GetEncoded();
  }

  private static byte[] EncodePublicKey(AsymmetricKeyParameter akp, out string keyType)
  {
    return MiscPemGenerator.EncodePublicKeyInfo(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(akp), out keyType);
  }

  private static byte[] EncodePublicKeyInfo(SubjectPublicKeyInfo info, out string keyType)
  {
    keyType = "PUBLIC KEY";
    return info.GetEncoded();
  }
}
