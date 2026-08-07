// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.Time
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.Globalization;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class Time : Asn1Encodable, IAsn1Choice
{
  private readonly Asn1Object m_timeObject;

  public static Time GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (Time) null;
      case Time instance:
        return instance;
      case Asn1UtcTime utcTime:
        return new Time(utcTime);
      case Asn1GeneralizedTime generalizedTime:
        return new Time(generalizedTime);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public static Time GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return Time.GetInstance((object) taggedObject.GetObject());
  }

  public Time(Asn1GeneralizedTime generalizedTime)
  {
    this.m_timeObject = (Asn1Object) (generalizedTime ?? throw new ArgumentNullException(nameof (generalizedTime)));
  }

  public Time(Asn1UtcTime utcTime)
  {
    if (utcTime == null)
      throw new ArgumentNullException(nameof (utcTime));
    utcTime.ToDateTime(2049);
    this.m_timeObject = (Asn1Object) utcTime;
  }

  public Time(DateTime date)
  {
    DateTime universalTime = date.ToUniversalTime();
    if (universalTime.Year >= 1950 && universalTime.Year <= 2049)
      this.m_timeObject = (Asn1Object) new DerUtcTime(universalTime, 2049);
    else
      this.m_timeObject = (Asn1Object) new DerGeneralizedTime(universalTime);
  }

  public DateTime ToDateTime()
  {
    try
    {
      return this.m_timeObject is Asn1UtcTime timeObject ? timeObject.ToDateTime(2049) : ((Asn1GeneralizedTime) this.m_timeObject).ToDateTime();
    }
    catch (FormatException ex)
    {
      throw new InvalidOperationException("invalid date string: " + ex.Message);
    }
  }

  public override Asn1Object ToAsn1Object() => this.m_timeObject;

  public override string ToString()
  {
    if (this.m_timeObject is Asn1UtcTime timeObject1)
      return timeObject1.ToDateTime(2049).ToString("yyyyMMddHHmmssK", (IFormatProvider) DateTimeFormatInfo.InvariantInfo);
    return this.m_timeObject is Asn1GeneralizedTime timeObject2 ? timeObject2.ToDateTime().ToString("yyyyMMddHHmmss.FFFFFFFK", (IFormatProvider) DateTimeFormatInfo.InvariantInfo) : throw new InvalidOperationException();
  }
}
