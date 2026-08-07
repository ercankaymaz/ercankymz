// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.IsisMtt.X509.Restriction
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X500;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.IsisMtt.X509;

public class Restriction : Asn1Encodable
{
  private readonly DirectoryString restriction;

  public static Restriction GetInstance(object obj)
  {
    switch (obj)
    {
      case Restriction _:
        return (Restriction) obj;
      case IAsn1String _:
        return new Restriction(DirectoryString.GetInstance(obj));
      default:
        throw new ArgumentException("Unknown object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private Restriction(DirectoryString restriction) => this.restriction = restriction;

  public Restriction(string restriction) => this.restriction = new DirectoryString(restriction);

  public virtual DirectoryString RestrictionString => this.restriction;

  public override Asn1Object ToAsn1Object() => this.restriction.ToAsn1Object();
}
