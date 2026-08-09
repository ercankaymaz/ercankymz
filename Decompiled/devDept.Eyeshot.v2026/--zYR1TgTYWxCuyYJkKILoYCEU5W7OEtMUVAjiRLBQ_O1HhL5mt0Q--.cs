using System;
using System.Collections.Generic;
using System.Xml;
using devDept;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003DzYR1TgTYWxCuyYJkKILoYCEU5W7OEtMUVAjiRLBQ_O1HhL5mt0Q_003D_003D
{
	private sealed class _0023_003DzsmYAq442n0Bt : IComparer<_0023_003DzPLVsJqutLb9QakB0UjOfJEpRMHwXSI8dq3Jo4FmwIEh93tZgXQ_003D_003D>
	{
		public int Compare(_0023_003DzPLVsJqutLb9QakB0UjOfJEpRMHwXSI8dq3Jo4FmwIEh93tZgXQ_003D_003D _0023_003DzMEwtr_A_003D, _0023_003DzPLVsJqutLb9QakB0UjOfJEpRMHwXSI8dq3Jo4FmwIEh93tZgXQ_003D_003D _0023_003DzW7Zyxfc_003D)
		{
			int num = -Utility.CompareWithoutTolerance(_0023_003DzMEwtr_A_003D._0023_003Dz9Hzulxu_6DX_0024._0023_003DzFuXfk4k_003D, _0023_003DzW7Zyxfc_003D._0023_003Dz9Hzulxu_6DX_0024._0023_003DzFuXfk4k_003D);
			if (num != 0)
			{
				return num;
			}
			return Utility.CompareWithoutTolerance(_0023_003DzMEwtr_A_003D._0023_003Dz9Hzulxu_6DX_0024._0023_003DzZ_0024Wvtoc_003D, _0023_003DzW7Zyxfc_003D._0023_003Dz9Hzulxu_6DX_0024._0023_003DzZ_0024Wvtoc_003D);
		}
	}

	internal LinkedList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003DzN57VxTE7ZsCw;

	private _0023_003DzPLVsJqutLb9QakB0UjOfJEpRMHwXSI8dq3Jo4FmwIEh93tZgXQ_003D_003D[] _0023_003DzhG4ZL_0024NfB9yNSIAl9w_003D_003D;

	private int _0023_003DzAXtzfrJR7wBx;

	public _0023_003DzYR1TgTYWxCuyYJkKILoYCEU5W7OEtMUVAjiRLBQ_O1HhL5mt0Q_003D_003D(IList<Point2D> _0023_003DzBZc7VVG5asYu, IList<IList<Point2D>> _0023_003DzxZtQCI37epAc, bool _0023_003Dz275RophIENHO)
	{
		if (_0023_003DzBZc7VVG5asYu == null)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653251), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653241));
		}
		if (_0023_003DzBZc7VVG5asYu.Count <= 3)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653222), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653199));
		}
		if (_0023_003Dz275RophIENHO)
		{
			Utility.CheckDir(_0023_003DzBZc7VVG5asYu, _0023_003DzxZtQCI37epAc);
		}
		_0023_003Dz2G0h61f_j3yd(_0023_003DzBZc7VVG5asYu, _0023_003DzxZtQCI37epAc, out var _0023_003DzJB9yXb3atfkL, out var _0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D);
		_0023_003Dz_EYKxgEWgAK_0024FEoz8Q_003D_003D(_0023_003DzJB9yXb3atfkL, _0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D, _0023_003DzaYhgSnxqAWC7: false);
	}

	internal _0023_003DzYR1TgTYWxCuyYJkKILoYCEU5W7OEtMUVAjiRLBQ_O1HhL5mt0Q_003D_003D(List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> _0023_003DzBZc7VVG5asYu, List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> _0023_003DzxZtQCI37epAc, IntegerGrid _0023_003DzOSo8vaE_003D)
	{
		int num = 0;
		_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[] array = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[_0023_003DzBZc7VVG5asYu.Count];
		for (int i = 0; i < _0023_003DzBZc7VVG5asYu.Count; i++)
		{
			array[i] = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(num++, _0023_003DzBZc7VVG5asYu[i]._0023_003Dzyk2fsPo_003D, _0023_003DzBZc7VVG5asYu[i]._0023_003DzvXOLtKg_003D, _0023_003DzOSo8vaE_003D);
		}
		_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[][] array2;
		if (_0023_003DzxZtQCI37epAc != null && _0023_003DzxZtQCI37epAc.Count > 0)
		{
			array2 = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[_0023_003DzxZtQCI37epAc.Count][];
			for (int j = 0; j < _0023_003DzxZtQCI37epAc.Count; j++)
			{
				array2[j] = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[_0023_003DzxZtQCI37epAc[j].Count];
				for (int k = 0; k < _0023_003DzxZtQCI37epAc[j].Count; k++)
				{
					array2[j][k] = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(num++, _0023_003DzxZtQCI37epAc[j][k]._0023_003Dzyk2fsPo_003D, _0023_003DzxZtQCI37epAc[j][k]._0023_003DzvXOLtKg_003D, _0023_003DzOSo8vaE_003D);
				}
			}
		}
		else
		{
			array2 = null;
		}
		_0023_003Dz20RLLdN3YhVAQ9Vl_00242iYibg_003D(array, array2, _0023_003DzaYhgSnxqAWC7: false, _0023_003DzOSo8vaE_003D);
	}

	internal _0023_003DzYR1TgTYWxCuyYJkKILoYCEU5W7OEtMUVAjiRLBQ_O1HhL5mt0Q_003D_003D(IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003DzBZc7VVG5asYu, IList<IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>> _0023_003DzxZtQCI37epAc, bool _0023_003DzaYhgSnxqAWC7)
	{
		_0023_003Dz_EYKxgEWgAK_0024FEoz8Q_003D_003D(_0023_003DzBZc7VVG5asYu, _0023_003DzxZtQCI37epAc, _0023_003DzaYhgSnxqAWC7);
	}

	public _0023_003DzYR1TgTYWxCuyYJkKILoYCEU5W7OEtMUVAjiRLBQ_O1HhL5mt0Q_003D_003D(string _0023_003Dzg5oC_Hs_003D)
	{
		_0023_003Dz7qDp_fk_003D(_0023_003Dzg5oC_Hs_003D, out var _0023_003Dz_SqBXz8_003D, out var _0023_003DzWaFlkhfmYCja);
		_0023_003Dz2G0h61f_j3yd(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, out var _0023_003DzJB9yXb3atfkL, out var _0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D);
		_0023_003Dz_EYKxgEWgAK_0024FEoz8Q_003D_003D(_0023_003DzJB9yXb3atfkL, _0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D, _0023_003DzaYhgSnxqAWC7: false);
	}

	private static void _0023_003Dz2G0h61f_j3yd(IList<Point2D> _0023_003DzBZc7VVG5asYu, IList<IList<Point2D>> _0023_003DzxZtQCI37epAc, out _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[] _0023_003DzJB9yXb3atfkL, out _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[][] _0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D)
	{
		int num = 0;
		_0023_003DzJB9yXb3atfkL = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[_0023_003DzBZc7VVG5asYu.Count];
		for (int i = 0; i < _0023_003DzBZc7VVG5asYu.Count; i++)
		{
			_0023_003DzJB9yXb3atfkL[i] = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(num++, _0023_003DzBZc7VVG5asYu[i]);
		}
		if (_0023_003DzxZtQCI37epAc != null && _0023_003DzxZtQCI37epAc.Count > 0)
		{
			_0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[_0023_003DzxZtQCI37epAc.Count][];
			for (int j = 0; j < _0023_003DzxZtQCI37epAc.Count; j++)
			{
				_0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D[j] = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[_0023_003DzxZtQCI37epAc[j].Count];
				for (int k = 0; k < _0023_003DzxZtQCI37epAc[j].Count; k++)
				{
					_0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D[j][k] = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(num++, _0023_003DzxZtQCI37epAc[j][k]);
				}
			}
		}
		else
		{
			_0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D = null;
		}
	}

	private void _0023_003Dz_EYKxgEWgAK_0024FEoz8Q_003D_003D(IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003DzBZc7VVG5asYu, IList<IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>> _0023_003DzxZtQCI37epAc, bool _0023_003DzaYhgSnxqAWC7)
	{
		IntegerGrid _0023_003DzOSo8vaE_003D = _0023_003Dz5pObody64KXX(_0023_003DzBZc7VVG5asYu, _0023_003DzxZtQCI37epAc);
		_0023_003Dz20RLLdN3YhVAQ9Vl_00242iYibg_003D(_0023_003DzBZc7VVG5asYu, _0023_003DzxZtQCI37epAc, _0023_003DzaYhgSnxqAWC7, _0023_003DzOSo8vaE_003D);
	}

	private void _0023_003Dz20RLLdN3YhVAQ9Vl_00242iYibg_003D(IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003DzBZc7VVG5asYu, IList<IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>> _0023_003DzxZtQCI37epAc, bool _0023_003DzaYhgSnxqAWC7, IntegerGrid _0023_003DzOSo8vaE_003D)
	{
		if (_0023_003DzxZtQCI37epAc != null && _0023_003DzxZtQCI37epAc.Count > 0)
		{
			_0023_003DzhG4ZL_0024NfB9yNSIAl9w_003D_003D = new _0023_003DzPLVsJqutLb9QakB0UjOfJEpRMHwXSI8dq3Jo4FmwIEh93tZgXQ_003D_003D[_0023_003DzxZtQCI37epAc.Count];
			for (int i = 0; i < _0023_003DzxZtQCI37epAc.Count; i++)
			{
				_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzMlCq3wk_003D;
				int _0023_003DzyzK8swU_003D = _0023_003DzWOkzRlCGjXjepYNodw_003D_003D(_0023_003DzxZtQCI37epAc[i], out _0023_003DzMlCq3wk_003D);
				_0023_003DzhG4ZL_0024NfB9yNSIAl9w_003D_003D[i] = new _0023_003DzPLVsJqutLb9QakB0UjOfJEpRMHwXSI8dq3Jo4FmwIEh93tZgXQ_003D_003D(_0023_003DzyzK8swU_003D, i, _0023_003DzMlCq3wk_003D);
			}
			_0023_003DzsmYAq442n0Bt comparer = new _0023_003DzsmYAq442n0Bt();
			Array.Sort(_0023_003DzhG4ZL_0024NfB9yNSIAl9w_003D_003D, comparer);
		}
		_0023_003DzN57VxTE7ZsCw = _0023_003DzUs0ukjH3O3e7(_0023_003DzBZc7VVG5asYu, _0023_003DzxZtQCI37epAc, _0023_003DzaYhgSnxqAWC7, _0023_003DzOSo8vaE_003D);
	}

	private IntegerGrid _0023_003Dz5pObody64KXX(IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003DzBZc7VVG5asYu, IList<IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>> _0023_003DzxZtQCI37epAc)
	{
		Point2D maxValue = Point2D.MaxValue;
		Point2D minValue = Point2D.MinValue;
		_0023_003DzNKw2dpKrk09r(_0023_003DzBZc7VVG5asYu, _0023_003DzBZc7VVG5asYu.Count, maxValue, minValue);
		IntegerGrid integerGrid = new IntegerGrid(524288, maxValue, minValue);
		_0023_003DzxDHv3Thrc_2bh7c1Xg_003D_003D(integerGrid, _0023_003DzBZc7VVG5asYu);
		if (_0023_003DzxZtQCI37epAc != null)
		{
			for (int i = 0; i < _0023_003DzxZtQCI37epAc.Count; i++)
			{
				_0023_003DzxDHv3Thrc_2bh7c1Xg_003D_003D(integerGrid, _0023_003DzxZtQCI37epAc[i]);
			}
		}
		return integerGrid;
	}

	private static void _0023_003DzNKw2dpKrk09r(IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003DzrdSL0CI_003D, int _0023_003Dzfsn580w_003D, Point2D _0023_003DzF7v9r2A_003D, Point2D _0023_003Dz8dK2uhU_003D)
	{
		for (int i = 0; i < _0023_003Dzfsn580w_003D; i++)
		{
			double[] array = _0023_003DzrdSL0CI_003D[i].ToArray();
			if (array[0] < _0023_003DzF7v9r2A_003D.X)
			{
				_0023_003DzF7v9r2A_003D.X = array[0];
			}
			if (array[0] > _0023_003Dz8dK2uhU_003D.X)
			{
				_0023_003Dz8dK2uhU_003D.X = array[0];
			}
			if (array[1] < _0023_003DzF7v9r2A_003D.Y)
			{
				_0023_003DzF7v9r2A_003D.Y = array[1];
			}
			if (array[1] > _0023_003Dz8dK2uhU_003D.Y)
			{
				_0023_003Dz8dK2uhU_003D.Y = array[1];
			}
		}
	}

	private bool _0023_003DzxDHv3Thrc_2bh7c1Xg_003D_003D(IntegerGrid _0023_003DzOSo8vaE_003D, IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003DzdEvMFOw_003D)
	{
		bool result = true;
		for (int i = 0; i < _0023_003DzdEvMFOw_003D.Count; i++)
		{
			_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2 = _0023_003DzdEvMFOw_003D[i];
			_0023_003DzOSo8vaE_003D.ScaleToGrid(_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzIHt45I8_003D.X, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzIHt45I8_003D.Y, out _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzFuXfk4k_003D, out _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzZ_0024Wvtoc_003D);
		}
		return result;
	}

	private LinkedList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003DzUs0ukjH3O3e7(IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003Dz_SqBXz8_003D, IList<IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>> _0023_003DzWaFlkhfmYCja, bool _0023_003DzaYhgSnxqAWC7, IntegerGrid _0023_003DzOSo8vaE_003D)
	{
		_0023_003DzN57VxTE7ZsCw = new LinkedList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>();
		if (!_0023_003DzaYhgSnxqAWC7)
		{
			for (int i = 0; i < _0023_003Dz_SqBXz8_003D.Count - 1; i++)
			{
				if (!_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D._0023_003DzlXwoCr7br7_7(_0023_003Dz_SqBXz8_003D[i], _0023_003Dz_SqBXz8_003D[i + 1]))
				{
					_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2 = _0023_003Dz_SqBXz8_003D[i];
					_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2._0023_003DzyzK8swU_003D = _0023_003DzN57VxTE7ZsCw.Count;
					_0023_003DzN57VxTE7ZsCw.AddLast(_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D2);
				}
			}
			_0023_003DzAXtzfrJR7wBx = _0023_003DzN57VxTE7ZsCw.Count;
		}
		else
		{
			for (int j = 0; j < _0023_003Dz_SqBXz8_003D.Count - 1; j++)
			{
				if (!_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D._0023_003DzlXwoCr7br7_7(_0023_003Dz_SqBXz8_003D[j], _0023_003Dz_SqBXz8_003D[j + 1]))
				{
					_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D value = _0023_003Dz_SqBXz8_003D[j];
					_0023_003DzN57VxTE7ZsCw.AddLast(value);
				}
			}
		}
		double diagonal = new Size2D(_0023_003DzOSo8vaE_003D.GridMax.X - _0023_003DzOSo8vaE_003D.GridMin.X, _0023_003DzOSo8vaE_003D.GridMax.Y - _0023_003DzOSo8vaE_003D.GridMin.Y).Diagonal;
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			IList<IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>> list = new List<IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>>(_0023_003DzWaFlkhfmYCja.Count);
			for (int k = 0; k < _0023_003DzWaFlkhfmYCja.Count; k++)
			{
				list.Add(_0023_003DzWaFlkhfmYCja[k]);
			}
			LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> linkedListNode = null;
			Point2D point2D = null;
			for (int l = 0; l < list.Count; l++)
			{
				int _0023_003DzyzK8swU_003D = _0023_003DzhG4ZL_0024NfB9yNSIAl9w_003D_003D[l]._0023_003DzyzK8swU_003D;
				int _0023_003DzhNQLY4s_003D = _0023_003DzhG4ZL_0024NfB9yNSIAl9w_003D_003D[l]._0023_003DzhNQLY4s_003D;
				_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003Dz9Hzulxu_6DX_0024 = _0023_003DzhG4ZL_0024NfB9yNSIAl9w_003D_003D[l]._0023_003Dz9Hzulxu_6DX_0024;
				Segment2D s = new Segment2D(_0023_003Dz9Hzulxu_6DX_0024._0023_003DzFuXfk4k_003D, _0023_003Dz9Hzulxu_6DX_0024._0023_003DzZ_0024Wvtoc_003D, _0023_003DzOSo8vaE_003D.GridMax.X, _0023_003Dz9Hzulxu_6DX_0024._0023_003DzZ_0024Wvtoc_003D);
				double num = double.MaxValue;
				LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> linkedListNode2;
				for (linkedListNode2 = _0023_003DzN57VxTE7ZsCw.Last; linkedListNode2 != null; linkedListNode2 = linkedListNode2.Previous)
				{
					_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D value2 = linkedListNode2.Value;
					_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D value3 = Utility.CircularNext(linkedListNode2).Value;
					Segment2D s2 = new Segment2D(value2._0023_003DzFuXfk4k_003D, value2._0023_003DzZ_0024Wvtoc_003D, value3._0023_003DzFuXfk4k_003D, value3._0023_003DzZ_0024Wvtoc_003D);
					double num2 = double.MaxValue;
					LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> linkedListNode3 = null;
					Point2D point2D2 = null;
					bool flag = value2._0023_003DzZ_0024Wvtoc_003D == _0023_003Dz9Hzulxu_6DX_0024._0023_003DzZ_0024Wvtoc_003D;
					double num3 = value2._0023_003DzFuXfk4k_003D - _0023_003Dz9Hzulxu_6DX_0024._0023_003DzFuXfk4k_003D;
					if (num3 > 0.0 && flag)
					{
						LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> linkedListNode4 = _0023_003DzN57VxTE7ZsCw.First;
						List<LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>> list2 = new List<LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>>();
						while (linkedListNode4 != null)
						{
							if (linkedListNode4.Value._0023_003DzyzK8swU_003D == linkedListNode2.Value._0023_003DzyzK8swU_003D)
							{
								list2.Add(linkedListNode4);
							}
							linkedListNode4 = linkedListNode4.Next;
						}
						if (list2.Count >= 1)
						{
							bool flag2 = true;
							if (list2.Count > 1)
							{
								flag2 = false;
								LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> linkedListNode5 = Utility.CircularNext(linkedListNode2);
								for (int m = 0; m < list2.Count; m++)
								{
									if (list2[m] != linkedListNode2)
									{
										continue;
									}
									if (linkedListNode2.Value._0023_003DzZ_0024Wvtoc_003D < linkedListNode5.Value._0023_003DzZ_0024Wvtoc_003D || (linkedListNode2.Value._0023_003DzZ_0024Wvtoc_003D == linkedListNode5.Value._0023_003DzZ_0024Wvtoc_003D && _0023_003Dz9Hzulxu_6DX_0024._0023_003DzZ_0024Wvtoc_003D <= linkedListNode2.Value._0023_003DzZ_0024Wvtoc_003D))
									{
										if (m < 0)
										{
											break;
										}
										flag2 = true;
										for (int num4 = m - 1; num4 >= 0; num4--)
										{
											linkedListNode5 = Utility.CircularNext(list2[num4]);
											if (list2[num4].Value._0023_003DzZ_0024Wvtoc_003D < linkedListNode5.Value._0023_003DzZ_0024Wvtoc_003D)
											{
												flag2 = false;
											}
										}
									}
									else
									{
										flag2 = m % 2 == 1;
									}
									break;
								}
							}
							if (flag2)
							{
								num2 = num3;
								linkedListNode3 = linkedListNode2;
								point2D2 = new Point2D(linkedListNode2.Value._0023_003DzFuXfk4k_003D, linkedListNode2.Value._0023_003DzZ_0024Wvtoc_003D);
								goto IL_049e;
							}
						}
					}
					if (value2._0023_003DzZ_0024Wvtoc_003D < _0023_003Dz9Hzulxu_6DX_0024._0023_003DzZ_0024Wvtoc_003D && value3._0023_003DzZ_0024Wvtoc_003D > _0023_003Dz9Hzulxu_6DX_0024._0023_003DzZ_0024Wvtoc_003D)
					{
						Point2D i2;
						Point2D i3;
						segmentIntersectionType segmentIntersectionType2 = Segment2D.Intersection(s, s2, out i2, out i3, diagonal * 0.001);
						if (segmentIntersectionType2 == segmentIntersectionType.Cross || segmentIntersectionType2 == segmentIntersectionType.Touch)
						{
							num3 = i2.X - (double)_0023_003Dz9Hzulxu_6DX_0024._0023_003DzFuXfk4k_003D;
							if (num3 > 0.0)
							{
								num2 = num3;
								LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> linkedListNode6 = Utility.CircularNext(linkedListNode2);
								linkedListNode3 = ((linkedListNode2.Value._0023_003DzFuXfk4k_003D != linkedListNode6.Value._0023_003DzFuXfk4k_003D) ? ((linkedListNode2.Value._0023_003DzFuXfk4k_003D > linkedListNode6.Value._0023_003DzFuXfk4k_003D) ? linkedListNode2 : linkedListNode6) : ((linkedListNode2.Value._0023_003DzZ_0024Wvtoc_003D < linkedListNode6.Value._0023_003DzZ_0024Wvtoc_003D) ? linkedListNode2 : linkedListNode6));
								point2D2 = i2;
							}
						}
					}
					goto IL_049e;
					IL_049e:
					if (num2 < num)
					{
						num = num2;
						linkedListNode = linkedListNode3;
						point2D = point2D2;
					}
				}
				_0023_003DzazmHqjCNiFpk4QoKuA_003D_003D();
				SortedList<double, LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>> sortedList = new SortedList<double, LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>>();
				for (LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> linkedListNode7 = _0023_003DzN57VxTE7ZsCw.First; linkedListNode7 != null; linkedListNode7 = linkedListNode7.Next)
				{
					if (linkedListNode7.Value._0023_003DzWy_0024UOU65OoM7)
					{
						if (point2D == null)
						{
							throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653436));
						}
						double[] array = new double[2]
						{
							linkedListNode7.Value._0023_003DzFuXfk4k_003D - _0023_003Dz9Hzulxu_6DX_0024._0023_003DzFuXfk4k_003D,
							linkedListNode7.Value._0023_003DzZ_0024Wvtoc_003D - _0023_003Dz9Hzulxu_6DX_0024._0023_003DzZ_0024Wvtoc_003D
						};
						double[] array2 = new double[2]
						{
							point2D.X - (double)_0023_003Dz9Hzulxu_6DX_0024._0023_003DzFuXfk4k_003D,
							0.0
						};
						double y = array[0] * array2[1] - array[1] * array2[0];
						double x = array[0] * array2[0] + array[1] * array2[1];
						double key = Math.Abs(Math.Atan2(y, x));
						if (Utility.PointInTriangle(linkedListNode7.Value._0023_003DzFuXfk4k_003D, linkedListNode7.Value._0023_003DzZ_0024Wvtoc_003D, _0023_003Dz9Hzulxu_6DX_0024._0023_003DzFuXfk4k_003D, _0023_003Dz9Hzulxu_6DX_0024._0023_003DzZ_0024Wvtoc_003D, point2D.X, point2D.Y, linkedListNode.Value._0023_003DzFuXfk4k_003D, linkedListNode.Value._0023_003DzZ_0024Wvtoc_003D))
						{
							if (sortedList.ContainsKey(key))
							{
								double num5 = _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D._0023_003DzIXhOPxB2Djci(_0023_003Dz9Hzulxu_6DX_0024, linkedListNode7.Value);
								double num6 = _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D._0023_003DzIXhOPxB2Djci(_0023_003Dz9Hzulxu_6DX_0024, sortedList[key].Value);
								if (num5 < num6)
								{
									sortedList.Remove(key);
									sortedList.Add(key, linkedListNode7);
								}
							}
							else
							{
								sortedList.Add(key, linkedListNode7);
							}
						}
					}
				}
				if (sortedList.Count > 0)
				{
					linkedListNode = sortedList.Values[0];
				}
				if (linkedListNode == null)
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653436));
				}
				linkedListNode2 = linkedListNode;
				LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> linkedListNode8 = linkedListNode2;
				IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> list3 = list[_0023_003DzhNQLY4s_003D];
				int num7 = 0;
				for (int n = 0; n < list3.Count - 1; n++)
				{
					int num8 = _0023_003DzyzK8swU_003D + n;
					if (num8 > list3.Count - 1)
					{
						num8 -= list3.Count - 1;
					}
					_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3 = list3[num8];
					if (!_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D._0023_003DzlXwoCr7br7_7(linkedListNode2.Value, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3))
					{
						if (_0023_003DzaYhgSnxqAWC7)
						{
							_0023_003DzN57VxTE7ZsCw.AddAfter(linkedListNode2, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3);
						}
						else
						{
							_0023_003DzN57VxTE7ZsCw.AddAfter(linkedListNode2, new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(_0023_003DzAXtzfrJR7wBx + num7, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D3));
						}
						linkedListNode2 = linkedListNode2.Next;
						num7++;
					}
				}
				if (_0023_003DzaYhgSnxqAWC7)
				{
					_0023_003DzN57VxTE7ZsCw.AddAfter(linkedListNode2, new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(_0023_003Dz9Hzulxu_6DX_0024._0023_003DzyzK8swU_003D, _0023_003Dz9Hzulxu_6DX_0024));
				}
				else
				{
					_0023_003DzN57VxTE7ZsCw.AddAfter(linkedListNode2, new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(_0023_003DzAXtzfrJR7wBx, _0023_003Dz9Hzulxu_6DX_0024));
				}
				linkedListNode2 = linkedListNode2.Next;
				_0023_003DzN57VxTE7ZsCw.AddAfter(linkedListNode2, new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(linkedListNode8.Value._0023_003DzyzK8swU_003D, linkedListNode8.Value));
				if (!_0023_003DzaYhgSnxqAWC7)
				{
					if (_0023_003DzAXtzfrJR7wBx < linkedListNode8.Value._0023_003DzyzK8swU_003D)
					{
						_0023_003DzAXtzfrJR7wBx = linkedListNode8.Value._0023_003DzyzK8swU_003D;
					}
					if (_0023_003DzAXtzfrJR7wBx < _0023_003DzAXtzfrJR7wBx + num7)
					{
						_0023_003DzAXtzfrJR7wBx += num7;
					}
				}
			}
		}
		if (_0023_003DzaYhgSnxqAWC7)
		{
			_0023_003DzAXtzfrJR7wBx = 0;
			foreach (_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D item in _0023_003DzN57VxTE7ZsCw)
			{
				if (item._0023_003DzyzK8swU_003D > _0023_003DzAXtzfrJR7wBx)
				{
					_0023_003DzAXtzfrJR7wBx = item._0023_003DzyzK8swU_003D;
				}
			}
			_0023_003DzAXtzfrJR7wBx++;
		}
		return _0023_003DzN57VxTE7ZsCw;
	}

	internal IndexTriangle[] _0023_003Dz5bTQ1u9UVidehQ86Hw_003D_003D(Point2D[] _0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D)
	{
		if (_0023_003DzN57VxTE7ZsCw.Count == 0)
		{
			return new IndexTriangle[0];
		}
		_0023_003DzazmHqjCNiFpk4QoKuA_003D_003D();
		List<IndexTriangle> list = new List<IndexTriangle>(_0023_003DzN57VxTE7ZsCw.Count);
		LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> linkedListNode = _0023_003DzN57VxTE7ZsCw.First;
		int num = 0;
		do
		{
			if (!linkedListNode.Value._0023_003DzWy_0024UOU65OoM7)
			{
				LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> linkedListNode2 = Utility.CircularPrevious(linkedListNode);
				LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> linkedListNode3 = linkedListNode;
				LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> linkedListNode4 = Utility.CircularNext(linkedListNode);
				LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> linkedListNode5 = _0023_003DzN57VxTE7ZsCw.First;
				bool flag = false;
				do
				{
					if (linkedListNode5.Value._0023_003DzyzK8swU_003D != linkedListNode2.Value._0023_003DzyzK8swU_003D && linkedListNode5.Value._0023_003DzyzK8swU_003D != linkedListNode3.Value._0023_003DzyzK8swU_003D && linkedListNode5.Value._0023_003DzyzK8swU_003D != linkedListNode4.Value._0023_003DzyzK8swU_003D && _0023_003DzzWJrWcuv5B_0024DZ6Qtew_003D_003D(linkedListNode5.Value._0023_003DzFuXfk4k_003D, linkedListNode5.Value._0023_003DzZ_0024Wvtoc_003D, linkedListNode2.Value._0023_003DzFuXfk4k_003D, linkedListNode2.Value._0023_003DzZ_0024Wvtoc_003D, linkedListNode3.Value._0023_003DzFuXfk4k_003D, linkedListNode3.Value._0023_003DzZ_0024Wvtoc_003D, linkedListNode4.Value._0023_003DzFuXfk4k_003D, linkedListNode4.Value._0023_003DzZ_0024Wvtoc_003D))
					{
						flag = true;
						break;
					}
					linkedListNode5 = linkedListNode5.Next;
				}
				while (linkedListNode5 != null);
				if (!flag)
				{
					int _0023_003DzyzK8swU_003D = linkedListNode3.Value._0023_003DzyzK8swU_003D;
					int _0023_003DzyzK8swU_003D2 = linkedListNode4.Value._0023_003DzyzK8swU_003D;
					int _0023_003DzyzK8swU_003D3 = linkedListNode2.Value._0023_003DzyzK8swU_003D;
					if (_0023_003DzyzK8swU_003D != _0023_003DzyzK8swU_003D2 && _0023_003DzyzK8swU_003D2 != _0023_003DzyzK8swU_003D3 && _0023_003DzyzK8swU_003D != _0023_003DzyzK8swU_003D3)
					{
						list.Add(new IndexTriangle(_0023_003DzyzK8swU_003D, _0023_003DzyzK8swU_003D2, _0023_003DzyzK8swU_003D3));
					}
					num = 0;
					LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> linkedListNode6 = Utility.CircularPrevious(linkedListNode);
					_0023_003DzN57VxTE7ZsCw.Remove(linkedListNode);
					linkedListNode = linkedListNode6;
					_0023_003DzD97cyB4_003D(linkedListNode);
					_0023_003DzD97cyB4_003D(Utility.CircularNext(linkedListNode));
				}
			}
			linkedListNode = Utility.CircularNext(linkedListNode);
		}
		while (num++ <= _0023_003DzN57VxTE7ZsCw.Count * 2 && _0023_003DzN57VxTE7ZsCw.Count > 3);
		if (_0023_003DzN57VxTE7ZsCw.Count == 3)
		{
			list.Add(new IndexTriangle(_0023_003DzN57VxTE7ZsCw.First.Value._0023_003DzyzK8swU_003D, _0023_003DzN57VxTE7ZsCw.First.Next.Value._0023_003DzyzK8swU_003D, _0023_003DzN57VxTE7ZsCw.Last.Value._0023_003DzyzK8swU_003D));
		}
		IndexTriangle[] array = list.ToArray();
		_0023_003Dzr6i__8IJUQmb_s3SzClGuC6m9bUF(_0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D, array);
		return array;
	}

	internal void _0023_003Dz5bTQ1u9UVidehQ86Hw_003D_003D(out _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[] _0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D, out IndexTriangle[] _0023_003DzXT3BRSZezblHON7QOg_003D_003D)
	{
		_0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[_0023_003DzAXtzfrJR7wBx];
		foreach (_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D item in _0023_003DzN57VxTE7ZsCw)
		{
			_0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D[item._0023_003DzyzK8swU_003D] = item;
		}
		_0023_003Dz5bTQ1u9UVidehQ86Hw_003D_003D(out Point2D[] _, out _0023_003DzXT3BRSZezblHON7QOg_003D_003D);
	}

	public void _0023_003Dz5bTQ1u9UVidehQ86Hw_003D_003D(out Point2D[] _0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D, out IndexTriangle[] _0023_003DzXT3BRSZezblHON7QOg_003D_003D)
	{
		_0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D = new Point2D[_0023_003DzAXtzfrJR7wBx];
		foreach (_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D item in _0023_003DzN57VxTE7ZsCw)
		{
			_0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D[item._0023_003DzyzK8swU_003D] = item._0023_003DzIHt45I8_003D;
		}
		_0023_003DzXT3BRSZezblHON7QOg_003D_003D = _0023_003Dz5bTQ1u9UVidehQ86Hw_003D_003D(_0023_003DzY3ahEmgbxOhjQjTWbA_003D_003D);
	}

	private void _0023_003Dzr6i__8IJUQmb_s3SzClGuC6m9bUF(Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
	{
		Utility.GetEdgesWithoutDuplicates(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length, out var edgesPerVertex);
		bool flag = true;
		while (flag)
		{
			flag = false;
			for (int i = 0; i < edgesPerVertex.Length; i++)
			{
				LinkedListNode<SharedEdge> linkedListNode = edgesPerVertex[i].First;
				int num = i;
				while (linkedListNode != null)
				{
					int mum = linkedListNode.Value.Mum;
					int dad = linkedListNode.Value.Dad;
					int v = linkedListNode.Value.V2;
					if (dad != -1)
					{
						int thirdVertex = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[mum].GetThirdVertex(num, v);
						int thirdVertex2 = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[dad].GetThirdVertex(num, v);
						if (!_0023_003Dz0vvE9AkbCx5HkBXOnQ_003D_003D(num, v, thirdVertex, thirdVertex2, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D))
						{
							_0023_003Dzp0uoJIXjIL9d(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[mum], _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[dad], num, v, thirdVertex, thirdVertex2, edgesPerVertex);
							flag = true;
						}
					}
					linkedListNode = linkedListNode.Next;
				}
			}
		}
	}

	private bool _0023_003DzLZmUBeS3VkKL<T>(LinkedList<T>[] _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D) where T : SharedEdge
	{
		for (int i = 0; i < _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D.Length; i++)
		{
			if (_0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D[i] == null)
			{
				continue;
			}
			for (LinkedListNode<T> linkedListNode = _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D[i].First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				for (LinkedListNode<T> linkedListNode2 = _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D[i].First; linkedListNode2 != null; linkedListNode2 = linkedListNode2.Next)
				{
					if (linkedListNode2 != linkedListNode && linkedListNode2.Value.V2 == linkedListNode.Value.V2)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	private bool _0023_003DzxnFL17JjsMPq<T>(LinkedList<T> _0023_003DzdMJs3G0_003D, int _0023_003Dz5Azd7L8_003D) where T : SharedEdge
	{
		for (LinkedListNode<T> linkedListNode = _0023_003DzdMJs3G0_003D.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
		{
			if (linkedListNode.Value.V2 == _0023_003Dz5Azd7L8_003D)
			{
				return true;
			}
		}
		return false;
	}

	private void _0023_003Dzp0uoJIXjIL9d(IndexTriangle _0023_003DzfikFABeXzzpL, IndexTriangle _0023_003DzQ8e3Lm5t_Y5r, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzAKYsX_Y_003D, int _0023_003DzRiQFiu0_003D, LinkedList<SharedEdge>[] _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D)
	{
		_0023_003DzfikFABeXzzpL.ReplaceVertexIndex(_0023_003Dz5Azd7L8_003D, _0023_003DzRiQFiu0_003D);
		_0023_003DzQ8e3Lm5t_Y5r.ReplaceVertexIndex(_0023_003DzffqPLNQ_003D, _0023_003DzAKYsX_Y_003D);
		Utility.GetMinMax(_0023_003DzAKYsX_Y_003D, _0023_003DzRiQFiu0_003D, out var min, out var max);
		SharedEdge sharedEdge = Utility.RemoveEdge(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D);
		if (_0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D[min] == null)
		{
			_0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D[min] = new LinkedList<SharedEdge>();
		}
		SharedEdge sharedEdge2 = new SharedEdge();
		sharedEdge2.V2 = max;
		sharedEdge2.Mum = sharedEdge.Mum;
		sharedEdge2.Dad = sharedEdge.Dad;
		_0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D[min].AddLast(new LinkedListNode<SharedEdge>(sharedEdge2));
		_0023_003DzrtUa0GKgpr6gDR8pdw_003D_003D(_0023_003DzAKYsX_Y_003D, _0023_003Dz5Azd7L8_003D, sharedEdge.Mum, sharedEdge.Dad, sharedEdge2.Dad, _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D);
		_0023_003DzrtUa0GKgpr6gDR8pdw_003D_003D(_0023_003DzffqPLNQ_003D, _0023_003DzRiQFiu0_003D, sharedEdge.Mum, sharedEdge.Dad, sharedEdge2.Mum, _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D);
	}

	private void _0023_003DzrtUa0GKgpr6gDR8pdw_003D_003D(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzbP_BhKIAOGcJ, int _0023_003DzCd5Ue2nbqYQG, int _0023_003DzEGZvwL8_003D, LinkedList<SharedEdge>[] _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D)
	{
		Utility.GetMinMax(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, out var min, out var max);
		SharedEdge edge = Utility.GetEdge(min, max, _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D);
		if (edge.Mum == _0023_003DzbP_BhKIAOGcJ || edge.Mum == _0023_003DzCd5Ue2nbqYQG)
		{
			edge.Mum = _0023_003DzEGZvwL8_003D;
		}
		else
		{
			edge.Dad = _0023_003DzEGZvwL8_003D;
		}
	}

	private bool _0023_003Dz0vvE9AkbCx5HkBXOnQ_003D_003D(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzAKYsX_Y_003D, int _0023_003DzRiQFiu0_003D, Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		double num = _0023_003Dz_OdYU2o_003D(_0023_003DzffqPLNQ_003D, _0023_003DzAKYsX_Y_003D, _0023_003Dz5Azd7L8_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D) + _0023_003Dz_OdYU2o_003D(_0023_003DzffqPLNQ_003D, _0023_003DzRiQFiu0_003D, _0023_003Dz5Azd7L8_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
		if (!(num < Math.PI))
		{
			return Utility.AreEqual(num, Math.PI, Math.PI * 2.0);
		}
		return true;
	}

	private double _0023_003Dz_OdYU2o_003D(int _0023_003DzffqPLNQ_003D, int _0023_003Dz77g161c_003D, int _0023_003Dz5Azd7L8_003D, Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		Vector2D vector2D = Vector2D.Subtract(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzffqPLNQ_003D], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz77g161c_003D]);
		Vector2D vector2D2 = Vector2D.Subtract(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz5Azd7L8_003D], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz77g161c_003D]);
		vector2D.Normalize();
		vector2D2.Normalize();
		return Vector2D.AngleBetween(vector2D, vector2D2);
	}

	internal void _0023_003Dz5bTQ1u9UVidehQ86Hw_003D_003D(out IndexTriangle[] _0023_003DzXT3BRSZezblHON7QOg_003D_003D)
	{
		_0023_003Dz5bTQ1u9UVidehQ86Hw_003D_003D(out Point2D[] _, out _0023_003DzXT3BRSZezblHON7QOg_003D_003D);
	}

	public Mesh _0023_003Dz5bTQ1u9UVidehQ86Hw_003D_003D(Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
	{
		Mesh mesh = new Mesh();
		mesh.Vertices = new Point3D[_0023_003DzAXtzfrJR7wBx];
		if (_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D == Mesh.natureType.MulticolorPlain || _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D == Mesh.natureType.MulticolorSmooth)
		{
			foreach (_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D item in _0023_003DzN57VxTE7ZsCw)
			{
				mesh.Vertices[item._0023_003DzyzK8swU_003D] = (Point3D)item._0023_003DzIHt45I8_003D;
			}
		}
		else
		{
			foreach (_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D item2 in _0023_003DzN57VxTE7ZsCw)
			{
				mesh.Vertices[item2._0023_003DzyzK8swU_003D] = new Point3D(item2._0023_003DzIHt45I8_003D.X, item2._0023_003DzIHt45I8_003D.Y);
			}
		}
		Point2D[] vertices = mesh.Vertices;
		IndexTriangle[] array = _0023_003Dz5bTQ1u9UVidehQ86Hw_003D_003D(vertices);
		mesh._triangles = new IndexTriangle[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			IndexTriangle indexTriangle = array[i];
			mesh.Triangles[i] = Utility.CreateTriangle(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
		}
		return mesh;
	}

	private static bool _0023_003DzzWJrWcuv5B_0024DZ6Qtew_003D_003D(double _0023_003DzuTkHiyI_003D, double _0023_003Dz0KVPVlc_003D, double _0023_003Dz3YfTAqg_003D, double _0023_003DzpilgH4E_003D, double _0023_003DzRFb1SGo_003D, double _0023_003Dz8qV981c_003D, double _0023_003DzuPuPztg_003D, double _0023_003Dz4693IIk_003D)
	{
		double[] array = new double[2]
		{
			_0023_003DzuPuPztg_003D - _0023_003Dz3YfTAqg_003D,
			_0023_003Dz4693IIk_003D - _0023_003DzpilgH4E_003D
		};
		double[] array2 = new double[2]
		{
			_0023_003DzRFb1SGo_003D - _0023_003Dz3YfTAqg_003D,
			_0023_003Dz8qV981c_003D - _0023_003DzpilgH4E_003D
		};
		double[] array3 = new double[2]
		{
			_0023_003DzuTkHiyI_003D - _0023_003Dz3YfTAqg_003D,
			_0023_003Dz0KVPVlc_003D - _0023_003DzpilgH4E_003D
		};
		double num = array[0] * array[0] + array[1] * array[1];
		double num2 = array[0] * array2[0] + array[1] * array2[1];
		double num3 = array[0] * array3[0] + array[1] * array3[1];
		double num4 = array2[0] * array2[0] + array2[1] * array2[1];
		double num5 = array2[0] * array3[0] + array2[1] * array3[1];
		double num6 = 1.0 / (num * num4 - num2 * num2);
		double num7 = (num4 * num3 - num2 * num5) * num6;
		double num8 = (num * num5 - num2 * num3) * num6;
		if (num7 >= 0.0 && num8 >= 0.0 && num7 + num8 <= 1.0)
		{
			return true;
		}
		return false;
	}

	private static int _0023_003DzFTCQCq8yZivJvv4NfA_003D_003D(ref int _0023_003DzxN8ClGE_003D, IList<IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>> _0023_003Dzcv8o5nO25OjS)
	{
		double num = double.MinValue;
		int result = -1;
		for (int i = 0; i < _0023_003Dzcv8o5nO25OjS.Count; i++)
		{
			_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzMlCq3wk_003D;
			int num2 = _0023_003DzWOkzRlCGjXjepYNodw_003D_003D(_0023_003Dzcv8o5nO25OjS[i], out _0023_003DzMlCq3wk_003D);
			if ((double)_0023_003DzMlCq3wk_003D._0023_003DzFuXfk4k_003D > num)
			{
				num = _0023_003DzMlCq3wk_003D._0023_003DzFuXfk4k_003D;
				result = i;
				_0023_003DzxN8ClGE_003D = num2;
			}
		}
		return result;
	}

	private static int _0023_003DzWOkzRlCGjXjepYNodw_003D_003D(IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003DzdEvMFOw_003D, out _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzMlCq3wk_003D)
	{
		int num = -1;
		double num2 = double.MinValue;
		int count = _0023_003DzdEvMFOw_003D.Count;
		for (int i = 0; i < count - 1; i++)
		{
			if ((double)_0023_003DzdEvMFOw_003D[i]._0023_003DzFuXfk4k_003D > num2)
			{
				num2 = _0023_003DzdEvMFOw_003D[i]._0023_003DzFuXfk4k_003D;
				num = i;
			}
		}
		_0023_003DzMlCq3wk_003D = _0023_003DzdEvMFOw_003D[num];
		return num;
	}

	private void _0023_003DzazmHqjCNiFpk4QoKuA_003D_003D()
	{
		LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> linkedListNode = _0023_003DzN57VxTE7ZsCw.First;
		do
		{
			_0023_003DzD97cyB4_003D(linkedListNode);
			linkedListNode = linkedListNode.Next;
		}
		while (linkedListNode != null);
	}

	private void _0023_003DzD97cyB4_003D(LinkedListNode<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003DzoMNiNRw_003D)
	{
		_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D value = Utility.CircularPrevious(_0023_003DzoMNiNRw_003D).Value;
		_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D value2 = Utility.CircularNext(_0023_003DzoMNiNRw_003D).Value;
		double[] array = new double[2]
		{
			_0023_003DzoMNiNRw_003D.Value._0023_003DzFuXfk4k_003D - value._0023_003DzFuXfk4k_003D,
			_0023_003DzoMNiNRw_003D.Value._0023_003DzZ_0024Wvtoc_003D - value._0023_003DzZ_0024Wvtoc_003D
		};
		double[] array2 = new double[2]
		{
			value2._0023_003DzFuXfk4k_003D - _0023_003DzoMNiNRw_003D.Value._0023_003DzFuXfk4k_003D,
			value2._0023_003DzZ_0024Wvtoc_003D - _0023_003DzoMNiNRw_003D.Value._0023_003DzZ_0024Wvtoc_003D
		};
		double y = array[0] * array2[1] - array[1] * array2[0];
		double x = array[0] * array2[0] + array[1] * array2[1];
		double num = Math.Atan2(y, x);
		if (num < 0.0 || Math.Abs(num) < Utility._0023_003DzheSR8QM7q9ya)
		{
			_0023_003DzoMNiNRw_003D.Value._0023_003DzWy_0024UOU65OoM7 = true;
		}
		else
		{
			_0023_003DzoMNiNRw_003D.Value._0023_003DzWy_0024UOU65OoM7 = false;
		}
	}

	public void _0023_003DzO2Tredg_003D(string _0023_003Dzg5oC_Hs_003D, IList<Point2D> _0023_003Dz_SqBXz8_003D, IList<IList<Point2D>> _0023_003DzWaFlkhfmYCja)
	{
		XmlTextWriter xmlTextWriter = new XmlTextWriter(_0023_003Dzg5oC_Hs_003D, null);
		xmlTextWriter.WriteStartDocument(standalone: true);
		xmlTextWriter.Formatting = Formatting.Indented;
		xmlTextWriter.Indentation = 2;
		xmlTextWriter.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976447));
		_0023_003DzwUZF5OA_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653398), _0023_003Dz_SqBXz8_003D, xmlTextWriter);
		xmlTextWriter.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958671));
		foreach (IList<Point2D> item in _0023_003DzWaFlkhfmYCja)
		{
			_0023_003DzwUZF5OA_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653378), item, xmlTextWriter);
		}
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.Close();
	}

	internal void _0023_003DzO2Tredg_003D(string _0023_003Dzg5oC_Hs_003D, List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> _0023_003Dz_SqBXz8_003D, List<List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D>> _0023_003DzWaFlkhfmYCja)
	{
		XmlTextWriter xmlTextWriter = new XmlTextWriter(_0023_003Dzg5oC_Hs_003D, null);
		xmlTextWriter.WriteStartDocument(standalone: true);
		xmlTextWriter.Formatting = Formatting.Indented;
		xmlTextWriter.Indentation = 2;
		xmlTextWriter.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976447));
		_0023_003DzwUZF5OA_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653398), _0023_003Dz_SqBXz8_003D, xmlTextWriter);
		xmlTextWriter.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958671));
		foreach (List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> item in _0023_003DzWaFlkhfmYCja)
		{
			_0023_003DzwUZF5OA_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653378), item, xmlTextWriter);
		}
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.Close();
	}

	private void _0023_003Dz7qDp_fk_003D(string _0023_003Dzg5oC_Hs_003D, out Point2D[] _0023_003Dz_SqBXz8_003D, out Point2D[][] _0023_003DzWaFlkhfmYCja)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(_0023_003Dzg5oC_Hs_003D);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653398));
		_0023_003Dz_SqBXz8_003D = _0023_003DzsaDs2uY_003D(elementsByTagName[0].ChildNodes);
		elementsByTagName = xmlDocument.GetElementsByTagName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958671));
		_0023_003DzWaFlkhfmYCja = new Point2D[elementsByTagName[0].ChildNodes.Count][];
		for (int i = 0; i < elementsByTagName[0].ChildNodes.Count; i++)
		{
			XmlNode xmlNode = elementsByTagName[0].ChildNodes[i];
			_0023_003DzWaFlkhfmYCja[i] = _0023_003DzsaDs2uY_003D(xmlNode.ChildNodes);
		}
	}

	private Point2D[] _0023_003DzsaDs2uY_003D(XmlNodeList _0023_003DzcDEsV8s_003D)
	{
		List<Point2D> list = new List<Point2D>();
		foreach (XmlNode item in _0023_003DzcDEsV8s_003D)
		{
			list.Add(_0023_003DzEeKHg2ny2gTe(item));
		}
		return list.ToArray();
	}

	private void _0023_003DzwUZF5OA_003D(string _0023_003DzPkGjh4I_003D, IEnumerable<Point2D> _0023_003Dz_SqBXz8_003D, XmlTextWriter _0023_003DzDdJAEBo_003D)
	{
		_0023_003DzDdJAEBo_003D.WriteStartElement(_0023_003DzPkGjh4I_003D);
		foreach (Point2D item in _0023_003Dz_SqBXz8_003D)
		{
			_0023_003Dz5_0024zXIxEyAXE5(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987288), item, _0023_003DzDdJAEBo_003D);
		}
		_0023_003DzDdJAEBo_003D.WriteEndElement();
	}

	private void _0023_003DzwUZF5OA_003D(string _0023_003DzPkGjh4I_003D, List<_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D> _0023_003Dz_SqBXz8_003D, XmlTextWriter _0023_003DzDdJAEBo_003D)
	{
		_0023_003DzDdJAEBo_003D.WriteStartElement(_0023_003DzPkGjh4I_003D);
		foreach (_0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D item in _0023_003Dz_SqBXz8_003D)
		{
			_0023_003DzsVWNZ76Sq7DE(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302987288), item, _0023_003DzDdJAEBo_003D);
		}
		_0023_003DzDdJAEBo_003D.WriteEndElement();
	}

	private void _0023_003Dz5_0024zXIxEyAXE5(string _0023_003DzS_00246o7tc_003D, Point2D _0023_003DzMlCq3wk_003D, XmlTextWriter _0023_003DzDdJAEBo_003D)
	{
		_0023_003DzDdJAEBo_003D.WriteStartElement(_0023_003DzS_00246o7tc_003D);
		_0023_003DzrfMfb4c_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981817), _0023_003DzMlCq3wk_003D.X, _0023_003DzDdJAEBo_003D);
		_0023_003DzrfMfb4c_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912525), _0023_003DzMlCq3wk_003D.Y, _0023_003DzDdJAEBo_003D);
		_0023_003DzDdJAEBo_003D.WriteEndElement();
	}

	private void _0023_003DzsVWNZ76Sq7DE(string _0023_003DzS_00246o7tc_003D, _0023_003DzW0_0024Wi_4SIrOH6Bj5KoRvfPo_003D _0023_003DzMlCq3wk_003D, XmlTextWriter _0023_003DzDdJAEBo_003D)
	{
		_0023_003DzDdJAEBo_003D.WriteStartElement(_0023_003DzS_00246o7tc_003D);
		_0023_003DzrfMfb4c_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302981817), _0023_003DzMlCq3wk_003D._0023_003Dzyk2fsPo_003D, _0023_003DzDdJAEBo_003D);
		_0023_003DzrfMfb4c_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912525), _0023_003DzMlCq3wk_003D._0023_003DzvXOLtKg_003D, _0023_003DzDdJAEBo_003D);
		_0023_003DzDdJAEBo_003D.WriteEndElement();
	}

	private void _0023_003DzrfMfb4c_003D(string _0023_003DzPkGjh4I_003D, double _0023_003DzJ_0024_IwTI_003D, XmlTextWriter _0023_003DzDdJAEBo_003D)
	{
		_0023_003DzDdJAEBo_003D.WriteStartElement(_0023_003DzPkGjh4I_003D);
		_0023_003DzDdJAEBo_003D.WriteValue(_0023_003DzJ_0024_IwTI_003D);
		_0023_003DzDdJAEBo_003D.WriteEndElement();
	}

	private Point2D _0023_003DzEeKHg2ny2gTe(XmlNode _0023_003DzRXJWLHs_003D)
	{
		double x = XmlConvert.ToDouble(_0023_003DzRXJWLHs_003D.FirstChild.InnerText);
		double y = 0.0;
		if (_0023_003DzRXJWLHs_003D.FirstChild.NextSibling != null)
		{
			y = XmlConvert.ToDouble(_0023_003DzRXJWLHs_003D.FirstChild.NextSibling.InnerText);
		}
		return new Point2D(x, y);
	}
}
