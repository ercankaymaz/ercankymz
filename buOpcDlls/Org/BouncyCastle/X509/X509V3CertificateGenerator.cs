// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509V3CertificateGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.X509.Extension;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.X509;

public class X509V3CertificateGenerator
{
  private readonly X509ExtensionsGenerator extGenerator = new X509ExtensionsGenerator();
  private V3TbsCertificateGenerator tbsGen;

  public X509V3CertificateGenerator() => this.tbsGen = new V3TbsCertificateGenerator();

  public X509V3CertificateGenerator(X509Certificate template)
    : this(template.CertificateStructure)
  {
  }

  public X509V3CertificateGenerator(X509CertificateStructure template)
  {
    this.tbsGen = new V3TbsCertificateGenerator();
    this.tbsGen.SetSerialNumber(template.SerialNumber);
    this.tbsGen.SetIssuer(template.Issuer);
    this.tbsGen.SetStartDate(template.StartDate);
    this.tbsGen.SetEndDate(template.EndDate);
    this.tbsGen.SetSubject(template.Subject);
    this.tbsGen.SetSubjectPublicKeyInfo(template.SubjectPublicKeyInfo);
    X509Extensions extensions = template.TbsCertificate.Extensions;
    foreach (DerObjectIdentifier extensionOid in extensions.ExtensionOids)
    {
      if (!X509Extensions.SubjectAltPublicKeyInfo.Equals((Asn1Object) extensionOid) && !X509Extensions.AltSignatureAlgorithm.Equals((Asn1Object) extensionOid) && !X509Extensions.AltSignatureValue.Equals((Asn1Object) extensionOid))
      {
        X509Extension extension = extensions.GetExtension(extensionOid);
        this.extGenerator.AddExtension(extensionOid, extension.critical, extension.Value.GetOctets());
      }
    }
  }

  public void Reset()
  {
    this.tbsGen = new V3TbsCertificateGenerator();
    this.extGenerator.Reset();
  }

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
    this.tbsGen.SetSubjectPublicKeyInfo(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(publicKey));
  }

  public void SetSubjectUniqueID(bool[] uniqueID)
  {
    this.tbsGen.SetSubjectUniqueID(X509V3CertificateGenerator.BooleanToBitString(uniqueID));
  }

  public void SetIssuerUniqueID(bool[] uniqueID)
  {
    this.tbsGen.SetIssuerUniqueID(X509V3CertificateGenerator.BooleanToBitString(uniqueID));
  }

  public void AddExtension(string oid, bool critical, Asn1Encodable extensionValue)
  {
    this.extGenerator.AddExtension(new DerObjectIdentifier(oid), critical, extensionValue);
  }

  public void AddExtension(DerObjectIdentifier oid, bool critical, Asn1Encodable extensionValue)
  {
    this.extGenerator.AddExtension(oid, critical, extensionValue);
  }

  public void AddExtension(string oid, bool critical, byte[] extensionValue)
  {
    this.extGenerator.AddExtension(new DerObjectIdentifier(oid), critical, (Asn1Encodable) new DerOctetString(extensionValue));
  }

  public void AddExtension(DerObjectIdentifier oid, bool critical, byte[] extensionValue)
  {
    this.extGenerator.AddExtension(oid, critical, (Asn1Encodable) new DerOctetString(extensionValue));
  }

  public void CopyAndAddExtension(string oid, bool critical, X509Certificate cert)
  {
    this.CopyAndAddExtension(new DerObjectIdentifier(oid), critical, cert);
  }

  public void CopyAndAddExtension(DerObjectIdentifier oid, bool critical, X509Certificate cert)
  {
    Asn1OctetString extensionValue1 = cert.GetExtensionValue(oid);
    if (extensionValue1 == null)
      throw new CertificateParsingException($"extension {oid?.ToString()} not present");
    try
    {
      Asn1Encodable extensionValue2 = (Asn1Encodable) X509ExtensionUtilities.FromExtensionValue(extensionValue1);
      this.AddExtension(oid, critical, extensionValue2);
    }
    catch (Exception ex)
    {
      throw new CertificateParsingException(ex.Message, ex);
    }
  }

  public X509Certificate Generate(ISignatureFactory signatureFactory)
  {
    AlgorithmIdentifier algorithmDetails = (AlgorithmIdentifier) signatureFactory.AlgorithmDetails;
    this.tbsGen.SetSignature(algorithmDetails);
    if (!this.extGenerator.IsEmpty)
      this.tbsGen.SetExtensions(this.extGenerator.Generate());
    TbsCertificateStructure tbsCertificate = this.tbsGen.GenerateTbsCertificate();
    DerBitString signature = X509Utilities.GenerateSignature(signatureFactory, (Asn1Encodable) tbsCertificate);
    return new X509Certificate(new X509CertificateStructure(tbsCertificate, algorithmDetails, signature));
  }

  public X509Certificate Generate(
    ISignatureFactory signatureFactory,
    bool isCritical,
    ISignatureFactory altSignatureFactory)
  {
    this.tbsGen.SetSignature((AlgorithmIdentifier) null);
    AlgorithmIdentifier algorithmDetails = (AlgorithmIdentifier) altSignatureFactory.AlgorithmDetails;
    this.extGenerator.AddExtension(X509Extensions.AltSignatureAlgorithm, isCritical, (Asn1Encodable) algorithmDetails);
    this.tbsGen.SetExtensions(this.extGenerator.Generate());
    DerBitString signature = X509Utilities.GenerateSignature(altSignatureFactory, (Asn1Encodable) this.tbsGen.GeneratePreTbsCertificate());
    this.extGenerator.AddExtension(X509Extensions.AltSignatureValue, isCritical, (Asn1Encodable) signature);
    return this.Generate(signatureFactory);
  }

  public IEnumerable<string> SignatureAlgNames => X509Utilities.GetAlgNames();

  private static DerBitString BooleanToBitString(bool[] id)
  {
    byte[] data = new byte[(id.Length + 7) / 8];
    for (int index = 0; index != id.Length; ++index)
    {
      if (id[index])
        data[index >> 3] |= (byte) (128 /*0x80*/ >> (index & 7));
    }
    return new DerBitString(data, 8 - id.Length & 7);
  }
}
