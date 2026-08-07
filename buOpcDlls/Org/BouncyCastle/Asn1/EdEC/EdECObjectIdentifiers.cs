// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.EdEC.EdECObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.EdEC;

public abstract class EdECObjectIdentifiers
{
  public static readonly DerObjectIdentifier id_edwards_curve_algs = new DerObjectIdentifier("1.3.101");
  public static readonly DerObjectIdentifier id_X25519 = EdECObjectIdentifiers.id_edwards_curve_algs.Branch("110");
  public static readonly DerObjectIdentifier id_X448 = EdECObjectIdentifiers.id_edwards_curve_algs.Branch("111");
  public static readonly DerObjectIdentifier id_Ed25519 = EdECObjectIdentifiers.id_edwards_curve_algs.Branch("112");
  public static readonly DerObjectIdentifier id_Ed448 = EdECObjectIdentifiers.id_edwards_curve_algs.Branch("113");
}
