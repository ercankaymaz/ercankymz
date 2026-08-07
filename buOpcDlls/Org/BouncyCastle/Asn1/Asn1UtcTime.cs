// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1UtcTime
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Date;
using System;
using System.Globalization;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class Asn1UtcTime : Asn1Object
{
  private readonly string m_timeString;
  private readonly DateTime m_dateTime;
  private readonly bool m_dateTimeLocked;
  private readonly int m_twoDigitYearMax;

  public static Asn1UtcTime GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (Asn1UtcTime) null;
      case Asn1UtcTime instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is Asn1UtcTime asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (Asn1UtcTime) Asn1UtcTime.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct UTC time from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
  }

  public static Asn1UtcTime GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (Asn1UtcTime) Asn1UtcTime.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  public Asn1UtcTime(string timeString)
  {
    this.m_timeString = timeString ?? throw new ArgumentNullException(nameof (timeString));
    try
    {
      this.m_dateTime = Asn1UtcTime.FromString(timeString, out this.m_twoDigitYearMax);
      this.m_dateTimeLocked = false;
    }
    catch (FormatException ex)
    {
      throw new ArgumentException("invalid date string: " + ex.Message);
    }
  }

  [Obsolete("Use `Asn1UtcTime(DateTime, int)' instead")]
  public Asn1UtcTime(DateTime dateTime)
  {
    dateTime = DateTimeUtilities.WithPrecisionSecond(dateTime.ToUniversalTime());
    this.m_dateTime = dateTime;
    this.m_dateTimeLocked = true;
    this.m_timeString = Asn1UtcTime.ToStringCanonical(dateTime, out this.m_twoDigitYearMax);
  }

  public Asn1UtcTime(DateTime dateTime, int twoDigitYearMax)
  {
    dateTime = DateTimeUtilities.WithPrecisionSecond(dateTime.ToUniversalTime());
    Asn1UtcTime.Validate(dateTime, twoDigitYearMax);
    this.m_dateTime = dateTime;
    this.m_dateTimeLocked = true;
    this.m_timeString = Asn1UtcTime.ToStringCanonical(dateTime);
    this.m_twoDigitYearMax = twoDigitYearMax;
  }

  internal Asn1UtcTime(byte[] contents)
    : this(Encoding.ASCII.GetString(contents))
  {
  }

  public string TimeString => this.m_timeString;

  public DateTime ToDateTime() => this.m_dateTime;

  public DateTime ToDateTime(int twoDigitYearMax)
  {
    if (Asn1UtcTime.InRange(this.m_dateTime, twoDigitYearMax))
      return this.m_dateTime;
    if (this.m_dateTimeLocked)
      throw new InvalidOperationException();
    int num1 = this.m_dateTime.Year % 100 - twoDigitYearMax % 100;
    int num2 = twoDigitYearMax + num1;
    if (num1 > 0)
      num2 -= 100;
    return this.m_dateTime.AddYears(num2 - this.m_dateTime.Year);
  }

  public DateTime ToDateTime(Calendar calendar) => this.ToDateTime(calendar.TwoDigitYearMax);

  [Obsolete("Use 'ToDateTime(2049)' instead")]
  public DateTime ToAdjustedDateTime() => this.ToDateTime(2049);

  public int TwoDigitYearMax => this.m_twoDigitYearMax;

  internal byte[] GetContents(int encoding)
  {
    return encoding == 2 && this.m_timeString.Length != 13 ? Encoding.ASCII.GetBytes(Asn1UtcTime.ToStringCanonical(this.m_dateTime)) : Encoding.ASCII.GetBytes(this.m_timeString);
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 23, this.GetContents(encoding));
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.GetContents(encoding));
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 23, this.GetContents(2));
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.GetContents(2));
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return asn1Object is Asn1UtcTime asn1UtcTime && Arrays.AreEqual(this.GetContents(2), asn1UtcTime.GetContents(2));
  }

  protected override int Asn1GetHashCode() => Arrays.GetHashCode(this.GetContents(2));

  public override string ToString() => this.m_timeString;

  internal static Asn1UtcTime CreatePrimitive(byte[] contents) => new Asn1UtcTime(contents);

  private static DateTime FromString(string s, out int twoDigitYearMax)
  {
    DateTimeFormatInfo invariantInfo = DateTimeFormatInfo.InvariantInfo;
    twoDigitYearMax = invariantInfo.Calendar.TwoDigitYearMax;
    switch (s.Length)
    {
      case 11:
        return DateTime.ParseExact(s, "yyMMddHHmm\\Z", (IFormatProvider) invariantInfo, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
      case 13:
        return DateTime.ParseExact(s, "yyMMddHHmmss\\Z", (IFormatProvider) invariantInfo, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
      case 15:
        return DateTime.ParseExact(s, "yyMMddHHmmzzz", (IFormatProvider) invariantInfo, DateTimeStyles.AdjustToUniversal);
      case 17:
        return DateTime.ParseExact(s, "yyMMddHHmmsszzz", (IFormatProvider) invariantInfo, DateTimeStyles.AdjustToUniversal);
      default:
        throw new FormatException();
    }
  }

  private static bool InRange(DateTime dateTime, int twoDigitYearMax)
  {
    return (uint) (twoDigitYearMax - dateTime.Year) < 100U;
  }

  private static string ToStringCanonical(DateTime dateTime, out int twoDigitYearMax)
  {
    DateTimeFormatInfo invariantInfo = DateTimeFormatInfo.InvariantInfo;
    twoDigitYearMax = invariantInfo.Calendar.TwoDigitYearMax;
    Asn1UtcTime.Validate(dateTime, twoDigitYearMax);
    return dateTime.ToString("yyMMddHHmmss\\Z", (IFormatProvider) invariantInfo);
  }

  private static string ToStringCanonical(DateTime dateTime)
  {
    return dateTime.ToString("yyMMddHHmmss\\Z", (IFormatProvider) DateTimeFormatInfo.InvariantInfo);
  }

  private static void Validate(DateTime dateTime, int twoDigitYearMax)
  {
    if (!Asn1UtcTime.InRange(dateTime, twoDigitYearMax))
      throw new ArgumentOutOfRangeException(nameof (dateTime));
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new Asn1UtcTime.Meta();

    private Meta()
      : base(typeof (Asn1UtcTime), 23)
    {
    }

    internal override Asn1Object FromImplicitPrimitive(DerOctetString octetString)
    {
      return (Asn1Object) Asn1UtcTime.CreatePrimitive(octetString.GetOctets());
    }
  }
}
