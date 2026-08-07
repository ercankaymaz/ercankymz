// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cryptlib.CryptlibObjectIdentifiers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cryptlib;

internal class CryptlibObjectIdentifiers
{
  internal static readonly DerObjectIdentifier cryptlib = new DerObjectIdentifier("1.3.6.1.4.1.3029");
  internal static readonly DerObjectIdentifier ecc = CryptlibObjectIdentifiers.cryptlib.Branch("1.5");
  internal static readonly DerObjectIdentifier curvey25519 = CryptlibObjectIdentifiers.ecc.Branch("1");
}
