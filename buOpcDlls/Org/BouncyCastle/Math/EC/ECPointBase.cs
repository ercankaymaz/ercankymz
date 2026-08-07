// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Math.EC.ECPointBase
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Math.EC;

public abstract class ECPointBase : ECPoint
{
  protected internal ECPointBase(ECCurve curve, ECFieldElement x, ECFieldElement y)
    : base(curve, x, y)
  {
  }

  protected internal ECPointBase(
    ECCurve curve,
    ECFieldElement x,
    ECFieldElement y,
    ECFieldElement[] zs)
    : base(curve, x, y, zs)
  {
  }

  public override byte[] GetEncoded(bool compressed)
  {
    if (this.IsInfinity)
      return new byte[1];
    ECPoint ecPoint = this.Normalize();
    byte[] encoded1 = ecPoint.XCoord.GetEncoded();
    if (compressed)
    {
      byte[] destinationArray = new byte[encoded1.Length + 1];
      destinationArray[0] = ecPoint.CompressionYTilde ? (byte) 3 : (byte) 2;
      Array.Copy((Array) encoded1, 0, (Array) destinationArray, 1, encoded1.Length);
      return destinationArray;
    }
    byte[] encoded2 = ecPoint.YCoord.GetEncoded();
    byte[] destinationArray1 = new byte[encoded1.Length + encoded2.Length + 1];
    destinationArray1[0] = (byte) 4;
    Array.Copy((Array) encoded1, 0, (Array) destinationArray1, 1, encoded1.Length);
    Array.Copy((Array) encoded2, 0, (Array) destinationArray1, encoded1.Length + 1, encoded2.Length);
    return destinationArray1;
  }

  public override int GetEncodedLength(bool compressed)
  {
    if (this.IsInfinity)
      return 1;
    return compressed ? 1 + this.XCoord.GetEncodedLength() : 1 + this.XCoord.GetEncodedLength() + this.YCoord.GetEncodedLength();
  }

  public override void EncodeTo(bool compressed, byte[] buf, int off)
  {
    if (this.IsInfinity)
    {
      buf[off] = (byte) 0;
    }
    else
    {
      ECPoint ecPoint = this.Normalize();
      ECFieldElement xcoord = ecPoint.XCoord;
      ECFieldElement ycoord = ecPoint.YCoord;
      if (compressed)
      {
        buf[off] = ecPoint.CompressionYTilde ? (byte) 3 : (byte) 2;
        xcoord.EncodeTo(buf, off + 1);
      }
      else
      {
        buf[off] = (byte) 4;
        xcoord.EncodeTo(buf, off + 1);
        ycoord.EncodeTo(buf, off + 1 + xcoord.GetEncodedLength());
      }
    }
  }

  public override ECPoint Multiply(BigInteger k)
  {
    return this.Curve.GetMultiplier().Multiply((ECPoint) this, k);
  }
}
