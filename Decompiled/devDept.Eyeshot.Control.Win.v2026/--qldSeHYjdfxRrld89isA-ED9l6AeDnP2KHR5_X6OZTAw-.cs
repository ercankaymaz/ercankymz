using System;
using System.Collections.Generic;
using System.Reflection;

internal static class _0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D
{
	private static class _0023_003DzjYYAPCA_003D
	{
		public static readonly Dictionary<Type, int> _0023_003DzjYYAPCA_003D = new Dictionary<Type, int>
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

	public static readonly Type _0023_003DzjYYAPCA_003D;

	public static readonly Type _0023_003DzVC9FBdo_003D;

	public static readonly Type _0023_003DzwBouG0w_003D;

	public static readonly Type _0023_003Dzf4Pqh9s_003D;

	public static readonly Type _0023_003DzTFNDoh0_003D;

	public static readonly Assembly _0023_003DzraVZG9g_003D;

	static _0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D()
	{
		_0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzjYYAPCA_003D = typeof(object);
		_0023_003DzVC9FBdo_003D = typeof(ValueType);
		_0023_003DzwBouG0w_003D = typeof(Enum);
		_0023_003Dzf4Pqh9s_003D = typeof(Nullable<>);
		_0023_003DzTFNDoh0_003D = typeof(void);
		_0023_003DzraVZG9g_003D = typeof(_0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D).Assembly;
	}

	public static bool _0023_003DzJOxLVMUq09gKMmJjDqh_BOpFRd5D2IDnyaMQ_PU_003D(Type _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D.IsGenericType && !_0023_003DzjYYAPCA_003D.IsGenericTypeDefinition)
		{
			return _0023_003DzjYYAPCA_003D.GetGenericTypeDefinition() == _0023_003Dzf4Pqh9s_003D;
		}
		return false;
	}

	public static Type _0023_003DzoC9bH1eMVZamY4yQnHoYg9cMo4hJmwbUvuc_0024TkZjHFud(Type _0023_003DzjYYAPCA_003D)
	{
		while (_0023_003DzjYYAPCA_003D.HasElementType)
		{
			_0023_003DzjYYAPCA_003D = _0023_003DzjYYAPCA_003D.GetElementType();
		}
		return _0023_003DzjYYAPCA_003D;
	}

	public static Type _0023_003DzM5GjsgMDoYpz28dMdyKB_0024JZsy1eP(Type _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D.HasElementType && !_0023_003DzjYYAPCA_003D.IsArray)
		{
			_0023_003DzjYYAPCA_003D = _0023_003DzjYYAPCA_003D.GetElementType();
		}
		return _0023_003DzjYYAPCA_003D;
	}

	public static Stack<_0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D> _0023_003DzBfue6AoofRZkIGtKnie10y0_003D(Type _0023_003DzjYYAPCA_003D)
	{
		Stack<_0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D> stack = new Stack<_0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D>();
		Type type = _0023_003DzjYYAPCA_003D;
		while (true)
		{
			if (type.IsArray)
			{
				stack.Push(new _0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D
				{
					_0023_003DzjYYAPCA_003D = 2,
					_0023_003DzVC9FBdo_003D = type.GetArrayRank()
				});
			}
			else if (type.IsByRef)
			{
				stack.Push(new _0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D
				{
					_0023_003DzjYYAPCA_003D = 1
				});
			}
			else
			{
				if (!type.IsPointer)
				{
					break;
				}
				stack.Push(new _0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D
				{
					_0023_003DzjYYAPCA_003D = 0
				});
			}
			type = type.GetElementType();
		}
		return stack;
	}

	public static Stack<_0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D> _0023_003Dz9zdkf9pmHD2DO4EmDsXAKIw_003D(string _0023_003DzjYYAPCA_003D)
	{
		string text = _0023_003DzjYYAPCA_003D;
		Stack<_0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D> stack = new Stack<_0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D>();
		while (true)
		{
			if (text.EndsWith(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619679), StringComparison.Ordinal))
			{
				stack.Push(new _0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D
				{
					_0023_003DzjYYAPCA_003D = 1
				});
				text = text.Substring(0, text.Length - 1);
				continue;
			}
			if (text.EndsWith(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619671), StringComparison.Ordinal))
			{
				stack.Push(new _0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D
				{
					_0023_003DzjYYAPCA_003D = 0
				});
				text = text.Substring(0, text.Length - 1);
				continue;
			}
			if (text.EndsWith(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619695), StringComparison.Ordinal))
			{
				stack.Push(new _0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D
				{
					_0023_003DzjYYAPCA_003D = 2,
					_0023_003DzVC9FBdo_003D = 1
				});
				text = text.Substring(0, text.Length - 2);
				continue;
			}
			if (!text.EndsWith(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619686), StringComparison.Ordinal))
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
					throw new InvalidOperationException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619709));
				}
			}
			if (num2 < 0)
			{
				throw new InvalidOperationException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619727));
			}
			text = text.Substring(0, num2);
			stack.Push(new _0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D
			{
				_0023_003DzjYYAPCA_003D = 2,
				_0023_003DzVC9FBdo_003D = num
			});
		}
		return stack;
	}

	public static Type _0023_003DzdudXII0n97BwllsbIrch9F0_003D(Type _0023_003DzjYYAPCA_003D, Stack<_0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D> _0023_003DzVC9FBdo_003D)
	{
		Type type = _0023_003DzjYYAPCA_003D;
		while (_0023_003DzVC9FBdo_003D.Count > 0)
		{
			_0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D _0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D2 = _0023_003DzVC9FBdo_003D.Pop();
			switch (_0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D2._0023_003DzjYYAPCA_003D)
			{
			case 2:
				type = ((_0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D2._0023_003DzVC9FBdo_003D != 1) ? type.MakeArrayType(_0023_003DqCYtpYjw7PR14CpnIyTweytiftqymnXVOhcq41SKthms_003D2._0023_003DzVC9FBdo_003D) : type.MakeArrayType());
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

	public static int _0023_003Dzontt5W6vgr4zFSUfGVKnvI8uhcup3T8_0024xQ_003D_003D(Type _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DqldSeHYjdfxRrld89isA_0024ED9l6AeDnP2KHR5_X6OZTAw_003D._0023_003DzjYYAPCA_003D._0023_003DzjYYAPCA_003D.TryGetValue(_0023_003DzjYYAPCA_003D, out var value))
		{
			return value;
		}
		if (_0023_003DzjYYAPCA_003D.IsArray)
		{
			return 9;
		}
		if (_0023_003DzjYYAPCA_003D.IsValueType)
		{
			if (_0023_003DzjYYAPCA_003D.IsSubclassOf(_0023_003DzwBouG0w_003D))
			{
				return 19;
			}
			if (_0023_003DzJOxLVMUq09gKMmJjDqh_BOpFRd5D2IDnyaMQ_PU_003D(_0023_003DzjYYAPCA_003D))
			{
				return 5;
			}
			return 25;
		}
		return 4;
	}
}
