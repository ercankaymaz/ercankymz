// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1GeneralizedTime
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.Globalization;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class Asn1GeneralizedTime : Asn1Object
{
  private readonly string m_timeString;
  private readonly bool m_timeStringCanonical;
  private readonly DateTime m_dateTime;

  public static Asn1GeneralizedTime GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (Asn1GeneralizedTime) null;
      case Asn1GeneralizedTime instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is Asn1GeneralizedTime asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (Asn1GeneralizedTime) Asn1GeneralizedTime.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct generalized time from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
  }

  public static Asn1GeneralizedTime GetInstance(
    Asn1TaggedObject taggedObject,
    bool declaredExplicit)
  {
    return (Asn1GeneralizedTime) Asn1GeneralizedTime.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  public Asn1GeneralizedTime(string timeString)
  {
    this.m_timeString = timeString ?? throw new ArgumentNullException(nameof (timeString));
    this.m_timeStringCanonical = false;
    try
    {
      this.m_dateTime = Asn1GeneralizedTime.FromString(timeString);
    }
    catch (FormatException ex)
    {
      throw new ArgumentException("invalid date string: " + ex.Message);
    }
  }

  public Asn1GeneralizedTime(DateTime dateTime)
  {
    dateTime = dateTime.ToUniversalTime();
    this.m_dateTime = dateTime;
    this.m_timeString = Asn1GeneralizedTime.ToStringCanonical(dateTime);
    this.m_timeStringCanonical = true;
  }

  internal Asn1GeneralizedTime(byte[] contents)
    : this(Encoding.ASCII.GetString(contents))
  {
  }

  public string TimeString => this.m_timeString;

  public DateTime ToDateTime() => this.m_dateTime;

  internal byte[] GetContents(int encoding)
  {
    return encoding == 2 && !this.m_timeStringCanonical ? Encoding.ASCII.GetBytes(Asn1GeneralizedTime.ToStringCanonical(this.m_dateTime)) : Encoding.ASCII.GetBytes(this.m_timeString);
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 24, this.GetContents(encoding));
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.GetContents(encoding));
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 24, this.GetContents(2));
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.GetContents(2));
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is Asn1GeneralizedTime asn1GeneralizedTime && Arrays.AreEqual(this.GetContents(2), asn1GeneralizedTime.GetContents(2));
  }

  protected override int Asn1GetHashCode() => Arrays.GetHashCode(this.GetContents(2));

  internal static Asn1GeneralizedTime CreatePrimitive(byte[] contents)
  {
    return new Asn1GeneralizedTime(contents);
  }

  private static DateTime FromString(string s)
  {
    s = s.Length >= 10 ? s.Replace(',', '.') : throw new FormatException();
    if (Platform.EndsWith(s, "Z"))
    {
      switch (s.Length)
      {
        case 11:
          return Asn1GeneralizedTime.ParseUtc(s, "yyyyMMddHH\\Z");
        case 13:
          return Asn1GeneralizedTime.ParseUtc(s, "yyyyMMddHHmm\\Z");
        case 15:
          return Asn1GeneralizedTime.ParseUtc(s, "yyyyMMddHHmmss\\Z");
        case 17:
          return Asn1GeneralizedTime.ParseUtc(s, "yyyyMMddHHmmss.f\\Z");
        case 18:
          return Asn1GeneralizedTime.ParseUtc(s, "yyyyMMddHHmmss.ff\\Z");
        case 19:
          return Asn1GeneralizedTime.ParseUtc(s, "yyyyMMddHHmmss.fff\\Z");
        case 20:
          return Asn1GeneralizedTime.ParseUtc(s, "yyyyMMddHHmmss.ffff\\Z");
        case 21:
          return Asn1GeneralizedTime.ParseUtc(s, "yyyyMMddHHmmss.fffff\\Z");
        case 22:
          return Asn1GeneralizedTime.ParseUtc(s, "yyyyMMddHHmmss.ffffff\\Z");
        case 23:
          return Asn1GeneralizedTime.ParseUtc(s, "yyyyMMddHHmmss.fffffff\\Z");
        default:
          throw new FormatException();
      }
    }
    else
    {
      int num = Asn1GeneralizedTime.IndexOfSign(s, Math.Max(10, s.Length - 5));
      if (num < 0)
      {
        switch (s.Length)
        {
          case 10:
            return Asn1GeneralizedTime.ParseLocal(s, "yyyyMMddHH");
          case 12:
            return Asn1GeneralizedTime.ParseLocal(s, "yyyyMMddHHmm");
          case 14:
            return Asn1GeneralizedTime.ParseLocal(s, "yyyyMMddHHmmss");
          case 16 /*0x10*/:
            return Asn1GeneralizedTime.ParseLocal(s, "yyyyMMddHHmmss.f");
          case 17:
            return Asn1GeneralizedTime.ParseLocal(s, "yyyyMMddHHmmss.ff");
          case 18:
            return Asn1GeneralizedTime.ParseLocal(s, "yyyyMMddHHmmss.fff");
          case 19:
            return Asn1GeneralizedTime.ParseLocal(s, "yyyyMMddHHmmss.ffff");
          case 20:
            return Asn1GeneralizedTime.ParseLocal(s, "yyyyMMddHHmmss.fffff");
          case 21:
            return Asn1GeneralizedTime.ParseLocal(s, "yyyyMMddHHmmss.ffffff");
          case 22:
            return Asn1GeneralizedTime.ParseLocal(s, "yyyyMMddHHmmss.fffffff");
          default:
            throw new FormatException();
        }
      }
      else if (num == s.Length - 5)
      {
        switch (s.Length)
        {
          case 15:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHzzz");
          case 17:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmzzz");
          case 19:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmsszzz");
          case 21:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmss.fzzz");
          case 22:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmss.ffzzz");
          case 23:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmss.fffzzz");
          case 24:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmss.ffffzzz");
          case 25:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmss.fffffzzz");
          case 26:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmss.ffffffzzz");
          case 27:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmss.fffffffzzz");
          default:
            throw new FormatException();
        }
      }
      else
      {
        if (num != s.Length - 3)
          throw new FormatException();
        switch (s.Length)
        {
          case 13:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHzz");
          case 15:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmzz");
          case 17:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmsszz");
          case 19:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmss.fzz");
          case 20:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmss.ffzz");
          case 21:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmss.fffzz");
          case 22:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmss.ffffzz");
          case 23:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmss.fffffzz");
          case 24:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmss.ffffffzz");
          case 25:
            return Asn1GeneralizedTime.ParseTimeZone(s, "yyyyMMddHHmmss.fffffffzz");
          default:
            throw new FormatException();
        }
      }
    }
  }

  private static int IndexOfSign(string s, int startIndex)
  {
    int num = Platform.IndexOf(s, '+', startIndex);
    if (num < 0)
      num = Platform.IndexOf(s, '-', startIndex);
    return num;
  }

  private static DateTime ParseLocal(string s, string format)
  {
    return DateTime.ParseExact(s, format, (IFormatProvider) DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AssumeLocal);
  }

  private static DateTime ParseTimeZone(string s, string format)
  {
    return DateTime.ParseExact(s, format, (IFormatProvider) DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AdjustToUniversal);
  }

  private static DateTime ParseUtc(string s, string format)
  {
    return DateTime.ParseExact(s, format, (IFormatProvider) DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
  }

  private static string ToStringCanonical(DateTime dateTime)
  {
    return dateTime.ToUniversalTime().ToString("yyyyMMddHHmmss.FFFFFFFK", (IFormatProvider) DateTimeFormatInfo.InvariantInfo);
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new Asn1GeneralizedTime.Meta();

    private Meta()
      : base(typeof (Asn1GeneralizedTime), 24)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) Asn1GeneralizedTime.CreatePrimitive(octetString.GetOctets());
    }
  }
}
