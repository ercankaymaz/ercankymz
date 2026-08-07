// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerVideotexString
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerVideotexString : DerStringBase
{
  private readonly byte[] m_contents;

  public static DerVideotexString GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (DerVideotexString) null;
      case DerVideotexString instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is DerVideotexString asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (DerVideotexString) DerVideotexString.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct videotex string from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
  }

  public static DerVideotexString GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (DerVideotexString) DerVideotexString.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  public DerVideotexString(byte[] contents)
    : this(contents, true)
  {
  }

  internal DerVideotexString(byte[] contents, bool clone)
  {
    if (contents == null)
      throw new ArgumentNullException(nameof (contents));
    this.m_contents = clone ? Arrays.Clone(contents) : contents;
  }

  public override string GetString() => Strings.FromByteArray(this.m_contents);

  public byte[] GetOctets() => Arrays.Clone(this.m_contents);

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 21, this.m_contents);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.m_contents);
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 21, this.m_contents);
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.m_contents);
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is DerVideotexString derVideotexString && Arrays.AreEqual(this.m_contents, derVideotexString.m_contents);
  }

  protected override int Asn1GetHashCode() => Arrays.GetHashCode(this.m_contents);

  internal static DerVideotexString CreatePrimitive(byte[] contents)
  {
    return new DerVideotexString(contents, false);
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new DerVideotexString.Meta();

    private Meta()
      : base(typeof (DerVideotexString), 21)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) DerVideotexString.CreatePrimitive(octetString.GetOctets());
    }
  }
}
