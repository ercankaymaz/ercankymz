// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X500.DirectoryString
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X500;

public class DirectoryString : Asn1Encodable, IAsn1Choice, IAsn1String
{
  private readonly DerStringBase str;

  public static DirectoryString GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case DirectoryString _:
        return (DirectoryString) obj;
      case DerStringBase _:
        if (obj is DerT61String || obj is DerPrintableString || obj is DerUniversalString || obj is DerUtf8String || obj is DerBmpString)
          return new DirectoryString((DerStringBase) obj);
        break;
    }
    throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
  }

  public static DirectoryString GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    if (!isExplicit)
      throw new ArgumentException("choice item must be explicitly tagged");
    return DirectoryString.GetInstance((object) obj.GetObject());
  }

  private DirectoryString(DerStringBase str) => this.str = str;

  public DirectoryString(string str) => this.str = (DerStringBase) new DerUtf8String(str);

  public string GetString() => this.str.GetString();

  public override Asn1Object ToAsn1Object() => this.str.ToAsn1Object();
}
