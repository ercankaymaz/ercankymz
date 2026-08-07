// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerGeneralizedTime
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerGeneralizedTime : Asn1GeneralizedTime
{
  public DerGeneralizedTime(string timeString)
    : base(timeString)
  {
  }

  public DerGeneralizedTime(DateTime dateTime)
    : base(dateTime)
  {
  }

  internal DerGeneralizedTime(byte[] contents)
    : base(contents)
  {
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 24, this.GetContents(2));
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.GetContents(2));
  }
}
