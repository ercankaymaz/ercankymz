// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.Polynomials.Polynomial
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru.Polynomials;

internal abstract class Polynomial
{
  internal ushort[] coeffs;
  private protected readonly NtruParameterSet ParameterSet;

  internal Polynomial(NtruParameterSet parameterSet)
  {
    this.coeffs = new ushort[parameterSet.N];
    this.ParameterSet = parameterSet;
  }

  internal static short BothNegativeMask(short x, short y) => (short) (((int) x & (int) y) >> 15);

  internal static ushort Mod3(ushort a) => Polynomial.Mod((double) a, 3.0);

  internal static byte Mod3(byte a) => (byte) Polynomial.Mod((double) a, 3.0);

  internal static uint ModQ(uint x, uint q) => (uint) Polynomial.Mod((double) x, (double) q);

  internal void Mod3PhiN()
  {
    int n = this.ParameterSet.N;
    for (int index = 0; index < n; ++index)
      this.coeffs[index] = Polynomial.Mod3((ushort) ((uint) this.coeffs[index] + 2U * (uint) this.coeffs[n - 1]));
  }

  internal void ModQPhiN()
  {
    int n = this.ParameterSet.N;
    for (int index = 0; index < n; ++index)
      this.coeffs[index] = (ushort) ((uint) this.coeffs[index] - (uint) this.coeffs[n - 1]);
  }

  internal static ushort Mod(double a, double b) => (ushort) (a - b * Math.Floor(a / b));

  public abstract byte[] SqToBytes(int len);

  public abstract void SqFromBytes(byte[] a);

  public byte[] RqSumZeroToBytes(int len) => this.SqToBytes(len);

  public void RqSumZeroFromBytes(byte[] a)
  {
    int length = this.coeffs.Length;
    this.SqFromBytes(a);
    this.coeffs[length - 1] = (ushort) 0;
    for (int index = 0; index < this.ParameterSet.PackDegree(); ++index)
      this.coeffs[length - 1] -= this.coeffs[index];
  }

  public byte[] S3ToBytes(int messageSize)
  {
    byte[] bytes = new byte[messageSize];
    for (int index = 0; index < this.ParameterSet.PackDegree() / 5; ++index)
    {
      byte num = (byte) (3 * (int) (byte) (3 * (int) (byte) (3 * (int) (byte) (3 * (int) (byte) ((uint) this.coeffs[5 * index + 4] & (uint) byte.MaxValue) + (int) this.coeffs[5 * index + 3] & (int) byte.MaxValue) + (int) this.coeffs[5 * index + 2] & (int) byte.MaxValue) + (int) this.coeffs[5 * index + 1] & (int) byte.MaxValue) + (int) this.coeffs[5 * index] & (int) byte.MaxValue);
      bytes[index] = num;
    }
    if (this.ParameterSet.PackDegree() > this.ParameterSet.PackDegree() / 5 * 5)
    {
      int index1 = this.ParameterSet.PackDegree() / 5;
      byte num = 0;
      for (int index2 = this.ParameterSet.PackDegree() - 5 * index1 - 1; index2 >= 0; --index2)
        num = (byte) (3 * (int) num + (int) this.coeffs[5 * index1 + index2] & (int) byte.MaxValue);
      bytes[index1] = num;
    }
    return bytes;
  }

  public void S3FromBytes(byte[] msg)
  {
    int length = this.coeffs.Length;
    for (int index = 0; index < this.ParameterSet.PackDegree() / 5; ++index)
    {
      byte num = msg[index];
      this.coeffs[5 * index] = (ushort) num;
      this.coeffs[5 * index + 1] = (ushort) ((int) num * 171 >> 9);
      this.coeffs[5 * index + 2] = (ushort) ((int) num * 57 >> 9);
      this.coeffs[5 * index + 3] = (ushort) ((int) num * 19 >> 9);
      this.coeffs[5 * index + 4] = (ushort) ((int) num * 203 >> 14);
    }
    if (this.ParameterSet.PackDegree() > this.ParameterSet.PackDegree() / 5 * 5)
    {
      int index1 = this.ParameterSet.PackDegree() / 5;
      byte num = msg[index1];
      for (int index2 = 0; 5 * index1 + index2 < this.ParameterSet.PackDegree(); ++index2)
      {
        this.coeffs[5 * index1 + index2] = (ushort) num;
        num = (byte) ((int) num * 171 >> 9);
      }
    }
    this.coeffs[length - 1] = (ushort) 0;
    this.Mod3PhiN();
  }

  public void RqMul(Polynomial a, Polynomial b)
  {
    int length = this.coeffs.Length;
    for (int index1 = 0; index1 < length; ++index1)
    {
      this.coeffs[index1] = (ushort) 0;
      for (int index2 = 1; index2 < length - index1; ++index2)
        this.coeffs[index1] += (ushort) ((uint) a.coeffs[index1 + index2] * (uint) b.coeffs[length - index2]);
      for (int index3 = 0; index3 < index1 + 1; ++index3)
        this.coeffs[index1] += (ushort) ((uint) a.coeffs[index1 - index3] * (uint) b.coeffs[index3]);
    }
  }

  public void SqMul(Polynomial a, Polynomial b)
  {
    this.RqMul(a, b);
    this.ModQPhiN();
  }

  public void S3Mul(Polynomial a, Polynomial b)
  {
    this.RqMul(a, b);
    this.Mod3PhiN();
  }

  public abstract void Lift(Polynomial a);

  public void RqToS3(Polynomial a)
  {
    int length = this.coeffs.Length;
    for (int index = 0; index < length; ++index)
    {
      this.coeffs[index] = (ushort) Polynomial.ModQ((uint) a.coeffs[index], (uint) this.ParameterSet.Q());
      ushort num = (ushort) ((uint) this.coeffs[index] >> this.ParameterSet.LogQ - 1);
      this.coeffs[index] += (ushort) ((uint) num << 1 - (this.ParameterSet.LogQ & 1));
    }
    this.Mod3PhiN();
  }

  public abstract void R2Inv(Polynomial a);

  internal void R2Inv(Polynomial a, Polynomial f, Polynomial g, Polynomial v, Polynomial w)
  {
    int length = this.coeffs.Length;
    w.coeffs[0] = (ushort) 1;
    for (int index = 0; index < length; ++index)
      f.coeffs[index] = (ushort) 1;
    for (int index = 0; index < length - 1; ++index)
      g.coeffs[length - 2 - index] = (ushort) (((int) a.coeffs[index] ^ (int) a.coeffs[length - 1]) & 1);
    g.coeffs[length - 1] = (ushort) 0;
    short num1 = 1;
    for (int index1 = 0; index1 < 2 * (length - 1) - 1; ++index1)
    {
      for (int index2 = length - 1; index2 > 0; --index2)
        v.coeffs[index2] = v.coeffs[index2 - 1];
      v.coeffs[0] = (ushort) 0;
      short num2 = (short) ((int) g.coeffs[0] & (int) f.coeffs[0]);
      short num3 = Polynomial.BothNegativeMask(-num1, (short) -g.coeffs[0]);
      num1 = (short) ((int) (short) ((int) num1 ^ (int) (short) ((int) num3 & ((int) num1 ^ (int) -num1))) + 1);
      for (int index3 = 0; index3 < length; ++index3)
      {
        short num4 = (short) ((int) num3 & ((int) f.coeffs[index3] ^ (int) g.coeffs[index3]));
        f.coeffs[index3] ^= (ushort) num4;
        g.coeffs[index3] ^= (ushort) num4;
        short num5 = (short) ((int) num3 & ((int) v.coeffs[index3] ^ (int) w.coeffs[index3]));
        v.coeffs[index3] ^= (ushort) num5;
        w.coeffs[index3] ^= (ushort) num5;
      }
      for (int index4 = 0; index4 < length; ++index4)
        g.coeffs[index4] = (ushort) ((uint) g.coeffs[index4] ^ (uint) num2 & (uint) f.coeffs[index4]);
      for (int index5 = 0; index5 < length; ++index5)
        w.coeffs[index5] = (ushort) ((uint) w.coeffs[index5] ^ (uint) num2 & (uint) v.coeffs[index5]);
      for (int index6 = 0; index6 < length - 1; ++index6)
        g.coeffs[index6] = g.coeffs[index6 + 1];
      g.coeffs[length - 1] = (ushort) 0;
    }
    for (int index = 0; index < length - 1; ++index)
      this.coeffs[index] = v.coeffs[length - 2 - index];
    this.coeffs[length - 1] = (ushort) 0;
  }

  public abstract void RqInv(Polynomial a);

  internal void RqInv(Polynomial a, Polynomial ai2, Polynomial b, Polynomial c, Polynomial s)
  {
    ai2.R2Inv(a);
    this.R2InvToRqInv(ai2, a, b, c, s);
  }

  private void R2InvToRqInv(
    Polynomial ai,
    Polynomial a,
    Polynomial b,
    Polynomial c,
    Polynomial s)
  {
    int length = this.coeffs.Length;
    for (int index = 0; index < length; ++index)
      b.coeffs[index] = -a.coeffs[index];
    for (int index = 0; index < length; ++index)
      this.coeffs[index] = ai.coeffs[index];
    c.RqMul(this, b);
    c.coeffs[0] += (ushort) 2;
    s.RqMul(c, this);
    c.RqMul(s, b);
    c.coeffs[0] += (ushort) 2;
    this.RqMul(c, s);
    c.RqMul(this, b);
    c.coeffs[0] += (ushort) 2;
    s.RqMul(c, this);
    c.RqMul(s, b);
    c.coeffs[0] += (ushort) 2;
    this.RqMul(c, s);
  }

  public abstract void S3Inv(Polynomial a);

  internal void S3Inv(Polynomial a, Polynomial f, Polynomial g, Polynomial v, Polynomial w)
  {
    int length = this.coeffs.Length;
    w.coeffs[0] = (ushort) 1;
    for (int index = 0; index < length; ++index)
      f.coeffs[index] = (ushort) 1;
    for (int index = 0; index < length - 1; ++index)
      g.coeffs[length - 2 - index] = Polynomial.Mod3((ushort) (((int) a.coeffs[index] & 3) + 2 * ((int) a.coeffs[length - 1] & 3)));
    g.coeffs[length - 1] = (ushort) 0;
    short num1 = 1;
    for (int index1 = 0; index1 < 2 * (length - 1) - 1; ++index1)
    {
      for (int index2 = length - 1; index2 > 0; --index2)
        v.coeffs[index2] = v.coeffs[index2 - 1];
      v.coeffs[0] = (ushort) 0;
      short num2 = (short) Polynomial.Mod3((byte) (2U * (uint) g.coeffs[0] * (uint) f.coeffs[0]));
      short num3 = Polynomial.BothNegativeMask(-num1, (short) -g.coeffs[0]);
      num1 = (short) ((int) (short) ((int) num1 ^ (int) (short) ((int) num3 & ((int) num1 ^ (int) -num1))) + 1);
      for (int index3 = 0; index3 < length; ++index3)
      {
        short num4 = (short) ((int) num3 & ((int) f.coeffs[index3] ^ (int) g.coeffs[index3]));
        f.coeffs[index3] ^= (ushort) num4;
        g.coeffs[index3] ^= (ushort) num4;
        short num5 = (short) ((int) num3 & ((int) v.coeffs[index3] ^ (int) w.coeffs[index3]));
        v.coeffs[index3] ^= (ushort) num5;
        w.coeffs[index3] ^= (ushort) num5;
      }
      for (int index4 = 0; index4 < length; ++index4)
        g.coeffs[index4] = (ushort) Polynomial.Mod3((byte) ((uint) g.coeffs[index4] + (uint) num2 * (uint) f.coeffs[index4]));
      for (int index5 = 0; index5 < length; ++index5)
        w.coeffs[index5] = (ushort) Polynomial.Mod3((byte) ((uint) w.coeffs[index5] + (uint) num2 * (uint) v.coeffs[index5]));
      for (int index6 = 0; index6 < length - 1; ++index6)
        g.coeffs[index6] = g.coeffs[index6 + 1];
      g.coeffs[length - 1] = (ushort) 0;
    }
    short coeff = (short) f.coeffs[0];
    for (int index = 0; index < length - 1; ++index)
      this.coeffs[index] = (ushort) Polynomial.Mod3((byte) ((uint) coeff * (uint) v.coeffs[length - 2 - index]));
    this.coeffs[length - 1] = (ushort) 0;
  }

  public void Z3ToZq()
  {
    int length = this.coeffs.Length;
    for (int index = 0; index < length; ++index)
      this.coeffs[index] = (ushort) ((uint) this.coeffs[index] | (uint) (-((int) this.coeffs[index] >> 1) & this.ParameterSet.Q() - 1));
  }

  public void TrinaryZqToZ3()
  {
    int length = this.coeffs.Length;
    for (int index = 0; index < length; ++index)
    {
      this.coeffs[index] = (ushort) Polynomial.ModQ((uint) this.coeffs[index] & (uint) ushort.MaxValue, (uint) this.ParameterSet.Q());
      this.coeffs[index] = (ushort) (3 & ((int) this.coeffs[index] ^ (int) this.coeffs[index] >> this.ParameterSet.LogQ - 1));
    }
  }
}
