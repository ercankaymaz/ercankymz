using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MIConvexHull;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Optimization;
using MathNet.Numerics.RootFinding;
using devDept.Diagnostic;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Fem;
using devDept.Eyeshot.Milling;
using devDept.Geometry.ConstraintSolver;
using devDept.Graphics;

namespace devDept.Geometry;

public class Utility
{
	private sealed class _0023_003Dz_0024ImZRv_0024KTAj1 : IComparer<_0023_003DzRaUhii6fJeG0>
	{
		public int Compare(_0023_003DzRaUhii6fJeG0 _0023_003DzBJFJHwk_003D, _0023_003DzRaUhii6fJeG0 _0023_003Dz40R7bAU_003D)
		{
			if (_0023_003DzBJFJHwk_003D._0023_003DzjTLb8o0_003D == _0023_003Dz40R7bAU_003D._0023_003DzjTLb8o0_003D)
			{
				return 0;
			}
			if (_0023_003DzBJFJHwk_003D._0023_003DzjTLb8o0_003D > _0023_003Dz40R7bAU_003D._0023_003DzjTLb8o0_003D)
			{
				return 1;
			}
			return -1;
		}
	}

	private interface _0023_003Dz0REmQspKVzhov2vmFzcEFIc_003D<in _0023_003DzWWgGxds_003D> : IComparer<_0023_003DzWWgGxds_003D>
	{
		void _0023_003DzOv1npdc_003D(_0023_003DzWWgGxds_003D[] _0023_003Dz1ZulaNM_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
	}

	private sealed class _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D
	{
		public Image _0023_003DzqwYd0N8_003D;

		internal bool _0023_003DzKfdrp1yMG3Mms7G3Kl6W5KnTfTVQ(ImageCodecInfo _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.FormatID == _0023_003DzqwYd0N8_003D.RawFormat.Guid;
		}
	}

	private sealed class _0023_003Dz0zaVEEEnjAUqYX0cjimZwVA_003D
	{
		public IReadOnlyList<int> _0023_003DzCS02Bu0_003D;

		internal void _0023_003Dz0pLrH7CaUIXPdb5zKg_003D_003D(IndexLine _0023_003DzTx2aqr8_003D)
		{
			_0023_003DzTx2aqr8_003D.V1 = _0023_003DzCS02Bu0_003D[_0023_003DzTx2aqr8_003D.V1];
			_0023_003DzTx2aqr8_003D.V2 = _0023_003DzCS02Bu0_003D[_0023_003DzTx2aqr8_003D.V2];
		}
	}

	[Serializable]
	private sealed class _0023_003Dz1opDSaEWcXR7ARRgjA_003D_003D<_0023_003DzWWgGxds_003D> where _0023_003DzWWgGxds_003D : IKeyedCollectionItem<_0023_003DzWWgGxds_003D>
	{
		public static readonly _0023_003Dz1opDSaEWcXR7ARRgjA_003D_003D<_0023_003DzWWgGxds_003D> _0023_003DzJ5g3Rwo_003D = new _0023_003Dz1opDSaEWcXR7ARRgjA_003D_003D<_0023_003DzWWgGxds_003D>();

		public static Func<_0023_003DzWWgGxds_003D, bool> _0023_003DzBgetg6OlpoJqdKiZOg_003D_003D;

		internal bool _0023_003DzowbF4GHjp7AllUjBNfDPNpo_003D(_0023_003DzWWgGxds_003D _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D is IDisposable;
		}
	}

	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Color, bool> _0023_003DzAHkUQ25JJUbtOJ8wYQ_003D_003D;

		public static Func<string, string> _0023_003Dz_0024eoOivHCRdpdALGsqA_003D_003D;

		public static Func<IGrouping<string, string>, IGrouping<string, string>> _0023_003DzaCW2l5VAGS882nX3gQ_003D_003D;

		public static Func<KeyValuePair<string, Dictionary<object, HashSet<string>>>, bool> _0023_003Dz5PXi8_0024J0SWe3xFSeug_003D_003D;

		public static Func<KeyValuePair<string, Dictionary<object, HashSet<string>>>, string> _0023_003Dz_zDjklhOWM6gKhwyPw_003D_003D;

		public static Func<KeyValuePair<string, Dictionary<object, HashSet<string>>>, Dictionary<object, HashSet<string>>> _0023_003DznqUshnsUswngnMzGhw_003D_003D;

		public static Func<KeyValuePair<Type, int>, string> _0023_003DzPM_32N2GPdr9pawF_A_003D_003D;

		public static Func<KeyValuePair<Type, int>, Type> _0023_003Dz3vjzA2_prvoAGIZT3w_003D_003D;

		public static Func<KeyValuePair<Type, int>, int> _0023_003Dz5TNKwuZ67fWmGb2RaQ_003D_003D;

		public static Func<KeyValuePair<Type, int>, string> _0023_003Dzz04eb9iBXABnUw8o0A_003D_003D;

		public static Func<KeyValuePair<Type, int>, Type> _0023_003DzwaITsC_HDBPQPhzBGA_003D_003D;

		public static Func<KeyValuePair<Type, int>, int> _0023_003DzlGh_0024By8Qi7J0xy_0024qlg_003D_003D;

		public static Func<Type, int, int> _0023_003Dz1LUmcjbH0K3fpXaL9w_003D_003D;

		internal bool _0023_003DzGkSe424KGQihHDQLYZXyvmE_arJx(Color _0023_003Dzt_m8zV0_003D)
		{
			return _0023_003Dzt_m8zV0_003D.A == byte.MaxValue;
		}

		internal string _0023_003Dz0T_kUDYnzW155NEfsFQYQ5EfrMVwJ8398KyB1oc_003D(string _0023_003Dz77g161c_003D)
		{
			return _0023_003Dz77g161c_003D;
		}

		internal IGrouping<string, string> _0023_003DzSqXCkykihdYF9L_PT82fn7kt50sVs54ggAQcmZs_003D(IGrouping<string, string> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D;
		}

		internal bool _0023_003DzeGxrj99VaE6JgjklQEhp6jqWF0IA(KeyValuePair<string, Dictionary<object, HashSet<string>>> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Value.Count > 0;
		}

		internal string _0023_003DzW1SsZ1fHrh3G5GqSBbZaiSqzLAOs(KeyValuePair<string, Dictionary<object, HashSet<string>>> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Key;
		}

		internal Dictionary<object, HashSet<string>> _0023_003DzE_0024tt1o1BYIamRQ2B03Dh3KkNL0s_0024(KeyValuePair<string, Dictionary<object, HashSet<string>>> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Value;
		}

		internal string _0023_003Dz0quuv2lhtcAOdY6E7UqP1Do_003D(KeyValuePair<Type, int> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Key.ToString();
		}

		internal Type _0023_003DzeX_0024bwjYWyPA_0024ILHul64lAds_003D(KeyValuePair<Type, int> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Key;
		}

		internal int _0023_003DzTYb065Or4h2ZTfG2R83j3vo_003D(KeyValuePair<Type, int> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Value;
		}

		internal string _0023_003DzWHte1hSXET21AHoVinu2UZs_003D(KeyValuePair<Type, int> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Key.ToString();
		}

		internal Type _0023_003DzUvsvGxQpF50Fc_SrGXzc05A_003D(KeyValuePair<Type, int> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Key;
		}

		internal int _0023_003DzRWlb2BTzNjdcfomqU08g4ic_003D(KeyValuePair<Type, int> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Value;
		}

		internal int _0023_003DzizRFQOEPoNMlnH_0024G5LE6hDNi7ISH(Type _0023_003DzEKSHIVc_003D, int _0023_003Dzfsn580w_003D)
		{
			return _0023_003Dzfsn580w_003D + 1;
		}
	}

	private sealed class _0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D
	{
		public BlockKeyedCollection _0023_003DzJO1FWlQ_003D;

		public _0023_003Dz_oAbKQB_0024bE8H _0023_003DzOLHnb2M_003D;

		public Action<Entity> _0023_003DzJjT3dOU3oUsg;

		internal void _0023_003Dz9mDbjZFLbwXPwmd8KWf3QIo_003D(Entity _0023_003DzNpfDgu2nb0Hr)
		{
			_0023_003Dz_oAbKQB_0024bE8H _0023_003DzflHdm0uTKwpx = _0023_003Dz9MXzPGXXCOqX(_0023_003DzNpfDgu2nb0Hr, _0023_003DzJO1FWlQ_003D, _0023_003DzNIs0hzaBCcL8z40btQ_003D_003D: true);
			_0023_003DzQOtC1Mf2FWpv(_0023_003DzOLHnb2M_003D, _0023_003DzflHdm0uTKwpx);
		}
	}

	private delegate bool _0023_003Dz3Hbn_0024P0_003D(string _0023_003DzGGUd1aw_003D);

	private sealed class _0023_003Dz5gWigDbfQ_0024Jn3SJ0J5A2BYM_003D : _0023_003Dz0REmQspKVzhov2vmFzcEFIc_003D<PointNormalUv>, IComparer<PointNormalUv>
	{
		public int Compare(PointNormalUv _0023_003DzMEwtr_A_003D, PointNormalUv _0023_003DzW7Zyxfc_003D)
		{
			int num = CompareWithoutTolerance(_0023_003DzMEwtr_A_003D.U, _0023_003DzW7Zyxfc_003D.U);
			if (num == 0)
			{
				return CompareWithoutTolerance(_0023_003DzMEwtr_A_003D.V, _0023_003DzW7Zyxfc_003D.V);
			}
			return num;
		}

		public void _0023_003DzOv1npdc_003D(PointNormalUv[] _0023_003Dz1ZulaNM_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
		{
			int num = 0;
			while (num < _0023_003Dz1ZulaNM_003D.Length)
			{
				int num2 = num;
				PointNormalUv pointNormalUv = _0023_003Dz1ZulaNM_003D[num++];
				while (num < _0023_003Dz1ZulaNM_003D.Length && Utility.Compare(_0023_003DzuMKQhOieejyEvhtVOw_003D_003D, pointNormalUv.U, _0023_003Dz1ZulaNM_003D[num].U) == 0)
				{
					_0023_003Dz1ZulaNM_003D[num++].U = pointNormalUv.U;
				}
				Array.Sort(_0023_003Dz1ZulaNM_003D, num2, num - num2, this);
			}
			int num3 = 0;
			while (num3 < _0023_003Dz1ZulaNM_003D.Length)
			{
				int num4 = num3;
				PointNormalUv pointNormalUv2 = _0023_003Dz1ZulaNM_003D[num3++];
				while (num3 < _0023_003Dz1ZulaNM_003D.Length && pointNormalUv2.U == _0023_003Dz1ZulaNM_003D[num3].U && Utility.Compare(_0023_003DzuMKQhOieejyEvhtVOw_003D_003D, pointNormalUv2.V, _0023_003Dz1ZulaNM_003D[num3].V) == 0)
				{
					_0023_003Dz1ZulaNM_003D[num3++].V = pointNormalUv2.V;
				}
				Array.Sort(_0023_003Dz1ZulaNM_003D, num4, num3 - num4, this);
			}
		}
	}

	private sealed class _0023_003DzAtGjYqeB5saLo1gpAIWB6TI_003D
	{
		public SketchCurve _0023_003DzDIkJozyJywX_oLeB6SD5yFc_003D;

		public Func<SketchCurve, bool> _0023_003DzkqbsCVPMJ_0024g6;

		internal bool _0023_003DzOETHUvIn_0024fRI04yYBSxWI9o_003D(SketchCurve _0023_003Dzs_0024uS8LA_003D)
		{
			if (_0023_003Dzs_0024uS8LA_003D != null)
			{
				return _0023_003Dzs_0024uS8LA_003D != _0023_003DzDIkJozyJywX_oLeB6SD5yFc_003D;
			}
			return false;
		}
	}

	private sealed class _0023_003DzJB7y4PKxFmsMx4pav3Nd2fo_003D
	{
		public SketchCurve _0023_003DzyGC5ZI76ZaE2HTUyhA_003D_003D;

		internal bool _0023_003DzBG34o_JzybGL1GKyfGVk6OQ_003D(SketchCurve _0023_003Dzs_0024uS8LA_003D)
		{
			if (_0023_003Dzs_0024uS8LA_003D != null)
			{
				return _0023_003Dzs_0024uS8LA_003D != _0023_003DzyGC5ZI76ZaE2HTUyhA_003D_003D;
			}
			return false;
		}

		internal bool _0023_003DzKhht_YEi9duiCjIPUiviCbs_003D(SketchCurve _0023_003Dzs_0024uS8LA_003D)
		{
			if (_0023_003Dzs_0024uS8LA_003D != null)
			{
				return _0023_003Dzs_0024uS8LA_003D != _0023_003DzyGC5ZI76ZaE2HTUyhA_003D_003D;
			}
			return false;
		}
	}

	private sealed class _0023_003DzJXFwcQeUoj_0024yhfwAUnzcfrs_003D<_0023_003DzWWgGxds_003D> where _0023_003DzWWgGxds_003D : IIndexObject
	{
		public IReadOnlyList<int> _0023_003DzCS02Bu0_003D;

		internal _0023_003DzWWgGxds_003D _0023_003Dzbxld8NEHHD5oAYaX0jAlQ6I_003D(_0023_003DzWWgGxds_003D _0023_003DzNDQ_E88_003D)
		{
			_0023_003DzPSBHfLpYLpHxGG6O9w_003D_003D(_0023_003DzNDQ_E88_003D, _0023_003DzCS02Bu0_003D);
			return _0023_003DzNDQ_E88_003D;
		}

		internal _0023_003DzWWgGxds_003D _0023_003DzzWoFMm_cVzNQ_RRoC_YYHc0_003D(_0023_003DzWWgGxds_003D _0023_003DzNDQ_E88_003D)
		{
			_0023_003DzNDQ_E88_003D.Reindex(_0023_003DzCS02Bu0_003D);
			return _0023_003DzNDQ_E88_003D;
		}
	}

	private sealed class _0023_003DzNCfzh2Axy2MCradzXQ_003D_003D : _0023_003Dz0REmQspKVzhov2vmFzcEFIc_003D<Point3D>, IComparer<Point3D>
	{
		public int Compare(Point3D _0023_003DzMEwtr_A_003D, Point3D _0023_003DzW7Zyxfc_003D)
		{
			int num = CompareWithoutTolerance(_0023_003DzMEwtr_A_003D.X, _0023_003DzW7Zyxfc_003D.X);
			if (num != 0)
			{
				return num;
			}
			int num2 = CompareWithoutTolerance(_0023_003DzMEwtr_A_003D.Y, _0023_003DzW7Zyxfc_003D.Y);
			if (num2 == 0)
			{
				return CompareWithoutTolerance(_0023_003DzMEwtr_A_003D.Z, _0023_003DzW7Zyxfc_003D.Z);
			}
			return num2;
		}

		public void _0023_003DzOv1npdc_003D(Point3D[] _0023_003Dz1ZulaNM_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D)
		{
			int num = 0;
			while (num < _0023_003Dz1ZulaNM_003D.Length)
			{
				int num2 = num;
				Point3D point3D = _0023_003Dz1ZulaNM_003D[num++];
				while (num < _0023_003Dz1ZulaNM_003D.Length && Utility.Compare(_0023_003DzuMKQhOieejyEvhtVOw_003D_003D, point3D.X, _0023_003Dz1ZulaNM_003D[num].X) == 0)
				{
					_0023_003Dz1ZulaNM_003D[num++].X = point3D.X;
				}
				Array.Sort(_0023_003Dz1ZulaNM_003D, num2, num - num2, this);
			}
			int num3 = 0;
			while (num3 < _0023_003Dz1ZulaNM_003D.Length)
			{
				int num4 = num3;
				Point3D point3D2 = _0023_003Dz1ZulaNM_003D[num3++];
				while (num3 < _0023_003Dz1ZulaNM_003D.Length && point3D2.X == _0023_003Dz1ZulaNM_003D[num3].X && Utility.Compare(_0023_003DzuMKQhOieejyEvhtVOw_003D_003D, point3D2.Y, _0023_003Dz1ZulaNM_003D[num3].Y) == 0)
				{
					_0023_003Dz1ZulaNM_003D[num3++].Y = point3D2.Y;
				}
				Array.Sort(_0023_003Dz1ZulaNM_003D, num4, num3 - num4, this);
			}
			int num5 = 0;
			while (num5 < _0023_003Dz1ZulaNM_003D.Length)
			{
				Point3D point3D3 = _0023_003Dz1ZulaNM_003D[num5++];
				while (num5 < _0023_003Dz1ZulaNM_003D.Length && point3D3.X == _0023_003Dz1ZulaNM_003D[num5].X && point3D3.Y == _0023_003Dz1ZulaNM_003D[num5].Y && Utility.Compare(_0023_003DzuMKQhOieejyEvhtVOw_003D_003D, point3D3.Z, _0023_003Dz1ZulaNM_003D[num5].Z) == 0)
				{
					_0023_003Dz1ZulaNM_003D[num5++].Z = point3D3.Z;
				}
			}
		}
	}

	[Serializable]
	private sealed class _0023_003DzPKFpvhodSEggWtcuYg_003D_003D<_0023_003DzWWgGxds_003D> where _0023_003DzWWgGxds_003D : ICloneable
	{
		public static readonly _0023_003DzPKFpvhodSEggWtcuYg_003D_003D<_0023_003DzWWgGxds_003D> _0023_003DzJ5g3Rwo_003D = new _0023_003DzPKFpvhodSEggWtcuYg_003D_003D<_0023_003DzWWgGxds_003D>();

		public static Func<_0023_003DzWWgGxds_003D, _0023_003DzWWgGxds_003D> _0023_003Dz_jMH4bvB3WA6DaWN6w_003D_003D;

		internal _0023_003DzWWgGxds_003D _0023_003DzILfkeHQltkq6NeFeqLO2_0024Oc_003D(_0023_003DzWWgGxds_003D _0023_003DzBJFJHwk_003D)
		{
			return (_0023_003DzWWgGxds_003D)_0023_003DzBJFJHwk_003D.Clone();
		}
	}

	private struct _0023_003DzRaUhii6fJeG0
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzyzK8swU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzjTLb8o0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Point2D[] _0023_003Dz06A5WivSSyUp;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ICurve _0023_003Dz5MW1eJg__0024ioiTFboUdiEDFk_003D;

		public _0023_003DzRaUhii6fJeG0(int _0023_003DzyzK8swU_003D, double _0023_003DzjTLb8o0_003D, Point2D[] _0023_003Dz06A5WivSSyUp)
		{
			this._0023_003DzyzK8swU_003D = _0023_003DzyzK8swU_003D;
			this._0023_003DzjTLb8o0_003D = _0023_003DzjTLb8o0_003D;
			this._0023_003Dz06A5WivSSyUp = _0023_003Dz06A5WivSSyUp;
			_0023_003Dz5MW1eJg__0024ioiTFboUdiEDFk_003D = null;
		}

		public _0023_003DzRaUhii6fJeG0(int _0023_003DzyzK8swU_003D, double _0023_003DzjTLb8o0_003D, ICurve _0023_003Dz06A5WivSSyUp)
		{
			this._0023_003DzyzK8swU_003D = _0023_003DzyzK8swU_003D;
			this._0023_003DzjTLb8o0_003D = _0023_003DzjTLb8o0_003D;
			this._0023_003Dz06A5WivSSyUp = null;
			_0023_003Dz5MW1eJg__0024ioiTFboUdiEDFk_003D = _0023_003Dz06A5WivSSyUp;
		}
	}

	internal sealed class _0023_003DzSFuhf_w_003D
	{
		private static byte[] _0023_003DzY2mALHE6ug3o = Encoding.ASCII.GetBytes(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660580));

		private static string _0023_003Dztz6PyH6cRpa7 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660567);

		public static string _0023_003Dz83_RyNBJkx1j(string _0023_003Dzsmqx3UlZnlgh)
		{
			if (string.IsNullOrEmpty(_0023_003Dzsmqx3UlZnlgh))
			{
				throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660560));
			}
			if (string.IsNullOrEmpty(_0023_003Dztz6PyH6cRpa7))
			{
				throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660537));
			}
			RijndaelManaged rijndaelManaged = null;
			string text = null;
			try
			{
				Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(_0023_003Dztz6PyH6cRpa7, _0023_003DzY2mALHE6ug3o);
				MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(_0023_003Dzsmqx3UlZnlgh));
				try
				{
					rijndaelManaged = new RijndaelManaged();
					rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
					rijndaelManaged.IV = _0023_003DzGJRBKhiXkN5d(memoryStream);
					ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
					CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
					try
					{
						StreamReader streamReader = new StreamReader(cryptoStream);
						try
						{
							return streamReader.ReadToEnd();
						}
						finally
						{
							((IDisposable)streamReader).Dispose();
						}
					}
					finally
					{
						((IDisposable)cryptoStream).Dispose();
					}
				}
				finally
				{
					((IDisposable)memoryStream).Dispose();
				}
			}
			finally
			{
				rijndaelManaged?.Clear();
			}
		}

		private static byte[] _0023_003DzGJRBKhiXkN5d(Stream _0023_003DzuwH5j5s_003D)
		{
			byte[] array = new byte[4];
			if (_0023_003DzuwH5j5s_003D.Read(array, 0, array.Length) != array.Length)
			{
				throw new SystemException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660526));
			}
			byte[] array2 = new byte[BitConverter.ToInt32(array, 0)];
			if (_0023_003DzuwH5j5s_003D.Read(array2, 0, array2.Length) != array2.Length)
			{
				throw new SystemException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660199));
			}
			return array2;
		}
	}

	private sealed class _0023_003DzSWQKpqBvYSEeYAzOALPj_0024d8_003D
	{
		public BlockKeyedCollection _0023_003DzJO1FWlQ_003D;

		public _0023_003Dz_oAbKQB_0024bE8H _0023_003DzOTjvb5U_003D;

		internal void _0023_003DzH8NHt_hBiNo3aXpFhQ_003D_003D(Entity _0023_003Dzs_0024uS8LA_003D)
		{
			_0023_003Dz_oAbKQB_0024bE8H _0023_003DzflHdm0uTKwpx = _0023_003Dz9MXzPGXXCOqX(_0023_003Dzs_0024uS8LA_003D, _0023_003DzJO1FWlQ_003D, _0023_003DzNIs0hzaBCcL8z40btQ_003D_003D: false);
			_0023_003DzQOtC1Mf2FWpv(_0023_003DzOTjvb5U_003D, _0023_003DzflHdm0uTKwpx);
		}
	}

	private sealed class _0023_003DzSpe8iZ6fy6btntamlyuSz3w_003D
	{
		public Vector<double> _0023_003DzuTkHiyI_003D;

		public Vector<double> _0023_003Dz0KVPVlc_003D;

		public Vector<double> _0023_003DzGRCZTwc_003D;

		internal Vector<double> _0023_003DqazlBQydKz2YBiYhPLzprHXB46Ahwe__e_0024L4cbDcoT4U_003D(Vector<double> _0023_003DzB68dg9Q_003D, Vector<double> _0023_003DzBJFJHwk_003D)
		{
			Vector<double> vector = CreateVector.DenseOfArray(new double[3]
			{
				_0023_003DzB68dg9Q_003D[0],
				_0023_003DzB68dg9Q_003D[1],
				_0023_003DzB68dg9Q_003D[2]
			});
			double num = Math.Cos(_0023_003DzB68dg9Q_003D[3]);
			double num2 = Math.Sin(_0023_003DzB68dg9Q_003D[3]);
			double num3 = Math.Cos(_0023_003DzB68dg9Q_003D[4]);
			double num4 = Math.Sin(_0023_003DzB68dg9Q_003D[4]);
			Vector<double> vector2 = CreateVector.DenseOfArray(new double[3]
			{
				num * num4,
				num2 * num4,
				num3
			});
			double num5 = _0023_003DzB68dg9Q_003D[5];
			double num6 = _0023_003DzB68dg9Q_003D[6];
			int num7 = _0023_003DzBJFJHwk_003D.Count();
			Vector<double> vector3 = CreateVector.Dense<double>(num7);
			for (int i = 0; i < num7; i++)
			{
				Vector<double> vector4 = CreateVector.DenseOfArray(new double[3]
				{
					_0023_003DzuTkHiyI_003D[i],
					_0023_003Dz0KVPVlc_003D[i],
					_0023_003DzGRCZTwc_003D[i]
				});
				Vector<double> vector5 = vector - vector4;
				double num8 = vector5 * vector5;
				double num9 = vector5 * vector2;
				double num10 = num8 + num6;
				vector3[i] = num10 * num10 - 4.0 * num5 * (num8 - num9 * num9);
			}
			return vector3;
		}

		internal Matrix<double> _0023_003DqSwhpcbqB8mQqb2wvkTCPpuFIa6GRsBrJ3SjRv8wtvQ0_003D(Vector<double> _0023_003DzB68dg9Q_003D, Vector<double> _0023_003DzBJFJHwk_003D)
		{
			Matrix<double> matrix = Matrix<double>.Build.Dense(_0023_003DzBJFJHwk_003D.Count, _0023_003DzB68dg9Q_003D.Count);
			Vector<double> vector = CreateVector.DenseOfArray(new double[3]
			{
				_0023_003DzB68dg9Q_003D[0],
				_0023_003DzB68dg9Q_003D[1],
				_0023_003DzB68dg9Q_003D[2]
			});
			double num = Math.Cos(_0023_003DzB68dg9Q_003D[3]);
			double num2 = Math.Sin(_0023_003DzB68dg9Q_003D[3]);
			double num3 = Math.Cos(_0023_003DzB68dg9Q_003D[4]);
			double num4 = Math.Sin(_0023_003DzB68dg9Q_003D[4]);
			Vector<double> vector2 = CreateVector.DenseOfArray(new double[3]
			{
				num * num4,
				num2 * num4,
				num3
			});
			double num5 = _0023_003DzB68dg9Q_003D[5];
			double num6 = _0023_003DzB68dg9Q_003D[6];
			int num7 = _0023_003DzBJFJHwk_003D.Count();
			for (int i = 0; i < num7; i++)
			{
				Vector<double> vector3 = CreateVector.DenseOfArray(new double[3]
				{
					_0023_003DzuTkHiyI_003D[0],
					_0023_003DzuTkHiyI_003D[1],
					_0023_003DzuTkHiyI_003D[2]
				});
				Vector<double> vector4 = vector - vector3;
				double num8 = vector4 * vector4;
				double num9 = vector4 * vector2;
				double num10 = num8 + num6;
				Vector<double> vector5 = CreateVector.DenseOfArray(new double[3]
				{
					(0.0 - num2) * num4,
					num * num4,
					0.0
				});
				Vector<double> vector6 = CreateVector.DenseOfArray(new double[3]
				{
					num * num3,
					num2 * num3,
					0.0 - num4
				});
				Vector<double> vector7 = 4.0 * num10 * vector4 - 8.0 * num5 * (vector4 - num9 * vector2);
				matrix[i, 0] = vector7[0];
				matrix[i, 1] = vector7[1];
				matrix[i, 2] = vector7[2];
				matrix[i, 3] = 8.0 * num5 * (vector5 * vector4);
				matrix[i, 4] = 8.0 * num5 * (vector6 * vector4);
				matrix[i, 5] = -4.0 * num5 * (num8 - num9 * num9);
				matrix[i, 6] = 2.0 * num10;
			}
			return matrix;
		}
	}

	internal sealed class _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D
	{
		public int _0023_003DztSjubr_JXt59;

		public Point3D[] _0023_003DzOK_0024S8ThjuNW5 = new Point3D[2];

		public Point3D[] _0023_003DzyUs6D9_SWs1i = new Point3D[2];

		public double[] _0023_003DzqLMDDyVBo88_0024 = new double[2];

		public double[] _0023_003DzlcY317DiY_0024sJ = new double[2];

		public int _0023_003Dz7L3Iw6frIRXoyynokiNCmg4_003D;

		public (Point3D, Point3D)[] _0023_003Dz6Iv8Vix9e_00249Dam0O_wtW0KY_003D = new(Point3D, Point3D)[2];

		public double _0023_003DzOxKU6GM_003D;

		public double _0023_003DzCZ6r8YUaZEiw;

		public bool _0023_003Dzsk2BQtp4tgbDO0Ghpw_003D_003D;
	}

	internal sealed class _0023_003DzVOCYxDs_003D
	{
		public int _0023_003DzJi_U_DO0FYyE;

		public Point3D[] _0023_003DzJeFVES8kK6nS = new Point3D[2];

		public Point3D[] _0023_003DzvTHGJgQ1ULAK = new Point3D[2];

		public double[] _0023_003Dzujw274ll21y9 = new double[2];

		public double[] _0023_003DzJZdh6hKL_zcF = new double[2];

		public double[] _0023_003DzmAHVzIc_003D = new double[2];

		public double[] _0023_003DzOxKU6GM_003D = new double[2];
	}

	private sealed class _0023_003DzW0vVMDai_00241WamJy166LzGtYXxAOH : IEnumerable<string>, IEnumerable, IEnumerator<string>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _0023_003DzAqOpw0w_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003DzAzn_DZmw_00247mn;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _0023_003Dzk64JNOo_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003DzRShWhkiAESmh;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private RegexOptions _0023_003DzdNx9MH0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegexOptions _0023_003DzTyy6rbWL8doh;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _0023_003Dz0EsKsC8_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003DzsFGs7sDiof2F;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IEnumerator _0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D;

		[DebuggerHidden]
		public _0023_003DzW0vVMDai_00241WamJy166LzGtYXxAOH(int _0023_003DzU7pGb3X7Zp4G)
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
				switch (_0023_003DzU7pGb3X7Zp4G)
				{
				default:
					return false;
				case 0:
				{
					_0023_003DzU7pGb3X7Zp4G = -1;
					MatchCollection matchCollection = new Regex(Regex.Escape(_0023_003DzAqOpw0w_003D) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660600) + Regex.Escape(_0023_003Dzk64JNOo_003D), _0023_003DzdNx9MH0_003D).Matches(_0023_003Dz0EsKsC8_003D);
					_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D = matchCollection.GetEnumerator();
					_0023_003DzU7pGb3X7Zp4G = -3;
					break;
				}
				case 1:
					_0023_003DzU7pGb3X7Zp4G = -3;
					break;
				}
				if (_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D.MoveNext())
				{
					Match match = (Match)_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D.Current;
					_0023_003DzezVIuujSK1H9 = match.Groups[1].Value;
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
			if (_0023_003DzyiWrtXgDzPH_MHCrAg_003D_003D is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}

		[DebuggerHidden]
		private string _0023_003DzY24C0PM3LBA5_Dov8ZgMrW3_FwuKRUAB_0024A_003D_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		string IEnumerator<string>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zY24C0PM3LBA5_Dov8ZgMrW3_FwuKRUAB$A==
			return this._0023_003DzY24C0PM3LBA5_Dov8ZgMrW3_FwuKRUAB_0024A_003D_003D();
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
		private IEnumerator<string> _0023_003Dz5vD0cnLBPES7LaYfvErawLopk875yrNPyQ_003D_003D()
		{
			_0023_003DzW0vVMDai_00241WamJy166LzGtYXxAOH _0023_003DzW0vVMDai_00241WamJy166LzGtYXxAOH2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzW0vVMDai_00241WamJy166LzGtYXxAOH2 = this;
			}
			else
			{
				_0023_003DzW0vVMDai_00241WamJy166LzGtYXxAOH2 = new _0023_003DzW0vVMDai_00241WamJy166LzGtYXxAOH(0);
			}
			_0023_003DzW0vVMDai_00241WamJy166LzGtYXxAOH2._0023_003Dz0EsKsC8_003D = _0023_003DzsFGs7sDiof2F;
			_0023_003DzW0vVMDai_00241WamJy166LzGtYXxAOH2._0023_003DzAqOpw0w_003D = _0023_003DzAzn_DZmw_00247mn;
			_0023_003DzW0vVMDai_00241WamJy166LzGtYXxAOH2._0023_003Dzk64JNOo_003D = _0023_003DzRShWhkiAESmh;
			_0023_003DzW0vVMDai_00241WamJy166LzGtYXxAOH2._0023_003DzdNx9MH0_003D = _0023_003DzTyy6rbWL8doh;
			return _0023_003DzW0vVMDai_00241WamJy166LzGtYXxAOH2;
		}

		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=z5vD0cnLBPES7LaYfvErawLopk875yrNPyQ==
			return this._0023_003Dz5vD0cnLBPES7LaYfvErawLopk875yrNPyQ_003D_003D();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003Dz5vD0cnLBPES7LaYfvErawLopk875yrNPyQ_003D_003D();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	[Serializable]
	private sealed class _0023_003DzWi8Y7HWlPE_txEBDzg_003D_003D<_0023_003DzWWgGxds_003D> where _0023_003DzWWgGxds_003D : ICloneable
	{
		public static readonly _0023_003DzWi8Y7HWlPE_txEBDzg_003D_003D<_0023_003DzWWgGxds_003D> _0023_003DzJ5g3Rwo_003D = new _0023_003DzWi8Y7HWlPE_txEBDzg_003D_003D<_0023_003DzWWgGxds_003D>();

		public static Func<_0023_003DzWWgGxds_003D, _0023_003DzWWgGxds_003D> _0023_003DzXvWpAWBWyOEu2_hCBQ_003D_003D;

		internal _0023_003DzWWgGxds_003D _0023_003Dzx4l3Qk5jaZLzS4DfScPqjT7ca7TLqnPNJg_003D_003D(_0023_003DzWWgGxds_003D _0023_003Dz77g161c_003D)
		{
			return (_0023_003DzWWgGxds_003D)_0023_003Dz77g161c_003D.Clone();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzZsKJFrz2EpH63_0024U44BCgokk_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dz9JZgoew_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzEvUQrI0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003Dzfm4oGj8_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003Dzkxp9QWw_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzCVdPoWM_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzN9y2G9c_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzGQE5xwU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzJKjUKZ4_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzH8_0024G110_003D;
	}

	private sealed class _0023_003Dz_oAbKQB_0024bE8H
	{
		public readonly ConcurrentDictionary<Type, int> _0023_003Dz3QHxwCaWnG9i = new ConcurrentDictionary<Type, int>();

		public int _0023_003DzbpLIUiI_003D;

		public int _0023_003DzJltwz0y1myjKQO1O8w_003D_003D;

		public int _0023_003DzPacMabcPoc4oQoC0UA_003D_003D;
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzdK0ygWN7LNhApRmmGzJ5bl0_003D<_0023_003DzWWgGxds_003D>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IList<_0023_003DzWWgGxds_003D> _0023_003DzcDEsV8s_003D;
	}

	private sealed class _0023_003DzebzciKwXEYAeg8D4y0YRM6E_003D<_0023_003DzWWgGxds_003D> where _0023_003DzWWgGxds_003D : IIndexObject
	{
		public IReadOnlyList<int> _0023_003DzCS02Bu0_003D;

		internal bool _0023_003DzQaRt4Kl_JnE7MqwSdHAkOZQ_003D(_0023_003DzWWgGxds_003D _0023_003DzNDQ_E88_003D)
		{
			return !_0023_003DzNDQ_E88_003D.WouldContainDuplicates(_0023_003DzCS02Bu0_003D);
		}

		internal bool _0023_003Dz_0024ZgUMTNhU0Eh3uZemnj4Ivo_003D(_0023_003DzWWgGxds_003D _0023_003DzNDQ_E88_003D)
		{
			return !_0023_003DzNDQ_E88_003D.WouldContainDuplicates(_0023_003DzCS02Bu0_003D);
		}
	}

	private sealed class _0023_003DzgXDOuv8r81l4Hsr1RflTF_w_003D
	{
		public _0023_003Dz_oAbKQB_0024bE8H _0023_003DzwbSYw4yD1PW4;

		public _0023_003DzSWQKpqBvYSEeYAzOALPj_0024d8_003D _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D;

		internal void _0023_003DzM7ZzqEOv_SxJANuDXg_003D_003D(Entity _0023_003DzIIVk_0024BF5CEyZ)
		{
			_0023_003Dz_oAbKQB_0024bE8H _0023_003DzflHdm0uTKwpx = _0023_003Dz9MXzPGXXCOqX(_0023_003DzIIVk_0024BF5CEyZ, _0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D._0023_003DzJO1FWlQ_003D, _0023_003DzNIs0hzaBCcL8z40btQ_003D_003D: false);
			_0023_003DzQOtC1Mf2FWpv(_0023_003DzwbSYw4yD1PW4, _0023_003DzflHdm0uTKwpx);
		}
	}

	private sealed class _0023_003DziN7DYA81qa_0024kjDuS0LTKYTs_003D
	{
		public KeyValuePair<Type, int> _0023_003Dz4okd4Qo_003D;

		internal int _0023_003Dz0KTTC6KkWKPs9pSkmg_003D_003D(Type _0023_003DzEKSHIVc_003D, int _0023_003Dzfsn580w_003D)
		{
			return _0023_003Dzfsn580w_003D + _0023_003Dz4okd4Qo_003D.Value;
		}
	}

	internal static class _0023_003DziWIBdhJJlTub
	{
		public struct _0023_003DzwbbgHmo_003D
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public double _0023_003DzRgUiPi1yoiaQ;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public double _0023_003Dz2LueQ4zIuh5i;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public double _0023_003DzOxKU6GM_003D;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public double _0023_003DzCZ6r8YUaZEiw;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public Point3D _0023_003DzCRi06tFycJw_0024;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public Point3D _0023_003Dzlwi4wOuYZwyn;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public Point3D _0023_003DzQ7usAag_003D;
		}

		public static _0023_003DzwbbgHmo_003D _0023_003DzL9woobs_003D(Line _0023_003DzQvaHyao_003D, Line _0023_003DzNyidyKE_003D, double _0023_003DzX0qX_IwWxysi)
		{
			Point3D startPoint = _0023_003DzQvaHyao_003D.StartPoint;
			Point3D endPoint = _0023_003DzQvaHyao_003D.EndPoint;
			Point3D startPoint2 = _0023_003DzNyidyKE_003D.StartPoint;
			Point3D endPoint2 = _0023_003DzNyidyKE_003D.EndPoint;
			Vector3D asVector = (endPoint - startPoint).AsVector;
			Vector3D asVector2 = (endPoint2 - startPoint2).AsVector;
			Vector3D asVector3 = (startPoint - startPoint2).AsVector;
			double num = Vector3D.Dot(asVector, asVector);
			double num2 = Vector3D.Dot(asVector, asVector2);
			double num3 = Vector3D.Dot(asVector2, asVector2);
			double num4 = Vector3D.Dot(asVector, asVector3);
			double num5 = Vector3D.Dot(asVector2, asVector3);
			double num6 = num4;
			double num7 = num4 + num;
			double _0023_003DzAGmW1Zo_003D = num4 - num2;
			double _0023_003DziDbNDXw_003D = num4 + num - num2;
			double num8 = 0.0 - num5;
			double num9 = 0.0 - num5 - num2;
			double num10 = 0.0 - num5 + num3;
			double num11 = 0.0 - num5 - num2 + num3;
			double _0023_003DzuwH5j5s_003D;
			double _0023_003DzNDQ_E88_003D;
			if (num > 0.0 && num3 > 0.0)
			{
				double[] array = new double[2]
				{
					_0023_003Dz8SdkRpxr4Y_tOUoVSQ_003D_003D(num, num6, num7),
					_0023_003Dz8SdkRpxr4Y_tOUoVSQ_003D_003D(num, _0023_003DzAGmW1Zo_003D, _0023_003DziDbNDXw_003D)
				};
				int[] array2 = new int[2];
				for (int i = 0; i < 2; i++)
				{
					if (array[i] <= 0.0)
					{
						array2[i] = -1;
					}
					else if (array[i] >= 1.0)
					{
						array2[i] = 1;
					}
					else
					{
						array2[i] = 0;
					}
				}
				if (array2[0] == -1 && array2[1] == -1)
				{
					_0023_003DzuwH5j5s_003D = 0.0;
					_0023_003DzNDQ_E88_003D = _0023_003Dz8SdkRpxr4Y_tOUoVSQ_003D_003D(num3, num8, num10);
				}
				else if (array2[0] == 1 && array2[1] == 1)
				{
					_0023_003DzuwH5j5s_003D = 1.0;
					_0023_003DzNDQ_E88_003D = _0023_003Dz8SdkRpxr4Y_tOUoVSQ_003D_003D(num3, num9, num11);
				}
				else
				{
					int[] _0023_003DzTx2aqr8_003D = new int[2];
					double[,] _0023_003Dzk64JNOo_003D = new double[2, 2];
					_0023_003DzOYxPx6FqLIHX(array, array2, num2, num6, num7, _0023_003DzTx2aqr8_003D, _0023_003Dzk64JNOo_003D);
					_0023_003DzR2ffzSD_00242pZl(_0023_003DzTx2aqr8_003D, _0023_003Dzk64JNOo_003D, num2, num3, num5, num8, num9, num10, num11, out _0023_003DzuwH5j5s_003D, out _0023_003DzNDQ_E88_003D);
				}
			}
			else if (num > 0.0)
			{
				_0023_003DzuwH5j5s_003D = _0023_003Dz8SdkRpxr4Y_tOUoVSQ_003D_003D(num, num6, num7);
				_0023_003DzNDQ_E88_003D = 0.0;
			}
			else if (num3 > 0.0)
			{
				_0023_003DzuwH5j5s_003D = 0.0;
				_0023_003DzNDQ_E88_003D = _0023_003Dz8SdkRpxr4Y_tOUoVSQ_003D_003D(num3, num8, num10);
			}
			else
			{
				_0023_003DzuwH5j5s_003D = 0.0;
				_0023_003DzNDQ_E88_003D = 0.0;
			}
			Point3D point3D = (1.0 - _0023_003DzuwH5j5s_003D) * startPoint + _0023_003DzuwH5j5s_003D * endPoint;
			Point3D point3D2 = (1.0 - _0023_003DzNDQ_E88_003D) * startPoint2 + _0023_003DzNDQ_E88_003D * endPoint2;
			Vector3D asVector4 = (point3D - point3D2).AsVector;
			double num12 = Vector3D.Dot(asVector4, asVector4);
			return new _0023_003DzwbbgHmo_003D
			{
				_0023_003DzRgUiPi1yoiaQ = _0023_003DzQvaHyao_003D.Domain.Low + _0023_003DzQvaHyao_003D.Domain.Length * _0023_003DzuwH5j5s_003D,
				_0023_003Dz2LueQ4zIuh5i = _0023_003DzNyidyKE_003D.Domain.Low + _0023_003DzNyidyKE_003D.Domain.Length * _0023_003DzNDQ_E88_003D,
				_0023_003DzCRi06tFycJw_0024 = point3D,
				_0023_003Dzlwi4wOuYZwyn = point3D2,
				_0023_003DzOxKU6GM_003D = Math.Sqrt(num12),
				_0023_003DzCZ6r8YUaZEiw = num12,
				_0023_003DzQ7usAag_003D = ((Math.Sqrt(num12) < _0023_003DzX0qX_IwWxysi) ? Point3D.MidPoint(point3D, point3D2) : null)
			};
		}

		private static double _0023_003Dz8SdkRpxr4Y_tOUoVSQ_003D_003D(double _0023_003DzIM9JECHurNLz, double _0023_003DzAGmW1Zo_003D, double _0023_003DziDbNDXw_003D)
		{
			if (_0023_003DzAGmW1Zo_003D < 0.0)
			{
				if (_0023_003DziDbNDXw_003D > 0.0)
				{
					double num = (0.0 - _0023_003DzAGmW1Zo_003D) / _0023_003DzIM9JECHurNLz;
					if (!(num > 1.0))
					{
						return num;
					}
					return 0.5;
				}
				return 1.0;
			}
			return 0.0;
		}

		private static void _0023_003DzOYxPx6FqLIHX(double[] _0023_003DznI_N5hw_003D, int[] _0023_003DzB_0024jGmeI_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003Dz3cG0Ey8_003D, double _0023_003Dz92Yz3QI_003D, int[] _0023_003DzTx2aqr8_003D, double[,] _0023_003Dzk64JNOo_003D)
		{
			if (_0023_003DzB_0024jGmeI_003D[0] < 0)
			{
				_0023_003DzTx2aqr8_003D[0] = 0;
				_0023_003Dzk64JNOo_003D[0, 0] = 0.0;
				_0023_003Dzk64JNOo_003D[0, 1] = _0023_003Dz5IigOWkZ7GyB(_0023_003Dz3cG0Ey8_003D / _0023_003Dz1v6oPQk_003D);
				if (_0023_003DzB_0024jGmeI_003D[1] == 0)
				{
					_0023_003DzTx2aqr8_003D[1] = 3;
					_0023_003Dzk64JNOo_003D[1, 0] = _0023_003DznI_N5hw_003D[1];
					_0023_003Dzk64JNOo_003D[1, 1] = 1.0;
				}
				else
				{
					_0023_003DzTx2aqr8_003D[1] = 1;
					_0023_003Dzk64JNOo_003D[1, 0] = 1.0;
					_0023_003Dzk64JNOo_003D[1, 1] = _0023_003Dz5IigOWkZ7GyB(_0023_003Dz92Yz3QI_003D / _0023_003Dz1v6oPQk_003D);
				}
			}
			else if (_0023_003DzB_0024jGmeI_003D[0] == 0)
			{
				_0023_003DzTx2aqr8_003D[0] = 2;
				_0023_003Dzk64JNOo_003D[0, 0] = _0023_003DznI_N5hw_003D[0];
				_0023_003Dzk64JNOo_003D[0, 1] = 0.0;
				if (_0023_003DzB_0024jGmeI_003D[1] < 0)
				{
					_0023_003DzTx2aqr8_003D[1] = 0;
					_0023_003Dzk64JNOo_003D[1, 0] = 0.0;
					_0023_003Dzk64JNOo_003D[1, 1] = _0023_003Dz5IigOWkZ7GyB(_0023_003Dz3cG0Ey8_003D / _0023_003Dz1v6oPQk_003D);
				}
				else if (_0023_003DzB_0024jGmeI_003D[1] == 0)
				{
					_0023_003DzTx2aqr8_003D[1] = 3;
					_0023_003Dzk64JNOo_003D[1, 0] = _0023_003DznI_N5hw_003D[1];
					_0023_003Dzk64JNOo_003D[1, 1] = 1.0;
				}
				else
				{
					_0023_003DzTx2aqr8_003D[1] = 1;
					_0023_003Dzk64JNOo_003D[1, 0] = 1.0;
					_0023_003Dzk64JNOo_003D[1, 1] = _0023_003Dz5IigOWkZ7GyB(_0023_003Dz92Yz3QI_003D / _0023_003Dz1v6oPQk_003D);
				}
			}
			else
			{
				_0023_003DzTx2aqr8_003D[0] = 1;
				_0023_003Dzk64JNOo_003D[0, 0] = 1.0;
				_0023_003Dzk64JNOo_003D[0, 1] = _0023_003Dz5IigOWkZ7GyB(_0023_003Dz92Yz3QI_003D / _0023_003Dz1v6oPQk_003D);
				_0023_003DzTx2aqr8_003D[1] = ((_0023_003DzB_0024jGmeI_003D[1] == 0) ? 3 : 0);
				_0023_003Dzk64JNOo_003D[1, 0] = ((_0023_003DzB_0024jGmeI_003D[1] == 0) ? _0023_003DznI_N5hw_003D[1] : 0.0);
				_0023_003Dzk64JNOo_003D[1, 1] = ((_0023_003DzB_0024jGmeI_003D[1] == 0) ? 1.0 : _0023_003Dz5IigOWkZ7GyB(_0023_003Dz3cG0Ey8_003D / _0023_003Dz1v6oPQk_003D));
			}
		}

		private static void _0023_003DzR2ffzSD_00242pZl(int[] _0023_003DzTx2aqr8_003D, double[,] _0023_003Dzk64JNOo_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003Dzt_m8zV0_003D, double _0023_003DzbfrNXYE_003D, double _0023_003Dz5s4LStc_003D, double _0023_003DzvdOdqyI_003D, double _0023_003Dzzdvg8ho_003D, double _0023_003DzXVGE89M_003D, out double _0023_003DzuwH5j5s_003D, out double _0023_003DzNDQ_E88_003D)
		{
			double num = _0023_003Dzk64JNOo_003D[1, 1] - _0023_003Dzk64JNOo_003D[0, 1];
			double num2 = num * ((0.0 - _0023_003Dz1v6oPQk_003D) * _0023_003Dzk64JNOo_003D[0, 0] + _0023_003Dzt_m8zV0_003D * _0023_003Dzk64JNOo_003D[0, 1] - _0023_003DzbfrNXYE_003D);
			if (num2 >= 0.0)
			{
				_0023_003DzTfA94W4_003D(_0023_003DzTx2aqr8_003D[0], _0023_003Dz5s4LStc_003D, _0023_003DzvdOdqyI_003D, _0023_003Dzzdvg8ho_003D, _0023_003DzXVGE89M_003D, _0023_003Dzk64JNOo_003D[0, 0], _0023_003Dzk64JNOo_003D[0, 1], out _0023_003DzuwH5j5s_003D, out _0023_003DzNDQ_E88_003D);
				return;
			}
			double num3 = num * ((0.0 - _0023_003Dz1v6oPQk_003D) * _0023_003Dzk64JNOo_003D[1, 0] + _0023_003Dzt_m8zV0_003D * _0023_003Dzk64JNOo_003D[1, 1] - _0023_003DzbfrNXYE_003D);
			if (num3 <= 0.0)
			{
				_0023_003DzTfA94W4_003D(_0023_003DzTx2aqr8_003D[1], _0023_003Dz5s4LStc_003D, _0023_003DzvdOdqyI_003D, _0023_003Dzzdvg8ho_003D, _0023_003DzXVGE89M_003D, _0023_003Dzk64JNOo_003D[1, 0], _0023_003Dzk64JNOo_003D[1, 1], out _0023_003DzuwH5j5s_003D, out _0023_003DzNDQ_E88_003D);
				return;
			}
			double num4 = Math.Min(Math.Max(num2 / (num2 - num3), 0.0), 1.0);
			_0023_003DzuwH5j5s_003D = (1.0 - num4) * _0023_003Dzk64JNOo_003D[0, 0] + num4 * _0023_003Dzk64JNOo_003D[1, 0];
			_0023_003DzNDQ_E88_003D = (1.0 - num4) * _0023_003Dzk64JNOo_003D[0, 1] + num4 * _0023_003Dzk64JNOo_003D[1, 1];
		}

		private static void _0023_003DzTfA94W4_003D(int _0023_003DzTx2aqr8_003D, double _0023_003Dz5s4LStc_003D, double _0023_003DzvdOdqyI_003D, double _0023_003Dzzdvg8ho_003D, double _0023_003DzXVGE89M_003D, double _0023_003Dz9KUDgLg_003D, double _0023_003DzA43i_0024Yk_003D, out double _0023_003DzuwH5j5s_003D, out double _0023_003DzNDQ_E88_003D)
		{
			switch (_0023_003DzTx2aqr8_003D)
			{
			case 0:
				_0023_003DzuwH5j5s_003D = 0.0;
				_0023_003DzNDQ_E88_003D = _0023_003Dz8SdkRpxr4Y_tOUoVSQ_003D_003D(_0023_003Dzzdvg8ho_003D - _0023_003Dz5s4LStc_003D, _0023_003Dz5s4LStc_003D, _0023_003Dzzdvg8ho_003D);
				break;
			case 1:
				_0023_003DzuwH5j5s_003D = 1.0;
				_0023_003DzNDQ_E88_003D = _0023_003Dz8SdkRpxr4Y_tOUoVSQ_003D_003D(_0023_003DzXVGE89M_003D - _0023_003DzvdOdqyI_003D, _0023_003DzvdOdqyI_003D, _0023_003DzXVGE89M_003D);
				break;
			default:
				_0023_003DzuwH5j5s_003D = _0023_003Dz9KUDgLg_003D;
				_0023_003DzNDQ_E88_003D = _0023_003DzA43i_0024Yk_003D;
				break;
			}
		}

		private static double _0023_003Dz5IigOWkZ7GyB(double _0023_003DzBJFJHwk_003D)
		{
			if (!(_0023_003DzBJFJHwk_003D < -1E-09) && !(_0023_003DzBJFJHwk_003D > 1.000000001))
			{
				return _0023_003DzBJFJHwk_003D;
			}
			return 0.5;
		}
	}

	private sealed class _0023_003Dzl1OlBiRLsfSNb_CysYoiFP4_003D
	{
		public _0023_003DzAxDX21mgNPt_0024ivyAT9VKDgo_003D _0023_003Dzijt6ZVq8pKeJ00reCQ_003D_003D;

		public _0023_003DzGZh8_0024BDFfDuikVamog_003D_003D _0023_003DzUFpglTk_003D;

		internal _0023_003DzGWN_0024NEefZYXVbwUUmQ_003D_003D _0023_003DzIcdE4VCrFAxfOEvvX_0024clmHE0yOy4djhe5w_003D_003D()
		{
			return _0023_003Dzijt6ZVq8pKeJ00reCQ_003D_003D;
		}

		internal _0023_003DzGZh8_0024BDFfDuikVamog_003D_003D _0023_003Dz_0024Nc5YYGJPOaEYqJo_FFp1RFIG3iejFgW7g_003D_003D()
		{
			return _0023_003DzUFpglTk_003D._0023_003Dz_0024SpdFwY_003D();
		}
	}

	private sealed class _0023_003DzrDktkTxLXKA_0024 : _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzyzK8swU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003Dz8wjMonY_003D;

		public _0023_003DzrDktkTxLXKA_0024(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, int _0023_003DzyzK8swU_003D)
			: base(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D)
		{
			this._0023_003DzyzK8swU_003D = _0023_003DzyzK8swU_003D;
		}

		public _0023_003DzrDktkTxLXKA_0024(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, int _0023_003DzyzK8swU_003D, int _0023_003DzE8L7Q4w_003D)
			: base(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzE8L7Q4w_003D)
		{
			this._0023_003DzyzK8swU_003D = _0023_003DzyzK8swU_003D;
		}

		public _0023_003DzrDktkTxLXKA_0024(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzId5C3LA_003D)
			: base(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D)
		{
			_0023_003Dz8wjMonY_003D = _0023_003DzId5C3LA_003D;
		}

		public _0023_003DzrDktkTxLXKA_0024(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzId5C3LA_003D, int _0023_003DzE8L7Q4w_003D)
			: base(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzE8L7Q4w_003D)
		{
			_0023_003Dz8wjMonY_003D = _0023_003DzId5C3LA_003D;
		}
	}

	private sealed class _0023_003DzsCSRcdgSAaTUtL9m_65y0_A_003D
	{
		public SketchCurve _0023_003DzyGC5ZI76ZaE2HTUyhA_003D_003D;

		internal bool _0023_003Dzcz_2WbVdul1sYAFz5pJIY7CAgLfo(SketchCurve _0023_003Dzs_0024uS8LA_003D)
		{
			if (_0023_003Dzs_0024uS8LA_003D != null)
			{
				return _0023_003Dzs_0024uS8LA_003D != _0023_003DzyGC5ZI76ZaE2HTUyhA_003D_003D;
			}
			return false;
		}

		internal bool _0023_003DzwgQMe9HWWDdEfCo0JQkExJKb3Vz3(SketchCurve _0023_003Dzs_0024uS8LA_003D)
		{
			if (_0023_003Dzs_0024uS8LA_003D != null)
			{
				return _0023_003Dzs_0024uS8LA_003D != _0023_003DzyGC5ZI76ZaE2HTUyhA_003D_003D;
			}
			return false;
		}
	}

	internal static class _0023_003DztDh_5dSqxQPzO4_gIg_003D_003D
	{
		public static _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D _0023_003DzL9woobs_003D(Line _0023_003DzQ9zpGF0_003D, Circle _0023_003Dzw6jQxH4k7cf_0024, double _0023_003DzX0qX_IwWxysi, double _0023_003DzMEUbpswpbKiabgAa_7cSNZA9Nf2fUvQnVw_003D_003D)
		{
			_0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D2 = new _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D();
			_0023_003DzVOCYxDs_003D _0023_003Dzr_002480gG4_003D = new _0023_003DzVOCYxDs_003D();
			_0023_003Dz_IsqsVA_003D(_0023_003DzQ9zpGF0_003D, _0023_003Dzw6jQxH4k7cf_0024, _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D2, _0023_003Dzr_002480gG4_003D, _0023_003DzX0qX_IwWxysi, _0023_003DzMEUbpswpbKiabgAa_7cSNZA9Nf2fUvQnVw_003D_003D);
			return _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D2;
		}

		private static void _0023_003Dz_IsqsVA_003D(Line _0023_003DzQ9zpGF0_003D, Circle _0023_003Dzw6jQxH4k7cf_0024, _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D _0023_003DzOkHnHgY_003D, _0023_003DzVOCYxDs_003D _0023_003Dzr_002480gG4_003D, double _0023_003DzX0qX_IwWxysi, double _0023_003DzMEUbpswpbKiabgAa_7cSNZA9Nf2fUvQnVw_003D_003D)
		{
			double _0023_003DzccAR5G0_003D = Math.Min(_0023_003DzQ9zpGF0_003D.Length(), 2.0 * _0023_003Dzw6jQxH4k7cf_0024.Radius);
			Vector3D axisZ = _0023_003Dzw6jQxH4k7cf_0024.Plane.AxisZ;
			Vector3D direction = _0023_003DzQ9zpGF0_003D.Direction;
			Vector3D vector3D = new Vector3D(_0023_003Dzw6jQxH4k7cf_0024.Center, _0023_003DzQ9zpGF0_003D.StartPoint);
			Vector3D vector3D2 = Vector3D.Cross(axisZ, direction);
			Vector3D vector3D3 = Vector3D.Cross(axisZ, vector3D);
			if (!vector3D2.IsZero)
			{
				if (!vector3D3.IsZero)
				{
					_0023_003DzNcu7nbnNqIJyXtt2rJkxYxKSCUWP3EoH5Nrkf5FUMFLU(_0023_003DzQ9zpGF0_003D, _0023_003Dzw6jQxH4k7cf_0024, vector3D, vector3D2, vector3D3, _0023_003DzOkHnHgY_003D, _0023_003Dzr_002480gG4_003D, _0023_003DzX0qX_IwWxysi, _0023_003DzMEUbpswpbKiabgAa_7cSNZA9Nf2fUvQnVw_003D_003D, _0023_003DzccAR5G0_003D);
				}
				else
				{
					_0023_003DzlJSCeMEGUWE6R2f7vDLffXBaZiKmGiFx1Gckut3mm_0024QyJFrojYxMbIs_003D(_0023_003DzQ9zpGF0_003D, _0023_003Dzw6jQxH4k7cf_0024, vector3D, vector3D2, _0023_003DzOkHnHgY_003D, _0023_003Dzr_002480gG4_003D, _0023_003DzX0qX_IwWxysi, _0023_003DzccAR5G0_003D);
				}
			}
			else if (!vector3D3.IsZero)
			{
				_0023_003DzhecEz69RPgu9G5at3ImAlQu7s6xlQNxRNm4WULBFQgOn(_0023_003DzQ9zpGF0_003D, _0023_003Dzw6jQxH4k7cf_0024, vector3D, _0023_003DzOkHnHgY_003D, _0023_003Dzr_002480gG4_003D, _0023_003DzX0qX_IwWxysi, _0023_003DzccAR5G0_003D);
			}
			else
			{
				_0023_003DzRLRKEoG9q_0024o_0024lkgYskJ_nrhciOGPZ28_0024roKPJdc_003D(_0023_003DzQ9zpGF0_003D, _0023_003Dzw6jQxH4k7cf_0024, vector3D, _0023_003DzOkHnHgY_003D, _0023_003Dzr_002480gG4_003D, _0023_003DzX0qX_IwWxysi);
			}
		}

		private static void _0023_003DzRLRKEoG9q_0024o_0024lkgYskJ_nrhciOGPZ28_0024roKPJdc_003D(Line _0023_003DzQ9zpGF0_003D, Circle _0023_003Dzw6jQxH4k7cf_0024, Vector3D _0023_003DzK_0024fbiW0_003D, _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D _0023_003DzOkHnHgY_003D, _0023_003DzVOCYxDs_003D _0023_003Dzr_002480gG4_003D, double _0023_003DzX0qX_IwWxysi)
		{
			Vector3D direction = _0023_003DzQ9zpGF0_003D.Direction;
			Point3D center = _0023_003Dzw6jQxH4k7cf_0024.Center;
			Vector3D axisZ = _0023_003Dzw6jQxH4k7cf_0024.Plane.AxisZ;
			double radius = _0023_003Dzw6jQxH4k7cf_0024.Radius;
			_0023_003DzOkHnHgY_003D._0023_003DztSjubr_JXt59 = 1;
			_0023_003DzOkHnHgY_003D._0023_003DzOK_0024S8ThjuNW5[0] = center;
			Vector3D vector3D = _0023_003DzpxM4UT_0024GdDyXbSqq6g_003D_003D(axisZ);
			_0023_003DzOkHnHgY_003D._0023_003DzyUs6D9_SWs1i[0] = center + radius * vector3D;
			Vector3D vector3D2 = new Vector3D(_0023_003DzOkHnHgY_003D._0023_003DzyUs6D9_SWs1i[0], _0023_003DzOkHnHgY_003D._0023_003DzOK_0024S8ThjuNW5[0]);
			_0023_003DzOkHnHgY_003D._0023_003DzCZ6r8YUaZEiw = Vector3D.Dot(vector3D2, vector3D2);
			_0023_003DzOkHnHgY_003D._0023_003DzOxKU6GM_003D = Math.Sqrt(_0023_003DzOkHnHgY_003D._0023_003DzCZ6r8YUaZEiw);
			_0023_003DzOkHnHgY_003D._0023_003Dzsk2BQtp4tgbDO0Ghpw_003D_003D = true;
			_0023_003Dzr_002480gG4_003D._0023_003DzJi_U_DO0FYyE = 1;
			_0023_003Dzr_002480gG4_003D._0023_003DzJeFVES8kK6nS[0] = _0023_003DzOkHnHgY_003D._0023_003DzOK_0024S8ThjuNW5[0];
			_0023_003Dzr_002480gG4_003D._0023_003DzvTHGJgQ1ULAK[0] = _0023_003DzOkHnHgY_003D._0023_003DzyUs6D9_SWs1i[0];
			_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[0] = (0.0 - Vector3D.Dot(direction, _0023_003DzK_0024fbiW0_003D)) / Vector3D.Dot(direction, direction);
			_0023_003Dzr_002480gG4_003D._0023_003DzOxKU6GM_003D[0] = _0023_003DzOkHnHgY_003D._0023_003DzOxKU6GM_003D;
		}

		private static void _0023_003DzhecEz69RPgu9G5at3ImAlQu7s6xlQNxRNm4WULBFQgOn(Line _0023_003DzQ9zpGF0_003D, Circle _0023_003Dzw6jQxH4k7cf_0024, Vector3D _0023_003DzK_0024fbiW0_003D, _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D _0023_003DzOkHnHgY_003D, _0023_003DzVOCYxDs_003D _0023_003Dzr_002480gG4_003D, double _0023_003DzX0qX_IwWxysi, double _0023_003DzccAR5G0_003D)
		{
			Vector3D direction = _0023_003DzQ9zpGF0_003D.Direction;
			_0023_003Dzr_002480gG4_003D._0023_003DzJi_U_DO0FYyE = 1;
			_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[0] = (0.0 - Vector3D.Dot(direction, _0023_003DzK_0024fbiW0_003D)) / Vector3D.Dot(direction, direction);
			_0023_003DzcTaJVEs_003D(_0023_003DzQ9zpGF0_003D, _0023_003Dzw6jQxH4k7cf_0024, _0023_003DzK_0024fbiW0_003D, _0023_003DzOkHnHgY_003D, _0023_003Dzr_002480gG4_003D, _0023_003DzX0qX_IwWxysi, _0023_003DzccAR5G0_003D);
		}

		private static void _0023_003DzlJSCeMEGUWE6R2f7vDLffXBaZiKmGiFx1Gckut3mm_0024QyJFrojYxMbIs_003D(Line _0023_003DzQ9zpGF0_003D, Circle _0023_003Dzw6jQxH4k7cf_0024, Vector3D _0023_003DzK_0024fbiW0_003D, Vector3D _0023_003Dz9rbOQdk_003D, _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D _0023_003DzOkHnHgY_003D, _0023_003DzVOCYxDs_003D _0023_003Dzr_002480gG4_003D, double _0023_003DzX0qX_IwWxysi, double _0023_003DzccAR5G0_003D)
		{
			Vector3D direction = _0023_003DzQ9zpGF0_003D.Direction;
			double radius = _0023_003Dzw6jQxH4k7cf_0024.Radius;
			double num = Vector3D.Dot(direction, _0023_003DzK_0024fbiW0_003D);
			double num2 = Vector3D.Dot(direction, direction);
			double num3 = radius * _0023_003Dz9rbOQdk_003D.Length;
			_0023_003Dzr_002480gG4_003D._0023_003DzJi_U_DO0FYyE = 2;
			_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[0] = (0.0 - num - num3) / num2;
			_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[1] = (0.0 - num + num3) / num2;
			_0023_003DzcTaJVEs_003D(_0023_003DzQ9zpGF0_003D, _0023_003Dzw6jQxH4k7cf_0024, _0023_003DzK_0024fbiW0_003D, _0023_003DzOkHnHgY_003D, _0023_003Dzr_002480gG4_003D, _0023_003DzX0qX_IwWxysi, _0023_003DzccAR5G0_003D);
		}

		private static void _0023_003DzNcu7nbnNqIJyXtt2rJkxYxKSCUWP3EoH5Nrkf5FUMFLU(Line _0023_003DzQ9zpGF0_003D, Circle _0023_003Dzw6jQxH4k7cf_0024, Vector3D _0023_003DzK_0024fbiW0_003D, Vector3D _0023_003Dz9rbOQdk_003D, Vector3D _0023_003DzWDD8XwY_003D, _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D _0023_003DzOkHnHgY_003D, _0023_003DzVOCYxDs_003D _0023_003Dzr_002480gG4_003D, double _0023_003DzX0qX_IwWxysi, double _0023_003DzMEUbpswpbKiabgAa_7cSNZA9Nf2fUvQnVw_003D_003D, double _0023_003DzccAR5G0_003D)
		{
			Vector3D direction = _0023_003DzQ9zpGF0_003D.Direction;
			Vector3D axisZ = _0023_003Dzw6jQxH4k7cf_0024.Plane.AxisZ;
			double radius = _0023_003Dzw6jQxH4k7cf_0024.Radius;
			double num = Vector3D.Dot(_0023_003Dz9rbOQdk_003D, _0023_003Dz9rbOQdk_003D);
			double num2 = (0.0 - Vector3D.Dot(_0023_003Dz9rbOQdk_003D, _0023_003DzWDD8XwY_003D)) / num;
			Vector3D vector3D = _0023_003DzK_0024fbiW0_003D + num2 * direction;
			double num3 = Vector3D.Dot(direction, direction);
			Vector3D vector3D2 = Vector3D.Cross(axisZ, vector3D);
			double num4 = Vector3D.Dot(direction, vector3D) / num3;
			double num5 = radius * num / num3;
			double num6 = num;
			double num7 = Vector3D.Dot(vector3D2, vector3D2);
			if (num5 > Math.Sqrt(num7) + 1E-12)
			{
				double num8 = Math.Sqrt(Math.Abs(Math.Pow(num5 * num7, 2.0 / 3.0) - num7) / num6);
				double num9 = num5 * num8 / Math.Sqrt(num6 * num8 * num8 + num7) - num8;
				if (num4 < 0.0 - num9 - 1E-12)
				{
					double num10 = _0023_003Dz5x1jmM6qBqfUQzBPOg_003D_003D(num4, num5, num6, num7, 0.0 - num4, 0.0 - num4 + num5 / Math.Sqrt(num6), _0023_003DzMEUbpswpbKiabgAa_7cSNZA9Nf2fUvQnVw_003D_003D);
					if (num4 < 0.0 - num9 - 1E-12)
					{
						_0023_003Dzr_002480gG4_003D._0023_003DzJi_U_DO0FYyE = 1;
						_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[0] = num10 + num2;
					}
					else
					{
						_0023_003Dzr_002480gG4_003D._0023_003DzJi_U_DO0FYyE = 2;
						_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[0] = num10 + num2;
						_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[1] = 0.0 - num8 + num2;
					}
				}
				else if (num4 > num9 + 1E-12)
				{
					double num10 = _0023_003Dz5x1jmM6qBqfUQzBPOg_003D_003D(num4, num5, num6, num7, 0.0 - num4 - num5 / Math.Sqrt(num6), 0.0 - num4, _0023_003DzMEUbpswpbKiabgAa_7cSNZA9Nf2fUvQnVw_003D_003D);
					if (num4 > num9 + 1E-12)
					{
						_0023_003Dzr_002480gG4_003D._0023_003DzJi_U_DO0FYyE = 1;
						_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[0] = num10 + num2;
					}
					else
					{
						_0023_003Dzr_002480gG4_003D._0023_003DzJi_U_DO0FYyE = 2;
						_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[0] = num8 + num2;
						_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[1] = num10 + num2;
					}
				}
				else
				{
					_0023_003Dzr_002480gG4_003D._0023_003DzJi_U_DO0FYyE = 2;
					if (num4 > 1E-12)
					{
						double num10 = _0023_003Dz5x1jmM6qBqfUQzBPOg_003D_003D(num4, num5, num6, num7, 0.0 - num4 - num5 / Math.Sqrt(num6), 0.0 - num4, _0023_003DzMEUbpswpbKiabgAa_7cSNZA9Nf2fUvQnVw_003D_003D);
						_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[0] = num10 + num2;
						num10 = _0023_003Dz5x1jmM6qBqfUQzBPOg_003D_003D(num4, num5, num6, num7, 0.0 - num8, 0.0 - num4 + num5 / Math.Sqrt(num6), _0023_003DzMEUbpswpbKiabgAa_7cSNZA9Nf2fUvQnVw_003D_003D);
						_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[1] = num10 + num2;
					}
					else if (num4 < -1E-12)
					{
						double num10 = _0023_003Dz5x1jmM6qBqfUQzBPOg_003D_003D(num4, num5, num6, num7, 0.0 - num4 - num5 / Math.Sqrt(num6), 0.0 - num8, _0023_003DzMEUbpswpbKiabgAa_7cSNZA9Nf2fUvQnVw_003D_003D);
						_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[0] = num10 + num2;
						num10 = _0023_003Dz5x1jmM6qBqfUQzBPOg_003D_003D(num4, num5, num6, num7, 0.0 - num4, 0.0 - num4 + num5 / Math.Sqrt(num6), _0023_003DzMEUbpswpbKiabgAa_7cSNZA9Nf2fUvQnVw_003D_003D);
						_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[1] = num10 + num2;
					}
					else
					{
						double num10 = Math.Sqrt((num5 * num5 - num7) / num6);
						_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[0] = num2 - num10;
						_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[1] = num2 + num10;
					}
				}
			}
			else
			{
				double num10 = ((num4 < -1E-12) ? _0023_003Dz5x1jmM6qBqfUQzBPOg_003D_003D(num4, num5, num6, num7, 0.0 - num4, 0.0 - num4 + num5 / Math.Sqrt(num6), _0023_003DzMEUbpswpbKiabgAa_7cSNZA9Nf2fUvQnVw_003D_003D) : ((!(num4 > 1E-12)) ? 0.0 : _0023_003Dz5x1jmM6qBqfUQzBPOg_003D_003D(num4, num5, num6, num7, 0.0 - num4 - num5 / Math.Sqrt(num6), 0.0 - num4, _0023_003DzMEUbpswpbKiabgAa_7cSNZA9Nf2fUvQnVw_003D_003D)));
				_0023_003Dzr_002480gG4_003D._0023_003DzJi_U_DO0FYyE = 1;
				_0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[0] = num10 + num2;
			}
			_0023_003DzcTaJVEs_003D(_0023_003DzQ9zpGF0_003D, _0023_003Dzw6jQxH4k7cf_0024, _0023_003DzK_0024fbiW0_003D, _0023_003DzOkHnHgY_003D, _0023_003Dzr_002480gG4_003D, _0023_003DzX0qX_IwWxysi, _0023_003DzccAR5G0_003D);
		}

		private static void _0023_003DzcTaJVEs_003D(Line _0023_003DzQ9zpGF0_003D, Circle _0023_003Dzw6jQxH4k7cf_0024, Vector3D _0023_003DzK_0024fbiW0_003D, _0023_003DzUjShKgxoWegnK8Q1Cg_003D_003D _0023_003DzOkHnHgY_003D, _0023_003DzVOCYxDs_003D _0023_003Dzr_002480gG4_003D, double _0023_003DzX0qX_IwWxysi, double _0023_003DzccAR5G0_003D)
		{
			for (int i = 0; i < _0023_003Dzr_002480gG4_003D._0023_003DzJi_U_DO0FYyE; i++)
			{
				Vector3D vector3D = _0023_003Dzr_002480gG4_003D._0023_003DzmAHVzIc_003D[i] * _0023_003DzQ9zpGF0_003D.Direction + _0023_003DzK_0024fbiW0_003D;
				double num = Vector3D.Dot(_0023_003Dzw6jQxH4k7cf_0024.Plane.AxisZ, vector3D);
				(vector3D - num * _0023_003Dzw6jQxH4k7cf_0024.Plane.AxisZ).Normalize();
				_0023_003Dzr_002480gG4_003D._0023_003DzJeFVES8kK6nS[i] = vector3D + _0023_003Dzw6jQxH4k7cf_0024.Center;
				_0023_003DzQ9zpGF0_003D.ClosestPointTo(_0023_003Dzr_002480gG4_003D._0023_003DzJeFVES8kK6nS[i], out var t);
				_0023_003Dzr_002480gG4_003D._0023_003Dzujw274ll21y9[i] = t;
				_0023_003Dzr_002480gG4_003D._0023_003DzJeFVES8kK6nS[i] = _0023_003DzQ9zpGF0_003D.PointAt(t);
				_0023_003Dzw6jQxH4k7cf_0024.ClosestPointTo(_0023_003Dzr_002480gG4_003D._0023_003DzJeFVES8kK6nS[i], out var t2);
				_0023_003Dzr_002480gG4_003D._0023_003DzJZdh6hKL_zcF[i] = t2;
				_0023_003Dzr_002480gG4_003D._0023_003DzvTHGJgQ1ULAK[i] = _0023_003Dzw6jQxH4k7cf_0024.PointAt(t2);
				_0023_003Dzr_002480gG4_003D._0023_003DzOxKU6GM_003D[i] = Point3D.Distance(_0023_003Dzr_002480gG4_003D._0023_003DzJeFVES8kK6nS[i], _0023_003Dzr_002480gG4_003D._0023_003DzvTHGJgQ1ULAK[i]);
			}
			if (_0023_003Dzr_002480gG4_003D._0023_003DzJi_U_DO0FYyE == 1)
			{
				_0023_003DzOkHnHgY_003D._0023_003DztSjubr_JXt59 = 1;
				_0023_003DzOkHnHgY_003D._0023_003DzOxKU6GM_003D = _0023_003Dzr_002480gG4_003D._0023_003DzOxKU6GM_003D[0];
				_0023_003DzOkHnHgY_003D._0023_003DzOK_0024S8ThjuNW5[0] = _0023_003Dzr_002480gG4_003D._0023_003DzJeFVES8kK6nS[0];
				_0023_003DzOkHnHgY_003D._0023_003DzyUs6D9_SWs1i[0] = _0023_003Dzr_002480gG4_003D._0023_003DzvTHGJgQ1ULAK[0];
				_0023_003DzOkHnHgY_003D._0023_003DzqLMDDyVBo88_0024[0] = _0023_003Dzr_002480gG4_003D._0023_003Dzujw274ll21y9[0];
				_0023_003DzOkHnHgY_003D._0023_003DzlcY317DiY_0024sJ[0] = _0023_003Dzr_002480gG4_003D._0023_003DzJZdh6hKL_zcF[0];
			}
			else if (_0023_003Dzr_002480gG4_003D._0023_003DzOxKU6GM_003D[0] < _0023_003Dzr_002480gG4_003D._0023_003DzOxKU6GM_003D[1] - 1E-12)
			{
				_0023_003DzOkHnHgY_003D._0023_003DztSjubr_JXt59 = 1;
				_0023_003DzOkHnHgY_003D._0023_003DzOxKU6GM_003D = _0023_003Dzr_002480gG4_003D._0023_003DzOxKU6GM_003D[0];
				_0023_003DzOkHnHgY_003D._0023_003DzOK_0024S8ThjuNW5[0] = _0023_003Dzr_002480gG4_003D._0023_003DzJeFVES8kK6nS[0];
				_0023_003DzOkHnHgY_003D._0023_003DzyUs6D9_SWs1i[0] = _0023_003Dzr_002480gG4_003D._0023_003DzvTHGJgQ1ULAK[0];
				_0023_003DzOkHnHgY_003D._0023_003DzqLMDDyVBo88_0024[0] = _0023_003Dzr_002480gG4_003D._0023_003Dzujw274ll21y9[0];
				_0023_003DzOkHnHgY_003D._0023_003DzlcY317DiY_0024sJ[0] = _0023_003Dzr_002480gG4_003D._0023_003DzJZdh6hKL_zcF[0];
			}
			else if (_0023_003Dzr_002480gG4_003D._0023_003DzOxKU6GM_003D[0] > _0023_003Dzr_002480gG4_003D._0023_003DzOxKU6GM_003D[1] + 1E-12)
			{
				_0023_003DzOkHnHgY_003D._0023_003DztSjubr_JXt59 = 1;
				_0023_003DzOkHnHgY_003D._0023_003DzOxKU6GM_003D = _0023_003Dzr_002480gG4_003D._0023_003DzOxKU6GM_003D[1];
				_0023_003DzOkHnHgY_003D._0023_003DzOK_0024S8ThjuNW5[0] = _0023_003Dzr_002480gG4_003D._0023_003DzJeFVES8kK6nS[1];
				_0023_003DzOkHnHgY_003D._0023_003DzyUs6D9_SWs1i[0] = _0023_003Dzr_002480gG4_003D._0023_003DzvTHGJgQ1ULAK[1];
				_0023_003DzOkHnHgY_003D._0023_003DzqLMDDyVBo88_0024[0] = _0023_003Dzr_002480gG4_003D._0023_003Dzujw274ll21y9[1];
				_0023_003DzOkHnHgY_003D._0023_003DzlcY317DiY_0024sJ[0] = _0023_003Dzr_002480gG4_003D._0023_003DzJZdh6hKL_zcF[1];
			}
			else
			{
				_0023_003DzOkHnHgY_003D._0023_003DztSjubr_JXt59 = 2;
				_0023_003DzOkHnHgY_003D._0023_003DzOxKU6GM_003D = _0023_003Dzr_002480gG4_003D._0023_003DzOxKU6GM_003D[0];
				_0023_003DzOkHnHgY_003D._0023_003DzOK_0024S8ThjuNW5 = _0023_003Dzr_002480gG4_003D._0023_003DzJeFVES8kK6nS;
				_0023_003DzOkHnHgY_003D._0023_003DzyUs6D9_SWs1i = _0023_003Dzr_002480gG4_003D._0023_003DzvTHGJgQ1ULAK;
				_0023_003DzOkHnHgY_003D._0023_003DzqLMDDyVBo88_0024 = _0023_003Dzr_002480gG4_003D._0023_003Dzujw274ll21y9;
				_0023_003DzOkHnHgY_003D._0023_003DzlcY317DiY_0024sJ = _0023_003Dzr_002480gG4_003D._0023_003DzJZdh6hKL_zcF;
			}
			_0023_003DzOkHnHgY_003D._0023_003DzCZ6r8YUaZEiw = _0023_003DzOkHnHgY_003D._0023_003DzOxKU6GM_003D * _0023_003DzOkHnHgY_003D._0023_003DzOxKU6GM_003D;
			_0023_003DzOkHnHgY_003D._0023_003Dz7L3Iw6frIRXoyynokiNCmg4_003D = 0;
			for (int j = 0; j < _0023_003Dzr_002480gG4_003D._0023_003DzJi_U_DO0FYyE; j++)
			{
				if (_0023_003DzOkHnHgY_003D._0023_003Dz7L3Iw6frIRXoyynokiNCmg4_003D >= 2)
				{
					break;
				}
				if (_0023_003Dzr_002480gG4_003D._0023_003DzOxKU6GM_003D[j] > _0023_003DzX0qX_IwWxysi)
				{
					continue;
				}
				bool flag = false;
				for (int k = 0; k < _0023_003DzOkHnHgY_003D._0023_003Dz7L3Iw6frIRXoyynokiNCmg4_003D; k++)
				{
					if (Point3D.AreEqual(_0023_003DzOkHnHgY_003D._0023_003Dz6Iv8Vix9e_00249Dam0O_wtW0KY_003D[k].Item1, _0023_003Dzr_002480gG4_003D._0023_003DzJeFVES8kK6nS[j], _0023_003DzccAR5G0_003D * 1E-06))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					_0023_003DzOkHnHgY_003D._0023_003Dz6Iv8Vix9e_00249Dam0O_wtW0KY_003D[_0023_003DzOkHnHgY_003D._0023_003Dz7L3Iw6frIRXoyynokiNCmg4_003D++] = (_0023_003Dzr_002480gG4_003D._0023_003DzJeFVES8kK6nS[j], _0023_003Dzr_002480gG4_003D._0023_003DzvTHGJgQ1ULAK[j]);
				}
			}
		}

		private static double _0023_003Dz5x1jmM6qBqfUQzBPOg_003D_003D(double _0023_003DzJKjUKZ4_003D, double _0023_003DzH8_0024G110_003D, double _0023_003DzN9y2G9c_003D, double _0023_003DzQHRJkPc_003D, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, double _0023_003Dzm0CYiiE_003D)
		{
			for (int i = 0; i < 128; i++)
			{
				double num = 0.5 * (_0023_003DzF7v9r2A_003D + _0023_003Dz8dK2uhU_003D);
				double num2 = num + _0023_003DzJKjUKZ4_003D - _0023_003DzH8_0024G110_003D * num / Math.Sqrt(_0023_003DzN9y2G9c_003D * num * num + _0023_003DzQHRJkPc_003D);
				if (Math.Abs(_0023_003Dz8dK2uhU_003D - _0023_003DzF7v9r2A_003D) < _0023_003Dzm0CYiiE_003D)
				{
					return num;
				}
				if (num2 > 0.0)
				{
					_0023_003Dz8dK2uhU_003D = num;
				}
				else
				{
					_0023_003DzF7v9r2A_003D = num;
				}
			}
			return 0.5 * (_0023_003DzF7v9r2A_003D + _0023_003Dz8dK2uhU_003D);
		}

		private static Vector3D _0023_003DzpxM4UT_0024GdDyXbSqq6g_003D_003D(Vector3D _0023_003DzoMNiNRw_003D)
		{
			Vector3D obj = ((Math.Abs(_0023_003DzoMNiNRw_003D.X) > Math.Abs(_0023_003DzoMNiNRw_003D.Y)) ? new Vector3D(0.0 - _0023_003DzoMNiNRw_003D.Z, 0.0, _0023_003DzoMNiNRw_003D.X) : new Vector3D(0.0, _0023_003DzoMNiNRw_003D.Z, 0.0 - _0023_003DzoMNiNRw_003D.Y));
			obj.Normalize();
			return obj;
		}
	}

	internal enum _0023_003DzwhtOFTk_003D
	{

	}

	internal enum _0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D
	{

	}

	private sealed class _0023_003DzyqjkVjvyKwBNjbO6wr7yKtI_003D
	{
		public Vector<double> _0023_003DzuTkHiyI_003D;

		public Vector<double> _0023_003Dz0KVPVlc_003D;

		public Vector<double> _0023_003DzGRCZTwc_003D;

		internal Vector<double> _0023_003DqLIjCYu3ipLpf3SR2OUQdzBBZt_LjLuvwtI_00245HJNJ1LE_003D(Vector<double> _0023_003DzB68dg9Q_003D, Vector<double> _0023_003DzBJFJHwk_003D)
		{
			Vector<double> vector = CreateVector.DenseOfArray(new double[3]
			{
				_0023_003DzB68dg9Q_003D[0],
				_0023_003DzB68dg9Q_003D[1],
				_0023_003DzB68dg9Q_003D[2]
			});
			Vector<double> vector2 = CreateVector.DenseOfArray(new double[3]
			{
				_0023_003DzB68dg9Q_003D[3],
				_0023_003DzB68dg9Q_003D[4],
				_0023_003DzB68dg9Q_003D[5]
			});
			int num = _0023_003DzBJFJHwk_003D.Count();
			Vector<double> vector3 = CreateVector.Dense<double>(num);
			for (int i = 0; i < num; i++)
			{
				Vector<double> vector4 = CreateVector.DenseOfArray(new double[3]
				{
					_0023_003DzuTkHiyI_003D[i],
					_0023_003Dz0KVPVlc_003D[i],
					_0023_003DzGRCZTwc_003D[i]
				});
				Vector<double> vector5 = vector - vector4;
				double num2 = vector5 * vector2;
				vector3[i] = vector5 * vector5 - num2 * num2;
			}
			return vector3;
		}

		internal Matrix<double> _0023_003Dq5_W_0024D_0024sbGBiq6NpTAqr4Vabmfp5ogC_0024kWHdPp5dE7nc_003D(Vector<double> _0023_003DzB68dg9Q_003D, Vector<double> _0023_003DzBJFJHwk_003D)
		{
			Matrix<double> matrix = Matrix<double>.Build.Dense(_0023_003DzBJFJHwk_003D.Count, _0023_003DzB68dg9Q_003D.Count);
			Vector<double> vector = CreateVector.DenseOfArray(new double[3]
			{
				_0023_003DzB68dg9Q_003D[0],
				_0023_003DzB68dg9Q_003D[1],
				_0023_003DzB68dg9Q_003D[2]
			});
			Vector<double> vector2 = CreateVector.DenseOfArray(new double[3]
			{
				_0023_003DzB68dg9Q_003D[3],
				_0023_003DzB68dg9Q_003D[4],
				_0023_003DzB68dg9Q_003D[5]
			});
			int num = _0023_003DzBJFJHwk_003D.Count();
			for (int i = 0; i < num; i++)
			{
				Vector<double> vector3 = CreateVector.DenseOfArray(new double[3]
				{
					_0023_003DzuTkHiyI_003D[i],
					_0023_003Dz0KVPVlc_003D[i],
					_0023_003DzGRCZTwc_003D[i]
				});
				Vector<double> vector4 = vector - vector3;
				double num2 = vector4 * vector2;
				Vector<double> vector5 = -2.0 * (vector4 - num2 * vector2);
				Vector<double> vector6 = -2.0 * vector4 * num2;
				for (int j = 0; j < 3; j++)
				{
					matrix[i, j] = vector5[j];
					matrix[i, j + 3] = vector6[j];
				}
			}
			return matrix;
		}
	}

	internal delegate void drawCall(RenderContextBase context, IViewport viewport);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static double _0023_003DzJ2MUkYo_2suxunAM1w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static double _0023_003Dz0R0VnlsFvotrUgin2vSuPIQOfZ4SDyKBy8lWl9A_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static double _0023_003DzZwL_mB1yo4VmFIBV_0024ETVeRJs_0024mpOsYjRK4mRwEN9Emn6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static double _0023_003DzmJq0qCkmyW_ojQnBEK6tFMvwPBqiC7SchQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static double _0023_003DzBdlHahH_sn5_0cVpzJ_0024pzhGGFVyq5_aiECmXAR_0024dnNChzXciog_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string _0023_003DzbxpIQIB9BGm6f2E7IA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static double _0023_003Dzjyaz_Vfaky9X;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static double _0023_003DzxhnLabVjXjPg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static double _0023_003DzheSR8QM7q9ya;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static double _0023_003DzSNemwQo_003D;

	public const double ZERO_TOLERANCE = 1E-12;

	public const double SQRT2 = 1.4142135623730951;

	public const double SQRT3 = 1.7320508075688772;

	public const double SQRT3_OVER_2 = 0.8660254037844386;

	public const double SQRT2_OVER_2 = 0.7071067811865476;

	public const double TWO_PI = Math.PI * 2.0;

	public const double PI_2 = Math.PI / 2.0;

	public const double PI_6 = Math.PI / 6.0;

	public const double QUARTER_PI = Math.PI / 4.0;

	public const double THREE_QUARTER_PI = Math.PI * 3.0 / 4.0;

	public const double POS_MIN_DBL = 2.2250738585072014E-308;

	public const double EPSILON = 2.220446049250313E-16;

	public const double SQRT_EPSILON = 1.490116119385E-08;

	public const int HDLGRIDSPAN = 524288;

	public static readonly Dictionary<Tuple<linearUnitsType, linearUnitsType>, double> LinearConversionFactors;

	public static readonly Dictionary<Tuple<massUnitsType, massUnitsType>, double> MassConversionFactors;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly Dictionary<linearUnitsType, string> _0023_003DzVRB9mmcxMVKlbDTCC5ToBgU_003D;

	internal static ConcurrentBag<WeakReference<IWorkspaceInternal>> RuntimeInstances;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static int _0023_003DznQKUIDFq83WZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static int _0023_003DznQ8y5z6Ph4a5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static int _0023_003Dz9Eyky55oGfv3;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static licenseType ProductEdition => LicenseManager.ProductEdition;

	static Utility()
	{
		_0023_003DzJ2MUkYo_2suxunAM1w_003D_003D = 0.3;
		_0023_003Dz0R0VnlsFvotrUgin2vSuPIQOfZ4SDyKBy8lWl9A_003D = 0.02;
		_0023_003DzZwL_mB1yo4VmFIBV_0024ETVeRJs_0024mpOsYjRK4mRwEN9Emn6 = 0.00075;
		_0023_003DzmJq0qCkmyW_ojQnBEK6tFMvwPBqiC7SchQ_003D_003D = 2E-09;
		_0023_003DzBdlHahH_sn5_0cVpzJ_0024pzhGGFVyq5_aiECmXAR_0024dnNChzXciog_003D_003D = 0.05;
		_0023_003DzbxpIQIB9BGm6f2E7IA_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660176);
		LinearConversionFactors = new Dictionary<Tuple<linearUnitsType, linearUnitsType>, double>
		{
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Feet),
				0.0833333
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Miles),
				1.5783E-05
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Millimeters),
				25.4
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Centimeters),
				2.54
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Meters),
				0.0254
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Kilometers),
				2.54E-05
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Microinches),
				1000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Mils),
				1000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Yards),
				0.0277778
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Angstroms),
				254000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Nanometers),
				25400000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Microns),
				25400.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Decimeters),
				0.254
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Decameters),
				0.00254
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Hectometers),
				0.000254
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Gigameters),
				2.54E-11
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Astronomical),
				1.69789E-13
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.LightYears),
				2.68478E-18
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Inches, linearUnitsType.Parsecs),
				8.23158E-19
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Inches),
				12.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Miles),
				0.000189394
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Millimeters),
				304.8
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Centimeters),
				30.48
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Meters),
				0.3048
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Kilometers),
				0.0003048
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Microinches),
				12000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Mils),
				12000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Yards),
				0.333333
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Angstroms),
				3048000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Nanometers),
				304800000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Microns),
				304800.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Decimeters),
				3.048
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Decameters),
				0.03048
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Hectometers),
				0.003048
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Gigameters),
				3.048E-10
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Astronomical),
				2.03746E-12
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.LightYears),
				3.22174E-17
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Feet, linearUnitsType.Parsecs),
				9.8779E-18
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Inches),
				63360.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Feet),
				5280.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Millimeters),
				1609000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Centimeters),
				160934.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Meters),
				1609.34
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Kilometers),
				1.60934
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Microinches),
				63360000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Mils),
				63360000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Yards),
				1760.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Angstroms),
				16090000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Nanometers),
				1609000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Microns),
				1609000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Decimeters),
				16093.4
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Decameters),
				160.934
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Hectometers),
				16.0934
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Gigameters),
				1.6093E-06
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Astronomical),
				1.07578E-08
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.LightYears),
				1.70108E-13
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Miles, linearUnitsType.Parsecs),
				5.21553E-14
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Inches),
				0.0393701
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Feet),
				0.00328084
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Miles),
				6.2137E-07
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Centimeters),
				0.1
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Meters),
				0.001
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Kilometers),
				1E-06
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Microinches),
				39400.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Mils),
				39.3701
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Yards),
				0.00109361
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Angstroms),
				10000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Nanometers),
				1000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Microns),
				1000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Decimeters),
				0.01
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Decameters),
				0.0001
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Hectometers),
				1E-05
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Gigameters),
				1E-12
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Astronomical),
				6.68459E-15
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.LightYears),
				1.057E-19
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Millimeters, linearUnitsType.Parsecs),
				3.24078E-20
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Inches),
				0.393701
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Feet),
				0.0328084
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Miles),
				6.2137E-06
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Millimeters),
				10.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Meters),
				0.01
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Kilometers),
				1E-05
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Microinches),
				393700.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Mils),
				393.701
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Yards),
				0.0109361
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Angstroms),
				100000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Nanometers),
				10000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Microns),
				10000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Decimeters),
				0.1
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Decameters),
				0.001
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Hectometers),
				0.0001
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Gigameters),
				1E-11
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Astronomical),
				6.68459E-14
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.LightYears),
				1.057E-18
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Centimeters, linearUnitsType.Parsecs),
				3.24078E-19
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Inches),
				39.3701
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Feet),
				3.28084
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Miles),
				0.000621371
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Millimeters),
				1000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Centimeters),
				100.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Kilometers),
				0.001
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Microinches),
				39370080.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Mils),
				39370.1
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Yards),
				1.09361
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Angstroms),
				10000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Nanometers),
				1000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Microns),
				1000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Decimeters),
				10.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Decameters),
				0.1
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Hectometers),
				0.01
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Gigameters),
				1E-09
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Astronomical),
				6.68459E-12
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.LightYears),
				1.057E-16
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Meters, linearUnitsType.Parsecs),
				3.24078E-17
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Inches),
				39370.1
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Feet),
				3280.84
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Miles),
				0.621371
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Millimeters),
				1000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Centimeters),
				100000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Meters),
				1000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Microinches),
				39370080000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Mils),
				39370000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Yards),
				1093.61
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Angstroms),
				10000000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Nanometers),
				1000000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Microns),
				1000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Decimeters),
				10000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Decameters),
				100.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Hectometers),
				10.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Gigameters),
				1E-06
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Astronomical),
				6.68459E-09
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.LightYears),
				1.057E-13
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Kilometers, linearUnitsType.Parsecs),
				3.24078E-14
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Inches),
				1E-06
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Feet),
				8.33333333333E-08
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Miles),
				1.57828281218333E-11
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Millimeters),
				2.54E-05
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Centimeters),
				2.54E-06
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Meters),
				2.54E-08
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Kilometers),
				2.54E-11
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Mils),
				0.001
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Yards),
				2.7778E-08
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Angstroms),
				254.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Nanometers),
				25.4
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Microns),
				0.0254
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Decimeters),
				2.54E-07
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Decameters),
				2.54E-09
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Hectometers),
				2.54E-10
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Gigameters),
				2.54E-17
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Astronomical),
				1.6978836615463E-19
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.LightYears),
				2.6848394627619E-24
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microinches, linearUnitsType.Parsecs),
				8.2315796449919E-25
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Inches),
				0.001
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Feet),
				8.3333E-05
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Miles),
				1.57828E-08
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Millimeters),
				0.0254
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Centimeters),
				0.00254
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Meters),
				2.54E-05
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Kilometers),
				1.60934
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Microinches),
				1000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Yards),
				2.77778E-05
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Angstroms),
				254000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Nanometers),
				25400.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Microns),
				25.4
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Decimeters),
				0.000254
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Decameters),
				2.54E-06
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Hectometers),
				2.54E-07
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Gigameters),
				2.54E-14
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Astronomical),
				1.69789E-16
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.LightYears),
				2.68478E-21
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Mils, linearUnitsType.Parsecs),
				8.23158E-22
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Inches),
				36.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Feet),
				3.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Miles),
				0.000568182
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Millimeters),
				914.4
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Centimeters),
				91.44
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Meters),
				0.9144
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Kilometers),
				0.0009144
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Microinches),
				36000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Mils),
				36000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Angstroms),
				9144000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Nanometers),
				914400000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Microns),
				914400.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Decimeters),
				9.144
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Decameters),
				0.09144
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Hectometers),
				0.009144
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Gigameters),
				9.144E-10
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Astronomical),
				6.112386465E-12
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.LightYears),
				9.66522E-17
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Yards, linearUnitsType.Parsecs),
				2.96337E-17
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Inches),
				3.93701E-09
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Feet),
				3.28084E-10
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Miles),
				6.21371E-14
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Millimeters),
				1E-07
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Centimeters),
				1E-08
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Meters),
				1E-10
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Kilometers),
				1E-13
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Microinches),
				0.00393701
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Mils),
				3.93701E-06
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Yards),
				1.09361E-10
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Nanometers),
				0.1
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Microns),
				0.0001
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Decimeters),
				1E-09
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Decameters),
				1E-11
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Hectometers),
				1E-12
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Gigameters),
				1E-19
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Astronomical),
				6.68459E-22
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.LightYears),
				1.057E-26
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Angstroms, linearUnitsType.Parsecs),
				3.24078E-27
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Inches),
				3.93701E-08
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Feet),
				3.28084E-09
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Miles),
				6.21371E-13
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Millimeters),
				1E-06
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Centimeters),
				1E-07
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Meters),
				1E-09
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Kilometers),
				1E-12
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Microinches),
				0.039370079
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Mils),
				3.93701E-05
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Yards),
				1.09361E-09
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Angstroms),
				10.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Microns),
				0.001
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Decimeters),
				1E-08
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Decameters),
				1E-10
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Hectometers),
				1E-11
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Gigameters),
				1E-18
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Astronomical),
				6.68459E-21
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.LightYears),
				1.057E-25
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Nanometers, linearUnitsType.Parsecs),
				3.24078E-26
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Inches),
				3.93701E-05
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Feet),
				3.28084E-06
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Miles),
				6.21371E-10
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Millimeters),
				0.001
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Centimeters),
				0.0001
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Meters),
				1E-06
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Kilometers),
				1E-09
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Microinches),
				39.37007874015748
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Mils),
				0.0393701
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Yards),
				1.09361E-06
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Angstroms),
				10000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Nanometers),
				1000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Decimeters),
				1E-05
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Decameters),
				1E-07
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Hectometers),
				1E-08
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Gigameters),
				1E-15
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Astronomical),
				6.68459E-18
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.LightYears),
				1.057E-22
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Microns, linearUnitsType.Parsecs),
				3.24078E-23
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Inches),
				3.93701
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Feet),
				0.328084
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Miles),
				6.21371E-05
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Millimeters),
				100.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Centimeters),
				10.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Meters),
				0.1
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Kilometers),
				0.0001
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Microinches),
				3937010.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Mils),
				3937.01
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Yards),
				0.109361
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Angstroms),
				1000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Nanometers),
				100000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Microns),
				100000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Decameters),
				0.01
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Hectometers),
				0.001
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Gigameters),
				1E-10
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Astronomical),
				6.68459E-13
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.LightYears),
				1.057E-17
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decimeters, linearUnitsType.Parsecs),
				3.24078E-18
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Inches),
				393.701
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Feet),
				32.8084
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Miles),
				0.00621371
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Millimeters),
				10000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Centimeters),
				1000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Meters),
				10.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Kilometers),
				0.01
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Microinches),
				393700787.4
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Mils),
				393701.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Yards),
				10.9361
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Angstroms),
				100000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Nanometers),
				10000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Microns),
				10000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Decimeters),
				100.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Hectometers),
				0.1
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Gigameters),
				1E-08
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Astronomical),
				6.68459E-11
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.LightYears),
				1.057E-15
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Decameters, linearUnitsType.Parsecs),
				3.24078E-16
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Inches),
				3937.01
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Feet),
				328.084
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Miles),
				0.0621371
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Millimeters),
				100000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Centimeters),
				10000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Meters),
				100.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Kilometers),
				0.1
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Microinches),
				3937007874.02
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Mils),
				3937000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Yards),
				109.361
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Angstroms),
				1000000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Nanometers),
				100000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Microns),
				100000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Decimeters),
				1000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Decameters),
				10.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Gigameters),
				1E-07
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Astronomical),
				6.68459E-10
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.LightYears),
				1.057E-14
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Hectometers, linearUnitsType.Parsecs),
				3.24078E-15
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Inches),
				39370000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Feet),
				3281000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Miles),
				621371.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Millimeters),
				1000000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Centimeters),
				100000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Meters),
				1000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Kilometers),
				1000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Microinches),
				39370078740200000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Mils),
				39370000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Yards),
				1094000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Angstroms),
				1E+19
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Nanometers),
				1E+18
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Microns),
				1000000000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Decimeters),
				10000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Decameters),
				100000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Hectometers),
				10000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Astronomical),
				0.00668459
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.LightYears),
				1.057E-07
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Gigameters, linearUnitsType.Parsecs),
				3.24078E-08
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Inches),
				5890000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Feet),
				490800000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Miles),
				92960000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Millimeters),
				149600000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Centimeters),
				14960000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Meters),
				149600000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Kilometers),
				149600000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Microinches),
				5.889679948E+18
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Mils),
				5889679948000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Yards),
				163600000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Angstroms),
				1.496E+21
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Nanometers),
				1.496E+20
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Microns),
				1.496E+17
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Decimeters),
				1496000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Decameters),
				14960000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Hectometers),
				1496000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Gigameters),
				149.598
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.LightYears),
				1.58125E-05
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Astronomical, linearUnitsType.Parsecs),
				4.84814E-06
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Inches),
				3.725E+17
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Feet),
				31040000000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Miles),
				5879000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Millimeters),
				9.461E+18
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Centimeters),
				9.461E+17
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Meters),
				9461000000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Kilometers),
				9461000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Microinches),
				3.724697036449134E+23
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Mils),
				3.725E+20
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Yards),
				10350000000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Angstroms),
				9.461E+25
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Nanometers),
				9.461E+24
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Microns),
				9.461E+21
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Decimeters),
				94610000000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Decameters),
				946100000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Hectometers),
				94610000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Gigameters),
				9461000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Astronomical),
				63241.1
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.LightYears, linearUnitsType.Parsecs),
				0.306601
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Inches),
				1.215E+18
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Feet),
				1.012E+17
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Miles),
				19170000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Millimeters),
				3.086E+19
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Centimeters),
				3.086E+18
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Meters),
				30860000000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Kilometers),
				30860000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Microinches),
				1.21483370079E+24
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Mils),
				1.215E+21
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Yards),
				33750000000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Angstroms),
				3.086E+26
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Nanometers),
				3.086E+25
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Microns),
				3.086E+22
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Decimeters),
				3.086E+17
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Decameters),
				3086000000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Hectometers),
				308600000000000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Gigameters),
				30860000.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.Astronomical),
				206265.0
			},
			{
				new Tuple<linearUnitsType, linearUnitsType>(linearUnitsType.Parsecs, linearUnitsType.LightYears),
				3.26156
			}
		};
		MassConversionFactors = new Dictionary<Tuple<massUnitsType, massUnitsType>, double>
		{
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Micrograms, massUnitsType.Micrograms),
				1.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Micrograms, massUnitsType.Milligrams),
				0.001
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Micrograms, massUnitsType.Grams),
				1E-06
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Micrograms, massUnitsType.Kilograms),
				1E-09
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Micrograms, massUnitsType.Tons),
				1E-12
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Micrograms, massUnitsType.Ounces),
				3.5274E-08
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Micrograms, massUnitsType.Pounds),
				2.2046E-09
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Micrograms, massUnitsType.Stones),
				1.5747E-10
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Micrograms, massUnitsType.ShortTons),
				1.1023E-12
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Micrograms, massUnitsType.LongTons),
				9.841964286679E-13
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Milligrams, massUnitsType.Micrograms),
				1000.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Milligrams, massUnitsType.Milligrams),
				1.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Milligrams, massUnitsType.Grams),
				0.001
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Milligrams, massUnitsType.Kilograms),
				1E-06
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Milligrams, massUnitsType.Tons),
				1E-09
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Milligrams, massUnitsType.Ounces),
				3.5274E-05
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Milligrams, massUnitsType.Pounds),
				2.2046E-06
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Milligrams, massUnitsType.Stones),
				1.5747E-07
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Milligrams, massUnitsType.ShortTons),
				1.1023E-09
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Milligrams, massUnitsType.LongTons),
				9.841964286679E-10
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Grams, massUnitsType.Micrograms),
				1000000.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Grams, massUnitsType.Milligrams),
				1000.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Grams, massUnitsType.Grams),
				1.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Grams, massUnitsType.Kilograms),
				0.001
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Grams, massUnitsType.Tons),
				1E-06
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Grams, massUnitsType.Ounces),
				0.035274
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Grams, massUnitsType.Pounds),
				0.0022046
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Grams, massUnitsType.Stones),
				0.00015747
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Grams, massUnitsType.ShortTons),
				1.1023E-06
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Grams, massUnitsType.LongTons),
				9.841964286679E-07
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Kilograms, massUnitsType.Micrograms),
				1000000000.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Kilograms, massUnitsType.Milligrams),
				1000000.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Kilograms, massUnitsType.Grams),
				1000.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Kilograms, massUnitsType.Kilograms),
				1.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Kilograms, massUnitsType.Tons),
				0.001
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Kilograms, massUnitsType.Ounces),
				35.274
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Kilograms, massUnitsType.Pounds),
				2.2046
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Kilograms, massUnitsType.Stones),
				0.15747
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Kilograms, massUnitsType.ShortTons),
				0.0011023
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Kilograms, massUnitsType.LongTons),
				0.0009841964286679
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Tons, massUnitsType.Micrograms),
				1000000000000.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Tons, massUnitsType.Milligrams),
				1000000000.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Tons, massUnitsType.Grams),
				1000000.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Tons, massUnitsType.Kilograms),
				1000.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Tons, massUnitsType.Tons),
				1.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Tons, massUnitsType.Ounces),
				35274.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Tons, massUnitsType.Pounds),
				5.2046
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Tons, massUnitsType.Stones),
				157.47
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Tons, massUnitsType.ShortTons),
				1.1023
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Tons, massUnitsType.LongTons),
				0.9841964286679
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Ounces, massUnitsType.Micrograms),
				28350000.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Ounces, massUnitsType.Milligrams),
				28350.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Ounces, massUnitsType.Grams),
				28.35
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Ounces, massUnitsType.Kilograms),
				0.02835
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Ounces, massUnitsType.Tons),
				2.835E-05
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Ounces, massUnitsType.Ounces),
				1.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Ounces, massUnitsType.Pounds),
				0.0625
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Ounces, massUnitsType.Stones),
				0.00446429
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Ounces, massUnitsType.ShortTons),
				3.125003E-05
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Ounces, massUnitsType.LongTons),
				2.79018125E-05
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Pounds, massUnitsType.Micrograms),
				453592805.4487
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Pounds, massUnitsType.Milligrams),
				453592.8054487001
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Pounds, massUnitsType.Grams),
				453.59280544870006
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Pounds, massUnitsType.Kilograms),
				0.45359280544870006
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Pounds, massUnitsType.Tons),
				0.0004535928054487001
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Pounds, massUnitsType.Ounces),
				16.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Pounds, massUnitsType.Pounds),
				1.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Pounds, massUnitsType.Stones),
				0.0714286
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Pounds, massUnitsType.ShortTons),
				0.0005000002
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Pounds, massUnitsType.LongTons),
				0.00044642875
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Stones, massUnitsType.Micrograms),
				6350295720.12
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Stones, massUnitsType.Milligrams),
				6350295.720119997
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Stones, massUnitsType.Grams),
				6350.295720119996
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Stones, massUnitsType.Kilograms),
				6.3502957201199965
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Stones, massUnitsType.Tons),
				0.006350295720119996
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Stones, massUnitsType.Ounces),
				224.0000896000961
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Stones, massUnitsType.Pounds),
				14.000005600006006
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Stones, massUnitsType.Stones),
				1.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Stones, massUnitsType.ShortTons),
				0.007000002800003003
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.Stones, massUnitsType.LongTons),
				0.006250002500002682
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.ShortTons, massUnitsType.Micrograms),
				907185102874.2852
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.ShortTons, massUnitsType.Milligrams),
				907185102.8742852
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.ShortTons, massUnitsType.Grams),
				907185.1028742852
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.ShortTons, massUnitsType.Kilograms),
				907.1851028742852
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.ShortTons, massUnitsType.Tons),
				0.9071851028742852
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.ShortTons, massUnitsType.Ounces),
				32000.012800013727
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.ShortTons, massUnitsType.Pounds),
				2000.000800000858
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.ShortTons, massUnitsType.Stones),
				142.85720000006128
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.ShortTons, massUnitsType.ShortTons),
				1.0
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.ShortTons, massUnitsType.LongTons),
				0.8928575000003831
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.LongTons, massUnitsType.Micrograms),
				1016047315219.1993
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.LongTons, massUnitsType.Milligrams),
				1016047315.2191994
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.LongTons, massUnitsType.Grams),
				1016047.3152191994
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.LongTons, massUnitsType.Kilograms),
				1016.0473152191994
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.LongTons, massUnitsType.Tons),
				1.0160473152191993
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.LongTons, massUnitsType.Ounces),
				35840.014336015374
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.LongTons, massUnitsType.Pounds),
				2240.000896000961
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.LongTons, massUnitsType.Stones),
				160.00006400006862
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.LongTons, massUnitsType.ShortTons),
				1.1200004480004804
			},
			{
				new Tuple<massUnitsType, massUnitsType>(massUnitsType.LongTons, massUnitsType.LongTons),
				1.0
			}
		};
		_0023_003DzVRB9mmcxMVKlbDTCC5ToBgU_003D = new Dictionary<linearUnitsType, string>
		{
			{
				linearUnitsType.Unitless,
				string.Empty
			},
			{
				linearUnitsType.Inches,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994950)
			},
			{
				linearUnitsType.Feet,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660301)
			},
			{
				linearUnitsType.Miles,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660280)
			},
			{
				linearUnitsType.Millimeters,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994957)
			},
			{
				linearUnitsType.Centimeters,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660287)
			},
			{
				linearUnitsType.Meters,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660266)
			},
			{
				linearUnitsType.Kilometers,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660242)
			},
			{
				linearUnitsType.Microinches,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660249)
			},
			{
				linearUnitsType.Mils,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660227)
			},
			{
				linearUnitsType.Yards,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660237)
			},
			{
				linearUnitsType.Angstroms,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660984)
			},
			{
				linearUnitsType.Nanometers,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660992)
			},
			{
				linearUnitsType.Microns,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660967)
			},
			{
				linearUnitsType.Decimeters,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660946)
			},
			{
				linearUnitsType.Decameters,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660953)
			},
			{
				linearUnitsType.Hectometers,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660931)
			},
			{
				linearUnitsType.Gigameters,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660942)
			},
			{
				linearUnitsType.Astronomical,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660917)
			},
			{
				linearUnitsType.LightYears,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660928)
			},
			{
				linearUnitsType.Parsecs,
				_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660903)
			},
			{
				linearUnitsType.NotSupported,
				string.Empty
			}
		};
		RuntimeInstances = new ConcurrentBag<WeakReference<IWorkspaceInternal>>();
		_0023_003DznQKUIDFq83WZ = 0;
		_0023_003DznQ8y5z6Ph4a5 = 0;
		_0023_003Dz9Eyky55oGfv3 = 0;
		_0023_003DzzpnSohNwUKjz4kUOef2slQo_003D();
	}

	internal static void _0023_003DzJf6X3nCs4sU4hFurtQ_003D_003D(byte[] _0023_003DzHsJk8twlh_mh, string _0023_003Dzg5oC_Hs_003D)
	{
		_0023_003DzizOTGs6OhkvTwbV4K_00245jooA_003D(_0023_003DzHsJk8twlh_mh, _0023_003Dzg5oC_Hs_003D);
	}

	private static void _0023_003DzizOTGs6OhkvTwbV4K_00245jooA_003D(byte[] _0023_003DzHsJk8twlh_mh, string _0023_003Dzg5oC_Hs_003D)
	{
		MemoryStream memoryStream = new MemoryStream(_0023_003DzHsJk8twlh_mh);
		try
		{
			using Image image = Image.FromStream(memoryStream);
			EncoderParameters encoderParameters = new EncoderParameters(3);
			ImageCodecInfo encoder = null;
			encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
			encoderParameters.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.ScanMethod, 7);
			encoderParameters.Param[2] = new EncoderParameter(System.Drawing.Imaging.Encoder.RenderMethod, 11);
			ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
			foreach (ImageCodecInfo imageCodecInfo in imageEncoders)
			{
				if (imageCodecInfo.MimeType == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660882))
				{
					encoder = imageCodecInfo;
				}
			}
			try
			{
				image.Save(_0023_003Dzg5oC_Hs_003D, encoder, encoderParameters);
			}
			finally
			{
				for (int j = 0; j < encoderParameters.Param.Length; j++)
				{
					encoderParameters.Param[j].Dispose();
				}
				encoderParameters.Dispose();
			}
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	internal static byte[] _0023_003DzhcaSq4WPuiVgYw2C0Q_003D_003D(byte[] _0023_003DzHsJk8twlh_mh)
	{
		MemoryStream memoryStream = new MemoryStream(_0023_003DzHsJk8twlh_mh);
		try
		{
			using Image image = Image.FromStream(memoryStream);
			try
			{
				MemoryStream memoryStream2 = new MemoryStream();
				try
				{
					image.Save(memoryStream2, ImageFormat.Png);
					return memoryStream2.ToArray();
				}
				finally
				{
					((IDisposable)memoryStream2).Dispose();
				}
			}
			catch
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660865));
			}
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	internal static byte[] _0023_003DzIpZE2cw6usPZ(Stream _0023_003DzbJnUyjhuUtKT)
	{
		using Image _0023_003DzqwYd0N8_003D = Image.FromStream(_0023_003DzbJnUyjhuUtKT);
		return _0023_003DzIpZE2cw6usPZ(_0023_003DzqwYd0N8_003D);
	}

	internal static byte[] _0023_003DzIpZE2cw6usPZ(string _0023_003Dzg5oC_Hs_003D)
	{
		if (IsUnsupportedFormat(_0023_003Dzg5oC_Hs_003D))
		{
			return null;
		}
		return File.ReadAllBytes(_0023_003Dzg5oC_Hs_003D);
	}

	internal static bool IsUnsupportedFormat(string _0023_003Dzg5oC_Hs_003D)
	{
		string text = Path.GetExtension(_0023_003Dzg5oC_Hs_003D).ToUpper();
		if (text != null)
		{
			int length = text.Length;
			if (length != 4)
			{
				if (length == 5)
				{
					char c = text[1];
					if (c != 'E')
					{
						if (c != 'J')
						{
							if (c == 'T' && text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661014))
							{
								goto IL_011c;
							}
						}
						else if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661034))
						{
							goto IL_011c;
						}
					}
					else if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661054))
					{
						goto IL_011c;
					}
				}
			}
			else
			{
				char c = text[1];
				if ((uint)c <= 71u)
				{
					if (c != 'B')
					{
						if (c == 'G' && text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661074))
						{
							goto IL_011c;
						}
					}
					else if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661093))
					{
						goto IL_011c;
					}
				}
				else if (c != 'J')
				{
					if (c != 'P')
					{
						if (c == 'T' && text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661041))
						{
							goto IL_011c;
						}
					}
					else if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661064))
					{
						goto IL_011c;
					}
				}
				else if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661083))
				{
					goto IL_011c;
				}
			}
		}
		return true;
		IL_011c:
		return false;
	}

	private static byte[] _0023_003DzIpZE2cw6usPZ(Image _0023_003DzqwYd0N8_003D)
	{
		if (_0023_003DzqwYd0N8_003D != null)
		{
			return (byte[])new ImageConverter().ConvertTo(_0023_003DzqwYd0N8_003D, typeof(byte[]));
		}
		return null;
	}

	internal static Size _0023_003Dz0liNYAxTbMhp(byte[] _0023_003DzHsJk8twlh_mh)
	{
		return _0023_003DzoNUC6j_0024pCiPlYUweuA_003D_003D(_0023_003DzHsJk8twlh_mh);
	}

	private static Size _0023_003DzoNUC6j_0024pCiPlYUweuA_003D_003D(byte[] _0023_003DzHsJk8twlh_mh)
	{
		MemoryStream memoryStream = new MemoryStream(_0023_003DzHsJk8twlh_mh);
		try
		{
			using Image image = Image.FromStream(memoryStream);
			return image.Size;
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	internal static byte[] _0023_003DzDohpCTS_V8wx(byte[] _0023_003DzHsJk8twlh_mh, int _0023_003Dz6tVBpdk_003D, int _0023_003DzvAxV_0024Ic_003D)
	{
		return _0023_003DzbIQmQDvKMLn_41mpGA_003D_003D(_0023_003DzHsJk8twlh_mh, _0023_003Dz6tVBpdk_003D, _0023_003DzvAxV_0024Ic_003D);
	}

	private static byte[] _0023_003DzbIQmQDvKMLn_41mpGA_003D_003D(byte[] _0023_003DzHsJk8twlh_mh, int _0023_003Dz6tVBpdk_003D, int _0023_003DzvAxV_0024Ic_003D)
	{
		Bitmap bitmap = null;
		try
		{
			MemoryStream memoryStream = new MemoryStream(_0023_003DzHsJk8twlh_mh);
			try
			{
				using Image image = Image.FromStream(memoryStream);
				if (image.PixelFormat == PixelFormat.Indexed || image.PixelFormat == PixelFormat.Format1bppIndexed || image.PixelFormat == PixelFormat.Format4bppIndexed || image.PixelFormat == PixelFormat.Format8bppIndexed)
				{
					bitmap = new Bitmap(_0023_003Dz6tVBpdk_003D, _0023_003DzvAxV_0024Ic_003D, PixelFormat.Format32bppArgb);
					Bitmap bitmap2 = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
					try
					{
						using System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap2);
						graphics.DrawImage(bitmap, 0, 0);
					}
					finally
					{
						((IDisposable)bitmap2).Dispose();
					}
				}
				else
				{
					bitmap = new Bitmap(_0023_003Dz6tVBpdk_003D, _0023_003DzvAxV_0024Ic_003D, image.PixelFormat);
				}
				using (System.Drawing.Graphics graphics2 = System.Drawing.Graphics.FromImage(bitmap))
				{
					ImageAttributes imageAttributes = new ImageAttributes();
					try
					{
						imageAttributes.SetWrapMode(WrapMode.TileFlipXY);
						graphics2.InterpolationMode = InterpolationMode.HighQualityBicubic;
						graphics2.DrawImage(image, Rectangle.FromLTRB(0, 0, _0023_003Dz6tVBpdk_003D, _0023_003DzvAxV_0024Ic_003D), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
					}
					finally
					{
						((IDisposable)imageAttributes).Dispose();
					}
				}
				return _0023_003DzIpZE2cw6usPZ(bitmap);
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		catch
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660994));
		}
		finally
		{
			bitmap?.Dispose();
		}
	}

	internal static string _0023_003DzbVn8_FIsct0h(byte[] _0023_003DzHsJk8twlh_mh)
	{
		return _0023_003DzZrUR2A3LUuhu7dly4A_003D_003D(_0023_003DzHsJk8twlh_mh);
	}

	private static string _0023_003DzZrUR2A3LUuhu7dly4A_003D_003D(byte[] _0023_003DzHsJk8twlh_mh)
	{
		MemoryStream memoryStream = new MemoryStream(_0023_003DzHsJk8twlh_mh);
		try
		{
			_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2 = new _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D();
			_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzqwYd0N8_003D = Image.FromStream(memoryStream);
			try
			{
				return ImageCodecInfo.GetImageEncoders().First(_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzKfdrp1yMG3Mms7G3Kl6W5KnTfTVQ).FilenameExtension.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries).First().Trim('*')
					.Trim('.')
					.ToLower();
			}
			catch (Exception)
			{
				return _0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzqwYd0N8_003D.RawFormat.ToString().ToLower();
			}
			finally
			{
				if (_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzqwYd0N8_003D != null)
				{
					((IDisposable)_0023_003Dz0rCQTIIyEsUYFVe50Uh9JuA_003D2._0023_003DzqwYd0N8_003D).Dispose();
				}
			}
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	internal static bool _0023_003DzEZap865nk78Y(byte[] _0023_003DzHsJk8twlh_mh)
	{
		return _0023_003DzQcxnpg1fmNowmchDCQ_003D_003D(_0023_003DzHsJk8twlh_mh);
	}

	private static bool _0023_003DzQcxnpg1fmNowmchDCQ_003D_003D(byte[] _0023_003DzHsJk8twlh_mh)
	{
		MemoryStream memoryStream = new MemoryStream(_0023_003DzHsJk8twlh_mh);
		try
		{
			Bitmap bitmap = new Bitmap(Image.FromStream(memoryStream, useEmbeddedColorManagement: true));
			try
			{
				if ((bitmap.Flags & 2) == 0)
				{
					return false;
				}
				if ((bitmap.PixelFormat & PixelFormat.Indexed) != PixelFormat.Undefined && bitmap.Palette.Entries.All(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzGkSe424KGQihHDQLYZXyvmE_arJx))
				{
					return false;
				}
				BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
				int num = bitmap.Height * bitmapData.Stride;
				byte[] array = new byte[num];
				Marshal.Copy(bitmapData.Scan0, array, 0, num);
				bitmap.UnlockBits(bitmapData);
				for (int i = 3; i < num; i += 4)
				{
					if (array[i] != byte.MaxValue)
					{
						return true;
					}
				}
				return false;
			}
			finally
			{
				((IDisposable)bitmap).Dispose();
			}
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	internal static Exception GetRealException(Exception _0023_003Dz28FDiEs_003D)
	{
		Exception ex = _0023_003Dz28FDiEs_003D;
		while (ex.InnerException != null)
		{
			ex = ex.InnerException;
		}
		return ex;
	}

	internal static void NormalizeBox(ref System.Drawing.Point _0023_003DzFj_0024IqDQ_003D, ref System.Drawing.Point _0023_003DzjdeMMkk_003D)
	{
		int x = Math.Min(_0023_003DzFj_0024IqDQ_003D.X, _0023_003DzjdeMMkk_003D.X);
		int y = Math.Min(_0023_003DzFj_0024IqDQ_003D.Y, _0023_003DzjdeMMkk_003D.Y);
		int x2 = Math.Max(_0023_003DzFj_0024IqDQ_003D.X, _0023_003DzjdeMMkk_003D.X);
		int y2 = Math.Max(_0023_003DzFj_0024IqDQ_003D.Y, _0023_003DzjdeMMkk_003D.Y);
		_0023_003DzFj_0024IqDQ_003D.X = x;
		_0023_003DzFj_0024IqDQ_003D.Y = y;
		_0023_003DzjdeMMkk_003D.X = x2;
		_0023_003DzjdeMMkk_003D.Y = y2;
	}

	internal static double _0023_003DzcWsuvoQfLK3L(Entity _0023_003Dzs_0024uS8LA_003D)
	{
		Point3D[] array = _0023_003Dzs_0024uS8LA_003D.EstimateBoundingBox(null, null);
		Point3D maxValue = Point3D.MaxValue;
		Point3D minValue = Point3D.MinValue;
		UpdateMinMax(null, array, array.Length, maxValue, minValue);
		double num = new Size3D(maxValue, minValue).Diagonal * 0.001;
		if (num < 1E-06)
		{
			num = 1E-06;
		}
		return num;
	}

	protected internal static bool TextNeedsToBeFlippedAccordingToDrawingRules(double angleInRad)
	{
		if (angleInRad < 0.0)
		{
			angleInRad += Math.PI * 2.0;
		}
		if (angleInRad > Math.PI * 2.0)
		{
			angleInRad -= Math.PI * 2.0;
		}
		if (angleInRad > Math.PI / 6.0)
		{
			return angleInRad <= 3.665191429188092;
		}
		return false;
	}

	public static bool IntersectionLineLine(ICurve line1, ICurve line2, Plane pln, out Point3D i0)
	{
		Segment2D s = new Segment2D(pln.Project(line1.StartPoint), pln.Project(line1.EndPoint));
		Segment2D s2 = new Segment2D(pln.Project(line2.StartPoint), pln.Project(line2.EndPoint));
		if (!Segment2D.IntersectionLineInternal(s, s2, out var s3, out var t, out var i1) || i1 == null)
		{
			i0 = null;
			return false;
		}
		i0 = pln.PointAt(i1);
		if (s3 > 0.0 - _0023_003DzheSR8QM7q9ya && s3 < 1.0 + _0023_003DzheSR8QM7q9ya && t > 0.0 - _0023_003DzheSR8QM7q9ya && t < 1.0 + _0023_003DzheSR8QM7q9ya)
		{
			return true;
		}
		return false;
	}

	internal static bool _0023_003DzMSve1bk9ojU7(ICurve _0023_003DzQvaHyao_003D, ICurve _0023_003DzNyidyKE_003D, double _0023_003DzccAR5G0_003D, out Point3D _0023_003Dz348XSZM_003D)
	{
		_0023_003Dz348XSZM_003D = null;
		Segment3D segment3D = new Segment3D(_0023_003DzQvaHyao_003D.StartPoint, _0023_003DzQvaHyao_003D.EndPoint);
		Segment3D segment3D2 = new Segment3D(_0023_003DzNyidyKE_003D.StartPoint, _0023_003DzNyidyKE_003D.EndPoint);
		if (!Segment3D.Intersection(segment3D, segment3D2, infinite: true, out var pointOnA, out var pointOnB, out var paramOnA, out var paramOnB))
		{
			return false;
		}
		if (Point3D.AreEqual(pointOnA, pointOnB, _0023_003DzccAR5G0_003D))
		{
			bool num = (0.0 <= paramOnA && paramOnA <= 1.0) || Point3D.AreEqual(pointOnA, segment3D.P0, _0023_003DzccAR5G0_003D) || Point3D.AreEqual(pointOnA, segment3D.P1, _0023_003DzccAR5G0_003D);
			bool flag = (0.0 <= paramOnB && paramOnB <= 1.0) || Point3D.AreEqual(pointOnB, segment3D2.P0, _0023_003DzccAR5G0_003D) || Point3D.AreEqual(pointOnB, segment3D2.P1, _0023_003DzccAR5G0_003D);
			if (num && flag)
			{
				_0023_003Dz348XSZM_003D = pointOnA;
				return true;
			}
		}
		return false;
	}

	public static bool IntersectionLineLine(ICurve line1, ICurve line2, out Point3D i0)
	{
		double _0023_003DzccAR5G0_003D = _0023_003Dz_0024lZxMnYFa_0024OQDkZzoQ_003D_003D(line1, line2);
		return _0023_003DzMSve1bk9ojU7(line1, line2, _0023_003DzccAR5G0_003D, out i0);
	}

	public static bool IntersectionLineCircle(Line line, Circle arc, Plane pln, out Point3D i0, out Point3D i1)
	{
		return IntersectionLineCircle(line, arc, pln, infiniteLine: false, out i0, out i1);
	}

	public static bool IntersectionLineCircle(Line line, Circle arc, Plane pln, bool infiniteLine, out Point3D i0, out Point3D i1)
	{
		return _0023_003DzYldFvvqGYzmQ4AlshA_003D_003D(line, arc, pln, infiniteLine, 1E-05, out i0, out i1);
	}

	private static bool _0023_003DzYldFvvqGYzmQ4AlshA_003D_003D(Line _0023_003DzQ9zpGF0_003D, Circle _0023_003DzN4MDZ_0024c_003D, Plane _0023_003Dzpyw2kZk_003D, bool _0023_003DzOKsJOVsIoYdboxTZBQ_003D_003D, double _0023_003Dzm0CYiiE_003D, out Point3D _0023_003Dz348XSZM_003D, out Point3D _0023_003DzVxmwB6Y_003D)
	{
		_0023_003Dz348XSZM_003D = (_0023_003DzVxmwB6Y_003D = null);
		Line line = (Line)_0023_003DzQ9zpGF0_003D.Clone();
		Circle circle = (Circle)_0023_003DzN4MDZ_0024c_003D.Clone();
		Vector3D v = Vector3D.Subtract(_0023_003Dzpyw2kZk_003D.Origin, circle.Center);
		circle.Translate(v);
		line.Translate(v);
		Point2D point2D = _0023_003Dzpyw2kZk_003D.Project(line.StartPoint);
		Point2D point2D2 = _0023_003Dzpyw2kZk_003D.Project(line.EndPoint);
		double num = point2D2.X - point2D.X;
		double num2 = point2D2.Y - point2D.Y;
		double num3 = Math.Sqrt(num * num + num2 * num2);
		double num4 = point2D.X * point2D2.Y - point2D2.X * point2D.Y;
		double num5 = circle.Radius * circle.Radius * (num3 * num3) - num4 * num4;
		if (num5 < (0.0 - _0023_003Dzm0CYiiE_003D) * circle.Radius)
		{
			return false;
		}
		if (num5 < _0023_003Dzm0CYiiE_003D * circle.Radius)
		{
			_0023_003DzQ9zpGF0_003D.ClosestPointTo(_0023_003DzN4MDZ_0024c_003D.Center, out var t);
			Point3D point3D = _0023_003DzQ9zpGF0_003D.PointAt(t);
			if (AreEqual(Point3D.Distance(point3D, _0023_003DzN4MDZ_0024c_003D.Center), _0023_003DzN4MDZ_0024c_003D.Radius, _0023_003DzN4MDZ_0024c_003D.Radius))
			{
				if (_0023_003DzN4MDZ_0024c_003D is Arc arc)
				{
					arc.ClosestPointTo(point3D, out t);
				}
				if (!(_0023_003DzN4MDZ_0024c_003D is Arc) || AreEqual(Point3D.Distance(point3D, _0023_003DzN4MDZ_0024c_003D.PointAt(t)), 0.0, _0023_003DzN4MDZ_0024c_003D.Radius))
				{
					_0023_003Dz348XSZM_003D = point3D;
					return true;
				}
			}
		}
		int num6 = ((!(num2 < 0.0)) ? 1 : (-1));
		double _0023_003DzBJFJHwk_003D = (num4 * num2 + (double)num6 * num * Math.Sqrt(num5)) / (num3 * num3);
		double _0023_003Dz40R7bAU_003D = ((0.0 - num4) * num + Math.Abs(num2) * Math.Sqrt(num5)) / (num3 * num3);
		_0023_003Dz348XSZM_003D = _0023_003Dzuc4FZ6qUpOS03LH02Q_003D_003D(_0023_003Dzpyw2kZk_003D, _0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, line, circle, _0023_003DzQ9zpGF0_003D, _0023_003DzOKsJOVsIoYdboxTZBQ_003D_003D);
		if (Math.Abs(num5) < 1E-12 && _0023_003Dz348XSZM_003D != null)
		{
			return true;
		}
		_0023_003DzBJFJHwk_003D = (num4 * num2 - (double)num6 * num * Math.Sqrt(num5)) / (num3 * num3);
		_0023_003Dz40R7bAU_003D = ((0.0 - num4) * num - Math.Abs(num2) * Math.Sqrt(num5)) / (num3 * num3);
		Point3D point3D2 = _0023_003Dzuc4FZ6qUpOS03LH02Q_003D_003D(_0023_003Dzpyw2kZk_003D, _0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, line, circle, _0023_003DzQ9zpGF0_003D, _0023_003DzOKsJOVsIoYdboxTZBQ_003D_003D);
		if (_0023_003Dz348XSZM_003D == null)
		{
			_0023_003Dz348XSZM_003D = point3D2;
		}
		else
		{
			_0023_003DzVxmwB6Y_003D = point3D2;
		}
		return _0023_003Dz348XSZM_003D != null;
	}

	public static bool IntersectionLineEllipse(Line line, Ellipse ellipse, Plane pln, bool infiniteLine, out Point3D i0, out Point3D i1)
	{
		return _0023_003DzMZ90HH3wyBIa(line, ellipse, pln, infiniteLine, 1E-05, out i0, out i1);
	}

	internal static bool _0023_003DzMZ90HH3wyBIa(Line _0023_003DzQ9zpGF0_003D, Ellipse _0023_003DzWUywqIo_003D, Plane _0023_003Dzpyw2kZk_003D, bool _0023_003DzOKsJOVsIoYdboxTZBQ_003D_003D, double _0023_003Dzm0CYiiE_003D, out Point3D _0023_003Dz348XSZM_003D, out Point3D _0023_003DzVxmwB6Y_003D)
	{
		_0023_003Dz348XSZM_003D = (_0023_003DzVxmwB6Y_003D = null);
		Line line = (Line)_0023_003DzQ9zpGF0_003D.Clone();
		Ellipse ellipse = (Ellipse)_0023_003DzWUywqIo_003D.Clone();
		Transformation xform = new Align3D(_0023_003DzWUywqIo_003D.Plane, Plane.XY);
		ellipse.TransformBy(xform);
		line.TransformBy(xform);
		Point2D _0023_003DzAqOpw0w_003D = Plane.XY.Project(line.StartPoint);
		Point2D _0023_003Dzk64JNOo_003D = Plane.XY.Project(line.EndPoint);
		_0023_003DzEdG8f3wtWaHHrjfLd6FVb_g_003D(_0023_003DzAqOpw0w_003D, _0023_003Dzk64JNOo_003D, _0023_003DzWUywqIo_003D.RadiusX, _0023_003DzWUywqIo_003D.RadiusY, _0023_003Dzm0CYiiE_003D, out var _0023_003Dz348XSZM_003D2, out var _0023_003DzVxmwB6Y_003D2);
		if (_0023_003Dz348XSZM_003D2 != null)
		{
			_0023_003Dz348XSZM_003D = _0023_003Dz0MOB5bNNl_0024Sp(Plane.XY, _0023_003Dz348XSZM_003D2.X, _0023_003Dz348XSZM_003D2.Y, line, ellipse, _0023_003DzQ9zpGF0_003D, _0023_003DzOKsJOVsIoYdboxTZBQ_003D_003D: false);
		}
		if (_0023_003DzVxmwB6Y_003D2 != null)
		{
			if (_0023_003Dz348XSZM_003D != null)
			{
				_0023_003DzVxmwB6Y_003D = _0023_003Dz0MOB5bNNl_0024Sp(Plane.XY, _0023_003DzVxmwB6Y_003D2.X, _0023_003DzVxmwB6Y_003D2.Y, line, ellipse, _0023_003DzQ9zpGF0_003D, _0023_003DzOKsJOVsIoYdboxTZBQ_003D_003D: false);
			}
			else
			{
				_0023_003Dz348XSZM_003D = _0023_003Dz0MOB5bNNl_0024Sp(Plane.XY, _0023_003DzVxmwB6Y_003D2.X, _0023_003DzVxmwB6Y_003D2.Y, line, ellipse, _0023_003DzQ9zpGF0_003D, _0023_003DzOKsJOVsIoYdboxTZBQ_003D_003D: false);
			}
		}
		return _0023_003Dz348XSZM_003D != null;
	}

	private static void _0023_003DzEdG8f3wtWaHHrjfLd6FVb_g_003D(Point2D _0023_003DzAqOpw0w_003D, Point2D _0023_003Dzk64JNOo_003D, double _0023_003DzTAvzjIc_003D, double _0023_003DzpbGuOuw_003D, double _0023_003Dzm0CYiiE_003D, out Point2D _0023_003Dz348XSZM_003D, out Point2D _0023_003DzVxmwB6Y_003D)
	{
		_0023_003Dz348XSZM_003D = null;
		_0023_003DzVxmwB6Y_003D = null;
		double num = Math.Max(_0023_003DzTAvzjIc_003D, _0023_003DzpbGuOuw_003D);
		_0023_003DzTAvzjIc_003D *= _0023_003DzTAvzjIc_003D;
		_0023_003DzpbGuOuw_003D *= _0023_003DzpbGuOuw_003D;
		double x;
		double num2;
		if (Math.Abs(_0023_003DzAqOpw0w_003D.X - _0023_003Dzk64JNOo_003D.X) < _0023_003DzheSR8QM7q9ya)
		{
			x = _0023_003DzAqOpw0w_003D.X;
			num2 = (_0023_003DzTAvzjIc_003D * _0023_003DzpbGuOuw_003D - _0023_003DzpbGuOuw_003D * x * x) / _0023_003DzTAvzjIc_003D;
			if (!(num2 < (0.0 - _0023_003Dzm0CYiiE_003D) * num))
			{
				if (num2 < _0023_003Dzm0CYiiE_003D * num)
				{
					_0023_003Dz348XSZM_003D = new Point2D(x, 0.0);
					return;
				}
				double num3 = Math.Sqrt(num2);
				_0023_003Dz348XSZM_003D = new Point2D(x, num3);
				_0023_003DzVxmwB6Y_003D = new Point2D(x, 0.0 - num3);
			}
			return;
		}
		double num4 = (_0023_003DzAqOpw0w_003D.Y - _0023_003Dzk64JNOo_003D.Y) / (_0023_003DzAqOpw0w_003D.X - _0023_003Dzk64JNOo_003D.X);
		x = _0023_003DzAqOpw0w_003D.Y - num4 * _0023_003DzAqOpw0w_003D.X;
		double num5 = _0023_003DzpbGuOuw_003D + _0023_003DzTAvzjIc_003D * num4 * num4;
		double num6 = 2.0 * _0023_003DzTAvzjIc_003D * num4 * x;
		double num7 = _0023_003DzTAvzjIc_003D * (x * x - _0023_003DzpbGuOuw_003D);
		num2 = num6 * num6 - 4.0 * num5 * num7;
		if (!(num2 < (0.0 - _0023_003Dzm0CYiiE_003D) * num))
		{
			double num8;
			double num3;
			if (num2 < _0023_003Dzm0CYiiE_003D * num)
			{
				num8 = (0.0 - num6) / (2.0 * num5);
				num3 = (double)Math.Sign(num4 * num8 + x) * Math.Sqrt((_0023_003DzTAvzjIc_003D * _0023_003DzpbGuOuw_003D - _0023_003DzpbGuOuw_003D * num8 * num8) / _0023_003DzTAvzjIc_003D);
				_0023_003Dz348XSZM_003D = new Point2D(num8, num3);
				return;
			}
			num8 = (0.0 - num6 + Math.Sqrt(num2)) / (2.0 * num5);
			num3 = (double)Math.Sign(num4 * num8 + x) * Math.Sqrt((_0023_003DzTAvzjIc_003D * _0023_003DzpbGuOuw_003D - _0023_003DzpbGuOuw_003D * num8 * num8) / _0023_003DzTAvzjIc_003D);
			_0023_003Dz348XSZM_003D = new Point2D(num8, num3);
			double num9 = (0.0 - num6 - Math.Sqrt(num2)) / (2.0 * num5);
			double y = (double)Math.Sign(num4 * num9 + x) * Math.Sqrt((_0023_003DzTAvzjIc_003D * _0023_003DzpbGuOuw_003D - _0023_003DzpbGuOuw_003D * num9 * num9) / _0023_003DzTAvzjIc_003D);
			_0023_003DzVxmwB6Y_003D = new Point2D(num9, y);
		}
	}

	private static Point3D _0023_003Dzuc4FZ6qUpOS03LH02Q_003D_003D(Plane _0023_003Dzpyw2kZk_003D, double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, Line _0023_003Dz3kxdC8KVNUNe, Circle _0023_003DzcI54GJx2hYqWJLH0mQ_003D_003D, Line _0023_003Dz76pmJfg_003D, bool _0023_003DzOKsJOVsIoYdboxTZBQ_003D_003D)
	{
		Point2D pt = new Point2D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
		Point3D point3D = _0023_003Dzpyw2kZk_003D.PointAt(pt);
		_0023_003Dz3kxdC8KVNUNe.Project(point3D, out var t);
		_0023_003DzcI54GJx2hYqWJLH0mQ_003D_003D.Project(point3D, out var t2);
		Point3D result = null;
		if (_0023_003DzcI54GJx2hYqWJLH0mQ_003D_003D is Arc)
		{
			if (Point3D.AreEqual(_0023_003DzcI54GJx2hYqWJLH0mQ_003D_003D.PointAt(t2), point3D, _0023_003DzcI54GJx2hYqWJLH0mQ_003D_003D.Radius) && _0023_003DzcI54GJx2hYqWJLH0mQ_003D_003D.Domain.Includes(t2, _0023_003DzcI54GJx2hYqWJLH0mQ_003D_003D.Domain.Length * _0023_003DzheSR8QM7q9ya) && (_0023_003DzOKsJOVsIoYdboxTZBQ_003D_003D || _0023_003Dz3kxdC8KVNUNe.Domain.Includes(t, _0023_003Dz3kxdC8KVNUNe.Domain.Length * _0023_003DzheSR8QM7q9ya)))
			{
				result = _0023_003Dz76pmJfg_003D.PointAt(t);
			}
		}
		else if (_0023_003DzOKsJOVsIoYdboxTZBQ_003D_003D || _0023_003Dz3kxdC8KVNUNe.Domain.Includes(t, _0023_003Dz3kxdC8KVNUNe.Domain.Length * _0023_003DzheSR8QM7q9ya))
		{
			result = _0023_003Dz76pmJfg_003D.PointAt(t);
		}
		return result;
	}

	private static Point3D _0023_003Dz0MOB5bNNl_0024Sp(Plane _0023_003Dzpyw2kZk_003D, double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, Line _0023_003Dz3kxdC8KVNUNe, Ellipse _0023_003DzHX2KsBALF_px, Line _0023_003Dz76pmJfg_003D, bool _0023_003DzOKsJOVsIoYdboxTZBQ_003D_003D)
	{
		Point2D pt = new Point2D(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D);
		Point3D point3D = _0023_003Dzpyw2kZk_003D.PointAt(pt);
		_0023_003Dz3kxdC8KVNUNe.Project(point3D, out var t);
		_0023_003DzHX2KsBALF_px.Project(point3D, out var t2);
		Point3D result = null;
		if (_0023_003DzHX2KsBALF_px is EllipticalArc)
		{
			if (Point3D.AreEqual(_0023_003DzHX2KsBALF_px.PointAt(t2), point3D, Math.Max(_0023_003DzHX2KsBALF_px.RadiusX, _0023_003DzHX2KsBALF_px.RadiusY)) && _0023_003DzHX2KsBALF_px.Domain.Includes(t2, _0023_003DzHX2KsBALF_px.Domain.Length * _0023_003DzheSR8QM7q9ya) && (_0023_003DzOKsJOVsIoYdboxTZBQ_003D_003D || _0023_003Dz3kxdC8KVNUNe.Domain.Includes(t, _0023_003Dz3kxdC8KVNUNe.Domain.Length * _0023_003DzheSR8QM7q9ya)))
			{
				result = _0023_003Dz76pmJfg_003D.PointAt(t);
			}
		}
		else if (_0023_003DzOKsJOVsIoYdboxTZBQ_003D_003D || _0023_003Dz3kxdC8KVNUNe.Domain.Includes(t, _0023_003Dz3kxdC8KVNUNe.Domain.Length * _0023_003DzheSR8QM7q9ya))
		{
			result = _0023_003Dz76pmJfg_003D.PointAt(t);
		}
		return result;
	}

	public static bool IntersectionLineCircle3D(Line line, Circle circ, out Point3D i0, out Point3D i1)
	{
		double _0023_003DzccAR5G0_003D = _0023_003Dz_0024lZxMnYFa_0024OQDkZzoQ_003D_003D(line, circ);
		return _0023_003DzlTBtz4ei63kfZ2jCcIi4R8c_003D(line, circ, _0023_003DzccAR5G0_003D, out i0, out i1);
	}

	public static bool IntersectionLineEllipse3D(Line line, Ellipse ellipse, out Point3D i0, out Point3D i1)
	{
		double _0023_003DzccAR5G0_003D = _0023_003Dz_0024lZxMnYFa_0024OQDkZzoQ_003D_003D(line, ellipse);
		return _0023_003Dzjkn37He1Dc0IA_0024_CNA_003D_003D(line, ellipse, _0023_003DzccAR5G0_003D, out i0, out i1);
	}

	internal static bool _0023_003DzlTBtz4ei63kfZ2jCcIi4R8c_003D(Line _0023_003DzQ9zpGF0_003D, Circle _0023_003DzOWSZ5jrxtEQi, double _0023_003DzccAR5G0_003D, out Point3D _0023_003Dz348XSZM_003D, out Point3D _0023_003DzVxmwB6Y_003D)
	{
		_0023_003Dz348XSZM_003D = (_0023_003DzVxmwB6Y_003D = null);
		Plane plane = _0023_003DzOWSZ5jrxtEQi.Plane;
		if (Math.Abs(_0023_003DzQ9zpGF0_003D.StartTangent * plane.AxisZ) < 1E-12 && Math.Abs(plane.DistanceTo(_0023_003DzQ9zpGF0_003D.StartPoint)) < _0023_003DzheSR8QM7q9ya * _0023_003DzccAR5G0_003D)
		{
			return IntersectionLineCircle(_0023_003DzQ9zpGF0_003D, _0023_003DzOWSZ5jrxtEQi, plane, infiniteLine: false, out _0023_003Dz348XSZM_003D, out _0023_003DzVxmwB6Y_003D);
		}
		new Segment3D(_0023_003DzQ9zpGF0_003D.StartPoint, _0023_003DzQ9zpGF0_003D.EndPoint)._0023_003DzGKZuR_4q838u(plane.Equation, out var _0023_003DzPjm3jErOBm, _0023_003Dz0ldn1DXnjGqH: true, _0023_003DzKQHbdoyJS3kp3_JzfQ_003D_003D: false);
		if (_0023_003DzPjm3jErOBm != null && AreEqual(Point3D.Distance(_0023_003DzOWSZ5jrxtEQi.Center, _0023_003DzPjm3jErOBm), _0023_003DzOWSZ5jrxtEQi.Radius, _0023_003DzccAR5G0_003D))
		{
			if (_0023_003DzOWSZ5jrxtEQi is Arc)
			{
				((Arc)_0023_003DzOWSZ5jrxtEQi).ClosestPointTo(_0023_003DzPjm3jErOBm, out var t);
				if (Point3D.AreEqual(_0023_003DzPjm3jErOBm, _0023_003DzOWSZ5jrxtEQi.PointAt(t), _0023_003DzccAR5G0_003D))
				{
					_0023_003Dz348XSZM_003D = _0023_003DzPjm3jErOBm;
					return true;
				}
				return false;
			}
			_0023_003Dz348XSZM_003D = _0023_003DzPjm3jErOBm;
			return true;
		}
		return false;
	}

	internal static bool _0023_003Dzjkn37He1Dc0IA_0024_CNA_003D_003D(Line _0023_003DzQ9zpGF0_003D, Ellipse _0023_003Dz_0024Ix3IG0_003D, double _0023_003DzccAR5G0_003D, out Point3D _0023_003Dz348XSZM_003D, out Point3D _0023_003DzVxmwB6Y_003D)
	{
		_0023_003Dz348XSZM_003D = (_0023_003DzVxmwB6Y_003D = null);
		Plane plane = _0023_003Dz_0024Ix3IG0_003D.Plane;
		if (Math.Abs(_0023_003DzQ9zpGF0_003D.StartTangent * plane.AxisZ) < 1E-12 && Math.Abs(plane.DistanceTo(_0023_003DzQ9zpGF0_003D.StartPoint)) < _0023_003DzheSR8QM7q9ya * _0023_003DzccAR5G0_003D)
		{
			return IntersectionLineEllipse(_0023_003DzQ9zpGF0_003D, _0023_003Dz_0024Ix3IG0_003D, plane, infiniteLine: false, out _0023_003Dz348XSZM_003D, out _0023_003DzVxmwB6Y_003D);
		}
		new Segment3D(_0023_003DzQ9zpGF0_003D.StartPoint, _0023_003DzQ9zpGF0_003D.EndPoint)._0023_003DzGKZuR_4q838u(plane.Equation, out var _0023_003DzPjm3jErOBm, _0023_003Dz0ldn1DXnjGqH: true, _0023_003DzKQHbdoyJS3kp3_JzfQ_003D_003D: false);
		if (_0023_003DzPjm3jErOBm != null)
		{
			if (_0023_003Dz_0024Ix3IG0_003D is EllipticalArc)
			{
				((EllipticalArc)_0023_003Dz_0024Ix3IG0_003D).ClosestPointTo(_0023_003DzPjm3jErOBm, out var t);
				if (Point3D.AreEqual(_0023_003DzPjm3jErOBm, _0023_003Dz_0024Ix3IG0_003D.PointAt(t), _0023_003DzccAR5G0_003D))
				{
					_0023_003Dz348XSZM_003D = _0023_003DzPjm3jErOBm;
					return true;
				}
				return false;
			}
			_0023_003Dz348XSZM_003D = _0023_003DzPjm3jErOBm;
			return true;
		}
		return false;
	}

	public static bool IntersectionCircleCircle(Circle arc1, Circle arc2, Plane pln, out Point3D i0, out Point3D i1)
	{
		Point2D point2D = pln.Project(arc1.Center);
		Point2D point2D2 = pln.Project(arc2.Center);
		Point3D point3D = new Point3D(point2D.X, point2D.Y, 0.0);
		Point3D point3D2 = new Point3D(point2D2.X, point2D2.Y, 0.0);
		Transformation transformation = new Translation(0.0 - point2D.X, 0.0 - point2D.Y);
		point3D = transformation * point3D;
		point3D2 = transformation * point3D2;
		Vector3D vector3D = Vector3D.Subtract(point3D2, point3D);
		Rotation rotation = new Rotation(0.0 - vector3D.AngleInXY, Vector3D.AxisZ);
		point3D = rotation * point3D;
		point3D2 = rotation * point3D2;
		double num = Point2D.Distance(point3D, point3D2);
		if (num < 1E-12 * Math.Min(arc1.Radius, arc2.Radius) || num > arc1.Radius + arc2.Radius + _0023_003DzheSR8QM7q9ya || arc1.Radius > num + arc2.Radius + _0023_003DzheSR8QM7q9ya || arc2.Radius > num + arc1.Radius + _0023_003DzheSR8QM7q9ya)
		{
			i0 = null;
			i1 = null;
			return false;
		}
		double num2 = (num * num - arc2.Radius * arc2.Radius + arc1.Radius * arc1.Radius) / (2.0 * num);
		double num3 = 0.0;
		if (AreEqual(Math.Abs(num2), arc1.Radius, Math.Max(num2, arc1.Radius)))
		{
			num3 = 0.0;
			i1 = null;
		}
		else
		{
			if (num2 > arc1.Radius)
			{
				i0 = (i1 = null);
				return false;
			}
			num3 = Math.Sqrt(arc1.Radius * arc1.Radius - num2 * num2);
			i1 = new Point3D(num2, 0.0 - num3, 0.0);
		}
		i0 = new Point3D(num2, num3, 0.0);
		transformation = new Translation(point2D.X, point2D.Y) * new Rotation(vector3D.AngleInXY, Vector3D.AxisZ);
		i0 = transformation * i0;
		i0 = pln.PointAt(i0.X, i0.Y);
		if (i1 != null)
		{
			i1 = transformation * i1;
			i1 = pln.PointAt(i1.X, i1.Y);
		}
		bool flag = true;
		bool flag2 = true;
		if (arc1 is Arc)
		{
			flag = _0023_003Dz1cwY_lgsKIts(arc1, i0);
		}
		if (arc2 is Arc)
		{
			flag2 = _0023_003Dz1cwY_lgsKIts(arc2, i0);
		}
		bool flag3 = false;
		if (flag && flag2)
		{
			if (i1 == null)
			{
				return true;
			}
			flag3 = true;
		}
		if (i1 != null)
		{
			if (arc1 is Arc)
			{
				flag = _0023_003Dz1cwY_lgsKIts(arc1, i1);
			}
			if (arc2 is Arc)
			{
				flag2 = _0023_003Dz1cwY_lgsKIts(arc2, i1);
			}
			if (flag && flag2)
			{
				if (!flag3)
				{
					i0 = i1;
					i1 = null;
				}
				return true;
			}
			if (flag3)
			{
				i1 = null;
				return true;
			}
		}
		i0 = (i1 = null);
		return false;
	}

	private static bool _0023_003Dz1cwY_lgsKIts(Circle _0023_003Dz0GK_otjkKO_00241, Point3D _0023_003Dz348XSZM_003D)
	{
		Arc arc = (Arc)_0023_003Dz0GK_otjkKO_00241;
		arc._0023_003DzIp4nxx0dXuNdTQbtjP_BbwQ_003D(_0023_003Dz348XSZM_003D, out var _0023_003DzNDQ_E88_003D);
		if (arc.Domain.Includes(_0023_003DzNDQ_E88_003D, arc.Domain.Length * _0023_003DzheSR8QM7q9ya))
		{
			return Point3D.Distance(arc.PointAt(_0023_003DzNDQ_E88_003D), _0023_003Dz348XSZM_003D) < arc.Radius * _0023_003Dzjyaz_Vfaky9X;
		}
		return false;
	}

	public static bool IntersectionCircleCircle3D(Circle arc1, Circle arc2, out Point3D i0, out Point3D i1)
	{
		return _0023_003Dz4BQ0X_NQrDi3B6fchajn6vP0dc1x(arc1, arc2, out i0, out i1, 0.0);
	}

	internal static bool _0023_003Dz4BQ0X_NQrDi3B6fchajn6vP0dc1x(Circle _0023_003Dz0GK_otjkKO_00241, Circle _0023_003Dzvi0wbtBjjhrX, out Point3D _0023_003Dz348XSZM_003D, out Point3D _0023_003DzVxmwB6Y_003D, double _0023_003DzccAR5G0_003D)
	{
		_0023_003Dz348XSZM_003D = null;
		_0023_003DzVxmwB6Y_003D = null;
		Plane plane = _0023_003Dz0GK_otjkKO_00241.Plane;
		Plane plane2 = _0023_003Dzvi0wbtBjjhrX.Plane;
		double tol = ((_0023_003DzccAR5G0_003D == 0.0) ? 1E-12 : (_0023_003DzxhnLabVjXjPg * _0023_003DzccAR5G0_003D));
		Segment3D intSeg;
		switch (Plane.Intersection(plane, plane2, tol, out intSeg))
		{
		case planeIntersectionType.Disjoint:
			return false;
		case planeIntersectionType.Coincide:
			return IntersectionCircleCircle(_0023_003Dz0GK_otjkKO_00241, _0023_003Dzvi0wbtBjjhrX, _0023_003Dz0GK_otjkKO_00241.Plane, out _0023_003Dz348XSZM_003D, out _0023_003DzVxmwB6Y_003D);
		case planeIntersectionType.UniqueLine:
		{
			double t = intSeg.Project(_0023_003Dz0GK_otjkKO_00241.Center);
			double t2 = intSeg.Project(_0023_003Dzvi0wbtBjjhrX.Center);
			Point3D point3D = intSeg.PointAt(t);
			Point3D point3D2 = intSeg.PointAt(t2);
			double num = Point3D.Distance(point3D, _0023_003Dz0GK_otjkKO_00241.Center);
			double num2 = Point3D.Distance(point3D2, _0023_003Dzvi0wbtBjjhrX.Center);
			if (num > _0023_003Dz0GK_otjkKO_00241.Radius + 1E-12 || num2 > _0023_003Dzvi0wbtBjjhrX.Radius + 1E-12)
			{
				return false;
			}
			Vector3D vector3D = new Vector3D(intSeg.P0, intSeg.P1);
			vector3D.Normalize();
			Line line = new Line(point3D - vector3D * _0023_003Dz0GK_otjkKO_00241.Radius, point3D + vector3D * _0023_003Dz0GK_otjkKO_00241.Radius);
			Line line2 = new Line(point3D2 - vector3D * _0023_003Dzvi0wbtBjjhrX.Radius, point3D2 + vector3D * _0023_003Dzvi0wbtBjjhrX.Radius);
			IntersectionLineCircle(line, _0023_003Dz0GK_otjkKO_00241, _0023_003Dz0GK_otjkKO_00241.Plane, out var i, out var i2);
			IntersectionLineCircle(line2, _0023_003Dzvi0wbtBjjhrX, _0023_003Dzvi0wbtBjjhrX.Plane, out var i3, out var i4);
			if (i == null || i3 == null)
			{
				return false;
			}
			double num3 = (_0023_003Dz0GK_otjkKO_00241.Radius + _0023_003Dzvi0wbtBjjhrX.Radius) / 2.0;
			if (Point3D.Distance(i, i3) < num3 * _0023_003DzxhnLabVjXjPg)
			{
				if (i2 != null && i4 != null && Point3D.Distance(i2, i4) < num3 * _0023_003DzxhnLabVjXjPg)
				{
					_0023_003Dz348XSZM_003D = i;
					_0023_003DzVxmwB6Y_003D = i2;
					return true;
				}
				_0023_003Dz348XSZM_003D = i;
				return true;
			}
			if (i2 == null && i4 == null)
			{
				return false;
			}
			if (i2 != null && i4 != null)
			{
				if (Point3D.Distance(i2, i4) < num3 * _0023_003DzxhnLabVjXjPg)
				{
					_0023_003Dz348XSZM_003D = i2;
					return true;
				}
				bool flag = Point3D.Distance(i, i4) < num3 * _0023_003DzxhnLabVjXjPg;
				bool flag2 = Point3D.Distance(i3, i2) < num3 * _0023_003DzxhnLabVjXjPg;
				if (flag && flag2)
				{
					_0023_003Dz348XSZM_003D = i;
					_0023_003DzVxmwB6Y_003D = i2;
					return true;
				}
				if (flag)
				{
					_0023_003Dz348XSZM_003D = i;
					return true;
				}
				if (flag2)
				{
					_0023_003Dz348XSZM_003D = i3;
					return true;
				}
				return false;
			}
			if (i2 != null && Point3D.Distance(i3, i2) < num3 * _0023_003DzxhnLabVjXjPg)
			{
				_0023_003Dz348XSZM_003D = i2;
				return true;
			}
			if (i4 != null && Point3D.Distance(i, i4) < num3 * _0023_003DzxhnLabVjXjPg)
			{
				_0023_003Dz348XSZM_003D = i4;
				return true;
			}
			return false;
		}
		default:
			return false;
		}
	}

	public static Point3D[] Intersection2D(ICurve C1, ICurve C2, Plane plane)
	{
		List<Point3D> list = new List<Point3D>();
		Point3D i = null;
		Point3D i2 = null;
		double _0023_003DzccAR5G0_003D = _0023_003Dz_0024lZxMnYFa_0024OQDkZzoQ_003D_003D(C1, C2);
		bool flag = C1 is CompositeCurve || C1 is LinearPath;
		bool flag2 = C2 is CompositeCurve || C2 is LinearPath;
		if (!flag && !flag2)
		{
			if (C1 is Line)
			{
				Line line = (Line)C1;
				if (C2 is Circle)
				{
					Circle arc = (Circle)C2;
					IntersectionLineCircle(line, arc, plane, out i, out i2);
				}
				else if (C2 is Line)
				{
					Segment2D s = new Segment2D(plane.Project(line.StartPoint), plane.Project(line.EndPoint));
					Segment2D s2 = new Segment2D(plane.Project(C2.StartPoint), plane.Project(C2.EndPoint));
					Segment2D.Intersection(s, s2, out var i3, out var i4, 1.0);
					if (i3 != null)
					{
						i = plane.PointAt(i3);
					}
					if (i4 != null)
					{
						i2 = plane.PointAt(i4);
					}
				}
				else
				{
					Curve.LineCurveBisection(line, C2, plane, out var ip);
					Point3D[] array = ip;
					Point3D[] array2 = array;
					if (array2 != null)
					{
						array = array2;
						for (int j = 0; j < array.Length; j++)
						{
							_0023_003DzPuQvgP_0024VB6nsFeK9mVC99MQ_003D(array[j], list, _0023_003DzccAR5G0_003D, line, C2);
						}
					}
				}
			}
			else if (C1 is Circle)
			{
				Circle circle = (Circle)C1;
				if (C2 is Circle)
				{
					Circle arc2 = (Circle)C2;
					IntersectionCircleCircle(circle, arc2, plane, out i, out i2);
				}
				else if (C2 is Line)
				{
					IntersectionLineCircle((Line)C2, circle, plane, out i, out i2);
				}
				else
				{
					Point3D[] array2 = Intersection(C1, C2);
					if (array2 != null)
					{
						Point3D[] array = array2;
						for (int j = 0; j < array.Length; j++)
						{
							_0023_003DzPuQvgP_0024VB6nsFeK9mVC99MQ_003D(array[j], list, _0023_003DzccAR5G0_003D, C1, C2);
						}
					}
				}
			}
			else
			{
				Point3D[] array2;
				if (C2 is Line)
				{
					Curve.LineCurveBisection((Line)C2, C1, plane, out var ip2, reverse: true);
					Point3D[] array = ip2;
					array2 = array;
				}
				else
				{
					array2 = Intersection(C2, C1);
				}
				if (array2 != null)
				{
					Point3D[] array = array2;
					for (int j = 0; j < array.Length; j++)
					{
						_0023_003DzPuQvgP_0024VB6nsFeK9mVC99MQ_003D(array[j], list, _0023_003DzccAR5G0_003D, C2, C1);
					}
				}
			}
			if (i != null)
			{
				_0023_003DzbIDY9BOTPqfc(i, list, _0023_003DzccAR5G0_003D);
			}
			if (i2 != null)
			{
				_0023_003DzbIDY9BOTPqfc(i2, list, _0023_003DzccAR5G0_003D);
			}
		}
		else if (flag && flag2)
		{
			List<ICurve> list2 = new List<ICurve>();
			List<ICurve> list3 = new List<ICurve>();
			if (C1 is LinearPath)
			{
				list2.AddRange(((LinearPath)C1).ConvertToLines());
			}
			else
			{
				list2.AddRange(((CompositeCurve)C1)._0023_003DzpoMoKemHyOl4());
			}
			if (C2 is LinearPath)
			{
				list3.AddRange(((LinearPath)C2).ConvertToLines());
			}
			else
			{
				list3.AddRange(((CompositeCurve)C2)._0023_003DzpoMoKemHyOl4());
			}
			foreach (ICurve item in list2)
			{
				foreach (ICurve item2 in list3)
				{
					Point3D[] array2 = Intersection2D(item, item2, plane);
					if (array2 != null)
					{
						Point3D[] array = array2;
						for (int j = 0; j < array.Length; j++)
						{
							_0023_003DzbIDY9BOTPqfc(array[j], list, _0023_003DzccAR5G0_003D);
						}
					}
				}
			}
		}
		else if (flag)
		{
			List<ICurve> list4 = new List<ICurve>();
			if (C1 is LinearPath)
			{
				list4.AddRange(((LinearPath)C1).ConvertToLines());
			}
			else
			{
				list4.AddRange(((CompositeCurve)C1)._0023_003DzpoMoKemHyOl4());
			}
			foreach (ICurve item3 in list4)
			{
				Point3D[] array2 = Intersection2D(item3, C2, plane);
				if (array2 != null)
				{
					Point3D[] array = array2;
					for (int j = 0; j < array.Length; j++)
					{
						_0023_003DzbIDY9BOTPqfc(array[j], list, _0023_003DzccAR5G0_003D);
					}
				}
			}
		}
		else
		{
			List<ICurve> list5 = new List<ICurve>();
			if (C2 is LinearPath)
			{
				list5.AddRange(((LinearPath)C2).ConvertToLines());
			}
			else
			{
				list5.AddRange(((CompositeCurve)C2)._0023_003DzpoMoKemHyOl4());
			}
			foreach (ICurve item4 in list5)
			{
				Point3D[] array2 = Intersection2D(C1, item4, plane);
				if (array2 != null)
				{
					Point3D[] array = array2;
					for (int j = 0; j < array.Length; j++)
					{
						_0023_003DzbIDY9BOTPqfc(array[j], list, _0023_003DzccAR5G0_003D);
					}
				}
			}
		}
		return list.ToArray();
	}

	public static Point3D[] Intersection(ICurve C1, ICurve C2, double maxGap = 0.0, bool computeParameters = true)
	{
		if (!_0023_003DzZEROl_YJ_9b_0024tIOMvw_003D_003D._0023_003DzwAfFvoy42C6h())
		{
			throw new NotAvailableException();
		}
		if (C1 is devDept.Eyeshot.Entities.Point point && C2 is devDept.Eyeshot.Entities.Point point2)
		{
			if (point.Position.DistanceTo(point2.Position) <= maxGap)
			{
				return new Point3D[1]
				{
					new InterPoint(point.Position.X, point.Position.Y, point.Position.Z, point.Domain.Low, 0.0, point2.Domain.Low, 0.0)
				};
			}
		}
		else if (C1 is devDept.Eyeshot.Entities.Point point3)
		{
			C2.ClosestPointTo(point3.Position, out var t);
			if (C2.PointAt(t).DistanceTo(point3.Position) <= maxGap)
			{
				return new Point3D[1]
				{
					new InterPoint(point3.Position.X, point3.Position.Y, point3.Position.Z, point3.Domain.Low, 0.0, t, 0.0)
				};
			}
		}
		else if (C2 is devDept.Eyeshot.Entities.Point point4)
		{
			C1.ClosestPointTo(point4.Position, out var t2);
			if (C1.PointAt(t2).DistanceTo(point4.Position) <= maxGap)
			{
				return new Point3D[1]
				{
					new InterPoint(point4.Position.X, point4.Position.Y, point4.Position.Z, t2, 0.0, point4.Domain.Low, 0.0)
				};
			}
		}
		List<Point3D> list = new List<Point3D>();
		List<ICurve> list2 = new List<ICurve>();
		List<ICurve> list3 = new List<ICurve>();
		if (C1 is LinearPath)
		{
			list2.AddRange(((LinearPath)C1).ConvertToLines());
		}
		else if (C1 is CompositeCurve)
		{
			list2.AddRange(((CompositeCurve)C1)._0023_003DzpoMoKemHyOl4());
		}
		else
		{
			list2.Add(C1);
		}
		if (C2 is LinearPath)
		{
			list3.AddRange(((LinearPath)C2).ConvertToLines());
		}
		else if (C2 is CompositeCurve)
		{
			list3.AddRange(((CompositeCurve)C2)._0023_003DzpoMoKemHyOl4());
		}
		else
		{
			list3.Add(C2);
		}
		foreach (ICurve item in list2)
		{
			foreach (ICurve item2 in list3)
			{
				if (Line._0023_003Dz3a74KJAFKP9OrQrJ3xojG00_003D(item, item2, list, maxGap))
				{
					continue;
				}
				ICurve[] array = new ICurve[1];
				ICurve[] array2 = new ICurve[1];
				Curve nurbsForm = item.GetNurbsForm();
				Curve nurbsForm2 = item2.GetNurbsForm();
				ICurve[] array3;
				if (nurbsForm.Degree == 1 && nurbsForm.KnotVector.Length > 4)
				{
					array3 = nurbsForm.SplitAtDiscontinuities(speedChange: true);
					array = array3;
				}
				else
				{
					array[0] = nurbsForm;
				}
				if (nurbsForm2.Degree == 1 && nurbsForm2.KnotVector.Length > 4)
				{
					array3 = nurbsForm2.SplitAtDiscontinuities(speedChange: true);
					array2 = array3;
				}
				else
				{
					array2[0] = nurbsForm2;
				}
				array3 = array;
				foreach (ICurve curve in array3)
				{
					ICurve[] array4 = array2;
					foreach (ICurve curve2 in array4)
					{
						((Curve)curve).ControlBoundingBox(maxGap, out var min, out var max);
						((Curve)curve2).ControlBoundingBox(maxGap, out var min2, out var max2);
						if (!DoOverlapOrTouch(min, max, min2, max2))
						{
							continue;
						}
						double diagonal = new Size3D(min, max).Diagonal;
						double diagonal2 = new Size3D(min2, max2).Diagonal;
						double _0023_003DzccAR5G0_003D = Math.Min(diagonal, diagonal2);
						Point3D[] array5 = _0023_003DzQ7usAag_003D((Curve)curve, (Curve)curve2, maxGap, _0023_003DzccAR5G0_003D, _0023_003DzRn5G27jw1CX8cwaOeA_003D_003D: true, 0.0, null);
						foreach (Point3D point3D in array5)
						{
							bool flag = _0023_003DzbIDY9BOTPqfc(point3D, list, _0023_003DzccAR5G0_003D);
							if (computeParameters)
							{
								InterPoint interPoint = (InterPoint)point3D;
								if (flag && (list2.Count > 1 || array.Length > 1 || C1 is Circle || C1 is Ellipse))
								{
									C1.ClosestPointTo(interPoint, out var t3);
									interPoint.u = t3;
								}
								if (flag && (list3.Count > 1 || array2.Length > 1 || C2 is Circle || C2 is Ellipse))
								{
									C2.ClosestPointTo(interPoint, out var t4);
									interPoint.s = t4;
								}
							}
						}
					}
				}
			}
		}
		return list.ToArray();
	}

	public static Point3D[] Intersection(ICurve C1, ICurve C2, double maxGap)
	{
		if (!_0023_003DzZEROl_YJ_9b_0024tIOMvw_003D_003D._0023_003DzwAfFvoy42C6h())
		{
			throw new NotAvailableException();
		}
		List<Point3D> list = new List<Point3D>();
		if (Line._0023_003Dz3a74KJAFKP9OrQrJ3xojG00_003D(C1, C2, list, maxGap))
		{
			return list.ToArray();
		}
		if (_0023_003DzmP_EFPqPdW71YrsRgKPjj_0024c_003D(C1, C2, maxGap, out var _0023_003DzMJGsWus7nIv8rDxu_Q_003D_003D))
		{
			return new Point3D[1] { _0023_003DzMJGsWus7nIv8rDxu_Q_003D_003D };
		}
		Curve curve = ((C1 is Curve) ? ((Curve)C1) : C1.GetNurbsForm());
		Curve curve2 = ((C2 is Curve) ? ((Curve)C2) : C2.GetNurbsForm());
		object obj = null;
		object obj2 = null;
		if (C1 is IEvaluable)
		{
			obj = ((Entity)C1).EntityData;
			curve.EntityData = C1;
		}
		if (C2 is IEvaluable)
		{
			obj2 = ((Entity)C2).EntityData;
			curve2.EntityData = C2;
		}
		curve.ControlBoundingBox(maxGap, out var min, out var max);
		curve2.ControlBoundingBox(maxGap, out var min2, out var max2);
		if (!DoOverlapOrTouch(min, max, min2, max2))
		{
			return new Point3D[0];
		}
		double diagonal = new Size3D(min, max).Diagonal;
		double diagonal2 = new Size3D(min2, max2).Diagonal;
		double _0023_003DzccAR5G0_003D = Math.Min(diagonal, diagonal2);
		Point3D[] array = _0023_003DzQ7usAag_003D(curve, curve2, maxGap, _0023_003DzccAR5G0_003D, _0023_003DzRn5G27jw1CX8cwaOeA_003D_003D: false, 0.0, null);
		if (obj != null)
		{
			((Entity)C1).EntityData = obj;
		}
		if (obj2 != null)
		{
			((Entity)C2).EntityData = obj2;
		}
		_0023_003DzKLlchKz7OHh3(C1, C2, array);
		return array;
	}

	internal static void _0023_003DzKLlchKz7OHh3(ICurve _0023_003Dzfm4oGj8_003D, ICurve _0023_003DzCVdPoWM_003D, Point3D[] _0023_003Dzh5zIRDeVqFGp)
	{
		if (_0023_003Dzfm4oGj8_003D is Circle circle)
		{
			Point3D[] array = _0023_003Dzh5zIRDeVqFGp;
			foreach (Point3D point3D in array)
			{
				circle.GetRadianFromNurbFormParameter(((InterPoint)point3D).u, out var radianParameter);
				((InterPoint)point3D).u = radianParameter;
			}
		}
		else if (_0023_003Dzfm4oGj8_003D is Ellipse ellipse)
		{
			Point3D[] array = _0023_003Dzh5zIRDeVqFGp;
			foreach (Point3D point3D2 in array)
			{
				ellipse.GetRadianFromNurbFormParameter(((InterPoint)point3D2).u, out var radianParameter2);
				((InterPoint)point3D2).u = radianParameter2;
			}
		}
		if (_0023_003DzCVdPoWM_003D is Circle circle2)
		{
			Point3D[] array = _0023_003Dzh5zIRDeVqFGp;
			foreach (Point3D point3D3 in array)
			{
				circle2.GetRadianFromNurbFormParameter(((InterPoint)point3D3).s, out var radianParameter3);
				((InterPoint)point3D3).s = radianParameter3;
			}
		}
		else if (_0023_003DzCVdPoWM_003D is Ellipse ellipse2)
		{
			Point3D[] array = _0023_003Dzh5zIRDeVqFGp;
			foreach (Point3D point3D4 in array)
			{
				ellipse2.GetRadianFromNurbFormParameter(((InterPoint)point3D4).s, out var radianParameter4);
				((InterPoint)point3D4).s = radianParameter4;
			}
		}
	}

	private static bool _0023_003DzmP_EFPqPdW71YrsRgKPjj_0024c_003D(ICurve _0023_003Dzfm4oGj8_003D, ICurve _0023_003DzCVdPoWM_003D, double _0023_003DzX0qX_IwWxysi, out Point3D _0023_003DzMJGsWus7nIv8rDxu_Q_003D_003D)
	{
		_0023_003DzMJGsWus7nIv8rDxu_Q_003D_003D = null;
		ICurve curve = null;
		ICurve curve2 = null;
		if ((_0023_003Dzfm4oGj8_003D is Circle || _0023_003Dzfm4oGj8_003D is Ellipse) && _0023_003Dzfm4oGj8_003D.IsClosed)
		{
			curve = _0023_003Dzfm4oGj8_003D;
		}
		else if ((_0023_003DzCVdPoWM_003D is Circle || _0023_003DzCVdPoWM_003D is Ellipse) && _0023_003DzCVdPoWM_003D.IsClosed)
		{
			curve = _0023_003DzCVdPoWM_003D;
		}
		if (!_0023_003Dzfm4oGj8_003D.IsClosed)
		{
			curve2 = _0023_003Dzfm4oGj8_003D;
		}
		else if (!_0023_003DzCVdPoWM_003D.IsClosed)
		{
			curve2 = _0023_003DzCVdPoWM_003D;
		}
		if (curve != null && curve2 != null)
		{
			for (int i = 0; i < 4; i++)
			{
				double t = curve.Domain.ParameterAt((double)i / 4.0);
				Point3D point3D = curve.PointAt(t);
				if (point3D.DistanceTo(curve2.StartPoint) < _0023_003DzX0qX_IwWxysi || point3D.DistanceTo(curve2.EndPoint) < _0023_003DzX0qX_IwWxysi)
				{
					_0023_003DzMJGsWus7nIv8rDxu_Q_003D_003D = point3D;
					return true;
				}
			}
		}
		return false;
	}

	private static void _0023_003DzXM6YnhkiXp7S(Point3D _0023_003DzCbSDGus_003D, Point3D _0023_003Dzjtp_lVY_003D, double _0023_003Dz_eY3Y4c_003D, double _0023_003DzuwH5j5s_003D, Vector3D _0023_003DzQ92X5CY_003D, Vector3D _0023_003DzhB8eS6w_003D, double _0023_003DzccAR5G0_003D, List<Point3D> _0023_003DzrdSL0CI_003D)
	{
		if (Compare(_0023_003DzCbSDGus_003D.X, _0023_003Dzjtp_lVY_003D.X) == 0 && Compare(_0023_003DzCbSDGus_003D.Y, _0023_003Dzjtp_lVY_003D.Y) == 0 && Compare(_0023_003DzCbSDGus_003D.Z, _0023_003Dzjtp_lVY_003D.Z) == 0)
		{
			InterPoint interPoint = new InterPoint(_0023_003DzCbSDGus_003D.X, _0023_003DzCbSDGus_003D.Y, _0023_003DzCbSDGus_003D.Z, _0023_003Dz_eY3Y4c_003D, 0.0, _0023_003DzuwH5j5s_003D, 0.0);
			if (Vector3D.AreParallel(_0023_003DzQ92X5CY_003D, _0023_003DzhB8eS6w_003D))
			{
				interPoint.IsTangent = true;
				interPoint.Tangent = (_0023_003DzQ92X5CY_003D + _0023_003DzhB8eS6w_003D) / 2.0;
			}
			_0023_003DzbIDY9BOTPqfc(interPoint, _0023_003DzrdSL0CI_003D, _0023_003DzccAR5G0_003D);
		}
	}

	internal static Point3D[] _0023_003DzQ7usAag_003D(Curve _0023_003Dzfm4oGj8_003D, Curve _0023_003DzCVdPoWM_003D, double _0023_003DzX0qX_IwWxysi, double _0023_003DzccAR5G0_003D, bool _0023_003DzRn5G27jw1CX8cwaOeA_003D_003D, double _0023_003DzfBEBL_o_003D, Vector3D _0023_003DzQqOWrmM_003D)
	{
		Curve[] bezierSegments = _0023_003Dzfm4oGj8_003D.GetBezierSegments();
		Curve[] bezierSegments2 = _0023_003DzCVdPoWM_003D.GetBezierSegments();
		List<Tuple<Curve, Curve>> list = new List<Tuple<Curve, Curve>>();
		double inflateBy = Math.Max(_0023_003DzX0qX_IwWxysi, _0023_003DzfBEBL_o_003D);
		Curve[] array = bezierSegments2;
		foreach (Curve curve in array)
		{
			curve.ControlBoundingBox(inflateBy, out var min, out var max);
			Curve[] array2 = bezierSegments;
			foreach (Curve curve2 in array2)
			{
				curve2.ControlBoundingBox(inflateBy, out var min2, out var max2);
				if (DoOverlapOrTouch(min, max, min2, max2, _0023_003DzccAR5G0_003D * 10.0))
				{
					list.Add(new Tuple<Curve, Curve>(curve2, curve));
				}
			}
		}
		List<Point3D> list2 = new List<Point3D>();
		List<Point3D> list3 = new List<Point3D>();
		if (list.Count == 0)
		{
			return list2.ToArray();
		}
		double[] _0023_003DzBJFJHwk_003D;
		int num = _0023_003DzqwguFGLBjn13(_0023_003Dzfm4oGj8_003D._0023_003DzB68dg9Q_003D, out _0023_003DzBJFJHwk_003D);
		double[] _0023_003DzBJFJHwk_003D2;
		int num2 = _0023_003DzqwguFGLBjn13(_0023_003DzCVdPoWM_003D._0023_003DzB68dg9Q_003D, out _0023_003DzBJFJHwk_003D2);
		foreach (Tuple<Curve, Curve> item3 in list)
		{
			Curve item = item3.Item1;
			Curve item2 = item3.Item2;
			if (_0023_003DzfBEBL_o_003D == 0.0)
			{
				_0023_003DzXM6YnhkiXp7S(item.StartPoint, item2.StartPoint, item.Domain.Low, item2.Domain.Low, item.StartTangent, item2.StartTangent, _0023_003DzccAR5G0_003D, list2);
				_0023_003DzXM6YnhkiXp7S(item.EndPoint, item2.StartPoint, item.Domain.High, item2.Domain.Low, item.EndTangent, item2.StartTangent, _0023_003DzccAR5G0_003D, list2);
				_0023_003DzXM6YnhkiXp7S(item.StartPoint, item2.EndPoint, item.Domain.Low, item2.Domain.High, item.StartTangent, item2.EndTangent, _0023_003DzccAR5G0_003D, list2);
				_0023_003DzXM6YnhkiXp7S(item.EndPoint, item2.EndPoint, item.Domain.High, item2.Domain.High, item.EndTangent, item2.EndTangent, _0023_003DzccAR5G0_003D, list2);
			}
			for (int k = 0; k < num2; k++)
			{
				double _0023_003DzuwH5j5s_003D = item2.Domain.ParameterAt(_0023_003DzBJFJHwk_003D2[k]);
				for (int l = 0; l < num; l++)
				{
					double _0023_003Dz_eY3Y4c_003D = item.Domain.ParameterAt(_0023_003DzBJFJHwk_003D[l]);
					if (Curve._0023_003DzUhQEKrRzaznj(item, item2, _0023_003Dz_eY3Y4c_003D, _0023_003DzuwH5j5s_003D, out var _0023_003DzqoHxF0k_003D, _0023_003DzccAR5G0_003D, _0023_003DzX0qX_IwWxysi, _0023_003DzfBEBL_o_003D, _0023_003DzQqOWrmM_003D))
					{
						_0023_003DzbIDY9BOTPqfc(_0023_003DzqoHxF0k_003D, list2, _0023_003DzccAR5G0_003D);
					}
					else if (_0023_003DzqoHxF0k_003D != null)
					{
						_0023_003DzbIDY9BOTPqfc(_0023_003DzqoHxF0k_003D, list3, _0023_003DzccAR5G0_003D);
					}
				}
			}
		}
		if (_0023_003DzRn5G27jw1CX8cwaOeA_003D_003D)
		{
			return ((list2.Count > 0) ? list2 : list3).ToArray();
		}
		return list2.ToArray();
	}

	private static int _0023_003DzqwguFGLBjn13(int _0023_003DzbNaBGJB2jTdK, out double[] _0023_003DzBJFJHwk_003D)
	{
		int result;
		if (_0023_003DzbNaBGJB2jTdK == 1)
		{
			result = 1;
			_0023_003DzBJFJHwk_003D = new double[1] { 0.5 };
		}
		else
		{
			result = 3;
			_0023_003DzBJFJHwk_003D = new double[3] { 0.0, 0.5, 1.0 };
		}
		return result;
	}

	internal static double _0023_003Dz_0024lZxMnYFa_0024OQDkZzoQ_003D_003D(ICurve _0023_003DzytDpi1c_003D, ICurve _0023_003Dzn8t0_00249E_003D)
	{
		double val;
		if (_0023_003DzytDpi1c_003D is devDept.Eyeshot.Entities.Point)
		{
			val = double.MaxValue;
		}
		else
		{
			ComputeBoundingBox(((Entity)_0023_003DzytDpi1c_003D).EstimateBoundingBox(null, null), out var boxMin, out var boxMax);
			val = new Size3D(boxMin, boxMax).Diagonal;
		}
		double val2;
		if (_0023_003Dzn8t0_00249E_003D is devDept.Eyeshot.Entities.Point)
		{
			val2 = double.MaxValue;
		}
		else
		{
			ComputeBoundingBox(((Entity)_0023_003Dzn8t0_00249E_003D).EstimateBoundingBox(null, null), out var boxMin2, out var boxMax2);
			val2 = new Size3D(boxMin2, boxMax2).Diagonal;
		}
		return Math.Min(val, val2);
	}

	public static double GetMaxGap(IList<ICurve> sorted, bool closed)
	{
		if (sorted.Count == 1)
		{
			return 0.0;
		}
		double num = double.MinValue;
		if (closed)
		{
			ICurve curve = sorted.Last();
			ICurve curve2 = sorted.First();
			double num2 = Point3D.DistanceSquared(curve2.StartPoint, curve.EndPoint);
			if (num2 > num)
			{
				num = num2;
			}
		}
		for (int i = 0; i < sorted.Count - 1; i++)
		{
			ICurve curve = sorted[i];
			ICurve curve2 = sorted[i + 1];
			double num2 = Point3D.DistanceSquared(curve.EndPoint, curve2.StartPoint);
			if (num2 > num)
			{
				num = num2;
			}
		}
		return Math.Sqrt(num);
	}

	internal static void _0023_003Dz1zSJGNpo0_0024Y5ZWKOCw_003D_003D(Point3D _0023_003DzhfEMngY_003D, Vector3D _0023_003DzxuJqjrs_003D, ref ICurve _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D, out Vector3D _0023_003DzcgQS2OJJ2x_L, out Segment3D _0023_003DzU6QO949msgio)
	{
		_0023_003DzU6QO949msgio = new Segment3D(_0023_003DzhfEMngY_003D, _0023_003DzhfEMngY_003D + _0023_003DzxuJqjrs_003D);
		Curve nurbsForm = _0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D.GetNurbsForm();
		_0023_003DzcgQS2OJJ2x_L = nurbsForm._0023_003Dz2Ew9vDIo4RqEw9OnJ5wRuuQ_003D(_0023_003DzU6QO949msgio, out var _);
		Plane plane = new Plane(_0023_003DzhfEMngY_003D, _0023_003DzcgQS2OJJ2x_L, _0023_003DzxuJqjrs_003D);
		ICurve curve = ((Curve)(_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D = nurbsForm.ProjectOn(plane))).Promote();
		if (curve != null)
		{
			_0023_003DzZ14fQj05Iuu_0024zHzN_0024Q_003D_003D = curve;
		}
	}

	internal static bool _0023_003Dzo47mVhkEPSIxZHOyuA_003D_003D(IList<ICurve> _0023_003DzKTAIrow_003D)
	{
		int count = _0023_003DzKTAIrow_003D.Count;
		if (count == 1)
		{
			return false;
		}
		int num = 0;
		foreach (ICurve item in _0023_003DzKTAIrow_003D)
		{
			if (item is Circle)
			{
				num++;
			}
		}
		int num2 = 0;
		Point3D point3D = null;
		if (num > 0 && count > 2)
		{
			if (Vector3D.AreOpposite(_0023_003DzKTAIrow_003D[count - 1].EndTangent, _0023_003DzKTAIrow_003D[0].StartTangent))
			{
				num2++;
				point3D = _0023_003DzKTAIrow_003D[count - 1].EndPoint;
			}
			for (int i = 0; i < count - 1; i++)
			{
				ICurve curve = _0023_003DzKTAIrow_003D[i];
				ICurve curve2 = _0023_003DzKTAIrow_003D[i + 1];
				if (Vector3D.AreOpposite(curve.EndTangent, curve2.StartTangent))
				{
					num2++;
					Point3D endPoint = curve.EndPoint;
					if (num2 == 2 && endPoint == point3D)
					{
						return true;
					}
					point3D = endPoint;
				}
			}
		}
		return false;
	}

	internal static bool _0023_003Dz1hSRhoQON8zJ(Interval _0023_003DzhbkBViI_003D)
	{
		return Math.Abs(Math.Abs(_0023_003DzhbkBViI_003D.Length) - Math.PI * 2.0) < 1E-12;
	}

	internal static Mesh _0023_003DzWsYKHEAWOPO4(Point3D _0023_003DzF7v9r2A_003D, Point3D _0023_003Dz8dK2uhU_003D)
	{
		Size3D size3D = new Size3D(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		Mesh mesh = Mesh.CreateBox(size3D.X, size3D.Y, size3D.Z);
		mesh.Translate(_0023_003DzF7v9r2A_003D.X, _0023_003DzF7v9r2A_003D.Y, _0023_003DzF7v9r2A_003D.Z);
		return mesh;
	}

	internal static bool _0023_003DzbpVM0qZ9Ah2MD_0024UU2Q_003D_003D(IList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D)
	{
		if (_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count != 2)
		{
			return false;
		}
		foreach (ICurve item in _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D)
		{
			ICurve[] individualCurves = item.GetIndividualCurves();
			for (int i = 0; i < individualCurves.Length; i++)
			{
				if (!(((TrimCurve)individualCurves[i]).Edge is Circle))
				{
					return false;
				}
			}
		}
		ICurve curve = _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[0].GetIndividualCurves().First();
		ICurve curve2 = _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[1].GetIndividualCurves().First();
		if (((TrimCurve)curve).Edge.StartPoint == ((TrimCurve)curve2).Edge.StartPoint)
		{
			return true;
		}
		return false;
	}

	internal static List<int> _0023_003Dz70p_WIcw9IYH_gW4jw_003D_003D(PlanarSurface _0023_003Dz_0024KKopL9T7nzT, IList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D)
	{
		List<int> list = new List<int>();
		if (_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count < 2)
		{
			return list;
		}
		ICurve curve = _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[0];
		for (int i = 1; i < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count; i++)
		{
			ICurve[] individualCurves = _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[i].GetIndividualCurves();
			for (int j = 0; j < individualCurves.Length; j++)
			{
				TrimCurve trimCurve = (TrimCurve)individualCurves[j];
				if (trimCurve.Edge is Circle)
				{
					_0023_003Dz_0024KKopL9T7nzT.Project(((Circle)trimCurve.Edge).Center, out var u, out var v);
					Point3D point3D = new Point3D(u, v);
					curve.ClosestPointTo(point3D, out var t);
					if (AreEqual(((Circle)trimCurve.Edge).Radius, Point3D.Distance(curve.PointAt(t), point3D), ((Circle)trimCurve.Edge).Radius))
					{
						list.Add(i);
						break;
					}
				}
			}
		}
		return list;
	}

	internal static bool _0023_003DziPUjApjASSVs1qNBWsNq8vo_003D(ref Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		bool flag = false;
		List<Point2D> list = new List<Point2D>(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
		int num = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length;
		for (int i = 0; i < num - 1; i++)
		{
			if (((Surface.PolygonPoint)list[i]).TrimCurveIndex == -1 || ((Surface.PolygonPoint)list[i + 1]).TrimCurveIndex == -1)
			{
				continue;
			}
			Segment2D s = new Segment2D(list[i], list[i + 1]);
			int num2 = ((i != num - 3) ? ((i == num - 2) ? 1 : (i + 2)) : 0);
			if (((Surface.PolygonPoint)list[num2]).TrimCurveIndex == -1 || ((Surface.PolygonPoint)list[num2 + 1]).TrimCurveIndex == -1 || !Segment2D.IntersectionLineInternal(new Segment2D(list[num2], list[num2 + 1]), s, out var s2, out var t, out var _))
			{
				continue;
			}
			bool num3 = s2 < -1E-09 || s2 > 1.000000001;
			bool flag2 = t < -1E-09 || t > 1.000000001;
			if (num3 || flag2)
			{
				continue;
			}
			bool flag3 = s2 > 1E-09 && s2 <= 1.0;
			bool flag4 = t >= 0.0 && t < 0.999999999;
			bool flag5 = s2 > -1E-09 && s2 < 1E-09;
			bool flag6 = t > 0.999999999 && t < 1.000000001;
			if (!(flag3 && flag4))
			{
				if (flag3 && flag6)
				{
					list.RemoveAt(num2);
					flag = true;
					num = list.Count;
					i = -1;
				}
				if (flag5 && flag4)
				{
					list.RemoveAt(i + 1);
					flag = true;
					num = list.Count;
					i = -1;
				}
			}
		}
		if (flag)
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = list.ToArray();
		}
		return flag;
	}

	internal static bool _0023_003DzbIDY9BOTPqfc(Point3D _0023_003DzOHpyMcKw0SXo, List<Point3D> _0023_003DzTyB0NW0_003D, double _0023_003DzccAR5G0_003D)
	{
		if (_0023_003DzTyB0NW0_003D.Count == 0)
		{
			_0023_003DzTyB0NW0_003D.Add(_0023_003DzOHpyMcKw0SXo);
			return true;
		}
		foreach (Point3D item in _0023_003DzTyB0NW0_003D)
		{
			if (Point3D.AreEqual(item, _0023_003DzOHpyMcKw0SXo, _0023_003DzccAR5G0_003D * 1000.0) || (Point3D.AreEqual(item, _0023_003DzOHpyMcKw0SXo, _0023_003DzccAR5G0_003D * 1000000.0) && item is InterPoint && ((InterPoint)item).IsTangent && _0023_003DzOHpyMcKw0SXo is InterPoint && ((InterPoint)_0023_003DzOHpyMcKw0SXo).IsTangent && Vector3D.AreCoincident(((InterPoint)item).Tangent, ((InterPoint)_0023_003DzOHpyMcKw0SXo).Tangent)))
			{
				return false;
			}
		}
		_0023_003DzTyB0NW0_003D.Add(_0023_003DzOHpyMcKw0SXo);
		return true;
	}

	internal static bool _0023_003DzPuQvgP_0024VB6nsFeK9mVC99MQ_003D(Point3D _0023_003DzOHpyMcKw0SXo, List<Point3D> _0023_003DzTyB0NW0_003D, double _0023_003DzccAR5G0_003D, ICurve _0023_003DzytDpi1c_003D, ICurve _0023_003Dzn8t0_00249E_003D)
	{
		if (_0023_003DzTyB0NW0_003D.Count == 0)
		{
			_0023_003DzTyB0NW0_003D.Add(_0023_003DzOHpyMcKw0SXo);
			return true;
		}
		Interval interval = ((_0023_003DzytDpi1c_003D.Domain.Length > _0023_003Dzn8t0_00249E_003D.Domain.Length) ? _0023_003DzytDpi1c_003D.Domain : _0023_003Dzn8t0_00249E_003D.Domain);
		double u = ((InterPoint)_0023_003DzOHpyMcKw0SXo).u;
		double s = ((InterPoint)_0023_003DzOHpyMcKw0SXo).s;
		foreach (Point3D item in _0023_003DzTyB0NW0_003D)
		{
			double u2 = ((InterPoint)item).u;
			double s2 = ((InterPoint)item).s;
			if ((Point3D.AreEqual(item, _0023_003DzOHpyMcKw0SXo, _0023_003DzccAR5G0_003D * 1000.0) && ((AreEqual(u2, u, interval.Length) && AreEqual(s2, s, interval.Length)) || _0023_003DzYkykZnu03qclmT3e2WBGjZo_003D(u2, u, _0023_003DzytDpi1c_003D) || _0023_003DzYkykZnu03qclmT3e2WBGjZo_003D(s2, s, _0023_003Dzn8t0_00249E_003D))) || (Point3D.AreEqual(item, _0023_003DzOHpyMcKw0SXo, _0023_003DzccAR5G0_003D * 1000000.0) && item is InterPoint && ((InterPoint)item).IsTangent && _0023_003DzOHpyMcKw0SXo is InterPoint && ((InterPoint)_0023_003DzOHpyMcKw0SXo).IsTangent && Vector3D.AreCoincident(((InterPoint)item).Tangent, ((InterPoint)_0023_003DzOHpyMcKw0SXo).Tangent)))
			{
				return false;
			}
		}
		_0023_003DzTyB0NW0_003D.Add(_0023_003DzOHpyMcKw0SXo);
		return true;
	}

	internal static bool _0023_003DzYkykZnu03qclmT3e2WBGjZo_003D(double _0023_003DzsK_Xndk_003D, double _0023_003Dz0ADyCos_003D, ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		if (!_0023_003Dz8fpRyMu9aKjE.IsClosed)
		{
			return false;
		}
		if ((AreEqual(_0023_003DzsK_Xndk_003D, _0023_003Dz8fpRyMu9aKjE.Domain.Low, _0023_003Dz8fpRyMu9aKjE.Domain.Length) && AreEqual(_0023_003Dz0ADyCos_003D, _0023_003Dz8fpRyMu9aKjE.Domain.High, _0023_003Dz8fpRyMu9aKjE.Domain.Length)) || (AreEqual(_0023_003Dz0ADyCos_003D, _0023_003Dz8fpRyMu9aKjE.Domain.Low, _0023_003Dz8fpRyMu9aKjE.Domain.Length) && AreEqual(_0023_003DzsK_Xndk_003D, _0023_003Dz8fpRyMu9aKjE.Domain.High, _0023_003Dz8fpRyMu9aKjE.Domain.Length)))
		{
			return true;
		}
		return false;
	}

	internal static bool _0023_003Dz_Dm7r9Ftq7Ss(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003DzxH4ozIo_003D)
	{
		return Math.Abs(_0023_003Dz1v6oPQk_003D - _0023_003DzjbqS1qE_003D) / _0023_003DzxH4ozIo_003D < 0.001;
	}

	internal static bool _0023_003DzLQiOPy8NYuPb(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003DzxH4ozIo_003D)
	{
		return Math.Abs(_0023_003Dz1v6oPQk_003D - _0023_003DzjbqS1qE_003D) / _0023_003DzxH4ozIo_003D < 0.0001;
	}

	internal static bool _0023_003DzucHjZcB1y1ms(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003DzxH4ozIo_003D)
	{
		return Math.Abs(_0023_003Dz1v6oPQk_003D - _0023_003DzjbqS1qE_003D) / _0023_003DzxH4ozIo_003D < 1E-05;
	}

	internal static bool _0023_003DzuW42NHK3HaLL(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003DzxH4ozIo_003D)
	{
		return Math.Abs(_0023_003Dz1v6oPQk_003D - _0023_003DzjbqS1qE_003D) / _0023_003DzxH4ozIo_003D < 1E-06;
	}

	internal static bool _0023_003DzU9tnUTcA5PB7(Point3D _0023_003DzFj_0024IqDQ_003D, Segment3D _0023_003DzSwfghCo_003D)
	{
		return Math.Abs(_0023_003DzFj_0024IqDQ_003D.DistanceTo(_0023_003DzSwfghCo_003D)) < _0023_003DzheSR8QM7q9ya;
	}

	private static bool _0023_003DzU9tnUTcA5PB7(Plane _0023_003DzJ7Ot5RuMhdMpo_6azw_003D_003D, Point2D _0023_003DzlY77YgY_003D, Segment3D _0023_003DzSwfghCo_003D)
	{
		return _0023_003DzU9tnUTcA5PB7(_0023_003DzJ7Ot5RuMhdMpo_6azw_003D_003D.PointAt(_0023_003DzlY77YgY_003D), _0023_003DzSwfghCo_003D);
	}

	public static int GetCpuCount(int len, out int[] startIndex, out int[] endIndex)
	{
		int num = Environment.ProcessorCount;
		if (num > len)
		{
			num = len;
		}
		int num2 = len / num;
		int num3 = len % num;
		startIndex = new int[num];
		endIndex = new int[num];
		for (int i = 0; i < num; i++)
		{
			startIndex[i] = num2 * i;
			endIndex[i] = num2 * (i + 1);
			if (i == num - 1 && num3 > 0)
			{
				endIndex[i] += num3;
			}
		}
		return num;
	}

	internal static bool _0023_003DzinOQp4_qBUm4opZWpg_003D_003D(Transformation _0023_003DzNDQ_E88_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		Point2D[] array = new Point2D[_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length];
		for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length; i++)
		{
			array[i] = _0023_003DzNDQ_E88_003D * _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i];
		}
		return IsOrientedClockwise(array);
	}

	internal static bool _0023_003DzinOQp4_qBUm4opZWpg_003D_003D(IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Plane _0023_003Dzrgqz890sj_0024X9)
	{
		return PolygonArea(_0023_003Dzrgqz890sj_0024X9.AxisZ, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D) < 0.0;
	}

	internal static Point3D[] _0023_003Dzm2WwrkTQN7Q4HSrEZQ_003D_003D(IList<ICurve> _0023_003Dzk4NDdBsFY7McXKKk7Q_003D_003D)
	{
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i < _0023_003Dzk4NDdBsFY7McXKKk7Q_003D_003D.Count; i++)
		{
			ICurve curve = _0023_003Dzk4NDdBsFY7McXKKk7Q_003D_003D[i];
			if (curve is Line)
			{
				list.Add(curve.StartPoint);
			}
			else if (curve is Curve)
			{
				for (int j = 0; j < ((Curve)curve).Pw.Length - 1; j++)
				{
					list.Add(((Curve)curve).Pw[j].Euclid);
				}
			}
			else if (curve is LinearPath)
			{
				for (int k = 0; k < ((LinearPath)curve).Vertices.Length - 1; k++)
				{
					list.Add(((LinearPath)curve).Vertices[k]);
				}
			}
			else if (curve is Circle || curve is Ellipse)
			{
				list.Add(curve.StartPoint);
				list.Add(curve.PointAt(curve.Domain.Mid));
			}
		}
		list.Add(_0023_003Dzk4NDdBsFY7McXKKk7Q_003D_003D[_0023_003Dzk4NDdBsFY7McXKKk7Q_003D_003D.Count - 1].EndPoint);
		return list.ToArray();
	}

	internal static void _0023_003Dz0U2l9p_0024wMUWMI2xPGxvwVTCSGwVr(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, out IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out IList<IList<Point3D>> _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D, out bool _0023_003DzJlv_CuAUfJRQ, bool _0023_003Dz5q1w0P79Gecn)
	{
		_0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, out _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D);
		_0023_003DzJlv_CuAUfJRQ = _0023_003DzSOQm2JeuhlBjZ46sDLoENc_0024rSbvZ(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003Dz5q1w0P79Gecn);
	}

	internal static bool _0023_003DzSOQm2JeuhlBjZ46sDLoENc_0024rSbvZ(IList<Point3D> _0023_003Dz_SqBXz8_003D, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, bool _0023_003DzbErHvVw_003D)
	{
		bool num = _0023_003Dz11IEgMLMt0KBMRc2f_slIVEN75jF3sqyuQ_003D_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D);
		if (!num && _0023_003DzbErHvVw_003D && !IsClosedProfile(_0023_003Dz_SqBXz8_003D))
		{
			throw new EyeshotException(_0023_003DzbxpIQIB9BGm6f2E7IA_003D_003D);
		}
		return num;
	}

	internal static bool _0023_003DzSOQm2JeuhlBjZ46sDLoENc_0024rSbvZ(Plane _0023_003DzJ7Ot5RuMhdMpo_6azw_003D_003D, IList<Point2D> _0023_003Dz_SqBXz8_003D, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D, bool _0023_003DzbErHvVw_003D)
	{
		bool num = _0023_003Dz11IEgMLMt0KBMRc2f_slIVEN75jF3sqyuQ_003D_003D(_0023_003DzJ7Ot5RuMhdMpo_6azw_003D_003D, _0023_003DzxuJqjrs_003D, _0023_003DzbUvT9Pc_003D, _0023_003Dz_SqBXz8_003D);
		if (!num && _0023_003DzbErHvVw_003D && !IsClosedProfile(_0023_003Dz_SqBXz8_003D))
		{
			throw new EyeshotException(_0023_003DzbxpIQIB9BGm6f2E7IA_003D_003D);
		}
		return num;
	}

	internal static bool _0023_003Dz11IEgMLMt0KBMRc2f_slIVEN75jF3sqyuQ_003D_003D(IList<Point3D> _0023_003Dz06A5WivSSyUp, Vector3D _0023_003Dz_0024w9jM1UEOK_U, Point3D _0023_003DzyNZquWXQaPzE)
	{
		Segment3D _0023_003DzSwfghCo_003D = new Segment3D(_0023_003DzyNZquWXQaPzE, _0023_003DzyNZquWXQaPzE + _0023_003Dz_0024w9jM1UEOK_U);
		for (int i = 0; i < _0023_003Dz06A5WivSSyUp.Count; i++)
		{
			if (_0023_003DzU9tnUTcA5PB7(_0023_003Dz06A5WivSSyUp[i], _0023_003DzSwfghCo_003D))
			{
				return true;
			}
		}
		return false;
	}

	internal static bool _0023_003Dz11IEgMLMt0KBMRc2f_slIVEN75jF3sqyuQ_003D_003D(Plane _0023_003DzJ7Ot5RuMhdMpo_6azw_003D_003D, Vector3D _0023_003Dz_0024w9jM1UEOK_U, Point3D _0023_003DzyNZquWXQaPzE, IList<Point2D> _0023_003Dz06A5WivSSyUp)
	{
		Segment3D _0023_003DzSwfghCo_003D = new Segment3D(_0023_003DzyNZquWXQaPzE, _0023_003DzyNZquWXQaPzE + _0023_003Dz_0024w9jM1UEOK_U);
		if (_0023_003DzU9tnUTcA5PB7(_0023_003DzJ7Ot5RuMhdMpo_6azw_003D_003D, _0023_003Dz06A5WivSSyUp[0], _0023_003DzSwfghCo_003D))
		{
			return _0023_003DzU9tnUTcA5PB7(_0023_003DzJ7Ot5RuMhdMpo_6azw_003D_003D, _0023_003Dz06A5WivSSyUp[_0023_003Dz06A5WivSSyUp.Count - 1], _0023_003DzSwfghCo_003D);
		}
		return false;
	}

	internal static void _0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, out IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out IList<IList<Point3D>> _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D)
	{
		_0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, new RegenParams(_0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D), out _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D);
	}

	internal static void _0023_003Dz5qFihJK3ui08U0cFuA_003D_003D(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, RegenParams _0023_003DzELu0Pss_003D, out IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out IList<IList<Point3D>> _0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D)
	{
		Point3D[] array = ((Entity)_0023_003Dz_SqBXz8_003D)._0023_003DzDphw2mIGq8srlxP4lA_003D_003D(_0023_003DzELu0Pss_003D);
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = array;
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			_0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D = new List<IList<Point3D>>();
			for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
			{
				array = ((Entity)_0023_003DzWaFlkhfmYCja[i])._0023_003DzDphw2mIGq8srlxP4lA_003D_003D(_0023_003DzELu0Pss_003D);
				_0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D.Add(array);
			}
		}
		else
		{
			_0023_003Dz4wuqSPX7HM8QPCsxGzdLeic_003D = null;
		}
	}

	public static void FlipTriangles(IList<IndexTriangle> triangles)
	{
		if (triangles == null || triangles.Count == 0)
		{
			return;
		}
		for (int i = 0; i < triangles.Count; i++)
		{
			IndexTriangle indexTriangle = triangles[i];
			int v = indexTriangle.V2;
			indexTriangle.V2 = indexTriangle.V3;
			indexTriangle.V3 = v;
		}
		if (triangles[0] is ITriangleSupportsTextureCoords)
		{
			for (int j = 0; j < triangles.Count; j++)
			{
				ITriangleSupportsTextureCoords obj = (ITriangleSupportsTextureCoords)triangles[j];
				int t = obj.T2;
				obj.T2 = obj.T3;
				obj.T3 = t;
			}
		}
		if (triangles[0] is ITriangleSupportsNormals)
		{
			for (int k = 0; k < triangles.Count; k++)
			{
				ITriangleSupportsNormals obj2 = (ITriangleSupportsNormals)triangles[k];
				int n = obj2.N2;
				obj2.N2 = obj2.N3;
				obj2.N3 = n;
			}
		}
	}

	internal static Vector3D _0023_003DzZ2FGq78_003D(ICurve _0023_003Dz8fpRyMu9aKjE, bool _0023_003DzMnu3zKCWb6Kc)
	{
		if (_0023_003Dz8fpRyMu9aKjE is Line)
		{
			return ((Line)_0023_003Dz8fpRyMu9aKjE).Tangent;
		}
		if (_0023_003Dz8fpRyMu9aKjE is Arc)
		{
			Arc arc = (Arc)_0023_003Dz8fpRyMu9aKjE;
			return arc.TangentAt(_0023_003DzMnu3zKCWb6Kc ? arc.Domain.t1 : arc.Domain.t0);
		}
		if (_0023_003Dz8fpRyMu9aKjE is Circle)
		{
			return ((Circle)_0023_003Dz8fpRyMu9aKjE).StartTangent;
		}
		if (_0023_003Dz8fpRyMu9aKjE is EllipticalArc)
		{
			EllipticalArc ellipticalArc = (EllipticalArc)_0023_003Dz8fpRyMu9aKjE;
			return ellipticalArc.TangentAt(_0023_003DzMnu3zKCWb6Kc ? ellipticalArc.Domain.t1 : ellipticalArc.Domain.t0);
		}
		if (_0023_003Dz8fpRyMu9aKjE is Ellipse)
		{
			return ((Ellipse)_0023_003Dz8fpRyMu9aKjE).StartTangent;
		}
		if (_0023_003Dz8fpRyMu9aKjE is LinearPath)
		{
			LinearPath linearPath = (LinearPath)_0023_003Dz8fpRyMu9aKjE;
			return linearPath.TangentAt(_0023_003DzMnu3zKCWb6Kc ? linearPath.Domain.t1 : linearPath.Domain.t0);
		}
		if (_0023_003Dz8fpRyMu9aKjE is Curve)
		{
			Curve curve = (Curve)_0023_003Dz8fpRyMu9aKjE;
			return curve.TangentAt(_0023_003DzMnu3zKCWb6Kc ? curve.Domain.High : curve.Domain.Low);
		}
		throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660735) + _0023_003Dz8fpRyMu9aKjE.GetType());
	}

	internal static void _0023_003DzUF5dE52DL3PQ(ICurve _0023_003DzqT6kZ6g_003D, ICurve _0023_003DzHgrHIfhYCh4p, ICurve _0023_003DzHXbzvx8ZY9nt, ref Plane _0023_003DzStUznlUnGSG5, sweepMethodType _0023_003Dzjy_YX_0024o_003D, bool _0023_003Dz3fpuiiI_003D)
	{
		bool flag = _0023_003DzZEROl_YJ_9b_0024tIOMvw_003D_003D._0023_003DzwAfFvoy42C6h();
		Plane[] array = (flag ? _0023_003DzZ9QiwSvQlgr8(_0023_003DzHgrHIfhYCh4p.GetNurbsForm(), _0023_003DzStUznlUnGSG5, _0023_003Dzjy_YX_0024o_003D) : new Plane[2]
		{
			new Plane(_0023_003DzHgrHIfhYCh4p.StartTangent)
			{
				Origin = (Point3D)_0023_003DzHgrHIfhYCh4p.StartPoint.Clone()
			},
			new Plane(_0023_003DzHgrHIfhYCh4p.EndTangent)
			{
				Origin = (Point3D)_0023_003DzHgrHIfhYCh4p.EndPoint.Clone()
			}
		});
		if (_0023_003Dz3fpuiiI_003D)
		{
			_0023_003DzStUznlUnGSG5 = array[^1];
		}
		Transformation transformation = new Transformation();
		Plane[] array2 = null;
		if (_0023_003DzHXbzvx8ZY9nt != null)
		{
			Vector3D v = _0023_003DzZ2FGq78_003D(_0023_003DzHXbzvx8ZY9nt, _0023_003DzMnu3zKCWb6Kc: false);
			if (!Vector3D.AreCoincident(_0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p, _0023_003DzMnu3zKCWb6Kc: true), v, 1E-06))
			{
				if (flag)
				{
					array2 = _0023_003DzZ9QiwSvQlgr8(_0023_003DzHXbzvx8ZY9nt.GetNurbsForm(), array[^1], _0023_003Dzjy_YX_0024o_003D);
				}
				else
				{
					Plane plane = (Plane)array[^1].Clone();
					double angleInRadians = Vector3D.AngleBetween(plane.AxisZ, _0023_003DzHXbzvx8ZY9nt.StartTangent);
					Plane plane2 = new Plane(plane.Origin, plane.AxisZ, _0023_003DzHXbzvx8ZY9nt.StartTangent);
					plane.Rotate(angleInRadians, plane2.AxisZ);
					array2 = new Plane[1]
					{
						new Plane((Point3D)_0023_003DzHXbzvx8ZY9nt.StartPoint.Clone(), plane.AxisX, plane.AxisY)
					};
				}
			}
		}
		if (_0023_003DzHgrHIfhYCh4p is Arc)
		{
			Arc arc = (Arc)_0023_003DzHgrHIfhYCh4p;
			((Entity)_0023_003DzqT6kZ6g_003D).Rotate(arc.AngleInRadians, arc.Plane.AxisZ, arc.Center);
			if (array2 != null)
			{
				transformation.Rotation(array[^1], array2[0]);
				((Entity)_0023_003DzqT6kZ6g_003D).TransformBy(transformation);
			}
		}
		else
		{
			if (_0023_003DzHgrHIfhYCh4p is Line && _0023_003Dzjy_YX_0024o_003D == sweepMethodType.FrenetSerret)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660680));
			}
			transformation.Rotation(array[0], (array2 == null) ? array[^1] : array2[0]);
			((Entity)_0023_003DzqT6kZ6g_003D).TransformBy(transformation);
		}
	}

	internal static double _0023_003DzgP4qC37WNH1g(ICurve _0023_003DzCRq4LBU_003D)
	{
		return _0023_003DzCRq4LBU_003D.Length() * 4.0;
	}

	internal static void _0023_003Dzdh_4OQddxCSDDYZ27Q_003D_003D(ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, bool _0023_003DzFSLBkBecx_0024NX, out ICurve[] _0023_003DzmO_0024kvb27FfjoVav64A_003D_003D, bool _0023_003Dz6SBnzmNnw6lO)
	{
		ICurve[] individualCurves = _0023_003Dz8fpRyMu9aKjE.GetIndividualCurves();
		List<ICurve> list = new List<ICurve>();
		ICurve[] array = individualCurves;
		foreach (ICurve curve in array)
		{
			if (curve is Line || curve is Arc || curve is devDept.Eyeshot.Entities.Point)
			{
				list.Add(curve);
				continue;
			}
			if (curve is Circle)
			{
				Circle circle = (Circle)curve;
				Arc item = new Arc((Plane)circle.Plane.Clone(), (Point3D)circle.Center.Clone(), circle.Radius, 0.0, Math.PI * 2.0);
				list.Add(item);
				continue;
			}
			if (curve is LinearPath)
			{
				ICurve[] individualCurves2 = curve.GetIndividualCurves();
				list.AddRange(individualCurves2);
				continue;
			}
			if (curve is Ellipse { IsCircle: not false } ellipse)
			{
				if (curve is EllipticalArc ellipticalArc)
				{
					list.Add(new Arc(ellipticalArc.Plane, ellipticalArc.Center, ellipticalArc.RadiusX, ellipticalArc.Domain.Low, ellipticalArc.Domain.High));
				}
				else
				{
					list.Add(new Circle(ellipse.Plane, ellipse.Center, ellipse.RadiusX));
				}
				continue;
			}
			if (!_0023_003DzFSLBkBecx_0024NX && !(curve is Curve))
			{
				if (curve is EllipticalArc)
				{
					list.Add(curve);
				}
				else if (curve is Ellipse)
				{
					Ellipse ellipse2 = (Ellipse)curve;
					EllipticalArc item2 = new EllipticalArc((Plane)ellipse2.Plane.Clone(), (Point3D)ellipse2.Center.Clone(), ellipse2.RadiusX, ellipse2.RadiusY, 0.0, Math.PI * 2.0);
					list.Add(item2);
				}
				continue;
			}
			Curve curve2 = (Curve)curve.GetNurbsForm().Clone();
			ICurve[] array2 = null;
			if (curve2._0023_003Dz9V15q_0Tnbjf())
			{
				ICurve[] array3 = curve2.SplitAtDiscontinuities(!_0023_003Dz6SBnzmNnw6lO);
				array2 = array3;
			}
			else
			{
				ICurve[] array3 = new Curve[1] { curve2 };
				array2 = array3;
			}
			if (curve2.Degree == 1 || !_0023_003DzFSLBkBecx_0024NX)
			{
				list.AddRange(array2);
				continue;
			}
			for (int j = 0; j < array2.Length; j++)
			{
				Curve curve3 = (Curve)array2[j];
				curve3.Regen(_0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D);
				int num = curve3.Vertices.Length;
				int num2 = curve3.KnotVector.Length;
				List<double> list2 = new List<double>(Math.Min(num, num2));
				int num3 = 0;
				for (int k = 1; k < num - 1; k++)
				{
					double u = ((PointTangentU)curve3.Vertices[k]).U;
					for (int l = num3; l < num2; l++)
					{
						if (curve3.KnotVector[l] < u)
						{
							num3 = l;
							continue;
						}
						if (Math.Abs(curve3.KnotVector[l] - u) > curve3.Domain.Length * 0.001)
						{
							list2.Add(u);
						}
						break;
					}
				}
				if (list2.Count > 0)
				{
					curve3.RefineKnotVector(list2.ToArray());
				}
				list.Add(curve3);
			}
		}
		_0023_003DzmO_0024kvb27FfjoVav64A_003D_003D = list.ToArray();
	}

	internal static void _0023_003Dzi_uJo1YauacTvNQ2CLEP2dc_003D(ICurve[] _0023_003DzHgrHIfhYCh4p, int _0023_003DzYnrMIDOkBgMJ, ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, out Arc _0023_003Dz5q4tZUlCeE1_P3aNGjVSGDY_003D, out Arc _0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D, out Plane _0023_003DzBUOXmQB5RSyh, out Plane _0023_003DzoiaZ_4eSUI1q, out ICurve _0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, out IList<ICurve> _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D, bool _0023_003DzHbb9s4FIaFfq, bool _0023_003DzqZLpJx9EBl4E2J4o3A9hYdM_003D)
	{
		Arc arc = null;
		if (_0023_003DzHgrHIfhYCh4p[_0023_003DzYnrMIDOkBgMJ].GetType() == typeof(Circle))
		{
			Circle circle = (Circle)_0023_003DzHgrHIfhYCh4p[_0023_003DzYnrMIDOkBgMJ];
			arc = new Arc(circle.Plane, circle.Center, circle.Radius, 0.0, Math.PI * 2.0);
		}
		else
		{
			arc = (Arc)_0023_003DzHgrHIfhYCh4p[_0023_003DzYnrMIDOkBgMJ];
		}
		((Entity)_0023_003Dz_SqBXz8_003D).Regen(_0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
		double num = arc.AngleInRadians / 2.0;
		double num3;
		double num2 = (num3 = arc.Domain.t0);
		double num5;
		double num4 = (num5 = arc.Domain.t1);
		_0023_003DzBUOXmQB5RSyh = (_0023_003DzoiaZ_4eSUI1q = null);
		_0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D = null;
		Vector3D vect = arc.TangentAt(arc.Domain.t0);
		_0023_003DzPesVNJCLTBDwAAMTkw_003D_003D = _0023_003Dz_SqBXz8_003D;
		_0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D = _0023_003DzWaFlkhfmYCja;
		if (_0023_003DzYnrMIDOkBgMJ > 0)
		{
			Vector3D vect2 = _0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p[_0023_003DzYnrMIDOkBgMJ - 1], _0023_003DzMnu3zKCWb6Kc: true);
			if (GetCutPlane(vect, vect2, arc.StartPoint, invertSide: true, out _0023_003DzBUOXmQB5RSyh, out var _))
			{
				_0023_003Dz4DvtTTqN1dB7(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, num, arc, out _0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, out _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D);
				num2 += num;
				double num6 = _0023_003Dz13vJeqF07anV39xM0A_003D_003D(((Entity)_0023_003Dz_SqBXz8_003D).Vertices, arc.Center, arc.StartPoint, arc.StartPoint, arc.StartTangent);
				num4 = num2 - num - num6;
				num3 = num2;
			}
		}
		if (_0023_003DzYnrMIDOkBgMJ < _0023_003DzHgrHIfhYCh4p.Length - 1 || (_0023_003DzYnrMIDOkBgMJ == _0023_003DzHgrHIfhYCh4p.Length - 1 && _0023_003DzHbb9s4FIaFfq))
		{
			Vector3D vect2 = ((!_0023_003DzHbb9s4FIaFfq || _0023_003DzYnrMIDOkBgMJ != _0023_003DzHgrHIfhYCh4p.Length - 1) ? _0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p[_0023_003DzYnrMIDOkBgMJ + 1], _0023_003DzMnu3zKCWb6Kc: false) : _0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p[0], _0023_003DzMnu3zKCWb6Kc: false));
			vect = arc.TangentAt(arc.Domain.t1);
			if (GetCutPlane(vect, vect2, arc.EndPoint, invertSide: false, out _0023_003DzoiaZ_4eSUI1q, out var _))
			{
				num3 = arc.Domain.t0 + num;
				double num7 = _0023_003Dz13vJeqF07anV39xM0A_003D_003D(((Entity)_0023_003Dz_SqBXz8_003D).Vertices, arc.Center, arc.StartPoint, arc.EndPoint, arc.EndTangent);
				num5 = num3 + num + num7;
				if (num2 == arc.Domain.t0)
				{
					num2 = num3;
					num4 = num2 - num;
					_0023_003Dz4DvtTTqN1dB7(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, num, arc, out _0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, out _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D);
				}
			}
		}
		if (_0023_003DzYnrMIDOkBgMJ == 0 && _0023_003DzHbb9s4FIaFfq)
		{
			Vector3D vect2 = _0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p[^1], _0023_003DzMnu3zKCWb6Kc: true);
			vect = arc.TangentAt(arc.Domain.t0);
			if (GetCutPlane(vect, vect2, arc.StartPoint, invertSide: true, out _0023_003DzBUOXmQB5RSyh, out var _))
			{
				num3 = arc.Domain.t0 + num;
				double num8 = _0023_003Dz13vJeqF07anV39xM0A_003D_003D(((Entity)_0023_003Dz_SqBXz8_003D).Vertices, arc.Center, arc.StartPoint, arc.StartPoint, arc.StartTangent);
				num5 = num3 + num + num8;
				if (num2 == arc.Domain.t0)
				{
					num2 = num3;
					num4 = num2 - num;
					_0023_003Dz4DvtTTqN1dB7(_0023_003Dz_SqBXz8_003D, _0023_003DzWaFlkhfmYCja, num, arc, out _0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, out _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D);
				}
			}
		}
		_0023_003Dz5q4tZUlCeE1_P3aNGjVSGDY_003D = new Arc(arc.Plane, arc.Center, arc.Radius, num2, num4);
		if (num2 != num3 || num4 != num5)
		{
			_0023_003DzU9BmYtsML4TsZeumM2Cxy_0024Q_003D = new Arc(arc.Plane, arc.Center, arc.Radius, num3, num5);
		}
	}

	internal static void _0023_003Dz4DvtTTqN1dB7(ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzRirVIphRT_mQ, Arc _0023_003DzN4MDZ_0024c_003D, out ICurve _0023_003DzPesVNJCLTBDwAAMTkw_003D_003D, out IList<ICurve> _0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D)
	{
		_0023_003DzPesVNJCLTBDwAAMTkw_003D_003D = (ICurve)_0023_003Dz_SqBXz8_003D.Clone();
		((Entity)_0023_003DzPesVNJCLTBDwAAMTkw_003D_003D).Rotate(_0023_003DzRirVIphRT_mQ, _0023_003DzN4MDZ_0024c_003D.Plane.AxisZ, _0023_003DzN4MDZ_0024c_003D.Center);
		if (_0023_003DzWaFlkhfmYCja != null)
		{
			_0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D = new ICurve[_0023_003DzWaFlkhfmYCja.Count];
			for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
			{
				_0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D[i] = (ICurve)_0023_003DzWaFlkhfmYCja[i].Clone();
				((Entity)_0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D[i]).Rotate(_0023_003DzRirVIphRT_mQ, _0023_003DzN4MDZ_0024c_003D.Plane.AxisZ, _0023_003DzN4MDZ_0024c_003D.Center);
			}
		}
		else
		{
			_0023_003DzNwi0hLXqrQquQeDmpt5VUrs_003D = _0023_003DzWaFlkhfmYCja;
		}
	}

	internal static void _0023_003Dz1yAuzVNQoxYxTpKKvl0luLRLQKl2(ICurve[] _0023_003DzHgrHIfhYCh4p, int _0023_003DzYnrMIDOkBgMJ, ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzC5YR9r5C06bj, out Line _0023_003DzPkEEDqSBB15OEaA9iw_003D_003D, out Plane _0023_003DzBUOXmQB5RSyh, out Plane _0023_003DzoiaZ_4eSUI1q, out ICurve _0023_003Dzx5RboRHsRXS2, out IList<ICurve> _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D, bool _0023_003DzHbb9s4FIaFfq)
	{
		Line line = (Line)_0023_003DzHgrHIfhYCh4p[_0023_003DzYnrMIDOkBgMJ];
		Point3D offsetPoint = line.StartPoint;
		Point3D offsetPoint2 = line.EndPoint;
		_0023_003DzBUOXmQB5RSyh = (_0023_003DzoiaZ_4eSUI1q = null);
		Vector3D tangent = line.Tangent;
		_0023_003Dzx5RboRHsRXS2 = (ICurve)_0023_003Dz_SqBXz8_003D.Clone();
		_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D = new List<ICurve>();
		int num = 0;
		while (_0023_003DzWaFlkhfmYCja != null && num < _0023_003DzWaFlkhfmYCja.Count)
		{
			_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D.Add((ICurve)_0023_003DzWaFlkhfmYCja[num].Clone());
			num++;
		}
		if (_0023_003DzYnrMIDOkBgMJ > 0)
		{
			Vector3D vector3D = _0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p[_0023_003DzYnrMIDOkBgMJ - 1], _0023_003DzMnu3zKCWb6Kc: true);
			if (GetCutPlane(tangent, vector3D, line.StartPoint, invertSide: true, out _0023_003DzBUOXmQB5RSyh, out var _))
			{
				OffsetPoint(line.EndPoint, line.StartPoint, _0023_003DzC5YR9r5C06bj, out offsetPoint);
				Vector3D v = Vector3D.Subtract(offsetPoint, line.StartPoint);
				Vector3D.AngleBetween(tangent, vector3D);
				((Entity)_0023_003Dzx5RboRHsRXS2).Translate(v);
				if (_0023_003DzWaFlkhfmYCja != null)
				{
					_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D = new ICurve[_0023_003DzWaFlkhfmYCja.Count];
					for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
					{
						_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D[i] = (ICurve)_0023_003DzWaFlkhfmYCja[i].Clone();
						((Entity)_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D[i]).Translate(v);
					}
				}
			}
		}
		if (_0023_003DzYnrMIDOkBgMJ < _0023_003DzHgrHIfhYCh4p.Length - 1 || (_0023_003DzYnrMIDOkBgMJ == _0023_003DzHgrHIfhYCh4p.Length - 1 && _0023_003DzHbb9s4FIaFfq))
		{
			Vector3D vector3D = ((!_0023_003DzHbb9s4FIaFfq || _0023_003DzYnrMIDOkBgMJ != _0023_003DzHgrHIfhYCh4p.Length - 1) ? _0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p[_0023_003DzYnrMIDOkBgMJ + 1], _0023_003DzMnu3zKCWb6Kc: false) : _0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p[0], _0023_003DzMnu3zKCWb6Kc: false));
			if (GetCutPlane(tangent, vector3D, line.EndPoint, invertSide: false, out _0023_003DzoiaZ_4eSUI1q, out var _))
			{
				OffsetPoint(line.StartPoint, line.EndPoint, _0023_003DzC5YR9r5C06bj, out offsetPoint2);
			}
		}
		if (_0023_003DzYnrMIDOkBgMJ == 0 && _0023_003DzHbb9s4FIaFfq)
		{
			Vector3D vector3D = _0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p[^1], _0023_003DzMnu3zKCWb6Kc: true);
			if (GetCutPlane(tangent, vector3D, line.StartPoint, invertSide: true, out _0023_003DzBUOXmQB5RSyh, out var _))
			{
				OffsetPoint(line.EndPoint, line.StartPoint, _0023_003DzC5YR9r5C06bj, out offsetPoint);
			}
			Vector3D v2 = Vector3D.Subtract(offsetPoint, line.StartPoint);
			_0023_003Dzx5RboRHsRXS2 = (ICurve)_0023_003Dz_SqBXz8_003D.Clone();
			((Entity)_0023_003Dzx5RboRHsRXS2).Translate(v2);
			if (_0023_003DzWaFlkhfmYCja != null)
			{
				_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D = new ICurve[_0023_003DzWaFlkhfmYCja.Count];
				for (int j = 0; j < _0023_003DzWaFlkhfmYCja.Count; j++)
				{
					_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D[j] = (ICurve)_0023_003DzWaFlkhfmYCja[j].Clone();
					((Entity)_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D[j]).Translate(v2);
				}
			}
		}
		_0023_003DzPkEEDqSBB15OEaA9iw_003D_003D = new Line(offsetPoint, offsetPoint2);
	}

	internal static void _0023_003DzaJ_0024f2lo0_00243GgxkJ85CDhnYs_003D(ICurve[] _0023_003DzHgrHIfhYCh4p, int _0023_003DzYnrMIDOkBgMJ, ICurve _0023_003Dz_SqBXz8_003D, IList<ICurve> _0023_003DzWaFlkhfmYCja, double _0023_003DzC5YR9r5C06bj, out Line _0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D, out Line _0023_003DzYsh7vg3YvPj33Pvt8w_003D_003D, out Plane _0023_003DzBUOXmQB5RSyh, out Plane _0023_003DzoiaZ_4eSUI1q, out ICurve _0023_003Dzx5RboRHsRXS2, out IList<ICurve> _0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D, bool _0023_003DzHbb9s4FIaFfq)
	{
		ICurve curve = _0023_003DzHgrHIfhYCh4p[_0023_003DzYnrMIDOkBgMJ];
		Point3D point3D = curve.StartPoint;
		Point3D offsetPoint = curve.EndPoint;
		_0023_003DzBUOXmQB5RSyh = (_0023_003DzoiaZ_4eSUI1q = null);
		Vector3D startTangent = curve.StartTangent;
		_0023_003Dzx5RboRHsRXS2 = (ICurve)_0023_003Dz_SqBXz8_003D.Clone();
		_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D = new List<ICurve>();
		int num = 0;
		while (_0023_003DzWaFlkhfmYCja != null && num < _0023_003DzWaFlkhfmYCja.Count)
		{
			_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D.Add((ICurve)_0023_003DzWaFlkhfmYCja[num].Clone());
			num++;
		}
		if (_0023_003DzYnrMIDOkBgMJ == 0 && _0023_003DzHbb9s4FIaFfq)
		{
			Vector3D vect = _0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p[^1], _0023_003DzMnu3zKCWb6Kc: true);
			if (GetCutPlane(startTangent, vect, curve.StartPoint, invertSide: true, out _0023_003DzBUOXmQB5RSyh, out var _))
			{
				point3D = curve.StartPoint + startTangent * (0.0 - _0023_003DzC5YR9r5C06bj);
			}
			Vector3D v = Vector3D.Subtract(point3D, curve.StartPoint);
			_0023_003Dzx5RboRHsRXS2 = (ICurve)_0023_003Dz_SqBXz8_003D.Clone();
			((Entity)_0023_003Dzx5RboRHsRXS2).Translate(v);
			if (_0023_003DzWaFlkhfmYCja != null)
			{
				_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D = new ICurve[_0023_003DzWaFlkhfmYCja.Count];
				for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
				{
					_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D[i] = (ICurve)_0023_003DzWaFlkhfmYCja[i].Clone();
					((Entity)_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D[i]).Translate(v);
				}
			}
		}
		if (_0023_003DzYnrMIDOkBgMJ > 0)
		{
			Vector3D vect = _0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p[_0023_003DzYnrMIDOkBgMJ - 1], _0023_003DzMnu3zKCWb6Kc: true);
			if (GetCutPlane(startTangent, vect, curve.StartPoint, invertSide: true, out _0023_003DzBUOXmQB5RSyh, out var _))
			{
				point3D = curve.StartPoint + startTangent * (0.0 - _0023_003DzC5YR9r5C06bj);
				Vector3D v2 = Vector3D.Subtract(point3D, curve.StartPoint);
				((Entity)_0023_003Dzx5RboRHsRXS2).Translate(v2);
				if (_0023_003DzWaFlkhfmYCja != null)
				{
					_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D = new ICurve[_0023_003DzWaFlkhfmYCja.Count];
					for (int j = 0; j < _0023_003DzWaFlkhfmYCja.Count; j++)
					{
						_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D[j] = (ICurve)_0023_003DzWaFlkhfmYCja[j].Clone();
						((Entity)_0023_003DzsPu4bP9W9X0MR3ZjBg_003D_003D[j]).Translate(v2);
					}
				}
			}
		}
		startTangent = curve.EndTangent;
		if (_0023_003DzYnrMIDOkBgMJ < _0023_003DzHgrHIfhYCh4p.Length - 1 || (_0023_003DzYnrMIDOkBgMJ == _0023_003DzHgrHIfhYCh4p.Length - 1 && _0023_003DzHbb9s4FIaFfq))
		{
			Vector3D vect = ((!_0023_003DzHbb9s4FIaFfq || _0023_003DzYnrMIDOkBgMJ != _0023_003DzHgrHIfhYCh4p.Length - 1) ? _0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p[_0023_003DzYnrMIDOkBgMJ + 1], _0023_003DzMnu3zKCWb6Kc: false) : _0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p[0], _0023_003DzMnu3zKCWb6Kc: false));
			if (GetCutPlane(startTangent, vect, curve.EndPoint, invertSide: false, out _0023_003DzoiaZ_4eSUI1q, out var _))
			{
				OffsetPoint(curve.StartPoint, curve.EndPoint, _0023_003DzC5YR9r5C06bj, out offsetPoint);
				offsetPoint = curve.EndPoint + startTangent * _0023_003DzC5YR9r5C06bj;
			}
		}
		_0023_003Dz36E85bQs4X5tLDFyWQ_003D_003D = new Line(point3D, curve.StartPoint);
		_0023_003DzYsh7vg3YvPj33Pvt8w_003D_003D = new Line(curve.EndPoint, offsetPoint);
	}

	internal static void _0023_003Dz7b9TFrXd9rCVnRQEGAbz5MKjvMEiSWk3Sg_003D_003D(ICurve[] _0023_003DzHgrHIfhYCh4p, int _0023_003DzYnrMIDOkBgMJ, double _0023_003DzC5YR9r5C06bj, bool _0023_003DzHbb9s4FIaFfq, out Plane _0023_003DzBUOXmQB5RSyh, out Plane _0023_003DzoiaZ_4eSUI1q, out Transformation _0023_003DzOx8ZYqOF_xYq, out Transformation _0023_003DzPFQpgmILhTq5)
	{
		Curve curve = (Curve)_0023_003DzHgrHIfhYCh4p[_0023_003DzYnrMIDOkBgMJ];
		_0023_003DzBUOXmQB5RSyh = (_0023_003DzoiaZ_4eSUI1q = null);
		Vector3D vector3D = (Vector3D)curve.StartTangent.Clone();
		_0023_003DzPFQpgmILhTq5 = (_0023_003DzOx8ZYqOF_xYq = null);
		if ((_0023_003DzYnrMIDOkBgMJ > 0 || (_0023_003DzYnrMIDOkBgMJ == 0 && _0023_003DzHbb9s4FIaFfq)) && GetCutPlane(vect2: (_0023_003DzYnrMIDOkBgMJ <= 0) ? _0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p[^1], _0023_003DzMnu3zKCWb6Kc: true) : _0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p[_0023_003DzYnrMIDOkBgMJ - 1], _0023_003DzMnu3zKCWb6Kc: true), vect1: vector3D, origin: curve.StartPoint, invertSide: true, plane: out _0023_003DzBUOXmQB5RSyh, rotAxis: out var _))
		{
			vector3D.Negate();
			vector3D *= _0023_003DzC5YR9r5C06bj;
			Translation translation = new Translation(vector3D.X, vector3D.Y, vector3D.Z);
			_0023_003DzOx8ZYqOF_xYq = translation;
		}
		if (_0023_003DzYnrMIDOkBgMJ < _0023_003DzHgrHIfhYCh4p.Length - 1 || (_0023_003DzYnrMIDOkBgMJ == _0023_003DzHgrHIfhYCh4p.Length - 1 && _0023_003DzHbb9s4FIaFfq))
		{
			vector3D = curve.EndTangent;
			if (GetCutPlane(vect2: (!_0023_003DzHbb9s4FIaFfq || _0023_003DzYnrMIDOkBgMJ != _0023_003DzHgrHIfhYCh4p.Length - 1) ? _0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p[_0023_003DzYnrMIDOkBgMJ + 1], _0023_003DzMnu3zKCWb6Kc: false) : _0023_003DzZ2FGq78_003D(_0023_003DzHgrHIfhYCh4p[0], _0023_003DzMnu3zKCWb6Kc: false), vect1: vector3D, origin: curve.EndPoint, invertSide: false, plane: out _0023_003DzoiaZ_4eSUI1q, rotAxis: out var _))
			{
				vector3D *= _0023_003DzC5YR9r5C06bj;
				Translation translation2 = new Translation(vector3D.X, vector3D.Y, vector3D.Z);
				_0023_003DzPFQpgmILhTq5 = translation2;
			}
		}
	}

	internal static Segment3D _0023_003DzDoIUcjWkjZQJ(Point3D _0023_003DzlY77YgY_003D, _0023_003DzwhtOFTk_003D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzDPcjoBJLcqli, Point3D _0023_003Dz_0024N_0024yKptW9BoC, double _0023_003Dz6pajdGM_003D)
	{
		double num = 1.0 + new Size3D(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC).Diagonal;
		Line line;
		switch (_0023_003DzxuJqjrs_003D)
		{
		case (_0023_003DzwhtOFTk_003D)0:
		{
			Point3D end = new Point3D(_0023_003Dz_0024N_0024yKptW9BoC.X + num, _0023_003DzlY77YgY_003D.Y, _0023_003DzlY77YgY_003D.Z);
			line = new Line(new Point3D(_0023_003DzDPcjoBJLcqli.X - num, _0023_003DzlY77YgY_003D.Y, _0023_003DzlY77YgY_003D.Z), end);
			if (_0023_003Dz6pajdGM_003D != 0.0)
			{
				line.Rotate(_0023_003Dz6pajdGM_003D, Vector3D.AxisZ, _0023_003DzlY77YgY_003D);
				line.Rotate(_0023_003Dz6pajdGM_003D, Vector3D.AxisY, _0023_003DzlY77YgY_003D);
				line.StartPoint.X = _0023_003DzDPcjoBJLcqli.X - 1.0;
				line.EndPoint.X = _0023_003Dz_0024N_0024yKptW9BoC.X + 1.0;
			}
			break;
		}
		case (_0023_003DzwhtOFTk_003D)1:
		{
			Point3D end = new Point3D(_0023_003DzlY77YgY_003D.X, _0023_003Dz_0024N_0024yKptW9BoC.Y + num, _0023_003DzlY77YgY_003D.Z);
			line = new Line(new Point3D(_0023_003DzlY77YgY_003D.X, _0023_003DzDPcjoBJLcqli.Y - num, _0023_003DzlY77YgY_003D.Z), end);
			if (_0023_003Dz6pajdGM_003D != 0.0)
			{
				line.Rotate(_0023_003Dz6pajdGM_003D, Vector3D.AxisX, _0023_003DzlY77YgY_003D);
				line.Rotate(_0023_003Dz6pajdGM_003D, Vector3D.AxisZ, _0023_003DzlY77YgY_003D);
				line.StartPoint.Y = _0023_003DzDPcjoBJLcqli.Y - 1.0;
				line.EndPoint.Y = _0023_003Dz_0024N_0024yKptW9BoC.Y + 1.0;
			}
			break;
		}
		case (_0023_003DzwhtOFTk_003D)2:
		{
			Point3D end = new Point3D(_0023_003DzlY77YgY_003D.X, _0023_003DzlY77YgY_003D.Y, _0023_003Dz_0024N_0024yKptW9BoC.Z + num);
			line = new Line(new Point3D(_0023_003DzlY77YgY_003D.X, _0023_003DzlY77YgY_003D.Y, _0023_003DzDPcjoBJLcqli.Z - num), end);
			if (_0023_003Dz6pajdGM_003D != 0.0)
			{
				line.Rotate(_0023_003Dz6pajdGM_003D, Vector3D.AxisY, _0023_003DzlY77YgY_003D);
				line.Rotate(_0023_003Dz6pajdGM_003D, Vector3D.AxisX, _0023_003DzlY77YgY_003D);
				line.StartPoint.Z = _0023_003DzDPcjoBJLcqli.Z - 1.0;
				line.EndPoint.Z = _0023_003Dz_0024N_0024yKptW9BoC.Z + 1.0;
			}
			break;
		}
		default:
		{
			Point3D end = new Point3D(_0023_003DzlY77YgY_003D.X, _0023_003DzlY77YgY_003D.Y, _0023_003Dz_0024N_0024yKptW9BoC.Z + num);
			line = new Line(new Point3D(_0023_003DzlY77YgY_003D.X, _0023_003DzlY77YgY_003D.Y, _0023_003DzDPcjoBJLcqli.Z - num), end);
			if (_0023_003Dz6pajdGM_003D != 0.0)
			{
				line.Rotate(_0023_003Dz6pajdGM_003D, Vector3D.AxisY, _0023_003DzlY77YgY_003D);
				line.Rotate(_0023_003Dz6pajdGM_003D, Vector3D.AxisX, _0023_003DzlY77YgY_003D);
				line.StartPoint.Z = _0023_003DzDPcjoBJLcqli.Z - 1.0;
				line.EndPoint.Z = _0023_003Dz_0024N_0024yKptW9BoC.Z + 1.0;
			}
			break;
		}
		}
		return new Segment3D(line.StartPoint, line.EndPoint);
	}

	internal static Plane[] _0023_003DzZ9QiwSvQlgr8(Curve _0023_003DzHgrHIfhYCh4p, Plane _0023_003DzStUznlUnGSG5, sweepMethodType _0023_003Dzjy_YX_0024o_003D)
	{
		Plane[] result = null;
		Point3D[] _0023_003DzBJFJHwk_003D;
		Vector3D[] _0023_003DzNDQ_E88_003D;
		Vector3D[] _0023_003Dz0ADyCos_003D;
		switch (_0023_003Dzjy_YX_0024o_003D)
		{
		case sweepMethodType.RotationMinimizingFrames:
		{
			Plane prevFrame = (Plane)((_0023_003DzStUznlUnGSG5 != null) ? _0023_003DzStUznlUnGSG5.Clone() : null);
			_0023_003Dz0JMASyWa7ni064GZ_g_003D_003D(_0023_003DzHgrHIfhYCh4p, 1, out _0023_003DzBJFJHwk_003D, out _0023_003DzNDQ_E88_003D, out _0023_003Dz0ADyCos_003D);
			result = RotationMinimizingFrames(prevFrame, _0023_003DzBJFJHwk_003D, _0023_003DzNDQ_E88_003D);
			break;
		}
		case sweepMethodType.FrenetSerret:
			_0023_003Dz0JMASyWa7ni064GZ_g_003D_003D(_0023_003DzHgrHIfhYCh4p, 2, out _0023_003DzBJFJHwk_003D, out _0023_003DzNDQ_E88_003D, out _0023_003Dz0ADyCos_003D);
			result = _0023_003DzL6ceDGcNA3ITNHPdHw_003D_003D(_0023_003DzBJFJHwk_003D, _0023_003DzNDQ_E88_003D, _0023_003Dz0ADyCos_003D);
			break;
		case sweepMethodType.RoadlikeTop:
			_0023_003Dz0JMASyWa7ni064GZ_g_003D_003D(_0023_003DzHgrHIfhYCh4p, 1, out _0023_003DzBJFJHwk_003D, out _0023_003DzNDQ_E88_003D, out _0023_003Dz0ADyCos_003D);
			result = _0023_003DzUR0E7SeA7NR8YHncCQ_003D_003D(_0023_003DzBJFJHwk_003D, _0023_003DzNDQ_E88_003D, Vector3D.AxisZ);
			break;
		case sweepMethodType.RoadlikeFront:
			_0023_003Dz0JMASyWa7ni064GZ_g_003D_003D(_0023_003DzHgrHIfhYCh4p, 1, out _0023_003DzBJFJHwk_003D, out _0023_003DzNDQ_E88_003D, out _0023_003Dz0ADyCos_003D);
			result = _0023_003DzUR0E7SeA7NR8YHncCQ_003D_003D(_0023_003DzBJFJHwk_003D, _0023_003DzNDQ_E88_003D, Vector3D.AxisY);
			break;
		case sweepMethodType.RoadlikeRight:
			_0023_003Dz0JMASyWa7ni064GZ_g_003D_003D(_0023_003DzHgrHIfhYCh4p, 1, out _0023_003DzBJFJHwk_003D, out _0023_003DzNDQ_E88_003D, out _0023_003Dz0ADyCos_003D);
			result = _0023_003DzUR0E7SeA7NR8YHncCQ_003D_003D(_0023_003DzBJFJHwk_003D, _0023_003DzNDQ_E88_003D, Vector3D.AxisX);
			break;
		}
		return result;
	}

	private static void _0023_003Dz0JMASyWa7ni064GZ_g_003D_003D(Curve _0023_003Dzt_m8zV0_003D, int _0023_003DzU7eDCS_XZhhv, out Point3D[] _0023_003DzBJFJHwk_003D, out Vector3D[] _0023_003DzNDQ_E88_003D, out Vector3D[] _0023_003Dz0ADyCos_003D)
	{
		int _0023_003DzB68dg9Q_003D = _0023_003Dzt_m8zV0_003D._0023_003DzB68dg9Q_003D;
		int num = _0023_003Dzt_m8zV0_003D._0023_003DzMv2C5Tm1QMvc();
		double[] array = new double[num];
		array[0] = _0023_003Dzt_m8zV0_003D._0023_003DziP9fFuA_003D[_0023_003Dzt_m8zV0_003D._0023_003DzB68dg9Q_003D];
		array[num - 1] = _0023_003Dzt_m8zV0_003D._0023_003DziP9fFuA_003D[_0023_003Dzt_m8zV0_003D._0023_003DziP9fFuA_003D.Length - _0023_003Dzt_m8zV0_003D._0023_003DzB68dg9Q_003D - 1];
		for (int i = 1; i < num - 1; i++)
		{
			array[i] = 0.0;
			for (int j = i + 1; j < i + _0023_003DzB68dg9Q_003D + 1; j++)
			{
				array[i] += _0023_003Dzt_m8zV0_003D._0023_003DziP9fFuA_003D[j];
			}
			array[i] /= _0023_003DzB68dg9Q_003D;
		}
		_0023_003DzBJFJHwk_003D = new Point3D[num];
		_0023_003DzNDQ_E88_003D = new Vector3D[num];
		if (_0023_003DzU7eDCS_XZhhv >= 2)
		{
			_0023_003Dz0ADyCos_003D = new Vector3D[num];
		}
		else
		{
			_0023_003Dz0ADyCos_003D = null;
		}
		for (int k = 0; k < num; k++)
		{
			Vector3D[] array2 = _0023_003Dzt_m8zV0_003D.Evaluate(array[k], _0023_003DzU7eDCS_XZhhv);
			_0023_003DzBJFJHwk_003D[k] = new Point3D(array2[0].ToArray());
			_0023_003DzNDQ_E88_003D[k] = array2[1];
			_0023_003DzNDQ_E88_003D[k].Normalize();
			if (_0023_003Dz0ADyCos_003D != null)
			{
				_0023_003Dz0ADyCos_003D[k] = array2[2];
				_0023_003Dz0ADyCos_003D[k].Normalize();
			}
		}
	}

	private static Plane[] _0023_003DzL6ceDGcNA3ITNHPdHw_003D_003D(Point3D[] _0023_003DzBJFJHwk_003D, Vector3D[] _0023_003DzNDQ_E88_003D, Vector3D[] _0023_003Dz0ADyCos_003D)
	{
		Plane[] array = new Plane[_0023_003DzBJFJHwk_003D.Length];
		for (int i = 0; i < _0023_003DzBJFJHwk_003D.Length; i++)
		{
			Vector3D vector3D = Vector3D.Cross(_0023_003DzNDQ_E88_003D[i], Vector3D.Cross(_0023_003Dz0ADyCos_003D[i], _0023_003DzNDQ_E88_003D[i]));
			vector3D.Normalize();
			array[i] = new Plane(_0023_003DzBJFJHwk_003D[i], _0023_003DzNDQ_E88_003D[i], vector3D);
		}
		return array;
	}

	public static Plane[] RotationMinimizingFrames(Plane prevFrame, Point3D[] x, Vector3D[] t)
	{
		Plane[] array = new Plane[x.Length];
		if (prevFrame == null)
		{
			array[0] = new Plane(x[0], t[0]);
		}
		for (int i = 0; i < x.Length - 1; i++)
		{
			Vector3D vector3D;
			double num;
			Vector3D axisX;
			Vector3D vector3D2;
			Vector3D axisZ;
			Vector3D vector3D3;
			Vector3D vector3D4;
			double num2;
			Vector3D vector3D5;
			Vector3D y;
			if (i == 0 && array[i] == null)
			{
				vector3D = Vector3D.Subtract(x[i + 1], x[i]);
				num = vector3D * vector3D;
				axisX = prevFrame.AxisX;
				vector3D2 = axisX - 2.0 / num * (vector3D * axisX) * vector3D;
				axisZ = prevFrame.AxisZ;
				vector3D3 = axisZ - 2.0 / num * (vector3D * axisZ) * vector3D;
				vector3D4 = t[i] - vector3D3;
				num2 = vector3D4 * vector3D4;
				vector3D5 = vector3D2 - 2.0 / num2 * (vector3D4 * vector3D2) * vector3D4;
				y = Vector3D.Cross(t[i], vector3D5);
				array[i] = new Plane(x[i], vector3D5, y);
			}
			vector3D = Vector3D.Subtract(x[i + 1], x[i]);
			num = vector3D * vector3D;
			axisX = array[i].AxisX;
			vector3D2 = axisX - 2.0 / num * (vector3D * axisX) * vector3D;
			axisZ = array[i].AxisZ;
			vector3D3 = axisZ - 2.0 / num * (vector3D * axisZ) * vector3D;
			vector3D4 = t[i + 1] - vector3D3;
			num2 = vector3D4 * vector3D4;
			vector3D5 = vector3D2 - 2.0 / num2 * (vector3D4 * vector3D2) * vector3D4;
			y = Vector3D.Cross(t[i + 1], vector3D5);
			array[i + 1] = new Plane(x[i + 1], vector3D5, y);
		}
		return array;
	}

	private static Plane[] _0023_003DzUR0E7SeA7NR8YHncCQ_003D_003D(Point3D[] _0023_003DzBJFJHwk_003D, Vector3D[] _0023_003DzNDQ_E88_003D, Vector3D _0023_003DzSodarTXAZkpQ)
	{
		Plane[] array = new Plane[_0023_003DzBJFJHwk_003D.Length];
		for (int i = 0; i < _0023_003DzBJFJHwk_003D.Length; i++)
		{
			Vector3D vector3D = Vector3D.Cross(_0023_003DzNDQ_E88_003D[i], _0023_003DzSodarTXAZkpQ);
			Vector3D y = Vector3D.Cross(_0023_003DzNDQ_E88_003D[i], vector3D);
			array[i] = new Plane(_0023_003DzBJFJHwk_003D[i], vector3D, y);
		}
		return array;
	}

	internal static void _0023_003Dz8nLh4eo_003D(int _0023_003DzUXX6SLgu46HF, ref int _0023_003DzU7eDCS_XZhhv)
	{
		switch (_0023_003DzUXX6SLgu46HF)
		{
		case 1:
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660653));
		case 2:
			if (_0023_003DzU7eDCS_XZhhv > 1)
			{
				_0023_003DzU7eDCS_XZhhv = 1;
				return;
			}
			break;
		}
		if (_0023_003DzUXX6SLgu46HF == 3 && _0023_003DzU7eDCS_XZhhv > 2)
		{
			_0023_003DzU7eDCS_XZhhv = 2;
		}
	}

	internal static void _0023_003DzDE7mL_712NEZeE5wpw_003D_003D(ICurve _0023_003DzqT6kZ6g_003D, ICurve _0023_003DzHgrHIfhYCh4p, double _0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D, bool _0023_003DzbErHvVw_003D, bool _0023_003DzGb8kdyZ1x5nj)
	{
		if (_0023_003DzbErHvVw_003D && !_0023_003DzqT6kZ6g_003D.IsClosed)
		{
			throw new EyeshotException(Mesh._0023_003DzCRupKJbhwyN62YPt8Q_003D_003D);
		}
		Plane plane;
		if (_0023_003DzqT6kZ6g_003D is Line || _0023_003DzqT6kZ6g_003D.IsLinear(_0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D * 10.0, out var _))
		{
			Vector3D vector3D = Vector3D.Cross(_0023_003DzHgrHIfhYCh4p.StartTangent, _0023_003DzqT6kZ6g_003D.StartTangent);
			if (vector3D.Length < _0023_003DzheSR8QM7q9ya)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660617));
			}
			plane = new Plane(_0023_003DzHgrHIfhYCh4p.StartPoint, _0023_003DzqT6kZ6g_003D.StartTangent, vector3D);
		}
		else if (!_0023_003DzqT6kZ6g_003D.IsPlanar(_0023_003DzeryUnHqaKuQhSvnQ4A_003D_003D * 10.0, out plane))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660832));
		}
		ICurve[] individualCurves = _0023_003DzHgrHIfhYCh4p.GetIndividualCurves();
		if (!_0023_003DzZEROl_YJ_9b_0024tIOMvw_003D_003D._0023_003DzwAfFvoy42C6h())
		{
			ICurve[] array = individualCurves;
			foreach (ICurve curve in array)
			{
				if (!(curve is Line) && !(curve is Circle) && !(curve is LinearPath))
				{
					throw new NotAvailableException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660795));
				}
			}
		}
		if (Math.Abs(Math.Abs(Vector3D.AngleBetween(_0023_003DzZ2FGq78_003D(individualCurves[0], _0023_003DzMnu3zKCWb6Kc: false), plane.AxisZ)) - Math.PI / 2.0) < _0023_003Dzjyaz_Vfaky9X)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661494));
		}
		if (Math.Abs(plane.DistanceTo(_0023_003DzHgrHIfhYCh4p.StartPoint)) > _0023_003Dzjyaz_Vfaky9X)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661463));
		}
	}

	private static List<ICurve> _0023_003DzrzTGlwfdU3k3YtEx_g_003D_003D(int _0023_003Dzfsn580w_003D, List<ICurve> _0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D, bool _0023_003Dz59LU6fL0vl_s4Lskpw_003D_003D)
	{
		List<ICurve> list = new List<ICurve>(_0023_003Dzfsn580w_003D);
		list.Add(_0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D[0]);
		_0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D.RemoveAt(0);
		Point3D startPoint = list[0].StartPoint;
		Point3D endPoint = list[0].EndPoint;
		while (_0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D.Count > 0)
		{
			double _0023_003DzTnVXy6ZEf8OP;
			bool _0023_003DzgLASWEgt0goG;
			int index = _0023_003Dz4qCJ2WP2w7yb(startPoint, _0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D, _0023_003Dzn9EIjD5r8BD3: true, out _0023_003DzTnVXy6ZEf8OP, out _0023_003DzgLASWEgt0goG);
			double _0023_003DzTnVXy6ZEf8OP2;
			bool _0023_003DzgLASWEgt0goG2;
			int index2 = _0023_003Dz4qCJ2WP2w7yb(endPoint, _0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D, _0023_003Dzn9EIjD5r8BD3: false, out _0023_003DzTnVXy6ZEf8OP2, out _0023_003DzgLASWEgt0goG2);
			if (_0023_003DzTnVXy6ZEf8OP < _0023_003DzTnVXy6ZEf8OP2)
			{
				if (_0023_003DzgLASWEgt0goG)
				{
					_0023_003Dz_0024fvibmW5yS_0024m(_0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D[index], _0023_003Dz59LU6fL0vl_s4Lskpw_003D_003D);
				}
				list.Insert(0, _0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D[index]);
				_0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D.RemoveAt(index);
				startPoint = list[0].StartPoint;
			}
			else
			{
				if (_0023_003DzgLASWEgt0goG2)
				{
					_0023_003Dz_0024fvibmW5yS_0024m(_0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D[index2], _0023_003Dz59LU6fL0vl_s4Lskpw_003D_003D);
				}
				list.Add(_0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D[index2]);
				_0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D.RemoveAt(index2);
				endPoint = list[list.Count - 1].EndPoint;
			}
		}
		return list;
	}

	internal static void _0023_003Dz_0024fvibmW5yS_0024m(ICurve _0023_003Dz8fpRyMu9aKjE, bool _0023_003Dz59LU6fL0vl_s4Lskpw_003D_003D)
	{
		_0023_003Dz8fpRyMu9aKjE.Reverse();
		Entity entity = (Entity)_0023_003Dz8fpRyMu9aKjE;
		if (!(entity.Vertices != null && _0023_003Dz59LU6fL0vl_s4Lskpw_003D_003D) || _0023_003Dz8fpRyMu9aKjE is TrimCurve)
		{
			return;
		}
		if (!(_0023_003Dz8fpRyMu9aKjE is Line) && !(_0023_003Dz8fpRyMu9aKjE is LinearPath))
		{
			Array.Reverse(entity.Vertices);
		}
		if (entity.Vertices[0] is PointTangent && entity.Vertices[entity.Vertices.Length - 1] is PointTangent)
		{
			for (int i = 0; i < entity.Vertices.Length; i++)
			{
				PointTangent obj = (PointTangent)entity.Vertices[i];
				obj.Tx = 0.0 - obj.Tx;
				obj.Ty = 0.0 - obj.Ty;
				obj.Tz = 0.0 - obj.Tz;
			}
		}
	}

	internal static bool _0023_003DzeSKB1dWK7i28y9mP3JIm0Jw_003D(ICurve _0023_003DzYqa83Us_003D, Point3D _0023_003DzDPcjoBJLcqli, Point3D _0023_003Dz_0024N_0024yKptW9BoC)
	{
		double num = Point3D.Distance(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC) / 1000.0;
		((Entity)_0023_003DzYqa83Us_003D).Regen(num);
		ComputeBoundingBox(((Entity)_0023_003DzYqa83Us_003D).Vertices, out var boxMin, out var boxMax);
		Size3D size3D = new Size3D(boxMin, boxMax);
		Size3D size3D2 = new Size3D(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
		bool num2 = (_0023_003DzDPcjoBJLcqli.X < boxMin.X || Math.Abs(boxMin.X - _0023_003DzDPcjoBJLcqli.X) < _0023_003DzxhnLabVjXjPg) && (_0023_003DzDPcjoBJLcqli.Y < boxMin.Y || Math.Abs(boxMin.Y - _0023_003DzDPcjoBJLcqli.Y) < _0023_003DzxhnLabVjXjPg) && (_0023_003DzDPcjoBJLcqli.Z < boxMin.Z || Math.Abs(boxMin.Z - _0023_003DzDPcjoBJLcqli.Z) < _0023_003DzxhnLabVjXjPg);
		bool flag = (_0023_003Dz_0024N_0024yKptW9BoC.X > boxMax.X || Math.Abs(boxMax.X - _0023_003Dz_0024N_0024yKptW9BoC.X) < _0023_003DzxhnLabVjXjPg) && (_0023_003Dz_0024N_0024yKptW9BoC.Y > boxMax.Y || Math.Abs(boxMax.Y - _0023_003Dz_0024N_0024yKptW9BoC.Y) < _0023_003DzxhnLabVjXjPg) && (_0023_003Dz_0024N_0024yKptW9BoC.Z > boxMax.Z || Math.Abs(boxMax.Z - _0023_003Dz_0024N_0024yKptW9BoC.Z) < _0023_003DzxhnLabVjXjPg);
		bool flag2 = Math.Abs(size3D2.X - size3D.X) <= num * 2.0 && Math.Abs(size3D2.Y - size3D.Y) <= num * 2.0 && Math.Abs(size3D2.Z - size3D.Z) <= num * 2.0;
		if (!num2 || !flag || !flag2)
		{
			return false;
		}
		return true;
	}

	internal static bool _0023_003DztviBgZeNYLdetGSTLA_003D_003D(Point3D _0023_003Dzk8Q2kNKWfuHn, Point3D _0023_003DzDPcjoBJLcqli, Point3D _0023_003Dz_0024N_0024yKptW9BoC, out bool _0023_003Dz8bomyDE_003D, out bool _0023_003DzOp7aOCA_003D, out bool _0023_003DzuaZo_0024Qs_003D)
	{
		_0023_003Dz8bomyDE_003D = _0023_003DzDPcjoBJLcqli.X <= _0023_003Dzk8Q2kNKWfuHn.X && _0023_003Dz_0024N_0024yKptW9BoC.X >= _0023_003Dzk8Q2kNKWfuHn.X;
		_0023_003DzOp7aOCA_003D = _0023_003DzDPcjoBJLcqli.Y <= _0023_003Dzk8Q2kNKWfuHn.Y && _0023_003Dz_0024N_0024yKptW9BoC.Y >= _0023_003Dzk8Q2kNKWfuHn.Y;
		_0023_003DzuaZo_0024Qs_003D = _0023_003Dz_0024N_0024yKptW9BoC.Z <= _0023_003Dzk8Q2kNKWfuHn.Z && _0023_003DzDPcjoBJLcqli.Z >= _0023_003Dzk8Q2kNKWfuHn.Z;
		return _0023_003Dz8bomyDE_003D & _0023_003DzOp7aOCA_003D & _0023_003DzuaZo_0024Qs_003D;
	}

	internal static bool _0023_003Dz5QRrfat3WheELwbdIzRlRyY_003D(IList<ICurve> _0023_003Dz06A5WivSSyUp)
	{
		int count = _0023_003Dz06A5WivSSyUp.Count;
		if (count == 1)
		{
			return true;
		}
		Point3D endPoint = _0023_003Dz06A5WivSSyUp[0].EndPoint;
		ICurve curve;
		double num;
		for (int i = 0; i < count - 1; i++)
		{
			curve = _0023_003Dz06A5WivSSyUp[i];
			num = Point3D.DistanceSquared(curve.StartPoint, endPoint);
			if (Point3D.DistanceSquared(curve.EndPoint, endPoint) < num)
			{
				return false;
			}
			endPoint = curve.EndPoint;
		}
		endPoint = _0023_003Dz06A5WivSSyUp[count - 1].EndPoint;
		curve = _0023_003Dz06A5WivSSyUp[0];
		num = Point3D.DistanceSquared(curve.StartPoint, endPoint);
		if (Point3D.DistanceSquared(curve.EndPoint, endPoint) < num)
		{
			return false;
		}
		return true;
	}

	internal static void _0023_003DzdFMOSey8Cxz2dU1ngA_003D_003D(IList<Brep.OrientedEdge> _0023_003DzpIZC_0024x5EiUBN, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Brep.Edge[] _0023_003DzU3hosSAzkxO7)
	{
		int count = _0023_003DzpIZC_0024x5EiUBN.Count;
		List<Brep.OrientedEdge> list = new List<Brep.OrientedEdge>(_0023_003DzpIZC_0024x5EiUBN.Count);
		for (int i = 0; i < count; i++)
		{
			Brep.OrientedEdge item = _0023_003DzpIZC_0024x5EiUBN[i];
			list.Add(item);
		}
		List<Brep.OrientedEdge> list2 = _0023_003DzrzTGlwfdU3k3YtEx_g_003D_003D(count, list, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO7);
		for (int j = 0; j < count; j++)
		{
			_0023_003DzpIZC_0024x5EiUBN[j] = list2[j];
		}
	}

	private static List<Brep.OrientedEdge> _0023_003DzrzTGlwfdU3k3YtEx_g_003D_003D(int _0023_003Dzfsn580w_003D, List<Brep.OrientedEdge> _0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Brep.Edge[] _0023_003DzU3hosSAzkxO7)
	{
		List<Brep.OrientedEdge> list = new List<Brep.OrientedEdge>(_0023_003Dzfsn580w_003D);
		list.Add(_0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D[0]);
		_0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D.RemoveAt(0);
		Point3D startVertex = list[0].GetStartVertex(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO7);
		list[0].GetEndVertex(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO7);
		while (_0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D.Count > 0)
		{
			double _0023_003DzY7vNKglonDym;
			bool _0023_003DzgLASWEgt0goG;
			int index = _0023_003Dz4qCJ2WP2w7yb(startVertex, _0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D, _0023_003Dzn9EIjD5r8BD3: true, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO7, out _0023_003DzY7vNKglonDym, out _0023_003DzgLASWEgt0goG);
			if (_0023_003DzgLASWEgt0goG)
			{
				Brep.OrientedEdge orientedEdge = _0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D[index];
				_0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D[index] = new Brep.OrientedEdge(orientedEdge.CurveIndex, !orientedEdge.Sense);
			}
			list.Insert(0, _0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D[index]);
			_0023_003Dz1WhyJq4lYUlpKTlrQQ_003D_003D.RemoveAt(index);
			startVertex = list[0].GetStartVertex(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO7);
		}
		return list;
	}

	private static int _0023_003Dz4qCJ2WP2w7yb(Point3D _0023_003DzMnu3zKCWb6Kc, IList<Brep.OrientedEdge> _0023_003DzpIZC_0024x5EiUBN, bool _0023_003Dzn9EIjD5r8BD3, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Brep.Edge[] _0023_003DzU3hosSAzkxO7, out double _0023_003DzY7vNKglonDym, out bool _0023_003DzgLASWEgt0goG)
	{
		_0023_003DzgLASWEgt0goG = false;
		_0023_003DzY7vNKglonDym = double.MaxValue;
		int result = -1;
		for (int i = 0; i < _0023_003DzpIZC_0024x5EiUBN.Count; i++)
		{
			Brep.OrientedEdge orientedEdge = _0023_003DzpIZC_0024x5EiUBN[i];
			double num = Point3D.DistanceSquared(_0023_003DzMnu3zKCWb6Kc, orientedEdge.GetStartVertex(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO7));
			double num2 = Point3D.DistanceSquared(_0023_003DzMnu3zKCWb6Kc, orientedEdge.GetEndVertex(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO7));
			double num3 = Math.Min(num, num2);
			if (!(num3 < _0023_003DzY7vNKglonDym))
			{
				continue;
			}
			_0023_003DzY7vNKglonDym = num3;
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

	internal static bool _0023_003Dz5QRrfat3WheELwbdIzRlRyY_003D(IList<Brep.OrientedEdge> _0023_003Dz06A5WivSSyUp, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Brep.Edge[] _0023_003DzU3hosSAzkxO7)
	{
		int count = _0023_003Dz06A5WivSSyUp.Count;
		if (count == 1)
		{
			return true;
		}
		Point3D endVertex = _0023_003Dz06A5WivSSyUp[0].GetEndVertex(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO7);
		Brep.OrientedEdge orientedEdge;
		double num;
		for (int i = 1; i < count; i++)
		{
			orientedEdge = _0023_003Dz06A5WivSSyUp[i];
			num = Point3D.DistanceSquared(orientedEdge.GetStartVertex(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO7), endVertex);
			if (Point3D.DistanceSquared(orientedEdge.GetEndVertex(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO7), endVertex) < num)
			{
				return false;
			}
			Brep.OrientedEdge orientedEdge2 = orientedEdge;
			endVertex = orientedEdge2.GetEndVertex(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO7);
		}
		endVertex = _0023_003Dz06A5WivSSyUp[count - 1].GetEndVertex(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO7);
		orientedEdge = _0023_003Dz06A5WivSSyUp[0];
		num = Point3D.DistanceSquared(orientedEdge.GetStartVertex(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO7), endVertex);
		if (Point3D.DistanceSquared(orientedEdge.GetEndVertex(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzU3hosSAzkxO7), endVertex) < num)
		{
			return false;
		}
		return true;
	}

	internal static double _0023_003DzcLYpEcsp_0024pkl(Size3D _0023_003Dzac9KEIHP1fei)
	{
		double num = Math.Min(_0023_003Dzac9KEIHP1fei.X, _0023_003Dzac9KEIHP1fei.Y);
		if (num < _0023_003DzxhnLabVjXjPg)
		{
			num = Math.Max(_0023_003Dzac9KEIHP1fei.X, _0023_003Dzac9KEIHP1fei.Y);
		}
		double num2 = Math.Min(num, _0023_003Dzac9KEIHP1fei.Z);
		if (num2 < _0023_003DzxhnLabVjXjPg)
		{
			num2 = Math.Max(num, _0023_003Dzac9KEIHP1fei.Z);
		}
		return num2;
	}

	internal static void _0023_003Dz61B8IYSGx6wG(Point4D[] _0023_003Dzu76y2KE_003D, int _0023_003DzUgvyR9E_003D, out Point3D _0023_003DzF7v9r2A_003D, out Point3D _0023_003Dz8dK2uhU_003D)
	{
		Point3D point3D = new Point3D();
		Point4D point4D = _0023_003Dzu76y2KE_003D[0];
		_0023_003DzF7v9r2A_003D = point4D.Euclid;
		_0023_003Dz8dK2uhU_003D = point4D.Euclid;
		for (int i = 1; i < _0023_003Dzu76y2KE_003D.Length; i++)
		{
			point4D = _0023_003Dzu76y2KE_003D[i];
			point3D.X = point4D.X / point4D.W;
			point3D.Y = point4D.Y / point4D.W;
			point3D.Z = point4D.Z / point4D.W;
			if (point3D.X < _0023_003DzF7v9r2A_003D.X)
			{
				_0023_003DzF7v9r2A_003D.X = point3D.X;
			}
			else if (point3D.X > _0023_003Dz8dK2uhU_003D.X)
			{
				_0023_003Dz8dK2uhU_003D.X = point3D.X;
			}
			if (point3D.Y < _0023_003DzF7v9r2A_003D.Y)
			{
				_0023_003DzF7v9r2A_003D.Y = point3D.Y;
			}
			else if (point3D.Y > _0023_003Dz8dK2uhU_003D.Y)
			{
				_0023_003Dz8dK2uhU_003D.Y = point3D.Y;
			}
			if (point3D.Z < _0023_003DzF7v9r2A_003D.Z)
			{
				_0023_003DzF7v9r2A_003D.Z = point3D.Z;
			}
			else if (point3D.Z > _0023_003Dz8dK2uhU_003D.Z)
			{
				_0023_003Dz8dK2uhU_003D.Z = point3D.Z;
			}
		}
	}

	internal static void _0023_003Dz61B8IYSGx6wG(Point4D[,] _0023_003Dzu76y2KE_003D, int _0023_003DzUgvyR9E_003D, int _0023_003Dzo36mOvw_003D, out Point3D _0023_003DzF7v9r2A_003D, out Point3D _0023_003Dz8dK2uhU_003D)
	{
		Point3D point3D = new Point3D();
		_0023_003DzF7v9r2A_003D = Point3D.MaxValue;
		_0023_003Dz8dK2uhU_003D = Point3D.MinValue;
		for (int i = 0; i < _0023_003Dzo36mOvw_003D; i++)
		{
			for (int j = 0; j < _0023_003DzUgvyR9E_003D; j++)
			{
				Point4D point4D = _0023_003Dzu76y2KE_003D[j, i];
				point3D.X = point4D.X / point4D.W;
				point3D.Y = point4D.Y / point4D.W;
				point3D.Z = point4D.Z / point4D.W;
				if (point3D.X < _0023_003DzF7v9r2A_003D.X)
				{
					_0023_003DzF7v9r2A_003D.X = point3D.X;
				}
				if (point3D.X > _0023_003Dz8dK2uhU_003D.X)
				{
					_0023_003Dz8dK2uhU_003D.X = point3D.X;
				}
				if (point3D.Y < _0023_003DzF7v9r2A_003D.Y)
				{
					_0023_003DzF7v9r2A_003D.Y = point3D.Y;
				}
				if (point3D.Y > _0023_003Dz8dK2uhU_003D.Y)
				{
					_0023_003Dz8dK2uhU_003D.Y = point3D.Y;
				}
				if (point3D.Z < _0023_003DzF7v9r2A_003D.Z)
				{
					_0023_003DzF7v9r2A_003D.Z = point3D.Z;
				}
				if (point3D.Z > _0023_003Dz8dK2uhU_003D.Z)
				{
					_0023_003Dz8dK2uhU_003D.Z = point3D.Z;
				}
			}
		}
	}

	internal static void _0023_003DzThVkk3uHVTf3(Point4D[,] _0023_003Dzu76y2KE_003D, int _0023_003DzUgvyR9E_003D, int _0023_003Dzo36mOvw_003D, out Size3D _0023_003DzxH4ozIo_003D, out bool _0023_003DzCq59RVw_003D, out bool _0023_003Dzoa6bboA_003D)
	{
		_0023_003Dz61B8IYSGx6wG(_0023_003Dzu76y2KE_003D, _0023_003DzUgvyR9E_003D, _0023_003Dzo36mOvw_003D, out var _0023_003DzF7v9r2A_003D, out var _0023_003Dz8dK2uhU_003D);
		_0023_003DzxH4ozIo_003D = new Size3D(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		double num = _0023_003DzxH4ozIo_003D.Diagonal * _0023_003DzxhnLabVjXjPg;
		_0023_003DzCq59RVw_003D = true;
		double num2 = num * num;
		for (int i = 0; i < _0023_003Dzo36mOvw_003D; i++)
		{
			if (Point3D.DistanceSquared(_0023_003Dzu76y2KE_003D[0, i].Euclid, _0023_003Dzu76y2KE_003D[_0023_003DzUgvyR9E_003D - 1, i].Euclid) > num2)
			{
				_0023_003DzCq59RVw_003D = false;
				break;
			}
		}
		_0023_003Dzoa6bboA_003D = true;
		for (int j = 0; j < _0023_003DzUgvyR9E_003D; j++)
		{
			if (Point3D.DistanceSquared(_0023_003Dzu76y2KE_003D[j, 0].Euclid, _0023_003Dzu76y2KE_003D[j, _0023_003Dzo36mOvw_003D - 1].Euclid) > num2)
			{
				_0023_003Dzoa6bboA_003D = false;
				break;
			}
		}
	}

	internal static void _0023_003DzD_00245nWTrQrjSP(Point4D[,] _0023_003Dzb7SPTpc_003D, Point4D[,] _0023_003DzaoQTclc_003D)
	{
		int length = _0023_003Dzb7SPTpc_003D.GetLength(0);
		int length2 = _0023_003Dzb7SPTpc_003D.GetLength(1);
		for (int i = 0; i < length2; i++)
		{
			for (int j = 0; j < length; j++)
			{
				_0023_003DzaoQTclc_003D[j, i] = (Point4D)_0023_003Dzb7SPTpc_003D[j, i].Clone();
			}
		}
	}

	public static void SplitEdgeOnSurfaceSeams(Brep brep, StringBuilder log)
	{
		Dictionary<int, Tuple<Point3D, Point3D>> _0023_003DzFTFMQa7WMNjc = new Dictionary<int, Tuple<Point3D, Point3D>>();
		Dictionary<int, double> _0023_003Dz3eari3pbWYae = new Dictionary<int, double>();
		Dictionary<int, double> _0023_003Dz3eari3pbWYae2 = new Dictionary<int, double>();
		Size3D _0023_003DzccAR5G0_003D = _0023_003DzG7lwGJQcHQ3U(brep.Edges, brep.Faces, _0023_003Dz3eari3pbWYae, _0023_003DzFTFMQa7WMNjc);
		_0023_003DzUUbhjpDxOFTyjkruXGN0sOA_003D(0, brep, brep.Faces, _0023_003DzccAR5G0_003D, _0023_003Dz3eari3pbWYae, log);
		for (int i = 0; i < brep.Inners.Length; i++)
		{
			Brep.Face[] array = brep.Inners[i];
			_0023_003DzG7lwGJQcHQ3U(brep.Edges, array, _0023_003Dz3eari3pbWYae2, _0023_003DzFTFMQa7WMNjc);
			_0023_003DzUUbhjpDxOFTyjkruXGN0sOA_003D(i + 1, brep, array, _0023_003DzccAR5G0_003D, _0023_003Dz3eari3pbWYae2, log);
		}
	}

	private static void _0023_003DzUUbhjpDxOFTyjkruXGN0sOA_003D(int _0023_003DzRLCcpW4_003D, Brep _0023_003DzGb8kdyZ1x5nj, Brep.Face[] _0023_003DzEtn4dIEPKCsi, Size3D _0023_003DzccAR5G0_003D, Dictionary<int, double> _0023_003Dz3eari3pbWYae, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		double tol = _0023_003DzccAR5G0_003D.Diagonal * _0023_003DzxhnLabVjXjPg;
		HashSet<int> hashSet = new HashSet<int>();
		for (int i = 0; i < _0023_003DzGb8kdyZ1x5nj.Edges.Length; i++)
		{
			Brep.Edge edge = _0023_003DzGb8kdyZ1x5nj.Edges[i];
			ICurve curve = edge.Curve;
			if (IsLine(curve) || curve.IsLinear(tol, out var _) || _0023_003DzRLCcpW4_003D != edge.ShellIndex)
			{
				continue;
			}
			Brep.Face[] array = new Brep.Face[edge.Parents.Length];
			for (int j = 0; j < edge.Parents.Length; j++)
			{
				array[j] = _0023_003DzEtn4dIEPKCsi[edge.Parents[j]];
			}
			if (array.Length > 1 && array[0] == array[1])
			{
				continue;
			}
			for (int k = 0; k < array.Length; k++)
			{
				Brep.Face face = array[k];
				if (!face.Surface.HasSeam)
				{
					continue;
				}
				Point3D startPoint = curve.StartPoint;
				Point3D endPoint = curve.EndPoint;
				if (face.Surface is PlanarSurf && curve is PlanarEntity)
				{
					PlanarSurf planarSurf = (PlanarSurf)face.Surface;
					PlanarEntity planarEntity = (PlanarEntity)curve;
					if (Vector3D.AreParallel(planarSurf.Plane.AxisZ, planarEntity.Plane.AxisZ, _0023_003DzxhnLabVjXjPg))
					{
						Segment3D seg = new Segment3D(planarSurf.Plane.Origin, planarSurf.Plane.Origin + planarSurf.Plane.AxisZ);
						Vector3D vector3D = new Vector3D(startPoint.ProjectTo(seg), startPoint);
						vector3D.Normalize();
						Vector3D vector3D2 = new Vector3D(endPoint.ProjectTo(seg), endPoint);
						vector3D2.Normalize();
						double num = 1.0 - _0023_003DzheSR8QM7q9ya;
						if (planarSurf is ToroidalSurf && ((ToroidalSurf)planarSurf).MajorRadius < 0.0)
						{
							if (-1.0 * planarSurf.Plane.AxisX * vector3D > num || -1.0 * planarSurf.Plane.AxisX * vector3D2 > num)
							{
								continue;
							}
						}
						else if (planarSurf.Plane.AxisX * vector3D > num || planarSurf.Plane.AxisX * vector3D2 > num)
						{
							continue;
						}
					}
				}
				if (face.Parametric == null)
				{
					ICurve[] edgeCurves = _0023_003DzGb8kdyZ1x5nj._0023_003Dzc82cILbi9HyU(face);
					Surface notRotated;
					if (face.Surface is ConicalSurf)
					{
						ICurve[] orientedTrimLoops = face.GetOrientedTrimLoops(_0023_003DzGb8kdyZ1x5nj.Edges, keepVertices: false);
						face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(new Surface[1] { face.Surface.GetUntrimmed(orientedTrimLoops, face.Sense, out notRotated) });
					}
					else if (face.Surface is SphericalSurf || face.Surface is ToroidalSurf)
					{
						face.Surface.GetUntrimmed(edgeCurves, face.Sense, out var notRotated2);
						face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(new Surface[1] { notRotated2 });
					}
					else
					{
						face._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(new Surface[1] { face.Surface.GetUntrimmed(edgeCurves, face.Sense, out notRotated) });
					}
					hashSet.Add(edge.Parents[k]);
				}
				Brep.OrientedEdge _0023_003DzztD7NmB1C1__0024PFJY6g_003D_003D = default(Brep.OrientedEdge);
				bool flag = false;
				int l = -1;
				int m;
				for (m = 0; m < face.Loops.Length; m++)
				{
					Brep.Loop loop = face.Loops[m];
					for (l = 0; l < loop.Segments.Length; l++)
					{
						_0023_003DzztD7NmB1C1__0024PFJY6g_003D_003D = loop.Segments[l];
						if (_0023_003DzztD7NmB1C1__0024PFJY6g_003D_003D.CurveIndex == i)
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
				List<ICurve> list = new List<ICurve>();
				Surface surface = face.Parametric[0];
				if (flag && surface._0023_003DzCq59RVw_003D && !surface.IsOnSeamU(curve))
				{
					surface._0023_003Dz7_dVN28lLvGQ(curve, list, surface.SeamU, _0023_003Dz3eari3pbWYae[edge.Parents[k]]);
					if (list.Count > 0)
					{
						int endPointIndex = edge.EndPointIndex;
						_0023_003Dz6tfQOjA79PKZ(_0023_003DzGb8kdyZ1x5nj, face, _0023_003DzztD7NmB1C1__0024PFJY6g_003D_003D, endPointIndex, l, m, edge.Parents[k], i, list, _0023_003DzqmF8XJ0_003D);
						curve = _0023_003DzGb8kdyZ1x5nj.Edges[i].Curve;
						_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661421), i));
					}
				}
				if (flag && surface._0023_003Dzoa6bboA_003D && !surface.IsOnSeamV(curve))
				{
					list.Clear();
					surface._0023_003Dz7_dVN28lLvGQ(curve, list, surface.SeamV, _0023_003Dz3eari3pbWYae[edge.Parents[k]]);
					if (list.Count > 0)
					{
						int endPointIndex2 = edge.EndPointIndex;
						_0023_003Dz6tfQOjA79PKZ(_0023_003DzGb8kdyZ1x5nj, face, _0023_003DzztD7NmB1C1__0024PFJY6g_003D_003D, endPointIndex2, l, m, edge.Parents[k], i, list, _0023_003DzqmF8XJ0_003D);
						curve = _0023_003DzGb8kdyZ1x5nj.Edges[i].Curve;
						_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661602), i));
					}
				}
				if (list.Count == 0)
				{
					surface._0023_003DzD2_0024xGqpJElDSjeq3uQ_003D_003D(curve, list);
					if (list.Count > 0)
					{
						int endPointIndex3 = edge.EndPointIndex;
						_0023_003Dz6tfQOjA79PKZ(_0023_003DzGb8kdyZ1x5nj, face, _0023_003DzztD7NmB1C1__0024PFJY6g_003D_003D, endPointIndex3, l, m, edge.Parents[k], i, list, _0023_003DzqmF8XJ0_003D);
						curve = _0023_003DzGb8kdyZ1x5nj.Edges[i].Curve;
						_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661555), i));
					}
				}
			}
		}
		foreach (int item in hashSet)
		{
			_0023_003DzEtn4dIEPKCsi[item]._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(null);
		}
		foreach (Brep.Face face2 in _0023_003DzEtn4dIEPKCsi)
		{
			if (face2.Surface is SphericalSurf || face2.Surface is ToroidalSurf)
			{
				face2._0023_003Dz4_00245QvdjonoeIATmUWuPNwGs_003D(null);
			}
		}
	}

	private static void _0023_003Dz6tfQOjA79PKZ(Brep _0023_003DzGb8kdyZ1x5nj, Brep.Face _0023_003DzHEpjcdg2hk9U, Brep.OrientedEdge _0023_003DzztD7NmB1C1__0024PFJY6g_003D_003D, int _0023_003Dzk64JNOo_003D, int _0023_003DzL8NvYU0_003D, int _0023_003DzhNQLY4s_003D, int _0023_003DznQRq8wY_003D, int _0023_003DzvCO4gGHjnA9Q, List<ICurve> _0023_003DzuoVaYNVR2RfX, StringBuilder _0023_003DzqmF8XJ0_003D)
	{
		int num = _0023_003DzGb8kdyZ1x5nj._vertices.Length;
		Array.Resize(ref _0023_003DzGb8kdyZ1x5nj._vertices, num + _0023_003DzuoVaYNVR2RfX.Count - 1);
		for (int i = 0; i < _0023_003DzuoVaYNVR2RfX.Count - 1; i++)
		{
			Point3D endPoint = _0023_003DzuoVaYNVR2RfX[i].EndPoint;
			_0023_003DzGb8kdyZ1x5nj._vertices[num + i] = new Brep.Vertex(endPoint.X, endPoint.Y, endPoint.Z);
			_0023_003DzqmF8XJ0_003D?.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661509), num + i));
			if (i == 0)
			{
				((Brep.Vertex)_0023_003DzGb8kdyZ1x5nj._vertices[num + i]).Parents = new int[2]
				{
					_0023_003DzvCO4gGHjnA9Q,
					_0023_003DzGb8kdyZ1x5nj.Edges.Length
				};
			}
			else
			{
				((Brep.Vertex)_0023_003DzGb8kdyZ1x5nj._vertices[num + i]).Parents = new int[2]
				{
					_0023_003DzGb8kdyZ1x5nj.Edges.Length + i - 1,
					_0023_003DzGb8kdyZ1x5nj.Edges.Length + i
				};
			}
		}
		Brep.Edge edge = _0023_003DzGb8kdyZ1x5nj.Edges[_0023_003DzztD7NmB1C1__0024PFJY6g_003D_003D.CurveIndex];
		if (edge.StartPointIndex != edge.EndPointIndex)
		{
			((Brep.Vertex)_0023_003DzGb8kdyZ1x5nj.Vertices[edge.EndPointIndex])._0023_003DznS097uo_003D(_0023_003DzztD7NmB1C1__0024PFJY6g_003D_003D.CurveIndex);
		}
		edge.Curve = _0023_003DzuoVaYNVR2RfX[0];
		edge.EndPointIndex = num;
		int[] array = new int[_0023_003DzuoVaYNVR2RfX.Count - 1];
		for (int j = 0; j < _0023_003DzuoVaYNVR2RfX.Count - 1; j++)
		{
			Brep.Edge edge2 = new Brep.Edge(_0023_003DzuoVaYNVR2RfX[j + 1], num + j, (num + j + 1 == _0023_003DzGb8kdyZ1x5nj.Vertices.Length) ? _0023_003Dzk64JNOo_003D : (num + j + 1));
			int num2 = edge.Parents.Length;
			edge2.Parents = new int[num2];
			Array.Copy(edge.Parents, edge2.Parents, num2);
			_0023_003DzGb8kdyZ1x5nj._0023_003DzxIz2h65fhdN2(_0023_003DzGb8kdyZ1x5nj.Edges.Length + 1);
			_0023_003DzGb8kdyZ1x5nj.Edges[_0023_003DzGb8kdyZ1x5nj.Edges.Length - 1] = edge2;
			List<Brep.OrientedEdge> list = new List<Brep.OrientedEdge>(_0023_003DzHEpjcdg2hk9U.Loops[_0023_003DzhNQLY4s_003D].Segments);
			list.Insert(item: new Brep.OrientedEdge(_0023_003DzGb8kdyZ1x5nj.Edges.Length - 1, _0023_003DzztD7NmB1C1__0024PFJY6g_003D_003D.Sense), index: _0023_003DzztD7NmB1C1__0024PFJY6g_003D_003D.Sense ? (_0023_003DzL8NvYU0_003D + 1) : _0023_003DzL8NvYU0_003D);
			_0023_003DzL8NvYU0_003D++;
			_0023_003DzHEpjcdg2hk9U.Loops[_0023_003DzhNQLY4s_003D].Segments = list.ToArray();
			array[j] = _0023_003DzGb8kdyZ1x5nj.Edges.Length - 1;
		}
		Brep.Face face = ((_0023_003DznQRq8wY_003D == edge.Parents[0] && edge.Parents.Length > 1) ? ((edge.ShellIndex != 0) ? _0023_003DzGb8kdyZ1x5nj.Inners[edge.ShellIndex - 1][edge.Parents[1]] : _0023_003DzGb8kdyZ1x5nj.Faces[edge.Parents[1]]) : ((edge.ShellIndex != 0) ? _0023_003DzGb8kdyZ1x5nj.Inners[edge.ShellIndex - 1][edge.Parents[0]] : _0023_003DzGb8kdyZ1x5nj.Faces[edge.Parents[0]]));
		if (edge.Parents.Length <= 1 || array.Length == 0)
		{
			return;
		}
		for (int k = 0; k < face.Loops.Length; k++)
		{
			Brep.OrientedEdge[] segments = face.Loops[k].Segments;
			for (int l = 0; l < segments.Length; l++)
			{
				Brep.OrientedEdge orientedEdge = segments[l];
				if (orientedEdge.CurveIndex == _0023_003DzztD7NmB1C1__0024PFJY6g_003D_003D.CurveIndex)
				{
					List<Brep.OrientedEdge> list2 = new List<Brep.OrientedEdge>(segments);
					for (int m = 0; m < array.Length; m++)
					{
						list2.Insert(item: new Brep.OrientedEdge(array[m], orientedEdge.Sense), index: orientedEdge.Sense ? (l + m + 1) : l);
					}
					face.Loops[k].Segments = list2.ToArray();
				}
			}
		}
	}

	private static Size3D _0023_003DzG7lwGJQcHQ3U(Brep.Edge[] _0023_003DzU3hosSAzkxO7, Brep.Face[] _0023_003DzpPOEJqcAh7Lr, Dictionary<int, double> _0023_003Dz3eari3pbWYae, Dictionary<int, Tuple<Point3D, Point3D>> _0023_003DzFTFMQa7WMNjc)
	{
		Point3D maxValue = Point3D.MaxValue;
		Point3D minValue = Point3D.MinValue;
		for (int i = 0; i < _0023_003DzpPOEJqcAh7Lr.Length; i++)
		{
			Brep.Face face = _0023_003DzpPOEJqcAh7Lr[i];
			Point3D maxValue2 = Point3D.MaxValue;
			Point3D minValue2 = Point3D.MinValue;
			for (int j = 0; j < face.Loops.Length; j++)
			{
				Brep.Loop loop = face.Loops[j];
				for (int k = 0; k < loop.Segments.Length; k++)
				{
					Brep.OrientedEdge orientedEdge = loop.Segments[k];
					Point3D min;
					Point3D max;
					if (_0023_003DzFTFMQa7WMNjc.ContainsKey(orientedEdge.CurveIndex))
					{
						min = _0023_003DzFTFMQa7WMNjc[orientedEdge.CurveIndex].Item1;
						max = _0023_003DzFTFMQa7WMNjc[orientedEdge.CurveIndex].Item2;
					}
					else
					{
						ICurve curve = _0023_003DzU3hosSAzkxO7[orientedEdge.CurveIndex].Curve;
						if (curve == null)
						{
							continue;
						}
						curve.GetNurbsForm().ControlBoundingBox(out min, out max);
						_0023_003DzFTFMQa7WMNjc.Add(orientedEdge.CurveIndex, new Tuple<Point3D, Point3D>(min, max));
					}
					UpdateMinMaxSlow(min, maxValue2, minValue2);
					UpdateMinMaxSlow(max, maxValue2, minValue2);
				}
			}
			if (!_0023_003Dz3eari3pbWYae.ContainsKey(i))
			{
				_0023_003Dz3eari3pbWYae.Add(i, new Size3D(maxValue2, minValue2).Diagonal);
			}
			UpdateMinMaxSlow(maxValue2, maxValue, minValue);
			UpdateMinMaxSlow(minValue2, maxValue, minValue);
		}
		return new Size3D(maxValue, minValue);
	}

	internal static double _0023_003Dz9Nw_0024YI_v5jW6812R4UknSZnBGZ67(Line _0023_003DziMjqlCo_003D, Line _0023_003DzI4dRPW0_003D, Plane _0023_003DzUv21N8tqBazJs5qBBg_003D_003D)
	{
		Point2D point2D = _0023_003DzUv21N8tqBazJs5qBBg_003D_003D.Project(_0023_003DziMjqlCo_003D.EndPoint);
		Point2D point2D2 = _0023_003DzUv21N8tqBazJs5qBBg_003D_003D.Project(_0023_003DziMjqlCo_003D.StartPoint);
		Point2D point2D3 = _0023_003DzUv21N8tqBazJs5qBBg_003D_003D.Project(_0023_003DzI4dRPW0_003D.EndPoint);
		Vector2D vector2D = new Vector2D(point2D, point2D3);
		Vector2D vector2D2 = new Vector2D(point2D, point2D2);
		Vector2D vector2D3 = vector2D2.Length * vector2D + vector2D.Length * vector2D2;
		Segment2D s = new Segment2D(point2D, point2D + vector2D3 * 0.01);
		if (_0023_003DziMjqlCo_003D.Length() > _0023_003DzI4dRPW0_003D.Length())
		{
			Vector2D vector2D4 = new Vector2D(vector2D.Y, 0.0 - vector2D.X);
			Segment2D s2 = new Segment2D(point2D3, point2D3 + vector2D4);
			if (!Segment2D.IntersectionLine(s, s2, out var i))
			{
				return -1.0;
			}
			return i.DistanceTo(point2D3);
		}
		Vector2D vector2D5 = new Vector2D(0.0 - vector2D2.Y, vector2D2.X);
		Segment2D s3 = new Segment2D(point2D2, point2D2 + vector2D5);
		if (!Segment2D.IntersectionLine(s, s3, out var i2))
		{
			return -1.0;
		}
		return i2.DistanceTo(point2D2);
	}

	public static ICurve[] GetConnectedCurves(IList<ICurve> unsorted, double gap)
	{
		List<ICurve> list = new List<ICurve>();
		foreach (List<ICurve> item in _0023_003Dzx1_VB8cQKrRRV2_0024w7g_003D_003D(unsorted, gap, _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D: false, _0023_003Dzp9LPrpP9wSDR: false))
		{
			if (item.Count == 1)
			{
				list.Add(item[0]);
				continue;
			}
			List<ICurve> list2 = new List<ICurve>();
			foreach (ICurve item2 in item)
			{
				if (item2 is CompositeCurve)
				{
					list2.AddRange(((CompositeCurve)item2).CurveList);
				}
				else
				{
					list2.Add(item2);
				}
			}
			list.Add(new CompositeCurve(list2));
		}
		return list.ToArray();
	}

	public static devDept.Eyeshot.Entities.Region[] DetectRegionsFromContours(IList<ICurve> contours, Plane plane = null, bool keepVertices = false)
	{
		List<devDept.Eyeshot.Entities.Region> list = new List<devDept.Eyeshot.Entities.Region>(contours.Count);
		FindLoopsInternal(contours, out var outersIndices, out var innersIndices, plane);
		for (int i = 0; i < outersIndices.Length; i++)
		{
			List<ICurve> list2 = new List<ICurve>(innersIndices[i].Length + 1) { contours[outersIndices[i]] };
			for (int j = 0; j < innersIndices[i].Length; j++)
			{
				list2.Add(contours[innersIndices[i][j]]);
			}
			if (plane != null)
			{
				list.Add(new devDept.Eyeshot.Entities.Region(list2, plane, _0023_003DzeyKgREVnRl_0024T8dZhnQ_003D_003D: true, keepVertices));
			}
			else
			{
				list.Add(new devDept.Eyeshot.Entities.Region(list2, null, _0023_003DzeyKgREVnRl_0024T8dZhnQ_003D_003D: true, keepVertices));
			}
		}
		return list.ToArray();
	}

	internal static void _0023_003Dzn4KqhjbmsZs5gdTzPejzj_0024M_003D(IList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, out int[] _0023_003DzsdySxIlQLgFZ, out int[][] _0023_003DzWaFlkhfmYCja, double _0023_003DzQ2_0024_99rGAke6, Plane _0023_003Dzrgqz890sj_0024X9)
	{
		Point2D[][] array = new Point2D[_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count][];
		for (int i = 0; i < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count; i++)
		{
			Entity entity = (Entity)_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[i];
			bool flag = true;
			if (entity is CompositeCurve)
			{
				CompositeCurve compositeCurve = (CompositeCurve)entity;
				List<Point3D> list = new List<Point3D>(compositeCurve.CurveList.Count);
				int count = compositeCurve.CurveList.Count;
				for (int j = 0; j < count; j++)
				{
					Entity entity2 = (Entity)compositeCurve.CurveList[j];
					if (entity2.Vertices != null)
					{
						flag = false;
						for (int k = 0; k < ((j < count - 1) ? (entity2.Vertices.Length - 1) : entity2.Vertices.Length); k++)
						{
							list.Add(entity2.Vertices[k]);
						}
						continue;
					}
					flag = true;
					break;
				}
				entity.Vertices = list.ToArray();
			}
			else if (entity.Vertices != null)
			{
				flag = false;
			}
			if (flag)
			{
				entity.Regen(_0023_003DzQ2_0024_99rGAke6);
			}
			array[i] = new Point2D[entity.Vertices.Length];
			for (int l = 0; l < entity.Vertices.Length; l++)
			{
				if (_0023_003Dzrgqz890sj_0024X9 == null)
				{
					array[i][l] = Plane.XY.Project(entity.Vertices[l]);
				}
				else
				{
					array[i][l] = _0023_003Dzrgqz890sj_0024X9.Project(entity.Vertices[l]);
				}
			}
		}
		FindLoopsInternal(array, out var _, out var _, out _0023_003DzsdySxIlQLgFZ, out _0023_003DzWaFlkhfmYCja);
	}

	internal static List<List<ICurve>> _0023_003Dzx1_VB8cQKrRRV2_0024w7g_003D_003D(IList<ICurve> _0023_003DzpIZC_0024x5EiUBN, double _0023_003Dz3SduW_0024w_003D, bool _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D, bool _0023_003Dzp9LPrpP9wSDR)
	{
		List<List<ICurve>> list = new List<List<ICurve>>();
		List<ICurve> list2 = new List<ICurve>(_0023_003DznoMOM1JgBMb7Z2tg4A_003D_003D(_0023_003DzpIZC_0024x5EiUBN, _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D));
		double num = _0023_003Dz3SduW_0024w_003D * _0023_003Dz3SduW_0024w_003D;
		if (double.IsInfinity(num))
		{
			num = double.MaxValue;
		}
		List<ICurve> list3 = new List<ICurve>();
		list3.Add(list2[0]);
		list2.RemoveAt(0);
		Point3D startPoint = list3[0].StartPoint;
		Point3D endPoint = list3[0].EndPoint;
		Vector3D startTangent = list3[0].StartTangent;
		Vector3D endTangent = list3[0].EndTangent;
		bool flag = IsLine(list3[0]);
		while (list2.Count > 0)
		{
			bool _0023_003DzgLASWEgt0goG = false;
			double _0023_003DzTnVXy6ZEf8OP;
			int index = (_0023_003Dzp9LPrpP9wSDR ? _0023_003Dz4qCJ2WP2w7yb(startPoint, list2, _0023_003Dzn9EIjD5r8BD3: true, out _0023_003DzTnVXy6ZEf8OP) : _0023_003Dz4qCJ2WP2w7yb(startPoint, list2, _0023_003Dzn9EIjD5r8BD3: true, out _0023_003DzTnVXy6ZEf8OP, out _0023_003DzgLASWEgt0goG));
			Vector3D startTangent2 = list2[index].StartTangent;
			if (_0023_003DzgLASWEgt0goG)
			{
				startTangent2 = list2[index].StartTangent;
				startTangent2.Negate();
			}
			bool flag2 = IsLine(list2[index]);
			bool _0023_003DzgLASWEgt0goG2 = false;
			double _0023_003DzTnVXy6ZEf8OP2;
			int index2 = (_0023_003Dzp9LPrpP9wSDR ? _0023_003Dz4qCJ2WP2w7yb(endPoint, list2, _0023_003Dzn9EIjD5r8BD3: false, out _0023_003DzTnVXy6ZEf8OP2) : _0023_003Dz4qCJ2WP2w7yb(endPoint, list2, _0023_003Dzn9EIjD5r8BD3: false, out _0023_003DzTnVXy6ZEf8OP2, out _0023_003DzgLASWEgt0goG2));
			Vector3D startTangent3 = list2[index2].StartTangent;
			if (_0023_003DzgLASWEgt0goG2)
			{
				startTangent3 = list2[index2].StartTangent;
				startTangent3.Negate();
			}
			bool flag3 = IsLine(list2[index2]);
			bool flag4 = false;
			double num2 = Point3D.DistanceSquared(list3[0].StartPoint, list3[list3.Count - 1].EndPoint);
			bool flag5 = num2 < num && num2 < _0023_003DzTnVXy6ZEf8OP + 1E-24 && num2 < _0023_003DzTnVXy6ZEf8OP2 + 1E-24;
			if (Math.Min(_0023_003DzTnVXy6ZEf8OP, _0023_003DzTnVXy6ZEf8OP2) < num && !flag5)
			{
				if (!flag || !flag2 || !flag3)
				{
					flag4 = true;
				}
				else if (!Vector3D.AreOpposite(startTangent, startTangent2) || !Vector3D.AreOpposite(endTangent, startTangent3))
				{
					flag4 = true;
				}
			}
			if (flag4)
			{
				if (_0023_003DzTnVXy6ZEf8OP < _0023_003DzTnVXy6ZEf8OP2)
				{
					if (_0023_003DzgLASWEgt0goG)
					{
						_0023_003Dz_0024fvibmW5yS_0024m(list2[index], _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D);
					}
					list3.Insert(0, list2[index]);
					list2.RemoveAt(index);
					startPoint = list3[0].StartPoint;
					startTangent = list3[0].StartTangent;
					flag = flag2;
				}
				else
				{
					if (_0023_003DzgLASWEgt0goG2)
					{
						_0023_003Dz_0024fvibmW5yS_0024m(list2[index2], _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D);
					}
					list3.Add(list2[index2]);
					list2.RemoveAt(index2);
					endPoint = list3[list3.Count - 1].EndPoint;
					endTangent = list3[list3.Count - 1].EndTangent;
					flag = flag3;
				}
			}
			else
			{
				list.Add(list3);
				if (_0023_003DzpIZC_0024x5EiUBN.Count <= 0)
				{
					break;
				}
				list3 = new List<ICurve> { list2[0] };
				list2.RemoveAt(0);
				startPoint = list3[0].StartPoint;
				endPoint = list3[0].EndPoint;
				startTangent = list3[0].StartTangent;
				endTangent = list3[0].EndTangent;
				flag = IsLine(list3[0]);
			}
		}
		if (list3.Count > 0)
		{
			list.Add(list3);
		}
		if (list.Count == 1 && list[0].Count > 1 && list[0].Count == _0023_003DzpIZC_0024x5EiUBN.Count)
		{
			HashSet<Point3D> hashSet = new HashSet<Point3D>();
			foreach (ICurve item in _0023_003DzpIZC_0024x5EiUBN)
			{
				hashSet.Add(item.StartPoint);
			}
			Point3D[] array = hashSet.ToList().ToArray();
			int[] array2 = new int[_0023_003DzpIZC_0024x5EiUBN.Count];
			for (int i = 0; i < _0023_003DzpIZC_0024x5EiUBN.Count; i++)
			{
				array2[i] = Array.IndexOf(array, _0023_003DzpIZC_0024x5EiUBN[i].StartPoint);
			}
			int[] array3 = new int[_0023_003DzpIZC_0024x5EiUBN.Count];
			for (int j = 0; j < _0023_003DzpIZC_0024x5EiUBN.Count; j++)
			{
				array3[j] = Array.IndexOf(array, list[0][j].StartPoint);
			}
			if (_0023_003Dz_wIB14K_oJMq(array2, array3))
			{
				foreach (List<ICurve> item2 in list)
				{
					if (item2.First().StartPoint.DistanceTo(item2.Last().EndPoint) <= _0023_003Dz3SduW_0024w_003D)
					{
						int k;
						for (k = 0; item2[k].StartPoint.DistanceTo(_0023_003DzpIZC_0024x5EiUBN[0].StartPoint) > _0023_003Dz3SduW_0024w_003D && item2[k].EndPoint.DistanceTo(_0023_003DzpIZC_0024x5EiUBN[0].StartPoint) > _0023_003Dz3SduW_0024w_003D && k < item2.Count; k++)
						{
						}
						RotateLeft(item2, k);
					}
				}
			}
		}
		return list;
	}

	private static List<ICurve> _0023_003DzYqhFQATGjPbVCxJVbw_003D_003D(ICurve _0023_003Dz3Ftsho0_003D, ICurve _0023_003DzAqOpw0w_003D, Dictionary<ICurve, List<ICurve>> _0023_003DzQsGDxYkY_0024t27qWJN4g_003D_003D, List<ICurve> _0023_003DzGxTlPFA_003D, bool _0023_003DzxVe7kdQ_003D, bool _0023_003Dzv2Ru7eyO1_0024YJ)
	{
		List<ICurve> list = new List<ICurve> { _0023_003Dz3Ftsho0_003D };
		_0023_003DzGxTlPFA_003D.Add(_0023_003Dz3Ftsho0_003D);
		while (_0023_003DzQsGDxYkY_0024t27qWJN4g_003D_003D[_0023_003Dz3Ftsho0_003D].Count > 0)
		{
			ICurve curve = null;
			double num = double.MinValue;
			foreach (ICurve item in _0023_003DzQsGDxYkY_0024t27qWJN4g_003D_003D[_0023_003Dz3Ftsho0_003D])
			{
				double num2 = double.MinValue;
				num2 = ((!_0023_003DzxVe7kdQ_003D) ? (_0023_003Dzv2Ru7eyO1_0024YJ ? Vector2D.SignedAngleBetween(item.StartTangent, _0023_003Dz3Ftsho0_003D.EndTangent) : Vector2D.SignedAngleBetween(_0023_003Dz3Ftsho0_003D.EndTangent, item.StartTangent)) : (_0023_003Dzv2Ru7eyO1_0024YJ ? Vector2D.SignedAngleBetween(_0023_003Dz3Ftsho0_003D.StartTangent, item.EndTangent) : Vector2D.SignedAngleBetween(item.EndTangent, _0023_003Dz3Ftsho0_003D.StartTangent)));
				if (num2 >= num)
				{
					num = num2;
					curve = item;
				}
			}
			if (curve == _0023_003DzAqOpw0w_003D || _0023_003DzGxTlPFA_003D.Contains(curve))
			{
				break;
			}
			list.Add(curve);
			_0023_003DzGxTlPFA_003D.Add(curve);
			_0023_003Dz3Ftsho0_003D = curve;
		}
		return list;
	}

	private static List<List<ICurve>> _0023_003DzP8nP_V6x08hJ(IList<ICurve> _0023_003Dz7HmkGjAieABn4X_0024n_Q_003D_003D, Dictionary<ICurve, List<ICurve>> _0023_003DzQsGDxYkY_0024t27qWJN4g_003D_003D, Dictionary<ICurve, List<ICurve>> _0023_003DzpvkCyP8pK5iOy9ii6A_003D_003D, List<ICurve> _0023_003DzGxTlPFA_003D, bool _0023_003Dzbu8BV15Qqzan)
	{
		List<List<ICurve>> list = new List<List<ICurve>>();
		foreach (ICurve item in _0023_003Dz7HmkGjAieABn4X_0024n_Q_003D_003D)
		{
			if (!_0023_003DzGxTlPFA_003D.Contains(item))
			{
				List<ICurve> list2 = _0023_003DzYqhFQATGjPbVCxJVbw_003D_003D(item, item, _0023_003DzQsGDxYkY_0024t27qWJN4g_003D_003D, _0023_003DzGxTlPFA_003D, _0023_003DzxVe7kdQ_003D: true, _0023_003Dzbu8BV15Qqzan);
				List<ICurve> source = _0023_003DzYqhFQATGjPbVCxJVbw_003D_003D(item, item, _0023_003DzpvkCyP8pK5iOy9ii6A_003D_003D, _0023_003DzGxTlPFA_003D, _0023_003DzxVe7kdQ_003D: false, _0023_003Dzbu8BV15Qqzan);
				list2.Reverse();
				List<ICurve> list3 = list2;
				list3.AddRange(source.Skip(1));
				list.Add(list3);
			}
		}
		return list;
	}

	internal static List<List<ICurve>> _0023_003Dz8NPpl2_L8jD6(IList<ICurve> _0023_003Dz01LSNgwwV_S0ZqWYwlhk96c_003D, double _0023_003DzX0qX_IwWxysi, List<ICurve> _0023_003DzfiBtPtOJuTYGM5yQGg_003D_003D, bool _0023_003Dzbu8BV15Qqzan)
	{
		Dictionary<ICurve, List<ICurve>> dictionary = new Dictionary<ICurve, List<ICurve>>();
		Dictionary<ICurve, List<ICurve>> dictionary2 = new Dictionary<ICurve, List<ICurve>>();
		List<ICurve> list = new List<ICurve>();
		List<ICurve> list2 = new List<ICurve>();
		foreach (ICurve item in _0023_003Dz01LSNgwwV_S0ZqWYwlhk96c_003D)
		{
			dictionary[item] = new List<ICurve>();
			dictionary2[item] = new List<ICurve>();
			foreach (ICurve item2 in _0023_003DzfiBtPtOJuTYGM5yQGg_003D_003D)
			{
				Point3D[] array = item.IntersectWith(item2, _0023_003DzX0qX_IwWxysi * _0023_003Dzjyaz_Vfaky9X);
				for (int i = 0; i < array.Length; i++)
				{
					double u = ((InterPoint)array[i]).u;
					if (_0023_003DzuW42NHK3HaLL(u, item.Domain.Left, item.Domain.Length))
					{
						list.Add(item);
					}
					if (_0023_003DzuW42NHK3HaLL(u, item.Domain.Right, item.Domain.Length))
					{
						list2.Add(item);
					}
				}
			}
		}
		for (int j = 0; j < _0023_003Dz01LSNgwwV_S0ZqWYwlhk96c_003D.Count; j++)
		{
			for (int k = j + 1; k < _0023_003Dz01LSNgwwV_S0ZqWYwlhk96c_003D.Count; k++)
			{
				ICurve curve = _0023_003Dz01LSNgwwV_S0ZqWYwlhk96c_003D[j];
				ICurve curve2 = _0023_003Dz01LSNgwwV_S0ZqWYwlhk96c_003D[k];
				if (Point3D.DistanceSquared(curve.StartPoint, curve2.EndPoint) < _0023_003DzX0qX_IwWxysi * _0023_003DzX0qX_IwWxysi)
				{
					if (!list.Contains(curve))
					{
						dictionary[curve].Add(curve2);
					}
					if (!list2.Contains(curve2))
					{
						dictionary2[curve2].Add(curve);
					}
				}
				if (Point3D.DistanceSquared(curve.EndPoint, curve2.StartPoint) < _0023_003DzX0qX_IwWxysi * _0023_003DzX0qX_IwWxysi)
				{
					if (!list2.Contains(curve))
					{
						dictionary2[curve].Add(curve2);
					}
					if (!list.Contains(curve2))
					{
						dictionary[curve2].Add(curve);
					}
				}
			}
		}
		return _0023_003DzP8nP_V6x08hJ(_0023_003Dz01LSNgwwV_S0ZqWYwlhk96c_003D, dictionary, dictionary2, new List<ICurve>(), _0023_003Dzbu8BV15Qqzan);
	}

	private static bool _0023_003Dz_wIB14K_oJMq(int[] _0023_003DzeMBeuAQ_003D, int[] _0023_003DznYtQKck_003D)
	{
		for (int i = 0; i < _0023_003DznYtQKck_003D.Length; i++)
		{
			bool flag = true;
			for (int j = 0; j < _0023_003DzeMBeuAQ_003D.Length; j++)
			{
				if (_0023_003DznYtQKck_003D[(i + j) % _0023_003DznYtQKck_003D.Length] != _0023_003DzeMBeuAQ_003D[j])
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return true;
			}
		}
		return false;
	}

	internal static ICurve _0023_003Dz5gQsf2mKW9NP2e0Zyw_003D_003D(ICurve _0023_003Dz06A5WivSSyUp, bool _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D)
	{
		if (_0023_003Dz06A5WivSSyUp is CompositeCurve compositeCurve && compositeCurve.CurveList.Count > 1)
		{
			CompositeCurve obj = (CompositeCurve)compositeCurve.Clone();
			ICurve[] source = _0023_003DznoMOM1JgBMb7Z2tg4A_003D_003D(compositeCurve.GetIndividualCurves(), _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D);
			obj.CurveList = source.ToList();
			return obj;
		}
		return SmartAdd(_0023_003DznoMOM1JgBMb7Z2tg4A_003D_003D((!(_0023_003Dz06A5WivSSyUp is LinearPath)) ? _0023_003Dz06A5WivSSyUp.GetIndividualCurves() : new ICurve[1] { _0023_003Dz06A5WivSSyUp }, _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D));
	}

	internal static ICurve[] _0023_003DznoMOM1JgBMb7Z2tg4A_003D_003D(IList<ICurve> _0023_003DzpIZC_0024x5EiUBN, bool _0023_003DzL0VDeg7FQifRgV2f0w_003D_003D)
	{
		ICurve[] array = new ICurve[_0023_003DzpIZC_0024x5EiUBN.Count];
		for (int i = 0; i < _0023_003DzpIZC_0024x5EiUBN.Count; i++)
		{
			Entity entity = (Entity)_0023_003DzpIZC_0024x5EiUBN[i];
			Entity entity2 = (Entity)entity.Clone();
			entity2.EntityData = entity.EntityData;
			((ICurve)entity2).EdgeIndex = ((ICurve)entity).EdgeIndex;
			((ICurve)entity2).FromBooleanIntersection = ((ICurve)entity).FromBooleanIntersection;
			array[i] = (ICurve)entity2;
			if (_0023_003DzL0VDeg7FQifRgV2f0w_003D_003D && entity.Vertices != null)
			{
				entity2.Vertices = new Point3D[entity.Vertices.Length];
				for (int j = 0; j < entity2.Vertices.Length; j++)
				{
					entity2.Vertices[j] = (Point3D)entity.Vertices[j].Clone();
				}
				if (entity is TrimCurve)
				{
					TrimCurve trimCurve = (TrimCurve)entity;
					((TrimCurve)entity2).Index = trimCurve.Index;
				}
			}
		}
		return array;
	}

	public static SortedList<double, HitTriangle> FindClosestTriangle(Transformation transf, Segment3D seg, IList<Point3D> vertices, IList<IndexTriangle> triangles)
	{
		SortedList<double, HitTriangle> sortedList = new SortedList<double, HitTriangle>();
		bool flag = transf != null && !transf.IsIdentity();
		Segment3D segment3D = seg;
		if (flag)
		{
			Transformation transformation = (Transformation)transf.Clone();
			transformation.Invert();
			Point3D obj = (Point3D)seg.P0.Clone();
			obj.TransformBy(transformation);
			Point3D point3D = (Point3D)seg.P1.Clone();
			point3D.TransformBy(transformation);
			segment3D = new Segment3D(obj, point3D);
		}
		for (int i = 0; i < triangles.Count; i++)
		{
			IndexTriangle indexTriangle = triangles[i];
			Point3D p = vertices[indexTriangle.V1];
			Point3D p2 = vertices[indexTriangle.V2];
			Point3D p3 = vertices[indexTriangle.V3];
			if (segment3D.IntersectWith(p, p2, p3, out var intPoint))
			{
				if (flag)
				{
					intPoint.TransformBy(transf);
				}
				sortedList[Point3D.Distance(intPoint, seg.P0)] = new HitTriangle(intPoint, i, 0, -1);
			}
		}
		return sortedList;
	}

	private static int _0023_003Dz4qCJ2WP2w7yb(Point3D _0023_003DzMnu3zKCWb6Kc, IList<ICurve> _0023_003DzpIZC_0024x5EiUBN, bool _0023_003Dzn9EIjD5r8BD3, out double _0023_003DzTnVXy6ZEf8OP, out bool _0023_003DzgLASWEgt0goG)
	{
		_0023_003DzgLASWEgt0goG = false;
		_0023_003DzTnVXy6ZEf8OP = double.MaxValue;
		int result = -1;
		for (int i = 0; i < _0023_003DzpIZC_0024x5EiUBN.Count; i++)
		{
			ICurve curve = _0023_003DzpIZC_0024x5EiUBN[i];
			double num = Point3D.DistanceSquared(_0023_003DzMnu3zKCWb6Kc, curve.StartPoint);
			double num2 = Point3D.DistanceSquared(_0023_003DzMnu3zKCWb6Kc, curve.EndPoint);
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

	private static int _0023_003Dz4qCJ2WP2w7yb(Point3D _0023_003DzMnu3zKCWb6Kc, IList<ICurve> _0023_003DzpIZC_0024x5EiUBN, bool _0023_003Dzn9EIjD5r8BD3, out double _0023_003DzTnVXy6ZEf8OP)
	{
		_0023_003DzTnVXy6ZEf8OP = double.MaxValue;
		int result = -1;
		for (int i = 0; i < _0023_003DzpIZC_0024x5EiUBN.Count; i++)
		{
			ICurve curve = _0023_003DzpIZC_0024x5EiUBN[i];
			double val = Point3D.DistanceSquared(_0023_003DzMnu3zKCWb6Kc, curve.StartPoint);
			double val2 = Point3D.DistanceSquared(_0023_003DzMnu3zKCWb6Kc, curve.EndPoint);
			double num = Math.Min(val, val2);
			if (num < _0023_003DzTnVXy6ZEf8OP)
			{
				_0023_003DzTnVXy6ZEf8OP = num;
				result = i;
			}
		}
		return result;
	}

	public static int GetOuterIndex(IList<IList<Point2D>> loops)
	{
		int num = 0;
		IList<Point2D> list = loops[num];
		BoundingRect(list, out var min, out var max);
		double domainSize = Point2D.Distance(min, max);
		for (int i = 0; i < loops.Count; i++)
		{
			if (i != num)
			{
				IList<Point2D> list2 = loops[i];
				if (list2.Count >= 3 && PointInPolygon(list2[1], list, domainSize) == pointStatusType.Outside && num < loops.Count - 1)
				{
					num++;
					list = loops[num];
					BoundingRect(list, out min, out max);
					domainSize = Point2D.Distance(min, max);
					i = -1;
				}
			}
		}
		if (num >= loops.Count)
		{
			return -1;
		}
		return num;
	}

	public static int GetOuterIndex(IList<IList<ICurve>> loops)
	{
		int num = 0;
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(SmartAdd(loops[num]), Plane.XY, sortAndOrient: false);
		for (int i = 0; i < loops.Count; i++)
		{
			if (i != num)
			{
				ICurve curve = loops[i][0];
				double t = curve.Domain.ParameterAt(0.1);
				if (!region.IsPointInside(curve.PointAt(t)) && num < loops.Count - 1)
				{
					num++;
					region = new devDept.Eyeshot.Entities.Region(SmartAdd(loops[num]), Plane.XY, sortAndOrient: false);
					i = -1;
				}
			}
		}
		if (num >= loops.Count)
		{
			return -1;
		}
		return num;
	}

	public static int GetOuterIndex(IList<Polygon2D> loops)
	{
		IList<IList<Point2D>> list = new List<IList<Point2D>>(loops.Count);
		for (int i = 0; i < loops.Count; i++)
		{
			list.Add(loops[i].Points);
		}
		return GetOuterIndex(list);
	}

	protected internal static void CreateCone(Mesh.natureType meshNature, double baseRadius, double topRadius, double height, int slices, bool computeNormals, out int firstBaseCenter, out int nCaps, out Point3D[] vertices, out IndexTriangle[] triangles, out Vector3D[] normals)
	{
		normals = null;
		int num = slices + 2;
		int num2 = slices * 2;
		nCaps = 1;
		if (baseRadius > _0023_003DzheSR8QM7q9ya && topRadius > _0023_003DzheSR8QM7q9ya)
		{
			num += slices;
			num2 *= 2;
			nCaps = 2;
		}
		_0023_003DzkudcX0UMh8Ow(slices, out var _0023_003Dz53vep03Z0JNX, out var _0023_003DzZtlDGFno_0024h0F);
		vertices = new Point3D[num];
		double z = (0.0 - (topRadius - baseRadius)) / height;
		if (computeNormals)
		{
			normals = new Vector3D[num];
			for (int i = 0; i < slices; i++)
			{
				Vector3D vector3D = new Vector3D(_0023_003DzZtlDGFno_0024h0F[i], _0023_003Dz53vep03Z0JNX[i], z);
				vector3D.Normalize();
				normals[i] = vector3D;
			}
		}
		if (baseRadius > _0023_003DzheSR8QM7q9ya)
		{
			_0023_003DzrorvIOifRofVQOeiFA_003D_003D(meshNature, baseRadius, 0.0, slices, _0023_003DzZtlDGFno_0024h0F, _0023_003Dz53vep03Z0JNX, 0, vertices);
		}
		if (topRadius > _0023_003DzheSR8QM7q9ya)
		{
			_0023_003DzrorvIOifRofVQOeiFA_003D_003D(meshNature, topRadius, height, slices, _0023_003DzZtlDGFno_0024h0F, _0023_003Dz53vep03Z0JNX, slices * (nCaps - 1), vertices);
		}
		if (computeNormals && nCaps == 2)
		{
			for (int j = slices; j < 2 * slices; j++)
			{
				normals[j] = (Vector3D)normals[j - slices].Clone();
			}
		}
		firstBaseCenter = slices * nCaps;
		vertices[firstBaseCenter] = CreateVertex(meshNature, 0.0, 0.0, 0.0);
		vertices[firstBaseCenter + 1] = CreateVertex(meshNature, 0.0, 0.0, height);
		if (computeNormals)
		{
			normals[firstBaseCenter] = new Vector3D(0.0, 0.0, -1.0);
			normals[firstBaseCenter + 1] = new Vector3D(0.0, 0.0, 1.0);
		}
		triangles = new IndexTriangle[num2];
		int num3 = 0;
		if (baseRadius > _0023_003DzheSR8QM7q9ya)
		{
			for (int k = 0; k < slices; k++)
			{
				int num4 = k;
				int num5 = ((k + 1 < slices) ? (k + 1) : 0);
				int num6 = ((nCaps != 2) ? (firstBaseCenter + 1) : ((k + slices + 1 >= slices * nCaps) ? slices : (k + slices + 1)));
				int n = num4;
				int n2 = num5;
				int n3 = num6;
				triangles[num3++] = CreateTriangle(meshNature, num4, num5, num6, n, n2, n3);
				num4 = slices * nCaps;
				num5 = ((k + 1 < slices) ? (k + 1) : 0);
				num6 = k;
				n = firstBaseCenter;
				n2 = firstBaseCenter;
				n3 = firstBaseCenter;
				triangles[num3++] = CreateTriangle(meshNature, num4, num5, num6, n, n2, n3);
			}
		}
		if (!(topRadius > _0023_003DzheSR8QM7q9ya))
		{
			return;
		}
		int num7 = ((nCaps == 2) ? slices : 0);
		for (int l = 0; l < slices; l++)
		{
			int num5 = ((l + num7 + 1 >= firstBaseCenter) ? num7 : (l + num7 + 1));
			int num4;
			int num6;
			if (nCaps == 2)
			{
				num4 = l;
				num6 = l + slices;
			}
			else
			{
				num4 = slices;
				num6 = l;
			}
			int n = num4;
			int n2 = num5;
			int n3 = num6;
			triangles[num3++] = CreateTriangle(meshNature, num4, num5, num6, n, n2, n3);
			num4 = firstBaseCenter + 1;
			num5 = l + num7;
			num6 = ((l + num7 + 1 >= firstBaseCenter) ? num7 : (l + num7 + 1));
			n = firstBaseCenter + 1;
			n2 = firstBaseCenter + 1;
			n3 = firstBaseCenter + 1;
			triangles[num3++] = CreateTriangle(meshNature, num4, num5, num6, n, n2, n3);
		}
	}

	private static void _0023_003DzkudcX0UMh8Ow(int _0023_003DzAPBIJmvn5i5Q, out double[] _0023_003Dz53vep03Z0JNX, out double[] _0023_003DzZtlDGFno_0024h0F)
	{
		_0023_003Dz53vep03Z0JNX = new double[_0023_003DzAPBIJmvn5i5Q];
		_0023_003DzZtlDGFno_0024h0F = new double[_0023_003DzAPBIJmvn5i5Q];
		double num = Math.PI * 2.0 / (double)_0023_003DzAPBIJmvn5i5Q;
		double num2 = 0.0;
		for (int i = 0; i < _0023_003DzAPBIJmvn5i5Q; i++)
		{
			_0023_003DzZtlDGFno_0024h0F[i] = Math.Cos(num2);
			_0023_003Dz53vep03Z0JNX[i] = Math.Sin(num2);
			num2 += num;
		}
	}

	private static void _0023_003DzrorvIOifRofVQOeiFA_003D_003D(Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, double _0023_003DzEGKj_0024SNUUihi, double _0023_003DzvAxV_0024Ic_003D, int _0023_003DzAPBIJmvn5i5Q, double[] _0023_003DzZtlDGFno_0024h0F, double[] _0023_003Dz53vep03Z0JNX, int _0023_003DzAddCv_o_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		for (int i = 0; i < _0023_003DzAPBIJmvn5i5Q; i++)
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzAddCv_o_003D + i] = CreateVertex(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, _0023_003DzZtlDGFno_0024h0F[i] * _0023_003DzEGKj_0024SNUUihi, _0023_003Dz53vep03Z0JNX[i] * _0023_003DzEGKj_0024SNUUihi, _0023_003DzvAxV_0024Ic_003D);
		}
	}

	internal static IndexTriangle _0023_003Dzk3meeCc_003D(Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
	{
		switch (_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
		{
		case Mesh.natureType.Plain:
		case Mesh.natureType.MulticolorPlain:
			return new IndexTriangle();
		case Mesh.natureType.ColorPlain:
			return new ColorTriangle();
		case Mesh.natureType.RichPlain:
			return new RichTriangle();
		case Mesh.natureType.Smooth:
		case Mesh.natureType.MulticolorSmooth:
			return new SmoothTriangle();
		case Mesh.natureType.ColorSmooth:
			return new ColorSmoothTriangle();
		case Mesh.natureType.RichSmooth:
			return new RichSmoothTriangle();
		default:
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661219));
		}
	}

	public static IndexTriangle CreateTriangle(Mesh.natureType meshNature, int v1, int v2, int v3)
	{
		IndexTriangle indexTriangle = _0023_003Dzk3meeCc_003D(meshNature);
		indexTriangle.V1 = v1;
		indexTriangle.V2 = v2;
		indexTriangle.V3 = v3;
		return indexTriangle;
	}

	public static IndexTriangle CreateTriangle(Mesh.natureType meshNature, int v1, int v2, int v3, int n1, int n2, int n3)
	{
		IndexTriangle indexTriangle = CreateTriangle(meshNature, v1, v2, v3);
		if (indexTriangle is SmoothTriangle)
		{
			SmoothTriangle obj = (SmoothTriangle)indexTriangle;
			obj.N1 = n1;
			obj.N2 = n2;
			obj.N3 = n3;
		}
		return indexTriangle;
	}

	public static IndexTriangle CreateTriangle(Mesh.natureType meshNature, int v1, int v2, int v3, int n1, int n2, int n3, int t1, int t2, int t3)
	{
		IndexTriangle indexTriangle = CreateTriangle(meshNature, v1, v2, v3);
		if (indexTriangle is RichSmoothTriangle)
		{
			RichSmoothTriangle obj = (RichSmoothTriangle)indexTriangle;
			obj.N1 = n1;
			obj.N2 = n2;
			obj.N3 = n3;
			obj.T1 = t1;
			obj.T2 = t2;
			obj.T3 = t3;
		}
		else if (indexTriangle is SmoothTriangle)
		{
			SmoothTriangle obj2 = (SmoothTriangle)indexTriangle;
			obj2.N1 = n1;
			obj2.N2 = n2;
			obj2.N3 = n3;
		}
		return indexTriangle;
	}

	public static Point3D CreateVertex(Mesh.natureType meshNature, double x, double y, double z)
	{
		switch (meshNature)
		{
		case Mesh.natureType.Plain:
		case Mesh.natureType.ColorPlain:
		case Mesh.natureType.RichPlain:
		case Mesh.natureType.Smooth:
		case Mesh.natureType.ColorSmooth:
		case Mesh.natureType.RichSmooth:
			return new Point3D(x, y, z);
		case Mesh.natureType.MulticolorPlain:
		case Mesh.natureType.MulticolorSmooth:
			return new PointRGB(x, y, z, 0, 0, 0);
		default:
			return null;
		}
	}

	protected internal static void CreateSphere(Mesh.natureType meshNature, double radius, int slices, int stacks, bool computeNormals, bool computeTextureCoords, out Point3D[] vertices, out IndexTriangle[] triangles, out Vector3D[] normals, out PointF[] texCoords)
	{
		int num = (computeTextureCoords ? (slices + 1) : slices);
		int num2 = num * (stacks - 1);
		num2 = ((!computeTextureCoords) ? (num2 + 2) : (num2 + 2 * num));
		vertices = new Point3D[num2];
		normals = null;
		if (computeNormals)
		{
			normals = new Vector3D[vertices.Length];
		}
		double[] array = new double[slices];
		double[] array2 = new double[slices];
		double num3 = 0.0;
		double num4 = Math.PI * 2.0 / (double)slices;
		for (int i = 0; i < slices; i++)
		{
			array[i] = Math.Cos(num3);
			array2[i] = Math.Sin(num3);
			num3 += num4;
		}
		double num5 = -Math.PI / 2.0;
		double num6 = Math.PI / (double)stacks;
		if (computeTextureCoords)
		{
			texCoords = new PointF[num2];
		}
		else
		{
			texCoords = null;
		}
		int num7 = 0;
		for (int j = 1; j < stacks; j++)
		{
			num5 += num6;
			double _0023_003Dz5qsuplK9eeyC = Math.Cos(num5);
			double _0023_003Dzj99uia_0024UjE6L = Math.Sin(num5);
			int num8 = 0;
			while (num8 < num)
			{
				_0023_003DzDeutQJrDzJ4h(meshNature, 0.0, radius, num7, array[num8 % slices], array2[num8 % slices], _0023_003Dz5qsuplK9eeyC, _0023_003Dzj99uia_0024UjE6L, computeNormals, vertices, normals);
				num8++;
				num7++;
			}
			if (computeTextureCoords)
			{
				num7 -= num;
				int num9 = 0;
				while (num9 < num)
				{
					texCoords[num7] = new PointF((float)num9 / (float)slices, (float)j / (float)stacks);
					num9++;
					num7++;
				}
			}
		}
		if (computeTextureCoords)
		{
			int num10 = 0;
			while (num10 < num)
			{
				_0023_003DzDeutQJrDzJ4h(meshNature, 0.0, radius, num7, array[0], array2[0], Math.Cos(-Math.PI / 2.0), Math.Sin(-Math.PI / 2.0), computeNormals, vertices, normals);
				texCoords[num7] = new PointF((float)num10 / (float)slices, 0f);
				num10++;
				num7++;
			}
			int num11 = 0;
			while (num11 < num)
			{
				_0023_003DzDeutQJrDzJ4h(meshNature, 0.0, radius, num7, array[0], array2[0], Math.Cos(Math.PI / 2.0), Math.Sin(Math.PI / 2.0), computeNormals, vertices, normals);
				texCoords[num7] = new PointF((float)num11 / (float)slices, 1f);
				num11++;
				num7++;
			}
		}
		else
		{
			_0023_003DzDeutQJrDzJ4h(meshNature, 0.0, radius, num7, array[0], array2[0], Math.Cos(-Math.PI / 2.0), Math.Sin(-Math.PI / 2.0), computeNormals, vertices, normals);
			num7++;
			_0023_003DzDeutQJrDzJ4h(meshNature, 0.0, radius, num7, array[0], array2[0], Math.Cos(Math.PI / 2.0), Math.Sin(Math.PI / 2.0), computeNormals, vertices, normals);
		}
		int num12 = slices * (stacks - 1) * 2;
		triangles = new IndexTriangle[num12];
		int num13 = 0;
		num7 = 0;
		int num17;
		int num15;
		if (computeTextureCoords)
		{
			for (int k = 1; k < stacks - 1; k++)
			{
				int num14 = 0;
				while (num14 < slices)
				{
					num15 = num7;
					int num16 = num7 + 1;
					num17 = num7 + num + 1;
					triangles[num13++] = CreateTriangle(meshNature, num15, num16, num17, num15, num16, num17, num15, num16, num17);
					num16 = num7 + num + 1;
					num17 = num7 + num;
					triangles[num13++] = CreateTriangle(meshNature, num15, num16, num17, num15, num16, num17, num15, num16, num17);
					num14++;
					num7++;
				}
				num7++;
			}
			num15 = num * (stacks - 1);
			num7 = 0;
			int num18 = 0;
			while (num18 < slices)
			{
				int num16 = num7 + 1;
				num17 = num7;
				triangles[num13++] = CreateTriangle(meshNature, num15, num16, num17, num15, num16, num17, num15, num16, num17);
				num18++;
				num7++;
				num15++;
			}
			num17 = num * stacks;
			num7 = num * (stacks - 2);
			int num19 = 0;
			while (num19 < slices)
			{
				num15 = num7;
				int num16 = num7 + 1;
				triangles[num13++] = CreateTriangle(meshNature, num15, num16, num17, num15, num16, num17, num15, num16, num17);
				num19++;
				num7++;
				num17++;
			}
			return;
		}
		for (int l = 1; l < stacks - 1; l++)
		{
			int num20 = 0;
			while (num20 < slices)
			{
				num15 = num7;
				int num16 = ((num20 + 1 >= slices) ? ((l - 1) * slices) : (num7 + 1));
				num17 = ((num20 + slices + 1 >= slices * 2) ? (slices + (l - 1) * slices) : (num7 + slices + 1));
				triangles[num13++] = CreateTriangle(meshNature, num15, num16, num17, num15, num16, num17, num15, num16, num17);
				num16 = ((num20 + slices + 1 >= slices * 2) ? (slices + (l - 1) * slices) : (num7 + slices + 1));
				num17 = num7 + slices;
				triangles[num13++] = CreateTriangle(meshNature, num15, num16, num17, num15, num16, num17, num15, num16, num17);
				num20++;
				num7++;
			}
		}
		num15 = slices * (stacks - 1);
		num7 = 0;
		int num21 = 0;
		while (num21 < slices)
		{
			int num16 = ((num21 + 1 < slices) ? (num7 + 1) : 0);
			num17 = num7;
			triangles[num13++] = CreateTriangle(meshNature, num15, num16, num17, num15, num16, num17, num15, num16, num17);
			num21++;
			num7++;
		}
		num17 = slices * (stacks - 1) + 1;
		num7 = slices * (stacks - 2);
		int num22 = 0;
		while (num22 < slices)
		{
			num15 = num7;
			int num16 = ((num22 + 1 >= slices) ? (slices * (stacks - 2)) : (num7 + 1));
			triangles[num13++] = CreateTriangle(meshNature, num15, num16, num17, num15, num16, num17, num15, num16, num17);
			num22++;
			num7++;
		}
	}

	internal static void _0023_003DzDeutQJrDzJ4h(Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, double _0023_003DzA_8ilLvuROi4, double _0023_003DzZonw8nQGtIca, int _0023_003DzyzK8swU_003D, double _0023_003DzoMs3NThpuAJj, double _0023_003Dz1b_0024wYI9rNJKX, double _0023_003Dz5qsuplK9eeyC, double _0023_003Dzj99uia_0024UjE6L, bool _0023_003DztU8XIY9a8QJIXrxx2Q_003D_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IList<Vector3D> _0023_003DzztJY0_0024dXEFMk)
	{
		double num = _0023_003Dz5qsuplK9eeyC * _0023_003DzoMs3NThpuAJj;
		double num2 = _0023_003Dz5qsuplK9eeyC * _0023_003Dz1b_0024wYI9rNJKX;
		if (_0023_003DztU8XIY9a8QJIXrxx2Q_003D_003D)
		{
			_0023_003DzztJY0_0024dXEFMk[_0023_003DzyzK8swU_003D] = new Vector3D(num, num2, _0023_003Dzj99uia_0024UjE6L);
		}
		_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzyzK8swU_003D] = CreateVertex(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, _0023_003DzA_8ilLvuROi4 * _0023_003DzoMs3NThpuAJj + num * _0023_003DzZonw8nQGtIca, _0023_003DzA_8ilLvuROi4 * _0023_003Dz1b_0024wYI9rNJKX + num2 * _0023_003DzZonw8nQGtIca, _0023_003Dzj99uia_0024UjE6L * _0023_003DzZonw8nQGtIca);
	}

	internal static bool _0023_003DzHIeX7C3oyv3F(double _0023_003Dz6pajdGM_003D, Interval _0023_003DzhbkBViI_003D, bool _0023_003DzQFI4Hrif1AaZ, out double[] _0023_003DzIAd7SiQgIqUPtq5oAw_003D_003D)
	{
		_0023_003DzIAd7SiQgIqUPtq5oAw_003D_003D = new double[0];
		List<double> list = new List<double>();
		if (_0023_003DzhbkBViI_003D.Includes(_0023_003Dz6pajdGM_003D, testOpenInterval: true))
		{
			list.Add(_0023_003Dz6pajdGM_003D);
			if (_0023_003DzhbkBViI_003D.Includes(_0023_003Dz6pajdGM_003D + Math.PI, testOpenInterval: true))
			{
				list.Add(_0023_003Dz6pajdGM_003D + Math.PI);
			}
			if (_0023_003DzhbkBViI_003D.Includes(_0023_003Dz6pajdGM_003D - Math.PI, testOpenInterval: true))
			{
				list.Add(_0023_003Dz6pajdGM_003D - Math.PI);
			}
			_0023_003DzIAd7SiQgIqUPtq5oAw_003D_003D = list.ToArray();
			return true;
		}
		if (_0023_003Dz6pajdGM_003D < _0023_003DzhbkBViI_003D.High)
		{
			do
			{
				_0023_003Dz6pajdGM_003D += Math.PI;
				if (_0023_003DzhbkBViI_003D.Includes(_0023_003Dz6pajdGM_003D, _0023_003DzQFI4Hrif1AaZ))
				{
					list.Add(_0023_003Dz6pajdGM_003D);
				}
			}
			while (_0023_003Dz6pajdGM_003D < _0023_003DzhbkBViI_003D.High);
		}
		else if (_0023_003Dz6pajdGM_003D > _0023_003DzhbkBViI_003D.Low)
		{
			do
			{
				_0023_003Dz6pajdGM_003D -= Math.PI;
				if (_0023_003DzhbkBViI_003D.Includes(_0023_003Dz6pajdGM_003D, _0023_003DzQFI4Hrif1AaZ))
				{
					list.Add(_0023_003Dz6pajdGM_003D);
				}
			}
			while (_0023_003Dz6pajdGM_003D > _0023_003DzhbkBViI_003D.Low);
		}
		if (list.Count > 0)
		{
			_0023_003DzIAd7SiQgIqUPtq5oAw_003D_003D = list.ToArray();
			return true;
		}
		return false;
	}

	internal static bool _0023_003Dz01EVtoUdEn9B(ICurve _0023_003Dz8fpRyMu9aKjE, IList<Point3D> _0023_003DzrdSL0CI_003D, out ICurve[] _0023_003DzKTAIrow_003D)
	{
		List<ICurve> list = new List<ICurve>();
		List<double> list2 = new List<double>();
		for (int i = 0; i < _0023_003DzrdSL0CI_003D.Count; i++)
		{
			Point3D point = _0023_003DzrdSL0CI_003D[i];
			_0023_003Dz8fpRyMu9aKjE.ClosestPointTo(point, out var t);
			if (!list2.Contains(t))
			{
				list2.Add(t);
			}
		}
		list2.Sort();
		if (_0023_003DzftzqUl9H6tLy(_0023_003Dz8fpRyMu9aKjE, list2, list))
		{
			_0023_003DzKTAIrow_003D = list.ToArray();
			return true;
		}
		_0023_003DzKTAIrow_003D = new ICurve[0];
		return false;
	}

	internal static bool _0023_003DzftzqUl9H6tLy(ICurve _0023_003Dz8fpRyMu9aKjE, IEnumerable<double> _0023_003DzBlBnvuA_003D, List<ICurve> _0023_003DzpIZC_0024x5EiUBN)
	{
		List<double> list = new List<double>(_0023_003DzBlBnvuA_003D);
		if (list.Count == 0)
		{
			return false;
		}
		ICurve lower;
		ICurve upper;
		bool num = _0023_003Dz8fpRyMu9aKjE.SplitAt(list[list.Count - 1], out lower, out upper);
		list.RemoveAt(list.Count - 1);
		ICurve curve = (num ? lower : _0023_003Dz8fpRyMu9aKjE);
		bool flag = _0023_003DzftzqUl9H6tLy(curve, list, _0023_003DzpIZC_0024x5EiUBN);
		if (num)
		{
			if (!flag)
			{
				_0023_003DzpIZC_0024x5EiUBN.Add(curve);
			}
			_0023_003DzpIZC_0024x5EiUBN.Add(upper);
		}
		return num || flag;
	}

	internal static bool _0023_003DzORMVE0Xmd0DtzbF76UFKV_0024E_00240xze8ka1xgCJQIc_003D(IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Vector3D _0023_003DzYNjcavt9guh2)
	{
		Plane trianglesPlane = GetTrianglesPlane(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
		return Vector3D.Dot(_0023_003DzYNjcavt9guh2, trianglesPlane.AxisZ) > 1E-06;
	}

	internal static bool _0023_003DzWU235rVAR0aSlJTfp4IMM8ikjdbN(IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003DzcuodTXZMEy5xbKmohQ_003D_003D, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzyNZquWXQaPzE)
	{
		Plane trianglesPlane = GetTrianglesPlane(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
		Vector3D vector3D = (Vector3D)_0023_003DzxuJqjrs_003D.Clone();
		Vector2D vector2D = trianglesPlane.Project(vector3D) - trianglesPlane.Project(new Vector3D());
		vector2D.Normalize();
		double num = Math.Acos(vector2D.X);
		num = ((!(vector2D.Y < 0.0)) ? (num - Math.PI / 2.0) : (4.71238898038469 - num));
		Point3D point3D = (Point3D)trianglesPlane.Origin.Clone();
		trianglesPlane.Translate(0.0 - point3D.X, 0.0 - point3D.Y, 0.0 - point3D.Z);
		trianglesPlane.Rotate(num, trianglesPlane.AxisZ);
		trianglesPlane.Translate(point3D.X, point3D.Y, point3D.Z);
		Point3D point3D2 = _0023_003DzyNZquWXQaPzE - point3D;
		if (Vector3D.Dot(trianglesPlane.AxisY, vector3D) < 0.0)
		{
			point3D = (Point3D)trianglesPlane.Origin.Clone();
			trianglesPlane.Translate(0.0 - point3D.X, 0.0 - point3D.Y, 0.0 - point3D.Z);
			trianglesPlane.Rotate(Math.PI, trianglesPlane.AxisZ);
			trianglesPlane.Translate(point3D.X, point3D.Y, point3D.Z);
		}
		trianglesPlane.Translate(point3D2.AsVector);
		Point2D point2D = null;
		double num2 = 0.0;
		for (int i = 0; i < _0023_003DzcuodTXZMEy5xbKmohQ_003D_003D; i++)
		{
			Point2D point2D2 = trianglesPlane.Project(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]);
			double num3 = Math.Abs(point2D2.X);
			if (num3 > num2)
			{
				point2D = point2D2;
				num2 = num3;
			}
		}
		if (point2D == null)
		{
			return false;
		}
		return point2D.X < 0.0;
	}

	internal static bool _0023_003Dzcgl1YHa2I1jhVm1Gy8K96dA_003D(ICurve _0023_003DzKqXe0lZPPVXXTI8rHg_003D_003D, Vector3D _0023_003DzZbOaTIM_003D, Vector3D _0023_003DzxuJqjrs_003D, Point3D _0023_003DzbUvT9Pc_003D)
	{
		Vector3D vector3D = (Vector3D)_0023_003DzxuJqjrs_003D.Clone();
		vector3D.Normalize();
		Point3D point3D = new Point3D();
		double num = double.MinValue;
		Vector3D x = new Vector3D();
		Segment3D seg = new Segment3D(_0023_003DzbUvT9Pc_003D, _0023_003DzbUvT9Pc_003D + vector3D);
		Point4D[] controlPoints = _0023_003DzKqXe0lZPPVXXTI8rHg_003D_003D.GetNurbsForm().ControlPoints;
		for (int i = 0; i < controlPoints.Length; i++)
		{
			double w = controlPoints[i].W;
			point3D.X = controlPoints[i].X / w;
			point3D.Y = controlPoints[i].Y / w;
			point3D.Z = controlPoints[i].Z / w;
			Point3D b = point3D.ProjectTo(seg);
			Vector3D vector3D2 = Vector3D.Subtract(point3D, b);
			double length = vector3D2.Length;
			new Vector3D();
			if (length > 0.0)
			{
				vector3D2.Normalize();
				if (length > num)
				{
					num = length;
					x = (Vector3D)vector3D2.Clone();
				}
			}
			else
			{
				vector3D2 = new Vector3D();
			}
			Vector3D.Cross(vector3D, vector3D2);
		}
		if (num == double.MinValue)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302964835));
		}
		return Vector3D.Dot(new Plane(_0023_003DzbUvT9Pc_003D, x, vector3D).AxisZ, _0023_003DzZbOaTIM_003D) < 1E-06;
	}

	internal static Point3D _0023_003DzbeHMzga5LfNKjFeCKg_003D_003D(IList<Point3D> _0023_003DzrdSL0CI_003D)
	{
		Point3D point3D = _0023_003DzrdSL0CI_003D[0];
		for (int i = 1; i < _0023_003DzrdSL0CI_003D.Count; i++)
		{
			point3D += _0023_003DzrdSL0CI_003D[i];
		}
		return point3D / _0023_003DzrdSL0CI_003D.Count;
	}

	public static Mesh ConvexHull(IList<Point3D> points, double domainSize = 0.0, bool fixNormal = true, bool getFaces = true)
	{
		if (domainSize == 0.0)
		{
			ComputeBoundingBox(points, out var boxMin, out var boxMax);
			domainSize = new Size3D(boxMin, boxMax).Diagonal;
		}
		ConvexHull(points, domainSize, out var iVertices, out var iTriangles, getFaces, fixNormal);
		return new Mesh(iVertices, iTriangles);
	}

	public static void ConvexHull(IList<Point3D> points, double domainSize, out Point3D[] iVertices, out IndexTriangle[] iTriangles, bool getFaces, bool fixNormals)
	{
		List<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8> list = new List<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8>(points.Count);
		Random random = new Random(0);
		double num = domainSize * _0023_003DzheSR8QM7q9ya;
		for (int i = 0; i < points.Count; i++)
		{
			Point3D point3D = (Point3D)points[i].Clone();
			_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8 _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv9 = new _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8();
			_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv9.Position = new double[3]
			{
				(point3D.X += random.NextDouble() * num),
				(point3D.Y += random.NextDouble() * num),
				(point3D.Z += random.NextDouble() * num)
			};
			_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv9._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D = i;
			_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8 item = _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv9;
			list.Add(item);
		}
		ConvexHullCreationResult<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8, DefaultConvexFace<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8>> convexHullCreationResult = MIConvexHull.ConvexHull.Create(list, 1E-10);
		if (convexHullCreationResult.Result == null)
		{
			iVertices = new Point3D[0];
			iTriangles = new IndexTriangle[0];
			return;
		}
		_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8[] array = convexHullCreationResult.Result.Points.ToArray();
		iVertices = new Point3D[convexHullCreationResult.Result.Points.Count()];
		int[] array2 = new int[points.Count];
		for (int j = 0; j < array.Length; j++)
		{
			_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8 _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv10 = array[j];
			iVertices[j] = (Point3D)points[_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv10._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D].Clone();
			array2[_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv10._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D] = j;
		}
		if (getFaces)
		{
			DefaultConvexFace<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8>[] array3 = convexHullCreationResult.Result.Faces.ToArray();
			iTriangles = new IndexTriangle[convexHullCreationResult.Result.Faces.Count()];
			for (int k = 0; k < array3.Length; k++)
			{
				DefaultConvexFace<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8> defaultConvexFace = array3[k];
				int num2 = array2[defaultConvexFace.Vertices[0]._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D];
				int num3 = array2[defaultConvexFace.Vertices[1]._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D];
				int num4 = array2[defaultConvexFace.Vertices[2]._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D];
				Vector3D axisZ = new Plane(iVertices[num2], iVertices[num3], iVertices[num4]).AxisZ;
				if (Vector3D.Dot(new Vector3D(defaultConvexFace.Normal[0], defaultConvexFace.Normal[1], defaultConvexFace.Normal[2]), axisZ) > 0.0 || !fixNormals)
				{
					iTriangles[k] = new IndexTriangle(num2, num3, num4);
				}
				else
				{
					iTriangles[k] = new IndexTriangle(num2, num4, num3);
				}
			}
		}
		else
		{
			iTriangles = new IndexTriangle[0];
		}
	}

	public static float[] ConvexHull(IList<float> pointsCoords, double domainSize)
	{
		_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8[] array = new _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8[pointsCoords.Count / 3];
		Random random = new Random(0);
		double num = domainSize * _0023_003DzheSR8QM7q9ya;
		for (int i = 0; i < pointsCoords.Count; i += 3)
		{
			_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8 _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv9 = new _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8();
			_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv9.Position = new double[3]
			{
				(double)pointsCoords[i] + random.NextDouble() * num,
				(double)pointsCoords[i + 1] + random.NextDouble() * num,
				(double)pointsCoords[i + 2] + random.NextDouble() * num
			};
			_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv9._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D = i / 3;
			_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8 _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv10 = _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv9;
			array[i / 3] = _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv10;
		}
		ConvexHullCreationResult<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8, DefaultConvexFace<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8>> convexHullCreationResult = MIConvexHull.ConvexHull.Create(array, 1E-10);
		array = null;
		if (convexHullCreationResult.Result == null)
		{
			return new float[0];
		}
		_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8[] array2 = (_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8[])convexHullCreationResult.Result.Points;
		float[] array3 = new float[array2.Length * 3];
		for (int j = 0; j < array2.Length; j++)
		{
			_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8 _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv11 = array2[j];
			array3[j * 3] = pointsCoords[_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv11._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D * 3];
			array3[j * 3 + 1] = pointsCoords[_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv11._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D * 3 + 1];
			array3[j * 3 + 2] = pointsCoords[_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv11._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D * 3 + 2];
		}
		return array3;
	}

	public static Point2D[] ConvexHull2D(IList<Point2D> points, bool sorted)
	{
		List<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8> list = new List<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8>(points.Count);
		for (int i = 0; i < points.Count; i++)
		{
			list.Add(new _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8
			{
				Position = new double[2]
				{
					points[i].X,
					points[i].Y
				},
				_0023_003DzVRJBdwP4f05YIEyr2g_003D_003D = i
			});
		}
		ConvexHullCreationResult<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8, DefaultConvexFace<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8>> convexHullCreationResult = MIConvexHull.ConvexHull.Create<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8, DefaultConvexFace<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8>>(list);
		list.Clear();
		if (convexHullCreationResult.Result != null)
		{
			_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8[] array = convexHullCreationResult.Result.Points.ToArray();
			List<Point2D> list2 = new List<Point2D>(convexHullCreationResult.Result.Points.Count());
			foreach (_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8 _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv9 in array)
			{
				list2.Add(points[_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv9._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D]);
			}
			if (sorted)
			{
				DefaultConvexFace<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8> defaultConvexFace = convexHullCreationResult.Result.Faces.ElementAt(0);
				List<Point2D> list3 = new List<Point2D>();
				_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8 _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv10 = defaultConvexFace.Vertices[0];
				list3.Add(points[_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv10._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D]);
				for (DefaultConvexFace<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8> defaultConvexFace2 = defaultConvexFace.Adjacency[0]; defaultConvexFace2 != defaultConvexFace; defaultConvexFace2 = defaultConvexFace2.Adjacency[0])
				{
					_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8 _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv11 = defaultConvexFace2.Vertices[0];
					list3.Add(points[_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv11._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D]);
				}
				_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8 _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv12 = convexHullCreationResult.Result.Faces.ElementAt(0).Vertices[0];
				list3.Add((Point2D)points[_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv12._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D].Clone());
				return Enumerable.ToArray(list3);
			}
			return Enumerable.ToArray(list2);
		}
		return null;
	}

	internal static Point3D[] _0023_003DzHgehaXbXsoae65o_R1WkC5o_003D(ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		if (_0023_003Dz8fpRyMu9aKjE is devDept.Eyeshot.Entities.Point point)
		{
			return new Point3D[1] { point.Position };
		}
		if (_0023_003Dz8fpRyMu9aKjE is Line line)
		{
			return new Point3D[2] { line.StartPoint, line.EndPoint };
		}
		if (!(_0023_003Dz8fpRyMu9aKjE is LinearPath { Vertices: var vertices }))
		{
			if (_0023_003Dz8fpRyMu9aKjE is CompositeCurve compositeCurve)
			{
				List<Point3D> list = new List<Point3D>();
				for (int i = 0; i < compositeCurve.CurveList.Count; i++)
				{
					Point3D[] array = _0023_003DzHgehaXbXsoae65o_R1WkC5o_003D(compositeCurve.CurveList[i]);
					if (i < compositeCurve.CurveList.Count - 1 || compositeCurve.IsClosed)
					{
						list.AddRange(array.Take(array.Length - 1));
					}
					else
					{
						list.AddRange(array);
					}
				}
				return list.ToArray();
			}
			if (_0023_003Dz8fpRyMu9aKjE is Circle || _0023_003Dz8fpRyMu9aKjE is Ellipse)
			{
				Curve nurbsForm;
				using (new _0023_003DzspExml1j72mr_FI04NKW780_003D())
				{
					nurbsForm = _0023_003Dz8fpRyMu9aKjE.GetNurbsForm();
				}
				return _0023_003DzfHSvFLY_003D(nurbsForm);
			}
			return _0023_003DzfHSvFLY_003D(_0023_003Dz8fpRyMu9aKjE.GetNurbsForm());
		}
		return vertices;
	}

	private static Point3D[] _0023_003DzfHSvFLY_003D(Curve _0023_003DzzmfUkNI_003D)
	{
		Point3D[] array = new Point3D[_0023_003DzzmfUkNI_003D._0023_003DzMv2C5Tm1QMvc()];
		for (int i = 0; i < _0023_003DzzmfUkNI_003D._0023_003DzMv2C5Tm1QMvc(); i++)
		{
			array[i] = _0023_003DzzmfUkNI_003D.Pw[i].Euclid;
		}
		return array;
	}

	public static LinearPath ConvexHull2D(IList<Point2D> points)
	{
		Point2D[] array = ConvexHull2D(points, sorted: true);
		if (array == null)
		{
			return null;
		}
		return new LinearPath(Plane.XY, array);
	}

	public static float[] ConvexHull2D(IList<float> pointsCoords)
	{
		List<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8> list = new List<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8>(pointsCoords.Count);
		for (int i = 0; i < pointsCoords.Count / 3; i += 3)
		{
			list.Add(new _0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8
			{
				Position = new double[2]
				{
					pointsCoords[i],
					pointsCoords[i + 1]
				},
				_0023_003DzVRJBdwP4f05YIEyr2g_003D_003D = i / 3
			});
		}
		ConvexHullCreationResult<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8, DefaultConvexFace<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8>> convexHullCreationResult = MIConvexHull.ConvexHull.Create<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8, DefaultConvexFace<_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8>>(list);
		list.Clear();
		if (convexHullCreationResult.Result != null)
		{
			_0023_003DzFFGua3Bs5uaFcBDrAEqz0uXeGfv8[] array = convexHullCreationResult.Result.Points.ToArray();
			int num = array.Count();
			float[] array2 = new float[num];
			for (int j = 0; j < num; j++)
			{
				array2[j * 3] = pointsCoords[array[j]._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D * 3];
				array2[j * 3 + 1] = pointsCoords[array[j]._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D * 3 + 1];
				array2[j * 3 + 2] = pointsCoords[array[j]._0023_003DzVRJBdwP4f05YIEyr2g_003D_003D * 3 + 2];
			}
			return array2.ToArray();
		}
		return null;
	}

	internal static bool _0023_003DzPXJymPlOuaUh(Surface _0023_003DzAI_Szwk_003D)
	{
		if (_0023_003DzAI_Szwk_003D._0023_003DzB68dg9Q_003D <= 1)
		{
			return _0023_003DzAI_Szwk_003D.q > 1;
		}
		return true;
	}

	public static bool IsLine(ICurve itfCurve)
	{
		if (itfCurve is Line)
		{
			return true;
		}
		if (itfCurve is Curve && ((Curve)itfCurve).IsLine)
		{
			return true;
		}
		return false;
	}

	internal static bool _0023_003Dzci5nLHpbsxCiqme1Bg_003D_003D(Plane _0023_003Dzpyw2kZk_003D, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, Surface _0023_003Dz_0024KKopL9T7nzT, out double _0023_003Dz6pajdGM_003D)
	{
		_0023_003Dz6pajdGM_003D = 0.0;
		if (_0023_003DzRTbTK_0024KwG32W == null)
		{
			return false;
		}
		for (int i = 0; i < 4; i++)
		{
			bool flag = false;
			foreach (ICurve item in _0023_003DzRTbTK_0024KwG32W)
			{
				ICurve[] individualCurves = item.GetIndividualCurves();
				for (int j = 0; j < individualCurves.Length; j++)
				{
					if (RevolvedSurface._0023_003DzEePbTg3jDjyLcUHYsuGBkXc_003D(individualCurves[j], _0023_003Dz6pajdGM_003D, _0023_003Dzpyw2kZk_003D, _0023_003Dz_0024KKopL9T7nzT))
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
				if (i > 0)
				{
					return true;
				}
				return false;
			}
			_0023_003Dz6pajdGM_003D += Math.PI / 2.0;
		}
		return false;
	}

	internal static bool _0023_003DzeRbwL3dSLSRdPlz0gQ_003D_003D(Plane _0023_003Dzpyw2kZk_003D, Plane _0023_003DzjDNJ3umjT6Lf, IList<ICurve> _0023_003DzRTbTK_0024KwG32W, out double _0023_003Dz6pajdGM_003D)
	{
		_0023_003Dz6pajdGM_003D = 0.0;
		if (_0023_003DzRTbTK_0024KwG32W == null)
		{
			return false;
		}
		for (int i = 0; i < 4; i++)
		{
			bool flag = false;
			foreach (ICurve item in _0023_003DzRTbTK_0024KwG32W)
			{
				ICurve[] individualCurves = item.GetIndividualCurves();
				foreach (ICurve _0023_003Dz8fpRyMu9aKjE in individualCurves)
				{
					if (RevolvedSurface._0023_003Dzn1ibPKOvoEFIUB0PQGYsJtA_003D(_0023_003Dzpyw2kZk_003D, _0023_003DzjDNJ3umjT6Lf, _0023_003Dz8fpRyMu9aKjE, _0023_003Dz6pajdGM_003D))
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
				if (i > 0)
				{
					return true;
				}
				return false;
			}
			_0023_003Dz6pajdGM_003D += Math.PI / 2.0;
		}
		return false;
	}

	internal static Arc _0023_003DzCVWMRix_XDAPR23xLg_003D_003D(Arc _0023_003DzHL3Pz2A_003D, out double _0023_003Dz6pajdGM_003D)
	{
		if (!_0023_003DzHL3Pz2A_003D.IsCircle)
		{
			Arc arc = (Arc)_0023_003DzHL3Pz2A_003D.Clone();
			_0023_003Dz6pajdGM_003D = Math.PI - arc.Domain.Mid;
			arc.Rotate(_0023_003Dz6pajdGM_003D, arc.Plane.AxisZ, arc.Plane.Origin);
		}
		_0023_003Dz6pajdGM_003D = 0.0;
		return null;
	}

	public static Mesh Triangulate(IList<Point3D> outerLoop, IList<IList<Point3D>> innerLoops, IList<Point3D> points, IList<Segment3D> segments)
	{
		if (outerLoop == null)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653251), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661214));
		}
		if (outerLoop.Count < 4)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661191), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661151));
		}
		_0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003DzFaMCED8PjsukeIy29w_003D_003D2 = new _0023_003DzFaMCED8PjsukeIy29w_003D_003D();
		_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D[] array = new _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D[outerLoop.Count - 1];
		int num = 0;
		for (int i = 0; i < outerLoop.Count - 1; i++)
		{
			Point3D point3D = outerLoop[i];
			array[i] = new _0023_003DzrDktkTxLXKA_0024(point3D.X, point3D.Y, point3D.Z);
		}
		_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzoQHfNE_0024SNkrCHT7oLg_003D_003D(array, num, _0023_003DzpclmpXl2mAVN: false, IsPolygonConvex(outerLoop));
		if (innerLoops != null)
		{
			foreach (IList<Point3D> innerLoop in innerLoops)
			{
				array = new _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D[innerLoop.Count - 1];
				for (int j = 0; j < innerLoop.Count - 1; j++)
				{
					Point3D point3D2 = innerLoop[j];
					array[j] = new _0023_003DzrDktkTxLXKA_0024(point3D2.X, point3D2.Y, point3D2.Z);
				}
				num++;
				_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzoQHfNE_0024SNkrCHT7oLg_003D_003D(array, num, _0023_003DzpclmpXl2mAVN: true, IsPolygonConvex(innerLoop));
			}
		}
		if (points != null)
		{
			for (int k = 0; k < points.Count; k++)
			{
				Point3D point3D3 = points[k];
				_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Add(new _0023_003DzrDktkTxLXKA_0024(point3D3.X, point3D3.Y, point3D3.Z));
			}
		}
		if (segments != null)
		{
			for (int l = 0; l < segments.Count; l++)
			{
				Point3D p = segments[l].P0;
				Point3D p2 = segments[l].P1;
				int count = _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Count;
				_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Add(new _0023_003DzrDktkTxLXKA_0024(p.X, p.Y, p.Z));
				int count2 = _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Count;
				_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Add(new _0023_003DzrDktkTxLXKA_0024(p2.X, p2.Y, p2.Z));
				_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzDugehDLz2Pg5().Add(new _0023_003Dz6aZVluM0HoQZHUo9pw_003D_003D(_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL()[count], _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL()[count2]));
			}
		}
		if (_0023_003DzSo_0024hId75EgH2Tq2_LlOiSGU_003D(out var _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out var _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzFaMCED8PjsukeIy29w_003D_003D2, out var _, null, null))
		{
			Point3D[] array2 = new Point3D[_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length];
			if (_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[0] is Point3D)
			{
				for (int m = 0; m < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length; m++)
				{
					array2[m] = (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[m];
				}
			}
			else
			{
				for (int n = 0; n < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length; n++)
				{
					array2[n] = new Point3D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[n].X, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[n].Y);
				}
			}
			return new Mesh(array2, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D);
		}
		return null;
	}

	public static bool Triangulate(IList<Point2D> outerLoop, IList<IList<Point2D>> innerLoops, bool fixOrientation, bool checkValidity, out Point2D[] vertices, out IndexTriangle[] triangles)
	{
		if (outerLoop == null)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653251), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661132));
		}
		if (outerLoop.Count < 4)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661191), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661365));
		}
		if (fixOrientation)
		{
			CheckDir(outerLoop, innerLoops);
		}
		if (checkValidity)
		{
			vertices = null;
			triangles = null;
			if (IsPolygonSelfIntersecting(outerLoop))
			{
				return false;
			}
			if (_0023_003DzrMzWdbPiOvrR(outerLoop.Take(outerLoop.Count - 1).ToArray()))
			{
				return false;
			}
			if (_0023_003DzX9fhVAvIb_UH(outerLoop))
			{
				return false;
			}
		}
		_0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003DzFaMCED8PjsukeIy29w_003D_003D2 = new _0023_003DzFaMCED8PjsukeIy29w_003D_003D(outerLoop.Count, _0023_003DzleEQ0oAjXGue: true);
		int num = 1;
		_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzPJNpNF4_003D(_0023_003DzQC4L9wrM0I36yqsmzUEV4zNJ6OMtrI8VCQ_003D_003D(outerLoop, num, null));
		if (innerLoops != null)
		{
			foreach (IList<Point2D> innerLoop in innerLoops)
			{
				num++;
				_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzPJNpNF4_003D(_0023_003DzQC4L9wrM0I36yqsmzUEV4zNJ6OMtrI8VCQ_003D_003D(innerLoop, num, null), _0023_003DzpclmpXl2mAVN: true);
			}
		}
		_0023_003DzBtMRswEpRHvk5E9N8_ROkUGHcFKD _0023_003DzH2EAWg0_003D;
		return _0023_003DzSo_0024hId75EgH2Tq2_LlOiSGU_003D(out vertices, out triangles, _0023_003DzFaMCED8PjsukeIy29w_003D_003D2, out _0023_003DzH2EAWg0_003D, null, null);
	}

	private static bool _0023_003DzrMzWdbPiOvrR(IList<Point2D> _0023_003DzN57VxTE7ZsCw)
	{
		Point2D[] array = _0023_003DzN57VxTE7ZsCw.Take(_0023_003DzN57VxTE7ZsCw.Count - 1).ToArray();
		if (new HashSet<Point2D>(array).Count != array.Length)
		{
			return true;
		}
		return false;
	}

	private static bool _0023_003DzX9fhVAvIb_UH(IList<Point2D> _0023_003DzN57VxTE7ZsCw)
	{
		Vector2D vector2D = new Vector2D(_0023_003DzN57VxTE7ZsCw[0], _0023_003DzN57VxTE7ZsCw[1]);
		vector2D.Normalize();
		for (int i = 0; i < _0023_003DzN57VxTE7ZsCw.Count - 2; i++)
		{
			Vector2D vector2D2 = new Vector2D(_0023_003DzN57VxTE7ZsCw[i + 1], _0023_003DzN57VxTE7ZsCw[i + 2]);
			vector2D2.Normalize();
			if (Vector2D.AngleBetween(vector2D, vector2D2) > 3.141492653589793)
			{
				return true;
			}
			vector2D = (Vector2D)vector2D2.Clone();
		}
		return false;
	}

	[Obsolete("Deprecated method: use the PlaneMesher class instead.")]
	public static Mesh Triangulate(devDept.Eyeshot.Entities.Region region, double elementSize, int smoothingPasses = 10, IList<LinearPath> hardEdges = null)
	{
		Point3D[] pointsByLengthPerSegment = region.ContourList[0].GetPointsByLengthPerSegment(elementSize);
		Point3D[][] array = null;
		if (region.HasHoles)
		{
			int count = region.ContourList.Count;
			array = new Point3D[count - 1][];
			for (int i = 1; i < count; i++)
			{
				array[i - 1] = region.ContourList[i].GetPointsByLengthPerSegment(elementSize);
			}
		}
		_0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003DzFaMCED8PjsukeIy29w_003D_003D2 = new _0023_003DzFaMCED8PjsukeIy29w_003D_003D(pointsByLengthPerSegment.Length, _0023_003DzleEQ0oAjXGue: true);
		int num = 1;
		_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzPJNpNF4_003D(_0023_003DzQC4L9wrM0I36yqsmzUEV4zNJ6OMtrI8VCQ_003D_003D(pointsByLengthPerSegment, num, region.Plane));
		if (array != null)
		{
			Point3D[][] array2 = array;
			foreach (IList<Point3D> list in array2)
			{
				num++;
				_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzPJNpNF4_003D(_0023_003DzQC4L9wrM0I36yqsmzUEV4zNJ6OMtrI8VCQ_003D_003D((IList<Point2D>)list, num, region.Plane), _0023_003DzpclmpXl2mAVN: true);
			}
		}
		_0023_003Dzwg3BDYTjt0_Pnf4ojhXAPRpAh0CM obj = new _0023_003Dzwg3BDYTjt0_Pnf4ojhXAPRpAh0CM();
		obj._0023_003DzUWOWFn2eJiJx(2);
		obj._0023_003DzKEviZKBCKAT1tG8_0024zNAFHSf8_HeXqjzq1A_003D_003D(_0023_003DzPzO_0024GUk_003D: true);
		_0023_003Dzwg3BDYTjt0_Pnf4ojhXAPRpAh0CM _0023_003DzdNx9MH0_003D = obj;
		_0023_003Dzny1QiGTNYMVEqxpmzhDfFL6sinoG _0023_003Dzny1QiGTNYMVEqxpmzhDfFL6sinoG2 = new _0023_003Dzny1QiGTNYMVEqxpmzhDfFL6sinoG();
		if (hardEdges != null)
		{
			foreach (LinearPath hardEdge in hardEdges)
			{
				num++;
				if (hardEdge.IsClosed)
				{
					_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzPJNpNF4_003D(_0023_003DzQC4L9wrM0I36yqsmzUEV4zNJ6OMtrI8VCQ_003D_003D(hardEdge.Vertices, num, region.Plane));
					continue;
				}
				int num2 = hardEdge.Vertices.Length;
				Point3D point3D = hardEdge.Vertices[0];
				int num3 = _0023_003DzMTRHRj8e_0024_gh(_0023_003DzFaMCED8PjsukeIy29w_003D_003D2, point3D);
				if (num3 == -1)
				{
					num3 = _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Count;
					_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Add(new _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D(point3D.X, point3D.Y, num));
				}
				for (int k = 1; k < num2; k++)
				{
					point3D = hardEdge.Vertices[k];
					int num4;
					if (k < num2 - 1)
					{
						num4 = _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Count;
						_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Add(new _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D(point3D.X, point3D.Y, num));
					}
					else
					{
						num4 = _0023_003DzMTRHRj8e_0024_gh(_0023_003DzFaMCED8PjsukeIy29w_003D_003D2, point3D);
						if (num4 == -1)
						{
							num4 = _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Count;
							_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Add(new _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D(point3D.X, point3D.Y, num));
						}
					}
					_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzDugehDLz2Pg5().Add(new _0023_003Dz6aZVluM0HoQZHUo9pw_003D_003D(_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL()[num3], _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL()[num4], num));
					num3 = num4;
				}
			}
		}
		double num5 = 1.7320508075688772 * elementSize * elementSize / 4.0;
		_0023_003Dzny1QiGTNYMVEqxpmzhDfFL6sinoG2._0023_003DzQVPyw7rkOoIJ(2.0 * num5);
		_0023_003Dzny1QiGTNYMVEqxpmzhDfFL6sinoG2._0023_003Dz5Gco_0024AAkXvX9(33.8);
		int count2 = _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Count;
		try
		{
			_0023_003DziQV1ad2pQ48G _0023_003DziQV1ad2pQ48G2 = (_0023_003DziQV1ad2pQ48G)_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003Dz5bTQ1u9UVidehQ86Hw_003D_003D(_0023_003DzdNx9MH0_003D, _0023_003Dzny1QiGTNYMVEqxpmzhDfFL6sinoG2);
			if (hardEdges == null)
			{
				((_0023_003DzlqaxOZ33s7_0024vD_TxfkOkj_JCK8_0024LJRW_I97hrfw_003D)new _0023_003Dz7HUxBg1zsMeRaP20zYjjrGkExWf9J6K_0024Pm_fZSU_003D())._0023_003Dzy9tytiY8GrO9((_0023_003DzBtMRswEpRHvk5E9N8_ROkUGHcFKD)_0023_003DziQV1ad2pQ48G2, smoothingPasses, (IProgress<double>)null);
			}
			int num6 = 0;
			Point3D[] array3 = new Point3D[_0023_003DziQV1ad2pQ48G2._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D().Count];
			foreach (_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D item in _0023_003DziQV1ad2pQ48G2._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D())
			{
				array3[num6++] = region.Plane.PointAt(item._0023_003DzR216mFc_003D(), item._0023_003DzqJqZpJk_003D());
			}
			num6 = 0;
			IndexTriangle[] array4 = new IndexTriangle[_0023_003DziQV1ad2pQ48G2._0023_003DzPvyA_tju2mOECWmhiQ_003D_003D().Count];
			foreach (_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D item2 in _0023_003DziQV1ad2pQ48G2._0023_003DzPvyA_tju2mOECWmhiQ_003D_003D())
			{
				array4[num6++] = new IndexTriangle(item2._0023_003DzBYFHRMc_fmcG(0), item2._0023_003DzBYFHRMc_fmcG(1), item2._0023_003DzBYFHRMc_fmcG(2));
			}
			if (hardEdges != null)
			{
				Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D = array3;
				_0023_003DzuUqGvvsHKivEIx6YuUoQZy0_003D(smoothingPasses, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, array4, count2);
			}
			return new Mesh(array3, array4);
		}
		catch (Exception)
		{
			return null;
		}
	}

	internal static void _0023_003DzuUqGvvsHKivEIx6YuUoQZy0_003D(int _0023_003DzwbwFbPlWeInfxtwFgQ_003D_003D, Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, int _0023_003DzNGTZiGn8rjy_)
	{
		LinkedList<IndexTriangle>[] array = new LinkedList<IndexTriangle>[_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new LinkedList<IndexTriangle>();
		}
		foreach (IndexTriangle indexTriangle in _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
		{
			array[indexTriangle.V1].AddLast(indexTriangle);
			array[indexTriangle.V2].AddLast(indexTriangle);
			array[indexTriangle.V3].AddLast(indexTriangle);
		}
		for (int k = 0; k < _0023_003DzwbwFbPlWeInfxtwFgQ_003D_003D; k++)
		{
			for (int l = _0023_003DzNGTZiGn8rjy_; l < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length; l++)
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				foreach (IndexTriangle item in array[l])
				{
					Point2D point2D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[item.V1];
					Point2D point2D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[item.V2];
					Point2D point2D3 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[item.V3];
					num += (point2D.X + point2D2.X + point2D3.X) / 3.0;
					num2 += (point2D.Y + point2D2.Y + point2D3.Y) / 3.0;
					num3 += 1.0;
				}
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[l].X = num / num3;
				_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[l].Y = num2 / num3;
			}
		}
	}

	internal static _0023_003DzgXtZ7nL_0024GY_0024qIlUDKKkKq2M_003D _0023_003DzQC4L9wrM0I36yqsmzUEV4zNJ6OMtrI8VCQ_003D_003D(IList<Point2D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003DzE8L7Q4w_003D, Plane _0023_003Dzpyw2kZk_003D)
	{
		_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D[] array = new _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D[_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count - 1];
		bool _0023_003DzvxU96L_71I8e = _0023_003DzF2vQuITUGX5vz3Bzmw_003D_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzE8L7Q4w_003D, _0023_003Dzpyw2kZk_003D, array);
		return new _0023_003DzgXtZ7nL_0024GY_0024qIlUDKKkKq2M_003D(array, _0023_003DzE8L7Q4w_003D, _0023_003DzvxU96L_71I8e);
	}

	private static bool _0023_003DzF2vQuITUGX5vz3Bzmw_003D_003D(IList<Point2D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003DzE8L7Q4w_003D, Plane _0023_003Dzpyw2kZk_003D, _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D[] _0023_003DzZ86NWzV6mlAE)
	{
		int count = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count;
		if (_0023_003Dzpyw2kZk_003D != null)
		{
			Point2D[] array = new Point2D[count];
			for (int i = 0; i < count - 1; i++)
			{
				Point2D point2D = (array[i] = _0023_003Dzpyw2kZk_003D.Project((Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]));
				_0023_003DzZ86NWzV6mlAE[i] = new _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D(point2D.X, point2D.Y, _0023_003DzE8L7Q4w_003D);
			}
			array[count - 1] = _0023_003Dzpyw2kZk_003D.Project((Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[count - 1]);
			return IsPolygonConvex(array);
		}
		for (int j = 0; j < count - 1; j++)
		{
			Point2D point2D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[j];
			_0023_003DzZ86NWzV6mlAE[j] = new _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D(point2D2.X, point2D2.Y, _0023_003DzE8L7Q4w_003D);
		}
		return IsPolygonConvex(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
	}

	private static int _0023_003DzMTRHRj8e_0024_gh(_0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003Dzouia0WU_003D, Point3D _0023_003DzMlCq3wk_003D)
	{
		for (int i = 0; i < _0023_003Dzouia0WU_003D._0023_003DzYNux6PWoz6TL().Count; i++)
		{
			_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D2 = _0023_003Dzouia0WU_003D._0023_003DzYNux6PWoz6TL()[i];
			if (Compare(_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D2._0023_003DzR216mFc_003D(), _0023_003DzMlCq3wk_003D.X) == 0 && Compare(_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D2._0023_003DzqJqZpJk_003D(), _0023_003DzMlCq3wk_003D.Y) == 0)
			{
				return i;
			}
		}
		return -1;
	}

	public static Mesh Triangulate(IList<Point3D> points, Mesh.natureType nature = Mesh.natureType.Plain)
	{
		_0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003DzFaMCED8PjsukeIy29w_003D_003D2 = new _0023_003DzFaMCED8PjsukeIy29w_003D_003D();
		_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Capacity = points.Count;
		foreach (Point3D point in points)
		{
			_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzYNux6PWoz6TL().Add(new _0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D(point.X, point.Y));
		}
		try
		{
			_0023_003DzBtMRswEpRHvk5E9N8_ROkUGHcFKD _0023_003DzBtMRswEpRHvk5E9N8_ROkUGHcFKD2 = _0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003Dz5bTQ1u9UVidehQ86Hw_003D_003D();
			IndexTriangle[] array = new IndexTriangle[_0023_003DzBtMRswEpRHvk5E9N8_ROkUGHcFKD2._0023_003DzPvyA_tju2mOECWmhiQ_003D_003D().Count];
			int num = 0;
			if (nature - 5 <= Mesh.natureType.ColorPlain)
			{
				foreach (_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D item in _0023_003DzBtMRswEpRHvk5E9N8_ROkUGHcFKD2._0023_003DzPvyA_tju2mOECWmhiQ_003D_003D())
				{
					array[num++] = new SmoothTriangle(item._0023_003DzBYFHRMc_fmcG(0), item._0023_003DzBYFHRMc_fmcG(1), item._0023_003DzBYFHRMc_fmcG(2));
				}
			}
			else
			{
				foreach (_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D item2 in _0023_003DzBtMRswEpRHvk5E9N8_ROkUGHcFKD2._0023_003DzPvyA_tju2mOECWmhiQ_003D_003D())
				{
					array[num++] = new IndexTriangle(item2._0023_003DzBYFHRMc_fmcG(0), item2._0023_003DzBYFHRMc_fmcG(1), item2._0023_003DzBYFHRMc_fmcG(2));
				}
			}
			return new Mesh(points.ToArray(), array);
		}
		catch
		{
			return null;
		}
	}

	internal static bool _0023_003DzSo_0024hId75EgH2Tq2_LlOiSGU_003D(out Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003Dzouia0WU_003D, out _0023_003DzBtMRswEpRHvk5E9N8_ROkUGHcFKD _0023_003DzH2EAWg0_003D, _0023_003Dzny1QiGTNYMVEqxpmzhDfFL6sinoG _0023_003DzJ0pFDSI_003D, _0023_003Dzwg3BDYTjt0_Pnf4ojhXAPRpAh0CM _0023_003DzTixQXR4_003D)
	{
		if (_0023_003DzTixQXR4_003D == null)
		{
			_0023_003Dzwg3BDYTjt0_Pnf4ojhXAPRpAh0CM obj = new _0023_003Dzwg3BDYTjt0_Pnf4ojhXAPRpAh0CM();
			obj._0023_003DzUWOWFn2eJiJx(2);
			obj._0023_003DzKEviZKBCKAT1tG8_0024zNAFHSf8_HeXqjzq1A_003D_003D(_0023_003DzPzO_0024GUk_003D: true);
			_0023_003DzTixQXR4_003D = obj;
		}
		_0023_003DzH2EAWg0_003D = null;
		try
		{
			_0023_003DzH2EAWg0_003D = _0023_003Dz9alFDr7ondkUKPvIirM55eI_003D(_0023_003Dzouia0WU_003D, _0023_003DzTixQXR4_003D, _0023_003DzJ0pFDSI_003D);
			_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = new IndexTriangle[_0023_003DzH2EAWg0_003D._0023_003DzPvyA_tju2mOECWmhiQ_003D_003D().Count];
			int num = 0;
			foreach (_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D item in _0023_003DzH2EAWg0_003D._0023_003DzPvyA_tju2mOECWmhiQ_003D_003D())
			{
				_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[num++] = new IndexTriangle(item._0023_003DzBYFHRMc_fmcG(0), item._0023_003DzBYFHRMc_fmcG(1), item._0023_003DzBYFHRMc_fmcG(2));
			}
			num = 0;
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new Point2D[_0023_003DzH2EAWg0_003D._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D().Count];
			if (_0023_003DzH2EAWg0_003D._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D().First() is _0023_003DzrDktkTxLXKA_0024)
			{
				foreach (_0023_003DzrDktkTxLXKA_0024 item2 in _0023_003DzH2EAWg0_003D._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D())
				{
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num++] = new Point3D(item2._0023_003DzR216mFc_003D(), item2._0023_003DzqJqZpJk_003D(), item2._0023_003Dz8wjMonY_003D);
				}
			}
			else
			{
				foreach (_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D item3 in _0023_003DzH2EAWg0_003D._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D())
				{
					_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num++] = new Point2D(item3._0023_003DzR216mFc_003D(), item3._0023_003DzqJqZpJk_003D());
				}
			}
		}
		catch
		{
			_0023_003Dzk98RESByZO6KwZuGTA_003D_003D = new Point2D[0];
			_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = new IndexTriangle[0];
			return false;
		}
		return true;
	}

	internal static _0023_003DzBtMRswEpRHvk5E9N8_ROkUGHcFKD _0023_003Dz9alFDr7ondkUKPvIirM55eI_003D(_0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003Dzouia0WU_003D, _0023_003Dzwg3BDYTjt0_Pnf4ojhXAPRpAh0CM _0023_003DzTixQXR4_003D, _0023_003Dzny1QiGTNYMVEqxpmzhDfFL6sinoG _0023_003DzJ0pFDSI_003D)
	{
		_0023_003Dzl1OlBiRLsfSNb_CysYoiFP4_003D CS_0024_003C_003E8__locals4 = new _0023_003Dzl1OlBiRLsfSNb_CysYoiFP4_003D();
		CS_0024_003C_003E8__locals4._0023_003DzUFpglTk_003D = new _0023_003DzGZh8_0024BDFfDuikVamog_003D_003D();
		CS_0024_003C_003E8__locals4._0023_003Dzijt6ZVq8pKeJ00reCQ_003D_003D = new _0023_003DzAxDX21mgNPt_0024ivyAT9VKDgo_003D();
		_0023_003DzJef6AZ2mSitL obj = new _0023_003DzJef6AZ2mSitL();
		obj._0023_003DzWKMWcDk1CKRY(() => CS_0024_003C_003E8__locals4._0023_003Dzijt6ZVq8pKeJ00reCQ_003D_003D);
		obj._0023_003DzuhvJeoXqwWjO(() => CS_0024_003C_003E8__locals4._0023_003DzUFpglTk_003D._0023_003Dz_0024SpdFwY_003D());
		return new _0023_003DzF9lWOmzsN60dmaEN6X_FVKPNbDNrYC9E2A_003D_003D(obj)._0023_003Dz5bTQ1u9UVidehQ86Hw_003D_003D(_0023_003Dzouia0WU_003D, _0023_003DzTixQXR4_003D, _0023_003DzJ0pFDSI_003D);
	}

	internal static bool _0023_003DzG8r7N_0024gcHhrIOyP09w_003D_003D(IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> _0023_003DzBZc7VVG5asYu, IList<IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D>> _0023_003DzxZtQCI37epAc, bool _0023_003Dz275RophIENHO, out Point2D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
	{
		List<Point2D> list = new List<Point2D>();
		_0023_003DzFaMCED8PjsukeIy29w_003D_003D _0023_003DzFaMCED8PjsukeIy29w_003D_003D2 = new _0023_003DzFaMCED8PjsukeIy29w_003D_003D(_0023_003DzBZc7VVG5asYu.Count, _0023_003DzleEQ0oAjXGue: true);
		_0023_003DzrDktkTxLXKA_0024[] array = new _0023_003DzrDktkTxLXKA_0024[_0023_003DzBZc7VVG5asYu.Count - 1];
		int num = 1;
		for (int i = 0; i < _0023_003DzBZc7VVG5asYu.Count - 1; i++)
		{
			Point2D _0023_003DzIHt45I8_003D = _0023_003DzBZc7VVG5asYu[i]._0023_003DzIHt45I8_003D;
			list.Add(_0023_003DzIHt45I8_003D);
			array[i] = new _0023_003DzrDktkTxLXKA_0024(_0023_003DzIHt45I8_003D.X, _0023_003DzIHt45I8_003D.Y, _0023_003DzBZc7VVG5asYu[i]._0023_003DzyzK8swU_003D);
		}
		list.Add(_0023_003DzBZc7VVG5asYu[0]._0023_003DzIHt45I8_003D);
		_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzoQHfNE_0024SNkrCHT7oLg_003D_003D(array, num, _0023_003DzpclmpXl2mAVN: false, IsPolygonConvex(list));
		if (_0023_003DzxZtQCI37epAc != null)
		{
			foreach (IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D> item in _0023_003DzxZtQCI37epAc)
			{
				array = new _0023_003DzrDktkTxLXKA_0024[item.Count - 1];
				list = new List<Point2D>();
				for (int j = 0; j < item.Count - 1; j++)
				{
					Point2D _0023_003DzIHt45I8_003D2 = item[j]._0023_003DzIHt45I8_003D;
					list.Add(_0023_003DzIHt45I8_003D2);
					array[j] = new _0023_003DzrDktkTxLXKA_0024(_0023_003DzIHt45I8_003D2.X, _0023_003DzIHt45I8_003D2.Y, item[j]._0023_003DzyzK8swU_003D);
				}
				list.Add(item[0]._0023_003DzIHt45I8_003D);
				num++;
				_0023_003DzFaMCED8PjsukeIy29w_003D_003D2._0023_003DzoQHfNE_0024SNkrCHT7oLg_003D_003D(array, num, _0023_003DzpclmpXl2mAVN: true, IsPolygonConvex(list));
			}
		}
		_0023_003DzBtMRswEpRHvk5E9N8_ROkUGHcFKD _0023_003DzH2EAWg0_003D;
		bool result = _0023_003DzSo_0024hId75EgH2Tq2_LlOiSGU_003D(out _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzFaMCED8PjsukeIy29w_003D_003D2, out _0023_003DzH2EAWg0_003D, null, null);
		_0023_003Dzs2pGYRHYf_0024Yyb009_Q_003D_003D[] array2 = _0023_003DzH2EAWg0_003D._0023_003DzuSc2g6MGhoLvwL3__0024w_003D_003D().ToArray();
		int num2 = 0;
		foreach (_0023_003DzrFSevYmtHQTnxAoc9Q_003D_003D item2 in _0023_003DzH2EAWg0_003D._0023_003DzPvyA_tju2mOECWmhiQ_003D_003D())
		{
			int _0023_003DzyzK8swU_003D = ((_0023_003DzrDktkTxLXKA_0024)array2[item2._0023_003DzBYFHRMc_fmcG(0)])._0023_003DzyzK8swU_003D;
			int _0023_003DzyzK8swU_003D2 = ((_0023_003DzrDktkTxLXKA_0024)array2[item2._0023_003DzBYFHRMc_fmcG(1)])._0023_003DzyzK8swU_003D;
			int _0023_003DzyzK8swU_003D3 = ((_0023_003DzrDktkTxLXKA_0024)array2[item2._0023_003DzBYFHRMc_fmcG(2)])._0023_003DzyzK8swU_003D;
			_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[num2++] = new IndexTriangle(_0023_003DzyzK8swU_003D, _0023_003DzyzK8swU_003D2, _0023_003DzyzK8swU_003D3);
		}
		return result;
	}

	public static bool DoOverlapOrTouch(Mesh first, Mesh second)
	{
		List<Point3D> _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D;
		return _0023_003DzGs4E7IuAJGux3fHv_Q_003D_003D(first, second, _0023_003Dz459_0024dvasvvb3: true, out _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D);
	}

	public static bool DoOverlapOrTouch(Mesh first, Mesh second, out List<Point3D> intersectionPoints)
	{
		return _0023_003DzGs4E7IuAJGux3fHv_Q_003D_003D(first, second, _0023_003Dz459_0024dvasvvb3: true, out intersectionPoints);
	}

	public static bool DoOverlap(Mesh first, Mesh second)
	{
		List<Point3D> _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D;
		return _0023_003DzGs4E7IuAJGux3fHv_Q_003D_003D(first, second, _0023_003Dz459_0024dvasvvb3: false, out _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D);
	}

	internal static bool _0023_003DzGs4E7IuAJGux3fHv_Q_003D_003D(Mesh _0023_003DzRVoDPs0_003D, Mesh _0023_003Dz_0024ozI2Ww_003D, bool _0023_003Dz459_0024dvasvvb3, out List<Point3D> _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D)
	{
		_0023_003DzRVoDPs0_003D.UpdateBoundingBox(null);
		_0023_003Dz_0024ozI2Ww_003D.UpdateBoundingBox(null);
		double _0023_003Dzm0CYiiE_003D = _0023_003DzRVoDPs0_003D.BoxSize.Diagonal * _0023_003DzxhnLabVjXjPg;
		double _0023_003Dzm0CYiiE_003D2 = _0023_003Dz_0024ozI2Ww_003D.BoxSize.Diagonal * _0023_003DzxhnLabVjXjPg;
		_0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D = new List<Point3D>();
		if (!_0023_003DzRVoDPs0_003D._0023_003Dz2rx0bYXAv_0024aP(_0023_003Dzm0CYiiE_003D, out var _) && _0023_003DzRVoDPs0_003D.IsClosed && _0023_003DzEU4MOmd6OOyZoyTIWQ_003D_003D(_0023_003Dz_0024ozI2Ww_003D, _0023_003DzRVoDPs0_003D, ref _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D))
		{
			return true;
		}
		if (!_0023_003Dz_0024ozI2Ww_003D._0023_003Dz2rx0bYXAv_0024aP(_0023_003Dzm0CYiiE_003D2, out var _) && _0023_003Dz_0024ozI2Ww_003D.IsClosed && _0023_003DzEU4MOmd6OOyZoyTIWQ_003D_003D(_0023_003DzRVoDPs0_003D, _0023_003Dz_0024ozI2Ww_003D, ref _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D))
		{
			return true;
		}
		return _0023_003DzGs4E7IuAJGux3fHv_Q_003D_003D(_0023_003DzRVoDPs0_003D.Vertices, _0023_003Dz_0024ozI2Ww_003D.Vertices, _0023_003DzRVoDPs0_003D.Triangles, _0023_003Dz_0024ozI2Ww_003D.Triangles, _0023_003Dz459_0024dvasvvb3, ref _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D);
	}

	internal static bool _0023_003DzEU4MOmd6OOyZoyTIWQ_003D_003D(Mesh _0023_003Dzm9bQX1ehzIK5, Mesh _0023_003DzbHkkNl4_003D, ref List<Point3D> _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D)
	{
		for (int i = 0; i < _0023_003Dzm9bQX1ehzIK5.Vertices.Length; i++)
		{
			if (_0023_003DzbHkkNl4_003D.IsPointInside(_0023_003Dzm9bQX1ehzIK5.Vertices[i]))
			{
				_0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D.Add(_0023_003Dzm9bQX1ehzIK5.Vertices[i]);
				return true;
			}
		}
		return false;
	}

	internal static bool _0023_003DzGBcHaJW_L4SQ(Point3D[] _0023_003Dz5eZPydcKlzr38Ssq0Q_003D_003D, Point3D[] _0023_003DzpbqiYkf6pUgI1dXUuA_003D_003D, IndexTriangle[] _0023_003DzdvhYN4sjyrYxjkKLAA_003D_003D, IndexTriangle[] _0023_003Dzcz9E9eRiFQr9xe_0024P4A_003D_003D)
	{
		List<Point3D> _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D = new List<Point3D>();
		return _0023_003DzGs4E7IuAJGux3fHv_Q_003D_003D(_0023_003Dz5eZPydcKlzr38Ssq0Q_003D_003D, _0023_003DzpbqiYkf6pUgI1dXUuA_003D_003D, _0023_003DzdvhYN4sjyrYxjkKLAA_003D_003D, _0023_003Dzcz9E9eRiFQr9xe_0024P4A_003D_003D, _0023_003DzTfxE2Y3M0gXu: true, ref _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D);
	}

	public static bool DoOverlapOrTouch(Point3D[] verticesF, Point3D[] verticesG, IndexTriangle[] trianglesF, IndexTriangle[] trianglesG, out List<Point3D> intersectionPoints)
	{
		intersectionPoints = new List<Point3D>();
		return _0023_003DzGs4E7IuAJGux3fHv_Q_003D_003D(verticesF, verticesG, trianglesF, trianglesG, _0023_003DzTfxE2Y3M0gXu: true, ref intersectionPoints);
	}

	internal static bool _0023_003DzRGcO5v1wS2S_(Point3D[] _0023_003Dz5eZPydcKlzr38Ssq0Q_003D_003D, Point3D[] _0023_003DzpbqiYkf6pUgI1dXUuA_003D_003D, IndexTriangle[] _0023_003DzdvhYN4sjyrYxjkKLAA_003D_003D, IndexTriangle[] _0023_003Dzcz9E9eRiFQr9xe_0024P4A_003D_003D)
	{
		List<Point3D> _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D = new List<Point3D>();
		return _0023_003DzGs4E7IuAJGux3fHv_Q_003D_003D(_0023_003Dz5eZPydcKlzr38Ssq0Q_003D_003D, _0023_003DzpbqiYkf6pUgI1dXUuA_003D_003D, _0023_003DzdvhYN4sjyrYxjkKLAA_003D_003D, _0023_003Dzcz9E9eRiFQr9xe_0024P4A_003D_003D, _0023_003DzTfxE2Y3M0gXu: false, ref _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D);
	}

	internal static bool _0023_003DzGs4E7IuAJGux3fHv_Q_003D_003D(Point3D[] _0023_003Dz5eZPydcKlzr38Ssq0Q_003D_003D, Point3D[] _0023_003DzpbqiYkf6pUgI1dXUuA_003D_003D, IndexTriangle[] _0023_003DzdvhYN4sjyrYxjkKLAA_003D_003D, IndexTriangle[] _0023_003Dzcz9E9eRiFQr9xe_0024P4A_003D_003D, bool _0023_003DzTfxE2Y3M0gXu, ref List<Point3D> _0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D)
	{
		for (int i = 0; i < _0023_003DzdvhYN4sjyrYxjkKLAA_003D_003D.Length; i++)
		{
			Point3D point3D = _0023_003Dz5eZPydcKlzr38Ssq0Q_003D_003D[_0023_003DzdvhYN4sjyrYxjkKLAA_003D_003D[i].V1];
			Point3D point3D2 = _0023_003Dz5eZPydcKlzr38Ssq0Q_003D_003D[_0023_003DzdvhYN4sjyrYxjkKLAA_003D_003D[i].V2];
			Point3D point3D3 = _0023_003Dz5eZPydcKlzr38Ssq0Q_003D_003D[_0023_003DzdvhYN4sjyrYxjkKLAA_003D_003D[i].V3];
			for (int j = 0; j < _0023_003Dzcz9E9eRiFQr9xe_0024P4A_003D_003D.Length; j++)
			{
				Point3D point3D4 = _0023_003DzpbqiYkf6pUgI1dXUuA_003D_003D[_0023_003Dzcz9E9eRiFQr9xe_0024P4A_003D_003D[j].V1];
				Point3D point3D5 = _0023_003DzpbqiYkf6pUgI1dXUuA_003D_003D[_0023_003Dzcz9E9eRiFQr9xe_0024P4A_003D_003D[j].V2];
				Point3D point3D6 = _0023_003DzpbqiYkf6pUgI1dXUuA_003D_003D[_0023_003Dzcz9E9eRiFQr9xe_0024P4A_003D_003D[j].V3];
				if (TriangleTriangleIntersection(point3D, point3D2, point3D3, point3D4, point3D5, point3D6, out var touch) && (!touch || _0023_003DzTfxE2Y3M0gXu))
				{
					Segment3D segment3D = new Segment3D(point3D, point3D2);
					Segment3D segment3D2 = new Segment3D(point3D2, point3D3);
					Segment3D segment3D3 = new Segment3D(point3D3, point3D);
					Segment3D segment3D4 = new Segment3D(point3D4, point3D5);
					Segment3D segment3D5 = new Segment3D(point3D5, point3D6);
					Segment3D segment3D6 = new Segment3D(point3D6, point3D4);
					if (segment3D.IntersectWith(point3D4, point3D5, point3D6, out var intPoint))
					{
						_0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D.Add(intPoint);
					}
					else if (segment3D2.IntersectWith(point3D4, point3D5, point3D6, out intPoint))
					{
						_0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D.Add(intPoint);
					}
					else if (segment3D3.IntersectWith(point3D4, point3D5, point3D6, out intPoint))
					{
						_0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D.Add(intPoint);
					}
					else if (segment3D4.IntersectWith(point3D, point3D2, point3D3, out intPoint))
					{
						_0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D.Add(intPoint);
					}
					else if (segment3D5.IntersectWith(point3D, point3D2, point3D3, out intPoint))
					{
						_0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D.Add(intPoint);
					}
					else if (segment3D6.IntersectWith(point3D, point3D2, point3D3, out intPoint))
					{
						_0023_003DzJOQpiEG8DvO6yLiPwxFcUtc_003D.Add(intPoint);
					}
					return true;
				}
			}
		}
		return false;
	}

	internal static InterPoint _0023_003DzOwZw6cav8LYtJDODzQ_003D_003D(ICurve _0023_003DzytDpi1c_003D, ICurve _0023_003Dzn8t0_00249E_003D, Point3D _0023_003Dz348XSZM_003D)
	{
		_0023_003DzytDpi1c_003D.ClosestPointTo(_0023_003Dz348XSZM_003D, out var t);
		_0023_003Dzn8t0_00249E_003D.ClosestPointTo(_0023_003Dz348XSZM_003D, out var t2);
		return new InterPoint(_0023_003Dz348XSZM_003D.X, _0023_003Dz348XSZM_003D.Y, _0023_003Dz348XSZM_003D.Z, t, 0.0, t2, 0.0);
	}

	internal static ICurve[] _0023_003DzlrAzqfA8goUU(IList<ICurve> _0023_003Dz06A5WivSSyUp, IList<ICurve> _0023_003Dzwlu1Iddwv6tiO1jJ4w_003D_003D)
	{
		List<ICurve> list = new List<ICurve>();
		for (int i = 0; i < _0023_003Dz06A5WivSSyUp.Count; i++)
		{
			ICurve curve = _0023_003Dz06A5WivSSyUp[i];
			bool flag = false;
			for (int j = i + 1; j < _0023_003Dz06A5WivSSyUp.Count; j++)
			{
				ICurve curve2 = _0023_003Dz06A5WivSSyUp[j];
				if (AreCurvesEqualsOrOpposite(curve, curve2))
				{
					flag = true;
					_0023_003Dzwlu1Iddwv6tiO1jJ4w_003D_003D.Add(curve);
					_0023_003Dzwlu1Iddwv6tiO1jJ4w_003D_003D.Add(curve2);
					break;
				}
			}
			if (!flag)
			{
				list.Add(curve);
			}
		}
		return list.ToArray();
	}

	internal static ICurve[] _0023_003DzCW598inSZMVFMY1xOw_003D_003D(IList<ICurve> _0023_003Dz06A5WivSSyUp, IList<ICurve> _0023_003Dzcqi9uJdsruiIK5geuA_003D_003D)
	{
		bool[] array = new bool[_0023_003Dz06A5WivSSyUp.Count];
		for (int i = 0; i < _0023_003Dz06A5WivSSyUp.Count; i++)
		{
			if (array[i])
			{
				continue;
			}
			ICurve curve = _0023_003Dz06A5WivSSyUp[i];
			for (int j = i + 1; j < _0023_003Dz06A5WivSSyUp.Count; j++)
			{
				if (!array[j])
				{
					ICurve curve2 = _0023_003Dz06A5WivSSyUp[j];
					if (AreCurvesEqualsOrOpposite(curve, curve2, checkOpposite: true))
					{
						array[i] = (array[j] = true);
						_0023_003Dzcqi9uJdsruiIK5geuA_003D_003D.Add(curve);
						_0023_003Dzcqi9uJdsruiIK5geuA_003D_003D.Add(curve2);
						break;
					}
				}
			}
		}
		List<ICurve> list = new List<ICurve>(_0023_003Dz06A5WivSSyUp.Count);
		for (int k = 0; k < _0023_003Dz06A5WivSSyUp.Count; k++)
		{
			if (!array[k])
			{
				list.Add(_0023_003Dz06A5WivSSyUp[k]);
			}
		}
		return list.ToArray();
	}

	public static Point3D[] GetSignificantPointsOnICurve(ICurve contour)
	{
		if (contour is devDept.Eyeshot.Entities.Point)
		{
			return new Point3D[1]
			{
				new Point3D(contour.EndPoint.X, contour.EndPoint.Y, contour.EndPoint.Z)
			};
		}
		if (contour is LinearPath)
		{
			return ((LinearPath)contour).Vertices;
		}
		if (contour is CompositeCurve)
		{
			List<Point3D> list = new List<Point3D>();
			foreach (ICurve curve in ((CompositeCurve)contour).CurveList)
			{
				if (curve is LinearPath)
				{
					list.AddRange(((LinearPath)curve).Vertices);
					list.RemoveAt(list.Count - 1);
				}
				else
				{
					list.Add(curve.StartPoint);
				}
			}
			list.Add(contour.EndPoint);
			return list.ToArray();
		}
		return new Point3D[2] { contour.StartPoint, contour.EndPoint };
	}

	internal static double _0023_003Dz13vJeqF07anV39xM0A_003D_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, Point3D _0023_003DzbUvT9Pc_003D, Point3D _0023_003Dz25mWt0jueIEE, Point3D _0023_003Dzs6eT6En_0024VMSW, Vector3D _0023_003DzNtBaHMY8y5NN)
	{
		double num = double.MaxValue;
		double num2 = 0.0;
		int num3 = 0;
		int num4 = 0;
		for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Length; i++)
		{
			double num5 = Math.Abs(_0023_003Dz25mWt0jueIEE.DistanceTo(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]));
			double num6 = Math.Abs(_0023_003DzbUvT9Pc_003D.DistanceTo(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i]));
			if (num6 < num)
			{
				num = num6;
				num3 = i;
			}
			if (num5 > num2)
			{
				num2 = num5;
				num3 = i;
			}
		}
		double num7 = Math.Max(Math.Abs(_0023_003Dz25mWt0jueIEE.DistanceTo(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num3])), Math.Abs(_0023_003Dz25mWt0jueIEE.DistanceTo(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[num4])));
		Point3D p = _0023_003Dzs6eT6En_0024VMSW + _0023_003DzNtBaHMY8y5NN * num7 * 3.0;
		Vector3D vector3D = new Vector3D(_0023_003DzbUvT9Pc_003D, p);
		Vector3D vector3D2 = new Vector3D(_0023_003DzbUvT9Pc_003D, _0023_003Dzs6eT6En_0024VMSW);
		vector3D.Normalize();
		vector3D2.Normalize();
		return Math.Abs(Vector3D.AngleBetween(vector3D, vector3D2));
	}

	internal static Mesh _0023_003DzqTukDnG3QxvA22yeWQ_003D_003D(Point3D[] _0023_003DzHSbrBYOzQjDgKZ7Yuw_003D_003D, IndexTriangle[] _0023_003DzTw28DqSzkmrRspLiZQ_003D_003D, Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, float _0023_003Dz0ALst1qWgJgu, float _0023_003Dz3ptwfGqkyzBL, float _0023_003Dz8T7D_uh2pyhK, float _0023_003Dz87zvNngD7KQv, float _0023_003DzsTaERoDlh2zJ, Entity _0023_003Dzalvl9z8_003D, Color? _0023_003DzKcASzhgy743Z, bool _0023_003DzTJ4ZjnpzOkzX, string _0023_003Dziwnes6KSa9_00241, Color? _0023_003DzZcz4mT91AgqL)
	{
		if (_0023_003Dzalvl9z8_003D == null || _0023_003Dzalvl9z8_003D.MaterialName == null)
		{
			switch (_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
			{
			case Mesh.natureType.RichPlain:
				_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D = Mesh.natureType.Plain;
				break;
			case Mesh.natureType.RichSmooth:
				_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D = Mesh.natureType.Smooth;
				break;
			}
		}
		Mesh mesh = new Mesh(_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D);
		int num = _0023_003DzHSbrBYOzQjDgKZ7Yuw_003D_003D.Length;
		mesh._vertices = new Point3D[num];
		for (int i = 0; i < num; i++)
		{
			Point3D point3D = _0023_003DzHSbrBYOzQjDgKZ7Yuw_003D_003D[i];
			if (_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D == Mesh.natureType.MulticolorPlain || _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D == Mesh.natureType.MulticolorSmooth)
			{
				mesh._vertices[i] = new PointRGB(point3D.X, point3D.Y, point3D.Z, Color.Beige.R, Color.Beige.G, Color.Beige.B);
			}
			else
			{
				mesh._vertices[i] = new Point3D(point3D.X, point3D.Y, point3D.Z);
			}
		}
		int num2 = _0023_003DzTw28DqSzkmrRspLiZQ_003D_003D.Length;
		mesh.Triangles = new IndexTriangle[num2];
		for (int j = 0; j < num2; j++)
		{
			IndexTriangle indexTriangle = _0023_003DzTw28DqSzkmrRspLiZQ_003D_003D[j];
			switch (_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
			{
			case Mesh.natureType.Plain:
			case Mesh.natureType.MulticolorPlain:
				mesh.Triangles[j] = new IndexTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
				break;
			case Mesh.natureType.ColorPlain:
				if (_0023_003DzKcASzhgy743Z.HasValue)
				{
					mesh.Triangles[j] = new ColorTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, _0023_003DzKcASzhgy743Z.Value.R, _0023_003DzKcASzhgy743Z.Value.G, _0023_003DzKcASzhgy743Z.Value.B);
				}
				else if (_0023_003DzZcz4mT91AgqL.HasValue)
				{
					mesh.Triangles[j] = new ColorTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, _0023_003DzZcz4mT91AgqL.Value.R, _0023_003DzZcz4mT91AgqL.Value.G, _0023_003DzZcz4mT91AgqL.Value.B);
				}
				else if (_0023_003Dzalvl9z8_003D != null && _0023_003Dzalvl9z8_003D.ColorMethod == colorMethodType.byEntity)
				{
					mesh.Triangles[j] = new ColorTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, _0023_003Dzalvl9z8_003D.Color.R, _0023_003Dzalvl9z8_003D.Color.G, _0023_003Dzalvl9z8_003D.Color.B);
				}
				else
				{
					mesh.Triangles[j] = new ColorTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, 0, 0, 0);
				}
				break;
			case Mesh.natureType.RichPlain:
				mesh.Triangles[j] = new RichTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
				break;
			case Mesh.natureType.Smooth:
			case Mesh.natureType.MulticolorSmooth:
				mesh.Triangles[j] = new SmoothTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
				break;
			case Mesh.natureType.ColorSmooth:
				if (_0023_003DzKcASzhgy743Z.HasValue)
				{
					mesh.Triangles[j] = new ColorSmoothTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, _0023_003DzKcASzhgy743Z.Value.R, _0023_003DzKcASzhgy743Z.Value.G, _0023_003DzKcASzhgy743Z.Value.B);
				}
				else if (_0023_003DzZcz4mT91AgqL.HasValue)
				{
					mesh.Triangles[j] = new ColorSmoothTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, _0023_003DzZcz4mT91AgqL.Value.R, _0023_003DzZcz4mT91AgqL.Value.G, _0023_003DzZcz4mT91AgqL.Value.B);
				}
				else if (_0023_003Dzalvl9z8_003D != null && _0023_003Dzalvl9z8_003D.ColorMethod == colorMethodType.byEntity)
				{
					mesh.Triangles[j] = new ColorSmoothTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, _0023_003Dzalvl9z8_003D.Color.R, _0023_003Dzalvl9z8_003D.Color.G, _0023_003Dzalvl9z8_003D.Color.B);
				}
				else
				{
					mesh.Triangles[j] = new ColorSmoothTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, 0, 0, 0);
				}
				break;
			case Mesh.natureType.RichSmooth:
				mesh.Triangles[j] = new RichSmoothTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3, indexTriangle.V1, indexTriangle.V2, indexTriangle.V3);
				break;
			}
		}
		switch (_0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D)
		{
		case Mesh.natureType.Plain:
			mesh.UpdateNormals();
			break;
		case Mesh.natureType.Smooth:
		case Mesh.natureType.ColorSmooth:
		case Mesh.natureType.MulticolorSmooth:
			_0023_003DzgfrCFkMnZEGUQGPf2A_003D_003D(mesh, _0023_003DzHSbrBYOzQjDgKZ7Yuw_003D_003D);
			break;
		case Mesh.natureType.RichSmooth:
			_0023_003DzgfrCFkMnZEGUQGPf2A_003D_003D(mesh, _0023_003DzHSbrBYOzQjDgKZ7Yuw_003D_003D);
			_0023_003DzhkMxsrSGltYeXsfmOA_003D_003D(mesh, _0023_003DzHSbrBYOzQjDgKZ7Yuw_003D_003D, _0023_003Dz0ALst1qWgJgu, _0023_003Dz3ptwfGqkyzBL, _0023_003Dz8T7D_uh2pyhK, _0023_003Dz87zvNngD7KQv, _0023_003DzsTaERoDlh2zJ);
			break;
		case Mesh.natureType.RichPlain:
			mesh.UpdateNormals();
			_0023_003DzhkMxsrSGltYeXsfmOA_003D_003D(mesh, _0023_003DzHSbrBYOzQjDgKZ7Yuw_003D_003D, _0023_003Dz0ALst1qWgJgu, _0023_003Dz3ptwfGqkyzBL, _0023_003Dz8T7D_uh2pyhK, _0023_003Dz87zvNngD7KQv, _0023_003DzsTaERoDlh2zJ);
			break;
		}
		mesh.EdgeStyle = Mesh.edgeStyleType.Free;
		if (!_0023_003DzTJ4ZjnpzOkzX)
		{
			mesh.ComputeEdges();
		}
		if (_0023_003Dzalvl9z8_003D != null)
		{
			mesh.CopyAttributes(_0023_003Dzalvl9z8_003D);
		}
		mesh.UpdateBoundingBox(null);
		mesh.MaterialName = _0023_003Dziwnes6KSa9_00241 ?? mesh.MaterialName;
		mesh.RegenMode = regenType.CompileOnly;
		return mesh;
	}

	private static void _0023_003DzgfrCFkMnZEGUQGPf2A_003D_003D(Mesh _0023_003DzkKfJheA_003D, Point3D[] _0023_003DzD_qPmUr7M9DZBv84BeD63uA_003D)
	{
		int num = _0023_003DzD_qPmUr7M9DZBv84BeD63uA_003D.Length;
		_0023_003DzkKfJheA_003D.Normals = new Vector3D[num];
		for (int i = 0; i < num; i++)
		{
			_0023_003DzkKfJheA_003D.Normals[i] = ((PointNormalUv)_0023_003DzD_qPmUr7M9DZBv84BeD63uA_003D[i]).Normal;
		}
	}

	private static void _0023_003DzhkMxsrSGltYeXsfmOA_003D_003D(Mesh _0023_003DzkKfJheA_003D, Point3D[] _0023_003DzD_qPmUr7M9DZBv84BeD63uA_003D, float _0023_003Dz0ALst1qWgJgu, float _0023_003Dz3ptwfGqkyzBL, float _0023_003Dz8T7D_uh2pyhK, float _0023_003Dz87zvNngD7KQv, float _0023_003DzsTaERoDlh2zJ)
	{
		int num = _0023_003DzD_qPmUr7M9DZBv84BeD63uA_003D.Length;
		_0023_003DzkKfJheA_003D.TextureCoords = new PointF[num];
		float[,] transformationMatrix = GetTransformationMatrix(_0023_003Dz3ptwfGqkyzBL, _0023_003Dz87zvNngD7KQv, _0023_003Dz0ALst1qWgJgu, _0023_003Dz8T7D_uh2pyhK, _0023_003DzsTaERoDlh2zJ);
		for (int i = 0; i < num; i++)
		{
			PointNormalUv pointNormalUv = (PointNormalUv)_0023_003DzD_qPmUr7M9DZBv84BeD63uA_003D[i];
			float[] array = Matrix.Multiply(transformationMatrix, new float[3]
			{
				(float)pointNormalUv.U,
				(float)pointNormalUv.V,
				1f
			});
			_0023_003DzkKfJheA_003D.TextureCoords[i] = new PointF(array[0], array[1]);
		}
	}

	public static bool AreCurvesEqualsOrOpposite(ICurve first, ICurve second, bool checkOpposite = false, bool anyDir = false)
	{
		first.GetApproximatedBoundingBox(out var boxMin, out var boxMax);
		second.GetApproximatedBoundingBox(out var boxMin2, out var boxMax2);
		if (!DoOverlapOrTouch(boxMin, boxMax, boxMin2, boxMax2))
		{
			return false;
		}
		double domainSize = first.Length();
		if (first is Line && second is Line)
		{
			Line line = (Line)first;
			Line line2 = (Line)second;
			if ((anyDir || checkOpposite) && Point3D.AreEqual(line.StartPoint, line2.EndPoint, domainSize) && Point3D.AreEqual(line.EndPoint, line2.StartPoint, domainSize))
			{
				return true;
			}
			if ((anyDir || !checkOpposite) && Point3D.AreEqual(line.StartPoint, line2.StartPoint, domainSize) && Point3D.AreEqual(line.EndPoint, line2.EndPoint, domainSize))
			{
				return true;
			}
		}
		else if (first is Arc && second is Arc)
		{
			Arc arc = (Arc)first;
			Arc arc2 = (Arc)second;
			double num = 1E-11 * Math.Max(arc.Radius, arc2.Radius);
			if (Point3D.AreEqual(arc.Center, arc2.Center, domainSize) && Math.Abs(arc.Radius - arc2.Radius) < num && Math.Abs(arc.angle.Length - arc2.angle.Length) <= 1E-12)
			{
				if ((anyDir || checkOpposite) && Point3D.AreEqual(arc.StartPoint, arc2.EndPoint, domainSize) && Vector3D.AreOpposite(arc.Plane.AxisZ, arc2.Plane.AxisZ))
				{
					return true;
				}
				if ((anyDir || !checkOpposite) && Point3D.AreEqual(arc.StartPoint, arc2.StartPoint, domainSize) && Vector3D.AreCoincident(arc.Plane.AxisZ, arc2.Plane.AxisZ))
				{
					return true;
				}
			}
		}
		else if (first is Circle && second is Circle)
		{
			Circle circle = (Circle)first;
			Circle circle2 = (Circle)second;
			double num2 = 1E-11 * Math.Max(circle.Radius, circle2.Radius);
			if (Point3D.AreEqual(circle.Center, circle2.Center, domainSize) && Math.Abs(circle.Radius - circle2.Radius) < num2 && Point3D.AreEqual(circle.StartPoint, circle2.StartPoint, domainSize))
			{
				if (anyDir)
				{
					return true;
				}
				if (checkOpposite && Vector3D.AreOpposite(circle.Plane.AxisZ, circle2.Plane.AxisZ))
				{
					return true;
				}
				if (!checkOpposite && Vector3D.AreCoincident(circle.Plane.AxisZ, circle2.Plane.AxisZ))
				{
					return true;
				}
			}
		}
		else if (first is EllipticalArc && second is EllipticalArc)
		{
			EllipticalArc ellipticalArc = (EllipticalArc)first;
			EllipticalArc ellipticalArc2 = (EllipticalArc)second;
			double num3 = 1E-11 * new double[4] { ellipticalArc.RadiusX, ellipticalArc.RadiusY, ellipticalArc2.RadiusX, ellipticalArc2.RadiusY }.Max();
			if (Point3D.AreEqual(ellipticalArc.Center, ellipticalArc2.Center, domainSize) && Math.Abs(ellipticalArc.angle.Length - ellipticalArc2.angle.Length) <= num3 && ((Math.Abs(ellipticalArc.RadiusX - ellipticalArc2.RadiusX) < num3 && Math.Abs(ellipticalArc.RadiusY - ellipticalArc2.RadiusY) < num3 && Vector3D.AreParallel(ellipticalArc.Plane.AxisX, ellipticalArc2.Plane.AxisX)) || (Math.Abs(ellipticalArc.RadiusY - ellipticalArc2.RadiusX) < num3 && Math.Abs(ellipticalArc.RadiusX - ellipticalArc2.RadiusY) < num3 && Vector3D.AreParallel(ellipticalArc.Plane.AxisX, ellipticalArc2.Plane.AxisY))))
			{
				if ((anyDir || checkOpposite) && Point3D.AreEqual(ellipticalArc.StartPoint, ellipticalArc2.EndPoint, domainSize) && Vector3D.AreOpposite(ellipticalArc.Plane.AxisZ, ellipticalArc2.Plane.AxisZ))
				{
					return true;
				}
				if ((anyDir || !checkOpposite) && Point3D.AreEqual(ellipticalArc.StartPoint, ellipticalArc2.StartPoint, domainSize) && Vector3D.AreCoincident(ellipticalArc.Plane.AxisZ, ellipticalArc2.Plane.AxisZ))
				{
					return true;
				}
			}
		}
		else if (first is Ellipse && second is Ellipse)
		{
			Ellipse ellipse = (Ellipse)first;
			Ellipse ellipse2 = (Ellipse)second;
			double num4 = 1E-11 * new double[4] { ellipse.RadiusX, ellipse.RadiusY, ellipse2.RadiusX, ellipse2.RadiusY }.Max();
			if (Point3D.AreEqual(ellipse.Center, ellipse2.Center, domainSize) && Point3D.AreEqual(ellipse.StartPoint, ellipse2.StartPoint, domainSize) && ((Math.Abs(ellipse.RadiusX - ellipse2.RadiusX) < num4 && Math.Abs(ellipse.RadiusY - ellipse2.RadiusY) < num4 && Vector3D.AreParallel(ellipse.Plane.AxisX, ellipse2.Plane.AxisX)) || (Math.Abs(ellipse.RadiusY - ellipse2.RadiusX) < num4 && Math.Abs(ellipse.RadiusX - ellipse2.RadiusY) < num4 && Vector3D.AreParallel(ellipse.Plane.AxisX, ellipse2.Plane.AxisY))))
			{
				if (anyDir)
				{
					return true;
				}
				if (checkOpposite && Vector3D.AreOpposite(ellipse.Plane.AxisZ, ellipse2.Plane.AxisZ))
				{
					return true;
				}
				if (!checkOpposite && Vector3D.AreCoincident(ellipse.Plane.AxisZ, ellipse2.Plane.AxisZ))
				{
					return true;
				}
			}
		}
		else if (first is Curve _0023_003Dzfm4oGj8_003D && second is Curve _0023_003DzCVdPoWM_003D)
		{
			Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D = Curve._0023_003DzMAxShrbxTEQp(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D);
			if (!anyDir && !checkOpposite && _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)5)
			{
				return true;
			}
			if (!anyDir && checkOpposite && _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)6)
			{
				return true;
			}
			if (anyDir && (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)5 || _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)6))
			{
				return true;
			}
		}
		return false;
	}

	internal static ICurve _0023_003Dzp4XhdBsfCih7(ICurve _0023_003Dz8fpRyMu9aKjE, Point3D _0023_003Dzrt6_0024RNc_003D, Point3D _0023_003DzBdJe9tA_003D)
	{
		ICurve curve = null;
		if (_0023_003Dz8fpRyMu9aKjE is Curve curve2)
		{
			curve = curve2.Promote();
		}
		if (curve == null)
		{
			curve = _0023_003Dz8fpRyMu9aKjE;
		}
		ICurve curve3;
		if (curve.IsLinear(1E-05, out var _))
		{
			curve3 = new Line(_0023_003Dzrt6_0024RNc_003D, _0023_003DzBdJe9tA_003D);
		}
		else if (curve is Circle circle)
		{
			curve3 = new Arc(circle.Plane, circle.Center, circle.Radius, _0023_003Dzrt6_0024RNc_003D, _0023_003DzBdJe9tA_003D, flip: false);
		}
		else if (curve is Ellipse ellipse)
		{
			curve3 = new EllipticalArc(ellipse.Plane, ellipse.Center, ellipse.RadiusX, ellipse.RadiusY, _0023_003Dzrt6_0024RNc_003D, _0023_003DzBdJe9tA_003D, flip: false);
		}
		else
		{
			curve3 = (ICurve)_0023_003Dz8fpRyMu9aKjE.Clone();
			curve3.ExtendBy(_0023_003DzBdJe9tA_003D);
			curve3.ExtendBy(_0023_003Dzrt6_0024RNc_003D, curveEnd: false);
		}
		return curve3;
	}

	internal static _0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D _0023_003Dz8G5bN3VOoglVAAMdtA_003D_003D(ICurve _0023_003DzRVoDPs0_003D, ICurve _0023_003Dz_0024ozI2Ww_003D)
	{
		Point3D _0023_003DzDVubtvo_003D;
		Point3D _0023_003DzFj_0024IqDQ_003D;
		bool _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D;
		switch (Curve._0023_003DzRGcO5v1wS2S_(_0023_003DzRVoDPs0_003D.GetNurbsForm(), _0023_003Dz_0024ozI2Ww_003D.GetNurbsForm(), out _0023_003DzDVubtvo_003D, out _0023_003DzFj_0024IqDQ_003D, out _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D, 1.0))
		{
		case (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)3:
		case (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)4:
		case (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)5:
		case (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)6:
			return (_0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D)4;
		case (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)1:
		case (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)2:
			if (_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D)
			{
				return (!(_0023_003DzRVoDPs0_003D.Length() < _0023_003Dz_0024ozI2Ww_003D.Length())) ? ((_0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D)1) : ((_0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D)0);
			}
			return (_0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D)3;
		default:
			return (_0023_003Dzx7zNu01lwNrsb0brTQ_003D_003D)2;
		}
	}

	internal static int _0023_003DzZCuAc1AnKVueDa_Q8w_003D_003D(ICurve _0023_003DzRVoDPs0_003D, ICurve _0023_003Dz_0024ozI2Ww_003D, out bool _0023_003DzKgWCaV5RTv9VxFld_g_003D_003D, double _0023_003DzN6G05Lg_003D)
	{
		Point3D _0023_003DzDVubtvo_003D;
		Point3D _0023_003DzFj_0024IqDQ_003D;
		bool _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D;
		Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D = Curve._0023_003DzRGcO5v1wS2S_(_0023_003DzRVoDPs0_003D.GetNurbsForm(), _0023_003Dz_0024ozI2Ww_003D.GetNurbsForm(), out _0023_003DzDVubtvo_003D, out _0023_003DzFj_0024IqDQ_003D, out _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D, _0023_003DzN6G05Lg_003D);
		_0023_003DzKgWCaV5RTv9VxFld_g_003D_003D = false;
		int result = -1;
		switch (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)
		{
		case (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)3:
			result = 0;
			break;
		case (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)4:
			_0023_003DzKgWCaV5RTv9VxFld_g_003D_003D = true;
			result = 0;
			break;
		case (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)5:
			result = 0;
			break;
		case (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)6:
			_0023_003DzKgWCaV5RTv9VxFld_g_003D_003D = true;
			result = 0;
			break;
		case (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)1:
			result = ((_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D && _0023_003DzRVoDPs0_003D.Length() < _0023_003Dz_0024ozI2Ww_003D.Length()) ? 1 : (-1));
			break;
		case (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)2:
			_0023_003DzKgWCaV5RTv9VxFld_g_003D_003D = true;
			result = ((_0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D && _0023_003DzRVoDPs0_003D.Length() < _0023_003Dz_0024ozI2Ww_003D.Length()) ? 1 : (-1));
			break;
		}
		return result;
	}

	internal static Point2D[] _0023_003DzJG8vopyBQob3(Point2D[] _0023_003DzdEvMFOw_003D)
	{
		List<Point2D> list = new List<Point2D>();
		double length = 0.02;
		for (int i = 0; i < _0023_003DzdEvMFOw_003D.Length - 1; i++)
		{
			Point2D point2D = _0023_003DzdEvMFOw_003D[i];
			if (point2D is Point3D && _0023_003DzdEvMFOw_003D[i + 1] is Point3D)
			{
				Point3D[] pointsByLength = new Curve(3, new double[8] { 0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 1.0 }, new Point4D[4]
				{
					new Point4D(point2D.X, point2D.Y, 0.0, 1.0),
					new Point4D(_0023_003DzdEvMFOw_003D[i + 1].X, _0023_003DzdEvMFOw_003D[i + 1].Y, 0.0, 1.0),
					new Point4D(_0023_003DzdEvMFOw_003D[i + 2].X, _0023_003DzdEvMFOw_003D[i + 2].Y, 0.0, 1.0),
					new Point4D(_0023_003DzdEvMFOw_003D[i + 3].X, _0023_003DzdEvMFOw_003D[i + 3].Y, 0.0, 1.0)
				}).GetPointsByLength(length);
				list.AddRange(pointsByLength.ToList().GetRange(0, pointsByLength.Length - 1));
				i = ((i + 4 >= _0023_003DzdEvMFOw_003D.Length - 1 || _0023_003DzdEvMFOw_003D[i + 4] is Point3D) ? (i + 3) : (i + 2));
			}
			else if (Point2D.DistanceSquared(point2D, _0023_003DzdEvMFOw_003D[i + 1]) > 0.0)
			{
				Point3D start = new Point3D(point2D.X, point2D.Y, 0.0);
				Point3D end = new Point3D(_0023_003DzdEvMFOw_003D[i + 1].X, _0023_003DzdEvMFOw_003D[i + 1].Y, 0.0);
				Point3D[] pointsByLength2 = new Line(start, end).GetPointsByLength(length);
				list.AddRange(pointsByLength2.ToList().GetRange(0, pointsByLength2.Length - 1));
			}
		}
		return list.ToArray();
	}

	protected internal static float[,] GetTransformationMatrix(float scaleU, float scaleV, float offsetU, float offsetV, float rotateUV)
	{
		float[,] b = new float[3, 3]
		{
			{ scaleU, 0f, 0f },
			{ 0f, scaleV, 0f },
			{ 0f, 0f, 1f }
		};
		float[,] array = new float[3, 3];
		array[0, 0] = (array[1, 1] = (float)Math.Cos(rotateUV));
		array[1, 0] = (float)Math.Sin(rotateUV);
		array[0, 1] = 0f - array[1, 0];
		array[2, 2] = 1f;
		float[,] array2 = new float[3, 3];
		array2[0, 0] = (array2[1, 1] = (array2[2, 2] = 1f));
		array2[0, 2] = offsetU;
		array2[1, 2] = offsetV;
		return Matrix.Multiply3x3(array2, Matrix.Multiply3x3(array, b));
	}

	public static Line[] GetLinesTangentToTwoCircles(Circle c1, Circle c2)
	{
		if (!c1.IsInPlane(c2.Plane, 0.1))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661346));
		}
		List<Line> list = new List<Line>();
		Line[] _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D;
		double _0023_003DzccAR5G0_003D;
		int num = _0023_003Dz38_00246MP7tFbY71TmJNysAJ_00248_003D(c1, c2, out _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D, out _0023_003DzccAR5G0_003D);
		double _0023_003Dzm0CYiiE_003D = _0023_003DzccAR5G0_003D * _0023_003DzxhnLabVjXjPg;
		bool _0023_003DzNQ7gPu8_0024wZ9N = c1 is Arc;
		bool _0023_003DzLNH2gQMaz9wi = c2 is Arc;
		switch (num)
		{
		case 0:
			return new Line[0];
		case 1:
			_0023_003DzacLV5RVOxa2H(c1, c2, _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[3], list, _0023_003Dzd70SmELWZpKZ: false, _0023_003DzNQ7gPu8_0024wZ9N, _0023_003DzLNH2gQMaz9wi, _0023_003Dzm0CYiiE_003D);
			break;
		case 2:
			_0023_003DzacLV5RVOxa2H(c1, c2, _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0], list, _0023_003Dzd70SmELWZpKZ: true, _0023_003DzNQ7gPu8_0024wZ9N, _0023_003DzLNH2gQMaz9wi, _0023_003Dzm0CYiiE_003D);
			_0023_003DzacLV5RVOxa2H(c1, c2, _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1], list, _0023_003Dzd70SmELWZpKZ: true, _0023_003DzNQ7gPu8_0024wZ9N, _0023_003DzLNH2gQMaz9wi, _0023_003Dzm0CYiiE_003D);
			break;
		case 3:
			_0023_003DzacLV5RVOxa2H(c1, c2, _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0], list, _0023_003Dzd70SmELWZpKZ: true, _0023_003DzNQ7gPu8_0024wZ9N, _0023_003DzLNH2gQMaz9wi, _0023_003Dzm0CYiiE_003D);
			_0023_003DzacLV5RVOxa2H(c1, c2, _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1], list, _0023_003Dzd70SmELWZpKZ: true, _0023_003DzNQ7gPu8_0024wZ9N, _0023_003DzLNH2gQMaz9wi, _0023_003Dzm0CYiiE_003D);
			_0023_003DzacLV5RVOxa2H(c1, c2, _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2], list, _0023_003Dzd70SmELWZpKZ: false, _0023_003DzNQ7gPu8_0024wZ9N, _0023_003DzLNH2gQMaz9wi, _0023_003Dzm0CYiiE_003D);
			break;
		case 4:
			_0023_003DzacLV5RVOxa2H(c1, c2, _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0], list, _0023_003Dzd70SmELWZpKZ: true, _0023_003DzNQ7gPu8_0024wZ9N, _0023_003DzLNH2gQMaz9wi, _0023_003Dzm0CYiiE_003D);
			_0023_003DzacLV5RVOxa2H(c1, c2, _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1], list, _0023_003Dzd70SmELWZpKZ: true, _0023_003DzNQ7gPu8_0024wZ9N, _0023_003DzLNH2gQMaz9wi, _0023_003Dzm0CYiiE_003D);
			_0023_003DzacLV5RVOxa2H(c1, c2, _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2], list, _0023_003Dzd70SmELWZpKZ: true, _0023_003DzNQ7gPu8_0024wZ9N, _0023_003DzLNH2gQMaz9wi, _0023_003Dzm0CYiiE_003D);
			_0023_003DzacLV5RVOxa2H(c1, c2, _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[3], list, _0023_003Dzd70SmELWZpKZ: true, _0023_003DzNQ7gPu8_0024wZ9N, _0023_003DzLNH2gQMaz9wi, _0023_003Dzm0CYiiE_003D);
			break;
		}
		return list.ToArray();
	}

	private static void _0023_003DzacLV5RVOxa2H(Circle _0023_003Dzfm4oGj8_003D, Circle _0023_003DzCVdPoWM_003D, Line _0023_003DzZE0Dh0xA3IA0lHM82A_003D_003D, List<Line> _0023_003DzSwiCDnGhNnvdMA63Pw_003D_003D, bool _0023_003Dzd70SmELWZpKZ, bool _0023_003DzNQ7gPu8_0024wZ9N, bool _0023_003DzLNH2gQMaz9wi, double _0023_003Dzm0CYiiE_003D)
	{
		if (_0023_003Dzd70SmELWZpKZ)
		{
			if ((!_0023_003DzNQ7gPu8_0024wZ9N || _0023_003DzZE0Dh0xA3IA0lHM82A_003D_003D.StartPoint.IsOnCurve(_0023_003Dzfm4oGj8_003D, _0023_003Dzm0CYiiE_003D)) && (!_0023_003DzLNH2gQMaz9wi || _0023_003DzZE0Dh0xA3IA0lHM82A_003D_003D.EndPoint.IsOnCurve(_0023_003DzCVdPoWM_003D, _0023_003Dzm0CYiiE_003D)))
			{
				_0023_003DzSwiCDnGhNnvdMA63Pw_003D_003D.Add(_0023_003DzZE0Dh0xA3IA0lHM82A_003D_003D);
			}
		}
		else if ((!_0023_003DzNQ7gPu8_0024wZ9N || _0023_003DzZE0Dh0xA3IA0lHM82A_003D_003D.MidPoint.IsOnCurve(_0023_003Dzfm4oGj8_003D, _0023_003Dzm0CYiiE_003D)) && (!_0023_003DzLNH2gQMaz9wi || _0023_003DzZE0Dh0xA3IA0lHM82A_003D_003D.MidPoint.IsOnCurve(_0023_003DzCVdPoWM_003D, _0023_003Dzm0CYiiE_003D)))
		{
			_0023_003DzSwiCDnGhNnvdMA63Pw_003D_003D.Add(_0023_003DzZE0Dh0xA3IA0lHM82A_003D_003D);
		}
	}

	public static int GetLinesTangentToTwoCircles(Circle c1, Circle c2, out Line[] tangentArray)
	{
		if (!c1.IsInPlane(c2.Plane, 0.1))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661346));
		}
		double _0023_003DzccAR5G0_003D;
		return _0023_003Dz38_00246MP7tFbY71TmJNysAJ_00248_003D(c1, c2, out tangentArray, out _0023_003DzccAR5G0_003D);
	}

	private static int _0023_003Dz38_00246MP7tFbY71TmJNysAJ_00248_003D(Circle _0023_003Dzfm4oGj8_003D, Circle _0023_003DzCVdPoWM_003D, out Line[] _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D, out double _0023_003DzccAR5G0_003D)
	{
		_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D = new Line[4];
		bool flag = _0023_003Dzfm4oGj8_003D.Radius > _0023_003DzCVdPoWM_003D.Radius;
		Circle circle = (flag ? _0023_003Dzfm4oGj8_003D : _0023_003DzCVdPoWM_003D);
		Circle circle2 = (flag ? _0023_003DzCVdPoWM_003D : _0023_003Dzfm4oGj8_003D);
		double radius = circle.Radius;
		double radius2 = circle2.Radius;
		double num = circle2.Center.DistanceTo(circle.Center);
		_0023_003DzccAR5G0_003D = Math.Max(radius, num);
		double num2 = _0023_003DzccAR5G0_003D * _0023_003DzxhnLabVjXjPg;
		if (Compare(num2, radius - radius2, num) > 0 || Compare(num2, 0.0, num) == 0)
		{
			return 0;
		}
		Line line = new Line((Point3D)circle.Center.Clone(), (Point3D)circle2.Center.Clone());
		Circle circle3 = new Circle(circle.Plane, line.MidPoint, num / 2.0);
		if (Compare(num2, _0023_003Dzfm4oGj8_003D.Radius + _0023_003DzCVdPoWM_003D.Radius, num) == -1)
		{
			_0023_003DzESbmkJEX3gTX(circle, circle2, circle3, num2, flag, out var _0023_003DzPqzKY7hIawvt);
			Circle arc = new Circle(circle.Plane, (Point3D)circle.Center.Clone(), radius + radius2);
			IntersectionCircleCircle(circle3, arc, circle3.Plane, out var i, out var i2);
			Line line2 = new Line((Point3D)circle2.Center.Clone(), (Point3D)i.Clone());
			Line line3 = new Line((Point3D)circle2.Center.Clone(), (Point3D)i2.Clone());
			Vector3D vector3D = new Vector3D(i, circle.Center);
			Vector3D vector3D2 = new Vector3D(i2, circle.Center);
			vector3D.Normalize();
			vector3D2.Normalize();
			line2.Translate(radius2 * vector3D);
			line3.Translate(radius2 * vector3D2);
			if (flag)
			{
				line2.Reverse();
				line3.Reverse();
			}
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzPqzKY7hIawvt[0];
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzPqzKY7hIawvt[1];
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = line3;
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[3] = line2;
			return 4;
		}
		if (Compare(num2, num, _0023_003Dzfm4oGj8_003D.Radius + _0023_003DzCVdPoWM_003D.Radius) == 0)
		{
			_0023_003DzESbmkJEX3gTX(circle, circle2, circle3, num2, flag, out var _0023_003DzPqzKY7hIawvt2);
			Vector3D startTangent = line.StartTangent;
			Point3D point3D = (Point3D)circle.Center.Clone() + radius * startTangent;
			Vector3D vector3D3 = Vector3D.Cross(startTangent, circle2.Plane.AxisZ);
			vector3D3.Normalize();
			Line line4 = new Line(point3D + radius * vector3D3, point3D - radius * vector3D3);
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzPqzKY7hIawvt2[0];
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzPqzKY7hIawvt2[1];
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = line4;
			return 3;
		}
		if (Compare(num2, radius - radius2, num) == -1)
		{
			_0023_003DzESbmkJEX3gTX(circle, circle2, circle3, num2, flag, out var _0023_003DzPqzKY7hIawvt3);
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzPqzKY7hIawvt3[0];
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzPqzKY7hIawvt3[1];
			return 2;
		}
		Vector3D startTangent2 = line.StartTangent;
		Point3D point3D2 = circle.Center + radius * startTangent2;
		Vector3D vector3D4 = Vector3D.Cross(line.StartTangent, circle2.Plane.AxisZ);
		vector3D4.Normalize();
		Line line5 = new Line(point3D2 + radius * vector3D4, point3D2 - radius * vector3D4);
		_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[3] = line5;
		return 1;
	}

	private static void _0023_003DzESbmkJEX3gTX(Circle _0023_003DzTm7ykWkuytAnYcB5pg_003D_003D, Circle _0023_003Dz_0024CEoJ4QLiq_scIRUuA_003D_003D, Circle _0023_003DzY8KlFqo_003D, double _0023_003Dzm0CYiiE_003D, bool _0023_003DzQEo44jI1CiQ6YtOPsA_003D_003D, out Line[] _0023_003DzPqzKY7hIawvt)
	{
		_0023_003DzPqzKY7hIawvt = new Line[2];
		Line line;
		Line line2;
		Vector3D vector3D;
		Vector3D vector3D2;
		if (Compare(_0023_003Dzm0CYiiE_003D, _0023_003DzTm7ykWkuytAnYcB5pg_003D_003D.Radius, _0023_003Dz_0024CEoJ4QLiq_scIRUuA_003D_003D.Radius) == 0)
		{
			line = new Line((Point3D)_0023_003Dz_0024CEoJ4QLiq_scIRUuA_003D_003D.Center.Clone(), (Point3D)_0023_003DzTm7ykWkuytAnYcB5pg_003D_003D.Center.Clone());
			line2 = (Line)line.Clone();
			vector3D = Vector3D.Cross(new Vector3D((Point3D)_0023_003Dz_0024CEoJ4QLiq_scIRUuA_003D_003D.Center.Clone(), (Point3D)_0023_003DzTm7ykWkuytAnYcB5pg_003D_003D.Center.Clone()), _0023_003Dz_0024CEoJ4QLiq_scIRUuA_003D_003D.Plane.AxisZ);
			vector3D.Normalize();
			vector3D2 = -1.0 * vector3D;
		}
		else
		{
			Circle arc = new Circle(_0023_003DzTm7ykWkuytAnYcB5pg_003D_003D.Plane, (Point3D)_0023_003DzTm7ykWkuytAnYcB5pg_003D_003D.Center.Clone(), _0023_003DzTm7ykWkuytAnYcB5pg_003D_003D.Radius - _0023_003Dz_0024CEoJ4QLiq_scIRUuA_003D_003D.Radius);
			IntersectionCircleCircle(_0023_003DzY8KlFqo_003D, arc, _0023_003DzY8KlFqo_003D.Plane, out var i, out var i2);
			line = new Line((Point3D)_0023_003Dz_0024CEoJ4QLiq_scIRUuA_003D_003D.Center.Clone(), i);
			line2 = new Line((Point3D)_0023_003Dz_0024CEoJ4QLiq_scIRUuA_003D_003D.Center.Clone(), i2);
			vector3D2 = new Vector3D((Point3D)_0023_003DzTm7ykWkuytAnYcB5pg_003D_003D.Center.Clone(), (Point3D)i.Clone());
			vector3D = new Vector3D((Point3D)_0023_003DzTm7ykWkuytAnYcB5pg_003D_003D.Center.Clone(), (Point3D)i2.Clone());
			vector3D2.Normalize();
			vector3D.Normalize();
		}
		line.Translate(_0023_003Dz_0024CEoJ4QLiq_scIRUuA_003D_003D.Radius * vector3D2);
		line2.Translate(_0023_003Dz_0024CEoJ4QLiq_scIRUuA_003D_003D.Radius * vector3D);
		if (_0023_003DzQEo44jI1CiQ6YtOPsA_003D_003D)
		{
			line.Reverse();
			line2.Reverse();
			_0023_003DzPqzKY7hIawvt[0] = line2;
			_0023_003DzPqzKY7hIawvt[1] = line;
		}
		else
		{
			_0023_003DzPqzKY7hIawvt[0] = line;
			_0023_003DzPqzKY7hIawvt[1] = line2;
		}
	}

	public static Circle[] GetCirclesTangentToTwoCircles(Circle c1, Circle c2, double radius, bool trim, bool flip = false)
	{
		Circle[] _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D;
		double _0023_003DzccAR5G0_003D;
		int num = _0023_003Dzt8eR93z0vwcOZ__0024SFmYIIXsEB_0nEWK_00243w_003D_003D(c1, c2, radius, _0023_003DzPyg3iAiZrTA_0024: true, out _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D, out _0023_003DzccAR5G0_003D);
		Circle[] _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D2;
		int num2 = _0023_003Dzt8eR93z0vwcOZ__0024SFmYIIXsEB_0nEWK_00243w_003D_003D(c1, c2, radius, _0023_003DzPyg3iAiZrTA_0024: false, out _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D2, out _0023_003DzccAR5G0_003D);
		double _0023_003Dzm0CYiiE_003D = _0023_003DzccAR5G0_003D * _0023_003DzxhnLabVjXjPg;
		List<Circle> list = new List<Circle>(num + num2);
		int num3 = _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D.Length;
		int num4 = num3 + _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D2.Length;
		for (int i = 0; i < num4; i++)
		{
			Circle circle = ((i < num3) ? _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[i] : _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D2[i - num3]);
			if (circle != null && _0023_003DzUwY_002467n7Rb61g48LHn7bMQk_003D(c1, c2, circle, c1 is Arc, c2 is Arc, _0023_003Dzm0CYiiE_003D))
			{
				list.Add(circle);
			}
		}
		if (trim)
		{
			for (int j = 0; j < list.Count; j++)
			{
				Circle circle2 = list[j];
				Vector3D vector3D = new Vector3D((Point3D)circle2.Center.Clone(), (Point3D)c2.Center.Clone());
				vector3D.Normalize();
				if (c2.Radius > circle2.Radius && c2.Radius > circle2.Center.DistanceTo(c2.Center))
				{
					vector3D.Negate();
				}
				_0023_003DzlrBg_0024xtJksjg6X6qYQ_003D_003D(circle2.Center + circle2.Radius * vector3D, list[j], out var _0023_003DzN4MDZ_0024c_003D, flip);
				list[j] = _0023_003DzN4MDZ_0024c_003D;
			}
		}
		return list.ToArray();
	}

	private static int _0023_003Dzt8eR93z0vwcOZ__0024SFmYIIXsEB_0nEWK_00243w_003D_003D(Circle _0023_003Dzfm4oGj8_003D, Circle _0023_003DzCVdPoWM_003D, double _0023_003DzEGKj_0024SNUUihi, bool _0023_003DzPyg3iAiZrTA_0024, out Circle[] _0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D, out double _0023_003DzccAR5G0_003D)
	{
		if (!_0023_003Dzfm4oGj8_003D.IsInPlane(_0023_003DzCVdPoWM_003D.Plane, 0.1))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661346));
		}
		bool flag = _0023_003Dzfm4oGj8_003D.Radius > _0023_003DzCVdPoWM_003D.Radius;
		Circle circle = (flag ? _0023_003Dzfm4oGj8_003D : _0023_003DzCVdPoWM_003D);
		Circle circle2 = (flag ? _0023_003DzCVdPoWM_003D : _0023_003Dzfm4oGj8_003D);
		double radius = circle.Radius;
		double radius2 = circle2.Radius;
		double radius3 = _0023_003Dzfm4oGj8_003D.Radius;
		double radius4 = _0023_003DzCVdPoWM_003D.Radius;
		Point3D point3D = (Point3D)circle.Center.Clone();
		Point3D point3D2 = (Point3D)circle2.Center.Clone();
		Point3D center = _0023_003Dzfm4oGj8_003D.Center;
		Point3D center2 = _0023_003DzCVdPoWM_003D.Center;
		double num = point3D2.DistanceTo(point3D);
		Point3D p = (Point3D)_0023_003Dzfm4oGj8_003D.StartPoint.Clone();
		Vector3D startTangent = new Line((Point3D)center.Clone(), (Point3D)center2.Clone()).StartTangent;
		startTangent.Normalize();
		Vector3D vector3D = new Vector3D((Point3D)circle.Center.Clone(), (Point3D)circle2.Center.Clone());
		vector3D.Normalize();
		_0023_003DzccAR5G0_003D = Math.Max(radius, num);
		double num2 = _0023_003DzccAR5G0_003D * _0023_003DzxhnLabVjXjPg;
		bool flag2 = Compare(num2, radius3, radius4) == 0;
		if (Point3D.Distance(_0023_003Dzfm4oGj8_003D.Center, _0023_003DzCVdPoWM_003D.Center) < num2)
		{
			Vector3D vector3D2 = new Vector3D(point3D2, p);
			vector3D2.Normalize();
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D = new Circle[1];
			if (_0023_003DzPyg3iAiZrTA_0024)
			{
				return 0;
			}
			double num3 = 0.5 * (radius - radius2);
			double num4 = 0.5 * (radius + radius2);
			Point3D point3D3 = null;
			if (Compare(num2, num3, _0023_003DzEGKj_0024SNUUihi) == 0)
			{
				point3D3 = point3D2 + (num3 + radius2) * vector3D2;
			}
			else if (Compare(num2, num4, _0023_003DzEGKj_0024SNUUihi) == 0)
			{
				point3D3 = point3D2 + (num4 - radius2) * vector3D2;
			}
			if (point3D3 != null)
			{
				Vector3D vector3D3 = ((!flag) ? new Vector3D((Point3D)point3D3.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone()) : new Vector3D((Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone(), (Point3D)point3D3.Clone()));
				Plane plane = new Plane(point3D3, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = new Circle(plane, point3D3, _0023_003DzEGKj_0024SNUUihi);
				return 1;
			}
			return 0;
		}
		Circle[] _0023_003DzDWPiour4RJLt;
		double b;
		double num5;
		if (Compare(num2, radius3 + radius4, num) == -1)
		{
			if (_0023_003DzPyg3iAiZrTA_0024)
			{
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D = new Circle[4];
				b = 0.5 * (num - radius3 - radius4);
				num5 = 0.5 * (num + radius3 + radius4);
				if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b) == -1)
				{
					return 0;
				}
				if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b) == 0)
				{
					Point3D point3D4 = center + (radius3 + _0023_003DzEGKj_0024SNUUihi) * startTangent;
					Vector3D vector3D3 = new Vector3D((Point3D)point3D4.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone());
					Plane plane2 = new Plane(point3D4, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = new Circle(plane2, point3D4, _0023_003DzEGKj_0024SNUUihi);
					return 1;
				}
				if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, num5) == -1)
				{
					_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 1, 1, out _0023_003DzDWPiour4RJLt);
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt[1];
					return 2;
				}
				if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, num5) == 0)
				{
					Point3D point3D5 = point3D - (radius - num5) * vector3D;
					Vector3D vector3D3 = new Vector3D((Point3D)point3D5.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone());
					Plane plane3 = new Plane(point3D5, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
					_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 1, 1, out _0023_003DzDWPiour4RJLt);
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt[1];
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = new Circle(plane3, point3D5, _0023_003DzEGKj_0024SNUUihi);
					return 3;
				}
				_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 1, 1, out _0023_003DzDWPiour4RJLt);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt[1];
				_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 2, 2, out _0023_003DzDWPiour4RJLt);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = _0023_003DzDWPiour4RJLt[0];
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[3] = _0023_003DzDWPiour4RJLt[1];
				return 4;
			}
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D = new Circle[4];
			double num6 = Math.Abs(radius3 - radius4);
			b = 0.5 * (num - num6);
			num5 = 0.5 * (num + num6);
			if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b) == -1)
			{
				return 0;
			}
			if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b) == 0)
			{
				Point3D point3D6 = point3D2 + (radius2 - _0023_003DzEGKj_0024SNUUihi) * vector3D;
				Vector3D vector3D3 = new Vector3D((Point3D)point3D6.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone());
				Plane plane4 = new Plane(point3D6, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = new Circle(plane4, point3D6, b);
				return 1;
			}
			if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, num5) == -1)
			{
				_0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 1, 2, flag, out _0023_003DzDWPiour4RJLt);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt[1];
				return 2;
			}
			if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, num5) == 0)
			{
				_0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 1, 2, flag, out _0023_003DzDWPiour4RJLt);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt[1];
				Point3D point3D7 = point3D + (0.0 - radius + num5) * vector3D;
				Vector3D vector3D3 = new Vector3D((Point3D)point3D7.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone());
				Plane plane5 = new Plane(point3D7, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = new Circle(plane5, point3D7, num5);
				return 3;
			}
			_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 1, 2, out _0023_003DzDWPiour4RJLt);
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt[1];
			_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 2, 1, out _0023_003DzDWPiour4RJLt);
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = _0023_003DzDWPiour4RJLt[0];
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[3] = _0023_003DzDWPiour4RJLt[1];
			return 4;
		}
		Circle[] _0023_003DzDWPiour4RJLt2;
		if (Compare(num2, num, radius3 + radius4) == 0)
		{
			if (_0023_003DzPyg3iAiZrTA_0024)
			{
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D = new Circle[4];
				_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 1, 1, out _0023_003DzDWPiour4RJLt);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt[1];
				b = 0.5 * (num + radius3 + radius4);
				if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b) == 0)
				{
					Point3D point3D8 = point3D2 + (radius2 - _0023_003DzEGKj_0024SNUUihi) * vector3D;
					Vector3D vector3D3 = new Vector3D((Point3D)point3D8.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone());
					Plane plane6 = new Plane(point3D8, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = new Circle(plane6, point3D8, _0023_003DzEGKj_0024SNUUihi);
					return 3;
				}
				if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b) == 1)
				{
					_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 2, 2, out _0023_003DzDWPiour4RJLt);
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = _0023_003DzDWPiour4RJLt[0];
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[3] = _0023_003DzDWPiour4RJLt[1];
					return 4;
				}
				return 2;
			}
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D = new Circle[2];
			if (flag2 && Compare(num2, radius3, _0023_003DzEGKj_0024SNUUihi) == 0)
			{
				return 0;
			}
			if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, radius2) == -1)
			{
				_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 1, 3, out _0023_003DzDWPiour4RJLt);
				_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 1, out _0023_003DzDWPiour4RJLt2);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt2[0];
				return 2;
			}
			if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, radius2) == 0)
			{
				_0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 1, flag, out _0023_003DzDWPiour4RJLt);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
				return 1;
			}
			if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, radius) == -1)
			{
				_0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 1, flag, out _0023_003DzDWPiour4RJLt);
				_0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 1, 2, flag, out _0023_003DzDWPiour4RJLt2);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt2[0];
				return 2;
			}
			if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, radius) == 0)
			{
				_0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 1, 2, flag, out _0023_003DzDWPiour4RJLt);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
				return 1;
			}
			_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 1, 2, out _0023_003DzDWPiour4RJLt);
			_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 2, 1, out _0023_003DzDWPiour4RJLt2);
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt2[0];
			return 2;
		}
		if (Compare(num2, Math.Abs(radius3 - radius4), num) == -1)
		{
			if (_0023_003DzPyg3iAiZrTA_0024)
			{
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D = new Circle[6];
				_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 1, 1, out _0023_003DzDWPiour4RJLt);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt[1];
				b = 0.5 * (radius3 + radius4 - num);
				num5 = 0.5 * (num + radius3 + radius4);
				if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b) == -1)
				{
					_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 3, out _0023_003DzDWPiour4RJLt);
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = _0023_003DzDWPiour4RJLt[0];
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[3] = _0023_003DzDWPiour4RJLt[1];
					return 4;
				}
				if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b) == 0)
				{
					Point3D point3D9 = point3D2 + (0.0 - radius2 + _0023_003DzEGKj_0024SNUUihi) * vector3D;
					Vector3D vector3D3 = new Vector3D((Point3D)point3D9.Clone(), _0023_003DzCVdPoWM_003D.Center);
					Plane plane7 = new Plane(point3D9, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = new Circle(plane7, point3D9, _0023_003DzEGKj_0024SNUUihi);
					return 3;
				}
				if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, num5) == 0)
				{
					Point3D point3D10 = point3D + (0.0 - radius + num5) * vector3D;
					Vector3D vector3D3 = new Vector3D((Point3D)point3D10.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone());
					Plane plane8 = new Plane(point3D10, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[4] = new Circle(plane8, point3D10, _0023_003DzEGKj_0024SNUUihi);
					return 3;
				}
				if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, num5) == 1)
				{
					_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 2, 2, out _0023_003DzDWPiour4RJLt);
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[4] = _0023_003DzDWPiour4RJLt[0];
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[5] = _0023_003DzDWPiour4RJLt[1];
					return 4;
				}
				return 2;
			}
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D = new Circle[4];
			b = 0.5 * (radius2 - radius + num);
			num5 = 0.5 * (radius - radius2 + num);
			if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b) == -1)
			{
				_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 1, 3, out _0023_003DzDWPiour4RJLt);
				_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 1, out _0023_003DzDWPiour4RJLt2);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt[1];
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = _0023_003DzDWPiour4RJLt2[0];
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[3] = _0023_003DzDWPiour4RJLt2[1];
				return 4;
			}
			if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b) == 0 && flag2)
			{
				_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 1, out _0023_003DzDWPiour4RJLt);
				_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 1, 3, out _0023_003DzDWPiour4RJLt2);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt2[0];
				return 2;
			}
			if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b) == 0)
			{
				Point3D point3D11 = point3D2 + (radius2 - _0023_003DzEGKj_0024SNUUihi) * vector3D;
				Vector3D vector3D3 = new Vector3D((Point3D)_0023_003DzCVdPoWM_003D.Center.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone());
				Plane plane9 = new Plane(point3D11, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = new Circle(plane9, point3D11, _0023_003DzEGKj_0024SNUUihi);
				_0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 1, flag, out _0023_003DzDWPiour4RJLt);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = _0023_003DzDWPiour4RJLt[0];
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[3] = _0023_003DzDWPiour4RJLt[1];
				return 3;
			}
			if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, num5) == -1)
			{
				_0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 1, flag, out _0023_003DzDWPiour4RJLt);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = _0023_003DzDWPiour4RJLt[0];
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[3] = _0023_003DzDWPiour4RJLt[1];
				return 2;
			}
			if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, num5) == 0)
			{
				Point3D point3D12 = point3D - (radius - _0023_003DzEGKj_0024SNUUihi) * vector3D;
				Vector3D vector3D3 = new Vector3D((Point3D)_0023_003DzCVdPoWM_003D.Center.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone());
				Plane plane10 = new Plane(point3D12, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[3] = new Circle(plane10, point3D12, _0023_003DzEGKj_0024SNUUihi);
				return 1;
			}
			return 0;
		}
		if (Compare(num2, Math.Abs(radius3 - radius4), num) == 0)
		{
			if (_0023_003DzPyg3iAiZrTA_0024)
			{
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D = new Circle[3];
				_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 1, 1, out _0023_003DzDWPiour4RJLt);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
				if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, radius2) == -1)
				{
					_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 3, out _0023_003DzDWPiour4RJLt);
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt[0];
					return 2;
				}
				if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, radius) == 1)
				{
					_0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 2, 2, out _0023_003DzDWPiour4RJLt);
					_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = _0023_003DzDWPiour4RJLt[0];
					return 2;
				}
				return 1;
			}
			int num7 = 0;
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D = new Circle[3];
			b = radius - radius2;
			if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b) == -1)
			{
				_0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 1, flag, out _0023_003DzDWPiour4RJLt);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt[1];
				num7 += 2;
			}
			if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b) == 0)
			{
				Point3D point3D13 = point3D2 - (_0023_003DzEGKj_0024SNUUihi + radius2) * vector3D;
				Vector3D vector3D3 = ((!flag) ? new Vector3D((Point3D)point3D13.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone()) : (-1.0 * new Vector3D((Point3D)point3D13.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone())));
				Plane plane11 = new Plane(point3D13, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = new Circle(plane11, point3D13, _0023_003DzEGKj_0024SNUUihi);
				num7++;
			}
			if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, radius2) == 1 && Compare(num2, _0023_003DzEGKj_0024SNUUihi, radius) == -1)
			{
				_0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 2, flag, out _0023_003DzDWPiour4RJLt);
				_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = _0023_003DzDWPiour4RJLt[0];
				num7++;
			}
			return num7;
		}
		_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D = new Circle[4];
		if (_0023_003DzPyg3iAiZrTA_0024)
		{
			return 0;
		}
		b = 0.5 * (radius - num - radius2);
		num5 = radius2 + b;
		double b2 = radius - radius2 - b;
		double b3 = radius - b;
		bool flag3 = Compare(num2, num5, b2) == 0;
		if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b) == -1)
		{
			return 0;
		}
		if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b) == 0)
		{
			Point3D point3D14 = point3D2 + (_0023_003DzEGKj_0024SNUUihi + radius2) * vector3D;
			Vector3D vector3D3 = ((!flag) ? new Vector3D((Point3D)point3D14.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone()) : (-1.0 * new Vector3D((Point3D)point3D14.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone())));
			Plane plane12 = new Plane(point3D14, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = new Circle(plane12, point3D14, _0023_003DzEGKj_0024SNUUihi);
			return 1;
		}
		if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b) == 1 && Compare(num2, _0023_003DzEGKj_0024SNUUihi, num5) == -1)
		{
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D = new Circle[2];
			_0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 1, flag, out _0023_003DzDWPiour4RJLt);
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt[1];
			return 2;
		}
		if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, num5) == 0 && flag3)
		{
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D = new Circle[2];
			Point3D point3D15 = point3D2 + (_0023_003DzEGKj_0024SNUUihi - radius2) * vector3D;
			Vector3D vector3D3 = ((!flag) ? new Vector3D((Point3D)point3D15.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone()) : new Vector3D((Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone(), (Point3D)point3D15.Clone()));
			Plane plane13 = new Plane(point3D15, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = new Circle(plane13, point3D15, _0023_003DzEGKj_0024SNUUihi);
			point3D15 = point3D + (_0023_003DzEGKj_0024SNUUihi - radius) * vector3D;
			vector3D3 = ((!flag) ? new Vector3D((Point3D)point3D15.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone()) : new Vector3D((Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone(), (Point3D)point3D15.Clone()));
			plane13 = new Plane(point3D15, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = new Circle(plane13, point3D15, _0023_003DzEGKj_0024SNUUihi);
			return 2;
		}
		if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, num5) == 0)
		{
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D = new Circle[3];
			_0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 1, flag, out _0023_003DzDWPiour4RJLt);
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt[1];
			Point3D point3D16 = point3D2 + (b - radius2) * vector3D;
			Vector3D vector3D3 = ((!flag) ? new Vector3D((Point3D)point3D16.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone()) : new Vector3D((Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone(), (Point3D)point3D16.Clone()));
			Plane plane14 = new Plane(point3D16, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = new Circle(plane14, point3D16, num5);
			return 3;
		}
		if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, num5) == 1 && Compare(num2, _0023_003DzEGKj_0024SNUUihi, b2) == -1)
		{
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D = new Circle[4];
			_0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 1, flag, out _0023_003DzDWPiour4RJLt);
			_0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 2, flag, out _0023_003DzDWPiour4RJLt2);
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt[1];
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[2] = _0023_003DzDWPiour4RJLt2[0];
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[3] = _0023_003DzDWPiour4RJLt2[1];
			return 4;
		}
		if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b2) == 0)
		{
			_0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 2, flag, out _0023_003DzDWPiour4RJLt);
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt[1];
			Point3D point3D17 = point3D + (_0023_003DzEGKj_0024SNUUihi - radius) * vector3D;
			Vector3D vector3D3 = ((!flag) ? new Vector3D((Point3D)point3D17.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone()) : new Vector3D((Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone(), (Point3D)point3D17.Clone()));
			Plane plane15 = new Plane(point3D17, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[3] = new Circle(plane15, point3D17, _0023_003DzEGKj_0024SNUUihi);
			return 3;
		}
		if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b2) == 1 && Compare(num2, _0023_003DzEGKj_0024SNUUihi, b3) == -1)
		{
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D = new Circle[2];
			_0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, 3, 2, flag, out _0023_003DzDWPiour4RJLt);
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = _0023_003DzDWPiour4RJLt[0];
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[1] = _0023_003DzDWPiour4RJLt[1];
			return 2;
		}
		if (Compare(num2, _0023_003DzEGKj_0024SNUUihi, b3) == 0)
		{
			Point3D point3D18 = circle.Center + (_0023_003DzEGKj_0024SNUUihi - radius) * vector3D;
			Vector3D vector3D3 = ((!flag) ? new Vector3D((Point3D)point3D18.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone()) : new Vector3D((Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone(), (Point3D)point3D18.Clone()));
			Plane plane16 = new Plane(point3D18, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
			_0023_003DzdQdfJjlQktpF2yVnFQ_003D_003D[0] = new Circle(plane16, point3D18, _0023_003DzEGKj_0024SNUUihi);
			return 1;
		}
		return 0;
	}

	private static bool _0023_003Dz_00249bGjKjldsieVbTcT97N4KDE4GM6(Circle _0023_003Dzfm4oGj8_003D, Circle _0023_003DzCVdPoWM_003D, double _0023_003DzEGKj_0024SNUUihi, int _0023_003Dzierz6tQjDiakWi2rNgXOStc_003D, int _0023_003DzF1ixNCvK674l_0024C9WqRbalvo_003D, bool _0023_003DzQEo44jI1CiQ6YtOPsA_003D_003D, out Circle[] _0023_003DzDWPiour4RJLt)
	{
		if (_0023_003DzQEo44jI1CiQ6YtOPsA_003D_003D)
		{
			return _0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, _0023_003Dzierz6tQjDiakWi2rNgXOStc_003D, _0023_003DzF1ixNCvK674l_0024C9WqRbalvo_003D, out _0023_003DzDWPiour4RJLt);
		}
		return _0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, _0023_003DzF1ixNCvK674l_0024C9WqRbalvo_003D, _0023_003Dzierz6tQjDiakWi2rNgXOStc_003D, out _0023_003DzDWPiour4RJLt);
	}

	private static bool _0023_003Dzr3u6t3ZJ_00249cBsZvHFQ_003D_003D(Circle _0023_003Dzfm4oGj8_003D, Circle _0023_003DzCVdPoWM_003D, double _0023_003DzEGKj_0024SNUUihi, int _0023_003DzSv_00241ZyLIseUr72BraQ_003D_003D, int _0023_003DzApglNDby0YoVHufk6g_003D_003D, out Circle[] _0023_003DzbCB8gRo_003D)
	{
		_0023_003DzbCB8gRo_003D = new Circle[2];
		if (_0023_003Dz7Dq1OuAlooxo9Wl4ZtAdr1w_003D(_0023_003Dzfm4oGj8_003D, _0023_003DzEGKj_0024SNUUihi, _0023_003DzSv_00241ZyLIseUr72BraQ_003D_003D, out var _0023_003DzshZYG54_003D) && _0023_003Dz7Dq1OuAlooxo9Wl4ZtAdr1w_003D(_0023_003DzCVdPoWM_003D, _0023_003DzEGKj_0024SNUUihi, _0023_003DzApglNDby0YoVHufk6g_003D_003D, out var _0023_003DzshZYG54_003D2))
		{
			if (!IntersectionCircleCircle(_0023_003DzshZYG54_003D, _0023_003DzshZYG54_003D2, _0023_003DzshZYG54_003D.Plane, out var i, out var i2))
			{
				return false;
			}
			Vector3D vector3D;
			if (i2 == null)
			{
				vector3D = new Vector3D((Point3D)i.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone());
				if (_0023_003DzSv_00241ZyLIseUr72BraQ_003D_003D == 3)
				{
					vector3D.Negate();
				}
				Plane plane = new Plane(i, vector3D, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D));
				_0023_003DzbCB8gRo_003D[0] = new Circle(plane, i, _0023_003DzEGKj_0024SNUUihi);
				return true;
			}
			Vector3D b = new Vector3D(_0023_003Dzfm4oGj8_003D.Center, _0023_003DzCVdPoWM_003D.Center);
			Vector3D vector3D2 = Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, b);
			Segment3D segment3D = new Segment3D(_0023_003Dzfm4oGj8_003D.Center, _0023_003Dzfm4oGj8_003D.Center + vector3D2);
			double num = segment3D.Project(i);
			double num2 = segment3D.Project(i2);
			vector3D = new Vector3D((Point3D)i.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone());
			Vector3D vector3D3 = new Vector3D((Point3D)i2.Clone(), (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone());
			if (_0023_003DzSv_00241ZyLIseUr72BraQ_003D_003D == 3)
			{
				vector3D.Negate();
				vector3D3.Negate();
			}
			Plane plane2 = new Plane(i, vector3D, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D));
			Plane plane3 = new Plane(i2, vector3D3, Vector3D.Cross(_0023_003Dzfm4oGj8_003D.Plane.AxisZ, vector3D3));
			Circle circle = new Circle(plane2, i, _0023_003DzEGKj_0024SNUUihi);
			Circle circle2 = new Circle(plane3, i2, _0023_003DzEGKj_0024SNUUihi);
			if (num > num2)
			{
				_0023_003DzbCB8gRo_003D[0] = circle;
				_0023_003DzbCB8gRo_003D[1] = circle2;
				return true;
			}
			_0023_003DzbCB8gRo_003D[1] = circle2;
			_0023_003DzbCB8gRo_003D[0] = circle;
			return true;
		}
		return false;
	}

	private static bool _0023_003Dz7Dq1OuAlooxo9Wl4ZtAdr1w_003D(Circle _0023_003Dzt_m8zV0_003D, double _0023_003DzEGKj_0024SNUUihi, int _0023_003DzEKSHIVc_003D, out Circle _0023_003DzshZYG54_003D)
	{
		double radius = _0023_003Dzt_m8zV0_003D.Radius;
		double tol = radius * _0023_003DzxhnLabVjXjPg;
		if (_0023_003DzEGKj_0024SNUUihi < 1E-12)
		{
			_0023_003DzshZYG54_003D = null;
			return false;
		}
		switch (_0023_003DzEKSHIVc_003D)
		{
		case 1:
			_0023_003DzshZYG54_003D = new Circle(_0023_003Dzt_m8zV0_003D.Plane, _0023_003Dzt_m8zV0_003D.Center, radius + _0023_003DzEGKj_0024SNUUihi);
			return true;
		case 2:
			if (Compare(tol, radius, _0023_003DzEGKj_0024SNUUihi) == 1)
			{
				_0023_003DzshZYG54_003D = null;
				return false;
			}
			_0023_003DzshZYG54_003D = new Circle(_0023_003Dzt_m8zV0_003D.Plane, _0023_003Dzt_m8zV0_003D.Center, _0023_003DzEGKj_0024SNUUihi - radius);
			return true;
		case 3:
			if (Compare(tol, radius, _0023_003DzEGKj_0024SNUUihi) == -1)
			{
				_0023_003DzshZYG54_003D = null;
				return false;
			}
			_0023_003DzshZYG54_003D = new Circle(_0023_003Dzt_m8zV0_003D.Plane, _0023_003Dzt_m8zV0_003D.Center, radius - _0023_003DzEGKj_0024SNUUihi);
			return true;
		default:
			_0023_003DzshZYG54_003D = null;
			return false;
		}
	}

	private static void _0023_003DzlrBg_0024xtJksjg6X6qYQ_003D_003D(Point3D _0023_003Dze3yBLitxTyfic26QDg_003D_003D, Circle _0023_003DzeQOQKfAqtAvt, out Arc _0023_003DzN4MDZ_0024c_003D, bool _0023_003Dzbu8BV15Qqzan)
	{
		Arc arc = new Arc(_0023_003DzeQOQKfAqtAvt.Plane, _0023_003DzeQOQKfAqtAvt.Center, _0023_003DzeQOQKfAqtAvt.Radius, Math.PI * 2.0);
		_0023_003DzeQOQKfAqtAvt.Project(_0023_003Dze3yBLitxTyfic26QDg_003D_003D, out var t);
		if (t > 3.141592653590793)
		{
			_0023_003Dzbu8BV15Qqzan = !_0023_003Dzbu8BV15Qqzan;
		}
		arc.TrimBy(_0023_003Dze3yBLitxTyfic26QDg_003D_003D, _0023_003Dzbu8BV15Qqzan);
		if (_0023_003Dzbu8BV15Qqzan)
		{
			arc.Reverse();
		}
		_0023_003DzN4MDZ_0024c_003D = arc;
	}

	private static bool _0023_003DzUwY_002467n7Rb61g48LHn7bMQk_003D(Circle _0023_003Dzfm4oGj8_003D, Circle _0023_003DzCVdPoWM_003D, Circle _0023_003DzvVtY_GumbMMFvpojLYi3Ahg_003D, bool _0023_003DzNQ7gPu8_0024wZ9N, bool _0023_003DzLNH2gQMaz9wi, double _0023_003Dzm0CYiiE_003D)
	{
		Point3D point3D = (Point3D)_0023_003DzvVtY_GumbMMFvpojLYi3Ahg_003D.Center.Clone();
		bool num = _0023_003Dzfm4oGj8_003D.Radius > _0023_003DzvVtY_GumbMMFvpojLYi3Ahg_003D.Radius && _0023_003Dzfm4oGj8_003D.Radius > _0023_003DzvVtY_GumbMMFvpojLYi3Ahg_003D.Center.DistanceTo(_0023_003Dzfm4oGj8_003D.Center);
		bool flag = _0023_003DzCVdPoWM_003D.Radius > _0023_003DzvVtY_GumbMMFvpojLYi3Ahg_003D.Radius && _0023_003DzCVdPoWM_003D.Radius > _0023_003DzvVtY_GumbMMFvpojLYi3Ahg_003D.Center.DistanceTo(_0023_003DzCVdPoWM_003D.Center);
		Vector3D vector3D = ((!num) ? new Vector3D(point3D, (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone()) : (-1.0 * new Vector3D(point3D, (Point3D)_0023_003Dzfm4oGj8_003D.Center.Clone())));
		Vector3D vector3D2 = ((!flag) ? new Vector3D(point3D, (Point3D)_0023_003DzCVdPoWM_003D.Center.Clone()) : (-1.0 * new Vector3D(point3D, (Point3D)_0023_003DzCVdPoWM_003D.Center.Clone())));
		vector3D.Normalize();
		vector3D2.Normalize();
		Point3D point = point3D + _0023_003DzvVtY_GumbMMFvpojLYi3Ahg_003D.Radius * vector3D;
		Point3D point2 = point3D + _0023_003DzvVtY_GumbMMFvpojLYi3Ahg_003D.Radius * vector3D2;
		if ((!_0023_003DzNQ7gPu8_0024wZ9N || point.IsOnCurve(_0023_003Dzfm4oGj8_003D, _0023_003Dzm0CYiiE_003D)) && (!_0023_003DzLNH2gQMaz9wi || point2.IsOnCurve(_0023_003DzCVdPoWM_003D, _0023_003Dzm0CYiiE_003D)))
		{
			return true;
		}
		return false;
	}

	public static int GetLinesTangentToCircleFromPoint(Circle c, Point3D pt, out Line[] tangentSegments)
	{
		double _0023_003DzccAR5G0_003D;
		Line[] array = _0023_003DzGNm6Yfr41eMBirPaTGpkCmJvOvIf(c, pt, out _0023_003DzccAR5G0_003D);
		tangentSegments = null;
		double maxGap = _0023_003DzccAR5G0_003D * _0023_003DzxhnLabVjXjPg;
		if (array[0] == null && array[1] == null)
		{
			tangentSegments = new Line[0];
			return 0;
		}
		if (c is Arc)
		{
			List<Line> list = new List<Line>();
			foreach (Line line in array)
			{
				if (line.EndPoint.IsOnCurve(c, maxGap))
				{
					list.Add(line);
				}
			}
			tangentSegments = list.ToArray();
			return tangentSegments.Length;
		}
		tangentSegments = array;
		return 2;
	}

	public static Line[] GetLinesTangentToCircleFromPoint(Circle c, Point3D pt)
	{
		double _0023_003DzccAR5G0_003D;
		return _0023_003DzGNm6Yfr41eMBirPaTGpkCmJvOvIf(c, pt, out _0023_003DzccAR5G0_003D);
	}

	private static Line[] _0023_003DzGNm6Yfr41eMBirPaTGpkCmJvOvIf(Circle _0023_003DzeQOQKfAqtAvt, Point3D _0023_003Dz_wBQFrxhapUV, out double _0023_003DzccAR5G0_003D)
	{
		Point3D center = _0023_003DzeQOQKfAqtAvt.Center;
		double radius = _0023_003DzeQOQKfAqtAvt.Radius;
		double num = _0023_003Dz_wBQFrxhapUV.DistanceTo(center);
		_0023_003DzccAR5G0_003D = Math.Max(radius, num);
		double tol = _0023_003DzccAR5G0_003D * _0023_003DzxhnLabVjXjPg;
		Line[] array = new Line[2];
		Plane plane = _0023_003DzeQOQKfAqtAvt.Plane;
		double a = Math.Abs(plane.DistanceTo(_0023_003Dz_wBQFrxhapUV));
		if (Compare(tol, a, 0.0) != 0)
		{
			return array;
		}
		if (Compare(tol, num, radius) <= 0)
		{
			return array;
		}
		double radius2 = Math.Sqrt(num * num - radius * radius);
		Circle arc = new Circle(plane, _0023_003Dz_wBQFrxhapUV, radius2);
		if (IntersectionCircleCircle(new Circle(plane, center, radius), arc, plane, out var i, out var i2))
		{
			array[0] = new Line(_0023_003Dz_wBQFrxhapUV, i);
			array[1] = new Line(_0023_003Dz_wBQFrxhapUV, i2);
		}
		return array;
	}

	internal static bool _0023_003Dz4DFkbZmBwKQn(double _0023_003Dz6pajdGM_003D, Interval _0023_003DzzJ_0024HnAY_003D, out double _0023_003DzMSkhoo0y_0024u25)
	{
		double low = _0023_003DzzJ_0024HnAY_003D.Low;
		double high = _0023_003DzzJ_0024HnAY_003D.High;
		if (low > high)
		{
			_0023_003DzzJ_0024HnAY_003D = new Interval(high, low);
		}
		_0023_003DzMSkhoo0y_0024u25 = _0023_003Dz6pajdGM_003D;
		if (_0023_003DzzJ_0024HnAY_003D._0023_003DzNoPt9TsyzDMJ(_0023_003DzMSkhoo0y_0024u25))
		{
			return true;
		}
		if (_0023_003DzMSkhoo0y_0024u25 > _0023_003DzzJ_0024HnAY_003D.High + 1E-12)
		{
			while (_0023_003DzMSkhoo0y_0024u25 > _0023_003DzzJ_0024HnAY_003D.High)
			{
				_0023_003DzMSkhoo0y_0024u25 -= Math.PI * 2.0;
			}
		}
		else if (_0023_003DzMSkhoo0y_0024u25 < _0023_003DzzJ_0024HnAY_003D.Low - 1E-12)
		{
			while (_0023_003DzMSkhoo0y_0024u25 < _0023_003DzzJ_0024HnAY_003D.Low)
			{
				_0023_003DzMSkhoo0y_0024u25 += Math.PI * 2.0;
			}
		}
		if (_0023_003DzzJ_0024HnAY_003D._0023_003DzNoPt9TsyzDMJ(_0023_003DzMSkhoo0y_0024u25))
		{
			return true;
		}
		return false;
	}

	public static double TetrahedronVolume(Point3D p1, Point3D p2, Point3D p3, Point3D p4)
	{
		double num = p1.DistanceTo(p2);
		double num2 = p1.DistanceTo(p3);
		double num3 = p1.DistanceTo(p4);
		double num4 = p2.DistanceTo(p3);
		double num5 = p2.DistanceTo(p4);
		double num6 = p3.DistanceTo(p4);
		double num7 = num * num;
		double num8 = num2 * num2;
		double num9 = num3 * num3;
		double num10 = num4 * num4;
		double num11 = num5 * num5;
		double num12 = num6 * num6;
		double num13 = num8 + num9 - num12;
		double num14 = num9 + num7 - num11;
		double num15 = num7 + num8 - num10;
		return Math.Sqrt(Math.Max(0.0, 4.0 * num7 * num8 * num9 - num7 * num13 * num13 - num8 * num14 * num14 - num9 * num15 * num15 + num13 * num14 * num15)) / 12.0;
	}

	public static double PentahedronVolume(Point3D p1, Point3D p2, Point3D p3, Point3D p4, Point3D p5, Point3D p6)
	{
		return TetrahedronVolume(p1, p2, p3, p4) + TetrahedronVolume(p2, p3, p4, p5) + TetrahedronVolume(p3, p4, p5, p6);
	}

	public static double HexahedronVolume(Point3D p1, Point3D p2, Point3D p3, Point3D p4, Point3D p5, Point3D p6, Point3D p7, Point3D p8)
	{
		return TetrahedronVolume(p1, p3, p6, p8) + TetrahedronVolume(p1, p2, p3, p6) + TetrahedronVolume(p1, p5, p6, p8) + TetrahedronVolume(p1, p3, p4, p8) + TetrahedronVolume(p3, p6, p7, p8);
	}

	public static IndexTriangle[] MakeFace(Plane pln, IList<int> outerLoop, IList<IList<int>> innerLoops, IList<Point3D> vertexList)
	{
		Plane xY = Plane.XY;
		Transformation transformation = new Transformation();
		transformation.Rotation(pln.Origin, pln.AxisX, pln.AxisY, pln.AxisZ, xY.Origin, xY.AxisX, xY.AxisY, xY.AxisZ);
		Point2D[] array = new Point2D[outerLoop.Count];
		for (int i = 0; i < outerLoop.Count; i++)
		{
			double[] array2 = vertexList[outerLoop[i]].ToArray();
			array[i] = transformation * new Point3D(array2[0], array2[1]);
		}
		IList<IList<Point2D>> list = null;
		if (innerLoops != null)
		{
			list = new List<IList<Point2D>>();
			for (int j = 0; j < innerLoops.Count; j++)
			{
				list[j] = new Point2D[innerLoops[j].Count];
				for (int k = 0; k < innerLoops[j].Count; k++)
				{
					double[] array3 = vertexList[innerLoops[j][k]].ToArray();
					list[j][k] = transformation * new Point2D(array3[0], array3[1]);
				}
			}
		}
		Triangulate(array, list, fixOrientation: true, checkValidity: false, out var _, out var triangles);
		return triangles;
	}

	public static IndexTriangle[] MakeFace(Plane pln, IList<IList<int>> loops, IList<Point3D> vertexList, bool checkForOuter)
	{
		if (!checkForOuter)
		{
			IList<int>[] array = new IList<int>[loops.Count - 1];
			for (int i = 1; i < loops.Count; i++)
			{
				array[i - 1] = loops[i];
			}
			return MakeFace(pln, loops[0], array, vertexList);
		}
		_0023_003DzrKw0B9PWjq_P(pln, loops, vertexList, out var _0023_003DzJB9yXb3atfkL, out var _0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D);
		_0023_003DzG8r7N_0024gcHhrIOyP09w_003D_003D(_0023_003DzJB9yXb3atfkL, _0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D, _0023_003Dz275RophIENHO: false, out var _, out var _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D);
		return _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D;
	}

	private static void _0023_003DzrKw0B9PWjq_P(Plane _0023_003Dzpyw2kZk_003D, IList<IList<int>> _0023_003Dzcv8o5nO25OjS, IList<Point3D> _0023_003Dz7pqWuheV0uU_0024, out _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[] _0023_003DzJB9yXb3atfkL, out _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[][] _0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D)
	{
		Plane xY = Plane.XY;
		Transformation transformation = new Transformation();
		transformation.Rotation(_0023_003Dzpyw2kZk_003D.Origin, _0023_003Dzpyw2kZk_003D.AxisX, _0023_003Dzpyw2kZk_003D.AxisY, _0023_003Dzpyw2kZk_003D.AxisZ, xY.Origin, xY.AxisX, xY.AxisY, xY.AxisZ);
		_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[][] array = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[_0023_003Dzcv8o5nO25OjS.Count][];
		for (int i = 0; i < _0023_003Dzcv8o5nO25OjS.Count; i++)
		{
			array[i] = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[_0023_003Dzcv8o5nO25OjS[i].Count];
			for (int j = 0; j < _0023_003Dzcv8o5nO25OjS[i].Count; j++)
			{
				Point3D _0023_003DzMlCq3wk_003D = transformation * _0023_003Dz7pqWuheV0uU_0024[_0023_003Dzcv8o5nO25OjS[i][j]];
				array[i][j] = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D(_0023_003Dzcv8o5nO25OjS[i][j], _0023_003DzMlCq3wk_003D);
			}
		}
		int num = _0023_003DzZqV8ENZ1fZiA(array);
		_0023_003DzJB9yXb3atfkL = array[num];
		_0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D = null;
		if (array.Length <= 1)
		{
			return;
		}
		_0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D = new _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[array.Length - 1][];
		int num2 = 0;
		for (int k = 0; k < array.Length; k++)
		{
			if (k != num)
			{
				_0023_003DzLYWjuc33iWj_BX5R_0024A_003D_003D[num2++] = array[k];
			}
		}
	}

	private static int _0023_003DzZqV8ENZ1fZiA(IList<_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[]> _0023_003Dzcv8o5nO25OjS)
	{
		int num = 0;
		int count = _0023_003Dzcv8o5nO25OjS.Count;
		for (int i = 0; i < count; i++)
		{
			if (i != num)
			{
				_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[] array = _0023_003Dzcv8o5nO25OjS[i];
				if (num < count && !_0023_003DzlgkUJVvf16gK(array[0], _0023_003Dzcv8o5nO25OjS[num]))
				{
					num++;
					i = -1;
				}
			}
		}
		if (num >= count)
		{
			return -1;
		}
		return num;
	}

	private static bool _0023_003DzlgkUJVvf16gK(_0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D _0023_003DzZTe_0024jFG9ebLg, _0023_003DzRV5GhlIkprjwXRkNGMknXBOYrewR09oqf_lNIvRxwZpVBQ6mcQ_003D_003D[] _0023_003DzN57VxTE7ZsCw)
	{
		int num = _0023_003DzN57VxTE7ZsCw.Length;
		int num2 = 0;
		int num3 = 0;
		int num4 = num - 1;
		while (num3 < num)
		{
			double[] array = _0023_003DzN57VxTE7ZsCw[num3].ToArray();
			double[] array2 = _0023_003DzN57VxTE7ZsCw[num4].ToArray();
			double[] array3 = _0023_003DzZTe_0024jFG9ebLg.ToArray();
			if (((array[1] <= array3[1] && array3[1] < array2[1]) || (array2[1] <= array3[1] && array3[1] < array[1])) && array3[0] < (array2[0] - array[0]) * (array3[1] - array[1]) / (array2[1] - array[1]) + array[0])
			{
				num2++;
			}
			num4 = num3++;
		}
		return (num2 & 1) == 1;
	}

	public static Plane FitPlane(IList<Point3D> points)
	{
		int count = points.Count;
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		for (int i = 0; i < count; i++)
		{
			Point3D point3D = points[i];
			num += point3D.X;
			num2 += point3D.Y;
			num3 += point3D.Z;
		}
		num /= (double)count;
		num2 /= (double)count;
		num3 /= (double)count;
		double[,] array = new double[3, 3];
		for (int j = 0; j < count; j++)
		{
			Point3D point3D2 = points[j];
			double num4 = point3D2.X - num;
			double num5 = point3D2.Y - num2;
			double num6 = point3D2.Z - num3;
			array[0, 0] += num4 * num4;
			array[0, 1] += num4 * num5;
			array[0, 2] += num4 * num6;
			array[1, 0] += num5 * num4;
			array[1, 1] += num5 * num5;
			array[1, 2] += num5 * num6;
			array[2, 0] += num6 * num4;
			array[2, 1] += num6 * num5;
			array[2, 2] += num6 * num6;
		}
		SortedList<double, Vector3D> sortedList = _0023_003DzC5kNm5vfoNVpxZo3I2TXfpQ_003D(array);
		return new Plane(new Point3D(num, num2, num3), sortedList.Values[0]);
	}

	public static Plane FitPlane(float[] points)
	{
		int num = points.Length;
		if (num % 3 != 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661319));
		}
		int num2 = num / 3;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		for (int i = 0; i < num; i += 3)
		{
			num3 += (double)points[i];
			num4 += (double)points[i + 1];
			num5 += (double)points[i + 2];
		}
		num3 /= (double)num2;
		num4 /= (double)num2;
		num5 /= (double)num2;
		double[,] array = new double[3, 3];
		for (int j = 0; j < num; j += 3)
		{
			double num6 = (double)points[j] - num3;
			double num7 = (double)points[j + 1] - num4;
			double num8 = (double)points[j + 2] - num5;
			array[0, 0] += num6 * num6;
			array[0, 1] += num6 * num7;
			array[0, 2] += num6 * num8;
			array[1, 0] += num7 * num6;
			array[1, 1] += num7 * num7;
			array[1, 2] += num7 * num8;
			array[2, 0] += num8 * num6;
			array[2, 1] += num8 * num7;
			array[2, 2] += num8 * num8;
		}
		SortedList<double, Vector3D> sortedList = _0023_003DzC5kNm5vfoNVpxZo3I2TXfpQ_003D(array);
		return new Plane(new Point3D(num3, num4, num5), sortedList.Values[0]);
	}

	public static void FitLine(IList<Point3D> points, out Point3D p, out Vector3D dir)
	{
		int count = points.Count;
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		for (int i = 0; i < count; i++)
		{
			Point3D point3D = points[i];
			num += point3D.X;
			num2 += point3D.Y;
			num3 += point3D.Z;
		}
		num /= (double)count;
		num2 /= (double)count;
		num3 /= (double)count;
		double num4 = 0.0;
		for (int j = 0; j < count; j++)
		{
			Point3D point3D2 = points[j];
			double num5 = point3D2.X - num;
			double num6 = point3D2.Y - num2;
			double num7 = point3D2.Z - num3;
			num4 += num5 * num5 + num6 * num6 + num7 * num7;
		}
		double[,] array = new double[3, 3];
		for (int k = 0; k < count; k++)
		{
			Point3D point3D3 = points[k];
			double num8 = point3D3.X - num;
			double num9 = point3D3.Y - num2;
			double num10 = point3D3.Z - num3;
			array[0, 0] -= num8 * num8;
			array[0, 1] -= num8 * num9;
			array[0, 2] -= num8 * num10;
			array[1, 0] -= num9 * num8;
			array[1, 1] -= num9 * num9;
			array[1, 2] -= num9 * num10;
			array[2, 0] -= num10 * num8;
			array[2, 1] -= num10 * num9;
			array[2, 2] -= num10 * num10;
		}
		array[0, 0] += num4;
		array[1, 1] += num4;
		array[2, 2] += num4;
		SortedList<double, Vector3D> sortedList = _0023_003DzC5kNm5vfoNVpxZo3I2TXfpQ_003D(array);
		p = new Point3D(num, num2, num3);
		dir = sortedList.Values[0];
	}

	public static void FitLine(float[] points, out Point3D p, out Vector3D dir)
	{
		int num = points.Length;
		if (num % 3 != 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661319));
		}
		int num2 = num / 3;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		for (int i = 0; i < num; i += 3)
		{
			num3 += (double)points[i];
			num4 += (double)points[i + 1];
			num5 += (double)points[i + 2];
		}
		num3 /= (double)num2;
		num4 /= (double)num2;
		num5 /= (double)num2;
		double num6 = 0.0;
		for (int j = 0; j < num; j += 3)
		{
			double num7 = (double)points[j] - num3;
			double num8 = (double)points[j + 1] - num4;
			double num9 = (double)points[j + 2] - num5;
			num6 += num7 * num7 + num8 * num8 + num9 * num9;
		}
		double[,] array = new double[3, 3];
		for (int k = 0; k < num; k += 3)
		{
			double num10 = (double)points[k] - num3;
			double num11 = (double)points[k + 1] - num4;
			double num12 = (double)points[k + 2] - num5;
			array[0, 0] -= num10 * num10;
			array[0, 1] -= num10 * num11;
			array[0, 2] -= num10 * num12;
			array[1, 0] -= num11 * num10;
			array[1, 1] -= num11 * num11;
			array[1, 2] -= num11 * num12;
			array[2, 0] -= num12 * num10;
			array[2, 1] -= num12 * num11;
			array[2, 2] -= num12 * num12;
		}
		array[0, 0] += num6;
		array[1, 1] += num6;
		array[2, 2] += num6;
		SortedList<double, Vector3D> sortedList = _0023_003DzC5kNm5vfoNVpxZo3I2TXfpQ_003D(array);
		p = new Point3D(num3, num4, num5);
		dir = sortedList.Values[0];
	}

	public static void FitCircle(IList<Point2D> pts2D, out Point2D center, out double radius)
	{
		double num = pts2D.Count;
		double num2 = 0.0;
		double num3 = 0.0;
		foreach (Point2D item in pts2D)
		{
			num2 += item.X;
			num3 += item.Y;
		}
		num2 /= num;
		num3 /= num;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		foreach (Point2D item2 in pts2D)
		{
			double num11 = item2.X - num2;
			double num12 = item2.Y - num3;
			num4 += num11 * num12;
			num5 += num11 * num11;
			num6 += num12 * num12;
			num7 += num11 * num11 * num12;
			num8 += num11 * num12 * num12;
			num9 += num11 * num11 * num11;
			num10 += num12 * num12 * num12;
		}
		double d = (num9 + num8) / 2.0;
		double d2 = (num7 + num10) / 2.0;
		Solve2x2(num5, num4, num4, num6, d, d2, out var x_addr, out var y_addr, out var _);
		double num13 = num2 + x_addr;
		double num14 = num3 + y_addr;
		radius = 0.0;
		foreach (Point2D item3 in pts2D)
		{
			radius += Math.Sqrt((item3.X - num13) * (item3.X - num13) + (item3.Y - num14) * (item3.Y - num14));
		}
		radius /= num;
		center = new Point2D(num13, num14);
	}

	public static void FitCircle(IList<Point3D> pts, out Plane plane, out double radius)
	{
		Plane plane2 = FitPlane(pts);
		int count = pts.Count;
		List<Point2D> list = new List<Point2D>();
		for (int i = 0; i < count; i++)
		{
			list.Add(plane2.Project(pts[i]));
		}
		FitCircle(list, out var center, out radius);
		plane = new Plane(plane2.PointAt(center), plane2.AxisZ);
	}

	public static void FitCircle(float[] pts, out Plane plane, out double radius)
	{
		int num = pts.Length;
		if (num % 3 != 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661319));
		}
		_ = num / 3;
		Plane plane2 = FitPlane(pts);
		List<Point2D> list = new List<Point2D>();
		for (int i = 0; i < num; i += 3)
		{
			list.Add(plane2.Project(new Point3D(pts[i], pts[i + 1], pts[i + 2])));
		}
		FitCircle(list, out var center, out radius);
		plane = new Plane(plane2.PointAt(center), plane2.AxisZ);
	}

	internal static void _0023_003DzQblHGY4s1vkJ(double[,] _0023_003DzjbqS1qE_003D, out double[] _0023_003DzAvn2b38_003D, out double[,] _0023_003Dz77g161c_003D)
	{
		int length = _0023_003DzjbqS1qE_003D.GetLength(0);
		int length2 = _0023_003DzjbqS1qE_003D.GetLength(1);
		int num = 0;
		int num2 = 0;
		double[] array = new double[length2];
		_0023_003DzAvn2b38_003D = new double[length2];
		_0023_003Dz77g161c_003D = new double[length2, length2];
		double num5;
		double num4;
		double num3 = (num4 = (num5 = 0.0));
		for (int i = 0; i < length2; i++)
		{
			num = i + 2;
			array[i] = num4 * num3;
			double num6;
			num3 = (num6 = (num4 = 0.0));
			if (i < length)
			{
				for (int j = i; j < length; j++)
				{
					num4 += Math.Abs(_0023_003DzjbqS1qE_003D[j, i]);
				}
				if (num4 != 0.0)
				{
					for (int j = i; j < length; j++)
					{
						_0023_003DzjbqS1qE_003D[j, i] /= num4;
						num6 += _0023_003DzjbqS1qE_003D[j, i] * _0023_003DzjbqS1qE_003D[j, i];
					}
					double num7 = _0023_003DzjbqS1qE_003D[i, i];
					num3 = 0.0 - _0023_003DzpO_OgmU_003D(Math.Sqrt(num6), num7);
					double num8 = num7 * num3 - num6;
					_0023_003DzjbqS1qE_003D[i, i] = num7 - num3;
					for (int k = num - 1; k < length2; k++)
					{
						num6 = 0.0;
						for (int j = i; j < length; j++)
						{
							num6 += _0023_003DzjbqS1qE_003D[j, i] * _0023_003DzjbqS1qE_003D[j, k];
						}
						num7 = num6 / num8;
						for (int j = i; j < length; j++)
						{
							_0023_003DzjbqS1qE_003D[j, k] += num7 * _0023_003DzjbqS1qE_003D[j, i];
						}
					}
					for (int j = i; j < length; j++)
					{
						_0023_003DzjbqS1qE_003D[j, i] *= num4;
					}
				}
			}
			_0023_003DzAvn2b38_003D[i] = num4 * num3;
			num3 = (num6 = (num4 = 0.0));
			if (i + 1 <= length && i + 1 != length2)
			{
				for (int j = num - 1; j < length2; j++)
				{
					num4 += Math.Abs(_0023_003DzjbqS1qE_003D[i, j]);
				}
				if (num4 != 0.0)
				{
					for (int j = num - 1; j < length2; j++)
					{
						_0023_003DzjbqS1qE_003D[i, j] /= num4;
						num6 += _0023_003DzjbqS1qE_003D[i, j] * _0023_003DzjbqS1qE_003D[i, j];
					}
					double num7 = _0023_003DzjbqS1qE_003D[i, num - 1];
					num3 = 0.0 - _0023_003DzpO_OgmU_003D(Math.Sqrt(num6), num7);
					double num8 = num7 * num3 - num6;
					_0023_003DzjbqS1qE_003D[i, num - 1] = num7 - num3;
					for (int j = num - 1; j < length2; j++)
					{
						array[j] = _0023_003DzjbqS1qE_003D[i, j] / num8;
					}
					for (int k = num - 1; k < length; k++)
					{
						num6 = 0.0;
						for (int j = num - 1; j < length2; j++)
						{
							num6 += _0023_003DzjbqS1qE_003D[k, j] * _0023_003DzjbqS1qE_003D[i, j];
						}
						for (int j = num - 1; j < length2; j++)
						{
							_0023_003DzjbqS1qE_003D[k, j] += num6 * array[j];
						}
					}
					for (int j = num - 1; j < length2; j++)
					{
						_0023_003DzjbqS1qE_003D[i, j] *= num4;
					}
				}
			}
			num5 = Math.Max(num5, Math.Abs(_0023_003DzAvn2b38_003D[i]) + Math.Abs(array[i]));
		}
		for (int i = length2 - 1; i >= 0; i--)
		{
			if (i < length2 - 1)
			{
				if (num3 != 0.0)
				{
					for (int k = num; k < length2; k++)
					{
						_0023_003Dz77g161c_003D[k, i] = _0023_003DzjbqS1qE_003D[i, k] / _0023_003DzjbqS1qE_003D[i, num] / num3;
					}
					for (int k = num; k < length2; k++)
					{
						double num6 = 0.0;
						for (int j = num; j < length2; j++)
						{
							num6 += _0023_003DzjbqS1qE_003D[i, j] * _0023_003Dz77g161c_003D[j, k];
						}
						for (int j = num; j < length2; j++)
						{
							_0023_003Dz77g161c_003D[j, k] += num6 * _0023_003Dz77g161c_003D[j, i];
						}
					}
				}
				for (int k = num; k < length2; k++)
				{
					_0023_003Dz77g161c_003D[i, k] = (_0023_003Dz77g161c_003D[k, i] = 0.0);
				}
			}
			_0023_003Dz77g161c_003D[i, i] = 1.0;
			num3 = array[i];
			num = i;
		}
		for (int i = Math.Min(length, length2) - 1; i >= 0; i--)
		{
			num = i + 1;
			num3 = _0023_003DzAvn2b38_003D[i];
			for (int k = num; k < length2; k++)
			{
				_0023_003DzjbqS1qE_003D[i, k] = 0.0;
			}
			if (num3 != 0.0)
			{
				num3 = 1.0 / num3;
				for (int k = num; k < length2; k++)
				{
					double num6 = 0.0;
					for (int j = num; j < length; j++)
					{
						num6 += _0023_003DzjbqS1qE_003D[j, i] * _0023_003DzjbqS1qE_003D[j, k];
					}
					double num7 = num6 / _0023_003DzjbqS1qE_003D[i, i] * num3;
					for (int j = i; j < length; j++)
					{
						_0023_003DzjbqS1qE_003D[j, k] += num7 * _0023_003DzjbqS1qE_003D[j, i];
					}
				}
				for (int k = i; k < length; k++)
				{
					_0023_003DzjbqS1qE_003D[k, i] *= num3;
				}
			}
			else
			{
				for (int k = i; k < length; k++)
				{
					_0023_003DzjbqS1qE_003D[k, i] = 0.0;
				}
			}
			_0023_003DzjbqS1qE_003D[i, i] += 1.0;
		}
		for (int j = length2 - 1; j >= 0; j--)
		{
			for (int l = 0; l < 30; l++)
			{
				bool flag = true;
				for (num = j; num >= 0; num--)
				{
					num2 = num - 1;
					if (Math.Abs(array[num]) + num5 == num5)
					{
						flag = false;
						break;
					}
					if (Math.Abs(_0023_003DzAvn2b38_003D[num2]) + num5 == num5)
					{
						break;
					}
				}
				double num9;
				double num6;
				double num7;
				double num8;
				double num10;
				double num11;
				if (flag)
				{
					num9 = 0.0;
					num6 = 1.0;
					for (int i = num; i < j + 1; i++)
					{
						num7 = num6 * array[i];
						array[i] = num9 * array[i];
						if (Math.Abs(num7) + num5 == num5)
						{
							break;
						}
						num3 = _0023_003DzAvn2b38_003D[i];
						num8 = _0023_003DzxXocPuwczc67(num7, num3);
						_0023_003DzAvn2b38_003D[i] = num8;
						num8 = 1.0 / num8;
						num9 = num3 * num8;
						num6 = (0.0 - num7) * num8;
						for (int k = 0; k < length; k++)
						{
							num10 = _0023_003DzjbqS1qE_003D[k, num2];
							num11 = _0023_003DzjbqS1qE_003D[k, i];
							_0023_003DzjbqS1qE_003D[k, num2] = num10 * num9 + num11 * num6;
							_0023_003DzjbqS1qE_003D[k, i] = num11 * num9 - num10 * num6;
						}
					}
				}
				num11 = _0023_003DzAvn2b38_003D[j];
				if (num == j)
				{
					if (num11 < 0.0)
					{
						_0023_003DzAvn2b38_003D[j] = 0.0 - num11;
						for (int k = 0; k < length2; k++)
						{
							_0023_003Dz77g161c_003D[k, j] = 0.0 - _0023_003Dz77g161c_003D[k, j];
						}
					}
					break;
				}
				if (l == 29)
				{
					throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661956));
				}
				double num12 = _0023_003DzAvn2b38_003D[num];
				num2 = j - 1;
				num10 = _0023_003DzAvn2b38_003D[num2];
				num3 = array[num2];
				num8 = array[j];
				num7 = ((num10 - num11) * (num10 + num11) + (num3 - num8) * (num3 + num8)) / (2.0 * num8 * num10);
				num3 = _0023_003DzxXocPuwczc67(num7, 1.0);
				num7 = ((num12 - num11) * (num12 + num11) + num8 * (num10 / (num7 + _0023_003DzpO_OgmU_003D(num3, num7)) - num8)) / num12;
				num9 = (num6 = 1.0);
				for (int k = num; k <= num2; k++)
				{
					int i = k + 1;
					num3 = array[i];
					num10 = _0023_003DzAvn2b38_003D[i];
					num8 = num6 * num3;
					num3 = num9 * num3;
					num11 = (array[k] = _0023_003DzxXocPuwczc67(num7, num8));
					num9 = num7 / num11;
					num6 = num8 / num11;
					num7 = num12 * num9 + num3 * num6;
					num3 = num3 * num9 - num12 * num6;
					num8 = num10 * num6;
					num10 *= num9;
					for (int m = 0; m < length2; m++)
					{
						num12 = _0023_003Dz77g161c_003D[m, k];
						num11 = _0023_003Dz77g161c_003D[m, i];
						_0023_003Dz77g161c_003D[m, k] = num12 * num9 + num11 * num6;
						_0023_003Dz77g161c_003D[m, i] = num11 * num9 - num12 * num6;
					}
					num11 = _0023_003DzxXocPuwczc67(num7, num8);
					_0023_003DzAvn2b38_003D[k] = num11;
					if (num11 != 0.0)
					{
						num11 = 1.0 / num11;
						num9 = num7 * num11;
						num6 = num8 * num11;
					}
					num7 = num9 * num3 + num6 * num10;
					num12 = num9 * num10 - num6 * num3;
					for (int m = 0; m < length; m++)
					{
						num10 = _0023_003DzjbqS1qE_003D[m, k];
						num11 = _0023_003DzjbqS1qE_003D[m, i];
						_0023_003DzjbqS1qE_003D[m, k] = num10 * num9 + num11 * num6;
						_0023_003DzjbqS1qE_003D[m, i] = num11 * num9 - num10 * num6;
					}
				}
				array[num] = 0.0;
				array[j] = num7;
				_0023_003DzAvn2b38_003D[j] = num12;
			}
		}
	}

	private static double _0023_003DzxXocPuwczc67(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D)
	{
		double num = Math.Abs(_0023_003DzjbqS1qE_003D);
		double num2 = Math.Abs(_0023_003Dz1v6oPQk_003D);
		if (num > num2)
		{
			return num * Math.Sqrt(1.0 + _0023_003DzwkW2huc_003D(num2 / num));
		}
		if (num2 != 0.0)
		{
			return num2 * Math.Sqrt(1.0 + _0023_003DzwkW2huc_003D(num / num2));
		}
		return 0.0;
	}

	private static double _0023_003DzwkW2huc_003D(double _0023_003DzjbqS1qE_003D)
	{
		return _0023_003DzjbqS1qE_003D * _0023_003DzjbqS1qE_003D;
	}

	private static double _0023_003DzpO_OgmU_003D(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D)
	{
		if (!(_0023_003Dz1v6oPQk_003D >= 0.0))
		{
			if (!(_0023_003DzjbqS1qE_003D >= 0.0))
			{
				return _0023_003DzjbqS1qE_003D;
			}
			return 0.0 - _0023_003DzjbqS1qE_003D;
		}
		if (!(_0023_003DzjbqS1qE_003D >= 0.0))
		{
			return 0.0 - _0023_003DzjbqS1qE_003D;
		}
		return _0023_003DzjbqS1qE_003D;
	}

	internal static bool _0023_003DzNY5YUv279_SW(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D, Point3D _0023_003Dzm4eSPQQ_003D, out Plane _0023_003Dzrgqz890sj_0024X9)
	{
		Vector3D vector3D = new Vector3D(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D, _0023_003Dzm4eSPQQ_003D);
		if (!vector3D.IsZero)
		{
			_0023_003Dzrgqz890sj_0024X9 = new Plane(_0023_003DzFj_0024IqDQ_003D, vector3D);
			return true;
		}
		_0023_003Dzrgqz890sj_0024X9 = null;
		return false;
	}

	private static SortedList<double, Vector3D> _0023_003DzC5kNm5vfoNVpxZo3I2TXfpQ_003D(double[,] _0023_003DzDtqAooE_003D)
	{
		_0023_003DzQblHGY4s1vkJ(_0023_003DzDtqAooE_003D, out var _0023_003DzAvn2b38_003D, out var _0023_003Dz77g161c_003D);
		SortedList<double, Vector3D> sortedList = new SortedList<double, Vector3D>(3);
		sortedList.Add(_0023_003DzAvn2b38_003D[0], new Vector3D(_0023_003Dz77g161c_003D[0, 0], _0023_003Dz77g161c_003D[1, 0], _0023_003Dz77g161c_003D[2, 0]));
		if (!sortedList.ContainsKey(_0023_003DzAvn2b38_003D[1]))
		{
			sortedList.Add(_0023_003DzAvn2b38_003D[1], new Vector3D(_0023_003Dz77g161c_003D[0, 1], _0023_003Dz77g161c_003D[1, 1], _0023_003Dz77g161c_003D[2, 1]));
		}
		if (!sortedList.ContainsKey(_0023_003DzAvn2b38_003D[2]))
		{
			sortedList.Add(_0023_003DzAvn2b38_003D[2], new Vector3D(_0023_003Dz77g161c_003D[0, 2], _0023_003Dz77g161c_003D[1, 2], _0023_003Dz77g161c_003D[2, 2]));
		}
		return sortedList;
	}

	public static void FitCylinder(IList<Point3D> points, bool refineEstimation, out Point3D center, out Vector3D axis, out double radius, out double height)
	{
		int count = points.Count;
		if (count < 5)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661935));
		}
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		for (int i = 0; i < count; i++)
		{
			Point3D point3D = points[i];
			num += point3D.X;
			num2 += point3D.Y;
			num3 += point3D.Z;
		}
		num /= (double)count;
		num2 /= (double)count;
		num3 /= (double)count;
		double[,] array = new double[3, 3];
		Matrix<double> matrix = Matrix<double>.Build.Dense(count, 3);
		for (int j = 0; j < count; j++)
		{
			Point3D point3D2 = points[j];
			double num4 = point3D2.X - num;
			double num5 = point3D2.Y - num2;
			double num6 = point3D2.Z - num3;
			array[0, 0] += num4 * num4;
			array[0, 1] += num4 * num5;
			array[0, 2] += num4 * num6;
			array[1, 0] += num5 * num4;
			array[1, 1] += num5 * num5;
			array[1, 2] += num5 * num6;
			array[2, 0] += num6 * num4;
			array[2, 1] += num6 * num5;
			array[2, 2] += num6 * num6;
			matrix[j, 0] = num4;
			matrix[j, 1] = num5;
			matrix[j, 2] = num6;
		}
		_0023_003Dzs8xwThpSc8Lh8cfD1w_003D_003D(refineEstimation, array, matrix, out center, out axis, out radius);
		_0023_003DzzYe9fz4B_0024zLq(center, axis, matrix, out var _0023_003DzsVw1i9LkTBtX, out var _0023_003DzbdEewMMmMxDg);
		height = Math.Abs(_0023_003DzbdEewMMmMxDg - _0023_003DzsVw1i9LkTBtX);
		center.X += num;
		center.Y += num2;
		center.Z += num3;
		center -= Math.Abs(_0023_003DzsVw1i9LkTBtX) * axis;
	}

	public static void FitCylinder(float[] points, bool refineEstimation, out Point3D center, out Vector3D axis, out double radius, out double height)
	{
		int num = points.Length;
		if (num % 3 != 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661319));
		}
		int num2 = num / 3;
		if (num2 < 5)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661935));
		}
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		for (int i = 0; i < num; i += 3)
		{
			num3 += (double)points[i];
			num4 += (double)points[i + 1];
			num5 += (double)points[i + 2];
		}
		num3 /= (double)num2;
		num4 /= (double)num2;
		num5 /= (double)num2;
		double[,] array = new double[3, 3];
		Matrix<double> matrix = Matrix<double>.Build.Dense(num2, 3);
		for (int j = 0; j < num; j += 3)
		{
			double num6 = (double)points[j] - num3;
			double num7 = (double)points[j + 1] - num4;
			double num8 = (double)points[j + 2] - num5;
			array[0, 0] += num6 * num6;
			array[0, 1] += num6 * num7;
			array[0, 2] += num6 * num8;
			array[1, 0] += num7 * num6;
			array[1, 1] += num7 * num7;
			array[1, 2] += num7 * num8;
			array[2, 0] += num8 * num6;
			array[2, 1] += num8 * num7;
			array[2, 2] += num8 * num8;
			int row = j / 3;
			matrix[row, 0] = num6;
			matrix[row, 1] = num7;
			matrix[row, 2] = num8;
		}
		_0023_003Dzs8xwThpSc8Lh8cfD1w_003D_003D(refineEstimation, array, matrix, out center, out axis, out radius);
		_0023_003DzzYe9fz4B_0024zLq(center, axis, matrix, out var _0023_003DzsVw1i9LkTBtX, out var _0023_003DzbdEewMMmMxDg);
		height = Math.Abs(_0023_003DzbdEewMMmMxDg - _0023_003DzsVw1i9LkTBtX);
		center.X += num3;
		center.Y += num4;
		center.Z += num5;
		center -= Math.Abs(_0023_003DzsVw1i9LkTBtX) * axis;
	}

	private static Matrix<double> _0023_003Dz9I7yulAxByo_0024(Vector<double> _0023_003DzAvn2b38_003D)
	{
		Matrix<double> matrix = Matrix<double>.Build.DenseIdentity(3);
		Matrix<double> matrix2 = _0023_003DzAvn2b38_003D.ToColumnMatrix() * _0023_003DzAvn2b38_003D.ToRowMatrix();
		return matrix - matrix2;
	}

	private static Matrix<double> _0023_003DzbpGBbcOEhgO4(Vector<double> _0023_003DzAvn2b38_003D)
	{
		return Matrix<double>.Build.DenseOfArray(new double[3, 3]
		{
			{
				0.0,
				0.0 - _0023_003DzAvn2b38_003D[2],
				_0023_003DzAvn2b38_003D[1]
			},
			{
				_0023_003DzAvn2b38_003D[2],
				0.0,
				0.0 - _0023_003DzAvn2b38_003D[0]
			},
			{
				0.0 - _0023_003DzAvn2b38_003D[1],
				_0023_003DzAvn2b38_003D[0],
				0.0
			}
		});
	}

	private static Matrix<double> _0023_003Dzga2o4kqNtGy0(Matrix<double> _0023_003DzE8QrneA_003D, Matrix<double> _0023_003DzR58imxw_003D)
	{
		return _0023_003DzR58imxw_003D * _0023_003DzE8QrneA_003D * _0023_003DzR58imxw_003D.Transpose();
	}

	private static void _0023_003DzzYe9fz4B_0024zLq(Point3D _0023_003DzbUvT9Pc_003D, Vector3D _0023_003DzxuJqjrs_003D, Matrix<double> _0023_003DzrdSL0CI_003D, out double _0023_003DzsVw1i9LkTBtX, out double _0023_003DzbdEewMMmMxDg)
	{
		SortedList<double, Point3D> sortedList = new SortedList<double, Point3D>();
		int rowCount = _0023_003DzrdSL0CI_003D.RowCount;
		for (int i = 0; i < rowCount; i++)
		{
			double num = _0023_003DzrdSL0CI_003D[i, 0] - _0023_003DzbUvT9Pc_003D.X;
			double num2 = _0023_003DzrdSL0CI_003D[i, 1] - _0023_003DzbUvT9Pc_003D.Y;
			double num3 = _0023_003DzrdSL0CI_003D[i, 2] - _0023_003DzbUvT9Pc_003D.Z;
			double key = num * _0023_003DzxuJqjrs_003D.X + num2 * _0023_003DzxuJqjrs_003D.Y + num3 * _0023_003DzxuJqjrs_003D.Z;
			if (!sortedList.ContainsKey(key))
			{
				sortedList.Add(key, new Point3D(_0023_003DzrdSL0CI_003D[i, 0], _0023_003DzrdSL0CI_003D[i, 1], _0023_003DzrdSL0CI_003D[i, 2]));
			}
		}
		_0023_003DzsVw1i9LkTBtX = sortedList.Keys.First();
		_0023_003DzbdEewMMmMxDg = sortedList.Keys.Last();
	}

	private static void _0023_003DzzYe9fz4B_0024zLq(Point3D _0023_003DzbUvT9Pc_003D, Vector3D _0023_003DzxuJqjrs_003D, IList<Point3D> _0023_003DzrdSL0CI_003D, out double _0023_003DzsVw1i9LkTBtX, out double _0023_003DzbdEewMMmMxDg)
	{
		SortedList<double, Point3D> sortedList = new SortedList<double, Point3D>();
		int count = _0023_003DzrdSL0CI_003D.Count;
		for (int i = 0; i < count; i++)
		{
			Point3D point3D = _0023_003DzrdSL0CI_003D[i];
			double num = point3D.X - _0023_003DzbUvT9Pc_003D.X;
			double num2 = point3D.Y - _0023_003DzbUvT9Pc_003D.Y;
			double num3 = point3D.Z - _0023_003DzbUvT9Pc_003D.Z;
			double key = num * _0023_003DzxuJqjrs_003D.X + num2 * _0023_003DzxuJqjrs_003D.Y + num3 * _0023_003DzxuJqjrs_003D.Z;
			if (!sortedList.ContainsKey(key))
			{
				sortedList.Add(key, point3D);
			}
		}
		_0023_003DzsVw1i9LkTBtX = sortedList.Keys.First();
		_0023_003DzbdEewMMmMxDg = sortedList.Keys.Last();
	}

	private static void _0023_003DzzYe9fz4B_0024zLq(Point3D _0023_003DzbUvT9Pc_003D, Vector3D _0023_003DzxuJqjrs_003D, float[] _0023_003DzrdSL0CI_003D, out double _0023_003DzsVw1i9LkTBtX, out double _0023_003DzbdEewMMmMxDg)
	{
		SortedList<double, Point3D> sortedList = new SortedList<double, Point3D>();
		int num = _0023_003DzrdSL0CI_003D.Length;
		for (int i = 0; i < num; i += 3)
		{
			float num2 = _0023_003DzrdSL0CI_003D[i];
			float num3 = _0023_003DzrdSL0CI_003D[i + 1];
			float num4 = _0023_003DzrdSL0CI_003D[i + 2];
			double num5 = (double)num2 - _0023_003DzbUvT9Pc_003D.X;
			double num6 = (double)num3 - _0023_003DzbUvT9Pc_003D.Y;
			double num7 = (double)num4 - _0023_003DzbUvT9Pc_003D.Z;
			double key = num5 * _0023_003DzxuJqjrs_003D.X + num6 * _0023_003DzxuJqjrs_003D.Y + num7 * _0023_003DzxuJqjrs_003D.Z;
			if (!sortedList.ContainsKey(key))
			{
				sortedList.Add(key, new Point3D(num2, num3, num4));
			}
		}
		_0023_003DzsVw1i9LkTBtX = sortedList.Keys.First();
		_0023_003DzbdEewMMmMxDg = sortedList.Keys.Last();
	}

	private static void _0023_003Dzs8xwThpSc8Lh8cfD1w_003D_003D(bool _0023_003DzDvlA7jDd7s3PtwTVJg_003D_003D, double[,] _0023_003DzDtqAooE_003D, Matrix<double> _0023_003DzFFEk9r8ctLh6PreR2w_003D_003D, out Point3D _0023_003DzbUvT9Pc_003D, out Vector3D _0023_003DzxuJqjrs_003D, out double _0023_003DzEGKj_0024SNUUihi)
	{
		MatrixBuilder<double> build = Matrix<double>.Build;
		VectorBuilder<double> build2 = Vector<double>.Build;
		int rowCount = _0023_003DzFFEk9r8ctLh6PreR2w_003D_003D.RowCount;
		Matrix<double> matrix = build.DenseOfArray(_0023_003DzDtqAooE_003D);
		matrix /= (double)rowCount;
		double[] array = new double[6]
		{
			matrix[0, 0],
			2.0 * matrix[0, 1],
			2.0 * matrix[0, 2],
			matrix[1, 1],
			2.0 * matrix[1, 2],
			matrix[2, 2]
		};
		Vector<double> vector = build2.Dense(array);
		Matrix<double> matrix2 = Matrix<double>.Build.Dense(rowCount, 6);
		for (int i = 0; i < rowCount; i++)
		{
			double num = _0023_003DzFFEk9r8ctLh6PreR2w_003D_003D[i, 0];
			double num2 = _0023_003DzFFEk9r8ctLh6PreR2w_003D_003D[i, 1];
			double num3 = _0023_003DzFFEk9r8ctLh6PreR2w_003D_003D[i, 2];
			matrix2[i, 0] = num * num - matrix[0, 0];
			matrix2[i, 1] = 2.0 * num * num2 - 2.0 * matrix[0, 1];
			matrix2[i, 2] = 2.0 * num * num3 - 2.0 * matrix[0, 2];
			matrix2[i, 3] = num2 * num2 - matrix[1, 1];
			matrix2[i, 4] = 2.0 * num2 * num3 - 2.0 * matrix[1, 2];
			matrix2[i, 5] = num3 * num3 - matrix[2, 2];
		}
		Matrix<double> matrix3 = _0023_003DzFFEk9r8ctLh6PreR2w_003D_003D.Transpose() * matrix2;
		Matrix<double> matrix4 = matrix2.Transpose() * matrix2;
		matrix3 = matrix3.Divide(rowCount);
		matrix4 = matrix4.Divide(rowCount);
		_0023_003DzQblHGY4s1vkJ(_0023_003DzDtqAooE_003D, out var _, out var _0023_003Dz77g161c_003D);
		List<Vector3D> list = new List<Vector3D>();
		list.Add(new Vector3D(_0023_003Dz77g161c_003D[0, 0], _0023_003Dz77g161c_003D[1, 0], _0023_003Dz77g161c_003D[2, 0]));
		list.Add(new Vector3D(_0023_003Dz77g161c_003D[0, 1], _0023_003Dz77g161c_003D[1, 1], _0023_003Dz77g161c_003D[2, 1]));
		list.Add(new Vector3D(_0023_003Dz77g161c_003D[0, 2], _0023_003Dz77g161c_003D[1, 2], _0023_003Dz77g161c_003D[2, 2]));
		if (_0023_003DzDvlA7jDd7s3PtwTVJg_003D_003D)
		{
			int num4 = 720;
			int num5 = num4 / 4;
			double num6 = Math.PI / 2.0 / (double)num5;
			double num7 = Math.PI / 2.0 / (double)num5;
			for (int j = 0; j <= num5; j++)
			{
				double num8 = num6 * (double)j;
				double z = Math.Cos(num8);
				double num9 = Math.Sin(num8);
				for (int k = 0; k < num4; k++)
				{
					double num10 = num7 * (double)k;
					double num11 = Math.Cos(num10);
					double num12 = Math.Sin(num10);
					list.Add(new Vector3D(num9 * num11, num9 * num12, z));
				}
			}
		}
		double num13 = double.PositiveInfinity;
		_0023_003DzbUvT9Pc_003D = new Point3D(0.0, 0.0, 0.0);
		_0023_003DzxuJqjrs_003D = new Vector3D(0.0, 0.0, 0.0);
		_0023_003DzEGKj_0024SNUUihi = 0.0;
		for (int l = 0; l < list.Count; l++)
		{
			double[] array2 = new double[3]
			{
				list[l][0],
				list[l][1],
				list[l][2]
			};
			Vector<double> vector2 = build2.Dense(array2);
			Matrix<double> matrix5 = _0023_003Dz9I7yulAxByo_0024(vector2);
			Matrix<double> _0023_003DzR58imxw_003D = _0023_003DzbpGBbcOEhgO4(vector2);
			Matrix<double> matrix6 = matrix5 * matrix * matrix5;
			Matrix<double> matrix7 = _0023_003Dzga2o4kqNtGy0(matrix6, _0023_003DzR58imxw_003D);
			double scalar = (matrix6 * matrix7).Trace();
			Matrix<double> matrix8 = matrix7.Divide(scalar);
			double[] array3 = new double[6]
			{
				matrix5[0, 0],
				matrix5[0, 1],
				matrix5[0, 2],
				matrix5[1, 1],
				matrix5[1, 2],
				matrix5[2, 2]
			};
			Vector<double> vector3 = build2.Dense(array3);
			Vector<double> vector4 = matrix3 * vector3;
			Vector<double> vector5 = matrix8 * vector4;
			double num14 = vector3 * (matrix4 * vector3) - 4.0 * (vector4 * vector5) + 4.0 * vector5 * (matrix * vector5);
			if (!(num14 < num13))
			{
				continue;
			}
			Vector<double> vector6;
			if (matrix5.Rank() == 3)
			{
				vector6 = matrix5.Solve(vector5);
			}
			else
			{
				vector6 = matrix5.PseudoInverse() * vector5;
				Vector<double> vector7 = matrix5 * vector6;
				if ((vector5 - vector7).L2Norm() > 1E-10)
				{
					continue;
				}
			}
			_0023_003DzbUvT9Pc_003D.X = vector6[0];
			_0023_003DzbUvT9Pc_003D.Y = vector6[1];
			_0023_003DzbUvT9Pc_003D.Z = vector6[2];
			_0023_003DzxuJqjrs_003D.X = vector2[0];
			_0023_003DzxuJqjrs_003D.Y = vector2[1];
			_0023_003DzxuJqjrs_003D.Z = vector2[2];
			num13 = num14;
			_0023_003DzEGKj_0024SNUUihi = Math.Sqrt(vector3 * vector + vector5 * vector5);
		}
	}

	public static bool FitSphere(IList<Point3D> points, out Point3D center, out double radius)
	{
		int count = points.Count;
		if (count < 4)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662125));
		}
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		for (int i = 0; i < count; i++)
		{
			Point3D point3D = points[i];
			num += point3D.X;
			num2 += point3D.Y;
			num3 += point3D.Z;
		}
		num /= (double)count;
		num2 /= (double)count;
		num3 /= (double)count;
		double[,] array = new double[3, 3];
		double[] array2 = new double[3];
		for (int j = 0; j < count; j++)
		{
			Point3D point3D2 = points[j];
			double num4 = point3D2.X - num;
			double num5 = point3D2.Y - num2;
			double num6 = point3D2.Z - num3;
			array[0, 0] += num4 * num4;
			array[0, 1] += num4 * num5;
			array[0, 2] += num4 * num6;
			array[1, 0] += num5 * num4;
			array[1, 1] += num5 * num5;
			array[1, 2] += num5 * num6;
			array[2, 0] += num6 * num4;
			array[2, 1] += num6 * num5;
			array[2, 2] += num6 * num6;
			double num7 = num4 * num4 + num5 * num5 + num6 * num6;
			array2[0] += num7 * num4;
			array2[1] += num7 * num5;
			array2[2] += num7 * num6;
		}
		array2[0] /= 2.0;
		array2[1] /= 2.0;
		array2[2] /= 2.0;
		center = new Point3D(0.0, 0.0, 0.0);
		radius = 0.0;
		Point3D _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D = new Point3D(num, num2, num3);
		if (!_0023_003DzxKZqrRpFP2kJ(array, array2, _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D, out center))
		{
			return false;
		}
		double num8 = 0.0;
		for (int k = 0; k < count; k++)
		{
			Point3D point3D3 = points[k] - center;
			num8 += point3D3.X * point3D3.X + point3D3.Y * point3D3.Y + point3D3.Z * point3D3.Z;
		}
		num8 /= (double)count;
		radius = Math.Sqrt(num8);
		return true;
	}

	public static bool FitSphere(float[] points, out Point3D center, out double radius)
	{
		int num = points.Length;
		if (num % 3 != 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661319));
		}
		int num2 = num / 3;
		if (num2 < 4)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662055));
		}
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		for (int i = 0; i < num; i += 3)
		{
			num3 += (double)points[i];
			num4 += (double)points[i + 1];
			num5 += (double)points[i + 2];
		}
		num3 /= (double)num2;
		num4 /= (double)num2;
		num5 /= (double)num2;
		double[,] array = new double[3, 3];
		double[] array2 = new double[3];
		for (int j = 0; j < num; j += 3)
		{
			double num6 = (double)points[j] - num3;
			double num7 = (double)points[j + 1] - num4;
			double num8 = (double)points[j + 2] - num5;
			array[0, 0] += num6 * num6;
			array[0, 1] += num6 * num7;
			array[0, 2] += num6 * num8;
			array[1, 0] += num7 * num6;
			array[1, 1] += num7 * num7;
			array[1, 2] += num7 * num8;
			array[2, 0] += num8 * num6;
			array[2, 1] += num8 * num7;
			array[2, 2] += num8 * num8;
			double num9 = num6 * num6 + num7 * num7 + num8 * num8;
			array2[0] += num9 * num6;
			array2[1] += num9 * num7;
			array2[2] += num9 * num8;
		}
		array2[0] /= 2.0;
		array2[1] /= 2.0;
		array2[2] /= 2.0;
		center = new Point3D(0.0, 0.0, 0.0);
		radius = 0.0;
		Point3D _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D = new Point3D(num3, num4, num5);
		if (!_0023_003DzxKZqrRpFP2kJ(array, array2, _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D, out center))
		{
			return false;
		}
		double num10 = 0.0;
		for (int k = 0; k < num; k += 3)
		{
			double num11 = points[k];
			double num12 = points[k + 1];
			Point3D point3D = new Point3D(z: (double)points[k + 2] - center.Z, x: num11 - center.X, y: num12 - center.Y);
			num10 += point3D.X * point3D.X + point3D.Y * point3D.Y + point3D.Z * point3D.Z;
		}
		num10 /= (double)num2;
		radius = Math.Sqrt(num10);
		return true;
	}

	private static bool _0023_003DzxKZqrRpFP2kJ(double[,] _0023_003DzDtqAooE_003D, double[] _0023_003DzAYqOj_Y_003D, Point3D _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D, out Point3D _0023_003DzbUvT9Pc_003D)
	{
		_0023_003DzbUvT9Pc_003D = new Point3D(0.0, 0.0, 0.0);
		double num = _0023_003DzDtqAooE_003D[1, 1] * _0023_003DzDtqAooE_003D[2, 2] - _0023_003DzDtqAooE_003D[1, 2] * _0023_003DzDtqAooE_003D[1, 2];
		double num2 = _0023_003DzDtqAooE_003D[0, 2] * _0023_003DzDtqAooE_003D[1, 2] - _0023_003DzDtqAooE_003D[0, 1] * _0023_003DzDtqAooE_003D[2, 2];
		double num3 = _0023_003DzDtqAooE_003D[0, 1] * _0023_003DzDtqAooE_003D[1, 2] - _0023_003DzDtqAooE_003D[0, 2] * _0023_003DzDtqAooE_003D[1, 1];
		double num4 = num * _0023_003DzDtqAooE_003D[0, 0] + num2 * _0023_003DzDtqAooE_003D[0, 1] + num3 * _0023_003DzDtqAooE_003D[0, 2];
		if (Math.Abs(num4) < 1E-06)
		{
			return false;
		}
		double num5 = _0023_003DzDtqAooE_003D[0, 0] * _0023_003DzDtqAooE_003D[2, 2] - _0023_003DzDtqAooE_003D[0, 2] * _0023_003DzDtqAooE_003D[0, 2];
		double num6 = _0023_003DzDtqAooE_003D[0, 1] * _0023_003DzDtqAooE_003D[0, 2] - _0023_003DzDtqAooE_003D[0, 0] * _0023_003DzDtqAooE_003D[1, 2];
		double num7 = _0023_003DzDtqAooE_003D[0, 0] * _0023_003DzDtqAooE_003D[1, 1] - _0023_003DzDtqAooE_003D[0, 1] * _0023_003DzDtqAooE_003D[0, 1];
		_0023_003DzbUvT9Pc_003D.X = _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D.X + (num * _0023_003DzAYqOj_Y_003D[0] + num2 * _0023_003DzAYqOj_Y_003D[1] + num3 * _0023_003DzAYqOj_Y_003D[2]) / num4;
		_0023_003DzbUvT9Pc_003D.Y = _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D.Y + (num2 * _0023_003DzAYqOj_Y_003D[0] + num5 * _0023_003DzAYqOj_Y_003D[1] + num6 * _0023_003DzAYqOj_Y_003D[2]) / num4;
		_0023_003DzbUvT9Pc_003D.Z = _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D.Z + (num3 * _0023_003DzAYqOj_Y_003D[0] + num6 * _0023_003DzAYqOj_Y_003D[1] + num7 * _0023_003DzAYqOj_Y_003D[2]) / num4;
		return true;
	}

	public static void FitCone(IList<Point3D> points, out Point3D center, out Vector3D axis, out double halfAngle, out double radius)
	{
		int count = points.Count;
		if (count < 5)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661731));
		}
		_0023_003Dzb3qULgAolVHNSDj9kA_003D_003D(points, out var _0023_003Dzy_aayKY_003D, out var _0023_003Dzuoh5ls4_003D, out var _0023_003DzFlKzbTY_003D);
		Vector<double> vector = Vector<double>.Build.Dense(count);
		Vector<double> vector2 = Vector<double>.Build.Dense(count);
		Vector<double> vector3 = Vector<double>.Build.Dense(count);
		for (int i = 0; i < count; i++)
		{
			vector[i] = points[i].X;
			vector2[i] = points[i].Y;
			vector3[i] = points[i].Z;
		}
		_0023_003DzB_0024TcR6FAxuy3yfEs_g_003D_003D(out var _0023_003DzkEYxO1SuR1Kw, out axis, out halfAngle, vector, vector2, vector3, _0023_003DzFlKzbTY_003D, _0023_003Dzy_aayKY_003D, _0023_003Dzuoh5ls4_003D);
		_0023_003DzzYe9fz4B_0024zLq(_0023_003DzkEYxO1SuR1Kw, axis, points, out var _0023_003DzsVw1i9LkTBtX, out var _);
		double num = Math.Abs(_0023_003DzsVw1i9LkTBtX);
		center = _0023_003DzkEYxO1SuR1Kw - axis * num;
		radius = num * Math.Tan(halfAngle);
	}

	public static void FitCone(float[] points, out Point3D center, out Vector3D axis, out double halfAngle, out double radius)
	{
		int num = points.Length;
		if (num % 3 != 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661319));
		}
		int num2 = num / 3;
		if (num2 < 5)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661731));
		}
		_0023_003Dzb3qULgAolVHNSDj9kA_003D_003D(points, out var _0023_003Dzy_aayKY_003D, out var _0023_003Dzuoh5ls4_003D, out var _0023_003DzFlKzbTY_003D);
		Vector<double> vector = Vector<double>.Build.Dense(num2);
		Vector<double> vector2 = Vector<double>.Build.Dense(num2);
		Vector<double> vector3 = Vector<double>.Build.Dense(num2);
		for (int i = 0; i < num2; i++)
		{
			vector[i] = points[3 * i];
			vector2[i] = points[3 * i + 1];
			vector3[i] = points[3 * i + 2];
		}
		_0023_003DzB_0024TcR6FAxuy3yfEs_g_003D_003D(out var _0023_003DzkEYxO1SuR1Kw, out axis, out halfAngle, vector, vector2, vector3, _0023_003DzFlKzbTY_003D, _0023_003Dzy_aayKY_003D, _0023_003Dzuoh5ls4_003D);
		_0023_003DzzYe9fz4B_0024zLq(_0023_003DzkEYxO1SuR1Kw, axis, points, out var _0023_003DzsVw1i9LkTBtX, out var _);
		double num3 = Math.Abs(_0023_003DzsVw1i9LkTBtX);
		center = _0023_003DzkEYxO1SuR1Kw - axis * num3;
		radius = num3 * Math.Tan(halfAngle);
	}

	private static void _0023_003DzCgysrlPQ6IkhHIcZPw_003D_003D(Vector3D _0023_003Dzuoh5ls4_003D, Matrix<double> _0023_003DzFFEk9r8ctLh6PreR2w_003D_003D, Point3D _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D, out Point3D _0023_003Dzy_aayKY_003D, out double _0023_003DzFlKzbTY_003D)
	{
		int rowCount = _0023_003DzFFEk9r8ctLh6PreR2w_003D_003D.RowCount;
		List<Point3D> list = new List<Point3D>();
		double num = double.PositiveInfinity;
		double num2 = double.NegativeInfinity;
		for (int i = 0; i < rowCount; i++)
		{
			double num3 = _0023_003DzFFEk9r8ctLh6PreR2w_003D_003D[i, 0];
			double num4 = _0023_003DzFFEk9r8ctLh6PreR2w_003D_003D[i, 1];
			double num5 = _0023_003DzFFEk9r8ctLh6PreR2w_003D_003D[i, 2];
			double num6 = num3 * _0023_003Dzuoh5ls4_003D.X + num4 * _0023_003Dzuoh5ls4_003D.Y + num5 * _0023_003Dzuoh5ls4_003D.Z;
			if (num6 < num)
			{
				num = num6;
			}
			if (num6 > num2)
			{
				num2 = num6;
			}
			double length = new Vector3D(num3 - num6 * _0023_003Dzuoh5ls4_003D.X, num4 - num6 * _0023_003Dzuoh5ls4_003D.Y, num5 - num6 * _0023_003Dzuoh5ls4_003D.Z).Length;
			list.Add(new Point3D(num6, length, 0.0));
		}
		FitLine(list, out var p, out var dir);
		double x = p.X;
		double y = p.Y;
		double num7 = 0.0;
		if (dir.X != 0.0)
		{
			num7 = dir.Y / dir.X;
		}
		if (num7 < 0.0)
		{
			_0023_003Dzuoh5ls4_003D.Negate();
			num7 = 0.0 - num7;
			double num8 = num2;
			num2 = num;
			num = num8;
			num *= -1.0;
			num2 *= -1.0;
		}
		double num9 = y + num7 * (num - x);
		double num10 = y + num7 * (num2 - x);
		double num11 = num2 - num;
		double num12 = num10 - num9;
		double num13 = num12 / num11;
		_0023_003DzFlKzbTY_003D = Math.Atan2(num12, num11);
		double num14 = num10 / num13 - num2;
		_0023_003Dzy_aayKY_003D = new Point3D(_0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D.X - num14 * _0023_003Dzuoh5ls4_003D.X, _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D.Y - num14 * _0023_003Dzuoh5ls4_003D.Y, _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D.Z - num14 * _0023_003Dzuoh5ls4_003D.Z);
	}

	private static void _0023_003Dzb3qULgAolVHNSDj9kA_003D_003D(IList<Point3D> _0023_003DzrdSL0CI_003D, out Point3D _0023_003Dzy_aayKY_003D, out Vector3D _0023_003Dzuoh5ls4_003D, out double _0023_003DzFlKzbTY_003D)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		int count = _0023_003DzrdSL0CI_003D.Count;
		for (int i = 0; i < count; i++)
		{
			Point3D point3D = _0023_003DzrdSL0CI_003D[i];
			num += point3D.X;
			num2 += point3D.Y;
			num3 += point3D.Z;
		}
		num /= (double)count;
		num2 /= (double)count;
		num3 /= (double)count;
		_0023_003Dzuoh5ls4_003D = new Vector3D(0.0, 0.0, 0.0);
		Matrix<double> matrix = Matrix<double>.Build.Dense(count, 3);
		for (int j = 0; j < count; j++)
		{
			Point3D point3D2 = _0023_003DzrdSL0CI_003D[j];
			double num4 = point3D2.X - num;
			double num5 = point3D2.Y - num2;
			double num6 = point3D2.Z - num3;
			matrix[j, 0] = num4;
			matrix[j, 1] = num5;
			matrix[j, 2] = num6;
			double num7 = num4 * num4 + num5 * num5 + num6 * num6;
			_0023_003Dzuoh5ls4_003D.X += num4 * num7;
			_0023_003Dzuoh5ls4_003D.Y += num5 * num7;
			_0023_003Dzuoh5ls4_003D.Z += num6 * num7;
		}
		_0023_003Dzuoh5ls4_003D.Normalize();
		Point3D _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D = new Point3D(num, num2, num3);
		_0023_003DzCgysrlPQ6IkhHIcZPw_003D_003D(_0023_003Dzuoh5ls4_003D, matrix, _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D, out _0023_003Dzy_aayKY_003D, out _0023_003DzFlKzbTY_003D);
	}

	private static void _0023_003Dzb3qULgAolVHNSDj9kA_003D_003D(float[] _0023_003DzrdSL0CI_003D, out Point3D _0023_003Dzy_aayKY_003D, out Vector3D _0023_003Dzuoh5ls4_003D, out double _0023_003DzFlKzbTY_003D)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		int num4 = _0023_003DzrdSL0CI_003D.Length;
		int num5 = num4 / 3;
		_ = Matrix<double>.Build;
		_ = Vector<double>.Build;
		for (int i = 0; i < num4; i += 3)
		{
			num += (double)_0023_003DzrdSL0CI_003D[i];
			num2 += (double)_0023_003DzrdSL0CI_003D[i + 1];
			num3 += (double)_0023_003DzrdSL0CI_003D[i + 2];
		}
		num /= (double)num5;
		num2 /= (double)num5;
		num3 /= (double)num5;
		_0023_003Dzuoh5ls4_003D = new Vector3D(0.0, 0.0, 0.0);
		Matrix<double> matrix = Matrix<double>.Build.Dense(num4, 3);
		for (int j = 0; j < num4; j += 3)
		{
			double num6 = (double)_0023_003DzrdSL0CI_003D[j] - num;
			double num7 = (double)_0023_003DzrdSL0CI_003D[j + 1] - num2;
			double num8 = (double)_0023_003DzrdSL0CI_003D[j + 2] - num3;
			int row = j / 3;
			matrix[row, 0] = num6;
			matrix[row, 1] = num7;
			matrix[row, 2] = num8;
			double num9 = num6 * num6 + num7 * num7 + num8 * num8;
			_0023_003Dzuoh5ls4_003D.X += num6 * num9;
			_0023_003Dzuoh5ls4_003D.Y += num7 * num9;
			_0023_003Dzuoh5ls4_003D.Z += num8 * num9;
		}
		_0023_003Dzuoh5ls4_003D.Normalize();
		Point3D _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D = new Point3D(num, num2, num3);
		_0023_003DzCgysrlPQ6IkhHIcZPw_003D_003D(_0023_003Dzuoh5ls4_003D, matrix, _0023_003Dzie_0024bpnq3s7I1Lr3RNA_003D_003D, out _0023_003Dzy_aayKY_003D, out _0023_003DzFlKzbTY_003D);
	}

	private static void _0023_003DzB_0024TcR6FAxuy3yfEs_g_003D_003D(out Point3D _0023_003DzkEYxO1SuR1Kw, out Vector3D _0023_003DzxuJqjrs_003D, out double _0023_003Dz6pajdGM_003D, Vector<double> _0023_003DzuTkHiyI_003D, Vector<double> _0023_003Dz0KVPVlc_003D, Vector<double> _0023_003DzGRCZTwc_003D, double _0023_003DzFlKzbTY_003D, Point3D _0023_003Dzy_aayKY_003D, Vector3D _0023_003Dzuoh5ls4_003D)
	{
		_0023_003DzyqjkVjvyKwBNjbO6wr7yKtI_003D CS_0024_003C_003E8__locals8 = new _0023_003DzyqjkVjvyKwBNjbO6wr7yKtI_003D();
		CS_0024_003C_003E8__locals8._0023_003DzuTkHiyI_003D = _0023_003DzuTkHiyI_003D;
		CS_0024_003C_003E8__locals8._0023_003Dz0KVPVlc_003D = _0023_003Dz0KVPVlc_003D;
		CS_0024_003C_003E8__locals8._0023_003DzGRCZTwc_003D = _0023_003DzGRCZTwc_003D;
		int count = CS_0024_003C_003E8__locals8._0023_003DzuTkHiyI_003D.Count;
		Vector<double> observedY = Vector<double>.Build.Dense(count);
		double num = Math.Cos(_0023_003DzFlKzbTY_003D);
		Vector<double> initialGuess = Vector<double>.Build.DenseOfArray(new double[6]
		{
			_0023_003Dzy_aayKY_003D.X,
			_0023_003Dzy_aayKY_003D.Y,
			_0023_003Dzy_aayKY_003D.Z,
			_0023_003Dzuoh5ls4_003D.X / num,
			_0023_003Dzuoh5ls4_003D.Y / num,
			_0023_003Dzuoh5ls4_003D.Z / num
		});
		IObjectiveModel objective = ObjectiveFunction.NonlinearModel(delegate(Vector<double> _0023_003DzB68dg9Q_003D, Vector<double> _0023_003DzBJFJHwk_003D)
		{
			Vector<double> vector = CreateVector.DenseOfArray(new double[3]
			{
				_0023_003DzB68dg9Q_003D[0],
				_0023_003DzB68dg9Q_003D[1],
				_0023_003DzB68dg9Q_003D[2]
			});
			Vector<double> vector2 = CreateVector.DenseOfArray(new double[3]
			{
				_0023_003DzB68dg9Q_003D[3],
				_0023_003DzB68dg9Q_003D[4],
				_0023_003DzB68dg9Q_003D[5]
			});
			int num2 = _0023_003DzBJFJHwk_003D.Count();
			Vector<double> vector3 = CreateVector.Dense<double>(num2);
			for (int i = 0; i < num2; i++)
			{
				Vector<double> vector4 = CreateVector.DenseOfArray(new double[3]
				{
					CS_0024_003C_003E8__locals8._0023_003DzuTkHiyI_003D[i],
					CS_0024_003C_003E8__locals8._0023_003Dz0KVPVlc_003D[i],
					CS_0024_003C_003E8__locals8._0023_003DzGRCZTwc_003D[i]
				});
				Vector<double> vector5 = vector - vector4;
				double num3 = vector5 * vector2;
				vector3[i] = vector5 * vector5 - num3 * num3;
			}
			return vector3;
		}, CS_0024_003C_003E8__locals8._0023_003DzuTkHiyI_003D, observedY);
		NonlinearMinimizationResult nonlinearMinimizationResult = new LevenbergMarquardtMinimizer(0.001, 1E-15, 1E-15, 1E-15, 10000).FindMinimum(objective, initialGuess);
		_0023_003DzkEYxO1SuR1Kw = new Point3D(nonlinearMinimizationResult.MinimizingPoint[0], nonlinearMinimizationResult.MinimizingPoint[1], nonlinearMinimizationResult.MinimizingPoint[2]);
		_0023_003DzxuJqjrs_003D = new Vector3D(nonlinearMinimizationResult.MinimizingPoint[3], nonlinearMinimizationResult.MinimizingPoint[4], nonlinearMinimizationResult.MinimizingPoint[5]);
		num = Math.Min(1.0, 1.0 / _0023_003DzxuJqjrs_003D.Length);
		_0023_003Dz6pajdGM_003D = Math.Acos(num);
		_0023_003DzxuJqjrs_003D.Normalize();
		_0023_003DzxuJqjrs_003D *= -1.0;
	}

	public static bool FitTorus(IList<Point3D> points, out Point3D center, out Vector3D axis, out double majorRadius, out double minorRadius)
	{
		if (points.Count < 7)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661693));
		}
		if (!_0023_003Dz89kKBuL_0024fIUWh0q9ZQ_003D_003D(points, out center, out axis, out minorRadius, out majorRadius))
		{
			center = new Point3D(0.0, 0.0, 0.0);
			axis = new Vector3D(0.0, 0.0, 1.0);
			majorRadius = 50.0;
			minorRadius = 10.0;
		}
		int count = points.Count;
		Vector<double> vector = Vector<double>.Build.Dense(count);
		Vector<double> vector2 = Vector<double>.Build.Dense(count);
		Vector<double> vector3 = Vector<double>.Build.Dense(count);
		for (int i = 0; i < count; i++)
		{
			vector[i] = points[i].X;
			vector2[i] = points[i].Y;
			vector3[i] = points[i].Z;
		}
		_0023_003DzBKueHb70VfVkBI27BA_003D_003D(ref center, ref axis, ref minorRadius, ref majorRadius, vector, vector2, vector3);
		if (majorRadius <= minorRadius)
		{
			return false;
		}
		return true;
	}

	public static bool FitTorus(float[] points, out Point3D center, out Vector3D axis, out double majorRadius, out double minorRadius)
	{
		int num = points.Length;
		if (num % 3 != 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661319));
		}
		int num2 = num / 3;
		if (num2 < 7)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302661693));
		}
		if (!_0023_003Dz89kKBuL_0024fIUWh0q9ZQ_003D_003D(points, out center, out axis, out minorRadius, out majorRadius))
		{
			center = new Point3D(0.0, 0.0, 0.0);
			axis = new Vector3D(0.0, 0.0, 1.0);
			majorRadius = 50.0;
			minorRadius = 10.0;
		}
		Vector<double> vector = Vector<double>.Build.Dense(num2);
		Vector<double> vector2 = Vector<double>.Build.Dense(num2);
		Vector<double> vector3 = Vector<double>.Build.Dense(num2);
		for (int i = 0; i < num2; i++)
		{
			vector[i] = points[3 * i];
			vector2[i] = points[3 * i + 1];
			vector3[i] = points[3 * i + 2];
		}
		_0023_003DzBKueHb70VfVkBI27BA_003D_003D(ref center, ref axis, ref minorRadius, ref majorRadius, vector, vector2, vector3);
		if (majorRadius <= minorRadius)
		{
			return false;
		}
		return true;
	}

	private static bool _0023_003Dz89kKBuL_0024fIUWh0q9ZQ_003D_003D(IList<Point3D> _0023_003DzrdSL0CI_003D, out Point3D _0023_003DzbUvT9Pc_003D, out Vector3D _0023_003DzxuJqjrs_003D, out double _0023_003DzPyrmfeo_003D, out double _0023_003DzB95shU0_003D)
	{
		int num = _0023_003DzrdSL0CI_003D.Count();
		Plane plane = FitPlane(_0023_003DzrdSL0CI_003D);
		_0023_003DzbUvT9Pc_003D = plane.Origin;
		_0023_003DzxuJqjrs_003D = plane.AxisZ;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double _0023_003Dz5YUZLCQ_003D = num;
		double num9 = 0.0;
		for (int i = 0; i < num; i++)
		{
			Point3D point3D = _0023_003DzrdSL0CI_003D[i];
			double num10 = point3D.X - _0023_003DzbUvT9Pc_003D.X;
			double num11 = point3D.Y - _0023_003DzbUvT9Pc_003D.Y;
			double num12 = point3D.Z - _0023_003DzbUvT9Pc_003D.Z;
			double num13 = num10 * _0023_003DzxuJqjrs_003D.X + num11 * _0023_003DzxuJqjrs_003D.Y + num12 * _0023_003DzxuJqjrs_003D.Z;
			double num14 = num10 * num10 + num11 * num11 + num12 * num12;
			double num15 = 4.0 * (num14 - num13 * num13);
			num4 += num15;
			num3 += num15 * num14;
			num2 += num15 * num14 * num14;
			num5 += num15 * num15;
			num8 += num14;
			num7 += num14 * num14;
			num6 += num14 * num14 * num14;
			num9 += num14 * num14 * num14 * num14;
		}
		return _0023_003DzlOkQsYwpJRtU76rLNg_003D_003D(out _0023_003DzPyrmfeo_003D, out _0023_003DzB95shU0_003D, num4, num3, num8, num7, num5, num2, num6, _0023_003Dz5YUZLCQ_003D, num, num9);
	}

	private static bool _0023_003DzlOkQsYwpJRtU76rLNg_003D_003D(out double _0023_003DzPyrmfeo_003D, out double _0023_003DzB95shU0_003D, double _0023_003DzN9y2G9c_003D, double _0023_003DzH8_0024G110_003D, double _0023_003DzCVdPoWM_003D, double _0023_003Dzfm4oGj8_003D, double _0023_003Dzkxp9QWw_003D, double _0023_003DzJKjUKZ4_003D, double _0023_003DzGQE5xwU_003D, double _0023_003Dz5YUZLCQ_003D, int _0023_003Dz9JZgoew_003D, double _0023_003DzEvUQrI0_003D)
	{
		_0023_003DzZsKJFrz2EpH63_0024U44BCgokk_003D _0023_003DzTnHGwq4_003D = default(_0023_003DzZsKJFrz2EpH63_0024U44BCgokk_003D);
		_0023_003DzTnHGwq4_003D._0023_003Dz9JZgoew_003D = _0023_003Dz9JZgoew_003D;
		_0023_003DzTnHGwq4_003D._0023_003DzEvUQrI0_003D = _0023_003DzEvUQrI0_003D;
		_0023_003DzTnHGwq4_003D._0023_003Dzfm4oGj8_003D = _0023_003Dzfm4oGj8_003D;
		_0023_003DzTnHGwq4_003D._0023_003Dzkxp9QWw_003D = _0023_003Dzkxp9QWw_003D;
		_0023_003DzTnHGwq4_003D._0023_003DzCVdPoWM_003D = _0023_003DzCVdPoWM_003D;
		_0023_003DzTnHGwq4_003D._0023_003DzN9y2G9c_003D = _0023_003DzN9y2G9c_003D;
		_0023_003DzTnHGwq4_003D._0023_003DzGQE5xwU_003D = _0023_003DzGQE5xwU_003D;
		_0023_003DzTnHGwq4_003D._0023_003DzJKjUKZ4_003D = _0023_003DzJKjUKZ4_003D;
		_0023_003DzTnHGwq4_003D._0023_003DzH8_0024G110_003D = _0023_003DzH8_0024G110_003D;
		_0023_003DzPyrmfeo_003D = 0.0;
		_0023_003DzB95shU0_003D = 0.0;
		double _0023_003DzN9y2G9c_003D2 = _0023_003DzTnHGwq4_003D._0023_003DzN9y2G9c_003D;
		double _0023_003DzH8_0024G110_003D2 = _0023_003DzTnHGwq4_003D._0023_003DzH8_0024G110_003D;
		_0023_003DzTnHGwq4_003D._0023_003DzH8_0024G110_003D *= 2.0;
		_0023_003DzTnHGwq4_003D._0023_003DzCVdPoWM_003D *= 3.0;
		_0023_003DzTnHGwq4_003D._0023_003Dzfm4oGj8_003D *= 3.0;
		if (_0023_003DzTnHGwq4_003D._0023_003Dzkxp9QWw_003D == 0.0)
		{
			return false;
		}
		double num = 1.0 / _0023_003DzTnHGwq4_003D._0023_003Dzkxp9QWw_003D;
		double num2 = _0023_003DzTnHGwq4_003D._0023_003DzJKjUKZ4_003D * num;
		double num3 = _0023_003DzTnHGwq4_003D._0023_003DzH8_0024G110_003D * num;
		double num4 = _0023_003DzTnHGwq4_003D._0023_003DzN9y2G9c_003D * num;
		double d = _0023_003DzTnHGwq4_003D._0023_003DzGQE5xwU_003D - _0023_003DzH8_0024G110_003D2 * num2;
		double c = _0023_003DzTnHGwq4_003D._0023_003Dzfm4oGj8_003D - _0023_003DzN9y2G9c_003D2 * num2 - _0023_003DzH8_0024G110_003D2 * num3;
		double b = _0023_003DzTnHGwq4_003D._0023_003DzCVdPoWM_003D - _0023_003DzN9y2G9c_003D2 * num3 - _0023_003DzH8_0024G110_003D2 * num4;
		double a = _0023_003Dz5YUZLCQ_003D - _0023_003DzN9y2G9c_003D2 * num4;
		(Complex, Complex, Complex) tuple = Cubic.Roots(d, c, b, a);
		Complex[] obj = new Complex[3] { tuple.Item1, tuple.Item2, tuple.Item3 };
		List<double> list = new List<double>();
		Complex[] array = obj;
		for (int i = 0; i < array.Length; i++)
		{
			Complex complex = array[i];
			if ((Math.Abs(complex.Imaginary) < 1E-09) & (complex.Real > 0.0))
			{
				list.Add(complex.Real);
			}
		}
		if (list.Count == 0)
		{
			return false;
		}
		double num5 = double.PositiveInfinity;
		double num6 = 0.0;
		double num7 = 0.0;
		foreach (double item in list)
		{
			double num8 = num2 + item * (num3 + item * num4);
			if (num8 > item)
			{
				double num9 = _0023_003DqoaiaRco19jqJhXKh2OHCKkvfErFZRXQpPGEP5uqhYfik0_0024aXtiWszKBAojorKslo9t04Rq2h0mYkVz4KCyq66g_003D_003D(num8, item, ref _0023_003DzTnHGwq4_003D);
				if (num9 < num5)
				{
					num5 = num9;
					num6 = num8;
					num7 = item;
				}
			}
		}
		if (double.IsPositiveInfinity(num5))
		{
			return false;
		}
		_0023_003DzB95shU0_003D = Math.Sqrt(num6);
		_0023_003DzPyrmfeo_003D = Math.Sqrt(num6 - num7);
		return true;
	}

	private static bool _0023_003Dz89kKBuL_0024fIUWh0q9ZQ_003D_003D(float[] _0023_003DzrdSL0CI_003D, out Point3D _0023_003DzbUvT9Pc_003D, out Vector3D _0023_003DzxuJqjrs_003D, out double _0023_003DzPyrmfeo_003D, out double _0023_003DzB95shU0_003D)
	{
		int num = _0023_003DzrdSL0CI_003D.Count();
		Plane plane = FitPlane(_0023_003DzrdSL0CI_003D);
		_0023_003DzbUvT9Pc_003D = plane.Origin;
		_0023_003DzxuJqjrs_003D = plane.AxisZ;
		_0023_003DzPyrmfeo_003D = 0.0;
		_0023_003DzB95shU0_003D = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double _0023_003Dz5YUZLCQ_003D = num;
		double num9 = 0.0;
		for (int i = 0; i < num; i += 3)
		{
			double num10 = (double)_0023_003DzrdSL0CI_003D[i] - _0023_003DzbUvT9Pc_003D.X;
			double num11 = (double)_0023_003DzrdSL0CI_003D[i + 1] - _0023_003DzbUvT9Pc_003D.Y;
			double num12 = (double)_0023_003DzrdSL0CI_003D[i + 2] - _0023_003DzbUvT9Pc_003D.Z;
			double num13 = num10 * _0023_003DzxuJqjrs_003D.X + num11 * _0023_003DzxuJqjrs_003D.Y + num12 * _0023_003DzxuJqjrs_003D.Z;
			double num14 = num10 * num10 + num11 * num11 + num12 * num12;
			double num15 = 4.0 * (num14 - num13 * num13);
			num4 += num15;
			num3 += num15 * num14;
			num2 += num15 * num14 * num14;
			num5 += num15 * num15;
			num8 += num14;
			num7 += num14 * num14;
			num6 += num14 * num14 * num14;
			num9 += num14 * num14 * num14 * num14;
		}
		return _0023_003DzlOkQsYwpJRtU76rLNg_003D_003D(out _0023_003DzPyrmfeo_003D, out _0023_003DzB95shU0_003D, num4, num3, num8, num7, num5, num2, num6, _0023_003Dz5YUZLCQ_003D, num, num9);
	}

	private static void _0023_003DzBKueHb70VfVkBI27BA_003D_003D(ref Point3D _0023_003DzbUvT9Pc_003D, ref Vector3D _0023_003DzxuJqjrs_003D, ref double _0023_003DzPyrmfeo_003D, ref double _0023_003DzB95shU0_003D, Vector<double> _0023_003DzuTkHiyI_003D, Vector<double> _0023_003Dz0KVPVlc_003D, Vector<double> _0023_003DzGRCZTwc_003D)
	{
		_0023_003DzSpe8iZ6fy6btntamlyuSz3w_003D CS_0024_003C_003E8__locals8 = new _0023_003DzSpe8iZ6fy6btntamlyuSz3w_003D();
		CS_0024_003C_003E8__locals8._0023_003DzuTkHiyI_003D = _0023_003DzuTkHiyI_003D;
		CS_0024_003C_003E8__locals8._0023_003Dz0KVPVlc_003D = _0023_003Dz0KVPVlc_003D;
		CS_0024_003C_003E8__locals8._0023_003DzGRCZTwc_003D = _0023_003DzGRCZTwc_003D;
		int count = CS_0024_003C_003E8__locals8._0023_003DzuTkHiyI_003D.Count;
		Vector<double> observedY = Vector<double>.Build.Dense(count);
		_ = _0023_003DzbUvT9Pc_003D.X;
		_ = _0023_003DzbUvT9Pc_003D.Y;
		_ = _0023_003DzbUvT9Pc_003D.Z;
		double num = 0.0;
		double num2 = 0.0;
		if (Math.Abs(_0023_003DzxuJqjrs_003D.Z) < 1.0)
		{
			num = Math.Atan2(_0023_003DzxuJqjrs_003D.Y, _0023_003DzxuJqjrs_003D.X);
			num2 = Math.Acos(_0023_003DzxuJqjrs_003D.Z);
		}
		double num3 = _0023_003DzB95shU0_003D * _0023_003DzB95shU0_003D;
		double num4 = num3 - _0023_003DzPyrmfeo_003D * _0023_003DzPyrmfeo_003D;
		Vector<double> initialGuess = CreateVector.DenseOfArray(new double[7] { _0023_003DzbUvT9Pc_003D.X, _0023_003DzbUvT9Pc_003D.Y, _0023_003DzbUvT9Pc_003D.Z, num, num2, num3, num4 });
		IObjectiveModel objective = ObjectiveFunction.NonlinearModel(delegate(Vector<double> _0023_003DzB68dg9Q_003D, Vector<double> _0023_003DzBJFJHwk_003D)
		{
			Vector<double> vector = CreateVector.DenseOfArray(new double[3]
			{
				_0023_003DzB68dg9Q_003D[0],
				_0023_003DzB68dg9Q_003D[1],
				_0023_003DzB68dg9Q_003D[2]
			});
			double num12 = Math.Cos(_0023_003DzB68dg9Q_003D[3]);
			double num13 = Math.Sin(_0023_003DzB68dg9Q_003D[3]);
			double num14 = Math.Cos(_0023_003DzB68dg9Q_003D[4]);
			double num15 = Math.Sin(_0023_003DzB68dg9Q_003D[4]);
			Vector<double> vector2 = CreateVector.DenseOfArray(new double[3]
			{
				num12 * num15,
				num13 * num15,
				num14
			});
			double num16 = _0023_003DzB68dg9Q_003D[5];
			double num17 = _0023_003DzB68dg9Q_003D[6];
			int num18 = _0023_003DzBJFJHwk_003D.Count();
			Vector<double> vector3 = CreateVector.Dense<double>(num18);
			for (int i = 0; i < num18; i++)
			{
				Vector<double> vector4 = CreateVector.DenseOfArray(new double[3]
				{
					CS_0024_003C_003E8__locals8._0023_003DzuTkHiyI_003D[i],
					CS_0024_003C_003E8__locals8._0023_003Dz0KVPVlc_003D[i],
					CS_0024_003C_003E8__locals8._0023_003DzGRCZTwc_003D[i]
				});
				Vector<double> vector5 = vector - vector4;
				double num19 = vector5 * vector5;
				double num20 = vector5 * vector2;
				double num21 = num19 + num17;
				vector3[i] = num21 * num21 - 4.0 * num16 * (num19 - num20 * num20);
			}
			return vector3;
		}, CS_0024_003C_003E8__locals8._0023_003DzuTkHiyI_003D, observedY);
		NonlinearMinimizationResult nonlinearMinimizationResult = new LevenbergMarquardtMinimizer(0.001, 1E-15, 1E-15, 1E-15, 10000).FindMinimum(objective, initialGuess);
		_0023_003DzbUvT9Pc_003D = new Point3D(nonlinearMinimizationResult.MinimizingPoint[0], nonlinearMinimizationResult.MinimizingPoint[1], nonlinearMinimizationResult.MinimizingPoint[2]);
		double num5 = nonlinearMinimizationResult.MinimizingPoint[3];
		double num6 = nonlinearMinimizationResult.MinimizingPoint[4];
		double num7 = Math.Cos(num5);
		double num8 = Math.Sin(num5);
		double z = Math.Cos(num6);
		double num9 = Math.Sin(num6);
		_0023_003DzxuJqjrs_003D.X = num7 * num9;
		_0023_003DzxuJqjrs_003D.Y = num8 * num9;
		_0023_003DzxuJqjrs_003D.Z = z;
		double num10 = nonlinearMinimizationResult.MinimizingPoint[5];
		double num11 = nonlinearMinimizationResult.MinimizingPoint[6];
		_0023_003DzB95shU0_003D = Math.Sqrt(num10);
		_0023_003DzPyrmfeo_003D = Math.Sqrt(num10 - num11);
	}

	public static void BoundingRect(IList<Point2D> pointList, out Point2D min, out Point2D max)
	{
		min = Point2D.MaxValue;
		max = Point2D.MinValue;
		foreach (Point2D point in pointList)
		{
			if (point.X < min.X)
			{
				min.X = point.X;
			}
			if (point.X > max.X)
			{
				max.X = point.X;
			}
			if (point.Y < min.Y)
			{
				min.Y = point.Y;
			}
			if (point.Y > max.Y)
			{
				max.Y = point.Y;
			}
		}
	}

	public static void BoundingRect(IList<System.Drawing.Point> pointList, out System.Drawing.Point min, out System.Drawing.Point max)
	{
		min = new System.Drawing.Point(int.MaxValue, int.MaxValue);
		max = new System.Drawing.Point(int.MinValue, int.MinValue);
		foreach (System.Drawing.Point point in pointList)
		{
			if (point.X < min.X)
			{
				min.X = point.X;
			}
			if (point.X > max.X)
			{
				max.X = point.X;
			}
			if (point.Y < min.Y)
			{
				min.Y = point.Y;
			}
			if (point.Y > max.Y)
			{
				max.Y = point.Y;
			}
		}
	}

	public static void BoundingRectOnPlane(IList<Point2D> pointList, Plane plane, out Point2D min, out Point2D max)
	{
		min = Point2D.MaxValue;
		max = Point2D.MinValue;
		foreach (Point2D point in pointList)
		{
			plane.Project(new Point3D(point.X, point.Y), out var s, out var t);
			if (s < min.X)
			{
				min.X = s;
			}
			if (s > max.X)
			{
				max.X = s;
			}
			if (t < min.Y)
			{
				min.Y = t;
			}
			if (t > max.Y)
			{
				max.Y = t;
			}
		}
	}

	public static void BoundingBox(IList<Point3D> pointList, out Point3D min, out Point3D max)
	{
		min = Point3D.MaxValue;
		max = Point3D.MinValue;
		foreach (Point3D point in pointList)
		{
			if (point.X < min.X)
			{
				min.X = point.X;
			}
			if (point.X > max.X)
			{
				max.X = point.X;
			}
			if (point.Y < min.Y)
			{
				min.Y = point.Y;
			}
			if (point.Y > max.Y)
			{
				max.Y = point.Y;
			}
			if (point.Z < min.Z)
			{
				min.Z = point.Z;
			}
			if (point.Z > max.Z)
			{
				max.Z = point.Z;
			}
		}
	}

	public static void ComputeBoundingBox(Transformation transform, IList<Point3D> points, out Point3D boxMin, out Point3D boxMax)
	{
		ComputeBoundingBox(transform, points, points.Count, out boxMin, out boxMax);
	}

	public static void ComputeBoundingBox<T>(IList<T> points, out Point3D boxMin, out Point3D boxMax) where T : Point3D
	{
		ComputeBoundingBox(new Identity(), points, points.Count, out boxMin, out boxMax);
	}

	public static void ComputeBoundingBox<T>(Transformation transform, IList<T> points, int count, out Point3D boxMin, out Point3D boxMax) where T : Point3D
	{
		boxMin = Point3D.MaxValue;
		boxMax = Point3D.MinValue;
		if (transform == null || transform.IsIdentity())
		{
			if (points != null && count > 0)
			{
				boxMin.X = (boxMax.X = points[0].X);
				boxMin.Y = (boxMax.Y = points[0].Y);
				boxMin.Z = (boxMax.Z = points[0].Z);
				for (int i = 1; i < count; i++)
				{
					UpdateMinMaxQuick(points[i], boxMin, boxMax);
				}
			}
		}
		else if (points != null && count > 0)
		{
			Point3D point3D = transform * points[0];
			boxMin.X = (boxMax.X = point3D.X);
			boxMin.Y = (boxMax.Y = point3D.Y);
			boxMin.Z = (boxMax.Z = point3D.Z);
			for (int j = 1; j < count; j++)
			{
				UpdateMinMaxQuick(transform * points[j], boxMin, boxMax);
			}
		}
	}

	public static void ComputeBoundingBox(Transformation transform, float[] points, int count, int skipPoints, out Point3D boxMin, out Point3D boxMax)
	{
		boxMin = Point3D.MaxValue;
		boxMax = Point3D.MinValue;
		int num = 3 + skipPoints * 3;
		if (transform == null || transform.IsIdentity())
		{
			if (points != null && count > 0)
			{
				boxMin.X = (boxMax.X = points[0]);
				boxMin.Y = (boxMax.Y = points[1]);
				boxMin.Z = (boxMax.Z = points[2]);
				for (int i = 0; i < count; i += num)
				{
					UpdateMinMaxQuick(points[i], points[i + 1], points[i + 2], boxMin, boxMax);
				}
			}
		}
		else if (points != null && count > 0)
		{
			float[,] floatMatrix = transform.GetFloatMatrix();
			float[] array = Transformation.ActOnLeftOne(points[0], points[1], points[2], floatMatrix);
			boxMin.X = (boxMax.X = array[0]);
			boxMin.Y = (boxMax.Y = array[1]);
			boxMin.Z = (boxMax.Z = array[2]);
			for (int j = 0; j < count; j += num)
			{
				float[] array2 = Transformation.ActOnLeftOne(points[j], points[j + 1], points[j + 2], floatMatrix);
				UpdateMinMaxQuick(array2[0], array2[1], array2[2], boxMin, boxMax);
			}
		}
	}

	public static void InitializeMinMax(Point3D firstPt, out Point3D min, out Point3D max)
	{
		min = new Point3D(firstPt.X, firstPt.Y, firstPt.Z);
		max = new Point3D(firstPt.X, firstPt.Y, firstPt.Z);
	}

	public static void UpdateMinMaxQuick(PointNormalUv p, Point2D min, Point2D max)
	{
		UpdateMinMaxQuick(p.U, p.V, min, max);
	}

	public static void UpdateMinMaxQuick(Point3D p, Point3D min, Point3D max)
	{
		UpdateMinMaxQuick(p.X, p.Y, p.Z, min, max);
	}

	public static void UpdateMinMaxQuick(double x, double y, double z, Point3D min, Point3D max)
	{
		UpdateMinMaxQuick(x, y, min, max);
		if (z < min.Z)
		{
			min.Z = z;
		}
		else if (z > max.Z)
		{
			max.Z = z;
		}
	}

	public static void UpdateMinMaxQuick(double x, double y, Point2D min, Point2D max)
	{
		if (x < min.X)
		{
			min.X = x;
		}
		else if (x > max.X)
		{
			max.X = x;
		}
		if (y < min.Y)
		{
			min.Y = y;
		}
		else if (y > max.Y)
		{
			max.Y = y;
		}
	}

	public static void UpdateMinMaxSlow(Point3D p, Point3D min, Point3D max)
	{
		if (p.X < min.X)
		{
			min.X = p.X;
		}
		if (p.X > max.X)
		{
			max.X = p.X;
		}
		if (p.Y < min.Y)
		{
			min.Y = p.Y;
		}
		if (p.Y > max.Y)
		{
			max.Y = p.Y;
		}
		if (p.Z < min.Z)
		{
			min.Z = p.Z;
		}
		if (p.Z > max.Z)
		{
			max.Z = p.Z;
		}
	}

	public static void UpdateMinMax(Transformation transform, IList<Point3D> points, int count, Point3D min, Point3D max)
	{
		if (transform == null || transform.IsIdentity())
		{
			for (int i = 0; i < count; i++)
			{
				Point3D point3D = points[i];
				if (point3D.X < min.X)
				{
					min.X = point3D.X;
				}
				if (point3D.X > max.X)
				{
					max.X = point3D.X;
				}
				if (point3D.Y < min.Y)
				{
					min.Y = point3D.Y;
				}
				if (point3D.Y > max.Y)
				{
					max.Y = point3D.Y;
				}
				if (point3D.Z < min.Z)
				{
					min.Z = point3D.Z;
				}
				if (point3D.Z > max.Z)
				{
					max.Z = point3D.Z;
				}
			}
			return;
		}
		for (int j = 0; j < count; j++)
		{
			Point3D point3D = transform * points[j];
			if (point3D.X < min.X)
			{
				min.X = point3D.X;
			}
			if (point3D.X > max.X)
			{
				max.X = point3D.X;
			}
			if (point3D.Y < min.Y)
			{
				min.Y = point3D.Y;
			}
			if (point3D.Y > max.Y)
			{
				max.Y = point3D.Y;
			}
			if (point3D.Z < min.Z)
			{
				min.Z = point3D.Z;
			}
			if (point3D.Z > max.Z)
			{
				max.Z = point3D.Z;
			}
		}
	}

	public static void UpdateMinMax(Transformation transform, IList<Point2D> points, int count, Point2D min, Point2D max)
	{
		if (transform == null || transform.IsIdentity())
		{
			for (int i = 0; i < count; i++)
			{
				Point2D point2D = points[i];
				if (point2D.X < min.X)
				{
					min.X = point2D.X;
				}
				if (point2D.X > max.X)
				{
					max.X = point2D.X;
				}
				if (point2D.Y < min.Y)
				{
					min.Y = point2D.Y;
				}
				if (point2D.Y > max.Y)
				{
					max.Y = point2D.Y;
				}
			}
			return;
		}
		for (int j = 0; j < count; j++)
		{
			Point2D point2D2 = transform * points[j];
			if (point2D2.X < min.X)
			{
				min.X = point2D2.X;
			}
			if (point2D2.X > max.X)
			{
				max.X = point2D2.X;
			}
			if (point2D2.Y < min.Y)
			{
				min.Y = point2D2.Y;
			}
			if (point2D2.Y > max.Y)
			{
				max.Y = point2D2.Y;
			}
		}
	}

	public static void UpdateMinMax(double value, ref double min, ref double max)
	{
		if (value > max)
		{
			max = value;
		}
		if (value < min)
		{
			min = value;
		}
	}

	public static void GetMinMax(int v1, int v2, out int min, out int max)
	{
		if (v1 < v2)
		{
			min = v1;
			max = v2;
		}
		else
		{
			min = v2;
			max = v1;
		}
	}

	public static void ComputeBoundingRect(IList<Point2D> points, out Point2D boxMin, out Point2D boxMax)
	{
		int count = points.Count;
		if (count > 0)
		{
			boxMin = new Point2D(points[0].X, points[0].Y);
			boxMax = new Point2D(points[0].X, points[0].Y);
			for (int i = 1; i < count; i++)
			{
				Point2D point2D = points[i];
				if (point2D.X < boxMin.X)
				{
					boxMin.X = point2D.X;
				}
				else if (point2D.X > boxMax.X)
				{
					boxMax.X = point2D.X;
				}
				if (point2D.Y < boxMin.Y)
				{
					boxMin.Y = point2D.Y;
				}
				else if (point2D.Y > boxMax.Y)
				{
					boxMax.Y = point2D.Y;
				}
			}
		}
		else
		{
			boxMin = Point2D.MaxValue;
			boxMax = Point2D.MinValue;
		}
	}

	public static void ComputeBoundingRect(double[,] points, out Point2D boxMin, out Point2D boxMax)
	{
		int length = points.GetLength(0);
		if (length > 0)
		{
			double num2;
			double num = (num2 = points[0, 0]);
			double num4;
			double num3 = (num4 = points[0, 1]);
			for (int i = 1; i < length; i++)
			{
				double num5 = points[i, 0];
				double num6 = points[i, 1];
				if (num5 < num)
				{
					num = num5;
				}
				else if (num5 > num2)
				{
					num2 = num5;
				}
				if (num6 < num3)
				{
					num3 = num6;
				}
				else if (num6 > num4)
				{
					num4 = num6;
				}
			}
			boxMin = new Point2D(num, num3);
			boxMax = new Point2D(num2, num4);
		}
		else
		{
			boxMin = Point2D.MaxValue;
			boxMax = Point2D.MinValue;
		}
	}

	public static bool IsPointInsideOrOntoBBox2D(Point2D pointToCheck, Point2D boxMin, Point2D boxMax)
	{
		if (boxMin.X <= pointToCheck.X && boxMin.Y <= pointToCheck.Y && boxMax.X >= pointToCheck.X && boxMax.Y >= pointToCheck.Y)
		{
			return true;
		}
		return false;
	}

	public static bool TriangleRectangleOverlap(Point2D[] tri, Point2D[] rect)
	{
		Point2D[] array = tri;
		for (int i = 0; i < array.Length; i++)
		{
			if (PointInRect(array[i], rect[0], rect[2]))
			{
				return true;
			}
		}
		array = rect;
		for (int i = 0; i < array.Length; i++)
		{
			if (PointInTriangle(array[i], tri[0], tri[1], tri[2]))
			{
				return true;
			}
		}
		for (int j = 0; j < rect.Length - 1; j++)
		{
			for (int k = 0; k < tri.Length - 1; k++)
			{
				Segment2D s = new Segment2D(rect[j], rect[j + 1]);
				Segment2D s2 = new Segment2D(tri[k], tri[k + 1]);
				if (Segment2D.Intersection(s, s2, out var _))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool DoOverlap(double min1, double max1, double min2, double max2)
	{
		if (max1 > min2)
		{
			return max2 > min1;
		}
		return false;
	}

	public static bool DoOverlap(Point2D min1, Point2D max1, Point2D min2, Point2D max2)
	{
		if (DoOverlap(min1.X, max1.X, min2.X, max2.X))
		{
			return DoOverlap(min1.Y, max1.Y, min2.Y, max2.Y);
		}
		return false;
	}

	public static bool DoOverlap(Point3D min1, Point3D max1, Point3D min2, Point3D max2)
	{
		if (DoOverlap(min1.X, max1.X, min2.X, max2.X) && DoOverlap(min1.Y, max1.Y, min2.Y, max2.Y))
		{
			return DoOverlap(min1.Z, max1.Z, min2.Z, max2.Z);
		}
		return false;
	}

	public static bool DoOverlapOrTouch(double min1, double max1, double min2, double max2)
	{
		if (max1 >= min2)
		{
			return max2 >= min1;
		}
		return false;
	}

	public static bool DoOverlapOrTouch(double min1, double max1, double min2, double max2, double tol)
	{
		tol /= 2.0;
		return DoOverlapOrTouch(min1 - tol, max1 + tol, min2 - tol, max2 + tol);
	}

	internal static bool _0023_003DzGBcHaJW_L4SQ(double _0023_003Dz0AUOSO0_003D, double _0023_003DziHdtxHs_003D, double _0023_003DzUq8xhlc_003D, double _0023_003DzBuffmwk_003D, out bool _0023_003Dzsc0Foo8_003D, out bool _0023_003DzlNxMjwYmRTkG)
	{
		_0023_003Dzsc0Foo8_003D = _0023_003DzBuffmwk_003D >= _0023_003DziHdtxHs_003D && _0023_003DzUq8xhlc_003D <= _0023_003Dz0AUOSO0_003D;
		_0023_003DzlNxMjwYmRTkG = _0023_003DziHdtxHs_003D >= _0023_003DzBuffmwk_003D && _0023_003Dz0AUOSO0_003D <= _0023_003DzUq8xhlc_003D;
		if (!(_0023_003DzlNxMjwYmRTkG | _0023_003Dzsc0Foo8_003D))
		{
			return DoOverlapOrTouch(_0023_003Dz0AUOSO0_003D, _0023_003DziHdtxHs_003D, _0023_003DzUq8xhlc_003D, _0023_003DzBuffmwk_003D);
		}
		return true;
	}

	public static bool DoOverlapOrTouch(Point2D min1, Point2D max1, Point2D min2, Point2D max2, double domainSize)
	{
		double tol = domainSize * _0023_003DzheSR8QM7q9ya;
		if (DoOverlapOrTouch(min1.X, max1.X, min2.X, max2.X, tol))
		{
			return DoOverlapOrTouch(min1.Y, max1.Y, min2.Y, max2.Y, tol);
		}
		return false;
	}

	public static bool DoOverlapOrTouch(Point3D min1, Point3D max1, Point3D min2, Point3D max2, double domainSize)
	{
		double tol = domainSize * _0023_003DzheSR8QM7q9ya;
		if (DoOverlapOrTouch(min1.X, max1.X, min2.X, max2.X, tol) && DoOverlapOrTouch(min1.Y, max1.Y, min2.Y, max2.Y, tol))
		{
			return DoOverlapOrTouch(min1.Z, max1.Z, min2.Z, max2.Z, tol);
		}
		return false;
	}

	public static bool DoOverlapOrTouch(Point3D min1, Point3D max1, Point3D min2, Point3D max2)
	{
		double num = Math.Max(max1.X, max2.X) - Math.Min(min1.X, min2.X);
		double num2 = Math.Max(max1.Y, max2.Y) - Math.Min(min1.Y, min2.Y);
		double num3 = Math.Max(max1.Z, max2.Z) - Math.Min(min1.Z, min2.Z);
		double domainSize = Math.Sqrt(num * num + num2 * num2 + num3 * num3);
		return DoOverlapOrTouch(min1, max1, min2, max2, domainSize);
	}

	public static bool DoOverlapOrTouch(Point2D min1, Point2D max1, Point2D min2, Point2D max2)
	{
		if (DoOverlapOrTouch(min1.X, max1.X, min2.X, max2.X))
		{
			return DoOverlapOrTouch(min1.Y, max1.Y, min2.Y, max2.Y);
		}
		return false;
	}

	internal static bool _0023_003DzGBcHaJW_L4SQ(Point2D _0023_003Dz0AUOSO0_003D, Point2D _0023_003DziHdtxHs_003D, Point2D _0023_003DzUq8xhlc_003D, Point2D _0023_003DzBuffmwk_003D, out bool _0023_003Dzsc0Foo8_003D, out bool _0023_003DzlNxMjwYmRTkG)
	{
		bool _0023_003Dzsc0Foo8_003D2;
		bool _0023_003DzlNxMjwYmRTkG2;
		bool _0023_003Dzsc0Foo8_003D3;
		bool _0023_003DzlNxMjwYmRTkG3;
		bool result = _0023_003DzGBcHaJW_L4SQ(_0023_003Dz0AUOSO0_003D.X, _0023_003DziHdtxHs_003D.X, _0023_003DzUq8xhlc_003D.X, _0023_003DzBuffmwk_003D.X, out _0023_003Dzsc0Foo8_003D2, out _0023_003DzlNxMjwYmRTkG2) & _0023_003DzGBcHaJW_L4SQ(_0023_003Dz0AUOSO0_003D.Y, _0023_003DziHdtxHs_003D.Y, _0023_003DzUq8xhlc_003D.Y, _0023_003DzBuffmwk_003D.Y, out _0023_003Dzsc0Foo8_003D3, out _0023_003DzlNxMjwYmRTkG3);
		_0023_003Dzsc0Foo8_003D = _0023_003Dzsc0Foo8_003D2 && _0023_003Dzsc0Foo8_003D3;
		_0023_003DzlNxMjwYmRTkG = _0023_003DzlNxMjwYmRTkG2 && _0023_003DzlNxMjwYmRTkG3;
		return result;
	}

	public static Size2D IntersectionRect(Point2D firstMin, Point2D firstMax, Point2D secondMin, Point2D secondMax, out Point2D intersMin, out Point2D intersMax)
	{
		double[] array = new double[4] { firstMin.X, firstMax.X, secondMin.X, secondMax.X };
		double[] array2 = new double[4] { firstMin.Y, firstMax.Y, secondMin.Y, secondMax.Y };
		Array.Sort(array);
		Array.Sort(array2);
		intersMin = new Point2D(array[1], array2[1]);
		intersMax = new Point2D(array[2], array2[2]);
		return new Size2D(intersMin, intersMax);
	}

	public static bool DoOverlapOrTouchWithIntersectionBox(Point3D firstMin, Point3D firstMax, Point3D secondMin, Point3D secondMax, out Size3D intersectionBox)
	{
		Point3D _0023_003Dz7Ol_o0jAWU2Q0S_BNA_003D_003D;
		Point3D _0023_003Dz8HG2JuKBpFMj_bVt8g_003D_003D;
		return _0023_003DzEXfUB4ostGLQ9ODvdRCrxyHbWtKQ(firstMin, firstMax, secondMin, secondMax, out _0023_003Dz7Ol_o0jAWU2Q0S_BNA_003D_003D, out _0023_003Dz8HG2JuKBpFMj_bVt8g_003D_003D, out intersectionBox);
	}

	public static bool DoOverlapOrTouchWithIntersectionBox(Point3D firstMin, Point3D firstMax, Point3D secondMin, Point3D secondMax, out Point3D intersMin, out Point3D intersMax)
	{
		Size3D _0023_003Dz3dlnVCvIHCBp6YV6NT6E4R8_003D;
		return _0023_003DzEXfUB4ostGLQ9ODvdRCrxyHbWtKQ(firstMin, firstMax, secondMin, secondMax, out intersMin, out intersMax, out _0023_003Dz3dlnVCvIHCBp6YV6NT6E4R8_003D);
	}

	private static bool _0023_003DzEXfUB4ostGLQ9ODvdRCrxyHbWtKQ(Point3D _0023_003DzBUe0cWJwMyFd, Point3D _0023_003Dzd4clotAQRmaU, Point3D _0023_003DzDpUCutTjteyn, Point3D _0023_003DzfHXdNp3DXsYD, out Point3D _0023_003Dz7Ol_o0jAWU2Q0S_BNA_003D_003D, out Point3D _0023_003Dz8HG2JuKBpFMj_bVt8g_003D_003D, out Size3D _0023_003Dz3dlnVCvIHCBp6YV6NT6E4R8_003D)
	{
		_0023_003Dz7Ol_o0jAWU2Q0S_BNA_003D_003D = null;
		_0023_003Dz8HG2JuKBpFMj_bVt8g_003D_003D = null;
		_0023_003Dz3dlnVCvIHCBp6YV6NT6E4R8_003D = null;
		_0023_003DzrcUskCiopSzm(_0023_003DzBUe0cWJwMyFd, _0023_003Dzd4clotAQRmaU, _0023_003DzDpUCutTjteyn, _0023_003DzfHXdNp3DXsYD, out var _0023_003DzBJFJHwk_003D, out var _0023_003Dz40R7bAU_003D, out var _0023_003DzId5C3LA_003D);
		double diagonal = new Size3D(new Point3D(_0023_003DzBJFJHwk_003D[0], _0023_003Dz40R7bAU_003D[0], _0023_003DzId5C3LA_003D[0]), new Point3D(_0023_003DzBJFJHwk_003D[3], _0023_003Dz40R7bAU_003D[3], _0023_003DzId5C3LA_003D[3])).Diagonal;
		double num = Math.Max(_0023_003DzBUe0cWJwMyFd.X, _0023_003DzDpUCutTjteyn.X);
		double num2 = Math.Min(_0023_003Dzd4clotAQRmaU.X, _0023_003DzfHXdNp3DXsYD.X);
		if ((num - num2) / diagonal > _0023_003DzheSR8QM7q9ya)
		{
			return false;
		}
		double num3 = Math.Max(_0023_003DzBUe0cWJwMyFd.Y, _0023_003DzDpUCutTjteyn.Y);
		double num4 = Math.Min(_0023_003Dzd4clotAQRmaU.Y, _0023_003DzfHXdNp3DXsYD.Y);
		if ((num3 - num4) / diagonal > _0023_003DzheSR8QM7q9ya)
		{
			return false;
		}
		double num5 = Math.Max(_0023_003DzBUe0cWJwMyFd.Z, _0023_003DzDpUCutTjteyn.Z);
		double num6 = Math.Min(_0023_003Dzd4clotAQRmaU.Z, _0023_003DzfHXdNp3DXsYD.Z);
		if ((num5 - num6) / diagonal > _0023_003DzheSR8QM7q9ya)
		{
			return false;
		}
		_0023_003Dz3dlnVCvIHCBp6YV6NT6E4R8_003D = new Size3D(new Point3D(num, num3, num5), new Point3D(num2, num4, num6));
		_0023_003Dz7Ol_o0jAWU2Q0S_BNA_003D_003D = new Point3D(num, num3, num5);
		_0023_003Dz8HG2JuKBpFMj_bVt8g_003D_003D = new Point3D(num2, num4, num6);
		return true;
	}

	public static Size3D IntersectionBox(Point3D firstMin, Point3D firstMax, Point3D secondMin, Point3D secondMax, out Point3D intersMin, out Point3D intersMax)
	{
		_0023_003DzrcUskCiopSzm(firstMin, firstMax, secondMin, secondMax, out var _0023_003DzBJFJHwk_003D, out var _0023_003Dz40R7bAU_003D, out var _0023_003DzId5C3LA_003D);
		intersMin = new Point3D(_0023_003DzBJFJHwk_003D[1], _0023_003Dz40R7bAU_003D[1], _0023_003DzId5C3LA_003D[1]);
		intersMax = new Point3D(_0023_003DzBJFJHwk_003D[2], _0023_003Dz40R7bAU_003D[2], _0023_003DzId5C3LA_003D[2]);
		return new Size3D(intersMin, intersMax);
	}

	private static void _0023_003DzrcUskCiopSzm(Point3D _0023_003DzBUe0cWJwMyFd, Point3D _0023_003Dzd4clotAQRmaU, Point3D _0023_003DzDpUCutTjteyn, Point3D _0023_003DzfHXdNp3DXsYD, out double[] _0023_003DzBJFJHwk_003D, out double[] _0023_003Dz40R7bAU_003D, out double[] _0023_003DzId5C3LA_003D)
	{
		_0023_003DzBJFJHwk_003D = new double[4] { _0023_003DzBUe0cWJwMyFd.X, _0023_003Dzd4clotAQRmaU.X, _0023_003DzDpUCutTjteyn.X, _0023_003DzfHXdNp3DXsYD.X };
		_0023_003Dz40R7bAU_003D = new double[4] { _0023_003DzBUe0cWJwMyFd.Y, _0023_003Dzd4clotAQRmaU.Y, _0023_003DzDpUCutTjteyn.Y, _0023_003DzfHXdNp3DXsYD.Y };
		_0023_003DzId5C3LA_003D = new double[4] { _0023_003DzBUe0cWJwMyFd.Z, _0023_003Dzd4clotAQRmaU.Z, _0023_003DzDpUCutTjteyn.Z, _0023_003DzfHXdNp3DXsYD.Z };
		Array.Sort(_0023_003DzBJFJHwk_003D);
		Array.Sort(_0023_003Dz40R7bAU_003D);
		Array.Sort(_0023_003DzId5C3LA_003D);
	}

	public static Point3D[] GetCornersOnPlane(Plane pln, Point3D min, Point3D max, double margin = 0.0)
	{
		GetSizeOnPlane(min, max, pln, out var min2, out var max2);
		Size2D size2D = new Size2D(min2, max2);
		double num = size2D.MaximumCoordinate * 0.01;
		if (size2D.X > num)
		{
			min2.X -= size2D.X * margin;
			max2.X += size2D.X * margin;
		}
		else
		{
			min2.X -= num;
			max2.X += num;
		}
		if (size2D.Y > num)
		{
			min2.Y -= size2D.Y * margin;
			max2.Y += size2D.Y * margin;
		}
		else
		{
			min2.Y -= num;
			max2.Y += num;
		}
		return new Point3D[4]
		{
			pln.PointAt(min2.X, min2.Y),
			pln.PointAt(max2.X, min2.Y),
			pln.PointAt(max2.X, max2.Y),
			pln.PointAt(min2.X, max2.Y)
		};
	}

	public static void GetSizeOnPlane(Point3D cornerMin, Point3D cornerMax, Plane pln, out Point2D min, out Point2D max)
	{
		Point3D[] boundingBoxCorners = GetBoundingBoxCorners(cornerMin, cornerMax);
		Point2D[] array = new Point2D[boundingBoxCorners.Length];
		for (int i = 0; i < boundingBoxCorners.Length; i++)
		{
			array[i] = pln.Project(boundingBoxCorners[i]);
		}
		ComputeBoundingRect(array, out min, out max);
	}

	internal static void _0023_003DzJrQHke2galGyBPw2iQ_003D_003D(double _0023_003DzsjDQiYI_003D, Point3D _0023_003DzF7v9r2A_003D, Point3D _0023_003Dz8dK2uhU_003D)
	{
		_0023_003DzF7v9r2A_003D.X -= _0023_003DzsjDQiYI_003D;
		_0023_003DzF7v9r2A_003D.Y -= _0023_003DzsjDQiYI_003D;
		_0023_003DzF7v9r2A_003D.Z -= _0023_003DzsjDQiYI_003D;
		_0023_003Dz8dK2uhU_003D.X += _0023_003DzsjDQiYI_003D;
		_0023_003Dz8dK2uhU_003D.Y += _0023_003DzsjDQiYI_003D;
		_0023_003Dz8dK2uhU_003D.Z += _0023_003DzsjDQiYI_003D;
	}

	internal static double _0023_003DzQE8nI0jAYt2jnSOq09fppKo_003D(Point3D _0023_003DzlY77YgY_003D, Point3D _0023_003Dz_0024OQWBwhmNbD6, Point3D _0023_003Dz2cdIhGv3Ra8q)
	{
		double num = ((_0023_003Dz_0024OQWBwhmNbD6.X <= _0023_003DzlY77YgY_003D.X && _0023_003DzlY77YgY_003D.X <= _0023_003Dz2cdIhGv3Ra8q.X) ? 0.0 : ((_0023_003DzlY77YgY_003D.X < _0023_003Dz_0024OQWBwhmNbD6.X) ? (_0023_003Dz_0024OQWBwhmNbD6.X - _0023_003DzlY77YgY_003D.X) : (_0023_003DzlY77YgY_003D.X - _0023_003Dz2cdIhGv3Ra8q.X)));
		double num2 = ((_0023_003Dz_0024OQWBwhmNbD6.Y <= _0023_003DzlY77YgY_003D.Y && _0023_003DzlY77YgY_003D.Y <= _0023_003Dz2cdIhGv3Ra8q.Y) ? 0.0 : ((_0023_003DzlY77YgY_003D.Y < _0023_003Dz_0024OQWBwhmNbD6.Y) ? (_0023_003Dz_0024OQWBwhmNbD6.Y - _0023_003DzlY77YgY_003D.Y) : (_0023_003DzlY77YgY_003D.Y - _0023_003Dz2cdIhGv3Ra8q.Y)));
		double num3 = ((_0023_003Dz_0024OQWBwhmNbD6.Z <= _0023_003DzlY77YgY_003D.Z && _0023_003DzlY77YgY_003D.Z <= _0023_003Dz2cdIhGv3Ra8q.Z) ? 0.0 : ((_0023_003DzlY77YgY_003D.Z < _0023_003Dz_0024OQWBwhmNbD6.Z) ? (_0023_003Dz_0024OQWBwhmNbD6.Z - _0023_003DzlY77YgY_003D.Z) : (_0023_003DzlY77YgY_003D.Z - _0023_003Dz2cdIhGv3Ra8q.Z)));
		return num * num + num2 * num2 + num3 * num3;
	}

	public static bool PointInPolygon(Point2D testPoint, IList<Point2D> polygon)
	{
		int count = polygon.Count;
		int num = 0;
		int num2 = 0;
		int index = count - 1;
		while (num2 < count)
		{
			Point2D point2D = polygon[num2];
			Point2D point2D2 = polygon[index];
			if (((point2D.Y <= testPoint.Y && testPoint.Y < point2D2.Y) || (point2D2.Y <= testPoint.Y && testPoint.Y < point2D.Y)) && testPoint.X < (point2D2.X - point2D.X) * (testPoint.Y - point2D.Y) / (point2D2.Y - point2D.Y) + point2D.X)
			{
				num++;
			}
			index = num2++;
		}
		return (num & 1) == 1;
	}

	public static pointStatusType PointInPolygon(Point2D testPoint, IList<Point2D> polygon, double domainSize)
	{
		int count = polygon.Count;
		for (int i = 0; i < count - 1; i++)
		{
			if (IsPointOnSegment(testPoint, polygon[i], polygon[i + 1], domainSize))
			{
				return pointStatusType.Onto;
			}
		}
		int num = 0;
		int num2 = 0;
		int index = count - 1;
		while (num2 < count)
		{
			if (((polygon[num2].Y <= testPoint.Y && testPoint.Y < polygon[index].Y) || (polygon[index].Y <= testPoint.Y && testPoint.Y < polygon[num2].Y)) && testPoint.X < (polygon[index].X - polygon[num2].X) * (testPoint.Y - polygon[num2].Y) / (polygon[index].Y - polygon[num2].Y) + polygon[num2].X)
			{
				num++;
			}
			index = num2++;
		}
		if ((num & 1) != 0)
		{
			return pointStatusType.Inside;
		}
		return pointStatusType.Outside;
	}

	public static pointStatusType PointInPolygon(Point2D testPoint, IList<IList<Point2D>> polygonList, double domainSize)
	{
		int num = 0;
		foreach (IList<Point2D> polygon in polygonList)
		{
			switch (PointInPolygon(testPoint, polygon, domainSize))
			{
			case pointStatusType.Onto:
				return pointStatusType.Onto;
			case pointStatusType.Inside:
				num++;
				break;
			}
		}
		if ((num & 1) != 0)
		{
			return pointStatusType.Inside;
		}
		return pointStatusType.Outside;
	}

	public static bool PointInPolygon(Point2D testPoint, IList<Polygon2D> polygonList)
	{
		int num = 0;
		foreach (Polygon2D polygon in polygonList)
		{
			if (polygon.IsPointInside(testPoint))
			{
				num++;
			}
		}
		return (num & 1) == 1;
	}

	public static pointStatusType PointInRectangle(Point2D testPoint, Point2D lowerLeft, Point2D upperRight)
	{
		Point2D[] array = new Point2D[5]
		{
			lowerLeft,
			new Point2D(upperRight.X, lowerLeft.Y),
			upperRight,
			new Point2D(lowerLeft.X, upperRight.Y),
			lowerLeft
		};
		double diagonal = new Size2D(upperRight.X - lowerLeft.X, upperRight.Y - lowerLeft.Y).Diagonal;
		int num = array.Length;
		for (int i = 0; i < num - 1; i++)
		{
			if (IsPointOnSegment(testPoint, array[i], array[i + 1], diagonal))
			{
				return pointStatusType.Onto;
			}
		}
		if (testPoint.X > lowerLeft.X && testPoint.X < upperRight.X && testPoint.Y > lowerLeft.Y && testPoint.Y < upperRight.Y)
		{
			return pointStatusType.Inside;
		}
		return pointStatusType.Outside;
	}

	public static bool PointInRect(Point2D testPoint, Point2D lowerLeft, Point2D upperRight)
	{
		if (testPoint.X > lowerLeft.X && testPoint.X < upperRight.X && testPoint.Y > lowerLeft.Y && testPoint.Y < upperRight.Y)
		{
			return true;
		}
		return false;
	}

	public static bool PointInTriangle(Point2D test, Point2D a, Point2D b, Point2D c)
	{
		return PointInTriangle(test.X, test.Y, a.X, a.Y, b.X, b.Y, c.X, c.Y);
	}

	public static bool PointInTriangle(double xP, double yP, double x1, double y1, double x2, double y2, double x3, double y3)
	{
		double[] array = new double[2]
		{
			x3 - x1,
			y3 - y1
		};
		double[] array2 = new double[2]
		{
			x2 - x1,
			y2 - y1
		};
		double[] array3 = new double[2]
		{
			xP - x1,
			yP - y1
		};
		double num = array[0] * array[0] + array[1] * array[1];
		double num2 = array[0] * array2[0] + array[1] * array2[1];
		double num3 = array[0] * array3[0] + array[1] * array3[1];
		double num4 = array2[0] * array2[0] + array2[1] * array2[1];
		double num5 = array2[0] * array3[0] + array2[1] * array3[1];
		double num6 = 1.0 / (num * num4 - num2 * num2);
		double num7 = (num4 * num3 - num2 * num5) * num6;
		double num8 = (num * num5 - num2 * num3) * num6;
		if (num7 > 0.0 && num8 > 0.0)
		{
			return num7 + num8 < 1.0;
		}
		return false;
	}

	public static bool IsPolygonConvex<T>(IList<T> vertices) where T : Point2D
	{
		int count = vertices.Count;
		if (count < 5)
		{
			return true;
		}
		double value = 0.0;
		bool flag = false;
		for (int i = 0; i < count - 1; i++)
		{
			int index = ((i > 0) ? (i - 1) : (count - 2));
			int index2 = i + 1;
			Vector2D vector2D = new Vector2D(vertices[index], vertices[i]);
			Vector2D vector2D2 = new Vector2D(vertices[i], vertices[index2]);
			vector2D.Normalize();
			vector2D2.Normalize();
			double num = Vector2D.PerpDotProduct(vector2D, vector2D2);
			if (Math.Abs(num) > 1E-12)
			{
				if (flag && Math.Sign(num) != Math.Sign(value))
				{
					return false;
				}
				flag = true;
				value = num;
			}
		}
		return true;
	}

	public static bool IsPolygonSelfIntersecting<T>(IList<T> vertices) where T : Point2D
	{
		double num = vertices.Count;
		Segment2D segment2D = new Segment2D();
		Segment2D segment2D2 = new Segment2D();
		for (int i = 0; (double)i < num - 1.0; i++)
		{
			segment2D.P0 = vertices[i];
			segment2D.P1 = vertices[i + 1];
			for (int j = i + 2; (double)j < ((i == 0) ? (num - 2.0) : (num - 1.0)); j++)
			{
				segment2D2.P0 = vertices[j];
				segment2D2.P1 = vertices[j + 1];
				if (Segment2D.Intersection(segment2D2, segment2D, out var _))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool IsPolygonCollapsed<T>(IList<T> vertices, double threshold = 0.01) where T : Point2D
	{
		int count = vertices.Count;
		new Segment2D();
		new Segment2D();
		for (int i = 0; i < count - 2; i++)
		{
			int index = i + 1;
			int index2 = (i + 2) % count;
			Vector2D asVector = (vertices[index] - vertices[i]).AsVector;
			Vector2D asVector2 = (vertices[index] - vertices[index2]).AsVector;
			asVector.Normalize();
			asVector2.Normalize();
			if (Vector2D.AngleBetween(asVector, asVector2) < 0.01)
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsPolygonDegenerated<T>(IList<T> vertices) where T : Point2D
	{
		double num = vertices.Count;
		for (int i = 0; (double)i < num - 1.0; i++)
		{
			Segment2D s = new Segment2D(vertices[i], vertices[i + 1]);
			for (int j = i + 2; (double)j < ((i == 0) ? (num - 2.0) : (num - 1.0)); j++)
			{
				if (Segment2D.IntersectionAndT(new Segment2D(vertices[j], vertices[j + 1]), s, out var _))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool IsPointInside(Point3D P, Point3D min, Point3D max, double inflateBy = 0.0, bool testOpenIntervals = true)
	{
		if (testOpenIntervals)
		{
			if (P.X > min.X - inflateBy && P.Y > min.Y - inflateBy && P.Z > min.Z - inflateBy && P.X < max.X + inflateBy && P.Y < max.Y + inflateBy && P.Z < max.Z + inflateBy)
			{
				return true;
			}
		}
		else if (P.X >= min.X - inflateBy && P.Y >= min.Y - inflateBy && P.Z >= min.Z - inflateBy && P.X <= max.X + inflateBy && P.Y <= max.Y + inflateBy && P.Z <= max.Z + inflateBy)
		{
			return true;
		}
		return false;
	}

	private static (T[], IList<T>) _0023_003DzJveBVAkAQaz6wi3xCQ_003D_003D<T>(IList<T> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dz0REmQspKVzhov2vmFzcEFIc_003D<T> _0023_003Dz4zn204U_003D) where T : ICloneable
	{
		T[] array = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Select(_0023_003DzWi8Y7HWlPE_txEBDzg_003D_003D<T>._0023_003DzJ5g3Rwo_003D._0023_003Dzx4l3Qk5jaZLzS4DfScPqjT7ca7TLqnPNJg_003D_003D).ToArray();
		T[] array2 = array.ToArray();
		Array.Sort(array2, _0023_003Dz4zn204U_003D);
		List<T> list = new List<T>();
		_0023_003Dz4zn204U_003D._0023_003DzOv1npdc_003D(array2, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D);
		int num = 0;
		while (num < array2.Length)
		{
			T val = array2[num];
			list.Add(val);
			do
			{
				num++;
			}
			while (num < array2.Length && _0023_003Dz4zn204U_003D.Compare(val, array2[num]) == 0);
		}
		return (list.ToArray(), array);
	}

	private static void _0023_003DzkNONydZnIaFv6fQF_0024avo8OM_003D<T>(IList<T> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IList<T> _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D, IReadOnlyList<int> _0023_003DzazXmgkHphnb_)
	{
		int num = 0;
		bool[] array = Enumerable.Repeat(element: false, _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D.Count).ToArray();
		for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count; i++)
		{
			if (num >= _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D.Count)
			{
				break;
			}
			if (!array[_0023_003DzazXmgkHphnb_[i]])
			{
				_0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D[_0023_003DzazXmgkHphnb_[i]] = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i];
				array[_0023_003DzazXmgkHphnb_[i]] = true;
				num++;
			}
		}
	}

	private static int[] _0023_003DzLEPRxd0XWBAy<T>(IList<T> _0023_003Dzx4IUarR974NZ4VLN3A_003D_003D, T[] _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D, IComparer<T> _0023_003Dz4zn204U_003D, IList<T> _0023_003DzW4Bg3MhcXb29L_0024XX_CQh04dvIGJp)
	{
		int[] array = new int[_0023_003Dzx4IUarR974NZ4VLN3A_003D_003D.Count];
		for (int i = 0; i < _0023_003Dzx4IUarR974NZ4VLN3A_003D_003D.Count; i++)
		{
			array[i] = Array.BinarySearch(_0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D, _0023_003Dzx4IUarR974NZ4VLN3A_003D_003D[i], _0023_003Dz4zn204U_003D);
		}
		_0023_003DzkNONydZnIaFv6fQF_0024avo8OM_003D(_0023_003DzW4Bg3MhcXb29L_0024XX_CQh04dvIGJp, _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D, array);
		return array;
	}

	private static void _0023_003DzPSBHfLpYLpHxGG6O9w_003D_003D(object _0023_003DzNDQ_E88_003D, IReadOnlyList<int> _0023_003DzCS02Bu0_003D)
	{
		QuadraticTriangle quadraticTriangle = (QuadraticTriangle)_0023_003DzNDQ_E88_003D;
		quadraticTriangle.V1 = _0023_003DzCS02Bu0_003D[quadraticTriangle.V1];
		quadraticTriangle.V2 = _0023_003DzCS02Bu0_003D[quadraticTriangle.V2];
		quadraticTriangle.V3 = _0023_003DzCS02Bu0_003D[quadraticTriangle.V3];
		quadraticTriangle.V4 = _0023_003DzCS02Bu0_003D[quadraticTriangle.V4];
		quadraticTriangle.V5 = _0023_003DzCS02Bu0_003D[quadraticTriangle.V5];
		quadraticTriangle.V6 = _0023_003DzCS02Bu0_003D[quadraticTriangle.V6];
	}

	private static Func<T, T> _0023_003DzyuHBbRCsL1_0024BVa9R6A_003D_003D<T>(IReadOnlyList<int> _0023_003DzCS02Bu0_003D, bool _0023_003DzFwalihjMriJGyFaGGg_003D_003D) where T : IIndexObject
	{
		_0023_003DzJXFwcQeUoj_0024yhfwAUnzcfrs_003D<T> _0023_003DzJXFwcQeUoj_0024yhfwAUnzcfrs_003D2 = new _0023_003DzJXFwcQeUoj_0024yhfwAUnzcfrs_003D<T>();
		_0023_003DzJXFwcQeUoj_0024yhfwAUnzcfrs_003D2._0023_003DzCS02Bu0_003D = _0023_003DzCS02Bu0_003D;
		if (!_0023_003DzFwalihjMriJGyFaGGg_003D_003D)
		{
			return _0023_003DzJXFwcQeUoj_0024yhfwAUnzcfrs_003D2._0023_003DzzWoFMm_cVzNQ_RRoC_YYHc0_003D;
		}
		return _0023_003DzJXFwcQeUoj_0024yhfwAUnzcfrs_003D2._0023_003Dzbxld8NEHHD5oAYaX0jAlQ6I_003D;
	}

	private static T[] _0023_003DzmX43G41ZXLsJy8gLkA_003D_003D<T>(ICollection<T> _0023_003DzzLs0hQ4_003D, IReadOnlyList<int> _0023_003DzCS02Bu0_003D, bool _0023_003DzWxpozSh5zXqB, bool _0023_003DzFwalihjMriJGyFaGGg_003D_003D) where T : IIndexObject
	{
		_0023_003DzebzciKwXEYAeg8D4y0YRM6E_003D<T> CS_0024_003C_003E8__locals5 = new _0023_003DzebzciKwXEYAeg8D4y0YRM6E_003D<T>();
		CS_0024_003C_003E8__locals5._0023_003DzCS02Bu0_003D = _0023_003DzCS02Bu0_003D;
		if (_0023_003DzzLs0hQ4_003D.Count != 0)
		{
			if (_0023_003DzzLs0hQ4_003D.Count >= 100)
			{
				return _0023_003DzzLs0hQ4_003D.AsParallel()._0023_003DzZLKOWsybRUkG(_0023_003DzWxpozSh5zXqB ? ((Func<T, bool>)((T _0023_003DzNDQ_E88_003D) => !_0023_003DzNDQ_E88_003D.WouldContainDuplicates(CS_0024_003C_003E8__locals5._0023_003DzCS02Bu0_003D))) : null).Select(_0023_003DzyuHBbRCsL1_0024BVa9R6A_003D_003D<T>(CS_0024_003C_003E8__locals5._0023_003DzCS02Bu0_003D, _0023_003DzFwalihjMriJGyFaGGg_003D_003D))
					.ToArray();
			}
			return _0023_003DzzLs0hQ4_003D._0023_003DzZLKOWsybRUkG(_0023_003DzWxpozSh5zXqB ? new Func<T, bool>(CS_0024_003C_003E8__locals5._0023_003DzQaRt4Kl_JnE7MqwSdHAkOZQ_003D) : null).Select(_0023_003DzyuHBbRCsL1_0024BVa9R6A_003D_003D<T>(CS_0024_003C_003E8__locals5._0023_003DzCS02Bu0_003D, _0023_003DzFwalihjMriJGyFaGGg_003D_003D)).ToArray();
		}
		return Array.Empty<T>();
	}

	private static void _0023_003Dz_cbjoiU_003D(IEnumerable<IndexLine> _0023_003DzU3hosSAzkxO7, IReadOnlyList<int> _0023_003DzCS02Bu0_003D)
	{
		_0023_003Dz0zaVEEEnjAUqYX0cjimZwVA_003D _0023_003Dz0zaVEEEnjAUqYX0cjimZwVA_003D2 = new _0023_003Dz0zaVEEEnjAUqYX0cjimZwVA_003D();
		_0023_003Dz0zaVEEEnjAUqYX0cjimZwVA_003D2._0023_003DzCS02Bu0_003D = _0023_003DzCS02Bu0_003D;
		_0023_003DzU3hosSAzkxO7?.AsParallel().ForAll(_0023_003Dz0zaVEEEnjAUqYX0cjimZwVA_003D2._0023_003Dz0pLrH7CaUIXPdb5zKg_003D_003D);
	}

	private static void _0023_003Dz6gmQ5dc_003D<TObject, TVertex>(ICollection<TObject> _0023_003DzzLs0hQ4_003D, IEnumerable<IndexLine> _0023_003DzU3hosSAzkxO7, IList<TVertex> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dz0REmQspKVzhov2vmFzcEFIc_003D<TVertex> _0023_003Dz4zn204U_003D, out TObject[] _0023_003DzzKJvOF43GAeD4kfn9Q_003D_003D, out TVertex[] _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D, double _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, bool _0023_003DzWxpozSh5zXqB, bool _0023_003DzFwalihjMriJGyFaGGg_003D_003D) where TObject : IIndexObject, ICloneable where TVertex : ICloneable
	{
		(TVertex[], IList<TVertex>) tuple = _0023_003DzJveBVAkAQaz6wi3xCQ_003D_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzuMKQhOieejyEvhtVOw_003D_003D, _0023_003Dz4zn204U_003D);
		_0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D = tuple.Item1;
		int[] _0023_003DzCS02Bu0_003D = _0023_003DzLEPRxd0XWBAy(tuple.Item2, _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D, _0023_003Dz4zn204U_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D);
		_0023_003DzzKJvOF43GAeD4kfn9Q_003D_003D = _0023_003DzmX43G41ZXLsJy8gLkA_003D_003D(_0023_003DzzLs0hQ4_003D, _0023_003DzCS02Bu0_003D, _0023_003DzWxpozSh5zXqB, _0023_003DzFwalihjMriJGyFaGGg_003D_003D);
		_0023_003Dz_cbjoiU_003D(_0023_003DzU3hosSAzkxO7, _0023_003DzCS02Bu0_003D);
	}

	internal static void _0023_003DzJNADeOQRO6_fPmN4Ig_003D_003D(IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, IList<IndexLine> _0023_003DzU3hosSAzkxO7, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out IndexTriangle[] _0023_003DzPSHPV1adgQcYEwqKXHGDJDXML8EU, out Point3D[] _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D, double _0023_003Dz9wdlyq0lljpO, bool _0023_003Dz5syaaeMy5pLBOZfa4Kfhgq4_003D, bool _0023_003DzFwalihjMriJGyFaGGg_003D_003D)
	{
		_0023_003Dz6gmQ5dc_003D(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzU3hosSAzkxO7, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, new _0023_003DzNCfzh2Axy2MCradzXQ_003D_003D(), out _0023_003DzPSHPV1adgQcYEwqKXHGDJDXML8EU, out _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D, _0023_003Dz9wdlyq0lljpO, _0023_003Dz5syaaeMy5pLBOZfa4Kfhgq4_003D, _0023_003DzFwalihjMriJGyFaGGg_003D_003D);
	}

	internal static double _0023_003DzKN_0024vjGN5_0024fwYJSS8TN63qBo_003D(double _0023_003Dzkmd4nWhpCdlsyk_YHw_003D_003D)
	{
		return _0023_003Dzkmd4nWhpCdlsyk_YHw_003D_003D * _0023_003DzheSR8QM7q9ya;
	}

	internal static double _0023_003DzKN_0024vjGN5_0024fwYJSS8TN63qBo_003D<T>(IList<T> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D) where T : Point3D
	{
		ComputeBoundingBox(new Identity(), _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count, out var boxMin, out var boxMax);
		return _0023_003DzKN_0024vjGN5_0024fwYJSS8TN63qBo_003D(boxMin.DistanceTo(boxMax));
	}

	private static void _0023_003DzJNADeOQRO6_fPmN4Ig_003D_003D(IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out IndexTriangle[] _0023_003DzPSHPV1adgQcYEwqKXHGDJDXML8EU, out Point3D[] _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D, double _0023_003Dz9wdlyq0lljpO)
	{
		_0023_003DzJNADeOQRO6_fPmN4Ig_003D_003D(_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, null, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out _0023_003DzPSHPV1adgQcYEwqKXHGDJDXML8EU, out _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D, _0023_003Dz9wdlyq0lljpO, _0023_003Dz5syaaeMy5pLBOZfa4Kfhgq4_003D: true, _0023_003DzFwalihjMriJGyFaGGg_003D_003D: false);
	}

	public static void CleanTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, out IndexTriangle[] cleanedTriangles, out Point3D[] uniqueVertices)
	{
		_0023_003DzJNADeOQRO6_fPmN4Ig_003D_003D(triangles, vertices, out cleanedTriangles, out uniqueVertices, _0023_003DzKN_0024vjGN5_0024fwYJSS8TN63qBo_003D(vertices));
	}

	internal static void _0023_003DzOGhpleFE54vE(IList<IndexQuad> _0023_003Dza2wpOzatpF2A, IList<PointNormalUv> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, out IndexQuad[] _0023_003DzIcWg2gnk_00247PoQ4G1gwIHc9I_003D, out PointNormalUv[] _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D)
	{
		_0023_003Dz6gmQ5dc_003D(_0023_003Dza2wpOzatpF2A, null, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, new _0023_003Dz5gWigDbfQ_0024Jn3SJ0J5A2BYM_003D(), out _0023_003DzIcWg2gnk_00247PoQ4G1gwIHc9I_003D, out _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D, _0023_003DzKN_0024vjGN5_0024fwYJSS8TN63qBo_003D(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D), _0023_003DzWxpozSh5zXqB: false, _0023_003DzFwalihjMriJGyFaGGg_003D_003D: false);
	}

	internal static void _0023_003DzepEAzpTGgC_4(ref Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, ref _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[] _0023_003DzD_4yRKeiIPD1, IndexLine[] _0023_003DzU3hosSAzkxO7, double _0023_003DzX0qX_IwWxysi, out _0023_003Dzk2XeTK2Hmq5Jcb1G55CZL7A_003D[] _0023_003DzabSzpyKrzcO8xP7ZnA_003D_003D, out Point3D[] _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D)
	{
		_0023_003Dz6gmQ5dc_003D(_0023_003DzD_4yRKeiIPD1, _0023_003DzU3hosSAzkxO7, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, new _0023_003DzNCfzh2Axy2MCradzXQ_003D_003D(), out _0023_003DzabSzpyKrzcO8xP7ZnA_003D_003D, out _0023_003DzrnJjSihyGwPQqq_0024JUA_003D_003D, _0023_003DzX0qX_IwWxysi, _0023_003DzWxpozSh5zXqB: true, _0023_003DzFwalihjMriJGyFaGGg_003D_003D: false);
	}

	public static bool AreEqual(double a, double b, double domainSize)
	{
		return Math.Abs(b - a) / domainSize < 1E-09;
	}

	public static int Compare(double a, double b)
	{
		double num = (Math.Abs(a) + Math.Abs(b)) * 1.490116119385E-08;
		if (num < 1E-12)
		{
			num = 1E-12;
		}
		if (a < b - num)
		{
			return -1;
		}
		if (b < a - num)
		{
			return 1;
		}
		return 0;
	}

	public static int Compare(double tol, double a, double b)
	{
		if (a < b - tol)
		{
			return -1;
		}
		if (b < a - tol)
		{
			return 1;
		}
		return 0;
	}

	public static int CompareWithoutTolerance(double a, double b)
	{
		if (a < b)
		{
			return -1;
		}
		if (b < a)
		{
			return 1;
		}
		return 0;
	}

	public static int Compare(long a, long b)
	{
		if (a < b)
		{
			return -1;
		}
		if (b < a)
		{
			return 1;
		}
		return 0;
	}

	public static bool PointCoincidence(Vector3D p, Vector3D q, double problemSize, out Vector3D r, out double rLen, double coincTol = 1E-10)
	{
		r = q - p;
		rLen = r.Length;
		return rLen / problemSize < coincTol;
	}

	public static bool ParametersDontChangeSignificantly(double stepLength, double problemSize)
	{
		return stepLength / problemSize < 1E-12;
	}

	private static void _0023_003DzzpnSohNwUKjz4kUOef2slQo_003D()
	{
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "V#C;mq\"ad&", null);
	}

	[AmbientValue(true)]
	internal static void _0023_003DzVlx406WWXDJOlqfoiV1SGJU_003D(Exception _0023_003Dz28FDiEs_003D)
	{
		object[] _0023_003DzAvn2b38_003D = new object[1] { _0023_003Dz28FDiEs_003D };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "55kK\\q\"acj", _0023_003DzAvn2b38_003D);
	}

	internal static void _0023_003Dzkbdl2RNkTQTU(string _0023_003DzuahRn9M_003D, TraceLevel _0023_003DzLC4gNyPZPfnJ, Exception _0023_003DzSQYc_0024aE_003D, object[] _0023_003Dz53Cncpw_003D)
	{
		if ((bool)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "XSr.uq\"acN", null))
		{
			switch (_0023_003DzLC4gNyPZPfnJ)
			{
			case TraceLevel.Error:
				Logger.Instance.Error(_0023_003DzuahRn9M_003D, _0023_003DzSQYc_0024aE_003D, _0023_003Dz53Cncpw_003D);
				break;
			case TraceLevel.Warning:
				Logger.Instance.Warn(_0023_003DzuahRn9M_003D, _0023_003DzSQYc_0024aE_003D, _0023_003Dz53Cncpw_003D);
				break;
			case TraceLevel.Info:
				Logger.Instance.Info(_0023_003DzuahRn9M_003D, _0023_003Dz53Cncpw_003D);
				break;
			case TraceLevel.Verbose:
				Logger.Instance.Trace(_0023_003DzuahRn9M_003D, _0023_003Dz53Cncpw_003D);
				break;
			}
		}
	}

	internal static double _0023_003Dz8s608KleYwNYvOtWkA_003D_003D(Func<double, double> _0023_003DzhidJeNw_003D, double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003DzrLeCfGcIfz7P)
	{
		int _0023_003DztlbGKC7GtKDN1adZAw_003D_003D;
		double _0023_003DzSkwcd6MT2HxSd_0024MPdg_003D_003D;
		return _0023_003Dz8s608KleYwNYvOtWkA_003D_003D(_0023_003DzhidJeNw_003D, _0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D, _0023_003DzrLeCfGcIfz7P, 20, out _0023_003DztlbGKC7GtKDN1adZAw_003D_003D, out _0023_003DzSkwcd6MT2HxSd_0024MPdg_003D_003D);
	}

	internal static double _0023_003Dz8s608KleYwNYvOtWkA_003D_003D(Func<double, double> _0023_003DzhidJeNw_003D, double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003DzpduTDKBJsIQh, int _0023_003DzfH0HrozQ4kFViQaqeHj8HoE_003D, out int _0023_003DztlbGKC7GtKDN1adZAw_003D_003D, out double _0023_003DzSkwcd6MT2HxSd_0024MPdg_003D_003D)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		_0023_003DztlbGKC7GtKDN1adZAw_003D_003D = 0;
		_0023_003DzSkwcd6MT2HxSd_0024MPdg_003D_003D = double.MaxValue;
		for (int i = 0; i <= _0023_003DzfH0HrozQ4kFViQaqeHj8HoE_003D; i++)
		{
			if (i == 0)
			{
				num5 = _0023_003DzhidJeNw_003D(_0023_003DzjbqS1qE_003D) + _0023_003DzhidJeNw_003D(_0023_003Dz1v6oPQk_003D);
				_0023_003DztlbGKC7GtKDN1adZAw_003D_003D = 2;
				num = num5 * 0.5 * (_0023_003Dz1v6oPQk_003D - _0023_003DzjbqS1qE_003D);
				continue;
			}
			int num6 = 1 << i - 1;
			num2 = 0.0;
			double num7 = (_0023_003Dz1v6oPQk_003D - _0023_003DzjbqS1qE_003D) / (double)num6;
			double num8 = _0023_003DzjbqS1qE_003D + 0.5 * num7;
			for (int j = 0; j < num6; j++)
			{
				num2 += _0023_003DzhidJeNw_003D(num8 + (double)j * num7);
			}
			_0023_003DztlbGKC7GtKDN1adZAw_003D_003D += num6;
			num2 *= 4.0;
			num5 += num2 - 0.5 * num3;
			num = num5 * (_0023_003Dz1v6oPQk_003D - _0023_003DzjbqS1qE_003D) / ((double)(1 << i) * 3.0);
			if (i >= 5)
			{
				_0023_003DzSkwcd6MT2HxSd_0024MPdg_003D_003D = Math.Abs(num - num4);
				if (_0023_003DzSkwcd6MT2HxSd_0024MPdg_003D_003D <= _0023_003DzpduTDKBJsIQh * Math.Abs(num4))
				{
					return num;
				}
			}
			num3 = num2;
			num4 = num;
		}
		return num;
	}

	internal static void _0023_003Dz6kYhc4pAp6ud(Arc _0023_003DzN4MDZ_0024c_003D, ref double _0023_003DzNDQ_E88_003D)
	{
		Interval _0023_003DzhbkBViI_003D = _0023_003DzN4MDZ_0024c_003D.Domain;
		_0023_003DzE_0024JdjFjbsAFt(ref _0023_003DzhbkBViI_003D, ref _0023_003DzNDQ_E88_003D);
		_0023_003DzN4MDZ_0024c_003D.Domain = _0023_003DzhbkBViI_003D;
	}

	internal static void _0023_003Dz6kYhc4pAp6ud(EllipticalArc _0023_003DzN4MDZ_0024c_003D, ref double _0023_003DzNDQ_E88_003D)
	{
		Interval _0023_003DzhbkBViI_003D = _0023_003DzN4MDZ_0024c_003D.Domain;
		_0023_003DzE_0024JdjFjbsAFt(ref _0023_003DzhbkBViI_003D, ref _0023_003DzNDQ_E88_003D);
		_0023_003DzN4MDZ_0024c_003D.Domain = _0023_003DzhbkBViI_003D;
	}

	internal static void _0023_003Dz6kYhc4pAp6ud(Arc _0023_003DzN4MDZ_0024c_003D)
	{
		Interval _0023_003DzhbkBViI_003D = _0023_003DzN4MDZ_0024c_003D.Domain;
		_0023_003DzE_0024JdjFjbsAFt(ref _0023_003DzhbkBViI_003D);
		_0023_003DzN4MDZ_0024c_003D.Domain = _0023_003DzhbkBViI_003D;
	}

	internal static void _0023_003Dz6kYhc4pAp6ud(EllipticalArc _0023_003DzN4MDZ_0024c_003D)
	{
		Interval _0023_003DzhbkBViI_003D = _0023_003DzN4MDZ_0024c_003D.Domain;
		_0023_003DzE_0024JdjFjbsAFt(ref _0023_003DzhbkBViI_003D);
		_0023_003DzN4MDZ_0024c_003D.Domain = _0023_003DzhbkBViI_003D;
	}

	private static void _0023_003DzE_0024JdjFjbsAFt(ref Interval _0023_003DzhbkBViI_003D, ref double _0023_003DzNDQ_E88_003D)
	{
		double num = Math.PI * 2.0;
		if (_0023_003DzhbkBViI_003D.High > num)
		{
			double num2 = Math.Floor(_0023_003DzhbkBViI_003D.High / num) * num;
			_0023_003DzhbkBViI_003D = new Interval(_0023_003DzhbkBViI_003D.Low - num2, _0023_003DzhbkBViI_003D.High - num2);
			_0023_003DzNDQ_E88_003D -= num2;
		}
		else
		{
			while (_0023_003DzhbkBViI_003D.Low < 0.0)
			{
				_0023_003DzhbkBViI_003D = new Interval(_0023_003DzhbkBViI_003D.Low + num, _0023_003DzhbkBViI_003D.High + num);
				_0023_003DzNDQ_E88_003D += num;
			}
		}
	}

	public static void UpdateAnalyticSurfSense(Surface special, ref bool faceSense)
	{
		if (special.GetType() == typeof(SphericalSurface))
		{
			SphericalSurface sphericalSurface = (SphericalSurface)special;
			Vector3D vector3D = new Vector3D(sphericalSurface.Plane.Origin, sphericalSurface.PointAt(sphericalSurface.DomainU.Mid, sphericalSurface.DomainV.Min));
			vector3D.Normalize();
			Vector3D v = sphericalSurface.NormalAt(sphericalSurface.DomainU.Mid, sphericalSurface.DomainV.Min);
			if (Vector3D.AreOpposite(vector3D, v, _0023_003Dzjyaz_Vfaky9X))
			{
				faceSense = !faceSense;
			}
		}
	}

	private static void _0023_003DzE_0024JdjFjbsAFt(ref Interval _0023_003DzhbkBViI_003D)
	{
		double _0023_003DzNDQ_E88_003D = 0.0;
		_0023_003DzE_0024JdjFjbsAFt(ref _0023_003DzhbkBViI_003D, ref _0023_003DzNDQ_E88_003D);
	}

	internal static void _0023_003Dz7iiwRWggF9n_(Interval _0023_003DzJUOlPYhShISQ, ref Interval _0023_003DzhbkBViI_003D)
	{
		double num = Math.PI * 2.0;
		if (_0023_003DzJUOlPYhShISQ.High > num)
		{
			double num2 = Math.Floor(_0023_003DzJUOlPYhShISQ.High / num) * num;
			_0023_003DzhbkBViI_003D = new Interval(_0023_003DzhbkBViI_003D.Low + num2, _0023_003DzhbkBViI_003D.High + num2);
		}
		else if (_0023_003DzJUOlPYhShISQ.Low < 0.0)
		{
			while (_0023_003DzhbkBViI_003D.Low >= 0.0)
			{
				_0023_003DzhbkBViI_003D = new Interval(_0023_003DzhbkBViI_003D.Low - num, _0023_003DzhbkBViI_003D.High - num);
			}
		}
	}

	public static bool AngleMinimizer(Curve curve, Vector3D dUnit, int maxIter, double tolerance, ref double u)
	{
		double t = curve.Domain.t0;
		double t2 = curve.Domain.t1;
		for (int i = 0; i < maxIter; i++)
		{
			Vector3D[] array = curve.Evaluate(u, 2);
			Vector3D vector3D = array[1];
			Vector3D vector3D2 = array[2];
			if (Math.Abs(vector3D * dUnit) < tolerance)
			{
				return true;
			}
			double num = vector3D * dUnit;
			double num2 = vector3D2 * dUnit;
			double num3 = u - num / num2;
			if (num3 < t)
			{
				num3 = t;
			}
			if (num3 > t2)
			{
				num3 = t2;
			}
			if (num3 - u == 0.0)
			{
				return false;
			}
			u = num3;
		}
		return false;
	}

	public static T[] DeepCopy<T>(T[] toCopy) where T : ICloneable
	{
		T[] array = new T[toCopy.Length];
		for (int i = 0; i < toCopy.Length; i++)
		{
			if (toCopy[i] != null)
			{
				array[i] = (T)toCopy[i].Clone();
			}
		}
		return array;
	}

	public static List<T> DeepCopy<T>(List<T> toCopy) where T : ICloneable
	{
		return toCopy.Select((T _0023_003DzBJFJHwk_003D) => (T)_0023_003DzBJFJHwk_003D.Clone()).ToList();
	}

	public static double GetDeviation(Point3D a, Vector3D aTan, Point3D b, Vector3D bTan, out double radius)
	{
		double num = Point3D.Distance(a, b);
		radius = num / Vector3D.AngleBetween(aTan, bTan);
		return _0023_003Dz_0024fuLDgcrIC4UriDYvw_003D_003D(num, radius);
	}

	public static double GetDeviation2D(Point2D a, Vector2D aTan, Point2D b, Vector2D bTan, out double radius)
	{
		double num = Point2D.Distance(a, b);
		radius = num / Vector2D.AngleBetween(aTan, bTan);
		return _0023_003Dz_0024fuLDgcrIC4UriDYvw_003D_003D(num, radius);
	}

	private static double _0023_003Dz_0024fuLDgcrIC4UriDYvw_003D_003D(double _0023_003DzYUMqwZQ_003D, double _0023_003DzAYqOj_Y_003D)
	{
		double num = _0023_003DzYUMqwZQ_003D / 2.0;
		if (num < _0023_003DzAYqOj_Y_003D)
		{
			double num2 = Math.Sqrt(_0023_003DzAYqOj_Y_003D * _0023_003DzAYqOj_Y_003D - num * num);
			return _0023_003DzAYqOj_Y_003D - num2;
		}
		return _0023_003DzAYqOj_Y_003D;
	}

	public static bool IsImperial(linearUnitsType units)
	{
		if (units != linearUnitsType.Inches && units != linearUnitsType.Feet)
		{
			return units == linearUnitsType.Miles;
		}
		return true;
	}

	public static bool IsImperial(massUnitsType units)
	{
		if (units != massUnitsType.Ounces && units != massUnitsType.Pounds && units != massUnitsType.Stones && units != massUnitsType.ShortTons)
		{
			return units == massUnitsType.LongTons;
		}
		return true;
	}

	public static string WriteFloatNumber(double value)
	{
		string text = value.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910425), CultureInfo.InvariantCulture.NumberFormat);
		if (text.IndexOf('.') == -1 && text.IndexOf('e') == -1)
		{
			text += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290);
		}
		return text;
	}

	public static double RadToDeg(double radians)
	{
		return radians * 180.0 / Math.PI;
	}

	public static double DegToRad(double degrees)
	{
		return degrees * Math.PI / 180.0;
	}

	public static double Clamp(in double val, in double min, in double max)
	{
		if (!(val > max))
		{
			if (!(val < min))
			{
				return val;
			}
			return min;
		}
		return max;
	}

	public static int Clamp(in int val, in int min, in int max)
	{
		if (val <= max)
		{
			if (val >= min)
			{
				return val;
			}
			return min;
		}
		return max;
	}

	public static float Clamp(in float val, in float min, in float max)
	{
		if (!(val > max))
		{
			if (!(val < min))
			{
				return val;
			}
			return min;
		}
		return max;
	}

	public static byte Clamp(in byte val, in byte min, in byte max)
	{
		if (val <= max)
		{
			if (val >= min)
			{
				return val;
			}
			return min;
		}
		return max;
	}

	public static void LimitRange(double low, ref double value, double high)
	{
		value = Clamp(in value, in low, in high);
	}

	public static void LimitRange(int low, ref int value, int high)
	{
		value = Clamp(in value, in low, in high);
	}

	public static void LimitRange(float low, ref float value, float high)
	{
		value = Clamp(in value, in low, in high);
	}

	public static void LimitRange(byte low, ref byte value, byte high)
	{
		value = Clamp(in value, in low, in high);
	}

	public static devDept.Geometry.ConstraintSolver.Constraint CloneTangentConstraintAtRightParameterInternal(TangentConstraint tangentConstraint, ICurve curve, ICurve curve1, ICurve curve2, SketchCurve newSketchCurve1, SketchCurve newSketchCurve2, SketchCurve oldSketchCurve)
	{
		_0023_003DzsCSRcdgSAaTUtL9m_65y0_A_003D _0023_003DzsCSRcdgSAaTUtL9m_65y0_A_003D2 = new _0023_003DzsCSRcdgSAaTUtL9m_65y0_A_003D();
		_0023_003DzsCSRcdgSAaTUtL9m_65y0_A_003D2._0023_003DzyGC5ZI76ZaE2HTUyhA_003D_003D = oldSketchCurve;
		double t = ((tangentConstraint.GetEntities()[0] == null) ? tangentConstraint.FirstParam : tangentConstraint.SecondParam);
		curve.ClosestPointTo(_0023_003DzsCSRcdgSAaTUtL9m_65y0_A_003D2._0023_003DzyGC5ZI76ZaE2HTUyhA_003D_003D.PointAt(t), out var t2);
		if (curve1.Domain.Includes(t2, testOpenInterval: false))
		{
			return tangentConstraint._0023_003DzXITeosZelhmK(newSketchCurve1, tangentConstraint.GetEntities().FirstOrDefault(_0023_003DzsCSRcdgSAaTUtL9m_65y0_A_003D2._0023_003Dzcz_2WbVdul1sYAFz5pJIY7CAgLfo));
		}
		return tangentConstraint._0023_003DzXITeosZelhmK(newSketchCurve2, tangentConstraint.GetEntities().FirstOrDefault(_0023_003DzsCSRcdgSAaTUtL9m_65y0_A_003D2._0023_003DzwgQMe9HWWDdEfCo0JQkExJKb3Vz3));
	}

	public static void ReplaceOldConstraints(devDept.Geometry.ConstraintSolver.Constraint[] constraints, SketchCurve newSketchCurve, SketchCurve oldSketchCure, out devDept.Geometry.ConstraintSolver.Constraint[] cloned)
	{
		_0023_003DzAtGjYqeB5saLo1gpAIWB6TI_003D CS_0024_003C_003E8__locals3 = new _0023_003DzAtGjYqeB5saLo1gpAIWB6TI_003D();
		CS_0024_003C_003E8__locals3._0023_003DzDIkJozyJywX_oLeB6SD5yFc_003D = oldSketchCure;
		List<devDept.Geometry.ConstraintSolver.Constraint> list = new List<devDept.Geometry.ConstraintSolver.Constraint>();
		foreach (devDept.Geometry.ConstraintSolver.Constraint constraint in constraints)
		{
			if (constraint is LengthConstraint)
			{
				continue;
			}
			devDept.Geometry.ConstraintSolver.Constraint constraint2 = constraint._0023_003DzXITeosZelhmK(newSketchCurve, (from _0023_003Dzs_0024uS8LA_003D in constraint.GetEntities()
				where _0023_003Dzs_0024uS8LA_003D != null && _0023_003Dzs_0024uS8LA_003D != CS_0024_003C_003E8__locals3._0023_003DzDIkJozyJywX_oLeB6SD5yFc_003D
				select _0023_003Dzs_0024uS8LA_003D).FirstOrDefault());
			if (constraint2 != null)
			{
				if (!CS_0024_003C_003E8__locals3._0023_003DzDIkJozyJywX_oLeB6SD5yFc_003D._0023_003DzCJa3xJlr6RLsK4xYxg_003D_003D()._0023_003Dzqh_BTJs_003D(constraint2))
				{
					constraint2.Destroy();
				}
				else
				{
					list.Add(constraint2);
				}
			}
		}
		cloned = list.ToArray();
	}

	public static devDept.Geometry.ConstraintSolver.Constraint CloneConstraintAtRightParameter(devDept.Geometry.ConstraintSolver.Constraint constraint, ICurve curve, ICurve curve1, ICurve curve2, SketchCurve newSketchCurve1, SketchCurve newSketchCurve2, SketchCurve oldSketchCurve)
	{
		_0023_003DzJB7y4PKxFmsMx4pav3Nd2fo_003D _0023_003DzJB7y4PKxFmsMx4pav3Nd2fo_003D2 = new _0023_003DzJB7y4PKxFmsMx4pav3Nd2fo_003D();
		_0023_003DzJB7y4PKxFmsMx4pav3Nd2fo_003D2._0023_003DzyGC5ZI76ZaE2HTUyhA_003D_003D = oldSketchCurve;
		if (constraint is TangentConstraint tangentConstraint)
		{
			return CloneTangentConstraintAtRightParameterInternal(tangentConstraint, curve, curve1, curve2, newSketchCurve1, newSketchCurve2, _0023_003DzJB7y4PKxFmsMx4pav3Nd2fo_003D2._0023_003DzyGC5ZI76ZaE2HTUyhA_003D_003D);
		}
		if (constraint.GetType() == typeof(PointOnConstraint))
		{
			Point3D position = ((SketchPoint)((PointOnConstraint)constraint).Point).Position;
			curve.Project(position, out var t);
			SketchCurve _0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D = newSketchCurve1;
			if (curve2.Domain.Includes(t, testOpenInterval: false))
			{
				_0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D = newSketchCurve2;
			}
			return constraint._0023_003DzXITeosZelhmK(_0023_003Dz8y2RdxeriOVAZjAcCg_003D_003D, constraint.GetEntities().FirstOrDefault(_0023_003DzJB7y4PKxFmsMx4pav3Nd2fo_003D2._0023_003DzBG34o_JzybGL1GKyfGVk6OQ_003D));
		}
		return constraint._0023_003DzXITeosZelhmK(newSketchCurve2, constraint.GetEntities().FirstOrDefault(_0023_003DzJB7y4PKxFmsMx4pav3Nd2fo_003D2._0023_003DzKhht_YEi9duiCjIPUiviCbs_003D));
	}

	public static double Max(double a, double b, double c)
	{
		if (!(c > a))
		{
			if (!(b > a))
			{
				return a;
			}
			return b;
		}
		if (!(c > b))
		{
			return b;
		}
		return c;
	}

	public static int Max(int a, int b, int c)
	{
		if (c <= a)
		{
			if (b <= a)
			{
				return a;
			}
			return b;
		}
		if (c <= b)
		{
			return b;
		}
		return c;
	}

	public static double Min(double a, double b, double c)
	{
		if (!(c < a))
		{
			if (!(b < a))
			{
				return a;
			}
			return b;
		}
		if (!(c < b))
		{
			return b;
		}
		return c;
	}

	internal static double _0023_003DzFSl4vWLaTYwafgTfDg_003D_003D(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003DzjdeMMkk_003D, Point3D _0023_003Dzm4eSPQQ_003D, Vector3D _0023_003DzoMNiNRw_003D)
	{
		return _0023_003DzoMNiNRw_003D.X * (_0023_003DzjdeMMkk_003D.Y - _0023_003DzFj_0024IqDQ_003D.Y) * (_0023_003Dzm4eSPQQ_003D.Z - _0023_003DzFj_0024IqDQ_003D.Z) + _0023_003DzoMNiNRw_003D.Y * (_0023_003DzjdeMMkk_003D.Z - _0023_003DzFj_0024IqDQ_003D.Z) * (_0023_003Dzm4eSPQQ_003D.X - _0023_003DzFj_0024IqDQ_003D.X) + _0023_003DzoMNiNRw_003D.Z * (_0023_003DzjdeMMkk_003D.X - _0023_003DzFj_0024IqDQ_003D.X) * (_0023_003Dzm4eSPQQ_003D.Y - _0023_003DzFj_0024IqDQ_003D.Y) - _0023_003DzoMNiNRw_003D.Z * (_0023_003DzjdeMMkk_003D.Y - _0023_003DzFj_0024IqDQ_003D.Y) * (_0023_003Dzm4eSPQQ_003D.X - _0023_003DzFj_0024IqDQ_003D.X) - _0023_003DzoMNiNRw_003D.Y * (_0023_003DzjdeMMkk_003D.X - _0023_003DzFj_0024IqDQ_003D.X) * (_0023_003Dzm4eSPQQ_003D.Z - _0023_003DzFj_0024IqDQ_003D.Z) - _0023_003DzoMNiNRw_003D.X * (_0023_003DzjdeMMkk_003D.Z - _0023_003DzFj_0024IqDQ_003D.Z) * (_0023_003Dzm4eSPQQ_003D.Y - _0023_003DzFj_0024IqDQ_003D.Y);
	}

	public static double TriangleSignedArea(Point3D p1, Point3D p2, Point3D p3, Vector3D n)
	{
		return _0023_003DzFSl4vWLaTYwafgTfDg_003D_003D(p1, p2, p3, n) / 2.0;
	}

	public static bool IsOrientedClockwise(Point3D p1, Point3D p2, Point3D p3, Vector3D n)
	{
		return _0023_003DzFSl4vWLaTYwafgTfDg_003D_003D(p1, p2, p3, n) < 0.0;
	}

	public static double TriangleArea(Point3D p1, Point3D p2, Point3D p3)
	{
		double num = (p2.Y - p1.Y) * (p3.Z - p1.Z) - (p2.Z - p1.Z) * (p3.Y - p1.Y);
		double num2 = (p2.Z - p1.Z) * (p3.X - p1.X) - (p2.X - p1.X) * (p3.Z - p1.Z);
		double num3 = (p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X);
		return Math.Sqrt(num * num + num2 * num2 + num3 * num3) / 2.0;
	}

	public static LinkedListNode<T> CircularNext<T>(LinkedListNode<T> listNode)
	{
		if (listNode.Next == null)
		{
			return listNode.List.First;
		}
		return listNode.Next;
	}

	public static LinkedListNode<T> CircularPrevious<T>(LinkedListNode<T> listNode)
	{
		if (listNode.Previous == null)
		{
			return listNode.List.Last;
		}
		return listNode.Previous;
	}

	public static double MmToInches(double mm)
	{
		return mm / 25.4;
	}

	public static double InchesToMm(double inches)
	{
		return 25.4 * inches;
	}

	public static bool EvaluateCurvature(Vector3D D1, Vector3D D2, out Vector3D T, out Vector3D K)
	{
		bool result = false;
		double length = D1.Length;
		T = new Vector3D();
		K = new Vector3D();
		if (length == 0.0)
		{
			length = D2.Length;
			if (length > 0.0)
			{
				T = 1.0 / length * D2;
			}
			else
			{
				T.Zero();
			}
			K.Zero();
		}
		else
		{
			T = 1.0 / length * D1;
			D2.Negate();
			double num = D2 * T;
			length = 1.0 / (length * length);
			K = length * (D2 + num * T);
			result = true;
		}
		return result;
	}

	public static void ReverseArray<T>(IList<T> array)
	{
		int count = array.Count;
		for (int i = 0; i < count / 2; i++)
		{
			T value = array[i];
			array[i] = array[count - i - 1];
			array[count - i - 1] = value;
		}
	}

	internal static List<int> _0023_003Dzv1eJ6yKpWyWB(int _0023_003DzF7v9r2A_003D, int _0023_003Dz8dK2uhU_003D, Random _0023_003Dzlraf5vU_003D)
	{
		List<int> list = new List<int>(_0023_003Dz8dK2uhU_003D - _0023_003DzF7v9r2A_003D);
		for (int i = _0023_003DzF7v9r2A_003D; i < _0023_003Dz8dK2uhU_003D; i++)
		{
			int index = _0023_003Dzlraf5vU_003D.Next(0, list.Count);
			list.Insert(index, i);
		}
		return list;
	}

	public static Point2D[] DoublesToPointArray2D(double[] listOfDoubles)
	{
		if (listOfDoubles.Length % 2 != 0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662528), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662494));
		}
		int num = listOfDoubles.Length / 2;
		Point2D[] array = new Point2D[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = new Point2D(listOfDoubles[i * 2], listOfDoubles[i * 2 + 1]);
		}
		return array;
	}

	public static Point3D[] DoublesToPointArray3D(double[] listOfDoubles)
	{
		if (listOfDoubles.Length % 3 != 0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662528), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662471));
		}
		int num = listOfDoubles.Length / 3;
		Point3D[] array = new Point3D[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = new Point3D(listOfDoubles[i * 3], listOfDoubles[i * 3 + 1], listOfDoubles[i * 3 + 2]);
		}
		return array;
	}

	public static Point4D[] DoublesToPointArray4D(double[] listOfDoubles)
	{
		if (listOfDoubles.Length % 3 != 0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662528), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662452));
		}
		int num = listOfDoubles.Length / 3;
		Point4D[] array = new Point4D[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = new Point4D(listOfDoubles[i * 3], listOfDoubles[i * 3 + 1], listOfDoubles[i * 3 + 2]);
		}
		return array;
	}

	public static double[,] Append(double[,] first, double[,] second)
	{
		double[,] array = new double[first.GetLength(0) + second.GetLength(0), first.GetLength(1)];
		Array.Copy(first, array, first.Length);
		Array.Copy(second, 0, array, first.Length, second.Length);
		return array;
	}

	public static int Solve2x2(double m00, double m01, double m10, double m11, double d0, double d1, out double x_addr, out double y_addr, out double pivot_ratio)
	{
		int num = 0;
		double num2 = Math.Abs(m00);
		double num3 = Math.Abs(m01);
		if (num3 > num2)
		{
			num2 = num3;
			num = 1;
		}
		num3 = Math.Abs(m10);
		if (num3 > num2)
		{
			num2 = num3;
			num = 2;
		}
		num3 = Math.Abs(m11);
		if (num3 > num2)
		{
			num2 = num3;
			num = 3;
		}
		pivot_ratio = (x_addr = (y_addr = 0.0));
		if (num2 == 0.0)
		{
			return 0;
		}
		double num5;
		double num4 = (num5 = num2);
		bool flag = false;
		if (num % 2 == 1)
		{
			flag = true;
			num2 = m00;
			m00 = m01;
			m01 = num2;
			num2 = m10;
			m10 = m11;
			m11 = num2;
		}
		if (num > 1)
		{
			num2 = d0;
			d0 = d1;
			d1 = num2;
			num2 = m00;
			m00 = m10;
			m10 = num2;
			num2 = m01;
			m01 = m11;
			m11 = num2;
		}
		num2 = 1.0 / m00;
		m01 *= num2;
		d0 *= num2;
		if (m10 != 0.0)
		{
			m11 -= m10 * m01;
			d1 -= m10 * d0;
		}
		if (m11 == 0.0)
		{
			return 1;
		}
		num3 = Math.Abs(m11);
		if (num3 > num5)
		{
			num5 = num3;
		}
		else if (num3 < num4)
		{
			num4 = num3;
		}
		d1 /= m11;
		if (m01 != 0.0)
		{
			d0 -= m01 * d1;
		}
		if (!flag)
		{
			x_addr = d0;
			y_addr = d1;
		}
		else
		{
			y_addr = d0;
			x_addr = d1;
		}
		pivot_ratio = num4 / num5;
		return 2;
	}

	public static bool AreCollinear(Point2D[] points, double tolerance, out Segment2D line)
	{
		int num = points.Length;
		line = null;
		if (points[0] == points[num - 1] || num < 2)
		{
			return false;
		}
		if (tolerance <= 0.0)
		{
			tolerance = 1E-12;
		}
		double num2 = double.MinValue;
		Segment2D segment2D = null;
		for (int i = 0; i < num - 1; i++)
		{
			Segment2D segment2D2 = new Segment2D(points[i], points[i + 1]);
			double num3 = segment2D2.Length * segment2D2.Length;
			if (num3 > num2)
			{
				segment2D = segment2D2;
				num2 = num3;
			}
		}
		bool flag = false;
		if (segment2D != null)
		{
			if (segment2D.IsPoint)
			{
				return false;
			}
			flag = true;
			foreach (Point2D point2D in points)
			{
				double t = segment2D.Project(point2D);
				if (point2D.DistanceTo(segment2D.PointAt(t)) > tolerance)
				{
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			line = segment2D;
		}
		return flag;
	}

	public static Interval FixRevAngle(double startAngle, double revAngle)
	{
		Interval result = default(Interval);
		if (revAngle > Math.PI * 2.0)
		{
			result.t0 = startAngle;
			result.t1 = startAngle + Math.PI * 2.0;
			return result;
		}
		if (revAngle < Math.PI * -2.0)
		{
			result.t0 = startAngle - Math.PI * 2.0;
			result.t1 = startAngle;
			return result;
		}
		if (revAngle < 0.0)
		{
			result.t0 = startAngle + revAngle;
			result.t1 = startAngle;
			return result;
		}
		result.t0 = startAngle;
		result.t1 = startAngle + revAngle;
		return result;
	}

	public static void FixEndAngle(double startAngle, ref double endAngle)
	{
		if (endAngle < startAngle || Math.Abs(endAngle - startAngle) < 1E-12)
		{
			endAngle += Math.PI * 2.0;
		}
	}

	public static bool InvertMatrixd(double[] m, double[] invOut)
	{
		double[] array = new double[16];
		array[0] = m[5] * m[10] * m[15] - m[5] * m[11] * m[14] - m[9] * m[6] * m[15] + m[9] * m[7] * m[14] + m[13] * m[6] * m[11] - m[13] * m[7] * m[10];
		array[4] = (0.0 - m[4]) * m[10] * m[15] + m[4] * m[11] * m[14] + m[8] * m[6] * m[15] - m[8] * m[7] * m[14] - m[12] * m[6] * m[11] + m[12] * m[7] * m[10];
		array[8] = m[4] * m[9] * m[15] - m[4] * m[11] * m[13] - m[8] * m[5] * m[15] + m[8] * m[7] * m[13] + m[12] * m[5] * m[11] - m[12] * m[7] * m[9];
		array[12] = (0.0 - m[4]) * m[9] * m[14] + m[4] * m[10] * m[13] + m[8] * m[5] * m[14] - m[8] * m[6] * m[13] - m[12] * m[5] * m[10] + m[12] * m[6] * m[9];
		array[1] = (0.0 - m[1]) * m[10] * m[15] + m[1] * m[11] * m[14] + m[9] * m[2] * m[15] - m[9] * m[3] * m[14] - m[13] * m[2] * m[11] + m[13] * m[3] * m[10];
		array[5] = m[0] * m[10] * m[15] - m[0] * m[11] * m[14] - m[8] * m[2] * m[15] + m[8] * m[3] * m[14] + m[12] * m[2] * m[11] - m[12] * m[3] * m[10];
		array[9] = (0.0 - m[0]) * m[9] * m[15] + m[0] * m[11] * m[13] + m[8] * m[1] * m[15] - m[8] * m[3] * m[13] - m[12] * m[1] * m[11] + m[12] * m[3] * m[9];
		array[13] = m[0] * m[9] * m[14] - m[0] * m[10] * m[13] - m[8] * m[1] * m[14] + m[8] * m[2] * m[13] + m[12] * m[1] * m[10] - m[12] * m[2] * m[9];
		array[2] = m[1] * m[6] * m[15] - m[1] * m[7] * m[14] - m[5] * m[2] * m[15] + m[5] * m[3] * m[14] + m[13] * m[2] * m[7] - m[13] * m[3] * m[6];
		array[6] = (0.0 - m[0]) * m[6] * m[15] + m[0] * m[7] * m[14] + m[4] * m[2] * m[15] - m[4] * m[3] * m[14] - m[12] * m[2] * m[7] + m[12] * m[3] * m[6];
		array[10] = m[0] * m[5] * m[15] - m[0] * m[7] * m[13] - m[4] * m[1] * m[15] + m[4] * m[3] * m[13] + m[12] * m[1] * m[7] - m[12] * m[3] * m[5];
		array[14] = (0.0 - m[0]) * m[5] * m[14] + m[0] * m[6] * m[13] + m[4] * m[1] * m[14] - m[4] * m[2] * m[13] - m[12] * m[1] * m[6] + m[12] * m[2] * m[5];
		array[3] = (0.0 - m[1]) * m[6] * m[11] + m[1] * m[7] * m[10] + m[5] * m[2] * m[11] - m[5] * m[3] * m[10] - m[9] * m[2] * m[7] + m[9] * m[3] * m[6];
		array[7] = m[0] * m[6] * m[11] - m[0] * m[7] * m[10] - m[4] * m[2] * m[11] + m[4] * m[3] * m[10] + m[8] * m[2] * m[7] - m[8] * m[3] * m[6];
		array[11] = (0.0 - m[0]) * m[5] * m[11] + m[0] * m[7] * m[9] + m[4] * m[1] * m[11] - m[4] * m[3] * m[9] - m[8] * m[1] * m[7] + m[8] * m[3] * m[5];
		array[15] = m[0] * m[5] * m[10] - m[0] * m[6] * m[9] - m[4] * m[1] * m[10] + m[4] * m[2] * m[9] + m[8] * m[1] * m[6] - m[8] * m[2] * m[5];
		double num = m[0] * array[0] + m[1] * array[4] + m[2] * array[8] + m[3] * array[12];
		if (num == 0.0)
		{
			return false;
		}
		num = 1.0 / num;
		for (int i = 0; i < 16; i++)
		{
			invOut[i] = array[i] * num;
		}
		return true;
	}

	public static bool IsValidMatrix(double[] matrix)
	{
		if (matrix == null)
		{
			return false;
		}
		int num = 0;
		for (int i = 0; i < 16; i++)
		{
			if (Math.Abs(matrix[i]) - _0023_003DzheSR8QM7q9ya < 0.0)
			{
				num++;
			}
		}
		return num != 16;
	}

	public static Point3D[] GetPointsOnPlane(Plane sketchPlane, IList<Point2D> contour)
	{
		Point3D[] array = new Point3D[contour.Count];
		for (int i = 0; i < contour.Count; i++)
		{
			array[i] = sketchPlane.PointAt(contour[i].X, contour[i].Y);
		}
		return array;
	}

	public static Plane GetTrianglesPlane(IList<IndexTriangle> triangles, IList<Point3D> vertices)
	{
		Plane _0023_003Dzrgqz890sj_0024X = null;
		for (int i = 0; i < triangles.Count; i++)
		{
			IndexTriangle indexTriangle = triangles[i];
			if (_0023_003DzNY5YUv279_SW(vertices[indexTriangle.V1], vertices[indexTriangle.V2], vertices[indexTriangle.V3], out _0023_003Dzrgqz890sj_0024X))
			{
				break;
			}
		}
		return _0023_003Dzrgqz890sj_0024X;
	}

	public static double PolygonArea<T>(IList<T> polygon) where T : Point2D
	{
		double num = 0.0;
		int count = polygon.Count;
		for (int i = 0; i < count; i++)
		{
			int index = (i + 1) % count;
			num += polygon[i].X * polygon[index].Y;
			num -= polygon[i].Y * polygon[index].X;
		}
		return num / 2.0;
	}

	public static double PolygonArea(double[,] polygon)
	{
		double num = 0.0;
		int num2 = polygon.Length / 2;
		for (int i = 0; i < num2; i++)
		{
			int num3 = (i + 1) % num2;
			num += polygon[i, 0] * polygon[num3, 1];
			num -= polygon[i, 1] * polygon[num3, 0];
		}
		return num / 2.0;
	}

	public static double PolygonArea(Vector3D normal, IList<Point3D> points)
	{
		double num = 0.0;
		for (int i = 1; i < points.Count - 2; i++)
		{
			num += TriangleSignedArea(points[0], points[i], points[i + 1], normal);
		}
		return num / 2.0;
	}

	public static int NumberOfSegments(double radius, double deltaInRadians, double deviation, double angle = Math.PI / 4.0)
	{
		int num;
		if (Compare(deltaInRadians, Math.PI * 2.0) == 0)
		{
			deltaInRadians = Math.PI / 2.0;
			num = _0023_003DztKN5MJdRSXeW(radius, deltaInRadians, deviation, out var _0023_003DzZggemaAZhxrF);
			if (angle > 0.0 && Compare(_0023_003DzZggemaAZhxrF, angle) != 0 && _0023_003DzZggemaAZhxrF > angle)
			{
				num = (int)Math.Ceiling(Math.PI / 2.0 / angle);
			}
			num *= 4;
		}
		else if (Compare(deltaInRadians, Math.PI) == 0)
		{
			deltaInRadians = Math.PI / 2.0;
			num = _0023_003DztKN5MJdRSXeW(radius, deltaInRadians, deviation, out var _0023_003DzZggemaAZhxrF2);
			if (angle > 0.0 && Compare(_0023_003DzZggemaAZhxrF2, angle) != 0 && _0023_003DzZggemaAZhxrF2 > angle)
			{
				num = (int)Math.Ceiling(Math.PI / 2.0 / angle);
			}
			num *= 2;
		}
		else
		{
			num = _0023_003DztKN5MJdRSXeW(radius, deltaInRadians, deviation, out var _0023_003DzZggemaAZhxrF3);
			if (angle > 0.0 && Compare(_0023_003DzZggemaAZhxrF3, angle) != 0 && _0023_003DzZggemaAZhxrF3 > angle)
			{
				num = (int)Math.Ceiling(deltaInRadians / angle);
			}
		}
		return num;
	}

	public static int NumberOfSegmentsByLength(double radius, double deltaInRadians, double length)
	{
		int num = (int)Math.Ceiling(radius * deltaInRadians / length);
		if (num < 1)
		{
			num = 1;
		}
		return num;
	}

	private static int _0023_003DztKN5MJdRSXeW(double _0023_003DzEGKj_0024SNUUihi, double _0023_003DzjP8trwISmVYKg2M0bA_003D_003D, double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, out double _0023_003DzZggemaAZhxrF)
	{
		int num = (int)Math.Ceiling(Math.Abs(_0023_003DzjP8trwISmVYKg2M0bA_003D_003D) / (2.0 * Math.Acos((_0023_003DzEGKj_0024SNUUihi - _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D) / _0023_003DzEGKj_0024SNUUihi)));
		if (num < 2 || num == int.MaxValue)
		{
			num = 2;
		}
		_0023_003DzZggemaAZhxrF = _0023_003DzjP8trwISmVYKg2M0bA_003D_003D / (double)num;
		return num;
	}

	public static void Swap<T>(ref T first, ref T second)
	{
		T val = first;
		first = second;
		second = val;
	}

	public static void GetBoundingBoxTransformed(Transformation transform, Point3D min, Point3D max, out Point3D boxMin, out Point3D boxMax)
	{
		Point3D[] boundingBoxCorners = GetBoundingBoxCorners(min, max);
		boxMin = Point3D.MaxValue;
		boxMax = Point3D.MinValue;
		UpdateMinMax(transform, boundingBoxCorners, boundingBoxCorners.Length, boxMin, boxMax);
	}

	public static Point3D[] GetBoundingBoxCorners(Point3D min, Point3D max)
	{
		return new Point3D[8]
		{
			new Point3D(min.X, min.Y, min.Z),
			new Point3D(max.X, min.Y, min.Z),
			new Point3D(max.X, max.Y, min.Z),
			new Point3D(min.X, max.Y, min.Z),
			new Point3D(min.X, min.Y, max.Z),
			new Point3D(max.X, min.Y, max.Z),
			new Point3D(max.X, max.Y, max.Z),
			new Point3D(min.X, max.Y, max.Z)
		};
	}

	public static double VectorsAngle(Vector3D v1, Vector3D v2, Plane plane)
	{
		plane.Project(v1.AsPoint, out var s, out var t);
		plane.Project(v2.AsPoint, out var s2, out var t2);
		Point2D pt = new Point2D(s, t);
		Point2D pt2 = new Point2D(s2, t2);
		Point3D point3D = plane.PointAt(pt);
		Point3D point3D2 = plane.PointAt(pt2);
		Vector3D asVector = point3D.AsVector;
		Vector3D asVector2 = point3D2.AsVector;
		asVector.Normalize();
		asVector2.Normalize();
		double num = Vector3D.Dot(asVector, asVector2);
		Vector3D u = Vector3D.Cross(v1, v2);
		Vector3D v3 = new Vector3D(plane.Equation.ToArray());
		int num2 = -Math.Sign(Vector3D.Dot(u, v3));
		if (num > 1.0)
		{
			num = 1.0;
		}
		else if (num < -1.0)
		{
			num = -1.0;
		}
		return (double)num2 * RadToDeg(Math.Acos(num));
	}

	public static double VectorsAngle(Vector3D v1, Vector3D v2, Vector3D rotAxis)
	{
		Plane plane = new Plane(new double[4] { rotAxis.X, rotAxis.Y, rotAxis.Z, 0.0 });
		return VectorsAngle(v1, v2, plane);
	}

	public static bool IsInFrustum(PlaneEquation[] frustum, Point3D center, double radius)
	{
		double x = center.X;
		double y = center.Y;
		double z = center.Z;
		for (int i = 0; i < 6; i++)
		{
			if (frustum[i].ValueAt(x, y, z) < 0.0 - radius)
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsInFrustum(PlaneEquation[] frustum, Point3D center, double radius, out bool intersect)
	{
		intersect = false;
		for (int i = 0; i < frustum.Length; i++)
		{
			double num = frustum[i].ValueAt(center);
			if (num < 0.0 - radius)
			{
				return false;
			}
			if (!intersect && num < radius)
			{
				intersect = true;
			}
		}
		return true;
	}

	public static bool IsInFrustum(PlaneEquation[] frustum, Point3D min, Point3D max)
	{
		Point3D point3D = new Point3D();
		for (int i = 0; i < 6; i++)
		{
			point3D.X = ((frustum[i].X >= 0.0) ? max.X : min.X);
			point3D.Y = ((frustum[i].Y >= 0.0) ? max.Y : min.Y);
			point3D.Z = ((frustum[i].Z >= 0.0) ? max.Z : min.Z);
			if (frustum[i].ValueAt(point3D) < 0.0)
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsPointOnSegment(Point2D testPoint, Point2D P0, Point2D P1, double domainDiag)
	{
		double num = domainDiag * _0023_003DzxhnLabVjXjPg;
		return _0023_003DzedEHTyqioyyN(testPoint._0023_003DzwY26hvo2cSE0(), P0._0023_003DzwY26hvo2cSE0(), P1._0023_003DzwY26hvo2cSE0(), num * num);
	}

	internal static bool _0023_003DzedEHTyqioyyN(_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzB68dg9Q_003D, _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzjbqS1qE_003D, _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz1v6oPQk_003D, double _0023_003DzT2I49JGvQcku)
	{
		_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzjbqS1qE_003D2 = _0023_003DzB68dg9Q_003D - _0023_003DzjbqS1qE_003D;
		_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz1v6oPQk_003D2 = _0023_003Dz1v6oPQk_003D - _0023_003DzjbqS1qE_003D;
		return (_0023_003DzjbqS1qE_003D2 - _0023_003Dz1v6oPQk_003D2 * ILSpyHelper_AsRefReadOnly(Clamp(_0023_003DzjbqS1qE_003D2 * _0023_003Dz1v6oPQk_003D2 / (_0023_003Dz1v6oPQk_003D2 * _0023_003Dz1v6oPQk_003D2), 0.0, 1.0)))._0023_003DzEi_F9g8kJ9d2() <= _0023_003DzT2I49JGvQcku;
		static ref readonly T ILSpyHelper_AsRefReadOnly<T>(in T temp)
		{
			//ILSpy generated this function to help ensure overload resolution can pick the overload using 'in'
			return ref temp;
		}
	}

	public static int[,] GetEdgesWithoutDuplicates(IList<IndexTriangle> polygons, int numVerts)
	{
		LinkedList<SharedEdge>[] edgesPerVertex;
		int edgesWithoutDuplicates = GetEdgesWithoutDuplicates(polygons, numVerts, out edgesPerVertex);
		return GetUniqueEdges(edgesPerVertex, edgesWithoutDuplicates);
	}

	public static int[,] GetEdgesWithoutDuplicates(int[] trianglesArray, int numVerts)
	{
		LinkedList<SharedEdge>[] edgesPerVertex;
		int edgesWithoutDuplicates = GetEdgesWithoutDuplicates(trianglesArray, numVerts, out edgesPerVertex);
		return GetUniqueEdges(edgesPerVertex, edgesWithoutDuplicates);
	}

	public static int GetEdgesWithoutDuplicates(IList<IndexTriangle> polygons, int numVerts, out LinkedList<SharedEdge>[] edgesPerVertex)
	{
		_0023_003DzXnXM_0024QLsvz6s(numVerts, out edgesPerVertex);
		int _0023_003DzG_0024VZaZrYvQv = 0;
		int[] array = new int[3];
		for (int i = 0; i < polygons.Count; i++)
		{
			array[0] = polygons[i].V1;
			array[1] = polygons[i].V2;
			array[2] = polygons[i].V3;
			_0023_003Dz0VphV_WmfeEu(3, edgesPerVertex, i, array, ref _0023_003DzG_0024VZaZrYvQv);
		}
		return _0023_003DzG_0024VZaZrYvQv;
	}

	public static int GetEdgesWithoutDuplicates(int[] trianglesArray, int numVerts, out LinkedList<SharedEdge>[] edgesPerVertex)
	{
		_0023_003DzXnXM_0024QLsvz6s(numVerts, out edgesPerVertex);
		int _0023_003DzG_0024VZaZrYvQv = 0;
		int[] array = new int[3];
		int num = 0;
		int num2 = 0;
		while (num2 < trianglesArray.Length)
		{
			array[0] = trianglesArray[num2];
			array[1] = trianglesArray[num2 + 1];
			array[2] = trianglesArray[num2 + 2];
			_0023_003Dz0VphV_WmfeEu(3, edgesPerVertex, num, array, ref _0023_003DzG_0024VZaZrYvQv);
			num2 += 3;
			num++;
		}
		return _0023_003DzG_0024VZaZrYvQv;
	}

	private static void _0023_003DzXnXM_0024QLsvz6s<SharedEdge>(int _0023_003Dz4Y21uI8f2Kzk, out LinkedList<SharedEdge>[] _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D)
	{
		_0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D = new LinkedList<SharedEdge>[_0023_003Dz4Y21uI8f2Kzk];
		for (int i = 0; i < _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D.Length; i++)
		{
			_0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D[i] = new LinkedList<SharedEdge>();
		}
	}

	private static void _0023_003Dz0VphV_WmfeEu(int _0023_003Dz_C5M_0024TZrmoaK, LinkedList<SharedEdge>[] _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, int _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D, int[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, ref int _0023_003DzG_0024VZaZrYvQv9)
	{
		for (int i = 0; i < _0023_003Dz_C5M_0024TZrmoaK; i++)
		{
			int _0023_003Dz3meCwcU_003D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i];
			int _0023_003DzOZnLD38_003D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[(i + 1) % _0023_003Dz_C5M_0024TZrmoaK];
			_0023_003DziD_qqx49KKTN(_0023_003Dz3meCwcU_003D, _0023_003DzOZnLD38_003D, _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D, ref _0023_003DzG_0024VZaZrYvQv9);
		}
	}

	private static void _0023_003DziD_qqx49KKTN(int _0023_003Dz3meCwcU_003D, int _0023_003DzOZnLD38_003D, LinkedList<SharedEdge>[] _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, int _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D, ref int _0023_003DzG_0024VZaZrYvQv9)
	{
		if (_0023_003Dz3meCwcU_003D > _0023_003DzOZnLD38_003D)
		{
			int num = _0023_003Dz3meCwcU_003D;
			_0023_003Dz3meCwcU_003D = _0023_003DzOZnLD38_003D;
			_0023_003DzOZnLD38_003D = num;
		}
		LinkedList<SharedEdge> linkedList = _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D[_0023_003Dz3meCwcU_003D];
		LinkedListNode<SharedEdge> linkedListNode = linkedList.First;
		while (linkedListNode != null && linkedListNode.Value.V2 != _0023_003DzOZnLD38_003D)
		{
			linkedListNode = linkedListNode.Next;
		}
		if (linkedListNode == null)
		{
			SharedEdge sharedEdge = new SharedEdge();
			sharedEdge.V2 = _0023_003DzOZnLD38_003D;
			sharedEdge.Mum = _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D;
			sharedEdge.Dad = -1;
			linkedList.AddLast(sharedEdge);
			_0023_003DzG_0024VZaZrYvQv9++;
		}
		else
		{
			linkedListNode.Value.Dad = _0023_003DzSMMqa1rrC8lJXjvQoQ_003D_003D;
		}
	}

	public static int[,] GetEdgesWithoutDuplicates(int[][] polygons, int numVerts, out LinkedList<SharedEdge>[] edgesPerVertex)
	{
		_0023_003DzXnXM_0024QLsvz6s(numVerts, out edgesPerVertex);
		int _0023_003DzG_0024VZaZrYvQv = 0;
		int length = polygons.GetLength(0);
		for (int i = 0; i < length; i++)
		{
			_0023_003Dz0VphV_WmfeEu(polygons[i].Length, edgesPerVertex, i, polygons[i], ref _0023_003DzG_0024VZaZrYvQv);
		}
		return GetUniqueEdges(edgesPerVertex, _0023_003DzG_0024VZaZrYvQv);
	}

	[CLSCompliant(false)]
	public static int[,] GetEdgesWithoutDuplicates(int[,] polygons, int numVerts)
	{
		LinkedList<SharedEdge>[] edgesPerVertex;
		return GetEdgesWithoutDuplicates(polygons, numVerts, out edgesPerVertex);
	}

	[CLSCompliant(false)]
	public static int[,] GetEdgesWithoutDuplicates(int[,] polygons, int numVerts, out LinkedList<SharedEdge>[] edgesPerVertex)
	{
		int outNumEdges = _0023_003DzDRs27HCuyKrlcTjdbQ_003D_003D(polygons, numVerts, out edgesPerVertex);
		return GetUniqueEdges(edgesPerVertex, outNumEdges);
	}

	internal static int[,] _0023_003Dz36sbfVCTXh1L(_0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom[] _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D, int _0023_003Dz4Y21uI8f2Kzk, out LinkedList<SharedEdge>[] _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, bool _0023_003DzZgSQ1WpOFIne)
	{
		int outNumEdges = _0023_003DzDRs27HCuyKrlcTjdbQ_003D_003D(_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D, _0023_003Dz4Y21uI8f2Kzk, _0023_003DzZgSQ1WpOFIne, out _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D);
		return GetUniqueEdges(_0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, outNumEdges);
	}

	private static int _0023_003DzDRs27HCuyKrlcTjdbQ_003D_003D(int[,] _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D, int _0023_003Dz4Y21uI8f2Kzk, out LinkedList<SharedEdge>[] _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D)
	{
		_0023_003DzXnXM_0024QLsvz6s(_0023_003Dz4Y21uI8f2Kzk, out _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D);
		int _0023_003DzG_0024VZaZrYvQv = 0;
		int length = _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D.GetLength(0);
		int length2 = _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				int _0023_003Dz3meCwcU_003D = _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D[i, j];
				int _0023_003DzOZnLD38_003D = _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D[i, (j + 1) % length2];
				_0023_003DziD_qqx49KKTN(_0023_003Dz3meCwcU_003D, _0023_003DzOZnLD38_003D, _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, i, ref _0023_003DzG_0024VZaZrYvQv);
			}
		}
		return _0023_003DzG_0024VZaZrYvQv;
	}

	private static int _0023_003DzDRs27HCuyKrlcTjdbQ_003D_003D(_0023_003Dz2npo5EJUR23zTb_0024_4OC_0024n7fXOqom[] _0023_003DzD_4yRKeiIPD1, int _0023_003Dz4Y21uI8f2Kzk, bool _0023_003DzZgSQ1WpOFIne, out LinkedList<SharedEdge>[] _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D)
	{
		_0023_003DzXnXM_0024QLsvz6s(_0023_003Dz4Y21uI8f2Kzk, out _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D);
		int _0023_003DzG_0024VZaZrYvQv = 0;
		int num = _0023_003DzD_4yRKeiIPD1.Length;
		for (int i = 0; i < num; i++)
		{
			int[][] _0023_003DzhMDfC7g_003D = _0023_003DzD_4yRKeiIPD1[i]._0023_003DzhMDfC7g_003D;
			foreach (int[] array in _0023_003DzhMDfC7g_003D)
			{
				for (int k = 0; k < array.Length - 1; k++)
				{
					_0023_003DziD_qqx49KKTN(array[k], array[k + 1], _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, i, ref _0023_003DzG_0024VZaZrYvQv);
				}
				_0023_003DziD_qqx49KKTN(array.Last(), array.First(), _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D, i, ref _0023_003DzG_0024VZaZrYvQv);
			}
		}
		if (_0023_003DzZgSQ1WpOFIne)
		{
			for (int l = 0; l < _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D.Length; l++)
			{
				LinkedListNode<SharedEdge> linkedListNode = _0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D[l].First;
				while (linkedListNode != null)
				{
					LinkedListNode<SharedEdge> next = linkedListNode.Next;
					if (linkedListNode.Value.Dad == -1)
					{
						_0023_003Dz1RCn3qFPirtRPdfJLw_003D_003D[l].Remove(linkedListNode);
						_0023_003DzG_0024VZaZrYvQv--;
					}
					linkedListNode = next;
				}
			}
		}
		return _0023_003DzG_0024VZaZrYvQv;
	}

	public static int[,] GetUniqueEdges(LinkedList<SharedEdge>[] edgesPerVertex, int outNumEdges)
	{
		int[,] array = new int[outNumEdges, 4];
		int num = 0;
		for (int i = 0; i < edgesPerVertex.Length; i++)
		{
			foreach (SharedEdge item in edgesPerVertex[i])
			{
				array[num, 0] = i;
				array[num, 1] = item.V2;
				array[num, 2] = item.Mum;
				array[num, 3] = item.Dad;
				num++;
			}
		}
		return array;
	}

	public static int[][] GetSkinFaces(int[][] faces, int numVerts, out LinkedList<SharedFace>[] facesPerVertex)
	{
		int num = faces.Length;
		facesPerVertex = new LinkedList<SharedFace>[numVerts];
		for (int i = 0; i < facesPerVertex.Length; i++)
		{
			facesPerVertex[i] = new LinkedList<SharedFace>();
		}
		int num2 = 0;
		SharedFace value = default(SharedFace);
		for (int j = 0; j < num; j++)
		{
			int num3 = faces[j].Length - 2;
			int num4 = faces[j][0];
			int num5 = faces[j][1];
			int num6 = faces[j][2];
			int num7 = 0;
			int[] array;
			if (num3 > 3)
			{
				num7 = faces[j][3];
				array = new int[4] { num4, num5, num6, num7 };
			}
			else
			{
				array = new int[3] { num4, num5, num6 };
			}
			Array.Sort(array);
			num4 = array[0];
			num5 = array[1];
			num6 = array[2];
			if (num3 > 3)
			{
				num7 = array[3];
			}
			LinkedList<SharedFace> linkedList = facesPerVertex[num4];
			LinkedListNode<SharedFace> linkedListNode = linkedList.First;
			if (num3 > 3)
			{
				while (linkedListNode != null && (linkedListNode.Value.V2 != num5 || linkedListNode.Value.V3 != num6 || linkedListNode.Value.V4 != num7))
				{
					linkedListNode = linkedListNode.Next;
				}
			}
			else
			{
				while (linkedListNode != null && (linkedListNode.Value.V2 != num5 || linkedListNode.Value.V3 != num6))
				{
					linkedListNode = linkedListNode.Next;
				}
			}
			if (linkedListNode == null)
			{
				value.V2 = num5;
				value.V3 = num6;
				if (num3 > 3)
				{
					value.V4 = num7;
				}
				value.Mum = j;
				value.Dad = -1;
				linkedList.AddLast(value);
				num2++;
			}
			else
			{
				value = linkedListNode.Value;
				value.Dad = j;
				linkedListNode.Value = value;
			}
		}
		List<int[]> list = new List<int[]>(num2);
		for (int k = 0; k < facesPerVertex.Length; k++)
		{
			foreach (SharedFace item2 in facesPerVertex[k])
			{
				if (item2.Dad == -1)
				{
					int[] item = faces[item2.Mum];
					list.Add(item);
				}
			}
		}
		return list.ToArray();
	}

	public static SharedEdge RemoveEdge(int v1, int v2, LinkedList<SharedEdge>[] edgesPerVertex)
	{
		LinkedList<SharedEdge> linkedList = edgesPerVertex[v1];
		LinkedListNode<SharedEdge> linkedListNode = linkedList.First;
		while (linkedListNode != null && linkedListNode.Value.V2 != v2)
		{
			linkedListNode = linkedListNode.Next;
		}
		linkedList.Remove(linkedListNode);
		return linkedListNode.Value;
	}

	public static SharedEdge GetEdge(int v1, int v2, IList<LinkedList<SharedEdge>> edgesPerVertex)
	{
		LinkedListNode<SharedEdge> linkedListNode = edgesPerVertex[v1].First;
		while (linkedListNode != null && linkedListNode.Value.V2 != v2)
		{
			linkedListNode = linkedListNode.Next;
		}
		return linkedListNode.Value;
	}

	public static bool TriangleTriangleIntersection(Point3D p1, Point3D q1, Point3D r1, Point3D p2, Point3D q2, Point3D r2, out bool touch)
	{
		return TriangleTriangleIntersection(p1.ToArray(), q1.ToArray(), r1.ToArray(), p2.ToArray(), q2.ToArray(), r2.ToArray(), out touch);
	}

	public static bool TriangleTriangleIntersection(double[] p1, double[] q1, double[] r1, double[] p2, double[] q2, double[] r2, out bool touch)
	{
		return _0023_003Dzk9GdjoLUR9NyLgI9HMT_00245GSaFm_Z._0023_003Dz2zyAKL7fLMG6kHdl7nWvKhOwpDDm_qQC4A_003D_003D(p1, q1, r1, p2, q2, r2, out touch) != 0;
	}

	public static bool TriangleTriangleIntersection2D(Point2D p1, Point2D q1, Point2D r1, Point2D p2, Point2D q2, Point2D r2)
	{
		return TriangleTriangleIntersection2D(p1.ToArray(), q1.ToArray(), r1.ToArray(), p2.ToArray(), q2.ToArray(), r2.ToArray());
	}

	public static bool TriangleTriangleIntersection2D(double[] p1, double[] q1, double[] r1, double[] p2, double[] q2, double[] r2)
	{
		return _0023_003Dzk9GdjoLUR9NyLgI9HMT_00245GSaFm_Z._0023_003DzpXXk8tq7xSyebLEBb9MlKYasHVp4EWxuXg_003D_003D(p1, q1, r1, p2, q2, r2) != 0;
	}

	private static int _0023_003DzOylzlsxYda1_0024k_0024OjBw_003D_003D(ref Point3D _0023_003DzjdeMMkk_003D, ref Point3D _0023_003DzYENOV_Q_003D, ref Point3D _0023_003DzKjjcAoU_003D, ref Point3D _0023_003DzFj_0024IqDQ_003D, ref Point3D _0023_003Dz7ZE84gQ_003D, ref Point3D _0023_003Dzkzf4gQ0_003D)
	{
		Vector3D vector3D = Vector3D.Cross(_0023_003DzYENOV_Q_003D - _0023_003DzjdeMMkk_003D, _0023_003DzKjjcAoU_003D - _0023_003DzjdeMMkk_003D);
		double num = (_0023_003DzFj_0024IqDQ_003D.X - _0023_003DzjdeMMkk_003D.X) * vector3D.X + (_0023_003DzFj_0024IqDQ_003D.Y - _0023_003DzjdeMMkk_003D.Y) * vector3D.Y + (_0023_003DzFj_0024IqDQ_003D.Z - _0023_003DzjdeMMkk_003D.Z) * vector3D.Z;
		double num2 = (_0023_003Dz7ZE84gQ_003D.X - _0023_003DzjdeMMkk_003D.X) * vector3D.X + (_0023_003Dz7ZE84gQ_003D.Y - _0023_003DzjdeMMkk_003D.Y) * vector3D.Y + (_0023_003Dz7ZE84gQ_003D.Z - _0023_003DzjdeMMkk_003D.Z) * vector3D.Z;
		double num3 = (_0023_003Dzkzf4gQ0_003D.X - _0023_003DzjdeMMkk_003D.X) * vector3D.X + (_0023_003Dzkzf4gQ0_003D.Y - _0023_003DzjdeMMkk_003D.Y) * vector3D.Y + (_0023_003Dzkzf4gQ0_003D.Z - _0023_003DzjdeMMkk_003D.Z) * vector3D.Z;
		bool flag = num == 0.0;
		bool flag2 = num2 == 0.0;
		bool flag3 = num3 == 0.0;
		bool flag4 = Math.Sign(num) == Math.Sign(num2);
		bool flag5 = Math.Sign(num) == Math.Sign(num3);
		if (flag && flag2 && flag3)
		{
			return 0;
		}
		if (flag3)
		{
			if (flag2)
			{
				_0023_003Dz7ZE84gQ_003D += (_0023_003Dz7ZE84gQ_003D - _0023_003DzFj_0024IqDQ_003D) * 0.1;
				_0023_003Dzkzf4gQ0_003D += (_0023_003Dzkzf4gQ0_003D - _0023_003DzFj_0024IqDQ_003D) * 0.1;
				return 2;
			}
			if (flag)
			{
				_0023_003DzFj_0024IqDQ_003D += (_0023_003DzFj_0024IqDQ_003D - _0023_003Dz7ZE84gQ_003D) * 0.1;
				_0023_003Dzkzf4gQ0_003D += (_0023_003Dzkzf4gQ0_003D - _0023_003Dz7ZE84gQ_003D) * 0.1;
				Point3D point3D = _0023_003Dz7ZE84gQ_003D;
				_0023_003Dz7ZE84gQ_003D = _0023_003Dzkzf4gQ0_003D;
				_0023_003Dzkzf4gQ0_003D = _0023_003DzFj_0024IqDQ_003D;
				_0023_003DzFj_0024IqDQ_003D = point3D;
				return 2;
			}
			if (flag4)
			{
				_0023_003Dzkzf4gQ0_003D += (_0023_003Dzkzf4gQ0_003D - _0023_003DzFj_0024IqDQ_003D) * 0.1;
				Point3D point3D2 = _0023_003Dzkzf4gQ0_003D;
				_0023_003Dzkzf4gQ0_003D = _0023_003Dz7ZE84gQ_003D;
				_0023_003Dz7ZE84gQ_003D = _0023_003DzFj_0024IqDQ_003D;
				_0023_003DzFj_0024IqDQ_003D = point3D2;
				return 2;
			}
		}
		else if (flag2)
		{
			if (flag)
			{
				_0023_003DzFj_0024IqDQ_003D += (_0023_003DzFj_0024IqDQ_003D - _0023_003Dzkzf4gQ0_003D) * 0.1;
				_0023_003Dz7ZE84gQ_003D += (_0023_003Dz7ZE84gQ_003D - _0023_003Dzkzf4gQ0_003D) * 0.1;
				Point3D point3D3 = _0023_003Dzkzf4gQ0_003D;
				_0023_003Dzkzf4gQ0_003D = _0023_003Dz7ZE84gQ_003D;
				_0023_003Dz7ZE84gQ_003D = _0023_003DzFj_0024IqDQ_003D;
				_0023_003DzFj_0024IqDQ_003D = point3D3;
				return 2;
			}
			if (flag5)
			{
				_0023_003Dz7ZE84gQ_003D += (_0023_003Dz7ZE84gQ_003D - _0023_003Dzkzf4gQ0_003D) * 0.1;
				Point3D point3D4 = _0023_003Dz7ZE84gQ_003D;
				_0023_003Dz7ZE84gQ_003D = _0023_003Dzkzf4gQ0_003D;
				_0023_003Dzkzf4gQ0_003D = _0023_003DzFj_0024IqDQ_003D;
				_0023_003DzFj_0024IqDQ_003D = point3D4;
				return 2;
			}
		}
		if (flag && Math.Sign(num2) == Math.Sign(num3))
		{
			_0023_003DzFj_0024IqDQ_003D += (_0023_003DzFj_0024IqDQ_003D - _0023_003Dzkzf4gQ0_003D) * 0.1;
			return 2;
		}
		if (flag4 && flag5)
		{
			return -1;
		}
		if (flag4)
		{
			Point3D point3D5 = _0023_003Dzkzf4gQ0_003D;
			_0023_003Dzkzf4gQ0_003D = _0023_003Dz7ZE84gQ_003D;
			_0023_003Dz7ZE84gQ_003D = _0023_003DzFj_0024IqDQ_003D;
			_0023_003DzFj_0024IqDQ_003D = point3D5;
		}
		if (flag5)
		{
			Point3D point3D6 = _0023_003Dz7ZE84gQ_003D;
			_0023_003Dz7ZE84gQ_003D = _0023_003Dzkzf4gQ0_003D;
			_0023_003Dzkzf4gQ0_003D = _0023_003DzFj_0024IqDQ_003D;
			_0023_003DzFj_0024IqDQ_003D = point3D6;
		}
		return 1;
	}

	public static bool TriangleTriangleIntersectionNO(Point3D p0A, Point3D p1A, Point3D p2A, Point3D p0B, Point3D p1B, Point3D p2B)
	{
		Vector3D vector3D = new Vector3D(p0B, p1B);
		Vector3D vector3D2 = new Vector3D(p0B, p2B);
		Vector3D vector3D3 = new Vector3D(p0A, p1A);
		Vector3D vector3D4 = new Vector3D(p0A, p2A);
		Vector3D _0023_003DzYENOV_Q_003D = vector3D4 - vector3D3;
		Vector3D vector3D5 = new Vector3D(p0B, p0A);
		Vector3D vector3D6 = new Vector3D(p0B, p0A);
		_ = vector3D5 + vector3D3;
		double x = vector3D.X;
		double x2 = vector3D2.X;
		double y = vector3D.Y;
		double y2 = vector3D2.Y;
		double z = vector3D.Z;
		double z2 = vector3D2.Z;
		double num = x * y2 - x2 * y;
		double num2 = x * z2 - x2 * z;
		double num3 = y * z2 - y2 * z;
		double num4 = vector3D3.X * num - vector3D3.Y * num2 - vector3D3.Z * num3;
		double num5 = vector3D4.X * num - vector3D4.Y * num2 - vector3D4.Z * num3;
		double num6 = num5 - num4;
		double num7 = vector3D5.X * num - vector3D5.Y * num2 - vector3D5.Z * num3;
		double num8 = vector3D6.X * num - vector3D6.Y * num2 - vector3D6.Z * num3;
		double num9 = num7 + num4;
		_ = (0.0 - num4) / num7;
		_ = (0.0 - num5) / num8;
		_ = (0.0 - num6) / num9;
		double num10 = (0.0 - num7) / num4;
		double num11 = (0.0 - num8) / num5;
		double num12 = (0.0 - num9) / num6;
		bool flag = num10 >= 0.0 && num10 <= 1.0;
		bool flag2 = num11 >= 0.0 && num11 <= 1.0;
		bool flag3 = num12 >= 0.0 && num12 <= 1.0;
		if (flag && flag2 && _0023_003Dzw1QwiPCxwNRZCwxwkA_003D_003D(num10, vector3D3, num11, vector3D4, p0A, vector3D, p0B, vector3D2))
		{
			return true;
		}
		if (flag && flag3 && _0023_003Dzw1QwiPCxwNRZCwxwkA_003D_003D(num10, vector3D3, num12, _0023_003DzYENOV_Q_003D, p0A, vector3D, p0B, vector3D2))
		{
			return true;
		}
		if (flag3 && flag2 && _0023_003Dzw1QwiPCxwNRZCwxwkA_003D_003D(num11, vector3D4, num12, _0023_003DzYENOV_Q_003D, p2A, vector3D, p0B, vector3D2))
		{
			return true;
		}
		return false;
	}

	private static bool _0023_003Dzw1QwiPCxwNRZCwxwkA_003D_003D(double _0023_003DzdznhJ9w_003D, Vector3D _0023_003Dz7ZE84gQ_003D, double _0023_003DzT7fIBwk_003D, Vector3D _0023_003DzYENOV_Q_003D, Point3D _0023_003DzfWhMsW4_003D, Vector3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003Dzl3DhHgI_003D, Vector3D _0023_003DzjdeMMkk_003D)
	{
		_0023_003Dzmfv7EqxqpxYO4X4MaQ_003D_003D(_0023_003DzdznhJ9w_003D, _0023_003Dz7ZE84gQ_003D, _0023_003DzT7fIBwk_003D, _0023_003DzYENOV_Q_003D, _0023_003DzfWhMsW4_003D, _0023_003DzFj_0024IqDQ_003D, _0023_003Dzl3DhHgI_003D, out var _0023_003DzvXOLtKg_003D, out var _0023_003DzEEncnNQ_003D);
		bool flag = _0023_003DzEEncnNQ_003D >= 0.0 && _0023_003DzEEncnNQ_003D <= 1.0;
		if (flag && _0023_003DzvXOLtKg_003D >= 0.0 && _0023_003DzvXOLtKg_003D <= 1.0)
		{
			return true;
		}
		_0023_003Dzmfv7EqxqpxYO4X4MaQ_003D_003D(_0023_003DzdznhJ9w_003D, _0023_003Dz7ZE84gQ_003D, _0023_003DzT7fIBwk_003D, _0023_003DzYENOV_Q_003D, _0023_003DzfWhMsW4_003D, _0023_003DzjdeMMkk_003D, _0023_003Dzl3DhHgI_003D, out var _0023_003DzvXOLtKg_003D2, out var _0023_003DzEEncnNQ_003D2);
		bool flag2 = _0023_003DzEEncnNQ_003D2 >= 0.0 && _0023_003DzEEncnNQ_003D2 <= 1.0;
		if (flag2 && _0023_003DzvXOLtKg_003D2 >= 0.0 && _0023_003DzvXOLtKg_003D2 <= 1.0)
		{
			return true;
		}
		if (flag && flag2 && !double.IsNaN(_0023_003DzvXOLtKg_003D2) && !double.IsNaN(_0023_003DzvXOLtKg_003D) && Math.Sign(_0023_003DzvXOLtKg_003D2) != Math.Sign(_0023_003DzvXOLtKg_003D) && Math.Min(_0023_003DzvXOLtKg_003D, _0023_003DzvXOLtKg_003D2) < 0.0 && Math.Max(_0023_003DzvXOLtKg_003D, _0023_003DzvXOLtKg_003D2) > 1.0)
		{
			return true;
		}
		Point3D _0023_003Dzl3DhHgI_003D2 = _0023_003Dzl3DhHgI_003D + _0023_003DzjdeMMkk_003D;
		Vector3D _0023_003DzFj_0024IqDQ_003D2 = _0023_003DzjdeMMkk_003D - _0023_003DzFj_0024IqDQ_003D;
		_0023_003Dzmfv7EqxqpxYO4X4MaQ_003D_003D(_0023_003DzdznhJ9w_003D, _0023_003Dz7ZE84gQ_003D, _0023_003DzT7fIBwk_003D, _0023_003DzYENOV_Q_003D, _0023_003DzfWhMsW4_003D, _0023_003DzFj_0024IqDQ_003D2, _0023_003Dzl3DhHgI_003D2, out var _0023_003DzvXOLtKg_003D3, out var _0023_003DzEEncnNQ_003D3);
		bool flag3 = _0023_003DzEEncnNQ_003D3 >= 0.0 && _0023_003DzEEncnNQ_003D3 <= 1.0;
		if (flag3 && _0023_003DzvXOLtKg_003D3 >= 0.0 && _0023_003DzvXOLtKg_003D3 <= 1.0)
		{
			return true;
		}
		if ((flag && flag3 && !double.IsNaN(_0023_003DzvXOLtKg_003D) && !double.IsNaN(_0023_003DzvXOLtKg_003D3) && Math.Sign(_0023_003DzvXOLtKg_003D3) != Math.Sign(_0023_003DzvXOLtKg_003D) && Math.Min(_0023_003DzvXOLtKg_003D, _0023_003DzvXOLtKg_003D3) < 0.0 && Math.Max(_0023_003DzvXOLtKg_003D, _0023_003DzvXOLtKg_003D3) > 1.0) || (flag2 && flag3 && !double.IsNaN(_0023_003DzvXOLtKg_003D2) && !double.IsNaN(_0023_003DzvXOLtKg_003D3) && Math.Sign(_0023_003DzvXOLtKg_003D2) != Math.Sign(_0023_003DzvXOLtKg_003D3) && Math.Min(_0023_003DzvXOLtKg_003D3, _0023_003DzvXOLtKg_003D2) < 0.0 && Math.Max(_0023_003DzvXOLtKg_003D3, _0023_003DzvXOLtKg_003D2) > 1.0))
		{
			return true;
		}
		return false;
	}

	private static bool _0023_003Dzmfv7EqxqpxYO4X4MaQ_003D_003D(double _0023_003DzdznhJ9w_003D, Vector3D _0023_003Dz7ZE84gQ_003D, double _0023_003DzT7fIBwk_003D, Vector3D _0023_003DzYENOV_Q_003D, Point3D _0023_003DzfWhMsW4_003D, Vector3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003Dzl3DhHgI_003D, out double _0023_003DzvXOLtKg_003D, out double _0023_003DzEEncnNQ_003D)
	{
		Vector3D vector3D = _0023_003DzdznhJ9w_003D * _0023_003Dz7ZE84gQ_003D;
		Vector3D vector3D2 = _0023_003DzT7fIBwk_003D * _0023_003DzYENOV_Q_003D;
		Point3D point3D = _0023_003DzfWhMsW4_003D + vector3D;
		Vector3D vector3D3 = vector3D2 - vector3D;
		_0023_003DzEEncnNQ_003D = -1.0;
		_0023_003DzvXOLtKg_003D = -1.0;
		double num = -1.0;
		double num2 = -1.0;
		double num3 = _0023_003DzFj_0024IqDQ_003D.X * vector3D3.Y - vector3D3.X * _0023_003DzFj_0024IqDQ_003D.Y;
		double num4 = point3D.X - _0023_003Dzl3DhHgI_003D.X;
		double num5 = point3D.Y - _0023_003Dzl3DhHgI_003D.Y;
		double num6 = point3D.Z - _0023_003Dzl3DhHgI_003D.Z;
		double num7 = num4 * vector3D3.Y - vector3D3.X * num5;
		double num8 = num4 * vector3D3.Z - vector3D3.X * num6;
		double num9 = num5 * vector3D3.Z - vector3D3.Y * num6;
		if (num3 != 0.0)
		{
			num = num7;
			num2 = _0023_003DzFj_0024IqDQ_003D.X * num4 - num5 * _0023_003DzFj_0024IqDQ_003D.Y;
		}
		else
		{
			num3 = _0023_003DzFj_0024IqDQ_003D.X * vector3D3.Z - vector3D3.X * _0023_003DzFj_0024IqDQ_003D.Z;
			if (num3 != 0.0)
			{
				num = num8;
				num2 = _0023_003DzFj_0024IqDQ_003D.X * num4 - num6 * _0023_003DzFj_0024IqDQ_003D.Z;
			}
			else
			{
				num3 = _0023_003DzFj_0024IqDQ_003D.Y * vector3D3.Z - vector3D3.Y * _0023_003DzFj_0024IqDQ_003D.Z;
				if (num3 == 0.0)
				{
					return false;
				}
				num = num9;
				num2 = _0023_003DzFj_0024IqDQ_003D.Y * num5 - num6 * _0023_003DzFj_0024IqDQ_003D.Z;
			}
		}
		_0023_003DzEEncnNQ_003D = num / num3;
		_0023_003DzvXOLtKg_003D = (0.0 - num2) / num3;
		return true;
	}

	public static bool LinePlaneIntersection(Point3D p0, Point3D p1, PlaneEquation pe, out Point3D intPoint)
	{
		intPoint = null;
		Vector3D vector3D = Vector3D.Subtract(p1, p0);
		double num = pe * vector3D;
		if (Math.Abs(num) < 1E-09)
		{
			return false;
		}
		double num2 = (0.0 - pe.ValueAt(p0)) / num;
		intPoint = p0 + num2 * vector3D;
		return true;
	}

	public static double[] MultMatrixd(double[] a, double[] b)
	{
		return new double[16]
		{
			a[0] * b[0] + a[1] * b[4] + a[2] * b[8] + a[3] * b[12],
			a[0] * b[1] + a[1] * b[5] + a[2] * b[9] + a[3] * b[13],
			a[0] * b[2] + a[1] * b[6] + a[2] * b[10] + a[3] * b[14],
			a[0] * b[3] + a[1] * b[7] + a[2] * b[11] + a[3] * b[15],
			a[4] * b[0] + a[5] * b[4] + a[6] * b[8] + a[7] * b[12],
			a[4] * b[1] + a[5] * b[5] + a[6] * b[9] + a[7] * b[13],
			a[4] * b[2] + a[5] * b[6] + a[6] * b[10] + a[7] * b[14],
			a[4] * b[3] + a[5] * b[7] + a[6] * b[11] + a[7] * b[15],
			a[8] * b[0] + a[9] * b[4] + a[10] * b[8] + a[11] * b[12],
			a[8] * b[1] + a[9] * b[5] + a[10] * b[9] + a[11] * b[13],
			a[8] * b[2] + a[9] * b[6] + a[10] * b[10] + a[11] * b[14],
			a[8] * b[3] + a[9] * b[7] + a[10] * b[11] + a[11] * b[15],
			a[12] * b[0] + a[13] * b[4] + a[14] * b[8] + a[15] * b[12],
			a[12] * b[1] + a[13] * b[5] + a[14] * b[9] + a[15] * b[13],
			a[12] * b[2] + a[13] * b[6] + a[14] * b[10] + a[15] * b[14],
			a[12] * b[3] + a[13] * b[7] + a[14] * b[11] + a[15] * b[15]
		};
	}

	public static float[] MultMatrixf(float[] a, float[] b)
	{
		float[] array = new float[16];
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				array[i * 4 + j] = a[i * 4] * b[j] + a[i * 4 + 1] * b[4 + j] + a[i * 4 + 2] * b[8 + j] + a[i * 4 + 3] * b[12 + j];
			}
		}
		return array;
	}

	public static double[] MultMatrixVecd(double[] matrix, double[] vector)
	{
		return new double[4]
		{
			vector[0] * matrix[0] + vector[1] * matrix[4] + vector[2] * matrix[8] + vector[3] * matrix[12],
			vector[0] * matrix[1] + vector[1] * matrix[5] + vector[2] * matrix[9] + vector[3] * matrix[13],
			vector[0] * matrix[2] + vector[1] * matrix[6] + vector[2] * matrix[10] + vector[3] * matrix[14],
			vector[0] * matrix[3] + vector[1] * matrix[7] + vector[2] * matrix[11] + vector[3] * matrix[15]
		};
	}

	protected internal static void FindLoopsInternal(Point2D[][] loops, out Point2D[][] outers, out Point2D[][][] inners, out int[] outersIndices, out int[][] innersIndices)
	{
		IList<bool> list = new bool[loops.Length];
		IList<IList<int>> list2 = new List<int>[loops.Length];
		_0023_003DzRaUhii6fJeG0[] array = _0023_003Dz8ixxG_IP8PL_(loops, _0023_003Dz80uXCRO2kkba: false);
		if (array.Length > 1 && Compare(1E-09, array[0]._0023_003DzjTLb8o0_003D, array[1]._0023_003DzjTLb8o0_003D) == 0)
		{
			array = _0023_003Dz8ixxG_IP8PL_(loops, _0023_003Dz80uXCRO2kkba: true);
		}
		Array.Sort(array, new _0023_003Dz_0024ImZRv_0024KTAj1());
		for (int i = 0; i < list2.Count; i++)
		{
			list2[i] = new List<int>();
		}
		bool[] array2 = new bool[array.Length];
		for (int j = 0; j < array.Length; j++)
		{
			if (array2[j])
			{
				continue;
			}
			IList<Point2D> _0023_003Dz06A5WivSSyUp = array[j]._0023_003Dz06A5WivSSyUp;
			array2[j] = true;
			for (int k = j + 1; k < array.Length; k++)
			{
				if (array2[k])
				{
					continue;
				}
				IList<Point2D> _0023_003Dz06A5WivSSyUp2 = array[k]._0023_003Dz06A5WivSSyUp;
				bool flag = false;
				int num = 0;
				int num2 = _0023_003Dz06A5WivSSyUp2.Count;
				if (_0023_003Dz06A5WivSSyUp2.Count > 2)
				{
					num++;
					num2--;
				}
				for (int l = num; l < num2; l++)
				{
					if (!PointInPolygon(_0023_003Dz06A5WivSSyUp2[l], _0023_003Dz06A5WivSSyUp))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list2[j].Add(k);
					array2[k] = true;
				}
			}
			list[j] = true;
		}
		for (int m = 0; m < list2.Count; m++)
		{
			_0023_003DzPQar2_diWLoNCuyE1A_003D_003D(array, list2[m], list, list2, _0023_003DzJpDHqdDTBGrcJyypJQ_003D_003D: false, null);
		}
		int num3 = 0;
		for (int n = 0; n < list.Count; n++)
		{
			if (list[n])
			{
				num3++;
			}
		}
		outers = new Point2D[num3][];
		inners = new Point2D[num3][][];
		outersIndices = new int[num3];
		innersIndices = new int[num3][];
		num3 = 0;
		for (int num4 = 0; num4 < list.Count; num4++)
		{
			if (!list[num4])
			{
				continue;
			}
			outers[num3] = array[num4]._0023_003Dz06A5WivSSyUp;
			outersIndices[num3] = array[num4]._0023_003DzyzK8swU_003D;
			if (list2[num4] != null)
			{
				inners[num3] = new Point2D[list2[num4].Count][];
				innersIndices[num3] = new int[list2[num4].Count];
				for (int num5 = 0; num5 < list2[num4].Count; num5++)
				{
					inners[num3][num5] = array[list2[num4][num5]]._0023_003Dz06A5WivSSyUp;
					innersIndices[num3][num5] = array[list2[num4][num5]]._0023_003DzyzK8swU_003D;
				}
			}
			num3++;
		}
	}

	protected internal static void FindLoopsInternal(IList<ICurve> loops, out int[] outersIndices, out int[][] innersIndices, Plane plane)
	{
		IList<bool> list = new bool[loops.Count];
		IList<IList<int>> list2 = new List<int>[loops.Count];
		_0023_003DzRaUhii6fJeG0[] array = _0023_003Dz8ixxG_IP8PL_(loops, _0023_003Dz80uXCRO2kkba: false);
		if (array.Length > 1 && Compare(1E-09, array[0]._0023_003DzjTLb8o0_003D, array[1]._0023_003DzjTLb8o0_003D) == 0)
		{
			array = _0023_003Dz8ixxG_IP8PL_(loops, _0023_003Dz80uXCRO2kkba: true);
		}
		Array.Sort(array, new _0023_003Dz_0024ImZRv_0024KTAj1());
		for (int i = 0; i < list2.Count; i++)
		{
			list2[i] = new List<int>();
		}
		bool[] array2 = new bool[array.Length];
		for (int j = 0; j < array.Length; j++)
		{
			if (array2[j])
			{
				continue;
			}
			ICurve _0023_003Dz5MW1eJg__0024ioiTFboUdiEDFk_003D = array[j]._0023_003Dz5MW1eJg__0024ioiTFboUdiEDFk_003D;
			devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(_0023_003Dz5MW1eJg__0024ioiTFboUdiEDFk_003D, plane, sortAndOrient: false);
			array2[j] = true;
			for (int k = j + 1; k < array.Length; k++)
			{
				if (array2[k])
				{
					continue;
				}
				ICurve _0023_003Dz5MW1eJg__0024ioiTFboUdiEDFk_003D2 = array[k]._0023_003Dz5MW1eJg__0024ioiTFboUdiEDFk_003D;
				if (_0023_003Dz5MW1eJg__0024ioiTFboUdiEDFk_003D.IntersectWith(_0023_003Dz5MW1eJg__0024ioiTFboUdiEDFk_003D2).Length >= 2)
				{
					continue;
				}
				ICurve[] array3 = _0023_003Dz5MW1eJg__0024ioiTFboUdiEDFk_003D2.GetIndividualCurves();
				if (array3.Length == 1 && array3[0].SplitAt(array3[0].Domain.ParameterAt(0.5), out var lower, out var upper))
				{
					array3 = new ICurve[2] { lower, upper };
				}
				bool flag = false;
				ICurve[] array4 = array3;
				foreach (ICurve curve in array4)
				{
					if (region.IsPointInside(curve.StartPoint))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					list2[j].Add(k);
					array2[k] = true;
				}
			}
			list[j] = true;
		}
		for (int m = 0; m < list2.Count; m++)
		{
			_0023_003DzPQar2_diWLoNCuyE1A_003D_003D(array, list2[m], list, list2, _0023_003DzJpDHqdDTBGrcJyypJQ_003D_003D: true, plane);
		}
		int num = 0;
		for (int n = 0; n < list.Count; n++)
		{
			if (list[n])
			{
				num++;
			}
		}
		outersIndices = new int[num];
		innersIndices = new int[num][];
		num = 0;
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			if (!list[num2])
			{
				continue;
			}
			outersIndices[num] = array[num2]._0023_003DzyzK8swU_003D;
			if (list2[num2] != null)
			{
				innersIndices[num] = new int[list2[num2].Count];
				for (int num3 = 0; num3 < list2[num2].Count; num3++)
				{
					innersIndices[num][num3] = array[list2[num2][num3]]._0023_003DzyzK8swU_003D;
				}
			}
			num++;
		}
	}

	public static void FindLoops(Point2D[][] loops, out Point2D[][] outers, out Point2D[][][] inners)
	{
		FindLoopsInternal(loops, out outers, out inners, out var _, out var _);
	}

	private static void _0023_003DzPQar2_diWLoNCuyE1A_003D_003D(_0023_003DzRaUhii6fJeG0[] _0023_003Dzm1sj9vVxNj34, IList<int> _0023_003DzWaFlkhfmYCja, IList<bool> _0023_003DzrBN5DibSQbzQPBe3VIRcOm8_003D, IList<IList<int>> _0023_003Dz1WbQOFzHTmucVhbztsgsveo_003D, bool _0023_003DzJpDHqdDTBGrcJyypJQ_003D_003D, Plane _0023_003Dzrgqz890sj_0024X9)
	{
		for (int i = 0; i < _0023_003DzWaFlkhfmYCja.Count; i++)
		{
			List<int> list = (_0023_003DzJpDHqdDTBGrcJyypJQ_003D_003D ? _0023_003Dzp8LibrWP_00246zTteegAw_003D_003D(i, _0023_003Dzm1sj9vVxNj34, _0023_003DzWaFlkhfmYCja, _0023_003Dzrgqz890sj_0024X9) : _0023_003Dzp8LibrWP_00246zTteegAw_003D_003D(i, _0023_003Dzm1sj9vVxNj34, _0023_003DzWaFlkhfmYCja));
			if (list.Count > 0)
			{
				for (int j = 0; j < list.Count; j++)
				{
					int index = list[j];
					_0023_003DzrBN5DibSQbzQPBe3VIRcOm8_003D[index] = true;
					_0023_003Dz1WbQOFzHTmucVhbztsgsveo_003D[index] = (_0023_003DzJpDHqdDTBGrcJyypJQ_003D_003D ? _0023_003Dzp8LibrWP_00246zTteegAw_003D_003D(j, _0023_003Dzm1sj9vVxNj34, list, _0023_003Dzrgqz890sj_0024X9) : _0023_003Dzp8LibrWP_00246zTteegAw_003D_003D(j, _0023_003Dzm1sj9vVxNj34, list));
					_0023_003DzPQar2_diWLoNCuyE1A_003D_003D(_0023_003Dzm1sj9vVxNj34, _0023_003Dz1WbQOFzHTmucVhbztsgsveo_003D[index], _0023_003DzrBN5DibSQbzQPBe3VIRcOm8_003D, _0023_003Dz1WbQOFzHTmucVhbztsgsveo_003D, _0023_003DzJpDHqdDTBGrcJyypJQ_003D_003D, _0023_003Dzrgqz890sj_0024X9);
				}
			}
		}
	}

	private static List<int> _0023_003Dzp8LibrWP_00246zTteegAw_003D_003D(int _0023_003Dz437_00244ak_003D, _0023_003DzRaUhii6fJeG0[] _0023_003Dzm1sj9vVxNj34, IList<int> _0023_003Dzcv8o5nO25OjS)
	{
		List<int> list = new List<int>();
		IList<Point2D> _0023_003Dz06A5WivSSyUp = _0023_003Dzm1sj9vVxNj34[_0023_003Dzcv8o5nO25OjS[_0023_003Dz437_00244ak_003D]]._0023_003Dz06A5WivSSyUp;
		for (int i = _0023_003Dz437_00244ak_003D + 1; i < _0023_003Dzcv8o5nO25OjS.Count; i++)
		{
			IList<Point2D> _0023_003Dz06A5WivSSyUp2 = _0023_003Dzm1sj9vVxNj34[_0023_003Dzcv8o5nO25OjS[i]]._0023_003Dz06A5WivSSyUp;
			bool flag = true;
			for (int j = 0; j < _0023_003Dz06A5WivSSyUp2.Count; j++)
			{
				if (!PointInPolygon(_0023_003Dz06A5WivSSyUp2[j], _0023_003Dz06A5WivSSyUp))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				list.Add(_0023_003Dzcv8o5nO25OjS[i]);
				_0023_003Dzcv8o5nO25OjS.RemoveAt(i);
				i--;
			}
		}
		return list;
	}

	private static List<int> _0023_003Dzp8LibrWP_00246zTteegAw_003D_003D(int _0023_003Dz437_00244ak_003D, _0023_003DzRaUhii6fJeG0[] _0023_003Dzm1sj9vVxNj34, IList<int> _0023_003Dzcv8o5nO25OjS, Plane _0023_003Dzrgqz890sj_0024X9)
	{
		List<int> list = new List<int>();
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(_0023_003Dzm1sj9vVxNj34[_0023_003Dzcv8o5nO25OjS[_0023_003Dz437_00244ak_003D]]._0023_003Dz5MW1eJg__0024ioiTFboUdiEDFk_003D, _0023_003Dzrgqz890sj_0024X9, sortAndOrient: false);
		for (int i = _0023_003Dz437_00244ak_003D + 1; i < _0023_003Dzcv8o5nO25OjS.Count; i++)
		{
			ICurve _0023_003Dz5MW1eJg__0024ioiTFboUdiEDFk_003D = _0023_003Dzm1sj9vVxNj34[_0023_003Dzcv8o5nO25OjS[i]]._0023_003Dz5MW1eJg__0024ioiTFboUdiEDFk_003D;
			if (region.IsPointInside(_0023_003Dz5MW1eJg__0024ioiTFboUdiEDFk_003D.PointAt(_0023_003Dz5MW1eJg__0024ioiTFboUdiEDFk_003D.Domain.Mid)))
			{
				list.Add(_0023_003Dzcv8o5nO25OjS[i]);
				_0023_003Dzcv8o5nO25OjS.RemoveAt(i);
				i--;
			}
		}
		return list;
	}

	private static _0023_003DzRaUhii6fJeG0[] _0023_003Dz8ixxG_IP8PL_(Point2D[][] _0023_003Dzcv8o5nO25OjS, bool _0023_003Dz80uXCRO2kkba)
	{
		_0023_003DzRaUhii6fJeG0[] array = new _0023_003DzRaUhii6fJeG0[_0023_003Dzcv8o5nO25OjS.Length];
		for (int i = 0; i < _0023_003Dzcv8o5nO25OjS.Length; i++)
		{
			double num = double.MaxValue;
			Point2D[] array2 = _0023_003Dzcv8o5nO25OjS[i];
			for (int j = 0; j < _0023_003Dzcv8o5nO25OjS[i].Length; j++)
			{
				if (_0023_003Dz80uXCRO2kkba)
				{
					if (array2[j].Y < num)
					{
						num = array2[j].Y;
					}
				}
				else if (array2[j].X < num)
				{
					num = array2[j].X;
				}
			}
			array[i] = new _0023_003DzRaUhii6fJeG0(i, num, _0023_003Dzcv8o5nO25OjS[i]);
		}
		return array;
	}

	private static _0023_003DzRaUhii6fJeG0[] _0023_003Dz8ixxG_IP8PL_(IList<ICurve> _0023_003Dzcv8o5nO25OjS, bool _0023_003Dz80uXCRO2kkba)
	{
		_0023_003DzRaUhii6fJeG0[] array = new _0023_003DzRaUhii6fJeG0[_0023_003Dzcv8o5nO25OjS.Count];
		for (int i = 0; i < _0023_003Dzcv8o5nO25OjS.Count; i++)
		{
			double num = double.MaxValue;
			_0023_003Dzcv8o5nO25OjS[i].GetApproximatedBoundingBox(out var boxMin, out var _);
			if (_0023_003Dz80uXCRO2kkba)
			{
				if (boxMin.Y < num)
				{
					num = boxMin.Y;
				}
			}
			else if (boxMin.X < num)
			{
				num = boxMin.X;
			}
			array[i] = new _0023_003DzRaUhii6fJeG0(i, num, _0023_003Dzcv8o5nO25OjS[i]);
		}
		return array;
	}

	public static void OffsetPoint(Point3D p1, Point3D p2, double length, out Point3D offsetPoint)
	{
		Vector3D vector3D = new Vector3D((p2 - p1).ToArray());
		vector3D.Normalize();
		offsetPoint = new Point3D(p2.X + length * vector3D.X, p2.Y + length * vector3D.Y, p2.Z + length * vector3D.Z);
	}

	public static T[] RemoveDuplicates<T>(IList<T> pointList) where T : Point2D
	{
		IList<int> _0023_003DzDPPdnUk_003D;
		return _0023_003DzOq_CSAk_003D(pointList, _0023_003DzfZ9aOqw_003D: false, out _0023_003DzDPPdnUk_003D, 1E-09);
	}

	public static T[] RemoveDuplicates<T>(IList<T> pointList, out IList<int> indices) where T : Point2D
	{
		return _0023_003DzOq_CSAk_003D(pointList, _0023_003DzfZ9aOqw_003D: true, out indices, 1E-09);
	}

	public static T[] RemoveDuplicates<T>(IList<T> pointList, double tol) where T : Point2D
	{
		IList<int> _0023_003DzDPPdnUk_003D;
		return _0023_003DzOq_CSAk_003D(pointList, _0023_003DzfZ9aOqw_003D: false, out _0023_003DzDPPdnUk_003D, tol);
	}

	private static T[] _0023_003DzOq_CSAk_003D<T>(IList<T> _0023_003DzTyB0NW0_003D, bool _0023_003DzfZ9aOqw_003D, out IList<int> _0023_003DzDPPdnUk_003D, double _0023_003Dzm0CYiiE_003D) where T : Point2D
	{
		int count = _0023_003DzTyB0NW0_003D.Count;
		double num = 0.0;
		double[] array = new double[count - 1];
		if (_0023_003DzTyB0NW0_003D[0] is Point3D)
		{
			for (int i = 0; i < count - 1; i++)
			{
				Point3D point3D = _0023_003DzTyB0NW0_003D[i] as Point3D;
				Point3D b = _0023_003DzTyB0NW0_003D[i + 1] as Point3D;
				array[i] = point3D.DistanceTo(b);
				num += array[i];
			}
		}
		else
		{
			for (int j = 0; j < count - 1; j++)
			{
				T val = _0023_003DzTyB0NW0_003D[j];
				T b2 = _0023_003DzTyB0NW0_003D[j + 1];
				array[j] = val.DistanceTo(b2);
				num += array[j];
			}
		}
		double num2 = num * _0023_003Dzm0CYiiE_003D;
		if (num2 < 1E-12)
		{
			num2 = 1E-12;
		}
		List<T> list = new List<T>(count);
		list.Add(_0023_003DzTyB0NW0_003D[0]);
		List<int> list2 = new List<int>(count);
		if (_0023_003DzfZ9aOqw_003D)
		{
			list2.Add(0);
		}
		for (int k = 0; k < count - 1; k++)
		{
			if (!(array[k] > num2))
			{
				continue;
			}
			for (int l = k + 1; l < count - 1; l++)
			{
				if (array[l] > num2)
				{
					list.Add(_0023_003DzTyB0NW0_003D[k + 1]);
					if (_0023_003DzfZ9aOqw_003D)
					{
						list2.Add(k + 1);
					}
					break;
				}
			}
		}
		double num3 = 0.0;
		if (_0023_003DzTyB0NW0_003D[0] is Point3D)
		{
			Point3D obj = _0023_003DzTyB0NW0_003D[0] as Point3D;
			Point3D b3 = _0023_003DzTyB0NW0_003D[count - 1] as Point3D;
			num3 = obj.DistanceTo(b3);
		}
		else
		{
			T val2 = _0023_003DzTyB0NW0_003D[0];
			T b4 = _0023_003DzTyB0NW0_003D[count - 1];
			num3 = val2.DistanceTo(b4);
		}
		if (list.Count > 1 || (list.Count == 1 && num3 > num2))
		{
			list.Add(_0023_003DzTyB0NW0_003D[count - 1]);
			if (_0023_003DzfZ9aOqw_003D)
			{
				list2.Add(count - 1);
			}
		}
		_0023_003DzDPPdnUk_003D = list2.ToArray();
		return list.ToArray();
	}

	public static T[] GetSampling<T>(IList<T> vertices) where T : Point2D
	{
		int count = vertices.Count;
		if (count == 0)
		{
			return new T[0];
		}
		int num = 4 + (int)Math.Pow(vertices.Count, 1.0 / 3.0);
		if (num > count)
		{
			num = count;
		}
		int num2 = count / num;
		if (num2 == 0)
		{
			num2 = 1;
		}
		T[] array = new T[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = vertices[i * num2];
		}
		return array;
	}

	public static Point3D[] GetSampling(float[] vertices)
	{
		int num = vertices.Length / 3;
		if (num == 0)
		{
			return new Point3D[0];
		}
		int num2 = 4 + (int)Math.Pow(vertices.Length / 3, 1.0 / 3.0);
		if (num2 > num)
		{
			num2 = num;
		}
		int num3 = num / num2;
		if (num3 == 0)
		{
			num3 = 1;
		}
		Point3D[] array = new Point3D[num2];
		for (int i = 0; i < num2; i++)
		{
			array[i] = new Point3D(vertices[i * num3], vertices[i * num3 + 1], vertices[i * num3 + 2]);
		}
		return array;
	}

	public static Transformation GetOrientationTransformation(Point3D position, Vector3D direction)
	{
		Vector3D obj = (Vector3D)direction.Clone();
		obj.Normalize();
		double angleInXY = obj.AngleInXY;
		double angleFromXY = obj.AngleFromXY;
		return new Translation(position.X, position.Y, position.Z) * new Rotation(angleInXY, Vector3D.AxisZ) * new Rotation(0.0 - angleFromXY, Vector3D.AxisY);
	}

	public static bool InsideOrCrossingFrustum(Point3D pt1, Point3D pt2, Point3D pt3, PlaneEquation[] frustum)
	{
		Segment3D segment = new Segment3D(pt1, pt2);
		if (IsSegmentInsideOrCrossing(frustum, segment))
		{
			return true;
		}
		segment = new Segment3D(pt2, pt3);
		if (IsSegmentInsideOrCrossing(frustum, segment))
		{
			return true;
		}
		segment = new Segment3D(pt3, pt1);
		if (IsSegmentInsideOrCrossing(frustum, segment))
		{
			return true;
		}
		return false;
	}

	public static bool InsideOrCrossingFrustumQuad(Point3D pt1, Point3D pt2, Point3D pt3, Point3D pt4, PlaneEquation[] frustum)
	{
		Segment3D segment = new Segment3D(pt1, pt2);
		if (IsSegmentInsideOrCrossing(frustum, segment))
		{
			return true;
		}
		segment = new Segment3D(pt2, pt3);
		if (IsSegmentInsideOrCrossing(frustum, segment))
		{
			return true;
		}
		segment = new Segment3D(pt3, pt4);
		if (IsSegmentInsideOrCrossing(frustum, segment))
		{
			return true;
		}
		segment = new Segment3D(pt4, pt1);
		if (IsSegmentInsideOrCrossing(frustum, segment))
		{
			return true;
		}
		return false;
	}

	public static bool IsSegmentInsideOrCrossing(PlaneEquation[] frustum, Segment3D segment)
	{
		Point3D point3D = segment.P0;
		Point3D point3D2 = segment.P1;
		for (int i = 0; i < 6; i++)
		{
			PlaneEquation planeEquation = frustum[i];
			double num = planeEquation.ValueAt(point3D);
			double num2 = planeEquation.ValueAt(point3D2);
			if (num < 0.0 && num2 < 0.0)
			{
				return false;
			}
			if (!(num * num2 > 0.0))
			{
				Vector3D vector3D = Vector3D.Subtract(point3D2, point3D);
				double num3 = planeEquation * vector3D;
				if (Math.Abs(num3) < _0023_003DzheSR8QM7q9ya)
				{
					return false;
				}
				double num4 = (0.0 - num) / num3;
				Point3D point3D3 = point3D + num4 * vector3D;
				if (num < 0.0)
				{
					point3D = point3D3;
				}
				else
				{
					point3D2 = point3D3;
				}
			}
		}
		return true;
	}

	public static bool IsPointInsideOrCrossing(PlaneEquation[] frustum, Point3D point)
	{
		for (int i = 0; i < 6; i++)
		{
			if (frustum[i].ValueAt(point) < 0.0)
			{
				return false;
			}
		}
		return true;
	}

	public static void TransformNormals(Transformation t, Vector3D[] normals)
	{
		if (!t.IsTranslation)
		{
			Transformation matrixForNormals = GetMatrixForNormals(t);
			bool hasScaling = t.HasScaling;
			foreach (Vector3D vector3D in normals)
			{
				_0023_003Dze5abBKgivGEU(matrixForNormals, hasScaling, ref vector3D.X, ref vector3D.Y, ref vector3D.Z);
			}
		}
	}

	internal static void _0023_003Dze5abBKgivGEU(Transformation _0023_003Dzk5acqRZ3KToeyq6Z_A_003D_003D, bool _0023_003Dz_Q8rZNlsxZpO, ref double _0023_003Dz6oPZTp0_003D, ref double _0023_003DzE54gPbg_003D, ref double _0023_003DzSQIwcNs_003D)
	{
		double[] array = _0023_003Dzk5acqRZ3KToeyq6Z_A_003D_003D.ActOnLeftZero(_0023_003Dz6oPZTp0_003D, _0023_003DzE54gPbg_003D, _0023_003DzSQIwcNs_003D);
		if (_0023_003Dz_Q8rZNlsxZpO)
		{
			double num = Math.Sqrt(array[0] * array[0] + array[1] * array[1] + array[2] * array[2]);
			array[0] /= num;
			array[1] /= num;
			array[2] /= num;
		}
		_0023_003Dz6oPZTp0_003D = array[0];
		_0023_003DzE54gPbg_003D = array[1];
		_0023_003DzSQIwcNs_003D = array[2];
	}

	public static Transformation GetMatrixForNormals(Transformation transform)
	{
		Transformation transformation = new Transformation(transform.Matrix);
		transformation.Invert();
		transformation.Transpose();
		return transformation;
	}

	public static void Translated(double dx, double dy, double dz, ref double[] original)
	{
		original = MultMatrixd(b: new double[16]
		{
			1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0,
			1.0, 0.0, dx, dy, dz, 1.0
		}, a: original);
	}

	public static void Scaled(double sx, double sy, double sz, ref double[] original)
	{
		original = MultMatrixd(new double[16]
		{
			sx, 0.0, 0.0, 0.0, 0.0, sy, 0.0, 0.0, 0.0, 0.0,
			sz, 0.0, 0.0, 0.0, 0.0, 1.0
		}, original);
	}

	public static T PrevItem<T>(IList<T> list, int itemIndex)
	{
		if (itemIndex <= 0)
		{
			return list[list.Count - 1];
		}
		return list[itemIndex - 1];
	}

	public static T NextItem<T>(IList<T> list, int itemIndex)
	{
		if (itemIndex >= list.Count - 1)
		{
			return list[0];
		}
		return list[itemIndex + 1];
	}

	public static Vector3D NormalInterpolation(Point3D p1, Vector3D n1, Point3D p2, Vector3D n2, Point3D p)
	{
		Point3D point3D = p1 + n1;
		Point3D point3D2 = p2 + n2;
		double num = Point3D.Distance(p1, p);
		double num2 = Point3D.Distance(p1, p2);
		Vector3D vector3D = Vector3D.Subtract(point3D + (point3D2 - point3D) * (num / num2), p);
		vector3D.Normalize();
		return vector3D;
	}

	public static Vector3D NormalInterpolation(Point3D p1, Vector3D n1, Point3D p2, Vector3D n2, Point3D p3, Vector3D n3, Point3D p4, Vector3D n4, Point3D p, Vector3D splittingPlaneNormal)
	{
		Segment3D segment3D = new Segment3D(p1, p2);
		Segment3D segment3D2 = new Segment3D(p2, p3);
		Segment3D segment3D3 = new Segment3D(p3, p4);
		Segment3D segment3D4 = new Segment3D(p4, p1);
		Plane plane = new Plane(p, splittingPlaneNormal);
		int num = 0;
		Point3D[] array = new Point3D[2];
		Vector3D[] array2 = new Vector3D[2];
		if (segment3D.IntersectWith(plane, out var intPoint))
		{
			array[num] = intPoint;
			array2[num] = NormalInterpolation(p1, n1, p2, n2, intPoint);
			num++;
		}
		if (segment3D2.IntersectWith(plane, out var intPoint2))
		{
			array[num] = intPoint2;
			array2[num] = NormalInterpolation(p2, n2, p3, n3, intPoint2);
			num++;
		}
		if (num < 2 && segment3D3.IntersectWith(plane, out var intPoint3))
		{
			array[num] = intPoint3;
			array2[num] = NormalInterpolation(p3, n3, p4, n4, intPoint3);
			num++;
		}
		if (num < 2 && segment3D4.IntersectWith(plane, out var intPoint4))
		{
			array[num] = intPoint4;
			array2[num] = NormalInterpolation(p4, n4, p1, n1, intPoint4);
		}
		if (num == 2)
		{
			return NormalInterpolation(array[0], array2[0], array[1], array2[1], p);
		}
		return array2[0];
	}

	public static double ComputeTolerance(double sceneDiagonal)
	{
		double num = sceneDiagonal * 0.0002;
		if (num < _0023_003DzxhnLabVjXjPg)
		{
			num = _0023_003DzxhnLabVjXjPg;
		}
		return num;
	}

	public static bool IsClosedProfile(IList<Point2D> profile)
	{
		Point2D maxValue = Point2D.MaxValue;
		Point2D minValue = Point2D.MinValue;
		UpdateMinMax(null, profile, profile.Count, maxValue, minValue);
		double domainSize = Point2D.Distance(maxValue, minValue);
		return Point2D.AreEqual(profile[0], profile[profile.Count - 1], domainSize);
	}

	public static bool IsClosedProfile(IList<Point3D> profile)
	{
		Point3D maxValue = Point3D.MaxValue;
		Point3D minValue = Point3D.MinValue;
		UpdateMinMax(null, profile, profile.Count, maxValue, minValue);
		double domainSize = Point3D.Distance(maxValue, minValue);
		return Point3D.AreEqual(profile[0], profile[profile.Count - 1], domainSize);
	}

	public static List<Point3D> GetPlanarIntersectionProfile(Plane plane, Point3D min, Point3D max, out bool onTheSameSide)
	{
		Point3D[] boundingBoxCorners = GetBoundingBoxCorners(min, max);
		int num = Math.Sign(plane.DistanceTo(boundingBoxCorners[0]));
		onTheSameSide = true;
		for (int i = 1; i < 8; i++)
		{
			if (Math.Sign(plane.DistanceTo(boundingBoxCorners[i])) != num)
			{
				onTheSameSide = false;
				break;
			}
		}
		if (onTheSameSide)
		{
			return null;
		}
		Point2D point2D = plane.Project(boundingBoxCorners[0]);
		Point2D point2D2 = (Point2D)point2D.Clone();
		Point2D point2D3 = (Point2D)point2D.Clone();
		for (int j = 1; j < 8; j++)
		{
			point2D = plane.Project(boundingBoxCorners[j]);
			if (point2D.X < point2D2.X)
			{
				point2D2.X = point2D.X;
			}
			else if (point2D.X > point2D3.X)
			{
				point2D3.X = point2D.X;
			}
			if (point2D.Y < point2D2.Y)
			{
				point2D2.Y = point2D.Y;
			}
			else if (point2D.Y > point2D3.Y)
			{
				point2D3.Y = point2D.Y;
			}
		}
		Point2D point2D4 = new Point2D(point2D3.X - point2D2.X, point2D3.Y - point2D2.Y);
		point2D4.X *= 0.02;
		point2D4.Y *= 0.02;
		if (Math.Abs(point2D4.X) < 1E-05)
		{
			point2D4.X = 1.0;
		}
		if (Math.Abs(point2D4.Y) < 1E-05)
		{
			point2D4.Y = 1.0;
		}
		point2D2 -= point2D4;
		point2D3 += point2D4;
		return new List<Point3D>
		{
			plane.PointAt(point2D2),
			plane.PointAt(new Point2D(point2D3.X, point2D2.Y)),
			plane.PointAt(point2D3),
			plane.PointAt(new Point2D(point2D2.X, point2D3.Y)),
			plane.PointAt(point2D2)
		};
	}

	public static void ResetBBox(out Point3D min, out Point3D max)
	{
		min = Point3D.Origin;
		max = new Point3D(1.0, 1.0, 1.0);
	}

	public static bool lessOrEqualCurveSurfaceIntersection(double a, double b, double domainSize)
	{
		if (!(a < b))
		{
			return Math.Abs(b - a) / domainSize < 1E-06;
		}
		return true;
	}

	public static Point2D HermiteSpline(Point2D p0, Vector2D m0, Point2D p1, Vector2D m1, double t)
	{
		return (2.0 * t * t * t - 3.0 * t * t + 1.0) * p0 + (t * t * t - 2.0 * t * t + t) * m0 + (-2.0 * t * t * t + 3.0 * t * t) * p1 + (t * t * t - t * t) * m1;
	}

	public static void GetSliceVerticesAndNormals(int sliceIndex, double radius, int slices, Point3D start, Point3D end, Point3D[] verts, out Point3D v0, out Point3D v1, out Point3D v2, out Point3D v3, out Vector3D n0, out Vector3D n1, out Vector3D n2, out Vector3D n3)
	{
		v0 = verts[sliceIndex + slices];
		v1 = verts[sliceIndex];
		v2 = ((sliceIndex + 1 + slices < slices * 2) ? verts[sliceIndex + 1 + slices] : verts[slices]);
		v3 = ((sliceIndex + 1 < slices) ? verts[sliceIndex + 1] : verts[0]);
		n0 = new Vector3D((v0.X - end.X) / radius, (v0.Y - end.Y) / radius, (v0.Z - end.Z) / radius);
		n1 = new Vector3D((v1.X - start.X) / radius, (v1.Y - start.Y) / radius, (v1.Z - start.Z) / radius);
		n2 = new Vector3D((v2.X - end.X) / radius, (v2.Y - end.Y) / radius, (v2.Z - end.Z) / radius);
		n3 = new Vector3D((v3.X - start.X) / radius, (v3.Y - start.Y) / radius, (v3.Z - start.Z) / radius);
	}

	public static bool InvalidOGLPoint(Point3D pt)
	{
		if (!(pt.X < -3.4028234663852886E+38) && !(pt.Y < -3.4028234663852886E+38) && !(pt.Z < -3.4028234663852886E+38) && !(pt.X > 3.4028234663852886E+38) && !(pt.Y > 3.4028234663852886E+38))
		{
			return pt.Z > 3.4028234663852886E+38;
		}
		return true;
	}

	public static bool IsOrientedClockwise<T>(IList<T> polygon) where T : Point2D
	{
		return PolygonArea(polygon) < 0.0;
	}

	public static double PolygonOrientation<T>(IList<T> polygon) where T : Point2D
	{
		int num = polygon.Count - 1;
		int num2 = 0;
		T val = polygon[0];
		double x = val.X;
		double y = val.Y;
		for (int i = 1; i < num; i++)
		{
			val = polygon[i];
			if (!(val.Y > y) && (val.Y != y || !(val.X < x)))
			{
				num2 = i;
				x = val.X;
				y = val.Y;
			}
		}
		if (num2 == 0)
		{
			return _0023_003DzbOJOtU0_003D(polygon[num - 1], polygon[0], polygon[1]);
		}
		return _0023_003DzbOJOtU0_003D(polygon[num2 - 1], polygon[num2], polygon[num2 + 1]);
	}

	private static double _0023_003DzbOJOtU0_003D<T>(T _0023_003DzapZc0IQ_003D, T _0023_003DzZFWF0AM_003D, T _0023_003Dz_fdaZUE_003D) where T : Point2D
	{
		return (_0023_003DzZFWF0AM_003D.X - _0023_003DzapZc0IQ_003D.X) * (_0023_003Dz_fdaZUE_003D.Y - _0023_003DzapZc0IQ_003D.Y) - (_0023_003Dz_fdaZUE_003D.X - _0023_003DzapZc0IQ_003D.X) * (_0023_003DzZFWF0AM_003D.Y - _0023_003DzapZc0IQ_003D.Y);
	}

	public static void CheckDir<T>(IList<T> outerPoints, IList<IList<T>> innerPoints) where T : Point2D
	{
		if (IsOrientedClockwise(outerPoints))
		{
			ReverseArray(outerPoints);
		}
		if (innerPoints == null)
		{
			return;
		}
		for (int i = 0; i < innerPoints.Count; i++)
		{
			IList<T> list = innerPoints[i];
			if (list != null)
			{
				if (!IsOrientedClockwise(list))
				{
					ReverseArray(list);
				}
				continue;
			}
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662461), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662411));
		}
	}

	public static Plane GetContourPlane(IList<Point3D> outer)
	{
		if (outer == null)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653251), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662654));
		}
		Plane plane = FitPlane(outer);
		Point2D[] array = new Point2D[outer.Count];
		for (int i = 0; i < outer.Count; i++)
		{
			array[i] = plane.Project(outer[i]);
		}
		if (IsOrientedClockwise(array))
		{
			plane.Flip();
		}
		return plane;
	}

	public static bool GetCutPlane(Vector3D vect1, Vector3D vect2, Point3D origin, bool invertSide, out Plane plane, out Vector3D rotAxis)
	{
		plane = null;
		double angleInRadians = Vector3D.AngleBetween(vect1, vect2) / 2.0 - Math.PI / 2.0;
		rotAxis = Vector3D.Cross(vect2, vect1);
		if (Vector3D.AreCoincident(vect1, vect2, 1E-06))
		{
			rotAxis = null;
			return false;
		}
		Transformation transformation = new Transformation();
		transformation.Rotation(angleInRadians, rotAxis);
		Point3D point3D = new Point3D(vect2.ToArray());
		point3D = transformation * point3D;
		Vector3D vector3D = Vector3D.Cross(rotAxis, new Vector3D(point3D.ToArray()));
		if (!vector3D.Normalize())
		{
			rotAxis = null;
			return false;
		}
		plane = new Plane(origin, vector3D);
		if (invertSide)
		{
			plane.Flip();
		}
		return true;
	}

	public static void Rotate<T>(IList<T> list, int k)
	{
		_0023_003DzdK0ygWN7LNhApRmmGzJ5bl0_003D<T> _0023_003DzTnHGwq4_003D = default(_0023_003DzdK0ygWN7LNhApRmmGzJ5bl0_003D<T>);
		_0023_003DzTnHGwq4_003D._0023_003DzcDEsV8s_003D = list;
		int count = _0023_003DzTnHGwq4_003D._0023_003DzcDEsV8s_003D.Count;
		if (count >= 2)
		{
			k %= count;
			if (k < 0)
			{
				k += count;
			}
			if (k != 0)
			{
				_0023_003Dq4bDZkS0myc5_KN6nHHXjdJu4V_0024XyFWh1zjCk_Fygi9E_003D(0, count - 1, ref _0023_003DzTnHGwq4_003D);
				_0023_003Dq4bDZkS0myc5_KN6nHHXjdJu4V_0024XyFWh1zjCk_Fygi9E_003D(0, k - 1, ref _0023_003DzTnHGwq4_003D);
				_0023_003Dq4bDZkS0myc5_KN6nHHXjdJu4V_0024XyFWh1zjCk_Fygi9E_003D(k, count - 1, ref _0023_003DzTnHGwq4_003D);
			}
		}
	}

	public static void RotateLeft<T>(IList<T> list, int k = 1)
	{
		Rotate(list, -Math.Abs(k));
	}

	public static void RotateRight<T>(IList<T> list, int k = 1)
	{
		Rotate(list, Math.Abs(k));
	}

	public static void GetRotationAxisAndAngle(Vector3D vector1, Vector3D vector2, out Vector3D rotAxis, out double angleInDegrees)
	{
		rotAxis = Vector3D.Cross(vector1, vector2);
		if (rotAxis.Length <= _0023_003DzheSR8QM7q9ya)
		{
			rotAxis = null;
			angleInDegrees = 0.0;
			return;
		}
		rotAxis.Normalize();
		((Vector3D)vector1.Clone()).Normalize();
		((Vector3D)vector2.Clone()).Normalize();
		if (Math.Abs(Vector3D.Dot(vector1, vector2) + 1.0) <= _0023_003DzheSR8QM7q9ya)
		{
			angleInDegrees = 180.0;
		}
		else if (rotAxis.Length < _0023_003DzheSR8QM7q9ya)
		{
			angleInDegrees = 0.0;
		}
		else
		{
			angleInDegrees = VectorsAngle(vector1, vector2, rotAxis);
		}
	}

	public static bool AreEqual(IList first, IList second)
	{
		if (first == null || second == null)
		{
			return false;
		}
		if (first.Count != second.Count)
		{
			return false;
		}
		for (int i = 0; i < first.Count; i++)
		{
			if (first[i] != second[i])
			{
				return false;
			}
		}
		return first == second;
	}

	public static bool AreArraysEqualElementWise(double[] a, double[] b, double epsilon = 1E-12)
	{
		if (a == null || b == null)
		{
			return false;
		}
		if (a.Length != b.Length)
		{
			return false;
		}
		for (int i = 0; i < a.Length; i++)
		{
			if (Math.Abs(a[i] - b[i]) > epsilon)
			{
				return false;
			}
		}
		return true;
	}

	public static bool AreEqual2D(double[] p1, double[] p2, double domainSize)
	{
		return _0023_003DzOxKU6GM_003D(p1, p2) / domainSize < 1E-09;
	}

	private static double _0023_003DzOxKU6GM_003D(double[] _0023_003DzFj_0024IqDQ_003D, double[] _0023_003DzjdeMMkk_003D)
	{
		double num = _0023_003DzFj_0024IqDQ_003D[0] - _0023_003DzjdeMMkk_003D[0];
		double num2 = _0023_003DzFj_0024IqDQ_003D[1] - _0023_003DzjdeMMkk_003D[1];
		return Math.Sqrt(num * num + num2 * num2);
	}

	public static int Intersect3DLines(Point3D p0, Vector3D t0, Point3D p1, Vector3D t1, out double s, out double t, out Point3D i)
	{
		double num = t0 * t0;
		double num2 = t0 * t1;
		double num3 = t1 * t1;
		double num4 = num * num3 - num2 * num2;
		if (Math.Abs(num4) <= 2.220446049250313E-16 * num)
		{
			s = 0.0;
			t = 0.0;
			i = null;
			return 1;
		}
		Vector3D vector3D = Vector3D.Subtract(p1, p0);
		double num5 = t0 * vector3D;
		double num6 = 0.0 - t1 * vector3D;
		s = (num5 * num3 + num6 * num2) / num4;
		t = (num5 * num2 + num6 * num) / num4;
		i = p0 + s * t0;
		return 0;
	}

	public static double ArcTanProblem(double x, double y)
	{
		double num = ((x != 0.0) ? Math.Atan(y / x) : ((!(y > 0.0)) ? 4.71238898038469 : (Math.PI / 2.0)));
		if (x < 0.0)
		{
			num += Math.PI;
		}
		if (x > 0.0 && y < 0.0)
		{
			num += Math.PI * 2.0;
		}
		return num;
	}

	public static int Compact(IList<Point3D> original, IList<IndexTriangle> triangles, out Point3D[] compacted)
	{
		int count = original.Count;
		int count2 = triangles.Count;
		int num = 0;
		bool[] array = new bool[count];
		for (int i = 0; i < count2; i++)
		{
			if (!array[triangles[i].V1])
			{
				array[triangles[i].V1] = true;
				num++;
			}
			if (!array[triangles[i].V2])
			{
				array[triangles[i].V2] = true;
				num++;
			}
			if (!array[triangles[i].V3])
			{
				array[triangles[i].V3] = true;
				num++;
			}
		}
		int[] array2 = new int[count];
		int num2 = 0;
		for (int j = 0; j < count; j++)
		{
			if (array[j])
			{
				array2[j] = num2;
				num2++;
			}
			else
			{
				array2[j] = -1;
			}
		}
		compacted = new Point3D[num];
		for (int k = 0; k < count2; k++)
		{
			IndexTriangle indexTriangle = (IndexTriangle)triangles[k].Clone();
			indexTriangle.V1 = array2[indexTriangle.V1];
			indexTriangle.V2 = array2[indexTriangle.V2];
			indexTriangle.V3 = array2[indexTriangle.V3];
			triangles[k] = indexTriangle;
		}
		num2 = 0;
		for (int l = 0; l < count; l++)
		{
			if (array[l])
			{
				compacted[num2] = (Point3D)original[l].Clone();
				num2++;
			}
		}
		return count - compacted.Length;
	}

	public static int CompactNormals(IList<Vector3D> original, IList<IndexTriangle> triangles, out Vector3D[] compacted)
	{
		int count = original.Count;
		int count2 = triangles.Count;
		int num = 0;
		bool[] array = new bool[count];
		for (int i = 0; i < count2; i++)
		{
			if (!array[((SmoothTriangle)triangles[i]).N1])
			{
				array[((SmoothTriangle)triangles[i]).N1] = true;
				num++;
			}
			if (!array[((SmoothTriangle)triangles[i]).N2])
			{
				array[((SmoothTriangle)triangles[i]).N2] = true;
				num++;
			}
			if (!array[((SmoothTriangle)triangles[i]).N3])
			{
				array[((SmoothTriangle)triangles[i]).N3] = true;
				num++;
			}
		}
		int[] array2 = new int[count];
		int num2 = 0;
		for (int j = 0; j < count; j++)
		{
			if (array[j])
			{
				array2[j] = num2;
				num2++;
			}
			else
			{
				array2[j] = -1;
			}
		}
		compacted = new Vector3D[num];
		for (int k = 0; k < count2; k++)
		{
			SmoothTriangle smoothTriangle = (SmoothTriangle)triangles[k].Clone();
			smoothTriangle.N1 = array2[smoothTriangle.N1];
			smoothTriangle.N2 = array2[smoothTriangle.N2];
			smoothTriangle.N3 = array2[smoothTriangle.N3];
			triangles[k] = smoothTriangle;
		}
		num2 = 0;
		for (int l = 0; l < count; l++)
		{
			if (array[l])
			{
				compacted[num2] = (Vector3D)original[l].Clone();
				num2++;
			}
		}
		return count - compacted.Length;
	}

	public static int GetProgress(int[] index, int[] startIndex, int cpuCount)
	{
		int num = 0;
		for (int i = 0; i < cpuCount; i++)
		{
			num += index[i] - startIndex[i];
		}
		if (num < 0)
		{
			return 0;
		}
		return num;
	}

	public static double KahanSum(double[] input)
	{
		double num = 0.0;
		double num2 = 0.0;
		for (int i = 0; i < input.Length; i++)
		{
			double num3 = input[i] - num2;
			double num4 = num + num3;
			num2 = num4 - num - num3;
			num = num4;
		}
		return num;
	}

	public static double DoubleParseIges(string value)
	{
		value = value.TrimEnd('.');
		return double.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
	}

	public static double DoubleParse(string value)
	{
		return double.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
	}

	public static float FloatParse(string value)
	{
		return float.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
	}

	public static bool DoubleTryParse(string value, out double result)
	{
		return double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out result);
	}

	public static supportedLinearUnitsType GetSupportedLinearUnits(linearUnitsType units)
	{
		if (units == linearUnitsType.NotSupported)
		{
			return supportedLinearUnitsType.Unitless;
		}
		string name = Enum.GetName(typeof(linearUnitsType), units);
		if (string.IsNullOrEmpty(name))
		{
			return supportedLinearUnitsType.Unitless;
		}
		return (supportedLinearUnitsType)Enum.Parse(typeof(supportedLinearUnitsType), name);
	}

	public static double GetLinearUnitsConversionFactor(linearUnitsType fromUnits, linearUnitsType toUnits)
	{
		if (fromUnits == toUnits || fromUnits == linearUnitsType.Unitless || fromUnits == linearUnitsType.NotSupported || toUnits == linearUnitsType.Unitless || toUnits == linearUnitsType.NotSupported)
		{
			return 1.0;
		}
		Tuple<linearUnitsType, linearUnitsType> key = new Tuple<linearUnitsType, linearUnitsType>(fromUnits, toUnits);
		return LinearConversionFactors[key];
	}

	public static supportedMassUnitsType GetSupportedMassUnits(massUnitsType units)
	{
		if (units == massUnitsType.NotSupported)
		{
			return supportedMassUnitsType.Unitless;
		}
		string name = Enum.GetName(typeof(massUnitsType), units);
		if (string.IsNullOrEmpty(name))
		{
			return supportedMassUnitsType.Unitless;
		}
		return (supportedMassUnitsType)Enum.Parse(typeof(supportedMassUnitsType), name);
	}

	public static double GetMassUnitsConversionFactor(massUnitsType fromUnits, massUnitsType toUnits)
	{
		if (fromUnits == toUnits || fromUnits == massUnitsType.Unitless || fromUnits == massUnitsType.NotSupported || toUnits == massUnitsType.Unitless || toUnits == massUnitsType.NotSupported)
		{
			return 1.0;
		}
		Tuple<massUnitsType, massUnitsType> key = new Tuple<massUnitsType, massUnitsType>(fromUnits, toUnits);
		return MassConversionFactors[key];
	}

	public static T[] Simplify<T>(IList<T> points, double deviation) where T : Point2D
	{
		return _0023_003DzZlAQUGJJhD__0024nMvKbmeh3fWL6xfuDQ7NrtumyRo_003D._0023_003Dz_IsqsVA_003D(points, deviation);
	}

	public static bool Intersection2D(Point3D[] chain, Segment2D segment, bool tIntersections)
	{
		for (int i = 0; i < chain.Length - 1; i++)
		{
			Segment2D s = new Segment2D(chain[i], chain[i + 1]);
			if (tIntersections ? Segment2D.IntersectionAndT(s, segment, out var i2) : Segment2D.Intersection(s, segment, out i2))
			{
				return true;
			}
		}
		return false;
	}

	public static bool Intersection2D(Point3D[] chainA, Point3D[] chainB, bool tIntersections = true)
	{
		for (int i = 0; i < chainA.Length - 1; i++)
		{
			Segment2D segment = new Segment2D(chainA[i], chainA[i + 1]);
			if (Intersection2D(chainB, segment, tIntersections))
			{
				return true;
			}
		}
		return false;
	}

	internal static Interval _0023_003DzHNhzuamBoympuHB_8w_003D_003D(Point3D _0023_003DzeoY7iyo_003D, Vector3D _0023_003DzY5pSLwI_003D, IList<ICurve> _0023_003DzRTbTK_0024KwG32W)
	{
		Interval result = new Interval(double.MaxValue, double.MinValue);
		Segment3D segment3D = new Segment3D(_0023_003DzeoY7iyo_003D, _0023_003DzeoY7iyo_003D + _0023_003DzY5pSLwI_003D);
		foreach (ICurve item in _0023_003DzRTbTK_0024KwG32W)
		{
			ICurve[] individualCurves = item.GetIndividualCurves();
			for (int i = 0; i < individualCurves.Length; i++)
			{
				Curve nurbsForm = individualCurves[i].GetNurbsForm();
				int num = nurbsForm._0023_003DzMv2C5Tm1QMvc();
				for (int j = 0; j < num; j++)
				{
					Point3D euclid = nurbsForm.ControlPoints[j].Euclid;
					double num2 = segment3D.Project(euclid);
					if (num2 < result.t0)
					{
						result.t0 = num2;
					}
					if (num2 > result.t1)
					{
						result.t1 = num2;
					}
				}
			}
		}
		return result;
	}

	internal static IndexTriangle _0023_003DzyKFFQjQrTYin(Tria3 _0023_003DzNDQ_E88_003D)
	{
		return new IndexTriangle(_0023_003DzNDQ_E88_003D.Connection[0], _0023_003DzNDQ_E88_003D.Connection[1], _0023_003DzNDQ_E88_003D.Connection[2]);
	}

	internal static IndexTriangle _0023_003DzyKFFQjQrTYin(Tria6 _0023_003DzNDQ_E88_003D)
	{
		return new IndexTriangle(_0023_003DzNDQ_E88_003D.Connection[0], _0023_003DzNDQ_E88_003D.Connection[2], _0023_003DzNDQ_E88_003D.Connection[4]);
	}

	internal static void _0023_003DzpgkCu6_h3HLE(Plane _0023_003Dzk5BbLuzKcKNK_ipsuA_003D_003D, Line _0023_003DzQ9zpGF0_003D, out Plane _0023_003Dzrgqz890sj_0024X9)
	{
		Vector3D vector3D = _0023_003DzQ9zpGF0_003D.Tangent;
		if (_0023_003DzMJl6kdmQQxAU(_0023_003Dzk5BbLuzKcKNK_ipsuA_003D_003D, _0023_003DzQ9zpGF0_003D))
		{
			vector3D = -1.0 * _0023_003DzQ9zpGF0_003D.Tangent;
		}
		Vector3D y = Vector3D.Cross(_0023_003Dzk5BbLuzKcKNK_ipsuA_003D_003D.AxisZ, vector3D);
		Point3D startPoint = _0023_003DzQ9zpGF0_003D.StartPoint;
		_0023_003Dzrgqz890sj_0024X9 = new Plane(startPoint, vector3D, y);
	}

	internal static bool _0023_003DzMJl6kdmQQxAU(Plane _0023_003Dzk5BbLuzKcKNK_ipsuA_003D_003D, Line _0023_003DzQ9zpGF0_003D)
	{
		Vector2D v = new Vector2D(_0023_003Dzk5BbLuzKcKNK_ipsuA_003D_003D.Project(_0023_003DzQ9zpGF0_003D.StartPoint), _0023_003Dzk5BbLuzKcKNK_ipsuA_003D_003D.Project(_0023_003DzQ9zpGF0_003D.EndPoint));
		double num = Vector2D.SignedAngleBetween(Vector2D.AxisX, v);
		if (num < 0.0)
		{
			num += Math.PI * 2.0;
		}
		if (Compare(num, _0023_003DzSNemwQo_003D / 2.0) != 0 && num > _0023_003DzSNemwQo_003D / 2.0 && num <= _0023_003DzSNemwQo_003D * 3.0 / 2.0)
		{
			return true;
		}
		return false;
	}

	public static bool Trim(IDesign design, System.Drawing.Point mouseLocation, out List<Entity> leftOverEntities, Plane plane = null)
	{
		leftOverEntities = new List<Entity>();
		List<Entity> _0023_003DzcM_Q3U04H3Bt = new List<Entity>();
		return new _0023_003Dz_p2RXz7Ce_dbmSFJ520GhUDSB4eGuCW_0024cBERiyU_003D(design, plane ?? Plane.XY, _0023_003DzqNH2rCw_003D: false)._0023_003Dz6PsRlFc_003D(mouseLocation, leftOverEntities, _0023_003DzcM_Q3U04H3Bt);
	}

	public static bool TrimPreview(IDesign design, System.Drawing.Point mouseLocation, out List<Entity> previewEntities, Plane plane = null)
	{
		List<Entity> _0023_003DzijSR7_0024YYLNcm = new List<Entity>();
		previewEntities = new List<Entity>();
		return new _0023_003Dz_p2RXz7Ce_dbmSFJ520GhUDSB4eGuCW_0024cBERiyU_003D(design, plane ?? Plane.XY, _0023_003DzqNH2rCw_003D: true)._0023_003Dz6PsRlFc_003D(mouseLocation, _0023_003DzijSR7_0024YYLNcm, previewEntities);
	}

	public static string GetUnitsAbbreviation(linearUnitsType unitType)
	{
		if (_0023_003DzVRB9mmcxMVKlbDTCC5ToBgU_003D.ContainsKey(unitType))
		{
			return _0023_003DzVRB9mmcxMVKlbDTCC5ToBgU_003D[unitType];
		}
		throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662638), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662600));
	}

	public static Vector3D Slerp(Vector3D a, Vector3D b, double t)
	{
		double num = Clamp(-1.0, Vector3D.Dot(a, b), 1.0);
		if (num > 0.9995)
		{
			Vector3D vector3D = a + (b - a) * t;
			vector3D.Normalize();
			return vector3D;
		}
		float num2 = (float)Math.Acos(num);
		float num3 = (float)Math.Sin(num2);
		float num4 = (float)Math.Sin((1.0 - t) * (double)num2) / num3;
		float num5 = (float)Math.Sin(t * (double)num2) / num3;
		return a * num4 + b * num5;
	}

	internal static bool _0023_003Dzv9BlzJBJ8Je9MrLd9w_003D_003D(Tuple<Stack<BlockReference>, Entity> _0023_003DzmdyIrQQUDpKM, List<Tuple<Stack<BlockReference>, Entity>> _0023_003Dz0KtzIE4moinE)
	{
		foreach (Tuple<Stack<BlockReference>, Entity> item in _0023_003Dz0KtzIE4moinE)
		{
			if (_0023_003DzmdyIrQQUDpKM.Item2 == item.Item2 && SelectedItemBase._0023_003DzPglMnmnGOjfR(_0023_003DzmdyIrQQUDpKM.Item1, item.Item1))
			{
				return true;
			}
		}
		return false;
	}

	internal static Stack<T> CloneStack<T>(Stack<T> _0023_003Dz4wZe_0024Xg_003D)
	{
		T[] array = new T[_0023_003Dz4wZe_0024Xg_003D.Count];
		_0023_003Dz4wZe_0024Xg_003D.CopyTo(array, 0);
		Array.Reverse(array);
		return new Stack<T>(array);
	}

	public static Table CreateBOMTable(EntityList entites, BlockKeyedCollection blocks, string itemNumberText, string partNumberText, string descriptionText, string quantityText, bool partsOnly = true, Table.flowDirection flowDirection = Table.flowDirection.Down, int maxLevel = int.MaxValue)
	{
		DataTable dataTable = CreateBillOfMaterials(entites, blocks, partsOnly, maxLevel);
		int count = dataTable.Rows.Count;
		double[] array = new double[count + 1];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = 6.0;
		}
		double[] columnsWidths = new double[4] { 8.0, 40.0, 100.0, 12.0 };
		Table table = new Table(Plane.XY, count + 1, 4, array, columnsWidths, 2.0, flowDirection);
		table.LineWeight = 0.1f;
		table.LineWeightMethod = colorMethodType.byEntity;
		int row = 0;
		table.SetTextString(row, 0, itemNumberText);
		table.SetTextString(row, 1, partNumberText);
		table.SetTextString(row, 2, descriptionText);
		table.SetTextString(row, 3, quantityText);
		table.HorCellMargin = 1.0;
		int num = 1;
		foreach (DataRow row2 in dataTable.Rows)
		{
			table.SetAlignment(num, 0, Text.alignmentType.MiddleRight);
			table.SetTextString(num, 0, row2[0].ToString());
			table.SetAlignment(num, 1, Text.alignmentType.MiddleLeft);
			table.SetTextString(num, 1, row2[1].ToString());
			table.SetAlignment(num, 2, Text.alignmentType.MiddleLeft);
			table.SetTextString(num, 2, row2[2].ToString());
			table.SetAlignment(num, 3, Text.alignmentType.MiddleRight);
			table.SetTextString(num, 3, row2[3].ToString());
			num++;
		}
		return table;
	}

	public static DataTable CreateBillOfMaterials(EntityList entities, BlockKeyedCollection blocks, bool partsOnly, int maxLevel = int.MaxValue)
	{
		IEnumerable<IGrouping<string, string>> enumerable = _0023_003DzjSu_vL5TcU1X(entities, blocks, blocks.RootBlockName, partsOnly, 0, maxLevel).GroupBy(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz0T_kUDYnzW155NEfsFQYQ5EfrMVwJ8398KyB1oc_003D);
		enumerable.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzSqXCkykihdYF9L_PT82fn7kt50sVs54ggAQcmZs_003D).Distinct().Count();
		DataTable dataTable = _0023_003DzPCrKWtxGrF7m();
		int num = 1;
		foreach (IGrouping<string, string> item in enumerable)
		{
			dataTable.Rows.Add(num, item.Key, blocks[item.Key].Description, item.Count());
			num++;
		}
		return dataTable;
	}

	private static string[] _0023_003DzjSu_vL5TcU1X(IList<Entity> _0023_003DzWc9WmS8VMsuA, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, string _0023_003DzS_00246o7tc_003D, bool _0023_003DzZBBBqsJx2PyB, int _0023_003DzfNi7d4A_003D, int _0023_003DzY8qwWXazwYMh)
	{
		List<string> list = new List<string>();
		if (_0023_003DzfNi7d4A_003D > _0023_003DzY8qwWXazwYMh)
		{
			return list.ToArray();
		}
		bool flag = false;
		foreach (Entity item in _0023_003DzWc9WmS8VMsuA)
		{
			if (item is BlockReference)
			{
				string blockName = ((BlockReference)item).BlockName;
				string[] collection = _0023_003DzjSu_vL5TcU1X(_0023_003DzJO1FWlQ_003D[blockName].Entities, _0023_003DzJO1FWlQ_003D, blockName, _0023_003DzZBBBqsJx2PyB, _0023_003DzfNi7d4A_003D + 1, _0023_003DzY8qwWXazwYMh);
				list.AddRange(collection);
			}
			else if (!flag)
			{
				list.Add(_0023_003DzS_00246o7tc_003D);
				flag = true;
			}
		}
		if (!_0023_003DzZBBBqsJx2PyB && !flag)
		{
			list.Add(_0023_003DzS_00246o7tc_003D);
		}
		return list.ToArray();
	}

	private static DataTable _0023_003DzPCrKWtxGrF7m()
	{
		return new DataTable
		{
			Columns = 
			{
				{
					_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302778217),
					typeof(int)
				},
				{
					_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662577),
					typeof(string)
				},
				{
					_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951019),
					typeof(string)
				},
				{
					_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302785199),
					typeof(int)
				}
			}
		};
	}

	internal static double _0023_003DzaWhFDDP5nQ_0024L(Material _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D, string _0023_003DzuWgZRyi3USzkvBZPBQ_003D_003D, massUnitsType _0023_003DzyxvbkJ1lwtnX, linearUnitsType _0023_003Dzvp5BWhkuLaXusIAeJw_003D_003D, double _0023_003DzhKcriekaIolc, out double _0023_003DzCtrz4DvviN6U)
	{
		double num;
		double linearUnitsConversionFactor;
		if (_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D == null)
		{
			num = 1.0;
			_0023_003DzCtrz4DvviN6U = num * GetMassUnitsConversionFactor(massUnitsType.Kilograms, _0023_003DzyxvbkJ1lwtnX);
			linearUnitsConversionFactor = GetLinearUnitsConversionFactor(linearUnitsType.Meters, _0023_003Dzvp5BWhkuLaXusIAeJw_003D_003D);
			_0023_003DzCtrz4DvviN6U /= linearUnitsConversionFactor * linearUnitsConversionFactor * linearUnitsConversionFactor;
			return _0023_003DzhKcriekaIolc * _0023_003DzCtrz4DvviN6U;
		}
		num = _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.Density;
		_0023_003DzCtrz4DvviN6U = num * GetMassUnitsConversionFactor(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.MassUnits, _0023_003DzyxvbkJ1lwtnX);
		linearUnitsConversionFactor = GetLinearUnitsConversionFactor(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.LinearUnits, _0023_003Dzvp5BWhkuLaXusIAeJw_003D_003D);
		_0023_003DzCtrz4DvviN6U /= linearUnitsConversionFactor * linearUnitsConversionFactor * linearUnitsConversionFactor;
		return _0023_003DzhKcriekaIolc * _0023_003DzCtrz4DvviN6U;
	}

	internal static void RestoreClippingPlanesStatus(ClippingPlaneBase[] _0023_003Dz6UteXW4OjphV_00246VeOw_003D_003D, RenderContextBase _0023_003DzQdnFby4_003D, bool[] _0023_003DzR_0024c5epA_003D)
	{
		for (int i = 0; i < _0023_003Dz6UteXW4OjphV_00246VeOw_003D_003D.Length; i++)
		{
			_0023_003Dz6UteXW4OjphV_00246VeOw_003D_003D[i].Active = _0023_003DzR_0024c5epA_003D[i];
		}
		_0023_003DzQdnFby4_003D.ProcessClippingPlanesVisibility(_0023_003Dz6UteXW4OjphV_00246VeOw_003D_003D, updateGraphics: true);
	}

	internal static bool[] TurnOffClippingPlanes(ClippingPlaneBase[] _0023_003Dz6UteXW4OjphV_00246VeOw_003D_003D, RenderContextBase _0023_003DzQdnFby4_003D, int _0023_003Dzlf_0024vRN4_003D = -1)
	{
		bool[] array = new bool[_0023_003Dz6UteXW4OjphV_00246VeOw_003D_003D.Length];
		for (int i = 0; i < _0023_003Dz6UteXW4OjphV_00246VeOw_003D_003D.Length; i++)
		{
			array[i] = _0023_003Dz6UteXW4OjphV_00246VeOw_003D_003D[i].Active;
			if (i != _0023_003Dzlf_0024vRN4_003D)
			{
				_0023_003Dz6UteXW4OjphV_00246VeOw_003D_003D[i].Active = false;
			}
		}
		_0023_003DzQdnFby4_003D.ProcessClippingPlanesVisibility(_0023_003Dz6UteXW4OjphV_00246VeOw_003D_003D, updateGraphics: true);
		return array;
	}

	public static ICurve SmartAdd(IList<ICurve> curveList, bool sortAndOrient = false)
	{
		if (curveList.Count == 0)
		{
			return null;
		}
		if (curveList.Count > 1)
		{
			return new CompositeCurve(curveList, sortAndOrient);
		}
		return curveList[0];
	}

	internal static void _0023_003Dzyx35VoBSR6flPmM7uA_003D_003D(IList<Point3D> _0023_003DzcDEsV8s_003D, out float[] _0023_003DzTbDlaOM_003D)
	{
		_0023_003DzTbDlaOM_003D = new float[_0023_003DzcDEsV8s_003D.Count * 3];
		int num = 0;
		for (int i = 0; i < _0023_003DzcDEsV8s_003D.Count; i++)
		{
			_0023_003DzTbDlaOM_003D[num++] = (float)_0023_003DzcDEsV8s_003D[i].X;
			_0023_003DzTbDlaOM_003D[num++] = (float)_0023_003DzcDEsV8s_003D[i].Y;
			_0023_003DzTbDlaOM_003D[num++] = (float)_0023_003DzcDEsV8s_003D[i].Z;
		}
	}

	internal static void _0023_003Dz7Vctk9GuN7ugAAgu_0024Q_003D_003D(float[] _0023_003DzTbDlaOM_003D, out Point3D[] _0023_003DzcDEsV8s_003D)
	{
		_0023_003DzcDEsV8s_003D = new Point3D[_0023_003DzTbDlaOM_003D.Length / 3];
		int num = 0;
		int num2 = 0;
		while (num2 < _0023_003DzTbDlaOM_003D.Length)
		{
			_0023_003DzcDEsV8s_003D[num++] = new Point3D(_0023_003DzTbDlaOM_003D[num2++], _0023_003DzTbDlaOM_003D[num2++], _0023_003DzTbDlaOM_003D[num2++]);
		}
	}

	public static bool CheckDataIntegrity(out string log, out Dictionary<string, Dictionary<object, HashSet<string>>> sharedItems)
	{
		return _0023_003Dz3YQjB2juoMUx(out log, out sharedItems);
	}

	internal static bool _0023_003Dz3YQjB2juoMUx(out string _0023_003DzqmF8XJ0_003D, out Dictionary<string, Dictionary<object, HashSet<string>>> _0023_003Dz7pkmDFZlhF_0024X)
	{
		_0023_003DzqmF8XJ0_003D = string.Empty;
		_0023_003Dz7pkmDFZlhF_0024X = new Dictionary<string, Dictionary<object, HashSet<string>>>();
		if (RuntimeInstances.Count < 2)
		{
			return true;
		}
		bool flag = true;
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < RuntimeInstances.Count - 1; i++)
		{
			if (!RuntimeInstances.ElementAt(i).TryGetTarget(out var target))
			{
				continue;
			}
			for (int j = i + 1; j < RuntimeInstances.Count; j++)
			{
				if (RuntimeInstances.ElementAt(j).TryGetTarget(out var target2))
				{
					flag &= _0023_003Dzu5__T5C9p6eU(target, target2, _0023_003Dz7pkmDFZlhF_0024X);
				}
			}
		}
		_0023_003Dz7pkmDFZlhF_0024X = _0023_003Dz7pkmDFZlhF_0024X.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzeGxrj99VaE6JgjklQEhp6jqWF0IA).ToDictionary(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzW1SsZ1fHrh3G5GqSBbZaiSqzLAOs, (KeyValuePair<string, Dictionary<object, HashSet<string>>> _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D.Value);
		foreach (KeyValuePair<string, Dictionary<object, HashSet<string>>> item in _0023_003Dz7pkmDFZlhF_0024X)
		{
			string key = item.Key;
			stringBuilder.AppendLine(key);
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302955247));
			foreach (KeyValuePair<object, HashSet<string>> item2 in item.Value)
			{
				string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302901990);
				object key2 = item2.Key;
				if (!(key == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654600)))
				{
					if (!(key == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662563)))
					{
						if (!(key == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967386)))
						{
							if (!(key == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662575)))
							{
								if (!(key == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662559)))
								{
									if (key == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662544))
									{
										text = ((HatchPattern)key2).Name;
									}
									else
									{
										text = key2.GetType().Name ?? string.Empty;
										if (key2 is BlockReference || key2 is devDept.Eyeshot.Entities.Region)
										{
											text = text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + key2.ToString();
										}
									}
								}
								else
								{
									text = ((LineType)key2).Name;
								}
							}
							else
							{
								text = ((TextStyle)key2).Name;
							}
						}
						else
						{
							text = ((Material)key2).Name;
						}
					}
					else
					{
						text = ((Block)key2).Name;
					}
				}
				else
				{
					text = ((Layer)key2).Name;
				}
				stringBuilder.AppendLine(text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662241) + string.Join(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962), item2.Value));
			}
			stringBuilder.AppendLine();
		}
		_0023_003DzqmF8XJ0_003D = stringBuilder.ToString();
		return flag;
	}

	private static bool _0023_003Dzu5__T5C9p6eU(IWorkspaceInternal _0023_003DzDamRFGE_003D, IWorkspaceInternal _0023_003DzdZrgwf8_003D, Dictionary<string, Dictionary<object, HashSet<string>>> _0023_003Dz7pkmDFZlhF_0024X)
	{
		bool flag = true;
		IWorkspaceInternal workspaceInternal;
		IWorkspaceInternal workspaceInternal2;
		if (_0023_003DzDamRFGE_003D.Blocks.Count >= _0023_003DzdZrgwf8_003D.Blocks.Count)
		{
			workspaceInternal = _0023_003DzDamRFGE_003D;
			workspaceInternal2 = _0023_003DzdZrgwf8_003D;
		}
		else
		{
			workspaceInternal = _0023_003DzdZrgwf8_003D;
			workspaceInternal2 = _0023_003DzDamRFGE_003D;
		}
		string instanceId = workspaceInternal.InstanceId;
		BlockKeyedCollection blocks = workspaceInternal.Blocks;
		string instanceId2 = workspaceInternal2.InstanceId;
		BlockKeyedCollection blocks2 = workspaceInternal2.Blocks;
		flag &= _0023_003DzO5hrHqReORyw(_0023_003Dz7pkmDFZlhF_0024X, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302654600), workspaceInternal.Layers, workspaceInternal2.Layers, instanceId, instanceId2);
		flag &= _0023_003DzO5hrHqReORyw(_0023_003Dz7pkmDFZlhF_0024X, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662563), workspaceInternal.Blocks, workspaceInternal2.Blocks, instanceId, instanceId2);
		flag &= _0023_003DzO5hrHqReORyw(_0023_003Dz7pkmDFZlhF_0024X, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302967386), workspaceInternal.Materials, workspaceInternal2.Materials, instanceId, instanceId2);
		flag &= _0023_003DzO5hrHqReORyw(_0023_003Dz7pkmDFZlhF_0024X, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662575), workspaceInternal.TextStyles, workspaceInternal2.TextStyles, instanceId, instanceId2);
		flag &= _0023_003DzO5hrHqReORyw(_0023_003Dz7pkmDFZlhF_0024X, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662559), workspaceInternal.LineTypes, workspaceInternal2.LineTypes, instanceId, instanceId2);
		flag &= _0023_003DzO5hrHqReORyw(_0023_003Dz7pkmDFZlhF_0024X, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662544), workspaceInternal.HatchPatterns, workspaceInternal2.HatchPatterns, instanceId, instanceId2);
		for (int i = 0; i < blocks.Count; i++)
		{
			Block block = blocks[i];
			for (int j = i + 1; j < blocks.Count; j++)
			{
				Block block2 = blocks[j];
				flag &= _0023_003DzO5hrHqReORyw(_0023_003Dz7pkmDFZlhF_0024X, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662232), block.Entities, block2.Entities, instanceId, instanceId);
			}
			for (int k = 0; k < blocks2.Count; k++)
			{
				Block block3 = blocks2[k];
				flag &= _0023_003DzO5hrHqReORyw(_0023_003Dz7pkmDFZlhF_0024X, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662232), block.Entities, block3.Entities, instanceId, instanceId2);
				for (int l = k + 1; l < blocks2.Count; l++)
				{
					Block block4 = blocks2[l];
					flag &= _0023_003DzO5hrHqReORyw(_0023_003Dz7pkmDFZlhF_0024X, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662232), block3.Entities, block4.Entities, instanceId2, instanceId2);
				}
			}
		}
		return flag;
	}

	private static bool _0023_003DzO5hrHqReORyw<T>(Dictionary<string, Dictionary<object, HashSet<string>>> _0023_003Dz7pkmDFZlhF_0024X, string _0023_003DzEKSHIVc_003D, IEnumerable<T> _0023_003Dzj7iXCmA_003D, IEnumerable<T> _0023_003DzC6DIOE0_003D, string _0023_003DzeGoh_ruB4hyC, string _0023_003DzmPRCnNDeEMh7)
	{
		bool result = true;
		if (!_0023_003Dz7pkmDFZlhF_0024X.TryGetValue(_0023_003DzEKSHIVc_003D, out var value))
		{
			value = new Dictionary<object, HashSet<string>>();
			_0023_003Dz7pkmDFZlhF_0024X.Add(_0023_003DzEKSHIVc_003D, value);
		}
		foreach (T item in _0023_003Dzj7iXCmA_003D)
		{
			foreach (T item2 in _0023_003DzC6DIOE0_003D)
			{
				if ((object)item == (object)item2)
				{
					if (!value.TryGetValue(item, out var value2))
					{
						value2 = new HashSet<string>();
						value.Add(item, value2);
					}
					value2.Add(_0023_003DzeGoh_ruB4hyC);
					value2.Add(_0023_003DzmPRCnNDeEMh7);
					result = false;
				}
			}
		}
		return result;
	}

	internal static bool _0023_003Dz_0024yfURu187RMm(RenderContextBase _0023_003DzQdnFby4_003D, Point3D _0023_003DzMlCq3wk_003D, IList<Point2D> _0023_003DzJzj8yw_5AsNB, double[] _0023_003DzypMGqyMVO5qA, int[] _0023_003DzqDFBISpCePlj)
	{
		return _0023_003Dz_0024yfURu187RMm(_0023_003DzQdnFby4_003D, _0023_003DzMlCq3wk_003D.X, _0023_003DzMlCq3wk_003D.Y, _0023_003DzMlCq3wk_003D.Z, _0023_003DzJzj8yw_5AsNB, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj);
	}

	internal static bool _0023_003Dz_0024yfURu187RMm(RenderContextBase _0023_003DzQdnFby4_003D, double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003DzId5C3LA_003D, IList<Point2D> _0023_003DzJzj8yw_5AsNB, double[] _0023_003DzypMGqyMVO5qA, int[] _0023_003DzqDFBISpCePlj)
	{
		Camera.Project(_0023_003DzQdnFby4_003D, _0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, _0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzId5C3LA_003D, out var _0023_003Dzm3rc4SA8WtT, out var _0023_003DzOM5CofBvYOXf, out var _);
		return PointInPolygon(new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf), _0023_003DzJzj8yw_5AsNB);
	}

	internal static bool _0023_003DzinOQp4_qBUm4opZWpg_003D_003D(ICurve _0023_003Dz8fpRyMu9aKjE, Plane _0023_003Dzrgqz890sj_0024X9)
	{
		if (_0023_003Dz8fpRyMu9aKjE is Circle circle)
		{
			return !Vector3D.AreCoincident(circle.Plane.AxisZ, _0023_003Dzrgqz890sj_0024X9.AxisZ, _0023_003DzxhnLabVjXjPg);
		}
		if (_0023_003Dz8fpRyMu9aKjE is Ellipse ellipse)
		{
			return !Vector3D.AreCoincident(ellipse.Plane.AxisZ, _0023_003Dzrgqz890sj_0024X9.AxisZ, _0023_003DzxhnLabVjXjPg);
		}
		ICurve curve = _0023_003Dz8fpRyMu9aKjE;
		if (_0023_003Dzrgqz890sj_0024X9 != Plane.XY)
		{
			Align3D xform = new Align3D(_0023_003Dzrgqz890sj_0024X9, Plane.XY);
			curve = (ICurve)((Entity)_0023_003Dz8fpRyMu9aKjE).Clone();
			((Entity)curve).TransformBy(xform);
		}
		ICurve[] individualCurves = curve.GetIndividualCurves();
		double num = 0.0;
		ICurve _0023_003Dzu8kIsEk1KBOe = individualCurves.Last();
		ICurve[] array = individualCurves;
		foreach (ICurve curve2 in array)
		{
			if (curve2 is Line _0023_003DzzmfUkNI_003D)
			{
				num += _0023_003DzT2LkqYg7RoQQL5YuUY6eXuQ_003D(_0023_003DzzmfUkNI_003D, _0023_003Dzu8kIsEk1KBOe);
				_0023_003Dzu8kIsEk1KBOe = curve2;
			}
			else if (curve2 is Arc arc)
			{
				num += _0023_003DzT2LkqYg7RoQQL5YuUY6eXuQ_003D(arc, _0023_003Dzu8kIsEk1KBOe);
				num = ((!(arc.Plane.AxisZ.Z < 0.0)) ? (num + arc.AngleInRadians) : (num - arc.AngleInRadians));
				_0023_003Dzu8kIsEk1KBOe = curve2;
			}
			else if (curve2 is Circle circle2)
			{
				num += _0023_003DzT2LkqYg7RoQQL5YuUY6eXuQ_003D(circle2, _0023_003Dzu8kIsEk1KBOe);
				num = ((!(circle2.Plane.AxisZ.Z < 0.0)) ? (num + Math.PI * 2.0) : (num - Math.PI * 2.0));
				_0023_003Dzu8kIsEk1KBOe = curve2;
			}
			else if (curve2 is EllipticalArc ellipticalArc)
			{
				num += _0023_003DzT2LkqYg7RoQQL5YuUY6eXuQ_003D(ellipticalArc, _0023_003Dzu8kIsEk1KBOe);
				num = ((!(ellipticalArc.Plane.AxisZ.Z < 0.0)) ? (num + ellipticalArc.AngleInRadians) : (num - ellipticalArc.AngleInRadians));
				_0023_003Dzu8kIsEk1KBOe = curve2;
			}
			else if (curve2 is Ellipse ellipse2)
			{
				num += _0023_003DzT2LkqYg7RoQQL5YuUY6eXuQ_003D(ellipse2, _0023_003Dzu8kIsEk1KBOe);
				num = ((!(ellipse2.Plane.AxisZ.Z < 0.0)) ? (num + Math.PI * 2.0) : (num - Math.PI * 2.0));
				_0023_003Dzu8kIsEk1KBOe = curve2;
			}
			else if (curve2 is Curve curve3)
			{
				ICurve[] array2 = curve3.SplitAtDiscontinuities(speedChange: true);
				array2 = array2;
				for (int j = 0; j < array2.Length; j++)
				{
					Curve nurbsForm = array2[j].GetNurbsForm();
					num += _0023_003DzT2LkqYg7RoQQL5YuUY6eXuQ_003D(nurbsForm, _0023_003Dzu8kIsEk1KBOe);
					num += _0023_003DzQQltFRj4NiVVjV8rlw_003D_003D(nurbsForm);
					_0023_003Dzu8kIsEk1KBOe = nurbsForm;
				}
			}
		}
		return num < 0.0;
	}

	private static double _0023_003DzQQltFRj4NiVVjV8rlw_003D_003D(Curve _0023_003DzzmfUkNI_003D)
	{
		double num = 0.0;
		for (int i = 1; i < _0023_003DzzmfUkNI_003D.ControlPoints.Length - 1; i++)
		{
			Vector3D vector3D = new Vector3D(_0023_003DzzmfUkNI_003D.ControlPoints[i].Euclid.X - _0023_003DzzmfUkNI_003D.ControlPoints[i - 1].Euclid.X, _0023_003DzzmfUkNI_003D.ControlPoints[i].Euclid.Y - _0023_003DzzmfUkNI_003D.ControlPoints[i - 1].Euclid.Y, 0.0);
			Vector3D vector3D2 = new Vector3D(_0023_003DzzmfUkNI_003D.ControlPoints[i + 1].Euclid.X - _0023_003DzzmfUkNI_003D.ControlPoints[i].Euclid.X, _0023_003DzzmfUkNI_003D.ControlPoints[i + 1].Euclid.Y - _0023_003DzzmfUkNI_003D.ControlPoints[i].Euclid.Y, 0.0);
			double num2 = (double)Math.Sign(vector3D.X * vector3D2.Y - vector3D.Y * vector3D2.X) * Math.Acos(Math.Max(Math.Min((vector3D.X * vector3D2.X + vector3D.Y * vector3D2.Y) / Math.Sqrt((vector3D.X * vector3D.X + vector3D.Y * vector3D.Y) * (vector3D2.X * vector3D2.X + vector3D2.Y * vector3D2.Y)), 1.0), -1.0));
			num += num2;
		}
		return num;
	}

	private static double _0023_003DzT2LkqYg7RoQQL5YuUY6eXuQ_003D(ICurve _0023_003DzzmfUkNI_003D, ICurve _0023_003Dzu8kIsEk1KBOe)
	{
		Vector3D endTangent = _0023_003Dzu8kIsEk1KBOe.EndTangent;
		Vector3D startTangent = _0023_003DzzmfUkNI_003D.StartTangent;
		int num = Math.Sign(endTangent.X * startTangent.Y - endTangent.Y * startTangent.X);
		double num2 = endTangent * startTangent;
		if (Math.Abs(endTangent.X * startTangent.Y - endTangent.Y * startTangent.X) < 0.01 && num2 < 0.0)
		{
			endTangent = _0023_003Dzu8kIsEk1KBOe.TangentAt(_0023_003Dzu8kIsEk1KBOe.Domain.Right - 0.01 * _0023_003Dzu8kIsEk1KBOe.Domain.Length);
			startTangent = _0023_003DzzmfUkNI_003D.TangentAt(_0023_003DzzmfUkNI_003D.Domain.Left + 0.01 * _0023_003DzzmfUkNI_003D.Domain.Length);
			num = Math.Sign(endTangent.X * startTangent.Y - endTangent.Y * startTangent.X);
		}
		return (double)num * Math.Acos(Math.Max(Math.Min(num2, 1.0), -1.0));
	}

	[IteratorStateMachine(typeof(_0023_003DzW0vVMDai_00241WamJy166LzGtYXxAOH))]
	internal static IEnumerable<string> _0023_003DzZPEv7WT7EohsW_mPuw_003D_003D(string _0023_003Dz0EsKsC8_003D, string _0023_003DzAqOpw0w_003D, string _0023_003Dzk64JNOo_003D, RegexOptions _0023_003DzdNx9MH0_003D)
	{
		return new _0023_003DzW0vVMDai_00241WamJy166LzGtYXxAOH(-2)
		{
			_0023_003DzsFGs7sDiof2F = _0023_003Dz0EsKsC8_003D,
			_0023_003DzAzn_DZmw_00247mn = _0023_003DzAqOpw0w_003D,
			_0023_003DzRShWhkiAESmh = _0023_003Dzk64JNOo_003D,
			_0023_003DzTyy6rbWL8doh = _0023_003DzdNx9MH0_003D
		};
	}

	internal static string _0023_003DzqlrZfOA_003D(string _0023_003Dz0EsKsC8_003D, string _0023_003Dzp8TRHtE_003D, string _0023_003DzL8JA6U0_003D, StringComparison _0023_003DzZw5LunE_003D)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		int num2;
		for (num2 = _0023_003Dz0EsKsC8_003D.IndexOf(_0023_003Dzp8TRHtE_003D, _0023_003DzZw5LunE_003D); num2 != -1; num2 = _0023_003Dz0EsKsC8_003D.IndexOf(_0023_003Dzp8TRHtE_003D, num2, _0023_003DzZw5LunE_003D))
		{
			stringBuilder.Append(_0023_003Dz0EsKsC8_003D, num, num2 - num);
			stringBuilder.Append(_0023_003DzL8JA6U0_003D);
			num2 += _0023_003Dzp8TRHtE_003D.Length;
			num = num2;
		}
		_0023_003DzS_0024C1UC0cJlqKiT6cj8_00242UChhOqXm._0023_003DzEDgZDJKdz1G9(stringBuilder, _0023_003Dz0EsKsC8_003D, num);
		return stringBuilder.ToString();
	}

	public static Color GetRandomColorDark(Random rand, int mask = 12632256)
	{
		return Color.FromArgb((int)(4278190080u + (rand.Next(16777215) & mask)));
	}

	public static Color GetRandomColor(Random rand)
	{
		return Color.FromArgb((int)(4278190080u + rand.Next(16777215)));
	}

	public static Color GetFrozenColor(Color source, double lightness = 1.8)
	{
		RGBtoHSL(source, out var hslCol);
		hslCol[2] = Math.Min(255.0, hslCol[2] * lightness);
		return HSLtoRGB(hslCol);
	}

	public static void RGBtoHSL(Color color, out double[] hslCol)
	{
		double num = (int)Math.Min(Math.Min(color.R, color.G), color.B);
		double num2 = (int)color.R;
		double num3 = 0.0;
		double num4 = color.G - color.B;
		if ((double)(int)color.G > num2)
		{
			num2 = (int)color.G;
			num3 = 120.0;
			num4 = color.B - color.R;
		}
		if ((double)(int)color.B > num2)
		{
			num2 = (int)color.B;
			num3 = 240.0;
			num4 = color.R - color.G;
		}
		double num5 = num2 - num;
		double num6 = num2 + num;
		double num7 = 0.5 * num6;
		double num8 = 0.0;
		double num9 = 0.0;
		if (num5 == 0.0)
		{
			num8 = 0.0;
			num9 = 0.0;
		}
		else
		{
			num9 = ((!(num7 < 127.5)) ? (255.0 * num5 / (510.0 - num6)) : (255.0 * num5 / num6));
			num8 = num3 + 60.0 * num4 / num5;
			if (num8 < 0.0)
			{
				num8 += 360.0;
			}
			if (num8 >= 360.0)
			{
				num8 -= 360.0;
			}
		}
		hslCol = new double[3] { num8, num9, num7 };
	}

	public static Color HSLtoRGB(double[] hsvCol)
	{
		double num = hsvCol[0];
		double num2 = hsvCol[1];
		double num3 = hsvCol[2];
		int red;
		int green;
		int blue;
		if (num2 == 0.0)
		{
			red = (green = (blue = (int)num3));
		}
		else
		{
			double num4 = ((!(num3 < 127.5)) ? (num3 + num2 - 1.0 / 255.0 * num2 * num3) : (1.0 / 255.0 * num3 * (255.0 + num2)));
			double num5 = 2.0 * num3 - num4;
			double num6 = num4 - num5;
			double num7 = num + 120.0;
			if (num7 >= 360.0)
			{
				num7 -= 360.0;
			}
			red = ((num7 < 60.0) ? ((int)(num5 + num6 * num7 * (1.0 / 60.0))) : ((num7 < 180.0) ? ((int)num4) : ((!(num7 < 240.0)) ? ((int)num5) : ((int)(num5 + num6 * (4.0 - num7 * (1.0 / 60.0)))))));
			num7 = num;
			green = ((num7 < 60.0) ? ((int)(num5 + num6 * num7 * (1.0 / 60.0))) : ((num7 < 180.0) ? ((int)num4) : ((!(num7 < 240.0)) ? ((int)num5) : ((int)(num5 + num6 * (4.0 - num7 * (1.0 / 60.0)))))));
			num7 = num - 120.0;
			if (num7 < 0.0)
			{
				num7 += 360.0;
			}
			blue = ((num7 < 60.0) ? ((int)(num5 + num6 * num7 * (1.0 / 60.0))) : ((num7 < 180.0) ? ((int)num4) : ((!(num7 < 240.0)) ? ((int)num5) : ((int)(num5 + num6 * (4.0 - num7 * (1.0 / 60.0)))))));
		}
		return Color.FromArgb(255, red, green, blue);
	}

	public static void RGBtoHSV(Color color, out double[] hsvCol)
	{
		double num = (int)color.R;
		double num2 = (int)color.G;
		double num3 = (int)color.B;
		double num4 = Math.Min(Math.Min(num, num2), num3);
		double num5 = Math.Max(Math.Max(num, num2), num3);
		double num6 = num5;
		double num7 = num5 - num4;
		double num8;
		double num9;
		if (num5 != 0.0)
		{
			num8 = num7 / num5;
			num9 = ((num5 == num) ? ((num2 - num3) / num7) : ((num5 != num2) ? (4.0 + (num - num2) / num7) : (2.0 + (num3 - num) / num7)));
			num9 *= 60.0;
			if (num9 < 0.0)
			{
				num9 += 360.0;
			}
		}
		else
		{
			num9 = (num8 = (num6 = 0.0));
		}
		hsvCol = new double[3] { num9, num8, num6 };
	}

	public static Color HSVtoRGB(double[] hsvCol)
	{
		double num = hsvCol[0];
		double num2 = hsvCol[1];
		double num3 = hsvCol[2];
		double num4;
		double num5;
		if (num2 == 0.0)
		{
			num4 = (num5 = num3);
			return Color.Black;
		}
		num /= 60.0;
		int num6 = (int)Math.Floor(num);
		double num7 = num - (double)num6;
		double num8 = num3 * (1.0 - num2);
		double num9 = num3 * (1.0 - num2 * num7);
		double num10 = num3 * (1.0 - num2 * (1.0 - num7));
		double num11;
		switch (num6)
		{
		case 0:
			num11 = num3;
			num4 = num10;
			num5 = num8;
			break;
		case 1:
			num11 = num9;
			num4 = num3;
			num5 = num8;
			break;
		case 2:
			num11 = num8;
			num4 = num3;
			num5 = num10;
			break;
		case 3:
			num11 = num8;
			num4 = num9;
			num5 = num3;
			break;
		case 4:
			num11 = num10;
			num4 = num8;
			num5 = num3;
			break;
		default:
			num11 = num3;
			num4 = num8;
			num5 = num9;
			break;
		}
		return Color.FromArgb((int)num11, (int)num4, (int)num5);
	}

	public static Color FloatArrayToColor(float[] color)
	{
		int value = (int)(color[3] * 255f);
		int value2 = (int)(color[0] * 255f);
		int value3 = (int)(color[1] * 255f);
		int value4 = (int)(color[2] * 255f);
		LimitRange(0, ref value, 255);
		LimitRange(0, ref value2, 255);
		LimitRange(0, ref value3, 255);
		LimitRange(0, ref value4, 255);
		return Color.FromArgb(value, value2, value3, value4);
	}

	public static Color DoubleArrayToColor(double[] color)
	{
		int value = (int)(color[0] * 255.0);
		int value2 = (int)(color[1] * 255.0);
		int value3 = (int)(color[2] * 255.0);
		LimitRange(0, ref value, 255);
		LimitRange(0, ref value2, 255);
		LimitRange(0, ref value3, 255);
		return Color.FromArgb(value, value2, value3);
	}

	public static float[] ColorToFloatArray(Color color)
	{
		return new float[4]
		{
			(float)(int)color.R / 255f,
			(float)(int)color.G / 255f,
			(float)(int)color.B / 255f,
			(float)(int)color.A / 255f
		};
	}

	public static double[] ColorToDoubleArray(Color color)
	{
		return new double[4]
		{
			(double)(int)color.R / 255.0,
			(double)(int)color.G / 255.0,
			(double)(int)color.B / 255.0,
			(double)(int)color.A / 255.0
		};
	}

	internal static float[] ToFloatArray(double[] _0023_003Dzb7SPTpc_003D)
	{
		float[] array = new float[_0023_003Dzb7SPTpc_003D.Length];
		for (int i = 0; i < _0023_003Dzb7SPTpc_003D.Length; i++)
		{
			array[i] = (float)_0023_003Dzb7SPTpc_003D[i];
		}
		return array;
	}

	public static bool AllVerticesInScreenPolygon(ScreenPolygonParams data, IList<Point3D> vertices, int count)
	{
		if (data.Transformation == null || data.Transformation.IsIdentity())
		{
			for (int i = 0; i < count; i++)
			{
				if (!VertexInScreenPolygon(vertices[i], data.ScreenPolygon, data.Min, data.Max, data.ModelViewProj, data.ViewFrame))
				{
					return false;
				}
			}
		}
		else
		{
			for (int j = 0; j < count; j++)
			{
				if (!VertexInScreenPolygon(data.Transformation * vertices[j], data.ScreenPolygon, data.Min, data.Max, data.ModelViewProj, data.ViewFrame))
				{
					return false;
				}
			}
		}
		return true;
	}

	public static bool VertexInScreenPolygon(Point3D pt, IList<Point2D> screenPolygon, Point2D min, Point2D max, double[] modelViewProj, int[] viewFrame)
	{
		Camera._0023_003DzlLK4_00249g_003D(modelViewProj, viewFrame, pt.X, pt.Y, pt.Z, out var _0023_003Dzm3rc4SA8WtT, out var _0023_003DzOM5CofBvYOXf);
		if (_0023_003Dzm3rc4SA8WtT > min.X && _0023_003Dzm3rc4SA8WtT < max.X && _0023_003DzOM5CofBvYOXf > min.Y && _0023_003DzOM5CofBvYOXf < max.Y)
		{
			return PointInPolygon(new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf), screenPolygon);
		}
		return false;
	}

	internal static bool _0023_003DzmNbBfJeObfba6gfTR6lLqbg_003D(int[] _0023_003DzqDFBISpCePlj, double[] _0023_003DzypMGqyMVO5qA, Transformation _0023_003Dzptomndc_003D, IList<Point2D> _0023_003DzJzj8yw_5AsNB, Point2D _0023_003DzF7v9r2A_003D, Point2D _0023_003Dz8dK2uhU_003D, float[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003Dzfsn580w_003D)
	{
		double _0023_003Dzm3rc4SA8WtT;
		double _0023_003DzOM5CofBvYOXf;
		if (_0023_003Dzptomndc_003D == null || _0023_003Dzptomndc_003D.IsIdentity())
		{
			for (int i = 0; i < _0023_003Dzfsn580w_003D; i += 3)
			{
				Camera._0023_003DzlLK4_00249g_003D(_0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i + 1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i + 2], out _0023_003Dzm3rc4SA8WtT, out _0023_003DzOM5CofBvYOXf);
				if (!(_0023_003Dzm3rc4SA8WtT > _0023_003DzF7v9r2A_003D.X) || !(_0023_003Dzm3rc4SA8WtT < _0023_003Dz8dK2uhU_003D.X) || !(_0023_003DzOM5CofBvYOXf > _0023_003DzF7v9r2A_003D.Y) || !(_0023_003DzOM5CofBvYOXf < _0023_003Dz8dK2uhU_003D.Y) || !PointInPolygon(new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf), _0023_003DzJzj8yw_5AsNB))
				{
					return false;
				}
			}
		}
		else
		{
			float[,] floatMatrix = _0023_003Dzptomndc_003D.GetFloatMatrix();
			for (int j = 0; j < _0023_003Dzfsn580w_003D; j += 3)
			{
				float[] array = Transformation.ActOnLeftOne(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[j], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[j + 1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[j + 2], floatMatrix);
				Camera._0023_003DzlLK4_00249g_003D(_0023_003DzypMGqyMVO5qA, _0023_003DzqDFBISpCePlj, array[0], array[1], array[2], out _0023_003Dzm3rc4SA8WtT, out _0023_003DzOM5CofBvYOXf);
				if (!(_0023_003Dzm3rc4SA8WtT > _0023_003DzF7v9r2A_003D.X) || !(_0023_003Dzm3rc4SA8WtT < _0023_003Dz8dK2uhU_003D.X) || !(_0023_003DzOM5CofBvYOXf > _0023_003DzF7v9r2A_003D.Y) || !(_0023_003DzOM5CofBvYOXf < _0023_003Dz8dK2uhU_003D.Y) || !PointInPolygon(new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf), _0023_003DzJzj8yw_5AsNB))
				{
					return false;
				}
			}
		}
		return true;
	}

	protected internal static void TrianglesToIndexedTriangles(Point3D[] vertTriangles, out Point3D[] uniqueVertices, out IndexTriangle[] cleanedTriangles, Mesh.natureType meshNature)
	{
		int num = vertTriangles.Length / 3;
		IList<IndexTriangle> list = Mesh._0023_003DzeVELJPX06XqphX1Zqg_003D_003D(meshNature, num);
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			list[i] = CreateTriangle(meshNature, num2++, num2++, num2++);
		}
		_0023_003DzJNADeOQRO6_fPmN4Ig_003D_003D(list, null, vertTriangles, out cleanedTriangles, out uniqueVertices, _0023_003DzKN_0024vjGN5_0024fwYJSS8TN63qBo_003D(vertTriangles), _0023_003Dz5syaaeMy5pLBOZfa4Kfhgq4_003D: true, _0023_003DzFwalihjMriJGyFaGGg_003D_003D: false);
	}

	public static CompositeCurve GetRevisionCloud(ICurve sourceCurve, Plane plane, double averageRadius)
	{
		Point3D[] pointsByLength = sourceCurve.GetPointsByLength(averageRadius * 2.0);
		List<ICurve> list = new List<ICurve>(pointsByLength.Length);
		for (int i = 0; i < pointsByLength.Length - 1; i++)
		{
			Point3D point3D = pointsByLength[i];
			Point3D point3D2 = pointsByLength[i + 1];
			Arc item = new Arc(plane, plane.Project(Point3D.MidPoint(point3D, point3D2)), plane.Project(point3D), plane.Project(point3D2));
			list.Add(item);
		}
		return new CompositeCurve(list);
	}

	internal static void _0023_003DzEtuso7_p35ZOEjCHBg_003D_003D(IList<Entity> _0023_003Dzv7xH9gk_003D, TraversalParams _0023_003DzELu0Pss_003D, out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC, out double _0023_003DzS61_KHm5Y3Cw, out bool _0023_003DzZkSIjE9P7t5u)
	{
		_0023_003DzZkSIjE9P7t5u = true;
		_0023_003DzDPcjoBJLcqli = Point3D.MaxValue;
		_0023_003Dz_0024N_0024yKptW9BoC = Point3D.MinValue;
		_0023_003DzS61_KHm5Y3Cw = 0.0;
		int count = _0023_003Dzv7xH9gk_003D.Count;
		LayerKeyedCollection layers = _0023_003DzELu0Pss_003D.Document.Layers;
		attributeReferenceVisibilityType attributeReferenceVisibilityMode = _0023_003DzELu0Pss_003D.Document.AttributeReferenceVisibilityMode;
		for (int i = 0; i < count; i++)
		{
			Entity entity = _0023_003Dzv7xH9gk_003D[i];
			if (!entity.IsVisible(null, layers, attributeReferenceVisibilityMode))
			{
				continue;
			}
			if (entity is BlockReference blockReference)
			{
				blockReference._0023_003DzFNUAUbe6oeIJ(_0023_003DzELu0Pss_003D, out var _0023_003DzDPcjoBJLcqli2, out var _0023_003Dz_0024N_0024yKptW9BoC2);
				if (_0023_003DzDPcjoBJLcqli2.X <= _0023_003Dz_0024N_0024yKptW9BoC2.X)
				{
					UpdateMinMaxQuick(_0023_003DzDPcjoBJLcqli2, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
					UpdateMinMaxQuick(_0023_003Dz_0024N_0024yKptW9BoC2, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC);
					_0023_003DzZkSIjE9P7t5u = false;
				}
			}
			else if (entity.CombineBoundingBox(_0023_003DzELu0Pss_003D.Transformation, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC))
			{
				_0023_003DzZkSIjE9P7t5u = false;
			}
			if (entity.localOffset > _0023_003DzS61_KHm5Y3Cw)
			{
				_0023_003DzS61_KHm5Y3Cw = entity.localOffset;
			}
		}
		_0023_003DzELu0Pss_003D.Document.OpenBlock.zoomFitConvexHull = null;
	}

	internal static void _0023_003DzEtuso7_p35ZOEjCHBg_003D_003D(IList<Entity> _0023_003Dzv7xH9gk_003D, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA, out Point3D _0023_003DzDPcjoBJLcqli, out Point3D _0023_003Dz_0024N_0024yKptW9BoC, out bool _0023_003DzZkSIjE9P7t5u)
	{
		_0023_003DzZkSIjE9P7t5u = true;
		_0023_003DzDPcjoBJLcqli = Point3D.MaxValue;
		_0023_003Dz_0024N_0024yKptW9BoC = Point3D.MinValue;
		int count = _0023_003Dzv7xH9gk_003D.Count;
		for (int i = 0; i < count; i++)
		{
			Entity entity = _0023_003Dzv7xH9gk_003D[i];
			if (_0023_003DzeWJg3NJnk3WA.TryGetValue(entity.LayerName, out var _) && _0023_003DzeWJg3NJnk3WA[entity.LayerName].Visible && entity.Visible && entity.CombineBoundingBox(null, _0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC))
			{
				_0023_003DzZkSIjE9P7t5u = false;
			}
		}
	}

	public static void ComputeMinMax(IList<Entity> entList, out Point3D boxMin, out Point3D boxMax)
	{
		boxMin = Point3D.MaxValue;
		boxMax = Point3D.MinValue;
		foreach (Entity ent in entList)
		{
			ent.CombineBoundingBox(null, boxMin, boxMax);
		}
	}

	public static void SortAndOrient(IList<ICurve> curveList)
	{
		int count = curveList.Count;
		List<ICurve> list = new List<ICurve>(curveList.Count);
		for (int i = 0; i < count; i++)
		{
			Entity entity = (Entity)((Entity)curveList[i]).Clone();
			list.Add((ICurve)entity);
		}
		List<ICurve> list2 = _0023_003DzrzTGlwfdU3k3YtEx_g_003D_003D(count, list, _0023_003Dz59LU6fL0vl_s4Lskpw_003D_003D: false);
		for (int j = 0; j < count; j++)
		{
			curveList[j] = list2[j];
		}
	}

	public static void SortAndOrient(IList<ICurve> curveList, double closureTol)
	{
		SortAndOrient(curveList, reverseVertices: false, assumeClosed: false, closureTol);
	}

	public static void SortAndOrient(IList<ICurve> curveList, bool reverseVertices, bool assumeClosed, double closureTol = 0.0)
	{
		int count = curveList.Count;
		if (count == 0)
		{
			return;
		}
		List<ICurve> list = new List<ICurve>(curveList.Count);
		for (int i = 0; i < count; i++)
		{
			Entity entity = (Entity)((Entity)curveList[i]).Clone();
			entity.EntityData = new Tuple<int, object>(i, ((Entity)curveList[i]).EntityData);
			((ICurve)entity).EdgeIndex = curveList[i].EdgeIndex;
			((ICurve)entity).FromBooleanIntersection = curveList[i].FromBooleanIntersection;
			if (reverseVertices && ((Entity)curveList[i]).Vertices != null)
			{
				Point3D[] vertices = ((Entity)curveList[i]).Vertices;
				entity.Vertices = new Point3D[vertices.Length];
				Array.Copy(vertices, entity.Vertices, vertices.Length);
			}
			list.Add((ICurve)entity);
		}
		List<ICurve> list2 = _0023_003DzrzTGlwfdU3k3YtEx_g_003D_003D(count, list, reverseVertices);
		bool num = assumeClosed || Point3D.Distance(list2[0].StartPoint, list2[list2.Count - 1].EndPoint) <= closureTol;
		ICurve[] array = list2.ToArray();
		if (num)
		{
			int j;
			for (j = 0; ((Tuple<int, object>)((Entity)array[j]).EntityData).Item1 != 0; j++)
			{
			}
			RotateLeft(array, j);
		}
		for (int k = 0; k < curveList.Count; k++)
		{
			curveList[k] = array[k];
			((Entity)curveList[k]).EntityData = ((Tuple<int, object>)((Entity)curveList[k]).EntityData).Item2;
		}
	}

	internal static void _0023_003DzTNlJvzZnPWmR1ZltZdV6n_A_003D(Entity _0023_003Dz0lRt3chMK_0024yum4ZjLg_003D_003D)
	{
		if (_0023_003Dz0lRt3chMK_0024yum4ZjLg_003D_003D.Vertices == null)
		{
			return;
		}
		Array.Reverse(_0023_003Dz0lRt3chMK_0024yum4ZjLg_003D_003D.Vertices);
		if (_0023_003Dz0lRt3chMK_0024yum4ZjLg_003D_003D.Vertices[0] is PointTangent && _0023_003Dz0lRt3chMK_0024yum4ZjLg_003D_003D.Vertices[_0023_003Dz0lRt3chMK_0024yum4ZjLg_003D_003D.Vertices.Length - 1] is PointTangent)
		{
			for (int i = 0; i < _0023_003Dz0lRt3chMK_0024yum4ZjLg_003D_003D.Vertices.Length; i++)
			{
				PointTangent obj = (PointTangent)_0023_003Dz0lRt3chMK_0024yum4ZjLg_003D_003D.Vertices[i];
				obj.Tx = 0.0 - obj.Tx;
				obj.Ty = 0.0 - obj.Ty;
				obj.Tz = 0.0 - obj.Tz;
			}
		}
	}

	public static int GetNextCurve(Point3D endPoint, ICurve current, bool isPrevStart, out double minGap, out bool needReverse)
	{
		needReverse = false;
		minGap = double.MaxValue;
		double num = Point3D.DistanceSquared(endPoint, current.StartPoint);
		double num2 = Point3D.DistanceSquared(endPoint, current.EndPoint);
		double num3 = Math.Min(num, num2);
		if (num3 < minGap)
		{
			minGap = num3;
			if (isPrevStart)
			{
				if (num < num2)
				{
					needReverse = true;
				}
			}
			else if (num > num2)
			{
				needReverse = true;
			}
		}
		return 0;
	}

	public static void DrawArrowOnView(DrawParams data, Vector3D curveDirection, Point3D point)
	{
		if (data.Transformation != null)
		{
			(data.Transformation * curveDirection).Normalize();
			curveDirection = data.Transformation.GetTransformationForNormals() * curveDirection;
			curveDirection.Normalize();
			point = data.Transformation * point;
		}
		Vector3D viewNormal = data.ViewNormal;
		Vector3D vector3D = Vector3D.Cross(curveDirection, viewNormal);
		if (vector3D.Length < _0023_003DzheSR8QM7q9ya)
		{
			int num = 0;
			int num2 = 0;
			double[] array = curveDirection.ToArray();
			for (int i = 1; i < 3; i++)
			{
				if (array[i] > array[num])
				{
					num = i;
				}
				if (array[i] < array[num2])
				{
					num2 = i;
				}
			}
			double num3 = array[num2];
			array[num2] = array[num];
			array[num] = num3;
			viewNormal = new Vector3D(array);
			viewNormal.Normalize();
			vector3D = Vector3D.Cross(curveDirection, viewNormal);
		}
		if (curveDirection.IsZero || vector3D.IsZero)
		{
			return;
		}
		Plane plane = new Plane(point, curveDirection, vector3D);
		Transformation transformation = new Transformation();
		transformation.Rotation(Plane.XY, plane);
		Point3D[] array2 = new Point3D[3];
		Point3D[] array3 = new Point3D[3];
		Point3D[] array4 = new Point3D[3];
		for (int j = 0; j < 3; j++)
		{
			array4[j] = transformation * DrawParams.DirectionArrowPoints[j];
		}
		array3[1] = array4[1];
		if (data.Viewport.Camera.ProjectionMode == projectionType.Perspective)
		{
			data.Viewport.Camera.GetFrame(out var _, out var camX, out var camY, out var _);
			Plane plane2 = new Plane(point, camX, camY);
			data.Viewport.Camera.ScreenToPlane(default(System.Drawing.Point), plane2, data.Height, data.ViewFrame, out var intPoint);
			double num4 = Vector3D.Subtract(intPoint, point).Length / 100.0;
			Vector3D vector3D2 = Vector3D.Subtract(array4[0], array4[1]);
			vector3D2.Normalize();
			array4[0] = array4[1] + num4 * vector3D2;
			Vector3D vector3D3 = Vector3D.Subtract(array4[2], array4[1]);
			vector3D3.Normalize();
			array4[2] = array4[1] + num4 * vector3D3;
		}
		array2 = data.Viewport.Camera.WorldToScreen(array4, data.ViewFrame);
		Vector3D vector3D4 = Vector3D.Subtract(array2[1], array2[0]);
		Vector3D vector3D5 = Vector3D.Subtract(array2[2], array2[1]);
		vector3D4.Normalize();
		vector3D5.Normalize();
		vector3D4 *= 16.0;
		vector3D5 *= 16.0;
		array2[0] = array2[1] - vector3D4;
		array2[2] = array2[1] + vector3D5;
		bool num5 = data.Viewport.Camera.ScreenToPlane(new System.Drawing.Point((int)array2[0].X, data.Height - (int)array2[0].Y), plane, data.Height, data.ViewFrame, out array3[0]);
		bool flag = data.Viewport.Camera.ScreenToPlane(new System.Drawing.Point((int)array2[2].X, data.Height - (int)array2[2].Y), plane, data.Height, data.ViewFrame, out array3[2]);
		if (!num5 || !flag)
		{
			Plane plane3 = new Plane(point, data.Viewport.Camera.ViewNormal);
			data.Viewport.Camera.ScreenToPlane(new System.Drawing.Point((int)array2[0].X, data.Height - (int)array2[0].Y), plane3, data.Height, data.ViewFrame, out array3[0]);
			flag = data.Viewport.Camera.ScreenToPlane(new System.Drawing.Point((int)array2[2].X, data.Height - (int)array2[2].Y), plane3, data.Height, data.ViewFrame, out array3[2]);
		}
		IViewportInternal viewportInternal = data.viewportInternal;
		if (viewportInternal.parent.CurrentTransformation != null)
		{
			for (int k = 0; k < array3.Length; k++)
			{
				array3[k] = viewportInternal.parent.CurrentTransformationInverse * array3[k];
			}
		}
		data.RenderContext.DrawLineStrip(array3, 0, 3);
	}

	public static int GetOuterIndex(IList<ICurve> loops, double tolerance)
	{
		for (int i = 0; i < loops.Count; i++)
		{
			Entity entity = (Entity)loops[i];
			if (entity.Vertices == null)
			{
				entity.Regen(tolerance);
			}
		}
		IList<IList<Point2D>> list = new List<IList<Point2D>>(loops.Count);
		for (int j = 0; j < loops.Count; j++)
		{
			list.Add(((Entity)loops[j]).Vertices);
		}
		return GetOuterIndex(list);
	}

	public static bool InsideOrCrossingFrustumQuad(FrustumParams myParams, IList<Point3D> vertices)
	{
		if (myParams.Transformation == null)
		{
			if (InsideOrCrossingFrustumQuad(vertices[0], vertices[1], vertices[2], vertices[3], myParams.Frustum))
			{
				return true;
			}
		}
		else if (InsideOrCrossingFrustumQuad(myParams.Transformation * vertices[0], myParams.Transformation * vertices[1], myParams.Transformation * vertices[2], myParams.Transformation * vertices[3], myParams.Frustum))
		{
			return true;
		}
		return false;
	}

	public static bool InsideOrCrossingFrustum(FrustumParams myParams, IList<Point3D> vertices, IList<IndexTriangle> triangles)
	{
		if (myParams.Transformation == null)
		{
			foreach (IndexTriangle triangle in triangles)
			{
				if (InsideOrCrossingFrustum(vertices[triangle.V1], vertices[triangle.V2], vertices[triangle.V3], myParams.Frustum))
				{
					return true;
				}
			}
		}
		else
		{
			foreach (IndexTriangle triangle2 in triangles)
			{
				if (InsideOrCrossingFrustum(myParams.Transformation * vertices[triangle2.V1], myParams.Transformation * vertices[triangle2.V2], myParams.Transformation * vertices[triangle2.V3], myParams.Frustum))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal static bool _0023_003DzuQDPXh1pHaNF4I3G_Evhw9Q_003D(Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, ScreenPolygonParams _0023_003DzmPmPjCPqZ3T3)
	{
		Transformation transformation = _0023_003DzmPmPjCPqZ3T3.Transformation;
		if (transformation == null)
		{
			IndexTriangle[] array = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D;
			foreach (IndexTriangle indexTriangle in array)
			{
				if (InsideOrCrossingScreenPolygon(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V1], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V2], _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle.V3], _0023_003DzmPmPjCPqZ3T3))
				{
					return true;
				}
			}
		}
		else
		{
			IndexTriangle[] array = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D;
			foreach (IndexTriangle indexTriangle2 in array)
			{
				if (InsideOrCrossingScreenPolygon(transformation * _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle2.V1], transformation * _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle2.V2], transformation * _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[indexTriangle2.V3], _0023_003DzmPmPjCPqZ3T3))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool InsideOrCrossingScreenPolygonQuad(Point3D pt1, Point3D pt2, Point3D pt3, Point3D pt4, ScreenPolygonParams myParams)
	{
		if (_0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(pt1, pt2, myParams))
		{
			return true;
		}
		if (_0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(pt2, pt3, myParams))
		{
			return true;
		}
		if (_0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(pt3, pt4, myParams))
		{
			return true;
		}
		if (_0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(pt4, pt1, myParams))
		{
			return true;
		}
		return false;
	}

	public static bool InsideOrCrossingScreenPolygon(Point3D pt1, Point3D pt2, Point3D pt3, ScreenPolygonParams myParams)
	{
		if (_0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(pt1, pt2, myParams))
		{
			return true;
		}
		if (_0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(pt2, pt3, myParams))
		{
			return true;
		}
		if (_0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(pt3, pt1, myParams))
		{
			return true;
		}
		return false;
	}

	internal static bool _0023_003DzCDHgZnw5jGnjOTqKdaPcrb3mQArQ(Point3D _0023_003DzMEwtr_A_003D, Point3D _0023_003DzW7Zyxfc_003D, ScreenPolygonParams _0023_003DzmPmPjCPqZ3T3)
	{
		Camera.Project(_0023_003DzmPmPjCPqZ3T3.Workspace.RenderContext, _0023_003DzmPmPjCPqZ3T3.ModelViewProj, _0023_003DzmPmPjCPqZ3T3.ViewFrame, _0023_003DzMEwtr_A_003D.X, _0023_003DzMEwtr_A_003D.Y, _0023_003DzMEwtr_A_003D.Z, out var _0023_003Dzm3rc4SA8WtT, out var _0023_003DzOM5CofBvYOXf, out var _0023_003Dz_00246VsdVC_0024uVkn);
		Camera.Project(_0023_003DzmPmPjCPqZ3T3.Workspace.RenderContext, _0023_003DzmPmPjCPqZ3T3.ModelViewProj, _0023_003DzmPmPjCPqZ3T3.ViewFrame, _0023_003DzW7Zyxfc_003D.X, _0023_003DzW7Zyxfc_003D.Y, _0023_003DzW7Zyxfc_003D.Z, out var _0023_003Dzm3rc4SA8WtT2, out var _0023_003DzOM5CofBvYOXf2, out var _0023_003Dz_00246VsdVC_0024uVkn2);
		if (_0023_003Dz_00246VsdVC_0024uVkn > 1.0 || _0023_003Dz_00246VsdVC_0024uVkn2 > 1.0)
		{
			return false;
		}
		Segment2D segment2D = new Segment2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf, _0023_003Dzm3rc4SA8WtT2, _0023_003DzOM5CofBvYOXf2);
		if (PointInPolygon(segment2D.P0, _0023_003DzmPmPjCPqZ3T3.ScreenPolygon) || PointInPolygon(segment2D.P1, _0023_003DzmPmPjCPqZ3T3.ScreenPolygon))
		{
			return true;
		}
		for (int i = 0; i < _0023_003DzmPmPjCPqZ3T3.ScreenSegments.Count; i++)
		{
			if (Segment2D.Intersection(_0023_003DzmPmPjCPqZ3T3.ScreenSegments[i], segment2D, out var _))
			{
				return true;
			}
		}
		return false;
	}

	internal static bool _0023_003DzwNyEcZpX6XZGQQLSIMXoIPUP01j6(Point3D _0023_003DzMEwtr_A_003D, ScreenPolygonParams _0023_003DzmPmPjCPqZ3T3)
	{
		Camera.Project(_0023_003DzmPmPjCPqZ3T3.Workspace.RenderContext, _0023_003DzmPmPjCPqZ3T3.ModelViewProj, _0023_003DzmPmPjCPqZ3T3.ViewFrame, _0023_003DzMEwtr_A_003D.X, _0023_003DzMEwtr_A_003D.Y, _0023_003DzMEwtr_A_003D.Z, out var _0023_003Dzm3rc4SA8WtT, out var _0023_003DzOM5CofBvYOXf, out var _0023_003Dz_00246VsdVC_0024uVkn);
		if (_0023_003Dz_00246VsdVC_0024uVkn > 1.0)
		{
			return false;
		}
		if (PointInPolygon(new Point2D(_0023_003Dzm3rc4SA8WtT, _0023_003DzOM5CofBvYOXf), _0023_003DzmPmPjCPqZ3T3.ScreenPolygon))
		{
			return true;
		}
		return false;
	}

	public static bool AllVerticesInFrustum(FrustumParams data, IList<Point3D> vertices, int vertexCount)
	{
		if (data.Transformation == null || data.Transformation.IsIdentity())
		{
			for (int i = 0; i < vertexCount; i++)
			{
				if (!Camera.IsInFrustum(vertices[i], data.Frustum))
				{
					return false;
				}
			}
		}
		else
		{
			for (int j = 0; j < vertexCount; j++)
			{
				if (!Camera.IsInFrustum(data.Transformation * vertices[j], data.Frustum))
				{
					return false;
				}
			}
		}
		return true;
	}

	public static bool AllVerticesInFrustum(PlaneEquation[] frustum, Transformation transform, float[] pointArray, int count)
	{
		if (transform == null || transform.IsIdentity())
		{
			for (int i = 0; i < count; i += 3)
			{
				if (!Camera._0023_003DzqtX29XBChOdOLdC8QQ_003D_003D(pointArray[i], pointArray[i + 1], pointArray[i + 2], frustum))
				{
					return false;
				}
			}
		}
		else
		{
			float[,] floatMatrix = transform.GetFloatMatrix();
			for (int j = 0; j < count; j += 3)
			{
				float[] array = Transformation.ActOnLeftOne(pointArray[j], pointArray[j + 1], pointArray[j + 2], floatMatrix);
				if (!Camera._0023_003DzqtX29XBChOdOLdC8QQ_003D_003D(array[0], array[1], array[2], frustum))
				{
					return false;
				}
			}
		}
		return true;
	}

	public static string GetUnusedBlockName(string name, BlockKeyedCollection blocks, bool addCounterOnlyIfNeeded = false)
	{
		return _0023_003DzXUVrZpJ__aQi(name, blocks.Contains, ref _0023_003DznQKUIDFq83WZ, addCounterOnlyIfNeeded);
	}

	public static string GetUnusedLayerName(string name, LayerKeyedCollection layers, bool addCounterOnlyIfNeeded = false)
	{
		return _0023_003DzXUVrZpJ__aQi(name, layers.Contains, ref _0023_003DznQ8y5z6Ph4a5, addCounterOnlyIfNeeded);
	}

	internal static string GetUnusedLineTypeName(string _0023_003DzS_00246o7tc_003D, LineTypeKeyedCollection _0023_003DzA3_0024EZ731xRIG, bool _0023_003DzYAFlx1qRy2tosXY_0024QQ_003D_003D = false)
	{
		return _0023_003DzXUVrZpJ__aQi(_0023_003DzS_00246o7tc_003D, _0023_003DzA3_0024EZ731xRIG.Contains, ref _0023_003Dz9Eyky55oGfv3, _0023_003DzYAFlx1qRy2tosXY_0024QQ_003D_003D);
	}

	internal static string _0023_003DzMnXK_AcQrfN3<T>(string _0023_003DzS_00246o7tc_003D, EyeshotKeyedCollection<T> _0023_003DzcrILBXg_003D, bool _0023_003DzYAFlx1qRy2tosXY_0024QQ_003D_003D) where T : IKeyedCollectionItem<T>
	{
		int _0023_003DzhYy1dJQ_003D = 0;
		return _0023_003DzXUVrZpJ__aQi(_0023_003DzS_00246o7tc_003D, _0023_003DzcrILBXg_003D.Contains, ref _0023_003DzhYy1dJQ_003D, _0023_003DzYAFlx1qRy2tosXY_0024QQ_003D_003D);
	}

	private static string _0023_003DzXUVrZpJ__aQi(string _0023_003DzS_00246o7tc_003D, _0023_003Dz3Hbn_0024P0_003D _0023_003Dzpvn1LMU_003D, ref int _0023_003DzhYy1dJQ_003D, bool _0023_003DzYAFlx1qRy2tosXY_0024QQ_003D_003D)
	{
		string text;
		if (_0023_003DzYAFlx1qRy2tosXY_0024QQ_003D_003D)
		{
			text = _0023_003DzS_00246o7tc_003D;
			int num = 0;
			while (_0023_003Dzpvn1LMU_003D(text))
			{
				text = _0023_003DzS_00246o7tc_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926624) + ++num;
			}
		}
		else
		{
			do
			{
				string text2 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926624);
				int num2 = ++_0023_003DzhYy1dJQ_003D;
				text = _0023_003DzS_00246o7tc_003D + text2 + num2;
			}
			while (_0023_003Dzpvn1LMU_003D(text));
		}
		return text;
	}

	internal static void _0023_003DzGJjMmeSXniV_0024(RenderContextBase _0023_003DzQdnFby4_003D, double _0023_003DzobiuKb8PuTBU, double _0023_003DznW4EU1BCrSeB, int _0023_003DzAPBIJmvn5i5Q, int _0023_003Dzcv8o5nO25OjS, bool _0023_003DzpS_hL4S_0024_8GX)
	{
		throw new NotImplementedException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662218));
	}

	internal static void _0023_003DzPhZiPGj5KCj5(RenderContextBase _0023_003DzQdnFby4_003D, Point3D[] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IndexTriangle[] _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, Vector3D[] _0023_003DzztJY0_0024dXEFMk, PointF[] _0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D)
	{
		_0023_003DzQdnFby4_003D.DrawTriangles(_0023_003Dzk98RESByZO6KwZuGTA_003D_003D, _0023_003DzztJY0_0024dXEFMk, _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, _0023_003DzT_0024JFl7sZFhXxIez_7A_003D_003D);
	}

	internal static bool _0023_003DziO8_0024N5HjLOoQRQgn7nLiej4gvs_amz7Myw_003D_003D(float[] _0023_003DzrH1N0x4_003D, byte[] _0023_003Dz10j_0024rZU_003D)
	{
		return _0023_003Dz10j_0024rZU_003D.Length == _0023_003DzrH1N0x4_003D.Length / 3;
	}

	internal static float[][] _0023_003DzEgpXpXaWYSvR(IList<float> _0023_003Dzps1XgJJ9NzWkz4jfng_003D_003D, int _0023_003DzLMo0v2w_003D, int _0023_003DzmTIZ8Fc_003D)
	{
		int num = _0023_003DzLMo0v2w_003D * _0023_003DzmTIZ8Fc_003D;
		if ((double)_0023_003Dzps1XgJJ9NzWkz4jfng_003D_003D.Count > (double)num * 1.5)
		{
			int num2 = (int)Math.Ceiling((double)_0023_003Dzps1XgJJ9NzWkz4jfng_003D_003D.Count / (double)num);
			float[][] array = new float[num2][];
			int num3 = 0;
			for (int i = 0; i < num2; i++)
			{
				array[i] = new float[(i < num2 - 1) ? num : (_0023_003Dzps1XgJJ9NzWkz4jfng_003D_003D.Count - num * i)];
				for (int j = 0; j < array[i].Length; j++)
				{
					array[i][j] = _0023_003Dzps1XgJJ9NzWkz4jfng_003D_003D[num3++];
				}
			}
			return array;
		}
		return new float[1][] { _0023_003Dzps1XgJJ9NzWkz4jfng_003D_003D.ToArray() };
	}

	public static double GetUnitsToMmFactor(linearUnitsType units)
	{
		double result = 1.0;
		switch (units)
		{
		case linearUnitsType.Centimeters:
			result = 100.0;
			break;
		case linearUnitsType.Meters:
			result = 1000.0;
			break;
		case linearUnitsType.Kilometers:
			result = 1000000.0;
			break;
		case linearUnitsType.Inches:
			result = 25.4;
			break;
		case linearUnitsType.Feet:
			result = 304.8;
			break;
		case linearUnitsType.Miles:
			result = 1609344.0;
			break;
		}
		return result;
	}

	public static ICurve[] CleanDuplicates(IList<ICurve> contour)
	{
		return _0023_003DzlrAzqfA8goUU(contour, new List<ICurve>());
	}

	public static double Normalize(double numValue, Interval range)
	{
		double value = 0.0;
		if (range.Length != 0.0)
		{
			value = (numValue - range.Min) / range.Length;
			LimitRange(0.0, ref value, 1.0);
		}
		return value;
	}

	internal static float _0023_003DzbV1eOjg_003D(double _0023_003DzPzO_0024GUk_003D, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D)
	{
		return (float)Normalize(_0023_003DzPzO_0024GUk_003D, new Interval(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D));
	}

	internal static void _0023_003DziGAL9VlRTiSaKUoibjs6bFxv0Ao6(Entity _0023_003Dzb7SPTpc_003D, Entity _0023_003DzaoQTclc_003D)
	{
		if (_0023_003Dzb7SPTpc_003D.localMin != null && _0023_003DzaoQTclc_003D.localMin == null)
		{
			_0023_003DzaoQTclc_003D.localMin = (Point3D)_0023_003Dzb7SPTpc_003D.localMin.Clone();
			_0023_003DzaoQTclc_003D.localMax = (Point3D)_0023_003Dzb7SPTpc_003D.localMax.Clone();
		}
		if (_0023_003DzaoQTclc_003D is Brep)
		{
			Brep brep = (Brep)_0023_003Dzb7SPTpc_003D;
			Brep brep2 = (Brep)_0023_003DzaoQTclc_003D;
			for (int i = 0; i < brep.Edges.Length; i++)
			{
				Brep.Edge edge = brep.Edges[i];
				if (((Entity)edge.Curve).Vertices != null && ((Entity)edge.Curve).Vertices.Length != 0)
				{
					Brep.Edge edge2 = brep2.Edges[i];
					int num = ((Entity)edge.Curve).Vertices.Length;
					((Entity)edge2.Curve).Vertices = new Point3D[num];
					for (int j = 0; j < num; j++)
					{
						((Entity)edge2.Curve).Vertices[j] = (Point3D)((Entity)edge.Curve).Vertices[j].Clone();
					}
				}
			}
			for (int k = 0; k < brep.Faces.Length; k++)
			{
				brep2.Faces[k].Tessellation = (FastMesh)brep.Faces[k].Tessellation.Clone();
				Brep._0023_003DzH_00244LxjBICrXYBxcvYXYFsGI_003D(brep.Faces[k], brep2.Faces[k], _0023_003Dz0mIPc9VROWxZ: false, null, 0.0);
			}
			for (int l = 0; l < brep.Inners.Length; l++)
			{
				Brep.Face[] array = brep.Inners[l];
				Brep.Face[] array2 = brep2.Inners[l];
				for (int m = 0; m < array.Length; m++)
				{
					array2[m].Tessellation = (FastMesh)array[m].Tessellation.Clone();
					Brep._0023_003DzH_00244LxjBICrXYBxcvYXYFsGI_003D(array[m], array2[m], _0023_003Dz0mIPc9VROWxZ: false, null, 0.0);
				}
			}
		}
		else if (_0023_003DzaoQTclc_003D is Surface)
		{
			Surface surface = (Surface)_0023_003Dzb7SPTpc_003D;
			Surface surface2 = (Surface)_0023_003DzaoQTclc_003D;
			if (surface.Vertices != null)
			{
				surface2.Vertices = new Point3D[surface.Vertices.Length];
				for (int n = 0; n < surface2._vertices.Length; n++)
				{
					surface2._vertices[n] = (Point3D)surface._vertices[n].Clone();
				}
			}
			if (surface.Triangles != null)
			{
				surface2._triangles = new IndexTriangle[surface.Triangles.Length];
				for (int num2 = 0; num2 < surface2._triangles.Length; num2++)
				{
					surface2._triangles[num2] = (IndexTriangle)surface._triangles[num2].Clone();
				}
			}
		}
		else if (_0023_003DzaoQTclc_003D is Bar)
		{
			Bar bar = (Bar)_0023_003Dzb7SPTpc_003D;
			Bar bar2 = (Bar)_0023_003DzaoQTclc_003D;
			if (bar.Vertices != null)
			{
				bar2._vertices = new Point3D[bar.Vertices.Length];
				for (int num3 = 0; num3 < bar2._vertices.Length; num3++)
				{
					bar2._vertices[num3] = (Point3D)bar._vertices[num3].Clone();
				}
			}
			if (bar.Triangles != null)
			{
				bar2.Triangles = new IndexTriangle[bar.Triangles.Length];
				for (int num4 = 0; num4 < bar2.Triangles.Length; num4++)
				{
					bar2.Triangles[num4] = (IndexTriangle)bar.Triangles[num4].Clone();
				}
			}
		}
		else if (_0023_003DzaoQTclc_003D is Joint)
		{
			Joint joint = (Joint)_0023_003Dzb7SPTpc_003D;
			Joint joint2 = (Joint)_0023_003DzaoQTclc_003D;
			if (joint.Vertices != null)
			{
				joint2._vertices = new Point3D[joint.Vertices.Length];
				for (int num5 = 0; num5 < joint2._vertices.Length; num5++)
				{
					joint2._vertices[num5] = (Point3D)joint._vertices[num5].Clone();
				}
			}
			if (joint.Triangles != null)
			{
				joint2._0023_003Dzg8NPq_0024Bv7ANvyfVpbA_003D_003D(new IndexTriangle[joint.Triangles.Length]);
				for (int num6 = 0; num6 < joint2.Triangles.Length; num6++)
				{
					joint2.Triangles[num6] = (IndexTriangle)joint.Triangles[num6].Clone();
				}
			}
		}
		else if (_0023_003DzaoQTclc_003D is devDept.Eyeshot.Entities.Region)
		{
			devDept.Eyeshot.Entities.Region region = (devDept.Eyeshot.Entities.Region)_0023_003Dzb7SPTpc_003D;
			devDept.Eyeshot.Entities.Region region2 = (devDept.Eyeshot.Entities.Region)_0023_003DzaoQTclc_003D;
			if (region.Vertices != null)
			{
				region2._vertices = new Point3D[region.Vertices.Length];
				for (int num7 = 0; num7 < region2._vertices.Length; num7++)
				{
					region2._vertices[num7] = (Point3D)region._vertices[num7].Clone();
				}
			}
			if (region.Triangles != null)
			{
				region2.Triangles = new IndexTriangle[region.Triangles.Length];
				for (int num8 = 0; num8 < region2.Triangles.Length; num8++)
				{
					region2.Triangles[num8] = (IndexTriangle)region.Triangles[num8].Clone();
				}
			}
			if (region.Edges != null)
			{
				region2.Edges = new IndexLine[region.Edges.Length];
				for (int num9 = 0; num9 < region2.Edges.Length; num9++)
				{
					region2.Edges[num9] = (IndexLine)region.Edges[num9].Clone();
				}
			}
		}
		else
		{
			if (!(_0023_003DzaoQTclc_003D is ICurve))
			{
				return;
			}
			if (_0023_003Dzb7SPTpc_003D.Vertices != null)
			{
				_0023_003DzaoQTclc_003D._vertices = new Point3D[_0023_003Dzb7SPTpc_003D.Vertices.Length];
				for (int num10 = 0; num10 < _0023_003DzaoQTclc_003D._vertices.Length; num10++)
				{
					_0023_003DzaoQTclc_003D._vertices[num10] = (Point3D)_0023_003Dzb7SPTpc_003D._vertices[num10].Clone();
				}
			}
		}
	}

	internal static Point3D[] _0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(IReadOnlyList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D)
	{
		Point3D[] array = new Point3D[_0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count];
		for (int i = 0; i < _0023_003Dzk98RESByZO6KwZuGTA_003D_003D.Count; i++)
		{
			array[i] = (Point3D)_0023_003Dzk98RESByZO6KwZuGTA_003D_003D[i].Clone();
		}
		return array;
	}

	internal static Entity _0023_003DzRl3z5maF_0024_jbcZb4zYuHZ4A_003D(Entity _0023_003Dzb7SPTpc_003D)
	{
		Entity entity = (Entity)_0023_003Dzb7SPTpc_003D.Clone();
		entity.EntityData = _0023_003Dzb7SPTpc_003D.EntityData;
		if (!(_0023_003Dzb7SPTpc_003D is Line) && !(_0023_003Dzb7SPTpc_003D is LinearPath) && _0023_003Dzb7SPTpc_003D.Vertices != null)
		{
			entity.Vertices = _0023_003DziiyOI32qB_0024yh69HaXQ_003D_003D(_0023_003Dzb7SPTpc_003D.Vertices);
		}
		if (_0023_003Dzb7SPTpc_003D.localMin != null)
		{
			entity.localMin = _0023_003Dzb7SPTpc_003D.localMin;
			entity.localMax = _0023_003Dzb7SPTpc_003D.localMax;
			entity.sphereCenter = _0023_003Dzb7SPTpc_003D.sphereCenter;
			entity.sphereRadius = _0023_003Dzb7SPTpc_003D.sphereRadius;
			entity.RegenMode = _0023_003Dzb7SPTpc_003D.RegenMode;
		}
		return entity;
	}

	internal static IndexTriangle[] _0023_003DzX42kjXfbzdxuD8Dt7A_003D_003D(IndexTriangle[] _0023_003Dzb7SPTpc_003D)
	{
		int num = _0023_003Dzb7SPTpc_003D.Length;
		IndexTriangle[] array = new IndexTriangle[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = (IndexTriangle)_0023_003Dzb7SPTpc_003D[i].Clone();
		}
		return array;
	}

	internal static Vector3D[] _0023_003DzuKHw7_00241xg_0024SB(IReadOnlyList<Vector3D> _0023_003DzT531JqWrKLWb)
	{
		Vector3D[] array = new Vector3D[_0023_003DzT531JqWrKLWb.Count];
		for (int i = 0; i < _0023_003DzT531JqWrKLWb.Count; i++)
		{
			array[i] = (Vector3D)_0023_003DzT531JqWrKLWb[i].Clone();
		}
		return array;
	}

	public static Dictionary<Type, int> GetEntitiesStats(IList<Entity> entityList, BlockKeyedCollection blocks, out int entitiesCount, out int verticesCount, out int trianglesCount, Dictionary<Block, Dictionary<Type, int>> blocksDetails = null)
	{
		_0023_003DzSWQKpqBvYSEeYAzOALPj_0024d8_003D _0023_003DzSWQKpqBvYSEeYAzOALPj_0024d8_003D2 = new _0023_003DzSWQKpqBvYSEeYAzOALPj_0024d8_003D();
		_0023_003DzSWQKpqBvYSEeYAzOALPj_0024d8_003D2._0023_003DzJO1FWlQ_003D = blocks;
		_0023_003DzSWQKpqBvYSEeYAzOALPj_0024d8_003D2._0023_003DzOTjvb5U_003D = new _0023_003Dz_oAbKQB_0024bE8H();
		Parallel.ForEach(entityList, _0023_003DzSWQKpqBvYSEeYAzOALPj_0024d8_003D2._0023_003DzH8NHt_hBiNo3aXpFhQ_003D_003D);
		if (blocksDetails != null)
		{
			foreach (Block item in _0023_003DzSWQKpqBvYSEeYAzOALPj_0024d8_003D2._0023_003DzJO1FWlQ_003D)
			{
				_0023_003DzgXDOuv8r81l4Hsr1RflTF_w_003D _0023_003DzgXDOuv8r81l4Hsr1RflTF_w_003D2 = new _0023_003DzgXDOuv8r81l4Hsr1RflTF_w_003D();
				_0023_003DzgXDOuv8r81l4Hsr1RflTF_w_003D2._0023_003Dq67X_icOyL2pbVg8MqeLnN9iyPisQmwHJyzSwPdBoj_0024I_003D = _0023_003DzSWQKpqBvYSEeYAzOALPj_0024d8_003D2;
				if (item.regenerated)
				{
					_0023_003DzgXDOuv8r81l4Hsr1RflTF_w_003D2._0023_003DzwbSYw4yD1PW4 = new _0023_003Dz_oAbKQB_0024bE8H();
					Parallel.ForEach(item.Entities, _0023_003DzgXDOuv8r81l4Hsr1RflTF_w_003D2._0023_003DzM7ZzqEOv_SxJANuDXg_003D_003D);
					Dictionary<Type, int> value = _0023_003DzgXDOuv8r81l4Hsr1RflTF_w_003D2._0023_003DzwbSYw4yD1PW4._0023_003Dz3QHxwCaWnG9i.OrderBy(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz0quuv2lhtcAOdY6E7UqP1Do_003D).ToDictionary((KeyValuePair<Type, int> _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D.Key, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzTYb065Or4h2ZTfG2R83j3vo_003D);
					blocksDetails.Add(item, value);
				}
			}
		}
		entitiesCount = _0023_003DzSWQKpqBvYSEeYAzOALPj_0024d8_003D2._0023_003DzOTjvb5U_003D._0023_003DzbpLIUiI_003D;
		verticesCount = _0023_003DzSWQKpqBvYSEeYAzOALPj_0024d8_003D2._0023_003DzOTjvb5U_003D._0023_003DzJltwz0y1myjKQO1O8w_003D_003D;
		trianglesCount = _0023_003DzSWQKpqBvYSEeYAzOALPj_0024d8_003D2._0023_003DzOTjvb5U_003D._0023_003DzPacMabcPoc4oQoC0UA_003D_003D;
		return new Dictionary<Type, int>(_0023_003DzSWQKpqBvYSEeYAzOALPj_0024d8_003D2._0023_003DzOTjvb5U_003D._0023_003Dz3QHxwCaWnG9i).OrderBy(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzWHte1hSXET21AHoVinu2UZs_003D).ToDictionary(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzUvsvGxQpF50Fc_SrGXzc05A_003D, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzRWlb2BTzNjdcfomqU08g4ic_003D);
	}

	[Obsolete("Use the method that accepts all the master collections instead.")]
	public static string GetEntitiesStats(IList<Entity> entityList, BlockKeyedCollection blocks, bool showTotals, bool showBlocksDetails = false)
	{
		return GetEntitiesStats(entityList, null, blocks, null, null, null, null, showTotals, showBlocksDetails);
	}

	public static string GetEntitiesStats(IList<Entity> entityList, LayerKeyedCollection layers, BlockKeyedCollection blocks, MaterialKeyedCollection materials, TextStyleKeyedCollection textStyles, LineTypeKeyedCollection lineTypes, HatchPatternKeyedCollection hatchPatterns, bool showTotals, bool showBlocksDetails = false, bool showCollectionsItems = false)
	{
		Dictionary<Block, Dictionary<Type, int>> dictionary = (showBlocksDetails ? new Dictionary<Block, Dictionary<Type, int>>() : null);
		int entitiesCount;
		int verticesCount;
		int trianglesCount;
		Dictionary<Type, int> entitiesStats = GetEntitiesStats(entityList, blocks, out entitiesCount, out verticesCount, out trianglesCount, dictionary);
		string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662387);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(text);
		_0023_003DzoMz0s3LUXF3DyUy31A_003D_003D(entitiesStats, stringBuilder);
		if (showTotals)
		{
			stringBuilder.AppendLine(text);
			stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662365));
			stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662347), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302657120), entitiesCount));
			stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662347), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302958678), verticesCount));
			stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662347), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968413), trianglesCount));
		}
		stringBuilder.Append(text);
		if (showCollectionsItems)
		{
			stringBuilder.AppendLine();
			_0023_003DzuTf8esungXOH(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998950), materials, stringBuilder, text);
			_0023_003DzuTf8esungXOH(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662305), textStyles, stringBuilder, text);
			_0023_003DzuTf8esungXOH(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662291), lineTypes, stringBuilder, text);
			_0023_003DzuTf8esungXOH(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662278), hatchPatterns, stringBuilder, text);
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663033), layers.Count));
			stringBuilder.AppendLine(text);
			foreach (Layer layer in layers)
			{
				string text2 = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663022), layer.Name, layer.Color);
				if (!string.IsNullOrEmpty(layer.MaterialName))
				{
					text2 = text2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663004) + layer.MaterialName;
				}
				if (!string.IsNullOrEmpty(layer.LineTypeName))
				{
					text2 = text2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662990) + layer.LineTypeName;
				}
				text2 = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662976), text2, layer.LineWeight);
				stringBuilder.AppendLine(text2);
			}
			if (!showBlocksDetails)
			{
				_0023_003DzuTf8esungXOH(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662938), blocks, stringBuilder, text);
			}
		}
		if (showBlocksDetails)
		{
			stringBuilder.AppendLine();
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662917), dictionary.Count));
			stringBuilder.AppendLine(text);
			foreach (KeyValuePair<Block, Dictionary<Type, int>> item in dictionary)
			{
				stringBuilder.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663162) + item.Key.Name);
				_0023_003DzoMz0s3LUXF3DyUy31A_003D_003D(item.Value, stringBuilder);
				stringBuilder.AppendLine(text);
			}
		}
		return stringBuilder.ToString();
	}

	private static void _0023_003DzuTf8esungXOH<T>(string _0023_003Dz7krrKyA_003D, EyeshotKeyedCollection<T> _0023_003DzcrILBXg_003D, StringBuilder _0023_003DzgyYoHow_003D, string _0023_003DzeF_0024TW_0024c_003D) where T : IKeyedCollectionItem<T>
	{
		_0023_003DzgyYoHow_003D.AppendLine();
		_0023_003DzgyYoHow_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302902674), _0023_003Dz7krrKyA_003D, _0023_003DzcrILBXg_003D.Count));
		_0023_003DzgyYoHow_003D.AppendLine(_0023_003DzeF_0024TW_0024c_003D);
		foreach (T item in _0023_003DzcrILBXg_003D)
		{
			_0023_003DzgyYoHow_003D.AppendLine(item.GetKey() ?? string.Empty);
		}
	}

	private static void _0023_003DzoMz0s3LUXF3DyUy31A_003D_003D(Dictionary<Type, int> _0023_003Dz5FOfWIC1qHN8, StringBuilder _0023_003DzgyYoHow_003D)
	{
		foreach (KeyValuePair<Type, int> item in _0023_003Dz5FOfWIC1qHN8)
		{
			string arg = item.Key.ToString().Split('.').Last();
			_0023_003DzgyYoHow_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662347), arg, item.Value));
		}
	}

	private static _0023_003Dz_oAbKQB_0024bE8H _0023_003Dz9MXzPGXXCOqX(Entity _0023_003Dzs_0024uS8LA_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, bool _0023_003DzNIs0hzaBCcL8z40btQ_003D_003D)
	{
		_0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D _0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2 = new _0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D();
		_0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzJO1FWlQ_003D = _0023_003DzJO1FWlQ_003D;
		_0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D = new _0023_003Dz_oAbKQB_0024bE8H();
		Type type = _0023_003Dzs_0024uS8LA_003D.GetType();
		if (!_0023_003DzNIs0hzaBCcL8z40btQ_003D_003D)
		{
			_0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D._0023_003DzbpLIUiI_003D++;
			_0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D._0023_003Dz3QHxwCaWnG9i.AddOrUpdate(type, 1, (Type _0023_003DzEKSHIVc_003D, int _0023_003Dzfsn580w_003D) => _0023_003Dzfsn580w_003D + 1);
		}
		if (_0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzJO1FWlQ_003D != null && _0023_003Dzs_0024uS8LA_003D is BlockReference blockReference)
		{
			foreach (Block item in _0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzJO1FWlQ_003D)
			{
				if (item.Name.Equals(blockReference.BlockName, StringComparison.OrdinalIgnoreCase))
				{
					Parallel.ForEach(item.Entities, _0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003Dz9mDbjZFLbwXPwmd8KWf3QIo_003D);
					break;
				}
			}
		}
		if (_0023_003Dzs_0024uS8LA_003D.Vertices != null)
		{
			_0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D._0023_003DzJltwz0y1myjKQO1O8w_003D_003D += _0023_003Dzs_0024uS8LA_003D.Vertices.Length;
		}
		if (!(_0023_003Dzs_0024uS8LA_003D is Triangle))
		{
			if (!(_0023_003Dzs_0024uS8LA_003D is Quad))
			{
				if (!(_0023_003Dzs_0024uS8LA_003D is Joint joint))
				{
					if (!(_0023_003Dzs_0024uS8LA_003D is Bar bar))
					{
						if (!(_0023_003Dzs_0024uS8LA_003D is Mesh mesh))
						{
							if (!(_0023_003Dzs_0024uS8LA_003D is devDept.Eyeshot.Entities.Region region))
							{
								if (!(_0023_003Dzs_0024uS8LA_003D is Solid solid))
								{
									if (!(_0023_003Dzs_0024uS8LA_003D is Surface surface))
									{
										if (!(_0023_003Dzs_0024uS8LA_003D is Brep brep))
										{
											if (_0023_003Dzs_0024uS8LA_003D is FemMesh { skin: not null } femMesh)
											{
												int num = 0;
												int num2 = 0;
												Mesh[] tessellation = femMesh.GetTessellation();
												foreach (Mesh mesh2 in tessellation)
												{
													num2 += mesh2.Vertices.Length;
													if (mesh2.Triangles != null)
													{
														num += mesh2.Triangles.Length;
													}
												}
												_0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D._0023_003DzJltwz0y1myjKQO1O8w_003D_003D += num2;
												_0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D._0023_003DzPacMabcPoc4oQoC0UA_003D_003D += num;
											}
										}
										else
										{
											int num4 = 0;
											int num5 = 0;
											Mesh[] tessellation = brep.GetTessellation();
											foreach (Mesh mesh3 in tessellation)
											{
												num5 += mesh3.Vertices.Length;
												if (mesh3.Triangles != null)
												{
													num4 += mesh3.Triangles.Length;
												}
											}
											_0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D._0023_003DzJltwz0y1myjKQO1O8w_003D_003D += num5;
											_0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D._0023_003DzPacMabcPoc4oQoC0UA_003D_003D += num4;
										}
									}
									else
									{
										_0023_003Dz_oAbKQB_0024bE8H _0023_003DzOLHnb2M_003D = _0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D;
										int _0023_003DzPacMabcPoc4oQoC0UA_003D_003D = _0023_003DzOLHnb2M_003D._0023_003DzPacMabcPoc4oQoC0UA_003D_003D;
										IndexTriangle[] triangles = surface.Triangles;
										_0023_003DzOLHnb2M_003D._0023_003DzPacMabcPoc4oQoC0UA_003D_003D = _0023_003DzPacMabcPoc4oQoC0UA_003D_003D + ((triangles != null) ? triangles.Length : 0);
									}
								}
								else
								{
									int num6 = 0;
									int num7 = 0;
									foreach (Solid.Portion portion in solid.Portions)
									{
										num7 += portion.VertexCount;
										if (portion.Triangles != null)
										{
											num6 += portion.Triangles.Length;
										}
									}
									_0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D._0023_003DzJltwz0y1myjKQO1O8w_003D_003D += num7;
									_0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D._0023_003DzPacMabcPoc4oQoC0UA_003D_003D += num6;
								}
							}
							else
							{
								_0023_003Dz_oAbKQB_0024bE8H _0023_003DzOLHnb2M_003D2 = _0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D;
								int _0023_003DzPacMabcPoc4oQoC0UA_003D_003D2 = _0023_003DzOLHnb2M_003D2._0023_003DzPacMabcPoc4oQoC0UA_003D_003D;
								IndexTriangle[] triangles2 = region.Triangles;
								_0023_003DzOLHnb2M_003D2._0023_003DzPacMabcPoc4oQoC0UA_003D_003D = _0023_003DzPacMabcPoc4oQoC0UA_003D_003D2 + ((triangles2 != null) ? triangles2.Length : 0);
							}
						}
						else
						{
							_0023_003Dz_oAbKQB_0024bE8H _0023_003DzOLHnb2M_003D3 = _0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D;
							int _0023_003DzPacMabcPoc4oQoC0UA_003D_003D3 = _0023_003DzOLHnb2M_003D3._0023_003DzPacMabcPoc4oQoC0UA_003D_003D;
							IndexTriangle[] triangles3 = mesh.Triangles;
							_0023_003DzOLHnb2M_003D3._0023_003DzPacMabcPoc4oQoC0UA_003D_003D = _0023_003DzPacMabcPoc4oQoC0UA_003D_003D3 + ((triangles3 != null) ? triangles3.Length : 0);
						}
					}
					else
					{
						_0023_003Dz_oAbKQB_0024bE8H _0023_003DzOLHnb2M_003D4 = _0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D;
						int _0023_003DzPacMabcPoc4oQoC0UA_003D_003D4 = _0023_003DzOLHnb2M_003D4._0023_003DzPacMabcPoc4oQoC0UA_003D_003D;
						IndexTriangle[] triangles4 = bar.Triangles;
						_0023_003DzOLHnb2M_003D4._0023_003DzPacMabcPoc4oQoC0UA_003D_003D = _0023_003DzPacMabcPoc4oQoC0UA_003D_003D4 + ((triangles4 != null) ? triangles4.Length : 0);
					}
				}
				else
				{
					_0023_003Dz_oAbKQB_0024bE8H _0023_003DzOLHnb2M_003D5 = _0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D;
					int _0023_003DzPacMabcPoc4oQoC0UA_003D_003D5 = _0023_003DzOLHnb2M_003D5._0023_003DzPacMabcPoc4oQoC0UA_003D_003D;
					IndexTriangle[] triangles5 = joint.Triangles;
					_0023_003DzOLHnb2M_003D5._0023_003DzPacMabcPoc4oQoC0UA_003D_003D = _0023_003DzPacMabcPoc4oQoC0UA_003D_003D5 + ((triangles5 != null) ? triangles5.Length : 0);
				}
			}
			else
			{
				_0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D._0023_003DzPacMabcPoc4oQoC0UA_003D_003D += 2;
			}
		}
		else
		{
			_0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D._0023_003DzPacMabcPoc4oQoC0UA_003D_003D++;
		}
		return _0023_003Dz2g6RT57NYPHki2BxsQGTnpo_003D2._0023_003DzOLHnb2M_003D;
	}

	private static void _0023_003DzQOtC1Mf2FWpv(_0023_003Dz_oAbKQB_0024bE8H _0023_003DzLg4y4i8_003D, _0023_003Dz_oAbKQB_0024bE8H _0023_003DzflHdm0uTKwpx)
	{
		lock (_0023_003DzLg4y4i8_003D)
		{
			_0023_003DzLg4y4i8_003D._0023_003DzbpLIUiI_003D += _0023_003DzflHdm0uTKwpx._0023_003DzbpLIUiI_003D;
			_0023_003DzLg4y4i8_003D._0023_003DzJltwz0y1myjKQO1O8w_003D_003D += _0023_003DzflHdm0uTKwpx._0023_003DzJltwz0y1myjKQO1O8w_003D_003D;
			_0023_003DzLg4y4i8_003D._0023_003DzPacMabcPoc4oQoC0UA_003D_003D += _0023_003DzflHdm0uTKwpx._0023_003DzPacMabcPoc4oQoC0UA_003D_003D;
			using IEnumerator<KeyValuePair<Type, int>> enumerator = _0023_003DzflHdm0uTKwpx._0023_003Dz3QHxwCaWnG9i.GetEnumerator();
			while (enumerator.MoveNext())
			{
				_0023_003DziN7DYA81qa_0024kjDuS0LTKYTs_003D _0023_003DziN7DYA81qa_0024kjDuS0LTKYTs_003D2 = new _0023_003DziN7DYA81qa_0024kjDuS0LTKYTs_003D();
				_0023_003DziN7DYA81qa_0024kjDuS0LTKYTs_003D2._0023_003Dz4okd4Qo_003D = enumerator.Current;
				_0023_003DzLg4y4i8_003D._0023_003Dz3QHxwCaWnG9i.AddOrUpdate(_0023_003DziN7DYA81qa_0024kjDuS0LTKYTs_003D2._0023_003Dz4okd4Qo_003D.Key, _0023_003DziN7DYA81qa_0024kjDuS0LTKYTs_003D2._0023_003Dz4okd4Qo_003D.Value, _0023_003DziN7DYA81qa_0024kjDuS0LTKYTs_003D2._0023_003Dz0KTTC6KkWKPs9pSkmg_003D_003D);
			}
		}
	}

	private static void _0023_003Dz9MXzPGXXCOqX(Entity _0023_003Dzs_0024uS8LA_003D, Dictionary<string, Block> _0023_003DzJO1FWlQ_003D, Dictionary<Type, IList<Entity>> _0023_003DzD1Qqr2OYgWRX, ref int _0023_003DzRVnqoMs_003D, List<Type> _0023_003DzHVNAyYVi80sh)
	{
		Type type = _0023_003Dzs_0024uS8LA_003D.GetType();
		if (_0023_003DzHVNAyYVi80sh != null && _0023_003DzHVNAyYVi80sh.Count > 0 && !_0023_003DzHVNAyYVi80sh.Contains(type))
		{
			return;
		}
		_0023_003DzRVnqoMs_003D++;
		if (_0023_003DzD1Qqr2OYgWRX.ContainsKey(type))
		{
			_0023_003DzD1Qqr2OYgWRX[type].Add(_0023_003Dzs_0024uS8LA_003D);
		}
		else
		{
			List<Entity> value = new List<Entity> { _0023_003Dzs_0024uS8LA_003D };
			_0023_003DzD1Qqr2OYgWRX.Add(type, value);
		}
		if (_0023_003DzJO1FWlQ_003D == null || !(type == typeof(BlockReference)))
		{
			return;
		}
		BlockReference blockReference = (BlockReference)_0023_003Dzs_0024uS8LA_003D;
		foreach (KeyValuePair<string, Block> item in _0023_003DzJO1FWlQ_003D)
		{
			if (!item.Key.Equals(blockReference.BlockName))
			{
				continue;
			}
			{
				foreach (Entity entity in item.Value.Entities)
				{
					_0023_003Dz9MXzPGXXCOqX(entity, _0023_003DzJO1FWlQ_003D, _0023_003DzD1Qqr2OYgWRX, ref _0023_003DzRVnqoMs_003D, _0023_003DzHVNAyYVi80sh);
				}
				break;
			}
		}
	}

	public static Dictionary<Type, IList<Entity>> GetEntitiesByType(IList<Entity> entityList, Dictionary<string, Block> blocks, List<Type> includedTypes = null)
	{
		Dictionary<Type, IList<Entity>> dictionary = new Dictionary<Type, IList<Entity>>();
		int _0023_003DzRVnqoMs_003D = 0;
		foreach (Entity entity in entityList)
		{
			_0023_003Dz9MXzPGXXCOqX(entity, blocks, dictionary, ref _0023_003DzRVnqoMs_003D, includedTypes);
		}
		return dictionary;
	}

	[Conditional("DRAW_BBOXES")]
	public static void DrawBoundingBox(RenderContextBase context, Point3D min, Point3D max)
	{
		if (!(min == null) && !(max == null))
		{
			Point3D[] boundingBoxCorners = GetBoundingBoxCorners(min, max);
			context.DrawLineLoop(new Point3D[4]
			{
				boundingBoxCorners[0],
				boundingBoxCorners[1],
				boundingBoxCorners[2],
				boundingBoxCorners[3]
			});
			context.DrawLineLoop(new Point3D[4]
			{
				boundingBoxCorners[4],
				boundingBoxCorners[5],
				boundingBoxCorners[6],
				boundingBoxCorners[7]
			});
			context.DrawLines(new Point3D[8]
			{
				boundingBoxCorners[0],
				boundingBoxCorners[4],
				boundingBoxCorners[1],
				boundingBoxCorners[5],
				boundingBoxCorners[2],
				boundingBoxCorners[6],
				boundingBoxCorners[3],
				boundingBoxCorners[7]
			});
		}
	}

	public static HashSet<string> GetReferencedBlocksNames(IList<Entity> entities, Dictionary<string, Block> blocks, Dictionary<string, Block> parentBlocks = null)
	{
		HashSet<string> hashSet = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
		_0023_003DzSx1RZy1qKE_6PWVD0g_003D_003D(blocks, hashSet, entities, parentBlocks);
		return hashSet;
	}

	private static void _0023_003DzSx1RZy1qKE_6PWVD0g_003D_003D(Dictionary<string, Block> _0023_003DzJO1FWlQ_003D, HashSet<string> _0023_003Dzgn9F5G0_003D, IList<Entity> _0023_003Dzv7xH9gk_003D, Dictionary<string, Block> _0023_003DzibJx_aY_e1oq)
	{
		foreach (Entity item in _0023_003Dzv7xH9gk_003D)
		{
			if (item is BlockReference blockReference)
			{
				_0023_003Dzgn9F5G0_003D.Add(blockReference.BlockName);
				_0023_003DzZj7X1KCHcb3zbfd5_0024Q_003D_003D(_0023_003DzJO1FWlQ_003D, blockReference, _0023_003Dzgn9F5G0_003D, _0023_003DzibJx_aY_e1oq);
			}
		}
	}

	private static void _0023_003DzZj7X1KCHcb3zbfd5_0024Q_003D_003D(Dictionary<string, Block> _0023_003DzJO1FWlQ_003D, BlockReference _0023_003Dz5I3b_GM_003D, HashSet<string> _0023_003Dzgn9F5G0_003D, Dictionary<string, Block> _0023_003DzibJx_aY_e1oq)
	{
		Block block = ((_0023_003DzJO1FWlQ_003D.ContainsKey(_0023_003Dz5I3b_GM_003D.BlockName) || _0023_003DzibJx_aY_e1oq == null || _0023_003DzibJx_aY_e1oq.Count <= 0) ? _0023_003DzJO1FWlQ_003D[_0023_003Dz5I3b_GM_003D.BlockName] : _0023_003DzibJx_aY_e1oq[_0023_003Dz5I3b_GM_003D.BlockName]);
		_0023_003DzSx1RZy1qKE_6PWVD0g_003D_003D(_0023_003DzJO1FWlQ_003D, _0023_003Dzgn9F5G0_003D, block.Entities, _0023_003DzibJx_aY_e1oq);
	}

	internal static void _0023_003DzBqhbUYI_0024vLjvzlHorg_003D_003D(IList<Entity> _0023_003Dzv7xH9gk_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, HashSet<Entity> _0023_003Dzd6rXGPzPgTjb)
	{
		if (_0023_003Dzv7xH9gk_003D == null || _0023_003Dzv7xH9gk_003D.Count == 0)
		{
			return;
		}
		if (_0023_003Dzd6rXGPzPgTjb == null)
		{
			_0023_003Dzd6rXGPzPgTjb = new HashSet<Entity>(_0023_003Dzv7xH9gk_003D.Count);
		}
		List<Entity> list = new List<Entity>();
		foreach (Entity item in _0023_003Dzv7xH9gk_003D)
		{
			if (item is BlockReference)
			{
				BlockReference blockReference = (BlockReference)item;
				if (_0023_003DzJO1FWlQ_003D != null)
				{
					list.AddRange(_0023_003DzJO1FWlQ_003D[blockReference.BlockName].Entities);
				}
			}
			else
			{
				_0023_003Dzd6rXGPzPgTjb.Add(item);
			}
		}
		_0023_003DzBqhbUYI_0024vLjvzlHorg_003D_003D(list, _0023_003DzJO1FWlQ_003D, _0023_003Dzd6rXGPzPgTjb);
	}

	internal static void Purge(IList<Entity> _0023_003Dzv7xH9gk_003D, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, TextStyleKeyedCollection _0023_003Dz9LJ7v7xBdLfO, LineTypeKeyedCollection _0023_003DzA3_0024EZ731xRIG, HatchPatternKeyedCollection _0023_003DzzX6rzVb3Ybsi, out LayerKeyedCollection _0023_003DzfchAzPg_003D, out BlockKeyedCollection _0023_003DzTKSsuc0_003D, out MaterialKeyedCollection _0023_003DzvEAegzCu5KMnKFso0g_003D_003D, out TextStyleKeyedCollection _0023_003DzIm3oyxMBrWGo, out LineTypeKeyedCollection _0023_003Dzl0O9h6oxpm0u, out HatchPatternKeyedCollection _0023_003Dz3b479cSvol0G, bool _0023_003DzkiaObrihH2G4 = true, bool _0023_003DzVUweAlrIUUDr = false)
	{
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		HashSet<string> hashSet2 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		HashSet<string> hashSet3 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		HashSet<string> hashSet4 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		HashSet<string> hashSet5 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		HashSet<string> hashSet6 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		_0023_003DzfchAzPg_003D = new LayerKeyedCollection();
		_0023_003DzTKSsuc0_003D = new BlockKeyedCollection();
		_0023_003DzvEAegzCu5KMnKFso0g_003D_003D = new MaterialKeyedCollection();
		_0023_003DzIm3oyxMBrWGo = new TextStyleKeyedCollection();
		_0023_003Dzl0O9h6oxpm0u = new LineTypeKeyedCollection();
		_0023_003Dz3b479cSvol0G = new HatchPatternKeyedCollection();
		if (_0023_003DzJO1FWlQ_003D.hasRootBlock)
		{
			hashSet2.Add(_0023_003DzJO1FWlQ_003D.RootBlockName);
			_0023_003DzTKSsuc0_003D.SetRootBlock(_0023_003DzJO1FWlQ_003D.RootBlockName);
		}
		_0023_003DzAUWerqJHpVcH(_0023_003Dzv7xH9gk_003D, _0023_003DzeWJg3NJnk3WA, _0023_003DzJO1FWlQ_003D, hashSet, hashSet2, hashSet3, hashSet4, hashSet5, hashSet6, _0023_003DzJtANkiFLnFgJ: true);
		_0023_003DzeuqreBmn_tGn(_0023_003DzeWJg3NJnk3WA, _0023_003DzfchAzPg_003D, hashSet, _0023_003DzkiaObrihH2G4, _0023_003DzVUweAlrIUUDr);
		_0023_003DzeuqreBmn_tGn(_0023_003DzJO1FWlQ_003D, _0023_003DzTKSsuc0_003D, hashSet2, _0023_003DzkiaObrihH2G4, _0023_003DzVUweAlrIUUDr);
		_0023_003DzeuqreBmn_tGn(_0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, _0023_003DzvEAegzCu5KMnKFso0g_003D_003D, hashSet3, _0023_003DzkiaObrihH2G4, _0023_003DzVUweAlrIUUDr);
		_0023_003DzeuqreBmn_tGn(_0023_003Dz9LJ7v7xBdLfO, _0023_003DzIm3oyxMBrWGo, hashSet4, _0023_003DzkiaObrihH2G4, _0023_003DzVUweAlrIUUDr);
		_0023_003DzeuqreBmn_tGn(_0023_003DzA3_0024EZ731xRIG, _0023_003Dzl0O9h6oxpm0u, hashSet5, _0023_003DzkiaObrihH2G4, _0023_003DzVUweAlrIUUDr);
		_0023_003DzeuqreBmn_tGn(_0023_003DzzX6rzVb3Ybsi, _0023_003Dz3b479cSvol0G, hashSet6, _0023_003DzkiaObrihH2G4, _0023_003DzVUweAlrIUUDr);
	}

	private static void _0023_003DzAUWerqJHpVcH(IList<Entity> _0023_003Dzv7xH9gk_003D, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, HashSet<string> _0023_003DzfO5SdN7F5QX1, HashSet<string> _0023_003Dz25nZSuNUZn5v, HashSet<string> _0023_003Dz3lL9qI71D1kkYHFloQ_003D_003D, HashSet<string> _0023_003DzF6udMxwPsuP9, HashSet<string> _0023_003DzEyss3CT_0024ud_w, HashSet<string> _0023_003DzE95EeO6mN_0024Bi, bool _0023_003DzJtANkiFLnFgJ)
	{
		foreach (Entity item2 in _0023_003Dzv7xH9gk_003D)
		{
			_0023_003DzfO5SdN7F5QX1.Add(item2.LayerName);
			if (item2.ColorMethod == colorMethodType.byEntity)
			{
				_0023_003Dz3lL9qI71D1kkYHFloQ_003D_003D.Add(item2.MaterialName);
			}
			if (item2.LineTypeMethod == colorMethodType.byEntity)
			{
				_0023_003DzEyss3CT_0024ud_w.Add(item2.LineTypeName);
			}
			if (item2 is Hatch hatch)
			{
				_0023_003DzE95EeO6mN_0024Bi.Add(hatch.PatternName);
			}
			else if (item2 is Text text)
			{
				_0023_003DzF6udMxwPsuP9.Add(text.StyleName);
			}
			else if (item2 is Table table)
			{
				for (int i = 0; i < table.RowsNum; i++)
				{
					for (int j = 0; j < table.ColumnsNum; j++)
					{
						_0023_003DzF6udMxwPsuP9.Add(table.GetStyleName(i, j));
					}
				}
			}
			else if (item2 is BlockReference blockReference)
			{
				if (blockReference.Attributes != null)
				{
					foreach (KeyValuePair<string, AttributeReference> attribute in blockReference.Attributes)
					{
						_0023_003DzF6udMxwPsuP9.Add(attribute.Value.StyleName);
						_0023_003DzfO5SdN7F5QX1.Add(attribute.Value.LayerName);
					}
				}
				_0023_003Dz25nZSuNUZn5v.Add(blockReference.BlockName);
				if (_0023_003DzJO1FWlQ_003D.TryGetValue(blockReference.BlockName, out var value))
				{
					_0023_003DzAUWerqJHpVcH(value.Entities, _0023_003DzeWJg3NJnk3WA, _0023_003DzJO1FWlQ_003D, _0023_003DzfO5SdN7F5QX1, _0023_003Dz25nZSuNUZn5v, _0023_003Dz3lL9qI71D1kkYHFloQ_003D_003D, _0023_003DzF6udMxwPsuP9, _0023_003DzEyss3CT_0024ud_w, _0023_003DzE95EeO6mN_0024Bi, _0023_003DzJtANkiFLnFgJ: false);
				}
			}
			if (item2.EntityData is Entity item)
			{
				_0023_003DzAUWerqJHpVcH(new List<Entity> { item }, _0023_003DzeWJg3NJnk3WA, _0023_003DzJO1FWlQ_003D, _0023_003DzfO5SdN7F5QX1, _0023_003Dz25nZSuNUZn5v, _0023_003Dz3lL9qI71D1kkYHFloQ_003D_003D, _0023_003DzF6udMxwPsuP9, _0023_003DzEyss3CT_0024ud_w, _0023_003DzE95EeO6mN_0024Bi, _0023_003DzJtANkiFLnFgJ: false);
			}
		}
		if (!_0023_003DzJtANkiFLnFgJ || _0023_003DzeWJg3NJnk3WA.Count <= 0)
		{
			return;
		}
		foreach (string item3 in _0023_003DzfO5SdN7F5QX1)
		{
			Layer layer = _0023_003DzeWJg3NJnk3WA[item3];
			_0023_003Dz3lL9qI71D1kkYHFloQ_003D_003D.Add(layer.MaterialName);
			_0023_003DzEyss3CT_0024ud_w.Add(layer.LineTypeName);
		}
	}

	private static void _0023_003DzeuqreBmn_tGn<T>(EyeshotKeyedCollection<T> _0023_003Dze2YLPPGWDCCB, EyeshotKeyedCollection<T> _0023_003DzsN98_0024xQ_003D, HashSet<string> _0023_003Dz2m6Cvx696GwE, bool _0023_003DzkiaObrihH2G4, bool _0023_003DzVUweAlrIUUDr) where T : IKeyedCollectionItem<T>
	{
		HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		foreach (string item in _0023_003Dz2m6Cvx696GwE)
		{
			if (!string.IsNullOrEmpty(item))
			{
				hashSet.Add(item);
			}
		}
		if (_0023_003DzkiaObrihH2G4)
		{
			foreach (T item2 in _0023_003Dze2YLPPGWDCCB)
			{
				if (hashSet.Contains(item2.GetKey()))
				{
					_0023_003DzsN98_0024xQ_003D.Add(item2);
				}
				else if (_0023_003DzVUweAlrIUUDr && item2 is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			return;
		}
		foreach (string item3 in hashSet)
		{
			_0023_003DzsN98_0024xQ_003D.Add(_0023_003Dze2YLPPGWDCCB[item3]);
		}
		if (!_0023_003DzVUweAlrIUUDr)
		{
			return;
		}
		foreach (IDisposable item4 in _0023_003Dze2YLPPGWDCCB.Except(_0023_003DzsN98_0024xQ_003D).Where(_0023_003Dz1opDSaEWcXR7ARRgjA_003D_003D<T>._0023_003DzJ5g3Rwo_003D._0023_003DzowbF4GHjp7AllUjBNfDPNpo_003D).Cast<IDisposable>()
			.ToList())
		{
			item4.Dispose();
		}
	}

	internal static byte _0023_003DzdceBluUVGYUs(float _0023_003DzPzO_0024GUk_003D, float _0023_003DzF7v9r2A_003D, float _0023_003Dz8dK2uhU_003D)
	{
		float num = _0023_003Dz8dK2uhU_003D - _0023_003DzF7v9r2A_003D;
		return (byte)((_0023_003DzPzO_0024GUk_003D - _0023_003DzF7v9r2A_003D) * 255f / num);
	}

	internal static ushort _0023_003DzdceBluUVGYUs(byte _0023_003DzPzO_0024GUk_003D, byte _0023_003DzF7v9r2A_003D, byte _0023_003Dz8dK2uhU_003D)
	{
		int num = _0023_003Dz8dK2uhU_003D - _0023_003DzF7v9r2A_003D;
		return (ushort)((_0023_003DzPzO_0024GUk_003D - _0023_003DzF7v9r2A_003D) * 65535 / num);
	}

	public static int ComputeItemsCount(IEnumerable<Entity> entList, BlockKeyedCollection blocks)
	{
		int num = 0;
		foreach (Entity ent in entList)
		{
			if (ent is BlockReference blockReference)
			{
				if (blocks.TryGetValue(blockReference.BlockName, out var value))
				{
					num += ComputeItemsCount(value.Entities, blocks);
				}
			}
			else
			{
				num++;
			}
		}
		return num;
	}

	public static int ComputeVisibleItemsCount(IEnumerable<Entity> entList, BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		int num = 0;
		foreach (Entity ent in entList)
		{
			if (!ent.Visible || !layers.GetItemFast(ent.LayerName).Visible)
			{
				continue;
			}
			if (ent is BlockReference blockReference)
			{
				if (blocks.TryGetValue(blockReference.BlockName, out var value))
				{
					num += ComputeItemsCount(value.Entities, blocks);
				}
			}
			else
			{
				num++;
			}
		}
		return num;
	}

	public static void CountNodes(IList<Entity> entList, BlockKeyedCollection blocks, out int fullNodeCount, out int emptyNodeCount, out int totalObjectCount)
	{
		fullNodeCount = 0;
		emptyNodeCount = 0;
		_0023_003DzGGsDEKAPI70t(entList, blocks, ref fullNodeCount, ref emptyNodeCount);
		totalObjectCount = ComputeItemsCount(entList, blocks);
	}

	private static void _0023_003DzGGsDEKAPI70t(IEnumerable<Entity> _0023_003DzWc9WmS8VMsuA, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ref int _0023_003DzVukOyaG4WZdX, ref int _0023_003DzPLSXxXtSXf2o)
	{
		bool flag = true;
		foreach (Entity item in _0023_003DzWc9WmS8VMsuA)
		{
			if (item is BlockReference blockReference)
			{
				if (_0023_003DzJO1FWlQ_003D.TryGetValue(blockReference.BlockName, out var value))
				{
					_0023_003DzGGsDEKAPI70t(value.Entities, _0023_003DzJO1FWlQ_003D, ref _0023_003DzVukOyaG4WZdX, ref _0023_003DzPLSXxXtSXf2o);
				}
			}
			else
			{
				flag = false;
			}
		}
		if (flag)
		{
			_0023_003DzPLSXxXtSXf2o++;
		}
		else
		{
			_0023_003DzVukOyaG4WZdX++;
		}
	}

	public static ICurve[] GetLogo()
	{
		ICurve[] array = new ICurve[23];
		Point4D[] ctrlPoints = new Point4D[37]
		{
			new Point4D(144.01559636186, -190.6826, 0.0, 1.0),
			new Point4D(143.701196369802, -190.6826, 0.0, 1.0),
			new Point4D(143.387696377722, -190.8389, 0.0, 1.0),
			new Point4D(143.073696385654, -190.8389, 0.0, 1.0),
			new Point4D(143.073696385654, -190.8389, 0.0, 1.0),
			new Point4D(120.929196945072, -194.1377, 0.0, 1.0),
			new Point4D(120.929196945072, -194.1377, 0.0, 1.0),
			new Point4D(118.259797012506, -194.6084, 0.0, 1.0),
			new Point4D(117.631297028383, -196.0215, 0.0, 1.0),
			new Point4D(117.631297028383, -198.6914, 0.0, 1.0),
			new Point4D(117.631297028383, -198.6914, 0.0, 1.0),
			new Point4D(117.631297028383, -217.2236, 0.0, 1.0),
			new Point4D(117.631297028383, -217.2236, 0.0, 1.0),
			new Point4D(117.631297028383, -217.2236, 0.0, 1.0),
			new Point4D(119.202096988702, -227.2744, 0.0, 1.0),
			new Point4D(119.202096988702, -227.2744, 0.0, 1.0),
			new Point4D(119.202096988702, -227.2744, 0.0, 1.0),
			new Point4D(110.407697210867, -224.4482, 0.0, 1.0),
			new Point4D(99.4141, -224.4482, 0.0, 1.0),
			new Point4D(72.4013999999997, -224.4482, 0.0, 1.0),
			new Point4D(66.5907999999999, -242.9785, 0.0, 1.0),
			new Point4D(66.5907999999999, -268.7354, 0.0, 1.0),
			new Point4D(66.5907999999999, -302.9717, 0.0, 1.0),
			new Point4D(78.9979999999996, -310.982400000001, 0.0, 1.0),
			new Point4D(109.93649722277, -310.982400000001, 0.0, 1.0),
			new Point4D(118.573697004576, -310.982400000001, 0.0, 1.0),
			new Point4D(129.724096722894, -309.882799999999, 0.0, 1.0),
			new Point4D(138.205096508646, -307.2129, 0.0, 1.0),
			new Point4D(146.528296298384, -304.543, 0.0, 1.0),
			new Point4D(147.156696282509, -298.7314, 0.0, 1.0),
			new Point4D(147.156696282509, -294.8057, 0.0, 1.0),
			new Point4D(147.156696282509, -294.8057, 0.0, 1.0),
			new Point4D(147.156696282509, -193.8223, 0.0, 1.0),
			new Point4D(147.156696282509, -193.8223, 0.0, 1.0),
			new Point4D(147.156696282509, -191.625, 0.0, 1.0),
			new Point4D(145.743696318205, -190.6826, 0.0, 1.0),
			new Point4D(144.01559636186, -190.6826, 0.0, 1.0)
		};
		double[] knotVector = new double[41]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 7.0, 7.0, 7.0, 8.0, 8.0, 8.0, 9.0, 9.0,
			9.0, 10.0, 10.0, 10.0, 11.0, 11.0, 11.0, 12.0, 12.0, 12.0,
			12.0
		};
		array[0] = new Curve(3, knotVector, ctrlPoints);
		Point4D[] ctrlPoints2 = new Point4D[16]
		{
			new Point4D(117.631297028383, -290.8799, 0.0, 1.0),
			new Point4D(117.631297028383, -290.8799, 0.0, 1.0),
			new Point4D(113.547897131539, -291.8213, 0.0, 1.0),
			new Point4D(109.93649722277, -291.8213, 0.0, 1.0),
			new Point4D(99.4141, -291.8213, 0.0, 1.0),
			new Point4D(96.5874000000003, -289.4668, 0.0, 1.0),
			new Point4D(96.5874000000003, -266.5361, 0.0, 1.0),
			new Point4D(96.5874000000003, -244.5498, 0.0, 1.0),
			new Point4D(99.1000999999997, -243.7646, 0.0, 1.0),
			new Point4D(108.67969725452, -243.7646, 0.0, 1.0),
			new Point4D(111.97749717121, -243.7646, 0.0, 1.0),
			new Point4D(117.631297028383, -244.5498, 0.0, 1.0),
			new Point4D(117.631297028383, -244.5498, 0.0, 1.0),
			new Point4D(117.631297028383, -244.5498, 0.0, 1.0),
			new Point4D(117.631297028383, -290.8799, 0.0, 1.0),
			new Point4D(117.631297028383, -290.8799, 0.0, 1.0)
		};
		double[] knotVector2 = new double[20]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 5.0
		};
		array[1] = new Curve(3, knotVector2, ctrlPoints2);
		Point4D[] ctrlPoints3 = new Point4D[49]
		{
			new Point4D(195.675295056826, -224.4482, 0.0, 1.0),
			new Point4D(165.521495818575, -224.4482, 0.0, 1.0),
			new Point4D(154.685496092316, -235.7559, 0.0, 1.0),
			new Point4D(154.685496092316, -268.4219, 0.0, 1.0),
			new Point4D(154.685496092316, -300.9307, 0.0, 1.0),
			new Point4D(169.60449571543, -310.982400000001, 0.0, 1.0),
			new Point4D(200.229494941777, -310.982400000001, 0.0, 1.0),
			new Point4D(214.99219456884, -310.982400000001, 0.0, 1.0),
			new Point4D(225.82859429509, -307.3701, 0.0, 1.0),
			new Point4D(230.226094183999, -305.484399999999, 0.0, 1.0),
			new Point4D(231.325194156234, -305.170899999999, 0.0, 1.0),
			new Point4D(232.267594132427, -304.0713, 0.0, 1.0),
			new Point4D(232.267594132427, -302.501, 0.0, 1.0),
			new Point4D(232.267594132427, -302.1875, 0.0, 1.0),
			new Point4D(232.110394136398, -301.872100000001, 0.0, 1.0),
			new Point4D(232.110394136398, -301.401400000001, 0.0, 1.0),
			new Point4D(232.110394136398, -301.401400000001, 0.0, 1.0),
			new Point4D(229.754394195916, -291.3506, 0.0, 1.0),
			new Point4D(229.754394195916, -291.3506, 0.0, 1.0),
			new Point4D(229.284194207794, -289.623, 0.0, 1.0),
			new Point4D(228.027294239546, -288.5244, 0.0, 1.0),
			new Point4D(226.928194267312, -288.5244, 0.0, 1.0),
			new Point4D(226.928194267312, -288.5244, 0.0, 1.0),
			new Point4D(226.456494279228, -288.5244, 0.0, 1.0),
			new Point4D(226.456494279228, -288.5244, 0.0, 1.0),
			new Point4D(223.943794342704, -289.1514, 0.0, 1.0),
			new Point4D(214.99219456884, -292.1357, 0.0, 1.0),
			new Point4D(205.569294806883, -292.1357, 0.0, 1.0),
			new Point4D(199.444294961613, -292.1357, 0.0, 1.0),
			new Point4D(194.732395080646, -291.5078, 0.0, 1.0),
			new Point4D(191.434595163955, -290.251, 0.0, 1.0),
			new Point4D(186.09519529884, -288.3672, 0.0, 1.0),
			new Point4D(183.896495354384, -284.5977, 0.0, 1.0),
			new Point4D(183.896495354384, -279.1006, 0.0, 1.0),
			new Point4D(183.896495354384, -279.1006, 0.0, 1.0),
			new Point4D(231.482394152263, -279.1006, 0.0, 1.0),
			new Point4D(231.482394152263, -279.1006, 0.0, 1.0),
			new Point4D(235.408194053089, -279.1006, 0.0, 1.0),
			new Point4D(236.036594037214, -276.4307, 0.0, 1.0),
			new Point4D(236.036594037214, -273.918, 0.0, 1.0),
			new Point4D(236.036594037214, -273.918, 0.0, 1.0),
			new Point4D(236.036594037214, -266.3799, 0.0, 1.0),
			new Point4D(236.036594037214, -266.3799, 0.0, 1.0),
			new Point4D(236.036594037214, -251.3027, 0.0, 1.0),
			new Point4D(233.680694096729, -240.624, 0.0, 1.0),
			new Point4D(226.928194267312, -233.7139, 0.0, 1.0),
			new Point4D(220.802694422055, -227.4316, 0.0, 1.0),
			new Point4D(210.752, -224.4482, 0.0, 1.0),
			new Point4D(195.675295056826, -224.4482, 0.0, 1.0)
		};
		double[] knotVector3 = new double[53]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 7.0, 7.0, 7.0, 8.0, 8.0, 8.0, 9.0, 9.0,
			9.0, 10.0, 10.0, 10.0, 11.0, 11.0, 11.0, 12.0, 12.0, 12.0,
			13.0, 13.0, 13.0, 14.0, 14.0, 14.0, 15.0, 15.0, 15.0, 16.0,
			16.0, 16.0, 16.0
		};
		array[2] = new Curve(3, knotVector3, ctrlPoints3);
		Point4D[] ctrlPoints4 = new Point4D[19]
		{
			new Point4D(207.296394763252, -262.4531, 0.0, 1.0),
			new Point4D(207.296394763252, -262.4531, 0.0, 1.0),
			new Point4D(183.896495354384, -262.4531, 0.0, 1.0),
			new Point4D(183.896495354384, -262.4531, 0.0, 1.0),
			new Point4D(183.896495354384, -258.2139, 0.0, 1.0),
			new Point4D(183.896495354384, -255.0723, 0.0, 1.0),
			new Point4D(184.36769534248, -251.9316, 0.0, 1.0),
			new Point4D(185.152795322647, -246.4346, 0.0, 1.0),
			new Point4D(187.823195255187, -243.2939, 0.0, 1.0),
			new Point4D(196.303195040964, -243.2939, 0.0, 1.0),
			new Point4D(201.957, -243.2939, 0.0, 1.0),
			new Point4D(205.569294806883, -245.6494, 0.0, 1.0),
			new Point4D(206.825694775143, -252.873, 0.0, 1.0),
			new Point4D(207.139594767214, -255.0723, 0.0, 1.0),
			new Point4D(207.454094759269, -257.1143, 0.0, 1.0),
			new Point4D(207.454094759269, -259.9404, 0.0, 1.0),
			new Point4D(207.454094759269, -260.7266, 0.0, 1.0),
			new Point4D(207.454094759269, -261.668, 0.0, 1.0),
			new Point4D(207.296394763252, -262.4531, 0.0, 1.0)
		};
		double[] knotVector4 = new double[23]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 6.0
		};
		array[3] = new Curve(3, knotVector4, ctrlPoints4);
		Point4D[] ctrlPoints5 = new Point4D[49]
		{
			new Point4D(318.173791962254, -226.4897, 0.0, 1.0),
			new Point4D(318.173791962254, -226.4897, 0.0, 1.0),
			new Point4D(295.872092525642, -226.4897, 0.0, 1.0),
			new Point4D(295.872092525642, -226.4897, 0.0, 1.0),
			new Point4D(293.673792581176, -226.4897, 0.0, 1.0),
			new Point4D(292.259792616896, -226.9614, 0.0, 1.0),
			new Point4D(291.789092628787, -229.6313, 0.0, 1.0),
			new Point4D(291.789092628787, -229.6313, 0.0, 1.0),
			new Point4D(281.581092886663, -291.0381, 0.0, 1.0),
			new Point4D(281.581092886663, -291.0381, 0.0, 1.0),
			new Point4D(281.581092886663, -291.0381, 0.0, 1.0),
			new Point4D(277.340792993782, -291.0381, 0.0, 1.0),
			new Point4D(277.340792993782, -291.0381, 0.0, 1.0),
			new Point4D(277.340792993782, -291.0381, 0.0, 1.0),
			new Point4D(265.876, -229.4741, 0.0, 1.0),
			new Point4D(265.876, -229.4741, 0.0, 1.0),
			new Point4D(265.405293295298, -226.8042, 0.0, 1.0),
			new Point4D(263.991193331021, -226.4897, 0.0, 1.0),
			new Point4D(261.793, -226.4897, 0.0, 1.0),
			new Point4D(261.793, -226.4897, 0.0, 1.0),
			new Point4D(239.334493953902, -226.4897, 0.0, 1.0),
			new Point4D(239.334493953902, -226.4897, 0.0, 1.0),
			new Point4D(237.293, -226.4897, 0.0, 1.0),
			new Point4D(236.036594037214, -227.9028, 0.0, 1.0),
			new Point4D(236.036594037214, -229.7876, 0.0, 1.0),
			new Point4D(236.036594037214, -230.1011, 0.0, 1.0),
			new Point4D(236.036594037214, -230.5737, 0.0, 1.0),
			new Point4D(236.193394033253, -231.0444, 0.0, 1.0),
			new Point4D(236.193394033253, -231.0444, 0.0, 1.0),
			new Point4D(255.982393533341, -306.426799999999, 0.0, 1.0),
			new Point4D(255.982393533341, -306.426799999999, 0.0, 1.0),
			new Point4D(256.295893525421, -307.8408, 0.0, 1.0),
			new Point4D(257.238293501614, -308.9404, 0.0, 1.0),
			new Point4D(258.808593461945, -308.9404, 0.0, 1.0),
			new Point4D(258.808593461945, -308.9404, 0.0, 1.0),
			new Point4D(299.012692446304, -308.9404, 0.0, 1.0),
			new Point4D(299.012692446304, -308.9404, 0.0, 1.0),
			new Point4D(300.584, -308.9404, 0.0, 1.0),
			new Point4D(301.369092386776, -307.8408, 0.0, 1.0),
			new Point4D(301.839792374885, -306.426799999999, 0.0, 1.0),
			new Point4D(301.839792374885, -306.426799999999, 0.0, 1.0),
			new Point4D(321.628891874971, -231.0444, 0.0, 1.0),
			new Point4D(321.628891874971, -231.0444, 0.0, 1.0),
			new Point4D(321.628891874971, -230.5737, 0.0, 1.0),
			new Point4D(321.786091870999, -230.2583, 0.0, 1.0),
			new Point4D(321.786091870999, -229.7876, 0.0, 1.0),
			new Point4D(321.786091870999, -227.9028, 0.0, 1.0),
			new Point4D(320.37209190672, -226.4897, 0.0, 1.0),
			new Point4D(318.173791962254, -226.4897, 0.0, 1.0)
		};
		double[] knotVector5 = new double[53]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 7.0, 7.0, 7.0, 8.0, 8.0, 8.0, 9.0, 9.0,
			9.0, 10.0, 10.0, 10.0, 11.0, 11.0, 11.0, 12.0, 12.0, 12.0,
			13.0, 13.0, 13.0, 14.0, 14.0, 14.0, 15.0, 15.0, 15.0, 16.0,
			16.0, 16.0, 16.0
		};
		array[4] = new Curve(3, knotVector5, ctrlPoints5);
		Point4D[] ctrlPoints6 = new Point4D[49]
		{
			new Point4D(544.661086240703, -224.4482, 0.0, 1.0),
			new Point4D(514.50778700244, -224.4482, 0.0, 1.0),
			new Point4D(503.672887276152, -235.7559, 0.0, 1.0),
			new Point4D(503.672887276152, -268.4219, 0.0, 1.0),
			new Point4D(503.672887276152, -300.9307, 0.0, 1.0),
			new Point4D(518.592786899244, -310.982400000001, 0.0, 1.0),
			new Point4D(549.215786125642, -310.982400000001, 0.0, 1.0),
			new Point4D(563.979485752679, -310.982400000001, 0.0, 1.0),
			new Point4D(574.814485478964, -307.3701, 0.0, 1.0),
			new Point4D(579.212885367851, -305.484399999999, 0.0, 1.0),
			new Point4D(580.312485340073, -305.170899999999, 0.0, 1.0),
			new Point4D(581.254885316266, -304.0713, 0.0, 1.0),
			new Point4D(581.254885316266, -302.501, 0.0, 1.0),
			new Point4D(581.254885316266, -302.1875, 0.0, 1.0),
			new Point4D(581.097685320237, -301.872100000001, 0.0, 1.0),
			new Point4D(581.097685320237, -301.401400000001, 0.0, 1.0),
			new Point4D(581.097685320237, -301.401400000001, 0.0, 1.0),
			new Point4D(578.742185379742, -291.3506, 0.0, 1.0),
			new Point4D(578.742185379742, -291.3506, 0.0, 1.0),
			new Point4D(578.270485391658, -289.623, 0.0, 1.0),
			new Point4D(577.013685423408, -288.5244, 0.0, 1.0),
			new Point4D(575.915999999999, -288.5244, 0.0, 1.0),
			new Point4D(575.915999999999, -288.5244, 0.0, 1.0),
			new Point4D(575.443385463077, -288.5244, 0.0, 1.0),
			new Point4D(575.443385463077, -288.5244, 0.0, 1.0),
			new Point4D(572.930685526553, -289.1514, 0.0, 1.0),
			new Point4D(563.979485752679, -292.1357, 0.0, 1.0),
			new Point4D(554.555685990745, -292.1357, 0.0, 1.0),
			new Point4D(548.431586145452, -292.1357, 0.0, 1.0),
			new Point4D(543.719686264485, -291.5078, 0.0, 1.0),
			new Point4D(540.421886347795, -290.251, 0.0, 1.0),
			new Point4D(535.082, -288.3672, 0.0, 1.0),
			new Point4D(532.882786538248, -284.5977, 0.0, 1.0),
			new Point4D(532.882786538248, -279.1006, 0.0, 1.0),
			new Point4D(532.882786538248, -279.1006, 0.0, 1.0),
			new Point4D(580.469685336102, -279.1006, 0.0, 1.0),
			new Point4D(580.469685336102, -279.1006, 0.0, 1.0),
			new Point4D(584.395485236928, -279.1006, 0.0, 1.0),
			new Point4D(585.022485221089, -276.4307, 0.0, 1.0),
			new Point4D(585.022485221089, -273.918, 0.0, 1.0),
			new Point4D(585.022485221089, -273.918, 0.0, 1.0),
			new Point4D(585.022485221089, -266.3799, 0.0, 1.0),
			new Point4D(585.022485221089, -266.3799, 0.0, 1.0),
			new Point4D(585.022485221089, -251.3027, 0.0, 1.0),
			new Point4D(582.668, -240.624, 0.0, 1.0),
			new Point4D(575.915999999999, -233.7139, 0.0, 1.0),
			new Point4D(569.789085605917, -227.4316, 0.0, 1.0),
			new Point4D(559.738285859821, -224.4482, 0.0, 1.0),
			new Point4D(544.661086240703, -224.4482, 0.0, 1.0)
		};
		double[] knotVector6 = new double[53]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 7.0, 7.0, 7.0, 8.0, 8.0, 8.0, 9.0, 9.0,
			9.0, 10.0, 10.0, 10.0, 11.0, 11.0, 11.0, 12.0, 12.0, 12.0,
			13.0, 13.0, 13.0, 14.0, 14.0, 14.0, 15.0, 15.0, 15.0, 16.0,
			16.0, 16.0, 16.0
		};
		array[5] = new Curve(3, knotVector6, ctrlPoints6);
		Point4D[] ctrlPoints7 = new Point4D[19]
		{
			new Point4D(556.284185947079, -262.4531, 0.0, 1.0),
			new Point4D(556.284185947079, -262.4531, 0.0, 1.0),
			new Point4D(532.882786538248, -262.4531, 0.0, 1.0),
			new Point4D(532.882786538248, -262.4531, 0.0, 1.0),
			new Point4D(532.882786538248, -258.2139, 0.0, 1.0),
			new Point4D(532.882786538248, -255.0723, 0.0, 1.0),
			new Point4D(533.355486526307, -251.9316, 0.0, 1.0),
			new Point4D(534.139586506499, -246.4346, 0.0, 1.0),
			new Point4D(536.809586439049, -243.2939, 0.0, 1.0),
			new Point4D(545.290000000001, -243.2939, 0.0, 1.0),
			new Point4D(550.944286081976, -243.2939, 0.0, 1.0),
			new Point4D(554.555685990745, -245.6494, 0.0, 1.0),
			new Point4D(555.81348595897, -252.873, 0.0, 1.0),
			new Point4D(556.127, -255.0723, 0.0, 1.0),
			new Point4D(556.440385943133, -257.1143, 0.0, 1.0),
			new Point4D(556.440385943133, -259.9404, 0.0, 1.0),
			new Point4D(556.440385943133, -260.7266, 0.0, 1.0),
			new Point4D(556.440385943133, -261.668, 0.0, 1.0),
			new Point4D(556.284185947079, -262.4531, 0.0, 1.0)
		};
		double[] knotVector7 = new double[23]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 6.0
		};
		array[6] = new Curve(3, knotVector7, ctrlPoints7);
		Point4D[] ctrlPoints8 = new Point4D[37]
		{
			new Point4D(637.621083892336, -224.6045, 0.0, 1.0),
			new Point4D(626.785184166074, -224.6045, 0.0, 1.0),
			new Point4D(614.691384471589, -225.8613, 0.0, 1.0),
			new Point4D(604.012684741356, -229.1602, 0.0, 1.0),
			new Point4D(597.730484900057, -231.0439, 0.0, 1.0),
			new Point4D(592.548785030958, -232.7705, 0.0, 1.0),
			new Point4D(592.548785030958, -242.8223, 0.0, 1.0),
			new Point4D(592.548785030958, -242.8223, 0.0, 1.0),
			new Point4D(592.548785030958, -338.7793, 0.0, 1.0),
			new Point4D(592.548785030958, -338.7793, 0.0, 1.0),
			new Point4D(592.548785030958, -341.135700000001, 0.0, 1.0),
			new Point4D(593.96188499526, -341.919900000001, 0.0, 1.0),
			new Point4D(595.688484951643, -341.919900000001, 0.0, 1.0),
			new Point4D(596.002, -341.919900000001, 0.0, 1.0),
			new Point4D(596.316384935781, -341.919900000001, 0.0, 1.0),
			new Point4D(596.788084923865, -341.762699999999, 0.0, 1.0),
			new Point4D(596.788084923865, -341.762699999999, 0.0, 1.0),
			new Point4D(618.931584364473, -338.4648, 0.0, 1.0),
			new Point4D(618.931584364473, -338.4648, 0.0, 1.0),
			new Point4D(621.444284300997, -338.1504, 0.0, 1.0),
			new Point4D(622.073184285109, -336.581099999999, 0.0, 1.0),
			new Point4D(622.073184285109, -333.911099999999, 0.0, 1.0),
			new Point4D(622.073184285109, -333.911099999999, 0.0, 1.0),
			new Point4D(622.073184285109, -318.5205, 0.0, 1.0),
			new Point4D(622.073184285109, -318.5205, 0.0, 1.0),
			new Point4D(622.073184285109, -318.5205, 0.0, 1.0),
			new Point4D(620.345684328749, -308.1543, 0.0, 1.0),
			new Point4D(620.345684328749, -308.1543, 0.0, 1.0),
			new Point4D(626.312484178015, -309.882799999999, 0.0, 1.0),
			new Point4D(632.910184011344, -310.982400000001, 0.0, 1.0),
			new Point4D(640.605483816944, -310.982400000001, 0.0, 1.0),
			new Point4D(670.601583059179, -310.982400000001, 0.0, 1.0),
			new Point4D(673.114282995703, -286.9541, 0.0, 1.0),
			new Point4D(673.114282995703, -267.793, 0.0, 1.0),
			new Point4D(673.114282995703, -243.6074, 0.0, 1.0),
			new Point4D(669.972683075066, -224.6045, 0.0, 1.0),
			new Point4D(637.621083892336, -224.6045, 0.0, 1.0)
		};
		double[] knotVector8 = new double[41]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 7.0, 7.0, 7.0, 8.0, 8.0, 8.0, 9.0, 9.0,
			9.0, 10.0, 10.0, 10.0, 11.0, 11.0, 11.0, 12.0, 12.0, 12.0,
			12.0
		};
		array[7] = new Curve(3, knotVector8, ctrlPoints8);
		Point4D[] ctrlPoints9 = new Point4D[16]
		{
			new Point4D(629.925784086736, -291.6641, 0.0, 1.0),
			new Point4D(626.312484178015, -291.6641, 0.0, 1.0),
			new Point4D(622.229484281161, -290.8799, 0.0, 1.0),
			new Point4D(622.229484281161, -290.8799, 0.0, 1.0),
			new Point4D(622.229484281161, -290.8799, 0.0, 1.0),
			new Point4D(622.229484281161, -245.0205, 0.0, 1.0),
			new Point4D(622.229484281161, -245.0205, 0.0, 1.0),
			new Point4D(622.229484281161, -245.0205, 0.0, 1.0),
			new Point4D(627.254884154208, -243.7646, 0.0, 1.0),
			new Point4D(631.966784035176, -243.7646, 0.0, 1.0),
			new Point4D(640.918883809027, -243.7646, 0.0, 1.0),
			new Point4D(643.117183753493, -245.335, 0.0, 1.0),
			new Point4D(643.117183753493, -266.6934, 0.0, 1.0),
			new Point4D(643.117183753493, -289.4668, 0.0, 1.0),
			new Point4D(640.290999999999, -291.6641, 0.0, 1.0),
			new Point4D(629.925784086736, -291.6641, 0.0, 1.0)
		};
		double[] knotVector9 = new double[20]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 5.0
		};
		array[8] = new Curve(3, knotVector9, ctrlPoints9);
		Point4D[] ctrlPoints10 = new Point4D[103]
		{
			new Point4D(733.252, -302.9717, 0.0, 1.0),
			new Point4D(733.252, -302.9717, 0.0, 1.0),
			new Point4D(731.05368153203, -290.7217, 0.0, 1.0),
			new Point4D(731.05368153203, -290.7217, 0.0, 1.0),
			new Point4D(730.739281539973, -289.7803, 0.0, 1.0),
			new Point4D(730.425781547892, -288.8379, 0.0, 1.0),
			new Point4D(729.010681583641, -288.8379, 0.0, 1.0),
			new Point4D(729.010681583641, -288.8379, 0.0, 1.0),
			new Point4D(728.383781599478, -288.8379, 0.0, 1.0),
			new Point4D(728.383781599478, -288.8379, 0.0, 1.0),
			new Point4D(726.341781651063, -289.1514, 0.0, 1.0),
			new Point4D(723.35838172643, -289.7803, 0.0, 1.0),
			new Point4D(718.646481845462, -289.7803, 0.0, 1.0),
			new Point4D(710.793882043836, -289.7803, 0.0, 1.0),
			new Point4D(709.85158206764, -285.6963, 0.0, 1.0),
			new Point4D(709.85158206764, -280.6709, 0.0, 1.0),
			new Point4D(709.85158206764, -280.6709, 0.0, 1.0),
			new Point4D(709.85158206764, -255.9248, 0.0, 1.0),
			new Point4D(709.85158206764, -255.9248, 0.0, 1.0),
			new Point4D(709.85158206764, -255.9248, 0.0, 1.0),
			new Point4D(709.85158206764, -250.085, 0.0, 1.0),
			new Point4D(709.85158206764, -250.085, 0.0, 1.0),
			new Point4D(709.85158206764, -250.085, 0.0, 1.0),
			new Point4D(709.85158206764, -248.0635, 0.0, 1.0),
			new Point4D(709.85158206764, -248.0635, 0.0, 1.0),
			new Point4D(709.85158206764, -248.0635, 0.0, 1.0),
			new Point4D(728.226581603449, -248.0635, 0.0, 1.0),
			new Point4D(728.226581603449, -248.0635, 0.0, 1.0),
			new Point4D(729.79688156378, -248.0635, 0.0, 1.0),
			new Point4D(730.896481536001, -247.1201, 0.0, 1.0),
			new Point4D(730.896481536001, -245.707, 0.0, 1.0),
			new Point4D(730.896481536001, -245.707, 0.0, 1.0),
			new Point4D(730.896481536001, -229.8447, 0.0, 1.0),
			new Point4D(730.896481536001, -229.8447, 0.0, 1.0),
			new Point4D(730.896481536001, -228.4316, 0.0, 1.0),
			new Point4D(729.79688156378, -227.4893, 0.0, 1.0),
			new Point4D(728.226581603449, -227.4893, 0.0, 1.0),
			new Point4D(728.226581603449, -227.4893, 0.0, 1.0),
			new Point4D(709.853482067592, -227.4893, 0.0, 1.0),
			new Point4D(709.853482067592, -227.4893, 0.0, 1.0),
			new Point4D(709.853482067592, -227.4893, 0.0, 1.0),
			new Point4D(709.853482067592, -226.7246, 0.0, 1.0),
			new Point4D(709.853482067592, -226.7246, 0.0, 1.0),
			new Point4D(709.853482067592, -226.7246, 0.0, 1.0),
			new Point4D(709.853482067592, -223.585, 0.0, 1.0),
			new Point4D(709.853482067592, -223.585, 0.0, 1.0),
			new Point4D(709.853482067592, -223.585, 0.0, 1.0),
			new Point4D(709.853482067592, -220.085, 0.0, 1.0),
			new Point4D(709.853482067592, -220.085, 0.0, 1.0),
			new Point4D(709.853482067592, -220.085, 0.0, 1.0),
			new Point4D(709.853482067592, -213.4463, 0.0, 1.0),
			new Point4D(709.853482067592, -213.4463, 0.0, 1.0),
			new Point4D(709.853482067592, -213.4463, 0.0, 1.0),
			new Point4D(709.853482067592, -202.7959, 0.0, 1.0),
			new Point4D(709.853482067592, -202.7959, 0.0, 1.0),
			new Point4D(709.853482067592, -200.5967, 0.0, 1.0),
			new Point4D(708.596682099342, -199.6543, 0.0, 1.0),
			new Point4D(706.870082142959, -199.6543, 0.0, 1.0),
			new Point4D(706.554682150927, -199.6543, 0.0, 1.0),
			new Point4D(706.241182158847, -199.8105, 0.0, 1.0),
			new Point4D(705.770482170738, -199.8105, 0.0, 1.0),
			new Point4D(705.770482170738, -199.8105, 0.0, 1.0),
			new Point4D(683.626, -203.4229, 0.0, 1.0),
			new Point4D(683.626, -203.4229, 0.0, 1.0),
			new Point4D(681.113282793631, -203.8936, 0.0, 1.0),
			new Point4D(680.329082813441, -205.4648, 0.0, 1.0),
			new Point4D(680.329082813441, -207.9775, 0.0, 1.0),
			new Point4D(680.329082813441, -207.9775, 0.0, 1.0),
			new Point4D(680.329082813441, -218.6279, 0.0, 1.0),
			new Point4D(680.329082813441, -218.6279, 0.0, 1.0),
			new Point4D(680.329082813441, -218.6279, 0.0, 1.0),
			new Point4D(680.329082813441, -220.085, 0.0, 1.0),
			new Point4D(680.329082813441, -220.085, 0.0, 1.0),
			new Point4D(680.329082813441, -220.085, 0.0, 1.0),
			new Point4D(680.329082813441, -223.585, 0.0, 1.0),
			new Point4D(680.329082813441, -223.585, 0.0, 1.0),
			new Point4D(680.329082813441, -223.585, 0.0, 1.0),
			new Point4D(680.329082813441, -226.6685, 0.0, 1.0),
			new Point4D(680.329082813441, -226.6685, 0.0, 1.0),
			new Point4D(680.329082813441, -226.6685, 0.0, 1.0),
			new Point4D(680.327082813492, -226.6685, 0.0, 1.0),
			new Point4D(680.327082813492, -226.6685, 0.0, 1.0),
			new Point4D(680.327082813492, -226.6685, 0.0, 1.0),
			new Point4D(680.327082813492, -250.085, 0.0, 1.0),
			new Point4D(680.327082813492, -250.085, 0.0, 1.0),
			new Point4D(680.327082813492, -250.085, 0.0, 1.0),
			new Point4D(680.327082813492, -255.9248, 0.0, 1.0),
			new Point4D(680.327082813492, -255.9248, 0.0, 1.0),
			new Point4D(680.327082813492, -255.9248, 0.0, 1.0),
			new Point4D(680.327082813492, -282.7129, 0.0, 1.0),
			new Point4D(680.327082813492, -282.7129, 0.0, 1.0),
			new Point4D(680.327082813492, -303.1289, 0.0, 1.0),
			new Point4D(690.692382551642, -310.1963, 0.0, 1.0),
			new Point4D(710.951182039862, -310.1963, 0.0, 1.0),
			new Point4D(722.101581758179, -310.1963, 0.0, 1.0),
			new Point4D(729.168, -307.8408, 0.0, 1.0),
			new Point4D(730.896481536001, -307.3701, 0.0, 1.0),
			new Point4D(732.781281488387, -306.897499999999, 0.0, 1.0),
			new Point4D(733.409181472525, -305.7979, 0.0, 1.0),
			new Point4D(733.409181472525, -304.3848, 0.0, 1.0),
			new Point4D(733.409181472525, -303.9141, 0.0, 1.0),
			new Point4D(733.409181472525, -303.4434, 0.0, 1.0),
			new Point4D(733.252, -302.9717, 0.0, 1.0)
		};
		double[] knotVector10 = new double[107]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 7.0, 7.0, 7.0, 8.0, 8.0, 8.0, 9.0, 9.0,
			9.0, 10.0, 10.0, 10.0, 11.0, 11.0, 11.0, 12.0, 12.0, 12.0,
			13.0, 13.0, 13.0, 14.0, 14.0, 14.0, 15.0, 15.0, 15.0, 16.0,
			16.0, 16.0, 17.0, 17.0, 17.0, 18.0, 18.0, 18.0, 19.0, 19.0,
			19.0, 20.0, 20.0, 20.0, 21.0, 21.0, 21.0, 22.0, 22.0, 22.0,
			23.0, 23.0, 23.0, 24.0, 24.0, 24.0, 25.0, 25.0, 25.0, 26.0,
			26.0, 26.0, 27.0, 27.0, 27.0, 28.0, 28.0, 28.0, 29.0, 29.0,
			29.0, 30.0, 30.0, 30.0, 31.0, 31.0, 31.0, 32.0, 32.0, 32.0,
			33.0, 33.0, 33.0, 34.0, 34.0, 34.0, 34.0
		};
		array[9] = new Curve(3, knotVector10, ctrlPoints10);
		Point4D[] ctrlPoints11 = new Point4D[16]
		{
			new Point4D(372.117190599529, -204.1475, 0.0, 1.0),
			new Point4D(372.117190599529, -204.1475, 0.0, 1.0),
			new Point4D(419.467789403352, -251.77, 0.0, 1.0),
			new Point4D(419.467789403352, -251.77, 0.0, 1.0),
			new Point4D(419.467789403352, -251.77, 0.0, 1.0),
			new Point4D(449.810488636831, -240.749, 0.0, 1.0),
			new Point4D(449.810488636831, -240.749, 0.0, 1.0),
			new Point4D(449.810488636831, -240.749, 0.0, 1.0),
			new Point4D(473.485388038753, -233.5376, 0.0, 1.0),
			new Point4D(444.368188774315, -211.6309, 0.0, 1.0),
			new Point4D(415.25, -189.7246, 0.0, 1.0),
			new Point4D(404.501, -193.8066, 0.0, 1.0),
			new Point4D(384.091290297038, -200.0654, 0.0, 1.0),
			new Point4D(384.091290297038, -200.0654, 0.0, 1.0),
			new Point4D(372.117190599529, -204.1475, 0.0, 1.0),
			new Point4D(372.117190599529, -204.1475, 0.0, 1.0)
		};
		double[] knotVector11 = new double[20]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 5.0
		};
		array[10] = new Curve(3, knotVector11, ctrlPoints11);
		Point4D[] ctrlPoints12 = new Point4D[61]
		{
			new Point4D(469.630888136126, -255.2178, 0.0, 1.0),
			new Point4D(469.630888136126, -255.2178, 0.0, 1.0),
			new Point4D(433.523389048278, -269.042, 0.0, 1.0),
			new Point4D(413.164089562597, -277.0576, 0.0, 1.0),
			new Point4D(413.164089562597, -277.0576, 0.0, 1.0),
			new Point4D(405.427689758035, -280.1514, 0.0, 1.0),
			new Point4D(399.453589908953, -282.5957, 0.0, 1.0),
			new Point4D(399.449189909064, -282.5977, 0.0, 1.0),
			new Point4D(399.447289909112, -282.5977, 0.0, 1.0),
			new Point4D(399.442889909224, -282.5996, 0.0, 1.0),
			new Point4D(397.107389968223, -283.5508, 0.0, 1.0),
			new Point4D(395.40379001126, -283.6289, 0.0, 1.0),
			new Point4D(394.675290029663, -283.6055, 0.0, 1.0),
			new Point4D(394.64889003033, -283.6045, 0.0, 1.0),
			new Point4D(394.621090031033, -283.6045, 0.0, 1.0),
			new Point4D(394.594690031699, -283.6016, 0.0, 1.0),
			new Point4D(394.537090033155, -283.5986, 0.0, 1.0),
			new Point4D(394.491690034301, -283.5967, 0.0, 1.0),
			new Point4D(394.45019003535, -283.5938, 0.0, 1.0),
			new Point4D(394.052690045392, -283.5586, 0.0, 1.0),
			new Point4D(393.677190054877, -283.498, 0.0, 1.0),
			new Point4D(393.326690063732, -283.4141, 0.0, 1.0),
			new Point4D(393.302190064351, -283.4092, 0.0, 1.0),
			new Point4D(393.278790064942, -283.4023, 0.0, 1.0),
			new Point4D(393.254390065558, -283.3955, 0.0, 1.0),
			new Point4D(392.869590075279, -283.2998, 0.0, 1.0),
			new Point4D(392.518590084146, -283.1758, 0.0, 1.0),
			new Point4D(392.193390092361, -283.041, 0.0, 1.0),
			new Point4D(390.838890126579, -282.4404, 0.0, 1.0),
			new Point4D(389.808090152619, -281.4287, 0.0, 1.0),
			new Point4D(389.252890166645, -280.792, 0.0, 1.0),
			new Point4D(389.252890166645, -280.792, 0.0, 1.0),
			new Point4D(382.630390333943, -272.5215, 0.0, 1.0),
			new Point4D(382.630390333943, -272.5215, 0.0, 1.0),
			new Point4D(382.630390333943, -272.5215, 0.0, 1.0),
			new Point4D(327.669891722362, -204.1475, 0.0, 1.0),
			new Point4D(327.669891722362, -204.1475, 0.0, 1.0),
			new Point4D(327.669891722362, -204.1475, 0.0, 1.0),
			new Point4D(335.788091517279, -256.5327, 0.0, 1.0),
			new Point4D(335.788091517279, -256.5327, 0.0, 1.0),
			new Point4D(335.788091517279, -256.5327, 0.0, 1.0),
			new Point4D(388.921390175019, -335.2461, 0.0, 1.0),
			new Point4D(391.642590106276, -339.328100000001, 0.0, 1.0),
			new Point4D(394.36429003752, -343.4102, 0.0, 1.0),
			new Point4D(399.149889916625, -341.0283, 0.0, 1.0),
			new Point4D(399.149889916625, -341.0283, 0.0, 1.0),
			new Point4D(399.149889916625, -341.0283, 0.0, 1.0),
			new Point4D(439.606388894608, -323.0684, 0.0, 1.0),
			new Point4D(461.831088333165, -312.727500000001, 0.0, 1.0),
			new Point4D(484.055687771724, -302.386699999999, 0.0, 1.0),
			new Point4D(487.138687693841, -287.7822, 0.0, 1.0),
			new Point4D(487.138687693841, -287.7822, 0.0, 1.0),
			new Point4D(487.138687693841, -287.7822, 0.0, 1.0),
			new Point4D(495.211887489895, -252.8589, 0.0, 1.0),
			new Point4D(496.935487446353, -243.7764, 0.0, 1.0),
			new Point4D(498.660187402784, -234.6943, 0.0, 1.0),
			new Point4D(498.659187402809, -232.1768, 0.0, 1.0),
			new Point4D(498.659187402809, -232.1768, 0.0, 1.0),
			new Point4D(496.029287469246, -244.3311, 0.0, 1.0),
			new Point4D(469.630888136126, -255.2178, 0.0, 1.0),
			new Point4D(469.630888136126, -255.2178, 0.0, 1.0)
		};
		double[] knotVector12 = new double[65]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 7.0, 7.0, 7.0, 8.0, 8.0, 8.0, 9.0, 9.0,
			9.0, 10.0, 10.0, 10.0, 11.0, 11.0, 11.0, 12.0, 12.0, 12.0,
			13.0, 13.0, 13.0, 14.0, 14.0, 14.0, 15.0, 15.0, 15.0, 16.0,
			16.0, 16.0, 17.0, 17.0, 17.0, 18.0, 18.0, 18.0, 19.0, 19.0,
			19.0, 20.0, 20.0, 20.0, 20.0
		};
		array[11] = new Curve(3, knotVector12, ctrlPoints12);
		Point4D[] ctrlPoints13 = new Point4D[67]
		{
			new Point4D(213.984894594287, -404.8027, 0.0, 1.0),
			new Point4D(213.561494604983, -404.5205, 0.0, 1.0),
			new Point4D(213.279294612112, -404.0029, 0.0, 1.0),
			new Point4D(213.279294612112, -403.391600000001, 0.0, 1.0),
			new Point4D(213.279294612112, -402.357400000001, 0.0, 1.0),
			new Point4D(214.079094591907, -401.5576, 0.0, 1.0),
			new Point4D(215.066394566966, -401.5576, 0.0, 1.0),
			new Point4D(215.536594555088, -401.5576, 0.0, 1.0),
			new Point4D(215.96, -401.7461, 0.0, 1.0),
			new Point4D(216.195294538447, -401.981400000001, 0.0, 1.0),
			new Point4D(219.298794460046, -404.614299999999, 0.0, 1.0),
			new Point4D(222.402794381633, -405.8838, 0.0, 1.0),
			new Point4D(226.588394275896, -405.8838, 0.0, 1.0),
			new Point4D(231.008794164227, -405.8838, 0.0, 1.0),
			new Point4D(233.924794090563, -403.5332, 0.0, 1.0),
			new Point4D(233.924794090563, -400.2881, 0.0, 1.0),
			new Point4D(233.924794090563, -400.2881, 0.0, 1.0),
			new Point4D(233.924794090563, -400.194299999999, 0.0, 1.0),
			new Point4D(233.924794090563, -400.194299999999, 0.0, 1.0),
			new Point4D(233.924794090563, -397.136699999999, 0.0, 1.0),
			new Point4D(232.278794132144, -395.397499999999, 0.0, 1.0),
			new Point4D(225.365694306784, -393.9395, 0.0, 1.0),
			new Point4D(217.793894498063, -392.293, 0.0, 1.0),
			new Point4D(214.314, -389.8477, 0.0, 1.0),
			new Point4D(214.314, -384.4395, 0.0, 1.0),
			new Point4D(214.314, -384.4395, 0.0, 1.0),
			new Point4D(214.314, -384.3457, 0.0, 1.0),
			new Point4D(214.314, -384.3457, 0.0, 1.0),
			new Point4D(214.314, -379.1729, 0.0, 1.0),
			new Point4D(218.876, -375.363300000001, 0.0, 1.0),
			new Point4D(225.130394312728, -375.363300000001, 0.0, 1.0),
			new Point4D(229.457, -375.363300000001, 0.0, 1.0),
			new Point4D(232.60789412383, -376.445299999999, 0.0, 1.0),
			new Point4D(235.617694047796, -378.608399999999, 0.0, 1.0),
			new Point4D(235.993694038298, -378.890600000001, 0.0, 1.0),
			new Point4D(236.417, -379.4072, 0.0, 1.0),
			new Point4D(236.417, -380.113300000001, 0.0, 1.0),
			new Point4D(236.417, -381.1006, 0.0, 1.0),
			new Point4D(235.617694047796, -381.9004, 0.0, 1.0),
			new Point4D(234.62989407275, -381.9004, 0.0, 1.0),
			new Point4D(234.207, -381.9004, 0.0, 1.0),
			new Point4D(233.87739409176, -381.805700000001, 0.0, 1.0),
			new Point4D(233.548294100074, -381.5713, 0.0, 1.0),
			new Point4D(230.773894170161, -379.5488, 0.0, 1.0),
			new Point4D(228.093294237879, -378.7021, 0.0, 1.0),
			new Point4D(225.036594315097, -378.7021, 0.0, 1.0),
			new Point4D(220.756794423214, -378.7021, 0.0, 1.0),
			new Point4D(218.029294492117, -381.0537, 0.0, 1.0),
			new Point4D(218.029294492117, -384.016600000001, 0.0, 1.0),
			new Point4D(218.029294492117, -384.016600000001, 0.0, 1.0),
			new Point4D(218.029294492117, -384.1104, 0.0, 1.0),
			new Point4D(218.029294492117, -384.1104, 0.0, 1.0),
			new Point4D(218.029294492117, -387.213900000001, 0.0, 1.0),
			new Point4D(219.72219444935, -388.954100000001, 0.0, 1.0),
			new Point4D(226.964394266397, -390.5059, 0.0, 1.0),
			new Point4D(234.300794081064, -392.1055, 0.0, 1.0),
			new Point4D(237.687, -394.786099999999, 0.0, 1.0),
			new Point4D(237.687, -399.8174, 0.0, 1.0),
			new Point4D(237.687, -399.8174, 0.0, 1.0),
			new Point4D(237.687, -399.9121, 0.0, 1.0),
			new Point4D(237.687, -399.9121, 0.0, 1.0),
			new Point4D(237.687, -405.554700000001, 0.0, 1.0),
			new Point4D(232.983894114332, -409.223599999999, 0.0, 1.0),
			new Point4D(226.44729427946, -409.223599999999, 0.0, 1.0),
			new Point4D(221.65039440064, -409.223599999999, 0.0, 1.0),
			new Point4D(217.653294501615, -407.718800000001, 0.0, 1.0),
			new Point4D(213.984894594287, -404.8027, 0.0, 1.0)
		};
		double[] knotVector13 = new double[71]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 7.0, 7.0, 7.0, 8.0, 8.0, 8.0, 9.0, 9.0,
			9.0, 10.0, 10.0, 10.0, 11.0, 11.0, 11.0, 12.0, 12.0, 12.0,
			13.0, 13.0, 13.0, 14.0, 14.0, 14.0, 15.0, 15.0, 15.0, 16.0,
			16.0, 16.0, 17.0, 17.0, 17.0, 18.0, 18.0, 18.0, 19.0, 19.0,
			19.0, 20.0, 20.0, 20.0, 21.0, 21.0, 21.0, 22.0, 22.0, 22.0,
			22.0
		};
		array[12] = new Curve(3, knotVector13, ctrlPoints13);
		Point4D[] ctrlPoints14 = new Point4D[19]
		{
			new Point4D(257.90229348484, -392.387699999999, 0.0, 1.0),
			new Point4D(257.90229348484, -392.387699999999, 0.0, 1.0),
			new Point4D(257.90229348484, -392.293, 0.0, 1.0),
			new Point4D(257.90229348484, -392.293, 0.0, 1.0),
			new Point4D(257.90229348484, -383.2168, 0.0, 1.0),
			new Point4D(264.721693312567, -375.2695, 0.0, 1.0),
			new Point4D(274.738293059527, -375.2695, 0.0, 1.0),
			new Point4D(284.755392806473, -375.2695, 0.0, 1.0),
			new Point4D(291.48, -383.123, 0.0, 1.0),
			new Point4D(291.48, -392.199199999999, 0.0, 1.0),
			new Point4D(291.48, -392.199199999999, 0.0, 1.0),
			new Point4D(291.48, -392.293, 0.0, 1.0),
			new Point4D(291.48, -392.293, 0.0, 1.0),
			new Point4D(291.48, -401.3691, 0.0, 1.0),
			new Point4D(284.661092808856, -409.3174, 0.0, 1.0),
			new Point4D(274.644493061896, -409.3174, 0.0, 1.0),
			new Point4D(264.62739331495, -409.3174, 0.0, 1.0),
			new Point4D(257.90229348484, -401.463900000001, 0.0, 1.0),
			new Point4D(257.90229348484, -392.387699999999, 0.0, 1.0)
		};
		double[] knotVector14 = new double[23]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 6.0
		};
		array[13] = new Curve(3, knotVector14, ctrlPoints14);
		Point4D[] ctrlPoints15 = new Point4D[19]
		{
			new Point4D(287.624, -392.387699999999, 0.0, 1.0),
			new Point4D(287.624, -392.387699999999, 0.0, 1.0),
			new Point4D(287.624, -392.293, 0.0, 1.0),
			new Point4D(287.624, -392.293, 0.0, 1.0),
			new Point4D(287.624, -384.8154, 0.0, 1.0),
			new Point4D(282.168892871814, -378.7021, 0.0, 1.0),
			new Point4D(274.644493061896, -378.7021, 0.0, 1.0),
			new Point4D(267.120093251979, -378.7021, 0.0, 1.0),
			new Point4D(261.758793387417, -384.7217, 0.0, 1.0),
			new Point4D(261.758793387417, -392.199199999999, 0.0, 1.0),
			new Point4D(261.758793387417, -392.199199999999, 0.0, 1.0),
			new Point4D(261.758793387417, -392.293, 0.0, 1.0),
			new Point4D(261.758793387417, -392.293, 0.0, 1.0),
			new Point4D(261.758793387417, -399.7705, 0.0, 1.0),
			new Point4D(267.213893249609, -405.8838, 0.0, 1.0),
			new Point4D(274.738293059527, -405.8838, 0.0, 1.0),
			new Point4D(282.262692869444, -405.8838, 0.0, 1.0),
			new Point4D(287.624, -399.864299999999, 0.0, 1.0),
			new Point4D(287.624, -392.387699999999, 0.0, 1.0)
		};
		double[] knotVector15 = new double[23]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 6.0
		};
		array[14] = new Curve(3, knotVector15, ctrlPoints15);
		Point4D[] ctrlPoints16 = new Point4D[43]
		{
			new Point4D(313.434092081989, -377.7148, 0.0, 1.0),
			new Point4D(313.434092081989, -376.679700000001, 0.0, 1.0),
			new Point4D(314.280792060599, -375.834000000001, 0.0, 1.0),
			new Point4D(315.268092035658, -375.834000000001, 0.0, 1.0),
			new Point4D(315.268092035658, -375.834000000001, 0.0, 1.0),
			new Point4D(335.63089152125, -375.834000000001, 0.0, 1.0),
			new Point4D(335.63089152125, -375.834000000001, 0.0, 1.0),
			new Point4D(336.571791497481, -375.834000000001, 0.0, 1.0),
			new Point4D(337.324191478474, -376.5859, 0.0, 1.0),
			new Point4D(337.324191478474, -377.526400000001, 0.0, 1.0),
			new Point4D(337.324191478474, -378.4668, 0.0, 1.0),
			new Point4D(336.571791497481, -379.266600000001, 0.0, 1.0),
			new Point4D(335.63089152125, -379.266600000001, 0.0, 1.0),
			new Point4D(335.63089152125, -379.266600000001, 0.0, 1.0),
			new Point4D(317.149391988132, -379.266600000001, 0.0, 1.0),
			new Point4D(317.149391988132, -379.266600000001, 0.0, 1.0),
			new Point4D(317.149391988132, -379.266600000001, 0.0, 1.0),
			new Point4D(317.149391988132, -391.0234, 0.0, 1.0),
			new Point4D(317.149391988132, -391.0234, 0.0, 1.0),
			new Point4D(317.149391988132, -391.0234, 0.0, 1.0),
			new Point4D(333.514591574712, -391.0234, 0.0, 1.0),
			new Point4D(333.514591574712, -391.0234, 0.0, 1.0),
			new Point4D(334.455591550941, -391.0234, 0.0, 1.0),
			new Point4D(335.208, -391.776400000001, 0.0, 1.0),
			new Point4D(335.208, -392.7168, 0.0, 1.0),
			new Point4D(335.208, -393.6572, 0.0, 1.0),
			new Point4D(334.455591550941, -394.4092, 0.0, 1.0),
			new Point4D(333.514591574712, -394.4092, 0.0, 1.0),
			new Point4D(333.514591574712, -394.4092, 0.0, 1.0),
			new Point4D(317.149391988132, -394.4092, 0.0, 1.0),
			new Point4D(317.149391988132, -394.4092, 0.0, 1.0),
			new Point4D(317.149391988132, -394.4092, 0.0, 1.0),
			new Point4D(317.149391988132, -407.107400000001, 0.0, 1.0),
			new Point4D(317.149391988132, -407.107400000001, 0.0, 1.0),
			new Point4D(317.149391988132, -408.141600000001, 0.0, 1.0),
			new Point4D(316.302692009522, -408.988300000001, 0.0, 1.0),
			new Point4D(315.268092035658, -408.988300000001, 0.0, 1.0),
			new Point4D(314.280792060599, -408.988300000001, 0.0, 1.0),
			new Point4D(313.434092081989, -408.141600000001, 0.0, 1.0),
			new Point4D(313.434092081989, -407.107400000001, 0.0, 1.0),
			new Point4D(313.434092081989, -407.107400000001, 0.0, 1.0),
			new Point4D(313.434092081989, -377.7148, 0.0, 1.0),
			new Point4D(313.434092081989, -377.7148, 0.0, 1.0)
		};
		double[] knotVector16 = new double[47]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 7.0, 7.0, 7.0, 8.0, 8.0, 8.0, 9.0, 9.0,
			9.0, 10.0, 10.0, 10.0, 11.0, 11.0, 11.0, 12.0, 12.0, 12.0,
			13.0, 13.0, 13.0, 14.0, 14.0, 14.0, 14.0
		};
		array[15] = new Curve(3, knotVector16, ctrlPoints16);
		Point4D[] ctrlPoints17 = new Point4D[34]
		{
			new Point4D(367.085, -379.266600000001, 0.0, 1.0),
			new Point4D(367.085, -379.266600000001, 0.0, 1.0),
			new Point4D(357.539090967803, -379.266600000001, 0.0, 1.0),
			new Point4D(357.539090967803, -379.266600000001, 0.0, 1.0),
			new Point4D(356.598590991562, -379.266600000001, 0.0, 1.0),
			new Point4D(355.798791011766, -378.5146, 0.0, 1.0),
			new Point4D(355.798791011766, -377.573200000001, 0.0, 1.0),
			new Point4D(355.798791011766, -376.632799999999, 0.0, 1.0),
			new Point4D(356.598590991562, -375.834000000001, 0.0, 1.0),
			new Point4D(357.539090967803, -375.834000000001, 0.0, 1.0),
			new Point4D(357.539090967803, -375.834000000001, 0.0, 1.0),
			new Point4D(380.394490390427, -375.834000000001, 0.0, 1.0),
			new Point4D(380.394490390427, -375.834000000001, 0.0, 1.0),
			new Point4D(381.335, -375.834000000001, 0.0, 1.0),
			new Point4D(382.133790346488, -376.632799999999, 0.0, 1.0),
			new Point4D(382.133790346488, -377.573200000001, 0.0, 1.0),
			new Point4D(382.133790346488, -378.5146, 0.0, 1.0),
			new Point4D(381.335, -379.266600000001, 0.0, 1.0),
			new Point4D(380.394490390427, -379.266600000001, 0.0, 1.0),
			new Point4D(380.394490390427, -379.266600000001, 0.0, 1.0),
			new Point4D(370.847690631599, -379.266600000001, 0.0, 1.0),
			new Point4D(370.847690631599, -379.266600000001, 0.0, 1.0),
			new Point4D(370.847690631599, -379.266600000001, 0.0, 1.0),
			new Point4D(370.847690631599, -407.107400000001, 0.0, 1.0),
			new Point4D(370.847690631599, -407.107400000001, 0.0, 1.0),
			new Point4D(370.847690631599, -408.141600000001, 0.0, 1.0),
			new Point4D(370.001, -408.988300000001, 0.0, 1.0),
			new Point4D(368.966790679115, -408.988300000001, 0.0, 1.0),
			new Point4D(367.931590705266, -408.988300000001, 0.0, 1.0),
			new Point4D(367.085, -408.141600000001, 0.0, 1.0),
			new Point4D(367.085, -407.107400000001, 0.0, 1.0),
			new Point4D(367.085, -407.107400000001, 0.0, 1.0),
			new Point4D(367.085, -379.266600000001, 0.0, 1.0),
			new Point4D(367.085, -379.266600000001, 0.0, 1.0)
		};
		double[] knotVector17 = new double[38]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 7.0, 7.0, 7.0, 8.0, 8.0, 8.0, 9.0, 9.0,
			9.0, 10.0, 10.0, 10.0, 11.0, 11.0, 11.0, 11.0
		};
		array[16] = new Curve(3, knotVector17, ctrlPoints17);
		Point4D[] ctrlPoints18 = new Point4D[70]
		{
			new Point4D(400.986289870234, -378.3262, 0.0, 1.0),
			new Point4D(400.892589872601, -378.043900000001, 0.0, 1.0),
			new Point4D(400.797889874993, -377.761699999999, 0.0, 1.0),
			new Point4D(400.797889874993, -377.4795, 0.0, 1.0),
			new Point4D(400.797889874993, -376.492200000001, 0.0, 1.0),
			new Point4D(401.691389852422, -375.598599999999, 0.0, 1.0),
			new Point4D(402.72658982627, -375.598599999999, 0.0, 1.0),
			new Point4D(403.667, -375.598599999999, 0.0, 1.0),
			new Point4D(404.372089784701, -376.3037, 0.0, 1.0),
			new Point4D(404.654289777573, -377.1504, 0.0, 1.0),
			new Point4D(404.654289777573, -377.1504, 0.0, 1.0),
			new Point4D(413.730489548289, -403.2979, 0.0, 1.0),
			new Point4D(413.730489548289, -403.2979, 0.0, 1.0),
			new Point4D(413.730489548289, -403.2979, 0.0, 1.0),
			new Point4D(422.336889330873, -377.0566, 0.0, 1.0),
			new Point4D(422.336889330873, -377.0566, 0.0, 1.0),
			new Point4D(422.619089323743, -376.209999999999, 0.0, 1.0),
			new Point4D(423.183589309483, -375.598599999999, 0.0, 1.0),
			new Point4D(424.170889284542, -375.598599999999, 0.0, 1.0),
			new Point4D(424.170889284542, -375.598599999999, 0.0, 1.0),
			new Point4D(424.406289278595, -375.598599999999, 0.0, 1.0),
			new Point4D(424.406289278595, -375.598599999999, 0.0, 1.0),
			new Point4D(425.346689254839, -375.598599999999, 0.0, 1.0),
			new Point4D(425.958, -376.209999999999, 0.0, 1.0),
			new Point4D(426.240189232267, -377.0566, 0.0, 1.0),
			new Point4D(426.240189232267, -377.0566, 0.0, 1.0),
			new Point4D(434.845689014874, -403.2979, 0.0, 1.0),
			new Point4D(434.845689014874, -403.2979, 0.0, 1.0),
			new Point4D(434.845689014874, -403.2979, 0.0, 1.0),
			new Point4D(443.969688784382, -377.0566, 0.0, 1.0),
			new Point4D(443.969688784382, -377.0566, 0.0, 1.0),
			new Point4D(444.252, -376.209999999999, 0.0, 1.0),
			new Point4D(444.863288761808, -375.598599999999, 0.0, 1.0),
			new Point4D(445.756788739236, -375.598599999999, 0.0, 1.0),
			new Point4D(446.744088714295, -375.598599999999, 0.0, 1.0),
			new Point4D(447.63768869172, -376.492200000001, 0.0, 1.0),
			new Point4D(447.63768869172, -377.4326, 0.0, 1.0),
			new Point4D(447.63768869172, -377.7148, 0.0, 1.0),
			new Point4D(447.496088695298, -378.043900000001, 0.0, 1.0),
			new Point4D(447.402288697667, -378.3262, 0.0, 1.0),
			new Point4D(447.402288697667, -378.3262, 0.0, 1.0),
			new Point4D(436.868188963781, -407.5771, 0.0, 1.0),
			new Point4D(436.868188963781, -407.5771, 0.0, 1.0),
			new Point4D(436.539088972095, -408.517599999999, 0.0, 1.0),
			new Point4D(435.880888988722, -409.175800000001, 0.0, 1.0),
			new Point4D(434.940389012481, -409.175800000001, 0.0, 1.0),
			new Point4D(434.940389012481, -409.175800000001, 0.0, 1.0),
			new Point4D(434.65818901961, -409.175800000001, 0.0, 1.0),
			new Point4D(434.65818901961, -409.175800000001, 0.0, 1.0),
			new Point4D(433.717789043367, -409.175800000001, 0.0, 1.0),
			new Point4D(433.05858906002, -408.517599999999, 0.0, 1.0),
			new Point4D(432.729489068333, -407.5771, 0.0, 1.0),
			new Point4D(432.729489068333, -407.5771, 0.0, 1.0),
			new Point4D(424.170889284542, -382.276400000001, 0.0, 1.0),
			new Point4D(424.170889284542, -382.276400000001, 0.0, 1.0),
			new Point4D(424.170889284542, -382.276400000001, 0.0, 1.0),
			new Point4D(415.659189499565, -407.5771, 0.0, 1.0),
			new Point4D(415.659189499565, -407.5771, 0.0, 1.0),
			new Point4D(415.330089507879, -408.517599999999, 0.0, 1.0),
			new Point4D(414.670889524532, -409.175800000001, 0.0, 1.0),
			new Point4D(413.730489548289, -409.175800000001, 0.0, 1.0),
			new Point4D(413.730489548289, -409.175800000001, 0.0, 1.0),
			new Point4D(413.44818955542, -409.175800000001, 0.0, 1.0),
			new Point4D(413.44818955542, -409.175800000001, 0.0, 1.0),
			new Point4D(412.507789579177, -409.175800000001, 0.0, 1.0),
			new Point4D(411.849589595804, -408.5645, 0.0, 1.0),
			new Point4D(411.520489604118, -407.5771, 0.0, 1.0),
			new Point4D(411.520489604118, -407.5771, 0.0, 1.0),
			new Point4D(400.986289870234, -378.3262, 0.0, 1.0),
			new Point4D(400.986289870234, -378.3262, 0.0, 1.0)
		};
		double[] knotVector18 = new double[74]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 7.0, 7.0, 7.0, 8.0, 8.0, 8.0, 9.0, 9.0,
			9.0, 10.0, 10.0, 10.0, 11.0, 11.0, 11.0, 12.0, 12.0, 12.0,
			13.0, 13.0, 13.0, 14.0, 14.0, 14.0, 15.0, 15.0, 15.0, 16.0,
			16.0, 16.0, 17.0, 17.0, 17.0, 18.0, 18.0, 18.0, 19.0, 19.0,
			19.0, 20.0, 20.0, 20.0, 21.0, 21.0, 21.0, 22.0, 22.0, 22.0,
			23.0, 23.0, 23.0, 23.0
		};
		array[17] = new Curve(3, knotVector18, ctrlPoints18);
		Point4D[] ctrlPoints19 = new Point4D[43]
		{
			new Point4D(462.959999999999, -406.3076, 0.0, 1.0),
			new Point4D(462.959999999999, -406.3076, 0.0, 1.0),
			new Point4D(476.315387967261, -377.103499999999, 0.0, 1.0),
			new Point4D(476.315387967261, -377.103499999999, 0.0, 1.0),
			new Point4D(476.78608795537, -376.0684, 0.0, 1.0),
			new Point4D(477.491187937558, -375.457, 0.0, 1.0),
			new Point4D(478.667, -375.457, 0.0, 1.0),
			new Point4D(478.667, -375.457, 0.0, 1.0),
			new Point4D(478.855487903093, -375.457, 0.0, 1.0),
			new Point4D(478.855487903093, -375.457, 0.0, 1.0),
			new Point4D(479.983387874599, -375.457, 0.0, 1.0),
			new Point4D(480.73628785558, -376.0684, 0.0, 1.0),
			new Point4D(481.159187844896, -377.103499999999, 0.0, 1.0),
			new Point4D(481.159187844896, -377.103499999999, 0.0, 1.0),
			new Point4D(494.515587507485, -406.260700000001, 0.0, 1.0),
			new Point4D(494.515587507485, -406.260700000001, 0.0, 1.0),
			new Point4D(494.656287503931, -406.5898, 0.0, 1.0),
			new Point4D(494.75, -406.918900000001, 0.0, 1.0),
			new Point4D(494.75, -407.2012, 0.0, 1.0),
			new Point4D(494.75, -408.1885, 0.0, 1.0),
			new Point4D(493.951187521743, -408.988300000001, 0.0, 1.0),
			new Point4D(492.96288754671, -408.988300000001, 0.0, 1.0),
			new Point4D(492.069287569284, -408.988300000001, 0.0, 1.0),
			new Point4D(491.458, -408.377, 0.0, 1.0),
			new Point4D(491.12888759304, -407.624, 0.0, 1.0),
			new Point4D(491.12888759304, -407.624, 0.0, 1.0),
			new Point4D(487.696287679755, -400.0527, 0.0, 1.0),
			new Point4D(487.696287679755, -400.0527, 0.0, 1.0),
			new Point4D(487.696287679755, -400.0527, 0.0, 1.0),
			new Point4D(469.637688135954, -400.0527, 0.0, 1.0),
			new Point4D(469.637688135954, -400.0527, 0.0, 1.0),
			new Point4D(469.637688135954, -400.0527, 0.0, 1.0),
			new Point4D(466.205088222669, -407.718800000001, 0.0, 1.0),
			new Point4D(466.205088222669, -407.718800000001, 0.0, 1.0),
			new Point4D(465.875, -408.517599999999, 0.0, 1.0),
			new Point4D(465.26368824645, -408.988300000001, 0.0, 1.0),
			new Point4D(464.418, -408.988300000001, 0.0, 1.0),
			new Point4D(463.476588291596, -408.988300000001, 0.0, 1.0),
			new Point4D(462.724588310593, -408.2354, 0.0, 1.0),
			new Point4D(462.724588310593, -407.294900000001, 0.0, 1.0),
			new Point4D(462.724588310593, -407.012699999999, 0.0, 1.0),
			new Point4D(462.771488309409, -406.6836, 0.0, 1.0),
			new Point4D(462.959999999999, -406.3076, 0.0, 1.0)
		};
		double[] knotVector19 = new double[47]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 7.0, 7.0, 7.0, 8.0, 8.0, 8.0, 9.0, 9.0,
			9.0, 10.0, 10.0, 10.0, 11.0, 11.0, 11.0, 12.0, 12.0, 12.0,
			13.0, 13.0, 13.0, 14.0, 14.0, 14.0, 14.0
		};
		array[18] = new Curve(3, knotVector19, ctrlPoints19);
		Point3D[] points = new Point3D[4]
		{
			new Point3D(486.238287716587, -396.667, 0.0),
			new Point3D(478.667, -379.831099999999, 0.0),
			new Point3D(471.095688099122, -396.667, 0.0),
			new Point3D(486.238287716587, -396.667, 0.0)
		};
		array[19] = new LinearPath(points);
		Point4D[] ctrlPoints20 = new Point4D[49]
		{
			new Point4D(516.892586942195, -377.7148, 0.0, 1.0),
			new Point4D(516.892586942195, -376.679700000001, 0.0, 1.0),
			new Point4D(517.739286920805, -375.834000000001, 0.0, 1.0),
			new Point4D(518.727486895841, -375.834000000001, 0.0, 1.0),
			new Point4D(518.727486895841, -375.834000000001, 0.0, 1.0),
			new Point4D(531.047886584602, -375.834000000001, 0.0, 1.0),
			new Point4D(531.047886584602, -375.834000000001, 0.0, 1.0),
			new Point4D(535.092786482419, -375.834000000001, 0.0, 1.0),
			new Point4D(538.337886400441, -377.0566, 0.0, 1.0),
			new Point4D(540.407186348166, -379.126, 0.0, 1.0),
			new Point4D(542.005886307779, -380.7246, 0.0, 1.0),
			new Point4D(542.946286284023, -383.0293, 0.0, 1.0),
			new Point4D(542.946286284023, -385.6152, 0.0, 1.0),
			new Point4D(542.946286284023, -385.6152, 0.0, 1.0),
			new Point4D(542.946286284023, -385.709000000001, 0.0, 1.0),
			new Point4D(542.946286284023, -385.709000000001, 0.0, 1.0),
			new Point4D(542.946286284023, -391.117200000001, 0.0, 1.0),
			new Point4D(539.278286376684, -394.268599999999, 0.0, 1.0),
			new Point4D(534.152286506178, -395.2559, 0.0, 1.0),
			new Point4D(534.152286506178, -395.2559, 0.0, 1.0),
			new Point4D(542.334999999999, -405.790000000001, 0.0, 1.0),
			new Point4D(542.334999999999, -405.790000000001, 0.0, 1.0),
			new Point4D(542.710886289969, -406.213900000001, 0.0, 1.0),
			new Point4D(542.946286284023, -406.636699999999, 0.0, 1.0),
			new Point4D(542.946286284023, -407.1543, 0.0, 1.0),
			new Point4D(542.946286284023, -408.141600000001, 0.0, 1.0),
			new Point4D(542.005886307779, -408.988300000001, 0.0, 1.0),
			new Point4D(541.065386331538, -408.988300000001, 0.0, 1.0),
			new Point4D(540.312486350558, -408.988300000001, 0.0, 1.0),
			new Point4D(539.748, -408.5645, 0.0, 1.0),
			new Point4D(539.325186375499, -408.001, 0.0, 1.0),
			new Point4D(539.325186375499, -408.001, 0.0, 1.0),
			new Point4D(530.060486609545, -395.9619, 0.0, 1.0),
			new Point4D(530.060486609545, -395.9619, 0.0, 1.0),
			new Point4D(530.060486609545, -395.9619, 0.0, 1.0),
			new Point4D(520.608386848326, -395.9619, 0.0, 1.0),
			new Point4D(520.608386848326, -395.9619, 0.0, 1.0),
			new Point4D(520.608386848326, -395.9619, 0.0, 1.0),
			new Point4D(520.608386848326, -407.107400000001, 0.0, 1.0),
			new Point4D(520.608386848326, -407.107400000001, 0.0, 1.0),
			new Point4D(520.608386848326, -408.141600000001, 0.0, 1.0),
			new Point4D(519.761686869715, -408.988300000001, 0.0, 1.0),
			new Point4D(518.727486895841, -408.988300000001, 0.0, 1.0),
			new Point4D(517.739286920805, -408.988300000001, 0.0, 1.0),
			new Point4D(516.892586942195, -408.141600000001, 0.0, 1.0),
			new Point4D(516.892586942195, -407.107400000001, 0.0, 1.0),
			new Point4D(516.892586942195, -407.107400000001, 0.0, 1.0),
			new Point4D(516.892586942195, -377.7148, 0.0, 1.0),
			new Point4D(516.892586942195, -377.7148, 0.0, 1.0)
		};
		double[] knotVector20 = new double[53]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 7.0, 7.0, 7.0, 8.0, 8.0, 8.0, 9.0, 9.0,
			9.0, 10.0, 10.0, 10.0, 11.0, 11.0, 11.0, 12.0, 12.0, 12.0,
			13.0, 13.0, 13.0, 14.0, 14.0, 14.0, 15.0, 15.0, 15.0, 16.0,
			16.0, 16.0, 16.0
		};
		array[20] = new Curve(3, knotVector20, ctrlPoints20);
		Point4D[] ctrlPoints21 = new Point4D[19]
		{
			new Point4D(530.718786592915, -392.622100000001, 0.0, 1.0),
			new Point4D(535.657186468161, -392.622100000001, 0.0, 1.0),
			new Point4D(539.184586379051, -390.083, 0.0, 1.0),
			new Point4D(539.184586379051, -385.8506, 0.0, 1.0),
			new Point4D(539.184586379051, -385.8506, 0.0, 1.0),
			new Point4D(539.184586379051, -385.756799999999, 0.0, 1.0),
			new Point4D(539.184586379051, -385.756799999999, 0.0, 1.0),
			new Point4D(539.184586379051, -381.7119, 0.0, 1.0),
			new Point4D(536.080086457478, -379.266600000001, 0.0, 1.0),
			new Point4D(530.766586591708, -379.266600000001, 0.0, 1.0),
			new Point4D(530.766586591708, -379.266600000001, 0.0, 1.0),
			new Point4D(520.608386848326, -379.266600000001, 0.0, 1.0),
			new Point4D(520.608386848326, -379.266600000001, 0.0, 1.0),
			new Point4D(520.608386848326, -379.266600000001, 0.0, 1.0),
			new Point4D(520.608386848326, -392.622100000001, 0.0, 1.0),
			new Point4D(520.608386848326, -392.622100000001, 0.0, 1.0),
			new Point4D(520.608386848326, -392.622100000001, 0.0, 1.0),
			new Point4D(530.718786592915, -392.622100000001, 0.0, 1.0),
			new Point4D(530.718786592915, -392.622100000001, 0.0, 1.0)
		};
		double[] knotVector21 = new double[23]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 6.0
		};
		array[21] = new Curve(3, knotVector21, ctrlPoints21);
		Point4D[] ctrlPoints22 = new Point4D[52]
		{
			new Point4D(566.875, -406.872100000001, 0.0, 1.0),
			new Point4D(566.875, -406.872100000001, 0.0, 1.0),
			new Point4D(566.875, -377.7148, 0.0, 1.0),
			new Point4D(566.875, -377.7148, 0.0, 1.0),
			new Point4D(566.875, -376.679700000001, 0.0, 1.0),
			new Point4D(567.721685658144, -375.834000000001, 0.0, 1.0),
			new Point4D(568.709999999999, -375.834000000001, 0.0, 1.0),
			new Point4D(568.709999999999, -375.834000000001, 0.0, 1.0),
			new Point4D(589.166999999999, -375.834000000001, 0.0, 1.0),
			new Point4D(589.166999999999, -375.834000000001, 0.0, 1.0),
			new Point4D(590.107385092633, -375.834000000001, 0.0, 1.0),
			new Point4D(590.859385073636, -376.5859, 0.0, 1.0),
			new Point4D(590.859385073636, -377.526400000001, 0.0, 1.0),
			new Point4D(590.859385073636, -378.4668, 0.0, 1.0),
			new Point4D(590.107385092633, -379.2197, 0.0, 1.0),
			new Point4D(589.166999999999, -379.2197, 0.0, 1.0),
			new Point4D(589.166999999999, -379.2197, 0.0, 1.0),
			new Point4D(570.590785585664, -379.2197, 0.0, 1.0),
			new Point4D(570.590785585664, -379.2197, 0.0, 1.0),
			new Point4D(570.590785585664, -379.2197, 0.0, 1.0),
			new Point4D(570.590785585664, -390.459000000001, 0.0, 1.0),
			new Point4D(570.590785585664, -390.459000000001, 0.0, 1.0),
			new Point4D(570.590785585664, -390.459000000001, 0.0, 1.0),
			new Point4D(587.049785169875, -390.459000000001, 0.0, 1.0),
			new Point4D(587.049785169875, -390.459000000001, 0.0, 1.0),
			new Point4D(587.991185146093, -390.459000000001, 0.0, 1.0),
			new Point4D(588.743185127096, -391.2588, 0.0, 1.0),
			new Point4D(588.743185127096, -392.1523, 0.0, 1.0),
			new Point4D(588.743185127096, -393.0928, 0.0, 1.0),
			new Point4D(587.991185146093, -393.8447, 0.0, 1.0),
			new Point4D(587.049785169875, -393.8447, 0.0, 1.0),
			new Point4D(587.049785169875, -393.8447, 0.0, 1.0),
			new Point4D(570.590785585664, -393.8447, 0.0, 1.0),
			new Point4D(570.590785585664, -393.8447, 0.0, 1.0),
			new Point4D(570.590785585664, -393.8447, 0.0, 1.0),
			new Point4D(570.590785585664, -405.367200000001, 0.0, 1.0),
			new Point4D(570.590785585664, -405.367200000001, 0.0, 1.0),
			new Point4D(570.590785585664, -405.367200000001, 0.0, 1.0),
			new Point4D(589.401385110468, -405.367200000001, 0.0, 1.0),
			new Point4D(589.401385110468, -405.367200000001, 0.0, 1.0),
			new Point4D(590.341785086712, -405.367200000001, 0.0, 1.0),
			new Point4D(591.094685067692, -406.1191, 0.0, 1.0),
			new Point4D(591.094685067692, -407.059600000001, 0.0, 1.0),
			new Point4D(591.094685067692, -408.001, 0.0, 1.0),
			new Point4D(590.341785086712, -408.7529, 0.0, 1.0),
			new Point4D(589.401385110468, -408.7529, 0.0, 1.0),
			new Point4D(589.401385110468, -408.7529, 0.0, 1.0),
			new Point4D(568.709999999999, -408.7529, 0.0, 1.0),
			new Point4D(568.709999999999, -408.7529, 0.0, 1.0),
			new Point4D(567.721685658144, -408.7529, 0.0, 1.0),
			new Point4D(566.875, -407.906300000001, 0.0, 1.0),
			new Point4D(566.875, -406.872100000001, 0.0, 1.0)
		};
		double[] knotVector22 = new double[56]
		{
			0.0, 0.0, 0.0, 0.0, 1.0, 1.0, 1.0, 2.0, 2.0, 2.0,
			3.0, 3.0, 3.0, 4.0, 4.0, 4.0, 5.0, 5.0, 5.0, 6.0,
			6.0, 6.0, 7.0, 7.0, 7.0, 8.0, 8.0, 8.0, 9.0, 9.0,
			9.0, 10.0, 10.0, 10.0, 11.0, 11.0, 11.0, 12.0, 12.0, 12.0,
			13.0, 13.0, 13.0, 14.0, 14.0, 14.0, 15.0, 15.0, 15.0, 16.0,
			16.0, 16.0, 17.0, 17.0, 17.0, 17.0
		};
		array[22] = new Curve(3, knotVector22, ctrlPoints22);
		return array;
	}

	public static Line[][] BuildHatch(devDept.Eyeshot.Entities.Region reg, double step, double angle)
	{
		if (!Vector3D.AreParallel(reg.Plane.AxisZ, Plane.XY.AxisZ))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663141));
		}
		List<IList<Line>> list = Machining._0023_003DzIBirOvc_003D(reg, angle, step, (Machining._0023_003DzdHAEsWFt2rbg)0, null);
		Line[][] array = new Line[list.Count][];
		for (int i = 0; i < list.Count; i++)
		{
			array[i] = list[i].ToArray();
		}
		return array;
	}

	internal static double _0023_003DqoaiaRco19jqJhXKh2OHCKkvfErFZRXQpPGEP5uqhYfik0_0024aXtiWszKBAojorKslo9t04Rq2h0mYkVz4KCyq66g_003D_003D(double _0023_003Dz_eY3Y4c_003D, double _0023_003Dz77g161c_003D, ref _0023_003DzZsKJFrz2EpH63_0024U44BCgokk_003D _0023_003DzTnHGwq4_003D)
	{
		return (double)_0023_003DzTnHGwq4_003D._0023_003Dz9JZgoew_003D * Math.Pow(_0023_003Dz77g161c_003D, 4.0) + _0023_003DzTnHGwq4_003D._0023_003DzEvUQrI0_003D + 2.0 * _0023_003Dz77g161c_003D * _0023_003Dz77g161c_003D * (double)_0023_003DzTnHGwq4_003D._0023_003Dz9JZgoew_003D * _0023_003DzTnHGwq4_003D._0023_003Dzfm4oGj8_003D + _0023_003DzTnHGwq4_003D._0023_003Dzkxp9QWw_003D * _0023_003Dz_eY3Y4c_003D * _0023_003Dz_eY3Y4c_003D * (double)_0023_003DzTnHGwq4_003D._0023_003Dz9JZgoew_003D + (double)(4 * _0023_003DzTnHGwq4_003D._0023_003Dz9JZgoew_003D) * Math.Pow(_0023_003Dz77g161c_003D, 3.0) * _0023_003DzTnHGwq4_003D._0023_003DzCVdPoWM_003D / 3.0 - _0023_003DzTnHGwq4_003D._0023_003DzN9y2G9c_003D * (double)_0023_003DzTnHGwq4_003D._0023_003Dz9JZgoew_003D * _0023_003Dz77g161c_003D * _0023_003Dz77g161c_003D * _0023_003Dz_eY3Y4c_003D + 4.0 * _0023_003Dz77g161c_003D * (double)_0023_003DzTnHGwq4_003D._0023_003Dz9JZgoew_003D * _0023_003DzTnHGwq4_003D._0023_003DzGQE5xwU_003D - 2.0 * _0023_003DzTnHGwq4_003D._0023_003DzJKjUKZ4_003D * _0023_003Dz_eY3Y4c_003D * (double)_0023_003DzTnHGwq4_003D._0023_003Dz9JZgoew_003D - 2.0 * _0023_003Dz77g161c_003D * _0023_003Dz_eY3Y4c_003D * (double)_0023_003DzTnHGwq4_003D._0023_003Dz9JZgoew_003D * _0023_003DzTnHGwq4_003D._0023_003DzH8_0024G110_003D;
	}

	internal static void _0023_003Dq4bDZkS0myc5_KN6nHHXjdJu4V_0024XyFWh1zjCk_Fygi9E_003D<T>(int _0023_003DzAqOpw0w_003D, int _0023_003Dzk64JNOo_003D, ref _0023_003DzdK0ygWN7LNhApRmmGzJ5bl0_003D<T> _0023_003DzTnHGwq4_003D)
	{
		while (_0023_003DzAqOpw0w_003D < _0023_003Dzk64JNOo_003D)
		{
			T value = _0023_003DzTnHGwq4_003D._0023_003DzcDEsV8s_003D[_0023_003DzAqOpw0w_003D];
			_0023_003DzTnHGwq4_003D._0023_003DzcDEsV8s_003D[_0023_003DzAqOpw0w_003D++] = _0023_003DzTnHGwq4_003D._0023_003DzcDEsV8s_003D[_0023_003Dzk64JNOo_003D];
			_0023_003DzTnHGwq4_003D._0023_003DzcDEsV8s_003D[_0023_003Dzk64JNOo_003D--] = value;
		}
	}
}
