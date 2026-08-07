// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StatusCode
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Name = "StatusCode", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public struct StatusCode : IComparable, IFormattable, IComparable<StatusCode>, IEquatable<StatusCode>
{
  private uint m_code;
  private const uint s_AggregateBits = 31 /*0x1F*/;
  private const uint s_OverflowBit = 128 /*0x80*/;
  private const uint s_LimitBits = 768 /*0x0300*/;
  private const uint s_DataValueInfoType = 1024 /*0x0400*/;
  private const uint s_SemanticsChangedBit = 16384 /*0x4000*/;
  private const uint s_StructureChangedBit = 32768 /*0x8000*/;

  public StatusCode(uint code) => this.m_code = code;

  public StatusCode(Exception e, uint defaultCode)
  {
    if (e is ServiceResultException serviceResultException)
      this.m_code = serviceResultException.StatusCode;
    else
      this.m_code = defaultCode;
  }

  [DataMember(Name = "Code", Order = 1, IsRequired = false)]
  public uint Code
  {
    get => this.m_code;
    set => this.m_code = value;
  }

  public uint CodeBits => this.m_code & 4294901760U;

  public StatusCode SetCodeBits(uint bits)
  {
    this.m_code &= (uint) ushort.MaxValue;
    this.m_code |= bits & 4294901760U;
    return this;
  }

  public uint FlagBits => this.m_code & (uint) ushort.MaxValue;

  public StatusCode SetFlagBits(uint bits)
  {
    this.m_code &= 4294901760U;
    this.m_code |= bits & (uint) ushort.MaxValue;
    return this;
  }

  public uint SubCode
  {
    get => this.m_code & 268369920U /*0x0FFF0000*/;
    set => this.m_code = 268369920U /*0x0FFF0000*/ & value;
  }

  [XmlIgnore]
  public bool StructureChanged
  {
    get => (this.m_code & 32768U /*0x8000*/) > 0U;
    set
    {
      if (value)
        this.m_code |= 32768U /*0x8000*/;
      else
        this.m_code &= 4294934527U;
    }
  }

  public StatusCode SetStructureChanged(bool structureChanged)
  {
    this.StructureChanged = structureChanged;
    return this;
  }

  [XmlIgnore]
  public bool SemanticsChanged
  {
    get => (this.m_code & 16384U /*0x4000*/) > 0U;
    set
    {
      if (value)
        this.m_code |= 16384U /*0x4000*/;
      else
        this.m_code &= 4294950911U;
    }
  }

  public StatusCode SetSemanticsChanged(bool semanticsChanged)
  {
    this.SemanticsChanged = semanticsChanged;
    return this;
  }

  [XmlIgnore]
  public bool HasDataValueInfo
  {
    get => (this.m_code & 1024U /*0x0400*/) > 0U;
    set
    {
      if (value)
      {
        this.m_code |= 1024U /*0x0400*/;
      }
      else
      {
        this.m_code &= 4294966271U;
        this.m_code &= 4294966272U;
      }
    }
  }

  [XmlIgnore]
  public LimitBits LimitBits
  {
    get => (LimitBits) ((int) this.m_code & 768 /*0x0300*/);
    set
    {
      this.m_code |= 1024U /*0x0400*/;
      this.m_code &= 4294966527U;
      this.m_code = (uint) ((LimitBits) this.m_code | value & LimitBits.Constant);
    }
  }

  public StatusCode SetLimitBits(LimitBits bits)
  {
    this.LimitBits = bits;
    return this;
  }

  [XmlIgnore]
  public bool Overflow
  {
    get => ((int) this.m_code & 1024 /*0x0400*/) != 0 && (this.m_code & 128U /*0x80*/) > 0U;
    set
    {
      this.m_code |= 1024U /*0x0400*/;
      if (value)
        this.m_code |= 128U /*0x80*/;
      else
        this.m_code &= 4294967167U;
    }
  }

  public StatusCode SetOverflow(bool overflow)
  {
    this.Overflow = overflow;
    return this;
  }

  [XmlIgnore]
  public AggregateBits AggregateBits
  {
    get => (AggregateBits) ((int) this.m_code & 31 /*0x1F*/);
    set
    {
      this.m_code |= 1024U /*0x0400*/;
      this.m_code &= 4294967264U;
      this.m_code = (uint) ((AggregateBits) this.m_code | value & (AggregateBits.DataSourceMask | AggregateBits.Partial | AggregateBits.ExtraData | AggregateBits.MultipleValues));
    }
  }

  public StatusCode SetAggregateBits(AggregateBits bits)
  {
    this.AggregateBits = bits;
    return this;
  }

  public int CompareTo(object obj)
  {
    switch (obj)
    {
      case StatusCode statusCode:
        return this.m_code.CompareTo(statusCode.m_code);
      case null:
        return 1;
      case uint num:
        return this.m_code.CompareTo(num);
      default:
        return -1;
    }
  }

  public int CompareTo(StatusCode other) => this.m_code.CompareTo(other.Code);

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format == null)
    {
      string browseName = StatusCodes.GetBrowseName(this.m_code & 4294901760U);
      return !string.IsNullOrEmpty(browseName) ? string.Format(formatProvider, "{0}", (object) browseName) : string.Format(formatProvider, "0x{0:X8}", (object) this.m_code);
    }
    throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
  }

  public override bool Equals(object obj) => this.CompareTo(obj) == 0;

  public bool Equals(StatusCode other) => this.CompareTo(other) == 0;

  public override int GetHashCode() => this.m_code.GetHashCode();

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append(StatusCode.LookupSymbolicId(this.m_code));
    if (((int) ushort.MaxValue & (int) this.Code) != 0)
      stringBuilder.AppendFormat(" [{0:X4}]", (object) (uint) ((int) ushort.MaxValue & (int) this.Code));
    return stringBuilder.ToString();
  }

  public static implicit operator StatusCode(uint code) => new StatusCode(code);

  public static explicit operator uint(StatusCode code) => code.Code;

  public static string LookupSymbolicId(uint code) => StatusCodes.GetBrowseName(code & 4294901760U);

  public static bool operator ==(StatusCode a, StatusCode b) => a.Equals(b);

  public static bool operator !=(StatusCode a, StatusCode b) => !(a == b);

  public static bool operator ==(StatusCode a, uint b) => a.Equals((StatusCode) b);

  public static bool operator !=(StatusCode a, uint b) => !(a == b);

  public static bool operator <(StatusCode a, StatusCode b) => a.CompareTo(b) < 0;

  public static bool operator >(StatusCode a, StatusCode b) => a.CompareTo(b) > 0;

  public static bool IsGood(StatusCode code)
  {
    return ((int) code.m_code & -1073741824 /*0xC0000000*/) == 0;
  }

  public static bool IsNotGood(StatusCode code) => (code.m_code & 3221225472U /*0xC0000000*/) > 0U;

  public static bool IsUncertain(StatusCode code)
  {
    return ((int) code.m_code & 1073741824 /*0x40000000*/) == 1073741824 /*0x40000000*/;
  }

  public static bool IsNotUncertain(StatusCode code)
  {
    return ((int) code.m_code & 1073741824 /*0x40000000*/) != 1073741824 /*0x40000000*/;
  }

  public static bool IsBad(StatusCode code) => (code.m_code & 2147483648U /*0x80000000*/) > 0U;

  public static bool IsNotBad(StatusCode code) => ((int) code.m_code & int.MinValue) == 0;
}
