// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.UA.UAObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.UA;

public abstract class UAObjectIdentifiers
{
  public static readonly DerObjectIdentifier UaOid = new DerObjectIdentifier("1.2.804.2.1.1.1");
  public static readonly DerObjectIdentifier dstu4145le = UAObjectIdentifiers.UaOid.Branch("1.3.1.1");
  public static readonly DerObjectIdentifier dstu4145be = UAObjectIdentifiers.UaOid.Branch("1.3.1.1.1.1");
  public static readonly DerObjectIdentifier dstu7564digest_256 = UAObjectIdentifiers.UaOid.Branch("1.2.2.1");
  public static readonly DerObjectIdentifier dstu7564digest_384 = UAObjectIdentifiers.UaOid.Branch("1.2.2.2");
  public static readonly DerObjectIdentifier dstu7564digest_512 = UAObjectIdentifiers.UaOid.Branch("1.2.2.3");
  public static readonly DerObjectIdentifier dstu7564mac_256 = UAObjectIdentifiers.UaOid.Branch("1.2.2.4");
  public static readonly DerObjectIdentifier dstu7564mac_384 = UAObjectIdentifiers.UaOid.Branch("1.2.2.5");
  public static readonly DerObjectIdentifier dstu7564mac_512 = UAObjectIdentifiers.UaOid.Branch("1.2.2.6");
  public static readonly DerObjectIdentifier dstu7624ecb_128 = UAObjectIdentifiers.UaOid.Branch("1.1.3.1.1");
  public static readonly DerObjectIdentifier dstu7624ecb_256 = UAObjectIdentifiers.UaOid.Branch("1.1.3.1.2");
  public static readonly DerObjectIdentifier dstu7624ecb_512 = UAObjectIdentifiers.UaOid.Branch("1.1.3.1.3");
  public static readonly DerObjectIdentifier dstu7624ctr_128 = UAObjectIdentifiers.UaOid.Branch("1.1.3.2.1");
  public static readonly DerObjectIdentifier dstu7624ctr_256 = UAObjectIdentifiers.UaOid.Branch("1.1.3.2.2");
  public static readonly DerObjectIdentifier dstu7624ctr_512 = UAObjectIdentifiers.UaOid.Branch("1.1.3.2.3");
  public static readonly DerObjectIdentifier dstu7624cfb_128 = UAObjectIdentifiers.UaOid.Branch("1.1.3.3.1");
  public static readonly DerObjectIdentifier dstu7624cfb_256 = UAObjectIdentifiers.UaOid.Branch("1.1.3.3.2");
  public static readonly DerObjectIdentifier dstu7624cfb_512 = UAObjectIdentifiers.UaOid.Branch("1.1.3.3.3");
  public static readonly DerObjectIdentifier dstu7624cmac_128 = UAObjectIdentifiers.UaOid.Branch("1.1.3.4.1");
  public static readonly DerObjectIdentifier dstu7624cmac_256 = UAObjectIdentifiers.UaOid.Branch("1.1.3.4.2");
  public static readonly DerObjectIdentifier dstu7624cmac_512 = UAObjectIdentifiers.UaOid.Branch("1.1.3.4.3");
  public static readonly DerObjectIdentifier dstu7624cbc_128 = UAObjectIdentifiers.UaOid.Branch("1.1.3.5.1");
  public static readonly DerObjectIdentifier dstu7624cbc_256 = UAObjectIdentifiers.UaOid.Branch("1.1.3.5.2");
  public static readonly DerObjectIdentifier dstu7624cbc_512 = UAObjectIdentifiers.UaOid.Branch("1.1.3.5.3");
  public static readonly DerObjectIdentifier dstu7624ofb_128 = UAObjectIdentifiers.UaOid.Branch("1.1.3.6.1");
  public static readonly DerObjectIdentifier dstu7624ofb_256 = UAObjectIdentifiers.UaOid.Branch("1.1.3.6.2");
  public static readonly DerObjectIdentifier dstu7624ofb_512 = UAObjectIdentifiers.UaOid.Branch("1.1.3.6.3");
  public static readonly DerObjectIdentifier dstu7624gmac_128 = UAObjectIdentifiers.UaOid.Branch("1.1.3.7.1");
  public static readonly DerObjectIdentifier dstu7624gmac_256 = UAObjectIdentifiers.UaOid.Branch("1.1.3.7.2");
  public static readonly DerObjectIdentifier dstu7624gmac_512 = UAObjectIdentifiers.UaOid.Branch("1.1.3.7.3");
  public static readonly DerObjectIdentifier dstu7624ccm_128 = UAObjectIdentifiers.UaOid.Branch("1.1.3.8.1");
  public static readonly DerObjectIdentifier dstu7624ccm_256 = UAObjectIdentifiers.UaOid.Branch("1.1.3.8.2");
  public static readonly DerObjectIdentifier dstu7624ccm_512 = UAObjectIdentifiers.UaOid.Branch("1.1.3.8.3");
  public static readonly DerObjectIdentifier dstu7624xts_128 = UAObjectIdentifiers.UaOid.Branch("1.1.3.9.1");
  public static readonly DerObjectIdentifier dstu7624xts_256 = UAObjectIdentifiers.UaOid.Branch("1.1.3.9.2");
  public static readonly DerObjectIdentifier dstu7624xts_512 = UAObjectIdentifiers.UaOid.Branch("1.1.3.9.3");
  public static readonly DerObjectIdentifier dstu7624kw_128 = UAObjectIdentifiers.UaOid.Branch("1.1.3.10.1");
  public static readonly DerObjectIdentifier dstu7624kw_256 = UAObjectIdentifiers.UaOid.Branch("1.1.3.10.2");
  public static readonly DerObjectIdentifier dstu7624kw_512 = UAObjectIdentifiers.UaOid.Branch("1.1.3.10.3");
}
