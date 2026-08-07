// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.IsisMtt.X509.AdditionalInformationSyntax
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X500;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.IsisMtt.X509;

public class AdditionalInformationSyntax : Asn1Encodable
{
  private readonly DirectoryString information;

  public static AdditionalInformationSyntax GetInstance(object obj)
  {
    switch (obj)
    {
      case AdditionalInformationSyntax _:
        return (AdditionalInformationSyntax) obj;
      case IAsn1String _:
        return new AdditionalInformationSyntax(DirectoryString.GetInstance(obj));
      default:
        throw new ArgumentException("Unknown object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private AdditionalInformationSyntax(DirectoryString information)
  {
    this.information = information;
  }

  public AdditionalInformationSyntax(string information)
  {
    this.information = new DirectoryString(information);
  }

  public virtual DirectoryString Information => this.information;

  public override Asn1Object ToAsn1Object() => this.information.ToAsn1Object();
}
