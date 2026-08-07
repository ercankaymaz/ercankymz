// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Utilities.SshBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Crypto.Utilities;

internal class SshBuilder
{
  private readonly MemoryStream bos = new MemoryStream();

  public void U32(uint value)
  {
    this.bos.WriteByte(Convert.ToByte(value >> 24 & (uint) byte.MaxValue));
    this.bos.WriteByte(Convert.ToByte(value >> 16 /*0x10*/ & (uint) byte.MaxValue));
    this.bos.WriteByte(Convert.ToByte(value >> 8 & (uint) byte.MaxValue));
    this.bos.WriteByte(Convert.ToByte(value & (uint) byte.MaxValue));
  }

  public void WriteMpint(BigInteger n) => this.WriteBlock(n.ToByteArray());

  public void WriteBlock(byte[] value)
  {
    this.U32((uint) value.Length);
    this.WriteBytes(value);
  }

  public void WriteBytes(byte[] value)
  {
    try
    {
      this.bos.Write(value, 0, value.Length);
    }
    catch (IOException ex)
    {
      throw new InvalidOperationException(ex.Message, (Exception) ex);
    }
  }

  public void WriteStringAscii(string str) => this.WriteBlock(Encoding.ASCII.GetBytes(str));

  public void WriteStringUtf8(string str) => this.WriteBlock(Encoding.UTF8.GetBytes(str));

  public byte[] GetBytes() => this.bos.ToArray();

  public byte[] GetPaddedBytes() => this.GetPaddedBytes(8);

  public byte[] GetPaddedBytes(int blockSize)
  {
    int num1 = (int) this.bos.Length % blockSize;
    if (num1 != 0)
    {
      int num2 = blockSize - num1;
      for (int index = 1; index <= num2; ++index)
        this.bos.WriteByte(Convert.ToByte(index));
    }
    return this.bos.ToArray();
  }
}
