// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.JsonConvert
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Text;
using System.Xml;
using System.Xml.Linq;

#nullable disable
namespace Newtonsoft.Json;

[NullableContext(1)]
[Nullable(0)]
public static class JsonConvert
{
  public static readonly string True = "true";
  public static readonly string False = "false";
  public static readonly string Null = "null";
  public static readonly string Undefined = "undefined";
  public static readonly string PositiveInfinity = "Infinity";
  public static readonly string NegativeInfinity = "-Infinity";
  public static readonly string NaN = nameof (NaN);

  [field: Nullable(new byte[] {2, 1})]
  [Nullable(new byte[] {2, 1})]
  public static Func<JsonSerializerSettings> DefaultSettings { [return: Nullable(new byte[] {2, 1})] get; [param: Nullable(new byte[] {2, 1})] set; }

  public static string ToString(DateTime value)
  {
    return JsonConvert.ToString(value, DateFormatHandling.IsoDateFormat, DateTimeZoneHandling.RoundtripKind);
  }

  public static string ToString(
    DateTime value,
    DateFormatHandling format,
    DateTimeZoneHandling timeZoneHandling)
  {
    DateTime dateTime = DateTimeUtils.EnsureDateTime(value, timeZoneHandling);
    using (StringWriter stringWriter = StringUtils.CreateStringWriter(64 /*0x40*/))
    {
      stringWriter.Write('"');
      DateTimeUtils.WriteDateTimeString((TextWriter) stringWriter, dateTime, format, (string) null, CultureInfo.InvariantCulture);
      stringWriter.Write('"');
      return stringWriter.ToString();
    }
  }

  public static string ToString(DateTimeOffset value)
  {
    return JsonConvert.ToString(value, DateFormatHandling.IsoDateFormat);
  }

  public static string ToString(DateTimeOffset value, DateFormatHandling format)
  {
    using (StringWriter stringWriter = StringUtils.CreateStringWriter(64 /*0x40*/))
    {
      stringWriter.Write('"');
      DateTimeUtils.WriteDateTimeOffsetString((TextWriter) stringWriter, value, format, (string) null, CultureInfo.InvariantCulture);
      stringWriter.Write('"');
      return stringWriter.ToString();
    }
  }

  public static string ToString(bool value) => !value ? JsonConvert.False : JsonConvert.True;

  public static string ToString(char value) => JsonConvert.ToString(char.ToString(value));

  public static string ToString(Enum value) => value.ToString("D");

  public static string ToString(int value)
  {
    return value.ToString((string) null, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public static string ToString(short value)
  {
    return value.ToString((string) null, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  [CLSCompliant(false)]
  public static string ToString(ushort value)
  {
    return value.ToString((string) null, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  [CLSCompliant(false)]
  public static string ToString(uint value)
  {
    return value.ToString((string) null, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public static string ToString(long value)
  {
    return value.ToString((string) null, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  private static string ToStringInternal(BigInteger value)
  {
    return value.ToString((string) null, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  [CLSCompliant(false)]
  public static string ToString(ulong value)
  {
    return value.ToString((string) null, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public static string ToString(float value)
  {
    return JsonConvert.EnsureDecimalPlace((double) value, value.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture));
  }

  internal static string ToString(
    float value,
    FloatFormatHandling floatFormatHandling,
    char quoteChar,
    bool nullable)
  {
    return JsonConvert.EnsureFloatFormat((double) value, JsonConvert.EnsureDecimalPlace((double) value, value.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture)), floatFormatHandling, quoteChar, nullable);
  }

  private static string EnsureFloatFormat(
    double value,
    string text,
    FloatFormatHandling floatFormatHandling,
    char quoteChar,
    bool nullable)
  {
    if (floatFormatHandling == FloatFormatHandling.Symbol || !double.IsInfinity(value) && !double.IsNaN(value))
      return text;
    if (floatFormatHandling != FloatFormatHandling.DefaultValue)
      return quoteChar.ToString() + text + quoteChar.ToString();
    return nullable ? JsonConvert.Null : "0.0";
  }

  public static string ToString(double value)
  {
    return JsonConvert.EnsureDecimalPlace(value, value.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture));
  }

  internal static string ToString(
    double value,
    FloatFormatHandling floatFormatHandling,
    char quoteChar,
    bool nullable)
  {
    return JsonConvert.EnsureFloatFormat(value, JsonConvert.EnsureDecimalPlace(value, value.ToString("R", (IFormatProvider) CultureInfo.InvariantCulture)), floatFormatHandling, quoteChar, nullable);
  }

  private static string EnsureDecimalPlace(double value, string text)
  {
    return !double.IsNaN(value) && !double.IsInfinity(value) && StringUtils.IndexOf(text, '.') == -1 && StringUtils.IndexOf(text, 'E') == -1 && StringUtils.IndexOf(text, 'e') == -1 ? text + ".0" : text;
  }

  private static string EnsureDecimalPlace(string text)
  {
    return StringUtils.IndexOf(text, '.') != -1 ? text : text + ".0";
  }

  public static string ToString(byte value)
  {
    return value.ToString((string) null, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  [CLSCompliant(false)]
  public static string ToString(sbyte value)
  {
    return value.ToString((string) null, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public static string ToString(Decimal value)
  {
    return JsonConvert.EnsureDecimalPlace(value.ToString((string) null, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  public static string ToString(Guid value) => JsonConvert.ToString(value, '"');

  internal static string ToString(Guid value, char quoteChar)
  {
    string str1 = value.ToString("D", (IFormatProvider) CultureInfo.InvariantCulture);
    string str2 = quoteChar.ToString((IFormatProvider) CultureInfo.InvariantCulture);
    return str2 + str1 + str2;
  }

  public static string ToString(TimeSpan value) => JsonConvert.ToString(value, '"');

  internal static string ToString(TimeSpan value, char quoteChar)
  {
    return JsonConvert.ToString(value.ToString(), quoteChar);
  }

  public static string ToString([Nullable(2)] Uri value)
  {
    return value == (Uri) null ? JsonConvert.Null : JsonConvert.ToString(value, '"');
  }

  internal static string ToString(Uri value, char quoteChar)
  {
    return JsonConvert.ToString(value.OriginalString, quoteChar);
  }

  public static string ToString([Nullable(2)] string value) => JsonConvert.ToString(value, '"');

  public static string ToString([Nullable(2)] string value, char delimiter)
  {
    return JsonConvert.ToString(value, delimiter, StringEscapeHandling.Default);
  }

  public static string ToString(
    [Nullable(2)] string value,
    char delimiter,
    StringEscapeHandling stringEscapeHandling)
  {
    if (delimiter != '"' && delimiter != '\'')
      throw new ArgumentException("Delimiter must be a single or double quote.", nameof (delimiter));
    return JavaScriptUtils.ToEscapedJavaScriptString(value, delimiter, true, stringEscapeHandling);
  }

  public static string ToString([Nullable(2)] object value)
  {
    if (value == null)
      return JsonConvert.Null;
    switch (ConvertUtils.GetTypeCode(value.GetType()))
    {
      case PrimitiveTypeCode.Char:
        return JsonConvert.ToString((char) value);
      case PrimitiveTypeCode.Boolean:
        return JsonConvert.ToString((bool) value);
      case PrimitiveTypeCode.SByte:
        return JsonConvert.ToString((sbyte) value);
      case PrimitiveTypeCode.Int16:
        return JsonConvert.ToString((short) value);
      case PrimitiveTypeCode.UInt16:
        return JsonConvert.ToString((ushort) value);
      case PrimitiveTypeCode.Int32:
        return JsonConvert.ToString((int) value);
      case PrimitiveTypeCode.Byte:
        return JsonConvert.ToString((byte) value);
      case PrimitiveTypeCode.UInt32:
        return JsonConvert.ToString((uint) value);
      case PrimitiveTypeCode.Int64:
        return JsonConvert.ToString((long) value);
      case PrimitiveTypeCode.UInt64:
        return JsonConvert.ToString((ulong) value);
      case PrimitiveTypeCode.Single:
        return JsonConvert.ToString((float) value);
      case PrimitiveTypeCode.Double:
        return JsonConvert.ToString((double) value);
      case PrimitiveTypeCode.DateTime:
        return JsonConvert.ToString((DateTime) value);
      case PrimitiveTypeCode.DateTimeOffset:
        return JsonConvert.ToString((DateTimeOffset) value);
      case PrimitiveTypeCode.Decimal:
        return JsonConvert.ToString((Decimal) value);
      case PrimitiveTypeCode.Guid:
        return JsonConvert.ToString((Guid) value);
      case PrimitiveTypeCode.TimeSpan:
        return JsonConvert.ToString((TimeSpan) value);
      case PrimitiveTypeCode.BigInteger:
        return JsonConvert.ToStringInternal((BigInteger) value);
      case PrimitiveTypeCode.Uri:
        return JsonConvert.ToString((Uri) value);
      case PrimitiveTypeCode.String:
        return JsonConvert.ToString((string) value);
      case PrimitiveTypeCode.DBNull:
        return JsonConvert.Null;
      default:
        throw new ArgumentException("Unsupported type: {0}. Use the JsonSerializer class to get the object's JSON representation.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) value.GetType()));
    }
  }

  [DebuggerStepThrough]
  public static string SerializeObject([Nullable(2)] object value)
  {
    return JsonConvert.SerializeObject(value, (Type) null, (JsonSerializerSettings) null);
  }

  [DebuggerStepThrough]
  public static string SerializeObject([Nullable(2)] object value, Formatting formatting)
  {
    return JsonConvert.SerializeObject(value, formatting, (JsonSerializerSettings) null);
  }

  [DebuggerStepThrough]
  public static string SerializeObject([Nullable(2)] object value, params JsonConverter[] converters)
  {
    JsonSerializerSettings serializerSettings;
    if (converters != null && converters.Length != 0)
      serializerSettings = new JsonSerializerSettings()
      {
        Converters = (IList<JsonConverter>) converters
      };
    else
      serializerSettings = (JsonSerializerSettings) null;
    JsonSerializerSettings settings = serializerSettings;
    return JsonConvert.SerializeObject(value, (Type) null, settings);
  }

  [DebuggerStepThrough]
  public static string SerializeObject(
    [Nullable(2)] object value,
    Formatting formatting,
    params JsonConverter[] converters)
  {
    JsonSerializerSettings serializerSettings;
    if (converters != null && converters.Length != 0)
      serializerSettings = new JsonSerializerSettings()
      {
        Converters = (IList<JsonConverter>) converters
      };
    else
      serializerSettings = (JsonSerializerSettings) null;
    JsonSerializerSettings settings = serializerSettings;
    return JsonConvert.SerializeObject(value, (Type) null, formatting, settings);
  }

  [NullableContext(2)]
  [DebuggerStepThrough]
  [return: Nullable(1)]
  public static string SerializeObject(object value, JsonSerializerSettings settings)
  {
    return JsonConvert.SerializeObject(value, (Type) null, settings);
  }

  [NullableContext(2)]
  [DebuggerStepThrough]
  [return: Nullable(1)]
  public static string SerializeObject(object value, Type type, JsonSerializerSettings settings)
  {
    JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(settings);
    return JsonConvert.SerializeObjectInternal(value, type, jsonSerializer);
  }

  [NullableContext(2)]
  [DebuggerStepThrough]
  [return: Nullable(1)]
  public static string SerializeObject(
    object value,
    Formatting formatting,
    JsonSerializerSettings settings)
  {
    return JsonConvert.SerializeObject(value, (Type) null, formatting, settings);
  }

  [NullableContext(2)]
  [DebuggerStepThrough]
  [return: Nullable(1)]
  public static string SerializeObject(
    object value,
    Type type,
    Formatting formatting,
    JsonSerializerSettings settings)
  {
    JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(settings);
    jsonSerializer.Formatting = formatting;
    return JsonConvert.SerializeObjectInternal(value, type, jsonSerializer);
  }

  private static string SerializeObjectInternal(
    [Nullable(2)] object value,
    [Nullable(2)] Type type,
    JsonSerializer jsonSerializer)
  {
    StringWriter stringWriter = new StringWriter(new StringBuilder(256 /*0x0100*/), (IFormatProvider) CultureInfo.InvariantCulture);
    using (JsonTextWriter jsonTextWriter = new JsonTextWriter((TextWriter) stringWriter))
    {
      jsonTextWriter.Formatting = jsonSerializer.Formatting;
      jsonSerializer.Serialize((JsonWriter) jsonTextWriter, value, type);
    }
    return stringWriter.ToString();
  }

  [DebuggerStepThrough]
  [return: Nullable(2)]
  public static object DeserializeObject(string value)
  {
    return JsonConvert.DeserializeObject(value, (Type) null, (JsonSerializerSettings) null);
  }

  [DebuggerStepThrough]
  [return: Nullable(2)]
  public static object DeserializeObject(string value, JsonSerializerSettings settings)
  {
    return JsonConvert.DeserializeObject(value, (Type) null, settings);
  }

  [DebuggerStepThrough]
  [return: Nullable(2)]
  public static object DeserializeObject(string value, Type type)
  {
    return JsonConvert.DeserializeObject(value, type, (JsonSerializerSettings) null);
  }

  [NullableContext(2)]
  [DebuggerStepThrough]
  public static T DeserializeObject<T>([Nullable(1)] string value)
  {
    return JsonConvert.DeserializeObject<T>(value, (JsonSerializerSettings) null);
  }

  [DebuggerStepThrough]
  [return: Nullable(2)]
  public static T DeserializeAnonymousType<[Nullable(2)] T>(string value, T anonymousTypeObject)
  {
    return JsonConvert.DeserializeObject<T>(value);
  }

  [DebuggerStepThrough]
  [return: Nullable(2)]
  public static T DeserializeAnonymousType<[Nullable(2)] T>(
    string value,
    T anonymousTypeObject,
    JsonSerializerSettings settings)
  {
    return JsonConvert.DeserializeObject<T>(value, settings);
  }

  [DebuggerStepThrough]
  [return: Nullable(2)]
  public static T DeserializeObject<[Nullable(2)] T>(
    string value,
    params JsonConverter[] converters)
  {
    return (T) JsonConvert.DeserializeObject(value, typeof (T), converters);
  }

  [NullableContext(2)]
  [DebuggerStepThrough]
  public static T DeserializeObject<T>([Nullable(1)] string value, JsonSerializerSettings settings)
  {
    return (T) JsonConvert.DeserializeObject(value, typeof (T), settings);
  }

  [DebuggerStepThrough]
  [return: Nullable(2)]
  public static object DeserializeObject(
    string value,
    Type type,
    params JsonConverter[] converters)
  {
    JsonSerializerSettings serializerSettings;
    if (converters != null && converters.Length != 0)
      serializerSettings = new JsonSerializerSettings()
      {
        Converters = (IList<JsonConverter>) converters
      };
    else
      serializerSettings = (JsonSerializerSettings) null;
    JsonSerializerSettings settings = serializerSettings;
    return JsonConvert.DeserializeObject(value, type, settings);
  }

  [NullableContext(2)]
  public static object DeserializeObject([Nullable(1)] string value, Type type, JsonSerializerSettings settings)
  {
    ValidationUtils.ArgumentNotNull((object) value, nameof (value));
    JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(settings);
    if (!jsonSerializer.IsCheckAdditionalContentSet())
      jsonSerializer.CheckAdditionalContent = true;
    using (JsonTextReader reader = new JsonTextReader((TextReader) new StringReader(value)))
      return jsonSerializer.Deserialize((JsonReader) reader, type);
  }

  [DebuggerStepThrough]
  public static void PopulateObject(string value, object target)
  {
    JsonConvert.PopulateObject(value, target, (JsonSerializerSettings) null);
  }

  public static void PopulateObject(string value, object target, [Nullable(2)] JsonSerializerSettings settings)
  {
    using (JsonReader reader = (JsonReader) new JsonTextReader((TextReader) new StringReader(value)))
    {
      JsonSerializer.CreateDefault(settings).Populate(reader, target);
      if (settings == null || !settings.CheckAdditionalContent)
        return;
      while (reader.Read())
      {
        if (reader.TokenType != JsonToken.Comment)
          throw JsonSerializationException.Create(reader, "Additional text found in JSON string after finishing deserializing object.");
      }
    }
  }

  public static string SerializeXmlNode([Nullable(2)] XmlNode node)
  {
    return JsonConvert.SerializeXmlNode(node, Formatting.None);
  }

  public static string SerializeXmlNode([Nullable(2)] XmlNode node, Formatting formatting)
  {
    XmlNodeConverter xmlNodeConverter = new XmlNodeConverter();
    return JsonConvert.SerializeObject((object) node, formatting, (JsonConverter) xmlNodeConverter);
  }

  public static string SerializeXmlNode([Nullable(2)] XmlNode node, Formatting formatting, bool omitRootObject)
  {
    XmlNodeConverter xmlNodeConverter = new XmlNodeConverter()
    {
      OmitRootObject = omitRootObject
    };
    return JsonConvert.SerializeObject((object) node, formatting, (JsonConverter) xmlNodeConverter);
  }

  [return: Nullable(2)]
  public static XmlDocument DeserializeXmlNode(string value)
  {
    return JsonConvert.DeserializeXmlNode(value, (string) null);
  }

  [NullableContext(2)]
  public static XmlDocument DeserializeXmlNode([Nullable(1)] string value, string deserializeRootElementName)
  {
    return JsonConvert.DeserializeXmlNode(value, deserializeRootElementName, false);
  }

  [NullableContext(2)]
  public static XmlDocument DeserializeXmlNode(
    [Nullable(1)] string value,
    string deserializeRootElementName,
    bool writeArrayAttribute)
  {
    return JsonConvert.DeserializeXmlNode(value, deserializeRootElementName, writeArrayAttribute, false);
  }

  [NullableContext(2)]
  public static XmlDocument DeserializeXmlNode(
    [Nullable(1)] string value,
    string deserializeRootElementName,
    bool writeArrayAttribute,
    bool encodeSpecialCharacters)
  {
    return (XmlDocument) JsonConvert.DeserializeObject(value, typeof (XmlDocument), (JsonConverter) new XmlNodeConverter()
    {
      DeserializeRootElementName = deserializeRootElementName,
      WriteArrayAttribute = writeArrayAttribute,
      EncodeSpecialCharacters = encodeSpecialCharacters
    });
  }

  public static string SerializeXNode([Nullable(2)] XObject node)
  {
    return JsonConvert.SerializeXNode(node, Formatting.None);
  }

  public static string SerializeXNode([Nullable(2)] XObject node, Formatting formatting)
  {
    return JsonConvert.SerializeXNode(node, formatting, false);
  }

  public static string SerializeXNode([Nullable(2)] XObject node, Formatting formatting, bool omitRootObject)
  {
    XmlNodeConverter xmlNodeConverter = new XmlNodeConverter()
    {
      OmitRootObject = omitRootObject
    };
    return JsonConvert.SerializeObject((object) node, formatting, (JsonConverter) xmlNodeConverter);
  }

  [return: Nullable(2)]
  public static XDocument DeserializeXNode(string value)
  {
    return JsonConvert.DeserializeXNode(value, (string) null);
  }

  [NullableContext(2)]
  public static XDocument DeserializeXNode([Nullable(1)] string value, string deserializeRootElementName)
  {
    return JsonConvert.DeserializeXNode(value, deserializeRootElementName, false);
  }

  [NullableContext(2)]
  public static XDocument DeserializeXNode(
    [Nullable(1)] string value,
    string deserializeRootElementName,
    bool writeArrayAttribute)
  {
    return JsonConvert.DeserializeXNode(value, deserializeRootElementName, writeArrayAttribute, false);
  }

  [NullableContext(2)]
  public static XDocument DeserializeXNode(
    [Nullable(1)] string value,
    string deserializeRootElementName,
    bool writeArrayAttribute,
    bool encodeSpecialCharacters)
  {
    return (XDocument) JsonConvert.DeserializeObject(value, typeof (XDocument), (JsonConverter) new XmlNodeConverter()
    {
      DeserializeRootElementName = deserializeRootElementName,
      WriteArrayAttribute = writeArrayAttribute,
      EncodeSpecialCharacters = encodeSpecialCharacters
    });
  }
}
