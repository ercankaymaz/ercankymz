// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkcs.Pkcs10CertificationRequestDelaySigned
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pkcs;

public class Pkcs10CertificationRequestDelaySigned : Pkcs10CertificationRequest
{
  protected Pkcs10CertificationRequestDelaySigned()
  {
  }

  public Pkcs10CertificationRequestDelaySigned(byte[] encoded)
    : base(encoded)
  {
  }

  public Pkcs10CertificationRequestDelaySigned(Asn1Sequence seq)
    : base(seq)
  {
  }

  public Pkcs10CertificationRequestDelaySigned(Stream input)
    : base(input)
  {
  }

  public Pkcs10CertificationRequestDelaySigned(
    string signatureAlgorithm,
    X509Name subject,
    AsymmetricKeyParameter publicKey,
    Asn1Set attributes,
    AsymmetricKeyParameter signingKey)
    : base(signatureAlgorithm, subject, publicKey, attributes, signingKey)
  {
  }

  public Pkcs10CertificationRequestDelaySigned(
    string signatureAlgorithm,
    X509Name subject,
    AsymmetricKeyParameter publicKey,
    Asn1Set attributes)
  {
    if (signatureAlgorithm == null)
      throw new ArgumentNullException(nameof (signatureAlgorithm));
    if (subject == null)
      throw new ArgumentNullException(nameof (subject));
    if (publicKey == null)
      throw new ArgumentNullException(nameof (publicKey));
    if (publicKey.IsPrivate)
      throw new ArgumentException("expected public key", nameof (publicKey));
    DerObjectIdentifier algorithm = CollectionUtilities.GetValueOrNull<string, DerObjectIdentifier>((IDictionary<string, DerObjectIdentifier>) Pkcs10CertificationRequest.m_algorithms, signatureAlgorithm);
    if (algorithm == null)
    {
      try
      {
        algorithm = new DerObjectIdentifier(signatureAlgorithm);
      }
      catch (Exception ex)
      {
        throw new ArgumentException("Unknown signature type requested", ex);
      }
    }
    if (Pkcs10CertificationRequest.m_noParams.Contains(algorithm))
    {
      this.sigAlgId = new AlgorithmIdentifier(algorithm);
    }
    else
    {
      Asn1Encodable parameters;
      if (Pkcs10CertificationRequest.m_exParams.TryGetValue(signatureAlgorithm, out parameters))
        this.sigAlgId = new AlgorithmIdentifier(algorithm, parameters);
      else
        this.sigAlgId = new AlgorithmIdentifier(algorithm, (Asn1Encodable) DerNull.Instance);
    }
    SubjectPublicKeyInfo subjectPublicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKey);
    this.reqInfo = new CertificationRequestInfo(subject, subjectPublicKeyInfo, attributes);
  }

  public byte[] GetDataToSign() => this.reqInfo.GetDerEncoded();

  public void SignRequest(byte[] signedData) => this.sigBits = new DerBitString(signedData);

  public void SignRequest(DerBitString signedData) => this.sigBits = signedData;
}
