// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerGeneralString
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerGeneralString : DerStringBase
{
  private readonly byte[] m_contents;

  public static DerGeneralString GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (DerGeneralString) null;
      case DerGeneralString instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is DerGeneralString asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (DerGeneralString) DerGeneralString.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct general string from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj));
  }

  public static DerGeneralString GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (DerGeneralString) DerGeneralString.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  public DerGeneralString(string str)
  {
    this.m_contents = str != null ? Strings.ToAsciiByteArray(str) : throw new ArgumentNullException(nameof (str));
  }

  public DerGeneralString(byte[] contents)
    : this(contents, true)
  {
  }

  internal DerGeneralString(byte[] contents, bool clone)
  {
    if (contents == null)
      throw new ArgumentNullException(nameof (contents));
    this.m_contents = clone ? Arrays.Clone(contents) : contents;
  }

  public override string GetString() => Strings.FromAsciiByteArray(this.m_contents);

  public byte[] GetOctets() => Arrays.Clone(this.m_contents);

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 27, this.m_contents);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.m_contents);
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 27, this.m_contents);
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.m_contents);
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is DerGeneralString derGeneralString && Arrays.AreEqual(this.m_contents, derGeneralString.m_contents);
  }

  protected override int Asn1GetHashCode() => Arrays.GetHashCode(this.m_contents);

  internal static DerGeneralString CreatePrimitive(byte[] contents)
  {
    return new DerGeneralString(contents, false);
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new DerGeneralString.Meta();

    private Meta()
      : base(typeof (DerGeneralString), 27)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) DerGeneralString.CreatePrimitive(octetString.GetOctets());
    }
  }
}
