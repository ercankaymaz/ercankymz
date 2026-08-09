using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Linq;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
public static class Extensions
{
	public static IJEnumerable<JToken> Ancestors<[Newtonsoft_002EJson_002ENullable(0)] T>(this IEnumerable<T> source) where T : JToken
	{
		ValidationUtils.ArgumentNotNull(source, "source");
		return source.SelectMany([Newtonsoft_002EJson_002ENullableContext(0)] (T j) => j.Ancestors()).AsJEnumerable();
	}

	public static IJEnumerable<JToken> AncestorsAndSelf<[Newtonsoft_002EJson_002ENullable(0)] T>(this IEnumerable<T> source) where T : JToken
	{
		ValidationUtils.ArgumentNotNull(source, "source");
		return source.SelectMany([Newtonsoft_002EJson_002ENullableContext(0)] (T j) => j.AncestorsAndSelf()).AsJEnumerable();
	}

	public static IJEnumerable<JToken> Descendants<[Newtonsoft_002EJson_002ENullable(0)] T>(this IEnumerable<T> source) where T : JContainer
	{
		ValidationUtils.ArgumentNotNull(source, "source");
		return source.SelectMany([Newtonsoft_002EJson_002ENullableContext(0)] (T j) => j.Descendants()).AsJEnumerable();
	}

	public static IJEnumerable<JToken> DescendantsAndSelf<[Newtonsoft_002EJson_002ENullable(0)] T>(this IEnumerable<T> source) where T : JContainer
	{
		ValidationUtils.ArgumentNotNull(source, "source");
		return source.SelectMany([Newtonsoft_002EJson_002ENullableContext(0)] (T j) => j.DescendantsAndSelf()).AsJEnumerable();
	}

	public static IJEnumerable<JProperty> Properties(this IEnumerable<JObject> source)
	{
		ValidationUtils.ArgumentNotNull(source, "source");
		return source.SelectMany([Newtonsoft_002EJson_002ENullableContext(0)] (JObject d) => d.Properties()).AsJEnumerable();
	}

	public static IJEnumerable<JToken> Values(this IEnumerable<JToken> source, [Newtonsoft_002EJson_002ENullable(2)] object key)
	{
		return source.Values<JToken, JToken>(key).AsJEnumerable();
	}

	public static IJEnumerable<JToken> Values(this IEnumerable<JToken> source)
	{
		return source.Values(null);
	}

	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 2 })]
	public static IEnumerable<U> Values<[Newtonsoft_002EJson_002ENullable(2)] U>(this IEnumerable<JToken> source, object key)
	{
		return source.Values<JToken, U>(key);
	}

	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 2 })]
	public static IEnumerable<U> Values<[Newtonsoft_002EJson_002ENullable(2)] U>(this IEnumerable<JToken> source)
	{
		return source.Values<JToken, U>(null);
	}

	[Newtonsoft_002EJson_002ENullableContext(2)]
	public static U Value<U>([Newtonsoft_002EJson_002ENullable(1)] this IEnumerable<JToken> value)
	{
		return value.Value<JToken, U>();
	}

	[return: Newtonsoft_002EJson_002ENullable(2)]
	public static U Value<[Newtonsoft_002EJson_002ENullable(0)] T, [Newtonsoft_002EJson_002ENullable(2)] U>(this IEnumerable<T> value) where T : JToken
	{
		ValidationUtils.ArgumentNotNull(value, "value");
		return ((value as JToken) ?? throw new ArgumentException("Source value must be a JToken.")).Convert<JToken, U>();
	}

	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 2 })]
	internal static IEnumerable<U> Values<[Newtonsoft_002EJson_002ENullable(0)] T, [Newtonsoft_002EJson_002ENullable(2)] U>(this IEnumerable<T> source, [Newtonsoft_002EJson_002ENullable(2)] object key) where T : JToken
	{
		ValidationUtils.ArgumentNotNull(source, "source");
		if (key == null)
		{
			foreach (T item in source)
			{
				if (item is JValue token)
				{
					yield return token.Convert<JValue, U>();
					continue;
				}
				foreach (JToken item2 in item.Children())
				{
					yield return item2.Convert<JToken, U>();
				}
			}
			yield break;
		}
		foreach (T item3 in source)
		{
			JToken jToken = item3[key];
			if (jToken != null)
			{
				yield return jToken.Convert<JToken, U>();
			}
		}
	}

	public static IJEnumerable<JToken> Children<[Newtonsoft_002EJson_002ENullable(0)] T>(this IEnumerable<T> source) where T : JToken
	{
		return source.Children<T, JToken>().AsJEnumerable();
	}

	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 2 })]
	public static IEnumerable<U> Children<[Newtonsoft_002EJson_002ENullable(0)] T, [Newtonsoft_002EJson_002ENullable(2)] U>(this IEnumerable<T> source) where T : JToken
	{
		ValidationUtils.ArgumentNotNull(source, "source");
		return source.SelectMany([Newtonsoft_002EJson_002ENullableContext(0)] (T c) => c.Children()).Convert<JToken, U>();
	}

	[return: Newtonsoft_002EJson_002ENullable(new byte[] { 1, 2 })]
	internal static IEnumerable<U> Convert<[Newtonsoft_002EJson_002ENullable(0)] T, [Newtonsoft_002EJson_002ENullable(2)] U>(this IEnumerable<T> source) where T : JToken
	{
		ValidationUtils.ArgumentNotNull(source, "source");
		foreach (T item in source)
		{
			yield return item.Convert<JToken, U>();
		}
	}

	[Newtonsoft_002EJson_002ENullableContext(2)]
	internal static U Convert<[Newtonsoft_002EJson_002ENullable(0)] T, U>([Newtonsoft_002EJson_002ENullable(1)] this T token) where T : JToken
	{
		if (token == null)
		{
			return default(U);
		}
		if (token is U result && typeof(U) != typeof(IComparable) && typeof(U) != typeof(IFormattable))
		{
			return result;
		}
		if (!(token is JValue { Value: var value } jValue))
		{
			throw new InvalidCastException("Cannot cast {0} to {1}.".FormatWith(CultureInfo.InvariantCulture, token.GetType(), typeof(T)));
		}
		if (value is U)
		{
			return (U)value;
		}
		Type type = typeof(U);
		if (ReflectionUtils.IsNullableType(type))
		{
			if (jValue.Value == null)
			{
				return default(U);
			}
			type = Nullable.GetUnderlyingType(type);
		}
		return (U)System.Convert.ChangeType(jValue.Value, type, CultureInfo.InvariantCulture);
	}

	public static IJEnumerable<JToken> AsJEnumerable(this IEnumerable<JToken> source)
	{
		return source.AsJEnumerable<JToken>();
	}

	public static IJEnumerable<T> AsJEnumerable<[Newtonsoft_002EJson_002ENullable(0)] T>(this IEnumerable<T> source) where T : JToken
	{
		if (source == null)
		{
			return null;
		}
		if (source is IJEnumerable<T> result)
		{
			return result;
		}
		return new JEnumerable<T>(source);
	}
}
