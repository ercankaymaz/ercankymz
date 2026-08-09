using System;
using System.IO;
using System.Text;

internal sealed class _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8
{
	private enum _0023_003Dz3nCm8N8_003D
	{

	}

	public enum _0023_003DznqdCgf91E_Pg
	{

	}

	private _0023_003Dz3nCm8N8_003D _0023_003DznXXM9vk_003D;

	private MemoryStream _0023_003DzdLqTRfo_003D;

	private BinaryReader _0023_003DzkKz7OWA_003D;

	private BinaryWriter _0023_003DzDdJAEBo_003D;

	internal _0023_003DzGbvkIgC5zcwBXCSsRl_2yY0GoNwL _0023_003DzB8hyw2kh48e4;

	private _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8()
	{
		_0023_003DzdLqTRfo_003D = new MemoryStream();
		_0023_003DzkKz7OWA_003D = new BinaryReader(_0023_003DzdLqTRfo_003D);
		_0023_003DzDdJAEBo_003D = new BinaryWriter(_0023_003DzdLqTRfo_003D);
	}

	~_0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8()
	{
		_0023_003DzkKz7OWA_003D.Close();
		_0023_003DzDdJAEBo_003D.Close();
		_0023_003DzdLqTRfo_003D.Close();
		_0023_003DzdLqTRfo_003D.Dispose();
	}

	public static _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003Dz4WBFhMXFKCAdtFOMag_003D_003D(int _0023_003Dzu8sgotQ_003D, _0023_003DzGbvkIgC5zcwBXCSsRl_2yY0GoNwL _0023_003DzB8hyw2kh48e4)
	{
		return new _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8
		{
			_0023_003DzdLqTRfo_003D = 
			{
				Capacity = _0023_003Dzu8sgotQ_003D
			},
			_0023_003DzB8hyw2kh48e4 = _0023_003DzB8hyw2kh48e4,
			_0023_003DznXXM9vk_003D = (_0023_003Dz3nCm8N8_003D)1
		};
	}

	public static _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003Dzv_ixFmv5CMNJFtL4XQ_003D_003D(int _0023_003Dzu8sgotQ_003D)
	{
		return _0023_003Dz4WBFhMXFKCAdtFOMag_003D_003D(_0023_003Dzu8sgotQ_003D, null);
	}

	public int _0023_003Dzu8sgotQ_003D()
	{
		return _0023_003DzdLqTRfo_003D.Capacity;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003Dzbu8BV15Qqzan()
	{
		_0023_003DznXXM9vk_003D = (_0023_003Dz3nCm8N8_003D)0;
		_0023_003DzdLqTRfo_003D.SetLength(_0023_003DzdLqTRfo_003D.Position);
		_0023_003DzdLqTRfo_003D.Position = 0L;
		return this;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzttBXI_0024c_003D()
	{
		_0023_003DznXXM9vk_003D = (_0023_003Dz3nCm8N8_003D)1;
		_0023_003DzdLqTRfo_003D.Position = 0L;
		return this;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzKLAQQF0_003D()
	{
		_0023_003DznXXM9vk_003D = (_0023_003Dz3nCm8N8_003D)1;
		MemoryStream destination = new MemoryStream(_0023_003DzdLqTRfo_003D.Capacity);
		_0023_003DzdLqTRfo_003D.CopyTo(destination);
		_0023_003DzdLqTRfo_003D = destination;
		return this;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzoKSLUW1O34Cu()
	{
		_0023_003DzdLqTRfo_003D.Position = 0L;
		return this;
	}

	public long _0023_003DzLMo0v2w_003D()
	{
		if (_0023_003DznXXM9vk_003D == (_0023_003Dz3nCm8N8_003D)1)
		{
			return _0023_003DzdLqTRfo_003D.Capacity;
		}
		return _0023_003DzdLqTRfo_003D.Length;
	}

	public int _0023_003DztUjb52A_003D()
	{
		return (int)_0023_003DzdLqTRfo_003D.Position;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DztUjb52A_003D(long _0023_003DzKDWAZk0_003D)
	{
		_0023_003DzdLqTRfo_003D.Position = _0023_003DzKDWAZk0_003D;
		return this;
	}

	public long _0023_003DzNBFv6Go_003D()
	{
		return _0023_003DzLMo0v2w_003D() - _0023_003DztUjb52A_003D();
	}

	public bool _0023_003DzKFSCkig4kYh9()
	{
		return _0023_003DzNBFv6Go_003D() > 0;
	}

	public int _0023_003DzlDvF6iY_003D()
	{
		return _0023_003DzdLqTRfo_003D.ReadByte();
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzlDvF6iY_003D(byte[] _0023_003DzKOKXzLg_003D, int _0023_003DzfBEBL_o_003D, int _0023_003Dz736ekIs_003D)
	{
		_0023_003DzdLqTRfo_003D.Read(_0023_003DzKOKXzLg_003D, _0023_003DzfBEBL_o_003D, _0023_003Dz736ekIs_003D);
		return this;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003Dz6M79YE0_003D(byte _0023_003Dz1v6oPQk_003D)
	{
		_0023_003DzdLqTRfo_003D.WriteByte(_0023_003Dz1v6oPQk_003D);
		return this;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003Dz6M79YE0_003D(byte[] _0023_003DzqjMrmuo_003D, int _0023_003DzfBEBL_o_003D, int _0023_003Dz736ekIs_003D)
	{
		_0023_003DzdLqTRfo_003D.Write(_0023_003DzqjMrmuo_003D, _0023_003DzfBEBL_o_003D, _0023_003Dz736ekIs_003D);
		return this;
	}

	public _0023_003DznqdCgf91E_Pg _0023_003DzhY366QI_003D()
	{
		if (!BitConverter.IsLittleEndian)
		{
			return (_0023_003DznqdCgf91E_Pg)0;
		}
		return (_0023_003DznqdCgf91E_Pg)1;
	}

	public void _0023_003DzhY366QI_003D(_0023_003DznqdCgf91E_Pg _0023_003Dz0IWv3Hdv8W25)
	{
	}

	public bool _0023_003Dza0ku3fI_003D(_0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003Dzl_0024MIsC0_003D)
	{
		if (_0023_003Dzl_0024MIsC0_003D != null && _0023_003DzNBFv6Go_003D() == _0023_003Dzl_0024MIsC0_003D._0023_003DzNBFv6Go_003D())
		{
			long _0023_003DzKDWAZk0_003D = _0023_003DztUjb52A_003D();
			long _0023_003DzKDWAZk0_003D2 = _0023_003Dzl_0024MIsC0_003D._0023_003DztUjb52A_003D();
			bool flag = false;
			while (_0023_003DzdLqTRfo_003D.Position < _0023_003DzdLqTRfo_003D.Length)
			{
				if (_0023_003DzlDvF6iY_003D() != _0023_003Dzl_0024MIsC0_003D._0023_003DzlDvF6iY_003D())
				{
					flag = true;
					break;
				}
			}
			_0023_003DztUjb52A_003D(_0023_003DzKDWAZk0_003D);
			_0023_003Dzl_0024MIsC0_003D._0023_003DztUjb52A_003D(_0023_003DzKDWAZk0_003D2);
			return !flag;
		}
		return false;
	}

	public char _0023_003DzV_0024bPHlY_003D()
	{
		return _0023_003DzkKz7OWA_003D.ReadChar();
	}

	public char _0023_003DzV_0024bPHlY_003D(int _0023_003DzyzK8swU_003D)
	{
		long position = _0023_003DzdLqTRfo_003D.Position;
		_0023_003DzdLqTRfo_003D.Position = _0023_003DzyzK8swU_003D;
		char result = _0023_003DzkKz7OWA_003D.ReadChar();
		_0023_003DzdLqTRfo_003D.Position = position;
		return result;
	}

	public double _0023_003DzPs_0024aDpA_003D()
	{
		return _0023_003DzkKz7OWA_003D.ReadDouble();
	}

	public double _0023_003DzPs_0024aDpA_003D(int _0023_003DzyzK8swU_003D)
	{
		long position = _0023_003DzdLqTRfo_003D.Position;
		_0023_003DzdLqTRfo_003D.Position = _0023_003DzyzK8swU_003D;
		double result = _0023_003DzkKz7OWA_003D.ReadDouble();
		_0023_003DzdLqTRfo_003D.Position = position;
		return result;
	}

	public float _0023_003DzbmlHM9w_003D()
	{
		return _0023_003DzkKz7OWA_003D.ReadSingle();
	}

	public float _0023_003DzbmlHM9w_003D(int _0023_003DzyzK8swU_003D)
	{
		long position = _0023_003DzdLqTRfo_003D.Position;
		_0023_003DzdLqTRfo_003D.Position = _0023_003DzyzK8swU_003D;
		float result = _0023_003DzkKz7OWA_003D.ReadSingle();
		_0023_003DzdLqTRfo_003D.Position = position;
		return result;
	}

	public int _0023_003Dz7_eyi6g_003D()
	{
		return _0023_003DzkKz7OWA_003D.ReadInt32();
	}

	public int _0023_003Dz7_eyi6g_003D(int _0023_003DzyzK8swU_003D)
	{
		long position = _0023_003DzdLqTRfo_003D.Position;
		_0023_003DzdLqTRfo_003D.Position = _0023_003DzyzK8swU_003D;
		int result = _0023_003DzkKz7OWA_003D.ReadInt32();
		_0023_003DzdLqTRfo_003D.Position = position;
		return result;
	}

	public long _0023_003DzIdLD_R8_003D()
	{
		return _0023_003DzkKz7OWA_003D.ReadInt64();
	}

	public long _0023_003DzIdLD_R8_003D(int _0023_003DzyzK8swU_003D)
	{
		long position = _0023_003DzdLqTRfo_003D.Position;
		_0023_003DzdLqTRfo_003D.Position = _0023_003DzyzK8swU_003D;
		long result = _0023_003DzkKz7OWA_003D.ReadInt64();
		_0023_003DzdLqTRfo_003D.Position = position;
		return result;
	}

	public short _0023_003DzAJs8HJI_003D()
	{
		return _0023_003DzkKz7OWA_003D.ReadInt16();
	}

	public short _0023_003DzAJs8HJI_003D(int _0023_003DzyzK8swU_003D)
	{
		long position = _0023_003DzdLqTRfo_003D.Position;
		_0023_003DzdLqTRfo_003D.Position = _0023_003DzyzK8swU_003D;
		short result = _0023_003DzkKz7OWA_003D.ReadInt16();
		_0023_003DzdLqTRfo_003D.Position = position;
		return result;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzbZg2YVSEhCcG(char _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzDdJAEBo_003D.Write(_0023_003DzPzO_0024GUk_003D);
		return this;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzbZg2YVSEhCcG(int _0023_003DzyzK8swU_003D, char _0023_003DzPzO_0024GUk_003D)
	{
		long position = _0023_003DzdLqTRfo_003D.Position;
		_0023_003DzdLqTRfo_003D.Position = _0023_003DzyzK8swU_003D;
		_0023_003DzDdJAEBo_003D.Write(_0023_003DzPzO_0024GUk_003D);
		_0023_003DzdLqTRfo_003D.Position = position;
		return this;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzHOMRRp3_0024a8a7(double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzDdJAEBo_003D.Write(_0023_003DzPzO_0024GUk_003D);
		return this;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzHOMRRp3_0024a8a7(int _0023_003DzyzK8swU_003D, double _0023_003DzPzO_0024GUk_003D)
	{
		long position = _0023_003DzdLqTRfo_003D.Position;
		_0023_003DzdLqTRfo_003D.Position = _0023_003DzyzK8swU_003D;
		_0023_003DzDdJAEBo_003D.Write(_0023_003DzPzO_0024GUk_003D);
		_0023_003DzdLqTRfo_003D.Position = position;
		return this;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzpdFBk6dLIrPz(float _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzDdJAEBo_003D.Write(_0023_003DzPzO_0024GUk_003D);
		return this;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzpdFBk6dLIrPz(int _0023_003DzyzK8swU_003D, float _0023_003DzPzO_0024GUk_003D)
	{
		long position = _0023_003DzdLqTRfo_003D.Position;
		_0023_003DzdLqTRfo_003D.Position = _0023_003DzyzK8swU_003D;
		_0023_003DzDdJAEBo_003D.Write(_0023_003DzPzO_0024GUk_003D);
		_0023_003DzdLqTRfo_003D.Position = position;
		return this;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzO8wmKTZ4i0OL(int _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzDdJAEBo_003D.Write(_0023_003DzPzO_0024GUk_003D);
		return this;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzO8wmKTZ4i0OL(int _0023_003DzyzK8swU_003D, int _0023_003DzPzO_0024GUk_003D)
	{
		long position = _0023_003DzdLqTRfo_003D.Position;
		_0023_003DzdLqTRfo_003D.Position = _0023_003DzyzK8swU_003D;
		_0023_003DzDdJAEBo_003D.Write(_0023_003DzPzO_0024GUk_003D);
		_0023_003DzdLqTRfo_003D.Position = position;
		return this;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003Dzk012MiFaQPQd(long _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzDdJAEBo_003D.Write(_0023_003DzPzO_0024GUk_003D);
		return this;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003Dzk012MiFaQPQd(int _0023_003DzyzK8swU_003D, long _0023_003DzPzO_0024GUk_003D)
	{
		long position = _0023_003DzdLqTRfo_003D.Position;
		_0023_003DzdLqTRfo_003D.Position = _0023_003DzyzK8swU_003D;
		_0023_003DzDdJAEBo_003D.Write(_0023_003DzPzO_0024GUk_003D);
		_0023_003DzdLqTRfo_003D.Position = position;
		return this;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzAODCCVxlUZpO(short _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzDdJAEBo_003D.Write(_0023_003DzPzO_0024GUk_003D);
		return this;
	}

	public _0023_003Dz4BThAeMUVNi5lkbCFOKIerpsUKH8 _0023_003DzAODCCVxlUZpO(int _0023_003DzyzK8swU_003D, short _0023_003DzPzO_0024GUk_003D)
	{
		long position = _0023_003DzdLqTRfo_003D.Position;
		_0023_003DzdLqTRfo_003D.Position = _0023_003DzyzK8swU_003D;
		_0023_003DzDdJAEBo_003D.Write(_0023_003DzPzO_0024GUk_003D);
		_0023_003DzdLqTRfo_003D.Position = position;
		return this;
	}

	public void _0023_003DzhRp3x7D8g_0024M_0024(int _0023_003Dzx_sdUG0Jm7Dk)
	{
	}

	public string _0023_003Dz1S9qPyLTyc1J(int _0023_003Dz9XWvB3JVM64h)
	{
		StringBuilder stringBuilder = new StringBuilder(_0023_003Dz9XWvB3JVM64h);
		for (int i = 0; i < _0023_003Dz9XWvB3JVM64h; i++)
		{
			stringBuilder.Append((char)_0023_003Dzm7mcmeeaNf5j());
		}
		return stringBuilder.ToString();
	}

	public string _0023_003DzJKBOCvaR5suw()
	{
		int num = _0023_003Dzmf8mDHW8MUJO();
		if (num == 0)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < num; i++)
		{
			stringBuilder.Append((char)_0023_003DzYeSlt_NVa_00248u());
		}
		return stringBuilder.ToString();
	}

	public string _0023_003DzjNIKzdM_003D()
	{
		int num = _0023_003Dzmf8mDHW8MUJO();
		if (num == 0)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < num; i++)
		{
			stringBuilder.Append((char)_0023_003Dzm7mcmeeaNf5j());
		}
		return stringBuilder.ToString();
	}

	public double _0023_003DzVPJIKJ3x_fCs()
	{
		_0023_003DzhRp3x7D8g_0024M_0024(8);
		return _0023_003DzPs_0024aDpA_003D();
	}

	public float _0023_003DzWTmlNWQ2_0024V27()
	{
		_0023_003DzhRp3x7D8g_0024M_0024(4);
		return _0023_003DzbmlHM9w_003D();
	}

	public float[] _0023_003DznF5eMJkvQgzr()
	{
		return new float[3]
		{
			_0023_003DzWTmlNWQ2_0024V27(),
			_0023_003DzWTmlNWQ2_0024V27(),
			_0023_003DzWTmlNWQ2_0024V27()
		};
	}

	public float[] _0023_003DzYL06Io_00241dZC_0024jZIK7g_003D_003D()
	{
		return new float[3]
		{
			_0023_003DzWTmlNWQ2_0024V27(),
			_0023_003DzWTmlNWQ2_0024V27(),
			_0023_003DzWTmlNWQ2_0024V27()
		};
	}

	public double[] _0023_003DzltJSfd8Y4kmPQKCIGg_003D_003D()
	{
		return new double[3]
		{
			_0023_003DzVPJIKJ3x_fCs(),
			_0023_003DzVPJIKJ3x_fCs(),
			_0023_003DzVPJIKJ3x_fCs()
		};
	}

	public float[] _0023_003Dzjwzm9Hsz4xeB()
	{
		return new float[4]
		{
			_0023_003DzWTmlNWQ2_0024V27(),
			_0023_003DzWTmlNWQ2_0024V27(),
			_0023_003DzWTmlNWQ2_0024V27(),
			_0023_003DzWTmlNWQ2_0024V27()
		};
	}

	public long _0023_003DzTi9_YMTEMhV9()
	{
		_0023_003DzhRp3x7D8g_0024M_0024(8);
		return _0023_003DzIdLD_R8_003D();
	}

	public int _0023_003Dzmf8mDHW8MUJO()
	{
		_0023_003DzhRp3x7D8g_0024M_0024(4);
		return _0023_003Dz7_eyi6g_003D();
	}

	public int _0023_003DzYeSlt_NVa_00248u()
	{
		_0023_003DzhRp3x7D8g_0024M_0024(2);
		return _0023_003DzAJs8HJI_003D();
	}

	public long _0023_003DzJhN07D9knaSP()
	{
		return _0023_003DzTi9_YMTEMhV9() & -1;
	}

	public long _0023_003DzvI_0024VUB8xYlas()
	{
		return _0023_003Dzmf8mDHW8MUJO() & 0xFFFFFFFFu;
	}

	public int _0023_003DzIcyyqsXtZDUy()
	{
		return _0023_003DzYeSlt_NVa_00248u() & 0xFFFF;
	}

	public int _0023_003Dzm7mcmeeaNf5j()
	{
		_0023_003DzhRp3x7D8g_0024M_0024(1);
		return (short)(_0023_003DzlDvF6iY_003D() & 0xFF);
	}

	public byte[] _0023_003Dzx_sdUG0Jm7Dk(int _0023_003DzQVP2utw6IqDE)
	{
		_0023_003DzhRp3x7D8g_0024M_0024(_0023_003DzQVP2utw6IqDE);
		byte[] array = new byte[_0023_003DzQVP2utw6IqDE];
		_0023_003DzlDvF6iY_003D(array, 0, array.Length);
		return array;
	}

	public int[] _0023_003DzRah59N4uqSSmPo0n3g_003D_003D()
	{
		int[] array = new int[_0023_003Dzmf8mDHW8MUJO()];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _0023_003Dzmf8mDHW8MUJO();
		}
		return array;
	}

	public long[] _0023_003Dz0eyz_0024dIebwj1azpCsA_003D_003D()
	{
		long[] array = new long[_0023_003Dzmf8mDHW8MUJO()];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _0023_003DzvI_0024VUB8xYlas();
		}
		return array;
	}

	public float[] _0023_003DzxIhhjl0uxFjna7KNOg_003D_003D()
	{
		float[] array = new float[_0023_003Dzmf8mDHW8MUJO()];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _0023_003DzWTmlNWQ2_0024V27();
		}
		return array;
	}

	public float[][] _0023_003DzIFfY7Ua7DO1aVKT8ew_003D_003D()
	{
		return new float[2][]
		{
			new float[3]
			{
				_0023_003DzWTmlNWQ2_0024V27(),
				_0023_003DzWTmlNWQ2_0024V27(),
				_0023_003DzWTmlNWQ2_0024V27()
			},
			new float[3]
			{
				_0023_003DzWTmlNWQ2_0024V27(),
				_0023_003DzWTmlNWQ2_0024V27(),
				_0023_003DzWTmlNWQ2_0024V27()
			}
		};
	}

	public int[] _0023_003DzaZsQpU6MMhwg()
	{
		return new int[2]
		{
			_0023_003Dzmf8mDHW8MUJO(),
			_0023_003Dzmf8mDHW8MUJO()
		};
	}
}
