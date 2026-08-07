// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Rosstandart.RosstandartObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Rosstandart;

public abstract class RosstandartObjectIdentifiers
{
  public static readonly DerObjectIdentifier rosstandart = new DerObjectIdentifier("1.2.643.7");
  public static readonly DerObjectIdentifier id_tc26 = RosstandartObjectIdentifiers.rosstandart.Branch("1");
  public static readonly DerObjectIdentifier id_tc26_gost_3411_12_256 = RosstandartObjectIdentifiers.id_tc26.Branch("1.2.2");
  public static readonly DerObjectIdentifier id_tc26_gost_3411_12_512 = RosstandartObjectIdentifiers.id_tc26.Branch("1.2.3");
  public static readonly DerObjectIdentifier id_tc26_hmac_gost_3411_12_256 = RosstandartObjectIdentifiers.id_tc26.Branch("1.4.1");
  public static readonly DerObjectIdentifier id_tc26_hmac_gost_3411_12_512 = RosstandartObjectIdentifiers.id_tc26.Branch("1.4.2");
  public static readonly DerObjectIdentifier id_tc26_gost_3410_12_256 = RosstandartObjectIdentifiers.id_tc26.Branch("1.1.1");
  public static readonly DerObjectIdentifier id_tc26_gost_3410_12_512 = RosstandartObjectIdentifiers.id_tc26.Branch("1.1.2");
  public static readonly DerObjectIdentifier id_tc26_signwithdigest_gost_3410_12_256 = RosstandartObjectIdentifiers.id_tc26.Branch("1.3.2");
  public static readonly DerObjectIdentifier id_tc26_signwithdigest_gost_3410_12_512 = RosstandartObjectIdentifiers.id_tc26.Branch("1.3.3");
  public static readonly DerObjectIdentifier id_tc26_agreement = RosstandartObjectIdentifiers.id_tc26.Branch("1.6");
  public static readonly DerObjectIdentifier id_tc26_agreement_gost_3410_12_256 = RosstandartObjectIdentifiers.id_tc26_agreement.Branch("1");
  public static readonly DerObjectIdentifier id_tc26_agreement_gost_3410_12_512 = RosstandartObjectIdentifiers.id_tc26_agreement.Branch("2");
  public static readonly DerObjectIdentifier id_tc26_gost_3410_12_256_paramSet = RosstandartObjectIdentifiers.id_tc26.Branch("2.1.1");
  public static readonly DerObjectIdentifier id_tc26_gost_3410_12_256_paramSetA = RosstandartObjectIdentifiers.id_tc26_gost_3410_12_256_paramSet.Branch("1");
  public static readonly DerObjectIdentifier id_tc26_gost_3410_12_512_paramSet = RosstandartObjectIdentifiers.id_tc26.Branch("2.1.2");
  public static readonly DerObjectIdentifier id_tc26_gost_3410_12_512_paramSetA = RosstandartObjectIdentifiers.id_tc26_gost_3410_12_512_paramSet.Branch("1");
  public static readonly DerObjectIdentifier id_tc26_gost_3410_12_512_paramSetB = RosstandartObjectIdentifiers.id_tc26_gost_3410_12_512_paramSet.Branch("2");
  public static readonly DerObjectIdentifier id_tc26_gost_3410_12_512_paramSetC = RosstandartObjectIdentifiers.id_tc26_gost_3410_12_512_paramSet.Branch("3");
  public static readonly DerObjectIdentifier id_tc26_gost_28147_param_Z = RosstandartObjectIdentifiers.id_tc26.Branch("2.5.1.1");
}
