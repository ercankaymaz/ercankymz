// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.Rfc6637Utilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public sealed class Rfc6637Utilities
{
  private static readonly byte[] ANONYMOUS_SENDER = Hex.Decode("416E6F6E796D6F75732053656E64657220202020");

  private Rfc6637Utilities()
  {
  }

  public static string GetAgreementAlgorithm(PublicKeyPacket pubKeyData)
  {
    ECDHPublicBcpgKey key = (ECDHPublicBcpgKey) pubKeyData.Key;
    switch (key.HashAlgorithm)
    {
      case HashAlgorithmTag.Sha256:
        return "ECCDHwithSHA256CKDF";
      case HashAlgorithmTag.Sha384:
        return "ECCDHwithSHA384CKDF";
      case HashAlgorithmTag.Sha512:
        return "ECCDHwithSHA512CKDF";
      default:
        throw new ArgumentException("Unknown hash algorithm specified: " + key.HashAlgorithm.ToString());
    }
  }

  public static DerObjectIdentifier GetKeyEncryptionOID(SymmetricKeyAlgorithmTag algID)
  {
    switch (algID)
    {
      case SymmetricKeyAlgorithmTag.Aes128:
        return NistObjectIdentifiers.IdAes128Wrap;
      case SymmetricKeyAlgorithmTag.Aes192:
        return NistObjectIdentifiers.IdAes192Wrap;
      case SymmetricKeyAlgorithmTag.Aes256:
        return NistObjectIdentifiers.IdAes256Wrap;
      default:
        throw new PgpException("unknown symmetric algorithm ID: " + algID.ToString());
    }
  }

  public static int GetKeyLength(SymmetricKeyAlgorithmTag algID)
  {
    switch (algID)
    {
      case SymmetricKeyAlgorithmTag.Aes128:
        return 16 /*0x10*/;
      case SymmetricKeyAlgorithmTag.Aes192:
        return 24;
      case SymmetricKeyAlgorithmTag.Aes256:
        return 32 /*0x20*/;
      default:
        throw new PgpException("unknown symmetric algorithm ID: " + algID.ToString());
    }
  }

  public static byte[] CreateKey(PublicKeyPacket pubKeyData, ECPoint s)
  {
    return Rfc6637Utilities.CreateKey(pubKeyData, s.AffineXCoord.GetEncoded());
  }

  public static byte[] CreateKey(PublicKeyPacket pubKeyData, byte[] secret)
  {
    byte[] userKeyingMaterial = Rfc6637Utilities.CreateUserKeyingMaterial(pubKeyData);
    ECDHPublicBcpgKey key = (ECDHPublicBcpgKey) pubKeyData.Key;
    return Rfc6637Utilities.Kdf(key.HashAlgorithm, secret, Rfc6637Utilities.GetKeyLength(key.SymmetricKeyAlgorithm), userKeyingMaterial);
  }

  public static byte[] CreateUserKeyingMaterial(PublicKeyPacket pubKeyData)
  {
    MemoryStream memoryStream = new MemoryStream();
    ECDHPublicBcpgKey key = (ECDHPublicBcpgKey) pubKeyData.Key;
    byte[] encoded = key.CurveOid.GetEncoded();
    memoryStream.Write(encoded, 1, encoded.Length - 1);
    memoryStream.WriteByte((byte) pubKeyData.Algorithm);
    memoryStream.WriteByte((byte) 3);
    memoryStream.WriteByte((byte) 1);
    memoryStream.WriteByte((byte) key.HashAlgorithm);
    memoryStream.WriteByte((byte) key.SymmetricKeyAlgorithm);
    memoryStream.Write(Rfc6637Utilities.ANONYMOUS_SENDER, 0, Rfc6637Utilities.ANONYMOUS_SENDER.Length);
    byte[] fingerprint = PgpPublicKey.CalculateFingerprint(pubKeyData);
    memoryStream.Write(fingerprint, 0, fingerprint.Length);
    return memoryStream.ToArray();
  }

  private static byte[] Kdf(HashAlgorithmTag digestAlg, byte[] ZB, int keyLen, byte[] parameters)
  {
    IDigest digest = PgpUtilities.CreateDigest(digestAlg);
    digest.Update((byte) 0);
    digest.Update((byte) 0);
    digest.Update((byte) 0);
    digest.Update((byte) 1);
    digest.BlockUpdate(ZB, 0, ZB.Length);
    digest.BlockUpdate(parameters, 0, parameters.Length);
    return Arrays.CopyOfRange(DigestUtilities.DoFinal(digest), 0, keyLen);
  }
}
