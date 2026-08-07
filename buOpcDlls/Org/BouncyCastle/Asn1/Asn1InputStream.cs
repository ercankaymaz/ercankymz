// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1InputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class Asn1InputStream : FilterStream
{
  private readonly int limit;
  private readonly bool m_leaveOpen;
  internal byte[][] tmpBuffers;

  internal static int FindLimit(Stream input)
  {
    switch (input)
    {
      case LimitedInputStream limitedInputStream:
        return limitedInputStream.Limit;
      case Asn1InputStream asn1InputStream:
        return asn1InputStream.limit;
      case MemoryStream memoryStream:
        return Convert.ToInt32(memoryStream.Length - memoryStream.Position);
      default:
        return int.MaxValue;
    }
  }

  public Asn1InputStream(byte[] input)
    : this((Stream) new MemoryStream(input, false), input.Length)
  {
  }

  public Asn1InputStream(Stream input)
    : this(input, Asn1InputStream.FindLimit(input))
  {
  }

  public Asn1InputStream(Stream input, int limit)
    : this(input, limit, false)
  {
  }

  public Asn1InputStream(Stream input, int limit, bool leaveOpen)
    : this(input, limit, leaveOpen, new byte[16 /*0x10*/][])
  {
  }

  internal Asn1InputStream(Stream input, int limit, bool leaveOpen, byte[][] tmpBuffers)
    : base(input)
  {
    if (!input.CanRead)
      throw new ArgumentException("Expected stream to be readable", nameof (input));
    this.limit = limit;
    this.m_leaveOpen = leaveOpen;
    this.tmpBuffers = tmpBuffers;
  }

  protected override void Dispose(bool disposing)
  {
    this.tmpBuffers = (byte[][]) null;
    if (this.m_leaveOpen)
      this.Detach(disposing);
    else
      base.Dispose(disposing);
  }

  private Asn1Object BuildObject(int tagHdr, int tagNo, int length)
  {
    DefiniteLengthInputStream defIn = new DefiniteLengthInputStream(this.s, length, this.limit);
    if ((tagHdr & 224 /*0xE0*/) == 0)
      return Asn1InputStream.CreatePrimitiveDerObject(tagNo, defIn, this.tmpBuffers);
    int tagClass = tagHdr & 192 /*0xC0*/;
    if (tagClass != 0)
    {
      bool constructed = (tagHdr & 32 /*0x20*/) != 0;
      return this.ReadTaggedObjectDL(tagClass, tagNo, constructed, defIn);
    }
    switch (tagNo)
    {
      case 3:
        return (Asn1Object) this.BuildConstructedBitString(this.ReadVector(defIn));
      case 4:
        return (Asn1Object) this.BuildConstructedOctetString(this.ReadVector(defIn));
      case 8:
        return (Asn1Object) DLSequence.FromVector(this.ReadVector(defIn)).ToAsn1External();
      case 16 /*0x10*/:
        return (Asn1Object) DLSequence.FromVector(this.ReadVector(defIn));
      case 17:
        return (Asn1Object) DLSet.FromVector(this.ReadVector(defIn));
      default:
        throw new IOException($"unknown tag {tagNo.ToString()} encountered");
    }
  }

  internal Asn1Object ReadTaggedObjectDL(
    int tagClass,
    int tagNo,
    bool constructed,
    DefiniteLengthInputStream defIn)
  {
    if (!constructed)
    {
      byte[] array = defIn.ToArray();
      return Asn1TaggedObject.CreatePrimitive(tagClass, tagNo, array);
    }
    Asn1EncodableVector contentsElements = this.ReadVector(defIn);
    return Asn1TaggedObject.CreateConstructedDL(tagClass, tagNo, contentsElements);
  }

  private Asn1EncodableVector ReadVector()
  {
    Asn1Object element = this.ReadObject();
    if (element == null)
      return new Asn1EncodableVector(0);
    Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector();
    do
    {
      asn1EncodableVector.Add((Asn1Encodable) element);
    }
    while ((element = this.ReadObject()) != null);
    return asn1EncodableVector;
  }

  private Asn1EncodableVector ReadVector(DefiniteLengthInputStream defIn)
  {
    int remaining = defIn.Remaining;
    if (remaining < 1)
      return new Asn1EncodableVector(0);
    using (Asn1InputStream asn1InputStream = new Asn1InputStream((Stream) defIn, remaining, true, this.tmpBuffers))
      return asn1InputStream.ReadVector();
  }

  public Asn1Object ReadObject()
  {
    int tagHdr = this.s.ReadByte();
    if (tagHdr <= 0)
    {
      if (tagHdr == 0)
        throw new IOException("unexpected end-of-contents marker");
      return (Asn1Object) null;
    }
    int tagNo = Asn1InputStream.ReadTagNumber(this.s, tagHdr);
    int length = Asn1InputStream.ReadLength(this.s, this.limit, false);
    if (length >= 0)
    {
      try
      {
        return this.BuildObject(tagHdr, tagNo, length);
      }
      catch (ArgumentException ex)
      {
        throw new Asn1Exception("corrupted stream detected", (Exception) ex);
      }
    }
    else
    {
      if ((tagHdr & 32 /*0x20*/) == 0)
        throw new IOException("indefinite-length primitive encoding encountered");
      Asn1StreamParser sp = new Asn1StreamParser((Stream) new IndefiniteLengthInputStream(this.s, this.limit), this.limit, this.tmpBuffers);
      int tagClass = tagHdr & 192 /*0xC0*/;
      if (tagClass != 0)
        return sp.LoadTaggedIL(tagClass, tagNo);
      switch (tagNo)
      {
        case 3:
          return (Asn1Object) BerBitStringParser.Parse(sp);
        case 4:
          return (Asn1Object) BerOctetStringParser.Parse(sp);
        case 8:
          return (Asn1Object) DerExternalParser.Parse(sp);
        case 16 /*0x10*/:
          return (Asn1Object) BerSequenceParser.Parse(sp);
        case 17:
          return (Asn1Object) BerSetParser.Parse(sp);
        default:
          throw new IOException("unknown BER object encountered");
      }
    }
  }

  private DerBitString BuildConstructedBitString(Asn1EncodableVector contentsElements)
  {
    DerBitString[] bitStrings = new DerBitString[contentsElements.Count];
    for (int index = 0; index != bitStrings.Length; ++index)
    {
      if (!(contentsElements[index] is DerBitString contentsElement))
        throw new Asn1Exception("unknown object encountered in constructed BIT STRING: " + Platform.GetTypeName((object) contentsElements[index]));
      bitStrings[index] = contentsElement;
    }
    return (DerBitString) new DLBitString(BerBitString.FlattenBitStrings(bitStrings), false);
  }

  private Asn1OctetString BuildConstructedOctetString(Asn1EncodableVector contentsElements)
  {
    Asn1OctetString[] octetStrings = new Asn1OctetString[contentsElements.Count];
    for (int index = 0; index != octetStrings.Length; ++index)
    {
      if (!(contentsElements[index] is Asn1OctetString contentsElement))
        throw new Asn1Exception("unknown object encountered in constructed OCTET STRING: " + Platform.GetTypeName((object) contentsElements[index]));
      octetStrings[index] = contentsElement;
    }
    return (Asn1OctetString) new DerOctetString(BerOctetString.FlattenOctetStrings(octetStrings));
  }

  internal static int ReadTagNumber(Stream s, int tagHdr)
  {
    int num1 = tagHdr & 31 /*0x1F*/;
    if (num1 == 31 /*0x1F*/)
    {
      int num2 = s.ReadByte();
      if (num2 < 31 /*0x1F*/)
      {
        if (num2 < 0)
          throw new EndOfStreamException("EOF found inside tag value.");
        throw new IOException("corrupted stream - high tag number < 31 found");
      }
      num1 = num2 & (int) sbyte.MaxValue;
      if (num1 == 0)
        throw new IOException("corrupted stream - invalid high tag number found");
      while ((num2 & 128 /*0x80*/) != 0)
      {
        if (num1 >>> 24 != 0)
          throw new IOException("Tag number more than 31 bits");
        int num3 = num1 << 7;
        num2 = s.ReadByte();
        if (num2 < 0)
          throw new EndOfStreamException("EOF found inside tag value.");
        num1 = num3 | num2 & (int) sbyte.MaxValue;
      }
    }
    return num1;
  }

  internal static int ReadLength(Stream s, int limit, bool isParsing)
  {
    int num1 = s.ReadByte();
    if (num1 >>> 7 == 0)
      return num1;
    if (128 /*0x80*/ == num1)
      return -1;
    if (num1 < 0)
      throw new EndOfStreamException("EOF found when length expected");
    if ((int) byte.MaxValue == num1)
      throw new IOException("invalid long form definite-length 0xFF");
    int num2 = num1 & (int) sbyte.MaxValue;
    int num3 = 0;
    int num4 = 0;
    do
    {
      int num5 = s.ReadByte();
      if (num5 >= 0)
      {
        if (num4 >>> 23 == 0)
          num4 = (num4 << 8) + num5;
        else
          goto label_13;
      }
      else
        goto label_12;
    }
    while (++num3 < num2);
    goto label_14;
label_12:
    throw new EndOfStreamException("EOF found reading length");
label_13:
    throw new IOException("long form definite-length more than 31 bits");
label_14:
    if (num4 >= limit && !isParsing)
      throw new IOException($"corrupted stream - out of bounds length found: {num4.ToString()} >= {limit.ToString()}");
    return num4;
  }

  private static bool GetBuffer(
    DefiniteLengthInputStream defIn,
    byte[][] tmpBuffers,
    out byte[] contents)
  {
    int remaining = defIn.Remaining;
    if (remaining >= tmpBuffers.Length)
    {
      contents = defIn.ToArray();
      return false;
    }
    byte[] buf = tmpBuffers[remaining] ?? (tmpBuffers[remaining] = new byte[remaining]);
    defIn.ReadAllIntoByteArray(buf);
    contents = buf;
    return true;
  }

  internal static Asn1Object CreatePrimitiveDerObject(
    int tagNo,
    DefiniteLengthInputStream defIn,
    byte[][] tmpBuffers)
  {
    switch (tagNo)
    {
      case 1:
        byte[] contents1;
        Asn1InputStream.GetBuffer(defIn, tmpBuffers, out contents1);
        return (Asn1Object) DerBoolean.CreatePrimitive(contents1);
      case 6:
        byte[] contents2;
        bool buffer1 = Asn1InputStream.GetBuffer(defIn, tmpBuffers, out contents2);
        return (Asn1Object) DerObjectIdentifier.CreatePrimitive(contents2, buffer1);
      case 10:
        byte[] contents3;
        bool buffer2 = Asn1InputStream.GetBuffer(defIn, tmpBuffers, out contents3);
        return (Asn1Object) DerEnumerated.CreatePrimitive(contents3, buffer2);
      case 30:
        return (Asn1Object) Asn1InputStream.CreateDerBmpString(defIn);
      default:
        byte[] array = defIn.ToArray();
        switch (tagNo - 2)
        {
          case 0:
            return (Asn1Object) DerInteger.CreatePrimitive(array);
          case 1:
            return (Asn1Object) DerBitString.CreatePrimitive(array);
          case 2:
            return (Asn1Object) Asn1OctetString.CreatePrimitive(array);
          case 3:
            return (Asn1Object) Asn1Null.CreatePrimitive(array);
          case 5:
            return (Asn1Object) Asn1ObjectDescriptor.CreatePrimitive(array);
          case 7:
          case 9:
          case 12:
          case 27:
          case 29:
          case 30:
          case 31 /*0x1F*/:
          case 32 /*0x20*/:
          case 33:
          case 34:
            throw new IOException($"unsupported tag {tagNo.ToString()} encountered");
          case 10:
            return (Asn1Object) DerUtf8String.CreatePrimitive(array);
          case 11:
            return (Asn1Object) Asn1RelativeOid.CreatePrimitive(array, false);
          case 16 /*0x10*/:
            return (Asn1Object) DerNumericString.CreatePrimitive(array);
          case 17:
            return (Asn1Object) DerPrintableString.CreatePrimitive(array);
          case 18:
            return (Asn1Object) DerT61String.CreatePrimitive(array);
          case 19:
            return (Asn1Object) DerVideotexString.CreatePrimitive(array);
          case 20:
            return (Asn1Object) DerIA5String.CreatePrimitive(array);
          case 21:
            return (Asn1Object) Asn1UtcTime.CreatePrimitive(array);
          case 22:
            return (Asn1Object) Asn1GeneralizedTime.CreatePrimitive(array);
          case 23:
            return (Asn1Object) DerGraphicString.CreatePrimitive(array);
          case 24:
            return (Asn1Object) DerVisibleString.CreatePrimitive(array);
          case 25:
            return (Asn1Object) DerGeneralString.CreatePrimitive(array);
          case 26:
            return (Asn1Object) DerUniversalString.CreatePrimitive(array);
          default:
            throw new IOException($"unknown tag {tagNo.ToString()} encountered");
        }
    }
  }

  private static DerBmpString CreateDerBmpString(DefiniteLengthInputStream defIn)
  {
    int remaining = defIn.Remaining;
    char[] str = (remaining & 1) == 0 ? new char[remaining / 2] : throw new IOException("malformed BMPString encoding encountered");
    int index1 = 0;
    byte[] buf = new byte[8];
    for (; remaining >= 8; remaining -= 8)
    {
      if (Streams.ReadFully((Stream) defIn, buf, 0, 8) != 8)
        throw new EndOfStreamException("EOF encountered in middle of BMPString");
      str[index1] = (char) ((int) buf[0] << 8 | (int) buf[1] & (int) byte.MaxValue);
      str[index1 + 1] = (char) ((int) buf[2] << 8 | (int) buf[3] & (int) byte.MaxValue);
      str[index1 + 2] = (char) ((int) buf[4] << 8 | (int) buf[5] & (int) byte.MaxValue);
      str[index1 + 3] = (char) ((int) buf[6] << 8 | (int) buf[7] & (int) byte.MaxValue);
      index1 += 4;
    }
    if (remaining > 0)
    {
      if (Streams.ReadFully((Stream) defIn, buf, 0, remaining) != remaining)
        throw new EndOfStreamException("EOF encountered in middle of BMPString");
      int num1 = 0;
      do
      {
        byte[] numArray1 = buf;
        int index2 = num1;
        int num2 = index2 + 1;
        int num3 = (int) numArray1[index2] << 8;
        byte[] numArray2 = buf;
        int index3 = num2;
        num1 = index3 + 1;
        int num4 = (int) numArray2[index3] & (int) byte.MaxValue;
        str[index1++] = (char) (num3 | num4);
      }
      while (num1 < remaining);
    }
    if (defIn.Remaining != 0 || str.Length != index1)
      throw new InvalidOperationException();
    return DerBmpString.CreatePrimitive(str);
  }
}
