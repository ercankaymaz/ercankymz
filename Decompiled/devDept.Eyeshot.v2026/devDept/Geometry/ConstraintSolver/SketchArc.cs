using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class SketchArc : SketchCircle, ISketchCurve
{
	private sealed class _0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy : IEnumerable<Exp>, IEnumerable, IEnumerator<Exp>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exp _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchArc _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy(int _0023_003DzU7pGb3X7Zp4G)
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
			SketchArc sketchArc = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				if (!sketchArc._startPoint._0023_003DzcC394h_GqnXLOnrbsRJh_00248Y_003D(sketchArc._endPoint))
				{
					_0023_003DzezVIuujSK1H9 = (sketchArc._startPoint._0023_003Dzuc1z_scDJBr3() - sketchArc.c._0023_003Dzuc1z_scDJBr3())._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - (sketchArc._endPoint._0023_003Dzuc1z_scDJBr3() - sketchArc.c._0023_003Dzuc1z_scDJBr3())._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D();
					_0023_003DzU7pGb3X7Zp4G = 1;
					return true;
				}
				break;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				break;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private Exp _0023_003DzrviWB3pX4aygbl_17Orc7N9qPUNGocHMKh7jYBdyaxoDXlSWgg_003D_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		Exp IEnumerator<Exp>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zrviWB3pX4aygbl_17Orc7N9qPUNGocHMKh7jYBdyaxoDXlSWgg==
			return this._0023_003DzrviWB3pX4aygbl_17Orc7N9qPUNGocHMKh7jYBdyaxoDXlSWgg_003D_003D();
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
		private IEnumerator<Exp> _0023_003DztMDWff9LdO44LVWz0lctyytpHTDFlOxLsjTv_0024MbIdl_IomwTLQ_003D_003D()
		{
			_0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy _0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy2 = this;
			}
			else
			{
				_0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy2 = new _0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy(0);
				_0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy2;
		}

		IEnumerator<Exp> IEnumerable<Exp>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=ztMDWff9LdO44LVWz0lctyytpHTDFlOxLsjTv$MbIdl_IomwTLQ==
			return this._0023_003DztMDWff9LdO44LVWz0lctyytpHTDFlOxLsjTv_0024MbIdl_IomwTLQ_003D_003D();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003DztMDWff9LdO44LVWz0lctyytpHTDFlOxLsjTv_0024MbIdl_IomwTLQ_003D_003D();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	private sealed class _0023_003Dzucdn3Qkn178GVpGZOQ_003D_003D : IEnumerable<SketchPoint>, IEnumerable, IEnumerator<SketchPoint>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SketchPoint _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchArc _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003Dzucdn3Qkn178GVpGZOQ_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
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
			SketchArc sketchArc = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = sketchArc._startPoint;
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = sketchArc._endPoint;
				_0023_003DzU7pGb3X7Zp4G = 2;
				return true;
			case 2:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = sketchArc.c;
				_0023_003DzU7pGb3X7Zp4G = 3;
				return true;
			case 3:
				_0023_003DzU7pGb3X7Zp4G = -1;
				return false;
			}
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
			_0023_003Dzucdn3Qkn178GVpGZOQ_003D_003D _0023_003Dzucdn3Qkn178GVpGZOQ_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003Dzucdn3Qkn178GVpGZOQ_003D_003D2 = this;
			}
			else
			{
				_0023_003Dzucdn3Qkn178GVpGZOQ_003D_003D2 = new _0023_003Dzucdn3Qkn178GVpGZOQ_003D_003D(0);
				_0023_003Dzucdn3Qkn178GVpGZOQ_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003Dzucdn3Qkn178GVpGZOQ_003D_003D2;
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

	internal SketchPoint _startPoint;

	internal SketchPoint _endPoint;

	public SketchPoint StartPoint => _startPoint;

	public SketchPoint EndPoint => _endPoint;

	public Vector3D[] SegmentPoints
	{
		get
		{
			double num = Utility.RadToDeg(_0023_003Dz_OdYU2o_003D());
			Vector3D vector3D = c._0023_003DzOy1CtAC3DuWW();
			Vector3D vector3D2 = _startPoint._0023_003DzOy1CtAC3DuWW() - vector3D;
			int num2 = Math.Max(Math.Abs((int)Math.Ceiling(num / 10.0)), 1);
			Vector3D[] array = new Vector3D[num2];
			Rotation rotation = new Rotation(axis: Vector3D.AxisZ, angleInRadians: num / (double)num2);
			for (int i = 0; i < num2; i++)
			{
				array[i] = vector3D2 + vector3D;
				vector3D2 = rotation * vector3D2;
			}
			return array;
		}
	}

	public override double Radius
	{
		get
		{
			return _0023_003Dz016ilyGI7o1a2mNIYw_003D_003D()._0023_003DzBUjqlpM_003D();
		}
		set
		{
			radius._0023_003DzO_0024HwSzQ_003D(value);
		}
	}

	protected SketchArc(SketchArc another)
		: base(another)
	{
		_startPoint = AddChild((SketchPoint)another._startPoint.Clone());
		_endPoint = AddChild((SketchPoint)another._endPoint.Clone());
	}

	internal SketchArc(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_startPoint = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		_endPoint = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
	}

	internal SketchArc(SketchInternal _0023_003DzjCETKTg_003D, SketchPoint _0023_003DzbUvT9Pc_003D, Point2D _0023_003Dz3k5Uze_VdwnF, Point2D _0023_003DzMnu3zKCWb6Kc)
		: base(_0023_003DzjCETKTg_003D, _0023_003DzbUvT9Pc_003D)
	{
		_startPoint = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		_endPoint = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		_startPoint._0023_003DzF56xZpo_003D(_0023_003Dz3k5Uze_VdwnF.X, _0023_003Dz3k5Uze_VdwnF.Y);
		_endPoint._0023_003DzF56xZpo_003D(_0023_003DzMnu3zKCWb6Kc.X, _0023_003DzMnu3zKCWb6Kc.Y);
	}

	internal SketchArc(SketchInternal _0023_003DzjCETKTg_003D, SketchPoint _0023_003DzbUvT9Pc_003D, SketchPoint _0023_003Dz3k5Uze_VdwnF, Point2D _0023_003DzMnu3zKCWb6Kc)
		: base(_0023_003DzjCETKTg_003D, _0023_003DzbUvT9Pc_003D)
	{
		_startPoint = AddChild(_0023_003Dz3k5Uze_VdwnF);
		_endPoint = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		_endPoint._0023_003DzF56xZpo_003D(_0023_003DzMnu3zKCWb6Kc.X, _0023_003DzMnu3zKCWb6Kc.Y);
	}

	internal SketchArc(SketchInternal _0023_003DzjCETKTg_003D, Point2D _0023_003DzbUvT9Pc_003D, Point2D _0023_003Dz3k5Uze_VdwnF, SketchPoint _0023_003DzMnu3zKCWb6Kc)
		: base(_0023_003DzjCETKTg_003D)
	{
		_startPoint = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		_endPoint = AddChild(_0023_003DzMnu3zKCWb6Kc);
		_startPoint._0023_003DzF56xZpo_003D(_0023_003Dz3k5Uze_VdwnF.X, _0023_003Dz3k5Uze_VdwnF.Y);
		c._0023_003DzF56xZpo_003D(_0023_003DzbUvT9Pc_003D.X, _0023_003DzbUvT9Pc_003D.Y);
	}

	protected SketchArc(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_startPoint = (SketchPoint)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656532), typeof(SketchPoint));
		_endPoint = (SketchPoint)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656515), typeof(SketchPoint));
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy))]
	internal override IEnumerable<Exp> _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D()
	{
		return new _0023_003DzWenArCRVJfIBcd_l2LPmAyR41pQy(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	[SpecialName]
	internal override IEnumerable<Param> _0023_003DzGVWngirLnmOL()
	{
		return new List<Param>();
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003Dzucdn3Qkn178GVpGZOQ_003D_003D))]
	internal override IEnumerable<SketchPoint> _0023_003DzgJiUT1qDtKLT()
	{
		return new _0023_003Dzucdn3Qkn178GVpGZOQ_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	internal override void _0023_003DzUNQ_t5U_003D(Transformation _0023_003DzLS0sR0pzioXc)
	{
		base._0023_003DzUNQ_t5U_003D(_0023_003DzLS0sR0pzioXc);
		if (_0023_003DzLS0sR0pzioXc.HasReflection)
		{
			Reverse();
		}
	}

	internal override bool _0023_003Dztl9hmdI_003D()
	{
		if (!_startPoint._0023_003Dztl9hmdI_003D() && !_endPoint._0023_003Dztl9hmdI_003D())
		{
			return c._0023_003Dztl9hmdI_003D();
		}
		return true;
	}

	internal Exp _0023_003Dzo6Exr5vIiWd9()
	{
		if (!_startPoint._0023_003DzcC394h_GqnXLOnrbsRJh_00248Y_003D(_endPoint))
		{
			ExpVector _0023_003DzizVqTKE_003D = _startPoint._0023_003Dzuc1z_scDJBr3() - c._0023_003Dzuc1z_scDJBr3();
			ExpVector _0023_003Dzt38nTwk_003D = _endPoint._0023_003Dzuc1z_scDJBr3() - c._0023_003Dzuc1z_scDJBr3();
			return _0023_003DzMr7dyDtNhE5ce7x_0024P8Wmwj_B7hbJ._0023_003Dz5wNeT2sDg28l(_0023_003DzizVqTKE_003D, _0023_003Dzt38nTwk_003D, _0023_003DzYRitoXujv8Dc: true);
		}
		return Math.PI * 2.0;
	}

	internal void _0023_003Dze8HLGHdo_0024aUJ(SketchPoint _0023_003DzPzO_0024GUk_003D)
	{
		_startPoint = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DzkiChZxXAOBwG(SketchPoint _0023_003DzPzO_0024GUk_003D)
	{
		_endPoint = _0023_003DzPzO_0024GUk_003D;
	}

	public override void Reverse()
	{
		SketchPoint endPoint = EndPoint;
		SketchPoint startPoint = StartPoint;
		_0023_003Dze8HLGHdo_0024aUJ(endPoint);
		_0023_003DzkiChZxXAOBwG(startPoint);
	}

	private double _0023_003Dz_OdYU2o_003D()
	{
		Vector3D vector3D = _startPoint._0023_003DzOy1CtAC3DuWW() - c._0023_003DzOy1CtAC3DuWW();
		vector3D.Normalize();
		Vector3D vector3D2 = _endPoint._0023_003DzOy1CtAC3DuWW() - c._0023_003DzOy1CtAC3DuWW();
		vector3D2.Normalize();
		double num = Vector3D.AngleBetween(vector3D, vector3D2);
		if (num <= 0.0)
		{
			num += Math.PI * 2.0;
		}
		return num;
	}

	internal Exp _0023_003Dz016ilyGI7o1a2mNIYw_003D_003D()
	{
		return (_startPoint._0023_003Dzuc1z_scDJBr3() - c._0023_003Dzuc1z_scDJBr3())._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D();
	}

	protected internal override SketchCurve OnSplit(Vector3D position)
	{
		SketchArc sketchArc = new SketchArc(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D());
		sketchArc.Center._0023_003Dzp88PjKDmx6K1(base.Center._0023_003DzOy1CtAC3DuWW());
		sketchArc._endPoint._0023_003Dzp88PjKDmx6K1(_endPoint._0023_003DzOy1CtAC3DuWW());
		_endPoint._0023_003Dzp88PjKDmx6K1(position);
		sketchArc._startPoint._0023_003Dzp88PjKDmx6K1(_endPoint._0023_003DzOy1CtAC3DuWW());
		return sketchArc;
	}

	internal override ExpVector _0023_003Dz1D2_0024pLU_003D(Exp _0023_003DzNDQ_E88_003D)
	{
		Exp exp = _0023_003Dzo6Exr5vIiWd9();
		Exp exp2 = Exp._0023_003DzHqHPcG0_003D(exp * _0023_003DzNDQ_E88_003D);
		Exp exp3 = Exp._0023_003DzzFteY6c_003D(exp * _0023_003DzNDQ_E88_003D);
		ExpVector expVector = _startPoint._0023_003Dzuc1z_scDJBr3() - c._0023_003Dzuc1z_scDJBr3();
		return c._0023_003Dzuc1z_scDJBr3() + new ExpVector(exp2 * expVector.x - exp3 * expVector.y, exp3 * expVector.x + exp2 * expVector.y, 0.0);
	}

	internal override ExpVector _0023_003DznwYbRgIzSbCB(Exp _0023_003DzNDQ_E88_003D)
	{
		Exp exp = _0023_003Dzo6Exr5vIiWd9();
		Exp exp2 = Exp._0023_003DzHqHPcG0_003D(exp * _0023_003DzNDQ_E88_003D + Math.PI / 2.0);
		Exp exp3 = Exp._0023_003DzzFteY6c_003D(exp * _0023_003DzNDQ_E88_003D + Math.PI / 2.0);
		ExpVector expVector = _startPoint._0023_003Dzuc1z_scDJBr3() - c._0023_003Dzuc1z_scDJBr3();
		return new ExpVector(exp2 * expVector.x - exp3 * expVector.y, exp3 * expVector.x + exp2 * expVector.y, 0.0);
	}

	internal override Exp _0023_003Dz2s6gjYE_003D()
	{
		return _0023_003Dzo6Exr5vIiWd9() * _0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D();
	}

	internal override Exp _0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D()
	{
		return (_startPoint._0023_003Dzuc1z_scDJBr3() - c._0023_003Dzuc1z_scDJBr3())._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D();
	}

	internal override ExpVector _0023_003DzwwGQT0MxcNOs()
	{
		return c._0023_003Dzuc1z_scDJBr3();
	}

	internal override void _0023_003DzjdvuhXvcm_002426()
	{
		Arc obj = (Arc)_0023_003DzZ_ilKakl9sw5();
		Point3D first = StartPoint.Position;
		Point3D second = EndPoint.Position;
		Point3D position = base.Center.Position;
		if (Vector3D.AreOpposite(obj.Plane.AxisZ, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane.AxisZ, 0.01))
		{
			Utility.Swap(ref first, ref second);
		}
		Vector3D vector3D = new Vector3D(base.Center.Position, StartPoint.Position);
		Plane plane = new Plane(base.Center.Position, vector3D, Vector3D.Cross(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane.AxisZ, vector3D));
		Arc arc = new Arc(plane, plane.Project(position), plane.Project(first), plane.Project(second));
		if (arc.Domain.Length < 1E-12)
		{
			arc.Domain = new Interval(arc.Domain.t0, arc.Domain.t0 + Utility._0023_003DzheSR8QM7q9ya);
		}
		obj.Domain = arc.Domain;
		obj.Plane = arc.Plane;
		obj.Radius = arc.Radius;
		obj.Center = arc.Center;
	}

	internal override ICurve _0023_003DzxXXV_0024fQ_003D()
	{
		return new Arc(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane, base.Center.PlanePosition, StartPoint.PlanePosition, EndPoint.PlanePosition);
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new SketchArcSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656532), _startPoint);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656515), _endPoint);
	}

	public override object Clone()
	{
		return new SketchArc(this);
	}
}
