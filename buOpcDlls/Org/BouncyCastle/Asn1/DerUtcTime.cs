// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerUtcTime
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerUtcTime : Asn1UtcTime
{
  public DerUtcTime(string timeString)
    : base(timeString)
  {
  }

  [Obsolete("Use `DerUtcTime(DateTime, int)' instead")]
  public DerUtcTime(DateTime dateTime)
    : base(dateTime)
  {
  }

  public DerUtcTime(DateTime dateTime, int twoDigitYearMax)
    : base(dateTime, twoDigitYearMax)
  {
  }

  internal DerUtcTime(byte[] contents)
    : base(contents)
  {
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 23, this.GetContents(2));
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.GetContents(2));
  }
}
