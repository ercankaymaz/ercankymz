// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.NtruPrime.NtruPrimeEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.NtruPrime;

internal class NtruPrimeEngine
{
  private readonly int _skBytes;
  private readonly int _pkBytes;
  private readonly int _ctBytes;
  private readonly int _secretKeyBytes;
  private readonly int _publicKeyBytes;
  private readonly int _ciphertextsBytes;
  private readonly int _confirmBytes;
  private readonly int _inputsBytes;
  private readonly int _topBytes;
  private readonly int _seedBytes;
  private readonly int _smallBytes;
  private readonly int _hashBytes;
  private readonly int SessionKeyBytes;
  private readonly int _p;
  private readonly int _q;
  private readonly int _roundedBytes;
  private readonly bool _lpr;
  private readonly int _w;
  private readonly int _tau0;
  private readonly int _tau1;
  private readonly int _tau2;
  private readonly int _tau3;
  private readonly int _I;
  private readonly int _q12;

  public int PrivateKeySize => this._skBytes;

  public int PublicKeySize => this._pkBytes;

  public int CipherTextSize => this._ctBytes;

  public int SessionKeySize => this.SessionKeyBytes;

  public NtruPrimeEngine(
    int p,
    int q,
    bool lpr,
    int w,
    int tau0,
    int tau1,
    int tau2,
    int tau3,
    int skBytes,
    int pkBytes,
    int ctBytes,
    int roundedBytes,
    int rqBytes,
    int defaultKeyLen)
  {
    this._p = p;
    this._q = q;
    this._w = w;
    this._tau0 = tau0;
    this._tau1 = tau1;
    this._tau2 = tau2;
    this._tau3 = tau3;
    this._roundedBytes = roundedBytes;
    this._skBytes = skBytes;
    this._pkBytes = pkBytes;
    this._ctBytes = ctBytes;
    this._lpr = lpr;
    this._confirmBytes = 32 /*0x20*/;
    this.SessionKeyBytes = defaultKeyLen;
    this._smallBytes = (p + 3) / 4;
    this._q12 = (q - 1) / 2;
    this._hashBytes = 32 /*0x20*/;
    if (lpr)
    {
      this._seedBytes = 32 /*0x20*/;
      this._I = 256 /*0x0100*/;
      this._inputsBytes = this._I / 8;
      this._topBytes = this._I / 2;
      this._ciphertextsBytes = roundedBytes + this._topBytes;
      this._secretKeyBytes = this._smallBytes;
      this._publicKeyBytes = this._seedBytes + roundedBytes;
    }
    else
    {
      this._inputsBytes = this._smallBytes;
      this._ciphertextsBytes = this._roundedBytes;
      this._secretKeyBytes = 2 * this._smallBytes;
      this._publicKeyBytes = rqBytes;
    }
  }

  public void kem_keypair(byte[] pk, byte[] sk, SecureRandom random)
  {
    this.KeyGen(random, ref pk, ref sk);
    Array.Copy((Array) pk, 0, (Array) sk, this._secretKeyBytes, this._publicKeyBytes);
    byte[] numArray = new byte[this._inputsBytes];
    random.NextBytes(numArray);
    Array.Copy((Array) numArray, 0, (Array) sk, this._secretKeyBytes + this._publicKeyBytes, this._inputsBytes);
    this.HashPrefix(ref sk, 4, ref pk, this._publicKeyBytes);
  }

  public void kem_enc(byte[] ct, byte[] ss, byte[] pk, SecureRandom random)
  {
    sbyte[] output1 = !this._lpr ? new sbyte[this._p] : new sbyte[this._I];
    byte[] numArray = new byte[this._inputsBytes];
    byte[] output2 = new byte[this._hashBytes];
    this.HashPrefix(ref output2, 4, ref pk, this._publicKeyBytes);
    if (this._lpr)
      this.InputsRandom(ref output1, random);
    else
      this.ShortRandom(ref output1, random);
    this.Hide(ref ct, numArray, output1, pk, output2);
    this.HashSession(ref ss, 1, numArray, ct);
  }

  public void kem_dec(byte[] ss, byte[] ct, byte[] sk)
  {
    byte[] numArray1 = new byte[sk.Length - this._secretKeyBytes];
    Array.Copy((Array) sk, this._secretKeyBytes, (Array) numArray1, 0, numArray1.Length);
    byte[] numArray2 = new byte[numArray1.Length - this._publicKeyBytes];
    Array.Copy((Array) numArray1, this._publicKeyBytes, (Array) numArray2, 0, numArray2.Length);
    byte[] numArray3 = new byte[numArray2.Length - this._inputsBytes];
    Array.Copy((Array) numArray2, this._inputsBytes, (Array) numArray3, 0, numArray3.Length);
    sbyte[] output1 = !this._lpr ? new sbyte[this._p] : new sbyte[this._I];
    byte[] numArray4 = new byte[this._inputsBytes];
    byte[] output2 = new byte[this._ciphertextsBytes + this._confirmBytes];
    byte[] c = Arrays.Clone(ct);
    this.Decrypt(ref output1, c, sk);
    this.Hide(ref output2, numArray4, output1, numArray1, numArray3);
    int num = this.ctDiffMask(ct, output2);
    for (int index = 0; index < this._inputsBytes; ++index)
      numArray4[index] ^= (byte) (num & ((int) numArray4[index] ^ (int) numArray2[index]));
    this.HashSession(ref ss, 1 + num, numArray4, ct);
  }

  private void KeyGen(SecureRandom random, ref byte[] pk, ref byte[] sk)
  {
    if (this._lpr)
    {
      short[] output1 = new short[this._p];
      sbyte[] a = new sbyte[this._p];
      byte[] numArray = new byte[this._seedBytes];
      random.NextBytes(numArray);
      Array.Copy((Array) numArray, 0, (Array) pk, 0, this._seedBytes);
      short[] output2 = new short[this._p];
      this.Generator(ref output2, numArray);
      this.ShortRandom(ref a, random);
      short[] output3 = new short[this._p];
      this.RqMult(ref output3, output2, ref a);
      this.Round(ref output1, output3);
      byte[] output4 = new byte[pk.Length];
      this.RoundedEncode(ref output4, output1);
      Array.Copy((Array) output4, 0, (Array) pk, this._seedBytes, pk.Length - this._seedBytes);
      this.ByteEncode(ref sk, a);
    }
    else
    {
      short[] output5 = new short[this._p];
      sbyte[] output6 = new sbyte[this._p];
      sbyte[] output7 = new sbyte[this._p];
      sbyte[] output8 = new sbyte[this._p];
      short[] output9 = new short[this._p];
      do
      {
        this.ByteRandom(ref output8, random);
      }
      while (this.R3Recip(ref output7, output8) != 0);
      this.ShortRandom(ref output6, random);
      this.RqRecip3(ref output9, output6);
      this.RqMult(ref output5, output9, output8);
      this.RqEncode(ref pk, output5);
      this.ByteEncode(ref sk, output6);
      byte[] output10 = new byte[sk.Length];
      this.ByteEncode(ref output10, output7);
      Array.Copy((Array) output10, 0, (Array) sk, this._smallBytes, sk.Length - this._smallBytes);
    }
  }

  private void ByteRandom(ref sbyte[] output, SecureRandom random)
  {
    for (int index = 0; index < this._p; ++index)
    {
      byte[] buffer = new byte[4];
      random.NextBytes(buffer);
      output[index] = (sbyte) ((((int) BitConverter.ToUInt32(buffer, 0) & 1073741823 /*0x3FFFFFFF*/) * 3 >>> 30) - 1);
    }
  }

  private int R3Recip(ref sbyte[] output, sbyte[] input)
  {
    sbyte[] numArray1 = new sbyte[this._p + 1];
    sbyte[] numArray2 = new sbyte[this._p + 1];
    sbyte[] numArray3 = new sbyte[this._p + 1];
    sbyte[] numArray4 = new sbyte[this._p + 1];
    for (int index = 0; index < this._p + 1; ++index)
    {
      numArray3[index] = (sbyte) 0;
      numArray4[index] = (sbyte) 0;
    }
    numArray4[0] = (sbyte) 1;
    for (int index = 0; index < this._p; ++index)
      numArray1[index] = (sbyte) 0;
    numArray1[0] = (sbyte) 1;
    sbyte[] numArray5 = numArray1;
    int index1 = this._p - 1;
    numArray1[this._p] = (sbyte) -1;
    numArray5[index1] = (sbyte) -1;
    for (int index2 = 0; index2 < this._p; ++index2)
      numArray2[this._p - 1 - index2] = input[index2];
    numArray2[this._p] = (sbyte) 0;
    int num1 = 1;
    for (int index3 = 0; index3 < 2 * this._p - 1; ++index3)
    {
      for (int p = this._p; p > 0; --p)
        numArray3[p] = numArray3[p - 1];
      numArray3[0] = (sbyte) 0;
      int num2 = (int) -numArray2[0] * (int) numArray1[0];
      int num3 = this.NegativeMask((short) -num1) & (numArray2[0] != (sbyte) 0 ? -1 : 0);
      num1 = (num1 ^ num3 & (num1 ^ -num1)) + 1;
      for (int index4 = 0; index4 < this._p + 1; ++index4)
      {
        int num4 = num3 & ((int) numArray1[index4] ^ (int) numArray2[index4]);
        numArray1[index4] ^= (sbyte) num4;
        numArray2[index4] ^= (sbyte) num4;
        int num5 = num3 & ((int) numArray3[index4] ^ (int) numArray4[index4]);
        numArray3[index4] ^= (sbyte) num5;
        numArray4[index4] ^= (sbyte) num5;
      }
      for (int index5 = 0; index5 < this._p + 1; ++index5)
        numArray2[index5] = (sbyte) (this.mod((double) ((int) numArray2[index5] + num2 * (int) numArray1[index5] + 1), 3.0) - 1.0);
      for (int index6 = 0; index6 < this._p + 1; ++index6)
        numArray4[index6] = (sbyte) (this.mod((double) ((int) numArray4[index6] + num2 * (int) numArray3[index6] + 1), 3.0) - 1.0);
      for (int index7 = 0; index7 < this._p; ++index7)
        numArray2[index7] = numArray2[index7 + 1];
      numArray2[this._p] = (sbyte) 0;
    }
    int num6 = (int) numArray1[0];
    for (int index8 = 0; index8 < this._p; ++index8)
      output[index8] = (sbyte) (num6 * (int) numArray3[this._p - 1 - index8]);
    return num1 == 0 ? 0 : -1;
  }

  private int RqRecip3(ref short[] output, sbyte[] input)
  {
    short[] numArray1 = new short[this._p + 1];
    short[] numArray2 = new short[this._p + 1];
    short[] numArray3 = new short[this._p + 1];
    short[] numArray4 = new short[this._p + 1];
    for (int index = 0; index < this._p + 1; ++index)
    {
      numArray3[index] = (short) 0;
      numArray4[index] = (short) 0;
    }
    numArray4[0] = this.FqRecip((short) 3);
    for (int index = 0; index < this._p; ++index)
      numArray1[index] = (short) 0;
    numArray1[0] = (short) 1;
    short[] numArray5 = numArray1;
    int index1 = this._p - 1;
    numArray1[this._p] = (short) -1;
    numArray5[index1] = (short) -1;
    for (int index2 = 0; index2 < this._p; ++index2)
      numArray2[this._p - 1 - index2] = (short) input[index2];
    numArray2[this._p] = (short) 0;
    int num1 = 1;
    for (int index3 = 0; index3 < 2 * this._p - 1; ++index3)
    {
      for (int p = this._p; p > 0; --p)
        numArray3[p] = numArray3[p - 1];
      numArray3[0] = (short) 0;
      int num2 = this.NegativeMask((short) -num1) & (numArray2[0] != (short) 0 ? -1 : 0);
      num1 = (num1 ^ num2 & (num1 ^ -num1)) + 1;
      for (int index4 = 0; index4 < this._p + 1; ++index4)
      {
        int num3 = num2 & ((int) numArray1[index4] ^ (int) numArray2[index4]);
        numArray1[index4] ^= (short) num3;
        numArray2[index4] ^= (short) num3;
        int num4 = num2 & ((int) numArray3[index4] ^ (int) numArray4[index4]);
        numArray3[index4] ^= (short) num4;
        numArray4[index4] ^= (short) num4;
      }
      int num5 = (int) numArray1[0];
      int num6 = (int) numArray2[0];
      for (int index5 = 0; index5 < this._p + 1; ++index5)
        numArray2[index5] = this.ArithmeticMod_q(num5 * (int) numArray2[index5] - num6 * (int) numArray1[index5]);
      for (int index6 = 0; index6 < this._p + 1; ++index6)
        numArray4[index6] = this.ArithmeticMod_q(num5 * (int) numArray4[index6] - num6 * (int) numArray3[index6]);
      for (int index7 = 0; index7 < this._p; ++index7)
        numArray2[index7] = numArray2[index7 + 1];
      numArray2[this._p] = (short) 0;
    }
    short num7 = this.FqRecip(numArray1[0]);
    for (int index8 = 0; index8 < this._p; ++index8)
      output[index8] = this.ArithmeticMod_q((int) num7 * (int) numArray3[this._p - 1 - index8]);
    return num1 == 0 ? 0 : -1;
  }

  private short FqRecip(short a1)
  {
    int num1 = 1;
    short num2 = a1;
    for (; num1 < this._q - 2; ++num1)
      num2 = this.ArithmeticMod_q((int) a1 * (int) num2);
    return num2;
  }

  private void RqMult(ref short[] output, short[] f, sbyte[] g)
  {
    short[] numArray = new short[this._p + this._p + 1];
    for (int index1 = 0; index1 < this._p; ++index1)
    {
      short num = 0;
      for (int index2 = 0; index2 <= index1; ++index2)
        num = this.ArithmeticMod_q((int) num + (int) f[index2] * (int) g[index1 - index2]);
      numArray[index1] = num;
    }
    for (int p = this._p; p < this._p + this._p - 1; ++p)
    {
      short num = 0;
      for (int index = p - this._p + 1; index < this._p; ++index)
        num = this.ArithmeticMod_q((int) num + (int) f[index] * (int) g[p - index]);
      numArray[p] = num;
    }
    for (int index = this._p + this._p - 2; index >= this._p; --index)
    {
      numArray[index - this._p] = this.ArithmeticMod_q((int) numArray[index - this._p] + (int) numArray[index]);
      numArray[index - this._p + 1] = this.ArithmeticMod_q((int) numArray[index - this._p + 1] + (int) numArray[index]);
    }
    for (int index = 0; index < this._p; ++index)
      output[index] = numArray[index];
  }

  private void RqEncode(ref byte[] output, short[] r)
  {
    ushort[] R = new ushort[this._p];
    ushort[] M = new ushort[this._p];
    for (int index = 0; index < this._p; ++index)
    {
      R[index] = (ushort) ((uint) r[index] + (uint) this._q12);
      M[index] = (ushort) this._q;
    }
    List<byte> output1 = new List<byte>();
    this.Encode(ref output1, R, M, (long) this._p);
    Array.Copy((Array) output1.ToArray(), 0, (Array) output, 0, output1.Count);
  }

  private void RqDecode(ref short[] output, byte[] s)
  {
    ushort[] collection = new ushort[this._p];
    for (int index = 0; index < this._p; ++index)
      collection[index] = (ushort) this._q;
    List<ushort> ushortList = this.Decode(new List<byte>((IEnumerable<byte>) s), new List<ushort>((IEnumerable<ushort>) collection));
    for (int index = 0; index < this._p; ++index)
      output[index] = (short) ((int) ushortList[index] - this._q12);
  }

  private void RqMult3(ref short[] output, short[] f)
  {
    for (int index = 0; index < this._p; ++index)
      output[index] = this.ArithmeticMod_q((int) f[index] * 3);
  }

  private void R3FromRq(ref sbyte[] output, short[] r)
  {
    for (int index = 0; index < this._p; ++index)
      output[index] = (sbyte) this.ArithmeticMod_3((int) r[index]);
  }

  private void R3Mult(ref sbyte[] output, sbyte[] f, sbyte[] g)
  {
    sbyte[] numArray = new sbyte[this._p + this._p + 1];
    for (int index1 = 0; index1 < this._p; ++index1)
    {
      sbyte num = 0;
      for (int index2 = 0; index2 <= index1; ++index2)
        num = (sbyte) this.ArithmeticMod_3((int) num + (int) f[index2] * (int) g[index1 - index2]);
      numArray[index1] = num;
    }
    for (int p = this._p; p < this._p + this._p - 1; ++p)
    {
      sbyte num = 0;
      for (int index = p - this._p + 1; index < this._p; ++index)
        num = (sbyte) this.ArithmeticMod_3((int) num + (int) f[index] * (int) g[p - index]);
      numArray[p] = num;
    }
    for (int index = this._p + this._p - 2; index >= this._p; --index)
    {
      numArray[index - this._p] = (sbyte) this.ArithmeticMod_3((int) numArray[index - this._p] + (int) numArray[index]);
      numArray[index - this._p + 1] = (sbyte) this.ArithmeticMod_3((int) numArray[index - this._p + 1] + (int) numArray[index]);
    }
    for (int index = 0; index < this._p; ++index)
      output[index] = numArray[index];
  }

  private int WeightMask(sbyte[] r)
  {
    int num = 0;
    for (int index = 0; index < this._p; ++index)
      num += (int) r[index] & 1;
    return this.NonZeroMask((short) (num - this._w));
  }

  private int NonZeroMask(short x) => x != (short) 0 ? -1 : 0;

  private List<ushort> Decode(List<byte> S, List<ushort> M)
  {
    int num1 = 16384 /*0x4000*/;
    if (M.Count == 0)
      return new List<ushort>();
    if (M.Count == 1)
    {
      if (M[0] == (ushort) 1)
        return new List<ushort>() { (ushort) 0 };
      if (M[0] <= (ushort) 256 /*0x0100*/)
        return new List<ushort>()
        {
          (ushort) this.mod((double) S[0], (double) M[0])
        };
      return new List<ushort>()
      {
        (ushort) this.mod((double) ((uint) S[0] + ((uint) S[1] << 8)), (double) M[0])
      };
    }
    int index1 = 0;
    List<ushort> ushortList1 = new List<ushort>();
    List<uint> uintList = new List<uint>();
    List<ushort> M1 = new List<ushort>();
    for (int index2 = 0; index2 < M.Count - 1; index2 += 2)
    {
      uint num2 = (uint) M[index2] * (uint) M[index2 + 1];
      ushort num3 = 0;
      uint num4 = 1;
      for (; (long) num2 >= (long) num1; num2 = (uint) Math.Floor((double) ((num2 + (uint) byte.MaxValue) / 256U /*0x0100*/)))
      {
        num3 += (ushort) ((uint) S[index1] * num4);
        num4 *= 256U /*0x0100*/;
        ++index1;
      }
      ushortList1.Add(num3);
      uintList.Add(num4);
      M1.Add((ushort) num2);
    }
    if (M.Count % 2 != 0)
      M1.Add(M[M.Count - 1]);
    List<byte> byteList = new List<byte>();
    List<ushort> ushortList2 = this.Decode(S.GetRange(index1, S.Count - index1), M1);
    List<ushort> ushortList3 = new List<ushort>();
    for (int index3 = 0; index3 < M.Count - 1; index3 += 2)
    {
      uint a = (uint) ushortList1[index3 / 2] + uintList[index3 / 2] * (uint) ushortList2[index3 / 2];
      ushortList3.Add((ushort) this.mod((double) a, (double) M[index3]));
      ushortList3.Add((ushort) this.mod(Math.Floor((double) a / (double) M[index3]), (double) M[index3 + 1]));
    }
    if (M.Count % 2 != 0)
      ushortList3.Add(ushortList2[M1.Count - 1]);
    return ushortList3;
  }

  private void Encode(ref List<byte> output, ushort[] R, ushort[] M, long len)
  {
    int num1 = 16384 /*0x4000*/;
    if (len == 1L)
    {
      ushort num2 = R[0];
      for (ushort index = M[0]; index > (ushort) 1; index = (ushort) ((int) index + (int) byte.MaxValue >> 8))
      {
        output.Add(Decimal.ToByte((Decimal) ((int) num2 % 256 /*0x0100*/)));
        num2 >>= 8;
      }
    }
    if (len <= 1L)
      return;
    ushort[] R1 = new ushort[(len + 1L) / 2L];
    ushort[] M1 = new ushort[(len + 1L) / 2L];
    int index1;
    for (index1 = 0; (long) index1 < len - 1L; index1 += 2)
    {
      uint num3 = (uint) M[index1];
      uint num4 = (uint) R[index1] + (uint) R[index1 + 1] * num3;
      uint num5;
      for (num5 = (uint) M[index1 + 1] * num3; (long) num5 >= (long) num1; num5 = num5 + (uint) byte.MaxValue >> 8)
      {
        output.Add(Decimal.ToByte((Decimal) (num4 % 256U /*0x0100*/)));
        num4 >>= 8;
      }
      R1[index1 / 2] = (ushort) num4;
      M1[index1 / 2] = (ushort) num5;
    }
    if ((long) index1 < len)
    {
      R1[index1 / 2] = R[index1];
      M1[index1 / 2] = M[index1];
    }
    this.Encode(ref output, R1, M1, (len + 1L) / 2L);
  }

  private void Encrypt(ref byte[] output, sbyte[] r, byte[] pk)
  {
    if (this._lpr)
    {
      short[] output1 = new short[this._p];
      short[] output2 = new short[this._p];
      sbyte[] T = new sbyte[this._I];
      byte[] numArray1 = new byte[pk.Length - this._seedBytes];
      Array.Copy((Array) pk, this._seedBytes, (Array) numArray1, 0, numArray1.Length);
      this.RoundedDecode(ref output1, numArray1);
      short[] output3 = new short[this._p];
      sbyte[] numArray2 = new sbyte[this._p];
      byte[] numArray3 = new byte[this._seedBytes];
      Array.Copy((Array) pk, 0, (Array) numArray3, 0, this._seedBytes);
      this.Generator(ref output3, numArray3);
      this.HashShort(ref numArray2, r);
      short[] output4 = new short[this._p];
      short[] output5 = new short[this._p];
      this.RqMult(ref output4, output3, ref numArray2);
      this.Round(ref output2, output4);
      this.RqMult(ref output5, output1, ref numArray2);
      for (int index = 0; index < this._I; ++index)
        T[index] = this.Top((int) this.ArithmeticMod_q((int) output5[index] + (int) r[index] * this._q12));
      this.RoundedEncode(ref output, output2);
      byte[] output6 = new byte[output.Length];
      this.TopEncode(ref output6, T);
      Array.Copy((Array) output6, 0, (Array) output, this._roundedBytes, output.Length - this._roundedBytes);
    }
    else
    {
      short[] output7 = new short[this._p];
      short[] output8 = new short[this._p];
      this.RqDecode(ref output7, pk);
      short[] output9 = new short[this._p];
      this.RqMult(ref output9, output7, r);
      this.Round(ref output8, output9);
      this.RoundedEncode(ref output, output8);
    }
  }

  private void Decrypt(ref sbyte[] output, byte[] c, byte[] sk)
  {
    if (this._lpr)
    {
      sbyte[] numArray = new sbyte[this._p];
      short[] output1 = new short[this._p];
      sbyte[] output2 = new sbyte[this._I];
      this.ByteDecode(ref numArray, sk);
      this.RoundedDecode(ref output1, c);
      Array.Copy((Array) c, this._roundedBytes, (Array) c, 0, c.Length - this._roundedBytes);
      this.TopDecode(ref output2, c);
      short[] output3 = new short[this._p];
      this.RqMult(ref output3, output1, ref numArray);
      for (int index = 0; index < this._I; ++index)
      {
        int num = (int) this.Right(output2[index]) - (int) output3[index] + 4 * this._w + 1;
        output[index] = (sbyte) -this.NegativeMask((short) (this.mod((double) (num + this._q12), (double) this._q) - (double) this._q12));
      }
    }
    else
    {
      sbyte[] output4 = new sbyte[this._p];
      sbyte[] output5 = new sbyte[this._p];
      short[] output6 = new short[this._p];
      this.ByteDecode(ref output4, sk);
      byte[] numArray = new byte[sk.Length];
      Array.Copy((Array) sk, this._smallBytes, (Array) numArray, 0, numArray.Length - this._smallBytes);
      this.ByteDecode(ref output5, numArray);
      this.RoundedDecode(ref output6, c);
      short[] output7 = new short[this._p];
      short[] output8 = new short[this._p];
      sbyte[] output9 = new sbyte[this._p];
      sbyte[] output10 = new sbyte[this._p];
      this.RqMult(ref output7, output6, output4);
      this.RqMult3(ref output8, output7);
      this.R3FromRq(ref output9, output8);
      this.R3Mult(ref output10, output9, output5);
      int num = this.WeightMask(output10);
      for (int index = 0; index < this._w; ++index)
        output[index] = (sbyte) (((int) output10[index] ^ 1) & ~num ^ 1);
      for (int w = this._w; w < this._p; ++w)
        output[w] = (sbyte) ((int) output10[w] & ~num);
    }
  }

  private void Hide(ref byte[] output, byte[] r_enc, sbyte[] r, byte[] pk, byte[] cache)
  {
    if (this._lpr)
      this.InputsEncode(ref r_enc, r);
    else
      this.ByteEncode(ref r_enc, r);
    this.Encrypt(ref output, r, pk);
    Array.Copy((Array) output, 0, (Array) output, this._ctBytes, output.Length - this._ctBytes);
    this.HashConfirm(ref output, ref r_enc, ref pk, ref cache);
  }

  private void Generator(ref short[] output, byte[] seed)
  {
    uint[] numArray = this.Expand(seed);
    for (int index = 0; index < this._p; ++index)
      output[index] = (short) ((long) numArray[index] % (long) this._q - (long) this._q12);
  }

  private uint[] Expand(byte[] k)
  {
    byte[] output = new byte[this._p * 4];
    byte[] input = new byte[this._p * 4];
    uint[] numArray = new uint[this._p];
    BufferedBlockCipher bufferedBlockCipher = new BufferedBlockCipher((IBlockCipherMode) new SicBlockCipher(AesUtilities.CreateEngine()));
    KeyParameter parameters = new KeyParameter(k);
    bufferedBlockCipher.Init(true, (ICipherParameters) new ParametersWithIV((ICipherParameters) parameters, new byte[16 /*0x10*/]));
    int outOff = bufferedBlockCipher.ProcessBytes(input, 0, 4 * this._p, output, 0);
    int num1 = outOff + bufferedBlockCipher.DoFinal(output, outOff);
    for (int index = 0; index < this._p; ++index)
    {
      uint num2 = (uint) output[4 * index];
      uint num3 = (uint) output[4 * index + 1];
      uint num4 = (uint) output[4 * index + 2];
      uint num5 = (uint) output[4 * index + 3];
      numArray[index] = (uint) ((int) num2 + ((int) num3 << 8) + ((int) num4 << 16 /*0x10*/) + ((int) num5 << 24));
    }
    return numArray;
  }

  private void ShortRandom(ref sbyte[] output, SecureRandom random)
  {
    uint[] L_in = new uint[this._p];
    for (int index = 0; index < this._p; ++index)
    {
      byte[] buffer = new byte[4];
      random.NextBytes(buffer);
      L_in[index] = BitConverter.ToUInt32(buffer, 0);
    }
    this.ShortFromList(ref output, L_in);
  }

  private void ShortFromList(ref sbyte[] output, uint[] L_in)
  {
    uint[] array = new uint[this._p];
    for (int index = 0; index < this._w; ++index)
      array[index] = (uint) ((ulong) L_in[index] & 18446744073709551614UL);
    for (int w = this._w; w < this._p; ++w)
      array[w] = (uint) ((ulong) L_in[w] & 18446744073709551613UL) | 1U;
    Array.Sort<uint>(array);
    for (int index = 0; index < this._p; ++index)
      output[index] = (sbyte) (((int) array[index] & 3) - 1);
  }

  private void RqMult(ref short[] output, short[] G, ref sbyte[] a)
  {
    short[] numArray = new short[this._p + this._p - 1];
    for (int index1 = 0; index1 < this._p; ++index1)
    {
      short num = 0;
      for (int index2 = 0; index2 <= index1; ++index2)
        num = this.ArithmeticMod_q((int) num + (int) G[index2] * (int) a[index1 - index2]);
      numArray[index1] = num;
    }
    for (int p = this._p; p < this._p + this._p - 1; ++p)
    {
      short num = 0;
      for (int index = p - this._p + 1; index < this._p; ++index)
        num = this.ArithmeticMod_q((int) num + (int) G[index] * (int) a[p - index]);
      numArray[p] = num;
    }
    for (int index = this._p + this._p - 2; index >= this._p; --index)
    {
      numArray[index - this._p] = this.ArithmeticMod_q((int) numArray[index - this._p] + (int) numArray[index]);
      numArray[index - this._p + 1] = this.ArithmeticMod_q((int) numArray[index - this._p + 1] + (int) numArray[index]);
    }
    for (int index = 0; index < this._p; ++index)
      output[index] = numArray[index];
  }

  private void Round(ref short[] output, short[] aG)
  {
    for (int index = 0; index < this._p; ++index)
      output[index] = (short) ((int) aG[index] - (int) this.ArithmeticMod_3((int) aG[index]));
  }

  private void InputsRandom(ref sbyte[] output, SecureRandom random)
  {
    byte[] buffer = new byte[this._inputsBytes];
    random.NextBytes(buffer);
    for (int index = 0; index < this._I; ++index)
      output[index] = (sbyte) (1 & (int) buffer[index >> 3] >> (index & 7));
  }

  private void InputsEncode(ref byte[] output, sbyte[] r)
  {
    for (int index = 0; index < this._inputsBytes; ++index)
      output[index] = (byte) 0;
    for (int index = 0; index < this._I; ++index)
      output[index >> 3] |= (byte) ((uint) r[index] << (index & 7));
  }

  private void RoundedEncode(ref byte[] output, short[] A)
  {
    ushort[] R = new ushort[this._p];
    ushort[] M = new ushort[this._p];
    for (int index = 0; index < this._p; ++index)
      R[index] = (ushort) (((int) A[index] + this._q12) * 10923 >> 15);
    for (int index = 0; index < this._p; ++index)
      M[index] = (ushort) ((this._q + 2) / 3);
    List<byte> output1 = new List<byte>();
    this.Encode(ref output1, R, M, (long) this._p);
    Array.Copy((Array) output1.ToArray(), 0, (Array) output, 0, output1.Count);
  }

  private void RoundedDecode(ref short[] output, byte[] s)
  {
    List<ushort> M = new List<ushort>(this._p);
    List<byte> S = new List<byte>((IEnumerable<byte>) s);
    for (int index = 0; index < this._p; ++index)
      M.Add((ushort) ((this._q + 2) / 3));
    List<ushort> ushortList = this.Decode(S, M);
    for (int index = 0; index < this._p; ++index)
      output[index] = (short) ((int) ushortList[index] * 3 - this._q12);
  }

  private void ByteEncode(ref byte[] output, sbyte[] a)
  {
    for (int index = 0; index < this._p / 4; ++index)
    {
      int num1 = (int) a[4 * index] + 1;
      int num2 = (int) a[4 * index + 1] + 1 << 2;
      int num3 = (int) a[4 * index + 2] + 1 << 4;
      int num4 = (int) a[4 * index + 3] + 1 << 6;
      int num5 = num2;
      sbyte num6 = (sbyte) (num1 + num5 + num3 + num4);
      output[index] = (byte) num6;
    }
    output[this._p / 4] = (byte) ((uint) a[this._p - 1] + 1U);
  }

  private void ByteDecode(ref sbyte[] output, byte[] s)
  {
    for (int index = 0; index < this._p / 4; ++index)
    {
      byte num1 = s[index];
      output[index * 4] = (sbyte) (((int) num1 & 3) - 1);
      byte num2 = (byte) ((uint) num1 >> 2);
      output[index * 4 + 1] = (sbyte) (((int) num2 & 3) - 1);
      byte num3 = (byte) ((uint) num2 >> 2);
      output[index * 4 + 2] = (sbyte) (((int) num3 & 3) - 1);
      byte num4 = (byte) ((uint) num3 >> 2);
      output[index * 4 + 3] = (sbyte) (((int) num4 & 3) - 1);
    }
    byte num = s[this._p / 4];
    output[this._p / 4 * 4] = (sbyte) (((int) num & 3) - 1);
  }

  private void TopEncode(ref byte[] output, sbyte[] T)
  {
    for (int index = 0; index < this._topBytes; ++index)
      output[index] = (byte) ((uint) T[2 * index] + ((uint) T[2 * index + 1] << 4));
  }

  private void TopDecode(ref sbyte[] output, byte[] s)
  {
    for (int index = 0; index < this._topBytes; ++index)
    {
      output[2 * index] = (sbyte) ((int) s[index] & 15);
      output[2 * index + 1] = (sbyte) ((int) s[index] >> 4);
    }
  }

  private void HashShort(ref sbyte[] output, sbyte[] r)
  {
    byte[] numArray1 = new byte[this._inputsBytes];
    byte[] output1 = new byte[this._hashBytes];
    uint[] numArray2 = new uint[this._p];
    this.InputsEncode(ref numArray1, r);
    this.HashPrefix(ref output1, 5, ref numArray1, numArray1.Length);
    uint[] L_in = this.Expand(output1);
    this.ShortFromList(ref output, L_in);
  }

  private void HashPrefix(ref byte[] output, int b, ref byte[] input, int inlen)
  {
    byte[] input1 = new byte[inlen + 1];
    byte[] numArray = new byte[64 /*0x40*/];
    input1[0] = (byte) b;
    for (int index = 0; index < inlen; ++index)
      input1[index + 1] = input[index];
    Sha512Digest sha512Digest = new Sha512Digest();
    sha512Digest.BlockUpdate(input1, 0, input1.Length);
    sha512Digest.DoFinal(numArray, 0);
    Array.Copy((Array) numArray, 0, (Array) output, output.Length - 32 /*0x20*/, 32 /*0x20*/);
  }

  private void HashConfirm(ref byte[] output, ref byte[] r, ref byte[] pk, ref byte[] cache)
  {
    byte[] input;
    if (this._lpr)
    {
      input = new byte[this._inputsBytes + this._hashBytes];
      for (int index = 0; index < this._inputsBytes; ++index)
        input[index] = r[index];
      for (int index = 0; index < this._hashBytes; ++index)
        input[this._inputsBytes + index] = cache[index];
    }
    else
    {
      input = new byte[this._hashBytes * 2];
      byte[] output1 = new byte[this._hashBytes];
      this.HashPrefix(ref output1, 3, ref r, this._inputsBytes);
      Array.Copy((Array) output1, 0, (Array) input, 0, this._hashBytes);
      for (int index = 0; index < this._hashBytes; ++index)
        input[this._hashBytes + index] = cache[index];
    }
    this.HashPrefix(ref output, 2, ref input, input.Length);
  }

  private void HashSession(ref byte[] output, int b, byte[] y, byte[] z)
  {
    byte[] input;
    if (this._lpr)
    {
      input = new byte[this._inputsBytes + this._ciphertextsBytes + this._confirmBytes];
      for (int index = 0; index < this._inputsBytes; ++index)
        input[index] = y[index];
      for (int index = 0; index < this._ciphertextsBytes + this._confirmBytes; ++index)
        input[this._inputsBytes + index] = z[index];
    }
    else
    {
      input = new byte[this._hashBytes + this._ciphertextsBytes + this._confirmBytes];
      byte[] output1 = new byte[this._hashBytes];
      this.HashPrefix(ref output1, 3, ref y, this._inputsBytes);
      Array.Copy((Array) output1, 0, (Array) input, 0, this._hashBytes);
      for (int index = 0; index < this._ciphertextsBytes + this._confirmBytes; ++index)
        input[this._hashBytes + index] = z[index];
    }
    byte[] output2 = new byte[32 /*0x20*/];
    this.HashPrefix(ref output2, b, ref input, input.Length);
    Array.Copy((Array) output2, 0, (Array) output, 0, output.Length);
  }

  private int NegativeMask(short x) => x >= (short) 0 ? 0 : -1;

  private int ctDiffMask(byte[] c, byte[] c2)
  {
    int num = c.Length ^ c2.Length;
    for (int index = 0; index < c.Length && index < c2.Length; ++index)
      num |= (int) c[index] ^ (int) c2[index];
    return num != 0 ? -1 : 0;
  }

  private double mod(double a, double b) => a - b * Math.Floor(a / b);

  private short ArithmeticMod_q(int x)
  {
    return (short) (this.mod((double) (x + this._q12), (double) this._q) - (double) this._q12);
  }

  private short ArithmeticMod_3(int x) => (short) (this.mod((double) (x + 1), 3.0) - 1.0);

  private sbyte Top(int C) => (sbyte) (this._tau1 * (C + this._tau0) + 16384 /*0x4000*/ >> 15);

  private short Right(sbyte T)
  {
    return (short) (this.mod((double) (this._tau3 * (int) T - this._tau2 + this._q12), (double) this._q) - (double) this._q12);
  }
}
