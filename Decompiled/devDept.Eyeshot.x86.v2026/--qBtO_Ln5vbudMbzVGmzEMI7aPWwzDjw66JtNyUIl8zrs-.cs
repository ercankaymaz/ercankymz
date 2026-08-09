using System;
using System.Collections.Generic;
using System.Reflection;

internal static class _0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D
{
	private static class _0023_003Dzq80RbjQ_003D
	{
		public static readonly Dictionary<Type, int> _0023_003Dzq80RbjQ_003D = new Dictionary<Type, int>
		{
			{
				typeof(object),
				7
			},
			{
				typeof(byte),
				12
			},
			{
				typeof(sbyte),
				17
			},
			{
				typeof(short),
				26
			},
			{
				typeof(int),
				1
			},
			{
				typeof(long),
				13
			},
			{
				typeof(ushort),
				16
			},
			{
				typeof(uint),
				3
			},
			{
				typeof(ulong),
				14
			},
			{
				typeof(IntPtr),
				0
			},
			{
				typeof(UIntPtr),
				20
			},
			{
				typeof(float),
				22
			},
			{
				typeof(double),
				8
			},
			{
				typeof(bool),
				15
			},
			{
				typeof(char),
				6
			},
			{
				typeof(string),
				10
			}
		};
	}

	public static readonly Type _0023_003Dzq80RbjQ_003D;

	public static readonly Type _0023_003DzZzVr6_0024U_003D;

	public static readonly Type _0023_003Dz7hRN5Rg_003D;

	public static readonly Type _0023_003DzcbLoSrg_003D;

	public static readonly Type _0023_003DzqMLoHoQ_003D;

	public static readonly Assembly _0023_003DzuwE9t4w_003D;

	static _0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D()
	{
		_0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003Dzq80RbjQ_003D = typeof(object);
		_0023_003DzZzVr6_0024U_003D = typeof(ValueType);
		_0023_003Dz7hRN5Rg_003D = typeof(Enum);
		_0023_003DzcbLoSrg_003D = typeof(Nullable<>);
		_0023_003DzqMLoHoQ_003D = typeof(void);
		_0023_003DzuwE9t4w_003D = typeof(_0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D).Assembly;
	}

	public static bool _0023_003DzYWGcjirBLOR1G3YpoMmbNyJEx1WWfXOuZmf7utk_003D(Type _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D.IsGenericType && !_0023_003Dzq80RbjQ_003D.IsGenericTypeDefinition)
		{
			return _0023_003Dzq80RbjQ_003D.GetGenericTypeDefinition() == _0023_003DzcbLoSrg_003D;
		}
		return false;
	}

	public static Type _0023_003DzFkSVnloSTgfB_TuxgOff5OemKRrwlKQflVohFlutimzk(Type _0023_003Dzq80RbjQ_003D)
	{
		while (_0023_003Dzq80RbjQ_003D.HasElementType)
		{
			_0023_003Dzq80RbjQ_003D = _0023_003Dzq80RbjQ_003D.GetElementType();
		}
		return _0023_003Dzq80RbjQ_003D;
	}

	public static Type _0023_003Dz5m3WmfE4_0024lDVC2gOqxYhKVJiZIXs(Type _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D.HasElementType && !_0023_003Dzq80RbjQ_003D.IsArray)
		{
			_0023_003Dzq80RbjQ_003D = _0023_003Dzq80RbjQ_003D.GetElementType();
		}
		return _0023_003Dzq80RbjQ_003D;
	}

	public static Stack<_0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D> _0023_003DzYl_0024a_yWqakc8AwZs01mSdGU_003D(Type _0023_003Dzq80RbjQ_003D)
	{
		Stack<_0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D> stack = new Stack<_0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D>();
		Type type = _0023_003Dzq80RbjQ_003D;
		while (true)
		{
			if (type.IsArray)
			{
				stack.Push(new _0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D
				{
					_0023_003Dzq80RbjQ_003D = 2,
					_0023_003DzZzVr6_0024U_003D = type.GetArrayRank()
				});
			}
			else if (type.IsByRef)
			{
				stack.Push(new _0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D
				{
					_0023_003Dzq80RbjQ_003D = 1
				});
			}
			else
			{
				if (!type.IsPointer)
				{
					break;
				}
				stack.Push(new _0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D
				{
					_0023_003Dzq80RbjQ_003D = 0
				});
			}
			type = type.GetElementType();
		}
		return stack;
	}

	public static Stack<_0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D> _0023_003DzsYo6xG8FqKmjeKuOtLTaTPw_003D(string _0023_003Dzq80RbjQ_003D)
	{
		string text = _0023_003Dzq80RbjQ_003D;
		Stack<_0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D> stack = new Stack<_0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D>();
		while (true)
		{
			if (text.EndsWith(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527742), StringComparison.Ordinal))
			{
				stack.Push(new _0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D
				{
					_0023_003Dzq80RbjQ_003D = 1
				});
				text = text.Substring(0, text.Length - 1);
				continue;
			}
			if (text.EndsWith(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527734), StringComparison.Ordinal))
			{
				stack.Push(new _0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D
				{
					_0023_003Dzq80RbjQ_003D = 0
				});
				text = text.Substring(0, text.Length - 1);
				continue;
			}
			if (text.EndsWith(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527694), StringComparison.Ordinal))
			{
				stack.Push(new _0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D
				{
					_0023_003Dzq80RbjQ_003D = 2,
					_0023_003DzZzVr6_0024U_003D = 1
				});
				text = text.Substring(0, text.Length - 2);
				continue;
			}
			if (!text.EndsWith(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527687), StringComparison.Ordinal))
			{
				break;
			}
			int num = 1;
			int num2 = -1;
			for (int num3 = text.Length - 2; num3 >= 0; num3--)
			{
				switch (text[num3])
				{
				case ',':
					num++;
					break;
				case '[':
					num2 = num3;
					num3 = -1;
					break;
				default:
					throw new InvalidOperationException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527708));
				}
			}
			if (num2 < 0)
			{
				throw new InvalidOperationException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527790));
			}
			text = text.Substring(0, num2);
			stack.Push(new _0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D
			{
				_0023_003Dzq80RbjQ_003D = 2,
				_0023_003DzZzVr6_0024U_003D = num
			});
		}
		return stack;
	}

	public static Type _0023_003DzGHlwp_0024Ivr07TXIwyhYJfDKc_003D(Type _0023_003Dzq80RbjQ_003D, Stack<_0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D> _0023_003DzZzVr6_0024U_003D)
	{
		Type type = _0023_003Dzq80RbjQ_003D;
		while (_0023_003DzZzVr6_0024U_003D.Count > 0)
		{
			_0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D _0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D2 = _0023_003DzZzVr6_0024U_003D.Pop();
			switch (_0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D2._0023_003Dzq80RbjQ_003D)
			{
			case 2:
				type = ((_0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D2._0023_003DzZzVr6_0024U_003D != 1) ? type.MakeArrayType(_0023_003Dqdjy057pni6pqXXBRENfBqhMi91Cb7XdMDRU_0024_DfYT4Q_003D2._0023_003DzZzVr6_0024U_003D) : type.MakeArrayType());
				break;
			case 1:
				type = type.MakeByRefType();
				break;
			case 0:
				type = type.MakePointerType();
				break;
			}
		}
		return type;
	}

	public static int _0023_003DzVYadrUYBIE2Ul169R0VQKnHLammK7Z8dnA_003D_003D(Type _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003DqBtO_Ln5vbudMbzVGmzEMI7aPWwzDjw66JtNyUIl8zrs_003D._0023_003Dzq80RbjQ_003D._0023_003Dzq80RbjQ_003D.TryGetValue(_0023_003Dzq80RbjQ_003D, out var value))
		{
			return value;
		}
		if (_0023_003Dzq80RbjQ_003D.IsArray)
		{
			return 9;
		}
		if (_0023_003Dzq80RbjQ_003D.IsValueType)
		{
			if (_0023_003Dzq80RbjQ_003D.IsSubclassOf(_0023_003Dz7hRN5Rg_003D))
			{
				return 19;
			}
			if (_0023_003DzYWGcjirBLOR1G3YpoMmbNyJEx1WWfXOuZmf7utk_003D(_0023_003Dzq80RbjQ_003D))
			{
				return 5;
			}
			return 25;
		}
		return 4;
	}
}
