// Decompiled with JetBrains decompiler
// Type: PdfSharp.SharpZipLib.Checksums.Adler32
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.SharpZipLib.Checksums;

internal sealed class Adler32 : IChecksum
{
  private const uint BASE = 65521;
  private uint checksum;

  public long Value => (long) this.checksum;

  public Adler32() => this.Reset();

  public void Reset() => this.checksum = 1U;

  public void Update(int value)
  {
    uint num1 = this.checksum & (uint) ushort.MaxValue;
    uint num2 = this.checksum >> 16 /*0x10*/;
    uint num3 = (num1 + (uint) (value & (int) byte.MaxValue)) % 65521U;
    this.checksum = ((num3 + num2) % 65521U << 16 /*0x10*/) + num3;
  }

  public void Update(byte[] buffer)
  {
    if (buffer == null)
      throw new ArgumentNullException(nameof (buffer));
    this.Update(buffer, 0, buffer.Length);
  }

  public void Update(byte[] buffer, int offset, int count)
  {
    if (buffer == null)
      throw new ArgumentNullException(nameof (buffer));
    if (offset < 0)
      throw new ArgumentOutOfRangeException(nameof (offset), "cannot be negative");
    if (count < 0)
      throw new ArgumentOutOfRangeException(nameof (count), "cannot be negative");
    if (offset >= buffer.Length)
      throw new ArgumentOutOfRangeException(nameof (offset), "not a valid index into buffer");
    if (offset + count > buffer.Length)
      throw new ArgumentOutOfRangeException(nameof (count), "exceeds buffer size");
    uint num1 = this.checksum & (uint) ushort.MaxValue;
    uint num2 = this.checksum >> 16 /*0x10*/;
    while (count > 0)
    {
      int num3 = 3800;
      if (3800 > count)
        num3 = count;
      count -= num3;
      while (--num3 >= 0)
      {
        num1 += (uint) buffer[offset++] & (uint) byte.MaxValue;
        num2 += num1;
      }
      num1 %= 65521U;
      num2 %= 65521U;
    }
    this.checksum = num2 << 16 /*0x10*/ | num1;
  }
}
