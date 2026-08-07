// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.Srp.Srp6Utilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement.Srp;

public class Srp6Utilities
{
  public static BigInteger CalculateK(IDigest digest, BigInteger N, BigInteger g)
  {
    return Srp6Utilities.HashPaddedPair(digest, N, N, g);
  }

  public static BigInteger CalculateU(IDigest digest, BigInteger N, BigInteger A, BigInteger B)
  {
    return Srp6Utilities.HashPaddedPair(digest, N, A, B);
  }

  public static BigInteger CalculateX(
    IDigest digest,
    BigInteger N,
    byte[] salt,
    byte[] identity,
    byte[] password)
  {
    byte[] numArray = new byte[digest.GetDigestSize()];
    digest.BlockUpdate(identity, 0, identity.Length);
    digest.Update((byte) 58);
    digest.BlockUpdate(password, 0, password.Length);
    digest.DoFinal(numArray, 0);
    digest.BlockUpdate(salt, 0, salt.Length);
    digest.BlockUpdate(numArray, 0, numArray.Length);
    digest.DoFinal(numArray, 0);
    return new BigInteger(1, numArray);
  }

  public static BigInteger GeneratePrivateValue(
    IDigest digest,
    BigInteger N,
    BigInteger g,
    SecureRandom random)
  {
    int num = System.Math.Min(256 /*0x0100*/, N.BitLength / 2);
    return BigIntegers.CreateRandomInRange(BigInteger.One.ShiftLeft(num - 1), N.Subtract(BigInteger.One), random);
  }

  public static BigInteger ValidatePublicValue(BigInteger N, BigInteger val)
  {
    val = val.Mod(N);
    return !val.Equals(BigInteger.Zero) ? val : throw new CryptoException("Invalid public value: 0");
  }

  public static BigInteger CalculateM1(
    IDigest digest,
    BigInteger N,
    BigInteger A,
    BigInteger B,
    BigInteger S)
  {
    return Srp6Utilities.HashPaddedTriplet(digest, N, A, B, S);
  }

  public static BigInteger CalculateM2(
    IDigest digest,
    BigInteger N,
    BigInteger A,
    BigInteger M1,
    BigInteger S)
  {
    return Srp6Utilities.HashPaddedTriplet(digest, N, A, M1, S);
  }

  public static BigInteger CalculateKey(IDigest digest, BigInteger N, BigInteger S)
  {
    int length = (N.BitLength + 7) / 8;
    int digestSize = digest.GetDigestSize();
    byte[] numArray1 = new byte[length];
    BigIntegers.AsUnsignedByteArray(S, numArray1, 0, numArray1.Length);
    digest.BlockUpdate(numArray1, 0, numArray1.Length);
    byte[] numArray2 = new byte[digestSize];
    digest.DoFinal(numArray2, 0);
    return new BigInteger(1, numArray2);
  }

  private static BigInteger HashPaddedTriplet(
    IDigest digest,
    BigInteger N,
    BigInteger n1,
    BigInteger n2,
    BigInteger n3)
  {
    int length = (N.BitLength + 7) / 8;
    int digestSize = digest.GetDigestSize();
    byte[] numArray1 = new byte[length];
    BigIntegers.AsUnsignedByteArray(n1, numArray1, 0, numArray1.Length);
    digest.BlockUpdate(numArray1, 0, numArray1.Length);
    BigIntegers.AsUnsignedByteArray(n2, numArray1, 0, numArray1.Length);
    digest.BlockUpdate(numArray1, 0, numArray1.Length);
    BigIntegers.AsUnsignedByteArray(n3, numArray1, 0, numArray1.Length);
    digest.BlockUpdate(numArray1, 0, numArray1.Length);
    byte[] numArray2 = new byte[digestSize];
    digest.DoFinal(numArray2, 0);
    return new BigInteger(1, numArray2);
  }

  private static BigInteger HashPaddedPair(
    IDigest digest,
    BigInteger N,
    BigInteger n1,
    BigInteger n2)
  {
    int length = (N.BitLength + 7) / 8;
    int digestSize = digest.GetDigestSize();
    byte[] numArray1 = new byte[length];
    BigIntegers.AsUnsignedByteArray(n1, numArray1, 0, numArray1.Length);
    digest.BlockUpdate(numArray1, 0, numArray1.Length);
    BigIntegers.AsUnsignedByteArray(n2, numArray1, 0, numArray1.Length);
    digest.BlockUpdate(numArray1, 0, numArray1.Length);
    byte[] numArray2 = new byte[digestSize];
    digest.DoFinal(numArray2, 0);
    return new BigInteger(1, numArray2);
  }
}
