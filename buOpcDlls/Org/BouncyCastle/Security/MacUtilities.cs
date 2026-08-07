// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.MacUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Iana;
using Org.BouncyCastle.Asn1.Misc;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Rosstandart;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Security;

public static class MacUtilities
{
  private static readonly IDictionary<string, string> Algorithms = (IDictionary<string, string>) new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

  static MacUtilities()
  {
    MacUtilities.Algorithms[IanaObjectIdentifiers.HmacMD5.Id] = "HMAC-MD5";
    MacUtilities.Algorithms[IanaObjectIdentifiers.HmacRipeMD160.Id] = "HMAC-RIPEMD160";
    MacUtilities.Algorithms[IanaObjectIdentifiers.HmacSha1.Id] = "HMAC-SHA1";
    MacUtilities.Algorithms[IanaObjectIdentifiers.HmacTiger.Id] = "HMAC-TIGER";
    MacUtilities.Algorithms[PkcsObjectIdentifiers.IdHmacWithSha1.Id] = "HMAC-SHA1";
    MacUtilities.Algorithms[MiscObjectIdentifiers.HMAC_SHA1.Id] = "HMAC-SHA1";
    MacUtilities.Algorithms[PkcsObjectIdentifiers.IdHmacWithSha224.Id] = "HMAC-SHA224";
    MacUtilities.Algorithms[PkcsObjectIdentifiers.IdHmacWithSha256.Id] = "HMAC-SHA256";
    MacUtilities.Algorithms[PkcsObjectIdentifiers.IdHmacWithSha384.Id] = "HMAC-SHA384";
    MacUtilities.Algorithms[PkcsObjectIdentifiers.IdHmacWithSha512.Id] = "HMAC-SHA512";
    MacUtilities.Algorithms[NistObjectIdentifiers.IdHMacWithSha3_224.Id] = "HMAC-SHA3-224";
    MacUtilities.Algorithms[NistObjectIdentifiers.IdHMacWithSha3_256.Id] = "HMAC-SHA3-256";
    MacUtilities.Algorithms[NistObjectIdentifiers.IdHMacWithSha3_384.Id] = "HMAC-SHA3-384";
    MacUtilities.Algorithms[NistObjectIdentifiers.IdHMacWithSha3_512.Id] = "HMAC-SHA3-512";
    MacUtilities.Algorithms[RosstandartObjectIdentifiers.id_tc26_hmac_gost_3411_12_256.Id] = "HMAC-GOST3411-2012-256";
    MacUtilities.Algorithms[RosstandartObjectIdentifiers.id_tc26_hmac_gost_3411_12_512.Id] = "HMAC-GOST3411-2012-512";
    MacUtilities.Algorithms["DES"] = "DESMAC";
    MacUtilities.Algorithms["DES/CFB8"] = "DESMAC/CFB8";
    MacUtilities.Algorithms["DES64"] = "DESMAC64";
    MacUtilities.Algorithms["DESEDE"] = "DESEDEMAC";
    MacUtilities.Algorithms[PkcsObjectIdentifiers.DesEde3Cbc.Id] = "DESEDEMAC";
    MacUtilities.Algorithms["DESEDE/CFB8"] = "DESEDEMAC/CFB8";
    MacUtilities.Algorithms["DESISO9797MAC"] = "DESWITHISO9797";
    MacUtilities.Algorithms["DESEDE64"] = "DESEDEMAC64";
    MacUtilities.Algorithms["DESEDE64WITHISO7816-4PADDING"] = "DESEDEMAC64WITHISO7816-4PADDING";
    MacUtilities.Algorithms["DESEDEISO9797ALG1MACWITHISO7816-4PADDING"] = "DESEDEMAC64WITHISO7816-4PADDING";
    MacUtilities.Algorithms["DESEDEISO9797ALG1WITHISO7816-4PADDING"] = "DESEDEMAC64WITHISO7816-4PADDING";
    MacUtilities.Algorithms["ISO9797ALG3"] = "ISO9797ALG3MAC";
    MacUtilities.Algorithms["ISO9797ALG3MACWITHISO7816-4PADDING"] = "ISO9797ALG3WITHISO7816-4PADDING";
    MacUtilities.Algorithms["SKIPJACK"] = "SKIPJACKMAC";
    MacUtilities.Algorithms["SKIPJACK/CFB8"] = "SKIPJACKMAC/CFB8";
    MacUtilities.Algorithms["IDEA"] = "IDEAMAC";
    MacUtilities.Algorithms["IDEA/CFB8"] = "IDEAMAC/CFB8";
    MacUtilities.Algorithms["RC2"] = "RC2MAC";
    MacUtilities.Algorithms["RC2/CFB8"] = "RC2MAC/CFB8";
    MacUtilities.Algorithms["RC5"] = "RC5MAC";
    MacUtilities.Algorithms["RC5/CFB8"] = "RC5MAC/CFB8";
    MacUtilities.Algorithms["GOST28147"] = "GOST28147MAC";
    MacUtilities.Algorithms["VMPC"] = "VMPCMAC";
    MacUtilities.Algorithms["VMPC-MAC"] = "VMPCMAC";
    MacUtilities.Algorithms["SIPHASH"] = "SIPHASH-2-4";
    MacUtilities.Algorithms["PBEWITHHMACSHA"] = "PBEWITHHMACSHA1";
    MacUtilities.Algorithms["1.3.14.3.2.26"] = "PBEWITHHMACSHA1";
  }

  public static IMac GetMac(DerObjectIdentifier id) => MacUtilities.GetMac(id.Id);

  public static IMac GetMac(string algorithm)
  {
    string source = algorithm != null ? CollectionUtilities.GetValueOrKey<string>(MacUtilities.Algorithms, algorithm).ToUpperInvariant() : throw new ArgumentNullException(nameof (algorithm));
    if (Platform.StartsWith(source, "PBEWITH"))
      source = source.Substring("PBEWITH".Length);
    if (Platform.StartsWith(source, "HMAC"))
      return (IMac) new HMac(DigestUtilities.GetDigest(Platform.StartsWith(source, "HMAC-") || Platform.StartsWith(source, "HMAC/") ? source.Substring(5) : source.Substring(4)));
    switch (source)
    {
      case "AESCMAC":
        return (IMac) new CMac(AesUtilities.CreateEngine());
      case "DESMAC":
        return (IMac) new CbcBlockCipherMac((IBlockCipher) new DesEngine());
      case "DESMAC/CFB8":
        return (IMac) new CfbBlockCipherMac((IBlockCipher) new DesEngine());
      case "DESMAC64":
        return (IMac) new CbcBlockCipherMac((IBlockCipher) new DesEngine(), 64 /*0x40*/);
      case "DESEDECMAC":
        return (IMac) new CMac((IBlockCipher) new DesEdeEngine());
      case "DESEDEMAC":
        return (IMac) new CbcBlockCipherMac((IBlockCipher) new DesEdeEngine());
      case "DESEDEMAC/CFB8":
        return (IMac) new CfbBlockCipherMac((IBlockCipher) new DesEdeEngine());
      case "DESEDEMAC64":
        return (IMac) new CbcBlockCipherMac((IBlockCipher) new DesEdeEngine(), 64 /*0x40*/);
      case "DESEDEMAC64WITHISO7816-4PADDING":
        return (IMac) new CbcBlockCipherMac((IBlockCipher) new DesEdeEngine(), 64 /*0x40*/, (IBlockCipherPadding) new ISO7816d4Padding());
      case "DESWITHISO9797":
      case "ISO9797ALG3MAC":
        return (IMac) new ISO9797Alg3Mac((IBlockCipher) new DesEngine());
      case "ISO9797ALG3WITHISO7816-4PADDING":
        return (IMac) new ISO9797Alg3Mac((IBlockCipher) new DesEngine(), (IBlockCipherPadding) new ISO7816d4Padding());
      case "SKIPJACKMAC":
        return (IMac) new CbcBlockCipherMac((IBlockCipher) new SkipjackEngine());
      case "SKIPJACKMAC/CFB8":
        return (IMac) new CfbBlockCipherMac((IBlockCipher) new SkipjackEngine());
      case "IDEAMAC":
        return (IMac) new CbcBlockCipherMac((IBlockCipher) new IdeaEngine());
      case "IDEAMAC/CFB8":
        return (IMac) new CfbBlockCipherMac((IBlockCipher) new IdeaEngine());
      case "RC2MAC":
        return (IMac) new CbcBlockCipherMac((IBlockCipher) new RC2Engine());
      case "RC2MAC/CFB8":
        return (IMac) new CfbBlockCipherMac((IBlockCipher) new RC2Engine());
      case "RC5MAC":
        return (IMac) new CbcBlockCipherMac((IBlockCipher) new RC532Engine());
      case "RC5MAC/CFB8":
        return (IMac) new CfbBlockCipherMac((IBlockCipher) new RC532Engine());
      case "GOST28147MAC":
        return (IMac) new Gost28147Mac();
      case "VMPCMAC":
        return (IMac) new VmpcMac();
      case "SIPHASH-2-4":
        return (IMac) new SipHash();
      default:
        throw new SecurityUtilityException($"Mac {source} not recognised.");
    }
  }

  public static string GetAlgorithmName(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<string, string>(MacUtilities.Algorithms, oid.Id);
  }

  public static byte[] CalculateMac(string algorithm, ICipherParameters cp, byte[] input)
  {
    IMac mac = MacUtilities.GetMac(algorithm);
    mac.Init(cp);
    mac.BlockUpdate(input, 0, input.Length);
    return MacUtilities.DoFinal(mac);
  }

  public static byte[] DoFinal(IMac mac)
  {
    byte[] output = new byte[mac.GetMacSize()];
    mac.DoFinal(output, 0);
    return output;
  }

  public static byte[] DoFinal(IMac mac, byte[] input)
  {
    mac.BlockUpdate(input, 0, input.Length);
    return MacUtilities.DoFinal(mac);
  }
}
