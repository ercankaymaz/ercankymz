// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X9.X962Parameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X9;

public class X962Parameters : Asn1Encodable, IAsn1Choice
{
  private readonly Asn1Object _params;

  public static X962Parameters GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case X962Parameters _:
        return (X962Parameters) obj;
      case Asn1Object _:
        return new X962Parameters((Asn1Object) obj);
      case byte[] _:
        try
        {
          return new X962Parameters(Asn1Object.FromByteArray((byte[]) obj));
        }
        catch (Exception ex)
        {
          throw new ArgumentException("unable to parse encoded data: " + ex.Message, ex);
        }
      default:
        throw new ArgumentException("unknown object in getInstance()");
    }
  }

  public X962Parameters(X9ECParameters ecParameters) => this._params = ecParameters.ToAsn1Object();

  public X962Parameters(DerObjectIdentifier namedCurve) => this._params = (Asn1Object) namedCurve;

  public X962Parameters(Asn1Null obj) => this._params = (Asn1Object) obj;

  private X962Parameters(Asn1Object obj) => this._params = obj;

  public bool IsNamedCurve => this._params is DerObjectIdentifier;

  public bool IsImplicitlyCA => this._params is Asn1Null;

  public Asn1Object Parameters => this._params;

  public override Asn1Object ToAsn1Object() => this._params;
}
