using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

internal sealed class _0023_003DzGZh8_0024BDFfDuikVamog_003D_003D : ICollection<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D>, IEnumerable<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D>, IEnumerable
{
	private sealed class _0023_003Dzk0GI3n85P6rg5EhV9w_003D_003D : IEnumerable<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D>, IEnumerable, IEnumerator<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzGZh8_0024BDFfDuikVamog_003D_003D _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzN6G05Lg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzY5zrJcs6HdDa;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Random _0023_003Dzlraf5vU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Random _0023_003DzA_9KPSSvZE6U;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzmYjjLftN8MAW_0024bU4XA_003D_003D;

		[DebuggerHidden]
		public _0023_003Dzk0GI3n85P6rg5EhV9w_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			_0023_003DzU7pGb3X7Zp4G = -2;
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zc0uzWO$CiiAh6KSB0g==
			this._0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
		}

		private bool MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzGZh8_0024BDFfDuikVamog_003D_003D _0023_003DzGZh8_0024BDFfDuikVamog_003D_003D2 = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzmYjjLftN8MAW_0024bU4XA_003D_003D = _0023_003DzGZh8_0024BDFfDuikVamog_003D_003D2.Count;
				if (_0023_003DzN6G05Lg_003D > _0023_003DzmYjjLftN8MAW_0024bU4XA_003D_003D)
				{
					_0023_003DzN6G05Lg_003D = _0023_003DzmYjjLftN8MAW_0024bU4XA_003D_003D;
				}
				break;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				break;
			}
			while (_0023_003DzN6G05Lg_003D > 0)
			{
				int num2 = _0023_003Dzlraf5vU_003D.Next(0, _0023_003DzmYjjLftN8MAW_0024bU4XA_003D_003D);
				_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2 = _0023_003DzGZh8_0024BDFfDuikVamog_003D_003D2._0023_003DzUFpglTk_003D[num2 / 1024][num2 % 1024];
				if (_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2._0023_003Dzi6_5x7g_003D >= 0)
				{
					_0023_003DzN6G05Lg_003D--;
					_0023_003DzezVIuujSK1H9 = _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2;
					_0023_003DzU7pGb3X7Zp4G = 1;
					return true;
				}
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D _0023_003DznsjaGsuO1dFElHgpEUIFC_YwNWIbaF0UJov8K5A_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D IEnumerator<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=znsjaGsuO1dFElHgpEUIFC_YwNWIbaF0UJov8K5A=
			return this._0023_003DznsjaGsuO1dFElHgpEUIFC_YwNWIbaF0UJov8K5A_003D();
		}

		[DebuggerHidden]
		private void _0023_003DzrmSvUIWk93_00242zIiUzQ_003D_003D()
		{
			throw new NotSupportedException();
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zrmSvUIWk93$2zIiUzQ==
			this._0023_003DzrmSvUIWk93_00242zIiUzQ_003D_003D();
		}

		[DebuggerHidden]
		private object _0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		object IEnumerator.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zfCYrBzv_gLnXs9JxTTL2gC0=
			return this._0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D();
		}

		[DebuggerHidden]
		private IEnumerator<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D> _0023_003DzyjosM4oBXnwlR_002480vGKEUYwXOnZO_0024ZVFCv4IW9k_003D()
		{
			_0023_003Dzk0GI3n85P6rg5EhV9w_003D_003D _0023_003Dzk0GI3n85P6rg5EhV9w_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003Dzk0GI3n85P6rg5EhV9w_003D_003D2 = this;
			}
			else
			{
				_0023_003Dzk0GI3n85P6rg5EhV9w_003D_003D2 = new _0023_003Dzk0GI3n85P6rg5EhV9w_003D_003D(0);
				_0023_003Dzk0GI3n85P6rg5EhV9w_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			_0023_003Dzk0GI3n85P6rg5EhV9w_003D_003D2._0023_003DzN6G05Lg_003D = _0023_003DzY5zrJcs6HdDa;
			_0023_003Dzk0GI3n85P6rg5EhV9w_003D_003D2._0023_003Dzlraf5vU_003D = _0023_003DzA_9KPSSvZE6U;
			return _0023_003Dzk0GI3n85P6rg5EhV9w_003D_003D2;
		}

		IEnumerator<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D> IEnumerable<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zyjosM4oBXnwlR$80vGKEUYwXOnZO$ZVFCv4IW9k=
			return this._0023_003DzyjosM4oBXnwlR_002480vGKEUYwXOnZO_0024ZVFCv4IW9k_003D();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003DzyjosM4oBXnwlR_002480vGKEUYwXOnZO_0024ZVFCv4IW9k_003D();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	private sealed class _0023_003Dzr84pz_0024g_003D : IEnumerator<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003Dzfsn580w_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D[][] _0023_003DzUFpglTk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D _0023_003Dz3Ftsho0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzyzK8swU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzfBEBL_o_003D;

		public _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D Current => _0023_003Dz3Ftsho0_003D;

		public _0023_003Dzr84pz_0024g_003D(_0023_003DzGZh8_0024BDFfDuikVamog_003D_003D _0023_003DzUFpglTk_003D)
		{
			_0023_003Dzfsn580w_003D = _0023_003DzUFpglTk_003D.Count;
			this._0023_003DzUFpglTk_003D = _0023_003DzUFpglTk_003D._0023_003DzUFpglTk_003D;
			_0023_003DzyzK8swU_003D = 0;
			_0023_003DzfBEBL_o_003D = 0;
		}

		public void Dispose()
		{
		}

		private object _0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D()
		{
			return _0023_003Dz3Ftsho0_003D;
		}

		object IEnumerator.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zfCYrBzv_gLnXs9JxTTL2gC0=
			return this._0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D();
		}

		public bool MoveNext()
		{
			while (_0023_003DzyzK8swU_003D < _0023_003Dzfsn580w_003D)
			{
				_0023_003Dz3Ftsho0_003D = _0023_003DzUFpglTk_003D[_0023_003DzfBEBL_o_003D / 1024][_0023_003DzfBEBL_o_003D % 1024];
				_0023_003DzfBEBL_o_003D++;
				if (_0023_003Dz3Ftsho0_003D._0023_003Dzi6_5x7g_003D >= 0)
				{
					_0023_003DzyzK8swU_003D++;
					return true;
				}
			}
			return false;
		}

		public void Reset()
		{
			_0023_003DzyzK8swU_003D = (_0023_003DzfBEBL_o_003D = 0);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz14lzA48_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzfsn580w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D[][] _0023_003DzUFpglTk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stack<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D> _0023_003DzoIXQ5WI_003D;

	public int Count => _0023_003Dzfsn580w_003D - _0023_003DzoIXQ5WI_003D.Count;

	public bool IsReadOnly => true;

	public _0023_003DzGZh8_0024BDFfDuikVamog_003D_003D()
	{
		_0023_003Dz14lzA48_003D = 0;
		int num = Math.Max(1, 64);
		_0023_003DzUFpglTk_003D = new _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D[num][];
		_0023_003DzUFpglTk_003D[0] = new _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D[1024];
		_0023_003DzoIXQ5WI_003D = new Stack<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D>(1024);
	}

	public _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D _0023_003Dz2mJ2y7U_003D()
	{
		_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2;
		if (_0023_003DzoIXQ5WI_003D.Count > 0)
		{
			_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2 = _0023_003DzoIXQ5WI_003D.Pop();
			_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2._0023_003Dzi6_5x7g_003D = -_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2._0023_003Dzi6_5x7g_003D - 1;
			_0023_003DzjP7mmKc_003D(_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2);
		}
		else if (_0023_003Dzfsn580w_003D < _0023_003Dz14lzA48_003D)
		{
			_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2 = _0023_003DzUFpglTk_003D[_0023_003Dzfsn580w_003D / 1024][_0023_003Dzfsn580w_003D % 1024];
			_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2._0023_003Dz2QVVx8s_003D = _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2._0023_003Dzi6_5x7g_003D;
			_0023_003DzjP7mmKc_003D(_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2);
			_0023_003Dzfsn580w_003D++;
		}
		else
		{
			_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2 = new _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D();
			_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2._0023_003Dzi6_5x7g_003D = _0023_003Dz14lzA48_003D;
			_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2._0023_003Dz2QVVx8s_003D = _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2._0023_003Dzi6_5x7g_003D;
			int num = _0023_003Dz14lzA48_003D / 1024;
			if (_0023_003DzUFpglTk_003D[num] == null)
			{
				_0023_003DzUFpglTk_003D[num] = new _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D[1024];
				if (num + 1 == _0023_003DzUFpglTk_003D.Length)
				{
					Array.Resize(ref _0023_003DzUFpglTk_003D, 2 * _0023_003DzUFpglTk_003D.Length);
				}
			}
			_0023_003DzUFpglTk_003D[num][_0023_003Dz14lzA48_003D % 1024] = _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2;
			_0023_003Dzfsn580w_003D = ++_0023_003Dz14lzA48_003D;
		}
		return _0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D2;
	}

	public void _0023_003Dz8LTHs9w_003D(_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D _0023_003DznnnQx3RwjThsBRPB9w_003D_003D)
	{
		_0023_003DzoIXQ5WI_003D.Push(_0023_003DznnnQx3RwjThsBRPB9w_003D_003D);
		_0023_003DznnnQx3RwjThsBRPB9w_003D_003D._0023_003Dzi6_5x7g_003D = -_0023_003DznnnQx3RwjThsBRPB9w_003D_003D._0023_003Dzi6_5x7g_003D - 1;
	}

	public _0023_003DzGZh8_0024BDFfDuikVamog_003D_003D _0023_003Dz_0024SpdFwY_003D()
	{
		foreach (_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D item in _0023_003DzoIXQ5WI_003D)
		{
			item._0023_003Dzi6_5x7g_003D = -item._0023_003Dzi6_5x7g_003D - 1;
		}
		_0023_003DzoIXQ5WI_003D.Clear();
		_0023_003Dzfsn580w_003D = 0;
		return this;
	}

	[IteratorStateMachine(typeof(_0023_003Dzk0GI3n85P6rg5EhV9w_003D_003D))]
	internal IEnumerable<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D> _0023_003DzoWQfySA_003D(int _0023_003DzN6G05Lg_003D, Random _0023_003Dzlraf5vU_003D)
	{
		return new _0023_003Dzk0GI3n85P6rg5EhV9w_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this,
			_0023_003DzY5zrJcs6HdDa = _0023_003DzN6G05Lg_003D,
			_0023_003DzA_9KPSSvZE6U = _0023_003Dzlraf5vU_003D
		};
	}

	private void _0023_003DzjP7mmKc_003D(_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D _0023_003DznnnQx3RwjThsBRPB9w_003D_003D)
	{
		_0023_003DznnnQx3RwjThsBRPB9w_003D_003D._0023_003Dz7uX3t_0024g_003D = 0;
		_0023_003DznnnQx3RwjThsBRPB9w_003D_003D._0023_003DzXWCF4rA_003D = 0.0;
		_0023_003DznnnQx3RwjThsBRPB9w_003D_003D._0023_003DzA3K6FwWsC6ETgy16Pw_003D_003D = false;
		for (int i = 0; i < 3; i++)
		{
			_0023_003DznnnQx3RwjThsBRPB9w_003D_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i] = null;
			_0023_003DznnnQx3RwjThsBRPB9w_003D_003D._0023_003Dzuvo_H6cl79f4[i] = default(_0023_003Dzl_0024gxlV8P00qGW2ZRm_G1kWI_003D);
			_0023_003DznnnQx3RwjThsBRPB9w_003D_003D._0023_003Dz8WM3j__0024e6O4Z2VuOjw_003D_003D[i] = default(_0023_003DzppJNOGX935r27BbEya4Bno0_003D);
		}
	}

	public void Add(_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D _0023_003DzUBZd570_003D)
	{
		throw new NotImplementedException();
	}

	public void Clear()
	{
		_0023_003DzoIXQ5WI_003D.Clear();
		int num = _0023_003Dz14lzA48_003D / 1024 + 1;
		for (int i = 0; i < num; i++)
		{
			_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D[] array = _0023_003DzUFpglTk_003D[i];
			int num2 = (_0023_003Dz14lzA48_003D - i * 1024) % 1024;
			for (int j = 0; j < num2; j++)
			{
				array[j] = null;
			}
		}
		_0023_003Dz14lzA48_003D = (_0023_003Dzfsn580w_003D = 0);
	}

	public bool Contains(_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D _0023_003DzUBZd570_003D)
	{
		int _0023_003Dzi6_5x7g_003D = _0023_003DzUBZd570_003D._0023_003Dzi6_5x7g_003D;
		if (_0023_003Dzi6_5x7g_003D < 0 || _0023_003Dzi6_5x7g_003D > _0023_003Dz14lzA48_003D)
		{
			return false;
		}
		return _0023_003DzUFpglTk_003D[_0023_003Dzi6_5x7g_003D / 1024][_0023_003Dzi6_5x7g_003D % 1024]._0023_003Dzi6_5x7g_003D >= 0;
	}

	public void CopyTo(_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D[] _0023_003DzTbDlaOM_003D, int _0023_003DzyzK8swU_003D)
	{
		IEnumerator<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			_0023_003DzTbDlaOM_003D[_0023_003DzyzK8swU_003D] = enumerator.Current;
			_0023_003DzyzK8swU_003D++;
		}
	}

	public bool Remove(_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D _0023_003DzUBZd570_003D)
	{
		throw new NotImplementedException();
	}

	public IEnumerator<_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D> GetEnumerator()
	{
		return new _0023_003Dzr84pz_0024g_003D(this);
	}

	private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
	{
		return GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
		return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
	}
}
