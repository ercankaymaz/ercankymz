using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal sealed class _0023_003Dzs2bajpKjWbmv2KO9uw_003D_003D
{
	protected internal sealed class _0023_003Dz00RwLV85nNhr
	{
		public ulong _0023_003DzmhpUO6yoZKKw;

		public byte[] _0023_003DzH22qlQQ_003D = new byte[_0023_003Dz_0024oxQthahZeIK._0023_003DzPz59Q49i5BOkok0U0Za7iv0_003D];

		public int _0023_003Dz99SbQWVr8dPk;
	}

	protected internal int _0023_003Dzxjq8Z8DoGySo;

	protected internal int _0023_003DzSK_78yFPmrKQ;

	protected internal _0023_003DzRCSzLwxOTjNO _0023_003DzXzmStFY_003D;

	protected internal List<_0023_003Dz00RwLV85nNhr> _0023_003DztahZMos_003D;

	public _0023_003Dzs2bajpKjWbmv2KO9uw_003D_003D()
	{
	}

	public _0023_003Dzs2bajpKjWbmv2KO9uw_003D_003D(_0023_003DzRCSzLwxOTjNO _0023_003DzIheLSec_003D, int _0023_003DzgK4Zf9w_003D)
	{
		_0023_003DzXzmStFY_003D = _0023_003DzIheLSec_003D;
		if (_0023_003DzgK4Zf9w_003D == 0)
		{
			throw new Exception();
		}
		_0023_003DztahZMos_003D = new _0023_003Dz00RwLV85nNhr[_0023_003DzgK4Zf9w_003D].ToList();
		for (int i = 0; i < _0023_003DzgK4Zf9w_003D; i++)
		{
			_0023_003DztahZMos_003D[i] = new _0023_003Dz00RwLV85nNhr();
		}
	}

	public _0023_003Dz_0024EGbqCm1KY5P2ENDgw_003D_003D _0023_003DzzOB9U9w_003D(ulong _0023_003DzXn30yAr_0024fDQK, ref byte[] _0023_003DzbHNZBcY_003D)
	{
		if (_0023_003Dzxjq8Z8DoGySo != 0)
		{
			_0023_003DzBL_TeXvDux7E(0u);
		}
		if (_0023_003Dzxjq8Z8DoGySo > 0)
		{
			throw new Exception();
		}
		if (_0023_003DzXn30yAr_0024fDQK == 0L)
		{
			throw new Exception();
		}
		for (int i = 0; i < _0023_003DztahZMos_003D.Count; i++)
		{
			_0023_003Dz00RwLV85nNhr _0023_003Dz00RwLV85nNhr2 = _0023_003DztahZMos_003D[i];
			if (_0023_003DzXn30yAr_0024fDQK == _0023_003Dz00RwLV85nNhr2._0023_003DzmhpUO6yoZKKw)
			{
				_0023_003Dz00RwLV85nNhr2._0023_003Dz99SbQWVr8dPk = ++_0023_003DzSK_78yFPmrKQ;
				_0023_003DzbHNZBcY_003D = _0023_003Dz00RwLV85nNhr2._0023_003DzH22qlQQ_003D;
				_0023_003Dz_0024EGbqCm1KY5P2ENDgw_003D_003D result = new _0023_003Dz_0024EGbqCm1KY5P2ENDgw_003D_003D(this, (uint)i);
				_0023_003Dzxjq8Z8DoGySo++;
				return result;
			}
		}
		int num = 0;
		int _0023_003Dz99SbQWVr8dPk = _0023_003DztahZMos_003D[0]._0023_003Dz99SbQWVr8dPk;
		for (int j = 0; j < _0023_003DztahZMos_003D.Count; j++)
		{
			_0023_003Dz00RwLV85nNhr _0023_003Dz00RwLV85nNhr3 = _0023_003DztahZMos_003D[j];
			if (_0023_003Dz00RwLV85nNhr3._0023_003Dz99SbQWVr8dPk < _0023_003Dz99SbQWVr8dPk)
			{
				num = j;
				_0023_003Dz99SbQWVr8dPk = _0023_003Dz00RwLV85nNhr3._0023_003Dz99SbQWVr8dPk;
			}
		}
		_0023_003DzjMoD5gCXMOAm(num, _0023_003DzXn30yAr_0024fDQK, (_0023_003DzRCSzLwxOTjNO._0023_003DzIaMpQArClRxi)0);
		_0023_003DzbHNZBcY_003D = _0023_003DztahZMos_003D[num]._0023_003DzH22qlQQ_003D;
		_0023_003Dz_0024EGbqCm1KY5P2ENDgw_003D_003D _0023_003Dz_0024EGbqCm1KY5P2ENDgw_003D_003D2 = new _0023_003Dz_0024EGbqCm1KY5P2ENDgw_003D_003D(this, (uint)num);
		_0023_003Dzxjq8Z8DoGySo++;
		try
		{
			_0023_003DzBL_TeXvDux7E(_0023_003Dz_0024EGbqCm1KY5P2ENDgw_003D_003D2._0023_003DzaKWk4triZ1SY);
			return _0023_003Dz_0024EGbqCm1KY5P2ENDgw_003D_003D2;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	private void _0023_003DzjMoD5gCXMOAm(int _0023_003Dz66AqDi3h3Ibev4nVWQ_003D_003D, ulong _0023_003DzXn30yAr_0024fDQK, _0023_003DzRCSzLwxOTjNO._0023_003DzIaMpQArClRxi _0023_003DzwDw4oqTZBK7U)
	{
		_0023_003DzFRgYt4kRdfbDoBi3Bg_003D_003D _0023_003DzFRgYt4kRdfbDoBi3Bg_003D_003D2 = new _0023_003DzFRgYt4kRdfbDoBi3Bg_003D_003D();
		if (_0023_003DzXzmStFY_003D._0023_003DzWPFOr9I_003D == null || !_0023_003DzXzmStFY_003D._0023_003DzWPFOr9I_003D.CanSeek)
		{
			_0023_003DzXzmStFY_003D._0023_003DzWPFOr9I_003D = new FileStream(_0023_003DzXzmStFY_003D._0023_003DzN5mckSmx8lqo, FileMode.Open, FileAccess.Read);
		}
		byte[] _0023_003DzDj6LpX0_003D = new byte[4];
		_0023_003DzXzmStFY_003D._0023_003DzT51EUwQ_003D(_0023_003DzXn30yAr_0024fDQK, (_0023_003DzRCSzLwxOTjNO._0023_003DzIaMpQArClRxi)0);
		_0023_003DzXzmStFY_003D._0023_003DzuuY9lIM_003D(ref _0023_003DzDj6LpX0_003D, 4L, 0L);
		MemoryStream memoryStream = new MemoryStream(_0023_003DzDj6LpX0_003D);
		try
		{
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			try
			{
				_0023_003DzFRgYt4kRdfbDoBi3Bg_003D_003D2._0023_003DzNaZfx10_003D = binaryReader.ReadByte();
				_0023_003DzFRgYt4kRdfbDoBi3Bg_003D_003D2._0023_003Dzu1KFZHw_003D = binaryReader.ReadByte();
				_0023_003DzFRgYt4kRdfbDoBi3Bg_003D_003D2._0023_003DzfMOL2E_0024F0iBbZ3RI8w_003D_003D = binaryReader.ReadUInt16();
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
		if (_0023_003DzFRgYt4kRdfbDoBi3Bg_003D_003D2._0023_003DzfMOL2E_0024F0iBbZ3RI8w_003D_003D + 1 > _0023_003Dz_0024oxQthahZeIK._0023_003DzPz59Q49i5BOkok0U0Za7iv0_003D)
		{
			throw new Exception();
		}
		_0023_003Dz00RwLV85nNhr _0023_003Dz00RwLV85nNhr2 = _0023_003DztahZMos_003D[_0023_003Dz66AqDi3h3Ibev4nVWQ_003D_003D];
		if (_0023_003DzXzmStFY_003D._0023_003DzWPFOr9I_003D == null || !_0023_003DzXzmStFY_003D._0023_003DzWPFOr9I_003D.CanSeek)
		{
			_0023_003DzXzmStFY_003D._0023_003DzWPFOr9I_003D = new FileStream(_0023_003DzXzmStFY_003D._0023_003DzN5mckSmx8lqo, FileMode.Open, FileAccess.Read);
		}
		_0023_003Dz00RwLV85nNhr2._0023_003DzH22qlQQ_003D = new byte[_0023_003DzFRgYt4kRdfbDoBi3Bg_003D_003D2._0023_003DzfMOL2E_0024F0iBbZ3RI8w_003D_003D + 1];
		_0023_003DzXzmStFY_003D._0023_003DzT51EUwQ_003D(_0023_003DzXn30yAr_0024fDQK, (_0023_003DzRCSzLwxOTjNO._0023_003DzIaMpQArClRxi)0);
		_0023_003DzXzmStFY_003D._0023_003DzuuY9lIM_003D(ref _0023_003Dz00RwLV85nNhr2._0023_003DzH22qlQQ_003D, _0023_003DzFRgYt4kRdfbDoBi3Bg_003D_003D2._0023_003DzfMOL2E_0024F0iBbZ3RI8w_003D_003D + 1, 0L);
		switch (_0023_003DzFRgYt4kRdfbDoBi3Bg_003D_003D2._0023_003DzNaZfx10_003D)
		{
		case 1:
			new _0023_003Dzky71NbzzZtXT(_0023_003Dz00RwLV85nNhr2._0023_003DzH22qlQQ_003D);
			break;
		default:
			throw new Exception();
		case 0:
		case 2:
			break;
		}
		_0023_003Dz00RwLV85nNhr2._0023_003DzmhpUO6yoZKKw = _0023_003DzXn30yAr_0024fDQK;
		_0023_003Dz00RwLV85nNhr2._0023_003Dz99SbQWVr8dPk = ++_0023_003DzSK_78yFPmrKQ;
	}

	protected internal void _0023_003DzBL_TeXvDux7E(uint _0023_003DzaKWk4triZ1SY)
	{
		if (_0023_003Dzxjq8Z8DoGySo != 1)
		{
			throw new Exception();
		}
		_0023_003Dzxjq8Z8DoGySo--;
	}
}
