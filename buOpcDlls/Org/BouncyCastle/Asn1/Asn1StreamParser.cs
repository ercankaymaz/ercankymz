// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1StreamParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class Asn1StreamParser
{
  private readonly Stream _in;
  private readonly int _limit;
  private readonly byte[][] tmpBuffers;

  public Asn1StreamParser(Stream input)
    : this(input, Asn1InputStream.FindLimit(input))
  {
  }

  public Asn1StreamParser(byte[] encoding)
    : this((Stream) new MemoryStream(encoding, false), encoding.Length)
  {
  }

  public Asn1StreamParser(Stream input, int limit)
    : this(input, limit, new byte[16 /*0x10*/][])
  {
  }

  internal Asn1StreamParser(Stream input, int limit, byte[][] tmpBuffers)
  {
    this._in = input.CanRead ? input : throw new ArgumentException("Expected stream to be readable", nameof (input));
    this._limit = limit;
    this.tmpBuffers = tmpBuffers;
  }

  public virtual IAsn1Convertible ReadObject()
  {
    int tagHdr = this._in.ReadByte();
    return tagHdr < 0 ? (IAsn1Convertible) null : this.ImplParseObject(tagHdr);
  }

  internal IAsn1Convertible ImplParseObject(int tagHdr)
  {
    this.Set00Check(false);
    int num = Asn1InputStream.ReadTagNumber(this._in, tagHdr);
    int length = Asn1InputStream.ReadLength(this._in, this._limit, num == 3 || num == 4 || num == 16 /*0x10*/ || num == 17 || num == 8);
    if (length < 0)
    {
      if ((tagHdr & 32 /*0x20*/) == 0)
        throw new IOException("indefinite-length primitive encoding encountered");
      Asn1StreamParser parser = new Asn1StreamParser((Stream) new IndefiniteLengthInputStream(this._in, this._limit), this._limit, this.tmpBuffers);
      int tagClass = tagHdr & 192 /*0xC0*/;
      return tagClass != 0 ? (IAsn1Convertible) new BerTaggedObjectParser(tagClass, num, parser) : parser.ParseImplicitConstructedIL(num);
    }
    DefiniteLengthInputStream lengthInputStream = new DefiniteLengthInputStream(this._in, length, this._limit);
    if ((tagHdr & 224 /*0xE0*/) == 0)
      return this.ParseImplicitPrimitive(num, lengthInputStream);
    Asn1StreamParser parser1 = new Asn1StreamParser((Stream) lengthInputStream, lengthInputStream.Remaining, this.tmpBuffers);
    int tagClass1 = tagHdr & 192 /*0xC0*/;
    if (tagClass1 == 0)
      return parser1.ParseImplicitConstructedDL(num);
    bool constructed = (tagHdr & 32 /*0x20*/) != 0;
    return (IAsn1Convertible) new DLTaggedObjectParser(tagClass1, num, constructed, parser1);
  }

  internal Asn1Object LoadTaggedDL(int tagClass, int tagNo, bool constructed)
  {
    if (!constructed)
    {
      byte[] array = ((DefiniteLengthInputStream) this._in).ToArray();
      return Asn1TaggedObject.CreatePrimitive(tagClass, tagNo, array);
    }
    Asn1EncodableVector contentsElements = this.ReadVector();
    return Asn1TaggedObject.CreateConstructedDL(tagClass, tagNo, contentsElements);
  }

  internal Asn1Object LoadTaggedIL(int tagClass, int tagNo)
  {
    Asn1EncodableVector contentsElements = this.ReadVector();
    return Asn1TaggedObject.CreateConstructedIL(tagClass, tagNo, contentsElements);
  }

  internal IAsn1Convertible ParseImplicitConstructedDL(int univTagNo)
  {
    switch (univTagNo)
    {
      case 3:
        return (IAsn1Convertible) new BerBitStringParser(this);
      case 4:
        return (IAsn1Convertible) new BerOctetStringParser(this);
      case 8:
        return (IAsn1Convertible) new DerExternalParser(this);
      case 16 /*0x10*/:
        return (IAsn1Convertible) new DerSequenceParser(this);
      case 17:
        return (IAsn1Convertible) new DerSetParser(this);
      default:
        throw new Asn1Exception("unknown DL object encountered: 0x" + univTagNo.ToString("X"));
    }
  }

  internal IAsn1Convertible ParseImplicitConstructedIL(int univTagNo)
  {
    switch (univTagNo)
    {
      case 3:
        return (IAsn1Convertible) new BerBitStringParser(this);
      case 4:
        return (IAsn1Convertible) new BerOctetStringParser(this);
      case 8:
        return (IAsn1Convertible) new DerExternalParser(this);
      case 16 /*0x10*/:
        return (IAsn1Convertible) new BerSequenceParser(this);
      case 17:
        return (IAsn1Convertible) new BerSetParser(this);
      default:
        throw new Asn1Exception("unknown BER object encountered: 0x" + univTagNo.ToString("X"));
    }
  }

  internal IAsn1Convertible ParseImplicitPrimitive(int univTagNo)
  {
    return this.ParseImplicitPrimitive(univTagNo, (DefiniteLengthInputStream) this._in);
  }

  internal IAsn1Convertible ParseImplicitPrimitive(int univTagNo, DefiniteLengthInputStream defIn)
  {
    if (univTagNo <= 4)
    {
      if (univTagNo == 3)
        return (IAsn1Convertible) new DLBitStringParser(defIn);
      if (univTagNo == 4)
        return (IAsn1Convertible) new DerOctetStringParser(defIn);
    }
    else
    {
      if (univTagNo == 8)
        throw new Asn1Exception("externals must use constructed encoding (see X.690 8.18)");
      if (univTagNo == 16 /*0x10*/)
        throw new Asn1Exception("sets must use constructed encoding (see X.690 8.11.1/8.12.1)");
      if (univTagNo == 17)
        throw new Asn1Exception("sequences must use constructed encoding (see X.690 8.9.1/8.10.1)");
    }
    try
    {
      return (IAsn1Convertible) Asn1InputStream.CreatePrimitiveDerObject(univTagNo, defIn, this.tmpBuffers);
    }
    catch (ArgumentException ex)
    {
      throw new Asn1Exception("corrupted stream detected", (Exception) ex);
    }
  }

  internal IAsn1Convertible ParseObject(int univTagNo)
  {
    if (univTagNo < 0 || univTagNo > 30)
      throw new ArgumentException("invalid universal tag number: " + univTagNo.ToString(), nameof (univTagNo));
    int tagHdr = this._in.ReadByte();
    if (tagHdr < 0)
      return (IAsn1Convertible) null;
    return (tagHdr & -33) == univTagNo ? this.ImplParseObject(tagHdr) : throw new IOException("unexpected identifier encountered: " + tagHdr.ToString());
  }

  internal Asn1TaggedObjectParser ParseTaggedObject()
  {
    int tagHdr = this._in.ReadByte();
    if (tagHdr < 0)
      return (Asn1TaggedObjectParser) null;
    return (tagHdr & 192 /*0xC0*/) != 0 ? (Asn1TaggedObjectParser) this.ImplParseObject(tagHdr) : throw new Asn1Exception("no tagged object found");
  }

  internal Asn1EncodableVector ReadVector()
  {
    int tagHdr = this._in.ReadByte();
    if (tagHdr < 0)
      return new Asn1EncodableVector(0);
    Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector();
    do
    {
      IAsn1Convertible asn1Convertible = this.ImplParseObject(tagHdr);
      asn1EncodableVector.Add((Asn1Encodable) asn1Convertible.ToAsn1Object());
    }
    while ((tagHdr = this._in.ReadByte()) >= 0);
    return asn1EncodableVector;
  }

  private void Set00Check(bool enabled)
  {
    if (!(this._in is IndefiniteLengthInputStream lengthInputStream))
      return;
    lengthInputStream.SetEofOn00(enabled);
  }
}
