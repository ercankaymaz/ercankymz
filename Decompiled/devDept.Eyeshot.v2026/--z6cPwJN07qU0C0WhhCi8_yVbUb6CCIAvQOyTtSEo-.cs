using System;

internal sealed class _0023_003Dz6cPwJN07qU0C0WhhCi8_yVbUb6CCIAvQOyTtSEo_003D
{
	public enum _0023_003DzCp025oNguDa9
	{
		ELFE_NBR_NODES = 3,
		MAX_SHELL = 6
	}

	private static int[] _0023_003DziHgMMu0_003D = new int[3] { 0, 1, 2 };

	private static readonly int[] _0023_003DzgFSaGpA_003D = new int[12]
	{
		0, 1, 2, 0, 2, 3, 0, 1, 3, 1,
		2, 3
	};

	private static readonly int[] _0023_003DzgEt85RU_003D = new int[45]
	{
		0, 1, 2, 0, 2, 3, 0, 3, 4, 0,
		1, 2, 0, 2, 4, 2, 3, 4, 1, 2,
		3, 0, 1, 3, 0, 3, 4, 1, 2, 3,
		1, 3, 4, 0, 1, 4, 2, 3, 4, 1,
		2, 4, 0, 1, 4
	};

	private static readonly int[] _0023_003DzBYRvmLs_003D = new int[168]
	{
		0, 1, 2, 0, 2, 3, 0, 3, 4, 0,
		4, 5, 0, 1, 2, 0, 2, 4, 2, 3,
		4, 0, 4, 5, 0, 1, 2, 0, 2, 5,
		2, 4, 5, 2, 3, 4, 0, 1, 2, 0,
		2, 3, 0, 3, 5, 3, 4, 5, 0, 1,
		2, 0, 2, 5, 2, 3, 5, 3, 4, 5,
		1, 2, 3, 1, 3, 4, 1, 4, 5, 1,
		5, 0, 1, 2, 3, 1, 3, 5, 3, 4,
		5, 1, 5, 0, 1, 2, 3, 0, 1, 3,
		0, 3, 5, 3, 4, 5, 1, 2, 3, 1,
		3, 4, 1, 4, 0, 0, 4, 5, 1, 2,
		3, 0, 1, 3, 0, 3, 4, 0, 4, 5,
		2, 3, 4, 1, 2, 4, 0, 1, 4, 0,
		4, 5, 2, 3, 4, 2, 4, 1, 1, 4,
		5, 1, 5, 0, 2, 3, 4, 2, 4, 5,
		2, 5, 1, 1, 5, 0, 5, 3, 4, 5,
		2, 3, 5, 1, 2, 5, 0, 1
	};

	private static int[] _0023_003Dza4MFmNc_003D = new int[4] { 0, 2, 1, 3 };

	private static readonly int[] _0023_003DzjYgvSgU_003D = new int[20]
	{
		0, 2, 0, 3, 0, 2, 2, 4, 1, 3,
		0, 3, 1, 3, 1, 4, 2, 4, 1, 4
	};

	private static readonly int[] _0023_003DzrSiY1Po_003D = new int[84]
	{
		0, 2, 0, 3, 0, 4, 0, 2, 2, 4,
		0, 4, 2, 0, 2, 4, 2, 5, 2, 0,
		0, 3, 3, 5, 0, 2, 2, 5, 5, 3,
		1, 3, 1, 4, 1, 5, 1, 3, 3, 5,
		5, 1, 3, 1, 3, 0, 3, 5, 0, 4,
		4, 1, 1, 3, 4, 0, 0, 3, 3, 1,
		4, 0, 4, 1, 4, 2, 5, 1, 1, 4,
		4, 2, 1, 5, 5, 2, 2, 4, 5, 1,
		5, 2, 5, 3
	};

	public static uint _0023_003DzLAvyP4iGkp85Hx3MYOsY9bs_003D(uint _0023_003Dz7H_cmNQ_003D)
	{
		uint[] array = new uint[7] { 0u, 0u, 0u, 1u, 2u, 5u, 14u };
		if (_0023_003Dz7H_cmNQ_003D >= 7)
		{
			return 0u;
		}
		return array[_0023_003Dz7H_cmNQ_003D];
	}

	public static uint _0023_003DzFumE15ueHXIHyekgIg_003D_003D(uint _0023_003Dz7H_cmNQ_003D)
	{
		if (_0023_003Dz7H_cmNQ_003D < 2)
		{
			return 0u;
		}
		return _0023_003Dz7H_cmNQ_003D - 2;
	}

	public static uint _0023_003DzsDqG5Qrltc_0024_3YnzIg_003D_003D(uint _0023_003Dz7H_cmNQ_003D)
	{
		if (_0023_003Dz7H_cmNQ_003D < 2)
		{
			return 0u;
		}
		return _0023_003Dz7H_cmNQ_003D - 2;
	}

	public static uint _0023_003DzCxnHes_5bPQGzeaFU7Hmmuc_003D(uint _0023_003Dz7H_cmNQ_003D)
	{
		if (_0023_003Dz7H_cmNQ_003D < 3)
		{
			return 0u;
		}
		return _0023_003Dz7H_cmNQ_003D - 3;
	}

	public static bool _0023_003DztVBkHoiNjqOp(uint _0023_003Dz7H_cmNQ_003D, ref int[] _0023_003Dzifq_QG8_003D, ref int[] _0023_003Dz79R_0024VZY_003D)
	{
		switch (_0023_003Dz7H_cmNQ_003D)
		{
		case 3u:
			Array.Resize(ref _0023_003Dzifq_QG8_003D, _0023_003DziHgMMu0_003D.Length);
			_0023_003Dzifq_QG8_003D = _0023_003DziHgMMu0_003D;
			break;
		case 4u:
			Array.Resize(ref _0023_003Dzifq_QG8_003D, _0023_003DzgFSaGpA_003D.Length);
			Array.Resize(ref _0023_003Dz79R_0024VZY_003D, _0023_003Dza4MFmNc_003D.Length);
			_0023_003Dzifq_QG8_003D = _0023_003DzgFSaGpA_003D;
			_0023_003Dz79R_0024VZY_003D = _0023_003Dza4MFmNc_003D;
			break;
		case 5u:
			Array.Resize(ref _0023_003Dzifq_QG8_003D, _0023_003DzgEt85RU_003D.Length);
			Array.Resize(ref _0023_003Dz79R_0024VZY_003D, _0023_003DzjYgvSgU_003D.Length);
			_0023_003Dzifq_QG8_003D = _0023_003DzgEt85RU_003D;
			_0023_003Dz79R_0024VZY_003D = _0023_003DzjYgvSgU_003D;
			break;
		case 6u:
			Array.Resize(ref _0023_003Dzifq_QG8_003D, _0023_003DzBYRvmLs_003D.Length);
			Array.Resize(ref _0023_003Dz79R_0024VZY_003D, _0023_003DzrSiY1Po_003D.Length);
			_0023_003Dzifq_QG8_003D = _0023_003DzBYRvmLs_003D;
			_0023_003Dz79R_0024VZY_003D = _0023_003DzrSiY1Po_003D;
			break;
		}
		return _0023_003Dz7H_cmNQ_003D <= 6;
	}

	public static bool _0023_003DztVBkHoiNjqOp(uint _0023_003Dz7H_cmNQ_003D, uint _0023_003DzG5kqCuWLHsML, ref int[] _0023_003Dzifq_QG8_003D, ref int _0023_003DzQ1ybVqo_003D, ref int[] _0023_003Dz79R_0024VZY_003D, ref int _0023_003DzNM8_6G0_003D, ref uint _0023_003DzGwgXmSuy_BJ3, ref uint _0023_003DzeAHWd_0024blbaz_0024, ref uint _0023_003DzYeiS8F7VIr0l)
	{
		bool result = _0023_003DztVBkHoiNjqOp(_0023_003Dz7H_cmNQ_003D, ref _0023_003Dzifq_QG8_003D, ref _0023_003Dz79R_0024VZY_003D);
		_0023_003DzGwgXmSuy_BJ3 = 0u;
		_0023_003DzeAHWd_0024blbaz_0024 = _0023_003Dz7H_cmNQ_003D - 2;
		_0023_003DzYeiS8F7VIr0l = _0023_003Dz7H_cmNQ_003D - 3;
		_0023_003DzQ1ybVqo_003D += (int)(_0023_003DzG5kqCuWLHsML * 3 * _0023_003DzeAHWd_0024blbaz_0024);
		_0023_003DzNM8_6G0_003D += (int)(_0023_003DzG5kqCuWLHsML * 2 * _0023_003DzYeiS8F7VIr0l);
		return result;
	}
}
