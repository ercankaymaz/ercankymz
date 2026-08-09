using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
internal sealed class ExpBasis2d : ICloneable
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Param, bool> _0023_003Dzvp4FXqXGVBNV3djM4w_003D_003D;

		public static Action<Param> _0023_003DzfboZSHzYXYu8n06YCg_003D_003D;

		internal bool _0023_003DzRJD6fhjW3fq75FBtIZHwlSI_003D(Param _0023_003DzB68dg9Q_003D)
		{
			return _0023_003DzB68dg9Q_003D.changed;
		}

		internal void _0023_003Dzaq8vDzpodmNNU9_sWtB7J2w_003D(Param _0023_003Dzlczk7GI_003D)
		{
			_0023_003Dzlczk7GI_003D.changed = false;
		}
	}

	private sealed class _0023_003DzDkRT9wtYPCVLMM854VUX6vCNGk7g : IEnumerable<Exp>, IEnumerable, IEnumerator<Exp>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exp _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ExpBasis2d _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003DzDkRT9wtYPCVLMM854VUX6vCNGk7g(int _0023_003DzU7pGb3X7Zp4G)
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
			ExpBasis2d expBasis2d = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = expBasis2d._0023_003DzGpzuFag_003D()._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - 1.0;
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = expBasis2d._0023_003Dz2JFkIIQ_003D()._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() - 1.0;
				_0023_003DzU7pGb3X7Zp4G = 2;
				return true;
			case 2:
			{
				_0023_003DzU7pGb3X7Zp4G = -1;
				ExpVector expVector = ExpVector._0023_003DzyJipUOg_003D(expBasis2d._0023_003DzGpzuFag_003D(), expBasis2d._0023_003Dz2JFkIIQ_003D());
				Exp _0023_003Dz40R7bAU_003D = ExpVector._0023_003DzBWYOAtM_003D(expBasis2d._0023_003DzGpzuFag_003D(), expBasis2d._0023_003Dz2JFkIIQ_003D());
				_0023_003DzezVIuujSK1H9 = Exp._0023_003DzmSWwcFA_003D(expVector._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D(), _0023_003Dz40R7bAU_003D) - Math.PI / 2.0;
				_0023_003DzU7pGb3X7Zp4G = 3;
				return true;
			}
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
			_0023_003DzDkRT9wtYPCVLMM854VUX6vCNGk7g _0023_003DzDkRT9wtYPCVLMM854VUX6vCNGk7g2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzDkRT9wtYPCVLMM854VUX6vCNGk7g2 = this;
			}
			else
			{
				_0023_003DzDkRT9wtYPCVLMM854VUX6vCNGk7g2 = new _0023_003DzDkRT9wtYPCVLMM854VUX6vCNGk7g(0);
				_0023_003DzDkRT9wtYPCVLMM854VUX6vCNGk7g2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzDkRT9wtYPCVLMM854VUX6vCNGk7g2;
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

	private sealed class _0023_003DzbBk4FrCSC_00240vJhd6Vw_003D_003D : IEnumerable<Param>, IEnumerable, IEnumerator<Param>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Param _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ExpBasis2d _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003DzbBk4FrCSC_00240vJhd6Vw_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
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
			ExpBasis2d expBasis2d = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = expBasis2d.ux;
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = expBasis2d.uy;
				_0023_003DzU7pGb3X7Zp4G = 2;
				return true;
			case 2:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = expBasis2d.vx;
				_0023_003DzU7pGb3X7Zp4G = 3;
				return true;
			case 3:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = expBasis2d.vy;
				_0023_003DzU7pGb3X7Zp4G = 4;
				return true;
			case 4:
				_0023_003DzU7pGb3X7Zp4G = -1;
				if (!expBasis2d.isPosParamsExternal)
				{
					_0023_003DzezVIuujSK1H9 = expBasis2d.px;
					_0023_003DzU7pGb3X7Zp4G = 5;
					return true;
				}
				break;
			case 5:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = expBasis2d.py;
				_0023_003DzU7pGb3X7Zp4G = 6;
				return true;
			case 6:
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
		private Param _0023_003Dzcbi5nOQLxptNo77Yg_0024Jc8aWyZ_0024460IrsvT18voWlqLZB4j6K0Q_003D_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		Param IEnumerator<Param>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zcbi5nOQLxptNo77Yg$Jc8aWyZ$460IrsvT18voWlqLZB4j6K0Q==
			return this._0023_003Dzcbi5nOQLxptNo77Yg_0024Jc8aWyZ_0024460IrsvT18voWlqLZB4j6K0Q_003D_003D();
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
		private IEnumerator<Param> _0023_003DzxNlvRhfIQy_0024WVUDjMQaY8aVUHXYxmRLXzqjrr_0024kou4GwVwkDgQ_003D_003D()
		{
			_0023_003DzbBk4FrCSC_00240vJhd6Vw_003D_003D _0023_003DzbBk4FrCSC_00240vJhd6Vw_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzbBk4FrCSC_00240vJhd6Vw_003D_003D2 = this;
			}
			else
			{
				_0023_003DzbBk4FrCSC_00240vJhd6Vw_003D_003D2 = new _0023_003DzbBk4FrCSC_00240vJhd6Vw_003D_003D(0);
				_0023_003DzbBk4FrCSC_00240vJhd6Vw_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzbBk4FrCSC_00240vJhd6Vw_003D_003D2;
		}

		IEnumerator<Param> IEnumerable<Param>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxNlvRhfIQy$WVUDjMQaY8aVUHXYxmRLXzqjrr$kou4GwVwkDgQ==
			return this._0023_003DzxNlvRhfIQy_0024WVUDjMQaY8aVUHXYxmRLXzqjrr_0024kou4GwVwkDgQ_003D_003D();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003DzxNlvRhfIQy_0024WVUDjMQaY8aVUHXYxmRLXzqjrr_0024kou4GwVwkDgQ_003D_003D();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	private bool isPosParamsExternal;

	internal Param px;

	internal Param py;

	internal Param ux;

	internal Param uy;

	internal Param vx;

	internal Param vy;

	[CompilerGenerated]
	private ExpVector _003Cu_003Ek__BackingField;

	[CompilerGenerated]
	private ExpVector _003Cv_003Ek__BackingField;

	[CompilerGenerated]
	private ExpVector _003Cp_003Ek__BackingField;

	protected ExpBasis2d(ExpBasis2d _0023_003DzySgeilxprQOK)
	{
		px = _0023_003DzySgeilxprQOK.px._0023_003DzqZwFarHnpOoH();
		py = _0023_003DzySgeilxprQOK.py._0023_003DzqZwFarHnpOoH();
		ux = _0023_003DzySgeilxprQOK.ux._0023_003DzqZwFarHnpOoH();
		uy = _0023_003DzySgeilxprQOK.uy._0023_003DzqZwFarHnpOoH();
		vx = _0023_003DzySgeilxprQOK.vx._0023_003DzqZwFarHnpOoH();
		vy = _0023_003DzySgeilxprQOK.vy._0023_003DzqZwFarHnpOoH();
		_0023_003DzUHFVG6c_003D(new ExpVector(px, py, 0.0));
		_0023_003DzYlbK4cc_003D(new ExpVector(ux, uy, 0.0));
		_0023_003Dzv0UNgsQ_003D(new ExpVector(vx, vy, 0.0));
		isPosParamsExternal = _0023_003DzySgeilxprQOK.isPosParamsExternal;
	}

	public ExpBasis2d()
	{
		px = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655970), 0.0);
		py = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655977), 0.0);
		ux = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655970), 1.0);
		uy = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655977), 0.0);
		vx = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655956), 0.0);
		vy = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655963), 1.0);
		_0023_003DzUHFVG6c_003D(new ExpVector(px, py, 0.0));
		_0023_003DzYlbK4cc_003D(new ExpVector(ux, uy, 0.0));
		_0023_003Dzv0UNgsQ_003D(new ExpVector(vx, vy, 0.0));
	}

	public ExpVector _0023_003DzGpzuFag_003D()
	{
		return _003Cu_003Ek__BackingField;
	}

	internal void _0023_003DzYlbK4cc_003D(ExpVector _0023_003DzPzO_0024GUk_003D)
	{
		_003Cu_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
	}

	public ExpVector _0023_003Dz2JFkIIQ_003D()
	{
		return _003Cv_003Ek__BackingField;
	}

	internal void _0023_003Dzv0UNgsQ_003D(ExpVector _0023_003DzPzO_0024GUk_003D)
	{
		_003Cv_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
	}

	public ExpVector _0023_003DzFFLKkkk_003D()
	{
		return _003Cp_003Ek__BackingField;
	}

	internal void _0023_003DzUHFVG6c_003D(ExpVector _0023_003DzPzO_0024GUk_003D)
	{
		_003Cp_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DzJ1SNHdOrtq1L(double[] _0023_003DzHSO_00246A0_003D)
	{
		int num = 0;
		foreach (Param item in _0023_003DzGVWngirLnmOL())
		{
			item._0023_003DzO_0024HwSzQ_003D(_0023_003DzHSO_00246A0_003D[num]);
			num++;
		}
	}

	internal void _0023_003DzOjiryAH4CnPe(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D)
	{
		px._0023_003DzO_0024HwSzQ_003D(_0023_003DzBJFJHwk_003D);
		py._0023_003DzO_0024HwSzQ_003D(_0023_003Dz40R7bAU_003D);
		_0023_003DzFFLKkkk_003D().x = px;
		_0023_003DzFFLKkkk_003D().y = py;
		isPosParamsExternal = true;
	}

	internal void _0023_003DzOjiryAH4CnPe(Param _0023_003DzBJFJHwk_003D, Param _0023_003Dz40R7bAU_003D)
	{
		px = _0023_003DzBJFJHwk_003D;
		py = _0023_003Dz40R7bAU_003D;
		_0023_003DzFFLKkkk_003D().x = px;
		_0023_003DzFFLKkkk_003D().y = py;
		isPosParamsExternal = true;
	}

	internal void _0023_003DzNKqPBn1ISogO(Vector2D _0023_003DzVlAX6WI_003D, Vector2D _0023_003DzmScrddQ_003D)
	{
		ux._0023_003DzO_0024HwSzQ_003D(_0023_003DzVlAX6WI_003D.X);
		uy._0023_003DzO_0024HwSzQ_003D(_0023_003DzVlAX6WI_003D.Y);
		vx._0023_003DzO_0024HwSzQ_003D(_0023_003DzmScrddQ_003D.X);
		vy._0023_003DzO_0024HwSzQ_003D(_0023_003DzmScrddQ_003D.Y);
	}

	[IteratorStateMachine(typeof(_0023_003DzbBk4FrCSC_00240vJhd6Vw_003D_003D))]
	public IEnumerable<Param> _0023_003DzGVWngirLnmOL()
	{
		return new _0023_003DzbBk4FrCSC_00240vJhd6Vw_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	public override string ToString()
	{
		string text = string.Empty;
		foreach (Param item in _0023_003DzGVWngirLnmOL())
		{
			text = text + item._0023_003DzV29zQ3g_003D()._0023_003Dz1eU15ZU_003D() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382);
		}
		return text;
	}

	public object Clone()
	{
		return new ExpBasis2d(this);
	}

	public void _0023_003DzmWeZeOY_003D(string _0023_003Dz_0024n2nrac_003D)
	{
		char[] separator = new char[1] { ' ' };
		string[] array = _0023_003Dz_0024n2nrac_003D.Split(separator, StringSplitOptions.RemoveEmptyEntries);
		int num = 0;
		foreach (Param item in _0023_003DzGVWngirLnmOL())
		{
			item._0023_003DzO_0024HwSzQ_003D(array[num]._0023_003DzR61OsnE_003D());
			num++;
		}
	}

	public ExpVector _0023_003Dzcw7M7n87_FwJ(ExpVector _0023_003DzpdeSbFA_003D)
	{
		return _0023_003DzpdeSbFA_003D.x * _0023_003DzGpzuFag_003D() + _0023_003DzpdeSbFA_003D.y * _0023_003Dz2JFkIIQ_003D() + _0023_003DzFFLKkkk_003D();
	}

	public ExpVector _0023_003DzUfWqQXFmqsqU(ExpVector _0023_003DzCJkr8nY_003D)
	{
		return _0023_003DzCJkr8nY_003D.x * _0023_003DzGpzuFag_003D() + _0023_003DzCJkr8nY_003D.y * _0023_003Dz2JFkIIQ_003D();
	}

	public ExpVector _0023_003DzwzELtoHWMa8y(ExpVector _0023_003DzCJkr8nY_003D)
	{
		ExpVector expVector = new ExpVector(_0023_003DzGpzuFag_003D().x, _0023_003Dz2JFkIIQ_003D().x, 0.0);
		ExpVector expVector2 = new ExpVector(_0023_003DzGpzuFag_003D().y, _0023_003Dz2JFkIIQ_003D().y, 0.0);
		return _0023_003DzCJkr8nY_003D.x * expVector + _0023_003DzCJkr8nY_003D.y * expVector2;
	}

	public void _0023_003DzDNS_0024gnq0318I1_h2vg_003D_003D(_0023_003Dz0PG7zd8xbyOk1MUCYsEf4yW9urSFrmaw_TcB_0024AI_003D _0023_003DzWvO4rTE_003D)
	{
		_0023_003DzWvO4rTE_003D._0023_003DzIAHusRU_003D(_0023_003DzGVWngirLnmOL());
		_0023_003DzWvO4rTE_003D._0023_003DzSJnfST_p7FvhG2o4OQ_003D_003D(_0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D());
	}

	[IteratorStateMachine(typeof(_0023_003DzDkRT9wtYPCVLMM854VUX6vCNGk7g))]
	public IEnumerable<Exp> _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D()
	{
		return new _0023_003DzDkRT9wtYPCVLMM854VUX6vCNGk7g(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	public bool _0023_003Dz13lPq0IVPigD()
	{
		return _0023_003DzGVWngirLnmOL().Any(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzRJD6fhjW3fq75FBtIZHwlSI_003D);
	}

	public void _0023_003DznRWLZJkEPtts()
	{
		_0023_003DzGVWngirLnmOL()._0023_003DzIAB23y8_003D(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzaq8vDzpodmNNU9_sWtB7J2w_003D);
	}
}
