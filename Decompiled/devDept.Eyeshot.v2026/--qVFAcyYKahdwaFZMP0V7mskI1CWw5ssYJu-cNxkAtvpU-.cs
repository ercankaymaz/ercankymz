using System;
using System.Collections.Generic;
using System.Reflection;

internal static class _0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D
{
	private static class _0023_003DziDLVpbY_003D
	{
		public static readonly Dictionary<Type, int> _0023_003DziDLVpbY_003D = new Dictionary<Type, int>
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

	public static readonly Type _0023_003DziDLVpbY_003D;

	public static readonly Type _0023_003Dz5rQzobg_003D;

	public static readonly Type _0023_003DzAvn2b38_003D;

	public static readonly Type _0023_003DzR58imxw_003D;

	public static readonly Type _0023_003DzmQTFaQA_003D;

	public static readonly Assembly _0023_003DzWYPqg2E_003D;

	static _0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D()
	{
		_0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DziDLVpbY_003D = typeof(object);
		_0023_003Dz5rQzobg_003D = typeof(ValueType);
		_0023_003DzAvn2b38_003D = typeof(Enum);
		_0023_003DzR58imxw_003D = typeof(Nullable<>);
		_0023_003DzmQTFaQA_003D = typeof(void);
		_0023_003DzWYPqg2E_003D = typeof(_0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D).Assembly;
	}

	public static bool _0023_003DzoIht4H3MBiobPh2HDJb056MsRfdA_00245XIgOj_0024Oec_003D(Type _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D.IsGenericType && !_0023_003DziDLVpbY_003D.IsGenericTypeDefinition)
		{
			return _0023_003DziDLVpbY_003D.GetGenericTypeDefinition() == _0023_003DzR58imxw_003D;
		}
		return false;
	}

	public static Type _0023_003DzabUOCE0NIf0_0024ueqjA0946qu_00246SbMH3py0xa3ro4LUTfS(Type _0023_003DziDLVpbY_003D)
	{
		while (_0023_003DziDLVpbY_003D.HasElementType)
		{
			_0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D.GetElementType();
		}
		return _0023_003DziDLVpbY_003D;
	}

	public static Type _0023_003Dz4RFZlwTSA_0024OBIxXad_0024ubOycm4BxX(Type _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D.HasElementType && !_0023_003DziDLVpbY_003D.IsArray)
		{
			_0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D.GetElementType();
		}
		return _0023_003DziDLVpbY_003D;
	}

	public static Stack<_0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D> _0023_003DzKvttB_0024Sc4ndvnJM2qX_0024DIAk_003D(Type _0023_003DziDLVpbY_003D)
	{
		Stack<_0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D> stack = new Stack<_0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D>();
		Type type = _0023_003DziDLVpbY_003D;
		while (true)
		{
			if (type.IsArray)
			{
				stack.Push(new _0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D
				{
					_0023_003DziDLVpbY_003D = 2,
					_0023_003Dz5rQzobg_003D = type.GetArrayRank()
				});
			}
			else if (type.IsByRef)
			{
				stack.Push(new _0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D
				{
					_0023_003DziDLVpbY_003D = 1
				});
			}
			else
			{
				if (!type.IsPointer)
				{
					break;
				}
				stack.Push(new _0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D
				{
					_0023_003DziDLVpbY_003D = 0
				});
			}
			type = type.GetElementType();
		}
		return stack;
	}

	public static Stack<_0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D> _0023_003Dz79D8nBufbe8GV8EWfy8sOOY_003D(string _0023_003DziDLVpbY_003D)
	{
		string text = _0023_003DziDLVpbY_003D;
		Stack<_0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D> stack = new Stack<_0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D>();
		while (true)
		{
			if (text.EndsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909451), StringComparison.Ordinal))
			{
				stack.Push(new _0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D
				{
					_0023_003DziDLVpbY_003D = 1
				});
				text = text.Substring(0, text.Length - 1);
				continue;
			}
			if (text.EndsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909683), StringComparison.Ordinal))
			{
				stack.Push(new _0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D
				{
					_0023_003DziDLVpbY_003D = 0
				});
				text = text.Substring(0, text.Length - 1);
				continue;
			}
			if (text.EndsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909691), StringComparison.Ordinal))
			{
				stack.Push(new _0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D
				{
					_0023_003DziDLVpbY_003D = 2,
					_0023_003Dz5rQzobg_003D = 1
				});
				text = text.Substring(0, text.Length - 2);
				continue;
			}
			if (!text.EndsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909670), StringComparison.Ordinal))
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
					throw new InvalidOperationException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909677));
				}
			}
			if (num2 < 0)
			{
				throw new InvalidOperationException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909659));
			}
			text = text.Substring(0, num2);
			stack.Push(new _0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D
			{
				_0023_003DziDLVpbY_003D = 2,
				_0023_003Dz5rQzobg_003D = num
			});
		}
		return stack;
	}

	public static Type _0023_003Dzz0Px9L6Or2TxYjXunF_0024Eikk_003D(Type _0023_003DziDLVpbY_003D, Stack<_0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D> _0023_003Dz5rQzobg_003D)
	{
		Type type = _0023_003DziDLVpbY_003D;
		while (_0023_003Dz5rQzobg_003D.Count > 0)
		{
			_0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D _0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D2 = _0023_003Dz5rQzobg_003D.Pop();
			switch (_0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D2._0023_003DziDLVpbY_003D)
			{
			case 2:
				type = ((_0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D2._0023_003Dz5rQzobg_003D != 1) ? type.MakeArrayType(_0023_003DqVB5DK809DPsZyVxh_00242OBCQzU2H5VPKqAzLdKF8DihzY_003D2._0023_003Dz5rQzobg_003D) : type.MakeArrayType());
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

	public static int _0023_003DzqW57JawRt_LNV_0024LQSBneJ5oiIMB_0024Bi6b_0024Q_003D_003D(Type _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DqVFAcyYKahdwaFZMP0V7mskI1CWw5ssYJu_0024cNxkAtvpU_003D._0023_003DziDLVpbY_003D._0023_003DziDLVpbY_003D.TryGetValue(_0023_003DziDLVpbY_003D, out var value))
		{
			return value;
		}
		if (_0023_003DziDLVpbY_003D.IsArray)
		{
			return 9;
		}
		if (_0023_003DziDLVpbY_003D.IsValueType)
		{
			if (_0023_003DziDLVpbY_003D.IsSubclassOf(_0023_003DzAvn2b38_003D))
			{
				return 19;
			}
			if (_0023_003DzoIht4H3MBiobPh2HDJb056MsRfdA_00245XIgOj_0024Oec_003D(_0023_003DziDLVpbY_003D))
			{
				return 5;
			}
			return 25;
		}
		return 4;
	}
}
