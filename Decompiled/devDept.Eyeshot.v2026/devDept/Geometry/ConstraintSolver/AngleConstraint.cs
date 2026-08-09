using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class AngleConstraint : ValueConstraint
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<ExpVector, Vector3D> _0023_003DzwwY5ZBi2wUYuUPrxAA_003D_003D;

		internal Vector3D _0023_003DzOfzKLKlDe0wFP7JoolgwBMvH7S7R(ExpVector _0023_003Dz79R_0024VZY_003D)
		{
			return _0023_003Dz79R_0024VZY_003D._0023_003DzBUjqlpM_003D();
		}
	}

	private sealed class _0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e7 : IEnumerable<Exp>, IEnumerable, IEnumerator<Exp>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exp _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AngleConstraint _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e7(int _0023_003DzU7pGb3X7Zp4G)
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
			AngleConstraint angleConstraint = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_0023_003DzU7pGb3X7Zp4G = -1;
				bool _0023_003DzYRitoXujv8Dc = angleConstraint._0023_003Dz1uzJIBKKgWz8<SketchArc>(1);
				ExpVector[] array = angleConstraint._0023_003Dzyrip106UpNY2(angleConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
				ExpVector _0023_003DzizVqTKE_003D = array[0] - array[1];
				ExpVector _0023_003Dzt38nTwk_003D = array[3] - array[2];
				Exp exp = (angleConstraint._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().is3d ? _0023_003DzMr7dyDtNhE5ce7x_0024P8Wmwj_B7hbJ._0023_003DzwnmeKH36nol2(_0023_003DzizVqTKE_003D, _0023_003Dzt38nTwk_003D) : _0023_003DzMr7dyDtNhE5ce7x_0024P8Wmwj_B7hbJ._0023_003Dz5wNeT2sDg28l(_0023_003DzizVqTKE_003D, _0023_003Dzt38nTwk_003D, _0023_003DzYRitoXujv8Dc));
				_0023_003DzezVIuujSK1H9 = exp - angleConstraint.value;
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			}
			case 1:
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
			_0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e7 _0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e8;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e8 = this;
			}
			else
			{
				_0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e8 = new _0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e7(0);
				_0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e8._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e8;
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

	private bool supplementary_;

	protected AngleConstraint(AngleConstraint another)
		: base(another)
	{
		supplementary_ = another.supplementary_;
	}

	internal AngleConstraint(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
	}

	internal AngleConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve[] _0023_003DzrdSL0CI_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		foreach (SketchCurve _0023_003DzbfrNXYE_003D in _0023_003DzrdSL0CI_003D)
		{
			_0023_003DzRCrpdGA_003D(_0023_003DzbfrNXYE_003D);
		}
		_0023_003Dz_09KxNE_003D();
	}

	internal AngleConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003DzN4MDZ_0024c_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzRCrpdGA_003D(_0023_003DzN4MDZ_0024c_003D);
		value._0023_003DzO_0024HwSzQ_003D(Math.PI / 4.0);
		_0023_003Dz_09KxNE_003D();
	}

	internal AngleConstraint(SketchInternal _0023_003DzjCETKTg_003D, SketchCurve _0023_003DzEIpBwhg_003D, SketchCurve _0023_003DziMjqlCo_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		_0023_003DzRCrpdGA_003D(_0023_003DzEIpBwhg_003D);
		_0023_003DzRCrpdGA_003D(_0023_003DziMjqlCo_003D);
		_0023_003Dz_09KxNE_003D();
	}

	protected AngleConstraint(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_0023_003DzA_WUrzZQ5SEjFakyKPc32NE_003D(info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655294)));
	}

	internal bool _0023_003Dz_eR8HRf3mFd11k584VDLJGw_003D()
	{
		return supplementary_;
	}

	internal void _0023_003DzA_WUrzZQ5SEjFakyKPc32NE_003D(bool _0023_003DzPzO_0024GUk_003D)
	{
		if (_0023_003DzPzO_0024GUk_003D == supplementary_)
		{
			return;
		}
		supplementary_ = _0023_003DzPzO_0024GUk_003D;
		if (_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D() != null && _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D()._0023_003DzlGXalEw_003D())
		{
			if (_0023_003Dz1uzJIBKKgWz8<SketchArc>(1))
			{
				value._0023_003DzO_0024HwSzQ_003D(Math.PI * 2.0 - value._0023_003DzV29zQ3g_003D());
			}
			else
			{
				value._0023_003DzO_0024HwSzQ_003D(0.0 - ((double)Math.Sign(value._0023_003DzV29zQ3g_003D()) * Math.PI - value._0023_003DzV29zQ3g_003D()));
			}
		}
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e7))]
	internal override IEnumerable<Exp> _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D()
	{
		return new _0023_003DzVyY8axO2M0gfjoHHUy_0024FgrPhY2e7(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	private Vector3D[] _0023_003Dz_0024QhhaksmW62Y7OJ9mA_003D_003D(_0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		return _0023_003Dzyrip106UpNY2(_0023_003Dzrgqz890sj_0024X9).Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzOfzKLKlDe0wFP7JoolgwBMvH7S7R).ToArray();
	}

	private Vector3D[] _0023_003DzfHSvFLY_003D()
	{
		return _0023_003Dz_0024QhhaksmW62Y7OJ9mA_003D_003D(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane);
	}

	private ExpVector[] _0023_003Dzyrip106UpNY2(_0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		ExpVector[] array = new ExpVector[4];
		if (_0023_003Dz1uzJIBKKgWz8<SketchPoint>(4))
		{
			for (int i = 0; i < 4; i++)
			{
				array[i] = _0023_003DzCobWdDk49r6E<SketchPoint>(i)._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(0, _0023_003Dzrgqz890sj_0024X9);
			}
			if (_0023_003Dz_eR8HRf3mFd11k584VDLJGw_003D())
			{
				Utility.Swap(ref array[2], ref array[3]);
			}
		}
		else if (_0023_003Dz1uzJIBKKgWz8<SketchPoint>(3))
		{
			array[0] = _0023_003DzCobWdDk49r6E<SketchPoint>(0)._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(0, _0023_003Dzrgqz890sj_0024X9);
			array[1] = _0023_003DzCobWdDk49r6E<SketchPoint>(1)._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(0, _0023_003Dzrgqz890sj_0024X9);
			array[2] = array[1];
			array[3] = _0023_003DzCobWdDk49r6E<SketchPoint>(2)._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(0, _0023_003Dzrgqz890sj_0024X9);
			if (_0023_003Dz_eR8HRf3mFd11k584VDLJGw_003D())
			{
				Utility.Swap(ref array[2], ref array[3]);
			}
		}
		else if (_0023_003Dz1uzJIBKKgWz8<SketchLine>(2))
		{
			SketchCurve _0023_003Dz8fpRyMu9aKjE = _0023_003DzCobWdDk49r6E<SketchLine>(0);
			array[0] = _0023_003Dz8fpRyMu9aKjE._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(0, _0023_003Dzrgqz890sj_0024X9);
			array[1] = _0023_003Dz8fpRyMu9aKjE._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(1, _0023_003Dzrgqz890sj_0024X9);
			SketchCurve _0023_003Dz8fpRyMu9aKjE2 = _0023_003DzCobWdDk49r6E<SketchLine>(1);
			array[2] = _0023_003Dz8fpRyMu9aKjE2._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(0, _0023_003Dzrgqz890sj_0024X9);
			array[3] = _0023_003Dz8fpRyMu9aKjE2._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(1, _0023_003Dzrgqz890sj_0024X9);
			if (_0023_003Dz_eR8HRf3mFd11k584VDLJGw_003D())
			{
				Utility.Swap(ref array[2], ref array[3]);
			}
		}
		else if (_0023_003Dz1uzJIBKKgWz8<SketchArc>(1))
		{
			SketchCurve _0023_003Dz8fpRyMu9aKjE3 = _0023_003DzCobWdDk49r6E<SketchArc>(0);
			array[0] = _0023_003Dz8fpRyMu9aKjE3._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(0, _0023_003Dzrgqz890sj_0024X9);
			array[1] = _0023_003Dz8fpRyMu9aKjE3._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(2, _0023_003Dzrgqz890sj_0024X9);
			array[2] = _0023_003Dz8fpRyMu9aKjE3._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(2, _0023_003Dzrgqz890sj_0024X9);
			array[3] = _0023_003Dz8fpRyMu9aKjE3._0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(1, _0023_003Dzrgqz890sj_0024X9);
			if (_0023_003Dz_eR8HRf3mFd11k584VDLJGw_003D())
			{
				Utility.Swap(ref array[0], ref array[3]);
				Utility.Swap(ref array[1], ref array[2]);
			}
		}
		return array;
	}

	private protected override Transformation _0023_003DzKPUxzjlpDSMi()
	{
		Vector3D[] array = _0023_003DzfHSvFLY_003D();
		Vector3D vector3D = array[1];
		double num = Math.Abs(GetValue());
		Vector3D vector3D2 = new Vector3D(0.0, 0.0, 0.0);
		if (Math.Abs(Math.Abs(num) - 180.0) < 9.999999747378752E-05)
		{
			vector3D = array[1];
			if (_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane != null)
			{
				vector3D2 = _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane._0023_003DzhuTGsQI_003D();
				vector3D2.Negate();
			}
		}
		else
		{
			Vector3D vector3D3 = array[1] - array[0];
			Vector3D vector3D4 = array[3] - array[2];
			Vector3D vector3D5 = new Vector3D(vector3D3.Y, 0.0 - vector3D3.X);
			Vector3D vector3D6 = new Vector3D(vector3D4.Y, 0.0 - vector3D4.X);
			vector3D5.Z = 0.0 - Vector3D.Dot(array[0], vector3D5);
			vector3D6.Z = 0.0 - Vector3D.Dot(array[2], vector3D6);
			vector3D = Vector3D.Cross(vector3D5, vector3D6);
			bool flag;
			if (Math.Abs(vector3D.Z) < 2.220446049250313E-16)
			{
				flag = false;
			}
			else
			{
				vector3D.X /= vector3D.Z;
				vector3D.Y /= vector3D.Z;
				vector3D.Z = 0.0;
				flag = true;
			}
			if (flag)
			{
				vector3D2 = Vector3D.Cross(array[0] - array[1], array[3] - array[2]);
				vector3D2.Normalize();
			}
		}
		if (vector3D2.Length < 1E-12)
		{
			vector3D2 = new Vector3D(0.0, 0.0, 1.0);
		}
		Vector3D vector3D7 = new Rotation(num / 2.0, vector3D2) * (array[0] - array[1]);
		vector3D7.Normalize();
		Vector3D vector3D8 = Vector3D.Cross(vector3D7, vector3D2);
		vector3D8.Normalize();
		Plane plane = new Plane(new Point3D(vector3D.ToArray()), vector3D8, vector3D7);
		plane.TransformBy(_0023_003DzNY5YUv279_SW()._0023_003Dz7d5lgPw_003D());
		return new Align3D(Plane.XY, plane);
	}

	private protected override void _0023_003DzIq_QSAJB6ejc(XmlNode _0023_003Dzzic3a9w_003D)
	{
		if (_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655250)] != null)
		{
			supplementary_ = Convert.ToBoolean(_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655250)].Value);
		}
	}

	private protected override void _0023_003DzGwY28g5pY8a7(XmlTextWriter _0023_003Dzzic3a9w_003D)
	{
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655250), _0023_003Dz_eR8HRf3mFd11k584VDLJGw_003D().ToString());
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new AngleConstraintSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655294), supplementary_);
	}

	public override object Clone()
	{
		return new AngleConstraint(this);
	}

	internal override Constraint _0023_003DzXITeosZelhmK(SketchCurve _0023_003Dz0itaRPgnFJP7nMXQGA_003D_003D, SketchCurve _0023_003Dzxjboi6Lm3wPAQpzt4A_003D_003D = null)
	{
		return new AngleConstraint(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D(), _0023_003Dz0itaRPgnFJP7nMXQGA_003D_003D, _0023_003Dzxjboi6Lm3wPAQpzt4A_003D_003D);
	}
}
