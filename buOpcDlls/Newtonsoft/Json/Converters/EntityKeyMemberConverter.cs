// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Converters.EntityKeyMemberConverter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Utilities;
using System;
using System.Globalization;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Converters;

[NullableContext(1)]
[Nullable(0)]
public class EntityKeyMemberConverter : JsonConverter
{
  private const string EntityKeyMemberFullTypeName = "System.Data.EntityKeyMember";
  private const string KeyPropertyName = "Key";
  private const string TypePropertyName = "Type";
  private const string ValuePropertyName = "Value";
  [Nullable(2)]
  private static ReflectionObject _reflectionObject;

  public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer)
  {
    if (value == null)
    {
      writer.WriteNull();
    }
    else
    {
      EntityKeyMemberConverter.EnsureReflectionObject(value.GetType());
      DefaultContractResolver contractResolver = serializer.ContractResolver as DefaultContractResolver;
      string str = (string) EntityKeyMemberConverter._reflectionObject.GetValue(value, "Key");
      object obj = EntityKeyMemberConverter._reflectionObject.GetValue(value, "Value");
      Type type = obj?.GetType();
      writer.WriteStartObject();
      writer.WritePropertyName(contractResolver != null ? contractResolver.GetResolvedPropertyName("Key") : "Key");
      writer.WriteValue(str);
      writer.WritePropertyName(contractResolver != null ? contractResolver.GetResolvedPropertyName("Type") : "Type");
      writer.WriteValue(type?.FullName);
      writer.WritePropertyName(contractResolver != null ? contractResolver.GetResolvedPropertyName("Value") : "Value");
      if (type != (Type) null)
      {
        string s;
        if (JsonSerializerInternalWriter.TryConvertToString(obj, type, out s))
          writer.WriteValue(s);
        else
          writer.WriteValue(obj);
      }
      else
        writer.WriteNull();
      writer.WriteEndObject();
    }
  }

  private static void ReadAndAssertProperty(JsonReader reader, string propertyName)
  {
    reader.ReadAndAssert();
    if (reader.TokenType != JsonToken.PropertyName || !string.Equals(reader.Value?.ToString(), propertyName, StringComparison.OrdinalIgnoreCase))
      throw new JsonSerializationException("Expected JSON property '{0}'.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) propertyName));
  }

  [return: Nullable(2)]
  public override object ReadJson(
    JsonReader reader,
    Type objectType,
    [Nullable(2)] object existingValue,
    JsonSerializer serializer)
  {
    EntityKeyMemberConverter.EnsureReflectionObject(objectType);
    object target = EntityKeyMemberConverter._reflectionObject.Creator();
    EntityKeyMemberConverter.ReadAndAssertProperty(reader, "Key");
    reader.ReadAndAssert();
    EntityKeyMemberConverter._reflectionObject.SetValue(target, "Key", (object) reader.Value?.ToString());
    EntityKeyMemberConverter.ReadAndAssertProperty(reader, "Type");
    reader.ReadAndAssert();
    Type type = Type.GetType(reader.Value?.ToString());
    EntityKeyMemberConverter.ReadAndAssertProperty(reader, "Value");
    reader.ReadAndAssert();
    EntityKeyMemberConverter._reflectionObject.SetValue(target, "Value", serializer.Deserialize(reader, type));
    reader.ReadAndAssert();
    return target;
  }

  private static void EnsureReflectionObject(Type objectType)
  {
    if (EntityKeyMemberConverter._reflectionObject != null)
      return;
    EntityKeyMemberConverter._reflectionObject = ReflectionObject.Create(objectType, "Key", "Value");
  }

  public override bool CanConvert(Type objectType)
  {
    return objectType.AssignableToTypeName("System.Data.EntityKeyMember", false);
  }
}
