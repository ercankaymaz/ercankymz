// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tsp.TspAlgorithms
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.GM;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Rosstandart;
using Org.BouncyCastle.Asn1.TeleTrust;
using Org.BouncyCastle.Utilities.Collections;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tsp;

public static class TspAlgorithms
{
  public static readonly string MD5 = PkcsObjectIdentifiers.MD5.Id;
  public static readonly string Sha1 = OiwObjectIdentifiers.IdSha1.Id;
  public static readonly string Sha224 = NistObjectIdentifiers.IdSha224.Id;
  public static readonly string Sha256 = NistObjectIdentifiers.IdSha256.Id;
  public static readonly string Sha384 = NistObjectIdentifiers.IdSha384.Id;
  public static readonly string Sha512 = NistObjectIdentifiers.IdSha512.Id;
  public static readonly string RipeMD128 = TeleTrusTObjectIdentifiers.RipeMD128.Id;
  public static readonly string RipeMD160 = TeleTrusTObjectIdentifiers.RipeMD160.Id;
  public static readonly string RipeMD256 = TeleTrusTObjectIdentifiers.RipeMD256.Id;
  public static readonly string Gost3411 = CryptoProObjectIdentifiers.GostR3411.Id;
  public static readonly string Gost3411_2012_256 = RosstandartObjectIdentifiers.id_tc26_gost_3411_12_256.Id;
  public static readonly string Gost3411_2012_512 = RosstandartObjectIdentifiers.id_tc26_gost_3411_12_512.Id;
  public static readonly string SM3 = GMObjectIdentifiers.sm3.Id;
  public static readonly IList<string> Allowed = CollectionUtilities.ReadOnly<string>((IList<string>) new List<string>()
  {
    TspAlgorithms.Gost3411,
    TspAlgorithms.Gost3411_2012_256,
    TspAlgorithms.Gost3411_2012_512,
    TspAlgorithms.MD5,
    TspAlgorithms.RipeMD128,
    TspAlgorithms.RipeMD160,
    TspAlgorithms.RipeMD256,
    TspAlgorithms.Sha1,
    TspAlgorithms.Sha224,
    TspAlgorithms.Sha256,
    TspAlgorithms.Sha384,
    TspAlgorithms.Sha512,
    TspAlgorithms.SM3
  });
}
