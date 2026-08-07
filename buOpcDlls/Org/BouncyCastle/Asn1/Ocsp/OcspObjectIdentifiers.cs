// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ocsp.OcspObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Ocsp;

public abstract class OcspObjectIdentifiers
{
  internal const string PkixOcspId = "1.3.6.1.5.5.7.48.1";
  public static readonly DerObjectIdentifier PkixOcsp = new DerObjectIdentifier("1.3.6.1.5.5.7.48.1");
  public static readonly DerObjectIdentifier PkixOcspBasic = new DerObjectIdentifier("1.3.6.1.5.5.7.48.1.1");
  public static readonly DerObjectIdentifier PkixOcspNonce = new DerObjectIdentifier(OcspObjectIdentifiers.PkixOcsp?.ToString() + ".2");
  public static readonly DerObjectIdentifier PkixOcspCrl = new DerObjectIdentifier(OcspObjectIdentifiers.PkixOcsp?.ToString() + ".3");
  public static readonly DerObjectIdentifier PkixOcspResponse = new DerObjectIdentifier(OcspObjectIdentifiers.PkixOcsp?.ToString() + ".4");
  public static readonly DerObjectIdentifier PkixOcspNocheck = new DerObjectIdentifier(OcspObjectIdentifiers.PkixOcsp?.ToString() + ".5");
  public static readonly DerObjectIdentifier PkixOcspArchiveCutoff = new DerObjectIdentifier(OcspObjectIdentifiers.PkixOcsp?.ToString() + ".6");
  public static readonly DerObjectIdentifier PkixOcspServiceLocator = new DerObjectIdentifier(OcspObjectIdentifiers.PkixOcsp?.ToString() + ".7");
}
