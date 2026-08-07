// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.TlsCryptoUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto;

public abstract class TlsCryptoUtilities
{
  private static readonly byte[] Tls13Prefix = new byte[6]
  {
    (byte) 116,
    (byte) 108,
    (byte) 115,
    (byte) 49,
    (byte) 51,
    (byte) 32 /*0x20*/
  };

  public static int GetHash(short hashAlgorithm)
  {
    switch (hashAlgorithm)
    {
      case 1:
        return 1;
      case 2:
        return 2;
      case 3:
        return 3;
      case 4:
        return 4;
      case 5:
        return 5;
      case 6:
        return 6;
      default:
        throw new ArgumentException("specified HashAlgorithm invalid: " + HashAlgorithm.GetText(hashAlgorithm));
    }
  }

  public static int GetHashForHmac(int macAlgorithm)
  {
    switch (macAlgorithm)
    {
      case 1:
        return 1;
      case 2:
        return 2;
      case 3:
        return 4;
      case 4:
        return 5;
      case 5:
        return 6;
      default:
        throw new ArgumentException("specified MacAlgorithm not an HMAC: " + MacAlgorithm.GetText(macAlgorithm));
    }
  }

  public static int GetHashForPrf(int prfAlgorithm)
  {
    switch (prfAlgorithm)
    {
      case 0:
      case 1:
        throw new ArgumentException("legacy PRF not a valid algorithm");
      case 2:
      case 4:
        return 4;
      case 3:
      case 5:
        return 5;
      case 7:
        return 7;
      default:
        throw new ArgumentException("unknown PrfAlgorithm: " + PrfAlgorithm.GetText(prfAlgorithm));
    }
  }

  public static int GetHashInternalSize(int cryptoHashAlgorithm)
  {
    switch (cryptoHashAlgorithm)
    {
      case 1:
      case 2:
      case 3:
      case 4:
      case 7:
        return 64 /*0x40*/;
      case 5:
      case 6:
        return 128 /*0x80*/;
      default:
        throw new ArgumentException();
    }
  }

  public static int GetHashOutputSize(int cryptoHashAlgorithm)
  {
    switch (cryptoHashAlgorithm)
    {
      case 1:
        return 16 /*0x10*/;
      case 2:
        return 20;
      case 3:
        return 28;
      case 4:
      case 7:
        return 32 /*0x20*/;
      case 5:
        return 48 /*0x30*/;
      case 6:
        return 64 /*0x40*/;
      default:
        throw new ArgumentException();
    }
  }

  public static DerObjectIdentifier GetOidForHash(int cryptoHashAlgorithm)
  {
    switch (cryptoHashAlgorithm)
    {
      case 1:
        return PkcsObjectIdentifiers.MD5;
      case 2:
        return X509ObjectIdentifiers.IdSha1;
      case 3:
        return NistObjectIdentifiers.IdSha224;
      case 4:
        return NistObjectIdentifiers.IdSha256;
      case 5:
        return NistObjectIdentifiers.IdSha384;
      case 6:
        return NistObjectIdentifiers.IdSha512;
      default:
        throw new ArgumentException();
    }
  }

  public static int GetSignature(short signatureAlgorithm)
  {
    switch (signatureAlgorithm)
    {
      case 1:
        return 1;
      case 2:
        return 2;
      case 3:
        return 3;
      case 4:
        return 4;
      case 5:
        return 5;
      case 6:
        return 6;
      case 7:
        return 7;
      case 8:
        return 8;
      case 9:
        return 9;
      case 10:
        return 10;
      case 11:
        return 11;
      case 26:
        return 26;
      case 27:
        return 27;
      case 28:
        return 28;
      case 64 /*0x40*/:
        return 64 /*0x40*/;
      case 65:
        return 65;
      default:
        throw new ArgumentException("specified SignatureAlgorithm invalid: " + SignatureAlgorithm.GetText(signatureAlgorithm));
    }
  }

  public static TlsSecret HkdfExpandLabel(
    TlsSecret secret,
    int cryptoHashAlgorithm,
    string label,
    byte[] context,
    int length)
  {
    int length1 = label.Length;
    if (length1 < 1)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    int length2 = context.Length;
    int i = TlsCryptoUtilities.Tls13Prefix.Length + length1;
    byte[] numArray = new byte[2 + (1 + i) + (1 + length2)];
    TlsUtilities.CheckUint16(length);
    TlsUtilities.WriteUint16(length, numArray, 0);
    TlsUtilities.CheckUint8(i);
    TlsUtilities.WriteUint8(i, numArray, 2);
    Array.Copy((Array) TlsCryptoUtilities.Tls13Prefix, 0, (Array) numArray, 3, TlsCryptoUtilities.Tls13Prefix.Length);
    int num = 2 + (1 + TlsCryptoUtilities.Tls13Prefix.Length);
    for (int index = 0; index < length1; ++index)
    {
      char ch = label[index];
      numArray[num + index] = (byte) ch;
    }
    TlsUtilities.WriteOpaque8(context, numArray, 2 + (1 + i));
    return secret.HkdfExpand(cryptoHashAlgorithm, numArray, length);
  }
}
