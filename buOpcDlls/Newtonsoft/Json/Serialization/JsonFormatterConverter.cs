// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.JsonFormatterConverter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;
using System;
using System.Globalization;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Runtime.Serialization;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(1)]
[Nullable(0)]
internal class JsonFormatterConverter : IFormatterConverter
{
  private readonly JsonSerializerInternalReader _reader;
  private readonly JsonISerializableContract _contract;
  [Nullable(2)]
  private readonly JsonProperty _member;

  public JsonFormatterConverter(
    JsonSerializerInternalReader reader,
    JsonISerializableContract contract,
    [Nullable(2)] JsonProperty member)
  {
    ValidationUtils.ArgumentNotNull((object) reader, nameof (reader));
    ValidationUtils.ArgumentNotNull((object) contract, nameof (contract));
    this._reader = reader;
    this._contract = contract;
    this._member = member;
  }

  private T GetTokenValue<[Nullable(2)] T>(object value)
  {
    ValidationUtils.ArgumentNotNull(value, nameof (value));
    return (T) System.Convert.ChangeType(((JValue) value).Value, typeof (T), (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public object Convert(object value, Type type)
  {
    ValidationUtils.ArgumentNotNull(value, nameof (value));
    if (!(value is JToken token))
      throw new ArgumentException("Value is not a JToken.", nameof (value));
    return this._reader.CreateISerializableItem(token, type, this._contract, this._member);
  }

  public object Convert(object value, TypeCode typeCode)
  {
    ValidationUtils.ArgumentNotNull(value, nameof (value));
    return System.Convert.ChangeType(value is JValue jvalue ? jvalue.Value : value, typeCode, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public bool ToBoolean(object value) => this.GetTokenValue<bool>(value);

  public byte ToByte(object value) => this.GetTokenValue<byte>(value);

  public char ToChar(object value) => this.GetTokenValue<char>(value);

  public DateTime ToDateTime(object value) => this.GetTokenValue<DateTime>(value);

  public Decimal ToDecimal(object value) => this.GetTokenValue<Decimal>(value);

  public double ToDouble(object value) => this.GetTokenValue<double>(value);

  public short ToInt16(object value) => this.GetTokenValue<short>(value);

  public int ToInt32(object value) => this.GetTokenValue<int>(value);

  public long ToInt64(object value) => this.GetTokenValue<long>(value);

  public sbyte ToSByte(object value) => this.GetTokenValue<sbyte>(value);

  public float ToSingle(object value) => this.GetTokenValue<float>(value);

  public string ToString(object value) => this.GetTokenValue<string>(value);

  public ushort ToUInt16(object value) => this.GetTokenValue<ushort>(value);

  public uint ToUInt32(object value) => this.GetTokenValue<uint>(value);

  public ulong ToUInt64(object value) => this.GetTokenValue<ulong>(value);
}
