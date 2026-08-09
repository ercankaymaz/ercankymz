using System;
using System.IO;
using System.Runtime.CompilerServices;

internal sealed class _0023_003DzGCUfYBe5eV21ayjvcXbRSVQwEeZu<_0023_003DzRJ_TQW0_003D> : _0023_003Dz7EU3jafgrAIj0FjRJ8wRX1Q_003D where _0023_003DzRJ_TQW0_003D : struct
{
	protected bool _0023_003DzGQmoODbMR1Vi;

	protected long _0023_003Dz2FQYtOs_003D;

	protected long _0023_003Dz5LaEuoE_003D;

	protected double _0023_003DzNwF0_ko_003D;

	protected double _0023_003DzxCjI_9c_003D;

	protected uint _0023_003DzzKg7bM4bJl9X;

	protected object _0023_003Dz2DwFFA9M7ImW;

	protected static readonly ulong _0023_003DzJSe_0024oFcDMvn6 = (ulong)Unsafe.SizeOf<_0023_003DzRJ_TQW0_003D>() * 8uL;

	protected static string _0023_003DzrGMyqfJ35C20;

	public _0023_003DzGCUfYBe5eV21ayjvcXbRSVQwEeZu(bool _0023_003DzZV3ZiKOGb1YJ, uint _0023_003Dz1jrm9N_0024UfoLGZQPQWwCBF9Q_003D, _0023_003Dzx5fE0Zn26f8WRpa4yw_003D_003D _0023_003DzHFWw_0024Winsv58, long _0023_003Dz1ltWTOc_003D, long _0023_003DzsUYguL0_003D, double _0023_003DzoMBKEgY_003D, double _0023_003DzfBEBL_o_003D, ulong _0023_003DzoLNS3E1Pxgua, string _0023_003DzOeiF_0024SI_003D = "")
		: base(_0023_003Dz1jrm9N_0024UfoLGZQPQWwCBF9Q_003D, _0023_003DzHFWw_0024Winsv58, _0023_003DzamqCopiqy2oc(_0023_003DzOeiF_0024SI_003D), _0023_003DzoLNS3E1Pxgua)
	{
		_0023_003DzGQmoODbMR1Vi = _0023_003DzZV3ZiKOGb1YJ;
		_0023_003Dz2FQYtOs_003D = _0023_003Dz1ltWTOc_003D;
		_0023_003Dz5LaEuoE_003D = _0023_003DzsUYguL0_003D;
		_0023_003DzNwF0_ko_003D = _0023_003DzoMBKEgY_003D;
		_0023_003DzxCjI_9c_003D = _0023_003DzfBEBL_o_003D;
		_0023_003DzrGMyqfJ35C20 = _0023_003DzOeiF_0024SI_003D;
		_0023_003Dzx3stKwWHA6u8Y67B_g_003D_003D _0023_003Dzx3stKwWHA6u8Y67B_g_003D_003D2 = _0023_003DzHFWw_0024Winsv58._0023_003DziJsS_S8_003D._0023_003Dz9NoRPtrD1TA7();
		_0023_003DzzKg7bM4bJl9X = _0023_003Dzx3stKwWHA6u8Y67B_g_003D_003D2._0023_003DzCdWOnfutkAv0(_0023_003Dz2FQYtOs_003D, _0023_003Dz5LaEuoE_003D);
		_0023_003Dz2DwFFA9M7ImW = ((_0023_003DzzKg7bM4bJl9X == 64) ? ((object)ulong.MaxValue) : ((object)(ulong)((1L << (int)_0023_003DzzKg7bM4bJl9X) - 1)));
	}

	private static uint _0023_003DzamqCopiqy2oc(string _0023_003DzS_00246o7tc_003D)
	{
		if (!(_0023_003DzS_00246o7tc_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302742405)))
		{
			if (!(_0023_003DzS_00246o7tc_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302742129)))
			{
				if (!(_0023_003DzS_00246o7tc_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302742144)))
				{
					if (_0023_003DzS_00246o7tc_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302742123))
					{
						return 8u;
					}
					return 0u;
				}
				return 4u;
			}
			return 2u;
		}
		return 1u;
	}

	public override ulong _0023_003DzlR6_0024bFKxIO9L(byte[] _0023_003DzK42AOhaAnl4C, ulong _0023_003DzNYxlP17PRu00, ulong _0023_003Dzv1TeLYMxx2me)
	{
		ulong val = _0023_003Dzc_00245BnRNRPPXZ._0023_003Dzu8sgotQ_003D() - _0023_003Dzc_00245BnRNRPPXZ._0023_003DzQwZDbJQ_003D();
		ulong num = _0023_003Dzv1TeLYMxx2me - _0023_003DzNYxlP17PRu00;
		ulong val2 = ((num != 0L && _0023_003DzzKg7bM4bJl9X != 0) ? (num / _0023_003DzzKg7bM4bJl9X) : 0);
		ulong _0023_003Dz7tIMWlw_003D = Math.Min(val, val2);
		if (_0023_003Dz7tIMWlw_003D > _0023_003DziZiYS_Z2g6V4 - _0023_003Dz2F1zp4WtKF3x)
		{
			_0023_003Dz7tIMWlw_003D = _0023_003DziZiYS_Z2g6V4 - _0023_003Dz2F1zp4WtKF3x;
		}
		_0023_003DzRJ_TQW0_003D[] array = new _0023_003DzRJ_TQW0_003D[_0023_003DzK42AOhaAnl4C.Length / _0023_003DzamqCopiqy2oc(_0023_003DzrGMyqfJ35C20)];
		int num2 = 0;
		if (typeof(_0023_003DzRJ_TQW0_003D) == typeof(ushort))
		{
			MemoryStream memoryStream = new MemoryStream(_0023_003DzK42AOhaAnl4C);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
					{
						ushort num3 = binaryReader.ReadUInt16();
						array[num2] = (_0023_003DzRJ_TQW0_003D)(object)num3;
						num2++;
					}
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		if (typeof(_0023_003DzRJ_TQW0_003D) == typeof(byte))
		{
			if (_0023_003DzK42AOhaAnl4C.Length != 0)
			{
				MemoryStream memoryStream2 = new MemoryStream(_0023_003DzK42AOhaAnl4C);
				try
				{
					BinaryReader binaryReader2 = new BinaryReader(memoryStream2);
					try
					{
						while (binaryReader2.BaseStream.Position < binaryReader2.BaseStream.Length)
						{
							byte b = binaryReader2.ReadByte();
							array[num2] = (_0023_003DzRJ_TQW0_003D)(object)b;
							num2++;
						}
					}
					finally
					{
						((IDisposable)binaryReader2).Dispose();
					}
				}
				finally
				{
					((IDisposable)memoryStream2).Dispose();
				}
			}
		}
		else if (typeof(_0023_003DzRJ_TQW0_003D) == typeof(uint))
		{
			if (_0023_003DzK42AOhaAnl4C.Length != 0)
			{
				MemoryStream memoryStream3 = new MemoryStream(_0023_003DzK42AOhaAnl4C);
				try
				{
					BinaryReader binaryReader3 = new BinaryReader(memoryStream3);
					try
					{
						while (binaryReader3.BaseStream.Position < binaryReader3.BaseStream.Length)
						{
							uint num4 = binaryReader3.ReadUInt32();
							array[num2] = (_0023_003DzRJ_TQW0_003D)(object)num4;
							num2++;
						}
					}
					finally
					{
						((IDisposable)binaryReader3).Dispose();
					}
				}
				finally
				{
					((IDisposable)memoryStream3).Dispose();
				}
			}
		}
		else if (typeof(_0023_003DzRJ_TQW0_003D) == typeof(ulong))
		{
			MemoryStream memoryStream4 = new MemoryStream(_0023_003DzK42AOhaAnl4C);
			try
			{
				BinaryReader binaryReader4 = new BinaryReader(memoryStream4);
				try
				{
					while (binaryReader4.BaseStream.Position < binaryReader4.BaseStream.Length)
					{
						ulong num5 = binaryReader4.ReadUInt64();
						array[num2] = (_0023_003DzRJ_TQW0_003D)(object)num5;
						num2++;
					}
				}
				finally
				{
					((IDisposable)binaryReader4).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream4).Dispose();
			}
		}
		int _0023_003DzOJZw_0024WDAFEwY = 0;
		ulong _0023_003DzjiPwDShhJEFv = _0023_003DzNYxlP17PRu00;
		_0023_003DzXjOCl3g_003D(array, ref _0023_003DzOJZw_0024WDAFEwY, ref _0023_003DzjiPwDShhJEFv, ref _0023_003Dz7tIMWlw_003D);
		_0023_003Dz2F1zp4WtKF3x += _0023_003Dz7tIMWlw_003D;
		return _0023_003Dz7tIMWlw_003D * _0023_003DzzKg7bM4bJl9X;
	}

	private void _0023_003DzXjOCl3g_003D(_0023_003DzRJ_TQW0_003D[] _0023_003Dz9wrgv_g_003D, ref int _0023_003DzOJZw_0024WDAFEwY, ref ulong _0023_003DzjiPwDShhJEFv, ref ulong _0023_003Dz7tIMWlw_003D)
	{
		for (int i = 0; i < (int)_0023_003Dz7tIMWlw_003D; i++)
		{
			if (typeof(_0023_003DzRJ_TQW0_003D) == typeof(byte))
			{
				byte b = (byte)(object)_0023_003Dz9wrgv_g_003D[_0023_003DzOJZw_0024WDAFEwY];
				byte b2 = 0;
				if (_0023_003DzjiPwDShhJEFv == 0L)
				{
					b2 = b;
				}
				else if (_0023_003DzjiPwDShhJEFv + _0023_003DzzKg7bM4bJl9X <= _0023_003DzJSe_0024oFcDMvn6)
				{
					b2 = (byte)(b >> (int)_0023_003DzjiPwDShhJEFv);
				}
				else
				{
					byte num = (byte)(object)_0023_003Dz9wrgv_g_003D[_0023_003DzOJZw_0024WDAFEwY + 1];
					int num2 = (int)_0023_003DzjiPwDShhJEFv;
					int num3 = (int)(_0023_003DzJSe_0024oFcDMvn6 - _0023_003DzjiPwDShhJEFv);
					b2 = (byte)((num << num3) | (b >> num2));
				}
				b2 &= Convert.ToByte(_0023_003Dz2DwFFA9M7ImW);
				long _0023_003DzPzO_0024GUk_003D = _0023_003Dz2FQYtOs_003D + b2;
				if (_0023_003DzGQmoODbMR1Vi)
				{
					_0023_003Dzc_00245BnRNRPPXZ._0023_003Dz2eEst8KT40Ts(_0023_003DzPzO_0024GUk_003D, _0023_003DzNwF0_ko_003D, _0023_003DzxCjI_9c_003D);
				}
				else
				{
					_0023_003Dzc_00245BnRNRPPXZ._0023_003Dz2eEst8KT40Ts(_0023_003DzPzO_0024GUk_003D);
				}
				_0023_003DzjiPwDShhJEFv += _0023_003DzzKg7bM4bJl9X;
				if (_0023_003DzjiPwDShhJEFv >= 8)
				{
					_0023_003DzjiPwDShhJEFv -= 8uL;
					_0023_003DzOJZw_0024WDAFEwY++;
				}
				continue;
			}
			if (typeof(_0023_003DzRJ_TQW0_003D) == typeof(ushort))
			{
				ushort num4 = (ushort)(object)_0023_003Dz9wrgv_g_003D[_0023_003DzOJZw_0024WDAFEwY];
				ushort num5 = 0;
				if (_0023_003DzjiPwDShhJEFv == 0L)
				{
					num5 = num4;
				}
				else if (_0023_003DzjiPwDShhJEFv + _0023_003DzzKg7bM4bJl9X <= _0023_003DzJSe_0024oFcDMvn6)
				{
					num5 = (ushort)(num4 >> (int)_0023_003DzjiPwDShhJEFv);
				}
				else
				{
					ushort num6 = (ushort)(object)_0023_003Dz9wrgv_g_003D[_0023_003DzOJZw_0024WDAFEwY + 1];
					int num7 = (int)_0023_003DzjiPwDShhJEFv;
					int num8 = (int)(_0023_003DzJSe_0024oFcDMvn6 - _0023_003DzjiPwDShhJEFv);
					num5 = (ushort)((num6 << num8) | (num4 >> num7));
				}
				num5 &= Convert.ToUInt16(_0023_003Dz2DwFFA9M7ImW);
				long _0023_003DzPzO_0024GUk_003D2 = _0023_003Dz2FQYtOs_003D + num5;
				if (_0023_003DzGQmoODbMR1Vi)
				{
					_0023_003Dzc_00245BnRNRPPXZ._0023_003Dz2eEst8KT40Ts(_0023_003DzPzO_0024GUk_003D2, _0023_003DzNwF0_ko_003D, _0023_003DzxCjI_9c_003D);
				}
				else
				{
					_0023_003Dzc_00245BnRNRPPXZ._0023_003Dz2eEst8KT40Ts(_0023_003DzPzO_0024GUk_003D2);
				}
				_0023_003DzjiPwDShhJEFv += _0023_003DzzKg7bM4bJl9X;
				if (_0023_003DzjiPwDShhJEFv >= 16)
				{
					_0023_003DzjiPwDShhJEFv -= 16uL;
					_0023_003DzOJZw_0024WDAFEwY++;
				}
				continue;
			}
			if (typeof(_0023_003DzRJ_TQW0_003D) == typeof(uint))
			{
				uint num9 = (uint)(object)_0023_003Dz9wrgv_g_003D[_0023_003DzOJZw_0024WDAFEwY];
				uint num10 = 0u;
				if (_0023_003DzjiPwDShhJEFv == 0L)
				{
					num10 = num9;
				}
				else if (_0023_003DzjiPwDShhJEFv + _0023_003DzzKg7bM4bJl9X <= _0023_003DzJSe_0024oFcDMvn6)
				{
					num10 = num9 >> (int)_0023_003DzjiPwDShhJEFv;
				}
				else
				{
					uint num11 = (uint)(object)_0023_003Dz9wrgv_g_003D[_0023_003DzOJZw_0024WDAFEwY + 1];
					int num12 = (int)_0023_003DzjiPwDShhJEFv;
					int num13 = (int)(_0023_003DzJSe_0024oFcDMvn6 - _0023_003DzjiPwDShhJEFv);
					num10 = (num11 << num13) | (num9 >> num12);
				}
				num10 &= Convert.ToUInt32(_0023_003Dz2DwFFA9M7ImW);
				long _0023_003DzPzO_0024GUk_003D3 = _0023_003Dz2FQYtOs_003D + num10;
				if (_0023_003DzGQmoODbMR1Vi)
				{
					_0023_003Dzc_00245BnRNRPPXZ._0023_003Dz2eEst8KT40Ts(_0023_003DzPzO_0024GUk_003D3, _0023_003DzNwF0_ko_003D, _0023_003DzxCjI_9c_003D);
				}
				else
				{
					_0023_003Dzc_00245BnRNRPPXZ._0023_003Dz2eEst8KT40Ts(_0023_003DzPzO_0024GUk_003D3);
				}
				_0023_003DzjiPwDShhJEFv += _0023_003DzzKg7bM4bJl9X;
				if (_0023_003DzjiPwDShhJEFv >= 32)
				{
					_0023_003DzjiPwDShhJEFv -= 32uL;
					_0023_003DzOJZw_0024WDAFEwY++;
				}
				continue;
			}
			if (typeof(_0023_003DzRJ_TQW0_003D) == typeof(ulong))
			{
				ulong num14 = (ulong)(object)_0023_003Dz9wrgv_g_003D[_0023_003DzOJZw_0024WDAFEwY];
				ulong num15 = 0uL;
				if (_0023_003DzjiPwDShhJEFv == 0L)
				{
					num15 = num14;
				}
				else if (_0023_003DzjiPwDShhJEFv + _0023_003DzzKg7bM4bJl9X <= _0023_003DzJSe_0024oFcDMvn6)
				{
					num15 = num14 >> (int)_0023_003DzjiPwDShhJEFv;
				}
				else
				{
					ulong num16 = (ulong)(object)_0023_003Dz9wrgv_g_003D[_0023_003DzOJZw_0024WDAFEwY + 1];
					int num17 = (int)_0023_003DzjiPwDShhJEFv;
					int num18 = (int)(_0023_003DzJSe_0024oFcDMvn6 - _0023_003DzjiPwDShhJEFv);
					num15 = (num16 << num18) | (num14 >> num17);
				}
				num15 &= Convert.ToUInt64(_0023_003Dz2DwFFA9M7ImW);
				long _0023_003DzPzO_0024GUk_003D4 = _0023_003Dz5LaEuoE_003D + (long)num15;
				if (_0023_003DzGQmoODbMR1Vi)
				{
					_0023_003Dzc_00245BnRNRPPXZ._0023_003Dz2eEst8KT40Ts(_0023_003DzPzO_0024GUk_003D4, _0023_003DzNwF0_ko_003D, _0023_003DzxCjI_9c_003D);
				}
				else
				{
					_0023_003Dzc_00245BnRNRPPXZ._0023_003Dz2eEst8KT40Ts(_0023_003DzPzO_0024GUk_003D4);
				}
				_0023_003DzjiPwDShhJEFv += _0023_003DzzKg7bM4bJl9X;
				if (_0023_003DzjiPwDShhJEFv >= 64)
				{
					_0023_003DzjiPwDShhJEFv -= 64uL;
					_0023_003DzOJZw_0024WDAFEwY++;
				}
				continue;
			}
			throw new NotSupportedException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302742106), typeof(_0023_003DzRJ_TQW0_003D)));
		}
	}
}
