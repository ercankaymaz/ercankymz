// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.GM.GMObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.GM;

public abstract class GMObjectIdentifiers
{
  public static readonly DerObjectIdentifier sm_scheme = new DerObjectIdentifier("1.2.156.10197.1");
  public static readonly DerObjectIdentifier sm6_ecb = GMObjectIdentifiers.sm_scheme.Branch("101.1");
  public static readonly DerObjectIdentifier sm6_cbc = GMObjectIdentifiers.sm_scheme.Branch("101.2");
  public static readonly DerObjectIdentifier sm6_ofb128 = GMObjectIdentifiers.sm_scheme.Branch("101.3");
  public static readonly DerObjectIdentifier sm6_cfb128 = GMObjectIdentifiers.sm_scheme.Branch("101.4");
  public static readonly DerObjectIdentifier sm1_ecb = GMObjectIdentifiers.sm_scheme.Branch("102.1");
  public static readonly DerObjectIdentifier sm1_cbc = GMObjectIdentifiers.sm_scheme.Branch("102.2");
  public static readonly DerObjectIdentifier sm1_ofb128 = GMObjectIdentifiers.sm_scheme.Branch("102.3");
  public static readonly DerObjectIdentifier sm1_cfb128 = GMObjectIdentifiers.sm_scheme.Branch("102.4");
  public static readonly DerObjectIdentifier sm1_cfb1 = GMObjectIdentifiers.sm_scheme.Branch("102.5");
  public static readonly DerObjectIdentifier sm1_cfb8 = GMObjectIdentifiers.sm_scheme.Branch("102.6");
  public static readonly DerObjectIdentifier ssf33_ecb = GMObjectIdentifiers.sm_scheme.Branch("103.1");
  public static readonly DerObjectIdentifier ssf33_cbc = GMObjectIdentifiers.sm_scheme.Branch("103.2");
  public static readonly DerObjectIdentifier ssf33_ofb128 = GMObjectIdentifiers.sm_scheme.Branch("103.3");
  public static readonly DerObjectIdentifier ssf33_cfb128 = GMObjectIdentifiers.sm_scheme.Branch("103.4");
  public static readonly DerObjectIdentifier ssf33_cfb1 = GMObjectIdentifiers.sm_scheme.Branch("103.5");
  public static readonly DerObjectIdentifier ssf33_cfb8 = GMObjectIdentifiers.sm_scheme.Branch("103.6");
  public static readonly DerObjectIdentifier sms4_ecb = GMObjectIdentifiers.sm_scheme.Branch("104.1");
  public static readonly DerObjectIdentifier sms4_cbc = GMObjectIdentifiers.sm_scheme.Branch("104.2");
  public static readonly DerObjectIdentifier sms4_ofb128 = GMObjectIdentifiers.sm_scheme.Branch("104.3");
  public static readonly DerObjectIdentifier sms4_cfb128 = GMObjectIdentifiers.sm_scheme.Branch("104.4");
  public static readonly DerObjectIdentifier sms4_cfb1 = GMObjectIdentifiers.sm_scheme.Branch("104.5");
  public static readonly DerObjectIdentifier sms4_cfb8 = GMObjectIdentifiers.sm_scheme.Branch("104.6");
  public static readonly DerObjectIdentifier sms4_ctr = GMObjectIdentifiers.sm_scheme.Branch("104.7");
  public static readonly DerObjectIdentifier sms4_gcm = GMObjectIdentifiers.sm_scheme.Branch("104.8");
  public static readonly DerObjectIdentifier sms4_ccm = GMObjectIdentifiers.sm_scheme.Branch("104.9");
  public static readonly DerObjectIdentifier sms4_xts = GMObjectIdentifiers.sm_scheme.Branch("104.10");
  public static readonly DerObjectIdentifier sms4_wrap = GMObjectIdentifiers.sm_scheme.Branch("104.11");
  public static readonly DerObjectIdentifier sms4_wrap_pad = GMObjectIdentifiers.sm_scheme.Branch("104.12");
  public static readonly DerObjectIdentifier sms4_ocb = GMObjectIdentifiers.sm_scheme.Branch("104.100");
  public static readonly DerObjectIdentifier sm5 = GMObjectIdentifiers.sm_scheme.Branch("201");
  public static readonly DerObjectIdentifier sm2p256v1 = GMObjectIdentifiers.sm_scheme.Branch("301");
  public static readonly DerObjectIdentifier sm2sign = GMObjectIdentifiers.sm_scheme.Branch("301.1");
  public static readonly DerObjectIdentifier sm2exchange = GMObjectIdentifiers.sm_scheme.Branch("301.2");
  public static readonly DerObjectIdentifier sm2encrypt = GMObjectIdentifiers.sm_scheme.Branch("301.3");
  public static readonly DerObjectIdentifier wapip192v1 = GMObjectIdentifiers.sm_scheme.Branch("301.101");
  public static readonly DerObjectIdentifier sm2encrypt_recommendedParameters = GMObjectIdentifiers.sm2encrypt.Branch("1");
  public static readonly DerObjectIdentifier sm2encrypt_specifiedParameters = GMObjectIdentifiers.sm2encrypt.Branch("2");
  public static readonly DerObjectIdentifier sm2encrypt_with_sm3 = GMObjectIdentifiers.sm2encrypt.Branch("2.1");
  public static readonly DerObjectIdentifier sm2encrypt_with_sha1 = GMObjectIdentifiers.sm2encrypt.Branch("2.2");
  public static readonly DerObjectIdentifier sm2encrypt_with_sha224 = GMObjectIdentifiers.sm2encrypt.Branch("2.3");
  public static readonly DerObjectIdentifier sm2encrypt_with_sha256 = GMObjectIdentifiers.sm2encrypt.Branch("2.4");
  public static readonly DerObjectIdentifier sm2encrypt_with_sha384 = GMObjectIdentifiers.sm2encrypt.Branch("2.5");
  public static readonly DerObjectIdentifier sm2encrypt_with_sha512 = GMObjectIdentifiers.sm2encrypt.Branch("2.6");
  public static readonly DerObjectIdentifier sm2encrypt_with_rmd160 = GMObjectIdentifiers.sm2encrypt.Branch("2.7");
  public static readonly DerObjectIdentifier sm2encrypt_with_whirlpool = GMObjectIdentifiers.sm2encrypt.Branch("2.8");
  public static readonly DerObjectIdentifier sm2encrypt_with_blake2b512 = GMObjectIdentifiers.sm2encrypt.Branch("2.9");
  public static readonly DerObjectIdentifier sm2encrypt_with_blake2s256 = GMObjectIdentifiers.sm2encrypt.Branch("2.10");
  public static readonly DerObjectIdentifier sm2encrypt_with_md5 = GMObjectIdentifiers.sm2encrypt.Branch("2.11");
  public static readonly DerObjectIdentifier id_sm9PublicKey = GMObjectIdentifiers.sm_scheme.Branch("302");
  public static readonly DerObjectIdentifier sm9sign = GMObjectIdentifiers.sm_scheme.Branch("302.1");
  public static readonly DerObjectIdentifier sm9keyagreement = GMObjectIdentifiers.sm_scheme.Branch("302.2");
  public static readonly DerObjectIdentifier sm9encrypt = GMObjectIdentifiers.sm_scheme.Branch("302.3");
  public static readonly DerObjectIdentifier sm3 = GMObjectIdentifiers.sm_scheme.Branch("401");
  public static readonly DerObjectIdentifier hmac_sm3 = GMObjectIdentifiers.sm3.Branch("2");
  public static readonly DerObjectIdentifier sm2sign_with_sm3 = GMObjectIdentifiers.sm_scheme.Branch("501");
  public static readonly DerObjectIdentifier sm2sign_with_sha1 = GMObjectIdentifiers.sm_scheme.Branch("502");
  public static readonly DerObjectIdentifier sm2sign_with_sha256 = GMObjectIdentifiers.sm_scheme.Branch("503");
  public static readonly DerObjectIdentifier sm2sign_with_sha512 = GMObjectIdentifiers.sm_scheme.Branch("504");
  public static readonly DerObjectIdentifier sm2sign_with_sha224 = GMObjectIdentifiers.sm_scheme.Branch("505");
  public static readonly DerObjectIdentifier sm2sign_with_sha384 = GMObjectIdentifiers.sm_scheme.Branch("506");
  public static readonly DerObjectIdentifier sm2sign_with_rmd160 = GMObjectIdentifiers.sm_scheme.Branch("507");
  public static readonly DerObjectIdentifier sm2sign_with_whirlpool = GMObjectIdentifiers.sm_scheme.Branch("520");
  public static readonly DerObjectIdentifier sm2sign_with_blake2b512 = GMObjectIdentifiers.sm_scheme.Branch("521");
  public static readonly DerObjectIdentifier sm2sign_with_blake2s256 = GMObjectIdentifiers.sm_scheme.Branch("522");
}
