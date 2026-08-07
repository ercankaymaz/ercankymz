// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Bsi.BsiObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Bsi;

public abstract class BsiObjectIdentifiers
{
  public static readonly DerObjectIdentifier bsi_de = new DerObjectIdentifier("0.4.0.127.0.7");
  public static readonly DerObjectIdentifier id_ecc = BsiObjectIdentifiers.bsi_de.Branch("1.1");
  public static readonly DerObjectIdentifier ecdsa_plain_signatures = BsiObjectIdentifiers.id_ecc.Branch("4.1");
  public static readonly DerObjectIdentifier ecdsa_plain_SHA1 = BsiObjectIdentifiers.ecdsa_plain_signatures.Branch("1");
  public static readonly DerObjectIdentifier ecdsa_plain_SHA224 = BsiObjectIdentifiers.ecdsa_plain_signatures.Branch("2");
  public static readonly DerObjectIdentifier ecdsa_plain_SHA256 = BsiObjectIdentifiers.ecdsa_plain_signatures.Branch("3");
  public static readonly DerObjectIdentifier ecdsa_plain_SHA384 = BsiObjectIdentifiers.ecdsa_plain_signatures.Branch("4");
  public static readonly DerObjectIdentifier ecdsa_plain_SHA512 = BsiObjectIdentifiers.ecdsa_plain_signatures.Branch("5");
  public static readonly DerObjectIdentifier ecdsa_plain_RIPEMD160 = BsiObjectIdentifiers.ecdsa_plain_signatures.Branch("6");
  public static readonly DerObjectIdentifier algorithm = BsiObjectIdentifiers.bsi_de.Branch("1");
  public static readonly DerObjectIdentifier ecka_eg = BsiObjectIdentifiers.id_ecc.Branch("5.1");
  public static readonly DerObjectIdentifier ecka_eg_X963kdf = BsiObjectIdentifiers.ecka_eg.Branch("1");
  public static readonly DerObjectIdentifier ecka_eg_X963kdf_SHA1 = BsiObjectIdentifiers.ecka_eg_X963kdf.Branch("1");
  public static readonly DerObjectIdentifier ecka_eg_X963kdf_SHA224 = BsiObjectIdentifiers.ecka_eg_X963kdf.Branch("2");
  public static readonly DerObjectIdentifier ecka_eg_X963kdf_SHA256 = BsiObjectIdentifiers.ecka_eg_X963kdf.Branch("3");
  public static readonly DerObjectIdentifier ecka_eg_X963kdf_SHA384 = BsiObjectIdentifiers.ecka_eg_X963kdf.Branch("4");
  public static readonly DerObjectIdentifier ecka_eg_X963kdf_SHA512 = BsiObjectIdentifiers.ecka_eg_X963kdf.Branch("5");
  public static readonly DerObjectIdentifier ecka_eg_X963kdf_RIPEMD160 = BsiObjectIdentifiers.ecka_eg_X963kdf.Branch("6");
  public static readonly DerObjectIdentifier ecka_eg_SessionKDF = BsiObjectIdentifiers.ecka_eg.Branch("2");
  public static readonly DerObjectIdentifier ecka_eg_SessionKDF_3DES = BsiObjectIdentifiers.ecka_eg_SessionKDF.Branch("1");
  public static readonly DerObjectIdentifier ecka_eg_SessionKDF_AES128 = BsiObjectIdentifiers.ecka_eg_SessionKDF.Branch("2");
  public static readonly DerObjectIdentifier ecka_eg_SessionKDF_AES192 = BsiObjectIdentifiers.ecka_eg_SessionKDF.Branch("3");
  public static readonly DerObjectIdentifier ecka_eg_SessionKDF_AES256 = BsiObjectIdentifiers.ecka_eg_SessionKDF.Branch("4");
}
