// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1Null
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public abstract class Asn1Null : Asn1Object
{
  public static Asn1Null GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (Asn1Null) null;
      case Asn1Null instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is Asn1Null asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (Asn1Null) Asn1Null.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct NULL from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj));
  }

  public static Asn1Null GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (Asn1Null) Asn1Null.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  internal Asn1Null()
  {
  }

  public override string ToString() => "NULL";

  internal static Asn1Null CreatePrimitive(byte[] contents)
  {
    if (contents.Length != 0)
      throw new InvalidOperationException("malformed NULL encoding encountered");
    return (Asn1Null) DerNull.Instance;
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new Asn1Null.Meta();

    private Meta()
      : base(typeof (Asn1Null), 5)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) Asn1Null.CreatePrimitive(octetString.GetOctets());
    }
  }
}
