// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Encoders.BufferedDecoder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Utilities.Encoders;

public class BufferedDecoder
{
  internal byte[] buffer;
  internal int bufOff;
  internal ITranslator translator;

  public BufferedDecoder(ITranslator translator, int bufferSize)
  {
    this.translator = translator;
    this.buffer = bufferSize % translator.GetEncodedBlockSize() == 0 ? new byte[bufferSize] : throw new ArgumentException("buffer size not multiple of input block size");
  }

  public int ProcessByte(byte input, byte[] output, int outOff)
  {
    int num = 0;
    this.buffer[this.bufOff++] = input;
    if (this.bufOff == this.buffer.Length)
    {
      num = this.translator.Decode(this.buffer, 0, this.buffer.Length, output, outOff);
      this.bufOff = 0;
    }
    return num;
  }

  public int ProcessBytes(byte[] input, int inOff, int len, byte[] outBytes, int outOff)
  {
    if (len < 0)
      throw new ArgumentException("Can't have a negative input length!");
    int num1 = 0;
    int length1 = this.buffer.Length - this.bufOff;
    if (len > length1)
    {
      Array.Copy((Array) input, inOff, (Array) this.buffer, this.bufOff, length1);
      int num2 = num1 + this.translator.Decode(this.buffer, 0, this.buffer.Length, outBytes, outOff);
      this.bufOff = 0;
      len -= length1;
      inOff += length1;
      outOff += num2;
      int length2 = len - len % this.buffer.Length;
      num1 = num2 + this.translator.Decode(input, inOff, length2, outBytes, outOff);
      len -= length2;
      inOff += length2;
    }
    if (len != 0)
    {
      Array.Copy((Array) input, inOff, (Array) this.buffer, this.bufOff, len);
      this.bufOff += len;
    }
    return num1;
  }
}
