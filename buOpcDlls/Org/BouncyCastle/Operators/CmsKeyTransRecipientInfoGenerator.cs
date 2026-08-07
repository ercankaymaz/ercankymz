// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Operators.CmsKeyTransRecipientInfoGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.X509;

#nullable disable
namespace Org.BouncyCastle.Operators;

public class CmsKeyTransRecipientInfoGenerator : KeyTransRecipientInfoGenerator
{
  public CmsKeyTransRecipientInfoGenerator(X509Certificate recipCert, IKeyWrapper keyWrapper)
    : base(new IssuerAndSerialNumber(recipCert.IssuerDN, new DerInteger(recipCert.SerialNumber)), keyWrapper)
  {
  }

  public CmsKeyTransRecipientInfoGenerator(
    IssuerAndSerialNumber issuerAndSerial,
    IKeyWrapper keyWrapper)
    : base(issuerAndSerial, keyWrapper)
  {
  }

  public CmsKeyTransRecipientInfoGenerator(byte[] subjectKeyID, IKeyWrapper keyWrapper)
    : base(subjectKeyID, keyWrapper)
  {
  }
}
