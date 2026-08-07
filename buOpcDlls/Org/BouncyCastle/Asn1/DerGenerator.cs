// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public abstract class DerGenerator : Asn1Generator
{
  private bool _tagged;
  private bool _isExplicit;
  private int _tagNo;

  protected DerGenerator(Stream outStream)
    : base(outStream)
  {
  }

  protected DerGenerator(Stream outStream, int tagNo, bool isExplicit)
    : base(outStream)
  {
    this._tagged = true;
    this._isExplicit = isExplicit;
    this._tagNo = tagNo;
  }

  internal void WriteDerEncoded(int tag, byte[] bytes)
  {
    if (this._tagged)
    {
      int tag1 = this._tagNo | 128 /*0x80*/;
      if (this._isExplicit)
      {
        int tag2 = this._tagNo | 32 /*0x20*/ | 128 /*0x80*/;
        MemoryStream outStream = new MemoryStream();
        DerGenerator.WriteDerEncoded((Stream) outStream, tag, bytes);
        DerGenerator.WriteDerEncoded(this.OutStream, tag2, outStream.ToArray());
      }
      else
      {
        if ((tag & 32 /*0x20*/) != 0)
          tag1 |= 32 /*0x20*/;
        DerGenerator.WriteDerEncoded(this.OutStream, tag1, bytes);
      }
    }
    else
      DerGenerator.WriteDerEncoded(this.OutStream, tag, bytes);
  }

  internal static void WriteDerEncoded(Stream outStream, int tag, byte[] bytes)
  {
    outStream.WriteByte((byte) tag);
    DerGenerator.WriteLength(outStream, bytes.Length);
    outStream.Write(bytes, 0, bytes.Length);
  }

  internal static void WriteDerEncoded(Stream outStream, int tag, Stream inStream)
  {
    DerGenerator.WriteDerEncoded(outStream, tag, Streams.ReadAll(inStream));
  }

  private static void WriteLength(Stream outStream, int length)
  {
    if (length > (int) sbyte.MaxValue)
    {
      int num1 = 1;
      int num2 = length;
      while ((num2 >>= 8) != 0)
        ++num1;
      outStream.WriteByte((byte) (num1 | 128 /*0x80*/));
      for (int index = (num1 - 1) * 8; index >= 0; index -= 8)
        outStream.WriteByte((byte) (length >> index));
    }
    else
      outStream.WriteByte((byte) length);
  }
}
