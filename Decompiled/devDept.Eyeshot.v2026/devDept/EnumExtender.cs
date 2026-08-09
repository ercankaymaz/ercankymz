using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace devDept;

public static class EnumExtender
{
	private sealed class _0023_003Dze0y44x9SivFgGDwa5cD4Nbg_003D<_0023_003DzWWgGxds_003D> where _0023_003DzWWgGxds_003D : Enum
	{
		public string _0023_003Dz6zIREZQ_003D;

		internal bool _0023_003DzdA_0024xcRlieLJRfOvpbOulrrk_003D(KeyValuePair<Enum, string> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Value.Equals(_0023_003Dz6zIREZQ_003D);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly Dictionary<Type, Dictionary<Enum, string>> _0023_003DzkHkEV2U_003D = new Dictionary<Type, Dictionary<Enum, string>>();

	private static string _0023_003DzrFPEcoOyKrrR(Enum _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzkHkEV2U_003D.TryGetValue(_0023_003DzPzO_0024GUk_003D.GetType(), out var value))
		{
			string value2 = null;
			if (value.TryGetValue(_0023_003DzPzO_0024GUk_003D, out value2))
			{
				return value2;
			}
			return Enum.GetName(_0023_003DzPzO_0024GUk_003D.GetType(), _0023_003DzPzO_0024GUk_003D);
		}
		return Enum.GetName(_0023_003DzPzO_0024GUk_003D.GetType(), _0023_003DzPzO_0024GUk_003D);
	}

	public static void SetDisplayName(this Enum value, string name)
	{
		if (!_0023_003DzkHkEV2U_003D.TryGetValue(value.GetType(), out var value2))
		{
			value2 = new Dictionary<Enum, string>();
			_0023_003DzkHkEV2U_003D.Add(value.GetType(), value2);
		}
		if (value2.ContainsKey(value))
		{
			value2[value] = name;
		}
		else
		{
			value2.Add(value, name);
		}
	}

	public static string GetDisplayName(this Enum value)
	{
		Type type = value.GetType();
		if (Attribute.GetCustomAttribute(type, typeof(FlagsAttribute)) == null)
		{
			return _0023_003DzrFPEcoOyKrrR(value);
		}
		Array values = Enum.GetValues(type);
		StringBuilder stringBuilder = new StringBuilder();
		foreach (Enum item in values)
		{
			if (!object.Equals(item, Enum.ToObject(type, 0)) && value.HasFlag(item))
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108));
				}
				stringBuilder.Append(_0023_003DzrFPEcoOyKrrR(item));
			}
		}
		stringBuilder.Insert(0, '[');
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}

	public static T GetValueFromDisplayName<T>(string displayName) where T : Enum
	{
		_0023_003Dze0y44x9SivFgGDwa5cD4Nbg_003D<T> CS_0024_003C_003E8__locals3 = new _0023_003Dze0y44x9SivFgGDwa5cD4Nbg_003D<T>();
		CS_0024_003C_003E8__locals3._0023_003Dz6zIREZQ_003D = displayName;
		Type typeFromHandle = typeof(T);
		if (_0023_003DzkHkEV2U_003D.TryGetValue(typeFromHandle, out var value) && value.ContainsValue(CS_0024_003C_003E8__locals3._0023_003Dz6zIREZQ_003D))
		{
			return (T)value.First((KeyValuePair<Enum, string> _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D.Value.Equals(CS_0024_003C_003E8__locals3._0023_003Dz6zIREZQ_003D)).Key;
		}
		throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951363));
	}
}
