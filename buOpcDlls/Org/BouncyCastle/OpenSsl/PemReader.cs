// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.OpenSsl.PemReader
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.Utilities.IO.Pem;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.OpenSsl;

public class PemReader : Org.BouncyCastle.Utilities.IO.Pem.PemReader
{
  private readonly IPasswordFinder pFinder;

  public PemReader(TextReader reader)
    : this(reader, (IPasswordFinder) null)
  {
  }

  public PemReader(TextReader reader, IPasswordFinder pFinder)
    : base(reader)
  {
    this.pFinder = pFinder;
  }

  public object ReadObject()
  {
    PemObject pemObject = this.ReadPemObject();
    if (pemObject == null)
      return (object) null;
    if (Platform.EndsWith(pemObject.Type, "PRIVATE KEY"))
      return this.ReadPrivateKey(pemObject);
    switch (pemObject.Type)
    {
      case "ATTRIBUTE CERTIFICATE":
        return (object) this.ReadAttributeCertificate(pemObject);
      case "CERTIFICATE":
      case "X509 CERTIFICATE":
        return (object) this.ReadCertificate(pemObject);
      case "CERTIFICATE REQUEST":
      case "NEW CERTIFICATE REQUEST":
        return (object) this.ReadCertificateRequest(pemObject);
      case "CMS":
      case "PKCS7":
        return (object) this.ReadPkcs7(pemObject);
      case "PUBLIC KEY":
        return (object) this.ReadPublicKey(pemObject);
      case "RSA PUBLIC KEY":
        return (object) this.ReadRsaPublicKey(pemObject);
      case "X509 CRL":
        return (object) this.ReadCrl(pemObject);
      default:
        throw new IOException("unrecognised object: " + pemObject.Type);
    }
  }

  private AsymmetricKeyParameter ReadRsaPublicKey(PemObject pemObject)
  {
    RsaPublicKeyStructure instance = RsaPublicKeyStructure.GetInstance((object) Asn1Object.FromByteArray(pemObject.Content));
    return (AsymmetricKeyParameter) new RsaKeyParameters(false, instance.Modulus, instance.PublicExponent);
  }

  private AsymmetricKeyParameter ReadPublicKey(PemObject pemObject)
  {
    return PublicKeyFactory.CreateKey(pemObject.Content);
  }

  private X509Certificate ReadCertificate(PemObject pemObject)
  {
    try
    {
      return new X509CertificateParser().ReadCertificate(pemObject.Content);
    }
    catch (Exception ex)
    {
      throw new PemException("problem parsing cert: " + ex.ToString());
    }
  }

  private X509Crl ReadCrl(PemObject pemObject)
  {
    try
    {
      return new X509CrlParser().ReadCrl(pemObject.Content);
    }
    catch (Exception ex)
    {
      throw new PemException("problem parsing cert: " + ex.ToString());
    }
  }

  private Pkcs10CertificationRequest ReadCertificateRequest(PemObject pemObject)
  {
    try
    {
      return new Pkcs10CertificationRequest(pemObject.Content);
    }
    catch (Exception ex)
    {
      throw new PemException("problem parsing cert: " + ex.ToString());
    }
  }

  private X509V2AttributeCertificate ReadAttributeCertificate(PemObject pemObject)
  {
    return new X509V2AttributeCertificate(pemObject.Content);
  }

  private Org.BouncyCastle.Asn1.Cms.ContentInfo ReadPkcs7(PemObject pemObject)
  {
    try
    {
      return Org.BouncyCastle.Asn1.Cms.ContentInfo.GetInstance((object) Asn1Object.FromByteArray(pemObject.Content));
    }
    catch (Exception ex)
    {
      throw new PemException("problem parsing PKCS7 object: " + ex.ToString());
    }
  }

  private object ReadPrivateKey(PemObject pemObject)
  {
    string str1 = pemObject.Type.Substring(0, pemObject.Type.Length - "PRIVATE KEY".Length).Trim();
    byte[] bytes = pemObject.Content;
    Dictionary<string, string> d = new Dictionary<string, string>();
    foreach (PemHeader header in (IEnumerable<PemHeader>) pemObject.Headers)
      d[header.Name] = header.Value;
    if (CollectionUtilities.GetValueOrNull<string, string>((IDictionary<string, string>) d, "Proc-Type") == "4,ENCRYPTED")
    {
      char[] password = this.pFinder != null ? this.pFinder.GetPassword() : throw new PasswordException("No password finder specified, but a password is required");
      if (password == null)
        throw new PasswordException("Password is null, but a password is required");
      string str2;
      if (!d.TryGetValue("DEK-Info", out str2))
        throw new PemException("missing DEK-info");
      string[] strArray = str2.Split(',');
      string dekAlgName = strArray[0].Trim();
      byte[] iv = Hex.Decode(strArray[1].Trim());
      bytes = PemUtilities.Crypt(false, bytes, password, dekAlgName, iv);
    }
    try
    {
      Asn1Sequence instance1 = Asn1Sequence.GetInstance((object) bytes);
      AsymmetricKeyParameter asymmetricKeyParameter;
      AsymmetricKeyParameter publicParameter;
      switch (str1)
      {
        case "RSA":
          RsaPrivateKeyStructure privateKeyStructure = instance1.Count == 9 ? RsaPrivateKeyStructure.GetInstance((object) instance1) : throw new PemException("malformed sequence in RSA private key");
          publicParameter = (AsymmetricKeyParameter) new RsaKeyParameters(false, privateKeyStructure.Modulus, privateKeyStructure.PublicExponent);
          asymmetricKeyParameter = (AsymmetricKeyParameter) new RsaPrivateCrtKeyParameters(privateKeyStructure.Modulus, privateKeyStructure.PublicExponent, privateKeyStructure.PrivateExponent, privateKeyStructure.Prime1, privateKeyStructure.Prime2, privateKeyStructure.Exponent1, privateKeyStructure.Exponent2, privateKeyStructure.Coefficient);
          break;
        case "DSA":
          DerInteger derInteger1 = instance1.Count == 6 ? (DerInteger) instance1[1] : throw new PemException("malformed sequence in DSA private key");
          DerInteger derInteger2 = (DerInteger) instance1[2];
          DerInteger derInteger3 = (DerInteger) instance1[3];
          DerInteger derInteger4 = (DerInteger) instance1[4];
          DerInteger derInteger5 = (DerInteger) instance1[5];
          DsaParameters parameters = new DsaParameters(derInteger1.Value, derInteger2.Value, derInteger3.Value);
          asymmetricKeyParameter = (AsymmetricKeyParameter) new DsaPrivateKeyParameters(derInteger5.Value, parameters);
          publicParameter = (AsymmetricKeyParameter) new DsaPublicKeyParameters(derInteger4.Value, parameters);
          break;
        case "EC":
          ECPrivateKeyStructure instance2 = ECPrivateKeyStructure.GetInstance((object) instance1);
          AlgorithmIdentifier algorithmIdentifier = new AlgorithmIdentifier(X9ObjectIdentifiers.IdECPublicKey, (Asn1Encodable) instance2.GetParameters());
          asymmetricKeyParameter = PrivateKeyFactory.CreateKey(new PrivateKeyInfo(algorithmIdentifier, (Asn1Encodable) instance2.ToAsn1Object()));
          DerBitString publicKey = instance2.GetPublicKey();
          publicParameter = publicKey == null ? (AsymmetricKeyParameter) ECKeyPairGenerator.GetCorrespondingPublicKey((ECPrivateKeyParameters) asymmetricKeyParameter) : PublicKeyFactory.CreateKey(new SubjectPublicKeyInfo(algorithmIdentifier, publicKey.GetBytes()));
          break;
        case "ENCRYPTED":
          return (object) PrivateKeyFactory.DecryptKey(this.pFinder.GetPassword() ?? throw new PasswordException("Password is null, but a password is required"), EncryptedPrivateKeyInfo.GetInstance((object) instance1));
        case "":
          return (object) PrivateKeyFactory.CreateKey(PrivateKeyInfo.GetInstance((object) instance1));
        default:
          throw new ArgumentException("Unknown key type: " + str1, "type");
      }
      return (object) new AsymmetricCipherKeyPair(publicParameter, asymmetricKeyParameter);
    }
    catch (IOException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new PemException($"problem creating {str1} private key: {ex.ToString()}");
    }
  }
}
