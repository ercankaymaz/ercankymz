// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X9.DHPublicKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X9;

public class DHPublicKey : Asn1Encodable
{
  private readonly DerInteger y;

  public static DHPublicKey GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return DHPublicKey.GetInstance((object) DerInteger.GetInstance(obj, isExplicit));
  }

  public static DHPublicKey GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case DHPublicKey _:
        return (DHPublicKey) obj;
      case DerInteger _:
        return new DHPublicKey((DerInteger) obj);
      default:
        throw new ArgumentException("Invalid DHPublicKey: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public DHPublicKey(DerInteger y)
  {
    this.y = y != null ? y : throw new ArgumentNullException(nameof (y));
  }

  public DerInteger Y => this.y;

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.y;
}
