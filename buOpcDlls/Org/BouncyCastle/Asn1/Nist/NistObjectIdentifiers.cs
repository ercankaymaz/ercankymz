// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Nist.NistObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Nist;

public sealed class NistObjectIdentifiers
{
  public static readonly DerObjectIdentifier NistAlgorithm = new DerObjectIdentifier("2.16.840.1.101.3.4");
  public static readonly DerObjectIdentifier HashAlgs = NistObjectIdentifiers.NistAlgorithm.Branch("2");
  public static readonly DerObjectIdentifier IdSha256 = NistObjectIdentifiers.HashAlgs.Branch("1");
  public static readonly DerObjectIdentifier IdSha384 = NistObjectIdentifiers.HashAlgs.Branch("2");
  public static readonly DerObjectIdentifier IdSha512 = NistObjectIdentifiers.HashAlgs.Branch("3");
  public static readonly DerObjectIdentifier IdSha224 = NistObjectIdentifiers.HashAlgs.Branch("4");
  public static readonly DerObjectIdentifier IdSha512_224 = NistObjectIdentifiers.HashAlgs.Branch("5");
  public static readonly DerObjectIdentifier IdSha512_256 = NistObjectIdentifiers.HashAlgs.Branch("6");
  public static readonly DerObjectIdentifier IdSha3_224 = NistObjectIdentifiers.HashAlgs.Branch("7");
  public static readonly DerObjectIdentifier IdSha3_256 = NistObjectIdentifiers.HashAlgs.Branch("8");
  public static readonly DerObjectIdentifier IdSha3_384 = NistObjectIdentifiers.HashAlgs.Branch("9");
  public static readonly DerObjectIdentifier IdSha3_512 = NistObjectIdentifiers.HashAlgs.Branch("10");
  public static readonly DerObjectIdentifier IdShake128 = NistObjectIdentifiers.HashAlgs.Branch("11");
  public static readonly DerObjectIdentifier IdShake256 = NistObjectIdentifiers.HashAlgs.Branch("12");
  public static readonly DerObjectIdentifier IdHMacWithSha3_224 = NistObjectIdentifiers.HashAlgs.Branch("13");
  public static readonly DerObjectIdentifier IdHMacWithSha3_256 = NistObjectIdentifiers.HashAlgs.Branch("14");
  public static readonly DerObjectIdentifier IdHMacWithSha3_384 = NistObjectIdentifiers.HashAlgs.Branch("15");
  public static readonly DerObjectIdentifier IdHMacWithSha3_512 = NistObjectIdentifiers.HashAlgs.Branch("16");
  public static readonly DerObjectIdentifier IdShake128Len = NistObjectIdentifiers.HashAlgs.Branch("17");
  public static readonly DerObjectIdentifier IdShake256Len = NistObjectIdentifiers.HashAlgs.Branch("18");
  public static readonly DerObjectIdentifier IdKmacWithShake128 = NistObjectIdentifiers.HashAlgs.Branch("19");
  public static readonly DerObjectIdentifier IdKmacWithShake256 = NistObjectIdentifiers.HashAlgs.Branch("20");
  public static readonly DerObjectIdentifier Aes = new DerObjectIdentifier(NistObjectIdentifiers.NistAlgorithm?.ToString() + ".1");
  public static readonly DerObjectIdentifier IdAes128Ecb = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".1");
  public static readonly DerObjectIdentifier IdAes128Cbc = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".2");
  public static readonly DerObjectIdentifier IdAes128Ofb = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".3");
  public static readonly DerObjectIdentifier IdAes128Cfb = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".4");
  public static readonly DerObjectIdentifier IdAes128Wrap = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".5");
  public static readonly DerObjectIdentifier IdAes128Gcm = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".6");
  public static readonly DerObjectIdentifier IdAes128Ccm = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".7");
  public static readonly DerObjectIdentifier IdAes192Ecb = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".21");
  public static readonly DerObjectIdentifier IdAes192Cbc = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".22");
  public static readonly DerObjectIdentifier IdAes192Ofb = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".23");
  public static readonly DerObjectIdentifier IdAes192Cfb = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".24");
  public static readonly DerObjectIdentifier IdAes192Wrap = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".25");
  public static readonly DerObjectIdentifier IdAes192Gcm = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".26");
  public static readonly DerObjectIdentifier IdAes192Ccm = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".27");
  public static readonly DerObjectIdentifier IdAes256Ecb = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".41");
  public static readonly DerObjectIdentifier IdAes256Cbc = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".42");
  public static readonly DerObjectIdentifier IdAes256Ofb = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".43");
  public static readonly DerObjectIdentifier IdAes256Cfb = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".44");
  public static readonly DerObjectIdentifier IdAes256Wrap = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".45");
  public static readonly DerObjectIdentifier IdAes256Gcm = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".46");
  public static readonly DerObjectIdentifier IdAes256Ccm = new DerObjectIdentifier(NistObjectIdentifiers.Aes?.ToString() + ".47");
  public static readonly DerObjectIdentifier IdDsaWithSha2 = new DerObjectIdentifier(NistObjectIdentifiers.NistAlgorithm?.ToString() + ".3");
  public static readonly DerObjectIdentifier DsaWithSha224 = new DerObjectIdentifier(NistObjectIdentifiers.IdDsaWithSha2?.ToString() + ".1");
  public static readonly DerObjectIdentifier DsaWithSha256 = new DerObjectIdentifier(NistObjectIdentifiers.IdDsaWithSha2?.ToString() + ".2");
  public static readonly DerObjectIdentifier DsaWithSha384 = new DerObjectIdentifier(NistObjectIdentifiers.IdDsaWithSha2?.ToString() + ".3");
  public static readonly DerObjectIdentifier DsaWithSha512 = new DerObjectIdentifier(NistObjectIdentifiers.IdDsaWithSha2?.ToString() + ".4");
  public static readonly DerObjectIdentifier IdDsaWithSha3_224 = new DerObjectIdentifier(NistObjectIdentifiers.IdDsaWithSha2?.ToString() + ".5");
  public static readonly DerObjectIdentifier IdDsaWithSha3_256 = new DerObjectIdentifier(NistObjectIdentifiers.IdDsaWithSha2?.ToString() + ".6");
  public static readonly DerObjectIdentifier IdDsaWithSha3_384 = new DerObjectIdentifier(NistObjectIdentifiers.IdDsaWithSha2?.ToString() + ".7");
  public static readonly DerObjectIdentifier IdDsaWithSha3_512 = new DerObjectIdentifier(NistObjectIdentifiers.IdDsaWithSha2?.ToString() + ".8");
  public static readonly DerObjectIdentifier IdEcdsaWithSha3_224 = new DerObjectIdentifier(NistObjectIdentifiers.IdDsaWithSha2?.ToString() + ".9");
  public static readonly DerObjectIdentifier IdEcdsaWithSha3_256 = new DerObjectIdentifier(NistObjectIdentifiers.IdDsaWithSha2?.ToString() + ".10");
  public static readonly DerObjectIdentifier IdEcdsaWithSha3_384 = new DerObjectIdentifier(NistObjectIdentifiers.IdDsaWithSha2?.ToString() + ".11");
  public static readonly DerObjectIdentifier IdEcdsaWithSha3_512 = new DerObjectIdentifier(NistObjectIdentifiers.IdDsaWithSha2?.ToString() + ".12");
  public static readonly DerObjectIdentifier IdRsassaPkcs1V15WithSha3_224 = new DerObjectIdentifier(NistObjectIdentifiers.IdDsaWithSha2?.ToString() + ".13");
  public static readonly DerObjectIdentifier IdRsassaPkcs1V15WithSha3_256 = new DerObjectIdentifier(NistObjectIdentifiers.IdDsaWithSha2?.ToString() + ".14");
  public static readonly DerObjectIdentifier IdRsassaPkcs1V15WithSha3_384 = new DerObjectIdentifier(NistObjectIdentifiers.IdDsaWithSha2?.ToString() + ".15");
  public static readonly DerObjectIdentifier IdRsassaPkcs1V15WithSha3_512 = new DerObjectIdentifier(NistObjectIdentifiers.IdDsaWithSha2?.ToString() + ".16");

  private NistObjectIdentifiers()
  {
  }
}
