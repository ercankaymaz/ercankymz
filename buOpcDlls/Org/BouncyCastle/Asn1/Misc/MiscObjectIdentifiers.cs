// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Misc.MiscObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Misc;

public abstract class MiscObjectIdentifiers
{
  public static readonly DerObjectIdentifier Netscape = new DerObjectIdentifier("2.16.840.1.113730.1");
  public static readonly DerObjectIdentifier NetscapeCertType = MiscObjectIdentifiers.Netscape.Branch("1");
  public static readonly DerObjectIdentifier NetscapeBaseUrl = MiscObjectIdentifiers.Netscape.Branch("2");
  public static readonly DerObjectIdentifier NetscapeRevocationUrl = MiscObjectIdentifiers.Netscape.Branch("3");
  public static readonly DerObjectIdentifier NetscapeCARevocationUrl = MiscObjectIdentifiers.Netscape.Branch("4");
  public static readonly DerObjectIdentifier NetscapeRenewalUrl = MiscObjectIdentifiers.Netscape.Branch("7");
  public static readonly DerObjectIdentifier NetscapeCAPolicyUrl = MiscObjectIdentifiers.Netscape.Branch("8");
  public static readonly DerObjectIdentifier NetscapeSslServerName = MiscObjectIdentifiers.Netscape.Branch("12");
  public static readonly DerObjectIdentifier NetscapeCertComment = MiscObjectIdentifiers.Netscape.Branch("13");
  public static readonly DerObjectIdentifier Verisign = new DerObjectIdentifier("2.16.840.1.113733.1");
  public static readonly DerObjectIdentifier VerisignCzagExtension = MiscObjectIdentifiers.Verisign.Branch("6.3");
  public static readonly DerObjectIdentifier VerisignPrivate_6_9 = MiscObjectIdentifiers.Verisign.Branch("6.9");
  public static readonly DerObjectIdentifier VerisignOnSiteJurisdictionHash = MiscObjectIdentifiers.Verisign.Branch("6.11");
  public static readonly DerObjectIdentifier VerisignBitString_6_13 = MiscObjectIdentifiers.Verisign.Branch("6.13");
  public static readonly DerObjectIdentifier VerisignDnbDunsNumber = MiscObjectIdentifiers.Verisign.Branch("6.15");
  public static readonly DerObjectIdentifier VerisignIssStrongCrypto = MiscObjectIdentifiers.Verisign.Branch("8.1");
  public static readonly DerObjectIdentifier Novell = new DerObjectIdentifier("2.16.840.1.113719");
  public static readonly DerObjectIdentifier NovellSecurityAttribs = MiscObjectIdentifiers.Novell.Branch("1.9.4.1");
  public static readonly DerObjectIdentifier Entrust = new DerObjectIdentifier("1.2.840.113533.7");
  public static readonly DerObjectIdentifier EntrustVersionExtension = MiscObjectIdentifiers.Entrust.Branch("65.0");
  public static readonly DerObjectIdentifier cast5CBC = MiscObjectIdentifiers.Entrust.Branch("66.10");
  public static readonly DerObjectIdentifier HMAC_SHA1 = new DerObjectIdentifier("1.3.6.1.5.5.8.1.2");
  public static readonly DerObjectIdentifier as_sys_sec_alg_ideaCBC = new DerObjectIdentifier("1.3.6.1.4.1.188.7.1.1.2");
  public static readonly DerObjectIdentifier cryptlib = new DerObjectIdentifier("1.3.6.1.4.1.3029");
  public static readonly DerObjectIdentifier cryptlib_algorithm = MiscObjectIdentifiers.cryptlib.Branch("1");
  public static readonly DerObjectIdentifier cryptlib_algorithm_blowfish_ECB = MiscObjectIdentifiers.cryptlib_algorithm.Branch("1.1");
  public static readonly DerObjectIdentifier cryptlib_algorithm_blowfish_CBC = MiscObjectIdentifiers.cryptlib_algorithm.Branch("1.2");
  public static readonly DerObjectIdentifier cryptlib_algorithm_blowfish_CFB = MiscObjectIdentifiers.cryptlib_algorithm.Branch("1.3");
  public static readonly DerObjectIdentifier cryptlib_algorithm_blowfish_OFB = MiscObjectIdentifiers.cryptlib_algorithm.Branch("1.4");
  public static readonly DerObjectIdentifier blake2 = new DerObjectIdentifier("1.3.6.1.4.1.1722.12.2");
  public static readonly DerObjectIdentifier id_blake2b160 = MiscObjectIdentifiers.blake2.Branch("1.5");
  public static readonly DerObjectIdentifier id_blake2b256 = MiscObjectIdentifiers.blake2.Branch("1.8");
  public static readonly DerObjectIdentifier id_blake2b384 = MiscObjectIdentifiers.blake2.Branch("1.12");
  public static readonly DerObjectIdentifier id_blake2b512 = MiscObjectIdentifiers.blake2.Branch("1.16");
  public static readonly DerObjectIdentifier id_blake2s128 = MiscObjectIdentifiers.blake2.Branch("2.4");
  public static readonly DerObjectIdentifier id_blake2s160 = MiscObjectIdentifiers.blake2.Branch("2.5");
  public static readonly DerObjectIdentifier id_blake2s224 = MiscObjectIdentifiers.blake2.Branch("2.7");
  public static readonly DerObjectIdentifier id_blake2s256 = MiscObjectIdentifiers.blake2.Branch("2.8");
  public static readonly DerObjectIdentifier blake3 = MiscObjectIdentifiers.blake2.Branch("3");
  public static readonly DerObjectIdentifier blake3_256 = MiscObjectIdentifiers.blake3.Branch("8");
  public static readonly DerObjectIdentifier id_scrypt = new DerObjectIdentifier("1.3.6.1.4.1.11591.4.11");
  public static readonly DerObjectIdentifier id_alg_composite = new DerObjectIdentifier("1.3.6.1.4.1.18227.2.1");
  public static readonly DerObjectIdentifier id_composite_key = new DerObjectIdentifier("2.16.840.1.114027.80.4.1");
  public static readonly DerObjectIdentifier id_oracle_pkcs12_trusted_key_usage = new DerObjectIdentifier("2.16.840.1.113894.746875.1.1");
}
