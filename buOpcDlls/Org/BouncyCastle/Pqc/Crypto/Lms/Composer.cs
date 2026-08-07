// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.Composer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class Composer
{
  private readonly MemoryStream bos = new MemoryStream();

  private Composer()
  {
  }

  public static Composer Compose() => new Composer();

  public Composer U64Str(long n)
  {
    this.U32Str((int) (n >> 32 /*0x20*/));
    this.U32Str((int) n);
    return this;
  }

  public Composer U32Str(int n)
  {
    this.bos.WriteByte((byte) (n >> 24));
    this.bos.WriteByte((byte) (n >> 16 /*0x10*/));
    this.bos.WriteByte((byte) (n >> 8));
    this.bos.WriteByte((byte) n);
    return this;
  }

  public Composer U16Str(int n)
  {
    n &= (int) ushort.MaxValue;
    this.bos.WriteByte((byte) (n >> 8));
    this.bos.WriteByte((byte) n);
    return this;
  }

  public Composer Bytes(IEncodable[] encodable)
  {
    foreach (IEncodable encodable1 in encodable)
    {
      byte[] encoded = encodable1.GetEncoded();
      this.bos.Write(encoded, 0, encoded.Length);
    }
    return this;
  }

  public Composer Bytes(IEncodable encodable)
  {
    byte[] encoded = encodable.GetEncoded();
    this.bos.Write(encoded, 0, encoded.Length);
    return this;
  }

  public Composer Pad(int v, int len)
  {
    for (; len >= 0; --len)
      this.bos.WriteByte((byte) v);
    return this;
  }

  public Composer Bytes2(byte[][] arrays)
  {
    foreach (byte[] array in arrays)
      this.bos.Write(array, 0, array.Length);
    return this;
  }

  public Composer Bytes2(byte[][] arrays, int start, int end)
  {
    for (int index = start; index != end; ++index)
      this.bos.Write(arrays[index], 0, arrays[index].Length);
    return this;
  }

  public Composer Bytes(byte[] array)
  {
    this.bos.Write(array, 0, array.Length);
    return this;
  }

  public Composer Bytes(byte[] array, int start, int len)
  {
    this.bos.Write(array, start, len);
    return this;
  }

  public byte[] Build() => this.bos.ToArray();

  public Composer PadUntil(int v, int requiredLen)
  {
    while (this.bos.Length < (long) requiredLen)
      this.bos.WriteByte((byte) v);
    return this;
  }

  public Composer Boolean(bool v)
  {
    this.bos.WriteByte(v ? (byte) 1 : (byte) 0);
    return this;
  }
}
