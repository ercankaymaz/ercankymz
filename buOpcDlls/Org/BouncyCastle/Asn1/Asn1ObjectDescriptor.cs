// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1ObjectDescriptor
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public sealed class Asn1ObjectDescriptor : Asn1Object
{
  private readonly DerGraphicString m_baseGraphicString;

  public static Asn1ObjectDescriptor GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (Asn1ObjectDescriptor) null;
      case Asn1ObjectDescriptor instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is Asn1ObjectDescriptor asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (Asn1ObjectDescriptor) Asn1ObjectDescriptor.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct object descriptor from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
  }

  public static Asn1ObjectDescriptor GetInstance(
    Asn1TaggedObject taggedObject,
    bool declaredExplicit)
  {
    return (Asn1ObjectDescriptor) Asn1ObjectDescriptor.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  public Asn1ObjectDescriptor(DerGraphicString baseGraphicString)
  {
    this.m_baseGraphicString = baseGraphicString != null ? baseGraphicString : throw new ArgumentNullException(nameof (baseGraphicString));
  }

  public DerGraphicString BaseGraphicString => this.m_baseGraphicString;

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return this.m_baseGraphicString.GetEncodingImplicit(encoding, 0, 7);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return this.m_baseGraphicString.GetEncodingImplicit(encoding, tagClass, tagNo);
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return this.m_baseGraphicString.GetEncodingDerImplicit(0, 7);
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return this.m_baseGraphicString.GetEncodingDerImplicit(tagClass, tagNo);
  }

  protected override int Asn1GetHashCode() => ~this.m_baseGraphicString.CallAsn1GetHashCode();

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is Asn1ObjectDescriptor objectDescriptor && this.m_baseGraphicString.Equals((Asn1Object) objectDescriptor.m_baseGraphicString);
  }

  internal static Asn1ObjectDescriptor CreatePrimitive(byte[] contents)
  {
    return new Asn1ObjectDescriptor(DerGraphicString.CreatePrimitive(contents));
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new Asn1ObjectDescriptor.Meta();

    private Meta()
      : base(typeof (Asn1ObjectDescriptor), 7)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) new Asn1ObjectDescriptor((DerGraphicString) DerGraphicString.Meta.Instance.FromImplicitPrimitive(octetString));
    }

    internal override Asn1Object FromImplicitConstructed(Asn1Sequence sequence)
    {
      return (Asn1Object) new Asn1ObjectDescriptor((DerGraphicString) DerGraphicString.Meta.Instance.FromImplicitConstructed(sequence));
    }
  }
}
