// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.IdeaEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class IdeaEngine : IBlockCipher
{
  private const int BLOCK_SIZE = 8;
  private int[] workingKey;
  private static readonly int MASK = (int) ushort.MaxValue;
  private static readonly int BASE = 65537 /*0x010001*/;

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.workingKey = parameters is KeyParameter ? this.GenerateWorkingKey(forEncryption, ((KeyParameter) parameters).GetKey()) : throw new ArgumentException("invalid parameter passed to IDEA init - " + Platform.GetTypeName((object) parameters));
  }

  public virtual string AlgorithmName => "IDEA";

  public virtual int GetBlockSize() => 8;

  public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    if (this.workingKey == null)
      throw new InvalidOperationException("IDEA engine not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, 8, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, 8, "output buffer too short");
    this.IdeaFunc(this.workingKey, input, inOff, output, outOff);
    return 8;
  }

  private int BytesToWord(byte[] input, int inOff)
  {
    return ((int) input[inOff] << 8 & 65280) + ((int) input[inOff + 1] & (int) byte.MaxValue);
  }

  private void WordToBytes(int word, byte[] outBytes, int outOff)
  {
    outBytes[outOff] = (byte) (word >>> 8);
    outBytes[outOff + 1] = (byte) word;
  }

  private int Mul(int x, int y)
  {
    if (x == 0)
      x = IdeaEngine.BASE - y;
    else if (y == 0)
    {
      x = IdeaEngine.BASE - x;
    }
    else
    {
      int num = x * y;
      y = num & IdeaEngine.MASK;
      x = num >>> 16 /*0x10*/;
      x = y - x + (y < x ? 1 : 0);
    }
    return x & IdeaEngine.MASK;
  }

  private void IdeaFunc(int[] workingKey, byte[] input, int inOff, byte[] outBytes, int outOff)
  {
    int num1 = this.BytesToWord(input, inOff);
    int num2 = this.BytesToWord(input, inOff + 2);
    int num3 = this.BytesToWord(input, inOff + 4);
    int x1 = this.BytesToWord(input, inOff + 6);
    int num4 = 0;
    for (int index1 = 0; index1 < 8; ++index1)
    {
      int x2 = num1;
      int[] numArray1 = workingKey;
      int index2 = num4;
      int num5 = index2 + 1;
      int y1 = numArray1[index2];
      int num6 = this.Mul(x2, y1);
      int num7 = num2;
      int[] numArray2 = workingKey;
      int index3 = num5;
      int num8 = index3 + 1;
      int num9 = numArray2[index3];
      int num10 = num7 + num9 & IdeaEngine.MASK;
      int num11 = num3;
      int[] numArray3 = workingKey;
      int index4 = num8;
      int num12 = index4 + 1;
      int num13 = numArray3[index4];
      int num14 = num11 + num13 & IdeaEngine.MASK;
      int x3 = x1;
      int[] numArray4 = workingKey;
      int index5 = num12;
      int num15 = index5 + 1;
      int y2 = numArray4[index5];
      int num16 = this.Mul(x3, y2);
      int num17 = num10;
      int num18 = num14;
      int num19 = num14 ^ num6;
      int num20 = num10 ^ num16;
      int x4 = num19;
      int[] numArray5 = workingKey;
      int index6 = num15;
      int num21 = index6 + 1;
      int y3 = numArray5[index6];
      int num22 = this.Mul(x4, y3);
      int x5 = num20 + num22 & IdeaEngine.MASK;
      int[] numArray6 = workingKey;
      int index7 = num21;
      num4 = index7 + 1;
      int y4 = numArray6[index7];
      int num23 = this.Mul(x5, y4);
      int num24 = num22 + num23 & IdeaEngine.MASK;
      num1 = num6 ^ num23;
      x1 = num16 ^ num24;
      num2 = num23 ^ num18;
      num3 = num24 ^ num17;
    }
    int x6 = num1;
    int[] numArray7 = workingKey;
    int index8 = num4;
    int num25 = index8 + 1;
    int y = numArray7[index8];
    this.WordToBytes(this.Mul(x6, y), outBytes, outOff);
    int num26 = num3;
    int[] numArray8 = workingKey;
    int index9 = num25;
    int num27 = index9 + 1;
    int num28 = numArray8[index9];
    this.WordToBytes(num26 + num28, outBytes, outOff + 2);
    int num29 = num2;
    int[] numArray9 = workingKey;
    int index10 = num27;
    int index11 = index10 + 1;
    int num30 = numArray9[index10];
    this.WordToBytes(num29 + num30, outBytes, outOff + 4);
    this.WordToBytes(this.Mul(x1, workingKey[index11]), outBytes, outOff + 6);
  }

  private int[] ExpandKey(byte[] uKey)
  {
    int[] numArray = new int[52];
    if (uKey.Length < 16 /*0x10*/)
    {
      byte[] destinationArray = new byte[16 /*0x10*/];
      Array.Copy((Array) uKey, 0, (Array) destinationArray, destinationArray.Length - uKey.Length, uKey.Length);
      uKey = destinationArray;
    }
    for (int index = 0; index < 8; ++index)
      numArray[index] = this.BytesToWord(uKey, index * 2);
    for (int index = 8; index < 52; ++index)
      numArray[index] = (index & 7) >= 6 ? ((index & 7) != 6 ? ((numArray[index - 15] & (int) sbyte.MaxValue) << 9 | numArray[index - 14] >> 7) & IdeaEngine.MASK : ((numArray[index - 7] & (int) sbyte.MaxValue) << 9 | numArray[index - 14] >> 7) & IdeaEngine.MASK) : ((numArray[index - 7] & (int) sbyte.MaxValue) << 9 | numArray[index - 6] >> 7) & IdeaEngine.MASK;
    return numArray;
  }

  private int MulInv(int x)
  {
    if (x < 2)
      return x;
    int num1 = 1;
    int num2 = IdeaEngine.BASE / x;
    int num3 = IdeaEngine.BASE % x;
    while (num3 != 1)
    {
      int num4 = x / num3;
      x %= num3;
      num1 = num1 + num2 * num4 & IdeaEngine.MASK;
      if (x == 1)
        return num1;
      int num5 = num3 / x;
      num3 %= x;
      num2 = num2 + num1 * num5 & IdeaEngine.MASK;
    }
    return 1 - num2 & IdeaEngine.MASK;
  }

  private int AddInv(int x) => -x & IdeaEngine.MASK;

  private int[] InvertKey(int[] inKey)
  {
    int num1 = 52;
    int[] numArray1 = new int[52];
    int num2 = 0;
    int[] numArray2 = inKey;
    num2 = 1;
    int num3 = this.MulInv(numArray2[0]);
    int[] numArray3 = inKey;
    num2 = 2;
    int num4 = this.AddInv(numArray3[1]);
    int[] numArray4 = inKey;
    num2 = 3;
    int num5 = this.AddInv(numArray4[2]);
    int[] numArray5 = inKey;
    int num6 = 4;
    int num7 = this.MulInv(numArray5[3]);
    int[] numArray6 = numArray1;
    num1 = 51;
    int num8 = num7;
    numArray6[51] = num8;
    int[] numArray7 = numArray1;
    num1 = 50;
    int num9 = num5;
    numArray7[50] = num9;
    int[] numArray8 = numArray1;
    num1 = 49;
    int num10 = num4;
    numArray8[49] = num10;
    int[] numArray9 = numArray1;
    int num11 = 48 /*0x30*/;
    int num12 = num3;
    numArray9[48 /*0x30*/] = num12;
    for (int index1 = 1; index1 < 8; ++index1)
    {
      int[] numArray10 = inKey;
      int index2 = num6;
      int num13 = index2 + 1;
      int num14 = numArray10[index2];
      int[] numArray11 = inKey;
      int index3 = num13;
      int num15 = index3 + 1;
      int num16 = numArray11[index3];
      int num17;
      numArray1[num17 = num11 - 1] = num16;
      int num18;
      numArray1[num18 = num17 - 1] = num14;
      int[] numArray12 = inKey;
      int index4 = num15;
      int num19 = index4 + 1;
      int num20 = this.MulInv(numArray12[index4]);
      int[] numArray13 = inKey;
      int index5 = num19;
      int num21 = index5 + 1;
      int num22 = this.AddInv(numArray13[index5]);
      int[] numArray14 = inKey;
      int index6 = num21;
      int num23 = index6 + 1;
      int num24 = this.AddInv(numArray14[index6]);
      int[] numArray15 = inKey;
      int index7 = num23;
      num6 = index7 + 1;
      int num25 = this.MulInv(numArray15[index7]);
      int num26;
      numArray1[num26 = num18 - 1] = num25;
      int num27;
      numArray1[num27 = num26 - 1] = num22;
      int num28;
      numArray1[num28 = num27 - 1] = num24;
      numArray1[num11 = num28 - 1] = num20;
    }
    int[] numArray16 = inKey;
    int index8 = num6;
    int num29 = index8 + 1;
    int num30 = numArray16[index8];
    int[] numArray17 = inKey;
    int index9 = num29;
    int num31 = index9 + 1;
    int num32 = numArray17[index9];
    int num33;
    numArray1[num33 = num11 - 1] = num32;
    int num34;
    numArray1[num34 = num33 - 1] = num30;
    int[] numArray18 = inKey;
    int index10 = num31;
    int num35 = index10 + 1;
    int num36 = this.MulInv(numArray18[index10]);
    int[] numArray19 = inKey;
    int index11 = num35;
    int num37 = index11 + 1;
    int num38 = this.AddInv(numArray19[index11]);
    int[] numArray20 = inKey;
    int index12 = num37;
    int index13 = index12 + 1;
    int num39 = this.AddInv(numArray20[index12]);
    int num40 = this.MulInv(inKey[index13]);
    int num41;
    numArray1[num41 = num34 - 1] = num40;
    int num42;
    numArray1[num42 = num41 - 1] = num39;
    int num43;
    numArray1[num43 = num42 - 1] = num38;
    numArray1[num1 = num43 - 1] = num36;
    return numArray1;
  }

  private int[] GenerateWorkingKey(bool forEncryption, byte[] userKey)
  {
    return forEncryption ? this.ExpandKey(userKey) : this.InvertKey(this.ExpandKey(userKey));
  }
}
