// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Serialization.JsonPrimitiveContract
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Serialization;

[NullableContext(1)]
[Nullable(0)]
public class JsonPrimitiveContract : JsonContract
{
  private static readonly Dictionary<Type, ReadType> ReadTypeMap = new Dictionary<Type, ReadType>()
  {
    [typeof (byte[])] = ReadType.ReadAsBytes,
    [typeof (byte)] = ReadType.ReadAsInt32,
    [typeof (short)] = ReadType.ReadAsInt32,
    [typeof (int)] = ReadType.ReadAsInt32,
    [typeof (Decimal)] = ReadType.ReadAsDecimal,
    [typeof (bool)] = ReadType.ReadAsBoolean,
    [typeof (string)] = ReadType.ReadAsString,
    [typeof (DateTime)] = ReadType.ReadAsDateTime,
    [typeof (DateTimeOffset)] = ReadType.ReadAsDateTimeOffset,
    [typeof (float)] = ReadType.ReadAsDouble,
    [typeof (double)] = ReadType.ReadAsDouble,
    [typeof (long)] = ReadType.ReadAsInt64
  };

  internal PrimitiveTypeCode TypeCode { get; set; }

  public JsonPrimitiveContract(Type underlyingType)
    : base(underlyingType)
  {
    this.ContractType = JsonContractType.Primitive;
    this.TypeCode = ConvertUtils.GetTypeCode(underlyingType);
    this.IsReadOnlyOrFixedSize = true;
    ReadType readType;
    if (!JsonPrimitiveContract.ReadTypeMap.TryGetValue(this.NonNullableUnderlyingType, out readType))
      return;
    this.InternalReadType = readType;
  }
}
