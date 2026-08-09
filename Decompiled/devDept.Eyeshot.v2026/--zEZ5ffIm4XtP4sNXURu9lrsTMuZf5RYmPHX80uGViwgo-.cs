using System.Collections.Generic;
using System.Linq;
using System.Text;
using devDept;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Milling;
using devDept.Geometry;

internal sealed class _0023_003DzEZ5ffIm4XtP4sNXURu9lrsTMuZf5RYmPHX80uGViwgo_0024
{
	private readonly IList<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> _0023_003DzDVkiJKY_003D;

	private readonly Machining _0023_003Dz1Sv2JybWYY_0024FY71nuQ_003D_003D;

	private readonly GeometryBase _0023_003DzTXjLRCo_003D;

	private readonly Setup _0023_003DzXBmvcLs_003D;

	private readonly cutDirectionType _0023_003DzyDWPXYcyjDHg;

	private readonly double _0023_003Dz3BT45YQ_003D;

	private readonly double _0023_003Dz659ujSHDsJXE;

	private readonly StringBuilder _0023_003DzVy4cXgY_003D;

	public _0023_003DzEZ5ffIm4XtP4sNXURu9lrsTMuZf5RYmPHX80uGViwgo_0024(IList<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> _0023_003DzfNi7d4A_003D, Machining _0023_003DzoTbxiuVd4e2jgBKPkA_003D_003D, GeometryBase _0023_003DzyXmKbtw_003D, Setup _0023_003Dz9cS3uG0_003D, StringBuilder _0023_003DzqmF8XJ0_003D = null)
		: this(_0023_003DzfNi7d4A_003D, _0023_003DzoTbxiuVd4e2jgBKPkA_003D_003D.CutDirectionMode, _0023_003DzoTbxiuVd4e2jgBKPkA_003D_003D.Feed, _0023_003DzoTbxiuVd4e2jgBKPkA_003D_003D.Speed)
	{
		_0023_003Dz1Sv2JybWYY_0024FY71nuQ_003D_003D = _0023_003DzoTbxiuVd4e2jgBKPkA_003D_003D;
		_0023_003DzTXjLRCo_003D = _0023_003DzyXmKbtw_003D;
		_0023_003DzXBmvcLs_003D = _0023_003Dz9cS3uG0_003D;
		_0023_003DzVy4cXgY_003D = _0023_003DzqmF8XJ0_003D;
	}

	public _0023_003DzEZ5ffIm4XtP4sNXURu9lrsTMuZf5RYmPHX80uGViwgo_0024(IList<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> _0023_003DzfNi7d4A_003D, cutDirectionType _0023_003DzCIpOJSfcMrGo, double _0023_003Dz4w6tHu4_003D = 0.0, double _0023_003Dz1v8WebVg_QJi = 0.0)
	{
		_0023_003DzDVkiJKY_003D = _0023_003DzfNi7d4A_003D;
		_0023_003DzyDWPXYcyjDHg = _0023_003DzCIpOJSfcMrGo;
		_0023_003Dz3BT45YQ_003D = _0023_003Dz4w6tHu4_003D;
		_0023_003Dz659ujSHDsJXE = _0023_003Dz1v8WebVg_QJi;
	}

	private void _0023_003Dz3lz5SKY_003D(string _0023_003DzBWbkhlEI4CRJ)
	{
		_0023_003DzVy4cXgY_003D?.AppendLine(_0023_003DzBWbkhlEI4CRJ);
	}

	private bool _0023_003DzOZwYBCI_003D(_0023_003DzEZ5ffIm4XtP4sNXURu9lrinvBTIMLCfe3lEU6wRXuTUl _0023_003DzS3WVCr8Gsb__0024, int _0023_003DzloqnalNL0dcq)
	{
		for (int i = 0; i < _0023_003DzDVkiJKY_003D.Count; i++)
		{
			_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2 = _0023_003DzDVkiJKY_003D[i];
			if (i == _0023_003DzloqnalNL0dcq)
			{
				if (!_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003DzlPrfzfc_003D(_0023_003DzS3WVCr8Gsb__0024, _0023_003DzyDWPXYcyjDHg, 1E-06))
				{
					return false;
				}
			}
			else if (_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003Dz9h5MY_A_003D(_0023_003DzS3WVCr8Gsb__0024._0023_003DzDKVESdcjwYUE))
			{
				return false;
			}
		}
		return true;
	}

	private bool _0023_003Dzr7zzVtbAjPGE<T>(bool _0023_003DzEVs_zpA_003D, ref T _0023_003DzK7ymDU4_003D) where T : _0023_003DzEZ5ffIm4XtP4sNXURu9lrinvBTIMLCfe3lEU6wRXuTUl
	{
		if (_0023_003DzEVs_zpA_003D)
		{
			return true;
		}
		_0023_003DzK7ymDU4_003D = null;
		return false;
	}

	private bool _0023_003DzOZwYBCI_003D(Ramp _0023_003Dz7A1N3G1lY62A, _0023_003DzffJpiSDBgZf8XoMYriAgy6yOFLX95VOWMvylykc5q4Hm _0023_003DzS3WVCr8Gsb__0024, int _0023_003DzloqnalNL0dcq, out _0023_003Dz0JIgxQpsDZbf4VcHqAU5fSFJJQQX8QJVWaIXn9RwP83t _0023_003Dz4pSfRSE2lse6)
	{
		_0023_003Dz4pSfRSE2lse6 = _0023_003Dz7A1N3G1lY62A._0023_003Dzdlp53MQ_003D(_0023_003DzS3WVCr8Gsb__0024, _0023_003Dz659ujSHDsJXE, _0023_003Dz3BT45YQ_003D, _0023_003DzyDWPXYcyjDHg);
		return _0023_003Dzr7zzVtbAjPGE(_0023_003DzOZwYBCI_003D(_0023_003Dz4pSfRSE2lse6, _0023_003DzloqnalNL0dcq), ref _0023_003Dz4pSfRSE2lse6);
	}

	private bool _0023_003DzOZwYBCI_003D(Lead _0023_003DzS3WVCr8Gsb__0024, int _0023_003DzloqnalNL0dcq, int _0023_003DzGaSzuaHRZ_0024fm, bool _0023_003DzdnLFZC6dNqmw, out _0023_003DzffJpiSDBgZf8XoMYriAgy6yOFLX95VOWMvylykc5q4Hm _0023_003DznxGIjQk_003D)
	{
		_0023_003DznxGIjQk_003D = _0023_003DzS3WVCr8Gsb__0024._0023_003Dzdlp53MQ_003D(_0023_003DzDVkiJKY_003D[_0023_003DzloqnalNL0dcq], _0023_003DzGaSzuaHRZ_0024fm, _0023_003DzdnLFZC6dNqmw, _0023_003Dz659ujSHDsJXE, _0023_003Dz3BT45YQ_003D, _0023_003DzyDWPXYcyjDHg);
		return _0023_003Dzr7zzVtbAjPGE(_0023_003DzOZwYBCI_003D(_0023_003DznxGIjQk_003D, _0023_003DzloqnalNL0dcq), ref _0023_003DznxGIjQk_003D);
	}

	private bool _0023_003DzOZwYBCI_003D(Ramp _0023_003DzS3WVCr8Gsb__0024, int _0023_003DzloqnalNL0dcq, int _0023_003DzGaSzuaHRZ_0024fm, bool _0023_003DzdnLFZC6dNqmw, out _0023_003Dz0JIgxQpsDZbf4VcHqAU5fSFJJQQX8QJVWaIXn9RwP83t _0023_003DznxGIjQk_003D)
	{
		_0023_003DznxGIjQk_003D = _0023_003DzS3WVCr8Gsb__0024._0023_003Dzdlp53MQ_003D(_0023_003DzDVkiJKY_003D[_0023_003DzloqnalNL0dcq], _0023_003DzGaSzuaHRZ_0024fm, _0023_003DzdnLFZC6dNqmw, _0023_003Dz659ujSHDsJXE, _0023_003Dz3BT45YQ_003D, _0023_003DzyDWPXYcyjDHg);
		return _0023_003Dzr7zzVtbAjPGE(_0023_003DzOZwYBCI_003D(_0023_003DznxGIjQk_003D, _0023_003DzloqnalNL0dcq), ref _0023_003DznxGIjQk_003D);
	}

	public Toolpath.Motion[] _0023_003DzFnWY1A6cHJ79(int _0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D, Lead _0023_003DzOm40_LfQ2mOP, Lead _0023_003Dzl8Gmj76S15XO, Ramp _0023_003Dz7A1N3G1lY62A, Ramp _0023_003DzgU3T3M_0024teV0g, bool _0023_003DzABRv2QAQiuFt)
	{
		_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2 = _0023_003DzDVkiJKY_003D[_0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D];
		bool flag = _0023_003DzOm40_LfQ2mOP != null && _0023_003DzOm40_LfQ2mOP == _0023_003Dzl8Gmj76S15XO;
		if (flag)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995778));
		}
		_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003DzFsatqHw_003D = Utility.RemoveDuplicates(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003DzFsatqHw_003D);
		Point3D[] _0023_003DzFsatqHw_003D = _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003DzFsatqHw_003D;
		List<Toolpath.Motion> list = new List<Toolpath.Motion>(_0023_003DzFsatqHw_003D.Length - 1);
		bool flag2 = Machining._0023_003DzySfSteI_003D(_0023_003DzFsatqHw_003D);
		int? num = null;
		int? num2 = null;
		_0023_003DzffJpiSDBgZf8XoMYriAgy6yOFLX95VOWMvylykc5q4Hm _0023_003DznxGIjQk_003D = null;
		_0023_003DzffJpiSDBgZf8XoMYriAgy6yOFLX95VOWMvylykc5q4Hm _0023_003DznxGIjQk_003D2 = null;
		_0023_003Dz0JIgxQpsDZbf4VcHqAU5fSFJJQQX8QJVWaIXn9RwP83t _0023_003Dz4pSfRSE2lse = null;
		if (flag2)
		{
			int num3 = 1;
			for (int i = 0; i <= num3; i++)
			{
				for (int j = 0; j < _0023_003DzFsatqHw_003D.Length - 1; j++)
				{
					if (_0023_003DzOm40_LfQ2mOP != null && !_0023_003DzOZwYBCI_003D(_0023_003DzOm40_LfQ2mOP, _0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D, j, _0023_003DzdnLFZC6dNqmw: true, out _0023_003DznxGIjQk_003D))
					{
						continue;
					}
					int num4 = j;
					if (num4 == 0 && !_0023_003DzABRv2QAQiuFt)
					{
						num4 = _0023_003DzFsatqHw_003D.Length - 1;
					}
					if (flag && _0023_003DzABRv2QAQiuFt)
					{
						_0023_003DznxGIjQk_003D2 = _0023_003Dzl8Gmj76S15XO._0023_003Dzdlp53MQ_003D(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2, num4, _0023_003DzABRv2QAQiuFt, _0023_003Dz659ujSHDsJXE, _0023_003Dz3BT45YQ_003D, _0023_003DzyDWPXYcyjDHg);
					}
					else if (_0023_003Dzl8Gmj76S15XO != null && !_0023_003DzOZwYBCI_003D(_0023_003Dzl8Gmj76S15XO, _0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D, num4, _0023_003DzABRv2QAQiuFt, out _0023_003DznxGIjQk_003D2))
					{
						continue;
					}
					if (!num2.HasValue)
					{
						num2 = j;
					}
					if (_0023_003Dz7A1N3G1lY62A != null)
					{
						if (_0023_003DzOm40_LfQ2mOP != null)
						{
							if (!_0023_003DzOZwYBCI_003D(_0023_003Dz7A1N3G1lY62A, _0023_003DznxGIjQk_003D, _0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D, out _0023_003Dz4pSfRSE2lse))
							{
								continue;
							}
						}
						else if (!_0023_003DzOZwYBCI_003D(_0023_003Dz7A1N3G1lY62A, _0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D, j, _0023_003DzdnLFZC6dNqmw: true, out _0023_003Dz4pSfRSE2lse))
						{
							continue;
						}
					}
					num = j;
					break;
				}
				if (num.HasValue)
				{
					break;
				}
				_0023_003DzcDUpHOx0W4TWuleBkg_003D_003D(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2);
				_0023_003DzFsatqHw_003D = _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003DzFsatqHw_003D;
			}
		}
		else
		{
			num = 0;
			int _0023_003DzGaSzuaHRZ_0024fm = _0023_003DzFsatqHw_003D.Length - 1;
			if ((_0023_003DzOm40_LfQ2mOP != null && !_0023_003DzOZwYBCI_003D(_0023_003DzOm40_LfQ2mOP, _0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D, num.Value, _0023_003DzdnLFZC6dNqmw: true, out _0023_003DznxGIjQk_003D)) || (_0023_003Dzl8Gmj76S15XO != null && !_0023_003DzOZwYBCI_003D(_0023_003Dzl8Gmj76S15XO, _0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D, _0023_003DzGaSzuaHRZ_0024fm, _0023_003DzdnLFZC6dNqmw: false, out _0023_003DznxGIjQk_003D2)))
			{
				num = null;
			}
			else if (_0023_003Dz7A1N3G1lY62A != null && ((_0023_003DzOm40_LfQ2mOP != null && !_0023_003DzOZwYBCI_003D(_0023_003Dz7A1N3G1lY62A, _0023_003DznxGIjQk_003D, _0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D, out _0023_003Dz4pSfRSE2lse)) || (_0023_003DzOm40_LfQ2mOP == null && !_0023_003DzOZwYBCI_003D(_0023_003Dz7A1N3G1lY62A, _0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D, num.Value, _0023_003DzdnLFZC6dNqmw: true, out _0023_003Dz4pSfRSE2lse))))
			{
				num = null;
				num2 = 0;
			}
		}
		if (!num.HasValue)
		{
			if (!num2.HasValue)
			{
				_0023_003Dz3lz5SKY_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995909));
				if (_0023_003Dz7A1N3G1lY62A != null)
				{
					_0023_003Dz4pSfRSE2lse = _0023_003DzgU3T3M_0024teV0g._0023_003Dzdlp53MQ_003D(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2, 0, _0023_003DzdnLFZC6dNqmw: true, _0023_003Dz659ujSHDsJXE, _0023_003Dz3BT45YQ_003D, _0023_003DzyDWPXYcyjDHg);
				}
				num = 0;
			}
			else
			{
				_0023_003Dz3lz5SKY_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995853));
				int value = num2.Value;
				if (_0023_003DzOm40_LfQ2mOP != null)
				{
					_0023_003DzOZwYBCI_003D(_0023_003DzOm40_LfQ2mOP, _0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D, value, _0023_003DzdnLFZC6dNqmw: true, out _0023_003DznxGIjQk_003D);
				}
				if (_0023_003Dzl8Gmj76S15XO != null)
				{
					int _0023_003DzGaSzuaHRZ_0024fm2 = ((!flag2 || (value == 0 && !_0023_003DzABRv2QAQiuFt)) ? (_0023_003DzFsatqHw_003D.Length - 1) : value);
					_0023_003DzOZwYBCI_003D(_0023_003Dzl8Gmj76S15XO, _0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D, _0023_003DzGaSzuaHRZ_0024fm2, _0023_003DzABRv2QAQiuFt && flag2, out _0023_003DznxGIjQk_003D2);
				}
				_0023_003Dz4pSfRSE2lse = ((_0023_003DzOm40_LfQ2mOP != null) ? _0023_003DzgU3T3M_0024teV0g._0023_003Dzdlp53MQ_003D(_0023_003DznxGIjQk_003D, _0023_003Dz659ujSHDsJXE, _0023_003Dz3BT45YQ_003D, _0023_003DzyDWPXYcyjDHg) : _0023_003DzgU3T3M_0024teV0g._0023_003Dzdlp53MQ_003D(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2, value, _0023_003DzdnLFZC6dNqmw: true, _0023_003Dz659ujSHDsJXE, _0023_003Dz3BT45YQ_003D, _0023_003DzyDWPXYcyjDHg));
				num = num2;
			}
		}
		if (_0023_003Dz4pSfRSE2lse != null)
		{
			list.AddRange(_0023_003Dz4pSfRSE2lse._0023_003DzRwuOq0Upg_0024zq);
		}
		bool flag3 = _0023_003DzTXjLRCo_003D is Geometry3D && _0023_003Dz1Sv2JybWYY_0024FY71nuQ_003D_003D is Machining3D { boundary: not null } && _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2 is _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D;
		if (_0023_003DznxGIjQk_003D != null)
		{
			double z = _0023_003DznxGIjQk_003D._0023_003DzRwuOq0Upg_0024zq.Last().EndPoint.Z;
			if (flag3 && _0023_003DznxGIjQk_003D._0023_003Dz5M9agOPDMhxd((Geometry3D)_0023_003DzTXjLRCo_003D, _0023_003DzXBmvcLs_003D, (Machining3D)_0023_003Dz1Sv2JybWYY_0024FY71nuQ_003D_003D, z, out var _0023_003DzzF0HA1IaMpzg))
			{
				double z2 = _0023_003DzzF0HA1IaMpzg[0].StartPoint.Z - _0023_003DznxGIjQk_003D._0023_003DzRwuOq0Upg_0024zq[0].StartPoint.Z;
				if (_0023_003Dz4pSfRSE2lse != null)
				{
					Toolpath.Motion[] _0023_003DzRwuOq0Upg_0024zq = _0023_003Dz4pSfRSE2lse._0023_003DzRwuOq0Upg_0024zq;
					for (int k = 0; k < _0023_003DzRwuOq0Upg_0024zq.Length; k++)
					{
						_0023_003DzRwuOq0Upg_0024zq[k]._0023_003DzUNQ_t5U_003D(new Translation(0.0, 0.0, z2));
					}
				}
				list.AddRange(_0023_003DzzF0HA1IaMpzg);
			}
			else
			{
				list.AddRange(_0023_003DznxGIjQk_003D._0023_003DzRwuOq0Upg_0024zq);
			}
		}
		list.AddRange(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003DzRwuOq0Upg_0024zq(_0023_003Dz659ujSHDsJXE, _0023_003Dz3BT45YQ_003D, num.Value));
		if (_0023_003DznxGIjQk_003D2 != null)
		{
			double z3 = _0023_003DznxGIjQk_003D2._0023_003DzRwuOq0Upg_0024zq[0].StartPoint.Z;
			if (flag3 && _0023_003DznxGIjQk_003D2._0023_003Dz5M9agOPDMhxd((Geometry3D)_0023_003DzTXjLRCo_003D, _0023_003DzXBmvcLs_003D, (Machining3D)_0023_003Dz1Sv2JybWYY_0024FY71nuQ_003D_003D, z3, out var _0023_003DzzF0HA1IaMpzg2))
			{
				list.AddRange(_0023_003DzzF0HA1IaMpzg2);
			}
			else
			{
				list.AddRange(_0023_003DznxGIjQk_003D2._0023_003DzRwuOq0Upg_0024zq);
			}
		}
		return list.ToArray();
	}

	private static void _0023_003DzcDUpHOx0W4TWuleBkg_003D_003D(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D _0023_003Dz06A5WivSSyUp)
	{
		Point3D[] array = new Point3D[_0023_003Dz06A5WivSSyUp._0023_003DzFsatqHw_003D.Length * 2 - 1];
		for (int i = 0; i < _0023_003Dz06A5WivSSyUp._0023_003DzFsatqHw_003D.Length; i++)
		{
			array[i * 2] = _0023_003Dz06A5WivSSyUp._0023_003DzFsatqHw_003D[i];
			if (i < _0023_003Dz06A5WivSSyUp._0023_003DzFsatqHw_003D.Length - 1)
			{
				array[i * 2 + 1] = (_0023_003Dz06A5WivSSyUp._0023_003DzFsatqHw_003D[i] + _0023_003Dz06A5WivSSyUp._0023_003DzFsatqHw_003D[i + 1]) / 2.0;
			}
		}
		_0023_003Dz06A5WivSSyUp._0023_003DzFsatqHw_003D = array;
	}
}
