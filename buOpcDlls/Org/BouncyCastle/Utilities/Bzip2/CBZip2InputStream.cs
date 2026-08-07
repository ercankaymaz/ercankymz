// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Bzip2.CBZip2InputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Utilities.Bzip2;

public class CBZip2InputStream : BaseInputStream
{
  private int last;
  private int origPtr;
  private int blockSize100k;
  private int bsBuff;
  private int bsLive;
  private readonly CRC m_blockCrc = new CRC();
  private int nInUse;
  private byte[] seqToUnseq = new byte[256 /*0x0100*/];
  private byte[] m_selectors = new byte[18002];
  private int[] tt;
  private byte[] ll8;
  private int[] unzftab = new int[256 /*0x0100*/];
  private int[][] limit = CBZip2InputStream.CreateIntArray(6, 21);
  private int[][] basev = CBZip2InputStream.CreateIntArray(6, 21);
  private int[][] perm = CBZip2InputStream.CreateIntArray(6, 258);
  private int[] minLens = new int[6];
  private Stream bsStream;
  private bool streamEnd;
  private int currentByte = -1;
  private const int RAND_PART_B_STATE = 1;
  private const int RAND_PART_C_STATE = 2;
  private const int NO_RAND_PART_B_STATE = 3;
  private const int NO_RAND_PART_C_STATE = 4;
  private int currentState;
  private int m_expectedBlockCrc;
  private int m_expectedStreamCrc;
  private int m_streamCrc;
  private int i2;
  private int count;
  private int chPrev;
  private int ch2;
  private int i;
  private int tPos;
  private int rNToGo;
  private int rTPos;
  private int j2;
  private int z;

  public CBZip2InputStream(Stream zStream)
  {
    this.ll8 = (byte[]) null;
    this.tt = (int[]) null;
    this.bsStream = zStream;
    this.bsLive = 0;
    this.bsBuff = 0;
    int num1 = this.bsStream.ReadByte();
    int num2 = this.bsStream.ReadByte();
    int num3 = this.bsStream.ReadByte();
    int num4 = this.bsStream.ReadByte();
    if (num4 < 0)
      throw new EndOfStreamException();
    if (num1 != 66 | num2 != 90 | num3 != 104 | num4 < 49 | num4 > 57)
      throw new IOException("Invalid stream header");
    this.blockSize100k = num4 - 48 /*0x30*/;
    int length = 100000 * this.blockSize100k;
    this.ll8 = new byte[length];
    this.tt = new int[length];
    this.m_streamCrc = 0;
    this.BeginBlock();
  }

  public override int Read(byte[] buffer, int offset, int count)
  {
    Streams.ValidateBufferArguments(buffer, offset, count);
    int num1;
    int num2;
    for (num1 = 0; num1 < count; buffer[offset + num1++] = (byte) num2)
    {
      num2 = this.ReadByte();
      if (num2 < 0)
        break;
    }
    return num1;
  }

  public override int ReadByte()
  {
    if (this.streamEnd)
      return -1;
    int currentByte = this.currentByte;
    switch (this.currentState)
    {
      case 1:
        this.SetupRandPartB();
        break;
      case 2:
        this.SetupRandPartC();
        break;
      case 3:
        this.SetupNoRandPartB();
        break;
      case 4:
        this.SetupNoRandPartC();
        break;
      default:
        throw new InvalidOperationException();
    }
    return currentByte;
  }

  private void BeginBlock()
  {
    switch (this.BsGetLong48())
    {
      case 25779555029136:
        this.m_expectedStreamCrc = this.BsGetInt32();
        if (this.m_expectedStreamCrc != this.m_streamCrc)
          throw new IOException("Stream CRC error");
        this.streamEnd = true;
        break;
      case 54156738319193:
        this.m_expectedBlockCrc = this.BsGetInt32();
        bool flag = this.BsGetBit() == 1;
        this.GetAndMoveToFrontDecode();
        this.m_blockCrc.Initialise();
        int[] numArray = new int[257];
        int num = 0;
        numArray[0] = 0;
        for (this.i = 0; this.i < 256 /*0x0100*/; ++this.i)
        {
          num += this.unzftab[this.i];
          numArray[this.i + 1] = num;
        }
        if (num != this.last + 1)
          throw new InvalidOperationException();
        for (this.i = 0; this.i <= this.last; ++this.i)
        {
          byte index = this.ll8[this.i];
          this.tt[numArray[(int) index]++] = this.i;
        }
        this.tPos = this.tt[this.origPtr];
        this.count = 0;
        this.i2 = 0;
        this.ch2 = 256 /*0x0100*/;
        if (flag)
        {
          this.rNToGo = 0;
          this.rTPos = 0;
          this.SetupRandPartA();
          break;
        }
        this.SetupNoRandPartA();
        break;
      default:
        throw new IOException("Block header error");
    }
  }

  private void EndBlock()
  {
    int final = this.m_blockCrc.GetFinal();
    if (this.m_expectedBlockCrc != final)
      throw new IOException("Block CRC error");
    this.m_streamCrc = Integers.RotateLeft(this.m_streamCrc, 1) ^ final;
  }

  protected void Detach(bool disposing)
  {
    if (disposing)
      this.ImplDisposing(false);
    base.Dispose(disposing);
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
      this.ImplDisposing(true);
    base.Dispose(disposing);
  }

  private void ImplDisposing(bool disposeInput)
  {
    if (this.bsStream == null)
      return;
    if (disposeInput)
      this.bsStream.Dispose();
    this.bsStream = (Stream) null;
  }

  private int BsGetBit()
  {
    if (this.bsLive == 0)
    {
      this.bsBuff = this.RequireByte();
      this.bsLive = 7;
      return this.bsBuff >>> 7;
    }
    --this.bsLive;
    return this.bsBuff >> this.bsLive & 1;
  }

  private int BsGetBits(int n)
  {
    for (; this.bsLive < n; this.bsLive += 8)
      this.bsBuff = this.bsBuff << 8 | this.RequireByte();
    this.bsLive -= n;
    return this.bsBuff >> this.bsLive & (1 << n) - 1;
  }

  private int BsGetBitsSmall(int n)
  {
    if (this.bsLive < n)
    {
      this.bsBuff = this.bsBuff << 8 | this.RequireByte();
      this.bsLive += 8;
    }
    this.bsLive -= n;
    return this.bsBuff >> this.bsLive & (1 << n) - 1;
  }

  private int BsGetInt32()
  {
    return this.BsGetBits(16 /*0x10*/) << 16 /*0x10*/ | this.BsGetBits(16 /*0x10*/);
  }

  private long BsGetLong48() => (long) this.BsGetBits(24) << 24 | (long) this.BsGetBits(24);

  private void HbCreateDecodeTables(
    int[] limit,
    int[] basev,
    int[] perm,
    byte[] length,
    int minLen,
    int maxLen,
    int alphaSize)
  {
    Array.Clear((Array) basev, 0, basev.Length);
    Array.Clear((Array) limit, 0, limit.Length);
    int num1 = 0;
    int num2 = 0;
    for (int index1 = minLen; index1 <= maxLen; ++index1)
    {
      for (int index2 = 0; index2 < alphaSize; ++index2)
      {
        if ((int) length[index2] == index1)
          perm[num1++] = index2;
      }
      basev[index1] = num2;
      limit[index1] = num2 + num1;
      num2 += num2 + num1;
    }
  }

  private int RecvDecodingTables()
  {
    this.nInUse = 0;
    int bits1 = this.BsGetBits(16 /*0x10*/);
    for (int index1 = 0; index1 < 16 /*0x10*/; ++index1)
    {
      if ((bits1 & 32768 /*0x8000*/ >> index1) != 0)
      {
        int bits2 = this.BsGetBits(16 /*0x10*/);
        int num = index1 * 16 /*0x10*/;
        for (int index2 = 0; index2 < 16 /*0x10*/; ++index2)
        {
          if ((bits2 & 32768 /*0x8000*/ >> index2) != 0)
            this.seqToUnseq[this.nInUse++] = (byte) (num + index2);
        }
      }
    }
    if (this.nInUse < 1)
      throw new InvalidOperationException();
    int alphaSize = this.nInUse + 2;
    int bitsSmall1 = this.BsGetBitsSmall(3);
    switch (bitsSmall1)
    {
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
        int bits3 = this.BsGetBits(15);
        if (bits3 < 1)
          throw new InvalidOperationException();
        uint num1 = 5517840;
        for (int index = 0; index < bits3; ++index)
        {
          int num2 = 0;
          while (this.BsGetBit() == 1)
          {
            if (++num2 >= bitsSmall1)
              throw new InvalidOperationException();
          }
          if (index < 18002)
          {
            switch (num2)
            {
              case 0:
                this.m_selectors[index] = (byte) (num1 & 15U);
                continue;
              case 1:
                num1 = (uint) ((int) (num1 >> 4) & 15 | (int) num1 << 4 & 240 /*0xF0*/ | (int) num1 & 16776960);
                goto case 0;
              case 2:
                num1 = (uint) ((int) (num1 >> 8) & 15 | (int) num1 << 4 & 4080 | (int) num1 & 16773120);
                goto case 0;
              case 3:
                num1 = (uint) ((int) (num1 >> 12) & 15 | (int) num1 << 4 & 65520 | (int) num1 & 16711680 /*0xFF0000*/);
                goto case 0;
              case 4:
                num1 = (uint) ((int) (num1 >> 16 /*0x10*/) & 15 | (int) num1 << 4 & 1048560 | (int) num1 & 15728640 /*0xF00000*/);
                goto case 0;
              case 5:
                num1 = (uint) ((int) (num1 >> 20) & 15 | (int) num1 << 4 & 16777200);
                goto case 0;
              default:
                throw new InvalidOperationException();
            }
          }
        }
        byte[] length = new byte[alphaSize];
        for (int index3 = 0; index3 < bitsSmall1; ++index3)
        {
          int num3 = 0;
          int num4 = 32 /*0x20*/;
          int bitsSmall2 = this.BsGetBitsSmall(5);
          if (bitsSmall2 < 1 | bitsSmall2 > 20)
            throw new InvalidOperationException();
          for (int index4 = 0; index4 < alphaSize; ++index4)
          {
            int bitsSmall3;
            for (int index5 = this.BsGetBit(); index5 != 0; index5 = bitsSmall3 & 1)
            {
              bitsSmall3 = this.BsGetBitsSmall(2);
              bitsSmall2 += 1 - (bitsSmall3 & 2);
              if (bitsSmall2 < 1 | bitsSmall2 > 20)
                throw new InvalidOperationException();
            }
            length[index4] = (byte) bitsSmall2;
            num3 = Math.Max(num3, bitsSmall2);
            num4 = Math.Min(num4, bitsSmall2);
          }
          this.HbCreateDecodeTables(this.limit[index3], this.basev[index3], this.perm[index3], length, num4, num3, alphaSize);
          this.minLens[index3] = num4;
        }
        return bits3;
      default:
        throw new InvalidOperationException();
    }
  }

  private void GetAndMoveToFrontDecode()
  {
    int num1 = 100000 * this.blockSize100k;
    this.origPtr = this.BsGetBits(24);
    if (this.origPtr > 10 + num1)
      throw new InvalidOperationException();
    int num2 = this.RecvDecodingTables();
    int num3 = this.nInUse + 2;
    int num4 = this.nInUse + 1;
    Array.Clear((Array) this.unzftab, 0, this.unzftab.Length);
    byte[] numArray1 = new byte[this.nInUse];
    for (int index = 0; index < this.nInUse; ++index)
      numArray1[index] = this.seqToUnseq[index];
    this.last = -1;
    int index1 = 0;
    int num5 = 49;
    int selector1 = (int) this.m_selectors[0];
    int minLen = this.minLens[selector1];
    int[] numArray2 = this.limit[selector1];
    int[] numArray3 = this.perm[selector1];
    int[] numArray4 = this.basev[selector1];
    int index2 = minLen;
    int num6;
    for (num6 = this.BsGetBits(minLen); num6 >= numArray2[index2]; num6 = num6 << 1 | this.BsGetBit())
    {
      if (++index2 > 20)
        throw new InvalidOperationException();
    }
    int index3 = num6 - numArray4[index2];
    int num7 = index3 < num3 ? numArray3[index3] : throw new InvalidOperationException();
label_43:
    while (num7 != num4)
    {
      if (num7 <= 1)
      {
        int num8 = 1;
        int num9 = 0;
        while (num8 <= 1048576 /*0x100000*/)
        {
          num9 += num8 << num7;
          num8 <<= 1;
          if (num5 == 0)
          {
            if (++index1 >= num2)
              throw new InvalidOperationException();
            num5 = 50;
            int selector2 = (int) this.m_selectors[index1];
            minLen = this.minLens[selector2];
            numArray2 = this.limit[selector2];
            numArray3 = this.perm[selector2];
            numArray4 = this.basev[selector2];
          }
          --num5;
          int index4 = minLen;
          int num10;
          for (num10 = this.BsGetBits(minLen); num10 >= numArray2[index4]; num10 = num10 << 1 | this.BsGetBit())
          {
            if (++index4 > 20)
              throw new InvalidOperationException();
          }
          int index5 = num10 - numArray4[index4];
          num7 = index5 < num3 ? numArray3[index5] : throw new InvalidOperationException();
          if (num7 > 1)
          {
            byte index6 = numArray1[0];
            this.unzftab[(int) index6] += num9;
            if (this.last >= num1 - num9)
              throw new InvalidOperationException("Block overrun");
            while (--num9 >= 0)
              this.ll8[++this.last] = index6;
            goto label_43;
          }
        }
        throw new InvalidOperationException();
      }
      if (++this.last >= num1)
        throw new InvalidOperationException("Block overrun");
      byte index7 = numArray1[num7 - 1];
      ++this.unzftab[(int) index7];
      this.ll8[this.last] = index7;
      if (num7 <= 16 /*0x10*/)
      {
        for (int index8 = num7 - 1; index8 > 0; --index8)
          numArray1[index8] = numArray1[index8 - 1];
      }
      else
        Array.Copy((Array) numArray1, 0, (Array) numArray1, 1, num7 - 1);
      numArray1[0] = index7;
      if (num5 == 0)
      {
        if (++index1 >= num2)
          throw new InvalidOperationException();
        num5 = 50;
        int selector3 = (int) this.m_selectors[index1];
        minLen = this.minLens[selector3];
        numArray2 = this.limit[selector3];
        numArray3 = this.perm[selector3];
        numArray4 = this.basev[selector3];
      }
      --num5;
      int index9 = minLen;
      int num11;
      for (num11 = this.BsGetBits(minLen); num11 >= numArray2[index9]; num11 = num11 << 1 | this.BsGetBit())
      {
        if (++index9 > 20)
          throw new InvalidOperationException();
      }
      int index10 = num11 - numArray4[index9];
      num7 = index10 < num3 ? numArray3[index10] : throw new InvalidOperationException();
    }
    if (this.origPtr > this.last)
      throw new InvalidOperationException();
    int num12 = this.last + 1;
    int num13 = 0;
    for (int index11 = 0; index11 <= (int) byte.MaxValue; ++index11)
    {
      int num14 = this.unzftab[index11];
      num13 = num13 | num14 | num12 - num14;
    }
    if (num13 < 0)
      throw new InvalidOperationException();
  }

  private int RequireByte()
  {
    int num = this.bsStream.ReadByte();
    if (num < 0)
      throw new EndOfStreamException();
    return num & (int) byte.MaxValue;
  }

  private void SetupRandPartA()
  {
    if (this.i2 <= this.last)
    {
      this.chPrev = this.ch2;
      this.ch2 = (int) this.ll8[this.tPos];
      this.tPos = this.tt[this.tPos];
      if (this.rNToGo == 0)
      {
        this.rNToGo = (int) CBZip2OutputStream.RNums[this.rTPos++];
        this.rTPos &= 511 /*0x01FF*/;
      }
      --this.rNToGo;
      this.ch2 ^= this.rNToGo == 1 ? 1 : 0;
      ++this.i2;
      this.currentByte = this.ch2;
      this.currentState = 1;
      this.m_blockCrc.Update((byte) this.ch2);
    }
    else
    {
      this.EndBlock();
      this.BeginBlock();
    }
  }

  private void SetupNoRandPartA()
  {
    if (this.i2 <= this.last)
    {
      this.chPrev = this.ch2;
      this.ch2 = (int) this.ll8[this.tPos];
      this.tPos = this.tt[this.tPos];
      ++this.i2;
      this.currentByte = this.ch2;
      this.currentState = 3;
      this.m_blockCrc.Update((byte) this.ch2);
    }
    else
    {
      this.EndBlock();
      this.BeginBlock();
    }
  }

  private void SetupRandPartB()
  {
    if (this.ch2 != this.chPrev)
    {
      this.count = 1;
      this.SetupRandPartA();
    }
    else if (++this.count < 4)
    {
      this.SetupRandPartA();
    }
    else
    {
      this.z = (int) this.ll8[this.tPos];
      this.tPos = this.tt[this.tPos];
      if (this.rNToGo == 0)
      {
        this.rNToGo = (int) CBZip2OutputStream.RNums[this.rTPos++];
        this.rTPos &= 511 /*0x01FF*/;
      }
      --this.rNToGo;
      this.z ^= this.rNToGo == 1 ? 1 : 0;
      this.j2 = 0;
      this.currentState = 2;
      this.SetupRandPartC();
    }
  }

  private void SetupNoRandPartB()
  {
    if (this.ch2 != this.chPrev)
    {
      this.count = 1;
      this.SetupNoRandPartA();
    }
    else if (++this.count < 4)
    {
      this.SetupNoRandPartA();
    }
    else
    {
      this.z = (int) this.ll8[this.tPos];
      this.tPos = this.tt[this.tPos];
      this.currentState = 4;
      this.j2 = 0;
      this.SetupNoRandPartC();
    }
  }

  private void SetupRandPartC()
  {
    if (this.j2 < this.z)
    {
      this.currentByte = this.ch2;
      this.m_blockCrc.Update((byte) this.ch2);
      ++this.j2;
    }
    else
    {
      ++this.i2;
      this.count = 0;
      this.SetupRandPartA();
    }
  }

  private void SetupNoRandPartC()
  {
    if (this.j2 < this.z)
    {
      this.currentByte = this.ch2;
      this.m_blockCrc.Update((byte) this.ch2);
      ++this.j2;
    }
    else
    {
      ++this.i2;
      this.count = 0;
      this.SetupNoRandPartA();
    }
  }

  internal static int[][] CreateIntArray(int n1, int n2)
  {
    int[][] intArray = new int[n1][];
    for (int index = 0; index < n1; ++index)
      intArray[index] = new int[n2];
    return intArray;
  }
}
