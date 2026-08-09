using System;
using System.Collections.Generic;
using devDept.Geometry.ConstraintSolver;

internal sealed class _0023_003DzOtmnu1oqpAlb4IU4A9aAG0CS6X9M
{
	private sealed class _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D
	{
		public string _0023_003DzS_00246o7tc_003D;

		internal bool _0023_003DzP6lZKQWQ36FllnkfeA_003D_003D(Param _0023_003DzB68dg9Q_003D)
		{
			return _0023_003DzB68dg9Q_003D.name == _0023_003DzS_00246o7tc_003D;
		}
	}

	private Dictionary<string, Exp.Op> _0023_003DzCvYTxLU_003D = new Dictionary<string, Exp.Op>
	{
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655942),
			Exp.Op.Sin
		},
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655952),
			Exp.Op.Cos
		},
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655930),
			Exp.Op.Atan2
		},
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655910),
			Exp.Op.Sqr
		},
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655920),
			Exp.Op.Sqrt
		},
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655897),
			Exp.Op.Abs
		},
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655875),
			Exp.Op.Sign
		},
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655888),
			Exp.Op.ACos
		},
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655609),
			Exp.Op.Cos
		},
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655590),
			Exp.Op.Exp
		},
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655600),
			Exp.Op.Sinh
		},
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655577),
			Exp.Op.Cosh
		},
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655558),
			Exp.Op.SFres
		},
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655538),
			Exp.Op.CFres
		}
	};

	private Dictionary<char, Exp.Op> _0023_003DzshE3tZQ_003D = new Dictionary<char, Exp.Op>
	{
		{
			'+',
			Exp.Op.Add
		},
		{
			'-',
			Exp.Op.Sub
		},
		{
			'*',
			Exp.Op.Mul
		},
		{
			'/',
			Exp.Op.Div
		}
	};

	private Dictionary<string, double> _0023_003DzyfK4cmd9941Tl5ST1w_003D_003D = new Dictionary<string, double>
	{
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655550),
			Math.PI
		},
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655525),
			Math.E
		}
	};

	private string _0023_003DznC95EKCcZV69;

	private int _0023_003DzyzK8swU_003D;

	public List<Param> _0023_003DzBlBnvuA_003D = new List<Param>();

	public _0023_003DzOtmnu1oqpAlb4IU4A9aAG0CS6X9M(string _0023_003Dz_0024n2nrac_003D)
	{
		_0023_003DznC95EKCcZV69 = _0023_003Dz_0024n2nrac_003D;
	}

	public static void _0023_003Dz1ur9dZs_003D()
	{
		foreach (string item in new List<string>
		{
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655533),
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655513),
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655497),
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655740),
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655725),
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655682),
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655668),
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655640),
			_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656384)
		})
		{
			new _0023_003DzOtmnu1oqpAlb4IU4A9aAG0CS6X9M(item)._0023_003DzY15vWMs_003D();
		}
		foreach (KeyValuePair<string, double> item2 in new Dictionary<string, double>
		{
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656307),
				6.0
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656319),
				3.0
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656299),
				0.0
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656282),
				4.0
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656264),
				4.0
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656502),
				2.0
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656484),
				20.0
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656468),
				20.0
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656454),
				30.0
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656440),
				30.0
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656430),
				1.0
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656409),
				1.0
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655550),
				Math.PI
			},
			{
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655525),
				Math.E
			}
		})
		{
			new _0023_003DzOtmnu1oqpAlb4IU4A9aAG0CS6X9M(item2.Key)._0023_003DzY15vWMs_003D()._0023_003DzBUjqlpM_003D();
			_ = item2.Value;
		}
	}

	public void _0023_003DzFYv8Smo_003D(string _0023_003Dz_0024n2nrac_003D)
	{
		_0023_003DznC95EKCcZV69 = _0023_003Dz_0024n2nrac_003D;
		_0023_003DzyzK8swU_003D = 0;
	}

	private char _0023_003DzFMHDKeM9S9Xg()
	{
		return _0023_003DznC95EKCcZV69[_0023_003DzyzK8swU_003D];
	}

	private bool _0023_003DzrTyJQLU_003D(char _0023_003Dzt_m8zV0_003D)
	{
		return char.IsWhiteSpace(_0023_003Dzt_m8zV0_003D);
	}

	private bool _0023_003Dz0D2_CHE_003D(char _0023_003Dzt_m8zV0_003D)
	{
		return char.IsDigit(_0023_003Dzt_m8zV0_003D);
	}

	private bool _0023_003DzOIfrLpo_003D(char _0023_003Dzt_m8zV0_003D)
	{
		return _0023_003Dzt_m8zV0_003D == '.';
	}

	private bool _0023_003Dzy_Xz1Ik_003D(char _0023_003Dzt_m8zV0_003D)
	{
		return char.IsLetter(_0023_003Dzt_m8zV0_003D);
	}

	private void _0023_003Dzu3HNsvUvuOMG()
	{
		if (_0023_003DzkU8Txtw_003D())
		{
			while (_0023_003DzkU8Txtw_003D() && _0023_003DzrTyJQLU_003D(_0023_003DzFMHDKeM9S9Xg()))
			{
				_0023_003DzyzK8swU_003D++;
			}
		}
	}

	private Param _0023_003DzKvixUAU_003D(string _0023_003DzS_00246o7tc_003D)
	{
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2 = new _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D();
		_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzS_00246o7tc_003D = _0023_003DzS_00246o7tc_003D;
		return _0023_003DzBlBnvuA_003D.Find(_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzP6lZKQWQ36FllnkfeA_003D_003D);
	}

	private void _0023_003DzTkU1YAI_003D(char _0023_003Dzt_m8zV0_003D)
	{
		_0023_003Dzu3HNsvUvuOMG();
		if (!_0023_003DzkU8Txtw_003D() || _0023_003DzFMHDKeM9S9Xg() != _0023_003Dzt_m8zV0_003D)
		{
			_0023_003Dz7R4nzv0_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951434) + _0023_003Dzt_m8zV0_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656121));
		}
		_0023_003DzyzK8swU_003D++;
	}

	private bool _0023_003DzyEI5E6Vv1Poy(char _0023_003Dzt_m8zV0_003D)
	{
		_0023_003Dzu3HNsvUvuOMG();
		if (!_0023_003DzkU8Txtw_003D() || _0023_003DzFMHDKeM9S9Xg() != _0023_003Dzt_m8zV0_003D)
		{
			return false;
		}
		_0023_003DzyzK8swU_003D++;
		return true;
	}

	private bool _0023_003Dz86_yZJ3_uaSB(ref double _0023_003Dzf_0024sXd83XZkB7)
	{
		_0023_003Dzu3HNsvUvuOMG();
		if (!_0023_003DzkU8Txtw_003D())
		{
			_0023_003Dz7R4nzv0_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656107));
		}
		if (!_0023_003Dz0D2_CHE_003D(_0023_003DzFMHDKeM9S9Xg()))
		{
			return false;
		}
		int num = _0023_003DzyzK8swU_003D;
		while (_0023_003DzkU8Txtw_003D() && (_0023_003Dz0D2_CHE_003D(_0023_003DzFMHDKeM9S9Xg()) || _0023_003DzOIfrLpo_003D(_0023_003DzFMHDKeM9S9Xg())))
		{
			_0023_003DzyzK8swU_003D++;
		}
		string _0023_003Dz_0024n2nrac_003D = _0023_003DznC95EKCcZV69.Substring(num, _0023_003DzyzK8swU_003D - num);
		_0023_003Dzf_0024sXd83XZkB7 = _0023_003Dz_0024n2nrac_003D._0023_003DzR61OsnE_003D();
		return true;
	}

	private bool _0023_003DzdpIOy9dMP6C_0024rb68Vw_003D_003D(ref string _0023_003DzpFnxJUpAdB1J)
	{
		_0023_003Dzu3HNsvUvuOMG();
		if (!_0023_003DzkU8Txtw_003D())
		{
			_0023_003Dz7R4nzv0_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656107));
		}
		if (!_0023_003Dzy_Xz1Ik_003D(_0023_003DzFMHDKeM9S9Xg()))
		{
			return false;
		}
		int num = _0023_003DzyzK8swU_003D;
		while (_0023_003DzkU8Txtw_003D() && (_0023_003Dzy_Xz1Ik_003D(_0023_003DzFMHDKeM9S9Xg()) || _0023_003Dz0D2_CHE_003D(_0023_003DzFMHDKeM9S9Xg())))
		{
			_0023_003DzyzK8swU_003D++;
		}
		_0023_003DzpFnxJUpAdB1J = _0023_003DznC95EKCcZV69.Substring(num, _0023_003DzyzK8swU_003D - num);
		return true;
	}

	private Exp.Op _0023_003Dz7mEdUac_003D(string _0023_003DzS_00246o7tc_003D)
	{
		if (_0023_003DzCvYTxLU_003D.ContainsKey(_0023_003DzS_00246o7tc_003D))
		{
			return _0023_003DzCvYTxLU_003D[_0023_003DzS_00246o7tc_003D];
		}
		return Exp.Op.Undefined;
	}

	private Exp _0023_003DzgpfPIUw_003D(string _0023_003DzS_00246o7tc_003D)
	{
		if (_0023_003DzyfK4cmd9941Tl5ST1w_003D_003D.ContainsKey(_0023_003DzS_00246o7tc_003D))
		{
			return _0023_003DzyfK4cmd9941Tl5ST1w_003D_003D[_0023_003DzS_00246o7tc_003D];
		}
		return null;
	}

	private void _0023_003Dz7R4nzv0_003D(string _0023_003Dz7R4nzv0_003D)
	{
		string text = _0023_003DznC95EKCcZV69;
		if (_0023_003DzyzK8swU_003D < text.Length)
		{
			text.Insert(_0023_003DzyzK8swU_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303003154));
		}
		throw new Exception(_0023_003Dz7R4nzv0_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656065) + text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656054));
	}

	private Exp _0023_003Dzxk3z9Lk_003D()
	{
		double _0023_003Dzf_0024sXd83XZkB = 0.0;
		if (_0023_003Dz86_yZJ3_uaSB(ref _0023_003Dzf_0024sXd83XZkB))
		{
			return new Exp(_0023_003Dzf_0024sXd83XZkB);
		}
		bool _0023_003Dz6Sd69qmV7tjg = false;
		string _0023_003DzpFnxJUpAdB1J = string.Empty;
		if (_0023_003DzdpIOy9dMP6C_0024rb68Vw_003D_003D(ref _0023_003DzpFnxJUpAdB1J))
		{
			Exp.Op op = _0023_003Dz7mEdUac_003D(_0023_003DzpFnxJUpAdB1J);
			if (op != Exp.Op.Undefined)
			{
				if (_0023_003DzyEI5E6Vv1Poy('('))
				{
					Exp _0023_003DzjbqS1qE_003D = _0023_003DzTdMerG1v8pEJ(ref _0023_003Dz6Sd69qmV7tjg);
					Exp exp = null;
					if (_0023_003DzyEI5E6Vv1Poy(','))
					{
						exp = _0023_003DzTdMerG1v8pEJ(ref _0023_003Dz6Sd69qmV7tjg);
					}
					_0023_003DzTkU1YAI_003D(')');
					if (op == Exp.Op.Atan2 && exp == null)
					{
						_0023_003Dz7R4nzv0_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656061));
					}
					return new Exp(op, _0023_003DzjbqS1qE_003D, exp);
				}
				_0023_003Dz7R4nzv0_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656005));
			}
			Exp exp2 = _0023_003DzgpfPIUw_003D(_0023_003DzpFnxJUpAdB1J);
			if (exp2 != null)
			{
				return exp2;
			}
			Param param = _0023_003DzKvixUAU_003D(_0023_003DzpFnxJUpAdB1J);
			if (param == null)
			{
				param = new Param(_0023_003DzpFnxJUpAdB1J);
				_0023_003DzBlBnvuA_003D.Add(param);
			}
			return new Exp(param);
		}
		_0023_003Dz7R4nzv0_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656231));
		return null;
	}

	private int _0023_003DzTL7bLXY_003D(Exp.Op _0023_003DzbzgxJgU_003D)
	{
		switch (_0023_003DzbzgxJgU_003D)
		{
		case Exp.Op.Add:
		case Exp.Op.Sub:
			return 1;
		case Exp.Op.Mul:
		case Exp.Op.Div:
			return 2;
		default:
			return 0;
		}
	}

	private Exp.Op _0023_003DzpZPmgUIJMogG()
	{
		_0023_003Dzu3HNsvUvuOMG();
		if (_0023_003DzshE3tZQ_003D.ContainsKey(_0023_003DzFMHDKeM9S9Xg()))
		{
			Exp.Op result = _0023_003DzshE3tZQ_003D[_0023_003DzFMHDKeM9S9Xg()];
			_0023_003DzyzK8swU_003D++;
			return result;
		}
		return Exp.Op.Undefined;
	}

	private bool _0023_003DzkU8Txtw_003D()
	{
		return _0023_003DzyzK8swU_003D < _0023_003DznC95EKCcZV69.Length;
	}

	private Exp.Op _0023_003DzTPIevXOKy5je()
	{
		_0023_003Dzu3HNsvUvuOMG();
		if (_0023_003DzFMHDKeM9S9Xg() == '+')
		{
			_0023_003DzyzK8swU_003D++;
			return Exp.Op.Pos;
		}
		if (_0023_003DzFMHDKeM9S9Xg() == '-')
		{
			_0023_003DzyzK8swU_003D++;
			return Exp.Op.Neg;
		}
		return Exp.Op.Undefined;
	}

	private Exp _0023_003DzTdMerG1v8pEJ(ref bool _0023_003Dz6Sd69qmV7tjg)
	{
		Exp.Op op = _0023_003DzTPIevXOKy5je();
		Exp exp = null;
		bool flag = false;
		if (_0023_003DzyEI5E6Vv1Poy('('))
		{
			bool _0023_003Dz6Sd69qmV7tjg2 = false;
			exp = _0023_003DzTdMerG1v8pEJ(ref _0023_003Dz6Sd69qmV7tjg2);
			_0023_003DzTkU1YAI_003D(')');
			flag = true;
		}
		else
		{
			exp = _0023_003Dzxk3z9Lk_003D();
		}
		if (op != Exp.Op.Undefined && op != Exp.Op.Pos)
		{
			exp = new Exp(op, exp, null);
		}
		_0023_003Dzu3HNsvUvuOMG();
		if (!_0023_003DzkU8Txtw_003D() || _0023_003DzFMHDKeM9S9Xg() == ')' || _0023_003DzFMHDKeM9S9Xg() == ',')
		{
			_0023_003Dz6Sd69qmV7tjg = flag;
			return exp;
		}
		Exp.Op op2 = _0023_003DzpZPmgUIJMogG();
		if (op2 == Exp.Op.Undefined)
		{
			_0023_003Dz7R4nzv0_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656198));
		}
		bool _0023_003Dz6Sd69qmV7tjg3 = false;
		Exp exp2 = _0023_003DzTdMerG1v8pEJ(ref _0023_003Dz6Sd69qmV7tjg3);
		if (!_0023_003Dz6Sd69qmV7tjg3 && exp2._0023_003DzJygGiJtbLp_0024E() && _0023_003DzTL7bLXY_003D(op2) > _0023_003DzTL7bLXY_003D(exp2.op))
		{
			exp2.a = new Exp(op2, exp, exp2.a);
			return exp2;
		}
		return new Exp(op2, exp, exp2);
	}

	public Exp _0023_003DzY15vWMs_003D()
	{
		try
		{
			bool _0023_003Dz6Sd69qmV7tjg = false;
			return _0023_003DzTdMerG1v8pEJ(ref _0023_003Dz6Sd69qmV7tjg);
		}
		catch (Exception)
		{
			return null;
		}
	}
}
