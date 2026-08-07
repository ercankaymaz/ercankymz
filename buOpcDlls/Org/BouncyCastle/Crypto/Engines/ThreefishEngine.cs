// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.ThreefishEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class ThreefishEngine : IBlockCipher
{
  public const int BLOCKSIZE_256 = 256 /*0x0100*/;
  public const int BLOCKSIZE_512 = 512 /*0x0200*/;
  public const int BLOCKSIZE_1024 = 1024 /*0x0400*/;
  private const int TWEAK_SIZE_BYTES = 16 /*0x10*/;
  private const int TWEAK_SIZE_WORDS = 2;
  private const int ROUNDS_256 = 72;
  private const int ROUNDS_512 = 72;
  private const int ROUNDS_1024 = 80 /*0x50*/;
  private const int MAX_ROUNDS = 80 /*0x50*/;
  private const ulong C_240 = 2004413935125273122;
  private static readonly int[] MOD9 = new int[80 /*0x50*/];
  private static readonly int[] MOD17 = new int[ThreefishEngine.MOD9.Length];
  private static readonly int[] MOD5 = new int[ThreefishEngine.MOD9.Length];
  private static readonly int[] MOD3 = new int[ThreefishEngine.MOD9.Length];
  private readonly int blocksizeBytes;
  private readonly int blocksizeWords;
  private readonly ulong[] currentBlock;
  private readonly ulong[] t = new ulong[5];
  private readonly ulong[] kw;
  private readonly ThreefishEngine.ThreefishCipher cipher;
  private bool forEncryption;

  static ThreefishEngine()
  {
    for (int index = 0; index < ThreefishEngine.MOD9.Length; ++index)
    {
      ThreefishEngine.MOD17[index] = index % 17;
      ThreefishEngine.MOD9[index] = index % 9;
      ThreefishEngine.MOD5[index] = index % 5;
      ThreefishEngine.MOD3[index] = index % 3;
    }
  }

  public ThreefishEngine(int blocksizeBits)
  {
    this.blocksizeBytes = blocksizeBits / 8;
    this.blocksizeWords = this.blocksizeBytes / 8;
    this.currentBlock = new ulong[this.blocksizeWords];
    this.kw = new ulong[2 * this.blocksizeWords + 1];
    if (blocksizeBits != 256 /*0x0100*/)
    {
      if (blocksizeBits != 512 /*0x0200*/)
      {
        if (blocksizeBits != 1024 /*0x0400*/)
          throw new ArgumentException("Invalid blocksize - Threefish is defined with block size of 256, 512, or 1024 bits");
        this.cipher = (ThreefishEngine.ThreefishCipher) new ThreefishEngine.Threefish1024Cipher(this.kw, this.t);
      }
      else
        this.cipher = (ThreefishEngine.ThreefishCipher) new ThreefishEngine.Threefish512Cipher(this.kw, this.t);
    }
    else
      this.cipher = (ThreefishEngine.ThreefishCipher) new ThreefishEngine.Threefish256Cipher(this.kw, this.t);
  }

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    byte[] key;
    byte[] bs;
    switch (parameters)
    {
      case TweakableBlockCipherParameters _:
        TweakableBlockCipherParameters cipherParameters = (TweakableBlockCipherParameters) parameters;
        key = cipherParameters.Key.GetKey();
        bs = cipherParameters.Tweak;
        break;
      case KeyParameter _:
        key = ((KeyParameter) parameters).GetKey();
        bs = (byte[]) null;
        break;
      default:
        throw new ArgumentException("Invalid parameter passed to Threefish init - " + Platform.GetTypeName((object) parameters));
    }
    ulong[] numArray1 = (ulong[]) null;
    ulong[] numArray2 = (ulong[]) null;
    if (key != null)
    {
      if (key.Length != this.blocksizeBytes)
        throw new ArgumentException($"Threefish key must be same size as block ({this.blocksizeBytes.ToString()} bytes)");
      numArray1 = new ulong[this.blocksizeWords];
      Pack.LE_To_UInt64(key, 0, numArray1);
    }
    if (bs != null)
    {
      if (bs.Length != 16 /*0x10*/)
        throw new ArgumentException($"Threefish tweak must be {16 /*0x10*/.ToString()} bytes");
      numArray2 = new ulong[2];
      Pack.LE_To_UInt64(bs, 0, numArray2);
    }
    this.Init(forEncryption, numArray1, numArray2);
  }

  internal void Init(bool forEncryption, ulong[] key, ulong[] tweak)
  {
    this.forEncryption = forEncryption;
    if (key != null)
      this.SetKey(key);
    if (tweak == null)
      return;
    this.SetTweak(tweak);
  }

  private void SetKey(ulong[] key)
  {
    if (key.Length != this.blocksizeWords)
      throw new ArgumentException($"Threefish key must be same size as block ({this.blocksizeWords.ToString()} words)");
    ulong num = 2004413935125273122;
    for (int index = 0; index < this.blocksizeWords; ++index)
    {
      this.kw[index] = key[index];
      num ^= this.kw[index];
    }
    this.kw[this.blocksizeWords] = num;
    Array.Copy((Array) this.kw, 0, (Array) this.kw, this.blocksizeWords + 1, this.blocksizeWords);
  }

  private void SetTweak(ulong[] tweak)
  {
    this.t[0] = tweak.Length == 2 ? tweak[0] : throw new ArgumentException($"Tweak must be {2.ToString()} words.");
    this.t[1] = tweak[1];
    this.t[2] = this.t[0] ^ this.t[1];
    this.t[3] = this.t[0];
    this.t[4] = this.t[1];
  }

  public virtual string AlgorithmName => "Threefish-" + (this.blocksizeBytes * 8).ToString();

  public virtual int GetBlockSize() => this.blocksizeBytes;

  public virtual int ProcessBlock(byte[] inBytes, int inOff, byte[] outBytes, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(inBytes, inOff, this.blocksizeBytes, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, this.blocksizeBytes, "output buffer too short");
    Pack.LE_To_UInt64(inBytes, inOff, this.currentBlock);
    this.ProcessBlock(this.currentBlock, this.currentBlock);
    Pack.UInt64_To_LE(this.currentBlock, outBytes, outOff);
    return this.blocksizeBytes;
  }

  internal int ProcessBlock(ulong[] inWords, ulong[] outWords)
  {
    if (this.kw[this.blocksizeWords] == 0UL)
      throw new InvalidOperationException("Threefish engine not initialised");
    if (inWords.Length != this.blocksizeWords)
      throw new DataLengthException("input buffer too short");
    if (outWords.Length != this.blocksizeWords)
      throw new OutputLengthException("output buffer too short");
    if (this.forEncryption)
      this.cipher.EncryptBlock(inWords, outWords);
    else
      this.cipher.DecryptBlock(inWords, outWords);
    return this.blocksizeWords;
  }

  private static ulong RotlXor(ulong x, int n, ulong xor) => (x << n | x >> 64 /*0x40*/ - n) ^ xor;

  private static ulong XorRotr(ulong x, int n, ulong xor)
  {
    ulong num = x ^ xor;
    return num >> n | num << 64 /*0x40*/ - n;
  }

  private abstract class ThreefishCipher
  {
    protected readonly ulong[] t;
    protected readonly ulong[] kw;

    protected ThreefishCipher(ulong[] kw, ulong[] t)
    {
      this.kw = kw;
      this.t = t;
    }

    internal abstract void EncryptBlock(ulong[] block, ulong[] outWords);

    internal abstract void DecryptBlock(ulong[] block, ulong[] outWords);
  }

  private sealed class Threefish256Cipher(ulong[] kw, ulong[] t) : ThreefishEngine.ThreefishCipher(kw, t)
  {
    private const int ROTATION_0_0 = 14;
    private const int ROTATION_0_1 = 16 /*0x10*/;
    private const int ROTATION_1_0 = 52;
    private const int ROTATION_1_1 = 57;
    private const int ROTATION_2_0 = 23;
    private const int ROTATION_2_1 = 40;
    private const int ROTATION_3_0 = 5;
    private const int ROTATION_3_1 = 37;
    private const int ROTATION_4_0 = 25;
    private const int ROTATION_4_1 = 33;
    private const int ROTATION_5_0 = 46;
    private const int ROTATION_5_1 = 12;
    private const int ROTATION_6_0 = 58;
    private const int ROTATION_6_1 = 22;
    private const int ROTATION_7_0 = 32 /*0x20*/;
    private const int ROTATION_7_1 = 32 /*0x20*/;

    internal override void EncryptBlock(ulong[] block, ulong[] outWords)
    {
      ulong[] kw = this.kw;
      ulong[] t = this.t;
      int[] moD5 = ThreefishEngine.MOD5;
      int[] moD3 = ThreefishEngine.MOD3;
      if (kw.Length != 9)
        throw new ArgumentException();
      if (t.Length != 5)
        throw new ArgumentException();
      ulong num1 = block[0];
      ulong num2 = block[1];
      ulong num3 = block[2];
      ulong num4 = block[3];
      ulong num5 = num1 + kw[0];
      ulong x1 = num2 + (kw[1] + t[0]);
      ulong num6 = num3 + (kw[2] + t[1]);
      ulong x2 = num4 + kw[3];
      for (int index1 = 1; index1 < 18; index1 += 2)
      {
        int index2 = moD5[index1];
        int index3 = moD3[index1];
        ulong num7;
        ulong x3 = ThreefishEngine.RotlXor(x1, 14, num7 = num5 + x1);
        ulong num8;
        ulong x4 = ThreefishEngine.RotlXor(x2, 16 /*0x10*/, num8 = num6 + x2);
        ulong num9;
        ulong x5 = ThreefishEngine.RotlXor(x4, 52, num9 = num7 + x4);
        ulong num10;
        ulong x6 = ThreefishEngine.RotlXor(x3, 57, num10 = num8 + x3);
        ulong num11;
        ulong x7 = ThreefishEngine.RotlXor(x6, 23, num11 = num9 + x6);
        ulong num12;
        ulong x8 = ThreefishEngine.RotlXor(x5, 40, num12 = num10 + x5);
        ulong num13;
        ulong num14 = ThreefishEngine.RotlXor(x8, 5, num13 = num11 + x8);
        ulong num15;
        ulong num16 = ThreefishEngine.RotlXor(x7, 37, num15 = num12 + x7);
        ulong num17 = num13 + kw[index2];
        ulong x9 = num16 + (kw[index2 + 1] + t[index3]);
        ulong num18 = num15 + (kw[index2 + 2] + t[index3 + 1]);
        ulong x10 = num14 + (kw[index2 + 3] + (ulong) (uint) index1);
        ulong num19;
        ulong x11 = ThreefishEngine.RotlXor(x9, 25, num19 = num17 + x9);
        ulong num20;
        ulong x12 = ThreefishEngine.RotlXor(x10, 33, num20 = num18 + x10);
        ulong num21;
        ulong x13 = ThreefishEngine.RotlXor(x12, 46, num21 = num19 + x12);
        ulong num22;
        ulong x14 = ThreefishEngine.RotlXor(x11, 12, num22 = num20 + x11);
        ulong num23;
        ulong x15 = ThreefishEngine.RotlXor(x14, 58, num23 = num21 + x14);
        ulong num24;
        ulong x16 = ThreefishEngine.RotlXor(x13, 22, num24 = num22 + x13);
        ulong num25;
        ulong num26 = ThreefishEngine.RotlXor(x16, 32 /*0x20*/, num25 = num23 + x16);
        ulong num27;
        ulong num28 = ThreefishEngine.RotlXor(x15, 32 /*0x20*/, num27 = num24 + x15);
        num5 = num25 + kw[index2 + 1];
        x1 = num28 + (kw[index2 + 2] + t[index3 + 1]);
        num6 = num27 + (kw[index2 + 3] + t[index3 + 2]);
        x2 = num26 + (ulong) ((long) kw[index2 + 4] + (long) (uint) index1 + 1L);
      }
      outWords[0] = num5;
      outWords[1] = x1;
      outWords[2] = num6;
      outWords[3] = x2;
    }

    internal override void DecryptBlock(ulong[] block, ulong[] state)
    {
      ulong[] kw = this.kw;
      ulong[] t = this.t;
      int[] moD5 = ThreefishEngine.MOD5;
      int[] moD3 = ThreefishEngine.MOD3;
      if (kw.Length != 9)
        throw new ArgumentException();
      if (t.Length != 5)
        throw new ArgumentException();
      ulong num1 = block[0];
      ulong num2 = block[1];
      ulong num3 = block[2];
      ulong num4 = block[3];
      for (int index1 = 17; index1 >= 1; index1 -= 2)
      {
        int index2 = moD5[index1];
        int index3 = moD3[index1];
        ulong xor1 = num1 - kw[index2 + 1];
        ulong x1 = num2 - (kw[index2 + 2] + t[index3 + 1]);
        ulong xor2 = num3 - (kw[index2 + 3] + t[index3 + 2]);
        ulong x2 = ThreefishEngine.XorRotr(num4 - (ulong) ((long) kw[index2 + 4] + (long) (uint) index1 + 1L), 32 /*0x20*/, xor1);
        ulong xor3 = xor1 - x2;
        ulong x3 = ThreefishEngine.XorRotr(x1, 32 /*0x20*/, xor2);
        ulong xor4 = xor2 - x3;
        ulong x4 = ThreefishEngine.XorRotr(x3, 58, xor3);
        ulong xor5 = xor3 - x4;
        ulong x5 = ThreefishEngine.XorRotr(x2, 22, xor4);
        ulong xor6 = xor4 - x5;
        ulong x6 = ThreefishEngine.XorRotr(x5, 46, xor5);
        ulong xor7 = xor5 - x6;
        ulong x7 = ThreefishEngine.XorRotr(x4, 12, xor6);
        ulong xor8 = xor6 - x7;
        ulong num5 = ThreefishEngine.XorRotr(x7, 25, xor7);
        ulong num6 = xor7 - num5;
        ulong num7 = ThreefishEngine.XorRotr(x6, 33, xor8);
        ulong num8 = xor8 - num7;
        ulong xor9 = num6 - kw[index2];
        ulong x8 = num5 - (kw[index2 + 1] + t[index3]);
        ulong xor10 = num8 - (kw[index2 + 2] + t[index3 + 1]);
        ulong x9 = ThreefishEngine.XorRotr(num7 - (kw[index2 + 3] + (ulong) (uint) index1), 5, xor9);
        ulong xor11 = xor9 - x9;
        ulong x10 = ThreefishEngine.XorRotr(x8, 37, xor10);
        ulong xor12 = xor10 - x10;
        ulong x11 = ThreefishEngine.XorRotr(x10, 23, xor11);
        ulong xor13 = xor11 - x11;
        ulong x12 = ThreefishEngine.XorRotr(x9, 40, xor12);
        ulong xor14 = xor12 - x12;
        ulong x13 = ThreefishEngine.XorRotr(x12, 52, xor13);
        ulong xor15 = xor13 - x13;
        ulong x14 = ThreefishEngine.XorRotr(x11, 57, xor14);
        ulong xor16 = xor14 - x14;
        num2 = ThreefishEngine.XorRotr(x14, 14, xor15);
        num1 = xor15 - num2;
        num4 = ThreefishEngine.XorRotr(x13, 16 /*0x10*/, xor16);
        num3 = xor16 - num4;
      }
      ulong num9 = num1 - kw[0];
      ulong num10 = num2 - (kw[1] + t[0]);
      ulong num11 = num3 - (kw[2] + t[1]);
      ulong num12 = num4 - kw[3];
      state[0] = num9;
      state[1] = num10;
      state[2] = num11;
      state[3] = num12;
    }
  }

  private sealed class Threefish512Cipher : ThreefishEngine.ThreefishCipher
  {
    private const int ROTATION_0_0 = 46;
    private const int ROTATION_0_1 = 36;
    private const int ROTATION_0_2 = 19;
    private const int ROTATION_0_3 = 37;
    private const int ROTATION_1_0 = 33;
    private const int ROTATION_1_1 = 27;
    private const int ROTATION_1_2 = 14;
    private const int ROTATION_1_3 = 42;
    private const int ROTATION_2_0 = 17;
    private const int ROTATION_2_1 = 49;
    private const int ROTATION_2_2 = 36;
    private const int ROTATION_2_3 = 39;
    private const int ROTATION_3_0 = 44;
    private const int ROTATION_3_1 = 9;
    private const int ROTATION_3_2 = 54;
    private const int ROTATION_3_3 = 56;
    private const int ROTATION_4_0 = 39;
    private const int ROTATION_4_1 = 30;
    private const int ROTATION_4_2 = 34;
    private const int ROTATION_4_3 = 24;
    private const int ROTATION_5_0 = 13;
    private const int ROTATION_5_1 = 50;
    private const int ROTATION_5_2 = 10;
    private const int ROTATION_5_3 = 17;
    private const int ROTATION_6_0 = 25;
    private const int ROTATION_6_1 = 29;
    private const int ROTATION_6_2 = 39;
    private const int ROTATION_6_3 = 43;
    private const int ROTATION_7_0 = 8;
    private const int ROTATION_7_1 = 35;
    private const int ROTATION_7_2 = 56;
    private const int ROTATION_7_3 = 22;

    internal Threefish512Cipher(ulong[] kw, ulong[] t)
      : base(kw, t)
    {
    }

    internal override void EncryptBlock(ulong[] block, ulong[] outWords)
    {
      ulong[] kw = this.kw;
      ulong[] t = this.t;
      int[] moD9 = ThreefishEngine.MOD9;
      int[] moD3 = ThreefishEngine.MOD3;
      if (kw.Length != 17)
        throw new ArgumentException();
      if (t.Length != 5)
        throw new ArgumentException();
      ulong num1 = block[0];
      ulong num2 = block[1];
      ulong num3 = block[2];
      ulong num4 = block[3];
      ulong num5 = block[4];
      ulong num6 = block[5];
      ulong num7 = block[6];
      ulong num8 = block[7];
      ulong num9 = num1 + kw[0];
      ulong x1 = num2 + kw[1];
      ulong num10 = num3 + kw[2];
      ulong x2 = num4 + kw[3];
      ulong num11 = num5 + kw[4];
      ulong x3 = num6 + (kw[5] + t[0]);
      ulong num12 = num7 + (kw[6] + t[1]);
      ulong x4 = num8 + kw[7];
      for (int index1 = 1; index1 < 18; index1 += 2)
      {
        int index2 = moD9[index1];
        int index3 = moD3[index1];
        ulong num13;
        ulong x5 = ThreefishEngine.RotlXor(x1, 46, num13 = num9 + x1);
        ulong num14;
        ulong x6 = ThreefishEngine.RotlXor(x2, 36, num14 = num10 + x2);
        ulong num15;
        ulong x7 = ThreefishEngine.RotlXor(x3, 19, num15 = num11 + x3);
        ulong num16;
        ulong x8 = ThreefishEngine.RotlXor(x4, 37, num16 = num12 + x4);
        ulong num17;
        ulong x9 = ThreefishEngine.RotlXor(x5, 33, num17 = num14 + x5);
        ulong num18;
        ulong x10 = ThreefishEngine.RotlXor(x8, 27, num18 = num15 + x8);
        ulong num19;
        ulong x11 = ThreefishEngine.RotlXor(x7, 14, num19 = num16 + x7);
        ulong num20;
        ulong x12 = ThreefishEngine.RotlXor(x6, 42, num20 = num13 + x6);
        ulong num21;
        ulong x13 = ThreefishEngine.RotlXor(x9, 17, num21 = num18 + x9);
        ulong num22;
        ulong x14 = ThreefishEngine.RotlXor(x12, 49, num22 = num19 + x12);
        ulong num23;
        ulong x15 = ThreefishEngine.RotlXor(x11, 36, num23 = num20 + x11);
        ulong num24;
        ulong x16 = ThreefishEngine.RotlXor(x10, 39, num24 = num17 + x10);
        ulong num25;
        ulong num26 = ThreefishEngine.RotlXor(x13, 44, num25 = num22 + x13);
        ulong num27;
        ulong num28 = ThreefishEngine.RotlXor(x16, 9, num27 = num23 + x16);
        ulong num29;
        ulong num30 = ThreefishEngine.RotlXor(x15, 54, num29 = num24 + x15);
        ulong num31;
        ulong num32 = ThreefishEngine.RotlXor(x14, 56, num31 = num21 + x14);
        ulong num33 = num27 + kw[index2];
        ulong x17 = num26 + kw[index2 + 1];
        ulong num34 = num29 + kw[index2 + 2];
        ulong x18 = num32 + kw[index2 + 3];
        ulong num35 = num31 + kw[index2 + 4];
        ulong x19 = num30 + (kw[index2 + 5] + t[index3]);
        ulong num36 = num25 + (kw[index2 + 6] + t[index3 + 1]);
        ulong x20 = num28 + (kw[index2 + 7] + (ulong) (uint) index1);
        ulong num37;
        ulong x21 = ThreefishEngine.RotlXor(x17, 39, num37 = num33 + x17);
        ulong num38;
        ulong x22 = ThreefishEngine.RotlXor(x18, 30, num38 = num34 + x18);
        ulong num39;
        ulong x23 = ThreefishEngine.RotlXor(x19, 34, num39 = num35 + x19);
        ulong num40;
        ulong x24 = ThreefishEngine.RotlXor(x20, 24, num40 = num36 + x20);
        ulong num41;
        ulong x25 = ThreefishEngine.RotlXor(x21, 13, num41 = num38 + x21);
        ulong num42;
        ulong x26 = ThreefishEngine.RotlXor(x24, 50, num42 = num39 + x24);
        ulong num43;
        ulong x27 = ThreefishEngine.RotlXor(x23, 10, num43 = num40 + x23);
        ulong num44;
        ulong x28 = ThreefishEngine.RotlXor(x22, 17, num44 = num37 + x22);
        ulong num45;
        ulong x29 = ThreefishEngine.RotlXor(x25, 25, num45 = num42 + x25);
        ulong num46;
        ulong x30 = ThreefishEngine.RotlXor(x28, 29, num46 = num43 + x28);
        ulong num47;
        ulong x31 = ThreefishEngine.RotlXor(x27, 39, num47 = num44 + x27);
        ulong num48;
        ulong x32 = ThreefishEngine.RotlXor(x26, 43, num48 = num41 + x26);
        ulong num49;
        ulong num50 = ThreefishEngine.RotlXor(x29, 8, num49 = num46 + x29);
        ulong num51;
        ulong num52 = ThreefishEngine.RotlXor(x32, 35, num51 = num47 + x32);
        ulong num53;
        ulong num54 = ThreefishEngine.RotlXor(x31, 56, num53 = num48 + x31);
        ulong num55;
        ulong num56 = ThreefishEngine.RotlXor(x30, 22, num55 = num45 + x30);
        num9 = num51 + kw[index2 + 1];
        x1 = num50 + kw[index2 + 2];
        num10 = num53 + kw[index2 + 3];
        x2 = num56 + kw[index2 + 4];
        num11 = num55 + kw[index2 + 5];
        x3 = num54 + (kw[index2 + 6] + t[index3 + 1]);
        num12 = num49 + (kw[index2 + 7] + t[index3 + 2]);
        x4 = num52 + (ulong) ((long) kw[index2 + 8] + (long) (uint) index1 + 1L);
      }
      outWords[0] = num9;
      outWords[1] = x1;
      outWords[2] = num10;
      outWords[3] = x2;
      outWords[4] = num11;
      outWords[5] = x3;
      outWords[6] = num12;
      outWords[7] = x4;
    }

    internal override void DecryptBlock(ulong[] block, ulong[] state)
    {
      ulong[] kw = this.kw;
      ulong[] t = this.t;
      int[] moD9 = ThreefishEngine.MOD9;
      int[] moD3 = ThreefishEngine.MOD3;
      if (kw.Length != 17)
        throw new ArgumentException();
      if (t.Length != 5)
        throw new ArgumentException();
      ulong num1 = block[0];
      ulong num2 = block[1];
      ulong num3 = block[2];
      ulong num4 = block[3];
      ulong num5 = block[4];
      ulong num6 = block[5];
      ulong num7 = block[6];
      ulong num8 = block[7];
      for (int index1 = 17; index1 >= 1; index1 -= 2)
      {
        int index2 = moD9[index1];
        int index3 = moD3[index1];
        ulong xor1 = num1 - kw[index2 + 1];
        ulong x1 = num2 - kw[index2 + 2];
        ulong xor2 = num3 - kw[index2 + 3];
        ulong x2 = num4 - kw[index2 + 4];
        ulong xor3 = num5 - kw[index2 + 5];
        ulong x3 = num6 - (kw[index2 + 6] + t[index3 + 1]);
        ulong xor4 = num7 - (kw[index2 + 7] + t[index3 + 2]);
        ulong x4 = num8 - (ulong) ((long) kw[index2 + 8] + (long) (uint) index1 + 1L);
        ulong x5 = ThreefishEngine.XorRotr(x1, 8, xor4);
        ulong xor5 = xor4 - x5;
        ulong x6 = ThreefishEngine.XorRotr(x4, 35, xor1);
        ulong xor6 = xor1 - x6;
        ulong x7 = ThreefishEngine.XorRotr(x3, 56, xor2);
        ulong xor7 = xor2 - x7;
        ulong x8 = ThreefishEngine.XorRotr(x2, 22, xor3);
        ulong xor8 = xor3 - x8;
        ulong x9 = ThreefishEngine.XorRotr(x5, 25, xor8);
        ulong xor9 = xor8 - x9;
        ulong x10 = ThreefishEngine.XorRotr(x8, 29, xor5);
        ulong xor10 = xor5 - x10;
        ulong x11 = ThreefishEngine.XorRotr(x7, 39, xor6);
        ulong xor11 = xor6 - x11;
        ulong x12 = ThreefishEngine.XorRotr(x6, 43, xor7);
        ulong xor12 = xor7 - x12;
        ulong x13 = ThreefishEngine.XorRotr(x9, 13, xor12);
        ulong xor13 = xor12 - x13;
        ulong x14 = ThreefishEngine.XorRotr(x12, 50, xor9);
        ulong xor14 = xor9 - x14;
        ulong x15 = ThreefishEngine.XorRotr(x11, 10, xor10);
        ulong xor15 = xor10 - x15;
        ulong x16 = ThreefishEngine.XorRotr(x10, 17, xor11);
        ulong xor16 = xor11 - x16;
        ulong num9 = ThreefishEngine.XorRotr(x13, 39, xor16);
        ulong num10 = xor16 - num9;
        ulong num11 = ThreefishEngine.XorRotr(x16, 30, xor13);
        ulong num12 = xor13 - num11;
        ulong num13 = ThreefishEngine.XorRotr(x15, 34, xor14);
        ulong num14 = xor14 - num13;
        ulong num15 = ThreefishEngine.XorRotr(x14, 24, xor15);
        ulong num16 = xor15 - num15;
        ulong xor17 = num10 - kw[index2];
        ulong x17 = num9 - kw[index2 + 1];
        ulong xor18 = num12 - kw[index2 + 2];
        ulong x18 = num11 - kw[index2 + 3];
        ulong xor19 = num14 - kw[index2 + 4];
        ulong x19 = num13 - (kw[index2 + 5] + t[index3]);
        ulong xor20 = num16 - (kw[index2 + 6] + t[index3 + 1]);
        ulong x20 = num15 - (kw[index2 + 7] + (ulong) (uint) index1);
        ulong x21 = ThreefishEngine.XorRotr(x17, 44, xor20);
        ulong xor21 = xor20 - x21;
        ulong x22 = ThreefishEngine.XorRotr(x20, 9, xor17);
        ulong xor22 = xor17 - x22;
        ulong x23 = ThreefishEngine.XorRotr(x19, 54, xor18);
        ulong xor23 = xor18 - x23;
        ulong x24 = ThreefishEngine.XorRotr(x18, 56, xor19);
        ulong xor24 = xor19 - x24;
        ulong x25 = ThreefishEngine.XorRotr(x21, 17, xor24);
        ulong xor25 = xor24 - x25;
        ulong x26 = ThreefishEngine.XorRotr(x24, 49, xor21);
        ulong xor26 = xor21 - x26;
        ulong x27 = ThreefishEngine.XorRotr(x23, 36, xor22);
        ulong xor27 = xor22 - x27;
        ulong x28 = ThreefishEngine.XorRotr(x22, 39, xor23);
        ulong xor28 = xor23 - x28;
        ulong x29 = ThreefishEngine.XorRotr(x25, 33, xor28);
        ulong xor29 = xor28 - x29;
        ulong x30 = ThreefishEngine.XorRotr(x28, 27, xor25);
        ulong xor30 = xor25 - x30;
        ulong x31 = ThreefishEngine.XorRotr(x27, 14, xor26);
        ulong xor31 = xor26 - x31;
        ulong x32 = ThreefishEngine.XorRotr(x26, 42, xor27);
        ulong xor32 = xor27 - x32;
        num2 = ThreefishEngine.XorRotr(x29, 46, xor32);
        num1 = xor32 - num2;
        num4 = ThreefishEngine.XorRotr(x32, 36, xor29);
        num3 = xor29 - num4;
        num6 = ThreefishEngine.XorRotr(x31, 19, xor30);
        num5 = xor30 - num6;
        num8 = ThreefishEngine.XorRotr(x30, 37, xor31);
        num7 = xor31 - num8;
      }
      ulong num17 = num1 - kw[0];
      ulong num18 = num2 - kw[1];
      ulong num19 = num3 - kw[2];
      ulong num20 = num4 - kw[3];
      ulong num21 = num5 - kw[4];
      ulong num22 = num6 - (kw[5] + t[0]);
      ulong num23 = num7 - (kw[6] + t[1]);
      ulong num24 = num8 - kw[7];
      state[0] = num17;
      state[1] = num18;
      state[2] = num19;
      state[3] = num20;
      state[4] = num21;
      state[5] = num22;
      state[6] = num23;
      state[7] = num24;
    }
  }

  private sealed class Threefish1024Cipher(ulong[] kw, ulong[] t) : ThreefishEngine.ThreefishCipher(kw, t)
  {
    private const int ROTATION_0_0 = 24;
    private const int ROTATION_0_1 = 13;
    private const int ROTATION_0_2 = 8;
    private const int ROTATION_0_3 = 47;
    private const int ROTATION_0_4 = 8;
    private const int ROTATION_0_5 = 17;
    private const int ROTATION_0_6 = 22;
    private const int ROTATION_0_7 = 37;
    private const int ROTATION_1_0 = 38;
    private const int ROTATION_1_1 = 19;
    private const int ROTATION_1_2 = 10;
    private const int ROTATION_1_3 = 55;
    private const int ROTATION_1_4 = 49;
    private const int ROTATION_1_5 = 18;
    private const int ROTATION_1_6 = 23;
    private const int ROTATION_1_7 = 52;
    private const int ROTATION_2_0 = 33;
    private const int ROTATION_2_1 = 4;
    private const int ROTATION_2_2 = 51;
    private const int ROTATION_2_3 = 13;
    private const int ROTATION_2_4 = 34;
    private const int ROTATION_2_5 = 41;
    private const int ROTATION_2_6 = 59;
    private const int ROTATION_2_7 = 17;
    private const int ROTATION_3_0 = 5;
    private const int ROTATION_3_1 = 20;
    private const int ROTATION_3_2 = 48 /*0x30*/;
    private const int ROTATION_3_3 = 41;
    private const int ROTATION_3_4 = 47;
    private const int ROTATION_3_5 = 28;
    private const int ROTATION_3_6 = 16 /*0x10*/;
    private const int ROTATION_3_7 = 25;
    private const int ROTATION_4_0 = 41;
    private const int ROTATION_4_1 = 9;
    private const int ROTATION_4_2 = 37;
    private const int ROTATION_4_3 = 31 /*0x1F*/;
    private const int ROTATION_4_4 = 12;
    private const int ROTATION_4_5 = 47;
    private const int ROTATION_4_6 = 44;
    private const int ROTATION_4_7 = 30;
    private const int ROTATION_5_0 = 16 /*0x10*/;
    private const int ROTATION_5_1 = 34;
    private const int ROTATION_5_2 = 56;
    private const int ROTATION_5_3 = 51;
    private const int ROTATION_5_4 = 4;
    private const int ROTATION_5_5 = 53;
    private const int ROTATION_5_6 = 42;
    private const int ROTATION_5_7 = 41;
    private const int ROTATION_6_0 = 31 /*0x1F*/;
    private const int ROTATION_6_1 = 44;
    private const int ROTATION_6_2 = 47;
    private const int ROTATION_6_3 = 46;
    private const int ROTATION_6_4 = 19;
    private const int ROTATION_6_5 = 42;
    private const int ROTATION_6_6 = 44;
    private const int ROTATION_6_7 = 25;
    private const int ROTATION_7_0 = 9;
    private const int ROTATION_7_1 = 48 /*0x30*/;
    private const int ROTATION_7_2 = 35;
    private const int ROTATION_7_3 = 52;
    private const int ROTATION_7_4 = 23;
    private const int ROTATION_7_5 = 31 /*0x1F*/;
    private const int ROTATION_7_6 = 37;
    private const int ROTATION_7_7 = 20;

    internal override void EncryptBlock(ulong[] block, ulong[] outWords)
    {
      ulong[] kw = this.kw;
      ulong[] t = this.t;
      int[] moD17 = ThreefishEngine.MOD17;
      int[] moD3 = ThreefishEngine.MOD3;
      if (kw.Length != 33)
        throw new ArgumentException();
      if (t.Length != 5)
        throw new ArgumentException();
      ulong num1 = block[0];
      ulong num2 = block[1];
      ulong num3 = block[2];
      ulong num4 = block[3];
      ulong num5 = block[4];
      ulong num6 = block[5];
      ulong num7 = block[6];
      ulong num8 = block[7];
      ulong num9 = block[8];
      ulong num10 = block[9];
      ulong num11 = block[10];
      ulong num12 = block[11];
      ulong num13 = block[12];
      ulong num14 = block[13];
      ulong num15 = block[14];
      ulong num16 = block[15];
      ulong num17 = num1 + kw[0];
      ulong x1 = num2 + kw[1];
      ulong num18 = num3 + kw[2];
      ulong x2 = num4 + kw[3];
      ulong num19 = num5 + kw[4];
      ulong x3 = num6 + kw[5];
      ulong num20 = num7 + kw[6];
      ulong x4 = num8 + kw[7];
      ulong num21 = num9 + kw[8];
      ulong x5 = num10 + kw[9];
      ulong num22 = num11 + kw[10];
      ulong x6 = num12 + kw[11];
      ulong num23 = num13 + kw[12];
      ulong x7 = num14 + (kw[13] + t[0]);
      ulong num24 = num15 + (kw[14] + t[1]);
      ulong x8 = num16 + kw[15];
      for (int index1 = 1; index1 < 20; index1 += 2)
      {
        int index2 = moD17[index1];
        int index3 = moD3[index1];
        ulong num25;
        ulong x9 = ThreefishEngine.RotlXor(x1, 24, num25 = num17 + x1);
        ulong num26;
        ulong x10 = ThreefishEngine.RotlXor(x2, 13, num26 = num18 + x2);
        ulong num27;
        ulong x11 = ThreefishEngine.RotlXor(x3, 8, num27 = num19 + x3);
        ulong num28;
        ulong x12 = ThreefishEngine.RotlXor(x4, 47, num28 = num20 + x4);
        ulong num29;
        ulong x13 = ThreefishEngine.RotlXor(x5, 8, num29 = num21 + x5);
        ulong num30;
        ulong x14 = ThreefishEngine.RotlXor(x6, 17, num30 = num22 + x6);
        ulong num31;
        ulong x15 = ThreefishEngine.RotlXor(x7, 22, num31 = num23 + x7);
        ulong num32;
        ulong x16 = ThreefishEngine.RotlXor(x8, 37, num32 = num24 + x8);
        ulong num33;
        ulong x17 = ThreefishEngine.RotlXor(x13, 38, num33 = num25 + x13);
        ulong num34;
        ulong x18 = ThreefishEngine.RotlXor(x15, 19, num34 = num26 + x15);
        ulong num35;
        ulong x19 = ThreefishEngine.RotlXor(x14, 10, num35 = num28 + x14);
        ulong num36;
        ulong x20 = ThreefishEngine.RotlXor(x16, 55, num36 = num27 + x16);
        ulong num37;
        ulong x21 = ThreefishEngine.RotlXor(x12, 49, num37 = num30 + x12);
        ulong num38;
        ulong x22 = ThreefishEngine.RotlXor(x10, 18, num38 = num31 + x10);
        ulong num39;
        ulong x23 = ThreefishEngine.RotlXor(x11, 23, num39 = num32 + x11);
        ulong num40;
        ulong x24 = ThreefishEngine.RotlXor(x9, 52, num40 = num29 + x9);
        ulong num41;
        ulong x25 = ThreefishEngine.RotlXor(x21, 33, num41 = num33 + x21);
        ulong num42;
        ulong x26 = ThreefishEngine.RotlXor(x23, 4, num42 = num34 + x23);
        ulong num43;
        ulong x27 = ThreefishEngine.RotlXor(x22, 51, num43 = num36 + x22);
        ulong num44;
        ulong x28 = ThreefishEngine.RotlXor(x24, 13, num44 = num35 + x24);
        ulong num45;
        ulong x29 = ThreefishEngine.RotlXor(x20, 34, num45 = num38 + x20);
        ulong num46;
        ulong x30 = ThreefishEngine.RotlXor(x18, 41, num46 = num39 + x18);
        ulong num47;
        ulong x31 = ThreefishEngine.RotlXor(x19, 59, num47 = num40 + x19);
        ulong num48;
        ulong x32 = ThreefishEngine.RotlXor(x17, 17, num48 = num37 + x17);
        ulong num49;
        ulong num50 = ThreefishEngine.RotlXor(x29, 5, num49 = num41 + x29);
        ulong num51;
        ulong num52 = ThreefishEngine.RotlXor(x31, 20, num51 = num42 + x31);
        ulong num53;
        ulong num54 = ThreefishEngine.RotlXor(x30, 48 /*0x30*/, num53 = num44 + x30);
        ulong num55;
        ulong num56 = ThreefishEngine.RotlXor(x32, 41, num55 = num43 + x32);
        ulong num57;
        ulong num58 = ThreefishEngine.RotlXor(x28, 47, num57 = num46 + x28);
        ulong num59;
        ulong num60 = ThreefishEngine.RotlXor(x26, 28, num59 = num47 + x26);
        ulong num61;
        ulong num62 = ThreefishEngine.RotlXor(x27, 16 /*0x10*/, num61 = num48 + x27);
        ulong num63;
        ulong num64 = ThreefishEngine.RotlXor(x25, 25, num63 = num45 + x25);
        ulong num65 = num49 + kw[index2];
        ulong x33 = num58 + kw[index2 + 1];
        ulong num66 = num51 + kw[index2 + 2];
        ulong x34 = num62 + kw[index2 + 3];
        ulong num67 = num55 + kw[index2 + 4];
        ulong x35 = num60 + kw[index2 + 5];
        ulong num68 = num53 + kw[index2 + 6];
        ulong x36 = num64 + kw[index2 + 7];
        ulong num69 = num59 + kw[index2 + 8];
        ulong x37 = num56 + kw[index2 + 9];
        ulong num70 = num61 + kw[index2 + 10];
        ulong x38 = num52 + kw[index2 + 11];
        ulong num71 = num63 + kw[index2 + 12];
        ulong x39 = num54 + (kw[index2 + 13] + t[index3]);
        ulong num72 = num57 + (kw[index2 + 14] + t[index3 + 1]);
        ulong x40 = num50 + (kw[index2 + 15] + (ulong) (uint) index1);
        ulong num73;
        ulong x41 = ThreefishEngine.RotlXor(x33, 41, num73 = num65 + x33);
        ulong num74;
        ulong x42 = ThreefishEngine.RotlXor(x34, 9, num74 = num66 + x34);
        ulong num75;
        ulong x43 = ThreefishEngine.RotlXor(x35, 37, num75 = num67 + x35);
        ulong num76;
        ulong x44 = ThreefishEngine.RotlXor(x36, 31 /*0x1F*/, num76 = num68 + x36);
        ulong num77;
        ulong x45 = ThreefishEngine.RotlXor(x37, 12, num77 = num69 + x37);
        ulong num78;
        ulong x46 = ThreefishEngine.RotlXor(x38, 47, num78 = num70 + x38);
        ulong num79;
        ulong x47 = ThreefishEngine.RotlXor(x39, 44, num79 = num71 + x39);
        ulong num80;
        ulong x48 = ThreefishEngine.RotlXor(x40, 30, num80 = num72 + x40);
        ulong num81;
        ulong x49 = ThreefishEngine.RotlXor(x45, 16 /*0x10*/, num81 = num73 + x45);
        ulong num82;
        ulong x50 = ThreefishEngine.RotlXor(x47, 34, num82 = num74 + x47);
        ulong num83;
        ulong x51 = ThreefishEngine.RotlXor(x46, 56, num83 = num76 + x46);
        ulong num84;
        ulong x52 = ThreefishEngine.RotlXor(x48, 51, num84 = num75 + x48);
        ulong num85;
        ulong x53 = ThreefishEngine.RotlXor(x44, 4, num85 = num78 + x44);
        ulong num86;
        ulong x54 = ThreefishEngine.RotlXor(x42, 53, num86 = num79 + x42);
        ulong num87;
        ulong x55 = ThreefishEngine.RotlXor(x43, 42, num87 = num80 + x43);
        ulong num88;
        ulong x56 = ThreefishEngine.RotlXor(x41, 41, num88 = num77 + x41);
        ulong num89;
        ulong x57 = ThreefishEngine.RotlXor(x53, 31 /*0x1F*/, num89 = num81 + x53);
        ulong num90;
        ulong x58 = ThreefishEngine.RotlXor(x55, 44, num90 = num82 + x55);
        ulong num91;
        ulong x59 = ThreefishEngine.RotlXor(x54, 47, num91 = num84 + x54);
        ulong num92;
        ulong x60 = ThreefishEngine.RotlXor(x56, 46, num92 = num83 + x56);
        ulong num93;
        ulong x61 = ThreefishEngine.RotlXor(x52, 19, num93 = num86 + x52);
        ulong num94;
        ulong x62 = ThreefishEngine.RotlXor(x50, 42, num94 = num87 + x50);
        ulong num95;
        ulong x63 = ThreefishEngine.RotlXor(x51, 44, num95 = num88 + x51);
        ulong num96;
        ulong x64 = ThreefishEngine.RotlXor(x49, 25, num96 = num85 + x49);
        ulong num97;
        ulong num98 = ThreefishEngine.RotlXor(x61, 9, num97 = num89 + x61);
        ulong num99;
        ulong num100 = ThreefishEngine.RotlXor(x63, 48 /*0x30*/, num99 = num90 + x63);
        ulong num101;
        ulong num102 = ThreefishEngine.RotlXor(x62, 35, num101 = num92 + x62);
        ulong num103;
        ulong num104 = ThreefishEngine.RotlXor(x64, 52, num103 = num91 + x64);
        ulong num105;
        ulong num106 = ThreefishEngine.RotlXor(x60, 23, num105 = num94 + x60);
        ulong num107;
        ulong num108 = ThreefishEngine.RotlXor(x58, 31 /*0x1F*/, num107 = num95 + x58);
        ulong num109;
        ulong num110 = ThreefishEngine.RotlXor(x59, 37, num109 = num96 + x59);
        ulong num111;
        ulong num112 = ThreefishEngine.RotlXor(x57, 20, num111 = num93 + x57);
        num17 = num97 + kw[index2 + 1];
        x1 = num106 + kw[index2 + 2];
        num18 = num99 + kw[index2 + 3];
        x2 = num110 + kw[index2 + 4];
        num19 = num103 + kw[index2 + 5];
        x3 = num108 + kw[index2 + 6];
        num20 = num101 + kw[index2 + 7];
        x4 = num112 + kw[index2 + 8];
        num21 = num107 + kw[index2 + 9];
        x5 = num104 + kw[index2 + 10];
        num22 = num109 + kw[index2 + 11];
        x6 = num100 + kw[index2 + 12];
        num23 = num111 + kw[index2 + 13];
        x7 = num102 + (kw[index2 + 14] + t[index3 + 1]);
        num24 = num105 + (kw[index2 + 15] + t[index3 + 2]);
        x8 = num98 + (ulong) ((long) kw[index2 + 16 /*0x10*/] + (long) (uint) index1 + 1L);
      }
      outWords[0] = num17;
      outWords[1] = x1;
      outWords[2] = num18;
      outWords[3] = x2;
      outWords[4] = num19;
      outWords[5] = x3;
      outWords[6] = num20;
      outWords[7] = x4;
      outWords[8] = num21;
      outWords[9] = x5;
      outWords[10] = num22;
      outWords[11] = x6;
      outWords[12] = num23;
      outWords[13] = x7;
      outWords[14] = num24;
      outWords[15] = x8;
    }

    internal override void DecryptBlock(ulong[] block, ulong[] state)
    {
      ulong[] kw = this.kw;
      ulong[] t = this.t;
      int[] moD17 = ThreefishEngine.MOD17;
      int[] moD3 = ThreefishEngine.MOD3;
      if (kw.Length != 33)
        throw new ArgumentException();
      if (t.Length != 5)
        throw new ArgumentException();
      ulong num1 = block[0];
      ulong num2 = block[1];
      ulong num3 = block[2];
      ulong num4 = block[3];
      ulong num5 = block[4];
      ulong num6 = block[5];
      ulong num7 = block[6];
      ulong num8 = block[7];
      ulong num9 = block[8];
      ulong num10 = block[9];
      ulong num11 = block[10];
      ulong num12 = block[11];
      ulong num13 = block[12];
      ulong num14 = block[13];
      ulong num15 = block[14];
      ulong num16 = block[15];
      for (int index1 = 19; index1 >= 1; index1 -= 2)
      {
        int index2 = moD17[index1];
        int index3 = moD3[index1];
        ulong xor1 = num1 - kw[index2 + 1];
        ulong x1 = num2 - kw[index2 + 2];
        ulong xor2 = num3 - kw[index2 + 3];
        ulong x2 = num4 - kw[index2 + 4];
        ulong xor3 = num5 - kw[index2 + 5];
        ulong x3 = num6 - kw[index2 + 6];
        ulong xor4 = num7 - kw[index2 + 7];
        ulong x4 = num8 - kw[index2 + 8];
        ulong xor5 = num9 - kw[index2 + 9];
        ulong x5 = num10 - kw[index2 + 10];
        ulong xor6 = num11 - kw[index2 + 11];
        ulong x6 = num12 - kw[index2 + 12];
        ulong xor7 = num13 - kw[index2 + 13];
        ulong x7 = num14 - (kw[index2 + 14] + t[index3 + 1]);
        ulong xor8 = num15 - (kw[index2 + 15] + t[index3 + 2]);
        ulong x8 = ThreefishEngine.XorRotr(num16 - (ulong) ((long) kw[index2 + 16 /*0x10*/] + (long) (uint) index1 + 1L), 9, xor1);
        ulong xor9 = xor1 - x8;
        ulong x9 = ThreefishEngine.XorRotr(x6, 48 /*0x30*/, xor2);
        ulong xor10 = xor2 - x9;
        ulong x10 = ThreefishEngine.XorRotr(x7, 35, xor4);
        ulong xor11 = xor4 - x10;
        ulong x11 = ThreefishEngine.XorRotr(x5, 52, xor3);
        ulong xor12 = xor3 - x11;
        ulong x12 = ThreefishEngine.XorRotr(x1, 23, xor8);
        ulong xor13 = xor8 - x12;
        ulong x13 = ThreefishEngine.XorRotr(x3, 31 /*0x1F*/, xor5);
        ulong xor14 = xor5 - x13;
        ulong x14 = ThreefishEngine.XorRotr(x2, 37, xor6);
        ulong xor15 = xor6 - x14;
        ulong x15 = ThreefishEngine.XorRotr(x4, 20, xor7);
        ulong xor16 = xor7 - x15;
        ulong x16 = ThreefishEngine.XorRotr(x15, 31 /*0x1F*/, xor9);
        ulong xor17 = xor9 - x16;
        ulong x17 = ThreefishEngine.XorRotr(x13, 44, xor10);
        ulong xor18 = xor10 - x17;
        ulong x18 = ThreefishEngine.XorRotr(x14, 47, xor12);
        ulong xor19 = xor12 - x18;
        ulong x19 = ThreefishEngine.XorRotr(x12, 46, xor11);
        ulong xor20 = xor11 - x19;
        ulong x20 = ThreefishEngine.XorRotr(x8, 19, xor16);
        ulong xor21 = xor16 - x20;
        ulong x21 = ThreefishEngine.XorRotr(x10, 42, xor13);
        ulong xor22 = xor13 - x21;
        ulong x22 = ThreefishEngine.XorRotr(x9, 44, xor14);
        ulong xor23 = xor14 - x22;
        ulong x23 = ThreefishEngine.XorRotr(x11, 25, xor15);
        ulong xor24 = xor15 - x23;
        ulong x24 = ThreefishEngine.XorRotr(x23, 16 /*0x10*/, xor17);
        ulong xor25 = xor17 - x24;
        ulong x25 = ThreefishEngine.XorRotr(x21, 34, xor18);
        ulong xor26 = xor18 - x25;
        ulong x26 = ThreefishEngine.XorRotr(x22, 56, xor20);
        ulong xor27 = xor20 - x26;
        ulong x27 = ThreefishEngine.XorRotr(x20, 51, xor19);
        ulong xor28 = xor19 - x27;
        ulong x28 = ThreefishEngine.XorRotr(x16, 4, xor24);
        ulong xor29 = xor24 - x28;
        ulong x29 = ThreefishEngine.XorRotr(x18, 53, xor21);
        ulong xor30 = xor21 - x29;
        ulong x30 = ThreefishEngine.XorRotr(x17, 42, xor22);
        ulong xor31 = xor22 - x30;
        ulong x31 = ThreefishEngine.XorRotr(x19, 41, xor23);
        ulong xor32 = xor23 - x31;
        ulong num17 = ThreefishEngine.XorRotr(x31, 41, xor25);
        ulong num18 = xor25 - num17;
        ulong num19 = ThreefishEngine.XorRotr(x29, 9, xor26);
        ulong num20 = xor26 - num19;
        ulong num21 = ThreefishEngine.XorRotr(x30, 37, xor28);
        ulong num22 = xor28 - num21;
        ulong num23 = ThreefishEngine.XorRotr(x28, 31 /*0x1F*/, xor27);
        ulong num24 = xor27 - num23;
        ulong num25 = ThreefishEngine.XorRotr(x24, 12, xor32);
        ulong num26 = xor32 - num25;
        ulong num27 = ThreefishEngine.XorRotr(x26, 47, xor29);
        ulong num28 = xor29 - num27;
        ulong num29 = ThreefishEngine.XorRotr(x25, 44, xor30);
        ulong num30 = xor30 - num29;
        ulong num31 = ThreefishEngine.XorRotr(x27, 30, xor31);
        ulong num32 = xor31 - num31;
        ulong xor33 = num18 - kw[index2];
        ulong x32 = num17 - kw[index2 + 1];
        ulong xor34 = num20 - kw[index2 + 2];
        ulong x33 = num19 - kw[index2 + 3];
        ulong xor35 = num22 - kw[index2 + 4];
        ulong x34 = num21 - kw[index2 + 5];
        ulong xor36 = num24 - kw[index2 + 6];
        ulong x35 = num23 - kw[index2 + 7];
        ulong xor37 = num26 - kw[index2 + 8];
        ulong x36 = num25 - kw[index2 + 9];
        ulong xor38 = num28 - kw[index2 + 10];
        ulong x37 = num27 - kw[index2 + 11];
        ulong xor39 = num30 - kw[index2 + 12];
        ulong x38 = num29 - (kw[index2 + 13] + t[index3]);
        ulong xor40 = num32 - (kw[index2 + 14] + t[index3 + 1]);
        ulong x39 = ThreefishEngine.XorRotr(num31 - (kw[index2 + 15] + (ulong) (uint) index1), 5, xor33);
        ulong xor41 = xor33 - x39;
        ulong x40 = ThreefishEngine.XorRotr(x37, 20, xor34);
        ulong xor42 = xor34 - x40;
        ulong x41 = ThreefishEngine.XorRotr(x38, 48 /*0x30*/, xor36);
        ulong xor43 = xor36 - x41;
        ulong x42 = ThreefishEngine.XorRotr(x36, 41, xor35);
        ulong xor44 = xor35 - x42;
        ulong x43 = ThreefishEngine.XorRotr(x32, 47, xor40);
        ulong xor45 = xor40 - x43;
        ulong x44 = ThreefishEngine.XorRotr(x34, 28, xor37);
        ulong xor46 = xor37 - x44;
        ulong x45 = ThreefishEngine.XorRotr(x33, 16 /*0x10*/, xor38);
        ulong xor47 = xor38 - x45;
        ulong x46 = ThreefishEngine.XorRotr(x35, 25, xor39);
        ulong xor48 = xor39 - x46;
        ulong x47 = ThreefishEngine.XorRotr(x46, 33, xor41);
        ulong xor49 = xor41 - x47;
        ulong x48 = ThreefishEngine.XorRotr(x44, 4, xor42);
        ulong xor50 = xor42 - x48;
        ulong x49 = ThreefishEngine.XorRotr(x45, 51, xor44);
        ulong xor51 = xor44 - x49;
        ulong x50 = ThreefishEngine.XorRotr(x43, 13, xor43);
        ulong xor52 = xor43 - x50;
        ulong x51 = ThreefishEngine.XorRotr(x39, 34, xor48);
        ulong xor53 = xor48 - x51;
        ulong x52 = ThreefishEngine.XorRotr(x41, 41, xor45);
        ulong xor54 = xor45 - x52;
        ulong x53 = ThreefishEngine.XorRotr(x40, 59, xor46);
        ulong xor55 = xor46 - x53;
        ulong x54 = ThreefishEngine.XorRotr(x42, 17, xor47);
        ulong xor56 = xor47 - x54;
        ulong x55 = ThreefishEngine.XorRotr(x54, 38, xor49);
        ulong xor57 = xor49 - x55;
        ulong x56 = ThreefishEngine.XorRotr(x52, 19, xor50);
        ulong xor58 = xor50 - x56;
        ulong x57 = ThreefishEngine.XorRotr(x53, 10, xor52);
        ulong xor59 = xor52 - x57;
        ulong x58 = ThreefishEngine.XorRotr(x51, 55, xor51);
        ulong xor60 = xor51 - x58;
        ulong x59 = ThreefishEngine.XorRotr(x47, 49, xor56);
        ulong xor61 = xor56 - x59;
        ulong x60 = ThreefishEngine.XorRotr(x49, 18, xor53);
        ulong xor62 = xor53 - x60;
        ulong x61 = ThreefishEngine.XorRotr(x48, 23, xor54);
        ulong xor63 = xor54 - x61;
        ulong x62 = ThreefishEngine.XorRotr(x50, 52, xor55);
        ulong xor64 = xor55 - x62;
        num2 = ThreefishEngine.XorRotr(x62, 24, xor57);
        num1 = xor57 - num2;
        num4 = ThreefishEngine.XorRotr(x60, 13, xor58);
        num3 = xor58 - num4;
        num6 = ThreefishEngine.XorRotr(x61, 8, xor60);
        num5 = xor60 - num6;
        num8 = ThreefishEngine.XorRotr(x59, 47, xor59);
        num7 = xor59 - num8;
        num10 = ThreefishEngine.XorRotr(x55, 8, xor64);
        num9 = xor64 - num10;
        num12 = ThreefishEngine.XorRotr(x57, 17, xor61);
        num11 = xor61 - num12;
        num14 = ThreefishEngine.XorRotr(x56, 22, xor62);
        num13 = xor62 - num14;
        num16 = ThreefishEngine.XorRotr(x58, 37, xor63);
        num15 = xor63 - num16;
      }
      ulong num33 = num1 - kw[0];
      ulong num34 = num2 - kw[1];
      ulong num35 = num3 - kw[2];
      ulong num36 = num4 - kw[3];
      ulong num37 = num5 - kw[4];
      ulong num38 = num6 - kw[5];
      ulong num39 = num7 - kw[6];
      ulong num40 = num8 - kw[7];
      ulong num41 = num9 - kw[8];
      ulong num42 = num10 - kw[9];
      ulong num43 = num11 - kw[10];
      ulong num44 = num12 - kw[11];
      ulong num45 = num13 - kw[12];
      ulong num46 = num14 - (kw[13] + t[0]);
      ulong num47 = num15 - (kw[14] + t[1]);
      ulong num48 = num16 - kw[15];
      state[0] = num33;
      state[1] = num34;
      state[2] = num35;
      state[3] = num36;
      state[4] = num37;
      state[5] = num38;
      state[6] = num39;
      state[7] = num40;
      state[8] = num41;
      state[9] = num42;
      state[10] = num43;
      state[11] = num44;
      state[12] = num45;
      state[13] = num46;
      state[14] = num47;
      state[15] = num48;
    }
  }
}
