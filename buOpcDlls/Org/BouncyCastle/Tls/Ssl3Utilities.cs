// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Ssl3Utilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

internal abstract class Ssl3Utilities
{
  private static readonly byte[] SSL_CLIENT = new byte[4]
  {
    (byte) 67,
    (byte) 76,
    (byte) 78,
    (byte) 84
  };
  private static readonly byte[] SSL_SERVER = new byte[4]
  {
    (byte) 83,
    (byte) 82,
    (byte) 86,
    (byte) 82
  };
  private const byte IPAD_BYTE = 54;
  private const byte OPAD_BYTE = 92;
  private static readonly byte[] IPAD = Ssl3Utilities.GenPad((byte) 54, 48 /*0x30*/);
  private static readonly byte[] OPAD = Ssl3Utilities.GenPad((byte) 92, 48 /*0x30*/);

  internal static byte[] CalculateVerifyData(TlsHandshakeHash handshakeHash, bool isServer)
  {
    TlsHash tlsHash = handshakeHash.ForkPrfHash();
    byte[] input = isServer ? Ssl3Utilities.SSL_SERVER : Ssl3Utilities.SSL_CLIENT;
    tlsHash.Update(input, 0, input.Length);
    return tlsHash.CalculateHash();
  }

  internal static void CompleteCombinedHash(TlsContext context, TlsHash md5, TlsHash sha1)
  {
    TlsSecret masterSecret = context.SecurityParameters.MasterSecret;
    byte[] master_secret = context.Crypto.AdoptSecret(masterSecret).Extract();
    Ssl3Utilities.CompleteHash(master_secret, md5, 48 /*0x30*/);
    Ssl3Utilities.CompleteHash(master_secret, sha1, 40);
  }

  private static void CompleteHash(byte[] master_secret, TlsHash hash, int padLength)
  {
    hash.Update(master_secret, 0, master_secret.Length);
    hash.Update(Ssl3Utilities.IPAD, 0, padLength);
    byte[] hash1 = hash.CalculateHash();
    hash.Update(master_secret, 0, master_secret.Length);
    hash.Update(Ssl3Utilities.OPAD, 0, padLength);
    hash.Update(hash1, 0, hash1.Length);
  }

  private static byte[] GenPad(byte b, int count)
  {
    byte[] buf = new byte[count];
    Arrays.Fill(buf, b);
    return buf;
  }

  internal static byte[] ReadEncryptedPms(Stream input) => Streams.ReadAll(input);

  internal static void WriteEncryptedPms(byte[] encryptedPms, Stream output)
  {
    output.Write(encryptedPms, 0, encryptedPms.Length);
  }
}
