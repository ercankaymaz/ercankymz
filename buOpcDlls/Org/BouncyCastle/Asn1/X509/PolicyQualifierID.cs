// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.PolicyQualifierID
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public sealed class PolicyQualifierID : DerObjectIdentifier
{
  private const string IdQt = "1.3.6.1.5.5.7.2";
  public static readonly PolicyQualifierID IdQtCps = new PolicyQualifierID("1.3.6.1.5.5.7.2.1");
  public static readonly PolicyQualifierID IdQtUnotice = new PolicyQualifierID("1.3.6.1.5.5.7.2.2");

  private PolicyQualifierID(string id)
    : base(id)
  {
  }
}
