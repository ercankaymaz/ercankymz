// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.SM2KeyExchange
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement;

public class SM2KeyExchange
{
  private readonly IDigest mDigest;
  private byte[] mUserID;
  private ECPrivateKeyParameters mStaticKey;
  private ECPoint mStaticPubPoint;
  private ECPoint mEphemeralPubPoint;
  private ECDomainParameters mECParams;
  private int mW;
  private ECPrivateKeyParameters mEphemeralKey;
  private bool mInitiator;

  public SM2KeyExchange()
    : this((IDigest) new SM3Digest())
  {
  }

  public SM2KeyExchange(IDigest digest) => this.mDigest = digest;

  public virtual void Init(ICipherParameters privParam)
  {
    SM2KeyExchangePrivateParameters privateParameters;
    if (privParam is ParametersWithID)
    {
      privateParameters = (SM2KeyExchangePrivateParameters) ((ParametersWithID) privParam).Parameters;
      this.mUserID = ((ParametersWithID) privParam).GetID();
    }
    else
    {
      privateParameters = (SM2KeyExchangePrivateParameters) privParam;
      this.mUserID = new byte[0];
    }
    this.mInitiator = privateParameters.IsInitiator;
    this.mStaticKey = privateParameters.StaticPrivateKey;
    this.mEphemeralKey = privateParameters.EphemeralPrivateKey;
    this.mECParams = this.mStaticKey.Parameters;
    this.mStaticPubPoint = privateParameters.StaticPublicPoint;
    this.mEphemeralPubPoint = privateParameters.EphemeralPublicPoint;
    this.mW = this.mECParams.Curve.FieldSize / 2 - 1;
  }

  public virtual byte[] CalculateKey(int kLen, ICipherParameters pubParam)
  {
    SM2KeyExchangePublicParameters otherPub;
    byte[] userID;
    if (pubParam is ParametersWithID)
    {
      otherPub = (SM2KeyExchangePublicParameters) ((ParametersWithID) pubParam).Parameters;
      userID = ((ParametersWithID) pubParam).GetID();
    }
    else
    {
      otherPub = (SM2KeyExchangePublicParameters) pubParam;
      userID = new byte[0];
    }
    byte[] z1 = this.GetZ(this.mDigest, this.mUserID, this.mStaticPubPoint);
    byte[] z2 = this.GetZ(this.mDigest, userID, otherPub.StaticPublicKey.Q);
    ECPoint u = this.CalculateU(otherPub);
    return !this.mInitiator ? this.Kdf(u, z2, z1, kLen) : this.Kdf(u, z1, z2, kLen);
  }

  public virtual byte[][] CalculateKeyWithConfirmation(
    int kLen,
    byte[] confirmationTag,
    ICipherParameters pubParam)
  {
    SM2KeyExchangePublicParameters otherPub;
    byte[] userID;
    if (pubParam is ParametersWithID)
    {
      otherPub = (SM2KeyExchangePublicParameters) ((ParametersWithID) pubParam).Parameters;
      userID = ((ParametersWithID) pubParam).GetID();
    }
    else
    {
      otherPub = (SM2KeyExchangePublicParameters) pubParam;
      userID = new byte[0];
    }
    if (this.mInitiator && confirmationTag == null)
      throw new ArgumentException("if initiating, confirmationTag must be set");
    byte[] z1 = this.GetZ(this.mDigest, this.mUserID, this.mStaticPubPoint);
    byte[] z2 = this.GetZ(this.mDigest, userID, otherPub.StaticPublicKey.Q);
    ECPoint u = this.CalculateU(otherPub);
    if (this.mInitiator)
    {
      byte[] numArray = this.Kdf(u, z1, z2, kLen);
      byte[] innerHash = this.CalculateInnerHash(this.mDigest, u, z1, z2, this.mEphemeralPubPoint, otherPub.EphemeralPublicKey.Q);
      if (!Arrays.FixedTimeEquals(this.S1(this.mDigest, u, innerHash), confirmationTag))
        throw new InvalidOperationException("confirmation tag mismatch");
      return new byte[2][]
      {
        numArray,
        this.S2(this.mDigest, u, innerHash)
      };
    }
    byte[] numArray1 = this.Kdf(u, z2, z1, kLen);
    byte[] innerHash1 = this.CalculateInnerHash(this.mDigest, u, z2, z1, otherPub.EphemeralPublicKey.Q, this.mEphemeralPubPoint);
    return new byte[3][]
    {
      numArray1,
      this.S1(this.mDigest, u, innerHash1),
      this.S2(this.mDigest, u, innerHash1)
    };
  }

  protected virtual ECPoint CalculateU(SM2KeyExchangePublicParameters otherPub)
  {
    ECDomainParameters parameters = this.mStaticKey.Parameters;
    ECPoint P = ECAlgorithms.CleanPoint(parameters.Curve, otherPub.StaticPublicKey.Q);
    ECPoint Q = ECAlgorithms.CleanPoint(parameters.Curve, otherPub.EphemeralPublicKey.Q);
    BigInteger bigInteger = this.Reduce(this.mEphemeralPubPoint.AffineXCoord.ToBigInteger());
    BigInteger val = this.Reduce(Q.AffineXCoord.ToBigInteger());
    BigInteger a = this.mECParams.H.Multiply(this.mStaticKey.D.Add(bigInteger.Multiply(this.mEphemeralKey.D))).Mod(this.mECParams.N);
    BigInteger b = a.Multiply(val).Mod(this.mECParams.N);
    return ECAlgorithms.SumOfTwoMultiplies(P, a, Q, b).Normalize();
  }

  protected virtual byte[] Kdf(ECPoint u, byte[] za, byte[] zb, int klen)
  {
    int digestSize = this.mDigest.GetDigestSize();
    byte[] numArray = new byte[System.Math.Max(4, digestSize)];
    byte[] destinationArray = new byte[(klen + 7) / 8];
    int destinationIndex = 0;
    IMemoable mDigest = this.mDigest as IMemoable;
    IMemoable other = (IMemoable) null;
    if (mDigest != null)
    {
      this.AddFieldElement(this.mDigest, u.AffineXCoord);
      this.AddFieldElement(this.mDigest, u.AffineYCoord);
      this.mDigest.BlockUpdate(za, 0, za.Length);
      this.mDigest.BlockUpdate(zb, 0, zb.Length);
      other = mDigest.Copy();
    }
    uint num = 0;
    int length;
    for (; destinationIndex < destinationArray.Length; destinationIndex += length)
    {
      if (mDigest != null)
      {
        mDigest.Reset(other);
      }
      else
      {
        this.AddFieldElement(this.mDigest, u.AffineXCoord);
        this.AddFieldElement(this.mDigest, u.AffineYCoord);
        this.mDigest.BlockUpdate(za, 0, za.Length);
        this.mDigest.BlockUpdate(zb, 0, zb.Length);
      }
      Pack.UInt32_To_BE(++num, numArray, 0);
      this.mDigest.BlockUpdate(numArray, 0, 4);
      this.mDigest.DoFinal(numArray, 0);
      length = System.Math.Min(digestSize, destinationArray.Length - destinationIndex);
      Array.Copy((Array) numArray, 0, (Array) destinationArray, destinationIndex, length);
    }
    return destinationArray;
  }

  private BigInteger Reduce(BigInteger x)
  {
    return x.And(BigInteger.One.ShiftLeft(this.mW).Subtract(BigInteger.One)).SetBit(this.mW);
  }

  private byte[] S1(IDigest digest, ECPoint u, byte[] inner)
  {
    digest.Update((byte) 2);
    this.AddFieldElement(digest, u.AffineYCoord);
    digest.BlockUpdate(inner, 0, inner.Length);
    return DigestUtilities.DoFinal(digest);
  }

  private byte[] CalculateInnerHash(
    IDigest digest,
    ECPoint u,
    byte[] za,
    byte[] zb,
    ECPoint p1,
    ECPoint p2)
  {
    this.AddFieldElement(digest, u.AffineXCoord);
    digest.BlockUpdate(za, 0, za.Length);
    digest.BlockUpdate(zb, 0, zb.Length);
    this.AddFieldElement(digest, p1.AffineXCoord);
    this.AddFieldElement(digest, p1.AffineYCoord);
    this.AddFieldElement(digest, p2.AffineXCoord);
    this.AddFieldElement(digest, p2.AffineYCoord);
    return DigestUtilities.DoFinal(digest);
  }

  private byte[] S2(IDigest digest, ECPoint u, byte[] inner)
  {
    digest.Update((byte) 3);
    this.AddFieldElement(digest, u.AffineYCoord);
    digest.BlockUpdate(inner, 0, inner.Length);
    return DigestUtilities.DoFinal(digest);
  }

  private byte[] GetZ(IDigest digest, byte[] userID, ECPoint pubPoint)
  {
    this.AddUserID(digest, userID);
    this.AddFieldElement(digest, this.mECParams.Curve.A);
    this.AddFieldElement(digest, this.mECParams.Curve.B);
    this.AddFieldElement(digest, this.mECParams.G.AffineXCoord);
    this.AddFieldElement(digest, this.mECParams.G.AffineYCoord);
    this.AddFieldElement(digest, pubPoint.AffineXCoord);
    this.AddFieldElement(digest, pubPoint.AffineYCoord);
    return DigestUtilities.DoFinal(digest);
  }

  private void AddUserID(IDigest digest, byte[] userID)
  {
    uint input = (uint) (userID.Length * 8);
    digest.Update((byte) (input >> 8));
    digest.Update((byte) input);
    digest.BlockUpdate(userID, 0, userID.Length);
  }

  private void AddFieldElement(IDigest digest, ECFieldElement v)
  {
    byte[] encoded = v.GetEncoded();
    digest.BlockUpdate(encoded, 0, encoded.Length);
  }
}
