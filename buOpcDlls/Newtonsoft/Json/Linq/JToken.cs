// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.JToken
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Linq.JsonPath;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices.Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Newtonsoft.Json.Linq;

[NullableContext(1)]
[Nullable(0)]
public abstract class JToken : 
  IJEnumerable<JToken>,
  IEnumerable<JToken>,
  IEnumerable,
  IJsonLineInfo,
  ICloneable,
  IDynamicMetaObjectProvider
{
  [Nullable(2)]
  private static JTokenEqualityComparer _equalityComparer;
  [Nullable(2)]
  private JContainer _parent;
  [Nullable(2)]
  private JToken _previous;
  [Nullable(2)]
  private JToken _next;
  [Nullable(2)]
  private object _annotations;
  private static readonly JTokenType[] BooleanTypes = new JTokenType[6]
  {
    JTokenType.Integer,
    JTokenType.Float,
    JTokenType.String,
    JTokenType.Comment,
    JTokenType.Raw,
    JTokenType.Boolean
  };
  private static readonly JTokenType[] NumberTypes = new JTokenType[6]
  {
    JTokenType.Integer,
    JTokenType.Float,
    JTokenType.String,
    JTokenType.Comment,
    JTokenType.Raw,
    JTokenType.Boolean
  };
  private static readonly JTokenType[] BigIntegerTypes = new JTokenType[7]
  {
    JTokenType.Integer,
    JTokenType.Float,
    JTokenType.String,
    JTokenType.Comment,
    JTokenType.Raw,
    JTokenType.Boolean,
    JTokenType.Bytes
  };
  private static readonly JTokenType[] StringTypes = new JTokenType[11]
  {
    JTokenType.Date,
    JTokenType.Integer,
    JTokenType.Float,
    JTokenType.String,
    JTokenType.Comment,
    JTokenType.Raw,
    JTokenType.Boolean,
    JTokenType.Bytes,
    JTokenType.Guid,
    JTokenType.TimeSpan,
    JTokenType.Uri
  };
  private static readonly JTokenType[] GuidTypes = new JTokenType[5]
  {
    JTokenType.String,
    JTokenType.Comment,
    JTokenType.Raw,
    JTokenType.Guid,
    JTokenType.Bytes
  };
  private static readonly JTokenType[] TimeSpanTypes = new JTokenType[4]
  {
    JTokenType.String,
    JTokenType.Comment,
    JTokenType.Raw,
    JTokenType.TimeSpan
  };
  private static readonly JTokenType[] UriTypes = new JTokenType[4]
  {
    JTokenType.String,
    JTokenType.Comment,
    JTokenType.Raw,
    JTokenType.Uri
  };
  private static readonly JTokenType[] CharTypes = new JTokenType[5]
  {
    JTokenType.Integer,
    JTokenType.Float,
    JTokenType.String,
    JTokenType.Comment,
    JTokenType.Raw
  };
  private static readonly JTokenType[] DateTimeTypes = new JTokenType[4]
  {
    JTokenType.Date,
    JTokenType.String,
    JTokenType.Comment,
    JTokenType.Raw
  };
  private static readonly JTokenType[] BytesTypes = new JTokenType[5]
  {
    JTokenType.Bytes,
    JTokenType.String,
    JTokenType.Comment,
    JTokenType.Raw,
    JTokenType.Integer
  };

  public virtual Task WriteToAsync(
    JsonWriter writer,
    CancellationToken cancellationToken,
    params JsonConverter[] converters)
  {
    throw new NotImplementedException();
  }

  public Task WriteToAsync(JsonWriter writer, params JsonConverter[] converters)
  {
    return this.WriteToAsync(writer, new CancellationToken(), converters);
  }

  public static Task<JToken> ReadFromAsync(JsonReader reader, CancellationToken cancellationToken = default (CancellationToken))
  {
    return JToken.ReadFromAsync(reader, (JsonLoadSettings) null, cancellationToken);
  }

  public static async Task<JToken> ReadFromAsync(
    JsonReader reader,
    [Nullable(2)] JsonLoadSettings settings,
    CancellationToken cancellationToken = default (CancellationToken))
  {
    ValidationUtils.ArgumentNotNull((object) reader, nameof (reader));
    if (reader.TokenType == JsonToken.None)
    {
      if (!await (settings == null || settings.CommentHandling != CommentHandling.Ignore ? reader.ReadAsync(cancellationToken) : reader.ReadAndMoveToContentAsync(cancellationToken)).ConfigureAwait(false))
        throw JsonReaderException.Create(reader, "Error reading JToken from JsonReader.");
    }
    IJsonLineInfo lineInfo = reader as IJsonLineInfo;
    switch (reader.TokenType)
    {
      case JsonToken.StartObject:
        return (JToken) await JObject.LoadAsync(reader, settings, cancellationToken).ConfigureAwait(false);
      case JsonToken.StartArray:
        return (JToken) await JArray.LoadAsync(reader, settings, cancellationToken).ConfigureAwait(false);
      case JsonToken.StartConstructor:
        return (JToken) await JConstructor.LoadAsync(reader, settings, cancellationToken).ConfigureAwait(false);
      case JsonToken.PropertyName:
        return (JToken) await JProperty.LoadAsync(reader, settings, cancellationToken).ConfigureAwait(false);
      case JsonToken.Comment:
        JValue comment = JValue.CreateComment(reader.Value?.ToString());
        comment.SetLineInfo(lineInfo, settings);
        return (JToken) comment;
      case JsonToken.Integer:
      case JsonToken.Float:
      case JsonToken.String:
      case JsonToken.Boolean:
      case JsonToken.Date:
      case JsonToken.Bytes:
        JValue jvalue1 = new JValue(reader.Value);
        jvalue1.SetLineInfo(lineInfo, settings);
        return (JToken) jvalue1;
      case JsonToken.Null:
        JValue jvalue2 = JValue.CreateNull();
        jvalue2.SetLineInfo(lineInfo, settings);
        return (JToken) jvalue2;
      case JsonToken.Undefined:
        JValue undefined = JValue.CreateUndefined();
        undefined.SetLineInfo(lineInfo, settings);
        return (JToken) undefined;
      default:
        throw JsonReaderException.Create(reader, "Error reading JToken from JsonReader. Unexpected token: {0}".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType));
    }
  }

  public static Task<JToken> LoadAsync(JsonReader reader, CancellationToken cancellationToken = default (CancellationToken))
  {
    return JToken.LoadAsync(reader, (JsonLoadSettings) null, cancellationToken);
  }

  public static Task<JToken> LoadAsync(
    JsonReader reader,
    [Nullable(2)] JsonLoadSettings settings,
    CancellationToken cancellationToken = default (CancellationToken))
  {
    return JToken.ReadFromAsync(reader, settings, cancellationToken);
  }

  public static JTokenEqualityComparer EqualityComparer
  {
    get
    {
      if (JToken._equalityComparer == null)
        JToken._equalityComparer = new JTokenEqualityComparer();
      return JToken._equalityComparer;
    }
  }

  [Nullable(2)]
  public JContainer Parent
  {
    [NullableContext(2), DebuggerStepThrough] get => this._parent;
    [NullableContext(2)] internal set => this._parent = value;
  }

  public JToken Root
  {
    get
    {
      JContainer parent = this.Parent;
      if (parent == null)
        return this;
      while (parent.Parent != null)
        parent = parent.Parent;
      return (JToken) parent;
    }
  }

  internal abstract JToken CloneToken([Nullable(2)] JsonCloneSettings settings);

  internal abstract bool DeepEquals(JToken node);

  public abstract JTokenType Type { get; }

  public abstract bool HasValues { get; }

  [NullableContext(2)]
  public static bool DeepEquals(JToken t1, JToken t2)
  {
    if (t1 == t2)
      return true;
    return t1 != null && t2 != null && t1.DeepEquals(t2);
  }

  [Nullable(2)]
  public JToken Next
  {
    [NullableContext(2)] get => this._next;
    [NullableContext(2)] internal set => this._next = value;
  }

  [Nullable(2)]
  public JToken Previous
  {
    [NullableContext(2)] get => this._previous;
    [NullableContext(2)] internal set => this._previous = value;
  }

  public string Path
  {
    get
    {
      if (this.Parent == null)
        return string.Empty;
      List<JsonPosition> jsonPositionList1 = new List<JsonPosition>();
      JToken jtoken1 = (JToken) null;
      for (JToken jtoken2 = this; jtoken2 != null; jtoken2 = (JToken) jtoken2.Parent)
      {
        JsonPosition jsonPosition1;
        switch (jtoken2.Type)
        {
          case JTokenType.Array:
          case JTokenType.Constructor:
            if (jtoken1 != null)
            {
              int num = ((IList<JToken>) jtoken2).IndexOf(jtoken1);
              List<JsonPosition> jsonPositionList2 = jsonPositionList1;
              jsonPosition1 = new JsonPosition(JsonContainerType.Array);
              jsonPosition1.Position = num;
              JsonPosition jsonPosition2 = jsonPosition1;
              jsonPositionList2.Add(jsonPosition2);
              break;
            }
            break;
          case JTokenType.Property:
            JProperty jproperty = (JProperty) jtoken2;
            List<JsonPosition> jsonPositionList3 = jsonPositionList1;
            jsonPosition1 = new JsonPosition(JsonContainerType.Object);
            jsonPosition1.PropertyName = jproperty.Name;
            JsonPosition jsonPosition3 = jsonPosition1;
            jsonPositionList3.Add(jsonPosition3);
            break;
        }
        jtoken1 = jtoken2;
      }
      jsonPositionList1.FastReverse<JsonPosition>();
      return JsonPosition.BuildPath(jsonPositionList1, new JsonPosition?());
    }
  }

  internal JToken()
  {
  }

  [NullableContext(2)]
  public void AddAfterSelf(object content)
  {
    if (this._parent == null)
      throw new InvalidOperationException("The parent is missing.");
    this._parent.TryAddInternal(this._parent.IndexOfItem(this) + 1, content, false, true);
  }

  [NullableContext(2)]
  public void AddBeforeSelf(object content)
  {
    if (this._parent == null)
      throw new InvalidOperationException("The parent is missing.");
    this._parent.TryAddInternal(this._parent.IndexOfItem(this), content, false, true);
  }

  public IEnumerable<JToken> Ancestors() => this.GetAncestors(false);

  public IEnumerable<JToken> AncestorsAndSelf() => this.GetAncestors(true);

  internal IEnumerable<JToken> GetAncestors(bool self)
  {
    JToken jtoken = this;
    JToken current;
    for (current = self ? jtoken : (JToken) jtoken.Parent; current != null; current = (JToken) current.Parent)
      yield return current;
    current = (JToken) null;
  }

  public IEnumerable<JToken> AfterSelf()
  {
    if (this.Parent != null)
    {
      JToken o;
      for (o = this.Next; o != null; o = o.Next)
        yield return o;
      o = (JToken) null;
    }
  }

  public IEnumerable<JToken> BeforeSelf()
  {
    JToken jtoken = this;
    if (jtoken.Parent != null)
    {
      JToken o;
      for (o = jtoken.Parent.First; o != jtoken && o != null; o = o.Next)
        yield return o;
      o = (JToken) null;
    }
  }

  [Nullable(2)]
  public virtual JToken this[object key]
  {
    [return: Nullable(2)] get
    {
      throw new InvalidOperationException("Cannot access child value on {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) this.GetType()));
    }
    [param: Nullable(2)] set
    {
      throw new InvalidOperationException("Cannot set child value on {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) this.GetType()));
    }
  }

  [NullableContext(2)]
  public virtual T Value<T>([Nullable(1)] object key)
  {
    JToken token = this[key];
    return token != null ? token.Convert<JToken, T>() : default (T);
  }

  [Nullable(2)]
  public virtual JToken First
  {
    [NullableContext(2)] get
    {
      throw new InvalidOperationException("Cannot access child value on {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) this.GetType()));
    }
  }

  [Nullable(2)]
  public virtual JToken Last
  {
    [NullableContext(2)] get
    {
      throw new InvalidOperationException("Cannot access child value on {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) this.GetType()));
    }
  }

  [return: Nullable(new byte[] {0, 1})]
  public virtual JEnumerable<JToken> Children() => JEnumerable<JToken>.Empty;

  [NullableContext(0)]
  [return: Nullable(new byte[] {0, 1})]
  public JEnumerable<T> Children<T>() where T : JToken
  {
    return new JEnumerable<T>(this.Children().OfType<T>());
  }

  [NullableContext(2)]
  [return: Nullable(new byte[] {1, 2})]
  public virtual IEnumerable<T> Values<T>()
  {
    throw new InvalidOperationException("Cannot access child value on {0}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) this.GetType()));
  }

  public void Remove()
  {
    if (this._parent == null)
      throw new InvalidOperationException("The parent is missing.");
    this._parent.RemoveItem(this);
  }

  public void Replace(JToken value)
  {
    if (this._parent == null)
      throw new InvalidOperationException("The parent is missing.");
    this._parent.ReplaceItem(this, value);
  }

  public abstract void WriteTo(JsonWriter writer, params JsonConverter[] converters);

  public override string ToString() => this.ToString(Formatting.Indented);

  public string ToString(Formatting formatting, params JsonConverter[] converters)
  {
    using (StringWriter stringWriter = new StringWriter((IFormatProvider) CultureInfo.InvariantCulture))
    {
      JsonTextWriter writer = new JsonTextWriter((TextWriter) stringWriter);
      writer.Formatting = formatting;
      this.WriteTo((JsonWriter) writer, converters);
      return stringWriter.ToString();
    }
  }

  [return: Nullable(2)]
  private static JValue EnsureValue(JToken value)
  {
    if (value == null)
      throw new ArgumentNullException(nameof (value));
    if (value is JProperty jproperty)
      value = jproperty.Value;
    return value as JValue;
  }

  private static string GetType(JToken token)
  {
    ValidationUtils.ArgumentNotNull((object) token, nameof (token));
    if (token is JProperty jproperty)
      token = jproperty.Value;
    return token.Type.ToString();
  }

  private static bool ValidateToken(JToken o, JTokenType[] validTypes, bool nullable)
  {
    if (Array.IndexOf<JTokenType>(validTypes, o.Type) != -1)
      return true;
    if (!nullable)
      return false;
    return o.Type == JTokenType.Null || o.Type == JTokenType.Undefined;
  }

  public static explicit operator bool(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.BooleanTypes, false))
      throw new ArgumentException("Can not convert {0} to Boolean.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value is BigInteger bigInteger ? Convert.ToBoolean((int) bigInteger) : Convert.ToBoolean(o.Value, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public static explicit operator DateTimeOffset(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.DateTimeTypes, false))
      throw new ArgumentException("Can not convert {0} to DateTimeOffset.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is DateTimeOffset dateTimeOffset)
      return dateTimeOffset;
    return o.Value is string input ? DateTimeOffset.Parse(input, (IFormatProvider) CultureInfo.InvariantCulture) : new DateTimeOffset(Convert.ToDateTime(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  [NullableContext(2)]
  public static explicit operator bool?(JToken value)
  {
    if (value == null)
      return new bool?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.BooleanTypes, true))
      throw new ArgumentException("Can not convert {0} to Boolean.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is BigInteger bigInteger)
      return new bool?(Convert.ToBoolean((int) bigInteger));
    return o.Value == null ? new bool?() : new bool?(Convert.ToBoolean(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  public static explicit operator long(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, false))
      throw new ArgumentException("Can not convert {0} to Int64.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value is BigInteger bigInteger ? (long) bigInteger : Convert.ToInt64(o.Value, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  [NullableContext(2)]
  public static explicit operator DateTime?(JToken value)
  {
    if (value == null)
      return new DateTime?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.DateTimeTypes, true))
      throw new ArgumentException("Can not convert {0} to DateTime.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is DateTimeOffset dateTimeOffset)
      return new DateTime?(dateTimeOffset.DateTime);
    return o.Value == null ? new DateTime?() : new DateTime?(Convert.ToDateTime(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  [NullableContext(2)]
  public static explicit operator DateTimeOffset?(JToken value)
  {
    if (value == null)
      return new DateTimeOffset?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.DateTimeTypes, true))
      throw new ArgumentException("Can not convert {0} to DateTimeOffset.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value == null)
      return new DateTimeOffset?();
    if (o.Value is DateTimeOffset dateTimeOffset)
      return new DateTimeOffset?(dateTimeOffset);
    return o.Value is string input ? new DateTimeOffset?(DateTimeOffset.Parse(input, (IFormatProvider) CultureInfo.InvariantCulture)) : new DateTimeOffset?(new DateTimeOffset(Convert.ToDateTime(o.Value, (IFormatProvider) CultureInfo.InvariantCulture)));
  }

  [NullableContext(2)]
  public static explicit operator Decimal?(JToken value)
  {
    if (value == null)
      return new Decimal?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, true))
      throw new ArgumentException("Can not convert {0} to Decimal.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is BigInteger bigInteger)
      return new Decimal?((Decimal) bigInteger);
    return o.Value == null ? new Decimal?() : new Decimal?(Convert.ToDecimal(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  [NullableContext(2)]
  public static explicit operator double?(JToken value)
  {
    if (value == null)
      return new double?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, true))
      throw new ArgumentException("Can not convert {0} to Double.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is BigInteger bigInteger)
      return new double?((double) bigInteger);
    return o.Value == null ? new double?() : new double?(Convert.ToDouble(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  [NullableContext(2)]
  public static explicit operator char?(JToken value)
  {
    if (value == null)
      return new char?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.CharTypes, true))
      throw new ArgumentException("Can not convert {0} to Char.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is BigInteger bigInteger)
      return new char?((char) (ushort) bigInteger);
    return o.Value == null ? new char?() : new char?(Convert.ToChar(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  public static explicit operator int(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, false))
      throw new ArgumentException("Can not convert {0} to Int32.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value is BigInteger bigInteger ? (int) bigInteger : Convert.ToInt32(o.Value, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public static explicit operator short(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, false))
      throw new ArgumentException("Can not convert {0} to Int16.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value is BigInteger bigInteger ? (short) bigInteger : Convert.ToInt16(o.Value, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  [CLSCompliant(false)]
  public static explicit operator ushort(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, false))
      throw new ArgumentException("Can not convert {0} to UInt16.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value is BigInteger bigInteger ? (ushort) bigInteger : Convert.ToUInt16(o.Value, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  [CLSCompliant(false)]
  public static explicit operator char(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.CharTypes, false))
      throw new ArgumentException("Can not convert {0} to Char.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value is BigInteger bigInteger ? (char) (ushort) bigInteger : Convert.ToChar(o.Value, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public static explicit operator byte(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, false))
      throw new ArgumentException("Can not convert {0} to Byte.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value is BigInteger bigInteger ? (byte) bigInteger : Convert.ToByte(o.Value, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  [CLSCompliant(false)]
  public static explicit operator sbyte(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, false))
      throw new ArgumentException("Can not convert {0} to SByte.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value is BigInteger bigInteger ? (sbyte) bigInteger : Convert.ToSByte(o.Value, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  [NullableContext(2)]
  public static explicit operator int?(JToken value)
  {
    if (value == null)
      return new int?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, true))
      throw new ArgumentException("Can not convert {0} to Int32.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is BigInteger bigInteger)
      return new int?((int) bigInteger);
    return o.Value == null ? new int?() : new int?(Convert.ToInt32(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  [NullableContext(2)]
  public static explicit operator short?(JToken value)
  {
    if (value == null)
      return new short?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, true))
      throw new ArgumentException("Can not convert {0} to Int16.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is BigInteger bigInteger)
      return new short?((short) bigInteger);
    return o.Value == null ? new short?() : new short?(Convert.ToInt16(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  [NullableContext(2)]
  [CLSCompliant(false)]
  public static explicit operator ushort?(JToken value)
  {
    if (value == null)
      return new ushort?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, true))
      throw new ArgumentException("Can not convert {0} to UInt16.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is BigInteger bigInteger)
      return new ushort?((ushort) bigInteger);
    return o.Value == null ? new ushort?() : new ushort?(Convert.ToUInt16(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  [NullableContext(2)]
  public static explicit operator byte?(JToken value)
  {
    if (value == null)
      return new byte?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, true))
      throw new ArgumentException("Can not convert {0} to Byte.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is BigInteger bigInteger)
      return new byte?((byte) bigInteger);
    return o.Value == null ? new byte?() : new byte?(Convert.ToByte(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  [NullableContext(2)]
  [CLSCompliant(false)]
  public static explicit operator sbyte?(JToken value)
  {
    if (value == null)
      return new sbyte?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, true))
      throw new ArgumentException("Can not convert {0} to SByte.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is BigInteger bigInteger)
      return new sbyte?((sbyte) bigInteger);
    return o.Value == null ? new sbyte?() : new sbyte?(Convert.ToSByte(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  public static explicit operator DateTime(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.DateTimeTypes, false))
      throw new ArgumentException("Can not convert {0} to DateTime.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value is DateTimeOffset dateTimeOffset ? dateTimeOffset.DateTime : Convert.ToDateTime(o.Value, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  [NullableContext(2)]
  public static explicit operator long?(JToken value)
  {
    if (value == null)
      return new long?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, true))
      throw new ArgumentException("Can not convert {0} to Int64.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is BigInteger bigInteger)
      return new long?((long) bigInteger);
    return o.Value == null ? new long?() : new long?(Convert.ToInt64(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  [NullableContext(2)]
  public static explicit operator float?(JToken value)
  {
    if (value == null)
      return new float?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, true))
      throw new ArgumentException("Can not convert {0} to Single.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is BigInteger bigInteger)
      return new float?((float) bigInteger);
    return o.Value == null ? new float?() : new float?(Convert.ToSingle(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  public static explicit operator Decimal(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, false))
      throw new ArgumentException("Can not convert {0} to Decimal.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value is BigInteger bigInteger ? (Decimal) bigInteger : Convert.ToDecimal(o.Value, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  [NullableContext(2)]
  [CLSCompliant(false)]
  public static explicit operator uint?(JToken value)
  {
    if (value == null)
      return new uint?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, true))
      throw new ArgumentException("Can not convert {0} to UInt32.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is BigInteger bigInteger)
      return new uint?((uint) bigInteger);
    return o.Value == null ? new uint?() : new uint?(Convert.ToUInt32(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  [NullableContext(2)]
  [CLSCompliant(false)]
  public static explicit operator ulong?(JToken value)
  {
    if (value == null)
      return new ulong?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, true))
      throw new ArgumentException("Can not convert {0} to UInt64.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is BigInteger bigInteger)
      return new ulong?((ulong) bigInteger);
    return o.Value == null ? new ulong?() : new ulong?(Convert.ToUInt64(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  public static explicit operator double(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, false))
      throw new ArgumentException("Can not convert {0} to Double.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value is BigInteger bigInteger ? (double) bigInteger : Convert.ToDouble(o.Value, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  public static explicit operator float(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, false))
      throw new ArgumentException("Can not convert {0} to Single.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value is BigInteger bigInteger ? (float) bigInteger : Convert.ToSingle(o.Value, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  [NullableContext(2)]
  public static explicit operator string(JToken value)
  {
    if (value == null)
      return (string) null;
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.StringTypes, true))
      throw new ArgumentException("Can not convert {0} to String.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value == null)
      return (string) null;
    if (o.Value is byte[] inArray)
      return Convert.ToBase64String(inArray);
    return o.Value is BigInteger bigInteger ? bigInteger.ToString((IFormatProvider) CultureInfo.InvariantCulture) : Convert.ToString(o.Value, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  [CLSCompliant(false)]
  public static explicit operator uint(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, false))
      throw new ArgumentException("Can not convert {0} to UInt32.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value is BigInteger bigInteger ? (uint) bigInteger : Convert.ToUInt32(o.Value, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  [CLSCompliant(false)]
  public static explicit operator ulong(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.NumberTypes, false))
      throw new ArgumentException("Can not convert {0} to UInt64.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value is BigInteger bigInteger ? (ulong) bigInteger : Convert.ToUInt64(o.Value, (IFormatProvider) CultureInfo.InvariantCulture);
  }

  [NullableContext(2)]
  public static explicit operator byte[](JToken value)
  {
    if (value == null)
      return (byte[]) null;
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.BytesTypes, false))
      throw new ArgumentException("Can not convert {0} to byte array.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is string)
      return Convert.FromBase64String(Convert.ToString(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
    if (o.Value is BigInteger bigInteger)
      return bigInteger.ToByteArray();
    if (!(o.Value is byte[] numArray))
      throw new ArgumentException("Can not convert {0} to byte array.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return numArray;
  }

  public static explicit operator Guid(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.GuidTypes, false))
      throw new ArgumentException("Can not convert {0} to Guid.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value is byte[] b)
      return new Guid(b);
    return o.Value is Guid guid ? guid : new Guid(Convert.ToString(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  [NullableContext(2)]
  public static explicit operator Guid?(JToken value)
  {
    if (value == null)
      return new Guid?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.GuidTypes, true))
      throw new ArgumentException("Can not convert {0} to Guid.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value == null)
      return new Guid?();
    return o.Value is byte[] b ? new Guid?(new Guid(b)) : new Guid?(!(o.Value is Guid guid) ? new Guid(Convert.ToString(o.Value, (IFormatProvider) CultureInfo.InvariantCulture)) : guid);
  }

  public static explicit operator TimeSpan(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.TimeSpanTypes, false))
      throw new ArgumentException("Can not convert {0} to TimeSpan.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value is TimeSpan timeSpan ? timeSpan : ConvertUtils.ParseTimeSpan(Convert.ToString(o.Value, (IFormatProvider) CultureInfo.InvariantCulture));
  }

  [NullableContext(2)]
  public static explicit operator TimeSpan?(JToken value)
  {
    if (value == null)
      return new TimeSpan?();
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.TimeSpanTypes, true))
      throw new ArgumentException("Can not convert {0} to TimeSpan.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value == null ? new TimeSpan?() : new TimeSpan?(!(o.Value is TimeSpan timeSpan) ? ConvertUtils.ParseTimeSpan(Convert.ToString(o.Value, (IFormatProvider) CultureInfo.InvariantCulture)) : timeSpan);
  }

  [NullableContext(2)]
  public static explicit operator Uri(JToken value)
  {
    if (value == null)
      return (Uri) null;
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.UriTypes, true))
      throw new ArgumentException("Can not convert {0} to Uri.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    if (o.Value == null)
      return (Uri) null;
    return !(o.Value is Uri uri) ? new Uri(Convert.ToString(o.Value, (IFormatProvider) CultureInfo.InvariantCulture)) : uri;
  }

  private static BigInteger ToBigInteger(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    return o != null && JToken.ValidateToken((JToken) o, JToken.BigIntegerTypes, false) ? ConvertUtils.ToBigInteger(o.Value) : throw new ArgumentException("Can not convert {0} to BigInteger.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
  }

  private static BigInteger? ToBigIntegerNullable(JToken value)
  {
    JValue o = JToken.EnsureValue(value);
    if (o == null || !JToken.ValidateToken((JToken) o, JToken.BigIntegerTypes, true))
      throw new ArgumentException("Can not convert {0} to BigInteger.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) JToken.GetType(value)));
    return o.Value == null ? new BigInteger?() : new BigInteger?(ConvertUtils.ToBigInteger(o.Value));
  }

  public static implicit operator JToken(bool value) => (JToken) new JValue(value);

  public static implicit operator JToken(DateTimeOffset value) => (JToken) new JValue(value);

  public static implicit operator JToken(byte value) => (JToken) new JValue((long) value);

  public static implicit operator JToken(byte? value) => (JToken) new JValue((object) value);

  [CLSCompliant(false)]
  public static implicit operator JToken(sbyte value) => (JToken) new JValue((long) value);

  [CLSCompliant(false)]
  public static implicit operator JToken(sbyte? value) => (JToken) new JValue((object) value);

  public static implicit operator JToken(bool? value) => (JToken) new JValue((object) value);

  public static implicit operator JToken(long value) => (JToken) new JValue(value);

  public static implicit operator JToken(DateTime? value) => (JToken) new JValue((object) value);

  public static implicit operator JToken(DateTimeOffset? value)
  {
    return (JToken) new JValue((object) value);
  }

  public static implicit operator JToken(Decimal? value) => (JToken) new JValue((object) value);

  public static implicit operator JToken(double? value) => (JToken) new JValue((object) value);

  [CLSCompliant(false)]
  public static implicit operator JToken(short value) => (JToken) new JValue((long) value);

  [CLSCompliant(false)]
  public static implicit operator JToken(ushort value) => (JToken) new JValue((long) value);

  public static implicit operator JToken(int value) => (JToken) new JValue((long) value);

  public static implicit operator JToken(int? value) => (JToken) new JValue((object) value);

  public static implicit operator JToken(DateTime value) => (JToken) new JValue(value);

  public static implicit operator JToken(long? value) => (JToken) new JValue((object) value);

  public static implicit operator JToken(float? value) => (JToken) new JValue((object) value);

  public static implicit operator JToken(Decimal value) => (JToken) new JValue(value);

  [CLSCompliant(false)]
  public static implicit operator JToken(short? value) => (JToken) new JValue((object) value);

  [CLSCompliant(false)]
  public static implicit operator JToken(ushort? value) => (JToken) new JValue((object) value);

  [CLSCompliant(false)]
  public static implicit operator JToken(uint? value) => (JToken) new JValue((object) value);

  [CLSCompliant(false)]
  public static implicit operator JToken(ulong? value) => (JToken) new JValue((object) value);

  public static implicit operator JToken(double value) => (JToken) new JValue(value);

  public static implicit operator JToken(float value) => (JToken) new JValue(value);

  public static implicit operator JToken([Nullable(2)] string value) => (JToken) new JValue(value);

  [CLSCompliant(false)]
  public static implicit operator JToken(uint value) => (JToken) new JValue((long) value);

  [CLSCompliant(false)]
  public static implicit operator JToken(ulong value) => (JToken) new JValue(value);

  public static implicit operator JToken(byte[] value) => (JToken) new JValue((object) value);

  public static implicit operator JToken([Nullable(2)] Uri value) => (JToken) new JValue(value);

  public static implicit operator JToken(TimeSpan value) => (JToken) new JValue(value);

  public static implicit operator JToken(TimeSpan? value) => (JToken) new JValue((object) value);

  public static implicit operator JToken(Guid value) => (JToken) new JValue(value);

  public static implicit operator JToken(Guid? value) => (JToken) new JValue((object) value);

  IEnumerator IEnumerable.GetEnumerator()
  {
    return (IEnumerator) ((IEnumerable<JToken>) this).GetEnumerator();
  }

  IEnumerator<JToken> IEnumerable<JToken>.GetEnumerator() => this.Children().GetEnumerator();

  internal abstract int GetDeepHashCode();

  IJEnumerable<JToken> IJEnumerable<JToken>.this[object key] => (IJEnumerable<JToken>) this[key];

  public JsonReader CreateReader() => (JsonReader) new JTokenReader(this);

  internal static JToken FromObjectInternal(object o, JsonSerializer jsonSerializer)
  {
    ValidationUtils.ArgumentNotNull(o, nameof (o));
    ValidationUtils.ArgumentNotNull((object) jsonSerializer, nameof (jsonSerializer));
    using (JTokenWriter jtokenWriter = new JTokenWriter())
    {
      jsonSerializer.Serialize((JsonWriter) jtokenWriter, o);
      return jtokenWriter.Token;
    }
  }

  public static JToken FromObject(object o)
  {
    return JToken.FromObjectInternal(o, JsonSerializer.CreateDefault());
  }

  public static JToken FromObject(object o, JsonSerializer jsonSerializer)
  {
    return JToken.FromObjectInternal(o, jsonSerializer);
  }

  [NullableContext(2)]
  public T ToObject<T>() => (T) this.ToObject(typeof (T));

  [return: Nullable(2)]
  public object ToObject(System.Type objectType)
  {
    if (JsonConvert.DefaultSettings == null)
    {
      bool isEnum;
      PrimitiveTypeCode typeCode = ConvertUtils.GetTypeCode(objectType, out isEnum);
      if (isEnum)
      {
        if (this.Type == JTokenType.String)
        {
          try
          {
            return this.ToObject(objectType, JsonSerializer.CreateDefault());
          }
          catch (Exception ex)
          {
            throw new ArgumentException("Could not convert '{0}' to {1}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) (string) this, (object) (objectType.IsEnum() ? (MemberInfo) objectType : (MemberInfo) Nullable.GetUnderlyingType(objectType)).Name), ex);
          }
        }
        else if (this.Type == JTokenType.Integer)
          return Enum.ToObject(objectType.IsEnum() ? objectType : Nullable.GetUnderlyingType(objectType), ((JValue) this).Value);
      }
      switch (typeCode)
      {
        case PrimitiveTypeCode.Char:
          return (object) (char) this;
        case PrimitiveTypeCode.CharNullable:
          return (object) (char?) this;
        case PrimitiveTypeCode.Boolean:
          return (object) (bool) this;
        case PrimitiveTypeCode.BooleanNullable:
          return (object) (bool?) this;
        case PrimitiveTypeCode.SByte:
          return (object) (sbyte) this;
        case PrimitiveTypeCode.SByteNullable:
          return (object) (sbyte?) this;
        case PrimitiveTypeCode.Int16:
          return (object) (short) this;
        case PrimitiveTypeCode.Int16Nullable:
          return (object) (short?) this;
        case PrimitiveTypeCode.UInt16:
          return (object) (ushort) this;
        case PrimitiveTypeCode.UInt16Nullable:
          return (object) (ushort?) this;
        case PrimitiveTypeCode.Int32:
          return (object) (int) this;
        case PrimitiveTypeCode.Int32Nullable:
          return (object) (int?) this;
        case PrimitiveTypeCode.Byte:
          return (object) (byte) this;
        case PrimitiveTypeCode.ByteNullable:
          return (object) (byte?) this;
        case PrimitiveTypeCode.UInt32:
          return (object) (uint) this;
        case PrimitiveTypeCode.UInt32Nullable:
          return (object) (uint?) this;
        case PrimitiveTypeCode.Int64:
          return (object) (long) this;
        case PrimitiveTypeCode.Int64Nullable:
          return (object) (long?) this;
        case PrimitiveTypeCode.UInt64:
          return (object) (ulong) this;
        case PrimitiveTypeCode.UInt64Nullable:
          return (object) (ulong?) this;
        case PrimitiveTypeCode.Single:
          return (object) (float) this;
        case PrimitiveTypeCode.SingleNullable:
          return (object) (float?) this;
        case PrimitiveTypeCode.Double:
          return (object) (double) this;
        case PrimitiveTypeCode.DoubleNullable:
          return (object) (double?) this;
        case PrimitiveTypeCode.DateTime:
          return (object) (DateTime) this;
        case PrimitiveTypeCode.DateTimeNullable:
          return (object) (DateTime?) this;
        case PrimitiveTypeCode.DateTimeOffset:
          return (object) (DateTimeOffset) this;
        case PrimitiveTypeCode.DateTimeOffsetNullable:
          return (object) (DateTimeOffset?) this;
        case PrimitiveTypeCode.Decimal:
          return (object) (Decimal) this;
        case PrimitiveTypeCode.DecimalNullable:
          return (object) (Decimal?) this;
        case PrimitiveTypeCode.Guid:
          return (object) (Guid) this;
        case PrimitiveTypeCode.GuidNullable:
          return (object) (Guid?) this;
        case PrimitiveTypeCode.TimeSpan:
          return (object) (TimeSpan) this;
        case PrimitiveTypeCode.TimeSpanNullable:
          return (object) (TimeSpan?) this;
        case PrimitiveTypeCode.BigInteger:
          return (object) JToken.ToBigInteger(this);
        case PrimitiveTypeCode.BigIntegerNullable:
          return (object) JToken.ToBigIntegerNullable(this);
        case PrimitiveTypeCode.Uri:
          return (object) (Uri) this;
        case PrimitiveTypeCode.String:
          return (object) (string) this;
      }
    }
    return this.ToObject(objectType, JsonSerializer.CreateDefault());
  }

  [NullableContext(2)]
  public T ToObject<T>([Nullable(1)] JsonSerializer jsonSerializer)
  {
    return (T) this.ToObject(typeof (T), jsonSerializer);
  }

  [NullableContext(2)]
  public object ToObject(System.Type objectType, [Nullable(1)] JsonSerializer jsonSerializer)
  {
    ValidationUtils.ArgumentNotNull((object) jsonSerializer, nameof (jsonSerializer));
    using (JTokenReader reader = new JTokenReader(this))
    {
      if (jsonSerializer is JsonSerializerProxy jsonSerializerProxy)
        jsonSerializerProxy._serializer.SetupReader((JsonReader) reader, out CultureInfo _, out DateTimeZoneHandling? _, out DateParseHandling? _, out FloatParseHandling? _, out int? _, out string _);
      return jsonSerializer.Deserialize((JsonReader) reader, objectType);
    }
  }

  public static JToken ReadFrom(JsonReader reader)
  {
    return JToken.ReadFrom(reader, (JsonLoadSettings) null);
  }

  public static JToken ReadFrom(JsonReader reader, [Nullable(2)] JsonLoadSettings settings)
  {
    ValidationUtils.ArgumentNotNull((object) reader, nameof (reader));
    if (!(reader.TokenType != JsonToken.None ? reader.TokenType != JsonToken.Comment || settings == null || settings.CommentHandling != CommentHandling.Ignore || reader.ReadAndMoveToContent() : (settings == null || settings.CommentHandling != CommentHandling.Ignore ? reader.Read() : reader.ReadAndMoveToContent())))
      throw JsonReaderException.Create(reader, "Error reading JToken from JsonReader.");
    IJsonLineInfo lineInfo = reader as IJsonLineInfo;
    switch (reader.TokenType)
    {
      case JsonToken.StartObject:
        return (JToken) JObject.Load(reader, settings);
      case JsonToken.StartArray:
        return (JToken) JArray.Load(reader, settings);
      case JsonToken.StartConstructor:
        return (JToken) JConstructor.Load(reader, settings);
      case JsonToken.PropertyName:
        return (JToken) JProperty.Load(reader, settings);
      case JsonToken.Comment:
        JValue comment = JValue.CreateComment(reader.Value.ToString());
        comment.SetLineInfo(lineInfo, settings);
        return (JToken) comment;
      case JsonToken.Integer:
      case JsonToken.Float:
      case JsonToken.String:
      case JsonToken.Boolean:
      case JsonToken.Date:
      case JsonToken.Bytes:
        JValue jvalue1 = new JValue(reader.Value);
        jvalue1.SetLineInfo(lineInfo, settings);
        return (JToken) jvalue1;
      case JsonToken.Null:
        JValue jvalue2 = JValue.CreateNull();
        jvalue2.SetLineInfo(lineInfo, settings);
        return (JToken) jvalue2;
      case JsonToken.Undefined:
        JValue undefined = JValue.CreateUndefined();
        undefined.SetLineInfo(lineInfo, settings);
        return (JToken) undefined;
      default:
        throw JsonReaderException.Create(reader, "Error reading JToken from JsonReader. Unexpected token: {0}".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) reader.TokenType));
    }
  }

  public static JToken Parse(string json) => JToken.Parse(json, (JsonLoadSettings) null);

  public static JToken Parse(string json, [Nullable(2)] JsonLoadSettings settings)
  {
    using (JsonReader reader = (JsonReader) new JsonTextReader((TextReader) new StringReader(json)))
    {
      JToken jtoken = JToken.Load(reader, settings);
      do
        ;
      while (reader.Read());
      return jtoken;
    }
  }

  public static JToken Load(JsonReader reader, [Nullable(2)] JsonLoadSettings settings)
  {
    return JToken.ReadFrom(reader, settings);
  }

  public static JToken Load(JsonReader reader) => JToken.Load(reader, (JsonLoadSettings) null);

  [NullableContext(2)]
  internal void SetLineInfo(IJsonLineInfo lineInfo, JsonLoadSettings settings)
  {
    if (settings != null && settings.LineInfoHandling != LineInfoHandling.Load || lineInfo == null || !lineInfo.HasLineInfo())
      return;
    this.SetLineInfo(lineInfo.LineNumber, lineInfo.LinePosition);
  }

  internal void SetLineInfo(int lineNumber, int linePosition)
  {
    this.AddAnnotation((object) new JToken.LineInfoAnnotation(lineNumber, linePosition));
  }

  bool IJsonLineInfo.HasLineInfo() => this.Annotation<JToken.LineInfoAnnotation>() != null;

  int IJsonLineInfo.LineNumber
  {
    get
    {
      JToken.LineInfoAnnotation lineInfoAnnotation = this.Annotation<JToken.LineInfoAnnotation>();
      return lineInfoAnnotation != null ? lineInfoAnnotation.LineNumber : 0;
    }
  }

  int IJsonLineInfo.LinePosition
  {
    get
    {
      JToken.LineInfoAnnotation lineInfoAnnotation = this.Annotation<JToken.LineInfoAnnotation>();
      return lineInfoAnnotation != null ? lineInfoAnnotation.LinePosition : 0;
    }
  }

  [return: Nullable(2)]
  public JToken SelectToken(string path) => this.SelectToken(path, (JsonSelectSettings) null);

  [return: Nullable(2)]
  public JToken SelectToken(string path, bool errorWhenNoMatch)
  {
    JsonSelectSettings jsonSelectSettings;
    if (!errorWhenNoMatch)
    {
      jsonSelectSettings = (JsonSelectSettings) null;
    }
    else
    {
      jsonSelectSettings = new JsonSelectSettings();
      jsonSelectSettings.ErrorWhenNoMatch = true;
    }
    JsonSelectSettings settings = jsonSelectSettings;
    return this.SelectToken(path, settings);
  }

  [NullableContext(2)]
  public JToken SelectToken([Nullable(1)] string path, JsonSelectSettings settings)
  {
    JPath jpath = new JPath(path);
    JToken jtoken1 = (JToken) null;
    JsonSelectSettings settings1 = settings;
    foreach (JToken jtoken2 in jpath.Evaluate(this, this, settings1))
      jtoken1 = jtoken1 == null ? jtoken2 : throw new JsonException("Path returned multiple tokens.");
    return jtoken1;
  }

  public IEnumerable<JToken> SelectTokens(string path)
  {
    return this.SelectTokens(path, (JsonSelectSettings) null);
  }

  public IEnumerable<JToken> SelectTokens(string path, bool errorWhenNoMatch)
  {
    JsonSelectSettings jsonSelectSettings;
    if (!errorWhenNoMatch)
    {
      jsonSelectSettings = (JsonSelectSettings) null;
    }
    else
    {
      jsonSelectSettings = new JsonSelectSettings();
      jsonSelectSettings.ErrorWhenNoMatch = true;
    }
    JsonSelectSettings settings = jsonSelectSettings;
    return this.SelectTokens(path, settings);
  }

  public IEnumerable<JToken> SelectTokens(string path, [Nullable(2)] JsonSelectSettings settings)
  {
    return new JPath(path).Evaluate(this, this, settings);
  }

  protected virtual DynamicMetaObject GetMetaObject(Expression parameter)
  {
    return (DynamicMetaObject) new DynamicProxyMetaObject<JToken>(parameter, this, new DynamicProxy<JToken>());
  }

  DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
  {
    return this.GetMetaObject(parameter);
  }

  object ICloneable.Clone() => (object) this.DeepClone();

  public JToken DeepClone() => this.CloneToken((JsonCloneSettings) null);

  public JToken DeepClone(JsonCloneSettings settings) => this.CloneToken(settings);

  public void AddAnnotation(object annotation)
  {
    if (annotation == null)
      throw new ArgumentNullException(nameof (annotation));
    if (this._annotations == null)
    {
      object obj;
      if (!(annotation is object[]))
      {
        obj = annotation;
      }
      else
      {
        obj = (object) new object[1];
        obj[0] = annotation;
      }
      this._annotations = obj;
    }
    else if (!(this._annotations is object[] annotations))
    {
      this._annotations = (object) new object[2]
      {
        this._annotations,
        annotation
      };
    }
    else
    {
      int index = 0;
      while (index < annotations.Length && annotations[index] != null)
        ++index;
      if (index == annotations.Length)
      {
        Array.Resize<object>(ref annotations, index * 2);
        this._annotations = (object) annotations;
      }
      annotations[index] = annotation;
    }
  }

  [return: Nullable(2)]
  public T Annotation<T>() where T : class
  {
    if (this._annotations != null)
    {
      if (!(this._annotations is object[] annotations))
        return this._annotations as T;
      for (int index = 0; index < annotations.Length; ++index)
      {
        object obj1 = annotations[index];
        if (obj1 != null)
        {
          if (obj1 is T obj2)
            return obj2;
        }
        else
          break;
      }
    }
    return default (T);
  }

  [return: Nullable(2)]
  public object Annotation(System.Type type)
  {
    if (type == (System.Type) null)
      throw new ArgumentNullException(nameof (type));
    if (this._annotations != null)
    {
      if (!(this._annotations is object[] annotations))
      {
        if (type.IsInstanceOfType(this._annotations))
          return this._annotations;
      }
      else
      {
        for (int index = 0; index < annotations.Length; ++index)
        {
          object o = annotations[index];
          if (o != null)
          {
            if (type.IsInstanceOfType(o))
              return o;
          }
          else
            break;
        }
      }
    }
    return (object) null;
  }

  public IEnumerable<T> Annotations<T>() where T : class
  {
    if (this._annotations != null)
    {
      if (this._annotations is object[] annotations2)
      {
        for (int i = 0; i < annotations2.Length; ++i)
        {
          object obj1 = annotations2[i];
          if (obj1 == null)
            break;
          if (!(obj1 is T obj2))
            continue;
          yield return obj2;
        }
      }
      else if (this._annotations is T annotations1)
        yield return annotations1;
    }
  }

  public IEnumerable<object> Annotations(System.Type type)
  {
    if (type == (System.Type) null)
      throw new ArgumentNullException(nameof (type));
    if (this._annotations != null)
    {
      if (this._annotations is object[] annotations)
      {
        for (int i = 0; i < annotations.Length; ++i)
        {
          object o = annotations[i];
          if (o == null)
            break;
          if (!type.IsInstanceOfType(o))
            continue;
          yield return o;
        }
      }
      else if (type.IsInstanceOfType(this._annotations))
        yield return this._annotations;
    }
  }

  public void RemoveAnnotations<T>() where T : class
  {
    if (this._annotations == null)
      return;
    if (!(this._annotations is object[] annotations))
    {
      if (!(this._annotations is T))
        return;
      this._annotations = (object) null;
    }
    else
    {
      int index = 0;
      int num = 0;
      for (; index < annotations.Length; ++index)
      {
        object obj = annotations[index];
        if (obj != null)
        {
          if (!(obj is T))
            annotations[num++] = obj;
        }
        else
          break;
      }
      if (num != 0)
      {
        while (num < index)
          annotations[num++] = (object) null;
      }
      else
        this._annotations = (object) null;
    }
  }

  public void RemoveAnnotations(System.Type type)
  {
    if (type == (System.Type) null)
      throw new ArgumentNullException(nameof (type));
    if (this._annotations == null)
      return;
    if (!(this._annotations is object[] annotations))
    {
      if (!type.IsInstanceOfType(this._annotations))
        return;
      this._annotations = (object) null;
    }
    else
    {
      int index = 0;
      int num = 0;
      for (; index < annotations.Length; ++index)
      {
        object o = annotations[index];
        if (o != null)
        {
          if (!type.IsInstanceOfType(o))
            annotations[num++] = o;
        }
        else
          break;
      }
      if (num != 0)
      {
        while (num < index)
          annotations[num++] = (object) null;
      }
      else
        this._annotations = (object) null;
    }
  }

  internal void CopyAnnotations(JToken target, JToken source)
  {
    if (source._annotations is object[] annotations)
      target._annotations = (object) ((IEnumerable<object>) annotations).ToArray<object>();
    else
      target._annotations = source._annotations;
  }

  [NullableContext(0)]
  private class LineInfoAnnotation
  {
    internal readonly int LineNumber;
    internal readonly int LinePosition;

    public LineInfoAnnotation(int lineNumber, int linePosition)
    {
      this.LineNumber = lineNumber;
      this.LinePosition = linePosition;
    }
  }
}
