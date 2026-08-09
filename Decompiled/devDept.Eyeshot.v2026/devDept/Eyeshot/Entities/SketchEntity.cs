using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class SketchEntity : PlanarEntity, ISelectableSubItems, IDeserializationCallback
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Entity, bool> _0023_003Dz7WKXDUM7qNCMbf2s2g_003D_003D;

		public static Func<Entity, bool> _0023_003Dz4BExgZY4uHZhaB5wjQ_003D_003D;

		public static Func<ILabel, bool> _0023_003DznpZt5R8lffynlK56FQ_003D_003D;

		public static Func<Constraint, VisualConstraint> _0023_003Dzlm2lrQMxP9Z4cmGPiw_003D_003D;

		public static Func<SketchPoint, Point> _0023_003DzcLOxoWBTXaQKUV_y_0024g_003D_003D;

		public static Func<Entity, SketchItem> _0023_003DzCpLew4mwS7bPbmh1ng_003D_003D;

		public static Func<Entity, SketchItem> _0023_003Dz3drBrPKBm72cXkBR_0024w_003D_003D;

		public static Func<Entity, SketchItem> _0023_003DznGFh0vGrO_dl9lfG9w_003D_003D;

		public static Func<Entity, SketchItem> _0023_003Dzv83ITtTo8t4_b_0024LSdg_003D_003D;

		public static Func<SketchCurve, Entity> _0023_003DzWHw_QWJNxLcC0IWW1w_003D_003D;

		public static Func<SketchCurve, Entity> _0023_003Dz61JCppLvjSPj9wggzg_003D_003D;

		public static Func<SketchArc, Arc> _0023_003DzpDJcGP_7UTar_002445_1A_003D_003D;

		public static Func<SketchCurve, Entity> _0023_003DzAISNsG74nyamRsSeVw_003D_003D;

		public static Func<Constraint, VisualConstraint> _0023_003DznK9CLSDFtlm6r_00242U8Q_003D_003D;

		public static Func<Entity, bool> _0023_003DzeNL8C_0024PAJ1bCdwoGPw_003D_003D;

		public static Func<Entity, SketchItem> _0023_003Dzgn9i_x1_VxxLOrk9jw_003D_003D;

		public static Func<Constraint, bool> _0023_003Dzi5_KylWLSUVWBSsS7Q_003D_003D;

		public static Func<Constraint, bool> _0023_003DzDlufuFWPBhYRfOj9LQ_003D_003D;

		public static Func<Constraint, VisualConstraint> _0023_003DzPmv_XVaSTAibuXnZdg_003D_003D;

		public static Func<ICurve, bool> _0023_003DzKS1WroSsS3_g8FBj0A_003D_003D;

		public static Func<Point, Point3D> _0023_003DzHBhaSsnsREdGLXF3MQ_003D_003D;

		public static Func<Entity, bool> _0023_003Dz1fk_0024QwpjmoClBXBr0w_003D_003D;

		internal bool _0023_003DzKLUXIQQgSWmprvOaKaWgVACXN_c6hj2MgQ_003D_003D(Entity _0023_003DzBJFJHwk_003D)
		{
			if (!(_0023_003DzBJFJHwk_003D is SketchEntity))
			{
				return !(_0023_003DzBJFJHwk_003D is Point);
			}
			return false;
		}

		internal bool _0023_003DzG0cM51GHELpo_0024NObqnXPzuc_003D(Entity _0023_003DzbfrNXYE_003D)
		{
			return !(_0023_003DzbfrNXYE_003D is Point);
		}

		internal bool _0023_003DzoFgcSbcU4b7TUqrS0w_003D_003D(ILabel _0023_003DzBJFJHwk_003D)
		{
			if (_0023_003DzBJFJHwk_003D is IStackedLabel stackedLabel)
			{
				return stackedLabel.Constraint != null;
			}
			return false;
		}

		internal VisualConstraint _0023_003DzeuZ_0024KL7AKP0_4Zl4bXx6QNQ_003D(Constraint _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D._0023_003DzzRLCjkBKJt17();
		}

		internal Point _0023_003Dz_9FGZ6mgyRkZgJjYvVBtzpM_003D(SketchPoint _0023_003DzB68dg9Q_003D)
		{
			return (Point)_0023_003DzB68dg9Q_003D._0023_003DzZ_ilKakl9sw5();
		}

		internal SketchItem _0023_003Dzl3tfq72rLtxSewKLcgJbIWhjR2z4(Entity _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
		}

		internal SketchItem _0023_003DzgKgURY41xRKG684HUuNC0CiyWXng(Entity _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
		}

		internal SketchItem _0023_003DzOhrpq00UABwzQUP06KvnSEk8MHV4(Entity _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
		}

		internal SketchItem _0023_003DzyvgFrPJfYAd09h6x96mJIOLHnNub(Entity _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
		}

		internal Entity _0023_003DzLJ34s8luf2eejQQaGn7ywwo_003D(SketchCurve _0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzbfrNXYE_003D._0023_003DzZ_ilKakl9sw5();
		}

		internal Entity _0023_003DzLJ9TUrE_DKPn6b7DPKujDrg_003D(SketchCurve _0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzbfrNXYE_003D._0023_003DzZ_ilKakl9sw5();
		}

		internal Arc _0023_003DzS85bw_0024l3TqCtT6eHfQoM_0024nc_003D(SketchArc _0023_003DzbfrNXYE_003D)
		{
			return (Arc)_0023_003DzbfrNXYE_003D._0023_003DzZ_ilKakl9sw5();
		}

		internal Entity _0023_003Dz2VSFkFTix_0024GTFy7aYiozSyA_003D(SketchCurve _0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzbfrNXYE_003D._0023_003DzZ_ilKakl9sw5();
		}

		internal VisualConstraint _0023_003Dz26SM_8U3UOUmRatvpAeixtI_003D(Constraint _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D._0023_003DzzRLCjkBKJt17();
		}

		internal bool _0023_003Dzvdru9RqabY9P44OX46SJ6iI_003D(Entity _0023_003Dzs_0024uS8LA_003D)
		{
			if (_0023_003Dzs_0024uS8LA_003D.IsSketchEntity())
			{
				return !_0023_003Dzs_0024uS8LA_003D.IsFixed();
			}
			return false;
		}

		internal SketchItem _0023_003Dzi4wZUA17pCd9eSgarj0dKGo_003D(Entity _0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzbfrNXYE_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
		}

		internal bool _0023_003DznxaK_0024vGuPq81bG6yZ9CsWNc_003D(Constraint _0023_003DzV_0024oduG8_003D)
		{
			return _0023_003DzV_0024oduG8_003D is PolygonConstraint;
		}

		internal bool _0023_003Dz77GWE5QD8NOq19M43JPy3IU_003D(Constraint _0023_003DzV_0024oduG8_003D)
		{
			if (!(_0023_003DzV_0024oduG8_003D is PointOnConstraint))
			{
				return _0023_003DzV_0024oduG8_003D is CoincidentConstraint;
			}
			return true;
		}

		internal VisualConstraint _0023_003Dzb9rKW6f2S6fGYHm_bdP6rPc_003D(Constraint _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D._0023_003DzzRLCjkBKJt17();
		}

		internal bool _0023_003DzXRD9nd_002447fnAPgFlKnplFAMhNj34(ICurve _0023_003Dzt_m8zV0_003D)
		{
			return ((Entity)_0023_003Dzt_m8zV0_003D)._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D();
		}

		internal Point3D _0023_003DzTi_0024QkbSOxzeR0ykAklQFa5QPzXfXmEuSCg_003D_003D(Point _0023_003DzB68dg9Q_003D)
		{
			return _0023_003DzB68dg9Q_003D.Position;
		}

		internal bool _0023_003DzIR3kPLbE_vMotXgmpJaZAUE_003D(Entity _0023_003DzBJFJHwk_003D)
		{
			return ((SketchCurve)_0023_003DzBJFJHwk_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Construction;
		}
	}

	[Serializable]
	private sealed class _0023_003DzCf6bSKSuk_DlmHe6xQ_003D_003D<_0023_003DzWWgGxds_003D> where _0023_003DzWWgGxds_003D : SketchCurve
	{
		public static readonly _0023_003DzCf6bSKSuk_DlmHe6xQ_003D_003D<_0023_003DzWWgGxds_003D> _0023_003DzJ5g3Rwo_003D = new _0023_003DzCf6bSKSuk_DlmHe6xQ_003D_003D<_0023_003DzWWgGxds_003D>();

		public static Func<_0023_003DzWWgGxds_003D, IEnumerable<Constraint>> _0023_003DzlB8faciyZd29_0024Mla4A_003D_003D;

		public static Func<_0023_003DzWWgGxds_003D, IEnumerable<SketchPoint>> _0023_003DzhJf5s8dfepoOJgzs2Q_003D_003D;

		public static Func<SketchPoint, IEnumerable<Constraint>> _0023_003Dz8sftwI0losRIwKegBg_003D_003D;

		internal IEnumerable<Constraint> _0023_003Dzr1H5ElP6vtTPC8Hiqs_0024E1Oo_003D(_0023_003DzWWgGxds_003D _0023_003DzvM_00244CJo_003D)
		{
			return _0023_003DzvM_00244CJo_003D.Constraints;
		}

		internal IEnumerable<SketchPoint> _0023_003DzWKwsNDNgjMrj57OXVeWzvqE_003D(_0023_003DzWWgGxds_003D _0023_003DzvM_00244CJo_003D)
		{
			return _0023_003DzvM_00244CJo_003D.Vertices;
		}

		internal IEnumerable<Constraint> _0023_003DzmeK2y4Xd3bkarO1EAuO3pZ0_003D(SketchPoint _0023_003DzB68dg9Q_003D)
		{
			return _0023_003DzB68dg9Q_003D.Constraints;
		}
	}

	private sealed class _0023_003DzExLW_3IqD8Ohw3ITomFksDVQbux_0024 : IEnumerable<Point3D>, IEnumerable, IEnumerator<Point3D>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Point3D _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SketchEntity _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<ICurve>.Enumerator _0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Point3D[] _0023_003DzfibMWVRp8R_0024wWcEv9w_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzNHzgj_0024PXvL03EGUcsA_003D_003D;

		[DebuggerHidden]
		public _0023_003DzExLW_3IqD8Ohw3ITomFksDVQbux_0024(int _0023_003DzU7pGb3X7Zp4G)
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
			_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D = default(List<ICurve>.Enumerator);
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
				SketchEntity sketchEntity = _0023_003DzopRx0_MBcTQs;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					_0023_003DzU7pGb3X7Zp4G = -3;
					_0023_003DzNHzgj_0024PXvL03EGUcsA_003D_003D++;
					goto IL_00a0;
				}
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D = sketchEntity._curveList.GetEnumerator();
				_0023_003DzU7pGb3X7Zp4G = -3;
				goto IL_00b7;
				IL_00a0:
				if (_0023_003DzNHzgj_0024PXvL03EGUcsA_003D_003D < _0023_003DzfibMWVRp8R_0024wWcEv9w_003D_003D.Length)
				{
					Point3D point3D = _0023_003DzfibMWVRp8R_0024wWcEv9w_003D_003D[_0023_003DzNHzgj_0024PXvL03EGUcsA_003D_003D];
					_0023_003DzezVIuujSK1H9 = point3D;
					_0023_003DzU7pGb3X7Zp4G = 1;
					return true;
				}
				_0023_003DzfibMWVRp8R_0024wWcEv9w_003D_003D = null;
				goto IL_00b7;
				IL_00b7:
				if (_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D.MoveNext())
				{
					Entity entity = (Entity)_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D.Current;
					_0023_003DzfibMWVRp8R_0024wWcEv9w_003D_003D = entity.Vertices;
					_0023_003DzNHzgj_0024PXvL03EGUcsA_003D_003D = 0;
					goto IL_00a0;
				}
				_0023_003Dza_5rxXxkeiYaHduTng_003D_003D();
				_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D = default(List<ICurve>.Enumerator);
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
			((IDisposable)_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D/*cast due to constrained. prefix*/).Dispose();
		}

		[DebuggerHidden]
		private Point3D _0023_003DzRu6rOpifzY3BoEQA_rmZDtPbSQSj58QJanX948we4bn8()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		Point3D IEnumerator<Point3D>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zRu6rOpifzY3BoEQA_rmZDtPbSQSj58QJanX948we4bn8
			return this._0023_003DzRu6rOpifzY3BoEQA_rmZDtPbSQSj58QJanX948we4bn8();
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
		private IEnumerator<Point3D> _0023_003DziHtl5qR4krlJiMA4V6j7DxrSlXte60ce_t51czbnv453()
		{
			_0023_003DzExLW_3IqD8Ohw3ITomFksDVQbux_0024 _0023_003DzExLW_3IqD8Ohw3ITomFksDVQbux_00242;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzExLW_3IqD8Ohw3ITomFksDVQbux_00242 = this;
			}
			else
			{
				_0023_003DzExLW_3IqD8Ohw3ITomFksDVQbux_00242 = new _0023_003DzExLW_3IqD8Ohw3ITomFksDVQbux_0024(0);
				_0023_003DzExLW_3IqD8Ohw3ITomFksDVQbux_00242._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			return _0023_003DzExLW_3IqD8Ohw3ITomFksDVQbux_00242;
		}

		IEnumerator<Point3D> IEnumerable<Point3D>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=ziHtl5qR4krlJiMA4V6j7DxrSlXte60ce_t51czbnv453
			return this._0023_003DziHtl5qR4krlJiMA4V6j7DxrSlXte60ce_t51czbnv453();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003DziHtl5qR4krlJiMA4V6j7DxrSlXte60ce_t51czbnv453();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	private sealed class _0023_003DzLh_iSt489MQDyk7Wbg2PsZo_003D
	{
		public Constraint _0023_003Dz9EdxXqI_003D;

		internal bool _0023_003DzXE2ScOI8Rumrq31Xjw_003D_003D(Type _0023_003DzNDQ_E88_003D)
		{
			return _0023_003DzNDQ_E88_003D.IsInstanceOfType(_0023_003Dz9EdxXqI_003D);
		}
	}

	private sealed class _0023_003DzNiz3x9WxdYOMlBYQLA_003D_003D : Circle
	{
		public _0023_003DzNiz3x9WxdYOMlBYQLA_003D_003D(Plane _0023_003Dzrgqz890sj_0024X9, Point2D _0023_003DzbUvT9Pc_003D, double _0023_003DzEGKj_0024SNUUihi)
			: base(_0023_003Dzrgqz890sj_0024X9, _0023_003DzbUvT9Pc_003D, _0023_003DzEGKj_0024SNUUihi)
		{
		}

		protected internal override void Draw(DrawParams _0023_003DzELu0Pss_003D)
		{
			_0023_003DzELu0Pss_003D.RenderContext.SetLineStipple(1, 65280, _0023_003DzELu0Pss_003D.Viewport.Camera);
			_0023_003DzELu0Pss_003D.RenderContext.EnableLineStipple(enable: true);
			base.Draw(_0023_003DzELu0Pss_003D);
			_0023_003DzELu0Pss_003D.RenderContext.EnableLineStipple(enable: false);
		}
	}

	private sealed class _0023_003DzOARt1VA_003D : Line
	{
		public _0023_003DzOARt1VA_003D(Point3D _0023_003DzAqOpw0w_003D, Point3D _0023_003Dzk64JNOo_003D)
			: base(_0023_003DzAqOpw0w_003D, _0023_003Dzk64JNOo_003D)
		{
		}

		protected internal override void Draw(DrawParams _0023_003DzELu0Pss_003D)
		{
			_0023_003DzELu0Pss_003D.RenderContext.SetLineStipple(1, 65280, _0023_003DzELu0Pss_003D.Viewport.Camera);
			_0023_003DzELu0Pss_003D.RenderContext.EnableLineStipple(enable: true);
			base.Draw(_0023_003DzELu0Pss_003D);
			_0023_003DzELu0Pss_003D.RenderContext.EnableLineStipple(enable: false);
		}
	}

	private sealed class _0023_003DzOrvogx7PHd_0024t : Arc
	{
		public _0023_003DzOrvogx7PHd_0024t(Plane _0023_003DzwwbxM1HP2_SRqORo3A_003D_003D, Point2D _0023_003DzbUvT9Pc_003D, Point2D _0023_003DzAqOpw0w_003D, Point2D _0023_003Dzk64JNOo_003D)
			: base(_0023_003DzwwbxM1HP2_SRqORo3A_003D_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzAqOpw0w_003D, _0023_003Dzk64JNOo_003D)
		{
		}

		protected internal override void Draw(DrawParams _0023_003DzELu0Pss_003D)
		{
			_0023_003DzELu0Pss_003D.RenderContext.SetLineStipple(1, 65280, _0023_003DzELu0Pss_003D.Viewport.Camera);
			_0023_003DzELu0Pss_003D.RenderContext.EnableLineStipple(enable: true);
			base.Draw(_0023_003DzELu0Pss_003D);
			_0023_003DzELu0Pss_003D.RenderContext.EnableLineStipple(enable: false);
		}
	}

	private sealed class _0023_003DzyCKwxE4ADDaS1Cy2Ib5Qd7s_003D
	{
		public SketchPoint _0023_003Dz1zXPEMVtR7MH;

		internal bool _0023_003DzAm05K_0024gR2bpdSvRquw_003D_003D(Constraint _0023_003Dzt_m8zV0_003D)
		{
			if (_0023_003Dzt_m8zV0_003D is PolygonConstraint polygonConstraint)
			{
				return polygonConstraint.Center == _0023_003Dz1zXPEMVtR7MH;
			}
			return false;
		}
	}

	public class CameraSettings : ICloneable
	{
		public bool Animate;

		public zoomFitType ZoomFitMode;

		public int Margin;

		public bool RotateToPlane;

		public Brep Brep;

		public int FaceIndex;

		public CameraSettings(bool animate = true, zoomFitType zoomFitMode = zoomFitType.Face, bool rotateToPlane = true, int margin = 0, Brep brep = null, int faceIndex = -1)
		{
			Animate = animate;
			ZoomFitMode = zoomFitMode;
			RotateToPlane = rotateToPlane;
			Margin = margin;
			Brep = brep;
			FaceIndex = faceIndex;
		}

		public object Clone()
		{
			return new CameraSettings(Animate, ZoomFitMode, RotateToPlane, Margin, Brep, FaceIndex);
		}
	}

	public class SketchCurveDeletedEventArgs : EventArgs
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SketchEntity _0023_003DzvDaGRdvKQ2bkxX9RxFD0B6xTyQb9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ICurve _0023_003DzAaSgCMU3Ag4Ns4Cym_0024qfuA9ZbiaZ;

		public SketchEntity SketchEntity
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzvDaGRdvKQ2bkxX9RxFD0B6xTyQb9;
			}
		}

		public ICurve DeletedSketchCurve
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzAaSgCMU3Ag4Ns4Cym_0024qfuA9ZbiaZ;
			}
		}

		public SketchCurveDeletedEventArgs(SketchEntity sketchEntity, ICurve deletedSketchCurve)
		{
			_0023_003DzmRqU1fZH_00247cqmN4aFQ_003D_003D(sketchEntity);
			_0023_003DzzkLXSNf8vJPCtmS9wGoy_4s_003D(deletedSketchCurve);
		}

		private void _0023_003DzmRqU1fZH_00247cqmN4aFQ_003D_003D(SketchEntity _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzvDaGRdvKQ2bkxX9RxFD0B6xTyQb9 = _0023_003DzPzO_0024GUk_003D;
		}

		private void _0023_003DzzkLXSNf8vJPCtmS9wGoy_4s_003D(ICurve _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzAaSgCMU3Ag4Ns4Cym_0024qfuA9ZbiaZ = _0023_003DzPzO_0024GUk_003D;
		}
	}

	public delegate void SketchCurveDeletedEventHandler(object source, SketchCurveDeletedEventArgs e);

	public class SketchCurveLinkedEventArgs : EventArgs
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SketchEntity _0023_003DzvDaGRdvKQ2bkxX9RxFD0B6xTyQb9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ICurve _0023_003DzDtCglxOs7t1OC4yVi7bqzbFqkLPX;

		public SketchEntity SketchEntity
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzvDaGRdvKQ2bkxX9RxFD0B6xTyQb9;
			}
		}

		public ICurve AddedSketchCurve
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzDtCglxOs7t1OC4yVi7bqzbFqkLPX;
			}
		}

		public SketchCurveLinkedEventArgs(SketchEntity sketchEntity, ICurve addedSketchCurve)
		{
			_0023_003DzmRqU1fZH_00247cqmN4aFQ_003D_003D(sketchEntity);
			_0023_003DzKHRVb2e6EFVVH8DYYlC4XQk_003D(addedSketchCurve);
		}

		private void _0023_003DzmRqU1fZH_00247cqmN4aFQ_003D_003D(SketchEntity _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzvDaGRdvKQ2bkxX9RxFD0B6xTyQb9 = _0023_003DzPzO_0024GUk_003D;
		}

		private void _0023_003DzKHRVb2e6EFVVH8DYYlC4XQk_003D(ICurve _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzDtCglxOs7t1OC4yVi7bqzbFqkLPX = _0023_003DzPzO_0024GUk_003D;
		}
	}

	public delegate void SketchCurveLinkedEventHandler(object source, SketchCurveLinkedEventArgs e);

	public delegate void SolveEventHandler(object source, SolveEventArgs e);

	public enum zoomFitType
	{
		Face,
		Body,
		Block,
		None
	}

	internal double screenToWorldInvariantFactor = 20.0;

	private LineType _constructionLineType;

	private IDesign _design;

	private FileSerializer _historySerializer;

	private bool _showFilledRegion = true;

	private Camera _prevCamera;

	private GridSettings _prevGrid;

	private projectionType _prevProjectionType;

	private int _startEntitiesIndex;

	private Block _currentBlock;

	private List<int> _prevSelectableIndices;

	private Sketch _sketchEntityAtEditStart;

	private Entity[] _sketchCurveListAtEditStart;

	private bool _isRegionReady;

	private List<Point3D[]> sketchRegionsVertices;

	private List<IndexTriangle[]> sketchRegionsTriangles;

	private int _prevDof = -1;

	private bool _isRegionValid = true;

	private global::_0023_003DzAXZzi6Sjw7p1yr6lAy7LfDtbxQJyrEjYWCcrbfg_003D<Stream> _history;

	internal int _pasteCounter;

	private Point2D _dragStartPoint;

	private Point2D _dragCurrentPoint;

	private Entity _target;

	private List<ICurve> _curveList;

	private float ratioCurvesSize = 3f;

	private float ratioPointsSize = 9f;

	public static SketchParams Defaults = new SketchParams();

	public SketchParams Params = new SketchParams(Defaults);

	public Plane DrawingPlane { get; } = Plane.XY;

	public int DOF => Sketch.DOF;

	public Color FilledRegionColor { get; set; } = Color.FromArgb(32, Color.DodgerBlue);

	public double DimensionsWidthFactor { get; set; } = 0.9;

	public bool Editing
	{
		get
		{
			if (_design != null)
			{
				return _design.CurrentBlock.sketchEntity == this;
			}
			return false;
		}
	}

	public double TextScaleFactor { get; set; } = 1.0;

	public bool ShowFilledRegion
	{
		get
		{
			return _showFilledRegion;
		}
		set
		{
			_showFilledRegion = value;
			if (_showFilledRegion)
			{
				_0023_003Dz1Epz1IigMnC6();
			}
		}
	}

	public bool UndoReady
	{
		get
		{
			if (_history != null)
			{
				return _history._0023_003Dz6JrdmnU2QTa_0024();
			}
			return false;
		}
	}

	public bool RedoReady
	{
		get
		{
			if (_history != null)
			{
				return _history._0023_003Dzru54n9Wsw_0024Uk();
			}
			return false;
		}
	}

	public Point2D PasteOffset { get; set; } = new Point2D(20.0, 10.0);

	public bool Dragging { get; }

	public Sketch Sketch { get; internal set; }

	public List<ICurve> CurveList => _curveList;

	public List<VisualConstraint> Constraints => Sketch.Constraints.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzb9rKW6f2S6fGYHm_bdP6rPc_003D).ToList();

	public new Plane Plane
	{
		get
		{
			return Sketch.SketchPlane;
		}
		set
		{
			Sketch.SketchPlane = value;
			base.Plane = Sketch.SketchPlane;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	internal List<SelectionInfoSubItems> SketchCurvesSelectionInfo { get; } = new List<SelectionInfoSubItems>();

	public selectionFilterType SelectionMode { get; set; } = selectionFilterType.Entity;

	public event EventHandler HistoryChanged;

	public event SolveEventHandler SystemSolved;

	public event SketchCurveLinkedEventHandler SketchCurveLinked;

	public event SketchCurveDeletedEventHandler SketchCurveDeleted;

	public SketchEntity(Sketch sketch)
		: this(sketch, _0023_003DzGoRYjXRnodfbarym0Q_003D_003D: true, _0023_003Dzmyw8uNw_003D: true)
	{
	}

	public SketchEntity(Plane plane)
		: this(new Sketch(plane), _0023_003DzGoRYjXRnodfbarym0Q_003D_003D: true, _0023_003Dzmyw8uNw_003D: true)
	{
	}

	internal SketchEntity(Sketch _0023_003Dz94T3qb4CfToF, bool _0023_003DzGoRYjXRnodfbarym0Q_003D_003D, bool _0023_003Dzmyw8uNw_003D)
	{
		Sketch = _0023_003Dz94T3qb4CfToF;
		_0023_003DzIRszeCqB4yN_0024(_0023_003Dzmyw8uNw_003D, _0023_003DzGoRYjXRnodfbarym0Q_003D_003D);
	}

	protected SketchEntity(SketchEntity another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		Sketch = (Sketch)another.Sketch.Clone();
		_curveList = new List<ICurve>(another._curveList.Count);
		foreach (ICurve curve in another._curveList)
		{
			_curveList.Add((ICurve)(keepTessellation ? ((Entity)curve).CloneWithTessellation() : curve.Clone()));
		}
		List<SketchCurve> curveList = Sketch.CurveList;
		for (int i = 0; i < curveList.Count; i++)
		{
			curveList[i]._0023_003DzTVQeh_2_2lC7((Entity)_curveList[i]);
		}
	}

	protected internal SketchEntity(SketchEntitySurrogate surrogate)
	{
		Sketch = surrogate.Sketch;
		if (_curveList == null)
		{
			_curveList = new List<ICurve>();
		}
	}

	protected SketchEntity(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		Sketch = new Sketch();
		Sketch = (Sketch)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976829), typeof(Sketch));
		_curveList = (List<ICurve>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976812), typeof(List<ICurve>));
	}

	internal void _0023_003DzvD5K1mPgYyRq_2asbQ_003D_003D(Plane _0023_003DzPzO_0024GUk_003D)
	{
		DrawingPlane = _0023_003DzPzO_0024GUk_003D;
	}

	private IViewportInternal _0023_003Dz4lwYpErPR_sa()
	{
		return (IViewportInternal)(_design?.ActiveViewport);
	}

	private ILabelFactory _0023_003DzLuIkz4x3FVHS()
	{
		return _0023_003Dz4lwYpErPR_sa()?.LabelFactory;
	}

	private double _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D()
	{
		if (_design != null)
		{
			return 10.0 * Utility.GetLinearUnitsConversionFactor(linearUnitsType.Millimeters, _design.CurrentBlock.Units);
		}
		return 10.0;
	}

	private void _0023_003DzGCjubnzMLXkYzHBw_0024w_003D_003D()
	{
		IGrid grid = _0023_003Dz4lwYpErPR_sa().Grid;
		if (grid != null)
		{
			_prevGrid = grid.GetSettings();
			Plane plane = (Plane)Plane.Clone();
			if (_design.CurrentTransformation != null)
			{
				plane.TransformBy(_design.CurrentTransformation);
			}
			grid.ApplySettings(new GridSettings
			{
				ColorAxisX = Color.Red,
				ColorAxisY = Color.Green,
				Lighting = true,
				Plane = plane
			});
		}
	}

	private void _0023_003Dz0AHBMJiSfbXAzcJ7gQ_003D_003D()
	{
		_0023_003Dz4lwYpErPR_sa().Grid?.ApplySettings(_prevGrid);
	}

	private void _0023_003DzXmzXw5DtdFZh(bool _0023_003DzZi3IeGA_003D, CameraSettings _0023_003DzxB3cR94_003D)
	{
		_0023_003DzGCjubnzMLXkYzHBw_0024w_003D_003D();
		_0023_003DzbrQA0WgHEqmSAarUUCD32Vc_003D(_0023_003DzZi3IeGA_003D, _0023_003DzxB3cR94_003D ?? new CameraSettings());
	}

	internal void ResetCameraForSketchEditing(CameraSettings _0023_003DzxB3cR94_003D)
	{
		if (Editing)
		{
			_0023_003DzbrQA0WgHEqmSAarUUCD32Vc_003D(_0023_003DzZi3IeGA_003D: true, _0023_003DzxB3cR94_003D);
		}
	}

	private void _0023_003DzbrQA0WgHEqmSAarUUCD32Vc_003D(bool _0023_003DzZi3IeGA_003D, CameraSettings _0023_003DzxB3cR94_003D)
	{
		Vector3D vector3D = Plane.AxisZ.Clone() as Vector3D;
		vector3D.TransformBy(_design.CurrentTransformation ?? new Identity());
		Vector3D vector3D2;
		if (Vector3D.AreParallel(Vector3D.AxisZ, vector3D))
		{
			vector3D2 = Plane.AxisY.Clone() as Vector3D;
			vector3D2.TransformBy(_design.CurrentTransformation ?? new Identity());
		}
		else
		{
			vector3D2 = Vector3D.AxisZ;
		}
		if (_0023_003DzZi3IeGA_003D)
		{
			_0023_003DzbrQA0WgHEqmSAarUUCD32Vc_003D(vector3D, vector3D2, _0023_003DzxB3cR94_003D);
		}
	}

	private void _0023_003DzbrQA0WgHEqmSAarUUCD32Vc_003D(Vector3D _0023_003Dz6u3psoE_003D, Vector3D _0023_003Dz3JYqu3AVDXFp, CameraSettings _0023_003DzxB3cR94_003D)
	{
		_currentBlock.Entities.UpdateBoundingBox();
		IList<Entity> list = _0023_003DzVq1CeLkvhsY4(_0023_003DzxB3cR94_003D);
		int num = 0;
		bool flag = (list?.Count(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzKLUXIQQgSWmprvOaKaWgVACXN_c6hj2MgQ_003D_003D) ?? 0) > 0;
		bool flag2 = _0023_003DzxB3cR94_003D.ZoomFitMode != zoomFitType.None && flag;
		if (flag2)
		{
			num = ((_0023_003DzxB3cR94_003D.Margin == 0) ? (Math.Min(_design.ActiveViewport.Size.Height, _design.ActiveViewport.Size.Width) / 6) : _0023_003DzxB3cR94_003D.Margin);
		}
		if (_0023_003DzxB3cR94_003D.RotateToPlane)
		{
			_design.SaveView(out _prevCamera);
			_prevProjectionType = _design.ActiveViewport.Camera.ProjectionMode;
			_design.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
			IViewport activeViewport = _design.ActiveViewport;
			int margin = num;
			activeViewport.SetView(_0023_003Dz6u3psoE_003D, _0023_003Dz3JYqu3AVDXFp, flag2, _0023_003DzxB3cR94_003D.Animate, margin, selectedOnly: false, list);
		}
		else if (flag2)
		{
			_design.ZoomFit(list, selectedOnly: false, num);
		}
	}

	private IList<Entity> _0023_003DzVq1CeLkvhsY4(CameraSettings _0023_003DzxB3cR94_003D)
	{
		Entity[] result = ((Sketch.CurveList.Count > 0) ? (from _0023_003DzbfrNXYE_003D in _currentBlock.Entities.Skip(_startEntitiesIndex)
			where !(_0023_003DzbfrNXYE_003D is Point)
			select _0023_003DzbfrNXYE_003D).ToArray() : _currentBlock.Entities.ToArray());
		if (_0023_003DzxB3cR94_003D.ZoomFitMode == zoomFitType.Block || _0023_003DzxB3cR94_003D.Brep == null)
		{
			return result;
		}
		if (_0023_003DzxB3cR94_003D.ZoomFitMode == zoomFitType.Body)
		{
			return new Entity[1] { _0023_003DzxB3cR94_003D.Brep };
		}
		if (_0023_003DzxB3cR94_003D.ZoomFitMode == zoomFitType.Face)
		{
			Entity entity = _0023_003Dz3NszXFBMYe2pIIMTgA_003D_003D(_0023_003DzxB3cR94_003D.FaceIndex, _0023_003DzxB3cR94_003D.Brep, Plane);
			entity.Regen(_design.Document.GetVisualRefinement());
			return new Entity[1] { entity };
		}
		return result;
	}

	private static Entity _0023_003Dz3NszXFBMYe2pIIMTgA_003D_003D(int _0023_003Dzfe2zeQMumw_4, Brep _0023_003DzGb8kdyZ1x5nj, Plane _0023_003Dz7UM8_pqCVK7AbFe_0024mQ_003D_003D)
	{
		ICurve[] orientedTrimLoops = _0023_003DzGb8kdyZ1x5nj.Faces[_0023_003Dzfe2zeQMumw_4].GetOrientedTrimLoops(_0023_003DzGb8kdyZ1x5nj.Edges);
		List<Point2D> list = new List<Point2D>();
		ICurve[] individualCurves = orientedTrimLoops[0].GetIndividualCurves();
		for (int i = 0; i < individualCurves.Length; i++)
		{
			Point4D[] controlPoints = individualCurves[i].GetNurbsForm().ControlPoints;
			foreach (Point4D point4D in controlPoints)
			{
				list.Add(_0023_003Dz7UM8_pqCVK7AbFe_0024mQ_003D_003D.Project(point4D.Euclid));
			}
		}
		Utility.ComputeBoundingRect(list, out var boxMin, out var boxMax);
		LinearPath linearPath = new LinearPath(_0023_003Dz7UM8_pqCVK7AbFe_0024mQ_003D_003D, boxMin, boxMax);
		linearPath.UpdateBoundingBox(null);
		return linearPath;
	}

	private void _0023_003Dz4ULqZamqepYf(CameraSettings _0023_003DzxB3cR94_003D)
	{
		_0023_003Dz0AHBMJiSfbXAzcJ7gQ_003D_003D();
		if (_0023_003DzxB3cR94_003D.RotateToPlane && _prevCamera != null)
		{
			_0023_003DzrF2ZBxguBD1M(_0023_003DzxB3cR94_003D.Animate);
		}
	}

	private void _0023_003DzrF2ZBxguBD1M(bool _0023_003DzaRXgMKzFjDqV)
	{
		bool animateCamera = _design.AnimateCamera;
		_design.AnimateCamera = _0023_003DzaRXgMKzFjDqV;
		if (_design.RenderContext != null)
		{
			_design.ActiveViewport.Camera.ProjectionMode = _prevProjectionType;
		}
		_design.RestoreView(_prevCamera);
		_design.AnimateCamera = animateCamera;
	}

	public void EnableEdgeSelection()
	{
		for (int i = 0; i < _startEntitiesIndex; i++)
		{
			if (_currentBlock.Entities[i] is Brep)
			{
				_currentBlock.Entities[i].Selectable = true;
			}
		}
	}

	public void DisableEdgeSelection()
	{
		for (int i = 0; i < _startEntitiesIndex; i++)
		{
			if (_currentBlock.Entities[i] is Brep)
			{
				_currentBlock.Entities[i].Selectable = false;
			}
		}
	}

	public void Edit(IDesign design, CameraSettings settings = null)
	{
		_design = design;
		_0023_003DzyxNvBqomQqPkmE9g_0024Q_003D_003D(settings ?? new CameraSettings());
	}

	private void _0023_003DzyxNvBqomQqPkmE9g_0024Q_003D_003D(CameraSettings _0023_003DzxB3cR94_003D)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		_sketchEntityAtEditStart = (Sketch)Sketch.Clone();
		_sketchCurveListAtEditStart = new Entity[_sketchEntityAtEditStart.CurveList.Count];
		for (int i = 0; i < _sketchEntityAtEditStart.CurveList.Count; i++)
		{
			_sketchCurveListAtEditStart[i] = Sketch.CurveList[i]._0023_003DzZ_ilKakl9sw5();
		}
		_historySerializer = FileSerializer._0023_003DzXUqKaIQ_003D(_design.FileSerializerForExtendedFormat);
		_startEntitiesIndex = _design.Entities.Count;
		_currentBlock = _design.CurrentBlock;
		_currentBlock.sketchEntity = this;
		_constructionLineType = new LineType(Utility.GetUnusedLineTypeName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976796), _design.LineTypes, _0023_003DzYAFlx1qRy2tosXY_0024QQ_003D_003D: true), Params.ConstructionCurvesPattern);
		if (!_design.LineTypes.Contains(_constructionLineType))
		{
			_design.LineTypes.Add(_constructionLineType);
		}
		_prevSelectableIndices = new List<int>();
		for (int j = 0; j < _currentBlock.Entities.Count; j++)
		{
			Entity entity = _currentBlock.Entities[j];
			if (entity.Selectable)
			{
				_prevSelectableIndices.Add(j);
				entity.Selectable = false;
			}
		}
		_0023_003DzvD5K1mPgYyRq_2asbQ_003D_003D(Plane.Clone() as Plane);
		if (_design.CurrentTransformation != null)
		{
			DrawingPlane.TransformBy(_design.CurrentTransformation);
		}
		_design.Entities.AddRange(CurveList.Cast<Entity>());
		for (int k = 0; k < Sketch.Constraints.Length; k++)
		{
			_0023_003DzIrs5MDJ5nmrc(Sketch.Constraints[k], _design.Entities);
		}
		foreach (Entity curve in CurveList)
		{
			if (((SketchCurve)curve._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Construction)
			{
				curve.LineTypeName = _constructionLineType.Name;
				curve.LineTypeMethod = colorMethodType.byEntity;
			}
		}
		_0023_003DzGpBouKT_0024wCmV(_design.CurrentTransformation, null);
		_design.Entities.Regen();
		_design.UpdateBoundingBox();
		_0023_003DzXmzXw5DtdFZh(_0023_003DzZi3IeGA_003D: true, _0023_003DzxB3cR94_003D);
		_0023_003Dz1Epz1IigMnC6();
		if (CurveList.Count > 0)
		{
			StoreHistory();
		}
	}

	public void Exit(bool keepChanges = true, CameraSettings settings = null)
	{
		settings = settings ?? new CameraSettings();
		if (!Editing)
		{
			return;
		}
		_historySerializer = null;
		_pasteCounter = -1;
		_0023_003Dz4ULqZamqepYf(settings);
		_currentBlock.Entities.RemoveRange(_startEntitiesIndex, _currentBlock.Entities.Count - _startEntitiesIndex);
		foreach (int prevSelectableIndex in _prevSelectableIndices)
		{
			_currentBlock.Entities[prevSelectableIndex].Selectable = true;
		}
		if (!keepChanges)
		{
			Sketch = _sketchEntityAtEditStart;
			for (int i = 0; i < _sketchCurveListAtEditStart.Length; i++)
			{
				Sketch.CurveList[i]._0023_003DzTVQeh_2_2lC7(_sketchCurveListAtEditStart[i]);
			}
			RegenMode = regenType.RegenAndCompile;
		}
		else
		{
			Regen(null);
		}
		_design.Entities.Regen();
		_currentBlock.sketchEntity = null;
		_currentBlock = null;
		if (_constructionLineType != null)
		{
			_design.LineTypes.TryRemove(_constructionLineType);
			_constructionLineType = null;
		}
		if (_0023_003Dz4lwYpErPR_sa() != null)
		{
			_0023_003Dz4lwYpErPR_sa().RemoveLabel(_0023_003Dz4lwYpErPR_sa().GetLabels().Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzoFgcSbcU4b7TUqrS0w_003D_003D).ToArray());
		}
		_0023_003DztXK6GnE_003D();
		_isRegionReady = false;
		sketchRegionsVertices = null;
		sketchRegionsTriangles = null;
		_design = null;
	}

	public IEnumerable<VisualConstraint> RedundantConstraints()
	{
		return from _0023_003Dzt_m8zV0_003D in Sketch.GetRedundantConstraints()
			select _0023_003Dzt_m8zV0_003D._0023_003DzzRLCjkBKJt17();
	}

	internal static void _0023_003Dz36TNao7oaYj6(Dimension _0023_003DzmTIZ8Fc_003D, ValueConstraint _0023_003Dz5cy3qZ0_003D)
	{
		_0023_003Dz5cy3qZ0_003D.DimPos = _0023_003DzmTIZ8Fc_003D.DimLinePosition;
	}

	internal void _0023_003DzUQJXD50_003D(SketchCurve _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D, Entity _0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D, EntityList _0023_003Dzv7xH9gk_003D)
	{
		_0023_003DzVnfAoovaoMa7(_0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D, _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D);
		if (_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D.Construction)
		{
			_0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D.LineTypeName = _constructionLineType.Name;
			_0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D.LineTypeMethod = colorMethodType.byEntity;
		}
		CurveList.Add((ICurve)_0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D);
		_0023_003Dzv7xH9gk_003D.Add(_0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D);
		_0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D._0023_003Dzo3By5vyys2vj7c0aCg_003D_003D(_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D);
		_0023_003DzA_002467er20sv9PpT_sPbnAeAA_003D(this, (ICurve)_0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D);
	}

	internal void _0023_003DzUQJXD50_003D(ValueConstraint _0023_003Dz95Fqw_A_003D, Dimension _0023_003DzmTIZ8Fc_003D)
	{
		_0023_003DzVnfAoovaoMa7(_0023_003DzmTIZ8Fc_003D, _0023_003Dz95Fqw_A_003D);
		_design.Entities.Insert(_startEntitiesIndex, _0023_003DzmTIZ8Fc_003D);
		_0023_003DzmTIZ8Fc_003D._0023_003Dzo3By5vyys2vj7c0aCg_003D_003D(_0023_003Dz95Fqw_A_003D);
	}

	private void _0023_003Dz4eFoqUXpy9Lo(SketchCurve _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D, Entity _0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D, EntityList _0023_003Dzv7xH9gk_003D)
	{
		_0023_003DzUQJXD50_003D(_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D, _0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D, _0023_003Dzv7xH9gk_003D);
		_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D.ClearConstraints();
		Sketch.AddEntity(_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D);
	}

	private void _0023_003DzZEJDfL4_003D(SketchCurve _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D, Entity _0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D, EntityList _0023_003Dzv7xH9gk_003D)
	{
		_0023_003DzUQJXD50_003D(_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D, _0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D, _0023_003Dzv7xH9gk_003D);
		if (!(_0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D is Point))
		{
			_0023_003Dz40alAqE_003D(_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D.Vertices);
		}
	}

	private void _0023_003DzZEJDfL4_003D(SketchCurve _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D, Entity _0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D)
	{
		_0023_003DzZEJDfL4_003D(_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D, _0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D, _design.Entities);
	}

	public void DisplayConstraintEntities(VisualConstraint constraint)
	{
		SketchCurve[] entities = constraint.constraint.GetEntities();
		foreach (SketchCurve sketchCurve in entities)
		{
			if (sketchCurve._0023_003DzZ_ilKakl9sw5() != null)
			{
				Entity entity = sketchCurve._0023_003DzZ_ilKakl9sw5().Clone() as Entity;
				entity.TransformBy(new Align3D(Plane, DrawingPlane));
				entity.Regen(new RegenParams(_design.Entities));
				entity.LineWeight = ((entity is Point) ? Params.PointsThickness : Params.CurvesThickness);
				entity.LineWeightMethod = colorMethodType.byEntity;
				entity.Color = Params.HoveringColor;
				entity.ColorMethod = colorMethodType.byEntity;
				_design.TempEntities.Add(entity);
			}
		}
		constraint._0023_003DzRxMIdizdKQ7q(this);
	}

	internal bool _0023_003DzWyepPf1e8IHzxbfCCfJq3d4_003D(Entity _0023_003Dzs_0024uS8LA_003D)
	{
		if (!_0023_003Dzs_0024uS8LA_003D.IsSketchEntity())
		{
			if (_0023_003Dzs_0024uS8LA_003D is Dimension)
			{
				return GetConstraint(_0023_003Dzs_0024uS8LA_003D) != null;
			}
			return false;
		}
		return true;
	}

	internal List<Entity> _0023_003Dz485JMIMmTVuuyF12gg_003D_003D(Entity _0023_003Dzs_0024uS8LA_003D)
	{
		List<Entity> list = new List<Entity>();
		foreach (SketchCurve linkedCurf in ((SketchCurve)_0023_003Dzs_0024uS8LA_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).GetLinkedCurves())
		{
			list.Add(linkedCurf._0023_003DzZ_ilKakl9sw5());
		}
		return list;
	}

	internal void _0023_003Dz5c_0024UHl9YMBzg(Entity _0023_003Dzs_0024uS8LA_003D, Entity _0023_003DzPyl7PbULKZ0E)
	{
		((SketchCurve)_0023_003DzPyl7PbULKZ0E._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).AddLinkedCurve((SketchCurve)_0023_003Dzs_0024uS8LA_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D());
	}

	internal bool _0023_003Dzr0gJ7b7EF0Dt(Entity _0023_003Dzs_0024uS8LA_003D, Entity _0023_003DzPyl7PbULKZ0E)
	{
		return ((SketchCurve)_0023_003DzPyl7PbULKZ0E._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).DeleteLinkedCurve((SketchCurve)_0023_003Dzs_0024uS8LA_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D());
	}

	public void SetConstruction(Entity entity, bool status)
	{
		if (entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() != null)
		{
			((SketchCurve)entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Construction = status;
			if (status)
			{
				entity.LineTypeName = _constructionLineType.Name;
				entity.LineTypeMethod = colorMethodType.byEntity;
			}
			else
			{
				entity.LineTypeName = null;
				entity.LineTypeMethod = colorMethodType.byLayer;
			}
			_0023_003DzVnfAoovaoMa7(entity, (SketchCurve)entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D());
			_design.Entities.Regen();
		}
	}

	internal Point _0023_003Dz40alAqE_003D(SketchPoint _0023_003DzlY77YgY_003D, EntityList _0023_003Dzv7xH9gk_003D)
	{
		Point point = new Point(_0023_003DzlY77YgY_003D.Position);
		_0023_003DzUQJXD50_003D(_0023_003DzlY77YgY_003D, point, _0023_003Dzv7xH9gk_003D);
		return point;
	}

	private Point[] _0023_003Dz40alAqE_003D(IEnumerable<SketchPoint> _0023_003DzrdSL0CI_003D)
	{
		return _0023_003DzrdSL0CI_003D.Select(_0023_003Dza5njaOyVGsRLbuOcB2Wv_Gs_003D).ToArray();
	}

	public Point StartPoint(ICurve curve)
	{
		return (Point)((ISketchCurve)((Entity)curve)._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).StartPoint._0023_003DzZ_ilKakl9sw5();
	}

	public Point EndPoint(ICurve curve)
	{
		return (Point)((ISketchCurve)((Entity)curve)._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).EndPoint._0023_003DzZ_ilKakl9sw5();
	}

	public Point CenterPoint(Circle circle)
	{
		return (Point)((SketchCircle)circle._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Center._0023_003DzZ_ilKakl9sw5();
	}

	public Point CenterPoint(Ellipse ellipse)
	{
		return (Point)((SketchEllipse)ellipse._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Center._0023_003DzZ_ilKakl9sw5();
	}

	public Point[] GetPoints(Entity entity)
	{
		return ((SketchCurve)entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Vertices.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz_9FGZ6mgyRkZgJjYvVBtzpM_003D).ToArray();
	}

	public void Move(Point p, Point3D newLocation)
	{
		p.Position = newLocation;
		((SketchPoint)p._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Position = newLocation;
	}

	public void DrawOverlay(DrawSceneParams data)
	{
		if (_showFilledRegion && _isRegionReady && _isRegionValid)
		{
			_0023_003DzV_0024ZQkfRmT6J3(data);
		}
	}

	private void _0023_003DzV_0024ZQkfRmT6J3(DrawSceneParams _0023_003DzELu0Pss_003D)
	{
		blendStateType currentBlendState = _0023_003DzELu0Pss_003D.RenderContext.CurrentBlendState;
		Color currentWireColor = _0023_003DzELu0Pss_003D.RenderContext.CurrentWireColor;
		_0023_003DzELu0Pss_003D.RenderContext.SetState(blendStateType.Blend);
		_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(FilledRegionColor);
		for (int i = 0; i < sketchRegionsVertices.Count; i++)
		{
			Point3D[] array = sketchRegionsVertices[i];
			Point3D[] array2 = new Point3D[array.Length];
			for (int j = 0; j < array.Length; j++)
			{
				array2[j] = _0023_003DzELu0Pss_003D.Workspace.WorldToScreen(array[j]);
			}
			_0023_003DzELu0Pss_003D.RenderContext.DrawTrianglesPlanar(array2, sketchRegionsTriangles[i], Plane.AxisZ);
		}
		_0023_003DzELu0Pss_003D.RenderContext.SetState(currentBlendState);
		_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(currentWireColor);
	}

	private double _0023_003DzF51E6l8EH_0024Ri()
	{
		return 2.0 * _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
	}

	internal void _0023_003DzIrs5MDJ5nmrc(Constraint _0023_003Dz9EdxXqI_003D, EntityList _0023_003Dzv7xH9gk_003D)
	{
		VisualConstraint visualConstraint = null;
		List<IStackedLabel> list = new List<IStackedLabel>();
		if (_0023_003Dz9EdxXqI_003D is ValueConstraint { DimPos: var point3D } valueConstraint)
		{
			SketchCurve[] array = valueConstraint.GetEntities().ToArray();
			Entity entity = array[0]._0023_003DzZ_ilKakl9sw5();
			Dimension dimension = null;
			if (valueConstraint is DiameterConstraint || valueConstraint is RadiusConstraint)
			{
				if (entity is Arc arc)
				{
					RadialDim radialDim = new RadialDim(arc, point3D ?? arc.MidPoint, _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D(), Plane);
					radialDim.Regen(new RegenParams(0.0, _design));
					visualConstraint = new DiameterVisualConstraint(_0023_003Dz4lwYpErPR_sa(), radialDim, (RadiusConstraint)valueConstraint);
					dimension = radialDim;
				}
				else
				{
					Circle circle = entity as Circle;
					DiametricDim diametricDim = new DiametricDim(circle, point3D ?? circle.PointAt(Math.PI / 4.0), _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D(), Plane);
					visualConstraint = new DiameterVisualConstraint(_0023_003Dz4lwYpErPR_sa(), diametricDim, (RadiusConstraint)valueConstraint);
					dimension = diametricDim;
				}
			}
			else if (entity is Line line && valueConstraint is LengthConstraint _0023_003DzmRJV_0024zKY51eQ)
			{
				Utility._0023_003DzpgkCu6_h3HLE(Plane, line, out var _0023_003Dzrgqz890sj_0024X);
				LinearDim linearDim = new LinearDim(_0023_003Dzrgqz890sj_0024X, line.StartPoint, line.EndPoint, point3D ?? (line.MidPoint + _0023_003DzF51E6l8EH_0024Ri() * _0023_003Dzrgqz890sj_0024X.AxisY), _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
				visualConstraint = new LengthVisualConstraint(_0023_003Dz4lwYpErPR_sa(), linearDim, _0023_003DzmRJV_0024zKY51eQ);
				dimension = linearDim;
			}
			else if (entity is Line _0023_003DzQvaHyao_003D && valueConstraint is LinesDistanceConstraint _0023_003Dz8cUYt3Xy05yN)
			{
				SketchLine sketchLine = array[1] as SketchLine;
				_0023_003DzpgkCu6_h3HLE(_0023_003DzQvaHyao_003D, (Line)sketchLine._0023_003DzZ_ilKakl9sw5(), out var _0023_003Dzrgqz890sj_0024X2, out var _0023_003DzO97ip_0024TQ_0024juS, out var _0023_003DzM7o0gT3hjI);
				LinearDim linearDim2 = new LinearDim(_0023_003Dzrgqz890sj_0024X2, _0023_003DzO97ip_0024TQ_0024juS, _0023_003DzM7o0gT3hjI, point3D ?? (Point3D.MidPoint(_0023_003DzO97ip_0024TQ_0024juS, _0023_003DzM7o0gT3hjI) + _0023_003DzF51E6l8EH_0024Ri() * _0023_003Dzrgqz890sj_0024X2.AxisY), _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
				visualConstraint = new LinesDistanceVisualConstraint(_0023_003Dz4lwYpErPR_sa(), linearDim2, _0023_003Dz8cUYt3Xy05yN);
				dimension = linearDim2;
			}
			else if (entity is Point point && valueConstraint is PointLineDistanceConstraint _0023_003DzylQfrn1EnYzu)
			{
				SketchCurve sketchCurve = array[1];
				_0023_003DzpgkCu6_h3HLE((Line)sketchCurve._0023_003DzZ_ilKakl9sw5(), point.Position, out var _0023_003Dzrgqz890sj_0024X3, out var _0023_003DzO97ip_0024TQ_0024juS2, out var _0023_003DzM7o0gT3hjI2);
				LinearDim linearDim3 = new LinearDim(_0023_003Dzrgqz890sj_0024X3, _0023_003DzO97ip_0024TQ_0024juS2, _0023_003DzM7o0gT3hjI2, point3D ?? (Point3D.MidPoint(_0023_003DzO97ip_0024TQ_0024juS2, _0023_003DzM7o0gT3hjI2) + _0023_003DzF51E6l8EH_0024Ri() * _0023_003Dzrgqz890sj_0024X3.AxisY), _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
				visualConstraint = new PointLineDistanceVisualConstraint(_0023_003Dz4lwYpErPR_sa(), linearDim3, _0023_003DzylQfrn1EnYzu);
				dimension = linearDim3;
			}
			else if (entity is Arc arc2 && valueConstraint is AngleConstraint _0023_003Dzaqvleb_7_00244W)
			{
				_0023_003DzbBuN7j7SY3kL(arc2, out var _0023_003Dzrgqz890sj_0024X4, out var _0023_003DzO97ip_0024TQ_0024juS3, out var _0023_003DzM7o0gT3hjI3);
				AngularDim angularDim = new AngularDim(_0023_003Dzrgqz890sj_0024X4, _0023_003DzO97ip_0024TQ_0024juS3, _0023_003DzM7o0gT3hjI3, point3D ?? arc2.MidPoint, _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
				visualConstraint = new AngleVisualConstraint(_0023_003Dz4lwYpErPR_sa(), angularDim, _0023_003Dzaqvleb_7_00244W);
				dimension = angularDim;
			}
			else if (entity is Point point2 && valueConstraint is AngleConstraint _0023_003Dzaqvleb_7_00244W2)
			{
				SketchPoint sketchPoint = array[2] as SketchPoint;
				AngularDim angularDim2 = new AngularDim(new Plane((array[1] as SketchPoint).Position, Plane.AxisX, Plane.AxisY), point2.Position, ((SketchPoint)array[1]).Position, point3D ?? Point3D.MidPoint(point2.Position, sketchPoint.Position), _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
				visualConstraint = new AngleVisualConstraint(_0023_003Dz4lwYpErPR_sa(), angularDim2, _0023_003Dzaqvleb_7_00244W2);
				dimension = angularDim2;
			}
			else if (entity is Line line2 && valueConstraint is AngleConstraint _0023_003Dzaqvleb_7_00244W3)
			{
				Line line3 = (Line)(array[1] as SketchLine)._0023_003DzZ_ilKakl9sw5();
				if (point3D == null)
				{
					Point2D point2D = Point2D.MidPoint(line2.EndPoint, line3.EndPoint);
					point3D = new Point3D(point2D.X, point2D.Y);
				}
				AngularDim angularDim3 = new AngularDim(Plane, line2, line3, point3D, point3D, _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
				visualConstraint = new AngleVisualConstraint(_0023_003Dz4lwYpErPR_sa(), angularDim3, _0023_003Dzaqvleb_7_00244W3);
				dimension = angularDim3;
			}
			else if (entity is Point point3 && valueConstraint is PointsDistanceConstraint _0023_003DzGz_0024tpxzOjJUx)
			{
				Point point4 = (Point)array[1]._0023_003DzZ_ilKakl9sw5();
				_0023_003DzpgkCu6_h3HLE(point3.Position, point4.Position, out var _0023_003Dzrgqz890sj_0024X5, out var _0023_003DzO97ip_0024TQ_0024juS4, out var _0023_003DzM7o0gT3hjI4);
				LinearDim linearDim4 = new LinearDim(_0023_003Dzrgqz890sj_0024X5, _0023_003DzO97ip_0024TQ_0024juS4, _0023_003DzM7o0gT3hjI4, point3D ?? (Point3D.MidPoint(_0023_003DzO97ip_0024TQ_0024juS4, _0023_003DzM7o0gT3hjI4) + _0023_003DzF51E6l8EH_0024Ri() * _0023_003Dzrgqz890sj_0024X5.AxisY), _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
				visualConstraint = new PointsDistanceVisualConstraint(_0023_003Dz4lwYpErPR_sa(), linearDim4, _0023_003DzGz_0024tpxzOjJUx);
				dimension = linearDim4;
			}
			else if (valueConstraint is EqualConstraint equalConstraint)
			{
				if (equalConstraint.IsEqualLength())
				{
					IStackedLabel stackedLabel = _0023_003DzLuIkz4x3FVHS().Create(labelType.Equal, equalConstraint.GetEntities()[0], equalConstraint);
					IStackedLabel stackedLabel2 = _0023_003DzLuIkz4x3FVHS().Create(labelType.Equal, equalConstraint.GetEntities()[1], equalConstraint);
					_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel);
					_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel2);
					visualConstraint = new EqualVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[2] { stackedLabel, stackedLabel2 }, equalConstraint);
				}
				else
				{
					IStackedLabel stackedLabel3 = _0023_003DzLuIkz4x3FVHS().Create(labelType.EqualRadius, equalConstraint.GetEntities()[0], equalConstraint);
					IStackedLabel stackedLabel4 = _0023_003DzLuIkz4x3FVHS().Create(labelType.EqualRadius, equalConstraint.GetEntities()[1], equalConstraint);
					_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel3);
					_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel4);
					visualConstraint = new EqualVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[2] { stackedLabel3, stackedLabel4 }, equalConstraint);
				}
			}
			else if (valueConstraint is ConcentricCirclesDistanceConstraint _0023_003DzbHPUachs5gMzZUQznfcXzyHPeOeOt_jZhw_003D_003D)
			{
				Circle circle2 = (Circle)array[0]._0023_003DzZ_ilKakl9sw5();
				Circle circle3 = (Circle)array[1]._0023_003DzZ_ilKakl9sw5();
				if (circle2 != null && circle3 != null)
				{
					_0023_003DzpgkCu6_h3HLE(circle2, circle3, out var _0023_003Dzrgqz890sj_0024X6, out var _0023_003DzO97ip_0024TQ_0024juS5, out var _0023_003DzM7o0gT3hjI5);
					LinearDim linearDim5 = new LinearDim(_0023_003Dzrgqz890sj_0024X6, _0023_003DzO97ip_0024TQ_0024juS5, _0023_003DzM7o0gT3hjI5, point3D ?? (Point2D.MidPoint(_0023_003DzO97ip_0024TQ_0024juS5, _0023_003DzM7o0gT3hjI5) + _0023_003DzF51E6l8EH_0024Ri() * _0023_003Dzrgqz890sj_0024X6.AxisY), _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
					visualConstraint = new ConcentricCirclesDistanceVisualConstraint(_0023_003Dz4lwYpErPR_sa(), linearDim5, _0023_003DzbHPUachs5gMzZUQznfcXzyHPeOeOt_jZhw_003D_003D);
					dimension = linearDim5;
				}
			}
			else if (valueConstraint is MidPointConstraint midPointConstraint)
			{
				IStackedLabel stackedLabel5 = _0023_003DzLuIkz4x3FVHS().Create(labelType.MidPoint, midPointConstraint.Point, midPointConstraint);
				_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel5);
				visualConstraint = new MidPointVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[1] { stackedLabel5 }, midPointConstraint);
			}
			else if (valueConstraint is PointAtConstraint pointAtConstraint)
			{
				IStackedLabel stackedLabel6 = _0023_003DzLuIkz4x3FVHS().Create(labelType.PointAt, pointAtConstraint.Point, pointAtConstraint);
				_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel6);
				visualConstraint = new PointAtVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[1] { stackedLabel6 }, pointAtConstraint);
			}
			else if (valueConstraint is PointOnConstraint pointOnConstraint)
			{
				IStackedLabel stackedLabel7 = _0023_003DzLuIkz4x3FVHS().Create(labelType.PointOn, pointOnConstraint.Point, pointOnConstraint);
				_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel7);
				visualConstraint = new PointOnVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[1] { stackedLabel7 }, pointOnConstraint);
			}
			if (dimension != null)
			{
				if (point3D != null)
				{
					dimension.DimLinePosition = point3D;
					_0023_003Dz36TNao7oaYj6(dimension, valueConstraint);
				}
				_0023_003DzVnfAoovaoMa7(dimension, valueConstraint);
				_0023_003Dzv7xH9gk_003D.Add(dimension);
			}
		}
		else if (_0023_003Dz9EdxXqI_003D is PolygonConstraint polygonConstraint)
		{
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(labelType.Polygon, _0023_003Dz9EdxXqI_003D.GetEntities()[0], polygonConstraint));
			visualConstraint = new PolygonVisualConstraint(_0023_003Dz4lwYpErPR_sa(), list.ToArray(), polygonConstraint);
		}
		else if (_0023_003Dz9EdxXqI_003D is MirrorConstraint mirrorConstraint)
		{
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(labelType.Mirror, _0023_003Dz9EdxXqI_003D.GetEntities()[0], mirrorConstraint));
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(labelType.Mirror, _0023_003Dz9EdxXqI_003D.GetEntities()[1], mirrorConstraint));
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(labelType.Mirror, _0023_003Dz9EdxXqI_003D.GetEntities()[2], mirrorConstraint));
			visualConstraint = new MirrorVisualConstraint(_0023_003Dz4lwYpErPR_sa(), list.ToArray(), mirrorConstraint);
		}
		else if (_0023_003Dz9EdxXqI_003D is PointFixedConstraint pointFixedConstraint)
		{
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(labelType.Fix, _0023_003Dz9EdxXqI_003D.GetEntities()[0], pointFixedConstraint));
			visualConstraint = new PointFixedVisualConstraint(_0023_003Dz4lwYpErPR_sa(), list.ToArray(), pointFixedConstraint);
		}
		else if (_0023_003Dz9EdxXqI_003D is CollinearPointsConstraint collinearPointsConstraint)
		{
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(labelType.Collinear, collinearPointsConstraint.GetEntities()[0], collinearPointsConstraint));
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(labelType.Collinear, collinearPointsConstraint.GetEntities()[1], collinearPointsConstraint));
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(labelType.Collinear, collinearPointsConstraint.GetEntities()[2], collinearPointsConstraint));
			visualConstraint = new CollinearPointsVisualConstraint(_0023_003Dz4lwYpErPR_sa(), list.ToArray(), collinearPointsConstraint);
		}
		else if (_0023_003Dz9EdxXqI_003D is HVConstraint hVConstraint)
		{
			labelType type = (hVConstraint.IsHorizontal ? labelType.Horizontal : labelType.Vertical);
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(type, hVConstraint.GetEntities()[0], hVConstraint));
			visualConstraint = new HvVisualConstraint(_0023_003Dz4lwYpErPR_sa(), list.ToArray(), hVConstraint);
		}
		else if (_0023_003Dz9EdxXqI_003D is CoincidentConstraint coincidentConstraint)
		{
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(labelType.Join, coincidentConstraint.GetEntities()[0], coincidentConstraint));
			visualConstraint = new CoincidentVisualConstraint(_0023_003Dz4lwYpErPR_sa(), list.ToArray(), coincidentConstraint);
		}
		else if (_0023_003Dz9EdxXqI_003D is TangentConstraint tangentConstraint)
		{
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(labelType.Tangent, tangentConstraint.GetEntities()[0], tangentConstraint));
			visualConstraint = new TangentVisualConstraint(_0023_003Dz4lwYpErPR_sa(), list.ToArray(), tangentConstraint);
		}
		else if (_0023_003Dz9EdxXqI_003D is CollinearConstraint collinearConstraint)
		{
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(labelType.Collinear, collinearConstraint.GetEntities()[0], collinearConstraint));
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(labelType.Collinear, collinearConstraint.GetEntities()[1], collinearConstraint));
			visualConstraint = new CollinearVisualConstraint(_0023_003Dz4lwYpErPR_sa(), list.ToArray(), collinearConstraint);
		}
		else if (_0023_003Dz9EdxXqI_003D is ParallelConstraint parallelConstraint)
		{
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(labelType.Parallel, parallelConstraint.GetEntities()[0], parallelConstraint));
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(labelType.Parallel, parallelConstraint.GetEntities()[1], parallelConstraint));
			visualConstraint = new ParallelLinesVisualConstraint(_0023_003Dz4lwYpErPR_sa(), list.ToArray(), parallelConstraint);
		}
		else if (_0023_003Dz9EdxXqI_003D is PerpendicularConstraint perpendicularConstraint)
		{
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(labelType.Perpendicular, perpendicularConstraint.GetEntities()[0], perpendicularConstraint));
			list.Add(_0023_003DzLuIkz4x3FVHS().Create(labelType.Perpendicular, perpendicularConstraint.GetEntities()[1], perpendicularConstraint));
			visualConstraint = new PerpendicularVisualConstraint(_0023_003Dz4lwYpErPR_sa(), list.ToArray(), perpendicularConstraint);
		}
		if (visualConstraint != null && list.Count > 0)
		{
			IViewportInternal viewportInternal = _0023_003Dz4lwYpErPR_sa();
			ILabel[] labels = list.ToArray();
			viewportInternal.AddLabel(labels);
		}
	}

	public Point AddPoint(Point2D point)
	{
		return _0023_003Dz40alAqE_003D(Sketch.AddPoint(point), _design.Entities);
	}

	public Curve[] AddSketchSplineFromCurveEntity(Curve curve)
	{
		return _0023_003DzlVU_Ji1CXxI_0024u7vZ5jkWxlV_VdB3s3zvYg_003D_003D(curve, _0023_003Dzb9XrRpQ_003D: true);
	}

	private Curve[] _0023_003DzlVU_Ji1CXxI_0024u7vZ5jkWxlV_VdB3s3zvYg_003D_003D(Curve _0023_003Dz8fpRyMu9aKjE, bool _0023_003Dzb9XrRpQ_003D)
	{
		Curve[] array = _0023_003Dz8fpRyMu9aKjE.Decompose();
		if (array.Length == 1)
		{
			array[0] = _0023_003Dz8fpRyMu9aKjE;
		}
		SketchSpline sketchSpline = null;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].Degree == 1)
			{
				array[i].DegreeElevate(2);
			}
			else if (array[i].Degree == 2)
			{
				array[i].DegreeElevate(1);
			}
			List<Point2D> list = new List<Point2D>();
			Point4D[] controlPoints = array[i].ControlPoints;
			foreach (Point4D point4D in controlPoints)
			{
				list.Add(Plane.Project(point4D.Euclid));
			}
			SketchSpline sketchSpline2 = Sketch.AddSpline(list);
			_0023_003DzZEJDfL4_003D(sketchSpline2, array[i]);
			if (sketchSpline != null && _0023_003Dzb9XrRpQ_003D)
			{
				_0023_003Dz9_0024HudZfEoQzz(sketchSpline.ControlPoints[3], sketchSpline2.ControlPoints[0]);
				AddConstraintTangent(array[i - 1], array[i]);
			}
			sketchSpline = sketchSpline2;
		}
		if (_0023_003Dz8fpRyMu9aKjE.IsClosed && _0023_003Dzb9XrRpQ_003D)
		{
			SketchSpline sketchSpline3 = array[0]._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchSpline;
			_0023_003Dz9_0024HudZfEoQzz(sketchSpline.ControlPoints.Last(), sketchSpline3.ControlPoints[0]);
			if (array.Length > 2)
			{
				AddConstraintTangent(array[0], array.Last());
			}
		}
		return array;
	}

	private Curve _0023_003Dzz5bbYqYRdCsr_0024b5sHH8iml4_003D(Point3D _0023_003DzeoY7iyo_003D, Point3D _0023_003Dzl_0024MIsC0_003D)
	{
		Vector3D asVector = (_0023_003Dzl_0024MIsC0_003D - _0023_003DzeoY7iyo_003D).AsVector;
		Vector3D vector3D = Vector3D.Cross(Plane.AxisZ, asVector);
		return Curve.LocalInterpolation(new PointTangent[3]
		{
			new PointTangent(_0023_003DzeoY7iyo_003D.X, _0023_003DzeoY7iyo_003D.Y, _0023_003DzeoY7iyo_003D.Z, asVector.X, asVector.Y, asVector.Z),
			new PointTangent(_0023_003Dzl_0024MIsC0_003D.X, _0023_003Dzl_0024MIsC0_003D.Y, _0023_003Dzl_0024MIsC0_003D.Z, vector3D.X, vector3D.Y, vector3D.Z),
			new PointTangent(_0023_003DzeoY7iyo_003D.X, _0023_003DzeoY7iyo_003D.Y, _0023_003DzeoY7iyo_003D.Z, 0.0 - asVector.X, 0.0 - asVector.Y, 0.0 - asVector.Z)
		});
	}

	public Curve[] AddSpline(IList<Point2D> points)
	{
		bool flag = points[0] == points.Last();
		Curve[] array = ((flag && points.Count == 3) ? _0023_003Dzz5bbYqYRdCsr_0024b5sHH8iml4_003D(Plane.PointAt(points[0]), Plane.PointAt(points[1])) : Curve.CubicSplineInterpolation(points.Select((Point2D _0023_003DzB68dg9Q_003D) => Plane.PointAt(_0023_003DzB68dg9Q_003D)).ToList())).Decompose();
		SketchSpline sketchSpline = null;
		for (int num = 0; num < array.Length; num++)
		{
			SketchSpline sketchSpline2 = Sketch.AddSpline(array[num].ControlPoints.Select(_0023_003Dzjv1UR9r25kdKBrFYzKDykgY_003D).ToArray());
			_0023_003DzZEJDfL4_003D(sketchSpline2, array[num]);
			SketchPoint[] array2 = sketchSpline2.Vertices.ToArray();
			for (int num2 = 0; num2 < array2.Length - 1; num2 += 2)
			{
				Line line = AddLine(array2[num2].PlanePosition, array2[num2 + 1].PlanePosition);
				AddConstraintJoin(StartPoint(line), array2[num2]._0023_003DzZ_ilKakl9sw5());
				AddConstraintJoin(EndPoint(line), array2[num2 + 1]._0023_003DzZ_ilKakl9sw5());
				SetConstruction(line, status: true);
				_0023_003Dz5c_0024UHl9YMBzg(line, array[num]);
			}
			if (sketchSpline != null)
			{
				_0023_003Dz9_0024HudZfEoQzz(sketchSpline.ControlPoints[3], sketchSpline2.ControlPoints[0]);
				AddConstraintTangent(array[num], array[num - 1]);
			}
			sketchSpline = sketchSpline2;
		}
		if (flag)
		{
			SketchSpline sketchSpline3 = array[0]._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchSpline;
			_0023_003Dz9_0024HudZfEoQzz(sketchSpline.ControlPoints[3], sketchSpline3.ControlPoints[0]);
			if (array.Length > 2)
			{
				AddConstraintTangent(array[0], array.Last());
			}
		}
		return array.ToArray();
	}

	public Ellipse AddEllipse(Point2D center, double radiusX, double radiusY)
	{
		Ellipse ellipse = new Ellipse(Sketch.SketchPlane, center, radiusX, radiusY);
		AddEllipse(ellipse);
		return ellipse;
	}

	internal Point[] _0023_003DzRddYZes_003D(Ellipse _0023_003DzWUywqIo_003D, bool _0023_003DzH0kpLC0_003D)
	{
		SketchEllipse _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D = Sketch.ProjectEllipse(_0023_003DzWUywqIo_003D);
		List<Point> list = new List<Point>();
		_0023_003DzZEJDfL4_003D(_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D, _0023_003DzWUywqIo_003D);
		for (double num = 0.0; num < 1.0; num += 0.25)
		{
			Point point = new Point(_0023_003DzWUywqIo_003D.PointAt(num * _0023_003DzWUywqIo_003D.Domain.Length));
			AddPoint(point);
			list.Add(point);
			if (!_0023_003DzH0kpLC0_003D)
			{
				AddConstraintPointAt(point, _0023_003DzWUywqIo_003D, num);
			}
		}
		return list.ToArray();
	}

	internal Point[] _0023_003DzLlGpKhZuCWqZx9ZXoOJeXC0_003D(EllipticalArc _0023_003DzN9YG4_1LCGXe, bool _0023_003DzH0kpLC0_003D)
	{
		SketchEllipse _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D = Sketch.ProjectEllipticalArc(_0023_003DzN9YG4_1LCGXe);
		List<Point> list = new List<Point>();
		_0023_003DzZEJDfL4_003D(_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D, _0023_003DzN9YG4_1LCGXe);
		for (double num = 0.0; num < 1.0; num += 0.25)
		{
			Point point = new Point(_0023_003DzN9YG4_1LCGXe.PointAt(num * (Math.PI * 2.0)));
			AddPoint(point);
			list.Add(point);
			if (!_0023_003DzH0kpLC0_003D)
			{
				AddConstraintPointAt(point, _0023_003DzN9YG4_1LCGXe, num);
			}
		}
		return list.ToArray();
	}

	public Point[] AddEllipse(Ellipse ellipse)
	{
		Point2D point2D = Plane.Project(ellipse.Center);
		Vector2D u = Plane.Project(ellipse.Plane.AxisX);
		Vector2D v = Plane.Project(ellipse.Plane.AxisY);
		SketchEllipse _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D = Sketch.AddEllipse(point2D.X, point2D.Y, ellipse.RadiusX, ellipse.RadiusY, u, v);
		List<Point> list = new List<Point>();
		_0023_003DzZEJDfL4_003D(_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D, ellipse);
		for (double num = 0.0; num < 1.0; num += 0.25)
		{
			Point point = new Point(ellipse.PointAt(num * ellipse.Domain.Length));
			AddPoint(point);
			list.Add(point);
			AddConstraintPointAt(point, ellipse, num);
		}
		return list.ToArray();
	}

	public Line AddLine(Point2D start, Point2D end)
	{
		Line line = new Line(Sketch.SketchPlane, start, end);
		AddLine(line);
		return line;
	}

	public void FixEntity(Entity ent, bool fix)
	{
		((SketchCurve)ent._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Fixed = fix;
	}

	public ICurve[] ProjectCurve(ICurve curve, bool fix = true)
	{
		return _0023_003DzgJYQYDOTBsxX(curve, fix, _0023_003DzBEvOagU_003D: true);
	}

	private ICurve[] _0023_003DzgJYQYDOTBsxX(ICurve _0023_003DzEZ_0024X0WU_003D, bool _0023_003DzH0kpLC0_003D, bool _0023_003DzBEvOagU_003D)
	{
		ICurve[] array = null;
		ICurve curve = (ICurve)_0023_003DzEZ_0024X0WU_003D.Clone();
		if (!_0023_003DzBEvOagU_003D)
		{
			((Entity)curve).TransformBy(new Align3D(Plane.XY, Plane));
		}
		Plane plane;
		if (curve is Point point)
		{
			Point point2 = AddPoint(Plane.Project(point.Position));
			array = new ICurve[1] { point2 };
		}
		else if (curve is Line line)
		{
			array = new ICurve[1] { line };
			AddLine(array[0] as Line);
		}
		else if (curve.IsPlanar(Utility._0023_003DzheSR8QM7q9ya, out plane))
		{
			if (Vector3D.AreOrthogonal(plane.AxisZ, Plane.AxisZ))
			{
				array = _0023_003Dz_XowAKhIk0tYpAji9vjqH1c_003D(curve, plane);
			}
			else if (Vector3D.AreParallel(plane.AxisZ, Plane.AxisZ))
			{
				array = _0023_003DzAsbmviyvSoiQ(_0023_003DzH0kpLC0_003D, _0023_003DzBEvOagU_003D, curve, array);
			}
		}
		if (array == null || array.Length == 0)
		{
			return new ICurve[0];
		}
		for (int i = 0; i < array.Length; i++)
		{
			Entity ent = (Entity)array[i];
			if (_0023_003DzH0kpLC0_003D)
			{
				FixEntity(ent, fix: true);
			}
		}
		if (_0023_003DzBEvOagU_003D)
		{
			UpdateAndInvalidate();
		}
		return array;
	}

	private ICurve[] _0023_003Dz6zMTnIdRFqjU(ICurve _0023_003Dz_Gzfs9c_003D)
	{
		ICurve[] array = new ICurve[1] { _0023_003Dz_Gzfs9c_003D.GetNurbsForm() };
		return _0023_003DzlVU_Ji1CXxI_0024u7vZ5jkWxlV_VdB3s3zvYg_003D_003D(array[0] as Curve, _0023_003Dzb9XrRpQ_003D: false);
	}

	private ICurve[] _0023_003DzAsbmviyvSoiQ(bool _0023_003DzH0kpLC0_003D, bool _0023_003DzBEvOagU_003D, ICurve _0023_003Dz_Gzfs9c_003D, ICurve[] _0023_003DzmihgIpFy0H92)
	{
		ICurve[] array;
		if (_0023_003Dz_Gzfs9c_003D is Ellipse ellipse)
		{
			if (ellipse is EllipticalArc { Angle: { IsTwoPI: false } } ellipticalArc)
			{
				if (Vector3D.AreOpposite(ellipticalArc.Plane.AxisZ, Plane.AxisZ, 0.01))
				{
					ellipticalArc.Reverse();
				}
				if (_0023_003DzBEvOagU_003D)
				{
					_0023_003DzLlGpKhZuCWqZx9ZXoOJeXC0_003D(ellipticalArc, _0023_003DzH0kpLC0_003D);
				}
				else
				{
					AddEllipticalArc(ellipticalArc);
				}
				_0023_003DzmihgIpFy0H92 = new ICurve[1] { ellipticalArc };
			}
			else
			{
				if (Vector3D.AreOpposite(ellipse.Plane.AxisZ, Plane.AxisZ, 0.01))
				{
					ellipse.Reverse();
				}
				if (_0023_003DzBEvOagU_003D)
				{
					_0023_003DzRddYZes_003D(ellipse, _0023_003DzH0kpLC0_003D);
				}
				else
				{
					AddEllipse(ellipse);
				}
				_0023_003DzmihgIpFy0H92 = new ICurve[1] { ellipse };
			}
		}
		else if (_0023_003Dz_Gzfs9c_003D is Arc arc)
		{
			if (arc.IsCircle)
			{
				_0023_003DzmihgIpFy0H92 = new ICurve[1]
				{
					new Circle(arc.Plane, arc.Center, arc.Radius)
				};
				AddCircle(_0023_003DzmihgIpFy0H92[0] as Circle);
			}
			else
			{
				_0023_003DzmihgIpFy0H92 = new ICurve[1] { arc };
				if (Vector3D.AreOpposite(arc.Plane.AxisZ, Plane.AxisZ, 0.01))
				{
					((Arc)_0023_003DzmihgIpFy0H92[0]).Reverse();
				}
				_0023_003DzmihgIpFy0H92 = new ICurve[1] { AddArc(Plane.Project(((Arc)_0023_003DzmihgIpFy0H92[0]).Center), Plane.Project(_0023_003DzmihgIpFy0H92[0].StartPoint), Plane.Project(_0023_003DzmihgIpFy0H92[0].EndPoint)) };
			}
		}
		else if (_0023_003Dz_Gzfs9c_003D is Circle circle)
		{
			_0023_003DzmihgIpFy0H92 = new ICurve[1] { circle };
			AddCircle(_0023_003DzmihgIpFy0H92[0] as Circle);
		}
		else if (_0023_003Dz_Gzfs9c_003D is Curve curve)
		{
			_0023_003DzmihgIpFy0H92 = new ICurve[1] { curve };
			array = _0023_003DzlVU_Ji1CXxI_0024u7vZ5jkWxlV_VdB3s3zvYg_003D_003D(_0023_003DzmihgIpFy0H92[0] as Curve, _0023_003Dzb9XrRpQ_003D: false);
			_0023_003DzmihgIpFy0H92 = array;
		}
		else if (_0023_003Dz_Gzfs9c_003D is LinearPath linearPath)
		{
			int num = linearPath.Vertices.Length - 1;
			_0023_003DzmihgIpFy0H92 = new ICurve[num];
			for (int i = 0; i < num; i++)
			{
				AddLine((Line)(_0023_003DzmihgIpFy0H92[i] = new Line(linearPath.Vertices[i], linearPath.Vertices[i + 1])));
			}
		}
		array = _0023_003DzmihgIpFy0H92;
		for (int j = 0; j < array.Length; j++)
		{
			((Entity)array[j])._0023_003DzqKkfI8jwDACTQroBqA_003D_003D((Entity)_0023_003Dz_Gzfs9c_003D);
		}
		return _0023_003DzmihgIpFy0H92;
	}

	private ICurve[] _0023_003Dz_XowAKhIk0tYpAji9vjqH1c_003D(ICurve _0023_003Dz_Gzfs9c_003D, Plane _0023_003Dzrgqz890sj_0024X9)
	{
		Line line = _0023_003DzYjw5848AKzk_fswDRAZ_PfgBGOFY(_0023_003Dz_Gzfs9c_003D, _0023_003Dzrgqz890sj_0024X9);
		ICurve[] array = new ICurve[1] { line };
		AddLine(array[0] as Line);
		return array;
	}

	public static void SynchProjectedCurve(SketchEntity sketchEntity, ICurve source, ICurve dest, int patchIndex = -1)
	{
		SketchItem sketchItem = ((Entity)dest)._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
		Plane plane;
		if (source is Line && sketchItem is SketchLine _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D)
		{
			_0023_003Dzba1siSYYSPKs(source, _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D);
		}
		else if (source.IsPlanar(Utility._0023_003DzheSR8QM7q9ya, out plane) && Vector3D.AreOrthogonal(plane.AxisZ, sketchEntity.Plane.AxisZ) && sketchItem is SketchLine _0023_003DzGcl_0024E9o_003D)
		{
			_0023_003DzWI1QrgsyIDuWEtNWk2bSnbk_003D(sketchEntity, source, patchIndex, plane, _0023_003DzGcl_0024E9o_003D);
		}
		else if (source is Arc && sketchItem is SketchArc _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D2)
		{
			_0023_003Dzab5eNDy7wKIH(sketchEntity, source, _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D2);
		}
		else if (source is Circle && sketchItem is SketchCircle _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D3)
		{
			_0023_003DzCtbCcu_0024ki8rgjsczlQ_003D_003D(sketchEntity, source, _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D3);
		}
		else if (source is Curve && sketchItem is SketchSpline _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D4)
		{
			_0023_003DzJNKm9_Uw2zfj(source, _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D4, patchIndex);
		}
		else if (source is Ellipse && sketchItem is SketchEllipse _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D5)
		{
			_0023_003DzePwZ4UkrX4OX(source, _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D5);
		}
		else if (source is Point && sketchItem is SketchPoint _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D6)
		{
			_0023_003Dz_00249K9sShTpEyn(source, _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D6);
		}
	}

	private static void _0023_003DzJNKm9_Uw2zfj(ICurve _0023_003DzTZ4X7t3zT087, SketchCurve _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D, int _0023_003Dz1tVbeNw_003D)
	{
		Curve obj = (Curve)_0023_003DzTZ4X7t3zT087;
		SketchSpline _0023_003DznYbCLDUxnKSb = (SketchSpline)_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D;
		Curve[] array = obj.Decompose();
		if (_0023_003Dz1tVbeNw_003D >= 0 && _0023_003Dz1tVbeNw_003D < array.Length)
		{
			_0023_003DzBXQthKzfV_lLRB_0024Sqg_003D_003D(_0023_003DznYbCLDUxnKSb, array[_0023_003Dz1tVbeNw_003D]);
		}
	}

	private static void _0023_003Dz_00249K9sShTpEyn(ICurve _0023_003DzTZ4X7t3zT087, SketchCurve _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D)
	{
		SketchPoint obj = (SketchPoint)_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D;
		Point3D point3D = (obj.Position = ((Point)_0023_003DzTZ4X7t3zT087).Position);
		Constraint[] constraints = obj.Constraints;
		foreach (Constraint constraint in constraints)
		{
			if (constraint is PointFixedConstraint)
			{
				((PointFixedConstraint)constraint).UpdateCoordinate(point3D.X, point3D.Y);
			}
		}
	}

	private static void _0023_003DzePwZ4UkrX4OX(ICurve _0023_003DzTZ4X7t3zT087, SketchCurve _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D)
	{
		Ellipse ellipse = (Ellipse)_0023_003DzTZ4X7t3zT087;
		SketchEllipse sketchEllipse = (SketchEllipse)_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D;
		sketchEllipse.Center.SetPosition(ellipse.Center);
		sketchEllipse.RadiusX = ellipse.RadiusX;
		sketchEllipse.RadiusY = ellipse.RadiusY;
		Constraint[] constraints = sketchEllipse.Center.Constraints;
		foreach (Constraint constraint in constraints)
		{
			if (constraint is PointFixedConstraint)
			{
				((PointFixedConstraint)constraint).UpdateCoordinate(sketchEllipse.Center.PlanePosition.X, sketchEllipse.Center.PlanePosition.Y);
			}
		}
	}

	private static void _0023_003DzCtbCcu_0024ki8rgjsczlQ_003D_003D(SketchEntity _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D, ICurve _0023_003DzTZ4X7t3zT087, SketchCurve _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D)
	{
		Circle circle = (Circle)_0023_003DzTZ4X7t3zT087;
		SketchCircle sketchCircle = (SketchCircle)_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D;
		if (!Vector3D.AreParallel(circle.Plane.AxisZ, _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D.Plane.AxisZ))
		{
			return;
		}
		sketchCircle.Center.SetPosition(circle.Center);
		sketchCircle.Radius = circle.Radius;
		Constraint[] constraints = sketchCircle.Constraints;
		foreach (Constraint constraint in constraints)
		{
			if (constraint is DiameterConstraint)
			{
				((DiameterConstraint)constraint).SetValue(2.0 * circle.Radius);
			}
		}
		constraints = sketchCircle.Center.Constraints;
		foreach (Constraint constraint2 in constraints)
		{
			if (constraint2 is PointFixedConstraint)
			{
				((PointFixedConstraint)constraint2).UpdateCoordinate(sketchCircle.Center.PlanePosition.X, sketchCircle.Center.PlanePosition.Y);
			}
		}
	}

	private static void _0023_003Dzab5eNDy7wKIH(SketchEntity _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D, ICurve _0023_003DzTZ4X7t3zT087, SketchCurve _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D)
	{
		Arc arc = (Arc)_0023_003DzTZ4X7t3zT087;
		SketchArc sketchArc = (SketchArc)_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D;
		if (!Vector3D.AreParallel(arc.Plane.AxisZ, _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D.Plane.AxisZ))
		{
			return;
		}
		if (Vector3D.AreOpposite(arc.Plane.AxisZ, _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D.Plane.AxisZ))
		{
			sketchArc.StartPoint.SetPosition(arc.EndPoint);
			sketchArc.EndPoint.SetPosition(arc.StartPoint);
		}
		else
		{
			sketchArc.StartPoint.SetPosition(arc.StartPoint);
			sketchArc.EndPoint.SetPosition(arc.EndPoint);
		}
		sketchArc.Center.SetPosition(arc.Center);
		Constraint[] constraints = sketchArc.StartPoint.Constraints;
		foreach (Constraint constraint in constraints)
		{
			if (constraint is PointFixedConstraint)
			{
				((PointFixedConstraint)constraint).UpdateCoordinate(sketchArc.StartPoint.PlanePosition.X, sketchArc.StartPoint.PlanePosition.Y);
			}
		}
		constraints = sketchArc.Center.Constraints;
		foreach (Constraint constraint2 in constraints)
		{
			if (constraint2 is PointFixedConstraint)
			{
				((PointFixedConstraint)constraint2).UpdateCoordinate(sketchArc.Center.PlanePosition.X, sketchArc.Center.PlanePosition.Y);
			}
		}
		constraints = sketchArc.Constraints;
		foreach (Constraint constraint3 in constraints)
		{
			if (constraint3 is LengthConstraint)
			{
				((LengthConstraint)constraint3).SetValue(arc.Length());
			}
		}
	}

	private static void _0023_003DzWI1QrgsyIDuWEtNWk2bSnbk_003D(SketchEntity _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D, ICurve _0023_003DzTZ4X7t3zT087, int _0023_003Dz1tVbeNw_003D, Plane _0023_003Dzrgqz890sj_0024X9, SketchLine _0023_003DzGcl_0024E9o_003D)
	{
		ICurve _0023_003DzEZ_0024X0WU_003D = _0023_003DzTZ4X7t3zT087;
		if (_0023_003DzTZ4X7t3zT087 is Curve)
		{
			Curve[] array = (((Curve)_0023_003DzTZ4X7t3zT087).Clone() as Curve).Decompose();
			if (_0023_003Dz1tVbeNw_003D >= 0 && _0023_003Dz1tVbeNw_003D < array.Length)
			{
				_0023_003DzEZ_0024X0WU_003D = array[_0023_003Dz1tVbeNw_003D];
			}
		}
		double _0023_003DzF7v9r2A_003D;
		double _0023_003Dz8dK2uhU_003D;
		Segment3D segment3D = _0023_003DzYziBQElzuNCA(_0023_003DzEZ_0024X0WU_003D, _0023_003Dzrgqz890sj_0024X9, _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D.Plane, out _0023_003DzF7v9r2A_003D, out _0023_003Dz8dK2uhU_003D);
		_0023_003DzGcl_0024E9o_003D.StartPoint.SetPosition(segment3D.PointAt(_0023_003DzF7v9r2A_003D));
		_0023_003DzGcl_0024E9o_003D.EndPoint.SetPosition(segment3D.PointAt(_0023_003Dz8dK2uhU_003D));
	}

	private static void _0023_003Dzba1siSYYSPKs(ICurve _0023_003DzTZ4X7t3zT087, SketchCurve _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D)
	{
		Line line = (Line)_0023_003DzTZ4X7t3zT087;
		SketchLine sketchLine = (SketchLine)_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D;
		sketchLine.StartPoint.SetPosition(line.StartPoint);
		sketchLine.EndPoint.SetPosition(line.EndPoint);
		Constraint[] constraints = sketchLine.StartPoint.Constraints;
		foreach (Constraint constraint in constraints)
		{
			if (constraint is PointFixedConstraint)
			{
				((PointFixedConstraint)constraint).UpdateCoordinate(sketchLine.StartPoint.PlanePosition.X, sketchLine.StartPoint.PlanePosition.Y);
			}
		}
		constraints = sketchLine.EndPoint.Constraints;
		foreach (Constraint constraint2 in constraints)
		{
			if (constraint2 is PointFixedConstraint)
			{
				((PointFixedConstraint)constraint2).UpdateCoordinate(sketchLine.EndPoint.PlanePosition.X, sketchLine.EndPoint.PlanePosition.Y);
			}
		}
	}

	private static void _0023_003DzBXQthKzfV_lLRB_0024Sqg_003D_003D(SketchSpline _0023_003DznYbCLDUxnKSb, Curve _0023_003Dz_Gzfs9c_003D)
	{
		if (_0023_003Dz_Gzfs9c_003D.Degree == 1)
		{
			_0023_003Dz_Gzfs9c_003D.DegreeElevate(2);
		}
		else if (_0023_003Dz_Gzfs9c_003D.Degree == 2)
		{
			_0023_003Dz_Gzfs9c_003D.DegreeElevate(1);
		}
		for (int i = 0; i < _0023_003DznYbCLDUxnKSb.ControlPoints.Length; i++)
		{
			SketchPoint sketchPoint = _0023_003DznYbCLDUxnKSb.ControlPoints[i];
			sketchPoint.SetPosition(_0023_003Dz_Gzfs9c_003D.ControlPoints[i]);
			Constraint[] constraints = sketchPoint.Constraints;
			foreach (Constraint constraint in constraints)
			{
				if (constraint is PointFixedConstraint)
				{
					((PointFixedConstraint)constraint).UpdateCoordinate(sketchPoint.PlanePosition.X, sketchPoint.PlanePosition.Y);
				}
			}
		}
	}

	private Line _0023_003DzYjw5848AKzk_fswDRAZ_PfgBGOFY(ICurve _0023_003DzEZ_0024X0WU_003D, Plane _0023_003Dzrgqz890sj_0024X9)
	{
		double _0023_003DzF7v9r2A_003D;
		double _0023_003Dz8dK2uhU_003D;
		Segment3D segment3D = _0023_003DzYziBQElzuNCA(_0023_003DzEZ_0024X0WU_003D, _0023_003Dzrgqz890sj_0024X9, Plane, out _0023_003DzF7v9r2A_003D, out _0023_003Dz8dK2uhU_003D);
		return new Line(segment3D.PointAt(_0023_003DzF7v9r2A_003D), segment3D.PointAt(_0023_003Dz8dK2uhU_003D));
	}

	private static Segment3D _0023_003DzYziBQElzuNCA(ICurve _0023_003DzEZ_0024X0WU_003D, Plane _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D, Plane _0023_003DzJ7Ot5RuMhdMpo_6azw_003D_003D, out double _0023_003DzF7v9r2A_003D, out double _0023_003Dz8dK2uhU_003D)
	{
		Segment3D intSeg = null;
		Plane.Intersection(_0023_003DzJ7Ot5RuMhdMpo_6azw_003D_003D, _0023_003DzWxLrrBpoUGDZmUkWVA_003D_003D, Utility._0023_003DzheSR8QM7q9ya, out intSeg);
		Vector3D dUnit = new Vector3D(intSeg.P0, intSeg.P1);
		_0023_003DzspExml1j72mr_FI04NKW780_003D _0023_003DzspExml1j72mr_FI04NKW780_003D2 = new _0023_003DzspExml1j72mr_FI04NKW780_003D();
		Curve nurbsForm;
		try
		{
			nurbsForm = _0023_003DzEZ_0024X0WU_003D.GetNurbsForm();
		}
		finally
		{
			((IDisposable)_0023_003DzspExml1j72mr_FI04NKW780_003D2).Dispose();
		}
		int num = nurbsForm.Degree + 3;
		double num2 = nurbsForm.Domain.Length / (double)num;
		List<double> list = new List<double>();
		list.Add(nurbsForm.Domain.Low);
		list.Add(nurbsForm.Domain.High);
		for (int i = 0; i < num + 1; i++)
		{
			double u = nurbsForm.Domain.Low + (double)i * num2;
			if (Utility.AngleMinimizer(nurbsForm, dUnit, 10, 1E-09, ref u))
			{
				list.Add(u);
			}
		}
		_0023_003DzF7v9r2A_003D = double.MaxValue;
		_0023_003Dz8dK2uhU_003D = double.MinValue;
		foreach (double item in list)
		{
			Point3D pt = nurbsForm.PointAt(item);
			double num3 = intSeg.Project(pt);
			if (num3 < _0023_003DzF7v9r2A_003D)
			{
				_0023_003DzF7v9r2A_003D = num3;
			}
			if (num3 > _0023_003Dz8dK2uhU_003D)
			{
				_0023_003Dz8dK2uhU_003D = num3;
			}
		}
		return intSeg;
	}

	private void _0023_003DzJY2NMdI_003D(ICurve _0023_003DzXFCaxBPL9SSm, bool _0023_003DzH0kpLC0_003D)
	{
		_0023_003DzgJYQYDOTBsxX(_0023_003DzXFCaxBPL9SSm, _0023_003DzH0kpLC0_003D, _0023_003DzBEvOagU_003D: false);
	}

	public void AddLine(Line line)
	{
		_0023_003DzZEJDfL4_003D(Sketch.AddLine(Plane.Project(line.StartPoint), Plane.Project(line.EndPoint)), line);
	}

	public void AddCircle(Circle circle)
	{
		_0023_003DzZEJDfL4_003D(Sketch.AddCircle(Plane.Project(circle.Center), circle.Radius, diamConstraint: false), circle);
	}

	public Circle AddCircle(Point2D center, double radius)
	{
		Circle circle = new Circle(Plane, center, radius);
		AddCircle(circle);
		return circle;
	}

	public Circle AddCircle(Point2D center, Point2D pointOnCircle)
	{
		return AddCircle(center, center.DistanceTo(pointOnCircle));
	}

	public Arc AddArc(Point2D centerPoint, Point2D startPoint, Point2D endPoint)
	{
		Arc arc = new Arc(Sketch.SketchPlane, centerPoint ?? Point2D.MidPoint(startPoint, endPoint), startPoint, endPoint);
		AddArc(arc);
		return arc;
	}

	public void TranslateCurves(double x, double y)
	{
		TranslateCurves(CurveList, x, y);
	}

	public void TranslateCurves(IList<ICurve> curves, double x, double y)
	{
		SketchCurve[] array = curves.Cast<Entity>().Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzl3tfq72rLtxSewKLcgJbIWhjR2z4).Cast<SketchCurve>()
			.ToArray();
		SketchCurve[] array2 = array;
		foreach (SketchCurve _0023_003Dz8fpRyMu9aKjE in array2)
		{
			_0023_003DzfkoXsQVhNX4K(_0023_003Dz8fpRyMu9aKjE, _0023_003DzWSPv6zs_003D: false, Sketch.unsupportedTranslateConstraints);
		}
		Sketch.Translate(array, x, y);
	}

	public void RotateCurves(Point2D center, double angle)
	{
		RotateCurves(CurveList, center, angle);
	}

	public void RotateCurves(IList<ICurve> curves, Point2D center, double angle)
	{
		SketchCurve[] array = curves.Cast<Entity>().Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzgKgURY41xRKG684HUuNC0CiyWXng).Cast<SketchCurve>()
			.ToArray();
		SketchCurve[] array2 = array;
		foreach (SketchCurve _0023_003Dz8fpRyMu9aKjE in array2)
		{
			_0023_003DzfkoXsQVhNX4K(_0023_003Dz8fpRyMu9aKjE, _0023_003DzWSPv6zs_003D: true, Sketch.supportedRotateConstraints);
		}
		Sketch.Rotate(array, center, angle);
	}

	public void ScaleCurves(Point2D fixedPoint, double factorX, double factorY)
	{
		ScaleCurves(CurveList, fixedPoint, factorX, factorY);
	}

	public void ScaleCurves(IList<ICurve> curves, Point2D fixedPoint, double factorX, double factorY)
	{
		SketchCurve[] array = curves.Cast<Entity>().Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzOhrpq00UABwzQUP06KvnSEk8MHV4).Cast<SketchCurve>()
			.ToArray();
		SketchCurve[] array2 = array;
		foreach (SketchCurve _0023_003Dz8fpRyMu9aKjE in array2)
		{
			_0023_003DzfkoXsQVhNX4K(_0023_003Dz8fpRyMu9aKjE, _0023_003DzWSPv6zs_003D: true, Sketch.supportedScaleConstraints);
		}
		Sketch.Scale(array, fixedPoint, factorX, factorY);
	}

	public void MirrorCurves(Plane plane = null)
	{
		MirrorCurves(CurveList, plane);
	}

	public void MirrorCurves(IList<ICurve> curves, Plane plane = null)
	{
		SketchCurve[] array = curves.Cast<Entity>().Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzyvgFrPJfYAd09h6x96mJIOLHnNub).Cast<SketchCurve>()
			.ToArray();
		SketchCurve[] array2 = array;
		foreach (SketchCurve _0023_003Dz8fpRyMu9aKjE in array2)
		{
			_0023_003DzfkoXsQVhNX4K(_0023_003Dz8fpRyMu9aKjE, _0023_003DzWSPv6zs_003D: false, Sketch.unsupportedMirrorConstraints);
		}
		Sketch.Mirror(array, plane);
		Constraint[] array3 = _0023_003Dz1cTWX1fK2A6e();
		foreach (Constraint constraint in array3)
		{
			if (constraint._0023_003DzzRLCjkBKJt17().ConstraintDimension != null)
			{
				constraint._0023_003DzzRLCjkBKJt17().ConstraintDimension.DimLinePosition.TransformBy(new Mirror(Plane.YZ));
			}
		}
	}

	private void _0023_003DzfkoXsQVhNX4K(SketchCurve _0023_003Dz8fpRyMu9aKjE, bool _0023_003DzWSPv6zs_003D, Type[] _0023_003DzTLd6lkE_003D)
	{
		_0023_003DzfkoXsQVhNX4K(_0023_003Dz8fpRyMu9aKjE.Constraints, _0023_003DzWSPv6zs_003D, _0023_003DzTLd6lkE_003D);
		if (_0023_003Dz8fpRyMu9aKjE is SketchPoint)
		{
			return;
		}
		foreach (SketchPoint vertex in _0023_003Dz8fpRyMu9aKjE.Vertices)
		{
			_0023_003DzfkoXsQVhNX4K(vertex.Constraints, _0023_003DzWSPv6zs_003D, _0023_003DzTLd6lkE_003D);
		}
	}

	private void _0023_003DzfkoXsQVhNX4K(IEnumerable<Constraint> _0023_003DzheZZscU_003D, bool _0023_003DzWSPv6zs_003D, Type[] _0023_003DzTLd6lkE_003D)
	{
		using IEnumerator<Constraint> enumerator = _0023_003DzheZZscU_003D.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_0023_003DzLh_iSt489MQDyk7Wbg2PsZo_003D _0023_003DzLh_iSt489MQDyk7Wbg2PsZo_003D2 = new _0023_003DzLh_iSt489MQDyk7Wbg2PsZo_003D();
			_0023_003DzLh_iSt489MQDyk7Wbg2PsZo_003D2._0023_003Dz9EdxXqI_003D = enumerator.Current;
			if (_0023_003DzWSPv6zs_003D != _0023_003DzTLd6lkE_003D.Any(_0023_003DzLh_iSt489MQDyk7Wbg2PsZo_003D2._0023_003DzXE2ScOI8Rumrq31Xjw_003D_003D))
			{
				DeleteConstraint(_0023_003DzLh_iSt489MQDyk7Wbg2PsZo_003D2._0023_003Dz9EdxXqI_003D._0023_003DzzRLCjkBKJt17());
			}
		}
	}

	public List<Entity> PreparesEntitiesForMirror(List<Entity> selectedEntities)
	{
		List<Entity> list = new List<Entity>();
		foreach (Entity selectedEntity in selectedEntities)
		{
			if (selectedEntity is Point point)
			{
				if (point._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() is SketchPoint sketchPoint)
				{
					if (sketchPoint.ParentCurve == null)
					{
						Constraint[] constraints = sketchPoint.Constraints;
						if (constraints == null || constraints.Count() <= 0 || !(sketchPoint.Constraints.ToList()[0] is PointOnConstraint))
						{
							list.Add(selectedEntity);
						}
					}
				}
				else
				{
					list.Add(selectedEntity);
				}
			}
			else
			{
				list.Add(selectedEntity);
			}
		}
		return list.Distinct().ToList();
	}

	private void _0023_003DzgWs_ED4iKr_o(KeyValuePair<Constraint, int[]> _0023_003Dzul15pKzowtxl, EntityList.DataForCopyAndPaste _0023_003DzT7FKw5k_003D, Entity[] _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D)
	{
		Constraint key = _0023_003Dzul15pKzowtxl.Key;
		int[] value = _0023_003Dzul15pKzowtxl.Value;
		if (!(key is PolygonConstraint))
		{
			if (!(key is MidPointConstraint))
			{
				if (!(key is ConcentricCirclesDistanceConstraint concentricCirclesDistanceConstraint))
				{
					if (!(key is CollinearConstraint))
					{
						if (!(key is CollinearPointsConstraint))
						{
							if (!(key is PointAtConstraint pointAtConstraint))
							{
								if (!(key is TangentConstraint))
								{
									if (!(key is PerpendicularConstraint))
									{
										if (!(key is ParallelConstraint))
										{
											if (!(key is PointOnConstraint))
											{
												if (!(key is AngleConstraint angleConstraint))
												{
													if (!(key is CoincidentConstraint))
													{
														if (!(key is DiameterConstraint diameterConstraint))
														{
															if (!(key is RadiusConstraint radiusConstraint))
															{
																if (!(key is PointFixedConstraint))
																{
																	if (!(key is LengthConstraint lengthConstraint))
																	{
																		if (!(key is LinesDistanceConstraint linesDistanceConstraint))
																		{
																			if (!(key is PointLineDistanceConstraint pointLineDistanceConstraint))
																			{
																				if (!(key is HorizontalPointsDistanceConstraint horizontalPointsDistanceConstraint))
																				{
																					if (!(key is VerticalPointsDistanceConstraint verticalPointsDistanceConstraint))
																					{
																						if (!(key is PointsDistanceConstraint pointsDistanceConstraint))
																						{
																							if (!(key is EqualConstraint equalConstraint))
																							{
																								if (!(key is HVConstraint hVConstraint))
																								{
																									if (key is MirrorConstraint)
																									{
																										AddConstraintMirror(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]], _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]], _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[2]] as Line);
																									}
																								}
																								else if (hVConstraint.IsHorizontal)
																								{
																									if (value.Length == 1)
																									{
																										AddConstraintHorizontal(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Line);
																									}
																									else if (value.Length == 2)
																									{
																										AddConstraintHorizontal(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Point, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]] as Point);
																									}
																								}
																								else if (value.Length == 1)
																								{
																									AddConstraintVertical(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Line);
																								}
																								else if (value.Length == 2)
																								{
																									AddConstraintVertical(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Point, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]] as Point);
																								}
																							}
																							else
																							{
																								AddConstraintEqual(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]], _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]], !equalConstraint.IsEqualLength());
																							}
																						}
																						else
																						{
																							AddConstraintAlignedPointsDistance(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Point, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]] as Point, pointsDistanceConstraint.GetValue(), pointsDistanceConstraint.Reference);
																						}
																					}
																					else
																					{
																						AddConstraintVerticalPointsDistance(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Point, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]] as Point, verticalPointsDistanceConstraint.GetValue(), verticalPointsDistanceConstraint.Reference);
																					}
																				}
																				else
																				{
																					AddConstraintHorizontalPointsDistance(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Point, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]] as Point, horizontalPointsDistanceConstraint.GetValue(), horizontalPointsDistanceConstraint.Reference);
																				}
																			}
																			else
																			{
																				AddConstraintPointLineDistance(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Point, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]] as Line, pointLineDistanceConstraint.GetValue(), pointLineDistanceConstraint.Reference);
																			}
																		}
																		else
																		{
																			AddConstraintLinesDistance(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Line, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]] as Line, linesDistanceConstraint.GetValue(), linesDistanceConstraint.Reference);
																		}
																	}
																	else
																	{
																		AddConstraintLength(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Line, lengthConstraint.GetValue(), lengthConstraint.Reference);
																	}
																}
																else
																{
																	AddConstraintPointFixed(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Point);
																}
															}
															else
															{
																AddConstraintDiameter(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Arc, radiusConstraint.GetValue(), radiusConstraint.Reference);
															}
														}
														else
														{
															AddConstraintDiameter(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Circle, -1.0, diameterConstraint.Reference);
														}
													}
													else
													{
														AddConstraintJoin(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Point, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]]);
													}
												}
												else if (value.Length == 1)
												{
													AddConstraintAngle(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Arc, angleConstraint.GetValue(), angleConstraint.Reference);
												}
												else
												{
													AddConstraintAngle(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Line, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]] as Line, Plane.Project(angleConstraint.DimPos), angleConstraint.GetValue(), angleConstraint.Reference);
												}
											}
											else
											{
												AddConstraintPointOn(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Point, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]]);
											}
										}
										else
										{
											AddConstraintParallelLines(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Line, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]] as Line);
										}
									}
									else
									{
										AddConstraintPerpendicular(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Line, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]] as Line);
									}
								}
								else
								{
									AddConstraintTangent(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]], _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]]);
								}
							}
							else
							{
								AddConstraintPointAt(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Point, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]], pointAtConstraint.GetValue());
							}
						}
						else
						{
							AddConstraintCollinearPoints(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Point, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]] as Point, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[2]] as Point);
						}
					}
					else
					{
						AddConstraintCollinear(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Line, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]] as Line);
					}
				}
				else
				{
					AddConstraintConcentricDistance(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Circle, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]] as Circle, concentricCirclesDistanceConstraint.Reference);
				}
			}
			else
			{
				AddConstraintMidPoint(_0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[0]] as Point, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[value[1]]);
			}
		}
		else
		{
			Line[] array = new Line[value.Length];
			for (int i = 0; i < value.Length; i++)
			{
				int num = value[i];
				array[i] = _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D[num] as Line;
			}
			AddConstraintPolygon(array);
		}
	}

	public void AddEntity(Entity ent)
	{
		if (ent is Line line)
		{
			AddLine(line);
		}
		else if (ent is Point point)
		{
			AddPoint(point);
		}
		else if (ent is Arc arc)
		{
			AddArc(arc);
		}
		else if (ent is Circle circle)
		{
			AddCircle(circle);
		}
		else if (ent is Curve curve)
		{
			AddSketchSplineFromCurveEntity(curve);
		}
		else if (ent is Ellipse ellipse)
		{
			AddEllipse(ellipse);
		}
	}

	internal Point _0023_003Dz8ilmF8wT2E63PguzhA_003D_003D(SketchPoint _0023_003Dz0GFBMIk_003D)
	{
		Point point = new Point(Plane.PointAt(_0023_003Dz0GFBMIk_003D.PlanePosition));
		_0023_003DzZEJDfL4_003D(_0023_003Dz0GFBMIk_003D, point);
		return point;
	}

	public void AddPoint(Point point)
	{
		SketchPoint _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D = Sketch.AddPoint3D(point.Position);
		_0023_003DzZEJDfL4_003D(_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D, point);
	}

	public Point[] AddEllipticalArc(EllipticalArc ellipticalArc)
	{
		Vector2D axisX = Plane.Project(ellipticalArc.Plane.AxisX);
		Vector2D axisY = Plane.Project(ellipticalArc.Plane.AxisY);
		SketchEllipticalArc _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D = Sketch.AddEllipticalArc(Plane.Project(ellipticalArc.Center), Plane.Project(ellipticalArc.StartPoint), Plane.Project(ellipticalArc.EndPoint), ellipticalArc.RadiusX, ellipticalArc.RadiusY, axisX, axisY);
		_0023_003DzZEJDfL4_003D(_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D, ellipticalArc);
		Ellipse ellipse = new Ellipse(ellipticalArc.Plane, ellipticalArc.RadiusX, ellipticalArc.RadiusY);
		List<Point> list = new List<Point>();
		for (double num = 0.0; num < 1.0; num += 0.25)
		{
			Point point = new Point(ellipticalArc.PointAt(num * ellipse.Domain.Length));
			AddPoint(point);
			list.Add(point);
			AddConstraintPointAt(point, ellipticalArc, num);
		}
		return list.ToArray();
	}

	public void AddArc(Arc arc)
	{
		SketchArc _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D = Sketch.AddArc(Plane.Project(arc.Center), Plane.Project(arc.StartPoint), Plane.Project(arc.EndPoint));
		_0023_003DzZEJDfL4_003D(_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D, arc);
	}

	public Entity[] AddSlot(double x, double y, double length, double radius, double angle = 0.0)
	{
		SketchCurve[] array = Sketch.AddSlot(x, y, length, radius, angle, dimConstraint: false);
		SketchCurve[] array2 = array;
		foreach (SketchCurve sketchCurve in array2)
		{
			if (sketchCurve is SketchArc sketchArc)
			{
				Arc _0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D = new Arc(Plane, sketchArc.Center.PlanePosition, sketchArc.StartPoint.PlanePosition, sketchArc.EndPoint.PlanePosition);
				_0023_003DzZEJDfL4_003D(sketchArc, _0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D);
				continue;
			}
			if (sketchCurve is SketchLine sketchLine)
			{
				Line _0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D2 = new Line(Plane, sketchLine.StartPoint.PlanePosition, sketchLine.EndPoint.PlanePosition);
				_0023_003DzZEJDfL4_003D(sketchLine, _0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D2);
				continue;
			}
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977013));
		}
		_0023_003DzbiZkb0WIYpL_0024(array);
		return array.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzLJ34s8luf2eejQQaGn7ywwo_003D).ToArray();
	}

	public Entity[] AddRectangle(double x, double y, double width, double height, double angle = 0.0, bool lengthConstraints = true)
	{
		SketchCurve[] array = Sketch.AddRectangle(x, y, width, height, angle, construction: false, lengthConstraints);
		SketchCurve[] array2 = array;
		array = array2;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] is SketchLine sketchLine)
			{
				Line _0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D = new Line(Plane, sketchLine.StartPoint.PlanePosition, sketchLine.EndPoint.PlanePosition);
				_0023_003DzZEJDfL4_003D(sketchLine, _0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D);
			}
		}
		_0023_003DzbiZkb0WIYpL_0024(array2);
		return array2.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzLJ9TUrE_DKPn6b7DPKujDrg_003D).ToArray();
	}

	public Arc[] AddCircularSlot(double x, double y, double startAngle, double deltaAngle, double radius, double slotRadius)
	{
		SketchArc[] array = Sketch.AddCircularSlot(x, y, startAngle, deltaAngle, radius, slotRadius, dimConstraint: false);
		SketchArc[] array2 = array;
		foreach (SketchArc sketchArc in array2)
		{
			Arc _0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D = new Arc(Plane, sketchArc.Center.PlanePosition, sketchArc.StartPoint.PlanePosition, sketchArc.EndPoint.PlanePosition);
			_0023_003DzZEJDfL4_003D(sketchArc, _0023_003Dzs_s7NEXDP5h495S7Lg_003D_003D);
		}
		_0023_003DzbiZkb0WIYpL_0024(array);
		return array.Select((SketchArc _0023_003DzbfrNXYE_003D) => (Arc)_0023_003DzbfrNXYE_003D._0023_003DzZ_ilKakl9sw5()).ToArray();
	}

	public void AddChamfer(ICurve c1, ICurve c2, bool flip1, bool flip2, double distance)
	{
		Point3D[] array = Utility.Intersection(c1, c2);
		if (array.Length < 1)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976992));
		}
		SketchCurve sketchCurve = (SketchCurve)((Entity)c1)._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
		SketchCurve sketchCurve2 = (SketchCurve)((Entity)c2)._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
		if (sketchCurve != null && sketchCurve2 != null)
		{
			Curve._0023_003DzIiP18cNbYFuU(c1, c2, null, distance, flip1, flip2, c1 is Arc || c1 is Line, c2 is Arc || c2 is Line, out var _0023_003DzTcFGbxcG1Gf, out var _0023_003DzxarKE0_b7mfP, out var _0023_003DzJzDd5JWc4Zih);
			if (_0023_003DzTcFGbxcG1Gf == null || _0023_003DzxarKE0_b7mfP || _0023_003DzJzDd5JWc4Zih)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976929));
			}
			_0023_003DzIdFV8s5xYAWe(c1);
			_0023_003DzIdFV8s5xYAWe(c2);
			AddLine(_0023_003DzTcFGbxcG1Gf);
			SketchLine _0023_003Dz8RNfPckTKvIfPC6sgA_003D_003D = _0023_003DzTcFGbxcG1Gf._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchLine;
			c1.ClosestPointTo(_0023_003DzTcFGbxcG1Gf.StartPoint, out var t);
			c2.ClosestPointTo(_0023_003DzTcFGbxcG1Gf.StartPoint, out var t2);
			bool flag = c1.PointAt(t).DistanceTo(_0023_003DzTcFGbxcG1Gf.StartPoint) < c2.PointAt(t2).DistanceTo(_0023_003DzTcFGbxcG1Gf.StartPoint);
			_0023_003Dz_0024lRrOKWExPzHxMMV0w_003D_003D(c1, sketchCurve, _0023_003DzTcFGbxcG1Gf, _0023_003Dz8RNfPckTKvIfPC6sgA_003D_003D, flag);
			_0023_003Dz_0024lRrOKWExPzHxMMV0w_003D_003D(c2, sketchCurve2, _0023_003DzTcFGbxcG1Gf, _0023_003Dz8RNfPckTKvIfPC6sgA_003D_003D, !flag);
			Point point = AddPoint(array[0]);
			AddConstraintAlignedPointsDistance(point, StartPoint(_0023_003DzTcFGbxcG1Gf));
			AddConstraintAlignedPointsDistance(point, EndPoint(_0023_003DzTcFGbxcG1Gf));
			AddConstraintPointOn(point, c1 as Entity);
			AddConstraintPointOn(point, c2 as Entity);
		}
	}

	private void _0023_003Dz_0024lRrOKWExPzHxMMV0w_003D_003D(ICurve _0023_003Dz8fpRyMu9aKjE, SketchCurve _0023_003DzsSdtyzVHYnLx, Line _0023_003DzTcFGbxcG1Gf9, SketchLine _0023_003Dz8RNfPckTKvIfPC6sgA_003D_003D, bool _0023_003Dz9_Y8GIYNrY3H)
	{
		(Point3D, SketchPoint) tuple = (_0023_003Dz9_Y8GIYNrY3H ? (_0023_003DzTcFGbxcG1Gf9.StartPoint, _0023_003Dz8RNfPckTKvIfPC6sgA_003D_003D.StartPoint) : (_0023_003DzTcFGbxcG1Gf9.EndPoint, _0023_003Dz8RNfPckTKvIfPC6sgA_003D_003D.EndPoint));
		if (_0023_003DzsSdtyzVHYnLx is ISketchCurve sketchCurve)
		{
			SketchPoint sketchPoint = ((_0023_003Dz8fpRyMu9aKjE.StartPoint.DistanceTo(tuple.Item1) < _0023_003Dz8fpRyMu9aKjE.EndPoint.DistanceTo(tuple.Item1)) ? sketchCurve.StartPoint : sketchCurve.EndPoint);
			_0023_003Dz1gNRaniInhY7(sketchPoint);
			_0023_003DzxtNOJHADFGkK(sketchPoint);
			_0023_003Dz9_0024HudZfEoQzz(sketchPoint, tuple.Item2);
		}
		else
		{
			_0023_003Dz9_0024HudZfEoQzz(tuple.Item2, _0023_003DzsSdtyzVHYnLx);
		}
	}

	public Arc AddFillet(ICurve c1, ICurve c2, bool flip1, bool flip2, double radius)
	{
		if (Utility.Intersection(c1, c2).Length < 1)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976992));
		}
		SketchCurve sketchCurve = (SketchCurve)((Entity)c1)._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
		SketchCurve sketchCurve2 = (SketchCurve)((Entity)c2)._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
		if (sketchCurve == null || sketchCurve2 == null)
		{
			return null;
		}
		Curve._0023_003DzPBKz88Xf9aEE(c1, c2, null, radius, flip1, flip2, c1 is Arc || c1 is Line, c2 is Arc || c2 is Line, out var _0023_003Dzxt7paKBusKOo, out var _0023_003DzxarKE0_b7mfP, out var _0023_003DzJzDd5JWc4Zih);
		if (_0023_003Dzxt7paKBusKOo == null || _0023_003DzxarKE0_b7mfP || _0023_003DzJzDd5JWc4Zih)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976901));
		}
		_0023_003DzIdFV8s5xYAWe(c1);
		_0023_003DzIdFV8s5xYAWe(c2);
		if (Vector3D.AreOpposite(_0023_003Dzxt7paKBusKOo.Plane.AxisZ, Plane.AxisZ, 0.01))
		{
			_0023_003Dzxt7paKBusKOo = new Arc(Plane, Plane.Project(_0023_003Dzxt7paKBusKOo.Center), Plane.Project(_0023_003Dzxt7paKBusKOo.EndPoint), Plane.Project(_0023_003Dzxt7paKBusKOo.StartPoint));
		}
		AddArc(_0023_003Dzxt7paKBusKOo);
		SketchArc _0023_003Dz8gYAqew_0024tREajJCfYQ_003D_003D = _0023_003Dzxt7paKBusKOo._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchArc;
		c1.ClosestPointTo(_0023_003Dzxt7paKBusKOo.StartPoint, out var t);
		c2.ClosestPointTo(_0023_003Dzxt7paKBusKOo.StartPoint, out var t2);
		bool flag = c1.PointAt(t).DistanceTo(_0023_003Dzxt7paKBusKOo.StartPoint) < c2.PointAt(t2).DistanceTo(_0023_003Dzxt7paKBusKOo.StartPoint);
		_0023_003Dz_00249NebbN_0024oJDQ_noBeA_003D_003D(c1, sketchCurve, _0023_003Dzxt7paKBusKOo, _0023_003Dz8gYAqew_0024tREajJCfYQ_003D_003D, flag);
		_0023_003Dz_00249NebbN_0024oJDQ_noBeA_003D_003D(c2, sketchCurve2, _0023_003Dzxt7paKBusKOo, _0023_003Dz8gYAqew_0024tREajJCfYQ_003D_003D, !flag);
		AddConstraintTangent((Entity)c1, _0023_003Dzxt7paKBusKOo);
		AddConstraintTangent((Entity)c2, _0023_003Dzxt7paKBusKOo);
		return _0023_003Dzxt7paKBusKOo;
	}

	private void _0023_003DzIdFV8s5xYAWe(ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		ISketchCurve sketchCurve = (ISketchCurve)((Entity)_0023_003Dz8fpRyMu9aKjE)._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
		if (sketchCurve != null)
		{
			sketchCurve.StartPoint.Position = _0023_003Dz8fpRyMu9aKjE.StartPoint;
			sketchCurve.EndPoint.Position = _0023_003Dz8fpRyMu9aKjE.EndPoint;
		}
	}

	private void _0023_003Dz_00249NebbN_0024oJDQ_noBeA_003D_003D(ICurve _0023_003Dz8fpRyMu9aKjE, SketchCurve _0023_003DzsSdtyzVHYnLx, Arc _0023_003Dzxt7paKBusKOo, SketchArc _0023_003Dz8gYAqew_0024tREajJCfYQ_003D_003D, bool _0023_003Dz9_Y8GIYNrY3H)
	{
		(Point3D, SketchPoint) tuple = (_0023_003Dz9_Y8GIYNrY3H ? (_0023_003Dzxt7paKBusKOo.StartPoint, _0023_003Dz8gYAqew_0024tREajJCfYQ_003D_003D.StartPoint) : (_0023_003Dzxt7paKBusKOo.EndPoint, _0023_003Dz8gYAqew_0024tREajJCfYQ_003D_003D.EndPoint));
		if (_0023_003DzsSdtyzVHYnLx is ISketchCurve sketchCurve)
		{
			SketchPoint sketchPoint = ((_0023_003Dz8fpRyMu9aKjE.StartPoint.DistanceTo(tuple.Item1) < _0023_003Dz8fpRyMu9aKjE.EndPoint.DistanceTo(tuple.Item1)) ? sketchCurve.StartPoint : sketchCurve.EndPoint);
			_0023_003Dz1gNRaniInhY7(sketchPoint);
			_0023_003DzxtNOJHADFGkK(sketchPoint);
			_0023_003Dz9_0024HudZfEoQzz(sketchPoint, tuple.Item2);
		}
		else
		{
			_0023_003Dz9_0024HudZfEoQzz(tuple.Item2, _0023_003DzsSdtyzVHYnLx);
		}
	}

	private string _0023_003DzgtzUy7uwiWjc(VisualConstraint _0023_003Dz62fcvwqOsQ6b)
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976618), _0023_003Dz62fcvwqOsQ6b.GetType());
	}

	private void _0023_003DzbBuN7j7SY3kL(Arc _0023_003DzN4MDZ_0024c_003D, out Plane _0023_003Dzrgqz890sj_0024X9, out Point3D _0023_003DzO97ip_0024TQ_0024juS, out Point3D _0023_003DzM7o0gT3hjI42)
	{
		_0023_003Dzrgqz890sj_0024X9 = (Plane)_0023_003DzN4MDZ_0024c_003D.Plane.Clone();
		_0023_003DzO97ip_0024TQ_0024juS = _0023_003DzN4MDZ_0024c_003D.StartPoint;
		_0023_003DzM7o0gT3hjI42 = _0023_003DzN4MDZ_0024c_003D.EndPoint;
		if (Utility.IsOrientedClockwise(_0023_003DzN4MDZ_0024c_003D.Vertices))
		{
			_0023_003Dzrgqz890sj_0024X9.Flip();
			_0023_003DzO97ip_0024TQ_0024juS = _0023_003DzN4MDZ_0024c_003D.EndPoint;
			_0023_003DzM7o0gT3hjI42 = _0023_003DzN4MDZ_0024c_003D.StartPoint;
		}
	}

	private void _0023_003DzpgkCu6_h3HLE(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D, out Plane _0023_003Dzrgqz890sj_0024X9, out Point3D _0023_003DzO97ip_0024TQ_0024juS, out Point3D _0023_003DzM7o0gT3hjI42, pointsDistanceOrientationType _0023_003Dz6hQ2Ons_003D)
	{
		Vector3D vector3D = Plane.AxisX;
		if (_0023_003Dz6hQ2Ons_003D == pointsDistanceOrientationType.Vertical)
		{
			vector3D = Plane.AxisY;
		}
		LinearDim linearDim = new LinearDim(new Plane(_0023_003DzFj_0024IqDQ_003D, vector3D, Vector3D.Cross(Plane.AxisZ, vector3D)), _0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D, Point3D.MidPoint(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D) + _0023_003DzF51E6l8EH_0024Ri() * Vector3D.Cross(Plane.AxisZ, vector3D), _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
		_0023_003Dzrgqz890sj_0024X9 = linearDim.Plane;
		_0023_003DzO97ip_0024TQ_0024juS = linearDim.ExtLine1;
		_0023_003DzM7o0gT3hjI42 = linearDim.ExtLine2;
	}

	private void _0023_003DzpgkCu6_h3HLE(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D, out Plane _0023_003Dzrgqz890sj_0024X9, out Point3D _0023_003DzO97ip_0024TQ_0024juS, out Point3D _0023_003DzM7o0gT3hjI42)
	{
		Vector3D vector3D = new Vector3D(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D);
		Point3D p = _0023_003DzFj_0024IqDQ_003D;
		vector3D.Normalize();
		if (Utility._0023_003DzMJl6kdmQQxAU(Plane, new Line(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D)))
		{
			vector3D *= -1.0;
			p = _0023_003DzjdeMMkk_003D;
		}
		LinearDim linearDim = new LinearDim(new Plane(p, vector3D, Vector3D.Cross(Plane.AxisZ, vector3D)), _0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D, Point3D.MidPoint(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D) + _0023_003DzF51E6l8EH_0024Ri() * Vector3D.Cross(Plane.AxisZ, vector3D), _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
		_0023_003Dzrgqz890sj_0024X9 = linearDim.Plane;
		_0023_003DzO97ip_0024TQ_0024juS = linearDim.ExtLine1;
		_0023_003DzM7o0gT3hjI42 = linearDim.ExtLine2;
	}

	private void _0023_003DzpgkCu6_h3HLE(Line _0023_003DzNyidyKE_003D, Point3D _0023_003DzFj_0024IqDQ_003D, out Plane _0023_003Dzrgqz890sj_0024X9, out Point3D _0023_003DzO97ip_0024TQ_0024juS, out Point3D _0023_003DzM7o0gT3hjI42)
	{
		_0023_003DzNyidyKE_003D.Project(_0023_003DzFj_0024IqDQ_003D, out var t);
		Point3D _0023_003DzjdeMMkk_003D = _0023_003DzNyidyKE_003D.PointAt(t);
		_0023_003DzpgkCu6_h3HLE(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D, out _0023_003Dzrgqz890sj_0024X9, out _0023_003DzO97ip_0024TQ_0024juS, out _0023_003DzM7o0gT3hjI42);
	}

	private void _0023_003DzpgkCu6_h3HLE(Line _0023_003DzQvaHyao_003D, Line _0023_003DzNyidyKE_003D, out Plane _0023_003Dzrgqz890sj_0024X9, out Point3D _0023_003DzO97ip_0024TQ_0024juS, out Point3D _0023_003DzM7o0gT3hjI42)
	{
		_0023_003DzpgkCu6_h3HLE(_0023_003DzNyidyKE_003D, _0023_003DzQvaHyao_003D.StartPoint, out _0023_003Dzrgqz890sj_0024X9, out _0023_003DzO97ip_0024TQ_0024juS, out _0023_003DzM7o0gT3hjI42);
	}

	private void _0023_003DzpgkCu6_h3HLE(Circle _0023_003DzRag2n2bqVONr, Circle _0023_003DzBBIgXSa7SkoG, out Plane _0023_003Dzrgqz890sj_0024X9, out Point3D _0023_003DzO97ip_0024TQ_0024juS, out Point3D _0023_003DzM7o0gT3hjI42)
	{
		Point3D point3D = _0023_003DzRag2n2bqVONr.PointAt(_0023_003DzRag2n2bqVONr.Domain.Mid);
		_0023_003DzBBIgXSa7SkoG.Project(point3D, out var t);
		Point3D point3D2 = _0023_003DzBBIgXSa7SkoG.PointAt(t);
		Vector3D vector3D = new Vector3D(point3D, point3D2);
		vector3D.Normalize();
		LinearDim linearDim = new LinearDim(new Plane(point3D, vector3D, Vector3D.Cross(Plane.AxisZ, vector3D)), point3D, point3D2, Point3D.MidPoint(point3D, point3D2) + _0023_003DzF51E6l8EH_0024Ri() * Vector3D.Cross(Plane.AxisZ, vector3D), _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
		_0023_003Dzrgqz890sj_0024X9 = linearDim.Plane;
		_0023_003DzO97ip_0024TQ_0024juS = linearDim.ExtLine1;
		_0023_003DzM7o0gT3hjI42 = linearDim.ExtLine2;
	}

	public VisualConstraint GetConstraint(Entity dimension)
	{
		Constraint[] array = _0023_003Dz1cTWX1fK2A6e();
		foreach (Constraint constraint in array)
		{
			if (constraint._0023_003DzzRLCjkBKJt17().ConstraintDimension != null && dimension == constraint._0023_003DzzRLCjkBKJt17().ConstraintDimension)
			{
				return constraint._0023_003DzzRLCjkBKJt17();
			}
		}
		return null;
	}

	public Entity GetParentEntity(Point point)
	{
		SketchCurve sketchCurve = (SketchCurve)point._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
		if (sketchCurve.ParentCurve == null)
		{
			return null;
		}
		return sketchCurve.ParentCurve._0023_003DzZ_ilKakl9sw5();
	}

	public IEnumerable<Entity> GetConstrained(VisualConstraint visualConstraint)
	{
		return from _0023_003DzbfrNXYE_003D in visualConstraint.GConstraint.GetEntities()
			select _0023_003DzbfrNXYE_003D._0023_003DzZ_ilKakl9sw5();
	}

	public VisualConstraint[] GetConstraints(Entity entity)
	{
		return ((SketchCurve)entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Constraints.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz26SM_8U3UOUmRatvpAeixtI_003D).ToArray();
	}

	public void UpdateAndInvalidate(SketchItem dragTarget = null)
	{
		if (_0023_003DzGZrCMzl_0024iuSu(out var _0023_003DzOLHnb2M_003D, out var _0023_003Dz5PjoC_vVvm2Y, dragTarget))
		{
			_0023_003DzyluVCy0_003D(_0023_003Dz5PjoC_vVvm2Y);
			_design.Entities.Regen();
			if (!Dragging)
			{
				_design.UpdateBoundingBox();
			}
			_0023_003Dz1Epz1IigMnC6();
			_design.Invalidate();
			if (!Dragging && (Sketch.DOF != _prevDof || _0023_003DzOLHnb2M_003D == solveFailureType.Redundant))
			{
				StoreHistory();
				_prevDof = Sketch.DOF;
			}
			_0023_003Dz3etDJxTITZMUBmhHLQ_003D_003D(_0023_003DzOLHnb2M_003D);
		}
	}

	private void _0023_003Dz_0024_gAR8eQQB_00245()
	{
		if (!_showFilledRegion || !Editing || Dragging)
		{
			return;
		}
		Region[] array = ConvertToRegions();
		if (array != null && array.Length != 0)
		{
			sketchRegionsVertices = new List<Point3D[]>();
			sketchRegionsTriangles = new List<IndexTriangle[]>();
			Region[] array2 = array;
			foreach (Region region in array2)
			{
				if (region != null && region.IsValid())
				{
					if (_design.CurrentTransformation != null)
					{
						region.TransformBy(_design.CurrentTransformation);
					}
					Surface surface = region.ConvertToSurface();
					surface.Regen(_design.Document.GetVisualRefinement());
					sketchRegionsTriangles.Add(surface.Triangles);
					sketchRegionsVertices.Add(surface.Vertices);
				}
			}
			_isRegionReady = sketchRegionsVertices.Count > 0;
		}
		else
		{
			sketchRegionsVertices = null;
			sketchRegionsTriangles = null;
			_isRegionReady = false;
		}
	}

	private bool _0023_003DzGZrCMzl_0024iuSu(out solveFailureType _0023_003DzOLHnb2M_003D, out HashSet<SketchItem> _0023_003Dz5PjoC_vVvm2Y, SketchItem _0023_003Dz0U_Pa5U_003D)
	{
		if (!_0023_003Dz6Q_TJfE_003D(out _0023_003DzOLHnb2M_003D, out _0023_003Dz5PjoC_vVvm2Y, _0023_003Dz0U_Pa5U_003D))
		{
			return false;
		}
		_isRegionValid = _0023_003DzOLHnb2M_003D == solveFailureType.Success;
		return true;
	}

	public bool Solve()
	{
		solveFailureType result;
		return Solve(out result);
	}

	public bool Solve(out solveFailureType result)
	{
		if (_0023_003DzGZrCMzl_0024iuSu(out result, out var _, null))
		{
			return result != solveFailureType.DidntConverge;
		}
		return false;
	}

	private void _0023_003Dz1Epz1IigMnC6()
	{
		try
		{
			_0023_003Dz_0024_gAR8eQQB_00245();
		}
		catch (Exception)
		{
		}
	}

	private bool _0023_003Dz6Q_TJfE_003D(out solveFailureType _0023_003DzOLHnb2M_003D, out HashSet<SketchItem> _0023_003Dz5PjoC_vVvm2Y, SketchItem _0023_003Dz0U_Pa5U_003D)
	{
		_0023_003DzOLHnb2M_003D = solveFailureType.DidntConverge;
		_0023_003Dz5PjoC_vVvm2Y = null;
		try
		{
			_0023_003DzOLHnb2M_003D = Sketch._sketchInternal._0023_003DzOykoXtw_003D(out _0023_003Dz5PjoC_vVvm2Y, _0023_003Dz0U_Pa5U_003D);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private void _0023_003DzTug8OOpDtJ4E()
	{
		if (_history == null)
		{
			_history = new global::_0023_003DzAXZzi6Sjw7p1yr6lAy7LfDtbxQJyrEjYWCcrbfg_003D<Stream>(100);
			_history._0023_003Dz1elxSw0bxGeE(_0023_003DzOha4h6QfL83i);
		}
	}

	private void _0023_003DzOha4h6QfL83i(object _0023_003Dz9VjL5i0_003D, EventArgs _0023_003DzbfrNXYE_003D)
	{
		this.HistoryChanged?.Invoke(this, EventArgs.Empty);
	}

	public void ClearHistory()
	{
		_prevDof = -1;
		if (_history != null)
		{
			_history.Dispose();
			_history._0023_003DzCoTmD1rTdzdX(_0023_003DzOha4h6QfL83i);
			_history = null;
		}
	}

	public void StoreHistory()
	{
		_0023_003DzTug8OOpDtJ4E();
		_history._0023_003Dz3sZAfOM_003D(_historySerializer._0023_003DzotZ8WhHPfkb3UzUxtg_003D_003D(this));
	}

	private void _0023_003Dz6iOjgQrgsK4k(Stream _0023_003DzGmHH8u4_003D)
	{
		if (_0023_003DzGmHH8u4_003D != null && _0023_003DzGmHH8u4_003D.Length != 0L)
		{
			_0023_003DzTug8OOpDtJ4E();
			_0023_003Dzj_00248p_0024dlMP0ic();
			SketchEntity sketchEntity = _historySerializer._0023_003DzIoWZ54SLqVMfg3dU_Q_003D_003D(_0023_003DzGmHH8u4_003D);
			Sketch = sketchEntity.Sketch;
			_curveList = sketchEntity.CurveList;
			_design.Entities.AddRange(_curveList.Cast<Entity>());
			Constraint[] constraints = Sketch.Constraints;
			foreach (Constraint _0023_003Dz9EdxXqI_003D in constraints)
			{
				_0023_003DzIrs5MDJ5nmrc(_0023_003Dz9EdxXqI_003D, _design.Entities);
			}
		}
	}

	private void _0023_003Dzj_00248p_0024dlMP0ic()
	{
		foreach (VisualConstraint constraint in Constraints)
		{
			constraint.Destroy();
		}
		Sketch.Clear();
		_design.Entities.RemoveRange(_startEntitiesIndex, _design.Entities.Count - _startEntitiesIndex);
	}

	public void Undo()
	{
		if (UndoReady)
		{
			_0023_003DzTug8OOpDtJ4E();
			_history._0023_003DzTtbN5fw_003D();
			_0023_003DzGuk7BFb_0024qrNX();
			if (_pasteCounter >= 0)
			{
				_pasteCounter--;
			}
		}
	}

	public void Redo()
	{
		if (!RedoReady)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976575));
		}
		_0023_003DzTug8OOpDtJ4E();
		_history._0023_003Dzn_KQLEk_003D();
		_0023_003DzGuk7BFb_0024qrNX();
	}

	private void _0023_003DzGuk7BFb_0024qrNX()
	{
		_0023_003Dz6iOjgQrgsK4k(_history._0023_003DzfOWbgto_003D());
		_0023_003Dz1Epz1IigMnC6();
		_0023_003DzGpBouKT_0024wCmV(_design.CurrentTransformation, null);
		_design.Entities.Regen();
		_prevDof = Sketch.DOF;
		_design.Invalidate();
	}

	public void ResetRedoCount()
	{
		_history?._0023_003DzdkbFwbBUIGfc();
	}

	private void _0023_003DzyluVCy0_003D(HashSet<SketchItem> _0023_003Dz5PjoC_vVvm2Y)
	{
		foreach (SketchCurve curve in Sketch.CurveList)
		{
			if (_0023_003Dz5PjoC_vVvm2Y == null || _0023_003Dz5PjoC_vVvm2Y.Contains(curve))
			{
				curve._0023_003DzjdvuhXvcm_002426();
				curve._0023_003DzZ_ilKakl9sw5().RegenMode = regenType.RegenAndCompile;
			}
		}
		_0023_003DzGpBouKT_0024wCmV(_design.CurrentTransformation, _0023_003Dz5PjoC_vVvm2Y);
		for (int i = _startEntitiesIndex + 1; i < _design.Entities.Count; i++)
		{
			Entity entity = _design.Entities[i];
			if (_0023_003Dz5PjoC_vVvm2Y == null || _0023_003Dz5PjoC_vVvm2Y.Contains(entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()))
			{
				entity.RegenMode = regenType.RegenAndCompile;
			}
		}
	}

	private void _0023_003DzGpBouKT_0024wCmV(Transformation _0023_003DzqKPG_jw1aarm, HashSet<SketchItem> _0023_003Dz5PjoC_vVvm2Y)
	{
		_0023_003Dzlnm1vysNiMTg(_0023_003DzqKPG_jw1aarm, _0023_003Dz5PjoC_vVvm2Y);
		Constraint[] array = _0023_003Dz1cTWX1fK2A6e();
		foreach (Constraint constraint in array)
		{
			if (_0023_003Dz5PjoC_vVvm2Y != null && !_0023_003Dz5PjoC_vVvm2Y.Contains(constraint))
			{
				continue;
			}
			VisualConstraint visualConstraint = constraint._0023_003DzzRLCjkBKJt17();
			SketchCurve[] array2 = visualConstraint._0023_003DzIFukBjkqga2dbdlCxA_003D_003D();
			Point3D _0023_003DzO97ip_0024TQ_0024juS3;
			if (visualConstraint is AngleVisualConstraint)
			{
				AngularDim angularDim = visualConstraint.ConstraintDimension as AngularDim;
				Plane plane = angularDim.Plane;
				if (array2[0] is SketchArc sketchArc)
				{
					Arc _0023_003DzN4MDZ_0024c_003D = (Arc)sketchArc._0023_003DzZ_ilKakl9sw5();
					_0023_003DzbBuN7j7SY3kL(_0023_003DzN4MDZ_0024c_003D, out var _0023_003Dzrgqz890sj_0024X, out var _0023_003DzO97ip_0024TQ_0024juS, out var _0023_003DzM7o0gT3hjI);
					angularDim.Plane = _0023_003Dzrgqz890sj_0024X;
					angularDim.ExtLine1 = _0023_003DzO97ip_0024TQ_0024juS;
					angularDim.ExtLine2 = _0023_003DzM7o0gT3hjI;
					angularDim.Height = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
					angularDim.ArrowheadSize = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
					angularDim.DimLinePosition.TransformBy(Transformation.CreateAlignment(plane, _0023_003Dzrgqz890sj_0024X));
					_0023_003Dz36TNao7oaYj6(angularDim, visualConstraint.GConstraint as ValueConstraint);
				}
				else if (array2[0] is SketchLine sketchLine && array2[1] is SketchLine sketchLine2)
				{
					Line line = (Line)sketchLine._0023_003DzZ_ilKakl9sw5();
					Line line2 = (Line)sketchLine2._0023_003DzZ_ilKakl9sw5();
					double num = (angularDim.StartAngle + angularDim.EndAngle) / 2.0;
					Point3D quadrantPoint = angularDim.Plane.PointAt(new Point2D(Math.Cos(num), Math.Sin(num)) * angularDim.Radius);
					AngularDim angularDim2 = new AngularDim(Plane, line, line2, quadrantPoint, angularDim.DimLinePosition, _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
					angularDim.Plane = angularDim2.Plane;
					angularDim.ExtLine1 = angularDim2.ExtLine1;
					angularDim.ExtLine2 = angularDim2.ExtLine2;
					angularDim.Height = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
					angularDim.ArrowheadSize = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
					angularDim.DimLinePosition.TransformBy(Transformation.CreateAlignment(plane, angularDim.Plane));
					_0023_003Dz36TNao7oaYj6(angularDim, visualConstraint.GConstraint as ValueConstraint);
				}
				else
				{
					if (!(array2[0] is SketchPoint sketchPoint) || !(array2[1] is SketchPoint sketchPoint2) || !(array2[2] is SketchPoint sketchPoint3))
					{
						throw new EyeshotException(_0023_003DzgtzUy7uwiWjc(visualConstraint));
					}
					AngularDim angularDim3 = new AngularDim(new Plane(sketchPoint2.Position, Plane.AxisX, Plane.AxisY), sketchPoint.Position, sketchPoint3.Position, angularDim.UnderlyingArc.MidPoint, _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
					angularDim.Plane = angularDim3.Plane;
					angularDim.ExtLine1 = angularDim3.ExtLine1;
					angularDim.ExtLine2 = angularDim3.ExtLine2;
					angularDim.Height = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
					angularDim.ArrowheadSize = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
					angularDim.DimLinePosition.TransformBy(Transformation.CreateAlignment(plane, angularDim.Plane));
					_0023_003Dz36TNao7oaYj6(angularDim, visualConstraint.GConstraint as ValueConstraint);
				}
			}
			else if (visualConstraint is DiameterVisualConstraint diameterVisualConstraint)
			{
				if (array2[0] is SketchArc sketchArc2)
				{
					Arc arc = (Arc)sketchArc2._0023_003DzZ_ilKakl9sw5();
					RadialDim radialDim = visualConstraint.ConstraintDimension as RadialDim;
					Plane plane2 = radialDim.Plane;
					int num2 = ((!(diameterVisualConstraint.GConstraint is DiameterConstraint)) ? 1 : 2);
					double sx = diameterVisualConstraint.Value / ((double)num2 * radialDim.Distance);
					radialDim.Plane = Plane.Clone() as Plane;
					radialDim.Plane.Origin = arc.Center;
					radialDim.Radius = arc.Radius;
					radialDim.Height = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
					radialDim.ArrowheadSize = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
					radialDim.DimLinePosition.TransformBy(Transformation.CreateAlignment(Plane.XY, radialDim.Plane) * Transformation.CreateRotation(radialDim.angle, Vector3D.AxisZ) * Transformation.CreateScaling(sx, 1.0) * Transformation.CreateRotation(0.0 - radialDim.angle, Vector3D.AxisZ) * Transformation.CreateAlignment(plane2, Plane.XY));
					_0023_003Dz36TNao7oaYj6(radialDim, visualConstraint.GConstraint as ValueConstraint);
					continue;
				}
				if (!(array2[0] is SketchCircle sketchCircle))
				{
					throw new EyeshotException(_0023_003DzgtzUy7uwiWjc(visualConstraint));
				}
				Circle circle = (Circle)sketchCircle._0023_003DzZ_ilKakl9sw5();
				DiametricDim diametricDim = visualConstraint.ConstraintDimension as DiametricDim;
				Plane plane3 = diametricDim.Plane;
				double num3 = ((diameterVisualConstraint.GConstraint is DiameterConstraint) ? 1.0 : 0.5);
				double sx2 = diameterVisualConstraint.Value / (num3 * diametricDim.Distance);
				diametricDim.Plane = Plane.Clone() as Plane;
				diametricDim.Plane.Origin = circle.Center;
				diametricDim.Radius = circle.Radius;
				diametricDim.Height = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
				diametricDim.ArrowheadSize = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
				diametricDim.DimLinePosition.TransformBy(Transformation.CreateAlignment(Plane.XY, diametricDim.Plane) * Transformation.CreateRotation(diametricDim.angle, Vector3D.AxisZ) * Transformation.CreateScaling(sx2, 1.0) * Transformation.CreateRotation(0.0 - diametricDim.angle, Vector3D.AxisZ) * Transformation.CreateAlignment(plane3, Plane.XY));
				_0023_003Dz36TNao7oaYj6(diametricDim, visualConstraint.GConstraint as ValueConstraint);
			}
			else if (visualConstraint is LengthVisualConstraint lengthVisualConstraint)
			{
				if (array2[0] is SketchLine sketchLine3)
				{
					LinearDim linearDim = visualConstraint.ConstraintDimension as LinearDim;
					Line line3 = (Line)sketchLine3._0023_003DzZ_ilKakl9sw5();
					Plane plane4 = linearDim.Plane;
					Utility._0023_003DzpgkCu6_h3HLE(Plane, line3, out var _0023_003Dzrgqz890sj_0024X2);
					double sx3 = lengthVisualConstraint.Value / linearDim.Distance;
					linearDim.Plane = _0023_003Dzrgqz890sj_0024X2;
					linearDim.ExtLine2 = line3.EndPoint;
					linearDim.Height = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
					linearDim.ArrowheadSize = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
					linearDim.DimLinePosition.TransformBy(Transformation.CreateAlignment(Plane.XY, _0023_003Dzrgqz890sj_0024X2) * Transformation.CreateScaling(sx3, 1.0) * Transformation.CreateAlignment(plane4, Plane.XY));
					_0023_003Dz36TNao7oaYj6(linearDim, visualConstraint.GConstraint as ValueConstraint);
					continue;
				}
				if (!(array2[0] is SketchArc sketchArc3))
				{
					throw new EyeshotException(_0023_003DzgtzUy7uwiWjc(visualConstraint));
				}
				Arc _0023_003DzN4MDZ_0024c_003D2 = (Arc)sketchArc3._0023_003DzZ_ilKakl9sw5();
				AngularDim angularDim4 = visualConstraint.ConstraintDimension as AngularDim;
				Plane plane5 = angularDim4.Plane;
				_0023_003DzbBuN7j7SY3kL(_0023_003DzN4MDZ_0024c_003D2, out var _0023_003Dzrgqz890sj_0024X3, out var _0023_003DzO97ip_0024TQ_0024juS2, out var _0023_003DzM7o0gT3hjI2);
				double sx4 = lengthVisualConstraint.Value / angularDim4.Distance;
				angularDim4.TextOverride = ((LengthConstraint)lengthVisualConstraint.GConstraint).GetValue().ToString();
				angularDim4.Plane = _0023_003Dzrgqz890sj_0024X3;
				angularDim4.ExtLine1 = _0023_003DzO97ip_0024TQ_0024juS2;
				angularDim4.ExtLine2 = _0023_003DzM7o0gT3hjI2;
				angularDim4.Height = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
				angularDim4.ArrowheadSize = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
				angularDim4.DimLinePosition.TransformBy(Transformation.CreateAlignment(Plane.XY, _0023_003Dzrgqz890sj_0024X3) * Transformation.CreateScaling(sx4, 1.0) * Transformation.CreateAlignment(plane5, Plane.XY));
				_0023_003Dz36TNao7oaYj6(angularDim4, visualConstraint.GConstraint as ValueConstraint);
			}
			else if (visualConstraint is LinesDistanceVisualConstraint linesDistanceVisualConstraint)
			{
				LinearDim linearDim2 = visualConstraint.ConstraintDimension as LinearDim;
				Plane plane6 = linearDim2.Plane;
				if (!(array2[0] is SketchLine sketchLine4) || !(array2[1] is SketchLine sketchLine5))
				{
					throw new EyeshotException(_0023_003DzgtzUy7uwiWjc(visualConstraint));
				}
				_0023_003DzpgkCu6_h3HLE((Line)sketchLine4._0023_003DzZ_ilKakl9sw5(), (Line)sketchLine5._0023_003DzZ_ilKakl9sw5(), out var _0023_003Dzrgqz890sj_0024X4, out _0023_003DzO97ip_0024TQ_0024juS3, out var _0023_003DzM7o0gT3hjI3);
				double sx5 = linesDistanceVisualConstraint.Value / linearDim2.Distance;
				linearDim2.Plane = _0023_003Dzrgqz890sj_0024X4;
				linearDim2.ExtLine2 = _0023_003DzM7o0gT3hjI3;
				linearDim2.Height = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
				linearDim2.ArrowheadSize = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
				linearDim2.DimLinePosition.TransformBy(Transformation.CreateAlignment(Plane.XY, _0023_003Dzrgqz890sj_0024X4) * Transformation.CreateScaling(sx5, 1.0) * Transformation.CreateAlignment(plane6, Plane.XY));
				_0023_003Dz36TNao7oaYj6(linearDim2, visualConstraint.GConstraint as ValueConstraint);
			}
			else if (visualConstraint is PointLineDistanceVisualConstraint pointLineDistanceVisualConstraint)
			{
				LinearDim linearDim3 = visualConstraint.ConstraintDimension as LinearDim;
				Plane plane7 = linearDim3.Plane;
				if (!(array2[0] is SketchPoint sketchPoint4) || !(array2[1] is SketchLine sketchLine6))
				{
					throw new EyeshotException(_0023_003DzgtzUy7uwiWjc(visualConstraint));
				}
				_0023_003DzpgkCu6_h3HLE((Line)sketchLine6._0023_003DzZ_ilKakl9sw5(), ((Point)sketchPoint4._0023_003DzZ_ilKakl9sw5()).Position, out var _0023_003Dzrgqz890sj_0024X5, out _0023_003DzO97ip_0024TQ_0024juS3, out var _0023_003DzM7o0gT3hjI4);
				double sx6 = pointLineDistanceVisualConstraint.Value / linearDim3.Distance;
				linearDim3.Plane = _0023_003Dzrgqz890sj_0024X5;
				linearDim3.ExtLine2 = _0023_003DzM7o0gT3hjI4;
				linearDim3.Height = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
				linearDim3.ArrowheadSize = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
				linearDim3.DimLinePosition.TransformBy(Transformation.CreateAlignment(Plane.XY, _0023_003Dzrgqz890sj_0024X5) * Transformation.CreateScaling(sx6, 1.0) * Transformation.CreateAlignment(plane7, Plane.XY));
				_0023_003Dz36TNao7oaYj6(linearDim3, visualConstraint.GConstraint as ValueConstraint);
			}
			else if (visualConstraint is PointsDistanceVisualConstraint pointsDistanceVisualConstraint)
			{
				LinearDim linearDim4 = visualConstraint.ConstraintDimension as LinearDim;
				Plane plane8 = linearDim4.Plane;
				if (!(array2[0] is SketchPoint sketchPoint5) || !(array2[1] is SketchPoint sketchPoint6))
				{
					throw new EyeshotException(_0023_003DzgtzUy7uwiWjc(visualConstraint));
				}
				Plane _0023_003Dzrgqz890sj_0024X6;
				Point3D _0023_003DzM7o0gT3hjI5;
				if (visualConstraint.GConstraint is HorizontalPointsDistanceConstraint)
				{
					_0023_003DzpgkCu6_h3HLE(((Point)sketchPoint5._0023_003DzZ_ilKakl9sw5()).Position, ((Point)sketchPoint6._0023_003DzZ_ilKakl9sw5()).Position, out _0023_003Dzrgqz890sj_0024X6, out _0023_003DzO97ip_0024TQ_0024juS3, out _0023_003DzM7o0gT3hjI5, pointsDistanceOrientationType.Horizontal);
				}
				else if (visualConstraint.GConstraint is VerticalPointsDistanceConstraint)
				{
					_0023_003DzpgkCu6_h3HLE(((Point)sketchPoint5._0023_003DzZ_ilKakl9sw5()).Position, ((Point)sketchPoint6._0023_003DzZ_ilKakl9sw5()).Position, out _0023_003Dzrgqz890sj_0024X6, out _0023_003DzO97ip_0024TQ_0024juS3, out _0023_003DzM7o0gT3hjI5, pointsDistanceOrientationType.Vertical);
				}
				else
				{
					_0023_003DzpgkCu6_h3HLE(((Point)sketchPoint5._0023_003DzZ_ilKakl9sw5()).Position, ((Point)sketchPoint6._0023_003DzZ_ilKakl9sw5()).Position, out _0023_003Dzrgqz890sj_0024X6, out _0023_003DzO97ip_0024TQ_0024juS3, out _0023_003DzM7o0gT3hjI5);
				}
				double sx7 = pointsDistanceVisualConstraint.Value / linearDim4.Distance;
				linearDim4.Plane = _0023_003Dzrgqz890sj_0024X6;
				linearDim4.ExtLine2 = _0023_003DzM7o0gT3hjI5;
				linearDim4.Height = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
				linearDim4.ArrowheadSize = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
				linearDim4.DimLinePosition.TransformBy(Transformation.CreateAlignment(Plane.XY, _0023_003Dzrgqz890sj_0024X6) * Transformation.CreateScaling(sx7, 1.0) * Transformation.CreateAlignment(plane8, Plane.XY));
				_0023_003Dz36TNao7oaYj6(linearDim4, visualConstraint.GConstraint as ValueConstraint);
			}
			else if (visualConstraint is ConcentricCirclesDistanceVisualConstraint concentricCirclesDistanceVisualConstraint)
			{
				LinearDim linearDim5 = visualConstraint.ConstraintDimension as LinearDim;
				Plane plane9 = linearDim5.Plane;
				if (!(array2[0] is SketchCircle sketchCircle2) || !(array2[1] is SketchCircle sketchCircle3))
				{
					throw new EyeshotException(_0023_003DzgtzUy7uwiWjc(visualConstraint));
				}
				_0023_003DzpgkCu6_h3HLE((Circle)sketchCircle2._0023_003DzZ_ilKakl9sw5(), (Circle)sketchCircle3._0023_003DzZ_ilKakl9sw5(), out var _0023_003Dzrgqz890sj_0024X7, out _0023_003DzO97ip_0024TQ_0024juS3, out var _0023_003DzM7o0gT3hjI6);
				double sx8 = concentricCirclesDistanceVisualConstraint.Value / linearDim5.Distance;
				linearDim5.Plane = _0023_003Dzrgqz890sj_0024X7;
				linearDim5.ExtLine2 = _0023_003DzM7o0gT3hjI6;
				linearDim5.Height = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
				linearDim5.ArrowheadSize = _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D();
				linearDim5.DimLinePosition.TransformBy(Transformation.CreateAlignment(Plane.XY, _0023_003Dzrgqz890sj_0024X7) * Transformation.CreateScaling(sx8, 1.0) * Transformation.CreateAlignment(plane9, Plane.XY));
				_0023_003Dz36TNao7oaYj6(linearDim5, visualConstraint.GConstraint as ValueConstraint);
			}
		}
	}

	private void _0023_003Dzlnm1vysNiMTg(Transformation _0023_003DzqKPG_jw1aarm, HashSet<SketchItem> _0023_003Dz5PjoC_vVvm2Y)
	{
		ILabel[] labels = _0023_003Dz4lwYpErPR_sa().GetLabels();
		for (int i = 0; i < labels.Length; i++)
		{
			if (!(labels[i] is IStackedLabel stackedLabel) || (_0023_003Dz5PjoC_vVvm2Y != null && !_0023_003Dz5PjoC_vVvm2Y.Contains(stackedLabel.Constraint.constraint)))
			{
				continue;
			}
			stackedLabel.UpdateAnchorPoint(_0023_003DzqKPG_jw1aarm);
			stackedLabel.ResetPos();
			for (int j = 0; j < i; j++)
			{
				if (labels[j] is IStackedLabel { Visible: not false } stackedLabel2 && Point3D.DistanceSquared(stackedLabel.AnchorPoint, stackedLabel2.AnchorPoint) < 1E-12)
				{
					stackedLabel.IncrementPos();
				}
			}
		}
	}

	private void _0023_003Dzddvsfpcx1xjm(Entity _0023_003Dzs_0024uS8LA_003D, EntityList.DataForCopyAndPaste _0023_003DzT7FKw5k_003D)
	{
		if (_0023_003DzT7FKw5k_003D.SketchEntities.ContainsKey(_0023_003Dzs_0024uS8LA_003D))
		{
			return;
		}
		if (_0023_003Dzs_0024uS8LA_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() != null)
		{
			_0023_003DzT7FKw5k_003D.SketchEntities.Add(_0023_003Dzs_0024uS8LA_003D, (SketchCurve)_0023_003Dzs_0024uS8LA_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D());
		}
		if (_0023_003Dzs_0024uS8LA_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() == null || _0023_003Dzs_0024uS8LA_003D is Point)
		{
			return;
		}
		foreach (SketchPoint vertex in ((SketchCurve)_0023_003Dzs_0024uS8LA_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Vertices)
		{
			_0023_003Dzddvsfpcx1xjm(vertex._0023_003DzZ_ilKakl9sw5(), _0023_003DzT7FKw5k_003D);
		}
	}

	internal HashSet<Entity> _0023_003DzwsXIprMtQcFW(EntityList.DataForCopyAndPaste _0023_003DzT7FKw5k_003D, HashSet<string> _0023_003DzWCQYTKrbaNoRwVTuzg_003D_003D, HashSet<string> _0023_003Dz78J4Ufc4fQIHwfRoh_0024mMuMc_003D, HashSet<string> _0023_003DzLZoMS553KlT3, HashSet<string> _0023_003DzvhHXxfpmKapi, HashSet<string> _0023_003Dzu4VhVrORkoJFj2c_0g_003D_003D, bool _0023_003DzyEyDDeg_003D)
	{
		StoreHistory();
		_pasteCounter = (_0023_003DzyEyDDeg_003D ? (-1) : 0);
		HashSet<Entity> hashSet = new HashSet<Entity>();
		for (int i = 0; i < _currentBlock.Entities.Count; i++)
		{
			Entity entity = _currentBlock.Entities[i];
			if (entity.Selected && entity.IsSketchEntity() && !_0023_003DzKZK9G9lNa0rj(entity))
			{
				_0023_003Dzddvsfpcx1xjm(entity, _0023_003DzT7FKw5k_003D);
				EntityList.FillCollectionToCopy(entity, _0023_003DzWCQYTKrbaNoRwVTuzg_003D_003D, _0023_003Dz78J4Ufc4fQIHwfRoh_0024mMuMc_003D, _0023_003DzLZoMS553KlT3, _0023_003DzvhHXxfpmKapi, _0023_003Dzu4VhVrORkoJFj2c_0g_003D_003D);
				if (_0023_003DzyEyDDeg_003D && (((SketchCurve)entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).ParentCurve == null || !((SketchCurve)entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).ParentCurve._0023_003DzZ_ilKakl9sw5().Selected))
				{
					hashSet.Add(entity);
				}
			}
		}
		List<Entity> list = _0023_003DzT7FKw5k_003D.SketchEntities.Keys.ToList();
		foreach (KeyValuePair<Entity, SketchCurve> sketchEntity in _0023_003DzT7FKw5k_003D.SketchEntities)
		{
			SketchCurve value = sketchEntity.Value;
			if (value == null)
			{
				continue;
			}
			Constraint[] constraints = value.Constraints;
			foreach (Constraint constraint in constraints)
			{
				bool flag = true;
				List<int> list2 = new List<int>();
				SketchCurve[] entities = constraint.GetEntities();
				foreach (SketchCurve sketchCurve in entities)
				{
					int num = list.IndexOf(sketchCurve._0023_003DzZ_ilKakl9sw5());
					if (num < 0)
					{
						flag = false;
						break;
					}
					list2.Add(num);
				}
				if (flag && !_0023_003DzT7FKw5k_003D.Constraints.ContainsKey(constraint))
				{
					_0023_003DzT7FKw5k_003D.Constraints.Add(constraint, list2.ToArray());
				}
			}
		}
		return hashSet;
	}

	private bool _0023_003DzKZK9G9lNa0rj(Entity _0023_003Dzs_0024uS8LA_003D)
	{
		_0023_003DzyCKwxE4ADDaS1Cy2Ib5Qd7s_003D CS_0024_003C_003E8__locals3 = new _0023_003DzyCKwxE4ADDaS1Cy2Ib5Qd7s_003D();
		CS_0024_003C_003E8__locals3._0023_003Dz1zXPEMVtR7MH = _0023_003Dzs_0024uS8LA_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint;
		if (CS_0024_003C_003E8__locals3._0023_003Dz1zXPEMVtR7MH != null && Sketch.Constraints.Any((Constraint _0023_003Dzt_m8zV0_003D) => _0023_003Dzt_m8zV0_003D is PolygonConstraint polygonConstraint && polygonConstraint.Center == CS_0024_003C_003E8__locals3._0023_003Dz1zXPEMVtR7MH))
		{
			return true;
		}
		return false;
	}

	internal void _0023_003DzI0UvCG0_003D(EntityList.DataForCopyAndPaste _0023_003DzT7FKw5k_003D)
	{
		if (_0023_003DzT7FKw5k_003D.SketchEntities.Count == 0)
		{
			return;
		}
		_pasteCounter++;
		foreach (KeyValuePair<Entity, SketchCurve> sketchEntity in _0023_003DzT7FKw5k_003D.SketchEntities)
		{
			if (sketchEntity.Key is ICurve)
			{
				_0023_003Dz4eFoqUXpy9Lo(sketchEntity.Value, sketchEntity.Key, _design.Entities);
			}
		}
		_0023_003Dz_0024RpJpdb7baIWeBTUoQ_003D_003D(_0023_003DzT7FKw5k_003D);
		Entity[] _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D = _0023_003DzT7FKw5k_003D.SketchEntities.Keys.ToArray();
		foreach (KeyValuePair<Constraint, int[]> constraint in _0023_003DzT7FKw5k_003D.Constraints)
		{
			_0023_003DzgWs_ED4iKr_o(constraint, _0023_003DzT7FKw5k_003D, _0023_003DzQW28u_0024Lqa_tMLVaB_0024g_003D_003D);
		}
		UpdateAndInvalidate();
		_0023_003DzGpBouKT_0024wCmV(_design.CurrentTransformation, null);
	}

	private void _0023_003Dz_0024RpJpdb7baIWeBTUoQ_003D_003D(EntityList.DataForCopyAndPaste _0023_003DzT7FKw5k_003D)
	{
		_dragStartPoint = Point2D.Origin;
		Sketch.DragStart(_0023_003DzT7FKw5k_003D.SketchEntities.Values.ToArray());
		Point2D point2D = _pasteCounter * PasteOffset;
		Sketch.Drag(_dragStartPoint, point2D);
		_dragCurrentPoint = point2D;
		UpdateAndInvalidate();
		Sketch.DragEnd();
	}

	private void _0023_003DzXDnPjAXCdv3s(bool _0023_003DzPzO_0024GUk_003D)
	{
		Dragging = _0023_003DzPzO_0024GUk_003D;
	}

	public void DragStart(Point2D start, params Entity[] entities)
	{
		_dragStartPoint = start;
		_dragCurrentPoint = start;
		if (entities.Length == 1)
		{
			Entity entity = entities[0];
			if (entity.IsFixed())
			{
				return;
			}
			if (entity.GetType() == typeof(Circle) || entity is Dimension)
			{
				_0023_003DzXDnPjAXCdv3s(_0023_003DzPzO_0024GUk_003D: true);
				_target = entities[0];
				return;
			}
		}
		SketchCurve[] array = entities.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzvdru9RqabY9P44OX46SJ6iI_003D).Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzi4wZUA17pCd9eSgarj0dKGo_003D).Cast<SketchCurve>()
			.ToArray();
		if (array.Length != 0)
		{
			_0023_003DzXDnPjAXCdv3s(_0023_003DzPzO_0024GUk_003D: true);
			Sketch.DragStart(array);
		}
	}

	public void DragTo(Point2D to)
	{
		if (!Dragging)
		{
			DragEnd();
			return;
		}
		if (_target is Circle)
		{
			SketchCircle obj = (SketchCircle)_target._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
			obj.Radius = obj.Center.PlanePosition.DistanceTo(to);
		}
		else if (_target is Dimension dimension)
		{
			dimension.DimLinePosition = Plane.PointAt(to);
			ValueVisualConstraint valueVisualConstraint = (ValueVisualConstraint)GetConstraint(dimension);
			_0023_003Dz36TNao7oaYj6(dimension, (ValueConstraint)valueVisualConstraint.GConstraint);
		}
		else
		{
			Sketch.Drag(_dragCurrentPoint, to);
		}
		_dragCurrentPoint = to;
	}

	public void DragEnd()
	{
		_target = null;
		if (Dragging)
		{
			_0023_003DzXDnPjAXCdv3s(_0023_003DzPzO_0024GUk_003D: false);
			Sketch.DragEnd();
			UpdateAndInvalidate();
			if (_dragStartPoint != null && _dragCurrentPoint != null && Point2D.DistanceSquared(_dragStartPoint, _dragCurrentPoint) > Utility._0023_003DzheSR8QM7q9ya)
			{
				StoreHistory();
			}
		}
	}

	internal void _0023_003DzrSUfOY0HOz5O(Entity _0023_003Dz9j7EUB0_003D)
	{
		if (_0023_003Dz9j7EUB0_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() != null)
		{
			_0023_003Dze5G1YDQ3JaMH((SketchCurve)_0023_003Dz9j7EUB0_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D());
			CurveList.Remove((ICurve)_0023_003Dz9j7EUB0_003D);
			_design.Entities.Remove(_0023_003Dz9j7EUB0_003D);
			_0023_003Dz9bTNAMXQoAjCHo_0024wAhHwr6g_003D(this, (ICurve)_0023_003Dz9j7EUB0_003D);
		}
	}

	public bool DeleteEntity(Entity entity)
	{
		return _0023_003Dz1sKlGcomVW_00249(entity, _0023_003Dz_Vh3jJmOXzl5R1f_0024IQ_003D_003D: true);
	}

	internal bool _0023_003Dz1sKlGcomVW_00249(Entity _0023_003Dz9j7EUB0_003D, bool _0023_003Dz_Vh3jJmOXzl5R1f_0024IQ_003D_003D)
	{
		if (_0023_003Dz9j7EUB0_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() == null)
		{
			return false;
		}
		if (_0023_003Dz9j7EUB0_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() is SketchPoint { ParentCurve: not null } sketchPoint)
		{
			return DeleteEntity(sketchPoint.ParentCurve._0023_003DzZ_ilKakl9sw5());
		}
		if (_0023_003Dz_Vh3jJmOXzl5R1f_0024IQ_003D_003D && _0023_003Dz9j7EUB0_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() is SketchEllipse)
		{
			Constraint[] constraints = ((SketchCurve)_0023_003Dz9j7EUB0_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Constraints;
			for (int i = 0; i < constraints.Length; i++)
			{
				if (constraints[i] is PointAtConstraint pointAtConstraint)
				{
					DeleteEntity(pointAtConstraint.Point._0023_003DzZ_ilKakl9sw5());
				}
			}
		}
		if (!(_0023_003Dz9j7EUB0_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() is SketchPoint) && _0023_003Dz_Vh3jJmOXzl5R1f_0024IQ_003D_003D)
		{
			foreach (SketchPoint vertex in ((SketchCurve)_0023_003Dz9j7EUB0_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Vertices)
			{
				_0023_003DzrSUfOY0HOz5O(vertex._0023_003DzZ_ilKakl9sw5());
			}
		}
		foreach (Entity item in _0023_003Dz485JMIMmTVuuyF12gg_003D_003D(_0023_003Dz9j7EUB0_003D))
		{
			DeleteEntity(item);
		}
		_0023_003DzrSUfOY0HOz5O(_0023_003Dz9j7EUB0_003D);
		_0023_003Dz9j7EUB0_003D._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D().Destroy();
		return true;
	}

	internal void _0023_003Dze5G1YDQ3JaMH(SketchCurve _0023_003Dz8fpRyMu9aKjE)
	{
		Constraint[] constraints = _0023_003Dz8fpRyMu9aKjE.Constraints;
		foreach (Constraint _0023_003DzV_0024oduG8_003D in constraints)
		{
			_0023_003DzHRlsxtgiikwy(_0023_003DzV_0024oduG8_003D);
		}
	}

	internal void _0023_003DzHRlsxtgiikwy(Constraint _0023_003DzV_0024oduG8_003D)
	{
		DeleteConstraint(_0023_003DzV_0024oduG8_003D._0023_003DzzRLCjkBKJt17());
	}

	public void DeleteConstraint(VisualConstraint constraint)
	{
		constraint?.Destroy();
	}

	public void DeleteConstraint(Entity entity)
	{
		VisualConstraint constraint = GetConstraint(entity);
		if (constraint != null)
		{
			DeleteConstraint(constraint);
		}
	}

	private void _0023_003DzxtNOJHADFGkK(SketchPoint _0023_003Dz79R_0024VZY_003D)
	{
		if (_0023_003Dz79R_0024VZY_003D.ParentCurve is SketchLine sketchLine)
		{
			sketchLine.Constraints.Where((Constraint _0023_003DzV_0024oduG8_003D) => _0023_003DzV_0024oduG8_003D is PolygonConstraint).ToList().ForEach(_0023_003DzHRlsxtgiikwy);
		}
	}

	private void _0023_003Dz1gNRaniInhY7(SketchPoint _0023_003Dz79R_0024VZY_003D)
	{
		_0023_003Dz79R_0024VZY_003D.Constraints.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz77GWE5QD8NOq19M43JPy3IU_003D).ToList().ForEach(_0023_003DzHRlsxtgiikwy);
	}

	private void _0023_003DztXK6GnE_003D()
	{
		ClearHistory();
	}

	private void _0023_003DzbiZkb0WIYpL_0024<T>(T[] _0023_003Dzv7xH9gk_003D) where T : SketchCurve
	{
		foreach (Constraint item in _0023_003Dzv7xH9gk_003D.SelectMany((T _0023_003DzvM_00244CJo_003D) => _0023_003DzvM_00244CJo_003D.Constraints).Distinct())
		{
			_0023_003DzIrs5MDJ5nmrc(item, _design.Entities);
		}
		foreach (Constraint item2 in _0023_003Dzv7xH9gk_003D.SelectMany(_0023_003DzCf6bSKSuk_DlmHe6xQ_003D_003D<T>._0023_003DzJ5g3Rwo_003D._0023_003DzWKwsNDNgjMrj57OXVeWzvqE_003D).SelectMany(_0023_003DzCf6bSKSuk_DlmHe6xQ_003D_003D<T>._0023_003DzJ5g3Rwo_003D._0023_003DzmeK2y4Xd3bkarO1EAuO3pZ0_003D).Distinct())
		{
			_0023_003DzIrs5MDJ5nmrc(item2, _design.Entities);
		}
	}

	public LengthVisualConstraint AddConstraintLength(Line line, double value = -1.0, bool reference = false, Point2D dimLinePos = null)
	{
		LengthConstraint lengthConstraint = ((value >= 0.0) ? Sketch.AddConstraintLength((SketchCurve)line._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), value) : Sketch.AddConstraintLength((SketchCurve)line._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()));
		lengthConstraint.Reference = reference;
		Utility._0023_003DzpgkCu6_h3HLE(Plane, line, out var _0023_003Dzrgqz890sj_0024X);
		Point3D dimLinePos2 = ((dimLinePos == null) ? (line.MidPoint + _0023_003DzF51E6l8EH_0024Ri() * _0023_003Dzrgqz890sj_0024X.AxisY) : Plane.PointAt(dimLinePos));
		LinearDim linearDim = new LinearDim(_0023_003Dzrgqz890sj_0024X, line.StartPoint, line.EndPoint, dimLinePos2, _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
		linearDim.WidthFactor = DimensionsWidthFactor;
		LengthVisualConstraint result = new LengthVisualConstraint(_0023_003Dz4lwYpErPR_sa(), linearDim, lengthConstraint);
		_0023_003DzUQJXD50_003D(lengthConstraint, linearDim);
		return result;
	}

	public DiameterVisualConstraint AddConstraintDiameter(Circle circle, double value = -1.0, bool reference = false, Point2D dimLinePos = null)
	{
		RadiusConstraint radiusConstraint = null;
		radiusConstraint = ((!(circle is Arc)) ? ((value >= 0.0) ? Sketch.AddConstraintDiameter((SketchCurve)circle._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), value) : Sketch.AddConstraintDiameter((SketchCurve)circle._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D())) : ((value >= 0.0) ? Sketch.AddConstraintRadius((SketchCurve)circle._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), value) : Sketch.AddConstraintRadius((SketchCurve)circle._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D())));
		if (radiusConstraint == null)
		{
			return null;
		}
		radiusConstraint.Reference = reference;
		Dimension dimension = null;
		if (circle is Arc)
		{
			Arc arc = circle as Arc;
			RadialDim radialDim = new RadialDim(arc, (dimLinePos == null) ? arc.MidPoint : Plane.PointAt(dimLinePos), _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D(), Plane);
			radialDim.WidthFactor = 0.9;
			radialDim.WidthFactor = DimensionsWidthFactor;
			dimension = radialDim;
		}
		else
		{
			DiametricDim diametricDim = new DiametricDim(circle, (dimLinePos == null) ? circle.PointAt(Math.PI / 4.0) : Plane.PointAt(dimLinePos), _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D(), Plane);
			diametricDim.WidthFactor = 0.9;
			diametricDim.WidthFactor = DimensionsWidthFactor;
			dimension = diametricDim;
		}
		DiameterVisualConstraint result = new DiameterVisualConstraint(_0023_003Dz4lwYpErPR_sa(), dimension, radiusConstraint);
		_0023_003DzUQJXD50_003D(radiusConstraint, dimension);
		return result;
	}

	public VisualConstraint AddConstraintJoin(Point p, Entity ent)
	{
		SketchPoint _0023_003DzlY77YgY_003D = p._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint;
		SketchCurve _0023_003Dz8fpRyMu9aKjE = (SketchCurve)ent._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
		return _0023_003Dz9_0024HudZfEoQzz(_0023_003DzlY77YgY_003D, _0023_003Dz8fpRyMu9aKjE);
	}

	private VisualConstraint _0023_003Dz9_0024HudZfEoQzz(SketchPoint _0023_003DzlY77YgY_003D, SketchCurve _0023_003Dz8fpRyMu9aKjE)
	{
		if (_0023_003Dz8fpRyMu9aKjE is SketchPoint point)
		{
			CoincidentConstraint coincidentConstraint = Sketch.AddConstraintJoin(_0023_003DzlY77YgY_003D, point);
			IStackedLabel stackedLabel = _0023_003DzLuIkz4x3FVHS().Create(labelType.Join, _0023_003DzlY77YgY_003D, coincidentConstraint);
			CoincidentVisualConstraint result = new CoincidentVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[1] { stackedLabel }, coincidentConstraint);
			_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel);
			return result;
		}
		PointOnConstraint pointOnConstraint = Sketch.AddConstraintPointOn(_0023_003DzlY77YgY_003D, _0023_003Dz8fpRyMu9aKjE);
		IStackedLabel stackedLabel2 = _0023_003DzLuIkz4x3FVHS().Create(labelType.PointOn, _0023_003DzlY77YgY_003D, pointOnConstraint);
		PointOnVisualConstraint result2 = new PointOnVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[1] { stackedLabel2 }, pointOnConstraint);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel2);
		return result2;
	}

	public PointFixedVisualConstraint AddConstraintPointFixed(Point p1)
	{
		((SketchPoint)p1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).FixToOrigin(out var pointFixedConstraint);
		IStackedLabel stackedLabel = _0023_003DzLuIkz4x3FVHS().Create(labelType.Fix, (SketchCurve)p1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), pointFixedConstraint);
		PointFixedVisualConstraint result = new PointFixedVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[1] { stackedLabel }, pointFixedConstraint);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel);
		return result;
	}

	public HvVisualConstraint AddConstraintHorizontal(Line l1)
	{
		HVConstraint hVConstraint = Sketch.AddConstraintHorizontal(l1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchLine);
		IStackedLabel stackedLabel = _0023_003DzLuIkz4x3FVHS().Create(labelType.Horizontal, (SketchCurve)l1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), hVConstraint);
		HvVisualConstraint result = new HvVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[1] { stackedLabel }, hVConstraint);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel);
		return result;
	}

	public HvVisualConstraint AddConstraintHorizontal(Point p1, Point p2)
	{
		HVConstraint hVConstraint = Sketch.AddConstraintHorizontal(p1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, p2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint);
		IStackedLabel stackedLabel = _0023_003DzLuIkz4x3FVHS().Create(labelType.Horizontal, (SketchCurve)p1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), hVConstraint);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel);
		IStackedLabel stackedLabel2 = _0023_003DzLuIkz4x3FVHS().Create(labelType.Horizontal, (SketchCurve)p2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), hVConstraint);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel2);
		return new HvVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[2] { stackedLabel, stackedLabel2 }, hVConstraint);
	}

	public HvVisualConstraint AddConstraintVertical(Point p1, Point p2)
	{
		HVConstraint hVConstraint = Sketch.AddConstraintVertical(p1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, p2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint);
		IStackedLabel stackedLabel = _0023_003DzLuIkz4x3FVHS().Create(labelType.Vertical, (SketchCurve)p1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), hVConstraint);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel);
		IStackedLabel stackedLabel2 = _0023_003DzLuIkz4x3FVHS().Create(labelType.Vertical, (SketchCurve)p2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), hVConstraint);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel2);
		return new HvVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[2] { stackedLabel, stackedLabel2 }, hVConstraint);
	}

	public HvVisualConstraint AddConstraintVertical(Line l1)
	{
		HVConstraint hVConstraint = Sketch.AddConstraintVertical(l1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchLine);
		IStackedLabel stackedLabel = _0023_003DzLuIkz4x3FVHS().Create(labelType.Vertical, (SketchCurve)l1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), hVConstraint);
		HvVisualConstraint result = new HvVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[1] { stackedLabel }, hVConstraint);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel);
		return result;
	}

	public ParallelLinesVisualConstraint AddConstraintParallelLines(Line l1, Line l2)
	{
		ParallelConstraint parallelConstraint = Sketch.AddConstraintParallel((SketchCurve)l1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), (SketchCurve)l2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D());
		IStackedLabel stackedLabel = _0023_003DzLuIkz4x3FVHS().Create(labelType.Parallel, (SketchCurve)l1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), parallelConstraint);
		IStackedLabel stackedLabel2 = _0023_003DzLuIkz4x3FVHS().Create(labelType.Parallel, (SketchCurve)l2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), parallelConstraint);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel2);
		return new ParallelLinesVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[2] { stackedLabel, stackedLabel2 }, parallelConstraint);
	}

	public PerpendicularVisualConstraint AddConstraintPerpendicular(Line l1, Line l2)
	{
		PerpendicularConstraint perpendicularConstraint = Sketch.AddConstraintPerpendicular((SketchCurve)l1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), (SketchCurve)l2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D());
		IStackedLabel stackedLabel = _0023_003DzLuIkz4x3FVHS().Create(labelType.Perpendicular, (SketchCurve)l1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), perpendicularConstraint);
		IStackedLabel stackedLabel2 = _0023_003DzLuIkz4x3FVHS().Create(labelType.Perpendicular, (SketchCurve)l2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), perpendicularConstraint);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel2);
		return new PerpendicularVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[2] { stackedLabel, stackedLabel2 }, perpendicularConstraint);
	}

	public EqualVisualConstraint AddConstraintEqual(Entity e1, Entity e2, bool eqRadius = false)
	{
		EqualConstraint equalConstraint = null;
		EqualVisualConstraint result = null;
		if (eqRadius)
		{
			if (e1 is Circle && e2 is Circle)
			{
				equalConstraint = Sketch.AddConstraintEqualRadius((SketchCircle)e1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), (SketchCircle)e2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D());
				IStackedLabel stackedLabel = _0023_003DzLuIkz4x3FVHS().Create(labelType.EqualRadius, (SketchCurve)e1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), equalConstraint);
				IStackedLabel stackedLabel2 = _0023_003DzLuIkz4x3FVHS().Create(labelType.EqualRadius, (SketchCurve)e2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), equalConstraint);
				_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel);
				_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel2);
				result = new EqualVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[2] { stackedLabel, stackedLabel2 }, equalConstraint);
			}
		}
		else
		{
			equalConstraint = Sketch.AddConstraintEqualLength((SketchCurve)e1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), (SketchCurve)e2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D());
			IStackedLabel stackedLabel3 = _0023_003DzLuIkz4x3FVHS().Create(labelType.Equal, (SketchCurve)e1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), equalConstraint);
			IStackedLabel stackedLabel4 = _0023_003DzLuIkz4x3FVHS().Create(labelType.Equal, (SketchCurve)e2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), equalConstraint);
			_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel3);
			_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel4);
			result = new EqualVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[2] { stackedLabel3, stackedLabel4 }, equalConstraint);
		}
		return result;
	}

	public CollinearPointsVisualConstraint AddConstraintCollinearPoints(Point p1, Point p2, Point p3)
	{
		CollinearPointsConstraint collinearPointsConstraint = Sketch.AddConstraintCollinear(p1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, p2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, p3._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint);
		IStackedLabel stackedLabel = _0023_003DzLuIkz4x3FVHS().Create(labelType.Collinear, (SketchCurve)p1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), collinearPointsConstraint);
		IStackedLabel stackedLabel2 = _0023_003DzLuIkz4x3FVHS().Create(labelType.Collinear, (SketchCurve)p2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), collinearPointsConstraint);
		IStackedLabel stackedLabel3 = _0023_003DzLuIkz4x3FVHS().Create(labelType.Collinear, (SketchCurve)p3._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), collinearPointsConstraint);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel2);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel3);
		return new CollinearPointsVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[3] { stackedLabel, stackedLabel2, stackedLabel3 }, collinearPointsConstraint);
	}

	public TangentVisualConstraint AddConstraintTangent(Entity e1, Entity e2)
	{
		TangentConstraint tangentConstraint = Sketch.AddConstraintTangent((SketchCurve)e1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), (SketchCurve)e2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D());
		List<IStackedLabel> list = new List<IStackedLabel>();
		IStackedLabel item = _0023_003DzLuIkz4x3FVHS().Create(labelType.Tangent, (SketchCurve)e1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), tangentConstraint);
		list.Add(item);
		TangentVisualConstraint result = new TangentVisualConstraint(_0023_003Dz4lwYpErPR_sa(), list.ToArray(), tangentConstraint);
		IViewportInternal viewportInternal = _0023_003Dz4lwYpErPR_sa();
		ILabel[] labels = list.ToArray();
		viewportInternal.AddLabel(labels);
		return result;
	}

	public PolygonVisualConstraint AddConstraintPolygon(Line[] edges, Point center = null)
	{
		SketchLine[] array = new SketchLine[edges.Length];
		for (int i = 0; i < edges.Length; i++)
		{
			array[i] = edges[i]._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchLine;
		}
		PolygonConstraint polygonConstraint = Sketch.AddConstraintPolygon(array, center?._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint);
		if (center == null)
		{
			_0023_003Dz8ilmF8wT2E63PguzhA_003D_003D(polygonConstraint.Center);
		}
		_0023_003DzIrs5MDJ5nmrc(polygonConstraint, _design.Entities);
		return polygonConstraint._0023_003DzzRLCjkBKJt17() as PolygonVisualConstraint;
	}

	public CollinearVisualConstraint AddConstraintCollinear(Line l1, Line l2)
	{
		CollinearConstraint collinearConstraint = Sketch.AddConstraintCollinear((SketchCurve)l1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), (SketchCurve)l2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D());
		List<IStackedLabel> list = new List<IStackedLabel>();
		IStackedLabel item = _0023_003DzLuIkz4x3FVHS().Create(labelType.Collinear, (SketchCurve)l1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), collinearConstraint);
		IStackedLabel item2 = _0023_003DzLuIkz4x3FVHS().Create(labelType.Collinear, (SketchCurve)l2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), collinearConstraint);
		list.Add(item);
		list.Add(item2);
		CollinearVisualConstraint result = new CollinearVisualConstraint(_0023_003Dz4lwYpErPR_sa(), list.ToArray(), collinearConstraint);
		IViewportInternal viewportInternal = _0023_003Dz4lwYpErPR_sa();
		ILabel[] labels = list.ToArray();
		viewportInternal.AddLabel(labels);
		return result;
	}

	public MirrorVisualConstraint AddConstraintMirror(Entity e1, Entity e2, Line axis)
	{
		MirrorConstraint mirrorConstraint = Sketch.AddConstraintMirror((SketchCurve)e1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), (SketchCurve)e2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), axis._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchLine);
		IStackedLabel stackedLabel = _0023_003DzLuIkz4x3FVHS().Create(labelType.Mirror, (SketchCurve)e1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), mirrorConstraint);
		IStackedLabel stackedLabel2 = _0023_003DzLuIkz4x3FVHS().Create(labelType.Mirror, (SketchCurve)e2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), mirrorConstraint);
		IStackedLabel stackedLabel3 = _0023_003DzLuIkz4x3FVHS().Create(labelType.Mirror, (SketchCurve)axis._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), mirrorConstraint);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel2);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel3);
		return new MirrorVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[3] { stackedLabel, stackedLabel2, stackedLabel3 }, mirrorConstraint);
	}

	public AngleVisualConstraint AddConstraintAngle(Point firstPoint, Point centerPoint, Point secondPoint, double value = -1.0, bool reference = false, Point2D dimLinePos = null)
	{
		AngleConstraint angleConstraint = ((value >= 0.0) ? Sketch.AddConstraintAngle(firstPoint._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, centerPoint._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, secondPoint._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, value) : Sketch.AddConstraintAngle(firstPoint._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, centerPoint._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, secondPoint._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint));
		angleConstraint.Reference = reference;
		Arc arc = new Arc(Plane, Plane.PointAt(centerPoint.Position), Plane.PointAt(firstPoint.Position), Plane.PointAt(secondPoint.Position));
		AngularDim angularDim = new AngularDim(new Plane(centerPoint.Position, Plane.AxisX, Plane.AxisY), firstPoint.Position, secondPoint.Position, (dimLinePos == null) ? arc.MidPoint : Plane.PointAt(dimLinePos), _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
		angularDim.WidthFactor = DimensionsWidthFactor;
		AngleVisualConstraint result = new AngleVisualConstraint(_0023_003Dz4lwYpErPR_sa(), angularDim, angleConstraint);
		_0023_003DzUQJXD50_003D(angleConstraint, angularDim);
		return result;
	}

	public AngleVisualConstraint AddConstraintAngle(Arc arc, double value = -1.0, bool reference = false, Point2D dimLinePos = null)
	{
		AngleConstraint angleConstraint = ((value >= 0.0) ? Sketch.AddConstraintAngle(arc._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchArc, value) : Sketch.AddConstraintAngle(arc._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchArc));
		angleConstraint.Reference = false;
		Plane plane = (Plane)arc.Plane.Clone();
		Point3D extLine = arc.StartPoint;
		Point3D extLine2 = arc.EndPoint;
		if (Utility.IsOrientedClockwise(arc.Vertices))
		{
			plane.Flip();
			extLine = arc.EndPoint;
			extLine2 = arc.StartPoint;
		}
		AngularDim angularDim = new AngularDim(plane, extLine, extLine2, (dimLinePos == null) ? arc.MidPoint : Plane.PointAt(dimLinePos), _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
		angularDim.WidthFactor = DimensionsWidthFactor;
		AngleVisualConstraint result = new AngleVisualConstraint(_0023_003Dz4lwYpErPR_sa(), angularDim, angleConstraint);
		_0023_003DzUQJXD50_003D(angleConstraint, angularDim);
		return result;
	}

	public AngleVisualConstraint AddConstraintAngle(Line l1, Line l2, Point2D quadrantPoint, double value = -1.0, bool reference = false, Point2D dimLinePos = null)
	{
		AngleConstraint angleConstraint = ((value >= 0.0) ? Sketch.AddConstraintAngle((SketchLine)l1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), (SketchLine)l2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), quadrantPoint, value) : Sketch.AddConstraintAngle((SketchLine)l1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), (SketchLine)l2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), quadrantPoint));
		angleConstraint.Reference = reference;
		Point3D quadrantPoint2 = Sketch.SketchPlane.PointAt(quadrantPoint);
		Point3D dimLinePos2 = ((dimLinePos != null) ? Sketch.SketchPlane.PointAt(dimLinePos) : Plane.PointAt(quadrantPoint));
		AngularDim angularDim = new AngularDim(Sketch.SketchPlane, l1, l2, quadrantPoint2, dimLinePos2, _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
		angularDim.WidthFactor = DimensionsWidthFactor;
		AngleVisualConstraint result = new AngleVisualConstraint(_0023_003Dz4lwYpErPR_sa(), angularDim, angleConstraint);
		_0023_003DzUQJXD50_003D(angleConstraint, angularDim);
		return result;
	}

	public PointLineDistanceVisualConstraint AddConstraintPointLineDistance(Point p, Line l, double value = -1.0, bool reference = false, Point2D dimLinePos = null)
	{
		PointLineDistanceConstraint pointLineDistanceConstraint = ((value >= 0.0) ? Sketch.AddConstraintDistance(p._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, l._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchLine, value) : Sketch.AddConstraintDistance(p._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, l._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchLine));
		pointLineDistanceConstraint.Reference = reference;
		l.Project(p.Position, out var t);
		Point3D point3D = l.PointAt(t);
		Vector3D vector3D = new Vector3D(p.Position, point3D);
		vector3D.Normalize();
		Point3D dimLinePos2 = ((dimLinePos == null) ? (Point3D.MidPoint(p.Position, point3D) + _0023_003DzF51E6l8EH_0024Ri() * Vector3D.Cross(Plane.AxisZ, vector3D)) : Plane.PointAt(dimLinePos));
		Plane plane = new Plane(p.Position, vector3D, Vector3D.Cross(Plane.AxisZ, vector3D));
		_0023_003DzFnNMk7MIIrR9IdPepgRQpoW_UWlS4cNmAdN5ZmM_003D(plane);
		LinearDim linearDim = new LinearDim(plane, p.Position, point3D, dimLinePos2, _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
		linearDim.WidthFactor = DimensionsWidthFactor;
		_0023_003DzUQJXD50_003D(pointLineDistanceConstraint, linearDim);
		return new PointLineDistanceVisualConstraint(_0023_003Dz4lwYpErPR_sa(), linearDim, pointLineDistanceConstraint);
	}

	public PointsDistanceVisualConstraint AddConstraintAlignedPointsDistance(Point p1, Point p2, double value = -1.0, bool reference = false, Point2D dimLinePos = null)
	{
		PointsDistanceConstraint pointsDistanceConstraint = ((value >= 0.0) ? Sketch.AddConstraintDistance(p1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, p2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, value) : Sketch.AddConstraintDistance(p1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, p2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint));
		pointsDistanceConstraint.Reference = reference;
		Vector3D vector3D = new Vector3D(p1.Position, p2.Position);
		vector3D.Normalize();
		Point3D dimLinePos2 = ((dimLinePos == null) ? (Point3D.MidPoint(p1.Position, p2.Position) + _0023_003DzF51E6l8EH_0024Ri() * Vector3D.Cross(Plane.AxisZ, vector3D)) : Plane.PointAt(dimLinePos));
		Plane plane = new Plane(p1.Position, vector3D, Vector3D.Cross(Plane.AxisZ, vector3D));
		_0023_003DzFnNMk7MIIrR9IdPepgRQpoW_UWlS4cNmAdN5ZmM_003D(plane);
		LinearDim linearDim = new LinearDim(plane, p1.Position, p2.Position, dimLinePos2, _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
		linearDim.WidthFactor = DimensionsWidthFactor;
		_0023_003DzUQJXD50_003D(pointsDistanceConstraint, linearDim);
		return new PointsDistanceVisualConstraint(_0023_003Dz4lwYpErPR_sa(), linearDim, pointsDistanceConstraint);
	}

	public PointsDistanceVisualConstraint AddConstraintHorizontalPointsDistance(Point p1, Point p2, double value = -1.0, bool reference = false, Point2D dimLinePos = null)
	{
		HorizontalPointsDistanceConstraint horizontalPointsDistanceConstraint = ((value >= 0.0) ? Sketch.AddConstraintHorizontalDistance(p1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, p2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, value) : Sketch.AddConstraintHorizontalDistance(p1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, p2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint));
		horizontalPointsDistanceConstraint.Reference = reference;
		Vector3D axisX = Plane.AxisX;
		axisX.Normalize();
		Point3D dimLinePos2 = ((dimLinePos == null) ? (Point3D.MidPoint(p1.Position, p2.Position) + _0023_003DzF51E6l8EH_0024Ri() * Vector3D.Cross(Plane.AxisZ, axisX)) : Plane.PointAt(dimLinePos));
		Plane plane = new Plane(p1.Position, axisX, Vector3D.Cross(Plane.AxisZ, axisX));
		_0023_003DzFnNMk7MIIrR9IdPepgRQpoW_UWlS4cNmAdN5ZmM_003D(plane);
		LinearDim linearDim = new LinearDim(plane, p1.Position, p2.Position, dimLinePos2, _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
		linearDim.WidthFactor = DimensionsWidthFactor;
		_0023_003DzUQJXD50_003D(horizontalPointsDistanceConstraint, linearDim);
		return new PointsDistanceVisualConstraint(_0023_003Dz4lwYpErPR_sa(), linearDim, horizontalPointsDistanceConstraint);
	}

	public PointsDistanceVisualConstraint AddConstraintVerticalPointsDistance(Point p1, Point p2, double value = -1.0, bool reference = false, Point2D dimLinePos = null)
	{
		VerticalPointsDistanceConstraint verticalPointsDistanceConstraint = ((value >= 0.0) ? Sketch.AddConstraintVerticalDistance(p1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, p2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, value) : Sketch.AddConstraintVerticalDistance(p1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint, p2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchPoint));
		verticalPointsDistanceConstraint.Reference = reference;
		Vector3D axisY = Plane.AxisY;
		axisY.Normalize();
		Point3D dimLinePos2 = ((dimLinePos != null) ? Plane.PointAt(dimLinePos) : (Point3D.MidPoint(p1.Position, p2.Position) + _0023_003DzF51E6l8EH_0024Ri() * Vector3D.Cross(Plane.AxisZ, axisY)));
		Plane plane = new Plane(p1.Position, axisY, Vector3D.Cross(Plane.AxisZ, axisY));
		_0023_003DzFnNMk7MIIrR9IdPepgRQpoW_UWlS4cNmAdN5ZmM_003D(plane);
		LinearDim linearDim = new LinearDim(plane, p1.Position, p2.Position, dimLinePos2, _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
		linearDim.WidthFactor = DimensionsWidthFactor;
		_0023_003DzUQJXD50_003D(verticalPointsDistanceConstraint, linearDim);
		return new PointsDistanceVisualConstraint(_0023_003Dz4lwYpErPR_sa(), linearDim, verticalPointsDistanceConstraint);
	}

	public LinesDistanceVisualConstraint AddConstraintLinesDistance(Line l1, Line l2, double value = -1.0, bool reference = false, Point2D dimLinePos = null)
	{
		LinesDistanceConstraint linesDistanceConstraint = ((value >= 0.0) ? Sketch.AddConstraintDistance(l1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchLine, l2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchLine, value) : Sketch.AddConstraintDistance(l1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchLine, l2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchLine));
		linesDistanceConstraint.Reference = reference;
		Point3D startPoint = l1.StartPoint;
		l2.Project(startPoint, out var t);
		Point3D point3D = l2.PointAt(t);
		Vector3D vector3D = new Vector3D(startPoint, point3D);
		vector3D.Normalize();
		Point3D dimLinePos2 = ((dimLinePos != null) ? Plane.PointAt(dimLinePos) : (Point3D.MidPoint(startPoint, point3D) + _0023_003DzF51E6l8EH_0024Ri() * Vector3D.Cross(Plane.AxisZ, vector3D)));
		Plane plane = new Plane(startPoint, vector3D, Vector3D.Cross(Plane.AxisZ, vector3D));
		_0023_003DzFnNMk7MIIrR9IdPepgRQpoW_UWlS4cNmAdN5ZmM_003D(plane);
		LinearDim linearDim = new LinearDim(plane, startPoint, point3D, dimLinePos2, _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
		linearDim.WidthFactor = DimensionsWidthFactor;
		_0023_003DzUQJXD50_003D(linesDistanceConstraint, linearDim);
		return new LinesDistanceVisualConstraint(_0023_003Dz4lwYpErPR_sa(), linearDim, linesDistanceConstraint);
	}

	private void _0023_003DzFnNMk7MIIrR9IdPepgRQpoW_UWlS4cNmAdN5ZmM_003D(Plane _0023_003Dzk5BbLuzKcKNK_ipsuA_003D_003D)
	{
		double num = Plane.Project(_0023_003Dzk5BbLuzKcKNK_ipsuA_003D_003D.AxisX).Angle;
		if (num < 0.0)
		{
			num += Math.PI * 2.0;
			_0023_003Dzk5BbLuzKcKNK_ipsuA_003D_003D.Rotate(Math.PI * 2.0, Plane.AxisZ, _0023_003Dzk5BbLuzKcKNK_ipsuA_003D_003D.Origin);
		}
		if (Utility.TextNeedsToBeFlippedAccordingToDrawingRules(num - Math.PI / 2.0))
		{
			_0023_003Dzk5BbLuzKcKNK_ipsuA_003D_003D.Rotate(Math.PI, Plane.AxisZ, _0023_003Dzk5BbLuzKcKNK_ipsuA_003D_003D.Origin);
		}
	}

	public ConcentricCirclesDistanceVisualConstraint AddConstraintConcentricDistance(Circle c1, Circle c2, bool reference = false, Point2D dimLinePos = null)
	{
		ConcentricCirclesDistanceConstraint concentricCirclesDistanceConstraint = Sketch.AddConstraintConcentricDistance((SketchCircle)c1._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), (SketchCircle)c2._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D());
		concentricCirclesDistanceConstraint.Reference = false;
		Point3D point3D = c1.PointAt(c1.Domain.Mid);
		if (c2.Project(point3D, out var t))
		{
			Point3D point3D2 = c2.PointAt(t);
			Vector3D vector3D = new Vector3D(point3D, point3D2);
			vector3D.Normalize();
			Point3D dimLinePos2 = ((dimLinePos != null) ? Plane.PointAt(dimLinePos) : (Point3D.MidPoint(point3D, point3D2) + _0023_003DzF51E6l8EH_0024Ri() * Vector3D.Cross(Plane.AxisZ, vector3D)));
			LinearDim linearDim = new LinearDim(new Plane(point3D, vector3D, Vector3D.Cross(Plane.AxisZ, vector3D)), point3D, point3D2, dimLinePos2, _0023_003DzsZ0wpSaTNKImuJfQ1A_003D_003D());
			linearDim.WidthFactor = DimensionsWidthFactor;
			ConcentricCirclesDistanceVisualConstraint result = new ConcentricCirclesDistanceVisualConstraint(_0023_003Dz4lwYpErPR_sa(), linearDim, concentricCirclesDistanceConstraint);
			_0023_003DzUQJXD50_003D(concentricCirclesDistanceConstraint, linearDim);
			return result;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976515));
	}

	public PointOnVisualConstraint AddConstraintPointOn(Point point, Entity entity)
	{
		PointOnConstraint pointOnConstraint = Sketch.AddConstraintPointOn((SketchPoint)point._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), (SketchCurve)entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D());
		IStackedLabel stackedLabel = _0023_003DzLuIkz4x3FVHS().Create(labelType.PointOn, (SketchPoint)point._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), pointOnConstraint);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel);
		return new PointOnVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[1] { stackedLabel }, pointOnConstraint);
	}

	public PointAtVisualConstraint AddConstraintPointAt(Point point, Entity entity, double value)
	{
		PointAtConstraint pointAtConstraint = Sketch.AddConstraintPointAt((SketchPoint)point._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), (SketchCurve)entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), value);
		IStackedLabel stackedLabel = _0023_003DzLuIkz4x3FVHS().Create(labelType.PointAt, (SketchPoint)point._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), pointAtConstraint);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel);
		return new PointAtVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[1] { stackedLabel }, pointAtConstraint);
	}

	public MidPointVisualConstraint AddConstraintMidPoint(Point point, Entity entity)
	{
		MidPointConstraint midPointConstraint = Sketch.AddConstraintMidPoint((SketchPoint)point._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), (SketchCurve)entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D());
		IStackedLabel stackedLabel = _0023_003DzLuIkz4x3FVHS().Create(labelType.MidPoint, (SketchPoint)point._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D(), midPointConstraint);
		_0023_003Dz4lwYpErPR_sa().AddLabel(stackedLabel);
		return new MidPointVisualConstraint(_0023_003Dz4lwYpErPR_sa(), new IStackedLabel[1] { stackedLabel }, midPointConstraint);
	}

	private void _0023_003Dz3etDJxTITZMUBmhHLQ_003D_003D(solveFailureType _0023_003DzOLHnb2M_003D)
	{
		this.SystemSolved?.Invoke(this, new SolveEventArgs(_0023_003DzOLHnb2M_003D, Dragging));
	}

	private void _0023_003DzA_002467er20sv9PpT_sPbnAeAA_003D(SketchEntity _0023_003Dzc8A2LAnL4SBs5UBu4A_003D_003D, ICurve _0023_003DzjrQZL7M2AsTQMA7P7Q_003D_003D)
	{
		this.SketchCurveLinked?.Invoke(this, new SketchCurveLinkedEventArgs(_0023_003Dzc8A2LAnL4SBs5UBu4A_003D_003D, _0023_003DzjrQZL7M2AsTQMA7P7Q_003D_003D));
	}

	private void _0023_003Dz9bTNAMXQoAjCHo_0024wAhHwr6g_003D(SketchEntity _0023_003Dzc8A2LAnL4SBs5UBu4A_003D_003D, ICurve _0023_003DzUPJpOYyE_2HitOaAgg_003D_003D)
	{
		this.SketchCurveDeleted?.Invoke(this, new SketchCurveDeletedEventArgs(_0023_003Dzc8A2LAnL4SBs5UBu4A_003D_003D, _0023_003DzUPJpOYyE_2HitOaAgg_003D_003D));
	}

	public Line[] AddPolygon(Point2D center, double radius, int numOfVertices, out Point polygonCenter, out Point firstPolygonVertex, double angle = 0.0)
	{
		PolygonConstraint constraint;
		SketchLine[] array = Sketch.AddPolygon(center, numOfVertices, radius, angle, out constraint);
		Line[] array2 = new Line[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			SketchLine sketchLine = array[i];
			array2[i] = new Line(Plane, sketchLine.StartPoint.PlanePosition, sketchLine.EndPoint.PlanePosition);
			_0023_003DzZEJDfL4_003D(sketchLine, array2[i]);
		}
		firstPolygonVertex = StartPoint(array2[0]);
		polygonCenter = _0023_003Dz8ilmF8wT2E63PguzhA_003D_003D(constraint.Center);
		_0023_003DzIrs5MDJ5nmrc(constraint, _design.Entities);
		return array2;
	}

	public void AddEntities(IList<Entity> entities, bool fix = true)
	{
		if (!Editing)
		{
			return;
		}
		foreach (Entity entity in entities)
		{
			if (entity is ICurve curve && curve.IsInPlane(Plane.XY, Utility._0023_003DzxhnLabVjXjPg))
			{
				if (curve is CompositeCurve compositeCurve)
				{
					AddEntities(compositeCurve.Explode());
				}
				else
				{
					_0023_003DzJY2NMdI_003D(curve, fix);
				}
			}
			else if (entity is Region region && Vector3D.AreParallel(region.Plane.AxisZ, Vector3D.AxisZ))
			{
				AddEntities(region.ContourList.Cast<Entity>().ToList(), fix);
			}
		}
	}

	public bool IsValid(Constraint constraint)
	{
		return Sketch.IsValid(constraint);
	}

	public static SketchItem GetSketchItem(Entity entity)
	{
		return entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D();
	}

	public bool Trim(System.Drawing.Point mousePos)
	{
		List<Entity> _0023_003DzijSR7_0024YYLNcm = new List<Entity>();
		List<Entity> _0023_003DzcM_Q3U04H3Bt = new List<Entity>();
		return new _0023_003Dz_p2RXz7Ce_dbmSFJ520GhUDSB4eGuCW_0024cBERiyU_003D(_design, this)._0023_003Dz6PsRlFc_003D(mousePos, _0023_003DzijSR7_0024YYLNcm, _0023_003DzcM_Q3U04H3Bt);
	}

	public bool TrimPreview(System.Drawing.Point mousePos, out List<Entity> previewEntities)
	{
		List<Entity> _0023_003DzijSR7_0024YYLNcm = new List<Entity>();
		previewEntities = new List<Entity>();
		return new _0023_003Dz_p2RXz7Ce_dbmSFJ520GhUDSB4eGuCW_0024cBERiyU_003D(_design, this, _0023_003DzqNH2rCw_003D: true)._0023_003Dz6PsRlFc_003D(mousePos, _0023_003DzijSR7_0024YYLNcm, previewEntities);
	}

	internal void _0023_003DzVnfAoovaoMa7(Dimension _0023_003DzmTIZ8Fc_003D, ValueConstraint _0023_003Dz5cy3qZ0_003D)
	{
		_0023_003DzmTIZ8Fc_003D.ColorMethod = colorMethodType.byEntity;
		_0023_003DzmTIZ8Fc_003D.Color = (_0023_003Dz5cy3qZ0_003D.Reference ? Params.DimensionsReferenceColor : Params.DimensionsColor);
		_0023_003DzmTIZ8Fc_003D.LineWeightMethod = colorMethodType.byEntity;
		_0023_003DzmTIZ8Fc_003D.LineWeight = Params.DimensionsThickness;
	}

	internal void _0023_003DzVnfAoovaoMa7(Entity _0023_003Dz9j7EUB0_003D, SketchCurve _0023_003DzIpCXIf1GmttHQRSf8w_003D_003D)
	{
		if (_0023_003Dz9j7EUB0_003D is Dimension)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976742));
		}
		if (_0023_003Dz9j7EUB0_003D is Point point)
		{
			point.ColorMethod = colorMethodType.byEntity;
			point.Color = Params.PointsColor;
			point.LineWeightMethod = colorMethodType.byEntity;
			point.LineWeight = Params.PointsThickness;
		}
		else if (_0023_003DzIpCXIf1GmttHQRSf8w_003D_003D.Construction)
		{
			_0023_003Dz9j7EUB0_003D.ColorMethod = colorMethodType.byEntity;
			_0023_003Dz9j7EUB0_003D.Color = Params.ConstructionCurvesColor;
			_0023_003Dz9j7EUB0_003D.LineWeightMethod = colorMethodType.byEntity;
			_0023_003Dz9j7EUB0_003D.LineWeight = Params.ConstructionCurvesThickness;
		}
		else
		{
			_0023_003Dz9j7EUB0_003D.ColorMethod = colorMethodType.byEntity;
			_0023_003Dz9j7EUB0_003D.Color = Params.CurvesColor;
			_0023_003Dz9j7EUB0_003D.LineWeightMethod = colorMethodType.byEntity;
			_0023_003Dz9j7EUB0_003D.LineWeight = Params.CurvesThickness;
		}
	}

	internal Constraint[] _0023_003Dz1cTWX1fK2A6e()
	{
		return Sketch.Constraints;
	}

	public override void TransformBy(Transformation xform)
	{
		Plane plane = (Plane)Plane.Clone();
		plane.TransformBy(xform);
		Plane = plane;
		foreach (ValueConstraint item in Sketch.Constraints.OfType<ValueConstraint>())
		{
			item.DimPos?.TransformBy(xform);
		}
		regenMode = regenType.RegenAndCompile;
	}

	[IteratorStateMachine(typeof(_0023_003DzExLW_3IqD8Ohw3ITomFksDVQbux_0024))]
	private IEnumerable<Point3D> _0023_003Dzl_0024lyqCZ6KbxA0BkRiw_003D_003D()
	{
		return new _0023_003DzExLW_3IqD8Ohw3ITomFksDVQbux_0024(-2)
		{
			_0023_003DzopRx0_MBcTQs = this
		};
	}

	protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		return Entity.ComputeBoundingBox(data, _0023_003Dzl_0024lyqCZ6KbxA0BkRiw_003D_003D().ToArray(), out boxMin, out boxMax);
	}

	protected internal override bool GetAllVertices(TraversalParams data, out IList<float> verticesCoords)
	{
		List<float> list = new List<float>();
		foreach (Point3D item in _0023_003Dzl_0024lyqCZ6KbxA0BkRiw_003D_003D())
		{
			list.Add((float)item.X);
			list.Add((float)item.Y);
			list.Add((float)item.Z);
		}
		verticesCoords = list;
		return true;
	}

	protected internal override bool AllVerticesInScreenPolygon(ScreenPolygonParams data)
	{
		Point3D[] array = _0023_003Dzl_0024lyqCZ6KbxA0BkRiw_003D_003D().ToArray();
		if (Utility.AllVerticesInScreenPolygon(data, array, array.Length))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override bool AllVerticesInFrustum(FrustumParams data)
	{
		Point3D[] array = _0023_003Dzl_0024lyqCZ6KbxA0BkRiw_003D_003D().ToArray();
		if (Utility.AllVerticesInFrustum(data, array, array.Length))
		{
			AddSelectedItemLeaf(data);
			return true;
		}
		return false;
	}

	protected internal override void ComputeOffsetOnCameraAxes(OffsetOnCameraAxesParams data)
	{
		Point3D[] array = _0023_003Dzl_0024lyqCZ6KbxA0BkRiw_003D_003D().ToArray();
		Entity.ComputeOffsetOnCameraAxes(data, array, array.Length);
	}

	public override void Regen(RegenParams data)
	{
		List<ICurve> list = new List<ICurve>();
		if (Sketch.Solve() != solveFailureType.Success)
		{
			throw new InvalidSketchException();
		}
		foreach (SketchCurve curve in Sketch.CurveList)
		{
			if (curve._0023_003DzZ_ilKakl9sw5() == null)
			{
				curve._0023_003DzTVQeh_2_2lC7((Entity)curve._0023_003DzxXXV_0024fQ_003D());
			}
			else
			{
				curve._0023_003DzjdvuhXvcm_002426();
			}
			list.Add((ICurve)curve._0023_003DzZ_ilKakl9sw5());
		}
		_curveList = list;
		foreach (Entity curve2 in _curveList)
		{
			if (data != null)
			{
				curve2.Regen(data);
			}
		}
		UpdateBoundingBox(data);
		RegenMode = regenType.CompileOnly;
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		_0023_003DzSrny2FmSPIa7();
		data.RenderContext.Compile(drawData, DrawEntity, null);
		CompilePattern(data);
		foreach (Entity curve in _curveList)
		{
			curve.Compile(data);
		}
		RegenMode = regenType.NotNeeded;
	}

	public override void Dispose()
	{
		if (_curveList != null)
		{
			foreach (Entity curve in _curveList)
			{
				curve.Dispose();
			}
		}
		base.Dispose();
	}

	protected override void CompilePattern(CompileParams data)
	{
		if (!data._0023_003Dz_5uhDE0_003D)
		{
			data.RenderContext.Compile(drawPattern, DrawWithPattern, data);
		}
	}

	protected override void DrawWithPattern(RenderContextBase renderContext, object myParams)
	{
		CompileParams compileParams = (CompileParams)myParams;
		LineType lineType = new LineType(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976678), Params.ConstructionCurvesPattern);
		foreach (Entity curve in CurveList)
		{
			if (((SketchCurve)curve._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Construction)
			{
				lineType.GetPatternVertices(compileParams.MaxPatternRepetitions, curve._vertices, LineTypeScale * compileParams.LineTypeScale, out var lines, out var points);
				compileParams.RenderContext.DrawLinesAndPoints(lines.ToArray(), points.ToArray());
			}
		}
	}

	private protected override void _0023_003DzcbxI7LvTjkOHwnPzLg_003D_003D(DrawParams _0023_003DzELu0Pss_003D, LineType _0023_003DzhC3Yby0_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		foreach (Entity curve in CurveList)
		{
			if (((SketchCurve)curve._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Construction)
			{
				base._0023_003DzcbxI7LvTjkOHwnPzLg_003D_003D(_0023_003DzELu0Pss_003D, _0023_003DzhC3Yby0_003D, curve._vertices);
			}
		}
	}

	protected internal override void Draw(DrawParams data)
	{
		if (((IDesign)data.viewportInternal.parent).CurrentSketch == null || !Editing)
		{
			if (data.RenderContext.IsDirect3D)
			{
				_0023_003DzzyvCIP8S_0024z4yFXk682ACf2I_003D(data);
				_0023_003Dz08cQgeJqEzrlywG4JQ_003D_003D(data);
				_0023_003DzEQtqVySXR3hRmRPfilYoRZY_003D(data);
			}
			else
			{
				_0023_003Dz08cQgeJqEzrlywG4JQ_003D_003D(data);
			}
		}
	}

	private void _0023_003DzxKRH4c45wPWdiHwMJQ_003D_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		if (!_0023_003DzELu0Pss_003D.ForceGray && !_0023_003DzELu0Pss_003D.ParentSelected && _0023_003DzELu0Pss_003D.Selected && SelectionMode != selectionFilterType.Entity)
		{
			if (_0023_003DzELu0Pss_003D.RenderContext.IsDirect3D)
			{
				_0023_003DzzyvCIP8S_0024z4yFXk682ACf2I_003D(_0023_003DzELu0Pss_003D);
				_0023_003Dz_MW2cf0Fc69YufmPVJVuGyA_003D(_0023_003DzELu0Pss_003D);
				_0023_003DzUDjj1U_00248AVp1yJUqBLoxJXVgnV5u(_0023_003DzELu0Pss_003D);
				_0023_003DzEQtqVySXR3hRmRPfilYoRZY_003D(_0023_003DzELu0Pss_003D);
			}
			else
			{
				_0023_003DzUDjj1U_00248AVp1yJUqBLoxJXVgnV5u(_0023_003DzELu0Pss_003D);
				_0023_003Dz_MW2cf0Fc69YufmPVJVuGyA_003D(_0023_003DzELu0Pss_003D);
			}
		}
		else
		{
			Draw(_0023_003DzELu0Pss_003D);
		}
	}

	protected internal override void DrawSelected(DrawParams data)
	{
		_0023_003DzxKRH4c45wPWdiHwMJQ_003D_003D(data);
	}

	protected internal override void DrawHiddenLines(DrawParams data)
	{
		_0023_003DzxKRH4c45wPWdiHwMJQ_003D_003D(data);
	}

	protected internal override void DrawWireframe(DrawParams data)
	{
		_0023_003DzxKRH4c45wPWdiHwMJQ_003D_003D(data);
	}

	internal void _0023_003DzzyvCIP8S_0024z4yFXk682ACf2I_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		_0023_003DzELu0Pss_003D.RenderContext.PushShader();
		_0023_003DzELu0Pss_003D.RenderContext.EnableThickLines();
	}

	internal void _0023_003DzEQtqVySXR3hRmRPfilYoRZY_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		_0023_003DzELu0Pss_003D.RenderContext.PopShader();
	}

	private void _0023_003Dz08cQgeJqEzrlywG4JQ_003D_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		float currentLineWidth = _0023_003DzELu0Pss_003D.RenderContext.CurrentLineWidth;
		float currentPointSize = _0023_003DzELu0Pss_003D.RenderContext.CurrentPointSize;
		float size = ratioPointsSize * currentLineWidth;
		float size2 = ratioCurvesSize * currentLineWidth;
		float size3 = currentLineWidth;
		_0023_003DzELu0Pss_003D.RenderContext.SetPointSize(size, setShader: false);
		_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(size2);
		base.Draw(_0023_003DzELu0Pss_003D);
		_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(size3);
		if (!_0023_003DzVmP7M1MzcRAi(_0023_003DzELu0Pss_003D, new LineType(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976678), Params.ConstructionCurvesPattern)))
		{
			foreach (Entity curve in CurveList)
			{
				if (((SketchCurve)curve._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Construction)
				{
					_0023_003DzELu0Pss_003D.RenderContext.DrawLineStrip(curve.Vertices);
				}
			}
		}
		_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(currentLineWidth);
		_0023_003DzELu0Pss_003D.RenderContext.SetPointSize(currentPointSize, setShader: false);
	}

	private void _0023_003Dz_MW2cf0Fc69YufmPVJVuGyA_003D(DrawParams _0023_003DzELu0Pss_003D)
	{
		SelectionInfoSubItems selectionInfoSubItems = SelectionInfoItemBase.FindInstance(_0023_003DzELu0Pss_003D.Parents, this, null, SketchCurvesSelectionInfo);
		float currentLineWidth = _0023_003DzELu0Pss_003D.RenderContext.CurrentLineWidth;
		float currentPointSize = _0023_003DzELu0Pss_003D.RenderContext.CurrentPointSize;
		List<Point3D> list = new List<Point3D>();
		List<Point3D> list2 = new List<Point3D>();
		for (int i = 0; i < _curveList.Count; i++)
		{
			if (_curveList[i] is Point point)
			{
				if (selectionInfoSubItems != null && selectionInfoSubItems.SubItems[i].IsFlagSet(_0023_003DzELu0Pss_003D.SelectionStatus))
				{
					list2.Add(point.Position);
				}
				else if (_0023_003DzELu0Pss_003D.SelectionStatus != selectionStatusType.Temporary && !_0023_003DzELu0Pss_003D.IsDrawingForHalo)
				{
					list.Add(point.Position);
				}
			}
		}
		float num = ratioPointsSize * currentLineWidth;
		_0023_003DzELu0Pss_003D.RenderContext.SetPointSize(_0023_003DzELu0Pss_003D.LineWeightFactor * num);
		_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(_0023_003DzELu0Pss_003D.IsDrawingForHalo ? RenderContextBase.selectionWithoutHaloColor : _0023_003DzELu0Pss_003D.WireSelectionColor);
		_0023_003DzELu0Pss_003D.RenderContext.DrawPoints(list2.ToArray());
		_0023_003DzELu0Pss_003D.RenderContext.SetPointSize(num, setShader: false);
		_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(_0023_003DzELu0Pss_003D.InsideColor);
		_0023_003DzELu0Pss_003D.RenderContext.DrawPoints(list.ToArray());
		_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(currentLineWidth);
		_0023_003DzELu0Pss_003D.RenderContext.SetPointSize(currentPointSize, setShader: false);
	}

	private void _0023_003DzUDjj1U_00248AVp1yJUqBLoxJXVgnV5u(DrawParams _0023_003DzELu0Pss_003D)
	{
		SelectionInfoSubItems selectionInfoSubItems = SelectionInfoItemBase.FindInstance(_0023_003DzELu0Pss_003D.Parents, this, null, SketchCurvesSelectionInfo);
		bool flag = !_0023_003DzELu0Pss_003D.Direct3D && _0023_003DzELu0Pss_003D.Selected;
		float currentLineWidth = _0023_003DzELu0Pss_003D.RenderContext.CurrentLineWidth;
		float currentPointSize = _0023_003DzELu0Pss_003D.RenderContext.CurrentPointSize;
		LineType lineType = new LineType(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976678), Params.ConstructionCurvesPattern);
		for (int i = 0; i < _curveList.Count; i++)
		{
			Entity entity = (Entity)_curveList[i];
			if (entity is Point)
			{
				continue;
			}
			float num = ratioCurvesSize * currentLineWidth;
			float num2 = currentLineWidth;
			bool flag2 = selectionInfoSubItems?.SubItems[i].IsFlagSet(_0023_003DzELu0Pss_003D.SelectionStatus) ?? false;
			if (flag2)
			{
				if (!flag)
				{
					_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(_0023_003DzELu0Pss_003D.IsDrawingForHalo ? RenderContextBase.selectionWithoutHaloColor : _0023_003DzELu0Pss_003D.WireSelectionColor);
					flag = true;
				}
			}
			else
			{
				if (_0023_003DzELu0Pss_003D.SelectionStatus == selectionStatusType.Temporary || _0023_003DzELu0Pss_003D.IsDrawingForHalo)
				{
					continue;
				}
				if (flag)
				{
					_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(_0023_003DzELu0Pss_003D.InsideColor);
					flag = false;
				}
			}
			if (((SketchCurve)entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Construction)
			{
				_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(flag2 ? (num2 * _0023_003DzELu0Pss_003D.LineWeightFactor) : num2);
				lineType.GetPatternVertices(_0023_003DzELu0Pss_003D.MaxPatternRepetitions, entity.Vertices, LineTypeScale * _0023_003DzELu0Pss_003D.LineTypeScale, out var lines, out var points, _0023_003DzELu0Pss_003D.Transformation);
				_0023_003DzELu0Pss_003D.RenderContext.DrawLinesAndPoints(lines.ToArray(), points.ToArray());
			}
			else
			{
				_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(flag2 ? (num * _0023_003DzELu0Pss_003D.LineWeightFactor) : num);
				_0023_003DzELu0Pss_003D.RenderContext.DrawLineStrip(entity.Vertices);
			}
		}
		_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(currentLineWidth);
		_0023_003DzELu0Pss_003D.RenderContext.SetPointSize(currentPointSize, setShader: false);
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i < _curveList.Count; i++)
		{
			Entity entity = (Entity)_curveList[i];
			if (entity is Point point)
			{
				list.Add(point.Position);
			}
			else if (!((SketchCurve)entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Construction)
			{
				context.DrawLineStrip(entity.Vertices);
			}
		}
		context.DrawPoints(list.ToArray());
	}

	protected internal override void DrawDirection(DrawParams data)
	{
		SelectionInfoSubItems selectionInfoSubItems = SelectionInfoItemBase.FindInstance(data.Parents, this, null, SketchCurvesSelectionInfo);
		bool flag = data.Selected;
		float currentLineWidth = data.RenderContext.CurrentLineWidth;
		float currentPointSize = data.RenderContext.CurrentPointSize;
		if (selectionInfoSubItems != null)
		{
			for (int i = 0; i < _curveList.Count; i++)
			{
				Entity entity = _curveList[i] as Entity;
				float num = ratioCurvesSize * currentLineWidth;
				float num2 = num;
				bool flag2 = selectionInfoSubItems?.SubItems[i].IsFlagSet(data.SelectionStatus) ?? false;
				if (flag2)
				{
					if (!flag)
					{
						data.RenderContext.SetColorWireframe(data.WireSelectionColor);
						flag = true;
					}
				}
				else
				{
					if (data.SelectionStatus == selectionStatusType.Temporary || data.IsDrawingForHalo)
					{
						continue;
					}
					if (flag)
					{
						data.RenderContext.SetColorWireframe(data.InsideColor);
						flag = false;
					}
				}
				if (((SketchCurve)entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Construction)
				{
					data.RenderContext.SetLineSize(flag2 ? (num2 * data.LineWeightFactor) : num2);
				}
				else
				{
					data.RenderContext.SetLineSize(flag2 ? (num * data.LineWeightFactor) : num);
				}
				entity.DrawDirection(data);
			}
			data.RenderContext.SetLineSize(currentLineWidth);
			data.RenderContext.SetPointSize(currentPointSize, setShader: false);
			return;
		}
		foreach (Entity curve in _curveList)
		{
			curve.DrawDirection(data);
		}
	}

	public override object Clone()
	{
		return new SketchEntity(this);
	}

	public override object CloneWithTessellation()
	{
		return new SketchEntity(this, RegenMode != regenType.RegenAndCompile);
	}

	public Entity[] Explode(bool propagateAttributes = true)
	{
		Entity[] array = new Entity[_curveList.Count];
		for (int i = 0; i < _curveList.Count; i++)
		{
			array[i] = (Entity)_curveList[i].Clone();
			if (propagateAttributes)
			{
				Entity.PropagateAttributes(this, array[i], force: true);
			}
		}
		return array;
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (_curveList != null)
		{
			return _curveList.All((ICurve _0023_003Dzt_m8zV0_003D) => ((Entity)_0023_003Dzt_m8zV0_003D)._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D());
		}
		return false;
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new SketchEntitySurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976829), Sketch);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976812), CurveList);
	}

	void IDeserializationCallback.OnDeserialization(object sender)
	{
		List<SketchCurve> curveList = Sketch.CurveList;
		for (int i = 0; i < _curveList.Count; i++)
		{
			ICurve curve = _curveList[i];
			curveList[i]._0023_003DzTVQeh_2_2lC7((Entity)curve);
		}
	}

	internal override bool AvoidSmallSizeCulling()
	{
		if (_curveList.Count == 1)
		{
			return ((Entity)_curveList[0]).AvoidSmallSizeCulling();
		}
		return false;
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		Draw(data);
	}

	protected internal override void DrawForSelectionSketchPoints(DrawForSelectionParams data)
	{
		for (int i = 0; i < _curveList.Count; i++)
		{
			if (_curveList[i] is Point point)
			{
				data.viewportInternal.parent.SetColorDrawForSelectionAndUpdateIdItemsMap<SelectedSketchCurve>(data, this, i);
				point.Draw(data);
				data.FalseColorIndex++;
			}
		}
	}

	protected internal override void DrawForSelectionSketchCurves(DrawForSelectionParams data)
	{
		if (data.RenderContext.IsDirect3D)
		{
			_0023_003DzzyvCIP8S_0024z4yFXk682ACf2I_003D(data);
			_0023_003DzrCbKJ_khqaMVjFZp7vO951oNmSIn(data);
			_0023_003DzEQtqVySXR3hRmRPfilYoRZY_003D(data);
		}
		else
		{
			_0023_003DzrCbKJ_khqaMVjFZp7vO951oNmSIn(data);
		}
	}

	private void _0023_003DzrCbKJ_khqaMVjFZp7vO951oNmSIn(DrawForSelectionParams _0023_003DzELu0Pss_003D)
	{
		for (int i = 0; i < _curveList.Count; i++)
		{
			Entity entity = (Entity)_curveList[i];
			if (!(entity is Point))
			{
				_0023_003DzELu0Pss_003D.viewportInternal.parent.SetColorDrawForSelectionAndUpdateIdItemsMap<SelectedSketchCurve>(_0023_003DzELu0Pss_003D, this, i);
				entity.Draw(_0023_003DzELu0Pss_003D);
				_0023_003DzELu0Pss_003D.FalseColorIndex++;
			}
		}
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		LineType lineType = new LineType(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976678), Params.ConstructionCurvesPattern);
		for (int i = 0; i < _curveList.Count; i++)
		{
			Entity entity = (Entity)_curveList[i];
			if (((SketchCurve)entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Construction)
			{
				lineType.GetPatternVertices(data.MaxPatternRepetitions, entity.Vertices, LineTypeScale * data.Document.LineTypeScale, out var lines, out var points);
				if (Entity.InsideOrCrossingFrustumInternal(data.Frustum, data.Transformation, lines, lines.Count, 2) || Entity.InsideFrustumPoint(data.Frustum, data.Transformation, points, points.Count))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
				return false;
			}
			if (entity.InsideOrCrossingFrustum(data))
			{
				AddSelectedItemLeaf(data);
				return true;
			}
		}
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		LineType lineType = new LineType(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976678), Params.ConstructionCurvesPattern);
		for (int i = 0; i < _curveList.Count; i++)
		{
			Entity entity = (Entity)_curveList[i];
			if (((SketchCurve)entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D()).Construction)
			{
				lineType.GetPatternVertices(data.MaxPatternRepetitions, entity.Vertices, LineTypeScale * data.Document.LineTypeScale, out var lines, out var points);
				if (Entity.InsideOrCrossingScreenPolygonInternal(data, lines, lines.Count, 2) || Entity.InsideOrCrossingScreenPolygonPoint(data, points, points.Count))
				{
					AddSelectedItemLeaf(data);
					return true;
				}
				return false;
			}
			if (entity.InsideOrCrossingScreenPolygon(data))
			{
				AddSelectedItemLeaf(data);
				return true;
			}
		}
		return false;
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		List<Point3D> list = new List<Point3D>(_curveList.Count);
		foreach (Entity curve in _curveList)
		{
			list.AddRange(curve.EstimateBoundingBox(blocks, layers));
		}
		return list.ToArray();
	}

	protected internal override void DrawVertices(DrawParams data)
	{
		Point3D[] array = (from _0023_003DzB68dg9Q_003D in CurveList.OfType<Point>()
			select _0023_003DzB68dg9Q_003D.Position).ToArray();
		_0023_003DzfytGakPJH0VOucX17g_003D_003D(data.RenderContext, array, array.Length);
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnitsType.Unitless, (LayerKeyedCollection)null, (MaterialKeyedCollection)null, (BlockKeyedCollection)null));
		int num = _curveList.OfType<Point>().Count();
		int num2 = _curveList.Cast<Entity>().Count(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzIR3kPLbE_vMotXgmpJaZAUE_003D);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963345) + (_curveList.Count - num) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302934389) + num2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976669));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302969090) + num);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977397) + _0023_003Dz1cTWX1fK2A6e().Length);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977366) + Sketch.DOF);
		return stringBuilder.ToString();
	}

	public Region ConvertToRegion()
	{
		return Sketch.ConvertToRegions()[0];
	}

	public Region[] ConvertToRegions()
	{
		return Sketch.ConvertToRegions();
	}

	public ICurve[] ConvertToCurves(bool keepConstructionCurves)
	{
		SketchCurve[] curveSketch;
		return Sketch.ConvertToCurves(keepConstructionCurves, out curveSketch);
	}

	internal void _0023_003DzIRszeCqB4yN_0024(bool _0023_003Dzmyw8uNw_003D, bool _0023_003DzGoRYjXRnodfbarym0Q_003D_003D)
	{
		Sketch._0023_003Dz1X_Sri5ODnnm6MmfXQ_003D_003D(_0023_003DzcAtPIuFLCyhPxLQTtQ_003D_003D: true, _0023_003DzIz4u_00246wI5Q9M: true, out var _0023_003DzpIZC_0024x5EiUBN, out var _0023_003DzGs_n0KbO_6uxyZjG2Q_003D_003D, _0023_003Dzmyw8uNw_003D);
		if (_0023_003DzGoRYjXRnodfbarym0Q_003D_003D)
		{
			_curveList = _0023_003DzWU_1ROfYiGJ4G_00241UzQ_003D_003D(_0023_003DzpIZC_0024x5EiUBN, _0023_003DzGs_n0KbO_6uxyZjG2Q_003D_003D);
		}
		else
		{
			_curveList = new List<ICurve>();
		}
	}

	private List<ICurve> _0023_003DzWU_1ROfYiGJ4G_00241UzQ_003D_003D(ICurve[] _0023_003DzTj1oJWREOpXS, SketchCurve[] _0023_003Dzjym4ZBECBkcu7SKyTg_003D_003D)
	{
		if (_0023_003DzTj1oJWREOpXS == null)
		{
			return null;
		}
		List<ICurve> list = new List<ICurve>(_0023_003DzTj1oJWREOpXS.Length);
		for (int i = 0; i < _0023_003DzTj1oJWREOpXS.Length; i++)
		{
			SketchCurve sketchCurve = _0023_003Dzjym4ZBECBkcu7SKyTg_003D_003D[i];
			ICurve curve = _0023_003DzTj1oJWREOpXS[i];
			_0023_003DzVnfAoovaoMa7((Entity)curve, sketchCurve);
			sketchCurve._0023_003DzTVQeh_2_2lC7((Entity)curve);
			list.Add(curve);
		}
		return list;
	}

	public void Read(string filePath)
	{
		Sketch.Read(filePath);
		_0023_003DzIRszeCqB4yN_0024(_0023_003Dzmyw8uNw_003D: true, _0023_003DzGoRYjXRnodfbarym0Q_003D_003D: true);
		RegenMode = regenType.RegenAndCompile;
	}

	public void Write(string filePath, Formatting formatting = Formatting.Indented)
	{
		Sketch.Write(filePath, formatting);
	}

	public override Mesh ExtrudeAsMesh(double amount, double deviation, Mesh.natureType meshNature)
	{
		return Sketch.ExtrudeAsMesh(amount, deviation, meshNature);
	}

	public new T ExtrudeAsMesh<T>(double amount, double deviation, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return Sketch.ExtrudeAsMesh<T>(amount, deviation, meshNature);
	}

	public Mesh ExtrudeAsMesh(Vector3D amount, double deviation, double angle, Mesh.natureType meshNature)
	{
		return Sketch.ExtrudeAsMesh(amount, deviation, angle, meshNature);
	}

	public Mesh ExtrudeAsMesh(Vector3D amount, double deviation, Mesh.natureType meshNature)
	{
		return Sketch.ExtrudeAsMesh(amount, deviation, Math.PI / 6.0, meshNature);
	}

	public Mesh ExtrudeAsMesh(Interval amount, double deviation, double angle, Mesh.natureType meshNature)
	{
		return Sketch.ExtrudeAsMesh(amount, deviation, angle, meshNature);
	}

	public Mesh ExtrudeAsMesh(Interval amount, double deviation, Mesh.natureType meshNature)
	{
		return Sketch.ExtrudeAsMesh(amount, deviation, Math.PI / 6.0, meshNature);
	}

	public T ExtrudeAsMesh<T>(Vector3D amount, double deviation, double angle, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return Sketch.ExtrudeAsMesh<T>(amount, deviation, angle, meshNature);
	}

	public Surface[] ExtrudeAsSurface(Vector3D amount)
	{
		return Sketch.ExtrudeAsSurface(amount);
	}

	public new Surface[] ExtrudeAsSurface(double amount)
	{
		return Sketch.ExtrudeAsSurface(amount * Plane.AxisZ);
	}

	public Surface[] ExtrudeAsSurface(Vector3D amount, double draftAngleInRadians, double tolerance)
	{
		return Sketch.ExtrudeAsSurface(amount, draftAngleInRadians, tolerance);
	}

	public Surface[] ExtrudeAsSurface(double amount, double draftAngleInRadians, double tolerance)
	{
		return Sketch.ExtrudeAsSurface(Plane.AxisZ * amount, draftAngleInRadians, tolerance);
	}

	public Brep[] ExtrudeAsBrep(double amount, double angleInRadians = 0.0, double tolerance = 0.0)
	{
		return Sketch.ExtrudeAsBrep(amount, angleInRadians, tolerance);
	}

	public Brep[] ExtrudeAsBrep(Interval amount, double angleInRadians = 0.0, double tolerance = 0.0)
	{
		return Sketch.ExtrudeAsBrep(amount, angleInRadians, tolerance);
	}

	public Brep[] ExtrudeAsBrep(Vector3D amount, double angleInRadians = 0.0, double tolerance = 0.0)
	{
		return Sketch.ExtrudeAsBrep(amount, angleInRadians, tolerance);
	}

	public Solid ExtrudeAsSolid(double x, double y, double z, double tolerance)
	{
		return Sketch.ExtrudeAsSolid(x, y, z, tolerance);
	}

	public T ExtrudeAsSolid<T>(double x, double y, double z, double tolerance) where T : Solid, new()
	{
		return Sketch.ExtrudeAsSolid<T>(new Vector3D(x, y, z), tolerance);
	}

	public new Solid ExtrudeAsSolid(double amount, double tolerance)
	{
		return Sketch.ExtrudeAsSolid(amount, tolerance);
	}

	public new T ExtrudeAsSolid<T>(double amount, double tolerance) where T : Solid, new()
	{
		return Sketch.ExtrudeAsSolid<T>(amount, tolerance);
	}

	public Solid ExtrudeAsSolid(Vector3D amount, double tolerance)
	{
		return Sketch.ExtrudeAsSolid(amount, tolerance);
	}

	public T ExtrudeAsSolid<T>(Vector3D amount, double tolerance) where T : Solid, new()
	{
		return Sketch.ExtrudeAsSolid<T>(amount, tolerance);
	}

	public Mesh RevolveAsMesh(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature)
	{
		return Sketch.RevolveAsMesh(startAngle, deltaAngle, axisStart, axisEnd, slices, tolerance, meshNature);
	}

	public T RevolveAsMesh<T>(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return Sketch.RevolveAsMesh<T>(startAngle, deltaAngle, axisStart, axisEnd, slices, tolerance, meshNature);
	}

	public Mesh RevolveAsMesh(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature)
	{
		return Sketch.RevolveAsMesh(startAngle, deltaAngle, axis, center, slices, tolerance, meshNature);
	}

	public T RevolveAsMesh<T>(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new()
	{
		return Sketch.RevolveAsMesh<T>(startAngle, deltaAngle, axis, center, slices, tolerance, meshNature);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		return Sketch.RevolveAsSurface(startAngle, deltaAngle, axis, center);
	}

	public Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd)
	{
		return Sketch.RevolveAsSurface(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart);
	}

	public Brep[] RevolveAsBrep(double startAngle, double deltaAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		return Sketch.RevolveAsBrep(startAngle, deltaAngle, axis, center, tolerance);
	}

	public Brep[] RevolveAsBrep(double deltaAngle, Vector3D axis, Point3D center, double tolerance = 0.0)
	{
		return Sketch.RevolveAsBrep(deltaAngle, axis, center, tolerance);
	}

	public Brep[] RevolveAsBrep(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0)
	{
		return Sketch.RevolveAsBrep(startAngle, deltaAngle, axisStart, axisEnd, tolerance);
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance)
	{
		return Sketch.RevolveAsSolid<Solid>(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public T RevolveAsSolid<T>(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance) where T : Solid, new()
	{
		return RevolveAsSolid<T>(startAngle, deltaAngle, Vector3D.Subtract(axisEnd, axisStart), axisStart, slices, tolerance);
	}

	public Solid RevolveAsSolid(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance)
	{
		return Sketch.RevolveAsSolid(startAngle, deltaAngle, axis, center, slices, tolerance);
	}

	public T RevolveAsSolid<T>(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance) where T : Solid, new()
	{
		return Sketch.RevolveAsSolid<T>(startAngle, deltaAngle, axis, center, slices, tolerance);
	}

	public Surface[] SweepAsSurface(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		return Sketch.SweepAsSurface(rail, tol, methodType);
	}

	public Brep[] SweepAsBrep(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		return Sketch.SweepAsBrep(rail, tol, methodType);
	}

	public Brep[] SweepAsBrep(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		return Sketch.SweepAsBrep(rail, tol, merge, methodType);
	}

	public Mesh SweepAsMesh(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType natureType = Mesh.natureType.Smooth)
	{
		return Sketch.SweepAsMesh(rail, tol, methodType, natureType);
	}

	public T SweepAsMesh<T>(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType natureType = Mesh.natureType.Smooth) where T : Mesh, new()
	{
		return Sketch.SweepAsMesh<T>(rail, tol, methodType, natureType);
	}

	public Mesh[] SweepAsMesh(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType natureType = Mesh.natureType.Smooth)
	{
		return Sketch.SweepAsMesh(rail, tol, merge, methodType, natureType);
	}

	public T SweepAsMesh<T>(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType natureType = Mesh.natureType.Smooth) where T : Mesh, new()
	{
		return Sketch.SweepAsMesh<T>(rail, tol, merge, methodType, natureType);
	}

	public Solid SweepAsSolid(ICurve rail, double tolerance, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames)
	{
		return Sketch.SweepAsSolid((ICurve)(Entity)rail, tolerance, sweepMethod);
	}

	public T SweepAsSolid<T>(ICurve rail, double tolerance, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames) where T : Solid, new()
	{
		return SweepAsSolid<T>(rail, tolerance, sweepMethod);
	}

	public Solid SweepAsSolid(ICurve rail, double tolerance, bool merge, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames)
	{
		return Sketch.SweepAsSolid(rail, tolerance, merge, sweepMethod);
	}

	public T SweepAsSolid<T>(ICurve rail, double tolerance, bool merge, sweepMethodType sweepMethod = sweepMethodType.RotationMinimizingFrames) where T : Solid, new()
	{
		return SweepAsSolid<T>(rail, tolerance, merge, sweepMethod);
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] array = new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[_curveList.Count];
		for (int i = 0; i < _curveList.Count; i++)
		{
			array[i] = ((Entity)_curveList[i])._0023_003DzAKDLnmImamFN(_0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ, _0023_003DzsAi4oSk_003D)[0];
		}
		return array;
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] array = _0023_003DzuAMveDQA6vvk();
		foreach (_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D obj in array)
		{
			obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
			obj._0023_003Dz1MMYB1g_003D = Color;
			obj._0023_003DzaROjBYA_003D = LayerName;
			obj._0023_003Dz_002418Nebs_KL8i = ColorMethod == colorMethodType.byEntity;
			obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
			obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
		}
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] array = new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[_curveList.Count];
		for (int i = 0; i < _curveList.Count; i++)
		{
			Entity entity = (Entity)_curveList[i];
			array[i] = entity._0023_003DzuAMveDQA6vvk()[0];
		}
		return array;
	}

	protected internal override bool SelectedInternal()
	{
		return SelectionMode != selectionFilterType.Entity;
	}

	internal override bool IsSelected(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, selectionStatusType _0023_003DzLEq8mIc_003D)
	{
		if (SelectionMode == selectionFilterType.Entity)
		{
			return base.IsSelected(_0023_003Dzq5nwX2I_003D, _0023_003DzLEq8mIc_003D);
		}
		bool flag = false;
		if (((SelectionMode & selectionFilterType.SketchPoint) != 0 || (SelectionMode & selectionFilterType.SketchCurve) != 0) && SelectionInfoItem._0023_003DzAdoyA7k_003D(_0023_003Dzq5nwX2I_003D, this, SketchCurvesSelectionInfo, out var _0023_003Dzv0Okb82R5LqH))
		{
			flag |= SelectionInfoSubItems.IsAnySelected(_0023_003Dzv0Okb82R5LqH.SubItems, _0023_003DzLEq8mIc_003D);
		}
		return flag;
	}

	public bool IsAnySketchPointSelected()
	{
		if (SelectionInfoSubItems.IsAnySelected(SketchCurvesSelectionInfo))
		{
			return true;
		}
		return false;
	}

	public bool IsAnySketchCurveSelected()
	{
		if (SelectionInfoSubItems.IsAnySelected(SketchCurvesSelectionInfo))
		{
			return true;
		}
		return false;
	}

	protected internal void ClearSketchCurvesSelection(selectionStatusType selectionFlag)
	{
		SelectionInfoSubItems._0023_003DzpeLpar2z_0024ejG(selectionFlag, this, SketchCurvesSelectionInfo);
		if (selectionFlag == selectionStatusType.Permanent && (SelectionMode & selectionFilterType.SketchCurve) != 0)
		{
			SelectionMode = selectionFilterType.Entity;
		}
	}

	public void ClearSketchCurvesSelectionForAllInstances()
	{
		if (IsAnySketchCurveSelected())
		{
			isDirtyForFlattenTree = true;
		}
		SketchCurvesSelectionInfo.Clear();
	}

	public void ResetSelectionMode()
	{
		if (!SelectionInfoSubItems.IsAnySelected(SketchCurvesSelectionInfo))
		{
			SelectionMode = selectionFilterType.Entity;
		}
	}

	private Point _0023_003Dza5njaOyVGsRLbuOcB2Wv_Gs_003D(SketchPoint _0023_003DzBJFJHwk_003D)
	{
		return _0023_003Dz40alAqE_003D(_0023_003DzBJFJHwk_003D, _design.Entities);
	}

	private Point3D _0023_003DzwnwSYqF2cs_cBa5Je6_0024KP64_003D(Point2D _0023_003DzB68dg9Q_003D)
	{
		return Plane.PointAt(_0023_003DzB68dg9Q_003D);
	}

	private Point2D _0023_003Dzjv1UR9r25kdKBrFYzKDykgY_003D(Point4D _0023_003DzBJFJHwk_003D)
	{
		return Plane.Project(_0023_003DzBJFJHwk_003D);
	}
}
