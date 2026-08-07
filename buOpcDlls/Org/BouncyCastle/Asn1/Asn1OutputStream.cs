// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1OutputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class Asn1OutputStream : FilterStream
{
  internal const int EncodingBer = 1;
  internal const int EncodingDer = 2;
  private readonly bool m_leaveOpen;

  public static Asn1OutputStream Create(Stream output) => Asn1OutputStream.Create(output, "BER");

  public static Asn1OutputStream Create(Stream output, string encoding)
  {
    return Asn1OutputStream.Create(output, encoding, false);
  }

  public static Asn1OutputStream Create(Stream output, string encoding, bool leaveOpen)
  {
    return "DER".Equals(encoding) ? (Asn1OutputStream) new DerOutputStream(output, leaveOpen) : new Asn1OutputStream(output, leaveOpen);
  }

  internal static int GetEncodingType(string encoding) => "DER".Equals(encoding) ? 2 : 1;

  protected internal Asn1OutputStream(Stream output, bool leaveOpen)
    : base(output)
  {
    if (!output.CanWrite)
      throw new ArgumentException("Expected stream to be writable", nameof (output));
    this.m_leaveOpen = leaveOpen;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
      this.FlushInternal();
    if (this.m_leaveOpen)
      this.Detach(disposing);
    else
      base.Dispose(disposing);
  }

  public virtual void WriteObject(Asn1Encodable asn1Encodable)
  {
    if (asn1Encodable == null)
      throw new ArgumentNullException(nameof (asn1Encodable));
    asn1Encodable.ToAsn1Object().GetEncoding(this.Encoding).Encode(this);
    this.FlushInternal();
  }

  public virtual void WriteObject(Asn1Object asn1Object)
  {
    if (asn1Object == null)
      throw new ArgumentNullException(nameof (asn1Object));
    asn1Object.GetEncoding(this.Encoding).Encode(this);
    this.FlushInternal();
  }

  internal void EncodeContents(IAsn1Encoding[] contentsEncodings)
  {
    int index = 0;
    for (int length = contentsEncodings.Length; index < length; ++index)
      contentsEncodings[index].Encode(this);
  }

  internal virtual int Encoding => 1;

  private void FlushInternal()
  {
  }

  internal void WriteDL(int dl)
  {
    if (dl < 128 /*0x80*/)
    {
      this.WriteByte((byte) dl);
    }
    else
    {
      byte[] buffer = new byte[5];
      int length = buffer.Length;
      do
      {
        buffer[--length] = (byte) dl;
        dl >>= 8;
      }
      while (dl > 0);
      int num = buffer.Length - length;
      int offset;
      buffer[offset = length - 1] = (byte) (128 /*0x80*/ | num);
      this.Write(buffer, offset, num + 1);
    }
  }

  internal void WriteIdentifier(int flags, int tagNo)
  {
    if (tagNo < 31 /*0x1F*/)
    {
      this.WriteByte((byte) (flags | tagNo));
    }
    else
    {
      byte[] buffer = new byte[6];
      int length = buffer.Length;
      int num;
      buffer[num = length - 1] = (byte) (tagNo & (int) sbyte.MaxValue);
      while (tagNo > (int) sbyte.MaxValue)
      {
        tagNo >>= 7;
        buffer[--num] = (byte) (tagNo & (int) sbyte.MaxValue | 128 /*0x80*/);
      }
      int offset;
      buffer[offset = num - 1] = (byte) (flags | 31 /*0x1F*/);
      this.Write(buffer, offset, buffer.Length - offset);
    }
  }

  internal static IAsn1Encoding[] GetContentsEncodings(int encoding, Asn1Encodable[] elements)
  {
    int length = elements.Length;
    IAsn1Encoding[] contentsEncodings = new IAsn1Encoding[length];
    for (int index = 0; index < length; ++index)
      contentsEncodings[index] = elements[index].ToAsn1Object().GetEncoding(encoding);
    return contentsEncodings;
  }

  internal static DerEncoding[] GetContentsEncodingsDer(Asn1Encodable[] elements)
  {
    int length = elements.Length;
    DerEncoding[] contentsEncodingsDer = new DerEncoding[length];
    for (int index = 0; index < length; ++index)
      contentsEncodingsDer[index] = elements[index].ToAsn1Object().GetEncodingDer();
    return contentsEncodingsDer;
  }

  internal static int GetLengthOfContents(IAsn1Encoding[] contentsEncodings)
  {
    int lengthOfContents = 0;
    int index = 0;
    for (int length = contentsEncodings.Length; index < length; ++index)
      lengthOfContents += contentsEncodings[index].GetLength();
    return lengthOfContents;
  }

  internal static int GetLengthOfDL(int dl)
  {
    if (dl < 128 /*0x80*/)
      return 1;
    int lengthOfDl = 2;
    while ((dl >>= 8) > 0)
      ++lengthOfDl;
    return lengthOfDl;
  }

  internal static int GetLengthOfEncodingDL(int tagNo, int contentsLength)
  {
    return Asn1OutputStream.GetLengthOfIdentifier(tagNo) + Asn1OutputStream.GetLengthOfDL(contentsLength) + contentsLength;
  }

  internal static int GetLengthOfEncodingIL(int tagNo, IAsn1Encoding[] contentsEncodings)
  {
    return Asn1OutputStream.GetLengthOfIdentifier(tagNo) + 3 + Asn1OutputStream.GetLengthOfContents(contentsEncodings);
  }

  internal static int GetLengthOfIdentifier(int tagNo)
  {
    if (tagNo < 31 /*0x1F*/)
      return 1;
    int lengthOfIdentifier = 2;
    while ((tagNo >>= 7) > 0)
      ++lengthOfIdentifier;
    return lengthOfIdentifier;
  }
}
