// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataValue
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DataValue : ICloneable, IFormattable, IEquatable<DataValue>
{
  private Variant m_value;
  private StatusCode m_statusCode;
  private DateTime m_sourceTimestamp;
  private ushort m_sourcePicoseconds;
  private DateTime m_serverTimestamp;
  private ushort m_serverPicoseconds;

  public DataValue() => this.Initialize();

  public DataValue(DataValue value)
  {
    if (value == null)
      throw new ArgumentNullException(nameof (value));
    this.m_value.Value = Utils.Clone(value.m_value.Value);
    this.m_statusCode = value.m_statusCode;
    this.m_sourceTimestamp = value.m_sourceTimestamp;
    this.m_sourcePicoseconds = value.m_sourcePicoseconds;
    this.m_serverTimestamp = value.m_serverTimestamp;
    this.m_serverPicoseconds = value.m_serverPicoseconds;
  }

  public DataValue(Variant value)
  {
    this.Initialize();
    this.m_value = value;
  }

  public DataValue(StatusCode statusCode)
  {
    this.Initialize();
    this.m_statusCode = statusCode;
  }

  public DataValue(StatusCode statusCode, DateTime serverTimestamp)
  {
    this.Initialize();
    this.m_statusCode = statusCode;
    this.m_serverTimestamp = serverTimestamp;
  }

  public DataValue(Variant value, StatusCode statusCode)
  {
    this.Initialize();
    this.m_value = value;
    this.m_statusCode = statusCode;
  }

  public DataValue(Variant value, StatusCode statusCode, DateTime sourceTimestamp)
  {
    this.Initialize();
    this.m_value = value;
    this.m_statusCode = statusCode;
    this.m_sourceTimestamp = sourceTimestamp;
  }

  public DataValue(
    Variant value,
    StatusCode statusCode,
    DateTime sourceTimestamp,
    DateTime serverTimestamp)
  {
    this.Initialize();
    this.m_value = value;
    this.m_statusCode = statusCode;
    this.m_sourceTimestamp = sourceTimestamp;
    this.m_serverTimestamp = serverTimestamp;
  }

  private void Initialize()
  {
    this.m_value = Variant.Null;
    this.m_statusCode = (StatusCode) 0U;
    this.m_sourceTimestamp = DateTime.MinValue;
    this.m_serverTimestamp = DateTime.MinValue;
  }

  public override bool Equals(object obj)
  {
    if (this == obj)
      return true;
    return obj is DataValue dataValue && !(this.m_statusCode != dataValue.m_statusCode) && !(this.m_serverTimestamp != dataValue.m_serverTimestamp) && !(this.m_sourceTimestamp != dataValue.m_sourceTimestamp) && (int) this.m_serverPicoseconds == (int) dataValue.m_serverPicoseconds && (int) this.m_sourcePicoseconds == (int) dataValue.m_sourcePicoseconds && Utils.IsEqual(this.m_value.Value, dataValue.m_value.Value);
  }

  public bool Equals(DataValue other)
  {
    if (this == other)
      return true;
    return other != null && !(this.m_statusCode != other.m_statusCode) && !(this.m_serverTimestamp != other.m_serverTimestamp) && !(this.m_sourceTimestamp != other.m_sourceTimestamp) && (int) this.m_serverPicoseconds == (int) other.m_serverPicoseconds && (int) this.m_sourcePicoseconds == (int) other.m_sourcePicoseconds && Utils.IsEqual(this.m_value.Value, other.m_value.Value);
  }

  public override int GetHashCode()
  {
    return this.m_value.Value != null ? this.m_value.Value.GetHashCode() : this.m_statusCode.GetHashCode();
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format != null)
      throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
    return string.Format(formatProvider, "{0}", (object) this.m_value);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new DataValue(this);

  public object Value
  {
    get => this.m_value.Value;
    set => this.m_value.Value = value;
  }

  [DataMember(Name = "Value", Order = 1, IsRequired = false)]
  public Variant WrappedValue
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  [DataMember(Order = 2, IsRequired = false)]
  public StatusCode StatusCode
  {
    get => this.m_statusCode;
    set => this.m_statusCode = value;
  }

  [DataMember(Order = 3, IsRequired = false)]
  public DateTime SourceTimestamp
  {
    get => this.m_sourceTimestamp;
    set => this.m_sourceTimestamp = value;
  }

  [DataMember(Order = 4, IsRequired = false)]
  public ushort SourcePicoseconds
  {
    get => this.m_sourcePicoseconds;
    set => this.m_sourcePicoseconds = value;
  }

  [DataMember(Order = 5, IsRequired = false)]
  public DateTime ServerTimestamp
  {
    get => this.m_serverTimestamp;
    set => this.m_serverTimestamp = value;
  }

  [DataMember(Order = 6, IsRequired = false)]
  public ushort ServerPicoseconds
  {
    get => this.m_serverPicoseconds;
    set => this.m_serverPicoseconds = value;
  }

  public static bool IsGood(DataValue value)
  {
    return value != null && StatusCode.IsGood(value.m_statusCode);
  }

  public static bool IsNotGood(DataValue value)
  {
    return value == null || StatusCode.IsNotGood(value.m_statusCode);
  }

  public static bool IsUncertain(DataValue value)
  {
    return value != null && StatusCode.IsUncertain(value.m_statusCode);
  }

  public static bool IsNotUncertain(DataValue value)
  {
    return value != null && StatusCode.IsNotUncertain(value.m_statusCode);
  }

  public static bool IsBad(DataValue value)
  {
    return value == null || StatusCode.IsBad(value.m_statusCode);
  }

  public static bool IsNotBad(DataValue value)
  {
    return value != null && StatusCode.IsNotBad(value.m_statusCode);
  }

  public object GetValue(Type expectedType)
  {
    object body = this.Value;
    if (expectedType != (Type) null && body != null)
    {
      if (StatusCode.IsBad(this.StatusCode))
        return (object) null;
      if (body is ExtensionObject extensionObject)
        body = extensionObject.Body;
      if (!expectedType.IsInstanceOfType(body))
        throw ServiceResultException.Create(2155085824U /*0x80740000*/, "DataValue is not of type {0}.", (object) expectedType.Name);
    }
    return body;
  }

  public T GetValue<T>(T defaultValue)
  {
    if (StatusCode.IsNotGood(this.StatusCode))
      return defaultValue;
    if (typeof (T).IsInstanceOfType(this.Value))
      return (T) this.Value;
    return this.Value is ExtensionObject extensionObject && typeof (T).IsInstanceOfType(extensionObject.Body) ? (T) extensionObject.Body : defaultValue;
  }
}
