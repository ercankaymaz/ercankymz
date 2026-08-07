// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Utilities.SshBuffer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Crypto.Utilities;

internal class SshBuffer
{
  private readonly byte[] buffer;
  private int pos;

  internal SshBuffer(byte[] magic, byte[] buffer)
  {
    this.buffer = buffer;
    for (int index = 0; index != magic.Length; ++index)
    {
      if ((int) magic[index] != (int) buffer[index])
        throw new ArgumentException("magic-number incorrect");
    }
    this.pos += magic.Length;
  }

  internal SshBuffer(byte[] buffer) => this.buffer = buffer;

  public int ReadU32()
  {
    if (this.pos > this.buffer.Length - 4)
      throw new ArgumentOutOfRangeException("4 bytes for U32 exceeds buffer.");
    int uint32 = (int) Pack.BE_To_UInt32(this.buffer, this.pos);
    this.pos += 4;
    return uint32;
  }

  public string ReadStringAscii() => Encoding.ASCII.GetString(this.ReadBlock());

  public string ReadStringUtf8() => Encoding.UTF8.GetString(this.ReadBlock());

  public byte[] ReadBlock()
  {
    int num = this.ReadU32();
    if (num == 0)
      return Arrays.EmptyBytes;
    if (this.pos > this.buffer.Length - num)
      throw new InvalidOperationException("not enough data for block");
    int pos = this.pos;
    this.pos += num;
    return Arrays.CopyOfRange(this.buffer, pos, this.pos);
  }

  public void SkipBlock()
  {
    int num = this.ReadU32();
    if (this.pos > this.buffer.Length - num)
      throw new InvalidOperationException("not enough data for block");
    this.pos += num;
  }

  public byte[] ReadPaddedBlock() => this.ReadPaddedBlock(8);

  public byte[] ReadPaddedBlock(int blockSize)
  {
    int num1 = this.ReadU32();
    if (num1 == 0)
      return Arrays.EmptyBytes;
    if (this.pos > this.buffer.Length - num1)
      throw new InvalidOperationException("not enough data for block");
    if (num1 % blockSize != 0)
      throw new InvalidOperationException("missing padding");
    int pos1 = this.pos;
    this.pos += num1;
    int pos2 = this.pos;
    if (num1 > 0)
    {
      int num2 = (int) this.buffer[this.pos - 1] & (int) byte.MaxValue;
      if (0 < num2 && num2 < blockSize)
      {
        int num3 = num2;
        pos2 -= num3;
        int num4 = 1;
        int index = pos2;
        while (num4 <= num3)
        {
          if (num4 != ((int) this.buffer[index] & (int) byte.MaxValue))
            throw new InvalidOperationException("incorrect padding");
          ++num4;
          ++index;
        }
      }
    }
    return Arrays.CopyOfRange(this.buffer, pos1, pos2);
  }

  public BigInteger ReadMpint()
  {
    int length = this.ReadU32();
    if (this.pos > this.buffer.Length - length)
      throw new InvalidOperationException("not enough data for big num");
    switch (length)
    {
      case 0:
        return BigInteger.Zero;
      case 1:
        if (this.buffer[this.pos] == (byte) 0)
          throw new InvalidOperationException("Zero MUST be stored with length 0");
        break;
    }
    if (length > 1 && (int) this.buffer[this.pos] == (int) (byte) -((int) this.buffer[this.pos + 1] >> 7))
      throw new InvalidOperationException("Unnecessary leading bytes MUST NOT be included");
    int pos = this.pos;
    this.pos += length;
    return new BigInteger(this.buffer, pos, length);
  }

  public BigInteger ReadMpintPositive()
  {
    BigInteger bigInteger = this.ReadMpint();
    return bigInteger.SignValue >= 0 ? bigInteger : throw new InvalidOperationException("Expected a positive mpint");
  }

  public bool HasRemaining() => this.pos < this.buffer.Length;
}
