// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.SignaturePolicyIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class SignaturePolicyIdentifier : Asn1Encodable, IAsn1Choice
{
  private readonly SignaturePolicyId sigPolicy;

  public static SignaturePolicyIdentifier GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case SignaturePolicyIdentifier _:
        return (SignaturePolicyIdentifier) obj;
      case SignaturePolicyId _:
        return new SignaturePolicyIdentifier((SignaturePolicyId) obj);
      case Asn1Null _:
        return new SignaturePolicyIdentifier();
      default:
        throw new ArgumentException("Unknown object in 'SignaturePolicyIdentifier' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public SignaturePolicyIdentifier() => this.sigPolicy = (SignaturePolicyId) null;

  public SignaturePolicyIdentifier(SignaturePolicyId signaturePolicyId)
  {
    this.sigPolicy = signaturePolicyId != null ? signaturePolicyId : throw new ArgumentNullException(nameof (signaturePolicyId));
  }

  public SignaturePolicyId SignaturePolicyId => this.sigPolicy;

  public override Asn1Object ToAsn1Object()
  {
    return this.sigPolicy != null ? this.sigPolicy.ToAsn1Object() : (Asn1Object) DerNull.Instance;
  }
}
