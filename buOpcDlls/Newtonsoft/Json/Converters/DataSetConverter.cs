// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.DataSetConverter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Serialization;
using System;
using System.Data;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Converters;

[NullableContext(1)]
[Nullable(0)]
public class DataSetConverter : JsonConverter
{
  public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer)
  {
    if (value == null)
    {
      writer.WriteNull();
    }
    else
    {
      DataSet dataSet = (DataSet) value;
      DefaultContractResolver contractResolver = serializer.ContractResolver as DefaultContractResolver;
      DataTableConverter dataTableConverter = new DataTableConverter();
      writer.WriteStartObject();
      foreach (DataTable table in (InternalDataCollectionBase) dataSet.Tables)
      {
        writer.WritePropertyName(contractResolver != null ? contractResolver.GetResolvedPropertyName(table.TableName) : table.TableName);
        dataTableConverter.WriteJson(writer, (object) table, serializer);
      }
      writer.WriteEndObject();
    }
  }

  [return: Nullable(2)]
  public override object ReadJson(
    JsonReader reader,
    Type objectType,
    [Nullable(2)] object existingValue,
    JsonSerializer serializer)
  {
    if (reader.TokenType == JsonToken.Null)
      return (object) null;
    DataSet dataSet = objectType == typeof (DataSet) ? new DataSet() : (DataSet) Activator.CreateInstance(objectType);
    DataTableConverter dataTableConverter = new DataTableConverter();
    reader.ReadAndAssert();
    while (reader.TokenType == JsonToken.PropertyName)
    {
      DataTable table1 = dataSet.Tables[(string) reader.Value];
      int num = table1 != null ? 1 : 0;
      DataTable table2 = (DataTable) dataTableConverter.ReadJson(reader, typeof (DataTable), (object) table1, serializer);
      if (num == 0)
        dataSet.Tables.Add(table2);
      reader.ReadAndAssert();
    }
    return (object) dataSet;
  }

  public override bool CanConvert(Type valueType) => typeof (DataSet).IsAssignableFrom(valueType);
}
