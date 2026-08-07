// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Encoders.BufferedEncoder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Utilities.Encoders;

public class BufferedEncoder
{
  internal byte[] Buffer;
  internal int bufOff;
  internal ITranslator translator;

  public BufferedEncoder(ITranslator translator, int bufferSize)
  {
    this.translator = translator;
    this.Buffer = bufferSize % translator.GetEncodedBlockSize() == 0 ? new byte[bufferSize] : throw new ArgumentException("buffer size not multiple of input block size");
  }

  public int ProcessByte(byte input, byte[] outBytes, int outOff)
  {
    int num = 0;
    this.Buffer[this.bufOff++] = input;
    if (this.bufOff == this.Buffer.Length)
    {
      num = this.translator.Encode(this.Buffer, 0, this.Buffer.Length, outBytes, outOff);
      this.bufOff = 0;
    }
    return num;
  }

  public int ProcessBytes(byte[] input, int inOff, int len, byte[] outBytes, int outOff)
  {
    if (len < 0)
      throw new ArgumentException("Can't have a negative input length!");
    int num1 = 0;
    int length1 = this.Buffer.Length - this.bufOff;
    if (len > length1)
    {
      Array.Copy((Array) input, inOff, (Array) this.Buffer, this.bufOff, length1);
      int num2 = num1 + this.translator.Encode(this.Buffer, 0, this.Buffer.Length, outBytes, outOff);
      this.bufOff = 0;
      len -= length1;
      inOff += length1;
      outOff += num2;
      int length2 = len - len % this.Buffer.Length;
      num1 = num2 + this.translator.Encode(input, inOff, length2, outBytes, outOff);
      len -= length2;
      inOff += length2;
    }
    if (len != 0)
    {
      Array.Copy((Array) input, inOff, (Array) this.Buffer, this.bufOff, len);
      this.bufOff += len;
    }
    return num1;
  }
}
