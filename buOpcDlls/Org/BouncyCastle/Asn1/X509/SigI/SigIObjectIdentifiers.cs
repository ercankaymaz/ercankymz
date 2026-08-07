// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.SigI.SigIObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.X509.SigI;

public sealed class SigIObjectIdentifiers
{
  public static readonly DerObjectIdentifier IdSigI = new DerObjectIdentifier("1.3.36.8");
  public static readonly DerObjectIdentifier IdSigIKP = new DerObjectIdentifier(SigIObjectIdentifiers.IdSigI?.ToString() + ".2");
  public static readonly DerObjectIdentifier IdSigICP = new DerObjectIdentifier(SigIObjectIdentifiers.IdSigI?.ToString() + ".1");
  public static readonly DerObjectIdentifier IdSigION = new DerObjectIdentifier(SigIObjectIdentifiers.IdSigI?.ToString() + ".4");
  public static readonly DerObjectIdentifier IdSigIKPDirectoryService = new DerObjectIdentifier(SigIObjectIdentifiers.IdSigIKP?.ToString() + ".1");
  public static readonly DerObjectIdentifier IdSigIONPersonalData = new DerObjectIdentifier(SigIObjectIdentifiers.IdSigION?.ToString() + ".1");
  public static readonly DerObjectIdentifier IdSigICPSigConform = new DerObjectIdentifier(SigIObjectIdentifiers.IdSigICP?.ToString() + ".1");

  private SigIObjectIdentifiers()
  {
  }
}
