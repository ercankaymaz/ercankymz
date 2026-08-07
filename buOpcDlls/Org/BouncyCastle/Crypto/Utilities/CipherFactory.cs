// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Utilities.CipherFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Kisa;
using Org.BouncyCastle.Asn1.Misc;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Ntt;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Utilities;

public class CipherFactory
{
  private static readonly byte[] RC2Ekb = new byte[256 /*0x0100*/]
  {
    (byte) 93,
    (byte) 190,
    (byte) 155,
    (byte) 139,
    (byte) 17,
    (byte) 153,
    (byte) 110,
    (byte) 77,
    (byte) 89,
    (byte) 243,
    (byte) 133,
    (byte) 166,
    (byte) 63 /*0x3F*/,
    (byte) 183,
    (byte) 131,
    (byte) 197,
    (byte) 228,
    (byte) 115,
    (byte) 107,
    (byte) 58,
    (byte) 104,
    (byte) 90,
    (byte) 192 /*0xC0*/,
    (byte) 71,
    (byte) 160 /*0xA0*/,
    (byte) 100,
    (byte) 52,
    (byte) 12,
    (byte) 241,
    (byte) 208 /*0xD0*/,
    (byte) 82,
    (byte) 165,
    (byte) 185,
    (byte) 30,
    (byte) 150,
    (byte) 67,
    (byte) 65,
    (byte) 216,
    (byte) 212,
    (byte) 44,
    (byte) 219,
    (byte) 248,
    (byte) 7,
    (byte) 119,
    (byte) 42,
    (byte) 202,
    (byte) 235,
    (byte) 239,
    (byte) 16 /*0x10*/,
    (byte) 28,
    (byte) 22,
    (byte) 13,
    (byte) 56,
    (byte) 114,
    (byte) 47,
    (byte) 137,
    (byte) 193,
    (byte) 249,
    (byte) 128 /*0x80*/,
    (byte) 196,
    (byte) 109,
    (byte) 174,
    (byte) 48 /*0x30*/,
    (byte) 61,
    (byte) 206,
    (byte) 32 /*0x20*/,
    (byte) 99,
    (byte) 254,
    (byte) 230,
    (byte) 26,
    (byte) 199,
    (byte) 184,
    (byte) 80 /*0x50*/,
    (byte) 232,
    (byte) 36,
    (byte) 23,
    (byte) 252,
    (byte) 37,
    (byte) 111,
    (byte) 187,
    (byte) 106,
    (byte) 163,
    (byte) 68,
    (byte) 83,
    (byte) 217,
    (byte) 162,
    (byte) 1,
    (byte) 171,
    (byte) 188,
    (byte) 182,
    (byte) 31 /*0x1F*/,
    (byte) 152,
    (byte) 238,
    (byte) 154,
    (byte) 167,
    (byte) 45,
    (byte) 79,
    (byte) 158,
    (byte) 142,
    (byte) 172,
    (byte) 224 /*0xE0*/,
    (byte) 198,
    (byte) 73,
    (byte) 70,
    (byte) 41,
    (byte) 244,
    (byte) 148,
    (byte) 138,
    (byte) 175,
    (byte) 225,
    (byte) 91,
    (byte) 195,
    (byte) 179,
    (byte) 123,
    (byte) 87,
    (byte) 209,
    (byte) 124,
    (byte) 156,
    (byte) 237,
    (byte) 135,
    (byte) 64 /*0x40*/,
    (byte) 140,
    (byte) 226,
    (byte) 203,
    (byte) 147,
    (byte) 20,
    (byte) 201,
    (byte) 97,
    (byte) 46,
    (byte) 229,
    (byte) 204,
    (byte) 246,
    (byte) 94,
    (byte) 168,
    (byte) 92,
    (byte) 214,
    (byte) 117,
    (byte) 141,
    (byte) 98,
    (byte) 149,
    (byte) 88,
    (byte) 105,
    (byte) 118,
    (byte) 161,
    (byte) 74,
    (byte) 181,
    (byte) 85,
    (byte) 9,
    (byte) 120,
    (byte) 51,
    (byte) 130,
    (byte) 215,
    (byte) 221,
    (byte) 121,
    (byte) 245,
    (byte) 27,
    (byte) 11,
    (byte) 222,
    (byte) 38,
    (byte) 33,
    (byte) 40,
    (byte) 116,
    (byte) 4,
    (byte) 151,
    (byte) 86,
    (byte) 223,
    (byte) 60,
    (byte) 240 /*0xF0*/,
    (byte) 55,
    (byte) 57,
    (byte) 220,
    byte.MaxValue,
    (byte) 6,
    (byte) 164,
    (byte) 234,
    (byte) 66,
    (byte) 8,
    (byte) 218,
    (byte) 180,
    (byte) 113,
    (byte) 176 /*0xB0*/,
    (byte) 207,
    (byte) 18,
    (byte) 122,
    (byte) 78,
    (byte) 250,
    (byte) 108,
    (byte) 29,
    (byte) 132,
    (byte) 0,
    (byte) 200,
    (byte) 127 /*0x7F*/,
    (byte) 145,
    (byte) 69,
    (byte) 170,
    (byte) 43,
    (byte) 194,
    (byte) 177,
    (byte) 143,
    (byte) 213,
    (byte) 186,
    (byte) 242,
    (byte) 173,
    (byte) 25,
    (byte) 178,
    (byte) 103,
    (byte) 54,
    (byte) 247,
    (byte) 15,
    (byte) 10,
    (byte) 146,
    (byte) 125,
    (byte) 227,
    (byte) 157,
    (byte) 233,
    (byte) 144 /*0x90*/,
    (byte) 62,
    (byte) 35,
    (byte) 39,
    (byte) 102,
    (byte) 19,
    (byte) 236,
    (byte) 129,
    (byte) 21,
    (byte) 189,
    (byte) 34,
    (byte) 191,
    (byte) 159,
    (byte) 126,
    (byte) 169,
    (byte) 81,
    (byte) 75,
    (byte) 76,
    (byte) 251,
    (byte) 2,
    (byte) 211,
    (byte) 112 /*0x70*/,
    (byte) 134,
    (byte) 49,
    (byte) 231,
    (byte) 59,
    (byte) 5,
    (byte) 3,
    (byte) 84,
    (byte) 96 /*0x60*/,
    (byte) 72,
    (byte) 101,
    (byte) 24,
    (byte) 210,
    (byte) 205,
    (byte) 95,
    (byte) 50,
    (byte) 136,
    (byte) 14,
    (byte) 53,
    (byte) 253
  };

  private CipherFactory()
  {
  }

  public static object CreateContentCipher(
    bool forEncryption,
    ICipherParameters encKey,
    AlgorithmIdentifier encryptionAlgID)
  {
    DerObjectIdentifier algorithm = encryptionAlgID.Algorithm;
    if (algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.rc4))
    {
      RC4Engine contentCipher = new RC4Engine();
      contentCipher.Init(forEncryption, encKey);
      return (object) contentCipher;
    }
    BufferedBlockCipher cipher = CipherFactory.CreateCipher(encryptionAlgID.Algorithm);
    Asn1Object asn1Object = encryptionAlgID.Parameters.ToAsn1Object();
    if (asn1Object != null && !(asn1Object is DerNull))
    {
      if (!algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.DesEde3Cbc) && !algorithm.Equals((Asn1Object) AlgorithmIdentifierFactory.IDEA_CBC) && !algorithm.Equals((Asn1Object) NistObjectIdentifiers.IdAes128Cbc) && !algorithm.Equals((Asn1Object) NistObjectIdentifiers.IdAes192Cbc) && !algorithm.Equals((Asn1Object) NistObjectIdentifiers.IdAes256Cbc) && !algorithm.Equals((Asn1Object) NttObjectIdentifiers.IdCamellia128Cbc) && !algorithm.Equals((Asn1Object) NttObjectIdentifiers.IdCamellia192Cbc) && !algorithm.Equals((Asn1Object) NttObjectIdentifiers.IdCamellia256Cbc) && !algorithm.Equals((Asn1Object) KisaObjectIdentifiers.IdSeedCbc) && !algorithm.Equals((Asn1Object) OiwObjectIdentifiers.DesCbc))
      {
        if (algorithm.Equals((Asn1Object) AlgorithmIdentifierFactory.CAST5_CBC))
        {
          Cast5CbcParameters instance = Cast5CbcParameters.GetInstance((object) asn1Object);
          cipher.Init(forEncryption, (ICipherParameters) new ParametersWithIV(encKey, instance.GetIV()));
        }
        else
        {
          if (!algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.RC2Cbc))
            throw new InvalidOperationException("cannot match parameters");
          RC2CbcParameter instance = RC2CbcParameter.GetInstance((object) asn1Object);
          cipher.Init(forEncryption, (ICipherParameters) new ParametersWithIV((ICipherParameters) new RC2Parameters(((KeyParameter) encKey).GetKey(), (int) CipherFactory.RC2Ekb[instance.RC2ParameterVersion.IntValue]), instance.GetIV()));
        }
      }
      else
        cipher.Init(forEncryption, (ICipherParameters) new ParametersWithIV(encKey, Asn1OctetString.GetInstance((object) asn1Object).GetOctets()));
    }
    else if (!algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.DesEde3Cbc) && !algorithm.Equals((Asn1Object) AlgorithmIdentifierFactory.IDEA_CBC) && !algorithm.Equals((Asn1Object) AlgorithmIdentifierFactory.CAST5_CBC))
      cipher.Init(forEncryption, encKey);
    else
      cipher.Init(forEncryption, (ICipherParameters) new ParametersWithIV(encKey, new byte[8]));
    return (object) cipher;
  }

  private static BufferedBlockCipher CreateCipher(DerObjectIdentifier algorithm)
  {
    IBlockCipherMode cipherMode;
    if (!NistObjectIdentifiers.IdAes128Cbc.Equals((Asn1Object) algorithm) && !NistObjectIdentifiers.IdAes192Cbc.Equals((Asn1Object) algorithm) && !NistObjectIdentifiers.IdAes256Cbc.Equals((Asn1Object) algorithm))
    {
      if (PkcsObjectIdentifiers.DesEde3Cbc.Equals((Asn1Object) algorithm))
        cipherMode = (IBlockCipherMode) new CbcBlockCipher((IBlockCipher) new DesEdeEngine());
      else if (OiwObjectIdentifiers.DesCbc.Equals((Asn1Object) algorithm))
        cipherMode = (IBlockCipherMode) new CbcBlockCipher((IBlockCipher) new DesEngine());
      else if (PkcsObjectIdentifiers.RC2Cbc.Equals((Asn1Object) algorithm))
      {
        cipherMode = (IBlockCipherMode) new CbcBlockCipher((IBlockCipher) new RC2Engine());
      }
      else
      {
        if (!MiscObjectIdentifiers.cast5CBC.Equals((Asn1Object) algorithm))
          throw new InvalidOperationException("cannot recognise cipher: " + algorithm?.ToString());
        cipherMode = (IBlockCipherMode) new CbcBlockCipher((IBlockCipher) new Cast5Engine());
      }
    }
    else
      cipherMode = (IBlockCipherMode) new CbcBlockCipher(AesUtilities.CreateEngine());
    return (BufferedBlockCipher) new PaddedBufferedBlockCipher(cipherMode, (IBlockCipherPadding) new Pkcs7Padding());
  }
}
