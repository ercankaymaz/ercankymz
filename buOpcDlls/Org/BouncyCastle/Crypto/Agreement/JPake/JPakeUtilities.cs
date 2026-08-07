// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.JPake.JPakeUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement.JPake;

public abstract class JPakeUtilities
{
  public static readonly BigInteger Zero = BigInteger.Zero;
  public static readonly BigInteger One = BigInteger.One;

  public static BigInteger GenerateX1(BigInteger q, SecureRandom random)
  {
    return BigIntegers.CreateRandomInRange(JPakeUtilities.Zero, q.Subtract(JPakeUtilities.One), random);
  }

  public static BigInteger GenerateX2(BigInteger q, SecureRandom random)
  {
    return BigIntegers.CreateRandomInRange(JPakeUtilities.One, q.Subtract(JPakeUtilities.One), random);
  }

  [Obsolete("Use version including the modulus instead")]
  public static BigInteger CalculateS(char[] password)
  {
    return new BigInteger(1, Strings.ToUtf8ByteArray(password));
  }

  public static BigInteger CalculateS(BigInteger q, byte[] password)
  {
    BigInteger bigInteger = new BigInteger(1, password).Mod(q);
    return bigInteger.SignValue != 0 ? bigInteger : throw new CryptoException("MUST ensure s is not equal to 0 modulo q");
  }

  public static BigInteger CalculateS(BigInteger q, char[] password)
  {
    return JPakeUtilities.CalculateS(q, Strings.ToUtf8ByteArray(password));
  }

  public static BigInteger CalculateGx(BigInteger p, BigInteger g, BigInteger x) => g.ModPow(x, p);

  public static BigInteger CalculateGA(
    BigInteger p,
    BigInteger gx1,
    BigInteger gx3,
    BigInteger gx4)
  {
    return gx1.Multiply(gx3).Multiply(gx4).Mod(p);
  }

  public static BigInteger CalculateX2s(BigInteger q, BigInteger x2, BigInteger s)
  {
    return x2.Multiply(s).Mod(q);
  }

  public static BigInteger CalculateA(BigInteger p, BigInteger q, BigInteger gA, BigInteger x2s)
  {
    return gA.ModPow(x2s, p);
  }

  public static BigInteger[] CalculateZeroKnowledgeProof(
    BigInteger p,
    BigInteger q,
    BigInteger g,
    BigInteger gx,
    BigInteger x,
    string participantId,
    IDigest digest,
    SecureRandom random)
  {
    BigInteger randomInRange = BigIntegers.CreateRandomInRange(JPakeUtilities.Zero, q.Subtract(JPakeUtilities.One), random);
    BigInteger gr = g.ModPow(randomInRange, p);
    BigInteger zeroKnowledgeProof = JPakeUtilities.CalculateHashForZeroKnowledgeProof(g, gr, gx, participantId, digest);
    return new BigInteger[2]
    {
      gr,
      randomInRange.Subtract(x.Multiply(zeroKnowledgeProof)).Mod(q)
    };
  }

  private static BigInteger CalculateHashForZeroKnowledgeProof(
    BigInteger g,
    BigInteger gr,
    BigInteger gx,
    string participantId,
    IDigest digest)
  {
    digest.Reset();
    JPakeUtilities.UpdateDigestIncludingSize(digest, g);
    JPakeUtilities.UpdateDigestIncludingSize(digest, gr);
    JPakeUtilities.UpdateDigestIncludingSize(digest, gx);
    JPakeUtilities.UpdateDigestIncludingSize(digest, participantId);
    return new BigInteger(DigestUtilities.DoFinal(digest));
  }

  public static void ValidateGx4(BigInteger gx4)
  {
    if (gx4.Equals(JPakeUtilities.One))
      throw new CryptoException("g^x validation failed.  g^x should not be 1.");
  }

  public static void ValidateGa(BigInteger ga)
  {
    if (ga.Equals(JPakeUtilities.One))
      throw new CryptoException("ga is equal to 1.  It should not be.  The chances of this happening are on the order of 2^160 for a 160-bit q.  Try again.");
  }

  public static void ValidateZeroKnowledgeProof(
    BigInteger p,
    BigInteger q,
    BigInteger g,
    BigInteger gx,
    BigInteger[] zeroKnowledgeProof,
    string participantId,
    IDigest digest)
  {
    BigInteger bigInteger = zeroKnowledgeProof[0];
    BigInteger e = zeroKnowledgeProof[1];
    BigInteger zeroKnowledgeProof1 = JPakeUtilities.CalculateHashForZeroKnowledgeProof(g, bigInteger, gx, participantId, digest);
    if (gx.CompareTo(JPakeUtilities.Zero) != 1 || gx.CompareTo(p) != -1 || gx.ModPow(q, p).CompareTo(JPakeUtilities.One) != 0 || g.ModPow(e, p).Multiply(gx.ModPow(zeroKnowledgeProof1, p)).Mod(p).CompareTo(bigInteger) != 0)
      throw new CryptoException("Zero-knowledge proof validation failed");
  }

  public static BigInteger CalculateKeyingMaterial(
    BigInteger p,
    BigInteger q,
    BigInteger gx4,
    BigInteger x2,
    BigInteger s,
    BigInteger B)
  {
    return gx4.ModPow(x2.Multiply(s).Negate().Mod(q), p).Multiply(B).ModPow(x2, p);
  }

  public static void ValidateParticipantIdsDiffer(string participantId1, string participantId2)
  {
    if (participantId1.Equals(participantId2))
      throw new CryptoException($"Both participants are using the same participantId ({participantId1}). This is not allowed. Each participant must use a unique participantId.");
  }

  public static void ValidateParticipantIdsEqual(
    string expectedParticipantId,
    string actualParticipantId)
  {
    if (!expectedParticipantId.Equals(actualParticipantId))
      throw new CryptoException($"Received payload from incorrect partner ({actualParticipantId}). Expected to receive payload from {expectedParticipantId}.");
  }

  public static void ValidateNotNull(object obj, string description)
  {
    if (obj == null)
      throw new ArgumentNullException(description);
  }

  public static BigInteger CalculateMacTag(
    string participantId,
    string partnerParticipantId,
    BigInteger gx1,
    BigInteger gx2,
    BigInteger gx3,
    BigInteger gx4,
    BigInteger keyingMaterial,
    IDigest digest)
  {
    byte[] macKey = JPakeUtilities.CalculateMacKey(keyingMaterial, digest);
    HMac hmac = new HMac(digest);
    hmac.Init((ICipherParameters) new KeyParameter(macKey));
    Arrays.Fill(macKey, (byte) 0);
    JPakeUtilities.UpdateMac((IMac) hmac, "KC_1_U");
    JPakeUtilities.UpdateMac((IMac) hmac, participantId);
    JPakeUtilities.UpdateMac((IMac) hmac, partnerParticipantId);
    JPakeUtilities.UpdateMac((IMac) hmac, gx1);
    JPakeUtilities.UpdateMac((IMac) hmac, gx2);
    JPakeUtilities.UpdateMac((IMac) hmac, gx3);
    JPakeUtilities.UpdateMac((IMac) hmac, gx4);
    return new BigInteger(MacUtilities.DoFinal((IMac) hmac));
  }

  private static byte[] CalculateMacKey(BigInteger keyingMaterial, IDigest digest)
  {
    digest.Reset();
    JPakeUtilities.UpdateDigest(digest, keyingMaterial);
    JPakeUtilities.UpdateDigest(digest, "JPAKE_KC");
    return DigestUtilities.DoFinal(digest);
  }

  public static void ValidateMacTag(
    string participantId,
    string partnerParticipantId,
    BigInteger gx1,
    BigInteger gx2,
    BigInteger gx3,
    BigInteger gx4,
    BigInteger keyingMaterial,
    IDigest digest,
    BigInteger partnerMacTag)
  {
    if (!JPakeUtilities.CalculateMacTag(partnerParticipantId, participantId, gx3, gx4, gx1, gx2, keyingMaterial, digest).Equals(partnerMacTag))
      throw new CryptoException("Partner MacTag validation failed. Therefore, the password, MAC, or digest algorithm of each participant does not match.");
  }

  private static void UpdateDigest(IDigest digest, BigInteger bigInteger)
  {
    JPakeUtilities.UpdateDigest(digest, BigIntegers.AsUnsignedByteArray(bigInteger));
  }

  private static void UpdateDigest(IDigest digest, string str)
  {
    JPakeUtilities.UpdateDigest(digest, Strings.ToUtf8ByteArray(str));
  }

  private static void UpdateDigest(IDigest digest, byte[] bytes)
  {
    digest.BlockUpdate(bytes, 0, bytes.Length);
    Arrays.Fill(bytes, (byte) 0);
  }

  private static void UpdateDigestIncludingSize(IDigest digest, BigInteger bigInteger)
  {
    JPakeUtilities.UpdateDigestIncludingSize(digest, BigIntegers.AsUnsignedByteArray(bigInteger));
  }

  private static void UpdateDigestIncludingSize(IDigest digest, string str)
  {
    JPakeUtilities.UpdateDigestIncludingSize(digest, Strings.ToUtf8ByteArray(str));
  }

  private static void UpdateDigestIncludingSize(IDigest digest, byte[] bytes)
  {
    digest.BlockUpdate(JPakeUtilities.IntToByteArray(bytes.Length), 0, 4);
    digest.BlockUpdate(bytes, 0, bytes.Length);
    Arrays.Fill(bytes, (byte) 0);
  }

  private static void UpdateMac(IMac mac, BigInteger bigInteger)
  {
    JPakeUtilities.UpdateMac(mac, BigIntegers.AsUnsignedByteArray(bigInteger));
  }

  private static void UpdateMac(IMac mac, string str)
  {
    JPakeUtilities.UpdateMac(mac, Strings.ToUtf8ByteArray(str));
  }

  private static void UpdateMac(IMac mac, byte[] bytes)
  {
    mac.BlockUpdate(bytes, 0, bytes.Length);
    Arrays.Fill(bytes, (byte) 0);
  }

  private static byte[] IntToByteArray(int value) => Pack.UInt32_To_BE((uint) value);
}
