// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Cmce.CmceEngine`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

internal class CmceEngine<GFImpl> : ICmceEngine where GFImpl : struct, GF
{
  private int SYS_N;
  private int SYS_T;
  private int GFBITS;
  private int IRR_BYTES;
  private int COND_BYTES;
  private int PK_NROWS;
  private int PK_NCOLS;
  private int PK_ROW_BYTES;
  private int SYND_BYTES;
  private int GFMASK;
  private int[] poly;
  private int defaultKeySize;
  private readonly GFImpl gf;
  private readonly Benes benes;
  private bool usePadding;
  private bool countErrorIndices;
  private bool usePivots;

  public int IrrBytes => this.IRR_BYTES;

  public int CondBytes => this.COND_BYTES;

  public int PrivateKeySize => this.COND_BYTES + this.IRR_BYTES + this.SYS_N / 8 + 40;

  public int PublicKeySize
  {
    get
    {
      return !this.usePadding ? this.PK_NROWS * this.PK_NCOLS / 8 : this.PK_NROWS * (this.SYS_N / 8 - (this.PK_NROWS - 1) / 8);
    }
  }

  public int CipherTextSize => this.SYND_BYTES;

  public int DefaultSessionKeySize => this.defaultKeySize;

  internal CmceEngine(int m, int n, int t, int[] p, bool usePivots, int defaultKeySize)
  {
    this.usePivots = usePivots;
    this.SYS_N = n;
    this.SYS_T = t;
    this.GFBITS = m;
    this.poly = p;
    this.defaultKeySize = defaultKeySize;
    this.IRR_BYTES = this.SYS_T * 2;
    this.COND_BYTES = (1 << this.GFBITS - 4) * (2 * this.GFBITS - 1);
    this.PK_NROWS = this.SYS_T * this.GFBITS;
    this.PK_NCOLS = this.SYS_N - this.PK_NROWS;
    this.PK_ROW_BYTES = (this.PK_NCOLS + 7) / 8;
    this.SYND_BYTES = (this.PK_NROWS + 7) / 8;
    this.GFMASK = (1 << this.GFBITS) - 1;
    this.gf = default (GFImpl);
    this.benes = this.GFBITS != 12 ? (Benes) new Benes13(this.SYS_N, this.SYS_T, this.GFBITS) : (Benes) new Benes12(this.SYS_N, this.SYS_T, this.GFBITS);
    this.usePadding = this.SYS_T % 8 != 0;
    this.countErrorIndices = 1 << this.GFBITS > this.SYS_N;
  }

  public byte[] GeneratePublicKeyFromPrivateKey(byte[] sk)
  {
    byte[] pk = new byte[this.PublicKeySize];
    ushort[] pi = new ushort[1 << this.GFBITS];
    ulong[] pivots = new ulong[1];
    uint[] perm = new uint[1 << this.GFBITS];
    byte[] numArray = new byte[this.SYS_N / 8 + (1 << this.GFBITS) * 4];
    int num = numArray.Length - 32 /*0x20*/ - this.IRR_BYTES - (1 << this.GFBITS) * 4;
    IDigest digest = DigestUtilities.GetDigest(NistObjectIdentifiers.IdShake256);
    digest.Update((byte) 64 /*0x40*/);
    digest.BlockUpdate(sk, 0, 32 /*0x20*/);
    ((IXof) digest).OutputFinal(numArray, 0, numArray.Length);
    for (int index = 0; index < 1 << this.GFBITS; ++index)
      perm[index] = Utils.Load4(numArray, num + index * 4);
    this.PKGen(pk, sk, perm, pi, pivots);
    return pk;
  }

  public byte[] DecompressPrivateKey(byte[] sk)
  {
    byte[] numArray1 = new byte[this.PrivateKeySize];
    Array.Copy((Array) sk, 0, (Array) numArray1, 0, sk.Length);
    byte[] numArray2 = new byte[this.SYS_N / 8 + (1 << this.GFBITS) * 4 + this.IRR_BYTES + 32 /*0x20*/];
    IDigest digest = DigestUtilities.GetDigest(NistObjectIdentifiers.IdShake256);
    digest.Update((byte) 64 /*0x40*/);
    digest.BlockUpdate(sk, 0, 32 /*0x20*/);
    ((IXof) digest).OutputFinal(numArray2, 0, numArray2.Length);
    if (sk.Length <= 40)
    {
      ushort[] field = new ushort[this.SYS_T];
      byte[] numArray3 = new byte[this.IRR_BYTES];
      int num = numArray2.Length - 32 /*0x20*/ - this.IRR_BYTES;
      for (int index = 0; index < this.SYS_T; ++index)
        field[index] = Utils.LoadGF(numArray2, num + index * 2, this.GFMASK);
      this.GenerateIrrPoly(field);
      for (int index = 0; index < this.SYS_T; ++index)
        Utils.StoreGF(numArray3, index * 2, field[index]);
      Array.Copy((Array) numArray3, 0, (Array) numArray1, 40, this.IRR_BYTES);
    }
    if (sk.Length <= 40 + this.IRR_BYTES)
    {
      uint[] perm = new uint[1 << this.GFBITS];
      ushort[] pi = new ushort[1 << this.GFBITS];
      int num = numArray2.Length - 32 /*0x20*/ - this.IRR_BYTES - (1 << this.GFBITS) * 4;
      for (int index = 0; index < 1 << this.GFBITS; ++index)
        perm[index] = Utils.Load4(numArray2, num + index * 4);
      if (this.usePivots)
      {
        ulong[] pivots = new ulong[1];
        this.PKGen((byte[]) null, numArray1, perm, pi, pivots);
      }
      else
      {
        long[] temp = new long[1 << this.GFBITS];
        for (int index = 0; index < 1 << this.GFBITS; ++index)
          temp[index] = (long) perm[index] << 31 /*0x1F*/ | (long) (uint) index;
        CmceEngine<GFImpl>.Sort64(temp, 0, temp.Length);
        for (int index = 0; index < 1 << this.GFBITS; ++index)
          pi[index] = (ushort) ((ulong) temp[index] & (ulong) this.GFMASK);
      }
      byte[] numArray4 = new byte[this.COND_BYTES];
      CmceEngine<GFImpl>.ControlBitsFromPermutation(numArray4, pi, (long) this.GFBITS, (long) (1 << this.GFBITS));
      Array.Copy((Array) numArray4, 0, (Array) numArray1, this.IRR_BYTES + 40, numArray4.Length);
    }
    Array.Copy((Array) numArray2, 0, (Array) numArray1, this.PrivateKeySize - this.SYS_N / 8, this.SYS_N / 8);
    return numArray1;
  }

  public void KemKeypair(byte[] pk, byte[] sk, SecureRandom random)
  {
    byte[] input = new byte[1];
    byte[] numArray1 = new byte[32 /*0x20*/];
    input[0] = (byte) 64 /*0x40*/;
    random.NextBytes(numArray1);
    byte[] numArray2 = new byte[this.SYS_N / 8 + (1 << this.GFBITS) * 4 + this.SYS_T * 2 + 32 /*0x20*/];
    byte[] sourceArray = numArray1;
    ulong[] pivots = new ulong[1];
    IDigest digest = DigestUtilities.GetDigest(NistObjectIdentifiers.IdShake256);
    uint[] perm;
    int num1;
    ushort[] pi;
    do
    {
      ushort[] field;
      int num2;
      do
      {
        digest.BlockUpdate(input, 0, input.Length);
        digest.BlockUpdate(numArray1, 0, numArray1.Length);
        ((IXof) digest).OutputFinal(numArray2, 0, numArray2.Length);
        int from = numArray2.Length - 32 /*0x20*/;
        numArray1 = Arrays.CopyOfRange(numArray2, from, from + 32 /*0x20*/);
        Array.Copy((Array) sourceArray, 0, (Array) sk, 0, 32 /*0x20*/);
        sourceArray = Arrays.CopyOfRange(numArray1, 0, 32 /*0x20*/);
        field = new ushort[this.SYS_T];
        int num3 = numArray2.Length - 32 /*0x20*/ - 2 * this.SYS_T;
        num2 = num3;
        for (int index = 0; index < this.SYS_T; ++index)
          field[index] = Utils.LoadGF(numArray2, num3 + index * 2, this.GFMASK);
      }
      while (this.GenerateIrrPoly(field) == -1);
      int num4 = 40;
      for (int index = 0; index < this.SYS_T; ++index)
        Utils.StoreGF(sk, num4 + index * 2, field[index]);
      perm = new uint[1 << this.GFBITS];
      num1 = num2 - (1 << this.GFBITS) * 4;
      for (int index = 0; index < 1 << this.GFBITS; ++index)
        perm[index] = Utils.Load4(numArray2, num1 + index * 4);
      pi = new ushort[1 << this.GFBITS];
    }
    while (this.PKGen(pk, sk, perm, pi, pivots) == -1);
    byte[] numArray3 = new byte[this.COND_BYTES];
    CmceEngine<GFImpl>.ControlBitsFromPermutation(numArray3, pi, (long) this.GFBITS, (long) (1 << this.GFBITS));
    Array.Copy((Array) numArray3, 0, (Array) sk, this.IRR_BYTES + 40, numArray3.Length);
    int sourceIndex = num1 - this.SYS_N / 8;
    Array.Copy((Array) numArray2, sourceIndex, (Array) sk, sk.Length - this.SYS_N / 8, this.SYS_N / 8);
    if (!this.usePivots)
      Utils.Store8(sk, 32 /*0x20*/, (ulong) uint.MaxValue);
    else
      Utils.Store8(sk, 32 /*0x20*/, pivots[0]);
  }

  private void Syndrome(byte[] cipher_text, byte[] pk, byte[] error_vector)
  {
    short[] numArray = new short[this.SYS_N / 8];
    int num1 = 0;
    int num2 = this.PK_NROWS % 8;
    for (int index = 0; index < this.SYND_BYTES; ++index)
      cipher_text[index] = (byte) 0;
    for (int index1 = 0; index1 < this.PK_NROWS; ++index1)
    {
      for (int index2 = 0; index2 < this.SYS_N / 8; ++index2)
        numArray[index2] = (short) 0;
      for (int index3 = 0; index3 < this.PK_ROW_BYTES; ++index3)
        numArray[this.SYS_N / 8 - this.PK_ROW_BYTES + index3] = (short) pk[num1 + index3];
      if (this.usePadding)
      {
        for (int index4 = this.SYS_N / 8 - 1; index4 >= this.SYS_N / 8 - this.PK_ROW_BYTES; --index4)
          numArray[index4] = (short) ((((int) numArray[index4] & (int) byte.MaxValue) << num2 | ((int) numArray[index4 - 1] & (int) byte.MaxValue) >> 8 - num2) & (int) byte.MaxValue);
      }
      numArray[index1 / 8] |= (short) (1 << index1 % 8);
      byte num3 = 0;
      for (int index5 = 0; index5 < this.SYS_N / 8; ++index5)
        num3 ^= (byte) ((uint) numArray[index5] & (uint) error_vector[index5]);
      byte num4 = (byte) ((uint) num3 ^ (uint) (byte) ((uint) num3 >> 4));
      byte num5 = (byte) ((uint) num4 ^ (uint) (byte) ((uint) num4 >> 2));
      byte num6 = (byte) ((uint) (byte) ((uint) num5 ^ (uint) (byte) ((uint) num5 >> 1)) & 1U);
      cipher_text[index1 / 8] |= (byte) ((uint) num6 << index1 % 8);
      num1 += this.PK_ROW_BYTES;
    }
  }

  private void GenerateErrorVector(byte[] error_vector, SecureRandom random)
  {
    ushort[] numArray1 = new ushort[this.SYS_T * 2];
    ushort[] numArray2 = new ushort[this.SYS_T];
    byte[] numArray3 = new byte[this.SYS_T];
    int num1;
    do
    {
      if (!this.countErrorIndices)
      {
        byte[] numArray4 = new byte[this.SYS_T * 2];
        random.NextBytes(numArray4);
        for (int index = 0; index < this.SYS_T; ++index)
          numArray2[index] = Utils.LoadGF(numArray4, index * 2, this.GFMASK);
      }
      else
        goto label_13;
label_4:
      num1 = 0;
      for (int index1 = 1; index1 < this.SYS_T && num1 != 1; ++index1)
      {
        for (int index2 = 0; index2 < index1; ++index2)
        {
          if ((int) numArray2[index1] == (int) numArray2[index2])
          {
            num1 = 1;
            break;
          }
        }
      }
      continue;
label_13:
      byte[] numArray5 = new byte[this.SYS_T * 4];
      random.NextBytes(numArray5);
      for (int index = 0; index < this.SYS_T * 2; ++index)
        numArray1[index] = Utils.LoadGF(numArray5, index * 2, this.GFMASK);
      int num2 = 0;
      for (int index = 0; index < this.SYS_T * 2 && num2 < this.SYS_T; ++index)
      {
        if ((int) numArray1[index] < this.SYS_N)
          numArray2[num2++] = numArray1[index];
      }
      if (num2 >= this.SYS_T)
        goto label_4;
    }
    while (num1 != 0);
    for (int index = 0; index < this.SYS_T; ++index)
      numArray3[index] = (byte) (1 << ((int) numArray2[index] & 7));
    for (short x = 0; (int) x < this.SYS_N / 8; ++x)
    {
      error_vector[(int) x] = (byte) 0;
      for (int index = 0; index < this.SYS_T; ++index)
      {
        short num3 = (short) ((int) (short) CmceEngine<GFImpl>.SameMask32(x, (short) ((int) numArray2[index] >> 3)) & (int) byte.MaxValue);
        error_vector[(int) x] |= (byte) ((uint) numArray3[index] & (uint) num3);
      }
    }
  }

  private void Encrypt(byte[] cipher_text, byte[] pk, byte[] error_vector, SecureRandom random)
  {
    this.GenerateErrorVector(error_vector, random);
    this.Syndrome(cipher_text, pk, error_vector);
  }

  public int KemEnc(byte[] cipher_text, byte[] key, byte[] pk, SecureRandom random)
  {
    byte[] numArray = new byte[this.SYS_N / 8];
    int num1 = 0;
    if (this.usePadding)
      num1 = this.CheckPKPadding(pk);
    this.Encrypt(cipher_text, pk, numArray, random);
    IDigest digest = DigestUtilities.GetDigest(NistObjectIdentifiers.IdShake256);
    digest.Update((byte) 1);
    digest.BlockUpdate(numArray, 0, numArray.Length);
    digest.BlockUpdate(cipher_text, 0, cipher_text.Length);
    ((IXof) digest).OutputFinal(key, 0, key.Length);
    if (!this.usePadding)
      return 0;
    byte num2 = (byte) ((uint) (byte) num1 ^ (uint) byte.MaxValue);
    for (int index = 0; index < this.SYND_BYTES; ++index)
      cipher_text[index] &= num2;
    for (int index = 0; index < 32 /*0x20*/; ++index)
      key[index] &= num2;
    return num1;
  }

  public int KemDec(byte[] key, byte[] cipher_text, byte[] sk)
  {
    byte[] error_vector = new byte[this.SYS_N / 8];
    byte[] input = new byte[1 + this.SYS_N / 8 + this.SYND_BYTES];
    int num1 = 0;
    if (this.usePadding)
      num1 = this.CheckCPadding(cipher_text);
    short num2 = (short) ((int) (short) ((int) (short) ((int) (short) (byte) this.Decrypt(error_vector, sk, cipher_text) - 1) >> 8) & (int) byte.MaxValue);
    input[0] = (byte) ((uint) num2 & 1U);
    for (int index = 0; index < this.SYS_N / 8; ++index)
      input[1 + index] = (byte) ((int) ~num2 & (int) sk[index + 40 + this.IRR_BYTES + this.COND_BYTES] | (int) num2 & (int) error_vector[index]);
    for (int index = 0; index < this.SYND_BYTES; ++index)
      input[1 + this.SYS_N / 8 + index] = cipher_text[index];
    DigestUtilities.GetDigest(NistObjectIdentifiers.IdShake256);
    IDigest digest = DigestUtilities.GetDigest(NistObjectIdentifiers.IdShake256);
    digest.BlockUpdate(input, 0, input.Length);
    ((IXof) digest).OutputFinal(key, 0, key.Length);
    if (!this.usePadding)
      return 0;
    byte num3 = (byte) num1;
    for (int index = 0; index < key.Length; ++index)
      key[index] |= num3;
    return num1;
  }

  private int Decrypt(byte[] error_vector, byte[] sk, byte[] cipher_text)
  {
    ushort[] f = new ushort[this.SYS_T + 1];
    ushort[] numArray1 = new ushort[this.SYS_N];
    ushort[] numArray2 = new ushort[this.SYS_T * 2];
    ushort[] output1 = new ushort[this.SYS_T * 2];
    ushort[] numArray3 = new ushort[this.SYS_T + 1];
    ushort[] output2 = new ushort[this.SYS_N];
    byte[] r = new byte[this.SYS_N / 8];
    for (int index = 0; index < this.SYND_BYTES; ++index)
      r[index] = cipher_text[index];
    for (int syndBytes = this.SYND_BYTES; syndBytes < this.SYS_N / 8; ++syndBytes)
      r[syndBytes] = (byte) 0;
    for (int index = 0; index < this.SYS_T; ++index)
      f[index] = Utils.LoadGF(sk, 40 + index * 2, this.GFMASK);
    f[this.SYS_T] = (ushort) 1;
    this.benes.SupportGen(numArray1, sk);
    this.Synd(numArray2, f, numArray1, r);
    this.BM(numArray3, numArray2);
    this.Root(output2, numArray3, numArray1);
    for (int index = 0; index < this.SYS_N / 8; ++index)
      error_vector[index] = (byte) 0;
    int num1 = 0;
    for (int index = 0; index < this.SYS_N; ++index)
    {
      ushort num2 = (ushort) ((uint) this.gf.GFIsZero(output2[index]) & 1U);
      error_vector[index / 8] |= (byte) ((uint) num2 << index % 8);
      num1 += (int) num2;
    }
    this.Synd(output1, f, numArray1, error_vector);
    int num3 = num1 ^ this.SYS_T;
    for (int index = 0; index < this.SYS_T * 2; ++index)
      num3 |= (int) numArray2[index] ^ (int) output1[index];
    return num3 - 1 >> 15 & 1 ^ 1;
  }

  private static int Min(ushort a, int b) => (int) a < b ? (int) a : b;

  private void BM(ushort[] output, ushort[] s)
  {
    ushort num1 = 0;
    ushort[] numArray1 = new ushort[this.SYS_T + 1];
    ushort[] numArray2 = new ushort[this.SYS_T + 1];
    ushort[] numArray3 = new ushort[this.SYS_T + 1];
    ushort den = 1;
    for (int index1 = 0; index1 < this.SYS_T + 1; ++index1)
    {
      ushort[] numArray4 = numArray2;
      int index2 = index1;
      numArray3[index1] = (ushort) 0;
      numArray4[index2] = (ushort) 0;
    }
    ushort[] numArray5 = numArray3;
    numArray2[0] = (ushort) 1;
    numArray5[1] = (ushort) 1;
    for (ushort a = 0; (int) a < 2 * this.SYS_T; ++a)
    {
      uint input = 0;
      GFImpl gf;
      for (int index = 0; index <= CmceEngine<GFImpl>.Min(a, this.SYS_T); ++index)
      {
        int num2 = (int) input;
        gf = this.gf;
        int num3 = (int) gf.GFMulExt(numArray2[index], s[(int) a - index]);
        input = (uint) (num2 ^ num3);
      }
      gf = this.gf;
      ushort num4 = gf.GFReduce(input);
      ushort num5 = (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) num4 - 1U) >> 15) & 1U) - 1U);
      ushort num6 = (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) a - (uint) (ushort) (2U * (uint) num1)) >> 15) & 1U) - 1U) & (uint) num5);
      for (int index = 0; index <= this.SYS_T; ++index)
        numArray1[index] = numArray2[index];
      gf = this.gf;
      ushort left = gf.GFFrac(den, num4);
      for (int index = 0; index <= this.SYS_T; ++index)
      {
        ref ushort local = ref numArray2[index];
        int num7 = (int) local;
        gf = this.gf;
        int num8 = (int) (ushort) ((uint) gf.GFMul(left, numArray3[index]) & (uint) num5);
        local = (ushort) (num7 ^ num8);
      }
      num1 = (ushort) ((int) num1 & (int) ~num6 | (int) a + 1 - (int) num1 & (int) num6);
      for (int index = this.SYS_T - 1; index >= 0; --index)
        numArray3[index + 1] = (ushort) ((int) numArray3[index] & (int) ~num6 | (int) numArray1[index] & (int) num6);
      numArray3[0] = (ushort) 0;
      den = (ushort) ((int) den & (int) ~num6 | (int) num4 & (int) num6);
    }
    for (int index = 0; index <= this.SYS_T; ++index)
      output[index] = numArray2[this.SYS_T - index];
  }

  private void Synd(ushort[] output, ushort[] f, ushort[] L, byte[] r)
  {
    ushort num1 = (ushort) ((uint) r[0] & 1U);
    ushort num2 = L[0];
    ushort left1 = (ushort) ((uint) this.gf.GFInv(this.gf.GFSq(this.Eval(f, num2))) & (uint) -num1);
    output[0] = left1;
    for (int index = 1; index < 2 * this.SYS_T; ++index)
    {
      left1 = this.gf.GFMul(left1, num2);
      output[index] = left1;
    }
    for (int index1 = 1; index1 < this.SYS_N; ++index1)
    {
      ushort right = (ushort) ((int) r[index1 / 8] >> index1 % 8 & 1);
      ushort num3 = L[index1];
      ushort input = this.Eval(f, num3);
      GFImpl gf = this.gf;
      ushort left2 = gf.GFInv(this.gf.GFSq(input));
      gf = this.gf;
      ushort left3 = gf.GFMul(left2, right);
      output[0] ^= left3;
      for (int index2 = 1; index2 < 2 * this.SYS_T; ++index2)
      {
        gf = this.gf;
        left3 = gf.GFMul(left3, num3);
        output[index2] ^= left3;
      }
    }
  }

  private int MovColumns(byte[][] mat, ushort[] pi, ulong[] pivots)
  {
    ulong[] numArray1 = new ulong[64 /*0x40*/];
    int[] numArray2 = new int[32 /*0x20*/];
    ulong num1 = 1;
    byte[] numArray3 = new byte[9];
    int num2 = this.PK_NROWS - 32 /*0x20*/;
    int offset = num2 / 8;
    int num3 = num2 % 8;
    if (this.usePadding)
    {
      for (int index1 = 0; index1 < 32 /*0x20*/; ++index1)
      {
        for (int index2 = 0; index2 < 9; ++index2)
          numArray3[index2] = mat[num2 + index1][offset + index2];
        for (int index3 = 0; index3 < 8; ++index3)
          numArray3[index3] = (byte) (((int) numArray3[index3] & (int) byte.MaxValue) >> num3 | (int) numArray3[index3 + 1] << 8 - num3);
        numArray1[index1] = Utils.Load8(numArray3, 0);
      }
    }
    else
    {
      for (int index = 0; index < 32 /*0x20*/; ++index)
        numArray1[index] = Utils.Load8(mat[num2 + index], offset);
    }
    pivots[0] = 0UL;
    for (int index4 = 0; index4 < 32 /*0x20*/; ++index4)
    {
      ulong input = numArray1[index4];
      for (int index5 = index4 + 1; index5 < 32 /*0x20*/; ++index5)
        input |= numArray1[index5];
      if (input == 0UL)
        return -1;
      int num4 = CmceEngine<GFImpl>.Ctz(input);
      numArray2[index4] = num4;
      pivots[0] |= num1 << num4;
      for (int index6 = index4 + 1; index6 < 32 /*0x20*/; ++index6)
      {
        ulong num5 = (numArray1[index4] >> num4 & 1UL) - 1UL;
        numArray1[index4] ^= numArray1[index6] & num5;
      }
      for (int index7 = index4 + 1; index7 < 32 /*0x20*/; ++index7)
      {
        ulong num6 = (ulong) -(long) (numArray1[index7] >> num4 & 1UL);
        numArray1[index7] ^= numArray1[index4] & num6;
      }
    }
    for (int index = 0; index < 32 /*0x20*/; ++index)
    {
      for (int x = index + 1; x < 64 /*0x40*/; ++x)
      {
        ulong num7 = (ulong) ((int) pi[num2 + index] ^ (int) pi[num2 + x]) & CmceEngine<GFImpl>.SameMask64((ushort) x, (ushort) numArray2[index]);
        pi[num2 + index] ^= (ushort) num7;
        pi[num2 + x] ^= (ushort) num7;
      }
    }
    for (int index8 = 0; index8 < this.PK_NROWS; ++index8)
    {
      ulong input;
      if (this.usePadding)
      {
        for (int index9 = 0; index9 < 9; ++index9)
          numArray3[index9] = mat[index8][offset + index9];
        for (int index10 = 0; index10 < 8; ++index10)
          numArray3[index10] = (byte) (((int) numArray3[index10] & (int) byte.MaxValue) >> num3 | (int) numArray3[index10 + 1] << 8 - num3);
        input = Utils.Load8(numArray3, 0);
      }
      else
        input = Utils.Load8(mat[index8], offset);
      for (int index11 = 0; index11 < 32 /*0x20*/; ++index11)
      {
        ulong num8 = (input >> index11 ^ input >> numArray2[index11]) & 1UL;
        input = input ^ num8 << numArray2[index11] ^ num8 << index11;
      }
      if (this.usePadding)
      {
        Utils.Store8(numArray3, 0, input);
        mat[index8][offset + 8] = (byte) (((int) mat[index8][offset + 8] & (int) byte.MaxValue) >> num3 << num3 | ((int) numArray3[7] & (int) byte.MaxValue) >> 8 - num3);
        mat[index8][offset] = (byte) (((int) numArray3[0] & (int) byte.MaxValue) << num3 | ((int) mat[index8][offset] & (int) byte.MaxValue) << 8 - num3 >> 8 - num3);
        for (int index12 = 7; index12 >= 1; --index12)
          mat[index8][offset + index12] = (byte) (((int) numArray3[index12] & (int) byte.MaxValue) << num3 | ((int) numArray3[index12 - 1] & (int) byte.MaxValue) >> 8 - num3);
      }
      else
        Utils.Store8(mat[index8], offset, input);
    }
    return 0;
  }

  private static int Ctz(ulong input)
  {
    ulong num1 = 72340172838076673;
    ulong num2 = 0;
    ulong num3 = ~input;
    for (int index = 0; index < 8; ++index)
    {
      num1 &= num3 >> index;
      num2 += num1;
    }
    ulong num4 = num2 & 578721382704613384UL;
    ulong num5 = num4 | num4 >> 1;
    ulong num6 = num5 | num5 >> 2;
    ulong num7 = num2;
    ulong num8 = num2 >> 8;
    ulong num9 = num7 + (num8 & num6);
    for (int index = 2; index < 8; ++index)
    {
      num6 &= num6 >> 8;
      num8 >>= 8;
      num9 += num8 & num6;
    }
    return (int) num9 & (int) byte.MaxValue;
  }

  private static ulong SameMask64(ushort x, ushort y)
  {
    return (ulong) -(long) ((ulong) ((int) x ^ (int) y) - 1UL >> 63 /*0x3F*/);
  }

  private static byte SameMask32(short x, short y)
  {
    return (byte) (-(uint) (((int) x ^ (int) y) - 1 >>> 31 /*0x1F*/) & (uint) byte.MaxValue);
  }

  private static void Layer(ushort[] p, byte[] output, int ptrIndex, int s, int n)
  {
    int num1 = 1 << s;
    int num2 = 0;
    for (int index1 = 0; index1 < n; index1 += num1 * 2)
    {
      for (int index2 = 0; index2 < num1; ++index2)
      {
        int num3 = ((int) p[index1 + index2] ^ (int) p[index1 + index2 + num1]) & -((int) output[ptrIndex + (num2 >> 3)] >> (num2 & 7) & 1);
        p[index1 + index2] ^= (ushort) num3;
        p[index1 + index2 + num1] ^= (ushort) num3;
        ++num2;
      }
    }
  }

  private static void ControlBitsFromPermutation(byte[] output, ushort[] pi, long w, long n)
  {
    int[] temp = new int[(int) (2L * n)];
    ushort[] p = new ushort[(int) n];
    ushort num;
    do
    {
      for (int index = 0; (long) index < ((2L * w - 1L) * n / 2L + 7L) / 8L; ++index)
        output[index] = (byte) 0;
      CmceEngine<GFImpl>.CBRecursion(output, 0L, 1L, pi, 0, w, n, temp);
      for (int index = 0; (long) index < n; ++index)
        p[index] = (ushort) index;
      int ptrIndex = 0;
      for (int s = 0; (long) s < w; ++s)
      {
        CmceEngine<GFImpl>.Layer(p, output, ptrIndex, s, (int) n);
        ptrIndex += (int) n >> 4;
      }
      for (int s = (int) (w - 2L); s >= 0; --s)
      {
        CmceEngine<GFImpl>.Layer(p, output, ptrIndex, s, (int) n);
        ptrIndex += (int) n >> 4;
      }
      num = (ushort) 0;
      for (int index = 0; (long) index < n; ++index)
        num |= (ushort) ((uint) pi[index] ^ (uint) p[index]);
    }
    while (num != (ushort) 0);
  }

  private static short GetQShort(int[] temp, int q_index)
  {
    int index = q_index / 2;
    return q_index % 2 == 0 ? (short) temp[index] : (short) (((long) temp[index] & 4294901760L) >> 16 /*0x10*/);
  }

  private static void CBRecursion(
    byte[] output,
    long pos,
    long step,
    ushort[] pi,
    int qIndex,
    long w,
    long n,
    int[] temp)
  {
    if (w == 1L)
    {
      output[(int) (pos >> 3)] ^= (byte) ((uint) CmceEngine<GFImpl>.GetQShort(temp, qIndex) << (int) (pos & 7L));
    }
    else
    {
      if (pi != null)
      {
        for (long index = 0; index < n; ++index)
          temp[(int) index] = ((int) pi[(int) index] ^ 1) << 16 /*0x10*/ | (int) pi[(int) (index ^ 1L)];
      }
      else
      {
        for (long index = 0; index < n; ++index)
        {
          ushort qshort1 = (ushort) CmceEngine<GFImpl>.GetQShort(temp, (int) ((long) qIndex + index));
          ushort qshort2 = (ushort) CmceEngine<GFImpl>.GetQShort(temp, (int) ((long) qIndex + (index ^ 1L)));
          temp[(int) index] = ((int) qshort1 ^ 1) << 16 /*0x10*/ | (int) qshort2;
        }
      }
      CmceEngine<GFImpl>.Sort32(temp, 0, (int) n);
      for (long index = 0; index < n; ++index)
      {
        int num1 = temp[(int) index] & (int) ushort.MaxValue;
        int num2 = num1;
        if (index < (long) num2)
          num2 = (int) index;
        temp[(int) (n + index)] = num1 << 16 /*0x10*/ | num2;
      }
      for (long index = 0; index < n; ++index)
        temp[(int) index] = (int) ((long) (uint) (temp[(int) index] << 16 /*0x10*/) | index);
      CmceEngine<GFImpl>.Sort32(temp, 0, (int) n);
      for (long index = 0; index < n; ++index)
        temp[(int) index] = (temp[(int) index] << 16 /*0x10*/) + (temp[(int) (n + index)] >> 16 /*0x10*/);
      CmceEngine<GFImpl>.Sort32(temp, 0, (int) n);
      if (w <= 10L)
      {
        for (long index = 0; index < n; ++index)
          temp[(int) (n + index)] = (temp[(int) index] & (int) ushort.MaxValue) << 10 | temp[(int) (n + index)] & 1023 /*0x03FF*/;
        for (long index1 = 1; index1 < w - 1L; ++index1)
        {
          for (long index2 = 0; index2 < n; ++index2)
            temp[(int) index2] = (int) ((long) (uint) ((temp[(int) (n + index2)] & -1024) << 6) | index2);
          CmceEngine<GFImpl>.Sort32(temp, 0, (int) n);
          for (long index3 = 0; index3 < n; ++index3)
            temp[(int) index3] = temp[(int) index3] << 20 | temp[(int) (n + index3)];
          CmceEngine<GFImpl>.Sort32(temp, 0, (int) n);
          for (long index4 = 0; index4 < n; ++index4)
          {
            int num3 = temp[(int) index4] & 1048575 /*0x0FFFFF*/;
            int num4 = temp[(int) index4] & 1047552 | temp[(int) (n + index4)] & 1023 /*0x03FF*/;
            if (num3 < num4)
              num4 = num3;
            temp[(int) (n + index4)] = num4;
          }
        }
        for (long index = 0; index < n; ++index)
          temp[(int) (n + index)] &= 1023 /*0x03FF*/;
      }
      else
      {
        for (long index = 0; index < n; ++index)
          temp[(int) (n + index)] = temp[(int) index] << 16 /*0x10*/ | temp[(int) (n + index)] & (int) ushort.MaxValue;
        for (long index5 = 1; index5 < w - 1L; ++index5)
        {
          for (long index6 = 0; index6 < n; ++index6)
            temp[(int) index6] = (int) ((long) (uint) (temp[(int) (n + index6)] & -65536) | index6);
          CmceEngine<GFImpl>.Sort32(temp, 0, (int) n);
          for (long index7 = 0; index7 < n; ++index7)
            temp[(int) index7] = temp[(int) index7] << 16 /*0x10*/ | temp[(int) (n + index7)] & (int) ushort.MaxValue;
          if (index5 < w - 2L)
          {
            for (long index8 = 0; index8 < n; ++index8)
              temp[(int) (n + index8)] = temp[(int) index8] & -65536 | temp[(int) (n + index8)] >> 16 /*0x10*/;
            CmceEngine<GFImpl>.Sort32(temp, (int) n, (int) (n * 2L));
            for (long index9 = 0; index9 < n; ++index9)
              temp[(int) (n + index9)] = temp[(int) (n + index9)] << 16 /*0x10*/ | temp[(int) index9] & (int) ushort.MaxValue;
          }
          CmceEngine<GFImpl>.Sort32(temp, 0, (int) n);
          for (long index10 = 0; index10 < n; ++index10)
          {
            int num = temp[(int) (n + index10)] & -65536 | temp[(int) index10] & (int) ushort.MaxValue;
            if (num < temp[(int) (n + index10)])
              temp[(int) (n + index10)] = num;
          }
        }
        for (long index = 0; index < n; ++index)
          temp[(int) (n + index)] &= (int) ushort.MaxValue;
      }
      if (pi != null)
      {
        for (long index = 0; index < n; ++index)
          temp[(int) index] = (int) ((long) ((int) pi[(int) index] << 16 /*0x10*/) + index);
      }
      else
      {
        for (long index = 0; index < n; ++index)
          temp[(int) index] = (int) ((long) ((int) CmceEngine<GFImpl>.GetQShort(temp, (int) ((long) qIndex + index)) << 16 /*0x10*/) + index);
      }
      CmceEngine<GFImpl>.Sort32(temp, 0, (int) n);
      for (long index11 = 0; index11 < n / 2L; ++index11)
      {
        long index12 = 2L * index11;
        int num5 = temp[(int) (n + index12)] & 1;
        int num6 = (int) (index12 + (long) num5);
        int num7 = num6 ^ 1;
        output[(int) (pos >> 3)] ^= (byte) ((uint) num5 << (int) (pos & 7L));
        pos += step;
        temp[(int) (n + index12)] = temp[(int) index12] << 16 /*0x10*/ | num6;
        temp[(int) (n + index12 + 1L)] = temp[(int) (index12 + 1L)] << 16 /*0x10*/ | num7;
      }
      CmceEngine<GFImpl>.Sort32(temp, (int) n, (int) (n * 2L));
      pos += (2L * w - 3L) * step * (n / 2L);
      for (long index13 = 0; index13 < n / 2L; ++index13)
      {
        long index14 = 2L * index13;
        int num8 = temp[(int) (n + index14)] & 1;
        int num9 = (int) (index14 + (long) num8);
        int num10 = num9 ^ 1;
        output[(int) (pos >> 3)] ^= (byte) ((uint) num8 << (int) (pos & 7L));
        pos += step;
        temp[(int) index14] = num9 << 16 /*0x10*/ | temp[(int) (n + index14)] & (int) ushort.MaxValue;
        temp[(int) (index14 + 1L)] = num10 << 16 /*0x10*/ | temp[(int) (n + index14 + 1L)] & (int) ushort.MaxValue;
      }
      CmceEngine<GFImpl>.Sort32(temp, 0, (int) n);
      pos -= (2L * w - 2L) * step * (n / 2L);
      short[] numArray = new short[(int) n * 4];
      for (long index = 0; index < n * 2L; ++index)
      {
        numArray[(int) (index * 2L)] = (short) temp[(int) index];
        numArray[(int) (index * 2L + 1L)] = (short) (((long) temp[(int) index] & 4294901760L) >> 16 /*0x10*/);
      }
      for (long index = 0; index < n / 2L; ++index)
      {
        numArray[(int) index] = (short) ((temp[(int) (2L * index)] & (int) ushort.MaxValue) >> 1);
        numArray[(int) (index + n / 2L)] = (short) ((temp[(int) (2L * index + 1L)] & (int) ushort.MaxValue) >> 1);
      }
      for (long index = 0; index < n / 2L; ++index)
        temp[(int) (n + n / 4L + index)] = (int) numArray[(int) (index * 2L + 1L)] << 16 /*0x10*/ | (int) numArray[(int) (index * 2L)];
      CmceEngine<GFImpl>.CBRecursion(output, pos, step * 2L, (ushort[]) null, (int) (n + n / 4L) * 2, w - 1L, n / 2L, temp);
      CmceEngine<GFImpl>.CBRecursion(output, pos + step, step * 2L, (ushort[]) null, (int) ((n + n / 4L) * 2L + n / 2L), w - 1L, n / 2L, temp);
    }
  }

  private int PKGen(byte[] pk, byte[] sk, uint[] perm, ushort[] pi, ulong[] pivots)
  {
    ushort[] f = new ushort[this.SYS_T + 1];
    f[this.SYS_T] = (ushort) 1;
    for (int index = 0; index < this.SYS_T; ++index)
      f[index] = Utils.LoadGF(sk, 40 + index * 2, this.GFMASK);
    long[] temp = new long[1 << this.GFBITS];
    for (int index = 0; index < 1 << this.GFBITS; ++index)
      temp[index] = (long) perm[index] << 31 /*0x1F*/ | (long) (uint) index;
    CmceEngine<GFImpl>.Sort64(temp, 0, temp.Length);
    for (int index = 1; index < 1 << this.GFBITS; ++index)
    {
      if (temp[index - 1] >> 31 /*0x1F*/ == temp[index] >> 31 /*0x1F*/)
        return -1;
    }
    ushort[] L = new ushort[this.SYS_N];
    for (int index = 0; index < 1 << this.GFBITS; ++index)
      pi[index] = (ushort) ((ulong) temp[index] & (ulong) this.GFMASK);
    for (int index = 0; index < this.SYS_N; ++index)
      L[index] = Utils.Bitrev(pi[index], this.GFBITS);
    ushort[] output = new ushort[this.SYS_N];
    this.Root(output, f, L);
    GFImpl gf;
    for (int index1 = 0; index1 < this.SYS_N; ++index1)
    {
      ushort[] numArray = output;
      int index2 = index1;
      gf = this.gf;
      int num = (int) gf.GFInv(output[index1]);
      numArray[index2] = (ushort) num;
    }
    byte[][] mat = new byte[this.PK_NROWS][];
    for (int index = 0; index < this.PK_NROWS; ++index)
      mat[index] = new byte[this.SYS_N / 8];
    for (int index3 = 0; index3 < this.SYS_T; ++index3)
    {
      for (int index4 = 0; index4 < this.SYS_N; index4 += 8)
      {
        for (int index5 = 0; index5 < this.GFBITS; ++index5)
        {
          byte num = (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((uint) (byte) ((int) output[index4 + 7] >> index5 & 1) << 1) | (uint) (byte) ((int) output[index4 + 6] >> index5 & 1)) << 1) | (uint) (byte) ((int) output[index4 + 5] >> index5 & 1)) << 1) | (uint) (byte) ((int) output[index4 + 4] >> index5 & 1)) << 1) | (uint) (byte) ((int) output[index4 + 3] >> index5 & 1)) << 1) | (uint) (byte) ((int) output[index4 + 2] >> index5 & 1)) << 1) | (uint) (byte) ((int) output[index4 + 1] >> index5 & 1)) << 1) | (uint) (byte) ((int) output[index4] >> index5 & 1));
          mat[index3 * this.GFBITS + index5][index4 / 8] = num;
        }
      }
      for (int index6 = 0; index6 < this.SYS_N; ++index6)
      {
        ushort[] numArray = output;
        int index7 = index6;
        gf = this.gf;
        int num = (int) gf.GFMul(output[index6], L[index6]);
        numArray[index7] = (ushort) num;
      }
    }
    for (int index8 = 0; index8 < this.PK_NROWS; ++index8)
    {
      int index9 = index8 >> 3;
      int num1 = index8 & 7;
      if (this.usePivots && index8 == this.PK_NROWS - 32 /*0x20*/ && this.MovColumns(mat, pi, pivots) != 0)
        return -1;
      byte[] numArray1 = mat[index8];
      for (int index10 = index8 + 1; index10 < this.PK_NROWS; ++index10)
      {
        byte[] numArray2 = mat[index10];
        byte num2 = (byte) ((uint) (byte) ((uint) (byte) ((uint) numArray1[index9] ^ (uint) numArray2[index9]) >> num1) & 1U);
        int index11 = 0;
        byte num3 = -num2;
        for (int index12 = this.SYS_N / 8 - 4; index11 <= index12; index11 += 4)
        {
          numArray1[index11] ^= (byte) ((uint) numArray2[index11] & (uint) num3);
          numArray1[index11 + 1] ^= (byte) ((uint) numArray2[index11 + 1] & (uint) num3);
          numArray1[index11 + 2] ^= (byte) ((uint) numArray2[index11 + 2] & (uint) num3);
          numArray1[index11 + 3] ^= (byte) ((uint) numArray2[index11 + 3] & (uint) num3);
        }
        byte num4 = -num2;
        for (; index11 < this.SYS_N / 8; ++index11)
          numArray1[index11] ^= (byte) ((uint) numArray2[index11] & (uint) num4);
      }
      if (((int) numArray1[index9] >> num1 & 1) == 0)
        return -1;
      for (int index13 = 0; index13 < this.PK_NROWS; ++index13)
      {
        if (index13 != index8)
        {
          byte[] numArray3 = mat[index13];
          byte num5 = (byte) ((uint) (byte) ((uint) numArray3[index9] >> num1) & 1U);
          int index14 = 0;
          byte num6 = -num5;
          for (int index15 = this.SYS_N / 8 - 4; index14 <= index15; index14 += 4)
          {
            numArray3[index14] ^= (byte) ((uint) numArray1[index14] & (uint) num6);
            numArray3[index14 + 1] ^= (byte) ((uint) numArray1[index14 + 1] & (uint) num6);
            numArray3[index14 + 2] ^= (byte) ((uint) numArray1[index14 + 2] & (uint) num6);
            numArray3[index14 + 3] ^= (byte) ((uint) numArray1[index14 + 3] & (uint) num6);
          }
          byte num7 = -num5;
          for (; index14 < this.SYS_N / 8; ++index14)
            numArray3[index14] ^= (byte) ((uint) numArray1[index14] & (uint) num7);
        }
      }
    }
    if (pk != null)
    {
      if (this.usePadding)
      {
        int num8 = 0;
        int num9 = this.PK_NROWS % 8;
        for (int index16 = 0; index16 < this.PK_NROWS; ++index16)
        {
          byte[] numArray = mat[index16];
          int index17;
          for (index17 = (this.PK_NROWS - 1) / 8; index17 < this.SYS_N / 8 - 1; ++index17)
            pk[num8++] = (byte) (((int) numArray[index17] & (int) byte.MaxValue) >> num9 | (int) numArray[index17 + 1] << 8 - num9);
          pk[num8++] = (byte) (((int) numArray[index17] & (int) byte.MaxValue) >> num9);
        }
      }
      else
      {
        int length = (this.SYS_N - this.PK_NROWS + 7) / 8;
        for (int index = 0; index < this.PK_NROWS; ++index)
          Array.Copy((Array) mat[index], this.PK_NROWS / 8, (Array) pk, length * index, length);
      }
    }
    return 0;
  }

  private ushort Eval(ushort[] f, ushort a)
  {
    ushort left = f[this.SYS_T];
    for (int index = this.SYS_T - 1; index >= 0; --index)
      left = (ushort) ((uint) this.gf.GFMul(left, a) ^ (uint) f[index]);
    return left;
  }

  private void Root(ushort[] output, ushort[] f, ushort[] L)
  {
    for (int index = 0; index < this.SYS_N; ++index)
      output[index] = this.Eval(f, L[index]);
  }

  private int GenerateIrrPoly(ushort[] field)
  {
    ushort[][] numArray = new ushort[this.SYS_T + 1][];
    numArray[0] = new ushort[this.SYS_T];
    numArray[0][0] = (ushort) 1;
    numArray[1] = new ushort[this.SYS_T];
    Array.Copy((Array) field, 0, (Array) numArray[1], 0, this.SYS_T);
    uint[] temp = new uint[this.SYS_T * 2 - 1];
    int index1;
    for (index1 = 2; index1 < this.SYS_T; index1 += 2)
    {
      numArray[index1] = new ushort[this.SYS_T];
      this.gf.GFSqrPoly(this.SYS_T, this.poly, numArray[index1], numArray[index1 >> 1], temp);
      numArray[index1 + 1] = new ushort[this.SYS_T];
      this.gf.GFMulPoly(this.SYS_T, this.poly, numArray[index1 + 1], numArray[index1], field, temp);
    }
    if (index1 == this.SYS_T)
    {
      numArray[index1] = new ushort[this.SYS_T];
      this.gf.GFSqrPoly(this.SYS_T, this.poly, numArray[index1], numArray[index1 >> 1], temp);
    }
    for (int index2 = 0; index2 < this.SYS_T; ++index2)
    {
      for (int index3 = index2 + 1; index3 < this.SYS_T; ++index3)
      {
        ushort num = this.gf.GFIsZero(numArray[index2][index2]);
        for (int index4 = index2; index4 < this.SYS_T + 1; ++index4)
          numArray[index4][index2] ^= (ushort) ((uint) numArray[index4][index3] & (uint) num);
      }
      if (numArray[index2][index2] == (ushort) 0)
        return -1;
      ushort right1 = this.gf.GFInv(numArray[index2][index2]);
      for (int index5 = index2; index5 < this.SYS_T + 1; ++index5)
        numArray[index5][index2] = this.gf.GFMul(numArray[index5][index2], right1);
      for (int index6 = 0; index6 < this.SYS_T; ++index6)
      {
        if (index6 != index2)
        {
          ushort right2 = numArray[index2][index6];
          for (int index7 = index2; index7 <= this.SYS_T; ++index7)
            numArray[index7][index6] ^= this.gf.GFMul(numArray[index7][index2], right2);
        }
      }
    }
    Array.Copy((Array) numArray[this.SYS_T], (Array) field, this.SYS_T);
    return 0;
  }

  private int CheckPKPadding(byte[] pk)
  {
    byte num = 0;
    for (int index = 0; index < this.PK_NROWS; ++index)
      num |= pk[index * this.PK_ROW_BYTES + this.PK_ROW_BYTES - 1];
    return (int) (byte) (((int) (byte) ((uint) (byte) (((int) num & (int) byte.MaxValue) >> this.PK_NCOLS % 8) - 1U) & (int) byte.MaxValue) >> 7) - 1;
  }

  private int CheckCPadding(byte[] c)
  {
    return (int) (byte) (((int) (byte) ((uint) (byte) (((int) c[this.SYND_BYTES - 1] & (int) byte.MaxValue) >> this.PK_NROWS % 8) - 1U) & (int) byte.MaxValue) >> 7) - 1;
  }

  private static void Sort32(int[] temp, int from, int to)
  {
    int num1 = to - from;
    if (num1 < 2)
      return;
    int num2 = 1;
    while (num2 < num1 - num2)
      num2 += num2;
    for (int index1 = num2; index1 > 0; index1 >>= 1)
    {
      for (int index2 = 0; index2 < num1 - index1; ++index2)
      {
        if ((index2 & index1) == 0)
        {
          int num3 = temp[from + index2 + index1] ^ temp[from + index2];
          int num4 = temp[from + index2 + index1] - temp[from + index2];
          int num5 = (num4 ^ num3 & (num4 ^ temp[from + index2 + index1])) >> 31 /*0x1F*/ & num3;
          temp[from + index2] ^= num5;
          temp[from + index2 + index1] ^= num5;
        }
      }
      for (int index3 = num2; index3 > index1; index3 >>= 1)
      {
        for (int index4 = 0; index4 < num1 - index3; ++index4)
        {
          if ((index4 & index1) == 0)
          {
            int num6 = temp[from + index4 + index1];
            for (int index5 = index3; index5 > index1; index5 >>= 1)
            {
              int num7 = temp[from + index4 + index5] ^ num6;
              int num8 = temp[from + index4 + index5] - num6;
              int num9 = (num8 ^ num7 & (num8 ^ temp[from + index4 + index5])) >> 31 /*0x1F*/ & num7;
              num6 ^= num9;
              temp[from + index4 + index5] ^= num9;
            }
            temp[from + index4 + index1] = num6;
          }
        }
      }
    }
  }

  private static void Sort64(long[] temp, int from, int to)
  {
    int num1 = to - from;
    if (num1 < 2)
      return;
    int num2 = 1;
    while (num2 < num1 - num2)
      num2 += num2;
    for (int index1 = num2; index1 > 0; index1 >>= 1)
    {
      for (int index2 = 0; index2 < num1 - index1; ++index2)
      {
        if ((index2 & index1) == 0)
        {
          long num3 = temp[from + index2 + index1] - temp[from + index2] >> 63 /*0x3F*/ & (temp[from + index2] ^ temp[from + index2 + index1]);
          temp[from + index2] ^= num3;
          temp[from + index2 + index1] ^= num3;
        }
      }
      for (int index3 = num2; index3 > index1; index3 >>= 1)
      {
        for (int index4 = 0; index4 < num1 - index3; ++index4)
        {
          if ((index4 & index1) == 0)
          {
            long num4 = temp[from + index4 + index1];
            for (int index5 = index3; index5 > index1; index5 >>= 1)
            {
              long num5 = temp[from + index4 + index5] - num4 >> 63 /*0x3F*/ & (num4 ^ temp[from + index4 + index5]);
              num4 ^= num5;
              temp[from + index4 + index5] ^= num5;
            }
            temp[from + index4 + index1] = num4;
          }
        }
      }
    }
  }
}
