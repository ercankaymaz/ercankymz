// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerEnumerated
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerEnumerated : Asn1Object
{
  private readonly byte[] contents;
  private readonly int start;
  private static readonly DerEnumerated[] cache = new DerEnumerated[12];

  public static DerEnumerated GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (DerEnumerated) null;
      case DerEnumerated instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is DerEnumerated asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (DerEnumerated) DerEnumerated.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct enumerated from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj));
  }

  public static DerEnumerated GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (DerEnumerated) DerEnumerated.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  public DerEnumerated(int val)
  {
    this.contents = val >= 0 ? BigInteger.ValueOf((long) val).ToByteArray() : throw new ArgumentException("enumerated must be non-negative", nameof (val));
    this.start = 0;
  }

  public DerEnumerated(long val)
  {
    this.contents = val >= 0L ? BigInteger.ValueOf(val).ToByteArray() : throw new ArgumentException("enumerated must be non-negative", nameof (val));
    this.start = 0;
  }

  public DerEnumerated(BigInteger val)
  {
    this.contents = val.SignValue >= 0 ? val.ToByteArray() : throw new ArgumentException("enumerated must be non-negative", nameof (val));
    this.start = 0;
  }

  public DerEnumerated(byte[] contents)
    : this(contents, true)
  {
  }

  internal DerEnumerated(byte[] contents, bool clone)
  {
    if (DerInteger.IsMalformed(contents))
      throw new ArgumentException("malformed enumerated", nameof (contents));
    if (((int) contents[0] & 128 /*0x80*/) != 0)
      throw new ArgumentException("enumerated must be non-negative", nameof (contents));
    this.contents = clone ? Arrays.Clone(contents) : contents;
    this.start = DerInteger.SignBytesToSkip(this.contents);
  }

  public BigInteger Value => new BigInteger(this.contents);

  public bool HasValue(int x)
  {
    return this.contents.Length - this.start <= 4 && DerInteger.IntValue(this.contents, this.start, -1) == x;
  }

  public bool HasValue(BigInteger x)
  {
    return x != null && DerInteger.IntValue(this.contents, this.start, -1) == x.IntValue && this.Value.Equals(x);
  }

  public int IntValueExact
  {
    get
    {
      if (this.contents.Length - this.start > 4)
        throw new ArithmeticException("ASN.1 Enumerated out of int range");
      return DerInteger.IntValue(this.contents, this.start, -1);
    }
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 10, this.contents);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.contents);
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 10, this.contents);
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.contents);
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is DerEnumerated derEnumerated && Arrays.AreEqual(this.contents, derEnumerated.contents);
  }

  protected override int Asn1GetHashCode() => Arrays.GetHashCode(this.contents);

  internal static DerEnumerated CreatePrimitive(byte[] contents, bool clone)
  {
    if (contents.Length > 1)
      return new DerEnumerated(contents, clone);
    int index = contents.Length != 0 ? (int) contents[0] : throw new ArgumentException("ENUMERATED has zero length", nameof (contents));
    if (index >= DerEnumerated.cache.Length)
      return new DerEnumerated(contents, clone);
    DerEnumerated primitive = DerEnumerated.cache[index];
    if (primitive == null)
      DerEnumerated.cache[index] = primitive = new DerEnumerated(contents, clone);
    return primitive;
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new DerEnumerated.Meta();

    private Meta()
      : base(typeof (DerEnumerated), 10)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) DerEnumerated.CreatePrimitive(octetString.GetOctets(), false);
    }
  }
}
