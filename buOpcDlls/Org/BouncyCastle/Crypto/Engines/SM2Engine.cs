// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.SM2Engine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class SM2Engine
{
  private readonly IDigest mDigest;
  private readonly SM2Engine.Mode mMode;
  private bool mForEncryption;
  private ECKeyParameters mECKey;
  private ECDomainParameters mECParams;
  private int mCurveLength;
  private SecureRandom mRandom;

  public SM2Engine()
    : this((IDigest) new SM3Digest())
  {
  }

  public SM2Engine(SM2Engine.Mode mode)
    : this((IDigest) new SM3Digest(), mode)
  {
  }

  public SM2Engine(IDigest digest)
    : this(digest, SM2Engine.Mode.C1C2C3)
  {
  }

  public SM2Engine(IDigest digest, SM2Engine.Mode mode)
  {
    this.mDigest = digest;
    this.mMode = mode;
  }

  public virtual void Init(bool forEncryption, ICipherParameters param)
  {
    this.mForEncryption = forEncryption;
    SecureRandom secureRandom = (SecureRandom) null;
    if (param is ParametersWithRandom parametersWithRandom)
    {
      param = parametersWithRandom.Parameters;
      secureRandom = parametersWithRandom.Random;
    }
    this.mECKey = (ECKeyParameters) param;
    this.mECParams = this.mECKey.Parameters;
    if (forEncryption)
    {
      this.mRandom = CryptoServicesRegistrar.GetSecureRandom(secureRandom);
      if (((ECPublicKeyParameters) this.mECKey).Q.Multiply(this.mECParams.H).IsInfinity)
        throw new ArgumentException("invalid key: [h]Q at infinity");
    }
    else
      this.mRandom = (SecureRandom) null;
    this.mCurveLength = (this.mECParams.Curve.FieldSize + 7) / 8;
  }

  public virtual byte[] ProcessBlock(byte[] input, int inOff, int inLen)
  {
    if (inOff + inLen > input.Length || inLen == 0)
      throw new DataLengthException("input buffer too short");
    return this.mForEncryption ? this.Encrypt(input, inOff, inLen) : this.Decrypt(input, inOff, inLen);
  }

  protected virtual ECMultiplier CreateBasePointMultiplier()
  {
    return (ECMultiplier) new FixedPointCombMultiplier();
  }

  private byte[] Encrypt(byte[] input, int inOff, int inLen)
  {
    byte[] numArray1 = new byte[inLen];
    Array.Copy((Array) input, inOff, (Array) numArray1, 0, numArray1.Length);
    ECMultiplier basePointMultiplier = this.CreateBasePointMultiplier();
    BigInteger bigInteger;
    ECPoint c1;
    do
    {
      bigInteger = this.NextK();
      c1 = ((ECPublicKeyParameters) this.mECKey).Q.Multiply(bigInteger).Normalize();
      this.Kdf(this.mDigest, c1, numArray1);
    }
    while (this.NotEncrypted(numArray1, input, inOff));
    byte[] encoded = basePointMultiplier.Multiply(this.mECParams.G, bigInteger).Normalize().GetEncoded(false);
    this.AddFieldElement(this.mDigest, c1.AffineXCoord);
    this.mDigest.BlockUpdate(input, inOff, inLen);
    this.AddFieldElement(this.mDigest, c1.AffineYCoord);
    byte[] numArray2 = DigestUtilities.DoFinal(this.mDigest);
    return this.mMode == SM2Engine.Mode.C1C3C2 ? Arrays.ConcatenateAll(encoded, numArray2, numArray1) : Arrays.ConcatenateAll(encoded, numArray1, numArray2);
  }

  private byte[] Decrypt(byte[] input, int inOff, int inLen)
  {
    byte[] numArray1 = new byte[this.mCurveLength * 2 + 1];
    Array.Copy((Array) input, inOff, (Array) numArray1, 0, numArray1.Length);
    ECPoint ecPoint = this.mECParams.Curve.DecodePoint(numArray1);
    if (ecPoint.Multiply(this.mECParams.H).IsInfinity)
      throw new InvalidCipherTextException("[h]C1 at infinity");
    ECPoint c1 = ecPoint.Multiply(((ECPrivateKeyParameters) this.mECKey).D).Normalize();
    int digestSize = this.mDigest.GetDigestSize();
    byte[] numArray2 = new byte[inLen - numArray1.Length - digestSize];
    if (this.mMode == SM2Engine.Mode.C1C3C2)
      Array.Copy((Array) input, inOff + numArray1.Length + digestSize, (Array) numArray2, 0, numArray2.Length);
    else
      Array.Copy((Array) input, inOff + numArray1.Length, (Array) numArray2, 0, numArray2.Length);
    this.Kdf(this.mDigest, c1, numArray2);
    this.AddFieldElement(this.mDigest, c1.AffineXCoord);
    this.mDigest.BlockUpdate(numArray2, 0, numArray2.Length);
    this.AddFieldElement(this.mDigest, c1.AffineYCoord);
    byte[] buf = DigestUtilities.DoFinal(this.mDigest);
    int num = 0;
    if (this.mMode == SM2Engine.Mode.C1C3C2)
    {
      for (int index = 0; index != buf.Length; ++index)
        num |= (int) buf[index] ^ (int) input[inOff + numArray1.Length + index];
    }
    else
    {
      for (int index = 0; index != buf.Length; ++index)
        num |= (int) buf[index] ^ (int) input[inOff + numArray1.Length + numArray2.Length + index];
    }
    Arrays.Fill(numArray1, (byte) 0);
    Arrays.Fill(buf, (byte) 0);
    if (num != 0)
    {
      Arrays.Fill(numArray2, (byte) 0);
      throw new InvalidCipherTextException("invalid cipher text");
    }
    return numArray2;
  }

  private bool NotEncrypted(byte[] encData, byte[] input, int inOff)
  {
    for (int index = 0; index != encData.Length; ++index)
    {
      if ((int) encData[index] != (int) input[inOff + index])
        return false;
    }
    return true;
  }

  private void Kdf(IDigest digest, ECPoint c1, byte[] encData)
  {
    int digestSize = digest.GetDigestSize();
    byte[] numArray = new byte[System.Math.Max(4, digestSize)];
    int dOff = 0;
    IMemoable memoable = digest as IMemoable;
    IMemoable other = (IMemoable) null;
    if (memoable != null)
    {
      this.AddFieldElement(digest, c1.AffineXCoord);
      this.AddFieldElement(digest, c1.AffineYCoord);
      other = memoable.Copy();
    }
    uint num = 0;
    int dRemaining;
    for (; dOff < encData.Length; dOff += dRemaining)
    {
      if (memoable != null)
      {
        memoable.Reset(other);
      }
      else
      {
        this.AddFieldElement(digest, c1.AffineXCoord);
        this.AddFieldElement(digest, c1.AffineYCoord);
      }
      dRemaining = System.Math.Min(digestSize, encData.Length - dOff);
      Pack.UInt32_To_BE(++num, numArray, 0);
      digest.BlockUpdate(numArray, 0, 4);
      digest.DoFinal(numArray, 0);
      this.Xor(encData, numArray, dOff, dRemaining);
    }
  }

  private void Xor(byte[] data, byte[] kdfOut, int dOff, int dRemaining)
  {
    for (int index = 0; index != dRemaining; ++index)
      data[dOff + index] ^= kdfOut[index];
  }

  private BigInteger NextK()
  {
    int bitLength = this.mECParams.N.BitLength;
    BigInteger bigInteger;
    do
    {
      bigInteger = new BigInteger(bitLength, (Random) this.mRandom);
    }
    while (bigInteger.SignValue == 0 || bigInteger.CompareTo(this.mECParams.N) >= 0);
    return bigInteger;
  }

  private void AddFieldElement(IDigest digest, ECFieldElement v)
  {
    byte[] encoded = v.GetEncoded();
    digest.BlockUpdate(encoded, 0, encoded.Length);
  }

  public enum Mode
  {
    C1C2C3,
    C1C3C2,
  }
}
