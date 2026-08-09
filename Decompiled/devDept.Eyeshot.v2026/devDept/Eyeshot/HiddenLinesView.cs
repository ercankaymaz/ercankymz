using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Fem;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot;

public class HiddenLinesView : WorkUnit
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<SilhoWireAndTriangleData, bool> _0023_003DzL8A4vc001c0gQY3dGg_003D_003D;

		public static Func<SilhoWireAndTriangleData, bool> _0023_003DzIcm2maGA2yhbJANWgg_003D_003D;

		public static Action<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003Dzq2_OugViiHADIOeoLg_003D_003D;

		public static Func<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D, bool> _0023_003DzTGkV57xncbVEmJqxOA_003D_003D;

		public static Func<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT, int> _0023_003DzTDzSw_vL6mbBxlv6bQ_003D_003D;

		internal bool _0023_003DzyBb_0024PtAJ40_4wkXzdh6Xhuo_003D(SilhoWireAndTriangleData _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D is _0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D;
		}

		internal bool _0023_003DzaEW5mJYvBbBA35Bf1qFFmv0_003D(SilhoWireAndTriangleData _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D is _0023_003Dzf1HxNbhqBUCjNYwMcQ2TfF4FueDkoyri1w_003D_003D;
		}

		internal void _0023_003DzFKVOKZLD9j4ZGvC6FuKG2efbDjiJLrTfRtQGyJA_003D(_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D _0023_003DzBJFJHwk_003D)
		{
			_0023_003DzBJFJHwk_003D._0023_003DzkZ5nG5U_003D = true;
		}

		internal bool _0023_003DzaHpASVqzT_i7bKaMiQO_0024T_00240_003D(_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D _0023_003DzBJFJHwk_003D)
		{
			if (_0023_003DzBJFJHwk_003D._0023_003Dzx9ez3pU_003D)
			{
				return !_0023_003DzBJFJHwk_003D._0023_003Dzi8cEFb9NybZ2LjlZwjtCkKw_003D;
			}
			return false;
		}

		internal int _0023_003Dz6zxlpYNQ5GrnS6BEhbJCuM_0024D4hh_0024(_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D._0023_003DzuxTqAp2a_0024JOK();
		}
	}

	private sealed class _0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D
	{
		public int _0023_003DzffqPLNQ_003D;

		public int _0023_003Dz5Azd7L8_003D;

		internal bool _0023_003Dzf4sKudkFxoYBSovakw_003D_003D(_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D _0023_003DzBJFJHwk_003D)
		{
			if (_0023_003DzBJFJHwk_003D._0023_003DzAddCv_o_003D == _0023_003DzffqPLNQ_003D)
			{
				return _0023_003DzBJFJHwk_003D._0023_003Dz9iVQ96E_003D == _0023_003Dz5Azd7L8_003D;
			}
			return false;
		}
	}

	private sealed class _0023_003DzKmzWz_00240_003D : _0023_003DzNSoc_izqpPSc
	{
		public int[] _0023_003DzCmn_5Z0_003D;

		public int _0023_003DzCPxOJfM_003D;

		public int _0023_003DzQLclF1Q_003D;

		public int _0023_003DzZqSqKm8_003D;

		public int _0023_003DztvD0Jdc_003D;

		public bool _0023_003Dzx9ez3pU_003D;

		public double _0023_003DzRN68t7g_003D;

		public double _0023_003DzuBiD7yI_003D;

		public _0023_003DzKmzWz_00240_003D()
		{
			_0023_003DzCmn_5Z0_003D = new int[2];
		}

		public bool _0023_003Dzq4sdH5I_003D()
		{
			return _0023_003DzQW_0024hBdI_003D[1] == _0023_003DzCmn_5Z0_003D[1];
		}

		public bool _0023_003Dz2lsfKGk_003D()
		{
			return _0023_003DzQW_0024hBdI_003D[0] == _0023_003DzCmn_5Z0_003D[0];
		}

		public virtual bool _0023_003DzKSi6EjvdA_pGvThAIA_003D_003D()
		{
			if (_0023_003DzQW_0024hBdI_003D[1] == _0023_003DzCmn_5Z0_003D[1])
			{
				return _0023_003DzQW_0024hBdI_003D[0] == _0023_003DzCmn_5Z0_003D[0];
			}
			return false;
		}

		internal void _0023_003Dzzg08ZSAHPR69(int _0023_003DzHC7Mg4BtsFMeAIyGjw_003D_003D)
		{
			_0023_003DzZqSqKm8_003D = Math.Min(_0023_003DzQW_0024hBdI_003D[_0023_003DzHC7Mg4BtsFMeAIyGjw_003D_003D], _0023_003DzCmn_5Z0_003D[_0023_003DzHC7Mg4BtsFMeAIyGjw_003D_003D]);
			_0023_003DztvD0Jdc_003D = Math.Max(_0023_003DzQW_0024hBdI_003D[_0023_003DzHC7Mg4BtsFMeAIyGjw_003D_003D], _0023_003DzCmn_5Z0_003D[_0023_003DzHC7Mg4BtsFMeAIyGjw_003D_003D]);
		}

		internal void _0023_003DzmkImHGGAlo_0024P(double _0023_003DzBYFR3As_003D, double _0023_003DzKrxVMYs_003D)
		{
			_0023_003DzRN68t7g_003D = Math.Round(Math.Min(_0023_003DzBYFR3As_003D, _0023_003DzKrxVMYs_003D), 12);
			_0023_003DzuBiD7yI_003D = Math.Round(Math.Max(_0023_003DzBYFR3As_003D, _0023_003DzKrxVMYs_003D), 12);
		}
	}

	internal class _0023_003DzNSoc_izqpPSc
	{
		public int[] _0023_003DzQW_0024hBdI_003D;

		public _0023_003DzNSoc_izqpPSc()
		{
			_0023_003DzQW_0024hBdI_003D = new int[2];
		}

		public int _0023_003DzR216mFc_003D()
		{
			return _0023_003DzQW_0024hBdI_003D[0];
		}

		public int _0023_003DzqJqZpJk_003D()
		{
			return _0023_003DzQW_0024hBdI_003D[1];
		}

		public override string ToString()
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977515), _0023_003DzR216mFc_003D(), _0023_003DzqJqZpJk_003D());
		}

		public static bool operator ==(_0023_003DzNSoc_izqpPSc _0023_003DzRVoDPs0_003D, _0023_003DzNSoc_izqpPSc _0023_003Dz_0024ozI2Ww_003D)
		{
			if (_0023_003DzRVoDPs0_003D._0023_003DzR216mFc_003D() == _0023_003Dz_0024ozI2Ww_003D._0023_003DzR216mFc_003D())
			{
				return _0023_003DzRVoDPs0_003D._0023_003DzqJqZpJk_003D() == _0023_003Dz_0024ozI2Ww_003D._0023_003DzqJqZpJk_003D();
			}
			return false;
		}

		public static bool operator !=(_0023_003DzNSoc_izqpPSc _0023_003DzRVoDPs0_003D, _0023_003DzNSoc_izqpPSc _0023_003Dz_0024ozI2Ww_003D)
		{
			return !(_0023_003DzRVoDPs0_003D == _0023_003Dz_0024ozI2Ww_003D);
		}
	}

	internal sealed class _0023_003DzPWBOFEX1IKDR : IndexLine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzSaHVljQ_003D;

		public _0023_003DzPWBOFEX1IKDR(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzL8NvYU0_003D = -1)
			: base(_0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D)
		{
			_0023_003DzSaHVljQ_003D = _0023_003DzL8NvYU0_003D;
		}

		protected _0023_003DzPWBOFEX1IKDR(_0023_003DzPWBOFEX1IKDR _0023_003DzySgeilxprQOK)
			: base(_0023_003DzySgeilxprQOK)
		{
			_0023_003DzSaHVljQ_003D = _0023_003DzySgeilxprQOK._0023_003DzSaHVljQ_003D;
		}

		public override object Clone()
		{
			return new _0023_003DzPWBOFEX1IKDR(this);
		}

		public override string ToString()
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985861), V1, V2, _0023_003DzSaHVljQ_003D);
		}
	}

	private static class _0023_003DzQm9ltrs_003D
	{
		public static Comparison<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzNux_etclG27gw4KjSQ_003D_003D;

		public static Comparison<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003Dz_WyyF86V9oY44Mhnn1HOjWI_003D;
	}

	private sealed class _0023_003DzRZtSalrSw11j : IComparer<_0023_003DzKmzWz_00240_003D>
	{
		public int Compare(_0023_003DzKmzWz_00240_003D _0023_003DziMjqlCo_003D, _0023_003DzKmzWz_00240_003D _0023_003DzI4dRPW0_003D)
		{
			if (_0023_003DziMjqlCo_003D._0023_003DzQLclF1Q_003D < _0023_003DzI4dRPW0_003D._0023_003DzQLclF1Q_003D)
			{
				return -1;
			}
			if (_0023_003DziMjqlCo_003D._0023_003DzQLclF1Q_003D > _0023_003DzI4dRPW0_003D._0023_003DzQLclF1Q_003D)
			{
				return 1;
			}
			return 0;
		}
	}

	public class HdlArc : HdlCurve
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Point2D _0023_003DzThkjhrDnTf2A5B97tQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double _0023_003DzGoU_JoL93mRxGRLAhw_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Interval _0023_003DzCwX4mA970fxgnASt2Q_003D_003D;

		public Point2D Center
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzThkjhrDnTf2A5B97tQ_003D_003D;
			}
		}

		public double Radius
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzGoU_JoL93mRxGRLAhw_003D_003D;
			}
		}

		public Interval Angle
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzCwX4mA970fxgnASt2Q_003D_003D;
			}
		}

		internal HdlArc(Point2D _0023_003DzbUvT9Pc_003D, double _0023_003DzEGKj_0024SNUUihi, Interval _0023_003Dz6pajdGM_003D, Entity _0023_003Dz9j7EUB0_003D, int _0023_003DzL8NvYU0_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, GfxAttributesWire _0023_003DzqP5lTto_003D)
			: base(_0023_003Dz9j7EUB0_003D, _0023_003Dzq5nwX2I_003D, _0023_003DzL8NvYU0_003D, _0023_003DzqP5lTto_003D)
		{
			_0023_003DzThkjhrDnTf2A5B97tQ_003D_003D = _0023_003DzbUvT9Pc_003D;
			_0023_003Dzwr0qdrp6YCaZ(_0023_003DzEGKj_0024SNUUihi);
			_0023_003DzCwX4mA970fxgnASt2Q_003D_003D = _0023_003Dz6pajdGM_003D;
		}

		internal void _0023_003Dzwr0qdrp6YCaZ(double _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzGoU_JoL93mRxGRLAhw_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		internal override void _0023_003DzK48Px00_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzoMBKEgY_003D)
		{
			Center.X = (Center.X + _0023_003DzBJFJHwk_003D) * _0023_003DzoMBKEgY_003D;
			Center.Y = (Center.Y + _0023_003Dz40R7bAU_003D) * _0023_003DzoMBKEgY_003D;
			_0023_003Dzwr0qdrp6YCaZ(Radius * _0023_003DzoMBKEgY_003D);
		}
	}

	public abstract class HdlCurve : HdlResult
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzQaWEWP8UInciG_0024Z3oQ_003D_003D;

		public int EdgeIndex
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzQaWEWP8UInciG_0024Z3oQ_003D_003D;
			}
		}

		internal HdlCurve(Entity _0023_003Dz9j7EUB0_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, int _0023_003DzL8NvYU0_003D, GfxAttributesWire _0023_003DzqP5lTto_003D)
			: base(_0023_003Dz9j7EUB0_003D, _0023_003Dzq5nwX2I_003D, _0023_003DzqP5lTto_003D)
		{
			_0023_003DzQaWEWP8UInciG_0024Z3oQ_003D_003D = _0023_003DzL8NvYU0_003D;
		}

		internal abstract void _0023_003DzK48Px00_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzoMBKEgY_003D);
	}

	public class HdlEllipticalArc : HdlCurve
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Plane _0023_003DzM9cMwfwXAw1RfrKRAwh8Xbs_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double _0023_003Dz5LsEOBkjYDzJnYV6gA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double _0023_003DzYkhTaXKK8gcR38CRiw_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Interval _0023_003DzCwX4mA970fxgnASt2Q_003D_003D;

		public Plane Plane
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzM9cMwfwXAw1RfrKRAwh8Xbs_003D;
			}
		}

		public double RadiusX
		{
			[CompilerGenerated]
			get
			{
				return _0023_003Dz5LsEOBkjYDzJnYV6gA_003D_003D;
			}
		}

		public double RadiusY
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzYkhTaXKK8gcR38CRiw_003D_003D;
			}
		}

		public Interval Angle
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzCwX4mA970fxgnASt2Q_003D_003D;
			}
		}

		internal HdlEllipticalArc(Plane _0023_003Dzrgqz890sj_0024X9, double _0023_003DzTAvzjIc_003D, double _0023_003DzpbGuOuw_003D, Interval _0023_003Dz6pajdGM_003D, Entity _0023_003Dz9j7EUB0_003D, int _0023_003DzL8NvYU0_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, GfxAttributesWire _0023_003DzqP5lTto_003D)
			: base(_0023_003Dz9j7EUB0_003D, _0023_003Dzq5nwX2I_003D, _0023_003DzL8NvYU0_003D, _0023_003DzqP5lTto_003D)
		{
			_0023_003DzM9cMwfwXAw1RfrKRAwh8Xbs_003D = _0023_003Dzrgqz890sj_0024X9;
			_0023_003DziGxa1Vjvpx4k(_0023_003DzTAvzjIc_003D);
			_0023_003DzHyhk8LNbBVz6(_0023_003DzpbGuOuw_003D);
			_0023_003DzCwX4mA970fxgnASt2Q_003D_003D = _0023_003Dz6pajdGM_003D;
		}

		internal void _0023_003DziGxa1Vjvpx4k(double _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003Dz5LsEOBkjYDzJnYV6gA_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		internal void _0023_003DzHyhk8LNbBVz6(double _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzYkhTaXKK8gcR38CRiw_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		internal override void _0023_003DzK48Px00_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzoMBKEgY_003D)
		{
			Plane.Origin.X = (Plane.Origin.X + _0023_003DzBJFJHwk_003D) * _0023_003DzoMBKEgY_003D;
			Plane.Origin.Y = (Plane.Origin.Y + _0023_003Dz40R7bAU_003D) * _0023_003DzoMBKEgY_003D;
			_0023_003DziGxa1Vjvpx4k(RadiusX * _0023_003DzoMBKEgY_003D);
			_0023_003DzHyhk8LNbBVz6(RadiusY * _0023_003DzoMBKEgY_003D);
		}
	}

	public class HdlLinearPath : HdlCurve
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Point2D[] _0023_003DzOy7x6nKmJG_0024PzP1zikqcql_pFqjr;

		public Point2D[] Vertices
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzOy7x6nKmJG_0024PzP1zikqcql_pFqjr;
			}
		}

		internal HdlLinearPath(Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Entity _0023_003Dz9j7EUB0_003D, int _0023_003DzL8NvYU0_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, GfxAttributesWire _0023_003DzqP5lTto_003D)
			: base(_0023_003Dz9j7EUB0_003D, _0023_003Dzq5nwX2I_003D, _0023_003DzL8NvYU0_003D, _0023_003DzqP5lTto_003D)
		{
			_0023_003DzOy7x6nKmJG_0024PzP1zikqcql_pFqjr = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
		}

		internal override void _0023_003DzK48Px00_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzoMBKEgY_003D)
		{
			Point2D[] vertices = Vertices;
			foreach (Point2D point2D in vertices)
			{
				point2D.X = (point2D.X + _0023_003DzBJFJHwk_003D) * _0023_003DzoMBKEgY_003D;
				point2D.Y = (point2D.Y + _0023_003Dz40R7bAU_003D) * _0023_003DzoMBKEgY_003D;
			}
		}
	}

	public class HdlMesh : HdlResult
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Mesh _0023_003DzHqJB_0024RV_0024OONND5ItsA_003D_003D;

		public Mesh Mesh
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzHqJB_0024RV_0024OONND5ItsA_003D_003D;
			}
		}

		internal HdlMesh(SilhoWireAndTriangleData _0023_003Dzf6SYuvBzh_0024w1Ht1jYA_003D_003D, Mesh _0023_003DzGGJSiQk_003D)
			: base(_0023_003Dzf6SYuvBzh_0024w1Ht1jYA_003D_003D.Entity, _0023_003Dzf6SYuvBzh_0024w1Ht1jYA_003D_003D.Parents, _0023_003Dzf6SYuvBzh_0024w1Ht1jYA_003D_003D.Attributes)
		{
			_0023_003DzHqJB_0024RV_0024OONND5ItsA_003D_003D = _0023_003DzGGJSiQk_003D;
		}
	}

	public class HdlPicture : HdlResult
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly double[] _0023_003DzX6nvjrrIhbZCRZ3PqX_rD0QJc9pu;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte[] _0023_003DzYoXP_EnkqiEGpgPaLg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private RectangleF _0023_003DzA6mJRPg_003D;

		public byte[] Image
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzYoXP_EnkqiEGpgPaLg_003D_003D;
			}
		}

		public double X => _0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[0];

		public double Y => _0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[1];

		public double Width => Rectangle.Width;

		public double Height => Rectangle.Height;

		public RectangleF Rectangle
		{
			get
			{
				if (_0023_003DzA6mJRPg_003D.IsEmpty)
				{
					Point2D a = new Point2D(_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[0], _0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[1]);
					Point2D point2D = new Point2D(_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[3], _0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[4]);
					Point2D b = new Point2D(_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[6], _0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[7]);
					Point2D point2D2 = new Point2D(_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[9], _0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[10]);
					_0023_003DzA6mJRPg_003D = new RectangleF((float)point2D2.X, (float)point2D2.Y, (float)Point2D.Distance(a, point2D), (float)Point2D.Distance(point2D, b));
				}
				return _0023_003DzA6mJRPg_003D;
			}
		}

		internal HdlPicture(_0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN _0023_003DzBkmSAt3H_jvz)
			: base(_0023_003DzBkmSAt3H_jvz._0023_003Dz0tIOZG5ZfcAY().Entity, _0023_003DzBkmSAt3H_jvz._0023_003Dz0tIOZG5ZfcAY().Parents, _0023_003DzBkmSAt3H_jvz._0023_003DzHptl2yRuV4Y_0024())
		{
			_0023_003DzX6nvjrrIhbZCRZ3PqX_rD0QJc9pu = _0023_003DzBkmSAt3H_jvz._0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D();
			_0023_003DzYoXP_EnkqiEGpgPaLg_003D_003D = _0023_003DzBkmSAt3H_jvz._0023_003Dz3_0024K28LXoY9HR();
		}

		internal double[] _0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()
		{
			return _0023_003DzX6nvjrrIhbZCRZ3PqX_rD0QJc9pu;
		}

		internal List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzqPk52tIIDIJe()
		{
			List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> list = new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>();
			list.Add(new _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new double[6]
				{
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[0],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[1],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[2],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[3],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[4],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[5]
				}
			});
			list.Add(new _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new double[6]
				{
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[3],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[4],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[5],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[6],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[7],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[8]
				}
			});
			list.Add(new _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new double[6]
				{
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[6],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[7],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[8],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[9],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[10],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[11]
				}
			});
			list.Add(new _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new double[6]
				{
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[9],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[10],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[11],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[0],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[1],
					_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[2]
				}
			});
			return list;
		}

		public float GetAngle()
		{
			Point3D p = new Point3D(_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[0], _0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[1]);
			Point2D p2 = new Point3D(_0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[3], _0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[4]);
			Vector2D vector2D = new Vector2D(p, p2);
			vector2D.Normalize();
			return (float)Utility.RadToDeg(Vector2D.SignedAngleBetween(Vector2D.AxisX, vector2D));
		}
	}

	public class HdlPoint : HdlCurve
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Point2D _0023_003DzqBBDir96tk1C10WwYw_003D_003D;

		public Point2D Vertex
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzqBBDir96tk1C10WwYw_003D_003D;
			}
		}

		internal HdlPoint(Point2D _0023_003DzkEYxO1SuR1Kw, Entity _0023_003Dz9j7EUB0_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, GfxAttributesWire _0023_003DzqP5lTto_003D)
			: base(_0023_003Dz9j7EUB0_003D, _0023_003Dzq5nwX2I_003D, -1, _0023_003DzqP5lTto_003D)
		{
			_0023_003DzqBBDir96tk1C10WwYw_003D_003D = _0023_003DzkEYxO1SuR1Kw;
		}

		internal override void _0023_003DzK48Px00_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzoMBKEgY_003D)
		{
			Vertex.X = (Vertex.X + _0023_003DzBJFJHwk_003D) * _0023_003DzoMBKEgY_003D;
			Vertex.Y = (Vertex.Y + _0023_003Dz40R7bAU_003D) * _0023_003DzoMBKEgY_003D;
		}
	}

	public abstract class HdlResult
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Entity _0023_003DzhhzkWcM2rt3Jym8xhA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly GfxAttributesWire _0023_003DzhhcoHBO6BxHF7oEESg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Stack<BlockReference> _0023_003DzVFEljva0ZbIneo8XbQ_003D_003D;

		public Entity Entity
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzhhzkWcM2rt3Jym8xhA_003D_003D;
			}
		}

		public GfxAttributesWire Attributes
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzhhcoHBO6BxHF7oEESg_003D_003D;
			}
		}

		public Stack<BlockReference> Parents
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzVFEljva0ZbIneo8XbQ_003D_003D;
			}
		}

		internal HdlResult(Entity _0023_003Dz9j7EUB0_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, GfxAttributesWire _0023_003DzqP5lTto_003D)
		{
			_0023_003DzhhzkWcM2rt3Jym8xhA_003D_003D = _0023_003Dz9j7EUB0_003D;
			_0023_003DzVFEljva0ZbIneo8XbQ_003D_003D = _0023_003Dzq5nwX2I_003D;
			_0023_003DzhhcoHBO6BxHF7oEESg_003D_003D = _0023_003DzqP5lTto_003D;
		}
	}

	public class HdlSection : HdlResult
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly Hatch _0023_003Dz6PlnxgFLzP5QEHxrCQ_003D_003D;

		public Hatch Hatch
		{
			[CompilerGenerated]
			get
			{
				return _0023_003Dz6PlnxgFLzP5QEHxrCQ_003D_003D;
			}
		}

		internal HdlSection(_0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D _0023_003DzELu0Pss_003D, Hatch _0023_003Dz1L3TZOcNA99t)
			: base(_0023_003DzELu0Pss_003D.Entity, _0023_003DzELu0Pss_003D.Parents, _0023_003DzELu0Pss_003D.Attributes)
		{
			_0023_003Dz6PlnxgFLzP5QEHxrCQ_003D_003D = _0023_003Dz1L3TZOcNA99t;
		}
	}

	public class HdlSpline : HdlCurve
	{
		public int Degree;

		public double[] KnotVector;

		public Point4D[] ControlPoints;

		internal HdlSpline(int _0023_003DzU7eDCS_XZhhv, double[] _0023_003DztnKSw31yt72w, Point4D[] _0023_003DzTkPhA8X_2C3n, Entity _0023_003Dz9j7EUB0_003D, int _0023_003DzL8NvYU0_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, GfxAttributesWire _0023_003DzqP5lTto_003D)
			: base(_0023_003Dz9j7EUB0_003D, _0023_003Dzq5nwX2I_003D, _0023_003DzL8NvYU0_003D, _0023_003DzqP5lTto_003D)
		{
			Degree = _0023_003DzU7eDCS_XZhhv;
			KnotVector = _0023_003DztnKSw31yt72w;
			ControlPoints = _0023_003DzTkPhA8X_2C3n;
		}

		internal override void _0023_003DzK48Px00_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzoMBKEgY_003D)
		{
			Point4D[] controlPoints = ControlPoints;
			foreach (Point4D point4D in controlPoints)
			{
				point4D.X = (point4D.X + _0023_003DzBJFJHwk_003D) * _0023_003DzoMBKEgY_003D;
				point4D.Y = (point4D.Y + _0023_003Dz40R7bAU_003D) * _0023_003DzoMBKEgY_003D;
			}
		}
	}

	public class HdlText : HdlResult
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly string _0023_003Dz18SZ2wIYdiPeUxfV1A_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly string _0023_003DzALWcNft6AmxV9hgmhhzuXPk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly fontStyle _0023_003DzIpPwz3OekvZuNfjfbGZAMoc_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private RectangleF _0023_003DzA6mJRPg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly double[] _0023_003DzOy7x6nKmJG_0024PzP1zikqcql_pFqjr;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly bool _0023_003DzkJOz7pK8rvsl0xVn5CK2_jawRk0Y;

		public string Text
		{
			[CompilerGenerated]
			get
			{
				return _0023_003Dz18SZ2wIYdiPeUxfV1A_003D_003D;
			}
		}

		public string FontFamilyName
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzALWcNft6AmxV9hgmhhzuXPk_003D;
			}
		}

		public fontStyle FontStyle
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzIpPwz3OekvZuNfjfbGZAMoc_003D;
			}
		}

		public RectangleF RectangleText
		{
			get
			{
				if (_0023_003DzA6mJRPg_003D.IsEmpty)
				{
					Point2D a = new Point2D(_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[0], _0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[1]);
					Point2D point2D = new Point2D(_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[3], _0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[4]);
					Point2D b = new Point2D(_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[6], _0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[7]);
					Point2D point2D2 = new Point2D(_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[9], _0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[10]);
					_0023_003DzA6mJRPg_003D = new RectangleF((float)point2D2.X, (float)point2D2.Y, (float)Point2D.Distance(a, point2D), (float)Point2D.Distance(point2D, b));
				}
				return _0023_003DzA6mJRPg_003D;
			}
		}

		public bool IsFlipped
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzkJOz7pK8rvsl0xVn5CK2_jawRk0Y;
			}
		}

		internal HdlText(_0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU _0023_003DzFxbJXwY_003D)
			: base(_0023_003DzFxbJXwY_003D._0023_003Dz0tIOZG5ZfcAY().Entity, _0023_003DzFxbJXwY_003D._0023_003Dz0tIOZG5ZfcAY().Parents, _0023_003DzFxbJXwY_003D._0023_003DzHptl2yRuV4Y_0024())
		{
			_0023_003Dz18SZ2wIYdiPeUxfV1A_003D_003D = _0023_003DzFxbJXwY_003D._0023_003Dztfs771XhsCDR();
			_0023_003DzALWcNft6AmxV9hgmhhzuXPk_003D = _0023_003DzFxbJXwY_003D._0023_003DzonppTMzbco4i();
			_0023_003DzIpPwz3OekvZuNfjfbGZAMoc_003D = _0023_003DzFxbJXwY_003D._0023_003DzcMHHHXFgK3x9();
			_0023_003DzOy7x6nKmJG_0024PzP1zikqcql_pFqjr = _0023_003DzFxbJXwY_003D._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D();
			_0023_003DzkJOz7pK8rvsl0xVn5CK2_jawRk0Y = _0023_003DzFxbJXwY_003D._0023_003DzrCyY1TVDe4xioci3zg_003D_003D();
		}

		internal double[] _0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()
		{
			return _0023_003DzOy7x6nKmJG_0024PzP1zikqcql_pFqjr;
		}

		internal List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzqPk52tIIDIJe()
		{
			List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> list = new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>();
			list.Add(new _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new double[6]
				{
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[0],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[1],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[2],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[3],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[4],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[5]
				}
			});
			list.Add(new _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new double[6]
				{
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[3],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[4],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[5],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[6],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[7],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[8]
				}
			});
			list.Add(new _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new double[6]
				{
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[6],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[7],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[8],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[9],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[10],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[11]
				}
			});
			list.Add(new _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new double[6]
				{
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[9],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[10],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[11],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[0],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[1],
					_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[2]
				}
			});
			return list;
		}

		public float GetAngle()
		{
			Point3D p = new Point3D(_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[0], _0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[1]);
			Point2D p2 = new Point3D(_0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[3], _0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[4]);
			Vector2D vector2D = new Vector2D(p, p2);
			vector2D.Normalize();
			return (float)Utility.RadToDeg(Vector2D.SignedAngleBetween(Vector2D.AxisX, vector2D));
		}
	}

	protected HashSet<int> printOrderValues = new HashSet<int>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003Dz5RvNwAoQz8qkxxvBUqX_cKg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzJpDx6YUyvUeu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzhZz9rIEFDTwJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<_0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN> _0023_003DzYP1mbLPa1Hn6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<_0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU> _0023_003Dz18MpjswfPHE6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzuEN6qKPJwlqve1bSzQyu9lY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzyrfqyvnF0yLf;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzCntTTb6_0024ylA6ae1s5A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<HdlCurve> _0023_003DzEvYbKUFCkpS4OvewBg_003D_003D = new List<HdlCurve>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HdlCurve[] _0023_003DzRsXkZdM50Jn3pQB8Bb5Icx8dwL1v;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HdlCurve[] _0023_003DzztXIWUDpAAT32KD_00241A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HdlCurve[] _0023_003Dz2Di0A_1uFlMqCcXOO7F1xYw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HdlCurve[] _0023_003Dz6YPBSFkImJAJ4nxF6it3YCpR_00247v7agdM4w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HdlCurve[] _0023_003Dzb_0024_0024n66yNH7OZucTm9nJ_hG0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HdlCurve[] _0023_003Dzxg9UypCvY6MCSjYwm8UtX5w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HdlMesh[] _0023_003DzCDM06IQCEeQRSmtyag_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HdlSection[] _0023_003Dzt7g2hZGHlSaw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HdlMesh[] _0023_003DzonJTCvsLblMn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HdlText[] _0023_003DzugbMPbbFAdkO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HdlPicture[] _0023_003DzQAyazhDHndgvak_0024_Sg7FCeA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HdlMesh[] _0023_003Dz0qrhEQZAhUAO;

	private protected List<SilhoWireAndTriangleData> wireAndTriangleDatas;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<_0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D> _0023_003Dz89MX302ggzaN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzuvkktNA2OHo_vIbJ7Q_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzheS2h4tdfFfa;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PlaneEquation[] _0023_003DzmPTqpRCcACPhYmg7UTvB9WI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GfxAttributesWire _0023_003DzjCqtHKg_003D;

	public HiddenLinesViewSettings HdlViewSettings;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly double _0023_003Dz3d_0024ELptjrAIK = 1.0 + Utility._0023_003DzheSR8QM7q9ya;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly double _0023_003Dzrn0tsjBS36LL = 0.0 - Utility._0023_003DzheSR8QM7q9ya;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D = _0023_003Dzrn0tsjBS36LL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003DzwJ3QaGJFHQh4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003DzTtgGeeqBjD2i;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string _0023_003Dz3lURioVh8358;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzyn1zu_0024TG8WG_0024CKS3gqst_uc_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986617);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzyMFpmcbbmQELriRj0O2GAR68SIQCMS4_0024lA_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986589);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzO15W8MCPNDHsEJGUNE_0024bEPw_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986558);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzGsDMjcfSTtHhtKQa0D_0024rsbWMxGKK = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986498);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static double _0023_003DzJtboPEauKSQjz2YtzmlRqtI_003D = 100.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzzIrgzh87xtI_EdP2YA_003D_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzQpZSox1CJlNK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzLE3fZGtyB_0024v8 = Color.White.ToArgb();

	public HdlCurve[] Silhouettes
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzRsXkZdM50Jn3pQB8Bb5Icx8dwL1v;
		}
	}

	public HdlCurve[] Edges
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzztXIWUDpAAT32KD_00241A_003D_003D;
		}
	}

	public HdlCurve[] Wires
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz2Di0A_1uFlMqCcXOO7F1xYw_003D;
		}
	}

	public HdlCurve[] HiddenSilhouettes
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz6YPBSFkImJAJ4nxF6it3YCpR_00247v7agdM4w_003D_003D;
		}
	}

	public HdlCurve[] HiddenEdges
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzb_0024_0024n66yNH7OZucTm9nJ_hG0_003D;
		}
	}

	public HdlCurve[] HiddenWires
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzxg9UypCvY6MCSjYwm8UtX5w_003D;
		}
	}

	protected internal HdlMesh[] Meshes
	{
		get
		{
			if (_0023_003DzCDM06IQCEeQRSmtyag_003D_003D == null)
			{
				_0023_003DzCDM06IQCEeQRSmtyag_003D_003D = _0023_003DzROQTjn5Yve4K(wireAndTriangleDatas);
			}
			return _0023_003DzCDM06IQCEeQRSmtyag_003D_003D;
		}
	}

	public HdlSection[] Sections
	{
		get
		{
			if (_0023_003Dzt7g2hZGHlSaw == null)
			{
				_0023_003Dzt7g2hZGHlSaw = _0023_003Dzr9dKzPoFBCXq(_0023_003Dz89MX302ggzaN);
			}
			return _0023_003Dzt7g2hZGHlSaw;
		}
	}

	public HdlMesh[] Texts
	{
		get
		{
			if (_0023_003DzonJTCvsLblMn == null)
			{
				_0023_003DzonJTCvsLblMn = _0023_003DzROQTjn5Yve4K(wireAndTriangleDatas.Where((SilhoWireAndTriangleData _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D is _0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D).ToList());
			}
			return _0023_003DzonJTCvsLblMn;
		}
	}

	public HdlText[] TextStrings
	{
		get
		{
			if (_0023_003DzugbMPbbFAdkO == null)
			{
				_0023_003DzugbMPbbFAdkO = new HdlText[_0023_003Dz18MpjswfPHE6.Count];
				for (int i = 0; i < _0023_003Dz18MpjswfPHE6.Count; i++)
				{
					_0023_003DzugbMPbbFAdkO[i] = new HdlText(_0023_003Dz18MpjswfPHE6[i]);
				}
			}
			return _0023_003DzugbMPbbFAdkO;
		}
	}

	public HdlPicture[] Pictures
	{
		get
		{
			if (_0023_003DzQAyazhDHndgvak_0024_Sg7FCeA_003D == null)
			{
				_0023_003DzQAyazhDHndgvak_0024_Sg7FCeA_003D = new HdlPicture[_0023_003DzYP1mbLPa1Hn6.Count];
				for (int i = 0; i < _0023_003DzYP1mbLPa1Hn6.Count; i++)
				{
					_0023_003DzQAyazhDHndgvak_0024_Sg7FCeA_003D[i] = new HdlPicture(_0023_003DzYP1mbLPa1Hn6[i]);
				}
			}
			return _0023_003DzQAyazhDHndgvak_0024_Sg7FCeA_003D;
		}
	}

	public HdlMesh[] Regions
	{
		get
		{
			if (_0023_003Dz0qrhEQZAhUAO == null)
			{
				_0023_003Dz0qrhEQZAhUAO = _0023_003DzROQTjn5Yve4K(wireAndTriangleDatas.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzaEW5mJYvBbBA35Bf1qFFmv0_003D).ToList());
			}
			return _0023_003Dz0qrhEQZAhUAO;
		}
	}

	public string ComputingVisibilityText
	{
		get
		{
			return _0023_003Dzyn1zu_0024TG8WG_0024CKS3gqst_uc_003D;
		}
		set
		{
			_0023_003Dzyn1zu_0024TG8WG_0024CKS3gqst_uc_003D = value;
		}
	}

	public string ComputingSilhouettesText
	{
		get
		{
			return _0023_003DzyMFpmcbbmQELriRj0O2GAR68SIQCMS4_0024lA_003D_003D;
		}
		set
		{
			_0023_003DzyMFpmcbbmQELriRj0O2GAR68SIQCMS4_0024lA_003D_003D = value;
		}
	}

	public string RemovingOverlappingLinesText
	{
		get
		{
			return _0023_003DzO15W8MCPNDHsEJGUNE_0024bEPw_003D;
		}
		set
		{
			_0023_003DzO15W8MCPNDHsEJGUNE_0024bEPw_003D = value;
		}
	}

	public string ComputingCirclesText
	{
		get
		{
			return _0023_003DzGsDMjcfSTtHhtKQa0D_0024rsbWMxGKK;
		}
		set
		{
			_0023_003DzGsDMjcfSTtHhtKQa0D_0024rsbWMxGKK = value;
		}
	}

	public HiddenLinesView(IWorkspace workspace)
		: this(workspace.ActiveViewport, workspace)
	{
	}

	public HiddenLinesView(IViewport viewport, IWorkspace workspace)
		: this(new HiddenLinesViewSettings(viewport.Camera, workspace.Document, hiddenLinesViewType.Extents, viewport.Size))
	{
	}

	public HiddenLinesView(Camera camera, Document document)
		: this(new HiddenLinesViewSettings(camera, document, hiddenLinesViewType.Extents))
	{
	}

	public HiddenLinesView(HiddenLinesViewSettings viewSettings)
		: this(viewSettings, viewSettings.ForceTextsAsTriangles)
	{
	}

	protected HiddenLinesView(HiddenLinesViewSettings viewSettings, bool forceTextsAsTriangles)
	{
		HdlViewSettings = viewSettings;
		HdlViewSettings.ForceTextsAsTriangles = forceTextsAsTriangles;
		_0023_003DzIA8GcQ0_003D(_0023_003DzvKQ6k8f_e9AV: true);
	}

	public new void DoWork()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		DoWork(null, default(CancellationToken));
		WorkCompleted(HdlViewSettings.document);
		stopwatch.Stop();
		base.ExecutionTime = stopwatch.ElapsedMilliseconds;
	}

	private void _0023_003DzVq_rQxw0kQMtblXdkEJzELk_003D(HdlCurve[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzRsXkZdM50Jn3pQB8Bb5Icx8dwL1v = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzXh_0024_c3AiFf_00248(HdlCurve[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzztXIWUDpAAT32KD_00241A_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzXYNwQUGUceBK(HdlCurve[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz2Di0A_1uFlMqCcXOO7F1xYw_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003Dz1ysqp8Yxm25nozhVs0x3LAk_003D(HdlCurve[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz6YPBSFkImJAJ4nxF6it3YCpR_00247v7agdM4w_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzipnGqfumV5Bq(HdlCurve[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dzb_0024_0024n66yNH7OZucTm9nJ_hG0_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003Dz3zsJBoZg_sNWWwZM_0024A_003D_003D(HdlCurve[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dzxg9UypCvY6MCSjYwm8UtX5w_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private HdlMesh[] _0023_003DzROQTjn5Yve4K<T>(List<T> _0023_003DzELu0Pss_003D) where T : SilhoWireAndTriangleData
	{
		HdlMesh[] array = new HdlMesh[_0023_003DzELu0Pss_003D.Count];
		for (int i = 0; i < _0023_003DzELu0Pss_003D.Count; i++)
		{
			T val = _0023_003DzELu0Pss_003D[i];
			double[,] screenVertices = val.ScreenVertices;
			IndexTriangle[] array2 = new IndexTriangle[screenVertices.GetLength(0) / 3];
			Point3D[] array3 = new Point3D[screenVertices.GetLength(0)];
			int num = 0;
			int num2 = 0;
			while (num2 < screenVertices.GetLength(0))
			{
				array3[num++] = new Point3D(screenVertices[num2, 0], screenVertices[num2++, 1]);
			}
			num = 0;
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = new IndexTriangle(num++, num++, num++);
			}
			Mesh mesh = new Mesh(array3, array2);
			mesh.Color = val.Attributes.GetColor();
			array[i] = new HdlMesh(val, mesh);
		}
		return array;
	}

	private HdlSection[] _0023_003Dzr9dKzPoFBCXq(IReadOnlyList<_0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D> _0023_003DzELu0Pss_003D)
	{
		HdlSection[] array = new HdlSection[_0023_003DzELu0Pss_003D.Count];
		double num = Math.PI / (double)_0023_003DzELu0Pss_003D.Count;
		for (int i = 0; i < _0023_003DzELu0Pss_003D.Count; i++)
		{
			_0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D _0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D2 = _0023_003DzELu0Pss_003D[i];
			double[,] screenVertices = _0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D2.ScreenVertices;
			List<ICurve> list = new List<ICurve>(_0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D2._0023_003DzZSnvfVF8Y5Qg.Length);
			_0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom[] _0023_003DzZSnvfVF8Y5Qg = _0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D2._0023_003DzZSnvfVF8Y5Qg;
			for (int j = 0; j < _0023_003DzZSnvfVF8Y5Qg.Length; j++)
			{
				int[][] _0023_003DzhMDfC7g_003D = _0023_003DzZSnvfVF8Y5Qg[j]._0023_003DzhMDfC7g_003D;
				foreach (int[] array2 in _0023_003DzhMDfC7g_003D)
				{
					Point3D[] array3 = new Point3D[array2.Length];
					for (int l = 0; l < array2.Length; l++)
					{
						array3[l] = new Point3D(screenVertices[array2[l], 0], screenVertices[array2[l], 1]);
					}
					list.Add(new LinearPath(array3));
				}
			}
			double _0023_003DzFYcYsHhaFHz = (double)i * num;
			_0023_003DzFYcYsHhaFHz = _0023_003DqJqSSlsAM9ZOWy2sGhrMYE_OnjFsONoIybzA_0024ObREKHQWLvhm_5zkw_0024scxu_0024D_JPh(_0023_003DzFYcYsHhaFHz, Math.PI / 2.0);
			_0023_003DzFYcYsHhaFHz = _0023_003DqJqSSlsAM9ZOWy2sGhrMYE_OnjFsONoIybzA_0024ObREKHQWLvhm_5zkw_0024scxu_0024D_JPh(_0023_003DzFYcYsHhaFHz, Math.PI);
			Hatch hatch = new Hatch(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985923), list)
			{
				PatternAngle = _0023_003DzFYcYsHhaFHz
			};
			hatch.Color = _0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D2.Attributes.GetColor();
			array[i] = new HdlSection(_0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D2, hatch);
		}
		return array;
	}

	protected void GetComputedLines(out HdlCurve[] silho, out HdlCurve[] edges, out HdlCurve[] wires, out HdlCurve[] hiddenSilho, out HdlCurve[] hiddenEdges, out HdlCurve[] hiddenWires, out HdlPicture[] pictures, out HdlText[] texts, out HdlSection[] sections)
	{
		silho = FilterLinesToExport(Silhouettes);
		edges = FilterLinesToExport(Edges);
		wires = FilterLinesToExport(Wires);
		hiddenSilho = FilterLinesToExport(HiddenSilhouettes);
		hiddenEdges = FilterLinesToExport(HiddenEdges);
		hiddenWires = FilterLinesToExport(HiddenWires);
		pictures = FilterLinesToExport(Pictures);
		texts = FilterLinesToExport(TextStrings);
		sections = FilterLinesToExport(Sections);
	}

	protected virtual T[] FilterLinesToExport<T>(T[] lines) where T : HdlResult
	{
		return lines;
	}

	public void ScaleLinesToWorld(float scale = 1f)
	{
		if (HdlViewSettings.Camera.ProjectionMode == projectionType.Orthographic)
		{
			scale *= (float)HdlViewSettings.ViewToWorldConversion();
			Point3D point3D = HdlViewSettings.Camera.WorldToScreen(0.0, 0.0, 0.0, HdlViewSettings.ViewBounds);
			_0023_003Dzy5vjFeQzzmmZ(0.0 - point3D.X, 0.0 - point3D.Y, scale, Silhouettes);
			_0023_003Dzy5vjFeQzzmmZ(0.0 - point3D.X, 0.0 - point3D.Y, scale, Edges);
			_0023_003Dzy5vjFeQzzmmZ(0.0 - point3D.X, 0.0 - point3D.Y, scale, Wires);
			if (HdlViewSettings.KeepHiddenSegments)
			{
				_0023_003Dzy5vjFeQzzmmZ(0.0 - point3D.X, 0.0 - point3D.Y, scale, HiddenSilhouettes);
				_0023_003Dzy5vjFeQzzmmZ(0.0 - point3D.X, 0.0 - point3D.Y, scale, HiddenEdges);
				_0023_003Dzy5vjFeQzzmmZ(0.0 - point3D.X, 0.0 - point3D.Y, scale, HiddenWires);
			}
			_0023_003DzpRmXznGBaXfvsVk8Yg_003D_003D(0.0 - point3D.X, 0.0 - point3D.Y, scale, _0023_003Dz89MX302ggzaN);
		}
	}

	public void ScaleTrianglesToWorld(float scale = 1f)
	{
		if (HdlViewSettings.Camera.ProjectionMode != projectionType.Orthographic)
		{
			return;
		}
		scale *= (float)HdlViewSettings.ViewToWorldConversion();
		Point3D point3D = HdlViewSettings.Camera.WorldToScreen(0.0, 0.0, 0.0, HdlViewSettings.ViewBounds);
		_0023_003DzpRmXznGBaXfvsVk8Yg_003D_003D(0.0 - point3D.X, 0.0 - point3D.Y, scale, wireAndTriangleDatas);
		foreach (_0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU item in _0023_003Dz18MpjswfPHE6)
		{
			for (int i = 0; i < item._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D().Length; i++)
			{
				item._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[i] = (item._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[i++] - point3D.X) * (double)scale;
				item._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[i] = (item._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[i++] - point3D.Y) * (double)scale;
			}
		}
		foreach (_0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN item2 in _0023_003DzYP1mbLPa1Hn6)
		{
			foreach (_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT item3 in item2._0023_003DzqPk52tIIDIJe())
			{
				item3._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0] = (item3._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0] - point3D.X) * (double)scale;
				item3._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1] = (item3._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1] - point3D.Y) * (double)scale;
				item3._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3] = (item3._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3] - point3D.X) * (double)scale;
				item3._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4] = (item3._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4] - point3D.Y) * (double)scale;
			}
			for (int j = 0; j < item2._0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D().Length; j++)
			{
				item2._0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[j] = (item2._0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[j++] - point3D.X) * (double)scale;
				item2._0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[j] = (item2._0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[j++] - point3D.Y) * (double)scale;
			}
		}
	}

	private static void _0023_003DzpRmXznGBaXfvsVk8Yg_003D_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzoMBKEgY_003D, IReadOnlyList<SilhoWireData> _0023_003DzdVNMNH_MwDtK)
	{
		for (int i = 0; i < _0023_003DzdVNMNH_MwDtK.Count; i++)
		{
			SilhoWireData silhoWireData = _0023_003DzdVNMNH_MwDtK[i];
			int length = silhoWireData.ScreenVertices.GetLength(0);
			for (int j = 0; j < length; j++)
			{
				silhoWireData.ScreenVertices[j, 0] = (silhoWireData.ScreenVertices[j, 0] + _0023_003DzBJFJHwk_003D) * _0023_003DzoMBKEgY_003D;
				silhoWireData.ScreenVertices[j, 1] = (silhoWireData.ScreenVertices[j, 1] + _0023_003Dz40R7bAU_003D) * _0023_003DzoMBKEgY_003D;
			}
		}
	}

	private void _0023_003Dzy5vjFeQzzmmZ(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzoMBKEgY_003D, IList<HdlCurve> _0023_003DzTftW4PL7HjPF9BhfLg_003D_003D)
	{
		if (_0023_003DzTftW4PL7HjPF9BhfLg_003D_003D == null)
		{
			return;
		}
		foreach (HdlCurve item in _0023_003DzTftW4PL7HjPF9BhfLg_003D_003D)
		{
			item._0023_003DzK48Px00_003D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzoMBKEgY_003D);
		}
	}

	internal void _0023_003Dz7m7OtO01ntFBekyLYg_003D_003D()
	{
		if (_0023_003DzJpDx6YUyvUeu != null)
		{
			_0023_003Dz7m7OtO01ntFBekyLYg_003D_003D(_0023_003DzJpDx6YUyvUeu);
		}
		if (_0023_003DzhZz9rIEFDTwJ != null)
		{
			_0023_003Dz7m7OtO01ntFBekyLYg_003D_003D(_0023_003DzhZz9rIEFDTwJ);
		}
		if (_0023_003Dz5RvNwAoQz8qkxxvBUqX_cKg_003D != null)
		{
			_0023_003Dz7m7OtO01ntFBekyLYg_003D_003D(_0023_003Dz5RvNwAoQz8qkxxvBUqX_cKg_003D);
		}
		if (_0023_003DzYP1mbLPa1Hn6 != null)
		{
			_0023_003Dz7m7OtO01ntFBekyLYg_003D_003D(_0023_003DzYP1mbLPa1Hn6);
		}
		if (_0023_003Dz18MpjswfPHE6 != null)
		{
			_0023_003Dz7m7OtO01ntFBekyLYg_003D_003D(_0023_003Dz18MpjswfPHE6);
		}
		if (HdlViewSettings.KeepHiddenSegments)
		{
			if (_0023_003DzyrfqyvnF0yLf != null)
			{
				_0023_003Dz7m7OtO01ntFBekyLYg_003D_003D(_0023_003DzyrfqyvnF0yLf);
			}
			if (_0023_003DzCntTTb6_0024ylA6ae1s5A_003D_003D != null)
			{
				_0023_003Dz7m7OtO01ntFBekyLYg_003D_003D(_0023_003DzCntTTb6_0024ylA6ae1s5A_003D_003D);
			}
			if (_0023_003DzuEN6qKPJwlqve1bSzQyu9lY_003D != null)
			{
				_0023_003Dz7m7OtO01ntFBekyLYg_003D_003D(_0023_003DzuEN6qKPJwlqve1bSzQyu9lY_003D);
			}
		}
		_0023_003Dz7m7OtO01ntFBekyLYg_003D_003D(wireAndTriangleDatas);
		_0023_003Dz7m7OtO01ntFBekyLYg_003D_003D(_0023_003Dz89MX302ggzaN);
		_0023_003Dzy5vjFeQzzmmZ(0.0, 0.0, HdlViewSettings.newOldViewportRatio, _0023_003DzEvYbKUFCkpS4OvewBg_003D_003D);
		if (HdlViewSettings.boxMax != null)
		{
			HdlViewSettings.boxMax = new Point2D(HdlViewSettings.boxMax.X * HdlViewSettings.newOldViewportRatio, HdlViewSettings.boxMax.Y * HdlViewSettings.newOldViewportRatio);
		}
		if (HdlViewSettings.boxMin != null)
		{
			HdlViewSettings.boxMin = new Point2D(HdlViewSettings.boxMin.X * HdlViewSettings.newOldViewportRatio, HdlViewSettings.boxMin.Y * HdlViewSettings.newOldViewportRatio);
		}
		HiddenLinesViewSettings._0023_003DzuvFJnrNKDlc7(HdlViewSettings.Camera, HdlViewSettings.hdlViewMode, HdlViewSettings.newOldViewportRatio, ref HdlViewSettings.ViewportSize, ref HdlViewSettings.Window, out HdlViewSettings._0023_003DzVYKAyIXbkWOU);
	}

	private void _0023_003Dz7m7OtO01ntFBekyLYg_003D_003D(IReadOnlyList<SilhoWireData> _0023_003DzdVNMNH_MwDtK)
	{
		_0023_003DzpRmXznGBaXfvsVk8Yg_003D_003D(0.0, 0.0, HdlViewSettings.newOldViewportRatio, _0023_003DzdVNMNH_MwDtK);
	}

	private void _0023_003Dz7m7OtO01ntFBekyLYg_003D_003D(List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzcDEsV8s_003D)
	{
		foreach (_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT item in _0023_003DzcDEsV8s_003D)
		{
			item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0] *= HdlViewSettings.newOldViewportRatio;
			item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1] *= HdlViewSettings.newOldViewportRatio;
			item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3] *= HdlViewSettings.newOldViewportRatio;
			item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4] *= HdlViewSettings.newOldViewportRatio;
		}
	}

	private void _0023_003Dz7m7OtO01ntFBekyLYg_003D_003D(List<_0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN> _0023_003DzcDEsV8s_003D)
	{
		foreach (_0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN item in _0023_003DzcDEsV8s_003D)
		{
			_0023_003Dz7m7OtO01ntFBekyLYg_003D_003D(item._0023_003DzqPk52tIIDIJe());
			for (int i = 0; i < item._0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D().Length; i++)
			{
				item._0023_003DzWq6ER1G_0024J5sbriqkcxXm_0024iU_003D()[i] *= HdlViewSettings.newOldViewportRatio;
			}
		}
	}

	private void _0023_003Dz7m7OtO01ntFBekyLYg_003D_003D(List<_0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU> _0023_003DzcDEsV8s_003D)
	{
		foreach (_0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU item in _0023_003DzcDEsV8s_003D)
		{
			for (int i = 0; i < item._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D().Length; i++)
			{
				item._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D()[i] *= HdlViewSettings.newOldViewportRatio;
			}
		}
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		_0023_003DzTtgGeeqBjD2i = -1;
		_0023_003DzzIrgzh87xtI_EdP2YA_003D_003D = true;
		_0023_003DzwJ3QaGJFHQh4 = 3;
		_0023_003DzIA8GcQ0_003D(_0023_003DzvKQ6k8f_e9AV: false);
		List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> list = new List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>();
		List<_0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN> list2 = new List<_0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN>();
		List<_0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU> list3 = new List<_0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU>();
		wireAndTriangleDatas = new List<SilhoWireAndTriangleData>();
		_0023_003Dz89MX302ggzaN = new List<_0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D>();
		_0023_003Dz37D_0024CERewGZnCIRD84lljEfRoWC8K5_0024gkRkMTX0_003D(progress, ct, list, wireAndTriangleDatas, list2, list3);
		_0023_003DzYP1mbLPa1Hn6 = list2;
		_0023_003Dz18MpjswfPHE6 = list3;
		if (list.Count == 0 && list2.Count == 0 && list3.Count == 0)
		{
			if (wireAndTriangleDatas != null)
			{
				HiddenLinesViewSettings._0023_003DzF6xWLztjwz7t(wireAndTriangleDatas, out HdlViewSettings.boxMin, out HdlViewSettings.boxMax);
			}
			_0023_003Dz7m7OtO01ntFBekyLYg_003D_003D();
			_0023_003DzVq_rQxw0kQMtblXdkEJzELk_003D(new HdlCurve[0]);
			_0023_003DzXh_0024_c3AiFf_00248(new HdlCurve[0]);
			_0023_003DzXYNwQUGUceBK(new HdlCurve[0]);
			_0023_003Dz1ysqp8Yxm25nozhVs0x3LAk_003D(new HdlCurve[0]);
			_0023_003DzipnGqfumV5Bq(new HdlCurve[0]);
			_0023_003Dz3zsJBoZg_sNWWwZM_0024A_003D_003D(new HdlCurve[0]);
		}
		else
		{
			_0023_003DzIkowfAsYgs9l(progress, ct, list, list2, list3, _0023_003DzuvkktNA2OHo_vIbJ7Q_003D_003D);
			UpdateProgressTo100(_0023_003Dz3lURioVh8358, progress);
		}
	}

	private void _0023_003DzIA8GcQ0_003D(bool _0023_003DzvKQ6k8f_e9AV)
	{
		if (_0023_003DzvKQ6k8f_e9AV)
		{
			if (HdlViewSettings.hdlViewMode == hiddenLinesViewType.Extents || (HdlViewSettings.Camera.ProjectionMode == projectionType.Orthographic && HdlViewSettings.hdlViewMode == hiddenLinesViewType.Viewport))
			{
				_0023_003DzuvkktNA2OHo_vIbJ7Q_003D_003D = false;
			}
			else
			{
				_0023_003DzuvkktNA2OHo_vIbJ7Q_003D_003D = true;
			}
			_0023_003DzheS2h4tdfFfa = HdlViewSettings.hdlViewMode == hiddenLinesViewType.Window;
			_0023_003DzmPTqpRCcACPhYmg7UTvB9WI_003D = HdlViewSettings.Camera.GetFrustum(HdlViewSettings.ViewBounds, _0023_003Dz_OlmZyU_003D: false);
			_0023_003DzjCqtHKg_003D = HdlViewSettings.GetGfxAttributes();
			HdlViewSettings._0023_003DzA8ZfmVFtMUmw = new List<SilhoWireData>();
		}
		HdlViewSettings._0023_003DzA8ZfmVFtMUmw.AddRange(_0023_003Dz_0024AYrdXI3HY9d<GfxAttributesWire>(new PreProcessSilhouettesParams
		{
			MaxPatternRepetitions = HdlViewSettings.MaxPatternRepetitions,
			Parents = new Stack<BlockReference>(),
			FrustumParams = new FrustumParams(_0023_003DzmPTqpRCcACPhYmg7UTvB9WI_003D, _0023_003DzrYojqqg_003D: true, HdlViewSettings.document),
			Camera = HdlViewSettings.Camera,
			Blocks = HdlViewSettings._0023_003DzZbAhroU_003D,
			Entities = HdlViewSettings._0023_003DzpagGO1c_003D,
			LineTypes = HdlViewSettings._0023_003DzAVrMnB8_003D,
			Layers = HdlViewSettings.Layers,
			Materials = HdlViewSettings._0023_003DzXnYgAZR3DgQjnDS1gQ_003D_003D,
			FontTolerance = HdlViewSettings.FontAccuracy,
			Document = HdlViewSettings.document,
			EntitiesToHide = HdlViewSettings.EntitiesToHide,
			CheckFrustum = _0023_003DzuvkktNA2OHo_vIbJ7Q_003D_003D,
			Attributes = _0023_003DzjCqtHKg_003D,
			FillTexts = HdlViewSettings.FillTexts,
			FillRegions = HdlViewSettings.FillRegions,
			KeepHiddenSegments = HdlViewSettings.KeepHiddenSegments,
			CollectTextsOnly = _0023_003DzvKQ6k8f_e9AV
		}));
		if (!_0023_003DzvKQ6k8f_e9AV)
		{
			_0023_003DzmPTqpRCcACPhYmg7UTvB9WI_003D = null;
			_0023_003DzjCqtHKg_003D = null;
		}
	}

	private static void _0023_003DzQWLz9EiVIfJ8uaruVw_003D_003D(bool[] _0023_003Dz2wjxF5y1xC5ttAykyQ_003D_003D, int[] _0023_003DzqDFBISpCePlj, _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzELu0Pss_003D, bool _0023_003DzxplST8guPds9o8nyigu3EaI_003D)
	{
		_0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom[] _0023_003DzZSnvfVF8Y5Qg = _0023_003DzELu0Pss_003D._0023_003DzZSnvfVF8Y5Qg;
		bool[] _0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D = _0023_003DzELu0Pss_003D._0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D;
		int num = _0023_003DzZSnvfVF8Y5Qg.Length;
		double _0023_003DzeMBeuAQ_003D = _0023_003DzqDFBISpCePlj[0];
		double _0023_003DznYtQKck_003D = _0023_003DzqDFBISpCePlj[0] + _0023_003DzqDFBISpCePlj[2];
		double _0023_003Dz5F7_i_0024U_003D = _0023_003DzqDFBISpCePlj[1];
		double _0023_003DzXmrDMdc_003D = _0023_003DzqDFBISpCePlj[1] + _0023_003DzqDFBISpCePlj[3];
		for (int i = 0; i < num; i++)
		{
			if (_0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D[i])
			{
				continue;
			}
			int[] array = _0023_003DzZSnvfVF8Y5Qg[i]._0023_003DzhMDfC7g_003D[0];
			int num2 = array.Length;
			bool flag = false;
			bool flag2 = _0023_003Dz2wjxF5y1xC5ttAykyQ_003D_003D[array[0]];
			for (int j = 1; j < num2; j++)
			{
				if (flag2 ^ _0023_003Dz2wjxF5y1xC5ttAykyQ_003D_003D[array[j]])
				{
					_0023_003DzELu0Pss_003D._0023_003DzwsVdE4aCB04rlTu9E7BEoXkNDRGraWob5A_003D_003D[i] = true;
					flag = true;
					break;
				}
			}
			bool flag3 = (_0023_003DzxplST8guPds9o8nyigu3EaI_003D ? (flag2 || flag) : (flag2 && !flag));
			if (!flag3)
			{
				flag3 = _0023_003DzDiiN7lIGF2cL6JLrTg_003D_003D(_0023_003DzeMBeuAQ_003D, _0023_003DznYtQKck_003D, _0023_003Dz5F7_i_0024U_003D, _0023_003DzXmrDMdc_003D, _0023_003DzELu0Pss_003D.ScreenVertices, array);
			}
			_0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D[i] = flag3;
		}
	}

	private void _0023_003Dz37D_0024CERewGZnCIRD84lljEfRoWC8K5_0024gkRkMTX0_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003Dz_Hkj4ZwK_00241kG, List<SilhoWireAndTriangleData> _0023_003Dz_0024Ii9GBWc3xfYTPyaXQ_003D_003D, List<_0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN> _0023_003DzFSLjUUdsuQJnRYaCrg_003D_003D, List<_0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU> _0023_003DzV9QMPP_GfOVW)
	{
		int count = HdlViewSettings._0023_003DzA8ZfmVFtMUmw.Count;
		_0023_003DzTtgGeeqBjD2i++;
		_0023_003Dz3lURioVh8358 = ComputingSilhouettesText;
		UpdateProgress(_0023_003DzTtgGeeqBjD2i, _0023_003DzwJ3QaGJFHQh4, _0023_003Dz3lURioVh8358, _0023_003DzmHS7frs_003D);
		int num = _0023_003Dz5Faw6jTsdRm7wsDgbA_003D_003D(count);
		double[] modelViewProjectionMatrix = HdlViewSettings.Camera.GetModelViewProjectionMatrix();
		Plane _0023_003Dz__4OfIpVgJ6A = HdlViewSettings.Camera.NearPlane;
		int[] viewBounds = HdlViewSettings.ViewBounds;
		bool flag = HdlViewSettings.SectionPlane != null;
		if (flag)
		{
			Camera.Project(HdlViewSettings.Camera.renderContext, modelViewProjectionMatrix, viewBounds, HdlViewSettings.SectionPlane.Origin.X, HdlViewSettings.SectionPlane.Origin.Y, HdlViewSettings.SectionPlane.Origin.Z, out var _, out var _, out _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D);
			_0023_003Dz__4OfIpVgJ6A = HdlViewSettings.SectionPlane;
		}
		for (int i = 0; i < count; i++)
		{
			SilhoWireData silhoWireData = HdlViewSettings._0023_003DzA8ZfmVFtMUmw[i];
			_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzUpNcQcY_003D;
			List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> list = _0023_003DzFIG4fZTg8nRADXOYjRTDqt4_003D(silhoWireData, _0023_003Dz_0024Ii9GBWc3xfYTPyaXQ_003D_003D, _0023_003DzV9QMPP_GfOVW, modelViewProjectionMatrix, _0023_003Dz__4OfIpVgJ6A, flag, out _0023_003DzUpNcQcY_003D);
			if (silhoWireData.Entity is Picture picture)
			{
				_0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN _0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN2 = new _0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN(silhoWireData.ScreenVertices, new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>(list), silhoWireData.Attributes, new AssemblyLeaf(picture, silhoWireData.Parents), picture.Image);
				if (_0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN2._0023_003DzX53zKJ7F8pm2() != 0.0 && _0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN2._0023_003DzyPvkXDxXMAaa() != 0.0)
				{
					_0023_003DzFSLjUUdsuQJnRYaCrg_003D_003D.Add(_0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN2);
				}
			}
			else
			{
				if (_0023_003DzUpNcQcY_003D != null)
				{
					HdlViewSettings._0023_003DzA8ZfmVFtMUmw.Add(_0023_003DzUpNcQcY_003D);
				}
				if (list != null)
				{
					_0023_003Dz_Hkj4ZwK_00241kG.AddRange(list);
				}
			}
			if (!UpdateProgressAndCheckCancelledParallel(num, _0023_003Dz3lURioVh8358, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				break;
			}
		}
	}

	internal int _0023_003Dz5Faw6jTsdRm7wsDgbA_003D_003D(int _0023_003Dzb0gN7Lkt2M64)
	{
		double num = 100.0 * (double)_0023_003DzTtgGeeqBjD2i / (double)_0023_003DzwJ3QaGJFHQh4;
		double num2 = 100.0 * (double)(_0023_003DzTtgGeeqBjD2i + 1) / (double)_0023_003DzwJ3QaGJFHQh4;
		double num3 = (double)(_0023_003Dzb0gN7Lkt2M64 * 100) / (num2 - num);
		double num4 = num3 * num / 100.0;
		ResetProgressParallel((int)num4);
		return (int)num3;
	}

	private bool _0023_003Dz3qZHwoB6iCYc(ref List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzyIUKu5w_003D, RectangleF _0023_003Dzl1cXRIw_003D, double _0023_003DzxH4ozIo_003D, Point2D _0023_003DzDPcjoBJLcqli, Point2D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		double num = _0023_003Dzl1cXRIw_003D.Left;
		double num2 = _0023_003Dzl1cXRIw_003D.Right;
		double num3 = _0023_003Dzl1cXRIw_003D.Top;
		double num4 = _0023_003Dzl1cXRIw_003D.Bottom;
		if (_0023_003DzDPcjoBJLcqli.X >= num && _0023_003DzDPcjoBJLcqli.Y >= num3 && _0023_003Dz_0024N_0024yKptW9BoC.X <= num2 && _0023_003Dz_0024N_0024yKptW9BoC.Y <= num4)
		{
			return false;
		}
		Segment2D[] _0023_003Dz_oVe_0024WR7VqvS = new Segment2D[4]
		{
			new Segment2D(num, num3, num2, num3),
			new Segment2D(num2, num3, num2, num4),
			new Segment2D(num2, num4, num, num4),
			new Segment2D(num, num4, num, num3)
		};
		List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> list = new List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>();
		for (int i = 0; i < _0023_003DzyIUKu5w_003D.Count; i++)
		{
			if (_0023_003DzSdkV8uwpdqAg6qJ6lQ_003D_003D(_0023_003DzyIUKu5w_003D, _0023_003Dz_oVe_0024WR7VqvS, num, num2, num3, num4, i, out var _0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D, _0023_003DzxH4ozIo_003D))
			{
				_0023_003DzyIUKu5w_003D[i]._0023_003Dzk98RESByZO6KwZuGTA_003D_003D = _0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D;
				list.Add(_0023_003DzyIUKu5w_003D[i]);
			}
		}
		_0023_003DzyIUKu5w_003D = list;
		return true;
	}

	private bool _0023_003DzSdkV8uwpdqAg6qJ6lQ_003D_003D(List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzyIUKu5w_003D, Segment2D[] _0023_003Dz_oVe_0024WR7VqvS, double _0023_003DzeMBeuAQ_003D, double _0023_003DznYtQKck_003D, double _0023_003Dz5F7_i_0024U_003D, double _0023_003DzXmrDMdc_003D, int _0023_003DzyzK8swU_003D, out double[] _0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D, double _0023_003DzxH4ozIo_003D)
	{
		double[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D = _0023_003DzyIUKu5w_003D[_0023_003DzyzK8swU_003D]._0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
		Segment2D segment2D = new Segment2D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4]);
		_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D = null;
		if (segment2D.P0.Y < _0023_003Dz5F7_i_0024U_003D && segment2D.P1.Y < _0023_003Dz5F7_i_0024U_003D)
		{
			return false;
		}
		if (segment2D.P0.X > _0023_003DznYtQKck_003D && segment2D.P1.X > _0023_003DznYtQKck_003D)
		{
			return false;
		}
		if (segment2D.P0.Y > _0023_003DzXmrDMdc_003D && segment2D.P1.Y > _0023_003DzXmrDMdc_003D)
		{
			return false;
		}
		if (segment2D.P0.X < _0023_003DzeMBeuAQ_003D && segment2D.P1.X < _0023_003DzeMBeuAQ_003D)
		{
			return false;
		}
		_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D = new double[6]
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0],
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1],
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[2],
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3],
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4],
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[5]
		};
		double[] _0023_003DzeEk0BGeXmyvR = new double[3];
		bool flag = false;
		if (Segment2D.Intersection(_0023_003Dz_oVe_0024WR7VqvS[0], segment2D, out var i, out var i2, _0023_003DzxH4ozIo_003D) != segmentIntersectionType.Disjoint)
		{
			flag = true;
			_0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D._0023_003Dznql2Kp4kdMT3ZawnYKViM1w_003D(segment2D, i, _0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D, ref _0023_003DzeEk0BGeXmyvR);
			if (segment2D.P0.Y > i.Y)
			{
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[3] = _0023_003DzeEk0BGeXmyvR[0];
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[4] = _0023_003DzeEk0BGeXmyvR[1];
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[5] = _0023_003DzeEk0BGeXmyvR[2];
				segment2D = new Segment2D(segment2D.P0, i);
			}
			else
			{
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[0] = _0023_003DzeEk0BGeXmyvR[0];
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[1] = _0023_003DzeEk0BGeXmyvR[1];
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[2] = _0023_003DzeEk0BGeXmyvR[2];
				segment2D = new Segment2D(i, segment2D.P1);
			}
		}
		if (Segment2D.Intersection(_0023_003Dz_oVe_0024WR7VqvS[1], segment2D, out i, out i2, _0023_003DzxH4ozIo_003D) != segmentIntersectionType.Disjoint)
		{
			flag = true;
			_0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D._0023_003Dznql2Kp4kdMT3ZawnYKViM1w_003D(segment2D, i, _0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D, ref _0023_003DzeEk0BGeXmyvR);
			if (segment2D.P0.X < i.X)
			{
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[3] = _0023_003DzeEk0BGeXmyvR[0];
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[4] = _0023_003DzeEk0BGeXmyvR[1];
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[5] = _0023_003DzeEk0BGeXmyvR[2];
				segment2D = new Segment2D(segment2D.P0, i);
			}
			else
			{
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[0] = _0023_003DzeEk0BGeXmyvR[0];
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[1] = _0023_003DzeEk0BGeXmyvR[1];
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[2] = _0023_003DzeEk0BGeXmyvR[2];
				segment2D = new Segment2D(i, segment2D.P1);
			}
		}
		if (Segment2D.Intersection(_0023_003Dz_oVe_0024WR7VqvS[2], segment2D, out i, out i2, _0023_003DzxH4ozIo_003D) != segmentIntersectionType.Disjoint)
		{
			flag = true;
			_0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D._0023_003Dznql2Kp4kdMT3ZawnYKViM1w_003D(segment2D, i, _0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D, ref _0023_003DzeEk0BGeXmyvR);
			if (segment2D.P0.Y < i.Y)
			{
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[3] = _0023_003DzeEk0BGeXmyvR[0];
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[4] = _0023_003DzeEk0BGeXmyvR[1];
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[5] = _0023_003DzeEk0BGeXmyvR[2];
				segment2D = new Segment2D(segment2D.P0, i);
			}
			else
			{
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[0] = _0023_003DzeEk0BGeXmyvR[0];
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[1] = _0023_003DzeEk0BGeXmyvR[1];
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[2] = _0023_003DzeEk0BGeXmyvR[2];
				segment2D = new Segment2D(i, segment2D.P1);
			}
		}
		if (Segment2D.Intersection(_0023_003Dz_oVe_0024WR7VqvS[3], segment2D, out i, out i2, _0023_003DzxH4ozIo_003D) != segmentIntersectionType.Disjoint)
		{
			flag = true;
			_0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D._0023_003Dznql2Kp4kdMT3ZawnYKViM1w_003D(segment2D, i, _0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D, ref _0023_003DzeEk0BGeXmyvR);
			if (segment2D.P0.X > i.X)
			{
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[3] = _0023_003DzeEk0BGeXmyvR[0];
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[4] = _0023_003DzeEk0BGeXmyvR[1];
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[5] = _0023_003DzeEk0BGeXmyvR[2];
			}
			else
			{
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[0] = _0023_003DzeEk0BGeXmyvR[0];
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[1] = _0023_003DzeEk0BGeXmyvR[1];
				_0023_003DzRwIy4Q0rQnvgv1RTqQ_003D_003D[2] = _0023_003DzeEk0BGeXmyvR[2];
			}
		}
		if (!flag && _0023_003DzdoKjaErObgdW(segment2D.P0, _0023_003DzeMBeuAQ_003D, _0023_003DznYtQKck_003D, _0023_003Dz5F7_i_0024U_003D, _0023_003DzXmrDMdc_003D) && _0023_003DzdoKjaErObgdW(segment2D.P1, _0023_003DzeMBeuAQ_003D, _0023_003DznYtQKck_003D, _0023_003Dz5F7_i_0024U_003D, _0023_003DzXmrDMdc_003D))
		{
			return false;
		}
		return true;
	}

	private bool _0023_003DzdoKjaErObgdW(Point2D _0023_003DzMlCq3wk_003D, double _0023_003DzeMBeuAQ_003D, double _0023_003DznYtQKck_003D, double _0023_003Dz5F7_i_0024U_003D, double _0023_003DzXmrDMdc_003D)
	{
		if (!(_0023_003DzMlCq3wk_003D.X < _0023_003DzeMBeuAQ_003D) && !(_0023_003DzMlCq3wk_003D.X > _0023_003DznYtQKck_003D))
		{
			if (!(_0023_003DzMlCq3wk_003D.Y < _0023_003Dz5F7_i_0024U_003D))
			{
				return _0023_003DzMlCq3wk_003D.Y > _0023_003DzXmrDMdc_003D;
			}
			return true;
		}
		return true;
	}

	private List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzFIG4fZTg8nRADXOYjRTDqt4_003D(SilhoWireData _0023_003DzELu0Pss_003D, List<SilhoWireAndTriangleData> _0023_003Dz_0024Ii9GBWc3xfYTPyaXQ_003D_003D, List<_0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU> _0023_003DzG6I_afQQrNaH, double[] _0023_003DzypMGqyMVO5qA, Plane _0023_003Dz__4OfIpVgJ6A, bool _0023_003DzSYE74fyHy8Zx, out _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzUpNcQcY_003D)
	{
		Camera camera = HdlViewSettings.Camera;
		int[] viewBounds = HdlViewSettings.ViewBounds;
		_0023_003DzUpNcQcY_003D = null;
		List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzewBcmhf9rM_00244Wus89w_003D_003D = null;
		_0023_003DzELu0Pss_003D.ComputeScreenVertices(camera.renderContext, _0023_003DzypMGqyMVO5qA, viewBounds);
		bool flag = _0023_003DzR27I3J1dRCld(camera, _0023_003DzypMGqyMVO5qA, viewBounds, _0023_003DzELu0Pss_003D, _0023_003DzG6I_afQQrNaH);
		if (!(_0023_003DzELu0Pss_003D is _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D))
		{
			if (!flag)
			{
				_0023_003DzfPpr_N3EJgE60_VJMNNhZuo_003D(camera, _0023_003DzypMGqyMVO5qA, viewBounds, HdlViewSettings.Window, _0023_003DzELu0Pss_003D, _0023_003Dz__4OfIpVgJ6A, out _0023_003DzewBcmhf9rM_00244Wus89w_003D_003D, _0023_003Dz_0024Ii9GBWc3xfYTPyaXQ_003D_003D, _0023_003DzuvkktNA2OHo_vIbJ7Q_003D_003D, _0023_003DzheS2h4tdfFfa);
			}
		}
		else
		{
			_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2 = (_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D)_0023_003DzELu0Pss_003D;
			_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D = new bool[_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzZSnvfVF8Y5Qg.Length];
			_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzwsVdE4aCB04rlTu9E7BEoXkNDRGraWob5A_003D_003D = new bool[_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzZSnvfVF8Y5Qg.Length];
			bool[] array = new bool[_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2.ScreenVertices.GetLength(0)];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _0023_003DzVkP_0024OJUt_0024tuH(_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2.ScreenVertices[i, 2], _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D);
			}
			bool flag2 = array.Contains(value: true) && array.Contains(value: false);
			if (_0023_003DzuvkktNA2OHo_vIbJ7Q_003D_003D || _0023_003DzSYE74fyHy8Zx)
			{
				_0023_003DzQWLz9EiVIfJ8uaruVw_003D_003D(array, viewBounds, _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2, !_0023_003DzSYE74fyHy8Zx);
				if (flag2 && !_0023_003DzSYE74fyHy8Zx)
				{
					_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003Dzxhr71LaqxMWZ(_0023_003DzPzO_0024GUk_003D: false);
				}
			}
			Utility._0023_003Dz36sbfVCTXh1L(_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzZSnvfVF8Y5Qg, _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2.Vertices.GetLength(0), out var _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, _0023_003DzZgSQ1WpOFIne: false);
			_0023_003DzJKZno7G_LQRSMf9GWm6R_0024Qs_003D(_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2, array, _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, out _0023_003DzewBcmhf9rM_00244Wus89w_003D_003D);
			if (flag2)
			{
				if (_0023_003DzSYE74fyHy8Zx)
				{
					if (_0023_003DzELu0Pss_003D.Transformation != null)
					{
						_0023_003Dz__4OfIpVgJ6A = (Plane)_0023_003Dz__4OfIpVgJ6A.Clone();
						Transformation transformation = (Transformation)_0023_003DzELu0Pss_003D.Transformation.Clone();
						transformation.Invert();
						_0023_003Dz__4OfIpVgJ6A.TransformBy(transformation);
					}
					_0023_003DzUpNcQcY_003D = _0023_003DzI1KZmlQ3bC8Gl2FaHA_003D_003D(_0023_003Dz__4OfIpVgJ6A, _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2);
				}
				else
				{
					_0023_003DzUpNcQcY_003D = _0023_003DzNjFDW8MzEkv9VwzRowpEbjzCdhZ4nALbTA_003D_003D(_0023_003DzELu0Pss_003D.Entity, _0023_003DzELu0Pss_003D.Parents, _0023_003Dz__4OfIpVgJ6A, _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2, array, _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D);
				}
				if (_0023_003DzUpNcQcY_003D != null)
				{
					_0023_003DzUpNcQcY_003D.ComputeScreenVertices(camera.renderContext, _0023_003DzypMGqyMVO5qA, viewBounds);
					if (_0023_003DzSYE74fyHy8Zx)
					{
						((_0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D)_0023_003DzUpNcQcY_003D)._0023_003Dz0a2mD4XWI3cV(_0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D);
					}
					_0023_003DzUpNcQcY_003D._0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D = new bool[_0023_003DzUpNcQcY_003D._0023_003DzZSnvfVF8Y5Qg.Length];
					_0023_003DzUpNcQcY_003D._0023_003DzwsVdE4aCB04rlTu9E7BEoXkNDRGraWob5A_003D_003D = new bool[_0023_003DzUpNcQcY_003D._0023_003DzZSnvfVF8Y5Qg.Length];
					Utility._0023_003Dz36sbfVCTXh1L(_0023_003DzUpNcQcY_003D._0023_003DzZSnvfVF8Y5Qg, _0023_003DzUpNcQcY_003D.Vertices.GetLength(0), out _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, _0023_003DzZgSQ1WpOFIne: false);
					_0023_003DzJKZno7G_LQRSMf9GWm6R_0024Qs_003D(_0023_003DzUpNcQcY_003D, new bool[_0023_003DzUpNcQcY_003D.ScreenVertices.GetLength(0)], _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, out var _0023_003DzewBcmhf9rM_00244Wus89w_003D_003D2);
					if (_0023_003DzSYE74fyHy8Zx)
					{
						_0023_003Dz89MX302ggzaN.Add((_0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D)_0023_003DzUpNcQcY_003D);
						double scaleFactor = 1.0;
						if ((_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2.Entity is Brep || _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2.Entity is Surface) && (_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2.Transformation == null || _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2.Transformation.IsScaleFactorUniform() || _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2.Transformation.IsScaleFactorUniformForPlanar(_0023_003Dz__4OfIpVgJ6A, ref scaleFactor)))
						{
							_0023_003DzEvYbKUFCkpS4OvewBg_003D_003D.AddRange(_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzEYc93l4qAj85V49lUA_003D_003D(_0023_003Dz__4OfIpVgJ6A, camera.renderContext, _0023_003DzypMGqyMVO5qA, viewBounds));
							_0023_003DzewBcmhf9rM_00244Wus89w_003D_003D2.ForEach(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzFKVOKZLD9j4ZGvC6FuKG2efbDjiJLrTfRtQGyJA_003D);
						}
					}
					_0023_003DzewBcmhf9rM_00244Wus89w_003D_003D.AddRange(_0023_003DzewBcmhf9rM_00244Wus89w_003D_003D2);
				}
			}
			if (!HdlViewSettings.IgnoreTransparency && _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2.Attributes.GetColor().A != byte.MaxValue)
			{
				_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzZSnvfVF8Y5Qg = Array.Empty<_0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom>();
				_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D = Array.Empty<bool>();
				if (_0023_003DzUpNcQcY_003D != null)
				{
					if (_0023_003DzSYE74fyHy8Zx)
					{
						for (int j = 0; j < _0023_003DzUpNcQcY_003D._0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D.Length; j++)
						{
							_0023_003DzUpNcQcY_003D._0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D[j] = true;
						}
					}
					else
					{
						_0023_003DzUpNcQcY_003D._0023_003DzZSnvfVF8Y5Qg = Array.Empty<_0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom>();
						_0023_003DzUpNcQcY_003D._0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D = Array.Empty<bool>();
					}
				}
			}
		}
		return _0023_003DzewBcmhf9rM_00244Wus89w_003D_003D;
	}

	private bool _0023_003DzR27I3J1dRCld(Camera _0023_003DzztLIRQOxCyGw, double[] _0023_003DzypMGqyMVO5qA, int[] _0023_003DzqDFBISpCePlj, SilhoWireData _0023_003DzELu0Pss_003D, List<_0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU> _0023_003DzG6I_afQQrNaH)
	{
		bool result = false;
		if (_0023_003DzELu0Pss_003D is _0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D { _0023_003DzcEFLt3aiIQTq: not false } _0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D2)
		{
			result = !(_0023_003DzELu0Pss_003D.Entity is Dimension) && !(_0023_003DzELu0Pss_003D.Entity is Balloon) && !(_0023_003DzELu0Pss_003D.Entity is SectionLine);
			_0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D2._0023_003DzT6h2a5Uo_xh_k0A373XWitc_003D(_0023_003DzztLIRQOxCyGw.renderContext, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj);
			Text text = (Text)_0023_003DzELu0Pss_003D.Entity;
			int num = _0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D2._0023_003DzyEHfeaefm2j6YGUAZ7IhouA_003D.GetLength(0) / 4;
			for (int i = 0; i < num; i++)
			{
				double[,] array = new double[4, 3];
				Array.Copy(_0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D2._0023_003DzyEHfeaefm2j6YGUAZ7IhouA_003D, i * 12, array, 0, 12);
				_0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU item = new _0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU(array, _0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D2.Attributes, new AssemblyLeaf(text, _0023_003DzELu0Pss_003D.Parents), HdlViewSettings._0023_003DzjWOIYmI_003D[text.StyleName], i);
				_0023_003DzG6I_afQQrNaH.Add(item);
			}
		}
		return result;
	}

	private void _0023_003DzfPpr_N3EJgE60_VJMNNhZuo_003D(Camera _0023_003DzztLIRQOxCyGw, double[] _0023_003DzypMGqyMVO5qA, int[] _0023_003DzqDFBISpCePlj, RectangleF _0023_003DzyeA5XEs_003D, SilhoWireData _0023_003DzELu0Pss_003D, Plane _0023_003Dzuuj78OZLJwEDNvgr8g_003D_003D, out List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzF4nIR5upQJX9, List<SilhoWireAndTriangleData> _0023_003DzXX_0024HJ9f3o_0024iJVVO3P9cO6ac_003D, bool _0023_003Dz1UarNw8gnQy8iQVO4A_003D_003D, bool _0023_003Dzbr5_0024DNI_003D)
	{
		_0023_003DzF4nIR5upQJX9 = new List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>();
		int num = ((_0023_003DzELu0Pss_003D.DataMode == silhoDataType.LineStrip) ? 1 : 2);
		if (_0023_003DzELu0Pss_003D is SilhoWireAndTriangleData && HdlViewSettings._0023_003Dza5erRGs_0024Kve7() && _0023_003DzELu0Pss_003D.DataMode == silhoDataType.TriangleList)
		{
			if (!_0023_003DzngaD_0024tqET14ChhxneA_003D_003D(_0023_003DzztLIRQOxCyGw, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, _0023_003DzyeA5XEs_003D, _0023_003DzELu0Pss_003D, _0023_003Dz1UarNw8gnQy8iQVO4A_003D_003D, _0023_003Dzbr5_0024DNI_003D))
			{
				_0023_003DzXX_0024HJ9f3o_0024iJVVO3P9cO6ac_003D.Add((SilhoWireAndTriangleData)_0023_003DzELu0Pss_003D);
			}
			return;
		}
		projectionType projectionMode = _0023_003DzztLIRQOxCyGw.ProjectionMode;
		int num2 = ((_0023_003DzELu0Pss_003D.startPointVertices < 0) ? _0023_003DzELu0Pss_003D.Vertices.GetLength(0) : _0023_003DzELu0Pss_003D.startPointVertices);
		if (projectionMode == projectionType.Perspective)
		{
			for (int i = 1; i < num2; i += num)
			{
				bool flag = _0023_003DzVkP_0024OJUt_0024tuH(_0023_003DzELu0Pss_003D.ScreenVertices[i, 2], _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D);
				bool flag2 = _0023_003DzVkP_0024OJUt_0024tuH(_0023_003DzELu0Pss_003D.ScreenVertices[i - 1, 2], _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D);
				if (!flag && !flag2)
				{
					_0023_003DzkVGo4dw_003D(_0023_003DzELu0Pss_003D, i, i - 1, -1, -1, HiddenLinesViewSettings.lineType.Wire, _0023_003DzF4nIR5upQJX9, _0023_003DzaaJHKt4_003D: false, -1, _0023_003DzWEBs53zXCVqc9JdZiw_003D_003D: false);
				}
				else if (flag ^ flag2)
				{
					_0023_003DzyCK6H_X8109MGZUpK5ArHCk_003D(_0023_003DzztLIRQOxCyGw.renderContext, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, _0023_003DzELu0Pss_003D, _0023_003Dzuuj78OZLJwEDNvgr8g_003D_003D, i, i - 1, flag, _0023_003DzF4nIR5upQJX9);
				}
			}
			if (_0023_003DzELu0Pss_003D.startPointVertices < 0)
			{
				return;
			}
			for (int j = _0023_003DzELu0Pss_003D.startPointVertices; j < _0023_003DzELu0Pss_003D.Vertices.GetLength(0); j++)
			{
				if (!_0023_003DzVkP_0024OJUt_0024tuH(_0023_003DzELu0Pss_003D.ScreenVertices[j, 2], _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D))
				{
					_0023_003Dzs5c8Do0_003D(_0023_003DzELu0Pss_003D, j, _0023_003DzF4nIR5upQJX9);
				}
			}
			return;
		}
		for (int k = 1; k < num2; k += num)
		{
			_0023_003DzkVGo4dw_003D(_0023_003DzELu0Pss_003D, k, k - 1, -1, -1, HiddenLinesViewSettings.lineType.Wire, _0023_003DzF4nIR5upQJX9, _0023_003DzaaJHKt4_003D: false, -1, _0023_003DzWEBs53zXCVqc9JdZiw_003D_003D: false);
		}
		if (_0023_003DzELu0Pss_003D.startPointVertices >= 0)
		{
			for (int l = _0023_003DzELu0Pss_003D.startPointVertices; l < _0023_003DzELu0Pss_003D.Vertices.GetLength(0); l++)
			{
				_0023_003Dzs5c8Do0_003D(_0023_003DzELu0Pss_003D, l, _0023_003DzF4nIR5upQJX9);
			}
		}
	}

	private static bool _0023_003DzngaD_0024tqET14ChhxneA_003D_003D(Camera _0023_003DzztLIRQOxCyGw, double[] _0023_003DzypMGqyMVO5qA, int[] _0023_003DzqDFBISpCePlj, RectangleF _0023_003DzyeA5XEs_003D, SilhoWireData _0023_003DzELu0Pss_003D, bool _0023_003Dz1UarNw8gnQy8iQVO4A_003D_003D, bool _0023_003Dzbr5_0024DNI_003D)
	{
		PlaneEquation[] frustum = _0023_003DzztLIRQOxCyGw.GetFrustum(_0023_003DzqDFBISpCePlj, _0023_003Dz_OlmZyU_003D: false);
		Mesh mesh = new Mesh(Mesh.natureType.Plain);
		mesh.LightWeight = true;
		List<Point3D> list = new List<Point3D>();
		if (_0023_003DzELu0Pss_003D.Transformation != null)
		{
			for (int i = 0; i < _0023_003DzELu0Pss_003D.Vertices.GetLength(0); i++)
			{
				list.Add(_0023_003DzELu0Pss_003D.Transformation * new Point3D(_0023_003DzELu0Pss_003D.Vertices[i, 0], _0023_003DzELu0Pss_003D.Vertices[i, 1], _0023_003DzELu0Pss_003D.Vertices[i, 2]));
			}
		}
		else
		{
			for (int j = 0; j < _0023_003DzELu0Pss_003D.Vertices.GetLength(0); j++)
			{
				list.Add(new Point3D(_0023_003DzELu0Pss_003D.Vertices[j, 0], _0023_003DzELu0Pss_003D.Vertices[j, 1], _0023_003DzELu0Pss_003D.Vertices[j, 2]));
			}
		}
		_0023_003DzELu0Pss_003D.Transformation = null;
		mesh.Vertices = list.ToArray();
		int num = 0;
		mesh.Triangles = _0023_003DzHsgErY60pPKafTQsTrhggkcl7Nsq(mesh.Vertices);
		if (_0023_003Dz1UarNw8gnQy8iQVO4A_003D_003D || _0023_003Dzbr5_0024DNI_003D)
		{
			Point3D maxValue = Point3D.MaxValue;
			Point3D minValue = Point3D.MinValue;
			Utility.UpdateMinMax(null, list, list.Count, maxValue, minValue);
			double diagonal = new Size3D(maxValue, minValue).Diagonal;
			if (_0023_003Dz1UarNw8gnQy8iQVO4A_003D_003D && !_0023_003DzV7icIEk_003D(_0023_003DzELu0Pss_003D.Parents))
			{
				Plane[] array = new Plane[6];
				for (int k = 0; k < 6; k++)
				{
					Plane plane = new Plane(frustum[k].ToArray());
					plane.Flip();
					array[k] = plane;
					mesh = _0023_003DzPRxVtxd_DkMM4u1IDmME1m4_003D(mesh, plane, diagonal);
				}
				for (int l = 0; l < 6; l++)
				{
					if (mesh.Vertices.Length == 0)
					{
						break;
					}
					mesh.CutBy(array[l]);
				}
			}
			if (_0023_003Dzbr5_0024DNI_003D)
			{
				double num2 = double.MaxValue;
				double num3 = double.MaxValue;
				double num4 = double.MinValue;
				double num5 = double.MinValue;
				for (int m = 0; m < _0023_003DzELu0Pss_003D.ScreenVertices.GetLength(0); m++)
				{
					double num6 = _0023_003DzELu0Pss_003D.ScreenVertices[m, 0];
					double num7 = _0023_003DzELu0Pss_003D.ScreenVertices[m, 1];
					num4 = ((num6 > num4) ? num6 : num4);
					num5 = ((num7 > num5) ? num7 : num5);
					num2 = ((num6 < num2) ? num6 : num2);
					num3 = ((num7 < num3) ? num7 : num3);
				}
				if (!(num4 > (double)_0023_003DzyeA5XEs_003D.X) || !(num5 > (double)_0023_003DzyeA5XEs_003D.Y) || !(num2 < (double)(_0023_003DzyeA5XEs_003D.X + _0023_003DzyeA5XEs_003D.Width)) || !(num3 < (double)(_0023_003DzyeA5XEs_003D.Y + _0023_003DzyeA5XEs_003D.Height)))
				{
					return true;
				}
				Segment3D _0023_003DzwSYRtiF9NfQV;
				Segment3D _0023_003Dz26JkE4mTgRSq;
				Segment3D _0023_003DzODmhfGke69CA;
				Segment3D _0023_003Dzr17r3fruk1Lg;
				PlaneEquation[] frustum2 = _0023_003DzztLIRQOxCyGw.GetFrustum(_0023_003DzqDFBISpCePlj, _0023_003Dz_OlmZyU_003D: false, new System.Drawing.Point((int)_0023_003DzyeA5XEs_003D.X, (int)_0023_003DzyeA5XEs_003D.Y), new System.Drawing.Point((int)(_0023_003DzyeA5XEs_003D.X + _0023_003DzyeA5XEs_003D.Width), (int)(_0023_003DzyeA5XEs_003D.Y + _0023_003DzyeA5XEs_003D.Height)), out _0023_003DzwSYRtiF9NfQV, out _0023_003Dz26JkE4mTgRSq, out _0023_003DzODmhfGke69CA, out _0023_003Dzr17r3fruk1Lg);
				Plane[] array2 = new Plane[4];
				for (int n = 1; n < 5; n++)
				{
					Plane plane2 = new Plane(frustum2[n].ToArray());
					plane2.Flip();
					array2[n - 1] = plane2;
					mesh = _0023_003DzPRxVtxd_DkMM4u1IDmME1m4_003D(mesh, plane2, diagonal);
				}
				for (int num8 = 0; num8 < 4; num8++)
				{
					if (mesh.Vertices.Length == 0)
					{
						break;
					}
					mesh.CutBy(array2[num8]);
				}
			}
		}
		if (mesh.Vertices.Length == 0)
		{
			_0023_003DzELu0Pss_003D.Vertices = new float[0, 3];
			_0023_003DzELu0Pss_003D.ScreenVertices = new double[0, 3];
			return true;
		}
		float[,] array3 = new float[mesh.Triangles.Length * 3, 3];
		num = 0;
		for (int num9 = 0; num9 < mesh.Triangles.Length; num9++)
		{
			IndexTriangle indexTriangle = mesh.Triangles[num9];
			Point3D point3D = mesh.Vertices[indexTriangle.V1];
			array3[num, 0] = (float)point3D.X;
			array3[num, 1] = (float)point3D.Y;
			array3[num, 2] = (float)point3D.Z;
			num++;
			point3D = mesh.Vertices[indexTriangle.V2];
			array3[num, 0] = (float)point3D.X;
			array3[num, 1] = (float)point3D.Y;
			array3[num, 2] = (float)point3D.Z;
			num++;
			point3D = mesh.Vertices[indexTriangle.V3];
			array3[num, 0] = (float)point3D.X;
			array3[num, 1] = (float)point3D.Y;
			array3[num, 2] = (float)point3D.Z;
			num++;
		}
		_0023_003DzELu0Pss_003D.Vertices = array3;
		_0023_003DzELu0Pss_003D.ComputeScreenVertices(_0023_003DzztLIRQOxCyGw.renderContext, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj);
		return false;
	}

	private static Mesh _0023_003DzPRxVtxd_DkMM4u1IDmME1m4_003D(Mesh _0023_003DzGGJSiQk_003D, Plane _0023_003Dzi4cdUYM_003D, double _0023_003Dz14lzA48_003D)
	{
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i < _0023_003DzGGJSiQk_003D.Triangles.Length; i++)
		{
			IndexTriangle indexTriangle = _0023_003DzGGJSiQk_003D.Triangles[i];
			Point3D point3D = _0023_003DzGGJSiQk_003D.Vertices[indexTriangle.V1];
			Point3D point3D2 = _0023_003DzGGJSiQk_003D.Vertices[indexTriangle.V2];
			Point3D point3D3 = _0023_003DzGGJSiQk_003D.Vertices[indexTriangle.V3];
			double _0023_003DzXMGjKnoZdqec = _0023_003Dzi4cdUYM_003D.DistanceTo(point3D);
			double _0023_003DzXMGjKnoZdqec2 = _0023_003Dzi4cdUYM_003D.DistanceTo(point3D2);
			double _0023_003DzXMGjKnoZdqec3 = _0023_003Dzi4cdUYM_003D.DistanceTo(point3D3);
			int num = _0023_003Dzyx0pb5M_003D(_0023_003DzXMGjKnoZdqec, _0023_003Dz14lzA48_003D);
			int num2 = _0023_003Dzyx0pb5M_003D(_0023_003DzXMGjKnoZdqec2, _0023_003Dz14lzA48_003D);
			int num3 = _0023_003Dzyx0pb5M_003D(_0023_003DzXMGjKnoZdqec3, _0023_003Dz14lzA48_003D);
			if (num != 1 || num2 != 1 || num3 != 1)
			{
				list.Add(point3D);
				list.Add(point3D2);
				list.Add(point3D3);
			}
		}
		Point3D[] array = list.ToArray();
		_0023_003DzGGJSiQk_003D = new Mesh(Mesh.natureType.Plain);
		_0023_003DzGGJSiQk_003D.Vertices = array;
		_0023_003DzGGJSiQk_003D.Triangles = _0023_003DzHsgErY60pPKafTQsTrhggkcl7Nsq(array);
		_0023_003DzGGJSiQk_003D.LightWeight = true;
		return _0023_003DzGGJSiQk_003D;
	}

	private static IndexTriangle[] _0023_003DzHsgErY60pPKafTQsTrhggkcl7Nsq(Point3D[] _0023_003DzrdSL0CI_003D)
	{
		int num = 0;
		List<IndexTriangle> list = new List<IndexTriangle>();
		for (int i = 0; i < _0023_003DzrdSL0CI_003D.Length / 3; i++)
		{
			list.Add(new IndexTriangle(num++, num++, num++));
		}
		return list.ToArray();
	}

	private static int _0023_003Dzyx0pb5M_003D(double _0023_003DzXMGjKnoZdqec, double _0023_003Dz14lzA48_003D)
	{
		if (Utility.AreEqual(_0023_003DzXMGjKnoZdqec, 0.0, _0023_003Dz14lzA48_003D))
		{
			return 0;
		}
		return (short)Math.Sign(_0023_003DzXMGjKnoZdqec);
	}

	private void _0023_003DzJKZno7G_LQRSMf9GWm6R_0024Qs_003D(_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D, bool[] _0023_003Dz2wjxF5y1xC5ttAykyQ_003D_003D, LinkedList<SharedEdge>[] _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, out List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzewBcmhf9rM_00244Wus89w_003D_003D)
	{
		_0023_003DzewBcmhf9rM_00244Wus89w_003D_003D = new List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>();
		int num = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzZSnvfVF8Y5Qg.Length;
		bool[] array = new bool[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = _0023_003DzhDa5OvbQw8gi(_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.ScreenVertices, _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzZSnvfVF8Y5Qg[i]);
		}
		_0023_003Dz8xa77MvcESoK4yz4YbZ6Z5M_003D(array, _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D, _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, _0023_003DzewBcmhf9rM_00244Wus89w_003D_003D, _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzkpGtkwc69sJY());
		if (_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzU4XYawo_003D != null)
		{
			_0023_003DzpMPf624_003D(_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D, _0023_003Dz2wjxF5y1xC5ttAykyQ_003D_003D, _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, _0023_003DzewBcmhf9rM_00244Wus89w_003D_003D, array);
		}
		_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzmN5Mam9VUpygzj_00243Sw_003D_003D = _0023_003Dzo1l1xaMrUoAjT8mfR4CZWtE_003D(_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzZSnvfVF8Y5Qg, _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.ScreenVertices, _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D);
		if (!_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzkpGtkwc69sJY())
		{
			return;
		}
		for (int j = 0; j < _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzmN5Mam9VUpygzj_00243Sw_003D_003D.Length; j++)
		{
			if (_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzmN5Mam9VUpygzj_00243Sw_003D_003D[j] < 0.0)
			{
				_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D[j] = true;
			}
		}
	}

	private void _0023_003DzpMPf624_003D(_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D, bool[] _0023_003Dz2wjxF5y1xC5ttAykyQ_003D_003D, LinkedList<SharedEdge>[] _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzewBcmhf9rM_00244Wus89w_003D_003D, bool[] _0023_003DzcFMbpGxCMTTT)
	{
		int num = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzU4XYawo_003D.Length;
		List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> list = new List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>(num);
		for (int i = 0; i < num; i++)
		{
			_0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D _0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D2 = new _0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D();
			_0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D2._0023_003DzffqPLNQ_003D = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzU4XYawo_003D[i]._0023_003DzQW_0024hBdI_003D;
			_0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D2._0023_003Dz5Azd7L8_003D = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzU4XYawo_003D[i]._0023_003DzCmn_5Z0_003D;
			int _0023_003DzSaHVljQ_003D = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzU4XYawo_003D[i]._0023_003DzSaHVljQ_003D;
			if (_0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D2._0023_003DzffqPLNQ_003D == _0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D2._0023_003Dz5Azd7L8_003D || (_0023_003Dz2wjxF5y1xC5ttAykyQ_003D_003D[_0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D2._0023_003DzffqPLNQ_003D] && _0023_003Dz2wjxF5y1xC5ttAykyQ_003D_003D[_0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D2._0023_003Dz5Azd7L8_003D]))
			{
				continue;
			}
			_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2 = _0023_003DzewBcmhf9rM_00244Wus89w_003D_003D.Find(_0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D2._0023_003Dzf4sKudkFxoYBSovakw_003D_003D);
			if (_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2 != null)
			{
				_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003Dz2fR0hp1LejC6(_0023_003DzSaHVljQ_003D);
				continue;
			}
			int num2 = -1;
			int num3 = -1;
			LinkedListNode<SharedEdge> linkedListNode = _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D[_0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D2._0023_003DzffqPLNQ_003D].First;
			while (linkedListNode != null && linkedListNode.Value.V2 != _0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D2._0023_003Dz5Azd7L8_003D)
			{
				linkedListNode = linkedListNode.Next;
			}
			if (linkedListNode != null)
			{
				num2 = linkedListNode.Value.Mum;
				num3 = linkedListNode.Value.Dad;
			}
			bool flag = _0023_003Dz2wjxF5y1xC5ttAykyQ_003D_003D[_0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D2._0023_003DzffqPLNQ_003D] ^ _0023_003Dz2wjxF5y1xC5ttAykyQ_003D_003D[_0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D2._0023_003Dz5Azd7L8_003D];
			if (!flag || ((num2 == -1 || !_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D[num2]) && (num3 == -1 || !_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D[num3])))
			{
				_0023_003Dzxc2pSHY_003D(_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D, _0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D2._0023_003DzffqPLNQ_003D, _0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D2._0023_003Dz5Azd7L8_003D, num2, num3, list, _0023_003DzcFMbpGxCMTTT, _0023_003DzSaHVljQ_003D, flag);
			}
		}
		_0023_003DzewBcmhf9rM_00244Wus89w_003D_003D.AddRange(list);
	}

	private void _0023_003Dzxc2pSHY_003D(_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzxEr071xAssYe, int _0023_003DzJefTJpnXqBD9, List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzyIUKu5w_003D, bool[] _0023_003DzcFMbpGxCMTTT, int _0023_003DzL8NvYU0_003D, bool _0023_003DzWEBs53zXCVqc9JdZiw_003D_003D)
	{
		if (_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzkpGtkwc69sJY() && _0023_003DzxEr071xAssYe != -1 && !_0023_003DzcFMbpGxCMTTT[_0023_003DzxEr071xAssYe])
		{
			if (HdlViewSettings.KeepHiddenSegments)
			{
				_0023_003DzkVGo4dw_003D(_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D, _0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzxEr071xAssYe, _0023_003DzJefTJpnXqBD9, HiddenLinesViewSettings.lineType.Edge, _0023_003DzyIUKu5w_003D, _0023_003DzaaJHKt4_003D: true, _0023_003DzL8NvYU0_003D, _0023_003DzWEBs53zXCVqc9JdZiw_003D_003D);
			}
		}
		else
		{
			_0023_003DzkVGo4dw_003D(_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D, _0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzxEr071xAssYe, _0023_003DzJefTJpnXqBD9, HiddenLinesViewSettings.lineType.Edge, _0023_003DzyIUKu5w_003D, _0023_003DzaaJHKt4_003D: false, _0023_003DzL8NvYU0_003D, _0023_003DzWEBs53zXCVqc9JdZiw_003D_003D);
		}
	}

	private _0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D _0023_003DzI1KZmlQ3bC8Gl2FaHA_003D_003D(Plane _0023_003Dz__4OfIpVgJ6A, _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D)
	{
		Entity entity = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.Entity;
		IFace face = null;
		if (entity is Brep brep)
		{
			face = brep.ConvertToMesh();
		}
		else if (entity is Surface surface)
		{
			face = surface.ConvertToMesh();
		}
		else if (entity is IFace face2)
		{
			face = face2;
		}
		if (face == null)
		{
			return null;
		}
		_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2 = _0023_003DzyAl__urfZrsfISx10w_003D_003D(Utility.DetectRegionsFromContours(face.Section(_0023_003Dz__4OfIpVgJ6A, 0.0), _0023_003Dz__4OfIpVgJ6A));
		if (_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2 != null)
		{
			_0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D obj = _0023_003Dz5B5v5rZAkT4idX9SIA_003D_003D(entity, _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.Parents, _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2._0023_003DzNKR_cAYoR2aGDUGpng_003D_003D, _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2._0023_003DzZSnvfVF8Y5Qg, _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2._0023_003DzU4XYawo_003D, _0023_003DzbErHvVw_003D: false, 0.0);
			obj.Transformation = (Transformation)(_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.Transformation?.Clone());
			obj.Attributes = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.Attributes;
			return obj;
		}
		string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986747) + entity.GetType().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908039);
		if (face is Mesh { IsClosed: false })
		{
			text += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986733);
		}
		log.AppendLine(text);
		return null;
	}

	private _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzNjFDW8MzEkv9VwzRowpEbjzCdhZ4nALbTA_003D_003D(Entity _0023_003Dz9j7EUB0_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, Plane _0023_003Dzuuj78OZLJwEDNvgr8g_003D_003D, _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D, bool[] _0023_003Dz2wjxF5y1xC5ttAykyQ_003D_003D, LinkedList<SharedEdge>[] _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D)
	{
		float[,] vertices = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.Vertices;
		List<_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D> list = new List<_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D>();
		List<int> list2 = new List<int>();
		for (int i = 0; i < _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzwsVdE4aCB04rlTu9E7BEoXkNDRGraWob5A_003D_003D.Length; i++)
		{
			if (!_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzwsVdE4aCB04rlTu9E7BEoXkNDRGraWob5A_003D_003D[i])
			{
				continue;
			}
			int num = i;
			int[][] _0023_003DzhMDfC7g_003D = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzZSnvfVF8Y5Qg[num]._0023_003DzhMDfC7g_003D;
			int[] array = _0023_003DzhMDfC7g_003D[0];
			int num2 = array.Length;
			int[] array2 = new int[num2];
			List<int> list3 = new List<int>(array);
			list3.Sort();
			array2[0] = _0023_003DzvNUwQHCch4zL(num, array[num2 - 1], _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D[list3[0]].First);
			for (int j = 0; j < num2 - 1; j++)
			{
				array2[j] = _0023_003DzvNUwQHCch4zL(num, array[j + 1], _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D[array[j]].First);
			}
			for (int k = 0; k < num2; k++)
			{
				int num3 = array2[k];
				if (num3 == -1 || list2.Contains(num3))
				{
					continue;
				}
				int[] array3 = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzZSnvfVF8Y5Qg[num3]._0023_003DzhMDfC7g_003D[0];
				bool flag = false;
				for (int l = 0; l < array3.Length; l++)
				{
					if (_0023_003Dz2wjxF5y1xC5ttAykyQ_003D_003D[array3[l]])
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list2.Add(num3);
				}
			}
			_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2 = _0023_003Dzyk1L1UFlUYEfnJpNl8nKpdw_003D(_0023_003Dzuuj78OZLJwEDNvgr8g_003D_003D, vertices, _0023_003DzhMDfC7g_003D);
			if (_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2 != null)
			{
				list.Add(_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2);
			}
		}
		for (int m = 0; m < list2.Count; m++)
		{
			int num4 = list2[m];
			List<Point3D> list4 = new List<Point3D>();
			int num5 = 0;
			int[][] array4 = new int[_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzZSnvfVF8Y5Qg[num4]._0023_003DzhMDfC7g_003D.Length][];
			for (int n = 0; n < _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzZSnvfVF8Y5Qg[num4]._0023_003DzhMDfC7g_003D.Length; n++)
			{
				int[] array5 = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D._0023_003DzZSnvfVF8Y5Qg[num4]._0023_003DzhMDfC7g_003D[n];
				for (int num6 = 0; num6 < array5.Length; num6++)
				{
					int num7 = array5[num6];
					list4.Add(new Point3D(_0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.Vertices[num7, 0], _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.Vertices[num7, 1], _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.Vertices[num7, 2]));
					array5[num6] = num5;
					num5++;
				}
				array4[n] = array5;
			}
			_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D item = new _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D(list4.ToArray(), array4);
			list.Add(item);
		}
		if (list.Count == 0)
		{
			return null;
		}
		_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D3 = list[0];
		for (int num8 = 1; num8 < list.Count; num8++)
		{
			_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D4 = list[num8];
			if (_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D4 != null && _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D4._0023_003DzNKR_cAYoR2aGDUGpng_003D_003D.Length != 0)
			{
				_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D3._0023_003DzSnbFaS0_003D(_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D4, _0023_003DzEuQ72GKNmfZl: false, _0023_003DzFD2DkC_4lrYUT6xPuw_003D_003D: false, _0023_003Dz9j7EUB0_003D.BoxSize);
			}
		}
		_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D._0023_003Dz6tNTbj2n_0024gTT(ref _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D3._0023_003DzNKR_cAYoR2aGDUGpng_003D_003D, ref _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D3._0023_003DzZSnvfVF8Y5Qg, _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D3._0023_003DzU4XYawo_003D, _0023_003Dz9j7EUB0_003D.BoxSize.Diagonal * Utility._0023_003DzxhnLabVjXjPg);
		_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D obj = _0023_003DzeWZNZhCW691ciXKd0w_003D_003D(_0023_003Dz9j7EUB0_003D, _0023_003Dzq5nwX2I_003D, _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D3._0023_003DzNKR_cAYoR2aGDUGpng_003D_003D, _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D3._0023_003DzZSnvfVF8Y5Qg, _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D3._0023_003DzU4XYawo_003D, _0023_003DzbErHvVw_003D: false, 0.0);
		obj.Attributes = _0023_003DzJZbLP0z5pb4vaCYMuw_003D_003D.Attributes;
		return obj;
	}

	private static _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D _0023_003Dzyk1L1UFlUYEfnJpNl8nKpdw_003D(Plane _0023_003Dzuuj78OZLJwEDNvgr8g_003D_003D, float[,] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int[][] _0023_003Dzcv8o5nO25OjS)
	{
		ICurve[] array = new ICurve[_0023_003Dzcv8o5nO25OjS.Length];
		for (int i = 0; i < _0023_003Dzcv8o5nO25OjS.Length; i++)
		{
			int[] array2 = _0023_003Dzcv8o5nO25OjS[i];
			int num = array2.Length;
			Point3D[] array3 = new Point3D[num + 1];
			for (int j = 0; j < num; j++)
			{
				array3[j] = new Point3D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[array2[j], 0], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[array2[j], 1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[array2[j], 2]);
			}
			array3[num] = new Point3D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[array2[0], 0], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[array2[0], 1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[array2[0], 2]);
			array[i] = new LinearPath(array3);
		}
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(array);
		Plane.Intersection(region.Plane, _0023_003Dzuuj78OZLJwEDNvgr8g_003D_003D, out var intSeg);
		Utility.ComputeBoundingBox(((Entity)array[0]).Vertices, out var boxMin, out var boxMax);
		double num2 = intSeg.Project(boxMin);
		double num3 = intSeg.Project(boxMax);
		if (num3 < num2)
		{
			double num4 = num2;
			num2 = num3;
			num3 = num4;
		}
		Line item = new Line(intSeg.PointAt(num2 - 10.0), intSeg.PointAt(num3 + 10.0));
		devDept.Eyeshot.Entities.Region.Trim(region, new List<ICurve> { item }, out var result);
		return _0023_003DzyAl__urfZrsfISx10w_003D_003D(result);
	}

	private static _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D _0023_003DzyAl__urfZrsfISx10w_003D_003D(devDept.Eyeshot.Entities.Region[] _0023_003Dz2C3D9QY_003D)
	{
		List<Point3D> list = new List<Point3D>();
		int num = 0;
		_0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[] array = new _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[_0023_003Dz2C3D9QY_003D.Length];
		List<IndexLine> list2 = new List<IndexLine>();
		for (int i = 0; i < _0023_003Dz2C3D9QY_003D.Length; i++)
		{
			devDept.Eyeshot.Entities.Region region = _0023_003Dz2C3D9QY_003D[i];
			int[][] array2 = new int[region.ContourList.Count][];
			for (int j = 0; j < region.ContourList.Count; j++)
			{
				Entity entity = region.ContourList[j] as Entity;
				entity.Regen(1.0);
				if (entity.Vertices.Length < 4)
				{
					return null;
				}
				int[] array3 = new int[entity.Vertices.Length - 1];
				int v = num;
				for (int k = 0; k < entity.Vertices.Length - 1; k++)
				{
					list.Add(entity.Vertices[k]);
					array3[k] = num;
					list2.Add(new IndexLine(num, num + 1));
					num++;
				}
				list2.Last().V2 = v;
				array2[j] = array3;
			}
			array[i] = new _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D(array2);
		}
		return new _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D(list.ToArray(), array)
		{
			_0023_003DzU4XYawo_003D = list2.ToArray()
		};
	}

	private static int _0023_003DzvNUwQHCch4zL(int _0023_003Dzfe2zeQMumw_4, int _0023_003Dz5Azd7L8_003D, LinkedListNode<SharedEdge> _0023_003DzU3hosSAzkxO7)
	{
		LinkedListNode<SharedEdge> linkedListNode = _0023_003DzU3hosSAzkxO7;
		while (linkedListNode != null && linkedListNode.Value.V2 != _0023_003Dz5Azd7L8_003D)
		{
			linkedListNode = linkedListNode.Next;
		}
		if (linkedListNode == null)
		{
			return -1;
		}
		if (linkedListNode.Value.Mum != _0023_003Dzfe2zeQMumw_4)
		{
			return linkedListNode.Value.Mum;
		}
		return linkedListNode.Value.Dad;
	}

	private static void _0023_003DzyCK6H_X8109MGZUpK5ArHCk_003D(RenderContextBase _0023_003DzQdnFby4_003D, double[] _0023_003DzypMGqyMVO5qA, int[] _0023_003DzqDFBISpCePlj, SilhoWireData _0023_003DzELu0Pss_003D, Plane _0023_003Dzuuj78OZLJwEDNvgr8g_003D_003D, int _0023_003Dzl_I7Ftx6MNbe, int _0023_003Dz8k8G7N9WzSKJ, bool _0023_003DzdlLOSYl6ffSQ, List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzWjAzoM4g_0024l0a)
	{
		Point3D p = new Point3D(_0023_003DzELu0Pss_003D.Vertices[_0023_003Dzl_I7Ftx6MNbe, 0], _0023_003DzELu0Pss_003D.Vertices[_0023_003Dzl_I7Ftx6MNbe, 1], _0023_003DzELu0Pss_003D.Vertices[_0023_003Dzl_I7Ftx6MNbe, 2]);
		Point3D p2 = new Point3D(_0023_003DzELu0Pss_003D.Vertices[_0023_003Dz8k8G7N9WzSKJ, 0], _0023_003DzELu0Pss_003D.Vertices[_0023_003Dz8k8G7N9WzSKJ, 1], _0023_003DzELu0Pss_003D.Vertices[_0023_003Dz8k8G7N9WzSKJ, 2]);
		if (new Segment3D(p, p2).IntersectWith(_0023_003Dzuuj78OZLJwEDNvgr8g_003D_003D, out var intPoint))
		{
			if (_0023_003DzELu0Pss_003D.Transformation != null && !_0023_003DzELu0Pss_003D.Transformation.IsIdentity())
			{
				intPoint = _0023_003DzELu0Pss_003D.Transformation * intPoint;
			}
			if (_0023_003DzdlLOSYl6ffSQ)
			{
				_0023_003Dz8k8G7N9WzSKJ = _0023_003Dzl_I7Ftx6MNbe;
			}
			GfxSilhoData.ComputeScreenCoords(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, intPoint.X, intPoint.Y, intPoint.Z, out _0023_003DzELu0Pss_003D.ScreenVertices[_0023_003Dz8k8G7N9WzSKJ, 0], out _0023_003DzELu0Pss_003D.ScreenVertices[_0023_003Dz8k8G7N9WzSKJ, 1], out _0023_003DzELu0Pss_003D.ScreenVertices[_0023_003Dz8k8G7N9WzSKJ, 2]);
			_0023_003DzkVGo4dw_003D(_0023_003DzELu0Pss_003D, _0023_003Dzl_I7Ftx6MNbe, _0023_003Dzl_I7Ftx6MNbe - 1, -1, -1, HiddenLinesViewSettings.lineType.Wire, _0023_003DzWjAzoM4g_0024l0a, _0023_003DzaaJHKt4_003D: false, -1, _0023_003DzWEBs53zXCVqc9JdZiw_003D_003D: false);
		}
	}

	private static double[] _0023_003Dzo1l1xaMrUoAjT8mfR4CZWtE_003D(_0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom[] _0023_003DzpPOEJqcAh7Lr, double[,] _0023_003DzFS_0024L8faKPib3, bool[] _0023_003DzQu4sjeayyYTk)
	{
		int num = _0023_003DzpPOEJqcAh7Lr.Length;
		double[] array = new double[num];
		for (int i = 0; i < num; i++)
		{
			double _0023_003DzXWCF4rA_003D;
			if (_0023_003DzpPOEJqcAh7Lr[i]._0023_003Dz7vjfoLA_003D)
			{
				int _0023_003DzQW_0024hBdI_003D = _0023_003DzpPOEJqcAh7Lr[i]._0023_003DzQW_0024hBdI_003D;
				int _0023_003DzCmn_5Z0_003D = _0023_003DzpPOEJqcAh7Lr[i]._0023_003DzCmn_5Z0_003D;
				int _0023_003DzqePf_00244c_003D = _0023_003DzpPOEJqcAh7Lr[i]._0023_003DzqePf_00244c_003D;
				if (_0023_003Dz5KTWTbEgvzb3(_0023_003DzFS_0024L8faKPib3[_0023_003DzQW_0024hBdI_003D, 0], _0023_003DzFS_0024L8faKPib3[_0023_003DzQW_0024hBdI_003D, 1], _0023_003DzFS_0024L8faKPib3[_0023_003DzCmn_5Z0_003D, 0], _0023_003DzFS_0024L8faKPib3[_0023_003DzCmn_5Z0_003D, 1], _0023_003DzFS_0024L8faKPib3[_0023_003DzqePf_00244c_003D, 0], _0023_003DzFS_0024L8faKPib3[_0023_003DzqePf_00244c_003D, 1], out _0023_003DzXWCF4rA_003D))
				{
					_0023_003DzQu4sjeayyYTk[i] = true;
				}
			}
			else if (_0023_003Dz5KTWTbEgvzb3(_0023_003DzVNcF7J2ZVn2_0024(_0023_003DzFS_0024L8faKPib3, _0023_003DzpPOEJqcAh7Lr[i]._0023_003DzhMDfC7g_003D[0]), out _0023_003DzXWCF4rA_003D))
			{
				_0023_003DzQu4sjeayyYTk[i] = true;
			}
			array[i] = _0023_003DzXWCF4rA_003D;
		}
		return array;
	}

	private static double[,] _0023_003DzVNcF7J2ZVn2_0024(double[,] _0023_003DzFS_0024L8faKPib3, int[] _0023_003DzdEvMFOw_003D)
	{
		int num = _0023_003DzdEvMFOw_003D.Length;
		double[,] array = new double[num, 2];
		for (int i = 0; i < num; i++)
		{
			array[i, 0] = _0023_003DzFS_0024L8faKPib3[_0023_003DzdEvMFOw_003D[i], 0];
			array[i, 1] = _0023_003DzFS_0024L8faKPib3[_0023_003DzdEvMFOw_003D[i], 1];
		}
		return array;
	}

	private void _0023_003Dz8xa77MvcESoK4yz4YbZ6Z5M_003D(bool[] _0023_003DzcFMbpGxCMTTT, _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzELu0Pss_003D, LinkedList<SharedEdge>[] _0023_003DzDn3gsQfBhRkJ, List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzyIUKu5w_003D, bool _0023_003DzeYcIiyliS7qU)
	{
		for (int i = 0; i < _0023_003DzDn3gsQfBhRkJ.Length; i++)
		{
			LinkedListNode<SharedEdge> linkedListNode = _0023_003DzDn3gsQfBhRkJ[i].First;
			while (linkedListNode != null)
			{
				SharedEdge value = linkedListNode.Value;
				linkedListNode = linkedListNode.Next;
				int mum = value.Mum;
				int dad = value.Dad;
				if (dad == -1)
				{
					if (!_0023_003DzELu0Pss_003D._0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D[mum] && (!_0023_003DzeYcIiyliS7qU || _0023_003DzcFMbpGxCMTTT[mum]))
					{
						_0023_003DzkVGo4dw_003D(_0023_003DzELu0Pss_003D, i, value.V2, mum, dad, HiddenLinesViewSettings.lineType.Silho, _0023_003DzyIUKu5w_003D, _0023_003DzaaJHKt4_003D: false, -1, _0023_003DzWEBs53zXCVqc9JdZiw_003D_003D: false);
					}
				}
				else if (!_0023_003DzGxYdGzYAf_33(_0023_003DzELu0Pss_003D, dad, mum) && (_0023_003DzcFMbpGxCMTTT[mum] ^ _0023_003DzcFMbpGxCMTTT[dad]))
				{
					_0023_003DzkVGo4dw_003D(_0023_003DzELu0Pss_003D, i, value.V2, mum, dad, HiddenLinesViewSettings.lineType.Silho, _0023_003DzyIUKu5w_003D, _0023_003DzaaJHKt4_003D: false, -1, _0023_003DzWEBs53zXCVqc9JdZiw_003D_003D: false);
				}
			}
		}
	}

	private bool _0023_003DzGxYdGzYAf_33(_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzELu0Pss_003D, int _0023_003Dz3meCwcU_003D, int _0023_003DzOZnLD38_003D)
	{
		if (!_0023_003DzELu0Pss_003D._0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D[_0023_003Dz3meCwcU_003D])
		{
			return _0023_003DzELu0Pss_003D._0023_003DzFMmK2jHh3LJlo9UxYw_003D_003D[_0023_003DzOZnLD38_003D];
		}
		return true;
	}

	private static bool _0023_003DzVkP_0024OJUt_0024tuH(double _0023_003Dz4LZNKgk_003D, double _0023_003DzahY3GS0_003D)
	{
		if (!(_0023_003Dz4LZNKgk_003D > _0023_003Dz3d_0024ELptjrAIK))
		{
			return _0023_003Dz4LZNKgk_003D < _0023_003DzahY3GS0_003D;
		}
		return true;
	}

	private static bool _0023_003DzhDa5OvbQw8gi(double[,] _0023_003DzrdSL0CI_003D, _0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom _0023_003Dz8NCSYr_tA_0024I_0024)
	{
		if (_0023_003Dz8NCSYr_tA_0024I_0024._0023_003Dz7vjfoLA_003D)
		{
			return _0023_003DzhDa5OvbQw8gi(_0023_003DzrdSL0CI_003D[_0023_003Dz8NCSYr_tA_0024I_0024._0023_003DzQW_0024hBdI_003D, 0], _0023_003DzrdSL0CI_003D[_0023_003Dz8NCSYr_tA_0024I_0024._0023_003DzQW_0024hBdI_003D, 1], _0023_003DzrdSL0CI_003D[_0023_003Dz8NCSYr_tA_0024I_0024._0023_003DzCmn_5Z0_003D, 0], _0023_003DzrdSL0CI_003D[_0023_003Dz8NCSYr_tA_0024I_0024._0023_003DzCmn_5Z0_003D, 1], _0023_003DzrdSL0CI_003D[_0023_003Dz8NCSYr_tA_0024I_0024._0023_003DzqePf_00244c_003D, 0], _0023_003DzrdSL0CI_003D[_0023_003Dz8NCSYr_tA_0024I_0024._0023_003DzqePf_00244c_003D, 1]);
		}
		return _0023_003DzhDa5OvbQw8gi(_0023_003DzVNcF7J2ZVn2_0024(_0023_003DzrdSL0CI_003D, _0023_003Dz8NCSYr_tA_0024I_0024._0023_003DzhMDfC7g_003D[0]));
	}

	private static bool _0023_003Dz5KTWTbEgvzb3(_0023_003DzNSoc_izqpPSc[] _0023_003DzrdSL0CI_003D, out double _0023_003DzXWCF4rA_003D)
	{
		return _0023_003Dz5KTWTbEgvzb3(_0023_003DzrdSL0CI_003D[0]._0023_003DzQW_0024hBdI_003D[0], _0023_003DzrdSL0CI_003D[0]._0023_003DzQW_0024hBdI_003D[1], _0023_003DzrdSL0CI_003D[1]._0023_003DzQW_0024hBdI_003D[0], _0023_003DzrdSL0CI_003D[1]._0023_003DzQW_0024hBdI_003D[1], _0023_003DzrdSL0CI_003D[2]._0023_003DzQW_0024hBdI_003D[0], _0023_003DzrdSL0CI_003D[2]._0023_003DzQW_0024hBdI_003D[1], out _0023_003DzXWCF4rA_003D);
	}

	private static bool _0023_003Dz5KTWTbEgvzb3(double _0023_003DzImYzsIk_003D, double _0023_003DzwTl2MSI_003D, double _0023_003DzDUl8fB4_003D, double _0023_003DzzdWDivM_003D, double _0023_003DzV9C3Wm0_003D, double _0023_003DzyKN2LzY_003D, out double _0023_003DzXWCF4rA_003D)
	{
		double num = _0023_003DzDUl8fB4_003D - _0023_003DzImYzsIk_003D;
		double num2 = _0023_003DzyKN2LzY_003D - _0023_003DzwTl2MSI_003D;
		double num3 = _0023_003DzzdWDivM_003D - _0023_003DzwTl2MSI_003D;
		double num4 = _0023_003DzV9C3Wm0_003D - _0023_003DzImYzsIk_003D;
		_0023_003DzXWCF4rA_003D = num * num2 - num3 * num4;
		double num5 = Math.Abs(_0023_003DzXWCF4rA_003D);
		if (num5 <= 1E-11)
		{
			return true;
		}
		if (num5 >= 0.0001)
		{
			return false;
		}
		double val = Math.Max(Math.Abs(num), Math.Abs(num4));
		double val2 = Math.Max(Math.Abs(num3), Math.Abs(num2));
		double num6 = Math.Max(val, val2);
		return num5 / num6 <= 1E-05;
	}

	private static bool _0023_003Dz5KTWTbEgvzb3(double[,] _0023_003DzPcLZK3G2ll_0024WVGivpw_003D_003D, out double _0023_003DzXWCF4rA_003D)
	{
		_0023_003DzXWCF4rA_003D = Utility.PolygonArea(_0023_003DzPcLZK3G2ll_0024WVGivpw_003D_003D);
		return Math.Abs(_0023_003DzXWCF4rA_003D) <= 1E-11;
	}

	private static bool _0023_003DzhDa5OvbQw8gi(double[,] _0023_003DzPcLZK3G2ll_0024WVGivpw_003D_003D)
	{
		return Utility.PolygonArea(_0023_003DzPcLZK3G2ll_0024WVGivpw_003D_003D) > 1E-11;
	}

	private static bool _0023_003DzhDa5OvbQw8gi(double _0023_003DzImYzsIk_003D, double _0023_003DzwTl2MSI_003D, double _0023_003DzDUl8fB4_003D, double _0023_003DzzdWDivM_003D, double _0023_003DzV9C3Wm0_003D, double _0023_003DzyKN2LzY_003D)
	{
		double num = _0023_003DzDUl8fB4_003D - _0023_003DzImYzsIk_003D;
		double num2 = _0023_003DzyKN2LzY_003D - _0023_003DzwTl2MSI_003D;
		double num3 = _0023_003DzzdWDivM_003D - _0023_003DzwTl2MSI_003D;
		double num4 = _0023_003DzV9C3Wm0_003D - _0023_003DzImYzsIk_003D;
		double num5 = num * num2 - num3 * num4;
		if (num5 <= 1E-11)
		{
			return false;
		}
		if (num5 >= 0.0001)
		{
			return true;
		}
		double val = Math.Max(Math.Abs(num), Math.Abs(num4));
		double val2 = Math.Max(Math.Abs(num3), Math.Abs(num2));
		double num6 = Math.Max(val, val2);
		return num5 / num6 > 1E-05;
	}

	private static void _0023_003Dzs5c8Do0_003D(SilhoWireData _0023_003DzELu0Pss_003D, int _0023_003Dz77g161c_003D, List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzWjAzoM4g_0024l0a)
	{
		double[] _0023_003DzrhOaQYs_003D = new double[6]
		{
			_0023_003DzELu0Pss_003D.ScreenVertices[_0023_003Dz77g161c_003D, 0],
			_0023_003DzELu0Pss_003D.ScreenVertices[_0023_003Dz77g161c_003D, 1],
			_0023_003DzELu0Pss_003D.ScreenVertices[_0023_003Dz77g161c_003D, 2],
			_0023_003DzELu0Pss_003D.ScreenVertices[_0023_003Dz77g161c_003D, 0],
			_0023_003DzELu0Pss_003D.ScreenVertices[_0023_003Dz77g161c_003D, 1],
			_0023_003DzELu0Pss_003D.ScreenVertices[_0023_003Dz77g161c_003D, 2]
		};
		_0023_003DzWjAzoM4g_0024l0a.Add(new _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D(_0023_003DzrhOaQYs_003D, HiddenLinesViewSettings.lineType.Wire, _0023_003DzELu0Pss_003D.Attributes, new AssemblyLeaf(_0023_003DzELu0Pss_003D.Entity, _0023_003DzELu0Pss_003D.Parents), -1, -1, _0023_003Dz77g161c_003D, _0023_003Dz77g161c_003D, -1, _0023_003DzqdXGMFc_003D: true));
	}

	private static void _0023_003DzkVGo4dw_003D(SilhoWireData _0023_003DzELu0Pss_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, int _0023_003DzxEr071xAssYe, int _0023_003DzJefTJpnXqBD9, HiddenLinesViewSettings.lineType _0023_003DzhC3Yby0_003D, List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzWjAzoM4g_0024l0a, bool _0023_003DzaaJHKt4_003D, int _0023_003DzL8NvYU0_003D, bool _0023_003DzWEBs53zXCVqc9JdZiw_003D_003D)
	{
		double[] _0023_003DzrhOaQYs_003D = new double[6]
		{
			_0023_003DzELu0Pss_003D.ScreenVertices[_0023_003DzffqPLNQ_003D, 0],
			_0023_003DzELu0Pss_003D.ScreenVertices[_0023_003DzffqPLNQ_003D, 1],
			_0023_003DzELu0Pss_003D.ScreenVertices[_0023_003DzffqPLNQ_003D, 2],
			_0023_003DzELu0Pss_003D.ScreenVertices[_0023_003Dz5Azd7L8_003D, 0],
			_0023_003DzELu0Pss_003D.ScreenVertices[_0023_003Dz5Azd7L8_003D, 1],
			_0023_003DzELu0Pss_003D.ScreenVertices[_0023_003Dz5Azd7L8_003D, 2]
		};
		_0023_003DzWjAzoM4g_0024l0a.Add(new _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D(_0023_003DzrhOaQYs_003D, _0023_003DzhC3Yby0_003D, _0023_003DzELu0Pss_003D.Attributes, new AssemblyLeaf(_0023_003DzELu0Pss_003D.Entity, _0023_003DzELu0Pss_003D.Parents), _0023_003DzxEr071xAssYe, _0023_003DzJefTJpnXqBD9, _0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D, _0023_003DzL8NvYU0_003D, _0023_003DzqdXGMFc_003D: false, _0023_003DzaaJHKt4_003D, _0023_003DzWEBs53zXCVqc9JdZiw_003D_003D));
	}

	private static bool _0023_003DzV7icIEk_003D(Stack<BlockReference> _0023_003Dzq5nwX2I_003D)
	{
		if (_0023_003Dzq5nwX2I_003D != null && _0023_003Dzq5nwX2I_003D.Count > 0)
		{
			return _0023_003Dzq5nwX2I_003D.First() is View;
		}
		return false;
	}

	private void _0023_003DzIkowfAsYgs9l(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzyIUKu5w_003D, List<_0023_003Dzuk2hG_Czem6GbXMxohg8jZ6A_00246QN> _0023_003Dz8jECbYImlLYXoNhrMQ_003D_003D, List<_0023_003DzjEyXBWtBsIsdFVXgrbBpl67eaIBU> _0023_003DzpbkolymgnLli, bool _0023_003Dz1UarNw8gnQy8iQVO4A_003D_003D)
	{
		HiddenLinesViewSettings._0023_003DzF6xWLztjwz7t(_0023_003DzyIUKu5w_003D, _0023_003Dz8jECbYImlLYXoNhrMQ_003D_003D, _0023_003DzpbkolymgnLli, out HdlViewSettings.boxMin, out HdlViewSettings.boxMax);
		List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> list = new List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>();
		List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> list2 = new List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>();
		foreach (_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D item in _0023_003DzyIUKu5w_003D)
		{
			if (_0023_003DzV7icIEk_003D(item._0023_003Dz0tIOZG5ZfcAY().Parents))
			{
				list.Add(item);
			}
			else
			{
				list2.Add(item);
			}
		}
		_0023_003DzyIUKu5w_003D = list2;
		double num = _0023_003DziSgdqm0iP1on(HdlViewSettings.boxMin, HdlViewSettings.boxMax);
		if (_0023_003DzyIUKu5w_003D.Count > 0 && _0023_003Dz1UarNw8gnQy8iQVO4A_003D_003D && _0023_003Dz3qZHwoB6iCYc(ref _0023_003DzyIUKu5w_003D, HdlViewSettings.Window, num, HdlViewSettings.boxMin, HdlViewSettings.boxMax))
		{
			HiddenLinesViewSettings._0023_003DzF6xWLztjwz7t(_0023_003DzyIUKu5w_003D, _0023_003Dz8jECbYImlLYXoNhrMQ_003D_003D, _0023_003DzpbkolymgnLli, out HdlViewSettings.boxMin, out HdlViewSettings.boxMax);
			num = _0023_003DziSgdqm0iP1on(HdlViewSettings.boxMin, HdlViewSettings.boxMax);
		}
		_0023_003Dz2_zO1L9VqNAx(_0023_003DzyIUKu5w_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
		if (Cancelled(_0023_003Dzjvn7P10_003D))
		{
			return;
		}
		IEnumerable<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> collection = new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>();
		if (HdlViewSettings.KeepHiddenSegments)
		{
			foreach (IGrouping<bool, _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> item2 in from _0023_003DzBJFJHwk_003D in _0023_003DzyIUKu5w_003D
				group _0023_003DzBJFJHwk_003D by _0023_003DzBJFJHwk_003D._0023_003Dzx9ez3pU_003D && !_0023_003DzBJFJHwk_003D._0023_003Dzi8cEFb9NybZ2LjlZwjtCkKw_003D)
			{
				if (item2.Key)
				{
					collection = item2;
				}
				else
				{
					_0023_003DzyIUKu5w_003D = item2.ToList();
				}
			}
		}
		_0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D obj = new _0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D(HdlViewSettings.boxMin.X, HdlViewSettings.boxMax.X, HdlViewSettings.boxMin.Y, HdlViewSettings.boxMax.Y, _0023_003DzyIUKu5w_003D);
		List<List<int>> _0023_003DzCULckQQ_003D = new List<List<int>>();
		double _0023_003DzKjCH8JldgEWa = num / _0023_003DzJtboPEauKSQjz2YtzmlRqtI_003D;
		int _0023_003Dz7Q5cFTJkZXky = obj._0023_003Dzse5L_LQ_003D(this, num, _0023_003DzKjCH8JldgEWa, _0023_003DzCULckQQ_003D);
		_0023_003Dz5RvNwAoQz8qkxxvBUqX_cKg_003D = new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>();
		_0023_003DzJpDx6YUyvUeu = new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>();
		_0023_003DzhZz9rIEFDTwJ = new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>();
		_0023_003DzuEN6qKPJwlqve1bSzQyu9lY_003D = new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>();
		_0023_003DzyrfqyvnF0yLf = new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>();
		_0023_003DzCntTTb6_0024ylA6ae1s5A_003D_003D = new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>();
		obj._0023_003DzTvoDUQUBQXMi(this, num, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, _0023_003DzCULckQQ_003D, _0023_003Dz7Q5cFTJkZXky);
		_0023_003DzMH8JED3aar33(ref _0023_003DzJpDx6YUyvUeu);
		_0023_003DzMH8JED3aar33(ref _0023_003DzhZz9rIEFDTwJ);
		_0023_003DzMH8JED3aar33(ref _0023_003Dz5RvNwAoQz8qkxxvBUqX_cKg_003D);
		_0023_003DzhZz9rIEFDTwJ.AddRange(list);
		if (HdlViewSettings.KeepHiddenSegments)
		{
			_0023_003DzMH8JED3aar33(ref _0023_003DzyrfqyvnF0yLf);
			_0023_003DzMH8JED3aar33(ref _0023_003DzCntTTb6_0024ylA6ae1s5A_003D_003D);
			_0023_003DzMH8JED3aar33(ref _0023_003DzuEN6qKPJwlqve1bSzQyu9lY_003D);
			_0023_003DzyrfqyvnF0yLf.AddRange(collection);
		}
		_0023_003Dz7m7OtO01ntFBekyLYg_003D_003D();
		HdlViewSettings._0023_003DzGV_0024jjdDDcXbB_xWpqA_003D_003D = new Dictionary<AssemblyLeaf, List<_0023_003DzOMV8NDKkemw9Bwhd_k_00245Q_kffIIJ>>();
		_0023_003Dzk2bMwTd_0024oRGZ(HdlViewSettings.document.Entities, HdlViewSettings.document.Layers, HdlViewSettings.document.Blocks, new Identity(), HdlViewSettings, HdlViewSettings.Camera.GetModelViewProjectionMatrix(), new Stack<BlockReference>());
		List<HdlCurve> list3 = _0023_003DzGRSQupLe2VtkqqXhFQ_003D_003D(_0023_003Dz5RvNwAoQz8qkxxvBUqX_cKg_003D, num).ToList();
		list3.AddRange(_0023_003DzEvYbKUFCkpS4OvewBg_003D_003D);
		_0023_003DzVq_rQxw0kQMtblXdkEJzELk_003D(list3.ToArray());
		_0023_003DzXh_0024_c3AiFf_00248(_0023_003DzGRSQupLe2VtkqqXhFQ_003D_003D(_0023_003DzJpDx6YUyvUeu, num));
		_0023_003DzXYNwQUGUceBK(_0023_003DzGRSQupLe2VtkqqXhFQ_003D_003D(_0023_003DzhZz9rIEFDTwJ, num));
		_0023_003Dz1ysqp8Yxm25nozhVs0x3LAk_003D(_0023_003DzGRSQupLe2VtkqqXhFQ_003D_003D(_0023_003DzuEN6qKPJwlqve1bSzQyu9lY_003D, num));
		_0023_003DzipnGqfumV5Bq(_0023_003DzGRSQupLe2VtkqqXhFQ_003D_003D(_0023_003DzyrfqyvnF0yLf, num));
		_0023_003Dz3zsJBoZg_sNWWwZM_0024A_003D_003D(_0023_003DzGRSQupLe2VtkqqXhFQ_003D_003D(_0023_003DzCntTTb6_0024ylA6ae1s5A_003D_003D, num));
		Cancelled(_0023_003Dzjvn7P10_003D);
	}

	private HdlCurve[] _0023_003DzGRSQupLe2VtkqqXhFQ_003D_003D(List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzyIUKu5w_003D, double _0023_003DzxH4ozIo_003D)
	{
		List<HdlCurve> list = new List<HdlCurve>();
		Dictionary<AssemblyLeaf, List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>> dictionary = new Dictionary<AssemblyLeaf, List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>>();
		Dictionary<_0023_003DzOMV8NDKkemw9Bwhd_k_00245Q_kffIIJ, List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>> dictionary2 = new Dictionary<_0023_003DzOMV8NDKkemw9Bwhd_k_00245Q_kffIIJ, List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>>();
		foreach (_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT item2 in _0023_003DzyIUKu5w_003D)
		{
			bool flag = false;
			if (HdlViewSettings._0023_003DzGV_0024jjdDDcXbB_xWpqA_003D_003D.TryGetValue(item2._0023_003Dz0tIOZG5ZfcAY(), out var value))
			{
				foreach (_0023_003DzOMV8NDKkemw9Bwhd_k_00245Q_kffIIJ item3 in value)
				{
					if (item3._0023_003DzuxTqAp2a_0024JOK() == item2._0023_003DzuxTqAp2a_0024JOK())
					{
						double _0023_003Dz3YfTAqg_003D = item2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0];
						double _0023_003DzpilgH4E_003D = item2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1];
						double _0023_003DzRFb1SGo_003D = item2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3];
						double _0023_003Dz8qV981c_003D = item2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4];
						_0023_003DzRBRZk8ic93rt(_0023_003Dz3YfTAqg_003D, _0023_003DzpilgH4E_003D, _0023_003DzRFb1SGo_003D, _0023_003Dz8qV981c_003D, item3, out var _0023_003Dz3veEI49c6b6Q, out var _0023_003DzSeznUY9fyh7N);
						item2._0023_003Dz5wuclIYLT3F_0024(_0023_003Dz3veEI49c6b6Q);
						item2._0023_003DztcQlh8b6GxQV(_0023_003DzSeznUY9fyh7N);
						if (dictionary2.ContainsKey(item3))
						{
							dictionary2[item3].Add(item2);
						}
						else
						{
							dictionary2.Add(item3, new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> { item2 });
						}
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				if (dictionary.ContainsKey(item2._0023_003Dz0tIOZG5ZfcAY()))
				{
					dictionary[item2._0023_003Dz0tIOZG5ZfcAY()].Add(item2);
					continue;
				}
				dictionary.Add(item2._0023_003Dz0tIOZG5ZfcAY(), new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> { item2 });
			}
		}
		list.AddRange(_0023_003DzG7WKNCpcpyWYMCBS0Q_003D_003D(dictionary2, _0023_003DzxH4ozIo_003D));
		foreach (KeyValuePair<AssemblyLeaf, List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>> item4 in dictionary)
		{
			foreach (IGrouping<int, _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> item5 in from _0023_003DzBJFJHwk_003D in item4.Value
				group _0023_003DzBJFJHwk_003D by _0023_003DzBJFJHwk_003D._0023_003DzuxTqAp2a_0024JOK())
			{
				if (item5.Key == -1)
				{
					foreach (_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT item6 in item5)
					{
						HdlCurve item = ((!item6._0023_003DzSy0j_0024ACSBvym()) ? ((HdlCurve)new HdlLinearPath(new Point2D[2]
						{
							new Point2D(item6._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0], item6._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1]),
							new Point2D(item6._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3], item6._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4])
						}, item6._0023_003Dz0tIOZG5ZfcAY().Entity, item6._0023_003DzuxTqAp2a_0024JOK(), item6._0023_003Dz0tIOZG5ZfcAY().Parents, item6._0023_003DzHptl2yRuV4Y_0024())) : ((HdlCurve)new HdlPoint(new Point2D(item6._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0], item6._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1]), item6._0023_003Dz0tIOZG5ZfcAY().Entity, item6._0023_003Dz0tIOZG5ZfcAY().Parents, item6._0023_003DzHptl2yRuV4Y_0024())));
						list.Add(item);
					}
					continue;
				}
				foreach (List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> item7 in _0023_003DzV_0024R08Y_8ddhkzfPYvw_003D_003D(item5.ToList(), _0023_003DzxH4ozIo_003D))
				{
					Point2D[] array = new Point2D[item7.Count + 1];
					int num;
					for (num = 0; num < item7.Count; num++)
					{
						array[num] = new Point2D(item7[num]._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0], item7[num]._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1]);
					}
					_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2 = item7.Last();
					array[num] = new Point2D(_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3], _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4]);
					if (Utility.AreCollinear(array, _0023_003DzxH4ozIo_003D * Utility._0023_003DzheSR8QM7q9ya, out var _))
					{
						array = new Point2D[2]
						{
							_0023_003DzqaXQ3yxGwrykWYQf2A_003D_003D(item7).Item1,
							_0023_003DzqaXQ3yxGwrykWYQf2A_003D_003D(item7).Item2
						};
					}
					list.Add(new HdlLinearPath(array, _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2._0023_003Dz0tIOZG5ZfcAY().Entity, _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2._0023_003DzuxTqAp2a_0024JOK(), _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2._0023_003Dz0tIOZG5ZfcAY().Parents, _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2._0023_003DzHptl2yRuV4Y_0024()));
				}
			}
		}
		return list.ToArray();
	}

	private Tuple<Point2D, Point2D> _0023_003DzqaXQ3yxGwrykWYQf2A_003D_003D(List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzyIUKu5w_003D)
	{
		List<Point2D> list = _0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(_0023_003DzyIUKu5w_003D);
		double num = -2147483648.0;
		Tuple<Point2D, Point2D> result = Tuple.Create(Point2D.Origin, Point2D.Origin);
		for (int i = 0; i < list.Count - 1; i++)
		{
			for (int j = i + 1; j < list.Count; j++)
			{
				double num2 = list[i].DistanceTo(list[j]);
				if (num2 > num)
				{
					num = num2;
					result = Tuple.Create(list[i], list[j]);
				}
			}
		}
		return result;
	}

	private List<Point2D> _0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzyIUKu5w_003D)
	{
		List<Point2D> list = new List<Point2D>();
		foreach (_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT item in _0023_003DzyIUKu5w_003D)
		{
			list.Add(new Point2D(item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0], item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1]));
			list.Add(new Point2D(item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3], item._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4]));
		}
		return list;
	}

	private List<HdlArc> _0023_003DzG7WKNCpcpyWYMCBS0Q_003D_003D(Dictionary<_0023_003DzOMV8NDKkemw9Bwhd_k_00245Q_kffIIJ, List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>> _0023_003Dzd7nry7g_003D, double _0023_003DzxH4ozIo_003D)
	{
		CirclePointComparer comparer = new CirclePointComparer();
		List<HdlArc> list = new List<HdlArc>();
		foreach (_0023_003DzOMV8NDKkemw9Bwhd_k_00245Q_kffIIJ key in _0023_003Dzd7nry7g_003D.Keys)
		{
			_0023_003DzaiwNQEWTVEK48te_0024K2mGAx1XNPoTvI5g8x0_LNM_003D comparer2 = new _0023_003DzaiwNQEWTVEK48te_0024K2mGAx1XNPoTvI5g8x0_LNM_003D(key._0023_003DzSVz6jiA_003D);
			List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> list2 = _0023_003Dzd7nry7g_003D[key];
			if (list2.Count < 1)
			{
				continue;
			}
			foreach (List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> item in _0023_003DzV_0024R08Y_8ddhkzfPYvw_003D_003D(list2, _0023_003DzxH4ozIo_003D))
			{
				List<PointOnCircle> list3 = new List<PointOnCircle>();
				for (int i = 0; i < item.Count; i++)
				{
					_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2 = item[i];
					list3.Add(new PointOnCircle(_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2._0023_003DzTSuhvXlm2E5e(), _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2._0023_003Dz1r_0024EACCB51W_(), _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2._0023_003Dz5puEqLFRQPr9(), isEnd: false));
					list3.Add(new PointOnCircle(_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2._0023_003DzcW80V_0024_00240bNpd(), _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2._0023_003DzBnomfpcT4JwN(), _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2._0023_003DzZs_7xWVA_0024dTc(), isEnd: false));
				}
				list3 = list3.Distinct(comparer2).ToList();
				list3.First().IsEnd = true;
				list3.Last().IsEnd = true;
				list3.Sort(comparer);
				if (list3.Count < 2)
				{
					continue;
				}
				double num = ((item.Count > 1) ? (1.5 * key._0023_003Dzv3_XI_A_003D.Length / (double)item.Count) : (Math.PI / 3.0));
				int _0023_003DzwZkhmzY_003D;
				int _0023_003DzIZJbb1c_003D;
				bool flag = _0023_003DzZzkiW4g6JvC1(list3, num, out _0023_003DzwZkhmzY_003D, out _0023_003DzIZJbb1c_003D);
				double num2 = list3[_0023_003DzwZkhmzY_003D].Angle;
				double num3 = list3[_0023_003DzIZJbb1c_003D].Angle;
				if (num3 < num2)
				{
					num2 = 0.0 - (Math.PI * 2.0 - num2);
				}
				if (list3.Count == 2)
				{
					Interval _0023_003Dz6pajdGM_003D = new Interval(num2, num3);
					if (_0023_003Dz6pajdGM_003D.Length > Math.PI * 2.0)
					{
						_0023_003Dz6pajdGM_003D.Reverse();
					}
					list.Add(new HdlArc(key._0023_003DzpevenEk_003D.Clone() as Point3D, key._0023_003DzSVz6jiA_003D, _0023_003Dz6pajdGM_003D, item[0]._0023_003Dz0tIOZG5ZfcAY().Entity, item[0]._0023_003DzuxTqAp2a_0024JOK(), item[0]._0023_003Dz0tIOZG5ZfcAY().Parents, item[0]._0023_003DzHptl2yRuV4Y_0024()));
				}
				else
				{
					if (!flag && Math.Abs(num2) < num && Math.PI * 2.0 - num3 < num && list3.Count >= 8)
					{
						num3 = Math.PI * 2.0;
						num2 = 0.0;
					}
					list.Add(new HdlArc(key._0023_003DzpevenEk_003D.Clone() as Point3D, key._0023_003DzSVz6jiA_003D, new Interval(num2, num3), item[0]._0023_003Dz0tIOZG5ZfcAY().Entity, item[0]._0023_003DzuxTqAp2a_0024JOK(), item[0]._0023_003Dz0tIOZG5ZfcAY().Parents, item[0]._0023_003DzHptl2yRuV4Y_0024()));
				}
			}
		}
		return list;
	}

	private bool _0023_003DzZzkiW4g6JvC1(List<PointOnCircle> _0023_003DzqQtwmz8_003D, double _0023_003DzOZ6Gosv6aBqb, out int _0023_003DzwZkhmzY_003D, out int _0023_003DzIZJbb1c_003D)
	{
		_0023_003DzwZkhmzY_003D = 0;
		_0023_003DzIZJbb1c_003D = _0023_003DzqQtwmz8_003D.Count - 1;
		bool result = false;
		for (int i = 0; i < _0023_003DzqQtwmz8_003D.Count - 1; i++)
		{
			if (_0023_003DzqQtwmz8_003D[i + 1].IsEnd && _0023_003DzqQtwmz8_003D[i].IsEnd && _0023_003DzqQtwmz8_003D[i + 1].Angle - _0023_003DzqQtwmz8_003D[i].Angle > _0023_003DzOZ6Gosv6aBqb)
			{
				result = true;
				if (i < _0023_003DzqQtwmz8_003D.Count - 2)
				{
					_0023_003DzwZkhmzY_003D = i + 1;
					_0023_003DzIZJbb1c_003D = i;
				}
				else
				{
					_0023_003DzwZkhmzY_003D = i + 1;
					_0023_003DzIZJbb1c_003D = i;
				}
			}
		}
		return result;
	}

	private bool _0023_003DzRBRZk8ic93rt(double _0023_003Dz3YfTAqg_003D, double _0023_003DzpilgH4E_003D, double _0023_003DzRFb1SGo_003D, double _0023_003Dz8qV981c_003D, _0023_003DzOMV8NDKkemw9Bwhd_k_00245Q_kffIIJ _0023_003DzN4MDZ_0024c_003D, out double _0023_003Dz3veEI49c6b6Q, out double _0023_003DzSeznUY9fyh7N)
	{
		_0023_003Dz3veEI49c6b6Q = (_0023_003DzSeznUY9fyh7N = 0.0);
		_ = _0023_003DzN4MDZ_0024c_003D._0023_003DzSVz6jiA_003D;
		double x = _0023_003DzN4MDZ_0024c_003D._0023_003DzpevenEk_003D.X;
		double y = _0023_003DzN4MDZ_0024c_003D._0023_003DzpevenEk_003D.Y;
		_ = _0023_003DzN4MDZ_0024c_003D._0023_003Dzv3_XI_A_003D;
		_ = _0023_003DzN4MDZ_0024c_003D._0023_003Dzv3_XI_A_003D;
		_0023_003Dz3_RK3NySGSUi(_0023_003Dz3YfTAqg_003D, _0023_003DzpilgH4E_003D, x, y, out _0023_003Dz3veEI49c6b6Q);
		_0023_003Dz3_RK3NySGSUi(_0023_003DzRFb1SGo_003D, _0023_003Dz8qV981c_003D, x, y, out _0023_003DzSeznUY9fyh7N);
		return true;
	}

	private void _0023_003Dzk2bMwTd_0024oRGZ(IList<Entity> _0023_003DzWc9WmS8VMsuA, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, Transformation _0023_003DzNDQ_E88_003D, HiddenLinesViewSettings _0023_003DzAoD9C5rPw8G4, double[] _0023_003DzwTc0B2NdlyUi, Stack<BlockReference> _0023_003Dzq5nwX2I_003D)
	{
		HdlViewSettings.Camera.GetFrame(out var origin, out var camX, out var camY, out var _);
		Plane _0023_003DzyRBxdOcXxUqEY95Wbg_003D_003D = new Plane(origin, camX, camY);
		RectangleF _0023_003Dzl1cXRIw_003D = RectangleF.Empty;
		if (_0023_003DzheS2h4tdfFfa)
		{
			_0023_003Dzl1cXRIw_003D = HdlViewSettings.Window;
		}
		foreach (Entity item in _0023_003DzWc9WmS8VMsuA)
		{
			if (!item.IsVisible(null, _0023_003DzeWJg3NJnk3WA, attributeReferenceVisibilityType.Normal))
			{
				continue;
			}
			Circle arc2;
			if (item is BlockReference blockReference)
			{
				_0023_003Dzq5nwX2I_003D.Push(blockReference);
				_0023_003Dzk2bMwTd_0024oRGZ(_0023_003DzJO1FWlQ_003D[blockReference.BlockName].Entities, _0023_003DzeWJg3NJnk3WA, _0023_003DzJO1FWlQ_003D, _0023_003DzNDQ_E88_003D * blockReference.GetFullTransformation(_0023_003DzJO1FWlQ_003D), _0023_003DzAoD9C5rPw8G4, _0023_003DzwTc0B2NdlyUi, _0023_003Dzq5nwX2I_003D);
				_0023_003Dzq5nwX2I_003D.Pop();
			}
			else if (item is Brep brep)
			{
				for (int i = 0; i < brep.Edges.Length; i++)
				{
					Brep.Edge edge = brep.Edges[i];
					if (edge.Curve is Circle || (edge.Curve is Ellipse && ((Ellipse)edge.Curve).IsCircle))
					{
						_0023_003DzTp9fSt8HMqaE(_0023_003DzNDQ_E88_003D, _0023_003DzAoD9C5rPw8G4, _0023_003DzwTc0B2NdlyUi, edge.Curve, _0023_003DzyRBxdOcXxUqEY95Wbg_003D_003D, _0023_003Dzl1cXRIw_003D, item, _0023_003Dzq5nwX2I_003D, i);
					}
				}
			}
			else if (item is Surface surface)
			{
				int num = 0;
				foreach (ICurve contour in surface.Trimming.ContourList)
				{
					ICurve[] individualCurves = contour.GetIndividualCurves();
					for (int j = 0; j < individualCurves.Length; j++)
					{
						TrimCurve trimCurve = (TrimCurve)individualCurves[j];
						Circle arc;
						if (trimCurve.Edge is Circle || trimCurve.Edge is Ellipse { IsCircle: not false })
						{
							_0023_003DzTp9fSt8HMqaE(_0023_003DzNDQ_E88_003D, _0023_003DzAoD9C5rPw8G4, _0023_003DzwTc0B2NdlyUi, trimCurve.Edge, _0023_003DzyRBxdOcXxUqEY95Wbg_003D_003D, _0023_003Dzl1cXRIw_003D, item, _0023_003Dzq5nwX2I_003D, num);
						}
						else if (trimCurve.Edge is Curve curve && curve.TryGetArc(out arc))
						{
							_0023_003DzTp9fSt8HMqaE(_0023_003DzNDQ_E88_003D, _0023_003DzAoD9C5rPw8G4, _0023_003DzwTc0B2NdlyUi, arc, _0023_003DzyRBxdOcXxUqEY95Wbg_003D_003D, _0023_003Dzl1cXRIw_003D, item, _0023_003Dzq5nwX2I_003D, num);
						}
						num++;
					}
				}
			}
			else if (item is Circle || item is Ellipse { IsCircle: not false })
			{
				_0023_003DzTp9fSt8HMqaE(_0023_003DzNDQ_E88_003D, _0023_003DzAoD9C5rPw8G4, _0023_003DzwTc0B2NdlyUi, (ICurve)item, _0023_003DzyRBxdOcXxUqEY95Wbg_003D_003D, _0023_003Dzl1cXRIw_003D, item, _0023_003Dzq5nwX2I_003D, -1);
			}
			else if (item is Curve curve2 && curve2.TryGetArc(out arc2))
			{
				_0023_003DzTp9fSt8HMqaE(_0023_003DzNDQ_E88_003D, _0023_003DzAoD9C5rPw8G4, _0023_003DzwTc0B2NdlyUi, arc2, _0023_003DzyRBxdOcXxUqEY95Wbg_003D_003D, _0023_003Dzl1cXRIw_003D, item, _0023_003Dzq5nwX2I_003D, -1);
			}
		}
	}

	private List<List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>> _0023_003DzV_0024R08Y_8ddhkzfPYvw_003D_003D(List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzyIUKu5w_003D, double _0023_003DzxH4ozIo_003D)
	{
		List<List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>> list = new List<List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>>();
		double num = _0023_003DzxH4ozIo_003D * Utility._0023_003DzheSR8QM7q9ya;
		List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> list2 = new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>();
		list2.Add(_0023_003DzyIUKu5w_003D[0]);
		_0023_003DzyIUKu5w_003D.RemoveAt(0);
		Point2D _0023_003DzlY77YgY_003D = new Point2D(list2[0]._0023_003DzTSuhvXlm2E5e(), list2[0]._0023_003Dz1r_0024EACCB51W_());
		Point2D _0023_003DzlY77YgY_003D2 = new Point2D(list2[0]._0023_003DzcW80V_0024_00240bNpd(), list2[0]._0023_003DzBnomfpcT4JwN());
		while (_0023_003DzyIUKu5w_003D.Count > 0)
		{
			double _0023_003DzTnVXy6ZEf8OP;
			bool _0023_003DzgLASWEgt0goG;
			int index = _0023_003DzdZMQDskek2iD(_0023_003DzlY77YgY_003D, _0023_003DzyIUKu5w_003D, _0023_003Dzn9EIjD5r8BD3: true, out _0023_003DzTnVXy6ZEf8OP, out _0023_003DzgLASWEgt0goG);
			_ = _0023_003DzyIUKu5w_003D[index];
			double _0023_003DzTnVXy6ZEf8OP2;
			bool _0023_003DzgLASWEgt0goG2;
			int index2 = _0023_003DzdZMQDskek2iD(_0023_003DzlY77YgY_003D2, _0023_003DzyIUKu5w_003D, _0023_003Dzn9EIjD5r8BD3: false, out _0023_003DzTnVXy6ZEf8OP2, out _0023_003DzgLASWEgt0goG2);
			_ = _0023_003DzyIUKu5w_003D[index2];
			bool flag = false;
			Point2D b = new Point2D(list2[list2.Count - 1]._0023_003DzcW80V_0024_00240bNpd(), list2[list2.Count - 1]._0023_003DzBnomfpcT4JwN());
			double num2 = Point2D.DistanceSquared(new Point2D(list2[0]._0023_003DzTSuhvXlm2E5e(), list2[0]._0023_003Dz1r_0024EACCB51W_()), b);
			bool flag2 = num2 < num && num2 < _0023_003DzTnVXy6ZEf8OP && num2 < _0023_003DzTnVXy6ZEf8OP2;
			if (Math.Min(_0023_003DzTnVXy6ZEf8OP, _0023_003DzTnVXy6ZEf8OP2) < num && !flag2)
			{
				flag = true;
			}
			if (flag)
			{
				if (_0023_003DzTnVXy6ZEf8OP < _0023_003DzTnVXy6ZEf8OP2)
				{
					if (_0023_003DzgLASWEgt0goG)
					{
						_0023_003DzyIUKu5w_003D[index] = _0023_003DzyIUKu5w_003D[index]._0023_003Dz0wcqTpk_003D();
					}
					list2.Insert(0, _0023_003DzyIUKu5w_003D[index]);
					_0023_003DzyIUKu5w_003D.RemoveAt(index);
					_0023_003DzlY77YgY_003D = new Point2D(list2[0]._0023_003DzTSuhvXlm2E5e(), list2[0]._0023_003Dz1r_0024EACCB51W_());
				}
				else
				{
					if (_0023_003DzgLASWEgt0goG2)
					{
						_0023_003DzyIUKu5w_003D[index2] = _0023_003DzyIUKu5w_003D[index2]._0023_003Dz0wcqTpk_003D();
					}
					list2.Add(_0023_003DzyIUKu5w_003D[index2]);
					_0023_003DzyIUKu5w_003D.RemoveAt(index2);
					_0023_003DzlY77YgY_003D2 = new Point2D(list2[list2.Count - 1]._0023_003DzcW80V_0024_00240bNpd(), list2[list2.Count - 1]._0023_003DzBnomfpcT4JwN());
				}
			}
			else
			{
				list.Add(list2);
				if (_0023_003DzyIUKu5w_003D.Count <= 0)
				{
					break;
				}
				list2 = new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> { _0023_003DzyIUKu5w_003D[0] };
				_0023_003DzyIUKu5w_003D.RemoveAt(0);
				_0023_003DzlY77YgY_003D = new Point2D(list2[0]._0023_003DzTSuhvXlm2E5e(), list2[0]._0023_003Dz1r_0024EACCB51W_());
				_0023_003DzlY77YgY_003D2 = new Point2D(list2[list2.Count - 1]._0023_003DzcW80V_0024_00240bNpd(), list2[0]._0023_003DzBnomfpcT4JwN());
			}
		}
		if (list2.Count > 0)
		{
			list.Add(list2);
		}
		return list;
	}

	private int _0023_003DzdZMQDskek2iD(Point2D _0023_003DzlY77YgY_003D, List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzcDEsV8s_003D, bool _0023_003Dzn9EIjD5r8BD3, out double _0023_003DzTnVXy6ZEf8OP, out bool _0023_003DzgLASWEgt0goG)
	{
		_0023_003DzgLASWEgt0goG = false;
		_0023_003DzTnVXy6ZEf8OP = double.MaxValue;
		int result = -1;
		for (int i = 0; i < _0023_003DzcDEsV8s_003D.Count; i++)
		{
			_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2 = _0023_003DzcDEsV8s_003D[i];
			Point2D b = new Point2D(_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2._0023_003DzTSuhvXlm2E5e(), _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2._0023_003Dz1r_0024EACCB51W_());
			Point2D b2 = new Point2D(_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2._0023_003DzcW80V_0024_00240bNpd(), _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2._0023_003DzBnomfpcT4JwN());
			double num = Point2D.DistanceSquared(_0023_003DzlY77YgY_003D, b);
			double num2 = Point2D.DistanceSquared(_0023_003DzlY77YgY_003D, b2);
			double num3 = Math.Min(num, num2);
			if (!(num3 < _0023_003DzTnVXy6ZEf8OP))
			{
				continue;
			}
			_0023_003DzTnVXy6ZEf8OP = num3;
			result = i;
			_0023_003DzgLASWEgt0goG = false;
			if (_0023_003Dzn9EIjD5r8BD3)
			{
				if (num < num2)
				{
					_0023_003DzgLASWEgt0goG = true;
				}
			}
			else if (num > num2)
			{
				_0023_003DzgLASWEgt0goG = true;
			}
		}
		return result;
	}

	private void _0023_003Dz3_RK3NySGSUi(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DziK8wxe9ky0iH, double _0023_003Dz4RNxWUPbjw_0024e, out double _0023_003Dz6pajdGM_003D)
	{
		double y = _0023_003Dz40R7bAU_003D - _0023_003Dz4RNxWUPbjw_0024e;
		double x = _0023_003DzBJFJHwk_003D - _0023_003DziK8wxe9ky0iH;
		_0023_003Dz6pajdGM_003D = Math.Atan2(y, x);
		if (_0023_003Dz6pajdGM_003D < 0.0)
		{
			_0023_003Dz6pajdGM_003D = Math.PI * 2.0 + _0023_003Dz6pajdGM_003D;
		}
	}

	private static bool _0023_003Dzu6pFkCKqLOy5Vj_002422w_003D_003D(AnalyticSurf _0023_003Dz26LjGxJ3AWq7, IList<ICurve> _0023_003DzKLgYld2LjjyU)
	{
		List<ICurve> list = new List<ICurve>();
		foreach (ICurve item in _0023_003DzKLgYld2LjjyU)
		{
			if (item is Circle || (item is Ellipse && ((Ellipse)item).IsCircle))
			{
				list.Add(item);
			}
		}
		return list.Count > 0;
	}

	private void _0023_003DzTp9fSt8HMqaE(Transformation _0023_003DzNDQ_E88_003D, HiddenLinesViewSettings _0023_003DzAoD9C5rPw8G4, double[] _0023_003DzwTc0B2NdlyUi, ICurve _0023_003DzTx2aqr8_003D, Plane _0023_003DzyRBxdOcXxUqEY95Wbg_003D_003D, RectangleF _0023_003Dzl1cXRIw_003D, Entity _0023_003Dzalvl9z8_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, int _0023_003DzL8NvYU0_003D)
	{
		AssemblyLeaf _0023_003Dzq0Mt9hYROxWQ = new AssemblyLeaf(_0023_003Dzalvl9z8_003D, Utility.CloneStack(_0023_003Dzq5nwX2I_003D));
		double scaleFactor = _0023_003DzNDQ_E88_003D.ScaleFactorX;
		if (!_0023_003DzNDQ_E88_003D.IsScaleFactorUniform() && !_0023_003DzNDQ_E88_003D.IsScaleFactorUniformForPlanar(((PlanarEntity)_0023_003DzTx2aqr8_003D).Plane, ref scaleFactor))
		{
			return;
		}
		ICurve curve = (ICurve)_0023_003DzTx2aqr8_003D.Clone();
		((Entity)curve).TransformBy(_0023_003DzNDQ_E88_003D);
		Plane plane = ((PlanarEntity)curve).Plane;
		if (Vector3D.AreCoincident(plane.AxisZ, HdlViewSettings.Camera.ViewNormal, Utility._0023_003Dzjyaz_Vfaky9X))
		{
			if (_0023_003DzTx2aqr8_003D is Arc)
			{
				Point3D startPoint = curve.StartPoint;
				Point2D point2D = HdlViewSettings.Camera.WorldToScreen(startPoint, _0023_003DzAoD9C5rPw8G4.ViewBounds);
				Point3D endPoint = curve.EndPoint;
				Point2D point2D2 = HdlViewSettings.Camera.WorldToScreen(endPoint, _0023_003DzAoD9C5rPw8G4.ViewBounds);
				Point3D point = curve.PointAt(curve.Domain.Mid);
				Point2D point2D3 = HdlViewSettings.Camera.WorldToScreen(point, _0023_003DzAoD9C5rPw8G4.ViewBounds);
				Point3D origin = plane.Origin;
				Point2D point2D4 = HdlViewSettings.Camera.WorldToScreen(origin, _0023_003DzAoD9C5rPw8G4.ViewBounds);
				if (_0023_003DzheS2h4tdfFfa && !_0023_003Dzl1cXRIw_003D.Contains(new PointF((float)point2D4.X, (float)point2D4.Y)))
				{
					return;
				}
				double num = point2D4.DistanceTo(point2D);
				if (!(num < 1E-12))
				{
					Circle circle = new Circle(point2D4.X, point2D4.Y, 0.0, num);
					circle.ClosestPointTo(new Point3D(point2D.X, point2D.Y), out var t);
					circle.ClosestPointTo(new Point3D(point2D2.X, point2D2.Y), out var t2);
					circle.ClosestPointTo(new Point3D(point2D3.X, point2D3.Y), out var t3);
					Interval _0023_003DzzJ_0024HnAY_003D = new Interval(t, t2);
					if (Math.Abs(_0023_003DzzJ_0024HnAY_003D.Length) < 1E-12)
					{
						_0023_003DzvoYNo_iIf2aW(point2D4, num, new Interval(0.0, Math.PI * 2.0), _0023_003Dzq0Mt9hYROxWQ, _0023_003DzL8NvYU0_003D);
						return;
					}
					_0023_003DzXsJ2_3KLZyAJ(ref _0023_003DzzJ_0024HnAY_003D, t3);
					_0023_003DzvoYNo_iIf2aW(point2D4, num, _0023_003DzzJ_0024HnAY_003D, _0023_003Dzq0Mt9hYROxWQ, _0023_003DzL8NvYU0_003D);
				}
			}
			else
			{
				Point3D startPoint2 = curve.StartPoint;
				Point3D origin2 = plane.Origin;
				Point2D point2D5 = HdlViewSettings.Camera.WorldToScreen(startPoint2, _0023_003DzAoD9C5rPw8G4.ViewBounds);
				Point2D point2D6 = HdlViewSettings.Camera.WorldToScreen(origin2, _0023_003DzAoD9C5rPw8G4.ViewBounds);
				if (!_0023_003DzheS2h4tdfFfa || _0023_003Dzl1cXRIw_003D.Contains(new PointF((float)point2D6.X, (float)point2D6.Y)))
				{
					double _0023_003DzEGKj_0024SNUUihi = point2D5.DistanceTo(point2D6);
					_0023_003DzvoYNo_iIf2aW(point2D6, _0023_003DzEGKj_0024SNUUihi, new Interval(0.0, Math.PI * 2.0), _0023_003Dzq0Mt9hYROxWQ, _0023_003DzL8NvYU0_003D);
				}
			}
		}
		else
		{
			if (!Vector3D.AreOpposite(plane.AxisZ, HdlViewSettings.Camera.ViewNormal, Utility._0023_003Dzjyaz_Vfaky9X))
			{
				return;
			}
			if (_0023_003DzTx2aqr8_003D is Arc)
			{
				Point3D startPoint3 = curve.StartPoint;
				Point2D point2D7 = HdlViewSettings.Camera.WorldToScreen(startPoint3, _0023_003DzAoD9C5rPw8G4.ViewBounds);
				Point3D endPoint2 = curve.EndPoint;
				Point2D point2D8 = HdlViewSettings.Camera.WorldToScreen(endPoint2, _0023_003DzAoD9C5rPw8G4.ViewBounds);
				Point3D point2 = curve.PointAt(curve.Domain.Mid);
				Point2D point2D9 = HdlViewSettings.Camera.WorldToScreen(point2, _0023_003DzAoD9C5rPw8G4.ViewBounds);
				Point3D origin3 = plane.Origin;
				Point2D point2D10 = HdlViewSettings.Camera.WorldToScreen(origin3, _0023_003DzAoD9C5rPw8G4.ViewBounds);
				if (_0023_003DzheS2h4tdfFfa && !_0023_003Dzl1cXRIw_003D.Contains(new PointF((float)point2D10.X, (float)point2D10.Y)))
				{
					return;
				}
				double num2 = point2D10.DistanceTo(point2D7);
				if (!(num2 < 1E-12))
				{
					Circle circle2 = new Circle(point2D10.X, point2D10.Y, 0.0, num2);
					circle2.ClosestPointTo(new Point3D(point2D7.X, point2D7.Y), out var t4);
					circle2.ClosestPointTo(new Point3D(point2D8.X, point2D8.Y), out var t5);
					circle2.ClosestPointTo(new Point3D(point2D9.X, point2D9.Y), out var t6);
					Interval _0023_003DzzJ_0024HnAY_003D2 = new Interval(t4, t5);
					if (Math.Abs(_0023_003DzzJ_0024HnAY_003D2.Length) < 1E-12)
					{
						_0023_003DzvoYNo_iIf2aW(point2D10, num2, new Interval(0.0, Math.PI * 2.0), _0023_003Dzq0Mt9hYROxWQ, _0023_003DzL8NvYU0_003D);
						return;
					}
					_0023_003Dz2Xr0BTI_0024az5j1jMWn2xq5vI_003D(ref _0023_003DzzJ_0024HnAY_003D2, t6);
					_0023_003DzvoYNo_iIf2aW(point2D10, num2, _0023_003DzzJ_0024HnAY_003D2, _0023_003Dzq0Mt9hYROxWQ, _0023_003DzL8NvYU0_003D);
				}
			}
			else
			{
				Point3D startPoint4 = curve.StartPoint;
				Point3D origin4 = plane.Origin;
				Point2D b = HdlViewSettings.Camera.WorldToScreen(startPoint4, _0023_003DzAoD9C5rPw8G4.ViewBounds);
				Point2D point2D11 = HdlViewSettings.Camera.WorldToScreen(origin4, _0023_003DzAoD9C5rPw8G4.ViewBounds);
				if (!_0023_003DzheS2h4tdfFfa || _0023_003Dzl1cXRIw_003D.Contains(new PointF((float)point2D11.X, (float)point2D11.Y)))
				{
					double _0023_003DzEGKj_0024SNUUihi2 = point2D11.DistanceTo(b);
					_0023_003DzvoYNo_iIf2aW(point2D11, _0023_003DzEGKj_0024SNUUihi2, new Interval(0.0, Math.PI * 2.0), _0023_003Dzq0Mt9hYROxWQ, _0023_003DzL8NvYU0_003D);
				}
			}
		}
	}

	private static void _0023_003DzXsJ2_3KLZyAJ(ref Interval _0023_003DzzJ_0024HnAY_003D, double _0023_003DzSzT7UbA_003D)
	{
		if (!_0023_003DzzJ_0024HnAY_003D.Includes(_0023_003DzSzT7UbA_003D, testOpenInterval: false))
		{
			if (Math.Abs(Math.Abs(_0023_003DzzJ_0024HnAY_003D.t0) - Math.PI * 2.0) < Utility._0023_003DzxhnLabVjXjPg)
			{
				_0023_003DzzJ_0024HnAY_003D.t0 = 0.0;
			}
			else if (Math.Abs(_0023_003DzzJ_0024HnAY_003D.t1) < Utility._0023_003DzxhnLabVjXjPg)
			{
				_0023_003DzzJ_0024HnAY_003D.t1 = Math.PI * 2.0;
			}
			else if (_0023_003DzzJ_0024HnAY_003D.IsDecreasing)
			{
				_0023_003DzzJ_0024HnAY_003D.t1 += Math.PI * 2.0;
			}
		}
	}

	private static void _0023_003Dz2Xr0BTI_0024az5j1jMWn2xq5vI_003D(ref Interval _0023_003DzzJ_0024HnAY_003D, double _0023_003DzSzT7UbA_003D)
	{
		if (_0023_003DzzJ_0024HnAY_003D.IsDecreasing && Math.Abs(_0023_003DzzJ_0024HnAY_003D.t0) < Utility._0023_003DzxhnLabVjXjPg)
		{
			_0023_003DzzJ_0024HnAY_003D.t0 += Math.PI * 2.0;
		}
		else
		{
			Utility.Swap(ref _0023_003DzzJ_0024HnAY_003D.t0, ref _0023_003DzzJ_0024HnAY_003D.t1);
		}
		if (!_0023_003DzzJ_0024HnAY_003D.Includes(_0023_003DzSzT7UbA_003D, testOpenInterval: false))
		{
			if (Math.Abs(Math.Abs(_0023_003DzzJ_0024HnAY_003D.t1) - Math.PI * 2.0) < Utility._0023_003DzxhnLabVjXjPg)
			{
				_0023_003DzzJ_0024HnAY_003D.t1 = 0.0;
			}
			else if (Math.Abs(_0023_003DzzJ_0024HnAY_003D.t0) < Utility._0023_003DzxhnLabVjXjPg)
			{
				Utility.Swap(ref _0023_003DzzJ_0024HnAY_003D.t0, ref _0023_003DzzJ_0024HnAY_003D.t1);
				_0023_003DzzJ_0024HnAY_003D.t1 = Math.PI * 2.0;
			}
			else if (_0023_003DzzJ_0024HnAY_003D.IsDecreasing)
			{
				_0023_003DzzJ_0024HnAY_003D.t1 += Math.PI * 2.0;
			}
		}
	}

	private void _0023_003DzvoYNo_iIf2aW(Point2D _0023_003DzeUujDMs_003D, double _0023_003DzEGKj_0024SNUUihi, Interval _0023_003DzhbkBViI_003D, AssemblyLeaf _0023_003Dzq0Mt9hYROxWQ, int _0023_003DzL8NvYU0_003D)
	{
		_0023_003DzOMV8NDKkemw9Bwhd_k_00245Q_kffIIJ item = new _0023_003DzOMV8NDKkemw9Bwhd_k_00245Q_kffIIJ(_0023_003DzeUujDMs_003D, _0023_003DzEGKj_0024SNUUihi, _0023_003DzhbkBViI_003D.t0, _0023_003DzhbkBViI_003D.t1, null, _0023_003Dzq0Mt9hYROxWQ, _0023_003DzL8NvYU0_003D);
		if (HdlViewSettings._0023_003DzGV_0024jjdDDcXbB_xWpqA_003D_003D.ContainsKey(_0023_003Dzq0Mt9hYROxWQ))
		{
			HdlViewSettings._0023_003DzGV_0024jjdDDcXbB_xWpqA_003D_003D[_0023_003Dzq0Mt9hYROxWQ].Add(item);
			return;
		}
		HdlViewSettings._0023_003DzGV_0024jjdDDcXbB_xWpqA_003D_003D.Add(_0023_003Dzq0Mt9hYROxWQ, new List<_0023_003DzOMV8NDKkemw9Bwhd_k_00245Q_kffIIJ> { item });
	}

	internal void _0023_003Dz2_zO1L9VqNAx(IList<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzyIUKu5w_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		if (_0023_003DzzIrgzh87xtI_EdP2YA_003D_003D)
		{
			_0023_003DzTtgGeeqBjD2i++;
			_0023_003Dz3lURioVh8358 = RemovingOverlappingLinesText;
			UpdateProgress(_0023_003DzTtgGeeqBjD2i, _0023_003DzwJ3QaGJFHQh4, _0023_003Dz3lURioVh8358, _0023_003DzmHS7frs_003D);
		}
		List<_0023_003DzKmzWz_00240_003D> list = new List<_0023_003DzKmzWz_00240_003D>(_0023_003DzyIUKu5w_003D.Count);
		List<_0023_003DzKmzWz_00240_003D> list2 = new List<_0023_003DzKmzWz_00240_003D>(_0023_003DzyIUKu5w_003D.Count);
		Dictionary<double, List<_0023_003DzKmzWz_00240_003D>> dictionary = new Dictionary<double, List<_0023_003DzKmzWz_00240_003D>>(_0023_003DzyIUKu5w_003D.Count);
		List<int> list3 = new List<int>(_0023_003DzyIUKu5w_003D.Count);
		IntegerGrid integerGrid = new IntegerGrid(524288, HdlViewSettings.boxMin, HdlViewSettings.boxMax);
		int count = _0023_003DzyIUKu5w_003D.Count;
		int num = (_0023_003DzzIrgzh87xtI_EdP2YA_003D_003D ? _0023_003Dz5Faw6jTsdRm7wsDgbA_003D_003D(count) : 0);
		for (int i = 0; i < count; i++)
		{
			_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2 = _0023_003DzyIUKu5w_003D[i];
			if (_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzSy0j_0024ACSBvym())
			{
				continue;
			}
			_0023_003DzKmzWz_00240_003D _0023_003DzKmzWz_00240_003D2 = new _0023_003DzKmzWz_00240_003D();
			integerGrid.ScaleToGrid(_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzTSuhvXlm2E5e(), _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003Dz1r_0024EACCB51W_(), _0023_003DzKmzWz_00240_003D2._0023_003DzQW_0024hBdI_003D);
			integerGrid.ScaleToGrid(_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzcW80V_0024_00240bNpd(), _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzBnomfpcT4JwN(), _0023_003DzKmzWz_00240_003D2._0023_003DzCmn_5Z0_003D);
			_0023_003DzKmzWz_00240_003D2._0023_003DzCPxOJfM_003D = i;
			if (_0023_003DzKmzWz_00240_003D2._0023_003DzKSi6EjvdA_pGvThAIA_003D_003D())
			{
				list3.Add(i);
				continue;
			}
			if (_0023_003DzKmzWz_00240_003D2._0023_003Dz2lsfKGk_003D())
			{
				_0023_003DzKmzWz_00240_003D2._0023_003DzQLclF1Q_003D = _0023_003DzKmzWz_00240_003D2._0023_003DzQW_0024hBdI_003D[0];
				list2.Add(_0023_003DzKmzWz_00240_003D2);
			}
			else if (_0023_003DzKmzWz_00240_003D2._0023_003Dzq4sdH5I_003D())
			{
				_0023_003DzKmzWz_00240_003D2._0023_003DzQLclF1Q_003D = _0023_003DzKmzWz_00240_003D2._0023_003DzQW_0024hBdI_003D[1];
				list.Add(_0023_003DzKmzWz_00240_003D2);
			}
			else
			{
				double key = Math.Round(Math.Atan((_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzBnomfpcT4JwN() - _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003Dz1r_0024EACCB51W_()) / (_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzcW80V_0024_00240bNpd() - _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzTSuhvXlm2E5e())), 6);
				if (!dictionary.ContainsKey(key))
				{
					dictionary.Add(key, new List<_0023_003DzKmzWz_00240_003D> { _0023_003DzKmzWz_00240_003D2 });
				}
				else
				{
					dictionary[key].Add(_0023_003DzKmzWz_00240_003D2);
				}
			}
			if ((_0023_003DzzIrgzh87xtI_EdP2YA_003D_003D && !UpdateProgressAndCheckCancelledParallel(num, _0023_003Dz3lURioVh8358, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D)) || Cancelled(_0023_003Dzjvn7P10_003D))
			{
				return;
			}
		}
		if (_0023_003DzzIrgzh87xtI_EdP2YA_003D_003D)
		{
			_0023_003DzzIrgzh87xtI_EdP2YA_003D_003D = false;
		}
		_0023_003DzRZtSalrSw11j comparer = new _0023_003DzRZtSalrSw11j();
		list.Sort(comparer);
		list2.Sort(comparer);
		_0023_003Dz2_zO1L9VqNAx(_0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, list, _0023_003DzyIUKu5w_003D, 0, list3);
		_0023_003Dz2_zO1L9VqNAx(_0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, list2, _0023_003DzyIUKu5w_003D, 1, list3);
		Point2D point2D = Point2D.MidPoint(HdlViewSettings.boxMin, HdlViewSettings.boxMax);
		Point3D center = new Point3D(point2D.X, point2D.Y, 0.0);
		foreach (KeyValuePair<double, List<_0023_003DzKmzWz_00240_003D>> item in dictionary)
		{
			List<_0023_003DzKmzWz_00240_003D> value = item.Value;
			if (value.Count <= 1)
			{
				continue;
			}
			double key2 = item.Key;
			devDept.Geometry.Rotation rotation = new devDept.Geometry.Rotation(0.0 - key2, Vector3D.AxisZ, center);
			double num2 = rotation.Matrix[1, 0];
			double num3 = rotation.Matrix[1, 1];
			double num4 = rotation.Matrix[1, 3];
			foreach (_0023_003DzKmzWz_00240_003D item2 in value)
			{
				_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D3 = _0023_003DzyIUKu5w_003D[item2._0023_003DzCPxOJfM_003D];
				item2._0023_003DzQLclF1Q_003D = integerGrid.ScaleYToGrid(num2 * _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D3._0023_003DzTSuhvXlm2E5e() + num3 * _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D3._0023_003Dz1r_0024EACCB51W_() + num4);
			}
			value.Sort(comparer);
			int _0023_003DzHC7Mg4BtsFMeAIyGjw_003D_003D = ((!(key2 >= -Math.PI / 4.0) || !(key2 <= Math.PI / 4.0)) ? 1 : 0);
			_0023_003Dz2_zO1L9VqNAx(_0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, value, _0023_003DzyIUKu5w_003D, _0023_003DzHC7Mg4BtsFMeAIyGjw_003D_003D, list3);
		}
		list3.Sort();
		for (int num5 = list3.Count - 1; num5 >= 0; num5--)
		{
			_0023_003DzyIUKu5w_003D.RemoveAt(list3[num5]);
		}
	}

	private void _0023_003Dz2_zO1L9VqNAx(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, List<_0023_003DzKmzWz_00240_003D> _0023_003Dz_0024FbGAZO7lHMG, IList<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003DzyIUKu5w_003D, int _0023_003DzHC7Mg4BtsFMeAIyGjw_003D_003D, List<int> _0023_003DzWCb2I3Ofpf4q)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < _0023_003Dz_0024FbGAZO7lHMG.Count; i++)
		{
			_0023_003DzKmzWz_00240_003D _0023_003DzKmzWz_00240_003D2 = _0023_003Dz_0024FbGAZO7lHMG[i];
			_0023_003DzKmzWz_00240_003D2._0023_003Dzzg08ZSAHPR69(_0023_003DzHC7Mg4BtsFMeAIyGjw_003D_003D);
			_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2 = _0023_003DzyIUKu5w_003D[_0023_003DzKmzWz_00240_003D2._0023_003DzCPxOJfM_003D];
			_0023_003DzKmzWz_00240_003D2._0023_003DzmkImHGGAlo_0024P(_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003Dz7DFEa5FBC0i7(), _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003DzZk9RYiYDbmaJ());
		}
		for (int j = 0; j < _0023_003Dz_0024FbGAZO7lHMG.Count; j++)
		{
			if (j == 0 || _0023_003Dz_0024FbGAZO7lHMG[j]._0023_003DzQLclF1Q_003D > num3)
			{
				num = j;
				num3 = _0023_003Dz_0024FbGAZO7lHMG[j]._0023_003DzQLclF1Q_003D;
				for (int k = j + 1; k < _0023_003Dz_0024FbGAZO7lHMG.Count; k++)
				{
					if (_0023_003Dz_0024FbGAZO7lHMG[k]._0023_003DzQLclF1Q_003D > num3)
					{
						num2 = k;
						break;
					}
				}
				if (num2 == num)
				{
					num2 = _0023_003Dz_0024FbGAZO7lHMG.Count;
				}
			}
			_0023_003DzKmzWz_00240_003D _0023_003DzKmzWz_00240_003D3 = _0023_003Dz_0024FbGAZO7lHMG[j];
			for (int l = num; l < num2; l++)
			{
				_0023_003DzKmzWz_00240_003D _0023_003DzKmzWz_00240_003D4 = _0023_003Dz_0024FbGAZO7lHMG[l];
				if (!_0023_003DzKmzWz_00240_003D4._0023_003Dzx9ez3pU_003D && j != l && _0023_003DzKmzWz_00240_003D3._0023_003DzZqSqKm8_003D >= _0023_003DzKmzWz_00240_003D4._0023_003DzZqSqKm8_003D && _0023_003DzKmzWz_00240_003D3._0023_003DztvD0Jdc_003D <= _0023_003DzKmzWz_00240_003D4._0023_003DztvD0Jdc_003D && _0023_003DzKmzWz_00240_003D3._0023_003DzRN68t7g_003D >= _0023_003DzKmzWz_00240_003D4._0023_003DzRN68t7g_003D && _0023_003DzKmzWz_00240_003D3._0023_003DzuBiD7yI_003D >= _0023_003DzKmzWz_00240_003D4._0023_003DzuBiD7yI_003D && _0023_003DzKmzWz_00240_003D4._0023_003DzRN68t7g_003D >= _0023_003Dz4rcJR0VRC6F_csqIXQ_003D_003D)
				{
					float num4 = (HdlViewSettings.KeepEntityLineWeight ? _0023_003DzyIUKu5w_003D[_0023_003DzKmzWz_00240_003D3._0023_003DzCPxOJfM_003D]._0023_003DzHptl2yRuV4Y_0024().LineWeight : HdlViewSettings.PenWidth(_0023_003DzyIUKu5w_003D[_0023_003DzKmzWz_00240_003D3._0023_003DzCPxOJfM_003D]._0023_003DzEKSHIVc_003D));
					float num5 = (HdlViewSettings.KeepEntityLineWeight ? _0023_003DzyIUKu5w_003D[_0023_003DzKmzWz_00240_003D4._0023_003DzCPxOJfM_003D]._0023_003DzHptl2yRuV4Y_0024().LineWeight : HdlViewSettings.PenWidth(_0023_003DzyIUKu5w_003D[_0023_003DzKmzWz_00240_003D4._0023_003DzCPxOJfM_003D]._0023_003DzEKSHIVc_003D));
					if (num4 <= num5)
					{
						_0023_003DzKmzWz_00240_003D3._0023_003Dzx9ez3pU_003D = true;
						_0023_003DzWCb2I3Ofpf4q.Add(_0023_003DzKmzWz_00240_003D3._0023_003DzCPxOJfM_003D);
						break;
					}
				}
			}
			if (Cancelled(_0023_003Dzjvn7P10_003D))
			{
				break;
			}
		}
	}

	private static int _0023_003Dzqs6ocmMwfQ5X(_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT _0023_003DziMjqlCo_003D, _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT _0023_003DzI4dRPW0_003D)
	{
		if (_0023_003DziMjqlCo_003D._0023_003DzIr63dnY3EK8N() < _0023_003DzI4dRPW0_003D._0023_003DzIr63dnY3EK8N())
		{
			return -1;
		}
		if (_0023_003DziMjqlCo_003D._0023_003DzIr63dnY3EK8N() > _0023_003DzI4dRPW0_003D._0023_003DzIr63dnY3EK8N())
		{
			return 1;
		}
		return 0;
	}

	private void _0023_003DzMH8JED3aar33(ref List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> _0023_003DzcDEsV8s_003D)
	{
		_0023_003DzcDEsV8s_003D.Sort(_0023_003Dzqs6ocmMwfQ5X);
		List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> list = new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>();
		List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT> list2 = new List<_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT>();
		int num;
		for (num = 0; num < _0023_003DzcDEsV8s_003D.Count; num++)
		{
			int num2 = _0023_003DzcDEsV8s_003D[num]._0023_003DzIr63dnY3EK8N();
			list2.Clear();
			_0023_003DzjJYvWCqGiL_0024s(_0023_003DzcDEsV8s_003D[num]);
			list2.Add(_0023_003DzcDEsV8s_003D[num]);
			while (++num < _0023_003DzcDEsV8s_003D.Count && _0023_003DzcDEsV8s_003D[num]._0023_003DzIr63dnY3EK8N() == num2)
			{
				_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2 = _0023_003DzcDEsV8s_003D[num];
				if (_0023_003DzjJYvWCqGiL_0024s(_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2) != 0)
				{
					list2.Add(_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT2);
				}
			}
			list2.Sort(_0023_003DzDQnM6DTZErm4);
			_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT3 = list2[0];
			for (int i = 1; i < list2.Count; i++)
			{
				_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT4 = list2[i];
				if (Utility.Compare(_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT3._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3], _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT4._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0]) == 0 && Utility.Compare(_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT3._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4], _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT4._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1]) == 0)
				{
					_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT3._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3] = _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT4._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3];
					_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT3._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4] = _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT4._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4];
				}
				else
				{
					list.Add(_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT3);
					_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT3 = _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT4;
				}
			}
			list.Add(_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT3);
			if (num == _0023_003DzcDEsV8s_003D.Count)
			{
				break;
			}
			num--;
		}
		_0023_003DzcDEsV8s_003D = list;
	}

	private static int _0023_003DzjJYvWCqGiL_0024s(_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT _0023_003DzQ9zpGF0_003D)
	{
		int num = Utility.Compare(_0023_003DzQ9zpGF0_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0], _0023_003DzQ9zpGF0_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3]);
		if (num == 0)
		{
			num = Utility.Compare(_0023_003DzQ9zpGF0_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1], _0023_003DzQ9zpGF0_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4]);
		}
		if (num == 1)
		{
			double[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D = _0023_003DzQ9zpGF0_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
			double num2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0];
			double num3 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1];
			double num4 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[2];
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0] = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3];
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1] = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4];
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[2] = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[5];
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3] = num2;
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4] = num3;
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[5] = num4;
		}
		return num;
	}

	private static int _0023_003DzDQnM6DTZErm4(_0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT _0023_003DzFj_0024IqDQ_003D, _0023_003DzUb5OrNhEJSuAWEj2tqEPWSRKMlzT _0023_003DzjdeMMkk_003D)
	{
		int result;
		if ((result = Utility.Compare(_0023_003DzFj_0024IqDQ_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0], _0023_003DzjdeMMkk_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0])) != 0)
		{
			return result;
		}
		return Utility.Compare(_0023_003DzFj_0024IqDQ_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1], _0023_003DzjdeMMkk_003D._0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1]);
	}

	internal static void _0023_003Dz_0024udsRTKS19rvSHeZ_u1mD64_003D(double _0023_003DzeMBeuAQ_003D, double _0023_003DznYtQKck_003D, double _0023_003Dz5F7_i_0024U_003D, double _0023_003DzXmrDMdc_003D, _0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, double[,] _0023_003DzFS_0024L8faKPib3, IList<int> _0023_003DzrB4XZFG2oxsT4F8o0g_003D_003D, out List<int> _0023_003DzAQKXeuJdfZIHAkje6A_003D_003D, out List<int> _0023_003DznYJLyL7e87gg3KoJaw_003D_003D)
	{
		_0023_003DzAQKXeuJdfZIHAkje6A_003D_003D = new List<int>(_0023_003DzrB4XZFG2oxsT4F8o0g_003D_003D.Count);
		_0023_003DznYJLyL7e87gg3KoJaw_003D_003D = new List<int>(_0023_003DzrB4XZFG2oxsT4F8o0g_003D_003D.Count);
		int count = _0023_003DzrB4XZFG2oxsT4F8o0g_003D_003D.Count;
		for (int i = 0; i < count; i++)
		{
			int num = _0023_003DzrB4XZFG2oxsT4F8o0g_003D_003D[i];
			int _0023_003DzQW_0024hBdI_003D = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[num]._0023_003DzQW_0024hBdI_003D;
			int _0023_003DzCmn_5Z0_003D = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[num]._0023_003DzCmn_5Z0_003D;
			int _0023_003DzqePf_00244c_003D = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[num]._0023_003DzqePf_00244c_003D;
			double num2 = _0023_003DzFS_0024L8faKPib3[_0023_003DzQW_0024hBdI_003D, 0];
			double num3 = _0023_003DzFS_0024L8faKPib3[_0023_003DzQW_0024hBdI_003D, 1];
			double num4 = _0023_003DzFS_0024L8faKPib3[_0023_003DzCmn_5Z0_003D, 0];
			double num5 = _0023_003DzFS_0024L8faKPib3[_0023_003DzCmn_5Z0_003D, 1];
			double num6 = _0023_003DzFS_0024L8faKPib3[_0023_003DzqePf_00244c_003D, 0];
			double num7 = _0023_003DzFS_0024L8faKPib3[_0023_003DzqePf_00244c_003D, 1];
			bool flag = num2 <= _0023_003DzeMBeuAQ_003D;
			bool flag2 = num4 <= _0023_003DzeMBeuAQ_003D;
			bool flag3 = num6 <= _0023_003DzeMBeuAQ_003D;
			if (flag && flag2 && flag3)
			{
				_0023_003DznYJLyL7e87gg3KoJaw_003D_003D.Add(num);
				continue;
			}
			bool flag4 = num2 >= _0023_003DznYtQKck_003D;
			bool flag5 = num4 >= _0023_003DznYtQKck_003D;
			bool flag6 = num6 >= _0023_003DznYtQKck_003D;
			if (flag4 && flag5 && flag6)
			{
				_0023_003DznYJLyL7e87gg3KoJaw_003D_003D.Add(num);
				continue;
			}
			bool flag7 = num3 <= _0023_003Dz5F7_i_0024U_003D;
			bool flag8 = num5 <= _0023_003Dz5F7_i_0024U_003D;
			bool flag9 = num7 <= _0023_003Dz5F7_i_0024U_003D;
			if (flag7 && flag8 && flag9)
			{
				_0023_003DznYJLyL7e87gg3KoJaw_003D_003D.Add(num);
				continue;
			}
			bool flag10 = num3 >= _0023_003DzXmrDMdc_003D;
			bool flag11 = num5 >= _0023_003DzXmrDMdc_003D;
			bool flag12 = num7 >= _0023_003DzXmrDMdc_003D;
			if (flag10 && flag11 && flag12)
			{
				_0023_003DznYJLyL7e87gg3KoJaw_003D_003D.Add(num);
				continue;
			}
			_0023_003DzAQKXeuJdfZIHAkje6A_003D_003D.Add(num);
			if (flag || flag2 || flag3 || flag4 || flag5 || flag6 || flag7 || flag8 || flag9 || flag10 || flag11 || flag12)
			{
				_0023_003DznYJLyL7e87gg3KoJaw_003D_003D.Add(num);
			}
		}
	}

	internal static void _0023_003Dz4dUuAkqMFHbDrGnHdg_003D_003D(double _0023_003DzeMBeuAQ_003D, double _0023_003DznYtQKck_003D, double _0023_003Dz5F7_i_0024U_003D, double _0023_003DzXmrDMdc_003D, _0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom[] _0023_003DzpPOEJqcAh7Lr, double[,] _0023_003DzFS_0024L8faKPib3, IList<int> _0023_003DzOUlmthl3JWuBjRHzkg_003D_003D, out List<int> _0023_003DzNLCpK1_05T8n)
	{
		_0023_003DzNLCpK1_05T8n = new List<int>(_0023_003DzOUlmthl3JWuBjRHzkg_003D_003D.Count);
		int count = _0023_003DzOUlmthl3JWuBjRHzkg_003D_003D.Count;
		for (int i = 0; i < count; i++)
		{
			int num = _0023_003DzOUlmthl3JWuBjRHzkg_003D_003D[i];
			if (!_0023_003DzDiiN7lIGF2cL6JLrTg_003D_003D(_0023_003DzeMBeuAQ_003D, _0023_003DznYtQKck_003D, _0023_003Dz5F7_i_0024U_003D, _0023_003DzXmrDMdc_003D, _0023_003DzFS_0024L8faKPib3, _0023_003DzpPOEJqcAh7Lr[num]._0023_003DzhMDfC7g_003D[0]))
			{
				_0023_003DzNLCpK1_05T8n.Add(num);
			}
		}
	}

	private static bool _0023_003DzDiiN7lIGF2cL6JLrTg_003D_003D(double _0023_003DzeMBeuAQ_003D, double _0023_003DznYtQKck_003D, double _0023_003Dz5F7_i_0024U_003D, double _0023_003DzXmrDMdc_003D, double[,] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int[] _0023_003DzdEvMFOw_003D)
	{
		int num = _0023_003DzdEvMFOw_003D.Length;
		int i;
		for (i = 0; i < num && !(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzdEvMFOw_003D[i], 0] > _0023_003DzeMBeuAQ_003D); i++)
		{
		}
		if (i == num)
		{
			return true;
		}
		for (i = 0; i < num && !(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzdEvMFOw_003D[i], 0] < _0023_003DznYtQKck_003D); i++)
		{
		}
		if (i == num)
		{
			return true;
		}
		for (i = 0; i < num && !(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzdEvMFOw_003D[i], 1] > _0023_003Dz5F7_i_0024U_003D); i++)
		{
		}
		if (i == num)
		{
			return true;
		}
		for (i = 0; i < num && !(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzdEvMFOw_003D[i], 1] < _0023_003DzXmrDMdc_003D); i++)
		{
		}
		if (i == num)
		{
			return true;
		}
		return false;
	}

	internal static List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>[] _0023_003DzPT2M26s8ljDY(IList<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D> _0023_003Dz8QArUk_JiSUK, int _0023_003DzLiDbFtubATq7, double _0023_003DzexDQbl7OdPPY, HiddenLinesViewSettings _0023_003DzlA0741irOW4x, double _0023_003DzxH4ozIo_003D)
	{
		int num;
		int num2;
		if (_0023_003DzLiDbFtubATq7 == 0)
		{
			num = 0;
			num2 = 3;
		}
		else
		{
			num = 1;
			num2 = 4;
		}
		List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>[] array = new List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>[2]
		{
			new List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>(),
			new List<_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D>()
		};
		Segment2D s = ((_0023_003DzLiDbFtubATq7 != 0) ? new Segment2D(_0023_003DzlA0741irOW4x.boxMin.X, _0023_003DzexDQbl7OdPPY, _0023_003DzlA0741irOW4x.boxMax.X, _0023_003DzexDQbl7OdPPY) : new Segment2D(_0023_003DzexDQbl7OdPPY, _0023_003DzlA0741irOW4x.boxMin.Y, _0023_003DzexDQbl7OdPPY, _0023_003DzlA0741irOW4x.boxMax.Y));
		for (int i = 0; i < _0023_003Dz8QArUk_JiSUK.Count; i++)
		{
			_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2 = _0023_003Dz8QArUk_JiSUK[i];
			double[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D = _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2._0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
			if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num] <= _0023_003DzexDQbl7OdPPY || _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num2] <= _0023_003DzexDQbl7OdPPY)
			{
				if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num] <= _0023_003DzexDQbl7OdPPY && _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num2] <= _0023_003DzexDQbl7OdPPY)
				{
					array[0].Add(_0023_003Dz8QArUk_JiSUK[i]);
					continue;
				}
				Segment2D segment2D = new Segment2D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4]);
				Point2D i2;
				Point2D i3;
				segmentIntersectionType segmentIntersectionType2 = Segment2D.Intersection(segment2D, s, out i2, out i3, _0023_003DzxH4ozIo_003D);
				if (segmentIntersectionType2 == segmentIntersectionType.Cross || segmentIntersectionType2 == segmentIntersectionType.Touch)
				{
					double[] _0023_003DzeEk0BGeXmyvR = new double[3];
					_0023_003DzrdGpTRhWPx_uI1Gk5hSv31nyx_hzPwtBTg_003D_003D._0023_003Dznql2Kp4kdMT3ZawnYKViM1w_003D(segment2D, i2, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, ref _0023_003DzeEk0BGeXmyvR);
					if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num] <= _0023_003DzeEk0BGeXmyvR[_0023_003DzLiDbFtubATq7] && _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num2] >= _0023_003DzeEk0BGeXmyvR[_0023_003DzLiDbFtubATq7])
					{
						array[0].Add(new _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D(_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2, new double[6]
						{
							_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0],
							_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1],
							_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[2],
							_0023_003DzeEk0BGeXmyvR[0],
							_0023_003DzeEk0BGeXmyvR[1],
							_0023_003DzeEk0BGeXmyvR[2]
						}));
						array[1].Add(new _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D(_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2, new double[6]
						{
							_0023_003DzeEk0BGeXmyvR[0],
							_0023_003DzeEk0BGeXmyvR[1],
							_0023_003DzeEk0BGeXmyvR[2],
							_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3],
							_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4],
							_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[5]
						}));
					}
					else
					{
						array[0].Add(new _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D(_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2, new double[6]
						{
							_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[3],
							_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[4],
							_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[5],
							_0023_003DzeEk0BGeXmyvR[0],
							_0023_003DzeEk0BGeXmyvR[1],
							_0023_003DzeEk0BGeXmyvR[2]
						}));
						array[1].Add(new _0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D(_0023_003Dz0GuWGiDwDkRkimwarXD_w6UpcMUBMvdFLMBn3us_003D2, new double[6]
						{
							_0023_003DzeEk0BGeXmyvR[0],
							_0023_003DzeEk0BGeXmyvR[1],
							_0023_003DzeEk0BGeXmyvR[2],
							_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0],
							_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[1],
							_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[2]
						}));
					}
				}
				else
				{
					array[1].Add(_0023_003Dz8QArUk_JiSUK[i]);
				}
			}
			else
			{
				array[1].Add(_0023_003Dz8QArUk_JiSUK[i]);
			}
		}
		return array;
	}

	private static double _0023_003DziSgdqm0iP1on(Point2D _0023_003DzDPcjoBJLcqli, Point2D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		double num = _0023_003Dz_0024N_0024yKptW9BoC.X - _0023_003DzDPcjoBJLcqli.X;
		double num2 = _0023_003Dz_0024N_0024yKptW9BoC.Y - _0023_003DzDPcjoBJLcqli.Y;
		return Math.Sqrt(num * num + num2 * num2);
	}

	private static void _0023_003DzcLScPK9UqQCBGPppfM8OSvQ_003D(RenderContextBase _0023_003DzQdnFby4_003D, projectionType _0023_003Dzbl24fQDH5pP9, double[] _0023_003DzypMGqyMVO5qA, int[] _0023_003DzqDFBISpCePlj, _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DztAfqF4hBU7RX, ref int[,] _0023_003DzDn3gsQfBhRkJ, Transformation _0023_003Dznke9mSLeC1ccmnopWxUuQJY_003D, bool _0023_003DzZgSQ1WpOFIne)
	{
		if (_0023_003DztAfqF4hBU7RX.Vertices != null)
		{
			if (_0023_003DzDn3gsQfBhRkJ == null)
			{
				_0023_003DzDn3gsQfBhRkJ = Utility._0023_003Dz36sbfVCTXh1L(_0023_003DztAfqF4hBU7RX._0023_003DzZSnvfVF8Y5Qg, _0023_003DztAfqF4hBU7RX.Vertices.GetLength(0), out var _, _0023_003DzZgSQ1WpOFIne);
			}
			if (_0023_003DztAfqF4hBU7RX.VertexArrayData == null)
			{
				_0023_003DztAfqF4hBU7RX.VertexArrayData = new SilhoVertexArrayData();
				_0023_003DztAfqF4hBU7RX.ScreenVertices = new double[_0023_003DztAfqF4hBU7RX.Vertices.GetLength(0), 3];
			}
			int length = _0023_003DztAfqF4hBU7RX.Vertices.GetLength(0);
			if (_0023_003Dznke9mSLeC1ccmnopWxUuQJY_003D != null)
			{
				_0023_003DzypMGqyMVO5qA = Utility.MultMatrixd(_0023_003Dznke9mSLeC1ccmnopWxUuQJY_003D.MatrixAsVectorByColumn, _0023_003DzypMGqyMVO5qA);
			}
			for (int i = 0; i < length; i++)
			{
				GfxSilhoData.ComputeScreenCoords(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, _0023_003DztAfqF4hBU7RX.Vertices[i, 0], _0023_003DztAfqF4hBU7RX.Vertices[i, 1], _0023_003DztAfqF4hBU7RX.Vertices[i, 2], out _0023_003DztAfqF4hBU7RX.ScreenVertices[i, 0], out _0023_003DztAfqF4hBU7RX.ScreenVertices[i, 1], out _0023_003DztAfqF4hBU7RX.ScreenVertices[i, 2]);
			}
			_0023_003DzaRP0AlnwKqZMf9x9hKjDxXGotsaKhlmyLg_003D_003D(_0023_003Dzbl24fQDH5pP9, _0023_003DztAfqF4hBU7RX, _0023_003DzDn3gsQfBhRkJ);
		}
	}

	private static void _0023_003DzaRP0AlnwKqZMf9x9hKjDxXGotsaKhlmyLg_003D_003D(projectionType _0023_003Dzbl24fQDH5pP9, _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DztAfqF4hBU7RX, int[,] _0023_003DzDn3gsQfBhRkJ)
	{
		_0023_003DztAfqF4hBU7RX.VertexArrayData.indices = new int[_0023_003DzDn3gsQfBhRkJ.GetLength(0), 2];
		bool[] array = new bool[_0023_003DztAfqF4hBU7RX._0023_003DzZSnvfVF8Y5Qg.GetLength(0)];
		bool[] array2 = null;
		int num = _0023_003DztAfqF4hBU7RX._0023_003DzZSnvfVF8Y5Qg.Length;
		if (_0023_003Dzbl24fQDH5pP9 == projectionType.Perspective)
		{
			array2 = new bool[_0023_003DztAfqF4hBU7RX._0023_003DzZSnvfVF8Y5Qg.Length];
			for (int i = 0; i < num; i++)
			{
				int _0023_003DzQW_0024hBdI_003D = _0023_003DztAfqF4hBU7RX._0023_003DzZSnvfVF8Y5Qg[i]._0023_003DzQW_0024hBdI_003D;
				int _0023_003DzCmn_5Z0_003D = _0023_003DztAfqF4hBU7RX._0023_003DzZSnvfVF8Y5Qg[i]._0023_003DzCmn_5Z0_003D;
				int _0023_003DzqePf_00244c_003D = _0023_003DztAfqF4hBU7RX._0023_003DzZSnvfVF8Y5Qg[i]._0023_003DzqePf_00244c_003D;
				double num2 = _0023_003DztAfqF4hBU7RX.ScreenVertices[_0023_003DzQW_0024hBdI_003D, 2];
				double num3 = _0023_003DztAfqF4hBU7RX.ScreenVertices[_0023_003DzCmn_5Z0_003D, 2];
				double num4 = _0023_003DztAfqF4hBU7RX.ScreenVertices[_0023_003DzqePf_00244c_003D, 2];
				if (num2 < 0.0 || num2 > 1.0 || num3 < 0.0 || num3 > 1.0 || num4 < 0.0 || num4 > 1.0)
				{
					array2[i] = true;
				}
				else
				{
					array[i] = _0023_003DzhDa5OvbQw8gi(_0023_003DztAfqF4hBU7RX.ScreenVertices[_0023_003DzQW_0024hBdI_003D, 0], _0023_003DztAfqF4hBU7RX.ScreenVertices[_0023_003DzQW_0024hBdI_003D, 1], _0023_003DztAfqF4hBU7RX.ScreenVertices[_0023_003DzCmn_5Z0_003D, 0], _0023_003DztAfqF4hBU7RX.ScreenVertices[_0023_003DzCmn_5Z0_003D, 1], _0023_003DztAfqF4hBU7RX.ScreenVertices[_0023_003DzqePf_00244c_003D, 0], _0023_003DztAfqF4hBU7RX.ScreenVertices[_0023_003DzqePf_00244c_003D, 1]);
				}
			}
		}
		else
		{
			for (int j = 0; j < num; j++)
			{
				int _0023_003DzQW_0024hBdI_003D2 = _0023_003DztAfqF4hBU7RX._0023_003DzZSnvfVF8Y5Qg[j]._0023_003DzQW_0024hBdI_003D;
				int _0023_003DzCmn_5Z0_003D2 = _0023_003DztAfqF4hBU7RX._0023_003DzZSnvfVF8Y5Qg[j]._0023_003DzCmn_5Z0_003D;
				int _0023_003DzqePf_00244c_003D2 = _0023_003DztAfqF4hBU7RX._0023_003DzZSnvfVF8Y5Qg[j]._0023_003DzqePf_00244c_003D;
				array[j] = _0023_003DzhDa5OvbQw8gi(_0023_003DztAfqF4hBU7RX.ScreenVertices[_0023_003DzQW_0024hBdI_003D2, 0], _0023_003DztAfqF4hBU7RX.ScreenVertices[_0023_003DzQW_0024hBdI_003D2, 1], _0023_003DztAfqF4hBU7RX.ScreenVertices[_0023_003DzCmn_5Z0_003D2, 0], _0023_003DztAfqF4hBU7RX.ScreenVertices[_0023_003DzCmn_5Z0_003D2, 1], _0023_003DztAfqF4hBU7RX.ScreenVertices[_0023_003DzqePf_00244c_003D2, 0], _0023_003DztAfqF4hBU7RX.ScreenVertices[_0023_003DzqePf_00244c_003D2, 1]);
			}
		}
		_0023_003DztAfqF4hBU7RX.VertexArrayData.indicesCount = 0;
		num = _0023_003DzDn3gsQfBhRkJ.GetLength(0);
		if (_0023_003Dzbl24fQDH5pP9 == projectionType.Perspective)
		{
			for (int k = 0; k < num; k++)
			{
				int num5 = _0023_003DzDn3gsQfBhRkJ[k, 0];
				int num6 = _0023_003DzDn3gsQfBhRkJ[k, 1];
				int num7 = _0023_003DzDn3gsQfBhRkJ[k, 2];
				int num8 = _0023_003DzDn3gsQfBhRkJ[k, 3];
				if (num8 == -1)
				{
					if (!array2[num7])
					{
						_0023_003DztAfqF4hBU7RX.VertexArrayData.indices[_0023_003DztAfqF4hBU7RX.VertexArrayData.indicesCount, 0] = num5;
						_0023_003DztAfqF4hBU7RX.VertexArrayData.indices[_0023_003DztAfqF4hBU7RX.VertexArrayData.indicesCount, 1] = num6;
						_0023_003DztAfqF4hBU7RX.VertexArrayData.indicesCount++;
					}
				}
				else if (!array2[num7] && !array2[num8] && (array[num7] ^ array[num8]))
				{
					_0023_003DztAfqF4hBU7RX.VertexArrayData.indices[_0023_003DztAfqF4hBU7RX.VertexArrayData.indicesCount, 0] = num5;
					_0023_003DztAfqF4hBU7RX.VertexArrayData.indices[_0023_003DztAfqF4hBU7RX.VertexArrayData.indicesCount, 1] = num6;
					_0023_003DztAfqF4hBU7RX.VertexArrayData.indicesCount++;
				}
			}
			return;
		}
		for (int l = 0; l < num; l++)
		{
			int num9 = _0023_003DzDn3gsQfBhRkJ[l, 0];
			int num10 = _0023_003DzDn3gsQfBhRkJ[l, 1];
			int num11 = _0023_003DzDn3gsQfBhRkJ[l, 2];
			int num12 = _0023_003DzDn3gsQfBhRkJ[l, 3];
			if (num12 == -1)
			{
				_0023_003DztAfqF4hBU7RX.VertexArrayData.indices[_0023_003DztAfqF4hBU7RX.VertexArrayData.indicesCount, 0] = num9;
				_0023_003DztAfqF4hBU7RX.VertexArrayData.indices[_0023_003DztAfqF4hBU7RX.VertexArrayData.indicesCount, 1] = num10;
				_0023_003DztAfqF4hBU7RX.VertexArrayData.indicesCount++;
			}
			else if (array[num11] ^ array[num12])
			{
				_0023_003DztAfqF4hBU7RX.VertexArrayData.indices[_0023_003DztAfqF4hBU7RX.VertexArrayData.indicesCount, 0] = num9;
				_0023_003DztAfqF4hBU7RX.VertexArrayData.indices[_0023_003DztAfqF4hBU7RX.VertexArrayData.indicesCount, 1] = num10;
				_0023_003DztAfqF4hBU7RX.VertexArrayData.indicesCount++;
			}
		}
	}

	internal static void PreProcessSilhouettesForDraw(IList<Entity> _0023_003DzWc9WmS8VMsuA, PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		foreach (Entity item in _0023_003DzWc9WmS8VMsuA)
		{
			item.silhoData = item._0023_003DzOQ9MbnSofHiL_xtPyyGkf6ozeVZJ(_0023_003DzELu0Pss_003D);
		}
	}

	private IList<SilhoWireData> _0023_003Dz_0024AYrdXI3HY9d<T>(PreProcessSilhouettesParams _0023_003DzELu0Pss_003D) where T : GfxAttributesWire
	{
		GfxAttributesWire gfxAttributesWire = (GfxAttributesWire)_0023_003DzELu0Pss_003D.Attributes.Clone();
		List<SilhoWireData> list = new List<SilhoWireData>();
		int count = _0023_003DzELu0Pss_003D.Entities.Count;
		for (int i = 0; i < count; i++)
		{
			Entity entity = _0023_003DzELu0Pss_003D.Entities[i];
			Tuple<Stack<BlockReference>, Entity> _0023_003DzmdyIrQQUDpKM = new Tuple<Stack<BlockReference>, Entity>(_0023_003DzELu0Pss_003D.Parents, entity);
			if (_0023_003DzELu0Pss_003D.EntitiesToHide != null && Utility._0023_003Dzv9BlzJBJ8Je9MrLd9w_003D_003D(_0023_003DzmdyIrQQUDpKM, _0023_003DzELu0Pss_003D.EntitiesToHide))
			{
				continue;
			}
			BlockReference blockReference = entity as BlockReference;
			bool flag = entity is Text || entity is Table;
			if ((flag && !_0023_003DzELu0Pss_003D.CollectTextsOnly) || (!flag && blockReference == null && _0023_003DzELu0Pss_003D.CollectTextsOnly) || !entity.IsVisible(_0023_003DzELu0Pss_003D.Parents, _0023_003DzELu0Pss_003D.Layers, _0023_003DzELu0Pss_003D.AttributeReferenceVisibilityMode) || (_0023_003DzuvkktNA2OHo_vIbJ7Q_003D_003D && !entity.IsInFrustum(_0023_003DzELu0Pss_003D.FrustumParams)))
			{
				continue;
			}
			_0023_003DzELu0Pss_003D.Attributes = (GfxAttributesWire)gfxAttributesWire.Clone();
			_0023_003DzELu0Pss_003D.Attributes.Propagate(entity, _0023_003DzELu0Pss_003D.Layers[entity.LayerName], _0023_003DzELu0Pss_003D.Materials);
			if (HdlViewSettings.TreatWhiteAsBlack && _0023_003DzELu0Pss_003D.Attributes.GetColor().ToArgb() == _0023_003DzLE3fZGtyB_0024v8)
			{
				_0023_003DzELu0Pss_003D.Attributes.Color = Color.Black;
			}
			if (blockReference != null)
			{
				bool flag2 = _0023_003DzQpZSox1CJlNK;
				_0023_003DzQpZSox1CJlNK = true;
				IList<Entity> entities = _0023_003DzELu0Pss_003D.Entities;
				_0023_003DzELu0Pss_003D.Entities = blockReference.GetEntities(_0023_003DzELu0Pss_003D.Blocks);
				_0023_003DzELu0Pss_003D.FrustumParams.PushTransformation(blockReference);
				_0023_003DzELu0Pss_003D.Parents.Push(blockReference);
				if (blockReference is View view)
				{
					_0023_003DzELu0Pss_003D.ViewScale = (float)view.Scale;
				}
				IList<SilhoWireData> list2 = _0023_003Dz_0024AYrdXI3HY9d<T>(_0023_003DzELu0Pss_003D);
				_0023_003DzELu0Pss_003D.Entities = entities;
				_0023_003DzELu0Pss_003D.FrustumParams.PopTransformation();
				_0023_003DzELu0Pss_003D.Parents.Pop();
				_0023_003DzELu0Pss_003D.ViewScale = 1f;
				_0023_003DzQpZSox1CJlNK = flag2;
				if (list2 == null)
				{
					continue;
				}
				foreach (SilhoWireData item in list2)
				{
					list.Add(item);
				}
				continue;
			}
			SilhoWireData silhoWireData = null;
			List<SilhoWireData> _0023_003Dz_00245kcECVgngOLQYbjzQ_003D_003D = new List<SilhoWireData>();
			if (_0023_003DzQpZSox1CJlNK && entity is devDept.Eyeshot.Entities.Attribute && !(_0023_003DzELu0Pss_003D.Parents.Peek() is ParentBlockReference))
			{
				continue;
			}
			if (entity.entityNature == entityNatureType.Wire || (entity is Mesh && _0023_003DzV7icIEk_003D(_0023_003DzELu0Pss_003D.Parents)) || entity is Picture || (entity is devDept.Eyeshot.Entities.Region && _0023_003DzELu0Pss_003D.FillRegions) || (entity is Hatch && _0023_003DzELu0Pss_003D.FillRegions) || (entity is FastPointCloud && _0023_003DzV7icIEk_003D(_0023_003DzELu0Pss_003D.Parents)) || entity is devDept.Eyeshot.Entities.Point)
			{
				silhoWireData = _0023_003Dz_GyOHL_0024i8xyp(entity, _0023_003DzELu0Pss_003D, ref _0023_003Dz_00245kcECVgngOLQYbjzQ_003D_003D);
				if (_0023_003Dz_00245kcECVgngOLQYbjzQ_003D_003D.Count > 0)
				{
					foreach (SilhoWireData item2 in _0023_003Dz_00245kcECVgngOLQYbjzQ_003D_003D)
					{
						_0023_003Dz79xh1HQY_0024Z_0024L(_0023_003DzELu0Pss_003D.FrustumParams.Transformation, _0023_003DzELu0Pss_003D.Attributes, item2, list);
					}
				}
			}
			else
			{
				bool flag3 = false;
				if (entity.silhoData == null || entity is Surface || entity is Brep)
				{
					silhoWireData = entity._0023_003DzEt1XHB_xc_BLLBoMbJmskWU_003D(_0023_003DzELu0Pss_003D);
					if (silhoWireData == null)
					{
						AppendToLog(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986702), entity.GetType()));
						continue;
					}
				}
				else
				{
					silhoWireData = new _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D((_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D)entity.silhoData)
					{
						Parents = ((_0023_003DzELu0Pss_003D.Parents == null) ? null : Utility.CloneStack(_0023_003DzELu0Pss_003D.Parents))
					};
					flag3 = true;
				}
				if (_0023_003DzELu0Pss_003D.FrustumParams.Transformation != null && _0023_003DzELu0Pss_003D.FrustumParams.Transformation.HasReflection)
				{
					_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2 = (_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D)silhoWireData;
					if (flag3)
					{
						_0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom[] array = new _0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom[_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzZSnvfVF8Y5Qg.Length];
						for (int j = 0; j < _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzZSnvfVF8Y5Qg.Length; j++)
						{
							array[j] = _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzZSnvfVF8Y5Qg[j]._0023_003Dzx9P_oXY_003D();
						}
						_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzZSnvfVF8Y5Qg = array;
					}
					for (int k = 0; k < _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzZSnvfVF8Y5Qg.Length; k++)
					{
						_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2._0023_003DzZSnvfVF8Y5Qg[k]._0023_003Dz0wcqTpk_003D();
					}
				}
			}
			printOrderValues.Add(entity.PrintOrder);
			_0023_003Dz79xh1HQY_0024Z_0024L(_0023_003DzELu0Pss_003D.FrustumParams.Transformation, _0023_003DzELu0Pss_003D.Attributes, silhoWireData, list);
		}
		return list;
	}

	private static void _0023_003Dz79xh1HQY_0024Z_0024L(Transformation _0023_003Dznke9mSLeC1ccmnopWxUuQJY_003D, GfxAttributesWire _0023_003DzqP5lTto_003D, SilhoWireData _0023_003Dz8izZmgY8WKfw_PTzzg_003D_003D, List<SilhoWireData> _0023_003DztAfqF4hBU7RX)
	{
		if (_0023_003Dz8izZmgY8WKfw_PTzzg_003D_003D != null)
		{
			if (_0023_003Dznke9mSLeC1ccmnopWxUuQJY_003D != null && !_0023_003Dznke9mSLeC1ccmnopWxUuQJY_003D.IsIdentity())
			{
				_0023_003Dz8izZmgY8WKfw_PTzzg_003D_003D.Transformation = _0023_003Dznke9mSLeC1ccmnopWxUuQJY_003D;
			}
			_0023_003Dz8izZmgY8WKfw_PTzzg_003D_003D.Attributes = _0023_003DzqP5lTto_003D;
			_0023_003DztAfqF4hBU7RX.Add(_0023_003Dz8izZmgY8WKfw_PTzzg_003D_003D);
		}
	}

	private SilhoWireData _0023_003Dz_GyOHL_0024i8xyp(Entity _0023_003Dzs_0024uS8LA_003D, PreProcessSilhouettesParams _0023_003DzELu0Pss_003D, ref List<SilhoWireData> _0023_003Dz_00245kcECVgngOLQYbjzQ_003D_003D)
	{
		Point3D[] array = null;
		List<Point3D[]> list = new List<Point3D[]>();
		SilhoWireData silhoWireData;
		if (_0023_003Dzs_0024uS8LA_003D is Dimension)
		{
			_0023_003DzxZKIPuMrajUpCgX1XWJEJ4nigv7cOU9tuw_003D_003D _0023_003DzxZKIPuMrajUpCgX1XWJEJ4nigv7cOU9tuw_003D_003D2 = new _0023_003DzxZKIPuMrajUpCgX1XWJEJ4nigv7cOU9tuw_003D_003D(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents, _0023_003DzpaBsULpDiecO: false);
			silhoWireData = _0023_003DzxZKIPuMrajUpCgX1XWJEJ4nigv7cOU9tuw_003D_003D2;
			Dimension dimension = (Dimension)_0023_003Dzs_0024uS8LA_003D;
			_0023_003DzxZKIPuMrajUpCgX1XWJEJ4nigv7cOU9tuw_003D_003D2._0023_003DzcEFLt3aiIQTq = _0023_003Dzj0IBnUt8SGHt(dimension, _0023_003DzELu0Pss_003D);
			Point3D[] _0023_003DzyIUKu5w_003D = null;
			Point3D[][] _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D = null;
			if (_0023_003DzELu0Pss_003D.FillTexts)
			{
				dimension.GetLines(_0023_003DzELu0Pss_003D.FontTolerance, _0023_003DzELu0Pss_003D.Document.workspace, _0023_003DzzGo2_Wb1L5us: true, out _0023_003DzyIUKu5w_003D, out _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D);
				List<Point3D> list2 = new List<Point3D>(_0023_003DzyIUKu5w_003D);
				if (_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D != null && _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D.GetLength(0) > 0)
				{
					list2.AddRange(_0023_003DzHWHGDy9x7KlK(_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D));
				}
				array = list2.ToArray();
				if (_0023_003DzxZKIPuMrajUpCgX1XWJEJ4nigv7cOU9tuw_003D_003D2._0023_003DzcEFLt3aiIQTq)
				{
					_0023_003DzG29BuGPAjYqU(dimension.GetTextRectangleVertices(), out var _0023_003DzTbDlaOM_003D, 0.0);
					((_0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D)silhoWireData)._0023_003DzfpLdUTfgyzIHbARQCQ_003D_003D = _0023_003DzTbDlaOM_003D;
				}
				_0023_003Dz_00245kcECVgngOLQYbjzQ_003D_003D.Add(new _0023_003DzxZKIPuMrajUpCgX1XWJEJ4nigv7cOU9tuw_003D_003D(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents, _0023_003DzpaBsULpDiecO: true));
				list.Add(_0023_003DzTq8rUu2Kj6vPGUyNS62aE7s_003D(dimension.GetTriangles(_0023_003DzELu0Pss_003D.FontTolerance, _0023_003DzxZKIPuMrajUpCgX1XWJEJ4nigv7cOU9tuw_003D_003D2._0023_003DzcEFLt3aiIQTq ? null : _0023_003DzELu0Pss_003D.Document.workspace)).ToArray());
			}
			else
			{
				dimension.GetLines(_0023_003DzELu0Pss_003D.FontTolerance, _0023_003DzELu0Pss_003D.Document.workspace, _0023_003DzzGo2_Wb1L5us: false, out _0023_003DzyIUKu5w_003D, out _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D);
				List<Point3D> list3 = new List<Point3D>(_0023_003DzyIUKu5w_003D);
				list3.AddRange(_0023_003DzHWHGDy9x7KlK(_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D));
				array = list3.ToArray();
			}
		}
		else if (_0023_003Dzs_0024uS8LA_003D is SectionLine)
		{
			_0023_003DzIQ6IsFp_0024iJJ19yulg_0024WUv3D0Xtz94KiZyQ_003D_003D _0023_003DzIQ6IsFp_0024iJJ19yulg_0024WUv3D0Xtz94KiZyQ_003D_003D2 = new _0023_003DzIQ6IsFp_0024iJJ19yulg_0024WUv3D0Xtz94KiZyQ_003D_003D(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents, _0023_003DzpaBsULpDiecO: false);
			silhoWireData = _0023_003DzIQ6IsFp_0024iJJ19yulg_0024WUv3D0Xtz94KiZyQ_003D_003D2;
			SectionLine sectionLine = (SectionLine)_0023_003Dzs_0024uS8LA_003D;
			_0023_003DzIQ6IsFp_0024iJJ19yulg_0024WUv3D0Xtz94KiZyQ_003D_003D2._0023_003DzcEFLt3aiIQTq = _0023_003Dzj0IBnUt8SGHt(sectionLine, _0023_003DzELu0Pss_003D);
			Point3D[] _0023_003DzyIUKu5w_003D2 = null;
			Point3D[][] _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D2 = null;
			if (_0023_003DzELu0Pss_003D.FillTexts)
			{
				sectionLine._0023_003DzAqQbug4_003D(_0023_003DzELu0Pss_003D.FontTolerance, _0023_003DzELu0Pss_003D.Document.workspace, _0023_003DzzGo2_Wb1L5us: true, out _0023_003DzyIUKu5w_003D2, out _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D2);
				List<Point3D> list4 = new List<Point3D>(_0023_003DzyIUKu5w_003D2);
				if (_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D2 != null && _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D2.GetLength(0) > 0)
				{
					list4.AddRange(_0023_003DzHWHGDy9x7KlK(_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D2));
				}
				array = list4.ToArray();
				if (_0023_003DzIQ6IsFp_0024iJJ19yulg_0024WUv3D0Xtz94KiZyQ_003D_003D2._0023_003DzcEFLt3aiIQTq)
				{
					_0023_003DzG29BuGPAjYqU(sectionLine.GetTextRectangleVertices(), out var _0023_003DzTbDlaOM_003D2, 0.0);
					((_0023_003DzIQ6IsFp_0024iJJ19yulg_0024WUv3D0Xtz94KiZyQ_003D_003D)silhoWireData)._0023_003DzfpLdUTfgyzIHbARQCQ_003D_003D = _0023_003DzTbDlaOM_003D2;
				}
				_0023_003Dz_00245kcECVgngOLQYbjzQ_003D_003D.Add(new _0023_003DzIQ6IsFp_0024iJJ19yulg_0024WUv3D0Xtz94KiZyQ_003D_003D(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents, _0023_003DzpaBsULpDiecO: true));
				list.Add(_0023_003DzTq8rUu2Kj6vPGUyNS62aE7s_003D(sectionLine.GetTriangles(_0023_003DzELu0Pss_003D.FontTolerance, _0023_003DzIQ6IsFp_0024iJJ19yulg_0024WUv3D0Xtz94KiZyQ_003D_003D2._0023_003DzcEFLt3aiIQTq ? null : _0023_003DzELu0Pss_003D.Document.workspace)).ToArray());
			}
			else
			{
				sectionLine._0023_003DzAqQbug4_003D(_0023_003DzELu0Pss_003D.FontTolerance, _0023_003DzELu0Pss_003D.Document.workspace, _0023_003DzzGo2_Wb1L5us: false, out _0023_003DzyIUKu5w_003D2, out _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D2);
				List<Point3D> list5 = new List<Point3D>(_0023_003DzyIUKu5w_003D2);
				list5.AddRange(_0023_003DzHWHGDy9x7KlK(_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D2));
				array = list5.ToArray();
			}
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Balloon)
		{
			_0023_003Dzc3V7MP_0024aQgRTn8DOJWjJO6Euhm0bbhYZGxnbM4c_003D _0023_003Dzc3V7MP_0024aQgRTn8DOJWjJO6Euhm0bbhYZGxnbM4c_003D2 = new _0023_003Dzc3V7MP_0024aQgRTn8DOJWjJO6Euhm0bbhYZGxnbM4c_003D(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents, _0023_003DzpaBsULpDiecO: false);
			silhoWireData = _0023_003Dzc3V7MP_0024aQgRTn8DOJWjJO6Euhm0bbhYZGxnbM4c_003D2;
			Balloon balloon = (Balloon)_0023_003Dzs_0024uS8LA_003D;
			_0023_003Dzc3V7MP_0024aQgRTn8DOJWjJO6Euhm0bbhYZGxnbM4c_003D2._0023_003DzcEFLt3aiIQTq = _0023_003Dzj0IBnUt8SGHt(balloon, _0023_003DzELu0Pss_003D);
			Point3D[] _0023_003DzyIUKu5w_003D3 = null;
			Point3D[][] _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D3 = null;
			if (_0023_003DzELu0Pss_003D.FillTexts)
			{
				balloon._0023_003DzAqQbug4_003D(_0023_003DzELu0Pss_003D.FontTolerance, _0023_003DzELu0Pss_003D.Document.workspace, _0023_003DzzGo2_Wb1L5us: true, out _0023_003DzyIUKu5w_003D3, out _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D3);
				List<Point3D> list6 = new List<Point3D>(_0023_003DzyIUKu5w_003D3);
				if (_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D3 != null && _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D3.GetLength(0) > 0)
				{
					list6.AddRange(_0023_003DzHWHGDy9x7KlK(_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D3));
				}
				array = list6.ToArray();
				if (_0023_003Dzc3V7MP_0024aQgRTn8DOJWjJO6Euhm0bbhYZGxnbM4c_003D2._0023_003DzcEFLt3aiIQTq)
				{
					_0023_003DzG29BuGPAjYqU(balloon.GetTextRectangleVertices(), out var _0023_003DzTbDlaOM_003D3, 0.0);
					((_0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D)silhoWireData)._0023_003DzfpLdUTfgyzIHbARQCQ_003D_003D = _0023_003DzTbDlaOM_003D3;
				}
				_0023_003Dz_00245kcECVgngOLQYbjzQ_003D_003D.Add(new _0023_003Dzc3V7MP_0024aQgRTn8DOJWjJO6Euhm0bbhYZGxnbM4c_003D(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents, _0023_003DzpaBsULpDiecO: true));
				list.Add(_0023_003DzTq8rUu2Kj6vPGUyNS62aE7s_003D(balloon._0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(_0023_003DzELu0Pss_003D.FontTolerance, _0023_003Dzc3V7MP_0024aQgRTn8DOJWjJO6Euhm0bbhYZGxnbM4c_003D2._0023_003DzcEFLt3aiIQTq ? null : _0023_003DzELu0Pss_003D.Document.workspace)).ToArray());
			}
			else
			{
				balloon._0023_003DzAqQbug4_003D(_0023_003DzELu0Pss_003D.FontTolerance, _0023_003DzELu0Pss_003D.Document.workspace, _0023_003DzzGo2_Wb1L5us: false, out _0023_003DzyIUKu5w_003D3, out _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D3);
				List<Point3D> list7 = new List<Point3D>(_0023_003DzyIUKu5w_003D3);
				list7.AddRange(_0023_003DzHWHGDy9x7KlK(_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D3));
				array = list7.ToArray();
			}
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Table)
		{
			silhoWireData = new _0023_003DzjXpXfbVskVETBhLLjip4uz4gjzrham7Lhw_003D_003D(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents, _0023_003DzpaBsULpDiecO: false);
			Table table = (Table)_0023_003Dzs_0024uS8LA_003D;
			_0023_003DzjXpXfbVskVETBhLLjip4uz4gjzrham7Lhw_003D_003D _0023_003DzjXpXfbVskVETBhLLjip4uz4gjzrham7Lhw_003D_003D2 = (_0023_003DzjXpXfbVskVETBhLLjip4uz4gjzrham7Lhw_003D_003D)silhoWireData;
			_0023_003DzjXpXfbVskVETBhLLjip4uz4gjzrham7Lhw_003D_003D2._0023_003Dzj0IBnUt8SGHt = _0023_003Dzj0IBnUt8SGHt(table.cells[0, 0], _0023_003DzELu0Pss_003D);
			Point3D[] _0023_003DzyIUKu5w_003D4 = null;
			Point3D[][] _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D4 = null;
			if (_0023_003DzELu0Pss_003D.FillTexts)
			{
				table._0023_003DzAqQbug4_003D(_0023_003DzELu0Pss_003D.FontTolerance, _0023_003DzELu0Pss_003D.Document.workspace, _0023_003DzzGo2_Wb1L5us: true, out _0023_003DzyIUKu5w_003D4, out _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D4);
				List<Point3D> list8 = new List<Point3D>(_0023_003DzyIUKu5w_003D4);
				if (_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D4 != null && _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D4.GetLength(0) > 0)
				{
					list8.AddRange(_0023_003DzHWHGDy9x7KlK(_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D4));
				}
				array = list8.ToArray();
				if (_0023_003DzjXpXfbVskVETBhLLjip4uz4gjzrham7Lhw_003D_003D2._0023_003Dzj0IBnUt8SGHt)
				{
					Table.Cell[] _0023_003DzvWtAEHE_003D;
					Point3D[][] array2 = table._0023_003DzvRwWWBffvmm7RAsSMMIldug_003D(out _0023_003DzvWtAEHE_003D);
					_0023_003DzjXpXfbVskVETBhLLjip4uz4gjzrham7Lhw_003D_003D2._0023_003DzZN8bmTIkunKijK_00240UA_003D_003D = new _0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D[_0023_003DzvWtAEHE_003D.Length];
					for (int i = 0; i < array2.GetLength(0); i++)
					{
						_0023_003DzG29BuGPAjYqU(array2[i], out var _0023_003DzTbDlaOM_003D4, 0.0);
						_0023_003Dz_00245kcECVgngOLQYbjzQ_003D_003D.Add(new _0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D(_0023_003DzvWtAEHE_003D[i], _0023_003DzELu0Pss_003D.Parents, _0023_003DzELu0Pss_003D.FillTexts)
						{
							_0023_003DzcEFLt3aiIQTq = _0023_003DzjXpXfbVskVETBhLLjip4uz4gjzrham7Lhw_003D_003D2._0023_003Dzj0IBnUt8SGHt,
							DataMode = silhoDataType.LineStrip,
							Attributes = _0023_003DzELu0Pss_003D.Attributes,
							Vertices = _0023_003DzTbDlaOM_003D4,
							_0023_003DzfpLdUTfgyzIHbARQCQ_003D_003D = _0023_003DzTbDlaOM_003D4
						});
					}
				}
				else
				{
					_0023_003Dz_00245kcECVgngOLQYbjzQ_003D_003D.Add(new _0023_003DzjXpXfbVskVETBhLLjip4uz4gjzrham7Lhw_003D_003D(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents, _0023_003DzpaBsULpDiecO: true));
					list.Add(_0023_003DzTq8rUu2Kj6vPGUyNS62aE7s_003D(table._0023_003Dz37SpqHylDgPQodlpFQ_003D_003D(_0023_003DzELu0Pss_003D.FontTolerance, _0023_003DzELu0Pss_003D.Document.workspace)).ToArray());
				}
			}
			else
			{
				table._0023_003DzAqQbug4_003D(_0023_003DzELu0Pss_003D.FontTolerance, _0023_003DzELu0Pss_003D.Document.workspace, _0023_003DzzGo2_Wb1L5us: false, out _0023_003DzyIUKu5w_003D4, out _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D4);
				List<Point3D> list9 = new List<Point3D>(_0023_003DzyIUKu5w_003D4);
				list9.AddRange(_0023_003DzHWHGDy9x7KlK(_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D4));
				array = list9.ToArray();
			}
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Text)
		{
			Text text = (Text)_0023_003Dzs_0024uS8LA_003D;
			if (string.IsNullOrEmpty(text.text))
			{
				_0023_003Dz_00245kcECVgngOLQYbjzQ_003D_003D.Clear();
				return null;
			}
			_0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D _0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D2 = new _0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents, _0023_003DzELu0Pss_003D.FillTexts);
			_0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D2._0023_003DzcEFLt3aiIQTq = _0023_003Dzj0IBnUt8SGHt(text, _0023_003DzELu0Pss_003D);
			silhoWireData = _0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D2;
			if (_0023_003DzELu0Pss_003D.FillTexts)
			{
				if (_0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D2._0023_003DzcEFLt3aiIQTq)
				{
					_0023_003DzG29BuGPAjYqU(text.GetTextRectangleVertices(), out var _0023_003DzTbDlaOM_003D5, 0.0);
					_0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D2._0023_003DzfpLdUTfgyzIHbARQCQ_003D_003D = _0023_003DzTbDlaOM_003D5;
					array = text.Vertices;
					_0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D2.DataMode = silhoDataType.LineStrip;
				}
				else
				{
					array = _0023_003DzTq8rUu2Kj6vPGUyNS62aE7s_003D(text.GetTriangles(_0023_003DzELu0Pss_003D.FontTolerance, _0023_003DzELu0Pss_003D.Document.workspace)).ToArray();
				}
			}
			if (array == null || array.Length == 0)
			{
				Point3D[][] outlines = text.GetOutlines(_0023_003DzELu0Pss_003D.FontTolerance, _0023_003DzELu0Pss_003D.Document.workspace);
				if (_0023_003DzELu0Pss_003D.Document.TextStyles[text.StyleName].IsSHX())
				{
					_0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D2.DataMode = silhoDataType.LineList;
				}
				array = _0023_003DzHWHGDy9x7KlK(outlines).ToArray();
			}
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Leader)
		{
			silhoWireData = new SilhoWireData(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents);
			Leader leader = (Leader)_0023_003Dzs_0024uS8LA_003D;
			array = leader._0023_003DzAqQbug4_003D(_0023_003DzELu0Pss_003D.FillTexts);
			if (_0023_003DzELu0Pss_003D.FillTexts)
			{
				_0023_003Dz_00245kcECVgngOLQYbjzQ_003D_003D.Add(new _0023_003DzxZKIPuMrajUpCgX1XWJEJ4nigv7cOU9tuw_003D_003D(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents, _0023_003DzpaBsULpDiecO: true));
				list.Add(_0023_003DzTq8rUu2Kj6vPGUyNS62aE7s_003D(leader._0023_003Dz37SpqHylDgPQodlpFQ_003D_003D()).ToArray());
			}
		}
		else if (_0023_003Dzs_0024uS8LA_003D is devDept.Eyeshot.Entities.Point)
		{
			silhoWireData = new SilhoWireData(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents);
			silhoWireData.startPointVertices = 0;
			array = new Point3D[1] { _0023_003Dzs_0024uS8LA_003D.Vertices[0] };
		}
		else if (_0023_003Dzs_0024uS8LA_003D is devDept.Eyeshot.Entities.Region region && _0023_003DzELu0Pss_003D.FillRegions)
		{
			silhoWireData = new _0023_003Dzf1HxNbhqBUCjNYwMcQ2TfF4FueDkoyri1w_003D_003D(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents, _0023_003DzELu0Pss_003D.FillRegions);
			array = _0023_003DzTq8rUu2Kj6vPGUyNS62aE7s_003D(region.Vertices, region.Triangles).ToArray();
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Hatch hatch)
		{
			if (hatch.IsSolid() && _0023_003DzELu0Pss_003D.FillRegions)
			{
				ICurve[] array3 = new ICurve[hatch.ContourList.Count];
				for (int j = 0; j < hatch.ContourList.Count; j++)
				{
					array3[j] = new LinearPath(((Entity)hatch.ContourList[j]).Vertices);
				}
				devDept.Eyeshot.Entities.Region[] array4 = Utility.DetectRegionsFromContours(array3, hatch.Plane);
				array4[0].Regen(0.0);
				SilhoWireData silhoWireData2 = _0023_003Dz_GyOHL_0024i8xyp(array4[0], _0023_003DzELu0Pss_003D, ref _0023_003Dz_00245kcECVgngOLQYbjzQ_003D_003D);
				silhoWireData2.Entity = hatch;
				for (int k = 1; k < array4.Length; k++)
				{
					array4[k].Regen(0.0);
					SilhoWireData silhoWireData3 = _0023_003Dz_GyOHL_0024i8xyp(array4[k], _0023_003DzELu0Pss_003D, ref _0023_003Dz_00245kcECVgngOLQYbjzQ_003D_003D);
					silhoWireData3.Entity = hatch;
					_0023_003Dz_00245kcECVgngOLQYbjzQ_003D_003D.Add(silhoWireData3);
				}
				return silhoWireData2;
			}
			silhoWireData = new SilhoWireData(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents);
			silhoWireData.DataMode = silhoDataType.LineList;
			List<Point3D> list10 = new List<Point3D>(hatch.patternLines);
			if (hatch.patternPoints.Length != 0)
			{
				silhoWireData.startPointVertices = hatch.patternLines.Length;
				list10.AddRange(hatch.patternPoints);
			}
			array = list10.ToArray();
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Mesh mesh && _0023_003DzV7icIEk_003D(_0023_003DzELu0Pss_003D.Parents))
		{
			silhoWireData = new _0023_003DzPPuckBjRMBPouGRNizHr6AJfouT_z5FFnA_003D_003D(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents, _0023_003DzpaBsULpDiecO: true);
			array = _0023_003DzTq8rUu2Kj6vPGUyNS62aE7s_003D(mesh.Vertices, mesh.Triangles).ToArray();
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Picture)
		{
			silhoWireData = new _0023_003DzYfYjH9Y9ofHnADzwKoCq_ZuL_00240FeLeh_0024qA_003D_003D(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents);
			array = new List<Point3D>(_0023_003Dzs_0024uS8LA_003D.Vertices) { (Point3D)_0023_003Dzs_0024uS8LA_003D.Vertices[0].Clone() }.ToArray();
		}
		else
		{
			if (_0023_003Dzs_0024uS8LA_003D is FastPointCloud fastPointCloud && _0023_003DzV7icIEk_003D(_0023_003DzELu0Pss_003D.Parents))
			{
				silhoWireData = new SilhoWireData(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents);
				int num = fastPointCloud.PointArray.Length / 3;
				silhoWireData.Vertices = new float[num, 3];
				int l = 0;
				int num2 = 0;
				for (; l < num; l++)
				{
					silhoWireData.Vertices[l, 0] = fastPointCloud.PointArray[num2++];
					silhoWireData.Vertices[l, 1] = fastPointCloud.PointArray[num2++];
					silhoWireData.Vertices[l, 2] = 0f;
					num2++;
				}
				silhoWireData.DataMode = silhoDataType.LineList;
				return silhoWireData;
			}
			silhoWireData = new SilhoWireData(_0023_003Dzs_0024uS8LA_003D, _0023_003DzELu0Pss_003D.Parents);
			string lineTypeName = _0023_003DzELu0Pss_003D.Attributes.LineTypeName;
			if (!string.IsNullOrEmpty(lineTypeName) && _0023_003DzELu0Pss_003D.LineTypes[lineTypeName].Pattern != null && _0023_003DzELu0Pss_003D.LineTypes[lineTypeName].Pattern.Length != 0)
			{
				silhoWireData.DataMode = silhoDataType.LineList;
				_0023_003DzELu0Pss_003D.LineTypes[lineTypeName].GetPatternVertices(_0023_003DzELu0Pss_003D.MaxPatternRepetitions, _0023_003Dzs_0024uS8LA_003D.Vertices, _0023_003Dzs_0024uS8LA_003D.LineTypeScale * _0023_003DzELu0Pss_003D.Document.LineTypeScale, out var lines, out var points, _0023_003DzELu0Pss_003D.FrustumParams.Transformation);
				List<Point3D> list11 = new List<Point3D>(lines);
				if (points.Count > 0)
				{
					silhoWireData.startPointVertices = lines.Count;
					list11.AddRange(points);
				}
				array = list11.ToArray();
			}
			else
			{
				array = _0023_003Dzs_0024uS8LA_003D.Vertices;
			}
		}
		_0023_003DzG29BuGPAjYqU(array, out silhoWireData.Vertices, 0.0);
		for (int m = 0; m < list.Count; m++)
		{
			_0023_003DzG29BuGPAjYqU(list[m], out _0023_003Dz_00245kcECVgngOLQYbjzQ_003D_003D[m].Vertices, 0.0);
		}
		return silhoWireData;
	}

	private bool _0023_003Dzj0IBnUt8SGHt(Text _0023_003DzwyYng5o_003D, PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		if (!HdlViewSettings.FillTexts || HdlViewSettings.ForceTextsAsTriangles || HdlViewSettings._0023_003DzjWOIYmI_003D[_0023_003DzwyYng5o_003D.StyleName].IsSHX())
		{
			return false;
		}
		HdlViewSettings.Camera.GetFrame(out var _, out var _, out var _, out var camZ);
		Vector3D axisZ = _0023_003DzwyYng5o_003D.Plane.AxisZ;
		if (_0023_003DzELu0Pss_003D.FrustumParams.Transformation != null)
		{
			axisZ.TransformBy(_0023_003DzELu0Pss_003D.FrustumParams.Transformation);
		}
		return Vector3D.AreCoincident(camZ, axisZ, Utility._0023_003DzxhnLabVjXjPg);
	}

	private static List<Point3D> _0023_003DzHWHGDy9x7KlK(Point3D[][] _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D)
	{
		List<Point3D> list = new List<Point3D>();
		if (_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D == null)
		{
			return list;
		}
		for (int i = 0; i < _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D.GetLength(0); i++)
		{
			for (int j = 1; j < _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D[i].Length; j++)
			{
				list.Add(_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D[i][j - 1]);
				list.Add(_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D[i][j]);
			}
		}
		return list;
	}

	private static List<Point3D> _0023_003Dz7Ga_ltfxbqYC(Point3D[][] _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D)
	{
		List<Point3D> list = new List<Point3D>();
		if (_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D == null)
		{
			return list;
		}
		for (int i = 0; i < _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D.GetLength(0); i++)
		{
			for (int j = 0; j < _0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D[i].Length; j++)
			{
				list.Add(_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D[i][j++]);
				list.Add(_0023_003DzHrvr2bchN6pj8RdUXQ_003D_003D[i][j++]);
			}
		}
		return list;
	}

	private static List<Point3D> _0023_003DzTq8rUu2Kj6vPGUyNS62aE7s_003D(Point3D[][] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		List<Point3D> list = new List<Point3D>();
		if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D == null)
		{
			return list;
		}
		for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.GetLength(0); i++)
		{
			list.AddRange(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]);
		}
		return list;
	}

	private static List<Point3D> _0023_003DzTq8rUu2Kj6vPGUyNS62aE7s_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
	{
		List<Point3D> list = new List<Point3D>();
		if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D == null)
		{
			return list;
		}
		foreach (IndexTriangle indexTriangle in _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
		{
			list.Add(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V1]);
			list.Add(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V2]);
			list.Add(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V3]);
		}
		return list;
	}

	internal static SilhoWireData _0023_003Dzd6UfXbAV5XrdEzghYg_003D_003D(Solid _0023_003DzQUhnjVe9kSO_0024, Stack<BlockReference> _0023_003Dzq5nwX2I_003D)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		foreach (Solid.Portion portion in _0023_003DzQUhnjVe9kSO_0024.Portions)
		{
			num += portion.VertexCount;
			num2 += ((portion.Triangles != null) ? portion.Triangles.Length : 0);
			num3 += portion.Edges.Length;
		}
		Point3D[] array = new Point3D[num];
		List<IndexTriangle> list = new List<IndexTriangle>(num2);
		List<IndexLine> list2 = new List<IndexLine>(num3);
		int num4 = 0;
		int num5 = 0;
		foreach (Solid.Portion portion2 in _0023_003DzQUhnjVe9kSO_0024.Portions)
		{
			num5 = num4;
			for (int i = 0; i < portion2.VertexCount; i++)
			{
				array[num4++] = (Point3D)portion2._vertices[i].Clone();
			}
			if (portion2.Triangles != null)
			{
				IndexTriangle[] triangles = portion2.Triangles;
				foreach (IndexTriangle indexTriangle in triangles)
				{
					list.Add(new IndexTriangle(indexTriangle.V1 + num5, indexTriangle.V2 + num5, indexTriangle.V3 + num5));
				}
			}
			if (portion2.Edges != null)
			{
				IndexLine[] edges = portion2.Edges;
				foreach (IndexLine indexLine in edges)
				{
					list2.Add(new IndexLine(indexLine.V1 + num5, indexLine.V2 + num5));
				}
			}
		}
		Utility._0023_003DzJNADeOQRO6_fPmN4Ig_003D_003D(list, list2, array, out var _0023_003DzPSHPV1adgQcYEwqKXHGDJDXML8EU, out var _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D, Utility._0023_003DzKN_0024vjGN5_0024fwYJSS8TN63qBo_003D(array), _0023_003Dz5syaaeMy5pLBOZfa4Kfhgq4_003D: true, _0023_003DzFwalihjMriJGyFaGGg_003D_003D: false);
		return _0023_003DzeWZNZhCW691ciXKd0w_003D_003D(_0023_003DzQUhnjVe9kSO_0024, _0023_003Dzq5nwX2I_003D, _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D, _0023_003DzPSHPV1adgQcYEwqKXHGDJDXML8EU, list2.ToArray(), _0023_003DzQUhnjVe9kSO_0024.IsClosed, 0.0);
	}

	internal static _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzHN4TT0c7MLm_0024AVFCx8_L2g4_003D(FemMesh _0023_003Dzkx0ud14_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D)
	{
		if (_0023_003Dzkx0ud14_003D.skin == null)
		{
			Mesh mesh = new Mesh(0, 0, Mesh.natureType.Plain);
			return _0023_003DzeWZNZhCW691ciXKd0w_003D_003D(mesh, _0023_003Dzq5nwX2I_003D, mesh.Vertices, mesh.Triangles, mesh.Edges, _0023_003DzbErHvVw_003D: false, 1.0);
		}
		if (_0023_003Dzkx0ud14_003D.PlotMode == FemMesh.plotType.Mesh)
		{
			return _0023_003DzeWZNZhCW691ciXKd0w_003D_003D(_0023_003Dzkx0ud14_003D, _0023_003Dzq5nwX2I_003D, _0023_003Dzkx0ud14_003D.skin.Vertices, _0023_003Dzkx0ud14_003D.skin.Triangles, _0023_003Dzkx0ud14_003D.skin.Edges, _0023_003Dzkx0ud14_003D.skin.IsClosed, 1.0);
		}
		double _0023_003DzXGmnJb5mDXOU = ((_0023_003Dzkx0ud14_003D.ClippingPlane == null) ? _0023_003Dzkx0ud14_003D.AmplificationFactor : 0.0);
		return _0023_003DzeWZNZhCW691ciXKd0w_003D_003D(_0023_003Dzkx0ud14_003D, _0023_003Dzq5nwX2I_003D, _0023_003Dzkx0ud14_003D.skin.Vertices, _0023_003Dzkx0ud14_003D.skin.Triangles, _0023_003Dzkx0ud14_003D.skin.Edges, _0023_003Dzkx0ud14_003D.skin.IsClosed, _0023_003DzXGmnJb5mDXOU);
	}

	internal static _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzeWZNZhCW691ciXKd0w_003D_003D(Entity _0023_003Dz9j7EUB0_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, IndexLine[] _0023_003DzU3hosSAzkxO7, bool _0023_003DzbErHvVw_003D, double _0023_003DzXGmnJb5mDXOU)
	{
		_0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[] array = new _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[i]);
		}
		return _0023_003DzeWZNZhCW691ciXKd0w_003D_003D(_0023_003Dz9j7EUB0_003D, _0023_003Dzq5nwX2I_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, array, _0023_003DzU3hosSAzkxO7, _0023_003DzbErHvVw_003D, _0023_003DzXGmnJb5mDXOU);
	}

	internal static _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzeWZNZhCW691ciXKd0w_003D_003D(Entity _0023_003Dz9j7EUB0_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, float[] _0023_003DzrH1N0x4_003D, int[] _0023_003DzyM_0024ZQ24dHDyAez5lcQ_003D_003D, IndexLine[] _0023_003DzU3hosSAzkxO7, bool _0023_003DzbErHvVw_003D, double _0023_003DzXGmnJb5mDXOU)
	{
		_0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[] array = new _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[_0023_003DzyM_0024ZQ24dHDyAez5lcQ_003D_003D.Length / 3];
		int num = 0;
		int num2 = 0;
		while (num2 < array.Length)
		{
			int num3 = _0023_003DzyM_0024ZQ24dHDyAez5lcQ_003D_003D[num];
			int num4 = _0023_003DzyM_0024ZQ24dHDyAez5lcQ_003D_003D[num + 1];
			int num5 = _0023_003DzyM_0024ZQ24dHDyAez5lcQ_003D_003D[num + 2];
			array[num2] = new _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D(new int[1][] { new int[3] { num3, num4, num5 } });
			num2++;
			num += 3;
		}
		return _0023_003DzeWZNZhCW691ciXKd0w_003D_003D(_0023_003Dz9j7EUB0_003D, _0023_003Dzq5nwX2I_003D, _0023_003DzrH1N0x4_003D, array, _0023_003DzU3hosSAzkxO7, _0023_003DzbErHvVw_003D, _0023_003DzXGmnJb5mDXOU);
	}

	internal static _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003DzeWZNZhCW691ciXKd0w_003D_003D<T>(Entity _0023_003Dz9j7EUB0_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, T[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[] _0023_003DzpPOEJqcAh7Lr, IndexLine[] _0023_003DzU3hosSAzkxO7, bool _0023_003DzbErHvVw_003D, double _0023_003DzXGmnJb5mDXOU)
	{
		return _0023_003DzeWZNZhCW691ciXKd0w_003D_003D<_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D, T>(_0023_003Dz9j7EUB0_003D, _0023_003Dzq5nwX2I_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzpPOEJqcAh7Lr, _0023_003DzU3hosSAzkxO7, _0023_003DzbErHvVw_003D, _0023_003DzXGmnJb5mDXOU);
	}

	private static _0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D _0023_003Dz5B5v5rZAkT4idX9SIA_003D_003D(Entity _0023_003Dz9j7EUB0_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[] _0023_003DzpPOEJqcAh7Lr, IndexLine[] _0023_003DzU3hosSAzkxO7, bool _0023_003DzbErHvVw_003D, double _0023_003DzXGmnJb5mDXOU)
	{
		return _0023_003DzeWZNZhCW691ciXKd0w_003D_003D<_0023_003DzVmw_xeFMWVWR3W1e3mu7ypMVcypiCVNF4A_003D_003D, Point3D>(_0023_003Dz9j7EUB0_003D, _0023_003Dzq5nwX2I_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzpPOEJqcAh7Lr, _0023_003DzU3hosSAzkxO7, _0023_003DzbErHvVw_003D, _0023_003DzXGmnJb5mDXOU);
	}

	private static Q _0023_003DzeWZNZhCW691ciXKd0w_003D_003D<Q, T>(Entity _0023_003Dz9j7EUB0_003D, Stack<BlockReference> _0023_003Dzq5nwX2I_003D, T[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[] _0023_003DzpPOEJqcAh7Lr, IndexLine[] _0023_003DzU3hosSAzkxO7, bool _0023_003DzbErHvVw_003D, double _0023_003DzXGmnJb5mDXOU) where Q : _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D, new()
	{
		Q val = new Q();
		val.Entity = _0023_003Dz9j7EUB0_003D;
		val._0023_003Dzxhr71LaqxMWZ(_0023_003DzbErHvVw_003D);
		Q val2 = val;
		if (_0023_003Dzq5nwX2I_003D != null)
		{
			val2.Parents = Utility.CloneStack(_0023_003Dzq5nwX2I_003D);
		}
		_0023_003DzZCvePLTSGV_aQjBXK7BoGQkUjMKo(_0023_003DzpPOEJqcAh7Lr, out val2._0023_003DzZSnvfVF8Y5Qg);
		if (typeof(T) == typeof(Point3D))
		{
			_0023_003DzG29BuGPAjYqU(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D as Point3D[], out val2.Vertices, _0023_003DzXGmnJb5mDXOU);
		}
		else
		{
			if (!(typeof(T) == typeof(float)))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986645));
			}
			_0023_003DzG29BuGPAjYqU(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D as float[], out val2.Vertices, _0023_003DzXGmnJb5mDXOU);
		}
		if (_0023_003DzU3hosSAzkxO7 != null && _0023_003DzU3hosSAzkxO7.Length != 0)
		{
			_0023_003DzssRfScH1P94Y(new List<IndexLine>(_0023_003DzU3hosSAzkxO7), out var _0023_003Dz6_W9DGo5pG);
			_0023_003DzD7U65wqw1B6cWM1njuRY3Nw_003D(_0023_003Dz6_W9DGo5pG.ToArray(), out val2._0023_003DzU4XYawo_003D);
		}
		return val2;
	}

	private static void _0023_003DzssRfScH1P94Y(List<IndexLine> _0023_003DzU3hosSAzkxO7, out List<IndexLine> _0023_003Dz6_W9DGo5pG62)
	{
		for (int i = 0; i < _0023_003DzU3hosSAzkxO7.Count; i++)
		{
			IndexLine indexLine = _0023_003DzU3hosSAzkxO7[i];
			if (indexLine.V1 > indexLine.V2)
			{
				int v = indexLine.V1;
				indexLine.V1 = indexLine.V2;
				indexLine.V2 = v;
			}
		}
		IndexLineComparer indexLineComparer = new IndexLineComparer();
		_0023_003DzU3hosSAzkxO7.Sort(indexLineComparer.Compare);
		_0023_003Dz6_W9DGo5pG62 = new List<IndexLine>(_0023_003DzU3hosSAzkxO7.Count);
		_0023_003Dz6_W9DGo5pG62.Add(_0023_003DzU3hosSAzkxO7[0]);
		IndexLine indexLine2 = _0023_003DzU3hosSAzkxO7[0];
		for (int j = 1; j < _0023_003DzU3hosSAzkxO7.Count; j++)
		{
			IndexLine indexLine3 = _0023_003DzU3hosSAzkxO7[j];
			if (indexLine3.V1 > indexLine2.V1 || indexLine3.V2 > indexLine2.V2)
			{
				_0023_003Dz6_W9DGo5pG62.Add(indexLine3);
				indexLine2 = indexLine3;
			}
			else if (indexLine2 is _0023_003DzPWBOFEX1IKDR { _0023_003DzSaHVljQ_003D: -1 } _0023_003DzPWBOFEX1IKDR2)
			{
				_0023_003DzPWBOFEX1IKDR2._0023_003DzSaHVljQ_003D = ((_0023_003DzPWBOFEX1IKDR)indexLine3)._0023_003DzSaHVljQ_003D;
			}
		}
	}

	internal static void _0023_003DzG29BuGPAjYqU(IReadOnlyList<Point3D> _0023_003DzcDEsV8s_003D, out float[,] _0023_003DzTbDlaOM_003D, double _0023_003DzXGmnJb5mDXOU)
	{
		if (_0023_003DzcDEsV8s_003D == null)
		{
			_0023_003DzTbDlaOM_003D = null;
			return;
		}
		_0023_003DzTbDlaOM_003D = new float[_0023_003DzcDEsV8s_003D.Count, 3];
		if (_0023_003DzXGmnJb5mDXOU == 0.0)
		{
			for (int i = 0; i < _0023_003DzcDEsV8s_003D.Count; i++)
			{
				_0023_003DzTbDlaOM_003D[i, 0] = (float)_0023_003DzcDEsV8s_003D[i].X;
				_0023_003DzTbDlaOM_003D[i, 1] = (float)_0023_003DzcDEsV8s_003D[i].Y;
				_0023_003DzTbDlaOM_003D[i, 2] = (float)_0023_003DzcDEsV8s_003D[i].Z;
			}
			return;
		}
		for (int j = 0; j < _0023_003DzcDEsV8s_003D.Count; j++)
		{
			Node node = (Node)_0023_003DzcDEsV8s_003D[j];
			_0023_003DzTbDlaOM_003D[j, 0] = (float)(node.X + node.Ux * _0023_003DzXGmnJb5mDXOU);
			_0023_003DzTbDlaOM_003D[j, 1] = (float)(node.Y + node.Uy * _0023_003DzXGmnJb5mDXOU);
			_0023_003DzTbDlaOM_003D[j, 2] = (float)(node.Z + node.Uz * _0023_003DzXGmnJb5mDXOU);
		}
	}

	internal static void _0023_003DzG29BuGPAjYqU(float[] _0023_003DzcDEsV8s_003D, out float[,] _0023_003DzTbDlaOM_003D, double _0023_003DzXGmnJb5mDXOU)
	{
		if (_0023_003DzcDEsV8s_003D == null)
		{
			_0023_003DzTbDlaOM_003D = null;
			return;
		}
		int num = _0023_003DzcDEsV8s_003D.Length / 3;
		_0023_003DzTbDlaOM_003D = new float[num, 3];
		if (_0023_003DzXGmnJb5mDXOU == 0.0)
		{
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				_0023_003DzTbDlaOM_003D[i, 0] = _0023_003DzcDEsV8s_003D[num2++];
				_0023_003DzTbDlaOM_003D[i, 1] = _0023_003DzcDEsV8s_003D[num2++];
				_0023_003DzTbDlaOM_003D[i, 2] = _0023_003DzcDEsV8s_003D[num2++];
			}
		}
	}

	private static void _0023_003DzZCvePLTSGV_aQjBXK7BoGQkUjMKo(_0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[] _0023_003DzhHqYL4M_003D, out _0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom[] _0023_003DzZo2LNpGcYzG7)
	{
		if (_0023_003DzhHqYL4M_003D == null)
		{
			_0023_003DzZo2LNpGcYzG7 = null;
			return;
		}
		_0023_003DzZo2LNpGcYzG7 = new _0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom[_0023_003DzhHqYL4M_003D.Length];
		for (int i = 0; i < _0023_003DzhHqYL4M_003D.Length; i++)
		{
			_0023_003DzZo2LNpGcYzG7[i] = new _0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom(_0023_003DzhHqYL4M_003D[i]._0023_003DzhMDfC7g_003D);
		}
	}

	private static void _0023_003Dzi2GAS5dpl44ADW5NNg_003D_003D(int _0023_003DzPhvUoeo_003D, out int[,] _0023_003DzTbDlaOM_003D)
	{
		_0023_003DzTbDlaOM_003D = new int[_0023_003DzPhvUoeo_003D, 2];
		for (int i = 0; i < _0023_003DzPhvUoeo_003D - 1; i++)
		{
			_0023_003DzTbDlaOM_003D[i, 0] = i;
			_0023_003DzTbDlaOM_003D[i, 1] = i + 1;
		}
		_0023_003DzTbDlaOM_003D[_0023_003DzPhvUoeo_003D - 1, 0] = _0023_003DzPhvUoeo_003D - 1;
		_0023_003DzTbDlaOM_003D[_0023_003DzPhvUoeo_003D - 1, 1] = 0;
	}

	private static void _0023_003DzD7U65wqw1B6cWM1njuRY3Nw_003D(IndexLine[] _0023_003DzcDEsV8s_003D, out _0023_003DzTNgUFyqUTGF3Q5n3QnnlrNv9y2li[] _0023_003DzTbDlaOM_003D)
	{
		if (_0023_003DzcDEsV8s_003D == null)
		{
			_0023_003DzTbDlaOM_003D = null;
			return;
		}
		_0023_003DzTbDlaOM_003D = new _0023_003DzTNgUFyqUTGF3Q5n3QnnlrNv9y2li[_0023_003DzcDEsV8s_003D.Length];
		for (int i = 0; i < _0023_003DzcDEsV8s_003D.Length; i++)
		{
			IndexLine indexLine = _0023_003DzcDEsV8s_003D[i];
			if (indexLine is _0023_003DzPWBOFEX1IKDR _0023_003DzPWBOFEX1IKDR2)
			{
				_0023_003DzTbDlaOM_003D[i] = new _0023_003DzTNgUFyqUTGF3Q5n3QnnlrNv9y2li(indexLine.V1, indexLine.V2, _0023_003DzPWBOFEX1IKDR2._0023_003DzSaHVljQ_003D);
			}
			else
			{
				_0023_003DzTbDlaOM_003D[i] = new _0023_003DzTNgUFyqUTGF3Q5n3QnnlrNv9y2li(indexLine.V1, indexLine.V2, -1);
			}
		}
	}

	internal static int[,] _0023_003DzkfglKE_0024Pn8Ii(int[,] _0023_003DzDn3gsQfBhRkJ)
	{
		int num = 0;
		int length = _0023_003DzDn3gsQfBhRkJ.GetLength(0);
		for (int i = 0; i < length; i++)
		{
			if (_0023_003DzDn3gsQfBhRkJ[i, 3] == -1)
			{
				num++;
			}
		}
		if (num > 0)
		{
			int[,] array = new int[length - num, 4];
			int num2 = 0;
			for (int j = 0; j < length; j++)
			{
				if (_0023_003DzDn3gsQfBhRkJ[j, 3] != -1)
				{
					array[num2, 0] = _0023_003DzDn3gsQfBhRkJ[j, 0];
					array[num2, 1] = _0023_003DzDn3gsQfBhRkJ[j, 1];
					array[num2, 2] = _0023_003DzDn3gsQfBhRkJ[j, 2];
					array[num2, 3] = _0023_003DzDn3gsQfBhRkJ[j, 3];
					num2++;
				}
			}
			return array;
		}
		return _0023_003DzDn3gsQfBhRkJ;
	}

	internal static void _0023_003DzY9TYF9sTjnZYO51HtXX26S0_003D(Entity _0023_003Dzs_0024uS8LA_003D, DrawSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		if (_0023_003Dzs_0024uS8LA_003D.silhoData == null)
		{
			_0023_003Dzs_0024uS8LA_003D.silhoData = _0023_003Dzs_0024uS8LA_003D._0023_003DzOQ9MbnSofHiL_xtPyyGkf6ozeVZJ(new PreProcessSilhouettesParams
			{
				Parents = null,
				Blocks = _0023_003DzELu0Pss_003D.Blocks
			});
		}
		_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2 = (_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D)_0023_003Dzs_0024uS8LA_003D.silhoData;
		_0023_003DzcLScPK9UqQCBGPppfM8OSvQ_003D(_0023_003DzELu0Pss_003D.RenderContext, _0023_003DzELu0Pss_003D.ProjectionMode, _0023_003DzELu0Pss_003D.ModelViewProj, _0023_003DzELu0Pss_003D.ViewFrame, _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2, ref _0023_003Dzs_0024uS8LA_003D.sharedEdgesForSilhouettesDraw, _0023_003DzELu0Pss_003D.Transformation, _0023_003DzELu0Pss_003D.SkipBorderEdges);
		_0023_003DzELu0Pss_003D.RenderContext.DrawSilhouettes(_0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D2);
	}

	internal static double _0023_003DqJqSSlsAM9ZOWy2sGhrMYE_OnjFsONoIybzA_0024ObREKHQWLvhm_5zkw_0024scxu_0024D_JPh(double _0023_003DzFYcYsHhaFHz6, double _0023_003DzIAOj0lYmWIeD)
	{
		double num = 0.2;
		double num2 = Math.PI / 4.0 + _0023_003DzFYcYsHhaFHz6;
		if (Math.Abs(num2 - _0023_003DzIAOj0lYmWIeD) <= num)
		{
			_0023_003DzFYcYsHhaFHz6 = ((!(num2 < _0023_003DzIAOj0lYmWIeD)) ? (_0023_003DzIAOj0lYmWIeD + num) : (_0023_003DzIAOj0lYmWIeD - num));
		}
		return _0023_003DzFYcYsHhaFHz6;
	}
}
