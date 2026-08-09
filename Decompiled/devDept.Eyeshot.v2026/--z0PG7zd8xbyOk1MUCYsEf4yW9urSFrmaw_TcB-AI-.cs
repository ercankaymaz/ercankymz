using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

internal sealed class _0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Exp, bool> _0023_003DzXxUuNy3uXlhVbmH2Yw_003D_003D;

		public static Func<Exp, Exp> _0023_003DzfboZSHzYXYu8n06YCg_003D_003D;

		internal bool _0023_003DzfybUHw1LZpmuFUvl1V778tM_003D(Exp _0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzbfrNXYE_003D._0023_003DzSHi1GOA_003D();
		}

		internal Exp _0023_003DzfykiYHWUBuLt1hmoBSyDwh8_003D(Exp _0023_003DzbfrNXYE_003D)
		{
			return (Exp)_0023_003DzbfrNXYE_003D.Clone();
		}
	}

	public Point3D _0023_003Dz_PR4lSU_003D;

	private bool _0023_003Dzn2gDcB0_003D = true;

	public int _0023_003DzHVkM4M9vsPcN = 100;

	public int _0023_003DzCj4jCRH3z6Gb = 4;

	public bool _0023_003DzFZC8G3iHtBMiEUB3b_0024Ox7_0024E_003D = true;

	private Exp[,] _0023_003DzeV5N9i0_003D;

	private double[,] _0023_003DzE8QrneA_003D;

	private double[] _0023_003DzH9VU2k0_003D;

	private double[] _0023_003Dzyk2fsPo_003D;

	private double[] _0023_003DzwkV4YjIKg_0024Hc;

	public List<Exp> _0023_003DzPPlaxaZ7sNaeTRG2hA_003D_003D = new List<Exp>();

	public List<Dictionary<Param, Exp>> _0023_003DzJuq1mFv6piLHNkjQLvMDlps_003D = new List<Dictionary<Param, Exp>>();

	public List<Param> _0023_003DzBlBnvuA_003D = new List<Param>();

	private List<Exp> _0023_003DzXMVGBHVmumq2ImENew_003D_003D = new List<Exp>();

	private List<Dictionary<Param, Exp>> _0023_003DzbGOJqHmDPOcR5EjUCQ_003D_003D = new List<Dictionary<Param, Exp>>();

	private List<Param> _0023_003DzObwQx_no3Bpl = new List<Param>();

	private Dictionary<Param, Param> _0023_003Dzk5pc6hsntgMt;

	public ExpVector _0023_003DzX6bq7sSjCTnm;

	private string _0023_003DzNiBo5fczHi1wYGu_00240g_003D_003D;

	private bool _0023_003DzVmHjI1XK_0024Th7W_00240utAOAlO4_003D;

	public int _0023_003Dz8brSmNa5saYu;

	public bool _0023_003DzWs_0024SmPOzWOCJ()
	{
		return _0023_003Dzn2gDcB0_003D;
	}

	public void _0023_003Dz96CX9U88jjMLoO6qZQ_003D_003D(Exp _0023_003DzYO5g7Fc_003D)
	{
		_0023_003DzPPlaxaZ7sNaeTRG2hA_003D_003D.Add(_0023_003DzYO5g7Fc_003D);
		_0023_003Dzn2gDcB0_003D = true;
	}

	public void _0023_003Dz96CX9U88jjMLoO6qZQ_003D_003D(ExpVector _0023_003Dz77g161c_003D)
	{
		_0023_003DzPPlaxaZ7sNaeTRG2hA_003D_003D.Add(_0023_003Dz77g161c_003D.x);
		_0023_003DzPPlaxaZ7sNaeTRG2hA_003D_003D.Add(_0023_003Dz77g161c_003D.y);
		_0023_003DzPPlaxaZ7sNaeTRG2hA_003D_003D.Add(_0023_003Dz77g161c_003D.z);
		_0023_003Dzn2gDcB0_003D = true;
	}

	public void _0023_003DzSJnfST_p7FvhG2o4OQ_003D_003D(IEnumerable<Exp> _0023_003DzYO5g7Fc_003D)
	{
		_0023_003DzPPlaxaZ7sNaeTRG2hA_003D_003D.AddRange(_0023_003DzYO5g7Fc_003D);
		_0023_003Dzn2gDcB0_003D = true;
	}

	public void _0023_003Dz100_0024qp_0024X6A14O11RCQ_003D_003D(Exp _0023_003DzYO5g7Fc_003D)
	{
		_0023_003DzPPlaxaZ7sNaeTRG2hA_003D_003D.Remove(_0023_003DzYO5g7Fc_003D);
		_0023_003Dzn2gDcB0_003D = true;
	}

	public void _0023_003Dz2AL_0024zf8_003D(Param _0023_003DzB68dg9Q_003D)
	{
		_0023_003DzBlBnvuA_003D.Add(_0023_003DzB68dg9Q_003D);
		_0023_003Dzn2gDcB0_003D = true;
	}

	public void _0023_003DzIAHusRU_003D(IEnumerable<Param> _0023_003DzB68dg9Q_003D)
	{
		_0023_003DzBlBnvuA_003D.AddRange(_0023_003DzB68dg9Q_003D);
		_0023_003Dzn2gDcB0_003D = true;
	}

	public void _0023_003Dz2m2938oFK1gG(Mate _0023_003Dz48C9g9BkbHSw)
	{
		if (_0023_003Dz48C9g9BkbHSw._0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D == null || _0023_003Dz48C9g9BkbHSw._0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D == null)
		{
			_0023_003Dz48C9g9BkbHSw._0023_003Dz3ScgB2IkFM6oBKJhsA_003D_003D();
		}
		foreach (ExpVector item in _0023_003Dz48C9g9BkbHSw._0023_003DzZi5wFbzsYQAyqkPNXQ_003D_003D)
		{
			_0023_003Dz96CX9U88jjMLoO6qZQ_003D_003D(item);
		}
		foreach (Exp item2 in _0023_003Dz48C9g9BkbHSw._0023_003DzCNNjnoZfJXmRoUt2_g_003D_003D)
		{
			_0023_003Dz96CX9U88jjMLoO6qZQ_003D_003D(item2);
		}
		foreach (Dictionary<Param, Exp> item3 in _0023_003Dz48C9g9BkbHSw._0023_003DzbGOJqHmDPOcR5EjUCQ_003D_003D)
		{
			_0023_003DzJuq1mFv6piLHNkjQLvMDlps_003D.Add(item3);
		}
	}

	public void _0023_003DzB2nO_002414_003D(Param _0023_003DzB68dg9Q_003D)
	{
		_0023_003DzBlBnvuA_003D.Remove(_0023_003DzB68dg9Q_003D);
		_0023_003Dzn2gDcB0_003D = true;
	}

	public void _0023_003DzBUjqlpM_003D(ref double[] _0023_003DzH9VU2k0_003D, bool _0023_003DzqgM8eZfShepX)
	{
		for (int i = 0; i < _0023_003DzXMVGBHVmumq2ImENew_003D_003D.Count; i++)
		{
			if (_0023_003DzqgM8eZfShepX && _0023_003DzXMVGBHVmumq2ImENew_003D_003D[i]._0023_003DzSHi1GOA_003D())
			{
				_0023_003DzH9VU2k0_003D[i] = 0.0;
			}
			else
			{
				_0023_003DzH9VU2k0_003D[i] = _0023_003DzXMVGBHVmumq2ImENew_003D_003D[i]._0023_003DzBUjqlpM_003D();
			}
		}
	}

	public void _0023_003DzBUjqlpM_003D(out Vector<double> _0023_003Dzn2qoE4_8t6mK, Vector<double> _0023_003DzB68dg9Q_003D, bool _0023_003DzqgM8eZfShepX)
	{
		_0023_003Dzn2qoE4_8t6mK = new DenseVector(_0023_003DzXMVGBHVmumq2ImENew_003D_003D.Count);
		for (int i = 0; i < _0023_003DzBlBnvuA_003D.Count; i++)
		{
			_0023_003DzBlBnvuA_003D[i]._0023_003DzO_0024HwSzQ_003D(_0023_003DzB68dg9Q_003D[i]);
		}
		for (int j = 0; j < _0023_003DzXMVGBHVmumq2ImENew_003D_003D.Count; j++)
		{
			if (_0023_003DzqgM8eZfShepX && _0023_003DzXMVGBHVmumq2ImENew_003D_003D[j]._0023_003DzSHi1GOA_003D())
			{
				_0023_003DzH9VU2k0_003D[j] = 0.0;
			}
			else
			{
				_0023_003Dzn2qoE4_8t6mK[j] = 0.0 - _0023_003DzXMVGBHVmumq2ImENew_003D_003D[j]._0023_003DzBUjqlpM_003D();
			}
		}
		for (int k = 0; k < _0023_003DzBlBnvuA_003D.Count; k++)
		{
			_0023_003DzBlBnvuA_003D[k]._0023_003DzO_0024HwSzQ_003D(_0023_003Dzyk2fsPo_003D[k]);
		}
	}

	public bool _0023_003Dzf07L9tuvLNf6I3v_zw_003D_003D(bool _0023_003Dz77OzOmooENr4, bool _0023_003DzF_0024LInI_0024aHwUMe7VDUZhBv_o_003D)
	{
		for (int i = 0; i < _0023_003DzXMVGBHVmumq2ImENew_003D_003D.Count; i++)
		{
			if ((_0023_003Dz77OzOmooENr4 || !_0023_003DzXMVGBHVmumq2ImENew_003D_003D[i]._0023_003DzSHi1GOA_003D()) && !(Math.Abs(_0023_003DzH9VU2k0_003D[i]) < 1E-12) && !_0023_003DzF_0024LInI_0024aHwUMe7VDUZhBv_o_003D)
			{
				return false;
			}
		}
		return true;
	}

	private void _0023_003Dz_0024G3gBjoQK_0024m7()
	{
		_0023_003DzwkV4YjIKg_0024Hc = new double[_0023_003DzBlBnvuA_003D.Count];
		for (int i = 0; i < _0023_003DzBlBnvuA_003D.Count; i++)
		{
			_0023_003DzwkV4YjIKg_0024Hc[i] = _0023_003DzBlBnvuA_003D[i]._0023_003DzV29zQ3g_003D();
		}
	}

	private void _0023_003Dz2yvQF2BysQ27()
	{
		for (int i = 0; i < _0023_003DzBlBnvuA_003D.Count; i++)
		{
			_0023_003DzBlBnvuA_003D[i]._0023_003DzO_0024HwSzQ_003D(_0023_003DzwkV4YjIKg_0024Hc[i]);
		}
	}

	private static Exp[,] _0023_003DzmKWT86vYA8Nhekpwbg_003D_003D(List<Dictionary<Param, Exp>> _0023_003DzbGOJqHmDPOcR5EjUCQ_003D_003D, List<Exp> _0023_003DzXMVGBHVmumq2ImENew_003D_003D, List<Param> _0023_003DzBlBnvuA_003D)
	{
		if (_0023_003DzbGOJqHmDPOcR5EjUCQ_003D_003D.Count == 0)
		{
			Exp[,] array = new Exp[_0023_003DzXMVGBHVmumq2ImENew_003D_003D.Count, _0023_003DzBlBnvuA_003D.Count];
			for (int i = 0; i < _0023_003DzXMVGBHVmumq2ImENew_003D_003D.Count; i++)
			{
				Exp exp = _0023_003DzXMVGBHVmumq2ImENew_003D_003D[i];
				for (int j = 0; j < _0023_003DzBlBnvuA_003D.Count; j++)
				{
					Param _0023_003DzB68dg9Q_003D = _0023_003DzBlBnvuA_003D[j];
					array[i, j] = exp._0023_003DzSOlfnhbkZ12J(_0023_003DzB68dg9Q_003D);
				}
			}
			return array;
		}
		Exp[,] array2 = new Exp[_0023_003DzbGOJqHmDPOcR5EjUCQ_003D_003D.Count, _0023_003DzBlBnvuA_003D.Count];
		for (int k = 0; k < _0023_003DzbGOJqHmDPOcR5EjUCQ_003D_003D.Count; k++)
		{
			for (int l = 0; l < _0023_003DzBlBnvuA_003D.Count; l++)
			{
				if (_0023_003DzbGOJqHmDPOcR5EjUCQ_003D_003D[k].TryGetValue(_0023_003DzBlBnvuA_003D[l], out var value))
				{
					array2[k, l] = value;
				}
				else
				{
					array2[k, l] = 0.0;
				}
			}
		}
		return array2;
	}

	public bool _0023_003Dz_rjtkYs_003D()
	{
		return _0023_003DzXMVGBHVmumq2ImENew_003D_003D.Any(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzfybUHw1LZpmuFUvl1V778tM_003D);
	}

	public void _0023_003Dzt2vroVTf9Yfw_00247Bakg_003D_003D(Exp[,] _0023_003DzeV5N9i0_003D, ref double[,] _0023_003DzE8QrneA_003D, bool _0023_003DzqgM8eZfShepX)
	{
		for (int i = 0; i < _0023_003DzeV5N9i0_003D.GetLength(0); i++)
		{
			if (_0023_003DzqgM8eZfShepX && _0023_003DzXMVGBHVmumq2ImENew_003D_003D[i]._0023_003DzSHi1GOA_003D())
			{
				for (int j = 0; j < _0023_003DzeV5N9i0_003D.GetLength(1); j++)
				{
					_0023_003DzE8QrneA_003D[i, j] = 0.0;
				}
			}
			else
			{
				for (int k = 0; k < _0023_003DzeV5N9i0_003D.GetLength(1); k++)
				{
					_0023_003DzE8QrneA_003D[i, k] = _0023_003DzeV5N9i0_003D[i, k]._0023_003DzBUjqlpM_003D();
				}
			}
		}
	}

	public static void _0023_003DzBLRPGmwPXW4LTycuqQ_003D_003D(double[,] _0023_003DzE8QrneA_003D, double[] _0023_003DzH9VU2k0_003D, ref double[] _0023_003Dzyk2fsPo_003D, double _0023_003Dz64_0024wWwU_003D)
	{
		MathNet.Numerics.LinearAlgebra.Double.Matrix matrix = SparseMatrix.OfArray(_0023_003DzE8QrneA_003D);
		Matrix<double> matrix2 = matrix.Transpose();
		Vector<double> vector = new DenseVector(_0023_003DzH9VU2k0_003D);
		Vector<double> vector2 = matrix2 * vector;
		Matrix<double> matrix3 = matrix2 * matrix;
		for (int i = 0; i < matrix3.RowCount; i++)
		{
			if (matrix3[i, i] >= 0.0)
			{
				matrix3[i, i] = Math.Max(matrix3[i, i] * (1.0 + _0023_003Dz64_0024wWwU_003D), matrix3[i, i] + _0023_003Dz64_0024wWwU_003D);
			}
			else
			{
				matrix3[i, i] = Math.Min(matrix3[i, i] * (1.0 + _0023_003Dz64_0024wWwU_003D), matrix3[i, i] - _0023_003Dz64_0024wWwU_003D);
			}
		}
		bool flag = false;
		int rowCount = matrix3.RowCount;
		NurbsBase.Cholesky(matrix3.ToArray(), rowCount, out var L);
		double[] array = new double[rowCount];
		for (int j = 0; j < rowCount; j++)
		{
			double num = 0.0;
			for (int k = 0; k < j; k++)
			{
				num += L[j, k] * array[k];
			}
			if (Math.Abs(L[j, j]) < 1E-12)
			{
				flag = true;
				break;
			}
			array[j] = (vector2[j] - num) / L[j, j];
		}
		for (int num2 = rowCount - 1; num2 >= 0; num2--)
		{
			double num3 = 0.0;
			for (int l = num2 + 1; l < rowCount; l++)
			{
				num3 += L[l, num2] * _0023_003Dzyk2fsPo_003D[l];
			}
			if (Math.Abs(L[num2, num2]) < 1E-12)
			{
				flag = true;
				break;
			}
			_0023_003Dzyk2fsPo_003D[num2] = (array[num2] - num3) / L[num2, num2];
		}
		if (!flag && !(vector2.AbsoluteMaximum() < Utility._0023_003DzheSR8QM7q9ya))
		{
			return;
		}
		double num4 = vector.AbsoluteMaximum();
		if (num4 > Utility._0023_003DzheSR8QM7q9ya)
		{
			for (int m = 0; m < _0023_003Dzyk2fsPo_003D.Length; m++)
			{
				_0023_003Dzyk2fsPo_003D[m] += (double)((m % 2 == 0) ? 1 : (-1)) * num4 / 100.0;
			}
		}
	}

	public int _0023_003DzbZBxE_0024c_003D(out int _0023_003DzeaV2Z0o_003D)
	{
		_0023_003Dzt2vroVTf9Yfw_00247Bakg_003D_003D(_0023_003DzeV5N9i0_003D, ref _0023_003DzE8QrneA_003D, _0023_003DzqgM8eZfShepX: false);
		int num = GaussianMethod.Rank(_0023_003DzE8QrneA_003D);
		_0023_003DzeaV2Z0o_003D = _0023_003DzE8QrneA_003D.GetLength(1) - num;
		return _0023_003DzE8QrneA_003D.GetLength(0) - num;
	}

	private void _0023_003DzfoHqmgs_003D()
	{
		if (_0023_003Dzn2gDcB0_003D)
		{
			_0023_003DzXMVGBHVmumq2ImENew_003D_003D = _0023_003DzPPlaxaZ7sNaeTRG2hA_003D_003D.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzfykiYHWUBuLt1hmoBSyDwh8_003D).ToList();
			_0023_003DzObwQx_no3Bpl = _0023_003DzBlBnvuA_003D.ToList();
			_0023_003Dzk5pc6hsntgMt = _0023_003Dz_0024TNo2t2T8RaA();
			_0023_003DzeV5N9i0_003D = _0023_003DzmKWT86vYA8Nhekpwbg_003D_003D(_0023_003DzJuq1mFv6piLHNkjQLvMDlps_003D, _0023_003DzXMVGBHVmumq2ImENew_003D_003D, _0023_003DzObwQx_no3Bpl);
			_0023_003Dzn2gDcB0_003D = false;
			_0023_003DzE8QrneA_003D = new double[_0023_003DzXMVGBHVmumq2ImENew_003D_003D.Count, _0023_003DzObwQx_no3Bpl.Count];
			_0023_003DzH9VU2k0_003D = new double[_0023_003DzXMVGBHVmumq2ImENew_003D_003D.Count];
			_0023_003Dzyk2fsPo_003D = new double[_0023_003DzObwQx_no3Bpl.Count];
			for (int i = 0; i < _0023_003DzObwQx_no3Bpl.Count; i++)
			{
				_0023_003Dzyk2fsPo_003D[i] = _0023_003DzObwQx_no3Bpl[i]._0023_003DzV29zQ3g_003D();
			}
			_0023_003DzwkV4YjIKg_0024Hc = new double[_0023_003DzBlBnvuA_003D.Count];
			_0023_003DzIYs_pI_SEf6A(_0023_003DzPzO_0024GUk_003D: true);
		}
	}

	private void _0023_003DzBmZPDRoItueE(Dictionary<Param, Param> _0023_003Dzk5pc6hsntgMt)
	{
		if (_0023_003Dzk5pc6hsntgMt == null)
		{
			return;
		}
		for (int i = 0; i < _0023_003DzBlBnvuA_003D.Count; i++)
		{
			Param param = _0023_003DzBlBnvuA_003D[i];
			if (_0023_003Dzk5pc6hsntgMt.ContainsKey(param))
			{
				param._0023_003DzO_0024HwSzQ_003D(_0023_003Dzk5pc6hsntgMt[param]._0023_003DzV29zQ3g_003D());
			}
		}
	}

	private Dictionary<Param, Param> _0023_003Dz_0024TNo2t2T8RaA()
	{
		Dictionary<Param, Param> dictionary = new Dictionary<Param, Param>();
		for (int i = 0; i < _0023_003DzXMVGBHVmumq2ImENew_003D_003D.Count; i++)
		{
			Exp exp = _0023_003DzXMVGBHVmumq2ImENew_003D_003D[i];
			if (!exp._0023_003DzB_kWkZdUz_0024nixFmySD0dKDs_003D())
			{
				continue;
			}
			Param param = exp._0023_003Dz1aX_0024I5TLgE2e();
			Param param2 = exp._0023_003DzMQdMDkMBNhOa();
			if (Math.Abs(param._0023_003DzV29zQ3g_003D() - param2._0023_003DzV29zQ3g_003D()) > 1E-12)
			{
				continue;
			}
			if (!_0023_003DzObwQx_no3Bpl.Contains(param2))
			{
				Param param3 = param;
				param = param2;
				param2 = param3;
			}
			foreach (Param item in dictionary.Keys.ToList())
			{
				if (dictionary[item] == param2)
				{
					dictionary[item] = param;
				}
			}
			dictionary[param2] = param;
			_0023_003DzXMVGBHVmumq2ImENew_003D_003D.RemoveAt(i--);
			_0023_003DzObwQx_no3Bpl.Remove(param2);
			for (int j = 0; j < _0023_003DzXMVGBHVmumq2ImENew_003D_003D.Count; j++)
			{
				_0023_003DzXMVGBHVmumq2ImENew_003D_003D[j]._0023_003Dz_9xLui4_003D(param2, param);
			}
		}
		return dictionary;
	}

	public string _0023_003DzSPSNhclcsxIh()
	{
		return _0023_003DzNiBo5fczHi1wYGu_00240g_003D_003D;
	}

	private void _0023_003DzQztTPI_0024_0024bVja(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzNiBo5fczHi1wYGu_00240g_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public bool _0023_003DzeuAWUmtyUODT()
	{
		return _0023_003DzVmHjI1XK_0024Th7W_00240utAOAlO4_003D;
	}

	private void _0023_003DzIYs_pI_SEf6A(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzVmHjI1XK_0024Th7W_00240utAOAlO4_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public solveFailureType _0023_003DzOykoXtw_003D()
	{
		_0023_003DzIYs_pI_SEf6A(_0023_003DzPzO_0024GUk_003D: false);
		_0023_003DzfoHqmgs_003D();
		if (_0023_003DzObwQx_no3Bpl.Count == 0)
		{
			if (_0023_003DzXMVGBHVmumq2ImENew_003D_003D.Count == 0)
			{
				return solveFailureType.Success;
			}
			return solveFailureType.DidntConverge;
		}
		_0023_003Dz_0024G3gBjoQK_0024m7();
		int num = 0;
		double num2 = 10.0;
		double num3 = double.MaxValue;
		do
		{
			bool flag = num <= _0023_003DzCj4jCRH3z6Gb;
			_0023_003DzBUjqlpM_003D(ref _0023_003DzH9VU2k0_003D, !flag);
			double num4 = 0.0;
			for (int i = 0; i < _0023_003DzH9VU2k0_003D.Length; i++)
			{
				num4 += _0023_003DzH9VU2k0_003D[i] * _0023_003DzH9VU2k0_003D[i];
			}
			num2 = ((!(num3 > num4)) ? (num2 * 10.0) : (num2 / 10.0));
			if (_0023_003Dzf07L9tuvLNf6I3v_zw_003D_003D(flag, _0023_003DzF_0024LInI_0024aHwUMe7VDUZhBv_o_003D: false))
			{
				if (num > 0)
				{
					_0023_003DzIYs_pI_SEf6A(_0023_003DzPzO_0024GUk_003D: true);
				}
				_0023_003DzQztTPI_0024_0024bVja(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654989), _0023_003DzXMVGBHVmumq2ImENew_003D_003D.Count, _0023_003DzObwQx_no3Bpl.Count));
				_0023_003DzBmZPDRoItueE(_0023_003Dzk5pc6hsntgMt);
				return solveFailureType.Success;
			}
			num3 = num4;
			_0023_003Dzt2vroVTf9Yfw_00247Bakg_003D_003D(_0023_003DzeV5N9i0_003D, ref _0023_003DzE8QrneA_003D, !flag);
			_0023_003DzBLRPGmwPXW4LTycuqQ_003D_003D(_0023_003DzE8QrneA_003D, _0023_003DzH9VU2k0_003D, ref _0023_003Dzyk2fsPo_003D, num2);
			for (int j = 0; j < _0023_003DzObwQx_no3Bpl.Count; j++)
			{
				Param param = _0023_003DzObwQx_no3Bpl[j];
				param._0023_003DzO_0024HwSzQ_003D(param._0023_003DzV29zQ3g_003D() - _0023_003Dzyk2fsPo_003D[j]);
			}
		}
		while (num++ <= _0023_003DzHVkM4M9vsPcN);
		_0023_003Dzf07L9tuvLNf6I3v_zw_003D_003D(_0023_003Dz77OzOmooENr4: false, _0023_003DzF_0024LInI_0024aHwUMe7VDUZhBv_o_003D: true);
		if (_0023_003DzFZC8G3iHtBMiEUB3b_0024Ox7_0024E_003D)
		{
			_0023_003Dz2yvQF2BysQ27();
			_0023_003DzIYs_pI_SEf6A(_0023_003DzPzO_0024GUk_003D: false);
		}
		return solveFailureType.DidntConverge;
	}
}
