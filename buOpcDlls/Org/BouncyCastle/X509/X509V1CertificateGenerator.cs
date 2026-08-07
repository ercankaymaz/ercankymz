// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509V1CertificateGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.X509;

public class X509V1CertificateGenerator
{
  private V1TbsCertificateGenerator tbsGen;

  public X509V1CertificateGenerator() => this.tbsGen = new V1TbsCertificateGenerator();

  public void Reset() => this.tbsGen = new V1TbsCertificateGenerator();

  public void SetSerialNumber(BigInteger serialNumber)
  {
    if (serialNumber.SignValue <= 0)
      throw new ArgumentException("serial number must be a positive integer", nameof (serialNumber));
    this.tbsGen.SetSerialNumber(new DerInteger(serialNumber));
  }

  public void SetIssuerDN(X509Name issuer) => this.tbsGen.SetIssuer(issuer);

  public void SetNotBefore(DateTime date) => this.tbsGen.SetStartDate(new Time(date));

  public void SetNotAfter(DateTime date) => this.tbsGen.SetEndDate(new Time(date));

  public void SetSubjectDN(X509Name subject) => this.tbsGen.SetSubject(subject);

  public void SetPublicKey(AsymmetricKeyParameter publicKey)
  {
    try
    {
      this.tbsGen.SetSubjectPublicKeyInfo(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKey));
    }
    catch (Exception ex)
    {
      throw new ArgumentException("unable to process key - " + ex.ToString());
    }
  }

  public X509Certificate Generate(ISignatureFactory signatureFactory)
  {
    AlgorithmIdentifier algorithmDetails = (AlgorithmIdentifier) signatureFactory.AlgorithmDetails;
    this.tbsGen.SetSignature(algorithmDetails);
    TbsCertificateStructure tbsCertificate = this.tbsGen.GenerateTbsCertificate();
    DerBitString signature = X509Utilities.GenerateSignature(signatureFactory, (Asn1Encodable) tbsCertificate);
    return new X509Certificate(new X509CertificateStructure(tbsCertificate, algorithmDetails, signature));
  }

  public IEnumerable<string> SignatureAlgNames => X509Utilities.GetAlgNames();
}
