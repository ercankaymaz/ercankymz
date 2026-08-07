// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.Qualified.Rfc3739QCObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.X509.Qualified;

public sealed class Rfc3739QCObjectIdentifiers
{
  public static readonly DerObjectIdentifier IdQcs = new DerObjectIdentifier("1.3.6.1.5.5.7.11");
  public static readonly DerObjectIdentifier IdQcsPkixQCSyntaxV1 = new DerObjectIdentifier(Rfc3739QCObjectIdentifiers.IdQcs?.ToString() + ".1");
  public static readonly DerObjectIdentifier IdQcsPkixQCSyntaxV2 = new DerObjectIdentifier(Rfc3739QCObjectIdentifiers.IdQcs?.ToString() + ".2");

  private Rfc3739QCObjectIdentifiers()
  {
  }
}
