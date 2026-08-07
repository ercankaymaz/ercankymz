// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Frodo.FrodoEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Frodo;

public class FrodoEngine
{
  internal static int nbar = 8;
  private static int mbar = 8;
  private static int len_seedA = 128 /*0x80*/;
  private static int len_z = 128 /*0x80*/;
  private static int len_chi = 16 /*0x10*/;
  private static int len_seedA_bytes = FrodoEngine.len_seedA / 8;
  private static int len_z_bytes = FrodoEngine.len_z / 8;
  private static int len_chi_bytes = FrodoEngine.len_chi / 8;
  private int D;
  private int q;
  private int n;
  private int B;
  private int len_sk_bytes;
  private int len_pk_bytes;
  private int len_ct_bytes;
  private short[] T_chi;
  private int len_mu;
  private int len_seedSE;
  private int len_s;
  private int len_k;
  private int len_pkh;
  private int len_ss;
  private int len_mu_bytes;
  private int len_seedSE_bytes;
  private int len_s_bytes;
  private int len_k_bytes;
  private int len_pkh_bytes;
  private int len_ss_bytes;
  private IDigest digest;
  private FrodoMatrixGenerator gen;

  public int CipherTextSize => this.len_ct_bytes;

  public int SessionKeySize => this.len_ss_bytes;

  public int PrivateKeySize => this.len_sk_bytes;

  public int PublicKeySize => this.len_pk_bytes;

  public FrodoEngine(
    int n,
    int D,
    int B,
    short[] cdf_table,
    IDigest digest,
    FrodoMatrixGenerator mGen)
  {
    this.n = n;
    this.D = D;
    this.q = 1 << D;
    this.B = B;
    this.len_mu = B * FrodoEngine.nbar * FrodoEngine.nbar;
    this.len_seedSE = this.len_mu;
    this.len_s = this.len_mu;
    this.len_k = this.len_mu;
    this.len_pkh = this.len_mu;
    this.len_ss = this.len_mu;
    this.len_mu_bytes = this.len_mu / 8;
    this.len_seedSE_bytes = this.len_seedSE / 8;
    this.len_s_bytes = this.len_s / 8;
    this.len_k_bytes = this.len_k / 8;
    this.len_pkh_bytes = this.len_pkh / 8;
    this.len_ss_bytes = this.len_ss / 8;
    this.len_ct_bytes = D * n * FrodoEngine.nbar / 8 + D * FrodoEngine.nbar * FrodoEngine.nbar / 8;
    this.len_pk_bytes = FrodoEngine.len_seedA_bytes + D * n * FrodoEngine.nbar / 8;
    this.len_sk_bytes = this.len_s_bytes + this.len_pk_bytes + (2 * n * FrodoEngine.nbar + this.len_pkh_bytes);
    this.T_chi = cdf_table;
    this.digest = digest;
    this.gen = mGen;
  }

  private short Sample(short r)
  {
    short num1 = (short) (((int) r & (int) ushort.MaxValue) >> 1);
    short num2 = 0;
    for (int index = 0; index < this.T_chi.Length; ++index)
    {
      if ((int) num1 > (int) this.T_chi[index])
        ++num2;
    }
    if (((int) r & (int) ushort.MaxValue) % 2 == 1)
      num2 = (short) ((int) num2 * -1 & (int) ushort.MaxValue);
    return num2;
  }

  private short[] SampleMatrix(short[] r, int offset, int n1, int n2)
  {
    short[] numArray = new short[n1 * n2];
    for (int index1 = 0; index1 < n1; ++index1)
    {
      for (int index2 = 0; index2 < n2; ++index2)
        numArray[index1 * n2 + index2] = this.Sample(r[index1 * n2 + index2 + offset]);
    }
    return numArray;
  }

  private short[] MatrixTranspose(short[] X, int n1, int n2)
  {
    short[] numArray = new short[n1 * n2];
    for (int index1 = 0; index1 < n2; ++index1)
    {
      for (int index2 = 0; index2 < n1; ++index2)
        numArray[index1 * n1 + index2] = X[index2 * n2 + index1];
    }
    return numArray;
  }

  private short[] MatrixMul(short[] X, int Xrow, int Xcol, short[] Y, int Ycol)
  {
    int num1 = this.q - 1;
    short[] numArray = new short[Xrow * Ycol];
    for (int index1 = 0; index1 < Xrow; ++index1)
    {
      for (int index2 = 0; index2 < Ycol; ++index2)
      {
        int num2 = 0;
        for (int index3 = 0; index3 < Xcol; ++index3)
          num2 += (int) X[index1 * Xcol + index3] * (int) Y[index3 * Ycol + index2];
        numArray[index1 * Ycol + index2] = (short) (num2 & num1);
      }
    }
    return numArray;
  }

  private short[] MatrixAdd(short[] X, short[] Y, int n1, int m1)
  {
    int num = this.q - 1;
    short[] numArray = new short[n1 * m1];
    for (int index1 = 0; index1 < n1; ++index1)
    {
      for (int index2 = 0; index2 < m1; ++index2)
        numArray[index1 * m1 + index2] = (short) ((int) X[index1 * m1 + index2] + (int) Y[index1 * m1 + index2] & num);
    }
    return numArray;
  }

  private byte[] FrodoPack(short[] C)
  {
    int length = C.Length;
    byte[] numArray = new byte[this.D * length / 8];
    short index1 = 0;
    short index2 = 0;
    short num1 = 0;
    byte val2 = 0;
    while ((int) index1 < numArray.Length && ((int) index2 < length || (int) index2 == length && val2 > (byte) 0))
    {
      byte num2 = 0;
      while (num2 < (byte) 8)
      {
        int num3 = Math.Min(8 - (int) num2, (int) val2);
        short num4 = (short) ((1 << num3) - 1);
        byte num5 = (byte) ((uint) num1 >> (int) val2 - num3 & (uint) num4);
        numArray[(int) index1] = (byte) ((uint) numArray[(int) index1] + ((uint) num5 << 8 - (int) num2 - num3));
        num2 += (byte) num3;
        val2 -= (byte) num3;
        if (val2 == (byte) 0)
        {
          if ((int) index2 < length)
          {
            num1 = C[(int) index2];
            val2 = (byte) this.D;
            ++index2;
          }
          else
            break;
        }
      }
      if (num2 == (byte) 8)
        ++index1;
    }
    return numArray;
  }

  public void kem_keypair(byte[] pk, byte[] sk, SecureRandom random)
  {
    byte[] numArray1 = new byte[this.len_s_bytes + this.len_seedSE_bytes + FrodoEngine.len_z_bytes];
    random.NextBytes(numArray1);
    byte[] a = Arrays.CopyOfRange(numArray1, 0, this.len_s_bytes);
    byte[] input1 = Arrays.CopyOfRange(numArray1, this.len_s_bytes, this.len_s_bytes + this.len_seedSE_bytes);
    byte[] input2 = Arrays.CopyOfRange(numArray1, this.len_s_bytes + this.len_seedSE_bytes, this.len_s_bytes + this.len_seedSE_bytes + FrodoEngine.len_z_bytes);
    byte[] numArray2 = new byte[FrodoEngine.len_seedA_bytes];
    this.digest.BlockUpdate(input2, 0, input2.Length);
    ((IXof) this.digest).OutputFinal(numArray2, 0, numArray2.Length);
    short[] X1 = this.gen.GenMatrix(numArray2);
    byte[] numArray3 = new byte[2 * this.n * FrodoEngine.nbar * FrodoEngine.len_chi_bytes];
    this.digest.Update((byte) 95);
    this.digest.BlockUpdate(input1, 0, input1.Length);
    ((IXof) this.digest).OutputFinal(numArray3, 0, numArray3.Length);
    short[] r = new short[2 * this.n * FrodoEngine.nbar];
    for (int index = 0; index < r.Length; ++index)
      r[index] = (short) Pack.LE_To_UInt16(numArray3, index * 2);
    short[] X2 = this.SampleMatrix(r, 0, FrodoEngine.nbar, this.n);
    short[] Y1 = this.MatrixTranspose(X2, FrodoEngine.nbar, this.n);
    short[] Y2 = this.SampleMatrix(r, this.n * FrodoEngine.nbar, this.n, FrodoEngine.nbar);
    byte[] b = this.FrodoPack(this.MatrixAdd(this.MatrixMul(X1, this.n, this.n, Y1, FrodoEngine.nbar), Y2, this.n, FrodoEngine.nbar));
    Array.Copy((Array) Arrays.Concatenate(numArray2, b), 0, (Array) pk, 0, this.len_pk_bytes);
    byte[] numArray4 = new byte[this.len_pkh_bytes];
    this.digest.BlockUpdate(pk, 0, pk.Length);
    ((IXof) this.digest).OutputFinal(numArray4, 0, numArray4.Length);
    Array.Copy((Array) Arrays.Concatenate(a, pk), 0, (Array) sk, 0, this.len_s_bytes + this.len_pk_bytes);
    byte[] numArray5 = new byte[4];
    for (int index1 = 0; index1 < FrodoEngine.nbar; ++index1)
    {
      for (int index2 = 0; index2 < this.n; ++index2)
      {
        Pack.UInt16_To_LE((ushort) X2[index1 * this.n + index2], numArray5);
        Array.Copy((Array) numArray5, 0, (Array) sk, this.len_s_bytes + this.len_pk_bytes + index1 * this.n * 2 + index2 * 2, 2);
      }
    }
    Array.Copy((Array) numArray4, 0, (Array) sk, this.len_sk_bytes - this.len_pkh_bytes, this.len_pkh_bytes);
  }

  private short[] FrodoUnpack(byte[] input, int n1, int n2)
  {
    short[] numArray = new short[n1 * n2];
    short index1 = 0;
    short index2 = 0;
    byte num1 = 0;
    byte val2 = 0;
    while ((int) index1 < numArray.Length && ((int) index2 < input.Length || (int) index2 == input.Length && val2 > (byte) 0))
    {
      byte num2 = 0;
      while ((int) num2 < this.D)
      {
        int num3 = Math.Min(this.D - (int) num2, (int) val2);
        short num4 = (short) ((1 << num3) - 1 & (int) ushort.MaxValue);
        byte num5 = (byte) (((int) num1 & (int) byte.MaxValue) >> ((int) val2 & (int) byte.MaxValue) - num3 & (int) num4 & (int) ushort.MaxValue & (int) byte.MaxValue);
        numArray[(int) index1] = (short) (((int) numArray[(int) index1] & (int) ushort.MaxValue) + (((int) num5 & (int) byte.MaxValue) << this.D - ((int) num2 & (int) byte.MaxValue) - num3) & (int) ushort.MaxValue);
        num2 += (byte) num3;
        val2 -= (byte) num3;
        num1 &= (byte) ~((int) num4 << (int) val2);
        if (val2 == (byte) 0)
        {
          if ((int) index2 < input.Length)
          {
            num1 = input[(int) index2];
            val2 = (byte) 8;
            ++index2;
          }
          else
            break;
        }
      }
      if ((int) num2 == this.D)
        ++index1;
    }
    return numArray;
  }

  private short[] Encode(byte[] k)
  {
    int index1 = 0;
    byte num1 = 1;
    short[] numArray = new short[FrodoEngine.mbar * FrodoEngine.nbar];
    for (int index2 = 0; index2 < FrodoEngine.mbar; ++index2)
    {
      for (int index3 = 0; index3 < FrodoEngine.nbar; ++index3)
      {
        int num2 = 0;
        for (int index4 = 0; index4 < this.B; ++index4)
        {
          if (((int) k[index1] & (int) num1) == (int) num1)
            num2 += 1 << index4;
          num1 <<= 1;
          if (num1 == (byte) 0)
          {
            num1 = (byte) 1;
            ++index1;
          }
        }
        numArray[index2 * FrodoEngine.nbar + index3] = (short) (num2 * (this.q / (1 << this.B)));
      }
    }
    return numArray;
  }

  public void kem_enc(byte[] ct, byte[] ss, byte[] pk, SecureRandom random)
  {
    byte[] seedA = Arrays.CopyOfRange(pk, 0, FrodoEngine.len_seedA_bytes);
    byte[] input1 = Arrays.CopyOfRange(pk, FrodoEngine.len_seedA_bytes, this.len_pk_bytes);
    byte[] numArray1 = new byte[this.len_mu_bytes];
    random.NextBytes(numArray1);
    byte[] numArray2 = new byte[this.len_pkh_bytes];
    this.digest.BlockUpdate(pk, 0, this.len_pk_bytes);
    ((IXof) this.digest).OutputFinal(numArray2, 0, this.len_pkh_bytes);
    byte[] numArray3 = new byte[this.len_seedSE + this.len_k];
    this.digest.BlockUpdate(numArray2, 0, this.len_pkh_bytes);
    this.digest.BlockUpdate(numArray1, 0, this.len_mu_bytes);
    ((IXof) this.digest).OutputFinal(numArray3, 0, this.len_seedSE_bytes + this.len_k_bytes);
    byte[] input2 = Arrays.CopyOfRange(numArray3, 0, this.len_seedSE_bytes);
    byte[] input3 = Arrays.CopyOfRange(numArray3, this.len_seedSE_bytes, this.len_seedSE_bytes + this.len_k_bytes);
    byte[] numArray4 = new byte[(2 * FrodoEngine.mbar * this.n + FrodoEngine.mbar * FrodoEngine.nbar) * FrodoEngine.len_chi_bytes];
    this.digest.Update((byte) 150);
    this.digest.BlockUpdate(input2, 0, input2.Length);
    ((IXof) this.digest).OutputFinal(numArray4, 0, numArray4.Length);
    short[] r = new short[numArray4.Length / 2];
    for (int index = 0; index < r.Length; ++index)
      r[index] = (short) Pack.LE_To_UInt16(numArray4, index * 2);
    short[] X = this.SampleMatrix(r, 0, FrodoEngine.mbar, this.n);
    short[] Y1 = this.SampleMatrix(r, FrodoEngine.mbar * this.n, FrodoEngine.mbar, this.n);
    short[] Y2 = this.gen.GenMatrix(seedA);
    byte[] numArray5 = this.FrodoPack(this.MatrixAdd(this.MatrixMul(X, FrodoEngine.mbar, this.n, Y2, this.n), Y1, FrodoEngine.mbar, this.n));
    short[] Y3 = this.SampleMatrix(r, 2 * FrodoEngine.mbar * this.n, FrodoEngine.mbar, FrodoEngine.nbar);
    short[] Y4 = this.FrodoUnpack(input1, this.n, FrodoEngine.nbar);
    byte[] numArray6 = this.FrodoPack(this.MatrixAdd(this.MatrixAdd(this.MatrixMul(X, FrodoEngine.mbar, this.n, Y4, FrodoEngine.nbar), Y3, FrodoEngine.mbar, FrodoEngine.nbar), this.Encode(numArray1), FrodoEngine.nbar, FrodoEngine.mbar));
    Array.Copy((Array) Arrays.Concatenate(numArray5, numArray6), 0, (Array) ct, 0, this.len_ct_bytes);
    this.digest.BlockUpdate(numArray5, 0, numArray5.Length);
    this.digest.BlockUpdate(numArray6, 0, numArray6.Length);
    this.digest.BlockUpdate(input3, 0, this.len_k_bytes);
    ((IXof) this.digest).OutputFinal(ss, 0, this.len_s_bytes);
  }

  private short[] MatrixSub(short[] X, short[] Y, int n1, int n2)
  {
    int num = this.q - 1;
    short[] numArray = new short[n1 * n2];
    for (int index1 = 0; index1 < n1; ++index1)
    {
      for (int index2 = 0; index2 < n2; ++index2)
        numArray[index1 * n2 + index2] = (short) ((int) X[index1 * n2 + index2] - (int) Y[index1 * n2 + index2] & num);
    }
    return numArray;
  }

  private byte[] Decode(short[] input)
  {
    int index1 = 0;
    int num1 = 8;
    int num2 = FrodoEngine.nbar * FrodoEngine.nbar / 8;
    short num3 = (short) ((1 << this.B) - 1);
    short num4 = (short) ((1 << this.D) - 1);
    byte[] numArray = new byte[8 * this.B];
    for (int index2 = 0; index2 < num2; ++index2)
    {
      long num5 = 0;
      for (int index3 = 0; index3 < num1; ++index3)
      {
        short num6 = (short) (((int) input[index1] & (int) num4) + (1 << this.D - this.B - 1) >> this.D - this.B);
        num5 |= (long) ((int) num6 & (int) num3) << this.B * index3;
        ++index1;
      }
      for (int index4 = 0; index4 < this.B; ++index4)
        numArray[index2 * this.B + index4] = (byte) (num5 >> 8 * index4 & (long) byte.MaxValue);
    }
    return numArray;
  }

  private short CTVerify(short[] a1, short[] a2, short[] b1, short[] b2)
  {
    short num = 0;
    for (short index = 0; (int) index < a1.Length; ++index)
      num |= (short) ((int) a1[(int) index] ^ (int) b1[(int) index]);
    for (short index = 0; (int) index < a2.Length; ++index)
      num |= (short) ((int) a2[(int) index] ^ (int) b2[(int) index]);
    return num == (short) 0 ? (short) 0 : (short) -1;
  }

  private byte[] CTSelect(byte[] a, byte[] b, short selector)
  {
    byte[] numArray = new byte[a.Length];
    for (int index = 0; index < a.Length; ++index)
      numArray[index] = (byte) ((int) ~selector & (int) a[index] & (int) byte.MaxValue | (int) selector & (int) b[index] & (int) byte.MaxValue);
    return numArray;
  }

  public void kem_dec(byte[] ss, byte[] ct, byte[] sk)
  {
    int num1 = 0;
    int num2 = FrodoEngine.mbar * this.n * this.D / 8;
    byte[] input1 = Arrays.CopyOfRange(ct, 0, 0 + num2);
    int from1 = 0 + num2;
    int num3 = FrodoEngine.mbar * FrodoEngine.nbar * this.D / 8;
    byte[] input2 = Arrays.CopyOfRange(ct, from1, from1 + num3);
    num1 = 0;
    int lenSBytes = this.len_s_bytes;
    byte[] b = Arrays.CopyOfRange(sk, 0, 0 + lenSBytes);
    int from2 = 0 + lenSBytes;
    int lenSeedABytes = FrodoEngine.len_seedA_bytes;
    byte[] seedA = Arrays.CopyOfRange(sk, from2, from2 + lenSeedABytes);
    int from3 = from2 + lenSeedABytes;
    int num4 = this.D * this.n * FrodoEngine.nbar / 8;
    byte[] input3 = Arrays.CopyOfRange(sk, from3, from3 + num4);
    int from4 = from3 + num4;
    int num5 = this.n * FrodoEngine.nbar * 16 /*0x10*/ / 8;
    byte[] bs = Arrays.CopyOfRange(sk, from4, from4 + num5);
    short[] X1 = new short[FrodoEngine.nbar * this.n];
    for (int index1 = 0; index1 < FrodoEngine.nbar; ++index1)
    {
      for (int index2 = 0; index2 < this.n; ++index2)
        X1[index1 * this.n + index2] = (short) Pack.LE_To_UInt16(bs, index1 * this.n * 2 + index2 * 2);
    }
    short[] Y1 = this.MatrixTranspose(X1, FrodoEngine.nbar, this.n);
    int from5 = from4 + num5;
    int lenPkhBytes = this.len_pkh_bytes;
    byte[] input4 = Arrays.CopyOfRange(sk, from5, from5 + lenPkhBytes);
    short[] numArray1 = this.FrodoUnpack(input1, FrodoEngine.mbar, this.n);
    short[] numArray2 = this.FrodoUnpack(input2, FrodoEngine.mbar, FrodoEngine.nbar);
    short[] Y2 = this.MatrixMul(numArray1, FrodoEngine.mbar, this.n, Y1, FrodoEngine.nbar);
    byte[] numArray3 = this.Decode(this.MatrixSub(numArray2, Y2, FrodoEngine.mbar, FrodoEngine.nbar));
    byte[] numArray4 = new byte[this.len_seedSE_bytes + this.len_k_bytes];
    this.digest.BlockUpdate(input4, 0, this.len_pkh_bytes);
    this.digest.BlockUpdate(numArray3, 0, this.len_mu_bytes);
    ((IXof) this.digest).OutputFinal(numArray4, 0, this.len_seedSE_bytes + this.len_k_bytes);
    byte[] a = Arrays.CopyOfRange(numArray4, this.len_seedSE_bytes, this.len_seedSE_bytes + this.len_k_bytes);
    byte[] numArray5 = new byte[(2 * FrodoEngine.mbar * this.n + FrodoEngine.mbar * FrodoEngine.mbar) * FrodoEngine.len_chi_bytes];
    this.digest.Update((byte) 150);
    this.digest.BlockUpdate(numArray4, 0, this.len_seedSE_bytes);
    ((IXof) this.digest).OutputFinal(numArray5, 0, numArray5.Length);
    short[] r = new short[2 * FrodoEngine.mbar * this.n + FrodoEngine.mbar * FrodoEngine.nbar];
    for (int index = 0; index < r.Length; ++index)
      r[index] = (short) Pack.LE_To_UInt16(numArray5, index * 2);
    short[] X2 = this.SampleMatrix(r, 0, FrodoEngine.mbar, this.n);
    short[] Y3 = this.SampleMatrix(r, FrodoEngine.mbar * this.n, FrodoEngine.mbar, this.n);
    short[] Y4 = this.gen.GenMatrix(seedA);
    short[] b1 = this.MatrixAdd(this.MatrixMul(X2, FrodoEngine.mbar, this.n, Y4, this.n), Y3, FrodoEngine.mbar, this.n);
    short[] Y5 = this.SampleMatrix(r, 2 * FrodoEngine.mbar * this.n, FrodoEngine.mbar, FrodoEngine.nbar);
    short[] Y6 = this.FrodoUnpack(input3, this.n, FrodoEngine.nbar);
    short[] b2 = this.MatrixAdd(this.MatrixAdd(this.MatrixMul(X2, FrodoEngine.mbar, this.n, Y6, FrodoEngine.nbar), Y5, FrodoEngine.mbar, FrodoEngine.nbar), this.Encode(numArray3), FrodoEngine.mbar, FrodoEngine.nbar);
    short selector = this.CTVerify(numArray1, numArray2, b1, b2);
    byte[] input5 = this.CTSelect(a, b, selector);
    this.digest.BlockUpdate(input1, 0, input1.Length);
    this.digest.BlockUpdate(input2, 0, input2.Length);
    this.digest.BlockUpdate(input5, 0, input5.Length);
    ((IXof) this.digest).OutputFinal(ss, 0, this.len_ss_bytes);
  }
}
