// Decompiled with JetBrains decompiler
// Type: Newtonsoft.Json.Linq.Extensions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Newtonsoft.Json.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices.Newtonsoft.Json;

#nullable disable
namespace Newtonsoft.Json.Linq;

[NullableContext(1)]
[Nullable(0)]
public static class Extensions
{
  public static IJEnumerable<JToken> Ancestors<[Nullable(0)] T>(this IEnumerable<T> source) where T : JToken
  {
    ValidationUtils.ArgumentNotNull((object) source, nameof (source));
    return source.SelectMany<T, JToken>((Func<T, IEnumerable<JToken>>) ([NullableContext(0)] (j) => j.Ancestors())).AsJEnumerable();
  }

  public static IJEnumerable<JToken> AncestorsAndSelf<[Nullable(0)] T>(this IEnumerable<T> source) where T : JToken
  {
    ValidationUtils.ArgumentNotNull((object) source, nameof (source));
    return source.SelectMany<T, JToken>((Func<T, IEnumerable<JToken>>) ([NullableContext(0)] (j) => j.AncestorsAndSelf())).AsJEnumerable();
  }

  public static IJEnumerable<JToken> Descendants<[Nullable(0)] T>(this IEnumerable<T> source) where T : JContainer
  {
    ValidationUtils.ArgumentNotNull((object) source, nameof (source));
    return source.SelectMany<T, JToken>((Func<T, IEnumerable<JToken>>) ([NullableContext(0)] (j) => j.Descendants())).AsJEnumerable();
  }

  public static IJEnumerable<JToken> DescendantsAndSelf<[Nullable(0)] T>(this IEnumerable<T> source) where T : JContainer
  {
    ValidationUtils.ArgumentNotNull((object) source, nameof (source));
    return source.SelectMany<T, JToken>((Func<T, IEnumerable<JToken>>) ([NullableContext(0)] (j) => j.DescendantsAndSelf())).AsJEnumerable();
  }

  public static IJEnumerable<JProperty> Properties(this IEnumerable<JObject> source)
  {
    ValidationUtils.ArgumentNotNull((object) source, nameof (source));
    return source.SelectMany<JObject, JProperty>((Func<JObject, IEnumerable<JProperty>>) ([NullableContext(0)] (d) => d.Properties())).AsJEnumerable<JProperty>();
  }

  public static IJEnumerable<JToken> Values(this IEnumerable<JToken> source, [Nullable(2)] object key)
  {
    return source.Values<JToken, JToken>(key).AsJEnumerable();
  }

  public static IJEnumerable<JToken> Values(this IEnumerable<JToken> source)
  {
    return source.Values((object) null);
  }

  [return: Nullable(new byte[] {1, 2})]
  public static IEnumerable<U> Values<[Nullable(2)] U>(this IEnumerable<JToken> source, object key)
  {
    return source.Values<JToken, U>(key);
  }

  [return: Nullable(new byte[] {1, 2})]
  public static IEnumerable<U> Values<[Nullable(2)] U>(this IEnumerable<JToken> source)
  {
    return source.Values<JToken, U>((object) null);
  }

  [NullableContext(2)]
  public static U Value<U>([Nullable(1)] this IEnumerable<JToken> value)
  {
    return value.Value<JToken, U>();
  }

  [return: Nullable(2)]
  public static U Value<[Nullable(0)] T, [Nullable(2)] U>(this IEnumerable<T> value) where T : JToken
  {
    ValidationUtils.ArgumentNotNull((object) value, nameof (value));
    return value is JToken token ? token.Convert<JToken, U>() : throw new ArgumentException("Source value must be a JToken.");
  }

  [return: Nullable(new byte[] {1, 2})]
  internal static IEnumerable<U> Values<[Nullable(0)] T, [Nullable(2)] U>(
    this IEnumerable<T> source,
    [Nullable(2)] object key)
    where T : JToken
  {
    ValidationUtils.ArgumentNotNull((object) source, nameof (source));
    if (key == null)
    {
      foreach (T obj in source)
      {
        if (!(obj is JValue token))
        {
          foreach (JToken child in obj.Children())
            yield return child.Convert<JToken, U>();
        }
        else
          yield return token.Convert<JValue, U>();
      }
    }
    else
    {
      foreach (T obj in source)
      {
        JToken token = obj[key];
        if (token != null)
          yield return token.Convert<JToken, U>();
      }
    }
  }

  public static IJEnumerable<JToken> Children<[Nullable(0)] T>(this IEnumerable<T> source) where T : JToken
  {
    return source.Children<T, JToken>().AsJEnumerable();
  }

  [return: Nullable(new byte[] {1, 2})]
  public static IEnumerable<U> Children<[Nullable(0)] T, [Nullable(2)] U>(this IEnumerable<T> source) where T : JToken
  {
    ValidationUtils.ArgumentNotNull((object) source, nameof (source));
    return source.SelectMany<T, JToken>((Func<T, IEnumerable<JToken>>) ([NullableContext(0)] (c) => (IEnumerable<JToken>) c.Children())).Convert<JToken, U>();
  }

  [return: Nullable(new byte[] {1, 2})]
  internal static IEnumerable<U> Convert<[Nullable(0)] T, [Nullable(2)] U>(
    this IEnumerable<T> source)
    where T : JToken
  {
    ValidationUtils.ArgumentNotNull((object) source, nameof (source));
    foreach (T token in source)
      yield return token.Convert<JToken, U>();
  }

  [NullableContext(2)]
  internal static U Convert<[Nullable(0)] T, U>([Nullable(1)] this T token) where T : JToken
  {
    if ((object) token == null)
      return default (U);
    switch (token)
    {
      case U u2 when typeof (U) != typeof (IComparable) && typeof (U) != typeof (IFormattable):
        return u2;
      case JValue jvalue:
        if (jvalue.Value is U u1)
          return u1;
        Type type = typeof (U);
        if (ReflectionUtils.IsNullableType(type))
        {
          if (jvalue.Value == null)
            return default (U);
          type = Nullable.GetUnderlyingType(type);
        }
        return (U) System.Convert.ChangeType(jvalue.Value, type, (IFormatProvider) CultureInfo.InvariantCulture);
      default:
        throw new InvalidCastException("Cannot cast {0} to {1}.".FormatWith((IFormatProvider) CultureInfo.InvariantCulture, (object) token.GetType(), (object) typeof (T)));
    }
  }

  public static IJEnumerable<JToken> AsJEnumerable(this IEnumerable<JToken> source)
  {
    return source.AsJEnumerable<JToken>();
  }

  public static IJEnumerable<T> AsJEnumerable<[Nullable(0)] T>(this IEnumerable<T> source) where T : JToken
  {
    if (source == null)
      return (IJEnumerable<T>) null;
    return source is IJEnumerable<T> jenumerable ? jenumerable : (IJEnumerable<T>) new JEnumerable<T>(source);
  }
}
