using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using devDept.Diagnostic;
using devDept.Eyeshot.Entities.NurbsSurface;
using devDept.Eyeshot.Meshing;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
public class Brep : Entity, IFace, ICloneable, ISelectableSubItems, IFaceSelectable
{
	private sealed class _0023_003Dz15xQV4ABMjmVh1Ui5plqk5A_003D
	{
		public Interval _0023_003DzYNjcavt9guh2;

		public Brep _0023_003DzopRx0_MBcTQs;

		internal Brep _0023_003DzSq8J_Vp_VjkEDtZ7aR5xBWU_003D(Region _0023_003DzFDwqpgU_003D)
		{
			return _0023_003DzFDwqpgU_003D.ExtrudeAsBrep(_0023_003DzYNjcavt9guh2, 0.0, _0023_003DzopRx0_MBcTQs._rebuildTol);
		}
	}

	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Predicate<Face> _0023_003Dz2OW3X2_0024kJijr8gZHOg_003D_003D;

		public static Func<Brep, bool> _0023_003Dzb_wDZ76zCSAdGR3zhw_003D_003D;

		public static Func<Brep, Brep> _0023_003DzvdZ2p67h7qzCqqrR1w_003D_003D;

		public static Predicate<bool> _0023_003Dzc8auAS2YXoK9TChmnQ_003D_003D;

		public static Func<Loop, OrientedEdge[]> _0023_003Dz741qW04X4fIbBg3ufQ_003D_003D;

		public static Func<OrientedEdge[], int> _0023_003DzojhVyQRBSKEvHfoToQ_003D_003D;

		public static Func<Loop, OrientedEdge[]> _0023_003DzHGGzGUGuHIBQ0YJ0ng_003D_003D;

		public static Func<OrientedEdge[], int> _0023_003DzMzfx_KKnGqRqw43dlA_003D_003D;

		public static Func<bool, bool> _0023_003DzM6rfetTj7btgMliI7A_003D_003D;

		public static Func<Face[], List<Face>> _0023_003DzGHtwGdYJ_0024E0YB7N9Bg_003D_003D;

		public static Func<List<Face>, Face[]> _0023_003DzqxYmaT3c5CCIQr0imw_003D_003D;

		public static Func<Edge, Edge> _0023_003DzCMmwolqFhK8y5Y6pXg_003D_003D;

		public static Func<Point3D, Point3D> _0023_003Dzi6QvGwk2bCiQorav_g_003D_003D;

		public static Func<Point3D, bool> _0023_003DzrmK7NaPoZpdWs854Gg_003D_003D;

		public static Func<Edge, bool> _0023_003DzzSSRgMvhSNO3126Pvw_003D_003D;

		public static Func<Point3D, bool> _0023_003DzsEWLlJhnFioDBjk3dg_003D_003D;

		public static Func<Edge, bool> _0023_003DzHszwsR_0024WdsHia_iH8w_003D_003D;

		public static Func<ICurve, ICurve> _0023_003Dz7buj28OQeeBSDiSqhA_003D_003D;

		public static Func<IEnumerable<int>, IEnumerable<int>> _0023_003DzsVTXpk1CSebYnfmUgw_003D_003D;

		public static Func<IEnumerable<int>, IEnumerable<int>> _0023_003DzozZ1tfzyyVFuG5_0024q1w_003D_003D;

		public static Func<ICurve, ICurve> _0023_003Dz2SZiaEFaXuR0kXsLAg_003D_003D;

		internal bool _0023_003DzXAoU7knBHu_0024yO2hv69SJSYPULG85uS8pgQ_003D_003D(Face _0023_003DzhidJeNw_003D)
		{
			return _0023_003DzhidJeNw_003D == null;
		}

		internal bool _0023_003DzleZv6WH3Mo9S5rKrKbwtxT_c1ar1Nf6GAw_003D_003D(Brep _0023_003Dz1v6oPQk_003D)
		{
			return !string.IsNullOrEmpty(_0023_003Dz1v6oPQk_003D.MaterialName);
		}

		internal Brep _0023_003Dz8nsRIIMFnbkPm1gXVNq01bqATvNMexyh1A_003D_003D(Brep _0023_003DzTLDMVPk_003D)
		{
			return _0023_003DzTLDMVPk_003D;
		}

		internal bool _0023_003DzcV9IxxQqdwBM5VMB6YD8RM09JkCRTcDgjHk38SAuPZqW(bool _0023_003Dz1v6oPQk_003D)
		{
			return _0023_003Dz1v6oPQk_003D;
		}

		internal OrientedEdge[] _0023_003DzzQi8_mSrFE1x8McExRVdCUOE8ODc(Loop _0023_003DzGcl_0024E9o_003D)
		{
			return _0023_003DzGcl_0024E9o_003D.Segments;
		}

		internal int _0023_003DzetaLymQteT4vni1rPF3jrQwY2h8i(OrientedEdge[] _0023_003DzIL0P1ps_003D)
		{
			return _0023_003DzIL0P1ps_003D.Length;
		}

		internal OrientedEdge[] _0023_003DzP_lVnqneasq2ZiLCMueV6toFC4Zt(Loop _0023_003DzGcl_0024E9o_003D)
		{
			return _0023_003DzGcl_0024E9o_003D.Segments;
		}

		internal int _0023_003Dzhfnn0wVocKQTjE1q8Lm8Xax3yPAm(OrientedEdge[] _0023_003DzIL0P1ps_003D)
		{
			return _0023_003DzIL0P1ps_003D.Length;
		}

		internal bool _0023_003Dzgnx7m86ApRe6vFzfPThBN7s_003D(bool _0023_003DzBJFJHwk_003D)
		{
			return !_0023_003DzBJFJHwk_003D;
		}

		internal List<Face> _0023_003DzYUKPDc0_cYRiXqVIsqESXWASX0ZP_qBjKg_003D_003D(Face[] _0023_003DzD_6vtKc_003D)
		{
			return _0023_003DzD_6vtKc_003D.ToList();
		}

		internal Face[] _0023_003DzSy8kp_dFE_fwuMdgqb717vvl1AUYOyCqNA_003D_003D(List<Face> _0023_003DzcDEsV8s_003D)
		{
			return _0023_003DzcDEsV8s_003D.ToArray();
		}

		internal Edge _0023_003DzorDoVJfhRkos2XZbyY2NYTH0g_0024cXf_rMdw_003D_003D(Edge _0023_003Dz77g161c_003D)
		{
			return (Edge)_0023_003Dz77g161c_003D.Clone();
		}

		internal Point3D _0023_003Dz8IEv_0024HX_00243TCfcutwFbMWAFkthgd562J9dw_003D_003D(Point3D _0023_003Dz77g161c_003D)
		{
			return (Point3D)_0023_003Dz77g161c_003D.Clone();
		}

		internal bool _0023_003DzelAtL_E7coVwIz5fbpnnJWnCWejt(Point3D _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D != null;
		}

		internal bool _0023_003DzVMSE7rEdX_mLgLNcy7cLz2rTH_ZJ(Edge _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D != null;
		}

		internal bool _0023_003Dz4qNez3F6eNfUibOJEEufUAijDfNX(Point3D _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D != null;
		}

		internal bool _0023_003Dz815M7ulVGJv8zwPZmQ4amssHY3rb(Edge _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D != null;
		}

		internal ICurve _0023_003DzUJxIL65txiAkccdTAQ6nWsQ_003D(ICurve _0023_003Dz9Bu_NNI_003D)
		{
			return (ICurve)_0023_003Dz9Bu_NNI_003D.Clone();
		}

		internal IEnumerable<int> _0023_003DzSjCB7oq8txhO2Y0Ppo_JZaZzReJU(IEnumerable<int> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D;
		}

		internal IEnumerable<int> _0023_003DzFew_0024JcTYsZ7ngSw0_0024ePngqAa_002400E(IEnumerable<int> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D;
		}

		internal ICurve _0023_003DzYVfRUioFnVlDuqo4m5CeihGaABWp(ICurve _0023_003Dz437_00244ak_003D)
		{
			return ((TrimCurve)_0023_003Dz437_00244ak_003D).Edge;
		}
	}

	internal enum _0023_003Dz4Hw_002424_0024xhqb8
	{

	}

	private sealed class _0023_003Dz8qmhS3jTMV3inA_0024QqkK0CVc_003D
	{
		public double _0023_003DzYNjcavt9guh2;

		public double _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D;

		public Brep _0023_003DzopRx0_MBcTQs;

		internal Brep _0023_003DzFLW5ZaGz6fHDhwojVqI2LJs_003D(Region _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.ExtrudeAsBrep(_0023_003DzYNjcavt9guh2, _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, _0023_003DzopRx0_MBcTQs._rebuildTol);
		}
	}

	private sealed class _0023_003Dz8xgbeGLa6j1KDhTFtVgo_v8_003D
	{
		public ICurve _0023_003DzSwfghCo_003D;

		internal bool _0023_003DzIMtdgvirAeKkia0XRLb5iNM_003D(ICurve _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D.EdgeIndex == _0023_003DzSwfghCo_003D.EdgeIndex;
		}
	}

	private sealed class _0023_003DzBXl2jEce9tintKxz1V2lw3E_003D
	{
		public int _0023_003DzHUUmkb0uibv6;

		public Func<int, bool> _0023_003DzkqbsCVPMJ_0024g6;

		internal bool _0023_003Dzj_0024P3tKtF3_oYedKZK_EPXlQ_003D(int _0023_003DzB68dg9Q_003D)
		{
			return _0023_003DzB68dg9Q_003D != _0023_003DzHUUmkb0uibv6;
		}

		internal bool _0023_003DzzWGLMtLQHomKan1p9DsfzdQ_003D(int _0023_003DzB68dg9Q_003D)
		{
			return _0023_003DzB68dg9Q_003D != _0023_003DzHUUmkb0uibv6;
		}
	}

	private sealed class _0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D
	{
		public double _0023_003DzYNjcavt9guh2;

		public double _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D;

		public Brep _0023_003DzopRx0_MBcTQs;

		internal Brep _0023_003Dz2L_0024ufM1_lFaQmy0GWXfZWsQ_003D(Region _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.ExtrudeAsBrep(_0023_003DzYNjcavt9guh2, _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, _0023_003DzopRx0_MBcTQs._rebuildTol);
		}
	}

	private sealed class _0023_003DzHGlGj7oYIL6hV3aiCu4SRzE_003D
	{
		public ICurve _0023_003DzHgrHIfhYCh4p;

		public Brep _0023_003DzopRx0_MBcTQs;

		public sweepMethodType _0023_003Dzjy_YX_0024o_003D;

		internal Brep _0023_003Dzc1iv6ohqRQwfCjyJuA_003D_003D(Region _0023_003DzFDwqpgU_003D)
		{
			return _0023_003DzFDwqpgU_003D.SweepAsBrep(_0023_003DzHgrHIfhYCh4p, _0023_003DzopRx0_MBcTQs._rebuildTol, _0023_003Dzjy_YX_0024o_003D);
		}
	}

	private sealed class _0023_003DzI0_0024QGEKv3_eQYWLq94YAcwY_003D
	{
		public double _0023_003DzYNjcavt9guh2;

		public Brep _0023_003DzopRx0_MBcTQs;

		internal Brep _0023_003DzFLW5ZaGz6fHDhwojVqI2LJs_003D(Region _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.ExtrudeAsBrep(_0023_003DzYNjcavt9guh2, 0.0, _0023_003DzopRx0_MBcTQs._rebuildTol);
		}
	}

	private sealed class _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D
	{
		public Interval _0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D;

		public double _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D;

		public Brep _0023_003DzopRx0_MBcTQs;

		internal Brep _0023_003DzC912HEnIM_0024HWUN5IgcdbbURgtGOo(Region _0023_003DzFDwqpgU_003D)
		{
			return _0023_003DzFDwqpgU_003D.ExtrudeAsBrep(_0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D, _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, _0023_003DzopRx0_MBcTQs._rebuildTol);
		}
	}

	internal struct _0023_003DzKfMGQQU_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal int _0023_003DzBLJ2fdI_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal int _0023_003DzLJVtPYc_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal int _0023_003DzVYqYlD94dR8lRmB4iw_003D_003D;

		public override bool Equals(object _0023_003DzCX9Hbao_003D)
		{
			if (!(_0023_003DzCX9Hbao_003D is _0023_003DzKfMGQQU_003D _0023_003DzKfMGQQU_003D2))
			{
				return false;
			}
			if (_0023_003DzKfMGQQU_003D2._0023_003DzBLJ2fdI_003D == _0023_003DzBLJ2fdI_003D && _0023_003DzKfMGQQU_003D2._0023_003DzLJVtPYc_003D == _0023_003DzLJVtPYc_003D && _0023_003DzKfMGQQU_003D2._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D == _0023_003DzVYqYlD94dR8lRmB4iw_003D_003D)
			{
				return true;
			}
			return false;
		}
	}

	private sealed class _0023_003DzM8ZnNXymrNp7E4BnbA0MVjk_003D
	{
		public OrientedEdge _0023_003DzIL0P1ps_003D;

		public Func<ICurve, bool> _0023_003DzkqbsCVPMJ_0024g6;

		internal bool _0023_003Dz_0024JfuHw1huMKu_qlButMGYuA_003D(ICurve _0023_003DzFDJdA7A_003D)
		{
			return _0023_003DzIL0P1ps_003D.CurveIndex == _0023_003DzFDJdA7A_003D.EdgeIndex;
		}
	}

	private sealed class _0023_003DzMWfQIqNU0l3e4CpzA_00248LyOY_003D
	{
		public double _0023_003Dz6pajdGM_003D;

		public Vector3D _0023_003DzxuJqjrs_003D;

		public Point3D _0023_003DzbUvT9Pc_003D;

		public Brep _0023_003DzopRx0_MBcTQs;

		internal Brep _0023_003DzppdwzV1WlOIza1L6gdCNVhU_003D(Region _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.RevolveAsBrep(0.0, _0023_003Dz6pajdGM_003D, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzopRx0_MBcTQs._rebuildTol);
		}
	}

	private sealed class _0023_003DzMmUe4Z6aWCjTKT9gjvK6TGI_003D
	{
		public Interval _0023_003DzYNjcavt9guh2;

		public Brep _0023_003DzopRx0_MBcTQs;

		internal Brep _0023_003Dz2L_0024ufM1_lFaQmy0GWXfZWsQ_003D(Region _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.ExtrudeAsBrep(_0023_003DzYNjcavt9guh2, 0.0, _0023_003DzopRx0_MBcTQs._rebuildTol);
		}
	}

	private sealed class _0023_003DzOitZJ30tn5_gRGODHg0w9aw_003D
	{
		public double _0023_003Dz6pajdGM_003D;

		public Vector3D _0023_003DzxuJqjrs_003D;

		public Point3D _0023_003DzbUvT9Pc_003D;

		internal Brep _0023_003Dz1mGf45_HNb7F2_0024SKq2eywcY_003D(Region _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.RevolveAsBrep(0.0, _0023_003Dz6pajdGM_003D, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D);
		}
	}

	private sealed class _0023_003DzPNxxWiDmMk0rfV6RJz_0024qcqc_003D
	{
		public Brep _0023_003DzopRx0_MBcTQs;

		public int _0023_003DzOhFjSPs8eMvF;

		public int _0023_003DzHUUmkb0uibv6;

		internal bool _0023_003DzGViQ4YDRwZ5Fo_aTuD_002445zQ_003D(int _0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzopRx0_MBcTQs.Edges[_0023_003DzbfrNXYE_003D].Parents.Except(new int[2] { _0023_003DzOhFjSPs8eMvF, _0023_003DzHUUmkb0uibv6 }).Count() == 1;
		}

		internal bool _0023_003DztIhSSHQn_8yGaZnZU5cEZD8_003D(int _0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzopRx0_MBcTQs.Edges[_0023_003DzbfrNXYE_003D].Parents.Except(new int[2] { _0023_003DzOhFjSPs8eMvF, _0023_003DzHUUmkb0uibv6 }).Count() == 1;
		}

		internal IEnumerable<int> _0023_003Dz3_JTH0tGPEQeF5LSe8SuR_0024g_003D(int _0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzopRx0_MBcTQs.Edges[_0023_003DzbfrNXYE_003D].Parents.Except(new int[2] { _0023_003DzOhFjSPs8eMvF, _0023_003DzHUUmkb0uibv6 });
		}

		internal IEnumerable<int> _0023_003DzhpSgx_0024i4YarWs_0024fiGcxELdM_003D(int _0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzopRx0_MBcTQs.Edges[_0023_003DzbfrNXYE_003D].Parents.Except(new int[2] { _0023_003DzOhFjSPs8eMvF, _0023_003DzHUUmkb0uibv6 });
		}
	}

	private sealed class _0023_003DzPo0945mwOhxL_0024aiBNElAmFQ_003D
	{
		public Tuple<int, int> _0023_003DzDVfrOi0_003D;

		internal bool _0023_003DzDxINQmRyCj750lEiIg2qAGZ89nZGsHZUug_003D_003D(Tuple<int, int> _0023_003DzNDQ_E88_003D)
		{
			if (_0023_003DzNDQ_E88_003D.Item1 == _0023_003DzDVfrOi0_003D.Item1)
			{
				return _0023_003DzNDQ_E88_003D.Item2 == _0023_003DzDVfrOi0_003D.Item2;
			}
			return false;
		}
	}

	private sealed class _0023_003DzQicRXXHaEitj718W9hu_JU0_003D
	{
		public double _0023_003DzYNjcavt9guh2;

		public Brep _0023_003DzopRx0_MBcTQs;

		internal Brep _0023_003Dz2L_0024ufM1_lFaQmy0GWXfZWsQ_003D(Region _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.ExtrudeAsBrep(_0023_003DzYNjcavt9guh2, 0.0, _0023_003DzopRx0_MBcTQs._rebuildTol);
		}
	}

	private static class _0023_003DzQm9ltrs_003D
	{
		public static Surface._0023_003DzTF2CM_00241RVKHwMbTM3A_003D_003D _0023_003Dzr_BLArVJNG777MDnagsd307FXwWh0SxzlQ_003D_003D;
	}

	private sealed class _0023_003DzR1M0JjuLm2wkLBjgh__3KF0_003D
	{
		public double _0023_003Dz6pajdGM_003D;

		public Vector3D _0023_003DzxuJqjrs_003D;

		public Point3D _0023_003DzbUvT9Pc_003D;

		internal Brep _0023_003DzNrVDzc_aaXzvnFKiMBP5140_003D(Region _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.RevolveAsBrep(0.0, _0023_003Dz6pajdGM_003D, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D);
		}
	}

	private sealed class _0023_003DzUe1S_0024HWFwkFH2Y4ijk5JkyU_003D
	{
		public Interval _0023_003DzYNjcavt9guh2;

		public Brep _0023_003DzopRx0_MBcTQs;

		internal Brep _0023_003DzFLW5ZaGz6fHDhwojVqI2LJs_003D(Region _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.ExtrudeAsBrep(_0023_003DzYNjcavt9guh2, 0.0, _0023_003DzopRx0_MBcTQs._rebuildTol);
		}
	}

	private sealed class _0023_003DzVM06RfdVk4wS76LngJFWhCU_003D
	{
		public Tuple<int, int> _0023_003DzDVfrOi0_003D;

		internal bool _0023_003Dz6mk7xh5R_oukWJ6ZUe0AeXrGK1kwg2nDTQ_003D_003D(Tuple<int, int> _0023_003DzNDQ_E88_003D)
		{
			if (_0023_003DzNDQ_E88_003D.Item1 == _0023_003DzDVfrOi0_003D.Item1)
			{
				return _0023_003DzNDQ_E88_003D.Item2 == _0023_003DzDVfrOi0_003D.Item2;
			}
			return false;
		}
	}

	private sealed class _0023_003DzWHliiEg4_0024SUfoPqIJXt3ClA_003D
	{
		public Brep _0023_003DzopRx0_MBcTQs;

		public int _0023_003DzyzK8swU_003D;

		public double _0023_003Dzm0CYiiE_003D;

		internal bool _0023_003DzrIEiVv9b2y8KcdK_mw_003D_003D(Point3D _0023_003DzkEYxO1SuR1Kw)
		{
			return Point3D.Distance(_0023_003DzkEYxO1SuR1Kw, _0023_003DzopRx0_MBcTQs.Vertices[_0023_003DzyzK8swU_003D]) < _0023_003Dzm0CYiiE_003D;
		}
	}

	private sealed class _0023_003DzYWh1m3jkC1VdKrr1j2zjFyI_003D
	{
		public double _0023_003Dz3veEI49c6b6Q;

		public double _0023_003DzFINJ6s3Z_0024n8G;

		public Vector3D _0023_003DzxuJqjrs_003D;

		public Point3D _0023_003DzbUvT9Pc_003D;

		public Brep _0023_003DzopRx0_MBcTQs;

		internal Brep _0023_003DzppdwzV1WlOIza1L6gdCNVhU_003D(Region _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.RevolveAsBrep(_0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzopRx0_MBcTQs._rebuildTol);
		}
	}

	private sealed class _0023_003Dz_9guY0O3vt0UEyykOm8q_t4_003D
	{
		public double _0023_003Dz3veEI49c6b6Q;

		public double _0023_003DzFINJ6s3Z_0024n8G;

		public Vector3D _0023_003DzxuJqjrs_003D;

		public Point3D _0023_003DzbUvT9Pc_003D;

		internal Brep _0023_003DzNrVDzc_aaXzvnFKiMBP5140_003D(Region _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.RevolveAsBrep(_0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D);
		}
	}

	private sealed class _0023_003Dz_OwNHlEru5e5qlpoNSmOxEk_003D
	{
		public Interval _0023_003DzJh6qrM9vQQk7;

		public Vector3D _0023_003DzxuJqjrs_003D;

		public Point3D _0023_003DzbUvT9Pc_003D;

		internal Brep _0023_003DzNrVDzc_aaXzvnFKiMBP5140_003D(Region _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.RevolveAsBrep(_0023_003DzJh6qrM9vQQk7, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D);
		}
	}

	private sealed class _0023_003DzaqHY_0024QDeja_zGESwjHTKLAY_003D
	{
		public int _0023_003DzL8NvYU0_003D;

		public Predicate<int> _0023_003DzkqbsCVPMJ_0024g6;

		public Predicate<int> _0023_003DzJjT3dOU3oUsg;

		internal bool _0023_003Dzkf59rM_0024UIxqX_54peg8Qrrs_003D(int _0023_003DzyzK8swU_003D)
		{
			return _0023_003DzyzK8swU_003D == _0023_003DzL8NvYU0_003D;
		}

		internal bool _0023_003Dz4LepviJiCO3K6Aj4ORRxMHE_003D(int _0023_003DzyzK8swU_003D)
		{
			return _0023_003DzyzK8swU_003D == _0023_003DzL8NvYU0_003D;
		}
	}

	private sealed class _0023_003Dzb1l_0024mcPKROAtwjGD_N6o9S0_003D
	{
		public ICurve _0023_003DzHgrHIfhYCh4p;

		public Brep _0023_003DzopRx0_MBcTQs;

		public sweepMethodType _0023_003Dzjy_YX_0024o_003D;

		internal Brep _0023_003Dzu3rGnZ_TtjfFiDgNmw_003D_003D(Region _0023_003DzFDwqpgU_003D)
		{
			return _0023_003DzFDwqpgU_003D.SweepAsBrep(_0023_003DzHgrHIfhYCh4p, _0023_003DzopRx0_MBcTQs._rebuildTol, _0023_003Dzjy_YX_0024o_003D);
		}
	}

	private sealed class _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D
	{
		public KeyValuePair<_0023_003DzeelgtjiMbn2Y, List<Point3D>>[] _0023_003DzNvDDVNp873gn;

		public List<ICurve>[] _0023_003DzpIZC_0024x5EiUBN;

		public List<ICurve>[] _0023_003DzTQ633Sx2Bn0U;

		public List<ICurve>[] _0023_003Dz5zXjpPFtftSB;

		public Surface._0023_003Dz2u_3iw7LP_ic[][][] _0023_003DzWf9pzKFDPeOw;

		public Surface._0023_003Dz2u_3iw7LP_ic[][][] _0023_003Dzg1mu9hOJIYwq;

		public Brep _0023_003DzqjniGGF9kvbc;

		public Brep _0023_003Dzk0sekCclUGst;

		public List<ICurve> _0023_003DzXs1mtPVIqhDmHRZf5w_003D_003D;

		public List<ICurve> _0023_003DzlYYjrfi3jLJrzpfbnA_003D_003D;

		public bool[] _0023_003DzgOYrZnL6wa7aFe5_0024raoLgQk_003D;

		public Vector3D _0023_003DzPsHFxZf6VuL6;

		public double _0023_003Dzm0CYiiE_003D;

		internal void _0023_003DzAkDiNFEnv7NT2tDpGSV4W92W5tjn(int _0023_003DzHDyvLPM_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			KeyValuePair<_0023_003DzeelgtjiMbn2Y, List<Point3D>> keyValuePair = _0023_003DzNvDDVNp873gn[_0023_003DzHDyvLPM_003D];
			_0023_003DzeelgtjiMbn2Y key = keyValuePair.Key;
			List<Point3D> value = keyValuePair.Value;
			_0023_003DzpIZC_0024x5EiUBN[_0023_003DzHDyvLPM_003D] = new List<ICurve>();
			_0023_003DzTQ633Sx2Bn0U[_0023_003DzHDyvLPM_003D] = new List<ICurve>();
			_0023_003Dz5zXjpPFtftSB[_0023_003DzHDyvLPM_003D] = new List<ICurve>();
			if (value.Count <= 0)
			{
				return;
			}
			Surface _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D = _0023_003DzWf9pzKFDPeOw[key._0023_003DzTGRzgYPVC4qM._0023_003DzBLJ2fdI_003D][key._0023_003DzTGRzgYPVC4qM._0023_003DzLJVtPYc_003D][key._0023_003DzTGRzgYPVC4qM._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
			Surface _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2 = _0023_003Dzg1mu9hOJIYwq[key._0023_003DzDb0c2BCwQPLH._0023_003DzBLJ2fdI_003D][key._0023_003DzDb0c2BCwQPLH._0023_003DzLJVtPYc_003D][key._0023_003DzDb0c2BCwQPLH._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
			Face face = ((key._0023_003DzTGRzgYPVC4qM._0023_003DzBLJ2fdI_003D == 0) ? _0023_003DzqjniGGF9kvbc._faces[key._0023_003DzTGRzgYPVC4qM._0023_003DzLJVtPYc_003D] : _0023_003DzqjniGGF9kvbc._inners[key._0023_003DzTGRzgYPVC4qM._0023_003DzBLJ2fdI_003D - 1][key._0023_003DzTGRzgYPVC4qM._0023_003DzLJVtPYc_003D]);
			Face face2 = ((key._0023_003DzDb0c2BCwQPLH._0023_003DzBLJ2fdI_003D == 0) ? _0023_003Dzk0sekCclUGst._faces[key._0023_003DzDb0c2BCwQPLH._0023_003DzLJVtPYc_003D] : _0023_003Dzk0sekCclUGst._inners[key._0023_003DzDb0c2BCwQPLH._0023_003DzBLJ2fdI_003D - 1][key._0023_003DzDb0c2BCwQPLH._0023_003DzLJVtPYc_003D]);
			_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.ControlBoundingBox(out var min, out var max);
			_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2.ControlBoundingBox(out var min2, out var max2);
			Point3D intersMin;
			Point3D intersMax;
			double diagonal = Utility.IntersectionBox(min, max, min2, max2, out intersMin, out intersMax).Diagonal;
			List<ICurve> list = new List<ICurve>();
			List<ICurve> list2 = new List<ICurve>();
			for (int i = 0; i < _0023_003DzXs1mtPVIqhDmHRZf5w_003D_003D.Count; i++)
			{
				ICurve curve = _0023_003DzXs1mtPVIqhDmHRZf5w_003D_003D[i];
				_0023_003DzKfMGQQU_003D _0023_003DzKfMGQQU_003D2 = key._0023_003DzTGRzgYPVC4qM;
				if (!((TrimCurve)curve).fromTangentEdgeParent)
				{
					curve = _0023_003DzlYYjrfi3jLJrzpfbnA_003D_003D[i];
					_0023_003DzKfMGQQU_003D2 = key._0023_003DzDb0c2BCwQPLH;
				}
				TrimCurve trimCurve = (TrimCurve)curve.Clone();
				if (trimCurve.FaceInfo._0023_003DzBLJ2fdI_003D != _0023_003DzKfMGQQU_003D2._0023_003DzBLJ2fdI_003D || trimCurve.FaceInfo._0023_003DzLJVtPYc_003D != _0023_003DzKfMGQQU_003D2._0023_003DzLJVtPYc_003D || trimCurve.FaceInfo._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D != _0023_003DzKfMGQQU_003D2._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D)
				{
					continue;
				}
				for (int j = 0; j < value.Count; j++)
				{
					InitialPoint initialPoint = (InitialPoint)value[j];
					trimCurve.Edge.ClosestPointTo(initialPoint, out var t);
					Vector3D vector3D = trimCurve.Edge.TangentAt(t);
					vector3D.Normalize();
					Vector3D vector3D2 = (Vector3D)initialPoint.Tangent.Clone();
					vector3D2.Normalize();
					if (initialPoint.DistanceTo(trimCurve.Edge.PointAt(t)) < diagonal * 1E-07 && Vector3D.AreParallel(vector3D, vector3D2, 0.001))
					{
						initialPoint._0023_003Dz4sg0Qp0_003D = true;
					}
				}
			}
			_0023_003DzgOYrZnL6wa7aFe5_0024raoLgQk_003D[_0023_003DzHDyvLPM_003D] = Surface._0023_003Dz5OI_0024k3MjS0hN3_0024YhCQ_003D_003D(value.ToArray(), _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, _0023_003DzPsHFxZf6VuL6, diagonal, _0023_003Dzm0CYiiE_003D, list, list2, _0023_003Dz0ZT3gEddQ5QD: false, 0.0, 0.0, null, (Surface._0023_003Dz_FJVTa8aqhc_0024)0, out var _, out var _);
			for (int k = 0; k < list.Count; k++)
			{
				ICurve curve2 = (ICurve)((TrimCurve)list[k]).Edge.Clone();
				((Entity)curve2).EntityData = new Tuple<int, int>(_0023_003DzNvDDVNp873gn[_0023_003DzHDyvLPM_003D].Key._0023_003DzTGRzgYPVC4qM._0023_003DzLJVtPYc_003D, _0023_003DzNvDDVNp873gn[_0023_003DzHDyvLPM_003D].Key._0023_003DzDb0c2BCwQPLH._0023_003DzLJVtPYc_003D);
				_0023_003DzpIZC_0024x5EiUBN[_0023_003DzHDyvLPM_003D].Add(curve2);
				InitialPoint startIp = ((TrimCurve)list[k]).startIp;
				InitialPoint endIp = ((TrimCurve)list[k]).endIp;
				if (startIp._0023_003Dz9UfD_00243UN4YK9Dk_Q_0024A_003D_003D && endIp._0023_003Dz9UfD_00243UN4YK9Dk_Q_0024A_003D_003D)
				{
					Face.tangentType tangentType = Face.tangentType.none;
					bool _0023_003DzKgWCaV5RTv9VxFld_g_003D_003D;
					if (face.tangentFacesIndices != null)
					{
						for (int l = 0; l < face.tangentFacesIndices.Count; l++)
						{
							int num = face.tangentFacesIndices[l];
							ICurve[] array = _0023_003Dzg1mu9hOJIYwq[0][num][0]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.ExtractEdges();
							foreach (ICurve _0023_003Dz_0024ozI2Ww_003D in array)
							{
								if (Utility._0023_003DzZCuAc1AnKVueDa_Q8w_003D_003D(((TrimCurve)list[k]).Edge, _0023_003Dz_0024ozI2Ww_003D, out _0023_003DzKgWCaV5RTv9VxFld_g_003D_003D, 1.0) >= 0)
								{
									((TrimCurve)list[k]).onTangentType = face.tangentFacesType[l];
									tangentType = face.tangentFacesType[l];
									((TrimCurve)list[k]).onTangentFaces = new int[2]
									{
										key._0023_003DzTGRzgYPVC4qM._0023_003DzLJVtPYc_003D,
										num
									};
									break;
								}
							}
							if (tangentType != Face.tangentType.none)
							{
								break;
							}
						}
					}
					if (tangentType == Face.tangentType.none && face2.tangentFacesIndices != null)
					{
						for (int n = 0; n < face2.tangentFacesIndices.Count; n++)
						{
							int num2 = face2.tangentFacesIndices[n];
							ICurve[] array = _0023_003DzWf9pzKFDPeOw[0][num2][0]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.ExtractEdges();
							foreach (ICurve _0023_003Dz_0024ozI2Ww_003D2 in array)
							{
								if (Utility._0023_003DzZCuAc1AnKVueDa_Q8w_003D_003D(((TrimCurve)list2[k]).Edge, _0023_003Dz_0024ozI2Ww_003D2, out _0023_003DzKgWCaV5RTv9VxFld_g_003D_003D, 1.0) >= 0)
								{
									((TrimCurve)list2[k]).onTangentType = face2.tangentFacesType[n];
									((TrimCurve)list2[k]).onTangentFaces = new int[2]
									{
										num2,
										key._0023_003DzDb0c2BCwQPLH._0023_003DzLJVtPYc_003D
									};
									tangentType = face2.tangentFacesType[n];
									break;
								}
							}
							if (tangentType != Face.tangentType.none)
							{
								break;
							}
						}
					}
					if (tangentType != Face.tangentType.none)
					{
						((Curve)_0023_003DzpIZC_0024x5EiUBN[_0023_003DzHDyvLPM_003D][_0023_003DzpIZC_0024x5EiUBN[_0023_003DzHDyvLPM_003D].Count - 1]).onTangentType = tangentType;
						((Curve)_0023_003DzpIZC_0024x5EiUBN[_0023_003DzHDyvLPM_003D][_0023_003DzpIZC_0024x5EiUBN[_0023_003DzHDyvLPM_003D].Count - 1]).onTangentFaces = ((TrimCurve)list2[k]).onTangentFaces ?? ((TrimCurve)list[k]).onTangentFaces;
					}
				}
				((TrimCurve)list[k]).FaceInfo = key._0023_003DzTGRzgYPVC4qM;
				((TrimCurve)list2[k]).FaceInfo = key._0023_003DzDb0c2BCwQPLH;
				_0023_003DzTQ633Sx2Bn0U[_0023_003DzHDyvLPM_003D].Add(list[k]);
				_0023_003Dz5zXjpPFtftSB[_0023_003DzHDyvLPM_003D].Add(list2[k]);
			}
		}
	}

	internal struct _0023_003DzeelgtjiMbn2Y(_0023_003DzKfMGQQU_003D _0023_003DzwXmQEC4_003D, _0023_003DzKfMGQQU_003D _0023_003DzAaoZ6Qk_003D)
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal _0023_003DzKfMGQQU_003D _0023_003DzTGRzgYPVC4qM = _0023_003DzwXmQEC4_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal _0023_003DzKfMGQQU_003D _0023_003DzDb0c2BCwQPLH = _0023_003DzAaoZ6Qk_003D;

		public bool _0023_003Dza0ku3fI_003D(_0023_003DzeelgtjiMbn2Y _0023_003Dzl_0024MIsC0_003D)
		{
			if (_0023_003DzTGRzgYPVC4qM.Equals(_0023_003Dzl_0024MIsC0_003D._0023_003DzTGRzgYPVC4qM))
			{
				return _0023_003DzDb0c2BCwQPLH.Equals(_0023_003Dzl_0024MIsC0_003D._0023_003DzDb0c2BCwQPLH);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (_0023_003DzTGRzgYPVC4qM.GetHashCode() * 397) ^ _0023_003DzDb0c2BCwQPLH.GetHashCode();
		}

		public override bool Equals(object _0023_003DzCX9Hbao_003D)
		{
			if (_0023_003DzCX9Hbao_003D == null)
			{
				return false;
			}
			if (_0023_003DzCX9Hbao_003D is _0023_003DzeelgtjiMbn2Y)
			{
				return _0023_003Dza0ku3fI_003D((_0023_003DzeelgtjiMbn2Y)_0023_003DzCX9Hbao_003D);
			}
			return false;
		}
	}

	private sealed class _0023_003DzetoHQs8u7csjtSYmLRke840_003D
	{
		public Edge _0023_003Dz9yOCzf0_003D;

		internal bool _0023_003DzYabVoCkgaVOTjAOHa86_hnvuCUgt(Edge _0023_003DzTx2aqr8_003D)
		{
			if (_0023_003DzTx2aqr8_003D.StartPointIndex != _0023_003Dz9yOCzf0_003D.StartPointIndex || _0023_003DzTx2aqr8_003D.EndPointIndex != _0023_003Dz9yOCzf0_003D.EndPointIndex)
			{
				if (_0023_003DzTx2aqr8_003D.StartPointIndex == _0023_003Dz9yOCzf0_003D.EndPointIndex)
				{
					return _0023_003DzTx2aqr8_003D.EndPointIndex == _0023_003Dz9yOCzf0_003D.StartPointIndex;
				}
				return false;
			}
			return true;
		}
	}

	private sealed class _0023_003DzfPLa4vQ_0024dOEb_Vf7VTSIqoc_003D
	{
		public ICurve _0023_003DzHgrHIfhYCh4p;

		public Brep _0023_003DzopRx0_MBcTQs;

		public sweepMethodType _0023_003Dzjy_YX_0024o_003D;

		internal Brep _0023_003DzCxtESBJgnxorvJ0sXQ_003D_003D(Region _0023_003DzFDwqpgU_003D)
		{
			return _0023_003DzFDwqpgU_003D.SweepAsBrep(_0023_003DzHgrHIfhYCh4p, _0023_003DzopRx0_MBcTQs._rebuildTol, _0023_003Dzjy_YX_0024o_003D);
		}
	}

	private sealed class _0023_003DzgSMWbzn8QRdeH45pLIHu_WU_003D
	{
		public double _0023_003Dz3veEI49c6b6Q;

		public double _0023_003DzFINJ6s3Z_0024n8G;

		public Vector3D _0023_003DzxuJqjrs_003D;

		public Point3D _0023_003DzbUvT9Pc_003D;

		public Brep _0023_003DzopRx0_MBcTQs;

		internal Brep _0023_003Dz1mGf45_HNb7F2_0024SKq2eywcY_003D(Region _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.RevolveAsBrep(_0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzopRx0_MBcTQs._rebuildTol);
		}
	}

	private delegate bool _0023_003DzhSGg_0024oKL6aEYn9EjCQ_003D_003D(Face _0023_003DzHEpjcdg2hk9U);

	private sealed class _0023_003Dziqg6bP_WKWBFTUiOdzXzVpQ_003D
	{
		public Interval _0023_003DzJh6qrM9vQQk7;

		public Vector3D _0023_003DzxuJqjrs_003D;

		public Point3D _0023_003DzbUvT9Pc_003D;

		public Brep _0023_003DzopRx0_MBcTQs;

		internal Brep _0023_003Dz1mGf45_HNb7F2_0024SKq2eywcY_003D(Region _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.RevolveAsBrep(_0023_003DzJh6qrM9vQQk7, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzopRx0_MBcTQs._rebuildTol);
		}
	}

	private sealed class _0023_003Dzk3LI7qGozxcdguRRMifTlx0_003D
	{
		public FrustumParams _0023_003DzELu0Pss_003D;

		internal bool _0023_003DzAIgslkgO3MG3jEfTN3tmG3fOFvN6WcT0ShB7pK4_003D(Face _0023_003DzhidJeNw_003D)
		{
			return _0023_003DzhidJeNw_003D.Tessellation.AllVerticesInFrustum(_0023_003DzELu0Pss_003D);
		}
	}

	private sealed class _0023_003DzoB_vXtS6zNDiyz4rZJZZHg4_003D
	{
		public List<Face> _0023_003DzEtn4dIEPKCsi;

		public Brep _0023_003DzopRx0_MBcTQs;

		public double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D;

		internal void _0023_003Dzn4ba9qUPJc4sXxQe0CysxEu4Cs8Crmx1kA_003D_003D(int _0023_003Dz437_00244ak_003D)
		{
			Face face = _0023_003DzEtn4dIEPKCsi[_0023_003Dz437_00244ak_003D];
			ICurve[] orientedTrimLoops = face.GetOrientedTrimLoops(_0023_003DzopRx0_MBcTQs._edges);
			Surface notRotated;
			Surface untrimmed = face.Surface.GetUntrimmed(orientedTrimLoops, face.Sense, out notRotated);
			face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(Surface._0023_003DzNxaR6FzQJCTX(untrimmed, orientedTrimLoops, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, 0.0, null, null));
			if (notRotated != null && _0023_003Dz909r3pkb63XgiBkYZQ_003D_003D(face.Parametric, untrimmed, notRotated, orientedTrimLoops))
			{
				face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(Surface._0023_003DzNxaR6FzQJCTX(notRotated, orientedTrimLoops, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, 0.0, null, null));
			}
			face.needRebuild = false;
		}
	}

	private sealed class _0023_003DzpITx87t3SC_0024wDJ_0024GkoKQQos_003D
	{
		public Tuple<int, int> _0023_003DzDVfrOi0_003D;

		internal bool _0023_003DzXZdr3k8wDi_0024_0024MTaZcqDC7Y8IEh2rre6NYg_003D_003D(Tuple<int, int> _0023_003DzNDQ_E88_003D)
		{
			if (_0023_003DzNDQ_E88_003D.Item1 == _0023_003DzDVfrOi0_003D.Item1)
			{
				return _0023_003DzNDQ_E88_003D.Item2 == _0023_003DzDVfrOi0_003D.Item2;
			}
			return false;
		}
	}

	private sealed class _0023_003Dzq05F0TOsYEIyvZGPMwuwPO4_003D
	{
		public ScreenPolygonParams _0023_003DzELu0Pss_003D;

		internal bool _0023_003Dzwql_00241pm2ANwHJBB046AN9K3jbALQkL2cgQ_003D_003D(Face _0023_003DzhidJeNw_003D)
		{
			return _0023_003DzhidJeNw_003D.Tessellation.AllVerticesInScreenPolygon(_0023_003DzELu0Pss_003D);
		}
	}

	private sealed class _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D
	{
		public double _0023_003DzYNjcavt9guh2;

		public double _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D;

		public Brep _0023_003DzopRx0_MBcTQs;

		internal Brep _0023_003DzSq8J_Vp_VjkEDtZ7aR5xBWU_003D(Region _0023_003DzFDwqpgU_003D)
		{
			return _0023_003DzFDwqpgU_003D.ExtrudeAsBrep(_0023_003DzYNjcavt9guh2, _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, _0023_003DzopRx0_MBcTQs._rebuildTol);
		}
	}

	private sealed class _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D
	{
		public double _0023_003DzYNjcavt9guh2;

		public Brep _0023_003DzopRx0_MBcTQs;

		internal Brep _0023_003DzSq8J_Vp_VjkEDtZ7aR5xBWU_003D(Region _0023_003DzFDwqpgU_003D)
		{
			return _0023_003DzFDwqpgU_003D.ExtrudeAsBrep(_0023_003DzYNjcavt9guh2, 0.0, _0023_003DzopRx0_MBcTQs._rebuildTol);
		}
	}

	private sealed class _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D
	{
		public KeyValuePair<_0023_003DzKfMGQQU_003D, List<Point3D>>[] _0023_003DziytJKSvyswPuISGO_0024Q_003D_003D;

		public Surface._0023_003Dz2u_3iw7LP_ic[][][] _0023_003DzIO8vCOqMZAPN;

		public Point3D _0023_003DzCFK21E0_003D;

		public Point3D _0023_003DzewZCcZQ_003D;

		public List<ICurve> _0023_003DzXs1mtPVIqhDmHRZf5w_003D_003D;

		public Surface _0023_003DzFmiij5k_003D;

		public Vector3D _0023_003DzPsHFxZf6VuL6;

		public Brep _0023_003DzopRx0_MBcTQs;

		public List<ICurve>[] _0023_003DzK2kANxBH211q;

		public List<ICurve>[] _0023_003DzVixMwhaCnCpx;

		public List<ICurve>[] _0023_003DzpIZC_0024x5EiUBN;

		internal void _0023_003Dzg2iOjsrja8Xs8nhaYw_003D_003D(int _0023_003DzHDyvLPM_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			KeyValuePair<_0023_003DzKfMGQQU_003D, List<Point3D>> keyValuePair = _0023_003DziytJKSvyswPuISGO_0024Q_003D_003D[_0023_003DzHDyvLPM_003D];
			List<Point3D> value = keyValuePair.Value;
			_0023_003DzKfMGQQU_003D key = keyValuePair.Key;
			Surface _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D = _0023_003DzIO8vCOqMZAPN[key._0023_003DzBLJ2fdI_003D][key._0023_003DzLJVtPYc_003D][key._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
			if (value.Count <= 1)
			{
				return;
			}
			_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.ControlBoundingBox(out var min, out var max);
			Utility.IntersectionBox(min, max, _0023_003DzCFK21E0_003D, _0023_003DzewZCcZQ_003D, out var intersMin, out var intersMax);
			double diagonal = new Size3D(intersMin, intersMax).Diagonal;
			for (int i = 0; i < _0023_003DzXs1mtPVIqhDmHRZf5w_003D_003D.Count; i++)
			{
				TrimCurve trimCurve = (TrimCurve)_0023_003DzXs1mtPVIqhDmHRZf5w_003D_003D[i].Clone();
				if (trimCurve.FaceInfo._0023_003DzBLJ2fdI_003D != key._0023_003DzBLJ2fdI_003D || trimCurve.FaceInfo._0023_003DzLJVtPYc_003D != key._0023_003DzLJVtPYc_003D || trimCurve.FaceInfo._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D != key._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D)
				{
					continue;
				}
				for (int j = 0; j < value.Count; j++)
				{
					InitialPoint initialPoint = (InitialPoint)value[j];
					trimCurve.Edge.ClosestPointTo(initialPoint, out var t);
					Vector3D vector3D = trimCurve.Edge.TangentAt(t);
					vector3D.Normalize();
					Vector3D vector3D2 = (Vector3D)initialPoint.Tangent.Clone();
					vector3D2.Normalize();
					if (initialPoint.DistanceTo(trimCurve.Edge.PointAt(t)) < diagonal * 1E-07 && Vector3D.AreParallel(vector3D, vector3D2, 0.001))
					{
						initialPoint._0023_003Dz4sg0Qp0_003D = true;
					}
				}
			}
			Surface._0023_003Dz5OI_0024k3MjS0hN3_0024YhCQ_003D_003D(value.ToArray(), _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzFmiij5k_003D, _0023_003DzPsHFxZf6VuL6, diagonal, _0023_003DzopRx0_MBcTQs._rebuildTol, _0023_003DzK2kANxBH211q[_0023_003DzHDyvLPM_003D], _0023_003DzVixMwhaCnCpx[_0023_003DzHDyvLPM_003D], _0023_003Dz0ZT3gEddQ5QD: false, 0.0, 0.0, null, (Surface._0023_003Dz_FJVTa8aqhc_0024)0, out var _, out var _);
			for (int k = 0; k < _0023_003DzK2kANxBH211q[_0023_003DzHDyvLPM_003D].Count; k++)
			{
				Curve item = (Curve)(Entity)((TrimCurve)_0023_003DzK2kANxBH211q[_0023_003DzHDyvLPM_003D][k]).Edge;
				((TrimCurve)_0023_003DzK2kANxBH211q[_0023_003DzHDyvLPM_003D][k]).FaceInfo = key;
				_0023_003DzpIZC_0024x5EiUBN[_0023_003DzHDyvLPM_003D].Add(item);
				InitialPoint startIp = ((TrimCurve)_0023_003DzK2kANxBH211q[_0023_003DzHDyvLPM_003D][k]).startIp;
				InitialPoint endIp = ((TrimCurve)_0023_003DzK2kANxBH211q[_0023_003DzHDyvLPM_003D][k]).endIp;
				if (!startIp._0023_003Dz9UfD_00243UN4YK9Dk_Q_0024A_003D_003D || !endIp._0023_003Dz9UfD_00243UN4YK9Dk_Q_0024A_003D_003D)
				{
					continue;
				}
				Face face = ((key._0023_003DzBLJ2fdI_003D == 0) ? _0023_003DzopRx0_MBcTQs._faces[key._0023_003DzLJVtPYc_003D] : _0023_003DzopRx0_MBcTQs._inners[key._0023_003DzBLJ2fdI_003D - 1][key._0023_003DzLJVtPYc_003D]);
				((TrimCurve)_0023_003DzVixMwhaCnCpx[_0023_003DzHDyvLPM_003D][k]).onTangentType = Face.tangentType.coplanar;
				bool flag = false;
				for (int l = 0; l < face.Loops.Length; l++)
				{
					for (int m = 0; m < face.Loops[l].Segments.Length; m++)
					{
						OrientedEdge orientedEdge = face.Loops[l].Segments[m];
						Edge edge = _0023_003DzopRx0_MBcTQs._edges[orientedEdge.CurveIndex];
						for (int n = 0; n < edge.Parents.Length; n++)
						{
							if (edge.Parents[n] != key._0023_003DzLJVtPYc_003D)
							{
								Face face2 = ((key._0023_003DzBLJ2fdI_003D == 0) ? _0023_003DzopRx0_MBcTQs._faces[edge.Parents[n]] : _0023_003DzopRx0_MBcTQs._inners[key._0023_003DzBLJ2fdI_003D - 1][edge.Parents[n]]);
								if (face2.tangentFacesType != null && (face2.tangentFacesType[0] == Face.tangentType.coplanarOpposite || face2.tangentFacesType[0] == Face.tangentType.coincidentOpposite))
								{
									flag = true;
									((TrimCurve)_0023_003DzVixMwhaCnCpx[_0023_003DzHDyvLPM_003D][k]).onTangentType = face2.tangentFacesType[0];
									break;
								}
							}
						}
						if (flag)
						{
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
				((Curve)_0023_003DzpIZC_0024x5EiUBN[_0023_003DzHDyvLPM_003D][_0023_003DzpIZC_0024x5EiUBN[_0023_003DzHDyvLPM_003D].Count - 1]).onTangentType = ((TrimCurve)_0023_003DzVixMwhaCnCpx[_0023_003DzHDyvLPM_003D][k]).onTangentType;
				((Curve)_0023_003DzpIZC_0024x5EiUBN[_0023_003DzHDyvLPM_003D][_0023_003DzpIZC_0024x5EiUBN[_0023_003DzHDyvLPM_003D].Count - 1]).onTangentFaces = ((TrimCurve)_0023_003DzVixMwhaCnCpx[_0023_003DzHDyvLPM_003D][k]).onTangentFaces;
			}
		}
	}

	[Serializable]
	public class Edge : ISerializable, ICloneable, IMateable
	{
		public int StartPointIndex;

		public int EndPointIndex;

		public ICurve Curve;

		public int ShellIndex;

		public int[] Parents;

		internal bool Visited;

		internal SplitEdgeStatus SplitStatus;

		public TranslationIdentifier TranslationID { get; set; }

		public object EdgeData { get; set; }

		public Edge(ICurve curve, int startPointIndex, int endPointIndex)
		{
			Curve = curve;
			StartPointIndex = startPointIndex;
			EndPointIndex = endPointIndex;
			Visited = false;
		}

		protected Edge(Edge another, bool keepTessellation = false)
		{
			Curve = (ICurve)(keepTessellation ? ((Entity)another.Curve).CloneWithTessellation() : another.Curve.Clone());
			StartPointIndex = another.StartPointIndex;
			EndPointIndex = another.EndPointIndex;
			ShellIndex = another.ShellIndex;
			Visited = false;
			if (another.Parents != null)
			{
				int num = another.Parents.Length;
				Parents = new int[num];
				Array.Copy(another.Parents, Parents, num);
			}
			if (another.EdgeData is ICloneable cloneable)
			{
				EdgeData = cloneable.Clone();
			}
			else if (another.EdgeData is ValueType)
			{
				EdgeData = another.EdgeData;
			}
		}

		protected internal Edge(BrepEdgeSurrogate surrogate)
			: this((ICurve)surrogate.GetCurve(), surrogate.StartPointIndex, surrogate.EndPointIndex)
		{
		}

		public Edge(SerializationInfo info, StreamingContext ctxt)
		{
			StartPointIndex = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957128));
			EndPointIndex = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957120));
			Curve = (ICurve)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957078), typeof(ICurve));
			ShellIndex = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957058));
			Parents = (int[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957300), typeof(int[]));
			EdgeData = info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957282), typeof(object));
		}

		public virtual object Clone()
		{
			return new Edge(this);
		}

		public virtual object CloneWithTessellation()
		{
			return new Edge(this, keepTessellation: true);
		}

		public bool IsTangentAt(double t, Face[] faces)
		{
			return _0023_003DzBoG8A9MoyXqm(faces, this, t);
		}

		public bool IsTangent(Face[] faces)
		{
			return _0023_003DzBoG8A9MoyXqm(faces, this, Curve.Domain.Mid);
		}

		public override string ToString()
		{
			string text = Curve.GetType().ToString().Split('.')[^1];
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957268), text, StartPointIndex, EndPointIndex, ShellIndex, Parents.Length);
		}

		public string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, MaterialKeyedCollection materials = null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(((Entity)Curve).Dump(linearUnits));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
			stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957198), StartPointIndex, EndPointIndex));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957929) + ShellIndex);
			if (Parents.Length > 1)
			{
				stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957917) + Parents[0]);
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108) + Parents[1]);
			}
			else
			{
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957917) + Parents[0]);
			}
			if (EdgeData != null)
			{
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957876) + EdgeData.ToString());
			}
			if (TranslationID != null)
			{
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957859) + TranslationID);
			}
			return stringBuilder.ToString();
		}

		public virtual BrepEdgeSurrogate ConvertToSurrogate()
		{
			return new BrepEdgeSurrogate(this);
		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957128), StartPointIndex);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957120), EndPointIndex);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957078), Curve);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957058), ShellIndex);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957300), Parents);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957282), EdgeData);
		}

		internal bool _0023_003Dz1f9A6PoNLtVGII_0024I6g_003D_003D(Face[] _0023_003DzpPOEJqcAh7Lr, out bool _0023_003DzMZraMbGvi3oMygJvBw_003D_003D, Face[][] _0023_003DzWaFlkhfmYCja)
		{
			_0023_003DzMZraMbGvi3oMygJvBw_003D_003D = true;
			if (Parents.Length <= 1 || Parents.Length > 2)
			{
				return false;
			}
			int num = Parents[0];
			int num2 = Parents[1];
			Face face = ((ShellIndex == 0) ? _0023_003DzpPOEJqcAh7Lr[num] : _0023_003DzWaFlkhfmYCja[ShellIndex - 1][num]);
			Face face2 = ((ShellIndex == 0) ? _0023_003DzpPOEJqcAh7Lr[num2] : _0023_003DzWaFlkhfmYCja[ShellIndex - 1][num2]);
			if (face == null || face2 == null)
			{
				return true;
			}
			if (num == num2)
			{
				if (typeof(PlanarSurf) == face.Surface.GetType())
				{
					face.IsPlanar();
					return true;
				}
				return false;
			}
			if (_0023_003DzN9x2DCq6gdeTJJw0n0PtVPU_003D(_0023_003DzpPOEJqcAh7Lr, _0023_003DzWaFlkhfmYCja))
			{
				return true;
			}
			if (face.Surface.GetType() == face2.Surface.GetType())
			{
				Type type = face.Surface.GetType();
				if (type == typeof(ToroidalSurf))
				{
					_0023_003DzMZraMbGvi3oMygJvBw_003D_003D = false;
					ToroidalSurf toroidalSurf = (ToroidalSurf)face.Surface;
					ToroidalSurf toroidalSurf2 = (ToroidalSurf)face2.Surface;
					Vector3D vector3D = new Vector3D(toroidalSurf.Plane.Origin, toroidalSurf2.Plane.Origin);
					vector3D.Normalize();
					if (Math.Abs(toroidalSurf.MinorRadius - toroidalSurf2.MinorRadius) < 1E-12 && Math.Abs(toroidalSurf.MajorRadius - toroidalSurf2.MajorRadius) < 1E-12 && Vector3D.AreParallel(toroidalSurf.Plane.AxisZ, toroidalSurf2.Plane.AxisZ) && (Point3D.AreEqual(toroidalSurf.Plane.Origin, toroidalSurf2.Plane.Origin, Curve.Length()) || Vector3D.AreParallel(toroidalSurf.Plane.AxisZ, vector3D)))
					{
						return true;
					}
				}
				if (type == typeof(ConicalSurf))
				{
					_0023_003DzMZraMbGvi3oMygJvBw_003D_003D = false;
					ConicalSurf conicalSurf = (ConicalSurf)face.Surface;
					ConicalSurf conicalSurf2 = (ConicalSurf)face2.Surface;
					double num3 = (double)((Math.Sin(conicalSurf.HalfAngle) * Math.Cos(conicalSurf.HalfAngle) < 0.0) ? 1 : (-1)) * Math.Abs(conicalSurf.Radius / Math.Tan(Math.Abs(conicalSurf.HalfAngle)));
					Point3D p = conicalSurf.Plane.Origin + conicalSurf.Plane.AxisZ * num3;
					double num4 = (double)((Math.Sin(conicalSurf2.HalfAngle) * Math.Cos(conicalSurf2.HalfAngle) < 0.0) ? 1 : (-1)) * Math.Abs(conicalSurf2.Radius / Math.Tan(Math.Abs(conicalSurf2.HalfAngle)));
					Point3D p2 = conicalSurf2.Plane.Origin + conicalSurf2.Plane.AxisZ * num4;
					if (conicalSurf.Radius == conicalSurf2.Radius && conicalSurf.HalfAngle == conicalSurf.HalfAngle && Point3D.AreEqual(p, p2, Curve.Length()))
					{
						return true;
					}
				}
				if (type == typeof(SphericalSurf) || type == typeof(CylindricalSurf))
				{
					_0023_003DzMZraMbGvi3oMygJvBw_003D_003D = false;
					CylindricalSurf cylindricalSurf = (CylindricalSurf)face.Surface;
					CylindricalSurf cylindricalSurf2 = (CylindricalSurf)face2.Surface;
					Vector3D vector3D2 = new Vector3D(cylindricalSurf.Plane.Origin, cylindricalSurf2.Plane.Origin);
					vector3D2.Normalize();
					if (cylindricalSurf.Radius == cylindricalSurf2.Radius && Vector3D.AreParallel(cylindricalSurf.Plane.AxisZ, cylindricalSurf2.Plane.AxisZ) && (Point3D.AreEqual(cylindricalSurf.Plane.Origin, cylindricalSurf2.Plane.Origin, Curve.Length()) || Vector3D.AreParallel(cylindricalSurf.Plane.AxisZ, vector3D2)))
					{
						return true;
					}
				}
			}
			return false;
		}

		internal bool _0023_003DzN9x2DCq6gdeTJJw0n0PtVPU_003D(Face[] _0023_003DzpPOEJqcAh7Lr, Face[][] _0023_003DzWaFlkhfmYCja)
		{
			if (Parents.Length <= 1)
			{
				return false;
			}
			int num = Parents[0];
			int num2 = Parents[1];
			Face face = ((ShellIndex == 0) ? _0023_003DzpPOEJqcAh7Lr[num] : _0023_003DzWaFlkhfmYCja[ShellIndex - 1][num]);
			Face face2 = ((ShellIndex == 0) ? _0023_003DzpPOEJqcAh7Lr[num2] : _0023_003DzWaFlkhfmYCja[ShellIndex - 1][num2]);
			if (num == num2)
			{
				if (typeof(PlanarSurf) == face.Surface.GetType())
				{
					face.plane = ((PlanarSurface)face.Parametric[0]).Plane;
					return true;
				}
				return false;
			}
			if (face == null || face2 == null)
			{
				return true;
			}
			if (face._0023_003Dz7EOfQ_wBFahDw9Pn9w_003D_003D(face2, out var _0023_003DzzwoQwOglTJml3vqNGA_003D_003D, _0023_003Dzk_3tZjgmhGlmfKWn0g_003D_003D: false))
			{
				return _0023_003DzzwoQwOglTJml3vqNGA_003D_003D == Face.tangentType.coplanar;
			}
			return false;
		}

		internal bool _0023_003Dze7d6tSz6lfTYk5LxrA_003D_003D(int _0023_003DzaLjxqEbPtcLc, int _0023_003Dzav_0024Hg5qRN80y)
		{
			if (Parents.Length <= 1)
			{
				return false;
			}
			if (_0023_003DzaLjxqEbPtcLc != Parents[0] || _0023_003Dzav_0024Hg5qRN80y != Parents[1])
			{
				if (_0023_003DzaLjxqEbPtcLc == Parents[1])
				{
					return _0023_003Dzav_0024Hg5qRN80y == Parents[0];
				}
				return false;
			}
			return true;
		}

		internal void _0023_003DzZ5fgum2m7AI_0024(int _0023_003DzAJYZcKw_003D, int _0023_003Dze38fBl8CXMMIjCl2bg_003D_003D)
		{
			if (StartPointIndex == _0023_003DzAJYZcKw_003D)
			{
				StartPointIndex = _0023_003Dze38fBl8CXMMIjCl2bg_003D_003D;
			}
			if (EndPointIndex == _0023_003DzAJYZcKw_003D)
			{
				EndPointIndex = _0023_003Dze38fBl8CXMMIjCl2bg_003D_003D;
			}
		}

		internal void _0023_003Dz8hR_kalXOG3N(int _0023_003DzhYip7VpUCjAO, int _0023_003DzjabR4po_003D)
		{
			if (Parents == null)
			{
				return;
			}
			for (int i = 0; i < Parents.Length; i++)
			{
				if (Parents[i] == _0023_003DzhYip7VpUCjAO)
				{
					Parents[i] = _0023_003DzjabR4po_003D;
				}
			}
		}

		internal static Mesh _0023_003DzCgaa0Gau9G1_OJewpg_003D_003D(ICurve _0023_003Dz8vL_NxTP5wHa, double _0023_003DzccAR5G0_003D)
		{
			double num = _0023_003DzccAR5G0_003D * Utility._0023_003DzxhnLabVjXjPg;
			if (_0023_003Dz8vL_NxTP5wHa.IsLinear(num, out var line))
			{
				double[] dest = new double[3];
				double[] array = line.P0.ToArray();
				double[] array2 = line.P1.ToArray();
				UtilityMacros.SUB(ref dest, array2, array);
				double num2 = Math.Sqrt(dest[0] * dest[0] + dest[1] * dest[1] + dest[2] * dest[2]);
				if (num2 > 2.2250738585072014E-308)
				{
					dest[0] /= num2;
					dest[1] /= num2;
					dest[2] /= num2;
				}
				double[] array3 = new double[3]
				{
					array[0] - dest[0] * 0.001,
					array[1] - dest[1] * 0.001,
					array[2] - dest[2] * 0.001
				};
				double[] array4 = new double[3]
				{
					array2[0] + dest[0] * 0.001,
					array2[1] + dest[1] * 0.001,
					array2[2] + dest[2] * 0.001
				};
				Vector3D axisX = Vector3D.AxisX;
				axisX.PerpendicularTo(new Vector3D(dest));
				axisX.Normalize();
				double[] coords = new double[3]
				{
					array3[0] - axisX.X * 0.001,
					array3[1] - axisX.Y * 0.001,
					array3[2] - axisX.Z * 0.001
				};
				double[] coords2 = new double[3]
				{
					array3[0] + axisX.X * 0.001,
					array3[1] + axisX.Y * 0.001,
					array3[2] + axisX.Z * 0.001
				};
				double[] coords3 = new double[3]
				{
					array4[0] - axisX.X * 0.001,
					array4[1] - axisX.Y * 0.001,
					array4[2] - axisX.Z * 0.001
				};
				double[] coords4 = new double[3]
				{
					array4[0] + axisX.X * 0.001,
					array4[1] + axisX.Y * 0.001,
					array4[2] + axisX.Z * 0.001
				};
				return new Mesh(new List<Point3D>
				{
					new Point3D(coords2),
					new Point3D(coords),
					new Point3D(coords4),
					new Point3D(coords3)
				}, new List<IndexTriangle>
				{
					new IndexTriangle(0, 2, 1),
					new IndexTriangle(1, 2, 3)
				});
			}
			if (_0023_003Dz8vL_NxTP5wHa.IsPlanar(num, out var plane))
			{
				Point3D[] array5 = Utility._0023_003DzHgehaXbXsoae65o_R1WkC5o_003D(_0023_003Dz8vL_NxTP5wHa);
				Point2D[] array6 = new Point2D[array5.Length];
				Point2D point2D = plane.Project(Utility._0023_003DzbeHMzga5LfNKjFeCKg_003D_003D(array5));
				for (int i = 0; i < array6.Length; i++)
				{
					array6[i] = plane.Project(array5[i]);
					Vector2D vector2D = new Vector2D(point2D, array6[i]);
					array6[i] = point2D + vector2D * (1.0 + num);
				}
				Utility.Triangulate(Utility.ConvexHull2D(array6).Vertices, null, fixOrientation: true, checkValidity: false, out var vertices, out var triangles);
				Point3D[] array7 = new Point3D[vertices.Length];
				for (int j = 0; j < vertices.Length; j++)
				{
					array7[j] = plane.PointAt(vertices[j]);
				}
				return new Mesh(array7, triangles);
			}
			Point3D[] array8 = Utility._0023_003DzHgehaXbXsoae65o_R1WkC5o_003D(_0023_003Dz8vL_NxTP5wHa);
			Point3D point3D = Utility._0023_003DzbeHMzga5LfNKjFeCKg_003D_003D(array8);
			for (int k = 0; k < array8.Length; k++)
			{
				Vector3D vector3D = new Vector3D(point3D, array8[k]);
				array8[k] = point3D + vector3D * (1.0 + num);
			}
			return Utility.ConvexHull(array8, _0023_003DzccAR5G0_003D, fixNormal: false);
		}

		ConstraintData IMateable.GetConstraintData(Stack<BlockReference> parents)
		{
			return ConstraintData.GetFromICurve(Curve, parents);
		}
	}

	[Serializable]
	public class Face : ISerializable, ICloneable, IMateable
	{
		[Serializable]
		private sealed class _0023_003Dz2IEmqow_003D
		{
			public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

			public static Func<ICurve, IEnumerable<ICurve>> _0023_003Dz_flk8Dd8dzuAveOTIg_003D_003D;

			public static Func<ICurve, TrimCurve> _0023_003DzmIkT8cvlj_0024C_0024asXZ_0024Q_003D_003D;

			public static Func<ICurve, IEnumerable<ICurve>> _0023_003DztMV7cG7Bvg1ltdx1BA_003D_003D;

			public static Func<ICurve, TrimCurve> _0023_003DzCFEqooWmVi_AksKuiw_003D_003D;

			public static Func<Edge, Edge> _0023_003Dz_GqUI8_lDnGsvB4JIg_003D_003D;

			public static Func<Point3D, Point3D> _0023_003DzLPVyQz0Hi6TQ6EDHCQ_003D_003D;

			internal IEnumerable<ICurve> _0023_003Dz180br7bUHQcw_7r_fE00AwY_003D(ICurve _0023_003DzdEvMFOw_003D)
			{
				return _0023_003DzdEvMFOw_003D.GetIndividualCurves();
			}

			internal TrimCurve _0023_003Dzs324uWNmoDmy2mfAkF3YUk4_003D(ICurve _0023_003DzTjnkGyI_003D)
			{
				return (TrimCurve)((TrimCurve)_0023_003DzTjnkGyI_003D).Clone();
			}

			internal IEnumerable<ICurve> _0023_003DzHj9A0Qjf_0024c9JOXulFPrpnbs_003D(ICurve _0023_003DzdEvMFOw_003D)
			{
				return _0023_003DzdEvMFOw_003D.GetIndividualCurves();
			}

			internal TrimCurve _0023_003Dz45eyyLKMxsAXfHb2VjbVxTY_003D(ICurve _0023_003DzTjnkGyI_003D)
			{
				return (TrimCurve)((TrimCurve)_0023_003DzTjnkGyI_003D).Clone();
			}

			internal Edge _0023_003DzeI97KeNSv6onsMGDQwxIMfYai66a(Edge _0023_003DzbfrNXYE_003D)
			{
				return (Edge)_0023_003DzbfrNXYE_003D.Clone();
			}

			internal Point3D _0023_003DzA51uabP61K9xMo_GQqFqH46ZHECZ(Point3D _0023_003Dz77g161c_003D)
			{
				Point3D obj = (Point3D)_0023_003Dz77g161c_003D.Clone();
				((Vertex)obj).Parents = null;
				return obj;
			}
		}

		private sealed class _0023_003DzYD1A7nQuNjpKRW6jVwbnAYA_003D
		{
			public int _0023_003DzTx2aqr8_003D;

			public Func<OrientedEdge, bool> _0023_003DzkqbsCVPMJ_0024g6;

			internal bool _0023_003DzP6LVvIY2v7hBEYZNBg_003D_003D(OrientedEdge _0023_003DzIL0P1ps_003D)
			{
				return _0023_003DzIL0P1ps_003D.CurveIndex == _0023_003DzTx2aqr8_003D;
			}
		}

		internal enum tangentType
		{
			none,
			coplanar,
			coplanarOpposite,
			coincident,
			coincidentOpposite,
			tangent
		}

		public int Subdomain;

		public Loop[] Loops;

		public AnalyticSurf Surface;

		private Surface[] _parametric;

		public FastMesh Tessellation;

		internal FastMesh drawTessellation;

		public bool Sense;

		internal bool needRebuild = true;

		internal bool Visited;

		internal bool hasEdgesToSplit;

		internal Plane plane;

		internal bool planeAlreadySet;

		internal List<int> tangentFacesIndices;

		internal List<tangentType> tangentFacesType;

		public Surface[] Parametric => _parametric;

		public Color? Color { get; set; }

		public string MaterialName { get; set; }

		public TranslationIdentifier TranslationID { get; set; }

		public object FaceData { get; set; }

		public float TextureScaleU { get; set; } = 1f;

		public float TextureScaleV { get; set; } = 1f;

		public float TextureOffsetU { get; set; }

		public float TextureOffsetV { get; set; }

		public float TextureRotationAngle { get; set; }

		internal Face()
		{
			Loops = null;
			Surface = null;
			Sense = true;
			Visited = false;
		}

		public Face(AnalyticSurf surface, Loop[] loops, bool sense = true, Color? color = null, string materialName = null)
		{
			Loops = loops;
			Surface = surface;
			Sense = sense;
			Visited = false;
			Color = color;
			MaterialName = materialName;
		}

		public Face(AnalyticSurf surface, Loop loop, bool sense = true, Color? color = null, string materialName = null)
		{
			Loops = new Loop[1] { loop };
			Surface = surface;
			Sense = sense;
			Visited = false;
			Color = color;
			MaterialName = materialName;
		}

		protected Face(Face another, bool keepTessellation = false)
		{
			Loops = new Loop[another.Loops.Length];
			for (int i = 0; i < Loops.Length; i++)
			{
				Loops[i] = (Loop)another.Loops[i].Clone();
			}
			if (another.Surface != null)
			{
				Surface = (AnalyticSurf)another.Surface.Clone();
			}
			Sense = another.Sense;
			Visited = false;
			Color = another.Color;
			MaterialName = another.MaterialName;
			TextureOffsetU = another.TextureOffsetU;
			TextureScaleU = another.TextureScaleU;
			TextureOffsetV = another.TextureOffsetV;
			TextureScaleV = another.TextureScaleV;
			TextureRotationAngle = another.TextureRotationAngle;
			Subdomain = another.Subdomain;
			if (another.FaceData is ICloneable cloneable)
			{
				FaceData = cloneable.Clone();
			}
			else if (another.FaceData is ValueType)
			{
				FaceData = another.FaceData;
			}
			if (keepTessellation && another.Tessellation != null)
			{
				Tessellation = (FastMesh)another.Tessellation.CloneWithTessellation();
			}
		}

		protected internal Face(BrepFaceSurrogate surrogate)
			: this(surrogate.Surface, surrogate.Loops ?? Array.Empty<Loop>(), surrogate.Sense, surrogate.GetColor())
		{
		}

		public Face(SerializationInfo info, StreamingContext ctxt)
		{
			Loops = (Loop[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957851), typeof(Loop[]));
			Surface = (AnalyticSurf)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957831), typeof(AnalyticSurf));
			Sense = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958069));
			FaceData = info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957282), typeof(object));
			TextureOffsetU = info.GetSingle(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958049));
			TextureOffsetV = info.GetSingle(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958040));
			TextureScaleU = info.GetSingle(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958027));
			TextureScaleV = info.GetSingle(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958015));
			TextureRotationAngle = info.GetSingle(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957971));
			MaterialName = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957968));
		}

		internal void _0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(Surface[] _0023_003DzPzO_0024GUk_003D)
		{
			_parametric = _0023_003DzPzO_0024GUk_003D;
			needRebuild = _0023_003DzPzO_0024GUk_003D == null;
		}

		public virtual object Clone()
		{
			return new Face(this);
		}

		public virtual object CloneWithTessellation()
		{
			return new Face(this, keepTessellation: true);
		}

		public virtual BrepFaceSurrogate ConvertToSurrogate()
		{
			return new BrepFaceSurrogate(this);
		}

		public Vector3D Normal(Point3D point)
		{
			Vector3D tu;
			Vector3D tv;
			Vector3D vector3D = Surface.Normal(point, out tu, out tv);
			if (!Sense)
			{
				vector3D.Negate();
			}
			return vector3D;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < Loops.Length; i++)
			{
				Loop value = Loops[i];
				if (i == 0)
				{
					stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957665));
				}
				else
				{
					stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957679) + i + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696));
				}
				stringBuilder.Append(value);
			}
			stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957634) + Sense);
			if (Color.HasValue)
			{
				stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957624) + Color.ToString());
			}
			if (MaterialName != null)
			{
				stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957608) + MaterialName);
			}
			if (FaceData != null)
			{
				stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957593) + FaceData);
			}
			return stringBuilder.ToString();
		}

		public string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Surface.Dump(linearUnits, massUnits, layers, materials, blocks));
			for (int i = 0; i < Loops.Length; i++)
			{
				Loop loop = Loops[i];
				if (i == 0)
				{
					stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957665));
				}
				else
				{
					stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957582) + i + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696));
				}
				stringBuilder.AppendLine(loop.ToString());
			}
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957820) + Sense);
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957805) + TextureOffsetU.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108) + TextureScaleU.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957758) + TextureOffsetV.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108) + TextureScaleV.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)));
			stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957700), Utility.RadToDeg(TextureRotationAngle).ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)), TextureRotationAngle.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747))));
			if (Tessellation != null)
			{
				stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958428), Tessellation.PointArray.Length / 3, Tessellation.TriangleArray.Length / 3));
			}
			if (Color.HasValue)
			{
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958397) + Color.ToString());
			}
			if (FaceData != null)
			{
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958379) + FaceData.ToString());
			}
			if (MaterialName != null)
			{
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958366) + MaterialName);
			}
			if (Tessellation != null)
			{
				double num = 0.0;
				double num2 = 0.0;
				Mesh mesh = ConvertToMesh();
				num = mesh.GetArea(out var centroid);
				num2 = mesh.GetVolume(out var centroid2);
				stringBuilder.AppendLine();
				stringBuilder.AppendLine();
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958349));
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956848) + linearUnits.ToString().ToLower());
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956804) + massUnits.ToString().ToLower());
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958561) + num.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957036) + linearUnits.ToString().ToLower());
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958549) + centroid);
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958539) + num2.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957747)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956962) + linearUnits.ToString().ToLower());
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958524) + centroid2);
			}
			if (TranslationID != null)
			{
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957859) + TranslationID);
			}
			return stringBuilder.ToString();
		}

		public void Dispose()
		{
			if (Tessellation != null)
			{
				Tessellation.Dispose();
			}
			if (drawTessellation != null)
			{
				drawTessellation.Dispose();
			}
		}

		public double GetError(Edge[] edges)
		{
			double num = double.MinValue;
			Loop[] loops = Loops;
			foreach (Loop loop in loops)
			{
				OrientedEdge orientedEdge;
				OrientedEdge orientedEdge2;
				double num2;
				for (int j = 0; j < loop.Segments.Length - 1; j++)
				{
					orientedEdge = loop.Segments[j];
					orientedEdge2 = loop.Segments[j + 1];
					num2 = Point3D.DistanceSquared(orientedEdge.GetEndPoint(edges), orientedEdge2.GetStartPoint(edges));
					if (num2 > num)
					{
						num = num2;
					}
				}
				orientedEdge = loop.Segments[loop.Segments.Length - 1];
				orientedEdge2 = loop.Segments[0];
				num2 = Point3D.DistanceSquared(orientedEdge.GetEndPoint(edges), orientedEdge2.GetStartPoint(edges));
				if (num2 > num)
				{
					num = num2;
				}
			}
			return Math.Sqrt(num);
		}

		public Mesh ConvertToMesh(Mesh.natureType meshNature = Mesh.natureType.Smooth, Entity parent = null, bool skipEdges = false, float texLength = 1f, Color? parentColor = null)
		{
			if (Tessellation == null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958484));
			}
			Mesh mesh = new Mesh(0, 0, meshNature);
			if (Tessellation.PointArray.Length != 0)
			{
				mesh = Utility._0023_003DzqTukDnG3QxvA22yeWQ_003D_003D(Tessellation.GetPoints(), Tessellation.GetTriangles(), meshNature, TextureOffsetU, TextureScaleU / texLength, TextureOffsetV, TextureScaleV / texLength, TextureRotationAngle, parent, Color, skipEdges, MaterialName, parentColor);
				if (Surface != null && Surface.HasSeam)
				{
					mesh._0023_003DzNfeoW_0024weFDsc(_0023_003DzoZ7QkU98lHkf: false, Surface is ConicalSurf || Surface is SphericalSurf, _0023_003DzFwalihjMriJGyFaGGg_003D_003D: false);
					mesh.sharedEdges = null;
					mesh.sharedEdgesForSilhouettesDraw = null;
					mesh.ComputeEdges();
				}
				if (parent != null)
				{
					mesh.CopyAttributes(parent);
				}
			}
			return mesh;
		}

		public ICurve[] GetOrientedTrimLoops(IList<Edge> edges, bool keepVertices = true)
		{
			int num = Loops.Length;
			ICurve[] array = new ICurve[num];
			for (int i = 0; i < num; i++)
			{
				Loop loop = Loops[i];
				CompositeCurve compositeCurve = new CompositeCurve();
				int num2 = loop.Segments.Length;
				compositeCurve.CurveList.Capacity = num2;
				for (int j = 0; j < num2; j++)
				{
					OrientedEdge orientedEdge = loop.Segments[j];
					Entity entity = (Entity)edges[orientedEdge.CurveIndex].Curve;
					ICurve curve = ((!keepVertices) ? ((ICurve)entity.Clone()) : ((ICurve)Utility._0023_003DzRl3z5maF_0024_jbcZb4zYuHZ4A_003D(entity)));
					curve.EdgeIndex = orientedEdge.CurveIndex;
					if (!orientedEdge.Sense)
					{
						Utility._0023_003Dz_0024fvibmW5yS_0024m(curve, keepVertices);
					}
					compositeCurve.CurveList.Add(curve);
				}
				if (!loop.Sense)
				{
					compositeCurve.CurveList.Reverse();
					foreach (ICurve curve2 in compositeCurve.CurveList)
					{
						Utility._0023_003Dz_0024fvibmW5yS_0024m(curve2, keepVertices);
					}
				}
				if (compositeCurve.CurveList.Count > 1)
				{
					array[i] = compositeCurve;
				}
				else if (compositeCurve.CurveList.Count == 1)
				{
					array[i] = compositeCurve.CurveList[0];
				}
			}
			return array;
		}

		internal _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D _0023_003Dz9ou0t1_BU0wq(Edge[] _0023_003DzqZQSC5KYMzQJ)
		{
			List<Point3D> list = new List<Point3D>(Loops[0].Segments.Length);
			List<int[]> list2 = new List<int[]>(Loops.Length);
			List<IndexLine> list3 = new List<IndexLine>(list.Capacity);
			ICurve[] orientedTrimLoops = GetOrientedTrimLoops(_0023_003DzqZQSC5KYMzQJ);
			for (int i = 0; i < orientedTrimLoops.Length; i++)
			{
				ICurve[] individualCurves = orientedTrimLoops[i].GetIndividualCurves();
				List<Point3D> list4 = new List<Point3D>(individualCurves.Length);
				List<int> list5 = new List<int>(individualCurves.Length);
				ICurve[] array = individualCurves;
				foreach (ICurve curve in array)
				{
					Entity entity = (Entity)curve;
					int num = entity.Vertices.Length;
					for (int k = 0; k < num - 1; k++)
					{
						list4.Add(entity.Vertices[k]);
						list5.Add(curve.EdgeIndex);
					}
				}
				if (list4.Count < 3)
				{
					if (i == 0)
					{
						return null;
					}
					continue;
				}
				int[] array2 = new int[list4.Count];
				IndexLine[] array3 = new IndexLine[list4.Count];
				int num2 = list.Count;
				int num3 = 0;
				while (num3 < list4.Count)
				{
					array2[num3] = num2;
					if (num3 < list4.Count - 1)
					{
						array3[num3] = new HiddenLinesView._0023_003DzPWBOFEX1IKDR(num2, num2 + 1, list5[num3]);
					}
					else
					{
						array3[num3] = new HiddenLinesView._0023_003DzPWBOFEX1IKDR(num2, list.Count, list5[num3]);
					}
					num3++;
					num2++;
				}
				list.AddRange(list4);
				list2.Add(array2);
				list3.AddRange(array3);
			}
			if (list2.Count > 1)
			{
				Plane plane = _0023_003DzNY5YUv279_SW(_0023_003DzAc2bAx13cHt5epGxxQ_003D_003D: false);
				Point2D[] array4 = new Point2D[list2[0].Length];
				for (int l = 0; l < array4.Length; l++)
				{
					array4[l] = plane.Project(list[list2[0][l]]);
				}
				if (!Utility.PointInPolygon(plane.Project(list[list2[1][0]]), array4))
				{
					list2.Reverse();
				}
			}
			return new _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D(list.ToArray(), list2.ToArray())
			{
				_0023_003DzU4XYawo_003D = list3.ToArray()
			};
		}

		internal Plane _0023_003DzNY5YUv279_SW(bool _0023_003DzAc2bAx13cHt5epGxxQ_003D_003D)
		{
			if (!planeAlreadySet)
			{
				if (Surface.GetType() == typeof(PlanarSurf))
				{
					this.plane = (Plane)((PlanarSurf)Surface).Plane.Clone();
					if (!Sense)
					{
						this.plane = new Plane(this.plane.Origin, -1.0 * this.plane.AxisX, this.plane.AxisY);
					}
				}
				else if (!_0023_003DzAc2bAx13cHt5epGxxQ_003D_003D)
				{
					Plane plane;
					if (_0023_003Dz9FCm9_0024CiAUGE())
					{
						if (!(Surface is TabulatedSurf tabulatedSurf) || !Utility.IsLine(tabulatedSurf.Directrix))
						{
							return null;
						}
						int num = (Sense ? 1 : (-1));
						this.plane = new Plane((Point3D)tabulatedSurf.Directrix.StartPoint.Clone(), num * tabulatedSurf.Directrix.StartTangent, (Vector3D)tabulatedSurf.Generatrix.Clone());
					}
					else if (Parametric[0].IsPlanar(1E-09, out plane))
					{
						this.plane = plane;
					}
				}
				planeAlreadySet = true;
			}
			return this.plane;
		}

		public Surface[] ConvertToSurface(Entity parent = null)
		{
			if (Parametric == null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958187));
			}
			int num = Parametric.Length;
			Surface[] array = new Surface[num];
			for (int i = 0; i < num; i++)
			{
				Surface surface = (Surface)Parametric[i].Clone();
				surface.TextureOffsetU = TextureOffsetU;
				surface.TextureScaleU = TextureScaleU;
				surface.TextureOffsetV = TextureOffsetV;
				surface.TextureScaleV = TextureScaleV;
				surface.TextureRotationAngle = TextureRotationAngle;
				if (parent != null)
				{
					surface.CopyAttributes(parent);
					if (Color.HasValue)
					{
						surface.ColorMethod = colorMethodType.byEntity;
						surface.Color = Color.Value;
					}
					if (MaterialName != null)
					{
						surface.MaterialName = MaterialName;
					}
				}
				array[i] = surface;
			}
			return array;
		}

		public void Flip()
		{
			Sense = !Sense;
			_0023_003Dzuc_5f2_0024SKYRM();
		}

		internal void _0023_003Dzuc_5f2_0024SKYRM()
		{
			Loop[] loops = Loops;
			foreach (Loop loop in loops)
			{
				loop.Sense = !loop.Sense;
			}
			if (Parametric != null)
			{
				Surface[] parametric = Parametric;
				for (int i = 0; i < parametric.Length; i++)
				{
					parametric[i].ReverseU();
				}
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957851), Loops);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957831), Surface);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958069), Sense);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957282), FaceData);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958049), TextureOffsetU);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958040), TextureOffsetV);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958027), TextureScaleU);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958015), TextureScaleV);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957971), TextureRotationAngle);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957968), MaterialName);
		}

		public void Draw(DrawParams data, float textureLength)
		{
			_0023_003DzwuJjRo0_003D(data, drawTessellation ?? Tessellation, textureLength);
		}

		internal void _0023_003Dz06hxzaWTjWAJ(DrawParams _0023_003DzELu0Pss_003D)
		{
			Color currentWireColor = _0023_003DzELu0Pss_003D.RenderContext.CurrentWireColor;
			Color diffuse = _0023_003DzELu0Pss_003D.RenderContext.CurrentMaterial.Diffuse;
			Color diffuse2 = _0023_003DzELu0Pss_003D.RenderContext.CurrentBackMaterial.Diffuse;
			Color ambient = _0023_003DzELu0Pss_003D.RenderContext.CurrentMaterial.Ambient;
			Entity.SetEntityColorForFace(_0023_003DzELu0Pss_003D, Color.Value);
			_0023_003DzwuJjRo0_003D(_0023_003DzELu0Pss_003D, drawTessellation ?? Tessellation, 1f);
			_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(currentWireColor);
			_0023_003DzELu0Pss_003D.RenderContext.SetMaterialFrontDiffuse(diffuse);
			_0023_003DzELu0Pss_003D.RenderContext.SetMaterialBackDiffuse(diffuse2);
			_0023_003DzELu0Pss_003D.RenderContext.SetMaterialFrontAmbient(ambient);
		}

		internal void _0023_003DzyoBNHb9uSLi2(DrawParams _0023_003DzELu0Pss_003D, float _0023_003DzWcVp_002487HeuHS)
		{
			bool num = _0023_003DzELu0Pss_003D.Viewport.DisplayMode == displayType.Rendered;
			bool flag = !string.IsNullOrEmpty(MaterialName);
			if (num)
			{
				Material material = ((RenderParams)_0023_003DzELu0Pss_003D).hqrData.Material ?? _0023_003DzELu0Pss_003D.RenderContext.CurrentMaterial;
				Material material2 = null;
				if (flag)
				{
					material2 = ((RenderParams)_0023_003DzELu0Pss_003D).materials[MaterialName];
				}
				else
				{
					material2 = material.SoftClone();
					material2.Diffuse = Color.Value;
				}
				Entity.SetEntityMaterialForFace(_0023_003DzELu0Pss_003D, material2);
				_0023_003DzwuJjRo0_003D(_0023_003DzELu0Pss_003D, Tessellation, _0023_003DzWcVp_002487HeuHS);
				Entity.SetEntityMaterialForFace(_0023_003DzELu0Pss_003D, material);
			}
			else if (!flag)
			{
				_0023_003Dz06hxzaWTjWAJ(_0023_003DzELu0Pss_003D);
			}
			else
			{
				_0023_003DzwuJjRo0_003D(_0023_003DzELu0Pss_003D, Tessellation, _0023_003DzWcVp_002487HeuHS);
			}
		}

		private void _0023_003DzwuJjRo0_003D(DrawParams _0023_003DzELu0Pss_003D, FastMesh _0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D, float _0023_003DzWcVp_002487HeuHS)
		{
			if (_0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D.TextureCoordsArray != null)
			{
				IWorkspaceInternal parent = ((IViewportInternal)_0023_003DzELu0Pss_003D.Viewport).parent;
				VBOParamsTexture myParams = new VBOParamsTexture
				{
					indices = _0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D.TriangleArray,
					vertices = _0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D.PointArray,
					normals = _0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D.NormalArray,
					TextureCoordinates = _0023_003DzoMVmMsDy2Y2DAlpMxpr_0024cB_00244FmRgUSsZxg_003D_003D(_0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D, !parent.IsHardwareAccelerated, _0023_003DzWcVp_002487HeuHS, _0023_003DzELu0Pss_003D.RenderContext.IsDirect3D)
				};
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndexedTriangles(myParams);
			}
			else
			{
				VBOParams myParams2 = new VBOParams
				{
					indices = _0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D.TriangleArray,
					vertices = _0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D.PointArray,
					normals = _0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D.NormalArray
				};
				_0023_003DzELu0Pss_003D.RenderContext.DrawIndexedTriangles(myParams2);
			}
		}

		private float[] _0023_003DzoMVmMsDy2Y2DAlpMxpr_0024cB_00244FmRgUSsZxg_003D_003D(FastMesh _0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D, bool _0023_003DzFG092rSyTM5qH3AdvQ_003D_003D, float _0023_003DzWcVp_002487HeuHS, bool _0023_003Dzxpw1cnFn69Qt)
		{
			float[] array = new float[_0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D.TextureCoordsArray.Length];
			Array.Copy(_0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D.TextureCoordsArray, array, array.Length);
			float num = TextureScaleU;
			float num2 = TextureScaleV;
			if (_0023_003DzFG092rSyTM5qH3AdvQ_003D_003D)
			{
				num /= _0023_003DzWcVp_002487HeuHS;
				num2 /= _0023_003DzWcVp_002487HeuHS;
			}
			float[,] transformationMatrix = Utility.GetTransformationMatrix(num, num2, TextureOffsetU, TextureOffsetV, TextureRotationAngle);
			for (int i = 0; i < array.Length; i += 2)
			{
				float[] array2 = Matrix.Multiply3x(transformationMatrix, new float[3]
				{
					array[i],
					array[i + 1],
					1f
				});
				array[i] = array2[0];
				array[i + 1] = (_0023_003Dzxpw1cnFn69Qt ? (1f - array2[1]) : array2[1]);
			}
			return array;
		}

		internal bool _0023_003Dz9FCm9_0024CiAUGE()
		{
			if (Parametric != null)
			{
				return Parametric.Length == 0;
			}
			return true;
		}

		internal bool _0023_003Dz7EOfQ_wBFahDw9Pn9w_003D_003D(Face _0023_003DzcQpPRG5mmRCF, out tangentType _0023_003DzzwoQwOglTJml3vqNGA_003D_003D, bool _0023_003Dzk_3tZjgmhGlmfKWn0g_003D_003D)
		{
			Plane plane = null;
			Plane plane2 = null;
			_0023_003DzzwoQwOglTJml3vqNGA_003D_003D = tangentType.none;
			plane = _0023_003Dz2rx0bYXAv_0024aP(_0023_003Dzk_3tZjgmhGlmfKWn0g_003D_003D);
			if (plane == null)
			{
				return false;
			}
			plane2 = _0023_003DzcQpPRG5mmRCF._0023_003Dz2rx0bYXAv_0024aP(_0023_003Dzk_3tZjgmhGlmfKWn0g_003D_003D);
			if (plane2 == null)
			{
				return false;
			}
			Plane plane3 = (Plane)plane.Clone();
			Plane plane4 = (Plane)plane2.Clone();
			if (Parametric != null && _0023_003DzcQpPRG5mmRCF.Parametric != null)
			{
				Parametric[0].ControlBoundingBox(out var min, out var max);
				_0023_003DzcQpPRG5mmRCF.Parametric[0].ControlBoundingBox(out var min2, out var max2);
				if (Utility.DoOverlapOrTouchWithIntersectionBox(min, max, min2, max2, out var intersMin, out var intersMax))
				{
					Point3D p = plane.Origin.ProjectTo(intersMin, intersMax);
					Point2D pt = plane.Project(p);
					plane3.Origin = plane.PointAt(pt);
					Point3D p2 = plane2.Origin.ProjectTo(intersMin, intersMax);
					Point2D pt2 = plane2.Project(p2);
					plane4.Origin = plane2.PointAt(pt2);
				}
			}
			if (Plane.Intersection(plane3, plane4, Utility._0023_003DzmJq0qCkmyW_ojQnBEK6tFMvwPBqiC7SchQ_003D_003D, out var _) == planeIntersectionType.Coincide)
			{
				_0023_003DzzwoQwOglTJml3vqNGA_003D_003D = ((!Vector3D.AreOpposite(plane.AxisZ, plane2.AxisZ)) ? tangentType.coplanar : tangentType.coplanarOpposite);
				return true;
			}
			return false;
		}

		internal tangentType _0023_003DzaGX1f4XwdTHn(Face _0023_003DzcQpPRG5mmRCF)
		{
			return devDept.Eyeshot.Entities.Surface._0023_003DzmB4COCtQntAOFJR13g_003D_003D(Parametric[0], _0023_003DzcQpPRG5mmRCF.Parametric[0], plane, _0023_003DzcQpPRG5mmRCF.plane);
		}

		public Plane IsPlanar()
		{
			return _0023_003Dz2rx0bYXAv_0024aP(_0023_003DzAc2bAx13cHt5epGxxQ_003D_003D: false);
		}

		internal Plane _0023_003Dz2rx0bYXAv_0024aP(bool _0023_003DzAc2bAx13cHt5epGxxQ_003D_003D)
		{
			if (!planeAlreadySet)
			{
				if (Surface.GetType() == typeof(PlanarSurf))
				{
					this.plane = (Plane)((PlanarSurf)Surface).Plane.Clone();
					if (!Sense)
					{
						this.plane = new Plane(this.plane.Origin, -1.0 * this.plane.AxisX, this.plane.AxisY);
					}
				}
				else if (!_0023_003DzAc2bAx13cHt5epGxxQ_003D_003D)
				{
					Plane pln;
					if (Surface is TabulatedSurf tabulatedSurf)
					{
						Vector3D vector3D = (Vector3D)tabulatedSurf.Generatrix.Clone();
						vector3D.Normalize();
						if (Utility.IsLine(tabulatedSurf.Directrix) || (tabulatedSurf.Directrix.IsPlanar(Utility._0023_003DzheSR8QM7q9ya, out var plane) && Vector3D.AreOrthogonal(plane.AxisZ, vector3D)))
						{
							double num = (Sense ? 1 : (-1));
							this.plane = new Plane(tabulatedSurf.Directrix.StartPoint, num * tabulatedSurf.Directrix.StartTangent, (Vector3D)tabulatedSurf.Generatrix.Clone());
						}
					}
					else if (Surface is RevolvedSurf revolvedSurf)
					{
						if ((Utility.IsLine(revolvedSurf.Generatrix) && Vector3D.AreOrthogonal(revolvedSurf.Plane.AxisZ, revolvedSurf.Generatrix.StartTangent)) || (revolvedSurf.Generatrix.IsPlanar(Utility._0023_003DzheSR8QM7q9ya, out var plane2) && Vector3D.AreParallel(revolvedSurf.Plane.AxisZ, plane2.AxisZ)))
						{
							double num2 = (Sense ? 1 : (-1));
							this.plane = new Plane(revolvedSurf.Generatrix.StartPoint, num2 * revolvedSurf.Generatrix.StartTangent, Vector3D.Cross(revolvedSurf.Plane.AxisZ, revolvedSurf.Generatrix.StartTangent));
						}
					}
					else if (Surface is ConicalSurf conicalSurf)
					{
						if (Math.Abs(conicalSurf.HalfAngle - Math.PI / 2.0) < Utility._0023_003DzheSR8QM7q9ya)
						{
							this.plane = (Plane)conicalSurf.Plane.Clone();
							if (!Sense)
							{
								this.plane.Flip();
							}
						}
					}
					else if (Surface is NurbsSurf nurbsSurf && nurbsSurf.IsPlanar(Utility._0023_003DzheSR8QM7q9ya, out pln))
					{
						if (!Sense)
						{
							pln.Flip();
						}
						this.plane = pln;
					}
				}
				planeAlreadySet = true;
			}
			return this.plane;
		}

		internal bool _0023_003DzUAP7_Fz4Idb4(Face _0023_003DzcQpPRG5mmRCF, double _0023_003Dzm0CYiiE_003D, Dictionary<int, int> _0023_003DznOxom2vgXvVl, out bool _0023_003DzGu4ta3WK76jHTSFs6DO7tLo_003D, bool _0023_003Dzco1t_0024ys8aSEApoNVew_003D_003D)
		{
			_0023_003DzGu4ta3WK76jHTSFs6DO7tLo_003D = false;
			Parametric[0].ControlBoundingBox(out var min, out var max);
			_0023_003DzcQpPRG5mmRCF.Parametric[0].ControlBoundingBox(out var min2, out var max2);
			double tol = 2.0 * Utility._0023_003DzmJq0qCkmyW_ojQnBEK6tFMvwPBqiC7SchQ_003D_003D;
			if (!Utility.DoOverlapOrTouch(min.X, max.X, min2.X, max2.X, tol) || !Utility.DoOverlapOrTouch(min.Y, max.Y, min2.Y, max2.Y, tol) || !Utility.DoOverlapOrTouch(min.Z, max.Z, min2.Z, max2.Z, tol))
			{
				return false;
			}
			bool flag = Loops.Length != _0023_003DzcQpPRG5mmRCF.Loops.Length;
			Loop loop = Loops[0];
			Loop loop2 = _0023_003DzcQpPRG5mmRCF.Loops[0];
			if (loop.Segments.Length != loop2.Segments.Length)
			{
				flag = true;
			}
			List<ICurve> list = new List<ICurve>();
			foreach (ICurve contour in Parametric[0].Trimming.ContourList)
			{
				ICurve[] individualCurves = contour.GetIndividualCurves();
				for (int i = 0; i < individualCurves.Length; i++)
				{
					TrimCurve trimCurve = (TrimCurve)individualCurves[i];
					list.Add((ICurve)trimCurve.Clone());
				}
			}
			List<ICurve> list2 = new List<ICurve>();
			foreach (ICurve contour2 in _0023_003DzcQpPRG5mmRCF.Parametric[0].Trimming.ContourList)
			{
				ICurve[] individualCurves = contour2.GetIndividualCurves();
				for (int i = 0; i < individualCurves.Length; i++)
				{
					TrimCurve trimCurve2 = (TrimCurve)individualCurves[i];
					list2.Add((ICurve)trimCurve2.Clone());
				}
			}
			if (list.Count != list2.Count)
			{
				flag = true;
			}
			for (int j = 0; j < list.Count; j++)
			{
				ICurve edge = ((TrimCurve)list[j]).Edge;
				int count = list2.Count;
				int num;
				for (num = count - 1; num >= 0; num--)
				{
					ICurve edge2 = ((TrimCurve)list2[num]).Edge;
					Point3D _0023_003DzDVubtvo_003D;
					Point3D _0023_003DzFj_0024IqDQ_003D;
					bool _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D;
					Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D = Curve._0023_003DzRGcO5v1wS2S_(edge.GetNurbsForm(), edge2.GetNurbsForm(), out _0023_003DzDVubtvo_003D, out _0023_003DzFj_0024IqDQ_003D, out _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D, 1.0);
					bool flag2 = _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)3 || _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)5;
					bool flag3 = _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)4 || _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)6;
					if ((!_0023_003Dzco1t_0024ys8aSEApoNVew_003D_003D && flag2) || (_0023_003Dzco1t_0024ys8aSEApoNVew_003D_003D && flag3))
					{
						if (!_0023_003DznOxom2vgXvVl.ContainsKey(list2[num].EdgeIndex))
						{
							_0023_003DznOxom2vgXvVl.Add(list2[num].EdgeIndex, list[j].EdgeIndex);
						}
						list2.RemoveAt(num);
						_0023_003DzGu4ta3WK76jHTSFs6DO7tLo_003D = true;
						if (!flag)
						{
							break;
						}
						return false;
					}
					if (_0023_003Dzco1t_0024ys8aSEApoNVew_003D_003D)
					{
						if (_0023_003DzbFBOqAxS4tgSnZ3iCeWbsLk_003D(this, edge2, ref _0023_003DzGu4ta3WK76jHTSFs6DO7tLo_003D, _0023_003Dzm0CYiiE_003D))
						{
							return false;
						}
						if (_0023_003DzbFBOqAxS4tgSnZ3iCeWbsLk_003D(_0023_003DzcQpPRG5mmRCF, edge, ref _0023_003DzGu4ta3WK76jHTSFs6DO7tLo_003D, _0023_003Dzm0CYiiE_003D))
						{
							return false;
						}
					}
				}
				if (list2.Count != 0 && num == count)
				{
					_0023_003DzcQpPRG5mmRCF.Parametric[0].Project(edge.StartPoint, out var proj);
					Region trimming = _0023_003DzcQpPRG5mmRCF.Parametric[0].Trimming;
					if (trimming.IsPointInside(proj) && !trimming.IsPointOnContour(new Point3D(proj.X, proj.Y, 0.0), _0023_003Dzm0CYiiE_003D))
					{
						_0023_003DzGu4ta3WK76jHTSFs6DO7tLo_003D = true;
						return false;
					}
					flag = true;
				}
			}
			if (list2.Count == 0)
			{
				return true;
			}
			return false;
		}

		internal bool _0023_003DzYzEUacYequL5(Face _0023_003DzcQpPRG5mmRCF, double _0023_003Dzm0CYiiE_003D, bool _0023_003Dzco1t_0024ys8aSEApoNVew_003D_003D)
		{
			Parametric[0].ControlBoundingBox(out var min, out var max);
			_0023_003DzcQpPRG5mmRCF.Parametric[0].ControlBoundingBox(out var min2, out var max2);
			double tol = 2.0 * Utility._0023_003DzmJq0qCkmyW_ojQnBEK6tFMvwPBqiC7SchQ_003D_003D;
			if (!Utility.DoOverlapOrTouch(min.X, max.X, min2.X, max2.X, tol) || !Utility.DoOverlapOrTouch(min.Y, max.Y, min2.Y, max2.Y, tol) || !Utility.DoOverlapOrTouch(min.Z, max.Z, min2.Z, max2.Z, tol))
			{
				return false;
			}
			List<TrimCurve> list = Parametric[0].Trimming.ContourList.SelectMany(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz180br7bUHQcw_7r_fE00AwY_003D).Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzs324uWNmoDmy2mfAkF3YUk4_003D).ToList();
			List<TrimCurve> list2 = _0023_003DzcQpPRG5mmRCF.Parametric[0].Trimming.ContourList.SelectMany((ICurve _0023_003DzdEvMFOw_003D) => _0023_003DzdEvMFOw_003D.GetIndividualCurves()).Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz45eyyLKMxsAXfHb2VjbVxTY_003D).ToList();
			bool flag = true;
			foreach (TrimCurve item in list)
			{
				bool flag2 = false;
				foreach (TrimCurve item2 in list2)
				{
					Point3D _0023_003DzDVubtvo_003D;
					Point3D _0023_003DzFj_0024IqDQ_003D;
					bool _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D;
					Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D = Curve._0023_003DzRGcO5v1wS2S_(item.Edge.GetNurbsForm(), item2.Edge.GetNurbsForm(), out _0023_003DzDVubtvo_003D, out _0023_003DzFj_0024IqDQ_003D, out _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D, 1.0);
					bool flag3 = _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)3 || _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)5 || _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)1;
					bool flag4 = _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)4 || _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)6 || _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)2;
					if ((!_0023_003Dzco1t_0024ys8aSEApoNVew_003D_003D && flag3) || (_0023_003Dzco1t_0024ys8aSEApoNVew_003D_003D && flag4))
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return true;
			}
			return false;
		}

		private static bool _0023_003DzbFBOqAxS4tgSnZ3iCeWbsLk_003D(Face _0023_003Dzn6eRxNucSNoK, ICurve _0023_003Dz_rN1bXw_003D, ref bool _0023_003DzGu4ta3WK76jHTSFs6DO7tLo_003D, double _0023_003Dzm0CYiiE_003D)
		{
			Point2D[] array = new Point2D[2];
			_0023_003Dzn6eRxNucSNoK.Parametric[0].Project(_0023_003Dz_rN1bXw_003D.StartPoint, out array[0]);
			_0023_003Dzn6eRxNucSNoK.Parametric[0].Project(_0023_003Dz_rN1bXw_003D.PointAt(_0023_003Dz_rN1bXw_003D.Domain.Mid), out array[1]);
			Region trimming = _0023_003Dzn6eRxNucSNoK.Parametric[0].Trimming;
			Point2D[] array2 = array;
			foreach (Point2D point2D in array2)
			{
				if (trimming.IsPointInside(point2D) && !trimming.IsPointOnContour(new Point3D(point2D.X, point2D.Y), _0023_003Dzm0CYiiE_003D))
				{
					_0023_003DzGu4ta3WK76jHTSFs6DO7tLo_003D = true;
					return true;
				}
			}
			return false;
		}

		internal void _0023_003Dzu_VTP2T_2LTBmaxiiTgVZUs_003D(Dictionary<int, int> _0023_003DzQtyBAo4gFsZY, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, bool _0023_003DzvsFKDVZyhE_Q)
		{
			Surface[] parametric = Parametric;
			if (parametric == null)
			{
				return;
			}
			for (int i = 0; i < parametric.Length; i++)
			{
				if (parametric[i] == null)
				{
					continue;
				}
				Region trimming = parametric[i].Trimming;
				for (int j = 0; j < trimming.ContourList.Count; j++)
				{
					ICurve[] individualCurves = trimming.ContourList[j].GetIndividualCurves();
					for (int k = 0; k < individualCurves.Length; k++)
					{
						if (individualCurves[k].EdgeIndex != -1 && individualCurves[k].FromBooleanIntersection == _0023_003DzvsFKDVZyhE_Q)
						{
							if (_0023_003DzQtyBAo4gFsZY.TryGetValue(individualCurves[k].EdgeIndex, out var value))
							{
								individualCurves[k].EdgeIndex = value;
							}
						}
						else
						{
							((TrimCurve)individualCurves[k]).Edge.Length();
						}
						((TrimCurve)individualCurves[k]).FromBooleanIntersection = false;
					}
				}
			}
		}

		internal int _0023_003DzYv8Bh4SElLSH(int _0023_003DzTx2aqr8_003D)
		{
			_0023_003DzYD1A7nQuNjpKRW6jVwbnAYA_003D _0023_003DzYD1A7nQuNjpKRW6jVwbnAYA_003D2 = new _0023_003DzYD1A7nQuNjpKRW6jVwbnAYA_003D();
			_0023_003DzYD1A7nQuNjpKRW6jVwbnAYA_003D2._0023_003DzTx2aqr8_003D = _0023_003DzTx2aqr8_003D;
			for (int i = 0; i < Loops.Length; i++)
			{
				if (Loops[i].Segments.Count(_0023_003DzYD1A7nQuNjpKRW6jVwbnAYA_003D2._0023_003DzP6LVvIY2v7hBEYZNBg_003D_003D) != 0)
				{
					return i;
				}
			}
			return -1;
		}

		internal bool _0023_003DzFx_0024iwuIdvVT76znlPxoNiYjJkEnS(List<Edge> _0023_003DzViGQVPM_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, int _0023_003DzhNQLY4s_003D, int _0023_003DzqhsKlJc_003D, double _0023_003Dzm0CYiiE_003D)
		{
			List<OrientedEdge> list = Loops[_0023_003DzhNQLY4s_003D].Segments.ToList();
			if (Loops[_0023_003DzhNQLY4s_003D].Sense)
			{
				for (int i = 0; i < list.Count; i++)
				{
					int index = i;
					int index2 = i + 1;
					if (i == list.Count - 1)
					{
						index = i;
						index2 = 0;
					}
					int num = (list[index].Sense ? _0023_003DzViGQVPM_003D[list[index].CurveIndex].EndPointIndex : _0023_003DzViGQVPM_003D[list[index].CurveIndex].StartPointIndex);
					int num2 = (list[index2].Sense ? _0023_003DzViGQVPM_003D[list[index2].CurveIndex].StartPointIndex : _0023_003DzViGQVPM_003D[list[index2].CurveIndex].EndPointIndex);
					Point3D a = (list[index].Sense ? _0023_003DzViGQVPM_003D[list[index].CurveIndex].Curve.EndPoint : _0023_003DzViGQVPM_003D[list[index].CurveIndex].Curve.StartPoint);
					Point3D b = (list[index2].Sense ? _0023_003DzViGQVPM_003D[list[index2].CurveIndex].Curve.StartPoint : _0023_003DzViGQVPM_003D[list[index2].CurveIndex].Curve.EndPoint);
					int startPointIndex = _0023_003DzViGQVPM_003D[_0023_003DzqhsKlJc_003D].StartPointIndex;
					int endPointIndex = _0023_003DzViGQVPM_003D[_0023_003DzqhsKlJc_003D].EndPointIndex;
					if (!(Point3D.DistanceSquared(a, b) > _0023_003Dzm0CYiiE_003D * _0023_003Dzm0CYiiE_003D) || (num2 != startPointIndex && num2 != endPointIndex && num != startPointIndex && num != endPointIndex))
					{
						continue;
					}
					bool num3 = num != endPointIndex;
					bool flag = num2 != startPointIndex;
					if (num3)
					{
						Edge edge = ((!list[index].Sense) ? _0023_003DziOhtUfKDpQ_zDVq0BA_003D_003D(_0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, list[index].CurveIndex, endPointIndex, _0023_003DzViGQVPM_003D[list[index].CurveIndex].EndPointIndex) : _0023_003DziOhtUfKDpQ_zDVq0BA_003D_003D(_0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, list[index].CurveIndex, _0023_003DzViGQVPM_003D[list[index].CurveIndex].StartPointIndex, endPointIndex));
						if (edge != null)
						{
							_0023_003DzViGQVPM_003D[list[index].CurveIndex] = edge;
						}
					}
					if (flag)
					{
						Edge edge2 = ((!list[index2].Sense) ? _0023_003DziOhtUfKDpQ_zDVq0BA_003D_003D(_0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, list[index2].CurveIndex, _0023_003DzViGQVPM_003D[list[index2].CurveIndex].StartPointIndex, startPointIndex) : _0023_003DziOhtUfKDpQ_zDVq0BA_003D_003D(_0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, list[index2].CurveIndex, startPointIndex, _0023_003DzViGQVPM_003D[list[index2].CurveIndex].EndPointIndex));
						if (edge2 != null)
						{
							_0023_003DzViGQVPM_003D[list[index2].CurveIndex] = edge2;
						}
					}
					if (_0023_003DzViGQVPM_003D[list[index2].CurveIndex].Curve.Length() < Utility._0023_003DzheSR8QM7q9ya)
					{
						_0023_003DzViGQVPM_003D[list[index2].CurveIndex].Parents = null;
						list.RemoveAt(index2);
					}
					list.Insert(index2, new OrientedEdge(_0023_003DzqhsKlJc_003D, sense: false));
					if (_0023_003DzViGQVPM_003D[list[index].CurveIndex].Curve.Length() < Utility._0023_003DzheSR8QM7q9ya)
					{
						_0023_003DzViGQVPM_003D[list[index].CurveIndex].Parents = null;
						list.RemoveAt(index);
					}
					Loops[_0023_003DzhNQLY4s_003D].Segments = list.ToArray();
					return true;
				}
			}
			else
			{
				for (int num4 = list.Count - 1; num4 >= 0; num4--)
				{
					int index3 = num4;
					int index4 = num4 - 1;
					if (num4 == 0)
					{
						index3 = num4;
						index4 = list.Count - 1;
					}
					int num5 = (list[index4].Sense ? _0023_003DzViGQVPM_003D[list[index4].CurveIndex].EndPointIndex : _0023_003DzViGQVPM_003D[list[index4].CurveIndex].StartPointIndex);
					int num6 = (list[index3].Sense ? _0023_003DzViGQVPM_003D[list[index3].CurveIndex].StartPointIndex : _0023_003DzViGQVPM_003D[list[index3].CurveIndex].EndPointIndex);
					Point3D a2 = (list[index3].Sense ? _0023_003DzViGQVPM_003D[list[index3].CurveIndex].Curve.StartPoint : _0023_003DzViGQVPM_003D[list[index3].CurveIndex].Curve.EndPoint);
					Point3D b2 = (list[index4].Sense ? _0023_003DzViGQVPM_003D[list[index4].CurveIndex].Curve.EndPoint : _0023_003DzViGQVPM_003D[list[index4].CurveIndex].Curve.StartPoint);
					int startPointIndex = _0023_003DzViGQVPM_003D[_0023_003DzqhsKlJc_003D].StartPointIndex;
					int endPointIndex = _0023_003DzViGQVPM_003D[_0023_003DzqhsKlJc_003D].EndPointIndex;
					if (Point3D.DistanceSquared(a2, b2) > _0023_003Dzm0CYiiE_003D * _0023_003Dzm0CYiiE_003D && (num5 == startPointIndex || num5 == endPointIndex || num6 == startPointIndex || num6 == endPointIndex))
					{
						bool flag2 = num5 == startPointIndex || num6 == endPointIndex;
						bool num7 = (flag2 ? (num6 != endPointIndex) : (num6 != startPointIndex));
						bool flag3 = (flag2 ? (num5 != startPointIndex) : (num5 != endPointIndex));
						if (num7)
						{
							Edge edge3 = ((!list[index3].Sense) ? _0023_003DziOhtUfKDpQ_zDVq0BA_003D_003D(_0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, list[index3].CurveIndex, _0023_003DzViGQVPM_003D[list[index3].CurveIndex].StartPointIndex, flag2 ? endPointIndex : startPointIndex) : _0023_003DziOhtUfKDpQ_zDVq0BA_003D_003D(_0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, list[index3].CurveIndex, flag2 ? endPointIndex : startPointIndex, _0023_003DzViGQVPM_003D[list[index3].CurveIndex].EndPointIndex));
							if (edge3 != null)
							{
								_0023_003DzViGQVPM_003D[list[index3].CurveIndex] = edge3;
							}
						}
						if (flag3)
						{
							Edge edge4 = ((!list[index4].Sense) ? _0023_003DziOhtUfKDpQ_zDVq0BA_003D_003D(_0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, list[index4].CurveIndex, flag2 ? startPointIndex : endPointIndex, _0023_003DzViGQVPM_003D[list[index4].CurveIndex].EndPointIndex) : _0023_003DziOhtUfKDpQ_zDVq0BA_003D_003D(_0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, list[index4].CurveIndex, _0023_003DzViGQVPM_003D[list[index4].CurveIndex].StartPointIndex, flag2 ? startPointIndex : endPointIndex));
							if (edge4 != null)
							{
								_0023_003DzViGQVPM_003D[list[index4].CurveIndex] = edge4;
							}
						}
						if (_0023_003DzViGQVPM_003D[list[index4].CurveIndex].Curve.Length() < Utility._0023_003DzheSR8QM7q9ya)
						{
							_0023_003DzViGQVPM_003D[list[index4].CurveIndex].Parents = null;
							list.RemoveAt(index4);
						}
						list.Insert(index3, new OrientedEdge(_0023_003DzqhsKlJc_003D, flag2));
						if (_0023_003DzViGQVPM_003D[list[index3].CurveIndex].Curve.Length() < Utility._0023_003DzheSR8QM7q9ya)
						{
							_0023_003DzViGQVPM_003D[list[index3].CurveIndex].Parents = null;
							list.RemoveAt(index3);
						}
						Loops[_0023_003DzhNQLY4s_003D].Segments = list.ToArray();
						return true;
					}
				}
			}
			return false;
		}

		internal bool _0023_003Dz_vlEt0lxdtIt(int _0023_003DzAJYZcKw_003D, int _0023_003DzqhsKlJc_003D, bool _0023_003Dz4UI1QTK0IxO2yG_zkA_003D_003D)
		{
			bool result = false;
			Loop[] loops = Loops;
			foreach (Loop loop in loops)
			{
				for (int j = 0; j < loop.Segments.Length; j++)
				{
					if (loop.Segments[j].CurveIndex == _0023_003DzAJYZcKw_003D)
					{
						loop.Segments[j] = new OrientedEdge(_0023_003DzqhsKlJc_003D, _0023_003Dz4UI1QTK0IxO2yG_zkA_003D_003D != loop.Segments[j].Sense);
						result = true;
					}
				}
			}
			return result;
		}

		internal void _0023_003Dz6Tva2mtI46vE(int _0023_003DzL8NvYU0_003D)
		{
			Loop[] loops = Loops;
			foreach (Loop loop in loops)
			{
				List<OrientedEdge> list = loop.Segments.ToList();
				for (int num = list.Count - 1; num >= 0; num--)
				{
					if (list[num].CurveIndex == _0023_003DzL8NvYU0_003D)
					{
						list.RemoveAt(num);
					}
				}
				loop.Segments = list.ToArray();
			}
		}

		public booleanFailureType SubdivideBy(Plane pln, Brep parent)
		{
			Dictionary<int, List<int>> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D = new Dictionary<int, List<int>>();
			List<int> _0023_003Dzx_GU4e6o84p = new List<int>();
			Dictionary<int, int> _0023_003DzV8Lcc5p5_0024hWB = new Dictionary<int, int>();
			Dictionary<int, int> _0023_003DzVR_NB33ieggi = new Dictionary<int, int>();
			return _0023_003Dz_00242tCFnhZs13OnckxuA_003D_003D(pln, parent, _0023_003DzdBFS3nhATrKQ: true, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, _0023_003Dzx_GU4e6o84p, null, null, _0023_003DzV8Lcc5p5_0024hWB, _0023_003DzVR_NB33ieggi);
		}

		public booleanFailureType SubdivideBy(IList<ICurve> contours, Brep parent)
		{
			if (Parametric != null)
			{
				Surface._0023_003Dz2u_3iw7LP_ic _0023_003Dz2u_3iw7LP_ic = new Surface._0023_003Dz2u_3iw7LP_ic
				{
					_0023_003Dz4wZe_0024Xg_003D = Parametric[0]
				};
				devDept.Eyeshot.Entities.Surface.Reparametrize(_0023_003Dz2u_3iw7LP_ic._0023_003Dz4wZe_0024Xg_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dz2AZ_kpw_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dza2Pq9PQ_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
				List<ICurve> list = new List<ICurve>();
				for (int i = 0; i < contours.Count; i++)
				{
					ICurve[] individualCurves = contours[i].GetIndividualCurves();
					int num = individualCurves.Length;
					for (int j = 0; j < num; j++)
					{
						if (_0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.DropCurve((ICurve)individualCurves[j].Clone(), out var parametric))
						{
							if (parametric != null)
							{
								TrimCurve trimCurve = parametric._0023_003DzmGgqdRaHiXdg((ICurve)individualCurves[j].Clone());
								bool flag = false;
								Plane plane = IsPlanar();
								if (plane != null && trimCurve.Edge is PlanarEntity)
								{
									flag = Plane.Intersection(((PlanarEntity)trimCurve.Edge).Plane, plane, out var _) == planeIntersectionType.Coincide;
								}
								if (flag)
								{
									list.Add(trimCurve);
									continue;
								}
								List<ICurve> contourList = _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.Trimming.ContourList;
								_0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.Trimming.ContourList = new List<ICurve> { trimCurve };
								_0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.RebuildEdge(0, 0, parent.RebuildTolerance);
								list.Add(_0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.Trimming.ContourList[0]);
								_0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.Trimming.contourList = contourList;
							}
							continue;
						}
						return booleanFailureType.Failed;
					}
				}
				if (list.Count == 0)
				{
					return booleanFailureType.NotIntersecting;
				}
				Dictionary<int, List<int>> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D = new Dictionary<int, List<int>>();
				List<int> _0023_003Dzx_GU4e6o84p = new List<int>();
				Dictionary<int, int> _0023_003DzV8Lcc5p5_0024hWB = new Dictionary<int, int>();
				Dictionary<int, int> _0023_003DzVR_NB33ieggi = new Dictionary<int, int>();
				return _0023_003Dz_00242tCFnhZs13OnckxuA_003D_003D(list, parent, _0023_003DzdBFS3nhATrKQ: true, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, _0023_003Dzx_GU4e6o84p, null, null, _0023_003DzV8Lcc5p5_0024hWB, _0023_003DzVR_NB33ieggi);
			}
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958099));
		}

		internal booleanFailureType _0023_003Dz_00242tCFnhZs13OnckxuA_003D_003D(Plane _0023_003Dzrgqz890sj_0024X9, Brep _0023_003Dzalvl9z8_003D, bool _0023_003DzdBFS3nhATrKQ, Dictionary<int, List<int>> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, List<int> _0023_003Dzx_GU4e6o84p3, List<Edge> _0023_003DzViGQVPM_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, Dictionary<int, int> _0023_003DzV8Lcc5p5_0024hWB, Dictionary<int, int> _0023_003DzVR_NB33ieggi)
		{
			if (planeAlreadySet && plane != null && Plane.Intersection(_0023_003Dzrgqz890sj_0024X9, plane, Utility._0023_003DzheSR8QM7q9ya, out var _) != planeIntersectionType.UniqueLine)
			{
				return booleanFailureType.NotIntersecting;
			}
			if (Parametric != null)
			{
				_ = Parametric.LongLength;
				Surface._0023_003Dz2u_3iw7LP_ic _0023_003Dz2u_3iw7LP_ic = new Surface._0023_003Dz2u_3iw7LP_ic
				{
					_0023_003Dz4wZe_0024Xg_003D = Parametric[0]
				};
				devDept.Eyeshot.Entities.Surface.Reparametrize(_0023_003Dz2u_3iw7LP_ic._0023_003Dz4wZe_0024Xg_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dz2AZ_kpw_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dza2Pq9PQ_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
				double rebuildTolerance = _0023_003Dzalvl9z8_003D.RebuildTolerance;
				_0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.ControlBoundingBox(out var min, out var max);
				Surface _0023_003Dz4wZe_0024Xg_003D = devDept.Eyeshot.Entities.Surface._0023_003DziDGe5xzc5KLyQpPYDk5PyHY_003D(_0023_003Dzrgqz890sj_0024X9, min, max);
				Surface._0023_003Dz2u_3iw7LP_ic _0023_003Dz2u_3iw7LP_ic2 = new Surface._0023_003Dz2u_3iw7LP_ic
				{
					_0023_003Dz4wZe_0024Xg_003D = _0023_003Dz4wZe_0024Xg_003D
				};
				devDept.Eyeshot.Entities.Surface.Reparametrize(_0023_003Dz2u_3iw7LP_ic2._0023_003Dz4wZe_0024Xg_003D, out _0023_003Dz2u_3iw7LP_ic2._0023_003Dz2AZ_kpw_003D, out _0023_003Dz2u_3iw7LP_ic2._0023_003Dza2Pq9PQ_003D, out _0023_003Dz2u_3iw7LP_ic2._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
				List<ICurve> list = new List<ICurve>();
				List<ICurve> _0023_003Dz1e137UCo69FgKytJgw_003D_003D = new List<ICurve>();
				devDept.Eyeshot.Entities.Surface._0023_003DzWybqssy4A7wSRKA21w_003D_003D(_0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003Dz2u_3iw7LP_ic2._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, list, _0023_003Dz1e137UCo69FgKytJgw_003D_003D, rebuildTolerance, _0023_003DzNa_3PCpJDrsG: false, out var _, out var _, out var _, _0023_003DzU9gB97bcrQk_0024: true);
				if (list.Count == 0)
				{
					return booleanFailureType.NotIntersecting;
				}
				return _0023_003Dz_00242tCFnhZs13OnckxuA_003D_003D(list, _0023_003Dzalvl9z8_003D, _0023_003DzdBFS3nhATrKQ, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, _0023_003Dzx_GU4e6o84p3, _0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003DzV8Lcc5p5_0024hWB, _0023_003DzVR_NB33ieggi);
			}
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958099));
		}

		internal booleanFailureType _0023_003Dz_00242tCFnhZs13OnckxuA_003D_003D(List<ICurve> _0023_003Dzwkc4gyXSPYcwB1NPBA_003D_003D, Brep _0023_003Dzalvl9z8_003D, bool _0023_003DzdBFS3nhATrKQ, Dictionary<int, List<int>> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, List<int> _0023_003Dzx_GU4e6o84p3, List<Edge> _0023_003DzViGQVPM_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, Dictionary<int, int> _0023_003DzV8Lcc5p5_0024hWB, Dictionary<int, int> _0023_003DzVR_NB33ieggi)
		{
			if (_0023_003DzViGQVPM_003D == null)
			{
				_0023_003DzViGQVPM_003D = _0023_003Dzalvl9z8_003D.Edges.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzeI97KeNSv6onsMGDQwxIMfYai66a).ToList();
			}
			if (_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D == null)
			{
				_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D = _0023_003Dzalvl9z8_003D.Vertices.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzA51uabP61K9xMo_GQqFqH46ZHECZ).ToList();
			}
			if (Parametric != null && Parametric.Length != 0)
			{
				int num = -1;
				List<Face> list = _0023_003Dzalvl9z8_003D._0023_003DzuHbAxNSGQE3z(_0023_003Dzalvl9z8_003D.Faces, _0023_003Dzu9oxwJ_zKlMt: false).ToList();
				for (int i = 0; i < _0023_003Dzalvl9z8_003D.Faces.Length; i++)
				{
					if (_0023_003Dzalvl9z8_003D.Faces[i] == this)
					{
						num = i;
					}
					_0023_003DzH_00244LxjBICrXYBxcvYXYFsGI_003D(_0023_003Dzalvl9z8_003D.Faces[i], list[i], _0023_003Dz0mIPc9VROWxZ: false, null, 0.0);
					_0023_003DzT4na_9HtOkWw(_0023_003Dzalvl9z8_003D.Faces[i], list[i]);
				}
				Dictionary<int, Dictionary<double, int>> dictionary = new Dictionary<int, Dictionary<double, int>>();
				Dictionary<int, List<int>> dictionary2 = new Dictionary<int, List<int>>();
				Surface._0023_003Dz2u_3iw7LP_ic _0023_003Dz2u_3iw7LP_ic = new Surface._0023_003Dz2u_3iw7LP_ic
				{
					_0023_003Dz4wZe_0024Xg_003D = (Surface)Parametric[0].Clone()
				};
				devDept.Eyeshot.Entities.Surface.Reparametrize(_0023_003Dz2u_3iw7LP_ic._0023_003Dz4wZe_0024Xg_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dz2AZ_kpw_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dza2Pq9PQ_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
				Surface _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D = _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
				double _0023_003Dz85DwsjHHsAwG = _0023_003Dzalvl9z8_003D.RebuildTolerance;
				List<ICurve> list2 = new List<ICurve>(_0023_003Dzwkc4gyXSPYcwB1NPBA_003D_003D.Count);
				List<ICurve> list3 = new List<ICurve>(_0023_003Dzwkc4gyXSPYcwB1NPBA_003D_003D.Count);
				int num2 = _0023_003Dzalvl9z8_003D.Edges.Length + _0023_003Dzwkc4gyXSPYcwB1NPBA_003D_003D.Count + 1;
				for (int j = 0; j < _0023_003Dzwkc4gyXSPYcwB1NPBA_003D_003D.Count; j++)
				{
					if (_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D._0023_003DzZf4zvJoP0u8G(_0023_003Dzwkc4gyXSPYcwB1NPBA_003D_003D[j], out var _, out var _0023_003Dz93D7WaCPl_0024u, _0023_003DzRAS4kB6WIA5zYp5K0eecf_00240_003D: false, null, _0023_003Dzb9U1KHmIZGGP: false, _0023_003Dzf5uydyTGDFr_0024: false))
					{
						if (_0023_003Dz93D7WaCPl_0024u != -1)
						{
							_0023_003Dzalvl9z8_003D.Edges[_0023_003Dz93D7WaCPl_0024u].SplitStatus = SplitEdgeStatus.OnBothEdges;
						}
						continue;
					}
					TrimCurve trimCurve = (TrimCurve)_0023_003Dzwkc4gyXSPYcwB1NPBA_003D_003D[j];
					trimCurve.FromBooleanIntersection = true;
					trimCurve.EdgeIndex = num2 + j;
					list3.Add(trimCurve);
					TrimCurve trimCurve2 = (TrimCurve)trimCurve.Clone();
					trimCurve2.Reverse();
					list2.Add(trimCurve2);
				}
				if (list3.Count == 0)
				{
					return booleanFailureType.NotIntersecting;
				}
				List<Surface> _0023_003DzZE9fb_0024M_003D;
				int num3 = _0023_003Dzalvl9z8_003D._0023_003DzRyYpgCwIajnh5_0024JDssSJlQY_003D(Parametric[0], list3, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, _0023_003DzV8Lcc5p5_0024hWB, out _0023_003Dz85DwsjHHsAwG, out _0023_003DzZE9fb_0024M_003D);
				List<Surface> _0023_003DzZE9fb_0024M_003D2;
				int num4 = _0023_003Dzalvl9z8_003D._0023_003DzRyYpgCwIajnh5_0024JDssSJlQY_003D(Parametric[0], list2, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, _0023_003DzV8Lcc5p5_0024hWB, out _0023_003Dz85DwsjHHsAwG, out _0023_003DzZE9fb_0024M_003D2);
				_0023_003DzZE9fb_0024M_003D.AddRange(_0023_003DzZE9fb_0024M_003D2);
				if (num3 == -2 || num4 == -2)
				{
					return booleanFailureType.Failed;
				}
				for (int k = 0; k < list3.Count; k++)
				{
					TrimCurve trimCurve3 = (TrimCurve)list3[k];
					trimCurve3.FaceInfo = new _0023_003DzKfMGQQU_003D
					{
						_0023_003DzLJVtPYc_003D = num
					};
					ICurve edge = trimCurve3.Edge;
					int num5 = -1;
					int num6 = -1;
					Point3D startPoint = edge.StartPoint;
					Point3D endPoint = edge.EndPoint;
					Vertex vertex = new Vertex(startPoint.X, startPoint.Y, startPoint.Z);
					num5 = _0023_003DzYrt453tI69Ce(vertex, _0023_003Dzalvl9z8_003D, trimCurve3, _0023_003DzViGQVPM_003D, dictionary, _0023_003DzVR_NB33ieggi, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003DzMOzZi0xOKVJU: false);
					if (num5 == -1)
					{
						num5 = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count;
						_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(vertex);
					}
					Vertex vertex2 = new Vertex(endPoint.X, endPoint.Y, endPoint.Z);
					num6 = _0023_003DzYrt453tI69Ce(vertex2, _0023_003Dzalvl9z8_003D, trimCurve3, _0023_003DzViGQVPM_003D, dictionary, _0023_003DzVR_NB33ieggi, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003DzMOzZi0xOKVJU: false);
					if (num6 == -1)
					{
						num6 = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count;
						_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(vertex2);
					}
					int num7 = _0023_003DzbIDY9BOTPqfc(new Edge(edge, num5, num6), _0023_003DzViGQVPM_003D, _0023_003Dz85DwsjHHsAwG, null, null);
					if (!dictionary2.ContainsKey(trimCurve3.EdgeIndex))
					{
						dictionary2.Add(trimCurve3.EdgeIndex, new List<int>());
					}
					dictionary2[trimCurve3.EdgeIndex].Add(num7);
					trimCurve3.EdgeIndex = num7;
				}
				_0023_003DzJiYrREIJy046(dictionary, _0023_003DzViGQVPM_003D, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, _0023_003Dz_d_002406W8syS3trhyv9w_003D_003D: true);
				Loop[][] array = new Loop[_0023_003DzZE9fb_0024M_003D.Count][];
				for (int l = 0; l < _0023_003DzZE9fb_0024M_003D.Count; l++)
				{
					Region trimming = _0023_003DzZE9fb_0024M_003D[l].Trimming;
					int num8 = l + (list.Count - 1);
					List<Loop> list4 = new List<Loop>(trimming.ContourList.Count);
					for (int m = 0; m < trimming.ContourList.Count; m++)
					{
						List<ICurve> list5 = trimming.ContourList[m].GetIndividualCurves().ToList();
						List<OrientedEdge> list6 = new List<OrientedEdge>(list5.Count);
						int num9 = 0;
						int num10 = 0;
						while (num10 < list5.Count && num9 < Loops.Length)
						{
							bool flag = false;
							OrientedEdge[] segments = Loops[num9].Segments;
							TrimCurve _0023_003Dz_0024KG_KlTLOjdx = (TrimCurve)list5[num10];
							int _0023_003DzpKx72ZfGKVdp = ((ICurve)_0023_003Dz_0024KG_KlTLOjdx).EdgeIndex;
							if (((ICurve)_0023_003Dz_0024KG_KlTLOjdx).EdgeIndex == -1)
							{
								if (_0023_003Dz_0024KG_KlTLOjdx.Edge.Length() > _0023_003Dzalvl9z8_003D.RebuildTolerance)
								{
									return booleanFailureType.Failed;
								}
								num10++;
								num9 = 0;
								continue;
							}
							if (_0023_003Dz_0024KG_KlTLOjdx.FromBooleanIntersection)
							{
								if (dictionary2.ContainsKey(_0023_003Dz_0024KG_KlTLOjdx.EdgeIndex))
								{
									Edge _0023_003DzXQ05_0024cQM5wVN = null;
									_0023_003Dzalvl9z8_003D._0023_003DzUGnDRo3eVm3pt4_33A_003D_003D(_0023_003Dz_0024KG_KlTLOjdx, dictionary2[_0023_003DzpKx72ZfGKVdp], _0023_003DzV8Lcc5p5_0024hWB, _0023_003DzViGQVPM_003D, _0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003DzVR_NB33ieggi, _0023_003Dz85DwsjHHsAwG, ref _0023_003DzpKx72ZfGKVdp, ref _0023_003DzXQ05_0024cQM5wVN);
									if (_0023_003Dz_0024KG_KlTLOjdx.EdgeIndex == _0023_003DzpKx72ZfGKVdp)
									{
										return booleanFailureType.Failed;
									}
								}
								else if (_0023_003DzpKx72ZfGKVdp > _0023_003DzViGQVPM_003D.Count - 1)
								{
									return booleanFailureType.Failed;
								}
								int num11 = _0023_003DzpKx72ZfGKVdp;
								bool sense = Point3D.Distance(_0023_003Dz_0024KG_KlTLOjdx.Edge.StartPoint, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzViGQVPM_003D[num11].StartPointIndex]) < _0023_003Dz85DwsjHHsAwG && Vector3D.AreCoincident(_0023_003Dz_0024KG_KlTLOjdx.Edge.StartTangent, _0023_003DzViGQVPM_003D[num11].Curve.StartTangent);
								OrientedEdge item = new OrientedEdge(num11, sense);
								list6.Add(item);
								flag = true;
								_0023_003Dz_0024KG_KlTLOjdx.FromBooleanIntersection = false;
								_0023_003Dz_0024KG_KlTLOjdx.EdgeIndex = num11;
								if (_0023_003DzViGQVPM_003D[num11].Parents == null)
								{
									_0023_003DzViGQVPM_003D[num11].Parents = new int[2];
									if (l != 0)
									{
										_0023_003DzViGQVPM_003D[num11].Parents[0] = num8;
									}
									else
									{
										_0023_003DzViGQVPM_003D[num11].Parents[0] = num;
									}
								}
								else if (l != 0)
								{
									_0023_003DzViGQVPM_003D[num11].Parents[1] = num8;
								}
								else
								{
									_0023_003DzViGQVPM_003D[num11].Parents[1] = num;
								}
							}
							else
							{
								for (int n = 0; n < segments.Length; n++)
								{
									if (segments[n].CurveIndex != _0023_003DzpKx72ZfGKVdp && (!_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D.ContainsKey(_0023_003DzpKx72ZfGKVdp) || !_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D[_0023_003DzpKx72ZfGKVdp].Contains(segments[n].CurveIndex)))
									{
										continue;
									}
									OrientedEdge orientedEdge = (segments[n] = segments[n]);
									flag = true;
									int num12 = -1;
									if (_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D.ContainsKey(_0023_003DzpKx72ZfGKVdp))
									{
										if (_0023_003Dzalvl9z8_003D.Edges[_0023_003DzpKx72ZfGKVdp].Parents.Length > 1)
										{
											if (_0023_003DzViGQVPM_003D[_0023_003DzpKx72ZfGKVdp].Parents[1] < _0023_003Dzalvl9z8_003D.Faces.Length && _0023_003Dzalvl9z8_003D.Faces[_0023_003Dzalvl9z8_003D.Edges[_0023_003DzpKx72ZfGKVdp].Parents[1]] != this)
											{
												int num13 = _0023_003Dzalvl9z8_003D.Edges[_0023_003DzpKx72ZfGKVdp].Parents[1];
												if (!_0023_003Dzx_GU4e6o84p3.Contains(num13) && !_0023_003Dzalvl9z8_003D.Faces[num13].Visited)
												{
													_0023_003Dzx_GU4e6o84p3.Add(num13);
												}
											}
											if (_0023_003DzViGQVPM_003D[_0023_003DzpKx72ZfGKVdp].Parents[0] < _0023_003Dzalvl9z8_003D.Faces.Length && _0023_003Dzalvl9z8_003D.Faces[_0023_003DzViGQVPM_003D[_0023_003DzpKx72ZfGKVdp].Parents[0]] != this)
											{
												int num14 = _0023_003Dzalvl9z8_003D.Edges[_0023_003DzpKx72ZfGKVdp].Parents[0];
												if (!_0023_003Dzx_GU4e6o84p3.Contains(num14) && !_0023_003Dzalvl9z8_003D.Faces[num14].Visited)
												{
													_0023_003Dzx_GU4e6o84p3.Add(num14);
												}
											}
										}
										_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D.TryGetValue(_0023_003DzpKx72ZfGKVdp, out var value);
										Edge _0023_003DzXQ05_0024cQM5wVN2 = null;
										num12 = _0023_003Dzalvl9z8_003D._0023_003DzUGnDRo3eVm3pt4_33A_003D_003D(_0023_003Dz_0024KG_KlTLOjdx, value, _0023_003DzV8Lcc5p5_0024hWB, _0023_003DzViGQVPM_003D, _0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003DzVR_NB33ieggi, _0023_003Dz85DwsjHHsAwG, ref _0023_003DzpKx72ZfGKVdp, ref _0023_003DzXQ05_0024cQM5wVN2);
										if (num12 == -1)
										{
											bool _0023_003DzhWkkZUdwNlwFcLySIQ_003D_003D = false;
											if (!_0023_003DzVpPOFMXqWVaoPGRXMQ_003D_003D(_0023_003DzViGQVPM_003D, value, num10, _0023_003DzZE9fb_0024M_003D[l], list5, _0023_003DzWkEiu3E_003D: false, ref _0023_003Dz_0024KG_KlTLOjdx, ref _0023_003DzhWkkZUdwNlwFcLySIQ_003D_003D))
											{
												return booleanFailureType.Failed;
											}
											num12 = _0023_003Dzalvl9z8_003D._0023_003DzUGnDRo3eVm3pt4_33A_003D_003D(_0023_003Dz_0024KG_KlTLOjdx, value, _0023_003DzV8Lcc5p5_0024hWB, _0023_003DzViGQVPM_003D, _0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003DzVR_NB33ieggi, _0023_003Dz85DwsjHHsAwG, ref _0023_003DzpKx72ZfGKVdp, ref _0023_003DzXQ05_0024cQM5wVN2);
											if (num12 == -1)
											{
												return booleanFailureType.Failed;
											}
											if (_0023_003DzhWkkZUdwNlwFcLySIQ_003D_003D)
											{
												int count = list5.Count;
												ICurve[] array2 = new ICurve[count];
												for (int num15 = 0; num15 < count; num15++)
												{
													Entity entity = (Entity)list5[num15].Clone();
													entity.TranslationID = ((Entity)list5[num15]).TranslationID;
													((ICurve)entity).EdgeIndex = list5[num15].EdgeIndex;
													((ICurve)entity).FromBooleanIntersection = list5[num15].FromBooleanIntersection;
													array2[num15] = (ICurve)entity;
												}
												trimming.ContourList[m] = Utility.SmartAdd(array2);
												list5 = trimming.ContourList[m].GetIndividualCurves().ToList();
											}
										}
									}
									else
									{
										num12 = orientedEdge.CurveIndex;
									}
									if (l != 0)
									{
										if (_0023_003DzViGQVPM_003D[num12].Parents[0] < _0023_003Dzalvl9z8_003D.Faces.Length && _0023_003Dzalvl9z8_003D.Faces[_0023_003DzViGQVPM_003D[num12].Parents[0]] == this)
										{
											_0023_003DzViGQVPM_003D[num12].Parents[0] = num8;
										}
										else if (_0023_003DzViGQVPM_003D[num12].Parents[1] < _0023_003Dzalvl9z8_003D.Faces.Length && _0023_003Dzalvl9z8_003D.Faces[_0023_003DzViGQVPM_003D[num12].Parents[1]] == this)
										{
											_0023_003DzViGQVPM_003D[num12].Parents[1] = num8;
										}
									}
									_0023_003DzViGQVPM_003D[num12].Visited = true;
									_0023_003Dz_0024KG_KlTLOjdx.EdgeIndex = num12;
									_0023_003Dz_0024KG_KlTLOjdx.Edge.EdgeIndex = num12;
									bool sense2 = Point3D.Distance(_0023_003Dz_0024KG_KlTLOjdx.Edge.StartPoint, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzViGQVPM_003D[num12].StartPointIndex]) < _0023_003Dz85DwsjHHsAwG && Vector3D.AreCoincident(_0023_003Dz_0024KG_KlTLOjdx.Edge.StartTangent, _0023_003DzViGQVPM_003D[num12].Curve.StartTangent);
									list6.Add(new OrientedEdge(num12, sense2));
									break;
								}
							}
							if (flag)
							{
								num10++;
								num9 = 0;
							}
							else
							{
								num9++;
							}
						}
						if (list6.Count > 0)
						{
							Loop item2 = new Loop(list6.ToArray(), sense: true);
							list4.Add(item2);
						}
						array[l] = list4.ToArray();
					}
				}
				if (array == null)
				{
					return booleanFailureType.Failed;
				}
				for (int num16 = 0; num16 < array.Length; num16++)
				{
					Loop[] loops = array[num16];
					if (num16 == 0)
					{
						list[num].Loops = loops;
						list[num]._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(new Surface[1] { _0023_003DzZE9fb_0024M_003D[num16] });
						list[num].Visited = true;
						continue;
					}
					AnalyticSurf surface = (AnalyticSurf)Surface.Clone();
					Plane plane = ((this.plane != null) ? ((Plane)this.plane.Clone()) : null);
					Face face = new Face(surface, loops, Sense);
					face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(new Surface[1] { _0023_003DzZE9fb_0024M_003D[num16] });
					face.planeAlreadySet = planeAlreadySet;
					face.plane = plane;
					Face face2 = face;
					face2.Visited = true;
					face2.Color = list[num].Color;
					face2.MaterialName = list[num].MaterialName;
					face2.FaceData = list[num].FaceData;
					list.Add(face2);
				}
				Visited = true;
				foreach (int item3 in _0023_003Dzx_GU4e6o84p3)
				{
					if (!list[item3].Visited)
					{
						list[item3]._0023_003DzD3Dj6Qt_0024SLNN(_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, _0023_003DzViGQVPM_003D, list[item3].Parametric[0], _0023_003DzdBFS3nhATrKQ);
						if (_0023_003DzdBFS3nhATrKQ)
						{
							list[item3]._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(null);
						}
					}
				}
				_0023_003Dzalvl9z8_003D.Edges = _0023_003DzViGQVPM_003D.ToArray();
				_0023_003Dzalvl9z8_003D.Faces = list.ToArray();
				_0023_003Dzalvl9z8_003D.Vertices = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.ToArray();
				if (_0023_003DzdBFS3nhATrKQ)
				{
					_0023_003Dz8VkxvzXXGxA_0024(_0023_003Dzalvl9z8_003D.Vertices, _0023_003Dzalvl9z8_003D.Edges, _0023_003Dzalvl9z8_003D.Faces, _0023_003Dzalvl9z8_003D.Inners, _0023_003DzLuJVbec_003D: false);
					_0023_003Dzalvl9z8_003D.Rebuild(0.0, soft: true);
				}
				return booleanFailureType.Success;
			}
			return booleanFailureType.Failed;
		}

		private static void _0023_003Dz1EjP9z5BEiiE(List<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Edge _0023_003DzTx2aqr8_003D, int _0023_003DzAJYZcKw_003D, int _0023_003DzqhsKlJc_003D)
		{
			Vertex vertex = (Vertex)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D.StartPointIndex];
			if (!vertex._0023_003Dz8hR_kalXOG3N(_0023_003DzAJYZcKw_003D, _0023_003DzqhsKlJc_003D))
			{
				int[] array = vertex.Parents;
				Array.Resize(ref array, array.Length + 1);
				array[^1] = _0023_003DzqhsKlJc_003D;
			}
			Vertex vertex2 = (Vertex)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzTx2aqr8_003D.EndPointIndex];
			if (!vertex2._0023_003Dz8hR_kalXOG3N(_0023_003DzAJYZcKw_003D, _0023_003DzqhsKlJc_003D))
			{
				int[] array2 = vertex2.Parents;
				Array.Resize(ref array2, array2.Length + 1);
				array2[^1] = _0023_003DzqhsKlJc_003D;
			}
		}

		internal void _0023_003DzD3Dj6Qt_0024SLNN(Dictionary<int, List<int>> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, List<Edge> _0023_003DzViGQVPM_003D, Surface _0023_003DzF7GfYSI_003D, bool _0023_003DzJTAR_ngPMCK4)
		{
			for (int i = 0; i < Loops.Length; i++)
			{
				List<OrientedEdge> list = new List<OrientedEdge>(Loops[i].Segments.Length);
				for (int j = 0; j < Loops[i].Segments.Length; j++)
				{
					if (_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D.ContainsKey(Loops[i].Segments[j].CurveIndex))
					{
						List<int> list2 = _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D[Loops[i].Segments[j].CurveIndex];
						bool flag = false;
						if (Loops[i].Segments[j].Sense)
						{
							int num = (j + (list2.Count - 1)) % Loops[i].Segments.Length;
							if (Loops[i].Segments.Length < list2.Count || Loops[i].Segments[num].CurveIndex != list2[list2.Count - 1])
							{
								flag = true;
								for (int k = 0; k < list2.Count; k++)
								{
									list.Add(new OrientedEdge(list2[k], Loops[i].Segments[j].Sense));
								}
							}
							else
							{
								list.Add(Loops[i].Segments[j]);
							}
						}
						else
						{
							int num2 = ((j == 0) ? (Loops[i].Segments.Length - (list2.Count - 1)) : (j - (list2.Count - 1)));
							if (num2 < 0 || Loops[i].Segments[num2].CurveIndex != list2[list2.Count - 1])
							{
								flag = true;
								for (int num3 = list2.Count - 1; num3 >= 0; num3--)
								{
									list.Add(new OrientedEdge(list2[num3], Loops[i].Segments[j].Sense));
								}
							}
							else
							{
								list.Add(Loops[i].Segments[j]);
							}
						}
						if (!(_0023_003DzJTAR_ngPMCK4 && flag))
						{
							continue;
						}
						bool _0023_003DzhWkkZUdwNlwFcLySIQ_003D_003D = false;
						List<ICurve> list3 = Parametric[0].Trimming.ContourList[0].GetIndividualCurves().ToList();
						TrimCurve _0023_003Dz_0024KG_KlTLOjdx = null;
						int _0023_003DzPpTz1gk_003D = -1;
						for (int l = 0; l < list3.Count; l++)
						{
							if (list3[l].EdgeIndex == Loops[i].Segments[j].CurveIndex)
							{
								_0023_003Dz_0024KG_KlTLOjdx = (TrimCurve)list3[l];
								_0023_003DzPpTz1gk_003D = l;
								break;
							}
						}
						_0023_003DzVpPOFMXqWVaoPGRXMQ_003D_003D(_0023_003DzViGQVPM_003D, list2, _0023_003DzPpTz1gk_003D, _0023_003DzF7GfYSI_003D, list3, _0023_003DzWkEiu3E_003D: true, ref _0023_003Dz_0024KG_KlTLOjdx, ref _0023_003DzhWkkZUdwNlwFcLySIQ_003D_003D);
						if (_0023_003DzhWkkZUdwNlwFcLySIQ_003D_003D)
						{
							Parametric[0].Trimming.ContourList[0] = new CompositeCurve(list3);
						}
					}
					else
					{
						list.Add(Loops[i].Segments[j]);
					}
				}
				Loops[i] = new Loop(list.ToArray(), Loops[i].Sense);
			}
		}

		public void GetLoopsControlBoundingBox(IList<Edge> edges, out Point3D min, out Point3D max)
		{
			min = Point3D.MaxValue;
			max = Point3D.MinValue;
			Loop[] loops = Loops;
			for (int i = 0; i < loops.Length; i++)
			{
				OrientedEdge[] segments = loops[i].Segments;
				for (int j = 0; j < segments.Length; j++)
				{
					OrientedEdge orientedEdge = segments[j];
					edges[orientedEdge.CurveIndex].Curve.GetNurbsForm().ControlBoundingBox(out var min2, out var max2);
					if (min2.X < min.X)
					{
						min.X = min2.X;
					}
					if (max2.X > max.X)
					{
						max.X = max2.X;
					}
					if (min2.Y < min.Y)
					{
						min.Y = min2.Y;
					}
					if (max2.Y > max.Y)
					{
						max.Y = max2.Y;
					}
					if (min2.Z < min.Z)
					{
						min.Z = min2.Z;
					}
					if (max2.Z > max.Z)
					{
						max.Z = max2.Z;
					}
				}
			}
		}

		public bool InitDrawTessellation()
		{
			drawTessellation?.Dispose();
			drawTessellation = _0023_003DzldFSSlJWg0l_0024();
			return drawTessellation != null;
		}

		private FastMesh _0023_003DzldFSSlJWg0l_0024()
		{
			Surface._0023_003Dzt0DfTGIEHrBGGDuaFsPivuA_003D();
			if (Tessellation.PointArray.Length < 1)
			{
				return null;
			}
			if (!Surface.collapsedEdges._0023_003Dzxiv0UU0_003D())
			{
				return null;
			}
			float[] pointArray = Tessellation.PointArray;
			List<float> list = new List<float>(pointArray);
			List<float> list2 = new List<float>(Tessellation.TextureCoordsArray);
			List<float> list3 = new List<float>(Tessellation.NormalArray);
			int[] array = new int[Tessellation.TriangleArray.Length];
			Array.Copy(Tessellation.TriangleArray, 0, array, 0, Tessellation.TriangleArray.Length);
			if (Tessellation.BoxMax == null)
			{
				Tessellation.UpdateBoundingBox(null);
			}
			double _0023_003DzbdEewMMmMxDg = Tessellation.BoxSize.Diagonal * Utility._0023_003Dzjyaz_Vfaky9X;
			Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
			for (int i = 0; i < pointArray.Length; i += 3)
			{
				float _0023_003DzBJFJHwk_003D = pointArray[i];
				float _0023_003Dz40R7bAU_003D = pointArray[i + 1];
				float _0023_003DzId5C3LA_003D = pointArray[i + 2];
				if (_0023_003DzwTmJvDg_003D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzId5C3LA_003D, _0023_003DzbdEewMMmMxDg))
				{
					dictionary.Add(i / 3, value: false);
				}
			}
			if (dictionary.Count < 1)
			{
				return null;
			}
			for (int j = 0; j < Tessellation.TriangleArray.Length; j += 3)
			{
				int _0023_003Dz5Azd7L8_003D = Tessellation.TriangleArray[j];
				int _0023_003Dz5Azd7L8_003D2 = Tessellation.TriangleArray[j + 1];
				int _0023_003Dz5Azd7L8_003D3 = Tessellation.TriangleArray[j + 2];
				_0023_003DzrvhA_0024DjTAzKE(ref array[j], _0023_003Dz5Azd7L8_003D3, dictionary, list, list2, list3);
				_0023_003DzrvhA_0024DjTAzKE(ref array[j + 1], _0023_003Dz5Azd7L8_003D, dictionary, list, list2, list3);
				_0023_003DzrvhA_0024DjTAzKE(ref array[j + 2], _0023_003Dz5Azd7L8_003D2, dictionary, list, list2, list3);
			}
			return new FastMesh(list.ToArray(), array.ToArray(), list3.ToArray(), list2.ToArray());
		}

		private static void _0023_003DzrvhA_0024DjTAzKE(ref int _0023_003Dz77g161c_003D, int _0023_003Dz5Azd7L8_003D, Dictionary<int, bool> _0023_003DzChjUNqgYpt7i, List<float> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, List<float> _0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D, List<float> _0023_003DzztJY0_0024dXEFMk)
		{
			if (_0023_003DzChjUNqgYpt7i.ContainsKey(_0023_003Dz77g161c_003D))
			{
				float num = _0023_003DzztJY0_0024dXEFMk[_0023_003Dz5Azd7L8_003D * 3];
				float num2 = _0023_003DzztJY0_0024dXEFMk[_0023_003Dz5Azd7L8_003D * 3 + 1];
				float num3 = _0023_003DzztJY0_0024dXEFMk[_0023_003Dz5Azd7L8_003D * 3 + 2];
				if (_0023_003DzChjUNqgYpt7i[_0023_003Dz77g161c_003D])
				{
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz77g161c_003D * 3]);
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz77g161c_003D * 3 + 1]);
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz77g161c_003D * 3 + 2]);
					_0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D.Add(_0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D[_0023_003Dz77g161c_003D * 2]);
					_0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D.Add(_0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D[_0023_003Dz77g161c_003D * 2 + 1]);
					_0023_003DzztJY0_0024dXEFMk.Add(num);
					_0023_003DzztJY0_0024dXEFMk.Add(num2);
					_0023_003DzztJY0_0024dXEFMk.Add(num3);
					_0023_003Dz77g161c_003D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count / 3 - 1;
				}
				else
				{
					_0023_003DzChjUNqgYpt7i[_0023_003Dz77g161c_003D] = true;
					_0023_003DzztJY0_0024dXEFMk[_0023_003Dz77g161c_003D * 3] = num;
					_0023_003DzztJY0_0024dXEFMk[_0023_003Dz77g161c_003D * 3 + 1] = num2;
					_0023_003DzztJY0_0024dXEFMk[_0023_003Dz77g161c_003D * 3 + 2] = num3;
				}
			}
		}

		private bool _0023_003DzwTmJvDg_003D(float _0023_003DzBJFJHwk_003D, float _0023_003Dz40R7bAU_003D, float _0023_003DzId5C3LA_003D, double _0023_003DzbdEewMMmMxDg)
		{
			Point3D point3D = new Point3D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzId5C3LA_003D);
			for (int i = 0; i < 4; i++)
			{
				Point3D point3D2 = Surface.collapsedEdges.Points[i];
				if (point3D2 != null && !Surface.collapsedEdges.Poles[i] && point3D.DistanceTo(point3D2) < _0023_003DzbdEewMMmMxDg)
				{
					return true;
				}
			}
			return false;
		}

		public Plane GetSketchPlane()
		{
			Plane obj = IsPlanar();
			if (obj == null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958317));
			}
			obj.Origin = obj.PointAt(obj.Project(Point3D.Origin));
			return obj;
		}

		public SketchEntity GetSketch()
		{
			return new SketchEntity(GetSketchPlane());
		}

		public Point3D[] IntersectWith(ICurve curve, bool enableBrepBorder)
		{
			List<Point3D> list = new List<Point3D>();
			_0023_003DzGKZuR_4q838u(curve, list, enableBrepBorder);
			return list.ToArray();
		}

		internal void _0023_003DzGKZuR_4q838u(ICurve _0023_003Dz8fpRyMu9aKjE, List<Point3D> _0023_003DzzOAzCouj9CuB, bool _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D)
		{
			Surface[] parametric = Parametric;
			for (int i = 0; i < parametric.Length; i++)
			{
				Point3D[] collection = _0023_003Dzj4BwwHpJqX0aXcrqKxfpae8BS9rB8XpyPw_003D_003D._0023_003Dz7XOXgvOEVlaU(parametric[i], _0023_003Dz8fpRyMu9aKjE, Surface, Sense, _0023_003DzX5UoPdYta6PN3aRrrg_003D_003D, null, null, null, 0.0, _0023_003DznbZoSmWt0NXt6IJtqNzBrqOnUXC7: true);
				_0023_003DzzOAzCouj9CuB.AddRange(collection);
			}
		}

		ConstraintData IMateable.GetConstraintData(Stack<BlockReference> parents)
		{
			return ConstraintData.GetFromAnalyticSurf(Surface, parents);
		}
	}

	[Serializable]
	public class Loop : ICloneable
	{
		public bool Sense;

		public OrientedEdge[] Segments;

		public Loop(OrientedEdge[] segments)
		{
			Segments = segments;
			Sense = true;
		}

		public Loop(OrientedEdge[] segments, bool sense)
		{
			Segments = segments;
			Sense = sense;
		}

		protected Loop(Loop another)
		{
			Segments = new OrientedEdge[another.Segments.Length];
			for (int i = 0; i < another.Segments.Length; i++)
			{
				Segments[i] = another.Segments[i];
			}
			Sense = another.Sense;
		}

		public Loop(SerializationInfo info, StreamingContext ctxt)
		{
			Segments = (OrientedEdge[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958214), typeof(OrientedEdge[]));
			Sense = info.GetBoolean(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958069));
		}

		public virtual object Clone()
		{
			return new Loop(this);
		}

		public virtual BrepLoopSurrogate ConvertToSurrogate()
		{
			return new BrepLoopSurrogate(this);
		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958214), Segments);
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958069), Sense);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			OrientedEdge[] segments = Segments;
			for (int i = 0; i < segments.Length; i++)
			{
				OrientedEdge orientedEdge = segments[i];
				int curveIndex = orientedEdge.CurveIndex;
				stringBuilder.Append(curveIndex + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108));
			}
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958963), stringBuilder, Sense);
		}

		public XElement GetXElement()
		{
			XElement xElement = new XElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958954), new XAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958069), Convert.ToInt16(Sense)));
			OrientedEdge[] segments = Segments;
			for (int i = 0; i < segments.Length; i++)
			{
				OrientedEdge orientedEdge = segments[i];
				xElement.Add(new XElement(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958931), new XAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958913), orientedEdge.CurveIndex), new XAttribute(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958069), Convert.ToInt16(orientedEdge.Sense))));
			}
			return xElement;
		}

		internal OrientedEdge[] _0023_003DzYcrVfiECm8tMdEgw8nGE7Hg_003D()
		{
			if (!Sense)
			{
				_0023_003Dz0wcqTpk_003D();
			}
			return Segments;
		}

		internal void _0023_003Dz0wcqTpk_003D()
		{
			OrientedEdge[] array = Enumerable.Reverse(Segments).ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new OrientedEdge(array[i].CurveIndex, !array[i].Sense);
			}
			Segments = array;
			Sense = true;
		}

		public bool IsValid(Brep brep, StringBuilder log = null)
		{
			if (Segments.Length == 0)
			{
				log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958926));
				return false;
			}
			if (Segments.Length == 1)
			{
				Edge edge = brep.Edges[Segments[0].CurveIndex];
				return edge.StartPointIndex == edge.EndPointIndex;
			}
			int num = ((!Sense) ? (Segments.Length - 1) : 0);
			bool flag = true;
			int num2 = -1;
			int num3 = -1;
			OrientedEdge orientedEdge;
			Edge edge2;
			do
			{
				orientedEdge = Segments[num];
				edge2 = brep._edges[orientedEdge.CurveIndex];
				if (flag)
				{
					num2 = ((orientedEdge.Sense == Sense) ? edge2.StartPointIndex : edge2.EndPointIndex);
					flag = false;
				}
				else
				{
					int num4 = ((orientedEdge.Sense == Sense) ? edge2.StartPointIndex : edge2.EndPointIndex);
					if (num4 != num3)
					{
						log?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958887), num3, num4));
						return false;
					}
				}
				num3 = ((orientedEdge.Sense == Sense) ? edge2.EndPointIndex : edge2.StartPointIndex);
				num = (Sense ? (num + 1) : (num - 1));
			}
			while (Sense ? (num < Segments.Length) : (num >= 0));
			num = (Sense ? (num - 1) : (num + 1));
			orientedEdge = Segments[num];
			edge2 = brep._edges[orientedEdge.CurveIndex];
			num3 = ((orientedEdge.Sense == Sense) ? edge2.EndPointIndex : edge2.StartPointIndex);
			if (num3 != num2)
			{
				log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959087));
				return false;
			}
			return true;
		}
	}

	[Serializable]
	public struct OrientedEdge(int curveIndex, bool sense = true)
	{
		public bool Sense = sense;

		public int CurveIndex = curveIndex;

		public override string ToString()
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959022), CurveIndex, Sense);
		}

		public BrepOrientedEdgeSurrogate ConvertToSurrogate()
		{
			return new BrepOrientedEdgeSurrogate(this);
		}

		public ICurve GetOrientedCurve(IList<Edge> edges)
		{
			ICurve curve = (ICurve)edges[CurveIndex].Curve.Clone();
			if (!Sense)
			{
				curve.Reverse();
			}
			return curve;
		}

		public Point3D GetStartVertex(IList<Point3D> vertices, IList<Edge> edges)
		{
			return vertices[Sense ? edges[CurveIndex].StartPointIndex : edges[CurveIndex].EndPointIndex];
		}

		public Point3D GetStartPoint(IList<Edge> edges)
		{
			if (!Sense)
			{
				return edges[CurveIndex].Curve.EndPoint;
			}
			return edges[CurveIndex].Curve.StartPoint;
		}

		public Point3D GetEndVertex(IList<Point3D> vertices, IList<Edge> edges)
		{
			return vertices[Sense ? edges[CurveIndex].EndPointIndex : edges[CurveIndex].StartPointIndex];
		}

		public Point3D GetEndPoint(IList<Edge> edges)
		{
			if (!Sense)
			{
				return edges[CurveIndex].Curve.StartPoint;
			}
			return edges[CurveIndex].Curve.EndPoint;
		}
	}

	internal enum SplitEdgeStatus
	{
		NotAssigned,
		Included,
		NeedToTrim,
		Discarded,
		StartFromVertex,
		EndToVertex,
		OnBothEdges,
		NewEdge,
		MiddleSubEdge
	}

	internal class TessellationMesh : Mesh
	{
		public float TextureScaleU { get; set; } = 1f;

		public float TextureScaleV { get; set; } = 1f;

		public float TextureOffsetU { get; set; }

		public float TextureOffsetV { get; set; }

		public TessellationMesh(IList<Point3D> vertices, IList<IndexTriangle> triangles)
			: base(vertices, triangles)
		{
		}

		protected TessellationMesh(TessellationMesh another)
			: base(another)
		{
			TextureScaleU = another.TextureScaleU;
			TextureScaleV = another.TextureScaleV;
			TextureOffsetU = another.TextureOffsetU;
			TextureOffsetV = another.TextureOffsetV;
		}

		public override object Clone()
		{
			return new TessellationMesh(this);
		}
	}

	public class TopologyElement
	{
		[Serializable]
		private sealed class _0023_003Dz2IEmqow_003D
		{
			public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

			public static Func<string, int, string> _0023_003DzA9FoL6RNL7DJ9VM0hw_003D_003D;

			public static Func<string, int, string> _0023_003DzwwY5ZBi2wUYuUPrxAA_003D_003D;

			public static Func<string, int, string> _0023_003DzS7z5XJ0kiONLREfHlA_003D_003D;

			internal string _0023_003DzsttNTZtwhT_00249yRJIdo6Vki4_003D(string _0023_003DzXULhp_00248_003D, int _0023_003DzbCB8gRo_003D)
			{
				return _0023_003DzXULhp_00248_003D + _0023_003DzbCB8gRo_003D;
			}

			internal string _0023_003DzLIvH8sxUhogAbR5wuA_003D_003D(string _0023_003DzXULhp_00248_003D, int _0023_003DzbCB8gRo_003D)
			{
				return _0023_003DzXULhp_00248_003D + _0023_003DzbCB8gRo_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108);
			}

			internal string _0023_003Dz31VJqYPaKOx4aWYFIQ_003D_003D(string _0023_003DzXULhp_00248_003D, int _0023_003DzbCB8gRo_003D)
			{
				return _0023_003DzXULhp_00248_003D + _0023_003DzbCB8gRo_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108);
			}
		}

		private sealed class _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D
		{
			public OrientedEdge _0023_003DzSwfghCo_003D;

			public Func<OrientedEdge, bool> _0023_003DzJjT3dOU3oUsg;

			internal bool _0023_003DzPRWCs3_IsqYMgI3Mdw_003D_003D(OrientedEdge _0023_003DzuwH5j5s_003D)
			{
				return _0023_003DzuwH5j5s_003D.CurveIndex == _0023_003DzSwfghCo_003D.CurveIndex;
			}

			internal bool _0023_003DzCWRH_MpSL7_XUdGUhA_003D_003D(OrientedEdge _0023_003DzuwH5j5s_003D)
			{
				return _0023_003DzuwH5j5s_003D.CurveIndex == _0023_003DzSwfghCo_003D.CurveIndex;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzlcypPxJSwpeL;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzMoErDAY_003D;

		public readonly int Shell;

		public readonly List<int> InnerFaces = new List<int>();

		public readonly List<int> BoundaryFaces = new List<int>();

		public bool[][] Loops;

		internal TopologyElement(Brep _0023_003DzGb8kdyZ1x5nj, int _0023_003DzRLCcpW4_003D, int _0023_003Dzfe2zeQMumw_4, int _0023_003DzhNQLY4s_003D)
		{
			_0023_003DzlcypPxJSwpeL = _0023_003Dzfe2zeQMumw_4;
			_0023_003DzMoErDAY_003D = _0023_003DzhNQLY4s_003D;
			Shell = _0023_003DzRLCcpW4_003D;
			BoundaryFaces.Add(_0023_003Dzfe2zeQMumw_4);
			if (_0023_003DzRLCcpW4_003D == 0)
			{
				Loops = _0023_003Dz4YnpnPVUv0Qk(_0023_003DzGb8kdyZ1x5nj.Faces, _0023_003DzGb8kdyZ1x5nj.Edges);
			}
			for (int i = 0; i < _0023_003DzGb8kdyZ1x5nj.Inners.Length; i++)
			{
				if (Shell - 1 == i)
				{
					Loops = _0023_003Dz4YnpnPVUv0Qk(_0023_003DzGb8kdyZ1x5nj.Inners[i], _0023_003DzGb8kdyZ1x5nj.Edges);
				}
			}
		}

		private bool[][] _0023_003Dz4YnpnPVUv0Qk(Face[] _0023_003DzpPOEJqcAh7Lr, Edge[] _0023_003DzU3hosSAzkxO7)
		{
			bool[][] array = new bool[_0023_003DzpPOEJqcAh7Lr.Length][];
			for (int i = 0; i < _0023_003DzpPOEJqcAh7Lr.Length; i++)
			{
				array[i] = new bool[_0023_003DzpPOEJqcAh7Lr[i].Loops.Length];
				for (int j = 0; j < array[i].Length; j++)
				{
					array[i][j] = true;
				}
			}
			_0023_003Dz4YnpnPVUv0Qk(_0023_003DzpPOEJqcAh7Lr, _0023_003DzU3hosSAzkxO7, array, _0023_003DzlcypPxJSwpeL, _0023_003DzMoErDAY_003D);
			return array;
		}

		private void _0023_003Dz4YnpnPVUv0Qk(Face[] _0023_003DzpPOEJqcAh7Lr, Edge[] _0023_003DzU3hosSAzkxO7, bool[][] _0023_003Dz7rJNFSTr63D_0024, int _0023_003Dzfe2zeQMumw_4, int _0023_003DzhNQLY4s_003D)
		{
			_0023_003Dz7rJNFSTr63D_0024[_0023_003Dzfe2zeQMumw_4][_0023_003DzhNQLY4s_003D] = false;
			OrientedEdge[] segments = _0023_003DzpPOEJqcAh7Lr[_0023_003Dzfe2zeQMumw_4].Loops[_0023_003DzhNQLY4s_003D].Segments;
			for (int i = 0; i < segments.Length; i++)
			{
				_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2 = new _0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D();
				_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzSwfghCo_003D = segments[i];
				Edge edge = _0023_003DzU3hosSAzkxO7[_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzSwfghCo_003D.CurveIndex];
				if (edge.Parents.Length < 2 || edge.Parents[1] < 0 || edge.Parents[0] == edge.Parents[1])
				{
					continue;
				}
				int num = ((edge.Parents[0] == _0023_003Dzfe2zeQMumw_4) ? edge.Parents[1] : edge.Parents[0]);
				if (InnerFaces._0023_003DzDGFTILcrZeCm(num))
				{
					continue;
				}
				Face face = _0023_003DzpPOEJqcAh7Lr[num];
				if (_0023_003DzpPOEJqcAh7Lr[num].Loops[0].Segments.Any(_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzPRWCs3_IsqYMgI3Mdw_003D_003D))
				{
					InnerFaces._0023_003DzxlrG_0024xCp402A(num);
					for (int j = 0; j < face.Loops.Length; j++)
					{
						_0023_003Dz4YnpnPVUv0Qk(_0023_003DzpPOEJqcAh7Lr, _0023_003DzU3hosSAzkxO7, _0023_003Dz7rJNFSTr63D_0024, num, j);
					}
					continue;
				}
				if (!BoundaryFaces.Contains(num))
				{
					BoundaryFaces._0023_003DzxlrG_0024xCp402A(num);
				}
				for (int k = 1; k < face.Loops.Length; k++)
				{
					if (face.Loops[k].Segments.Any(_0023_003DzW7lOue6V_0024xLksm4Y0Q_003D_003D2._0023_003DzCWRH_MpSL7_XUdGUhA_003D_003D))
					{
						_0023_003Dz7rJNFSTr63D_0024[num][k] = false;
					}
				}
			}
		}

		public override bool Equals(object obj)
		{
			if (obj is TopologyElement topologyElement)
			{
				return GetHashCode() == topologyElement.GetHashCode();
			}
			return false;
		}

		public override int GetHashCode()
		{
			return InnerFaces.Aggregate(string.Empty, (string _0023_003DzXULhp_00248_003D, int _0023_003DzbCB8gRo_003D) => _0023_003DzXULhp_00248_003D + _0023_003DzbCB8gRo_003D).GetHashCode();
		}

		public override string ToString()
		{
			if (InnerFaces.Count > 5)
			{
				return InnerFaces.Take(3).Aggregate(string.Empty, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzLIvH8sxUhogAbR5wuA_003D_003D) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958980) + InnerFaces.Last();
			}
			string text = InnerFaces.Aggregate(string.Empty, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz31VJqYPaKOx4aWYFIQ_003D_003D);
			if (text.Length <= 0)
			{
				return string.Empty;
			}
			return text.Substring(0, text.Length - 2);
		}
	}

	[Serializable]
	public class Vertex : Point3D
	{
		internal bool Visited;

		public int[] Parents;

		public Vertex(double x, double y, double z = 0.0)
			: base(x, y, z)
		{
			Visited = false;
		}

		public Vertex(double[] coords)
			: base(coords)
		{
			Visited = false;
		}

		protected Vertex(Vertex another)
			: base(another)
		{
			if (another.Parents != null)
			{
				Parents = new int[another.Parents.Length];
				Array.Copy(another.Parents, Parents, another.Parents.Length);
			}
			Visited = false;
		}

		public Vertex(SerializationInfo info, StreamingContext ctxt)
		{
			Parents = (int[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957300), typeof(int[]));
		}

		public override object Clone()
		{
			return new Vertex(this);
		}

		public string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958992) + ToString());
			if (Parents != null)
			{
				if (Parents.Length > 1)
				{
					stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958719) + Parents[0]);
					for (int i = 1; i < Parents.Length; i++)
					{
						stringBuilder.Append(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108) + Parents[i]);
					}
				}
				else
				{
					stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958719) + Parents[0]);
				}
			}
			return stringBuilder.ToString();
		}

		public override Point2DSurrogate ConvertToSurrogate()
		{
			return new BrepVertexSurrogate(this);
		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302957300), Parents);
		}

		internal void _0023_003DznS097uo_003D(int _0023_003DzYXbMUNc_003D)
		{
			if (Parents == null || Parents.Length == 0)
			{
				return;
			}
			List<int> list = new List<int>(Parents.Length);
			for (int i = 0; i < Parents.Length; i++)
			{
				if (Parents[i] != _0023_003DzYXbMUNc_003D)
				{
					list.Add(Parents[i]);
				}
			}
			Parents = list.ToArray();
		}

		internal bool _0023_003Dz8hR_kalXOG3N(int _0023_003DzhYip7VpUCjAO, int _0023_003DzjabR4po_003D)
		{
			if (Parents == null)
			{
				return false;
			}
			for (int i = 0; i < Parents.Length; i++)
			{
				if (Parents[i] == _0023_003DzhYip7VpUCjAO)
				{
					Parents[i] = _0023_003DzjabR4po_003D;
					return true;
				}
			}
			return false;
		}

		internal bool _0023_003Dz1f9A6PoNLtVGII_0024I6g_003D_003D(int _0023_003DzcJpaJQAcgoDn, Edge[] _0023_003DzU3hosSAzkxO7, Face[] _0023_003DzpPOEJqcAh7Lr)
		{
			if (Parents.Length != 2 || Parents[0] == -1 || Parents[1] == -1)
			{
				return false;
			}
			int num = Parents[0];
			int num2 = Parents[1];
			if (num == num2)
			{
				return false;
			}
			Edge edge = _0023_003DzU3hosSAzkxO7[num];
			Edge edge2 = _0023_003DzU3hosSAzkxO7[num2];
			if (edge == null || edge2 == null || edge.Parents.Length != 2 || edge2.Parents.Length != 2)
			{
				return false;
			}
			if ((edge.Parents[0] != edge2.Parents[0] && edge.Parents[0] != edge2.Parents[1]) || (edge.Parents[1] != edge2.Parents[0] && edge.Parents[1] != edge2.Parents[1]))
			{
				return false;
			}
			Face face = _0023_003DzpPOEJqcAh7Lr[edge.Parents[0]];
			Face face2 = _0023_003DzpPOEJqcAh7Lr[edge.Parents[1]];
			if (face == null || _0023_003DzgXk8Ru_iJQUJ(face.Surface))
			{
				return false;
			}
			if (face2 == null || _0023_003DzgXk8Ru_iJQUJ(face2.Surface))
			{
				return false;
			}
			ICurve curve = edge.Curve;
			ICurve curve2 = edge2.Curve;
			if (curve.GetType() != curve2.GetType())
			{
				return false;
			}
			Vector3D u = ((edge.StartPointIndex == _0023_003DzcJpaJQAcgoDn) ? curve.StartTangent : curve.EndTangent);
			Vector3D v = ((edge2.StartPointIndex == _0023_003DzcJpaJQAcgoDn) ? curve2.StartTangent : curve2.EndTangent);
			if (Vector3D.AreParallel(u, v))
			{
				if (_0023_003DzpPOEJqcAh7Lr[edge.Parents[0]].Parametric != null && (_0023_003DzpPOEJqcAh7Lr[edge.Parents[0]].Parametric[0].IsOnSeamU(curve) || _0023_003DzpPOEJqcAh7Lr[edge.Parents[0]].Parametric[0].IsOnSeamV(curve)))
				{
					return false;
				}
				if (_0023_003DzpPOEJqcAh7Lr[edge.Parents[1]].Parametric != null && (_0023_003DzpPOEJqcAh7Lr[edge.Parents[1]].Parametric[0].IsOnSeamU(curve) || _0023_003DzpPOEJqcAh7Lr[edge.Parents[1]].Parametric[0].IsOnSeamV(curve)))
				{
					return false;
				}
				if (_0023_003DzpPOEJqcAh7Lr[edge2.Parents[0]].Parametric != null && (_0023_003DzpPOEJqcAh7Lr[edge2.Parents[0]].Parametric[0].IsOnSeamU(curve2) || _0023_003DzpPOEJqcAh7Lr[edge2.Parents[0]].Parametric[0].IsOnSeamV(curve2)))
				{
					return false;
				}
				if (_0023_003DzpPOEJqcAh7Lr[edge2.Parents[1]].Parametric != null && (_0023_003DzpPOEJqcAh7Lr[edge2.Parents[1]].Parametric[0].IsOnSeamU(curve2) || _0023_003DzpPOEJqcAh7Lr[edge2.Parents[1]].Parametric[0].IsOnSeamV(curve2)))
				{
					return false;
				}
				return true;
			}
			return false;
		}

		private bool _0023_003DzgXk8Ru_iJQUJ(AnalyticSurf _0023_003DzuwH5j5s_003D)
		{
			Point3D point3D = null;
			Point3D b = null;
			if (_0023_003DzuwH5j5s_003D is RevolvedSurf { Generatrix: Arc generatrix } revolvedSurf && Point3D.DistanceSquared(generatrix.Center, revolvedSurf.Plane.Origin) < 1E-12)
			{
				point3D = revolvedSurf.Plane.Origin + revolvedSurf.Plane.AxisZ * generatrix.Radius;
				b = revolvedSurf.Plane.Origin - revolvedSurf.Plane.AxisZ * generatrix.Radius;
				if (!(Point3D.DistanceSquared(this, point3D) < 1E-12))
				{
					return Point3D.DistanceSquared(this, b) < 1E-12;
				}
				return true;
			}
			if (_0023_003DzuwH5j5s_003D is SphericalSurf sphericalSurf)
			{
				point3D = sphericalSurf.Plane.Origin + sphericalSurf.Plane.AxisZ * sphericalSurf.Radius;
				b = sphericalSurf.Plane.Origin - sphericalSurf.Plane.AxisZ * sphericalSurf.Radius;
			}
			if (point3D != null)
			{
				if (!(Point3D.DistanceSquared(this, point3D) < 1E-12))
				{
					return Point3D.DistanceSquared(this, b) < 1E-12;
				}
				return true;
			}
			return false;
		}
	}

	public enum silhouettesDrawingType
	{
		Standard,
		SkipPlanars,
		SkipInwardPrimitives
	}

	private double _rebuildTol = 0.001;

	private Edge[] _edges;

	private Face[] _faces;

	private Face[][] _inners = new Face[0][];

	private Mesh _convexHull;

	private selectionFilterType _selectionMode = selectionFilterType.Entity;

	private EntityGraphicsData _drawWireData;

	private (EntityGraphicsData, Color?)[] _colorGroupsDrawData;

	private float _textureLength;

	private bool suspendFaceColor;

	private bool _materialOnFace;

	private silhouettesDrawingType _silhouettesDrawingMode = silhouettesDrawingType.SkipInwardPrimitives;

	public double RebuildTolerance
	{
		get
		{
			return _rebuildTol;
		}
		set
		{
			if (value > Utility._0023_003DzheSR8QM7q9ya)
			{
				_rebuildTol = value;
			}
			else
			{
				_rebuildTol = Utility._0023_003DzheSR8QM7q9ya;
			}
		}
	}

	public override Point3D[] Vertices
	{
		get
		{
			return _vertices;
		}
		set
		{
			_vertices = value;
			VerticesSelectionInfo.Clear();
			_0023_003DzUE6pJD8Y3NVt();
			_0023_003DzDumeg9jsTU7S(_0023_003Dzxt7paKBusKOo: false);
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public Edge[] Edges
	{
		get
		{
			return _edges;
		}
		set
		{
			_edges = value;
			EdgesSelectionInfo.Clear();
			_0023_003DzDumeg9jsTU7S(_0023_003Dzxt7paKBusKOo: false);
			RegenMode = regenType.RegenAndCompile;
		}
	}

	protected Mesh ConvexHull => _convexHull;

	public override regenType RegenMode
	{
		get
		{
			return base.RegenMode;
		}
		set
		{
			if (value == regenType.RegenAndCompile)
			{
				_convexHull = null;
			}
			base.RegenMode = value;
		}
	}

	public Face[] Faces
	{
		get
		{
			return _faces;
		}
		set
		{
			_faces = value;
			_0023_003DzDumeg9jsTU7S(_0023_003Dzxt7paKBusKOo: false);
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public Face[][] Inners
	{
		get
		{
			return _inners;
		}
		set
		{
			_inners = value;
			_0023_003DzUE6pJD8Y3NVt();
			_0023_003DzDumeg9jsTU7S(_0023_003Dzxt7paKBusKOo: false);
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public bool IsClosed
	{
		get
		{
			Edge[] edges = Edges;
			foreach (Edge edge in edges)
			{
				if (edge.Parents == null || edge.Parents.Length < 2)
				{
					return false;
				}
			}
			return true;
		}
	}

	public override colorMethodType LineTypeMethod
	{
		get
		{
			return base.LineTypeMethod;
		}
		set
		{
			base.LineTypeMethod = colorMethodType.byEntity;
		}
	}

	public override string LineTypeName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<SelectionInfoSubItems> FacesSelectionInfo { get; } = new List<SelectionInfoSubItems>();

	internal List<SelectionInfoSubItemsArray> InnerFacesSelectionInfo { get; } = new List<SelectionInfoSubItemsArray>();

	internal List<SelectionInfoSubItems> EdgesSelectionInfo { get; } = new List<SelectionInfoSubItems>();

	internal List<SelectionInfoSubItems> VerticesSelectionInfo { get; } = new List<SelectionInfoSubItems>();

	public selectionFilterType SelectionMode
	{
		get
		{
			return _selectionMode;
		}
		set
		{
			_selectionMode = value;
		}
	}

	internal override bool UseMaterialTextureLength => true;

	public override string MaterialName
	{
		get
		{
			return base.MaterialName;
		}
		set
		{
			base.MaterialName = value;
			if (RegenMode != regenType.RegenAndCompile)
			{
				RegenMode = regenType.CompileOnly;
			}
		}
	}

	public silhouettesDrawingType SilhouettesDrawingMode
	{
		get
		{
			return _silhouettesDrawingMode;
		}
		set
		{
			bool num = SilhouettesDrawingMode != value;
			_silhouettesDrawingMode = value;
			if (num)
			{
				silhoData = null;
				sharedEdgesForSilhouettesDraw = null;
			}
		}
	}

	public Brep(Point3D[] vertices, Edge[] edges, Face[] faces, Face[][] inners = null, double tolerance = 0.001)
		: this(vertices, edges, faces, _0023_003DzqMxdROkOZ2gG: true, inners, _0023_003DzPPoX8HETqTZN: false, _0023_003DzMcq9hcRIFsnaUZ3PgA_003D_003D: false, null, tolerance)
	{
	}

	internal Brep(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Edge[] _0023_003DzU3hosSAzkxO7, Face[] _0023_003DzpPOEJqcAh7Lr, bool _0023_003DzqMxdROkOZ2gG, Face[][] _0023_003DzWaFlkhfmYCja, bool _0023_003DzPPoX8HETqTZN, bool _0023_003DzMcq9hcRIFsnaUZ3PgA_003D_003D, StringBuilder _0023_003DzqmF8XJ0_003D = null, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D = 0.001)
		: this()
	{
		_vertices = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
		_edges = _0023_003DzU3hosSAzkxO7;
		_faces = _0023_003DzpPOEJqcAh7Lr;
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			_inners = _0023_003DzWaFlkhfmYCja;
		}
		RebuildTolerance = _0023_003DzuMKQhOieejyEvhtVOw_003D_003D;
		if (_0023_003DzqMxdROkOZ2gG)
		{
			_0023_003DzUE6pJD8Y3NVt();
			_0023_003DzDumeg9jsTU7S(_0023_003Dzxt7paKBusKOo: false);
		}
		if (_0023_003DzPPoX8HETqTZN)
		{
			_0023_003DzcYE3B98AVdT9();
		}
		if (_0023_003DzMcq9hcRIFsnaUZ3PgA_003D_003D)
		{
			Utility.SplitEdgeOnSurfaceSeams(this, _0023_003DzqmF8XJ0_003D);
		}
		if (_0023_003DzPPoX8HETqTZN)
		{
			FixFaces(_0023_003DzqmF8XJ0_003D);
		}
	}

	private Brep()
		: base(entityNatureType.Polygon)
	{
		LineTypeMethod = colorMethodType.byEntity;
		_0023_003DzCBXaK_002496NUpX(3);
	}

	protected internal Brep(Face[] faces, Face[][] inners)
		: this()
	{
		_faces = faces;
		if (inners != null)
		{
			_inners = inners;
		}
	}

	protected Brep(Brep another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		_rebuildTol = another._rebuildTol;
		_vertices = new Point3D[another._vertices.Length];
		for (int i = 0; i < another._vertices.Length; i++)
		{
			_vertices[i] = (Point3D)another._vertices[i].Clone();
		}
		_edges = new Edge[another._edges.Length];
		for (int j = 0; j < another._edges.Length; j++)
		{
			_edges[j] = (keepTessellation ? ((Edge)another._edges[j].CloneWithTessellation()) : ((Edge)another._edges[j].Clone()));
		}
		_faces = _0023_003DzuHbAxNSGQE3z(another._faces, keepTessellation);
		_inners = new Face[another._inners.Length][];
		for (int k = 0; k < another._inners.Length; k++)
		{
			_inners[k] = _0023_003DzuHbAxNSGQE3z(another._inners[k], keepTessellation);
		}
		SilhouettesDrawingMode = another.SilhouettesDrawingMode;
	}

	protected internal Brep(BrepSurrogate surrogate)
		: this(surrogate.GetVertices() ?? Array.Empty<Point3D>(), surrogate.GetEdges() ?? Array.Empty<Edge>(), surrogate.GetFaces() ?? Array.Empty<Face>(), _0023_003DzqMxdROkOZ2gG: false, surrogate.GetInners(), _0023_003DzPPoX8HETqTZN: false, _0023_003DzMcq9hcRIFsnaUZ3PgA_003D_003D: false, null, surrogate.GetRebuildTolerance())
	{
	}

	public Brep(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
		_vertices = (Point3D[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), typeof(Point3D[]));
		_edges = (Edge[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954162), typeof(Edge[]));
		_faces = (Face[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958659), typeof(Face[]));
		_inners = (Face[][])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958671), typeof(Face[][]));
		_silhouettesDrawingMode = (silhouettesDrawingType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958654), typeof(silhouettesDrawingType));
	}

	public void Remove(TopologyElement element)
	{
		Face[] array = ((element.Shell > 0) ? _inners[element.Shell - 1] : _faces);
		bool[][] loops = element.Loops;
		for (int i = 0; i < array.Length; i++)
		{
			Loop[] loops2 = array[i].Loops;
			List<Loop> list = new List<Loop>(loops2.Length);
			for (int j = 0; j < loops2.Length; j++)
			{
				if (!loops[i][j])
				{
					OrientedEdge[] segments = loops2[j].Segments;
					for (int k = 0; k < segments.Length; k++)
					{
						OrientedEdge orientedEdge = segments[k];
						if (_edges[orientedEdge.CurveIndex] != null)
						{
							_vertices[_edges[orientedEdge.CurveIndex].StartPointIndex] = null;
							_vertices[_edges[orientedEdge.CurveIndex].EndPointIndex] = null;
						}
						_edges[orientedEdge.CurveIndex] = null;
					}
				}
				else
				{
					list.Add(loops2[j]);
				}
			}
			if (list.Count == 0)
			{
				array[i] = null;
			}
			else if (list.Count != loops2.Length)
			{
				array[i] = (Face)array[i].Clone();
				array[i].Loops = list.ToArray();
			}
		}
		array = NullMap.RemoveNulls(array, null, out var map);
		_edges = NullMap.RemoveNulls(_edges, null, out var map2);
		_vertices = NullMap.RemoveNulls(_vertices, null, out var map3);
		Point3D[] vertices = _vertices;
		for (int k = 0; k < vertices.Length; k++)
		{
			Vertex vertex = (Vertex)vertices[k];
			for (int l = 0; l < vertex.Parents.Length; l++)
			{
				int i2 = vertex.Parents[l];
				vertex.Parents[l] = map2[i2];
			}
		}
		Edge[] edges = _edges;
		foreach (Edge edge in edges)
		{
			edge.StartPointIndex = map3[edge.StartPointIndex];
			edge.EndPointIndex = map3[edge.EndPointIndex];
			if (edge.ShellIndex == element.Shell)
			{
				edge.Parents[0] = map[edge.Parents[0]];
				if (edge.Parents.Length > 1 && edge.Parents[1] > 0)
				{
					edge.Parents[1] = map[edge.Parents[1]];
				}
			}
		}
		if (element.Shell == 0)
		{
			_faces = array;
		}
		else
		{
			_inners[element.Shell - 1] = array;
		}
		_0023_003DzV_ErUMtC6n2P(_faces, map2);
		Face[][] inners = _inners;
		foreach (Face[] _0023_003DzpPOEJqcAh7Lr in inners)
		{
			_0023_003DzV_ErUMtC6n2P(_0023_003DzpPOEJqcAh7Lr, map2);
		}
		RegenMode = regenType.RegenAndCompile;
	}

	private void _0023_003DzV_ErUMtC6n2P(Face[] _0023_003DzpPOEJqcAh7Lr, NullMap _0023_003Dzj3zz603SnM0G)
	{
		foreach (Face face in _0023_003DzpPOEJqcAh7Lr)
		{
			Loop[] loops = face.Loops;
			foreach (Loop loop in loops)
			{
				for (int k = 0; k < loop.Segments.Length; k++)
				{
					loop.Segments[k].CurveIndex = _0023_003Dzj3zz603SnM0G[loop.Segments[k].CurveIndex];
				}
			}
			if (face.Parametric == null)
			{
				continue;
			}
			Surface[] parametric = face.Parametric;
			for (int j = 0; j < parametric.Length; j++)
			{
				foreach (ICurve contour in parametric[j].Trimming.ContourList)
				{
					ICurve[] individualCurves = contour.GetIndividualCurves();
					foreach (ICurve curve in individualCurves)
					{
						curve.EdgeIndex = _0023_003Dzj3zz603SnM0G[curve.EdgeIndex];
					}
				}
			}
		}
	}

	public TopologyElement[] GetRemovableElements()
	{
		List<TopologyElement> list = new List<TopologyElement>();
		list.AddRange(_0023_003DzjV_0024_zMh5g2ZN(Faces, 0));
		for (int i = 0; i < _inners.Length; i++)
		{
			list.AddRange(_0023_003DzjV_0024_zMh5g2ZN(_inners[i], i + 1));
		}
		return list.ToArray();
	}

	private IEnumerable<TopologyElement> _0023_003DzjV_0024_zMh5g2ZN(Face[] _0023_003DzpPOEJqcAh7Lr, int _0023_003DzRLCcpW4_003D)
	{
		HashSet<TopologyElement> hashSet = new HashSet<TopologyElement>();
		for (int i = 0; i < _0023_003DzpPOEJqcAh7Lr.Length; i++)
		{
			Face face = _0023_003DzpPOEJqcAh7Lr[i];
			if (face.Loops.Length < 2)
			{
				continue;
			}
			for (int j = 1; j < face.Loops.Length; j++)
			{
				TopologyElement topologyElement = new TopologyElement(this, _0023_003DzRLCcpW4_003D, i, j);
				if (topologyElement.InnerFaces.Count != 0 && topologyElement.InnerFaces.Count + topologyElement.BoundaryFaces.Count <= _0023_003DzpPOEJqcAh7Lr.Length)
				{
					hashSet.Add(topologyElement);
				}
			}
		}
		return hashSet.ToArray();
	}

	private static Brep _0023_003DzQ7LTw5GKYnP0qMDYo6Jfnn_0024KrTyp(Region _0023_003Dz7revxoQ_003D, Interval _0023_003DzYNjcavt9guh2, double _0023_003DzgMK0f1GDiTy7, Plane _0023_003DzloJJEdKMR47X, double _0023_003DzlBA2KcQ_003D, int _0023_003DzM2i6yTg_003D, double _0023_003DzmszIVng_003D, int _0023_003Dzz6Xw76k_003D, double _0023_003DzGvLz4uh736QEMEZuVg_003D_003D)
	{
		if (_0023_003DzGvLz4uh736QEMEZuVg_003D_003D == 0.0)
		{
			_0023_003DzGvLz4uh736QEMEZuVg_003D_003D = 0.001;
		}
		Vector3D axisX = _0023_003DzloJJEdKMR47X.AxisX;
		Vector3D axisY = _0023_003DzloJJEdKMR47X.AxisY;
		Brep brep = _0023_003Dz7revxoQ_003D.ExtrudeAsBrep(_0023_003DzYNjcavt9guh2, _0023_003DzgMK0f1GDiTy7, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D);
		_0023_003Dz8VkxvzXXGxA_0024(brep.Vertices, brep.Edges, brep.Faces, new Face[0][], _0023_003DzLuJVbec_003D: true);
		List<Point3D> list = new List<Point3D>(brep.Vertices.Length * _0023_003DzM2i6yTg_003D * _0023_003Dzz6Xw76k_003D);
		List<Edge> list2 = new List<Edge>(brep.Edges.Length * _0023_003DzM2i6yTg_003D * _0023_003Dzz6Xw76k_003D);
		List<Face> list3 = new List<Face>(brep.Faces.Length * _0023_003DzM2i6yTg_003D * _0023_003Dzz6Xw76k_003D);
		list.AddRange(brep.Vertices);
		list2.AddRange(brep.Edges);
		list3.AddRange(brep.Faces);
		int num = brep.Vertices.Length;
		int num2 = brep.Edges.Length;
		int num3 = 0;
		for (int i = 0; i < _0023_003DzM2i6yTg_003D; i++)
		{
			for (int j = 0; j < _0023_003Dzz6Xw76k_003D; j++)
			{
				if (i == 0 && j == 0)
				{
					continue;
				}
				num3++;
				Brep brep2 = (Brep)brep.Clone();
				brep2.Translate(_0023_003DzlBA2KcQ_003D * (double)i * axisX);
				brep2.Translate(_0023_003DzmszIVng_003D * (double)j * axisY);
				list.AddRange(brep2.Vertices);
				for (int k = 0; k < brep2.Edges.Length; k++)
				{
					brep2.Edges[k].StartPointIndex += num * num3;
					brep2.Edges[k].EndPointIndex += num * num3;
					list2.Add(brep2.Edges[k]);
				}
				for (int l = 0; l < brep2.Faces.Length; l++)
				{
					Loop[] loops = brep2.Faces[l].Loops;
					foreach (Loop loop in loops)
					{
						for (int n = 0; n < loop.Segments.Length; n++)
						{
							loop.Segments[n].CurveIndex += num2 * num3;
						}
					}
					list3.Add(brep2.Faces[l]);
				}
			}
		}
		return new Brep(list.ToArray(), list2.ToArray(), list3.ToArray(), null, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D);
	}

	private Brep _0023_003Dzh0T3HOtyGhjj9UjyJCkldfwQvi_6qwIXzg_003D_003D(Region _0023_003Dz7revxoQ_003D, double _0023_003DzgMK0f1GDiTy7, Plane _0023_003DzloJJEdKMR47X, double _0023_003DzlBA2KcQ_003D, int _0023_003DzM2i6yTg_003D, double _0023_003DzmszIVng_003D, int _0023_003Dzz6Xw76k_003D, double _0023_003DzGvLz4uh736QEMEZuVg_003D_003D)
	{
		_0023_003Dzz0cR7hJgEH1Gz0obmw_003D_003D(_0023_003Dz7revxoQ_003D.Plane, out var _0023_003Dzkvk88KaXCcAi, out var _0023_003Dzj_0024c4yo8Y8jLt);
		double num = Utility._0023_003DzBdlHahH_sn5_0cVpzJ_0024pzhGGFVyq5_aiECmXAR_0024dnNChzXciog_003D_003D * (_0023_003Dzj_0024c4yo8Y8jLt - _0023_003Dzkvk88KaXCcAi);
		Interval _0023_003DzYNjcavt9guh = new Interval(_0023_003Dzkvk88KaXCcAi - num, _0023_003Dzj_0024c4yo8Y8jLt + num);
		if (_0023_003DzGvLz4uh736QEMEZuVg_003D_003D == 0.0)
		{
			_0023_003DzGvLz4uh736QEMEZuVg_003D_003D = 0.001;
		}
		return _0023_003DzQ7LTw5GKYnP0qMDYo6Jfnn_0024KrTyp(_0023_003Dz7revxoQ_003D, _0023_003DzYNjcavt9guh, _0023_003DzgMK0f1GDiTy7, _0023_003DzloJJEdKMR47X, _0023_003DzlBA2KcQ_003D, _0023_003DzM2i6yTg_003D, _0023_003DzmszIVng_003D, _0023_003Dzz6Xw76k_003D, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D);
	}

	internal static Brep _0023_003DzN5skCNvL5pOuyAf6qA_003D_003D(Region _0023_003Dz7revxoQ_003D, Interval _0023_003DzYNjcavt9guh2, double _0023_003DzgMK0f1GDiTy7, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003Dz96zZozU1V2X4, double _0023_003DznPBtD_0024qc7LrUv9BA9Ct5vlA_003D, int _0023_003DzbbXd51DIYTErQLlt_0024A_003D_003D, double _0023_003DzGvLz4uh736QEMEZuVg_003D_003D)
	{
		if (_0023_003DzGvLz4uh736QEMEZuVg_003D_003D == 0.0)
		{
			_0023_003DzGvLz4uh736QEMEZuVg_003D_003D = 0.001;
		}
		if (_0023_003DznPBtD_0024qc7LrUv9BA9Ct5vlA_003D * (double)_0023_003DzbbXd51DIYTErQLlt_0024A_003D_003D > 6.283185307180586)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958619));
		}
		Brep brep = _0023_003Dz7revxoQ_003D.ExtrudeAsBrep(_0023_003DzYNjcavt9guh2, _0023_003DzgMK0f1GDiTy7, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D);
		_0023_003Dz8VkxvzXXGxA_0024(brep.Vertices, brep.Edges, brep.Faces, new Face[0][], _0023_003DzLuJVbec_003D: true);
		List<Point3D> list = new List<Point3D>(brep.Vertices.Length * _0023_003DzbbXd51DIYTErQLlt_0024A_003D_003D);
		List<Edge> list2 = new List<Edge>(brep.Edges.Length * _0023_003DzbbXd51DIYTErQLlt_0024A_003D_003D);
		List<Face> list3 = new List<Face>(brep.Faces.Length * _0023_003DzbbXd51DIYTErQLlt_0024A_003D_003D);
		list.AddRange(brep.Vertices);
		list2.AddRange(brep.Edges);
		list3.AddRange(brep.Faces);
		int num = brep.Vertices.Length;
		int num2 = brep.Edges.Length;
		int num3 = 0;
		for (int i = 1; i < _0023_003DzbbXd51DIYTErQLlt_0024A_003D_003D; i++)
		{
			num3++;
			Brep brep2 = (Brep)brep.Clone();
			brep2.Rotate(_0023_003DznPBtD_0024qc7LrUv9BA9Ct5vlA_003D * (double)i, _0023_003DzxuJqjrs_003D, _0023_003Dz96zZozU1V2X4);
			list.AddRange(brep2.Vertices);
			for (int j = 0; j < brep2.Edges.Length; j++)
			{
				brep2.Edges[j].StartPointIndex += num * num3;
				brep2.Edges[j].EndPointIndex += num * num3;
				list2.Add(brep2.Edges[j]);
			}
			for (int k = 0; k < brep2.Faces.Length; k++)
			{
				Loop[] loops = brep2.Faces[k].Loops;
				foreach (Loop loop in loops)
				{
					for (int m = 0; m < loop.Segments.Length; m++)
					{
						loop.Segments[m].CurveIndex += num2 * num3;
					}
				}
				list3.Add(brep2.Faces[k]);
			}
		}
		return new Brep(list.ToArray(), list2.ToArray(), list3.ToArray(), null, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D);
	}

	private Brep _0023_003Dz_0024WyRSkLuWJy02RkuCDBvW_0024U_003D(Region _0023_003Dz7revxoQ_003D, double _0023_003DzgMK0f1GDiTy7, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003Dz96zZozU1V2X4, double _0023_003DznPBtD_0024qc7LrUv9BA9Ct5vlA_003D, int _0023_003DzbbXd51DIYTErQLlt_0024A_003D_003D, double _0023_003DzGvLz4uh736QEMEZuVg_003D_003D)
	{
		_0023_003Dzz0cR7hJgEH1Gz0obmw_003D_003D(_0023_003Dz7revxoQ_003D.Plane, out var _0023_003Dzkvk88KaXCcAi, out var _0023_003Dzj_0024c4yo8Y8jLt);
		double num = Utility._0023_003DzBdlHahH_sn5_0cVpzJ_0024pzhGGFVyq5_aiECmXAR_0024dnNChzXciog_003D_003D * (_0023_003Dzj_0024c4yo8Y8jLt - _0023_003Dzkvk88KaXCcAi);
		Interval _0023_003DzYNjcavt9guh = new Interval(_0023_003Dzkvk88KaXCcAi - num, _0023_003Dzj_0024c4yo8Y8jLt + num);
		if (_0023_003DzGvLz4uh736QEMEZuVg_003D_003D == 0.0)
		{
			_0023_003DzGvLz4uh736QEMEZuVg_003D_003D = 0.001;
		}
		return _0023_003DzN5skCNvL5pOuyAf6qA_003D_003D(_0023_003Dz7revxoQ_003D, _0023_003DzYNjcavt9guh, _0023_003DzgMK0f1GDiTy7, _0023_003DzxuJqjrs_003D, _0023_003Dz96zZozU1V2X4, _0023_003DznPBtD_0024qc7LrUv9BA9Ct5vlA_003D, _0023_003DzbbXd51DIYTErQLlt_0024A_003D_003D, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D);
	}

	public bool ExtrudeRemove(Region reg, double amount)
	{
		Brep b = reg.ExtrudeAsBrep(amount, 0.0, _rebuildTol);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemove(Region reg, Interval amount)
	{
		Brep b = reg.ExtrudeAsBrep(amount, 0.0, _rebuildTol);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemove(Region reg, double amount, double angleInRadians)
	{
		Brep b = reg.ExtrudeAsBrep(reg.Plane.AxisZ * amount, angleInRadians, _rebuildTol);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemove(Sketch sketch, double amount)
	{
		_0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D2 = new _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D();
		_0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D2._0023_003DzYNjcavt9guh2 = amount;
		_0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D2._0023_003DzopRx0_MBcTQs = this;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(sketch.ConvertToRegions().Select(_0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D2._0023_003DzSq8J_Vp_VjkEDtZ7aR5xBWU_003D).ToArray(), _rebuildTol, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemove(Sketch sketch, Interval amount)
	{
		_0023_003Dz15xQV4ABMjmVh1Ui5plqk5A_003D _0023_003Dz15xQV4ABMjmVh1Ui5plqk5A_003D2 = new _0023_003Dz15xQV4ABMjmVh1Ui5plqk5A_003D();
		_0023_003Dz15xQV4ABMjmVh1Ui5plqk5A_003D2._0023_003DzYNjcavt9guh2 = amount;
		_0023_003Dz15xQV4ABMjmVh1Ui5plqk5A_003D2._0023_003DzopRx0_MBcTQs = this;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(sketch.ConvertToRegions().Select(_0023_003Dz15xQV4ABMjmVh1Ui5plqk5A_003D2._0023_003DzSq8J_Vp_VjkEDtZ7aR5xBWU_003D).ToArray(), _rebuildTol, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemove(Sketch sketch, double amount, double angleInRadians)
	{
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2 = new _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D();
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzYNjcavt9guh2 = amount;
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D = angleInRadians;
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzopRx0_MBcTQs = this;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(sketch.ConvertToRegions().Select(_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzSq8J_Vp_VjkEDtZ7aR5xBWU_003D).ToArray(), _rebuildTol, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	internal void _0023_003Dzz0cR7hJgEH1Gz0obmw_003D_003D(Plane _0023_003Dzrgqz890sj_0024X9, out double _0023_003Dzkvk88KaXCcAi, out double _0023_003Dzj_0024c4yo8Y8jLt)
	{
		Point3D _0023_003DzDPcjoBJLcqli;
		Point3D _0023_003Dz_0024N_0024yKptW9BoC;
		if (localMin != Point3D.MaxValue && localMin != Point3D.MinValue && localMax != Point3D.MaxValue && localMax != Point3D.MinValue && localMin != null && localMax != null && RegenMode == regenType.NotNeeded)
		{
			_0023_003DzDPcjoBJLcqli = base.BoxMin;
			_0023_003Dz_0024N_0024yKptW9BoC = base.BoxMax;
		}
		else
		{
			Rebuild(0.0, soft: true);
			_0023_003DzQCWJbpjMGLxZWfwMCQ_003D_003D(out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC, _0023_003Dz7cP1pZCb1hQy: true);
		}
		Point3D[] boundingBoxCorners = Utility.GetBoundingBoxCorners(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
		_0023_003Dzkvk88KaXCcAi = double.MaxValue;
		_0023_003Dzj_0024c4yo8Y8jLt = double.MinValue;
		Point3D[] array = boundingBoxCorners;
		foreach (Point3D point in array)
		{
			double num = _0023_003Dzrgqz890sj_0024X9.DistanceTo(point);
			if (num > _0023_003Dzj_0024c4yo8Y8jLt)
			{
				_0023_003Dzj_0024c4yo8Y8jLt = num;
			}
			if (num < _0023_003Dzkvk88KaXCcAi)
			{
				_0023_003Dzkvk88KaXCcAi = num;
			}
		}
	}

	public bool ExtrudeRemoveThrough(Region reg, double angleInRadians)
	{
		_0023_003Dzz0cR7hJgEH1Gz0obmw_003D_003D(reg.Plane, out var _0023_003Dzkvk88KaXCcAi, out var _0023_003Dzj_0024c4yo8Y8jLt);
		double num = Utility._0023_003DzBdlHahH_sn5_0cVpzJ_0024pzhGGFVyq5_aiECmXAR_0024dnNChzXciog_003D_003D * (_0023_003Dzj_0024c4yo8Y8jLt - _0023_003Dzkvk88KaXCcAi);
		Interval amount = new Interval(_0023_003Dzkvk88KaXCcAi - num, _0023_003Dzj_0024c4yo8Y8jLt + num);
		Brep b = reg.ExtrudeAsBrep(amount, angleInRadians, _rebuildTol);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemoveThrough(Region reg)
	{
		_0023_003Dzz0cR7hJgEH1Gz0obmw_003D_003D(reg.Plane, out var _0023_003Dzkvk88KaXCcAi, out var _0023_003Dzj_0024c4yo8Y8jLt);
		double num = Utility._0023_003DzBdlHahH_sn5_0cVpzJ_0024pzhGGFVyq5_aiECmXAR_0024dnNChzXciog_003D_003D * (_0023_003Dzj_0024c4yo8Y8jLt - _0023_003Dzkvk88KaXCcAi);
		Interval amount = new Interval(_0023_003Dzkvk88KaXCcAi - num, _0023_003Dzj_0024c4yo8Y8jLt + num);
		return ExtrudeRemove(reg, amount);
	}

	public bool ExtrudeRemoveThrough(Sketch sketch, double angleInRadians)
	{
		_0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D CS_0024_003C_003E8__locals6 = new _0023_003DzJtjkANrc7CleZq9RRzp8B4Q_003D();
		CS_0024_003C_003E8__locals6._0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D = angleInRadians;
		CS_0024_003C_003E8__locals6._0023_003DzopRx0_MBcTQs = this;
		_0023_003Dzz0cR7hJgEH1Gz0obmw_003D_003D(sketch.SketchPlane, out var _0023_003Dzkvk88KaXCcAi, out var _0023_003Dzj_0024c4yo8Y8jLt);
		double num = Utility._0023_003DzBdlHahH_sn5_0cVpzJ_0024pzhGGFVyq5_aiECmXAR_0024dnNChzXciog_003D_003D * (_0023_003Dzj_0024c4yo8Y8jLt - _0023_003Dzkvk88KaXCcAi);
		CS_0024_003C_003E8__locals6._0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D = new Interval(_0023_003Dzkvk88KaXCcAi - num, _0023_003Dzj_0024c4yo8Y8jLt + num);
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D((from _0023_003DzFDwqpgU_003D in sketch.ConvertToRegions()
			select _0023_003DzFDwqpgU_003D.ExtrudeAsBrep(CS_0024_003C_003E8__locals6._0023_003Dzm0JmtELjQLEBsuYjjQ_003D_003D, CS_0024_003C_003E8__locals6._0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, CS_0024_003C_003E8__locals6._0023_003DzopRx0_MBcTQs._rebuildTol)).ToArray(), _rebuildTol, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemoveThrough(Sketch sketch)
	{
		return ExtrudeRemoveThrough(sketch, 0.0);
	}

	public bool ExtrudeRemovePattern(Region region, double amount, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(region, amount, 0.0, region.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(Region region, Interval amount, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(region, amount, 0.0, region.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(Region region, double amount, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(region, amount, 0.0, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(Region region, Interval amount, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(region, amount, 0.0, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(Region region, double amount, double angleInRadians, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(region, amount, angleInRadians, region.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(Region region, Interval amount, double angleInRadians, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(region, amount, angleInRadians, region.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(Region region, double amount, double angleInRadians, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(region, (amount > 0.0) ? new Interval(0.0, amount) : new Interval(amount, 0.0), angleInRadians, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(Region region, Interval amount, double angleInRadians, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		Brep b = _0023_003DzQ7LTw5GKYnP0qMDYo6Jfnn_0024KrTyp(region, amount, angleInRadians, patternPln, spacingX, numberX, spacingY, numberY, _rebuildTol);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeAddPattern(Region region, double amount, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(region, amount, 0.0, region.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(Region region, Interval amount, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(region, amount, 0.0, region.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(Region region, double amount, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(region, amount, 0.0, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(Region region, Interval amount, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(region, amount, 0.0, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(Region region, double amount, double draftAngleInRadians, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(region, amount, draftAngleInRadians, region.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(Region region, Interval amount, double draftAngleInRadians, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(region, amount, draftAngleInRadians, region.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(Region region, double amount, double draftAngleInRadians, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(region, (amount > 0.0) ? new Interval(0.0, amount) : new Interval(amount, 0.0), draftAngleInRadians, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(Region region, Interval amount, double draftAngleInRadians, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		Brep b = _0023_003DzQ7LTw5GKYnP0qMDYo6Jfnn_0024KrTyp(region, amount, draftAngleInRadians, patternPln, spacingX, numberX, spacingY, numberY, _rebuildTol);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemovePattern(Region region, double amount, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(region, amount, 0.0, region.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(Region region, Interval amount, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(region, amount, 0.0, region.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(Region region, double amount, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(region, amount, 0.0, axis, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(Region region, Interval amount, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(region, amount, 0.0, axis, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(Region region, double amount, double draftAngleInRadians, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(region, amount, draftAngleInRadians, region.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(Region region, Interval amount, double draftAngleInRadians, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(region, amount, draftAngleInRadians, region.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(Region region, double amount, double draftAngleInRadians, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(region, (amount > 0.0) ? new Interval(0.0, amount) : new Interval(amount, 0.0), draftAngleInRadians, axis, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(Region region, Interval amount, double draftAngleInRadians, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		Brep b = _0023_003DzN5skCNvL5pOuyAf6qA_003D_003D(region, amount, draftAngleInRadians, axis, center, angleInRadians, number, _rebuildTol);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemoveThroughPattern(Region region, double angleInRadians, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		Brep b = _0023_003Dzh0T3HOtyGhjj9UjyJCkldfwQvi_6qwIXzg_003D_003D(region, angleInRadians, patternPln, spacingX, numberX, spacingY, numberY, _rebuildTol);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemoveThroughPattern(Region region, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemoveThroughPattern(region, 0.0, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemoveThroughPattern(Region region, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemoveThroughPattern(region, 0.0, region.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemoveThroughPattern(Region region, double draftAngleInRadians, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		Brep b = _0023_003Dz_0024WyRSkLuWJy02RkuCDBvW_0024U_003D(region, draftAngleInRadians, axis, center, angleInRadians, number, _rebuildTol);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemoveThroughPattern(Region region, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemoveThroughPattern(region, 0.0, axis, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(Region region, double amount, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(region, amount, 0.0, region.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(Region region, Interval amount, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(region, amount, 0.0, region.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(Region region, double amount, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(region, amount, 0.0, axis, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(Region region, Interval amount, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(region, amount, 0.0, axis, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(Region region, double amount, double draftAngleInRadians, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(region, amount, draftAngleInRadians, region.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(Region region, Interval amount, double draftAngleInRadians, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(region, amount, draftAngleInRadians, region.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(Region region, double amount, double draftAngleInRadians, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(region, (amount > 0.0) ? new Interval(0.0, amount) : new Interval(amount, 0.0), draftAngleInRadians, axis, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(Region region, Interval amount, double draftAngleInRadians, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		Brep b = _0023_003DzN5skCNvL5pOuyAf6qA_003D_003D(region, amount, draftAngleInRadians, axis, center, angleInRadians, number, _rebuildTol);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeAddPattern(Sketch sketch, double amount, double draftAngleInRadians, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(sketch, amount, draftAngleInRadians, sketch.SketchPlane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(Sketch sketch, double amount, double draftAngleInRadians, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(sketch, (amount > 0.0) ? new Interval(0.0, amount) : new Interval(amount, 0.0), draftAngleInRadians, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(Sketch sketch, double amount, double draftAngleInRadians, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(sketch, amount, draftAngleInRadians, sketch.SketchPlane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(Sketch sketch, double amount, double draftAngleInRadians, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(sketch, (amount > 0.0) ? new Interval(0.0, amount) : new Interval(amount, 0.0), draftAngleInRadians, axis, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(Sketch sketch, double amount, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(sketch, amount, 0.0, sketch.SketchPlane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(Sketch sketch, double amount, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(sketch, amount, 0.0, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(Sketch sketch, double amount, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(sketch, amount, 0.0, sketch.SketchPlane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(Sketch sketch, double amount, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(sketch, amount, 0.0, axis, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(Sketch sketch, Interval amount, double draftAngleInRadians, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(sketch, amount, draftAngleInRadians, sketch.SketchPlane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(Sketch sketch, Interval amount, double draftAngleInRadians, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(sketch.ConvertToRegions()[0], amount, draftAngleInRadians, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(Sketch sketch, Interval amount, double draftAngleInRadians, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(sketch, amount, draftAngleInRadians, sketch.SketchPlane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(Sketch sketch, Interval amount, double draftAngleInRadians, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(sketch.ConvertToRegions()[0], amount, draftAngleInRadians, axis, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(Sketch sketch, Interval amount, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(sketch, amount, 0.0, sketch.SketchPlane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(Sketch sketch, Interval amount, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(sketch, amount, 0.0, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(Sketch sketch, Interval amount, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(sketch, amount, 0.0, sketch.SketchPlane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(Sketch sketch, Interval amount, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(sketch, amount, 0.0, axis, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(Sketch sketch, double amount, double angleInRadians, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(sketch, amount, angleInRadians, sketch.SketchPlane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(Sketch sketch, double amount, double angleInRadians, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(sketch, (amount > 0.0) ? new Interval(0.0, amount) : new Interval(amount, 0.0), angleInRadians, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(Sketch sketch, double amount, double draftAngleInRadians, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(sketch, amount, draftAngleInRadians, sketch.SketchPlane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(Sketch sketch, double amount, double draftAngleInRadians, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(sketch, (amount > 0.0) ? new Interval(0.0, amount) : new Interval(amount, 0.0), draftAngleInRadians, axis, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(Sketch sketch, double amount, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(sketch, amount, 0.0, sketch.SketchPlane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(Sketch sketch, double amount, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(sketch, amount, 0.0, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(Sketch sketch, double amount, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(sketch, amount, 0.0, sketch.SketchPlane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(Sketch sketch, double amount, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(sketch, amount, 0.0, axis, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(Sketch sketch, Interval amount, double angleInRadians, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(sketch, amount, angleInRadians, sketch.SketchPlane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(Sketch sketch, Interval amount, double angleInRadians, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(sketch.ConvertToRegions()[0], amount, angleInRadians, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(Sketch sketch, Interval amount, double draftAngleInRadians, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(sketch, amount, draftAngleInRadians, sketch.SketchPlane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(Sketch sketch, Interval amount, double draftAngleInRadians, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(sketch.ConvertToRegions()[0], amount, draftAngleInRadians, axis, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(Sketch sketch, Interval amount, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(sketch, amount, 0.0, sketch.SketchPlane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(Sketch sketch, Interval amount, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(sketch, amount, 0.0, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(Sketch sketch, Interval amount, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(sketch, amount, 0.0, sketch.SketchPlane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(Sketch sketch, Interval amount, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(sketch, amount, 0.0, axis, center, angleInRadians, number);
	}

	public bool ExtrudeRemoveThroughPattern(Sketch sketch, double angleInRadians, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemoveThroughPattern(sketch.ConvertToRegions()[0], angleInRadians, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemoveThroughPattern(Sketch sketch, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemoveThroughPattern(sketch, 0.0, sketch.SketchPlane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemoveThroughPattern(Sketch sketch, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemoveThroughPattern(sketch, 0.0, axis, center, angleInRadians, number);
	}

	public bool ExtrudeRemoveThroughPattern(Sketch sketch, double draftAngleInRadians, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemoveThroughPattern(sketch, draftAngleInRadians, sketch.SketchPlane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemoveThroughPattern(Sketch sketch, double draftAngleInRadians, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemoveThroughPattern(sketch.ConvertToRegions()[0], draftAngleInRadians, axis, center, angleInRadians, number);
	}

	public bool ExtrudeRemoveThroughPattern(Sketch sketch, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemoveThroughPattern(sketch, 0.0, sketch.SketchPlane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemoveThroughPattern(Sketch sketch, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemoveThroughPattern(sketch, 0.0, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAdd(Region reg, double amount)
	{
		Brep b = reg.ExtrudeAsBrep(amount, 0.0, _rebuildTol);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			return true;
		}
		return false;
	}

	public bool ExtrudeAdd(Region reg, double amount, double angleInRadians)
	{
		Brep b = reg.ExtrudeAsBrep(reg.Plane.AxisZ * amount, angleInRadians, _rebuildTol);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			return true;
		}
		return false;
	}

	public bool ExtrudeAdd(Region reg, Interval amount)
	{
		Brep b = reg.ExtrudeAsBrep(amount, 0.0, _rebuildTol);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			return true;
		}
		return false;
	}

	public bool ExtrudeAdd(Sketch sketch, double amount)
	{
		_0023_003DzI0_0024QGEKv3_eQYWLq94YAcwY_003D _0023_003DzI0_0024QGEKv3_eQYWLq94YAcwY_003D2 = new _0023_003DzI0_0024QGEKv3_eQYWLq94YAcwY_003D();
		_0023_003DzI0_0024QGEKv3_eQYWLq94YAcwY_003D2._0023_003DzYNjcavt9guh2 = amount;
		_0023_003DzI0_0024QGEKv3_eQYWLq94YAcwY_003D2._0023_003DzopRx0_MBcTQs = this;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(sketch.ConvertToRegions().Select(_0023_003DzI0_0024QGEKv3_eQYWLq94YAcwY_003D2._0023_003DzFLW5ZaGz6fHDhwojVqI2LJs_003D).ToArray(), 0.0, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeAdd(Sketch sketch, double amount, double angleInRadians)
	{
		_0023_003Dz8qmhS3jTMV3inA_0024QqkK0CVc_003D _0023_003Dz8qmhS3jTMV3inA_0024QqkK0CVc_003D2 = new _0023_003Dz8qmhS3jTMV3inA_0024QqkK0CVc_003D();
		_0023_003Dz8qmhS3jTMV3inA_0024QqkK0CVc_003D2._0023_003DzYNjcavt9guh2 = amount;
		_0023_003Dz8qmhS3jTMV3inA_0024QqkK0CVc_003D2._0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D = angleInRadians;
		_0023_003Dz8qmhS3jTMV3inA_0024QqkK0CVc_003D2._0023_003DzopRx0_MBcTQs = this;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(sketch.ConvertToRegions().Select(_0023_003Dz8qmhS3jTMV3inA_0024QqkK0CVc_003D2._0023_003DzFLW5ZaGz6fHDhwojVqI2LJs_003D).ToArray(), 0.0, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeAdd(Sketch sketch, Interval amount)
	{
		_0023_003DzUe1S_0024HWFwkFH2Y4ijk5JkyU_003D _0023_003DzUe1S_0024HWFwkFH2Y4ijk5JkyU_003D2 = new _0023_003DzUe1S_0024HWFwkFH2Y4ijk5JkyU_003D();
		_0023_003DzUe1S_0024HWFwkFH2Y4ijk5JkyU_003D2._0023_003DzYNjcavt9guh2 = amount;
		_0023_003DzUe1S_0024HWFwkFH2Y4ijk5JkyU_003D2._0023_003DzopRx0_MBcTQs = this;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(sketch.ConvertToRegions().Select(_0023_003DzUe1S_0024HWFwkFH2Y4ijk5JkyU_003D2._0023_003DzFLW5ZaGz6fHDhwojVqI2LJs_003D).ToArray(), 0.0, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeIntersect(Region reg, double amount)
	{
		Brep b = reg.ExtrudeAsBrep(amount, 0.0, _rebuildTol);
		Brep[] array = Intersection(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeIntersect(Region reg, double amount, double angleInRadians)
	{
		Brep b = reg.ExtrudeAsBrep(reg.Plane.AxisZ * amount, angleInRadians, _rebuildTol);
		Brep[] array = Intersection(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeIntersect(Region reg, Interval amount)
	{
		Brep b = reg.ExtrudeAsBrep(amount, 0.0, _rebuildTol);
		Brep[] array = Intersection(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeIntersect(Sketch sketch, double amount)
	{
		_0023_003DzQicRXXHaEitj718W9hu_JU0_003D CS_0024_003C_003E8__locals4 = new _0023_003DzQicRXXHaEitj718W9hu_JU0_003D();
		CS_0024_003C_003E8__locals4._0023_003DzYNjcavt9guh2 = amount;
		CS_0024_003C_003E8__locals4._0023_003DzopRx0_MBcTQs = this;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D((from _0023_003DzBJFJHwk_003D in sketch.ConvertToRegions()
			select _0023_003DzBJFJHwk_003D.ExtrudeAsBrep(CS_0024_003C_003E8__locals4._0023_003DzYNjcavt9guh2, 0.0, CS_0024_003C_003E8__locals4._0023_003DzopRx0_MBcTQs._rebuildTol)).ToArray(), _rebuildTol, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Intersection(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeIntersect(Sketch sketch, double amount, double angleInRadians)
	{
		_0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D CS_0024_003C_003E8__locals6 = new _0023_003DzBmtIsDT_0024oh_0024x5jJgZ8NZ7Nc_003D();
		CS_0024_003C_003E8__locals6._0023_003DzYNjcavt9guh2 = amount;
		CS_0024_003C_003E8__locals6._0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D = angleInRadians;
		CS_0024_003C_003E8__locals6._0023_003DzopRx0_MBcTQs = this;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D((from _0023_003DzBJFJHwk_003D in sketch.ConvertToRegions()
			select _0023_003DzBJFJHwk_003D.ExtrudeAsBrep(CS_0024_003C_003E8__locals6._0023_003DzYNjcavt9guh2, CS_0024_003C_003E8__locals6._0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, CS_0024_003C_003E8__locals6._0023_003DzopRx0_MBcTQs._rebuildTol)).ToArray(), _rebuildTol, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Intersection(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeIntersect(Sketch sketch, Interval amount)
	{
		_0023_003DzMmUe4Z6aWCjTKT9gjvK6TGI_003D CS_0024_003C_003E8__locals4 = new _0023_003DzMmUe4Z6aWCjTKT9gjvK6TGI_003D();
		CS_0024_003C_003E8__locals4._0023_003DzYNjcavt9guh2 = amount;
		CS_0024_003C_003E8__locals4._0023_003DzopRx0_MBcTQs = this;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D((from _0023_003DzBJFJHwk_003D in sketch.ConvertToRegions()
			select _0023_003DzBJFJHwk_003D.ExtrudeAsBrep(CS_0024_003C_003E8__locals4._0023_003DzYNjcavt9guh2, 0.0, CS_0024_003C_003E8__locals4._0023_003DzopRx0_MBcTQs._rebuildTol)).ToArray(), _rebuildTol, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Intersection(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public void ExtrudeFace(int faceIndex, double amount)
	{
		Plane plane = Faces[faceIndex].IsPlanar();
		if (plane == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958818));
		}
		ExtrudeFace(faceIndex, plane.AxisZ * amount);
		RegenMode = regenType.RegenAndCompile;
	}

	public void ExtrudeFace(int faceIndex, Vector3D amount, double angleInRadians = 0.0)
	{
		Face face = Faces[faceIndex];
		if (face.IsPlanar() == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958818));
		}
		Region region = new Region(face.GetOrientedTrimLoops(Edges));
		Brep brep = region.ExtrudeAsBrep(amount, angleInRadians);
		int num = brep.Faces.Length - 2;
		int num2 = brep.Faces.Length - 1;
		bool _0023_003Dz7Fxltek9kn7U = Vector3D.Dot(amount, region.Plane.AxisZ) < 1E-06;
		_0023_003DzBvKljzDhzeqN(new int[1] { faceIndex }, brep, new int[1] { num }, new int[1] { num2 }, _0023_003Dz7Fxltek9kn7U);
		RegenMode = regenType.RegenAndCompile;
	}

	public void RevolveFace(int faceIndex, double deltaAngle, Vector3D axis, Point3D center)
	{
		Face face = Faces[faceIndex];
		if (face.IsPlanar() == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958818));
		}
		Region region = new Region(face.GetOrientedTrimLoops(Edges));
		Brep brep = region.RevolveAsBrep(deltaAngle, axis, center);
		bool flag = Utility.FixRevAngle(0.0, deltaAngle).t0 != 0.0;
		int num;
		int num2;
		if (flag)
		{
			num = brep.Faces.Length - 1;
			num2 = brep.Faces.Length - 2;
		}
		else
		{
			num = brep.Faces.Length - 2;
			num2 = brep.Faces.Length - 1;
		}
		bool _0023_003Dz7Fxltek9kn7U = Utility._0023_003Dzcgl1YHa2I1jhVm1Gy8K96dA_003D(region.ContourList[0], region.Plane.AxisZ, axis, center) == flag;
		_0023_003DzBvKljzDhzeqN(new int[1] { faceIndex }, brep, new int[1] { num }, new int[1] { num2 }, _0023_003Dz7Fxltek9kn7U);
		RegenMode = regenType.RegenAndCompile;
	}

	public bool AddFlange(int edgeIndex, double radius, double amount, double angle = Math.PI / 2.0)
	{
		if (!Edges[edgeIndex].Curve.IsLinear(RebuildTolerance, out var _))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958789));
		}
		if (angle <= 0.0 - RebuildTolerance)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958765));
		}
		int num = _0023_003DzWq8IAnpGDVDH41wQcE_0024kHssdawL0(edgeIndex);
		if (num == -1)
		{
			return false;
		}
		Face face = Faces[num];
		if (angle > RebuildTolerance)
		{
			Vector3D vector3D = null;
			for (int i = 0; i < Faces[num].Loops[0].Segments.Length; i++)
			{
				if (face.Loops[0].Segments[i].CurveIndex == edgeIndex)
				{
					Vector3D vector3D2 = (Vector3D)Edges[edgeIndex].Curve.StartTangent.Clone();
					if (face.Loops[0].Sense != face.Loops[0].Segments[i].Sense)
					{
						vector3D2.Negate();
					}
					vector3D2.Normalize();
					vector3D = vector3D2;
					break;
				}
			}
			if (vector3D == null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959474));
			}
			Vector3D vector3D3 = Vector3D.Cross(vector3D, face.plane.AxisZ);
			vector3D3.Normalize();
			Point3D center = Edges[edgeIndex].Curve.StartPoint + vector3D3 * radius;
			RevolveFace(num, angle, vector3D, center);
		}
		if (amount >= RebuildTolerance)
		{
			ExtrudeFace(num, amount);
		}
		else if (angle < RebuildTolerance)
		{
			return false;
		}
		RegenMode = regenType.RegenAndCompile;
		return true;
	}

	public bool RevolveRemove(Region reg, double angle, Vector3D axis, Point3D center)
	{
		Brep b = reg.RevolveAsBrep(0.0, angle, axis, center);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveRemove(Region reg, double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		Brep b = reg.RevolveAsBrep(startAngle, deltaAngle, axis, center);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveRemove(Region reg, Interval intervalAngle, Vector3D axis, Point3D center)
	{
		return RevolveRemove(reg, intervalAngle.Low, intervalAngle.High, axis, center);
	}

	public bool RevolveRemove(Sketch sketch, double angle, Vector3D axis, Point3D center)
	{
		_0023_003DzR1M0JjuLm2wkLBjgh__3KF0_003D _0023_003DzR1M0JjuLm2wkLBjgh__3KF0_003D2 = new _0023_003DzR1M0JjuLm2wkLBjgh__3KF0_003D();
		_0023_003DzR1M0JjuLm2wkLBjgh__3KF0_003D2._0023_003Dz6pajdGM_003D = angle;
		_0023_003DzR1M0JjuLm2wkLBjgh__3KF0_003D2._0023_003DzxuJqjrs_003D = axis;
		_0023_003DzR1M0JjuLm2wkLBjgh__3KF0_003D2._0023_003DzbUvT9Pc_003D = center;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(sketch.ConvertToRegions().Select(_0023_003DzR1M0JjuLm2wkLBjgh__3KF0_003D2._0023_003DzNrVDzc_aaXzvnFKiMBP5140_003D).ToArray(), 0.0, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveRemove(Sketch sketch, double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		_0023_003Dz_9guY0O3vt0UEyykOm8q_t4_003D _0023_003Dz_9guY0O3vt0UEyykOm8q_t4_003D2 = new _0023_003Dz_9guY0O3vt0UEyykOm8q_t4_003D();
		_0023_003Dz_9guY0O3vt0UEyykOm8q_t4_003D2._0023_003Dz3veEI49c6b6Q = startAngle;
		_0023_003Dz_9guY0O3vt0UEyykOm8q_t4_003D2._0023_003DzFINJ6s3Z_0024n8G = deltaAngle;
		_0023_003Dz_9guY0O3vt0UEyykOm8q_t4_003D2._0023_003DzxuJqjrs_003D = axis;
		_0023_003Dz_9guY0O3vt0UEyykOm8q_t4_003D2._0023_003DzbUvT9Pc_003D = center;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(sketch.ConvertToRegions().Select(_0023_003Dz_9guY0O3vt0UEyykOm8q_t4_003D2._0023_003DzNrVDzc_aaXzvnFKiMBP5140_003D).ToArray(), 0.0, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveRemove(Sketch sketch, Interval intervalAngle, Vector3D axis, Point3D center)
	{
		_0023_003Dz_OwNHlEru5e5qlpoNSmOxEk_003D _0023_003Dz_OwNHlEru5e5qlpoNSmOxEk_003D2 = new _0023_003Dz_OwNHlEru5e5qlpoNSmOxEk_003D();
		_0023_003Dz_OwNHlEru5e5qlpoNSmOxEk_003D2._0023_003DzJh6qrM9vQQk7 = intervalAngle;
		_0023_003Dz_OwNHlEru5e5qlpoNSmOxEk_003D2._0023_003DzxuJqjrs_003D = axis;
		_0023_003Dz_OwNHlEru5e5qlpoNSmOxEk_003D2._0023_003DzbUvT9Pc_003D = center;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(sketch.ConvertToRegions().Select(_0023_003Dz_OwNHlEru5e5qlpoNSmOxEk_003D2._0023_003DzNrVDzc_aaXzvnFKiMBP5140_003D).ToArray(), 0.0, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveAdd(Region reg, double angle, Vector3D axis, Point3D center)
	{
		Brep b = reg.RevolveAsBrep(0.0, angle, axis, center, _rebuildTol);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveAdd(Region reg, double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		Brep b = reg.RevolveAsBrep(startAngle, deltaAngle, axis, center, _rebuildTol);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveAdd(Region reg, Interval intervalAngle, Vector3D axis, Point3D center)
	{
		Brep b = reg.RevolveAsBrep(intervalAngle, axis, center, _rebuildTol);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveAdd(Sketch sketch, double angle, Vector3D axis, Point3D center)
	{
		_0023_003DzOitZJ30tn5_gRGODHg0w9aw_003D CS_0024_003C_003E8__locals6 = new _0023_003DzOitZJ30tn5_gRGODHg0w9aw_003D();
		CS_0024_003C_003E8__locals6._0023_003Dz6pajdGM_003D = angle;
		CS_0024_003C_003E8__locals6._0023_003DzxuJqjrs_003D = axis;
		CS_0024_003C_003E8__locals6._0023_003DzbUvT9Pc_003D = center;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D((from _0023_003DzBJFJHwk_003D in sketch.ConvertToRegions()
			select _0023_003DzBJFJHwk_003D.RevolveAsBrep(0.0, CS_0024_003C_003E8__locals6._0023_003Dz6pajdGM_003D, CS_0024_003C_003E8__locals6._0023_003DzxuJqjrs_003D, CS_0024_003C_003E8__locals6._0023_003DzbUvT9Pc_003D)).ToArray(), 0.0, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveAdd(Sketch sketch, double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		_0023_003DzgSMWbzn8QRdeH45pLIHu_WU_003D CS_0024_003C_003E8__locals10 = new _0023_003DzgSMWbzn8QRdeH45pLIHu_WU_003D();
		CS_0024_003C_003E8__locals10._0023_003Dz3veEI49c6b6Q = startAngle;
		CS_0024_003C_003E8__locals10._0023_003DzFINJ6s3Z_0024n8G = deltaAngle;
		CS_0024_003C_003E8__locals10._0023_003DzxuJqjrs_003D = axis;
		CS_0024_003C_003E8__locals10._0023_003DzbUvT9Pc_003D = center;
		CS_0024_003C_003E8__locals10._0023_003DzopRx0_MBcTQs = this;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D((from _0023_003DzBJFJHwk_003D in sketch.ConvertToRegions()
			select _0023_003DzBJFJHwk_003D.RevolveAsBrep(CS_0024_003C_003E8__locals10._0023_003Dz3veEI49c6b6Q, CS_0024_003C_003E8__locals10._0023_003DzFINJ6s3Z_0024n8G, CS_0024_003C_003E8__locals10._0023_003DzxuJqjrs_003D, CS_0024_003C_003E8__locals10._0023_003DzbUvT9Pc_003D, CS_0024_003C_003E8__locals10._0023_003DzopRx0_MBcTQs._rebuildTol)).ToArray(), 0.0, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveAdd(Sketch sketch, Interval intervalAngle, Vector3D axis, Point3D center)
	{
		_0023_003Dziqg6bP_WKWBFTUiOdzXzVpQ_003D CS_0024_003C_003E8__locals8 = new _0023_003Dziqg6bP_WKWBFTUiOdzXzVpQ_003D();
		CS_0024_003C_003E8__locals8._0023_003DzJh6qrM9vQQk7 = intervalAngle;
		CS_0024_003C_003E8__locals8._0023_003DzxuJqjrs_003D = axis;
		CS_0024_003C_003E8__locals8._0023_003DzbUvT9Pc_003D = center;
		CS_0024_003C_003E8__locals8._0023_003DzopRx0_MBcTQs = this;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D((from _0023_003DzBJFJHwk_003D in sketch.ConvertToRegions()
			select _0023_003DzBJFJHwk_003D.RevolveAsBrep(CS_0024_003C_003E8__locals8._0023_003DzJh6qrM9vQQk7, CS_0024_003C_003E8__locals8._0023_003DzxuJqjrs_003D, CS_0024_003C_003E8__locals8._0023_003DzbUvT9Pc_003D, CS_0024_003C_003E8__locals8._0023_003DzopRx0_MBcTQs._rebuildTol)).ToArray(), 0.0, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveIntersect(Region reg, double angle, Vector3D axis, Point3D center)
	{
		Brep b = reg.RevolveAsBrep(0.0, angle, axis, center, _rebuildTol);
		Brep[] array = Intersection(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveIntersect(Region reg, double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		Brep b = reg.RevolveAsBrep(startAngle, deltaAngle, axis, center, _rebuildTol);
		Brep[] array = Intersection(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveIntersect(Sketch sketch, double angle, Vector3D axis, Point3D center)
	{
		_0023_003DzMWfQIqNU0l3e4CpzA_00248LyOY_003D _0023_003DzMWfQIqNU0l3e4CpzA_00248LyOY_003D2 = new _0023_003DzMWfQIqNU0l3e4CpzA_00248LyOY_003D();
		_0023_003DzMWfQIqNU0l3e4CpzA_00248LyOY_003D2._0023_003Dz6pajdGM_003D = angle;
		_0023_003DzMWfQIqNU0l3e4CpzA_00248LyOY_003D2._0023_003DzxuJqjrs_003D = axis;
		_0023_003DzMWfQIqNU0l3e4CpzA_00248LyOY_003D2._0023_003DzbUvT9Pc_003D = center;
		_0023_003DzMWfQIqNU0l3e4CpzA_00248LyOY_003D2._0023_003DzopRx0_MBcTQs = this;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(sketch.ConvertToRegions().Select(_0023_003DzMWfQIqNU0l3e4CpzA_00248LyOY_003D2._0023_003DzppdwzV1WlOIza1L6gdCNVhU_003D).ToArray(), _rebuildTol, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Intersection(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveIntersect(Sketch sketch, double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		_0023_003DzYWh1m3jkC1VdKrr1j2zjFyI_003D _0023_003DzYWh1m3jkC1VdKrr1j2zjFyI_003D2 = new _0023_003DzYWh1m3jkC1VdKrr1j2zjFyI_003D();
		_0023_003DzYWh1m3jkC1VdKrr1j2zjFyI_003D2._0023_003Dz3veEI49c6b6Q = startAngle;
		_0023_003DzYWh1m3jkC1VdKrr1j2zjFyI_003D2._0023_003DzFINJ6s3Z_0024n8G = deltaAngle;
		_0023_003DzYWh1m3jkC1VdKrr1j2zjFyI_003D2._0023_003DzxuJqjrs_003D = axis;
		_0023_003DzYWh1m3jkC1VdKrr1j2zjFyI_003D2._0023_003DzbUvT9Pc_003D = center;
		_0023_003DzYWh1m3jkC1VdKrr1j2zjFyI_003D2._0023_003DzopRx0_MBcTQs = this;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(sketch.ConvertToRegions().Select(_0023_003DzYWh1m3jkC1VdKrr1j2zjFyI_003D2._0023_003DzppdwzV1WlOIza1L6gdCNVhU_003D).ToArray(), _rebuildTol, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Intersection(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool Remove(params Brep[] breps)
	{
		Brep[] leftOvers;
		return Remove(breps, out leftOvers);
	}

	public bool Remove(IList<Brep> breps, out Brep[] leftOvers)
	{
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(breps, _rebuildTol, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		leftOvers = null;
		Brep[] array = Difference(this, b);
		if (array != null && array.Length != 0)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			if (array.Length > 1)
			{
				leftOvers = new Brep[array.Length - 1];
				Array.Copy(array, 1, leftOvers, 0, leftOvers.Length);
			}
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool SweepAdd(Region reg, ICurve rail, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		Brep b = reg.SweepAsBrep(rail, _rebuildTol, methodType);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool SweepAdd(Sketch sketch, ICurve rail, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		_0023_003Dzb1l_0024mcPKROAtwjGD_N6o9S0_003D _0023_003Dzb1l_0024mcPKROAtwjGD_N6o9S0_003D2 = new _0023_003Dzb1l_0024mcPKROAtwjGD_N6o9S0_003D();
		_0023_003Dzb1l_0024mcPKROAtwjGD_N6o9S0_003D2._0023_003DzHgrHIfhYCh4p = rail;
		_0023_003Dzb1l_0024mcPKROAtwjGD_N6o9S0_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003Dzb1l_0024mcPKROAtwjGD_N6o9S0_003D2._0023_003Dzjy_YX_0024o_003D = methodType;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(sketch.ConvertToRegions().Select(_0023_003Dzb1l_0024mcPKROAtwjGD_N6o9S0_003D2._0023_003Dzu3rGnZ_TtjfFiDgNmw_003D_003D).ToArray(), _rebuildTol, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool SweepIntersect(Region reg, ICurve rail, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		Brep b = reg.SweepAsBrep(rail, _rebuildTol, methodType);
		Brep[] array = Intersection(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool SweepIntersect(Sketch sketch, ICurve rail, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		_0023_003DzfPLa4vQ_0024dOEb_Vf7VTSIqoc_003D _0023_003DzfPLa4vQ_0024dOEb_Vf7VTSIqoc_003D2 = new _0023_003DzfPLa4vQ_0024dOEb_Vf7VTSIqoc_003D();
		_0023_003DzfPLa4vQ_0024dOEb_Vf7VTSIqoc_003D2._0023_003DzHgrHIfhYCh4p = rail;
		_0023_003DzfPLa4vQ_0024dOEb_Vf7VTSIqoc_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzfPLa4vQ_0024dOEb_Vf7VTSIqoc_003D2._0023_003Dzjy_YX_0024o_003D = methodType;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(sketch.ConvertToRegions().Select(_0023_003DzfPLa4vQ_0024dOEb_Vf7VTSIqoc_003D2._0023_003DzCxtESBJgnxorvJ0sXQ_003D_003D).ToArray(), _rebuildTol, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Intersection(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool SweepRemove(Region reg, ICurve rail, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		Brep b = reg.SweepAsBrep(rail, _rebuildTol, methodType);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool SweepRemove(Sketch sketch, ICurve rail, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		_0023_003DzHGlGj7oYIL6hV3aiCu4SRzE_003D _0023_003DzHGlGj7oYIL6hV3aiCu4SRzE_003D2 = new _0023_003DzHGlGj7oYIL6hV3aiCu4SRzE_003D();
		_0023_003DzHGlGj7oYIL6hV3aiCu4SRzE_003D2._0023_003DzHgrHIfhYCh4p = rail;
		_0023_003DzHGlGj7oYIL6hV3aiCu4SRzE_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzHGlGj7oYIL6hV3aiCu4SRzE_003D2._0023_003Dzjy_YX_0024o_003D = methodType;
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(sketch.ConvertToRegions().Select(_0023_003DzHGlGj7oYIL6hV3aiCu4SRzE_003D2._0023_003Dzc1iv6ohqRQwfCjyJuA_003D_003D).ToArray(), _rebuildTol, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Difference(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool Add(params Brep[] solids)
	{
		Brep b = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(solids, _rebuildTol, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: false);
		Brep[] array = Union(this, b);
		if (array != null)
		{
			_0023_003Dzd55uIPSKitfg(array[0]._vertices, array[0]._edges, array[0]._faces, array[0]._inners);
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	private static Brep _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(IList<Brep> _0023_003DzH6GDaaq_lIr4, double _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, bool _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D)
	{
		if (_0023_003DzGvLz4uh736QEMEZuVg_003D_003D == 0.0)
		{
			_0023_003DzGvLz4uh736QEMEZuVg_003D_003D = 0.001;
		}
		List<Point3D> list = new List<Point3D>();
		List<Edge> list2 = new List<Edge>();
		List<Face> list3 = new List<Face>();
		Face[][] array = (_0023_003DzRb83x_TfwJW2hnkcYA_003D_003D ? new Face[_0023_003DzH6GDaaq_lIr4.Count - 1][] : null);
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < _0023_003DzH6GDaaq_lIr4.Count; i++)
		{
			Brep brep = (Brep)_0023_003DzH6GDaaq_lIr4[i].Clone();
			_0023_003Dz8VkxvzXXGxA_0024(brep.Vertices, brep.Edges, brep.Faces, brep.Inners, _0023_003DzLuJVbec_003D: true);
			list.AddRange(brep.Vertices);
			for (int j = 0; j < brep.Edges.Length; j++)
			{
				brep.Edges[j].StartPointIndex += num;
				brep.Edges[j].EndPointIndex += num;
				brep.Edges[j].Parents = null;
				list2.Add(brep.Edges[j]);
			}
			if (i == 0 || !_0023_003DzRb83x_TfwJW2hnkcYA_003D_003D)
			{
				for (int k = 0; k < brep.Faces.Length; k++)
				{
					Loop[] loops = brep.Faces[k].Loops;
					foreach (Loop loop in loops)
					{
						for (int m = 0; m < loop.Segments.Length; m++)
						{
							loop.Segments[m].CurveIndex += num2;
						}
					}
					list3.Add(brep.Faces[k]);
				}
			}
			else
			{
				array[i - 1] = new Face[brep.Faces.Length];
				for (int n = 0; n < brep.Faces.Length; n++)
				{
					Loop[] loops = brep.Faces[n].Loops;
					foreach (Loop loop2 in loops)
					{
						loop2.Sense = !loop2.Sense;
						for (int num3 = 0; num3 < loop2.Segments.Length; num3++)
						{
							loop2.Segments[num3].CurveIndex += num2;
						}
					}
					Face face = brep.Faces[n];
					face.Sense = !face.Sense;
					array[i - 1][n] = brep.Faces[n];
				}
			}
			num += brep.Vertices.Length;
			num2 += brep.Edges.Length;
		}
		return new Brep(list.ToArray(), list2.ToArray(), list3.ToArray(), array, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D);
	}

	private int _0023_003DzmRDRobofPXgJ(double _0023_003Dzt_m8zV0_003D, double _0023_003Dzm0CYiiE_003D)
	{
		return (int)Math.Floor(_0023_003Dzt_m8zV0_003D / _0023_003Dzm0CYiiE_003D);
	}

	private void _0023_003DznTKML6d77Pen(Dictionary<(int, int, int), List<Point3D>> _0023_003Dz38O0SCk69Nfz, Point3D _0023_003DzkEYxO1SuR1Kw, double _0023_003Dzm0CYiiE_003D)
	{
		(int, int, int) key = (_0023_003DzmRDRobofPXgJ(_0023_003DzkEYxO1SuR1Kw.X, _0023_003Dzm0CYiiE_003D), _0023_003DzmRDRobofPXgJ(_0023_003DzkEYxO1SuR1Kw.Y, _0023_003Dzm0CYiiE_003D), _0023_003DzmRDRobofPXgJ(_0023_003DzkEYxO1SuR1Kw.Z, _0023_003Dzm0CYiiE_003D));
		if (!_0023_003Dz38O0SCk69Nfz.TryGetValue(key, out var value))
		{
			value = (_0023_003Dz38O0SCk69Nfz[key] = new List<Point3D>());
		}
		value.Add(_0023_003DzkEYxO1SuR1Kw);
	}

	internal int _0023_003DzAEmsloOmWi0D(Point3D _0023_003Dz77g161c_003D, Dictionary<(int, int, int), List<Point3D>> _0023_003Dz38O0SCk69Nfz, Dictionary<Point3D, int> _0023_003DzFEBbkrN764AeVqB0tGM3Bro_003D, double _0023_003Dzm0CYiiE_003D, double _0023_003Dzrl1US_TwBOGL)
	{
		int num = _0023_003DzmRDRobofPXgJ(_0023_003Dz77g161c_003D.X, _0023_003Dzm0CYiiE_003D);
		int num2 = _0023_003DzmRDRobofPXgJ(_0023_003Dz77g161c_003D.Y, _0023_003Dzm0CYiiE_003D);
		int num3 = _0023_003DzmRDRobofPXgJ(_0023_003Dz77g161c_003D.Z, _0023_003Dzm0CYiiE_003D);
		for (int i = -1; i <= 1; i++)
		{
			for (int j = -1; j <= 1; j++)
			{
				for (int k = -1; k <= 1; k++)
				{
					(int, int, int) key = (num + i, num2 + j, num3 + k);
					if (!_0023_003Dz38O0SCk69Nfz.TryGetValue(key, out var value))
					{
						continue;
					}
					foreach (Point3D item in value)
					{
						if (Point3D.DistanceSquared(item, _0023_003Dz77g161c_003D) < _0023_003Dzrl1US_TwBOGL)
						{
							return _0023_003DzFEBbkrN764AeVqB0tGM3Bro_003D[item];
						}
					}
				}
			}
		}
		return -1;
	}

	internal void _0023_003DzCzO_0024rIw_0024_51emANn3A_003D_003D(Brep[] _0023_003DzdgpPaxHk1dVsWmzKlA_003D_003D)
	{
		double _0023_003Dzrl1US_TwBOGL = _rebuildTol * _rebuildTol;
		List<Vertex> list = new List<Vertex>();
		Dictionary<(int, int, int), List<Point3D>> _0023_003Dz38O0SCk69Nfz = new Dictionary<(int, int, int), List<Point3D>>();
		Dictionary<Point3D, int> dictionary = new Dictionary<Point3D, int>();
		List<int> list2 = new List<int>();
		for (int i = 0; i < _vertices.Length; i++)
		{
			Vertex vertex = (Vertex)_vertices[i];
			list.Add(vertex);
			if (vertex == null)
			{
				list2.Add(i);
				continue;
			}
			vertex.Parents = null;
			_0023_003DznTKML6d77Pen(_0023_003Dz38O0SCk69Nfz, vertex, _rebuildTol);
			dictionary[vertex] = i;
		}
		Dictionary<int, int>[] array = new Dictionary<int, int>[_0023_003DzdgpPaxHk1dVsWmzKlA_003D_003D.Length];
		int num = 0;
		for (int j = 0; j < _0023_003DzdgpPaxHk1dVsWmzKlA_003D_003D.Length; j++)
		{
			Brep brep = _0023_003DzdgpPaxHk1dVsWmzKlA_003D_003D[j];
			Dictionary<int, int> dictionary2 = (array[j] = new Dictionary<int, int>());
			for (int k = 0; k < brep._vertices.Length; k++)
			{
				Vertex vertex2 = (Vertex)brep._vertices[k];
				int num2 = _0023_003DzAEmsloOmWi0D(vertex2, _0023_003Dz38O0SCk69Nfz, dictionary, _rebuildTol, _0023_003Dzrl1US_TwBOGL);
				if (num2 >= 0)
				{
					dictionary2[k] = num2;
					continue;
				}
				vertex2.Parents = null;
				int num3;
				if (num < list2.Count)
				{
					num3 = list2[num++];
					list[num3] = vertex2;
				}
				else
				{
					num3 = list.Count;
					list.Add(vertex2);
				}
				dictionary2[k] = num3;
				dictionary[vertex2] = num3;
				_0023_003DznTKML6d77Pen(_0023_003Dz38O0SCk69Nfz, vertex2, _rebuildTol);
			}
		}
		List<Edge> list3 = new List<Edge>();
		Dictionary<(int, int), int> dictionary3 = new Dictionary<(int, int), int>();
		List<int> list4 = new List<int>();
		for (int l = 0; l < _edges.Length; l++)
		{
			Edge edge = _edges[l];
			list3.Add(edge);
			if (edge == null)
			{
				list4.Add(l);
				continue;
			}
			if (edge.Parents.Length == 1)
			{
				dictionary3[(edge.StartPointIndex, edge.EndPointIndex)] = l;
			}
			edge.Parents = null;
		}
		HashSet<int>[] array2 = new HashSet<int>[_0023_003DzdgpPaxHk1dVsWmzKlA_003D_003D.Length];
		Dictionary<int, int>[] array3 = new Dictionary<int, int>[_0023_003DzdgpPaxHk1dVsWmzKlA_003D_003D.Length];
		int _0023_003DzYf7O2SrIVfDfqHM2hw_003D_003D = 0;
		for (int m = 0; m < _0023_003DzdgpPaxHk1dVsWmzKlA_003D_003D.Length; m++)
		{
			Brep brep2 = _0023_003DzdgpPaxHk1dVsWmzKlA_003D_003D[m];
			Dictionary<int, int> dictionary4 = (array3[m] = new Dictionary<int, int>());
			HashSet<int> hashSet = (array2[m] = new HashSet<int>());
			Dictionary<int, int> dictionary5 = array[m];
			for (int n = 0; n < brep2._edges.Length; n++)
			{
				Edge edge2 = brep2._edges[n];
				(int, int) tuple = (dictionary5[edge2.StartPointIndex], dictionary5[edge2.EndPointIndex]);
				if (edge2.Parents.Length == 1)
				{
					if (dictionary3.TryGetValue(tuple, out var value))
					{
						dictionary4[n] = value;
					}
					else if (dictionary3.TryGetValue((tuple.Item2, tuple.Item1), out value))
					{
						dictionary4[n] = value;
						hashSet.Add(n);
					}
					else
					{
						_0023_003DzLmdgIrEZjFJj(n, edge2, tuple, dictionary4, list4, ref _0023_003DzYf7O2SrIVfDfqHM2hw_003D_003D, list3, dictionary3);
					}
				}
				else
				{
					_0023_003DzLmdgIrEZjFJj(n, edge2, tuple, dictionary4, list4, ref _0023_003DzYf7O2SrIVfDfqHM2hw_003D_003D, list3, dictionary3);
				}
			}
		}
		List<Face> list5 = new List<Face>();
		List<int> list6 = new List<int>();
		for (int num4 = 0; num4 < _faces.Length; num4++)
		{
			Face face = _faces[num4];
			list5.Add(face);
			if (face == null)
			{
				list6.Add(num4);
			}
		}
		int num5 = 0;
		for (int num6 = 0; num6 < _0023_003DzdgpPaxHk1dVsWmzKlA_003D_003D.Length; num6++)
		{
			Brep brep3 = _0023_003DzdgpPaxHk1dVsWmzKlA_003D_003D[num6];
			Dictionary<int, int> dictionary6 = array3[num6];
			HashSet<int> hashSet2 = array2[num6];
			for (int num7 = 0; num7 < brep3._faces.Length; num7++)
			{
				Face face2 = brep3._faces[num7];
				for (int num8 = 0; num8 < face2.Loops.Length; num8++)
				{
					Loop loop = face2.Loops[num8];
					for (int num9 = 0; num9 < loop.Segments.Length; num9++)
					{
						if (hashSet2.Contains(loop.Segments[num9].CurveIndex))
						{
							ref bool sense = ref loop.Segments[num9].Sense;
							sense = !sense;
						}
						loop.Segments[num9].CurveIndex = dictionary6[loop.Segments[num9].CurveIndex];
					}
				}
				Surface[] parametric = face2.Parametric;
				for (int num10 = 0; num10 < parametric.Length; num10++)
				{
					foreach (ICurve contour in parametric[num10].Trimming.contourList)
					{
						ICurve[] individualCurves = contour.GetIndividualCurves();
						for (int num11 = 0; num11 < individualCurves.Length; num11++)
						{
							TrimCurve trimCurve = (TrimCurve)individualCurves[num11];
							int edgeIndex = (trimCurve.EdgeIndex = dictionary6[trimCurve.EdgeIndex]);
							trimCurve.Edge.EdgeIndex = edgeIndex;
						}
					}
				}
				if (num5 < list6.Count)
				{
					list5[list6[num5++]] = face2;
				}
				else
				{
					list5.Add(face2);
				}
			}
		}
		Dictionary<int, int> dictionary7 = null;
		Dictionary<int, int> dictionary8 = null;
		if (num < list2.Count)
		{
			dictionary7 = _0023_003Dz_0024Lv19gY_003D(list);
		}
		if (_0023_003DzYf7O2SrIVfDfqHM2hw_003D_003D < list4.Count)
		{
			dictionary8 = _0023_003Dz_0024Lv19gY_003D(list3);
		}
		if (num5 < list6.Count)
		{
			list5.RemoveAll((Face _0023_003DzhidJeNw_003D) => _0023_003DzhidJeNw_003D == null);
		}
		if (dictionary7 != null)
		{
			foreach (Edge item in list3)
			{
				if (dictionary7.TryGetValue(item.StartPointIndex, out var value2))
				{
					item.StartPointIndex = value2;
				}
				if (dictionary7.TryGetValue(item.EndPointIndex, out var value3))
				{
					item.EndPointIndex = value3;
				}
			}
		}
		if (dictionary8 != null)
		{
			for (int num13 = list4[0]; num13 < list3.Count; num13++)
			{
				list3[num13].Curve.EdgeIndex = num13;
			}
			foreach (Face item2 in list5)
			{
				for (int num14 = 0; num14 < item2.Loops.Length; num14++)
				{
					Loop loop2 = item2.Loops[num14];
					for (int num15 = 0; num15 < loop2.Segments.Length; num15++)
					{
						if (dictionary8.TryGetValue(loop2.Segments[num15].CurveIndex, out var value4))
						{
							loop2.Segments[num15].CurveIndex = value4;
						}
					}
				}
				Surface[] parametric = item2.Parametric;
				for (int num10 = 0; num10 < parametric.Length; num10++)
				{
					foreach (ICurve contour2 in parametric[num10].Trimming.contourList)
					{
						ICurve[] individualCurves = contour2.GetIndividualCurves();
						for (int num11 = 0; num11 < individualCurves.Length; num11++)
						{
							TrimCurve trimCurve2 = (TrimCurve)individualCurves[num11];
							if (dictionary8.TryGetValue(trimCurve2.EdgeIndex, out var value5))
							{
								trimCurve2.EdgeIndex = value5;
								trimCurve2.Edge.EdgeIndex = value5;
							}
						}
					}
				}
			}
		}
		Point3D[] vertices = list.ToArray();
		Brep brep4 = new Brep(vertices, list3.ToArray(), list5.ToArray());
		_0023_003Dzd55uIPSKitfg(brep4._vertices, brep4._edges, brep4._faces, brep4._inners);
	}

	private Dictionary<int, int> _0023_003Dz_0024Lv19gY_003D<T>(List<T> _0023_003DzcDEsV8s_003D)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		int num = 0;
		for (int i = 0; i < _0023_003DzcDEsV8s_003D.Count; i++)
		{
			T val = _0023_003DzcDEsV8s_003D[i];
			if (val != null)
			{
				if (num != i)
				{
					_0023_003DzcDEsV8s_003D[num] = val;
					dictionary[i] = num;
				}
				num++;
			}
		}
		if (num < _0023_003DzcDEsV8s_003D.Count)
		{
			_0023_003DzcDEsV8s_003D.RemoveRange(num, _0023_003DzcDEsV8s_003D.Count - num);
		}
		return dictionary;
	}

	private void _0023_003DzLmdgIrEZjFJj(int _0023_003DzbfrNXYE_003D, Edge _0023_003DzTx2aqr8_003D, (int, int) _0023_003DzMi7phLEz0y6u, Dictionary<int, int> _0023_003DzTGnScLKrXNtr3IxvLg_003D_003D, List<int> _0023_003Dzqyf8i5CweszP, ref int _0023_003DzYf7O2SrIVfDfqHM2hw_003D_003D, List<Edge> _0023_003Dz01MONuQ2nbyU, Dictionary<(int, int), int> _0023_003Dz4R9FfTf_0024KRifi5mzuw_003D_003D)
	{
		Edge edge = (Edge)_0023_003DzTx2aqr8_003D.Clone();
		int num;
		if (_0023_003DzYf7O2SrIVfDfqHM2hw_003D_003D < _0023_003Dzqyf8i5CweszP.Count)
		{
			num = _0023_003Dzqyf8i5CweszP[_0023_003DzYf7O2SrIVfDfqHM2hw_003D_003D++];
			_0023_003Dz01MONuQ2nbyU[num] = edge;
		}
		else
		{
			num = _0023_003Dz01MONuQ2nbyU.Count;
			_0023_003Dz01MONuQ2nbyU.Add(edge);
		}
		(edge.StartPointIndex, edge.EndPointIndex) = _0023_003DzMi7phLEz0y6u;
		_0023_003Dz4R9FfTf_0024KRifi5mzuw_003D_003D[(_0023_003DzMi7phLEz0y6u.Item1, _0023_003DzMi7phLEz0y6u.Item2)] = num;
		_0023_003DzTGnScLKrXNtr3IxvLg_003D_003D[_0023_003DzbfrNXYE_003D] = num;
		edge.Parents = null;
	}

	public void RemoveFaces(params int[] facesToRemove)
	{
		if (facesToRemove.Length == 0)
		{
			return;
		}
		HashSet<int> hashSet = new HashSet<int>(facesToRemove);
		Face[] array = new Face[_faces.Length - hashSet.Count];
		Dictionary<int, int> dictionary = new Dictionary<int, int>(array.Length);
		int value = 0;
		for (int i = 0; i < _faces.Length; i++)
		{
			if (!hashSet.Contains(i))
			{
				dictionary[i] = value;
				array[value++] = _faces[i];
			}
		}
		List<Edge> list = new List<Edge>();
		HashSet<int> hashSet2 = new HashSet<int>();
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
		int num = 0;
		int num2 = -1;
		for (int j = 0; j < _edges.Length; j++)
		{
			Edge edge = _edges[j];
			if (edge.Parents == null)
			{
				hashSet2.Add(j);
				if (num2 < 0)
				{
					num2 = j;
				}
				continue;
			}
			List<int> list2 = new List<int>();
			int[] parents = edge.Parents;
			foreach (int num3 in parents)
			{
				if (!hashSet.Contains(num3) && dictionary.TryGetValue(num3, out var value2))
				{
					list2.Add(value2);
				}
			}
			if (list2.Count == 0)
			{
				hashSet2.Add(j);
				if (num2 < 0)
				{
					num2 = j;
				}
			}
			else
			{
				edge.Parents = list2.ToArray();
				dictionary2[j] = num++;
				list.Add(edge);
			}
		}
		if (list.Count < _edges.Length)
		{
			for (int l = num2; l < list.Count; l++)
			{
				list[l].Curve.EdgeIndex = l;
			}
			foreach (Face face in array)
			{
				for (int n = 0; n < face.Loops.Length; n++)
				{
					Loop loop = face.Loops[n];
					for (int num4 = 0; num4 < loop.Segments.Length; num4++)
					{
						loop.Segments[num4].CurveIndex = dictionary2[loop.Segments[num4].CurveIndex];
					}
				}
				if (face.Parametric == null)
				{
					continue;
				}
				Surface[] parametric = face.Parametric;
				for (int k = 0; k < parametric.Length; k++)
				{
					foreach (ICurve contour in parametric[k].Trimming.contourList)
					{
						ICurve[] individualCurves = contour.GetIndividualCurves();
						for (int num5 = 0; num5 < individualCurves.Length; num5++)
						{
							TrimCurve trimCurve = (TrimCurve)individualCurves[num5];
							if (dictionary2.TryGetValue(trimCurve.EdgeIndex, out var value3))
							{
								trimCurve.EdgeIndex = value3;
								trimCurve.Edge.EdgeIndex = value3;
							}
						}
					}
				}
			}
			_edges = list.ToArray();
		}
		List<Vertex> list3 = new List<Vertex>();
		HashSet<int> hashSet3 = new HashSet<int>();
		Dictionary<int, int> dictionary3 = new Dictionary<int, int>();
		int num6 = 0;
		for (int num7 = 0; num7 < _vertices.Length; num7++)
		{
			Vertex vertex = (Vertex)_vertices[num7];
			if (vertex.Parents == null)
			{
				hashSet3.Add(num7);
				continue;
			}
			List<int> list4 = new List<int>();
			int[] parents = vertex.Parents;
			foreach (int num8 in parents)
			{
				if (!hashSet2.Contains(num8) && dictionary2.TryGetValue(num8, out var value4))
				{
					list4.Add(value4);
				}
			}
			if (list4.Count == 0)
			{
				hashSet3.Add(num7);
				continue;
			}
			vertex.Parents = list4.ToArray();
			dictionary3[num7] = num6++;
			list3.Add(vertex);
		}
		if (list3.Count < _vertices.Length)
		{
			foreach (Edge item in list)
			{
				item.StartPointIndex = dictionary3[item.StartPointIndex];
				item.EndPointIndex = dictionary3[item.EndPointIndex];
			}
			Point3D[] vertices = list3.ToArray();
			_vertices = vertices;
		}
		_faces = array;
		RegenMode = regenType.RegenAndCompile;
	}

	internal void _0023_003DzgmNS3534EK2Tpn7R_0024vZ3IV6nlGvBJhYvcQ_003D_003D(int[] _0023_003DzZ066hTHjB3EN)
	{
		if (_0023_003DzZ066hTHjB3EN.Length == 0)
		{
			return;
		}
		HashSet<int> hashSet = new HashSet<int>(_0023_003DzZ066hTHjB3EN);
		for (int i = 0; i < _faces.Length; i++)
		{
			if (hashSet.Contains(i))
			{
				_faces[i] = null;
			}
		}
		for (int j = 0; j < _edges.Length; j++)
		{
			Edge edge = _edges[j];
			if (edge.Parents == null)
			{
				_edges[j] = null;
				continue;
			}
			List<int> list = new List<int>();
			int[] parents = edge.Parents;
			foreach (int num in parents)
			{
				if (_faces[num] != null)
				{
					list.Add(num);
				}
			}
			if (list.Count == 0)
			{
				_edges[j] = null;
			}
			else
			{
				edge.Parents = list.ToArray();
			}
		}
		for (int l = 0; l < _vertices.Length; l++)
		{
			Vertex vertex = (Vertex)_vertices[l];
			if (vertex.Parents == null)
			{
				_vertices[l] = null;
				continue;
			}
			List<int> list2 = new List<int>();
			int[] parents = vertex.Parents;
			foreach (int num2 in parents)
			{
				if (_edges[num2] != null)
				{
					list2.Add(num2);
				}
			}
			if (list2.Count == 0)
			{
				_vertices[l] = null;
			}
			else
			{
				vertex.Parents = list2.ToArray();
			}
		}
	}

	private static bool _0023_003Dzt8_0024zbuvCbXTx(Brep _0023_003DzQUhnjVe9kSO_0024, int _0023_003DzyzK8swU_003D, List<Edge> _0023_003DzVyFgxRzS_Yz8, Dictionary<int, List<int>> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, Dictionary<int, int> _0023_003DzV8Lcc5p5_0024hWB, Dictionary<int, int> _0023_003DzVR_NB33ieggi, Dictionary<int, List<ICurve>> _0023_003DzNsS6ffzfSlG6, List<Edge> _0023_003DzViGQVPM_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, List<Face> _0023_003DzUbkxYVFDH3ry, Color? _0023_003DzOn_quequ5gWQIBVpCg_003D_003D, string _0023_003DzMSePdGORTGCj6kcdWA_003D_003D, object _0023_003DzYJzQU0io36oJuCOj_0024A_003D_003D, bool _0023_003DzEt2Zcy_TSPx_0024)
	{
		Surface[] _0023_003Dz_0024AxqLU6JSbjFi59sUNmvveY_003D;
		Loop[][] array = _0023_003DzQUhnjVe9kSO_0024._0023_003DzgohMRFtWo4Kp0sv9bQ_003D_003D(_0023_003DzyzK8swU_003D, 0, _0023_003DzVyFgxRzS_Yz8, _0023_003DzViGQVPM_003D, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, _0023_003DzV8Lcc5p5_0024hWB, _0023_003DzVR_NB33ieggi, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003DzUbkxYVFDH3ry, _0023_003DzNsS6ffzfSlG6, out _0023_003Dz_0024AxqLU6JSbjFi59sUNmvveY_003D, _0023_003DzEt2Zcy_TSPx_0024);
		if (array == null)
		{
			return false;
		}
		Face face = _0023_003DzQUhnjVe9kSO_0024.Faces[_0023_003DzyzK8swU_003D];
		for (int i = 0; i < array.Length; i++)
		{
			Loop[] array2 = array[i];
			Plane plane = ((face.plane != null) ? ((Plane)face.plane.Clone()) : null);
			if (_0023_003DzEt2Zcy_TSPx_0024)
			{
				Loop[] array3 = array2;
				foreach (Loop loop in array3)
				{
					loop.Sense = !loop.Sense;
				}
				_0023_003Dz_0024AxqLU6JSbjFi59sUNmvveY_003D[i].ReverseU();
				if (plane != null)
				{
					plane.Flip();
				}
			}
			Face face2 = new Face((AnalyticSurf)face.Surface.Clone(), array2, _0023_003DzEt2Zcy_TSPx_0024 ? (!face.Sense) : face.Sense);
			face2._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(new Surface[1] { _0023_003Dz_0024AxqLU6JSbjFi59sUNmvveY_003D[i] });
			face2.planeAlreadySet = face.planeAlreadySet;
			face2.plane = plane;
			face2.Color = _0023_003DzOn_quequ5gWQIBVpCg_003D_003D ?? face.Color;
			face2.MaterialName = _0023_003DzMSePdGORTGCj6kcdWA_003D_003D ?? face.MaterialName;
			face2.FaceData = _0023_003DzYJzQU0io36oJuCOj_0024A_003D_003D ?? face.FaceData;
			Face face3 = face2;
			face3.Surface.TranslationID = new TranslationIdentifier(_0023_003DzUbkxYVFDH3ry.Count);
			_0023_003DzUbkxYVFDH3ry.Add(face3);
		}
		return true;
	}

	private static int _0023_003DzYrt453tI69Ce(Vertex _0023_003DzffqPLNQ_003D, Brep _0023_003DzqjniGGF9kvbc, TrimCurve _0023_003DzhvZXz_c_003D, List<Edge> _0023_003DzXSY01UdFdeAG, Dictionary<int, Dictionary<double, int>> _0023_003DzcMaHHKcJVuc0t4_0024H3CNIsvw_003D, Dictionary<int, int> _0023_003Dz6hfCi07v6l67, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, bool _0023_003DzMOzZi0xOKVJU)
	{
		int _0023_003DzqhsKlJc_003D = -1;
		double num = _0023_003DzqjniGGF9kvbc.RebuildTolerance;
		Loop[] loops = _0023_003DzqjniGGF9kvbc.Faces[_0023_003DzhvZXz_c_003D.FaceInfo._0023_003DzLJVtPYc_003D].Loops;
		for (int i = 0; i < loops.Length; i++)
		{
			OrientedEdge[] segments = loops[i].Segments;
			for (int j = 0; j < segments.Length; j++)
			{
				OrientedEdge orientedEdge = segments[j];
				if (_0023_003DzffqPLNQ_003D.IsOnCurve(_0023_003DzXSY01UdFdeAG[orientedEdge.CurveIndex].Curve, Utility._0023_003DzxhnLabVjXjPg, out var _, out var _))
				{
					num = Math.Min(num, _0023_003DzXSY01UdFdeAG[orientedEdge.CurveIndex].Curve.Length() / 100.0);
				}
			}
		}
		loops = _0023_003DzqjniGGF9kvbc.Faces[_0023_003DzhvZXz_c_003D.FaceInfo._0023_003DzLJVtPYc_003D].Loops;
		for (int i = 0; i < loops.Length; i++)
		{
			OrientedEdge[] segments = loops[i].Segments;
			for (int j = 0; j < segments.Length; j++)
			{
				OrientedEdge orientedEdge2 = segments[j];
				Edge _0023_003DzTx2aqr8_003D = _0023_003DzXSY01UdFdeAG[orientedEdge2.CurveIndex];
				if (_0023_003DzqjniGGF9kvbc._0023_003DzmwC6ucT5JizX(_0023_003DzTx2aqr8_003D, _0023_003DzffqPLNQ_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003DzcMaHHKcJVuc0t4_0024H3CNIsvw_003D, orientedEdge2.CurveIndex, _0023_003Dz6hfCi07v6l67, out _0023_003DzqhsKlJc_003D, _0023_003DzMOzZi0xOKVJU, num) != -1)
				{
					break;
				}
			}
		}
		return _0023_003DzqhsKlJc_003D;
	}

	private static void _0023_003DzJiYrREIJy046(Dictionary<int, Dictionary<double, int>> _0023_003DzPJcXXugv0JJMnYzeTQ_003D_003D, List<Edge> _0023_003DzVyFgxRzS_Yz8, Dictionary<int, List<int>> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, bool _0023_003Dz_d_002406W8syS3trhyv9w_003D_003D)
	{
		foreach (int key in _0023_003DzPJcXXugv0JJMnYzeTQ_003D_003D.Keys)
		{
			if (_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D.ContainsKey(key))
			{
				continue;
			}
			Edge[] array = _0023_003DzGe33fZySDaTf((Edge)_0023_003DzVyFgxRzS_Yz8[key].Clone(), _0023_003DzPJcXXugv0JJMnYzeTQ_003D_003D[key]);
			_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D.Add(key, new List<int>());
			for (int i = 0; i < array.Length; i++)
			{
				int item;
				if (_0023_003Dz_d_002406W8syS3trhyv9w_003D_003D && i == 0)
				{
					item = key;
					_0023_003DzVyFgxRzS_Yz8[key] = array[i];
				}
				else
				{
					item = _0023_003DzVyFgxRzS_Yz8.Count;
					_0023_003DzVyFgxRzS_Yz8.Add(array[i]);
				}
				_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D[key].Add(item);
			}
		}
	}

	private int _0023_003DzeapIrHLtVxHU(int _0023_003DzyzK8swU_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, Dictionary<int, int> _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, double _0023_003Dzm0CYiiE_003D)
	{
		_0023_003DzWHliiEg4_0024SUfoPqIJXt3ClA_003D _0023_003DzWHliiEg4_0024SUfoPqIJXt3ClA_003D2 = new _0023_003DzWHliiEg4_0024SUfoPqIJXt3ClA_003D();
		_0023_003DzWHliiEg4_0024SUfoPqIJXt3ClA_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzWHliiEg4_0024SUfoPqIJXt3ClA_003D2._0023_003DzyzK8swU_003D = _0023_003DzyzK8swU_003D;
		_0023_003DzWHliiEg4_0024SUfoPqIJXt3ClA_003D2._0023_003Dzm0CYiiE_003D = _0023_003Dzm0CYiiE_003D;
		int num;
		if (!_0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D.ContainsKey(_0023_003DzWHliiEg4_0024SUfoPqIJXt3ClA_003D2._0023_003DzyzK8swU_003D))
		{
			num = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.FindIndex(_0023_003DzWHliiEg4_0024SUfoPqIJXt3ClA_003D2._0023_003DzrIEiVv9b2y8KcdK_mw_003D_003D);
			if (num == -1)
			{
				num = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count;
				Vertex vertex = (Vertex)Vertices[_0023_003DzWHliiEg4_0024SUfoPqIJXt3ClA_003D2._0023_003DzyzK8swU_003D].Clone();
				vertex.Parents = null;
				_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(vertex);
			}
			_0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D.Add(_0023_003DzWHliiEg4_0024SUfoPqIJXt3ClA_003D2._0023_003DzyzK8swU_003D, num);
			((Vertex)Vertices[_0023_003DzWHliiEg4_0024SUfoPqIJXt3ClA_003D2._0023_003DzyzK8swU_003D]).Visited = true;
			((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num]).Visited = true;
		}
		else
		{
			num = _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D[_0023_003DzWHliiEg4_0024SUfoPqIJXt3ClA_003D2._0023_003DzyzK8swU_003D];
		}
		return num;
	}

	private static Edge[] _0023_003DzGe33fZySDaTf(Edge _0023_003DzmCM_0024s12le28l, Dictionary<double, int> _0023_003DzHkWtB_0024ITVdlN)
	{
		List<Edge> list = new List<Edge>();
		double[] array = _0023_003DzHkWtB_0024ITVdlN.Keys.ToArray();
		Array.Sort(array);
		int startPointIndex = _0023_003DzmCM_0024s12le28l.StartPointIndex;
		int endPointIndex = _0023_003DzHkWtB_0024ITVdlN[array[0]];
		Edge edge = (Edge)_0023_003DzmCM_0024s12le28l.Clone();
		if (_0023_003DzmCM_0024s12le28l.Curve.SubCurve(_0023_003DzmCM_0024s12le28l.Curve.Domain.Low, array[0], out var sub))
		{
			edge.Curve = sub;
			edge.StartPointIndex = startPointIndex;
			edge.EndPointIndex = endPointIndex;
			edge.SplitStatus = SplitEdgeStatus.StartFromVertex;
			if (startPointIndex != -1)
			{
				list.Add(edge);
			}
		}
		for (int i = 0; i < array.Length - 1; i++)
		{
			startPointIndex = _0023_003DzHkWtB_0024ITVdlN[array[i]];
			endPointIndex = _0023_003DzHkWtB_0024ITVdlN[array[i + 1]];
			_0023_003DzmCM_0024s12le28l.Curve.SubCurve(array[i], array[i + 1], out sub);
			edge = (Edge)_0023_003DzmCM_0024s12le28l.Clone();
			edge.Curve = sub;
			edge.StartPointIndex = startPointIndex;
			edge.EndPointIndex = endPointIndex;
			edge.SplitStatus = SplitEdgeStatus.MiddleSubEdge;
			list.Add(edge);
		}
		startPointIndex = _0023_003DzHkWtB_0024ITVdlN[array[^1]];
		endPointIndex = _0023_003DzmCM_0024s12le28l.EndPointIndex;
		if (_0023_003DzmCM_0024s12le28l.Curve.SubCurve(array[^1], _0023_003DzmCM_0024s12le28l.Curve.Domain.High, out sub))
		{
			edge = (Edge)_0023_003DzmCM_0024s12le28l.Clone();
			edge.Curve = sub;
			edge.StartPointIndex = startPointIndex;
			edge.EndPointIndex = endPointIndex;
			edge.SplitStatus = SplitEdgeStatus.EndToVertex;
			if (endPointIndex != -1)
			{
				list.Add(edge);
			}
		}
		return list.ToArray();
	}

	public static Brep[] Difference(Brep a, Brep b)
	{
		bool _0023_003DztLD2a19GFACn;
		Brep[] array = _0023_003DzFYrPwPw_003D(a, b, (_0023_003Dz4Hw_002424_0024xhqb8)2, out _0023_003DztLD2a19GFACn);
		if (array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (!_0023_003DztLD2a19GFACn && array[i].IsClosed && array[i].MergeFaces() == -1)
				{
					return null;
				}
				array[i].CopyAttributes(a);
			}
		}
		return array;
	}

	public static Brep[] Intersection(Brep a, Brep b)
	{
		bool _0023_003DztLD2a19GFACn;
		Brep[] array = _0023_003DzFYrPwPw_003D(a, b, (_0023_003Dz4Hw_002424_0024xhqb8)1, out _0023_003DztLD2a19GFACn);
		Brep[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].CopyAttributes(a);
		}
		return array;
	}

	public static Brep[] Union(Brep a, Brep b)
	{
		bool _0023_003DztLD2a19GFACn;
		Brep[] array = _0023_003DzFYrPwPw_003D(a, b, (_0023_003Dz4Hw_002424_0024xhqb8)0, out _0023_003DztLD2a19GFACn);
		if (array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (!_0023_003DztLD2a19GFACn && array[i].IsClosed && array[i].MergeFaces() == -1)
				{
					return null;
				}
				array[i].CopyAttributes(a);
			}
		}
		return array;
	}

	public static Brep[] Union(IList<Brep> breps)
	{
		if (breps.Count <= 1)
		{
			return breps.ToArray();
		}
		List<Brep> list = new List<Brep>();
		bool[] array = new bool[breps.Count];
		int num = 0;
		bool flag = false;
		while (!flag)
		{
			Brep brep = breps[num];
			array[num] = true;
			bool flag2;
			do
			{
				flag2 = false;
				for (int i = num + 1; i < breps.Count; i++)
				{
					if (!array[i])
					{
						Brep b = breps[i];
						Brep[] array2 = Union(brep, b);
						if (array2.Length == 1)
						{
							brep = array2[0];
							array[i] = true;
							flag2 = true;
						}
					}
				}
			}
			while (flag2);
			list.Add(brep);
			flag = true;
			for (int j = num + 1; j < breps.Count; j++)
			{
				if (!array[j])
				{
					flag = false;
					num = j;
					break;
				}
			}
		}
		return list.ToArray();
	}

	internal static Brep[] _0023_003DzFYrPwPw_003D(Brep _0023_003DzGaP3OdRQ6mc0, Brep _0023_003Dz2LW9YRh_lBXc, _0023_003Dz4Hw_002424_0024xhqb8 _0023_003DzjwXjJRWTdRfR, out bool _0023_003DztLD2a19GFACn)
	{
		bool flag = true;
		byte b = 3;
		object[] array = null;
		array = new object[3] { b, _0023_003DzGaP3OdRQ6mc0, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		Telemetry.Instance.AddUsage(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959468), Telemetry.moduleType.Booleans);
		_0023_003DzGaP3OdRQ6mc0.Rebuild(0.0, soft: true);
		_0023_003Dz2LW9YRh_lBXc.Rebuild(0.0, soft: true);
		Point3D[] _0023_003Dzwf2OU4pUJmjk;
		ICurve[] _0023_003DzHnOH3yIXp9ivQgg4BQ_003D_003D;
		Brep[] result = _0023_003DzzDn32WHo_7Y_0024(_0023_003DzGaP3OdRQ6mc0, _0023_003Dz2LW9YRh_lBXc, _0023_003DzjwXjJRWTdRfR, out _0023_003DztLD2a19GFACn, out _0023_003Dzwf2OU4pUJmjk, out _0023_003DzHnOH3yIXp9ivQgg4BQ_003D_003D);
		_0023_003Dz8VkxvzXXGxA_0024(_0023_003DzGaP3OdRQ6mc0.Vertices, _0023_003DzGaP3OdRQ6mc0.Edges, _0023_003DzGaP3OdRQ6mc0.Faces, _0023_003DzGaP3OdRQ6mc0.Inners, _0023_003DzLuJVbec_003D: false);
		_0023_003Dz8VkxvzXXGxA_0024(_0023_003Dz2LW9YRh_lBXc.Vertices, _0023_003Dz2LW9YRh_lBXc.Edges, _0023_003Dz2LW9YRh_lBXc.Faces, _0023_003Dz2LW9YRh_lBXc.Inners, _0023_003DzLuJVbec_003D: false);
		return result;
	}

	public static Brep[] Mirror(int planarFaceIndex, Brep solid)
	{
		AnalyticSurf surface = solid.Faces[planarFaceIndex].Surface;
		if (surface.GetType() != typeof(PlanarSurf))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959445));
		}
		Brep brep = (Brep)solid.Clone();
		brep.TransformBy(new Mirror(((PlanarSurf)surface).Plane));
		Brep[] array = Union(solid, brep);
		if (array == null)
		{
			return null;
		}
		Brep[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].CopyAttributes(solid);
		}
		return array;
	}

	public static Brep[] Mirror(Face planarFace, Brep solid)
	{
		if (planarFace.Surface.GetType() != typeof(PlanarSurf))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959445));
		}
		Brep brep = (Brep)solid.Clone();
		brep.TransformBy(new Mirror(((PlanarSurf)planarFace.Surface).Plane));
		Brep[] array = Union(solid, brep);
		if (array == null)
		{
			return null;
		}
		Brep[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].CopyAttributes(solid);
		}
		return array;
	}

	public static Brep[] Mirror(Plane mirrorPlane, Brep solid)
	{
		Brep brep = (Brep)solid.Clone();
		brep.TransformBy(new Mirror(mirrorPlane));
		Brep[] array = Union(solid, brep);
		if (array == null)
		{
			return null;
		}
		Brep[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].CopyAttributes(solid);
		}
		return array;
	}

	public static Brep MergeAndKeepFaces(Brep a, Brep b)
	{
		_0023_003Dzhlq5RKbWjx6nskJGYQMtB7C9hVAf(a, b, out var _, out var _, out var _, _0023_003Dzk_3tZjgmhGlmfKWn0g_003D_003D: false, _0023_003DzY7IAYN_00249VAHl11lbabS4sjVmDFI0: false);
		if (_0023_003DzgJ8N_I4FtIHFwcYxDiDmkdg_003D(a, b, (_0023_003Dz4Hw_002424_0024xhqb8)0, out var _0023_003Dz6Jdj4TI_003D, _0023_003DzJVWkwrC6nEkD: true))
		{
			return _0023_003Dz6Jdj4TI_003D[0];
		}
		_0023_003Dz8VkxvzXXGxA_0024(a.Vertices, a.Edges, a.Faces, a.Inners, _0023_003DzLuJVbec_003D: false);
		_0023_003Dz8VkxvzXXGxA_0024(b.Vertices, b.Edges, b.Faces, b.Inners, _0023_003DzLuJVbec_003D: false);
		return null;
	}

	public static bool MergeAndKeepFaces(IList<Brep> breps, out Brep merged)
	{
		Brep[] array = _0023_003DzJkvItQQEI_00247frneYBg_003D_003D(breps);
		if (array == null || array.Length == 0)
		{
			merged = null;
			return false;
		}
		merged = array[0];
		return array.Length == 1;
	}

	private static Brep[] _0023_003DzJkvItQQEI_00247frneYBg_003D_003D(IList<Brep> _0023_003DzgDmZd_0024DWZh3s)
	{
		List<Brep> list = new List<Brep>(_0023_003DzgDmZd_0024DWZh3s.Count);
		bool[] array = new bool[_0023_003DzgDmZd_0024DWZh3s.Count];
		Brep brep = null;
		for (int i = 0; i < _0023_003DzgDmZd_0024DWZh3s.Count; i++)
		{
			if (brep == null && array[i])
			{
				continue;
			}
			array[i] = true;
			bool flag = false;
			Brep brep2 = _0023_003DzgDmZd_0024DWZh3s[i];
			if (brep2 == null)
			{
				continue;
			}
			if (brep == null)
			{
				brep = brep2;
			}
			for (int j = i + 1; j < _0023_003DzgDmZd_0024DWZh3s.Count; j++)
			{
				if (!array[j])
				{
					Brep brep3 = MergeAndKeepFaces(_0023_003DzgDmZd_0024DWZh3s[j], brep);
					if (brep3 != null)
					{
						array[j] = true;
						flag = true;
						brep = brep3;
					}
				}
			}
			if (flag)
			{
				i--;
				continue;
			}
			list.Add(brep);
			brep = null;
		}
		return list.ToArray();
	}

	public static Brep MergeAndKeepFaces(Brep a, Brep b, MaterialKeyedCollection materials = null)
	{
		Brep brep = a;
		Brep brep2 = b;
		if (materials != null && !string.IsNullOrEmpty(a.MaterialName) && !string.IsNullOrEmpty(b.MaterialName))
		{
			brep = (Brep)a.Clone();
			brep2 = (Brep)b.Clone();
			Face[] faces = brep.Faces;
			foreach (Face face in faces)
			{
				face.Color = materials[brep.MaterialName].Diffuse;
				face.Subdomain = brep.MaterialName.GetHashCode();
			}
			faces = brep2.Faces;
			foreach (Face face2 in faces)
			{
				face2.Color = materials[brep2.MaterialName].Diffuse;
				face2.Subdomain = brep2.MaterialName.GetHashCode();
			}
			brep.Rebuild(0.0, soft: true);
			brep2.Rebuild(0.0, soft: true);
		}
		Brep brep3 = MergeAndKeepFaces(brep, brep2);
		if (brep3 == null)
		{
			return null;
		}
		return new Brep(brep3);
	}

	public static Brep MergeAndKeepFaces(IList<Brep> breps, MaterialKeyedCollection materials = null)
	{
		IList<Brep> list = breps;
		if (materials != null && breps.All(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzleZv6WH3Mo9S5rKrKbwtxT_c1ar1Nf6GAw_003D_003D))
		{
			list = new Brep[breps.Count];
			for (int i = 0; i < breps.Count; i++)
			{
				list[i] = (Brep)breps[i].Clone();
				list[i].Rebuild();
				Face[] faces = list[i].Faces;
				foreach (Face face in faces)
				{
					face.Color = materials[list[i].MaterialName].Diffuse;
					face.Subdomain = list[i].MaterialName.GetHashCode();
				}
			}
			if (MergeAndKeepFaces(list.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz8nsRIIMFnbkPm1gXVNq01bqATvNMexyh1A_003D_003D).ToArray(), out var merged))
			{
				return merged;
			}
			return null;
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959384));
	}

	internal static bool _0023_003DzgJ8N_I4FtIHFwcYxDiDmkdg_003D(Brep _0023_003DzqjniGGF9kvbc, Brep _0023_003Dzk0sekCclUGst, _0023_003Dz4Hw_002424_0024xhqb8 _0023_003DzwY9ClXw_003D, out Brep[] _0023_003Dz6Jdj4TI_003D, bool _0023_003DzJVWkwrC6nEkD)
	{
		_0023_003Dz6Jdj4TI_003D = new Brep[0];
		if (_0023_003Dz61QgbOL8M2D2epyN9w_003D_003D(_0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst, out var _0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D, out var _0023_003Dzjo59Kug_JL3x, out var _0023_003Dz4OZePitdhuZLxrhKfA_003D_003D, _0023_003DzwY9ClXw_003D == (_0023_003Dz4Hw_002424_0024xhqb8)0))
		{
			if (_0023_003Dz4OZePitdhuZLxrhKfA_003D_003D.Count == _0023_003DzqjniGGF9kvbc.Faces.Length && _0023_003DzqjniGGF9kvbc.Faces.Length == _0023_003Dzk0sekCclUGst.Faces.Length)
			{
				if (_0023_003DzwY9ClXw_003D != (_0023_003Dz4Hw_002424_0024xhqb8)2)
				{
					_0023_003Dz6Jdj4TI_003D = new Brep[1] { (Brep)_0023_003DzqjniGGF9kvbc.Clone() };
				}
				return true;
			}
			pointStatusType pointStatusType2 = pointStatusType.Onto;
			pointStatusType pointStatusType3 = pointStatusType.Onto;
			for (int i = 0; i < _0023_003Dzk0sekCclUGst.Vertices.Length; i++)
			{
				if (_0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D.ContainsKey(i))
				{
					continue;
				}
				pointStatusType pointStatusType4 = _0023_003DzqjniGGF9kvbc.IsPointInside(_0023_003Dzk0sekCclUGst.Vertices[i], skipRebuild: true);
				if (pointStatusType4 != pointStatusType.Undetermined)
				{
					if (pointStatusType2 == pointStatusType.Onto)
					{
						pointStatusType2 = pointStatusType4;
					}
					else if (pointStatusType4 != pointStatusType.Onto && pointStatusType2 != pointStatusType4)
					{
						return false;
					}
				}
			}
			for (int j = 0; j < _0023_003DzqjniGGF9kvbc.Vertices.Length; j++)
			{
				if (_0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D.ContainsValue(j))
				{
					continue;
				}
				pointStatusType pointStatusType5 = _0023_003Dzk0sekCclUGst.IsPointInside(_0023_003DzqjniGGF9kvbc.Vertices[j], skipRebuild: true);
				if (pointStatusType5 != pointStatusType.Undetermined)
				{
					if (pointStatusType3 == pointStatusType.Onto)
					{
						pointStatusType3 = pointStatusType5;
					}
					else if (pointStatusType5 != pointStatusType.Onto && pointStatusType3 != pointStatusType5)
					{
						return false;
					}
				}
			}
			if (pointStatusType2 == pointStatusType.Undetermined || pointStatusType3 == pointStatusType.Undetermined)
			{
				return false;
			}
			switch (_0023_003DzwY9ClXw_003D)
			{
			case (_0023_003Dz4Hw_002424_0024xhqb8)1:
				if (pointStatusType2 == pointStatusType.Inside || pointStatusType2 == pointStatusType.Onto)
				{
					_0023_003Dz6Jdj4TI_003D = new Brep[1] { (Brep)_0023_003Dzk0sekCclUGst.Clone() };
					return true;
				}
				if (pointStatusType3 == pointStatusType.Inside || pointStatusType2 == pointStatusType.Onto)
				{
					_0023_003Dz6Jdj4TI_003D = new Brep[1] { (Brep)_0023_003DzqjniGGF9kvbc.Clone() };
					return true;
				}
				return false;
			case (_0023_003Dz4Hw_002424_0024xhqb8)2:
				if (pointStatusType2 == pointStatusType.Outside && pointStatusType3 == pointStatusType.Inside)
				{
					_0023_003Dz6Jdj4TI_003D = new Brep[0];
					return true;
				}
				if (pointStatusType2 == pointStatusType.Outside && pointStatusType3 == pointStatusType.Outside)
				{
					return false;
				}
				break;
			}
			Brep brep = _0023_003Dzvsag8z_YSTdoVQOKsa9XViI_003D(_0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst, _0023_003DzwY9ClXw_003D == (_0023_003Dz4Hw_002424_0024xhqb8)2, _0023_003Dz4OZePitdhuZLxrhKfA_003D_003D, _0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D, _0023_003Dzjo59Kug_JL3x, -1, -1, _0023_003DzJVWkwrC6nEkD);
			if (brep != null)
			{
				_0023_003Dz6Jdj4TI_003D = new Brep[1] { brep };
				return true;
			}
		}
		return false;
	}

	private static Brep _0023_003Dzvsag8z_YSTdoVQOKsa9XViI_003D(Brep _0023_003DzqjniGGF9kvbc, Brep _0023_003Dzk0sekCclUGst, bool _0023_003DzRc9F6BRuOvkMZTotrXhyjts_003D, Dictionary<int, int> _0023_003Dz4OZePitdhuZLxrhKfA_003D_003D, Dictionary<int, int> _0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D, Dictionary<int, int> _0023_003Dzjo59Kug_JL3x, int _0023_003DzQUquNE_00246AOdg, int _0023_003DzRFd35WGqGw1U, bool _0023_003DzJVWkwrC6nEkD)
	{
		List<Face> list = new List<Face>(_0023_003DzqjniGGF9kvbc.Faces.Length + _0023_003Dzk0sekCclUGst.Faces.Length);
		List<Edge> list2 = new List<Edge>(_0023_003DzqjniGGF9kvbc.Edges.Length + _0023_003Dzk0sekCclUGst.Edges.Length);
		List<Point3D> list3 = new List<Point3D>(_0023_003DzqjniGGF9kvbc.Vertices.Length + _0023_003Dzk0sekCclUGst.Vertices.Length);
		Dictionary<int, int> dictionary = new Dictionary<int, int>(_0023_003DzqjniGGF9kvbc.Edges.Length);
		for (int i = 0; i < _0023_003DzqjniGGF9kvbc.Vertices.Length; i++)
		{
			Vertex vertex = (Vertex)_0023_003DzqjniGGF9kvbc.Vertices[i].Clone();
			vertex.Parents = null;
			list3.Add(vertex);
		}
		for (int j = 0; j < _0023_003DzqjniGGF9kvbc.Edges.Length; j++)
		{
			Edge edge = (Edge)_0023_003DzqjniGGF9kvbc.Edges[j].Clone();
			if (_0023_003DzJVWkwrC6nEkD || !_0023_003Dz4OZePitdhuZLxrhKfA_003D_003D.ContainsValue(edge.Parents[0]) || edge.Parents.Length <= 1 || !_0023_003Dz4OZePitdhuZLxrhKfA_003D_003D.ContainsValue(edge.Parents[1]))
			{
				edge.Parents = null;
				dictionary[j] = list2.Count;
				list2.Add(edge);
			}
		}
		int[] array = new int[_0023_003Dzk0sekCclUGst.Vertices.Length];
		for (int k = 0; k < _0023_003Dzk0sekCclUGst.Vertices.Length; k++)
		{
			Vertex vertex2 = (Vertex)_0023_003Dzk0sekCclUGst.Vertices[k].Clone();
			vertex2.Parents = null;
			int key = k;
			if (_0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D.ContainsKey(key))
			{
				key = _0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D[k];
			}
			else
			{
				key = list3.Count;
				list3.Add(vertex2);
			}
			array[k] = key;
		}
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>(_0023_003Dzk0sekCclUGst.Edges.Length);
		for (int l = 0; l < _0023_003Dzk0sekCclUGst.Edges.Length; l++)
		{
			Edge edge2 = (Edge)_0023_003Dzk0sekCclUGst.Edges[l].Clone();
			int key2 = l;
			if (!_0023_003Dz4OZePitdhuZLxrhKfA_003D_003D.ContainsKey(edge2.Parents[0]) || edge2.Parents.Length <= 1 || !_0023_003Dz4OZePitdhuZLxrhKfA_003D_003D.ContainsKey(edge2.Parents[1]))
			{
				edge2.Parents = null;
				if (_0023_003Dzjo59Kug_JL3x.ContainsKey(key2))
				{
					key2 = dictionary[_0023_003Dzjo59Kug_JL3x[l]];
				}
				else
				{
					key2 = list2.Count;
					list2.Add(edge2);
				}
				dictionary2.Add(l, key2);
				if (!_0023_003Dzjo59Kug_JL3x.ContainsKey(l))
				{
					edge2.StartPointIndex = array[edge2.StartPointIndex];
					edge2.EndPointIndex = array[edge2.EndPointIndex];
				}
			}
		}
		for (int m = 0; m < _0023_003DzqjniGGF9kvbc.Faces.Length; m++)
		{
			bool flag = _0023_003Dz4OZePitdhuZLxrhKfA_003D_003D.ContainsValue(m);
			if (!(!flag || _0023_003DzJVWkwrC6nEkD))
			{
				continue;
			}
			Face face = (Face)_0023_003DzqjniGGF9kvbc.Faces[m].Clone();
			if (flag)
			{
				face.Subdomain = 0;
			}
			for (int n = 0; n < face.Loops.Length; n++)
			{
				for (int num = 0; num < face.Loops[n].Segments.Length; num++)
				{
					face.Loops[n].Segments[num] = new OrientedEdge(dictionary[face.Loops[n].Segments[num].CurveIndex], face.Loops[n].Segments[num].Sense);
				}
			}
			_0023_003DzH_00244LxjBICrXYBxcvYXYFsGI_003D(_0023_003DzqjniGGF9kvbc.Faces[m], face, _0023_003Dz0mIPc9VROWxZ: false, dictionary, _0023_003DzqjniGGF9kvbc.RebuildTolerance);
			list.Add(face);
		}
		int num2 = -1;
		for (int num3 = 0; num3 < _0023_003Dzk0sekCclUGst.Faces.Length; num3++)
		{
			if (_0023_003Dz4OZePitdhuZLxrhKfA_003D_003D.ContainsKey(num3))
			{
				continue;
			}
			Face face2 = (Face)_0023_003Dzk0sekCclUGst.Faces[num3].Clone();
			if (_0023_003DzRc9F6BRuOvkMZTotrXhyjts_003D)
			{
				face2.Sense = !face2.Sense;
			}
			_0023_003DzH_00244LxjBICrXYBxcvYXYFsGI_003D(_0023_003Dzk0sekCclUGst.Faces[num3], face2, _0023_003DzRc9F6BRuOvkMZTotrXhyjts_003D, dictionary2, _0023_003DzqjniGGF9kvbc.RebuildTolerance);
			for (int num4 = 0; num4 < face2.Loops.Length; num4++)
			{
				if (_0023_003DzRc9F6BRuOvkMZTotrXhyjts_003D)
				{
					face2.Loops[num4].Sense = !face2.Loops[num4].Sense;
				}
				for (int num5 = 0; num5 < face2.Loops[num4].Segments.Length; num5++)
				{
					OrientedEdge orientedEdge = face2.Loops[num4].Segments[num5];
					bool sense = orientedEdge.Sense;
					if (_0023_003Dzjo59Kug_JL3x.ContainsKey(orientedEdge.CurveIndex))
					{
						sense = (_0023_003Dzk0sekCclUGst.Edges[orientedEdge.CurveIndex].Curve.IsClosed ? (orientedEdge.Sense == Vector3D.AreCoincident(_0023_003DzqjniGGF9kvbc.Edges[dictionary2[orientedEdge.CurveIndex]].Curve.StartTangent, _0023_003Dzk0sekCclUGst.Edges[orientedEdge.CurveIndex].Curve.StartTangent)) : (orientedEdge.Sense == (_0023_003DzqjniGGF9kvbc.Edges[dictionary2[orientedEdge.CurveIndex]].Curve.StartPoint == _0023_003Dzk0sekCclUGst.Edges[orientedEdge.CurveIndex].Curve.StartPoint)));
					}
					face2.Loops[num4].Segments[num5] = new OrientedEdge(dictionary2[orientedEdge.CurveIndex], sense);
				}
			}
			list.Add(face2);
			if (num3 == _0023_003DzRFd35WGqGw1U)
			{
				num2 = list.Count - 1;
			}
		}
		if (_0023_003DzQUquNE_00246AOdg != -1 && num2 != -1)
		{
			Face value = list[_0023_003DzQUquNE_00246AOdg];
			list[_0023_003DzQUquNE_00246AOdg] = list[num2];
			list[num2] = value;
		}
		Brep brep = new Brep(list3.ToArray(), list2.ToArray(), list.ToArray(), null, _0023_003DzqjniGGF9kvbc.RebuildTolerance);
		brep._0023_003DzZgiqXorCPZhhzzpl2py39to_003D();
		return brep;
	}

	internal static void _0023_003DzH_00244LxjBICrXYBxcvYXYFsGI_003D(Face _0023_003Dzb7SPTpc_003D, Face _0023_003DzaoQTclc_003D, bool _0023_003Dz0mIPc9VROWxZ, Dictionary<int, int> _0023_003Dzsng1XmiIKfL3, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
	{
		if (_0023_003Dzb7SPTpc_003D.Parametric == null)
		{
			return;
		}
		_0023_003DzaoQTclc_003D._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(new Surface[_0023_003Dzb7SPTpc_003D.Parametric.Length]);
		for (int i = 0; i < _0023_003Dzb7SPTpc_003D.Parametric.Length; i++)
		{
			_0023_003DzaoQTclc_003D.Parametric[i] = (Surface)_0023_003Dzb7SPTpc_003D.Parametric[i].Clone();
			if (_0023_003Dz0mIPc9VROWxZ)
			{
				_0023_003DzaoQTclc_003D.Parametric[i].ReverseU();
			}
			if (_0023_003Dzsng1XmiIKfL3 != null)
			{
				_0023_003DzaoQTclc_003D._0023_003Dzu_VTP2T_2LTBmaxiiTgVZUs_003D(_0023_003Dzsng1XmiIKfL3, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003DzvsFKDVZyhE_Q: false);
			}
		}
		_0023_003DzaoQTclc_003D.needRebuild = _0023_003Dzb7SPTpc_003D.needRebuild;
	}

	internal static bool _0023_003Dz61QgbOL8M2D2epyN9w_003D_003D(Brep _0023_003DzqjniGGF9kvbc, Brep _0023_003Dzk0sekCclUGst, out Dictionary<int, int> _0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D, out Dictionary<int, int> _0023_003Dzjo59Kug_JL3x, out Dictionary<int, int> _0023_003Dz4OZePitdhuZLxrhKfA_003D_003D, bool _0023_003Dzco1t_0024ys8aSEApoNVew_003D_003D)
	{
		_0023_003Dz4OZePitdhuZLxrhKfA_003D_003D = new Dictionary<int, int>(_0023_003DzqjniGGF9kvbc.Faces.Length);
		_0023_003Dzjo59Kug_JL3x = new Dictionary<int, int>(_0023_003DzqjniGGF9kvbc.Edges.Length);
		_0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D = new Dictionary<int, int>(_0023_003DzqjniGGF9kvbc.Vertices.Length);
		for (int i = 0; i < _0023_003Dzk0sekCclUGst.Faces.Length; i++)
		{
			Face face = _0023_003Dzk0sekCclUGst.Faces[i];
			if (face.tangentFacesType == null)
			{
				continue;
			}
			for (int j = 0; j < face.tangentFacesType.Count; j++)
			{
				int num = face.tangentFacesIndices[j];
				Face face2 = _0023_003DzqjniGGF9kvbc.Faces[num];
				bool flag = face.tangentFacesType[j] == Face.tangentType.coplanarOpposite || face.tangentFacesType[j] == Face.tangentType.coincidentOpposite;
				bool _0023_003DzGu4ta3WK76jHTSFs6DO7tLo_003D = false;
				bool flag2 = false;
				if (face.tangentFacesType[j] != Face.tangentType.tangent && _0023_003Dzco1t_0024ys8aSEApoNVew_003D_003D == flag)
				{
					flag2 = face2._0023_003DzUAP7_Fz4Idb4(face, _0023_003DzqjniGGF9kvbc.RebuildTolerance, _0023_003Dzjo59Kug_JL3x, out _0023_003DzGu4ta3WK76jHTSFs6DO7tLo_003D, _0023_003Dzco1t_0024ys8aSEApoNVew_003D_003D);
				}
				if (flag2)
				{
					_0023_003Dz4OZePitdhuZLxrhKfA_003D_003D.Add(i, num);
					_0023_003DzexlinmBd63Hvfg3dNg_003D_003D(_0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst, face, _0023_003Dzjo59Kug_JL3x, _0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D);
					break;
				}
				if (_0023_003DzGu4ta3WK76jHTSFs6DO7tLo_003D)
				{
					return false;
				}
			}
		}
		if (_0023_003Dz4OZePitdhuZLxrhKfA_003D_003D.Count == 0)
		{
			return false;
		}
		return true;
	}

	private static void _0023_003DzexlinmBd63Hvfg3dNg_003D_003D(Brep _0023_003DzqjniGGF9kvbc, Brep _0023_003Dzk0sekCclUGst, Face _0023_003DzcQpPRG5mmRCF, Dictionary<int, int> _0023_003Dzjo59Kug_JL3x, Dictionary<int, int> _0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D)
	{
		Loop[] loops = _0023_003DzcQpPRG5mmRCF.Loops;
		for (int i = 0; i < loops.Length; i++)
		{
			OrientedEdge[] segments = loops[i].Segments;
			for (int j = 0; j < segments.Length; j++)
			{
				OrientedEdge orientedEdge = segments[j];
				int num = _0023_003Dzjo59Kug_JL3x[orientedEdge.CurveIndex];
				Edge edge = _0023_003Dzk0sekCclUGst.Edges[orientedEdge.CurveIndex];
				Edge edge2 = _0023_003DzqjniGGF9kvbc.Edges[num];
				if (edge.Curve.IsClosed)
				{
					if (!_0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D.ContainsKey(edge.StartPointIndex))
					{
						_0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D.Add(edge.StartPointIndex, edge2.StartPointIndex);
					}
				}
				else if (Point3D.DistanceSquared(_0023_003DzqjniGGF9kvbc.Vertices[edge2.StartPointIndex], _0023_003Dzk0sekCclUGst.Vertices[edge.StartPointIndex]) < 1E-12)
				{
					if (!_0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D.ContainsKey(edge.StartPointIndex))
					{
						_0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D.Add(edge.StartPointIndex, edge2.StartPointIndex);
					}
					if (!_0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D.ContainsKey(edge.EndPointIndex))
					{
						_0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D.Add(edge.EndPointIndex, edge2.EndPointIndex);
					}
				}
				else
				{
					if (!_0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D.ContainsKey(edge.StartPointIndex))
					{
						_0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D.Add(edge.StartPointIndex, edge2.EndPointIndex);
					}
					if (!_0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D.ContainsKey(edge.EndPointIndex))
					{
						_0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D.Add(edge.EndPointIndex, edge2.StartPointIndex);
					}
				}
			}
		}
	}

	internal static Brep[] _0023_003DzzDn32WHo_7Y_0024(Brep _0023_003DzqjniGGF9kvbc, Brep _0023_003Dzk0sekCclUGst, _0023_003Dz4Hw_002424_0024xhqb8 _0023_003DzjwXjJRWTdRfR, out bool _0023_003DztLD2a19GFACn, out Point3D[] _0023_003Dzwf2OU4pUJmjk, out ICurve[] _0023_003DzHnOH3yIXp9ivQgg4BQ_003D_003D)
	{
		double num = Math.Min(_0023_003DzqjniGGF9kvbc.RebuildTolerance, _0023_003Dzk0sekCclUGst.RebuildTolerance);
		double num2 = num;
		_0023_003Dzwf2OU4pUJmjk = null;
		_0023_003DzHnOH3yIXp9ivQgg4BQ_003D_003D = null;
		bool flag;
		bool flag2;
		switch (_0023_003DzjwXjJRWTdRfR)
		{
		case (_0023_003Dz4Hw_002424_0024xhqb8)0:
			flag = true;
			flag2 = false;
			break;
		case (_0023_003Dz4Hw_002424_0024xhqb8)1:
			flag = false;
			flag2 = true;
			break;
		case (_0023_003Dz4Hw_002424_0024xhqb8)2:
			flag = true;
			flag2 = true;
			break;
		default:
			flag = false;
			flag2 = false;
			break;
		}
		_0023_003Dzhlq5RKbWjx6nskJGYQMtB7C9hVAf(_0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst, out var _0023_003DzFUZJf1oIN_0024YFcfi6jm6UmW4_003D, out var _, out var _0023_003DzbtFoN5ZWAcGhm0aNILADRWs_003D, _0023_003Dzk_3tZjgmhGlmfKWn0g_003D_003D: false, _0023_003DzY7IAYN_00249VAHl11lbabS4sjVmDFI0: false);
		_0023_003DztLD2a19GFACn = false;
		if ((_0023_003DzFUZJf1oIN_0024YFcfi6jm6UmW4_003D > 0 || _0023_003DzbtFoN5ZWAcGhm0aNILADRWs_003D > 0) && _0023_003DzgJ8N_I4FtIHFwcYxDiDmkdg_003D(_0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst, _0023_003DzjwXjJRWTdRfR, out var _0023_003Dz6Jdj4TI_003D, _0023_003DzJVWkwrC6nEkD: false))
		{
			return _0023_003Dz6Jdj4TI_003D;
		}
		_0023_003DzxW071OSsSln1GonVbw_003D_003D(_0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst, out _0023_003Dzwf2OU4pUJmjk, out _0023_003DzHnOH3yIXp9ivQgg4BQ_003D_003D, out var _0023_003DzPheed_XFmRFyp84Vdw_003D_003D, out var _0023_003DzjDTWe310b3TOuqMxjA_003D_003D);
		List<Curve> _0023_003Dz0B5Dc_00244nIZ5Fu87AHQ_003D_003D;
		bool flag3 = _0023_003Dzp5I572_XXGZXPdnmnkHnAuWkcdr5(_0023_003DzPheed_XFmRFyp84Vdw_003D_003D, out _0023_003Dz0B5Dc_00244nIZ5Fu87AHQ_003D_003D);
		if (_0023_003DzPheed_XFmRFyp84Vdw_003D_003D.Length == 0 || flag3)
		{
			switch (_0023_003DzphGY8ZZmyMfcPRaN4A_003D_003D(_0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst, flag3, _0023_003Dz0B5Dc_00244nIZ5Fu87AHQ_003D_003D))
			{
			case (_0023_003DzGRk_0024ChFuOP73AsKQDDS1_9AKBHAND6iGKQ_003D_003D)2:
				switch (_0023_003DzjwXjJRWTdRfR)
				{
				case (_0023_003Dz4Hw_002424_0024xhqb8)2:
				{
					Brep brep = _0023_003DzJrt27ckdk68JVyoc_Q_003D_003D(new Brep[2] { _0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst }, num, _0023_003DzRb83x_TfwJW2hnkcYA_003D_003D: true);
					return new Brep[1] { brep };
				}
				case (_0023_003Dz4Hw_002424_0024xhqb8)1:
					return new Brep[1] { (Brep)_0023_003Dzk0sekCclUGst.Clone() };
				case (_0023_003Dz4Hw_002424_0024xhqb8)0:
					return new Brep[1] { (Brep)_0023_003DzqjniGGF9kvbc.Clone() };
				}
				break;
			case (_0023_003DzGRk_0024ChFuOP73AsKQDDS1_9AKBHAND6iGKQ_003D_003D)1:
				switch (_0023_003DzjwXjJRWTdRfR)
				{
				case (_0023_003Dz4Hw_002424_0024xhqb8)2:
					return new Brep[0];
				case (_0023_003Dz4Hw_002424_0024xhqb8)1:
					return new Brep[1] { (Brep)_0023_003DzqjniGGF9kvbc.Clone() };
				case (_0023_003Dz4Hw_002424_0024xhqb8)0:
					return new Brep[1] { (Brep)_0023_003Dzk0sekCclUGst.Clone() };
				}
				break;
			default:
				switch (_0023_003DzjwXjJRWTdRfR)
				{
				case (_0023_003Dz4Hw_002424_0024xhqb8)2:
					_0023_003DztLD2a19GFACn = true;
					return new Brep[1] { (Brep)_0023_003DzqjniGGF9kvbc.Clone() };
				case (_0023_003Dz4Hw_002424_0024xhqb8)0:
					_0023_003DztLD2a19GFACn = true;
					return new Brep[2]
					{
						(Brep)_0023_003DzqjniGGF9kvbc.Clone(),
						(Brep)_0023_003Dzk0sekCclUGst.Clone()
					};
				case (_0023_003Dz4Hw_002424_0024xhqb8)1:
					_0023_003DztLD2a19GFACn = true;
					return new Brep[0];
				}
				break;
			}
		}
		if (_0023_003DzBF1D4Y_0024BXIDMgWwReA_003D_003D(_0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst, num2, ref _0023_003DzPheed_XFmRFyp84Vdw_003D_003D, ref _0023_003DzjDTWe310b3TOuqMxjA_003D_003D, out var _0023_003Dzc9K9azBAwWI_0024, out var _0023_003DzgLfcg0Bs8CGK))
		{
			return _0023_003DzzDn32WHo_7Y_0024(_0023_003Dzc9K9azBAwWI_0024, _0023_003DzgLfcg0Bs8CGK, _0023_003DzjwXjJRWTdRfR, out _0023_003DztLD2a19GFACn, out _0023_003Dzwf2OU4pUJmjk, out _0023_003DzHnOH3yIXp9ivQgg4BQ_003D_003D);
		}
		List<Edge> list = _0023_003DzqjniGGF9kvbc.Edges.ToList();
		List<Edge> list2 = _0023_003Dzk0sekCclUGst.Edges.ToList();
		List<Point3D> list3 = new List<Point3D>();
		List<Edge> list4 = new List<Edge>();
		List<Face> list5 = new List<Face>();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
		Dictionary<int, int> dictionary3 = new Dictionary<int, int>();
		Dictionary<int, int> _0023_003DzV8Lcc5p5_0024hWB = new Dictionary<int, int>();
		Dictionary<int, Dictionary<double, int>> dictionary4 = new Dictionary<int, Dictionary<double, int>>();
		Dictionary<int, Dictionary<double, int>> dictionary5 = new Dictionary<int, Dictionary<double, int>>();
		Dictionary<int, List<int>> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D = new Dictionary<int, List<int>>();
		Dictionary<int, List<int>> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D2 = new Dictionary<int, List<int>>();
		Dictionary<int, List<ICurve>> dictionary6 = new Dictionary<int, List<ICurve>>();
		Dictionary<int, List<ICurve>> dictionary7 = new Dictionary<int, List<ICurve>>();
		bool? flag4 = null;
		bool flag5 = false;
		for (int i = 0; i < _0023_003DzPheed_XFmRFyp84Vdw_003D_003D.Length; i++)
		{
			TrimCurve trimCurve = (TrimCurve)_0023_003DzPheed_XFmRFyp84Vdw_003D_003D[i];
			TrimCurve trimCurve2 = (TrimCurve)_0023_003DzjDTWe310b3TOuqMxjA_003D_003D[i];
			Surface _0023_003Dz4wZe_0024Xg_003D = _0023_003DzqjniGGF9kvbc.Faces[trimCurve.FaceInfo._0023_003DzLJVtPYc_003D].Parametric[trimCurve.FaceInfo._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D];
			Surface _0023_003Dz4wZe_0024Xg_003D2 = _0023_003Dzk0sekCclUGst.Faces[trimCurve2.FaceInfo._0023_003DzLJVtPYc_003D].Parametric[trimCurve2.FaceInfo._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D];
			Surface._0023_003Dz2u_3iw7LP_ic _0023_003Dz2u_3iw7LP_ic = new Surface._0023_003Dz2u_3iw7LP_ic
			{
				_0023_003Dz4wZe_0024Xg_003D = _0023_003Dz4wZe_0024Xg_003D
			};
			Surface.Reparametrize(_0023_003Dz2u_3iw7LP_ic._0023_003Dz4wZe_0024Xg_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dz2AZ_kpw_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dza2Pq9PQ_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
			_0023_003Dz4wZe_0024Xg_003D = _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
			Surface._0023_003Dz2u_3iw7LP_ic _0023_003Dz2u_3iw7LP_ic2 = new Surface._0023_003Dz2u_3iw7LP_ic
			{
				_0023_003Dz4wZe_0024Xg_003D = _0023_003Dz4wZe_0024Xg_003D2
			};
			Surface.Reparametrize(_0023_003Dz2u_3iw7LP_ic2._0023_003Dz4wZe_0024Xg_003D, out _0023_003Dz2u_3iw7LP_ic2._0023_003Dz2AZ_kpw_003D, out _0023_003Dz2u_3iw7LP_ic2._0023_003Dza2Pq9PQ_003D, out _0023_003Dz2u_3iw7LP_ic2._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
			_0023_003Dz4wZe_0024Xg_003D2 = _0023_003Dz2u_3iw7LP_ic2._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
			_0023_003Dz4wZe_0024Xg_003D.ControlBoundingBox(out var min, out var max);
			_0023_003Dz4wZe_0024Xg_003D2.ControlBoundingBox(out var min2, out var max2);
			Utility.IntersectionBox(min, max, min2, max2, out var _, out var _);
			bool flag6 = true;
			bool flag7 = true;
			bool _0023_003Dzb9U1KHmIZGGP = _0023_003DzqjniGGF9kvbc.Faces[trimCurve.FaceInfo._0023_003DzLJVtPYc_003D].tangentFacesIndices != null && _0023_003Dzk0sekCclUGst.Faces[trimCurve2.FaceInfo._0023_003DzLJVtPYc_003D].tangentFacesIndices != null;
			bool _0023_003DzKgWCaV5RTv9VxFld_g_003D_003D;
			int _0023_003Dz93D7WaCPl_0024u;
			bool flag8 = _0023_003Dz4wZe_0024Xg_003D._0023_003DzZf4zvJoP0u8G(trimCurve, out _0023_003DzKgWCaV5RTv9VxFld_g_003D_003D, out _0023_003Dz93D7WaCPl_0024u, _0023_003DzRAS4kB6WIA5zYp5K0eecf_00240_003D: false, _0023_003Dz4wZe_0024Xg_003D2, _0023_003Dzb9U1KHmIZGGP, _0023_003Dzf5uydyTGDFr_0024: false);
			bool _0023_003DzKgWCaV5RTv9VxFld_g_003D_003D2;
			int _0023_003Dz93D7WaCPl_0024u2;
			bool flag9 = _0023_003Dz4wZe_0024Xg_003D2._0023_003DzZf4zvJoP0u8G(trimCurve2, out _0023_003DzKgWCaV5RTv9VxFld_g_003D_003D2, out _0023_003Dz93D7WaCPl_0024u2, _0023_003DzRAS4kB6WIA5zYp5K0eecf_00240_003D: false, _0023_003Dz4wZe_0024Xg_003D, _0023_003Dzb9U1KHmIZGGP, _0023_003Dzf5uydyTGDFr_0024: false);
			bool flag10 = trimCurve2.onTangentType == Face.tangentType.coplanarOpposite || trimCurve2.onTangentType == Face.tangentType.coincidentOpposite;
			bool flag11 = trimCurve.onTangentType == Face.tangentType.coplanarOpposite || trimCurve.onTangentType == Face.tangentType.coincidentOpposite;
			if (!flag4.HasValue || flag4.Value)
			{
				flag4 = flag11 || flag10;
			}
			if (flag8 && flag9)
			{
				if (_0023_003Dz93D7WaCPl_0024u != -1)
				{
					flag5 = flag5 || flag11;
					if (_0023_003DzjwXjJRWTdRfR == (_0023_003Dz4Hw_002424_0024xhqb8)2 && (flag11 || trimCurve.onTangentType == Face.tangentType.none) && _0023_003DzqjniGGF9kvbc.Edges[_0023_003Dz93D7WaCPl_0024u].SplitStatus != SplitEdgeStatus.OnBothEdges)
					{
						_0023_003DzqjniGGF9kvbc.Edges[_0023_003Dz93D7WaCPl_0024u].SplitStatus = SplitEdgeStatus.Included;
					}
					else if (_0023_003DzqjniGGF9kvbc.Edges[_0023_003Dz93D7WaCPl_0024u].SplitStatus != SplitEdgeStatus.NeedToTrim)
					{
						_0023_003DzqjniGGF9kvbc.Edges[_0023_003Dz93D7WaCPl_0024u].SplitStatus = SplitEdgeStatus.OnBothEdges;
					}
				}
				if (_0023_003Dz93D7WaCPl_0024u2 != -1)
				{
					flag5 = flag5 || flag10;
					if (_0023_003Dzk0sekCclUGst.Edges[_0023_003Dz93D7WaCPl_0024u2].SplitStatus != SplitEdgeStatus.NeedToTrim)
					{
						_0023_003Dzk0sekCclUGst.Edges[_0023_003Dz93D7WaCPl_0024u2].SplitStatus = SplitEdgeStatus.OnBothEdges;
					}
				}
				continue;
			}
			if (trimCurve2.onTangentType != Face.tangentType.tangent && trimCurve2.onTangentType != Face.tangentType.none && _0023_003Dzk0sekCclUGst.Faces[trimCurve2.FaceInfo._0023_003DzLJVtPYc_003D].tangentFacesIndices != null)
			{
				if (!flag10 || _0023_003DzjwXjJRWTdRfR == (_0023_003Dz4Hw_002424_0024xhqb8)0)
				{
					if (flag8 && !_0023_003DzKgWCaV5RTv9VxFld_g_003D_003D)
					{
						flag7 = false;
					}
				}
				else if (flag10 && _0023_003DzjwXjJRWTdRfR != 0 && flag8 && _0023_003DzKgWCaV5RTv9VxFld_g_003D_003D)
				{
					flag7 = false;
				}
			}
			if (trimCurve.onTangentType != Face.tangentType.tangent && trimCurve.onTangentType != Face.tangentType.none && _0023_003DzqjniGGF9kvbc.Faces[trimCurve.FaceInfo._0023_003DzLJVtPYc_003D].tangentFacesIndices != null)
			{
				if (!flag11 || _0023_003DzjwXjJRWTdRfR != 0)
				{
					if (flag9 && !_0023_003DzKgWCaV5RTv9VxFld_g_003D_003D2)
					{
						flag6 = false;
					}
				}
				else if (flag11 && _0023_003DzjwXjJRWTdRfR == (_0023_003Dz4Hw_002424_0024xhqb8)0 && flag9 && _0023_003DzKgWCaV5RTv9VxFld_g_003D_003D2)
				{
					flag6 = false;
				}
			}
			if (flag6 && flag)
			{
				trimCurve.Reverse();
			}
			if (flag7 && flag2)
			{
				trimCurve2.Reverse();
			}
			if (flag7 && flag6)
			{
				ICurve edge = trimCurve.Edge;
				int num3 = -1;
				int num4 = -1;
				Point3D startPoint = edge.StartPoint;
				Point3D endPoint = edge.EndPoint;
				Vertex vertex = new Vertex(startPoint.X, startPoint.Y, startPoint.Z);
				num3 = _0023_003DzYrt453tI69Ce(vertex, _0023_003DzqjniGGF9kvbc, trimCurve, list, dictionary4, dictionary, list3, flag8);
				int num5 = _0023_003DzYrt453tI69Ce(vertex, _0023_003Dzk0sekCclUGst, trimCurve2, list2, dictionary5, dictionary2, list3, flag9);
				if (num3 == -1)
				{
					if (num5 != -1)
					{
						num3 = num5;
					}
					else
					{
						num3 = list3.Count;
						list3.Add(vertex);
					}
				}
				Vertex vertex2 = new Vertex(endPoint.X, endPoint.Y, endPoint.Z);
				num4 = _0023_003DzYrt453tI69Ce(vertex2, _0023_003DzqjniGGF9kvbc, trimCurve, list, dictionary4, dictionary, list3, flag8);
				int num6 = _0023_003DzYrt453tI69Ce(vertex2, _0023_003Dzk0sekCclUGst, trimCurve2, list2, dictionary5, dictionary2, list3, flag9);
				if (num4 == -1)
				{
					if (num6 != -1)
					{
						num4 = num6;
					}
					else
					{
						num4 = list3.Count;
						list3.Add(vertex2);
					}
				}
				Edge _0023_003DzXQ05_0024cQM5wVN = new Edge(edge, num3, num4);
				int count = list4.Count;
				int edgeIndex = (trimCurve.EdgeIndex = _0023_003DzbIDY9BOTPqfc(_0023_003DzXQ05_0024cQM5wVN, list4, num2, null, null));
				trimCurve.FromBooleanIntersection = true;
				trimCurve2.EdgeIndex = edgeIndex;
				trimCurve2.FromBooleanIntersection = true;
				if (count == list4.Count)
				{
					if (flag8 == flag9)
					{
						return null;
					}
					flag6 = flag6 && flag8;
					flag7 = flag7 && flag9;
				}
			}
			if (flag6)
			{
				int _0023_003DzLJVtPYc_003D = trimCurve.FaceInfo._0023_003DzLJVtPYc_003D;
				if (!dictionary6.ContainsKey(_0023_003DzLJVtPYc_003D))
				{
					dictionary6.Add(_0023_003DzLJVtPYc_003D, new List<ICurve>());
				}
				dictionary6[_0023_003DzLJVtPYc_003D].Add(trimCurve);
			}
			if (flag7)
			{
				int _0023_003DzLJVtPYc_003D = trimCurve2.FaceInfo._0023_003DzLJVtPYc_003D;
				if (!dictionary7.ContainsKey(_0023_003DzLJVtPYc_003D))
				{
					dictionary7.Add(_0023_003DzLJVtPYc_003D, new List<ICurve>());
				}
				dictionary7[_0023_003DzLJVtPYc_003D].Add(trimCurve2);
			}
		}
		bool flag12 = (flag4.HasValue && flag4.Value) || flag5;
		if (list4.Count == 0 && flag12)
		{
			switch (_0023_003DzjwXjJRWTdRfR)
			{
			case (_0023_003Dz4Hw_002424_0024xhqb8)2:
				return new Brep[1] { (Brep)_0023_003DzqjniGGF9kvbc.Clone() };
			case (_0023_003Dz4Hw_002424_0024xhqb8)1:
				return new Brep[0];
			}
		}
		_0023_003DzJiYrREIJy046(dictionary4, list, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, _0023_003Dz_d_002406W8syS3trhyv9w_003D_003D: false);
		_0023_003DzJiYrREIJy046(dictionary5, list2, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D2, _0023_003Dz_d_002406W8syS3trhyv9w_003D_003D: false);
		try
		{
			for (int j = 0; j < _0023_003DzqjniGGF9kvbc.Faces.Length; j++)
			{
				if (!dictionary6.ContainsKey(j) && _0023_003DzqjniGGF9kvbc.Faces[j].tangentFacesIndices != null && _0023_003DzjwXjJRWTdRfR == (_0023_003Dz4Hw_002424_0024xhqb8)0 && !_0023_003DzqjniGGF9kvbc.Faces[j].Visited)
				{
					bool flag13 = true;
					for (int k = 0; k < _0023_003DzqjniGGF9kvbc.Faces[j].tangentFacesType.Count; k++)
					{
						if (_0023_003DzqjniGGF9kvbc.Faces[j].tangentFacesType[k] == Face.tangentType.coplanarOpposite || _0023_003DzqjniGGF9kvbc.Faces[j].tangentFacesType[k] == Face.tangentType.coincidentOpposite)
						{
							int num8 = _0023_003DzqjniGGF9kvbc.Faces[j].tangentFacesIndices[k];
							for (int l = 0; l < _0023_003DzjDTWe310b3TOuqMxjA_003D_003D.Length; l++)
							{
								if (((TrimCurve)_0023_003DzjDTWe310b3TOuqMxjA_003D_003D[l]).FaceInfo._0023_003DzLJVtPYc_003D == num8 && ((TrimCurve)_0023_003DzjDTWe310b3TOuqMxjA_003D_003D[l]).onTangentFaces != null && ((TrimCurve)_0023_003DzjDTWe310b3TOuqMxjA_003D_003D[l]).onTangentFaces[0] == j)
								{
									flag13 = false;
									_0023_003DzqjniGGF9kvbc.Faces[j].Visited = true;
									break;
								}
							}
						}
						if (!flag13)
						{
							break;
						}
					}
				}
				if (dictionary6.ContainsKey(j) || _0023_003DzqjniGGF9kvbc.Faces[j].Visited || _0023_003DzjwXjJRWTdRfR == (_0023_003Dz4Hw_002424_0024xhqb8)0 || _0023_003DzqjniGGF9kvbc.Faces[j].tangentFacesIndices == null)
				{
					continue;
				}
				Face _0023_003DzdjGa2HlHPqCy_0024d2Wjw_003D_003D;
				bool flag14 = _0023_003Dzk9dIqBWAYqkC1QeaSEiM6AfX5sLX(_0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst, _0023_003DzqjniGGF9kvbc.Faces[j], num, out _0023_003DzdjGa2HlHPqCy_0024d2Wjw_003D_003D);
				if (_0023_003DzjwXjJRWTdRfR == (_0023_003Dz4Hw_002424_0024xhqb8)2 && flag14 && _0023_003DzdjGa2HlHPqCy_0024d2Wjw_003D_003D != null)
				{
					_0023_003DzqjniGGF9kvbc.Faces[j].Visited = true;
					_0023_003DzdjGa2HlHPqCy_0024d2Wjw_003D_003D.Visited = true;
					continue;
				}
				if (_0023_003DzjwXjJRWTdRfR == (_0023_003Dz4Hw_002424_0024xhqb8)2 && !flag14 && _0023_003DzqjniGGF9kvbc.Faces[j].tangentFacesType.Contains(Face.tangentType.coplanarOpposite))
				{
					bool flag15 = false;
					for (int m = 0; m < _0023_003DzqjniGGF9kvbc.Faces[j].tangentFacesIndices.Count; m++)
					{
						int num9 = _0023_003DzqjniGGF9kvbc.Faces[j].tangentFacesIndices[m];
						if (_0023_003DzqjniGGF9kvbc.Faces[j].tangentFacesType[m] == Face.tangentType.coplanarOpposite)
						{
							_0023_003DzqjniGGF9kvbc.Faces[j].Parametric[0].ControlBoundingBox(out var min3, out var max3);
							_0023_003Dzk0sekCclUGst.Faces[num9].Parametric[0].ControlBoundingBox(out var min4, out var max4);
							if (Utility.DoOverlapOrTouch(min3, max3, min4, max4))
							{
								flag15 = true;
								break;
							}
						}
					}
					if (flag15 && !_0023_003DzqjniGGF9kvbc._0023_003DzQ5fDF2jR3C5L0fCEng_003D_003D(j, list5, dictionary6, _0023_003DzxI_R5dw_003D: true, list3, dictionary, list4, dictionary3, _0023_003Dz0mIPc9VROWxZ: false))
					{
						return null;
					}
				}
				if (flag14 && !_0023_003DzqjniGGF9kvbc._0023_003DzQ5fDF2jR3C5L0fCEng_003D_003D(j, list5, dictionary6, _0023_003DzxI_R5dw_003D: true, list3, dictionary, list4, dictionary3, _0023_003Dz0mIPc9VROWxZ: false))
				{
					return null;
				}
			}
			for (int n = 0; n < _0023_003DzqjniGGF9kvbc.Faces.Length; n++)
			{
				Face face = _0023_003DzqjniGGF9kvbc.Faces[n];
				if (dictionary6.ContainsKey(n) || (face.hasEdgesToSplit && _0023_003DzjwXjJRWTdRfR != (_0023_003Dz4Hw_002424_0024xhqb8)1) || ((_0023_003DzTCcFngj0Zh3U(_0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst, face) || _0023_003Dzy0agWQU1pS_0024g(_0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst, face)) && !face.Visited && _0023_003DzjwXjJRWTdRfR == (_0023_003Dz4Hw_002424_0024xhqb8)0))
				{
					face.Visited = true;
					bool _0023_003DzEt2Zcy_TSPx_0024 = !(flag || flag2);
					if (!_0023_003Dzt8_0024zbuvCbXTx(_0023_003DzqjniGGF9kvbc, n, list, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, dictionary3, dictionary, dictionary6, list4, list3, list5, null, null, null, _0023_003DzEt2Zcy_TSPx_0024))
					{
						return null;
					}
				}
			}
			for (int num10 = 0; num10 < _0023_003Dzk0sekCclUGst.Faces.Length; num10++)
			{
				Face face2 = _0023_003Dzk0sekCclUGst.Faces[num10];
				if (!dictionary7.ContainsKey(num10) && face2.tangentFacesIndices == null && (!face2.hasEdgesToSplit || _0023_003DzjwXjJRWTdRfR != 0))
				{
					continue;
				}
				bool flag16 = true;
				if (!dictionary7.ContainsKey(num10) && face2.tangentFacesType != null)
				{
					for (int num11 = 0; num11 < face2.tangentFacesType.Count; num11++)
					{
						if (face2.tangentFacesType[num11] == Face.tangentType.coplanarOpposite || face2.tangentFacesType[num11] == Face.tangentType.coincidentOpposite)
						{
							int num12 = face2.tangentFacesIndices[num11];
							if (dictionary6.TryGetValue(num12, out var value))
							{
								for (int num13 = 0; num13 < value.Count; num13++)
								{
									if (((TrimCurve)value[num13]).onTangentFaces != null && ((TrimCurve)value[num13]).onTangentFaces[1] == num10)
									{
										flag16 = false;
										face2.Visited = true;
										break;
									}
								}
							}
							else if (_0023_003DzjwXjJRWTdRfR == (_0023_003Dz4Hw_002424_0024xhqb8)0 && _0023_003DzqjniGGF9kvbc.Faces[num12]._0023_003DzYzEUacYequL5(face2, _0023_003DzqjniGGF9kvbc.RebuildTolerance, _0023_003Dzco1t_0024ys8aSEApoNVew_003D_003D: true))
							{
								flag16 = false;
								face2.Visited = true;
								break;
							}
						}
						if (!flag16)
						{
							break;
						}
					}
					if (!flag16)
					{
						continue;
					}
					if (!dictionary7.ContainsKey(num10))
					{
						bool flag17 = true;
						bool flag18 = true;
						OrientedEdge[] segments = face2.Loops[0].Segments;
						foreach (OrientedEdge orientedEdge in segments)
						{
							ICurve orientedCurve = orientedEdge.GetOrientedCurve(_0023_003Dzk0sekCclUGst.Edges);
							Point3D point3D = orientedCurve.PointAt(orientedCurve.Domain.Mid);
							if (_0023_003DzqjniGGF9kvbc.IsPointInside(point3D, skipRebuild: true) == pointStatusType.Outside)
							{
								flag17 = false;
								if (!flag18)
								{
									break;
								}
							}
							bool flag19 = false;
							for (int num15 = 0; num15 < face2.tangentFacesIndices.Count; num15++)
							{
								if (_0023_003DzqjniGGF9kvbc.Faces[face2.tangentFacesIndices[num15]].Parametric[0]._0023_003DzeluEnlV_EVoyLal8lA_003D_003D(point3D, num2))
								{
									flag19 = true;
									break;
								}
							}
							if (!flag19)
							{
								flag18 = false;
								if (!flag17)
								{
									break;
								}
							}
						}
						if (flag18 && _0023_003DzjwXjJRWTdRfR != 0)
						{
							continue;
						}
						if (flag17 && !flag18)
						{
							if (_0023_003DzjwXjJRWTdRfR == (_0023_003Dz4Hw_002424_0024xhqb8)0)
							{
								continue;
							}
						}
						else if (_0023_003DzjwXjJRWTdRfR != 0)
						{
							continue;
						}
					}
				}
				face2.Visited = true;
				bool _0023_003DzEt2Zcy_TSPx_00242 = _0023_003DzjwXjJRWTdRfR == (_0023_003Dz4Hw_002424_0024xhqb8)2;
				string _0023_003DzMSePdGORTGCj6kcdWA_003D_003D = ((face2.tangentFacesIndices != null) ? _0023_003DzqjniGGF9kvbc.Faces[face2.tangentFacesIndices[0]].MaterialName : null);
				Color? _0023_003DzOn_quequ5gWQIBVpCg_003D_003D = ((face2.tangentFacesIndices != null) ? _0023_003DzqjniGGF9kvbc.Faces[face2.tangentFacesIndices[0]].Color : ((Color?)null));
				object _0023_003DzYJzQU0io36oJuCOj_0024A_003D_003D = ((face2.tangentFacesIndices != null) ? _0023_003DzqjniGGF9kvbc.Faces[face2.tangentFacesIndices[0]].FaceData : null);
				if (!_0023_003Dzt8_0024zbuvCbXTx(_0023_003Dzk0sekCclUGst, num10, list2, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D2, _0023_003DzV8Lcc5p5_0024hWB, dictionary2, dictionary7, list4, list3, list5, _0023_003DzOn_quequ5gWQIBVpCg_003D_003D, _0023_003DzMSePdGORTGCj6kcdWA_003D_003D, _0023_003DzYJzQU0io36oJuCOj_0024A_003D_003D, _0023_003DzEt2Zcy_TSPx_00242))
				{
					return null;
				}
			}
		}
		catch (EyeshotException ex)
		{
			if (ex != null)
			{
				throw;
			}
			return null;
		}
		if (list3.Count > 0 && list4.Count > 0 && list5.Count > 0)
		{
			Point3D[] array = list3.ToArray();
			Edge[] array2 = list4.ToArray();
			Face[] array3 = list5.ToArray();
			_0023_003Dz8VkxvzXXGxA_0024(array, array2, array3, new Face[0][], _0023_003DzLuJVbec_003D: true);
			Brep brep2 = new Brep(array, array2, array3, null, num);
			Brep[] array4 = _0023_003Dz2LwOnW_H_0024i8hPxptuw_003D_003D(brep2);
			if (array4 == null)
			{
				array4 = new Brep[1] { brep2 };
			}
			return array4;
		}
		return new Brep[0];
	}

	private static bool _0023_003DzBF1D4Y_0024BXIDMgWwReA_003D_003D(Brep _0023_003DzqjniGGF9kvbc, Brep _0023_003Dzk0sekCclUGst, double _0023_003Dz85DwsjHHsAwG, ref ICurve[] _0023_003DzPheed_XFmRFyp84Vdw_003D_003D, ref ICurve[] _0023_003DzjDTWe310b3TOuqMxjA_003D_003D, out Brep _0023_003Dzc9K9azBAwWI_0024, out Brep _0023_003DzgLfcg0Bs8CGK)
	{
		List<int> list = new List<int>();
		bool num = _0023_003DzevHKBKK32_uMY2nu6PIiHEXEXVXX(_0023_003DzqjniGGF9kvbc, _0023_003DzPheed_XFmRFyp84Vdw_003D_003D, _0023_003DzjDTWe310b3TOuqMxjA_003D_003D, list, _0023_003Dz85DwsjHHsAwG, out _0023_003Dzc9K9azBAwWI_0024);
		bool flag = _0023_003DzevHKBKK32_uMY2nu6PIiHEXEXVXX(_0023_003Dzk0sekCclUGst, _0023_003DzjDTWe310b3TOuqMxjA_003D_003D, _0023_003DzPheed_XFmRFyp84Vdw_003D_003D, list, _0023_003Dz85DwsjHHsAwG, out _0023_003DzgLfcg0Bs8CGK);
		if (num || flag)
		{
			_0023_003Dz8VkxvzXXGxA_0024(_0023_003DzqjniGGF9kvbc.Vertices, _0023_003DzqjniGGF9kvbc.Edges, _0023_003DzqjniGGF9kvbc.Faces, _0023_003DzqjniGGF9kvbc.Inners, _0023_003DzLuJVbec_003D: false);
			_0023_003Dz8VkxvzXXGxA_0024(_0023_003Dzk0sekCclUGst.Vertices, _0023_003Dzk0sekCclUGst.Edges, _0023_003Dzk0sekCclUGst.Faces, _0023_003Dzk0sekCclUGst.Inners, _0023_003DzLuJVbec_003D: false);
			return true;
		}
		List<ICurve> list2 = new List<ICurve>();
		List<ICurve> list3 = new List<ICurve>();
		for (int i = 0; i < _0023_003DzPheed_XFmRFyp84Vdw_003D_003D.Length; i++)
		{
			if (!list.Contains(i))
			{
				list2.Add(_0023_003DzPheed_XFmRFyp84Vdw_003D_003D[i]);
				list3.Add(_0023_003DzjDTWe310b3TOuqMxjA_003D_003D[i]);
			}
		}
		_0023_003DzPheed_XFmRFyp84Vdw_003D_003D = list2.ToArray();
		_0023_003DzjDTWe310b3TOuqMxjA_003D_003D = list3.ToArray();
		return false;
	}

	private static bool _0023_003DzevHKBKK32_uMY2nu6PIiHEXEXVXX(Brep _0023_003DzQUhnjVe9kSO_0024, ICurve[] _0023_003DzPheed_XFmRFyp84Vdw_003D_003D, ICurve[] _0023_003DzjDTWe310b3TOuqMxjA_003D_003D, List<int> _0023_003DzVsY16T9qo18G, double _0023_003Dz85DwsjHHsAwG, out Brep _0023_003DzLuJVbec_003D)
	{
		_0023_003DzLuJVbec_003D = null;
		bool flag = false;
		for (int i = 0; i < _0023_003DzQUhnjVe9kSO_0024.Faces.Length; i++)
		{
			List<(int, bool)> list = new List<(int, bool)>();
			for (int j = 0; j < _0023_003DzPheed_XFmRFyp84Vdw_003D_003D.Length; j++)
			{
				if (((TrimCurve)_0023_003DzPheed_XFmRFyp84Vdw_003D_003D[j]).FaceInfo._0023_003DzLJVtPYc_003D == i)
				{
					list.Add((j, false));
				}
			}
			Dictionary<int, List<ICurve>> dictionary = new Dictionary<int, List<ICurve>>();
			for (int k = 0; k < list.Count; k++)
			{
				if (list[k].Item2)
				{
					continue;
				}
				int num = -1;
				bool _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D;
				if (_0023_003DzQUhnjVe9kSO_0024.Faces[i].tangentFacesIndices != null)
				{
					int num2 = _0023_003DzQUhnjVe9kSO_0024.Faces[i].tangentFacesIndices.IndexOf(((TrimCurve)_0023_003DzjDTWe310b3TOuqMxjA_003D_003D[list[k].Item1]).FaceInfo._0023_003DzLJVtPYc_003D);
					_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D = num2 != -1;
					if (_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D)
					{
						Face.tangentType tangentType = _0023_003DzQUhnjVe9kSO_0024.Faces[i].tangentFacesType[num2];
						bool flag2 = (uint)(tangentType - 3) <= 1u;
						_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D = flag2;
					}
					if (_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D)
					{
						num = ((TrimCurve)_0023_003DzjDTWe310b3TOuqMxjA_003D_003D[list[k].Item1]).FaceInfo._0023_003DzLJVtPYc_003D;
					}
				}
				TrimCurve trimCurve = (TrimCurve)_0023_003DzPheed_XFmRFyp84Vdw_003D_003D[list[k].Item1];
				for (int l = k + 1; l < list.Count; l++)
				{
					if (list[l].Item2)
					{
						continue;
					}
					int num3 = -1;
					if (_0023_003DzQUhnjVe9kSO_0024.Faces[i].tangentFacesIndices != null)
					{
						int num4 = _0023_003DzQUhnjVe9kSO_0024.Faces[i].tangentFacesIndices.IndexOf(((TrimCurve)_0023_003DzjDTWe310b3TOuqMxjA_003D_003D[list[l].Item1]).FaceInfo._0023_003DzLJVtPYc_003D);
						_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D = num4 != -1;
						if (_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D)
						{
							Face.tangentType tangentType = _0023_003DzQUhnjVe9kSO_0024.Faces[i].tangentFacesType[num4];
							bool flag2 = (uint)(tangentType - 3) <= 1u;
							_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D = flag2;
						}
						if (_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D)
						{
							num3 = ((TrimCurve)_0023_003DzjDTWe310b3TOuqMxjA_003D_003D[list[l].Item1]).FaceInfo._0023_003DzLJVtPYc_003D;
							if (num3 != num)
							{
								continue;
							}
						}
					}
					TrimCurve trimCurve2 = (TrimCurve)_0023_003DzPheed_XFmRFyp84Vdw_003D_003D[list[l].Item1];
					Point3D _0023_003DzDVubtvo_003D;
					Point3D _0023_003DzFj_0024IqDQ_003D;
					Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D = Curve._0023_003DzRGcO5v1wS2S_(trimCurve.Edge.GetNurbsForm(), trimCurve2.Edge.GetNurbsForm(), out _0023_003DzDVubtvo_003D, out _0023_003DzFj_0024IqDQ_003D, out _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D, 1.0);
					_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D = ((_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)4 || _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)6) ? true : false);
					if (!_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D)
					{
						continue;
					}
					list[k] = (list[k].Item1, true);
					list[l] = (list[l].Item1, true);
					Surface._0023_003Dz2u_3iw7LP_ic _0023_003Dz2u_3iw7LP_ic = new Surface._0023_003Dz2u_3iw7LP_ic
					{
						_0023_003Dz4wZe_0024Xg_003D = _0023_003DzQUhnjVe9kSO_0024.Faces[i].Parametric[trimCurve.FaceInfo._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D]
					};
					Surface.Reparametrize(_0023_003Dz2u_3iw7LP_ic._0023_003Dz4wZe_0024Xg_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dz2AZ_kpw_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dza2Pq9PQ_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
					_0023_003DzVsY16T9qo18G.Add(list[k].Item1);
					_0023_003DzVsY16T9qo18G.Add(list[l].Item1);
					if (!_0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D._0023_003DzZf4zvJoP0u8G(trimCurve, out _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D, out var _, _0023_003DzRAS4kB6WIA5zYp5K0eecf_00240_003D: false, null, _0023_003Dzb9U1KHmIZGGP: false, _0023_003Dzf5uydyTGDFr_0024: false))
					{
						int key = -1;
						if (num != -1)
						{
							key = num;
						}
						if (num3 != -1)
						{
							key = num3;
						}
						if (dictionary.ContainsKey(key))
						{
							dictionary[key].Add(trimCurve.Edge);
							break;
						}
						dictionary.Add(key, new List<ICurve> { trimCurve.Edge });
					}
					break;
				}
			}
			if (dictionary.Count == 0)
			{
				continue;
			}
			if (_0023_003DzLuJVbec_003D == null)
			{
				_0023_003DzLuJVbec_003D = (Brep)_0023_003DzQUhnjVe9kSO_0024.Clone();
				_0023_003DzQUhnjVe9kSO_0024._0023_003DzwIO5_fKTGLjaAtxRaMO9kU4_003D(_0023_003DzLuJVbec_003D);
			}
			int num5 = 0;
			for (int m = 0; m < dictionary.Values.Count; m++)
			{
				ICurve[] connectedCurves = Utility.GetConnectedCurves(dictionary.Values.ElementAt(m), _0023_003Dz85DwsjHHsAwG);
				int num6 = _0023_003DzLuJVbec_003D.Faces.Length;
				booleanFailureType booleanFailureType2 = booleanFailureType.NotIntersecting;
				if (_0023_003DzLuJVbec_003D.Faces[i].Parametric[0]._0023_003DzeluEnlV_EVoyLal8lA_003D_003D(connectedCurves[0].StartPoint, _0023_003Dz85DwsjHHsAwG))
				{
					booleanFailureType2 = _0023_003DzLuJVbec_003D.SubdivideBy(i, connectedCurves);
				}
				if (booleanFailureType2 == booleanFailureType.Success)
				{
					flag = true;
					num5 += _0023_003DzLuJVbec_003D.Faces.Length - num6;
					continue;
				}
				for (int n = 1; n <= num5; n++)
				{
					if (_0023_003DzLuJVbec_003D.Faces[_0023_003DzLuJVbec_003D.Faces.Length - n].Parametric[0]._0023_003DzeluEnlV_EVoyLal8lA_003D_003D(connectedCurves[0].StartPoint, _0023_003Dz85DwsjHHsAwG))
					{
						booleanFailureType2 = _0023_003DzLuJVbec_003D.SubdivideBy(_0023_003DzLuJVbec_003D.Faces.Length - n, connectedCurves);
					}
					if (booleanFailureType2 == booleanFailureType.Success)
					{
						flag = true;
						num5 += _0023_003DzLuJVbec_003D.Faces.Length - num6;
						break;
					}
				}
			}
		}
		if (!flag)
		{
			_0023_003DzLuJVbec_003D = _0023_003DzQUhnjVe9kSO_0024;
		}
		return flag;
	}

	private static _0023_003DzGRk_0024ChFuOP73AsKQDDS1_9AKBHAND6iGKQ_003D_003D _0023_003DzphGY8ZZmyMfcPRaN4A_003D_003D(Brep _0023_003DzqjniGGF9kvbc, Brep _0023_003Dzk0sekCclUGst, bool _0023_003DzIZ8chfIpPnQJmpmf_0024PCX3FPAYO7ClGow9w_003D_003D, List<Curve> _0023_003DzsUwMpJqLeJdg5_yv5w_003D_003D)
	{
		Point3D point = (Point3D)_0023_003DzqjniGGF9kvbc.Vertices[0].Clone();
		Point3D point2 = (Point3D)_0023_003Dzk0sekCclUGst.Vertices[0].Clone();
		bool flag = false;
		bool flag2 = false;
		if (_0023_003DzsUwMpJqLeJdg5_yv5w_003D_003D != null && _0023_003DzIZ8chfIpPnQJmpmf_0024PCX3FPAYO7ClGow9w_003D_003D)
		{
			int num = -1;
			for (int i = 0; i < _0023_003DzqjniGGF9kvbc.Vertices.Length; i++)
			{
				bool flag3 = true;
				foreach (Curve item in _0023_003DzsUwMpJqLeJdg5_yv5w_003D_003D)
				{
					item.ClosestPointTo(_0023_003DzqjniGGF9kvbc.Vertices[i], out var t);
					Point3D b = item.PointAt(t);
					if (Point3D.Distance(_0023_003DzqjniGGF9kvbc.Vertices[i], b) < Utility._0023_003DzheSR8QM7q9ya)
					{
						flag3 = false;
						break;
					}
				}
				if (flag3)
				{
					point = (Point3D)_0023_003DzqjniGGF9kvbc.Vertices[i].Clone();
					num = i;
					break;
				}
			}
			int num2 = -1;
			for (int j = 0; j < _0023_003Dzk0sekCclUGst.Vertices.Length; j++)
			{
				bool flag4 = true;
				foreach (Curve item2 in _0023_003DzsUwMpJqLeJdg5_yv5w_003D_003D)
				{
					item2.ClosestPointTo(_0023_003Dzk0sekCclUGst.Vertices[j], out var t2);
					Point3D b2 = item2.PointAt(t2);
					if (Point3D.Distance(_0023_003Dzk0sekCclUGst.Vertices[j], b2) < Utility._0023_003DzheSR8QM7q9ya)
					{
						flag4 = false;
						break;
					}
				}
				if (flag4)
				{
					point2 = (Point3D)_0023_003Dzk0sekCclUGst.Vertices[j].Clone();
					num2 = j;
					break;
				}
			}
			if (num2 == -1 && num >= 0)
			{
				flag2 = true;
			}
			else if (num == -1 && num2 >= 0)
			{
				flag = true;
			}
		}
		bool flag5;
		if (_0023_003DzqjniGGF9kvbc.ConvexHull != null && _0023_003Dzk0sekCclUGst.ConvexHull != null)
		{
			flag5 = Utility.DoOverlapOrTouch(_0023_003DzqjniGGF9kvbc.ConvexHull, _0023_003Dzk0sekCclUGst.ConvexHull);
		}
		else
		{
			_0023_003DzqjniGGF9kvbc._0023_003DzQCWJbpjMGLxZWfwMCQ_003D_003D(out var _0023_003DzDPcjoBJLcqli, out var _0023_003Dz_0024N_0024yKptW9BoC, _0023_003Dz7cP1pZCb1hQy: true);
			_0023_003Dzk0sekCclUGst._0023_003DzQCWJbpjMGLxZWfwMCQ_003D_003D(out var _0023_003DzDPcjoBJLcqli2, out var _0023_003Dz_0024N_0024yKptW9BoC2, _0023_003Dz7cP1pZCb1hQy: true);
			flag5 = Utility.DoOverlapOrTouch(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC, _0023_003DzDPcjoBJLcqli2, _0023_003Dz_0024N_0024yKptW9BoC2);
		}
		if (flag5)
		{
			if (flag2 || _0023_003DzqjniGGF9kvbc.IsPointInside(point2, skipRebuild: true) == pointStatusType.Inside)
			{
				return (_0023_003DzGRk_0024ChFuOP73AsKQDDS1_9AKBHAND6iGKQ_003D_003D)2;
			}
			if (flag || _0023_003Dzk0sekCclUGst.IsPointInside(point, skipRebuild: true) == pointStatusType.Inside)
			{
				return (_0023_003DzGRk_0024ChFuOP73AsKQDDS1_9AKBHAND6iGKQ_003D_003D)1;
			}
		}
		return (_0023_003DzGRk_0024ChFuOP73AsKQDDS1_9AKBHAND6iGKQ_003D_003D)0;
	}

	private static bool _0023_003DzTCcFngj0Zh3U(Brep _0023_003DzqjniGGF9kvbc, Brep _0023_003Dzk0sekCclUGst, Face _0023_003Dz1nUze6XeLehx)
	{
		if (_0023_003Dz1nUze6XeLehx.tangentFacesIndices == null)
		{
			return false;
		}
		bool result = false;
		OrientedEdge[] segments = _0023_003Dz1nUze6XeLehx.Loops[0].Segments;
		foreach (OrientedEdge orientedEdge in segments)
		{
			ICurve orientedCurve = orientedEdge.GetOrientedCurve(_0023_003DzqjniGGF9kvbc.Edges);
			for (int j = 0; j < _0023_003Dz1nUze6XeLehx.tangentFacesIndices.Count; j++)
			{
				Face face = _0023_003Dzk0sekCclUGst.Faces[_0023_003Dz1nUze6XeLehx.tangentFacesIndices[j]];
				for (int k = 1; k < face.Loops.Length; k++)
				{
					OrientedEdge[] array = face.Loops[k]._0023_003DzYcrVfiECm8tMdEgw8nGE7Hg_003D();
					for (int l = 0; l < array.Length; l++)
					{
						OrientedEdge orientedEdge2 = array[l];
						if (Utility._0023_003DzZCuAc1AnKVueDa_Q8w_003D_003D(_0023_003Dzk0sekCclUGst.Edges[orientedEdge2.CurveIndex].Curve, orientedCurve, out var _, 1.0) == 0)
						{
							result = true;
							break;
						}
					}
				}
			}
		}
		return result;
	}

	private static bool _0023_003Dzy0agWQU1pS_0024g(Brep _0023_003DzqjniGGF9kvbc, Brep _0023_003Dzk0sekCclUGst, Face _0023_003Dz1nUze6XeLehx)
	{
		if (_0023_003Dz1nUze6XeLehx.tangentFacesIndices == null)
		{
			return false;
		}
		if (_0023_003Dz1nUze6XeLehx.Loops.Length < 2)
		{
			return false;
		}
		for (int i = 1; i < _0023_003Dz1nUze6XeLehx.Loops.Length; i++)
		{
			OrientedEdge[] segments = _0023_003Dz1nUze6XeLehx.Loops[i].Segments;
			foreach (OrientedEdge orientedEdge in segments)
			{
				ICurve orientedCurve = orientedEdge.GetOrientedCurve(_0023_003DzqjniGGF9kvbc.Edges);
				for (int k = 0; k < _0023_003Dz1nUze6XeLehx.tangentFacesIndices.Count; k++)
				{
					OrientedEdge[] array = _0023_003Dzk0sekCclUGst.Faces[_0023_003Dz1nUze6XeLehx.tangentFacesIndices[k]].Loops[0]._0023_003DzYcrVfiECm8tMdEgw8nGE7Hg_003D();
					for (int l = 0; l < array.Length; l++)
					{
						OrientedEdge orientedEdge2 = array[l];
						if (Utility._0023_003DzZCuAc1AnKVueDa_Q8w_003D_003D(_0023_003Dzk0sekCclUGst.Edges[orientedEdge2.CurveIndex].Curve, orientedCurve, out var _, 1.0) == 0)
						{
							return true;
						}
						if (orientedCurve.IsClosed && orientedCurve is Circle circle && _0023_003Dzk0sekCclUGst.Edges[orientedEdge2.CurveIndex].Curve.IsClosed && _0023_003Dzk0sekCclUGst.Edges[orientedEdge2.CurveIndex].Curve is Circle circle2)
						{
							double problemSize = Math.Min(circle.Length(), circle2.Length());
							double num = 1E-06 * Math.Min(circle.Length(), circle2.Length());
							if (Utility.PointCoincidence(circle.Center.AsVector, circle2.Center.AsVector, problemSize, out var _, out var _) && Vector3D.AreParallel(circle.Plane.AxisZ, circle2.Plane.AxisZ, 1E-06) && Math.Abs(circle.Radius - circle2.Radius) < num)
							{
								return true;
							}
						}
					}
				}
			}
		}
		return false;
	}

	private static bool _0023_003Dzp5I572_XXGZXPdnmnkHnAuWkcdr5(ICurve[] _0023_003DzPheed_XFmRFyp84Vdw_003D_003D, out List<Curve> _0023_003Dz0B5Dc_00244nIZ5Fu87AHQ_003D_003D)
	{
		bool[] array = new bool[_0023_003DzPheed_XFmRFyp84Vdw_003D_003D.Length];
		_0023_003Dz0B5Dc_00244nIZ5Fu87AHQ_003D_003D = new List<Curve>();
		if (_0023_003DzPheed_XFmRFyp84Vdw_003D_003D.Length < 2)
		{
			return false;
		}
		for (int i = 0; i < _0023_003DzPheed_XFmRFyp84Vdw_003D_003D.Length - 1; i++)
		{
			if (array[i])
			{
				continue;
			}
			Curve nurbsForm = ((TrimCurve)_0023_003DzPheed_XFmRFyp84Vdw_003D_003D[i]).Edge.GetNurbsForm();
			bool flag = false;
			HashSet<int> hashSet = new HashSet<int>();
			bool _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D;
			for (int j = i + 1; j < _0023_003DzPheed_XFmRFyp84Vdw_003D_003D.Length; j++)
			{
				Curve nurbsForm2 = ((TrimCurve)_0023_003DzPheed_XFmRFyp84Vdw_003D_003D[j]).Edge.GetNurbsForm();
				Point3D _0023_003DzDVubtvo_003D;
				Point3D _0023_003DzFj_0024IqDQ_003D;
				Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D = Curve._0023_003DzRGcO5v1wS2S_(nurbsForm, nurbsForm2, out _0023_003DzDVubtvo_003D, out _0023_003DzFj_0024IqDQ_003D, out _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D, 1.0);
				if (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)6 || _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)5)
				{
					hashSet.Add(i);
					hashSet.Add(j);
					if (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)6)
					{
						flag = true;
					}
				}
			}
			if (!flag)
			{
				return false;
			}
			if (_0023_003Dz0B5Dc_00244nIZ5Fu87AHQ_003D_003D.Count > 0)
			{
				foreach (Curve item in _0023_003Dz0B5Dc_00244nIZ5Fu87AHQ_003D_003D)
				{
					if (item.IntersectWith(nurbsForm).Length != 0 && (!Point3D.AreEqual(nurbsForm.StartPoint, item.StartPoint, 1.0) || !Vector3D.AreParallel(nurbsForm.StartTangent, item.StartTangent)) && (!Point3D.AreEqual(nurbsForm.StartPoint, item.EndPoint, 1.0) || !Vector3D.AreParallel(nurbsForm.StartTangent, item.EndTangent)) && (!Point3D.AreEqual(nurbsForm.EndPoint, item.StartPoint, 1.0) || !Vector3D.AreParallel(nurbsForm.EndTangent, item.StartTangent)) && (!Point3D.AreEqual(nurbsForm.EndPoint, item.EndPoint, 1.0) || !Vector3D.AreParallel(nurbsForm.EndTangent, item.EndTangent)))
					{
						_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D = false;
						return _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D;
					}
				}
			}
			foreach (int item2 in hashSet)
			{
				array[item2] = true;
			}
			_0023_003Dz0B5Dc_00244nIZ5Fu87AHQ_003D_003D.Add(nurbsForm);
		}
		return Array.TrueForAll(array, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzcV9IxxQqdwBM5VMB6YD8RM09JkCRTcDgjHk38SAuPZqW);
	}

	private static bool _0023_003Dzk9dIqBWAYqkC1QeaSEiM6AfX5sLX(Brep _0023_003DzqjniGGF9kvbc, Brep _0023_003Dzk0sekCclUGst, Face _0023_003Dz1nUze6XeLehx, double _0023_003DzjE0LV51gRsJN, out Face _0023_003DzdjGa2HlHPqCy_0024d2Wjw_003D_003D)
	{
		_0023_003DzdjGa2HlHPqCy_0024d2Wjw_003D_003D = null;
		for (int i = 0; i < _0023_003Dz1nUze6XeLehx.Loops.Length; i++)
		{
			Loop loop = _0023_003Dz1nUze6XeLehx.Loops[i];
			for (int j = 0; j < loop.Segments.Length; j++)
			{
				Edge edge = _0023_003DzqjniGGF9kvbc.Edges[loop.Segments[j].CurveIndex];
				if (edge.SplitStatus != SplitEdgeStatus.OnBothEdges && edge.SplitStatus != SplitEdgeStatus.Included)
				{
					return false;
				}
			}
		}
		Edge edge2 = _0023_003DzqjniGGF9kvbc.Edges[_0023_003Dz1nUze6XeLehx.Loops[0].Segments[0].CurveIndex];
		int[] array = _0023_003Dz1nUze6XeLehx.tangentFacesIndices.ToArray();
		bool flag = false;
		for (int k = 0; k < array.Length; k++)
		{
			if (_0023_003Dz1nUze6XeLehx.tangentFacesType[k] == Face.tangentType.coplanarOpposite || _0023_003Dz1nUze6XeLehx.tangentFacesType[k] == Face.tangentType.coincidentOpposite)
			{
				continue;
			}
			_0023_003DzdjGa2HlHPqCy_0024d2Wjw_003D_003D = _0023_003Dzk0sekCclUGst.Faces[array[k]];
			if (_0023_003DzdjGa2HlHPqCy_0024d2Wjw_003D_003D.Loops.Length != _0023_003Dz1nUze6XeLehx.Loops.Length || _0023_003DzdjGa2HlHPqCy_0024d2Wjw_003D_003D.Loops[0].Segments.Length != _0023_003Dz1nUze6XeLehx.Loops[0].Segments.Length)
			{
				continue;
			}
			for (int l = 0; l < _0023_003DzdjGa2HlHPqCy_0024d2Wjw_003D_003D.Loops[0].Segments.Length; l++)
			{
				Edge edge3 = _0023_003Dzk0sekCclUGst.Edges[_0023_003DzdjGa2HlHPqCy_0024d2Wjw_003D_003D.Loops[0].Segments[l].CurveIndex];
				flag = Utility._0023_003DzZCuAc1AnKVueDa_Q8w_003D_003D(edge2.Curve, edge3.Curve, out var _, 1.0) != -1;
				if (flag)
				{
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		return flag;
	}

	private static void _0023_003Dzhlq5RKbWjx6nskJGYQMtB7C9hVAf(Brep _0023_003DzqjniGGF9kvbc, Brep _0023_003Dzk0sekCclUGst, out int _0023_003DzFUZJf1oIN_0024YFcfi6jm6UmW4_003D, out int _0023_003Dz3TY01ej_00249czv3Uoapw_003D_003D, out int _0023_003DzbtFoN5ZWAcGhm0aNILADRWs_003D, bool _0023_003Dzk_3tZjgmhGlmfKWn0g_003D_003D, bool _0023_003DzY7IAYN_00249VAHl11lbabS4sjVmDFI0)
	{
		_0023_003DzFUZJf1oIN_0024YFcfi6jm6UmW4_003D = 0;
		_0023_003Dz3TY01ej_00249czv3Uoapw_003D_003D = 0;
		_0023_003DzbtFoN5ZWAcGhm0aNILADRWs_003D = 0;
		for (int i = 0; i < _0023_003DzqjniGGF9kvbc.Faces.Length; i++)
		{
			for (int j = 0; j < _0023_003Dzk0sekCclUGst.Faces.Length; j++)
			{
				if (_0023_003DzqjniGGF9kvbc.Faces[i]._0023_003Dz7EOfQ_wBFahDw9Pn9w_003D_003D(_0023_003Dzk0sekCclUGst.Faces[j], out var _0023_003DzzwoQwOglTJml3vqNGA_003D_003D, _0023_003Dzk_3tZjgmhGlmfKWn0g_003D_003D))
				{
					_0023_003DzDGKpAzSkMFmF(_0023_003DzqjniGGF9kvbc.Faces[i], j, _0023_003Dzk0sekCclUGst.Faces[j], i, _0023_003DzzwoQwOglTJml3vqNGA_003D_003D);
					_0023_003Dzk0sekCclUGst.Faces[j].Visited = true;
					_0023_003DzFUZJf1oIN_0024YFcfi6jm6UmW4_003D++;
				}
				if (_0023_003DzY7IAYN_00249VAHl11lbabS4sjVmDFI0)
				{
					continue;
				}
				if ((object)_0023_003Dzk0sekCclUGst.Faces[j].plane == null)
				{
					_0023_003Dzk0sekCclUGst.Faces[j]._0023_003Dz2rx0bYXAv_0024aP(_0023_003Dzk_3tZjgmhGlmfKWn0g_003D_003D);
				}
				Face.tangentType tangentType = _0023_003DzqjniGGF9kvbc.Faces[i]._0023_003DzaGX1f4XwdTHn(_0023_003Dzk0sekCclUGst.Faces[j]);
				if (tangentType != Face.tangentType.none && (_0023_003DzqjniGGF9kvbc.Faces[i].tangentFacesIndices == null || !_0023_003DzqjniGGF9kvbc.Faces[i].tangentFacesIndices.Contains(j)) && tangentType != Face.tangentType.none)
				{
					_0023_003DzDGKpAzSkMFmF(_0023_003DzqjniGGF9kvbc.Faces[i], j, _0023_003Dzk0sekCclUGst.Faces[j], i, tangentType);
					_0023_003Dzk0sekCclUGst.Faces[j].Visited = true;
					_0023_003Dz3TY01ej_00249czv3Uoapw_003D_003D++;
					if (tangentType == Face.tangentType.coincident || tangentType == Face.tangentType.coincidentOpposite)
					{
						_0023_003DzbtFoN5ZWAcGhm0aNILADRWs_003D++;
					}
				}
			}
		}
	}

	private static void _0023_003DzDGKpAzSkMFmF(Face _0023_003Dzn6eRxNucSNoK, int _0023_003DzhuMcd2o_003D, Face _0023_003DzcQpPRG5mmRCF, int _0023_003Dz3_xJkPw_003D, Face.tangentType _0023_003DzEKSHIVc_003D)
	{
		if (_0023_003Dzn6eRxNucSNoK.tangentFacesIndices == null)
		{
			_0023_003Dzn6eRxNucSNoK.tangentFacesIndices = new List<int>();
			_0023_003Dzn6eRxNucSNoK.tangentFacesType = new List<Face.tangentType>();
		}
		_0023_003Dzn6eRxNucSNoK.tangentFacesIndices.Add(_0023_003DzhuMcd2o_003D);
		_0023_003Dzn6eRxNucSNoK.tangentFacesType.Add(_0023_003DzEKSHIVc_003D);
		if (_0023_003DzcQpPRG5mmRCF.tangentFacesIndices == null)
		{
			_0023_003DzcQpPRG5mmRCF.tangentFacesIndices = new List<int>();
			_0023_003DzcQpPRG5mmRCF.tangentFacesType = new List<Face.tangentType>();
		}
		_0023_003DzcQpPRG5mmRCF.tangentFacesIndices.Add(_0023_003Dz3_xJkPw_003D);
		_0023_003DzcQpPRG5mmRCF.tangentFacesType.Add(_0023_003DzEKSHIVc_003D);
	}

	internal void _0023_003DzQCWJbpjMGLxZWfwMCQ_003D_003D(out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC, bool _0023_003Dz7cP1pZCb1hQy)
	{
		List<Point3D> list = new List<Point3D>();
		Face[] faces = Faces;
		foreach (Face face in faces)
		{
			if (face.Parametric == null)
			{
				_0023_003DzDPcjoBJLcqli = (_0023_003Dz_0024N_0024yKptW9BoC = null);
				return;
			}
			Surface[] parametric = face.Parametric;
			foreach (Surface surface in parametric)
			{
				surface._0023_003DzIQv8kUn9rJJPHOmQIg_003D_003D();
				surface.shrunk.ControlBoundingBox(out surface.shrunk.localMin, out surface.shrunk.localMax);
				list.Add(surface.shrunk.localMin);
				list.Add(surface.shrunk.localMax);
			}
		}
		Utility.ComputeBoundingBox(list.ToArray(), out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC);
	}

	private int _0023_003DzmwC6ucT5JizX(Edge _0023_003DzTx2aqr8_003D, Vertex _0023_003Dz77g161c_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, Dictionary<int, Dictionary<double, int>> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, int _0023_003DzD65Ok98_003D, Dictionary<int, int> _0023_003DzVR_NB33ieggi, out int _0023_003DzqhsKlJc_003D, bool _0023_003DzQvAq6etyzFEv, double _0023_003Dz4pnV730yubPj)
	{
		double t = 0.0;
		double num = Math.Min(_rebuildTol, _0023_003Dz4pnV730yubPj);
		_0023_003DzqhsKlJc_003D = -1;
		for (int i = 0; i < _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count; i++)
		{
			if (Point3D.Distance(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[i], _0023_003Dz77g161c_003D) < num)
			{
				_0023_003DzqhsKlJc_003D = i;
				_0023_003Dz77g161c_003D = (Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzqhsKlJc_003D];
				break;
			}
		}
		_0023_003DzTx2aqr8_003D.Curve.ClosestPointTo(_0023_003Dz77g161c_003D, out t);
		if (Point3D.Distance(_0023_003Dz77g161c_003D, _0023_003DzTx2aqr8_003D.Curve.PointAt(t)) > num)
		{
			return -1;
		}
		if (_0023_003DzTx2aqr8_003D.Curve.Domain.Includes(t, testOpenInterval: true) && !Utility.AreEqual(t, _0023_003DzTx2aqr8_003D.Curve.Domain.Low, _0023_003DzTx2aqr8_003D.Curve.Domain.Length) && !Utility.AreEqual(t, _0023_003DzTx2aqr8_003D.Curve.Domain.High, _0023_003DzTx2aqr8_003D.Curve.Domain.Length))
		{
			if (_0023_003DzqhsKlJc_003D == -1)
			{
				_0023_003DzqhsKlJc_003D = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count;
				_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(_0023_003Dz77g161c_003D);
			}
			_0023_003DzTx2aqr8_003D.SplitStatus = SplitEdgeStatus.NeedToTrim;
			if (!_0023_003DzQvAq6etyzFEv)
			{
				_faces[_0023_003DzTx2aqr8_003D.Parents[0]].hasEdgesToSplit = true;
				if (_0023_003DzTx2aqr8_003D.Parents.Length > 1)
				{
					_faces[_0023_003DzTx2aqr8_003D.Parents[1]].hasEdgesToSplit = true;
				}
			}
			if (!_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D.TryGetValue(_0023_003DzD65Ok98_003D, out var value))
			{
				value = new Dictionary<double, int>();
				_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D.Add(_0023_003DzD65Ok98_003D, value);
			}
			if (!value.ContainsKey(t))
			{
				value.Add(t, _0023_003DzqhsKlJc_003D);
			}
		}
		else
		{
			if (_0023_003DzqhsKlJc_003D == -1 && Utility.AreEqual(t, _0023_003DzTx2aqr8_003D.Curve.Domain.Low, _0023_003DzTx2aqr8_003D.Curve.Domain.Length))
			{
				((Vertex)Vertices[_0023_003DzTx2aqr8_003D.StartPointIndex]).Visited = true;
				if (_0023_003DzqhsKlJc_003D == -1)
				{
					_0023_003DzqhsKlJc_003D = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count;
					Vertex vertex = (Vertex)Vertices[_0023_003DzTx2aqr8_003D.StartPointIndex].Clone();
					vertex.Parents = null;
					_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(vertex);
				}
				if (!_0023_003DzVR_NB33ieggi.ContainsKey(_0023_003DzTx2aqr8_003D.StartPointIndex))
				{
					_0023_003DzVR_NB33ieggi.Add(_0023_003DzTx2aqr8_003D.StartPointIndex, _0023_003DzqhsKlJc_003D);
				}
				return _0023_003DzTx2aqr8_003D.StartPointIndex;
			}
			if (_0023_003DzqhsKlJc_003D == -1 && Utility.AreEqual(t, _0023_003DzTx2aqr8_003D.Curve.Domain.High, _0023_003DzTx2aqr8_003D.Curve.Domain.Length))
			{
				((Vertex)Vertices[_0023_003DzTx2aqr8_003D.EndPointIndex]).Visited = true;
				if (_0023_003DzqhsKlJc_003D == -1)
				{
					_0023_003DzqhsKlJc_003D = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count;
					Vertex vertex2 = (Vertex)Vertices[_0023_003DzTx2aqr8_003D.EndPointIndex].Clone();
					vertex2.Parents = null;
					_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(vertex2);
				}
				if (!_0023_003DzVR_NB33ieggi.ContainsKey(_0023_003DzTx2aqr8_003D.EndPointIndex))
				{
					_0023_003DzVR_NB33ieggi.Add(_0023_003DzTx2aqr8_003D.EndPointIndex, _0023_003DzqhsKlJc_003D);
				}
				return _0023_003DzTx2aqr8_003D.EndPointIndex;
			}
		}
		return -1;
	}

	internal Loop[][] _0023_003DzgohMRFtWo4Kp0sv9bQ_003D_003D(int _0023_003DzsMwVBGaGQeZg, int _0023_003DzhNQLY4s_003D, List<Edge> _0023_003DzU3hosSAzkxO7, List<Edge> _0023_003DzViGQVPM_003D, Dictionary<int, List<int>> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, Dictionary<int, int> _0023_003DzQtyBAo4gFsZY, Dictionary<int, int> _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, List<Face> _0023_003DzUbkxYVFDH3ry, Dictionary<int, List<ICurve>> _0023_003DzNsS6ffzfSlG6, out Surface[] _0023_003Dz_0024AxqLU6JSbjFi59sUNmvveY_003D, bool _0023_003Dz0mIPc9VROWxZ)
	{
		Loop[][] array = new Loop[0][];
		_0023_003Dz_0024AxqLU6JSbjFi59sUNmvveY_003D = new Surface[0];
		_0023_003DzNsS6ffzfSlG6.TryGetValue(_0023_003DzsMwVBGaGQeZg, out var value);
		Face face = Faces[_0023_003DzsMwVBGaGQeZg];
		for (int num = 0; num < face.Parametric.Length; num++)
		{
			double _0023_003Dz85DwsjHHsAwG;
			List<Surface> _0023_003DzZE9fb_0024M_003D;
			switch (_0023_003DzRyYpgCwIajnh5_0024JDssSJlQY_003D(face.Parametric[num], value, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, _0023_003DzQtyBAo4gFsZY, out _0023_003Dz85DwsjHHsAwG, out _0023_003DzZE9fb_0024M_003D))
			{
			case -1:
				return new Loop[0][];
			case -2:
				return null;
			}
			_0023_003Dz_0024AxqLU6JSbjFi59sUNmvveY_003D = _0023_003DzZE9fb_0024M_003D.ToArray();
			array = new Loop[_0023_003DzZE9fb_0024M_003D.Count][];
			for (int i = 0; i < _0023_003DzZE9fb_0024M_003D.Count; i++)
			{
				Region trimming = _0023_003DzZE9fb_0024M_003D[i].Trimming;
				List<Loop> list = new List<Loop>(trimming.ContourList.Count);
				for (int j = 0; j < trimming.ContourList.Count; j++)
				{
					ICurve[] individualCurves = trimming.ContourList[j].GetIndividualCurves();
					List<OrientedEdge> list2 = new List<OrientedEdge>(individualCurves.Length);
					int num2 = 0;
					int num3 = 0;
					while (num3 < individualCurves.Length && num2 < face.Loops.Length)
					{
						bool flag = false;
						OrientedEdge[] segments = face.Loops[num2].Segments;
						TrimCurve trimCurve = (TrimCurve)individualCurves[num3];
						int edgeIndex = ((ICurve)trimCurve).EdgeIndex;
						if (((ICurve)trimCurve).EdgeIndex == -1)
						{
							if (trimCurve.Edge.Length() > _rebuildTol)
							{
								return null;
							}
							num3++;
							num2 = 0;
							continue;
						}
						if (trimCurve.FromBooleanIntersection)
						{
							int num4 = edgeIndex;
							double t = trimCurve.Edge.Domain.Low + trimCurve.Edge.Domain.Length / 3.0 * 2.0;
							_0023_003DzViGQVPM_003D[num4].Curve.Project(trimCurve.Edge.PointAt(t), out var t2);
							bool sense = Vector3D.AreCoincident(trimCurve.Edge.TangentAt(t), _0023_003DzViGQVPM_003D[num4].Curve.TangentAt(t2));
							OrientedEdge item = new OrientedEdge(num4, sense);
							flag = true;
							list2.Add(item);
							trimCurve.FromBooleanIntersection = false;
						}
						else
						{
							for (int k = 0; k < segments.Length; k++)
							{
								if (segments[k].CurveIndex != edgeIndex)
								{
									continue;
								}
								OrientedEdge _0023_003DzKm2q1fi2Z68M_0024_5T6A_003D_003D = (segments[k] = segments[k]);
								flag = true;
								if ((Edges[_0023_003DzKm2q1fi2Z68M_0024_5T6A_003D_003D.CurveIndex].SplitStatus == SplitEdgeStatus.Included || Edges[_0023_003DzKm2q1fi2Z68M_0024_5T6A_003D_003D.CurveIndex].SplitStatus == SplitEdgeStatus.NotAssigned) && Edges[_0023_003DzKm2q1fi2Z68M_0024_5T6A_003D_003D.CurveIndex].Parents.Length > 1)
								{
									int _0023_003DzsMwVBGaGQeZg2 = ((Edges[_0023_003DzKm2q1fi2Z68M_0024_5T6A_003D_003D.CurveIndex].Parents[0] == _0023_003DzsMwVBGaGQeZg) ? Edges[_0023_003DzKm2q1fi2Z68M_0024_5T6A_003D_003D.CurveIndex].Parents[1] : Edges[_0023_003DzKm2q1fi2Z68M_0024_5T6A_003D_003D.CurveIndex].Parents[0]);
									if (!_0023_003DzQ5fDF2jR3C5L0fCEng_003D_003D(_0023_003DzsMwVBGaGQeZg2, _0023_003DzUbkxYVFDH3ry, _0023_003DzNsS6ffzfSlG6, _0023_003DzxI_R5dw_003D: true, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, _0023_003DzViGQVPM_003D, _0023_003DzQtyBAo4gFsZY, _0023_003Dz0mIPc9VROWxZ))
									{
										return null;
									}
								}
								_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D.TryGetValue(edgeIndex, out var value2);
								switch (_0023_003DzLCTQ3rz_P4Wm(_0023_003DzKm2q1fi2Z68M_0024_5T6A_003D_003D, edgeIndex, _0023_003DzU3hosSAzkxO7, _0023_003DzViGQVPM_003D, value2, _0023_003DzQtyBAo4gFsZY, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, _0023_003DzZE9fb_0024M_003D[i], list2, j, num3))
								{
								case 1:
									individualCurves = trimming.ContourList[j].GetIndividualCurves();
									break;
								case -1:
									return null;
								}
								break;
							}
						}
						if (flag)
						{
							num3++;
							num2 = 0;
						}
						else
						{
							num2++;
						}
					}
					if (list2.Count > 0)
					{
						list.Add(new Loop(list2.ToArray(), sense: true));
					}
					array[i] = list.ToArray();
				}
			}
		}
		return array;
	}

	private int _0023_003DzRyYpgCwIajnh5_0024JDssSJlQY_003D(Surface _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D, List<ICurve> _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D, Dictionary<int, List<int>> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, Dictionary<int, int> _0023_003DzQtyBAo4gFsZY, out double _0023_003Dz85DwsjHHsAwG, out List<Surface> _0023_003DzZE9fb_0024M_003D)
	{
		Surface._0023_003Dz2u_3iw7LP_ic _0023_003Dz2u_3iw7LP_ic = new Surface._0023_003Dz2u_3iw7LP_ic
		{
			_0023_003Dz4wZe_0024Xg_003D = _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D
		};
		Surface.Reparametrize(_0023_003Dz2u_3iw7LP_ic._0023_003Dz4wZe_0024Xg_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dz2AZ_kpw_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dza2Pq9PQ_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
		_0023_003Dz85DwsjHHsAwG = _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D._0023_003DzVx1luJEZaaC7().Diagonal * 1E-05;
		_0023_003DzZE9fb_0024M_003D = new List<Surface>();
		int result = 0;
		List<ICurve> list = new List<ICurve>();
		if (_0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D != null)
		{
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D.Count; i++)
			{
				if (!((TrimCurve)_0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D[i]).fromTangentEdgeParent)
				{
					flag2 = true;
					break;
				}
			}
			for (int j = 0; j < _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D.Count; j++)
			{
				if (((TrimCurve)_0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D[j]).fromTangentEdgeParent && flag2)
				{
					continue;
				}
				if (_0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D._0023_003DzZf4zvJoP0u8G(_0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D[j], out var _0023_003DzKgWCaV5RTv9VxFld_g_003D_003D, out var _0023_003Dz93D7WaCPl_0024u, _0023_003DzRAS4kB6WIA5zYp5K0eecf_00240_003D: false, null, _0023_003Dzb9U1KHmIZGGP: false, _0023_003Dzf5uydyTGDFr_0024: false))
				{
					if (_0023_003Dz93D7WaCPl_0024u != -1 && _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D[j].EdgeIndex != -1 && (!_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D.ContainsKey(_0023_003Dz93D7WaCPl_0024u) || _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D[_0023_003Dz93D7WaCPl_0024u].Count == 1))
					{
						_edges[_0023_003Dz93D7WaCPl_0024u].SplitStatus = SplitEdgeStatus.NewEdge;
						_edges[_0023_003Dz93D7WaCPl_0024u].Visited = true;
						if (!_0023_003DzQtyBAo4gFsZY.ContainsKey(_0023_003Dz93D7WaCPl_0024u))
						{
							_0023_003DzQtyBAo4gFsZY.Add(_0023_003Dz93D7WaCPl_0024u, _0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D[j].EdgeIndex);
						}
					}
				}
				else
				{
					list.Add(_0023_003Dzez6bqSFwp7dL7pq_lA_003D_003D[j]);
				}
				if (_0023_003DzKgWCaV5RTv9VxFld_g_003D_003D)
				{
					flag = true;
				}
			}
			if (list.Count == 0)
			{
				result = ((!flag) ? 1 : (-1));
			}
			else
			{
				for (int k = 0; k < _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.Trimming.ContourList.Count; k++)
				{
					ICurve[] individualCurves = _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.Trimming.ContourList[k].GetIndividualCurves();
					for (int l = 0; l < individualCurves.Length; l++)
					{
						TrimCurve trimCurve = (TrimCurve)individualCurves[l];
						if (trimCurve.EdgeIndex == -1 && trimCurve.Edge.Length() > _rebuildTol)
						{
							throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959580));
						}
					}
				}
				if (!_0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D._0023_003Dz3K5qCLg_003D(list, _0023_003DzaFEehOi8mwIq: false, _0023_003DzZE9fb_0024M_003D))
				{
					return -2;
				}
			}
		}
		else
		{
			result = 1;
		}
		_0023_003DzZE9fb_0024M_003D.Add(_0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
		for (int m = 0; m < _0023_003DzZE9fb_0024M_003D.Count; m++)
		{
			Surface surface = (Surface)_0023_003Dz2u_3iw7LP_ic._0023_003Dz4wZe_0024Xg_003D.Clone();
			Surface._0023_003Dz2H0sPWA7GG3dUZULsA6_WPc_003D(surface, _0023_003Dz2u_3iw7LP_ic._0023_003Dz2AZ_kpw_003D, _0023_003Dz2u_3iw7LP_ic._0023_003Dza2Pq9PQ_003D, _0023_003Dz2u_3iw7LP_ic._0023_003Dz4EQwPRR8p12S, _0023_003DzZE9fb_0024M_003D[m], _0023_003Dz2u_3iw7LP_ic._0023_003DzskeF_tVWIwSE);
			_0023_003DzZE9fb_0024M_003D[m] = surface;
		}
		return result;
	}

	internal static Brep[] _0023_003Dz2LwOnW_H_0024i8hPxptuw_003D_003D(Brep _0023_003Dz9vlLNhLzY7_0024X)
	{
		List<Brep> list = new List<Brep>();
		bool[] array = new bool[_0023_003Dz9vlLNhLzY7_0024X.Faces.Length];
		Dictionary<int, int> dictionary = new Dictionary<int, int>(_0023_003Dz9vlLNhLzY7_0024X.Edges.Length);
		int[] array2 = new int[_0023_003Dz9vlLNhLzY7_0024X.Vertices.Length];
		for (int i = 0; i < _0023_003Dz9vlLNhLzY7_0024X.Edges.Length; i++)
		{
			dictionary.Add(i, -1);
		}
		for (int j = 0; j < array2.Length; j++)
		{
			array2[j] = -1;
		}
		int num = 0;
		int num2 = -1;
		do
		{
			List<Face> list2 = new List<Face>(_0023_003Dz9vlLNhLzY7_0024X.Faces.Length);
			List<Edge> list3 = new List<Edge>(_0023_003Dz9vlLNhLzY7_0024X.Edges.Length);
			List<Vertex> list4 = new List<Vertex>(_0023_003Dz9vlLNhLzY7_0024X.Vertices.Length);
			List<int> list5 = new List<int>(_0023_003Dz9vlLNhLzY7_0024X.Faces.Length);
			if (!array[num])
			{
				list5.Add(num);
				array[num] = true;
				int num3;
				for (num3 = 0; num3 < list5.Count; num3++)
				{
					Face face = (Face)_0023_003Dz9vlLNhLzY7_0024X.Faces[list5[num3]].Clone();
					if (_0023_003Dz9vlLNhLzY7_0024X.Faces[list5[num3]].Parametric != null)
					{
						face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D((Surface[])_0023_003Dz9vlLNhLzY7_0024X.Faces[list5[num3]].Parametric.Clone());
						face.needRebuild = _0023_003Dz9vlLNhLzY7_0024X.Faces[list5[num3]].needRebuild;
					}
					for (int k = 0; k < face.Loops.Length; k++)
					{
						Loop loop = face.Loops[k];
						for (int l = 0; l < loop.Segments.Length; l++)
						{
							OrientedEdge orientedEdge = loop.Segments[l];
							if (dictionary[orientedEdge.CurveIndex] == -1)
							{
								dictionary[orientedEdge.CurveIndex] = list3.Count;
								Edge edge = _0023_003Dz9vlLNhLzY7_0024X.Edges[orientedEdge.CurveIndex];
								if (array2[edge.StartPointIndex] == -1)
								{
									array2[edge.StartPointIndex] = list4.Count;
									list4.Add((Vertex)_0023_003Dz9vlLNhLzY7_0024X.Vertices[edge.StartPointIndex].Clone());
								}
								if (array2[edge.EndPointIndex] == -1)
								{
									array2[edge.EndPointIndex] = list4.Count;
									list4.Add((Vertex)_0023_003Dz9vlLNhLzY7_0024X.Vertices[edge.EndPointIndex].Clone());
								}
								Edge edge2 = (Edge)edge.Clone();
								edge2.StartPointIndex = array2[edge.StartPointIndex];
								edge2.EndPointIndex = array2[edge.EndPointIndex];
								list3.Add(edge2);
								if (edge.Parents.Length <= 2)
								{
									for (int m = 0; m < edge.Parents.Length; m++)
									{
										if (!array[edge.Parents[m]])
										{
											list5.Add(edge.Parents[m]);
											array[edge.Parents[m]] = true;
										}
									}
								}
								else
								{
									edge2.Parents = null;
									num2 = orientedEdge.CurveIndex;
								}
							}
							loop.Segments[l] = new OrientedEdge(dictionary[orientedEdge.CurveIndex], orientedEdge.Sense);
						}
					}
					if (face.Parametric != null)
					{
						face._0023_003Dzu_VTP2T_2LTBmaxiiTgVZUs_003D(dictionary, _0023_003Dz9vlLNhLzY7_0024X._rebuildTol, _0023_003DzvsFKDVZyhE_Q: false);
					}
					list2.Add(face);
					face.Surface.TranslationID = new TranslationIdentifier(list2.Count - 1);
					list5.RemoveAt(num3);
					num3 = -1;
				}
			}
			Point3D[] array3 = list4.ToArray();
			Point3D[] array4 = array3;
			Edge[] array5 = list3.ToArray();
			Face[] array6 = list2.ToArray();
			Face[][] _0023_003DzWaFlkhfmYCja = new Face[0][];
			if (num2 != -1)
			{
				dictionary[num2] = -1;
				array2[_0023_003Dz9vlLNhLzY7_0024X.Edges[num2].StartPointIndex] = -1;
				array2[_0023_003Dz9vlLNhLzY7_0024X.Edges[num2].EndPointIndex] = -1;
			}
			try
			{
				_0023_003Dz8VkxvzXXGxA_0024(array4, array5, array6, _0023_003DzWaFlkhfmYCja, _0023_003DzLuJVbec_003D: true);
				Brep brep = new Brep(array4, array5, array6, null, _0023_003Dz9vlLNhLzY7_0024X.RebuildTolerance);
				brep.CopyAttributes(_0023_003Dz9vlLNhLzY7_0024X);
				list.Add(brep);
			}
			catch (Exception)
			{
				return null;
			}
			list2.Clear();
			list3.Clear();
			list4.Clear();
			for (int n = 0; n < array.Length; n++)
			{
				if (!array[n])
				{
					num = n;
					break;
				}
				if (n == array.Length - 1)
				{
					num = _0023_003Dz9vlLNhLzY7_0024X.Faces.Length;
					break;
				}
			}
		}
		while (num < _0023_003Dz9vlLNhLzY7_0024X.Faces.Length && _0023_003Dz9vlLNhLzY7_0024X.Faces.Length > 1);
		return list.ToArray();
	}

	public int MergeFaces()
	{
		Brep brep = (Brep)Clone();
		int[] array = new int[brep._inners.GetLength(0) + 1];
		int _0023_003DzzRLVd6CqM2bZhmKGqA_003D_003D = 0;
		int[][] array2 = new int[brep._inners.Length + 1][];
		for (int i = 0; i < array2.Length; i++)
		{
			if (i == 0)
			{
				array2[i] = new int[brep._faces.Length];
			}
			else
			{
				array2[i] = new int[brep._inners[i - 1].Length];
			}
			for (int j = 0; j < array2[i].Length; j++)
			{
				array2[i][j] = -1;
				if (i == 0)
				{
					_0023_003DzH_00244LxjBICrXYBxcvYXYFsGI_003D(_faces[j], brep._faces[j], _0023_003Dz0mIPc9VROWxZ: false, null, 0.0);
					brep._faces[j].planeAlreadySet = _faces[j].planeAlreadySet;
					brep._faces[j].plane = (Plane)(_faces[j].plane?.Clone());
				}
				else
				{
					_0023_003DzH_00244LxjBICrXYBxcvYXYFsGI_003D(_inners[i - 1][j], brep._inners[i - 1][j], _0023_003Dz0mIPc9VROWxZ: false, null, 0.0);
					brep._inners[i - 1][j].planeAlreadySet = _inners[i - 1][j].planeAlreadySet;
					brep._inners[i - 1][j].plane = (Plane)(_inners[i - 1][j].plane?.Clone());
				}
			}
		}
		bool[] _0023_003Dz4sg0Qp0_003D = new bool[brep._edges.Length];
		for (int k = 0; k < brep._edges.Length; k++)
		{
			Edge edge = brep._edges[k];
			if (_0023_003Dz4sg0Qp0_003D[k] || !edge._0023_003Dz1f9A6PoNLtVGII_0024I6g_003D_003D(brep._faces, out var _0023_003DzMZraMbGvi3oMygJvBw_003D_003D, brep._inners))
			{
				continue;
			}
			Face face = brep._faces[edge.Parents[0]];
			bool flag = false;
			int l;
			if (face != null)
			{
				ICurve curve = brep._edges[k].Curve;
				flag = face.Surface._0023_003DziYlx1Dzq9Zgl(curve, out l);
			}
			if (flag)
			{
				continue;
			}
			_0023_003Dz4sg0Qp0_003D[k] = true;
			_0023_003DzzRLVd6CqM2bZhmKGqA_003D_003D++;
			((Vertex)brep._vertices[edge.StartPointIndex])._0023_003DznS097uo_003D(k);
			((Vertex)brep._vertices[edge.EndPointIndex])._0023_003DznS097uo_003D(k);
			int num = edge.Parents[0];
			int num2 = edge.Parents[1];
			Face face2 = ((edge.ShellIndex == 0) ? brep._faces[num] : brep._inners[edge.ShellIndex - 1][num]);
			Face face3 = ((edge.ShellIndex == 0) ? brep._faces[num2] : brep._inners[edge.ShellIndex - 1][num2]);
			if (face2 != null && face2.planeAlreadySet && face2.plane == null)
			{
				int num3 = -1;
				bool flag2 = true;
				HashSet<int> hashSet = new HashSet<int>();
				OrientedEdge[] segments = face2.Loops[0].Segments;
				for (l = 0; l < segments.Length; l++)
				{
					OrientedEdge orientedEdge = segments[l];
					ICurve curve2 = brep._edges[orientedEdge.CurveIndex].Curve;
					if (face2.Surface._0023_003DziYlx1Dzq9Zgl(curve2, out var _0023_003DzmnVJyP415JCd))
					{
						hashSet.Add(_0023_003DzmnVJyP415JCd);
					}
				}
				if (face2.Surface is ToroidalSurf)
				{
					if (hashSet.Contains(0) && hashSet.Contains(1))
					{
						flag2 = false;
					}
				}
				else if (face2.Surface is CylindricalSurf && hashSet.Count >= 1)
				{
					flag2 = false;
				}
				segments = face2.Loops[0].Segments;
				for (l = 0; l < segments.Length; l++)
				{
					OrientedEdge orientedEdge2 = segments[l];
					if (orientedEdge2.CurveIndex == k)
					{
						continue;
					}
					ICurve curve3 = brep._edges[orientedEdge2.CurveIndex].Curve;
					Plane plane = new Plane(((PlanarSurf)face2.Surface).Plane.Origin, ((PlanarSurf)face2.Surface).Plane.AxisX, ((PlanarSurf)face2.Surface).Plane.AxisZ);
					if ((!(curve3 is Circle) || (!(face2.Surface is ToroidalSurf) && !(face2.Surface is SphericalSurf))) && (!(curve3 is Line) || !(face2.Surface is CylindricalSurf)))
					{
						continue;
					}
					int _0023_003DzmnVJyP415JCd3;
					if (face2.Surface._0023_003DziYlx1Dzq9Zgl(curve3, out var _0023_003DzmnVJyP415JCd2))
					{
						if ((num3 != -1 && num3 != _0023_003DzmnVJyP415JCd2) || typeof(ToroidalSurf) != face2.Surface.GetType())
						{
							break;
						}
						num3 = _0023_003DzmnVJyP415JCd2;
					}
					else if (face2.Surface._0023_003Dzp2cxcSDr1evr(curve3, out _0023_003DzmnVJyP415JCd3) && _0023_003DzmnVJyP415JCd3 != num3 && flag2)
					{
						Point3D p = ((PlanarSurf)face2.Surface).Plane.PointAt(((PlanarSurf)face2.Surface).Plane.Project(curve3.StartPoint));
						Vector3D vector3D = new Vector3D(plane.Origin, p);
						vector3D.Normalize();
						Plane destinationFrame;
						if (curve3 is PlanarEntity && vector3D.IsZero)
						{
							vector3D = ((PlanarEntity)curve3).Plane.AxisX;
							destinationFrame = ((PlanarEntity)curve3).Plane;
						}
						else
						{
							destinationFrame = new Plane(plane.Origin, vector3D, Vector3D.Cross(((PlanarSurf)face2.Surface).Plane.AxisZ, vector3D));
						}
						Align3D align3D = new Align3D(((PlanarSurf)face2.Surface).Plane, destinationFrame);
						face2.Surface.TransformBy(align3D);
						ICurve curve4 = brep._edges[k].Curve;
						if (face2.Surface._0023_003DziYlx1Dzq9Zgl(curve4, out var _))
						{
							align3D.Invert();
							face2.Surface.TransformBy(align3D);
						}
					}
				}
			}
			if (!brep._0023_003Dzi_0FdNNYyhVe(face2, face3, num, num2, ref _0023_003Dz4sg0Qp0_003D, ref _0023_003DzzRLVd6CqM2bZhmKGqA_003D_003D))
			{
				continue;
			}
			if (num != num2)
			{
				if (!_0023_003DzMZraMbGvi3oMygJvBw_003D_003D && face2.Sense != face3.Sense && !_0023_003DzLIjXjp_o6_q1CrV2Qb43N44hOLYJ(brep, face2, num))
				{
					face2.Sense = face3.Sense;
				}
				if (edge.ShellIndex == 0)
				{
					brep._faces[num2] = null;
				}
				else
				{
					brep._inners[edge.ShellIndex - 1][num2] = null;
				}
				array[edge.ShellIndex]++;
			}
			array2[edge.ShellIndex][num2] = num;
		}
		int num4 = brep._0023_003DzcXqsW5xVLz8J(null, _0023_003DzEuQ72GKNmfZl: false);
		if (num4 == -1)
		{
			return -1;
		}
		_0023_003DzzRLVd6CqM2bZhmKGqA_003D_003D += num4;
		brep._0023_003DzxW3N3i886iwK(_0023_003Dz4sg0Qp0_003D, array2, _0023_003DzzRLVd6CqM2bZhmKGqA_003D_003D, array);
		_vertices = brep.Vertices;
		_edges = brep.Edges;
		_faces = brep.Faces;
		_inners = brep._inners;
		RegenMode = regenType.RegenAndCompile;
		return array.Sum();
	}

	private void _0023_003DzxW3N3i886iwK(bool[] _0023_003Dz4sg0Qp0_003D, int[][] _0023_003DzXZwOMC0_003D, int _0023_003DzzRLVd6CqM2bZhmKGqA_003D_003D, int[] _0023_003DzZFo9uOBV2PZx)
	{
		List<Point3D> list = new List<Point3D>(_vertices.Length);
		int num = 0;
		for (int i = 0; i < _vertices.Length; i++)
		{
			Vertex vertex = (Vertex)_vertices[i];
			if (vertex == null || vertex.Parents == null || vertex.Parents.Length == 0)
			{
				num++;
				continue;
			}
			int _0023_003Dze38fBl8CXMMIjCl2bg_003D_003D = i - num;
			list.Add(vertex);
			int[] parents = vertex.Parents;
			foreach (int num2 in parents)
			{
				if (num2 != -1 && _edges[num2] != null)
				{
					_edges[num2]._0023_003DzZ5fgum2m7AI_0024(i, _0023_003Dze38fBl8CXMMIjCl2bg_003D_003D);
				}
			}
		}
		List<Edge> list2 = new List<Edge>(_edges.Length - _0023_003DzzRLVd6CqM2bZhmKGqA_003D_003D);
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		int num3 = 0;
		for (int k = 0; k < _edges.Length; k++)
		{
			if ((_0023_003Dz4sg0Qp0_003D != null && _0023_003Dz4sg0Qp0_003D[k]) || _edges[k] == null || _edges[k].Parents == null)
			{
				num3++;
				continue;
			}
			int num4 = k - num3;
			list2.Add(_edges[k]);
			list2[num4].Curve.EdgeIndex = num4;
			((Vertex)list[list2[num4].StartPointIndex])._0023_003Dz8hR_kalXOG3N(k, num4);
			((Vertex)list[list2[num4].EndPointIndex])._0023_003Dz8hR_kalXOG3N(k, num4);
			dictionary.Add(k, num4);
			for (int l = 0; l < list2[num4].Parents.Length; l++)
			{
				int shellIndex = list2[num4].ShellIndex;
				Face face = ((shellIndex == 0) ? _faces[list2[num4].Parents[l]] : _inners[shellIndex - 1][list2[num4].Parents[l]]);
				if (_0023_003DzXZwOMC0_003D != null)
				{
					while (face == null)
					{
						list2[num4].Parents[l] = _0023_003DzXZwOMC0_003D[list2[num4].ShellIndex][list2[num4].Parents[l]];
						face = ((shellIndex == 0) ? _faces[list2[num4].Parents[l]] : _inners[shellIndex - 1][list2[num4].Parents[l]]);
					}
				}
				int num5 = _edges[k].Parents[l];
				face = ((shellIndex == 0) ? _faces[num5] : _inners[shellIndex - 1][num5]);
				face._0023_003Dz_vlEt0lxdtIt(k, num4, _0023_003Dz4UI1QTK0IxO2yG_zkA_003D_003D: false);
			}
		}
		List<Face> list3 = new List<Face>(_faces.Length - ((_0023_003DzZFo9uOBV2PZx != null) ? _0023_003DzZFo9uOBV2PZx[0] : 0));
		int num6 = 0;
		for (int m = 0; m < _faces.Length; m++)
		{
			if (_faces[m] == null)
			{
				continue;
			}
			list3.Add(_faces[m]);
			if (num6 != m)
			{
				for (int n = 0; n < _faces[m].Loops.Length; n++)
				{
					for (int num7 = 0; num7 < _faces[m].Loops[n].Segments.Length; num7++)
					{
						list2[_faces[m].Loops[n].Segments[num7].CurveIndex]._0023_003Dz8hR_kalXOG3N(m, num6);
					}
				}
			}
			list3[num6]._0023_003Dzu_VTP2T_2LTBmaxiiTgVZUs_003D(dictionary, _rebuildTol, _0023_003DzvsFKDVZyhE_Q: false);
			num6++;
		}
		Face[][] array = new Face[_inners.Length][];
		for (int num8 = 0; num8 < array.Length; num8++)
		{
			num6 = 0;
			List<Face> list4 = new List<Face>(_inners[num8].Length);
			for (int num9 = 0; num9 < _inners[num8].Length; num9++)
			{
				if (_inners[num8][num9] == null)
				{
					continue;
				}
				list4.Add(_inners[num8][num9]);
				if (num6 != num9)
				{
					for (int num10 = 0; num10 < _inners[num8][num9].Loops.Length; num10++)
					{
						for (int num11 = 0; num11 < _inners[num8][num9].Loops[num10].Segments.Length; num11++)
						{
							list2[_inners[num8][num9].Loops[num10].Segments[num11].CurveIndex]._0023_003Dz8hR_kalXOG3N(num9, num6);
						}
					}
				}
				list4[num6]._0023_003Dzu_VTP2T_2LTBmaxiiTgVZUs_003D(dictionary, _rebuildTol, _0023_003DzvsFKDVZyhE_Q: false);
				num6++;
			}
			array[num8] = list4.ToArray();
		}
		_0023_003Dzd55uIPSKitfg(list.ToArray(), list2.ToArray(), list3.ToArray(), array);
	}

	private bool _0023_003DzLIjXjp_o6_q1CrV2Qb43N44hOLYJ(Brep _0023_003DzQ_cEcvVibzBl, Face _0023_003DzAOZ62S0_003D, int _0023_003DzvN_uO6mA3aGN)
	{
		List<Curve> list = new List<Curve>();
		ICurve[] orientedTrimLoops = Faces[_0023_003DzvN_uO6mA3aGN].GetOrientedTrimLoops(Edges);
		for (int i = 0; i < orientedTrimLoops.Length; i++)
		{
			ICurve[] individualCurves = orientedTrimLoops[i].GetIndividualCurves();
			for (int j = 0; j < individualCurves.Length; j++)
			{
				list.Add(individualCurves[j].GetNurbsForm());
			}
		}
		for (int k = 0; k < _0023_003DzAOZ62S0_003D.Loops.Length; k++)
		{
			OrientedEdge[] array = _0023_003DzAOZ62S0_003D.Loops[k]._0023_003DzYcrVfiECm8tMdEgw8nGE7Hg_003D();
			for (int l = 0; l < array.Length; l++)
			{
				OrientedEdge orientedEdge = array[l];
				Point3D startPoint = orientedEdge.GetStartPoint(_0023_003DzQ_cEcvVibzBl.Edges);
				Point3D endPoint = orientedEdge.GetEndPoint(_0023_003DzQ_cEcvVibzBl.Edges);
				bool flag = false;
				bool flag2 = false;
				foreach (Curve item in list)
				{
					if (!flag)
					{
						item.Project(startPoint, out var t);
						if (item.Domain._0023_003DzNoPt9TsyzDMJ(t) && Math.Abs(startPoint.DistanceTo(item.PointAt(t))) < 1E-12)
						{
							flag = true;
						}
					}
					if (!flag2)
					{
						item.Project(endPoint, out var t2);
						if (item.Domain._0023_003DzNoPt9TsyzDMJ(t2) && Math.Abs(endPoint.DistanceTo(item.PointAt(t2))) < 1E-12)
						{
							flag2 = true;
						}
					}
					if (flag && flag2)
					{
						break;
					}
				}
				if (!flag || !flag2)
				{
					return false;
				}
			}
		}
		return true;
	}

	internal bool _0023_003Dzi_0FdNNYyhVe(Face _0023_003DzRVoDPs0_003D, Face _0023_003Dz_0024ozI2Ww_003D, int _0023_003Dz6FmXO74tLDUK, int _0023_003Dzzen3FtVPxXSY, ref bool[] _0023_003Dz4sg0Qp0_003D, ref int _0023_003DzzRLVd6CqM2bZhmKGqA_003D_003D)
	{
		if (_0023_003Dz4sg0Qp0_003D == null)
		{
			_0023_003Dz4sg0Qp0_003D = new bool[_edges.Length];
		}
		if (_0023_003DzRVoDPs0_003D == null || _0023_003Dz_0024ozI2Ww_003D == null)
		{
			return false;
		}
		List<Loop> list = new List<Loop>(1);
		List<OrientedEdge> list2 = new List<OrientedEdge>(_0023_003DzRVoDPs0_003D.Loops[0].Segments.Length);
		int num = -1;
		int num2 = -1;
		bool flag = true;
		bool flag2 = false;
		bool flag3 = false;
		int num3 = -1;
		int num4 = -1;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = -1;
		int num10 = -1;
		int num11 = _0023_003DzRVoDPs0_003D.Loops.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzzQi8_mSrFE1x8McExRVdCUOE8ODc).Sum((Func<OrientedEdge[], int>)_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzetaLymQteT4vni1rPF3jrQwY2h8i) + _0023_003Dz_0024ozI2Ww_003D.Loops.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzP_lVnqneasq2ZiLCMueV6toFC4Zt).Sum((Func<OrientedEdge[], int>)_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzhfnn0wVocKQTjE1q8Lm8Xax3yPAm);
		int num12 = 0;
		do
		{
			num2 = -1;
			int k;
			if (flag || num != -1)
			{
				for (int i = 0; i < _0023_003DzRVoDPs0_003D.Loops.Length; i++)
				{
					if (num7 <= i)
					{
						num7++;
					}
					if (num3 == num4 && flag3)
					{
						list2.Clear();
					}
					OrientedEdge[] array = _0023_003DzRVoDPs0_003D.Loops[i]._0023_003DzYcrVfiECm8tMdEgw8nGE7Hg_003D();
					num5 = 0;
					bool flag4 = true;
					for (int j = 0; j < array.Length; j++)
					{
						OrientedEdge item = array[j];
						if (item.CurveIndex == -1)
						{
							num5++;
						}
						else if (num9 != -1 && i != num9)
						{
							list2.Add(item);
							array[j].CurveIndex = -1;
						}
						else if (item.CurveIndex == num)
						{
							num = -1;
							num9 = i;
							flag = true;
						}
						else
						{
							if (!flag)
							{
								continue;
							}
							if (!_0023_003Dz4sg0Qp0_003D[item.CurveIndex])
							{
								ICurve curve = _edges[item.CurveIndex].Curve;
								bool flag5 = _0023_003DzRVoDPs0_003D.Surface._0023_003DziYlx1Dzq9Zgl(curve, out k);
								if (!(!_edges[item.CurveIndex]._0023_003Dze7d6tSz6lfTYk5LxrA_003D_003D(_0023_003Dz6FmXO74tLDUK, _0023_003Dzzen3FtVPxXSY) || flag5))
								{
									if ((j > 0 && array[j - 1].CurveIndex != -1 && _0023_003Dz4sg0Qp0_003D[array[j - 1].CurveIndex]) || list2.Count == 0)
									{
										num5++;
									}
									_0023_003DzzRLVd6CqM2bZhmKGqA_003D_003D++;
									_0023_003Dz4sg0Qp0_003D[item.CurveIndex] = true;
									((Vertex)_vertices[_edges[item.CurveIndex].StartPointIndex])._0023_003DznS097uo_003D(item.CurveIndex);
									((Vertex)_vertices[_edges[item.CurveIndex].EndPointIndex])._0023_003DznS097uo_003D(item.CurveIndex);
									num2 = item.CurveIndex;
									break;
								}
								list2.Add(item);
								array[j].CurveIndex = -1;
							}
							else if (_edges[item.CurveIndex]._0023_003Dze7d6tSz6lfTYk5LxrA_003D_003D(_0023_003Dz6FmXO74tLDUK, _0023_003Dzzen3FtVPxXSY))
							{
								bool flag6 = false;
								if (_0023_003Dz_0024ozI2Ww_003D.Loops.Length > 1 && _0023_003Dz_0024ozI2Ww_003D.Loops[0].Segments.Length == 1 && _0023_003Dz_0024ozI2Ww_003D.Loops[0]._0023_003DzYcrVfiECm8tMdEgw8nGE7Hg_003D()[0].CurveIndex == item.CurveIndex)
								{
									flag6 = true;
								}
								if ((j <= 0 || array[j - 1].CurveIndex == -1 || !_0023_003Dz4sg0Qp0_003D[array[j - 1].CurveIndex]) && (list2.Count != 0 || list.Count <= 0 || flag6))
								{
									num2 = item.CurveIndex;
									break;
								}
								num5++;
							}
							else
							{
								flag4 = false;
							}
						}
					}
					if (list2.Count > 0)
					{
						OrientedEdge orientedEdge = list2.First();
						OrientedEdge orientedEdge2 = list2.Last();
						num3 = (orientedEdge.Sense ? _edges[orientedEdge.CurveIndex].StartPointIndex : _edges[orientedEdge.CurveIndex].EndPointIndex);
						num4 = (orientedEdge2.Sense ? _edges[orientedEdge2.CurveIndex].EndPointIndex : _edges[orientedEdge2.CurveIndex].StartPointIndex);
						if (num3 == num4)
						{
							flag3 = false;
							bool flag7 = false;
							int[] parents = ((Vertex)_vertices[num3]).Parents;
							for (k = 0; k < parents.Length; k++)
							{
								int num13 = parents[k];
								int l;
								for (l = 0; l < list2.Count && list2[l].CurveIndex != num13; l++)
								{
								}
								if (l >= list2.Count && !_0023_003Dz4sg0Qp0_003D[num13] && (_edges[num13].Parents.Contains(_0023_003Dz6FmXO74tLDUK) || _edges[num13].Parents.Contains(_0023_003Dzzen3FtVPxXSY)))
								{
									flag7 = true;
									break;
								}
							}
							if (!flag7)
							{
								list.Add(new Loop(list2.ToArray()));
								flag3 = true;
							}
						}
					}
					if (flag && num5 < array.Length && flag4)
					{
						i--;
					}
					if (num2 != -1)
					{
						flag2 = false;
						break;
					}
				}
			}
			if (num2 != -1 || flag2 || (num7 == _0023_003DzRVoDPs0_003D.Loops.Length && num8 < _0023_003Dz_0024ozI2Ww_003D.Loops.Length))
			{
				num = -1;
				for (int m = 0; m < _0023_003Dz_0024ozI2Ww_003D.Loops.Length; m++)
				{
					if (num8 <= m)
					{
						num8++;
					}
					if (num3 == num4 && flag3)
					{
						list2.Clear();
					}
					OrientedEdge[] array2 = _0023_003Dz_0024ozI2Ww_003D.Loops[m]._0023_003DzYcrVfiECm8tMdEgw8nGE7Hg_003D();
					num6 = 0;
					for (int n = 0; n < array2.Length; n++)
					{
						OrientedEdge item2 = array2[n];
						if (item2.CurveIndex == -1)
						{
							num6++;
						}
						else if (num10 != -1 && m != num10)
						{
							list2.Add(item2);
							array2[n].CurveIndex = -1;
							if (_edges[item2.CurveIndex].Parents[0] == _0023_003Dzzen3FtVPxXSY)
							{
								_edges[item2.CurveIndex].Parents[0] = _0023_003Dz6FmXO74tLDUK;
							}
							if (_edges[item2.CurveIndex].Parents[1] == _0023_003Dzzen3FtVPxXSY)
							{
								_edges[item2.CurveIndex].Parents[1] = _0023_003Dz6FmXO74tLDUK;
							}
						}
						else if (item2.CurveIndex == num2)
						{
							num2 = -1;
							num10 = m;
							flag2 = true;
						}
						else
						{
							if (!flag2)
							{
								continue;
							}
							if (!_0023_003Dz4sg0Qp0_003D[item2.CurveIndex])
							{
								ICurve curve2 = _edges[item2.CurveIndex].Curve;
								bool flag8 = _0023_003DzRVoDPs0_003D.Surface._0023_003DziYlx1Dzq9Zgl(curve2, out k);
								if (!(!_edges[item2.CurveIndex]._0023_003Dze7d6tSz6lfTYk5LxrA_003D_003D(_0023_003Dz6FmXO74tLDUK, _0023_003Dzzen3FtVPxXSY) || flag8))
								{
									if ((n > 0 && array2[n - 1].CurveIndex != -1 && _0023_003Dz4sg0Qp0_003D[array2[n - 1].CurveIndex]) || (list2.Count == 0 && list.Count > 0))
									{
										num6++;
									}
									_0023_003DzzRLVd6CqM2bZhmKGqA_003D_003D++;
									_0023_003Dz4sg0Qp0_003D[item2.CurveIndex] = true;
									((Vertex)_vertices[_edges[item2.CurveIndex].StartPointIndex])._0023_003DznS097uo_003D(item2.CurveIndex);
									((Vertex)_vertices[_edges[item2.CurveIndex].EndPointIndex])._0023_003DznS097uo_003D(item2.CurveIndex);
									num = item2.CurveIndex;
									break;
								}
								list2.Add(item2);
								array2[n].CurveIndex = -1;
								if (_edges[item2.CurveIndex].Parents[0] == _0023_003Dzzen3FtVPxXSY)
								{
									_edges[item2.CurveIndex].Parents[0] = _0023_003Dz6FmXO74tLDUK;
								}
								if (_edges[item2.CurveIndex].Parents[1] == _0023_003Dzzen3FtVPxXSY)
								{
									_edges[item2.CurveIndex].Parents[1] = _0023_003Dz6FmXO74tLDUK;
								}
							}
							else if (_edges[item2.CurveIndex]._0023_003Dze7d6tSz6lfTYk5LxrA_003D_003D(_0023_003Dz6FmXO74tLDUK, _0023_003Dzzen3FtVPxXSY))
							{
								if ((n <= 0 || array2[n - 1].CurveIndex == -1 || !_0023_003Dz4sg0Qp0_003D[array2[n - 1].CurveIndex]) && list2.Count != 0)
								{
									num = item2.CurveIndex;
									break;
								}
								num6++;
							}
						}
					}
					if (list2.Count > 0)
					{
						OrientedEdge orientedEdge3 = list2.First();
						OrientedEdge orientedEdge4 = list2.Last();
						num3 = (orientedEdge3.Sense ? _edges[orientedEdge3.CurveIndex].StartPointIndex : _edges[orientedEdge3.CurveIndex].EndPointIndex);
						num4 = (orientedEdge4.Sense ? _edges[orientedEdge4.CurveIndex].EndPointIndex : _edges[orientedEdge4.CurveIndex].StartPointIndex);
						if (num3 == num4)
						{
							flag3 = false;
							bool flag9 = false;
							int[] parents = ((Vertex)_vertices[num3]).Parents;
							for (k = 0; k < parents.Length; k++)
							{
								int num14 = parents[k];
								int num15;
								for (num15 = 0; num15 < list2.Count && list2[num15].CurveIndex != num14; num15++)
								{
								}
								if (num15 >= list2.Count && !_0023_003Dz4sg0Qp0_003D[num14] && (_edges[num14].Parents.Contains(_0023_003Dz6FmXO74tLDUK) || _edges[num14].Parents.Contains(_0023_003Dzzen3FtVPxXSY)))
								{
									flag9 = true;
									break;
								}
							}
							if (!flag9)
							{
								list.Add(new Loop(list2.ToArray()));
								flag3 = true;
							}
						}
					}
					if (flag2 && num6 < array2.Length)
					{
						m--;
					}
					if (num != -1)
					{
						flag = false;
						break;
					}
				}
			}
			num12++;
		}
		while ((num3 != num4 || list2.Count > 0 || list.Count == 0 || num7 < _0023_003DzRVoDPs0_003D.Loops.Length || num8 < _0023_003Dz_0024ozI2Ww_003D.Loops.Length || num != -1) && num12 <= num11);
		if (_0023_003DzRVoDPs0_003D.plane != null)
		{
			_0023_003DzRVoDPs0_003D.Surface = new PlanarSurf(_0023_003DzRVoDPs0_003D.plane.Origin, _0023_003DzRVoDPs0_003D.plane.AxisZ, _0023_003DzRVoDPs0_003D.plane.AxisX, _0023_003Dz6FmXO74tLDUK);
			_0023_003DzRVoDPs0_003D.Sense = true;
		}
		_0023_003DzRVoDPs0_003D.Loops = list.ToArray();
		if (list.Count > 1)
		{
			ICurve[] orientedTrimLoops = _0023_003DzRVoDPs0_003D.GetOrientedTrimLoops(_edges);
			int _0023_003Dz_SqBXz8_003D;
			if (_0023_003DzRVoDPs0_003D.plane != null)
			{
				_0023_003Dzh61TpNdk4yJL(orientedTrimLoops, out _0023_003Dz_SqBXz8_003D, _0023_003DzRVoDPs0_003D.plane, _rebuildTol * 10.0);
			}
			else
			{
				_0023_003Dz_SqBXz8_003D = 0;
			}
			_0023_003DzRVoDPs0_003D.Loops[0] = list[_0023_003Dz_SqBXz8_003D];
			int num16 = 1;
			for (int num17 = 0; num17 < list.Count; num17++)
			{
				if (num17 != _0023_003Dz_SqBXz8_003D)
				{
					_0023_003DzRVoDPs0_003D.Loops[num16] = list[num17];
					num16++;
				}
			}
		}
		_0023_003DzRVoDPs0_003D._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(null);
		_0023_003DzRVoDPs0_003D.Tessellation = null;
		_0023_003DzRVoDPs0_003D.Color = _0023_003DzRVoDPs0_003D.Color ?? _0023_003Dz_0024ozI2Ww_003D.Color;
		_0023_003DzRVoDPs0_003D.MaterialName = _0023_003DzRVoDPs0_003D.MaterialName ?? _0023_003Dz_0024ozI2Ww_003D.MaterialName;
		_0023_003DzRVoDPs0_003D.needRebuild = true;
		return true;
	}

	private int _0023_003DzcXqsW5xVLz8J(StringBuilder _0023_003DzqmF8XJ0_003D, bool _0023_003DzEuQ72GKNmfZl)
	{
		int[] array = new int[_edges.Length];
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = -1;
		}
		for (int j = 0; j < _vertices.Length; j++)
		{
			Vertex vertex = (Vertex)_vertices[j];
			if (!vertex._0023_003Dz1f9A6PoNLtVGII_0024I6g_003D_003D(j, _edges, _faces))
			{
				continue;
			}
			int num2 = vertex.Parents[0];
			int num3 = vertex.Parents[1];
			while (_edges[num2] == null)
			{
				num2 = array[num2];
			}
			while (_edges[num3] == null)
			{
				num3 = array[num3];
			}
			Edge edge = _edges[num2];
			Edge edge2 = _edges[num3];
			vertex.Parents = null;
			int startPointIndex = edge.StartPointIndex;
			int endPointIndex = edge.EndPointIndex;
			int num4;
			int num5;
			if (edge.StartPointIndex == j)
			{
				num4 = ((edge2.StartPointIndex == j) ? edge2.EndPointIndex : edge2.StartPointIndex);
				num5 = edge.EndPointIndex;
				edge.StartPointIndex = num4;
				((Vertex)_vertices[num4])._0023_003Dz8hR_kalXOG3N(num3, num2);
			}
			else
			{
				num4 = edge.StartPointIndex;
				num5 = (edge.EndPointIndex = ((edge2.StartPointIndex == j) ? edge2.EndPointIndex : edge2.StartPointIndex));
				((Vertex)_vertices[num5])._0023_003Dz8hR_kalXOG3N(num3, num2);
			}
			ICurve curve;
			if (edge.Curve is Line)
			{
				curve = new Line((Point3D)_vertices[num4].Clone(), (Point3D)_vertices[num5].Clone());
			}
			else if (edge.Curve is Arc)
			{
				Arc arc = (Arc)edge.Curve;
				curve = new Arc(arc.Plane, arc.Center, arc.Radius, _vertices[num4], _vertices[num5], flip: false);
				if (num4 == num5)
				{
					((Arc)curve).Domain = new Interval(curve.Domain.t0, Math.PI * 2.0 + curve.Domain.t0);
				}
			}
			else if (edge.Curve is EllipticalArc)
			{
				EllipticalArc ellipticalArc = (EllipticalArc)edge.Curve;
				curve = new EllipticalArc(ellipticalArc.Plane, ellipticalArc.Center, ellipticalArc.RadiusX, ellipticalArc.RadiusY, _vertices[num4], _vertices[num5], flip: false);
				if (num4 == num5)
				{
					((EllipticalArc)curve).Domain = new Interval(curve.Domain.t0, Math.PI * 2.0 + curve.Domain.t0);
				}
			}
			else
			{
				Curve curve2 = (Curve)edge.Curve;
				Curve curve3 = (Curve)edge2.Curve;
				if (num4 == num5)
				{
					bool flag = num4 != startPointIndex;
					bool flag2 = num5 != endPointIndex;
					if (edge2.StartPointIndex == num4)
					{
						if (flag2)
						{
							curve3.Reverse();
							curve = Curve.Merge(curve2, curve3);
						}
						else
						{
							curve = Curve.Merge(curve3, curve2);
						}
					}
					else if (flag)
					{
						curve3.Reverse();
						curve = Curve.Merge(curve3, curve2);
					}
					else
					{
						curve = Curve.Merge(curve2, curve3);
					}
				}
				else
				{
					List<ICurve> obj = new List<ICurve> { curve2, curve3 };
					Utility.SortAndOrient(obj);
					curve = Curve.Merge(obj);
					double num6 = Point3D.DistanceSquared(curve.StartPoint, _vertices[num4]);
					double num7 = Point3D.DistanceSquared(curve.EndPoint, _vertices[num4]);
					if (Utility.Compare(num6, num7) != 0 && num6 > num7)
					{
						curve.Reverse();
					}
				}
			}
			if (_0023_003DzqmF8XJ0_003D != null)
			{
				string text = curve.GetType().ToString().Split('.')
					.Last();
				_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959205), num2, num3, text, j));
			}
			edge.Curve = curve;
			_edges[num3] = null;
			num++;
			array[num3] = num2;
		}
		bool[] array2 = new bool[_edges.Length];
		for (int k = 0; k < _edges.Length; k++)
		{
			if (array2[k])
			{
				continue;
			}
			int num8 = k;
			int num9 = 0;
			while (array[num8] != -1)
			{
				num9++;
				array2[num8] = true;
				num8 = array[num8];
			}
			if (num9 == 0)
			{
				continue;
			}
			Edge edge3 = _edges[num8];
			for (int l = 0; l < edge3.Parents.Length; l++)
			{
				Face face = ((edge3.ShellIndex == 0) ? _faces[edge3.Parents[l]] : _inners[edge3.ShellIndex - 1][edge3.Parents[l]]);
				face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(null);
				face.needRebuild = true;
				for (int m = 0; m < face.Loops.Length; m++)
				{
					List<OrientedEdge> list = face.Loops[m].Segments.ToList();
					for (int num10 = list.Count - 1; num10 >= 0; num10--)
					{
						if (_edges[list[num10].CurveIndex] == null)
						{
							list.RemoveAt(num10);
						}
						else
						{
							array2[list[num10].CurveIndex] = true;
						}
					}
					face.Loops[m].Segments = list.ToArray();
				}
			}
		}
		if (_0023_003DzEuQ72GKNmfZl)
		{
			_0023_003DzxW3N3i886iwK(null, null, num, null);
			RegenMode = regenType.RegenAndCompile;
		}
		return num;
	}

	internal static void _0023_003Dzh61TpNdk4yJL(ICurve[] _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, out int _0023_003Dz_SqBXz8_003D, Plane _0023_003Dzrgqz890sj_0024X9, double _0023_003DzQ2_0024_99rGAke6)
	{
		_0023_003Dz_SqBXz8_003D = -1;
		Point2D[][] array = new Point2D[_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Length][];
		for (int i = 0; i < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Length; i++)
		{
			ICurve curve = _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[i];
			((Entity)curve).Regen(_0023_003DzQ2_0024_99rGAke6);
			array[i] = new Point2D[((Entity)curve).Vertices.Length];
			for (int j = 0; j < ((Entity)curve).Vertices.Length; j++)
			{
				array[i][j] = _0023_003Dzrgqz890sj_0024X9.Project(((Entity)curve).Vertices[j]);
			}
			if (Utility.PointInPolygon(_0023_003Dzrgqz890sj_0024X9.Project(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[(i + 1) % _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Length].StartPoint), array[i]))
			{
				_0023_003Dz_SqBXz8_003D = i;
				break;
			}
		}
	}

	internal int _0023_003DzLCTQ3rz_P4Wm(OrientedEdge _0023_003DzKm2q1fi2Z68M_0024_5T6A_003D_003D, int _0023_003DzpKx72ZfGKVdp, List<Edge> _0023_003DzVyFgxRzS_Yz8, List<Edge> _0023_003DzViGQVPM_003D, List<int> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, Dictionary<int, int> _0023_003DzQtyBAo4gFsZY, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, Dictionary<int, int> _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, Surface _0023_003DzF7GfYSI_003D, List<OrientedEdge> _0023_003DzP8sh_0024RnTCuDmlMKpiw_003D_003D, int _0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D, int _0023_003DzPpTz1gk_003D)
	{
		int num = -1;
		bool _0023_003DzhWkkZUdwNlwFcLySIQ_003D_003D = false;
		Edge _0023_003DzXQ05_0024cQM5wVN = _0023_003DzVyFgxRzS_Yz8[_0023_003DzpKx72ZfGKVdp];
		SplitEdgeStatus splitStatus = _0023_003DzXQ05_0024cQM5wVN.SplitStatus;
		TrimCurve trimCurve = (TrimCurve)((_0023_003DzF7GfYSI_003D.Trimming.ContourList[_0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D] is CompositeCurve) ? ((CompositeCurve)_0023_003DzF7GfYSI_003D.Trimming.ContourList[_0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D]).CurveList[_0023_003DzPpTz1gk_003D] : _0023_003DzF7GfYSI_003D.Trimming.ContourList[_0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D]);
		TrimCurve _0023_003Dz_0024KG_KlTLOjdx = (TrimCurve)trimCurve.Clone();
		double num2 = Math.Min(RebuildTolerance, Edges[_0023_003DzKm2q1fi2Z68M_0024_5T6A_003D_003D.CurveIndex].Curve.Length() / 100.0);
		List<ICurve> list = _0023_003DzF7GfYSI_003D.Trimming.ContourList[_0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D].GetIndividualCurves().ToList();
		switch (splitStatus)
		{
		case SplitEdgeStatus.NeedToTrim:
			num = _0023_003DzUGnDRo3eVm3pt4_33A_003D_003D(_0023_003Dz_0024KG_KlTLOjdx, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, _0023_003DzQtyBAo4gFsZY, _0023_003DzVyFgxRzS_Yz8, _0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, num2, ref _0023_003DzpKx72ZfGKVdp, ref _0023_003DzXQ05_0024cQM5wVN);
			if (num == -1)
			{
				if (!_0023_003DzVpPOFMXqWVaoPGRXMQ_003D_003D(_0023_003DzVyFgxRzS_Yz8, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, _0023_003DzPpTz1gk_003D, _0023_003DzF7GfYSI_003D, list, _0023_003DzWkEiu3E_003D: false, ref _0023_003Dz_0024KG_KlTLOjdx, ref _0023_003DzhWkkZUdwNlwFcLySIQ_003D_003D))
				{
					return -1;
				}
				num = _0023_003DzUGnDRo3eVm3pt4_33A_003D_003D(_0023_003Dz_0024KG_KlTLOjdx, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, _0023_003DzQtyBAo4gFsZY, _0023_003DzVyFgxRzS_Yz8, _0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, num2, ref _0023_003DzpKx72ZfGKVdp, ref _0023_003DzXQ05_0024cQM5wVN);
			}
			break;
		case SplitEdgeStatus.NotAssigned:
		case SplitEdgeStatus.Included:
		case SplitEdgeStatus.OnBothEdges:
			_0023_003DzXQ05_0024cQM5wVN.SplitStatus = ((_0023_003DzXQ05_0024cQM5wVN.SplitStatus == SplitEdgeStatus.NotAssigned) ? SplitEdgeStatus.Included : _0023_003DzXQ05_0024cQM5wVN.SplitStatus);
			num = ((!_0023_003DzKm2q1fi2Z68M_0024_5T6A_003D_003D.Sense) ? _0023_003DzdV7MwsVvednZlOLTTHVUrBw_003D(_0023_003DzpKx72ZfGKVdp, _0023_003DzViGQVPM_003D, _0023_003DzQtyBAo4gFsZY, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, _0023_003DzXQ05_0024cQM5wVN, num2) : _0023_003Dz2dxuReVyljdwHKUQ9KVDCNI_003D(_0023_003DzpKx72ZfGKVdp, _0023_003DzViGQVPM_003D, _0023_003DzQtyBAo4gFsZY, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, _0023_003DzXQ05_0024cQM5wVN, num2));
			break;
		case SplitEdgeStatus.EndToVertex:
			num = _0023_003Dz2dxuReVyljdwHKUQ9KVDCNI_003D(_0023_003DzpKx72ZfGKVdp, _0023_003DzViGQVPM_003D, _0023_003DzQtyBAo4gFsZY, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, _0023_003DzXQ05_0024cQM5wVN, num2);
			break;
		case SplitEdgeStatus.StartFromVertex:
			num = _0023_003DzdV7MwsVvednZlOLTTHVUrBw_003D(_0023_003DzpKx72ZfGKVdp, _0023_003DzViGQVPM_003D, _0023_003DzQtyBAo4gFsZY, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, _0023_003DzXQ05_0024cQM5wVN, num2);
			break;
		case SplitEdgeStatus.MiddleSubEdge:
			num = _0023_003Dz6A93Hs8hjj1BFaemBA_003D_003D(_0023_003DzpKx72ZfGKVdp, _0023_003DzViGQVPM_003D, _0023_003DzQtyBAo4gFsZY, _0023_003DzXQ05_0024cQM5wVN, num2);
			break;
		case SplitEdgeStatus.NewEdge:
			num = _0023_003DzQtyBAo4gFsZY[_0023_003DzpKx72ZfGKVdp];
			break;
		}
		if (num == -1)
		{
			return -1;
		}
		_0023_003DzVyFgxRzS_Yz8[_0023_003DzpKx72ZfGKVdp].Visited = true;
		double num3 = Point3D.Distance(trimCurve.Edge.StartPoint, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzViGQVPM_003D[num].StartPointIndex]);
		double num4 = Point3D.Distance(trimCurve.Edge.StartPoint, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzViGQVPM_003D[num].EndPointIndex]);
		bool sense = num3 < num4 + num2 && Vector3D.Dot(trimCurve.Edge.StartTangent, _0023_003DzViGQVPM_003D[num].Curve.StartTangent) > 0.0;
		OrientedEdge item = new OrientedEdge(num, sense);
		_0023_003DzP8sh_0024RnTCuDmlMKpiw_003D_003D.Add(item);
		trimCurve.EdgeIndex = num;
		_0023_003Dz_0024KG_KlTLOjdx.EdgeIndex = num;
		trimCurve.Edge.EdgeIndex = num;
		_0023_003Dz_0024KG_KlTLOjdx.Edge.EdgeIndex = num;
		if (_0023_003DzhWkkZUdwNlwFcLySIQ_003D_003D)
		{
			int count = list.Count;
			ICurve[] array = new ICurve[count];
			for (int i = 0; i < count; i++)
			{
				Entity entity = (Entity)list[i].Clone();
				entity.TranslationID = ((Entity)list[i]).TranslationID;
				((ICurve)entity).EdgeIndex = list[i].EdgeIndex;
				((ICurve)entity).FromBooleanIntersection = list[i].FromBooleanIntersection;
				array[i] = (ICurve)entity;
			}
			_0023_003DzF7GfYSI_003D.Trimming.ContourList[_0023_003DzoS5gZ6aHl0_0024ZratZpw_003D_003D] = Utility.SmartAdd(array);
		}
		return _0023_003DzhWkkZUdwNlwFcLySIQ_003D_003D ? 1 : 0;
	}

	private static bool _0023_003DzVpPOFMXqWVaoPGRXMQ_003D_003D(List<Edge> _0023_003DzVyFgxRzS_Yz8, List<int> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, int _0023_003DzPpTz1gk_003D, Surface _0023_003DzF7GfYSI_003D, List<ICurve> _0023_003DzpIZC_0024x5EiUBN, bool _0023_003DzWkEiu3E_003D, ref TrimCurve _0023_003Dz_0024KG_KlTLOjdx, ref bool _0023_003DzhWkkZUdwNlwFcLySIQ_003D_003D)
	{
		if (_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D == null || _0023_003DzPpTz1gk_003D == -1)
		{
			return false;
		}
		ICurve curve = null;
		List<double> list = new List<double>();
		List<double> list2 = new List<double>();
		bool flag = false;
		for (int i = 0; i < _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D.Count; i++)
		{
			int index = _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D[i];
			Point3D endPoint = _0023_003DzVyFgxRzS_Yz8[index].Curve.EndPoint;
			_0023_003Dz_0024KG_KlTLOjdx.Edge.Project(endPoint, out var t);
			if (!flag && list.Count > 0 && t < list[0])
			{
				flag = true;
			}
			if (!_0023_003Dz_0024KG_KlTLOjdx.Edge.Domain.Includes(t, testOpenInterval: true) || Utility.AreEqual(t, _0023_003Dz_0024KG_KlTLOjdx.Edge.Domain.Low, _0023_003Dz_0024KG_KlTLOjdx.Edge.Domain.Length) || Utility.AreEqual(t, _0023_003Dz_0024KG_KlTLOjdx.Edge.Domain.High, _0023_003Dz_0024KG_KlTLOjdx.Edge.Domain.Length))
			{
				continue;
			}
			_0023_003DzF7GfYSI_003D.Project(endPoint, out var proj);
			_0023_003Dz_0024KG_KlTLOjdx.Project(new Point3D(proj.X, proj.Y, 0.0), out var t2);
			if (_0023_003Dz_0024KG_KlTLOjdx.Domain.Includes(t2, testOpenInterval: true) && !Utility.AreEqual(t2, _0023_003Dz_0024KG_KlTLOjdx.Domain.Low, _0023_003Dz_0024KG_KlTLOjdx.Domain.Length) && !Utility.AreEqual(t2, _0023_003Dz_0024KG_KlTLOjdx.Domain.High, _0023_003Dz_0024KG_KlTLOjdx.Domain.Length))
			{
				if (flag)
				{
					list.Insert(0, t);
					list2.Insert(0, t2);
				}
				else
				{
					list.Add(t);
					list2.Add(t2);
				}
				_0023_003DzhWkkZUdwNlwFcLySIQ_003D_003D = true;
			}
		}
		if (!_0023_003DzhWkkZUdwNlwFcLySIQ_003D_003D)
		{
			return false;
		}
		List<ICurve> list3 = new List<ICurve>();
		List<ICurve> list4 = new List<ICurve>();
		Utility._0023_003DzftzqUl9H6tLy(_0023_003Dz_0024KG_KlTLOjdx.Edge, list, list3);
		Utility._0023_003DzftzqUl9H6tLy(_0023_003Dz_0024KG_KlTLOjdx, list2, list4);
		if (list4.Count != list3.Count)
		{
			return false;
		}
		for (int j = 0; j < list4.Count; j++)
		{
			int edgeIndex = ((!_0023_003DzWkEiu3E_003D) ? _0023_003Dz_0024KG_KlTLOjdx.EdgeIndex : (flag ? _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D[_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D.Count - j - 1] : _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D[j]));
			list4[j] = ((Curve)list4[j])._0023_003DzmGgqdRaHiXdg(list3[j]);
			list3[j].EdgeIndex = edgeIndex;
			list4[j].EdgeIndex = edgeIndex;
			if (j == 0)
			{
				_0023_003DzpIZC_0024x5EiUBN[_0023_003DzPpTz1gk_003D] = list4[j];
				curve = _0023_003DzpIZC_0024x5EiUBN[_0023_003DzPpTz1gk_003D];
				list3[j].EdgeIndex = (flag ? _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D[_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D.Count - j - 1] : _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D[j]);
				list4[j].EdgeIndex = (flag ? _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D[_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D.Count - j - 1] : _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D[j]);
			}
			else
			{
				_0023_003DzpIZC_0024x5EiUBN.Insert(_0023_003DzPpTz1gk_003D + j, list4[j]);
			}
		}
		if (curve != null)
		{
			_0023_003Dz_0024KG_KlTLOjdx = (TrimCurve)curve;
			return true;
		}
		return false;
	}

	private int _0023_003DzUGnDRo3eVm3pt4_33A_003D_003D(TrimCurve _0023_003Dz_0024KG_KlTLOjdx, List<int> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, Dictionary<int, int> _0023_003DzQtyBAo4gFsZY, List<Edge> _0023_003DzVyFgxRzS_Yz8, List<Edge> _0023_003DzViGQVPM_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, Dictionary<int, int> _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, ref int _0023_003DzpKx72ZfGKVdp, ref Edge _0023_003DzXQ05_0024cQM5wVN)
	{
		int num = -1;
		foreach (int item in _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D)
		{
			Edge edge = _0023_003DzVyFgxRzS_Yz8[item];
			double val = _0023_003DzuMKQhOieejyEvhtVOw_003D_003D / (Math.Min(edge.Curve.Length(), _0023_003Dz_0024KG_KlTLOjdx.Edge.Length()) * 0.001);
			val = Math.Max(Utility._0023_003DzxhnLabVjXjPg, Math.Min(val, 1.0));
			if (Utility._0023_003DzZCuAc1AnKVueDa_Q8w_003D_003D(edge.Curve, _0023_003Dz_0024KG_KlTLOjdx.Edge, out var _, val) == 0)
			{
				_0023_003DzXQ05_0024cQM5wVN = edge;
				_0023_003DzpKx72ZfGKVdp = item;
				if (edge.SplitStatus == SplitEdgeStatus.StartFromVertex)
				{
					num = _0023_003DzdV7MwsVvednZlOLTTHVUrBw_003D(_0023_003DzpKx72ZfGKVdp, _0023_003DzViGQVPM_003D, _0023_003DzQtyBAo4gFsZY, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, _0023_003DzXQ05_0024cQM5wVN, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
					_0023_003DzcqZ3vGPD0SLG(_0023_003DzViGQVPM_003D[num].StartPointIndex, item, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D);
				}
				if (edge.SplitStatus == SplitEdgeStatus.EndToVertex)
				{
					num = _0023_003Dz2dxuReVyljdwHKUQ9KVDCNI_003D(_0023_003DzpKx72ZfGKVdp, _0023_003DzViGQVPM_003D, _0023_003DzQtyBAo4gFsZY, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, _0023_003DzXQ05_0024cQM5wVN, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
					_0023_003DzcqZ3vGPD0SLG(_0023_003DzViGQVPM_003D[num].EndPointIndex, item, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D);
				}
				if (edge.SplitStatus == SplitEdgeStatus.MiddleSubEdge)
				{
					num = _0023_003Dz6A93Hs8hjj1BFaemBA_003D_003D(_0023_003DzpKx72ZfGKVdp, _0023_003DzViGQVPM_003D, _0023_003DzQtyBAo4gFsZY, _0023_003DzXQ05_0024cQM5wVN, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
				}
			}
		}
		return num;
	}

	private static void _0023_003DzcqZ3vGPD0SLG(int _0023_003DzyzK8swU_003D, int _0023_003Dzx3lGMHmK_xtn3wmq6w_003D_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, List<int> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D)
	{
		int[] parents = ((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzyzK8swU_003D]).Parents;
		if (parents == null)
		{
			return;
		}
		for (int i = 0; i < _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D.Count; i++)
		{
			if (_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D[i] != _0023_003Dzx3lGMHmK_xtn3wmq6w_003D_003D)
			{
				int num = Array.IndexOf(parents, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D[i]);
				if (num != -1)
				{
					parents[num] = _0023_003Dzx3lGMHmK_xtn3wmq6w_003D_003D;
				}
			}
		}
	}

	private int _0023_003Dz6A93Hs8hjj1BFaemBA_003D_003D(int _0023_003DzpKx72ZfGKVdp, List<Edge> _0023_003DzViGQVPM_003D, Dictionary<int, int> _0023_003DzQtyBAo4gFsZY, Edge _0023_003DzXQ05_0024cQM5wVN, double _0023_003DzJcx6KHbkVhi_0024)
	{
		int num;
		if (!_0023_003DzQtyBAo4gFsZY.TryGetValue(_0023_003DzpKx72ZfGKVdp, out var value))
		{
			num = _0023_003DzbIDY9BOTPqfc(new Edge(_0023_003DzXQ05_0024cQM5wVN.Curve, _0023_003DzXQ05_0024cQM5wVN.StartPointIndex, _0023_003DzXQ05_0024cQM5wVN.EndPointIndex), _0023_003DzViGQVPM_003D, _0023_003DzJcx6KHbkVhi_0024, null, null);
			_0023_003DzQtyBAo4gFsZY.Add(_0023_003DzpKx72ZfGKVdp, num);
		}
		else
		{
			num = value;
		}
		return num;
	}

	private int _0023_003DzdV7MwsVvednZlOLTTHVUrBw_003D(int _0023_003DzpKx72ZfGKVdp, List<Edge> _0023_003DzViGQVPM_003D, Dictionary<int, int> _0023_003DzQtyBAo4gFsZY, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, Dictionary<int, int> _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, Edge _0023_003DzXQ05_0024cQM5wVN, double _0023_003DzJcx6KHbkVhi_0024)
	{
		int num;
		if (!_0023_003DzQtyBAo4gFsZY.TryGetValue(_0023_003DzpKx72ZfGKVdp, out var value))
		{
			Edge edge = (Edge)_0023_003DzXQ05_0024cQM5wVN.Clone();
			edge.StartPointIndex = _0023_003DzeapIrHLtVxHU(_0023_003DzXQ05_0024cQM5wVN.StartPointIndex, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, _0023_003DzJcx6KHbkVhi_0024);
			if (_0023_003DzXQ05_0024cQM5wVN.SplitStatus != SplitEdgeStatus.StartFromVertex)
			{
				edge.EndPointIndex = _0023_003DzeapIrHLtVxHU(_0023_003DzXQ05_0024cQM5wVN.EndPointIndex, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, _0023_003DzJcx6KHbkVhi_0024);
			}
			edge.Parents = null;
			num = _0023_003DzbIDY9BOTPqfc(edge, _0023_003DzViGQVPM_003D, _0023_003DzJcx6KHbkVhi_0024, null, null);
			_0023_003DzQtyBAo4gFsZY.Add(_0023_003DzpKx72ZfGKVdp, num);
		}
		else
		{
			num = value;
		}
		return num;
	}

	private int _0023_003Dz2dxuReVyljdwHKUQ9KVDCNI_003D(int _0023_003DzpKx72ZfGKVdp, List<Edge> _0023_003DzViGQVPM_003D, Dictionary<int, int> _0023_003DzQtyBAo4gFsZY, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, Dictionary<int, int> _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, Edge _0023_003DzXQ05_0024cQM5wVN, double _0023_003DzJcx6KHbkVhi_0024)
	{
		int num;
		if (!_0023_003DzQtyBAo4gFsZY.TryGetValue(_0023_003DzpKx72ZfGKVdp, out var value))
		{
			Edge edge = (Edge)_0023_003DzXQ05_0024cQM5wVN.Clone();
			edge.EndPointIndex = _0023_003DzeapIrHLtVxHU(_0023_003DzXQ05_0024cQM5wVN.EndPointIndex, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, _0023_003DzJcx6KHbkVhi_0024);
			if (_0023_003DzXQ05_0024cQM5wVN.SplitStatus != SplitEdgeStatus.EndToVertex)
			{
				edge.StartPointIndex = _0023_003DzeapIrHLtVxHU(_0023_003DzXQ05_0024cQM5wVN.StartPointIndex, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, _0023_003DzJcx6KHbkVhi_0024);
			}
			edge.Parents = null;
			num = _0023_003DzbIDY9BOTPqfc(edge, _0023_003DzViGQVPM_003D, _0023_003DzJcx6KHbkVhi_0024, null, null);
			_0023_003DzQtyBAo4gFsZY.Add(_0023_003DzpKx72ZfGKVdp, num);
		}
		else
		{
			num = value;
		}
		return num;
	}

	private static int _0023_003DzbIDY9BOTPqfc(Edge _0023_003DzXQ05_0024cQM5wVN, List<Edge> _0023_003DzViGQVPM_003D, double _0023_003Dz85DwsjHHsAwG, StringBuilder _0023_003DzqmF8XJ0_003D, List<int> _0023_003DzJQdiRnsfMhPS)
	{
		int num = -1;
		bool flag = false;
		Point3D point3D = _0023_003DzXQ05_0024cQM5wVN.Curve.PointAt(_0023_003DzXQ05_0024cQM5wVN.Curve.Domain.Mid);
		for (int i = 0; i < _0023_003DzViGQVPM_003D.Count; i++)
		{
			if (_0023_003DzViGQVPM_003D[i] != null && ((_0023_003DzViGQVPM_003D[i].StartPointIndex == _0023_003DzXQ05_0024cQM5wVN.StartPointIndex && _0023_003DzViGQVPM_003D[i].EndPointIndex == _0023_003DzXQ05_0024cQM5wVN.EndPointIndex) || (_0023_003DzViGQVPM_003D[i].StartPointIndex == _0023_003DzXQ05_0024cQM5wVN.EndPointIndex && _0023_003DzViGQVPM_003D[i].EndPointIndex == _0023_003DzXQ05_0024cQM5wVN.StartPointIndex)))
			{
				_0023_003DzViGQVPM_003D[i].Curve.ClosestPointTo(point3D, out var t);
				if (Point3D.DistanceSquared(point3D, _0023_003DzViGQVPM_003D[i].Curve.PointAt(t)) < _0023_003Dz85DwsjHHsAwG)
				{
					num = i;
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			if (_0023_003DzJQdiRnsfMhPS != null && _0023_003DzJQdiRnsfMhPS.Count > 0)
			{
				foreach (int _0023_003DzJQdiRnsfMhP in _0023_003DzJQdiRnsfMhPS)
				{
					if (_0023_003DzViGQVPM_003D[_0023_003DzJQdiRnsfMhP] == null)
					{
						_0023_003DzViGQVPM_003D[_0023_003DzJQdiRnsfMhP] = _0023_003DzXQ05_0024cQM5wVN;
						num = _0023_003DzJQdiRnsfMhP;
						flag = true;
						_0023_003DzJQdiRnsfMhPS.Remove(_0023_003DzJQdiRnsfMhP);
						break;
					}
				}
			}
			if (!flag)
			{
				num = _0023_003DzViGQVPM_003D.Count;
				_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959148), num));
				_0023_003DzViGQVPM_003D.Add(_0023_003DzXQ05_0024cQM5wVN);
			}
		}
		return num;
	}

	private static int _0023_003DzbIDY9BOTPqfc(Vertex _0023_003DzE3AiSb8DsnXw1dat8Q_003D_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, ref List<int> _0023_003DzJQdiRnsfMhPS)
	{
		int num = -1;
		bool flag = false;
		for (int i = 0; i < _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count; i++)
		{
			if (_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[i] != null && Point3D.DistanceSquared(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[i], _0023_003DzE3AiSb8DsnXw1dat8Q_003D_003D) < _0023_003DzuMKQhOieejyEvhtVOw_003D_003D * _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
			{
				num = i;
				_0023_003DzE3AiSb8DsnXw1dat8Q_003D_003D = (Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num];
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			if (_0023_003DzJQdiRnsfMhPS.Count > 0)
			{
				foreach (int _0023_003DzJQdiRnsfMhP in _0023_003DzJQdiRnsfMhPS)
				{
					if (_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzJQdiRnsfMhP] == null)
					{
						_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzJQdiRnsfMhP] = _0023_003DzE3AiSb8DsnXw1dat8Q_003D_003D;
						num = _0023_003DzJQdiRnsfMhP;
						flag = true;
						_0023_003DzJQdiRnsfMhPS.Remove(_0023_003DzJQdiRnsfMhP);
						break;
					}
				}
			}
			if (!flag)
			{
				num = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count;
				_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(_0023_003DzE3AiSb8DsnXw1dat8Q_003D_003D);
			}
		}
		return num;
	}

	private bool _0023_003DzQ5fDF2jR3C5L0fCEng_003D_003D(int _0023_003DzsMwVBGaGQeZg, List<Face> _0023_003DzUbkxYVFDH3ry, Dictionary<int, List<ICurve>> _0023_003DzNsS6ffzfSlG6, bool _0023_003DzxI_R5dw_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, Dictionary<int, int> _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, List<Edge> _0023_003DzViGQVPM_003D, Dictionary<int, int> _0023_003DzQtyBAo4gFsZY, bool _0023_003Dz0mIPc9VROWxZ)
	{
		if (_0023_003DzNsS6ffzfSlG6.ContainsKey(_0023_003DzsMwVBGaGQeZg) || _faces[_0023_003DzsMwVBGaGQeZg].Visited || _faces[_0023_003DzsMwVBGaGQeZg].hasEdgesToSplit)
		{
			return true;
		}
		SplitEdgeStatus splitEdgeStatus = (_0023_003DzxI_R5dw_003D ? SplitEdgeStatus.Included : SplitEdgeStatus.Discarded);
		Loop[] array = new Loop[_faces[_0023_003DzsMwVBGaGQeZg].Loops.Length];
		for (int i = 0; i < _faces[_0023_003DzsMwVBGaGQeZg].Loops.Length; i++)
		{
			Loop loop = _faces[_0023_003DzsMwVBGaGQeZg].Loops[i];
			OrientedEdge[] array2 = new OrientedEdge[loop.Segments.Length];
			for (int j = 0; j < loop.Segments.Length; j++)
			{
				Edge edge = Edges[loop.Segments[j].CurveIndex];
				if (edge.Visited && edge.SplitStatus != splitEdgeStatus && edge.SplitStatus != SplitEdgeStatus.NewEdge && edge.SplitStatus != SplitEdgeStatus.OnBothEdges)
				{
					return false;
				}
				_faces[_0023_003DzsMwVBGaGQeZg].Visited = true;
				if (_0023_003DzxI_R5dw_003D)
				{
					int num2;
					if (!edge.Visited)
					{
						double num = edge.Curve.Length() * 1E-05;
						int startPointIndex = _0023_003DzeapIrHLtVxHU(edge.StartPointIndex, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, num);
						int endPointIndex = _0023_003DzeapIrHLtVxHU(edge.EndPointIndex, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, num);
						Edge obj = (Edge)edge.Clone();
						obj.StartPointIndex = startPointIndex;
						obj.EndPointIndex = endPointIndex;
						obj.Parents = null;
						num2 = _0023_003DzbIDY9BOTPqfc(obj, _0023_003DzViGQVPM_003D, num, null, null);
						_0023_003DzQtyBAo4gFsZY.Add(loop.Segments[j].CurveIndex, num2);
					}
					else
					{
						num2 = _0023_003DzQtyBAo4gFsZY[loop.Segments[j].CurveIndex];
					}
					Vector3D r;
					double rLen;
					bool flag = Vector3D.AreCoincident(edge.Curve.StartTangent, _0023_003DzViGQVPM_003D[num2].Curve.StartTangent) && Utility.PointCoincidence(edge.Curve.StartPoint.AsVector, _0023_003DzViGQVPM_003D[num2].Curve.StartPoint.AsVector, edge.Curve.Length(), out r, out rLen, Utility._0023_003Dzjyaz_Vfaky9X);
					array2[j] = new OrientedEdge(num2, flag ? loop.Segments[j].Sense : (!loop.Segments[j].Sense));
				}
				edge.Visited = true;
				edge.SplitStatus = ((edge.SplitStatus == SplitEdgeStatus.NotAssigned) ? splitEdgeStatus : edge.SplitStatus);
				if (edge.SplitStatus != SplitEdgeStatus.NewEdge && edge.SplitStatus != SplitEdgeStatus.OnBothEdges)
				{
					if (!_0023_003DzQ5fDF2jR3C5L0fCEng_003D_003D(edge.Parents[0], _0023_003DzUbkxYVFDH3ry, _0023_003DzNsS6ffzfSlG6, _0023_003DzxI_R5dw_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, _0023_003DzViGQVPM_003D, _0023_003DzQtyBAo4gFsZY, _0023_003Dz0mIPc9VROWxZ))
					{
						return false;
					}
					if (edge.Parents.Length > 1 && !_0023_003DzQ5fDF2jR3C5L0fCEng_003D_003D(edge.Parents[1], _0023_003DzUbkxYVFDH3ry, _0023_003DzNsS6ffzfSlG6, _0023_003DzxI_R5dw_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dz2wjxF5y1xC6yiw6CVg_003D_003D, _0023_003DzViGQVPM_003D, _0023_003DzQtyBAo4gFsZY, _0023_003Dz0mIPc9VROWxZ))
					{
						return false;
					}
				}
			}
			array[i] = new Loop(array2, _0023_003Dz0mIPc9VROWxZ ? (!loop.Sense) : loop.Sense);
		}
		if (_0023_003DzxI_R5dw_003D)
		{
			Face face = (Face)_faces[_0023_003DzsMwVBGaGQeZg].Clone();
			face.Sense = (_0023_003Dz0mIPc9VROWxZ ? (!face.Sense) : face.Sense);
			face.Loops = array;
			face.planeAlreadySet = _faces[_0023_003DzsMwVBGaGQeZg].planeAlreadySet;
			Plane plane = ((_faces[_0023_003DzsMwVBGaGQeZg].plane != null) ? ((Plane)_faces[_0023_003DzsMwVBGaGQeZg].plane.Clone()) : null);
			if (_0023_003Dz0mIPc9VROWxZ && plane != null)
			{
				plane.Flip();
			}
			face.plane = plane;
			_0023_003DzH_00244LxjBICrXYBxcvYXYFsGI_003D(_faces[_0023_003DzsMwVBGaGQeZg], face, _0023_003Dz0mIPc9VROWxZ, _0023_003DzQtyBAo4gFsZY, _rebuildTol);
			if (face.Tessellation != null)
			{
				face.Tessellation = (FastMesh)_faces[_0023_003DzsMwVBGaGQeZg].Tessellation.Clone();
				if (_0023_003Dz0mIPc9VROWxZ)
				{
					face.Tessellation.FlipNormal();
				}
			}
			face.Surface.TranslationID = new TranslationIdentifier(_0023_003DzUbkxYVFDH3ry.Count);
			_0023_003DzUbkxYVFDH3ry.Add(face);
		}
		return true;
	}

	internal static void _0023_003Dz8VkxvzXXGxA_0024(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Edge[] _0023_003DzU3hosSAzkxO7, Face[] _0023_003DzpPOEJqcAh7Lr, Face[][] _0023_003DzWaFlkhfmYCja, bool _0023_003DzLuJVbec_003D)
	{
		for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length; i++)
		{
			if (!(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i] == null))
			{
				((Vertex)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]).Visited = false;
				if (_0023_003DzLuJVbec_003D)
				{
					((Vertex)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]).Parents = null;
				}
			}
		}
		for (int j = 0; j < _0023_003DzU3hosSAzkxO7.Length; j++)
		{
			if (_0023_003DzU3hosSAzkxO7[j] != null)
			{
				_0023_003DzU3hosSAzkxO7[j].Visited = false;
				_0023_003DzU3hosSAzkxO7[j].SplitStatus = SplitEdgeStatus.NotAssigned;
				if (_0023_003DzLuJVbec_003D)
				{
					_0023_003DzU3hosSAzkxO7[j].Parents = null;
				}
			}
		}
		for (int k = 0; k < _0023_003DzpPOEJqcAh7Lr.Length; k++)
		{
			if (_0023_003DzpPOEJqcAh7Lr[k] == null)
			{
				continue;
			}
			_0023_003DzpPOEJqcAh7Lr[k].Visited = false;
			_0023_003DzpPOEJqcAh7Lr[k].tangentFacesIndices = null;
			_0023_003DzpPOEJqcAh7Lr[k].tangentFacesType = null;
			if (_0023_003DzpPOEJqcAh7Lr[k].Parametric == null)
			{
				continue;
			}
			Surface[] parametric = _0023_003DzpPOEJqcAh7Lr[k].Parametric;
			for (int l = 0; l < parametric.Length; l++)
			{
				foreach (ICurve contour in parametric[l].Trimming.contourList)
				{
					ICurve[] individualCurves = contour.GetIndividualCurves();
					for (int m = 0; m < individualCurves.Length; m++)
					{
						((TrimCurve)individualCurves[m]).FromBooleanIntersection = false;
					}
				}
			}
		}
		for (int n = 0; n < _0023_003DzWaFlkhfmYCja.Length; n++)
		{
			for (int num = 0; num < _0023_003DzWaFlkhfmYCja[n].Length; num++)
			{
				if (_0023_003DzWaFlkhfmYCja[n][num] == null)
				{
					continue;
				}
				_0023_003DzWaFlkhfmYCja[n][num].Visited = false;
				_0023_003DzWaFlkhfmYCja[n][num].tangentFacesIndices = null;
				_0023_003DzWaFlkhfmYCja[n][num].tangentFacesType = null;
				if (_0023_003DzWaFlkhfmYCja[n][num].Parametric == null)
				{
					continue;
				}
				Surface[] parametric = _0023_003DzWaFlkhfmYCja[n][num].Parametric;
				for (int l = 0; l < parametric.Length; l++)
				{
					foreach (ICurve contour2 in parametric[l].Trimming.contourList)
					{
						ICurve[] individualCurves = contour2.GetIndividualCurves();
						for (int m = 0; m < individualCurves.Length; m++)
						{
							((TrimCurve)individualCurves[m]).FromBooleanIntersection = false;
						}
					}
				}
			}
		}
	}

	public static Brep CreateBox(double width, double depth, double height, double tolerance = 0.0)
	{
		if (tolerance == 0.0)
		{
			tolerance = 0.001;
		}
		if (width < Utility._0023_003DzheSR8QM7q9ya || depth < Utility._0023_003DzheSR8QM7q9ya || height < Utility._0023_003DzheSR8QM7q9ya)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959112));
		}
		Point3D[] array = new Vertex[8];
		array[0] = new Vertex(0.0, 0.0);
		array[1] = new Vertex(width, 0.0);
		array[2] = new Vertex(width, depth);
		array[3] = new Vertex(0.0, depth);
		array[4] = new Vertex(0.0, 0.0, height);
		array[5] = new Vertex(width, 0.0, height);
		array[6] = new Vertex(width, depth, height);
		array[7] = new Vertex(0.0, depth, height);
		Edge[] edges = new Edge[12]
		{
			new Edge(new Line(0.0, 0.0, 0.0, width, 0.0, 0.0), 0, 1),
			new Edge(new Line(width, 0.0, 0.0, width, depth, 0.0), 1, 2),
			new Edge(new Line(width, depth, 0.0, 0.0, depth, 0.0), 2, 3),
			new Edge(new Line(0.0, depth, 0.0, 0.0, 0.0, 0.0), 3, 0),
			new Edge(new Line(0.0, 0.0, 0.0, 0.0, 0.0, height), 0, 4),
			new Edge(new Line(0.0, depth, 0.0, 0.0, depth, height), 3, 7),
			new Edge(new Line(width, depth, 0.0, width, depth, height), 2, 6),
			new Edge(new Line(width, 0.0, 0.0, width, 0.0, height), 1, 5),
			new Edge(new Line(0.0, 0.0, height, width, 0.0, height), 4, 5),
			new Edge(new Line(width, 0.0, height, width, depth, height), 5, 6),
			new Edge(new Line(width, depth, height, 0.0, depth, height), 6, 7),
			new Edge(new Line(0.0, depth, height, 0.0, 0.0, height), 7, 4)
		};
		OrientedEdge[] array2 = new OrientedEdge[4];
		OrientedEdge[] array3 = new OrientedEdge[4];
		OrientedEdge[] array4 = new OrientedEdge[4];
		OrientedEdge[] array5 = new OrientedEdge[4];
		OrientedEdge[] array6 = new OrientedEdge[4];
		OrientedEdge[] array7 = new OrientedEdge[4];
		array2[0] = new OrientedEdge(0, sense: false);
		array2[1] = new OrientedEdge(3, sense: false);
		array2[2] = new OrientedEdge(2, sense: false);
		array2[3] = new OrientedEdge(1, sense: false);
		array3[0] = new OrientedEdge(2);
		array3[1] = new OrientedEdge(5);
		array3[2] = new OrientedEdge(10, sense: false);
		array3[3] = new OrientedEdge(6, sense: false);
		array4[0] = new OrientedEdge(10);
		array4[1] = new OrientedEdge(11);
		array4[2] = new OrientedEdge(8);
		array4[3] = new OrientedEdge(9);
		array5[0] = new OrientedEdge(3);
		array5[1] = new OrientedEdge(4);
		array5[2] = new OrientedEdge(11, sense: false);
		array5[3] = new OrientedEdge(5, sense: false);
		array6[0] = new OrientedEdge(9, sense: false);
		array6[1] = new OrientedEdge(7, sense: false);
		array6[2] = new OrientedEdge(1);
		array6[3] = new OrientedEdge(6);
		array7[0] = new OrientedEdge(0);
		array7[1] = new OrientedEdge(7);
		array7[2] = new OrientedEdge(8, sense: false);
		array7[3] = new OrientedEdge(4, sense: false);
		PlanarSurf surface = new PlanarSurf(array[3], Vector3D.AxisZ, Vector3D.AxisX, 5);
		PlanarSurf surface2 = new PlanarSurf(array[0], Vector3D.AxisY, Vector3D.AxisX);
		PlanarSurf surface3 = new PlanarSurf(array[1], Vector3D.AxisX, Vector3D.AxisY, 2);
		PlanarSurf surface4 = new PlanarSurf(array[2], Vector3D.AxisY, Vector3D.AxisX, 1);
		PlanarSurf surface5 = new PlanarSurf(array[3], Vector3D.AxisX, Vector3D.AxisY, 3);
		PlanarSurf surface6 = new PlanarSurf(array[4], Vector3D.AxisZ, Vector3D.AxisX, 4);
		return new Brep(array, edges, new Face[6]
		{
			new Face(surface2, new Loop(array7), sense: false),
			new Face(surface4, new Loop(array3)),
			new Face(surface3, new Loop(array6)),
			new Face(surface5, new Loop(array5), sense: false),
			new Face(surface6, new Loop(array4)),
			new Face(surface, new Loop(array2), sense: false)
		}, null, tolerance);
	}

	public static Brep CreateCylinder(double radius, double height, double tolerance = 0.0)
	{
		if (tolerance == 0.0)
		{
			tolerance = 0.001;
		}
		Point3D[] array = new Point3D[2]
		{
			new Vertex(radius, 0.0),
			new Vertex(radius, 0.0, height)
		};
		Edge[] array2 = new Edge[3];
		Face[] array3 = new Face[3];
		Circle curve = new Circle(Plane.XY, radius);
		array2[0] = new Edge(curve, 0, 0);
		Circle circle = new Circle(Plane.XY, radius);
		circle.Translate(0.0, 0.0, height);
		array2[1] = new Edge(circle, 1, 1);
		Line curve2 = new Line((Point3D)array[0].Clone(), (Point3D)array[1].Clone());
		array2[2] = new Edge(curve2, 0, 1);
		OrientedEdge[] segments = new OrientedEdge[1]
		{
			new OrientedEdge(0, sense: false)
		};
		OrientedEdge[] segments2 = new OrientedEdge[1]
		{
			new OrientedEdge(1)
		};
		OrientedEdge[] segments3 = new OrientedEdge[4]
		{
			new OrientedEdge(0),
			new OrientedEdge(2),
			new OrientedEdge(1, sense: false),
			new OrientedEdge(2, sense: false)
		};
		PlanarSurf surface = new PlanarSurf(array[1], Vector3D.AxisZ, Vector3D.AxisX);
		CylindricalSurf surface2 = new CylindricalSurf(Point3D.Origin, Vector3D.AxisZ, Vector3D.AxisX, radius, 1);
		PlanarSurf surface3 = new PlanarSurf(array[0], Vector3D.AxisZ, Vector3D.AxisX, 2);
		array3[0] = new Face(surface3, new Loop(segments), sense: false);
		array3[1] = new Face(surface2, new Loop(segments3));
		array3[2] = new Face(surface, new Loop(segments2));
		return new Brep(array, array2, array3, null, tolerance);
	}

	public static Brep CreateCone(double baseRadius, double height)
	{
		return CreateCone(baseRadius, 0.0, height);
	}

	public static Brep CreateCone(double baseRadius, double topRadius, double height, double tolerance = 0.0)
	{
		if (tolerance == 0.0)
		{
			tolerance = 0.001;
		}
		if (baseRadius < Utility._0023_003DzheSR8QM7q9ya || height < Utility._0023_003DzheSR8QM7q9ya)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959112));
		}
		if (Math.Abs(baseRadius - topRadius) < 1E-12)
		{
			return CreateCylinder(baseRadius, height, tolerance);
		}
		Point3D[] array = new Point3D[2]
		{
			new Vertex(baseRadius, 0.0),
			new Vertex(topRadius, 0.0, height)
		};
		Edge[] array2 = new Edge[0];
		Line curve = new Line((Point3D)array[0].Clone(), (Point3D)array[1].Clone());
		Circle curve2 = new Circle(Plane.XY, baseRadius);
		OrientedEdge[] segments = new OrientedEdge[1]
		{
			new OrientedEdge(0, sense: false)
		};
		double halfAngle = 0.0 - Math.Atan((baseRadius - topRadius) / height);
		ConicalSurf surface = new ConicalSurf(Point3D.Origin, Vector3D.AxisZ, Vector3D.AxisX, baseRadius, halfAngle);
		PlanarSurf surface2 = new PlanarSurf(Point3D.Origin, Vector3D.AxisZ, Vector3D.AxisX, 1);
		Face[] array3 = new Face[0];
		if (topRadius > 0.0)
		{
			array2 = new Edge[3];
			array3 = new Face[3];
			Circle circle = new Circle(Plane.XY, topRadius);
			circle.Translate(0.0, 0.0, height);
			array2[0] = new Edge(curve2, 0, 0);
			array2[1] = new Edge(circle, 1, 1);
			array2[2] = new Edge(curve, 0, 1);
			OrientedEdge[] segments2 = new OrientedEdge[1]
			{
				new OrientedEdge(1)
			};
			OrientedEdge[] segments3 = new OrientedEdge[4]
			{
				new OrientedEdge(0),
				new OrientedEdge(2),
				new OrientedEdge(1, sense: false),
				new OrientedEdge(2, sense: false)
			};
			PlanarSurf surface3 = new PlanarSurf(new Point3D(0.0, 0.0, height), Vector3D.AxisZ, Vector3D.AxisX, 2);
			array3[0] = new Face(surface2, new Loop(segments), sense: false);
			array3[1] = new Face(surface, new Loop(segments3));
			array3[2] = new Face(surface3, new Loop(segments2));
		}
		else
		{
			array2 = new Edge[2];
			array3 = new Face[2];
			array2[0] = new Edge(curve2, 0, 0);
			array2[1] = new Edge(curve, 0, 1);
			OrientedEdge[] segments4 = new OrientedEdge[3]
			{
				new OrientedEdge(1, sense: false),
				new OrientedEdge(0),
				new OrientedEdge(1)
			};
			array3[0] = new Face(surface2, new Loop(segments), sense: false);
			array3[1] = new Face(surface, new Loop(segments4));
		}
		return new Brep(array, array2, array3, null, tolerance);
	}

	public static Brep CreateCone(double baseRadius, double baseInnerRadius, double topRadius, double topInnerRadius, double height, double distance = 0.0, double tolerance = 0.0)
	{
		if (tolerance == 0.0)
		{
			tolerance = 0.001;
		}
		if (baseRadius < Utility._0023_003DzheSR8QM7q9ya || height < Utility._0023_003DzheSR8QM7q9ya)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959112));
		}
		double num = baseRadius - baseInnerRadius;
		if (topRadius < topInnerRadius || baseRadius < baseInnerRadius || (topRadius != 0.0 && baseInnerRadius == 0.0 != (topInnerRadius == 0.0)) || num < Utility._0023_003DzheSR8QM7q9ya)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959359));
		}
		if (topRadius > 0.0)
		{
			Circle circle = new Circle(Plane.XY, baseRadius);
			Circle circle2 = new Circle(Plane.XY, topRadius);
			circle2.Translate(distance, 0.0, height);
			Surface bottom;
			Surface top;
			if (num != baseRadius)
			{
				Circle item = new Circle(Plane.XY, baseInnerRadius);
				Circle circle3 = new Circle(Plane.XY, topInnerRadius);
				circle3.Translate(distance, 0.0, height);
				bottom = new Region(new List<ICurve> { circle, item }).ConvertToSurface();
				top = new Region(new List<ICurve> { circle2, circle3 }).ConvertToSurface();
			}
			else
			{
				bottom = new Region(circle).ConvertToSurface();
				top = new Region(circle2).ConvertToSurface();
			}
			return Ruled(bottom, top, tolerance);
		}
		Circle circle4 = new Circle(Plane.XY, baseRadius);
		Point3D point3D = new Point3D(distance, 0.0, height);
		ICurve[] array;
		if (num == baseRadius)
		{
			array = new Circle[1] { circle4 };
			ICurve[] _0023_003DzHq9_ZDPKuH6o = array;
			array = new Point[1]
			{
				new Point(point3D)
			};
			ICurve[] _0023_003DziOkfOjERhlX = array;
			ICurve[][] _0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D = new ICurve[0][];
			ICurve[][] _0023_003Dz5XeGAGdLNT1O0yOtGA_003D_003D = new ICurve[0][];
			_0023_003DzrPhwbxuRz63c(_0023_003DzHq9_ZDPKuH6o, _0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D, _0023_003DziOkfOjERhlX, _0023_003Dz5XeGAGdLNT1O0yOtGA_003D_003D, out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003DzU3hosSAzkxO, out var _0023_003DzpPOEJqcAh7Lr, out var _0023_003Dz0yrVO2YPB2dr, out var _, new Dictionary<int, int>());
			AnalyticSurf surface = new Region(circle4).ConvertToSurface()._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D();
			_0023_003DzpPOEJqcAh7Lr.Add(new Face(surface, _0023_003Dz0yrVO2YPB2dr, sense: false));
			return new Brep(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO.ToArray(), _0023_003DzpPOEJqcAh7Lr.ToArray(), null, tolerance);
		}
		Circle circle5 = new Circle(Plane.XY, baseInnerRadius);
		circle5.Reverse();
		Vector3D vector3D = new Vector3D(circle4.Center, point3D);
		vector3D.Normalize();
		Point3D p = new Point3D(distance - vector3D.X * num, 0.0, height - vector3D.Z * num);
		array = new Circle[1] { circle4 };
		ICurve[] _0023_003DzHq9_ZDPKuH6o2 = array;
		array = new Point[1]
		{
			new Point(point3D)
		};
		ICurve[] _0023_003DziOkfOjERhlX2 = array;
		ICurve[][] array2 = new ICurve[1][];
		array = new Circle[1] { circle5 };
		array2[0] = array;
		ICurve[][] _0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D2 = array2;
		ICurve[][] array3 = new ICurve[1][];
		array = new Point[1]
		{
			new Point(p)
		};
		array3[0] = array;
		ICurve[][] _0023_003Dz5XeGAGdLNT1O0yOtGA_003D_003D2 = array3;
		_0023_003DzrPhwbxuRz63c(_0023_003DzHq9_ZDPKuH6o2, _0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D2, _0023_003DziOkfOjERhlX2, _0023_003Dz5XeGAGdLNT1O0yOtGA_003D_003D2, out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D2, out var _0023_003DzU3hosSAzkxO2, out var _0023_003DzpPOEJqcAh7Lr2, out var _0023_003Dz0yrVO2YPB2dr2, out var _, new Dictionary<int, int>());
		AnalyticSurf surface2 = new Region(new List<ICurve> { circle4, circle5 }).ConvertToSurface()._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D();
		_0023_003DzpPOEJqcAh7Lr2.Add(new Face(surface2, _0023_003Dz0yrVO2YPB2dr2, sense: false));
		return new Brep(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D2, _0023_003DzU3hosSAzkxO2.ToArray(), _0023_003DzpPOEJqcAh7Lr2.ToArray(), null, tolerance);
	}

	public static Brep CreateSphere(double radius, double tolerance = 0.0)
	{
		if (tolerance == 0.0)
		{
			tolerance = 0.001;
		}
		if (radius < Utility._0023_003DzheSR8QM7q9ya)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959112));
		}
		Point3D[] vertices = new Point3D[2]
		{
			new Vertex(0.0, 0.0, 0.0 - radius),
			new Vertex(0.0, 0.0, radius)
		};
		Edge[] array = new Edge[1];
		Arc curve = new Arc(new Plane(Point3D.Origin, Vector3D.AxisX, Vector3D.AxisZ), Point3D.Origin, radius, 4.71238898038469, 7.853981633974483);
		array[0] = new Edge(curve, 0, 1);
		OrientedEdge[] segments = new OrientedEdge[2]
		{
			new OrientedEdge(0),
			new OrientedEdge(0, sense: false)
		};
		SphericalSurf surface = new SphericalSurf(Point3D.Origin, Vector3D.AxisZ, Vector3D.AxisX, radius);
		return new Brep(vertices, array, new Face[1]
		{
			new Face(surface, new Loop(segments))
			{
				TextureOffsetV = (float)((0.0 - radius) / 2.0 * Math.PI)
			}
		}, null, tolerance);
	}

	public static Brep CreateTorus(double majorRadius, double minorRadius, double tolerance = 0.0)
	{
		if (tolerance == 0.0)
		{
			tolerance = 0.001;
		}
		if (majorRadius < Utility._0023_003DzheSR8QM7q9ya || minorRadius < Utility._0023_003DzheSR8QM7q9ya)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959112));
		}
		Point3D[] vertices = new Point3D[1]
		{
			new Vertex(majorRadius + minorRadius, 0.0)
		};
		Edge[] array = new Edge[2];
		Circle curve = new Circle(Plane.XY, majorRadius + minorRadius);
		array[0] = new Edge(curve, 0, 0);
		Circle curve2 = new Circle(new Plane(Point3D.Origin, Vector3D.AxisX, Vector3D.AxisZ), new Point3D(majorRadius, 0.0, 0.0), minorRadius);
		array[1] = new Edge(curve2, 0, 0);
		OrientedEdge[] segments = new OrientedEdge[4]
		{
			new OrientedEdge(0),
			new OrientedEdge(1),
			new OrientedEdge(0, sense: false),
			new OrientedEdge(1, sense: false)
		};
		ToroidalSurf surface = new ToroidalSurf(Point3D.Origin, Vector3D.AxisZ, Vector3D.AxisX, majorRadius, minorRadius);
		return new Brep(vertices, array, new Face[1]
		{
			new Face(surface, new Loop(segments))
		}, null, tolerance);
	}

	internal static Brep _0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(Region _0023_003DzqT6kZ6g_003D, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dzbu8BV15Qqzan, bool _0023_003DzbErHvVw_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
	{
		_0023_003DzqT6kZ6g_003D._0023_003DzWFzsryZTA1I_JcqmPg_mY3Wl4l5L(out var _0023_003Dz_SqBXz8_003D, out var _0023_003DzWaFlkhfmYCja);
		return _0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzYNjcavt9guh2, _0023_003Dzbu8BV15Qqzan, _0023_003DzbErHvVw_003D: true, (Plane)_0023_003DzqT6kZ6g_003D.Plane.Clone(), _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
	}

	internal static Brep _0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dzbu8BV15Qqzan, bool _0023_003DzbErHvVw_003D, double _0023_003DzGvLz4uh736QEMEZuVg_003D_003D)
	{
		return _0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzYNjcavt9guh2, _0023_003Dzbu8BV15Qqzan, _0023_003DzbErHvVw_003D, null, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D);
	}

	internal static Brep _0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, Vector3D _0023_003DzYNjcavt9guh2, bool _0023_003Dzbu8BV15Qqzan, bool _0023_003DzbErHvVw_003D, Plane _0023_003Dzrgqz890sj_0024X9, double _0023_003DzGvLz4uh736QEMEZuVg_003D_003D)
	{
		if (_0023_003DzGvLz4uh736QEMEZuVg_003D_003D == 0.0)
		{
			_0023_003DzGvLz4uh736QEMEZuVg_003D_003D = 0.001;
		}
		Entity entity = (Entity)_0023_003Dz_SqBXz8_003D.Clone();
		List<ICurve> list = new List<ICurve> { (ICurve)entity };
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
			{
				Entity entity2 = (Entity)_0023_003DzWaFlkhfmYCja[i].Clone();
				list.Add((ICurve)entity2);
			}
		}
		int num = list[0].GetIndividualCurves().Length + ((!_0023_003DzbErHvVw_003D) ? 1 : 0);
		List<Point3D> list2 = new List<Point3D>(num * 2);
		List<Edge> list3 = new List<Edge>(num * 3);
		List<Face> list4 = new List<Face>(num);
		Loop[] array = new Loop[list.Count];
		Loop[] array2 = new Loop[list.Count];
		for (int j = 0; j < list.Count; j++)
		{
			_0023_003Dz5CLQsFJmJqrC9s7TRtPzUnc_003D(list[j], _0023_003DzYNjcavt9guh2, list2.Count, list3.Count, _0023_003Dzbu8BV15Qqzan, out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003DzU3hosSAzkxO, out var _0023_003DzpPOEJqcAh7Lr, out array[j], out array2[j]);
			list2.AddRange(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
			list3.AddRange(_0023_003DzU3hosSAzkxO);
			list4.AddRange(_0023_003DzpPOEJqcAh7Lr);
		}
		if (_0023_003DzbErHvVw_003D)
		{
			double tol = Surface._0023_003DzWu3S5IPxj3tfF03Eyw_003D_003D(new ICurve[1] { (ICurve)entity }).Diagonal * _0023_003DzGvLz4uh736QEMEZuVg_003D_003D;
			if (_0023_003Dzrgqz890sj_0024X9 == null)
			{
				((ICurve)entity).IsPlanar(tol, out _0023_003Dzrgqz890sj_0024X9);
			}
			Point3D obj = (Point3D)list2[0].Clone();
			obj.TransformBy(new Translation(_0023_003DzYNjcavt9guh2));
			PlanarSurf _0023_003DzjGoXlKw_003D = new PlanarSurf((Point3D)list2[0].Clone(), (Vector3D)_0023_003Dzrgqz890sj_0024X9.AxisZ.Clone(), (Vector3D)_0023_003Dzrgqz890sj_0024X9.AxisX.Clone(), list4.Count);
			PlanarSurf _0023_003Dz1FonMC4_003D = new PlanarSurf(obj, (Vector3D)_0023_003Dzrgqz890sj_0024X9.AxisZ.Clone(), (Vector3D)_0023_003Dzrgqz890sj_0024X9.AxisX.Clone(), list4.Count + 1);
			_0023_003Dzcg4Fe1KpKEim(list4, _0023_003DzjGoXlKw_003D, _0023_003Dz1FonMC4_003D, array, array2, _0023_003Dzbu8BV15Qqzan);
		}
		return new Brep(list2.ToArray(), list3.ToArray(), list4.ToArray(), null, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D);
	}

	internal static Brep _0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(Region _0023_003DzqT6kZ6g_003D, Interval _0023_003DzJh6qrM9vQQk7, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
	{
		return _0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(_0023_003DzqT6kZ6g_003D, _0023_003DzJh6qrM9vQQk7.Low, _0023_003DzJh6qrM9vQQk7.Length, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
	}

	internal static Brep _0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, Interval _0023_003DzJh6qrM9vQQk7, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, bool _0023_003DzbErHvVw_003D, double _0023_003DzGvLz4uh736QEMEZuVg_003D_003D)
	{
		return _0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzJh6qrM9vQQk7.Low, _0023_003DzJh6qrM9vQQk7.Length, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzbErHvVw_003D, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D);
	}

	internal static Brep _0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(Region _0023_003DzqT6kZ6g_003D, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
	{
		if (_0023_003DzuMKQhOieejyEvhtVOw_003D_003D == 0.0)
		{
			_0023_003DzuMKQhOieejyEvhtVOw_003D_003D = 0.001;
		}
		ICurve curve = (ICurve)_0023_003DzqT6kZ6g_003D.ContourList[0].Clone();
		IList<ICurve> list = null;
		if (_0023_003DzqT6kZ6g_003D.ContourList.Count > 1)
		{
			list = new List<ICurve>();
			for (int i = 1; i < _0023_003DzqT6kZ6g_003D.ContourList.Count; i++)
			{
				list.Add((ICurve)_0023_003DzqT6kZ6g_003D.ContourList[i].Clone());
			}
		}
		Vector3D vector3D = (Vector3D)_0023_003DzxuJqjrs_003D.Clone();
		if (_0023_003DzFINJ6s3Z_0024n8G < 0.0)
		{
			vector3D.Negate();
		}
		bool num = Utility._0023_003Dzcgl1YHa2I1jhVm1Gy8K96dA_003D(_0023_003DzqT6kZ6g_003D.ContourList[0], _0023_003DzqT6kZ6g_003D.Plane.AxisZ, vector3D, _0023_003DzbUvT9Pc_003D);
		Plane plane = (Plane)_0023_003DzqT6kZ6g_003D.Plane.Clone();
		if (num)
		{
			curve.Reverse();
			int num2 = 0;
			while (list != null && num2 < list.Count)
			{
				list[num2].Reverse();
				num2++;
			}
			plane.Flip();
		}
		return _0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(curve, list, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzbErHvVw_003D: true, plane, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
	}

	internal static Brep _0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, bool _0023_003DzbErHvVw_003D, double _0023_003DzGvLz4uh736QEMEZuVg_003D_003D)
	{
		return _0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzbErHvVw_003D, null, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D);
	}

	internal static Brep _0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003Dz3veEI49c6b6Q, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, bool _0023_003DzbErHvVw_003D, Plane _0023_003Dzrgqz890sj_0024X9, double _0023_003DzGvLz4uh736QEMEZuVg_003D_003D)
	{
		if (_0023_003DzGvLz4uh736QEMEZuVg_003D_003D == 0.0)
		{
			_0023_003DzGvLz4uh736QEMEZuVg_003D_003D = 0.001;
		}
		bool flag = Math.Abs(_0023_003DzFINJ6s3Z_0024n8G % (Math.PI * 2.0)) < Utility._0023_003DzxhnLabVjXjPg * _0023_003DzGvLz4uh736QEMEZuVg_003D_003D;
		double num = _0023_003DzFINJ6s3Z_0024n8G;
		Vector3D vector3D = (Vector3D)_0023_003DzxuJqjrs_003D.Clone();
		vector3D.Normalize();
		_0023_003Dz3veEI49c6b6Q = Utility.FixRevAngle(_0023_003Dz3veEI49c6b6Q, _0023_003DzFINJ6s3Z_0024n8G).t0;
		num = Math.Abs(_0023_003DzFINJ6s3Z_0024n8G);
		ICurve[][] array = new ICurve[1 + (_0023_003DzWaFlkhfmYCja?.Count ?? 0)][];
		Entity entity = (Entity)_0023_003Dz_SqBXz8_003D.Clone();
		entity.Rotate(_0023_003Dz3veEI49c6b6Q, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D);
		Utility._0023_003Dzdh_4OQddxCSDDYZ27Q_003D_003D((ICurve)entity, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, _0023_003DzFSLBkBecx_0024NX: false, out var _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, _0023_003Dz6SBnzmNnw6lO: false);
		List<ICurve> list = _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.ToList();
		List<Point3D> _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D = new List<Point3D>(_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length * 2);
		bool flag2 = false;
		if (flag || !_0023_003DzbErHvVw_003D)
		{
			flag2 = _0023_003Dz6CQjBiIvVh9x(_0023_003Dz_SqBXz8_003D, _0023_003DzbUvT9Pc_003D, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, vector3D, list);
		}
		array[0] = list.ToArray();
		int num2 = list.Count;
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
			{
				Entity obj = (Entity)_0023_003DzWaFlkhfmYCja[i].Clone();
				obj.Rotate(_0023_003Dz3veEI49c6b6Q, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D);
				Utility._0023_003Dzdh_4OQddxCSDDYZ27Q_003D_003D((ICurve)obj, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, _0023_003DzFSLBkBecx_0024NX: false, out var _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D2, _0023_003Dz6SBnzmNnw6lO: false);
				array[i + 1] = _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D2;
				num2 += _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D2.Length;
			}
		}
		List<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new List<Point3D>(num2 * 2);
		List<Edge> _0023_003DzU3hosSAzkxO = new List<Edge>(num2 * 3);
		List<Face> list2 = new List<Face>(num2);
		List<Face[]> list3 = new List<Face[]>();
		Loop[] array2 = new Loop[array.Length];
		Loop[] array3 = new Loop[array.Length];
		for (int j = 0; j < array.Length; j++)
		{
			List<Face> _0023_003DzpPOEJqcAh7Lr = new List<Face>(num2);
			int count = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count;
			int count2 = _0023_003DzU3hosSAzkxO.Count;
			bool _0023_003DzQ_0024sdp7BxtgRwrt1d_0024A_003D_003D = ((j != 0) ? _0023_003DzWaFlkhfmYCja[j - 1].IsClosed : (!flag2 && _0023_003Dz_SqBXz8_003D.IsClosed));
			OrientedEdge[] _0023_003Dz_0024SsLohloknxt = new OrientedEdge[array[j].Length];
			OrientedEdge[] _0023_003DzuYjXyyijq2Xy = new OrientedEdge[array[j].Length];
			for (int k = 0; k < array[j].Length; k++)
			{
				_0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(array[j][k], _0023_003DzQ_0024sdp7BxtgRwrt1d_0024A_003D_003D, k, array[j].Length, num, vector3D, _0023_003DzbUvT9Pc_003D, count, count2, ref _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, ref _0023_003DzU3hosSAzkxO, ref _0023_003DzpPOEJqcAh7Lr, ref _0023_003Dz_0024SsLohloknxt, ref _0023_003DzuYjXyyijq2Xy);
			}
			if (_0023_003DzFINJ6s3Z_0024n8G < 0.0)
			{
				for (int l = 0; l < _0023_003DzpPOEJqcAh7Lr.Count; l++)
				{
					_0023_003DzpPOEJqcAh7Lr[l].Sense = !_0023_003DzpPOEJqcAh7Lr[l].Sense;
					Loop[] loops = _0023_003DzpPOEJqcAh7Lr[l].Loops;
					foreach (Loop loop in loops)
					{
						loop.Sense = !loop.Sense;
					}
				}
			}
			if (flag && j > 0)
			{
				list3.Add(_0023_003DzpPOEJqcAh7Lr.ToArray());
			}
			else
			{
				list2.AddRange(_0023_003DzpPOEJqcAh7Lr);
			}
			if (_0023_003DzFINJ6s3Z_0024n8G < 0.0)
			{
				array2[j] = new Loop(_0023_003Dz_0024SsLohloknxt.ToArray(), sense: false);
				array3[j] = new Loop(_0023_003DzuYjXyyijq2Xy.ToArray());
			}
			else
			{
				array2[j] = new Loop(_0023_003Dz_0024SsLohloknxt.ToArray());
				array3[j] = new Loop(_0023_003DzuYjXyyijq2Xy.ToArray(), sense: false);
			}
		}
		if (_0023_003DzbErHvVw_003D && !flag)
		{
			double tol = Surface._0023_003DzWu3S5IPxj3tfF03Eyw_003D_003D(new ICurve[1] { (ICurve)entity }).Diagonal * _0023_003DzGvLz4uh736QEMEZuVg_003D_003D;
			if (_0023_003Dzrgqz890sj_0024X9 == null)
			{
				((ICurve)entity).IsPlanar(tol, out _0023_003Dzrgqz890sj_0024X9);
			}
			else
			{
				_0023_003Dzrgqz890sj_0024X9.Rotate(_0023_003Dz3veEI49c6b6Q, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D);
			}
			entity.Rotate(num, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D);
			Plane plane = (Plane)_0023_003Dzrgqz890sj_0024X9.Clone();
			plane.Rotate(num, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D);
			PlanarSurf _0023_003DzjGoXlKw_003D = new PlanarSurf((Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0].Clone(), (Vector3D)_0023_003Dzrgqz890sj_0024X9.AxisZ.Clone(), (Vector3D)_0023_003Dzrgqz890sj_0024X9.AxisX.Clone(), list2.Count);
			PlanarSurf _0023_003Dz1FonMC4_003D = new PlanarSurf(((ICurve)entity).StartPoint, (Vector3D)plane.AxisZ.Clone(), (Vector3D)plane.AxisX.Clone(), list2.Count + 1);
			_0023_003Dzcg4Fe1KpKEim(list2, _0023_003DzjGoXlKw_003D, _0023_003Dz1FonMC4_003D, array2, array3, _0023_003DzFINJ6s3Z_0024n8G >= 0.0);
		}
		return new Brep(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.ToArray(), _0023_003DzU3hosSAzkxO.ToArray(), list2.ToArray(), list3.ToArray(), _0023_003DzGvLz4uh736QEMEZuVg_003D_003D);
	}

	private static bool _0023_003Dz6CQjBiIvVh9x(ICurve _0023_003Dz_SqBXz8_003D, Point3D _0023_003DzbUvT9Pc_003D, double _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, ICurve[] _0023_003DzITGbK80_003D, List<Point3D> _0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, Vector3D _0023_003DzqADawwrHvpK9, List<ICurve> _0023_003DzItZ6aEugTCY435PyVw_003D_003D)
	{
		int num = 0;
		foreach (ICurve curve in _0023_003DzITGbK80_003D)
		{
			_0023_003DzPqXWTst3YPlWn9JngQ_003D_003D.AddRange(((Entity)curve).EstimateBoundingBox(null, null));
			if (Utility.IsLine(curve))
			{
				Point3D point3D = curve.StartPoint.ProjectTo(new Segment3D(_0023_003DzbUvT9Pc_003D, _0023_003DzbUvT9Pc_003D + _0023_003DzqADawwrHvpK9));
				Point3D point3D2 = curve.EndPoint.ProjectTo(new Segment3D(_0023_003DzbUvT9Pc_003D, _0023_003DzbUvT9Pc_003D + _0023_003DzqADawwrHvpK9));
				if (point3D.Equals(curve.StartPoint) && point3D2.Equals(curve.EndPoint))
				{
					_0023_003DzItZ6aEugTCY435PyVw_003D_003D.Remove(curve);
					num++;
				}
				if (num > 1)
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959327));
				}
			}
		}
		Utility.ComputeBoundingBox(_0023_003DzPqXWTst3YPlWn9JngQ_003D_003D, out var boxMin, out var boxMax);
		double closureTol = new Size3D(boxMin, boxMax).Diagonal * Utility._0023_003DzxhnLabVjXjPg * _0023_003DzGvLz4uh736QEMEZuVg_003D_003D;
		if (_0023_003Dz_SqBXz8_003D.IsClosed && num > 0)
		{
			Utility.SortAndOrient(_0023_003DzItZ6aEugTCY435PyVw_003D_003D, closureTol);
		}
		return num > 0;
	}

	private static void _0023_003DzG0d_0024L_I9MyMuIit8Aw_003D_003D(ICurve _0023_003DzSwfghCo_003D, bool _0023_003DzQ_0024sdp7BxtgRwrt1d_0024A_003D_003D, int _0023_003DzPtl6JaRWmAK7, int _0023_003DzImi_BLBVgg2oprXkIg_003D_003D, double _0023_003DzFINJ6s3Z_0024n8G, Vector3D _0023_003DzqADawwrHvpK9, Point3D _0023_003DzbUvT9Pc_003D, int _0023_003DzJORM_n3VoDYx, int _0023_003Dz_0024WEho_0024n35nr4, ref List<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, ref List<Edge> _0023_003DzU3hosSAzkxO7, ref List<Face> _0023_003DzpPOEJqcAh7Lr, ref OrientedEdge[] _0023_003Dz_0024SsLohloknxt, ref OrientedEdge[] _0023_003DzuYjXyyijq2Xy)
	{
		_ = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count;
		bool flag = Math.Abs(_0023_003DzFINJ6s3Z_0024n8G % (Math.PI * 2.0)) < 1E-06;
		bool flag2 = _0023_003DzPtl6JaRWmAK7 == _0023_003DzImi_BLBVgg2oprXkIg_003D_003D - 1;
		Segment3D segment3D = new Segment3D(_0023_003DzbUvT9Pc_003D, _0023_003DzbUvT9Pc_003D + _0023_003DzqADawwrHvpK9);
		double _0023_003Dz9ulfqf0M07_0024x;
		Vector3D vector3D = _0023_003DzSwfghCo_003D.GetNurbsForm()._0023_003Dz2Ew9vDIo4RqEw9OnJ5wRuuQ_003D(segment3D, out _0023_003Dz9ulfqf0M07_0024x);
		Vector3D y = Vector3D.Cross(_0023_003DzqADawwrHvpK9, vector3D);
		Point3D point3D = _0023_003DzSwfghCo_003D.StartPoint.ProjectTo(segment3D);
		double num = Point3D.Distance(point3D, _0023_003DzSwfghCo_003D.StartPoint);
		bool flag3 = num < 1E-06;
		Point3D point3D2 = _0023_003DzSwfghCo_003D.EndPoint.ProjectTo(segment3D);
		double num2 = Point3D.Distance(point3D2, _0023_003DzSwfghCo_003D.EndPoint);
		bool flag4 = num2 < 1E-06;
		bool flag5 = false;
		bool flag6 = false;
		bool flag7 = false;
		if (Utility.IsLine(_0023_003DzSwfghCo_003D))
		{
			Vector3D startTangent = _0023_003DzSwfghCo_003D.StartTangent;
			if (Vector3D.AreOrthogonal(startTangent, _0023_003DzqADawwrHvpK9) && Vector3D.AreParallel(startTangent, vector3D))
			{
				flag7 = Vector3D.AreOpposite(vector3D, startTangent);
			}
			flag5 = flag3 && flag4;
			flag6 = Vector3D.AreOrthogonal(startTangent, _0023_003DzqADawwrHvpK9) && Vector3D.AreParallel(startTangent, vector3D);
			if (flag6)
			{
				flag7 = Vector3D.AreOpposite(vector3D, startTangent);
			}
		}
		int num3 = -1;
		int num4 = -1;
		int num5 = -1;
		int num6 = -1;
		Point3D point3D3 = (Point3D)_0023_003DzSwfghCo_003D.StartPoint.Clone();
		Point3D point3D4 = (Point3D)_0023_003DzSwfghCo_003D.EndPoint.Clone();
		num3 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count;
		if (!(flag3 && flag6 && flag))
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(new Vertex(point3D3.X, point3D3.Y, point3D3.Z));
		}
		num4 = num3;
		if (!flag && !flag3)
		{
			num4 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count;
			point3D3.TransformBy(new Rotation(_0023_003DzFINJ6s3Z_0024n8G, _0023_003DzqADawwrHvpK9, _0023_003DzbUvT9Pc_003D));
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(new Vertex(point3D3.X, point3D3.Y, point3D3.Z));
		}
		num5 = num4 + 1;
		if (!(flag && flag4 && flag6) && !_0023_003DzQ_0024sdp7BxtgRwrt1d_0024A_003D_003D && flag2)
		{
			num5 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count;
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(new Vertex(point3D4.X, point3D4.Y, point3D4.Z));
		}
		else if (flag2)
		{
			num5 = _0023_003DzJORM_n3VoDYx;
		}
		num6 = ((flag || flag4) ? num5 : (num5 + 1));
		if (!flag && !flag4 && !_0023_003DzQ_0024sdp7BxtgRwrt1d_0024A_003D_003D && flag2)
		{
			num6 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count;
			point3D4.TransformBy(new Rotation(_0023_003DzFINJ6s3Z_0024n8G, _0023_003DzqADawwrHvpK9, _0023_003DzbUvT9Pc_003D));
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Add(new Vertex(point3D4.X, point3D4.Y, point3D4.Z));
		}
		int num7 = -1;
		int num8 = -1;
		int num9 = -1;
		int num10 = -1;
		Entity entity = (Entity)_0023_003DzSwfghCo_003D.Clone();
		if (!flag3)
		{
			num9 = _0023_003DzU3hosSAzkxO7.Count;
			Arc curve = new Arc(new Plane(point3D, vector3D, y), point3D, num, (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num3].Clone(), (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num4].Clone(), flip: false);
			_0023_003DzU3hosSAzkxO7.Add(new Edge(curve, num3, num4));
		}
		if (!flag || !flag6)
		{
			num7 = _0023_003DzU3hosSAzkxO7.Count;
			_0023_003DzU3hosSAzkxO7.Add(new Edge((ICurve)entity.Clone(), num3, num5));
		}
		num8 = num7;
		if (!flag && !flag5)
		{
			num8 = _0023_003DzU3hosSAzkxO7.Count;
			entity.TransformBy(new Rotation(_0023_003DzFINJ6s3Z_0024n8G, _0023_003DzqADawwrHvpK9, _0023_003DzbUvT9Pc_003D));
			_0023_003DzU3hosSAzkxO7.Add(new Edge((ICurve)entity.Clone(), num4, num6));
		}
		if (!_0023_003DzQ_0024sdp7BxtgRwrt1d_0024A_003D_003D && flag2 && !flag4)
		{
			Arc curve2 = new Arc(new Plane(point3D2, vector3D, y), point3D2, num2, (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num5].Clone(), (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num6].Clone(), flip: false);
			num10 = _0023_003DzU3hosSAzkxO7.Count;
			_0023_003DzU3hosSAzkxO7.Add(new Edge(curve2, num5, num6));
		}
		else if (_0023_003DzQ_0024sdp7BxtgRwrt1d_0024A_003D_003D && flag2 && !flag4)
		{
			num10 = _0023_003Dz_0024WEho_0024n35nr4;
		}
		else if (!flag2 && !flag4)
		{
			num10 = _0023_003DzU3hosSAzkxO7.Count;
		}
		List<OrientedEdge> list = new List<OrientedEdge>(1);
		List<OrientedEdge> list2 = new List<OrientedEdge>(1);
		if (flag && flag6)
		{
			if (flag7)
			{
				list.Add(new OrientedEdge(num9));
				if (num10 != -1)
				{
					list2.Add(new OrientedEdge(num10, sense: false));
				}
			}
			else
			{
				list.Add(new OrientedEdge(num10, sense: false));
				if (num9 != -1)
				{
					list2.Add(new OrientedEdge(num9));
				}
			}
		}
		else
		{
			list = new List<OrientedEdge>(4);
			if (num9 != -1)
			{
				list.Add(new OrientedEdge(num9));
			}
			if (num8 != -1)
			{
				list.Add(new OrientedEdge(num8));
			}
			if (num10 != -1)
			{
				list.Add(new OrientedEdge(num10, sense: false));
			}
			if (num7 != -1)
			{
				list.Add(new OrientedEdge(num7, sense: false));
			}
		}
		_0023_003Dz_0024SsLohloknxt[_0023_003DzPtl6JaRWmAK7] = new OrientedEdge(num7);
		_0023_003DzuYjXyyijq2Xy[_0023_003DzPtl6JaRWmAK7] = new OrientedEdge(num8);
		if (flag5)
		{
			return;
		}
		AnalyticSurf analyticSurf = null;
		Plane plane = new Plane(_0023_003DzbUvT9Pc_003D, vector3D, _0023_003DzqADawwrHvpK9);
		if (_0023_003DzSwfghCo_003D.IsInPlane(plane, _0023_003Dz9ulfqf0M07_0024x * Utility._0023_003DzxhnLabVjXjPg) && flag6)
		{
			Vector3D normal = (flag7 ? _0023_003DzqADawwrHvpK9 : (_0023_003DzqADawwrHvpK9 * -1.0));
			analyticSurf = new PlanarSurf(_0023_003DzSwfghCo_003D.StartPoint, normal, vector3D);
		}
		else
		{
			Surface[] array = _0023_003DzSwfghCo_003D.RevolveAsSurface(0.0, _0023_003DzFINJ6s3Z_0024n8G, _0023_003DzqADawwrHvpK9, _0023_003DzbUvT9Pc_003D);
			if (array.Length != 0)
			{
				if (array[0] is RevolvedSurface)
				{
					RevolvedSurface revolvedSurface = (RevolvedSurface)array[0];
					analyticSurf = new RevolvedSurf((Point3D)revolvedSurface.Center.Clone(), (Vector3D)revolvedSurface.Axis.Clone(), (Vector3D)revolvedSurface.SeamPlane.AxisX.Clone(), (ICurve)revolvedSurface.Generatrix.Clone());
				}
				else
				{
					analyticSurf = array[0]._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D();
				}
			}
		}
		if (analyticSurf != null)
		{
			Loop[] loops = ((list2.Count == 0) ? new Loop[1]
			{
				new Loop(list.ToArray())
			} : new Loop[2]
			{
				new Loop(list.ToArray()),
				new Loop(list2.ToArray())
			});
			Face item = new Face(analyticSurf, loops);
			_0023_003DzpPOEJqcAh7Lr.Add(item);
		}
	}

	public static Brep Ruled(Surface bottom, Surface top, double tolerance = 0.0)
	{
		if (tolerance == 0.0)
		{
			tolerance = 0.0;
		}
		if (bottom.Trimming.ContourList.Count != top.Trimming.ContourList.Count)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959257));
		}
		if (bottom.IsClosedU != top.IsClosedU || bottom.IsClosedV != top.IsClosedV)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959989));
		}
		ICurve[] individualCurves = bottom.Trimming.ContourList[0].GetIndividualCurves();
		ICurve[] individualCurves2 = top.Trimming.ContourList[0].GetIndividualCurves();
		List<ICurve> list = new List<ICurve>(individualCurves.Length);
		List<ICurve> list2 = new List<ICurve>(individualCurves.Length);
		if (individualCurves.Length != individualCurves2.Length)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959941));
		}
		List<ICurve[]> list3 = new List<ICurve[]>(bottom.Trimming.ContourList.Count - 1);
		List<ICurve[]> list4 = new List<ICurve[]>(top.Trimming.ContourList.Count - 1);
		Dictionary<double, int> dictionary = new Dictionary<double, int>();
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
		for (int i = 0; i < individualCurves.Length; i++)
		{
			TrimCurve trimCurve = (TrimCurve)individualCurves[i];
			TrimCurve trimCurve2 = (TrimCurve)individualCurves2[i];
			if (bottom.IsClosedU && bottom.IsOnSeamU(trimCurve.Edge))
			{
				double key = Math.Round(trimCurve.StartPoint.Y, 9);
				double key2 = Math.Round(trimCurve.EndPoint.Y, 9);
				if (!dictionary.ContainsKey(key2))
				{
					dictionary.Add(key, i);
				}
				else
				{
					double x = individualCurves[dictionary[key2]].StartPoint.X;
					double x2 = individualCurves[i].StartPoint.X;
					if (Utility.AreEqual(x, bottom.DomainU.Low, bottom.DomainU.Length))
					{
						if (Utility.AreEqual(x2, bottom.DomainU.High, bottom.DomainU.Length))
						{
							if (!Utility.AreEqual(individualCurves2[i].StartPoint.X, top.DomainU.High, top.DomainU.Length) || !Utility.AreEqual(individualCurves2[i].StartPoint.Y, individualCurves2[dictionary[key2]].EndPoint.Y, top.DomainV.Length))
							{
								throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959917));
							}
							dictionary2.Add(dictionary[key2], i);
							dictionary.Remove(key2);
						}
						else if (Utility.AreEqual(x2, bottom.DomainU.Low, bottom.DomainU.Length))
						{
							dictionary.Add(key, i);
						}
					}
					else if (Utility.AreEqual(x, bottom.DomainU.High, bottom.DomainU.Length))
					{
						if (Utility.AreEqual(x2, bottom.DomainU.Low, bottom.DomainU.Length))
						{
							if (!Utility.AreEqual(individualCurves2[i].StartPoint.X, top.DomainU.Low, top.DomainU.Length) || !Utility.AreEqual(individualCurves2[i].StartPoint.Y, individualCurves2[dictionary[key2]].EndPoint.Y, top.DomainV.Length))
							{
								throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959917));
							}
							dictionary2.Add(i, dictionary[key2]);
							dictionary.Remove(key2);
						}
						else if (Utility.AreEqual(x2, bottom.DomainU.High, bottom.DomainU.Length))
						{
							dictionary.Add(key, i);
						}
					}
				}
			}
			else if (bottom.IsClosedV && bottom.IsOnSeamV(trimCurve.Edge))
			{
				double key3 = Math.Round(trimCurve.StartPoint.X, 9);
				double key4 = Math.Round(trimCurve.EndPoint.X, 9);
				if (!dictionary.ContainsKey(key4))
				{
					dictionary.Add(key3, i);
				}
				else
				{
					double y = individualCurves[dictionary[key4]].StartPoint.Y;
					double y2 = individualCurves[i].StartPoint.Y;
					if (Utility.AreEqual(y, bottom.DomainV.Low, bottom.DomainV.Length))
					{
						if (Utility.AreEqual(y2, bottom.DomainV.High, bottom.DomainV.Length))
						{
							if (!Utility.AreEqual(individualCurves2[i].StartPoint.Y, top.DomainV.High, top.DomainV.Length) || !Utility.AreEqual(individualCurves2[i].StartPoint.X, individualCurves2[dictionary[key4]].EndPoint.Y, top.DomainU.Length))
							{
								throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959917));
							}
							dictionary2.Add(dictionary[key4], i);
							dictionary.Remove(key4);
						}
						else if (Utility.AreEqual(y2, bottom.DomainV.Low, bottom.DomainV.Length))
						{
							dictionary.Add(key3, i);
						}
					}
					else if (Utility.AreEqual(y, bottom.DomainV.High, bottom.DomainV.Length))
					{
						if (Utility.AreEqual(y2, bottom.DomainV.Low, bottom.DomainV.Length))
						{
							if (!Utility.AreEqual(individualCurves2[i].StartPoint.Y, top.DomainV.Low, top.DomainV.Length) || !Utility.AreEqual(individualCurves2[i].StartPoint.X, individualCurves2[dictionary[key4]].EndPoint.X, top.DomainU.Length))
							{
								throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959917));
							}
							dictionary2.Add(i, dictionary[key4]);
							dictionary.Remove(key4);
						}
						else if (Utility.AreEqual(y2, bottom.DomainV.High, bottom.DomainV.Length))
						{
							dictionary.Add(key3, i);
						}
					}
				}
			}
			list.Add(trimCurve.Edge);
			list2.Add(trimCurve2.Edge);
		}
		if (bottom.Trimming.ContourList.Count > 1)
		{
			for (int j = 1; j < bottom.Trimming.ContourList.Count; j++)
			{
				ICurve[] individualCurves3 = bottom.Trimming.ContourList[j].GetIndividualCurves();
				list3.Add(new ICurve[individualCurves3.Length]);
				ICurve[] individualCurves4 = top.Trimming.ContourList[j].GetIndividualCurves();
				list4.Add(new ICurve[individualCurves4.Length]);
				if (individualCurves3.Length != individualCurves4.Length)
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960128));
				}
				for (int k = 0; k < individualCurves3.Length; k++)
				{
					TrimCurve trimCurve3 = (TrimCurve)individualCurves3[k];
					list3[list3.Count - 1][k] = trimCurve3.Edge;
					TrimCurve trimCurve4 = (TrimCurve)individualCurves4[k];
					list4[list4.Count - 1][k] = trimCurve4.Edge;
				}
			}
		}
		_0023_003DzrPhwbxuRz63c(list.ToArray(), list3.ToArray(), list2.ToArray(), list4.ToArray(), out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003DzU3hosSAzkxO, out var _0023_003DzpPOEJqcAh7Lr, out var _0023_003Dz0yrVO2YPB2dr, out var _0023_003DzIgssic2TOqah, dictionary2);
		AnalyticSurf analyticSurf = bottom._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D();
		bool _0023_003Dzx3pYiE0_003D = false;
		_0023_003Dze_0024eVclnuDv0s(bottom, analyticSurf, ref _0023_003Dzx3pYiE0_003D);
		_0023_003DzpPOEJqcAh7Lr.Add(new Face(analyticSurf, _0023_003Dz0yrVO2YPB2dr, _0023_003Dzx3pYiE0_003D));
		AnalyticSurf analyticSurf2 = top._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D();
		_0023_003Dzx3pYiE0_003D = true;
		_0023_003Dze_0024eVclnuDv0s(top, analyticSurf2, ref _0023_003Dzx3pYiE0_003D);
		_0023_003DzpPOEJqcAh7Lr.Add(new Face(analyticSurf2, _0023_003DzIgssic2TOqah, _0023_003Dzx3pYiE0_003D));
		return new Brep(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO.ToArray(), _0023_003DzpPOEJqcAh7Lr.ToArray(), null, tolerance);
	}

	private static void _0023_003DzrPhwbxuRz63c(ICurve[] _0023_003DzHq9_ZDPKuH6o, ICurve[][] _0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D, ICurve[] _0023_003DziOkfOjERhlX8, ICurve[][] _0023_003Dz5XeGAGdLNT1O0yOtGA_003D_003D, out Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out List<Edge> _0023_003DzU3hosSAzkxO7, out List<Face> _0023_003DzpPOEJqcAh7Lr, out Loop[] _0023_003Dz0yrVO2YPB2dr, out Loop[] _0023_003DzIgssic2TOqah, Dictionary<int, int> _0023_003Dzv5e_0024kkG_Q_0024La)
	{
		int num = _0023_003DzHq9_ZDPKuH6o.Length;
		int num2 = 0;
		for (int i = 0; i < _0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D.Length; i++)
		{
			num2 += _0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D[i].Length;
		}
		int num3 = num - 2 * _0023_003Dzv5e_0024kkG_Q_0024La.Count + num2;
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new Point3D[num3 * 2];
		_0023_003DzU3hosSAzkxO7 = new List<Edge>(num3 * 3);
		OrientedEdge[] array = new OrientedEdge[num];
		List<OrientedEdge> list = new List<OrientedEdge>(num);
		List<OrientedEdge>[] array2 = new List<OrientedEdge>[num];
		int num4 = 0;
		foreach (KeyValuePair<int, int> item2 in _0023_003Dzv5e_0024kkG_Q_0024La)
		{
			ICurve curve = (ICurve)_0023_003DzHq9_ZDPKuH6o[item2.Key].Clone();
			ICurve curve2 = (ICurve)_0023_003DziOkfOjERhlX8[item2.Key].Clone();
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num4++] = new Vertex(((Point3D)curve.StartPoint.Clone()).ToArray());
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num4++] = new Vertex(((Point3D)curve2.StartPoint.Clone()).ToArray());
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num4++] = new Vertex(((Point3D)curve.EndPoint.Clone()).ToArray());
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num4++] = new Vertex(((Point3D)curve2.EndPoint.Clone()).ToArray());
			_0023_003DzU3hosSAzkxO7.Add(new Edge(curve, num4 - 4, num4 - 2));
			curve.EdgeIndex = _0023_003DzU3hosSAzkxO7.Count - 1;
			_0023_003DzHq9_ZDPKuH6o[item2.Key].EdgeIndex = _0023_003DzU3hosSAzkxO7.Count - 1;
			_0023_003DzHq9_ZDPKuH6o[item2.Value].EdgeIndex = _0023_003DzU3hosSAzkxO7.Count - 1;
			_0023_003DzU3hosSAzkxO7.Add(new Edge(curve2, num4 - 3, num4 - 1));
			curve2.EdgeIndex = _0023_003DzU3hosSAzkxO7.Count - 1;
			_0023_003DziOkfOjERhlX8[item2.Key].EdgeIndex = _0023_003DzU3hosSAzkxO7.Count - 1;
			_0023_003DziOkfOjERhlX8[item2.Value].EdgeIndex = _0023_003DzU3hosSAzkxO7.Count - 1;
		}
		int count = _0023_003DzU3hosSAzkxO7.Count;
		int num5 = count;
		bool flag = false;
		bool flag2 = false;
		for (int j = 0; j < num; j++)
		{
			ICurve curve3 = (ICurve)_0023_003DzHq9_ZDPKuH6o[j].Clone();
			ICurve curve4 = (ICurve)_0023_003DziOkfOjERhlX8[j].Clone();
			int num6 = -1;
			int num7 = -1;
			int num8 = -1;
			int num9 = -1;
			int num10 = j - 1;
			if (j == 0)
			{
				flag = _0023_003Dzv5e_0024kkG_Q_0024La.ContainsKey(num - 1);
				bool flag3 = _0023_003Dzv5e_0024kkG_Q_0024La.ContainsValue(num - 1);
				flag2 = flag || flag3;
				num10 = num - 1;
			}
			bool flag4 = _0023_003Dzv5e_0024kkG_Q_0024La.ContainsKey(j);
			bool flag5 = _0023_003Dzv5e_0024kkG_Q_0024La.ContainsValue(j);
			bool flag6 = flag4 || flag5;
			bool flag7 = false;
			bool flag8 = false;
			if (j < num - 1)
			{
				flag7 = _0023_003Dzv5e_0024kkG_Q_0024La.ContainsKey(j + 1);
				bool flag9 = _0023_003Dzv5e_0024kkG_Q_0024La.ContainsValue(j + 1);
				flag8 = flag7 || flag9;
			}
			if (!flag6)
			{
				if (!flag2)
				{
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num4++] = new Vertex(((Point3D)curve3.StartPoint.Clone()).ToArray());
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num4++] = new Vertex(((Point3D)curve4.StartPoint.Clone()).ToArray());
					num6 = num4 - 2;
					num8 = num4 - 1;
					if (j > 0)
					{
						_0023_003DzU3hosSAzkxO7[_0023_003DzHq9_ZDPKuH6o[num10].EdgeIndex].EndPointIndex = num6;
						_0023_003DzU3hosSAzkxO7[_0023_003DziOkfOjERhlX8[num10].EdgeIndex].EndPointIndex = num8;
					}
				}
				else if (flag)
				{
					num6 = _0023_003DzU3hosSAzkxO7[_0023_003DzHq9_ZDPKuH6o[num10].EdgeIndex].EndPointIndex;
					num8 = _0023_003DzU3hosSAzkxO7[_0023_003DziOkfOjERhlX8[num10].EdgeIndex].EndPointIndex;
				}
				else
				{
					num6 = _0023_003DzU3hosSAzkxO7[_0023_003DzHq9_ZDPKuH6o[num10].EdgeIndex].StartPointIndex;
					num8 = _0023_003DzU3hosSAzkxO7[_0023_003DziOkfOjERhlX8[num10].EdgeIndex].StartPointIndex;
				}
				if (flag8)
				{
					if (flag7)
					{
						num7 = _0023_003DzU3hosSAzkxO7[_0023_003DzHq9_ZDPKuH6o[j + 1].EdgeIndex].StartPointIndex;
						num9 = _0023_003DzU3hosSAzkxO7[_0023_003DziOkfOjERhlX8[j + 1].EdgeIndex].StartPointIndex;
					}
					else
					{
						num7 = _0023_003DzU3hosSAzkxO7[_0023_003DzHq9_ZDPKuH6o[j + 1].EdgeIndex].EndPointIndex;
						num9 = _0023_003DzU3hosSAzkxO7[_0023_003DziOkfOjERhlX8[j + 1].EdgeIndex].EndPointIndex;
					}
				}
				if (j == num - 1)
				{
					if (num > 1)
					{
						num7 = _0023_003DzU3hosSAzkxO7[_0023_003DzHq9_ZDPKuH6o[0].EdgeIndex].StartPointIndex;
						num9 = _0023_003DzU3hosSAzkxO7[_0023_003DziOkfOjERhlX8[0].EdgeIndex].StartPointIndex;
					}
					else
					{
						num7 = num6;
						num9 = num8;
					}
				}
				int num11 = 0;
				int num12 = 0;
				int num13 = 0;
				num5++;
				if (!curve4.IsPoint)
				{
					num11 = num5;
					num5++;
				}
				num12 = num5;
				num5++;
				num13 = ((j + 1 != num) ? (num5 + 2) : (curve4.IsPoint ? 1 : 2));
				_0023_003DzU3hosSAzkxO7.Add(new Edge(curve3, num6, num7));
				int num14 = _0023_003DzU3hosSAzkxO7.Count - 1;
				array[j] = new OrientedEdge(num14);
				_0023_003DzHq9_ZDPKuH6o[j].EdgeIndex = num14;
				curve3.EdgeIndex = num14;
				if (!curve4.IsPoint)
				{
					_0023_003DzU3hosSAzkxO7.Add(new Edge(curve4, num8, num9));
					num11 = _0023_003DzU3hosSAzkxO7.Count - 1;
					list.Add(new OrientedEdge(num11));
					_0023_003DziOkfOjERhlX8[j].EdgeIndex = num11;
					curve4.EdgeIndex = num11;
				}
				bool flag10 = false;
				if (flag2)
				{
					int num15 = num6;
					int num16 = num8;
					for (int k = count; k < _0023_003DzU3hosSAzkxO7.Count; k++)
					{
						if (_0023_003DzU3hosSAzkxO7[k].StartPointIndex == num15 && _0023_003DzU3hosSAzkxO7[k].EndPointIndex == num16)
						{
							flag10 = true;
							num12 = k;
							break;
						}
					}
				}
				if (!flag10)
				{
					Line curve5 = new Line((Point3D)curve3.StartPoint.Clone(), (Point3D)curve4.StartPoint.Clone());
					_0023_003DzU3hosSAzkxO7.Add(new Edge(curve5, num6, num8));
					num12 = _0023_003DzU3hosSAzkxO7.Count - 1;
				}
				flag10 = false;
				if (flag8)
				{
					int num17 = num7;
					int num18 = num9;
					for (int l = count; l < _0023_003DzU3hosSAzkxO7.Count; l++)
					{
						if (_0023_003DzU3hosSAzkxO7[l].StartPointIndex == num17 && _0023_003DzU3hosSAzkxO7[l].EndPointIndex == num18)
						{
							flag10 = true;
							num13 = l;
							break;
						}
					}
					if (!flag10)
					{
						Line curve6 = new Line((Point3D)curve3.EndPoint.Clone(), (Point3D)curve4.EndPoint.Clone());
						_0023_003DzU3hosSAzkxO7.Add(new Edge(curve6, num17, num18));
						num13 = _0023_003DzU3hosSAzkxO7.Count - 1;
					}
				}
				array2[j] = new List<OrientedEdge>(4);
				array2[j].Add(new OrientedEdge(num14));
				array2[j].Add(new OrientedEdge(num13));
				if (!curve4.IsPoint)
				{
					array2[j].Add(new OrientedEdge(num11, sense: false));
				}
				array2[j].Add(new OrientedEdge(num12, sense: false));
			}
			else
			{
				array[j] = new OrientedEdge(_0023_003DzHq9_ZDPKuH6o[j].EdgeIndex, flag4);
				list.Add(new OrientedEdge(_0023_003DziOkfOjERhlX8[j].EdgeIndex, flag4));
			}
			flag = flag4;
			flag2 = flag6;
		}
		num5 = _0023_003DzU3hosSAzkxO7.Count;
		OrientedEdge[][] array3 = new OrientedEdge[_0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D.Length][];
		List<OrientedEdge>[] array4 = new List<OrientedEdge>[_0023_003Dz5XeGAGdLNT1O0yOtGA_003D_003D.Length];
		List<OrientedEdge>[][] array5 = new List<OrientedEdge>[_0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D.Length][];
		for (int m = 0; m < _0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D.Length; m++)
		{
			int num19 = _0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D[m].Length;
			array3[m] = new OrientedEdge[num19];
			array4[m] = new List<OrientedEdge>(num19);
			array5[m] = new List<OrientedEdge>[num19];
			int num20 = num5;
			int num21 = num4;
			for (int n = 0; n < num19; n++)
			{
				ICurve curve7 = (ICurve)_0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D[m][n].Clone();
				ICurve curve8 = (ICurve)_0023_003Dz5XeGAGdLNT1O0yOtGA_003D_003D[m][n].Clone();
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num4++] = new Vertex(((Point3D)curve7.StartPoint.Clone()).ToArray());
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num4++] = new Vertex(((Point3D)curve8.StartPoint.Clone()).ToArray());
				int curveIndex = num5;
				num5++;
				int curveIndex2 = 0;
				if (!curve8.IsPoint)
				{
					curveIndex2 = num5;
					num5++;
				}
				int curveIndex3 = num5;
				num5++;
				int curveIndex4 = ((n + 1 != num19) ? (num5 + 2) : ((!curve8.IsPoint) ? (num20 + 2) : (num20 + 1)));
				array3[m][n] = new OrientedEdge(curveIndex);
				_0023_003DzU3hosSAzkxO7.Add(new Edge(curve7, num4 - 2, (n == num19 - 1) ? num21 : num4));
				if (!curve8.IsPoint)
				{
					array4[m].Add(new OrientedEdge(curveIndex2));
					_0023_003DzU3hosSAzkxO7.Add(new Edge(curve8, num4 - 1, (n == num19 - 1) ? (num21 + 1) : (num4 + 1)));
				}
				Line curve9 = new Line((Point3D)curve7.StartPoint.Clone(), (Point3D)curve8.StartPoint.Clone());
				_0023_003DzU3hosSAzkxO7.Add(new Edge(curve9, num4 - 2, num4 - 1));
				array5[m][n] = new List<OrientedEdge>(4);
				array5[m][n].Add(new OrientedEdge(curveIndex));
				array5[m][n].Add(new OrientedEdge(curveIndex4));
				if (!curve8.IsPoint)
				{
					array5[m][n].Add(new OrientedEdge(curveIndex2, sense: false));
				}
				array5[m][n].Add(new OrientedEdge(curveIndex3, sense: false));
			}
		}
		_0023_003DzpPOEJqcAh7Lr = new List<Face>(num3 + 2);
		for (int num22 = 0; num22 < _0023_003DzHq9_ZDPKuH6o.Length; num22++)
		{
			bool num23 = _0023_003Dzv5e_0024kkG_Q_0024La.ContainsKey(num22);
			bool flag11 = _0023_003Dzv5e_0024kkG_Q_0024La.ContainsValue(num22);
			if (!(num23 || flag11))
			{
				Surface surface = Surface.Ruled(_0023_003DzHq9_ZDPKuH6o[num22], _0023_003DziOkfOjERhlX8[num22]);
				Surface surface2 = surface.Promote();
				if (surface2 != null)
				{
					surface = surface2;
				}
				Face item = new Face(surface._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D(), new Loop(array2[num22].ToArray()));
				_0023_003DzpPOEJqcAh7Lr.Add(item);
			}
		}
		for (int num24 = 0; num24 < _0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D.Length; num24++)
		{
			for (int num25 = 0; num25 < _0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D[num24].Length; num25++)
			{
				Surface surface3 = Surface.Ruled(_0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D[num24][num25], _0023_003Dz5XeGAGdLNT1O0yOtGA_003D_003D[num24][num25]);
				Surface surface4 = surface3.Promote();
				if (surface4 != null)
				{
					surface3 = surface4;
				}
				AnalyticSurf surface5 = surface3._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D();
				_0023_003DzpPOEJqcAh7Lr.Add(new Face(surface5, new Loop(array5[num24][num25].ToArray())));
			}
		}
		_0023_003Dz0yrVO2YPB2dr = new Loop[_0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D.Length + 1];
		_0023_003DzIgssic2TOqah = new Loop[_0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D.Length + 1];
		for (int num26 = 0; num26 < _0023_003DzPAdhhwXZ3pcnDVDKkg_003D_003D.Length + 1; num26++)
		{
			_0023_003Dz0yrVO2YPB2dr[num26] = ((num26 == 0) ? new Loop(array, sense: false) : new Loop(array3[num26 - 1], sense: false));
			_0023_003DzIgssic2TOqah[num26] = ((num26 == 0) ? new Loop(list.ToArray()) : new Loop(array4[num26 - 1].ToArray()));
		}
	}

	public static Brep Loft(params ICurve[] curveList)
	{
		return Loft(curveList, 3, splitAtCorners: true, endCaps: true, speedChange: true);
	}

	public static Brep Loft(IList<ICurve> curveList, int degree, bool splitAtCorners = true, bool endCaps = true, bool speedChange = false, double tolerance = 0.0)
	{
		if (tolerance == 0.0)
		{
			tolerance = 0.001;
		}
		Utility._0023_003Dz8nLh4eo_003D(curveList.Count, ref degree);
		bool flag = curveList[0] is Point;
		bool _0023_003DzV_0024XrwDgXItsG = curveList[curveList.Count - 1] is Point;
		bool flag2 = (flag ? curveList[1].IsClosed : curveList[0].IsClosed);
		bool _0023_003DzEt2Zcy_TSPx_0024 = false;
		if (!flag2 && endCaps)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960025));
		}
		for (int i = 0; i < curveList.Count; i++)
		{
			if (i != curveList.Count - 1 && i != 0 && curveList[i] is Point)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959688));
			}
			if (curveList[i].IsClosed != flag2 && ((i != 0 && i != curveList.Count - 1) || !(curveList[i] is Point)))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959870));
			}
		}
		Surface[] array = Surface.Loft(curveList, degree, splitAtCorners, speedChange);
		int num = array.Length;
		OrientedEdge[][] array2 = new OrientedEdge[2][];
		ICurve curve = null;
		Plane plane = null;
		Plane plane2 = null;
		if (endCaps)
		{
			array2[0] = new OrientedEdge[num];
			array2[1] = new OrientedEdge[num];
			double tol = curveList[0].GetNurbsForm().ControlBoundingBox().Diagonal * 1E-09;
			double tol2 = curveList[curveList.Count - 1].GetNurbsForm().ControlBoundingBox().Diagonal * 1E-09;
			if (!curveList[0].IsPlanar(tol, out plane) || !curveList[curveList.Count - 1].IsPlanar(tol2, out plane2))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959805));
			}
			curve = array[0].IsocurveU(array[0].DomainV.Low);
			if (!(Vector3D.Dot(plane.AxisZ, curve.StartTangent) < 1E-06))
			{
				_0023_003DzEt2Zcy_TSPx_0024 = true;
			}
		}
		Brep brep = _0023_003DzBm9smVnM6zqdm6MLOA_003D_003D(array, plane, plane2, array2, endCaps, flag2, _0023_003DzEt2Zcy_TSPx_0024, flag, _0023_003DzV_0024XrwDgXItsG);
		brep.RebuildTolerance = tolerance;
		return brep;
	}

	public static Brep Sweep(IList<ICurve> sections, ICurve rail, bool endCaps = true, double tolerance = 0.0)
	{
		if (sections.Count < 2)
		{
			return null;
		}
		if (tolerance == 0.0)
		{
			tolerance = 0.001;
		}
		List<Surface> list = new List<Surface>();
		ICurve[] array = null;
		ICurve curve = rail.GetNurbsForm();
		for (int i = 0; i < sections.Count; i++)
		{
			ICurve curve2 = sections[i];
			ICurve[] individualCurves = curve2.GetIndividualCurves();
			if (!curve2.IsPlanar(tolerance, out var plane))
			{
				return null;
			}
			Point3D[] array2 = ((Curve)curve).IntersectWith(plane, tolerance);
			if (array2.Length != 1)
			{
				return null;
			}
			rail.Project(array2[0], out var t);
			if (Vector3D.Dot(rail.TangentAt(t), plane.AxisZ) < 0.0)
			{
				curve2 = (ICurve)sections[i].Clone();
				curve2.Reverse();
			}
			ICurve curve3 = null;
			if (curve.SplitAt(((InterPoint)array2[0]).u, out var lower, out var upper))
			{
				curve = lower;
				curve3 = upper;
			}
			else
			{
				curve3 = curve;
			}
			if (i == 0)
			{
				if (endCaps)
				{
					Region region = new Region(curve2);
					region.FlipNormal();
					list.Add(region.ConvertToSurface());
				}
			}
			else
			{
				if (array.Length != individualCurves.Length)
				{
					return null;
				}
				for (int j = 0; j < array.Length; j++)
				{
					ICurve curve4 = array[j];
					ICurve curve5 = individualCurves[j];
					Curve curve6 = (Curve)curve.Clone();
					curve6.TransformBy(Transformation.CreateTranslation(new Vector3D(curve6.StartPoint, curve4.StartPoint)));
					Transformation xform = Transformation.CreateTranslation(new Vector3D(curve6.EndPoint, curve5.StartPoint));
					for (int k = 1; k < curve6.Degree; k++)
					{
						curve6.ControlPoints[curve6.ControlPoints.Length - k].TransformBy(xform);
					}
					Curve curve7 = (Curve)curve.Clone();
					curve7.TransformBy(Transformation.CreateTranslation(new Vector3D(curve7.StartPoint, curve4.EndPoint)));
					Transformation xform2 = Transformation.CreateTranslation(new Vector3D(curve7.EndPoint, curve5.EndPoint));
					for (int l = 1; l < curve7.Degree; l++)
					{
						curve7.ControlPoints[curve7.ControlPoints.Length - l].TransformBy(xform2);
					}
					Surface item = Surface.Gordon(new List<ICurve> { curve4, curve5 }, new List<ICurve> { curve6, curve7 }, tolerance);
					list.Add(item);
				}
			}
			array = individualCurves;
			curve = curve3;
		}
		if (endCaps)
		{
			Region region2 = new Region(sections[sections.Count - 1]);
			list.Add(region2.ConvertToSurface());
		}
		Solidifier solidifier = new Solidifier(list, tolerance);
		solidifier.DoWork();
		return solidifier.Result;
	}

	public static Brep ExtrudeWithTwist(ICurve curve, Vector3D direction, Point3D center, double angle, double tol, bool endCaps = true)
	{
		int numberOfSections = Surface._0023_003Dz1wWtcT5Ea1zq(curve.GetNurbsForm(), center, angle, tol);
		return ExtrudeWithTwist(curve, direction, center, angle, numberOfSections, endCaps, tol);
	}

	public static Brep ExtrudeWithTwist(ICurve curve, Vector3D direction, Point3D center, double angle, int numberOfSections, bool endCaps = true, double rebuildTol = 0.0)
	{
		if (rebuildTol == 0.0)
		{
			rebuildTol = 0.0;
		}
		bool isClosed = curve.IsClosed;
		bool _0023_003DzEt2Zcy_TSPx_0024 = false;
		if (curve is Point)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960481));
		}
		if (!isClosed && endCaps)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960025));
		}
		Surface[] array = Surface.ExtrudeWithTwist(curve, direction, center, angle, numberOfSections);
		Surface[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].SwapUV();
		}
		int num = array.Length;
		OrientedEdge[][] array3 = new OrientedEdge[2][];
		ICurve curve2 = null;
		Plane plane = null;
		Plane plane2 = null;
		if (endCaps)
		{
			array3[0] = new OrientedEdge[num];
			array3[1] = new OrientedEdge[num];
			double tol = curve.GetNurbsForm().ControlBoundingBox().Diagonal * 1E-09;
			if (!curve.IsPlanar(tol, out plane))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959805));
			}
			plane2 = (Plane)plane.Clone();
			plane2.Translate(direction);
			plane2.Rotate(angle, direction, center);
			curve2 = array[0].IsocurveU(array[0].DomainV.Low);
			if (!(Vector3D.Dot(plane.AxisZ, curve2.StartTangent) < 1E-06))
			{
				_0023_003DzEt2Zcy_TSPx_0024 = true;
			}
		}
		Brep brep = _0023_003DzBm9smVnM6zqdm6MLOA_003D_003D(array, plane, plane2, array3, endCaps, isClosed, _0023_003DzEt2Zcy_TSPx_0024, _0023_003Dz02NThXOJnnrg: false, _0023_003DzV_0024XrwDgXItsG: false);
		if (rebuildTol > 0.0)
		{
			brep.RebuildTolerance = rebuildTol;
		}
		return brep;
	}

	private static bool _0023_003DzuifiG3ZAhApi(Face _0023_003Dzn6eRxNucSNoK, Face _0023_003DzcQpPRG5mmRCF, Edge[] _0023_003Dz7taeRywG__0024W_0024, Edge[] _0023_003DzV4Y4B9UvCfhj, ref Dictionary<int, int> _0023_003DznOxom2vgXvVl)
	{
		List<ICurve> list = new List<ICurve>();
		ICurve[] orientedTrimLoops = _0023_003Dzn6eRxNucSNoK.GetOrientedTrimLoops(_0023_003Dz7taeRywG__0024W_0024);
		for (int i = 0; i < orientedTrimLoops.Length; i++)
		{
			ICurve[] individualCurves = orientedTrimLoops[i].GetIndividualCurves();
			foreach (ICurve curve in individualCurves)
			{
				list.Add((ICurve)curve.Clone());
			}
		}
		List<ICurve> list2 = new List<ICurve>();
		orientedTrimLoops = _0023_003DzcQpPRG5mmRCF.GetOrientedTrimLoops(_0023_003DzV4Y4B9UvCfhj);
		for (int i = 0; i < orientedTrimLoops.Length; i++)
		{
			ICurve[] individualCurves = orientedTrimLoops[i].GetIndividualCurves();
			foreach (ICurve curve2 in individualCurves)
			{
				list2.Add((ICurve)curve2.Clone());
			}
		}
		if (list.Count != list2.Count)
		{
			return false;
		}
		for (int k = 0; k < list.Count; k++)
		{
			ICurve curve3 = list[k];
			int l = 0;
			for (int count = list2.Count; l < count; l++)
			{
				ICurve curve4 = list2[l];
				if (Utility.AreCurvesEqualsOrOpposite(curve3, curve4, checkOpposite: true))
				{
					if (!_0023_003DznOxom2vgXvVl.ContainsKey(curve4.EdgeIndex))
					{
						_0023_003DznOxom2vgXvVl.Add(curve4.EdgeIndex, curve3.EdgeIndex);
					}
					list2.RemoveAt(l);
					break;
				}
			}
		}
		if (list2.Count == 0)
		{
			return true;
		}
		return false;
	}

	internal void _0023_003DzBvKljzDhzeqN(int[] _0023_003Dzfe2zeQMumw_4, Brep _0023_003DzV_0024cl2oc_003D, int[] _0023_003DzW8Cnc29uFlYc, int[] _0023_003DzTfaySF4f3gY4, bool _0023_003Dz7Fxltek9kn7U)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		Dictionary<int, int> _0023_003DznOxom2vgXvVl = new Dictionary<int, int>();
		Dictionary<int, int> _0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D = new Dictionary<int, int>();
		for (int i = 0; i < _0023_003Dzfe2zeQMumw_4.Length; i++)
		{
			if (_0023_003Dzfe2zeQMumw_4[i] != -1)
			{
				Face _0023_003Dzn6eRxNucSNoK = Faces[_0023_003Dzfe2zeQMumw_4[i]];
				Face face = _0023_003DzV_0024cl2oc_003D.Faces[_0023_003DzW8Cnc29uFlYc[i]];
				if (_0023_003Dz7Fxltek9kn7U)
				{
					face.Loops[0].Sense = !face.Loops[0].Sense;
				}
				dictionary.Add(_0023_003DzW8Cnc29uFlYc[i], _0023_003Dzfe2zeQMumw_4[i]);
				if (!_0023_003DzuifiG3ZAhApi(_0023_003Dzn6eRxNucSNoK, face, Edges, _0023_003DzV_0024cl2oc_003D.Edges, ref _0023_003DznOxom2vgXvVl))
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960429));
				}
				_0023_003DzexlinmBd63Hvfg3dNg_003D_003D(this, _0023_003DzV_0024cl2oc_003D, face, _0023_003DznOxom2vgXvVl, _0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D);
			}
		}
		Brep brep = _0023_003Dzvsag8z_YSTdoVQOKsa9XViI_003D(this, _0023_003DzV_0024cl2oc_003D, _0023_003Dz7Fxltek9kn7U, dictionary, _0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D, _0023_003DznOxom2vgXvVl, _0023_003Dzfe2zeQMumw_4[0], _0023_003DzTfaySF4f3gY4[0], _0023_003DzJVWkwrC6nEkD: false);
		_0023_003Dzd55uIPSKitfg(brep.Vertices, brep.Edges, brep.Faces, brep.Inners);
	}

	internal static void _0023_003Dze_0024eVclnuDv0s(Surface _0023_003DzF7GfYSI_003D, AnalyticSurf _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D, ref bool _0023_003Dzx3pYiE0_003D)
	{
		if (_0023_003DzF7GfYSI_003D is SphericalSurface sphericalSurface && !(_0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D is RevolvedSurf))
		{
			if (sphericalSurface.Generatrix is Arc && Vector3D.AreOpposite(((Arc)sphericalSurface.Generatrix).Plane.AxisZ, sphericalSurface.SeamPlane.AxisZ))
			{
				_0023_003Dzx3pYiE0_003D = !_0023_003Dzx3pYiE0_003D;
			}
		}
		else if (_0023_003DzF7GfYSI_003D is CylindricalSurface cylindricalSurface)
		{
			if (Vector3D.AreOpposite(((Line)cylindricalSurface.Generatrix).StartTangent, ((PlanarSurf)_0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D).Plane.AxisX))
			{
				_0023_003Dzx3pYiE0_003D = !_0023_003Dzx3pYiE0_003D;
			}
			else if (Vector3D.AngleBetween(cylindricalSurface.Generatrix.StartTangent, ((PlanarSurf)_0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D).Plane.AxisZ) > Math.PI / 2.0)
			{
				_0023_003Dzx3pYiE0_003D = !_0023_003Dzx3pYiE0_003D;
			}
		}
	}

	private static Brep _0023_003DzBm9smVnM6zqdm6MLOA_003D_003D(Surface[] _0023_003DzZI2Hrmt4xzgu, Plane _0023_003DzbljtdnBsXAMO, Plane _0023_003Dz2B9ytOJprTom, OrientedEdge[][] _0023_003DzESnjam3ybi_0024c, bool _0023_003Dz5q1w0P79Gecn, bool _0023_003DzbErHvVw_003D, bool _0023_003DzEt2Zcy_TSPx_0024, bool _0023_003Dz02NThXOJnnrg, bool _0023_003DzV_0024XrwDgXItsG)
	{
		int num = _0023_003DzZI2Hrmt4xzgu.Length;
		int num2 = (_0023_003Dz02NThXOJnnrg ? 1 : (num + ((!_0023_003DzbErHvVw_003D) ? 1 : 0)));
		int num3 = (_0023_003DzV_0024XrwDgXItsG ? 1 : (num + ((!_0023_003DzbErHvVw_003D) ? 1 : 0)));
		int num4 = num * 2;
		int num5 = num2 + num3;
		int num6 = num + num4 + ((!_0023_003DzbErHvVw_003D) ? 1 : 0);
		Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new Point3D[num5];
		Edge[] _0023_003DzU3hosSAzkxO = new Edge[num6];
		OrientedEdge[][] _0023_003DzTRVdRDR0thzn = new OrientedEdge[num][];
		List<Face> list = new List<Face>();
		ICurve curve = null;
		ICurve curve2 = null;
		ICurve curve3 = null;
		ICurve curve4 = null;
		Surface surface = null;
		for (int i = 0; i < num; i++)
		{
			surface = _0023_003DzZI2Hrmt4xzgu[i];
			curve = surface.IsocurveU(surface.DomainV.Low);
			curve2 = surface.IsocurveU(surface.DomainV.High);
			curve3 = surface.IsocurveV(surface.DomainU.Low);
			curve4 = surface.IsocurveV(surface.DomainU.High);
			int num7 = num2;
			if (!_0023_003Dz02NThXOJnnrg || i == 0)
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i] = new Vertex(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z);
			}
			if (!_0023_003DzV_0024XrwDgXItsG || i == 0)
			{
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i + num7] = new Vertex(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z);
			}
			double num8 = 1E-12;
			int startPointIndex = ((!_0023_003Dz02NThXOJnnrg) ? i : 0);
			int num9 = (_0023_003DzV_0024XrwDgXItsG ? num7 : (i + num7));
			int num10 = (i + 1) % Math.Max(num, num2);
			int endPointIndex = (i + 1) % num3 + num7;
			_0023_003DzU3hosSAzkxO[i] = ((!_0023_003Dz02NThXOJnnrg) ? new Edge(curve3, startPointIndex, num10) : null);
			_0023_003DzU3hosSAzkxO[i + num6 / 3] = ((!_0023_003DzV_0024XrwDgXItsG) ? new Edge(curve4, num9, endPointIndex) : null);
			_0023_003DzU3hosSAzkxO[i + num6 * 2 / 3] = ((curve.Length() > num8) ? new Edge(curve, startPointIndex, num9) : null);
			_0023_003DzTRVdRDR0thzn[i] = new OrientedEdge[4];
			int num11 = i;
			_0023_003DzTRVdRDR0thzn[i][2] = new OrientedEdge((_0023_003DzU3hosSAzkxO[num11] != null) ? num11 : (-1), sense: false);
			num11 = num10 + num6 * 2 / 3;
			_0023_003DzTRVdRDR0thzn[i][1] = new OrientedEdge((curve2.Length() > 0.0) ? num11 : (-1), sense: false);
			num11 = i + num6 / 3;
			_0023_003DzTRVdRDR0thzn[i][0] = new OrientedEdge((_0023_003DzU3hosSAzkxO[num11] != null) ? num11 : (-1));
			num11 = i + num6 * 2 / 3;
			_0023_003DzTRVdRDR0thzn[i][3] = new OrientedEdge((_0023_003DzU3hosSAzkxO[num11] != null) ? num11 : (-1));
			if (_0023_003Dz5q1w0P79Gecn)
			{
				_0023_003DzESnjam3ybi_0024c[0][i] = new OrientedEdge(i);
				_0023_003DzESnjam3ybi_0024c[1][i] = new OrientedEdge(i + num6 / 3);
			}
			AnalyticSurf surface2 = new NurbsSurf(surface.DegreeU, surface.KnotVectorU, surface.DegreeV, surface.KnotVectorV, surface.ControlPoints, i);
			list.Add(new Face(surface2, new Loop(_0023_003DzTRVdRDR0thzn[i], !_0023_003DzEt2Zcy_TSPx_0024), !_0023_003DzEt2Zcy_TSPx_0024));
		}
		if (!_0023_003DzbErHvVw_003D)
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num5 / 2 - 1] = new Vertex(curve2.StartPoint.X, curve2.StartPoint.Y, curve2.StartPoint.Z);
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num5 - 1] = new Vertex(curve2.EndPoint.X, curve2.EndPoint.Y, curve2.EndPoint.Z);
			curve2 = surface.IsocurveU(surface.DomainV.High);
			_0023_003DzU3hosSAzkxO[^1] = new Edge(curve2, num5 / 2 - 1, num5 - 1);
		}
		if (_0023_003Dz5q1w0P79Gecn)
		{
			if (!_0023_003Dz02NThXOJnnrg)
			{
				PlanarSurf surface3 = new PlanarSurf(_0023_003DzbljtdnBsXAMO.Origin, _0023_003DzbljtdnBsXAMO.AxisZ, _0023_003DzbljtdnBsXAMO.AxisX);
				list.Add(new Face(surface3, new Loop(_0023_003DzESnjam3ybi_0024c[0], !_0023_003DzEt2Zcy_TSPx_0024), !_0023_003DzEt2Zcy_TSPx_0024));
			}
			if (!_0023_003DzV_0024XrwDgXItsG)
			{
				PlanarSurf surface4 = new PlanarSurf(_0023_003Dz2B9ytOJprTom.Origin, _0023_003Dz2B9ytOJprTom.AxisZ, _0023_003Dz2B9ytOJprTom.AxisX);
				list.Add(new Face(surface4, new Loop(_0023_003DzESnjam3ybi_0024c[1], _0023_003DzEt2Zcy_TSPx_0024), _0023_003DzEt2Zcy_TSPx_0024));
			}
		}
		Face[] _0023_003DzpPOEJqcAh7Lr = list.ToArray();
		_0023_003DzYEiUlcDf0Wve(num2, num6 / 3, 0, 0, ref _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, ref _0023_003DzU3hosSAzkxO, ref _0023_003DzTRVdRDR0thzn, ref _0023_003DzpPOEJqcAh7Lr, ref _0023_003DzESnjam3ybi_0024c[1]);
		return new Brep(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO, _0023_003DzpPOEJqcAh7Lr);
	}

	private static void _0023_003Dzcg4Fe1KpKEim(List<Face> _0023_003DzpPOEJqcAh7Lr, PlanarSurf _0023_003DzjGoXlKw_003D, PlanarSurf _0023_003Dz1FonMC4_003D, Loop[] _0023_003DzEKCukvZX6CmZ, Loop[] _0023_003DzejljNeqAHKTg, bool _0023_003Dzbu8BV15Qqzan)
	{
		Face item = new Face(_0023_003DzjGoXlKw_003D, _0023_003DzEKCukvZX6CmZ, _0023_003Dzbu8BV15Qqzan);
		Face item2 = new Face(_0023_003Dz1FonMC4_003D, _0023_003DzejljNeqAHKTg, !_0023_003Dzbu8BV15Qqzan);
		_0023_003DzpPOEJqcAh7Lr.Add(item);
		_0023_003DzpPOEJqcAh7Lr.Add(item2);
	}

	private static void _0023_003Dz5CLQsFJmJqrC9s7TRtPzUnc_003D(ICurve _0023_003Dz06A5WivSSyUp, Vector3D _0023_003DzYNjcavt9guh2, int _0023_003Dz1OARlKY_003D, int _0023_003Dzjt29dMs_003D, bool _0023_003Dzbu8BV15Qqzan, out Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out Edge[] _0023_003DzU3hosSAzkxO7, out Face[] _0023_003DzpPOEJqcAh7Lr, out Loop _0023_003Dz_0024SsLohloknxt, out Loop _0023_003DzuYjXyyijq2Xy)
	{
		Utility._0023_003Dzdh_4OQddxCSDDYZ27Q_003D_003D(_0023_003Dz06A5WivSSyUp, 0.0, _0023_003DzFSLBkBecx_0024NX: false, out var _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, _0023_003Dz6SBnzmNnw6lO: false);
		int num = _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length;
		int num2;
		if (_0023_003Dz06A5WivSSyUp.IsClosed)
		{
			num2 = _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length;
			Point3D[] array = new Vertex[num2 * 2];
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = array;
			_0023_003DzU3hosSAzkxO7 = new Edge[num2 * 3];
			_0023_003DzpPOEJqcAh7Lr = new Face[num2];
		}
		else
		{
			num2 = _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length + 1;
			Point3D[] array = new Vertex[num2 * 2];
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = array;
			_0023_003DzU3hosSAzkxO7 = new Edge[num2 * 3 - 2];
			_0023_003DzpPOEJqcAh7Lr = new Face[num2 - 1];
		}
		for (int i = 0; i < num2; i++)
		{
			Point3D point3D = ((!_0023_003Dz06A5WivSSyUp.IsClosed && i >= num2 - 1) ? ((Point3D)_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[i - 1].EndPoint.Clone()) : ((Point3D)_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[i].StartPoint.Clone()));
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i] = new Vertex(point3D.X, point3D.Y, point3D.Z);
			point3D.TransformBy(new Translation(_0023_003DzYNjcavt9guh2));
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num2 + i] = new Vertex(point3D.X, point3D.Y, point3D.Z);
		}
		for (int j = 0; j < num; j++)
		{
			int num3 = (j + 1) % num2;
			int num4 = _0023_003Dz1OARlKY_003D + num2;
			Entity entity = (Entity)_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[j].Clone();
			_0023_003DzU3hosSAzkxO7[j] = new Edge((ICurve)entity.Clone(), j + _0023_003Dz1OARlKY_003D, _0023_003Dz1OARlKY_003D + num3);
			entity.TransformBy(new Translation(_0023_003DzYNjcavt9guh2));
			_0023_003DzU3hosSAzkxO7[num + j] = new Edge((ICurve)entity.Clone(), num4 + j, num4 + num3);
			_0023_003DzU3hosSAzkxO7[num * 2 + j] = new Edge(new Line((Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[j].Clone(), (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[j + num2].Clone()), _0023_003Dz1OARlKY_003D + j, num4 + j);
		}
		if (!_0023_003Dz06A5WivSSyUp.IsClosed)
		{
			_0023_003DzU3hosSAzkxO7[_0023_003DzU3hosSAzkxO7.Length - 1] = new Edge(new Line((Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num2 - 1].Clone(), (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num2 * 2 - 1].Clone()), _0023_003Dz1OARlKY_003D + num2 - 1, _0023_003Dz1OARlKY_003D + num2 * 2 - 1);
		}
		OrientedEdge[][] array2 = new OrientedEdge[num][];
		OrientedEdge[] array3 = new OrientedEdge[num];
		OrientedEdge[] array4 = new OrientedEdge[num];
		for (int k = 0; k < num; k++)
		{
			array2[k] = new OrientedEdge[4];
			array2[k][0] = new OrientedEdge(_0023_003Dzjt29dMs_003D + k);
			array2[k][1] = new OrientedEdge(_0023_003Dzjt29dMs_003D + num * 2 + (k + 1) % num2);
			array2[k][2] = new OrientedEdge(_0023_003Dzjt29dMs_003D + num + k, sense: false);
			array2[k][3] = new OrientedEdge(_0023_003Dzjt29dMs_003D + num * 2 + k, sense: false);
			array3[k] = new OrientedEdge(_0023_003Dzjt29dMs_003D + k);
			array4[k] = new OrientedEdge(_0023_003Dzjt29dMs_003D + num + k);
		}
		_0023_003Dz_0024SsLohloknxt = new Loop(array3, _0023_003Dzbu8BV15Qqzan);
		_0023_003DzuYjXyyijq2Xy = new Loop(array4, !_0023_003Dzbu8BV15Qqzan);
		TabulatedSurf[] array5 = new TabulatedSurf[num];
		for (int l = 0; l < num; l++)
		{
			array5[l] = new TabulatedSurf((ICurve)_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[l].Clone(), (Vector3D)_0023_003DzYNjcavt9guh2.Clone(), _0023_003Dz1OARlKY_003D + l);
			if (_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[l] is Arc)
			{
				double _0023_003Dz6pajdGM_003D;
				Arc arc = Utility._0023_003DzCVWMRix_XDAPR23xLg_003D_003D((Arc)_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[l], out _0023_003Dz6pajdGM_003D);
				if (arc != null)
				{
					array5[l] = new TabulatedSurf(arc, (Vector3D)_0023_003DzYNjcavt9guh2.Clone(), _0023_003Dz1OARlKY_003D + l);
				}
			}
			_0023_003DzpPOEJqcAh7Lr[l] = new Face(array5[l], new Loop[1]
			{
				new Loop(array2[l], !_0023_003Dzbu8BV15Qqzan)
			}, !_0023_003Dzbu8BV15Qqzan);
		}
	}

	private static void _0023_003DzYEiUlcDf0Wve(int _0023_003Dz1OARlKY_003D, int _0023_003Dzjt29dMs_003D, int _0023_003DzZUeQ8pA_003D, int _0023_003DzUg7v6eo_003D, ref Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, ref Edge[] _0023_003DzU3hosSAzkxO7, ref OrientedEdge[][] _0023_003DzTRVdRDR0thzn, ref Face[] _0023_003DzpPOEJqcAh7Lr, ref OrientedEdge[] _0023_003Dzlofx_002495jBe1J)
	{
		int[] array = new int[_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length];
		int[] array2 = new int[_0023_003DzU3hosSAzkxO7.Length];
		List<Edge> list = new List<Edge>(_0023_003DzU3hosSAzkxO7.Length);
		List<Point3D> list2 = new List<Point3D>(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length);
		List<OrientedEdge[]> list3 = new List<OrientedEdge[]>(_0023_003DzTRVdRDR0thzn.Length);
		List<Face> list4 = new List<Face>(_0023_003DzpPOEJqcAh7Lr.Length);
		int i;
		for (i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length; i++)
		{
			if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i] != null)
			{
				list2.Add(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]);
				array[i] = _0023_003DzZUeQ8pA_003D + list2.Count - 1;
			}
			else
			{
				array[i] = _0023_003DzZUeQ8pA_003D + i - _0023_003Dz1OARlKY_003D;
			}
		}
		for (i = 0; i < _0023_003DzU3hosSAzkxO7.Length; i++)
		{
			if (_0023_003DzU3hosSAzkxO7[i] != null)
			{
				if (_0023_003DzU3hosSAzkxO7[i].StartPointIndex != -1)
				{
					_0023_003DzU3hosSAzkxO7[i].StartPointIndex = array[_0023_003DzU3hosSAzkxO7[i].StartPointIndex - _0023_003DzZUeQ8pA_003D];
					_0023_003DzU3hosSAzkxO7[i].EndPointIndex = array[_0023_003DzU3hosSAzkxO7[i].EndPointIndex - _0023_003DzZUeQ8pA_003D];
					list.Add(_0023_003DzU3hosSAzkxO7[i]);
					array2[i] = _0023_003DzUg7v6eo_003D + list.Count - 1;
				}
				else
				{
					array2[i] = _0023_003DzUg7v6eo_003D + i - _0023_003Dzjt29dMs_003D;
				}
			}
		}
		for (i = 0; i < _0023_003DzTRVdRDR0thzn.Length; i++)
		{
			List<OrientedEdge> list5 = new List<OrientedEdge>();
			if (_0023_003DzTRVdRDR0thzn[i][0].CurveIndex != -1)
			{
				OrientedEdge item = new OrientedEdge(array2[_0023_003DzTRVdRDR0thzn[i][0].CurveIndex - _0023_003DzUg7v6eo_003D], _0023_003DzTRVdRDR0thzn[i][0].Sense);
				list5.Add(item);
			}
			if (_0023_003DzTRVdRDR0thzn[i].Length > 1 && _0023_003DzTRVdRDR0thzn[i][1].CurveIndex != -1)
			{
				OrientedEdge item = new OrientedEdge(array2[_0023_003DzTRVdRDR0thzn[i][1].CurveIndex - _0023_003DzUg7v6eo_003D], _0023_003DzTRVdRDR0thzn[i][1].Sense);
				list5.Add(item);
			}
			if (_0023_003DzTRVdRDR0thzn[i].Length > 2 && _0023_003DzTRVdRDR0thzn[i][2].CurveIndex != -1)
			{
				OrientedEdge item = new OrientedEdge(array2[_0023_003DzTRVdRDR0thzn[i][2].CurveIndex - _0023_003DzUg7v6eo_003D], _0023_003DzTRVdRDR0thzn[i][2].Sense);
				list5.Add(item);
			}
			if (_0023_003DzTRVdRDR0thzn[i].Length > 3 && _0023_003DzTRVdRDR0thzn[i][3].CurveIndex != -1)
			{
				OrientedEdge item = new OrientedEdge(array2[_0023_003DzTRVdRDR0thzn[i][3].CurveIndex - _0023_003DzUg7v6eo_003D], _0023_003DzTRVdRDR0thzn[i][3].Sense);
				list5.Add(item);
			}
			if (_0023_003Dzlofx_002495jBe1J != null)
			{
				_0023_003Dzlofx_002495jBe1J[i].CurveIndex = array2[_0023_003Dzlofx_002495jBe1J[i].CurveIndex - _0023_003DzUg7v6eo_003D];
			}
			if (list5.Count >= 3 || list5.Count < 2 || !(list[list5[0].CurveIndex].Curve is Line) || !(list[list5[1].CurveIndex].Curve is Line))
			{
				list3.Add(list5.ToArray());
				_0023_003DzpPOEJqcAh7Lr[i].Loops = new Loop[1]
				{
					new Loop(list5.ToArray(), _0023_003DzpPOEJqcAh7Lr[i].Loops[0].Sense)
				};
				list4.Add(_0023_003DzpPOEJqcAh7Lr[i]);
			}
		}
		for (; i < _0023_003DzpPOEJqcAh7Lr.Length; i++)
		{
			list4.Add(_0023_003DzpPOEJqcAh7Lr[i]);
		}
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = list2.ToArray();
		_0023_003DzU3hosSAzkxO7 = list.ToArray();
		_0023_003DzTRVdRDR0thzn = list3.ToArray();
		_0023_003DzpPOEJqcAh7Lr = list4.ToArray();
	}

	internal void _0023_003Dzd55uIPSKitfg(Point3D[] _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, Edge[] _0023_003DzViGQVPM_003D, Face[] _0023_003DzUbkxYVFDH3ry, Face[][] _0023_003Dzkr1E5lj_m8iE)
	{
		_vertices = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D;
		_edges = _0023_003DzViGQVPM_003D;
		_faces = _0023_003DzUbkxYVFDH3ry;
		_inners = _0023_003Dzkr1E5lj_m8iE;
		RegenMode = regenType.RegenAndCompile;
	}

	internal virtual void _0023_003Dzn7CZziZi_8snx0i8Sg_003D_003D()
	{
		if (_convexHull != null)
		{
			return;
		}
		Point3D point3D = new Point3D();
		int num = 0;
		List<Point3D> list = new List<Point3D>(_vertices.Length);
		Face[] faces = Faces;
		foreach (Face face in faces)
		{
			if (face.Parametric == null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960616));
			}
			Surface[] parametric = face.Parametric;
			foreach (Surface surface in parametric)
			{
				if (surface.shrunk == null)
				{
					surface._0023_003DzIQv8kUn9rJJPHOmQIg_003D_003D();
				}
				Point3D _0023_003DzbUvT9Pc_003D;
				Point3D _0023_003DzF7v9r2A_003D;
				Point3D _0023_003Dz8dK2uhU_003D;
				Point3D[] collection = surface.shrunk._0023_003DzSeLFiVq6QTTq(out _0023_003DzbUvT9Pc_003D, out _0023_003DzF7v9r2A_003D, out _0023_003Dz8dK2uhU_003D);
				point3D += _0023_003DzbUvT9Pc_003D;
				num++;
				list.AddRange(collection);
			}
		}
		point3D /= (double)num;
		for (int k = 0; k < list.Count; k++)
		{
			Vector3D vector3D = new Vector3D(point3D, list[k]);
			list[k] = point3D + vector3D * (1.0 + _rebuildTol);
		}
		_convexHull = Utility.ConvexHull(list, 0.0, fixNormal: false);
	}

	public bool IsTangent(int edgeIndex)
	{
		return _0023_003DzBoG8A9MoyXqm(_faces, _edges[edgeIndex], _edges[edgeIndex].Curve.Domain.Mid);
	}

	public bool IsTangentAt(double t, int edgeIndex)
	{
		return _0023_003DzBoG8A9MoyXqm(_faces, _edges[edgeIndex], t);
	}

	private static bool _0023_003DzBoG8A9MoyXqm(Face[] _0023_003DzpPOEJqcAh7Lr, Edge _0023_003DzTx2aqr8_003D, double _0023_003DzNDQ_E88_003D)
	{
		Face face = _0023_003DzpPOEJqcAh7Lr[_0023_003DzTx2aqr8_003D.Parents[0]];
		Face face2 = _0023_003DzpPOEJqcAh7Lr[_0023_003DzTx2aqr8_003D.Parents[1]];
		Point3D point = _0023_003DzTx2aqr8_003D.Curve.PointAt(_0023_003DzNDQ_E88_003D);
		Vector3D u = face.Normal(point);
		Vector3D v = face2.Normal(point);
		return Vector3D.AreCoincident(u, v);
	}

	public Region GetPlanarFaceRegion(int index)
	{
		Face face = _faces[index];
		if (face.Surface is PlanarSurf planarSurf)
		{
			return new Region(face.GetOrientedTrimLoops(_edges), planarSurf.Plane);
		}
		return null;
	}

	private Face[] _0023_003DzuHbAxNSGQE3z(Face[] _0023_003Dzb7SPTpc_003D, bool _0023_003Dzu9oxwJ_zKlMt)
	{
		Face[] array = new Face[_0023_003Dzb7SPTpc_003D.Length];
		for (int i = 0; i < _0023_003Dzb7SPTpc_003D.Length; i++)
		{
			array[i] = (Face)(_0023_003Dzu9oxwJ_zKlMt ? _0023_003Dzb7SPTpc_003D[i].CloneWithTessellation() : _0023_003Dzb7SPTpc_003D[i].Clone());
		}
		return array;
	}

	public override object Clone()
	{
		return new Brep(this);
	}

	public override object CloneWithTessellation()
	{
		return new Brep(this, RegenMode != regenType.RegenAndCompile);
	}

	private protected override void _0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(Entity _0023_003Dzb7SPTpc_003D)
	{
	}

	public double GetError()
	{
		double num = double.MinValue;
		Face[] faces = Faces;
		for (int i = 0; i < faces.Length; i++)
		{
			double error = faces[i].GetError(_edges);
			if (error > num)
			{
				num = error;
			}
		}
		return num;
	}

	internal void _0023_003DzxIz2h65fhdN2(int _0023_003Dz9JZgoew_003D)
	{
		Array.Resize(ref _edges, _0023_003Dz9JZgoew_003D);
	}

	public override bool IsValid(StringBuilder log = null)
	{
		if (_vertices == null)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960550));
			return false;
		}
		if (_vertices.Length == 0)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960514));
			return false;
		}
		for (int i = 0; i < _vertices.Length; i++)
		{
			Vertex vertex = (Vertex)_vertices[i];
			if (vertex == null)
			{
				log?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960252), i));
				return false;
			}
			if (vertex.Parents == null)
			{
				log?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960221), i));
				return false;
			}
			if (vertex.Parents.Length == 0)
			{
				log?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960172), i));
				return false;
			}
			for (int j = 0; j < vertex.Parents.Length; j++)
			{
				if (vertex.Parents[j] < 0 || vertex.Parents[j] >= _edges?.Length)
				{
					log?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960373), vertex.Parents[j], j, i));
					return false;
				}
				Edge[] edges = _edges;
				Edge edge = ((edges != null) ? edges[vertex.Parents[j]] : null);
				if ((edge == null || edge.StartPointIndex != i) && (edge == null || edge.EndPointIndex != i))
				{
					log?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960309), i, vertex.Parents[j], edge?.StartPointIndex, edge?.EndPointIndex));
					return false;
				}
			}
		}
		if (_edges == null)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961008));
			return false;
		}
		if (_edges.Length == 0)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960969));
			return false;
		}
		for (int k = 0; k < _edges.Length; k++)
		{
			Edge edge2 = _edges[k];
			if (edge2 == null)
			{
				log?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960932), k));
				return false;
			}
			if (edge2.Parents == null)
			{
				log?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960899), k));
				return false;
			}
			if (edge2.Parents.Length == 0)
			{
				log?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961136), k));
				return false;
			}
			if (edge2.Parents.Length > 2)
			{
				log?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961079), k, edge2.Parents.Length));
				return false;
			}
			for (int l = 0; l < edge2.Parents.Length; l++)
			{
				bool[] array = new bool[_inners.Length + 1];
				array[0] = _0023_003Dzrd58_duKXmV4(k, l, _edges, _faces);
				for (int m = 0; m < _inners.Length; m++)
				{
					Face[] _0023_003DzpPOEJqcAh7Lr = _inners[m];
					array[m + 1] = _0023_003Dzrd58_duKXmV4(k, l, _edges, _0023_003DzpPOEJqcAh7Lr);
				}
				if (array.All(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzgnx7m86ApRe6vFzfPThBN7s_003D))
				{
					log?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961050), k, edge2.Parents[l]));
					return false;
				}
			}
		}
		if (_faces == null)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960715));
			return false;
		}
		if (_faces.Length == 0)
		{
			log?.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960680));
			return false;
		}
		if (!_0023_003Dzd8DD_BVJrk8w4EzWCg_003D_003D(_faces, log))
		{
			return false;
		}
		for (int n = 0; n < Inners.Length; n++)
		{
			Face[] _0023_003DzpPOEJqcAh7Lr2 = Inners[n];
			if (!_0023_003Dzd8DD_BVJrk8w4EzWCg_003D_003D(_0023_003DzpPOEJqcAh7Lr2, log))
			{
				return false;
			}
		}
		return base.IsValid(log);
	}

	private bool _0023_003Dzd8DD_BVJrk8w4EzWCg_003D_003D(Face[] _0023_003DzpPOEJqcAh7Lr, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		for (int i = 0; i < _0023_003DzpPOEJqcAh7Lr.Length; i++)
		{
			Face face = _0023_003DzpPOEJqcAh7Lr[i];
			if (face == null)
			{
				_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960671), i));
				return false;
			}
			PlanarSurf planarSurf = ((face.Surface.GetType() == typeof(PlanarSurf)) ? ((PlanarSurf)face.Surface) : null);
			ICurve[][] array = new ICurve[face.Loops.Length][];
			for (int j = 0; j < face.Loops.Length; j++)
			{
				Loop loop = face.Loops[j];
				if (loop == null)
				{
					_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960866), j, i));
					return false;
				}
				ICurve[] array2 = new ICurve[loop.Segments.Length];
				for (int k = 0; k < loop.Segments.Length; k++)
				{
					OrientedEdge orientedEdge = loop.Segments[k];
					if (orientedEdge.CurveIndex < 0 || orientedEdge.CurveIndex >= _edges?.Length)
					{
						_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960846), orientedEdge.CurveIndex, k, j, i));
						continue;
					}
					Point3D startVertex = orientedEdge.GetStartVertex(_vertices, _edges);
					if (startVertex == null)
					{
						_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961524), k, j, i));
						continue;
					}
					Point3D endVertex = orientedEdge.GetEndVertex(_vertices, _edges);
					if (endVertex == null)
					{
						_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961462), k, j, i));
						continue;
					}
					ICurve orientedCurve = orientedEdge.GetOrientedCurve(_edges);
					if (planarSurf != null)
					{
						Curve nurbsForm = orientedCurve.GetNurbsForm();
						array2[k] = nurbsForm.Drop(planarSurf.Plane);
					}
					if (orientedCurve == null)
					{
						_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961654), k, j, i));
						continue;
					}
					Utility.ComputeBoundingBox(_vertices, out var boxMin, out var boxMax);
					double num = new Size3D(boxMin, boxMax).Diagonal * Utility._0023_003Dzjyaz_Vfaky9X;
					if ((object)startVertex != null && startVertex.DistanceTo(orientedCurve.StartPoint) > num)
					{
						_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961594), k, j, i, startVertex));
						return false;
					}
					if ((object)endVertex != null && endVertex.DistanceTo(orientedCurve.EndPoint) > num)
					{
						_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961220), k, j, i, endVertex));
						return false;
					}
				}
				array[j] = array2;
				if (!loop.IsValid(this, _0023_003DzqmF8XJ0_003D))
				{
					_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302960866), j, i));
					return false;
				}
			}
			if (planarSurf != null)
			{
				int outerIndex = Utility.GetOuterIndex(array);
				if (outerIndex != -1 && outerIndex != 0)
				{
					_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961388), i));
					return false;
				}
			}
			if (face.Parametric == null || face.needRebuild)
			{
				continue;
			}
			if (face.Parametric.Length == 0)
			{
				_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961325), i));
				return false;
			}
			Loop[] loops = face.Loops;
			for (int l = 0; l < loops.Length; l++)
			{
				OrientedEdge[] segments = loops[l].Segments;
				for (int m = 0; m < segments.Length; m++)
				{
					_0023_003DzM8ZnNXymrNp7E4BnbA0MVjk_003D CS_0024_003C_003E8__locals3 = new _0023_003DzM8ZnNXymrNp7E4BnbA0MVjk_003D();
					CS_0024_003C_003E8__locals3._0023_003DzIL0P1ps_003D = segments[m];
					bool flag = false;
					Surface[] parametric = face.Parametric;
					foreach (Surface surface in parametric)
					{
						if (!surface.IsValid(_0023_003DzqmF8XJ0_003D))
						{
							_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962047), i));
							return false;
						}
						foreach (ICurve contour in surface.Trimming.ContourList)
						{
							if (contour.GetIndividualCurves().Any((ICurve _0023_003DzFDJdA7A_003D) => CS_0024_003C_003E8__locals3._0023_003DzIL0P1ps_003D.CurveIndex == _0023_003DzFDJdA7A_003D.EdgeIndex))
							{
								flag = true;
							}
							if (flag)
							{
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
					if (!flag)
					{
						_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961971), CS_0024_003C_003E8__locals3._0023_003DzIL0P1ps_003D.CurveIndex, i));
						return false;
					}
				}
			}
		}
		return true;
	}

	private static bool _0023_003Dzrd58_duKXmV4(int _0023_003DzL8NvYU0_003D, int _0023_003Dzc_0024GVAo88PcA5, Edge[] _0023_003DzU3hosSAzkxO7, Face[] _0023_003DzpPOEJqcAh7Lr)
	{
		Edge edge = _0023_003DzU3hosSAzkxO7[_0023_003DzL8NvYU0_003D];
		if (_0023_003DzpPOEJqcAh7Lr != null && (edge.Parents[_0023_003Dzc_0024GVAo88PcA5] < 0 || edge.Parents[_0023_003Dzc_0024GVAo88PcA5] >= _0023_003DzpPOEJqcAh7Lr.Length))
		{
			return false;
		}
		Face face = ((_0023_003DzpPOEJqcAh7Lr != null) ? _0023_003DzpPOEJqcAh7Lr[edge.Parents[_0023_003Dzc_0024GVAo88PcA5]] : null);
		bool flag = false;
		for (int i = 0; i < face?.Loops.Length; i++)
		{
			OrientedEdge[] segments = face.Loops[i].Segments;
			for (int j = 0; j < segments.Length; j++)
			{
				if (segments[j].CurveIndex == _0023_003DzL8NvYU0_003D)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (!flag)
		{
			return false;
		}
		return true;
	}

	internal void _0023_003DzZgiqXorCPZhhzzpl2py39to_003D()
	{
		List<Vertex> list = new List<Vertex>();
		int[] array = new int[_vertices.Length];
		for (int i = 0; i < _vertices.Length; i++)
		{
			Vertex vertex = (Vertex)_vertices[i];
			if (vertex.Parents != null)
			{
				array[i] = list.Count;
				list.Add(vertex);
			}
			else
			{
				array[i] = -1;
			}
		}
		Edge[] edges = _edges;
		foreach (Edge edge in edges)
		{
			edge.StartPointIndex = array[edge.StartPointIndex];
			edge.EndPointIndex = array[edge.EndPointIndex];
		}
		Point3D[] vertices = list.ToArray();
		_vertices = vertices;
	}

	private void _0023_003DzDumeg9jsTU7S(bool _0023_003Dzxt7paKBusKOo)
	{
		_0023_003DzaVCYL4SoOzFc(0, _faces, _0023_003Dzxt7paKBusKOo);
		for (int i = 0; i < _inners.Length; i++)
		{
			Face[] _0023_003DzEtn4dIEPKCsi = _inners[i];
			_0023_003DzaVCYL4SoOzFc(i + 1, _0023_003DzEtn4dIEPKCsi, _0023_003Dzxt7paKBusKOo);
		}
	}

	private void _0023_003DzaVCYL4SoOzFc(int _0023_003DzRLCcpW4_003D, Face[] _0023_003DzEtn4dIEPKCsi, bool _0023_003Dzxt7paKBusKOo)
	{
		if (_0023_003DzEtn4dIEPKCsi == null)
		{
			return;
		}
		int num = _0023_003DzEtn4dIEPKCsi.Length;
		bool[] array = new bool[Edges.Length];
		for (int i = 0; i < num; i++)
		{
			Face face = _0023_003DzEtn4dIEPKCsi[i];
			if (_0023_003Dzxt7paKBusKOo && face == null)
			{
				continue;
			}
			for (int j = 0; j < face.Loops.Length; j++)
			{
				Loop loop = face.Loops[j];
				for (int k = 0; k < loop.Segments.Length; k++)
				{
					OrientedEdge orientedEdge = loop.Segments[k];
					Edge edge = Edges[orientedEdge.CurveIndex];
					edge.ShellIndex = _0023_003DzRLCcpW4_003D;
					if (edge.Parents == null)
					{
						array[orientedEdge.CurveIndex] = true;
						edge.Parents = new int[1] { i };
					}
					else if (array[orientedEdge.CurveIndex])
					{
						Array.Resize(ref edge.Parents, edge.Parents.Length + 1);
						edge.Parents[edge.Parents.Length - 1] = i;
					}
				}
			}
		}
	}

	private void _0023_003DzUE6pJD8Y3NVt()
	{
		for (int i = 0; i < _edges.Length; i++)
		{
			Edge edge = _edges[i];
			if (edge == null)
			{
				continue;
			}
			edge.Curve.EdgeIndex = i;
			if (edge.StartPointIndex < Vertices.Length)
			{
				Vertex vertex = (Vertex)Vertices[edge.StartPointIndex];
				int[] parents = vertex.Parents;
				if (parents == null)
				{
					vertex.Parents = new int[1] { i };
				}
				else if (!((IList)parents).Contains((object)i))
				{
					int num = parents.Length;
					Array.Resize(ref vertex.Parents, num + 1);
					vertex.Parents[num] = i;
				}
			}
			if (edge.EndPointIndex < Vertices.Length)
			{
				Vertex vertex2 = (Vertex)Vertices[edge.EndPointIndex];
				int[] parents2 = vertex2.Parents;
				if (parents2 == null)
				{
					vertex2.Parents = new int[1] { i };
				}
				else if (!((IList)parents2).Contains((object)i))
				{
					int num2 = parents2.Length;
					Array.Resize(ref vertex2.Parents, num2 + 1);
					vertex2.Parents[num2] = i;
				}
			}
		}
	}

	public int[] FindEdge(int firstIndex, int secondIndex)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < _edges.Length; i++)
		{
			if ((_edges[i].StartPointIndex == firstIndex && _edges[i].EndPointIndex == secondIndex) || (_edges[i].StartPointIndex == secondIndex && _edges[i].EndPointIndex == firstIndex))
			{
				list.Add(i);
			}
		}
		return list.ToArray();
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		if (RegenMode != regenType.RegenAndCompile)
		{
			return new Point3D[2] { base.BoxMin, base.BoxMax };
		}
		List<Point3D> list = new List<Point3D>(Edges.Length);
		Edge[] edges = Edges;
		foreach (Edge edge in edges)
		{
			list.AddRange(((Entity)edge.Curve).EstimateBoundingBox(blocks, layers));
		}
		return list.ToArray();
	}

	public override void TransformBy(Transformation xform)
	{
		bool flag = xform.IsScaleFactorUniform();
		bool _0023_003DzSD8Lrec_003D = RegenMode != regenType.RegenAndCompile;
		if (!flag)
		{
			_0023_003Dz2ddX9TxKCPwr7REVkA_003D_003D(_faces, xform);
			Face[][] inners = _inners;
			foreach (Face[] _0023_003DzEtn4dIEPKCsi in inners)
			{
				_0023_003Dz2ddX9TxKCPwr7REVkA_003D_003D(_0023_003DzEtn4dIEPKCsi, xform);
			}
		}
		else
		{
			_0023_003DzD5hSmjGI7C_0024n(_faces, xform, _0023_003DzSD8Lrec_003D);
			Face[][] inners = _inners;
			foreach (Face[] _0023_003DzEtn4dIEPKCsi2 in inners)
			{
				_0023_003DzD5hSmjGI7C_0024n(_0023_003DzEtn4dIEPKCsi2, xform, _0023_003DzSD8Lrec_003D);
			}
		}
		if (!flag)
		{
			for (int j = 0; j < Edges.Length; j++)
			{
				ICurve curve = Edges[j].Curve;
				if (!(curve is Line))
				{
					Curve nurbsForm = curve.GetNurbsForm();
					if (((Entity)curve).EntityData is ICloneable)
					{
						nurbsForm.EntityData = ((Entity)curve).EntityData;
					}
					nurbsForm.TransformBy(xform);
					Edges[j].Curve = nurbsForm;
				}
				else
				{
					((Entity)curve).TransformBy(xform);
				}
			}
		}
		else
		{
			Edge[] edges = Edges;
			foreach (Edge edge in edges)
			{
				if (edge != null)
				{
					((Entity)edge.Curve).TransformBy(xform);
				}
			}
		}
		if (xform.HasReflection)
		{
			_0023_003DzAPllSwUuGBft(_faces);
			Face[][] inners = _inners;
			for (int i = 0; i < inners.Length; i++)
			{
				_0023_003DzAPllSwUuGBft(inners[i]);
			}
		}
		if (flag && _convexHull != null)
		{
			_convexHull.TransformBy(xform);
		}
		base.TransformBy(xform);
	}

	private protected override void _0023_003DzW6DreOuCtoN4OdSR3r_0024aPf8_003D(Transformation _0023_003DzLS0sR0pzioXc, bool _0023_003DzfHX6qJ20RY9Zf_2BYw_003D_003D)
	{
		TransformAllVertices(_0023_003DzLS0sR0pzioXc);
	}

	private void _0023_003Dz2ddX9TxKCPwr7REVkA_003D_003D(Face[] _0023_003DzEtn4dIEPKCsi, Transformation _0023_003Dzptomndc_003D)
	{
		foreach (Face face in _0023_003DzEtn4dIEPKCsi)
		{
			face.plane = null;
			face.planeAlreadySet = false;
			if (face.Surface != null)
			{
				AnalyticSurf surface = face.Surface;
				if (surface.GetType() != typeof(NurbsSurf))
				{
					ICurve[] edgeCurves = _0023_003Dzc82cILbi9HyU(face);
					Surface notRotated;
					Surface generic = surface.GetUntrimmed(edgeCurves, sense: true, out notRotated).GetGeneric();
					AnalyticSurf analyticSurf = new NurbsSurf(generic.DegreeU, generic.KnotVectorU, generic.DegreeV, generic.KnotVectorV, generic.ControlPoints);
					analyticSurf.TransformBy(_0023_003Dzptomndc_003D);
					face.Surface = analyticSurf;
				}
				else
				{
					surface.TransformBy(_0023_003Dzptomndc_003D);
				}
			}
		}
	}

	private void _0023_003DzD5hSmjGI7C_0024n(Face[] _0023_003DzEtn4dIEPKCsi, Transformation _0023_003Dzptomndc_003D, bool _0023_003DzSD8Lrec_003D)
	{
		foreach (Face face in _0023_003DzEtn4dIEPKCsi)
		{
			if (face == null)
			{
				continue;
			}
			face.Surface.TransformBy(_0023_003Dzptomndc_003D);
			face.plane = null;
			face.planeAlreadySet = false;
			if (face.Parametric != null)
			{
				Surface[] parametric = face.Parametric;
				for (int j = 0; j < parametric.Length; j++)
				{
					parametric[j].TransformBy(_0023_003Dzptomndc_003D);
				}
			}
			if (_0023_003DzSD8Lrec_003D)
			{
				face.Tessellation.TransformBy(_0023_003Dzptomndc_003D);
			}
		}
	}

	public void Rebuild(double tol = 0.0, bool soft = false)
	{
		if (tol == 0.0)
		{
			tol = _rebuildTol;
		}
		else if (_rebuildTol != tol)
		{
			RebuildTolerance = tol;
		}
		List<Face> list = new List<Face>(_faces.Length);
		if (soft)
		{
			Face[] faces = _faces;
			foreach (Face face in faces)
			{
				if (face != null && (face._0023_003Dz9FCm9_0024CiAUGE() || face.needRebuild))
				{
					list.Add(face);
				}
			}
			Face[][] inners = _inners;
			for (int i = 0; i < inners.Length; i++)
			{
				faces = inners[i];
				foreach (Face face2 in faces)
				{
					if (face2 != null && (face2._0023_003Dz9FCm9_0024CiAUGE() || face2.needRebuild))
					{
						list.Add(face2);
					}
				}
			}
		}
		else
		{
			list.AddRange(_faces);
			Face[][] inners = _inners;
			foreach (Face[] collection in inners)
			{
				list.AddRange(collection);
			}
		}
		if (list.Count > 0)
		{
			_0023_003Dzsbu_0024qag0bE6HjJtgiPvQCKDPPuzm(list, tol);
		}
	}

	public override void Regen(RegenParams data)
	{
		RegenMode = regenType.RegenAndCompile;
		_0023_003Dz8nn2PNTEXNhi(data);
		_0023_003DzTM_0024oj0RGNh_nyHBxNAZRijjp4KZe(_faces, data.Deviation, data.Angle);
		Face[][] inners = _inners;
		foreach (Face[] _0023_003DzEtn4dIEPKCsi in inners)
		{
			_0023_003DzTM_0024oj0RGNh_nyHBxNAZRijjp4KZe(_0023_003DzEtn4dIEPKCsi, data.Deviation, data.Angle);
		}
		FacesSelectionInfo.Clear();
		InnerFacesSelectionInfo.Clear();
		EdgesSelectionInfo.Clear();
		VerticesSelectionInfo.Clear();
		UpdateBoundingBox(new TraversalParams(data.Document, new Identity()));
		RegenMode = regenType.CompileOnly;
	}

	private void _0023_003DzTM_0024oj0RGNh_nyHBxNAZRijjp4KZe(Face[] _0023_003DzEtn4dIEPKCsi, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, double _0023_003Dz6pajdGM_003D)
	{
		int num = _0023_003DzEtn4dIEPKCsi.Length;
		for (int i = 0; i < num; i++)
		{
			Face face = _0023_003DzEtn4dIEPKCsi[i];
			ICurve[] orientedTrimLoops = face.GetOrientedTrimLoops(_edges);
			if (orientedTrimLoops.Length == 0)
			{
				face.Tessellation = new FastMesh(new float[0], new int[0], new float[0]);
				continue;
			}
			Surface notRotated;
			Surface untrimmed = face.Surface.GetUntrimmed(orientedTrimLoops, face.Sense, out notRotated);
			if (face.Tessellation != null)
			{
				_0023_003Dz9ctHTXjAW5QC(face.Tessellation);
			}
			Surface[] array = Surface._0023_003DzNxaR6FzQJCTX(untrimmed, orientedTrimLoops, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, null, null);
			if (array != null && array.Length != 0 && _0023_003Dz909r3pkb63XgiBkYZQ_003D_003D(array, untrimmed, notRotated, orientedTrimLoops))
			{
				array = Surface._0023_003DzNxaR6FzQJCTX(notRotated, orientedTrimLoops, _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, null, null);
			}
			if (array == null || array.Length == 0)
			{
				face.Tessellation = new FastMesh(new float[0], new int[0], new float[0]);
				continue;
			}
			Mesh mesh = null;
			double uScale = 1.0;
			double vScale = 1.0;
			Surface[] array2 = array;
			foreach (Surface surface in array2)
			{
				surface._0023_003DzcX3lwu4d7umF(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, null, 0.0, null);
				Surface.Reparametrize(surface, out uScale, out vScale, out var _);
				if (mesh == null)
				{
					mesh = new Mesh(surface.Vertices, surface.Triangles);
				}
				else
				{
					mesh.MergeWith(new Mesh(surface.Vertices, surface.Triangles), weldNow: false, recomputeEdges: false);
				}
			}
			face.TextureScaleU = (float)uScale;
			face.TextureScaleV = (float)vScale;
			face.Tessellation = mesh.ConvertToFastMesh();
		}
	}

	private bool _0023_003DzQbEbt5zGYXpLSVEnBA_003D_003D(Face[] _0023_003DzEtn4dIEPKCsi, Edge[] _0023_003DzcFqhPo_0024Q_0024jYE, SizesOnCurve[] _0023_003DzSrRL3Zr_fKWh, VolumeMesher _0023_003Dz1rWN_AM_003D, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, string _0023_003Dz3lURioVh8358, out Mesh[] _0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D)
	{
		int num = _0023_003DzEtn4dIEPKCsi.Length;
		Mesh[] array = new Mesh[num];
		for (int i = 0; i < num; i++)
		{
			Face face = _0023_003DzEtn4dIEPKCsi[i];
			ICurve[] orientedTrimLoops = face.GetOrientedTrimLoops(_edges);
			Surface notRotated;
			Surface untrimmed = face.Surface.GetUntrimmed(orientedTrimLoops, face.Sense, out notRotated);
			double[] _0023_003DzHWRvKhe4g2j_0024;
			Dictionary<int, SizesOnCurve> _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D = _0023_003DzV6U3UVUo5N46(_0023_003DzcFqhPo_0024Q_0024jYE, _0023_003DzSrRL3Zr_fKWh, face, out _0023_003DzHWRvKhe4g2j_0024);
			if (face.Tessellation != null)
			{
				_0023_003Dz9ctHTXjAW5QC(face.Tessellation);
			}
			Surface[] array2 = Surface._0023_003DzNxaR6FzQJCTX(untrimmed, orientedTrimLoops, 0.0, 0.0, _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D, null);
			if (array2 != null && array2.Length != 0 && _0023_003Dz909r3pkb63XgiBkYZQ_003D_003D(array2, untrimmed, notRotated, orientedTrimLoops))
			{
				array2 = Surface._0023_003DzNxaR6FzQJCTX(notRotated, orientedTrimLoops, 0.0, 0.0, _0023_003DzNcN7H_tY7XrNMA_8eXCQOlc_003D, null);
			}
			if (array2 == null || array2.Length == 0)
			{
				array[i] = new Mesh(new Point3D[0], new IndexTriangle[0]);
			}
			else
			{
				Mesh mesh = null;
				Surface[] array3 = array2;
				foreach (Surface surface in array3)
				{
					surface._0023_003DzcX3lwu4d7umF(0.0, 0.0, _0023_003DzHWRvKhe4g2j_0024, _0023_003DzHWRvKhe4g2j_0024.Max(), _0023_003Dz1rWN_AM_003D);
					if (mesh == null)
					{
						mesh = new Mesh(surface.Vertices, surface.Triangles);
					}
					else
					{
						mesh.MergeWith(new Mesh(surface.Vertices, surface.Triangles), weldNow: false, recomputeEdges: false);
					}
				}
				if (array2.Length > 1)
				{
					mesh.Weld(_0023_003DzHWRvKhe4g2j_0024.Min() / 10.0);
				}
				face.Tessellation = mesh.ConvertToFastMesh();
				array[i] = mesh;
			}
			if (_0023_003Dz1rWN_AM_003D != null && !_0023_003Dz1rWN_AM_003D.UpdateProgressAndCheckCancelled(i, num, _0023_003Dz3lURioVh8358, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, i.ToString(), num.ToString()))
			{
				_0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D = null;
				return false;
			}
		}
		_0023_003Dz1rWN_AM_003D?.UpdateProgressTo100(_0023_003Dz3lURioVh8358, _0023_003DzmHS7frs_003D, num.ToString(), num.ToString());
		_0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D = array;
		return true;
	}

	internal SizesOnCurve[] _0023_003DzV6U3UVUo5N46(double[] _0023_003DzTsINDy8j6voWNHu1xQ_003D_003D)
	{
		if (_0023_003DzTsINDy8j6voWNHu1xQ_003D_003D.Length < Vertices.Length)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962145), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961786));
		}
		int num = Edges.Length;
		SizesOnCurve[] array = new SizesOnCurve[num];
		for (int i = 0; i < num; i++)
		{
			Edge edge = Edges[i];
			double startSize = _0023_003DzTsINDy8j6voWNHu1xQ_003D_003D[edge.StartPointIndex];
			double endSize = _0023_003DzTsINDy8j6voWNHu1xQ_003D_003D[edge.EndPointIndex];
			array[i] = new SizesOnCurve(startSize, endSize);
		}
		return array;
	}

	private static Dictionary<int, SizesOnCurve> _0023_003DzV6U3UVUo5N46(Edge[] _0023_003DzcFqhPo_0024Q_0024jYE, IList<SizesOnCurve> _0023_003DzSrRL3Zr_fKWh, Face _0023_003DzWXFXOqg_003D, out double[] _0023_003DzHWRvKhe4g2j_0024)
	{
		HashSet<double> hashSet = new HashSet<double>();
		Dictionary<int, SizesOnCurve> dictionary = new Dictionary<int, SizesOnCurve>();
		Loop[] loops = _0023_003DzWXFXOqg_003D.Loops;
		for (int i = 0; i < loops.Length; i++)
		{
			OrientedEdge[] segments = loops[i].Segments;
			for (int j = 0; j < segments.Length; j++)
			{
				int curveIndex = segments[j].CurveIndex;
				dictionary[curveIndex] = _0023_003DzSrRL3Zr_fKWh[curveIndex];
				hashSet.Add(dictionary[curveIndex].StartSize);
				hashSet.Add(dictionary[curveIndex].EndSize);
			}
		}
		_0023_003DzHWRvKhe4g2j_0024 = hashSet.ToArray();
		return dictionary;
	}

	private static bool _0023_003Dz909r3pkb63XgiBkYZQ_003D_003D(Surface[] _0023_003Dz74tpWPU_003D, Surface _0023_003DzAI_Szwk_003D, Surface _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D, ICurve[] _0023_003DzRTbTK_0024KwG32W)
	{
		bool num = _0023_003Dz74tpWPU_003D.Length == 1 && _0023_003DzAI_Szwk_003D is SphericalSurface;
		bool flag = _0023_003DzRTbTK_0024KwG32W.Length == 1 && _0023_003Dz74tpWPU_003D.Length != 0 && _0023_003Dz74tpWPU_003D[0].Trimming.ContourList.Count > 1;
		if (num && flag)
		{
			return true;
		}
		if (!(_0023_003DzAI_Szwk_003D is SphericalSurface) && _0023_003DzAI_Szwk_003D.rotAngleU != 0.0 && _0023_003DzZZ3udmm1DZ6s(_0023_003Dz74tpWPU_003D))
		{
			for (int i = 0; i < _0023_003DzRTbTK_0024KwG32W.Length; i++)
			{
				ICurve[] individualCurves = _0023_003DzRTbTK_0024KwG32W[i].GetIndividualCurves();
				foreach (ICurve curve in individualCurves)
				{
					if (_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D.IsOnSeamU(curve) && !_0023_003DzAI_Szwk_003D.IsOnSeamU(curve))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private static bool _0023_003DzZZ3udmm1DZ6s(Surface[] _0023_003Dz74tpWPU_003D)
	{
		for (int i = 0; i < _0023_003Dz74tpWPU_003D.Length; i++)
		{
			foreach (ICurve contour in _0023_003Dz74tpWPU_003D[i].Trimming.ContourList)
			{
				ICurve[] individualCurves = contour.GetIndividualCurves();
				for (int j = 0; j < individualCurves.Length; j++)
				{
					if (individualCurves[j].EdgeIndex == -1)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private bool _0023_003Dz2lo2BymHsQ6hbknq5hTRcEYbsbwt(SizesOnCurve[] _0023_003DzSrRL3Zr_fKWh, VolumeMesher _0023_003Dz1rWN_AM_003D, string _0023_003Dz3lURioVh8358, StringBuilder _0023_003DzqmF8XJ0_003D, out Mesh[] _0023_003DzO5ynmul98lyB, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		for (int i = 0; i < Edges.Length; i++)
		{
			Edge edge = Edges[i];
			if (edge.Curve is Line line)
			{
				edge.Curve = line.GetNurbsForm();
			}
			Point3D[] _0023_003DzrdSL0CI_003D = ((_0023_003Dz1rWN_AM_003D != null) ? _0023_003Dz1rWN_AM_003D.CreateCurveMesher(edge.Curve, _0023_003DzSrRL3Zr_fKWh[i]) : new CurveMesher(edge.Curve, _0023_003DzSrRL3Zr_fKWh[i]))._0023_003DzfHSvFLY_003D(null, default(CancellationToken));
			_0023_003DzM863smJCnYvX(i, edge.Curve, ref _0023_003DzrdSL0CI_003D);
			((Entity)edge.Curve).Vertices = _0023_003DzrdSL0CI_003D;
		}
		stopwatch.Stop();
		_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961763), (double)stopwatch.ElapsedMilliseconds / 1000.0));
		_0023_003DzO5ynmul98lyB = null;
		List<Mesh> list = new List<Mesh>(Faces.Length + Inners.Length);
		stopwatch.Reset();
		stopwatch.Start();
		if (!_0023_003DzQbEbt5zGYXpLSVEnBA_003D_003D(_faces, _edges, _0023_003DzSrRL3Zr_fKWh, _0023_003Dz1rWN_AM_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, _0023_003Dz3lURioVh8358, out var _0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D))
		{
			return false;
		}
		list.AddRange(_0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D);
		Face[][] inners = _inners;
		foreach (Face[] _0023_003DzEtn4dIEPKCsi in inners)
		{
			if (!_0023_003DzQbEbt5zGYXpLSVEnBA_003D_003D(_0023_003DzEtn4dIEPKCsi, _edges, _0023_003DzSrRL3Zr_fKWh, _0023_003Dz1rWN_AM_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, _0023_003Dz3lURioVh8358, out var _0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D2))
			{
				return false;
			}
			list.AddRange(_0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D2);
		}
		stopwatch.Stop();
		_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961734), (double)stopwatch.ElapsedMilliseconds / 1000.0));
		_0023_003DzO5ynmul98lyB = list.ToArray();
		return true;
	}

	private void _0023_003DzM863smJCnYvX(int _0023_003DzL8NvYU0_003D, ICurve _0023_003Dz8vL_NxTP5wHa, ref Point3D[] _0023_003DzrdSL0CI_003D)
	{
		if (_0023_003DzrdSL0CI_003D.Length != 2)
		{
			return;
		}
		int num = 0;
		Face[] faces = Faces;
		for (int i = 0; i < faces.Length; i++)
		{
			Loop[] loops = faces[i].Loops;
			foreach (Loop loop in loops)
			{
				if (loop.Segments.Length == 2 && (loop.Segments[0].CurveIndex == _0023_003DzL8NvYU0_003D || loop.Segments[1].CurveIndex == _0023_003DzL8NvYU0_003D))
				{
					num++;
					_0023_003DzrdSL0CI_003D = new Point3D[3]
					{
						_0023_003DzrdSL0CI_003D[0],
						CurveMesher._0023_003DzMEXpAaVkFlpl(_0023_003Dz8vL_NxTP5wHa, _0023_003Dz8vL_NxTP5wHa.Domain.ParameterAt(0.5)),
						_0023_003DzrdSL0CI_003D[1]
					};
					break;
				}
			}
			if (num == 2)
			{
				break;
			}
		}
	}

	private void _0023_003Dzsbu_0024qag0bE6HjJtgiPvQCKDPPuzm(List<Face> _0023_003DzEtn4dIEPKCsi, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D)
	{
		_0023_003DzoB_vXtS6zNDiyz4rZJZZHg4_003D _0023_003DzoB_vXtS6zNDiyz4rZJZZHg4_003D2 = new _0023_003DzoB_vXtS6zNDiyz4rZJZZHg4_003D();
		_0023_003DzoB_vXtS6zNDiyz4rZJZZHg4_003D2._0023_003DzEtn4dIEPKCsi = _0023_003DzEtn4dIEPKCsi;
		_0023_003DzoB_vXtS6zNDiyz4rZJZZHg4_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003DzoB_vXtS6zNDiyz4rZJZZHg4_003D2._0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D = _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D;
		Point3D[][] array = new Point3D[_edges.Length][];
		regenType[] array2 = new regenType[_edges.Length];
		for (int i = 0; i < _edges.Length; i++)
		{
			Entity entity = (Entity)_edges[i].Curve;
			array[i] = entity.Vertices;
			array2[i] = entity.RegenMode;
		}
		_0023_003Dz8nn2PNTEXNhi(new RegenParams(_0023_003DzoB_vXtS6zNDiyz4rZJZZHg4_003D2._0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, Math.PI / 10.0));
		int count = _0023_003DzoB_vXtS6zNDiyz4rZJZZHg4_003D2._0023_003DzEtn4dIEPKCsi.Count;
		Parallel.For(0, count, _0023_003DzoB_vXtS6zNDiyz4rZJZZHg4_003D2._0023_003Dzn4ba9qUPJc4sXxQe0CysxEu4Cs8Crmx1kA_003D_003D);
		for (int j = 0; j < _edges.Length; j++)
		{
			Entity obj = (Entity)_edges[j].Curve;
			obj._vertices = array[j];
			obj.regenMode = array2[j];
		}
	}

	public int GetEdgeIndex(Point3D pointOnEdge, Vector3D direction = null)
	{
		for (int i = 0; i < Edges.Length; i++)
		{
			Edge edge = Edges[i];
			edge.Curve.ClosestPointTo(pointOnEdge, out var t);
			if (!(Point3D.Distance(edge.Curve.PointAt(t), pointOnEdge) < RebuildTolerance))
			{
				continue;
			}
			bool flag = Utility.AreEqual(t, edge.Curve.Domain.Low, edge.Curve.Domain.Length * RebuildTolerance);
			bool flag2 = Utility.AreEqual(t, edge.Curve.Domain.High, edge.Curve.Domain.Length * RebuildTolerance);
			if ((!flag && !flag2) || (edge.StartPointIndex == edge.EndPointIndex && ((Vertex)Vertices[edge.StartPointIndex]).Parents.Length == 1))
			{
				return i;
			}
			if (direction == null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961701));
			}
			int num = (flag ? edge.StartPointIndex : edge.EndPointIndex);
			Vertex vertex = (Vertex)Vertices[num];
			for (int j = 0; j < vertex.Parents.Length; j++)
			{
				int num2 = vertex.Parents[j];
				Edge edge2 = Edges[num2];
				if (edge2.StartPointIndex == num && Vector3D.AreParallel(direction, edge2.Curve.StartTangent))
				{
					return num2;
				}
				if (edge2.EndPointIndex == num && Vector3D.AreParallel(direction, edge2.Curve.EndTangent))
				{
					return num2;
				}
			}
		}
		return -1;
	}

	private int _0023_003DzWq8IAnpGDVDH41wQcE_0024kHssdawL0(int _0023_003DzL8NvYU0_003D)
	{
		int num = Edges[_0023_003DzL8NvYU0_003D].Parents[0];
		Face face = Faces[num];
		int num2 = Edges[_0023_003DzL8NvYU0_003D].Parents[1];
		Face face2 = Faces[num2];
		Plane plane = face.IsPlanar();
		Plane plane2 = face2.IsPlanar();
		if (plane == null && plane2 == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302961834));
		}
		if (plane == null)
		{
			return num2;
		}
		if (plane2 == null)
		{
			return num;
		}
		ICurve curve = face.GetOrientedTrimLoops(Edges)[0];
		ICurve curve2 = face2.GetOrientedTrimLoops(Edges)[0];
		if (!(curve.Length() >= curve2.Length()))
		{
			return num;
		}
		return num2;
	}

	public int GetPlanarFaceIndex(Plane plane, Point3D pointOnFace = null)
	{
		if (pointOnFace != null && Math.Abs(plane.DistanceTo(pointOnFace)) > RebuildTolerance)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962536));
		}
		for (int i = 0; i < Faces.Length; i++)
		{
			Face face = Faces[i];
			Plane plane2 = face.IsPlanar();
			if (!(plane2 != null) || Plane.Intersection(plane2, plane, Utility._0023_003DzheSR8QM7q9ya, out var _) != planeIntersectionType.Coincide)
			{
				continue;
			}
			if (pointOnFace != null)
			{
				Region region = new Region(face.GetOrientedTrimLoops(Edges), plane2);
				if (!region.IsPointInside(pointOnFace) && !region.IsPointOnContour(pointOnFace, Utility._0023_003DzheSR8QM7q9ya * region.contourList[0].Length()))
				{
					continue;
				}
			}
			return i;
		}
		return -1;
	}

	internal ICurve[] _0023_003Dzc82cILbi9HyU(Face _0023_003DzWXFXOqg_003D)
	{
		List<ICurve> list = new List<ICurve>(_0023_003DzWXFXOqg_003D.Loops.Length);
		Loop[] loops = _0023_003DzWXFXOqg_003D.Loops;
		for (int i = 0; i < loops.Length; i++)
		{
			OrientedEdge[] segments = loops[i].Segments;
			for (int j = 0; j < segments.Length; j++)
			{
				OrientedEdge orientedEdge = segments[j];
				list.Add(Edges[orientedEdge.CurveIndex].Curve);
			}
		}
		return list.ToArray();
	}

	private void _0023_003Dz8nn2PNTEXNhi(RegenParams _0023_003DzZtFpRmA_003D)
	{
		for (int i = 0; i < _edges.Length; i++)
		{
			((Entity)_edges[i].Curve).Regen(_0023_003DzZtFpRmA_003D);
		}
		_0023_003DzyEzAPA6dc1tX74Pv8nN6G9zMB_ggkunhuw_003D_003D(Faces, _0023_003DzZtFpRmA_003D);
		Face[][] inners = _inners;
		foreach (Face[] _0023_003DzEtn4dIEPKCsi in inners)
		{
			_0023_003DzyEzAPA6dc1tX74Pv8nN6G9zMB_ggkunhuw_003D_003D(_0023_003DzEtn4dIEPKCsi, _0023_003DzZtFpRmA_003D);
		}
	}

	private void _0023_003DzyEzAPA6dc1tX74Pv8nN6G9zMB_ggkunhuw_003D_003D(Face[] _0023_003DzEtn4dIEPKCsi, RegenParams _0023_003DzZtFpRmA_003D)
	{
		int num = _0023_003DzEtn4dIEPKCsi.Length;
		HashSet<int> hashSet = new HashSet<int>();
		for (int i = 0; i < num; i++)
		{
			Face face = _0023_003DzEtn4dIEPKCsi[i];
			bool flag = false;
			if (face.Surface is ToroidalSurf || face.Surface is SphericalSurf)
			{
				flag = true;
			}
			else if (face.Surface is RevolvedSurf revolvedSurf && (revolvedSurf.Generatrix is Arc || revolvedSurf.Generatrix is Circle))
			{
				flag = true;
			}
			if (!flag)
			{
				continue;
			}
			int num2 = face.Loops.Length;
			ICurve[] orientedTrimLoops = face.GetOrientedTrimLoops(_edges);
			if (orientedTrimLoops.Length == 0)
			{
				face.Tessellation = new FastMesh(new float[0], new int[0], new float[0]);
				continue;
			}
			Surface notRotated;
			Surface untrimmed = face.Surface.GetUntrimmed(orientedTrimLoops, face.Sense, out notRotated);
			bool flag2 = untrimmed.GetType() == typeof(SphericalSurface);
			bool flag3 = untrimmed is ToroidalSurface toroidalSurface && toroidalSurface.Type == torusType.Donut;
			if (!(flag2 || flag3))
			{
				continue;
			}
			double num3 = 0.0;
			double num4 = 0.0;
			Interval interval = default(Interval);
			Interval interval2 = default(Interval);
			double num5 = 0.0;
			double num6 = 0.0;
			Size2D size2D = Surface._0023_003DzEJKmOg1IZUbn(untrimmed);
			num3 = size2D.X / untrimmed._0023_003DzVx1luJEZaaC7().X;
			num4 = size2D.Y / untrimmed._0023_003DzVx1luJEZaaC7().Y;
			double val = double.MaxValue;
			double val2 = double.MaxValue;
			double val3 = double.MinValue;
			double val4 = double.MinValue;
			ICurve[] array = orientedTrimLoops;
			for (int j = 0; j < array.Length; j++)
			{
				ICurve[] individualCurves = array[j].GetIndividualCurves();
				double num7 = double.MaxValue;
				double num8 = double.MaxValue;
				double num9 = double.MinValue;
				double num10 = double.MinValue;
				ICurve[] array2 = individualCurves;
				foreach (ICurve curve in array2)
				{
					if (((Entity)curve).Vertices == null)
					{
						((Entity)curve).Regen(_0023_003DzZtFpRmA_003D);
					}
					bool flag4 = false;
					bool flag5 = false;
					bool flag6 = false;
					bool flag7 = false;
					double num11 = double.MaxValue;
					double num12 = double.MaxValue;
					for (int l = 0; l < ((Entity)curve).Vertices.Length; l++)
					{
						Point3D p = ((Entity)curve).Vertices[l];
						untrimmed.PointInversion(p, _0023_003DzZtFpRmA_003D.Deviation, out double u, out double v);
						flag6 = !untrimmed.IsClosedU || !(Math.Abs(u - untrimmed.DomainU.Low) < 1E-12);
						flag7 = !untrimmed.IsClosedV || !(Math.Abs(v - untrimmed.DomainV.Low) < 1E-12);
						if (flag6)
						{
							num7 = Math.Min(num7, u);
							num9 = Math.Max(num9, u);
							num11 = u;
						}
						if (l > 0 && flag4 && !flag6)
						{
							double val5 = ((Math.Abs(num11 - untrimmed.DomainU.Low) < Math.Abs(num11 - untrimmed.DomainU.High)) ? untrimmed.DomainU.Low : untrimmed.DomainU.High);
							num7 = Math.Min(num7, val5);
							num9 = Math.Max(num9, val5);
						}
						if (l > 0 && !flag4 && flag6)
						{
							double val6 = ((Math.Abs(u - untrimmed.DomainU.Low) < Math.Abs(u - untrimmed.DomainU.High)) ? untrimmed.DomainU.Low : untrimmed.DomainU.High);
							num7 = Math.Min(num7, val6);
							num9 = Math.Max(num9, val6);
						}
						if (flag7)
						{
							num8 = Math.Min(num8, v);
							num10 = Math.Max(num10, v);
							num12 = v;
						}
						if (l > 0 && flag5 && !flag7)
						{
							double val7 = ((Math.Abs(num12 - untrimmed.DomainV.Low) < Math.Abs(num12 - untrimmed.DomainV.High)) ? untrimmed.DomainV.Low : untrimmed.DomainV.High);
							num8 = Math.Min(num8, val7);
							num10 = Math.Max(num10, val7);
						}
						if (l > 0 && !flag5 && flag7)
						{
							double val8 = ((Math.Abs(v - untrimmed.DomainV.Low) < Math.Abs(v - untrimmed.DomainV.High)) ? untrimmed.DomainV.Low : untrimmed.DomainV.High);
							num8 = Math.Min(num8, val8);
							num10 = Math.Max(num10, val8);
						}
						flag4 = flag6;
						flag5 = flag7;
					}
					if (untrimmed.IsClosedU && curve.IsClosed)
					{
						if (Utility._0023_003DzucHjZcB1y1ms(num7, untrimmed.DomainU.Low, untrimmed.DomainU.Length * num3))
						{
							num9 = untrimmed.DomainU.High;
						}
						else if (Utility._0023_003DzucHjZcB1y1ms(num9, untrimmed.DomainU.High, untrimmed.DomainU.Length * num3))
						{
							num7 = untrimmed.DomainU.Low;
						}
					}
					if (untrimmed.IsClosedV && curve.IsClosed)
					{
						if (Utility._0023_003DzucHjZcB1y1ms(num8, untrimmed.DomainV.Low, untrimmed.DomainV.Length * num4))
						{
							num10 = untrimmed.DomainV.High;
						}
						else if (Utility._0023_003DzucHjZcB1y1ms(num10, untrimmed.DomainV.High, untrimmed.DomainV.Length * num4))
						{
							num8 = untrimmed.DomainV.Low;
						}
					}
				}
				val = Math.Min(val, num7);
				val3 = Math.Max(val3, num9);
				val2 = Math.Min(val2, num8);
				val4 = Math.Max(val4, num10);
			}
			val = Math.Max(val, untrimmed.DomainU.Low);
			val2 = Math.Max(val2, untrimmed.DomainV.Low);
			val3 = Math.Min(val3, untrimmed.DomainU.High);
			val4 = Math.Min(val4, untrimmed.DomainV.High);
			interval = new Interval(0.0, val3 - val);
			interval2 = new Interval(0.0, val4 - val2);
			int num13 = 0;
			int num14 = 0;
			if (flag3)
			{
				ToroidalSurface obj = (ToroidalSurface)untrimmed;
				num5 = obj.MajorRadius;
				num6 = obj.MinorRadius;
				num13 = Utility.NumberOfSegments(num5 + num6, interval.Length, _0023_003DzZtFpRmA_003D.Deviation / 2.0);
				num14 = Utility.NumberOfSegments(num6, interval2.Length, _0023_003DzZtFpRmA_003D.Deviation / 2.0);
				double num15 = interval.Length * num3 / (double)num13;
				double num16 = interval2.Length * num4 / (double)num14;
				if (num15 > 1000.0 * num16)
				{
					num13 = (int)(interval.Length * num3 / (1000.0 * num16));
				}
				else if (num16 > 1000.0 * num15)
				{
					num14 = (int)(interval2.Length * num4 / (1000.0 * num15));
				}
				int num17 = 4;
				if (num13 < num17)
				{
					num13 = num17;
				}
				if (num14 < num17)
				{
					num14 = num17;
				}
			}
			else if (flag2)
			{
				SphericalSurface obj2 = (SphericalSurface)untrimmed;
				num13 = Utility.NumberOfSegments(obj2.Radius, interval.Length, _0023_003DzZtFpRmA_003D.Deviation / 2.0) + 1;
				num14 = Utility.NumberOfSegments(obj2.Radius, interval2.Length, _0023_003DzZtFpRmA_003D.Deviation / 2.0);
				int num18 = 4;
				if (num13 < num18)
				{
					num13 = num18;
				}
				if (num14 < num18)
				{
					num14 = num18;
				}
			}
			for (int m = 0; m < num2; m++)
			{
				Loop loop = face.Loops[m];
				CompositeCurve compositeCurve = new CompositeCurve();
				int num19 = loop.Segments.Length;
				compositeCurve.CurveList.Capacity = num19;
				for (int n = 0; n < num19; n++)
				{
					OrientedEdge orientedEdge = loop.Segments[n];
					if (hashSet.Contains(orientedEdge.CurveIndex))
					{
						continue;
					}
					Edge edge = Edges[orientedEdge.CurveIndex];
					bool flag8 = false;
					bool flag9 = false;
					ICurve curve2 = edge.Curve;
					double u2;
					double v2;
					bool num20 = untrimmed.PointInversion(curve2.StartPoint, _0023_003DzZtFpRmA_003D.Deviation, out u2, out v2);
					double u3;
					double v3;
					bool flag10 = untrimmed.PointInversion(curve2.EndPoint, _0023_003DzZtFpRmA_003D.Deviation, out u3, out v3);
					if (untrimmed.IsClosedU && Utility._0023_003DzucHjZcB1y1ms(u2, u3, untrimmed.DomainU.Length) && Utility._0023_003DzucHjZcB1y1ms(u3, untrimmed.DomainU.Low, untrimmed.DomainU.Length) && curve2.IsClosed && curve2.Length() > 1E-12 * num3)
					{
						u3 = untrimmed.DomainU.High;
					}
					else if (untrimmed.IsClosedU && Utility._0023_003DzucHjZcB1y1ms(u2, u3, untrimmed.DomainU.Length) && Utility._0023_003DzucHjZcB1y1ms(u2, untrimmed.DomainU.High, untrimmed.DomainU.Length) && curve2.IsClosed && curve2.Length() > 1E-12 * num3)
					{
						u2 = untrimmed.DomainU.Low;
					}
					if (untrimmed.IsClosedV && Utility._0023_003DzucHjZcB1y1ms(v2, v3, untrimmed.DomainU.Length) && Utility._0023_003DzucHjZcB1y1ms(v3, untrimmed.DomainV.Low, untrimmed.DomainV.Length) && curve2.IsClosed && curve2.Length() > 1E-12 * num4)
					{
						v3 = untrimmed.DomainV.High;
					}
					else if (untrimmed.IsClosedV && Utility._0023_003DzucHjZcB1y1ms(v2, v3, untrimmed.DomainU.Length) && Utility._0023_003DzucHjZcB1y1ms(v2, untrimmed.DomainV.High, untrimmed.DomainV.Length) && curve2.IsClosed && curve2.Length() > 1E-12 * num4)
					{
						v2 = untrimmed.DomainV.Low;
					}
					if (num20 && flag10)
					{
						untrimmed.PointInversion(curve2.PointAt(curve2.Domain.ParameterAt(0.01)), _0023_003DzZtFpRmA_003D.Deviation, out double u4, out double v4);
						untrimmed.PointInversion(curve2.PointAt(curve2.Domain.ParameterAt(0.99)), _0023_003DzZtFpRmA_003D.Deviation, out double u5, out double v5);
						if (untrimmed.IsClosedU)
						{
							if (Utility._0023_003DzucHjZcB1y1ms(u2, untrimmed.DomainU.Low, untrimmed.DomainU.Length) && Math.Abs(u4 - u2) > untrimmed.DomainU.Length / 2.0)
							{
								u2 = untrimmed.DomainU.High;
							}
							else if (Utility._0023_003DzucHjZcB1y1ms(u2, untrimmed.DomainU.High, untrimmed.DomainU.Length) && Math.Abs(u4 - u2) > untrimmed.DomainU.Length / 2.0)
							{
								u2 = untrimmed.DomainU.Low;
							}
							if (Utility._0023_003DzucHjZcB1y1ms(u3, untrimmed.DomainU.Low, untrimmed.DomainU.Length) && Math.Abs(u5 - u3) > untrimmed.DomainU.Length / 2.0)
							{
								u3 = untrimmed.DomainU.High;
							}
							else if (Utility._0023_003DzucHjZcB1y1ms(u3, untrimmed.DomainU.High, untrimmed.DomainU.Length) && Math.Abs(u5 - u3) > untrimmed.DomainU.Length / 2.0)
							{
								u3 = untrimmed.DomainU.Low;
							}
						}
						if (untrimmed.IsClosedV)
						{
							if (Utility._0023_003DzucHjZcB1y1ms(v2, untrimmed.DomainV.Low, untrimmed.DomainV.Length) && Math.Abs(v4 - v2) > untrimmed.DomainV.Length / 2.0)
							{
								v2 = untrimmed.DomainV.High;
							}
							else if (Utility._0023_003DzucHjZcB1y1ms(v2, untrimmed.DomainV.High, untrimmed.DomainV.Length) && Math.Abs(v4 - v2) > untrimmed.DomainV.Length / 2.0)
							{
								v2 = untrimmed.DomainV.Low;
							}
							if (Utility._0023_003DzucHjZcB1y1ms(v3, untrimmed.DomainV.Low, untrimmed.DomainV.Length) && Math.Abs(v5 - v3) > untrimmed.DomainV.Length / 2.0)
							{
								v3 = untrimmed.DomainV.High;
							}
							else if (Utility._0023_003DzucHjZcB1y1ms(v3, untrimmed.DomainV.High, untrimmed.DomainV.Length) && Math.Abs(v5 - v3) > untrimmed.DomainV.Length / 2.0)
							{
								v3 = untrimmed.DomainV.Low;
							}
						}
						Vector2D vector2D = new Vector2D(u4 - u2, v4 - v2);
						vector2D.Normalize();
						Vector2D vector2D2 = new Vector2D(u3 - u5, v3 - v5);
						vector2D2.Normalize();
						Point2D _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D;
						bool flag11 = untrimmed._0023_003DzgXk8Ru_iJQUJ(curve2.StartPoint, 1E-05, out _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D);
						bool flag12 = untrimmed._0023_003DzgXk8Ru_iJQUJ(curve2.EndPoint, 1E-05, out _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D);
						double v6;
						if (flag11)
						{
							untrimmed.PointInversion(curve2.PointAt(curve2.Domain.ParameterAt(0.001)), _0023_003DzZtFpRmA_003D.Deviation, out double u6, out v6);
							vector2D = new Vector2D(u4 - u6, v4 - v2);
							vector2D.Normalize();
							u2 = u6;
						}
						if (flag12)
						{
							untrimmed.PointInversion(curve2.PointAt(curve2.Domain.ParameterAt(0.999)), _0023_003DzZtFpRmA_003D.Deviation, out double u7, out v6);
							vector2D2 = new Vector2D(u7 - u5, v3 - v5);
							vector2D2.Normalize();
							u3 = u7;
						}
						flag9 = (Utility._0023_003DzucHjZcB1y1ms(u2, u3, untrimmed.DomainU.Length) || flag11 || flag12) && Vector2D.AreParallel(vector2D, Vector2D.AxisY) && Vector2D.AreParallel(vector2D2, Vector2D.AxisY);
						flag8 = Utility._0023_003DzucHjZcB1y1ms(v2, v3, untrimmed.DomainV.Length) && Vector2D.AreParallel(vector2D, Vector2D.AxisX) && Vector2D.AreParallel(vector2D2, Vector2D.AxisX);
					}
					if (!(flag8 || flag9) || (flag8 && flag9))
					{
						continue;
					}
					bool flag13 = false;
					int num21 = 0;
					if (flag8)
					{
						if (num13 > 1024)
						{
							num13 = 1024;
						}
						num21 = num13;
						flag13 = Utility._0023_003DzucHjZcB1y1ms(Math.Abs(u2 - u3), interval.Length, interval.Length * num3);
					}
					else
					{
						if (num14 > 1024)
						{
							num14 = 1024;
						}
						num21 = num14;
						flag13 = Utility._0023_003DzucHjZcB1y1ms(Math.Abs(v2 - v3), interval2.Length, interval2.Length * num4);
					}
					if (flag13)
					{
						if (((Entity)curve2).Vertices.Length <= num21 + 1)
						{
							if (curve2.GetType() == typeof(Circle))
							{
								((Circle)curve2)._0023_003DzAWinFpBcJb6_3uUJ15BE5C0_003D(_0023_003DzZtFpRmA_003D, num21 - 1);
								hashSet.Add(orientedEdge.CurveIndex);
							}
							else if (curve2.GetType() == typeof(Arc))
							{
								((Arc)curve2)._0023_003DzAWinFpBcJb6_3uUJ15BE5C0_003D(_0023_003DzZtFpRmA_003D, num21 - 1);
								hashSet.Add(orientedEdge.CurveIndex);
							}
							else if (curve2 is Curve)
							{
								((Curve)curve2)._0023_003DzAWinFpBcJb6_3uUJ15BE5C0_003D(_0023_003DzZtFpRmA_003D, num21 - 1);
								hashSet.Add(orientedEdge.CurveIndex);
							}
						}
						continue;
					}
					List<double> list = new List<double>();
					double num22;
					double num23;
					if (flag8)
					{
						num22 = u2;
						num23 = u3;
						Interval interval3 = new Interval(num22, num23);
						for (int num24 = 1; num24 <= num21 - 1; num24++)
						{
							double num25 = val + (double)num24 / (double)(num21 - 1) * (val3 - val);
							if (interval3.Includes(num25, testOpenInterval: true))
							{
								list.Add(num25);
							}
						}
					}
					else
					{
						num22 = v2;
						num23 = v3;
						Interval interval4 = new Interval(num22, num23);
						for (int num26 = 1; num26 <= num21 - 1; num26++)
						{
							double num27 = val2 + (double)num26 / (double)(num21 - 1) * (val4 - val2);
							if (interval4.Includes(num27, testOpenInterval: true) && !Utility._0023_003DzucHjZcB1y1ms(num27, num22, interval4.Length) && !Utility._0023_003DzucHjZcB1y1ms(num27, num23, interval4.Length))
							{
								list.Add(num27);
							}
						}
					}
					if (((Entity)curve2).Vertices.Length <= list.Count + 2)
					{
						if (curve2.GetType() == typeof(Circle))
						{
							((Circle)curve2)._0023_003Dzci7aJXfjtY_00243OTtVfw_003D_003D(_0023_003DzZtFpRmA_003D, list, num22, num23);
							hashSet.Add(orientedEdge.CurveIndex);
						}
						else if (curve2.GetType() == typeof(Arc))
						{
							((Arc)curve2)._0023_003Dzci7aJXfjtY_00243OTtVfw_003D_003D(_0023_003DzZtFpRmA_003D, list, num22, num23);
							hashSet.Add(orientedEdge.CurveIndex);
						}
						else if (curve2 is Curve)
						{
							((Curve)curve2)._0023_003Dzci7aJXfjtY_00243OTtVfw_003D_003D(_0023_003DzZtFpRmA_003D, list, num22, num23);
							hashSet.Add(orientedEdge.CurveIndex);
						}
					}
				}
			}
		}
	}

	public Surface[] ConvertToSurfaces(double rebuildTol = 0.0)
	{
		if (rebuildTol == 0.0)
		{
			Rebuild(0.0, soft: true);
			List<Surface> list = new List<Surface>(_faces.Length);
			_0023_003DzY2v1k5MR6TJN(_faces, list);
			Face[][] inners = _inners;
			foreach (Face[] _0023_003DzEtn4dIEPKCsi in inners)
			{
				_0023_003DzY2v1k5MR6TJN(_0023_003DzEtn4dIEPKCsi, list);
			}
			return list.ToArray();
		}
		Brep obj = (Brep)Clone();
		obj.Rebuild(rebuildTol);
		return obj.ConvertToSurfaces();
	}

	private void _0023_003DzY2v1k5MR6TJN(Face[] _0023_003DzEtn4dIEPKCsi, List<Surface> _0023_003Dz6MbJmZmXz92vcvaETQ_003D_003D)
	{
		int num = _0023_003DzEtn4dIEPKCsi.Length;
		for (int i = 0; i < num; i++)
		{
			Face face = _0023_003DzEtn4dIEPKCsi[i];
			_0023_003Dz6MbJmZmXz92vcvaETQ_003D_003D.AddRange(face.ConvertToSurface(this));
		}
	}

	public Solid ConvertToSolid(double deviation = 0.0, double angle = 0.0)
	{
		return ConvertToMesh(deviation, angle).ConvertToSolid();
	}

	public bool FlipOutward()
	{
		if (GetVolume(out var _) < 0.0)
		{
			FlipNormal();
			return true;
		}
		return false;
	}

	public int FixNormals()
	{
		int _0023_003Dznu938GrBOa47O4GGZxcfk_g_003D = 0;
		int _0023_003Dz3leha9I_003D = 0;
		bool[] _0023_003Dz4sg0Qp0_003D = new bool[_faces.Length];
		_0023_003DzrVgJszT0q3_zz3HiCg_003D_003D(0, _0023_003Dz9QB0faOI1j_00249: false, _0023_003Dz4sg0Qp0_003D, _edges, _faces, ref _0023_003Dznu938GrBOa47O4GGZxcfk_g_003D, ref _0023_003Dz3leha9I_003D);
		Face[][] inners = _inners;
		foreach (Face[] array in inners)
		{
			_0023_003Dz4sg0Qp0_003D = new bool[array.Length];
			_0023_003DzrVgJszT0q3_zz3HiCg_003D_003D(0, _0023_003Dz9QB0faOI1j_00249: false, _0023_003Dz4sg0Qp0_003D, _edges, array, ref _0023_003Dznu938GrBOa47O4GGZxcfk_g_003D, ref _0023_003Dz3leha9I_003D);
		}
		if (_0023_003Dznu938GrBOa47O4GGZxcfk_g_003D > 0)
		{
			RegenMode = regenType.RegenAndCompile;
		}
		return _0023_003Dznu938GrBOa47O4GGZxcfk_g_003D;
	}

	private static void _0023_003DzrVgJszT0q3_zz3HiCg_003D_003D(int _0023_003Dz6F3vY3100So0, bool _0023_003Dz9QB0faOI1j_00249, bool[] _0023_003Dz4sg0Qp0_003D, Edge[] _0023_003DzU3hosSAzkxO7, Face[] _0023_003DzpPOEJqcAh7Lr, ref int _0023_003Dznu938GrBOa47O4GGZxcfk_g_003D, ref int _0023_003Dz3leha9I_003D)
	{
		Stack<(int, bool)> stack = new Stack<(int, bool)>();
		stack.Push((_0023_003Dz6F3vY3100So0, _0023_003Dz9QB0faOI1j_00249));
		while (stack.Count > 0)
		{
			var (num, flag) = stack.Pop();
			if (_0023_003Dz4sg0Qp0_003D[num])
			{
				continue;
			}
			_0023_003Dz4sg0Qp0_003D[num] = true;
			_0023_003Dz3leha9I_003D++;
			Face face = _0023_003DzpPOEJqcAh7Lr[num];
			if (flag)
			{
				face.Flip();
				_0023_003Dznu938GrBOa47O4GGZxcfk_g_003D++;
			}
			Loop[] loops = face.Loops;
			foreach (Loop loop in loops)
			{
				bool sense = loop.Sense;
				OrientedEdge[] segments = loop.Segments;
				for (int j = 0; j < segments.Length; j++)
				{
					OrientedEdge orientedEdge = segments[j];
					Edge edge = _0023_003DzU3hosSAzkxO7[orientedEdge.CurveIndex];
					if (edge.Parents.Length >= 3)
					{
						continue;
					}
					int[] parents = edge.Parents;
					foreach (int num2 in parents)
					{
						if (_0023_003Dz4sg0Qp0_003D[num2])
						{
							continue;
						}
						Loop[] loops2 = _0023_003DzpPOEJqcAh7Lr[num2].Loops;
						foreach (Loop loop2 in loops2)
						{
							bool sense2 = loop2.Sense;
							OrientedEdge[] segments2 = loop2.Segments;
							for (int m = 0; m < segments2.Length; m++)
							{
								OrientedEdge orientedEdge2 = segments2[m];
								if (orientedEdge.CurveIndex == orientedEdge2.CurveIndex)
								{
									bool item = _0023_003DzzSOxDJ7_SFj3(sense, orientedEdge.Sense) == _0023_003DzzSOxDJ7_SFj3(sense2, orientedEdge2.Sense);
									stack.Push((num2, item));
								}
							}
						}
					}
				}
			}
		}
		if (_0023_003Dz3leha9I_003D < _0023_003DzpPOEJqcAh7Lr.Length)
		{
			int n;
			for (n = 0; n < _0023_003Dz4sg0Qp0_003D.Length && _0023_003Dz4sg0Qp0_003D[n]; n++)
			{
			}
			_0023_003DzrVgJszT0q3_zz3HiCg_003D_003D(n, _0023_003Dz9QB0faOI1j_00249: false, _0023_003Dz4sg0Qp0_003D, _0023_003DzU3hosSAzkxO7, _0023_003DzpPOEJqcAh7Lr, ref _0023_003Dznu938GrBOa47O4GGZxcfk_g_003D, ref _0023_003Dz3leha9I_003D);
		}
	}

	private static bool _0023_003DzzSOxDJ7_SFj3(bool _0023_003DzhMdLYtHTEBWu, bool _0023_003Dz5ZKyO3OkSX71)
	{
		return _0023_003DzhMdLYtHTEBWu ^ _0023_003Dz5ZKyO3OkSX71;
	}

	public void FlipNormal()
	{
		_0023_003Dz3jeSWxABmWS4(_faces);
		Face[][] inners = _inners;
		foreach (Face[] _0023_003DzEtn4dIEPKCsi in inners)
		{
			_0023_003Dz3jeSWxABmWS4(_0023_003DzEtn4dIEPKCsi);
		}
		RegenMode = regenType.RegenAndCompile;
	}

	internal void _0023_003Dz3jeSWxABmWS4(Face[] _0023_003DzEtn4dIEPKCsi)
	{
		for (int i = 0; i < _0023_003DzEtn4dIEPKCsi.Length; i++)
		{
			_0023_003DzEtn4dIEPKCsi[i].Flip();
		}
	}

	private static void _0023_003DzAPllSwUuGBft(Face[] _0023_003DzEtn4dIEPKCsi)
	{
		foreach (Face face in _0023_003DzEtn4dIEPKCsi)
		{
			if (face.Surface is NurbsSurf)
			{
				face.Sense = !face.Sense;
			}
			face._0023_003Dzuc_5f2_0024SKYRM();
		}
	}

	[SpecialName]
	internal override bool _0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D()
	{
		if (base._0023_003DzhyxDeuUGo6PSyb6RHQ_003D_003D() && Edges != null && Edges.Length != 0 && Faces != null && Faces.Length != 0)
		{
			return Faces[0].Tessellation != null;
		}
		return false;
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new BrepSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
	{
		base.GetObjectData(info, ctxt);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), _vertices);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302954162), _edges);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958659), _faces);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958671), _inners);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958654), _silhouettesDrawingMode);
	}

	public double ClosestPointTo(Point3D P, out Point3D closest)
	{
		double _0023_003DzsVw1i9LkTBtX = double.MaxValue;
		closest = null;
		double _0023_003DzMeLY8V4_003D = 1.0;
		_0023_003DzAzVFPYFo2TLf(_faces, P, ref closest, ref _0023_003DzsVw1i9LkTBtX, ref _0023_003DzMeLY8V4_003D);
		Face[][] inners = _inners;
		for (int i = 0; i < inners.Length; i++)
		{
			_0023_003DzAzVFPYFo2TLf(inners[i], P, ref closest, ref _0023_003DzsVw1i9LkTBtX, ref _0023_003DzMeLY8V4_003D);
		}
		return _0023_003DzMeLY8V4_003D * _0023_003DzsVw1i9LkTBtX;
	}

	public bool FixTopology(StringBuilder log = null)
	{
		if (!_0023_003Dzo7dlnN8P4j7nmTiMBg_003D_003D(log, out var _0023_003DzhFidXaRsVK1EU3fHng_003D_003D))
		{
			return false;
		}
		if (_0023_003DzhFidXaRsVK1EU3fHng_003D_003D._0023_003DzcXqsW5xVLz8J(log, _0023_003DzEuQ72GKNmfZl: true) == -1)
		{
			return false;
		}
		_0023_003Dzd55uIPSKitfg(_0023_003DzhFidXaRsVK1EU3fHng_003D_003D.Vertices, _0023_003DzhFidXaRsVK1EU3fHng_003D_003D.Edges, _0023_003DzhFidXaRsVK1EU3fHng_003D_003D.Faces, _0023_003DzhFidXaRsVK1EU3fHng_003D_003D.Inners);
		return true;
	}

	private bool _0023_003Dzo7dlnN8P4j7nmTiMBg_003D_003D(StringBuilder _0023_003DzqmF8XJ0_003D, out Brep _0023_003DzhFidXaRsVK1EU3fHng_003D_003D)
	{
		Brep brep = (Brep)Clone();
		brep.Rebuild(0.0, soft: true);
		List<Point3D> list = brep._vertices.ToList();
		List<Edge> list2 = brep._edges.ToList();
		List<Face> list3 = brep._faces.ToList();
		List<Face>[] array = brep._inners.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzYUKPDc0_cYRiXqVIsqESXWASX0ZP_qBjKg_003D_003D).ToArray();
		_0023_003DzhFidXaRsVK1EU3fHng_003D_003D = null;
		for (int i = 0; i < _faces.Length; i++)
		{
			Face _0023_003DzHEpjcdg2hk9U = list3[i];
			if (!brep._0023_003Dza__0024FXr7fuR0en8POmA_003D_003D(_0023_003DzHEpjcdg2hk9U, list, list2, list3, i, _0023_003DzqmF8XJ0_003D))
			{
				return false;
			}
		}
		for (int j = 0; j < _inners.Length; j++)
		{
			for (int k = 0; k < _inners[j].Length; k++)
			{
				Face _0023_003DzHEpjcdg2hk9U2 = array[j][k];
				if (!brep._0023_003Dza__0024FXr7fuR0en8POmA_003D_003D(_0023_003DzHEpjcdg2hk9U2, list, list2, array[j], k, _0023_003DzqmF8XJ0_003D))
				{
					return false;
				}
			}
		}
		brep._vertices = list.ToArray();
		brep._edges = list2.ToArray();
		brep._faces = list3.ToArray();
		brep._inners = array.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzSy8kp_dFE_fwuMdgqb717vvl1AUYOyCqNA_003D_003D).ToArray();
		brep._0023_003DzUE6pJD8Y3NVt();
		brep._0023_003DzDumeg9jsTU7S(_0023_003Dzxt7paKBusKOo: false);
		brep.localMin = localMin;
		brep.localMax = localMax;
		_0023_003DzhFidXaRsVK1EU3fHng_003D_003D = brep;
		return true;
	}

	private bool _0023_003Dza__0024FXr7fuR0en8POmA_003D_003D(Face _0023_003DzHEpjcdg2hk9U, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, List<Edge> _0023_003DzViGQVPM_003D, List<Face> _0023_003DzUbkxYVFDH3ry, int _0023_003Dzfe2zeQMumw_4, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		if (_0023_003DzHEpjcdg2hk9U.Surface.GetType() == typeof(PlanarSurf) || (_0023_003DzHEpjcdg2hk9U.Surface is TabulatedSurf tabulatedSurf && !tabulatedSurf.Directrix.IsClosed))
		{
			return true;
		}
		if (_0023_003DzHEpjcdg2hk9U._0023_003Dz9FCm9_0024CiAUGE())
		{
			return false;
		}
		_0023_003DzHEpjcdg2hk9U.GetLoopsControlBoundingBox(_0023_003DzViGQVPM_003D, out var min, out var max);
		double num = new Size3D(min, max).Diagonal * Utility._0023_003DzxhnLabVjXjPg;
		for (int i = 0; i < _0023_003DzHEpjcdg2hk9U.Parametric.Length; i++)
		{
			Surface surface = _0023_003DzHEpjcdg2hk9U.Parametric[i];
			if (!surface.IsClosedU && !surface.IsClosedV)
			{
				return true;
			}
			List<Tuple<int, TrimCurve>> list = new List<Tuple<int, TrimCurve>>();
			Region trimming = surface.Trimming;
			Loop[] array = new Loop[trimming.ContourList.Count];
			int num2 = 0;
			int num3 = 0;
			for (int j = 0; j < trimming.ContourList.Count; j++)
			{
				ICurve[] individualCurves = trimming.ContourList[j].GetIndividualCurves();
				List<OrientedEdge> list2 = new List<OrientedEdge>();
				bool sense = _0023_003DzHEpjcdg2hk9U.Loops[num2].Sense;
				for (int k = 0; k < individualCurves.Length; k++)
				{
					TrimCurve trimCurve = (TrimCurve)individualCurves[k];
					if (trimCurve.EdgeIndex == -1 && trimCurve.Edge.Length() > num)
					{
						bool flag = false;
						for (int l = 0; l < list.Count; l++)
						{
							int item = list[l].Item1;
							TrimCurve item2 = list[l].Item2;
							bool flag2 = Point3D.Distance(trimCurve.Edge.StartPoint, _0023_003DzViGQVPM_003D[item].Curve.StartPoint) < num;
							bool flag3 = Point3D.Distance(trimCurve.Edge.StartPoint, _0023_003DzViGQVPM_003D[item].Curve.EndPoint) < num;
							if ((flag2 || flag3) && Vector3D.AreParallel(trimCurve.StartTangent, item2.StartTangent))
							{
								bool flag4 = flag2 && Vector3D.AreCoincident(trimCurve.StartTangent, item2.StartTangent);
								trimCurve.EdgeIndex = item;
								list2.Add(new OrientedEdge(item, flag4 == sense));
								flag = true;
							}
						}
						if (!flag)
						{
							int num4 = _0023_003DzFzdNOyVjNMkt(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003DzViGQVPM_003D, num, individualCurves, k, _0023_003DzqmF8XJ0_003D);
							TrimCurve trimCurve2 = trimCurve;
							bool flag5 = Point3D.Distance(trimCurve.Edge.StartPoint, _0023_003DzViGQVPM_003D[num4].Curve.StartPoint) < num;
							bool flag6 = Point3D.Distance(trimCurve.Edge.StartPoint, _0023_003DzViGQVPM_003D[num4].Curve.EndPoint) < num;
							if ((flag5 || flag6) && Vector3D.AreParallel(trimCurve.StartTangent, trimCurve2.StartTangent))
							{
								bool flag7 = flag5 && Vector3D.AreCoincident(trimCurve.StartTangent, trimCurve2.StartTangent);
								trimCurve.EdgeIndex = num4;
								list2.Add(new OrientedEdge(num4, flag7 == sense));
								list.Add(new Tuple<int, TrimCurve>(num4, trimCurve2));
							}
						}
					}
					else
					{
						if (trimCurve.EdgeIndex == -1)
						{
							continue;
						}
						bool flag8 = false;
						for (int m = num2; m < _0023_003DzHEpjcdg2hk9U.Loops.Length; m++)
						{
							for (int n = num3; n < _0023_003DzHEpjcdg2hk9U.Loops[m].Segments.Length; n++)
							{
								if (_0023_003DzHEpjcdg2hk9U.Loops[m].Segments[n].CurveIndex == trimCurve.EdgeIndex)
								{
									list2.Add(_0023_003DzHEpjcdg2hk9U.Loops[m].Segments[n]);
									_0023_003DzViGQVPM_003D[_0023_003DzHEpjcdg2hk9U.Loops[m].Segments[n].CurveIndex] = (Edge)_edges[_0023_003DzHEpjcdg2hk9U.Loops[m].Segments[n].CurveIndex].Clone();
									_0023_003DzViGQVPM_003D[_0023_003DzHEpjcdg2hk9U.Loops[m].Segments[n].CurveIndex].Parents = null;
									num3 = n++ % _0023_003DzHEpjcdg2hk9U.Loops[m].Segments.Length;
									flag8 = true;
									break;
								}
								if (n + 1 >= _0023_003DzHEpjcdg2hk9U.Loops[m].Segments.Length && num3 != 0)
								{
									num3 = 0;
									n = -1;
								}
							}
							if (flag8)
							{
								num2 = m;
								break;
							}
							if (m + 1 >= _0023_003DzHEpjcdg2hk9U.Loops.Length && num2 != 0)
							{
								num2 = 0;
								m = -1;
							}
							else if (m + 1 >= _0023_003DzHEpjcdg2hk9U.Loops.Length)
							{
								return false;
							}
						}
					}
				}
				if (list.Count == 0)
				{
					return true;
				}
				if (!sense)
				{
					list2.Reverse();
				}
				array[j] = new Loop(list2.ToArray(), sense);
			}
			Face face = (Face)_0023_003DzHEpjcdg2hk9U.Clone();
			face.Loops = array;
			face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(new Surface[1] { (Surface)surface.Clone() });
			face.needRebuild = _0023_003DzHEpjcdg2hk9U.needRebuild;
			if (i == 0)
			{
				_0023_003DzUbkxYVFDH3ry[_0023_003Dzfe2zeQMumw_4] = face;
			}
			else
			{
				_0023_003DzUbkxYVFDH3ry.Add(face);
			}
		}
		return true;
	}

	private static int _0023_003DzFzdNOyVjNMkt(List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, List<Edge> _0023_003DzViGQVPM_003D, double _0023_003Dz85DwsjHHsAwG, ICurve[] _0023_003DzKTAIrow_003D, int _0023_003DzTSeNR8Q_003D, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		TrimCurve trimCurve = (TrimCurve)_0023_003DzKTAIrow_003D[_0023_003DzTSeNR8Q_003D];
		TrimCurve trimCurve2 = (TrimCurve)_0023_003DzKTAIrow_003D[(_0023_003DzTSeNR8Q_003D + _0023_003DzKTAIrow_003D.Length - 1) % _0023_003DzKTAIrow_003D.Length];
		TrimCurve trimCurve3 = (TrimCurve)_0023_003DzKTAIrow_003D[(_0023_003DzTSeNR8Q_003D + 1) % _0023_003DzKTAIrow_003D.Length];
		for (int num = _0023_003DzTSeNR8Q_003D + _0023_003DzKTAIrow_003D.Length - 1; num >= _0023_003DzTSeNR8Q_003D; num--)
		{
			int num2 = num % _0023_003DzKTAIrow_003D.Length;
			trimCurve2 = (TrimCurve)_0023_003DzKTAIrow_003D[num2];
			if (!trimCurve2.Edge.IsPoint)
			{
				break;
			}
		}
		int num3;
		if (trimCurve2.EdgeIndex == -1)
		{
			Vertex item = new Vertex(trimCurve.Edge.StartPoint.X, trimCurve.Edge.StartPoint.Y, trimCurve.Edge.StartPoint.Z);
			num3 = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count;
			_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962479), num3));
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(item);
		}
		else
		{
			Edge edge = _0023_003DzViGQVPM_003D[trimCurve2.EdgeIndex];
			num3 = _0023_003Dz8FecXDmZlIO7(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, edge.StartPointIndex, edge.EndPointIndex, trimCurve.Edge);
		}
		for (int i = _0023_003DzTSeNR8Q_003D + 1; i <= _0023_003DzTSeNR8Q_003D + _0023_003DzKTAIrow_003D.Length; i++)
		{
			int num4 = i % _0023_003DzKTAIrow_003D.Length;
			trimCurve3 = (TrimCurve)_0023_003DzKTAIrow_003D[num4];
			if (!trimCurve3.Edge.IsPoint)
			{
				break;
			}
		}
		int num5;
		if (trimCurve3.EdgeIndex == -1)
		{
			Vertex item2 = new Vertex(trimCurve.Edge.EndPoint.X, trimCurve.Edge.EndPoint.Y, trimCurve.Edge.EndPoint.Z);
			num5 = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count;
			_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962675), num5));
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(item2);
		}
		else
		{
			Edge edge2 = _0023_003DzViGQVPM_003D[trimCurve3.EdgeIndex];
			num5 = _0023_003Dz8FecXDmZlIO7(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, edge2.StartPointIndex, edge2.EndPointIndex, trimCurve.Edge);
		}
		return _0023_003DzbIDY9BOTPqfc(new Edge(trimCurve.Edge, num3, num5), _0023_003DzViGQVPM_003D, _0023_003Dz85DwsjHHsAwG, _0023_003DzqmF8XJ0_003D, null);
	}

	private static int _0023_003Dz8FecXDmZlIO7(List<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003DzAqOpw0w_003D, int _0023_003Dzk64JNOo_003D, ICurve _0023_003DzTx2aqr8_003D)
	{
		Point3D point3D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzAqOpw0w_003D];
		Point3D point3D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dzk64JNOo_003D];
		double num = Math.Min(point3D.DistanceTo(_0023_003DzTx2aqr8_003D.StartPoint), point3D.DistanceTo(_0023_003DzTx2aqr8_003D.EndPoint));
		double num2 = Math.Min(point3D2.DistanceTo(_0023_003DzTx2aqr8_003D.StartPoint), point3D2.DistanceTo(_0023_003DzTx2aqr8_003D.EndPoint));
		if (!(num < num2))
		{
			return _0023_003Dzk64JNOo_003D;
		}
		return _0023_003DzAqOpw0w_003D;
	}

	private static void _0023_003DzAzVFPYFo2TLf(Face[] _0023_003DzpPOEJqcAh7Lr, Point3D _0023_003Dzl3DhHgI_003D, ref Point3D _0023_003Dzv_00241u4AU_003D, ref double _0023_003DzsVw1i9LkTBtX, ref double _0023_003DzMeLY8V4_003D)
	{
		for (int i = 0; i < _0023_003DzpPOEJqcAh7Lr.Length; i++)
		{
			Surface[] parametric = _0023_003DzpPOEJqcAh7Lr[i].Parametric;
			foreach (Surface surface in parametric)
			{
				surface.ControlBoundingBox(_0023_003DzsVw1i9LkTBtX * 1.001, out var min, out var max);
				if (Utility.IsPointInside(_0023_003Dzl3DhHgI_003D, min, max))
				{
					surface.ClosestPointTo(_0023_003Dzl3DhHgI_003D, out var u, out var v);
					surface._0023_003DzfSoiFiPSG81U(u, v, out var _0023_003DzlY77YgY_003D, out var _, out var _, out var _0023_003DzZbOaTIM_003D);
					double num = _0023_003DzlY77YgY_003D.DistanceTo(_0023_003Dzl3DhHgI_003D);
					if (num < _0023_003DzsVw1i9LkTBtX)
					{
						_0023_003Dzv_00241u4AU_003D = _0023_003DzlY77YgY_003D;
						_0023_003DzsVw1i9LkTBtX = num;
						double value = new Plane(_0023_003DzlY77YgY_003D, _0023_003DzZbOaTIM_003D).DistanceTo(_0023_003Dzl3DhHgI_003D);
						_0023_003DzMeLY8V4_003D = ((Math.Abs(value) > 0.0) ? ((double)Math.Sign(value)) : 1.0);
					}
				}
			}
		}
	}

	public void FlipFace(int outerFaceIndex)
	{
		_faces[outerFaceIndex].Flip();
		RegenMode = regenType.RegenAndCompile;
	}

	public Brep ConvertToBrep(bool mergeFaces = true, bool mergeEdges = true)
	{
		return this;
	}

	public void GetTightBBox(out Point3D boxMin, out Point3D boxMax)
	{
		Utility.ComputeBoundingBox(_vertices, out var boxMin2, out var boxMax2);
		boxMin = new Point3D(boxMin2.X, boxMin2.Y, boxMin2.Z);
		boxMax = new Point3D(boxMax2.X, boxMax2.Y, boxMax2.Z);
		Edge[] edges = _edges;
		for (int i = 0; i < edges.Length; i++)
		{
			Curve nurbsForm = edges[i].Curve.GetNurbsForm();
			nurbsForm.ControlBoundingBox(out boxMin2, out boxMax2);
			if (boxMin2.X < boxMin.X || boxMax2.X > boxMax.X || boxMin2.Y < boxMin.Y || boxMax2.Y > boxMax.Y || boxMin2.Z < boxMin.Z || boxMax2.Z > boxMax.Z)
			{
				nurbsForm.GetTightBBox(out var boxMin3, out var boxMax3);
				_0023_003DzEjKX2OhBx6Yl(ref boxMin, ref boxMax, boxMin3, boxMax3);
			}
		}
		Face[] faces = _faces;
		foreach (Face face in faces)
		{
			if ((!(face.Surface is SphericalSurf _0023_003Dz7TFjJCU_003D) || !_0023_003DzdS5ZPB6PO3Ur1Q7k2g_003D_003D(_0023_003Dz7TFjJCU_003D, boxMin, boxMax)) && (!(face.Surface is ToroidalSurf _0023_003Dzjm85u4E_003D) || !_0023_003DzGGFTEwktUy3P(_0023_003Dzjm85u4E_003D, boxMin, boxMax)) && (!(face.Surface is RevolvedSurf revolvedSurf) || Utility.IsLine(revolvedSurf.Generatrix)) && !(face.Surface is NurbsSurf { DegreeU: >1, DegreeV: >1 }))
			{
				continue;
			}
			ICurve[] orientedTrimLoops = face.GetOrientedTrimLoops(_edges);
			Surface notRotated;
			Surface untrimmed = face.Surface.GetUntrimmed(orientedTrimLoops, face.Sense, out notRotated);
			untrimmed.ControlBoundingBox(out boxMin2, out boxMax2);
			if (!(boxMin2.X < boxMin.X) && !(boxMax2.X > boxMax.X) && !(boxMin2.Y < boxMin.Y) && !(boxMax2.Y > boxMax.Y) && !(boxMin2.Z < boxMin.Z) && !(boxMax2.Z > boxMax.Z))
			{
				continue;
			}
			List<Point3D> list = new List<Point3D>();
			ICurve[] array = orientedTrimLoops;
			for (int j = 0; j < array.Length; j++)
			{
				ICurve[] individualCurves = array[j].GetIndividualCurves();
				foreach (ICurve curve in individualCurves)
				{
					list.Add(curve.StartPoint);
				}
			}
			Utility.ComputeBoundingBox(list, out var boxMin4, out var boxMax4);
			double num = new Size3D(boxMin4, boxMax4).Diagonal / 1000.0;
			array = orientedTrimLoops;
			for (int j = 0; j < array.Length; j++)
			{
				ICurve[] individualCurves = array[j].GetIndividualCurves();
				for (int k = 0; k < individualCurves.Length; k++)
				{
					Entity entity = (Entity)individualCurves[k];
					if (entity.Vertices == null)
					{
						entity.Regen(new RegenParams(num, 0.5));
					}
				}
			}
			Surface[] array2 = Surface._0023_003DzNxaR6FzQJCTX(untrimmed, orientedTrimLoops, num, 0.5, null, null);
			if (array2 != null && array2.Length != 0 && _0023_003Dz909r3pkb63XgiBkYZQ_003D_003D(array2, untrimmed, notRotated, orientedTrimLoops))
			{
				array2 = Surface._0023_003DzNxaR6FzQJCTX(notRotated, orientedTrimLoops, num, 0.5, null, null);
			}
			Surface[] array3 = array2;
			foreach (Surface surface in array3)
			{
				surface.ControlBoundingBox(out boxMin2, out boxMax2);
				if (!(boxMin2.X < boxMin.X) && !(boxMax2.X > boxMax.X) && !(boxMin2.Y < boxMin.Y) && !(boxMax2.Y > boxMax.Y) && !(boxMin2.Z < boxMin.Z) && !(boxMax2.Z > boxMax.Z))
				{
					continue;
				}
				array = surface.Trimming.ContourList[0].GetIndividualCurves();
				for (int k = 0; k < array.Length; k++)
				{
					((TrimCurve)array[k]).Edge.GetTightBBox(out var boxMin5, out var boxMax5);
					_0023_003DzEjKX2OhBx6Yl(ref boxMin, ref boxMax, boxMin5, boxMax5);
				}
				surface.ControlBoundingBox(out boxMin2, out boxMax2);
				if (!(boxMin2.X < boxMin.X) && !(boxMax2.X > boxMax.X) && !(boxMin2.Y < boxMin.Y) && !(boxMax2.Y > boxMax.Y) && !(boxMin2.Z < boxMin.Z) && !(boxMax2.Z > boxMax.Z))
				{
					continue;
				}
				Surface[,] array4 = surface._0023_003DzP70yTR4sE75F2ZLH0Q_003D_003D();
				foreach (Surface surface2 in array4)
				{
					surface2.ControlBoundingBox(out boxMin2, out boxMax2);
					if (boxMin2.X < boxMin.X || boxMax2.X > boxMax.X || boxMin2.Y < boxMin.Y || boxMax2.Y > boxMax.Y || boxMin2.Z < boxMin.Z || boxMax2.Z > boxMax.Z)
					{
						surface2._0023_003DzRCMLly5jFMJi();
						BoundingCone nCone = surface2.nCone;
						bool[] array5 = new bool[3] { true, true, true };
						if (surface2.nCone != null)
						{
							array5[0] = nCone.Contains(Vector3D.AxisX) || nCone.Contains(Vector3D.AxisMinusX);
							array5[1] = nCone.Contains(Vector3D.AxisY) || nCone.Contains(Vector3D.AxisMinusY);
							array5[2] = nCone.Contains(Vector3D.AxisZ) || nCone.Contains(Vector3D.AxisMinusZ);
						}
						if (array5[0] || array5[1] || array5[2])
						{
							surface2._0023_003Dz5a5G5K_0024q9obEBs1aC9Jiem0_003D(surface.Trimming, array5, ref boxMin, ref boxMax);
						}
					}
				}
			}
		}
	}

	private bool _0023_003DzdS5ZPB6PO3Ur1Q7k2g_003D_003D(SphericalSurf _0023_003Dz7TFjJCU_003D, Point3D _0023_003DzDPcjoBJLcqli, Point3D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		if (!(_0023_003Dz7TFjJCU_003D.Plane.Origin.X - _0023_003Dz7TFjJCU_003D.Radius < _0023_003DzDPcjoBJLcqli.X) && !(_0023_003Dz7TFjJCU_003D.Plane.Origin.X + _0023_003Dz7TFjJCU_003D.Radius > _0023_003Dz_0024N_0024yKptW9BoC.X) && !(_0023_003Dz7TFjJCU_003D.Plane.Origin.Y - _0023_003Dz7TFjJCU_003D.Radius < _0023_003DzDPcjoBJLcqli.Y) && !(_0023_003Dz7TFjJCU_003D.Plane.Origin.Y + _0023_003Dz7TFjJCU_003D.Radius > _0023_003Dz_0024N_0024yKptW9BoC.Y) && !(_0023_003Dz7TFjJCU_003D.Plane.Origin.Z - _0023_003Dz7TFjJCU_003D.Radius < _0023_003DzDPcjoBJLcqli.Z))
		{
			return _0023_003Dz7TFjJCU_003D.Plane.Origin.Z + _0023_003Dz7TFjJCU_003D.Radius > _0023_003Dz_0024N_0024yKptW9BoC.Z;
		}
		return true;
	}

	private bool _0023_003DzGGFTEwktUy3P(ToroidalSurf _0023_003Dzjm85u4E_003D, Point3D _0023_003DzDPcjoBJLcqli, Point3D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		Point3D point3D = new Point3D(0.0, 0.0, 0.0);
		Point3D point3D2 = new Point3D(0.0, 0.0, 0.0);
		double[,] matrix = new Align3D(_0023_003Dzjm85u4E_003D.Plane, Plane.XY).Matrix;
		double majorRadius = _0023_003Dzjm85u4E_003D.MajorRadius;
		double minorRadius = _0023_003Dzjm85u4E_003D.MinorRadius;
		for (int i = 0; i < 3; i++)
		{
			double num = matrix[0, i];
			double num2 = matrix[1, i];
			double num3 = matrix[2, i];
			double num4 = Math.Atan2(num2, num);
			double num5 = ((num != 0.0) ? Math.Atan2(num3, (num + num2 * num2 / num) * Math.Cos(num4)) : ((num2 == 0.0) ? (Math.PI / 2.0) : Math.Atan2(num3, (num2 + num * num / num2) * Math.Sin(num4))));
			switch (i)
			{
			case 0:
				point3D.X = (majorRadius + minorRadius * Math.Cos(num5)) * (num * Math.Cos(num4) + num2 * Math.Sin(num4)) + num3 * minorRadius * Math.Sin(num5);
				point3D2.X = (majorRadius + minorRadius * Math.Cos(num5)) * (num * Math.Cos(num4 + Math.PI) + num2 * Math.Sin(num4 + Math.PI)) + num3 * minorRadius * Math.Sin(num5 + Math.PI);
				break;
			case 1:
				point3D.Y = (majorRadius + minorRadius * Math.Cos(num5)) * (num * Math.Cos(num4) + num2 * Math.Sin(num4)) + num3 * minorRadius * Math.Sin(num5);
				point3D2.Y = (majorRadius + minorRadius * Math.Cos(num5)) * (num * Math.Cos(num4 + Math.PI) + num2 * Math.Sin(num4 + Math.PI)) + num3 * minorRadius * Math.Sin(num5 + Math.PI);
				break;
			case 2:
				point3D.Z = (majorRadius + minorRadius * Math.Cos(num5)) * (num * Math.Cos(num4) + num2 * Math.Sin(num4)) + num3 * minorRadius * Math.Sin(num5);
				point3D2.Z = (majorRadius + minorRadius * Math.Cos(num5)) * (num * Math.Cos(num4 + Math.PI) + num2 * Math.Sin(num4 + Math.PI)) + num3 * minorRadius * Math.Sin(num5 + Math.PI);
				break;
			}
		}
		point3D += _0023_003Dzjm85u4E_003D.Plane.Origin;
		point3D2 += _0023_003Dzjm85u4E_003D.Plane.Origin;
		if (!(Math.Min(point3D.X, point3D2.X) < _0023_003DzDPcjoBJLcqli.X) && !(Math.Max(point3D.X, point3D2.X) > _0023_003Dz_0024N_0024yKptW9BoC.X) && !(Math.Min(point3D.Y, point3D2.Y) < _0023_003DzDPcjoBJLcqli.Y) && !(Math.Max(point3D.Y, point3D2.Y) > _0023_003Dz_0024N_0024yKptW9BoC.Y) && !(Math.Min(point3D.Z, point3D2.Z) < _0023_003DzDPcjoBJLcqli.Z))
		{
			return Math.Max(point3D.Z, point3D2.Z) > _0023_003Dz_0024N_0024yKptW9BoC.Z;
		}
		return true;
	}

	private void _0023_003DzEjKX2OhBx6Yl(ref Point3D _0023_003DzDPcjoBJLcqli, ref Point3D _0023_003Dz_0024N_0024yKptW9BoC, Point3D _0023_003DzvBXpiGOqIK5u, Point3D _0023_003DzDlQbSy9BfBUm)
	{
		if (_0023_003DzvBXpiGOqIK5u.X < _0023_003DzDPcjoBJLcqli.X)
		{
			_0023_003DzDPcjoBJLcqli.X = _0023_003DzvBXpiGOqIK5u.X;
		}
		if (_0023_003DzDlQbSy9BfBUm.X > _0023_003Dz_0024N_0024yKptW9BoC.X)
		{
			_0023_003Dz_0024N_0024yKptW9BoC.X = _0023_003DzDlQbSy9BfBUm.X;
		}
		if (_0023_003DzvBXpiGOqIK5u.Y < _0023_003DzDPcjoBJLcqli.Y)
		{
			_0023_003DzDPcjoBJLcqli.Y = _0023_003DzvBXpiGOqIK5u.Y;
		}
		if (_0023_003DzDlQbSy9BfBUm.Y > _0023_003Dz_0024N_0024yKptW9BoC.Y)
		{
			_0023_003Dz_0024N_0024yKptW9BoC.Y = _0023_003DzDlQbSy9BfBUm.Y;
		}
		if (_0023_003DzvBXpiGOqIK5u.Z < _0023_003DzDPcjoBJLcqli.Z)
		{
			_0023_003DzDPcjoBJLcqli.Z = _0023_003DzvBXpiGOqIK5u.Z;
		}
		if (_0023_003DzDlQbSy9BfBUm.Z > _0023_003Dz_0024N_0024yKptW9BoC.Z)
		{
			_0023_003Dz_0024N_0024yKptW9BoC.Z = _0023_003DzDlQbSy9BfBUm.Z;
		}
	}

	public void FixFaces(StringBuilder log)
	{
		_0023_003Dz1ROb0UvNXYnsFZWPrA_003D_003D(_faces, log);
		Face[][] inners = _inners;
		foreach (Face[] _0023_003DzEtn4dIEPKCsi in inners)
		{
			_0023_003Dz1ROb0UvNXYnsFZWPrA_003D_003D(_0023_003DzEtn4dIEPKCsi, log);
		}
	}

	private void _0023_003Dz1ROb0UvNXYnsFZWPrA_003D_003D(Face[] _0023_003DzEtn4dIEPKCsi, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		int num = _0023_003DzEtn4dIEPKCsi.Length;
		for (int i = 0; i < num; i++)
		{
			Face face = _0023_003DzEtn4dIEPKCsi[i];
			if (face.Surface.GetType() == typeof(PlanarSurf))
			{
				PlanarSurf planarSurf = (PlanarSurf)face.Surface;
				ICurve[][] array = new ICurve[face.Loops.Length][];
				if (face.Loops.Length > 1)
				{
					for (int j = 0; j < face.Loops.Length; j++)
					{
						ICurve[] array2 = new ICurve[face.Loops[j].Segments.Length];
						for (int k = 0; k < face.Loops[j].Segments.Length; k++)
						{
							Curve nurbsForm = face.Loops[j].Segments[k].GetOrientedCurve(_edges).GetNurbsForm();
							array2[k] = nurbsForm.Drop(planarSurf.Plane);
						}
						if (!face.Loops[j].Sense)
						{
							Array.Reverse(array2);
							ICurve[] array3 = array2;
							for (int l = 0; l < array3.Length; l++)
							{
								Utility._0023_003Dz_0024fvibmW5yS_0024m(array3[l], _0023_003Dz59LU6fL0vl_s4Lskpw_003D_003D: false);
							}
						}
						array[j] = array2;
					}
					int outerIndex = Utility.GetOuterIndex(array);
					if (outerIndex != -1 && outerIndex != 0)
					{
						Utility.Swap(ref face.Loops[outerIndex], ref face.Loops[0]);
						_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962645), i));
					}
				}
				ICurve[] orientedTrimLoops = face.GetOrientedTrimLoops(_edges);
				if (orientedTrimLoops.Length == 0)
				{
					continue;
				}
				bool flag = Utility._0023_003DzinOQp4_qBUm4opZWpg_003D_003D(orientedTrimLoops[0], ((PlanarSurf)face.Surface).Plane);
				if ((flag && face.Sense) || (!flag && !face.Sense))
				{
					face.Sense = !face.Sense;
					face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(null);
					_0023_003DzqmF8XJ0_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962597) + i);
				}
				for (int m = 1; m < orientedTrimLoops.Length; m++)
				{
					bool flag2 = Utility._0023_003DzinOQp4_qBUm4opZWpg_003D_003D(orientedTrimLoops[m], ((PlanarSurf)face.Surface).Plane);
					if ((!flag2 && face.Sense) || (flag2 && !face.Sense))
					{
						face.Loops[m].Sense = !face.Loops[m].Sense;
						_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962571), m, i));
					}
				}
			}
			else
			{
				if (face.Surface is ToroidalSurf || face.Surface is SphericalSurf || _0023_003Dz7K_0024M5qfm2OtL(face))
				{
					continue;
				}
				ICurve[] orientedTrimLoops2 = face.GetOrientedTrimLoops(_edges);
				if (orientedTrimLoops2.Length != 1)
				{
					continue;
				}
				ICurve[] individualCurves = orientedTrimLoops2[0].GetIndividualCurves();
				bool flag3 = false;
				ICurve[] array3 = individualCurves;
				int n;
				foreach (ICurve _0023_003Dz8fpRyMu9aKjE in array3)
				{
					if (face.Surface._0023_003DziYlx1Dzq9Zgl(_0023_003Dz8fpRyMu9aKjE, out n))
					{
						flag3 = true;
						break;
					}
				}
				if (!flag3)
				{
					array3 = individualCurves;
					for (int l = 0; l < array3.Length; l++)
					{
						_0023_003Dz8xgbeGLa6j1KDhTFtVgo_v8_003D _0023_003Dz8xgbeGLa6j1KDhTFtVgo_v8_003D2 = new _0023_003Dz8xgbeGLa6j1KDhTFtVgo_v8_003D();
						_0023_003Dz8xgbeGLa6j1KDhTFtVgo_v8_003D2._0023_003DzSwfghCo_003D = array3[l];
						if (face.Surface._0023_003Dzp2cxcSDr1evr(_0023_003Dz8xgbeGLa6j1KDhTFtVgo_v8_003D2._0023_003DzSwfghCo_003D, out n) && individualCurves.Count(_0023_003Dz8xgbeGLa6j1KDhTFtVgo_v8_003D2._0023_003DzIMtdgvirAeKkia0XRLb5iNM_003D) == 2)
						{
							PlanarSurf planarSurf2 = (PlanarSurf)face.Surface;
							Point2D point2D = planarSurf2.Plane.Project(_0023_003Dz8xgbeGLa6j1KDhTFtVgo_v8_003D2._0023_003DzSwfghCo_003D.PointAt(_0023_003Dz8xgbeGLa6j1KDhTFtVgo_v8_003D2._0023_003DzSwfghCo_003D.Domain.ParameterAt(0.5)));
							face.Surface.TransformBy(Transformation.CreateRotation(point2D.AsVector.Angle, planarSurf2.Plane.AxisZ, planarSurf2.Plane.Origin));
							face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(null);
							break;
						}
					}
				}
				ICurve curve = individualCurves.Last();
				double num2 = 0.0;
				bool flag4 = true;
				Surface _0023_003DzSphmeCeMcE_ = null;
				if (face.Surface is NurbsSurf nurbsSurf)
				{
					_0023_003DzSphmeCeMcE_ = new Surface(nurbsSurf.DegreeU, nurbsSurf.KnotVectorU, nurbsSurf.DegreeV, nurbsSurf.KnotVectorV, nurbsSurf.ControlPoints);
				}
				array3 = individualCurves;
				foreach (ICurve curve2 in array3)
				{
					if (face.Surface.HasSeam && face.Surface is PlanarSurf planarSurf3 && _0023_003DzHZpNnW8MlX_0024f26z7Ng_003D_003D(planarSurf3.Plane, curve.EndPoint) && !face.Surface._0023_003DziYlx1Dzq9Zgl(curve2, out n) && !face.Surface._0023_003DziYlx1Dzq9Zgl(curve, out n))
					{
						flag4 = !flag4;
					}
					if (curve2 is Line _0023_003Dziidc4_0024c_003D)
					{
						if (!_0023_003DzT2LkqYg7RoQQL5YuUY6eXuQ_003D(_0023_003Dziidc4_0024c_003D, curve, face.Surface, face.Sense, out var _0023_003Dz6pajdGM_003D, _0023_003DzSphmeCeMcE_))
						{
							flag4 = false;
							break;
						}
						num2 += _0023_003Dz6pajdGM_003D;
						curve = curve2;
						continue;
					}
					ICurve[] array4 = curve2.GetNurbsForm().SplitAtDiscontinuities(speedChange: true);
					array4 = array4;
					for (n = 0; n < array4.Length; n++)
					{
						Curve nurbsForm2 = array4[n].GetNurbsForm();
						if (!_0023_003DzT2LkqYg7RoQQL5YuUY6eXuQ_003D(nurbsForm2, curve, face.Surface, face.Sense, out var _0023_003Dz6pajdGM_003D2, _0023_003DzSphmeCeMcE_))
						{
							flag4 = false;
							break;
						}
						num2 += _0023_003Dz6pajdGM_003D2;
						if (!_0023_003DzT2LkqYg7RoQQL5YuUY6eXuQ_003D(nurbsForm2, face.Surface, face.Sense, out var _0023_003Dz6pajdGM_003D3, _0023_003DzSphmeCeMcE_))
						{
							flag4 = false;
							break;
						}
						num2 += _0023_003Dz6pajdGM_003D3;
						curve = nurbsForm2;
					}
				}
				_0023_003DzSphmeCeMcE_ = null;
				if (flag4 && num2 < -1E-12)
				{
					face.Sense = !face.Sense;
					face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(null);
					_0023_003DzqmF8XJ0_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962249) + i);
				}
			}
		}
	}

	private static bool _0023_003Dz7K_0024M5qfm2OtL(Face _0023_003DzHEpjcdg2hk9U)
	{
		if (_0023_003DzHEpjcdg2hk9U.Surface is RevolvedSurf { Generatrix: Circle generatrix } revolvedSurf)
		{
			new Plane(revolvedSurf.Plane.Origin, revolvedSurf.Plane.AxisX, revolvedSurf.Plane.AxisZ).Project(generatrix.Center, out var s, out var _);
			if (s < generatrix.Radius && Vector3D.AreCoincident(generatrix.Plane.AxisZ, revolvedSurf.Plane.AxisY))
			{
				return true;
			}
		}
		return false;
	}

	private void _0023_003DzcYE3B98AVdT9()
	{
		Edge[] edges = _edges;
		foreach (Edge edge in edges)
		{
			ICurve curve = edge.Curve;
			int startPointIndex = edge.StartPointIndex;
			int endPointIndex = edge.EndPointIndex;
			Point3D point3D = _vertices[startPointIndex];
			Point3D point3D2 = _vertices[endPointIndex];
			if (curve is Line line)
			{
				line.StartPoint = (Point3D)point3D.Clone();
				line.EndPoint = (Point3D)point3D2.Clone();
			}
			else if (curve.GetType() == typeof(Circle) || curve.GetType() == typeof(Ellipse))
			{
				edge.Curve = _0023_003DzrLYP2geTSc3BteakRS3hjGM_003D(edge.Curve, _vertices[edge.StartPointIndex]);
			}
			else if (curve is Arc arc)
			{
				if (startPointIndex == endPointIndex)
				{
					edge.Curve = _0023_003DzrLYP2geTSc3BteakRS3hjGM_003D(edge.Curve, _vertices[edge.StartPointIndex]);
					continue;
				}
				Arc arc2 = (Arc)arc.Clone();
				if (arc.Project(point3D, out var t))
				{
					arc.ExtendAt(t);
				}
				if (arc.Project(point3D2, out var t2))
				{
					arc.ExtendAt(t2);
				}
				if (arc.Angle.Length / arc2.Angle.Length > 1.1 || arc.Angle.Length / arc2.Angle.Length < 0.9)
				{
					edge.Curve = arc2;
				}
			}
			else if (curve is EllipticalArc ellipticalArc)
			{
				if (startPointIndex == endPointIndex)
				{
					edge.Curve = _0023_003DzrLYP2geTSc3BteakRS3hjGM_003D(edge.Curve, _vertices[edge.StartPointIndex]);
					continue;
				}
				EllipticalArc ellipticalArc2 = (EllipticalArc)ellipticalArc.Clone();
				if (ellipticalArc.Project(point3D, out var t3))
				{
					ellipticalArc.ExtendAt(t3);
				}
				if (ellipticalArc.Project(point3D2, out var t4))
				{
					ellipticalArc.ExtendAt(t4);
				}
				if (ellipticalArc.Angle.Length / ellipticalArc2.Angle.Length > 1.1 || ellipticalArc.Angle.Length / ellipticalArc2.Angle.Length < 0.9)
				{
					edge.Curve = ellipticalArc2;
				}
			}
			else if (curve is Curve curve2)
			{
				curve2._0023_003Dz2r9Ujfm8VxAN(Math.PI * 99.0 / 100.0);
				Translation xform = new Translation(new Vector3D(curve2.Pw[0].Euclid, point3D));
				if (curve2.ControlPoints.Length > 3)
				{
					curve2.ControlPoints[1].TransformBy(xform);
				}
				curve2.ControlPoints[0].TransformBy(xform);
				Translation xform2 = new Translation(new Vector3D(curve2.ControlPoints[curve2.Pw.Length - 1].Euclid, point3D2));
				if (curve2.ControlPoints.Length > 3)
				{
					curve2.ControlPoints[curve2.Pw.Length - 2].TransformBy(xform2);
				}
				curve2.ControlPoints[curve2.Pw.Length - 1].TransformBy(xform2);
				curve2.RegenMode = regenType.RegenAndCompile;
			}
		}
	}

	private static ICurve _0023_003DzrLYP2geTSc3BteakRS3hjGM_003D(ICurve _0023_003Dz8fpRyMu9aKjE, Point3D _0023_003Dz4uDIlkCSfBuuNtFCt0opqv0_003D)
	{
		if (Point3D.DistanceSquared(_0023_003Dz8fpRyMu9aKjE.StartPoint, _0023_003Dz4uDIlkCSfBuuNtFCt0opqv0_003D) > Utility._0023_003DzheSR8QM7q9ya)
		{
			_0023_003Dz8fpRyMu9aKjE.ClosestPointTo(_0023_003Dz4uDIlkCSfBuuNtFCt0opqv0_003D, out var t);
			if (Point3D.DistanceSquared(_0023_003Dz8fpRyMu9aKjE.PointAt(t), _0023_003Dz4uDIlkCSfBuuNtFCt0opqv0_003D) < Utility._0023_003DzheSR8QM7q9ya)
			{
				if (_0023_003Dz8fpRyMu9aKjE is Ellipse ellipse)
				{
					return new EllipticalArc(ellipse.Plane, ellipse.Center, ellipse.RadiusX, ellipse.RadiusY, t, t + Math.PI * 2.0, polarAngles: false);
				}
				if (_0023_003Dz8fpRyMu9aKjE is Circle circle)
				{
					return new Arc(circle.Plane, circle.Center, circle.Radius, t, t + Math.PI * 2.0);
				}
			}
		}
		return _0023_003Dz8fpRyMu9aKjE;
	}

	private static bool _0023_003DzHZpNnW8MlX_0024f26z7Ng_003D_003D(Plane _0023_003Dzpyw2kZk_003D, Point3D _0023_003DzMlCq3wk_003D)
	{
		Plane plane = new Plane(_0023_003Dzpyw2kZk_003D.Origin, _0023_003Dzpyw2kZk_003D.AxisX, _0023_003Dzpyw2kZk_003D.AxisZ);
		if (Math.Abs(plane.DistanceTo(_0023_003DzMlCq3wk_003D)) < Utility._0023_003Dzjyaz_Vfaky9X && plane.Project(_0023_003DzMlCq3wk_003D).X > 0.0)
		{
			return true;
		}
		return false;
	}

	private static bool _0023_003DzT2LkqYg7RoQQL5YuUY6eXuQ_003D(ICurve _0023_003Dziidc4_0024c_003D, AnalyticSurf _0023_003Dz_0024KKopL9T7nzT, bool _0023_003Dzx3pYiE0_003D, out double _0023_003Dz6pajdGM_003D, Surface _0023_003DzSphmeCeMcE_4)
	{
		Curve nurbsForm = _0023_003Dziidc4_0024c_003D.GetNurbsForm();
		Point3D[] array = _0023_003Dz_igNxtmQTqmxVQ2T1vlQCIcPfXD9PLlsgH9i_KbaWpLX._0023_003DzvKjleDzBEPeHTOWneerYzYE_003D(nurbsForm, 0.0, Math.PI / 2.0);
		_0023_003Dz6pajdGM_003D = 0.0;
		Vector3D vector3D = nurbsForm.StartTangent;
		_0023_003Dzx4bkUSY_003D(nurbsForm.StartPoint, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzSphmeCeMcE_4, out var _0023_003DzaUqU2Iw_003D, out var _0023_003Dz9E8k_0024SQ_003D);
		for (int i = 1; i < array.Length; i++)
		{
			double u = ((PointTangentU)array[i]).U;
			Vector3D vector3D2 = _0023_003Dziidc4_0024c_003D.TangentAt(u);
			Vector3D _0023_003DzaUqU2Iw_003D2;
			Vector3D _0023_003Dz9E8k_0024SQ_003D2;
			Vector3D vector3D3 = _0023_003Dzx4bkUSY_003D(array[i], _0023_003Dz_0024KKopL9T7nzT, _0023_003DzSphmeCeMcE_4, out _0023_003DzaUqU2Iw_003D2, out _0023_003Dz9E8k_0024SQ_003D2);
			if (vector3D3 == null)
			{
				return false;
			}
			if (!_0023_003Dzx3pYiE0_003D)
			{
				vector3D3.Negate();
			}
			if (!_0023_003DzaUqU2Iw_003D.IsZero && !_0023_003Dz9E8k_0024SQ_003D.IsZero && !_0023_003DzaUqU2Iw_003D2.IsZero && !_0023_003Dz9E8k_0024SQ_003D2.IsZero)
			{
				try
				{
					Transformation xform = Transformation.CreateAlignment(new Plane(Point3D.Origin, _0023_003DzaUqU2Iw_003D2, _0023_003Dz9E8k_0024SQ_003D2), new Plane(Point3D.Origin, _0023_003DzaUqU2Iw_003D, _0023_003Dz9E8k_0024SQ_003D));
					vector3D2.TransformBy(xform);
				}
				catch (Exception)
				{
					continue;
				}
			}
			double num = Vector3D.Cross(vector3D, vector3D2) * vector3D3;
			double num2 = vector3D * vector3D2;
			if (Math.Abs(num) < 1E-12 && Math.Abs(num2) < 1E-12)
			{
				return false;
			}
			_0023_003Dz6pajdGM_003D += Math.Atan2(num, num2);
			vector3D = vector3D2;
		}
		return true;
	}

	private static bool _0023_003DzT2LkqYg7RoQQL5YuUY6eXuQ_003D(ICurve _0023_003Dziidc4_0024c_003D, ICurve _0023_003DzDr1MUxo_003D, AnalyticSurf _0023_003Dz_0024KKopL9T7nzT, bool _0023_003Dzx3pYiE0_003D, out double _0023_003Dz6pajdGM_003D, Surface _0023_003DzSphmeCeMcE_4)
	{
		_0023_003Dz6pajdGM_003D = 0.0;
		Vector3D vector3D = _0023_003DzDr1MUxo_003D.EndTangent;
		Vector3D vector3D2 = _0023_003Dziidc4_0024c_003D.StartTangent;
		Vector3D _0023_003DzaUqU2Iw_003D;
		Vector3D _0023_003Dz9E8k_0024SQ_003D;
		Vector3D vector3D3 = _0023_003Dzx4bkUSY_003D(_0023_003Dziidc4_0024c_003D.StartPoint, _0023_003Dz_0024KKopL9T7nzT, _0023_003DzSphmeCeMcE_4, out _0023_003DzaUqU2Iw_003D, out _0023_003Dz9E8k_0024SQ_003D);
		if (vector3D3 == null)
		{
			return false;
		}
		if (!_0023_003Dzx3pYiE0_003D)
		{
			vector3D3.Negate();
		}
		double num = Vector3D.Cross(vector3D, vector3D2) * vector3D3;
		if (Math.Abs(num) < 0.01)
		{
			vector3D = _0023_003DzDr1MUxo_003D.TangentAt(_0023_003DzDr1MUxo_003D.Domain.Right - _0023_003DzDr1MUxo_003D.Domain.Length * 0.01);
			vector3D2 = _0023_003Dziidc4_0024c_003D.TangentAt(_0023_003Dziidc4_0024c_003D.Domain.Left + _0023_003Dziidc4_0024c_003D.Domain.Length * 0.01);
			num = Vector3D.Cross(vector3D, vector3D2) * vector3D3;
		}
		double num2 = vector3D * vector3D2;
		if (Math.Abs(num) < 1E-12 && Math.Abs(num2) < 1E-12)
		{
			return false;
		}
		_0023_003Dz6pajdGM_003D = Math.Atan2(num, num2);
		return true;
	}

	private static Vector3D _0023_003Dzx4bkUSY_003D(Point3D _0023_003DzMlCq3wk_003D, AnalyticSurf _0023_003Dz_0024KKopL9T7nzT, Surface _0023_003DzSphmeCeMcE_4, out Vector3D _0023_003DzaUqU2Iw_003D, out Vector3D _0023_003Dz9E8k_0024SQ_003D)
	{
		if (_0023_003DzSphmeCeMcE_4 == null)
		{
			return _0023_003Dz_0024KKopL9T7nzT.Normal(_0023_003DzMlCq3wk_003D, out _0023_003DzaUqU2Iw_003D, out _0023_003Dz9E8k_0024SQ_003D);
		}
		return ((NurbsSurf)_0023_003Dz_0024KKopL9T7nzT)._0023_003Dz9T2qChw_003D(_0023_003DzMlCq3wk_003D, _0023_003DzSphmeCeMcE_4, out _0023_003DzaUqU2Iw_003D, out _0023_003Dz9E8k_0024SQ_003D);
	}

	private void _0023_003DzwIO5_fKTGLjaAtxRaMO9kU4_003D(Brep _0023_003Dz_Gzfs9c_003D)
	{
		for (int i = 0; i < Faces.Length; i++)
		{
			if (Faces[i].Parametric != null)
			{
				_0023_003Dz_Gzfs9c_003D.Faces[i]._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D((Surface[])Faces[i].Parametric.Clone());
			}
		}
		for (int j = 0; j < Inners.Length; j++)
		{
			for (int num = 0; num < Inners[j].Length; j++)
			{
				if (Inners[j][num].Parametric != null)
				{
					_0023_003Dz_Gzfs9c_003D.Inners[j][num]._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D((Surface[])Inners[j][num].Parametric.Clone());
				}
			}
		}
	}

	public booleanFailureType SplitBy(Plane pln, out Brep[] left, out Brep[] right)
	{
		left = null;
		right = null;
		Brep brep = (Brep)Clone();
		_0023_003DzwIO5_fKTGLjaAtxRaMO9kU4_003D(brep);
		Brep[] leftOvers;
		booleanFailureType booleanFailureType2 = brep.CutBy(pln, out leftOvers);
		if (booleanFailureType2 == booleanFailureType.Success)
		{
			List<Brep> list = new List<Brep> { brep };
			list.AddRange(leftOvers);
			left = list.ToArray();
			Brep brep2 = (Brep)Clone();
			_0023_003DzwIO5_fKTGLjaAtxRaMO9kU4_003D(brep2);
			booleanFailureType2 = brep2.CutBy(pln, out leftOvers, flip: true);
			if (booleanFailureType2 == booleanFailureType.Success)
			{
				List<Brep> list2 = new List<Brep> { brep2 };
				list2.AddRange(leftOvers);
				right = list2.ToArray();
			}
		}
		return booleanFailureType2;
	}

	public booleanFailureType SplitBy(Surface G, out Brep[] left, out Brep[] right)
	{
		left = null;
		right = null;
		Brep brep = (Brep)Clone();
		_0023_003DzwIO5_fKTGLjaAtxRaMO9kU4_003D(brep);
		Brep[] leftOvers;
		booleanFailureType booleanFailureType2 = brep.CutBy(G, out leftOvers);
		if (booleanFailureType2 == booleanFailureType.Success)
		{
			List<Brep> list = new List<Brep> { brep };
			list.AddRange(leftOvers);
			left = list.ToArray();
			Brep[] array = left;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].CopyAttributes(this);
			}
			Brep brep2 = (Brep)Clone();
			_0023_003DzwIO5_fKTGLjaAtxRaMO9kU4_003D(brep2);
			booleanFailureType2 = brep2.CutBy(G, out leftOvers, flip: true);
			if (booleanFailureType2 == booleanFailureType.Success)
			{
				List<Brep> list2 = new List<Brep> { brep2 };
				list2.AddRange(leftOvers);
				right = list2.ToArray();
				array = right;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].CopyAttributes(this);
				}
			}
		}
		return booleanFailureType2;
	}

	public booleanFailureType CutBy(Plane pln, bool flip = false, Color? capColor = null)
	{
		Brep[] leftOvers;
		return CutBy(pln, out leftOvers, flip, capColor);
	}

	public booleanFailureType CutBy(Plane pln, out Brep[] leftOvers, bool flip = false, Color? capColor = null)
	{
		Plane plane = (Plane)pln.Clone();
		if (flip)
		{
			plane.Flip();
		}
		booleanFailureType booleanFailureType2 = _0023_003DzBVSD8WPcX9kp(plane, null, out leftOvers, IsClosed, capColor);
		_0023_003Dz8VkxvzXXGxA_0024(Vertices, Edges, Faces, Inners, _0023_003DzLuJVbec_003D: false);
		if (booleanFailureType2 == booleanFailureType.Success)
		{
			Brep[] array = leftOvers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].CopyAttributes(this);
			}
			RegenMode = regenType.RegenAndCompile;
		}
		return booleanFailureType2;
	}

	public booleanFailureType CutBy(Surface surface, bool flip = false)
	{
		Brep[] leftOvers;
		return CutBy(surface, out leftOvers, flip);
	}

	public booleanFailureType CutBy(Surface surface, out Brep[] leftOvers, bool flip = false)
	{
		Surface surface2 = (Surface)surface.Clone();
		if (flip)
		{
			surface2.ReverseU();
		}
		Color? _0023_003Dz82mM5EWr42v = null;
		if (surface.ColorMethod == colorMethodType.byEntity)
		{
			_0023_003Dz82mM5EWr42v = surface.Color;
		}
		booleanFailureType num = _0023_003DzBVSD8WPcX9kp(null, surface2, out leftOvers, _0023_003DzcSSP_dM_003D: true, _0023_003Dz82mM5EWr42v);
		_0023_003Dz8VkxvzXXGxA_0024(Vertices, Edges, Faces, Inners, _0023_003DzLuJVbec_003D: false);
		if (num == booleanFailureType.Success)
		{
			RegenMode = regenType.RegenAndCompile;
		}
		return num;
	}

	private booleanFailureType _0023_003DzBVSD8WPcX9kp(Plane _0023_003Dzrgqz890sj_0024X9, Surface _0023_003DzF7GfYSI_003D, out Brep[] _0023_003DzACJ8of7_00247mab, bool _0023_003DzcSSP_dM_003D, Color? _0023_003Dz82mM5EWr42v6)
	{
		List<Brep> list = new List<Brep>();
		Point3D _0023_003DzDPcjoBJLcqli = null;
		Point3D _0023_003Dz_0024N_0024yKptW9BoC = null;
		if (localMin == null || regenMode == regenType.RegenAndCompile)
		{
			Rebuild(0.0, soft: true);
			_0023_003DzQCWJbpjMGLxZWfwMCQ_003D_003D(out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC, _0023_003Dz7cP1pZCb1hQy: true);
			localMin = _0023_003DzDPcjoBJLcqli;
			localMax = _0023_003Dz_0024N_0024yKptW9BoC;
		}
		else
		{
			_0023_003DzDPcjoBJLcqli = localMin;
			_0023_003Dz_0024N_0024yKptW9BoC = localMax;
		}
		Surface _0023_003Dz4wZe_0024Xg_003D = ((_0023_003DzF7GfYSI_003D != null) ? _0023_003DzF7GfYSI_003D : Surface._0023_003DziDGe5xzc5KLyQpPYDk5PyHY_003D(_0023_003Dzrgqz890sj_0024X9, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC));
		double rebuildTolerance = RebuildTolerance;
		Surface._0023_003Dz2u_3iw7LP_ic _0023_003Dz2u_3iw7LP_ic = new Surface._0023_003Dz2u_3iw7LP_ic
		{
			_0023_003Dz4wZe_0024Xg_003D = _0023_003Dz4wZe_0024Xg_003D
		};
		Surface.Reparametrize(_0023_003Dz2u_3iw7LP_ic._0023_003Dz4wZe_0024Xg_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dz2AZ_kpw_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dza2Pq9PQ_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
		_0023_003Dz4wZe_0024Xg_003D = _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
		_0023_003Dza3t_hvZMRgAKlujUZQ_003D_003D(_0023_003Dz4wZe_0024Xg_003D);
		ICurve[] _0023_003DzvAopSzLGqCc;
		ICurve[] _0023_003DzxO_0024dwgyFkvCa;
		ICurve[] array = _0023_003DzKK3pUYhqE_002427(_0023_003DzF7GfYSI_003D, _0023_003Dzrgqz890sj_0024X9, _0023_003DzOVP5EDBXMxbE: false, out _0023_003DzvAopSzLGqCc, out _0023_003DzxO_0024dwgyFkvCa);
		_0023_003DzACJ8of7_00247mab = new Brep[0];
		if (_0023_003DzvAopSzLGqCc == null || _0023_003DzvAopSzLGqCc.Length == 0)
		{
			return booleanFailureType.NotIntersecting;
		}
		List<Edge> list2 = Edges.ToList();
		List<Point3D> list3 = new List<Point3D>();
		List<Edge> list4 = new List<Edge>();
		List<Face> list5 = new List<Face>();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		Dictionary<int, int> _0023_003DzV8Lcc5p5_0024hWB = new Dictionary<int, int>();
		Dictionary<int, Dictionary<double, int>> dictionary2 = new Dictionary<int, Dictionary<double, int>>();
		Dictionary<int, List<int>> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D = new Dictionary<int, List<int>>();
		Dictionary<int, List<ICurve>> dictionary3 = new Dictionary<int, List<ICurve>>();
		List<TrimCurve> list6 = new List<TrimCurve>(_0023_003DzxO_0024dwgyFkvCa.Length);
		for (int i = 0; i < _0023_003DzvAopSzLGqCc.Length; i++)
		{
			bool flag = true;
			bool flag2 = true;
			TrimCurve trimCurve = (TrimCurve)_0023_003DzxO_0024dwgyFkvCa[i];
			TrimCurve trimCurve2 = (TrimCurve)_0023_003DzvAopSzLGqCc[i];
			Surface _0023_003Dz4wZe_0024Xg_003D2 = Faces[trimCurve2.FaceInfo._0023_003DzLJVtPYc_003D].Parametric[trimCurve2.FaceInfo._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D];
			Surface._0023_003Dz2u_3iw7LP_ic _0023_003Dz2u_3iw7LP_ic2 = new Surface._0023_003Dz2u_3iw7LP_ic
			{
				_0023_003Dz4wZe_0024Xg_003D = _0023_003Dz4wZe_0024Xg_003D2
			};
			Surface.Reparametrize(_0023_003Dz2u_3iw7LP_ic2._0023_003Dz4wZe_0024Xg_003D, out _0023_003Dz2u_3iw7LP_ic2._0023_003Dz2AZ_kpw_003D, out _0023_003Dz2u_3iw7LP_ic2._0023_003Dza2Pq9PQ_003D, out _0023_003Dz2u_3iw7LP_ic2._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
			_0023_003Dz4wZe_0024Xg_003D2 = _0023_003Dz2u_3iw7LP_ic2._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
			bool _0023_003DzKgWCaV5RTv9VxFld_g_003D_003D;
			int _0023_003Dz93D7WaCPl_0024u;
			bool flag3 = _0023_003Dz4wZe_0024Xg_003D2._0023_003DzZf4zvJoP0u8G(_0023_003DzvAopSzLGqCc[i], out _0023_003DzKgWCaV5RTv9VxFld_g_003D_003D, out _0023_003Dz93D7WaCPl_0024u, _0023_003DzRAS4kB6WIA5zYp5K0eecf_00240_003D: false, _0023_003DzF7GfYSI_003D, trimCurve.onTangentType == Face.tangentType.coplanar, _0023_003Dzf5uydyTGDFr_0024: true);
			if (trimCurve.onTangentType == Face.tangentType.coplanar || trimCurve.onTangentType == Face.tangentType.tangent || trimCurve.onTangentType == Face.tangentType.coincident)
			{
				if (flag3 && !_0023_003DzKgWCaV5RTv9VxFld_g_003D_003D)
				{
					flag2 = false;
					flag = false;
				}
			}
			else if ((trimCurve.onTangentType == Face.tangentType.coplanarOpposite || trimCurve.onTangentType == Face.tangentType.coincidentOpposite) && flag3 && _0023_003DzKgWCaV5RTv9VxFld_g_003D_003D)
			{
				flag2 = false;
				flag = false;
			}
			ICurve edge = trimCurve2.Edge;
			int num = -1;
			int num2 = -1;
			Point3D startPoint = edge.StartPoint;
			Point3D endPoint = edge.EndPoint;
			Vertex vertex = new Vertex(startPoint.X, startPoint.Y, startPoint.Z);
			num = _0023_003DzYrt453tI69Ce(vertex, this, trimCurve2, list2, dictionary2, dictionary, list3, _0023_003DzMOzZi0xOKVJU: false);
			if (num == -1)
			{
				num = list3.Count;
				list3.Add(vertex);
			}
			Vertex vertex2 = new Vertex(endPoint.X, endPoint.Y, endPoint.Z);
			num2 = _0023_003DzYrt453tI69Ce(vertex2, this, trimCurve2, list2, dictionary2, dictionary, list3, _0023_003DzMOzZi0xOKVJU: false);
			if (num2 == -1)
			{
				num2 = list3.Count;
				list3.Add(vertex2);
			}
			Edge edge2 = new Edge(edge, num, num2);
			trimCurve2.FromBooleanIntersection = true;
			int count = list4.Count;
			int edgeIndex = (((ICurve)trimCurve2).EdgeIndex = _0023_003DzbIDY9BOTPqfc(edge2, list4, rebuildTolerance, null, null));
			edge2.Curve.EdgeIndex = edgeIndex;
			((ICurve)trimCurve).EdgeIndex = edgeIndex;
			if (count < list4.Count && flag)
			{
				list6.Add(trimCurve);
			}
			if (flag2)
			{
				int _0023_003DzLJVtPYc_003D = trimCurve2.FaceInfo._0023_003DzLJVtPYc_003D;
				if (!dictionary3.ContainsKey(_0023_003DzLJVtPYc_003D))
				{
					dictionary3.Add(_0023_003DzLJVtPYc_003D, new List<ICurve>());
				}
				dictionary3[_0023_003DzLJVtPYc_003D].Add(trimCurve2);
			}
		}
		if (list6.Count > 0 && _0023_003DzcSSP_dM_003D)
		{
			Surface._0023_003Dz2u_3iw7LP_ic _0023_003DzP_2gWaf14JoJ = _0023_003Dz2u_3iw7LP_ic;
			ICurve[] _0023_003Dz1e137UCo69FgKytJgw_003D_003D = list6.ToArray();
			if (!_0023_003Dz95tGpw9eFUqHRfJkNg_003D_003D(_0023_003DzP_2gWaf14JoJ, _0023_003Dz1e137UCo69FgKytJgw_003D_003D, rebuildTolerance, list3, list4, list5, _0023_003Dz82mM5EWr42v6))
			{
				if (!(_0023_003Dzrgqz890sj_0024X9 != null) || array[0].IsClosed)
				{
					return booleanFailureType.Failed;
				}
				ICurve[] individualCurves = array[0].GetIndividualCurves();
				OrientedEdge[] array2 = new OrientedEdge[individualCurves.Length];
				for (int j = 0; j < individualCurves.Length; j++)
				{
					array2[j] = new OrientedEdge(individualCurves[j].EdgeIndex);
				}
				Face face = new Face(new PlanarSurf((Plane)_0023_003Dzrgqz890sj_0024X9.Clone(), list5.Count), new Loop(array2, sense: false));
				face.Color = _0023_003Dz82mM5EWr42v6;
				list5.Add(face);
			}
		}
		_0023_003DzJiYrREIJy046(dictionary2, list2, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, _0023_003Dz_d_002406W8syS3trhyv9w_003D_003D: false);
		try
		{
			for (int k = 0; k < Faces.Length; k++)
			{
				if (dictionary3.ContainsKey(k))
				{
					Faces[k].Visited = true;
					if (dictionary3[k].Count > 0 && !_0023_003Dzt8_0024zbuvCbXTx(this, k, list2, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, _0023_003DzV8Lcc5p5_0024hWB, dictionary, dictionary3, list4, list3, list5, null, null, null, _0023_003DzEt2Zcy_TSPx_0024: false))
					{
						return booleanFailureType.Failed;
					}
				}
			}
		}
		catch (EyeshotException ex)
		{
			if (ex != null)
			{
				throw ex;
			}
			return booleanFailureType.Failed;
		}
		if (list3.Count > 0 && list4.Count > 0 && list5.Count > 0)
		{
			Brep[] array3 = _0023_003Dz2LwOnW_H_0024i8hPxptuw_003D_003D(new Brep(list3.ToArray(), list4.ToArray(), list5.ToArray()));
			if (array3 == null)
			{
				return booleanFailureType.Failed;
			}
			_0023_003Dzd55uIPSKitfg(array3[0].Vertices, array3[0].Edges, array3[0].Faces, array3[0].Inners);
			list = array3.ToList();
			list.RemoveAt(0);
			_0023_003DzACJ8of7_00247mab = list.ToArray();
			Brep[] array4 = _0023_003DzACJ8of7_00247mab;
			for (int _0023_003Dz93D7WaCPl_0024u = 0; _0023_003Dz93D7WaCPl_0024u < array4.Length; _0023_003Dz93D7WaCPl_0024u++)
			{
				array4[_0023_003Dz93D7WaCPl_0024u].CopyAttributes(this);
			}
			RegenMode = regenType.RegenAndCompile;
			return booleanFailureType.Success;
		}
		return booleanFailureType.NotIntersecting;
	}

	public booleanFailureType SubdivideBy(int faceIndex, IList<ICurve> contours)
	{
		booleanFailureType num = Faces[faceIndex].SubdivideBy(contours, this);
		if (num == booleanFailureType.Success)
		{
			RegenMode = regenType.RegenAndCompile;
		}
		return num;
	}

	public booleanFailureType SubdivideBy(int faceIndex, Plane plane)
	{
		booleanFailureType num = Faces[faceIndex].SubdivideBy(plane, this);
		if (num == booleanFailureType.Success)
		{
			RegenMode = regenType.RegenAndCompile;
		}
		return num;
	}

	public booleanFailureType SubdivideBy(Plane plane)
	{
		Dictionary<int, List<ICurve>> dictionary = new Dictionary<int, List<ICurve>>();
		_0023_003DzKK3pUYhqE_002427(null, plane, _0023_003DzOVP5EDBXMxbE: false, out var _0023_003DzvAopSzLGqCc, out var _);
		for (int i = 0; i < _0023_003DzvAopSzLGqCc.Length; i++)
		{
			if (!dictionary.ContainsKey(((TrimCurve)_0023_003DzvAopSzLGqCc[i]).FaceInfo._0023_003DzLJVtPYc_003D))
			{
				dictionary.Add(((TrimCurve)_0023_003DzvAopSzLGqCc[i]).FaceInfo._0023_003DzLJVtPYc_003D, new List<ICurve> { _0023_003DzvAopSzLGqCc[i] });
			}
			else
			{
				dictionary[((TrimCurve)_0023_003DzvAopSzLGqCc[i]).FaceInfo._0023_003DzLJVtPYc_003D].Add(_0023_003DzvAopSzLGqCc[i]);
			}
		}
		Dictionary<int, List<int>> _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D = new Dictionary<int, List<int>>();
		List<int> list = new List<int>();
		List<Edge> _0023_003DzViGQVPM_003D = Edges.Select((Edge _0023_003Dz77g161c_003D) => (Edge)_0023_003Dz77g161c_003D.Clone()).ToList();
		List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D = Vertices.Select((Point3D _0023_003Dz77g161c_003D) => (Point3D)_0023_003Dz77g161c_003D.Clone()).ToList();
		Dictionary<int, int> _0023_003DzV8Lcc5p5_0024hWB = new Dictionary<int, int>();
		Dictionary<int, int> _0023_003DzVR_NB33ieggi = new Dictionary<int, int>();
		booleanFailureType booleanFailureType2 = booleanFailureType.NotIntersecting;
		foreach (KeyValuePair<int, List<ICurve>> item in dictionary)
		{
			booleanFailureType booleanFailureType3 = Faces[item.Key]._0023_003Dz_00242tCFnhZs13OnckxuA_003D_003D(item.Value, this, _0023_003DzdBFS3nhATrKQ: false, _0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, list, _0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003DzV8Lcc5p5_0024hWB, _0023_003DzVR_NB33ieggi);
			if (booleanFailureType3 == booleanFailureType.Success && booleanFailureType2 != booleanFailureType.Failed)
			{
				booleanFailureType2 = booleanFailureType3;
				if (list.Contains(item.Key))
				{
					list.Remove(item.Key);
				}
			}
			else if (booleanFailureType3 == booleanFailureType.Failed)
			{
				booleanFailureType2 = booleanFailureType3;
				if (!list.Contains(item.Key))
				{
					list.Add(item.Key);
				}
			}
		}
		foreach (int item2 in list)
		{
			if (!Faces[item2].Visited)
			{
				Faces[item2]._0023_003DzD3Dj6Qt_0024SLNN(_0023_003Dzn7xPRtY4woa4zm1Ruw_003D_003D, _0023_003DzViGQVPM_003D, Faces[item2].Parametric[0], _0023_003DzJTAR_ngPMCK4: true);
			}
		}
		_0023_003Dz8VkxvzXXGxA_0024(Vertices, Edges, Faces, Inners, _0023_003DzLuJVbec_003D: false);
		if (booleanFailureType2 == booleanFailureType.Success)
		{
			RegenMode = regenType.RegenAndCompile;
		}
		return booleanFailureType2;
	}

	private void _0023_003Dzm46XtFoc4yjkLe4U6I6ZJuCit_0024eyqU3llw_003D_003D(Surface _0023_003DzFmiij5k_003D, ref Plane _0023_003DzUJlotrhfAwWV)
	{
		if (_0023_003DzFmiij5k_003D != null && _0023_003DzUJlotrhfAwWV == null)
		{
			_0023_003DzFmiij5k_003D.IsPlanar(1E-06, out _0023_003DzUJlotrhfAwWV);
		}
		if (!(_0023_003DzUJlotrhfAwWV != null))
		{
			return;
		}
		for (int i = 0; i < Faces.Length; i++)
		{
			Plane plane;
			if (_faces[i].planeAlreadySet)
			{
				plane = _faces[i].plane;
			}
			else
			{
				if (Faces[i]._0023_003Dz9FCm9_0024CiAUGE())
				{
					_faces[i].planeAlreadySet = true;
					continue;
				}
				if (Faces[i].Parametric[0].IsPlanar(1E-09, out plane))
				{
					Faces[i].plane = plane;
				}
				_faces[i].planeAlreadySet = true;
			}
			if (plane != null && Plane.Intersection(_0023_003DzUJlotrhfAwWV, plane, out var _) == planeIntersectionType.Coincide)
			{
				Face.tangentType item = ((!Vector3D.AreOpposite(_0023_003DzUJlotrhfAwWV.AxisZ, plane.AxisZ)) ? Face.tangentType.coplanar : Face.tangentType.coplanarOpposite);
				if (Faces[i].tangentFacesIndices == null)
				{
					Faces[i].tangentFacesIndices = new List<int> { -1 };
					Faces[i].tangentFacesType = new List<Face.tangentType> { item };
				}
				else
				{
					Faces[i].tangentFacesIndices.Add(-1);
					Faces[i].tangentFacesType.Add(item);
				}
			}
		}
	}

	private void _0023_003DzoYtnM6mQQkChQQZjk8nAMKY_003D(Surface _0023_003DzFmiij5k_003D, Plane _0023_003DzUJlotrhfAwWV)
	{
		for (int i = 0; i < Faces.Length; i++)
		{
			if (Faces[i]._0023_003Dz9FCm9_0024CiAUGE())
			{
				continue;
			}
			Face.tangentType tangentType = Surface._0023_003DzmB4COCtQntAOFJR13g_003D_003D(Faces[i].Parametric[0], _0023_003DzFmiij5k_003D, Faces[i].plane, _0023_003DzUJlotrhfAwWV);
			if (tangentType != Face.tangentType.none)
			{
				if (Faces[i].tangentFacesIndices == null)
				{
					Faces[i].tangentFacesIndices = new List<int> { -1 };
					Faces[i].tangentFacesType = new List<Face.tangentType> { tangentType };
				}
				else
				{
					Faces[i].tangentFacesIndices.Add(-1);
					Faces[i].tangentFacesType.Add(tangentType);
				}
			}
		}
	}

	private void _0023_003Dza3t_hvZMRgAKlujUZQ_003D_003D(Surface _0023_003Dz_0024KKopL9T7nzT)
	{
		for (int i = 0; i < _0023_003Dz_0024KKopL9T7nzT.Trimming.ContourList.Count; i++)
		{
			ICurve[] individualCurves = _0023_003Dz_0024KKopL9T7nzT.Trimming.ContourList[i].GetIndividualCurves();
			for (int j = 0; j < individualCurves.Length; j++)
			{
				individualCurves[j].EdgeIndex = -1;
				individualCurves[j].FromBooleanIntersection = false;
			}
		}
	}

	private static bool _0023_003Dz95tGpw9eFUqHRfJkNg_003D_003D(Surface._0023_003Dz2u_3iw7LP_ic _0023_003DzP_2gWaf14JoJ, ICurve[] _0023_003Dz1e137UCo69FgKytJgw_003D_003D, double _0023_003Dz85DwsjHHsAwG, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, List<Edge> _0023_003DzViGQVPM_003D, List<Face> _0023_003DzUbkxYVFDH3ry, Color? _0023_003Dz82mM5EWr42v6)
	{
		List<Surface> list = new List<Surface>();
		Surface surface = (Surface)_0023_003DzP_2gWaf14JoJ._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.Clone();
		if ((!surface.IsClosedU && !surface.IsClosedV) || (!surface._0023_003Dz3K5qCLg_003D(_0023_003Dz1e137UCo69FgKytJgw_003D_003D, _0023_003DzaFEehOi8mwIq: true, list) && list.Count == 0))
		{
			Region[] array = Utility.DetectRegionsFromContours(Utility.GetConnectedCurves(_0023_003Dz1e137UCo69FgKytJgw_003D_003D, _0023_003Dz85DwsjHHsAwG), Plane.XY);
			if (array.Length == 0)
			{
				return false;
			}
			list = new List<Surface>(array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				Surface surface2 = (Surface)surface.Clone();
				surface2.Trimming = array[i];
				Surface._0023_003Dz63Ybg3tCMMws(surface2, surface2._trimming);
				list.Add(surface2);
			}
		}
		else
		{
			list.Add(surface);
		}
		for (int j = 0; j < list.Count; j++)
		{
			Region trimming = list[j].Trimming;
			Loop[] array2 = new Loop[trimming.ContourList.Count];
			for (int k = 0; k < trimming.ContourList.Count; k++)
			{
				OrientedEdge[] array3;
				if (trimming.ContourList[k] is CompositeCurve)
				{
					CompositeCurve compositeCurve = (CompositeCurve)trimming.ContourList[k];
					array3 = new OrientedEdge[compositeCurve.CurveList.Count];
					for (int l = 0; l < compositeCurve.CurveList.Count; l++)
					{
						TrimCurve trimCurve = (TrimCurve)compositeCurve.CurveList[l];
						int num = ((ICurve)trimCurve).EdgeIndex;
						int index = (l + compositeCurve.CurveList.Count - 1) % compositeCurve.CurveList.Count;
						int index2 = (l + 1) % compositeCurve.CurveList.Count;
						int edgeIndex = compositeCurve.CurveList[index].EdgeIndex;
						int edgeIndex2 = compositeCurve.CurveList[index2].EdgeIndex;
						if (num == -1 && edgeIndex != -1 && edgeIndex2 != -1)
						{
							_0023_003DzetoHQs8u7csjtSYmLRke840_003D _0023_003DzetoHQs8u7csjtSYmLRke840_003D2 = new _0023_003DzetoHQs8u7csjtSYmLRke840_003D();
							Edge edge = _0023_003DzViGQVPM_003D[edgeIndex];
							Edge edge2 = _0023_003DzViGQVPM_003D[edgeIndex2];
							bool flag = Point3D.Distance(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[edge.StartPointIndex], ((TrimCurve)compositeCurve.CurveList[index]).Edge.StartPoint) < _0023_003Dz85DwsjHHsAwG && Vector3D.AreCoincident(((TrimCurve)compositeCurve.CurveList[index]).Edge.StartTangent, edge.Curve.StartTangent);
							bool flag2 = Point3D.Distance(_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[edge2.StartPointIndex], ((TrimCurve)compositeCurve.CurveList[index2]).Edge.StartPoint) < _0023_003Dz85DwsjHHsAwG && Vector3D.AreCoincident(((TrimCurve)compositeCurve.CurveList[index2]).Edge.StartTangent, edge2.Curve.StartTangent);
							_0023_003DzetoHQs8u7csjtSYmLRke840_003D2._0023_003Dz9yOCzf0_003D = new Edge(trimCurve.Edge, flag ? edge.EndPointIndex : edge.StartPointIndex, flag2 ? edge2.StartPointIndex : edge2.EndPointIndex);
							if ((num = _0023_003DzViGQVPM_003D.FindIndex(_0023_003Dz1e137UCo69FgKytJgw_003D_003D.Length - 1, _0023_003DzetoHQs8u7csjtSYmLRke840_003D2._0023_003DzYabVoCkgaVOTjAOHa86_hnvuCUgt)) < 0)
							{
								num = _0023_003DzViGQVPM_003D.Count;
								_0023_003DzViGQVPM_003D.Add(_0023_003DzetoHQs8u7csjtSYmLRke840_003D2._0023_003Dz9yOCzf0_003D);
							}
						}
						else if (((ICurve)trimCurve).EdgeIndex == -1)
						{
							return false;
						}
						((ICurve)trimCurve).EdgeIndex = num;
						bool sense = Point3D.Distance(trimCurve.Edge.StartPoint, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzViGQVPM_003D[num].StartPointIndex]) < _0023_003Dz85DwsjHHsAwG && Vector3D.AreCoincident(trimCurve.Edge.StartTangent, _0023_003DzViGQVPM_003D[num].Curve.StartTangent);
						array3[l] = new OrientedEdge(num, sense);
					}
				}
				else
				{
					TrimCurve trimCurve2 = (TrimCurve)trimming.ContourList[k];
					int edgeIndex3 = ((ICurve)trimCurve2).EdgeIndex;
					bool sense2 = Point3D.Distance(trimCurve2.Edge.StartPoint, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzViGQVPM_003D[edgeIndex3].StartPointIndex]) < _0023_003Dz85DwsjHHsAwG && Vector3D.AreCoincident(trimCurve2.Edge.StartTangent, _0023_003DzViGQVPM_003D[edgeIndex3].Curve.StartTangent);
					array3 = new OrientedEdge[1]
					{
						new OrientedEdge(edgeIndex3, sense2)
					};
				}
				array2[k] = new Loop(array3, sense: true);
			}
			Face face = new Face(surface._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D(), array2);
			Surface surface3 = (Surface)_0023_003DzP_2gWaf14JoJ._0023_003Dz4wZe_0024Xg_003D.Clone();
			Surface._0023_003Dz2H0sPWA7GG3dUZULsA6_WPc_003D(surface3, _0023_003DzP_2gWaf14JoJ._0023_003Dz2AZ_kpw_003D, _0023_003DzP_2gWaf14JoJ._0023_003Dza2Pq9PQ_003D, _0023_003DzP_2gWaf14JoJ._0023_003Dz4EQwPRR8p12S, list[j], _0023_003DzP_2gWaf14JoJ._0023_003DzskeF_tVWIwSE);
			list[j] = surface3;
			face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(new Surface[1] { list[j] });
			face.Color = _0023_003Dz82mM5EWr42v6;
			_0023_003DzUbkxYVFDH3ry.Add(face);
		}
		return true;
	}

	public pointStatusType IsPointInside(Point3D point, bool skipRebuild = false)
	{
		if (!skipRebuild)
		{
			Rebuild(0.0, soft: true);
		}
		if (localMin == null || localMax == null)
		{
			_0023_003DzQCWJbpjMGLxZWfwMCQ_003D_003D(out localMin, out localMax, _0023_003Dz7cP1pZCb1hQy: true);
		}
		if (!point.IsInside(base.BoxMin, base.BoxMax))
		{
			return pointStatusType.Outside;
		}
		switch (_0023_003DzVb4wZyDw8mgJ(point, (Utility._0023_003DzwhtOFTk_003D)0))
		{
		default:
			return pointStatusType.Outside;
		case 1:
			return pointStatusType.Inside;
		case -1:
			switch (_0023_003DzVb4wZyDw8mgJ(point, (Utility._0023_003DzwhtOFTk_003D)2))
			{
			default:
				return pointStatusType.Outside;
			case 1:
				return pointStatusType.Inside;
			case -1:
				switch (_0023_003DzVb4wZyDw8mgJ(point, (Utility._0023_003DzwhtOFTk_003D)1))
				{
				default:
					return pointStatusType.Outside;
				case 1:
					return pointStatusType.Inside;
				case -1:
				{
					ClosestPointTo(point, out var closest);
					if (Point3D.DistanceSquared(point, closest) < _rebuildTol * _rebuildTol)
					{
						return pointStatusType.Onto;
					}
					return pointStatusType.Undetermined;
				}
				}
			}
		}
	}

	private int _0023_003DzVb4wZyDw8mgJ(Point3D _0023_003DzlY77YgY_003D, Utility._0023_003DzwhtOFTk_003D _0023_003DzxuJqjrs_003D)
	{
		int num = 0;
		if (Faces.Length == 1 && Faces[0].Parametric.Length == 1)
		{
			if (Faces[0].Parametric[0] is ToroidalSurface)
			{
				ToroidalSurface toroidalSurface = (ToroidalSurface)Faces[0].Parametric[0];
				double num2 = Math.Abs(_0023_003DzlY77YgY_003D.DistanceTo(toroidalSurface.Center));
				if (num2 > toroidalSurface.MajorRadius + toroidalSurface.MinorRadius || num2 < toroidalSurface.MajorRadius - toroidalSurface.MinorRadius)
				{
					return 0;
				}
			}
			else
			{
				if (Faces[0].Parametric[0] is SphericalSurface)
				{
					SphericalSurface sphericalSurface = (SphericalSurface)Faces[0].Parametric[0];
					if (Math.Abs(_0023_003DzlY77YgY_003D.DistanceTo(sphericalSurface.Center)) > sphericalSurface.Radius)
					{
						return 0;
					}
					return 1;
				}
				if (Faces[0].Parametric[0] is CylindricalSurface)
				{
					CylindricalSurface cylindricalSurface = (CylindricalSurface)Faces[0].Parametric[0];
					if (Math.Abs(_0023_003DzlY77YgY_003D.DistanceTo(cylindricalSurface.Center)) > cylindricalSurface.Radius)
					{
						return 0;
					}
				}
			}
		}
		Line[] array = new Line[4];
		Segment3D segment3D = Utility._0023_003DzDoIUcjWkjZQJ(_0023_003DzlY77YgY_003D, _0023_003DzxuJqjrs_003D, base.BoxMin, base.BoxMax, 0.0);
		Segment3D segment3D2 = Utility._0023_003DzDoIUcjWkjZQJ(_0023_003DzlY77YgY_003D, _0023_003DzxuJqjrs_003D, base.BoxMin, base.BoxMax, Utility.DegToRad(10.0));
		array[0] = new Line(_0023_003DzlY77YgY_003D, segment3D.P1);
		array[1] = new Line(segment3D.P0, _0023_003DzlY77YgY_003D);
		array[2] = new Line(_0023_003DzlY77YgY_003D, segment3D2.P1);
		array[3] = new Line(segment3D2.P0, _0023_003DzlY77YgY_003D);
		for (int i = 0; i < array.Length; i++)
		{
			num = _0023_003DzN_0024dOy9n0RFtsKjIWtg_003D_003D(array[i], _0023_003DzlY77YgY_003D);
			if (num != -1)
			{
				return num;
			}
		}
		return num;
	}

	private int _0023_003DzN_0024dOy9n0RFtsKjIWtg_003D_003D(Line _0023_003DzPpF_0024Cv0_003D, Point3D _0023_003DzlY77YgY_003D)
	{
		int num = 0;
		int result = 0;
		bool _0023_003DzTZVb85e98Ui = false;
		List<Point3D> _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D = new List<Point3D>();
		for (int i = 0; i < Faces.Length; i++)
		{
			Surface[] parametric = Faces[i].Parametric;
			for (int j = 0; j < parametric.Length; j++)
			{
				if (_0023_003DzEGNxIbHV4ZZxnFpwjA_003D_003D(parametric[j], _0023_003DzPpF_0024Cv0_003D.StartTangent, _0023_003DzlY77YgY_003D))
				{
					_0023_003Dz9JK49cQJe__0024g1wd8Fa4VEl4HQf4Iqci9_0024A_003D_003D(_0023_003DzPpF_0024Cv0_003D, base.BoxSize.Diagonal, parametric[j], ref _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D, ref _0023_003DzTZVb85e98Ui);
				}
			}
			if (_0023_003DzTZVb85e98Ui)
			{
				return -1;
			}
		}
		for (int k = 0; k < Inners.GetLength(0); k++)
		{
			for (int l = 0; l < Inners[k].Length; l++)
			{
				Surface[] parametric2 = Inners[k][l].Parametric;
				for (int m = 0; m < parametric2.Length; m++)
				{
					if (_0023_003DzEGNxIbHV4ZZxnFpwjA_003D_003D(parametric2[m], _0023_003DzPpF_0024Cv0_003D.StartTangent, _0023_003DzlY77YgY_003D))
					{
						_0023_003Dz9JK49cQJe__0024g1wd8Fa4VEl4HQf4Iqci9_0024A_003D_003D(_0023_003DzPpF_0024Cv0_003D, base.BoxSize.Diagonal, parametric2[m], ref _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D, ref _0023_003DzTZVb85e98Ui);
						if (_0023_003DzTZVb85e98Ui)
						{
							return -1;
						}
					}
				}
			}
		}
		num += _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D.Count;
		if (num % 2 != 0)
		{
			result = 1;
		}
		return result;
	}

	private static void _0023_003Dz9JK49cQJe__0024g1wd8Fa4VEl4HQf4Iqci9_0024A_003D_003D(Line _0023_003DzPpF_0024Cv0_003D, double _0023_003DzccAR5G0_003D, Surface _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D, ref List<Point3D> _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D, ref bool _0023_003DzTZVb85e98Ui7)
	{
		Point3D[] array = _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.IntersectWith(_0023_003DzPpF_0024Cv0_003D);
		for (int i = 0; i < array.Length; i++)
		{
			InitialPoint initialPoint = (InitialPoint)array[i];
			if (Utility._0023_003DzbIDY9BOTPqfc(initialPoint, _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D, _0023_003DzccAR5G0_003D))
			{
				Vector3D vector3D = _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.NormalAt(initialPoint.s, initialPoint.t);
				_0023_003DzPpF_0024Cv0_003D.StartTangent.Normalize();
				if (Math.Abs(_0023_003DzPpF_0024Cv0_003D.StartTangent * vector3D) < 0.001)
				{
					_0023_003DzTZVb85e98Ui7 = true;
					break;
				}
				if (_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Trimming.IsPointOnContour(new Point3D(initialPoint.s, initialPoint.t, 0.0), _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D._0023_003DzVx1luJEZaaC7().Diagonal * 0.001))
				{
					_0023_003DzTZVb85e98Ui7 = true;
					break;
				}
			}
		}
	}

	private static bool _0023_003DzEGNxIbHV4ZZxnFpwjA_003D_003D(Surface _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D, Vector3D _0023_003DzvCHh__0024sF4dWH, Point3D _0023_003DzlY77YgY_003D)
	{
		_0023_003DzvCHh__0024sF4dWH.Normalize();
		if (_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D is PlanarSurface)
		{
			Plane plane = ((PlanarSurface)_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D).Plane;
			if (Vector3D.AreOrthogonal(_0023_003DzvCHh__0024sF4dWH, plane.AxisZ))
			{
				return false;
			}
		}
		if (_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D is CylindricalSurface && !(_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D is ConicalSurface))
		{
			CylindricalSurface cylindricalSurface = (CylindricalSurface)_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D;
			if (Vector3D.AreParallel(_0023_003DzvCHh__0024sF4dWH, cylindricalSurface.Axis))
			{
				return false;
			}
		}
		_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.ControlBoundingBox(out var min, out var max);
		if (!_0023_003Dz2EwZI7LqotMS5Mp9dPZXc28_003D(_0023_003DzlY77YgY_003D, min, max, _0023_003DzvCHh__0024sF4dWH))
		{
			return false;
		}
		return true;
	}

	private static bool _0023_003Dz2EwZI7LqotMS5Mp9dPZXc28_003D(Point3D _0023_003DzlY77YgY_003D, Point3D _0023_003DzDPcjoBJLcqli, Point3D _0023_003Dz_0024N_0024yKptW9BoC, Vector3D _0023_003DzxuJqjrs_003D)
	{
		if (Vector3D.AreParallel(_0023_003DzxuJqjrs_003D, Vector3D.AxisX))
		{
			if (_0023_003DzlY77YgY_003D.Y >= _0023_003DzDPcjoBJLcqli.Y - 1.0 && _0023_003DzlY77YgY_003D.Y <= _0023_003Dz_0024N_0024yKptW9BoC.Y + 1.0 && _0023_003DzlY77YgY_003D.Z >= _0023_003DzDPcjoBJLcqli.Z - 1.0 && _0023_003DzlY77YgY_003D.Z <= _0023_003Dz_0024N_0024yKptW9BoC.Z + 1.0)
			{
				return true;
			}
		}
		else if (Vector3D.AreParallel(_0023_003DzxuJqjrs_003D, Vector3D.AxisY))
		{
			if (_0023_003DzlY77YgY_003D.X >= _0023_003DzDPcjoBJLcqli.X - 1.0 && _0023_003DzlY77YgY_003D.X <= _0023_003Dz_0024N_0024yKptW9BoC.X + 1.0 && _0023_003DzlY77YgY_003D.Z >= _0023_003DzDPcjoBJLcqli.Z - 1.0 && _0023_003DzlY77YgY_003D.Z <= _0023_003Dz_0024N_0024yKptW9BoC.Z + 1.0)
			{
				return true;
			}
		}
		else
		{
			if (!Vector3D.AreParallel(_0023_003DzxuJqjrs_003D, Vector3D.AxisZ))
			{
				return true;
			}
			if (_0023_003DzlY77YgY_003D.X >= _0023_003DzDPcjoBJLcqli.X - 1.0 && _0023_003DzlY77YgY_003D.X <= _0023_003Dz_0024N_0024yKptW9BoC.X + 1.0 && _0023_003DzlY77YgY_003D.Y >= _0023_003DzDPcjoBJLcqli.Y - 1.0 && _0023_003DzlY77YgY_003D.Y <= _0023_003Dz_0024N_0024yKptW9BoC.Y + 1.0)
			{
				return true;
			}
		}
		return false;
	}

	internal static bool _0023_003Dz6KMeGlIwa_ELnAyOOa4Yu6o_003D(ref List<ICurve> _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D, ref List<ICurve> _0023_003Dz81sECUMrsR8n, ref List<ICurve> _0023_003DzT4jdzOkqELa6, double _0023_003DzGvLz4uh736QEMEZuVg_003D_003D)
	{
		Point3D[] array = new Point3D[_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count * 2];
		for (int i = 0; i < _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count; i++)
		{
			_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D[i].GetApproximatedBoundingBox(out var boxMin, out var boxMax);
			array[i] = boxMin;
			array[i + _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count] = boxMax;
		}
		Utility.BoundingBox(array, out var min, out var max);
		double _0023_003Dzm0CYiiE_003D = new Size3D(min, max).Diagonal * Utility._0023_003DzxhnLabVjXjPg;
		if (_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count <= 1)
		{
			return true;
		}
		List<ICurve> list = new List<ICurve>(_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count);
		List<ICurve> list2 = new List<ICurve>(_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count);
		List<ICurve> list3 = new List<ICurve>(_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count);
		List<ICurve> list4 = new List<ICurve>(_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count);
		List<ICurve> list5 = new List<ICurve>(_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count);
		List<ICurve> list6 = new List<ICurve>(_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count);
		ICurve curve = _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D[0];
		_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.RemoveAt(0);
		ICurve curve2 = null;
		ICurve curve3 = null;
		curve2 = _0023_003Dz81sECUMrsR8n[0];
		_0023_003Dz81sECUMrsR8n.RemoveAt(0);
		curve3 = _0023_003DzT4jdzOkqELa6[0];
		_0023_003DzT4jdzOkqELa6.RemoveAt(0);
		int num = 0;
		while (_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count > 0)
		{
			ICurve curve4 = _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D[num];
			ICurve _0023_003DzB9SXqllpeTK = _0023_003Dz81sECUMrsR8n[num];
			ICurve _0023_003DzOZC6CD485ZNl = _0023_003DzT4jdzOkqELa6[num];
			Utility._0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D _0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D = Utility._0023_003Dz8G5bN3VOoglVAAMdtA_003D_003D(curve, curve4);
			if (_0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D == (Utility._0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D)4)
			{
				list4.Add(curve);
				list5.Add(curve2);
				list6.Add(curve3);
				_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.RemoveAt(num);
				list5.Add(_0023_003Dz81sECUMrsR8n[num]);
				_0023_003Dz81sECUMrsR8n.RemoveAt(num);
				list6.Add(_0023_003DzT4jdzOkqELa6[num]);
				_0023_003DzT4jdzOkqELa6.RemoveAt(num);
				num = 0;
				if (_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count == 1)
				{
					list4.Add(_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D[0]);
					list5.Add(_0023_003Dz81sECUMrsR8n[0]);
					list6.Add(_0023_003DzT4jdzOkqELa6[0]);
					break;
				}
				if (list.Count == 0 && _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count > 0)
				{
					curve = _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D[0];
					_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.RemoveAt(0);
					curve2 = _0023_003Dz81sECUMrsR8n[0];
					_0023_003Dz81sECUMrsR8n.RemoveAt(0);
					curve3 = _0023_003DzT4jdzOkqELa6[0];
					_0023_003DzT4jdzOkqELa6.RemoveAt(0);
				}
				if (list.Count > 0)
				{
					curve = list[0];
					list.RemoveAt(0);
					curve2 = list2[0];
					list2.RemoveAt(0);
					curve3 = list3[0];
					list3.RemoveAt(0);
				}
				continue;
			}
			if (_0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D == (Utility._0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D)2 && num < _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count - 1)
			{
				num++;
				continue;
			}
			int num2 = 0;
			if (_0023_003DzBrVhq6fh9q_0024g(curve, curve2, curve3, curve4, _0023_003DzB9SXqllpeTK, _0023_003DzOZC6CD485ZNl, list, list2, list3, _0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D, _0023_003Dzm0CYiiE_003D, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D))
			{
				num2++;
				_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.RemoveAt(num);
				_0023_003Dz81sECUMrsR8n.RemoveAt(num);
				_0023_003DzT4jdzOkqELa6.RemoveAt(num);
				num = 0;
			}
			else if (_0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D != (Utility._0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D)2)
			{
				_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.AddRange(list4);
				_0023_003Dz81sECUMrsR8n.AddRange(list5);
				_0023_003DzT4jdzOkqELa6.AddRange(list6);
				return false;
			}
			if (num == _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count - 1)
			{
				list4.Add(curve);
				list5.Add(curve2);
				list6.Add(curve3);
				num = 0;
				if (_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count == 1)
				{
					list4.Add(_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D[0]);
					list5.Add(_0023_003Dz81sECUMrsR8n[0]);
					list6.Add(_0023_003DzT4jdzOkqELa6[0]);
					break;
				}
			}
			if (list.Count == 0 && _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count > 0)
			{
				curve = _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D[0];
				_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.RemoveAt(0);
				curve2 = _0023_003Dz81sECUMrsR8n[0];
				_0023_003Dz81sECUMrsR8n.RemoveAt(0);
				curve3 = _0023_003DzT4jdzOkqELa6[0];
				_0023_003DzT4jdzOkqELa6.RemoveAt(0);
			}
			if (list.Count > 0)
			{
				curve = list[0];
				list.RemoveAt(0);
				curve2 = list2[0];
				list2.RemoveAt(0);
				curve3 = list3[0];
				list3.RemoveAt(0);
			}
		}
		_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D = list4;
		_0023_003Dz81sECUMrsR8n = list5;
		_0023_003DzT4jdzOkqELa6 = list6;
		return true;
	}

	internal static bool _0023_003DzBrVhq6fh9q_0024g(ICurve _0023_003Dz3Ftsho0_003D, ICurve _0023_003Dzn1a4Ukw_003D, ICurve _0023_003DzLEnKVfk_003D, ICurve _0023_003Dzq_00240BKhUirasG, ICurve _0023_003DzB9SXqllpeTK4, ICurve _0023_003DzOZC6CD485ZNl, List<ICurve> _0023_003DzU9kLWIu9nU0q, List<ICurve> _0023_003Dz9zLwxmXkgFXY, List<ICurve> _0023_003DzyyoeQznW8_efUHj_0024TQ_003D_003D, Utility._0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D _0023_003Dzd4UzfAt5a_0024Oa, double _0023_003Dzm0CYiiE_003D, double _0023_003DzGvLz4uh736QEMEZuVg_003D_003D)
	{
		ICurve curve = (ICurve)_0023_003Dz3Ftsho0_003D.Clone();
		TrimCurve trimCurve = (TrimCurve)_0023_003Dzn1a4Ukw_003D;
		TrimCurve trimCurve2 = (TrimCurve)_0023_003DzLEnKVfk_003D;
		ICurve curve2 = (ICurve)_0023_003Dzq_00240BKhUirasG.Clone();
		TrimCurve trimCurve3 = (TrimCurve)_0023_003DzB9SXqllpeTK4;
		TrimCurve trimCurve4 = (TrimCurve)_0023_003DzOZC6CD485ZNl;
		List<Point3D> list = new List<Point3D>(2);
		List<Point3D> list2 = new List<Point3D>(2);
		List<Point3D> list3 = new List<Point3D>(2);
		List<Point3D> list4 = new List<Point3D>(2);
		List<Point3D> list5 = new List<Point3D>(2);
		List<Point3D> list6 = new List<Point3D>(2);
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		if (Vector3D.AreOpposite(curve.StartTangent, curve2.StartTangent))
		{
			if (_0023_003Dzd4UzfAt5a_0024Oa == (Utility._0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D)0)
			{
				curve.Reverse();
			}
			else
			{
				curve2.Reverse();
			}
		}
		InitialPoint endIp = trimCurve.endIp;
		InitialPoint startIp = trimCurve.startIp;
		InitialPoint endIp2 = trimCurve3.endIp;
		InitialPoint startIp2 = trimCurve3.startIp;
		switch (_0023_003Dzd4UzfAt5a_0024Oa)
		{
		case (Utility._0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D)0:
		{
			curve2.Project(curve.StartPoint, out var t5);
			Point2D proj7;
			Point2D proj8;
			if (curve2.Domain.Includes(t5, _0023_003Dzm0CYiiE_003D) && !Utility.AreEqual(t5, curve2.Domain.Low, curve2.Domain.Length) && !Utility.AreEqual(t5, curve2.Domain.High, curve2.Domain.Length))
			{
				list2.Add(curve.StartPoint);
				if (endIp._0023_003DzSobLr5DEOQoE && endIp.startPointCurveOwner == trimCurve3.originalSurface)
				{
					proj7 = new Point3D(startIp.u, startIp.v);
				}
				else
				{
					trimCurve3.originalSurface.PointInversion(curve.StartPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out proj7);
				}
				if (!endIp._0023_003DzSobLr5DEOQoE && endIp.startPointCurveOwner == trimCurve4.originalSurface)
				{
					proj8 = new Point3D(startIp.s, startIp.t);
				}
				else
				{
					trimCurve4.originalSurface.PointInversion(curve.StartPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out proj8);
				}
				list4.Add(new Point3D(proj7.X, proj7.Y));
				list6.Add(new Point3D(proj8.X, proj8.Y));
				flag3 = true;
			}
			curve2.Project(curve.EndPoint, out t5);
			if (curve2.Domain.Includes(t5, _0023_003Dzm0CYiiE_003D) && !Utility.AreEqual(t5, curve2.Domain.Low, curve2.Domain.Length) && !Utility.AreEqual(t5, curve2.Domain.High, curve2.Domain.Length))
			{
				list2.Add(curve.EndPoint);
				if (endIp._0023_003DzSobLr5DEOQoE && endIp.startPointCurveOwner == trimCurve3.originalSurface)
				{
					proj7 = new Point3D(endIp.u, endIp.v);
				}
				else
				{
					trimCurve3.originalSurface.PointInversion(curve.EndPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out proj7);
				}
				if (!endIp._0023_003DzSobLr5DEOQoE && endIp.startPointCurveOwner == trimCurve4.originalSurface)
				{
					proj8 = new Point3D(endIp.s, endIp.t);
				}
				else
				{
					trimCurve4.originalSurface.PointInversion(curve.EndPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out proj8);
				}
				list4.Add(new Point3D(proj7.X, proj7.Y));
				list6.Add(new Point3D(proj8.X, proj8.Y));
				flag4 = true;
			}
			break;
		}
		case (Utility._0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D)1:
		{
			curve.Project(curve2.StartPoint, out var t4);
			Point2D proj5;
			Point2D proj6;
			if (curve.Domain.Includes(t4, _0023_003Dzm0CYiiE_003D) && !Utility.AreEqual(t4, curve.Domain.Low, curve.Domain.Length) && !Utility.AreEqual(t4, curve.Domain.High, curve.Domain.Length))
			{
				list.Add(curve2.StartPoint);
				if (startIp2._0023_003DzSobLr5DEOQoE && startIp2.startPointCurveOwner == trimCurve.originalSurface)
				{
					proj5 = new Point3D(startIp2.u, startIp2.v);
				}
				else
				{
					trimCurve.originalSurface.PointInversion(curve2.StartPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out proj5);
				}
				if (!startIp2._0023_003DzSobLr5DEOQoE && startIp2.startPointCurveOwner == trimCurve2.originalSurface)
				{
					proj6 = new Point3D(startIp2.s, startIp2.t);
				}
				else
				{
					trimCurve2.originalSurface.PointInversion(curve2.StartPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out proj6);
				}
				list3.Add(new Point3D(proj5.X, proj5.Y));
				list5.Add(new Point3D(proj6.X, proj6.Y));
				flag = true;
			}
			curve.Project(curve2.EndPoint, out t4);
			if (curve.Domain.Includes(t4, _0023_003Dzm0CYiiE_003D) && !Utility.AreEqual(t4, curve.Domain.Low, curve.Domain.Length) && !Utility.AreEqual(t4, curve.Domain.High, curve.Domain.Length))
			{
				list.Add(curve2.EndPoint);
				if (endIp2._0023_003DzSobLr5DEOQoE && endIp2.startPointCurveOwner == trimCurve.originalSurface)
				{
					proj5 = new Point3D(endIp2.u, endIp2.v);
				}
				else
				{
					trimCurve.originalSurface.PointInversion(curve2.EndPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out proj5);
				}
				if (!endIp2._0023_003DzSobLr5DEOQoE && endIp2.startPointCurveOwner == trimCurve2.originalSurface)
				{
					proj6 = new Point3D(endIp2.s, endIp2.t);
				}
				else
				{
					trimCurve2.originalSurface.PointInversion(curve2.EndPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out proj6);
				}
				list3.Add(new Point3D(proj5.X, proj5.Y));
				list5.Add(new Point3D(proj6.X, proj6.Y));
				flag2 = true;
			}
			break;
		}
		case (Utility._0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D)3:
		{
			curve.Project(curve2.StartPoint, out var t);
			if (curve.Domain.Includes(t, _0023_003Dzm0CYiiE_003D) && !Utility.AreEqual(t, curve.Domain.Low, curve.Domain.Length) && !Utility.AreEqual(t, curve.Domain.High, curve.Domain.Length))
			{
				list.Add(curve2.StartPoint);
				Point2D proj;
				if (startIp2._0023_003DzSobLr5DEOQoE && startIp2.startPointCurveOwner == trimCurve.originalSurface)
				{
					proj = new Point3D(startIp2.u, startIp2.v);
				}
				else
				{
					trimCurve.originalSurface.PointInversion(curve2.StartPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out proj);
				}
				Point2D proj2;
				if (!startIp2._0023_003DzSobLr5DEOQoE && startIp2.startPointCurveOwner == trimCurve2.originalSurface)
				{
					proj2 = new Point3D(startIp2.s, startIp2.t);
				}
				else
				{
					trimCurve2.originalSurface.PointInversion(curve2.StartPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out proj2);
				}
				list3.Add(new Point3D(proj.X, proj.Y));
				list5.Add(new Point3D(proj2.X, proj2.Y));
				flag = (flag2 = true);
				curve2.Project(curve.EndPoint, out var t2);
				if (curve2.Domain.Includes(t2, _0023_003Dzm0CYiiE_003D) && !Utility.AreEqual(t2, curve2.Domain.Low, curve2.Domain.Length) && !Utility.AreEqual(t2, curve2.Domain.High, curve2.Domain.Length))
				{
					list2.Add(curve.EndPoint);
					if (endIp._0023_003DzSobLr5DEOQoE && endIp.startPointCurveOwner == trimCurve3.originalSurface)
					{
						proj = new Point3D(endIp.u, endIp.v);
					}
					else
					{
						trimCurve3.originalSurface.PointInversion(curve.EndPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out proj);
					}
					if (!endIp._0023_003DzSobLr5DEOQoE && endIp.startPointCurveOwner == trimCurve4.originalSurface)
					{
						proj2 = new Point3D(endIp.s, endIp.t);
					}
					else
					{
						trimCurve4.originalSurface.PointInversion(curve.EndPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out proj2);
					}
					list4.Add(new Point3D(proj.X, proj.Y));
					list6.Add(new Point3D(proj2.X, proj2.Y));
					flag3 = false;
					flag4 = true;
				}
				break;
			}
			curve.Project(curve2.EndPoint, out t);
			if (!curve.Domain.Includes(t, _0023_003Dzm0CYiiE_003D) || Utility.AreEqual(t, curve.Domain.Low, curve.Domain.Length) || Utility.AreEqual(t, curve.Domain.High, curve.Domain.Length))
			{
				break;
			}
			list.Add(curve2.EndPoint);
			Point2D proj3;
			if (endIp2._0023_003DzSobLr5DEOQoE && endIp2.startPointCurveOwner == trimCurve.originalSurface)
			{
				proj3 = new Point3D(endIp2.u, endIp2.v);
			}
			else
			{
				trimCurve.originalSurface.PointInversion(curve2.EndPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out proj3);
			}
			Point2D proj4;
			if (!endIp2._0023_003DzSobLr5DEOQoE && endIp2.startPointCurveOwner == trimCurve2.originalSurface)
			{
				proj4 = new Point3D(endIp2.s, endIp2.t);
			}
			else
			{
				trimCurve2.originalSurface.PointInversion(curve2.EndPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out proj4);
			}
			list3.Add(new Point3D(proj3.X, proj3.Y));
			list5.Add(new Point3D(proj4.X, proj4.Y));
			flag = (flag2 = true);
			curve2.Project(curve.StartPoint, out var t3);
			if (curve2.Domain.Includes(t3, _0023_003Dzm0CYiiE_003D) && !Utility.AreEqual(t3, curve2.Domain.Low, curve2.Domain.Length) && !Utility.AreEqual(t3, curve2.Domain.High, curve2.Domain.Length))
			{
				list2.Add(curve.StartPoint);
				if (endIp._0023_003DzSobLr5DEOQoE && endIp.startPointCurveOwner == trimCurve3.originalSurface)
				{
					proj3 = new Point3D(startIp.u, startIp.v);
				}
				else
				{
					trimCurve3.originalSurface.PointInversion(curve.StartPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out proj3);
				}
				if (!endIp._0023_003DzSobLr5DEOQoE && endIp.startPointCurveOwner == trimCurve4.originalSurface)
				{
					proj4 = new Point3D(startIp.s, startIp.t);
				}
				else
				{
					trimCurve4.originalSurface.PointInversion(curve.StartPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out proj4);
				}
				list4.Add(new Point3D(proj3.X, proj3.Y));
				list6.Add(new Point3D(proj4.X, proj4.Y));
				flag3 = true;
				flag4 = false;
			}
			break;
		}
		default:
			return false;
		}
		if (list.Count > 0)
		{
			ICurve[] segments = null;
			ICurve[] segments2 = null;
			_0023_003Dz3Ftsho0_003D.SplitBy(list, out var segments3);
			trimCurve.SplitBy(list3, out segments);
			trimCurve2.SplitBy(list5, out segments2);
			if (segments.Length != segments3.Length || segments2.Length != segments3.Length || segments3.Length == 0)
			{
				return false;
			}
			if (flag)
			{
				_0023_003DzT4na_9HtOkWw(_0023_003Dz3Ftsho0_003D, segments3[0]);
				_0023_003DzU9kLWIu9nU0q.Add(segments3[0]);
				segments[0] = ((Curve)segments[0])._0023_003DzmGgqdRaHiXdg(segments3[0]);
				((TrimCurve)segments[0]).originalSurface = trimCurve.originalSurface;
				((TrimCurve)segments[0]).FaceInfo = trimCurve.FaceInfo;
				((TrimCurve)segments[0]).startIp = startIp;
				((TrimCurve)segments[0]).endIp = startIp2;
				_0023_003DzT4na_9HtOkWw(trimCurve, segments[0]);
				segments2[0] = ((Curve)segments2[0])._0023_003DzmGgqdRaHiXdg(segments3[0]);
				((TrimCurve)segments2[0]).originalSurface = trimCurve2.originalSurface;
				((TrimCurve)segments2[0]).FaceInfo = trimCurve2.FaceInfo;
				((TrimCurve)segments2[0]).startIp = startIp;
				((TrimCurve)segments2[0]).endIp = startIp2;
				_0023_003DzT4na_9HtOkWw(trimCurve2, segments2[0]);
				_0023_003Dz9zLwxmXkgFXY.Add(segments[0]);
				_0023_003DzyyoeQznW8_efUHj_0024TQ_003D_003D.Add(segments2[0]);
			}
			if (flag2)
			{
				int num = segments3.Length - 1;
				_0023_003DzT4na_9HtOkWw(_0023_003Dz3Ftsho0_003D, segments3[num]);
				_0023_003DzU9kLWIu9nU0q.Add(segments3[num]);
				segments[num] = ((Curve)segments[num])._0023_003DzmGgqdRaHiXdg(segments3[num]);
				((TrimCurve)segments[num]).originalSurface = trimCurve.originalSurface;
				((TrimCurve)segments[num]).FaceInfo = trimCurve.FaceInfo;
				((TrimCurve)segments[num]).endIp = endIp;
				((TrimCurve)segments[num]).startIp = endIp2;
				_0023_003DzT4na_9HtOkWw(trimCurve, segments[num]);
				segments2[num] = ((Curve)segments2[num])._0023_003DzmGgqdRaHiXdg(segments3[num]);
				((TrimCurve)segments2[num]).originalSurface = trimCurve2.originalSurface;
				((TrimCurve)segments2[num]).FaceInfo = trimCurve2.FaceInfo;
				((TrimCurve)segments2[num]).endIp = endIp;
				((TrimCurve)segments2[num]).startIp = endIp2;
				_0023_003DzT4na_9HtOkWw(trimCurve2, segments2[num]);
				_0023_003Dz9zLwxmXkgFXY.Add(segments[num]);
				_0023_003DzyyoeQznW8_efUHj_0024TQ_003D_003D.Add(segments2[num]);
			}
		}
		else
		{
			_0023_003DzU9kLWIu9nU0q.Add(_0023_003Dz3Ftsho0_003D);
			_0023_003Dz9zLwxmXkgFXY.Add(_0023_003Dzn1a4Ukw_003D);
			_0023_003DzyyoeQznW8_efUHj_0024TQ_003D_003D.Add(_0023_003DzLEnKVfk_003D);
		}
		if (list2.Count > 0)
		{
			ICurve[] segments4 = null;
			ICurve[] segments5 = null;
			_0023_003Dzq_00240BKhUirasG.SplitBy(list2, out var segments6);
			trimCurve3.SplitBy(list4, out segments4);
			trimCurve4.SplitBy(list6, out segments5);
			if (segments4.Length == 0 || segments4.Length != segments6.Length || segments5.Length != segments6.Length)
			{
				return false;
			}
			if (flag3)
			{
				_0023_003DzT4na_9HtOkWw(_0023_003Dzq_00240BKhUirasG, segments6[0]);
				_0023_003DzU9kLWIu9nU0q.Add(segments6[0]);
				segments4[0] = ((Curve)segments4[0])._0023_003DzmGgqdRaHiXdg(segments6[0]);
				((TrimCurve)segments4[0]).originalSurface = trimCurve3.originalSurface;
				((TrimCurve)segments4[0]).FaceInfo = trimCurve3.FaceInfo;
				((TrimCurve)segments4[0]).endIp = startIp;
				((TrimCurve)segments4[0]).startIp = startIp2;
				_0023_003DzT4na_9HtOkWw(trimCurve3, segments4[0]);
				segments5[0] = ((Curve)segments5[0])._0023_003DzmGgqdRaHiXdg(segments6[0]);
				((TrimCurve)segments5[0]).originalSurface = trimCurve4.originalSurface;
				((TrimCurve)segments5[0]).FaceInfo = trimCurve4.FaceInfo;
				((TrimCurve)segments5[0]).endIp = startIp;
				((TrimCurve)segments5[0]).startIp = startIp2;
				_0023_003DzT4na_9HtOkWw(trimCurve4, segments5[0]);
				_0023_003Dz9zLwxmXkgFXY.Add(segments4[0]);
				_0023_003DzyyoeQznW8_efUHj_0024TQ_003D_003D.Add(segments5[0]);
			}
			if (flag4)
			{
				int num2 = segments6.Length - 1;
				segments6[num2].EdgeIndex = curve2.EdgeIndex;
				_0023_003DzT4na_9HtOkWw(_0023_003Dzq_00240BKhUirasG, segments6[num2]);
				_0023_003DzU9kLWIu9nU0q.Add(segments6[num2]);
				segments4[num2] = ((Curve)segments4[num2])._0023_003DzmGgqdRaHiXdg(segments6[num2]);
				((TrimCurve)segments4[num2]).originalSurface = trimCurve3.originalSurface;
				((TrimCurve)segments4[num2]).FaceInfo = trimCurve3.FaceInfo;
				((TrimCurve)segments4[num2]).endIp = endIp2;
				((TrimCurve)segments4[num2]).startIp = endIp;
				_0023_003DzT4na_9HtOkWw(trimCurve3, segments4[num2]);
				segments5[num2] = ((Curve)segments5[num2])._0023_003DzmGgqdRaHiXdg(segments6[num2]);
				((TrimCurve)segments5[num2]).originalSurface = trimCurve4.originalSurface;
				((TrimCurve)segments5[num2]).FaceInfo = trimCurve4.FaceInfo;
				((TrimCurve)segments5[num2]).endIp = endIp2;
				((TrimCurve)segments5[num2]).startIp = endIp;
				_0023_003DzT4na_9HtOkWw(trimCurve4, segments5[num2]);
				_0023_003Dz9zLwxmXkgFXY.Add(segments4[num2]);
				_0023_003DzyyoeQznW8_efUHj_0024TQ_003D_003D.Add(segments5[num2]);
			}
		}
		else
		{
			_0023_003DzU9kLWIu9nU0q.Add(_0023_003Dzq_00240BKhUirasG);
			_0023_003Dz9zLwxmXkgFXY.Add(_0023_003DzB9SXqllpeTK4);
			_0023_003DzyyoeQznW8_efUHj_0024TQ_003D_003D.Add(_0023_003DzOZC6CD485ZNl);
		}
		return true;
	}

	private static void _0023_003DzT4na_9HtOkWw(object _0023_003Dzb7SPTpc_003D, object _0023_003Dzw_E1nLs_003D)
	{
		if (_0023_003Dzb7SPTpc_003D is ICurve)
		{
			((ICurve)_0023_003Dzw_E1nLs_003D).EdgeIndex = ((ICurve)_0023_003Dzb7SPTpc_003D).EdgeIndex;
			if (_0023_003Dzw_E1nLs_003D is Curve)
			{
				((Curve)_0023_003Dzw_E1nLs_003D).FromBooleanIntersection = ((Curve)_0023_003Dzb7SPTpc_003D).FromBooleanIntersection;
				((Curve)_0023_003Dzw_E1nLs_003D).onTangentType = ((Curve)_0023_003Dzb7SPTpc_003D).onTangentType;
				((Curve)_0023_003Dzw_E1nLs_003D).onTangentFaces = ((Curve)_0023_003Dzb7SPTpc_003D).onTangentFaces;
			}
		}
		else if (_0023_003Dzb7SPTpc_003D is Face)
		{
			((Face)_0023_003Dzw_E1nLs_003D).Visited = ((Face)_0023_003Dzb7SPTpc_003D).Visited;
			((Face)_0023_003Dzw_E1nLs_003D).hasEdgesToSplit = ((Face)_0023_003Dzb7SPTpc_003D).hasEdgesToSplit;
			((Face)_0023_003Dzw_E1nLs_003D).tangentFacesIndices = ((Face)_0023_003Dzb7SPTpc_003D).tangentFacesIndices;
			((Face)_0023_003Dzw_E1nLs_003D).tangentFacesType = ((Face)_0023_003Dzb7SPTpc_003D).tangentFacesType;
			((Face)_0023_003Dzw_E1nLs_003D).planeAlreadySet = ((Face)_0023_003Dzb7SPTpc_003D).planeAlreadySet;
			((Face)_0023_003Dzw_E1nLs_003D).plane = ((Face)_0023_003Dzb7SPTpc_003D).plane;
		}
	}

	public ICurve[] Section(Plane pln, double tol)
	{
		Plane _0023_003Dzpyw2kZk_003D = (Plane)pln.Clone();
		ICurve[] _0023_003DzvAopSzLGqCc;
		ICurve[] _0023_003DzxO_0024dwgyFkvCa;
		List<ICurve> _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D = _0023_003DzKK3pUYhqE_002427(null, _0023_003Dzpyw2kZk_003D, _0023_003DzOVP5EDBXMxbE: false, out _0023_003DzvAopSzLGqCc, out _0023_003DzxO_0024dwgyFkvCa).ToList();
		List<ICurve> _0023_003DzAlrB2OA_003D = _0023_003DzvAopSzLGqCc.ToList();
		List<ICurve> _0023_003DzAUP8SdQ_003D = _0023_003DzxO_0024dwgyFkvCa.ToList();
		return _0023_003DzgU5PpD8SBDyjWzoG0TiwGAo_003D(_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D, ref _0023_003DzAlrB2OA_003D, ref _0023_003DzAUP8SdQ_003D, _rebuildTol);
	}

	public ICurve[] IntersectWith(Surface surface)
	{
		ICurve[] _0023_003DzvAopSzLGqCc;
		ICurve[] _0023_003DzxO_0024dwgyFkvCa;
		List<ICurve> _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D = _0023_003DzKK3pUYhqE_002427(surface, null, _0023_003DzOVP5EDBXMxbE: false, out _0023_003DzvAopSzLGqCc, out _0023_003DzxO_0024dwgyFkvCa).ToList();
		List<ICurve> _0023_003DzAlrB2OA_003D = _0023_003DzvAopSzLGqCc.ToList();
		List<ICurve> _0023_003DzAUP8SdQ_003D = _0023_003DzxO_0024dwgyFkvCa.ToList();
		return _0023_003DzgU5PpD8SBDyjWzoG0TiwGAo_003D(_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D, ref _0023_003DzAlrB2OA_003D, ref _0023_003DzAUP8SdQ_003D, _rebuildTol);
	}

	public Point3D[] IntersectWith(ICurve curve, bool enableBrepBorder = false)
	{
		List<Point3D> list = new List<Point3D>();
		Face[] faces = _faces;
		for (int i = 0; i < faces.Length; i++)
		{
			faces[i]._0023_003DzGKZuR_4q838u(curve, list, enableBrepBorder);
		}
		Face[][] inners = _inners;
		for (int i = 0; i < inners.Length; i++)
		{
			faces = inners[i];
			for (int j = 0; j < faces.Length; j++)
			{
				faces[j]._0023_003DzGKZuR_4q838u(curve, list, enableBrepBorder);
			}
		}
		return list.ToArray();
	}

	private ICurve[] _0023_003DzKK3pUYhqE_002427(Surface _0023_003DzF7GfYSI_003D, Plane _0023_003Dzpyw2kZk_003D, bool _0023_003DzOVP5EDBXMxbE, out ICurve[] _0023_003DzvAopSzLGqCc5, out ICurve[] _0023_003DzxO_0024dwgyFkvCa)
	{
		_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2 = new _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D();
		_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzopRx0_MBcTQs = this;
		ICurve[] array = new TrimCurve[0];
		_0023_003DzvAopSzLGqCc5 = (_0023_003DzxO_0024dwgyFkvCa = array);
		Rebuild(0.0, soft: true);
		Point3D _0023_003DzDPcjoBJLcqli;
		Point3D _0023_003Dz_0024N_0024yKptW9BoC;
		if (localMin != null)
		{
			_0023_003DzDPcjoBJLcqli = localMin;
			_0023_003Dz_0024N_0024yKptW9BoC = localMax;
		}
		else
		{
			_0023_003DzQCWJbpjMGLxZWfwMCQ_003D_003D(out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC, _0023_003Dz7cP1pZCb1hQy: true);
		}
		if (_0023_003DzF7GfYSI_003D == null)
		{
			_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D = Surface._0023_003DziDGe5xzc5KLyQpPYDk5PyHY_003D(_0023_003Dzpyw2kZk_003D, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
		}
		else
		{
			_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D = _0023_003DzF7GfYSI_003D;
		}
		Size3D size3D = new Size3D(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
		_0023_003Dzm46XtFoc4yjkLe4U6I6ZJuCit_0024eyqU3llw_003D_003D(_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D, ref _0023_003Dzpyw2kZk_003D);
		_0023_003DzoYtnM6mQQkChQQZjk8nAMKY_003D(_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D, _0023_003Dzpyw2kZk_003D);
		Surface surf = (Surface)_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D.Clone();
		Surface._0023_003Dz2u_3iw7LP_ic _0023_003Dz2u_3iw7LP_ic = default(Surface._0023_003Dz2u_3iw7LP_ic);
		Surface.Reparametrize(surf, out _0023_003Dz2u_3iw7LP_ic._0023_003Dz2AZ_kpw_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dza2Pq9PQ_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
		surf = _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
		surf.ControlBoundingBox(out _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzCFK21E0_003D, out _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzewZCcZQ_003D);
		Plane plane = ((_0023_003Dzpyw2kZk_003D == null) ? null : ((Plane)_0023_003Dzpyw2kZk_003D.Clone()));
		_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzPsHFxZf6VuL6 = new Vector3D(_0023_003DzDPcjoBJLcqli.X, _0023_003DzDPcjoBJLcqli.Y, _0023_003DzDPcjoBJLcqli.Z);
		if (plane != null)
		{
			plane.TransformBy(new Translation(-1.0 * _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzPsHFxZf6VuL6));
		}
		Surface._0023_003DzBz88rbCTqJ_K(surf, -1.0 * _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzPsHFxZf6VuL6);
		_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D = surf;
		_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzIO8vCOqMZAPN = _0023_003DzjwHfLWwaRklt_0024sgoShcqXfTofnfX(_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzPsHFxZf6VuL6, _0023_003Dzb_oSv5xIJjDFBiUXNjPZ_Qo_003D: true, _0023_003Dz16MJo1JQ0jsITRzr5A_003D_003D: true);
		_0023_003Dzn7CZziZi_8snx0i8Sg_003D_003D();
		_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D._0023_003Dzn7CZziZi_8snx0i8Sg_003D_003D();
		if (!Utility.DoOverlapOrTouch(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC, _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzCFK21E0_003D, _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzewZCcZQ_003D, size3D.Diagonal) && !Utility.DoOverlapOrTouch(ConvexHull, _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D.ConvexHull))
		{
			return new ICurve[0];
		}
		_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D.ControlBoundingBox(out _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzCFK21E0_003D, out _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzewZCcZQ_003D);
		HashSet<Tuple<int, int>> hashSet = new HashSet<Tuple<int, int>>();
		List<ICurve> list = new List<ICurve>();
		List<ICurve> list2 = new List<ICurve>();
		List<ICurve> list3 = new List<ICurve>();
		for (int i = 0; i < _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzIO8vCOqMZAPN.GetLength(0); i++)
		{
			for (int j = 0; j < _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzIO8vCOqMZAPN[i].GetLength(0); j++)
			{
				for (int k = 0; k < _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzIO8vCOqMZAPN[i][j].Length; k++)
				{
					Surface _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D = _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzIO8vCOqMZAPN[i][j][k]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
					Face obj = ((i == 0) ? _faces[j] : _inners[i - 1][j]);
					if (_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.shrunk == null)
					{
						_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D._0023_003DzIQv8kUn9rJJPHOmQIg_003D_003D();
					}
					_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.shrunk.ControlBoundingBox(out var min, out var max);
					Surface surface = ((_0023_003DzF7GfYSI_003D != null || !(plane != null)) ? _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D : Surface._0023_003DziDGe5xzc5KLyQpPYDk5PyHY_003D(plane, min, max));
					bool flag = true;
					if (obj.tangentFacesIndices != null)
					{
						hashSet.Add(new Tuple<int, int>(j, -1));
					}
					else
					{
						if (_0023_003DzOVP5EDBXMxbE)
						{
							continue;
						}
						ICurve[] _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D = new ICurve[0];
						ICurve[] _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO = new ICurve[0];
						surface.ControlBoundingBox(out var min2, out var max2);
						Point3D intersMin;
						Point3D intersMax;
						double _0023_003Dzm0CYiiE_003D = Utility.IntersectionBox(min, max, min2, max2, out intersMin, out intersMax).Diagonal * Utility._0023_003DzxhnLabVjXjPg;
						if (surface is PlanarSurface)
						{
							flag = Surface._0023_003DzG7qias9QKP9i(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, surface, plane, _0023_003Dzo3ZHoX_0024NyVsaNh8SBg_003D_003D: false, _0023_003Dzm0CYiiE_003D, out _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D, out _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO);
						}
						else if (_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D is PlanarSurface)
						{
							flag = Surface._0023_003DzG7qias9QKP9i(surface, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, ((PlanarSurface)_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D).Plane, _0023_003Dzo3ZHoX_0024NyVsaNh8SBg_003D_003D: true, _0023_003Dzm0CYiiE_003D, out _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO, out _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D);
						}
						PlanarSurface _0023_003DzaR3A1ks_003D = null;
						PlanarSurface _0023_003DzaR3A1ks_003D2 = null;
						bool flag2 = false;
						bool flag3 = false;
						Transformation _0023_003DzNDQ_E88_003D = null;
						Transformation _0023_003DzNDQ_E88_003D2 = null;
						if (flag)
						{
							flag2 = _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D is TabulatedSurface && _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D._0023_003Dz_9WsAykzZ67lManT4w_003D_003D(out _0023_003DzaR3A1ks_003D, out _0023_003DzNDQ_E88_003D);
							flag3 = _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D is TabulatedSurface && _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D._0023_003Dz_9WsAykzZ67lManT4w_003D_003D(out _0023_003DzaR3A1ks_003D2, out _0023_003DzNDQ_E88_003D2);
							if (flag2 && flag3)
							{
								flag = Surface._0023_003DzG7qias9QKP9i(_0023_003DzaR3A1ks_003D2, _0023_003DzaR3A1ks_003D, _0023_003DzaR3A1ks_003D.Plane, _0023_003Dzo3ZHoX_0024NyVsaNh8SBg_003D_003D: true, _0023_003Dzm0CYiiE_003D, out _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO, out _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D);
							}
							else if (flag2)
							{
								flag = Surface._0023_003DzG7qias9QKP9i(_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D, _0023_003DzaR3A1ks_003D, _0023_003DzaR3A1ks_003D.Plane, _0023_003Dzo3ZHoX_0024NyVsaNh8SBg_003D_003D: true, _0023_003Dzm0CYiiE_003D, out _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO, out _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D);
							}
							else if (flag3)
							{
								flag = Surface._0023_003DzG7qias9QKP9i(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzaR3A1ks_003D2, _0023_003DzaR3A1ks_003D2.Plane, _0023_003Dzo3ZHoX_0024NyVsaNh8SBg_003D_003D: false, _0023_003Dzm0CYiiE_003D, out _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D, out _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO);
							}
						}
						if (flag)
						{
							continue;
						}
						hashSet.Add(new Tuple<int, int>(j, -1));
						if (_0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D.Length == 0)
						{
							continue;
						}
						for (int l = 0; l < _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D.Length; l++)
						{
							TrimCurve trimCurve = (TrimCurve)_0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D[l];
							TrimCurve trimCurve2 = (TrimCurve)_0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO[l];
							ICurve curve = (ICurve)(Entity)trimCurve.Edge;
							if (trimCurve != null && trimCurve2 != null)
							{
								if (_0023_003DzNDQ_E88_003D != null)
								{
									_0023_003DzNDQ_E88_003D.Invert();
									trimCurve.TransformBy(_0023_003DzNDQ_E88_003D);
								}
								trimCurve.originalSurface = _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
								if (_0023_003DzNDQ_E88_003D2 != null)
								{
									_0023_003DzNDQ_E88_003D2.Invert();
									trimCurve2.TransformBy(_0023_003DzNDQ_E88_003D2);
								}
								trimCurve2.originalSurface = _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D;
								trimCurve.FaceInfo = new _0023_003DzKfMGQQU_003D
								{
									_0023_003DzLJVtPYc_003D = j,
									_0023_003DzVYqYlD94dR8lRmB4iw_003D_003D = k,
									_0023_003DzBLJ2fdI_003D = l
								};
								trimCurve.startIp = new InitialPoint(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z, trimCurve.StartPoint.X, trimCurve.StartPoint.Y, trimCurve2.StartPoint.X, trimCurve2.StartPoint.Y);
								trimCurve.endIp = new InitialPoint(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z, trimCurve.EndPoint.X, trimCurve.EndPoint.Y, trimCurve2.EndPoint.X, trimCurve2.EndPoint.Y);
								trimCurve2.startIp = new InitialPoint(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z, trimCurve.StartPoint.X, trimCurve.StartPoint.Y, trimCurve2.StartPoint.X, trimCurve2.StartPoint.Y);
								trimCurve2.endIp = new InitialPoint(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z, trimCurve.EndPoint.X, trimCurve.EndPoint.Y, trimCurve2.EndPoint.X, trimCurve2.EndPoint.Y);
								_0023_003DzI9aD8Vo8tHlTXfkrMB2he1A_003D(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, j, -1, trimCurve, trimCurve2, _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D, _0023_003Dzb9U1KHmIZGGP: false, _0023_003Dzf5uydyTGDFr_0024: true);
								list.Add(curve);
								list2.Add(trimCurve);
								list3.Add(trimCurve2);
							}
						}
					}
				}
			}
		}
		List<ICurve> list4 = new List<ICurve>();
		_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzXs1mtPVIqhDmHRZf5w_003D_003D = new List<ICurve>();
		List<ICurve> list5 = new List<ICurve>();
		List<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>> _0023_003Dzr1JqptnFernPnT_CHSjJH23BqG0s = new List<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>>();
		_0023_003Dz3CnW_YfpJsRK(_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D, null, -1, _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzIO8vCOqMZAPN, _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzPsHFxZf6VuL6, out var _0023_003DzTmhgNwFiSUUdfHgPqA_003D_003D, _0023_003Dzjm4D0qYZNBEL: true, _0023_003DzTymA54q3SWU7: false, hashSet, -1, -1, _0023_003Dz2u_3iw7LP_ic._0023_003DzZ8DVrAfDB6VE7Gu9_0024Jl7_0024Dg_003D, _0023_003Dz2u_3iw7LP_ic._0023_003Dz4wZe_0024Xg_003D, list4, _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzXs1mtPVIqhDmHRZf5w_003D_003D, list5, _0023_003Dzr1JqptnFernPnT_CHSjJH23BqG0s, null);
		_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DziytJKSvyswPuISGO_0024Q_003D_003D = _0023_003DzTmhgNwFiSUUdfHgPqA_003D_003D.ToArray();
		int num = _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DziytJKSvyswPuISGO_0024Q_003D_003D.Length;
		if (num == 0 && list.Count == 0)
		{
			return new ICurve[0];
		}
		_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzpIZC_0024x5EiUBN = new List<ICurve>[num];
		_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzK2kANxBH211q = new List<ICurve>[num];
		_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzVixMwhaCnCpx = new List<ICurve>[num];
		if (num != 0)
		{
			for (int m = 0; m < _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DziytJKSvyswPuISGO_0024Q_003D_003D.Length; m++)
			{
				KeyValuePair<_0023_003DzKfMGQQU_003D, List<Point3D>> keyValuePair = _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DziytJKSvyswPuISGO_0024Q_003D_003D[m];
				List<Point3D> value = keyValuePair.Value;
				_0023_003DzKfMGQQU_003D key = keyValuePair.Key;
				Surface _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2 = _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzIO8vCOqMZAPN[key._0023_003DzBLJ2fdI_003D][key._0023_003DzLJVtPYc_003D][key._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
				AnalyticSurf surface2 = Faces[key._0023_003DzLJVtPYc_003D].Surface;
				Surface _0023_003Dz4wZe_0024Xg_003D = _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzIO8vCOqMZAPN[key._0023_003DzBLJ2fdI_003D][key._0023_003DzLJVtPYc_003D][key._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D]._0023_003Dz4wZe_0024Xg_003D;
				_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2.ControlBoundingBox(out var min3, out var max3);
				_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzpIZC_0024x5EiUBN[m] = new List<ICurve>();
				_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzK2kANxBH211q[m] = new List<ICurve>();
				_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzVixMwhaCnCpx[m] = new List<ICurve>();
				Point3D intersMin2;
				Point3D intersMax2;
				double diagonal = Utility.IntersectionBox(min3, max3, _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzCFK21E0_003D, _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzewZCcZQ_003D, out intersMin2, out intersMax2).Diagonal;
				Face face = ((key._0023_003DzBLJ2fdI_003D == 0) ? _faces[key._0023_003DzLJVtPYc_003D] : Inners[key._0023_003DzBLJ2fdI_003D - 1][key._0023_003DzLJVtPYc_003D]);
				Plane plane2 = null;
				if (face.planeAlreadySet)
				{
					plane2 = face.plane;
				}
				else
				{
					if (_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2.IsPlanar(diagonal * Utility._0023_003DzheSR8QM7q9ya, out plane2))
					{
						face.plane = plane2;
					}
					face.planeAlreadySet = true;
				}
				Surface._0023_003Dz40xvinZhV3PNYJwPCg_003D_003D(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D, plane2, _rebuildTol, value, diagonal, _0023_003Dz4wZe_0024Xg_003D, surface2, _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzPsHFxZf6VuL6);
				if (value.Count > 0)
				{
					List<Point3D> list6 = new List<Point3D>();
					_0023_003Dz2HQ0TbeXoMdaW6Sxxg_003D_003D(value, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzFmiij5k_003D, diagonal, _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzPsHFxZf6VuL6, null, list6);
					_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DziytJKSvyswPuISGO_0024Q_003D_003D[m] = new KeyValuePair<_0023_003DzKfMGQQU_003D, List<Point3D>>(keyValuePair.Key, list6);
				}
			}
			regenType regenType2 = RegenMode;
			RegenMode = regenType.RegenAndCompile;
			Parallel.For(0, num, _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003Dzg2iOjsrja8Xs8nhaYw_003D_003D);
			RegenMode = regenType2;
		}
		List<ICurve> list7 = new List<ICurve>();
		List<ICurve> list8 = new List<ICurve>();
		List<ICurve> list9 = new List<ICurve>();
		Transformation xform = new Translation(_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzPsHFxZf6VuL6);
		for (int n = 0; n < list.Count; n++)
		{
			((Entity)((TrimCurve)list2[n]).Edge).TransformBy(xform);
			((Entity)((TrimCurve)list3[n]).Edge).TransformBy(xform);
			((TrimCurve)list3[n]).originalSurface.TransformBy(xform);
			((TrimCurve)list3[n]).originalSurface.TransformBy(xform);
		}
		list7.AddRange(list);
		list8.AddRange(list2);
		list9.AddRange(list3);
		for (int num2 = 0; num2 < list4.Count; num2++)
		{
			((Entity)list4[num2]).TransformBy(xform);
			((Entity)((TrimCurve)_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzXs1mtPVIqhDmHRZf5w_003D_003D[num2]).Edge).TransformBy(xform);
			((Entity)((TrimCurve)list5[num2]).Edge).TransformBy(xform);
		}
		list7.AddRange(list4);
		list8.AddRange(_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzXs1mtPVIqhDmHRZf5w_003D_003D);
		list9.AddRange(list5);
		for (int num3 = 0; num3 < _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzpIZC_0024x5EiUBN.Length; num3++)
		{
			if (_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzpIZC_0024x5EiUBN[num3] == null)
			{
				continue;
			}
			for (int num4 = 0; num4 < _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzpIZC_0024x5EiUBN[num3].Count; num4++)
			{
				list7.Add(_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzpIZC_0024x5EiUBN[num3][num4]);
				if (_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzK2kANxBH211q[num3] != null && _0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzK2kANxBH211q[num3].Count > 0)
				{
					TrimCurve trimCurve3 = (TrimCurve)_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzK2kANxBH211q[num3][num4];
					TrimCurve trimCurve4 = (TrimCurve)_0023_003DzzhQ1JihXYGSxR9FxtjxgZiQ_003D2._0023_003DzVixMwhaCnCpx[num3][num4];
					((Entity)trimCurve3.Edge).TransformBy(xform);
					((Entity)trimCurve4.Edge).TransformBy(xform);
					trimCurve3.originalSurface.TransformBy(xform);
					trimCurve4.originalSurface.TransformBy(xform);
					list8.Add(trimCurve3);
					list9.Add(trimCurve4);
				}
			}
		}
		if (list7.Count > 0)
		{
			if (list8.Count == list9.Count)
			{
				_0023_003DzvAopSzLGqCc5 = list8.ToArray();
				_0023_003DzxO_0024dwgyFkvCa = list9.ToArray();
			}
			return list7.ToArray();
		}
		return new ICurve[0];
	}

	private static ICurve[] _0023_003DzgU5PpD8SBDyjWzoG0TiwGAo_003D(List<ICurve> _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D, ref List<ICurve> _0023_003DzAlrB2OA_003D, ref List<ICurve> _0023_003DzAUP8SdQ_003D, double _0023_003DzGvLz4uh736QEMEZuVg_003D_003D)
	{
		if (_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.Count > 0)
		{
			_0023_003Dz6KMeGlIwa_ELnAyOOa4Yu6o_003D(ref _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D, ref _0023_003DzAlrB2OA_003D, ref _0023_003DzAUP8SdQ_003D, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D);
			List<List<ICurve>> list = Utility._0023_003Dzx1_VB8cQKrRRV2_0024w7g_003D_003D(_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D: false, _0023_003Dzp9LPrpP9wSDR: false);
			ICurve[] array = new ICurve[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				List<ICurve> list2 = list[i];
				if (list2.Count == 1)
				{
					array[i] = list2[0];
					continue;
				}
				List<ICurve> list3 = new List<ICurve>();
				foreach (ICurve item2 in list2)
				{
					ICurve[] individualCurves = item2.GetIndividualCurves();
					foreach (ICurve item in individualCurves)
					{
						list3.Add(item);
					}
				}
				array[i] = new CompositeCurve(list3, sortAndOrient: false);
			}
			return array;
		}
		return new ICurve[0];
	}

	private static bool _0023_003DzBbuBZ3952ZPP(ICurve _0023_003DzLNKybEs_003D, Surface _0023_003DzHit7vU4_003D, Surface _0023_003DzFmiij5k_003D, double _0023_003DzGvLz4uh736QEMEZuVg_003D_003D)
	{
		bool result = false;
		if (_0023_003DzLNKybEs_003D != null)
		{
			_0023_003DzHit7vU4_003D.PointInversion(_0023_003DzLNKybEs_003D.StartPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out double u, out double v);
			_0023_003DzFmiij5k_003D.PointInversion(_0023_003DzLNKybEs_003D.StartPoint, _0023_003DzGvLz4uh736QEMEZuVg_003D_003D, out double u2, out double v2);
			Vector3D a = _0023_003DzHit7vU4_003D.NormalAt(u, v);
			Vector3D b = _0023_003DzFmiij5k_003D.NormalAt(u2, v2);
			Vector3D vector3D = Vector3D.Cross(a, b);
			vector3D.Normalize();
			_0023_003DzLNKybEs_003D.StartTangent.Normalize();
			result = Vector3D.Dot(vector3D, _0023_003DzLNKybEs_003D.StartTangent) < Utility._0023_003DzheSR8QM7q9ya;
		}
		return result;
	}

	private void _0023_003Dz2HQ0TbeXoMdaW6Sxxg_003D_003D(List<Point3D> _0023_003DzTyB0NW0_003D, Surface _0023_003DzHit7vU4_003D, Surface _0023_003DzFmiij5k_003D, double _0023_003DzccAR5G0_003D, Vector3D _0023_003DzPsHFxZf6VuL6, bool? _0023_003Dzoery_WzWxkVl, List<Point3D> _0023_003DzK4k_0024wmMbw7C81FS_bQ_003D_003D)
	{
		List<Point3D> _0023_003Dz1gbJndw_003D = new List<Point3D>();
		for (int i = 0; i < _0023_003DzTyB0NW0_003D.Count; i++)
		{
			InitialPoint initialPoint = (InitialPoint)_0023_003DzTyB0NW0_003D[i];
			bool _0023_003DzdqlFMyo_XyDZ = true;
			if (initialPoint._0023_003DzL8NvYU0_003D > -1)
			{
				Edge edge = Edges[initialPoint._0023_003DzL8NvYU0_003D];
				_0023_003DzdqlFMyo_XyDZ = edge.Parents.Length > 1 && edge.Parents[0] == edge.Parents[1];
			}
			bool flag = (_0023_003Dzoery_WzWxkVl.HasValue ? _0023_003Dzoery_WzWxkVl.Value : (!initialPoint._0023_003DzSobLr5DEOQoE));
			if (!initialPoint._0023_003DzlWOnyq_0024UKjqEXiRxzQ_003D_003D)
			{
				bool _0023_003DzUL0EnEkkm3iQ = (flag ? (Surface._0023_003DzqXlnzeBE597qWuJw1A_003D_003D(initialPoint, _0023_003DzHit7vU4_003D, _0023_003DzFmiij5k_003D, _0023_003DzccAR5G0_003D) == (Surface._0023_003DzD0g28q26sEFtlchSuw_003D_003D)5) : (Surface._0023_003DzhnC3thPzhntEomwmJQ_003D_003D(initialPoint, _0023_003DzHit7vU4_003D, _0023_003DzFmiij5k_003D, _0023_003DzccAR5G0_003D) == (Surface._0023_003DzD0g28q26sEFtlchSuw_003D_003D)5));
				Surface._0023_003Dz_0024ags0qA3kCGK(initialPoint, _0023_003DzHit7vU4_003D, _0023_003DzFmiij5k_003D, _0023_003Dz1gbJndw_003D, _0023_003DzccAR5G0_003D, flag, _0023_003DzUL0EnEkkm3iQ, _0023_003DzdqlFMyo_XyDZ);
				initialPoint._0023_003DzlWOnyq_0024UKjqEXiRxzQ_003D_003D = true;
			}
			else
			{
				Surface._0023_003Dz_0024ags0qA3kCGK(initialPoint, _0023_003DzHit7vU4_003D, _0023_003DzFmiij5k_003D, _0023_003Dz1gbJndw_003D, _0023_003DzccAR5G0_003D, flag, _0023_003DzUL0EnEkkm3iQ: true, _0023_003DzdqlFMyo_XyDZ);
			}
			Surface._0023_003Dz0IbGMrVFIc12P2nxbQ_003D_003D(initialPoint, _0023_003DzHit7vU4_003D, _0023_003DzmNpevGU_003D: true, _0023_003DzccAR5G0_003D);
			Surface._0023_003Dz0IbGMrVFIc12P2nxbQ_003D_003D(initialPoint, _0023_003DzFmiij5k_003D, _0023_003DzmNpevGU_003D: false, _0023_003DzccAR5G0_003D);
		}
		Surface._0023_003DzUyz6WNY0b_hYSjilnQ_003D_003D(_0023_003DzHit7vU4_003D, _0023_003DzFmiij5k_003D, _0023_003DzccAR5G0_003D, _0023_003Dz1gbJndw_003D, _0023_003DzPsHFxZf6VuL6, _0023_003DzXj5EmoITPwYy: true, ref _0023_003DzK4k_0024wmMbw7C81FS_bQ_003D_003D);
	}

	private void _0023_003DzB31hWm4MZVCD(InitialPoint _0023_003DzqoHxF0k_003D, Point3D _0023_003DzXHWalrDkZYCI6o4Fng_003D_003D, Surface _0023_003DzFmiij5k_003D, Dictionary<_0023_003DzKfMGQQU_003D, List<Point3D>> _0023_003DzpOf_GHqPFitB, bool _0023_003DzvEgxrcQTlXX6mOjMuw_003D_003D, int _0023_003Dzfe2zeQMumw_4)
	{
		if (Edges[_0023_003DzqoHxF0k_003D._0023_003DzL8NvYU0_003D].Parents.Length < 2)
		{
			return;
		}
		int num = ((_0023_003Dzfe2zeQMumw_4 == Edges[_0023_003DzqoHxF0k_003D._0023_003DzL8NvYU0_003D].Parents[0]) ? Edges[_0023_003DzqoHxF0k_003D._0023_003DzL8NvYU0_003D].Parents[1] : Edges[_0023_003DzqoHxF0k_003D._0023_003DzL8NvYU0_003D].Parents[0]);
		Point3D min;
		Point3D max;
		if (_0023_003DzqoHxF0k_003D._0023_003DzutFG6gdoV0Ic != null)
		{
			_0023_003DzqoHxF0k_003D._0023_003DzutFG6gdoV0Ic.ControlBoundingBox(out min, out max);
		}
		else
		{
			_0023_003DzFmiij5k_003D.ControlBoundingBox(out min, out max);
		}
		double num2 = new Size3D(min, max).Diagonal * Utility._0023_003DzheSR8QM7q9ya;
		bool flag = false;
		InitialPoint initialPoint = null;
		foreach (KeyValuePair<_0023_003DzKfMGQQU_003D, List<Point3D>> item in _0023_003DzpOf_GHqPFitB)
		{
			if (item.Key._0023_003DzLJVtPYc_003D != num)
			{
				continue;
			}
			foreach (InitialPoint item2 in item.Value)
			{
				if (item2._0023_003DzL8NvYU0_003D == _0023_003DzqoHxF0k_003D._0023_003DzL8NvYU0_003D && item2.DistanceTo(_0023_003DzXHWalrDkZYCI6o4Fng_003D_003D) < num2 && !item2._0023_003DzlWOnyq_0024UKjqEXiRxzQ_003D_003D)
				{
					initialPoint = item2;
					flag = true;
					break;
				}
			}
		}
		if (flag)
		{
			Surface startPointCurveOwner = initialPoint.startPointCurveOwner;
			startPointCurveOwner.Project(_0023_003DzqoHxF0k_003D, out var u, out var v);
			initialPoint._0023_003DzlWOnyq_0024UKjqEXiRxzQ_003D_003D = true;
			Vector3D[,] array = startPointCurveOwner.Evaluate(u, v, 1);
			Vector3D vector3D = array[1, 0];
			Vector3D vector3D2 = array[0, 1];
			if (_0023_003DzvEgxrcQTlXX6mOjMuw_003D_003D)
			{
				Vector3D[,] array2 = _0023_003DzFmiij5k_003D.Evaluate(_0023_003DzqoHxF0k_003D.u, _0023_003DzqoHxF0k_003D.v, 1);
				Vector3D _0023_003DzQ6Gbqkk_003D = array2[1, 0];
				Vector3D _0023_003DzYmM1v24_003D = array2[0, 1];
				Surface._0023_003Dz81tHaSh91U339gSq_0024g_003D_003D(initialPoint, _0023_003DzqoHxF0k_003D.u, _0023_003DzqoHxF0k_003D.v, u, v, null, 1.0, _0023_003DzqoHxF0k_003D, _0023_003DzQ6Gbqkk_003D, _0023_003DzYmM1v24_003D, vector3D, vector3D2);
			}
			else
			{
				Vector3D[,] array3 = _0023_003DzFmiij5k_003D.Evaluate(_0023_003DzqoHxF0k_003D.s, _0023_003DzqoHxF0k_003D.t, 1);
				Vector3D _0023_003DzQ6Gbqkk_003D = array3[1, 0];
				Vector3D _0023_003DzYmM1v24_003D = array3[0, 1];
				Surface._0023_003Dz81tHaSh91U339gSq_0024g_003D_003D(initialPoint, u, v, _0023_003DzqoHxF0k_003D.s, _0023_003DzqoHxF0k_003D.t, null, 1.0, _0023_003DzqoHxF0k_003D, vector3D, vector3D2, _0023_003DzQ6Gbqkk_003D, _0023_003DzYmM1v24_003D);
			}
		}
	}

	private void _0023_003Dz3CnW_YfpJsRK(Surface _0023_003DzF7GfYSI_003D, Brep _0023_003DzkoMzW4RvquFL, int _0023_003DzWGK64IQLDyWN, Surface._0023_003Dz2u_3iw7LP_ic[][][] _0023_003DzVu89R1DJ2wENgCyqdyx6Ymo_003D, Vector3D _0023_003DzPsHFxZf6VuL6, out Dictionary<_0023_003DzKfMGQQU_003D, List<Point3D>> _0023_003DzTmhgNwFiSUUdfHgPqA_003D_003D, bool _0023_003Dzjm4D0qYZNBEL, bool _0023_003DzTymA54q3SWU7, HashSet<Tuple<int, int>> _0023_003Dz7b1_EkFXtnHn, int _0023_003DzouKQRsP5tcPXubQriQ_003D_003D, int _0023_003DzRLCcpW4_003D, AnalyticSurf _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D, Surface _0023_003Dz4wZe_0024Xg_003D, List<ICurve> _0023_003DzeJW3Kznumb_0024KMmTj0g_003D_003D, List<ICurve> _0023_003Dzknqtwd_00246VMEYdDlz_00249g8qcY_003D, List<ICurve> _0023_003Dz8VfEbJmiWwJ4FAEd5bmP__g_003D, List<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>> _0023_003Dzr1JqptnFernPnT_CHSjJH23BqG0s, HashSet<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>> _0023_003Dzj0U7nuNL7GBJ)
	{
		_0023_003DzTmhgNwFiSUUdfHgPqA_003D_003D = new Dictionary<_0023_003DzKfMGQQU_003D, List<Point3D>>();
		bool flag = false;
		Plane plane = null;
		if (_0023_003DzF7GfYSI_003D.shrunk == null)
		{
			_0023_003DzF7GfYSI_003D._0023_003DzIQv8kUn9rJJPHOmQIg_003D_003D();
		}
		Point3D min;
		Point3D max;
		if (_0023_003DzF7GfYSI_003D.shrunk.BoxMin != null)
		{
			min = _0023_003DzF7GfYSI_003D.shrunk.BoxMin;
			max = _0023_003DzF7GfYSI_003D.shrunk.BoxMax;
		}
		else
		{
			_0023_003DzF7GfYSI_003D.shrunk.ControlBoundingBox(out min, out max);
			_0023_003DzF7GfYSI_003D.shrunk.localMin = min;
			_0023_003DzF7GfYSI_003D.shrunk.localMax = max;
		}
		double diagonal = new Size3D(min, max).Diagonal;
		double tol = diagonal * Utility._0023_003DzheSR8QM7q9ya;
		_ = diagonal / 500.0;
		if (_0023_003DzWGK64IQLDyWN > -1)
		{
			Face face = _0023_003DzkoMzW4RvquFL.Faces[_0023_003DzWGK64IQLDyWN];
			if (face.planeAlreadySet && face.plane != null)
			{
				plane = (Plane)face.plane.Clone();
				plane.Translate(-1.0 * _0023_003DzPsHFxZf6VuL6);
			}
			else if (!face.planeAlreadySet)
			{
				if (_0023_003DzF7GfYSI_003D.IsPlanar(tol, out plane))
				{
					face.plane = (Plane)plane.Clone();
					face.plane.Translate(_0023_003DzPsHFxZf6VuL6);
				}
				face.planeAlreadySet = true;
			}
			if (face.tangentFacesIndices != null)
			{
				flag = true;
			}
		}
		else if (_0023_003DzF7GfYSI_003D.IsPlanar(tol, out plane))
		{
			flag = true;
		}
		_0023_003Dzj4BwwHpJqX0aXcrqKxfpae8BS9rB8XpyPw_003D_003D _0023_003Dzj4BwwHpJqX0aXcrqKxfpae8BS9rB8XpyPw_003D_003D2 = new _0023_003Dzj4BwwHpJqX0aXcrqKxfpae8BS9rB8XpyPw_003D_003D();
		bool flag2 = false;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 1;
		for (int i = 0; i < Edges.Length; i++)
		{
			Edge edge = Edges[i];
			if (edge.Parents == null || edge.SplitStatus == SplitEdgeStatus.OnBothEdges)
			{
				continue;
			}
			int num5 = -1;
			if (_0023_003Dz7b1_EkFXtnHn != null)
			{
				Tuple<int, int> item = (_0023_003Dzjm4D0qYZNBEL ? new Tuple<int, int>(edge.Parents[0], _0023_003DzWGK64IQLDyWN) : new Tuple<int, int>(_0023_003DzWGK64IQLDyWN, edge.Parents[0]));
				bool flag3 = _0023_003Dz7b1_EkFXtnHn.Contains(item);
				bool flag4 = false;
				if (edge.Parents.Length == 2)
				{
					Tuple<int, int> item2 = (_0023_003Dzjm4D0qYZNBEL ? new Tuple<int, int>(edge.Parents[1], _0023_003DzWGK64IQLDyWN) : new Tuple<int, int>(_0023_003DzWGK64IQLDyWN, edge.Parents[1]));
					flag4 = _0023_003Dz7b1_EkFXtnHn.Contains(item2);
				}
				if (_0023_003DzTymA54q3SWU7)
				{
					if (flag3 || flag4)
					{
						continue;
					}
				}
				else
				{
					if (flag3 && flag4)
					{
						continue;
					}
					num5 = ((!flag3) ? (flag4 ? 1 : (-1)) : 0);
				}
			}
			flag2 = false;
			for (int j = 0; j < edge.Parents.Length; j++)
			{
				flag2 |= Faces[edge.Parents[j]].tangentFacesIndices != null;
			}
			if (flag)
			{
				bool flag5 = true;
				for (int k = 0; k < edge.Parents.Length; k++)
				{
					List<int> tangentFacesIndices = Faces[edge.Parents[k]].tangentFacesIndices;
					if (tangentFacesIndices != null)
					{
						for (int l = 0; l < tangentFacesIndices.Count; l++)
						{
							bool flag6 = tangentFacesIndices[l] == _0023_003DzWGK64IQLDyWN;
							flag5 = flag5 && !flag6;
						}
					}
				}
				if (!flag5)
				{
					continue;
				}
			}
			ICurve curve;
			if (_0023_003DzPsHFxZf6VuL6.IsZero)
			{
				curve = edge.Curve;
			}
			else
			{
				curve = (ICurve)edge.Curve.Clone();
				Transformation xform = Transformation.CreateTranslation(-1.0 * _0023_003DzPsHFxZf6VuL6);
				((Entity)curve).TransformBy(xform);
				if (((Entity)edge.Curve).Vertices != null)
				{
					((Entity)curve).Vertices = Utility.DeepCopy(((Entity)edge.Curve).Vertices);
					Point3D[] vertices = ((Entity)curve).Vertices;
					for (int m = 0; m < vertices.Length; m++)
					{
						vertices[m].TransformBy(xform);
					}
				}
			}
			Surface[] array = new Surface[_0023_003DzVu89R1DJ2wENgCyqdyx6Ymo_003D[edge.ShellIndex][edge.Parents[0]].Length];
			for (int n = 0; n < array.Length; n++)
			{
				Surface._0023_003Dz2u_3iw7LP_ic _0023_003Dz2u_3iw7LP_ic = _0023_003DzVu89R1DJ2wENgCyqdyx6Ymo_003D[edge.ShellIndex][edge.Parents[0]][n];
				if (_0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D == null)
				{
					Surface.Reparametrize(_0023_003Dz2u_3iw7LP_ic._0023_003Dz4wZe_0024Xg_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dz2AZ_kpw_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003Dza2Pq9PQ_003D, out _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
					_0023_003DzVu89R1DJ2wENgCyqdyx6Ymo_003D[edge.ShellIndex][edge.Parents[0]][n] = _0023_003Dz2u_3iw7LP_ic;
				}
				array[n] = _0023_003Dz2u_3iw7LP_ic._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
			}
			Surface[] array2 = new Surface[0];
			if (edge.Parents.Length > 1)
			{
				array2 = new Surface[_0023_003DzVu89R1DJ2wENgCyqdyx6Ymo_003D[edge.ShellIndex][edge.Parents[1]].Length];
				for (int num6 = 0; num6 < array2.Length; num6++)
				{
					Surface._0023_003Dz2u_3iw7LP_ic _0023_003Dz2u_3iw7LP_ic2 = _0023_003DzVu89R1DJ2wENgCyqdyx6Ymo_003D[edge.ShellIndex][edge.Parents[1]][num6];
					if (_0023_003Dz2u_3iw7LP_ic2._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D == null)
					{
						Surface.Reparametrize(_0023_003Dz2u_3iw7LP_ic2._0023_003Dz4wZe_0024Xg_003D, out _0023_003Dz2u_3iw7LP_ic2._0023_003Dz2AZ_kpw_003D, out _0023_003Dz2u_3iw7LP_ic2._0023_003Dza2Pq9PQ_003D, out _0023_003Dz2u_3iw7LP_ic2._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
						_0023_003DzVu89R1DJ2wENgCyqdyx6Ymo_003D[edge.ShellIndex][edge.Parents[1]][num6] = _0023_003Dz2u_3iw7LP_ic2;
					}
					array2[num6] = _0023_003Dz2u_3iw7LP_ic2._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
				}
			}
			bool _0023_003DzL5JnwECkCSS = edge.Parents.Length <= 1 || edge.Parents[0] == edge.Parents[1];
			Surface _0023_003DzEOYOsIZn22b = null;
			Surface _0023_003DzEOYOsIZn22b2 = null;
			num = 0;
			num2 = 0;
			num3 = 0;
			num4 = 1;
			_0023_003DzmGgqdRaHiXdg(array, out _0023_003DzEOYOsIZn22b, i, _0023_003DzL5JnwECkCSS4: false, ref num, out var _0023_003DzTjnkGyI_003D);
			_0023_003DzmGgqdRaHiXdg(array2, out _0023_003DzEOYOsIZn22b2, i, _0023_003DzL5JnwECkCSS, ref num2, out var _0023_003DzTjnkGyI_003D2);
			if (_0023_003DzEOYOsIZn22b == null || num5 == 0)
			{
				if (_0023_003DzEOYOsIZn22b2 == null || num5 == 1)
				{
					continue;
				}
				_0023_003DzEOYOsIZn22b = _0023_003DzEOYOsIZn22b2;
				num = num2;
				_0023_003DzTjnkGyI_003D = _0023_003DzTjnkGyI_003D2;
				num3 = 1;
				_0023_003DzEOYOsIZn22b2 = null;
				num2 = -1;
				_0023_003DzTjnkGyI_003D2 = null;
				num4 = 0;
			}
			_0023_003DzEOYOsIZn22b.ControlBoundingBox(out var _, out var _);
			curve.GetApproximatedBoundingBox(out var boxMin, out var boxMax);
			Size3D intersectionBox;
			bool flag7 = Utility.DoOverlapOrTouchWithIntersectionBox(boxMin, boxMax, min, max, out intersectionBox);
			Point3D[] array3 = new Point3D[0];
			if (flag7)
			{
				double diagonal2 = new Size3D(boxMin, boxMax).Diagonal;
				double num7 = ((intersectionBox.Diagonal > _rebuildTol) ? intersectionBox.Diagonal : diagonal2);
				_0023_003DzF7GfYSI_003D.shrunk._0023_003Dzn7CZziZi_8snx0i8Sg_003D_003D();
				if (!Utility.DoOverlapOrTouch(Edge._0023_003DzCgaa0Gau9G1_OJewpg_003D_003D(curve, diagonal2), _0023_003DzF7GfYSI_003D.shrunk.ConvexHull) || _0023_003DzemnFsB3wMkfbIgJjlbnHx7s_003D(_0023_003DzF7GfYSI_003D, curve, num7 * _rebuildTol))
				{
					continue;
				}
				double _0023_003Dzm0CYiiE_003D = _rebuildTol / 10.0;
				if (_0023_003DzeJW3Kznumb_0024KMmTj0g_003D_003D != null && _0023_003DzF7GfYSI_003D._0023_003Dz8YHQGvCahm8V(curve, _0023_003Dzm0CYiiE_003D, 5) && _0023_003DzfOEOSCcr4ep6PWoklA_003D_003D(_0023_003DzF7GfYSI_003D, _0023_003DzWGK64IQLDyWN, _0023_003DzVu89R1DJ2wENgCyqdyx6Ymo_003D, _0023_003Dzjm4D0qYZNBEL, _0023_003DzouKQRsP5tcPXubQriQ_003D_003D, _0023_003DzRLCcpW4_003D, _0023_003DzeJW3Kznumb_0024KMmTj0g_003D_003D, _0023_003Dzknqtwd_00246VMEYdDlz_00249g8qcY_003D, _0023_003Dz8VfEbJmiWwJ4FAEd5bmP__g_003D, _0023_003Dzr1JqptnFernPnT_CHSjJH23BqG0s, _0023_003Dzj0U7nuNL7GBJ, curve, edge, i, _0023_003Dzm0CYiiE_003D, _0023_003Dz7b1_EkFXtnHn))
				{
					continue;
				}
				if (_0023_003DzTjnkGyI_003D == null)
				{
					_0023_003DzTjnkGyI_003D = curve.GetNurbsForm().GetTrimCurve();
					_0023_003DzTjnkGyI_003D.Edge = curve;
				}
				if (_0023_003DzTjnkGyI_003D2 == null)
				{
					_0023_003DzTjnkGyI_003D2 = curve.GetNurbsForm().GetTrimCurve();
					_0023_003DzTjnkGyI_003D2.Edge = curve;
				}
				ICurve _0023_003Dz8fpRyMu9aKjE = ((_0023_003DzTjnkGyI_003D != null) ? _0023_003DzTjnkGyI_003D.Edge : curve);
				array3 = _0023_003Dzj4BwwHpJqX0aXcrqKxfpae8BS9rB8XpyPw_003D_003D2._0023_003DzQ7usAag_003D(_0023_003Dz8fpRyMu9aKjE, _0023_003DzF7GfYSI_003D, plane, num7, _0023_003DzTjnkGyI_003D, _0023_003DzEOYOsIZn22b, _0023_003DzjddUj_FVLA_VJ_Y9aNk2QAQ_003D, _0023_003Dz4wZe_0024Xg_003D, _0023_003DzPsHFxZf6VuL6);
				if (flag || flag2)
				{
					for (int num8 = 0; num8 < array3.Length; num8++)
					{
						InitialPoint initialPoint = (InitialPoint)array3[num8].Clone();
						initialPoint.TransformBy(new Translation(_0023_003DzPsHFxZf6VuL6));
						Vertex vertex = (Vertex)Vertices[edge.StartPointIndex];
						Vertex vertex2 = (Vertex)Vertices[edge.EndPointIndex];
						double domainSize = num7 * 1000000.0;
						if (Point3D.AreEqual(initialPoint, vertex, domainSize))
						{
							for (int num9 = 0; num9 < vertex.Parents.Length; num9++)
							{
								if (vertex.Parents[num9] != i)
								{
									Edge _0023_003DzhqSijpWww9v = Edges[vertex.Parents[num9]];
									if (_0023_003Dzp3Ed5HgwZL03i6GKZdJve5A_003D(_0023_003DzWGK64IQLDyWN, _0023_003DzhqSijpWww9v))
									{
										((InitialPoint)array3[num8])._0023_003Dz9UfD_00243UN4YK9Dk_Q_0024A_003D_003D = true;
										break;
									}
								}
							}
						}
						if (Point3D.AreEqual(initialPoint, vertex2, domainSize))
						{
							for (int num10 = 0; num10 < vertex2.Parents.Length; num10++)
							{
								if (vertex2.Parents[num10] != i)
								{
									Edge _0023_003DzhqSijpWww9v2 = Edges[vertex2.Parents[num10]];
									if (_0023_003Dzp3Ed5HgwZL03i6GKZdJve5A_003D(_0023_003DzWGK64IQLDyWN, _0023_003DzhqSijpWww9v2))
									{
										((InitialPoint)array3[num8])._0023_003Dz9UfD_00243UN4YK9Dk_Q_0024A_003D_003D = true;
										break;
									}
								}
							}
						}
						if (!flag2 || _0023_003DzWGK64IQLDyWN == -1 || ((InitialPoint)array3[num8])._0023_003Dz9UfD_00243UN4YK9Dk_Q_0024A_003D_003D)
						{
							continue;
						}
						Face face2 = _0023_003DzkoMzW4RvquFL.Faces[_0023_003DzWGK64IQLDyWN];
						for (int num11 = 0; num11 < face2.Loops.Length; num11++)
						{
							for (int num12 = 0; num12 < face2.Loops[num11].Segments.Length; num12++)
							{
								Edge edge2 = _0023_003DzkoMzW4RvquFL.Edges[face2.Loops[num11].Segments[num12].CurveIndex];
								ICurve curve2 = edge2.Curve;
								curve2.ClosestPointTo(initialPoint, out var t);
								Point3D p = curve2.PointAt(t);
								if (!Point3D.AreEqual(initialPoint, p, domainSize))
								{
									continue;
								}
								for (int num13 = 0; num13 < edge.Parents.Length; num13++)
								{
									if (_0023_003DzkoMzW4RvquFL._0023_003Dzp3Ed5HgwZL03i6GKZdJve5A_003D(edge.Parents[num13], edge2))
									{
										((InitialPoint)array3[num8])._0023_003Dz9UfD_00243UN4YK9Dk_Q_0024A_003D_003D = true;
										break;
									}
								}
								if (((InitialPoint)array3[num8])._0023_003Dz9UfD_00243UN4YK9Dk_Q_0024A_003D_003D)
								{
									break;
								}
							}
							if (((InitialPoint)array3[num8])._0023_003Dz9UfD_00243UN4YK9Dk_Q_0024A_003D_003D)
							{
								break;
							}
						}
					}
				}
			}
			if (_0023_003DzWGK64IQLDyWN == -1 || flag7)
			{
				if (num5 != num3)
				{
					_0023_003Dz3fyoN3vD76NKnDamJKs6VoA_003D(_0023_003DzTmhgNwFiSUUdfHgPqA_003D_003D, array3, edge, num3, num, i, _0023_003DzTjnkGyI_003D, _0023_003DzEOYOsIZn22b, _0023_003Dzjm4D0qYZNBEL);
				}
				if (_0023_003DzEOYOsIZn22b2 != null && num5 != num4)
				{
					_0023_003Dz3fyoN3vD76NKnDamJKs6VoA_003D(_0023_003DzTmhgNwFiSUUdfHgPqA_003D_003D, array3, edge, num4, num2, i, _0023_003DzTjnkGyI_003D2, _0023_003DzEOYOsIZn22b2, _0023_003Dzjm4D0qYZNBEL);
				}
			}
		}
	}

	private bool _0023_003DzfOEOSCcr4ep6PWoklA_003D_003D(Surface _0023_003DzF7GfYSI_003D, int _0023_003DzWGK64IQLDyWN, Surface._0023_003Dz2u_3iw7LP_ic[][][] _0023_003DzVu89R1DJ2wENgCyqdyx6Ymo_003D, bool _0023_003Dzjm4D0qYZNBEL, int _0023_003DzouKQRsP5tcPXubQriQ_003D_003D, int _0023_003DzRLCcpW4_003D, List<ICurve> _0023_003DzeJW3Kznumb_0024KMmTj0g_003D_003D, List<ICurve> _0023_003Dzknqtwd_00246VMEYdDlz_00249g8qcY_003D, List<ICurve> _0023_003Dz8VfEbJmiWwJ4FAEd5bmP__g_003D, List<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>> _0023_003Dzr1JqptnFernPnT_CHSjJH23BqG0s, HashSet<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>> _0023_003Dzj0U7nuNL7GBJ, ICurve _0023_003Dz8vL_NxTP5wHa, Edge _0023_003DzTx2aqr8_003D, int _0023_003DzbfrNXYE_003D, double _0023_003Dzm0CYiiE_003D, HashSet<Tuple<int, int>> _0023_003Dz7b1_EkFXtnHn)
	{
		bool result = false;
		bool flag = ((Entity)_0023_003Dz8vL_NxTP5wHa).Vertices == null;
		regenType regenType2 = ((Entity)_0023_003Dz8vL_NxTP5wHa).RegenMode;
		int[] parents = _0023_003DzTx2aqr8_003D.Parents;
		foreach (int num in parents)
		{
			ICurve curve = (ICurve)_0023_003Dz8vL_NxTP5wHa.Clone();
			if (!flag)
			{
				((Entity)curve).Vertices = Utility.DeepCopy(((Entity)_0023_003Dz8vL_NxTP5wHa).Vertices);
			}
			else
			{
				((Entity)curve).Regen(RebuildTolerance);
			}
			Surface._0023_003Dz2u_3iw7LP_ic[] array = _0023_003DzVu89R1DJ2wENgCyqdyx6Ymo_003D[_0023_003DzTx2aqr8_003D.ShellIndex][num];
			TrimCurve trimCurve = null;
			bool flag2 = false;
			bool flag3 = true;
			for (int j = 0; j < array.Length; j++)
			{
				Surface _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D = array[j]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
				foreach (ICurve contour in _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.Trimming.ContourList)
				{
					ICurve[] individualCurves = contour.GetIndividualCurves();
					foreach (ICurve curve2 in individualCurves)
					{
						Curve curve3 = (Curve)curve2.GetNurbsForm().Clone();
						Curve curve4 = (Curve)((TrimCurve)curve2).Edge.GetNurbsForm().Clone();
						if (curve3.EdgeIndex != _0023_003DzbfrNXYE_003D || Math.Abs(curve4.Length() - curve.Length()) > curve.Length() * Utility._0023_003DzxhnLabVjXjPg)
						{
							continue;
						}
						bool flag4 = Point3D.Distance(curve4.StartPoint, curve.StartPoint) <= _0023_003Dzm0CYiiE_003D;
						bool flag5 = Point3D.Distance(curve4.StartPoint, curve.EndPoint) <= _0023_003Dzm0CYiiE_003D;
						if (!(flag4 || flag5))
						{
							continue;
						}
						if (flag4)
						{
							if (Point3D.Distance(curve4.EndPoint, curve.EndPoint) > _0023_003Dzm0CYiiE_003D)
							{
								continue;
							}
						}
						else if (Point3D.Distance(curve4.EndPoint, curve.StartPoint) > _0023_003Dzm0CYiiE_003D)
						{
							continue;
						}
						_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.PointInversion(curve.StartPoint, _0023_003Dzm0CYiiE_003D, out var proj);
						_0023_003DzF7GfYSI_003D.PointInversion(curve.StartPoint, _0023_003Dzm0CYiiE_003D, out var proj2);
						Vector3D vector3D = _0023_003DzF7GfYSI_003D.NormalAt(proj2);
						Vector3D vector3D2 = _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.NormalAt(proj);
						Vector3D vector3D3 = (_0023_003Dzjm4D0qYZNBEL ? Vector3D.Cross(vector3D2, vector3D) : Vector3D.Cross(vector3D, vector3D2));
						if (Vector3D.AreParallel(vector3D, vector3D2, Utility._0023_003Dzjyaz_Vfaky9X))
						{
							flag3 = false;
						}
						vector3D3.Normalize();
						if (Vector3D.AreOpposite(vector3D3, curve.StartTangent, 0.001))
						{
							curve.Reverse();
							if (((Entity)curve).Vertices != null && ((Entity)curve).Vertices.Length != 0 && Point3D.Distance(curve.StartPoint, ((Entity)curve).Vertices[0]) > curve.Length() * Utility._0023_003DzheSR8QM7q9ya)
							{
								Array.Reverse(((Entity)curve).Vertices);
								Point3D[] vertices = ((Entity)curve).Vertices;
								foreach (Point3D point3D in vertices)
								{
									if (point3D.GetType() == typeof(PointTangent) || point3D.GetType() == typeof(PointTangentU))
									{
										((PointTangent)point3D).Tangent *= -1.0;
									}
								}
							}
						}
						if (flag3 && new _0023_003DzGJERpBU4BDeOxTXWM4VD_r9439SEC8V22w_003D_003D(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D)._0023_003Dz9D8dDjb0uUoA(curve, _0023_003Dzm0CYiiE_003D, out var _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D) && (!Vector3D.AreCoincident(_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.StartTangent, curve3.StartTangent) || !Utility.PointCoincidence(curve3.StartPoint.AsVector, _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.StartPoint.AsVector, curve3.Length(), out var _, out var _, Utility._0023_003Dzjyaz_Vfaky9X)))
						{
							curve3.Reverse();
						}
						Curve curve5 = (Curve)curve.GetNurbsForm().Clone();
						if (flag)
						{
							curve5.Vertices = null;
						}
						curve5.RegenMode = regenType2;
						trimCurve = curve3._0023_003DzmGgqdRaHiXdg((Curve)curve5.GetNurbsForm().Clone());
						trimCurve.FaceInfo = new _0023_003DzKfMGQQU_003D
						{
							_0023_003DzLJVtPYc_003D = num,
							_0023_003DzVYqYlD94dR8lRmB4iw_003D_003D = j,
							_0023_003DzBLJ2fdI_003D = _0023_003DzTx2aqr8_003D.ShellIndex
						};
						trimCurve.fromTangentEdgeParent = true;
						flag2 = true;
						break;
					}
					if (flag2)
					{
						break;
					}
				}
				if (flag2)
				{
					break;
				}
			}
			if (!flag2)
			{
				return false;
			}
			_0023_003DzGJERpBU4BDeOxTXWM4VD_r9439SEC8V22w_003D_003D obj = new _0023_003DzGJERpBU4BDeOxTXWM4VD_r9439SEC8V22w_003D_003D(_0023_003DzF7GfYSI_003D);
			TrimCurve trimCurve2 = null;
			if (obj._0023_003Dz9D8dDjb0uUoA(curve, _0023_003Dzm0CYiiE_003D, out var _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D2))
			{
				Curve curve6 = (Curve)curve.GetNurbsForm().Clone();
				if (flag)
				{
					curve6.Vertices = null;
				}
				curve6.RegenMode = regenType2;
				trimCurve2 = ((Curve)_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D2.Clone())._0023_003DzmGgqdRaHiXdg(curve6);
				trimCurve2.FaceInfo = new _0023_003DzKfMGQQU_003D
				{
					_0023_003DzLJVtPYc_003D = _0023_003DzWGK64IQLDyWN,
					_0023_003DzVYqYlD94dR8lRmB4iw_003D_003D = _0023_003DzouKQRsP5tcPXubQriQ_003D_003D,
					_0023_003DzBLJ2fdI_003D = _0023_003DzRLCcpW4_003D
				};
				bool flag6 = false;
				if (_0023_003Dzj0U7nuNL7GBJ != null)
				{
					flag6 = (_0023_003Dzjm4D0qYZNBEL ? _0023_003Dzj0U7nuNL7GBJ.Contains(new Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>(trimCurve.FaceInfo, trimCurve2.FaceInfo)) : _0023_003Dzj0U7nuNL7GBJ.Contains(new Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>(trimCurve2.FaceInfo, trimCurve.FaceInfo)));
				}
				else
				{
					if (_0023_003Dz7b1_EkFXtnHn == null)
					{
						throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962223));
					}
					flag6 = (_0023_003Dzjm4D0qYZNBEL ? (!_0023_003Dz7b1_EkFXtnHn.Contains(new Tuple<int, int>(trimCurve.FaceInfo._0023_003DzLJVtPYc_003D, trimCurve2.FaceInfo._0023_003DzLJVtPYc_003D))) : (!_0023_003Dz7b1_EkFXtnHn.Contains(new Tuple<int, int>(trimCurve2.FaceInfo._0023_003DzLJVtPYc_003D, trimCurve.FaceInfo._0023_003DzLJVtPYc_003D))));
				}
				if (flag6 && flag3)
				{
					if (!_0023_003Dzjm4D0qYZNBEL)
					{
						trimCurve.startIp = new InitialPoint(trimCurve.Edge.StartPoint.X, trimCurve.Edge.StartPoint.Y, trimCurve.Edge.StartPoint.Z, trimCurve2.StartPoint.X, trimCurve2.StartPoint.Y, trimCurve.StartPoint.X, trimCurve.StartPoint.Y);
						trimCurve.endIp = new InitialPoint(trimCurve.Edge.EndPoint.X, trimCurve.Edge.EndPoint.Y, trimCurve.Edge.EndPoint.Z, trimCurve2.EndPoint.X, trimCurve2.EndPoint.Y, trimCurve.EndPoint.X, trimCurve.EndPoint.Y);
						trimCurve2.startIp = new InitialPoint(trimCurve2.Edge.StartPoint.X, trimCurve2.Edge.StartPoint.Y, trimCurve2.Edge.StartPoint.Z, trimCurve.StartPoint.X, trimCurve.StartPoint.Y, trimCurve2.StartPoint.X, trimCurve2.StartPoint.Y);
						trimCurve2.endIp = new InitialPoint(trimCurve2.Edge.StartPoint.X, trimCurve2.Edge.EndPoint.Y, trimCurve2.Edge.EndPoint.Z, trimCurve.EndPoint.X, trimCurve.EndPoint.Y, trimCurve2.EndPoint.X, trimCurve2.EndPoint.Y);
					}
					else
					{
						trimCurve.startIp = new InitialPoint(trimCurve.Edge.StartPoint.X, trimCurve.Edge.StartPoint.Y, trimCurve.Edge.StartPoint.Z, trimCurve.StartPoint.X, trimCurve.StartPoint.Y, trimCurve2.StartPoint.X, trimCurve2.StartPoint.Y);
						trimCurve.endIp = new InitialPoint(trimCurve.Edge.EndPoint.X, trimCurve.Edge.EndPoint.Y, trimCurve.Edge.EndPoint.Z, trimCurve.EndPoint.X, trimCurve.EndPoint.Y, trimCurve2.EndPoint.X, trimCurve2.EndPoint.Y);
						trimCurve2.startIp = new InitialPoint(trimCurve2.Edge.StartPoint.X, trimCurve2.Edge.StartPoint.Y, trimCurve2.Edge.StartPoint.Z, trimCurve.StartPoint.X, trimCurve.StartPoint.Y, trimCurve2.StartPoint.X, trimCurve2.StartPoint.Y);
						trimCurve2.endIp = new InitialPoint(trimCurve2.Edge.StartPoint.X, trimCurve2.Edge.EndPoint.Y, trimCurve2.Edge.EndPoint.Z, trimCurve.EndPoint.X, trimCurve.EndPoint.Y, trimCurve2.EndPoint.X, trimCurve2.EndPoint.Y);
					}
					if (flag)
					{
						((Entity)curve).Vertices = null;
					}
					((Entity)curve).RegenMode = regenType2;
					_0023_003DzeJW3Kznumb_0024KMmTj0g_003D_003D.Add(curve);
					_0023_003Dzknqtwd_00246VMEYdDlz_00249g8qcY_003D.Add(trimCurve);
					_0023_003Dz8VfEbJmiWwJ4FAEd5bmP__g_003D.Add(trimCurve2);
				}
				if (!_0023_003Dzjm4D0qYZNBEL)
				{
					_0023_003Dzr1JqptnFernPnT_CHSjJH23BqG0s.Add(new Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>(trimCurve2.FaceInfo, trimCurve.FaceInfo));
				}
				else
				{
					_0023_003Dzr1JqptnFernPnT_CHSjJH23BqG0s.Add(new Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>(trimCurve.FaceInfo, trimCurve2.FaceInfo));
				}
				result = true;
				continue;
			}
			return false;
		}
		return result;
	}

	internal static bool _0023_003DzemnFsB3wMkfbIgJjlbnHx7s_003D(Surface _0023_003DzcspOUes_003D, ICurve _0023_003DzexHbPhuoA__P, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
	{
		bool flag = _0023_003DzcspOUes_003D is CylindricalSurface;
		bool flag2 = _0023_003DzcspOUes_003D is TabulatedSurface;
		if (_0023_003DzexHbPhuoA__P is Circle && (flag || flag2))
		{
			Circle circle = (Circle)_0023_003DzexHbPhuoA__P;
			if (flag)
			{
				CylindricalSurface cylindricalSurface = (CylindricalSurface)_0023_003DzcspOUes_003D;
				if (Vector3D.AreParallel(cylindricalSurface.Axis, circle.Plane.AxisZ))
				{
					Segment3D segment3D = new Segment3D(cylindricalSurface.Center, cylindricalSurface.Center + cylindricalSurface.Axis);
					double t = segment3D.Project(circle.Center);
					if (Point3D.Distance(segment3D.PointAt(t), circle.Center) < _0023_003DzuMKQhOieejyEvhtVOw_003D_003D / 10.0)
					{
						return true;
					}
				}
			}
			else if (flag2)
			{
				TabulatedSurface tabulatedSurface = (TabulatedSurface)_0023_003DzcspOUes_003D;
				if (tabulatedSurface.Directrix is Circle)
				{
					Circle circle2 = (Circle)tabulatedSurface.Directrix;
					if (Vector3D.AreParallel(circle2.Plane.AxisZ, circle.Plane.AxisZ))
					{
						Segment3D segment3D2 = new Segment3D(circle2.Center, circle2.Center + circle2.Plane.AxisZ);
						double t2 = segment3D2.Project(circle.Center);
						if (Point3D.Distance(segment3D2.PointAt(t2), circle.Center) < _0023_003DzuMKQhOieejyEvhtVOw_003D_003D / 10.0)
						{
							return true;
						}
					}
				}
			}
		}
		return false;
	}

	private bool _0023_003Dzp3Ed5HgwZL03i6GKZdJve5A_003D(int _0023_003DzWGK64IQLDyWN, Edge _0023_003DzhqSijpWww9v3)
	{
		for (int i = 0; i < _0023_003DzhqSijpWww9v3.Parents.Length; i++)
		{
			List<int> tangentFacesIndices = Faces[_0023_003DzhqSijpWww9v3.Parents[i]].tangentFacesIndices;
			if (tangentFacesIndices == null)
			{
				continue;
			}
			for (int j = 0; j < tangentFacesIndices.Count; j++)
			{
				if (tangentFacesIndices[j] == _0023_003DzWGK64IQLDyWN)
				{
					return true;
				}
			}
		}
		return false;
	}

	private static void _0023_003Dz3fyoN3vD76NKnDamJKs6VoA_003D(Dictionary<_0023_003DzKfMGQQU_003D, List<Point3D>> _0023_003DzpOf_GHqPFitB, Point3D[] _0023_003DzrdSL0CI_003D, Edge _0023_003DzTx2aqr8_003D, int _0023_003DznQRq8wY_003D, int _0023_003DzJ7OGZmA_003D, int _0023_003DzbfrNXYE_003D, TrimCurve _0023_003DzTjnkGyI_003D, Surface _0023_003DzEOYOsIZn22b6, bool _0023_003Dzjm4D0qYZNBEL)
	{
		if (_0023_003DzrdSL0CI_003D != null)
		{
			_0023_003DzKfMGQQU_003D key = new _0023_003DzKfMGQQU_003D
			{
				_0023_003DzBLJ2fdI_003D = _0023_003DzTx2aqr8_003D.ShellIndex,
				_0023_003DzLJVtPYc_003D = _0023_003DzTx2aqr8_003D.Parents[_0023_003DznQRq8wY_003D],
				_0023_003DzVYqYlD94dR8lRmB4iw_003D_003D = _0023_003DzJ7OGZmA_003D
			};
			if (!_0023_003DzpOf_GHqPFitB.ContainsKey(key))
			{
				_0023_003DzpOf_GHqPFitB.Add(key, new List<Point3D>());
			}
			List<Point3D> list = _0023_003DzpOf_GHqPFitB[key];
			for (int i = 0; i < _0023_003DzrdSL0CI_003D.Length; i++)
			{
				InitialPoint initialPoint = (InitialPoint)_0023_003DzrdSL0CI_003D[i].Clone();
				initialPoint._0023_003DzL8NvYU0_003D = _0023_003DzbfrNXYE_003D;
				initialPoint._0023_003DzSobLr5DEOQoE = _0023_003Dzjm4D0qYZNBEL;
				initialPoint._0023_003DzutFG6gdoV0Ic = _0023_003DzTjnkGyI_003D;
				initialPoint.startPointCurveOwner = _0023_003DzEOYOsIZn22b6;
				list.Add(initialPoint);
			}
		}
	}

	private void _0023_003DzmGgqdRaHiXdg(Surface[] _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D, out Surface _0023_003DzEOYOsIZn22b6, int _0023_003DzbfrNXYE_003D, bool _0023_003DzL5JnwECkCSS4, ref int _0023_003DzJ7OGZmA_003D, out TrimCurve _0023_003DzTjnkGyI_003D)
	{
		if (_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Length == 0)
		{
			_0023_003DzEOYOsIZn22b6 = null;
			_0023_003DzTjnkGyI_003D = null;
			_0023_003DzJ7OGZmA_003D = -1;
			return;
		}
		_0023_003DzEOYOsIZn22b6 = _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D[0];
		int _0023_003Dz4QXIUAk_003D = (_0023_003DzL5JnwECkCSS4 ? 1 : 0);
		if (Surface._0023_003DzsDi_rTtQwDS4(_0023_003DzbfrNXYE_003D, _0023_003DzEOYOsIZn22b6, _0023_003Dz4QXIUAk_003D, out _0023_003DzTjnkGyI_003D))
		{
			return;
		}
		for (int i = 1; i < _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.Length; i++)
		{
			_0023_003DzEOYOsIZn22b6 = _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D[i];
			_0023_003DzJ7OGZmA_003D = i;
			if (Surface._0023_003DzsDi_rTtQwDS4(_0023_003DzbfrNXYE_003D, _0023_003DzEOYOsIZn22b6, _0023_003Dz4QXIUAk_003D, out _0023_003DzTjnkGyI_003D))
			{
				break;
			}
		}
	}

	private Surface._0023_003Dz2u_3iw7LP_ic[][][] _0023_003DzjwHfLWwaRklt_0024sgoShcqXfTofnfX(Vector3D _0023_003DznqTT8cFXRJlY560dz_BsFy0_003D, bool _0023_003Dzb_oSv5xIJjDFBiUXNjPZ_Qo_003D, bool _0023_003Dz16MJo1JQ0jsITRzr5A_003D_003D)
	{
		Surface._0023_003Dz2u_3iw7LP_ic[][][] array = new Surface._0023_003Dz2u_3iw7LP_ic[Inners.GetLength(0) + 1][][];
		int num = Faces.Length;
		array[0] = new Surface._0023_003Dz2u_3iw7LP_ic[num][];
		for (int i = 0; i < num; i++)
		{
			array[0][i] = new Surface._0023_003Dz2u_3iw7LP_ic[Faces[i].Parametric.Length];
			for (int j = 0; j < array[0][i].Length; j++)
			{
				Surface _0023_003Dz9KmenBCrwEbu = Faces[i].Parametric[j];
				Surface._0023_003Dz2u_3iw7LP_ic _0023_003Dz2u_3iw7LP_ic = _0023_003DzHeo7dg_0024anFsVQTZtqg_003D_003D(_0023_003DznqTT8cFXRJlY560dz_BsFy0_003D, _0023_003Dzb_oSv5xIJjDFBiUXNjPZ_Qo_003D, _0023_003Dz16MJo1JQ0jsITRzr5A_003D_003D, _0023_003Dz9KmenBCrwEbu);
				_0023_003Dz2u_3iw7LP_ic._0023_003DzZ8DVrAfDB6VE7Gu9_0024Jl7_0024Dg_003D = Faces[i].Surface;
				array[0][i][j] = _0023_003Dz2u_3iw7LP_ic;
			}
		}
		for (int k = 0; k < Inners.GetLength(0); k++)
		{
			num = Inners[k].Length;
			array[k + 1] = new Surface._0023_003Dz2u_3iw7LP_ic[num][];
			for (int l = 0; l < num; l++)
			{
				array[k + 1][l] = new Surface._0023_003Dz2u_3iw7LP_ic[Inners[k][l].Parametric.Length];
				for (int m = 0; m < array[k + 1][l].Length; m++)
				{
					Surface _0023_003Dz9KmenBCrwEbu2 = Inners[k][l].Parametric[m];
					Surface._0023_003Dz2u_3iw7LP_ic _0023_003Dz2u_3iw7LP_ic2 = _0023_003DzHeo7dg_0024anFsVQTZtqg_003D_003D(_0023_003DznqTT8cFXRJlY560dz_BsFy0_003D, _0023_003Dzb_oSv5xIJjDFBiUXNjPZ_Qo_003D, _0023_003Dz16MJo1JQ0jsITRzr5A_003D_003D, _0023_003Dz9KmenBCrwEbu2);
					_0023_003Dz2u_3iw7LP_ic2._0023_003DzZ8DVrAfDB6VE7Gu9_0024Jl7_0024Dg_003D = Faces[l].Surface;
					array[k + 1][l][m] = _0023_003Dz2u_3iw7LP_ic2;
				}
			}
		}
		return array;
	}

	private static Surface._0023_003Dz2u_3iw7LP_ic _0023_003DzHeo7dg_0024anFsVQTZtqg_003D_003D(Vector3D _0023_003DznqTT8cFXRJlY560dz_BsFy0_003D, bool _0023_003Dzb_oSv5xIJjDFBiUXNjPZ_Qo_003D, bool _0023_003Dz16MJo1JQ0jsITRzr5A_003D_003D, Surface _0023_003Dz9KmenBCrwEbu)
	{
		Surface._0023_003Dz2u_3iw7LP_ic result = new Surface._0023_003Dz2u_3iw7LP_ic
		{
			_0023_003Dz4wZe_0024Xg_003D = _0023_003Dz9KmenBCrwEbu
		};
		if (_0023_003Dzb_oSv5xIJjDFBiUXNjPZ_Qo_003D)
		{
			Surface.Reparametrize(_0023_003Dz9KmenBCrwEbu, out result._0023_003Dz2AZ_kpw_003D, out result._0023_003Dza2Pq9PQ_003D, out result._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
		}
		if (_0023_003Dz16MJo1JQ0jsITRzr5A_003D_003D)
		{
			if (_0023_003Dzb_oSv5xIJjDFBiUXNjPZ_Qo_003D)
			{
				Surface._0023_003DzBz88rbCTqJ_K(result._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, -1.0 * _0023_003DznqTT8cFXRJlY560dz_BsFy0_003D);
			}
			else
			{
				Surface surface = (Surface)result._0023_003Dz4wZe_0024Xg_003D.Clone();
				Surface._0023_003DzBz88rbCTqJ_K(surface, -1.0 * _0023_003DznqTT8cFXRJlY560dz_BsFy0_003D);
				result._0023_003Dz4wZe_0024Xg_003D = surface;
			}
		}
		return result;
	}

	public static ssiFailureType IntersectionLoops(Brep solidA, Brep solidB, out ICurve[] intCurves)
	{
		solidA.Rebuild(0.0, soft: true);
		solidB.Rebuild(0.0, soft: true);
		_0023_003Dzhlq5RKbWjx6nskJGYQMtB7C9hVAf(solidA, solidB, out var _, out var _, out var _, _0023_003Dzk_3tZjgmhGlmfKWn0g_003D_003D: false, _0023_003DzY7IAYN_00249VAHl11lbabS4sjVmDFI0: false);
		Point3D[] _0023_003Dzov9kS8rXOl_0024;
		ICurve[] _0023_003DzPheed_XFmRFyp84Vdw_003D_003D;
		ICurve[] _0023_003DzjDTWe310b3TOuqMxjA_003D_003D;
		ssiFailureType ssiFailureType2 = _0023_003DzxW071OSsSln1GonVbw_003D_003D(solidA, solidB, out _0023_003Dzov9kS8rXOl_0024, out intCurves, out _0023_003DzPheed_XFmRFyp84Vdw_003D_003D, out _0023_003DzjDTWe310b3TOuqMxjA_003D_003D);
		if (intCurves.Length != 0)
		{
			double num = Math.Min(solidA._rebuildTol, solidB._rebuildTol);
			List<ICurve> _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D = intCurves.ToList();
			List<ICurve> _0023_003Dz81sECUMrsR8n = _0023_003DzPheed_XFmRFyp84Vdw_003D_003D.ToList();
			List<ICurve> _0023_003DzT4jdzOkqELa = _0023_003DzjDTWe310b3TOuqMxjA_003D_003D.ToList();
			bool num2 = _0023_003Dz6KMeGlIwa_ELnAyOOa4Yu6o_003D(ref _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D, ref _0023_003Dz81sECUMrsR8n, ref _0023_003DzT4jdzOkqELa, num);
			intCurves = Utility.GetConnectedCurves(_0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D, num / 10.0);
			if (intCurves.Length == 0)
			{
				intCurves = _0023_003Dz8iTeoKoqfuow3UlWSw_003D_003D.ToArray();
			}
			if (!num2)
			{
				return ssiFailureType.InvalidIntersectionCurves;
			}
		}
		_0023_003Dz8VkxvzXXGxA_0024(new Point3D[0], new Edge[0], solidA.Faces, solidA.Inners, _0023_003DzLuJVbec_003D: false);
		_0023_003Dz8VkxvzXXGxA_0024(new Point3D[0], new Edge[0], solidB.Faces, solidB.Inners, _0023_003DzLuJVbec_003D: false);
		if (ssiFailureType2 != ssiFailureType.DontTouch)
		{
			return ssiFailureType2;
		}
		List<Curve> _0023_003Dz0B5Dc_00244nIZ5Fu87AHQ_003D_003D;
		bool flag = _0023_003Dzp5I572_XXGZXPdnmnkHnAuWkcdr5(_0023_003DzPheed_XFmRFyp84Vdw_003D_003D, out _0023_003Dz0B5Dc_00244nIZ5Fu87AHQ_003D_003D);
		if (intCurves.Length == 0 || flag)
		{
			switch (_0023_003DzphGY8ZZmyMfcPRaN4A_003D_003D(solidA, solidB, _0023_003DzIZ8chfIpPnQJmpmf_0024PCX3FPAYO7ClGow9w_003D_003D: true, _0023_003Dz0B5Dc_00244nIZ5Fu87AHQ_003D_003D))
			{
			case (_0023_003DzGRk_0024ChFuOP73AsKQDDS1_9AKBHAND6iGKQ_003D_003D)2:
				return ssiFailureType.Success;
			case (_0023_003DzGRk_0024ChFuOP73AsKQDDS1_9AKBHAND6iGKQ_003D_003D)1:
				return ssiFailureType.Success;
			}
		}
		return ssiFailureType.DontTouch;
	}

	public static bool Intersect(Brep solidF, Brep solidG, bool ignoreComplexSurfaces, out Point3D[] intersectionPoints)
	{
		intersectionPoints = new Point3D[0];
		bool flag = true;
		bool flag2 = true;
		Point3D _0023_003DzDPcjoBJLcqli;
		Point3D _0023_003Dz_0024N_0024yKptW9BoC;
		if (solidF.localMin != null && solidF.localMax != null && solidF.RegenMode == regenType.NotNeeded)
		{
			_0023_003DzDPcjoBJLcqli = solidF.BoxMin;
			_0023_003Dz_0024N_0024yKptW9BoC = solidF.BoxMax;
		}
		else
		{
			solidF.Rebuild(0.0, soft: true);
			solidF._0023_003DzQCWJbpjMGLxZWfwMCQ_003D_003D(out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC, _0023_003Dz7cP1pZCb1hQy: true);
			flag = false;
		}
		Point3D _0023_003DzDPcjoBJLcqli2;
		Point3D _0023_003Dz_0024N_0024yKptW9BoC2;
		if (solidG.localMin != null && solidG.localMax != null && solidG.RegenMode == regenType.NotNeeded)
		{
			_0023_003DzDPcjoBJLcqli2 = solidG.BoxMin;
			_0023_003Dz_0024N_0024yKptW9BoC2 = solidG.BoxMax;
		}
		else
		{
			solidG.Rebuild(0.0, soft: true);
			solidG._0023_003DzQCWJbpjMGLxZWfwMCQ_003D_003D(out _0023_003DzDPcjoBJLcqli2, out _0023_003Dz_0024N_0024yKptW9BoC2, _0023_003Dz7cP1pZCb1hQy: true);
			flag2 = false;
		}
		if (!Utility.DoOverlapOrTouch(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC, _0023_003DzDPcjoBJLcqli2, _0023_003Dz_0024N_0024yKptW9BoC2))
		{
			return false;
		}
		if (solidF.ConvexHull == null)
		{
			if (flag)
			{
				solidF.Rebuild(0.0, soft: true);
				flag = false;
			}
			solidF._0023_003Dzn7CZziZi_8snx0i8Sg_003D_003D();
		}
		if (solidG.ConvexHull == null)
		{
			if (flag2)
			{
				solidG.Rebuild(0.0, soft: true);
				flag2 = false;
			}
			solidG._0023_003Dzn7CZziZi_8snx0i8Sg_003D_003D();
		}
		if (!Utility.DoOverlapOrTouch(solidF.ConvexHull, solidG.ConvexHull))
		{
			return false;
		}
		double num = Math.Min(solidF._rebuildTol, solidG._rebuildTol);
		if (num < solidF._rebuildTol)
		{
			solidF.Rebuild(num);
		}
		else if (flag)
		{
			solidF.Rebuild(0.0, soft: true);
		}
		if (num < solidG._rebuildTol)
		{
			solidG.Rebuild(num);
		}
		else if (flag2)
		{
			solidG.Rebuild(0.0, soft: true);
		}
		int num2 = solidF.Faces.Length;
		_0023_003Dz2atUuwuOEaVpCF5sAqFer7CzSA7EsPgeAP6tWi0_003D[] array = new _0023_003Dz2atUuwuOEaVpCF5sAqFer7CzSA7EsPgeAP6tWi0_003D[num2];
		int num3 = solidG.Faces.Length;
		_0023_003Dz2atUuwuOEaVpCF5sAqFer7CzSA7EsPgeAP6tWi0_003D[] array2 = new _0023_003Dz2atUuwuOEaVpCF5sAqFer7CzSA7EsPgeAP6tWi0_003D[num3];
		for (int i = 0; i < num2; i++)
		{
			if (solidF.Faces[i].Parametric != null && solidF.Faces[i].Parametric.Length != 0)
			{
				array[i] = solidF.Faces[i].Parametric[0]._0023_003Dz_0024uXgpJJ4Bfgt(ignoreComplexSurfaces);
				if (array[i] != null)
				{
					solidF.Faces[i].planeAlreadySet = true;
					solidF.Faces[i].plane = array[i]._0023_003DzXCecWa6CYPEG;
				}
			}
		}
		for (int j = 0; j < num3; j++)
		{
			if (solidG.Faces[j].Parametric != null && solidG.Faces[j].Parametric.Length != 0)
			{
				array2[j] = solidG.Faces[j].Parametric[0]._0023_003Dz_0024uXgpJJ4Bfgt(ignoreComplexSurfaces);
				if (array2[j] != null)
				{
					solidG.Faces[j].planeAlreadySet = true;
					solidG.Faces[j].plane = array2[j]._0023_003DzXCecWa6CYPEG;
				}
			}
		}
		HashSet<Tuple<int, int>> hashSet = new HashSet<Tuple<int, int>>();
		HashSet<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>> hashSet2 = new HashSet<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>>();
		for (int k = 0; k < solidF.Faces.Length; k++)
		{
			if (array[k] == null)
			{
				continue;
			}
			for (int l = 0; l < solidG.Faces.Length; l++)
			{
				if (array2[l] != null)
				{
					switch (Surface._0023_003DzYbCdpqXxwUwE(array[k], array2[l], solidF.RebuildTolerance))
					{
					case ssiFailureType.Success:
						return true;
					case ssiFailureType.DontTouch:
						hashSet.Add(new Tuple<int, int>(k, l));
						continue;
					}
					hashSet2.Add(new Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>(new _0023_003DzKfMGQQU_003D
					{
						_0023_003DzLJVtPYc_003D = k
					}, new _0023_003DzKfMGQQU_003D
					{
						_0023_003DzLJVtPYc_003D = l
					}));
				}
			}
		}
		Vector3D vector3D = new Vector3D();
		Surface._0023_003Dz2u_3iw7LP_ic[][][] _0023_003DzWf9pzKFDPeOw = solidF._0023_003DzjwHfLWwaRklt_0024sgoShcqXfTofnfX(vector3D, _0023_003Dzb_oSv5xIJjDFBiUXNjPZ_Qo_003D: false, _0023_003Dz16MJo1JQ0jsITRzr5A_003D_003D: false);
		Surface._0023_003Dz2u_3iw7LP_ic[][][] _0023_003Dzg1mu9hOJIYwq = solidG._0023_003DzjwHfLWwaRklt_0024sgoShcqXfTofnfX(vector3D, _0023_003Dzb_oSv5xIJjDFBiUXNjPZ_Qo_003D: false, _0023_003Dz16MJo1JQ0jsITRzr5A_003D_003D: false);
		if (_0023_003DzcjKhXiIYg4rS(solidF, solidG, vector3D, _0023_003DzWf9pzKFDPeOw, _0023_003Dzg1mu9hOJIYwq, _0023_003DzTymA54q3SWU7: true, out var _0023_003DzlCm_lJD6faPHHpr23A_003D_003D, hashSet, hashSet2, null, null, null))
		{
			List<Point3D> list = new List<Point3D>(_0023_003DzlCm_lJD6faPHHpr23A_003D_003D.Values.Count);
			foreach (List<Point3D> value in _0023_003DzlCm_lJD6faPHHpr23A_003D_003D.Values)
			{
				foreach (Point3D item in value)
				{
					list.Add(item);
				}
			}
			intersectionPoints = list.ToArray();
			return true;
		}
		if (intersectionPoints.Length == 0)
		{
			switch (_0023_003DzphGY8ZZmyMfcPRaN4A_003D_003D(solidF, solidG, _0023_003DzIZ8chfIpPnQJmpmf_0024PCX3FPAYO7ClGow9w_003D_003D: false, null))
			{
			case (_0023_003DzGRk_0024ChFuOP73AsKQDDS1_9AKBHAND6iGKQ_003D_003D)2:
				return true;
			case (_0023_003DzGRk_0024ChFuOP73AsKQDDS1_9AKBHAND6iGKQ_003D_003D)1:
				return true;
			}
		}
		return false;
	}

	internal static ssiFailureType _0023_003DzxW071OSsSln1GonVbw_003D_003D(Brep _0023_003DzqjniGGF9kvbc, Brep _0023_003Dzk0sekCclUGst, out Point3D[] _0023_003Dzov9kS8rXOl_00241, out ICurve[] _0023_003Dztarvi1RkS1TgN1GwCQ_003D_003D, out ICurve[] _0023_003DzPheed_XFmRFyp84Vdw_003D_003D, out ICurve[] _0023_003DzjDTWe310b3TOuqMxjA_003D_003D)
	{
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2 = new _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D();
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc = _0023_003DzqjniGGF9kvbc;
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst = _0023_003Dzk0sekCclUGst;
		List<ICurve> list = new List<ICurve>();
		_0023_003Dzov9kS8rXOl_00241 = new Point3D[0];
		_0023_003Dztarvi1RkS1TgN1GwCQ_003D_003D = new ICurve[0];
		_0023_003DzPheed_XFmRFyp84Vdw_003D_003D = new ICurve[0];
		_0023_003DzjDTWe310b3TOuqMxjA_003D_003D = new ICurve[0];
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzm0CYiiE_003D = Math.Min(_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc._rebuildTol, _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst._rebuildTol);
		bool flag = true;
		bool flag2 = true;
		Point3D _0023_003DzDPcjoBJLcqli;
		Point3D _0023_003Dz_0024N_0024yKptW9BoC;
		if (_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc.localMin != null && _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc.localMax != null && _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc.RegenMode == regenType.NotNeeded)
		{
			_0023_003DzDPcjoBJLcqli = _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc.BoxMin;
			_0023_003Dz_0024N_0024yKptW9BoC = _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc.BoxMax;
		}
		else
		{
			_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc.Rebuild(0.0, soft: true);
			_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc._0023_003DzQCWJbpjMGLxZWfwMCQ_003D_003D(out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC, _0023_003Dz7cP1pZCb1hQy: true);
			flag = false;
		}
		Point3D _0023_003DzDPcjoBJLcqli2;
		Point3D _0023_003Dz_0024N_0024yKptW9BoC2;
		if (_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst.localMin != null && _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst.localMax != null && _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst.RegenMode == regenType.NotNeeded)
		{
			_0023_003DzDPcjoBJLcqli2 = _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst.BoxMin;
			_0023_003Dz_0024N_0024yKptW9BoC2 = _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst.BoxMax;
		}
		else
		{
			_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst.Rebuild(0.0, soft: true);
			_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst._0023_003DzQCWJbpjMGLxZWfwMCQ_003D_003D(out _0023_003DzDPcjoBJLcqli2, out _0023_003Dz_0024N_0024yKptW9BoC2, _0023_003Dz7cP1pZCb1hQy: true);
			flag2 = false;
		}
		if (!Utility.DoOverlapOrTouch(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC, _0023_003DzDPcjoBJLcqli2, _0023_003Dz_0024N_0024yKptW9BoC2))
		{
			return ssiFailureType.DontTouch;
		}
		if (_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc.ConvexHull == null)
		{
			_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc._0023_003Dzn7CZziZi_8snx0i8Sg_003D_003D();
		}
		if (_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst.ConvexHull == null)
		{
			_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst._0023_003Dzn7CZziZi_8snx0i8Sg_003D_003D();
		}
		if (!Utility.DoOverlapOrTouch(_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc.ConvexHull, _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst.ConvexHull))
		{
			return ssiFailureType.DontTouch;
		}
		if (_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzm0CYiiE_003D < _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc._rebuildTol)
		{
			_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc.Rebuild(_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzm0CYiiE_003D);
		}
		else if (flag)
		{
			_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc.Rebuild(0.0, soft: true);
		}
		if (_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzm0CYiiE_003D < _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst._rebuildTol)
		{
			_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst.Rebuild(_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzm0CYiiE_003D);
		}
		else if (flag2)
		{
			_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst.Rebuild(0.0, soft: true);
		}
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzPsHFxZf6VuL6 = new Vector3D(_0023_003DzDPcjoBJLcqli.X, _0023_003DzDPcjoBJLcqli.Y, _0023_003DzDPcjoBJLcqli.Z);
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzWf9pzKFDPeOw = _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc._0023_003DzjwHfLWwaRklt_0024sgoShcqXfTofnfX(_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzPsHFxZf6VuL6, _0023_003Dzb_oSv5xIJjDFBiUXNjPZ_Qo_003D: true, _0023_003Dz16MJo1JQ0jsITRzr5A_003D_003D: true);
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzg1mu9hOJIYwq = _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst._0023_003DzjwHfLWwaRklt_0024sgoShcqXfTofnfX(_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzPsHFxZf6VuL6, _0023_003Dzb_oSv5xIJjDFBiUXNjPZ_Qo_003D: true, _0023_003Dz16MJo1JQ0jsITRzr5A_003D_003D: true);
		HashSet<Tuple<int, int>> hashSet = new HashSet<Tuple<int, int>>();
		HashSet<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>> hashSet2 = new HashSet<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>>();
		List<ICurve> list2 = new List<ICurve>();
		List<ICurve> list3 = new List<ICurve>();
		List<ICurve> list4 = new List<ICurve>();
		for (int i = 0; i < _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzWf9pzKFDPeOw.GetLength(0); i++)
		{
			for (int j = 0; j < _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzWf9pzKFDPeOw[i].GetLength(0); j++)
			{
				for (int k = 0; k < _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzWf9pzKFDPeOw[i][j].Length; k++)
				{
					Surface _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D = _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzWf9pzKFDPeOw[i][j][k]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
					Face face = ((i == 0) ? _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc._faces[j] : _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc._inners[i - 1][j]);
					for (int l = 0; l < _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzg1mu9hOJIYwq.GetLength(0); l++)
					{
						for (int m = 0; m < _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzg1mu9hOJIYwq[l].GetLength(0); m++)
						{
							for (int n = 0; n < _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzg1mu9hOJIYwq[l][m].Length; n++)
							{
								Surface _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2 = _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzg1mu9hOJIYwq[l][m][n]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
								if (l != 0)
								{
									_ = _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst._inners[l - 1][m];
								}
								else
								{
									_ = _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst._faces[m];
								}
								bool flag3 = true;
								if (face.tangentFacesIndices != null && face.tangentFacesIndices.IndexOf(m) != -1)
								{
									hashSet.Add(new Tuple<int, int>(j, m));
									continue;
								}
								_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.ControlBoundingBox(out var min, out var max);
								_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2.ControlBoundingBox(out var min2, out var max2);
								if (!Utility.DoOverlapOrTouchWithIntersectionBox(min, max, min2, max2, out var intersectionBox))
								{
									continue;
								}
								double diagonal = intersectionBox.Diagonal;
								List<ICurve> list5 = new List<ICurve>();
								List<ICurve> list6 = new List<ICurve>();
								PlanarSurface _0023_003DzaR3A1ks_003D = null;
								PlanarSurface _0023_003DzaR3A1ks_003D2 = null;
								bool flag4 = false;
								bool flag5 = false;
								Transformation _0023_003DzNDQ_E88_003D = null;
								Transformation _0023_003DzNDQ_E88_003D2 = null;
								double _0023_003Dzm0CYiiE_003D = diagonal * 1E-07;
								Surface surface = _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2.Promote();
								Surface surface2 = _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.Promote();
								ICurve[] _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D;
								ICurve[] _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO;
								if (_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2 is PlanarSurface planarSurface)
								{
									flag3 = Surface._0023_003DzG7qias9QKP9i(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, planarSurface.Plane, _0023_003Dzo3ZHoX_0024NyVsaNh8SBg_003D_003D: false, _0023_003Dzm0CYiiE_003D, out _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D, out _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO);
									if (!flag3)
									{
										Surface._0023_003Dz4Y3gptRKxXrD_0024hZDMZyrQuA_003D(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, list5, list6, _0023_003DzNDQ_E88_003D, _0023_003DzNDQ_E88_003D2, _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D, _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO);
									}
								}
								else if (_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D is PlanarSurface planarSurface2)
								{
									flag3 = Surface._0023_003DzG7qias9QKP9i(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, planarSurface2.Plane, _0023_003Dzo3ZHoX_0024NyVsaNh8SBg_003D_003D: true, _0023_003Dzm0CYiiE_003D, out _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO, out _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D);
									if (!flag3)
									{
										Surface._0023_003Dz4Y3gptRKxXrD_0024hZDMZyrQuA_003D(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, list5, list6, _0023_003DzNDQ_E88_003D, _0023_003DzNDQ_E88_003D2, _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D, _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO);
									}
								}
								else if (surface is PlanarSurface planarSurface3)
								{
									flag3 = Surface._0023_003DzG7qias9QKP9i(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, planarSurface3, planarSurface3.Plane, _0023_003Dzo3ZHoX_0024NyVsaNh8SBg_003D_003D: false, _0023_003Dzm0CYiiE_003D, out _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D, out _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO);
									if (!flag3)
									{
										Surface._0023_003Dz4Y3gptRKxXrD_0024hZDMZyrQuA_003D(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, planarSurface3, list5, list6, _0023_003DzNDQ_E88_003D, _0023_003DzNDQ_E88_003D2, _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D, _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO);
									}
								}
								else if (surface2 is PlanarSurface planarSurface4)
								{
									flag3 = Surface._0023_003DzG7qias9QKP9i(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, planarSurface4, planarSurface4.Plane, _0023_003Dzo3ZHoX_0024NyVsaNh8SBg_003D_003D: true, _0023_003Dzm0CYiiE_003D, out _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO, out _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D);
									if (!flag3)
									{
										Surface._0023_003Dz4Y3gptRKxXrD_0024hZDMZyrQuA_003D(planarSurface4, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, list5, list6, _0023_003DzNDQ_E88_003D, _0023_003DzNDQ_E88_003D2, _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D, _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO);
									}
								}
								if (flag3)
								{
									flag4 = _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D is TabulatedSurface && _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D._0023_003Dz_9WsAykzZ67lManT4w_003D_003D(out _0023_003DzaR3A1ks_003D, out _0023_003DzNDQ_E88_003D);
									flag5 = _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2 is TabulatedSurface && _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2._0023_003Dz_9WsAykzZ67lManT4w_003D_003D(out _0023_003DzaR3A1ks_003D2, out _0023_003DzNDQ_E88_003D2);
									if (flag4 && flag5)
									{
										flag3 = Surface._0023_003DzG7qias9QKP9i(_0023_003DzaR3A1ks_003D2, _0023_003DzaR3A1ks_003D, _0023_003DzaR3A1ks_003D.Plane, _0023_003Dzo3ZHoX_0024NyVsaNh8SBg_003D_003D: true, _0023_003Dzm0CYiiE_003D, out _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO, out _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D);
										if (!flag3)
										{
											Surface._0023_003Dz4Y3gptRKxXrD_0024hZDMZyrQuA_003D(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, list5, list6, _0023_003DzNDQ_E88_003D, _0023_003DzNDQ_E88_003D2, _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D, _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO);
										}
									}
									else if (flag4)
									{
										flag3 = Surface._0023_003DzG7qias9QKP9i(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, _0023_003DzaR3A1ks_003D, _0023_003DzaR3A1ks_003D.Plane, _0023_003Dzo3ZHoX_0024NyVsaNh8SBg_003D_003D: true, _0023_003Dzm0CYiiE_003D, out _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO, out _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D);
										if (!flag3)
										{
											Surface._0023_003Dz4Y3gptRKxXrD_0024hZDMZyrQuA_003D(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, list5, list6, _0023_003DzNDQ_E88_003D, _0023_003DzNDQ_E88_003D2, _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D, _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO);
										}
									}
									else if (flag5)
									{
										flag3 = Surface._0023_003DzG7qias9QKP9i(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzaR3A1ks_003D2, _0023_003DzaR3A1ks_003D2.Plane, _0023_003Dzo3ZHoX_0024NyVsaNh8SBg_003D_003D: false, _0023_003Dzm0CYiiE_003D, out _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D, out _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO);
										if (!flag3)
										{
											Surface._0023_003Dz4Y3gptRKxXrD_0024hZDMZyrQuA_003D(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, list5, list6, _0023_003DzNDQ_E88_003D, _0023_003DzNDQ_E88_003D2, _0023_003Dz7XBIYEsSlvyMvLjx9eT2A9oRD0kpa9fjCw_003D_003D, _0023_003Dz7OOYD4iSK7wv7sk7PlspulXrjLdO);
										}
									}
								}
								if (!flag3)
								{
									hashSet.Add(new Tuple<int, int>(j, m));
									if (list5.Count <= 0 || list6.Count <= 0)
									{
										continue;
									}
									for (int num = 0; num < list5.Count; num++)
									{
										TrimCurve trimCurve = (TrimCurve)list5[num];
										TrimCurve trimCurve2 = (TrimCurve)list6[num];
										ICurve curve = (ICurve)trimCurve.Edge.Clone();
										if (trimCurve != null && trimCurve2 != null)
										{
											trimCurve.FaceInfo = new _0023_003DzKfMGQQU_003D
											{
												_0023_003DzLJVtPYc_003D = j,
												_0023_003DzVYqYlD94dR8lRmB4iw_003D_003D = k,
												_0023_003DzBLJ2fdI_003D = i
											};
											trimCurve2.FaceInfo = new _0023_003DzKfMGQQU_003D
											{
												_0023_003DzLJVtPYc_003D = m,
												_0023_003DzVYqYlD94dR8lRmB4iw_003D_003D = n,
												_0023_003DzBLJ2fdI_003D = l
											};
											trimCurve.startIp = new InitialPoint(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z, trimCurve.StartPoint.X, trimCurve.StartPoint.Y, trimCurve2.StartPoint.X, trimCurve2.StartPoint.Y);
											trimCurve.endIp = new InitialPoint(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z, trimCurve.EndPoint.X, trimCurve.EndPoint.Y, trimCurve2.EndPoint.X, trimCurve2.EndPoint.Y);
											trimCurve2.startIp = new InitialPoint(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z, trimCurve.StartPoint.X, trimCurve.StartPoint.Y, trimCurve2.StartPoint.X, trimCurve2.StartPoint.Y);
											trimCurve2.endIp = new InitialPoint(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z, trimCurve.EndPoint.X, trimCurve.EndPoint.Y, trimCurve2.EndPoint.X, trimCurve2.EndPoint.Y);
											bool flag6 = false;
											bool _0023_003Dzb9U1KHmIZGGP = _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst.Faces[m].tangentFacesIndices != null && _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc.Faces[j].tangentFacesIndices != null;
											if (_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst.Faces[m].tangentFacesIndices != null)
											{
												flag6 = _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc._0023_003DzI9aD8Vo8tHlTXfkrMB2he1A_003D(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, j, m, trimCurve, trimCurve2, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, _0023_003Dzb9U1KHmIZGGP, _0023_003Dzf5uydyTGDFr_0024: false);
											}
											if (!flag6 && _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc.Faces[j].tangentFacesIndices != null && _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst._0023_003DzI9aD8Vo8tHlTXfkrMB2he1A_003D(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, m, j, trimCurve2, trimCurve, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003Dzb9U1KHmIZGGP, _0023_003Dzf5uydyTGDFr_0024: false))
											{
												Array.Reverse(trimCurve.onTangentFaces);
												Array.Reverse(trimCurve2.onTangentFaces);
											}
											((Entity)curve).EntityData = new Tuple<int, int>(j, m);
											list2.Add(curve);
											list3.Add(trimCurve);
											list4.Add(trimCurve2);
										}
									}
								}
								else
								{
									hashSet2.Add(new Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>(new _0023_003DzKfMGQQU_003D
									{
										_0023_003DzBLJ2fdI_003D = i,
										_0023_003DzLJVtPYc_003D = j
									}, new _0023_003DzKfMGQQU_003D
									{
										_0023_003DzBLJ2fdI_003D = l,
										_0023_003DzLJVtPYc_003D = m
									}));
								}
							}
						}
					}
				}
			}
		}
		List<ICurve> list7 = new List<ICurve>();
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzXs1mtPVIqhDmHRZf5w_003D_003D = new List<ICurve>();
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzlYYjrfi3jLJrzpfbnA_003D_003D = new List<ICurve>();
		_0023_003DzcjKhXiIYg4rS(_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc, _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst, _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzPsHFxZf6VuL6, _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzWf9pzKFDPeOw, _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzg1mu9hOJIYwq, _0023_003DzTymA54q3SWU7: false, out var _0023_003DzlCm_lJD6faPHHpr23A_003D_003D, hashSet, hashSet2, list7, _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzXs1mtPVIqhDmHRZf5w_003D_003D, _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzlYYjrfi3jLJrzpfbnA_003D_003D);
		List<Point3D> list8 = new List<Point3D>(_0023_003DzlCm_lJD6faPHHpr23A_003D_003D.Values.Count);
		foreach (List<Point3D> value in _0023_003DzlCm_lJD6faPHHpr23A_003D_003D.Values)
		{
			for (int num2 = 0; num2 < value.Count; num2++)
			{
				Point3D point3D = (Point3D)value[num2].Clone();
				point3D.TransformBy(new Translation(_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzPsHFxZf6VuL6));
				list8.Add(point3D);
			}
		}
		_0023_003Dzov9kS8rXOl_00241 = list8.ToArray();
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzNvDDVNp873gn = _0023_003DzlCm_lJD6faPHHpr23A_003D_003D.ToArray();
		int num3 = _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzNvDDVNp873gn.Length;
		if (num3 == 0 && list2.Count == 0)
		{
			return ssiFailureType.DontTouch;
		}
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzpIZC_0024x5EiUBN = new List<ICurve>[num3];
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzTQ633Sx2Bn0U = new List<ICurve>[num3];
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dz5zXjpPFtftSB = new List<ICurve>[num3];
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzgOYrZnL6wa7aFe5_0024raoLgQk_003D = new bool[num3];
		regenType regenType2 = _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc.RegenMode;
		regenType regenType3 = _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst.RegenMode;
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc.RegenMode = regenType.RegenAndCompile;
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst.RegenMode = regenType.RegenAndCompile;
		if (num3 != 0)
		{
			Parallel.For(0, _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzNvDDVNp873gn.Length, _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzAkDiNFEnv7NT2tDpGSV4W92W5tjn);
		}
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzqjniGGF9kvbc.RegenMode = regenType2;
		_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dzk0sekCclUGst.RegenMode = regenType3;
		List<ICurve> list9 = new List<ICurve>();
		List<ICurve> list10 = new List<ICurve>();
		Transformation xform = new Translation(_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzPsHFxZf6VuL6);
		for (int num4 = 0; num4 < list2.Count; num4++)
		{
			((Entity)list2[num4]).TransformBy(xform);
			((Entity)((TrimCurve)list3[num4]).Edge).TransformBy(xform);
			((Entity)((TrimCurve)list4[num4]).Edge).TransformBy(xform);
			((TrimCurve)list3[num4]).originalSurface.TransformBy(xform);
			((TrimCurve)list4[num4]).originalSurface.TransformBy(xform);
		}
		list.AddRange(list2);
		list9.AddRange(list3);
		list10.AddRange(list4);
		for (int num5 = 0; num5 < _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzpIZC_0024x5EiUBN.Length; num5++)
		{
			if (_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzpIZC_0024x5EiUBN[num5] == null)
			{
				continue;
			}
			for (int num6 = 0; num6 < _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzpIZC_0024x5EiUBN[num5].Count; num6++)
			{
				((Entity)_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzpIZC_0024x5EiUBN[num5][num6]).TransformBy(xform);
				if (num6 < _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzTQ633Sx2Bn0U[num5].Count)
				{
					((Entity)((TrimCurve)_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzTQ633Sx2Bn0U[num5][num6]).Edge).TransformBy(xform);
					((Entity)((TrimCurve)_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dz5zXjpPFtftSB[num5][num6]).Edge).TransformBy(xform);
					((TrimCurve)_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzTQ633Sx2Bn0U[num5][num6]).originalSurface.TransformBy(xform);
					((TrimCurve)_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dz5zXjpPFtftSB[num5][num6]).originalSurface.TransformBy(xform);
				}
				list.Add(_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzpIZC_0024x5EiUBN[num5][num6]);
			}
			list9.AddRange(_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzTQ633Sx2Bn0U[num5]);
			list10.AddRange(_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003Dz5zXjpPFtftSB[num5]);
		}
		for (int num7 = 0; num7 < list7.Count; num7++)
		{
			((Entity)list7[num7]).TransformBy(xform);
			((Entity)((TrimCurve)_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzXs1mtPVIqhDmHRZf5w_003D_003D[num7]).Edge).TransformBy(xform);
			((Entity)((TrimCurve)_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzlYYjrfi3jLJrzpfbnA_003D_003D[num7]).Edge).TransformBy(xform);
		}
		list.AddRange(list7);
		list9.AddRange(_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzXs1mtPVIqhDmHRZf5w_003D_003D);
		list10.AddRange(_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzlYYjrfi3jLJrzpfbnA_003D_003D);
		if (list.Count > 0)
		{
			_0023_003Dztarvi1RkS1TgN1GwCQ_003D_003D = list.ToArray();
			_0023_003DzPheed_XFmRFyp84Vdw_003D_003D = list9.ToArray();
			_0023_003DzjDTWe310b3TOuqMxjA_003D_003D = list10.ToArray();
		}
		for (int num8 = 0; num8 < _0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzgOYrZnL6wa7aFe5_0024raoLgQk_003D.Length; num8++)
		{
			if (!_0023_003DzeZhXW5_0024HRdROq8GYjLJUhAY_003D2._0023_003DzgOYrZnL6wa7aFe5_0024raoLgQk_003D[num8])
			{
				return ssiFailureType.UnknownFailure;
			}
		}
		return ssiFailureType.Success;
	}

	private bool _0023_003DzI9aD8Vo8tHlTXfkrMB2he1A_003D(Surface _0023_003DzHit7vU4_003D, int _0023_003DzttIPcVNzssTT, int _0023_003DzG10DnekqPnXX, TrimCurve _0023_003Dz5SjVeI8be_0024ae, TrimCurve _0023_003DzSzylehPMxd5q, Surface _0023_003Dz0nUpcocwbdBuykNP2Jg6VoA_003D, bool _0023_003Dzb9U1KHmIZGGP, bool _0023_003Dzf5uydyTGDFr_0024)
	{
		if (_0023_003DzHit7vU4_003D._0023_003DzZf4zvJoP0u8G(_0023_003Dz5SjVeI8be_0024ae, _0023_003DzLJE7PYTEzSqT: false, out var _, out var _0023_003Dz93D7WaCPl_0024u, _0023_003DzRAS4kB6WIA5zYp5K0eecf_00240_003D: false, _0023_003Dz0nUpcocwbdBuykNP2Jg6VoA_003D, _0023_003Dzb9U1KHmIZGGP, _0023_003Dzf5uydyTGDFr_0024) && _0023_003Dz93D7WaCPl_0024u != -1)
		{
			int[] parents = _edges[_0023_003Dz93D7WaCPl_0024u].Parents;
			for (int i = 0; i < parents.Length; i++)
			{
				if (parents[i] == _0023_003DzttIPcVNzssTT)
				{
					continue;
				}
				Face face = _faces[parents[i]];
				if (face.tangentFacesIndices == null)
				{
					continue;
				}
				for (int j = 0; j < face.tangentFacesIndices.Count; j++)
				{
					if (face.tangentFacesIndices[j] == _0023_003DzG10DnekqPnXX)
					{
						_0023_003Dz5SjVeI8be_0024ae.onTangentType = face.tangentFacesType[j];
						_0023_003Dz5SjVeI8be_0024ae.onTangentFaces = new int[2]
						{
							parents[i],
							_0023_003DzG10DnekqPnXX
						};
						_0023_003DzSzylehPMxd5q.onTangentType = face.tangentFacesType[j];
						_0023_003DzSzylehPMxd5q.onTangentFaces = new int[2]
						{
							parents[i],
							_0023_003DzG10DnekqPnXX
						};
						return true;
					}
				}
			}
		}
		return false;
	}

	private static bool _0023_003DzcjKhXiIYg4rS(Brep _0023_003DzqjniGGF9kvbc, Brep _0023_003Dzk0sekCclUGst, Vector3D _0023_003DzPsHFxZf6VuL6, Surface._0023_003Dz2u_3iw7LP_ic[][][] _0023_003DzWf9pzKFDPeOw, Surface._0023_003Dz2u_3iw7LP_ic[][][] _0023_003Dzg1mu9hOJIYwq, bool _0023_003DzTymA54q3SWU7, out Dictionary<_0023_003DzeelgtjiMbn2Y, List<Point3D>> _0023_003DzlCm_lJD6faPHHpr23A_003D_003D, HashSet<Tuple<int, int>> _0023_003DzWQoinMU_0024Uqb1, HashSet<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>> _0023_003Dz2r0w3MjvlOmGh9ov2g_003D_003D, List<ICurve> _0023_003DzeJW3Kznumb_0024KMmTj0g_003D_003D, List<ICurve> _0023_003DzFXfiSiU0v8GegCcxtv_0024_jB8_003D, List<ICurve> _0023_003Dz_OwltpbLxtOEKj6RZ_8Foeg_003D)
	{
		_0023_003DzlCm_lJD6faPHHpr23A_003D_003D = new Dictionary<_0023_003DzeelgtjiMbn2Y, List<Point3D>>();
		bool flag = _0023_003DzGck_dz7MMapt(_0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst, 0, _0023_003DzPsHFxZf6VuL6, _0023_003DzWf9pzKFDPeOw, _0023_003Dzg1mu9hOJIYwq[0], ref _0023_003DzlCm_lJD6faPHHpr23A_003D_003D, _0023_003DzTymA54q3SWU7, _0023_003DzWQoinMU_0024Uqb1, _0023_003Dz2r0w3MjvlOmGh9ov2g_003D_003D, _0023_003DzeJW3Kznumb_0024KMmTj0g_003D_003D, _0023_003DzFXfiSiU0v8GegCcxtv_0024_jB8_003D, _0023_003Dz_OwltpbLxtOEKj6RZ_8Foeg_003D);
		for (int i = 0; i < _0023_003Dzk0sekCclUGst.Inners.Length; i++)
		{
			flag |= _0023_003DzGck_dz7MMapt(_0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst, i + 1, _0023_003DzPsHFxZf6VuL6, _0023_003DzWf9pzKFDPeOw, _0023_003Dzg1mu9hOJIYwq[i + 1], ref _0023_003DzlCm_lJD6faPHHpr23A_003D_003D, _0023_003DzTymA54q3SWU7, _0023_003DzWQoinMU_0024Uqb1, _0023_003Dz2r0w3MjvlOmGh9ov2g_003D_003D, _0023_003DzeJW3Kznumb_0024KMmTj0g_003D_003D, _0023_003DzFXfiSiU0v8GegCcxtv_0024_jB8_003D, _0023_003Dz_OwltpbLxtOEKj6RZ_8Foeg_003D);
		}
		if (!flag || !_0023_003DzTymA54q3SWU7)
		{
			flag |= _0023_003DzUsQ4gcWqyACQ(_0023_003Dzk0sekCclUGst, _0023_003DzqjniGGF9kvbc, 0, _0023_003DzPsHFxZf6VuL6, _0023_003DzWf9pzKFDPeOw[0], _0023_003Dzg1mu9hOJIYwq, ref _0023_003DzlCm_lJD6faPHHpr23A_003D_003D, _0023_003DzTymA54q3SWU7, _0023_003DzWQoinMU_0024Uqb1, _0023_003Dz2r0w3MjvlOmGh9ov2g_003D_003D, _0023_003DzeJW3Kznumb_0024KMmTj0g_003D_003D, _0023_003DzFXfiSiU0v8GegCcxtv_0024_jB8_003D, _0023_003Dz_OwltpbLxtOEKj6RZ_8Foeg_003D);
			for (int j = 0; j < _0023_003DzqjniGGF9kvbc.Inners.Length; j++)
			{
				flag |= _0023_003DzUsQ4gcWqyACQ(_0023_003Dzk0sekCclUGst, _0023_003DzqjniGGF9kvbc, j + 1, _0023_003DzPsHFxZf6VuL6, _0023_003DzWf9pzKFDPeOw[j + 1], _0023_003Dzg1mu9hOJIYwq, ref _0023_003DzlCm_lJD6faPHHpr23A_003D_003D, _0023_003DzTymA54q3SWU7, _0023_003DzWQoinMU_0024Uqb1, _0023_003Dz2r0w3MjvlOmGh9ov2g_003D_003D, _0023_003DzeJW3Kznumb_0024KMmTj0g_003D_003D, _0023_003DzFXfiSiU0v8GegCcxtv_0024_jB8_003D, _0023_003Dz_OwltpbLxtOEKj6RZ_8Foeg_003D);
			}
		}
		if (!flag || !_0023_003DzTymA54q3SWU7)
		{
			foreach (Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D> item in _0023_003Dz2r0w3MjvlOmGh9ov2g_003D_003D)
			{
				Surface _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D = _0023_003DzWf9pzKFDPeOw[item.Item1._0023_003DzBLJ2fdI_003D][item.Item1._0023_003DzLJVtPYc_003D][item.Item1._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
				Surface _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2 = _0023_003Dzg1mu9hOJIYwq[item.Item2._0023_003DzBLJ2fdI_003D][item.Item2._0023_003DzLJVtPYc_003D][item.Item2._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
				if (_0023_003DzP1QeRy50u8rlB0HYj7kjJBk_v9L4912iSQ_003D_003D(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2) || (!Utility._0023_003DzPXJymPlOuaUh(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D) && !Utility._0023_003DzPXJymPlOuaUh(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2)))
				{
					continue;
				}
				PointUv[] array = Surface._0023_003DzLwRuzY_q0GL0(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, Math.Min(_0023_003DzqjniGGF9kvbc.RebuildTolerance, _0023_003Dzk0sekCclUGst.RebuildTolerance));
				foreach (PointUv pointUv in array)
				{
					if (!_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.DomainU.Includes(pointUv.U, testOpenInterval: true))
					{
						continue;
					}
					_0023_003Dzj4BwwHpJqX0aXcrqKxfpae8BS9rB8XpyPw_003D_003D _0023_003Dzj4BwwHpJqX0aXcrqKxfpae8BS9rB8XpyPw_003D_003D2 = new _0023_003Dzj4BwwHpJqX0aXcrqKxfpae8BS9rB8XpyPw_003D_003D();
					List<Point3D> list = new List<Point3D>();
					_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.ControlBoundingBox(out var min, out var max);
					_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2.ControlBoundingBox(out var min2, out var max2);
					if (!Utility.DoOverlapOrTouchWithIntersectionBox(min, max, min2, max2, out var intersectionBox))
					{
						continue;
					}
					TrimCurve trimCurve = new Line(pointUv.U, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.DomainV.Low, pointUv.U, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.DomainV.High).GetNurbsForm()._0023_003DzmGgqdRaHiXdg(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.IsocurveV(pointUv.U));
					Point3D[] array2 = _0023_003Dzj4BwwHpJqX0aXcrqKxfpae8BS9rB8XpyPw_003D_003D2._0023_003DzQ7usAag_003D(trimCurve.Edge, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, null, intersectionBox.Diagonal, trimCurve, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, null, null, null);
					if (array2.Length != 2 || Point3D.DistanceSquared(array2[0], array2[1]) < _0023_003DzqjniGGF9kvbc.RebuildTolerance * _0023_003Dzk0sekCclUGst.RebuildTolerance)
					{
						TrimCurve trimCurve2 = new Line(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.DomainU.Low, pointUv.V, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.DomainU.High, pointUv.V).GetNurbsForm()._0023_003DzmGgqdRaHiXdg(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.IsocurveU(pointUv.V));
						array2 = _0023_003Dzj4BwwHpJqX0aXcrqKxfpae8BS9rB8XpyPw_003D_003D2._0023_003DzQ7usAag_003D(trimCurve2.Edge, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, null, intersectionBox.Diagonal, trimCurve2, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, null, null, null);
					}
					list.AddRange(array2);
					List<Point3D> list2 = new List<Point3D>();
					foreach (InitialPoint item2 in list)
					{
						item2._0023_003DzuI5Ekdc_003D = -3;
					}
					_0023_003DzqjniGGF9kvbc._0023_003Dz2HQ0TbeXoMdaW6Sxxg_003D_003D(list, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, intersectionBox.Diagonal, _0023_003DzPsHFxZf6VuL6, false, list2);
					if (list2.Count <= 0)
					{
						continue;
					}
					_0023_003DzeelgtjiMbn2Y key = new _0023_003DzeelgtjiMbn2Y(item.Item1, item.Item2);
					if (!_0023_003DzlCm_lJD6faPHHpr23A_003D_003D.ContainsKey(key))
					{
						_0023_003DzlCm_lJD6faPHHpr23A_003D_003D.Add(key, new List<Point3D>());
					}
					foreach (Point3D item3 in list2)
					{
						flag |= Utility._0023_003DzbIDY9BOTPqfc(item3, _0023_003DzlCm_lJD6faPHHpr23A_003D_003D[key], intersectionBox.Diagonal);
					}
				}
			}
		}
		return flag;
	}

	private static bool _0023_003DzP1QeRy50u8rlB0HYj7kjJBk_v9L4912iSQ_003D_003D(Surface _0023_003DzHit7vU4_003D, Surface _0023_003DzFmiij5k_003D)
	{
		if (_0023_003DzHit7vU4_003D.GetType() == typeof(RevolvedSurface))
		{
			Point3D center = ((RevolvedSurface)_0023_003DzHit7vU4_003D).Center;
			if (_0023_003DzFmiij5k_003D is TabulatedSurface tabulatedSurface && Utility.IsLine(tabulatedSurface.Directrix))
			{
				Vector3D obj = (Vector3D)tabulatedSurface.Directrix.StartTangent.Clone();
				obj.Normalize();
				Vector3D asVector = (center - tabulatedSurface.Directrix.StartPoint).AsVector;
				asVector.Normalize();
				if (Vector3D.AreParallel(obj, asVector))
				{
					return true;
				}
			}
			else if (_0023_003DzFmiij5k_003D is CylindricalSurface cylindricalSurface)
			{
				Vector3D obj2 = (Vector3D)cylindricalSurface.Axis.Clone();
				obj2.Normalize();
				Vector3D asVector2 = (center - cylindricalSurface.Center).AsVector;
				asVector2.Normalize();
				if (Vector3D.AreParallel(obj2, asVector2))
				{
					return true;
				}
			}
		}
		if (_0023_003DzFmiij5k_003D.GetType() == typeof(RevolvedSurface))
		{
			Point3D center2 = ((RevolvedSurface)_0023_003DzFmiij5k_003D).Center;
			if (_0023_003DzHit7vU4_003D is TabulatedSurface tabulatedSurface2 && Utility.IsLine(tabulatedSurface2.Directrix))
			{
				Vector3D obj3 = (Vector3D)tabulatedSurface2.Directrix.StartTangent.Clone();
				obj3.Normalize();
				Vector3D asVector3 = (center2 - tabulatedSurface2.Directrix.StartPoint).AsVector;
				asVector3.Normalize();
				if (Vector3D.AreParallel(obj3, asVector3))
				{
					return true;
				}
			}
			else if (_0023_003DzHit7vU4_003D is CylindricalSurface cylindricalSurface2)
			{
				Vector3D obj4 = (Vector3D)cylindricalSurface2.Axis.Clone();
				obj4.Normalize();
				Vector3D asVector4 = (center2 - cylindricalSurface2.Center).AsVector;
				asVector4.Normalize();
				if (Vector3D.AreParallel(obj4, asVector4))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static bool _0023_003DzUsQ4gcWqyACQ(Brep _0023_003Dzk0sekCclUGst, Brep _0023_003DzqjniGGF9kvbc, int _0023_003DzjfyCbcaQyzau, Vector3D _0023_003DzPsHFxZf6VuL6, Surface._0023_003Dz2u_3iw7LP_ic[][] _0023_003DzWf9pzKFDPeOw, Surface._0023_003Dz2u_3iw7LP_ic[][][] _0023_003Dzg1mu9hOJIYwq, ref Dictionary<_0023_003DzeelgtjiMbn2Y, List<Point3D>> _0023_003DzlCm_lJD6faPHHpr23A_003D_003D, bool _0023_003DzTymA54q3SWU7, HashSet<Tuple<int, int>> _0023_003Dz7b1_EkFXtnHn, HashSet<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>> _0023_003Dzj0U7nuNL7GBJ, List<ICurve> _0023_003DzeJW3Kznumb_0024KMmTj0g_003D_003D, List<ICurve> _0023_003DzFXfiSiU0v8GegCcxtv_0024_jB8_003D, List<ICurve> _0023_003Dz_OwltpbLxtOEKj6RZ_8Foeg_003D)
	{
		bool result = false;
		for (int i = 0; i < _0023_003DzWf9pzKFDPeOw.Length; i++)
		{
			Surface._0023_003Dz2u_3iw7LP_ic[] array = _0023_003DzWf9pzKFDPeOw[i];
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D == null)
				{
					Surface.Reparametrize(array[j]._0023_003Dz4wZe_0024Xg_003D, out array[j]._0023_003Dz2AZ_kpw_003D, out array[j]._0023_003Dza2Pq9PQ_003D, out array[j]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
				}
				Surface _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D = array[j]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
				List<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>> list = new List<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>>();
				_0023_003Dzk0sekCclUGst._0023_003Dz3CnW_YfpJsRK(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzqjniGGF9kvbc, i, _0023_003Dzg1mu9hOJIYwq, _0023_003DzPsHFxZf6VuL6, out var _0023_003DzTmhgNwFiSUUdfHgPqA_003D_003D, _0023_003Dzjm4D0qYZNBEL: false, _0023_003DzTymA54q3SWU7, _0023_003Dz7b1_EkFXtnHn, j, _0023_003DzjfyCbcaQyzau, array[j]._0023_003DzZ8DVrAfDB6VE7Gu9_0024Jl7_0024Dg_003D, array[j]._0023_003Dz4wZe_0024Xg_003D, _0023_003DzeJW3Kznumb_0024KMmTj0g_003D_003D, _0023_003Dz_OwltpbLxtOEKj6RZ_8Foeg_003D, _0023_003DzFXfiSiU0v8GegCcxtv_0024_jB8_003D, list, _0023_003Dzj0U7nuNL7GBJ);
				_0023_003DzKfMGQQU_003D _0023_003DzwXmQEC4_003D = new _0023_003DzKfMGQQU_003D
				{
					_0023_003DzBLJ2fdI_003D = _0023_003DzjfyCbcaQyzau,
					_0023_003DzLJVtPYc_003D = i,
					_0023_003DzVYqYlD94dR8lRmB4iw_003D_003D = j
				};
				foreach (_0023_003DzKfMGQQU_003D key2 in _0023_003DzTmhgNwFiSUUdfHgPqA_003D_003D.Keys)
				{
					Surface _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2 = _0023_003Dzg1mu9hOJIYwq[key2._0023_003DzBLJ2fdI_003D][key2._0023_003DzLJVtPYc_003D][key2._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
					_0023_003DzeelgtjiMbn2Y key = new _0023_003DzeelgtjiMbn2Y(_0023_003DzwXmQEC4_003D, key2);
					bool flag = _0023_003DzlCm_lJD6faPHHpr23A_003D_003D.ContainsKey(key);
					List<Point3D> collection = (flag ? _0023_003DzlCm_lJD6faPHHpr23A_003D_003D[key] : new List<Point3D>());
					List<Point3D> list2 = new List<Point3D>();
					_0023_003Dzk0sekCclUGst._0023_003Dz2HQ0TbeXoMdaW6Sxxg_003D_003D(_0023_003DzTmhgNwFiSUUdfHgPqA_003D_003D[key2], _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, Math.Min(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D._0023_003DzVx1luJEZaaC7().Diagonal, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2._0023_003DzVx1luJEZaaC7().Diagonal), _0023_003DzPsHFxZf6VuL6, true, list2);
					List<Point3D> list3 = new List<Point3D>(collection);
					_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.ControlBoundingBox(out var min, out var max);
					_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2.ControlBoundingBox(out var min2, out var max2);
					Point3D intersMin;
					Point3D intersMax;
					Size3D size3D = Utility.IntersectionBox(min, max, min2, max2, out intersMin, out intersMax);
					foreach (Point3D item in list2)
					{
						if (((InitialPoint)item)._0023_003DzuI5Ekdc_003D != -1 && ((InitialPoint)item)._0023_003DzuI5Ekdc_003D != -2)
						{
							Surface._0023_003DzbIDY9BOTPqfc(item, list3, size3D.Diagonal, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, _0023_003DzXj5EmoITPwYy: true);
						}
						else
						{
							Surface._0023_003DzL0ZtQjAb0Ml99zk0lg_003D_003D(item, list3, size3D.Diagonal, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2);
						}
					}
					if (list3.Count > 0)
					{
						result = true;
						if (!flag)
						{
							_0023_003DzlCm_lJD6faPHHpr23A_003D_003D.Add(key, list3);
							_0023_003Dzj0U7nuNL7GBJ.Remove(new Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>(key._0023_003DzTGRzgYPVC4qM, key._0023_003DzDb0c2BCwQPLH));
						}
						else
						{
							_0023_003DzlCm_lJD6faPHHpr23A_003D_003D[key] = list3;
						}
						if (_0023_003DzTymA54q3SWU7)
						{
							return true;
						}
					}
				}
				foreach (Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D> item2 in list)
				{
					_0023_003Dzj0U7nuNL7GBJ.Remove(item2);
				}
			}
		}
		return result;
	}

	private static bool _0023_003DzGck_dz7MMapt(Brep _0023_003DzqjniGGF9kvbc, Brep _0023_003Dzk0sekCclUGst, int _0023_003Dz4q020iPVK_uE, Vector3D _0023_003DzPsHFxZf6VuL6, Surface._0023_003Dz2u_3iw7LP_ic[][][] _0023_003DzWf9pzKFDPeOw, Surface._0023_003Dz2u_3iw7LP_ic[][] _0023_003Dzg1mu9hOJIYwq, ref Dictionary<_0023_003DzeelgtjiMbn2Y, List<Point3D>> _0023_003DzlCm_lJD6faPHHpr23A_003D_003D, bool _0023_003DzTymA54q3SWU7, HashSet<Tuple<int, int>> _0023_003Dz7b1_EkFXtnHn, HashSet<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>> _0023_003Dzj0U7nuNL7GBJ, List<ICurve> _0023_003DzeJW3Kznumb_0024KMmTj0g_003D_003D, List<ICurve> _0023_003DzFXfiSiU0v8GegCcxtv_0024_jB8_003D, List<ICurve> _0023_003Dz_OwltpbLxtOEKj6RZ_8Foeg_003D)
	{
		bool result = false;
		for (int i = 0; i < _0023_003Dzg1mu9hOJIYwq.Length; i++)
		{
			Surface._0023_003Dz2u_3iw7LP_ic[] array = _0023_003Dzg1mu9hOJIYwq[i];
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D == null)
				{
					Surface.Reparametrize(array[j]._0023_003Dz4wZe_0024Xg_003D, out array[j]._0023_003Dz2AZ_kpw_003D, out array[j]._0023_003Dza2Pq9PQ_003D, out array[j]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
				}
				Surface _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D = array[j]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
				List<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>> list = new List<Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>>();
				_0023_003DzqjniGGF9kvbc._0023_003Dz3CnW_YfpJsRK(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003Dzk0sekCclUGst, i, _0023_003DzWf9pzKFDPeOw, _0023_003DzPsHFxZf6VuL6, out var _0023_003DzTmhgNwFiSUUdfHgPqA_003D_003D, _0023_003Dzjm4D0qYZNBEL: true, _0023_003DzTymA54q3SWU7, _0023_003Dz7b1_EkFXtnHn, j, _0023_003Dz4q020iPVK_uE, array[j]._0023_003DzZ8DVrAfDB6VE7Gu9_0024Jl7_0024Dg_003D, array[j]._0023_003Dz4wZe_0024Xg_003D, _0023_003DzeJW3Kznumb_0024KMmTj0g_003D_003D, _0023_003DzFXfiSiU0v8GegCcxtv_0024_jB8_003D, _0023_003Dz_OwltpbLxtOEKj6RZ_8Foeg_003D, list, _0023_003Dzj0U7nuNL7GBJ);
				_0023_003DzKfMGQQU_003D _0023_003DzAaoZ6Qk_003D = new _0023_003DzKfMGQQU_003D
				{
					_0023_003DzBLJ2fdI_003D = _0023_003Dz4q020iPVK_uE,
					_0023_003DzLJVtPYc_003D = i,
					_0023_003DzVYqYlD94dR8lRmB4iw_003D_003D = j
				};
				foreach (_0023_003DzKfMGQQU_003D key2 in _0023_003DzTmhgNwFiSUUdfHgPqA_003D_003D.Keys)
				{
					Surface _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2 = _0023_003DzWf9pzKFDPeOw[key2._0023_003DzBLJ2fdI_003D][key2._0023_003DzLJVtPYc_003D][key2._0023_003DzVYqYlD94dR8lRmB4iw_003D_003D]._0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D;
					_0023_003DzeelgtjiMbn2Y key = new _0023_003DzeelgtjiMbn2Y(key2, _0023_003DzAaoZ6Qk_003D);
					bool flag = _0023_003DzlCm_lJD6faPHHpr23A_003D_003D.ContainsKey(key);
					List<Point3D> list2 = (flag ? _0023_003DzlCm_lJD6faPHHpr23A_003D_003D[key] : new List<Point3D>());
					_0023_003DzqjniGGF9kvbc._0023_003Dz2HQ0TbeXoMdaW6Sxxg_003D_003D(_0023_003DzTmhgNwFiSUUdfHgPqA_003D_003D[key2], _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, Math.Max(_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2._0023_003DzVx1luJEZaaC7().Diagonal, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D._0023_003DzVx1luJEZaaC7().Diagonal), _0023_003DzPsHFxZf6VuL6, false, list2);
					List<Point3D> list3 = new List<Point3D>();
					_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2.ControlBoundingBox(out var min, out var max);
					_0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D.ControlBoundingBox(out var min2, out var max2);
					Point3D intersMin;
					Point3D intersMax;
					Size3D size3D = Utility.IntersectionBox(min, max, min2, max2, out intersMin, out intersMax);
					foreach (Point3D item in list2)
					{
						if (((InitialPoint)item)._0023_003DzuI5Ekdc_003D != -1 && ((InitialPoint)item)._0023_003DzuI5Ekdc_003D != -2)
						{
							Surface._0023_003DzbIDY9BOTPqfc(item, list3, size3D.Diagonal, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D, _0023_003DzXj5EmoITPwYy: true);
						}
						else
						{
							Surface._0023_003DzL0ZtQjAb0Ml99zk0lg_003D_003D(item, list3, size3D.Diagonal, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D2, _0023_003DzpB407jzRj7N_00241yaMRsYSupw_003D);
						}
					}
					if (list2.Count > 0)
					{
						result = true;
						if (!flag)
						{
							_0023_003DzlCm_lJD6faPHHpr23A_003D_003D.Add(key, list3);
							_0023_003Dzj0U7nuNL7GBJ.Remove(new Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D>(key._0023_003DzTGRzgYPVC4qM, key._0023_003DzDb0c2BCwQPLH));
						}
						if (_0023_003DzTymA54q3SWU7)
						{
							return true;
						}
					}
				}
				foreach (Tuple<_0023_003DzKfMGQQU_003D, _0023_003DzKfMGQQU_003D> item2 in list)
				{
					_0023_003Dzj0U7nuNL7GBJ.Remove(item2);
				}
			}
		}
		return result;
	}

	internal static Brep[] _0023_003Dz1A9iP9WIToC5(ICurve _0023_003DzHgrHIfhYCh4p, Region _0023_003DzqT6kZ6g_003D, double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, bool _0023_003DzjepEGXc_003D, sweepMethodType _0023_003Dzjy_YX_0024o_003D)
	{
		ICurve curve = (ICurve)_0023_003DzqT6kZ6g_003D.ContourList[0].Clone();
		IList<ICurve> list = null;
		if (_0023_003DzqT6kZ6g_003D.ContourList.Count > 1)
		{
			list = new List<ICurve>();
			for (int i = 1; i < _0023_003DzqT6kZ6g_003D.ContourList.Count; i++)
			{
				list.Add((ICurve)_0023_003DzqT6kZ6g_003D.ContourList[i].Clone());
			}
		}
		if (Vector3D.Dot(_0023_003DzqT6kZ6g_003D.Plane.AxisZ, _0023_003DzHgrHIfhYCh4p.StartTangent) < 1E-06)
		{
			curve.Reverse();
			int num = 0;
			while (list != null && num < list.Count)
			{
				list[num].Reverse();
				num++;
			}
		}
		return _0023_003Dz1A9iP9WIToC5(_0023_003DzHgrHIfhYCh4p, curve, list, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzbErHvVw_003D: true, _0023_003DzjepEGXc_003D, _0023_003Dzjy_YX_0024o_003D);
	}

	internal static Brep[] _0023_003Dz1A9iP9WIToC5(ICurve _0023_003DzHgrHIfhYCh4p, ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, bool _0023_003DzbErHvVw_003D, bool _0023_003DzjepEGXc_003D, sweepMethodType _0023_003Dzjy_YX_0024o_003D)
	{
		Utility._0023_003DzDE7mL_712NEZeE5wpw_003D_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzHgrHIfhYCh4p, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzbErHvVw_003D, _0023_003DzGb8kdyZ1x5nj: true);
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			foreach (ICurve item in _0023_003DzWaFlkhfmYCja)
			{
				Utility._0023_003DzDE7mL_712NEZeE5wpw_003D_003D(item, _0023_003DzHgrHIfhYCh4p, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzbErHvVw_003D, _0023_003DzGb8kdyZ1x5nj: true);
			}
		}
		Utility._0023_003Dzdh_4OQddxCSDDYZ27Q_003D_003D(_0023_003DzHgrHIfhYCh4p, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzFSLBkBecx_0024NX: true, out var _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, _0023_003Dz6SBnzmNnw6lO: false);
		ICurve curve = (ICurve)_0023_003Dz_SqBXz8_003D.Clone();
		ICurve[] array = null;
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			array = new ICurve[_0023_003DzWaFlkhfmYCja.Count];
			for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
			{
				array[i] = (ICurve)_0023_003DzWaFlkhfmYCja[i].Clone();
			}
		}
		double tol = Math.Max(_0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D * Utility._0023_003DzxhnLabVjXjPg, Utility._0023_003DzheSR8QM7q9ya);
		Plane _0023_003DzStUznlUnGSG = null;
		List<Brep> list = new List<Brep>();
		List<ICurve> list2 = new List<ICurve>();
		bool flag = false;
		for (int j = 0; j < _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length; j++)
		{
			ICurve curve2 = _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[j];
			ICurve curve3 = curve2;
			if (_0023_003DzjepEGXc_003D)
			{
				if (!flag)
				{
					list2.Clear();
				}
				int num = ((j < _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length - 1) ? (j + 1) : (-1));
				bool flag2 = num != -1 && Vector3D.AreCoincident(curve2.EndTangent, _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[num].StartTangent, tol);
				if (list2.Count == 0 || flag2 || flag)
				{
					list2.Add(curve2);
					flag = flag2;
				}
				if (flag2)
				{
					continue;
				}
				if (list2.Count > 1)
				{
					curve3 = new CompositeCurve(list2, sortAndOrient: false);
				}
			}
			Brep[] array2 = null;
			if (curve3 is Line)
			{
				array2 = new Brep[1] { _0023_003DzdncxQYEu8hc00O7aiw_003D_003D(_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, j, curve, array, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzbErHvVw_003D, _0023_003DzHgrHIfhYCh4p.IsClosed, _0023_003DzjepEGXc_003D) };
			}
			else if (curve3 is Arc)
			{
				array2 = ((!_0023_003DzjepEGXc_003D) ? _0023_003DzRLbt9uDCT0W7yo59pg_003D_003D(_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, j, curve, array, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D / 10.0, _0023_003DzbErHvVw_003D, _0023_003DzHgrHIfhYCh4p.IsClosed, _0023_003DzjepEGXc_003D) : _0023_003Dz4BpCEcd0hr02Aku4Cw_003D_003D(_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, j, curve, array, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzbErHvVw_003D, _0023_003DzHgrHIfhYCh4p.IsClosed, _0023_003DzjepEGXc_003D));
			}
			else
			{
				int _0023_003DzAddCv_o_003D = j - (curve3.GetIndividualCurves().Length - 1);
				array2 = new Brep[1] { _0023_003DzriHaSLBwtW75(_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, _0023_003DzAddCv_o_003D, curve3, curve, array, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzbErHvVw_003D || _0023_003DzHgrHIfhYCh4p.IsClosed, _0023_003DzjepEGXc_003D, _0023_003Dzjy_YX_0024o_003D, _0023_003DzHgrHIfhYCh4p.IsClosed) };
			}
			if (curve3 is CompositeCurve)
			{
				CompositeCurve compositeCurve = (CompositeCurve)curve3;
				for (int k = 0; k < compositeCurve.CurveList.Count; k++)
				{
					ICurve _0023_003DzHXbzvx8ZY9nt = null;
					if (k + 1 < compositeCurve.CurveList.Count)
					{
						_0023_003DzHXbzvx8ZY9nt = compositeCurve.CurveList[k + 1];
					}
					else if (j + 1 < _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length)
					{
						_0023_003DzHXbzvx8ZY9nt = _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[j + 1];
					}
					if (array != null)
					{
						for (int l = 0; l < array.Length; l++)
						{
							Utility._0023_003DzUF5dE52DL3PQ(array[l], compositeCurve.CurveList[k], _0023_003DzHXbzvx8ZY9nt, ref _0023_003DzStUznlUnGSG, _0023_003Dzjy_YX_0024o_003D, _0023_003Dz3fpuiiI_003D: false);
						}
					}
					Utility._0023_003DzUF5dE52DL3PQ(curve, compositeCurve.CurveList[k], _0023_003DzHXbzvx8ZY9nt, ref _0023_003DzStUznlUnGSG, _0023_003Dzjy_YX_0024o_003D, _0023_003Dz3fpuiiI_003D: true);
				}
			}
			else
			{
				ICurve _0023_003DzHXbzvx8ZY9nt2 = null;
				if (j + 1 < _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length)
				{
					_0023_003DzHXbzvx8ZY9nt2 = _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D[j + 1];
				}
				if (array != null)
				{
					for (int m = 0; m < array.Length; m++)
					{
						Utility._0023_003DzUF5dE52DL3PQ(array[m], curve2, _0023_003DzHXbzvx8ZY9nt2, ref _0023_003DzStUznlUnGSG, _0023_003Dzjy_YX_0024o_003D, _0023_003Dz3fpuiiI_003D: false);
					}
				}
				Utility._0023_003DzUF5dE52DL3PQ(curve, curve2, _0023_003DzHXbzvx8ZY9nt2, ref _0023_003DzStUznlUnGSG, _0023_003Dzjy_YX_0024o_003D, _0023_003Dz3fpuiiI_003D: true);
			}
			if (array2 == null || array2.Length == 0)
			{
				continue;
			}
			if (list.Count == 0)
			{
				list.AddRange(array2);
			}
			else if (_0023_003DzjepEGXc_003D)
			{
				Brep brep = _0023_003Dz7SSjHlM9sQ2_gkrsbg_003D_003D(list[list.Count - 1], array2[0]);
				if (brep == null)
				{
					return null;
				}
				list[list.Count - 1] = brep;
			}
			else
			{
				list.AddRange(array2);
			}
		}
		return list.ToArray();
	}

	internal static Brep _0023_003DzOWhWBJ1MYpBx(ICurve _0023_003DzHgrHIfhYCh4p, ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, bool _0023_003DzbErHvVw_003D, sweepMethodType _0023_003Dzjy_YX_0024o_003D, bool _0023_003DztQU_Iy7aFgwfb7bZKg_003D_003D)
	{
		Utility._0023_003Dzdh_4OQddxCSDDYZ27Q_003D_003D(_0023_003DzHgrHIfhYCh4p, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, _0023_003DzFSLBkBecx_0024NX: true, out var _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, _0023_003DztQU_Iy7aFgwfb7bZKg_003D_003D);
		ICurve curve = (ICurve)_0023_003Dz_SqBXz8_003D.Clone();
		List<ICurve> list = new List<ICurve>();
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			foreach (ICurve item in _0023_003DzWaFlkhfmYCja)
			{
				list.Add((ICurve)item.Clone());
			}
		}
		bool flag = !_0023_003DzHgrHIfhYCh4p.IsClosed && _0023_003DzbErHvVw_003D;
		List<Point3D> list2 = new List<Point3D>();
		List<Edge> _0023_003DzU3hosSAzkxO = new List<Edge>();
		List<Face> list3 = new List<Face>();
		List<Face[]> list4 = new List<Face[]>();
		Loop[] array = new Loop[list.Count + 1];
		Loop[] array2 = new Loop[list.Count + 1];
		double tol = Surface._0023_003DzWu3S5IPxj3tfF03Eyw_003D_003D(new ICurve[1] { curve }).Diagonal * 0.001;
		curve.IsPlanar(tol, out var plane);
		for (int i = 0; i < _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length; i++)
		{
			_0023_003Dz8sOQV_GDM2Op(_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, i, curve, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, list2.Count, _0023_003DzU3hosSAzkxO.Count, _0023_003Dzjy_YX_0024o_003D, out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003DzU3hosSAzkxO2, out var _0023_003DzpPOEJqcAh7Lr, out var _0023_003Dz1Dom_0024Tie1nm_, out var _0023_003DzOAlPmgi9yzUJ);
			list2.AddRange(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzelAtL_E7coVwIz5fbpnnJWnCWejt));
			_0023_003DzU3hosSAzkxO.AddRange(_0023_003DzU3hosSAzkxO2.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzVMSE7rEdX_mLgLNcy7cLz2rTH_ZJ));
			list3.AddRange(_0023_003DzpPOEJqcAh7Lr);
			if (!_0023_003DzHgrHIfhYCh4p.IsClosed)
			{
				_ = _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.LongLength;
			}
			if (i == 0)
			{
				array2[0] = new Loop(_0023_003Dz1Dom_0024Tie1nm_, sense: false);
			}
			if (i == _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length - 1)
			{
				array[0] = new Loop(_0023_003DzOAlPmgi9yzUJ);
			}
		}
		if (_0023_003DzHgrHIfhYCh4p.IsClosed)
		{
			Face[] _0023_003DzpPOEJqcAh7Lr2 = list3.ToArray();
			_0023_003Dz4o8T5ypHXQtJ(list2.Count, _0023_003DzU3hosSAzkxO.Count, ref _0023_003DzU3hosSAzkxO, ref _0023_003DzpPOEJqcAh7Lr2);
		}
		for (int j = 0; j < list.Count; j++)
		{
			int count = list4.Count;
			for (int k = 0; k < _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length; k++)
			{
				_0023_003Dz8sOQV_GDM2Op(_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, k, list[j], _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, list2.Count, _0023_003DzU3hosSAzkxO.Count, _0023_003Dzjy_YX_0024o_003D, out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D2, out var _0023_003DzU3hosSAzkxO3, out var _0023_003DzpPOEJqcAh7Lr3, out var _0023_003Dz1Dom_0024Tie1nm_2, out var _0023_003DzOAlPmgi9yzUJ2);
				list2.AddRange(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D2.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz4qNez3F6eNfUibOJEEufUAijDfNX));
				_0023_003DzU3hosSAzkxO.AddRange(_0023_003DzU3hosSAzkxO3.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz815M7ulVGJv8zwPZmQ4amssHY3rb));
				if (_0023_003DzHgrHIfhYCh4p.IsClosed)
				{
					list4.Add(_0023_003DzpPOEJqcAh7Lr3);
				}
				else
				{
					list3.AddRange(_0023_003DzpPOEJqcAh7Lr3);
				}
				if (!_0023_003DzHgrHIfhYCh4p.IsClosed)
				{
					_ = _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.LongLength;
				}
				if (k == 0)
				{
					array2[j + 1] = new Loop(_0023_003Dz1Dom_0024Tie1nm_2, sense: false);
				}
				if (k == _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D.Length - 1)
				{
					array[j + 1] = new Loop(_0023_003DzOAlPmgi9yzUJ2);
				}
			}
			if (_0023_003DzHgrHIfhYCh4p.IsClosed)
			{
				for (int l = count; l < list4.Count; l++)
				{
					Face[] _0023_003DzpPOEJqcAh7Lr4 = list4[l];
					_0023_003Dz4o8T5ypHXQtJ(list2.Count, _0023_003DzU3hosSAzkxO.Count, ref _0023_003DzU3hosSAzkxO, ref _0023_003DzpPOEJqcAh7Lr4);
				}
			}
		}
		if (flag)
		{
			curve.IsPlanar(tol, out var plane2);
			PlanarSurf _0023_003DzjGoXlKw_003D = new PlanarSurf((Point3D)list2[0].Clone(), plane.AxisZ, plane.AxisX, list3.Count);
			PlanarSurf _0023_003Dz1FonMC4_003D = new PlanarSurf((Point3D)curve.StartPoint.Clone(), plane2.AxisZ, plane2.AxisX, list3.Count + 1);
			_0023_003Dzcg4Fe1KpKEim(list3, _0023_003DzjGoXlKw_003D, _0023_003Dz1FonMC4_003D, array2, array, _0023_003Dzbu8BV15Qqzan: false);
		}
		return new Brep(list2.ToArray(), _0023_003DzU3hosSAzkxO.ToArray(), list3.ToArray(), list4.ToArray(), _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D);
	}

	private static Brep[] _0023_003Dz4BpCEcd0hr02Aku4Cw_003D_003D(ICurve[] _0023_003DzHgrHIfhYCh4p, int _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, bool _0023_003DzbErHvVw_003D, bool _0023_003DzHbb9s4FIaFfq, bool _0023_003DzjepEGXc_003D)
	{
		Arc arc = (Arc)_0023_003DzHgrHIfhYCh4p[_0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D];
		Plane[] array = new Plane[2];
		double num = Utility._0023_003DzgP4qC37WNH1g(_0023_003Dz_SqBXz8_003D);
		Utility._0023_003DzaJ_0024f2lo0_00243GgxkJ85CDhnYs_003D(_0023_003DzHgrHIfhYCh4p, _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, _0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, num / 2.0, out var _0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D, out var _0023_003DzYsh7vg3YvPj33Pvt8w_003D_003D, out array[0], out array[1], out var _0023_003Dzx5RboRHsRXS, out var _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D, _0023_003DzHbb9s4FIaFfq);
		Brep brep = null;
		ICurve curve = new CompositeCurve(arc);
		if (array[0] == null && array[1] == null)
		{
			_0023_003Dzx5RboRHsRXS = (ICurve)_0023_003Dz_SqBXz8_003D.Clone();
			if (_0023_003DzWaFlkhfmYCja != null)
			{
				_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D = new ICurve[_0023_003DzWaFlkhfmYCja.Count];
				for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
				{
					_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D[i] = (ICurve)_0023_003DzWaFlkhfmYCja[i].Clone();
				}
			}
			else
			{
				_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D = _0023_003DzWaFlkhfmYCja;
			}
			brep = _0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(_0023_003Dzx5RboRHsRXS, _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D, 0.0, arc.AngleInRadians, arc.Plane.AxisZ, arc.Center, _0023_003DzjepEGXc_003D || _0023_003DzbErHvVw_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
			brep.FlipNormal();
		}
		else
		{
			Utility._0023_003Dz4DvtTTqN1dB7(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, arc.AngleInRadians / 2.0, arc, out _0023_003Dzx5RboRHsRXS, out _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D);
			Arc arc2 = new Arc(arc.Plane, arc.Center, arc.Radius, arc.Domain.Mid, arc.Domain.Low);
			curve = new CompositeCurve(arc2);
			_0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D.Reverse();
			if (array[0] != null)
			{
				((CompositeCurve)curve).CurveList.Add(_0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D);
			}
			if (((CompositeCurve)curve).CurveList.Count > 1)
			{
				curve = Surface._0023_003DzKpqCbi118vVrwyeGTQ_003D_003D(new List<ICurve> { curve })[0];
				brep = _0023_003DzOWhWBJ1MYpBx(curve, _0023_003Dzx5RboRHsRXS, _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003DzbErHvVw_003D: true, sweepMethodType.RotationMinimizingFrames, _0023_003DztQU_Iy7aFgwfb7bZKg_003D_003D: true);
				brep.FlipNormal();
			}
			else
			{
				brep = _0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(_0023_003Dzx5RboRHsRXS, _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D, 0.0, arc2.AngleInRadians, arc2.Plane.AxisZ, arc2.Center, _0023_003DzbErHvVw_003D: true, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
			}
		}
		bool flag = _0023_003Dz7mr_4Z4_003D(brep, new Plane[2]
		{
			array[0],
			null
		}, _0023_003DzjepEGXc_003D || _0023_003DzbErHvVw_003D);
		if (array[0] == null && array[1] == null)
		{
			return new Brep[1] { brep };
		}
		Arc arc3 = new Arc(arc.Plane, arc.Center, arc.Radius, arc.Domain.Mid, arc.Domain.High);
		ICurve curve2 = new CompositeCurve(arc3);
		Brep brep2;
		if (array[1] != null)
		{
			((CompositeCurve)curve2).CurveList.Add(_0023_003DzYsh7vg3YvPj33Pvt8w_003D_003D);
			curve2 = Surface._0023_003DzKpqCbi118vVrwyeGTQ_003D_003D(new List<ICurve> { curve2 })[0];
			brep2 = _0023_003DzOWhWBJ1MYpBx(curve2, _0023_003Dzx5RboRHsRXS, _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003DzbErHvVw_003D: true, sweepMethodType.RotationMinimizingFrames, _0023_003DztQU_Iy7aFgwfb7bZKg_003D_003D: true);
		}
		else
		{
			brep2 = _0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(_0023_003Dzx5RboRHsRXS, _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D, 0.0, arc3.AngleInRadians, arc3.Plane.AxisZ, arc3.Center, _0023_003DzbErHvVw_003D: true, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
			brep.FlipNormal();
		}
		if (array[1] == null && !_0023_003DzbErHvVw_003D)
		{
			Face[] array2 = brep2.Faces;
			Edge[] edges = brep2.Edges;
			for (int j = 0; j < edges.Length; j++)
			{
				edges[j].Parents = null;
			}
			Array.Resize(ref array2, array2.Length - 1);
			brep2.Faces = array2;
		}
		flag &= _0023_003Dz7mr_4Z4_003D(brep2, new Plane[2]
		{
			null,
			array[1]
		}, _0023_003DzjepEGXc_003D || _0023_003DzbErHvVw_003D);
		Brep brep3 = null;
		if (brep2 != null)
		{
			if (flag)
			{
				brep3 = _0023_003Dz7SSjHlM9sQ2_gkrsbg_003D_003D(brep, brep2);
			}
			if (brep3 == null && !_0023_003DzjepEGXc_003D)
			{
				return new Brep[2] { brep, brep2 };
			}
		}
		return new Brep[1] { brep3 };
	}

	private static Brep[] _0023_003DzRLbt9uDCT0W7yo59pg_003D_003D(ICurve[] _0023_003DzHgrHIfhYCh4p, int _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, bool _0023_003DzbErHvVw_003D, bool _0023_003DzHbb9s4FIaFfq, bool _0023_003DzjepEGXc_003D)
	{
		Plane[] array = new Plane[2];
		Utility._0023_003Dzi_uJo1YauacTvNQ2CLEP2dc_003D(_0023_003DzHgrHIfhYCh4p, _0023_003Dz5C_0024cyD9lhEyKEXb3Cw_003D_003D, _0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, out var _0023_003Dz5q4tZUlCeE1_P3aNGjVSGDY_003D, out var _0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D, out array[0], out array[1], out var _0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, out var _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D, _0023_003DzHbb9s4FIaFfq, _0023_003DzqZLpJx9EBl4E2J4o3A9hYdM_003D: false);
		bool _0023_003DzbErHvVw_003D2 = _0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D != null || _0023_003DzjepEGXc_003D || _0023_003DzbErHvVw_003D;
		Brep brep = _0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(_0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D, 0.0, _0023_003Dz5q4tZUlCeE1_P3aNGjVSGDY_003D.AngleInRadians, _0023_003Dz5q4tZUlCeE1_P3aNGjVSGDY_003D.Plane.AxisZ, _0023_003Dz5q4tZUlCeE1_P3aNGjVSGDY_003D.Center, _0023_003DzbErHvVw_003D2, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
		bool flag = _0023_003Dz7mr_4Z4_003D(brep, new Plane[2]
		{
			array[0],
			(_0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D == null) ? array[1] : null
		}, _0023_003DzjepEGXc_003D || _0023_003DzbErHvVw_003D);
		if (_0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D == null)
		{
			brep.FlipNormal();
			return new Brep[1] { brep };
		}
		if (array[0] == null && !_0023_003DzbErHvVw_003D)
		{
			Face[] array2 = brep.Faces;
			Edge[] edges = brep.Edges;
			for (int i = 0; i < edges.Length; i++)
			{
				edges[i].Parents = null;
			}
			Array.Resize(ref array2, array2.Length - 1);
			brep.Faces = array2;
		}
		Brep brep2 = _0023_003Dz6nLyC_8IbDEEREIvLvK4CBo_003D(_0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D, 0.0, _0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D.AngleInRadians, _0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D.Plane.AxisZ, _0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D.Center, _0023_003DzbErHvVw_003D2, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
		brep2.FlipNormal();
		if (array[1] == null && !_0023_003DzbErHvVw_003D)
		{
			Face[] array3 = brep2.Faces;
			Edge[] edges = brep2.Edges;
			for (int i = 0; i < edges.Length; i++)
			{
				edges[i].Parents = null;
			}
			Array.Resize(ref array3, array3.Length - 1);
			brep2.Faces = array3;
		}
		flag &= _0023_003Dz7mr_4Z4_003D(brep2, new Plane[2]
		{
			null,
			array[1]
		}, _0023_003DzjepEGXc_003D || _0023_003DzbErHvVw_003D);
		Brep brep3 = null;
		if (brep2 != null)
		{
			if (flag)
			{
				brep3 = _0023_003Dz7SSjHlM9sQ2_gkrsbg_003D_003D(brep, brep2);
			}
			if (brep3 == null && !_0023_003DzjepEGXc_003D)
			{
				return new Brep[2] { brep, brep2 };
			}
		}
		return new Brep[1] { brep3 };
	}

	private static Brep _0023_003DzriHaSLBwtW75(ICurve[] _0023_003DzuJ_0024KGvKEaZDc, int _0023_003DzAddCv_o_003D, ICurve _0023_003DzHgrHIfhYCh4p, ICurve _0023_003DzmPc2IzxmGflkhcQ2JA_003D_003D, ICurve[] _0023_003DzBAznzPo3w0TAF3vOBg_003D_003D, double _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, bool _0023_003DzbErHvVw_003D, bool _0023_003DzjepEGXc_003D, sweepMethodType _0023_003Dzjy_YX_0024o_003D, bool _0023_003DzHbb9s4FIaFfq)
	{
		Plane[] array = new Plane[2];
		ICurve curve = null;
		ICurve curve2 = null;
		ICurve curve3 = (ICurve)_0023_003DzHgrHIfhYCh4p.Clone();
		ICurve curve4 = (ICurve)_0023_003DzmPc2IzxmGflkhcQ2JA_003D_003D.Clone();
		ICurve[] array2 = null;
		if (_0023_003DzBAznzPo3w0TAF3vOBg_003D_003D != null)
		{
			array2 = _0023_003DzBAznzPo3w0TAF3vOBg_003D_003D.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzUJxIL65txiAkccdTAQ6nWsQ_003D).ToArray();
		}
		bool flag = false;
		if (curve3 is CompositeCurve)
		{
			CompositeCurve compositeCurve = (CompositeCurve)curve3;
			Plane _0023_003DzoiaZ_4eSUI1q;
			if (compositeCurve.CurveList[0] is Line)
			{
				double _0023_003DzC5YR9r5C06bj = Utility._0023_003DzgP4qC37WNH1g(curve4);
				Utility._0023_003DzaJ_0024f2lo0_00243GgxkJ85CDhnYs_003D(_0023_003DzuJ_0024KGvKEaZDc, _0023_003DzAddCv_o_003D, curve4, array2, _0023_003DzC5YR9r5C06bj, out var _0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D, out var _0023_003DzYsh7vg3YvPj33Pvt8w_003D_003D, out array[0], out _0023_003DzoiaZ_4eSUI1q, out var _0023_003Dzx5RboRHsRXS, out var _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D, _0023_003DzHbb9s4FIaFfq);
				Line line = new Line(_0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D.StartPoint, _0023_003DzYsh7vg3YvPj33Pvt8w_003D_003D.EndPoint);
				if (array[0] != null)
				{
					curve = line;
					compositeCurve.CurveList.RemoveAt(0);
					flag = true;
				}
				curve4 = _0023_003Dzx5RboRHsRXS;
				array2 = _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D?.ToArray();
			}
			else if (compositeCurve.CurveList[0] is Arc)
			{
				double _0023_003DzC5YR9r5C06bj2 = Utility._0023_003DzgP4qC37WNH1g(curve4);
				Utility._0023_003DzaJ_0024f2lo0_00243GgxkJ85CDhnYs_003D(_0023_003DzuJ_0024KGvKEaZDc, _0023_003DzAddCv_o_003D, curve4, array2, _0023_003DzC5YR9r5C06bj2, out var _0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D2, out var _, out array[0], out var _, out var _0023_003Dzx5RboRHsRXS2, out var _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D2, _0023_003DzHbb9s4FIaFfq);
				if (array[0] != null)
				{
					Arc arc = (Arc)_0023_003DzuJ_0024KGvKEaZDc[_0023_003DzAddCv_o_003D];
					ICurve curve5 = new CompositeCurve(new Arc(arc.Plane, arc.Center, arc.Radius, arc.Domain.t0, arc.Domain.Mid));
					((CompositeCurve)curve5).CurveList.Insert(0, _0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D2);
					curve5 = ((((CompositeCurve)curve5).CurveList.Count <= 1) ? ((CompositeCurve)curve5).CurveList[0] : Surface._0023_003DzKpqCbi118vVrwyeGTQ_003D_003D(new List<ICurve> { curve5 })[0]);
					curve = curve5;
					compositeCurve.CurveList[0] = new Arc(arc.Plane, arc.Center, arc.Radius, arc.Domain.Mid, arc.Domain.t1);
					curve4 = _0023_003Dzx5RboRHsRXS2;
					array2 = _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D2?.ToArray();
				}
			}
			int num = compositeCurve.CurveList.Count - 1;
			if (compositeCurve.CurveList[num] is Line)
			{
				double _0023_003DzC5YR9r5C06bj3 = Utility._0023_003DzgP4qC37WNH1g(curve4);
				int _0023_003DzYnrMIDOkBgMJ = (flag ? (_0023_003DzAddCv_o_003D + num + 1) : (_0023_003DzAddCv_o_003D + num));
				Utility._0023_003DzaJ_0024f2lo0_00243GgxkJ85CDhnYs_003D(_0023_003DzuJ_0024KGvKEaZDc, _0023_003DzYnrMIDOkBgMJ, curve4, array2, _0023_003DzC5YR9r5C06bj3, out var _0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D3, out var _0023_003DzYsh7vg3YvPj33Pvt8w_003D_003D3, out _0023_003DzoiaZ_4eSUI1q, out array[1], out var _, out var _, _0023_003DzHbb9s4FIaFfq);
				if (array[1] != null)
				{
					curve2 = new Line(_0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D3.StartPoint, _0023_003DzYsh7vg3YvPj33Pvt8w_003D_003D3.EndPoint);
					compositeCurve.CurveList.RemoveAt(num);
				}
			}
			else if (compositeCurve.CurveList[num] is Arc)
			{
				double _0023_003DzC5YR9r5C06bj4 = Utility._0023_003DzgP4qC37WNH1g(curve4);
				int _0023_003DzYnrMIDOkBgMJ2 = (flag ? (_0023_003DzAddCv_o_003D + num + 1) : (_0023_003DzAddCv_o_003D + num));
				Utility._0023_003DzaJ_0024f2lo0_00243GgxkJ85CDhnYs_003D(_0023_003DzuJ_0024KGvKEaZDc, _0023_003DzYnrMIDOkBgMJ2, curve4, array2, _0023_003DzC5YR9r5C06bj4, out var _, out var _0023_003DzYsh7vg3YvPj33Pvt8w_003D_003D4, out var _, out array[1], out var _, out var _, curve3.IsClosed);
				if (array[1] != null)
				{
					Arc arc2 = (Arc)_0023_003DzuJ_0024KGvKEaZDc[_0023_003DzAddCv_o_003D + num];
					ICurve curve6 = new CompositeCurve(new Arc(arc2.Plane, arc2.Center, arc2.Radius, arc2.Domain.Mid, arc2.Domain.t1));
					((CompositeCurve)curve6).CurveList.Add(_0023_003DzYsh7vg3YvPj33Pvt8w_003D_003D4);
					curve6 = ((((CompositeCurve)curve6).CurveList.Count <= 1) ? ((CompositeCurve)curve6).CurveList[0] : Surface._0023_003DzKpqCbi118vVrwyeGTQ_003D_003D(new List<ICurve> { curve6 })[0]);
					curve2 = curve6;
					compositeCurve.CurveList[num] = new Arc(arc2.Plane, arc2.Center, arc2.Radius, arc2.Domain.t0, arc2.Domain.Mid);
				}
			}
		}
		Plane _0023_003DzStUznlUnGSG = null;
		Brep brep = null;
		if (curve != null)
		{
			brep = _0023_003DzOWhWBJ1MYpBx(curve, curve4, array2, _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, _0023_003DzbErHvVw_003D: true, _0023_003Dzjy_YX_0024o_003D, _0023_003DztQU_Iy7aFgwfb7bZKg_003D_003D: true);
		}
		Brep brep2 = null;
		if (!(curve3 is CompositeCurve) || ((CompositeCurve)curve3).CurveList.Count > 0)
		{
			if (curve != null)
			{
				ICurve _0023_003DzHXbzvx8ZY9nt = curve3.GetIndividualCurves()[0];
				if (array2 != null)
				{
					for (int i = 0; i < array2.Length; i++)
					{
						Utility._0023_003DzUF5dE52DL3PQ(array2[i], curve, _0023_003DzHXbzvx8ZY9nt, ref _0023_003DzStUznlUnGSG, _0023_003Dzjy_YX_0024o_003D, _0023_003Dz3fpuiiI_003D: false);
					}
				}
				Utility._0023_003DzUF5dE52DL3PQ(curve4, curve, _0023_003DzHXbzvx8ZY9nt, ref _0023_003DzStUznlUnGSG, _0023_003Dzjy_YX_0024o_003D, _0023_003Dz3fpuiiI_003D: true);
			}
			brep2 = _0023_003DzOWhWBJ1MYpBx(curve3, curve4, array2, _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, _0023_003DzbErHvVw_003D: true, _0023_003Dzjy_YX_0024o_003D, _0023_003DztQU_Iy7aFgwfb7bZKg_003D_003D: true);
		}
		Brep brep3 = null;
		if (curve2 != null)
		{
			ICurve[] array3 = ((brep2 != null) ? curve3.GetIndividualCurves() : new ICurve[1] { curve });
			if (array3 != null)
			{
				for (int j = 0; j < array3.Length; j++)
				{
					ICurve curve7 = null;
					curve7 = ((j + 1 >= array3.Length) ? curve2 : array3[j + 1]);
					if (array2 != null)
					{
						for (int k = 0; k < array2.Length; k++)
						{
							Utility._0023_003DzUF5dE52DL3PQ(array2[k], array3[j], curve7, ref _0023_003DzStUznlUnGSG, _0023_003Dzjy_YX_0024o_003D, _0023_003Dz3fpuiiI_003D: false);
						}
					}
					Utility._0023_003DzUF5dE52DL3PQ(curve4, array3[j], curve7, ref _0023_003DzStUznlUnGSG, _0023_003Dzjy_YX_0024o_003D, _0023_003Dz3fpuiiI_003D: true);
				}
			}
			brep3 = _0023_003DzOWhWBJ1MYpBx(curve2, curve4, array2, _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, _0023_003DzbErHvVw_003D: true, _0023_003Dzjy_YX_0024o_003D, _0023_003DztQU_Iy7aFgwfb7bZKg_003D_003D: true);
		}
		if (!_0023_003DzbErHvVw_003D && brep2 == null && brep3 == null && array[1] == null)
		{
			Face[] array4 = brep.Faces;
			Edge[] edges = brep.Edges;
			for (int l = 0; l < edges.Length; l++)
			{
				edges[l].Parents = null;
			}
			Array.Resize(ref array4, array4.Length - 1);
			brep.Faces = array4;
		}
		if (!_0023_003DzbErHvVw_003D && !_0023_003DzHgrHIfhYCh4p.IsClosed && brep == null && array[0] == null)
		{
			Face[] array5 = brep2.Faces;
			Edge[] edges = brep2.Edges;
			for (int l = 0; l < edges.Length; l++)
			{
				edges[l].Parents = null;
			}
			array5[^2] = array5[^1];
			Array.Resize(ref array5, array5.Length - 1);
			brep2.Faces = array5;
		}
		if (!_0023_003DzbErHvVw_003D && !_0023_003DzHgrHIfhYCh4p.IsClosed && brep3 == null && array[1] == null)
		{
			Face[] array6 = brep2.Faces;
			Edge[] edges = brep2.Edges;
			for (int l = 0; l < edges.Length; l++)
			{
				edges[l].Parents = null;
			}
			Array.Resize(ref array6, array6.Length - 1);
			brep2.Faces = array6;
		}
		if (!_0023_003DzbErHvVw_003D && brep2 == null && brep == null && array[0] == null)
		{
			Face[] array7 = brep3.Faces;
			Edge[] edges = brep3.Edges;
			for (int l = 0; l < edges.Length; l++)
			{
				edges[l].Parents = null;
			}
			array7[^2] = array7[^1];
			Array.Resize(ref array7, array7.Length - 1);
			brep3.Faces = array7;
		}
		if (brep != null && !_0023_003Dz7mr_4Z4_003D(brep, new Plane[1] { array[0] }, _0023_003DzjepEGXc_003D || _0023_003DzbErHvVw_003D))
		{
			return null;
		}
		if (brep3 != null && !_0023_003Dz7mr_4Z4_003D(brep3, new Plane[2]
		{
			null,
			array[1]
		}, _0023_003DzjepEGXc_003D || _0023_003DzbErHvVw_003D))
		{
			return null;
		}
		if (brep == null && brep3 == null && !_0023_003Dz7mr_4Z4_003D(brep2, array, _0023_003DzjepEGXc_003D || _0023_003DzbErHvVw_003D))
		{
			return null;
		}
		Brep brep4 = brep2;
		if (brep != null && brep2 != null)
		{
			brep4 = _0023_003Dz7SSjHlM9sQ2_gkrsbg_003D_003D(brep, brep2);
		}
		if (brep4 != null && brep3 != null)
		{
			brep4 = _0023_003Dz7SSjHlM9sQ2_gkrsbg_003D_003D(brep4, brep3);
		}
		else if (brep2 == null)
		{
			brep4 = _0023_003Dz7SSjHlM9sQ2_gkrsbg_003D_003D(brep, brep3);
		}
		return brep4;
	}

	private static Brep _0023_003DzdncxQYEu8hc00O7aiw_003D_003D(ICurve[] _0023_003DzC6SYinZDkKHt, int _0023_003Dz6_Xe0PJWewaZ, ICurve _0023_003Dz06A5WivSSyUp, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, bool _0023_003DzbErHvVw_003D, bool _0023_003DzHbb9s4FIaFfq, bool _0023_003DzjepEGXc_003D)
	{
		Plane[] array = new Plane[2];
		double _0023_003DzC5YR9r5C06bj = Utility._0023_003DzgP4qC37WNH1g(_0023_003Dz06A5WivSSyUp);
		Utility._0023_003DzaJ_0024f2lo0_00243GgxkJ85CDhnYs_003D(_0023_003DzC6SYinZDkKHt, _0023_003Dz6_Xe0PJWewaZ, _0023_003Dz06A5WivSSyUp, _0023_003DzWaFlkhfmYCja, _0023_003DzC5YR9r5C06bj, out var _0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D, out var _0023_003DzYsh7vg3YvPj33Pvt8w_003D_003D, out array[0], out array[1], out var _0023_003Dzx5RboRHsRXS, out var _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D, _0023_003DzHbb9s4FIaFfq);
		Vector3D _0023_003DzYNjcavt9guh = new Vector3D(_0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D.StartPoint, _0023_003DzYsh7vg3YvPj33Pvt8w_003D_003D.EndPoint);
		Brep brep = _0023_003DzXp6eFW3mILyyzxitajgm3U0_003D(_0023_003Dzx5RboRHsRXS, _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D, _0023_003DzYNjcavt9guh, _0023_003Dzbu8BV15Qqzan: false, _0023_003DzbErHvVw_003D || (_0023_003DzHbb9s4FIaFfq && _0023_003DzjepEGXc_003D), _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D);
		_0023_003Dz7mr_4Z4_003D(brep, array, _0023_003DzjepEGXc_003D || _0023_003DzbErHvVw_003D);
		return brep;
	}

	private static bool _0023_003Dz7mr_4Z4_003D(Brep _0023_003DzQUhnjVe9kSO_0024, Plane[] _0023_003DzO846Fq5qmPew, bool _0023_003DzcSSP_dM_003D)
	{
		try
		{
			foreach (Plane plane in _0023_003DzO846Fq5qmPew)
			{
				if (!(plane == null) && _0023_003DzQUhnjVe9kSO_0024._0023_003DzBVSD8WPcX9kp(plane, null, out var _, _0023_003DzcSSP_dM_003D, null) != booleanFailureType.Success)
				{
					return false;
				}
			}
		}
		catch
		{
			return false;
		}
		return true;
	}

	private static void _0023_003Dz8sOQV_GDM2Op(ICurve[] _0023_003DzC6SYinZDkKHt, int _0023_003Dz6_Xe0PJWewaZ, ICurve _0023_003Dz06A5WivSSyUp, double _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, int _0023_003Dz1OARlKY_003D, int _0023_003Dzjt29dMs_003D, sweepMethodType _0023_003Dz0h7AakEIaVwL, out Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out Edge[] _0023_003DzU3hosSAzkxO7, out Face[] _0023_003DzpPOEJqcAh7Lr, out OrientedEdge[] _0023_003Dz1Dom_0024Tie1nm_, out OrientedEdge[] _0023_003DzOAlPmgi9yzUJ)
	{
		ICurve curve = _0023_003DzC6SYinZDkKHt[_0023_003Dz6_Xe0PJWewaZ];
		bool flag = _0023_003DzC6SYinZDkKHt[^1].EndPoint.Equals(_0023_003DzC6SYinZDkKHt[0].StartPoint) && _0023_003Dz6_Xe0PJWewaZ == 0;
		bool flag2 = curve is Arc || curve is Circle;
		Surface[] array = Surface._0023_003DzowcsV69kzLEYIxyHy7oa2d4_003D(_0023_003Dz06A5WivSSyUp, new List<ICurve>(), new ICurve[1] { curve }, curve.IsClosed, _0023_003DzAqH9bgFsOafeqpSJ5A_003D_003D, _0023_003DzbErHvVw_003D: false, _0023_003Dz0h7AakEIaVwL).ToArray();
		int num = array.Length;
		ICurve[] array2 = new ICurve[num];
		ICurve[] array3 = new ICurve[num];
		ICurve[] array4 = new ICurve[num];
		for (int i = 0; i < num; i++)
		{
			if (flag2)
			{
				array[i].ReverseU();
				array2[i] = array[i].IsocurveV(array[i].KnotVectorU.First());
				array3[i] = array[i].IsocurveV(array[i].KnotVectorU.Last());
				array4[i] = array[i].IsocurveU(array[i].KnotVectorV.First());
			}
			else
			{
				array2[i] = array[i].IsocurveU(array[i].KnotVectorV.First());
				array3[i] = array[i].IsocurveU(array[i].KnotVectorV.Last());
				array4[i] = array[i].IsocurveV(array[i].KnotVectorU.First());
			}
		}
		int num2 = num;
		int num3;
		OrientedEdge[][] array6;
		if (_0023_003Dz06A5WivSSyUp.IsClosed)
		{
			num3 = num;
			Point3D[] array5 = new Vertex[num3 * ((_0023_003Dz6_Xe0PJWewaZ > 0) ? 1 : 2)];
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = array5;
			_0023_003DzU3hosSAzkxO7 = new Edge[num3 * ((_0023_003Dz6_Xe0PJWewaZ > 0) ? 2 : 3)];
			array6 = new OrientedEdge[num3][];
			_0023_003Dz1Dom_0024Tie1nm_ = new OrientedEdge[num3];
			_0023_003DzOAlPmgi9yzUJ = new OrientedEdge[num3];
			_0023_003DzpPOEJqcAh7Lr = new Face[num3];
		}
		else
		{
			num3 = num + 1;
			Point3D[] array5 = new Vertex[num3 * ((_0023_003Dz6_Xe0PJWewaZ > 0) ? 1 : 2)];
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = array5;
			_0023_003DzU3hosSAzkxO7 = new Edge[num * ((_0023_003Dz6_Xe0PJWewaZ > 0) ? 2 : 3) + 1];
			array6 = new OrientedEdge[num][];
			_0023_003Dz1Dom_0024Tie1nm_ = new OrientedEdge[num3 - 1];
			_0023_003DzOAlPmgi9yzUJ = new OrientedEdge[num3 - 1];
			_0023_003DzpPOEJqcAh7Lr = new Face[num];
		}
		_0023_003Dz1OARlKY_003D = ((!(_0023_003Dz6_Xe0PJWewaZ > 0 || flag)) ? _0023_003Dz1OARlKY_003D : (_0023_003Dz1OARlKY_003D - num3));
		_0023_003Dzjt29dMs_003D = ((!(_0023_003Dz6_Xe0PJWewaZ > 0 || flag)) ? _0023_003Dzjt29dMs_003D : (_0023_003Dzjt29dMs_003D - num2));
		for (int j = 0; j < num3; j++)
		{
			if (_0023_003Dz06A5WivSSyUp.IsClosed || j < num3 - 1)
			{
				int num4 = (j + 1) % num3;
				int num5 = _0023_003Dz1OARlKY_003D + num3;
				int num6 = j + ((!_0023_003Dz06A5WivSSyUp.IsClosed) ? 1 : 0);
				if (_0023_003Dz6_Xe0PJWewaZ == 0 && !flag)
				{
					Point3D point3D = (Point3D)array2[j].StartPoint.Clone();
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[j] = new Vertex(point3D.X, point3D.Y, point3D.Z);
					point3D = (Point3D)array3[j].StartPoint.Clone();
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num3 + j] = new Vertex(point3D.X, point3D.Y, point3D.Z);
					_0023_003DzU3hosSAzkxO7[j] = new Edge(array2[j], _0023_003Dz1OARlKY_003D + j, _0023_003Dz1OARlKY_003D + num4);
					_0023_003DzU3hosSAzkxO7[num2 + j] = new Edge(array4[j], _0023_003Dz1OARlKY_003D + j, num5 + j);
					_0023_003DzU3hosSAzkxO7[num2 + num3 + j] = new Edge(array3[j], num5 + j, num5 + num4);
				}
				else
				{
					Point3D point3D2 = (Point3D)array3[j].StartPoint.Clone();
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[j] = new Vertex(point3D2.X, point3D2.Y, point3D2.Z);
					_0023_003DzU3hosSAzkxO7[j] = new Edge(array4[j], j + (flag ? (-num3) : _0023_003Dz1OARlKY_003D), num5 + j);
					_0023_003DzU3hosSAzkxO7[num2 + num6] = new Edge(array3[j], num5 + j, num5 + num4);
				}
			}
			else
			{
				int num7 = _0023_003Dz1OARlKY_003D + num3;
				ICurve curve2 = ((!flag2) ? array[num - 1].IsocurveV(array[num - 1].KnotVectorU.Last()) : array[num - 1].IsocurveU(array[num - 1].KnotVectorV.Last()));
				if (_0023_003Dz6_Xe0PJWewaZ == 0 && !flag)
				{
					Point3D point3D3 = (Point3D)array2[j - 1].EndPoint.Clone();
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[j] = new Vertex(point3D3.X, point3D3.Y, point3D3.Z);
					point3D3 = (Point3D)array3[j - 1].EndPoint.Clone();
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num3 + j] = new Vertex(point3D3.X, point3D3.Y, point3D3.Z);
					_0023_003DzU3hosSAzkxO7[num2 + j] = new Edge(curve2, _0023_003Dz1OARlKY_003D + j, num7 + j);
				}
				else
				{
					Point3D point3D4 = (Point3D)array3[j - 1].EndPoint.Clone();
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[j] = new Vertex(point3D4.X, point3D4.Y, point3D4.Z);
					_0023_003DzU3hosSAzkxO7[j] = new Edge(curve2, j + (flag ? (-num3) : _0023_003Dz1OARlKY_003D), num7 + j);
				}
			}
		}
		for (int k = 0; k < num2; k++)
		{
			array6[k] = new OrientedEdge[4];
			if (!flag)
			{
				array6[k][0] = new OrientedEdge(_0023_003Dzjt29dMs_003D + k);
			}
			else
			{
				array6[k][0] = new OrientedEdge(k - num2);
			}
			array6[k][1] = new OrientedEdge(_0023_003Dzjt29dMs_003D + num2 + (k + 1) % num3);
			array6[k][2] = new OrientedEdge(_0023_003Dzjt29dMs_003D + num2 * 2 + k + ((!_0023_003Dz06A5WivSSyUp.IsClosed) ? 1 : 0), sense: false);
			array6[k][3] = new OrientedEdge(_0023_003Dzjt29dMs_003D + num2 + k, sense: false);
			_0023_003Dz1Dom_0024Tie1nm_[k] = new OrientedEdge(array6[k][0].CurveIndex);
			_0023_003DzOAlPmgi9yzUJ[k] = new OrientedEdge(array6[k][2].CurveIndex);
			AnalyticSurf surface;
			bool sense;
			if (array[k] is RevolvedSurface)
			{
				RevolvedSurface revolvedSurface = (RevolvedSurface)array[k];
				Segment3D segment3D = new Segment3D(((Circle)curve).Center, ((Circle)curve).Center + ((Circle)curve).Plane.AxisZ);
				double _0023_003Dz9ulfqf0M07_0024x;
				Vector3D vector3D = array2[k].GetNurbsForm()._0023_003Dz2Ew9vDIo4RqEw9OnJ5wRuuQ_003D(segment3D, out _0023_003Dz9ulfqf0M07_0024x);
				Plane plane = new Plane(array2[k].StartPoint, vector3D, segment3D);
				bool flag3 = false;
				bool flag4 = false;
				if (Utility.IsLine(array2[k]))
				{
					Vector3D startTangent = array2[k].StartTangent;
					flag3 = Vector3D.AreOrthogonal(startTangent, revolvedSurface.Axis) && Vector3D.AreParallel(startTangent, vector3D);
					if (flag3)
					{
						flag4 = !Vector3D.AreOpposite(vector3D, startTangent);
					}
				}
				if (array2[k].IsInPlane(plane, _0023_003Dz9ulfqf0M07_0024x * Utility._0023_003DzxhnLabVjXjPg) && flag3)
				{
					Vector3D normal = (flag4 ? ((Circle)curve).Plane.AxisZ : (((Circle)curve).Plane.AxisZ * -1.0));
					surface = new PlanarSurf(array2[k].StartPoint, normal, vector3D);
					sense = true;
				}
				else
				{
					RevolvedSurface revolvedSurface2 = (RevolvedSurface)array[k];
					surface = new RevolvedSurf((Point3D)revolvedSurface2.Center.Clone(), (Vector3D)revolvedSurface2.Axis.Clone(), (Vector3D)revolvedSurface2.SeamPlane.AxisX.Clone(), (ICurve)revolvedSurface2.Generatrix.Clone());
					sense = false;
				}
			}
			else
			{
				surface = array[k]._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D();
				sense = !flag2;
			}
			_0023_003DzpPOEJqcAh7Lr[k] = new Face(surface, new Loop[1]
			{
				new Loop(array6[k])
			}, sense);
		}
	}

	private static void _0023_003Dz4o8T5ypHXQtJ(int _0023_003Dz1mib2YtxndaN, int _0023_003DzkuvR6pWe_0024db1, ref List<Edge> _0023_003DzU3hosSAzkxO7, ref Face[] _0023_003DzpPOEJqcAh7Lr)
	{
		foreach (Edge item in _0023_003DzU3hosSAzkxO7)
		{
			if (item.StartPointIndex < 0)
			{
				item.StartPointIndex = _0023_003Dz1mib2YtxndaN + item.StartPointIndex;
			}
			if (item.EndPointIndex < 0)
			{
				item.EndPointIndex = _0023_003Dz1mib2YtxndaN + item.EndPointIndex;
			}
		}
		Face[] array = _0023_003DzpPOEJqcAh7Lr;
		foreach (Face face in array)
		{
			if (face.Loops[0].Segments[0].CurveIndex < 0)
			{
				face.Loops[0].Segments[0].CurveIndex = _0023_003DzkuvR6pWe_0024db1 + face.Loops[0].Segments[0].CurveIndex;
			}
			if (face.Loops[0].Segments[1].CurveIndex < 0)
			{
				face.Loops[0].Segments[1].CurveIndex = _0023_003DzkuvR6pWe_0024db1 + face.Loops[0].Segments[1].CurveIndex;
			}
			if (face.Loops[0].Segments[2].CurveIndex < 0)
			{
				face.Loops[0].Segments[2].CurveIndex = _0023_003DzkuvR6pWe_0024db1 + face.Loops[0].Segments[2].CurveIndex;
			}
			if (face.Loops[0].Segments[3].CurveIndex < 0)
			{
				face.Loops[0].Segments[3].CurveIndex = _0023_003DzkuvR6pWe_0024db1 + face.Loops[0].Segments[3].CurveIndex;
			}
		}
	}

	private static Brep _0023_003Dz7SSjHlM9sQ2_gkrsbg_003D_003D(Brep _0023_003DzqjniGGF9kvbc, Brep _0023_003Dzk0sekCclUGst)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>(_0023_003DzqjniGGF9kvbc.Faces.Length);
		Dictionary<int, int> _0023_003DznOxom2vgXvVl = new Dictionary<int, int>(_0023_003DzqjniGGF9kvbc.Edges.Length);
		Dictionary<int, int> _0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D = new Dictionary<int, int>(_0023_003DzqjniGGF9kvbc.Vertices.Length);
		_0023_003Dzhlq5RKbWjx6nskJGYQMtB7C9hVAf(_0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst, out var _, out var _, out var _, _0023_003Dzk_3tZjgmhGlmfKWn0g_003D_003D: true, _0023_003DzY7IAYN_00249VAHl11lbabS4sjVmDFI0: true);
		for (int i = 0; i < _0023_003Dzk0sekCclUGst.Faces.Length; i++)
		{
			Face face = _0023_003Dzk0sekCclUGst.Faces[i];
			if (face.tangentFacesType == null)
			{
				continue;
			}
			for (int j = 0; j < face.tangentFacesType.Count; j++)
			{
				if (face.tangentFacesType[j] != Face.tangentType.coplanar)
				{
					int num = face.tangentFacesIndices[j];
					Face _0023_003Dzn6eRxNucSNoK = _0023_003DzqjniGGF9kvbc.Faces[num];
					if (_0023_003DzEQ9iwU9O8GC7(_0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst, _0023_003Dzn6eRxNucSNoK, face, _0023_003DzqjniGGF9kvbc._rebuildTol, ref _0023_003DznOxom2vgXvVl, ref _0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D, _0023_003DzZGts1TUYc93W_LmnjQ_003D_003D: true))
					{
						dictionary.Add(i, num);
					}
				}
			}
		}
		if (dictionary.Count > 0)
		{
			return _0023_003Dzvsag8z_YSTdoVQOKsa9XViI_003D(_0023_003DzqjniGGF9kvbc, _0023_003Dzk0sekCclUGst, _0023_003DzRc9F6BRuOvkMZTotrXhyjts_003D: false, dictionary, _0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D, _0023_003DznOxom2vgXvVl, -1, -1, _0023_003DzJVWkwrC6nEkD: false);
		}
		return null;
	}

	private static bool _0023_003DzEQ9iwU9O8GC7(Brep _0023_003Dzj2oE5Ppl7__s, Brep _0023_003Dzyffz4QVsPwJl, Face _0023_003Dzn6eRxNucSNoK, Face _0023_003DzcQpPRG5mmRCF, double _0023_003Dzm0CYiiE_003D, ref Dictionary<int, int> _0023_003DznOxom2vgXvVl, ref Dictionary<int, int> _0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D, bool _0023_003DzZGts1TUYc93W_LmnjQ_003D_003D)
	{
		if (_0023_003Dzn6eRxNucSNoK.Parametric == null)
		{
			_0023_003Dzj2oE5Ppl7__s._0023_003Dzsbu_0024qag0bE6HjJtgiPvQCKDPPuzm(new List<Face> { _0023_003Dzn6eRxNucSNoK }, _0023_003Dzm0CYiiE_003D);
		}
		if (_0023_003DzcQpPRG5mmRCF.Parametric == null)
		{
			_0023_003Dzyffz4QVsPwJl._0023_003Dzsbu_0024qag0bE6HjJtgiPvQCKDPPuzm(new List<Face> { _0023_003DzcQpPRG5mmRCF }, _0023_003Dzm0CYiiE_003D);
		}
		if (!_0023_003DzqCSugSCWh2k_0024(_0023_003Dzn6eRxNucSNoK, _0023_003DzcQpPRG5mmRCF, _0023_003Dzm0CYiiE_003D, ref _0023_003DznOxom2vgXvVl, _0023_003DzZGts1TUYc93W_LmnjQ_003D_003D))
		{
			return false;
		}
		_0023_003DzexlinmBd63Hvfg3dNg_003D_003D(_0023_003Dzj2oE5Ppl7__s, _0023_003Dzyffz4QVsPwJl, _0023_003DzcQpPRG5mmRCF, _0023_003DznOxom2vgXvVl, _0023_003DzZyI0xqZFhVCjocj2pIbJMGw_003D);
		return true;
	}

	private static bool _0023_003DzqCSugSCWh2k_0024(Face _0023_003Dzn6eRxNucSNoK, Face _0023_003DzcQpPRG5mmRCF, double _0023_003Dzm0CYiiE_003D, ref Dictionary<int, int> _0023_003DznOxom2vgXvVl, bool _0023_003DzZGts1TUYc93W_LmnjQ_003D_003D)
	{
		List<ICurve> list = _0023_003DzcQpPRG5mmRCF.Parametric[0].Trimming.ContourList.ToList();
		for (int i = 0; i < _0023_003Dzn6eRxNucSNoK.Parametric[0].Trimming.ContourList.Count; i++)
		{
			List<ICurve> list2 = new List<ICurve>();
			ICurve[] individualCurves = _0023_003Dzn6eRxNucSNoK.Parametric[0].Trimming.ContourList[i].GetIndividualCurves();
			for (int j = 0; j < individualCurves.Length; j++)
			{
				TrimCurve trimCurve = (TrimCurve)individualCurves[j];
				list2.Add((ICurve)trimCurve.Clone());
			}
			for (int k = 0; k < list.Count; k++)
			{
				List<ICurve> list3 = new List<ICurve>();
				individualCurves = list[k].GetIndividualCurves();
				for (int j = 0; j < individualCurves.Length; j++)
				{
					TrimCurve trimCurve2 = (TrimCurve)individualCurves[j];
					list3.Add((ICurve)trimCurve2.Clone());
				}
				if (!_0023_003DzU6cVoIKpewxbFYiO2A_003D_003D(_0023_003Dzm0CYiiE_003D, _0023_003DznOxom2vgXvVl, _0023_003DzZGts1TUYc93W_LmnjQ_003D_003D, list3, list2))
				{
					if (i == 0 || k == list.Count - 1)
					{
						return false;
					}
					continue;
				}
				list.RemoveAt(k);
				break;
			}
		}
		return true;
	}

	private static bool _0023_003DzU6cVoIKpewxbFYiO2A_003D_003D(double _0023_003Dzm0CYiiE_003D, Dictionary<int, int> _0023_003DznOxom2vgXvVl, bool _0023_003DzZGts1TUYc93W_LmnjQ_003D_003D, List<ICurve> _0023_003DzVixMwhaCnCpx, List<ICurve> _0023_003DzK2kANxBH211q)
	{
		foreach (TrimCurve item in _0023_003DzK2kANxBH211q)
		{
			bool flag = false;
			foreach (TrimCurve item2 in _0023_003DzVixMwhaCnCpx)
			{
				Curve nurbsForm = item.Edge.GetNurbsForm();
				Curve nurbsForm2 = item2.Edge.GetNurbsForm();
				Point3D _0023_003DzDVubtvo_003D;
				Point3D _0023_003DzFj_0024IqDQ_003D;
				bool _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D;
				Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D = Curve._0023_003DzRGcO5v1wS2S_(nurbsForm, nurbsForm2, out _0023_003DzDVubtvo_003D, out _0023_003DzFj_0024IqDQ_003D, out _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D, 1.0);
				_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D = !_0023_003DzZGts1TUYc93W_LmnjQ_003D_003D;
				if (_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D)
				{
					bool flag2 = ((_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)3 || _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)5) ? true : false);
					_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D = flag2;
				}
				bool flag3 = _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D;
				if (!flag3)
				{
					bool flag2 = _0023_003DzZGts1TUYc93W_LmnjQ_003D_003D;
					if (flag2)
					{
						bool flag4 = ((_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)4 || _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)6) ? true : false);
						flag2 = flag4;
					}
					flag3 = flag2;
				}
				if (flag3)
				{
					flag = true;
					if (!_0023_003DznOxom2vgXvVl.ContainsKey(item2.EdgeIndex))
					{
						_0023_003DznOxom2vgXvVl.Add(item2.EdgeIndex, item.EdgeIndex);
					}
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
		}
		return true;
	}

	public ssiFailureType Chamfer(Edge edge, double dist, double chainingTolerance = 0.0)
	{
		return _0023_003Dz1_0024T_0024pNpmTkLk3YNwnMXVU2sf7mG_(edge.Curve.EdgeIndex, dist, dist, _0023_003DzTcFGbxcG1Gf9: true, chainingTolerance);
	}

	public ssiFailureType Chamfer(int edgeIndex, double dist, double chainingTolerance = 0.0)
	{
		return _0023_003Dz1_0024T_0024pNpmTkLk3YNwnMXVU2sf7mG_(edgeIndex, dist, dist, _0023_003DzTcFGbxcG1Gf9: true, chainingTolerance);
	}

	public ssiFailureType Chamfer(int edgeIndex, double dist1, double dist2, double chainingTolerance = 0.0)
	{
		return _0023_003Dz1_0024T_0024pNpmTkLk3YNwnMXVU2sf7mG_(edgeIndex, dist1, dist2, _0023_003DzTcFGbxcG1Gf9: true, chainingTolerance);
	}

	public ssiFailureType Fillet(Edge edge, double radius, double chainingTolerance = 0.0)
	{
		return _0023_003Dz1_0024T_0024pNpmTkLk3YNwnMXVU2sf7mG_(edge.Curve.EdgeIndex, radius, radius, _0023_003DzTcFGbxcG1Gf9: false, chainingTolerance);
	}

	public ssiFailureType Fillet(int edgeIndex, double radius, double chainingTolerance = 0.0)
	{
		return _0023_003Dz1_0024T_0024pNpmTkLk3YNwnMXVU2sf7mG_(edgeIndex, radius, radius, _0023_003DzTcFGbxcG1Gf9: false, chainingTolerance);
	}

	private ssiFailureType _0023_003Dz1_0024T_0024pNpmTkLk3YNwnMXVU2sf7mG_(int _0023_003DzL8NvYU0_003D, double _0023_003DzerTCYakiui4_0024, double _0023_003DzYSQyjvxa2kEh, bool _0023_003DzTcFGbxcG1Gf9, double _0023_003Dzpjf6nIMzquoXVde4kw_003D_003D)
	{
		Point3D point3D = _vertices[_edges[_0023_003DzL8NvYU0_003D].StartPointIndex];
		Vector3D vector3D = new Vector3D(point3D.X, point3D.Y, point3D.Z);
		Vector3D v = -1.0 * vector3D;
		Translate(v);
		ssiFailureType ssiFailureType2 = _0023_003Dzag5j_BGGB3Zz0alpVg_003D_003D(_0023_003DzL8NvYU0_003D, _0023_003DzerTCYakiui4_0024, _0023_003DzYSQyjvxa2kEh, _0023_003DzTcFGbxcG1Gf9, _0023_003Dzpjf6nIMzquoXVde4kw_003D_003D);
		Translate(vector3D);
		if (ssiFailureType2 != ssiFailureType.Success)
		{
			return ssiFailureType2;
		}
		RegenMode = regenType.RegenAndCompile;
		return ssiFailureType2;
	}

	private void _0023_003Dzjud0Dv_0024cr1xW()
	{
		for (int i = 0; i < _edges.Length; i++)
		{
			_edges[i].Curve.EdgeIndex = i;
		}
	}

	private ssiFailureType _0023_003Dzag5j_BGGB3Zz0alpVg_003D_003D(int _0023_003DzL8NvYU0_003D, double _0023_003DzEGKj_0024SNUUihi, double _0023_003DzYSQyjvxa2kEh, bool _0023_003DzTcFGbxcG1Gf9, double _0023_003Dzpjf6nIMzquoXVde4kw_003D_003D)
	{
		if (_0023_003DzL8NvYU0_003D == -1)
		{
			return ssiFailureType.InvalidFillet;
		}
		List<int> list = new List<int>();
		List<bool> list2 = new List<bool>();
		list.Add(_0023_003DzL8NvYU0_003D);
		list2.Add(item: false);
		Rebuild(0.0, soft: true);
		if (Edges[_0023_003DzL8NvYU0_003D].Curve.EdgeIndex == -1)
		{
			_0023_003Dzjud0Dv_0024cr1xW();
		}
		if (_0023_003Dzpjf6nIMzquoXVde4kw_003D_003D == 0.0)
		{
			_0023_003Dzpjf6nIMzquoXVde4kw_003D_003D = Utility._0023_003DzxhnLabVjXjPg;
		}
		_0023_003DzG2E8RV0k0M6w(_0023_003DzL8NvYU0_003D, list, list2, _0023_003Dzpjf6nIMzquoXVde4kw_003D_003D, _0023_003DzvVHR6PM_003D: true, _0023_003DzU4acXOY_003D: true);
		int num = (list2[0] ? Edges[list[0]].EndPointIndex : Edges[list[0]].StartPointIndex);
		int num2 = (list2[list2.Count - 1] ? Edges[list[list2.Count - 1]].StartPointIndex : Edges[list[list2.Count - 1]].EndPointIndex);
		bool flag = num == num2;
		if (flag)
		{
			while (list[0] != _0023_003DzL8NvYU0_003D)
			{
				int item = list[0];
				bool flag2 = list2[0];
				list.RemoveAt(0);
				list2.RemoveAt(0);
				list.Add(item);
				list2.Add(!flag2);
			}
		}
		else if (list.Last() == _0023_003DzL8NvYU0_003D)
		{
			list.Reverse();
			list2.Reverse();
			for (int i = 0; i < list2.Count; i++)
			{
				list2[i] = !list2[i];
			}
		}
		bool flag3 = false;
		if (flag)
		{
			Vector3D u = (list2[0] ? Edges[list[0]].Curve.EndTangent : Edges[list[0]].Curve.StartTangent);
			Vector3D v = (list2[list2.Count - 1] ? Edges[list[list2.Count - 1]].Curve.StartTangent : Edges[list[list2.Count - 1]].Curve.EndTangent);
			flag3 = flag && Vector3D.AreParallel(u, v, _0023_003Dzpjf6nIMzquoXVde4kw_003D_003D);
		}
		Brep brep = (Brep)Clone();
		int num3 = Edges[_0023_003DzL8NvYU0_003D].ShellIndex - 1;
		if (num3 == -1)
		{
			for (int j = 0; j < Faces.Length; j++)
			{
				_0023_003DzVBezP1GqFkfaNh7Evfs0OoA_003D(Faces[j], brep.Faces[j]);
			}
		}
		else
		{
			for (int k = 0; k < Inners[num3].Length; k++)
			{
				_0023_003DzVBezP1GqFkfaNh7Evfs0OoA_003D(Inners[num3][k], brep.Inners[num3][k]);
			}
		}
		int num4 = 0;
		while (num4 < list.Count)
		{
			bool _0023_003DzRMO0hohF8hhA3Hyhdg_003D_003D = false;
			bool _0023_003DzfT1oRNXkh4iVsabWuw_003D_003D = false;
			if (!flag || !flag3)
			{
				_0023_003DzRMO0hohF8hhA3Hyhdg_003D_003D = (list2[num4] ? (num4 == 0) : (num4 == list.Count - 1));
				_0023_003DzfT1oRNXkh4iVsabWuw_003D_003D = (list2[num4] ? (num4 == list.Count - 1) : (num4 == 0));
			}
			ssiFailureType ssiFailureType2 = brep._0023_003Dz1wTXv6qt1UbIhbpFgg_003D_003D(list[num4], _0023_003DzEGKj_0024SNUUihi, _0023_003DzYSQyjvxa2kEh, _0023_003DzTcFGbxcG1Gf9, _0023_003Dzpjf6nIMzquoXVde4kw_003D_003D, _0023_003DzfT1oRNXkh4iVsabWuw_003D_003D, _0023_003DzRMO0hohF8hhA3Hyhdg_003D_003D, (num4 == list.Count - 1) ? null : list);
			switch (ssiFailureType2)
			{
			case ssiFailureType.BoundaryProcessingFailed:
				throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962353), list[num4]));
			default:
				throw new EyeshotException(ssiFailureType2.ToString() + string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962311), list[num4]));
			case ssiFailureType.Success:
				if (ssiFailureType2 != ssiFailureType.Success && ssiFailureType2 != ssiFailureType.BoundaryProcessingFailed)
				{
					return ssiFailureType2;
				}
				num4++;
				break;
			}
		}
		Face[] faces = brep.Faces;
		foreach (Face face in faces)
		{
			if (face.needRebuild)
			{
				face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(null);
			}
			if (face.Parametric == null)
			{
				continue;
			}
			Loop[] loops = face.Loops;
			for (int m = 0; m < loops.Length; m++)
			{
				OrientedEdge[] segments = loops[m].Segments;
				for (int n = 0; n < segments.Length; n++)
				{
					OrientedEdge orientedEdge = segments[n];
					if (list.Contains(orientedEdge.CurveIndex))
					{
						face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(null);
						break;
					}
				}
				if (face.Parametric == null)
				{
					break;
				}
			}
		}
		_0023_003Dz8VkxvzXXGxA_0024(brep.Vertices, brep.Edges, brep.Faces, brep.Inners, _0023_003DzLuJVbec_003D: true);
		brep._0023_003DzUE6pJD8Y3NVt();
		brep._0023_003DzDumeg9jsTU7S(_0023_003Dzxt7paKBusKOo: true);
		brep._0023_003DzxW3N3i886iwK(null, null, 0, null);
		_0023_003Dzd55uIPSKitfg(brep.Vertices, brep.Edges, brep.Faces, brep.Inners);
		return ssiFailureType.Success;
	}

	private void _0023_003DzG2E8RV0k0M6w(int _0023_003DzL8NvYU0_003D, List<int> _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D, List<bool> _0023_003Dz4UI1QTK0IxO2yG_zkA_003D_003D, double _0023_003DzKQtixx1nLBno7hO2_0024A_003D_003D, bool _0023_003DzvVHR6PM_003D, bool _0023_003DzU4acXOY_003D)
	{
		_0023_003DzaqHY_0024QDeja_zGESwjHTKLAY_003D CS_0024_003C_003E8__locals11 = new _0023_003DzaqHY_0024QDeja_zGESwjHTKLAY_003D();
		CS_0024_003C_003E8__locals11._0023_003DzL8NvYU0_003D = _0023_003DzL8NvYU0_003D;
		int[] array;
		if (_0023_003DzU4acXOY_003D)
		{
			int endPointIndex = Edges[CS_0024_003C_003E8__locals11._0023_003DzL8NvYU0_003D].EndPointIndex;
			int[] parents = ((Vertex)Vertices[endPointIndex]).Parents;
			Vector3D endTangent = Edges[CS_0024_003C_003E8__locals11._0023_003DzL8NvYU0_003D].Curve.EndTangent;
			array = parents;
			foreach (int num in array)
			{
				if (num == CS_0024_003C_003E8__locals11._0023_003DzL8NvYU0_003D)
				{
					continue;
				}
				bool flag = Edges[num].StartPointIndex == endPointIndex;
				Vector3D v = (flag ? Edges[num].Curve.StartTangent : Edges[num].Curve.EndTangent);
				if (!Vector3D.AreParallel(endTangent, v, _0023_003DzKQtixx1nLBno7hO2_0024A_003D_003D))
				{
					continue;
				}
				if (!_0023_003DzZd8B81_0024nDQA_0024m4kvBg_003D_003D(num, _rebuildTol, out var _0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D) || !_0023_003DzZd8B81_0024nDQA_0024m4kvBg_003D_003D(CS_0024_003C_003E8__locals11._0023_003DzL8NvYU0_003D, _rebuildTol, out var _0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D2) || _0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D != _0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D2)
				{
					break;
				}
				int num2 = _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.FindIndex((int _0023_003DzyzK8swU_003D) => _0023_003DzyzK8swU_003D == CS_0024_003C_003E8__locals11._0023_003DzL8NvYU0_003D);
				int index = (num2 + 1) % _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.Count;
				int index2 = (_0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.Count + num2 - 1) % _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.Count;
				if (_0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D[index] != num && _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D[index2] != num)
				{
					if (num2 == _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.Count - 1)
					{
						_0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.Insert(num2 + 1, num);
						_0023_003Dz4UI1QTK0IxO2yG_zkA_003D_003D.Insert(num2 + 1, !flag);
					}
					else
					{
						_0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.Insert(0, num);
						_0023_003Dz4UI1QTK0IxO2yG_zkA_003D_003D.Insert(0, flag);
					}
					_0023_003DzG2E8RV0k0M6w(num, _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D, _0023_003Dz4UI1QTK0IxO2yG_zkA_003D_003D, _0023_003DzKQtixx1nLBno7hO2_0024A_003D_003D, !flag, flag);
				}
				break;
			}
		}
		if (!_0023_003DzvVHR6PM_003D)
		{
			return;
		}
		int startPointIndex = Edges[CS_0024_003C_003E8__locals11._0023_003DzL8NvYU0_003D].StartPointIndex;
		int[] parents2 = ((Vertex)Vertices[startPointIndex]).Parents;
		Vector3D startTangent = Edges[CS_0024_003C_003E8__locals11._0023_003DzL8NvYU0_003D].Curve.StartTangent;
		array = parents2;
		foreach (int num3 in array)
		{
			if (num3 == CS_0024_003C_003E8__locals11._0023_003DzL8NvYU0_003D)
			{
				continue;
			}
			bool flag2 = Edges[num3].StartPointIndex == startPointIndex;
			Vector3D v2 = (flag2 ? Edges[num3].Curve.StartTangent : Edges[num3].Curve.EndTangent);
			if (!Vector3D.AreParallel(startTangent, v2, _0023_003DzKQtixx1nLBno7hO2_0024A_003D_003D))
			{
				continue;
			}
			_0023_003DzZd8B81_0024nDQA_0024m4kvBg_003D_003D(num3, _rebuildTol, out var _0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D3);
			_0023_003DzZd8B81_0024nDQA_0024m4kvBg_003D_003D(CS_0024_003C_003E8__locals11._0023_003DzL8NvYU0_003D, _rebuildTol, out var _0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D4);
			if (_0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D3 != _0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D4)
			{
				break;
			}
			int num4 = _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.FindIndex(CS_0024_003C_003E8__locals11._0023_003Dz4LepviJiCO3K6Aj4ORRxMHE_003D);
			int index3 = (num4 + 1) % _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.Count;
			int index4 = (_0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.Count + num4 - 1) % _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.Count;
			if (_0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D[index3] != num3 && _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D[index4] != num3)
			{
				if (_0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.Count > 1 && num4 == _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.Count - 1)
				{
					_0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.Insert(num4 + 1, num3);
					_0023_003Dz4UI1QTK0IxO2yG_zkA_003D_003D.Insert(num4 + 1, !flag2);
				}
				else
				{
					_0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.Insert(0, num3);
					_0023_003Dz4UI1QTK0IxO2yG_zkA_003D_003D.Insert(0, flag2);
				}
				_0023_003DzG2E8RV0k0M6w(num3, _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D, _0023_003Dz4UI1QTK0IxO2yG_zkA_003D_003D, _0023_003DzKQtixx1nLBno7hO2_0024A_003D_003D, !flag2, flag2);
			}
			break;
		}
	}

	private ssiFailureType _0023_003Dz1wTXv6qt1UbIhbpFgg_003D_003D(int _0023_003DzL8NvYU0_003D, double _0023_003DzEGKj_0024SNUUihi, double _0023_003DzYSQyjvxa2kEh, bool _0023_003DzTcFGbxcG1Gf9, double _0023_003Dzpjf6nIMzquoXVde4kw_003D_003D, bool _0023_003DzfT1oRNXkh4iVsabWuw_003D_003D, bool _0023_003DzRMO0hohF8hhA3Hyhdg_003D_003D, List<int> _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D)
	{
		_0023_003DzPNxxWiDmMk0rfV6RJz_0024qcqc_003D CS_0024_003C_003E8__locals31 = new _0023_003DzPNxxWiDmMk0rfV6RJz_0024qcqc_003D();
		CS_0024_003C_003E8__locals31._0023_003DzopRx0_MBcTQs = this;
		bool _0023_003DzoPXSzGAOaRPS = true;
		bool _0023_003DzUVWKmG9exPuC = true;
		bool _0023_003Dz9I3m6f9Si9Wb = false;
		bool _0023_003Dzb8PJBkDXtQ1N = true;
		Edge edge = _edges[_0023_003DzL8NvYU0_003D];
		edge.Curve.EdgeIndex = _0023_003DzL8NvYU0_003D;
		double num = _rebuildTol / 10.0;
		double _0023_003Dzm0CYiiE_003D = num / 100.0 * edge.Curve.Length();
		if (!_0023_003Dz_0024WTkU9JSY152(edge, num, out var _0023_003Dz3jDpzyJtb3_0024Nm8rt_0024Q_003D_003D))
		{
			return ssiFailureType.InvalidFillet;
		}
		Surface[] _0023_003DzU7OxNcM1zxhB = null;
		Surface[] _0023_003DzPuJY3x2xFYgq = null;
		CS_0024_003C_003E8__locals31._0023_003DzHUUmkb0uibv6 = -1;
		CS_0024_003C_003E8__locals31._0023_003DzOhFjSPs8eMvF = -1;
		if ((!_0023_003Dz3jDpzyJtb3_0024Nm8rt_0024Q_003D_003D && !_0023_003DzkDcf5W3CxoRl4jCPt0PtwGk_003D(edge, out _0023_003DzU7OxNcM1zxhB, out _0023_003DzPuJY3x2xFYgq, out CS_0024_003C_003E8__locals31._0023_003DzHUUmkb0uibv6, out CS_0024_003C_003E8__locals31._0023_003DzOhFjSPs8eMvF)) || (_0023_003Dz3jDpzyJtb3_0024Nm8rt_0024Q_003D_003D && !_0023_003DzkDcf5W3CxoRl4jCPt0PtwGk_003D(edge, out _0023_003DzPuJY3x2xFYgq, out _0023_003DzU7OxNcM1zxhB, out CS_0024_003C_003E8__locals31._0023_003DzOhFjSPs8eMvF, out CS_0024_003C_003E8__locals31._0023_003DzHUUmkb0uibv6)))
		{
			return ssiFailureType.UnknownFailure;
		}
		int[] array = ((Vertex)Vertices[edge.StartPointIndex]).Parents.Where((int _0023_003DzbfrNXYE_003D) => CS_0024_003C_003E8__locals31._0023_003DzopRx0_MBcTQs.Edges[_0023_003DzbfrNXYE_003D].Parents.Except(new int[2] { CS_0024_003C_003E8__locals31._0023_003DzOhFjSPs8eMvF, CS_0024_003C_003E8__locals31._0023_003DzHUUmkb0uibv6 }).Count() == 1).Distinct().ToArray();
		int[] array2 = ((Vertex)Vertices[edge.EndPointIndex]).Parents.Where(CS_0024_003C_003E8__locals31._0023_003DztIhSSHQn_8yGaZnZU5cEZD8_003D).Distinct().ToArray();
		int[] array3 = array.Select((int _0023_003DzbfrNXYE_003D) => CS_0024_003C_003E8__locals31._0023_003DzopRx0_MBcTQs.Edges[_0023_003DzbfrNXYE_003D].Parents.Except(new int[2] { CS_0024_003C_003E8__locals31._0023_003DzOhFjSPs8eMvF, CS_0024_003C_003E8__locals31._0023_003DzHUUmkb0uibv6 })).SelectMany(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzSjCB7oq8txhO2Y0Ppo_JZaZzReJU).Distinct()
			.ToArray();
		int[] array4 = array2.Select((int _0023_003DzbfrNXYE_003D) => CS_0024_003C_003E8__locals31._0023_003DzopRx0_MBcTQs.Edges[_0023_003DzbfrNXYE_003D].Parents.Except(new int[2] { CS_0024_003C_003E8__locals31._0023_003DzOhFjSPs8eMvF, CS_0024_003C_003E8__locals31._0023_003DzHUUmkb0uibv6 })).SelectMany((IEnumerable<int> _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D).Except(array3)
			.Distinct()
			.ToArray();
		bool[] array5 = new bool[array3.Length];
		bool[] array6 = new bool[array4.Length];
		bool flag = _0023_003DzfT1oRNXkh4iVsabWuw_003D_003D && array3.Length != 0;
		bool flag2 = _0023_003DzRMO0hohF8hhA3Hyhdg_003D_003D && array4.Length != 0;
		Face[] array7 = ((edge.ShellIndex == 0) ? Faces : Inners[edge.ShellIndex - 1]);
		int _0023_003Dz6Wgpeb47lwUusKlgI1a5UvI_003D = _0023_003DzJSH_hr4DJ0qh6mo3EHwcQyo_003D(_0023_003DzL8NvYU0_003D, array7[CS_0024_003C_003E8__locals31._0023_003DzHUUmkb0uibv6]);
		int _0023_003DzvVnkZlO_0024HXlmKIIwueA3BSw_003D = _0023_003DzJSH_hr4DJ0qh6mo3EHwcQyo_003D(_0023_003DzL8NvYU0_003D, array7[CS_0024_003C_003E8__locals31._0023_003DzOhFjSPs8eMvF]);
		_0023_003DzzHJb0M9USFYG(_0023_003DzL8NvYU0_003D, array7[CS_0024_003C_003E8__locals31._0023_003DzHUUmkb0uibv6], array7[CS_0024_003C_003E8__locals31._0023_003DzOhFjSPs8eMvF], _0023_003Dz6Wgpeb47lwUusKlgI1a5UvI_003D, _0023_003DzvVnkZlO_0024HXlmKIIwueA3BSw_003D, out var _0023_003Dzbu8BV15Qqzan);
		bool flag3 = false;
		bool flag4 = false;
		if (_0023_003DzfT1oRNXkh4iVsabWuw_003D_003D)
		{
			flag3 = _0023_003DzTCK5_nRS5GCJ(array3, array, array7, _0023_003Dzbu8BV15Qqzan, num, array5);
		}
		if (_0023_003DzRMO0hohF8hhA3Hyhdg_003D_003D)
		{
			flag4 = _0023_003DzTCK5_nRS5GCJ(array4, array2, array7, _0023_003Dzbu8BV15Qqzan, num, array6);
		}
		Surface._0023_003Dzl1R5g44F3qtfixblIATQ_0024b4ayiNQ(_0023_003DzU7OxNcM1zxhB, _0023_003DzPuJY3x2xFYgq, _0023_003Dzbu8BV15Qqzan, _0023_003Dzbu8BV15Qqzan, out var _0023_003DzYvfyufGFFwmK, out var _0023_003DzvVCNKYH_0024jPXr);
		Surface._0023_003Dzb3ilAYDrxJR3dc3Cf_0024_0024Le7b9rD7j(_0023_003DzYvfyufGFFwmK, _0023_003DzvVCNKYH_0024jPXr, out var _0023_003Dzm30uCFw_003D, out var _0023_003DzCE1nYNI_003D);
		int _0023_003Dz9EMF9D5SvqdX;
		int _0023_003DzNu7esSs8sEDi;
		Surface._0023_003DzNmB23wM0JqUW99SXKg_003D_003D _0023_003DzNmB23wM0JqUW99SXKg_003D_003D;
		List<_0023_003Dz9bSHHx6Gf6fW0XQmwNcsniYkCPi9_0024l0r2gjzys8_003D> _0023_003DzdupzawMaxwrg = _0023_003DzT8cuf6q1lV9tLglxp5vPGYc_003D(edge, _0023_003Dzm30uCFw_003D, _0023_003DzCE1nYNI_003D, _0023_003Dzpjf6nIMzquoXVde4kw_003D_003D, _0023_003Dz3jDpzyJtb3_0024Nm8rt_0024Q_003D_003D, _0023_003Dzbu8BV15Qqzan, _0023_003DzEGKj_0024SNUUihi, _0023_003DzTcFGbxcG1Gf9, out _0023_003Dz9EMF9D5SvqdX, out _0023_003DzNu7esSs8sEDi, out _0023_003DzNmB23wM0JqUW99SXKg_003D_003D);
		ssiFailureType ssiFailureType2 = Surface._0023_003Dz3vEpVxZI0lvxEpQN2w_003D_003D(_0023_003DzYvfyufGFFwmK, _0023_003DzvVCNKYH_0024jPXr, _0023_003DzdupzawMaxwrg, _0023_003DzEGKj_0024SNUUihi, _0023_003DzYSQyjvxa2kEh, _0023_003DzEGKj_0024SNUUihi, (Surface._0023_003Dz_FJVTa8aqhc_0024)0, _0023_003DzTcFGbxcG1Gf9, _0023_003Dzm0CYiiE_003D, _0023_003DzUVWKmG9exPuC, _0023_003DzoPXSzGAOaRPS, _0023_003Dzb8PJBkDXtQ1N, _0023_003Dz9I3m6f9Si9Wb, _0023_003DzfT1oRNXkh4iVsabWuw_003D_003D, _0023_003DzRMO0hohF8hhA3Hyhdg_003D_003D, _0023_003Dz9EMF9D5SvqdX, _0023_003DzNu7esSs8sEDi, out var _0023_003DzVqhoEf8VbO9tl_0024vfgQJi0ic_003D, out var _, out var _, out var _0023_003Dz932FJwk_003D, out var _0023_003DzgoMmCoE_003D);
		if ((ssiFailureType2 != ssiFailureType.Success && ssiFailureType2 != ssiFailureType.BoundaryProcessingFailed) || _0023_003DzVqhoEf8VbO9tl_0024vfgQJi0ic_003D.Length == 0)
		{
			return ssiFailureType2;
		}
		ssiFailureType2 = ssiFailureType.Success;
		Surface surface = _0023_003DzVqhoEf8VbO9tl_0024vfgQJi0ic_003D[0];
		ICurve[] individualCurves = surface.Trimming.ContourList[0].GetIndividualCurves();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		if (!_0023_003Dzbu8BV15Qqzan)
		{
			surface.ReverseU();
		}
		dictionary.Add(individualCurves[_0023_003DzNu7esSs8sEDi].EdgeIndex, CS_0024_003C_003E8__locals31._0023_003DzOhFjSPs8eMvF);
		dictionary.Add(individualCurves[_0023_003Dz9EMF9D5SvqdX].EdgeIndex, CS_0024_003C_003E8__locals31._0023_003DzHUUmkb0uibv6);
		for (int num2 = individualCurves.Length - 1; num2 >= 0; num2--)
		{
			if (((TrimCurve)individualCurves[num2]).EdgeIndex == -1 || !((TrimCurve)individualCurves[num2]).FromBooleanIntersection)
			{
				((TrimCurve)individualCurves[num2]).EdgeIndex = -2;
			}
		}
		if (flag)
		{
			ssiFailureType2 = _0023_003DzcWq4J0CHOIp2ctIRVg_003D_003D(array3, array7, CS_0024_003C_003E8__locals31._0023_003DzHUUmkb0uibv6, CS_0024_003C_003E8__locals31._0023_003DzOhFjSPs8eMvF, array5, surface, _0023_003Dzm0CYiiE_003D, _0023_003Dzbu8BV15Qqzan, dictionary);
		}
		if (flag2)
		{
			ssiFailureType2 = _0023_003DzcWq4J0CHOIp2ctIRVg_003D_003D(array4, array7, CS_0024_003C_003E8__locals31._0023_003DzHUUmkb0uibv6, CS_0024_003C_003E8__locals31._0023_003DzOhFjSPs8eMvF, array6, surface, _0023_003Dzm0CYiiE_003D, !_0023_003Dzbu8BV15Qqzan, dictionary);
		}
		if (ssiFailureType2 != ssiFailureType.BoundaryProcessingFailed && ssiFailureType2 != ssiFailureType.Success)
		{
			return ssiFailureType2;
		}
		List<Point3D> list = Vertices.ToList();
		List<Edge> list2 = Edges.ToList();
		List<Face> list3 = array7.ToList();
		List<int> _0023_003Dzsvnj887WjFnx = new List<int>(2);
		List<int> list4 = new List<int>(1);
		if (_0023_003Dz932FJwk_003D)
		{
			_0023_003DzKnPF1H2VIOwi((TrimCurve)individualCurves[_0023_003Dz9EMF9D5SvqdX], list3, CS_0024_003C_003E8__locals31._0023_003DzHUUmkb0uibv6, list2, _0023_003DzL8NvYU0_003D, num, dictionary, list4);
		}
		else
		{
			list3[CS_0024_003C_003E8__locals31._0023_003DzHUUmkb0uibv6].needRebuild = true;
		}
		if (_0023_003DzgoMmCoE_003D)
		{
			_0023_003DzKnPF1H2VIOwi((TrimCurve)individualCurves[_0023_003DzNu7esSs8sEDi], list3, CS_0024_003C_003E8__locals31._0023_003DzOhFjSPs8eMvF, list2, _0023_003DzL8NvYU0_003D, num, dictionary, list4);
		}
		else
		{
			list3[CS_0024_003C_003E8__locals31._0023_003DzOhFjSPs8eMvF].needRebuild = true;
		}
		new Dictionary<int, int>();
		_0023_003Dzfp_0024xdsUDOPQDHwvBQtbLikbMb0OinnHmYA_003D_003D(edge, _0023_003DzfT1oRNXkh4iVsabWuw_003D_003D, flag3, _0023_003DzRMO0hohF8hhA3Hyhdg_003D_003D, flag4, list, _0023_003DzL8NvYU0_003D, _0023_003Dzsvnj887WjFnx);
		list2[_0023_003DzL8NvYU0_003D] = null;
		list4.Add(_0023_003DzL8NvYU0_003D);
		if (_0023_003DzTcFGbxcG1Gf9)
		{
			_0023_003DzoDiveDddlQSo(edge, _0023_003Dz98St4PSCKWvi: true, list, list2, list3, num, individualCurves, _0023_003Dzbu8BV15Qqzan);
			_0023_003DzoDiveDddlQSo(edge, _0023_003Dz98St4PSCKWvi: false, list, list2, list3, num, individualCurves, _0023_003Dzbu8BV15Qqzan);
		}
		_0023_003Dzg7GPRisTDc4YrOZqfdEXy3s_003D(surface, list, list2, list3, num, _0023_003Dzsvnj887WjFnx, list4, dictionary, _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D, _0023_003DzL8NvYU0_003D, _0023_003Dzbu8BV15Qqzan);
		if (_0023_003DzfT1oRNXkh4iVsabWuw_003D_003D && flag3)
		{
			int[] array8 = array3;
			foreach (int index in array8)
			{
				if (list3[index].needRebuild)
				{
					ICurve[] orientedTrimLoops = list3[index].GetOrientedTrimLoops(list2);
					list3[index].Surface = list3[index].Surface.GetExtended(orientedTrimLoops);
				}
			}
		}
		if (_0023_003DzRMO0hohF8hhA3Hyhdg_003D_003D && flag4)
		{
			int[] array8 = array4;
			foreach (int index2 in array8)
			{
				if (list3[index2].needRebuild)
				{
					ICurve[] orientedTrimLoops2 = list3[index2].GetOrientedTrimLoops(list2);
					list3[index2].Surface = list3[index2].Surface.GetExtended(orientedTrimLoops2);
				}
			}
		}
		_vertices = list.ToArray();
		_edges = list2.ToArray();
		if (edge.ShellIndex == 0)
		{
			_faces = list3.ToArray();
		}
		else
		{
			_inners[edge.ShellIndex - 1] = list3.ToArray();
		}
		_0023_003Dz8VkxvzXXGxA_0024(_vertices, _edges, _faces, _inners, _0023_003DzLuJVbec_003D: true);
		_0023_003DzUE6pJD8Y3NVt();
		_0023_003DzDumeg9jsTU7S(_0023_003Dzxt7paKBusKOo: true);
		_0023_003DzxW3N3i886iwK(null, null, 0, null);
		return ssiFailureType2;
	}

	private ssiFailureType _0023_003DzcWq4J0CHOIp2ctIRVg_003D_003D(int[] _0023_003DzQ75AoGvLuF3w_ivvcQ_003D_003D, Face[] _0023_003DzpPOEJqcAh7Lr, int _0023_003DzHUUmkb0uibv6, int _0023_003DzOhFjSPs8eMvF, bool[] _0023_003DzW_GftyAjFImwYcMC1w_003D_003D, Surface _0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D, double _0023_003Dzm0CYiiE_003D, bool _0023_003DzRFz6rqc_003D, Dictionary<int, int> _0023_003Dz5bUZxpy0IQVbatwCJQ_003D_003D)
	{
		ssiFailureType result = ssiFailureType.UnknownFailure;
		for (int i = 0; i < _0023_003DzQ75AoGvLuF3w_ivvcQ_003D_003D.Length; i++)
		{
			int num = _0023_003DzQ75AoGvLuF3w_ivvcQ_003D_003D[i];
			if (!_0023_003DzpPOEJqcAh7Lr[_0023_003DzHUUmkb0uibv6]._0023_003Dz7EOfQ_wBFahDw9Pn9w_003D_003D(_0023_003DzpPOEJqcAh7Lr[num], out var _0023_003DzzwoQwOglTJml3vqNGA_003D_003D, _0023_003Dzk_3tZjgmhGlmfKWn0g_003D_003D: false) && _0023_003DzpPOEJqcAh7Lr[_0023_003DzHUUmkb0uibv6]._0023_003DzaGX1f4XwdTHn(_0023_003DzpPOEJqcAh7Lr[num]) == Face.tangentType.none && !_0023_003DzpPOEJqcAh7Lr[_0023_003DzOhFjSPs8eMvF]._0023_003Dz7EOfQ_wBFahDw9Pn9w_003D_003D(_0023_003DzpPOEJqcAh7Lr[num], out _0023_003DzzwoQwOglTJml3vqNGA_003D_003D, _0023_003Dzk_3tZjgmhGlmfKWn0g_003D_003D: false) && _0023_003DzpPOEJqcAh7Lr[_0023_003DzOhFjSPs8eMvF]._0023_003DzaGX1f4XwdTHn(_0023_003DzpPOEJqcAh7Lr[num]) == Face.tangentType.none)
			{
				bool _0023_003DzaFEehOi8mwIq = !_0023_003DzW_GftyAjFImwYcMC1w_003D_003D[i];
				ssiFailureType ssiFailureType2 = _0023_003DzFjl3DvZvO_0024TMnWPrVR_00248NLs_003D(_0023_003DzpPOEJqcAh7Lr[num].Parametric[0], _0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D, _0023_003Dzm0CYiiE_003D, _0023_003DzaFEehOi8mwIq, _0023_003DzRFz6rqc_003D, _0023_003Dz5bUZxpy0IQVbatwCJQ_003D_003D, num);
				if (ssiFailureType2 != ssiFailureType.UnknownFailure)
				{
					result = ssiFailureType2;
				}
			}
		}
		return result;
	}

	private static void _0023_003Dzg7GPRisTDc4YrOZqfdEXy3s_003D(Surface _0023_003Dzxt7paKBusKOo, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, List<Edge> _0023_003DzViGQVPM_003D, List<Face> _0023_003DzUbkxYVFDH3ry, double _0023_003Dzm0CYiiE_003D, List<int> _0023_003Dzsvnj887WjFnx, List<int> _0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D, Dictionary<int, int> _0023_003Dz5bUZxpy0IQVbatwCJQ_003D_003D, List<int> _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D, int _0023_003DzL8NvYU0_003D, bool _0023_003Dzbu8BV15Qqzan)
	{
		List<ICurve> list = _0023_003Dzxt7paKBusKOo.Trimming.ContourList[0].GetIndividualCurves().ToList();
		for (int num = list.Count - 1; num >= 0; num--)
		{
			if (((TrimCurve)list[num]).Edge.Length() < _0023_003Dzm0CYiiE_003D)
			{
				if (_0023_003Dz5bUZxpy0IQVbatwCJQ_003D_003D.ContainsKey(list[num].EdgeIndex))
				{
					_0023_003DzUbkxYVFDH3ry[_0023_003Dz5bUZxpy0IQVbatwCJQ_003D_003D[list[num].EdgeIndex]]._0023_003Dz6Tva2mtI46vE(_0023_003DzL8NvYU0_003D);
				}
				list.RemoveAt(num);
			}
		}
		Loop loop = new Loop(new OrientedEdge[list.Count]);
		List<Tuple<int, int>> list2 = new List<Tuple<int, int>>();
		for (int i = 0; i < list.Count; i++)
		{
			ICurve edge = ((TrimCurve)list[i]).Edge;
			int _0023_003DzKiIL9O0_003D;
			int num2 = _0023_003Dz_0024qwEGejVavuKr9_0024r9w_003D_003D(edge, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003DzViGQVPM_003D, _0023_003DzUbkxYVFDH3ry, _0023_003Dzm0CYiiE_003D, _0023_003Dzsvnj887WjFnx, _0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D, out _0023_003DzKiIL9O0_003D);
			if (list[i].FromBooleanIntersection)
			{
				int num3 = _0023_003Dz5bUZxpy0IQVbatwCJQ_003D_003D[list[i].EdgeIndex];
				if (_0023_003DzUbkxYVFDH3ry[num3] != null && _0023_003DzvH1ZioS9o39mhji6j3g4nDA_0024JVAl(_0023_003DzUbkxYVFDH3ry, num3, _0023_003DzL8NvYU0_003D, _0023_003DzKiIL9O0_003D, _0023_003Dzm0CYiiE_003D, _0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D, _0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D, list2))
				{
					_0023_003DzViGQVPM_003D[_0023_003DzKiIL9O0_003D].Parents[1] = num3;
					Dictionary<int, int> _0023_003DzQtyBAo4gFsZY = new Dictionary<int, int>(1) { 
					{
						list[i].EdgeIndex,
						_0023_003DzKiIL9O0_003D
					} };
					_0023_003DzUbkxYVFDH3ry[num3]._0023_003Dzu_VTP2T_2LTBmaxiiTgVZUs_003D(_0023_003DzQtyBAo4gFsZY, _0023_003Dzm0CYiiE_003D, _0023_003DzvsFKDVZyhE_Q: true);
				}
			}
			else
			{
				bool flag = list[i].EdgeIndex == -2;
				if (list[i].EdgeIndex != -1 && !flag && _0023_003Dz5bUZxpy0IQVbatwCJQ_003D_003D.ContainsKey(list[i].EdgeIndex) && _0023_003Dz5bUZxpy0IQVbatwCJQ_003D_003D[list[i].EdgeIndex] != -1)
				{
					_0023_003DzVM06RfdVk4wS76LngJFWhCU_003D _0023_003DzVM06RfdVk4wS76LngJFWhCU_003D2 = new _0023_003DzVM06RfdVk4wS76LngJFWhCU_003D
					{
						_0023_003DzDVfrOi0_003D = new Tuple<int, int>(_0023_003Dz5bUZxpy0IQVbatwCJQ_003D_003D[list[i].EdgeIndex], _0023_003DzKiIL9O0_003D)
					};
					if (!list2.Exists(_0023_003DzVM06RfdVk4wS76LngJFWhCU_003D2._0023_003Dz6mk7xh5R_oukWJ6ZUe0AeXrGK1kwg2nDTQ_003D_003D))
					{
						list2.Add(_0023_003DzVM06RfdVk4wS76LngJFWhCU_003D2._0023_003DzDVfrOi0_003D);
					}
				}
			}
			bool sense = num2 != _0023_003DzViGQVPM_003D.Count || Vector3D.AreCoincident(_0023_003DzViGQVPM_003D[_0023_003DzKiIL9O0_003D].Curve.StartTangent, edge.StartTangent);
			list[i].EdgeIndex = _0023_003DzKiIL9O0_003D;
			loop.Segments[i] = new OrientedEdge(_0023_003DzKiIL9O0_003D, sense);
		}
		foreach (Tuple<int, int> item in list2)
		{
			for (int j = 0; j < _0023_003DzUbkxYVFDH3ry[item.Item1].Loops.Length; j++)
			{
				if (_0023_003DzUbkxYVFDH3ry[item.Item1]._0023_003DzFx_0024iwuIdvVT76znlPxoNiYjJkEnS(_0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, j, item.Item2, _0023_003Dzm0CYiiE_003D / 100.0))
				{
					_0023_003DzViGQVPM_003D[item.Item2].Parents[1] = item.Item1;
					_0023_003DzUbkxYVFDH3ry[item.Item1].needRebuild = true;
					break;
				}
			}
		}
		Surface obj = (Surface)_0023_003Dzxt7paKBusKOo.Clone();
		obj.Untrim();
		AnalyticSurf analyticSurf = obj._0023_003DzWTGiFlsuyM_0024wBdTI5w_003D_003D();
		Face face = new Face(analyticSurf, loop);
		if (!_0023_003Dzbu8BV15Qqzan && analyticSurf is SphericalSurf)
		{
			face.Sense = false;
		}
		face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(new Surface[1] { _0023_003Dzxt7paKBusKOo });
		face.needRebuild = false;
		_0023_003DzUbkxYVFDH3ry.Add(face);
	}

	private static int _0023_003Dz_0024qwEGejVavuKr9_0024r9w_003D_003D(ICurve _0023_003DzHXSVUTwh6gQ_0024, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, List<Edge> _0023_003DzViGQVPM_003D, List<Face> _0023_003DzUbkxYVFDH3ry, double _0023_003Dzm0CYiiE_003D, List<int> _0023_003Dzsvnj887WjFnx, List<int> _0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D, out int _0023_003DzKiIL9O0_003D)
	{
		int num = _0023_003DzbIDY9BOTPqfc(new Vertex(_0023_003DzHXSVUTwh6gQ_0024.StartPoint.X, _0023_003DzHXSVUTwh6gQ_0024.StartPoint.Y, _0023_003DzHXSVUTwh6gQ_0024.StartPoint.Z), _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dzm0CYiiE_003D, ref _0023_003Dzsvnj887WjFnx);
		if (!((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num]).Visited)
		{
			((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num]).Visited = true;
			((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num]).Parents = null;
		}
		int num2 = _0023_003DzbIDY9BOTPqfc(new Vertex(_0023_003DzHXSVUTwh6gQ_0024.EndPoint.X, _0023_003DzHXSVUTwh6gQ_0024.EndPoint.Y, _0023_003DzHXSVUTwh6gQ_0024.EndPoint.Z), _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, _0023_003Dzm0CYiiE_003D, ref _0023_003Dzsvnj887WjFnx);
		if (!((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num2]).Visited)
		{
			((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num2]).Visited = true;
			((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num2]).Parents = null;
		}
		Edge _0023_003DzXQ05_0024cQM5wVN = new Edge((ICurve)_0023_003DzHXSVUTwh6gQ_0024.Clone(), num, num2);
		int count = _0023_003DzViGQVPM_003D.Count;
		_0023_003DzKiIL9O0_003D = _0023_003DzbIDY9BOTPqfc(_0023_003DzXQ05_0024cQM5wVN, _0023_003DzViGQVPM_003D, _0023_003Dzm0CYiiE_003D, null, _0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D);
		_0023_003DzViGQVPM_003D[_0023_003DzKiIL9O0_003D].Curve.EdgeIndex = _0023_003DzKiIL9O0_003D;
		if (_0023_003DzViGQVPM_003D[_0023_003DzKiIL9O0_003D].Parents == null)
		{
			_0023_003DzViGQVPM_003D[_0023_003DzKiIL9O0_003D].Parents = new int[2];
			_0023_003DzViGQVPM_003D[_0023_003DzKiIL9O0_003D].Parents[0] = _0023_003DzUbkxYVFDH3ry.Count;
		}
		else
		{
			Array.Resize(ref _0023_003DzViGQVPM_003D[_0023_003DzKiIL9O0_003D].Parents, 2);
			_0023_003DzViGQVPM_003D[_0023_003DzKiIL9O0_003D].Parents[1] = _0023_003DzUbkxYVFDH3ry.Count;
		}
		int[] array = ((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num]).Parents;
		if (array == null)
		{
			((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num]).Parents = new int[1] { _0023_003DzKiIL9O0_003D };
		}
		else
		{
			Array.Resize(ref array, array.Length + 1);
			array[^1] = _0023_003DzKiIL9O0_003D;
			((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num]).Parents = array;
		}
		if (num2 != num)
		{
			array = ((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num2]).Parents;
			if (array == null)
			{
				((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num2]).Parents = new int[1] { _0023_003DzKiIL9O0_003D };
			}
			else
			{
				Array.Resize(ref array, array.Length + 1);
				array[^1] = _0023_003DzKiIL9O0_003D;
				((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num2]).Parents = array;
			}
		}
		return count;
	}

	private static void _0023_003Dzfp_0024xdsUDOPQDHwvBQtbLikbMb0OinnHmYA_003D_003D(Edge _0023_003DzTx2aqr8_003D, bool _0023_003DzwuxRad8_003D, bool _0023_003DzS7fMDL6Proy4, bool _0023_003Dz9Y6O910_003D, bool _0023_003Dzy0AC6xBDRVVL, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, int _0023_003DzL8NvYU0_003D, List<int> _0023_003Dzsvnj887WjFnx)
	{
		if (!_0023_003DzS7fMDL6Proy4 && ((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzTx2aqr8_003D.StartPointIndex]).Parents.Length <= 3)
		{
			if (_0023_003DzwuxRad8_003D)
			{
				_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzTx2aqr8_003D.StartPointIndex] = null;
			}
			else
			{
				Vertex vertex = (Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzTx2aqr8_003D.StartPointIndex];
				vertex._0023_003DznS097uo_003D(_0023_003DzL8NvYU0_003D);
				if (vertex.Parents == null || vertex.Parents.Length == 0)
				{
					_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzTx2aqr8_003D.StartPointIndex] = null;
				}
			}
			_0023_003Dzsvnj887WjFnx.Add(_0023_003DzTx2aqr8_003D.StartPointIndex);
		}
		if (_0023_003DzTx2aqr8_003D.EndPointIndex == _0023_003DzTx2aqr8_003D.StartPointIndex || _0023_003Dzy0AC6xBDRVVL || ((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzTx2aqr8_003D.EndPointIndex]).Parents.Length > 3)
		{
			return;
		}
		if (_0023_003Dz9Y6O910_003D)
		{
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzTx2aqr8_003D.EndPointIndex] = null;
		}
		else
		{
			Vertex vertex2 = (Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzTx2aqr8_003D.EndPointIndex];
			vertex2._0023_003DznS097uo_003D(_0023_003DzL8NvYU0_003D);
			if (vertex2.Parents == null || vertex2.Parents.Length == 0)
			{
				_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzTx2aqr8_003D.EndPointIndex] = null;
			}
		}
		_0023_003Dzsvnj887WjFnx.Add(_0023_003DzTx2aqr8_003D.EndPointIndex);
	}

	private static ssiFailureType _0023_003DzFjl3DvZvO_0024TMnWPrVR_00248NLs_003D(Surface _0023_003DzQjz1hx5kvolHEjX3PCD5vAA_003D, Surface _0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D, double _0023_003Dzm0CYiiE_003D, bool _0023_003DzaFEehOi8mwIq, bool _0023_003DzAqOpw0w_003D, Dictionary<int, int> _0023_003Dz5bUZxpy0IQVbatwCJQ_003D_003D, int _0023_003DzCPg7LvHY9aaq6GAW9w_003D_003D)
	{
		Surface surface = (Surface)_0023_003DzQjz1hx5kvolHEjX3PCD5vAA_003D.Clone();
		if (surface.IsClosedU || surface.IsClosedV || surface.IsPlanar(_0023_003Dzm0CYiiE_003D, out var _))
		{
			Point3D boxMin;
			Point3D boxMax;
			if (_0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D is TabulatedSurface)
			{
				ICurve curve = _0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.IsocurveU(_0023_003DzAqOpw0w_003D ? (_0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.DomainV.Low + _0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.DomainV.Length / 5.0) : (_0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.DomainV.High - _0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.DomainV.Length / 5.0));
				_0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.IsocurveU(_0023_003DzAqOpw0w_003D ? _0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.DomainV.Low : _0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.DomainV.High).GetNurbsForm().ControlBoundingBox(out var min, out var max);
				curve.GetNurbsForm().ControlBoundingBox(out var min2, out var max2);
				Utility.ComputeBoundingBox(new List<Point3D> { min, min2, max, max2 }, out boxMin, out boxMax);
			}
			else
			{
				ICurve curve2 = _0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.IsocurveV(_0023_003DzAqOpw0w_003D ? (_0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.DomainU.Low + _0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.DomainU.Length / 5.0) : (_0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.DomainU.High - _0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.DomainU.Length / 5.0));
				_0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.IsocurveV(_0023_003DzAqOpw0w_003D ? _0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.DomainU.Low : _0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.DomainU.High).GetNurbsForm().ControlBoundingBox(out var min3, out var max3);
				curve2.GetNurbsForm().ControlBoundingBox(out var min4, out var max4);
				Utility.ComputeBoundingBox(new List<Point3D> { min3, min4, max3, max4 }, out boxMin, out boxMax);
			}
			surface = surface._0023_003Dz9lEDaC6ts_0024AwxkwIiQ_003D_003D(boxMin, boxMax, _0023_003Dzm0CYiiE_003D);
		}
		else
		{
			surface._0023_003DzMu_zjZVLA1vc(0.25);
		}
		List<Surface> _0023_003DzSD7IY1eUqz9yNpTGBA_003D_003D = new List<Surface>();
		List<Surface> _0023_003Dzz_qlISsjX3ant40CJA_003D_003D = new List<Surface>();
		ssiFailureType ssiFailureType2 = Surface._0023_003DzS_0024pM1o19RjjX(new List<Surface> { _0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D }, new List<Surface> { surface }, _0023_003Dzm0CYiiE_003D, _0023_003DzaFEehOi8mwIq, _0023_003Dz9I3m6f9Si9Wb: false, _0023_003DzUVWKmG9exPuC: true, _0023_003DzoPXSzGAOaRPS: false, _0023_003DzSD7IY1eUqz9yNpTGBA_003D_003D, _0023_003Dzz_qlISsjX3ant40CJA_003D_003D, _0023_003Dz2VvYjXGXtcX2ylEto0HHodFWwtr1);
		if (ssiFailureType2 != ssiFailureType.Success && ssiFailureType2 != ssiFailureType.BoundaryProcessingFailed)
		{
			_0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.Untrim();
			return ssiFailureType2;
		}
		List<ICurve> list = _0023_003DzoU71_0024KYxBMRkhxN04A_003D_003D.Trimming.ContourList[0].GetIndividualCurves().ToList();
		for (int num = list.Count - 1; num >= 0; num--)
		{
			if (((TrimCurve)list[num]).Edge.Length() < _0023_003Dzm0CYiiE_003D)
			{
				list.RemoveAt(num);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			TrimCurve trimCurve = (TrimCurve)list[i];
			if (trimCurve.EdgeIndex < 0 && (trimCurve.EdgeIndex == -1 || surface._0023_003DzcjVMhDFVb35M(trimCurve.Edge.PointAt(trimCurve.Edge.Domain.Mid), _0023_003Dzm0CYiiE_003D)))
			{
				int key = (trimCurve.EdgeIndex = _0023_003Dz5bUZxpy0IQVbatwCJQ_003D_003D.Keys.Max() + 1);
				if (!_0023_003Dz5bUZxpy0IQVbatwCJQ_003D_003D.ContainsKey(key))
				{
					_0023_003Dz5bUZxpy0IQVbatwCJQ_003D_003D.Add(key, _0023_003DzCPg7LvHY9aaq6GAW9w_003D_003D);
				}
			}
		}
		return ssiFailureType.Success;
	}

	private static bool _0023_003Dz2VvYjXGXtcX2ylEto0HHodFWwtr1(Surface _0023_003DzhidJeNw_003D, Surface _0023_003Dz5rQzobg_003D, List<ICurve> _0023_003Dzwkc4gyXSPYcwB1NPBA_003D_003D, List<ICurve> _0023_003Dz1e137UCo69FgKytJgw_003D_003D, int _0023_003DzgifFiMiKBlLc)
	{
		double num = 0.2 * _0023_003DzhidJeNw_003D.DomainU.Length;
		bool result = false;
		for (int num2 = _0023_003Dzwkc4gyXSPYcwB1NPBA_003D_003D.Count - 1; num2 >= _0023_003DzgifFiMiKBlLc; num2--)
		{
			double x = _0023_003Dzwkc4gyXSPYcwB1NPBA_003D_003D[num2].StartPoint.X;
			double x2 = _0023_003Dzwkc4gyXSPYcwB1NPBA_003D_003D[num2].EndPoint.X;
			if (!(Math.Abs(x - _0023_003DzhidJeNw_003D.DomainU.Low) < num) && !(Math.Abs(x - _0023_003DzhidJeNw_003D.DomainU.High) < num) && !(Math.Abs(x2 - _0023_003DzhidJeNw_003D.DomainU.Low) < num) && !(Math.Abs(x2 - _0023_003DzhidJeNw_003D.DomainU.High) < num))
			{
				_0023_003Dzwkc4gyXSPYcwB1NPBA_003D_003D.RemoveAt(num2);
				_0023_003Dz1e137UCo69FgKytJgw_003D_003D.RemoveAt(num2);
				result = true;
			}
		}
		return result;
	}

	private bool _0023_003DzTCK5_nRS5GCJ(int[] _0023_003DzKDBGZVxi5nWOV8ysnA_003D_003D, int[] _0023_003DzqC3gzB37aoM3QFjoOrmSygU_003D, Face[] _0023_003DzpPOEJqcAh7Lr, bool _0023_003DzoH2XBeyWRP2k77kumpfyWFQ_003D, double _0023_003Dzm0CYiiE_003D, bool[] _0023_003DzGk9rOSW9NYc1FMPBgQ_003D_003D)
	{
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < _0023_003DzKDBGZVxi5nWOV8ysnA_003D_003D.Length; i++)
		{
			bool flag3 = false;
			for (int j = 0; j < _0023_003DzqC3gzB37aoM3QFjoOrmSygU_003D.Length; j++)
			{
				int num = _0023_003DzqC3gzB37aoM3QFjoOrmSygU_003D[j];
				if (Edges[num].Parents.Contains(_0023_003DzKDBGZVxi5nWOV8ysnA_003D_003D[i]) && _0023_003DzZd8B81_0024nDQA_0024m4kvBg_003D_003D(num, _0023_003Dzm0CYiiE_003D, out var _0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D))
				{
					if (!flag3)
					{
						_0023_003DzGk9rOSW9NYc1FMPBgQ_003D_003D[i] = _0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D;
						flag3 = true;
					}
					else if (_0023_003DzoH2XBeyWRP2k77kumpfyWFQ_003D)
					{
						_0023_003DzGk9rOSW9NYc1FMPBgQ_003D_003D[i] &= _0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D;
					}
					else
					{
						_0023_003DzGk9rOSW9NYc1FMPBgQ_003D_003D[i] |= _0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D;
					}
					if (i == 0 && j == 0)
					{
						flag = _0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D;
					}
					else if (flag != _0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D)
					{
						flag2 = true;
					}
				}
			}
		}
		if (!flag2 && !_0023_003DzoH2XBeyWRP2k77kumpfyWFQ_003D && _0023_003DzKDBGZVxi5nWOV8ysnA_003D_003D.Length > 1)
		{
			flag2 = true;
		}
		return flag2;
	}

	private bool _0023_003DzZd8B81_0024nDQA_0024m4kvBg_003D_003D(int _0023_003DzbfrNXYE_003D, double _0023_003Dzm0CYiiE_003D, out bool _0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D)
	{
		_0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D = false;
		Edge edge = Edges[_0023_003DzbfrNXYE_003D];
		if (!_0023_003Dz_0024WTkU9JSY152(edge, _0023_003Dzm0CYiiE_003D, out var _0023_003Dz3jDpzyJtb3_0024Nm8rt_0024Q_003D_003D))
		{
			return false;
		}
		int num = (_0023_003Dz3jDpzyJtb3_0024Nm8rt_0024Q_003D_003D ? edge.Parents[1] : edge.Parents[0]);
		int num2 = (_0023_003Dz3jDpzyJtb3_0024Nm8rt_0024Q_003D_003D ? edge.Parents[0] : edge.Parents[1]);
		Face[] array = ((edge.ShellIndex == 0) ? Faces : Inners[edge.ShellIndex - 1]);
		int num3 = _0023_003DzJSH_hr4DJ0qh6mo3EHwcQyo_003D(_0023_003DzbfrNXYE_003D, array[num]);
		int num4 = _0023_003DzJSH_hr4DJ0qh6mo3EHwcQyo_003D(_0023_003DzbfrNXYE_003D, array[num2]);
		if (num4 == -1 || num3 == -1)
		{
			return false;
		}
		_0023_003DzzHJb0M9USFYG(_0023_003DzbfrNXYE_003D, array[num], array[num2], num3, num4, out _0023_003DzU1WyD_0024dw0pLmBgRB_g_003D_003D);
		return true;
	}

	private static void _0023_003DzKnPF1H2VIOwi(TrimCurve _0023_003Dz5ppsz047J0_0024n, List<Face> _0023_003DzUbkxYVFDH3ry, int _0023_003DzHUUmkb0uibv6, List<Edge> _0023_003DzViGQVPM_003D, int _0023_003DzL8NvYU0_003D, double _0023_003Dzm0CYiiE_003D, Dictionary<int, int> _0023_003DzwmWYj8H9roGZ, List<int> _0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D)
	{
		_0023_003DzBXl2jEce9tintKxz1V2lw3E_003D CS_0024_003C_003E8__locals5 = new _0023_003DzBXl2jEce9tintKxz1V2lw3E_003D();
		CS_0024_003C_003E8__locals5._0023_003DzHUUmkb0uibv6 = _0023_003DzHUUmkb0uibv6;
		int num = -1;
		Loop[] loops = _0023_003DzUbkxYVFDH3ry[CS_0024_003C_003E8__locals5._0023_003DzHUUmkb0uibv6].Loops;
		for (int i = 0; i < loops.Length; i++)
		{
			OrientedEdge[] segments = loops[i].Segments;
			for (int j = 0; j < segments.Length; j++)
			{
				OrientedEdge orientedEdge = segments[j];
				bool flag = false;
				if (num == -1)
				{
					flag = Utility._0023_003DzZCuAc1AnKVueDa_Q8w_003D_003D(_0023_003DzViGQVPM_003D[orientedEdge.CurveIndex].Curve, _0023_003Dz5ppsz047J0_0024n.Edge, out var _, 1.0) >= 0;
					if (flag)
					{
						num = orientedEdge.CurveIndex;
					}
				}
				if (!flag && orientedEdge.CurveIndex != _0023_003DzL8NvYU0_003D)
				{
					int index = _0023_003DzViGQVPM_003D[orientedEdge.CurveIndex].Parents.First((int _0023_003DzB68dg9Q_003D) => _0023_003DzB68dg9Q_003D != CS_0024_003C_003E8__locals5._0023_003DzHUUmkb0uibv6);
					_0023_003DzUbkxYVFDH3ry[index]._0023_003Dz6Tva2mtI46vE(orientedEdge.CurveIndex);
					_0023_003DzViGQVPM_003D[orientedEdge.CurveIndex] = null;
					_0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D.Add(orientedEdge.CurveIndex);
				}
			}
		}
		if (num != -1)
		{
			int num2 = _0023_003DzViGQVPM_003D[num].Parents.First(CS_0024_003C_003E8__locals5._0023_003DzzWGLMtLQHomKan1p9DsfzdQ_003D);
			_0023_003DzViGQVPM_003D[num].Parents = new int[1] { num2 };
			_0023_003DzwmWYj8H9roGZ[_0023_003Dz5ppsz047J0_0024n.EdgeIndex] = num2;
		}
		_0023_003DzUbkxYVFDH3ry[CS_0024_003C_003E8__locals5._0023_003DzHUUmkb0uibv6] = null;
	}

	private bool _0023_003DzkDcf5W3CxoRl4jCPt0PtwGk_003D(Edge _0023_003DzTx2aqr8_003D, out Surface[] _0023_003DzU7OxNcM1zxhB, out Surface[] _0023_003DzPuJY3x2xFYgq, out int _0023_003Dz1rhp9xojqX85, out int _0023_003DzYIkKipeHCLZv)
	{
		if (_0023_003DzTx2aqr8_003D.Parents[0] == _0023_003DzTx2aqr8_003D.Parents[1])
		{
			_0023_003DzU7OxNcM1zxhB = new Surface[0];
			_0023_003DzPuJY3x2xFYgq = new Surface[0];
			_0023_003Dz1rhp9xojqX85 = -1;
			_0023_003DzYIkKipeHCLZv = -1;
			return false;
		}
		Face[] array = ((_0023_003DzTx2aqr8_003D.ShellIndex == 0) ? Faces : Inners[_0023_003DzTx2aqr8_003D.ShellIndex - 1]);
		if (array[_0023_003DzTx2aqr8_003D.Parents[0]].Parametric == null || array[_0023_003DzTx2aqr8_003D.Parents[1]].Parametric == null)
		{
			Rebuild(0.0, soft: true);
		}
		Face face = (Face)array[_0023_003DzTx2aqr8_003D.Parents[0]].Clone();
		Face face2 = (Face)array[_0023_003DzTx2aqr8_003D.Parents[1]].Clone();
		_0023_003DzVBezP1GqFkfaNh7Evfs0OoA_003D(array[_0023_003DzTx2aqr8_003D.Parents[0]], face);
		_0023_003DzVBezP1GqFkfaNh7Evfs0OoA_003D(array[_0023_003DzTx2aqr8_003D.Parents[1]], face2);
		_0023_003DzU7OxNcM1zxhB = face.Parametric;
		_0023_003DzPuJY3x2xFYgq = face2.Parametric;
		_0023_003Dz1rhp9xojqX85 = _0023_003DzTx2aqr8_003D.Parents[0];
		_0023_003DzYIkKipeHCLZv = _0023_003DzTx2aqr8_003D.Parents[1];
		return true;
	}

	private static void _0023_003DzVBezP1GqFkfaNh7Evfs0OoA_003D(Face _0023_003Dzb7SPTpc_003D, Face _0023_003DzaoQTclc_003D)
	{
		if (_0023_003Dzb7SPTpc_003D.Parametric != null)
		{
			_0023_003DzaoQTclc_003D._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(new Surface[_0023_003Dzb7SPTpc_003D.Parametric.Length]);
			for (int i = 0; i < _0023_003Dzb7SPTpc_003D.Parametric.Length; i++)
			{
				_0023_003DzaoQTclc_003D.Parametric[i] = (Surface)_0023_003Dzb7SPTpc_003D.Parametric[i].Clone();
			}
			_0023_003DzaoQTclc_003D.needRebuild = _0023_003Dzb7SPTpc_003D.needRebuild;
		}
	}

	private List<_0023_003Dz9bSHHx6Gf6fW0XQmwNcsniYkCPi9_0024l0r2gjzys8_003D> _0023_003DzT8cuf6q1lV9tLglxp5vPGYc_003D(Edge _0023_003DzTx2aqr8_003D, List<Surface> _0023_003Dzm30uCFw_003D, List<Surface> _0023_003DzCE1nYNI_003D, double _0023_003DzKQtixx1nLBno7hO2_0024A_003D_003D, bool _0023_003DztxUNNkRDb4orZsoZjA_003D_003D, bool _0023_003Dzbu8BV15Qqzan, double _0023_003DzEGKj_0024SNUUihi, bool _0023_003DzTcFGbxcG1Gf9, out int _0023_003Dz9EMF9D5SvqdX, out int _0023_003DzNu7esSs8sEDi, out Surface._0023_003DzNmB23wM0JqUW99SXKg_003D_003D _0023_003DzNmB23wM0JqUW99SXKg_003D_003D)
	{
		List<_0023_003Dz9bSHHx6Gf6fW0XQmwNcsniYkCPi9_0024l0r2gjzys8_003D> list = new List<_0023_003Dz9bSHHx6Gf6fW0XQmwNcsniYkCPi9_0024l0r2gjzys8_003D>();
		int _0023_003DzCuZj25pdHPFr = _0023_003DzTx2aqr8_003D.Parents[_0023_003DztxUNNkRDb4orZsoZjA_003D_003D ? 1u : 0u];
		int _0023_003DzCuZj25pdHPFr2 = _0023_003DzTx2aqr8_003D.Parents[(!_0023_003DztxUNNkRDb4orZsoZjA_003D_003D) ? 1u : 0u];
		_0023_003Dz9EMF9D5SvqdX = 2;
		_0023_003DzNu7esSs8sEDi = 0;
		_0023_003DzNmB23wM0JqUW99SXKg_003D_003D = (Surface._0023_003DzNmB23wM0JqUW99SXKg_003D_003D)0;
		if (_0023_003DzTx2aqr8_003D.Curve != null)
		{
			ICurve curve = _0023_003DzTx2aqr8_003D.Curve;
			_0023_003Dz9bSHHx6Gf6fW0XQmwNcsniYkCPi9_0024l0r2gjzys8_003D item = new _0023_003Dz9bSHHx6Gf6fW0XQmwNcsniYkCPi9_0024l0r2gjzys8_003D
			{
				_0023_003DzHit7vU4_003D = _0023_003Dzm30uCFw_003D[0]._0023_003Dz1PC0lMBv7hGP(),
				_0023_003DzFmiij5k_003D = _0023_003DzCE1nYNI_003D[0]._0023_003Dz1PC0lMBv7hGP()
			};
			Surface._0023_003DzyQAinSVKfzcy0dfn0Q_003D_003D(_0023_003DzEGKj_0024SNUUihi, _0023_003DzEGKj_0024SNUUihi, item._0023_003DzHit7vU4_003D, item._0023_003DzFmiij5k_003D, _0023_003DzTcFGbxcG1Gf9, out _0023_003Dz9EMF9D5SvqdX, out _0023_003DzNu7esSs8sEDi, out _0023_003DzNmB23wM0JqUW99SXKg_003D_003D);
			item._0023_003DzPEa0u5IwfWZxn_0024Eqbg_003D_003D = _0023_003DzNmB23wM0JqUW99SXKg_003D_003D;
			item._0023_003DznZIXBbdywAOduoZ3Tg_003D_003D = _0023_003Dzm30uCFw_003D[0];
			item._0023_003Dz0ert22Dvth2XQJZwBA_003D_003D = _0023_003DzCE1nYNI_003D[0];
			TrimCurve trimCurve = null;
			TrimCurve trimCurve2 = null;
			bool flag = false;
			trimCurve = _0023_003Dzv53lvzq6BUu7SyGSDQ_003D_003D(_0023_003DzTx2aqr8_003D.StartPointIndex, _0023_003DzTx2aqr8_003D.Curve.EdgeIndex, _0023_003DzTx2aqr8_003D.ShellIndex, _0023_003DzCuZj25pdHPFr, _0023_003Dzm30uCFw_003D, _0023_003Dzbu8BV15Qqzan, _0023_003DzKQtixx1nLBno7hO2_0024A_003D_003D, _0023_003DzE_mX6AnTpbMv: true);
			if (trimCurve == null)
			{
				flag = true;
				trimCurve = _0023_003Dzv53lvzq6BUu7SyGSDQ_003D_003D(_0023_003DzTx2aqr8_003D.StartPointIndex, _0023_003DzTx2aqr8_003D.Curve.EdgeIndex, _0023_003DzTx2aqr8_003D.ShellIndex, _0023_003DzCuZj25pdHPFr2, _0023_003DzCE1nYNI_003D, _0023_003Dzbu8BV15Qqzan, _0023_003DzKQtixx1nLBno7hO2_0024A_003D_003D, _0023_003DzE_mX6AnTpbMv: true);
			}
			else
			{
				trimCurve2 = _0023_003Dzv53lvzq6BUu7SyGSDQ_003D_003D(_0023_003DzTx2aqr8_003D.StartPointIndex, _0023_003DzTx2aqr8_003D.Curve.EdgeIndex, _0023_003DzTx2aqr8_003D.ShellIndex, _0023_003DzCuZj25pdHPFr2, _0023_003DzCE1nYNI_003D, _0023_003Dzbu8BV15Qqzan, _0023_003DzKQtixx1nLBno7hO2_0024A_003D_003D, _0023_003DzE_mX6AnTpbMv: true);
			}
			item._0023_003DzYqa83Us_003D = trimCurve;
			item._0023_003DzccAR5G0_003D = _0023_003DzTx2aqr8_003D.Curve.Length();
			item._0023_003DzCJkr8nY_003D = 1.0;
			item._0023_003DzYqa83Us_003D = (Curve)_0023_003DzTx2aqr8_003D.Curve.GetNurbsForm().Clone();
			item._0023_003DzhXNLMIHOUegn = new PointTangent[2];
			Point3D point3D = (Point3D)curve.StartPoint.Clone();
			Point3D point3D2 = (Point3D)curve.EndPoint.Clone();
			item._0023_003DzHit7vU4_003D.Project(point3D, out var u, out var v);
			item._0023_003DzFmiij5k_003D.Project(point3D, out var u2, out var v2);
			InitialPoint initialPoint = new InitialPoint(point3D.X, point3D.Y, point3D.Z, 0.0, 0.0, 0.0, 0.0);
			if (flag)
			{
				initialPoint.u = u2;
				initialPoint.v = v2;
				initialPoint.s = u;
				initialPoint.t = v;
				initialPoint.startPointCurveOwner = ((trimCurve == null) ? null : _0023_003DzCE1nYNI_003D[0]._0023_003Dz1PC0lMBv7hGP());
				initialPoint._0023_003Dzykss8zCkIIpmZGGp6g_003D_003D = ((trimCurve2 == null) ? null : _0023_003Dzm30uCFw_003D[0]._0023_003Dz1PC0lMBv7hGP());
			}
			else
			{
				initialPoint.u = u;
				initialPoint.v = v;
				initialPoint.s = u2;
				initialPoint.t = v2;
				initialPoint.startPointCurveOwner = ((trimCurve == null) ? null : _0023_003Dzm30uCFw_003D[0]._0023_003Dz1PC0lMBv7hGP());
				initialPoint._0023_003Dzykss8zCkIIpmZGGp6g_003D_003D = ((trimCurve2 == null) ? null : _0023_003DzCE1nYNI_003D[0]._0023_003Dz1PC0lMBv7hGP());
			}
			initialPoint._0023_003DzutFG6gdoV0Ic = trimCurve;
			initialPoint._0023_003DzAWeAyU4FWrA8I442mQ_003D_003D = trimCurve2;
			Vector3D startTangent = curve.StartTangent;
			startTangent.Normalize();
			initialPoint.Tx = startTangent.X;
			initialPoint.Ty = startTangent.Y;
			initialPoint.Tz = startTangent.Z;
			if (trimCurve != null)
			{
				initialPoint.curveTx = trimCurve.Edge.StartTangent.X;
				initialPoint.curveTy = trimCurve.Edge.StartTangent.Y;
				initialPoint.curveTz = trimCurve.Edge.StartTangent.Z;
				if (!flag)
				{
					Surface._0023_003DzhnC3thPzhntEomwmJQ_003D_003D(initialPoint, _0023_003Dzm30uCFw_003D[0]._0023_003Dz1PC0lMBv7hGP(), _0023_003DzCE1nYNI_003D[0]._0023_003Dz1PC0lMBv7hGP(), _0023_003DzTx2aqr8_003D.Curve.Length());
				}
				else
				{
					Surface._0023_003DzqXlnzeBE597qWuJw1A_003D_003D(initialPoint, _0023_003Dzm30uCFw_003D[0]._0023_003Dz1PC0lMBv7hGP(), _0023_003DzCE1nYNI_003D[0]._0023_003Dz1PC0lMBv7hGP(), _0023_003DzTx2aqr8_003D.Curve.Length());
				}
			}
			item._0023_003DzhXNLMIHOUegn[0] = initialPoint;
			TrimCurve trimCurve3 = null;
			TrimCurve trimCurve4 = null;
			bool flag2 = false;
			trimCurve3 = _0023_003Dzv53lvzq6BUu7SyGSDQ_003D_003D(_0023_003DzTx2aqr8_003D.EndPointIndex, _0023_003DzTx2aqr8_003D.Curve.EdgeIndex, _0023_003DzTx2aqr8_003D.ShellIndex, _0023_003DzCuZj25pdHPFr, _0023_003Dzm30uCFw_003D, _0023_003Dzbu8BV15Qqzan, _0023_003DzKQtixx1nLBno7hO2_0024A_003D_003D, _0023_003DzE_mX6AnTpbMv: false);
			if (trimCurve3 == null)
			{
				flag2 = true;
				trimCurve3 = _0023_003Dzv53lvzq6BUu7SyGSDQ_003D_003D(_0023_003DzTx2aqr8_003D.EndPointIndex, _0023_003DzTx2aqr8_003D.Curve.EdgeIndex, _0023_003DzTx2aqr8_003D.ShellIndex, _0023_003DzCuZj25pdHPFr2, _0023_003DzCE1nYNI_003D, _0023_003Dzbu8BV15Qqzan, _0023_003DzKQtixx1nLBno7hO2_0024A_003D_003D, _0023_003DzE_mX6AnTpbMv: false);
			}
			else
			{
				trimCurve4 = _0023_003Dzv53lvzq6BUu7SyGSDQ_003D_003D(_0023_003DzTx2aqr8_003D.EndPointIndex, _0023_003DzTx2aqr8_003D.Curve.EdgeIndex, _0023_003DzTx2aqr8_003D.ShellIndex, _0023_003DzCuZj25pdHPFr2, _0023_003DzCE1nYNI_003D, _0023_003Dzbu8BV15Qqzan, _0023_003DzKQtixx1nLBno7hO2_0024A_003D_003D, _0023_003DzE_mX6AnTpbMv: false);
			}
			item._0023_003DzHit7vU4_003D.Project(point3D2, out var u3, out var v3);
			item._0023_003DzFmiij5k_003D.Project(point3D2, out var u4, out var v4);
			InitialPoint initialPoint2 = new InitialPoint(point3D2.X, point3D2.Y, point3D2.Z, 0.0, 0.0, 0.0, 0.0);
			if (flag2)
			{
				initialPoint2.u = u4;
				initialPoint2.v = v4;
				initialPoint2.s = u3;
				initialPoint2.t = v3;
				initialPoint2.startPointCurveOwner = ((trimCurve3 == null) ? null : _0023_003DzCE1nYNI_003D[0]._0023_003Dz1PC0lMBv7hGP());
				initialPoint2._0023_003Dzykss8zCkIIpmZGGp6g_003D_003D = ((trimCurve4 == null) ? null : _0023_003Dzm30uCFw_003D[0]._0023_003Dz1PC0lMBv7hGP());
			}
			else
			{
				initialPoint2.u = u3;
				initialPoint2.v = v3;
				initialPoint2.s = u4;
				initialPoint2.t = v4;
				initialPoint2.startPointCurveOwner = ((trimCurve3 == null) ? null : _0023_003Dzm30uCFw_003D[0]._0023_003Dz1PC0lMBv7hGP());
				initialPoint2._0023_003Dzykss8zCkIIpmZGGp6g_003D_003D = ((trimCurve4 == null) ? null : _0023_003DzCE1nYNI_003D[0]._0023_003Dz1PC0lMBv7hGP());
			}
			initialPoint2._0023_003DzutFG6gdoV0Ic = trimCurve3;
			initialPoint2._0023_003DzAWeAyU4FWrA8I442mQ_003D_003D = trimCurve4;
			Vector3D endTangent = curve.EndTangent;
			endTangent.Normalize();
			initialPoint2.Tx = endTangent.X;
			initialPoint2.Ty = endTangent.Y;
			initialPoint2.Tz = endTangent.Z;
			if (trimCurve3 != null)
			{
				initialPoint2.curveTx = trimCurve3.Edge.EndTangent.X;
				initialPoint2.curveTy = trimCurve3.Edge.EndTangent.Y;
				initialPoint2.curveTz = trimCurve3.Edge.EndTangent.Z;
				if (!flag2)
				{
					Surface._0023_003DzhnC3thPzhntEomwmJQ_003D_003D(initialPoint2, _0023_003Dzm30uCFw_003D[0]._0023_003Dz1PC0lMBv7hGP(), _0023_003DzCE1nYNI_003D[0]._0023_003Dz1PC0lMBv7hGP(), _0023_003DzTx2aqr8_003D.Curve.Length());
				}
				else
				{
					Surface._0023_003DzqXlnzeBE597qWuJw1A_003D_003D(initialPoint2, _0023_003Dzm30uCFw_003D[0]._0023_003Dz1PC0lMBv7hGP(), _0023_003DzCE1nYNI_003D[0]._0023_003Dz1PC0lMBv7hGP(), _0023_003DzTx2aqr8_003D.Curve.Length());
				}
			}
			item._0023_003DzhXNLMIHOUegn[item._0023_003DzhXNLMIHOUegn.Length - 1] = initialPoint2;
			list.Add(item);
		}
		return list;
	}

	private TrimCurve _0023_003Dzv53lvzq6BUu7SyGSDQ_003D_003D(int _0023_003DzEyJj6vAwGjIK4Pe84A_003D_003D, int _0023_003DzL8NvYU0_003D, int _0023_003DzRLCcpW4_003D, int _0023_003DzCuZj25pdHPFr, IList<Surface> _0023_003Dzqh5Pnk7eNMWL0eTkbQ_003D_003D, bool _0023_003Dzbu8BV15Qqzan, double _0023_003DzKQtixx1nLBno7hO2_0024A_003D_003D, bool _0023_003DzE_mX6AnTpbMv)
	{
		Loop[] array = ((_0023_003DzRLCcpW4_003D == 0) ? Faces[_0023_003DzCuZj25pdHPFr].Loops : Inners[_0023_003DzRLCcpW4_003D - 1][_0023_003DzCuZj25pdHPFr].Loops);
		foreach (Loop loop in array)
		{
			int num = loop.Segments.Length;
			for (int j = 0; j < num; j++)
			{
				if (loop.Segments[j].CurveIndex != _0023_003DzL8NvYU0_003D)
				{
					continue;
				}
				bool flag = Edges[_0023_003DzL8NvYU0_003D].StartPointIndex == _0023_003DzEyJj6vAwGjIK4Pe84A_003D_003D;
				if (Edges[_0023_003DzL8NvYU0_003D].StartPointIndex == Edges[_0023_003DzL8NvYU0_003D].EndPointIndex)
				{
					flag = _0023_003DzE_mX6AnTpbMv;
				}
				bool flag2 = flag == (loop.Segments[j].Sense == loop.Sense == !_0023_003Dzbu8BV15Qqzan);
				foreach (Surface item in _0023_003Dzqh5Pnk7eNMWL0eTkbQ_003D_003D)
				{
					foreach (ICurve contour in item.Trimming.ContourList)
					{
						ICurve[] individualCurves = contour.GetIndividualCurves();
						for (int k = 0; k < individualCurves.Length; k++)
						{
							TrimCurve trimCurve = (TrimCurve)individualCurves[k];
							if (trimCurve.EdgeIndex == _0023_003DzL8NvYU0_003D)
							{
								int num2 = ((flag2 ? (k - 1) : (k + 1)) % individualCurves.Length + individualCurves.Length) % individualCurves.Length;
								TrimCurve trimCurve2 = (TrimCurve)individualCurves[num2];
								double t = (flag2 ? trimCurve.Edge.Domain.Low : trimCurve.Edge.Domain.High);
								double t2 = (flag2 ? trimCurve2.Edge.Domain.High : trimCurve2.Edge.Domain.Low);
								Vector3D vector3D = trimCurve.Edge.TangentAt(t);
								Vector3D vector3D2 = trimCurve2.Edge.TangentAt(t2);
								vector3D.Normalize();
								vector3D2.Normalize();
								if (!Vector3D.AreParallel(vector3D, vector3D2, _0023_003DzKQtixx1nLBno7hO2_0024A_003D_003D))
								{
									return trimCurve2;
								}
								return null;
							}
						}
					}
				}
			}
		}
		return null;
	}

	private static bool _0023_003DzvH1ZioS9o39mhji6j3g4nDA_0024JVAl(List<Face> _0023_003DzUbkxYVFDH3ry, int _0023_003Dzfe2zeQMumw_4, int _0023_003DzAJYZcKw_003D, int _0023_003DzqhsKlJc_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, List<Edge> _0023_003DzViGQVPM_003D, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, List<int> _0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D, List<int> _0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D, List<Tuple<int, int>> _0023_003DzIrfEWrXUlD53)
	{
		Loop[] loops = _0023_003DzUbkxYVFDH3ry[_0023_003Dzfe2zeQMumw_4].Loops;
		Edge edge = _0023_003DzViGQVPM_003D[_0023_003DzqhsKlJc_003D];
		bool flag = edge.EndPointIndex == edge.StartPointIndex;
		for (int i = 0; i < loops.Length; i++)
		{
			OrientedEdge[] segments = loops[i].Segments;
			bool sense = loops[i].Sense;
			for (int j = 0; j < segments.Length; j++)
			{
				if (segments[j].CurveIndex != _0023_003DzAJYZcKw_003D)
				{
					continue;
				}
				int num = ((j == 0) ? (segments.Length - 1) : (j - 1));
				int num2 = ((j != segments.Length - 1) ? (j + 1) : 0);
				if (segments.Length > 1)
				{
					int num3 = (sense ? edge.EndPointIndex : edge.StartPointIndex);
					int num4 = (sense ? edge.StartPointIndex : edge.EndPointIndex);
					OrientedEdge orientedEdge = segments[num];
					int curveIndex = orientedEdge.CurveIndex;
					OrientedEdge orientedEdge2 = segments[num2];
					int curveIndex2 = orientedEdge2.CurveIndex;
					if (curveIndex != curveIndex2 || flag)
					{
						int num5 = -1;
						int num6 = -1;
						if (_0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D == null || !_0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.Contains(curveIndex))
						{
							ICurve curve = _0023_003DzViGQVPM_003D[curveIndex].Curve;
							Edge edge2;
							if (orientedEdge.Sense)
							{
								edge2 = _0023_003DziOhtUfKDpQ_zDVq0BA_003D_003D(_0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, curveIndex, _0023_003DzViGQVPM_003D[curveIndex].StartPointIndex, num3);
								if (edge2 == null)
								{
									Point3D _0023_003DzxIcuzwZ7lStX = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num3];
									Point3D endPoint = curve.EndPoint;
									double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D = curve.Length() * 1E-05;
									num5 = _0023_003DzkUMRMNfp3zKwu43sCQ_003D_003D(_0023_003DzUbkxYVFDH3ry[_0023_003Dzfe2zeQMumw_4].Parametric[0], _0023_003DzViGQVPM_003D, _0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, endPoint, _0023_003DzxIcuzwZ7lStX, _0023_003DzViGQVPM_003D[curveIndex].EndPointIndex, num3);
								}
							}
							else
							{
								edge2 = _0023_003DziOhtUfKDpQ_zDVq0BA_003D_003D(_0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, curveIndex, num3, _0023_003DzViGQVPM_003D[curveIndex].EndPointIndex);
								if (edge2 == null)
								{
									Point3D _0023_003DzxIcuzwZ7lStX2 = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num3];
									Point3D startPoint = curve.StartPoint;
									double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D2 = curve.Length() * 1E-05;
									num5 = _0023_003DzkUMRMNfp3zKwu43sCQ_003D_003D(_0023_003DzUbkxYVFDH3ry[_0023_003Dzfe2zeQMumw_4].Parametric[0], _0023_003DzViGQVPM_003D, _0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D2, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, startPoint, _0023_003DzxIcuzwZ7lStX2, _0023_003DzViGQVPM_003D[curveIndex].StartPointIndex, num3);
								}
							}
							if (edge2 != null)
							{
								_0023_003DzViGQVPM_003D[curveIndex] = edge2;
								int[] array = ((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num3]).Parents;
								if (!array.Contains(curveIndex))
								{
									Array.Resize(ref array, array.Length + 1);
									array[^1] = curveIndex;
									((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num3]).Parents = array;
								}
							}
							else
							{
								_0023_003DzViGQVPM_003D[num5].Parents = new int[2];
								_0023_003DzViGQVPM_003D[num5].Parents[0] = _0023_003Dzfe2zeQMumw_4;
								int[] parents = ((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzViGQVPM_003D[num5].StartPointIndex]).Parents;
								foreach (int num7 in parents)
								{
									if (num7 == _0023_003DzqhsKlJc_003D || num7 == _0023_003DzAJYZcKw_003D)
									{
										continue;
									}
									for (int l = 0; l < _0023_003DzViGQVPM_003D[num7].Parents.Length; l++)
									{
										_0023_003DzPo0945mwOhxL_0024aiBNElAmFQ_003D _0023_003DzPo0945mwOhxL_0024aiBNElAmFQ_003D2 = new _0023_003DzPo0945mwOhxL_0024aiBNElAmFQ_003D();
										int item = _0023_003DzViGQVPM_003D[num7].Parents[l];
										_0023_003DzPo0945mwOhxL_0024aiBNElAmFQ_003D2._0023_003DzDVfrOi0_003D = new Tuple<int, int>(item, num5);
										if (!_0023_003DzIrfEWrXUlD53.Exists(_0023_003DzPo0945mwOhxL_0024aiBNElAmFQ_003D2._0023_003DzDxINQmRyCj750lEiIg2qAGZ89nZGsHZUug_003D_003D))
										{
											_0023_003DzIrfEWrXUlD53.Add(_0023_003DzPo0945mwOhxL_0024aiBNElAmFQ_003D2._0023_003DzDVfrOi0_003D);
										}
									}
								}
							}
						}
						if (_0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D == null || !_0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.Contains(curveIndex2))
						{
							ICurve curve2 = _0023_003DzViGQVPM_003D[curveIndex2].Curve;
							Edge edge3;
							if (orientedEdge2.Sense)
							{
								edge3 = _0023_003DziOhtUfKDpQ_zDVq0BA_003D_003D(_0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, curveIndex2, num4, _0023_003DzViGQVPM_003D[curveIndex2].EndPointIndex);
								if (edge3 == null)
								{
									Point3D startPoint2 = curve2.StartPoint;
									Point3D _0023_003DzWWeP8DUK_0024yA = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num4];
									double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D3 = curve2.Length() * 1E-05;
									num6 = _0023_003DzkUMRMNfp3zKwu43sCQ_003D_003D(_0023_003DzUbkxYVFDH3ry[_0023_003Dzfe2zeQMumw_4].Parametric[0], _0023_003DzViGQVPM_003D, _0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D3, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003DzWWeP8DUK_0024yA, startPoint2, num4, _0023_003DzViGQVPM_003D[curveIndex2].StartPointIndex);
								}
							}
							else
							{
								edge3 = _0023_003DziOhtUfKDpQ_zDVq0BA_003D_003D(_0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, curveIndex2, _0023_003DzViGQVPM_003D[curveIndex2].StartPointIndex, num4);
								if (edge3 == null)
								{
									Point3D endPoint2 = curve2.EndPoint;
									Point3D _0023_003DzWWeP8DUK_0024yA2 = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num4];
									double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D4 = curve2.Length() * 1E-05;
									num6 = _0023_003DzkUMRMNfp3zKwu43sCQ_003D_003D(_0023_003DzUbkxYVFDH3ry[_0023_003Dzfe2zeQMumw_4].Parametric[0], _0023_003DzViGQVPM_003D, _0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D4, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003DzWWeP8DUK_0024yA2, endPoint2, num4, _0023_003DzViGQVPM_003D[curveIndex2].EndPointIndex);
								}
							}
							if (edge3 != null)
							{
								_0023_003DzViGQVPM_003D[curveIndex2] = edge3;
								int[] array2 = ((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num4]).Parents;
								if (!array2.Contains(curveIndex2))
								{
									Array.Resize(ref array2, array2.Length + 1);
									array2[^1] = curveIndex2;
									((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num4]).Parents = array2;
								}
							}
							else
							{
								_0023_003DzViGQVPM_003D[num6].Parents = new int[2];
								_0023_003DzViGQVPM_003D[num6].Parents[0] = _0023_003Dzfe2zeQMumw_4;
								int[] parents = ((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzViGQVPM_003D[num6].EndPointIndex]).Parents;
								foreach (int num8 in parents)
								{
									if (num8 == _0023_003DzqhsKlJc_003D || num8 == _0023_003DzAJYZcKw_003D)
									{
										continue;
									}
									for (int m = 0; m < _0023_003DzViGQVPM_003D[num8].Parents.Length; m++)
									{
										_0023_003DzpITx87t3SC_0024wDJ_0024GkoKQQos_003D CS_0024_003C_003E8__locals4 = new _0023_003DzpITx87t3SC_0024wDJ_0024GkoKQQos_003D();
										int item2 = _0023_003DzViGQVPM_003D[num8].Parents[m];
										CS_0024_003C_003E8__locals4._0023_003DzDVfrOi0_003D = new Tuple<int, int>(item2, num6);
										if (!_0023_003DzIrfEWrXUlD53.Exists((Tuple<int, int> _0023_003DzNDQ_E88_003D) => _0023_003DzNDQ_E88_003D.Item1 == CS_0024_003C_003E8__locals4._0023_003DzDVfrOi0_003D.Item1 && _0023_003DzNDQ_E88_003D.Item2 == CS_0024_003C_003E8__locals4._0023_003DzDVfrOi0_003D.Item2))
										{
											_0023_003DzIrfEWrXUlD53.Add(CS_0024_003C_003E8__locals4._0023_003DzDVfrOi0_003D);
										}
									}
								}
							}
						}
						OrientedEdge orientedEdge3 = new OrientedEdge(_0023_003DzqhsKlJc_003D, !sense);
						segments[j] = orientedEdge3;
						if (_0023_003DzViGQVPM_003D[curveIndex].Curve.Length() < Utility._0023_003DzheSR8QM7q9ya)
						{
							((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzViGQVPM_003D[curveIndex].StartPointIndex])?._0023_003DznS097uo_003D(curveIndex);
							((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzViGQVPM_003D[curveIndex].EndPointIndex])?._0023_003DznS097uo_003D(curveIndex);
							int[] parents = _0023_003DzViGQVPM_003D[curveIndex].Parents;
							foreach (int index in parents)
							{
								_0023_003DzUbkxYVFDH3ry[index]._0023_003Dz6Tva2mtI46vE(curveIndex);
							}
							_0023_003DzViGQVPM_003D[curveIndex].Parents = null;
							_0023_003DzViGQVPM_003D[curveIndex] = null;
							if (!_0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D.Contains(curveIndex))
							{
								_0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D.Add(curveIndex);
							}
						}
						if (_0023_003DzViGQVPM_003D[curveIndex2].Curve.Length() < Utility._0023_003DzheSR8QM7q9ya)
						{
							((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzViGQVPM_003D[curveIndex2].StartPointIndex])?._0023_003DznS097uo_003D(curveIndex);
							((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[_0023_003DzViGQVPM_003D[curveIndex2].EndPointIndex])?._0023_003DznS097uo_003D(curveIndex);
							int[] parents = _0023_003DzViGQVPM_003D[curveIndex2].Parents;
							foreach (int index2 in parents)
							{
								_0023_003DzUbkxYVFDH3ry[index2]._0023_003Dz6Tva2mtI46vE(curveIndex2);
							}
							_0023_003DzViGQVPM_003D[curveIndex2].Parents = null;
							_0023_003DzViGQVPM_003D[curveIndex2] = null;
							if (!_0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D.Contains(curveIndex2))
							{
								_0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D.Add(curveIndex2);
							}
						}
						if (num5 != -1 || num6 != -1)
						{
							_0023_003DzUbkxYVFDH3ry[_0023_003Dzfe2zeQMumw_4].needRebuild = true;
						}
						return true;
					}
					if (_0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D == null || !_0023_003DzU7bXbu2_WOA7s3rPdw_003D_003D.Contains(curveIndex))
					{
						if (orientedEdge2.Sense)
						{
							_0023_003DzViGQVPM_003D[curveIndex] = _0023_003DziOhtUfKDpQ_zDVq0BA_003D_003D(_0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, curveIndex, num4, num3);
						}
						else
						{
							_0023_003DzViGQVPM_003D[curveIndex] = _0023_003DziOhtUfKDpQ_zDVq0BA_003D_003D(_0023_003DzViGQVPM_003D, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, curveIndex, num3, num4);
						}
					}
				}
				segments[j] = new OrientedEdge(_0023_003DzqhsKlJc_003D, !sense);
				return true;
			}
		}
		return false;
	}

	private static int _0023_003DzkUMRMNfp3zKwu43sCQ_003D_003D(Surface _0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D, List<Edge> _0023_003DzViGQVPM_003D, List<int> _0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D, double _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, Point3D _0023_003DzWWeP8DUK_0024yA4, Point3D _0023_003DzxIcuzwZ7lStX, int _0023_003Dz0mpLUaQHQBW0, int _0023_003DzTwQpWzBy3CGU)
	{
		_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.PointInversion(_0023_003DzWWeP8DUK_0024yA4, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out var proj);
		_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.PointInversion(_0023_003DzxIcuzwZ7lStX, _0023_003Dz0RRZ4GYHVsiJCDJvVw_003D_003D, out var proj2);
		TrimCurve trimCurve = new Line(proj.X, proj.Y, proj2.X, proj2.Y).GetNurbsForm().GetTrimCurve();
		return _0023_003DzbIDY9BOTPqfc(new Edge(_0023_003DzKW0_0024chKQ4k20kHVn_A_003D_003D.LiftCurve(trimCurve, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D / 10.0), _0023_003Dz0mpLUaQHQBW0, _0023_003DzTwQpWzBy3CGU), _0023_003DzViGQVPM_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, null, _0023_003Dz92ZE_382_0024kSvXnJVhw_003D_003D);
	}

	private static Edge _0023_003DziOhtUfKDpQ_zDVq0BA_003D_003D(List<Edge> _0023_003DzU3hosSAzkxO7, List<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003DzJQBg9NkOw_uE, int _0023_003DzbTvQNDE_003D, int _0023_003Dz5ruqoXs_003D)
	{
		Edge edge = _0023_003DzU3hosSAzkxO7[_0023_003DzJQBg9NkOw_uE];
		Point3D point3D = (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzbTvQNDE_003D].Clone();
		Point3D point3D2 = (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz5ruqoXs_003D].Clone();
		if (edge.Visited)
		{
			return edge;
		}
		Edge edge2 = (Edge)edge.Clone();
		if (edge2.Curve is Arc)
		{
			Utility._0023_003Dz6kYhc4pAp6ud((Arc)edge2.Curve);
		}
		else if (edge2.Curve is EllipticalArc)
		{
			Utility._0023_003Dz6kYhc4pAp6ud((EllipticalArc)edge2.Curve);
		}
		edge2.Curve.Project(point3D2, out var t);
		edge2.Curve.Project(point3D, out var t2);
		if (edge2.Curve is Circle || edge2.Curve is Ellipse)
		{
			t = ((t > edge2.Curve.Domain.High + Math.PI) ? (t - Math.PI * 2.0) : t);
			t2 = ((t2 > edge2.Curve.Domain.High + Math.PI) ? (t2 - Math.PI * 2.0) : t2);
		}
		bool flag = t < t2;
		double tol = edge2.Curve.Domain.Length * 1E-05;
		bool flag2 = edge2.Curve.Domain.Includes(t, tol);
		bool flag3 = edge2.Curve.Domain.Includes(t2, tol);
		if (Point3D.DistanceSquared(edge2.Curve.PointAt(t), point3D2) > 1E-05 || Point3D.DistanceSquared(edge2.Curve.PointAt(t2), point3D) > 1E-05)
		{
			return null;
		}
		if (flag)
		{
			Point3D point3D3 = point3D2;
			point3D2 = point3D;
			point3D = point3D3;
			double num = t;
			t = t2;
			t2 = num;
		}
		ICurve sub;
		if (!(flag3 && flag2))
		{
			sub = ((!(edge2.Curve is Curve)) ? Utility._0023_003Dzp4XhdBsfCih7(edge2.Curve, point3D, point3D2) : _0023_003DzK_0024_00244Vwc_0024Mvgd(edge2, point3D, point3D2, flag3, flag2, ref t2, ref t));
		}
		else
		{
			double t3 = edge2.Curve.Domain.t0;
			double t4 = edge2.Curve.Domain.t1;
			double num2 = 1E-05;
			double num3 = t2;
			if (t3 - num2 <= num3 && num3 <= t3 + num2)
			{
				t2 = edge2.Curve.Domain.t0;
			}
			num3 = t;
			if (t4 - num2 <= num3 && num3 <= t4 + num2)
			{
				t = edge2.Curve.Domain.t1;
			}
			edge2.Curve.SubCurve(t2, t, out sub);
		}
		if (sub == null)
		{
			if (Math.Abs(t - t2) < Utility._0023_003DzheSR8QM7q9ya)
			{
				edge2.Curve = new Line(edge2.Curve.PointAt(t2), edge2.Curve.PointAt(t));
				return edge2;
			}
			return edge;
		}
		edge2.Curve = sub;
		if (edge2.EndPointIndex != _0023_003Dz5ruqoXs_003D)
		{
			if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[edge2.EndPointIndex] != null)
			{
				((Vertex)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[edge2.EndPointIndex])._0023_003DznS097uo_003D(_0023_003DzJQBg9NkOw_uE);
				if (((Vertex)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[edge2.EndPointIndex]).Parents.Length == 0)
				{
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[edge2.EndPointIndex] = null;
				}
			}
			int[] array = ((Vertex)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz5ruqoXs_003D]).Parents;
			if (!array.Contains(_0023_003DzJQBg9NkOw_uE))
			{
				Array.Resize(ref array, array.Length + 1);
				array[^1] = _0023_003DzJQBg9NkOw_uE;
				((Vertex)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003Dz5ruqoXs_003D]).Parents = array;
			}
			edge2.EndPointIndex = _0023_003Dz5ruqoXs_003D;
		}
		if (edge2.StartPointIndex != _0023_003DzbTvQNDE_003D)
		{
			if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[edge2.StartPointIndex] != null)
			{
				((Vertex)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[edge2.StartPointIndex])._0023_003DznS097uo_003D(_0023_003DzJQBg9NkOw_uE);
				if (((Vertex)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[edge2.StartPointIndex]).Parents.Length == 0)
				{
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[edge2.StartPointIndex] = null;
				}
			}
			int[] array2 = ((Vertex)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzbTvQNDE_003D]).Parents;
			if (!array2.Contains(_0023_003DzJQBg9NkOw_uE))
			{
				Array.Resize(ref array2, array2.Length + 1);
				array2[^1] = _0023_003DzJQBg9NkOw_uE;
				((Vertex)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzbTvQNDE_003D]).Parents = array2;
			}
			edge2.StartPointIndex = _0023_003DzbTvQNDE_003D;
		}
		edge2.Visited = true;
		edge2.Curve.EdgeIndex = edge.Curve.EdgeIndex;
		return edge2;
	}

	private static ICurve _0023_003DzK_0024_00244Vwc_0024Mvgd(Edge _0023_003Dzz2TE_9QNdBis, Point3D _0023_003Dzrt6_0024RNc_003D, Point3D _0023_003DzBdJe9tA_003D, bool _0023_003DzeQZ0Emk_003D, bool _0023_003Dze9Z2sl4_003D, ref double _0023_003DzW0Z33Kp7qhM6, ref double _0023_003DzN_p_T4_0024rNGLU)
	{
		double t = _0023_003Dzz2TE_9QNdBis.Curve.Domain.t0;
		double t2 = _0023_003Dzz2TE_9QNdBis.Curve.Domain.t1;
		double num = 1E-05;
		double num2 = _0023_003DzW0Z33Kp7qhM6;
		if (t - num <= num2 && num2 <= t + num)
		{
			_0023_003DzW0Z33Kp7qhM6 = _0023_003Dzz2TE_9QNdBis.Curve.Domain.t0;
		}
		num2 = _0023_003DzN_p_T4_0024rNGLU;
		if (t2 - num <= num2 && num2 <= t2 + num)
		{
			_0023_003DzN_p_T4_0024rNGLU = _0023_003Dzz2TE_9QNdBis.Curve.Domain.t1;
		}
		ICurve sub;
		if (_0023_003DzeQZ0Emk_003D)
		{
			_0023_003Dzz2TE_9QNdBis.Curve.SubCurve(_0023_003DzW0Z33Kp7qhM6, _0023_003DzN_p_T4_0024rNGLU, out sub);
			if (sub != null)
			{
				((Curve)sub).ExtendBy(_0023_003DzBdJe9tA_003D);
			}
			else
			{
				sub = _0023_003Dzz2TE_9QNdBis.Curve.Clone() as Curve;
				((Curve)sub).ExtendBy(_0023_003DzBdJe9tA_003D);
			}
		}
		else if (_0023_003Dze9Z2sl4_003D)
		{
			_0023_003Dzz2TE_9QNdBis.Curve.SubCurve(_0023_003DzW0Z33Kp7qhM6, _0023_003DzN_p_T4_0024rNGLU, out sub);
			if (sub != null)
			{
				((Curve)sub).ExtendBy(_0023_003Dzrt6_0024RNc_003D, curveEnd: false);
			}
			else
			{
				sub = _0023_003Dzz2TE_9QNdBis.Curve.Clone() as Curve;
				((Curve)sub).ExtendBy(_0023_003Dzrt6_0024RNc_003D, curveEnd: false);
			}
		}
		else
		{
			sub = _0023_003Dzz2TE_9QNdBis.Curve.Clone() as Curve;
			((Curve)sub).ExtendBy(_0023_003DzBdJe9tA_003D);
			((Curve)sub).ExtendBy(_0023_003Dzrt6_0024RNc_003D, curveEnd: false);
		}
		return sub;
	}

	private int _0023_003DzJSH_hr4DJ0qh6mo3EHwcQyo_003D(int _0023_003DzL8NvYU0_003D, Face _0023_003DzHEpjcdg2hk9U)
	{
		int result = -1;
		for (int i = 0; i < _0023_003DzHEpjcdg2hk9U.Parametric.Length; i++)
		{
			if (Surface._0023_003DzsDi_rTtQwDS4(_0023_003DzL8NvYU0_003D, _0023_003DzHEpjcdg2hk9U.Parametric[i], 0, out var _))
			{
				result = i;
				break;
			}
		}
		return result;
	}

	private bool _0023_003Dz_0024WTkU9JSY152(Edge _0023_003DzTx2aqr8_003D, double _0023_003Dzm0CYiiE_003D, out bool _0023_003Dz3jDpzyJtb3_0024Nm8rt_0024Q_003D_003D)
	{
		_0023_003Dz3jDpzyJtb3_0024Nm8rt_0024Q_003D_003D = false;
		Face[] obj = ((_0023_003DzTx2aqr8_003D.ShellIndex == 0) ? Faces : Inners[_0023_003DzTx2aqr8_003D.ShellIndex - 1]);
		Point3D point3D = _0023_003DzTx2aqr8_003D.Curve.PointAt(_0023_003DzTx2aqr8_003D.Curve.Domain.Mid);
		Surface surface = obj[_0023_003DzTx2aqr8_003D.Parents[0]].Parametric[0];
		surface.Project(point3D, _0023_003Dzm0CYiiE_003D, out var proj);
		Surface surface2 = obj[_0023_003DzTx2aqr8_003D.Parents[1]].Parametric[0];
		surface2.Project(point3D, _0023_003Dzm0CYiiE_003D, out var proj2);
		Vector3D a = surface.NormalAt(proj);
		Vector3D b = surface2.NormalAt(proj2);
		_0023_003DzTx2aqr8_003D.Curve.Project(point3D, out var t);
		Vector3D vector3D = _0023_003DzTx2aqr8_003D.Curve.TangentAt(t);
		Vector3D vector3D2 = Vector3D.Cross(a, b);
		if (vector3D2.IsZero)
		{
			return false;
		}
		vector3D.Normalize();
		vector3D2.Normalize();
		_0023_003Dz3jDpzyJtb3_0024Nm8rt_0024Q_003D_003D = Vector3D.AreOpposite(vector3D, vector3D2);
		return true;
	}

	private bool _0023_003DzzHJb0M9USFYG(int _0023_003DzL8NvYU0_003D, Face _0023_003Dzn6eRxNucSNoK, Face _0023_003DzcQpPRG5mmRCF, int _0023_003Dz6Wgpeb47lwUusKlgI1a5UvI_003D, int _0023_003DzvVnkZlO_0024HXlmKIIwueA3BSw_003D, out bool _0023_003Dzbu8BV15Qqzan)
	{
		Edge edge = Edges[_0023_003DzL8NvYU0_003D];
		edge.Curve.PointAt(edge.Curve.Domain.Mid);
		if (!_0023_003Dz0TLJ1Bn6pEG9PyooGCoeO66qgW2RG3HTKg_003D_003D(_0023_003Dzn6eRxNucSNoK, _0023_003Dz6Wgpeb47lwUusKlgI1a5UvI_003D, _0023_003DzL8NvYU0_003D, out var _0023_003DzlllF2to_003D, out var _))
		{
			throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963042), _0023_003DzL8NvYU0_003D.ToString()));
		}
		if (!_0023_003Dz0TLJ1Bn6pEG9PyooGCoeO66qgW2RG3HTKg_003D_003D(_0023_003DzcQpPRG5mmRCF, _0023_003DzvVnkZlO_0024HXlmKIIwueA3BSw_003D, _0023_003DzL8NvYU0_003D, out var _, out var _0023_003Dzn8G7AOUeiIgL2))
		{
			throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963005), _0023_003DzL8NvYU0_003D.ToString()));
		}
		if (_0023_003DzsRM4g3CpTMdxqtKwfw_003D_003D(_0023_003DzlllF2to_003D, _0023_003Dzn8G7AOUeiIgL2))
		{
			_0023_003Dzbu8BV15Qqzan = true;
		}
		else
		{
			_0023_003Dzbu8BV15Qqzan = false;
		}
		return true;
	}

	private bool _0023_003Dz0TLJ1Bn6pEG9PyooGCoeO66qgW2RG3HTKg_003D_003D(Face _0023_003DzHEpjcdg2hk9U, int _0023_003DzZ7XN7rW3WKmBgwGMwgL40E0_003D, int _0023_003DzL8NvYU0_003D, out Vector3D _0023_003DzlllF2to_003D, out Vector3D _0023_003Dzn8G7AOUeiIgL)
	{
		if (!_0023_003Dz3k3r8c5eCjU6(_0023_003DzHEpjcdg2hk9U, _0023_003DzL8NvYU0_003D, out var _0023_003DzSwfghCo_003D, out var _0023_003DzdEvMFOw_003D))
		{
			_0023_003DzlllF2to_003D = null;
			_0023_003Dzn8G7AOUeiIgL = null;
			return false;
		}
		ICurve curve = Edges[_0023_003DzL8NvYU0_003D].Curve;
		_0023_003Dzn8G7AOUeiIgL = null;
		_0023_003DzlllF2to_003D = null;
		Point3D p = curve.PointAt(curve.Domain.Mid);
		Surface surface = _0023_003DzHEpjcdg2hk9U.Parametric[_0023_003DzZ7XN7rW3WKmBgwGMwgL40E0_003D];
		surface.Project(p, out var proj);
		_0023_003Dzn8G7AOUeiIgL = surface.NormalAt(proj);
		_0023_003DzlllF2to_003D = Vector3D.Cross(_0023_003Dzn8G7AOUeiIgL, curve.TangentAt(curve.Domain.Mid) * ((!(_0023_003DzdEvMFOw_003D.Sense ^ _0023_003DzSwfghCo_003D.Sense)) ? 1 : (-1)));
		_0023_003DzlllF2to_003D.Normalize();
		return (_0023_003DzlllF2to_003D != null) & (_0023_003Dzn8G7AOUeiIgL != null);
	}

	private bool _0023_003Dz3k3r8c5eCjU6(Face _0023_003DzhidJeNw_003D, int _0023_003DzL8NvYU0_003D, out OrientedEdge _0023_003DzSwfghCo_003D, out Loop _0023_003DzdEvMFOw_003D)
	{
		Loop[] loops = _0023_003DzhidJeNw_003D.Loops;
		foreach (Loop loop in loops)
		{
			OrientedEdge[] segments = loop.Segments;
			for (int j = 0; j < segments.Length; j++)
			{
				OrientedEdge orientedEdge = segments[j];
				if (orientedEdge.CurveIndex == _0023_003DzL8NvYU0_003D)
				{
					_0023_003DzSwfghCo_003D = orientedEdge;
					_0023_003DzdEvMFOw_003D = loop;
					return true;
				}
			}
		}
		_0023_003DzSwfghCo_003D = default(OrientedEdge);
		_0023_003DzdEvMFOw_003D = null;
		return false;
	}

	private static bool _0023_003DzsRM4g3CpTMdxqtKwfw_003D_003D(Vector3D _0023_003DzJQRMHqZ1AZoA, Vector3D _0023_003DzLM7TJxRoHNlx)
	{
		return Vector3D.Dot(_0023_003DzJQRMHqZ1AZoA, _0023_003DzLM7TJxRoHNlx) < 0.0;
	}

	private void _0023_003DzoDiveDddlQSo(Edge _0023_003DzTx2aqr8_003D, bool _0023_003Dz98St4PSCKWvi, List<Point3D> _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D, List<Edge> _0023_003DzViGQVPM_003D, List<Face> _0023_003DzUbkxYVFDH3ry, double _0023_003DzvGrBkpR3QpZd, ICurve[] _0023_003Dz6FZenRE4wAquLkr_5g_003D_003D, bool _0023_003Dzbu8BV15Qqzan)
	{
		int num = (_0023_003Dz98St4PSCKWvi ? _0023_003DzTx2aqr8_003D.StartPointIndex : _0023_003DzTx2aqr8_003D.EndPointIndex);
		Vertex vertex = (Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[num];
		if ((object)vertex == null)
		{
			return;
		}
		int[] parents = vertex.Parents;
		if (parents.Length != 4)
		{
			return;
		}
		ICurve[] array = _0023_003Dz6FZenRE4wAquLkr_5g_003D_003D.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzYVfRUioFnVlDuqo4m5CeihGaABWp).ToArray();
		CompositeCurve compositeCurve = new CompositeCurve(array);
		List<Tuple<Edge, Point3D>> list = new List<Tuple<Edge, Point3D>>();
		int num2 = -1;
		int[] array2 = parents;
		foreach (int num3 in array2)
		{
			Edge edge = _0023_003DzViGQVPM_003D[num3];
			if (edge != null)
			{
				Point3D[] array3 = compositeCurve.IntersectWith(edge.Curve, _0023_003DzvGrBkpR3QpZd);
				if (array3.Length == 1)
				{
					list.Add(new Tuple<Edge, Point3D>(edge, array3[0]));
				}
				else if (array3.Length == 0)
				{
					num2 = num3;
				}
			}
		}
		if (list.Count != 2 || num2 == -1)
		{
			return;
		}
		Edge edge2 = _0023_003DzViGQVPM_003D[num2];
		int num4 = -1;
		bool flag = false;
		for (int j = 0; j < array.Length; j++)
		{
			if (Point3D.DistanceSquared(list[0].Item2, array[j].StartPoint) < _0023_003DzvGrBkpR3QpZd && Point3D.DistanceSquared(list[1].Item2, array[j].EndPoint) < _0023_003DzvGrBkpR3QpZd)
			{
				num4 = j;
				break;
			}
			if (Point3D.DistanceSquared(list[0].Item2, array[j].EndPoint) < _0023_003DzvGrBkpR3QpZd && Point3D.DistanceSquared(list[1].Item2, array[j].StartPoint) < _0023_003DzvGrBkpR3QpZd)
			{
				num4 = j;
				flag = true;
				break;
			}
		}
		if (num4 == -1)
		{
			return;
		}
		List<OrientedEdge> list2 = new List<OrientedEdge>();
		foreach (Tuple<Edge, Point3D> item6 in list)
		{
			Edge item = item6.Item1;
			Point3D item2 = item6.Item2;
			_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Add(new Vertex(item6.Item2.X, item6.Item2.Y, item6.Item2.Z));
			ICurve sub2;
			if (Point3D.DistanceSquared(item6.Item1.Curve.EndPoint, vertex) < _0023_003DzvGrBkpR3QpZd)
			{
				if (item.Curve.SubCurve(item.Curve.Domain.Low, ((InterPoint)item2).s, out var sub))
				{
					item.Curve = sub;
					item.EndPointIndex = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count - 1;
				}
			}
			else if (item.Curve.SubCurve(((InterPoint)item2).s, item.Curve.Domain.High, out sub2))
			{
				item.Curve = sub2;
				item.StartPointIndex = _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count - 1;
			}
			Edge item3 = ((edge2.StartPointIndex == num) ? new Edge(new Line(item6.Item2, (Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[edge2.EndPointIndex].Clone()), _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count - 1, edge2.EndPointIndex) : new Edge(new Line((Vertex)_0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[edge2.StartPointIndex].Clone(), item6.Item2), edge2.StartPointIndex, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count - 1));
			_0023_003DzViGQVPM_003D.Add(item3);
			Face face = _0023_003DzUbkxYVFDH3ry[item6.Item1.Parents[0]];
			if (_0023_003DzTx2aqr8_003D.Parents.Contains(item6.Item1.Parents[0]))
			{
				face = _0023_003DzUbkxYVFDH3ry[item6.Item1.Parents[1]];
				face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(null);
			}
			Loop[] loops = face.Loops;
			foreach (Loop loop in loops)
			{
				for (int k = 0; k < loop.Segments.Length; k++)
				{
					OrientedEdge orientedEdge = loop.Segments[k];
					if (orientedEdge.CurveIndex == num2)
					{
						loop.Segments[k] = new OrientedEdge(_0023_003DzViGQVPM_003D.Count - 1, orientedEdge.Sense);
						list2.Add(new OrientedEdge(_0023_003DzViGQVPM_003D.Count - 1, !orientedEdge.Sense));
					}
				}
			}
		}
		if (flag)
		{
			list2.Reverse();
		}
		Edge item4 = (flag ? new Edge((ICurve)array[num4].Clone(), _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count - 1, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count - 2) : new Edge((ICurve)array[num4].Clone(), _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count - 2, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D.Count - 1));
		_0023_003DzViGQVPM_003D.Add(item4);
		list2.Add(new OrientedEdge(_0023_003DzViGQVPM_003D.Count - 1, sense: false));
		_0023_003Dz6FZenRE4wAquLkr_5g_003D_003D[num4].EdgeIndex = _0023_003DzViGQVPM_003D.Count - 1;
		Plane _0023_003Dzrgqz890sj_0024X = null;
		if (_0023_003DzViGQVPM_003D[num2].StartPointIndex == num)
		{
			Utility._0023_003DzNY5YUv279_SW(list[0].Item2, list[1].Item2, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[edge2.EndPointIndex], out _0023_003Dzrgqz890sj_0024X);
			bool flag2 = _0023_003DzsRM4g3CpTMdxqtKwfw_003D_003D(_0023_003Dzrgqz890sj_0024X.AxisZ, -1.0 * edge2.Curve.StartTangent);
			if (!_0023_003Dzbu8BV15Qqzan ^ flag2)
			{
				_0023_003Dzrgqz890sj_0024X.Flip();
			}
		}
		else
		{
			Utility._0023_003DzNY5YUv279_SW(list[0].Item2, list[1].Item2, _0023_003Dz8lScEFK7iEv_0024NrOSDg_003D_003D[edge2.StartPointIndex], out _0023_003Dzrgqz890sj_0024X);
			bool flag3 = _0023_003DzsRM4g3CpTMdxqtKwfw_003D_003D(_0023_003Dzrgqz890sj_0024X.AxisZ, edge2.Curve.EndTangent);
			if (!_0023_003Dzbu8BV15Qqzan ^ flag3)
			{
				_0023_003Dzrgqz890sj_0024X.Flip();
			}
		}
		Face item5 = new Face(new PlanarSurf(_0023_003Dzrgqz890sj_0024X), new Loop(list2.ToArray()));
		_0023_003DzUbkxYVFDH3ry.Add(item5);
	}

	public bool ExtrudeRemove(SketchEntity sketch, double amount)
	{
		if (ExtrudeRemove(sketch.Sketch, amount))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemove(SketchEntity sketch, Interval amount)
	{
		if (ExtrudeRemove(sketch.Sketch, amount))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemove(SketchEntity sketch, double amount, double angleInRadians)
	{
		if (ExtrudeRemove(sketch.Sketch, amount, angleInRadians))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemoveThrough(SketchEntity sketch)
	{
		if (ExtrudeRemoveThrough(sketch.Sketch))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemoveThrough(SketchEntity sketch, double angleInRadians)
	{
		if (ExtrudeRemoveThrough(sketch.Sketch, angleInRadians))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeAddPattern(SketchEntity sketch, double amount, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(sketch, amount, 0.0, sketch.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(SketchEntity sketch, Interval amount, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(sketch, amount, 0.0, sketch.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(SketchEntity sketch, double amount, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(sketch, amount, 0.0, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(SketchEntity sketch, Interval amount, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(sketch, amount, 0.0, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(SketchEntity sketch, double amount, double draftAngleInRadians, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(sketch, amount, draftAngleInRadians, sketch.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(SketchEntity sketch, Interval amount, double draftAngleInRadians, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(sketch, amount, draftAngleInRadians, sketch.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(SketchEntity sketch, double amount, double draftAngleInRadians, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeAddPattern(sketch, (amount > 0.0) ? new Interval(0.0, amount) : new Interval(amount, 0.0), draftAngleInRadians, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeAddPattern(SketchEntity sketch, Interval amount, double draftAngleInRadians, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		if (ExtrudeAddPattern(sketch.Sketch, amount, draftAngleInRadians, patternPln, spacingX, numberX, spacingY, numberY))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeAddPattern(SketchEntity sketch, double amount, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(sketch, amount, 0.0, sketch.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(SketchEntity sketch, Interval amount, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(sketch, amount, 0.0, sketch.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(SketchEntity sketch, double amount, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(sketch, amount, 0.0, axis, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(SketchEntity sketch, Interval amount, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(sketch, amount, 0.0, axis, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(SketchEntity sketch, double amount, double draftAngleInRadians, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(sketch, amount, draftAngleInRadians, sketch.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(SketchEntity sketch, Interval amount, double draftAngleInRadians, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(sketch, amount, draftAngleInRadians, sketch.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(SketchEntity sketch, double amount, double draftAngleInRadians, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeAddPattern(sketch, (amount > 0.0) ? new Interval(0.0, amount) : new Interval(amount, 0.0), draftAngleInRadians, axis, center, angleInRadians, number);
	}

	public bool ExtrudeAddPattern(SketchEntity sketch, Interval amount, double draftAngleInRadians, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		if (ExtrudeAddPattern(sketch.Sketch, amount, draftAngleInRadians, axis, center, angleInRadians, number))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemovePattern(SketchEntity sketch, double amount, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(sketch, amount, 0.0, sketch.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(SketchEntity sketch, Interval amount, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(sketch, amount, 0.0, sketch.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(SketchEntity sketch, double amount, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(sketch, amount, 0.0, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(SketchEntity sketch, Interval amount, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(sketch, amount, 0.0, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(SketchEntity sketch, double amount, double angleInRadians, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(sketch, amount, angleInRadians, sketch.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(SketchEntity sketch, Interval amount, double angleInRadians, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(sketch, amount, angleInRadians, sketch.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(SketchEntity sketch, double amount, double angleInRadians, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemovePattern(sketch, (amount > 0.0) ? new Interval(0.0, amount) : new Interval(amount, 0.0), angleInRadians, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemovePattern(SketchEntity sketch, Interval amount, double angleInRadians, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		if (ExtrudeRemovePattern(sketch.Sketch, amount, angleInRadians, patternPln, spacingX, numberX, spacingY, numberY))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemovePattern(SketchEntity sketch, double amount, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(sketch, amount, 0.0, sketch.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(SketchEntity sketch, Interval amount, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(sketch, amount, 0.0, sketch.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(SketchEntity sketch, double amount, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(sketch, amount, 0.0, axis, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(SketchEntity sketch, Interval amount, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(sketch, amount, 0.0, axis, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(SketchEntity sketch, double amount, double draftAngleInRadians, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(sketch, amount, draftAngleInRadians, sketch.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(SketchEntity sketch, Interval amount, double draftAngleInRadians, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(sketch, amount, draftAngleInRadians, sketch.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(SketchEntity sketch, double amount, double draftAngleInRadians, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemovePattern(sketch, (amount > 0.0) ? new Interval(0.0, amount) : new Interval(amount, 0.0), draftAngleInRadians, axis, center, angleInRadians, number);
	}

	public bool ExtrudeRemovePattern(SketchEntity sketch, Interval amount, double draftAngleInRadians, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		if (ExtrudeRemovePattern(sketch.Sketch, amount, draftAngleInRadians, axis, center, angleInRadians, number))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemoveThroughPattern(SketchEntity sketch, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemoveThroughPattern(sketch, 0.0, sketch.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemoveThroughPattern(SketchEntity sketch, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemoveThroughPattern(sketch, 0.0, patternPln, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemoveThroughPattern(SketchEntity sketch, double angleInRadians, double spacingX, int numberX, double spacingY, int numberY)
	{
		return ExtrudeRemoveThroughPattern(sketch, angleInRadians, sketch.Plane, spacingX, numberX, spacingY, numberY);
	}

	public bool ExtrudeRemoveThroughPattern(SketchEntity sketch, double angleInRadians, Plane patternPln, double spacingX, int numberX, double spacingY, int numberY)
	{
		if (ExtrudeRemoveThroughPattern(sketch.Sketch, angleInRadians, patternPln, spacingX, numberX, spacingY, numberY))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeRemoveThroughPattern(SketchEntity sketch, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemoveThroughPattern(sketch, 0.0, sketch.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemoveThroughPattern(SketchEntity sketch, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemoveThroughPattern(sketch, 0.0, axis, center, angleInRadians, number);
	}

	public bool ExtrudeRemoveThroughPattern(SketchEntity sketch, double draftAngleInRadians, Point3D center, double angleInRadians, int number)
	{
		return ExtrudeRemoveThroughPattern(sketch, draftAngleInRadians, sketch.Plane.AxisZ, center, angleInRadians, number);
	}

	public bool ExtrudeRemoveThroughPattern(SketchEntity sketch, double draftAngleInRadians, Vector3D axis, Point3D center, double angleInRadians, int number)
	{
		if (ExtrudeRemoveThroughPattern(sketch.Sketch, draftAngleInRadians, axis, center, angleInRadians, number))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeAdd(SketchEntity sketch, double amount)
	{
		if (ExtrudeAdd(sketch.Sketch, amount))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeAdd(SketchEntity sketch, double amount, double angleInRadians)
	{
		if (ExtrudeAdd(sketch.Sketch, amount, angleInRadians))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeAdd(SketchEntity sketch, Interval amount)
	{
		if (ExtrudeAdd(sketch.Sketch, amount))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeIntersect(SketchEntity sketch, double amount)
	{
		if (ExtrudeIntersect(sketch.Sketch, amount))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeIntersect(SketchEntity sketch, double amount, double angleInRadians)
	{
		if (ExtrudeIntersect(sketch.Sketch, amount, angleInRadians))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool ExtrudeIntersect(SketchEntity sketch, Interval amount)
	{
		if (ExtrudeIntersect(sketch.Sketch, amount))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveRemove(SketchEntity sketch, double angle, Vector3D axis, Point3D center)
	{
		if (RevolveRemove(sketch.Sketch, angle, axis, center))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveRemove(SketchEntity sketch, double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		if (RevolveRemove(sketch.Sketch, startAngle, deltaAngle, axis, center))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveAdd(SketchEntity sketch, double angle, Vector3D axis, Point3D center)
	{
		if (RevolveAdd(sketch.Sketch, angle, axis, center))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveAdd(SketchEntity sketch, double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		if (RevolveAdd(sketch.Sketch, startAngle, deltaAngle, axis, center))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveIntersect(SketchEntity sketch, double angle, Vector3D axis, Point3D center)
	{
		if (RevolveIntersect(sketch.Sketch, angle, axis, center))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool RevolveIntersect(SketchEntity sketch, double startAngle, double deltaAngle, Vector3D axis, Point3D center)
	{
		if (RevolveIntersect(sketch.Sketch, startAngle, deltaAngle, axis, center))
		{
			RegenMode = regenType.RegenAndCompile;
			return true;
		}
		return false;
	}

	public bool SweepAdd(SketchEntity sketch, ICurve rail, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		return SweepAdd(sketch.Sketch, rail, methodType);
	}

	public bool SweepIntersect(SketchEntity sketch, ICurve rail, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		return SweepAdd(sketch.Sketch, rail, methodType);
	}

	public bool SweepRemove(SketchEntity sketch, ICurve rail, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames)
	{
		return SweepAdd(sketch.Sketch, rail, methodType);
	}

	public Edge[] GetSelectedEdges(Stack<BlockReference> parents = null)
	{
		SelectionInfoSubItems selectionInfoSubItems = SelectionInfoItemBase.FindInstance(parents, this, null, EdgesSelectionInfo);
		List<Edge> list = new List<Edge>();
		if (selectionInfoSubItems == null)
		{
			return null;
		}
		for (int i = 0; i < selectionInfoSubItems.SubItems.Length; i++)
		{
			if (selectionInfoSubItems.SubItems[i].Selected)
			{
				list.Add(Edges[i]);
			}
		}
		return list.ToArray();
	}

	public Face[] GetSelectedFaces(Stack<BlockReference> parents = null)
	{
		SelectionInfoSubItems selectionInfoSubItems = SelectionInfoItemBase.FindInstance(parents, this, null, FacesSelectionInfo);
		List<Face> list = new List<Face>();
		if (selectionInfoSubItems == null)
		{
			return null;
		}
		for (int i = 0; i < selectionInfoSubItems.SubItems.Length; i++)
		{
			if (selectionInfoSubItems.SubItems[i].Selected)
			{
				list.Add(Faces[i]);
			}
		}
		return list.ToArray();
	}

	public Point3D[] GetSelectedVertices(Stack<BlockReference> parents = null)
	{
		SelectionInfoSubItems selectionInfoSubItems = SelectionInfoItemBase.FindInstance(parents, this, null, VerticesSelectionInfo);
		List<Point3D> list = new List<Point3D>();
		if (selectionInfoSubItems == null)
		{
			return null;
		}
		for (int i = 0; i < selectionInfoSubItems.SubItems.Length; i++)
		{
			if (selectionInfoSubItems.SubItems[i].Selected)
			{
				list.Add(Vertices[i]);
			}
		}
		return list.ToArray();
	}

	public Face[] GetSelectedInnerFaces(Stack<BlockReference> parents = null)
	{
		SelectionInfoSubItemsArray selectionInfoSubItemsArray = SelectionInfoItemBase.FindInstance(parents, this, null, InnerFacesSelectionInfo);
		List<Face> list = new List<Face>();
		if (selectionInfoSubItemsArray == null)
		{
			return null;
		}
		for (int i = 0; i < selectionInfoSubItemsArray.SubItems.GetLength(0); i++)
		{
			for (int j = 0; j < selectionInfoSubItemsArray.SubItems[i].Length; j++)
			{
				if (selectionInfoSubItemsArray.SubItems[i][j].Selected)
				{
					list.Add(Inners[i][j]);
				}
			}
		}
		return list.ToArray();
	}

	protected internal override bool SelectedInternal()
	{
		return SelectionMode != selectionFilterType.Entity;
	}

	public bool IsAnyFaceSelected()
	{
		if (SelectionInfoSubItems.IsAnySelected(FacesSelectionInfo))
		{
			return true;
		}
		foreach (SelectionInfoSubItemsArray item in InnerFacesSelectionInfo)
		{
			SelectionInfo[][] subItems = item.SubItems;
			for (int i = 0; i < subItems.Length; i++)
			{
				if (SelectionInfoSubItems.IsAnySelected(subItems[i]))
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool IsAnyEdgeSelected()
	{
		return SelectionInfoSubItems.IsAnySelected(EdgesSelectionInfo);
	}

	public bool IsAnyVertexSelected()
	{
		return SelectionInfoSubItems.IsAnySelected(VerticesSelectionInfo);
	}

	internal override List<SelectionInfoSubItems> _0023_003Dz4NlMyrooY_aHAHG2Ag_003D_003D()
	{
		return FacesSelectionInfo;
	}

	internal override int _0023_003Dz5RPGbcVkdZb3()
	{
		return Faces.Length;
	}

	public bool GetFaceSelection(int faceIndex, Stack<BlockReference> parents = null)
	{
		return SelectionInfoItemBase._0023_003Dz4SMVPY0ZDXX8(this, Faces, FacesSelectionInfo, faceIndex, parents);
	}

	public bool GetFaceSelection(int shellIndex, int faceIndex, Stack<BlockReference> parents = null)
	{
		if (shellIndex == 0)
		{
			return GetFaceSelection(faceIndex, parents);
		}
		int num = shellIndex - 1;
		if (num < 0 || num >= Inners.GetLength(0))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963196));
		}
		List<SelectionInfoSubItemsArray> innerFacesSelectionInfo = InnerFacesSelectionInfo;
		object[][] inners = Inners;
		SelectionInfoSubItemsArray selectionInfoSubItemsArray = SelectionInfoItemBase.FindInstanceOrCreate(parents, this, null, innerFacesSelectionInfo, -1, inners);
		if (faceIndex >= selectionInfoSubItemsArray.SubItems[num].Length)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963159));
		}
		return selectionInfoSubItemsArray.SubItems[num][faceIndex].Selected;
	}

	public void SetFaceSelection(int faceIndex, bool status, Stack<BlockReference> parents = null)
	{
		SetFaceSelection(0, faceIndex, status, parents);
	}

	public void SetFaceSelection(int shellIndex, int faceIndex, bool status, Stack<BlockReference> parents = null)
	{
		if (shellIndex == 0)
		{
			SelectionInfoSubItems._0023_003DzTaF8sCpHm_00245q(selectionFilterType.Face, faceIndex, status, this, Faces, FacesSelectionInfo, parents);
			return;
		}
		object[][] inners = Inners;
		SelectionInfoSubItemsArray._0023_003DzTaF8sCpHm_00245q(selectionFilterType.Face, shellIndex, faceIndex, status, this, inners, InnerFacesSelectionInfo, parents);
	}

	public void ClearFacesSelection(Stack<BlockReference> parents = null)
	{
		int num = SelectedItemBase._0023_003DzAdoyA7k_003D(new SelectionInfoSubItems(parents, this), FacesSelectionInfo);
		if (num >= 0)
		{
			FacesSelectionInfo.RemoveAt(num);
			isDirtyForFlattenTree = true;
		}
		num = SelectedItemBase._0023_003DzAdoyA7k_003D(new SelectionInfoSubItemsArray(parents, this), InnerFacesSelectionInfo);
		if (num >= 0)
		{
			InnerFacesSelectionInfo.RemoveAt(num);
			isDirtyForFlattenTree = true;
		}
	}

	public void ClearFacesSelectionForAllInstances()
	{
		if (IsAnyFaceSelected())
		{
			isDirtyForFlattenTree = true;
		}
		FacesSelectionInfo.Clear();
		InnerFacesSelectionInfo.Clear();
	}

	internal override bool IsSelected(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, selectionStatusType _0023_003DzLEq8mIc_003D)
	{
		if (SelectionMode == selectionFilterType.Entity)
		{
			return base.IsSelected(_0023_003Dzq5nwX2I_003D, _0023_003DzLEq8mIc_003D);
		}
		bool flag = false;
		if ((SelectionMode & selectionFilterType.Face) != 0)
		{
			if (FacesSelectionInfo.Count > 0 && SelectionInfoItem._0023_003DzAdoyA7k_003D(_0023_003Dzq5nwX2I_003D, this, FacesSelectionInfo, out var _0023_003Dzv0Okb82R5LqH))
			{
				flag |= SelectionInfoSubItems.IsAnySelected(_0023_003Dzv0Okb82R5LqH.SubItems, _0023_003DzLEq8mIc_003D);
			}
			if (InnerFacesSelectionInfo.Count > 0 && SelectionInfoItem._0023_003DzAdoyA7k_003D(_0023_003Dzq5nwX2I_003D, this, InnerFacesSelectionInfo, out var _0023_003Dzv0Okb82R5LqH2))
			{
				flag |= SelectionInfoSubItemsArray._0023_003DzwRqUsQPmazuq(_0023_003Dzv0Okb82R5LqH2.SubItems, _0023_003DzLEq8mIc_003D);
			}
		}
		if ((SelectionMode & selectionFilterType.Edge) != 0 && SelectionInfoItem._0023_003DzAdoyA7k_003D(_0023_003Dzq5nwX2I_003D, this, EdgesSelectionInfo, out var _0023_003Dzv0Okb82R5LqH3))
		{
			flag |= SelectionInfoSubItems.IsAnySelected(_0023_003Dzv0Okb82R5LqH3.SubItems, _0023_003DzLEq8mIc_003D);
		}
		if ((SelectionMode & selectionFilterType.Vertex) != 0 && SelectionInfoItem._0023_003DzAdoyA7k_003D(_0023_003Dzq5nwX2I_003D, this, VerticesSelectionInfo, out var _0023_003Dzv0Okb82R5LqH4))
		{
			flag |= SelectionInfoSubItems.IsAnySelected(_0023_003Dzv0Okb82R5LqH4.SubItems, _0023_003DzLEq8mIc_003D);
		}
		return flag;
	}

	internal override void ClearSelectionFaces(selectionStatusType _0023_003DzCYtX6jC7ppkE)
	{
		SelectionInfoSubItems._0023_003DzpeLpar2z_0024ejG(_0023_003DzCYtX6jC7ppkE, this, FacesSelectionInfo);
		if (_0023_003DzCYtX6jC7ppkE == selectionStatusType.Temporary)
		{
			foreach (SelectionInfoSubItemsArray item in InnerFacesSelectionInfo)
			{
				SelectionInfo[][] subItems = item.SubItems;
				foreach (SelectionInfo[] array in subItems)
				{
					for (int j = 0; j < array.Length; j++)
					{
						array[j].UnsetFlag(_0023_003DzCYtX6jC7ppkE);
					}
				}
			}
			return;
		}
		if (IsAnyFaceSelected())
		{
			isDirtyForFlattenTree = true;
		}
		InnerFacesSelectionInfo.Clear();
		if (SelectionMode == selectionFilterType.Face)
		{
			SelectionMode = selectionFilterType.Entity;
		}
	}

	[Obsolete("Use SetFaceSelection()")]
	public void SelectFace(int faceIndex, bool selectionState, Stack<BlockReference> parents = null)
	{
		SelectFace(0, faceIndex, selectionState, parents);
	}

	[Obsolete("Use SetFaceSelection()")]
	public void SelectFace(int shellIndex, int faceIndex, bool selectionState, Stack<BlockReference> parents = null)
	{
		SetFaceSelection(shellIndex, faceIndex, selectionState, parents);
	}

	internal override List<SelectedSubItem> ClearSelectionFaces(Stack<BlockReference> _0023_003Dzq5nwX2I_003D, selectionStatusType _0023_003DzCYtX6jC7ppkE)
	{
		List<SelectedSubItem> list = new List<SelectedSubItem>();
		SelectionInfoSubItems selectionInfoSubItems = SelectionInfoItemBase.FindInstanceOrCreate(_0023_003Dzq5nwX2I_003D, this, null, FacesSelectionInfo, Faces.Length);
		int num = 0;
		list.AddRange(Entity.ClearChildrenItemsSelection<SelectedFace>(_0023_003DzCYtX6jC7ppkE, _0023_003Dzq5nwX2I_003D, this, selectionInfoSubItems.SubItems, num++));
		List<SelectionInfoSubItemsArray> innerFacesSelectionInfo = InnerFacesSelectionInfo;
		object[][] inners = Inners;
		SelectionInfoSubItemsArray selectionInfoSubItemsArray = SelectionInfoItemBase.FindInstanceOrCreate(_0023_003Dzq5nwX2I_003D, this, null, innerFacesSelectionInfo, -1, inners);
		if (selectionInfoSubItemsArray.SubItems != null)
		{
			for (int i = 0; i < Inners.Length; i++)
			{
				list.AddRange(Entity.ClearChildrenItemsSelection<SelectedFace>(_0023_003DzCYtX6jC7ppkE, _0023_003Dzq5nwX2I_003D, this, selectionInfoSubItemsArray.SubItems[i], num++));
			}
		}
		return list;
	}

	private void _0023_003DzEHXTGfYkuxsA()
	{
		if (_colorGroupsDrawData != null)
		{
			(EntityGraphicsData, Color?)[] colorGroupsDrawData = _colorGroupsDrawData;
			for (int i = 0; i < colorGroupsDrawData.Length; i++)
			{
				colorGroupsDrawData[i].Item1.Dispose();
			}
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		_0023_003DzEHXTGfYkuxsA();
		Edge[] edges = Edges;
		for (int i = 0; i < edges.Length; i++)
		{
			((Entity)(edges[i]?.Curve))?.Dispose();
		}
		_0023_003DzalvoMSOivEJef76qig_003D_003D(_faces);
		if (Inners != null)
		{
			Face[][] inners = Inners;
			for (int i = 0; i < inners.Length; i++)
			{
				_0023_003DzalvoMSOivEJef76qig_003D_003D(inners[i]);
			}
		}
		_drawWireData?.Dispose();
		drawData?.Dispose();
	}

	private static void _0023_003DzalvoMSOivEJef76qig_003D_003D(Face[] _0023_003DzpPOEJqcAh7Lr)
	{
		if (_0023_003DzpPOEJqcAh7Lr != null)
		{
			for (int i = 0; i < _0023_003DzpPOEJqcAh7Lr.Length; i++)
			{
				_0023_003DzpPOEJqcAh7Lr[i]?.Dispose();
			}
		}
	}

	public override string Dump(linearUnitsType linearUnits = linearUnitsType.Unitless, massUnitsType massUnits = massUnitsType.Unitless, LayerKeyedCollection layers = null, MaterialKeyedCollection materials = null, BlockKeyedCollection blocks = null)
	{
		StringBuilder stringBuilder = new StringBuilder(base.Dump(linearUnits, massUnits, layers, materials, blocks));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963124) + _edges.Length);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963115) + (_inners.Length + 1));
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963077) + _faces.Length);
		for (int i = 0; i < _inners.Length; i++)
		{
			Face[] array = _inners[i];
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962771) + (i + 1) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962741) + array.Length);
		}
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962751) + IsClosed);
		stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962735) + GetError());
		double _0023_003DzXWCF4rA_003D = double.NaN;
		Point3D centroid = null;
		double _0023_003DzhKcriekaIolc = double.NaN;
		Point3D centroid2 = null;
		double _0023_003DzZZ1x4JqOx = double.NaN;
		double convertedDensity = double.NaN;
		if (regenMode == regenType.RegenAndCompile)
		{
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962720));
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
		}
		else
		{
			_0023_003DzXWCF4rA_003D = GetArea(out centroid);
			_0023_003DzhKcriekaIolc = GetVolume(out centroid2);
			_0023_003DzZZ1x4JqOx = GetMass(GetMaterial(materials, layers), linearUnits, massUnits, out convertedDensity);
		}
		stringBuilder = _0023_003DzJ7t6sHqYVrbZ(stringBuilder, _0023_003DzXWCF4rA_003D, centroid, _0023_003DzhKcriekaIolc, centroid2, _0023_003DzZZ1x4JqOx, convertedDensity, linearUnits, massUnits, materials, layers);
		return stringBuilder.ToString();
	}

	public double GetArea(out Point3D centroid)
	{
		AreaProperties areaProperties = new AreaProperties();
		areaProperties.Add(_0023_003DzPeEa001D5Cs2());
		centroid = areaProperties.Centroid;
		return areaProperties.Area;
	}

	public double GetVolume(out Point3D centroid)
	{
		VolumeProperties volumeProperties = new VolumeProperties();
		volumeProperties.Add(_0023_003DzPeEa001D5Cs2());
		centroid = volumeProperties.Centroid;
		return volumeProperties.Volume;
	}

	public void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ, out double ix, out double iy, out double iz)
	{
		VolumeProperties volumeProperties = new VolumeProperties();
		volumeProperties.Add(_0023_003DzPeEa001D5Cs2());
		volumeProperties.GetPrincipalAxes(volumeProperties.Volume, volumeProperties.Centroid, out axisX, out axisY, out axisZ, out ix, out iy, out iz);
	}

	public void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ)
	{
		GetPrincipalAxes(out axisX, out axisY, out axisZ, out var _, out var _, out var _);
	}

	public double GetMass(Material material, linearUnitsType linearUnits, massUnitsType massUnits, out double convertedDensity)
	{
		Point3D centroid;
		return Utility._0023_003DzaWhFDDP5nQ_0024L(material, MaterialName, massUnits, linearUnits, GetVolume(out centroid), out convertedDensity);
	}

	private Mesh[] _0023_003DzPeEa001D5Cs2()
	{
		List<Mesh> list = new List<Mesh>(_faces.Length);
		list.AddRange(_0023_003DzleKHvj4gK0eE(_faces, Mesh.natureType.Plain));
		Face[][] inners = _inners;
		foreach (Face[] _0023_003DzEtn4dIEPKCsi in inners)
		{
			list.AddRange(_0023_003DzleKHvj4gK0eE(_0023_003DzEtn4dIEPKCsi, Mesh.natureType.Plain));
		}
		return list.ToArray();
	}

	internal override bool _0023_003Dz1owWudHkrMNo9ZKfxq18_OA_003D(TraversalParams _0023_003DzELu0Pss_003D, out Point2D[] _0023_003DzrdSL0CI_003D, out bool _0023_003DzlglYmGw_003D, out int _0023_003DzHhJEwwk_003D, bool _0023_003DzjZRgeJk_003D = false)
	{
		_0023_003DzHhJEwwk_003D = 1;
		Point2D[] array = new Point3D[0];
		_0023_003DzrdSL0CI_003D = array;
		_0023_003DzlglYmGw_003D = false;
		List<Point3D> list = new List<Point3D>(Vertices.Length);
		Face[] faces = _faces;
		foreach (Face face in faces)
		{
			if (face.Tessellation == null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962923));
			}
			list.AddRange(face.Tessellation.GetPoints());
		}
		Point3D[] array2 = list.ToArray();
		array = array2;
		_0023_003DzrdSL0CI_003D = array;
		if (_localOB != null && !_localOB._0023_003DziQOhVy0_003D && (RegenMode == regenType.NotNeeded || _0023_003DzjZRgeJk_003D))
		{
			return true;
		}
		if (list.Count > 0)
		{
			base.OrientedBounding = new OrientedBoundingBox(array2);
			_0023_003DzlglYmGw_003D = true;
			return true;
		}
		return false;
	}

	protected internal override bool GetAllVertices(TraversalParams data, out IList<float> verticesCoords)
	{
		List<float> list = new List<float>();
		_0023_003Dzpy8J_0024UAHRCbnEAQhI1L1bS0_003D(_faces, list);
		Face[][] inners = _inners;
		for (int i = 0; i < inners.Length; i++)
		{
			_0023_003Dzpy8J_0024UAHRCbnEAQhI1L1bS0_003D(inners[i], list);
		}
		verticesCoords = list;
		return true;
	}

	private static void _0023_003Dzpy8J_0024UAHRCbnEAQhI1L1bS0_003D(Face[] _0023_003DzpPOEJqcAh7Lr, List<float> _0023_003DzD0vYoclJjkWP)
	{
		foreach (Face face in _0023_003DzpPOEJqcAh7Lr)
		{
			if (face.Tessellation.PointArray != null)
			{
				_0023_003DzD0vYoclJjkWP.AddRange(face.Tessellation.PointArray);
			}
		}
	}

	protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		boxMin = Point3D.MaxValue;
		boxMax = Point3D.MinValue;
		bool _0023_003Dz9oqQC7s_003D = data == null || data.Transformation == null || data.Transformation.IsIdentity();
		bool _0023_003DzRVoDPs0_003D = true;
		_0023_003Dzgb_0024SKVSyiPAvoiSM6g_003D_003D(_faces, data, ref boxMin, ref boxMax, _0023_003Dz9oqQC7s_003D, ref _0023_003DzRVoDPs0_003D);
		Face[][] inners = _inners;
		for (int i = 0; i < inners.Length; i++)
		{
			_0023_003Dzgb_0024SKVSyiPAvoiSM6g_003D_003D(inners[i], data, ref boxMin, ref boxMax, _0023_003Dz9oqQC7s_003D, ref _0023_003DzRVoDPs0_003D);
		}
		return true;
	}

	private static void _0023_003Dzgb_0024SKVSyiPAvoiSM6g_003D_003D(Face[] _0023_003DzpPOEJqcAh7Lr, TraversalParams _0023_003DzELu0Pss_003D, ref Point3D _0023_003DzDPcjoBJLcqli, ref Point3D _0023_003Dz_0024N_0024yKptW9BoC, bool _0023_003Dz9oqQC7s_003D, ref bool _0023_003DzRVoDPs0_003D)
	{
		foreach (Face face in _0023_003DzpPOEJqcAh7Lr)
		{
			if (face.Tessellation.ComputeBoundingBox(_0023_003DzELu0Pss_003D, out var boxMin, out var boxMax))
			{
				if (_0023_003Dz9oqQC7s_003D)
				{
					face.Tessellation.localMin = boxMin;
					face.Tessellation.localMax = boxMax;
				}
				if (_0023_003DzRVoDPs0_003D)
				{
					Utility.InitializeMinMax(boxMin, out _0023_003DzDPcjoBJLcqli, out _0023_003Dz_0024N_0024yKptW9BoC);
					Utility.UpdateMinMaxQuick(boxMax, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
					_0023_003DzRVoDPs0_003D = false;
				}
				else
				{
					Utility.UpdateMinMaxQuick(boxMin, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
					Utility.UpdateMinMaxQuick(boxMax, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
				}
			}
		}
	}

	protected internal override void ComputeOffsetOnCameraAxes(OffsetOnCameraAxesParams data)
	{
		_0023_003Dzh77AI_0024MD2bzqvv_0024XyWIs4S4_003D(_faces, data);
		Face[][] inners = _inners;
		for (int i = 0; i < inners.Length; i++)
		{
			_0023_003Dzh77AI_0024MD2bzqvv_0024XyWIs4S4_003D(inners[i], data);
		}
	}

	private static void _0023_003Dzh77AI_0024MD2bzqvv_0024XyWIs4S4_003D(Face[] _0023_003DzpPOEJqcAh7Lr, OffsetOnCameraAxesParams _0023_003DzELu0Pss_003D)
	{
		for (int i = 0; i < _0023_003DzpPOEJqcAh7Lr.Length; i++)
		{
			_0023_003DzpPOEJqcAh7Lr[i].Tessellation.ComputeOffsetOnCameraAxes(_0023_003DzELu0Pss_003D);
		}
	}

	protected override void InitGraphicsData(RenderContextBase renderContext)
	{
		base.InitGraphicsData(renderContext);
		if (_drawWireData == null)
		{
			_drawWireData = renderContext.CreateEntityGraphicsData(this);
		}
	}

	public override void Compile(CompileParams data)
	{
		InitGraphicsData(data.RenderContext);
		_0023_003DzSrny2FmSPIa7();
		Edge[] edges = Edges;
		for (int i = 0; i < edges.Length; i++)
		{
			((Entity)edges[i].Curve).Compile(data);
		}
		GetMaterial(data.Materials, data.Layers, data.ParentMaterial);
		_ = data.Units;
		_0023_003DzPcRQnBLO6kcc0AFbtzf7o7YPuGQ5MZpu3A_003D_003D _0023_003DzPcRQnBLO6kcc0AFbtzf7o7YPuGQ5MZpu3A_003D_003D2 = new _0023_003DzPcRQnBLO6kcc0AFbtzf7o7YPuGQ5MZpu3A_003D_003D();
		_materialOnFace = false;
		Face[] faces = _faces;
		foreach (Face face in faces)
		{
			FastMesh _0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D = (face.InitDrawTessellation() ? face.drawTessellation : face.Tessellation);
			_0023_003DzPcRQnBLO6kcc0AFbtzf7o7YPuGQ5MZpu3A_003D_003D2._0023_003DzPJNpNF4_003D(new _0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D(face, _0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D));
			if (!string.IsNullOrEmpty(face.MaterialName))
			{
				_materialOnFace = true;
			}
		}
		Face[][] inners = _inners;
		for (int i = 0; i < inners.Length; i++)
		{
			faces = inners[i];
			foreach (Face face2 in faces)
			{
				FastMesh _0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D2 = (face2.InitDrawTessellation() ? face2.drawTessellation : face2.Tessellation);
				_0023_003DzPcRQnBLO6kcc0AFbtzf7o7YPuGQ5MZpu3A_003D_003D2._0023_003DzPJNpNF4_003D(new _0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D(face2, _0023_003DzPvRHOW81mIGJraj1OAAaOJ0_003D2));
				if (!string.IsNullOrEmpty(face2.MaterialName))
				{
					_materialOnFace = true;
				}
			}
		}
		_0023_003DzEHXTGfYkuxsA();
		_colorGroupsDrawData = new(EntityGraphicsData, Color?)[_0023_003DzPcRQnBLO6kcc0AFbtzf7o7YPuGQ5MZpu3A_003D_003D2._0023_003DzxuUw1NQ_003D.Count];
		for (int k = 0; k < _colorGroupsDrawData.Length; k++)
		{
			var (_0023_003DzpPOEJqcAh7Lr, item) = _0023_003DzPcRQnBLO6kcc0AFbtzf7o7YPuGQ5MZpu3A_003D_003D2._0023_003DzxuUw1NQ_003D[k];
			_colorGroupsDrawData[k] = (data.RenderContext.CreateEntityGraphicsData(this), item);
			base.Compiling = true;
			_0023_003DzkWmZw3diFVOfwtBKJqcRRU5yNSmg_00244DpLQ_003D_003D _0023_003DzkWmZw3diFVOfwtBKJqcRRU5yNSmg_00244DpLQ_003D_003D2 = new _0023_003DzkWmZw3diFVOfwtBKJqcRRU5yNSmg_00244DpLQ_003D_003D(_0023_003DzpPOEJqcAh7Lr);
			data.RenderContext.CompileVBO(_colorGroupsDrawData[k].Item1, _0023_003DzkWmZw3diFVOfwtBKJqcRRU5yNSmg_00244DpLQ_003D_003D2._0023_003DzmHTSerA_003D, _0023_003DzkWmZw3diFVOfwtBKJqcRRU5yNSmg_00244DpLQ_003D_003D2._0023_003DzmHTSerA_003D());
			base.Compiling = false;
		}
		base.Compiling = true;
		data.RenderContext.Compile(_drawWireData, _0023_003DzB1ACct51dJ0G, null);
		base.Compiling = false;
		regenMode = regenType.NotNeeded;
	}

	private void _0023_003DzB1ACct51dJ0G(RenderContextBase _0023_003DzB8iS0QA_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		int num = 0;
		int[] array = new int[_edges.Length];
		for (int i = 0; i < _edges.Length; i++)
		{
			Edge edge = _edges[i];
			array[i] = num;
			num += (((Entity)edge.Curve).Vertices.Length - 1) * 2;
		}
		Point3D[] array2 = new Point3D[num];
		for (int j = 0; j < _edges.Length; j++)
		{
			Point3D[] vertices = ((Entity)_edges[j].Curve).Vertices;
			Point3D[] array3 = new Point3D[(vertices.Length - 1) * 2];
			for (int k = 0; k < vertices.Length - 1; k++)
			{
				array3[k * 2] = vertices[k];
				array3[k * 2 + 1] = vertices[k + 1];
			}
			Array.Copy(array3, 0, array2, array[j], array3.Length);
		}
		_0023_003DzB8iS0QA_003D.DrawLines(array2);
	}

	protected internal override void DrawForSelectionWireframe(DrawForSelectionParams data)
	{
		data.RenderContext.Draw(_drawWireData);
	}

	protected internal override void DrawForSelectionEdges(DrawForSelectionParams data)
	{
		for (int i = 0; i < Edges.Length; i++)
		{
			Edge edge = Edges[i];
			data.viewportInternal.parent.SetColorDrawForSelectionAndUpdateIdItemsMap<SelectedEdge>(data, this, i);
			((Entity)edge.Curve).Draw(data);
			data.FalseColorIndex++;
		}
	}

	protected internal override void DrawForSelectionVertices(DrawForSelectionParams data)
	{
		for (int i = 0; i < Vertices.Length; i++)
		{
			Point3D v = Vertices[i];
			data.viewportInternal.parent.SetColorDrawForSelectionAndUpdateIdItemsMap<SelectedVertex>(data, this, i);
			data.RenderContext.DrawBufferedPoint(v);
			data.FalseColorIndex++;
		}
	}

	protected internal override void DrawForSelectionFaces(DrawForSelectionParams data)
	{
		int _0023_003DzJj8GJzxnZM = 0;
		int num = 0;
		_0023_003Dzm2NTXwuXOu06NTDTF1N1qmM_003D(data, _faces, num++, ref _0023_003DzJj8GJzxnZM);
		Face[][] inners = _inners;
		foreach (Face[] _0023_003DzpPOEJqcAh7Lr in inners)
		{
			_0023_003Dzm2NTXwuXOu06NTDTF1N1qmM_003D(data, _0023_003DzpPOEJqcAh7Lr, num++, ref _0023_003DzJj8GJzxnZM);
		}
	}

	private void _0023_003Dzm2NTXwuXOu06NTDTF1N1qmM_003D(DrawForSelectionParams _0023_003DzELu0Pss_003D, Face[] _0023_003DzpPOEJqcAh7Lr, int _0023_003DzRLCcpW4_003D, ref int _0023_003DzJj8GJzxnZM54)
	{
		for (int i = 0; i < _0023_003DzpPOEJqcAh7Lr.Length; i++)
		{
			Face face = _0023_003DzpPOEJqcAh7Lr[i];
			_0023_003DzELu0Pss_003D.viewportInternal.parent.SetColorDrawForSelectionAndUpdateIdItemsMap<SelectedFace>(_0023_003DzELu0Pss_003D, this, i, _0023_003DzRLCcpW4_003D);
			_0023_003DzELu0Pss_003D.FalseColorIndex++;
			face.Draw(_0023_003DzELu0Pss_003D, _textureLength);
		}
	}

	protected internal override void DrawSelected(DrawParams data)
	{
		if (!data.ForceGray && !data.ParentSelected && SelectionMode != selectionFilterType.Entity)
		{
			SelectionInfoSubItems selectionInfoSubItems = SelectionInfoItemBase.FindInstance(data.Parents, this, null, FacesSelectionInfo);
			SelectionInfoSubItemsArray selectionInfoSubItemsArray = SelectionInfoItemBase.FindInstance(data.Parents, this, null, InnerFacesSelectionInfo);
			if (selectionInfoSubItems != null)
			{
				_0023_003DzWrBM_0024AXx6fJO2ag57A_003D_003D(data, _faces, selectionInfoSubItems.SubItems);
			}
			else if (data.SelectionStatus != selectionStatusType.Temporary && !data.IsDrawingForHalo)
			{
				Entity.SetEntityColorForSelection(data);
				_0023_003Dz8Zo5XUwgjtVoCUCNtmED7Ro_003D(data, _faces);
			}
			if (selectionInfoSubItemsArray != null)
			{
				for (int i = 0; i < _inners.Length; i++)
				{
					_0023_003DzWrBM_0024AXx6fJO2ag57A_003D_003D(data, _inners[i], selectionInfoSubItemsArray.SubItems[i]);
				}
			}
			else if (data.SelectionStatus != selectionStatusType.Temporary && !data.IsDrawingForHalo)
			{
				Entity.SetEntityColorForSelection(data);
				for (int j = 0; j < _inners.Length; j++)
				{
					_0023_003Dz8Zo5XUwgjtVoCUCNtmED7Ro_003D(data, _inners[j]);
				}
			}
		}
		else
		{
			_0023_003DzR4Q0df5fIcWE(data);
		}
	}

	private void _0023_003DzWrBM_0024AXx6fJO2ag57A_003D_003D(DrawParams _0023_003DzELu0Pss_003D, Face[] _0023_003DzpPOEJqcAh7Lr, SelectionInfo[] _0023_003Dz6yuMK6iFN_0024si)
	{
		if (_0023_003DzELu0Pss_003D.SelectionStatus == selectionStatusType.Temporary && !_0023_003DzELu0Pss_003D.IsDrawingForHalo)
		{
			_0023_003DzELu0Pss_003D.RenderContext.PushBlendState();
			_0023_003DzELu0Pss_003D.RenderContext.SetState(blendStateType.ColorMaskOff);
			Face[] faces = _faces;
			for (int i = 0; i < faces.Length; i++)
			{
				faces[i].Draw(_0023_003DzELu0Pss_003D, _textureLength);
			}
			_0023_003DzELu0Pss_003D.RenderContext.PopBlendState();
			_0023_003DzELu0Pss_003D.RenderContext.PushDepthStencilState();
			_0023_003DzELu0Pss_003D.RenderContext.SetState(depthStencilStateType.DepthTestLessEqual);
		}
		Entity.SetSelectionColorForSelection(_0023_003DzELu0Pss_003D);
		for (int j = 0; j < _0023_003DzpPOEJqcAh7Lr.Length; j++)
		{
			if (_0023_003Dz6yuMK6iFN_0024si[j].IsFlagSet(_0023_003DzELu0Pss_003D.SelectionStatus))
			{
				_0023_003DzpPOEJqcAh7Lr[j].Draw(_0023_003DzELu0Pss_003D, _textureLength);
			}
		}
		if (_0023_003DzELu0Pss_003D.SelectionStatus != selectionStatusType.Temporary && !_0023_003DzELu0Pss_003D.IsDrawingForHalo)
		{
			Entity.SetEntityColorForSelection(_0023_003DzELu0Pss_003D);
			if (_0023_003DzELu0Pss_003D.ShaderParams.Texture2D)
			{
				_0023_003DzELu0Pss_003D.RenderContext.SetTextureLength(_0023_003DzELu0Pss_003D.InsideMaterial.TextureLength);
			}
			for (int k = 0; k < _0023_003DzpPOEJqcAh7Lr.Length; k++)
			{
				if (!_0023_003Dz6yuMK6iFN_0024si[k].IsFlagSet(_0023_003DzELu0Pss_003D.SelectionStatus))
				{
					if ((_0023_003DzpPOEJqcAh7Lr[k].MaterialName != null || _0023_003DzpPOEJqcAh7Lr[k].Color.HasValue) && !suspendFaceColor)
					{
						_0023_003DzpPOEJqcAh7Lr[k]._0023_003DzyoBNHb9uSLi2(_0023_003DzELu0Pss_003D, _textureLength);
					}
					else
					{
						_0023_003DzpPOEJqcAh7Lr[k].Draw(_0023_003DzELu0Pss_003D, _textureLength);
					}
				}
			}
			if (_0023_003DzELu0Pss_003D.ShaderParams != null && _0023_003DzELu0Pss_003D.ShaderParams.Texture2D)
			{
				_0023_003DzELu0Pss_003D.RenderContext.SetTextureLength(0f);
			}
		}
		if (_0023_003DzELu0Pss_003D.SelectionStatus == selectionStatusType.Temporary && !_0023_003DzELu0Pss_003D.IsDrawingForHalo)
		{
			_0023_003DzELu0Pss_003D.RenderContext.PopDepthStencilState();
		}
	}

	internal static bool _0023_003DzwRqUsQPmazuq(SelectionInfo[] _0023_003DzhrgkevI_003D)
	{
		for (int i = 0; i < _0023_003DzhrgkevI_003D.Length; i++)
		{
			SelectionInfo selectionInfo = _0023_003DzhrgkevI_003D[i];
			if (selectionInfo.IsFlagSet(selectionStatusType.Permanent) || selectionInfo.IsFlagSet(selectionStatusType.Temporary))
			{
				return true;
			}
		}
		return false;
	}

	protected internal void DrawWithFaceMaterial(DrawParams data)
	{
		if (!data.ForceGray)
		{
			_0023_003Dz8Zo5XUwgjtVoCUCNtmED7Ro_003D(data, _faces);
			for (int i = 0; i < _inners.Length; i++)
			{
				_0023_003Dz8Zo5XUwgjtVoCUCNtmED7Ro_003D(data, _inners[i]);
			}
		}
		else
		{
			_0023_003DzR4Q0df5fIcWE(data);
		}
	}

	public void ResetSelectionMode()
	{
		if (!IsAnyFaceSelected() && !SelectionInfoSubItems.IsAnySelected(EdgesSelectionInfo) && !SelectionInfoSubItems.IsAnySelected(VerticesSelectionInfo))
		{
			SelectionMode = selectionFilterType.Entity;
		}
	}

	public void SetEdgeSelection(int edgeIndex, bool status, Stack<BlockReference> parents = null)
	{
		SelectionInfoSubItems._0023_003DzTaF8sCpHm_00245q(selectionFilterType.Edge, edgeIndex, status, this, Edges, EdgesSelectionInfo, parents);
	}

	public bool GetEdgeSelection(int edgeIndex, Stack<BlockReference> parents = null)
	{
		return SelectionInfoItemBase._0023_003Dz4SMVPY0ZDXX8(this, Edges, EdgesSelectionInfo, edgeIndex, parents);
	}

	public void ClearEdgesSelection(Stack<BlockReference> parents)
	{
		int num = SelectedItemBase._0023_003DzAdoyA7k_003D(new SelectionInfoSubItems(parents, this), EdgesSelectionInfo);
		if (num >= 0)
		{
			EdgesSelectionInfo.RemoveAt(num);
			isDirtyForFlattenTree = true;
		}
	}

	public void ClearEdgesSelectionForAllInstances()
	{
		if (IsAnyEdgeSelected())
		{
			isDirtyForFlattenTree = true;
		}
		EdgesSelectionInfo.Clear();
	}

	public void SetVertexSelection(int vertexIndex, bool status, Stack<BlockReference> parents = null)
	{
		SelectionInfoSubItems._0023_003DzTaF8sCpHm_00245q(selectionFilterType.Vertex, vertexIndex, status, this, Vertices, VerticesSelectionInfo, parents);
	}

	public bool GetVertexSelection(int vertexIndex, Stack<BlockReference> parents = null)
	{
		return SelectionInfoItemBase._0023_003Dz4SMVPY0ZDXX8(this, Vertices, VerticesSelectionInfo, vertexIndex, parents);
	}

	public void ClearVerticesSelection(Stack<BlockReference> parents)
	{
		int num = SelectedItemBase._0023_003DzAdoyA7k_003D(new SelectionInfoSubItems(parents, this), VerticesSelectionInfo);
		if (num >= 0)
		{
			VerticesSelectionInfo.RemoveAt(num);
			isDirtyForFlattenTree = true;
		}
	}

	public void ClearVerticesSelectionForAllInstances()
	{
		if (IsAnyVertexSelected())
		{
			isDirtyForFlattenTree = true;
		}
		VerticesSelectionInfo.Clear();
	}

	internal void ClearEdgesSelection(selectionStatusType _0023_003DzCYtX6jC7ppkE)
	{
		SelectionInfoSubItems._0023_003DzpeLpar2z_0024ejG(_0023_003DzCYtX6jC7ppkE, this, EdgesSelectionInfo);
		if (_0023_003DzCYtX6jC7ppkE == selectionStatusType.Permanent && SelectionMode == selectionFilterType.Edge)
		{
			SelectionMode = selectionFilterType.Entity;
		}
	}

	[Obsolete("Use SetEdgeSelection()")]
	public void SelectEdge(int edgeIndex, bool selectionState, Stack<BlockReference> parents = null)
	{
		SelectionInfoSubItems._0023_003DzTaF8sCpHm_00245q(selectionFilterType.Edge, edgeIndex, selectionState, this, Edges, EdgesSelectionInfo, parents);
	}

	[Obsolete("Use SetVertexSelection()")]
	public void SelectVertex(int vertexIndex, bool selectionState, Stack<BlockReference> parents = null)
	{
		SelectionInfoSubItems._0023_003DzTaF8sCpHm_00245q(selectionFilterType.Vertex, vertexIndex, selectionState, this, Vertices, VerticesSelectionInfo, parents);
	}

	internal void ClearVerticesSelection(selectionStatusType _0023_003DzCYtX6jC7ppkE)
	{
		SelectionInfoSubItems._0023_003DzpeLpar2z_0024ejG(_0023_003DzCYtX6jC7ppkE, this, VerticesSelectionInfo);
		if (_0023_003DzCYtX6jC7ppkE == selectionStatusType.Permanent && SelectionMode == selectionFilterType.Vertex)
		{
			SelectionMode = selectionFilterType.Entity;
		}
	}

	protected internal override void DrawForSelection(DrawForSelectionParams data)
	{
		_0023_003DzR4Q0df5fIcWE(data);
	}

	protected internal override void DrawHiddenLines(DrawParams data)
	{
		if (data.viewportInternal.parent.HiddenLines.ColorMethod == hiddenLinesColorMethodType.SingleColor)
		{
			suspendFaceColor = true;
			base.DrawHiddenLines(data);
			suspendFaceColor = false;
		}
		else
		{
			base.DrawHiddenLines(data);
		}
	}

	protected internal override void DrawHiddenLinesFast(DrawParams data)
	{
		if (data.viewportInternal.parent.HiddenLines.ColorMethod == hiddenLinesColorMethodType.SingleColor)
		{
			suspendFaceColor = true;
			base.DrawHiddenLinesFast(data);
			suspendFaceColor = false;
		}
		else
		{
			base.DrawHiddenLinesFast(data);
		}
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
		_0023_003DzR4Q0df5fIcWE(data);
	}

	private void _0023_003Dzz1yHEHG8BZWD(DrawParams _0023_003DzELu0Pss_003D)
	{
		Color? color = null;
		Color? color2 = null;
		Color? color3 = null;
		Color? color4 = null;
		(EntityGraphicsData, Color?)[] colorGroupsDrawData = _colorGroupsDrawData;
		for (int i = 0; i < colorGroupsDrawData.Length; i++)
		{
			(EntityGraphicsData, Color?) tuple = colorGroupsDrawData[i];
			if (tuple.Item1.IsValid())
			{
				if (tuple.Item2.HasValue)
				{
					color = _0023_003DzELu0Pss_003D.RenderContext.CurrentWireColor;
					color2 = _0023_003DzELu0Pss_003D.RenderContext.CurrentMaterial.Diffuse;
					color3 = _0023_003DzELu0Pss_003D.RenderContext.CurrentBackMaterial.Diffuse;
					color4 = _0023_003DzELu0Pss_003D.RenderContext.CurrentMaterial.Ambient;
					Entity.SetEntityColorForFace(_0023_003DzELu0Pss_003D, tuple.Item2.Value);
				}
				_0023_003DzELu0Pss_003D.RenderContext.Draw(tuple.Item1, primitiveType.TriangleList);
				if (tuple.Item2.HasValue)
				{
					_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(color.Value);
					_0023_003DzELu0Pss_003D.RenderContext.SetMaterialFrontDiffuse(color2.Value);
					_0023_003DzELu0Pss_003D.RenderContext.SetMaterialBackDiffuse(color3.Value);
					_0023_003DzELu0Pss_003D.RenderContext.SetMaterialFrontAmbient(color4.Value);
				}
			}
		}
	}

	private void _0023_003DzR4Q0df5fIcWE(DrawParams _0023_003DzELu0Pss_003D)
	{
		(EntityGraphicsData, Color?)[] colorGroupsDrawData = _colorGroupsDrawData;
		for (int i = 0; i < colorGroupsDrawData.Length; i++)
		{
			(EntityGraphicsData, Color?) tuple = colorGroupsDrawData[i];
			if (tuple.Item1.IsValid())
			{
				_0023_003DzELu0Pss_003D.RenderContext.Draw(tuple.Item1);
			}
		}
	}

	protected internal override void Draw(DrawParams data)
	{
		if (_materialOnFace)
		{
			DrawWithFaceMaterial(data);
		}
		else if (data.Selected)
		{
			DrawSelected(data);
		}
		else if (data.ForceGray || suspendFaceColor)
		{
			_0023_003DzR4Q0df5fIcWE(data);
		}
		else
		{
			_0023_003Dzz1yHEHG8BZWD(data);
		}
	}

	private void _0023_003Dz8Zo5XUwgjtVoCUCNtmED7Ro_003D(DrawParams _0023_003DzELu0Pss_003D, Face[] _0023_003DzpPOEJqcAh7Lr)
	{
		foreach (Face face in _0023_003DzpPOEJqcAh7Lr)
		{
			if ((face.MaterialName != null || face.Color.HasValue) && !suspendFaceColor)
			{
				face._0023_003DzyoBNHb9uSLi2(_0023_003DzELu0Pss_003D, _textureLength);
			}
			else
			{
				face.Draw(_0023_003DzELu0Pss_003D, _textureLength);
			}
		}
	}

	protected internal override void DrawWireframe(DrawParams data)
	{
		if (!data.viewportInternal.parent.Wireframe.ShowEdges)
		{
			RenderContextBase renderContext = data.RenderContext;
			renderContext.SetColorWireframe(Color.FromArgb(255, renderContext.CurrentWireColor));
			renderContext.SetLineSize(data.Attributes.LineWeight * data.LineWeightFactor);
			DrawEdges(data);
		}
	}

	protected internal override void DrawEdges(DrawParams data)
	{
		if (!data.ForceGray && !data.ParentSelected && data.Selected && SelectionMode != selectionFilterType.Entity)
		{
			_0023_003Dzco6tWIjnFcan(data);
		}
		else
		{
			data.RenderContext.Draw(_drawWireData);
		}
	}

	private void _0023_003Dzco6tWIjnFcan(DrawParams _0023_003DzELu0Pss_003D)
	{
		bool flag = _0023_003DzELu0Pss_003D.Selected;
		SelectionInfoSubItems selectionInfoSubItems = SelectionInfoItemBase.FindInstance(_0023_003DzELu0Pss_003D.Parents, this, null, EdgesSelectionInfo);
		if (selectionInfoSubItems != null)
		{
			float currentLineWidth = _0023_003DzELu0Pss_003D.RenderContext.CurrentLineWidth;
			for (int i = 0; i < Edges.Length; i++)
			{
				if (selectionInfoSubItems.SubItems[i].IsFlagSet(_0023_003DzELu0Pss_003D.SelectionStatus))
				{
					if (!flag)
					{
						_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.EdgeThickness * _0023_003DzELu0Pss_003D.SelectionLineWeightScaleFactor);
						_0023_003DzELu0Pss_003D.RenderContext.SetColorWireframe(_0023_003DzELu0Pss_003D.InsideSelectionColor);
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
						_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.EdgeThickness);
						flag = false;
					}
				}
				((Entity)Edges[i].Curve).Draw(_0023_003DzELu0Pss_003D);
			}
			_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(currentLineWidth);
		}
		else if (_0023_003DzELu0Pss_003D.SelectionStatus != selectionStatusType.Temporary && !_0023_003DzELu0Pss_003D.IsDrawingForHalo)
		{
			Entity.SetEntityColorForSelection(_0023_003DzELu0Pss_003D);
			_0023_003DzELu0Pss_003D.RenderContext.SetLineSize(_0023_003DzELu0Pss_003D.EdgeThickness);
			Edge[] edges = _edges;
			for (int j = 0; j < edges.Length; j++)
			{
				((Entity)edges[j].Curve).Draw(_0023_003DzELu0Pss_003D);
			}
		}
	}

	protected internal override void DrawSelectedVertices(DrawParams data)
	{
		List<Point3D> list = new List<Point3D>();
		List<Point3D> list2 = new List<Point3D>();
		SelectionInfoSubItems selectionInfoSubItems = SelectionInfoItemBase.FindInstance(data.Parents, this, null, VerticesSelectionInfo);
		if (selectionInfoSubItems == null)
		{
			return;
		}
		if (data.SelectionStatus != selectionStatusType.None)
		{
			if (!data.ForceGray && data.Selected)
			{
				for (int i = 0; i < Vertices.Length; i++)
				{
					if (selectionInfoSubItems.SubItems[i].IsFlagSet(data.SelectionStatus))
					{
						list.Add(Vertices[i]);
					}
				}
			}
		}
		else
		{
			for (int j = 0; j < Vertices.Length; j++)
			{
				if (selectionInfoSubItems.SubItems[j]._selectionStatus != selectionStatusType.None)
				{
					list.Add(Vertices[j]);
				}
				else
				{
					list2.Add(Vertices[j]);
				}
			}
		}
		bool flag = false;
		if (list.Count > 0)
		{
			flag = true;
			data.RenderContext.PushBlendState();
			data.RenderContext.SetState(blendStateType.NoBlend);
			data.RenderContext.SetColorWireframe(data.InsideSelectionColor);
			data.RenderContext.DrawPoints(list.ToArray());
			data.RenderContext.PopBlendState();
		}
		if (flag)
		{
			data.RenderContext.SetColorWireframe(data.InsideColor);
		}
		if (list2.Count > 0)
		{
			data.RenderContext.DrawPoints(list2.ToArray());
		}
	}

	internal override SilhoWireData _0023_003DzEt1XHB_xc_BLLBoMbJmskWU_003D(PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		bool flag = _0023_003DzELu0Pss_003D.Camera.ProjectionMode == projectionType.Orthographic && IsClosed;
		Vector3D vector3D = _0023_003DzELu0Pss_003D.Camera.ViewNormal;
		if (flag && _0023_003DzELu0Pss_003D.FrustumParams.Transformation != null)
		{
			vector3D = (Vector3D)vector3D.Clone();
			Transformation transformation = (Transformation)_0023_003DzELu0Pss_003D.FrustumParams.Transformation.Clone();
			transformation.Invert();
			vector3D.TransformBy(transformation);
		}
		_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2 = _0023_003DzHebbve2m4A66_w8W9zkAnyo_003D(_0023_003DzELu0Pss_003D.KeepHiddenSegments, flag, vector3D);
		if (_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2 == null && flag)
		{
			_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2 = _0023_003DzHebbve2m4A66_w8W9zkAnyo_003D(_0023_003DzELu0Pss_003D.KeepHiddenSegments, _0023_003DzNW8kXZkeqMlohqG_0024373c8wCspM8Wr1uMXQ_003D_003D: false, vector3D);
		}
		if (_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2 != null)
		{
			return HiddenLinesView._0023_003DzeWZNZhCW691ciXKd0w_003D_003D(this, _0023_003DzELu0Pss_003D.Parents, _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2._0023_003DzNKR_cAYoR2aGDUGpng_003D_003D, _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2._0023_003DzZSnvfVF8Y5Qg, _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2._0023_003DzU4XYawo_003D, IsClosed, 0.0);
		}
		return null;
	}

	internal override SilhoWireData _0023_003DzOQ9MbnSofHiL_xtPyyGkf6ozeVZJ(PreProcessSilhouettesParams _0023_003DzELu0Pss_003D)
	{
		FastMesh fastMesh = _0023_003DzaXOXMdWGwLJtDhpErLettuQ_003D(_0023_003DzzvgX00ljK1e4: true);
		IndexLine[] _0023_003DzU3hosSAzkxO = null;
		if (fastMesh != null)
		{
			return HiddenLinesView._0023_003DzeWZNZhCW691ciXKd0w_003D_003D(this, _0023_003DzELu0Pss_003D.Parents, fastMesh.PointArray, fastMesh.TriangleArray, _0023_003DzU3hosSAzkxO, IsClosed, 0.0);
		}
		return new _0023_003Dz3_PtpOaOjpXjWC_vDAZRJohk7rQE0Ct_tA_003D_003D(this, null);
	}

	protected internal override void SetLineWeightForSilhouettes(DrawSilhouettesParams data)
	{
		float num = data.SilhoThickness;
		if (SilhouettesDrawingMode != silhouettesDrawingType.Standard)
		{
			num = data.EdgeThickness;
		}
		if (data.Selected && FlagsHelper.IsSet(SelectionMode, selectionFilterType.Entity))
		{
			num *= data.SelectionLineWeightScaleFactor;
		}
		_0023_003Dzw7EU_3iuNJBd(data, num);
	}

	protected internal override void DrawSilhouettes(DrawSilhouettesParams data)
	{
		if (!Mesh._0023_003Dz5sgFm90LQ3fISwPMCQ_003D_003D(data, SelectionMode) && RegenMode == regenType.NotNeeded)
		{
			bool skipBorderEdges = data.SkipBorderEdges;
			if (SilhouettesDrawingMode != silhouettesDrawingType.Standard)
			{
				data.SkipBorderEdges = true;
			}
			HiddenLinesView._0023_003DzY9TYF9sTjnZYO51HtXX26S0_003D(this, data);
			data.SkipBorderEdges = skipBorderEdges;
		}
	}

	internal _0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D _0023_003DzpxaK_etP8mGw(Color _0023_003Dz1MMYB1g_003D)
	{
		_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D _0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2 = new _0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D();
		if (base.TranslationID != null && !string.IsNullOrEmpty(base.TranslationID.Name))
		{
			_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2._0023_003DzS_00246o7tc_003D = WriteSTEP._0023_003DzS0Pr1Qk_003D(base.TranslationID.Name);
		}
		for (int i = 0; i < Vertices.Length; i++)
		{
			Point3D point3D = Vertices[i];
			_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2._0023_003DzKaHmcDF41bzcKoQbLQ_003D_003D.Add(new _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D(point3D.X, point3D.Y, point3D.Z, 1.0, i));
		}
		for (int j = 0; j < Edges.Length; j++)
		{
			Edge edge = Edges[j];
			_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D2 = new _0023_003DzAesEZlpt4n5DGdrqIA_003D_003D(TrimCurve._0023_003Dzr6lX0LAcmuDg(edge.Curve)._0023_003DzyXmKbtw_003D, j, edge.StartPointIndex, edge.EndPointIndex);
			if (edge.TranslationID != null && !string.IsNullOrEmpty(edge.TranslationID.Name))
			{
				_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D2._0023_003DzDzRTlWYpsVqm(WriteSTEP._0023_003DzS0Pr1Qk_003D(edge.TranslationID.Name));
			}
			_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2._0023_003DzZi4TmHJSVINO.Add(_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D2);
		}
		int _0023_003Dzfsn580w_003D = 0;
		List<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D> _0023_003Dzsxj5eGbuTeczQAxsKg_003D_003D = _0023_003DzA8XV6BjEzDp4zQbL1w_003D_003D(Faces, _0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2, ref _0023_003Dzfsn580w_003D);
		_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2._0023_003Dz_SqBXz8_003D._0023_003DzgMoDyVyuV67MZBgNCPrRZu_M1Y7u(_0023_003Dzsxj5eGbuTeczQAxsKg_003D_003D);
		_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2._0023_003DzWaFlkhfmYCja = new List<_0023_003DzSO_l6Vl7Ap5t>();
		Face[][] inners = Inners;
		foreach (Face[] _0023_003DzEtn4dIEPKCsi in inners)
		{
			List<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D> _0023_003Dzsxj5eGbuTeczQAxsKg_003D_003D2 = _0023_003DzA8XV6BjEzDp4zQbL1w_003D_003D(_0023_003DzEtn4dIEPKCsi, _0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2, ref _0023_003Dzfsn580w_003D);
			_0023_003DzSO_l6Vl7Ap5t _0023_003DzSO_l6Vl7Ap5t2 = new _0023_003DzSO_l6Vl7Ap5t();
			_0023_003DzSO_l6Vl7Ap5t2._0023_003DzgMoDyVyuV67MZBgNCPrRZu_M1Y7u(_0023_003Dzsxj5eGbuTeczQAxsKg_003D_003D2);
			_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2._0023_003DzWaFlkhfmYCja.Add(_0023_003DzSO_l6Vl7Ap5t2);
		}
		_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2._0023_003Dzwtld1NM_003D = Utility.ColorToDoubleArray(_0023_003Dz1MMYB1g_003D);
		return _0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D2;
	}

	internal override _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[] _0023_003DzAKDLnmImamFN(Color _0023_003Dz1MMYB1g_003D, Dictionary<string, List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>> _0023_003DzISRR3MaRx1qQ, linearUnitsType _0023_003DzsAi4oSk_003D)
	{
		_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2 = new _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D();
		_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzyZFnD3E_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302959468));
		_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzrdvTjeaFTRlY = _0023_003DzsAi4oSk_003D;
		_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003Dz5bVmMWCNZpiUDgO8rg_003D_003D().Add(_0023_003DzpxaK_etP8mGw(_0023_003Dz1MMYB1g_003D));
		_0023_003DzYe_6EnQecc8d(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2, _0023_003Dz1MMYB1g_003D, _0023_003DzISRR3MaRx1qQ);
		return new _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D[1] { _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2 };
	}

	internal bool _0023_003DzqVbueJBALRcMy_0024MhR5DmES0_003D(SizesOnCurve[] _0023_003DzSrRL3Zr_fKWh, VolumeMesher _0023_003Dz1rWN_AM_003D, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, string _0023_003Dz3lURioVh8358, StringBuilder _0023_003DzqmF8XJ0_003D, out Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, out int[] _0023_003DzZQ2HyLn4R0pl)
	{
		Brep brep = (Brep)Clone();
		brep.Rebuild();
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = null;
		_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = null;
		_0023_003DzZQ2HyLn4R0pl = null;
		if (!brep._0023_003Dz2lo2BymHsQ6hbknq5hTRcEYbsbwt(_0023_003DzSrRL3Zr_fKWh, _0023_003Dz1rWN_AM_003D, _0023_003Dz3lURioVh8358, _0023_003DzqmF8XJ0_003D, out var _0023_003DzO5ynmul98lyB, null, default(CancellationToken)))
		{
			return false;
		}
		List<Mesh> list = new List<Mesh>();
		List<int> list2 = new List<int>();
		int num = 0;
		Face[] faces = brep.Faces;
		foreach (Face _0023_003DzHEpjcdg2hk9U in faces)
		{
			if (!_0023_003DzMmqK9nDn_mze(_0023_003DzHEpjcdg2hk9U, _0023_003DzO5ynmul98lyB[num++], list, list2))
			{
				return false;
			}
		}
		Face[][] inners = brep.Inners;
		for (int i = 0; i < inners.Length; i++)
		{
			faces = inners[i];
			foreach (Face _0023_003DzHEpjcdg2hk9U2 in faces)
			{
				if (!_0023_003DzMmqK9nDn_mze(_0023_003DzHEpjcdg2hk9U2, _0023_003DzO5ynmul98lyB[num++], list, list2))
				{
					return false;
				}
			}
		}
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		Mesh mesh = list[0];
		mesh.EdgeStyle = Mesh.edgeStyleType.Free;
		mesh.ComputeEdges();
		for (int k = 1; k < list.Count; k++)
		{
			Mesh mesh2 = list[k];
			if (mesh2 != null && mesh2.Vertices.Length != 0)
			{
				mesh2.EdgeStyle = Mesh.edgeStyleType.Free;
				mesh2.ComputeEdges();
				mesh.MergeWith(mesh2, weldNow: false, recomputeEdges: false);
			}
		}
		stopwatch.Stop();
		_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962822), (double)stopwatch.ElapsedMilliseconds / 1000.0));
		stopwatch.Reset();
		stopwatch.Start();
		double num2 = _0023_003Dz8xrHk0Q_0024GqJqkIqq_g_003D_003D(mesh);
		stopwatch.Stop();
		_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963557), (double)stopwatch.ElapsedMilliseconds / 1000.0));
		stopwatch.Reset();
		stopwatch.Start();
		mesh.WeldFreeEdgesQuadratic(num2 / 10.0);
		stopwatch.Stop();
		_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963528), (double)stopwatch.ElapsedMilliseconds / 1000.0));
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = mesh.Vertices;
		_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = mesh.Triangles;
		_0023_003DzZQ2HyLn4R0pl = null;
		if (list2.Count > 0)
		{
			_0023_003DzZQ2HyLn4R0pl = list2.ToArray();
		}
		return true;
	}

	internal bool _0023_003Dz1td33yCcgI1ZRbAOew_003D_003D(SizesOnCurve[] _0023_003DzSrRL3Zr_fKWh, VolumeMesher _0023_003Dz1rWN_AM_003D, string _0023_003Dz3lURioVh8358, StringBuilder _0023_003DzqmF8XJ0_003D, out Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, out int[] _0023_003DzZQ2HyLn4R0pl, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		Brep brep = (Brep)Clone();
		brep.Rebuild();
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = null;
		_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = null;
		_0023_003DzZQ2HyLn4R0pl = null;
		if (!brep._0023_003Dz2lo2BymHsQ6hbknq5hTRcEYbsbwt(_0023_003DzSrRL3Zr_fKWh, _0023_003Dz1rWN_AM_003D, _0023_003Dz3lURioVh8358, _0023_003DzqmF8XJ0_003D, out var _0023_003DzO5ynmul98lyB, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
		{
			return false;
		}
		List<Mesh> list = new List<Mesh>();
		List<int> list2 = new List<int>();
		int num = 0;
		Face[] faces = brep.Faces;
		for (int i = 0; i < faces.Length; i++)
		{
			_0023_003DzN2UZIMbkHoLu(faces[i], _0023_003DzO5ynmul98lyB[num++], list, list2);
		}
		Face[][] inners = brep.Inners;
		for (int i = 0; i < inners.Length; i++)
		{
			faces = inners[i];
			for (int j = 0; j < faces.Length; j++)
			{
				_0023_003DzN2UZIMbkHoLu(faces[j], _0023_003DzO5ynmul98lyB[num++], list, list2);
			}
		}
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		Mesh mesh = list[0];
		mesh.EdgeStyle = Mesh.edgeStyleType.Free;
		mesh.ComputeEdges();
		for (int k = 1; k < list.Count; k++)
		{
			Mesh mesh2 = list[k];
			if (mesh2 != null && mesh2.Vertices.Length != 0)
			{
				mesh2.EdgeStyle = Mesh.edgeStyleType.Free;
				mesh2.ComputeEdges();
				mesh.MergeWith(mesh2, weldNow: false, recomputeEdges: false);
			}
		}
		stopwatch.Stop();
		_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302962822), (double)stopwatch.ElapsedMilliseconds / 1000.0));
		stopwatch.Reset();
		stopwatch.Start();
		double num2 = _0023_003Dz8xrHk0Q_0024GqJqkIqq_g_003D_003D(mesh);
		stopwatch.Stop();
		_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963557), (double)stopwatch.ElapsedMilliseconds / 1000.0));
		stopwatch.Reset();
		stopwatch.Start();
		mesh.Weld(num2 / 10.0);
		stopwatch.Stop();
		_0023_003DzqmF8XJ0_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963528), (double)stopwatch.ElapsedMilliseconds / 1000.0));
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = mesh.Vertices;
		_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = mesh.Triangles;
		_0023_003DzZQ2HyLn4R0pl = null;
		if (list2.Count > 0)
		{
			_0023_003DzZQ2HyLn4R0pl = list2.ToArray();
		}
		return true;
	}

	private bool _0023_003DzMmqK9nDn_mze(Face _0023_003DzHEpjcdg2hk9U, Mesh _0023_003DzkKfJheA_003D, List<Mesh> _0023_003DzcFIqX7s_003D, List<int> _0023_003DzZQ2HyLn4R0pl)
	{
		List<ICurve> list = new List<ICurve>(_0023_003DzHEpjcdg2hk9U.Loops.Length);
		Loop[] loops = _0023_003DzHEpjcdg2hk9U.Loops;
		for (int i = 0; i < loops.Length; i++)
		{
			OrientedEdge[] segments = loops[i].Segments;
			for (int j = 0; j < segments.Length; j++)
			{
				OrientedEdge orientedEdge = segments[j];
				list.Add(Edges[orientedEdge.CurveIndex].Curve);
			}
		}
		Mesh mesh = Surface._0023_003DzqONH5KoLjeGW(_0023_003DzHEpjcdg2hk9U.Parametric[0], _0023_003DzkKfJheA_003D, list, null);
		if (mesh == null)
		{
			return false;
		}
		_0023_003DzcFIqX7s_003D.Add(mesh);
		int num = _0023_003DzkKfJheA_003D.Triangles.Length;
		int[] array = new int[num];
		for (int k = 0; k < num; k++)
		{
			array[k] = _0023_003DzHEpjcdg2hk9U.Subdomain;
		}
		_0023_003DzZQ2HyLn4R0pl.AddRange(array);
		return true;
	}

	private static void _0023_003DzN2UZIMbkHoLu(Face _0023_003DzHEpjcdg2hk9U, Mesh _0023_003DzkKfJheA_003D, List<Mesh> _0023_003DzcFIqX7s_003D, List<int> _0023_003DzZQ2HyLn4R0pl)
	{
		_0023_003DzcFIqX7s_003D.Add(_0023_003DzkKfJheA_003D);
		int num = _0023_003DzkKfJheA_003D.Triangles.Length;
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = _0023_003DzHEpjcdg2hk9U.Subdomain;
		}
		_0023_003DzZQ2HyLn4R0pl.AddRange(array);
	}

	private static double _0023_003Dz8xrHk0Q_0024GqJqkIqq_g_003D_003D(Mesh _0023_003DzGGJSiQk_003D)
	{
		Utility.GetEdgesWithoutDuplicates(_0023_003DzGGJSiQk_003D.Triangles, _0023_003DzGGJSiQk_003D.Vertices.Length, out var edgesPerVertex);
		double num = double.MaxValue;
		for (int i = 0; i < edgesPerVertex.Length; i++)
		{
			foreach (SharedEdge item in edgesPerVertex[i])
			{
				double num2 = Point3D.DistanceSquared(_0023_003DzGGJSiQk_003D.Vertices[i], _0023_003DzGGJSiQk_003D.Vertices[item.V2]);
				if (num2 < num)
				{
					num = num2;
				}
			}
		}
		return Math.Sqrt(num);
	}

	public Mesh ConvertToMesh(double deviation = 0.0, double angle = 0.0, Mesh.natureType nature = Mesh.natureType.Smooth, bool weld = true)
	{
		return ConvertToMesh(deviation, angle, nature, weld, 0.0);
	}

	public Mesh ConvertToMesh(double deviation, double angle, Mesh.natureType meshNature, bool weldNow, double weldMaxGap, MaterialKeyedCollection materials = null, linearUnitsType blockUnits = linearUnitsType.Unitless, Color? actualColor = null)
	{
		if (deviation == 0.0)
		{
			if (_faces.Length == 0)
			{
				return null;
			}
			if (_faces[0].Tessellation == null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958484));
			}
			List<Mesh> list = new List<Mesh>(_faces.Length);
			_0023_003Dz4IIRRMw3cf6H(_faces, list, meshNature, this, _0023_003DzzvgX00ljK1e4: false, materials, blockUnits, actualColor);
			for (int i = 0; i < _inners.Length; i++)
			{
				_0023_003Dz4IIRRMw3cf6H(_inners[i], list, meshNature, this, _0023_003DzzvgX00ljK1e4: false, materials, blockUnits, actualColor);
			}
			Mesh mesh = list[0];
			if (mesh == null)
			{
				return null;
			}
			for (int j = 1; j < list.Count; j++)
			{
				Mesh mesh2 = list[j];
				if (mesh2 != null && mesh2.Vertices.Length != 0)
				{
					mesh.MergeWith(mesh2, weldNow: false, recomputeEdges: false);
				}
			}
			mesh.Edges = null;
			mesh.EdgeStyle = Mesh.edgeStyleType.Sharp;
			mesh.RegenMode = regenType.RegenAndCompile;
			if (weldNow)
			{
				double maxGap = base.BoxSize.Diagonal * Utility._0023_003DzxhnLabVjXjPg;
				if (weldMaxGap > 0.0)
				{
					maxGap = weldMaxGap;
				}
				mesh.Weld(maxGap);
			}
			return mesh;
		}
		Brep obj = (Brep)Clone();
		obj.Regen(new RegenParams(deviation, angle));
		return obj.ConvertToMesh(0.0, 0.0, meshNature, weldNow, weldMaxGap, materials, blockUnits, actualColor);
	}

	private _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D _0023_003DzHebbve2m4A66_w8W9zkAnyo_003D(bool _0023_003Dzd5WfzA4r_3LXUhqXyw_003D_003D, bool _0023_003DzNW8kXZkeqMlohqG_0024373c8wCspM8Wr1uMXQ_003D_003D, Vector3D _0023_003DzzI1V7USxatHy)
	{
		List<_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D> list = new List<_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D>(_faces.Length);
		_0023_003DzMeIkmnOGyaXU_anJ_0024w_003D_003D(_faces, list, _0023_003DzNW8kXZkeqMlohqG_0024373c8wCspM8Wr1uMXQ_003D_003D, _0023_003DzzI1V7USxatHy);
		if (_0023_003Dzd5WfzA4r_3LXUhqXyw_003D_003D)
		{
			Face[][] inners = _inners;
			foreach (Face[] _0023_003DzpPOEJqcAh7Lr in inners)
			{
				_0023_003DzMeIkmnOGyaXU_anJ_0024w_003D_003D(_0023_003DzpPOEJqcAh7Lr, list, _0023_003DzNW8kXZkeqMlohqG_0024373c8wCspM8Wr1uMXQ_003D_003D, _0023_003DzzI1V7USxatHy);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		try
		{
			_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2 = list[0];
			for (int j = 1; j < list.Count; j++)
			{
				_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D3 = list[j];
				if (_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D3 != null && _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D3._0023_003DzNKR_cAYoR2aGDUGpng_003D_003D.Length != 0)
				{
					_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2._0023_003DzSnbFaS0_003D(_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D3, _0023_003DzEuQ72GKNmfZl: false, _0023_003DzFD2DkC_4lrYUT6xPuw_003D_003D: false, base.BoxSize);
				}
			}
			_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D._0023_003Dz6tNTbj2n_0024gTT(ref _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2._0023_003DzNKR_cAYoR2aGDUGpng_003D_003D, ref _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2._0023_003DzZSnvfVF8Y5Qg, _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2._0023_003DzU4XYawo_003D, base.BoxSize.Diagonal * Utility._0023_003DzxhnLabVjXjPg);
			return _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2;
		}
		catch (Exception)
		{
			return null;
		}
	}

	private void _0023_003DzMeIkmnOGyaXU_anJ_0024w_003D_003D(Face[] _0023_003DzpPOEJqcAh7Lr, List<_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D> _0023_003DzcFIqX7s_003D, bool _0023_003DzNW8kXZkeqMlohqG_0024373c8wCspM8Wr1uMXQ_003D_003D, Vector3D _0023_003DzzI1V7USxatHy)
	{
		foreach (Face face in _0023_003DzpPOEJqcAh7Lr)
		{
			if (face.Surface.GetType() == typeof(PlanarSurf))
			{
				if (!_0023_003DzNW8kXZkeqMlohqG_0024373c8wCspM8Wr1uMXQ_003D_003D || !Vector3D.AreOrthogonal(((PlanarSurf)face.Surface).Plane.AxisZ, _0023_003DzzI1V7USxatHy, Utility._0023_003DzxhnLabVjXjPg))
				{
					_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2 = face._0023_003Dz9ou0t1_BU0wq(_edges);
					if (_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2 != null)
					{
						_0023_003DzcFIqX7s_003D.Add(_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D2);
					}
				}
			}
			else if (face.Surface is TabulatedSurf tabulatedSurf)
			{
				if (_0023_003DzNW8kXZkeqMlohqG_0024373c8wCspM8Wr1uMXQ_003D_003D)
				{
					Vector3D obj = (Vector3D)tabulatedSurf.Generatrix.Clone();
					obj.Normalize();
					if (Vector3D.AreParallel(obj, _0023_003DzzI1V7USxatHy))
					{
						continue;
					}
				}
				if (Utility.IsLine(tabulatedSurf.Directrix))
				{
					_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D3 = face._0023_003Dz9ou0t1_BU0wq(_edges);
					if (_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D3 != null)
					{
						_0023_003DzcFIqX7s_003D.Add(_0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D3);
					}
				}
				else
				{
					Mesh _0023_003DzkKfJheA_003D = face.ConvertToMesh(Mesh.natureType.Plain, this);
					_0023_003DzcP2QEP72QnnE(face, _0023_003DzkKfJheA_003D);
					_0023_003DzcFIqX7s_003D.Add(new _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D(_0023_003DzkKfJheA_003D));
				}
			}
			else if (!_0023_003DzNW8kXZkeqMlohqG_0024373c8wCspM8Wr1uMXQ_003D_003D || !(face.Surface.GetType() == typeof(CylindricalSurf)) || !Vector3D.AreParallel(((CylindricalSurf)face.Surface).Plane.AxisZ, _0023_003DzzI1V7USxatHy))
			{
				Mesh mesh = face.ConvertToMesh(Mesh.natureType.Plain, this);
				if (mesh.Triangles.Length != 0)
				{
					_0023_003DzcP2QEP72QnnE(face, mesh);
					_0023_003DzcFIqX7s_003D.Add(new _0023_003Dz8eGM0HNbeTTHUmXgkq155V0_003D(mesh));
				}
			}
		}
	}

	private void _0023_003DzcP2QEP72QnnE(Face _0023_003DzHEpjcdg2hk9U, Mesh _0023_003DzkKfJheA_003D)
	{
		if (_0023_003DzkKfJheA_003D.Edges == null)
		{
			return;
		}
		double _0023_003DzPRk9EFntRplh = 1E-06;
		ICurve[] orientedTrimLoops = _0023_003DzHEpjcdg2hk9U.GetOrientedTrimLoops(_edges);
		for (int i = 0; i < _0023_003DzkKfJheA_003D.Edges.Length; i++)
		{
			HiddenLinesView._0023_003DzPWBOFEX1IKDR _0023_003DzPWBOFEX1IKDR = new HiddenLinesView._0023_003DzPWBOFEX1IKDR(_0023_003DzkKfJheA_003D.Edges[i].V1, _0023_003DzkKfJheA_003D.Edges[i].V2);
			_0023_003DzkKfJheA_003D.Edges[i] = _0023_003DzPWBOFEX1IKDR;
			Point3D point3D = _0023_003DzkKfJheA_003D.Vertices[_0023_003DzPWBOFEX1IKDR.V1];
			_0023_003Dza9w_00246r75Zgo_0024(point3D, _0023_003DzPWBOFEX1IKDR, orientedTrimLoops, _0023_003DzPRk9EFntRplh);
			if (_0023_003DzPWBOFEX1IKDR._0023_003DzSaHVljQ_003D == -1)
			{
				Point3D point3D2 = _0023_003DzkKfJheA_003D.Vertices[_0023_003DzPWBOFEX1IKDR.V2];
				_0023_003Dza9w_00246r75Zgo_0024(point3D2, _0023_003DzPWBOFEX1IKDR, orientedTrimLoops, _0023_003DzPRk9EFntRplh);
				if (_0023_003DzPWBOFEX1IKDR._0023_003DzSaHVljQ_003D == -1)
				{
					_0023_003DzrjUK5hAOpsZB(point3D, point3D2, _0023_003DzPWBOFEX1IKDR, orientedTrimLoops, _0023_003DzPRk9EFntRplh);
				}
			}
		}
	}

	private int[] _0023_003DzPbxuxBKxqDn_0024(Face _0023_003DzHEpjcdg2hk9U)
	{
		List<int> list = new List<int>(_0023_003DzHEpjcdg2hk9U.Loops.Length);
		for (int i = 0; i < _0023_003DzHEpjcdg2hk9U.Loops.Length; i++)
		{
			OrientedEdge[] segments = _0023_003DzHEpjcdg2hk9U.Loops[i].Segments;
			for (int j = 0; j < segments.Length; j++)
			{
				OrientedEdge orientedEdge = segments[j];
				if (!list.Contains(orientedEdge.CurveIndex))
				{
					list.Add(orientedEdge.CurveIndex);
				}
			}
		}
		return list.ToArray();
	}

	private static void _0023_003Dza9w_00246r75Zgo_0024(Point3D _0023_003DzMlCq3wk_003D, HiddenLinesView._0023_003DzPWBOFEX1IKDR _0023_003DzTx2aqr8_003D, ICurve[] _0023_003DzRTbTK_0024KwG32W, double _0023_003DzPRk9EFntRplh)
	{
		for (int i = 0; i < _0023_003DzRTbTK_0024KwG32W.Length; i++)
		{
			ICurve[] individualCurves = _0023_003DzRTbTK_0024KwG32W[i].GetIndividualCurves();
			foreach (ICurve curve in individualCurves)
			{
				Entity entity = (Entity)curve;
				for (int k = 1; k < entity.Vertices.Length - 1; k++)
				{
					if (Point3D.DistanceSquared(_0023_003DzMlCq3wk_003D, entity.Vertices[k]) < _0023_003DzPRk9EFntRplh)
					{
						_0023_003DzTx2aqr8_003D._0023_003DzSaHVljQ_003D = curve.EdgeIndex;
						return;
					}
				}
			}
		}
	}

	private static void _0023_003DzrjUK5hAOpsZB(Point3D _0023_003DzMEwtr_A_003D, Point3D _0023_003DzW7Zyxfc_003D, HiddenLinesView._0023_003DzPWBOFEX1IKDR _0023_003DzTx2aqr8_003D, ICurve[] _0023_003DzRTbTK_0024KwG32W, double _0023_003DzPRk9EFntRplh)
	{
		for (int i = 0; i < _0023_003DzRTbTK_0024KwG32W.Length; i++)
		{
			ICurve[] individualCurves = _0023_003DzRTbTK_0024KwG32W[i].GetIndividualCurves();
			foreach (ICurve curve in individualCurves)
			{
				if ((Point3D.DistanceSquared(_0023_003DzMEwtr_A_003D, curve.StartPoint) < _0023_003DzPRk9EFntRplh && Point3D.DistanceSquared(_0023_003DzW7Zyxfc_003D, curve.EndPoint) < _0023_003DzPRk9EFntRplh) || (Point3D.DistanceSquared(_0023_003DzW7Zyxfc_003D, curve.StartPoint) < _0023_003DzPRk9EFntRplh && Point3D.DistanceSquared(_0023_003DzMEwtr_A_003D, curve.EndPoint) < _0023_003DzPRk9EFntRplh))
				{
					_0023_003DzTx2aqr8_003D._0023_003DzSaHVljQ_003D = curve.EdgeIndex;
					return;
				}
			}
		}
	}

	internal Mesh _0023_003DzUxl6JD_LiM3ksEnQUA_003D_003D(bool _0023_003DzzvgX00ljK1e4)
	{
		List<Mesh> list = new List<Mesh>(_faces.Length);
		_0023_003Dz4IIRRMw3cf6H(_faces, list, Mesh.natureType.Plain, this, _0023_003DzzvgX00ljK1e4, null, linearUnitsType.Unitless, null);
		Face[][] inners = _inners;
		foreach (Face[] _0023_003DzEtn4dIEPKCsi in inners)
		{
			_0023_003Dz4IIRRMw3cf6H(_0023_003DzEtn4dIEPKCsi, list, Mesh.natureType.Plain, this, _0023_003DzzvgX00ljK1e4, null, linearUnitsType.Unitless, null);
		}
		if (list.Count == 0)
		{
			return new Mesh(0, 0, Mesh.natureType.Plain);
		}
		try
		{
			Mesh mesh = list[0];
			for (int j = 1; j < list.Count; j++)
			{
				Mesh mesh2 = list[j];
				if (mesh2 != null && mesh2.Vertices.Length != 0)
				{
					mesh.MergeWith(mesh2, weldNow: false, recomputeEdges: false);
				}
			}
			if (SilhouettesDrawingMode == silhouettesDrawingType.Standard || !_0023_003DzzvgX00ljK1e4)
			{
				mesh.Weld(base.BoxSize.Diagonal * Utility._0023_003DzxhnLabVjXjPg, updateEdges: true);
			}
			return mesh;
		}
		catch (Exception)
		{
			return new Mesh(0, 0, Mesh.natureType.Plain);
		}
	}

	internal FastMesh _0023_003DzaXOXMdWGwLJtDhpErLettuQ_003D(bool _0023_003DzzvgX00ljK1e4)
	{
		List<FastMesh> list = new List<FastMesh>(_faces.Length);
		_0023_003DzBSVCIsxGwI7n52OM5w_003D_003D(_faces, list);
		for (int i = 0; i < _inners.Length; i++)
		{
			_0023_003DzBSVCIsxGwI7n52OM5w_003D_003D(_inners[i], list);
		}
		if (list.Count == 0)
		{
			return new FastMesh(new float[0], new int[0], new float[0]);
		}
		try
		{
			FastMesh fastMesh = (FastMesh)list[0].Clone();
			for (int j = 1; j < list.Count; j++)
			{
				FastMesh fastMesh2 = list[j];
				if (fastMesh2 != null && fastMesh2.PointArray.Length != 0)
				{
					fastMesh.MergeWith(fastMesh2);
				}
			}
			return fastMesh;
		}
		catch (Exception)
		{
			return new FastMesh(new float[0], new int[0], new float[0]);
		}
	}

	private void _0023_003Dz4IIRRMw3cf6H(Face[] _0023_003DzEtn4dIEPKCsi, List<Mesh> _0023_003DzcFIqX7s_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, Entity _0023_003Dzalvl9z8_003D, bool _0023_003DzzvgX00ljK1e4, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, linearUnitsType _0023_003DzYQZzH9suRkRt, Color? _0023_003DzGITKfqI_003D)
	{
		if (!_0023_003DzzvgX00ljK1e4)
		{
			float texLength = 1f;
			if (_0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D != null && !string.IsNullOrEmpty(MaterialName))
			{
				Material material = _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D[MaterialName];
				if (material != null)
				{
					texLength = (float)(Utility.GetLinearUnitsConversionFactor(material.LinearUnits, _0023_003DzYQZzH9suRkRt) * (double)material.TextureLength);
				}
			}
			Face[] array = _0023_003DzEtn4dIEPKCsi;
			foreach (Face face in array)
			{
				_0023_003DzcFIqX7s_003D.Add(face.ConvertToMesh(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, _0023_003Dzalvl9z8_003D, skipEdges: false, texLength, _0023_003DzGITKfqI_003D));
			}
			return;
		}
		switch (SilhouettesDrawingMode)
		{
		case silhouettesDrawingType.Standard:
		{
			Face[] array = _0023_003DzEtn4dIEPKCsi;
			foreach (Face face3 in array)
			{
				_0023_003DzcFIqX7s_003D.Add(face3.ConvertToMesh(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, _0023_003Dzalvl9z8_003D, skipEdges: false, 1f, _0023_003DzGITKfqI_003D));
			}
			break;
		}
		case silhouettesDrawingType.SkipPlanars:
		{
			Face[] array = _0023_003DzEtn4dIEPKCsi;
			foreach (Face face4 in array)
			{
				if (face4.Surface.GetType() != typeof(PlanarSurf))
				{
					_0023_003DzcFIqX7s_003D.Add(face4.ConvertToMesh(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, _0023_003Dzalvl9z8_003D, skipEdges: true, 1f, _0023_003DzGITKfqI_003D));
				}
			}
			break;
		}
		case silhouettesDrawingType.SkipInwardPrimitives:
		{
			Face[] array = _0023_003DzEtn4dIEPKCsi;
			foreach (Face face2 in array)
			{
				if ((face2.Sense || face2.Surface.GetType() == typeof(RevolvedSurf) || face2.Surface.GetType() == typeof(TabulatedSurf) || face2.Surface.GetType() == typeof(NurbsSurf)) && face2.Surface.GetType() != typeof(PlanarSurf))
				{
					_0023_003DzcFIqX7s_003D.Add(face2.ConvertToMesh(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, _0023_003Dzalvl9z8_003D, skipEdges: true, 1f, _0023_003DzGITKfqI_003D));
				}
			}
			break;
		}
		}
	}

	private void _0023_003DzBSVCIsxGwI7n52OM5w_003D_003D(Face[] _0023_003DzEtn4dIEPKCsi, List<FastMesh> _0023_003DzcFIqX7s_003D)
	{
		switch (SilhouettesDrawingMode)
		{
		case silhouettesDrawingType.Standard:
		{
			for (int j = 0; j < _0023_003DzEtn4dIEPKCsi.Length; j++)
			{
				_0023_003DzcFIqX7s_003D.Add(_0023_003DzEtn4dIEPKCsi[j].Tessellation);
			}
			break;
		}
		case silhouettesDrawingType.SkipPlanars:
		{
			for (int k = 0; k < _0023_003DzEtn4dIEPKCsi.Length; k++)
			{
				if (_0023_003DzEtn4dIEPKCsi[k].Surface.GetType() != typeof(PlanarSurf))
				{
					_0023_003DzcFIqX7s_003D.Add(_0023_003DzEtn4dIEPKCsi[k].Tessellation);
				}
			}
			break;
		}
		case silhouettesDrawingType.SkipInwardPrimitives:
		{
			for (int i = 0; i < _0023_003DzEtn4dIEPKCsi.Length; i++)
			{
				Face face = _0023_003DzEtn4dIEPKCsi[i];
				if (face.Surface.GetType() != typeof(PlanarSurf) && (face.Sense || face.Surface.GetType() == typeof(RevolvedSurf) || face.Surface.GetType() == typeof(TabulatedSurf) || face.Surface.GetType() == typeof(NurbsSurf)))
				{
					_0023_003DzcFIqX7s_003D.Add(_0023_003DzEtn4dIEPKCsi[i].Tessellation);
				}
			}
			break;
		}
		}
	}

	internal override void _0023_003Dz_0024_0024rGbexgW9YV(IList<_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D> _0023_003Dza_SABTbwi5q2, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzyzK8swU_003D)
	{
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D obj = _0023_003DzuAMveDQA6vvk()[0];
		obj._0023_003DzqkDCo38_003D(ref _0023_003DzyzK8swU_003D, LayerName);
		obj._0023_003DzsxCTpik_003D(ref _0023_003DzyzK8swU_003D);
		obj._0023_003Dzu9FtIMXgxSrQ(_0023_003Dza_SABTbwi5q2);
	}

	internal override _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] _0023_003DzuAMveDQA6vvk()
	{
		_0023_003DzQsJMTitxsWEIpMMKp8zjTAk_003D(out var _0023_003DzkEYxO1SuR1Kw, out var _0023_003DzTx2aqr8_003D, out var _0023_003DzTbKSx1UHykdt);
		return new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[1]
		{
			new _0023_003DzTsGSj5r0zhbKoPjk04Ctgt5hXkbDo26vk_YJJ_kCYeB4dIKQQQ_003D_003D(_0023_003DzkEYxO1SuR1Kw, _0023_003DzTx2aqr8_003D, _0023_003DzTbKSx1UHykdt, ColorMethod == colorMethodType.byEntity, LayerName, Color)
		};
	}

	private void _0023_003DzQsJMTitxsWEIpMMKp8zjTAk_003D(out _0023_003DzzqQMnVz1u4B7Ao5VuLHfFnIEzCMKuUZ_0024gQ_003D_003D _0023_003DzkEYxO1SuR1Kw, out _0023_003Dzg9kdMKEMX5KRt9SgqKcmIBs4bF4zPzCU3g_003D_003D _0023_003DzTx2aqr8_003D, out _0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D[][] _0023_003DzTbKSx1UHykdt)
	{
		_0023_003DzkEYxO1SuR1Kw = new _0023_003DzzqQMnVz1u4B7Ao5VuLHfFnIEzCMKuUZ_0024gQ_003D_003D(Vertices, LayerName);
		_0023_003DzTx2aqr8_003D = _0023_003Dz4eh_0024BWqT9JfS();
		_0023_003DzTbKSx1UHykdt = _0023_003DzDLILYLuxL2Of3TBY9Q_003D_003D();
	}

	private _0023_003Dzg9kdMKEMX5KRt9SgqKcmIBs4bF4zPzCU3g_003D_003D _0023_003Dz4eh_0024BWqT9JfS()
	{
		_0023_003Dz38od8vOHDENlXGsAjsoZ8Zt6_0024YR8MrUxug_003D_003D[] array = new _0023_003Dz38od8vOHDENlXGsAjsoZ8Zt6_0024YR8MrUxug_003D_003D[Edges.Length];
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[] array2 = new _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D[Edges.Length];
		for (int i = 0; i < Edges.Length; i++)
		{
			Edge edge = Edges[i];
			array[i] = new _0023_003Dz38od8vOHDENlXGsAjsoZ8Zt6_0024YR8MrUxug_003D_003D
			{
				_0023_003DzxyO_0024eRmpEgLo = 0,
				_0023_003DzTwQpWzBy3CGU = edge.EndPointIndex + 1,
				_0023_003Dz0mpLUaQHQBW0 = edge.StartPointIndex + 1
			};
			array2[i] = ((Entity)edge.Curve)._0023_003DzuAMveDQA6vvk()[0];
		}
		return new _0023_003Dzg9kdMKEMX5KRt9SgqKcmIBs4bF4zPzCU3g_003D_003D(array, array2, LayerName);
	}

	private _0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D[][] _0023_003DzDLILYLuxL2Of3TBY9Q_003D_003D()
	{
		_0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D[][] array = new _0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D[Inners.Length + 1][];
		array[0] = _0023_003DzFg5lX6PR9HVxwgFP_0024w_003D_003D(Faces);
		for (int i = 0; i < Inners.Length; i++)
		{
			array[i + 1] = _0023_003DzFg5lX6PR9HVxwgFP_0024w_003D_003D(Inners[i]);
		}
		return array;
	}

	private _0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D[] _0023_003DzFg5lX6PR9HVxwgFP_0024w_003D_003D(Face[] _0023_003DzpPOEJqcAh7Lr)
	{
		int num = _0023_003DzpPOEJqcAh7Lr.Length;
		_0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D[] array = new _0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D[num];
		for (int i = 0; i < num; i++)
		{
			Face face = _0023_003DzpPOEJqcAh7Lr[i];
			_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DzF7GfYSI_003D = _0023_003DzsVY_0024qB7eAqkG(face);
			_0023_003DzEKmPHSrtZpXBuvnSgWZRaP_j0pyFE9wA6w_003D_003D[] array2 = new _0023_003DzEKmPHSrtZpXBuvnSgWZRaP_j0pyFE9wA6w_003D_003D[face.Loops.Length];
			for (int j = 0; j < face.Loops.Length; j++)
			{
				Loop loop = face.Loops[j];
				_0023_003DzKYRxuYwyt6i6S31w4RfQLz_sEGsBO92VbTkQi6E_003D[] array3 = new _0023_003DzKYRxuYwyt6i6S31w4RfQLz_sEGsBO92VbTkQi6E_003D[loop.Segments.Length];
				for (int k = 0; k < loop.Segments.Length; k++)
				{
					OrientedEdge orientedEdge = loop.Segments[k];
					array3[k] = new _0023_003DzKYRxuYwyt6i6S31w4RfQLz_sEGsBO92VbTkQi6E_003D(0, 0, orientedEdge.CurveIndex + 1, orientedEdge.Sense);
				}
				array2[j] = new _0023_003DzEKmPHSrtZpXBuvnSgWZRaP_j0pyFE9wA6w_003D_003D(array3, loop.Sense, LayerName);
			}
			array[i] = new _0023_003Dzy4DM0pk_0024TAdIhuL2pH9FIzCDKJadlZSRDQ_003D_003D(_0023_003DzF7GfYSI_003D, array2, face.Sense, LayerName, face.Color.HasValue ? face.Color.Value : Color.Empty);
		}
		return array;
	}

	private _0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D _0023_003DzsVY_0024qB7eAqkG(Face _0023_003DzHEpjcdg2hk9U)
	{
		AnalyticSurf surface = _0023_003DzHEpjcdg2hk9U.Surface;
		_0023_003DziKaAvIY2f9OEJZiA_0024YOyTugyN_0024viO64E5w_003D_003D result = null;
		if (surface is SphericalSurf sphericalSurf)
		{
			result = new _0023_003DzzTCaZbrp3S0YNBiuIm4zwWRKyXGhqoSnJfApr9Zao2Py(sphericalSurf.Plane, sphericalSurf.Radius, LayerName);
		}
		else if (surface is ToroidalSurf toroidalSurf)
		{
			result = new _0023_003DzgRGydxI0js4H2FiOzNOIWEvotJMyjEeDqqICnCrzpRPU(toroidalSurf.Plane, toroidalSurf.MajorRadius, toroidalSurf.MinorRadius, LayerName);
		}
		else if (surface is ConicalSurf conicalSurf)
		{
			result = new _0023_003DzvRv2q7rL_0024ZnoPvAjrfwD6WnhKv4_00240RnC93FJKB2l87_0024PrYvxiw_003D_003D(conicalSurf.Plane, conicalSurf.Radius, conicalSurf.HalfAngle, LayerName);
		}
		else if (surface is CylindricalSurf cylindricalSurf)
		{
			result = new _0023_003DzfDpAK59ydJjjoyL2Yh_q4HLkc9bx82zcUjw_9FsJK2JXGYdzuKEWaoI_003D(cylindricalSurf.Plane, cylindricalSurf.Radius, LayerName);
		}
		else if (surface is TabulatedSurf tabulatedSurf)
		{
			result = new _0023_003DzZXHZ8r_AKGbCsLnm7EUe1w_00244EG0i1nNAEdrGUvzdztgO(((Entity)tabulatedSurf.Directrix)._0023_003DzuAMveDQA6vvk()[0], tabulatedSurf.Directrix.StartPoint + tabulatedSurf.Generatrix, LayerName);
		}
		else if (surface is RevolvedSurf revolvedSurf)
		{
			result = new _0023_003DzYkQVv2Lb0egyGZnzeO8ydkyFt0lDEhHA4uvG2TxpWX6vfM3gdg_003D_003D(new _0023_003DzCDSdDaukKIfQIKuoRosZ3NAKyMQ1WGSxOA_003D_003D(revolvedSurf.Plane.Origin, revolvedSurf.Plane.Origin + revolvedSurf.Plane.AxisZ, _0023_003Dz_002418Nebs_KL8i: false, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963495), Color.Black, _0023_003Dz_KjZG5vEM9v9: false), ((Entity)revolvedSurf.Generatrix)._0023_003DzuAMveDQA6vvk()[0], LayerName);
		}
		else if (surface is PlanarSurf planarSurf)
		{
			result = new _0023_003Dz33gUjy3ocKE8GMVaXVlNH3IyyZmuwan0aTQv6YQ_003D(planarSurf.Plane, LayerName);
		}
		else if (surface is NurbsSurf nurbsSurf)
		{
			result = new _0023_003Dz_ZR_60g8KTZpV15NG_0024gJ1cZ3Q9yL1UXPtzY9x8s_003D(nurbsSurf.DegreeU, nurbsSurf.KnotVectorU, nurbsSurf.DegreeV, nurbsSurf.KnotVectorV, nurbsSurf.ControlPoints, LayerName);
		}
		return result;
	}

	internal void _0023_003Dz3jeSWxABmWS4(FastMesh[] _0023_003DzEtn4dIEPKCsi)
	{
		if (_0023_003DzEtn4dIEPKCsi != null)
		{
			for (int i = 0; i < _0023_003DzEtn4dIEPKCsi.Length; i++)
			{
				_0023_003DzEtn4dIEPKCsi[i].FlipNormal();
			}
		}
	}

	protected internal override void DrawNormals(DrawParams data)
	{
		double normalLength = GetNormalLength();
		_0023_003DzDNtufezqjTzL(_faces, data, normalLength);
		Face[][] inners = _inners;
		for (int i = 0; i < inners.Length; i++)
		{
			_0023_003DzDNtufezqjTzL(inners[i], data, normalLength);
		}
	}

	private static void _0023_003DzDNtufezqjTzL(Face[] _0023_003DzEtn4dIEPKCsi, DrawParams _0023_003DzELu0Pss_003D, double _0023_003Dz736ekIs_003D)
	{
		for (int i = 0; i < _0023_003DzEtn4dIEPKCsi.Length; i++)
		{
			_0023_003DzEtn4dIEPKCsi[i].Tessellation._0023_003Dz7OF2rTbBn_00246AbUdMn_T8bDg_003D(_0023_003DzELu0Pss_003D, _0023_003Dz736ekIs_003D);
		}
	}

	public Mesh[] GetTessellation()
	{
		List<Mesh> list = new List<Mesh>();
		list.AddRange(_0023_003DzleKHvj4gK0eE(_faces, Mesh.natureType.Smooth));
		Face[][] inners = _inners;
		foreach (Face[] _0023_003DzEtn4dIEPKCsi in inners)
		{
			list.AddRange(_0023_003DzleKHvj4gK0eE(_0023_003DzEtn4dIEPKCsi, Mesh.natureType.Smooth));
		}
		return list.ToArray();
	}

	private static Mesh[] _0023_003DzleKHvj4gK0eE(Face[] _0023_003DzEtn4dIEPKCsi, Mesh.natureType _0023_003DzL3kjwgWK1Hcy)
	{
		Mesh[] array = new Mesh[_0023_003DzEtn4dIEPKCsi.Length];
		for (int i = 0; i < _0023_003DzEtn4dIEPKCsi.Length; i++)
		{
			array[i] = _0023_003DzEtn4dIEPKCsi[i].Tessellation.ConvertToMesh(0.0, 0.0, _0023_003DzL3kjwgWK1Hcy, weld: false);
		}
		return array;
	}

	protected override bool EvaluateIntersectEdges(FrustumParams data)
	{
		return data.DisplayMode == displayType.Wireframe;
	}

	protected override bool EvaluateIntersectTriangles(FrustumParams data)
	{
		return data.DisplayMode != displayType.Wireframe;
	}

	internal override bool IntersectEdgeOrIsoline(FrustumParams _0023_003DzELu0Pss_003D)
	{
		if (!EvaluateIntersectEdges(_0023_003DzELu0Pss_003D))
		{
			return false;
		}
		_0023_003DzELu0Pss_003D.ForceSkipLeafAdd = true;
		for (int i = 0; i < Edges.Length; i++)
		{
			if (Surface._0023_003Dz8Y5VBifFYChxexbDRySI1v0_003D(_0023_003DzELu0Pss_003D.Frustum, _0023_003DzELu0Pss_003D.Transformation, (Entity)Edges[i].Curve))
			{
				_0023_003DzELu0Pss_003D.ForceSkipLeafAdd = false;
				AddSelectedItemLeaf(_0023_003DzELu0Pss_003D);
				return true;
			}
		}
		_0023_003DzELu0Pss_003D.ForceSkipLeafAdd = false;
		return false;
	}

	internal override bool IntersectEdgeOrIsolineScreenPolygon(ScreenPolygonParams _0023_003DzELu0Pss_003D)
	{
		if (!EvaluateIntersectEdges(_0023_003DzELu0Pss_003D))
		{
			return false;
		}
		_0023_003DzELu0Pss_003D.ForceSkipLeafAdd = true;
		if (_0023_003DzELu0Pss_003D.Transformation == null)
		{
			for (int i = 0; i < Edges.Length; i++)
			{
				Entity entity = (Entity)Edges[i].Curve;
				for (int j = 0; j < entity.Vertices.Length - 1; j++)
				{
					if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(entity.Vertices[j], entity.Vertices[j + 1], _0023_003DzELu0Pss_003D))
					{
						_0023_003DzELu0Pss_003D.ForceSkipLeafAdd = false;
						AddSelectedItemLeaf(_0023_003DzELu0Pss_003D);
						return true;
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < Edges.Length; k++)
			{
				Entity entity2 = (Entity)Edges[k].Curve;
				for (int l = 0; l < entity2.Vertices.Length - 1; l++)
				{
					if (Utility._0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(_0023_003DzELu0Pss_003D.Transformation * entity2.Vertices[l], _0023_003DzELu0Pss_003D.Transformation * entity2.Vertices[l + 1], _0023_003DzELu0Pss_003D))
					{
						_0023_003DzELu0Pss_003D.ForceSkipLeafAdd = false;
						AddSelectedItemLeaf(_0023_003DzELu0Pss_003D);
						return true;
					}
				}
			}
		}
		_0023_003DzELu0Pss_003D.ForceSkipLeafAdd = false;
		return false;
	}

	protected internal override bool InsideOrCrossingFrustum(FrustumParams data)
	{
		if (!EvaluateIntersectTriangles(data))
		{
			return false;
		}
		data.ForceSkipLeafAdd = true;
		Face[] faces = _faces;
		for (int i = 0; i < faces.Length; i++)
		{
			if (faces[i].Tessellation.InsideOrCrossingFrustum(data))
			{
				data.ForceSkipLeafAdd = false;
				AddSelectedItemLeaf(data);
				return true;
			}
		}
		data.ForceSkipLeafAdd = false;
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		if (!EvaluateIntersectTriangles(data))
		{
			return false;
		}
		data.ForceSkipLeafAdd = true;
		Face[] faces = _faces;
		for (int i = 0; i < faces.Length; i++)
		{
			if (faces[i].Tessellation.InsideOrCrossingScreenPolygon(data))
			{
				data.ForceSkipLeafAdd = false;
				AddSelectedItemLeaf(data);
				return true;
			}
		}
		data.ForceSkipLeafAdd = false;
		return false;
	}

	private bool _0023_003DzzDSpDS0BYbqDgLNEvo5uRbqQcEelwDjLvzoq87g_003D(_0023_003DzhSGg_0024oKL6aEYn9EjCQ_003D_003D _0023_003Dz3g87Qqzdsco0Ou9bMQ_003D_003D, FrustumParams _0023_003DzELu0Pss_003D)
	{
		_0023_003DzELu0Pss_003D.ForceSkipLeafAdd = true;
		Face[] faces = _faces;
		foreach (Face _0023_003DzHEpjcdg2hk9U in faces)
		{
			if (!_0023_003Dz3g87Qqzdsco0Ou9bMQ_003D_003D(_0023_003DzHEpjcdg2hk9U))
			{
				_0023_003DzELu0Pss_003D.ForceSkipLeafAdd = false;
				return false;
			}
		}
		_0023_003DzELu0Pss_003D.ForceSkipLeafAdd = false;
		AddSelectedItemLeaf(_0023_003DzELu0Pss_003D);
		return true;
	}

	protected internal override bool AllVerticesInFrustum(FrustumParams data)
	{
		_0023_003Dzk3LI7qGozxcdguRRMifTlx0_003D _0023_003Dzk3LI7qGozxcdguRRMifTlx0_003D2 = new _0023_003Dzk3LI7qGozxcdguRRMifTlx0_003D();
		_0023_003Dzk3LI7qGozxcdguRRMifTlx0_003D2._0023_003DzELu0Pss_003D = data;
		return _0023_003DzzDSpDS0BYbqDgLNEvo5uRbqQcEelwDjLvzoq87g_003D(_0023_003Dzk3LI7qGozxcdguRRMifTlx0_003D2._0023_003DzAIgslkgO3MG3jEfTN3tmG3fOFvN6WcT0ShB7pK4_003D, _0023_003Dzk3LI7qGozxcdguRRMifTlx0_003D2._0023_003DzELu0Pss_003D);
	}

	protected internal override bool AllVerticesInScreenPolygon(ScreenPolygonParams data)
	{
		_0023_003Dzq05F0TOsYEIyvZGPMwuwPO4_003D CS_0024_003C_003E8__locals3 = new _0023_003Dzq05F0TOsYEIyvZGPMwuwPO4_003D();
		CS_0024_003C_003E8__locals3._0023_003DzELu0Pss_003D = data;
		return _0023_003DzzDSpDS0BYbqDgLNEvo5uRbqQcEelwDjLvzoq87g_003D((Face _0023_003DzhidJeNw_003D) => _0023_003DzhidJeNw_003D.Tessellation.AllVerticesInScreenPolygon(CS_0024_003C_003E8__locals3._0023_003DzELu0Pss_003D), CS_0024_003C_003E8__locals3._0023_003DzELu0Pss_003D);
	}

	protected internal override bool ThroughTriangle(FrustumParams data)
	{
		data.ForceSkipLeafAdd = true;
		Face[] faces = _faces;
		for (int i = 0; i < faces.Length; i++)
		{
			if (faces[i].Tessellation.ThroughTriangle(data))
			{
				data.ForceSkipLeafAdd = false;
				AddSelectedItemLeaf(data);
				return true;
			}
		}
		data.ForceSkipLeafAdd = false;
		return false;
	}

	protected internal override bool ThroughTriangleScreenPolygon(ScreenPolygonParams data)
	{
		data.ForceSkipLeafAdd = true;
		Face[] faces = _faces;
		for (int i = 0; i < faces.Length; i++)
		{
			if (faces[i].Tessellation.ThroughTriangleScreenPolygon(data))
			{
				data.ForceSkipLeafAdd = false;
				AddSelectedItemLeaf(data);
				return true;
			}
		}
		data.ForceSkipLeafAdd = false;
		return false;
	}

	public IList<HitTriangle> FindClosestTriangle(Transformation transf, Segment3D seg)
	{
		SortedList<double, HitTriangle> sortedList = new SortedList<double, HitTriangle>();
		_0023_003DzAimTvH_0024dxpdM1a3fNA_003D_003D(_faces, transf, seg, 0, sortedList);
		for (int i = 0; i < _inners.Length; i++)
		{
			_0023_003DzAimTvH_0024dxpdM1a3fNA_003D_003D(_inners[i], transf, seg, i + 1, sortedList);
		}
		return sortedList.Values;
	}

	private void _0023_003DzAimTvH_0024dxpdM1a3fNA_003D_003D(Face[] _0023_003DzEtn4dIEPKCsi, Transformation _0023_003Dz9ZUzIX4xmsyA, Segment3D _0023_003DzFDJdA7A_003D, int _0023_003DzRLCcpW4_003D, SortedList<double, HitTriangle> _0023_003DzJMMhfoqq1zLk)
	{
		for (int i = 0; i < _0023_003DzEtn4dIEPKCsi.Length; i++)
		{
			foreach (KeyValuePair<double, HitTriangle> item in Utility.FindClosestTriangle(_0023_003Dz9ZUzIX4xmsyA, _0023_003DzFDJdA7A_003D, _0023_003DzEtn4dIEPKCsi[i].Tessellation.GetPoints(), _0023_003DzEtn4dIEPKCsi[i].Tessellation.GetTriangles()))
			{
				_0023_003DzJMMhfoqq1zLk[item.Key] = new HitTriangle(item.Value.IntersectionPoint, item.Value.TriangleIndex, i, _0023_003DzRLCcpW4_003D);
			}
		}
	}

	internal override void FindClosestVertices(FindClosestVerticesParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
	{
		_0023_003DzhSj4NWLzpllgkRXNhvst5vw_003D(_0023_003DzELu0Pss_003D, _faces, 0, _0023_003Dz7xzxLVk_003D);
		for (int i = 0; i < _inners.Length; i++)
		{
			_0023_003DzhSj4NWLzpllgkRXNhvst5vw_003D(_0023_003DzELu0Pss_003D, _inners[i], i + 1, _0023_003Dz7xzxLVk_003D);
		}
	}

	internal override bool FindClosestVertex(FindClosestVertexParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
	{
		bool flag = _0023_003Dz46TdCSv4NiVERbommQ_003D_003D(_0023_003DzELu0Pss_003D, _faces, 0, _0023_003Dz7xzxLVk_003D);
		for (int i = 0; i < _inners.Length; i++)
		{
			flag |= _0023_003Dz46TdCSv4NiVERbommQ_003D_003D(_0023_003DzELu0Pss_003D, _inners[i], i + 1, _0023_003Dz7xzxLVk_003D);
		}
		return flag;
	}

	private static void _0023_003DzhSj4NWLzpllgkRXNhvst5vw_003D(FindClosestVerticesParams _0023_003DzELu0Pss_003D, Face[] _0023_003DzEtn4dIEPKCsi, int _0023_003DzRLCcpW4_003D, int _0023_003Dz7xzxLVk_003D)
	{
		for (int i = 0; i < _0023_003DzEtn4dIEPKCsi.Length; i++)
		{
			FastMesh tessellation = _0023_003DzEtn4dIEPKCsi[i].Tessellation;
			int count = _0023_003DzELu0Pss_003D.ClosestVertices.Count;
			tessellation.FindClosestVertices(_0023_003DzELu0Pss_003D, _0023_003Dz7xzxLVk_003D);
			for (int j = count; j < _0023_003DzELu0Pss_003D.ClosestVertices.Count; j++)
			{
				HitVertex hitVertex = _0023_003DzELu0Pss_003D.ClosestVertices[j];
				hitVertex.FaceIndex = i;
				hitVertex.ShellOrElementIndex = _0023_003DzRLCcpW4_003D;
			}
		}
	}

	private static bool _0023_003Dz46TdCSv4NiVERbommQ_003D_003D(FindClosestVertexParams _0023_003DzELu0Pss_003D, Face[] _0023_003DzEtn4dIEPKCsi, int _0023_003DzRLCcpW4_003D, int _0023_003Dz7xzxLVk_003D)
	{
		bool result = false;
		for (int i = 0; i < _0023_003DzEtn4dIEPKCsi.Length; i++)
		{
			if (_0023_003DzEtn4dIEPKCsi[i].Tessellation.FindClosestVertex(_0023_003DzELu0Pss_003D, _0023_003Dz7xzxLVk_003D))
			{
				_0023_003DzELu0Pss_003D.ClosestVertex.FaceIndex = i;
				_0023_003DzELu0Pss_003D.ClosestVertex.ShellOrElementIndex = _0023_003DzRLCcpW4_003D;
				result = true;
			}
		}
		return result;
	}

	private List<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D> _0023_003DzA8XV6BjEzDp4zQbL1w_003D_003D(Face[] _0023_003DzEtn4dIEPKCsi, _0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D _0023_003DzrtuC07k_003D, ref int _0023_003Dzfsn580w_003D)
	{
		List<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D> list = new List<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D>();
		foreach (Face face in _0023_003DzEtn4dIEPKCsi)
		{
			_0023_003Dz7MB4rUSi95DNhr7phw_003D_003D[] array = new _0023_003Dz7MB4rUSi95DNhr7phw_003D_003D[face.Loops.Length];
			bool[] array2 = new bool[face.Loops.Length];
			for (int j = 0; j < face.Loops.Length; j++)
			{
				Loop loop = face.Loops[j];
				int[] array3 = new int[loop.Segments.Length];
				for (int k = 0; k < loop.Segments.Length; k++)
				{
					OrientedEdge orientedEdge = loop.Segments[k];
					_0023_003DzrtuC07k_003D._0023_003DzJCFVuqLIIlHMRWB1mA_003D_003D.Add(new _0023_003DzYWy1thn0_ZNC89PCrYX2ANq_jtki(_0023_003Dzfsn580w_003D, orientedEdge.CurveIndex, orientedEdge.Sense));
					array3[k] = _0023_003Dzfsn580w_003D;
					_0023_003Dzfsn580w_003D++;
				}
				array[j] = new _0023_003Dz7MB4rUSi95DNhr7phw_003D_003D(array3);
				array2[j] = loop.Sense;
			}
			_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 = _0023_003DzcvgxhwltnVm9(face.Surface, null, face.Sense);
			_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzbykJA36oCfUxYTgeaw_003D_003D3 = new _0023_003DzbykJA36oCfUxYTgeaw_003D_003D(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzyXmKbtw_003D, _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003Dz3teLb_0024wWvlUs(), array, array2);
			if (face.Color.HasValue)
			{
				_0023_003DzbykJA36oCfUxYTgeaw_003D_003D3._0023_003Dzwtld1NM_003D = Utility.ColorToDoubleArray(face.Color.Value);
			}
			if (face.FaceData != null && face.FaceData is string _0023_003Dz4wZe_0024Xg_003D)
			{
				_0023_003DzbykJA36oCfUxYTgeaw_003D_003D3._0023_003Dzh5UrnhhPGlo6 = WriteSTEP._0023_003DzS0Pr1Qk_003D(_0023_003Dz4wZe_0024Xg_003D);
			}
			list.Add(_0023_003DzbykJA36oCfUxYTgeaw_003D_003D3);
		}
		return list;
	}

	private static _0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzcvgxhwltnVm9(AnalyticSurf _0023_003Dz_0024KKopL9T7nzT, ICurve[] _0023_003DzRTbTK_0024KwG32W, bool _0023_003Dzx3pYiE0_003D)
	{
		_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 = new _0023_003DzbykJA36oCfUxYTgeaw_003D_003D();
		if (!(_0023_003Dz_0024KKopL9T7nzT is NurbsSurf nurbsSurf))
		{
			if (!(_0023_003Dz_0024KKopL9T7nzT is ConicalSurf { Plane: var plane } conicalSurf))
			{
				if (!(_0023_003Dz_0024KKopL9T7nzT is SphericalSurf { Plane: var plane2 } sphericalSurf))
				{
					if (!(_0023_003Dz_0024KKopL9T7nzT is CylindricalSurf { Plane: var plane3 } cylindricalSurf))
					{
						if (!(_0023_003Dz_0024KKopL9T7nzT is RevolvedSurf revolvedSurf))
						{
							if (!(_0023_003Dz_0024KKopL9T7nzT is ToroidalSurf toroidalSurf))
							{
								if (!(_0023_003Dz_0024KKopL9T7nzT is PlanarSurf { Plane: var plane4 }))
								{
									if (!(_0023_003Dz_0024KKopL9T7nzT is TabulatedSurf tabulatedSurf))
									{
										throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302963477));
									}
									_0023_003DzAesEZlpt4n5DGdrqIA_003D_003D _0023_003DzcX2HU0yGwowv = TrimCurve._0023_003DzDj2isiZZZIae(tabulatedSurf.Directrix);
									double _0023_003DzZNubB_0024cRfbTUejOA7Q_003D_003D = tabulatedSurf.Generatrix.Length;
									Vector3D obj = (Vector3D)tabulatedSurf.Generatrix.Clone();
									obj.Normalize();
									double[] _0023_003DzbIIdMFuNXKsO = obj.ToArray();
									_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003Dz0b4GnlLoqtdeU075oZx2gvc_003D(ref _0023_003DzcX2HU0yGwowv, ref _0023_003DzZNubB_0024cRfbTUejOA7Q_003D_003D, ref _0023_003DzbIIdMFuNXKsO);
									_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzwELGnAxTIoqvkMlamQ_003D_003D(_0023_003Dzx3pYiE0_003D);
									Surface._0023_003DzSVoxUgsmFpRu(_0023_003DzRTbTK_0024KwG32W, _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2);
								}
								else
								{
									_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DznMfYYu4y2pvS(plane4.Origin.ToArray(), plane4.AxisZ.ToArray(), plane4.AxisX.ToArray());
									_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzwELGnAxTIoqvkMlamQ_003D_003D(_0023_003Dzx3pYiE0_003D);
									Surface._0023_003DzSVoxUgsmFpRu(_0023_003DzRTbTK_0024KwG32W, _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2);
								}
							}
							else
							{
								torusType num = ToroidalSurface._0023_003DzrGbSgLEhkB_K(toroidalSurf.MajorRadius, toroidalSurf.MinorRadius);
								Plane plane5 = toroidalSurf.Plane;
								if (num == torusType.Lemon)
								{
									_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzYaoXrwAviA_0024eoI7FlBdFIcK0JTAx(plane5.Origin.ToArray(), toroidalSurf.MajorRadius, toroidalSurf.MinorRadius, plane5.AxisZ.ToArray(), plane5.AxisX.ToArray(), _0023_003DzlZRyGoqAErWyKrgbFA_003D_003D: true);
								}
								else
								{
									_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzIcrAJ2l9jc2a(plane5.Origin.ToArray(), toroidalSurf.MajorRadius, toroidalSurf.MinorRadius, plane5.AxisZ.ToArray(), plane5.AxisX.ToArray());
								}
								_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzwELGnAxTIoqvkMlamQ_003D_003D(_0023_003Dzx3pYiE0_003D);
								Surface._0023_003DzSVoxUgsmFpRu(_0023_003DzRTbTK_0024KwG32W, _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2);
							}
						}
						else
						{
							_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 = _0023_003DzWKd_yLQl3W6gP0LcmA_003D_003D(revolvedSurf.Plane, revolvedSurf.Generatrix, _0023_003DzRTbTK_0024KwG32W, _0023_003Dzx3pYiE0_003D);
						}
					}
					else
					{
						_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzBeOrJbvuvLXFcwoI0g_003D_003D(plane3.Origin.ToArray(), plane3.AxisZ.ToArray(), plane3.AxisX.ToArray(), cylindricalSurf.Radius);
						_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzwELGnAxTIoqvkMlamQ_003D_003D(_0023_003Dzx3pYiE0_003D);
						Surface._0023_003DzSVoxUgsmFpRu(_0023_003DzRTbTK_0024KwG32W, _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2);
					}
				}
				else
				{
					_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzgwwqFTCoElfW_z2jYg_003D_003D(plane2.Origin.ToArray(), sphericalSurf.Radius, plane2.AxisZ.ToArray(), plane2.AxisX.ToArray());
					_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzwELGnAxTIoqvkMlamQ_003D_003D(_0023_003Dzx3pYiE0_003D);
					Surface._0023_003DzSVoxUgsmFpRu(_0023_003DzRTbTK_0024KwG32W, _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2);
				}
			}
			else if (Math.PI / 2.0 - Math.Abs(conicalSurf.HalfAngle) < Utility._0023_003DzxhnLabVjXjPg && _0023_003DzRTbTK_0024KwG32W != null)
			{
				conicalSurf._0023_003Dz6VRTLeo_003D(_0023_003DzRTbTK_0024KwG32W, out var _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D);
				ICurve _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D = _0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D.IsocurveV(_0023_003Dzmlh_0024D7evTZ9rQf2_Ag_003D_003D.DomainU.Low);
				_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 = _0023_003DzWKd_yLQl3W6gP0LcmA_003D_003D(plane, _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D, _0023_003DzRTbTK_0024KwG32W, _0023_003Dzx3pYiE0_003D);
			}
			else
			{
				double num2 = conicalSurf.HalfAngle;
				Vector3D vector3D = (Vector3D)plane.AxisZ.Clone();
				if (num2 < 0.0)
				{
					num2 = Math.PI + num2;
					_0023_003Dzx3pYiE0_003D = !_0023_003Dzx3pYiE0_003D;
				}
				if (num2 > Math.PI / 2.0)
				{
					num2 = Math.PI - num2;
					vector3D.Negate();
					_0023_003Dzx3pYiE0_003D = !_0023_003Dzx3pYiE0_003D;
				}
				_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzEoXZTe17AylQ(plane.Origin.ToArray(), vector3D.ToArray(), plane.AxisX.ToArray(), conicalSurf.Radius, num2);
				_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzwELGnAxTIoqvkMlamQ_003D_003D(_0023_003Dzx3pYiE0_003D);
				Surface._0023_003DzSVoxUgsmFpRu(_0023_003DzRTbTK_0024KwG32W, _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2);
			}
		}
		else
		{
			List<List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>> list = new List<List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>>();
			int length = nurbsSurf.ControlPoints.GetLength(0);
			int length2 = nurbsSurf.ControlPoints.GetLength(1);
			for (int i = 0; i < length; i++)
			{
				List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D> list2 = new List<_0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D>();
				for (int j = 0; j < length2; j++)
				{
					Point4D point4D = nurbsSurf.ControlPoints[i, j];
					list2.Add(new _0023_003DzIAnkpAwgS0aL23_0024iNA_003D_003D(point4D.X / point4D.W, point4D.Y / point4D.W, point4D.Z / point4D.W, point4D.W));
				}
				list.Add(list2);
			}
			_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzzHNNahA99aTG(nurbsSurf.DegreeU, nurbsSurf.DegreeV, new List<double>(nurbsSurf.KnotVectorU), new List<double>(nurbsSurf.KnotVectorV), list);
			_0023_003DzbykJA36oCfUxYTgeaw_003D_003D2._0023_003DzwELGnAxTIoqvkMlamQ_003D_003D(_0023_003Dzx3pYiE0_003D);
			Surface._0023_003DzSVoxUgsmFpRu(_0023_003DzRTbTK_0024KwG32W, _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2);
		}
		return _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2;
	}

	private static _0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzWKd_yLQl3W6gP0LcmA_003D_003D(Plane _0023_003Dzpyw2kZk_003D, ICurve _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D, ICurve[] _0023_003DzRTbTK_0024KwG32W, bool _0023_003Dzx3pYiE0_003D)
	{
		_0023_003DzbykJA36oCfUxYTgeaw_003D_003D _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2 = RevolvedSurface._0023_003DzTBgYs4ruey8A8uteS_AA__00248_003D(_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D, _0023_003Dzpyw2kZk_003D.Origin, _0023_003Dzpyw2kZk_003D.AxisZ, _0023_003Dzx3pYiE0_003D);
		Surface._0023_003DzSVoxUgsmFpRu(_0023_003DzRTbTK_0024KwG32W, _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2);
		return _0023_003DzbykJA36oCfUxYTgeaw_003D_003D2;
	}

	public void Smash(IWorkspace ws, int layerIndex)
	{
		Smash(ws.Document, layerIndex);
	}

	public void Smash(Document document, int layerIndex)
	{
		Smash(document, document.Layers[layerIndex].Name);
	}

	public void Smash(IWorkspace ws, string layerName = "default")
	{
		Smash(ws.Document, layerName);
	}

	public void Smash(Document document, string layerName = "default")
	{
		double num = 0.0;
		Rebuild(0.0, soft: true);
		_0023_003DzQCWJbpjMGLxZWfwMCQ_003D_003D(out var _0023_003DzDPcjoBJLcqli, out var _0023_003Dz_0024N_0024yKptW9BoC, _0023_003Dz7cP1pZCb1hQy: true);
		double diagonal = new Size3D(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC).Diagonal;
		for (int i = 0; i < Faces.Length; i++)
		{
			Face face = Faces[i];
			for (int j = 0; j < face.Parametric.Length; j++)
			{
				Surface.Reparametrize(face.Parametric[j], out var _, out var _, out var reparametrized);
				Region region = (Region)reparametrized.Trimming.Clone();
				region.Regen(0.1);
				Vector3D asVector = region.BoxMin.AsVector;
				region.Translate(-1.0 * asVector);
				region.Translate(num + diagonal, 0.0);
				document.Entities.Add(region, layerName, Color.FromArgb(150, face.Sense ? Color.OrangeRed : Color.LimeGreen));
				double num2 = Math.Min(region.BoxSize.X, region.BoxSize.Y);
				Text text = new Text(Plane.XY, Point3D.MidPoint(region.BoxMax, region.BoxMin), i.ToString(), num2 / 10.0, Text.alignmentType.MiddleCenter);
				text.Translate(0.0, 0.0, 0.01);
				document.Entities.Add(text, layerName, face.Sense ? Color.OrangeRed : Color.LimeGreen);
				num += region.BoxSize.Diagonal;
				for (int k = 0; k < region.ContourList.Count; k++)
				{
					ICurve[] individualCurves = region.ContourList[k].GetIndividualCurves();
					for (int l = 0; l < individualCurves.Length; l++)
					{
						TrimCurve trimCurve = (TrimCurve)individualCurves[l].Clone();
						if (!face.Sense)
						{
							trimCurve.Reverse();
						}
						document.Entities.Add(trimCurve, layerName, Color.Magenta);
						Point3D insPoint = trimCurve.PointAt(trimCurve.Domain.Mid);
						Text text2 = new Text(Plane.XY, insPoint, trimCurve.EdgeIndex.ToString(), num2 / 20.0, Text.alignmentType.MiddleCenter);
						text2.Regen(new RegenParams(0.1, document));
						Vector3D vector3D = trimCurve.TangentAt(trimCurve.Domain.Mid);
						vector3D.TransformBy(new Rotation(Math.PI / 2.0, Vector3D.AxisZ, Point3D.Origin));
						vector3D.Normalize();
						text2.Translate(vector3D * text2.BoxSize.Max * ((!face.Sense) ? 1 : (-1)));
						document.Entities.Add(text2, layerName);
					}
				}
			}
		}
	}
}
