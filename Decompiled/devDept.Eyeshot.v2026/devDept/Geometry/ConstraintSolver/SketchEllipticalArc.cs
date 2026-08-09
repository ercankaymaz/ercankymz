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
public class SketchEllipticalArc : SketchEllipse, ISketchCurve
{
	private sealed class _0023_003Dz1UvKkpB75MK40Ly9zUI0R4rkxk5x : IEnumerable<Exp>, IEnumerable, IEnumerator<Exp>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exp _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchEllipticalArc _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ExpVector _0023_003DzFM0K9E3dKWHZjl2c1w_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IEnumerator<Exp> _0023_003DzfibMWVRp8R_0024wWcEv9w_003D_003D;

		[DebuggerHidden]
		public _0023_003Dz1UvKkpB75MK40Ly9zUI0R4rkxk5x(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_0023_003Dza_5rxXxkeiYaHduTng_003D_003D();
				}
			}
			_0023_003DzFM0K9E3dKWHZjl2c1w_003D_003D = null;
			_0023_003DzfibMWVRp8R_0024wWcEv9w_003D_003D = null;
			_0023_003DzU7pGb3X7Zp4G = -2;
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zc0uzWO$CiiAh6KSB0g==
			this._0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
		}

		private bool MoveNext()
		{
			try
			{
				int num = _0023_003DzU7pGb3X7Zp4G;
				SketchEllipticalArc sketchEllipticalArc = _0023_003DzopRx0_MBcTQs;
				ExpVector _0023_003DzCJkr8nY_003D;
				switch (num)
				{
				default:
					return false;
				case 0:
					_0023_003DzU7pGb3X7Zp4G = -1;
					_0023_003DzfibMWVRp8R_0024wWcEv9w_003D_003D = sketchEllipticalArc.basis._0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D().GetEnumerator();
					_0023_003DzU7pGb3X7Zp4G = -3;
					goto IL_007d;
				case 1:
					_0023_003DzU7pGb3X7Zp4G = -3;
					goto IL_007d;
				case 2:
					_0023_003DzU7pGb3X7Zp4G = -1;
					_0023_003DzezVIuujSK1H9 = _0023_003DzFM0K9E3dKWHZjl2c1w_003D_003D.x * _0023_003DzFM0K9E3dKWHZjl2c1w_003D_003D.x / (sketchEllipticalArc.r0._0023_003Dzuc1z_scDJBr3() * sketchEllipticalArc.r0._0023_003Dzuc1z_scDJBr3()) + _0023_003DzFM0K9E3dKWHZjl2c1w_003D_003D.y * _0023_003DzFM0K9E3dKWHZjl2c1w_003D_003D.y / (sketchEllipticalArc.r1._0023_003Dzuc1z_scDJBr3() * sketchEllipticalArc.r1._0023_003Dzuc1z_scDJBr3()) - 1.0;
					_0023_003DzU7pGb3X7Zp4G = 3;
					return true;
				case 3:
					{
						_0023_003DzU7pGb3X7Zp4G = -1;
						return false;
					}
					IL_007d:
					if (_0023_003DzfibMWVRp8R_0024wWcEv9w_003D_003D.MoveNext())
					{
						Exp current = _0023_003DzfibMWVRp8R_0024wWcEv9w_003D_003D.Current;
						_0023_003DzezVIuujSK1H9 = current;
						_0023_003DzU7pGb3X7Zp4G = 1;
						return true;
					}
					_0023_003Dza_5rxXxkeiYaHduTng_003D_003D();
					_0023_003DzfibMWVRp8R_0024wWcEv9w_003D_003D = null;
					_0023_003DzCJkr8nY_003D = sketchEllipticalArc.p0._0023_003Dzuc1z_scDJBr3() - sketchEllipticalArc.Center._0023_003Dzuc1z_scDJBr3();
					_0023_003DzFM0K9E3dKWHZjl2c1w_003D_003D = sketchEllipticalArc.p1._0023_003Dzuc1z_scDJBr3() - sketchEllipticalArc.Center._0023_003Dzuc1z_scDJBr3();
					_0023_003DzCJkr8nY_003D = sketchEllipticalArc.basis._0023_003DzwzELtoHWMa8y(_0023_003DzCJkr8nY_003D);
					_0023_003DzFM0K9E3dKWHZjl2c1w_003D_003D = sketchEllipticalArc.basis._0023_003DzwzELtoHWMa8y(_0023_003DzFM0K9E3dKWHZjl2c1w_003D_003D);
					_0023_003DzezVIuujSK1H9 = _0023_003DzCJkr8nY_003D.x * _0023_003DzCJkr8nY_003D.x / (sketchEllipticalArc.r0._0023_003Dzuc1z_scDJBr3() * sketchEllipticalArc.r0._0023_003Dzuc1z_scDJBr3()) + _0023_003DzCJkr8nY_003D.y * _0023_003DzCJkr8nY_003D.y / (sketchEllipticalArc.r1._0023_003Dzuc1z_scDJBr3() * sketchEllipticalArc.r1._0023_003Dzuc1z_scDJBr3()) - 1.0;
					_0023_003DzU7pGb3X7Zp4G = 2;
					return true;
				}
			}
			catch
			{
				//try-fault
				_0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _0023_003Dza_5rxXxkeiYaHduTng_003D_003D()
		{
			_0023_003DzU7pGb3X7Zp4G = -1;
			if (_0023_003DzfibMWVRp8R_0024wWcEv9w_003D_003D != null)
			{
				_0023_003DzfibMWVRp8R_0024wWcEv9w_003D_003D.Dispose();
			}
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
			_0023_003Dz1UvKkpB75MK40Ly9zUI0R4rkxk5x _0023_003Dz1UvKkpB75MK40Ly9zUI0R4rkxk5x2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003Dz1UvKkpB75MK40Ly9zUI0R4rkxk5x2 = this;
			}
			else
			{
				_0023_003Dz1UvKkpB75MK40Ly9zUI0R4rkxk5x2 = new _0023_003Dz1UvKkpB75MK40Ly9zUI0R4rkxk5x(0);
				_0023_003Dz1UvKkpB75MK40Ly9zUI0R4rkxk5x2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003Dz1UvKkpB75MK40Ly9zUI0R4rkxk5x2;
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

	private sealed class _0023_003DzCDeNeV0exRQlgKd42A_003D_003D : IEnumerable<SketchPoint>, IEnumerable, IEnumerator<SketchPoint>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SketchPoint _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchEllipticalArc _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003DzCDeNeV0exRQlgKd42A_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
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
			SketchEllipticalArc sketchEllipticalArc = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = sketchEllipticalArc.p0;
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = sketchEllipticalArc.p1;
				_0023_003DzU7pGb3X7Zp4G = 2;
				return true;
			case 2:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = sketchEllipticalArc.c;
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
			_0023_003DzCDeNeV0exRQlgKd42A_003D_003D _0023_003DzCDeNeV0exRQlgKd42A_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzCDeNeV0exRQlgKd42A_003D_003D2 = this;
			}
			else
			{
				_0023_003DzCDeNeV0exRQlgKd42A_003D_003D2 = new _0023_003DzCDeNeV0exRQlgKd42A_003D_003D(0);
				_0023_003DzCDeNeV0exRQlgKd42A_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzCDeNeV0exRQlgKd42A_003D_003D2;
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

	private sealed class _0023_003DzoYY4DNUMdeIjqNW89A_003D_003D : IEnumerable<Param>, IEnumerable, IEnumerator<Param>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Param _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchEllipticalArc _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IEnumerator<Param> _0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D;

		[DebuggerHidden]
		public _0023_003DzoYY4DNUMdeIjqNW89A_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			if (num == -3 || num == 3)
			{
				try
				{
				}
				finally
				{
					_0023_003Dza_5rxXxkeiYaHduTng_003D_003D();
				}
			}
			_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D = null;
			_0023_003DzU7pGb3X7Zp4G = -2;
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zc0uzWO$CiiAh6KSB0g==
			this._0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
		}

		private bool MoveNext()
		{
			try
			{
				int num = _0023_003DzU7pGb3X7Zp4G;
				SketchEllipticalArc sketchEllipticalArc = _0023_003DzopRx0_MBcTQs;
				switch (num)
				{
				default:
					return false;
				case 0:
					_0023_003DzU7pGb3X7Zp4G = -1;
					_0023_003DzezVIuujSK1H9 = sketchEllipticalArc.r0;
					_0023_003DzU7pGb3X7Zp4G = 1;
					return true;
				case 1:
					_0023_003DzU7pGb3X7Zp4G = -1;
					_0023_003DzezVIuujSK1H9 = sketchEllipticalArc.r1;
					_0023_003DzU7pGb3X7Zp4G = 2;
					return true;
				case 2:
					_0023_003DzU7pGb3X7Zp4G = -1;
					_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D = sketchEllipticalArc.basis._0023_003DzGVWngirLnmOL().GetEnumerator();
					_0023_003DzU7pGb3X7Zp4G = -3;
					break;
				case 3:
					_0023_003DzU7pGb3X7Zp4G = -3;
					break;
				}
				if (_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D.MoveNext())
				{
					Param current = _0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D.Current;
					_0023_003DzezVIuujSK1H9 = current;
					_0023_003DzU7pGb3X7Zp4G = 3;
					return true;
				}
				_0023_003Dza_5rxXxkeiYaHduTng_003D_003D();
				_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D = null;
				return false;
			}
			catch
			{
				//try-fault
				_0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _0023_003Dza_5rxXxkeiYaHduTng_003D_003D()
		{
			_0023_003DzU7pGb3X7Zp4G = -1;
			if (_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D != null)
			{
				_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D.Dispose();
			}
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
			_0023_003DzoYY4DNUMdeIjqNW89A_003D_003D _0023_003DzoYY4DNUMdeIjqNW89A_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzoYY4DNUMdeIjqNW89A_003D_003D2 = this;
			}
			else
			{
				_0023_003DzoYY4DNUMdeIjqNW89A_003D_003D2 = new _0023_003DzoYY4DNUMdeIjqNW89A_003D_003D(0);
				_0023_003DzoYY4DNUMdeIjqNW89A_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzoYY4DNUMdeIjqNW89A_003D_003D2;
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

	internal SketchPoint p0;

	internal SketchPoint p1;

	public SketchPoint StartPoint => p0;

	public SketchPoint EndPoint => p1;

	internal SketchEllipticalArc(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		p0 = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		p1 = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
	}

	protected SketchEllipticalArc(SketchEllipticalArc another)
		: base(another)
	{
		p0 = AddChild((SketchPoint)another.p0.Clone());
		p1 = AddChild((SketchPoint)another.p1.Clone());
	}

	internal SketchEllipticalArc(SketchInternal _0023_003DzjCETKTg_003D, SketchPoint _0023_003DzbUvT9Pc_003D, Point2D _0023_003Dz3k5Uze_VdwnF, Point2D _0023_003DzMnu3zKCWb6Kc)
		: base(_0023_003DzjCETKTg_003D, _0023_003DzbUvT9Pc_003D)
	{
		p0 = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		p1 = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		p0._0023_003DzF56xZpo_003D(_0023_003Dz3k5Uze_VdwnF.X, _0023_003Dz3k5Uze_VdwnF.Y);
		p1._0023_003DzF56xZpo_003D(_0023_003DzMnu3zKCWb6Kc.X, _0023_003DzMnu3zKCWb6Kc.Y);
	}

	internal SketchEllipticalArc(SketchInternal _0023_003DzjCETKTg_003D, SketchPoint _0023_003DzbUvT9Pc_003D, SketchPoint _0023_003Dz3k5Uze_VdwnF, Point2D _0023_003DzMnu3zKCWb6Kc)
		: base(_0023_003DzjCETKTg_003D, _0023_003DzbUvT9Pc_003D)
	{
		p0 = AddChild(_0023_003Dz3k5Uze_VdwnF);
		p1 = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		p1._0023_003DzF56xZpo_003D(_0023_003DzMnu3zKCWb6Kc.X, _0023_003DzMnu3zKCWb6Kc.Y);
	}

	internal SketchEllipticalArc(SketchInternal _0023_003DzjCETKTg_003D, Point2D _0023_003DzbUvT9Pc_003D, Point2D _0023_003Dz3k5Uze_VdwnF, SketchPoint _0023_003DzMnu3zKCWb6Kc)
		: base(_0023_003DzjCETKTg_003D)
	{
		p0 = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		p1 = AddChild(_0023_003DzMnu3zKCWb6Kc);
		p0._0023_003DzF56xZpo_003D(_0023_003Dz3k5Uze_VdwnF.X, _0023_003Dz3k5Uze_VdwnF.Y);
		c._0023_003DzF56xZpo_003D(_0023_003DzbUvT9Pc_003D.X, _0023_003DzbUvT9Pc_003D.Y);
	}

	protected SketchEllipticalArc(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		p0 = (SketchPoint)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657506), typeof(SketchPoint));
		p1 = (SketchPoint)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657513), typeof(SketchPoint));
	}

	internal void _0023_003Dze8HLGHdo_0024aUJ(SketchPoint _0023_003DzPzO_0024GUk_003D)
	{
		p0 = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DzkiChZxXAOBwG(SketchPoint _0023_003DzPzO_0024GUk_003D)
	{
		p1 = _0023_003DzPzO_0024GUk_003D;
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzoYY4DNUMdeIjqNW89A_003D_003D))]
	internal override IEnumerable<Param> _0023_003DzGVWngirLnmOL()
	{
		return new _0023_003DzoYY4DNUMdeIjqNW89A_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003Dz1UvKkpB75MK40Ly9zUI0R4rkxk5x))]
	internal override IEnumerable<Exp> _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D()
	{
		return new _0023_003Dz1UvKkpB75MK40Ly9zUI0R4rkxk5x(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzCDeNeV0exRQlgKd42A_003D_003D))]
	internal override IEnumerable<SketchPoint> _0023_003DzgJiUT1qDtKLT()
	{
		return new _0023_003DzCDeNeV0exRQlgKd42A_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	internal override bool _0023_003Dztl9hmdI_003D()
	{
		if (!p0._0023_003Dztl9hmdI_003D() && !p1._0023_003Dztl9hmdI_003D())
		{
			return c._0023_003Dztl9hmdI_003D();
		}
		return true;
	}

	private Exp _0023_003Dz1Qne7nGPb8PU()
	{
		ExpVector _0023_003Dzt38nTwk_003D = p0._0023_003Dzuc1z_scDJBr3() - c._0023_003Dzuc1z_scDJBr3();
		return _0023_003DzMr7dyDtNhE5ce7x_0024P8Wmwj_B7hbJ._0023_003Dz5wNeT2sDg28l(new ExpVector(1.0, 0.0, 0.0), _0023_003Dzt38nTwk_003D, _0023_003DzYRitoXujv8Dc: true);
	}

	internal Exp _0023_003Dzo6Exr5vIiWd9()
	{
		if (!p0._0023_003DzcC394h_GqnXLOnrbsRJh_00248Y_003D(p1))
		{
			ExpVector _0023_003DzizVqTKE_003D = p0._0023_003Dzuc1z_scDJBr3() - c._0023_003Dzuc1z_scDJBr3();
			ExpVector _0023_003Dzt38nTwk_003D = p1._0023_003Dzuc1z_scDJBr3() - c._0023_003Dzuc1z_scDJBr3();
			return _0023_003DzMr7dyDtNhE5ce7x_0024P8Wmwj_B7hbJ._0023_003Dz5wNeT2sDg28l(_0023_003DzizVqTKE_003D, _0023_003Dzt38nTwk_003D, _0023_003DzYRitoXujv8Dc: true);
		}
		return Math.PI * 2.0;
	}

	internal override Exp _0023_003DzQoC8eSxbb9t_BV2MfA_003D_003D()
	{
		throw new NotImplementedException();
	}

	internal Exp _0023_003DzSVz6jiA_003D()
	{
		return (p0._0023_003Dzuc1z_scDJBr3() - c._0023_003Dzuc1z_scDJBr3())._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D();
	}

	internal ExpVector _0023_003DzelSSGl9E3_0024i4()
	{
		return c._0023_003Dzuc1z_scDJBr3();
	}

	public override object Clone()
	{
		return new SketchEllipticalArc(this);
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new SketchEllipticalArcSurrogate(this);
	}

	internal override void _0023_003DzjdvuhXvcm_002426()
	{
		EllipticalArc obj = (EllipticalArc)_0023_003DzZ_ilKakl9sw5();
		Point3D first = StartPoint.Position;
		Point3D second = EndPoint.Position;
		Point3D position = base.Center.Position;
		Align3D xform = new Align3D(Plane.XY, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane);
		bool flag = Vector3D.AreOpposite(obj.Plane.AxisZ, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane.AxisZ, 0.01);
		if (flag)
		{
			Utility.Swap(ref first, ref second);
		}
		Plane plane = base.Plane;
		plane.TransformBy(xform);
		EllipticalArc ellipticalArc = new EllipticalArc(plane, position, Math.Abs(base.RadiusX), Math.Abs(base.RadiusY), first, second, flag);
		if (ellipticalArc.Domain.Length < 1E-12)
		{
			ellipticalArc.Domain = new Interval(ellipticalArc.Domain.t0, ellipticalArc.Domain.t0 + Utility._0023_003DzheSR8QM7q9ya);
		}
		obj.Domain = ellipticalArc.Domain;
		obj.Plane = plane;
		obj.RadiusX = ellipticalArc.RadiusX;
		obj.RadiusY = ellipticalArc.RadiusY;
	}

	internal override ICurve _0023_003DzxXXV_0024fQ_003D()
	{
		EllipticalArc ellipticalArc = new EllipticalArc(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane, base.Center.Position, Math.Abs(base.RadiusX), Math.Abs(base.RadiusY), StartPoint.Position, EndPoint.Position, flip: false);
		double angleInRadians = Vector2D.SignedAngleBetween(Vector2D.AxisX, base.Plane.AxisX);
		ellipticalArc.Rotate(angleInRadians, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane.AxisZ, base.Center.Position);
		return ellipticalArc;
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657506), p0);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657513), p1);
	}
}
