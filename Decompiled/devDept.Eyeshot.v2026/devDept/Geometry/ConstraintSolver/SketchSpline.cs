using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class SketchSpline : SketchCurve, ISketchCurve
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<SketchPoint, bool> _0023_003DzUdr4O3AsaCYJAKzjhQ_003D_003D;

		public static Func<SketchPoint, Point3D> _0023_003DzlBU9112_00246US7xbowuQ_003D_003D;

		internal bool _0023_003Dz_0024j9YMZf_FH2ZAahDmQ_003D_003D(SketchPoint _0023_003DzgNguvTg_003D)
		{
			return _0023_003DzgNguvTg_003D._0023_003Dztl9hmdI_003D();
		}

		internal Point3D _0023_003DzTFbywJJRkhuj5PD3QWuP7eQ_003D(SketchPoint _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Position;
		}
	}

	private sealed class _0023_003Dz92B8gv5kz_O_7V23WQ_003D_003D : IEnumerable<SketchPoint>, IEnumerable, IEnumerator<SketchPoint>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SketchPoint _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchSpline _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003Dze6QF3HQ90_qw;

		[DebuggerHidden]
		public _0023_003Dz92B8gv5kz_O_7V23WQ_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
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
			SketchSpline sketchSpline = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003Dze6QF3HQ90_qw = 0;
				break;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003Dze6QF3HQ90_qw++;
				break;
			}
			if (_0023_003Dze6QF3HQ90_qw < sketchSpline.ControlPoints.Length)
			{
				_0023_003DzezVIuujSK1H9 = sketchSpline.ControlPoints[_0023_003Dze6QF3HQ90_qw];
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private SketchPoint _0023_003DzQ704FxG2taak6wseX1QcHOAUySyzgqEGVEIJ5nn4_sTeL6EFvSIGWhVMnRaw()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		SketchPoint IEnumerator<SketchPoint>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zQ704FxG2taak6wseX1QcHOAUySyzgqEGVEIJ5nn4_sTeL6EFvSIGWhVMnRaw
			return this._0023_003DzQ704FxG2taak6wseX1QcHOAUySyzgqEGVEIJ5nn4_sTeL6EFvSIGWhVMnRaw();
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
		private IEnumerator<SketchPoint> _0023_003Dzl1JofgN8RYmzCy5typKGbga5VGe34fop1q0HoKmu_00246dMK5KWTFCGpitTsTGs()
		{
			_0023_003Dz92B8gv5kz_O_7V23WQ_003D_003D _0023_003Dz92B8gv5kz_O_7V23WQ_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003Dz92B8gv5kz_O_7V23WQ_003D_003D2 = this;
			}
			else
			{
				_0023_003Dz92B8gv5kz_O_7V23WQ_003D_003D2 = new _0023_003Dz92B8gv5kz_O_7V23WQ_003D_003D(0);
				_0023_003Dz92B8gv5kz_O_7V23WQ_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003Dz92B8gv5kz_O_7V23WQ_003D_003D2;
		}

		IEnumerator<SketchPoint> IEnumerable<SketchPoint>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zl1JofgN8RYmzCy5typKGbga5VGe34fop1q0HoKmu$6dMK5KWTFCGpitTsTGs
			return this._0023_003Dzl1JofgN8RYmzCy5typKGbga5VGe34fop1q0HoKmu_00246dMK5KWTFCGpitTsTGs();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003Dzl1JofgN8RYmzCy5typKGbga5VGe34fop1q0HoKmu_00246dMK5KWTFCGpitTsTGs();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	public SketchPoint[] ControlPoints = new SketchPoint[4];

	public SketchPoint StartPoint => ControlPoints[0];

	public SketchPoint EndPoint => ControlPoints[3];

	public Vector3D[] SegmentPoints => new Vector3D[1] { Vector3D.AxisX };

	protected SketchSpline(SketchSpline another)
		: base(another)
	{
		_0023_003DzZEROl_YJ_9b_0024tIOMvw_003D_003D._0023_003DzCBXaK_002496NUpX(3, this);
		for (int i = 0; i < another.ControlPoints.Length; i++)
		{
			SketchPoint sketchPoint = another.ControlPoints[i];
			ControlPoints[i] = AddChild((SketchPoint)sketchPoint.Clone());
		}
	}

	internal SketchSpline(SketchInternal _0023_003DzjCETKTg_003D, Curve _0023_003DzvPhb6lvffr27, SketchPoint _0023_003DzLxQW3eiASmKM, bool _0023_003DzAqOpw0w_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzZEROl_YJ_9b_0024tIOMvw_003D_003D._0023_003DzCBXaK_002496NUpX(3, this);
		ControlPoints = new SketchPoint[4];
		if (_0023_003DzAqOpw0w_003D)
		{
			for (int i = 1; i < ControlPoints.Length; i++)
			{
				ControlPoints[i] = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
				ControlPoints[i].SetPosition(_0023_003DzvPhb6lvffr27.ControlPoints[i].Euclid);
			}
			ControlPoints[0] = AddChild(_0023_003DzLxQW3eiASmKM);
		}
		else
		{
			for (int j = 0; j < ControlPoints.Length - 1; j++)
			{
				ControlPoints[j] = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
				ControlPoints[j].SetPosition(_0023_003DzvPhb6lvffr27.ControlPoints[j].Euclid);
			}
			ControlPoints[3] = AddChild(_0023_003DzLxQW3eiASmKM);
		}
	}

	internal SketchSpline(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzZEROl_YJ_9b_0024tIOMvw_003D_003D._0023_003DzCBXaK_002496NUpX(3, this);
		for (int i = 0; i < ControlPoints.Length; i++)
		{
			ControlPoints[i] = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		}
	}

	protected SketchSpline(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		ControlPoints = (SketchPoint[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657238), typeof(SketchPoint[]));
	}

	internal override void _0023_003DzUNQ_t5U_003D(Transformation _0023_003DzLS0sR0pzioXc)
	{
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003Dz92B8gv5kz_O_7V23WQ_003D_003D))]
	internal override IEnumerable<SketchPoint> _0023_003DzgJiUT1qDtKLT()
	{
		return new _0023_003Dz92B8gv5kz_O_7V23WQ_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	internal override SketchPoint _0023_003Dzwuf7q2alCxk7_0024lpuTg_003D_003D(_0023_003DzpIxZyllUf71E32IBGeiYQ3GZCeope4AwcQ_003D_003D _0023_003Dz437_00244ak_003D)
	{
		return _0023_003Dz437_00244ak_003D switch
		{
			(_0023_003DzpIxZyllUf71E32IBGeiYQ3GZCeope4AwcQ_003D_003D)0 => ControlPoints[0], 
			(_0023_003DzpIxZyllUf71E32IBGeiYQ3GZCeope4AwcQ_003D_003D)1 => ControlPoints[3], 
			_ => base._0023_003Dzwuf7q2alCxk7_0024lpuTg_003D_003D(_0023_003Dz437_00244ak_003D), 
		};
	}

	internal override bool _0023_003Dztl9hmdI_003D()
	{
		return ControlPoints.Any((SketchPoint _0023_003DzgNguvTg_003D) => _0023_003DzgNguvTg_003D._0023_003Dztl9hmdI_003D());
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new SketchSplineSurrogate(this);
	}

	public override void Reverse()
	{
		ControlPoints = Enumerable.Reverse(ControlPoints).ToArray();
	}

	internal override ExpVector _0023_003Dz1D2_0024pLU_003D(Exp _0023_003DzNDQ_E88_003D)
	{
		ExpVector expVector = ControlPoints[0]._0023_003Dzuc1z_scDJBr3();
		ExpVector expVector2 = ControlPoints[1]._0023_003Dzuc1z_scDJBr3();
		ExpVector expVector3 = ControlPoints[2]._0023_003Dzuc1z_scDJBr3();
		ExpVector expVector4 = ControlPoints[3]._0023_003Dzuc1z_scDJBr3();
		Exp exp = _0023_003DzNDQ_E88_003D * _0023_003DzNDQ_E88_003D;
		Exp exp2 = exp * _0023_003DzNDQ_E88_003D;
		return expVector2 * (3.0 * exp2 - 6.0 * exp + 3.0 * _0023_003DzNDQ_E88_003D) + expVector4 * exp2 + expVector3 * (3.0 * exp - 3.0 * exp2) - expVector * (exp2 - 3.0 * exp + 3.0 * _0023_003DzNDQ_E88_003D - 1.0);
	}

	internal override Exp _0023_003Dz2s6gjYE_003D()
	{
		return null;
	}

	internal override Exp _0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D()
	{
		return null;
	}

	internal override ExpVector _0023_003DzwwGQT0MxcNOs()
	{
		return null;
	}

	public override object Clone()
	{
		return new SketchSpline(this);
	}

	internal override void _0023_003DzjdvuhXvcm_002426()
	{
		Curve curve = (Curve)_0023_003DzZ_ilKakl9sw5();
		if (curve.ControlPoints.Length == 4)
		{
			for (int i = 0; i < 4; i++)
			{
				curve.ControlPoints[i] = new Point4D(ControlPoints[i].Position);
			}
		}
	}

	internal override ICurve _0023_003DzxXXV_0024fQ_003D()
	{
		return new Curve(3, ControlPoints.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzTFbywJJRkhuj5PD3QWuP7eQ_003D).ToList());
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657238), ControlPoints);
	}
}
