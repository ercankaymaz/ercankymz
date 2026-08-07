// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Nsri.NsriObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Nsri;

public sealed class NsriObjectIdentifiers
{
  public static readonly DerObjectIdentifier nsri = new DerObjectIdentifier("1.2.410.200046");
  public static readonly DerObjectIdentifier id_algorithm = NsriObjectIdentifiers.nsri.Branch("1");
  public static readonly DerObjectIdentifier id_sea = NsriObjectIdentifiers.id_algorithm.Branch("1");
  public static readonly DerObjectIdentifier id_pad = NsriObjectIdentifiers.id_algorithm.Branch("2");
  public static readonly DerObjectIdentifier id_pad_null = NsriObjectIdentifiers.id_algorithm.Branch("0");
  public static readonly DerObjectIdentifier id_pad_1 = NsriObjectIdentifiers.id_algorithm.Branch("1");
  public static readonly DerObjectIdentifier id_aria128_ecb = NsriObjectIdentifiers.id_sea.Branch("1");
  public static readonly DerObjectIdentifier id_aria128_cbc = NsriObjectIdentifiers.id_sea.Branch("2");
  public static readonly DerObjectIdentifier id_aria128_cfb = NsriObjectIdentifiers.id_sea.Branch("3");
  public static readonly DerObjectIdentifier id_aria128_ofb = NsriObjectIdentifiers.id_sea.Branch("4");
  public static readonly DerObjectIdentifier id_aria128_ctr = NsriObjectIdentifiers.id_sea.Branch("5");
  public static readonly DerObjectIdentifier id_aria192_ecb = NsriObjectIdentifiers.id_sea.Branch("6");
  public static readonly DerObjectIdentifier id_aria192_cbc = NsriObjectIdentifiers.id_sea.Branch("7");
  public static readonly DerObjectIdentifier id_aria192_cfb = NsriObjectIdentifiers.id_sea.Branch("8");
  public static readonly DerObjectIdentifier id_aria192_ofb = NsriObjectIdentifiers.id_sea.Branch("9");
  public static readonly DerObjectIdentifier id_aria192_ctr = NsriObjectIdentifiers.id_sea.Branch("10");
  public static readonly DerObjectIdentifier id_aria256_ecb = NsriObjectIdentifiers.id_sea.Branch("11");
  public static readonly DerObjectIdentifier id_aria256_cbc = NsriObjectIdentifiers.id_sea.Branch("12");
  public static readonly DerObjectIdentifier id_aria256_cfb = NsriObjectIdentifiers.id_sea.Branch("13");
  public static readonly DerObjectIdentifier id_aria256_ofb = NsriObjectIdentifiers.id_sea.Branch("14");
  public static readonly DerObjectIdentifier id_aria256_ctr = NsriObjectIdentifiers.id_sea.Branch("15");
  public static readonly DerObjectIdentifier id_aria128_cmac = NsriObjectIdentifiers.id_sea.Branch("21");
  public static readonly DerObjectIdentifier id_aria192_cmac = NsriObjectIdentifiers.id_sea.Branch("22");
  public static readonly DerObjectIdentifier id_aria256_cmac = NsriObjectIdentifiers.id_sea.Branch("23");
  public static readonly DerObjectIdentifier id_aria128_ocb2 = NsriObjectIdentifiers.id_sea.Branch("31");
  public static readonly DerObjectIdentifier id_aria192_ocb2 = NsriObjectIdentifiers.id_sea.Branch("32");
  public static readonly DerObjectIdentifier id_aria256_ocb2 = NsriObjectIdentifiers.id_sea.Branch("33");
  public static readonly DerObjectIdentifier id_aria128_gcm = NsriObjectIdentifiers.id_sea.Branch("34");
  public static readonly DerObjectIdentifier id_aria192_gcm = NsriObjectIdentifiers.id_sea.Branch("35");
  public static readonly DerObjectIdentifier id_aria256_gcm = NsriObjectIdentifiers.id_sea.Branch("36");
  public static readonly DerObjectIdentifier id_aria128_ccm = NsriObjectIdentifiers.id_sea.Branch("37");
  public static readonly DerObjectIdentifier id_aria192_ccm = NsriObjectIdentifiers.id_sea.Branch("38");
  public static readonly DerObjectIdentifier id_aria256_ccm = NsriObjectIdentifiers.id_sea.Branch("39");
  public static readonly DerObjectIdentifier id_aria128_kw = NsriObjectIdentifiers.id_sea.Branch("40");
  public static readonly DerObjectIdentifier id_aria192_kw = NsriObjectIdentifiers.id_sea.Branch("41");
  public static readonly DerObjectIdentifier id_aria256_kw = NsriObjectIdentifiers.id_sea.Branch("42");
  public static readonly DerObjectIdentifier id_aria128_kwp = NsriObjectIdentifiers.id_sea.Branch("43");
  public static readonly DerObjectIdentifier id_aria192_kwp = NsriObjectIdentifiers.id_sea.Branch("44");
  public static readonly DerObjectIdentifier id_aria256_kwp = NsriObjectIdentifiers.id_sea.Branch("45");
}
