// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.CipherUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.CryptoPro;
using Org.BouncyCastle.Asn1.Kisa;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Nsri;
using Org.BouncyCastle.Asn1.Ntt;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Agreement;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Security;

public static class CipherUtilities
{
  private static readonly Dictionary<string, string> Algorithms = new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

  static CipherUtilities()
  {
    Enums.GetArbitraryValue<CipherUtilities.CipherAlgorithm>().ToString();
    Enums.GetArbitraryValue<CipherUtilities.CipherMode>().ToString();
    Enums.GetArbitraryValue<CipherUtilities.CipherPadding>().ToString();
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes128Cbc.Id] = "AES/CBC/PKCS7PADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes192Cbc.Id] = "AES/CBC/PKCS7PADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes256Cbc.Id] = "AES/CBC/PKCS7PADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes128Ccm.Id] = "AES/CCM/NOPADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes192Ccm.Id] = "AES/CCM/NOPADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes256Ccm.Id] = "AES/CCM/NOPADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes128Cfb.Id] = "AES/CFB/NOPADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes192Cfb.Id] = "AES/CFB/NOPADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes256Cfb.Id] = "AES/CFB/NOPADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes128Ecb.Id] = "AES/ECB/PKCS7PADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes192Ecb.Id] = "AES/ECB/PKCS7PADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes256Ecb.Id] = "AES/ECB/PKCS7PADDING";
    CipherUtilities.Algorithms["AES//PKCS7"] = "AES/ECB/PKCS7PADDING";
    CipherUtilities.Algorithms["AES//PKCS7PADDING"] = "AES/ECB/PKCS7PADDING";
    CipherUtilities.Algorithms["AES//PKCS5"] = "AES/ECB/PKCS7PADDING";
    CipherUtilities.Algorithms["AES//PKCS5PADDING"] = "AES/ECB/PKCS7PADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes128Gcm.Id] = "AES/GCM/NOPADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes192Gcm.Id] = "AES/GCM/NOPADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes256Gcm.Id] = "AES/GCM/NOPADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes128Ofb.Id] = "AES/OFB/NOPADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes192Ofb.Id] = "AES/OFB/NOPADDING";
    CipherUtilities.Algorithms[NistObjectIdentifiers.IdAes256Ofb.Id] = "AES/OFB/NOPADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria128_cbc.Id] = "ARIA/CBC/PKCS7PADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria192_cbc.Id] = "ARIA/CBC/PKCS7PADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria256_cbc.Id] = "ARIA/CBC/PKCS7PADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria128_ccm.Id] = "ARIA/CCM/NOPADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria192_ccm.Id] = "ARIA/CCM/NOPADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria256_ccm.Id] = "ARIA/CCM/NOPADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria128_cfb.Id] = "ARIA/CFB/NOPADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria192_cfb.Id] = "ARIA/CFB/NOPADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria256_cfb.Id] = "ARIA/CFB/NOPADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria128_ctr.Id] = "ARIA/CTR/NOPADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria192_ctr.Id] = "ARIA/CTR/NOPADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria256_ctr.Id] = "ARIA/CTR/NOPADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria128_ecb.Id] = "ARIA/ECB/PKCS7PADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria192_ecb.Id] = "ARIA/ECB/PKCS7PADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria256_ecb.Id] = "ARIA/ECB/PKCS7PADDING";
    CipherUtilities.Algorithms["ARIA//PKCS7"] = "ARIA/ECB/PKCS7PADDING";
    CipherUtilities.Algorithms["ARIA//PKCS7PADDING"] = "ARIA/ECB/PKCS7PADDING";
    CipherUtilities.Algorithms["ARIA//PKCS5"] = "ARIA/ECB/PKCS7PADDING";
    CipherUtilities.Algorithms["ARIA//PKCS5PADDING"] = "ARIA/ECB/PKCS7PADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria128_gcm.Id] = "ARIA/GCM/NOPADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria192_gcm.Id] = "ARIA/GCM/NOPADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria256_gcm.Id] = "ARIA/GCM/NOPADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria128_ofb.Id] = "ARIA/OFB/NOPADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria192_ofb.Id] = "ARIA/OFB/NOPADDING";
    CipherUtilities.Algorithms[NsriObjectIdentifiers.id_aria256_ofb.Id] = "ARIA/OFB/NOPADDING";
    CipherUtilities.Algorithms["RSA/ECB/PKCS1"] = "RSA//PKCS1PADDING";
    CipherUtilities.Algorithms["RSA/ECB/PKCS1PADDING"] = "RSA//PKCS1PADDING";
    CipherUtilities.Algorithms[PkcsObjectIdentifiers.RsaEncryption.Id] = "RSA//PKCS1PADDING";
    CipherUtilities.Algorithms[PkcsObjectIdentifiers.IdRsaesOaep.Id] = "RSA//OAEPPADDING";
    CipherUtilities.Algorithms[OiwObjectIdentifiers.DesCbc.Id] = "DES/CBC";
    CipherUtilities.Algorithms[OiwObjectIdentifiers.DesCfb.Id] = "DES/CFB";
    CipherUtilities.Algorithms[OiwObjectIdentifiers.DesEcb.Id] = "DES/ECB";
    CipherUtilities.Algorithms[OiwObjectIdentifiers.DesOfb.Id] = "DES/OFB";
    CipherUtilities.Algorithms[OiwObjectIdentifiers.DesEde.Id] = "DESEDE";
    CipherUtilities.Algorithms["TDEA"] = "DESEDE";
    CipherUtilities.Algorithms[PkcsObjectIdentifiers.DesEde3Cbc.Id] = "DESEDE/CBC";
    CipherUtilities.Algorithms[PkcsObjectIdentifiers.RC2Cbc.Id] = "RC2/CBC";
    CipherUtilities.Algorithms["1.3.6.1.4.1.188.7.1.1.2"] = "IDEA/CBC";
    CipherUtilities.Algorithms["1.2.840.113533.7.66.10"] = "CAST5/CBC";
    CipherUtilities.Algorithms["RC4"] = "ARC4";
    CipherUtilities.Algorithms["ARCFOUR"] = "ARC4";
    CipherUtilities.Algorithms["1.2.840.113549.3.4"] = "ARC4";
    CipherUtilities.Algorithms["PBEWITHSHA1AND128BITRC4"] = "PBEWITHSHAAND128BITRC4";
    CipherUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithShaAnd128BitRC4.Id] = "PBEWITHSHAAND128BITRC4";
    CipherUtilities.Algorithms["PBEWITHSHA1AND40BITRC4"] = "PBEWITHSHAAND40BITRC4";
    CipherUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithShaAnd40BitRC4.Id] = "PBEWITHSHAAND40BITRC4";
    CipherUtilities.Algorithms["PBEWITHSHA1ANDDES"] = "PBEWITHSHA1ANDDES-CBC";
    CipherUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithSha1AndDesCbc.Id] = "PBEWITHSHA1ANDDES-CBC";
    CipherUtilities.Algorithms["PBEWITHSHA1ANDRC2"] = "PBEWITHSHA1ANDRC2-CBC";
    CipherUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithSha1AndRC2Cbc.Id] = "PBEWITHSHA1ANDRC2-CBC";
    CipherUtilities.Algorithms["PBEWITHSHA1AND3-KEYTRIPLEDES-CBC"] = "PBEWITHSHAAND3-KEYTRIPLEDES-CBC";
    CipherUtilities.Algorithms["PBEWITHSHAAND3KEYTRIPLEDES"] = "PBEWITHSHAAND3-KEYTRIPLEDES-CBC";
    CipherUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithShaAnd3KeyTripleDesCbc.Id] = "PBEWITHSHAAND3-KEYTRIPLEDES-CBC";
    CipherUtilities.Algorithms["PBEWITHSHA1ANDDESEDE"] = "PBEWITHSHAAND3-KEYTRIPLEDES-CBC";
    CipherUtilities.Algorithms["PBEWITHSHA1AND2-KEYTRIPLEDES-CBC"] = "PBEWITHSHAAND2-KEYTRIPLEDES-CBC";
    CipherUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithShaAnd2KeyTripleDesCbc.Id] = "PBEWITHSHAAND2-KEYTRIPLEDES-CBC";
    CipherUtilities.Algorithms["PBEWITHSHA1AND128BITRC2-CBC"] = "PBEWITHSHAAND128BITRC2-CBC";
    CipherUtilities.Algorithms[PkcsObjectIdentifiers.PbeWithShaAnd128BitRC2Cbc.Id] = "PBEWITHSHAAND128BITRC2-CBC";
    CipherUtilities.Algorithms["PBEWITHSHA1AND40BITRC2-CBC"] = "PBEWITHSHAAND40BITRC2-CBC";
    CipherUtilities.Algorithms[PkcsObjectIdentifiers.PbewithShaAnd40BitRC2Cbc.Id] = "PBEWITHSHAAND40BITRC2-CBC";
    CipherUtilities.Algorithms["PBEWITHSHA1AND128BITAES-CBC-BC"] = "PBEWITHSHAAND128BITAES-CBC-BC";
    CipherUtilities.Algorithms["PBEWITHSHA-1AND128BITAES-CBC-BC"] = "PBEWITHSHAAND128BITAES-CBC-BC";
    CipherUtilities.Algorithms["PBEWITHSHA1AND192BITAES-CBC-BC"] = "PBEWITHSHAAND192BITAES-CBC-BC";
    CipherUtilities.Algorithms["PBEWITHSHA-1AND192BITAES-CBC-BC"] = "PBEWITHSHAAND192BITAES-CBC-BC";
    CipherUtilities.Algorithms["PBEWITHSHA1AND256BITAES-CBC-BC"] = "PBEWITHSHAAND256BITAES-CBC-BC";
    CipherUtilities.Algorithms["PBEWITHSHA-1AND256BITAES-CBC-BC"] = "PBEWITHSHAAND256BITAES-CBC-BC";
    CipherUtilities.Algorithms["PBEWITHSHA-256AND128BITAES-CBC-BC"] = "PBEWITHSHA256AND128BITAES-CBC-BC";
    CipherUtilities.Algorithms["PBEWITHSHA-256AND192BITAES-CBC-BC"] = "PBEWITHSHA256AND192BITAES-CBC-BC";
    CipherUtilities.Algorithms["PBEWITHSHA-256AND256BITAES-CBC-BC"] = "PBEWITHSHA256AND256BITAES-CBC-BC";
    CipherUtilities.Algorithms["GOST"] = "GOST28147";
    CipherUtilities.Algorithms["GOST-28147"] = "GOST28147";
    CipherUtilities.Algorithms[CryptoProObjectIdentifiers.GostR28147Gcfb.Id] = "GOST28147/CBC/PKCS7PADDING";
    CipherUtilities.Algorithms["RC5-32"] = "RC5";
    CipherUtilities.Algorithms[NttObjectIdentifiers.IdCamellia128Cbc.Id] = "CAMELLIA/CBC/PKCS7PADDING";
    CipherUtilities.Algorithms[NttObjectIdentifiers.IdCamellia192Cbc.Id] = "CAMELLIA/CBC/PKCS7PADDING";
    CipherUtilities.Algorithms[NttObjectIdentifiers.IdCamellia256Cbc.Id] = "CAMELLIA/CBC/PKCS7PADDING";
    CipherUtilities.Algorithms[KisaObjectIdentifiers.IdSeedCbc.Id] = "SEED/CBC/PKCS7PADDING";
    CipherUtilities.Algorithms["1.3.6.1.4.1.3029.1.2"] = "BLOWFISH/CBC";
    CipherUtilities.Algorithms["CHACHA20"] = "CHACHA7539";
    CipherUtilities.Algorithms[PkcsObjectIdentifiers.IdAlgAeadChaCha20Poly1305.Id] = "CHACHA20-POLY1305";
  }

  public static IBufferedCipher GetCipher(DerObjectIdentifier oid)
  {
    return CipherUtilities.GetCipher(oid.Id);
  }

  public static IBufferedCipher GetCipher(string algorithm)
  {
    algorithm = algorithm != null ? CollectionUtilities.GetValueOrKey<string>((IDictionary<string, string>) CipherUtilities.Algorithms, algorithm).ToUpperInvariant() : throw new ArgumentNullException(nameof (algorithm));
    IBasicAgreement agree = (IBasicAgreement) null;
    if (algorithm == "IES")
      agree = (IBasicAgreement) new DHBasicAgreement();
    else if (algorithm == "ECIES")
      agree = (IBasicAgreement) new ECDHBasicAgreement();
    if (agree != null)
      return (IBufferedCipher) new BufferedIesCipher(new IesEngine(agree, (IDerivationFunction) new Kdf2BytesGenerator((IDigest) new Sha1Digest()), (IMac) new HMac((IDigest) new Sha1Digest())));
    if (Platform.StartsWith(algorithm, "PBE"))
    {
      if (Platform.EndsWith(algorithm, "-CBC"))
      {
        switch (algorithm)
        {
          case "PBEWITHSHA1ANDDES-CBC":
            return (IBufferedCipher) new PaddedBufferedBlockCipher((IBlockCipherMode) new CbcBlockCipher((IBlockCipher) new DesEngine()));
          case "PBEWITHSHA1ANDRC2-CBC":
            return (IBufferedCipher) new PaddedBufferedBlockCipher((IBlockCipherMode) new CbcBlockCipher((IBlockCipher) new RC2Engine()));
          default:
            if (Strings.IsOneOf(algorithm, "PBEWITHSHAAND2-KEYTRIPLEDES-CBC", "PBEWITHSHAAND3-KEYTRIPLEDES-CBC"))
              return (IBufferedCipher) new PaddedBufferedBlockCipher((IBlockCipherMode) new CbcBlockCipher((IBlockCipher) new DesEdeEngine()));
            if (Strings.IsOneOf(algorithm, "PBEWITHSHAAND128BITRC2-CBC", "PBEWITHSHAAND40BITRC2-CBC"))
              return (IBufferedCipher) new PaddedBufferedBlockCipher((IBlockCipherMode) new CbcBlockCipher((IBlockCipher) new RC2Engine()));
            break;
        }
      }
      else if (Platform.EndsWith(algorithm, "-BC") || Platform.EndsWith(algorithm, "-OPENSSL"))
      {
        if (Strings.IsOneOf(algorithm, "PBEWITHSHAAND128BITAES-CBC-BC", "PBEWITHSHAAND192BITAES-CBC-BC", "PBEWITHSHAAND256BITAES-CBC-BC", "PBEWITHSHA256AND128BITAES-CBC-BC", "PBEWITHSHA256AND192BITAES-CBC-BC", "PBEWITHSHA256AND256BITAES-CBC-BC", "PBEWITHMD5AND128BITAES-CBC-OPENSSL", "PBEWITHMD5AND192BITAES-CBC-OPENSSL", "PBEWITHMD5AND256BITAES-CBC-OPENSSL"))
          return (IBufferedCipher) new PaddedBufferedBlockCipher((IBlockCipherMode) new CbcBlockCipher(AesUtilities.CreateEngine()));
      }
    }
    string[] strArray = algorithm.Split('/');
    IAeadCipher cipher1 = (IAeadCipher) null;
    IBlockCipher blockCipher = (IBlockCipher) null;
    IAsymmetricBlockCipher cipher2 = (IAsymmetricBlockCipher) null;
    IStreamCipher cipher3 = (IStreamCipher) null;
    string upperInvariant = CollectionUtilities.GetValueOrKey<string>((IDictionary<string, string>) CipherUtilities.Algorithms, strArray[0]).ToUpperInvariant();
    CipherUtilities.CipherAlgorithm enumValue1;
    try
    {
      enumValue1 = Enums.GetEnumValue<CipherUtilities.CipherAlgorithm>(upperInvariant);
    }
    catch (ArgumentException ex)
    {
      throw new SecurityUtilityException($"Cipher {algorithm} not recognised.");
    }
    switch (enumValue1)
    {
      case CipherUtilities.CipherAlgorithm.AES:
        blockCipher = AesUtilities.CreateEngine();
        break;
      case CipherUtilities.CipherAlgorithm.ARC4:
        cipher3 = (IStreamCipher) new RC4Engine();
        break;
      case CipherUtilities.CipherAlgorithm.ARIA:
        blockCipher = (IBlockCipher) new AriaEngine();
        break;
      case CipherUtilities.CipherAlgorithm.BLOWFISH:
        blockCipher = (IBlockCipher) new BlowfishEngine();
        break;
      case CipherUtilities.CipherAlgorithm.CAMELLIA:
        blockCipher = (IBlockCipher) new CamelliaEngine();
        break;
      case CipherUtilities.CipherAlgorithm.CAST5:
        blockCipher = (IBlockCipher) new Cast5Engine();
        break;
      case CipherUtilities.CipherAlgorithm.CAST6:
        blockCipher = (IBlockCipher) new Cast6Engine();
        break;
      case CipherUtilities.CipherAlgorithm.CHACHA:
        cipher3 = (IStreamCipher) new ChaChaEngine();
        break;
      case CipherUtilities.CipherAlgorithm.CHACHA20_POLY1305:
        cipher1 = (IAeadCipher) new ChaCha20Poly1305();
        break;
      case CipherUtilities.CipherAlgorithm.CHACHA7539:
        cipher3 = (IStreamCipher) new ChaCha7539Engine();
        break;
      case CipherUtilities.CipherAlgorithm.DES:
        blockCipher = (IBlockCipher) new DesEngine();
        break;
      case CipherUtilities.CipherAlgorithm.DESEDE:
        blockCipher = (IBlockCipher) new DesEdeEngine();
        break;
      case CipherUtilities.CipherAlgorithm.ELGAMAL:
        cipher2 = (IAsymmetricBlockCipher) new ElGamalEngine();
        break;
      case CipherUtilities.CipherAlgorithm.GOST28147:
        blockCipher = (IBlockCipher) new Gost28147Engine();
        break;
      case CipherUtilities.CipherAlgorithm.HC128:
        cipher3 = (IStreamCipher) new HC128Engine();
        break;
      case CipherUtilities.CipherAlgorithm.HC256:
        cipher3 = (IStreamCipher) new HC256Engine();
        break;
      case CipherUtilities.CipherAlgorithm.IDEA:
        blockCipher = (IBlockCipher) new IdeaEngine();
        break;
      case CipherUtilities.CipherAlgorithm.NOEKEON:
        blockCipher = (IBlockCipher) new NoekeonEngine();
        break;
      case CipherUtilities.CipherAlgorithm.PBEWITHSHAAND128BITRC4:
      case CipherUtilities.CipherAlgorithm.PBEWITHSHAAND40BITRC4:
        cipher3 = (IStreamCipher) new RC4Engine();
        break;
      case CipherUtilities.CipherAlgorithm.RC2:
        blockCipher = (IBlockCipher) new RC2Engine();
        break;
      case CipherUtilities.CipherAlgorithm.RC5:
        blockCipher = (IBlockCipher) new RC532Engine();
        break;
      case CipherUtilities.CipherAlgorithm.RC5_64:
        blockCipher = (IBlockCipher) new RC564Engine();
        break;
      case CipherUtilities.CipherAlgorithm.RC6:
        blockCipher = (IBlockCipher) new RC6Engine();
        break;
      case CipherUtilities.CipherAlgorithm.RIJNDAEL:
        blockCipher = (IBlockCipher) new RijndaelEngine();
        break;
      case CipherUtilities.CipherAlgorithm.RSA:
        cipher2 = (IAsymmetricBlockCipher) new RsaBlindedEngine();
        break;
      case CipherUtilities.CipherAlgorithm.SALSA20:
        cipher3 = (IStreamCipher) new Salsa20Engine();
        break;
      case CipherUtilities.CipherAlgorithm.SEED:
        blockCipher = (IBlockCipher) new SeedEngine();
        break;
      case CipherUtilities.CipherAlgorithm.SERPENT:
        blockCipher = (IBlockCipher) new SerpentEngine();
        break;
      case CipherUtilities.CipherAlgorithm.SKIPJACK:
        blockCipher = (IBlockCipher) new SkipjackEngine();
        break;
      case CipherUtilities.CipherAlgorithm.SM4:
        blockCipher = (IBlockCipher) new SM4Engine();
        break;
      case CipherUtilities.CipherAlgorithm.TEA:
        blockCipher = (IBlockCipher) new TeaEngine();
        break;
      case CipherUtilities.CipherAlgorithm.THREEFISH_256:
        blockCipher = (IBlockCipher) new ThreefishEngine(256 /*0x0100*/);
        break;
      case CipherUtilities.CipherAlgorithm.THREEFISH_512:
        blockCipher = (IBlockCipher) new ThreefishEngine(512 /*0x0200*/);
        break;
      case CipherUtilities.CipherAlgorithm.THREEFISH_1024:
        blockCipher = (IBlockCipher) new ThreefishEngine(1024 /*0x0400*/);
        break;
      case CipherUtilities.CipherAlgorithm.TNEPRES:
        blockCipher = (IBlockCipher) new TnepresEngine();
        break;
      case CipherUtilities.CipherAlgorithm.TWOFISH:
        blockCipher = (IBlockCipher) new TwofishEngine();
        break;
      case CipherUtilities.CipherAlgorithm.VMPC:
        cipher3 = (IStreamCipher) new VmpcEngine();
        break;
      case CipherUtilities.CipherAlgorithm.VMPC_KSA3:
        cipher3 = (IStreamCipher) new VmpcKsa3Engine();
        break;
      case CipherUtilities.CipherAlgorithm.XTEA:
        blockCipher = (IBlockCipher) new XteaEngine();
        break;
      default:
        throw new SecurityUtilityException($"Cipher {algorithm} not recognised.");
    }
    if (cipher1 != null)
    {
      if (strArray.Length > 1)
        throw new ArgumentException("Modes and paddings cannot be applied to AEAD ciphers");
      return (IBufferedCipher) new BufferedAeadCipher(cipher1);
    }
    if (cipher3 != null)
    {
      if (strArray.Length > 1)
        throw new ArgumentException("Modes and paddings not used for stream ciphers");
      return (IBufferedCipher) new BufferedStreamCipher(cipher3);
    }
    bool flag1 = false;
    bool flag2 = true;
    IBlockCipherPadding padding = (IBlockCipherPadding) null;
    IAeadBlockCipher cipher4 = (IAeadBlockCipher) null;
    if (strArray.Length > 2)
    {
      if (cipher3 != null)
        throw new ArgumentException("Paddings not used for stream ciphers");
      string s = strArray[2];
      CipherUtilities.CipherPadding cipherPadding;
      switch (s)
      {
        case "":
          cipherPadding = CipherUtilities.CipherPadding.RAW;
          goto label_100;
        case "X9.23PADDING":
          cipherPadding = CipherUtilities.CipherPadding.X923PADDING;
          break;
        default:
          CipherUtilities.CipherPadding enumValue2;
          try
          {
            enumValue2 = Enums.GetEnumValue<CipherUtilities.CipherPadding>(s);
          }
          catch (ArgumentException ex)
          {
            throw new SecurityUtilityException($"Cipher {algorithm} not recognised.");
          }
          switch (enumValue2)
          {
            case CipherUtilities.CipherPadding.NOPADDING:
              flag2 = false;
              goto label_100;
            case CipherUtilities.CipherPadding.RAW:
              goto label_100;
            case CipherUtilities.CipherPadding.ISO10126PADDING:
            case CipherUtilities.CipherPadding.ISO10126D2PADDING:
            case CipherUtilities.CipherPadding.ISO10126_2PADDING:
              padding = (IBlockCipherPadding) new ISO10126d2Padding();
              goto label_100;
            case CipherUtilities.CipherPadding.ISO7816_4PADDING:
            case CipherUtilities.CipherPadding.ISO9797_1PADDING:
              padding = (IBlockCipherPadding) new ISO7816d4Padding();
              goto label_100;
            case CipherUtilities.CipherPadding.ISO9796_1:
            case CipherUtilities.CipherPadding.ISO9796_1PADDING:
              cipher2 = (IAsymmetricBlockCipher) new ISO9796d1Encoding(cipher2);
              goto label_100;
            case CipherUtilities.CipherPadding.OAEP:
            case CipherUtilities.CipherPadding.OAEPPADDING:
              cipher2 = (IAsymmetricBlockCipher) new OaepEncoding(cipher2);
              goto label_100;
            case CipherUtilities.CipherPadding.OAEPWITHMD5ANDMGF1PADDING:
              cipher2 = (IAsymmetricBlockCipher) new OaepEncoding(cipher2, (IDigest) new MD5Digest());
              goto label_100;
            case CipherUtilities.CipherPadding.OAEPWITHSHA1ANDMGF1PADDING:
            case CipherUtilities.CipherPadding.OAEPWITHSHA_1ANDMGF1PADDING:
              cipher2 = (IAsymmetricBlockCipher) new OaepEncoding(cipher2, (IDigest) new Sha1Digest());
              goto label_100;
            case CipherUtilities.CipherPadding.OAEPWITHSHA224ANDMGF1PADDING:
            case CipherUtilities.CipherPadding.OAEPWITHSHA_224ANDMGF1PADDING:
              cipher2 = (IAsymmetricBlockCipher) new OaepEncoding(cipher2, (IDigest) new Sha224Digest());
              goto label_100;
            case CipherUtilities.CipherPadding.OAEPWITHSHA256ANDMGF1PADDING:
            case CipherUtilities.CipherPadding.OAEPWITHSHA_256ANDMGF1PADDING:
            case CipherUtilities.CipherPadding.OAEPWITHSHA256ANDMGF1WITHSHA256PADDING:
            case CipherUtilities.CipherPadding.OAEPWITHSHA_256ANDMGF1WITHSHA_256PADDING:
              cipher2 = (IAsymmetricBlockCipher) new OaepEncoding(cipher2, (IDigest) new Sha256Digest());
              goto label_100;
            case CipherUtilities.CipherPadding.OAEPWITHSHA256ANDMGF1WITHSHA1PADDING:
            case CipherUtilities.CipherPadding.OAEPWITHSHA_256ANDMGF1WITHSHA_1PADDING:
              cipher2 = (IAsymmetricBlockCipher) new OaepEncoding(cipher2, (IDigest) new Sha256Digest(), (IDigest) new Sha1Digest(), (byte[]) null);
              goto label_100;
            case CipherUtilities.CipherPadding.OAEPWITHSHA384ANDMGF1PADDING:
            case CipherUtilities.CipherPadding.OAEPWITHSHA_384ANDMGF1PADDING:
              cipher2 = (IAsymmetricBlockCipher) new OaepEncoding(cipher2, (IDigest) new Sha384Digest());
              goto label_100;
            case CipherUtilities.CipherPadding.OAEPWITHSHA512ANDMGF1PADDING:
            case CipherUtilities.CipherPadding.OAEPWITHSHA_512ANDMGF1PADDING:
              cipher2 = (IAsymmetricBlockCipher) new OaepEncoding(cipher2, (IDigest) new Sha512Digest());
              goto label_100;
            case CipherUtilities.CipherPadding.PKCS1:
            case CipherUtilities.CipherPadding.PKCS1PADDING:
              cipher2 = (IAsymmetricBlockCipher) new Pkcs1Encoding(cipher2);
              goto label_100;
            case CipherUtilities.CipherPadding.PKCS5:
            case CipherUtilities.CipherPadding.PKCS5PADDING:
            case CipherUtilities.CipherPadding.PKCS7:
            case CipherUtilities.CipherPadding.PKCS7PADDING:
              padding = (IBlockCipherPadding) new Pkcs7Padding();
              goto label_100;
            case CipherUtilities.CipherPadding.TBCPADDING:
              padding = (IBlockCipherPadding) new TbcPadding();
              goto label_100;
            case CipherUtilities.CipherPadding.WITHCTS:
              flag1 = true;
              goto label_100;
            case CipherUtilities.CipherPadding.X923PADDING:
              break;
            case CipherUtilities.CipherPadding.ZEROBYTEPADDING:
              padding = (IBlockCipherPadding) new ZeroBytePadding();
              goto label_100;
            default:
              throw new SecurityUtilityException($"Cipher {algorithm} not recognised.");
          }
          break;
      }
      padding = (IBlockCipherPadding) new X923Padding();
    }
label_100:
    IBlockCipherMode cipherMode = (IBlockCipherMode) null;
    if (strArray.Length > 1)
    {
      string s1 = strArray[1];
      int digitIndex = CipherUtilities.GetDigitIndex(s1);
      string s2 = digitIndex >= 0 ? s1.Substring(0, digitIndex) : s1;
      try
      {
        if (!(s2 == ""))
        {
          switch (Enums.GetEnumValue<CipherUtilities.CipherMode>(s2))
          {
            case CipherUtilities.CipherMode.ECB:
            case CipherUtilities.CipherMode.NONE:
              break;
            case CipherUtilities.CipherMode.CBC:
              cipherMode = (IBlockCipherMode) new CbcBlockCipher(blockCipher);
              break;
            case CipherUtilities.CipherMode.CCM:
              cipher4 = (IAeadBlockCipher) new CcmBlockCipher(blockCipher);
              break;
            case CipherUtilities.CipherMode.CFB:
              int bitBlockSize = digitIndex < 0 ? 8 * blockCipher.GetBlockSize() : int.Parse(s1.Substring(digitIndex));
              cipherMode = (IBlockCipherMode) new CfbBlockCipher(blockCipher, bitBlockSize);
              break;
            case CipherUtilities.CipherMode.CTR:
              cipherMode = (IBlockCipherMode) new SicBlockCipher(blockCipher);
              break;
            case CipherUtilities.CipherMode.CTS:
              flag1 = true;
              cipherMode = (IBlockCipherMode) new CbcBlockCipher(blockCipher);
              break;
            case CipherUtilities.CipherMode.EAX:
              cipher4 = (IAeadBlockCipher) new EaxBlockCipher(blockCipher);
              break;
            case CipherUtilities.CipherMode.GCM:
              cipher4 = (IAeadBlockCipher) new GcmBlockCipher(blockCipher);
              break;
            case CipherUtilities.CipherMode.GOFB:
              cipherMode = (IBlockCipherMode) new GOfbBlockCipher(blockCipher);
              break;
            case CipherUtilities.CipherMode.OCB:
              cipher4 = (IAeadBlockCipher) new OcbBlockCipher(blockCipher, CipherUtilities.CreateBlockCipher(enumValue1));
              break;
            case CipherUtilities.CipherMode.OFB:
              int blockSize = digitIndex < 0 ? 8 * blockCipher.GetBlockSize() : int.Parse(s1.Substring(digitIndex));
              cipherMode = (IBlockCipherMode) new OfbBlockCipher(blockCipher, blockSize);
              break;
            case CipherUtilities.CipherMode.OPENPGPCFB:
              cipherMode = (IBlockCipherMode) new OpenPgpCfbBlockCipher(blockCipher);
              break;
            case CipherUtilities.CipherMode.SIC:
              cipherMode = blockCipher.GetBlockSize() >= 16 /*0x10*/ ? (IBlockCipherMode) new SicBlockCipher(blockCipher) : throw new ArgumentException("Warning: SIC-Mode can become a twotime-pad if the blocksize of the cipher is too small. Use a cipher with a block size of at least 128 bits (e.g. AES)");
              break;
            default:
              throw new SecurityUtilityException($"Cipher {algorithm} not recognised.");
          }
        }
      }
      catch (ArgumentException ex)
      {
        throw new SecurityUtilityException($"Cipher {algorithm} not recognised.");
      }
    }
    if (cipher4 != null)
    {
      if (flag1)
        throw new SecurityUtilityException("CTS mode not valid for AEAD ciphers.");
      if (flag2 && strArray.Length > 2 && strArray[2] != "")
        throw new SecurityUtilityException("Bad padding specified for AEAD cipher.");
      return (IBufferedCipher) new BufferedAeadBlockCipher(cipher4);
    }
    if (blockCipher != null)
    {
      if (cipherMode == null)
        cipherMode = EcbBlockCipher.GetBlockCipherMode(blockCipher);
      if (flag1)
        return (IBufferedCipher) new CtsBlockCipher(cipherMode);
      if (padding != null)
        return (IBufferedCipher) new PaddedBufferedBlockCipher(cipherMode, padding);
      return flag2 && !cipherMode.IsPartialBlockOkay ? (IBufferedCipher) new PaddedBufferedBlockCipher(cipherMode) : (IBufferedCipher) new BufferedBlockCipher(cipherMode);
    }
    return cipher2 != null ? (IBufferedCipher) new BufferedAsymmetricBlockCipher(cipher2) : throw new SecurityUtilityException($"Cipher {algorithm} not recognised.");
  }

  public static string GetAlgorithmName(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<string, string>((IDictionary<string, string>) CipherUtilities.Algorithms, oid.Id);
  }

  private static int GetDigitIndex(string s)
  {
    for (int index = 0; index < s.Length; ++index)
    {
      if (char.IsDigit(s[index]))
        return index;
    }
    return -1;
  }

  private static IBlockCipher CreateBlockCipher(CipherUtilities.CipherAlgorithm cipherAlgorithm)
  {
    switch (cipherAlgorithm)
    {
      case CipherUtilities.CipherAlgorithm.AES:
        return AesUtilities.CreateEngine();
      case CipherUtilities.CipherAlgorithm.ARIA:
        return (IBlockCipher) new AriaEngine();
      case CipherUtilities.CipherAlgorithm.BLOWFISH:
        return (IBlockCipher) new BlowfishEngine();
      case CipherUtilities.CipherAlgorithm.CAMELLIA:
        return (IBlockCipher) new CamelliaEngine();
      case CipherUtilities.CipherAlgorithm.CAST5:
        return (IBlockCipher) new Cast5Engine();
      case CipherUtilities.CipherAlgorithm.CAST6:
        return (IBlockCipher) new Cast6Engine();
      case CipherUtilities.CipherAlgorithm.DES:
        return (IBlockCipher) new DesEngine();
      case CipherUtilities.CipherAlgorithm.DESEDE:
        return (IBlockCipher) new DesEdeEngine();
      case CipherUtilities.CipherAlgorithm.GOST28147:
        return (IBlockCipher) new Gost28147Engine();
      case CipherUtilities.CipherAlgorithm.IDEA:
        return (IBlockCipher) new IdeaEngine();
      case CipherUtilities.CipherAlgorithm.NOEKEON:
        return (IBlockCipher) new NoekeonEngine();
      case CipherUtilities.CipherAlgorithm.RC2:
        return (IBlockCipher) new RC2Engine();
      case CipherUtilities.CipherAlgorithm.RC5:
        return (IBlockCipher) new RC532Engine();
      case CipherUtilities.CipherAlgorithm.RC5_64:
        return (IBlockCipher) new RC564Engine();
      case CipherUtilities.CipherAlgorithm.RC6:
        return (IBlockCipher) new RC6Engine();
      case CipherUtilities.CipherAlgorithm.RIJNDAEL:
        return (IBlockCipher) new RijndaelEngine();
      case CipherUtilities.CipherAlgorithm.SEED:
        return (IBlockCipher) new SeedEngine();
      case CipherUtilities.CipherAlgorithm.SERPENT:
        return (IBlockCipher) new SerpentEngine();
      case CipherUtilities.CipherAlgorithm.SKIPJACK:
        return (IBlockCipher) new SkipjackEngine();
      case CipherUtilities.CipherAlgorithm.SM4:
        return (IBlockCipher) new SM4Engine();
      case CipherUtilities.CipherAlgorithm.TEA:
        return (IBlockCipher) new TeaEngine();
      case CipherUtilities.CipherAlgorithm.THREEFISH_256:
        return (IBlockCipher) new ThreefishEngine(256 /*0x0100*/);
      case CipherUtilities.CipherAlgorithm.THREEFISH_512:
        return (IBlockCipher) new ThreefishEngine(512 /*0x0200*/);
      case CipherUtilities.CipherAlgorithm.THREEFISH_1024:
        return (IBlockCipher) new ThreefishEngine(1024 /*0x0400*/);
      case CipherUtilities.CipherAlgorithm.TNEPRES:
        return (IBlockCipher) new TnepresEngine();
      case CipherUtilities.CipherAlgorithm.TWOFISH:
        return (IBlockCipher) new TwofishEngine();
      case CipherUtilities.CipherAlgorithm.XTEA:
        return (IBlockCipher) new XteaEngine();
      default:
        throw new SecurityUtilityException($"Cipher {cipherAlgorithm.ToString()} not recognised or not a block cipher");
    }
  }

  private enum CipherAlgorithm
  {
    AES,
    ARC4,
    ARIA,
    BLOWFISH,
    CAMELLIA,
    CAST5,
    CAST6,
    CHACHA,
    CHACHA20_POLY1305,
    CHACHA7539,
    DES,
    DESEDE,
    ELGAMAL,
    GOST28147,
    HC128,
    HC256,
    IDEA,
    NOEKEON,
    PBEWITHSHAAND128BITRC4,
    PBEWITHSHAAND40BITRC4,
    RC2,
    RC5,
    RC5_64,
    RC6,
    RIJNDAEL,
    RSA,
    SALSA20,
    SEED,
    SERPENT,
    SKIPJACK,
    SM4,
    TEA,
    THREEFISH_256,
    THREEFISH_512,
    THREEFISH_1024,
    TNEPRES,
    TWOFISH,
    VMPC,
    VMPC_KSA3,
    XTEA,
  }

  private enum CipherMode
  {
    ECB,
    NONE,
    CBC,
    CCM,
    CFB,
    CTR,
    CTS,
    EAX,
    GCM,
    GOFB,
    OCB,
    OFB,
    OPENPGPCFB,
    SIC,
  }

  private enum CipherPadding
  {
    NOPADDING,
    RAW,
    ISO10126PADDING,
    ISO10126D2PADDING,
    ISO10126_2PADDING,
    ISO7816_4PADDING,
    ISO9797_1PADDING,
    ISO9796_1,
    ISO9796_1PADDING,
    OAEP,
    OAEPPADDING,
    OAEPWITHMD5ANDMGF1PADDING,
    OAEPWITHSHA1ANDMGF1PADDING,
    OAEPWITHSHA_1ANDMGF1PADDING,
    OAEPWITHSHA224ANDMGF1PADDING,
    OAEPWITHSHA_224ANDMGF1PADDING,
    OAEPWITHSHA256ANDMGF1PADDING,
    OAEPWITHSHA_256ANDMGF1PADDING,
    OAEPWITHSHA256ANDMGF1WITHSHA256PADDING,
    OAEPWITHSHA_256ANDMGF1WITHSHA_256PADDING,
    OAEPWITHSHA256ANDMGF1WITHSHA1PADDING,
    OAEPWITHSHA_256ANDMGF1WITHSHA_1PADDING,
    OAEPWITHSHA384ANDMGF1PADDING,
    OAEPWITHSHA_384ANDMGF1PADDING,
    OAEPWITHSHA512ANDMGF1PADDING,
    OAEPWITHSHA_512ANDMGF1PADDING,
    PKCS1,
    PKCS1PADDING,
    PKCS5,
    PKCS5PADDING,
    PKCS7,
    PKCS7PADDING,
    TBCPADDING,
    WITHCTS,
    X923PADDING,
    ZEROBYTEPADDING,
  }
}
