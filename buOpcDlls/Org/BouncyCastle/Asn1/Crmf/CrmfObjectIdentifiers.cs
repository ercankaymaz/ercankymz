// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.CrmfObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public abstract class CrmfObjectIdentifiers
{
  public static readonly DerObjectIdentifier id_pkix = new DerObjectIdentifier("1.3.6.1.5.5.7");
  public static readonly DerObjectIdentifier id_pkip = CrmfObjectIdentifiers.id_pkix.Branch("5");
  public static readonly DerObjectIdentifier id_regCtrl = CrmfObjectIdentifiers.id_pkip.Branch("1");
  public static readonly DerObjectIdentifier id_regCtrl_regToken = CrmfObjectIdentifiers.id_regCtrl.Branch("1");
  public static readonly DerObjectIdentifier id_regCtrl_authenticator = CrmfObjectIdentifiers.id_regCtrl.Branch("2");
  public static readonly DerObjectIdentifier id_regCtrl_pkiPublicationInfo = CrmfObjectIdentifiers.id_regCtrl.Branch("3");
  public static readonly DerObjectIdentifier id_regCtrl_pkiArchiveOptions = CrmfObjectIdentifiers.id_regCtrl.Branch("4");
  public static readonly DerObjectIdentifier id_ct_encKeyWithID = new DerObjectIdentifier("1.2.840.113549.1.9.16.1.21");
}
