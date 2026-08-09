using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
internal sealed class Exp : ISerializable, ICloneable
{
	public enum Op
	{
		Undefined,
		Const,
		Param,
		Add,
		Sub,
		Mul,
		Div,
		Sin,
		Cos,
		ACos,
		ASin,
		Sqrt,
		Sqr,
		Atan2,
		Abs,
		Sign,
		Neg,
		Pos,
		Drag,
		Exp,
		Sinh,
		Cosh,
		SFres,
		CFres
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static readonly Exp _0023_003DzeW9p26g_003D = new Exp(0.0);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static readonly Exp _0023_003DzvuWzDD8_003D = new Exp(1.0);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static readonly Exp _0023_003Dz3RX8Sec_003D = new Exp(-1.0);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public static readonly Exp _0023_003DzTLoluCY_003D = new Exp(2.0);

	public Op op;

	public Exp a;

	public Exp b;

	public Param param;

	public double value;

	private Exp()
	{
	}

	protected Exp(Exp _0023_003DzySgeilxprQOK)
	{
		op = _0023_003DzySgeilxprQOK.op;
		param = _0023_003DzySgeilxprQOK.param;
		value = _0023_003DzySgeilxprQOK.value;
		if (_0023_003DzySgeilxprQOK.a != null)
		{
			a = (Exp)_0023_003DzySgeilxprQOK.a.Clone();
			if (_0023_003DzySgeilxprQOK.b != null)
			{
				b = (Exp)_0023_003DzySgeilxprQOK.b.Clone();
			}
		}
	}

	public Exp(double _0023_003DzPzO_0024GUk_003D)
	{
		value = _0023_003DzPzO_0024GUk_003D;
		op = Op.Const;
	}

	internal Exp(Param _0023_003DzB68dg9Q_003D)
	{
		param = _0023_003DzB68dg9Q_003D;
		op = Op.Param;
	}

	public Exp(Op _0023_003DzbzgxJgU_003D, Exp _0023_003DzjbqS1qE_003D, Exp _0023_003Dz1v6oPQk_003D)
	{
		a = _0023_003DzjbqS1qE_003D;
		b = _0023_003Dz1v6oPQk_003D;
		op = _0023_003DzbzgxJgU_003D;
	}

	protected Exp(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
	{
		op = (Op)_0023_003Dz9lrNnXY_003D.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655205), typeof(Op));
		value = _0023_003Dz9lrNnXY_003D.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955820));
		param = (Param)_0023_003Dz9lrNnXY_003D.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655189), typeof(Param));
	}

	public static implicit operator Exp(Param _0023_003DzebV_0024Ttc_003D)
	{
		return _0023_003DzebV_0024Ttc_003D._0023_003Dzuc1z_scDJBr3();
	}

	public static implicit operator Exp(double _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzPzO_0024GUk_003D == 0.0)
		{
			return _0023_003DzeW9p26g_003D;
		}
		if (_0023_003DzPzO_0024GUk_003D == 1.0)
		{
			return _0023_003DzvuWzDD8_003D;
		}
		return new Exp
		{
			value = _0023_003DzPzO_0024GUk_003D,
			op = Op.Const
		};
	}

	public static Exp operator +(Exp _0023_003DzjbqS1qE_003D, Exp _0023_003Dz1v6oPQk_003D)
	{
		if (_0023_003DzjbqS1qE_003D._0023_003DzPAGJAmSVYvJc())
		{
			return _0023_003Dz1v6oPQk_003D;
		}
		if (_0023_003Dz1v6oPQk_003D._0023_003DzPAGJAmSVYvJc())
		{
			return _0023_003DzjbqS1qE_003D;
		}
		if (_0023_003Dz1v6oPQk_003D.op == Op.Neg)
		{
			return _0023_003DzjbqS1qE_003D - _0023_003Dz1v6oPQk_003D.a;
		}
		if (_0023_003Dz1v6oPQk_003D.op == Op.Pos)
		{
			return _0023_003DzjbqS1qE_003D + _0023_003Dz1v6oPQk_003D.a;
		}
		return new Exp(Op.Add, _0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D);
	}

	public static Exp operator -(Exp _0023_003DzjbqS1qE_003D, Exp _0023_003Dz1v6oPQk_003D)
	{
		if (_0023_003DzjbqS1qE_003D._0023_003DzPAGJAmSVYvJc())
		{
			return -_0023_003Dz1v6oPQk_003D;
		}
		if (_0023_003Dz1v6oPQk_003D._0023_003DzPAGJAmSVYvJc())
		{
			return _0023_003DzjbqS1qE_003D;
		}
		return new Exp(Op.Sub, _0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D);
	}

	public static Exp operator *(Exp _0023_003DzjbqS1qE_003D, Exp _0023_003Dz1v6oPQk_003D)
	{
		if (_0023_003DzjbqS1qE_003D._0023_003DzPAGJAmSVYvJc())
		{
			return _0023_003DzeW9p26g_003D;
		}
		if (_0023_003Dz1v6oPQk_003D._0023_003DzPAGJAmSVYvJc())
		{
			return _0023_003DzeW9p26g_003D;
		}
		if (_0023_003DzjbqS1qE_003D._0023_003DzCY0JzkykhUIk())
		{
			return _0023_003Dz1v6oPQk_003D;
		}
		if (_0023_003Dz1v6oPQk_003D._0023_003DzCY0JzkykhUIk())
		{
			return _0023_003DzjbqS1qE_003D;
		}
		if (_0023_003DzjbqS1qE_003D._0023_003DzOeFrDJvUaCMJ())
		{
			return -_0023_003Dz1v6oPQk_003D;
		}
		if (_0023_003Dz1v6oPQk_003D._0023_003DzOeFrDJvUaCMJ())
		{
			return -_0023_003DzjbqS1qE_003D;
		}
		if (_0023_003DzjbqS1qE_003D._0023_003DzvfCySFk_003D() && _0023_003Dz1v6oPQk_003D._0023_003DzvfCySFk_003D())
		{
			return _0023_003DzjbqS1qE_003D.value * _0023_003Dz1v6oPQk_003D.value;
		}
		return new Exp(Op.Mul, _0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D);
	}

	public static Exp operator /(Exp _0023_003DzjbqS1qE_003D, Exp _0023_003Dz1v6oPQk_003D)
	{
		if (_0023_003Dz1v6oPQk_003D._0023_003DzCY0JzkykhUIk())
		{
			return _0023_003DzjbqS1qE_003D;
		}
		if (_0023_003DzjbqS1qE_003D._0023_003DzPAGJAmSVYvJc())
		{
			return _0023_003DzeW9p26g_003D;
		}
		if (_0023_003Dz1v6oPQk_003D._0023_003DzOeFrDJvUaCMJ())
		{
			return -_0023_003DzjbqS1qE_003D;
		}
		return new Exp(Op.Div, _0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D);
	}

	public static Exp operator -(Exp _0023_003DzjbqS1qE_003D)
	{
		if (_0023_003DzjbqS1qE_003D._0023_003DzPAGJAmSVYvJc())
		{
			return _0023_003DzjbqS1qE_003D;
		}
		if (_0023_003DzjbqS1qE_003D._0023_003DzvfCySFk_003D())
		{
			return 0.0 - _0023_003DzjbqS1qE_003D.value;
		}
		if (_0023_003DzjbqS1qE_003D.op == Op.Neg)
		{
			return _0023_003DzjbqS1qE_003D.a;
		}
		return new Exp(Op.Neg, _0023_003DzjbqS1qE_003D, null);
	}

	public static double _0023_003DzFZiVhypatjMG(double _0023_003DzBJFJHwk_003D)
	{
		double num = Math.Abs(_0023_003DzBJFJHwk_003D);
		double num2 = num * num;
		double num3 = num2 * num;
		return (double)Math.Sign(_0023_003DzBJFJHwk_003D) * (0.5 + (1.0 + 0.926 * num) / (2.0 + 1.792 * num + 3.104 * num2) * Math.Sin(Math.PI * num2 / 2.0) - 1.0 / (2.0 + 4.142 * num + 3.492 * num2 + 6.67 * num3) * Math.Cos(Math.PI * num2 / 2.0));
	}

	public static double _0023_003Dz21pgBw3bsYyB(double _0023_003DzBJFJHwk_003D)
	{
		double num = Math.Abs(_0023_003DzBJFJHwk_003D);
		double num2 = num * num;
		double num3 = num2 * num;
		return (double)Math.Sign(_0023_003DzBJFJHwk_003D) * (0.5 - (1.0 + 0.926 * num) / (2.0 + 1.792 * num + 3.104 * num2) * Math.Cos(Math.PI * num2 / 2.0) - 1.0 / (6.142 + 3.492 * num2 + 6.67 * num3) * Math.Sin(Math.PI * num2 / 2.0));
	}

	public static Exp _0023_003DzzFteY6c_003D(Exp _0023_003DzBJFJHwk_003D)
	{
		return new Exp(Op.Sin, _0023_003DzBJFJHwk_003D, null);
	}

	public static Exp _0023_003DzHqHPcG0_003D(Exp _0023_003DzBJFJHwk_003D)
	{
		return new Exp(Op.Cos, _0023_003DzBJFJHwk_003D, null);
	}

	public static Exp _0023_003DzFgc3sHjkJlg0(Exp _0023_003DzBJFJHwk_003D)
	{
		return new Exp(Op.ACos, _0023_003DzBJFJHwk_003D, null);
	}

	public static Exp _0023_003Dzxw_0024hDpljReeT(Exp _0023_003DzBJFJHwk_003D)
	{
		return new Exp(Op.ASin, _0023_003DzBJFJHwk_003D, null);
	}

	public static Exp _0023_003Dzn7TsgvrQX_0024_7(Exp _0023_003DzBJFJHwk_003D)
	{
		return new Exp(Op.Sqrt, _0023_003DzBJFJHwk_003D, null);
	}

	public static Exp _0023_003DzKSdA2AY_003D(Exp _0023_003DzBJFJHwk_003D)
	{
		return new Exp(Op.Sqr, _0023_003DzBJFJHwk_003D, null);
	}

	public static Exp _0023_003Dz0v89Hn0_003D(Exp _0023_003DzBJFJHwk_003D)
	{
		return new Exp(Op.Abs, _0023_003DzBJFJHwk_003D, null);
	}

	public static Exp _0023_003DzE4Ox648_003D(Exp _0023_003DzBJFJHwk_003D)
	{
		return new Exp(Op.Sign, _0023_003DzBJFJHwk_003D, null);
	}

	public static Exp _0023_003DzmSWwcFA_003D(Exp _0023_003DzBJFJHwk_003D, Exp _0023_003Dz40R7bAU_003D)
	{
		return new Exp(Op.Atan2, _0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
	}

	public static Exp _0023_003DzW_0024foAbMx5sYe(Exp _0023_003DzBJFJHwk_003D)
	{
		return new Exp(Op.Exp, _0023_003DzBJFJHwk_003D, null);
	}

	public static Exp _0023_003DzJnX6582oy1I4(Exp _0023_003DzBJFJHwk_003D)
	{
		return new Exp(Op.Sinh, _0023_003DzBJFJHwk_003D, null);
	}

	public static Exp _0023_003DzG_5XRBIVup7e(Exp _0023_003DzBJFJHwk_003D)
	{
		return new Exp(Op.Cosh, _0023_003DzBJFJHwk_003D, null);
	}

	public static Exp _0023_003Dz21pgBw3bsYyB(Exp _0023_003DzBJFJHwk_003D)
	{
		return new Exp(Op.SFres, _0023_003DzBJFJHwk_003D, null);
	}

	public static Exp _0023_003DzFZiVhypatjMG(Exp _0023_003DzBJFJHwk_003D)
	{
		return new Exp(Op.CFres, _0023_003DzBJFJHwk_003D, null);
	}

	public Exp _0023_003Dz7cZ02rs_003D(Exp _0023_003Dz8SEdsjQ_003D)
	{
		return new Exp(Op.Drag, this, _0023_003Dz8SEdsjQ_003D);
	}

	public double _0023_003DzBUjqlpM_003D()
	{
		switch (op)
		{
		case Op.Const:
			return value;
		case Op.Param:
			return param._0023_003DzV29zQ3g_003D();
		case Op.Add:
			return a._0023_003DzBUjqlpM_003D() + b._0023_003DzBUjqlpM_003D();
		case Op.Sub:
		case Op.Drag:
			return a._0023_003DzBUjqlpM_003D() - b._0023_003DzBUjqlpM_003D();
		case Op.Mul:
			return a._0023_003DzBUjqlpM_003D() * b._0023_003DzBUjqlpM_003D();
		case Op.Div:
		{
			double num2 = b._0023_003DzBUjqlpM_003D();
			if (Math.Abs(num2) < 1E-12)
			{
				num2 = 1.0;
			}
			return a._0023_003DzBUjqlpM_003D() / num2;
		}
		case Op.Sin:
			return Math.Sin(a._0023_003DzBUjqlpM_003D());
		case Op.Cos:
			return Math.Cos(a._0023_003DzBUjqlpM_003D());
		case Op.ACos:
			return Math.Acos(a._0023_003DzBUjqlpM_003D());
		case Op.ASin:
			return Math.Asin(a._0023_003DzBUjqlpM_003D());
		case Op.Sqrt:
			return Math.Sqrt(a._0023_003DzBUjqlpM_003D());
		case Op.Sqr:
		{
			double num = a._0023_003DzBUjqlpM_003D();
			return num * num;
		}
		case Op.Atan2:
			return Math.Atan2(a._0023_003DzBUjqlpM_003D(), b._0023_003DzBUjqlpM_003D());
		case Op.Abs:
			return Math.Abs(a._0023_003DzBUjqlpM_003D());
		case Op.Sign:
			return Math.Sign(a._0023_003DzBUjqlpM_003D());
		case Op.Neg:
			return 0.0 - a._0023_003DzBUjqlpM_003D();
		case Op.Pos:
			return a._0023_003DzBUjqlpM_003D();
		case Op.Exp:
			return Math.Exp(a._0023_003DzBUjqlpM_003D());
		case Op.Sinh:
			return Math.Sinh(a._0023_003DzBUjqlpM_003D());
		case Op.Cosh:
			return Math.Cosh(a._0023_003DzBUjqlpM_003D());
		case Op.SFres:
			return _0023_003Dz21pgBw3bsYyB(a._0023_003DzBUjqlpM_003D());
		case Op.CFres:
			return _0023_003DzFZiVhypatjMG(a._0023_003DzBUjqlpM_003D());
		default:
			return 0.0;
		}
	}

	public bool _0023_003DzPAGJAmSVYvJc()
	{
		if (op == Op.Const)
		{
			return value == 0.0;
		}
		return false;
	}

	public bool _0023_003DzCY0JzkykhUIk()
	{
		if (op == Op.Const)
		{
			return value == 1.0;
		}
		return false;
	}

	public bool _0023_003DzOeFrDJvUaCMJ()
	{
		if (op == Op.Const)
		{
			return value == -1.0;
		}
		return false;
	}

	public bool _0023_003DzvfCySFk_003D()
	{
		return op == Op.Const;
	}

	public bool _0023_003DzSHi1GOA_003D()
	{
		return op == Op.Drag;
	}

	public bool _0023_003Dz52uys2k_003D()
	{
		switch (op)
		{
		case Op.Const:
		case Op.Param:
		case Op.Sin:
		case Op.Cos:
		case Op.ACos:
		case Op.ASin:
		case Op.Sqrt:
		case Op.Sqr:
		case Op.Abs:
		case Op.Sign:
		case Op.Neg:
		case Op.Pos:
		case Op.Exp:
		case Op.Sinh:
		case Op.Cosh:
		case Op.SFres:
		case Op.CFres:
			return true;
		default:
			return false;
		}
	}

	public bool _0023_003DzPOI8lWaQBaVTlDX_8w_003D_003D()
	{
		Op op = this.op;
		if ((uint)(op - 3) <= 1u || op == Op.Drag)
		{
			return true;
		}
		return false;
	}

	private string _0023_003DzKjnGSwk_003D()
	{
		if (_0023_003Dz52uys2k_003D())
		{
			return ToString();
		}
		return _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083) + ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091);
	}

	private string _0023_003Dzj8xfNgs_003D()
	{
		if (!_0023_003DzPOI8lWaQBaVTlDX_8w_003D_003D())
		{
			return ToString();
		}
		return _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908083) + ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091);
	}

	public override string ToString()
	{
		return op switch
		{
			Op.Const => value._0023_003Dz1eU15ZU_003D(), 
			Op.Param => param.name, 
			Op.Add => a.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655169) + b.ToString(), 
			Op.Sub => a.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008275) + b._0023_003Dzj8xfNgs_003D(), 
			Op.Mul => a._0023_003Dzj8xfNgs_003D() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655179) + b._0023_003Dzj8xfNgs_003D(), 
			Op.Div => a._0023_003Dzj8xfNgs_003D() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915925) + b._0023_003DzKjnGSwk_003D(), 
			Op.Sin => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655157) + a.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091), 
			Op.Cos => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655138) + a.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091), 
			Op.ASin => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655147) + a.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091), 
			Op.ACos => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655127) + a.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091), 
			Op.Sqrt => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655107) + a.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091), 
			Op.Sqr => a._0023_003DzKjnGSwk_003D() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655119), 
			Op.Abs => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655868) + a.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091), 
			Op.Sign => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655845) + a.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091), 
			Op.Atan2 => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655825) + a.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108) + b.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091), 
			Op.Neg => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915752) + a._0023_003DzKjnGSwk_003D(), 
			Op.Pos => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302929243) + a._0023_003DzKjnGSwk_003D(), 
			Op.Drag => a.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655840) + b._0023_003Dzj8xfNgs_003D(), 
			Op.Exp => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655819) + a.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091), 
			Op.Sinh => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655800) + a.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091), 
			Op.Cosh => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655780) + a.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091), 
			Op.SFres => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655792) + a.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091), 
			Op.CFres => _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655771) + a.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908091), 
			_ => string.Empty, 
		};
	}

	public object Clone()
	{
		return new Exp(this);
	}

	public virtual void GetObjectData(SerializationInfo _0023_003Dz9lrNnXY_003D, StreamingContext _0023_003DzB8iS0QA_003D)
	{
		_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655205), op);
		_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955820), value);
		_0023_003Dz9lrNnXY_003D.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655189), param);
	}

	public bool _0023_003Dze7e7y6ZykF1ClEZM3w_003D_003D(Param _0023_003DzB68dg9Q_003D)
	{
		if (op == Op.Param)
		{
			return param == _0023_003DzB68dg9Q_003D;
		}
		if (a != null)
		{
			if (b != null)
			{
				if (!a._0023_003Dze7e7y6ZykF1ClEZM3w_003D_003D(_0023_003DzB68dg9Q_003D))
				{
					return b._0023_003Dze7e7y6ZykF1ClEZM3w_003D_003D(_0023_003DzB68dg9Q_003D);
				}
				return true;
			}
			return a._0023_003Dze7e7y6ZykF1ClEZM3w_003D_003D(_0023_003DzB68dg9Q_003D);
		}
		return false;
	}

	public Exp _0023_003DzSOlfnhbkZ12J(Param _0023_003DzB68dg9Q_003D)
	{
		return _0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D);
	}

	private Exp _0023_003DzXrexKjY_003D(Param _0023_003DzB68dg9Q_003D)
	{
		switch (op)
		{
		case Op.Const:
			return _0023_003DzeW9p26g_003D;
		case Op.Param:
			if (param != _0023_003DzB68dg9Q_003D)
			{
				return _0023_003DzeW9p26g_003D;
			}
			return _0023_003DzvuWzDD8_003D;
		case Op.Add:
			return a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) + b._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D);
		case Op.Sub:
		case Op.Drag:
			return a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) - b._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D);
		case Op.Mul:
			return a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) * b + a * b._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D);
		case Op.Div:
			return (a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) * b - a * b._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D)) / _0023_003DzKSdA2AY_003D(b);
		case Op.Sin:
			return a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) * _0023_003DzHqHPcG0_003D(a);
		case Op.Cos:
			return a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) * -_0023_003DzzFteY6c_003D(a);
		case Op.ASin:
			return a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) / _0023_003Dzn7TsgvrQX_0024_7(_0023_003DzvuWzDD8_003D - _0023_003DzKSdA2AY_003D(a));
		case Op.ACos:
			return a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) * _0023_003Dz3RX8Sec_003D / _0023_003Dzn7TsgvrQX_0024_7(_0023_003DzvuWzDD8_003D - _0023_003DzKSdA2AY_003D(a));
		case Op.Sqrt:
			return a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) / (_0023_003DzTLoluCY_003D * _0023_003Dzn7TsgvrQX_0024_7(a));
		case Op.Sqr:
			return a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) * _0023_003DzTLoluCY_003D * a;
		case Op.Abs:
			return a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) * _0023_003DzE4Ox648_003D(a);
		case Op.Sign:
			return _0023_003DzeW9p26g_003D;
		case Op.Neg:
			return -a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D);
		case Op.Atan2:
			return (b * a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) - a * b._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D)) / (_0023_003DzKSdA2AY_003D(a) + _0023_003DzKSdA2AY_003D(b));
		case Op.Exp:
			return a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) * _0023_003DzW_0024foAbMx5sYe(a);
		case Op.Sinh:
			return a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) * _0023_003DzG_5XRBIVup7e(a);
		case Op.Cosh:
			return a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) * _0023_003DzJnX6582oy1I4(a);
		case Op.SFres:
			return a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) * _0023_003DzzFteY6c_003D(Math.PI * _0023_003DzKSdA2AY_003D(a) / 2.0);
		case Op.CFres:
			return a._0023_003DzXrexKjY_003D(_0023_003DzB68dg9Q_003D) * _0023_003DzHqHPcG0_003D(Math.PI * _0023_003DzKSdA2AY_003D(a) / 2.0);
		default:
			return _0023_003DzeW9p26g_003D;
		}
	}

	public bool _0023_003DzB_kWkZdUz_0024nixFmySD0dKDs_003D()
	{
		if (op == Op.Sub && a.op == Op.Param)
		{
			return b.op == Op.Param;
		}
		return false;
	}

	public Param _0023_003Dz1aX_0024I5TLgE2e()
	{
		if (!_0023_003DzB_kWkZdUz_0024nixFmySD0dKDs_003D())
		{
			return null;
		}
		return a.param;
	}

	public Param _0023_003DzMQdMDkMBNhOa()
	{
		if (!_0023_003DzB_kWkZdUz_0024nixFmySD0dKDs_003D())
		{
			return null;
		}
		return b.param;
	}

	public void _0023_003Dz_9xLui4_003D(Param _0023_003DzXeFhIfw_003D, Param _0023_003Dz4ezcSpk_003D)
	{
		if (a != null)
		{
			a._0023_003Dz_9xLui4_003D(_0023_003DzXeFhIfw_003D, _0023_003Dz4ezcSpk_003D);
			if (b != null)
			{
				b._0023_003Dz_9xLui4_003D(_0023_003DzXeFhIfw_003D, _0023_003Dz4ezcSpk_003D);
			}
		}
		else if (op == Op.Param && param == _0023_003DzXeFhIfw_003D)
		{
			param = _0023_003Dz4ezcSpk_003D;
		}
	}

	public void _0023_003Dz_9xLui4_003D(Param _0023_003DzB68dg9Q_003D, Exp _0023_003DzbfrNXYE_003D)
	{
		if (a != null)
		{
			a._0023_003Dz_9xLui4_003D(_0023_003DzB68dg9Q_003D, _0023_003DzbfrNXYE_003D);
			if (b != null)
			{
				b._0023_003Dz_9xLui4_003D(_0023_003DzB68dg9Q_003D, _0023_003DzbfrNXYE_003D);
			}
		}
		else if (op == Op.Param && param == _0023_003DzB68dg9Q_003D)
		{
			op = _0023_003DzbfrNXYE_003D.op;
			a = _0023_003DzbfrNXYE_003D.a;
			b = _0023_003DzbfrNXYE_003D.b;
			param = _0023_003DzbfrNXYE_003D.param;
			value = _0023_003DzbfrNXYE_003D.value;
		}
	}

	public void _0023_003DzX8FPpd4_003D(Action<Exp> _0023_003DzaPWY5KY_003D)
	{
		_0023_003DzaPWY5KY_003D(this);
		if (a != null)
		{
			_0023_003DzaPWY5KY_003D(a);
			if (b != null)
			{
				_0023_003DzaPWY5KY_003D(b);
			}
		}
	}

	public void _0023_003DzzttS9YxbEzs_0024(List<Param> _0023_003DzcFMgdWw_003D)
	{
		if (op == Op.Param)
		{
			if (param.reduceable && !_0023_003DzcFMgdWw_003D.Contains(param))
			{
				value = _0023_003DzBUjqlpM_003D();
				op = Op.Const;
				param = null;
			}
		}
		else if (a != null)
		{
			a._0023_003DzzttS9YxbEzs_0024(_0023_003DzcFMgdWw_003D);
			if (b != null)
			{
				b._0023_003DzzttS9YxbEzs_0024(_0023_003DzcFMgdWw_003D);
			}
			if (a._0023_003DzvfCySFk_003D() && (b == null || b._0023_003DzvfCySFk_003D()))
			{
				value = _0023_003DzBUjqlpM_003D();
				op = Op.Const;
				a = null;
				b = null;
				param = null;
			}
		}
	}

	public bool _0023_003DzJygGiJtbLp_0024E()
	{
		if (a != null)
		{
			return b != null;
		}
		return false;
	}

	public Op _0023_003Dz5mwm_0024GE_003D()
	{
		return op;
	}
}
