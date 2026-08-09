using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

internal static class _0023_003Dz_biLHvnc7MZXgpsebiV90gH7DuB4ihHsbQ_003D_003D
{
	private sealed class _0023_003DzCluSZf1436sp4vA3Vq54uf4_003D : IEnumerable<ExpVector>, IEnumerable, IEnumerator<ExpVector>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExpVector _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003DzAcfDX51Wlhd41ne5mQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SketchCurve _0023_003Dz8fpRyMu9aKjE;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchCurve _0023_003DzFf67v1RK1BCODpa6JQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IEnumerator<ExpVector> _0023_003DzFG3sANyTBzy1KVLUgQ_003D_003D;

		[DebuggerHidden]
		public _0023_003DzCluSZf1436sp4vA3Vq54uf4_003D(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			_0023_003DzFG3sANyTBzy1KVLUgQ_003D_003D = null;
			_0023_003DzU7pGb3X7Zp4G = -2;
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zc0uzWO$CiiAh6KSB0g==
			this._0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
		}

		private bool MoveNext()
		{
			switch (_0023_003DzU7pGb3X7Zp4G)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				if (_0023_003Dzrgqz890sj_0024X9 == _0023_003Dz8fpRyMu9aKjE._0023_003Dz_0024B4JBsGot9sy())
				{
					_0023_003DzFG3sANyTBzy1KVLUgQ_003D_003D = _0023_003Dz8fpRyMu9aKjE._0023_003DzMiXki3_0024IvHM9ZDMTyK3_rVc_003D().GetEnumerator();
					goto IL_006e;
				}
				goto IL_0082;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				goto IL_006e;
			case 2:
				{
					_0023_003DzU7pGb3X7Zp4G = -1;
					break;
				}
				IL_006e:
				if (_0023_003DzFG3sANyTBzy1KVLUgQ_003D_003D.MoveNext())
				{
					_0023_003DzezVIuujSK1H9 = _0023_003DzFG3sANyTBzy1KVLUgQ_003D_003D.Current;
					_0023_003DzU7pGb3X7Zp4G = 1;
					return true;
				}
				_0023_003DzFG3sANyTBzy1KVLUgQ_003D_003D = null;
				goto IL_0082;
				IL_0082:
				_0023_003DzFG3sANyTBzy1KVLUgQ_003D_003D = _0023_003Dz8fpRyMu9aKjE._0023_003DzMiXki3_0024IvHM9ZDMTyK3_rVc_003D().GetEnumerator();
				break;
			}
			if (_0023_003DzFG3sANyTBzy1KVLUgQ_003D_003D.MoveNext())
			{
				_0023_003DzezVIuujSK1H9 = _0023_003Dzrgqz890sj_0024X9._0023_003Dz1binOM8_003D(_0023_003DzFG3sANyTBzy1KVLUgQ_003D_003D.Current, _0023_003Dz8fpRyMu9aKjE._0023_003Dz_0024B4JBsGot9sy());
				_0023_003DzU7pGb3X7Zp4G = 2;
				return true;
			}
			_0023_003DzFG3sANyTBzy1KVLUgQ_003D_003D = null;
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private ExpVector _0023_003DzzzGXgtbooM5iu7x1SCJTVqcM5uAXFyqkk45qT4yOWgyBtO6HlctVrbg_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		ExpVector IEnumerator<ExpVector>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zzzGXgtbooM5iu7x1SCJTVqcM5uAXFyqkk45qT4yOWgyBtO6HlctVrbg=
			return this._0023_003DzzzGXgtbooM5iu7x1SCJTVqcM5uAXFyqkk45qT4yOWgyBtO6HlctVrbg_003D();
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
		private IEnumerator<ExpVector> _0023_003DzE6N_MQXdscypkFXFFWdJGcHZD_0024cycJk_0024Zaiyz9k0enhoJOCoXBBtjIs_003D()
		{
			_0023_003DzCluSZf1436sp4vA3Vq54uf4_003D _0023_003DzCluSZf1436sp4vA3Vq54uf4_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzCluSZf1436sp4vA3Vq54uf4_003D2 = this;
			}
			else
			{
				_0023_003DzCluSZf1436sp4vA3Vq54uf4_003D2 = new _0023_003DzCluSZf1436sp4vA3Vq54uf4_003D(0);
			}
			_0023_003DzCluSZf1436sp4vA3Vq54uf4_003D2._0023_003Dz8fpRyMu9aKjE = _0023_003DzFf67v1RK1BCODpa6JQ_003D_003D;
			_0023_003DzCluSZf1436sp4vA3Vq54uf4_003D2._0023_003Dzrgqz890sj_0024X9 = _0023_003DzAcfDX51Wlhd41ne5mQ_003D_003D;
			return _0023_003DzCluSZf1436sp4vA3Vq54uf4_003D2;
		}

		IEnumerator<ExpVector> IEnumerable<ExpVector>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zE6N_MQXdscypkFXFFWdJGcHZD$cycJk$Zaiyz9k0enhoJOCoXBBtjIs=
			return this._0023_003DzE6N_MQXdscypkFXFFWdJGcHZD_0024cycJk_0024Zaiyz9k0enhoJOCoXBBtjIs_003D();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003DzE6N_MQXdscypkFXFFWdJGcHZD_0024cycJk_0024Zaiyz9k0enhoJOCoXBBtjIs_003D();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	public static ExpVector _0023_003Dz37OPKlxi4S3U(this SketchCurve _0023_003DzfjVos4c_003D, Exp _0023_003DzNDQ_E88_003D)
	{
		return _0023_003DzfjVos4c_003D._0023_003DzTYUQTQfCxvrs9fo_NA_003D_003D(_0023_003DzNDQ_E88_003D, _0023_003DzfjVos4c_003D._0023_003Dz_0024B4JBsGot9sy());
	}

	public static ExpVector _0023_003DzTYUQTQfCxvrs9fo_NA_003D_003D(this SketchCurve _0023_003DzfjVos4c_003D, Exp _0023_003DzNDQ_E88_003D, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		if (_0023_003DzfjVos4c_003D._0023_003Dz_0024B4JBsGot9sy() != null)
		{
			ExpVector expVector = _0023_003DzfjVos4c_003D._0023_003DznwYbRgIzSbCB(_0023_003DzNDQ_E88_003D);
			if (expVector == null)
			{
				return null;
			}
			ExpVector expVector2 = ExpVector._0023_003DzyJipUOg_003D(expVector, Vector3D.AxisZ);
			if (_0023_003Dzrgqz890sj_0024X9 == _0023_003DzfjVos4c_003D._0023_003Dz_0024B4JBsGot9sy())
			{
				return expVector2;
			}
			return _0023_003Dzrgqz890sj_0024X9._0023_003DzSXhMXWF129li(expVector2, _0023_003DzfjVos4c_003D._0023_003Dz_0024B4JBsGot9sy());
		}
		Param param = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656130));
		ExpVector expVector3 = _0023_003DzfjVos4c_003D._0023_003Dz1D2_0024pLU_003D(param);
		ExpVector expVector4 = new ExpVector(expVector3.x._0023_003DzSOlfnhbkZ12J(param)._0023_003DzSOlfnhbkZ12J(param), expVector3.y._0023_003DzSOlfnhbkZ12J(param)._0023_003DzSOlfnhbkZ12J(param), expVector3.z._0023_003DzSOlfnhbkZ12J(param)._0023_003DzSOlfnhbkZ12J(param));
		expVector4.x._0023_003Dz_9xLui4_003D(param, _0023_003DzNDQ_E88_003D);
		expVector4.y._0023_003Dz_9xLui4_003D(param, _0023_003DzNDQ_E88_003D);
		expVector4.z._0023_003Dz_9xLui4_003D(param, _0023_003DzNDQ_E88_003D);
		if (_0023_003Dzrgqz890sj_0024X9 == null)
		{
			return expVector4;
		}
		return _0023_003Dzrgqz890sj_0024X9._0023_003DzVstW_0024UycJxNGceLNLQ_003D_003D(expVector4);
	}

	public static bool _0023_003Dz0PHhFCY_003D(this SketchCurve _0023_003DzbfrNXYE_003D)
	{
		if (_0023_003DzbfrNXYE_003D._0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D() != null)
		{
			return _0023_003DzbfrNXYE_003D._0023_003DzwwGQT0MxcNOs() != null;
		}
		return false;
	}

	public static bool _0023_003DzuwORSGsM0fc5(this SketchCurve _0023_003Dz9MkSMcc_003D, SketchCurve _0023_003Dz2T4sy2I_003D)
	{
		if (_0023_003Dz9MkSMcc_003D == null)
		{
			return _0023_003Dz2T4sy2I_003D == null;
		}
		if (_0023_003Dz2T4sy2I_003D == null)
		{
			return _0023_003Dz9MkSMcc_003D == null;
		}
		if (_0023_003Dz9MkSMcc_003D != _0023_003Dz2T4sy2I_003D)
		{
			if (_0023_003Dz9MkSMcc_003D.GetType() == _0023_003Dz2T4sy2I_003D.GetType())
			{
				return _0023_003Dz9MkSMcc_003D.ObjectId == _0023_003Dz2T4sy2I_003D.ObjectId;
			}
			return false;
		}
		return true;
	}

	public static ExpVector _0023_003DznBE9fJlN_RVjSMhUAA_003D_003D(this SketchCurve _0023_003Dz8fpRyMu9aKjE, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		IEnumerator<ExpVector> enumerator = _0023_003Dz8fpRyMu9aKjE._0023_003DzR4SRlXnJG4Zr6xm4rg_003D_003D(_0023_003Dzrgqz890sj_0024X9).GetEnumerator();
		enumerator.MoveNext();
		return enumerator.Current;
	}

	public static ExpVector _0023_003DzvZpvBdFc_0024vJr0ob44g_003D_003D(this SketchCurve _0023_003Dz8fpRyMu9aKjE, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		ExpVector expVector = _0023_003Dz8fpRyMu9aKjE._0023_003DzwwGQT0MxcNOs();
		if (expVector == null)
		{
			return null;
		}
		return _0023_003Dzrgqz890sj_0024X9._0023_003Dz1binOM8_003D(expVector, _0023_003Dz8fpRyMu9aKjE._0023_003Dz_0024B4JBsGot9sy());
	}

	[IteratorStateMachine(typeof(_0023_003DzCluSZf1436sp4vA3Vq54uf4_003D))]
	public static IEnumerable<ExpVector> _0023_003DzR4SRlXnJG4Zr6xm4rg_003D_003D(this SketchCurve _0023_003Dz8fpRyMu9aKjE, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		return new _0023_003DzCluSZf1436sp4vA3Vq54uf4_003D(-2)
		{
			_0023_003DzFf67v1RK1BCODpa6JQ_003D_003D = _0023_003Dz8fpRyMu9aKjE,
			_0023_003DzAcfDX51Wlhd41ne5mQ_003D_003D = _0023_003Dzrgqz890sj_0024X9
		};
	}

	public static ExpVector _0023_003DzHay5oSnsOrhEx1IRfA_003D_003D(this SketchCurve _0023_003Dz8fpRyMu9aKjE, Exp _0023_003DzNDQ_E88_003D, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		if (_0023_003Dzrgqz890sj_0024X9 == _0023_003Dz8fpRyMu9aKjE._0023_003Dz_0024B4JBsGot9sy())
		{
			return _0023_003Dz8fpRyMu9aKjE._0023_003Dz1D2_0024pLU_003D(_0023_003DzNDQ_E88_003D);
		}
		return _0023_003Dzrgqz890sj_0024X9._0023_003Dz1binOM8_003D(_0023_003Dz8fpRyMu9aKjE._0023_003Dz1D2_0024pLU_003D(_0023_003DzNDQ_E88_003D), _0023_003Dz8fpRyMu9aKjE._0023_003Dz_0024B4JBsGot9sy());
	}

	public static ExpVector _0023_003DzroVPFPWrAGmDA0WC5g_003D_003D(this SketchCurve _0023_003Dz8fpRyMu9aKjE, Exp _0023_003DzNDQ_E88_003D, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		if (_0023_003Dzrgqz890sj_0024X9 == _0023_003Dz8fpRyMu9aKjE._0023_003Dz_0024B4JBsGot9sy())
		{
			return _0023_003Dz8fpRyMu9aKjE._0023_003DznwYbRgIzSbCB(_0023_003DzNDQ_E88_003D);
		}
		return _0023_003Dzrgqz890sj_0024X9._0023_003DzSXhMXWF129li(_0023_003Dz8fpRyMu9aKjE._0023_003DznwYbRgIzSbCB(_0023_003DzNDQ_E88_003D), _0023_003Dz8fpRyMu9aKjE._0023_003Dz_0024B4JBsGot9sy());
	}

	public static ExpVector _0023_003Dzy_5KJihFxeEA7535uA_003D_003D(this SketchCurve _0023_003DzbfrNXYE_003D, Exp _0023_003DzNDQ_E88_003D, Exp _0023_003DzfBEBL_o_003D, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		if (_0023_003Dzrgqz890sj_0024X9 == _0023_003DzbfrNXYE_003D._0023_003Dz_0024B4JBsGot9sy())
		{
			return _0023_003DzbfrNXYE_003D._0023_003Dz1D2_0024pLU_003D(_0023_003DzNDQ_E88_003D) + _0023_003DzbfrNXYE_003D._0023_003Dz37OPKlxi4S3U(_0023_003DzNDQ_E88_003D)._0023_003DznLBUdKk_003D() * _0023_003DzfBEBL_o_003D;
		}
		return _0023_003DzbfrNXYE_003D._0023_003DzHay5oSnsOrhEx1IRfA_003D_003D(_0023_003DzNDQ_E88_003D, _0023_003Dzrgqz890sj_0024X9) + _0023_003DzbfrNXYE_003D._0023_003DzTYUQTQfCxvrs9fo_NA_003D_003D(_0023_003DzNDQ_E88_003D, _0023_003Dzrgqz890sj_0024X9)._0023_003DznLBUdKk_003D() * _0023_003DzfBEBL_o_003D;
	}

	public static ExpVector _0023_003DzA_0024J70Z2BeZ2NjG9QJw_003D_003D(this SketchCurve _0023_003Dz8fpRyMu9aKjE, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		IEnumerator<ExpVector> enumerator = _0023_003Dz8fpRyMu9aKjE._0023_003DzMiXki3_0024IvHM9ZDMTyK3_rVc_003D().GetEnumerator();
		enumerator.MoveNext();
		ExpVector expVector = _0023_003Dzrgqz890sj_0024X9._0023_003Dz1binOM8_003D(enumerator.Current, _0023_003Dz8fpRyMu9aKjE._0023_003Dz_0024B4JBsGot9sy());
		enumerator.MoveNext();
		return _0023_003Dzrgqz890sj_0024X9._0023_003Dz1binOM8_003D(enumerator.Current, _0023_003Dz8fpRyMu9aKjE._0023_003Dz_0024B4JBsGot9sy()) - expVector;
	}

	public static ExpVector _0023_003Dz3n47qxIbm22LgMNXhA_003D_003D(this SketchCurve _0023_003Dz8fpRyMu9aKjE, int _0023_003DzyzK8swU_003D, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		IEnumerator<ExpVector> enumerator = _0023_003Dz8fpRyMu9aKjE._0023_003DzMiXki3_0024IvHM9ZDMTyK3_rVc_003D().GetEnumerator();
		int num = -1;
		while (num++ < _0023_003DzyzK8swU_003D && enumerator.MoveNext())
		{
		}
		return _0023_003Dzrgqz890sj_0024X9._0023_003Dz1binOM8_003D(enumerator.Current, _0023_003Dz8fpRyMu9aKjE._0023_003Dz_0024B4JBsGot9sy());
	}

	public static Vector3D _0023_003DzvpK7b5hknESlsSE43ckrjwU_003D(this SketchCurve _0023_003Dz8fpRyMu9aKjE, int _0023_003DzyzK8swU_003D, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		IEnumerator<ExpVector> enumerator = _0023_003Dz8fpRyMu9aKjE._0023_003DzMiXki3_0024IvHM9ZDMTyK3_rVc_003D().GetEnumerator();
		int num = -1;
		while (num++ < _0023_003DzyzK8swU_003D && enumerator.MoveNext())
		{
		}
		return _0023_003Dzrgqz890sj_0024X9._0023_003Dz1binOM8_003D(enumerator.Current._0023_003DzBUjqlpM_003D(), _0023_003Dz8fpRyMu9aKjE._0023_003Dz_0024B4JBsGot9sy());
	}

	public static ExpVector _0023_003Dz1Ho9nWIuWuKe(this SketchCurve _0023_003Dz8fpRyMu9aKjE, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		IEnumerator<ExpVector> enumerator = _0023_003Dz8fpRyMu9aKjE._0023_003DzMiXki3_0024IvHM9ZDMTyK3_rVc_003D().GetEnumerator();
		enumerator.MoveNext();
		return _0023_003Dzrgqz890sj_0024X9._0023_003Dz1binOM8_003D(enumerator.Current, _0023_003Dz8fpRyMu9aKjE._0023_003Dz_0024B4JBsGot9sy());
	}

	public static ExpVector _0023_003Dz9QssUmv2_00247tx(this SketchCurve _0023_003Dz8fpRyMu9aKjE, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		IEnumerator<ExpVector> enumerator = _0023_003Dz8fpRyMu9aKjE._0023_003DzMiXki3_0024IvHM9ZDMTyK3_rVc_003D().GetEnumerator();
		enumerator.MoveNext();
		enumerator.MoveNext();
		return _0023_003Dzrgqz890sj_0024X9._0023_003Dz1binOM8_003D(enumerator.Current, _0023_003Dz8fpRyMu9aKjE._0023_003Dz_0024B4JBsGot9sy());
	}

	public static ExpVector _0023_003Dz248i0kZfbCoU(this SketchCurve _0023_003DzbfrNXYE_003D, Exp _0023_003DzNDQ_E88_003D, Exp _0023_003DzfBEBL_o_003D)
	{
		return _0023_003DzbfrNXYE_003D._0023_003Dz1D2_0024pLU_003D(_0023_003DzNDQ_E88_003D) + _0023_003DzbfrNXYE_003D._0023_003Dz37OPKlxi4S3U(_0023_003DzNDQ_E88_003D)._0023_003DznLBUdKk_003D() * _0023_003DzfBEBL_o_003D;
	}

	public static ExpVector _0023_003DzhORDpsH0WRpi(this SketchCurve _0023_003DzbfrNXYE_003D, Exp _0023_003DzNDQ_E88_003D, Exp _0023_003DzfBEBL_o_003D)
	{
		Param param = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656130));
		ExpVector expVector = _0023_003DzbfrNXYE_003D._0023_003Dz248i0kZfbCoU(param, _0023_003DzfBEBL_o_003D);
		ExpVector expVector2 = new ExpVector(expVector.x._0023_003DzSOlfnhbkZ12J(param), expVector.y._0023_003DzSOlfnhbkZ12J(param), expVector.z._0023_003DzSOlfnhbkZ12J(param));
		expVector2.x._0023_003Dz_9xLui4_003D(param, _0023_003DzNDQ_E88_003D);
		expVector2.y._0023_003Dz_9xLui4_003D(param, _0023_003DzNDQ_E88_003D);
		expVector2.z._0023_003Dz_9xLui4_003D(param, _0023_003DzNDQ_E88_003D);
		return expVector2;
	}
}
