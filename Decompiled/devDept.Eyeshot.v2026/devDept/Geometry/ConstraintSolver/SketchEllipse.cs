using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
public class SketchEllipse : SketchCurve
{
	private sealed class _0023_003DzGdcrJKKZLGz4i13siw_003D_003D : IEnumerable<SketchPoint>, IEnumerable, IEnumerator<SketchPoint>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SketchPoint _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchEllipse _0023_003DzopRx0_MBcTQs;

		[DebuggerHidden]
		public _0023_003DzGdcrJKKZLGz4i13siw_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
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
			SketchEllipse sketchEllipse = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = sketchEllipse.c;
				_0023_003DzU7pGb3X7Zp4G = 1;
				return true;
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
			_0023_003DzGdcrJKKZLGz4i13siw_003D_003D _0023_003DzGdcrJKKZLGz4i13siw_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzGdcrJKKZLGz4i13siw_003D_003D2 = this;
			}
			else
			{
				_0023_003DzGdcrJKKZLGz4i13siw_003D_003D2 = new _0023_003DzGdcrJKKZLGz4i13siw_003D_003D(0);
				_0023_003DzGdcrJKKZLGz4i13siw_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzGdcrJKKZLGz4i13siw_003D_003D2;
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

	private sealed class _0023_003DzJL_zy1QzfRuE3SUQbQ_003D_003D : IEnumerable<Param>, IEnumerable, IEnumerator<Param>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Param _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchEllipse _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IEnumerator<Param> _0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D;

		[DebuggerHidden]
		public _0023_003DzJL_zy1QzfRuE3SUQbQ_003D_003D(int _0023_003DzU7pGb3X7Zp4G)
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
				SketchEllipse sketchEllipse = _0023_003DzopRx0_MBcTQs;
				switch (num)
				{
				default:
					return false;
				case 0:
					_0023_003DzU7pGb3X7Zp4G = -1;
					_0023_003DzezVIuujSK1H9 = sketchEllipse.r0;
					_0023_003DzU7pGb3X7Zp4G = 1;
					return true;
				case 1:
					_0023_003DzU7pGb3X7Zp4G = -1;
					_0023_003DzezVIuujSK1H9 = sketchEllipse.r1;
					_0023_003DzU7pGb3X7Zp4G = 2;
					return true;
				case 2:
					_0023_003DzU7pGb3X7Zp4G = -1;
					_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D = sketchEllipse.basis._0023_003DzGVWngirLnmOL().GetEnumerator();
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
			_0023_003DzJL_zy1QzfRuE3SUQbQ_003D_003D _0023_003DzJL_zy1QzfRuE3SUQbQ_003D_003D2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzJL_zy1QzfRuE3SUQbQ_003D_003D2 = this;
			}
			else
			{
				_0023_003DzJL_zy1QzfRuE3SUQbQ_003D_003D2 = new _0023_003DzJL_zy1QzfRuE3SUQbQ_003D_003D(0);
				_0023_003DzJL_zy1QzfRuE3SUQbQ_003D_003D2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzJL_zy1QzfRuE3SUQbQ_003D_003D2;
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

	private sealed class _0023_003Dz__0024vU_0024_0024alFgxTiBxWCfVA3jLeDBof : IEnumerable<Exp>, IEnumerable, IEnumerator<Exp>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Exp _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchEllipse _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IEnumerator<Exp> _0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D;

		[DebuggerHidden]
		public _0023_003Dz__0024vU_0024_0024alFgxTiBxWCfVA3jLeDBof(int _0023_003DzU7pGb3X7Zp4G)
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
				SketchEllipse sketchEllipse = _0023_003DzopRx0_MBcTQs;
				switch (num)
				{
				default:
					return false;
				case 0:
					_0023_003DzU7pGb3X7Zp4G = -1;
					_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D = sketchEllipse.basis._0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D().GetEnumerator();
					_0023_003DzU7pGb3X7Zp4G = -3;
					break;
				case 1:
					_0023_003DzU7pGb3X7Zp4G = -3;
					break;
				}
				if (_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D.MoveNext())
				{
					Exp current = _0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D.Current;
					_0023_003DzezVIuujSK1H9 = current;
					_0023_003DzU7pGb3X7Zp4G = 1;
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
			_0023_003Dz__0024vU_0024_0024alFgxTiBxWCfVA3jLeDBof _0023_003Dz__0024vU_0024_0024alFgxTiBxWCfVA3jLeDBof2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003Dz__0024vU_0024_0024alFgxTiBxWCfVA3jLeDBof2 = this;
			}
			else
			{
				_0023_003Dz__0024vU_0024_0024alFgxTiBxWCfVA3jLeDBof2 = new _0023_003Dz__0024vU_0024_0024alFgxTiBxWCfVA3jLeDBof(0);
				_0023_003Dz__0024vU_0024_0024alFgxTiBxWCfVA3jLeDBof2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003Dz__0024vU_0024_0024alFgxTiBxWCfVA3jLeDBof2;
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

	internal SketchPoint c;

	internal Param r0 = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657318));

	internal Param r1 = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657325));

	internal ExpBasis2d basis = new ExpBasis2d();

	public Plane Plane => new Plane(basis._0023_003DzFFLKkkk_003D()._0023_003DzBUjqlpM_003D().AsPoint, basis._0023_003DzGpzuFag_003D()._0023_003DzBUjqlpM_003D(), basis._0023_003Dz2JFkIIQ_003D()._0023_003DzBUjqlpM_003D());

	public double RadiusX
	{
		get
		{
			return r0._0023_003DzV29zQ3g_003D();
		}
		set
		{
			r0._0023_003DzO_0024HwSzQ_003D(value);
		}
	}

	public double RadiusY
	{
		get
		{
			return r1._0023_003DzV29zQ3g_003D();
		}
		set
		{
			r1._0023_003DzO_0024HwSzQ_003D(value);
		}
	}

	public SketchPoint Center => c;

	protected SketchEllipse(SketchEllipse another)
		: base(another)
	{
		c = AddChild((SketchPoint)another.c.Clone());
		r0 = another.r0._0023_003DzqZwFarHnpOoH();
		r1 = another.r1._0023_003DzqZwFarHnpOoH();
		basis = (ExpBasis2d)another.basis.Clone();
	}

	internal SketchEllipse(SketchInternal _0023_003DzjCETKTg_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		c = AddChild(new SketchPoint(_0023_003DzjCETKTg_003D));
		basis._0023_003DzOjiryAH4CnPe(c.x, c.y);
	}

	internal SketchEllipse(SketchInternal _0023_003DzjCETKTg_003D, SketchPoint _0023_003DzbUvT9Pc_003D)
		: base(_0023_003DzjCETKTg_003D)
	{
		c = AddChild(_0023_003DzbUvT9Pc_003D);
	}

	protected SketchEllipse(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		basis = (ExpBasis2d)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657304), typeof(ExpBasis2d));
		c = (SketchPoint)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656765), typeof(SketchPoint));
		r0 = (Param)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657284), typeof(Param));
		r1 = (Param)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657291), typeof(Param));
	}

	internal override void _0023_003DzUNQ_t5U_003D(Transformation _0023_003DzLS0sR0pzioXc)
	{
		double scaleFactor = Math.Abs(_0023_003DzLS0sR0pzioXc.ScaleFactorX);
		if (_0023_003DzLS0sR0pzioXc.IsScaleFactorUniform() || _0023_003DzLS0sR0pzioXc.IsScaleFactorUniformForPlanar(Plane.XY, ref scaleFactor))
		{
			RadiusX *= scaleFactor;
			RadiusY *= scaleFactor;
		}
		if (_0023_003DzLS0sR0pzioXc.HasReflection)
		{
			Reverse();
		}
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzGdcrJKKZLGz4i13siw_003D_003D))]
	internal override IEnumerable<SketchPoint> _0023_003DzgJiUT1qDtKLT()
	{
		return new _0023_003DzGdcrJKKZLGz4i13siw_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	internal override bool _0023_003Dztl9hmdI_003D()
	{
		if (!c._0023_003Dztl9hmdI_003D() && !r0.changed)
		{
			return r1.changed;
		}
		return true;
	}

	public override SketchItemSurrogate ConvertToSurrogate()
	{
		return new SketchEllipseSurrogate(this);
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003DzJL_zy1QzfRuE3SUQbQ_003D_003D))]
	internal override IEnumerable<Param> _0023_003DzGVWngirLnmOL()
	{
		return new _0023_003DzJL_zy1QzfRuE3SUQbQ_003D_003D(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	[SpecialName]
	[IteratorStateMachine(typeof(_0023_003Dz__0024vU_0024_0024alFgxTiBxWCfVA3jLeDBof))]
	internal override IEnumerable<Exp> _0023_003DzYi2k33SIk8bhOhY4gQ_003D_003D()
	{
		return new _0023_003Dz__0024vU_0024_0024alFgxTiBxWCfVA3jLeDBof(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	internal ExpVector[] _0023_003Dz5YatEap4_vPP()
	{
		ExpVector[] array = new ExpVector[4];
		for (int i = 0; i <= 3; i++)
		{
			Param param = new Param(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656130));
			ExpVector expVector = _0023_003Dz1D2_0024pLU_003D(param);
			param._0023_003DzO_0024HwSzQ_003D((double)i / 4.0);
			array[i] = expVector;
		}
		return array;
	}

	private protected override void _0023_003DzLMYk8jQ_003D(XmlTextWriter _0023_003Dzzic3a9w_003D)
	{
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657318), Math.Abs(r0._0023_003DzV29zQ3g_003D())._0023_003Dz1eU15ZU_003D());
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657325), Math.Abs(r1._0023_003DzV29zQ3g_003D())._0023_003Dz1eU15ZU_003D());
		_0023_003Dzzic3a9w_003D.WriteAttributeString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657526), basis.ToString());
	}

	private protected override void _0023_003Dzy_0024vnioE_003D(XmlNode _0023_003Dzzic3a9w_003D)
	{
		r0._0023_003DzO_0024HwSzQ_003D(_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657318)].Value._0023_003DzR61OsnE_003D());
		r1._0023_003DzO_0024HwSzQ_003D(_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657325)].Value._0023_003DzR61OsnE_003D());
		basis._0023_003DzmWeZeOY_003D(_0023_003Dzzic3a9w_003D.Attributes[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657526)].Value);
	}

	internal override ExpVector _0023_003Dz1D2_0024pLU_003D(Exp _0023_003DzNDQ_E88_003D)
	{
		Exp _0023_003DzBJFJHwk_003D = _0023_003DzNDQ_E88_003D * 2.0 * Math.PI;
		basis._0023_003DzOjiryAH4CnPe(c.x, c.y);
		return basis._0023_003Dzcw7M7n87_FwJ(new ExpVector(Exp._0023_003DzHqHPcG0_003D(_0023_003DzBJFJHwk_003D) * Exp._0023_003Dz0v89Hn0_003D(r0), Exp._0023_003DzzFteY6c_003D(_0023_003DzBJFJHwk_003D) * Exp._0023_003Dz0v89Hn0_003D(r1), 0.0));
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
		return new SketchEllipse(this);
	}

	internal override void _0023_003DzjdvuhXvcm_002426()
	{
		Ellipse obj = (Ellipse)_0023_003DzZ_ilKakl9sw5();
		Align3D xform = new Align3D(Plane.XY, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane);
		obj.Plane = Plane;
		obj.Plane.TransformBy(xform);
		obj.RadiusX = Math.Abs(RadiusX);
		obj.RadiusY = Math.Abs(RadiusY);
	}

	internal override ICurve _0023_003DzxXXV_0024fQ_003D()
	{
		Ellipse ellipse = new Ellipse(_0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane, Center.Position, Math.Abs(RadiusX), Math.Abs(RadiusY));
		double angleInRadians = Vector2D.SignedAngleBetween(Vector2D.AxisX, Plane.AxisX);
		ellipse.Rotate(angleInRadians, _0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D().Plane.AxisZ, Center.Position);
		return ellipse;
	}

	public override void Reverse()
	{
		ExpBasis2d expBasis2d = basis;
		expBasis2d._0023_003DzYlbK4cc_003D(expBasis2d._0023_003DzGpzuFag_003D() * -1.0);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657304), basis);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302656765), c);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657284), r0);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657291), r1);
	}
}
