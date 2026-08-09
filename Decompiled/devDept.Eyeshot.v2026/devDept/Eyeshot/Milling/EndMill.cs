using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class EndMill
{
	private readonly struct _0023_003DzagyYgV0lYvBGySlZTQ_003D_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003DzjbqS1qE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003Dz1v6oPQk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003Dzea56G9B_0024LyGp;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003DzIH4V7bo0MxBq;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003DzhidJeNw_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003DzfzEMRu0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003DzkKfJheA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003DzoMNiNRw_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003DzZIuFz5YoZ980;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003Dzi6iDS4DnI51J;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003DzbfrNXYE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003DzB68dg9Q_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003DzO_0024iiQ4U_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003DzRpXgovo_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003DzeKd1WNM_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003DzAYqOj_Y_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal readonly double _0023_003DzqD6oJOI_003D;

		public _0023_003DzagyYgV0lYvBGySlZTQ_003D_003D(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003DzhidJeNw_003D, double _0023_003DzkKfJheA_003D, double _0023_003DzoMNiNRw_003D, double _0023_003DzRpXgovo_003D, double _0023_003DzAYqOj_Y_003D)
		{
			this._0023_003DzjbqS1qE_003D = _0023_003DzjbqS1qE_003D;
			this._0023_003Dz1v6oPQk_003D = _0023_003Dz1v6oPQk_003D;
			this._0023_003DzhidJeNw_003D = _0023_003DzhidJeNw_003D;
			this._0023_003DzkKfJheA_003D = _0023_003DzkKfJheA_003D;
			this._0023_003DzoMNiNRw_003D = _0023_003DzoMNiNRw_003D;
			this._0023_003DzRpXgovo_003D = _0023_003DzRpXgovo_003D;
			this._0023_003DzAYqOj_Y_003D = _0023_003DzAYqOj_Y_003D;
			_0023_003Dzea56G9B_0024LyGp = _0023_003DzjbqS1qE_003D / _0023_003Dz1v6oPQk_003D;
			_0023_003DzIH4V7bo0MxBq = _0023_003Dz1v6oPQk_003D / _0023_003DzjbqS1qE_003D;
			_0023_003DzZIuFz5YoZ980 = _0023_003DzkKfJheA_003D / _0023_003DzoMNiNRw_003D;
			_0023_003Dzi6iDS4DnI51J = _0023_003DzoMNiNRw_003D / _0023_003DzkKfJheA_003D;
			_0023_003DzqD6oJOI_003D = _0023_003DzAYqOj_Y_003D * _0023_003DzAYqOj_Y_003D;
			_0023_003DzeKd1WNM_003D = _0023_003DzRpXgovo_003D * _0023_003DzRpXgovo_003D;
			_0023_003DzfzEMRu0_003D = _0023_003DzhidJeNw_003D * _0023_003DzhidJeNw_003D;
			_0023_003DzbfrNXYE_003D = ((_0023_003DzjbqS1qE_003D > 0.0 && _0023_003Dz1v6oPQk_003D > 0.0) ? (_0023_003DzhidJeNw_003D + _0023_003DzRpXgovo_003D * _0023_003Dz1v6oPQk_003D / Math.Sqrt(_0023_003DzjbqS1qE_003D * _0023_003DzjbqS1qE_003D + _0023_003Dz1v6oPQk_003D * _0023_003Dz1v6oPQk_003D)) : _0023_003DzAYqOj_Y_003D);
			_0023_003DzB68dg9Q_003D = _0023_003DzoMNiNRw_003D + Math.Sqrt(_0023_003DzeKd1WNM_003D - (_0023_003DzkKfJheA_003D - _0023_003DzhidJeNw_003D) * (_0023_003DzkKfJheA_003D - _0023_003DzhidJeNw_003D));
			_0023_003DzO_0024iiQ4U_003D = _0023_003DzB68dg9Q_003D - Math.Sqrt(_0023_003DzeKd1WNM_003D - (_0023_003DzbfrNXYE_003D - _0023_003DzhidJeNw_003D) * (_0023_003DzbfrNXYE_003D - _0023_003DzhidJeNw_003D));
			if (!_0023_003DzntELpWfX6gSw())
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994468));
			}
		}

		private bool _0023_003DzntELpWfX6gSw()
		{
			if (_0023_003DzhidJeNw_003D < 0.0 || _0023_003DzRpXgovo_003D < 0.0 || _0023_003DzjbqS1qE_003D < 0.0 || _0023_003Dz1v6oPQk_003D < 0.0 || _0023_003DzkKfJheA_003D < 0.0 || _0023_003DzoMNiNRw_003D < 0.0)
			{
				return false;
			}
			if (_0023_003DzjbqS1qE_003D > 0.0 && _0023_003Dz1v6oPQk_003D == 0.0)
			{
				return false;
			}
			if (_0023_003DzoMNiNRw_003D > 0.0 && _0023_003DzkKfJheA_003D == 0.0)
			{
				return false;
			}
			if (_0023_003DzjbqS1qE_003D > 0.0 && _0023_003DzoMNiNRw_003D > 0.0 && _0023_003Dz1v6oPQk_003D / _0023_003DzjbqS1qE_003D <= _0023_003DzoMNiNRw_003D / _0023_003DzkKfJheA_003D)
			{
				return false;
			}
			return true;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzagyYgV0lYvBGySlZTQ_003D_003D _0023_003DzIMbXMULW_00244B_QsdIKyEIPamouJ_p;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003DzElsat0LzlZVII9Vppw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003DzyApLiW8gKUS4P2_zca7N2NE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzHRvX_P0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003DzoyH_buRmyCkkbacyYtkoZdI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzvUCknP61uTAjGk5s7O15i9I_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzMO1teKiVhnqws0hJSRhnm1c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzmA4Ff6rHG3v0XO_qxw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzwglnHoJt_NgpNvTd_0024g_003D_003D = 1000.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dzl3BsUcCuaIBlgWXFuw_003D_003D = 500.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzKSmf3MFmpXdBbxIfSw_003D_003D = Color.Magenta;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzSCVMMEFWle1i4U1ipGYosnw_003D = Color.White;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003Dz3HQWusTiiYuWFRQj87wGmec_003D = Color.FromArgb(204, 204, 204);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzZQaeNzau2RvSYWcvSg_003D_003D = Color.GreenYellow;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25 _0023_003DzEKSHIVc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double _0023_003DzEGKj_0024SNUUihi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[,] _0023_003DzqJQVDupDLepd;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzD6ykLbPlz_Dy6zB1nQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double _0023_003DzaJKMOzZMYBZ13Rj_VA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ICurve> _0023_003DzqppQUq8Oo4lu;

	protected const int SLICES = 36;

	public double Diameter
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzElsat0LzlZVII9Vppw_003D_003D;
		}
	}

	public double CornerRadius
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzyApLiW8gKUS4P2_zca7N2NE_003D;
		}
	}

	public double TipAngle => 2.0 * (Math.PI / 2.0 - _0023_003DzHRvX_P0_003D);

	public double TaperAngle
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzoyH_buRmyCkkbacyYtkoZdI_003D;
		}
	}

	public double ShaftLength
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzvUCknP61uTAjGk5s7O15i9I_003D;
		}
	}

	public double FluteLength
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzMO1teKiVhnqws0hJSRhnm1c_003D;
		}
	}

	public int Number
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzmA4Ff6rHG3v0XO_qxw_003D_003D;
		}
	}

	public double Speed
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzwglnHoJt_NgpNvTd_0024g_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzwglnHoJt_NgpNvTd_0024g_003D_003D = value;
		}
	}

	public double Feed
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzl3BsUcCuaIBlgWXFuw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzl3BsUcCuaIBlgWXFuw_003D_003D = value;
		}
	}

	public Color CornerColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzKSmf3MFmpXdBbxIfSw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzKSmf3MFmpXdBbxIfSw_003D_003D = value;
		}
	}

	public Color FluteColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzSCVMMEFWle1i4U1ipGYosnw_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzSCVMMEFWle1i4U1ipGYosnw_003D = value;
		}
	}

	public Color ShaftColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz3HQWusTiiYuWFRQj87wGmec_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz3HQWusTiiYuWFRQj87wGmec_003D = value;
		}
	}

	public Color SimulationColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzZQaeNzau2RvSYWcvSg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzZQaeNzau2RvSYWcvSg_003D_003D = value;
		}
	}

	public EndMill(double diameter, double cornerRadius, int number = 0)
		: this(diameter, 0.0, cornerRadius, 0.0, 0.0, 0.0, number)
	{
	}

	public EndMill(double diameter, double cornerRadius, double fluteLength, double shaftLength, int number = 0)
		: this(diameter, 0.0, cornerRadius, 0.0, fluteLength, shaftLength, number)
	{
	}

	public EndMill(double d, double alpha, double r, double beta, double h, double shaftLength, int number = 0)
	{
		_0023_003DzElsat0LzlZVII9Vppw_003D_003D = d;
		_0023_003DzyApLiW8gKUS4P2_zca7N2NE_003D = r;
		if (CornerRadius > d / 2.0)
		{
			_0023_003DzyApLiW8gKUS4P2_zca7N2NE_003D = d / 2.0;
		}
		_0023_003DzoyH_buRmyCkkbacyYtkoZdI_003D = beta;
		_0023_003DzHRvX_P0_003D = alpha;
		_0023_003Dz4o_DAnKiWnHZLJqPXg_003D_003D(h);
		_0023_003Dz87aAv80G_0024MMaaAZe0g_003D_003D(shaftLength);
		_0023_003DzmA4Ff6rHG3v0XO_qxw_003D_003D = number;
		_0023_003DzVnfAoovaoMa7();
	}

	protected EndMill(EndMill another)
	{
		_0023_003DzElsat0LzlZVII9Vppw_003D_003D = another.Diameter;
		_0023_003DzyApLiW8gKUS4P2_zca7N2NE_003D = another.CornerRadius;
		_0023_003DzmA4Ff6rHG3v0XO_qxw_003D_003D = another.Number;
		_0023_003Dz87aAv80G_0024MMaaAZe0g_003D_003D(another.ShaftLength);
		_0023_003Dz4o_DAnKiWnHZLJqPXg_003D_003D(another.FluteLength);
		_0023_003DzHRvX_P0_003D = another._0023_003DzHRvX_P0_003D;
		_0023_003DzoyH_buRmyCkkbacyYtkoZdI_003D = another.TaperAngle;
		SimulationColor = another.SimulationColor;
		ShaftColor = another.ShaftColor;
		CornerColor = another.CornerColor;
		FluteColor = another.FluteColor;
		Speed = another.Speed;
		Feed = another.Feed;
		_0023_003DzVnfAoovaoMa7();
	}

	private _0023_003DzagyYgV0lYvBGySlZTQ_003D_003D _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()
	{
		return _0023_003DzIMbXMULW_00244B_QsdIKyEIPamouJ_p;
	}

	private void _0023_003Dz8l4lUwM6UmCHr61gkA_003D_003D(_0023_003DzagyYgV0lYvBGySlZTQ_003D_003D _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzIMbXMULW_00244B_QsdIKyEIPamouJ_p = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003Dz87aAv80G_0024MMaaAZe0g_003D_003D(double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzvUCknP61uTAjGk5s7O15i9I_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003Dz4o_DAnKiWnHZLJqPXg_003D_003D(double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzMO1teKiVhnqws0hJSRhnm1c_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public static EndMill CreateDrill(double diameter, double tipAngle, double fluteLength, double shaftLength, int number = 0)
	{
		return new EndMill(diameter, Math.PI / 2.0 - tipAngle / 2.0, 0.0, 0.0, fluteLength, shaftLength, number);
	}

	public static EndMill CreateChamfer(double diameter, double tipDiameter, double fluteLength, double shaftLength, int number = 0)
	{
		return new EndMill(diameter, 0.0, 0.0, Math.Atan((diameter - tipDiameter) / (2.0 * fluteLength)), fluteLength, shaftLength, number);
	}

	public static EndMill CreateTapered(double diameter, double cornerRadius, double taperAngle, double fluteLength, double shaftLength, int number = 0)
	{
		return new EndMill(diameter, 0.0, cornerRadius, taperAngle, fluteLength, shaftLength, number);
	}

	public virtual object Clone()
	{
		return new EndMill(this);
	}

	private void _0023_003DzVnfAoovaoMa7()
	{
		_0023_003DzeaScEt842PuU();
		_0023_003DzWh7_00240Rzbobd3();
		_0023_003Dz7PqEIe5mbWeHArxI_Q_003D_003D();
	}

	private void _0023_003DzeaScEt842PuU()
	{
		if (FluteLength == 0.0)
		{
			_0023_003Dz4o_DAnKiWnHZLJqPXg_003D_003D(Diameter * 5.0);
		}
		if (ShaftLength == 0.0)
		{
			_0023_003Dz87aAv80G_0024MMaaAZe0g_003D_003D(4.0 * FluteLength / 3.0);
		}
		if (ShaftLength < FluteLength)
		{
			_0023_003Dz87aAv80G_0024MMaaAZe0g_003D_003D(FluteLength);
		}
	}

	private void _0023_003Dz7PqEIe5mbWeHArxI_Q_003D_003D()
	{
		_0023_003DzI_0024VuGSTWEZdc(out var _0023_003DzQvaHyao_003D, out var _0023_003DzNyidyKE_003D);
		Arc arc = _0023_003DzGmWsqRO99VOMgDPsJQ_003D_003D(_0023_003DzQvaHyao_003D, _0023_003DzNyidyKE_003D);
		_0023_003DzqppQUq8Oo4lu = new List<ICurve>();
		if (_0023_003DzQvaHyao_003D != null)
		{
			_0023_003DzqppQUq8Oo4lu.Add(_0023_003DzQvaHyao_003D);
		}
		if (_0023_003DzNyidyKE_003D != null)
		{
			_0023_003DzqppQUq8Oo4lu.Add(_0023_003DzNyidyKE_003D);
		}
		if (CornerRadius > 0.0)
		{
			_0023_003DzqppQUq8Oo4lu.Add(arc);
		}
		double num = Diameter / 2.0;
		double cornerRadius = CornerRadius;
		_0023_003DzEGKj_0024SNUUihi = num;
		double _0023_003DzjbqS1qE_003D = ((TaperAngle > 0.0 && _0023_003DzNyidyKE_003D != null) ? (num - _0023_003DzNyidyKE_003D.StartPoint.X) : 0.0);
		double _0023_003Dz1v6oPQk_003D = ((TaperAngle > 0.0 && _0023_003DzNyidyKE_003D != null) ? (FluteLength - _0023_003DzNyidyKE_003D.StartPoint.Y) : 0.0);
		double num2 = _0023_003DzQvaHyao_003D?.EndPoint.X ?? 0.0;
		double _0023_003DzoMNiNRw_003D = _0023_003DzQvaHyao_003D?.EndPoint.Y ?? 0.0;
		double _0023_003DzhidJeNw_003D = ((CornerRadius > 0.0 && arc != null) ? arc.Center.X : num2);
		_0023_003Dz8l4lUwM6UmCHr61gkA_003D_003D(new _0023_003DzagyYgV0lYvBGySlZTQ_003D_003D(_0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D, _0023_003DzhidJeNw_003D, num2, _0023_003DzoMNiNRw_003D, cornerRadius, num));
	}

	private Arc _0023_003DzGmWsqRO99VOMgDPsJQ_003D_003D(Line _0023_003DzQvaHyao_003D, Line _0023_003DzNyidyKE_003D)
	{
		if (CornerRadius > 0.0)
		{
			if (IsBall())
			{
				return new Arc(Plane.XY, new Point2D(0.0, CornerRadius), Point2D.Origin, new Point2D(CornerRadius, CornerRadius));
			}
			Line line = (Line)_0023_003DzQvaHyao_003D.Offset(0.0 - CornerRadius, Vector3D.AxisZ)[0];
			Line line2 = (Line)_0023_003DzNyidyKE_003D.Offset(0.0 - CornerRadius, Vector3D.AxisZ)[0];
			if (Segment2D.IntersectionLine(new Segment2D(line.StartPoint, line.EndPoint), new Segment2D(line2.StartPoint, line2.EndPoint), out var i))
			{
				Arc arc = new Arc(Plane.XY, i, CornerRadius, _0023_003DzQvaHyao_003D.Direction.AngleInXY - Math.PI / 2.0, _0023_003DzNyidyKE_003D.Direction.AngleInXY - Math.PI / 2.0);
				_0023_003DzQvaHyao_003D.TrimBy(arc.StartPoint, flipSide: false);
				_0023_003DzNyidyKE_003D.TrimBy(arc.EndPoint, flipSide: true);
				return arc;
			}
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994468));
		}
		return null;
	}

	public bool IsFlat()
	{
		if (TaperAngle == 0.0 && _0023_003DzHRvX_P0_003D == 0.0)
		{
			return CornerRadius == 0.0;
		}
		return false;
	}

	public bool IsBall()
	{
		return Utility.AreEqual(CornerRadius, Diameter / 2.0, Diameter * 1E-12);
	}

	public bool IsBull()
	{
		if (CornerRadius > 0.0 && !IsBall() && TaperAngle == 0.0)
		{
			return _0023_003DzHRvX_P0_003D == 0.0;
		}
		return false;
	}

	public bool IsDrill()
	{
		if (TaperAngle == 0.0 && _0023_003DzHRvX_P0_003D > 0.0)
		{
			return CornerRadius == 0.0;
		}
		return false;
	}

	public bool IsChamfer()
	{
		if (_0023_003DzHRvX_P0_003D == 0.0 && TaperAngle > 0.0)
		{
			return !Utility.AreEqual(2.0 * Math.Tan(TaperAngle), FluteLength / Diameter, Diameter * 1E-12);
		}
		return false;
	}

	public bool IsTapered()
	{
		if (_0023_003DzHRvX_P0_003D == 0.0 && TaperAngle > 0.0)
		{
			return CornerRadius > 0.0;
		}
		return false;
	}

	private void _0023_003DzWh7_00240Rzbobd3()
	{
		if (IsBull())
		{
			_0023_003DzEKSHIVc_003D = _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.bull;
		}
		else if (IsBall())
		{
			_0023_003DzEKSHIVc_003D = _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.ball;
		}
		else if (IsFlat())
		{
			_0023_003DzEKSHIVc_003D = _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.flat;
		}
		else if (IsDrill())
		{
			_0023_003DzEKSHIVc_003D = _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.drill;
		}
		else
		{
			_0023_003DzEKSHIVc_003D = _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.generic;
		}
	}

	private void _0023_003DzI_0024VuGSTWEZdc(out Line _0023_003DzQvaHyao_003D, out Line _0023_003DzNyidyKE_003D)
	{
		double num = Diameter / 2.0;
		_0023_003DzQvaHyao_003D = null;
		_0023_003DzNyidyKE_003D = null;
		if (IsBall())
		{
			_0023_003DzQvaHyao_003D = new Line(CornerRadius, CornerRadius, CornerRadius, FluteLength);
			return;
		}
		double num2;
		double num3;
		if (IsDrill())
		{
			num2 = num;
			num3 = num * Math.Tan(_0023_003DzHRvX_P0_003D);
			_0023_003DzNyidyKE_003D = new Line(num2, num3, num2, FluteLength);
			_0023_003DzQvaHyao_003D = new Line(0.0, 0.0, num2, num3);
			return;
		}
		double num4 = Math.Tan(_0023_003DzHRvX_P0_003D);
		if (TaperAngle != 0.0)
		{
			double num5 = Math.Tan(Math.PI / 2.0 - TaperAngle);
			double num6 = (0.0 - num5) * num + FluteLength;
			num2 = num6 / (num4 - num5);
			num3 = num4 * num6 / (num4 - num5);
		}
		else
		{
			num3 = num4 * num;
			num2 = num;
		}
		_0023_003DzQvaHyao_003D = new Line(0.0, 0.0, num2, num3);
		_0023_003DzNyidyKE_003D = new Line(num2, num3, num, FluteLength);
	}

	internal double _0023_003Dzbkpk06c_003D(double _0023_003DzuwH5j5s_003D)
	{
		if (Math.Abs(_0023_003DzuwH5j5s_003D) < _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzIH4V7bo0MxBq)
		{
			return _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzbfrNXYE_003D * Math.Sqrt(1.0 - _0023_003DzuwH5j5s_003D * _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003Dzea56G9B_0024LyGp * (_0023_003DzuwH5j5s_003D * _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003Dzea56G9B_0024LyGp));
		}
		return _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzbfrNXYE_003D + _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzjbqS1qE_003D;
	}

	internal double _0023_003Dz0lybwrA_003D(double _0023_003DzuwH5j5s_003D)
	{
		if (Math.Abs(_0023_003DzuwH5j5s_003D) < _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003Dzi6iDS4DnI51J)
		{
			return _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzkKfJheA_003D * Math.Sqrt(1.0 - _0023_003DzuwH5j5s_003D * _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzZIuFz5YoZ980 * (_0023_003DzuwH5j5s_003D * _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzZIuFz5YoZ980));
		}
		return 0.0;
	}

	internal void _0023_003DzKcsjzYfbPlFj(SimulationStock._0023_003DzB_002497lLiRwQhv _0023_003DzPo_ODtE_003D, double _0023_003Dzxxb31SXSK4Ly)
	{
		if (_0023_003DzqJQVDupDLepd == null)
		{
			_0023_003DzTf2Q4onUdWUUzX4sdOQs_Fc_003D(_0023_003Dzxxb31SXSK4Ly);
		}
	}

	private void _0023_003DzkQd1FBYLG3n9(double _0023_003Dzxxb31SXSK4Ly)
	{
		_0023_003DzD6ykLbPlz_Dy6zB1nQ_003D_003D = _0023_003Dzxxb31SXSK4Ly / 100.0;
		_0023_003DzaJKMOzZMYBZ13Rj_VA_003D_003D = _0023_003Dzxxb31SXSK4Ly / 10.0;
	}

	internal void _0023_003DzTf2Q4onUdWUUzX4sdOQs_Fc_003D(double _0023_003DzIrPGUnY_003D)
	{
		if (_0023_003DzqJQVDupDLepd != null)
		{
			return;
		}
		_0023_003DzWh7_00240Rzbobd3();
		_0023_003DzkQd1FBYLG3n9(_0023_003DzIrPGUnY_003D);
		int num = (int)(_0023_003DzEGKj_0024SNUUihi / _0023_003DzD6ykLbPlz_Dy6zB1nQ_003D_003D);
		_0023_003DzqJQVDupDLepd = new double[num + 1, num + 1];
		if (_0023_003DzEKSHIVc_003D == _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.flat)
		{
			return;
		}
		double num2 = _0023_003DzD6ykLbPlz_Dy6zB1nQ_003D_003D * _0023_003DzD6ykLbPlz_Dy6zB1nQ_003D_003D;
		for (int i = 0; i <= num; i++)
		{
			for (int j = 0; j <= num; j++)
			{
				_0023_003Dzw2IofbY_003D(Math.Sqrt((double)(i * i) * num2 + (double)(j * j) * num2), out var _0023_003DzId5C3LA_003D);
				_0023_003DzqJQVDupDLepd[i, j] = _0023_003DzId5C3LA_003D;
			}
		}
	}

	internal double[] _0023_003DzLC_Qh1WskCwMcoxm7NkBaCxqWCan(double _0023_003DzuwH5j5s_003D, double _0023_003Dz7TFjJCU_003D, double _0023_003DzjubloQBnEwe5, double _0023_003DzYBOcjt4_003D, double _0023_003Dz2MpoULk_003D, double _0023_003Dzxxb31SXSK4Ly)
	{
		if (_0023_003DzaJKMOzZMYBZ13Rj_VA_003D_003D == 0.0)
		{
			_0023_003DzaJKMOzZMYBZ13Rj_VA_003D_003D = _0023_003Dzxxb31SXSK4Ly / 10.0;
		}
		int num = (int)(_0023_003DzEGKj_0024SNUUihi / _0023_003DzaJKMOzZMYBZ13Rj_VA_003D_003D);
		double[] array = new double[num + 1];
		if (double.IsInfinity(_0023_003DzuwH5j5s_003D))
		{
			return array;
		}
		for (int i = 0; i <= num; i++)
		{
			double num2 = (double)i * _0023_003DzaJKMOzZMYBZ13Rj_VA_003D_003D;
			_0023_003DzxH0bQ10_003D(_0023_003DzuwH5j5s_003D, _0023_003Dz7TFjJCU_003D, _0023_003DzjubloQBnEwe5, num2, num2 * num2, _0023_003DzYBOcjt4_003D, _0023_003Dz2MpoULk_003D, out var _0023_003DzAvn2b38_003D);
			array[i] = _0023_003DzAvn2b38_003D;
		}
		return array;
	}

	public void AddTo(DesignDocument design)
	{
		Entity visualRep = GetVisualRep();
		design.Entities.Add(visualRep);
	}

	public Entity GetVisualRep()
	{
		List<Mesh> list = new List<Mesh>();
		double num = FluteLength;
		if (num == 0.0)
		{
			num = Diameter * 5.0;
		}
		double num2 = ShaftLength;
		if (num2 == 0.0)
		{
			num2 = 4.0 * num / 3.0;
		}
		AddSectionMeshes(num, num2, 36, list);
		Mesh mesh = new Mesh(0, 0, Mesh.natureType.ColorSmooth);
		foreach (Mesh item in list)
		{
			mesh.MergeWith(item, weldNow: false);
		}
		mesh.Weld();
		mesh.Rotate(Math.PI / 2.0, Vector3D.AxisX, Point3D.Origin);
		return mesh;
	}

	protected virtual void AddSectionMeshes(double length, double shaft, int slices, List<Mesh> mList)
	{
		double tolerance = CornerRadius / 100.0;
		for (int i = 0; i < _0023_003DzqppQUq8Oo4lu.Count; i++)
		{
			ICurve curve = _0023_003DzqppQUq8Oo4lu[i];
			Mesh mesh = curve.RevolveAsMesh(0.0, Math.PI * 2.0, Vector3D.AxisY, Point3D.Origin, slices, tolerance, Mesh.natureType.ColorSmooth);
			SetTriangleColor(mesh.Triangles, (curve is Arc) ? CornerColor : FluteColor);
			mList.Add(mesh);
		}
		Mesh mesh2 = new Line(Diameter / 2.0, length, Diameter / 2.0, shaft).RevolveAsMesh(0.0, Math.PI * 2.0, Vector3D.AxisY, Point3D.Origin, slices, tolerance, Mesh.natureType.ColorSmooth);
		SetTriangleColor(mesh2.Triangles, ShaftColor);
		mList.Add(mesh2);
		Mesh mesh3 = new Line(Diameter / 2.0, shaft, 0.0, shaft).RevolveAsMesh(0.0, Math.PI * 2.0, Vector3D.AxisY, Point3D.Origin, slices, tolerance, Mesh.natureType.ColorSmooth);
		SetTriangleColor(mesh3.Triangles, ShaftColor);
		mList.Add(mesh3);
	}

	protected static void SetTriangleColor(IndexTriangle[] triArray, Color color)
	{
		for (int i = 0; i < triArray.Length; i++)
		{
			ColorSmoothTriangle obj = (ColorSmoothTriangle)triArray[i];
			obj.R = color.R;
			obj.G = color.G;
			obj.B = color.B;
		}
	}

	public override string ToString()
	{
		string text = _0023_003DzEKSHIVc_003D.ToString();
		if (!string.IsNullOrEmpty(text))
		{
			text = char.ToUpper(text[0]) + text.Substring(1);
		}
		string text2 = text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994441) + Diameter.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994676));
		if (_0023_003DzEKSHIVc_003D == _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.bull)
		{
			text2 = text2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994683) + CornerRadius.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994676));
		}
		return text2;
	}

	internal virtual bool _0023_003DzUpi18zaCZLvO(ref SimulationStock._0023_003DzB_002497lLiRwQhv _0023_003DzPo_ODtE_003D, double _0023_003DzUIfKDS0_003D, double _0023_003DzWBM5jB4_003D, double _0023_003DzEM_vSEo_003D, out double _0023_003DzId5C3LA_003D, out bool _0023_003DznzO_0024H5wCu3wXbNTJgA_003D_003D)
	{
		_0023_003DzId5C3LA_003D = 0.0;
		_0023_003DznzO_0024H5wCu3wXbNTJgA_003D_003D = false;
		if (_0023_003DzPo_ODtE_003D._0023_003DzXrexKjY_003D < Utility._0023_003DzxhnLabVjXjPg)
		{
			double num = Math.Abs(_0023_003DzUIfKDS0_003D - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.X);
			double num2 = Math.Abs(_0023_003DzWBM5jB4_003D - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Y);
			if (num * num + num2 * num2 > _0023_003DzPo_ODtE_003D._0023_003DzopgN7_0024i7W_D8)
			{
				return false;
			}
			_0023_003Dzw2IofbY_003D(Math.Sqrt(num * num + num2 * num2), out _0023_003DzId5C3LA_003D);
			_0023_003DzId5C3LA_003D = _0023_003DzPo_ODtE_003D._0023_003DzDNpeQO0_003D.Z + _0023_003DzId5C3LA_003D;
			return true;
		}
		_0023_003DzPo_ODtE_003D._0023_003DzWWgGxds_003D.X = _0023_003DzUIfKDS0_003D - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.X;
		_0023_003DzPo_ODtE_003D._0023_003DzWWgGxds_003D.Y = _0023_003DzWBM5jB4_003D - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Y;
		_0023_003DzPo_ODtE_003D._0023_003DzWWgGxds_003D.Z = 0.0;
		double num3 = Math.Abs(_0023_003DzPo_ODtE_003D._0023_003DziP9fFuA_003D.X * _0023_003DzPo_ODtE_003D._0023_003DzWWgGxds_003D.X + _0023_003DzPo_ODtE_003D._0023_003DziP9fFuA_003D.Y * _0023_003DzPo_ODtE_003D._0023_003DzWWgGxds_003D.Y);
		double _0023_003DzEsC0mJg_003D = num3 * num3;
		double _0023_003Dz77g161c_003D = Vector3D.Dot(_0023_003DzPo_ODtE_003D._0023_003Dz61IPlm0_003D, _0023_003DzPo_ODtE_003D._0023_003DzWWgGxds_003D);
		if (!_0023_003Dz6Bbtk02U_o9B(ref _0023_003DzPo_ODtE_003D, num3, _0023_003DzEsC0mJg_003D, _0023_003Dz77g161c_003D, _0023_003DzPo_ODtE_003D._0023_003DzXrexKjY_003D))
		{
			return false;
		}
		_0023_003DzxNY7G4s_003D(num3, _0023_003DzEsC0mJg_003D, _0023_003Dz77g161c_003D, _0023_003DzPo_ODtE_003D._0023_003DzuwH5j5s_003D, _0023_003DzPo_ODtE_003D._0023_003Dz7TFjJCU_003D, _0023_003DzPo_ODtE_003D._0023_003DzcNpWTdOzVsQA, _0023_003DzPo_ODtE_003D._0023_003DzYBOcjt4_003D, _0023_003DzPo_ODtE_003D._0023_003Dz2MpoULk_003D, ref _0023_003DzPo_ODtE_003D, out _0023_003DzId5C3LA_003D);
		return true;
	}

	private bool _0023_003DzEYsNT90fRzI4q_BODg_003D_003D(ref SimulationStock._0023_003DzB_002497lLiRwQhv _0023_003DzPo_ODtE_003D, double _0023_003DzUIfKDS0_003D, double _0023_003DzWBM5jB4_003D, out double _0023_003DzId5C3LA_003D)
	{
		_0023_003DzId5C3LA_003D = 0.0;
		double num = (_0023_003DzUIfKDS0_003D - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.X) * (_0023_003DzUIfKDS0_003D - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.X) + (_0023_003DzWBM5jB4_003D - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Y) * (_0023_003DzWBM5jB4_003D - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Y) + _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Z * _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Z;
		double num2 = (_0023_003DzUIfKDS0_003D - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.X) * _0023_003DzPo_ODtE_003D._0023_003DzMfbogc0_003D.X + (_0023_003DzWBM5jB4_003D - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Y) * _0023_003DzPo_ODtE_003D._0023_003DzMfbogc0_003D.Y - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Z * _0023_003DzPo_ODtE_003D._0023_003DzMfbogc0_003D.Z;
		double num3 = 1.0 - _0023_003DzPo_ODtE_003D._0023_003DzMfbogc0_003D.Z * _0023_003DzPo_ODtE_003D._0023_003DzMfbogc0_003D.Z;
		double num4 = -2.0 * (_0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Z + num2 * _0023_003DzPo_ODtE_003D._0023_003DzMfbogc0_003D.Z);
		double num5 = num - num2 * num2 - _0023_003DzPo_ODtE_003D._0023_003DzopgN7_0024i7W_D8;
		double num6 = num4 * num4 - 4.0 * num3 * num5;
		if (num6 < 0.0)
		{
			return false;
		}
		_0023_003DzId5C3LA_003D = (0.0 - num4 - Math.Sqrt(num6)) / (2.0 * num3);
		double num7 = (new Vector3D(_0023_003DzUIfKDS0_003D, _0023_003DzWBM5jB4_003D, _0023_003DzId5C3LA_003D) - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.AsVector) * _0023_003DzPo_ODtE_003D._0023_003DzMfbogc0_003D / _0023_003DzPo_ODtE_003D._0023_003Dz2s6gjYE_003D;
		if (0.0 <= num7 && num7 <= 1.0)
		{
			_0023_003DzId5C3LA_003D += _0023_003DzEGKj_0024SNUUihi;
			return true;
		}
		double lengthSquared = (new Vector2D(_0023_003DzUIfKDS0_003D, _0023_003DzWBM5jB4_003D) - new Vector2D(_0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.X, _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Y)).LengthSquared;
		double lengthSquared2 = (new Vector2D(_0023_003DzUIfKDS0_003D, _0023_003DzWBM5jB4_003D) - new Vector2D(_0023_003DzPo_ODtE_003D._0023_003DzDNpeQO0_003D.X, _0023_003DzPo_ODtE_003D._0023_003DzDNpeQO0_003D.Y)).LengthSquared;
		if (lengthSquared <= _0023_003DzPo_ODtE_003D._0023_003DzopgN7_0024i7W_D8 && lengthSquared < lengthSquared2)
		{
			_0023_003DzId5C3LA_003D = _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Z + _0023_003DzEGKj_0024SNUUihi - Math.Sqrt(_0023_003DzPo_ODtE_003D._0023_003DzopgN7_0024i7W_D8 - lengthSquared);
			return true;
		}
		if (lengthSquared2 <= _0023_003DzPo_ODtE_003D._0023_003DzopgN7_0024i7W_D8)
		{
			_0023_003DzId5C3LA_003D = _0023_003DzPo_ODtE_003D._0023_003DzDNpeQO0_003D.Z + _0023_003DzEGKj_0024SNUUihi - Math.Sqrt(_0023_003DzPo_ODtE_003D._0023_003DzopgN7_0024i7W_D8 - lengthSquared2);
			return true;
		}
		return false;
	}

	private void _0023_003DzxNY7G4s_003D(double _0023_003Dz_eY3Y4c_003D, double _0023_003DzEsC0mJg_003D, double _0023_003Dz77g161c_003D, double _0023_003DzuwH5j5s_003D, double _0023_003Dz7TFjJCU_003D, double _0023_003DzjubloQBnEwe5, double _0023_003DzYBOcjt4_003D, double _0023_003Dz2MpoULk_003D, ref SimulationStock._0023_003DzB_002497lLiRwQhv _0023_003DzPo_ODtE_003D, out double _0023_003DzId5C3LA_003D)
	{
		_0023_003DzId5C3LA_003D = double.PositiveInfinity;
		if (_0023_003DzxH0bQ10_003D(_0023_003DzuwH5j5s_003D, _0023_003Dz7TFjJCU_003D, _0023_003DzjubloQBnEwe5, _0023_003Dz_eY3Y4c_003D, _0023_003DzEsC0mJg_003D, _0023_003DzYBOcjt4_003D, _0023_003Dz2MpoULk_003D, out var _0023_003DzAvn2b38_003D))
		{
			if (Math.Abs(_0023_003Dz77g161c_003D - _0023_003DzAvn2b38_003D) < Utility._0023_003DzheSR8QM7q9ya)
			{
				_0023_003DzAvn2b38_003D = _0023_003Dz77g161c_003D;
			}
			double.IsNaN(_0023_003DzAvn2b38_003D);
			double _0023_003DzId5C3LA_003D2;
			if (_0023_003Dz77g161c_003D <= _0023_003DzAvn2b38_003D)
			{
				_0023_003Dzw2IofbY_003D(Math.Sqrt(_0023_003DzEsC0mJg_003D + _0023_003Dz77g161c_003D * _0023_003Dz77g161c_003D), out _0023_003DzId5C3LA_003D2);
				_0023_003DzId5C3LA_003D = _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Z + _0023_003DzId5C3LA_003D2;
			}
			else if (_0023_003DzAvn2b38_003D < _0023_003Dz77g161c_003D && _0023_003Dz77g161c_003D < _0023_003DzAvn2b38_003D + _0023_003DzPo_ODtE_003D._0023_003DzXrexKjY_003D)
			{
				_0023_003Dzw2IofbY_003D(Math.Sqrt(_0023_003DzEsC0mJg_003D + _0023_003DzAvn2b38_003D * _0023_003DzAvn2b38_003D), out _0023_003DzId5C3LA_003D2);
				_0023_003DzId5C3LA_003D = _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Z + _0023_003DzId5C3LA_003D2 + _0023_003DzPo_ODtE_003D._0023_003DzuwH5j5s_003D * (_0023_003Dz77g161c_003D - _0023_003DzAvn2b38_003D);
			}
			else
			{
				_0023_003Dzw2IofbY_003D(Math.Sqrt(_0023_003DzEsC0mJg_003D + (_0023_003Dz77g161c_003D - _0023_003DzPo_ODtE_003D._0023_003DzXrexKjY_003D) * (_0023_003Dz77g161c_003D - _0023_003DzPo_ODtE_003D._0023_003DzXrexKjY_003D)), out _0023_003DzId5C3LA_003D2);
				_0023_003DzId5C3LA_003D = _0023_003DzPo_ODtE_003D._0023_003DzDNpeQO0_003D.Z + _0023_003DzId5C3LA_003D2;
			}
		}
	}

	private void _0023_003Dzw2IofbY_003D(double _0023_003DzNDQ_E88_003D, out double _0023_003DzId5C3LA_003D)
	{
		_0023_003DzId5C3LA_003D = 0.0;
		if (_0023_003DzEKSHIVc_003D != _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.flat)
		{
			if (_0023_003DzEKSHIVc_003D == _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.ball)
			{
				_0023_003DzId5C3LA_003D = _0023_003DzEGKj_0024SNUUihi - Math.Sqrt(_0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzeKd1WNM_003D - _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D);
			}
			else if (_0023_003DzEKSHIVc_003D == _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.drill)
			{
				_0023_003DzId5C3LA_003D = _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzoMNiNRw_003D * _0023_003DzNDQ_E88_003D / _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzkKfJheA_003D;
			}
			else if (_0023_003DzEKSHIVc_003D == _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.bull && _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzhidJeNw_003D < _0023_003DzNDQ_E88_003D && _0023_003DzNDQ_E88_003D <= _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzAYqOj_Y_003D)
			{
				_0023_003DzId5C3LA_003D = _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzRpXgovo_003D - Math.Sqrt(_0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzeKd1WNM_003D - (_0023_003DzNDQ_E88_003D - _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzhidJeNw_003D) * (_0023_003DzNDQ_E88_003D - _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzhidJeNw_003D));
			}
			else if (_0023_003DzEKSHIVc_003D == _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.generic)
			{
				_0023_003DzId5C3LA_003D = _0023_003Dzsp8uhf51HftJ(_0023_003DzNDQ_E88_003D);
			}
		}
	}

	private double _0023_003Dzsp8uhf51HftJ(double _0023_003DzNDQ_E88_003D)
	{
		if (_0023_003DzNDQ_E88_003D <= _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzkKfJheA_003D + Utility._0023_003DzxhnLabVjXjPg)
		{
			return _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003Dzi6iDS4DnI51J * _0023_003DzNDQ_E88_003D;
		}
		if (_0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzkKfJheA_003D < _0023_003DzNDQ_E88_003D && _0023_003DzNDQ_E88_003D < _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzbfrNXYE_003D + Utility._0023_003DzxhnLabVjXjPg)
		{
			return _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzB68dg9Q_003D - Math.Sqrt(_0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzeKd1WNM_003D - (_0023_003DzNDQ_E88_003D - _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzhidJeNw_003D) * (_0023_003DzNDQ_E88_003D - _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzhidJeNw_003D));
		}
		return _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzO_0024iiQ4U_003D + _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzIH4V7bo0MxBq * (_0023_003DzNDQ_E88_003D - _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzbfrNXYE_003D);
	}

	private bool _0023_003DzmqkqmB_0024Cy1Bg(double _0023_003DzuwH5j5s_003D, double _0023_003Dz7TFjJCU_003D, double _0023_003DzcNpWTdOzVsQA, double _0023_003Dz_eY3Y4c_003D, double _0023_003DzEsC0mJg_003D, double _0023_003DzYBOcjt4_003D, double _0023_003Dz2MpoULk_003D, out double _0023_003DzAvn2b38_003D)
	{
		_0023_003DzAvn2b38_003D = 0.0;
		if (!_0023_003DzXfrAeOVwMjnt(_0023_003DzuwH5j5s_003D, _0023_003Dz7TFjJCU_003D, _0023_003DzcNpWTdOzVsQA, _0023_003Dz_eY3Y4c_003D, _0023_003DzEsC0mJg_003D, _0023_003DzYBOcjt4_003D, _0023_003Dz2MpoULk_003D, out var _0023_003DzgTBh2DI_003D))
		{
			return false;
		}
		if (_0023_003DzgTBh2DI_003D * _0023_003DzgTBh2DI_003D >= _0023_003Dz_eY3Y4c_003D * _0023_003Dz_eY3Y4c_003D)
		{
			if (_0023_003DzgTBh2DI_003D > _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzAYqOj_Y_003D)
			{
				_0023_003DzgTBh2DI_003D = _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzAYqOj_Y_003D;
			}
			_0023_003DzAvn2b38_003D = (double)((_0023_003DzuwH5j5s_003D >= 0.0) ? 1 : (-1)) * Math.Sqrt(_0023_003DzgTBh2DI_003D * _0023_003DzgTBh2DI_003D - _0023_003DzEsC0mJg_003D);
			return true;
		}
		return false;
	}

	private bool _0023_003DzXfrAeOVwMjnt(double _0023_003DzuwH5j5s_003D, double _0023_003Dz7TFjJCU_003D, double _0023_003DzcNpWTdOzVsQA, double _0023_003Dz_eY3Y4c_003D, double _0023_003DzEsC0mJg_003D, double _0023_003DzYBOcjt4_003D, double _0023_003Dz2MpoULk_003D, out double _0023_003DzgTBh2DI_003D)
	{
		_0023_003DzgTBh2DI_003D = 0.0;
		if (Math.Abs(_0023_003Dz_eY3Y4c_003D) < _0023_003DzYBOcjt4_003D)
		{
			_0023_003DzgTBh2DI_003D = Math.Abs(_0023_003Dz_eY3Y4c_003D) / Math.Sqrt(1.0 - _0023_003DzuwH5j5s_003D * _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzZIuFz5YoZ980 * (_0023_003DzuwH5j5s_003D * _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzZIuFz5YoZ980));
			return true;
		}
		if (Math.Abs(_0023_003Dz_eY3Y4c_003D) >= _0023_003DzYBOcjt4_003D && Math.Abs(_0023_003Dz_eY3Y4c_003D) < _0023_003Dz2MpoULk_003D)
		{
			if (CornerRadius == 0.0)
			{
				_0023_003DzgTBh2DI_003D = _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzkKfJheA_003D;
				return true;
			}
			if (_0023_003DzuwH5j5s_003D == 0.0)
			{
				_0023_003DzgTBh2DI_003D = ((Math.Abs(_0023_003Dz_eY3Y4c_003D) < _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzhidJeNw_003D) ? _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzhidJeNw_003D : _0023_003Dz_eY3Y4c_003D);
				return true;
			}
			double num = -2.0 * _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzhidJeNw_003D;
			double _0023_003Dz1v6oPQk_003D = _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzfzEMRu0_003D - (_0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzeKd1WNM_003D * _0023_003Dz7TFjJCU_003D + _0023_003DzEsC0mJg_003D) / _0023_003DzcNpWTdOzVsQA;
			double _0023_003Dzt_m8zV0_003D = (0.0 - num) * _0023_003DzEsC0mJg_003D / _0023_003DzcNpWTdOzVsQA;
			double _0023_003DzXrexKjY_003D = (0.0 - _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzfzEMRu0_003D) * _0023_003DzEsC0mJg_003D / _0023_003DzcNpWTdOzVsQA;
			foreach (double item in _0023_003DzIcp8V_b9lTcpvTMD4vMInII_003D(num, _0023_003Dz1v6oPQk_003D, _0023_003Dzt_m8zV0_003D, _0023_003DzXrexKjY_003D, 1E-12))
			{
				if (_0023_003Dzv3ascpxXXfoJ(_0023_003Dz_eY3Y4c_003D, item))
				{
					_0023_003DzgTBh2DI_003D = item;
					return true;
				}
			}
			_0023_003DzgTBh2DI_003D = 0.0;
			return false;
		}
		_0023_003DzgTBh2DI_003D = Math.Abs(_0023_003Dz_eY3Y4c_003D) / Math.Sqrt(1.0 - _0023_003DzuwH5j5s_003D * _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003Dzea56G9B_0024LyGp * (_0023_003DzuwH5j5s_003D * _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003Dzea56G9B_0024LyGp));
		if (_0023_003DzgTBh2DI_003D > _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzjbqS1qE_003D + _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzbfrNXYE_003D)
		{
			_0023_003DzgTBh2DI_003D = _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzjbqS1qE_003D + _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzbfrNXYE_003D;
		}
		return true;
	}

	internal bool _0023_003DzxH0bQ10_003D(double _0023_003DzuwH5j5s_003D, double _0023_003Dz7TFjJCU_003D, double _0023_003DzjubloQBnEwe5, double _0023_003Dz_eY3Y4c_003D, double _0023_003DzEsC0mJg_003D, double _0023_003DzYBOcjt4_003D, double _0023_003Dz2MpoULk_003D, out double _0023_003DzAvn2b38_003D)
	{
		_0023_003DzAvn2b38_003D = 0.0;
		if (_0023_003DzEKSHIVc_003D == _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.flat)
		{
			_0023_003DzAvn2b38_003D = (double)((_0023_003DzuwH5j5s_003D >= 0.0) ? 1 : (-1)) * Math.Sqrt(_0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzfzEMRu0_003D - _0023_003DzEsC0mJg_003D);
		}
		else if (_0023_003DzEKSHIVc_003D == _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.bull)
		{
			_0023_003Dz5VepU1bzGl0H(_0023_003DzuwH5j5s_003D, _0023_003Dz7TFjJCU_003D, _0023_003DzjubloQBnEwe5, _0023_003Dz_eY3Y4c_003D, _0023_003DzEsC0mJg_003D, out _0023_003DzAvn2b38_003D);
		}
		else
		{
			if (_0023_003DzEKSHIVc_003D == _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.drill)
			{
				return _0023_003Dz65h42weGK9A7(_0023_003DzuwH5j5s_003D, _0023_003Dz_eY3Y4c_003D, out _0023_003DzAvn2b38_003D);
			}
			if (_0023_003DzEKSHIVc_003D == _0023_003DzfIWSRzwTxvMxCl7A7RtEJcTDwoPgKVzn4xDN_0024ZFFHU25.ball)
			{
				return _0023_003DzrWvb8J_d7gLa(_0023_003DzuwH5j5s_003D, _0023_003Dz7TFjJCU_003D, _0023_003DzjubloQBnEwe5, _0023_003Dz_eY3Y4c_003D, _0023_003DzEsC0mJg_003D, out _0023_003DzAvn2b38_003D);
			}
			_0023_003DzmqkqmB_0024Cy1Bg(_0023_003DzuwH5j5s_003D, _0023_003Dz7TFjJCU_003D, _0023_003DzjubloQBnEwe5, _0023_003Dz_eY3Y4c_003D, _0023_003DzEsC0mJg_003D, _0023_003DzYBOcjt4_003D, _0023_003Dz2MpoULk_003D, out _0023_003DzAvn2b38_003D);
		}
		return true;
	}

	private bool _0023_003DzrWvb8J_d7gLa(double _0023_003DzuwH5j5s_003D, double _0023_003Dz7TFjJCU_003D, double _0023_003DzcNpWTdOzVsQA, double _0023_003Dz_eY3Y4c_003D, double _0023_003DzEsC0mJg_003D, out double _0023_003DzAvn2b38_003D)
	{
		double num = ((!(Math.Abs(_0023_003DzuwH5j5s_003D) < 1E-12)) ? ((_0023_003DzEsC0mJg_003D + _0023_003Dz7TFjJCU_003D * _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzqD6oJOI_003D) / _0023_003DzcNpWTdOzVsQA) : (_0023_003Dz_eY3Y4c_003D * _0023_003Dz_eY3Y4c_003D));
		_0023_003DzAvn2b38_003D = (double)((_0023_003DzuwH5j5s_003D >= 0.0) ? 1 : (-1)) * Math.Sqrt(num - _0023_003DzEsC0mJg_003D);
		return true;
	}

	private void _0023_003Dz5VepU1bzGl0H(double _0023_003DzuwH5j5s_003D, double _0023_003Dz7TFjJCU_003D, double _0023_003DzcNpWTdOzVsQA, double _0023_003Dz_eY3Y4c_003D, double _0023_003DzEsC0mJg_003D, out double _0023_003DzAvn2b38_003D)
	{
		double num = 0.0;
		if (Math.Abs(_0023_003DzuwH5j5s_003D) < Utility._0023_003DzxhnLabVjXjPg)
		{
			num = ((Math.Abs(_0023_003Dz_eY3Y4c_003D) < _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzhidJeNw_003D) ? _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzhidJeNw_003D : _0023_003Dz_eY3Y4c_003D);
		}
		else
		{
			double num2 = -2.0 * _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzhidJeNw_003D;
			double _0023_003Dz1v6oPQk_003D = _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzfzEMRu0_003D - (_0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzeKd1WNM_003D * _0023_003Dz7TFjJCU_003D + _0023_003DzEsC0mJg_003D) / _0023_003DzcNpWTdOzVsQA;
			double _0023_003Dzt_m8zV0_003D = (0.0 - num2) * _0023_003DzEsC0mJg_003D / _0023_003DzcNpWTdOzVsQA;
			double _0023_003DzXrexKjY_003D = (0.0 - _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzfzEMRu0_003D) * _0023_003DzEsC0mJg_003D / _0023_003DzcNpWTdOzVsQA;
			foreach (double item in _0023_003DzIcp8V_b9lTcpvTMD4vMInII_003D(num2, _0023_003Dz1v6oPQk_003D, _0023_003Dzt_m8zV0_003D, _0023_003DzXrexKjY_003D, 1E-12))
			{
				if (_0023_003Dzv3ascpxXXfoJ(_0023_003Dz_eY3Y4c_003D, item))
				{
					num = item;
					break;
				}
			}
		}
		double num3 = num * num;
		if (num3 > _0023_003DzEsC0mJg_003D)
		{
			_0023_003DzAvn2b38_003D = (double)((_0023_003DzuwH5j5s_003D >= 0.0) ? 1 : (-1)) * Math.Sqrt(num3 - _0023_003DzEsC0mJg_003D);
		}
		else if (Math.Abs(num * num - _0023_003DzEsC0mJg_003D) < 1E-12)
		{
			_0023_003DzAvn2b38_003D = 0.0;
		}
		else
		{
			_0023_003DzAvn2b38_003D = double.NaN;
		}
	}

	private bool _0023_003Dz65h42weGK9A7(double _0023_003DzuwH5j5s_003D, double _0023_003Dz_eY3Y4c_003D, out double _0023_003DzAvn2b38_003D)
	{
		_0023_003DzAvn2b38_003D = 0.0;
		if (Math.Abs(_0023_003DzuwH5j5s_003D) < _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003Dzi6iDS4DnI51J)
		{
			double d = 1.0 - _0023_003DzuwH5j5s_003D * _0023_003DzuwH5j5s_003D * _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzZIuFz5YoZ980 * _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzZIuFz5YoZ980;
			double num = Math.Abs(_0023_003Dz_eY3Y4c_003D) / Math.Sqrt(d);
			if (num > _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzkKfJheA_003D)
			{
				num = _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzkKfJheA_003D;
			}
			_0023_003DzAvn2b38_003D = (double)((_0023_003DzuwH5j5s_003D >= 0.0) ? 1 : (-1)) * Math.Sqrt(num * num - _0023_003Dz_eY3Y4c_003D * _0023_003Dz_eY3Y4c_003D);
			return true;
		}
		_0023_003DzAvn2b38_003D = (double)((_0023_003DzuwH5j5s_003D >= 0.0) ? 1 : (-1)) * Math.Sqrt(_0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzkKfJheA_003D * _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzkKfJheA_003D - _0023_003Dz_eY3Y4c_003D * _0023_003Dz_eY3Y4c_003D);
		return true;
	}

	private bool _0023_003Dzv3ascpxXXfoJ(double _0023_003Dz_eY3Y4c_003D, double _0023_003DzNDQ_E88_003D)
	{
		double num = Math.Max(_0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzhidJeNw_003D, Math.Abs(_0023_003Dz_eY3Y4c_003D));
		if (num < _0023_003DzNDQ_E88_003D || Math.Abs(num - _0023_003DzNDQ_E88_003D) < 1E-12)
		{
			return _0023_003DzNDQ_E88_003D <= _0023_003DzJ_0024W_0024yrlPZaONRP5Piw_003D_003D()._0023_003DzAYqOj_Y_003D;
		}
		return false;
	}

	private bool _0023_003Dz6Bbtk02U_o9B(ref SimulationStock._0023_003DzB_002497lLiRwQhv _0023_003DzPo_ODtE_003D, double _0023_003Dz_eY3Y4c_003D, double _0023_003DzEsC0mJg_003D, double _0023_003Dz77g161c_003D, double _0023_003DzXrexKjY_003D)
	{
		if (_0023_003Dz_eY3Y4c_003D > _0023_003DzEGKj_0024SNUUihi || (_0023_003Dz77g161c_003D < 0.0 && _0023_003DzEsC0mJg_003D + _0023_003Dz77g161c_003D * _0023_003Dz77g161c_003D > _0023_003DzPo_ODtE_003D._0023_003DzopgN7_0024i7W_D8) || (_0023_003Dz77g161c_003D > _0023_003DzXrexKjY_003D && _0023_003DzEsC0mJg_003D + (_0023_003DzXrexKjY_003D - _0023_003Dz77g161c_003D) * (_0023_003DzXrexKjY_003D - _0023_003Dz77g161c_003D) > _0023_003DzPo_ODtE_003D._0023_003DzopgN7_0024i7W_D8))
		{
			return false;
		}
		return true;
	}

	private static int _0023_003DzKpLQegNRBwJ2(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003Dzt_m8zV0_003D, out double[] _0023_003DzbCB8gRo_003D)
	{
		double num = _0023_003DzjbqS1qE_003D * _0023_003DzjbqS1qE_003D;
		double num2 = (num - 3.0 * _0023_003Dz1v6oPQk_003D) / 9.0;
		double num3 = (_0023_003DzjbqS1qE_003D * (2.0 * num - 9.0 * _0023_003Dz1v6oPQk_003D) + 27.0 * _0023_003Dzt_m8zV0_003D) / 54.0;
		double num4 = num3 * num3;
		double num5 = num2 * num2 * num2;
		_0023_003DzbCB8gRo_003D = new double[3];
		if (num4 < num5)
		{
			double num6 = num3 / Math.Sqrt(num5);
			if (num6 < -1.0)
			{
				num6 = -1.0;
			}
			if (num6 > 1.0)
			{
				num6 = 1.0;
			}
			num6 = Math.Acos(num6);
			_0023_003DzjbqS1qE_003D /= 3.0;
			num2 = -2.0 * Math.Sqrt(num2);
			_0023_003DzbCB8gRo_003D[0] = num2 * Math.Cos(num6 / 3.0) - _0023_003DzjbqS1qE_003D;
			_0023_003DzbCB8gRo_003D[1] = num2 * Math.Cos((num6 + Math.PI * 2.0) / 3.0) - _0023_003DzjbqS1qE_003D;
			_0023_003DzbCB8gRo_003D[2] = num2 * Math.Cos((num6 - Math.PI * 2.0) / 3.0) - _0023_003DzjbqS1qE_003D;
			return 3;
		}
		double num7 = 0.0 - Math.Pow(Math.Abs(num3) + Math.Sqrt(num4 - num5), 1.0 / 3.0);
		if (num3 < 0.0)
		{
			num7 = 0.0 - num7;
		}
		double num8 = ((0.0 == num7) ? 0.0 : (num2 / num7));
		_0023_003DzjbqS1qE_003D /= 3.0;
		_0023_003DzbCB8gRo_003D[0] = num7 + num8 - _0023_003DzjbqS1qE_003D;
		_0023_003DzbCB8gRo_003D[1] = -0.5 * (num7 + num8) - _0023_003DzjbqS1qE_003D;
		_0023_003DzbCB8gRo_003D[2] = 0.5 * Math.Sqrt(3.0) * (num7 - num8);
		if (Math.Abs(_0023_003DzbCB8gRo_003D[2]) < Utility._0023_003DzheSR8QM7q9ya)
		{
			_0023_003DzbCB8gRo_003D[2] = _0023_003DzbCB8gRo_003D[1];
			return 2;
		}
		return 1;
	}

	internal static List<double> _0023_003DzIcp8V_b9lTcpvTMD4vMInII_003D(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003Dzt_m8zV0_003D, double _0023_003DzXrexKjY_003D, double _0023_003Dzm0CYiiE_003D)
	{
		double _0023_003DzjbqS1qE_003D2 = 0.0 - _0023_003Dz1v6oPQk_003D;
		double _0023_003Dz1v6oPQk_003D2 = _0023_003DzjbqS1qE_003D * _0023_003Dzt_m8zV0_003D - 4.0 * _0023_003DzXrexKjY_003D;
		double _0023_003Dzt_m8zV0_003D2 = (0.0 - _0023_003DzjbqS1qE_003D) * _0023_003DzjbqS1qE_003D * _0023_003DzXrexKjY_003D - _0023_003Dzt_m8zV0_003D * _0023_003Dzt_m8zV0_003D + 4.0 * _0023_003Dz1v6oPQk_003D * _0023_003DzXrexKjY_003D;
		double[] _0023_003DzbCB8gRo_003D;
		int num = _0023_003DzKpLQegNRBwJ2(_0023_003DzjbqS1qE_003D2, _0023_003Dz1v6oPQk_003D2, _0023_003Dzt_m8zV0_003D2, out _0023_003DzbCB8gRo_003D);
		double num2 = _0023_003DzbCB8gRo_003D[0];
		if (num != 1)
		{
			if (Math.Abs(_0023_003DzbCB8gRo_003D[1]) > Math.Abs(num2))
			{
				num2 = _0023_003DzbCB8gRo_003D[1];
			}
			if (Math.Abs(_0023_003DzbCB8gRo_003D[2]) > Math.Abs(num2))
			{
				num2 = _0023_003DzbCB8gRo_003D[2];
			}
		}
		double num3 = num2 * num2 - 4.0 * _0023_003DzXrexKjY_003D;
		double num4;
		double num5;
		double num6;
		double num7;
		if (Math.Abs(num3) < _0023_003Dzm0CYiiE_003D)
		{
			num4 = (num5 = num2 * 0.5);
			num3 = _0023_003DzjbqS1qE_003D * _0023_003DzjbqS1qE_003D - 4.0 * (_0023_003Dz1v6oPQk_003D - num2);
			if (Math.Abs(num3) < _0023_003Dzm0CYiiE_003D)
			{
				num6 = (num7 = _0023_003DzjbqS1qE_003D * 0.5);
			}
			else
			{
				double num8 = Math.Sqrt(num3);
				num6 = (_0023_003DzjbqS1qE_003D + num8) * 0.5;
				num7 = (_0023_003DzjbqS1qE_003D - num8) * 0.5;
			}
		}
		else
		{
			double num8 = Math.Sqrt(num3);
			num4 = (num2 + num8) * 0.5;
			num5 = (num2 - num8) * 0.5;
			num6 = (_0023_003DzjbqS1qE_003D * num4 - _0023_003Dzt_m8zV0_003D) / (num4 - num5);
			num7 = (_0023_003Dzt_m8zV0_003D - _0023_003DzjbqS1qE_003D * num5) / (num4 - num5);
		}
		List<double> list = new List<double>();
		num3 = num6 * num6 - 4.0 * num4;
		if (Math.Abs(num3) < _0023_003Dzm0CYiiE_003D)
		{
			list.Add((0.0 - num6) * 0.5);
		}
		else if (num3 > 0.0)
		{
			double num8 = Math.Sqrt(num3);
			list.Add((0.0 - num6 + num8) * 0.5);
			list.Add((0.0 - num6 - num8) * 0.5);
		}
		num3 = num7 * num7 - 4.0 * num5;
		if (Math.Abs(num3) < _0023_003Dzm0CYiiE_003D)
		{
			list.Add((0.0 - num7) * 0.5);
		}
		else if (num3 > 0.0)
		{
			double num8 = Math.Sqrt(num3);
			list.Add((0.0 - num7 + num8) * 0.5);
			list.Add((0.0 - num7 - num8) * 0.5);
		}
		return list;
	}
}
