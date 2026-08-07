// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerUtf8String
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerUtf8String : DerStringBase
{
  private readonly byte[] m_contents;

  public static DerUtf8String GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (DerUtf8String) null;
      case DerUtf8String instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is DerUtf8String asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (DerUtf8String) DerUtf8String.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct UTF8 string from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj));
  }

  public static DerUtf8String GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (DerUtf8String) DerUtf8String.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  public DerUtf8String(string str)
    : this(Strings.ToUtf8ByteArray(str), false)
  {
  }

  public DerUtf8String(byte[] contents)
    : this(contents, true)
  {
  }

  internal DerUtf8String(byte[] contents, bool clone)
  {
    if (contents == null)
      throw new ArgumentNullException(nameof (contents));
    this.m_contents = clone ? Arrays.Clone(contents) : contents;
  }

  public override string GetString() => Strings.FromUtf8ByteArray(this.m_contents);

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is DerUtf8String derUtf8String && Arrays.AreEqual(this.m_contents, derUtf8String.m_contents);
  }

  protected override int Asn1GetHashCode() => Arrays.GetHashCode(this.m_contents);

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 12, this.m_contents);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.m_contents);
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 12, this.m_contents);
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.m_contents);
  }

  internal static DerUtf8String CreatePrimitive(byte[] contents)
  {
    return new DerUtf8String(contents, false);
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new DerUtf8String.Meta();

    private Meta()
      : base(typeof (DerUtf8String), 12)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) DerUtf8String.CreatePrimitive(octetString.GetOctets());
    }
  }
}
