using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml;
using devDept.Eyeshot.Entities;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public abstract class SketchCurve : SketchItem
{
	private sealed class _0023_003DzHGZRYRKbfDLx__DJ6g_003D_003D : IEnumerable<SketchPoint>, IEnumerable, IEnumerator<SketchPoint>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SketchPoint _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerHidden]
		public _0023_003DzHGZRYRKbfDLx__DJ6g_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
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
			if (_0023_003DzU7pGb3X7Zp4G != 0)
			{
				return false;
			}
			_0023_003DzU7pGb3X7Zp4G = -1;
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
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				return this;
			}
			return new _0023_003DzHGZRYRKbfDLx__DJ6g_003D_003D(0);
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

	private sealed class _0023_003DzPv9xkRV3LPdmFKf3FFQNWKeiUyS_0024ikidcQ_003D_003D : IEnumerable<ExpVector>, IEnumerable, IEnumerator<ExpVector>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExpVector _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchCurve _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IEnumerator<SketchPoint> _0023_003DzFG3sANyTBzy1KVLUgQ_003D_003D;

		[DebuggerHidden]
		public _0023_003DzPv9xkRV3LPdmFKf3FFQNWKeiUyS_0024ikidcQ_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
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
			int num = _0023_003DzU7pGb3X7Zp4G;
			SketchCurve sketchCurve = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzFG3sANyTBzy1KVLUgQ_003D_003D = sketchCurve._0023_003DzgJiUT1qDtKLT().GetEnumerator();
				break;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				break;
			}
			if (_0023_003DzFG3sANyTBzy1KVLUgQ_003D_003D.MoveNext())
			{
				_0023_003DzezVIuujSK1H9 = _0023_003DzFG3sANyTBzy1KVLUgQ_003D_003D.Current._0023_003Dzuc1z_scDJBr3();
				_0023_003DzU7pGb3X7Zp4G = 1;
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
			_0023_003DzPv9xkRV3LPdmFKf3FFQNWKeiUyS_0024ikidcQ_003D_003D _0023_003DzPv9xkRV3LPdmFKf3FFQNWKeiUyS_0024ikidcQ_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzPv9xkRV3LPdmFKf3FFQNWKeiUyS_0024ikidcQ_003D_003D2 = this;
			}
			else
			{
				_0023_003DzPv9xkRV3LPdmFKf3FFQNWKeiUyS_0024ikidcQ_003D_003D2 = new _0023_003DzPv9xkRV3LPdmFKf3FFQNWKeiUyS_0024ikidcQ_003D_003D(0);
				_0023_003DzPv9xkRV3LPdmFKf3FFQNWKeiUyS_0024ikidcQ_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzPv9xkRV3LPdmFKf3FFQNWKeiUyS_0024ikidcQ_003D_003D2;
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

	private sealed class _0023_003DzpY73sCoLN4RnX0SkjG7gC5s_003D : IEnumerable<Vector3D>, IEnumerable, IEnumerator<Vector3D>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Vector3D _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchCurve _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DztTOd8jiTI6HT;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dzlo7bGovleCmOSleXzQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Param _0023_003DzGPzGJDpl4DnRfmRsGA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExpVector _0023_003DzNi0dUXuOcnJaL7MHjQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003Dz9xraizeN7vwK;

		[DebuggerHidden]
		public _0023_003DzpY73sCoLN4RnX0SkjG7gC5s_003D(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			_0023_003DzGPzGJDpl4DnRfmRsGA_003D_003D = null;
			_0023_003DzNi0dUXuOcnJaL7MHjQ_003D_003D = null;
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
			SketchCurve sketchCurve = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzGPzGJDpl4DnRfmRsGA_003D_003D = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656130));
				_0023_003DzNi0dUXuOcnJaL7MHjQ_003D_003D = sketchCurve._0023_003Dz1D2_0024pLU_003D(_0023_003DzGPzGJDpl4DnRfmRsGA_003D_003D);
				_0023_003Dz9xraizeN7vwK = 0;
				break;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003Dz9xraizeN7vwK++;
				break;
			}
			if (_0023_003Dz9xraizeN7vwK <= _0023_003DztTOd8jiTI6HT)
			{
				_0023_003DzGPzGJDpl4DnRfmRsGA_003D_003D._0023_003DzO_0024HwSzQ_003D((double)_0023_003Dz9xraizeN7vwK / (double)_0023_003DztTOd8jiTI6HT);
				_0023_003DzezVIuujSK1H9 = _0023_003DzNi0dUXuOcnJaL7MHjQ_003D_003D._0023_003DzBUjqlpM_003D();
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
		private Vector3D _0023_003DzomLL1210qZFKgAKoo03FP4nam5KJWJdaEQJZ9I6yu212()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		Vector3D IEnumerator<Vector3D>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zomLL1210qZFKgAKoo03FP4nam5KJWJdaEQJZ9I6yu212
			return this._0023_003DzomLL1210qZFKgAKoo03FP4nam5KJWJdaEQJZ9I6yu212();
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
		private IEnumerator<Vector3D> _0023_003Dzt8LpUT2fUpQEvZy0gyISv50nDJv53HZz6PkhCkJCSls0()
		{
			_0023_003DzpY73sCoLN4RnX0SkjG7gC5s_003D _0023_003DzpY73sCoLN4RnX0SkjG7gC5s_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzpY73sCoLN4RnX0SkjG7gC5s_003D2 = this;
			}
			else
			{
				_0023_003DzpY73sCoLN4RnX0SkjG7gC5s_003D2 = new _0023_003DzpY73sCoLN4RnX0SkjG7gC5s_003D(0);
				_0023_003DzpY73sCoLN4RnX0SkjG7gC5s_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			_0023_003DzpY73sCoLN4RnX0SkjG7gC5s_003D2._0023_003DztTOd8jiTI6HT = _0023_003Dzlo7bGovleCmOSleXzQ_003D_003D;
			return _0023_003DzpY73sCoLN4RnX0SkjG7gC5s_003D2;
		}

		IEnumerator<Vector3D> IEnumerable<Vector3D>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zt8LpUT2fUpQEvZy0gyISv50nDJv53HZz6PkhCkJCSls0
			return this._0023_003Dzt8LpUT2fUpQEvZy0gyISv50nDJv53HZz6PkhCkJCSls0();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003Dzt8LpUT2fUpQEvZy0gyISv50nDJv53HZz6PkhCkJCSls0();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	private sealed class _0023_003DzsxpV8wkFW3PnyLbekw_003D_003D : IEnumerable<Vector3D>, IEnumerable, IEnumerator<Vector3D>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Vector3D _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Func<double, Vector3D> _0023_003DzXDZjGQY_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Func<double, Vector3D> _0023_003DzVsMZWdP2QfM5Nw6teA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DztTOd8jiTI6HT;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dzlo7bGovleCmOSleXzQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003Dze6QF3HQ90_qw;

		[DebuggerHidden]
		public _0023_003DzsxpV8wkFW3PnyLbekw_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
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
			switch (_0023_003DzU7pGb3X7Zp4G)
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
			if (_0023_003Dze6QF3HQ90_qw <= _0023_003DztTOd8jiTI6HT)
			{
				_0023_003DzezVIuujSK1H9 = _0023_003DzXDZjGQY_003D((double)_0023_003Dze6QF3HQ90_qw / (double)_0023_003DztTOd8jiTI6HT);
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
		private Vector3D _0023_003DzomLL1210qZFKgAKoo03FP4nam5KJWJdaEQJZ9I6yu212()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		Vector3D IEnumerator<Vector3D>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zomLL1210qZFKgAKoo03FP4nam5KJWJdaEQJZ9I6yu212
			return this._0023_003DzomLL1210qZFKgAKoo03FP4nam5KJWJdaEQJZ9I6yu212();
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
		private IEnumerator<Vector3D> _0023_003Dzt8LpUT2fUpQEvZy0gyISv50nDJv53HZz6PkhCkJCSls0()
		{
			_0023_003DzsxpV8wkFW3PnyLbekw_003D_003D _0023_003DzsxpV8wkFW3PnyLbekw_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzsxpV8wkFW3PnyLbekw_003D_003D2 = this;
			}
			else
			{
				_0023_003DzsxpV8wkFW3PnyLbekw_003D_003D2 = new _0023_003DzsxpV8wkFW3PnyLbekw_003D_003D(0);
			}
			_0023_003DzsxpV8wkFW3PnyLbekw_003D_003D2._0023_003DztTOd8jiTI6HT = _0023_003Dzlo7bGovleCmOSleXzQ_003D_003D;
			_0023_003DzsxpV8wkFW3PnyLbekw_003D_003D2._0023_003DzXDZjGQY_003D = _0023_003DzVsMZWdP2QfM5Nw6teA_003D_003D;
			return _0023_003DzsxpV8wkFW3PnyLbekw_003D_003D2;
		}

		IEnumerator<Vector3D> IEnumerable<Vector3D>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zt8LpUT2fUpQEvZy0gyISv50nDJv53HZz6PkhCkJCSls0
			return this._0023_003Dzt8LpUT2fUpQEvZy0gyISv50nDJv53HZz6PkhCkJCSls0();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003Dzt8LpUT2fUpQEvZy0gyISv50nDJv53HZz6PkhCkJCSls0();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	private bool _fixed;

	internal List<Constraint> usedInConstraints = new List<Constraint>();

	internal List<SketchCurve> children = new List<SketchCurve>();

	internal List<SketchCurve> linkedCurves = new List<SketchCurve>();

	internal Func<ExpVector, ExpVector> transform;

	public bool Fixed
	{
		get
		{
			return _fixed;
		}
		set
		{
			_fixed = value;
			foreach (SketchCurve child in children)
			{
				child.Fixed = value;
			}
			foreach (SketchCurve linkedCurf in GetLinkedCurves())
			{
				linkedCurf.Fixed = value;
			}
		}
	}

	public bool Construction { get; set; }

	public SketchCurve ParentCurve { get; }

	public Constraint[] Constraints => usedInConstraints.ToArray();

	public IEnumerable<SketchPoint> Vertices => _0023_003DzgJiUT1qDtKLT();

	protected SketchCurve(SketchCurve another)
		: base(another)
	{
		Construction = another.Construction;
		children = new List<SketchCurve>();
		usedInConstraints = new List<Constraint>();
		foreach (Constraint usedInConstraint in another.usedInConstraints)
		{
			usedInConstraints.Add((Constraint)usedInConstraint.Clone());
		}
		Fixed = another.Fixed;
	}

	protected SketchCurve()
	{
		children = new List<SketchCurve>();
		usedInConstraints = new List<Constraint>();
	}

	internal SketchCurve(SketchInternal _0023_003DzLIMKAVqStH2OJ85ZPw_003D_003D)
		: base(_0023_003DzLIMKAVqStH2OJ85ZPw_003D_003D)
	{
		_0023_003DzLIMKAVqStH2OJ85ZPw_003D_003D?._0023_003DzRCrpdGA_003D(this);
	}

	protected SketchCurve(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		Construction = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656748));
		Fixed = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656733));
		children = (List<SketchCurve>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656713), typeof(List<SketchCurve>));
		usedInConstraints = (List<Constraint>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656698), typeof(List<Constraint>));
		_0023_003DzbnpFo4dSYs9p((SketchCurve)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656684), typeof(SketchCurve)));
	}

	internal void _0023_003Dz55vCXok_003D(Constraint _0023_003Dzt_m8zV0_003D)
	{
		usedInConstraints.Add(_0023_003Dzt_m8zV0_003D);
	}

	internal void _0023_003Dze64dfX0_003D(Constraint _0023_003Dzt_m8zV0_003D)
	{
		usedInConstraints.Remove(_0023_003Dzt_m8zV0_003D);
	}

	internal Entity _0023_003DzZ_ilKakl9sw5()
	{
		return entityLink._0023_003DzUtOYa_o_003D();
	}

	internal void _0023_003DzTVQeh_2_2lC7(Entity _0023_003DzPzO_0024GUk_003D)
	{
		entityLink._0023_003Dzdlp53MQ_003D(_0023_003DzPzO_0024GUk_003D.sketchLink);
	}

	public void ClearConstraints()
	{
		usedInConstraints.Clear();
	}

	internal void _0023_003DzbnpFo4dSYs9p(SketchCurve _0023_003DzPzO_0024GUk_003D)
	{
		ParentCurve = _0023_003DzPzO_0024GUk_003D;
	}

	[IteratorStateMachine(typeof(_0023_003DzHGZRYRKbfDLx__DJ6g_003D_003D))]
	internal virtual IEnumerable<SketchPoint> _0023_003DzgJiUT1qDtKLT()
	{
		return new _0023_003DzHGZRYRKbfDLx__DJ6g_003D_003D(-2);
	}

	internal _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dz_0024B4JBsGot9sy()
	{
		return _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().plane;
	}

	internal abstract void _0023_003DzUNQ_t5U_003D(Transformation _0023_003DzLS0sR0pzioXc);

	public virtual Point3D[] IntersectWith(SketchCurve skCurve)
	{
		return GetGeometricEntity().IntersectWith(skCurve.GetGeometricEntity(), 0.0, computeParameters: false);
	}

	public ICurve GetGeometricEntity()
	{
		if (this is SketchLine sketchLine)
		{
			return new Line(sketchLine.StartPoint.Position, sketchLine.EndPoint.Position);
		}
		if (this is SketchArc sketchArc)
		{
			return new Arc(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane, sketchArc.Center.Position, Math.Abs(sketchArc.Radius), sketchArc.StartPoint.Position, sketchArc.EndPoint.Position, flip: false);
		}
		if (this is SketchCircle sketchCircle)
		{
			return new Circle(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane, sketchCircle.Center.Position, Math.Abs(sketchCircle.Radius));
		}
		if (this is SketchEllipticalArc sketchEllipticalArc)
		{
			Plane plane = sketchEllipticalArc.Plane;
			plane.TransformBy(new Align3D(Plane.XY, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane));
			return new EllipticalArc(plane, sketchEllipticalArc.Center.Position, Math.Abs(sketchEllipticalArc.RadiusX), Math.Abs(sketchEllipticalArc.RadiusY), sketchEllipticalArc.StartPoint.Position, sketchEllipticalArc.EndPoint.Position, flip: false);
		}
		if (this is SketchEllipse sketchEllipse)
		{
			Plane plane2 = sketchEllipse.Plane;
			plane2.TransformBy(new Align3D(Plane.XY, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane));
			return new Ellipse(plane2, sketchEllipse.Center.Position, Math.Abs(sketchEllipse.RadiusX), Math.Abs(sketchEllipse.RadiusY));
		}
		if (this is SketchSpline sketchSpline)
		{
			Point4D[] array = new Point4D[4];
			for (int i = 0; i < 4; i++)
			{
				array[i] = new Point4D(sketchSpline.ControlPoints[i].Position);
			}
			Point3D[] ctrlPoints = array;
			return new Curve(3, ctrlPoints);
		}
		if (this is SketchPoint sketchPoint)
		{
			return new Point(sketchPoint.Position);
		}
		return null;
	}

	private int _0023_003Dzmew5HyOwcpyc()
	{
		return children.Count;
	}

	[IteratorStateMachine(typeof(_0023_003DzPv9xkRV3LPdmFKf3FFQNWKeiUyS_0024ikidcQ_003D_003D))]
	internal IEnumerable<ExpVector> _0023_003DzMiXki3_0024IvHM9ZDMTyK3_rVc_003D()
	{
		return new _0023_003DzPv9xkRV3LPdmFKf3FFQNWKeiUyS_0024ikidcQ_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	internal virtual SketchPoint _0023_003Dzwuf7q2alCxk7_0024lpuTg_003D_003D(_0023_003DzpIxZyllUf71E32IBGeiYQ3GZCeope4AwcQ_003D_003D _0023_003Dz437_00244ak_003D)
	{
		return _0023_003Dzwuf7q2alCxk7_0024lpuTg_003D_003D((int)_0023_003Dz437_00244ak_003D);
	}

	internal SketchPoint _0023_003Dzwuf7q2alCxk7_0024lpuTg_003D_003D(int _0023_003Dz437_00244ak_003D)
	{
		if (this is SketchPoint result)
		{
			return result;
		}
		return children[_0023_003Dz437_00244ak_003D] as SketchPoint;
	}

	[IteratorStateMachine(typeof(_0023_003DzpY73sCoLN4RnX0SkjG7gC5s_003D))]
	protected internal IEnumerable<Vector3D> getSegmentsUsingPointOn(int subdiv)
	{
		return new _0023_003DzpY73sCoLN4RnX0SkjG7gC5s_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this,
			_0023_003Dzlo7bGovleCmOSleXzQ_003D_003D = subdiv
		};
	}

	[IteratorStateMachine(typeof(_0023_003DzsxpV8wkFW3PnyLbekw_003D_003D))]
	protected internal IEnumerable<Vector3D> getSegments(int subdiv, Func<double, Vector3D> pointOn)
	{
		return new _0023_003DzsxpV8wkFW3PnyLbekw_003D_003D(-2)
		{
			_0023_003Dzlo7bGovleCmOSleXzQ_003D_003D = subdiv,
			_0023_003DzVsMZWdP2QfM5Nw6teA_003D_003D = pointOn
		};
	}

	public Point3D PointAt(double t)
	{
		return _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane.PointAt(_0023_003Dz1D2_0024pLU_003D(t)._0023_003DzBUjqlpM_003D().AsPoint);
	}

	internal abstract ExpVector _0023_003Dz1D2_0024pLU_003D(Exp _0023_003DzNDQ_E88_003D);

	public T AddChild<T>(T e) where T : SketchCurve
	{
		children.Add(e);
		e._0023_003DzbnpFo4dSYs9p(this);
		return e;
	}

	public List<SketchCurve> GetLinkedCurves()
	{
		return linkedCurves.ToList();
	}

	public T AddLinkedCurve<T>(T e) where T : SketchCurve
	{
		linkedCurves.Add(e);
		return e;
	}

	public bool DeleteLinkedCurve(SketchCurve skCurve)
	{
		if (linkedCurves.Contains(skCurve))
		{
			linkedCurves.Remove(skCurve);
			return true;
		}
		return false;
	}

	public override void Destroy()
	{
		if (base.IsDestroyed)
		{
			return;
		}
		while (usedInConstraints.Count > 0)
		{
			usedInConstraints[0].Destroy();
		}
		foreach (SketchCurve item in _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D()._0023_003DzW1wgPM78KxwE())
		{
			if (item.linkedCurves.Contains(this))
			{
				item.DeleteLinkedCurve(this);
			}
		}
		base.Destroy();
		if (ParentCurve != null)
		{
			ParentCurve.Destroy();
			_0023_003DzbnpFo4dSYs9p(null);
		}
		while (children.Count > 0)
		{
			children[0].Destroy();
			children.RemoveAt(0);
		}
		while (linkedCurves.Count > 0)
		{
			linkedCurves[0].Destroy();
			linkedCurves.RemoveAt(0);
		}
	}

	internal override void _0023_003Dzqx2DhVY_003D(XmlTextWriter _0023_003Dzzic3a9w_003D)
	{
		_0023_003Dzzic3a9w_003D.WriteStartElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655099));
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655404), GetType().FullName);
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656670), Construction ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657403) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656655));
		base._0023_003Dzqx2DhVY_003D(_0023_003Dzzic3a9w_003D);
		if (children.Count > 0)
		{
			foreach (SketchCurve child in children)
			{
				child._0023_003Dzqx2DhVY_003D(_0023_003Dzzic3a9w_003D);
			}
		}
		_0023_003Dzzic3a9w_003D.WriteEndElement();
	}

	internal override void _0023_003DzVemZ00E_003D(XmlNode _0023_003Dzzic3a9w_003D)
	{
		base._0023_003DzVemZ00E_003D(_0023_003Dzzic3a9w_003D);
		int num = 0;
		foreach (XmlNode childNode in _0023_003Dzzic3a9w_003D.ChildNodes)
		{
			if (children.Count <= num)
			{
				string value = childNode.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302655404)].Value;
				string value2 = childNode.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656670)].Value;
				SketchCurve sketchCurve = _0023_003DzSfMvOM4_003D(value, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D());
				sketchCurve.Construction = bool.Parse(value2);
				AddChild(sketchCurve);
			}
			children[num]._0023_003DzVemZ00E_003D(childNode);
			num++;
		}
	}

	internal bool _0023_003DzA7T2ee4_003D(SketchPoint _0023_003DzB68dg9Q_003D)
	{
		if (!(this is ISketchCurve))
		{
			return false;
		}
		ISketchCurve sketchCurve = this as ISketchCurve;
		if (sketchCurve.StartPoint != _0023_003DzB68dg9Q_003D)
		{
			return sketchCurve.EndPoint == _0023_003DzB68dg9Q_003D;
		}
		return true;
	}

	protected internal virtual SketchCurve OnSplit(Vector3D position)
	{
		return null;
	}

	private SketchCurve _0023_003Dzse5L_LQ_003D(Vector3D _0023_003DztUjb52A_003D)
	{
		return OnSplit(_0023_003DztUjb52A_003D);
	}

	public Vector3D TangentAt(double t)
	{
		return _0023_003DznwYbRgIzSbCB(new Exp(t))._0023_003DzBUjqlpM_003D();
	}

	internal virtual ExpVector _0023_003DznwYbRgIzSbCB(Exp _0023_003DzNDQ_E88_003D)
	{
		Param param = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656130));
		ExpVector expVector = _0023_003Dz1D2_0024pLU_003D(param);
		ExpVector expVector2 = new ExpVector(expVector.x._0023_003DzSOlfnhbkZ12J(param), expVector.y._0023_003DzSOlfnhbkZ12J(param), expVector.z._0023_003DzSOlfnhbkZ12J(param));
		expVector2.x._0023_003Dz_9xLui4_003D(param, _0023_003DzNDQ_E88_003D);
		expVector2.y._0023_003Dz_9xLui4_003D(param, _0023_003DzNDQ_E88_003D);
		expVector2.z._0023_003Dz_9xLui4_003D(param, _0023_003DzNDQ_E88_003D);
		return expVector2;
	}

	internal abstract Exp _0023_003Dz2s6gjYE_003D();

	internal abstract Exp _0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D();

	internal virtual ExpVector _0023_003DzwwGQT0MxcNOs()
	{
		return null;
	}

	internal static SketchCurve _0023_003DzSfMvOM4_003D(string _0023_003DzuAHwq4M_003D, SketchInternal _0023_003DzjCETKTg_003D)
	{
		Type[] types = new Type[1] { typeof(SketchInternal) };
		object[] parameters = new object[1] { _0023_003DzjCETKTg_003D };
		Type type = Type.GetType(_0023_003DzuAHwq4M_003D);
		if (type == null)
		{
			throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657384) + _0023_003DzuAHwq4M_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302942177));
		}
		return type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, types, null).Invoke(parameters) as SketchCurve;
	}

	internal abstract void _0023_003DzjdvuhXvcm_002426();

	internal abstract ICurve _0023_003DzxXXV_0024fQ_003D();

	public abstract void Reverse();

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656748), Construction);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656733), Fixed);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656713), children);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657329), linkedCurves);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656698), usedInConstraints);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656684), ParentCurve);
	}
}
