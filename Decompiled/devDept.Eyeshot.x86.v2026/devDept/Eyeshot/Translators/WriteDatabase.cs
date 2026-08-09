using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using ODA.Drawings.PlotSettingsValidator;
using ODA.Drawings.TD_DbCoreIntegrated;
using ODA.Kernel.TD_RootIntegrated;
using devDept.Diagnostic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public abstract class WriteDatabase : WriteFileAsyncWithUnits
{
	internal sealed class _0023_003DzKyfEzVn70e7f
	{
		internal struct _0023_003DztkCSqsUNusrt(OdDbObjectId _0023_003DzPjbPPps_003D, string _0023_003DzyTMhpZk_003D)
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public OdDbObjectId _0023_003DzuaKKESU_003D = _0023_003DzPjbPPps_003D;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public string _0023_003DzyTMhpZk_003D = _0023_003DzyTMhpZk_003D;
		}

		internal string _0023_003DzNPYQWFmJWAm9;

		internal bool _0023_003DzHGfwTrs_003D;

		internal double _0023_003Dz8NH_0024q0LqZMz86QOwVLTvO54_003D;

		internal double _0023_003Dz4JDubhm_0024SsISGTxglqAsn10TKL8x;

		private bool _0023_003DzltVsGoCNDmPhD1mYbz_0024jQ2s_003D;

		private Color _0023_003DzLDxPGlSONGm_0024GGm_iw_003D_003D = Color.White;

		internal bool _0023_003Dz4MwBDBTtsrsJj4VGiw_003D_003D;

		internal bool _0023_003Dz1iDsSuYGoT3xz1G6CQ_003D_003D;

		internal bool _0023_003Dzhf6uXz_0024l6dpO;

		internal linearUnitsType _0023_003DzDAi5BZ1ecRzR;

		private lineWeightUnitsType _0023_003Dzlg6SeyP6ObQxI9OaB2wlSJ0_003D;

		private float _0023_003Dz32FEdL3eiQOuj9lQwTa_0024V_00240_003D;

		private OdDbObjectId _0023_003Dz7MLJt9pUY2gV;

		internal int _0023_003DzsGX1y6oLSiDGWFx2aw_003D_003D;

		private OdDbBlockTableRecord _0023_003DzIk_w3CK1oK_0024CvEzyk_0024_002421ec_003D;

		private OdDbDatabase _0023_003DzNZgjdBRoBl0h8zsBlw_003D_003D;

		private LayerKeyedCollection _0023_003DzI7dpPaM8_OEX2k77Kg_003D_003D;

		private BlockKeyedCollection _0023_003Dzr_xx0wnXwzqsUG5KIg_003D_003D;

		private Sheet _0023_003Dzyop4XF72QzRPcG58nA_003D_003D;

		private TextStyleKeyedCollection _0023_003DzJ2oGh8I6i0Af_EZFJA_003D_003D;

		private TextStyle _0023_003Dz98naOKmM6wiC;

		private LineTypeKeyedCollection _0023_003DzLrh26nxjiLqf7BcT0Q_003D_003D;

		private attributeReferenceVisibilityType _0023_003DzpMR_0024PstNu0_0024_0024VP15ig_003D_003D = attributeReferenceVisibilityType.Normal;

		private string _0023_003Dz4gJjPe4_003D;

		private string _0023_003Dz6qxu2HNgn0Hc;

		private string _0023_003Dz5cP8cGzrsvvP;

		internal Dictionary<string, OdDbObjectId> _0023_003Dz4c0qJg8waJ38 = new Dictionary<string, OdDbObjectId>(StringComparer.OrdinalIgnoreCase);

		internal Dictionary<string, OdDbObjectId> _0023_003DzMD3OMd7A7ssm = new Dictionary<string, OdDbObjectId>(StringComparer.OrdinalIgnoreCase);

		internal Dictionary<string, OdDbObjectId> _0023_003DzZPcQ4wkr_0024Dy8MdR3GahoFfw_003D = new Dictionary<string, OdDbObjectId>(StringComparer.OrdinalIgnoreCase);

		private Dictionary<string, string> _0023_003DzJA1W80moB2y_0024 = new Dictionary<string, string>();

		private Dictionary<string, _0023_003DztkCSqsUNusrt> _0023_003DzHcboNMSsk8CK = new Dictionary<string, _0023_003DztkCSqsUNusrt>();

		internal _0023_003DzKyfEzVn70e7f(OdDbBlockTableRecord _0023_003Dz1EtocfNGByJv, OdDbDatabase _0023_003Dzd2hFvl0_003D, string _0023_003DzTy1t0gY_003D, LayerKeyedCollection _0023_003Dz68IvW_AooqDP, BlockKeyedCollection _0023_003DzFyBLmv3KS6Nt, TextStyleKeyedCollection _0023_003Dzc3aLSLYhP84G, LineTypeKeyedCollection _0023_003Dziw5fCBSsasyX, bool _0023_003Dz_sf9dBZZ1poK, double _0023_003DzYtMizIs_003D, double _0023_003DzdGTjfa6MRJgl, attributeReferenceVisibilityType _0023_003DzptDEYWRLdwXY, float _0023_003DzowbNHIq7Etf9 = 1f, bool _0023_003DzHGfwTrs_003D = false, lineWeightUnitsType _0023_003DztO5OPB0oehHq = lineWeightUnitsType.Millimeters, string _0023_003Dze_FK0WaY6acJ = null)
		{
			_0023_003DzJsTeTeQ9VUeY(_0023_003Dz1EtocfNGByJv);
			_0023_003Dz6VVPSink4ntM(_0023_003Dzd2hFvl0_003D);
			_0023_003Dz2myn7xsIk_0024_0024z(new LayerKeyedCollection(_0023_003Dz68IvW_AooqDP));
			_0023_003Dz7MLJt9pUY2gV = OdDbRasterImageDef.createImageDictionary(_0023_003Dzd2hFvl0_003D);
			_0023_003DzKF8MVuFZC92h(_0023_003DzTy1t0gY_003D, out var _0023_003DzyTMhpZk_003D, out var _0023_003DzLS7X_M0_003D, out var _0023_003Dz6BHBKHWo_s8K);
			_0023_003DzyRwgMtE_003D(_0023_003DzyTMhpZk_003D);
			_0023_003DzuoM6MbI8ilL_(_0023_003DzLS7X_M0_003D);
			_0023_003DzBC_6dgp1g5Z9uY_Cmg_003D_003D(_0023_003Dz6BHBKHWo_s8K);
			_0023_003DzDIUoqxhc7sL1(_0023_003DzFyBLmv3KS6Nt);
			_0023_003DzJpLe7FIn9ly_0024(_0023_003Dzc3aLSLYhP84G);
			_0023_003DzQE3UZi3kJzXg(_0023_003Dziw5fCBSsasyX);
			_0023_003Dzgg4hEQsdch0t(_0023_003Dz_sf9dBZZ1poK);
			this._0023_003DzHGfwTrs_003D = _0023_003DzHGfwTrs_003D;
			_0023_003Dz8NH_0024q0LqZMz86QOwVLTvO54_003D = _0023_003DzYtMizIs_003D;
			_0023_003Dz4JDubhm_0024SsISGTxglqAsn10TKL8x = _0023_003DzdGTjfa6MRJgl;
			_0023_003DzxqJcffHenU2B(_0023_003DztO5OPB0oehHq);
			_0023_003DzHlmRTTvVVj0u(_0023_003DzowbNHIq7Etf9);
			_0023_003Dz5okto_C9piP4yvtd6g_003D_003D(_0023_003DzptDEYWRLdwXY);
			_0023_003DzNPYQWFmJWAm9 = _0023_003Dze_FK0WaY6acJ;
		}

		internal bool _0023_003DzujvIJ3_tyt6U()
		{
			return _0023_003DzltVsGoCNDmPhD1mYbz_0024jQ2s_003D;
		}

		internal void _0023_003Dzgg4hEQsdch0t(bool _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003DzltVsGoCNDmPhD1mYbz_0024jQ2s_003D = _0023_003Dzdc1k2Kc_003D;
		}

		internal Color _0023_003DzFVrp9CCbpZz_0024()
		{
			return _0023_003DzLDxPGlSONGm_0024GGm_iw_003D_003D;
		}

		internal void _0023_003DzYn330TSKENIF(Color _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003DzLDxPGlSONGm_0024GGm_iw_003D_003D = _0023_003Dzdc1k2Kc_003D;
		}

		public lineWeightUnitsType _0023_003Dz_GNl1_0024oPxrrc()
		{
			return _0023_003Dzlg6SeyP6ObQxI9OaB2wlSJ0_003D;
		}

		public void _0023_003DzxqJcffHenU2B(lineWeightUnitsType _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003Dzlg6SeyP6ObQxI9OaB2wlSJ0_003D = _0023_003Dzdc1k2Kc_003D;
		}

		public float _0023_003DzDOMSCwx9uFf5()
		{
			return _0023_003Dz32FEdL3eiQOuj9lQwTa_0024V_00240_003D;
		}

		private void _0023_003DzHlmRTTvVVj0u(float _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003Dz32FEdL3eiQOuj9lQwTa_0024V_00240_003D = _0023_003Dzdc1k2Kc_003D;
		}

		internal static void _0023_003DzKF8MVuFZC92h(string _0023_003DzTy1t0gY_003D, out string _0023_003DzyTMhpZk_003D, out string _0023_003DzLS7X_M0_003D, out string _0023_003Dz6BHBKHWo_s8K)
		{
			_0023_003DzyTMhpZk_003D = null;
			_0023_003DzLS7X_M0_003D = null;
			if (!string.IsNullOrEmpty(_0023_003DzTy1t0gY_003D))
			{
				_0023_003DzyTMhpZk_003D = Path.GetDirectoryName(_0023_003DzTy1t0gY_003D);
				_0023_003DzLS7X_M0_003D = Path.GetFileName(_0023_003DzTy1t0gY_003D);
				if (!string.IsNullOrEmpty(_0023_003DzLS7X_M0_003D))
				{
					_0023_003DzLS7X_M0_003D = _0023_003DzLS7X_M0_003D.Substring(0, _0023_003DzLS7X_M0_003D.Length - 4);
				}
			}
			if (string.IsNullOrEmpty(_0023_003DzyTMhpZk_003D))
			{
				_0023_003DzyTMhpZk_003D = Directory.GetCurrentDirectory();
			}
			if (string.IsNullOrEmpty(_0023_003DzLS7X_M0_003D))
			{
				_0023_003DzLS7X_M0_003D = _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518001);
			}
			_0023_003DzyTMhpZk_003D += _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517983);
			_0023_003Dz6BHBKHWo_s8K = _0023_003DzyTMhpZk_003D + _0023_003DzLS7X_M0_003D + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517975);
		}

		internal OdDbObjectId _0023_003DzK_0024xRe1S_rqh9()
		{
			return _0023_003Dz7MLJt9pUY2gV;
		}

		internal string _0023_003Dzf9SmUfU_003D()
		{
			return _0023_003Dz4gJjPe4_003D;
		}

		internal void _0023_003DzyRwgMtE_003D(string _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003Dz4gJjPe4_003D = _0023_003Dzdc1k2Kc_003D;
		}

		internal string _0023_003DzEHeTa4hPpAa2()
		{
			return _0023_003Dz6qxu2HNgn0Hc;
		}

		internal void _0023_003DzuoM6MbI8ilL_(string _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003Dz6qxu2HNgn0Hc = _0023_003Dzdc1k2Kc_003D;
		}

		internal string _0023_003DzxE6pBeCcqhBAmtKm3A_003D_003D()
		{
			return _0023_003Dz5cP8cGzrsvvP;
		}

		internal void _0023_003DzBC_6dgp1g5Z9uY_Cmg_003D_003D(string _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003Dz5cP8cGzrsvvP = _0023_003Dzdc1k2Kc_003D;
		}

		internal Dictionary<string, _0023_003DztkCSqsUNusrt> _0023_003DzN6p3ohvSmsu4()
		{
			return _0023_003DzHcboNMSsk8CK;
		}

		internal void _0023_003DzJP7_0024bYJVahyK(Dictionary<string, _0023_003DztkCSqsUNusrt> _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003DzHcboNMSsk8CK = _0023_003Dzdc1k2Kc_003D;
		}

		public OdDbBlockTableRecord _0023_003DzZqUFYw1FQIHO()
		{
			return _0023_003DzIk_w3CK1oK_0024CvEzyk_0024_002421ec_003D;
		}

		public void _0023_003DzJsTeTeQ9VUeY(OdDbBlockTableRecord _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003DzIk_w3CK1oK_0024CvEzyk_0024_002421ec_003D = _0023_003Dzdc1k2Kc_003D;
		}

		public OdDbDatabase _0023_003DzbXRspLkELXCh()
		{
			return _0023_003DzNZgjdBRoBl0h8zsBlw_003D_003D;
		}

		public void _0023_003Dz6VVPSink4ntM(OdDbDatabase _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003DzNZgjdBRoBl0h8zsBlw_003D_003D = _0023_003Dzdc1k2Kc_003D;
		}

		internal LayerKeyedCollection _0023_003Dzr4B1w_OXMWkt()
		{
			return _0023_003DzI7dpPaM8_OEX2k77Kg_003D_003D;
		}

		internal void _0023_003Dz2myn7xsIk_0024_0024z(LayerKeyedCollection _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003DzI7dpPaM8_OEX2k77Kg_003D_003D = _0023_003Dzdc1k2Kc_003D;
		}

		internal BlockKeyedCollection _0023_003DzXOYNmXUz4Tcl()
		{
			return _0023_003Dzr_xx0wnXwzqsUG5KIg_003D_003D;
		}

		internal void _0023_003DzDIUoqxhc7sL1(BlockKeyedCollection _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003Dzr_xx0wnXwzqsUG5KIg_003D_003D = _0023_003Dzdc1k2Kc_003D;
		}

		internal Sheet _0023_003Dz_gnOOU92zK_s()
		{
			return _0023_003Dzyop4XF72QzRPcG58nA_003D_003D;
		}

		internal void _0023_003Dzz3btBKF70SPz(Sheet _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003Dzyop4XF72QzRPcG58nA_003D_003D = _0023_003Dzdc1k2Kc_003D;
		}

		public TextStyleKeyedCollection _0023_003Dz_0024FFVZEHAUJk7()
		{
			return _0023_003DzJ2oGh8I6i0Af_EZFJA_003D_003D;
		}

		internal void _0023_003DzJpLe7FIn9ly_0024(TextStyleKeyedCollection _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003DzJ2oGh8I6i0Af_EZFJA_003D_003D = _0023_003Dzdc1k2Kc_003D;
		}

		internal TextStyle _0023_003DzLBMQhl8GsJK7(string _0023_003DzkrK9jgU_003D)
		{
			if (string.IsNullOrEmpty(_0023_003DzkrK9jgU_003D))
			{
				if (_0023_003Dz98naOKmM6wiC == null)
				{
					_0023_003Dz98naOKmM6wiC = new TextStyleKeyedCollection(_0023_003Dz_0024FFVZEHAUJk7())[null];
				}
				return _0023_003Dz98naOKmM6wiC;
			}
			return _0023_003Dz_0024FFVZEHAUJk7()[_0023_003DzkrK9jgU_003D];
		}

		public LineTypeKeyedCollection _0023_003DzfU2XkQAIbouE()
		{
			return _0023_003DzLrh26nxjiLqf7BcT0Q_003D_003D;
		}

		internal void _0023_003DzQE3UZi3kJzXg(LineTypeKeyedCollection _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003DzLrh26nxjiLqf7BcT0Q_003D_003D = _0023_003Dzdc1k2Kc_003D;
		}

		public attributeReferenceVisibilityType _0023_003Dz91fFQBrO1GBf1_nraw_003D_003D()
		{
			return _0023_003DzpMR_0024PstNu0_0024_0024VP15ig_003D_003D;
		}

		public void _0023_003Dz5okto_C9piP4yvtd6g_003D_003D(attributeReferenceVisibilityType _0023_003Dzdc1k2Kc_003D)
		{
			_0023_003DzpMR_0024PstNu0_0024_0024VP15ig_003D_003D = _0023_003Dzdc1k2Kc_003D;
		}

		internal static OdDbObjectId _0023_003DzER_0024be_edpFIg(OdDbTextStyleTable _0023_003DzIv_4qks_003D, OdDbTextStyleTableRecord _0023_003Dz0XEZEQY_003D, string _0023_003DzkrK9jgU_003D, string _0023_003DzL8Hxpzo_003D, string _0023_003DzLS7X_M0_003D, bool _0023_003Dz5q0miVg_003D, bool _0023_003Dz_0024CjJ2p4_003D, double _0023_003Dz_5NSVV5FjWsK)
		{
			_0023_003Dz0XEZEQY_003D.setName(_0023_003DzkrK9jgU_003D);
			OdDbObjectId result = _0023_003DzIv_4qks_003D.add(_0023_003Dz0XEZEQY_003D);
			_0023_003Dz0XEZEQY_003D.setXScale(_0023_003Dz_5NSVV5FjWsK);
			_0023_003Dz0XEZEQY_003D.setFileName(_0023_003DzLS7X_M0_003D);
			if (!string.IsNullOrEmpty(_0023_003DzL8Hxpzo_003D))
			{
				_0023_003Dz0XEZEQY_003D.setFont(_0023_003DzL8Hxpzo_003D, _0023_003Dz5q0miVg_003D, _0023_003Dz_0024CjJ2p4_003D, 0, 0);
			}
			_0023_003Dz0XEZEQY_003D.setTextSize(0.0);
			return result;
		}

		internal static FontStyle _0023_003DzUKqqj5jVq6VSnKlzpPedCok_003D(FontStyle _0023_003Dzn3m49BPvVQSo, out bool _0023_003Dz5q0miVg_003D, out bool _0023_003Dz_0024CjJ2p4_003D)
		{
			FontStyle fontStyle2 = FontStyle.Regular;
			_0023_003Dz5q0miVg_003D = _0023_003DzcgqtdOY_003D(_0023_003Dzn3m49BPvVQSo);
			if (_0023_003Dz5q0miVg_003D)
			{
				fontStyle2 |= FontStyle.Bold;
			}
			_0023_003Dz_0024CjJ2p4_003D = _0023_003Dz_PEqetw_003D(_0023_003Dzn3m49BPvVQSo);
			if (_0023_003Dz_0024CjJ2p4_003D)
			{
				fontStyle2 |= FontStyle.Italic;
			}
			return fontStyle2;
		}

		private static bool _0023_003DzcgqtdOY_003D(FontStyle _0023_003Dzn3m49BPvVQSo)
		{
			return (_0023_003Dzn3m49BPvVQSo & FontStyle.Bold) == FontStyle.Bold;
		}

		private static bool _0023_003Dz_PEqetw_003D(FontStyle _0023_003Dzn3m49BPvVQSo)
		{
			return (_0023_003Dzn3m49BPvVQSo & FontStyle.Italic) == FontStyle.Italic;
		}

		internal OdDbObjectId _0023_003Dzlgdo2AJKqMVX(string _0023_003DzHMyyYsfMn_4Mwi_LuA_003D_003D)
		{
			if (string.IsNullOrEmpty(_0023_003DzHMyyYsfMn_4Mwi_LuA_003D_003D))
			{
				return OdDbObjectId.kNull;
			}
			return _0023_003DzZPcQ4wkr_0024Dy8MdR3GahoFfw_003D[_0023_003DzHMyyYsfMn_4Mwi_LuA_003D_003D];
		}
	}

	protected lineWeightUnitsType lineWeightUnits = lineWeightUnitsType.Millimeters;

	protected TextStyleKeyedCollection textStyles;

	protected LineTypeKeyedCollection lineTypes;

	protected HatchPatternKeyedCollection hatchPatterns;

	protected MaterialKeyedCollection materials;

	protected SheetKeyedCollection sheets;

	protected Dictionary<string, IList<Entity>> sheetsExtraEntities;

	protected bool _explodeViews;

	protected bool curvesAsFitSpline;

	protected bool saveGeometry = true;

	protected bool aciColors = true;

	protected Color foregroundColor = Color.White;

	protected string textureImagesPath;

	protected bool purge;

	protected List<KeyValuePair<short, object>> modelXData;

	protected IViewport viewport;

	protected attributeReferenceVisibilityType attributeReferenceVisibilityMode;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly OdDbMText_AttachmentPoint[,] _0023_003Dz_00242ondg2w093e = new OdDbMText_AttachmentPoint[4, 6]
	{
		{
			OdDbMText_AttachmentPoint.kBaseLeft,
			OdDbMText_AttachmentPoint.kBaseCenter,
			OdDbMText_AttachmentPoint.kBaseRight,
			OdDbMText_AttachmentPoint.kBaseAlign,
			OdDbMText_AttachmentPoint.kBaseMid,
			OdDbMText_AttachmentPoint.kBaseFit
		},
		{
			OdDbMText_AttachmentPoint.kBottomLeft,
			OdDbMText_AttachmentPoint.kBottomCenter,
			OdDbMText_AttachmentPoint.kBottomRight,
			OdDbMText_AttachmentPoint.kBottomAlign,
			OdDbMText_AttachmentPoint.kBottomMid,
			OdDbMText_AttachmentPoint.kBottomFit
		},
		{
			OdDbMText_AttachmentPoint.kMiddleLeft,
			OdDbMText_AttachmentPoint.kMiddleCenter,
			OdDbMText_AttachmentPoint.kMiddleRight,
			OdDbMText_AttachmentPoint.kMiddleAlign,
			OdDbMText_AttachmentPoint.kMiddleMid,
			OdDbMText_AttachmentPoint.kMiddleFit
		},
		{
			OdDbMText_AttachmentPoint.kTopLeft,
			OdDbMText_AttachmentPoint.kTopCenter,
			OdDbMText_AttachmentPoint.kTopRight,
			OdDbMText_AttachmentPoint.kTopAlign,
			OdDbMText_AttachmentPoint.kTopMid,
			OdDbMText_AttachmentPoint.kTopFit
		}
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static HashSet<string> _0023_003Dz6qjGZbgwhBed = new HashSet<string>
	{
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528962),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518063),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518051),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518068),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518025),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518042),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518127),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518112),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518133),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518086),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518107),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518189),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518204),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518193),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518144),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518163),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516709),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516724),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516679),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516694),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516777),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516795),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516785),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516741),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516761),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516843),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516862),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516853),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516809),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516828),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516817),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516900),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516920),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516877),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516864),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516884),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516456),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516477),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516467),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516423),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516443),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516527),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516536),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516485),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516590),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516603),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516548),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516561),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516666),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516615),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516624),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517245),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517190),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517203),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517308),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517257),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517276),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517264),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517350),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517373),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517361),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517314),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517335),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517416),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517436),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517424),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517380),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517400),
		_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516973)
	};

	public static supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.All;

	protected WriteDatabase(WriteDatabaseParams writeParams, Stream stream)
		: base(writeParams, stream)
	{
		_0023_003DzqNFgFJPR60_B(writeParams);
	}

	protected WriteDatabase(WriteDatabaseParams writeParams, string filePath)
		: base(writeParams, filePath)
	{
		_0023_003DzqNFgFJPR60_B(writeParams);
	}

	protected WriteDatabase(string filePath, bool selectedOnly = false)
		: base(filePath, selectedOnly)
	{
	}

	protected WriteDatabase(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, Stream stream, linearUnitsType units)
		: base(entList, layerList, blockDict, stream, units)
	{
	}

	protected WriteDatabase(IList<Entity> entList, IEnumerable<Layer> layerList, IDictionary<string, Block> blockDict, string filePath, linearUnitsType units)
		: base(entList, layerList, blockDict, filePath, units)
	{
	}

	private void _0023_003DzqNFgFJPR60_B(WriteDatabaseParams _0023_003DzPE_0024Wv_0024xbODq9)
	{
		lineWeightUnits = _0023_003DzPE_0024Wv_0024xbODq9.LineWeightUnits;
		viewport = _0023_003DzPE_0024Wv_0024xbODq9.Viewport;
		attributeReferenceVisibilityMode = _0023_003DzPE_0024Wv_0024xbODq9.AttributeReferenceVisibilityMode;
		purge = _0023_003DzPE_0024Wv_0024xbODq9.Purge;
		if (_0023_003DzPE_0024Wv_0024xbODq9.TextStyles != null)
		{
			textStyles = new TextStyleKeyedCollection(_0023_003DzPE_0024Wv_0024xbODq9.TextStyles);
		}
		materials = new MaterialKeyedCollection(_0023_003DzPE_0024Wv_0024xbODq9.Materials);
		lineTypes = new LineTypeKeyedCollection(_0023_003DzPE_0024Wv_0024xbODq9.LineTypes);
		lineTypeScale = _0023_003DzPE_0024Wv_0024xbODq9.LineTypeScale;
		hatchPatterns = new HatchPatternKeyedCollection(_0023_003DzPE_0024Wv_0024xbODq9.HatchPatterns);
		hatchPatterns.Measurement = _0023_003DzPE_0024Wv_0024xbODq9.HatchPatterns.Measurement;
		PurgeCollectionsForOpenBlock(ref materials, ref textStyles, ref lineTypes, ref hatchPatterns);
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003Dz59lijRsT8LI_0024XHJOQ_0024AIGNJAuo4Gno8YZbyXhC6NbIN90_6Sbg_003D_003D._0023_003DzdzZLZbiwVTg1a0D6OXj_pZ7Vxsm1I1oH6u_0024_fyl4AGtqqQqxXQ_003D_003D()._0023_003DzcuxJrsHQF_Rj5c_67u2AJCIjdCLa(_0023_003Dz59lijRsT8LI_0024XHJOQ_0024AIGNJAuo4Gno8YZbyXhC6NbIN90_6Sbg_003D_003D._0023_003Dz9h7prLD836B0_0024F42nFw7qcyRyorkXYYKZ0vX9bIws0q0ILDt6g_003D_003D(), "p&4miq\"adM", array);
		if (!SupportedLinearUnitsType.HasFlag(Utility.GetSupportedLinearUnits(units)))
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518314) + units);
		}
		MemoryTransaction memoryTransaction = MemoryManager.GetMemoryManager().StartTransaction();
		try
		{
			IList<Entity> list = GetEntities();
			_0023_003Dzqd_B62LuTiuE(list, layers, blocks, textStyles, lineTypes, materials, out var _0023_003DzxyKqJGqsMOpmzMxskw_003D_003D, out var _0023_003DzdwXUAt55V94f, out var _0023_003DzpQDP4NbryDRj, out var _0023_003DzN3NoDUp6A05iLpBqliiODvw_003D, out var _, out var _0023_003Dz1yl8n3yUTC6e);
			SynchronizeAttributeReference(_0023_003Dz1yl8n3yUTC6e, list);
			if (sheets != null)
			{
				foreach (Sheet sheet in sheets)
				{
					SynchronizeAttributeReference(_0023_003Dz1yl8n3yUTC6e, sheet.Entities);
				}
			}
			if (_0023_003DzxyKqJGqsMOpmzMxskw_003D_003D.Count == 0)
			{
				throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518377));
			}
			ExHostAppServices exHostAppServices = new ExHostAppServices();
			memoryTransaction.AddObject(exHostAppServices);
			exHostAppServices.disableOutput(disable: true);
			OdDbDatabase pDb = exHostAppServices.createDatabase(createDefault: true);
			WriteDatabaseInternal(string.Empty, list, progress, ct, pDb, _0023_003DzxyKqJGqsMOpmzMxskw_003D_003D, _0023_003Dz1yl8n3yUTC6e, null, _0023_003DzdwXUAt55V94f, _0023_003DzpQDP4NbryDRj, _0023_003DzN3NoDUp6A05iLpBqliiODvw_003D, attributeReferenceVisibilityMode);
		}
		catch (Exception ex)
		{
			log.AppendLine(ex.Message);
			throw new EyeshotException(ex.Message, ex);
		}
		finally
		{
			MemoryManager.GetMemoryManager().StopTransaction(memoryTransaction);
		}
	}

	private void _0023_003Dzqd_B62LuTiuE(IList<Entity> _0023_003DzmK54snhR6Xwp, LayerKeyedCollection _0023_003Dz68IvW_AooqDP, BlockKeyedCollection _0023_003DzFyBLmv3KS6Nt, TextStyleKeyedCollection _0023_003Dzc3aLSLYhP84G, LineTypeKeyedCollection _0023_003Dziw5fCBSsasyX, MaterialKeyedCollection _0023_003DzN0ZWdMqGnIFK8BemCQ_003D_003D, out LayerKeyedCollection _0023_003DzxyKqJGqsMOpmzMxskw_003D_003D, out TextStyleKeyedCollection _0023_003DzdwXUAt55V94f, out LineTypeKeyedCollection _0023_003DzpQDP4NbryDRj, out MaterialKeyedCollection _0023_003DzN3NoDUp6A05iLpBqliiODvw_003D, out Dictionary<string, string> _0023_003Dz9JyhtH6kCI33, out BlockKeyedCollection _0023_003Dz1yl8n3yUTC6e)
	{
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzSothfIG2mlbP();
		_0023_003Dz1yl8n3yUTC6e = _0023_003DzobR8DJrUi6Yu(null, string.Empty, _0023_003DzFyBLmv3KS6Nt, _0023_003DzmK54snhR6Xwp, this is Write3DPDF);
		_0023_003DzxyKqJGqsMOpmzMxskw_003D_003D = _0023_003DzBBXKkG65XrJN(string.Empty, string.Empty, _0023_003Dz68IvW_AooqDP, _0023_003DzFyBLmv3KS6Nt, _0023_003DzmK54snhR6Xwp, out _0023_003Dz9JyhtH6kCI33);
		_0023_003DzdwXUAt55V94f = _0023_003Dz3WHYiTYwY2ClnmiJ6A_003D_003D<TextStyleKeyedCollection, TextStyle>(string.Empty, string.Empty, _0023_003Dzc3aLSLYhP84G);
		_0023_003DzpQDP4NbryDRj = _0023_003Dz3WHYiTYwY2ClnmiJ6A_003D_003D<LineTypeKeyedCollection, LineType>(string.Empty, string.Empty, _0023_003Dziw5fCBSsasyX);
		_0023_003DzN3NoDUp6A05iLpBqliiODvw_003D = _0023_003DzN0ZWdMqGnIFK8BemCQ_003D_003D;
		Autodesk.InitializeServices();
		Logger.Instance.Trace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518365));
		if (_0023_003DzP5BxsHqkgBUsubhPkA_003D_003D._0023_003Dzun1LQstwai0q())
		{
			TD_RootIntegrated_Globals.odrxDynamicLinker().loadApp(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518414)).Dispose();
			Logger.Instance.Trace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518424));
		}
	}

	internal void _0023_003DzIe4F3qbVyQHL(BlockKeyedCollection _0023_003Dzl7J42PTjIXfn)
	{
		blocks = _0023_003Dzl7J42PTjIXfn;
	}

	internal void _0023_003DzxzkMs81g9yTTR8P8Cg_003D_003D(LayerKeyedCollection _0023_003DzhsO0Q_PL_rlY, BlockKeyedCollection _0023_003DziXS7DNI_003D, TextStyleKeyedCollection _0023_003Dz7ip8s1p1cPxO, LineTypeKeyedCollection _0023_003Dz81YVQnrKmt6N, MaterialKeyedCollection _0023_003DzmQzBmUxRsGtswIuVtQ_003D_003D)
	{
		for (int i = 0; i < _0023_003DzhsO0Q_PL_rlY.Count; i++)
		{
			if (string.IsNullOrEmpty(_0023_003DzhsO0Q_PL_rlY[i].Name))
			{
				throw new EyeshotException(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355516990), i));
			}
		}
		for (int j = 0; j < _0023_003DziXS7DNI_003D.Count; j++)
		{
			if (string.IsNullOrEmpty(_0023_003DziXS7DNI_003D[j].Name))
			{
				throw new EyeshotException(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517042), j));
			}
		}
		for (int k = 0; k < _0023_003Dz7ip8s1p1cPxO.Count; k++)
		{
			if (string.IsNullOrEmpty(_0023_003Dz7ip8s1p1cPxO[k].Name))
			{
				throw new EyeshotException(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517062), k));
			}
		}
		for (int l = 0; l < _0023_003Dz81YVQnrKmt6N.Count; l++)
		{
			if (string.IsNullOrEmpty(_0023_003Dz81YVQnrKmt6N[l].Name))
			{
				throw new EyeshotException(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517142), l));
			}
		}
		if (_0023_003DzmQzBmUxRsGtswIuVtQ_003D_003D == null)
		{
			return;
		}
		for (int m = 0; m < _0023_003DzmQzBmUxRsGtswIuVtQ_003D_003D.Count; m++)
		{
			if (string.IsNullOrEmpty(_0023_003DzmQzBmUxRsGtswIuVtQ_003D_003D[m].Name))
			{
				throw new EyeshotException(string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519849), m));
			}
		}
	}

	protected void WriteDatabaseInternal(string xRefName, IList<Entity> myEntities, IProgress<ProgressChangedEventArgs> progress, CancellationToken ct, OdDbDatabase pDb, LayerKeyedCollection layersToSave, BlockKeyedCollection blocksToSave, Dictionary<string, string> currXRefPaths, TextStyleKeyedCollection textStylesToSave, LineTypeKeyedCollection lineTypesToSave, MaterialKeyedCollection materialsToSave, attributeReferenceVisibilityType attributeReferenceVisibility, float ltScale = 1f, bool append = false, string textureImagesPath = null)
	{
		_0023_003DzxzkMs81g9yTTR8P8Cg_003D_003D(layersToSave, blocksToSave, textStylesToSave, lineTypesToSave, materialsToSave);
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		_0023_003DzKyfEzVn70e7f obj = new _0023_003DzKyfEzVn70e7f(null, pDb, base.FilePath, layersToSave, blocksToSave, textStylesToSave, lineTypesToSave, aciColors, base.Deviation, base.Angle, attributeReferenceVisibility, ltScale, append, lineWeightUnits, textureImagesPath);
		obj._0023_003DzDAi5BZ1ecRzR = units;
		obj._0023_003Dz4MwBDBTtsrsJj4VGiw_003D_003D = _explodeViews;
		obj._0023_003Dz1iDsSuYGoT3xz1G6CQ_003D_003D = curvesAsFitSpline;
		obj._0023_003Dzhf6uXz_0024l6dpO = saveGeometry;
		obj._0023_003DzNPYQWFmJWAm9 = textureImagesPath;
		obj._0023_003DzYn330TSKENIF(foregroundColor);
		_0023_003DzKyfEzVn70e7f _0023_003DzKyfEzVn70e7f2 = obj;
		if (currXRefPaths != null)
		{
			foreach (KeyValuePair<string, string> currXRefPath in currXRefPaths)
			{
				if (blocksToSave.Contains(currXRefPath.Key))
				{
					OdDbBlockTableRecord odDbBlockTableRecord = OdDbXRefManExt.addNewXRefDefBlock(pDb, currXRefPath.Value, currXRefPath.Key, overlaid: false);
					OdDbObjectIdArray xrefBTRids = new OdDbObjectIdArray { odDbBlockTableRecord.objectId() };
					OdDbXRefMan.unload(xrefBTRids);
					OdDbXRefMan.load(xrefBTRids);
					_0023_003DzKyfEzVn70e7f2._0023_003DzN6p3ohvSmsu4().Add(currXRefPath.Key, new _0023_003DzKyfEzVn70e7f._0023_003DztkCSqsUNusrt(odDbBlockTableRecord.objectId(), currXRefPath.Value));
				}
			}
		}
		if (_0023_003DzE1Uqgj4Q4YiU(_0023_003DzKyfEzVn70e7f2, xRefName, pDb, layersToSave, blocksToSave, textStylesToSave, lineTypesToSave, materialsToSave, myEntities, selectedOnly, progress, ct))
		{
			StartContinuousAnimation(base.WritingText, progress);
			if (purge)
			{
				OdDbObjectIdArray odDbObjectIdArray = new OdDbObjectIdArray();
				_0023_003DzY204C5xsqaLs((OdDbSymbolTable)pDb.getBlockTableId().openObject(OdDb_OpenMode.kForRead), odDbObjectIdArray);
				_0023_003DzY204C5xsqaLs((OdDbSymbolTable)pDb.getDimStyleTableId().openObject(OdDb_OpenMode.kForRead), odDbObjectIdArray);
				_0023_003DzY204C5xsqaLs((OdDbSymbolTable)pDb.getLayerTableId().openObject(OdDb_OpenMode.kForRead), odDbObjectIdArray);
				_0023_003DzY204C5xsqaLs((OdDbSymbolTable)pDb.getLinetypeTableId().openObject(OdDb_OpenMode.kForRead), odDbObjectIdArray);
				_0023_003DzY204C5xsqaLs((OdDbSymbolTable)pDb.getTextStyleTableId().openObject(OdDb_OpenMode.kForRead), odDbObjectIdArray);
				pDb.purge(odDbObjectIdArray);
				foreach (OdDbObjectId item in odDbObjectIdArray)
				{
					item.openObject(OdDb_OpenMode.kForWrite).erase();
				}
			}
		}
		WriteFile(pDb);
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}

	protected abstract void WriteFile(OdDbDatabase pDb);

	private void _0023_003DzY204C5xsqaLs(OdDbSymbolTable _0023_003DzVGdFVbA_003D, OdDbObjectIdArray _0023_003DzZY6eAGk_003D)
	{
		OdDbSymbolTableIterator odDbSymbolTableIterator = _0023_003DzVGdFVbA_003D.newIterator();
		odDbSymbolTableIterator.start();
		while (!odDbSymbolTableIterator.done())
		{
			_0023_003DzZY6eAGk_003D.Add(odDbSymbolTableIterator.getRecordId());
			odDbSymbolTableIterator.step();
		}
	}

	internal static T _0023_003Dz3WHYiTYwY2ClnmiJ6A_003D_003D<T, Q>(string _0023_003Dz0EA0NeSD2dKB, string _0023_003DzamvOStS9w87S, T _0023_003DzArmdPRQ_003D) where T : EyeshotKeyedCollection<Q>, new() where Q : IKeyedCollectionItem<Q>
	{
		T val = new T();
		if (string.IsNullOrEmpty(_0023_003Dz0EA0NeSD2dKB))
		{
			foreach (Q item in _0023_003DzArmdPRQ_003D)
			{
				if (!(item is IDataEx) || string.IsNullOrEmpty(((IDataEx)(object)item).XRefName))
				{
					val.Add(item);
				}
			}
		}
		else
		{
			foreach (Q item2 in _0023_003DzArmdPRQ_003D)
			{
				if (item2 is IDataEx && ((IDataEx)(object)item2).XRefName == _0023_003Dz0EA0NeSD2dKB)
				{
					val.Add(item2);
				}
			}
		}
		return val;
	}

	internal static Dictionary<string, T> _0023_003Dz3WHYiTYwY2ClnmiJ6A_003D_003D<T>(string _0023_003Dz0EA0NeSD2dKB, string _0023_003DzamvOStS9w87S, IDictionary<string, T> _0023_003DzArmdPRQ_003D) where T : class
	{
		Dictionary<string, T> dictionary = new Dictionary<string, T>();
		if (string.IsNullOrEmpty(_0023_003Dz0EA0NeSD2dKB))
		{
			foreach (KeyValuePair<string, T> item in _0023_003DzArmdPRQ_003D)
			{
				if (!(item.Value is IDataEx) || string.IsNullOrEmpty(((IDataEx)item.Value).XRefName))
				{
					dictionary.Add(item.Key, item.Value);
				}
			}
		}
		else
		{
			foreach (KeyValuePair<string, T> item2 in _0023_003DzArmdPRQ_003D)
			{
				if (item2.Value is IDataEx && ((IDataEx)item2.Value).XRefName == _0023_003Dz0EA0NeSD2dKB)
				{
					dictionary.Add(item2.Key, item2.Value);
				}
			}
		}
		return dictionary;
	}

	internal static LayerKeyedCollection _0023_003DzBBXKkG65XrJN(string _0023_003Dz0EA0NeSD2dKB, string _0023_003DzamvOStS9w87S, LayerKeyedCollection _0023_003DzhsO0Q_PL_rlY, BlockKeyedCollection _0023_003DziXS7DNI_003D, IList<Entity> _0023_003DzLpVMKc8_003D, out Dictionary<string, string> _0023_003DzTlTnTeqJ2Uw23WbwGA_003D_003D)
	{
		LayerKeyedCollection layerKeyedCollection = new LayerKeyedCollection();
		bool flag = !string.IsNullOrEmpty(_0023_003Dz0EA0NeSD2dKB);
		_0023_003DzTlTnTeqJ2Uw23WbwGA_003D_003D = new Dictionary<string, string>();
		for (int i = 0; i < _0023_003DzhsO0Q_PL_rlY.Count; i++)
		{
			Layer layer = _0023_003DzhsO0Q_PL_rlY[i];
			string text = _0023_003Dzmniq5JprCDdq(layer);
			if (!layer.Exportable || (!string.IsNullOrEmpty(_0023_003Dz0EA0NeSD2dKB) && !text.StartsWith(_0023_003Dz0EA0NeSD2dKB) && (flag || !_0023_003DziXS7DNI_003D.Contains(text) || _0023_003DziXS7DNI_003D[text].ExportMode != autodeskExportType.Embedded)))
			{
				continue;
			}
			string text2 = layer.Name.ToUpper();
			if (flag && layer.Name.StartsWith(_0023_003DzamvOStS9w87S))
			{
				Layer layer2 = (Layer)layer.Clone();
				text2 = (layer2.Name = text2.Substring(_0023_003DzamvOStS9w87S.Length));
				if (!_0023_003DzTlTnTeqJ2Uw23WbwGA_003D_003D.ContainsKey(text2))
				{
					_0023_003DzoErE2eM_003D(layer.Name, _0023_003DzTlTnTeqJ2Uw23WbwGA_003D_003D, layerKeyedCollection, layer2);
				}
			}
			else
			{
				_0023_003DzoErE2eM_003D(layer.Name, _0023_003DzTlTnTeqJ2Uw23WbwGA_003D_003D, layerKeyedCollection, layer);
			}
		}
		return layerKeyedCollection;
	}

	private static string _0023_003Dzmniq5JprCDdq(object _0023_003DzmS9zzlg_003D)
	{
		if (_0023_003DzmS9zzlg_003D is IDataEx)
		{
			return ((IDataEx)_0023_003DzmS9zzlg_003D).XRefName;
		}
		return string.Empty;
	}

	private static void _0023_003DzoErE2eM_003D(string _0023_003DzM3bkLpc_003D, Dictionary<string, string> _0023_003Dz6FIr2aKbb5yCjcSQgQ_003D_003D, LayerKeyedCollection _0023_003DzWUDzIqY_003D, Layer _0023_003Dz87hGE54_003D)
	{
		_0023_003Dz6FIr2aKbb5yCjcSQgQ_003D_003D.Add(_0023_003DzM3bkLpc_003D, _0023_003Dz87hGE54_003D.Name);
		_0023_003DzWUDzIqY_003D.Add(_0023_003Dz87hGE54_003D);
	}

	internal static void _0023_003DzjtpB4FpRJxc7(BlockKeyedCollection _0023_003DzNvI8GrA91RSh, Block _0023_003Dz9uVhDi0_003D, bool _0023_003DzEoO49dsZOP0E)
	{
		if (_0023_003DzEoO49dsZOP0E && _0023_003Dz9uVhDi0_003D.ExportMode != autodeskExportType.Embedded)
		{
			_0023_003DzNvI8GrA91RSh.Add(new Block(_0023_003Dz9uVhDi0_003D)
			{
				_exportMode = autodeskExportType.Embedded
			});
		}
		else
		{
			_0023_003DzNvI8GrA91RSh.Add(_0023_003Dz9uVhDi0_003D);
		}
	}

	internal static BlockKeyedCollection _0023_003DzobR8DJrUi6Yu(Block _0023_003DzzZTccC0_003D, string _0023_003Dz0EA0NeSD2dKB, BlockKeyedCollection _0023_003DzFyBLmv3KS6Nt, IList<Entity> _0023_003DzLpVMKc8_003D, bool _0023_003DzEoO49dsZOP0E)
	{
		BlockKeyedCollection blockKeyedCollection = new BlockKeyedCollection();
		if (string.IsNullOrEmpty(_0023_003Dz0EA0NeSD2dKB))
		{
			foreach (Block item in _0023_003DzFyBLmv3KS6Nt)
			{
				if (string.IsNullOrEmpty(item.XRefName))
				{
					_0023_003DzjtpB4FpRJxc7(blockKeyedCollection, item, _0023_003DzEoO49dsZOP0E);
				}
			}
		}
		else
		{
			foreach (Block item2 in _0023_003DzFyBLmv3KS6Nt)
			{
				if (!(item2.XRefName == _0023_003Dz0EA0NeSD2dKB))
				{
					continue;
				}
				Block block = new Block(item2.Name, item2.BasePoint);
				block.Units = item2.Units;
				block._filePath = item2._filePath;
				block._exportMode = item2._exportMode;
				foreach (Entity entity in item2.Entities)
				{
					block.Entities.Add((Entity)entity.Clone());
				}
				_0023_003DzjtpB4FpRJxc7(blockKeyedCollection, block, _0023_003DzEoO49dsZOP0E);
			}
		}
		if (!string.IsNullOrEmpty(_0023_003DzFyBLmv3KS6Nt.RootBlockName))
		{
			blockKeyedCollection.Remove(_0023_003DzFyBLmv3KS6Nt.RootBlockName);
		}
		return blockKeyedCollection;
	}

	protected virtual IList<Entity> SortEntitiesForWriteAutodesk(IList<Entity> entitiesToSave)
	{
		return entitiesToSave;
	}

	private bool _0023_003DzE1Uqgj4Q4YiU(_0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu, string _0023_003Dz0EA0NeSD2dKB, OdDbDatabase _0023_003DzR8GRspk_003D, LayerKeyedCollection _0023_003Dz68IvW_AooqDP, BlockKeyedCollection _0023_003DzFyBLmv3KS6Nt, TextStyleKeyedCollection _0023_003Dzc3aLSLYhP84G, LineTypeKeyedCollection _0023_003Dziw5fCBSsasyX, MaterialKeyedCollection _0023_003DzN0ZWdMqGnIFK8BemCQ_003D_003D, IList<Entity> _0023_003Dz29mwgg0FBLPP, bool _0023_003Dz8PMCTH_0024Bkfwq, IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		bool _0023_003DzDKrJANc_003D = true;
		if (!_0023_003DzwzL57J6ueMIu._0023_003DzHGfwTrs_003D)
		{
			_0023_003DzR8GRspk_003D.setINSUNITS(_0023_003DzC_A_00240jSUbYHi0SaUjw_003D_003D(units));
		}
		_0023_003Dz29mwgg0FBLPP = SortEntitiesForWriteAutodesk(_0023_003Dz29mwgg0FBLPP);
		if (hatchPatterns != null)
		{
			_0023_003DzR8GRspk_003D.setMEASUREMENT((hatchPatterns.Measurement != HatchPatternKeyedCollection.measurementType.Imperial) ? MeasurementValue.kMetric : MeasurementValue.kEnglish);
		}
		_0023_003DzR8GRspk_003D.setATTMODE((short)_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzMwUDQThh00ih_0024EW2k7ao5gzhI7BqcXziYA_003D_003D(_0023_003DzwzL57J6ueMIu._0023_003Dz91fFQBrO1GBf1_nraw_003D_003D()));
		_0023_003DzR8GRspk_003D.setLTSCALE(_0023_003DzwzL57J6ueMIu._0023_003DzDOMSCwx9uFf5());
		OdDbBlockTableRecord odDbBlockTableRecord = (OdDbBlockTableRecord)_0023_003DzR8GRspk_003D.getModelSpaceId().openObject(OdDb_OpenMode.kForWrite);
		string text = odDbBlockTableRecord.getName().TrimStart('*');
		if (!_0023_003DzwzL57J6ueMIu._0023_003DzHGfwTrs_003D && text.ToUpper() != _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529012))
		{
			odDbBlockTableRecord.setBlockInsertUnits(_0023_003DzR8GRspk_003D.getINSUNITS());
		}
		if (modelXData != null)
		{
			try
			{
				OdResBuf xData = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzFAdNEnYlqrJZ(_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzsU8xs6EN_FSS(modelXData, _0023_003DzR8GRspk_003D));
				odDbBlockTableRecord.setXData(xData);
			}
			catch (Exception)
			{
				log.AppendLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519928));
			}
		}
		_0023_003Dz3LPMScrCx9N64txF_g_003D_003D(_0023_003DzR8GRspk_003D, _0023_003DzwzL57J6ueMIu, _0023_003Dz0EA0NeSD2dKB, _0023_003DzN0ZWdMqGnIFK8BemCQ_003D_003D);
		_0023_003DzL_ht5hWbVwnu(_0023_003DzR8GRspk_003D, _0023_003DzwzL57J6ueMIu, _0023_003Dz0EA0NeSD2dKB, _0023_003Dziw5fCBSsasyX);
		_0023_003DznoCAfPY1JuUn(_0023_003DzR8GRspk_003D);
		_0023_003DzPQxPw7A_003D(_0023_003DzR8GRspk_003D, _0023_003DzwzL57J6ueMIu, _0023_003Dz0EA0NeSD2dKB, _0023_003Dz68IvW_AooqDP);
		_0023_003DzPArH_0024bNSkn7_0024(_0023_003DzR8GRspk_003D, _0023_003DzwzL57J6ueMIu, _0023_003Dz0EA0NeSD2dKB, _0023_003Dzc3aLSLYhP84G);
		_0023_003DzH_0024g5Bwc_003D(_0023_003DzR8GRspk_003D, _0023_003DzwzL57J6ueMIu, _0023_003DzFyBLmv3KS6Nt, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D, ref _0023_003DzDKrJANc_003D);
		if (_0023_003DzDKrJANc_003D)
		{
			_0023_003DzFZhkSVA_003D(_0023_003DzR8GRspk_003D, _0023_003DzwzL57J6ueMIu, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
			_0023_003Dz2rzgTJs_003D(odDbBlockTableRecord, _0023_003DzwzL57J6ueMIu, _0023_003Dz29mwgg0FBLPP, _0023_003Dz8PMCTH_0024Bkfwq, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D, ref _0023_003DzDKrJANc_003D);
			_0023_003Dzdi43iqw_003D(_0023_003DzR8GRspk_003D);
		}
		MemoryManager.GetMemoryManager().StopTransaction(value);
		return _0023_003DzDKrJANc_003D;
	}

	private void _0023_003Dz3LPMScrCx9N64txF_g_003D_003D(OdDbDatabase _0023_003DzR8GRspk_003D, _0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu, string _0023_003Dz0EA0NeSD2dKB, MaterialKeyedCollection _0023_003DzN0ZWdMqGnIFK8BemCQ_003D_003D)
	{
		if (_0023_003DzN0ZWdMqGnIFK8BemCQ_003D_003D == null)
		{
			return;
		}
		OdDbDictionary odDbDictionary = (OdDbDictionary)_0023_003DzR8GRspk_003D.getMaterialDictionaryId().openObject(OdDb_OpenMode.kForWrite);
		if (_0023_003DzwzL57J6ueMIu._0023_003DzHGfwTrs_003D)
		{
			OdDbDictionaryIterator odDbDictionaryIterator = odDbDictionary.newIterator();
			while (!odDbDictionaryIterator.done())
			{
				_0023_003DzwzL57J6ueMIu._0023_003DzZPcQ4wkr_0024Dy8MdR3GahoFfw_003D.Add(odDbDictionaryIterator.name(), odDbDictionaryIterator.objectId());
				odDbDictionaryIterator.next();
			}
		}
		foreach (Material item in _0023_003DzN0ZWdMqGnIFK8BemCQ_003D_003D)
		{
			if (_0023_003DzwzL57J6ueMIu._0023_003DzHGfwTrs_003D && _0023_003DzwzL57J6ueMIu._0023_003DzZPcQ4wkr_0024Dy8MdR3GahoFfw_003D.ContainsKey(item.Name))
			{
				continue;
			}
			OdDbMaterial odDbMaterial = OdDbMaterial.createObject();
			odDbMaterial.setName(item.Name);
			odDbMaterial.setDescription(item.Description);
			string text = Regex.Replace(item.Name, string.Format(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519899), Regex.Escape(new string(Path.GetInvalidFileNameChars()))), string.Empty, RegexOptions.None);
			string text2 = null;
			if (item.TextureImage != null)
			{
				text2 = ((this is Write3DPDF) ? (Path.GetTempPath() + _0023_003DzwzL57J6ueMIu._0023_003DzEHeTa4hPpAa2() + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517975) + text + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517897)) : ((_0023_003DzwzL57J6ueMIu._0023_003DzNPYQWFmJWAm9 == null) ? (_0023_003DzwzL57J6ueMIu._0023_003DzxE6pBeCcqhBAmtKm3A_003D_003D() + text + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517897)) : (_0023_003DzwzL57J6ueMIu._0023_003DzNPYQWFmJWAm9 + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517983) + _0023_003DzwzL57J6ueMIu._0023_003DzEHeTa4hPpAa2() + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517975) + text + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517897))));
				using Bitmap bitmap = _0023_003Dz0UqjDJRVjznU032ZobZyG6sRUxOwSxYhJCJ1_WxsRxkgAkSSjABO220_003D._0023_003Dzgx309QbPrd02(item.TextureImage);
				bitmap.Save(text2, ImageFormat.Png);
			}
			OdGiMaterialMap odGiMaterialMap = new OdGiMaterialMap();
			odGiMaterialMap.setSource(OdGiMaterialMap_Source.kFile);
			odGiMaterialMap.setSourceFileName(text2);
			odGiMaterialMap.setBlendFactor(1.0);
			OdGiMaterialColor odGiMaterialColor = new OdGiMaterialColor();
			odGiMaterialColor.setMethod(OdGiMaterialColor_Method.kOverride);
			odGiMaterialColor.setFactor(1.0);
			odGiMaterialColor.setColor(new OdCmEntityColor(item.Ambient.R, item.Ambient.G, item.Ambient.B));
			odDbMaterial.setAmbient(odGiMaterialColor);
			odDbMaterial.setBump(odGiMaterialMap);
			OdGiMaterialColor odGiMaterialColor2 = new OdGiMaterialColor();
			odGiMaterialColor2.setMethod(OdGiMaterialColor_Method.kOverride);
			odGiMaterialColor2.setFactor(1.0);
			odGiMaterialColor2.setColor(new OdCmEntityColor(item.Diffuse.R, item.Diffuse.G, item.Diffuse.B));
			odDbMaterial.setDiffuse(odGiMaterialColor2, odGiMaterialMap);
			OdGiMaterialColor odGiMaterialColor3 = new OdGiMaterialColor();
			odGiMaterialColor3.setMethod(OdGiMaterialColor_Method.kOverride);
			odGiMaterialColor3.setFactor(1.0);
			odGiMaterialColor3.setColor(new OdCmEntityColor(item.Specular.R, item.Specular.G, item.Specular.B));
			odDbMaterial.setSpecular(odGiMaterialColor3, odGiMaterialMap, 0.67);
			odDbMaterial.setOpacity((double)(int)item.Diffuse.A / 255.0, odGiMaterialMap);
			odDbMaterial.setRefraction(1.0, odGiMaterialMap);
			odDbMaterial.setTranslucence(0.0);
			odDbMaterial.setSelfIllumination(0.0);
			odDbMaterial.setReflectivity(0.0);
			odDbMaterial.setMode(OdGiMaterialTraits_Mode.kRealistic);
			odDbMaterial.setChannelFlags(OdGiMaterialTraits_ChannelFlags.kUseDiffuse);
			odDbMaterial.setIlluminationModel(OdGiMaterialTraits_IlluminationModel.kBlinnShader);
			odDbDictionary.setAt(item.Name, odDbMaterial);
			_0023_003DzwzL57J6ueMIu._0023_003DzZPcQ4wkr_0024Dy8MdR3GahoFfw_003D.Add(item.Name, odDbMaterial.objectId());
		}
	}

	private void _0023_003Dz2rzgTJs_003D(OdDbBlockTableRecord _0023_003Dz8M4Ib4c_003D, _0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu, IList<Entity> _0023_003Dz29mwgg0FBLPP, bool _0023_003Dz8PMCTH_0024Bkfwq, IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D, ref bool _0023_003DzDKrJANc_003D)
	{
		_0023_003DzwzL57J6ueMIu._0023_003DzJsTeTeQ9VUeY(_0023_003Dz8M4Ib4c_003D);
		int count = _0023_003Dz29mwgg0FBLPP.Count;
		for (int i = 0; i < count; i++)
		{
			Entity entity = _0023_003Dz29mwgg0FBLPP[i];
			if (!_0023_003Dz8PMCTH_0024Bkfwq || entity.Selected)
			{
				MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
				try
				{
					_0023_003Dzzh5VcS4KZoiIBUTAU9kkMuKCym7v_cHtxoIgjHLVjw33._0023_003DzwlUm98KZEubL(entity, _0023_003DzwzL57J6ueMIu, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
				}
				catch (Exception ex)
				{
					log.AppendLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519983) + i + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519987) + entity.GetType()?.ToString() + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519938) + ex.Message);
				}
				finally
				{
					MemoryManager.GetMemoryManager().StopTransaction(value);
				}
			}
			if (!UpdateProgressAndCheckCancelled(i, count, base.ComposingEntitiesText, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D))
			{
				_0023_003DzDKrJANc_003D = false;
				break;
			}
		}
		UpdateProgressTo100(base.ComposingEntitiesText, _0023_003DzIzeJ4Qs_003D);
	}

	private void _0023_003DzFZhkSVA_003D(OdDbDatabase _0023_003DzR8GRspk_003D, _0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu, IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		SheetKeyedCollection sheetKeyedCollection = sheets;
		if (sheetKeyedCollection != null && sheetKeyedCollection.Count > 0)
		{
			if (!_0023_003DzwzL57J6ueMIu._0023_003DzHGfwTrs_003D)
			{
				_0023_003DzR8GRspk_003D.deleteLayout(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519529));
			}
			bool flag = true;
			foreach (Sheet sheet in sheets)
			{
				bool flag2 = true;
				OdDbObjectId odDbObjectId = _0023_003DzR8GRspk_003D.findLayoutNamed(sheet.Name);
				if (odDbObjectId.isNull())
				{
					odDbObjectId = _0023_003DzR8GRspk_003D.createLayout(sheet.Name);
				}
				else if (_0023_003DzwzL57J6ueMIu._0023_003DzHGfwTrs_003D)
				{
					flag2 = false;
				}
				else
				{
					flag = false;
				}
				OdDbLayout odDbLayout = (OdDbLayout)odDbObjectId.safeOpenObject();
				if (flag2)
				{
					_0023_003DzGG4QQxQloen_(_0023_003DzR8GRspk_003D, odDbObjectId, sheet, odDbLayout);
				}
				OdDbBlockTableRecord _0023_003Dzdc1k2Kc_003D = (OdDbBlockTableRecord)odDbLayout.getBlockTableRecordId().safeOpenObject(OdDb_OpenMode.kForWrite);
				_0023_003DzwzL57J6ueMIu._0023_003DzJsTeTeQ9VUeY(_0023_003Dzdc1k2Kc_003D);
				_0023_003DzwzL57J6ueMIu._0023_003Dzz3btBKF70SPz(sheet);
				_0023_003DzJogklzwufdntD_72_t0Wspc_003D(_0023_003DzwzL57J6ueMIu, sheet.Entities, base.ComposingBlocksText, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
				if (!_0023_003DzwzL57J6ueMIu._0023_003Dz4MwBDBTtsrsJj4VGiw_003D_003D)
				{
					_0023_003DzJogklzwufdntD_72_t0Wspc_003D(_0023_003DzwzL57J6ueMIu, sheetsExtraEntities[sheet.Name], base.ComposingBlocksText, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
				}
				((OdDbViewport)odDbLayout.activeViewportId().openObject(OdDb_OpenMode.kForWrite, openErasedOne: false)).zoomExtents();
			}
			if (flag && !_0023_003DzwzL57J6ueMIu._0023_003DzHGfwTrs_003D)
			{
				_0023_003DzR8GRspk_003D.deleteLayout(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519547));
			}
		}
		_0023_003DzR8GRspk_003D.setTILEMODE(val: true);
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}

	private static void _0023_003DzGG4QQxQloen_(OdDbDatabase _0023_003DzR8GRspk_003D, OdDbObjectId _0023_003DzevtwqGI_003D, Sheet _0023_003DzIMsyjzKWHHDa, OdDbLayout _0023_003Dz6j6Jgtc_003D)
	{
		OdRxModule odRxModule = TD_RootIntegrated_Globals.odrxDynamicLinker().loadModule(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519501));
		_0023_003DzR8GRspk_003D.setCurrentLayout(_0023_003DzevtwqGI_003D);
		OdDbPlotSettingsValidator odDbPlotSettingsValidator = _0023_003DzR8GRspk_003D.appServices().plotSettingsValidator();
		OdDbPlotSettings_PlotPaperUnits plotPaperUnits = ((_0023_003DzIMsyjzKWHHDa.Units == linearUnitsType.Millimeters) ? OdDbPlotSettings_PlotPaperUnits.kMillimeters : OdDbPlotSettings_PlotPaperUnits.kInches);
		odDbPlotSettingsValidator.setPlotPaperUnits(_0023_003Dz6j6Jgtc_003D, plotPaperUnits);
		odDbPlotSettingsValidator.setPlotRotation(_0023_003Dz6j6Jgtc_003D, OdDbPlotSettings_PlotRotation.k0degrees);
		odDbPlotSettingsValidator.refreshLists(_0023_003Dz6j6Jgtc_003D);
		string text = _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519505);
		OdDbPlotSettingsValidatorPE.psvPaperInfo psvPaperInfo = new OdDbPlotSettingsValidatorPE.psvPaperInfo
		{
			canonicalName = text,
			localeName = text,
			w = _0023_003DzIMsyjzKWHHDa.Width,
			h = _0023_003DzIMsyjzKWHHDa.Height
		};
		double num = (psvPaperInfo.top = 0.0);
		double num3 = (psvPaperInfo.bottom = num);
		double left = (psvPaperInfo.right = num3);
		psvPaperInfo.left = left;
		psvPaperInfo.units = plotPaperUnits;
		if (OdDbPlotSettingsValidatorPE.desc().getX(OdDbPlotSettingsValidatorCustomMediaPE.desc()) is OdDbPlotSettingsValidatorCustomMediaPE odDbPlotSettingsValidatorCustomMediaPE)
		{
			odDbPlotSettingsValidatorCustomMediaPE.addMedia(psvPaperInfo);
			odDbPlotSettingsValidator.setPlotCfgName(_0023_003Dz6j6Jgtc_003D, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519612));
			odDbPlotSettingsValidator.setCanonicalMediaName(_0023_003Dz6j6Jgtc_003D, text);
		}
		odRxModule.Dispose();
	}

	private void _0023_003DzH_0024g5Bwc_003D(OdDbDatabase _0023_003DzR8GRspk_003D, _0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu, BlockKeyedCollection _0023_003DzFyBLmv3KS6Nt, IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D, ref bool _0023_003DzDKrJANc_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		OdDbBlockTable odDbBlockTable = (OdDbBlockTable)_0023_003DzR8GRspk_003D.getBlockTableId().openObject(OdDb_OpenMode.kForWrite);
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
		if (_0023_003DzwzL57J6ueMIu._0023_003DzHGfwTrs_003D)
		{
			OdDbSymbolTableIterator odDbSymbolTableIterator = odDbBlockTable.newIterator();
			odDbSymbolTableIterator.start();
			while (!odDbSymbolTableIterator.done())
			{
				OdDbBlockTableRecord odDbBlockTableRecord = (OdDbBlockTableRecord)odDbSymbolTableIterator.getRecord(OdDb_OpenMode.kForRead, openErasedRecord: false);
				dictionary2.Add(odDbBlockTableRecord.getName(), 0);
				odDbSymbolTableIterator.step();
			}
		}
		foreach (Block item in _0023_003DzFyBLmv3KS6Nt)
		{
			if (_0023_003DzwzL57J6ueMIu._0023_003DzHGfwTrs_003D && dictionary2.ContainsKey(item.Name))
			{
				continue;
			}
			string name = item.Name;
			if (item.ExportMode == autodeskExportType.Embedded && !name.ToUpper().StartsWith(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528982)))
			{
				string text = name.TrimStart('*');
				text = WriteFileAsync.RemoveInvalidChars(text.Trim());
				if (odDbBlockTable.has(text))
				{
					throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519560) + item.Name);
				}
				dictionary.Add(text, item.Name);
				OdDbBlockTableRecord odDbBlockTableRecord2 = OdDbBlockTableRecord.createObject();
				odDbBlockTableRecord2.setName(text);
				odDbBlockTableRecord2.setComments(item.Description);
				if (!text.ToUpper().StartsWith(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528982)))
				{
					odDbBlockTableRecord2.setBlockInsertUnits(_0023_003DzC_A_00240jSUbYHi0SaUjw_003D_003D(item.Units));
				}
				odDbBlockTableRecord2.setOrigin(new OdGePoint3d(item.BasePoint.X, item.BasePoint.Y, item.BasePoint.Z));
				odDbBlockTable.add(odDbBlockTableRecord2);
			}
		}
		int num = 0;
		OdDbSymbolTableIterator odDbSymbolTableIterator2 = odDbBlockTable.newIterator();
		odDbSymbolTableIterator2.start();
		while (!odDbSymbolTableIterator2.done())
		{
			num++;
			odDbSymbolTableIterator2.step();
		}
		int num2 = 0;
		odDbSymbolTableIterator2.start(atBeginning: true);
		while (!odDbSymbolTableIterator2.done())
		{
			OdDbBlockTableRecord odDbBlockTableRecord3 = (OdDbBlockTableRecord)odDbSymbolTableIterator2.getRecord(OdDb_OpenMode.kForWrite);
			if (dictionary.ContainsKey(odDbBlockTableRecord3.getName()))
			{
				_0023_003DzwzL57J6ueMIu._0023_003DzJsTeTeQ9VUeY(odDbBlockTableRecord3);
				_0023_003DzJogklzwufdntD_72_t0Wspc_003D(_0023_003DzwzL57J6ueMIu, _0023_003DzFyBLmv3KS6Nt[dictionary[odDbBlockTableRecord3.getName()]].Entities, base.ComposingBlocksText, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
			}
			if (!UpdateProgressAndCheckCancelled(num2, num, base.ComposingBlocksText, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D))
			{
				_0023_003DzDKrJANc_003D = false;
			}
			num2++;
			odDbSymbolTableIterator2.step();
		}
		UpdateProgressTo100(base.ComposingBlocksText, _0023_003DzIzeJ4Qs_003D);
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}

	private void _0023_003DzL_ht5hWbVwnu(OdDbDatabase _0023_003DzR8GRspk_003D, _0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu, string _0023_003Dz0EA0NeSD2dKB, LineTypeKeyedCollection _0023_003Dz81YVQnrKmt6N)
	{
		OdDbLinetypeTable odDbLinetypeTable = (OdDbLinetypeTable)_0023_003DzR8GRspk_003D.getLinetypeTableId().openObject(OdDb_OpenMode.kForWrite);
		if (_0023_003DzwzL57J6ueMIu._0023_003DzHGfwTrs_003D)
		{
			OdDbSymbolTableIterator odDbSymbolTableIterator = odDbLinetypeTable.newIterator();
			odDbSymbolTableIterator.start();
			while (!odDbSymbolTableIterator.done())
			{
				OdDbLinetypeTableRecord odDbLinetypeTableRecord = (OdDbLinetypeTableRecord)odDbSymbolTableIterator.getRecord(OdDb_OpenMode.kForRead, openErasedRecord: false);
				_0023_003DzwzL57J6ueMIu._0023_003DzMD3OMd7A7ssm.Add(odDbLinetypeTableRecord.getName(), odDbSymbolTableIterator.getRecordId());
				odDbSymbolTableIterator.step();
			}
		}
		foreach (LineType item in _0023_003Dz81YVQnrKmt6N)
		{
			if (!_0023_003Dz6j9PKd6iStK4(_0023_003Dz0EA0NeSD2dKB, _0023_003Dzmniq5JprCDdq(item)) && (!_0023_003DzwzL57J6ueMIu._0023_003DzHGfwTrs_003D || !_0023_003DzwzL57J6ueMIu._0023_003DzMD3OMd7A7ssm.ContainsKey(item.Name)))
			{
				OdDbObjectId value = _0023_003DzIyc16os_003D(item.Name, item.Pattern, item.Description, odDbLinetypeTable);
				_0023_003DzwzL57J6ueMIu._0023_003DzMD3OMd7A7ssm.Add(item.Name, value);
			}
		}
	}

	private void _0023_003DznoCAfPY1JuUn(OdDbDatabase _0023_003DzR8GRspk_003D)
	{
		if (hatchPatterns == null)
		{
			return;
		}
		foreach (HatchPattern hatchPattern in hatchPatterns)
		{
			if (_0023_003Dz6qjGZbgwhBed.Contains(hatchPattern.Name))
			{
				continue;
			}
			OdHatchPattern odHatchPattern = new OdHatchPattern();
			HatchPatternLine[] lines = hatchPattern.Lines;
			foreach (HatchPatternLine hatchPatternLine in lines)
			{
				OdHatchPatternLine odHatchPatternLine = new OdHatchPatternLine();
				odHatchPatternLine.m_dLineAngle = hatchPatternLine.Angle;
				odHatchPatternLine.m_patternOffset = new OdGeVector2d(hatchPatternLine.DeltaX, hatchPatternLine.DeltaY);
				odHatchPatternLine.m_basePoint = new OdGePoint2d(hatchPatternLine.Origin.X, hatchPatternLine.Origin.Y);
				if (hatchPatternLine.Pattern != null)
				{
					float[] pattern = hatchPatternLine.Pattern;
					foreach (float num in pattern)
					{
						odHatchPatternLine.m_dashes.Add(num);
					}
				}
				odHatchPattern.Add(odHatchPatternLine);
			}
			_0023_003DzR8GRspk_003D.appServices().patternManager().appendPattern(OdDbHatch_HatchPatternType.kCustomDefined, hatchPattern.Name, odHatchPattern);
		}
	}

	private void _0023_003DzPArH_0024bNSkn7_0024(OdDbDatabase _0023_003DzR8GRspk_003D, _0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu, string _0023_003Dz0EA0NeSD2dKB, TextStyleKeyedCollection _0023_003Dzc3aLSLYhP84G)
	{
		OdDbTextStyleTable odDbTextStyleTable = (OdDbTextStyleTable)_0023_003DzR8GRspk_003D.getTextStyleTableId().openObject(OdDb_OpenMode.kForWrite);
		if (_0023_003DzwzL57J6ueMIu._0023_003DzHGfwTrs_003D)
		{
			OdDbSymbolTableIterator odDbSymbolTableIterator = odDbTextStyleTable.newIterator();
			odDbSymbolTableIterator.start();
			while (!odDbSymbolTableIterator.done())
			{
				string name = ((OdDbTextStyleTableRecord)odDbSymbolTableIterator.getRecord(OdDb_OpenMode.kForRead, openErasedRecord: false)).getName();
				if (!string.IsNullOrEmpty(name) && !_0023_003DzwzL57J6ueMIu._0023_003Dz4c0qJg8waJ38.ContainsKey(name))
				{
					_0023_003DzwzL57J6ueMIu._0023_003Dz4c0qJg8waJ38.Add(name, odDbSymbolTableIterator.getRecordId());
				}
				odDbSymbolTableIterator.step();
			}
		}
		foreach (TextStyle item in _0023_003Dzc3aLSLYhP84G)
		{
			if (_0023_003Dz6j9PKd6iStK4(_0023_003Dz0EA0NeSD2dKB, _0023_003Dzmniq5JprCDdq(item)))
			{
				continue;
			}
			_0023_003DzKyfEzVn70e7f._0023_003DzUKqqj5jVq6VSnKlzpPedCok_003D((FontStyle)item.Style, out var _0023_003Dz5q0miVg_003D, out var _0023_003Dz_0024CjJ2p4_003D);
			if (string.Compare(item.Name, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531415), StringComparison.OrdinalIgnoreCase) == 0)
			{
				OdDbSymbolTableIterator odDbSymbolTableIterator2 = odDbTextStyleTable.newIterator();
				odDbSymbolTableIterator2.start();
				while (!odDbSymbolTableIterator2.done())
				{
					OdDbTextStyleTableRecord odDbTextStyleTableRecord = (OdDbTextStyleTableRecord)odDbSymbolTableIterator2.getRecord(OdDb_OpenMode.kForWrite, openErasedRecord: false);
					if (string.Compare(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531415), odDbTextStyleTableRecord.getName(), StringComparison.OrdinalIgnoreCase) == 0)
					{
						odDbTextStyleTableRecord.setFileName(item.FileName);
						if (!string.IsNullOrEmpty(item.FontFamilyName))
						{
							odDbTextStyleTableRecord.setFont(item.FontFamilyName, _0023_003Dz5q0miVg_003D, _0023_003Dz_0024CjJ2p4_003D, 0, 0);
						}
						odDbTextStyleTableRecord.setXScale(item.WidthFactor);
						if (!_0023_003DzwzL57J6ueMIu._0023_003DzHGfwTrs_003D || !_0023_003DzwzL57J6ueMIu._0023_003Dz4c0qJg8waJ38.ContainsKey(item.Name))
						{
							_0023_003DzwzL57J6ueMIu._0023_003Dz4c0qJg8waJ38.Add(item.Name, odDbSymbolTableIterator2.getRecordId());
						}
						break;
					}
					odDbSymbolTableIterator2.step();
				}
			}
			else if (!_0023_003DzwzL57J6ueMIu._0023_003DzHGfwTrs_003D || !_0023_003DzwzL57J6ueMIu._0023_003Dz4c0qJg8waJ38.ContainsKey(item.Name))
			{
				try
				{
					OdDbTextStyleTableRecord _0023_003Dz0XEZEQY_003D = OdDbTextStyleTableRecord.createObject();
					OdDbObjectId value = _0023_003DzKyfEzVn70e7f._0023_003DzER_0024be_edpFIg(odDbTextStyleTable, _0023_003Dz0XEZEQY_003D, item.Name, string.IsNullOrEmpty(item.FileName) ? item.FontFamilyName : string.Empty, item.FileName, _0023_003Dz5q0miVg_003D, _0023_003Dz_0024CjJ2p4_003D, item.WidthFactor);
					_0023_003DzwzL57J6ueMIu._0023_003Dz4c0qJg8waJ38.Add(item.Name, value);
				}
				catch (Exception)
				{
					throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519620) + item.Name + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519717));
				}
			}
		}
	}

	private void _0023_003DzPQxPw7A_003D(OdDbDatabase _0023_003DzR8GRspk_003D, _0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu, string _0023_003Dz0EA0NeSD2dKB, LayerKeyedCollection _0023_003Dz68IvW_AooqDP)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
		if (_0023_003DzwzL57J6ueMIu._0023_003DzHGfwTrs_003D)
		{
			OdDbSymbolTableIterator odDbSymbolTableIterator = ((OdDbLayerTable)_0023_003DzR8GRspk_003D.getLayerTableId().openObject(OdDb_OpenMode.kForRead)).newIterator();
			odDbSymbolTableIterator.start();
			while (!odDbSymbolTableIterator.done())
			{
				OdDbLayerTableRecord odDbLayerTableRecord = (OdDbLayerTableRecord)odDbSymbolTableIterator.getRecord(OdDb_OpenMode.kForRead, openErasedRecord: false);
				dictionary.Add(odDbLayerTableRecord.getName(), 0);
				odDbSymbolTableIterator.step();
			}
		}
		foreach (Layer item in _0023_003Dz68IvW_AooqDP)
		{
			if (_0023_003Dz6j9PKd6iStK4(_0023_003Dz0EA0NeSD2dKB, _0023_003Dzmniq5JprCDdq(item)) || (_0023_003DzwzL57J6ueMIu._0023_003DzHGfwTrs_003D && dictionary.ContainsKey(item.Name)))
			{
				continue;
			}
			object obj;
			if (item != null)
			{
				Layer layer = item;
				obj = layer.XData;
			}
			else
			{
				obj = null;
			}
			List<KeyValuePair<short, object>> _0023_003Dzgh2w2yI_003D = (List<KeyValuePair<short, object>>)obj;
			if (item.Name != _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525371))
			{
				_0023_003DzoErE2eM_003D(_0023_003DzR8GRspk_003D, item.Name, item.Color, item.Visible, item.LineTypeName, item.LineWeight, _0023_003DzwzL57J6ueMIu._0023_003DzujvIJ3_tyt6U(), _0023_003DzwzL57J6ueMIu._0023_003DzFVrp9CCbpZz_0024(), lineWeightUnits, _0023_003DzwzL57J6ueMIu._0023_003Dzlgdo2AJKqMVX(item.MaterialName), log, item.Locked, _0023_003Dzgh2w2yI_003D);
				continue;
			}
			OdDbSymbolTableIterator odDbSymbolTableIterator2 = ((OdDbLayerTable)_0023_003DzR8GRspk_003D.getLayerTableId().openObject(OdDb_OpenMode.kForRead, openErasedOne: false)).newIterator();
			odDbSymbolTableIterator2.start();
			while (!odDbSymbolTableIterator2.done())
			{
				OdDbLayerTableRecord odDbLayerTableRecord2 = (OdDbLayerTableRecord)odDbSymbolTableIterator2.getRecord(OdDb_OpenMode.kForWrite, openErasedRecord: false);
				if (odDbLayerTableRecord2.getName() == _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525371))
				{
					_0023_003DzfLKrLxgRz4K63hFCTrDKvR80s7Gb(_0023_003DzR8GRspk_003D, odDbLayerTableRecord2, item.Name, item.Color, item.Visible, item.LineTypeName, item.LineWeight, _0023_003DzwzL57J6ueMIu._0023_003DzujvIJ3_tyt6U(), _0023_003DzwzL57J6ueMIu._0023_003DzFVrp9CCbpZz_0024(), _0023_003DzwzL57J6ueMIu._0023_003Dz_GNl1_0024oPxrrc(), _0023_003DzwzL57J6ueMIu._0023_003Dzlgdo2AJKqMVX(item.MaterialName), log, item.Locked, _0023_003Dzgh2w2yI_003D, null);
					break;
				}
				odDbSymbolTableIterator2.step();
			}
		}
	}

	private void _0023_003Dzdi43iqw_003D(OdDbDatabase _0023_003Dzd2hFvl0_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		if (_0023_003Dzd2hFvl0_003D.getTILEMODE())
		{
			OdDbViewportTableRecord odDbViewportTableRecord = (OdDbViewportTableRecord)((OdDbViewportTable)_0023_003Dzd2hFvl0_003D.getViewportTableId().safeOpenObject()).getActiveViewportId().openObject(OdDb_OpenMode.kForWrite, openErasedOne: false);
			if (viewport != null)
			{
				OdDbDictionary _0023_003DzlJd_0024w_llT80Y = (OdDbDictionary)_0023_003Dzd2hFvl0_003D.getVisualStyleDictionaryId().openObject();
				odDbViewportTableRecord.setVisualStyle(_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzQnE4k6_0024RHM2tjCasTiJl7R8_003D(viewport.DisplayMode, _0023_003DzlJd_0024w_llT80Y));
				Camera camera = viewport.Camera;
				camera.GetFrame(out var _, out var _, out var camY, out var camZ);
				camZ *= camera.Distance;
				odDbViewportTableRecord.setViewDirection(new OdGeVector3d(camZ.X, camZ.Y, camZ.Z));
				odDbViewportTableRecord.setLensLength(camera.FocalLength);
				odDbViewportTableRecord.setTarget(_0023_003Dzzh5VcS4KZoiIBUTAU9kkMuKCym7v_cHtxoIgjHLVjw33._0023_003DzbhysZL9VFmRcYmsohA_003D_003D(camera.Target));
				Transformation.AutocadOCS(camZ, out var _, out var yAxis);
				double num = Utility.VectorsAngle(yAxis, camY, camZ);
				if (num < 0.0)
				{
					num += 360.0;
				}
				odDbViewportTableRecord.setViewTwist(Utility.DegToRad(num));
				odDbViewportTableRecord.setPerspectiveEnabled(camera.ProjectionMode == projectionType.Perspective);
				odDbViewportTableRecord.setWidth((double)viewport.Size.Width / camera.ZoomFactor);
				odDbViewportTableRecord.setHeight((double)viewport.Size.Height / camera.ZoomFactor);
				odDbViewportTableRecord.setCenterPoint(new OdGePoint2d(0.0, 0.0));
			}
			else
			{
				odDbViewportTableRecord.zoomExtents();
			}
		}
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}

	private bool _0023_003Dz6j9PKd6iStK4(string _0023_003DzBqStsTeTm8OQ, string _0023_003Dzd_0024bKsZSsLyQp)
	{
		if (!string.IsNullOrEmpty(_0023_003Dzd_0024bKsZSsLyQp))
		{
			if (!blocks.TryGetValue(_0023_003Dzd_0024bKsZSsLyQp, out var value))
			{
				return true;
			}
			if (value.ExportMode != autodeskExportType.Embedded && _0023_003Dzd_0024bKsZSsLyQp != _0023_003DzBqStsTeTm8OQ)
			{
				return true;
			}
		}
		return false;
	}

	private void _0023_003DzJogklzwufdntD_72_t0Wspc_003D(_0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu, IList<Entity> _0023_003Dza7_00240bKo3NuxL, string _0023_003DzCJMUC7wYxalQ, IProgress<ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		int count = _0023_003Dza7_00240bKo3NuxL.Count;
		for (int i = 0; i < count; i++)
		{
			Entity entity = _0023_003Dza7_00240bKo3NuxL[i];
			MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
			try
			{
				_0023_003Dzzh5VcS4KZoiIBUTAU9kkMuKCym7v_cHtxoIgjHLVjw33._0023_003DzwlUm98KZEubL(entity, _0023_003DzwzL57J6ueMIu, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
			}
			catch (Exception ex)
			{
				log.AppendLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519983) + i + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519738) + _0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().getName() + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519987) + entity.GetType()?.ToString() + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519938) + ex.Message);
			}
			finally
			{
				MemoryManager.GetMemoryManager().StopTransaction(value);
			}
		}
	}

	protected override void InitLayers(LayerKeyedCollection layerCollection)
	{
		layers = new LayerKeyedCollection(layerCollection);
	}

	internal static OdDbObjectId _0023_003DzoErE2eM_003D(OdDbDatabase _0023_003Dzd2hFvl0_003D, string _0023_003DzFVJAp_Y_003D, Color _0023_003DzJBUBFWA_003D, bool _0023_003Dz6Y4jgDI_003D, string _0023_003DzdGTZ_0024_ca3DDq, float _0023_003Dzq_ABCx2CTIN8, bool _0023_003Dz_sf9dBZZ1poK, Color _0023_003DzYh4eDvc_003D, lineWeightUnitsType _0023_003DztO5OPB0oehHq, OdDbObjectId _0023_003DzGoOdnTqGVAqBgFWOTQ_003D_003D, StringBuilder _0023_003DzWfEJJHg_003D, bool _0023_003DzCzVVavI_003D, List<KeyValuePair<short, object>> _0023_003Dzgh2w2yI_003D)
	{
		OdDbLayerTable _0023_003DzHXBTdKw_003D = (OdDbLayerTable)_0023_003Dzd2hFvl0_003D.getLayerTableId().openObject(OdDb_OpenMode.kForWrite);
		OdDbLayerTableRecord _0023_003DzRZQe7ec_003D = OdDbLayerTableRecord.createObject();
		return _0023_003DzfLKrLxgRz4K63hFCTrDKvR80s7Gb(_0023_003Dzd2hFvl0_003D, _0023_003DzRZQe7ec_003D, _0023_003DzFVJAp_Y_003D, _0023_003DzJBUBFWA_003D, _0023_003Dz6Y4jgDI_003D, _0023_003DzdGTZ_0024_ca3DDq, _0023_003Dzq_ABCx2CTIN8, _0023_003Dz_sf9dBZZ1poK, _0023_003DzYh4eDvc_003D, _0023_003DztO5OPB0oehHq, _0023_003DzGoOdnTqGVAqBgFWOTQ_003D_003D, _0023_003DzWfEJJHg_003D, _0023_003DzCzVVavI_003D, _0023_003Dzgh2w2yI_003D, _0023_003DzHXBTdKw_003D);
	}

	private static OdDbObjectId _0023_003DzfLKrLxgRz4K63hFCTrDKvR80s7Gb(OdDbDatabase _0023_003Dzd2hFvl0_003D, OdDbLayerTableRecord _0023_003DzRZQe7ec_003D, string _0023_003DzFVJAp_Y_003D, Color _0023_003DzJBUBFWA_003D, bool _0023_003Dz6Y4jgDI_003D, string _0023_003DzdGTZ_0024_ca3DDq, float _0023_003Dzq_ABCx2CTIN8, bool _0023_003Dz_sf9dBZZ1poK, Color _0023_003DzYh4eDvc_003D, lineWeightUnitsType _0023_003DztO5OPB0oehHq, OdDbObjectId _0023_003DzGoOdnTqGVAqBgFWOTQ_003D_003D, StringBuilder _0023_003DzWfEJJHg_003D, bool _0023_003DzCzVVavI_003D, List<KeyValuePair<short, object>> _0023_003Dzgh2w2yI_003D, OdDbLayerTable _0023_003DzHXBTdKw_003D)
	{
		try
		{
			_0023_003DzRZQe7ec_003D.setName(_0023_003DzFVJAp_Y_003D);
		}
		catch (Exception)
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519688) + _0023_003DzFVJAp_Y_003D + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355519717));
		}
		OdDbObjectId result = _0023_003DzHXBTdKw_003D?.add(_0023_003DzRZQe7ec_003D);
		_0023_003DzRZQe7ec_003D.setColor(_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DztRLzArIqOrBK0lmTPw_003D_003D(_0023_003DzJBUBFWA_003D, _0023_003Dz_sf9dBZZ1poK, _0023_003DzYh4eDvc_003D));
		OdCmTransparency transparency = new OdCmTransparency(_0023_003DzJBUBFWA_003D.A);
		_0023_003DzRZQe7ec_003D.setTransparency(transparency);
		_0023_003DzRZQe7ec_003D.setIsOff(!_0023_003Dz6Y4jgDI_003D);
		_0023_003DzRZQe7ec_003D.setIsLocked(_0023_003DzCzVVavI_003D);
		if (!string.IsNullOrEmpty(_0023_003DzdGTZ_0024_ca3DDq))
		{
			OdDbLinetypeTable odDbLinetypeTable = (OdDbLinetypeTable)_0023_003Dzd2hFvl0_003D.getLinetypeTableId().openObject(OdDb_OpenMode.kForWrite);
			_0023_003DzRZQe7ec_003D.setLinetypeObjectId(odDbLinetypeTable.getAt(_0023_003DzdGTZ_0024_ca3DDq));
		}
		_0023_003DzRZQe7ec_003D.setLineWeight(_0023_003Dz6rzgaSHBY5QMk_0024oC226vguvdkkCP(_0023_003Dzq_ABCx2CTIN8, _0023_003DztO5OPB0oehHq));
		_0023_003DzRZQe7ec_003D.setMaterialId(_0023_003DzGoOdnTqGVAqBgFWOTQ_003D_003D);
		if (_0023_003Dzgh2w2yI_003D != null)
		{
			KeyValuePair<short, object>[] _0023_003DzU3o1kV6AvBoG = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzsU8xs6EN_FSS(_0023_003Dzgh2w2yI_003D, _0023_003Dzd2hFvl0_003D);
			try
			{
				OdResBuf xData = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzFAdNEnYlqrJZ(_0023_003DzU3o1kV6AvBoG);
				_0023_003DzRZQe7ec_003D.setXData(xData);
			}
			catch (OdError odError)
			{
				_0023_003DzWfEJJHg_003D.AppendLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355520300) + _0023_003DzFVJAp_Y_003D + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355520265) + odError.description());
			}
		}
		return result;
	}

	internal static void _0023_003DzIyc16os_003D(OdDbDatabase _0023_003DzR8GRspk_003D, string _0023_003DzdGTZ_0024_ca3DDq, string _0023_003DzGohF3uM_003D, float[] _0023_003Dz21gnOMY_003D)
	{
		OdDbLinetypeTable _0023_003DzJC_0024FzBae1MZTGOYDpg_003D_003D = (OdDbLinetypeTable)_0023_003DzR8GRspk_003D.getLinetypeTableId().openObject(OdDb_OpenMode.kForWrite);
		_0023_003DzIyc16os_003D(_0023_003DzdGTZ_0024_ca3DDq, _0023_003Dz21gnOMY_003D, _0023_003DzGohF3uM_003D, _0023_003DzJC_0024FzBae1MZTGOYDpg_003D_003D);
	}

	internal static OdDbObjectId _0023_003DzIyc16os_003D(string _0023_003DzFVJAp_Y_003D, float[] _0023_003Dz21gnOMY_003D, string _0023_003DzGohF3uM_003D, OdDbLinetypeTable _0023_003DzJC_0024FzBae1MZTGOYDpg_003D_003D)
	{
		OdDbObjectId odDbObjectId = _0023_003DziggCaN4Yoxvg(_0023_003DzJC_0024FzBae1MZTGOYDpg_003D_003D, _0023_003DzFVJAp_Y_003D, null);
		OdDbLinetypeTableRecord odDbLinetypeTableRecord = (OdDbLinetypeTableRecord)odDbObjectId.openObject(OdDb_OpenMode.kForWrite);
		if (_0023_003Dz21gnOMY_003D != null)
		{
			odDbLinetypeTableRecord.setNumDashes(_0023_003Dz21gnOMY_003D.Length);
			float num = 0f;
			for (int i = 0; i < odDbLinetypeTableRecord.numDashes(); i++)
			{
				odDbLinetypeTableRecord.setDashLengthAt(i, _0023_003Dz21gnOMY_003D[i]);
				num += Math.Abs(_0023_003Dz21gnOMY_003D[i]);
			}
			odDbLinetypeTableRecord.setPatternLength(num);
			odDbLinetypeTableRecord.setComments(_0023_003DzGohF3uM_003D);
		}
		return odDbObjectId;
	}

	private static OdDbObjectId _0023_003DziggCaN4Yoxvg(OdDbDatabase _0023_003DzR8GRspk_003D, string _0023_003DzFVJAp_Y_003D, string _0023_003DzCU5PkdQ_003D)
	{
		return _0023_003DziggCaN4Yoxvg((OdDbLinetypeTable)_0023_003DzR8GRspk_003D.getLinetypeTableId().openObject(OdDb_OpenMode.kForWrite), _0023_003DzFVJAp_Y_003D, _0023_003DzCU5PkdQ_003D);
	}

	private static OdDbObjectId _0023_003DziggCaN4Yoxvg(OdDbLinetypeTable _0023_003DzJC_0024FzBae1MZTGOYDpg_003D_003D, string _0023_003DzFVJAp_Y_003D, string _0023_003DzCU5PkdQ_003D)
	{
		OdDbLinetypeTableRecord odDbLinetypeTableRecord = OdDbLinetypeTableRecord.createObject();
		odDbLinetypeTableRecord.setName(_0023_003DzFVJAp_Y_003D);
		OdDbObjectId result = _0023_003DzJC_0024FzBae1MZTGOYDpg_003D_003D.add(odDbLinetypeTableRecord);
		odDbLinetypeTableRecord.setComments(_0023_003DzCU5PkdQ_003D);
		return result;
	}

	internal static string _0023_003DzTMPuHD43rj2n(float[] _0023_003Dz21gnOMY_003D, OdDbLinetypeTable _0023_003DzMrqqtoPGgHtO)
	{
		OdDbSymbolTableIterator odDbSymbolTableIterator = _0023_003DzMrqqtoPGgHtO.newIterator();
		odDbSymbolTableIterator.start();
		while (!odDbSymbolTableIterator.done())
		{
			OdDbLinetypeTableRecord odDbLinetypeTableRecord = (OdDbLinetypeTableRecord)odDbSymbolTableIterator.getRecord(OdDb_OpenMode.kForWrite);
			if (odDbLinetypeTableRecord.numDashes() == _0023_003Dz21gnOMY_003D.Length)
			{
				bool flag = true;
				for (int i = 0; i < odDbLinetypeTableRecord.numDashes(); i++)
				{
					if ((float)odDbLinetypeTableRecord.dashLengthAt(i) != _0023_003Dz21gnOMY_003D[i])
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return odDbLinetypeTableRecord.getName();
				}
			}
			odDbSymbolTableIterator.step();
		}
		return null;
	}

	internal static LineWeight _0023_003Dz6rzgaSHBY5QMk_0024oC226vguvdkkCP(float _0023_003Dzq_ABCx2CTIN8, lineWeightUnitsType _0023_003DztO5OPB0oehHq)
	{
		if (_0023_003DztO5OPB0oehHq == lineWeightUnitsType.Default)
		{
			return LineWeight.kLnWtByLwDefault;
		}
		float num = (float)((double)_0023_003Dzq_ABCx2CTIN8 * Utility.GetUnitsToMmFactor((_0023_003DztO5OPB0oehHq != lineWeightUnitsType.Millimeters) ? linearUnitsType.Inches : linearUnitsType.Millimeters));
		if (num <= 0.05f)
		{
			return LineWeight.kLnWt005;
		}
		if (num <= 0.09f)
		{
			return LineWeight.kLnWt009;
		}
		if (num <= 0.13f)
		{
			return LineWeight.kLnWt013;
		}
		if (num <= 0.15f)
		{
			return LineWeight.kLnWt015;
		}
		if (num <= 0.18f)
		{
			return LineWeight.kLnWt018;
		}
		if (num <= 0.2f)
		{
			return LineWeight.kLnWt020;
		}
		if (num <= 0.25f)
		{
			return LineWeight.kLnWt025;
		}
		if (num <= 0.3f)
		{
			return LineWeight.kLnWt030;
		}
		if (num <= 0.35f)
		{
			return LineWeight.kLnWt035;
		}
		if (num <= 0.4f)
		{
			return LineWeight.kLnWt040;
		}
		if (num <= 0.5f)
		{
			return LineWeight.kLnWt050;
		}
		if (num <= 0.53f)
		{
			return LineWeight.kLnWt053;
		}
		if (num <= 0.6f)
		{
			return LineWeight.kLnWt060;
		}
		if (num <= 0.7f)
		{
			return LineWeight.kLnWt070;
		}
		if (num <= 0.8f)
		{
			return LineWeight.kLnWt080;
		}
		if (num <= 1f)
		{
			return LineWeight.kLnWt100;
		}
		if (num <= 1.2f)
		{
			return LineWeight.kLnWt120;
		}
		if (num <= 1.4f)
		{
			return LineWeight.kLnWt140;
		}
		if (num <= 1.58f)
		{
			return LineWeight.kLnWt158;
		}
		if (num <= 2f)
		{
			return LineWeight.kLnWt200;
		}
		return LineWeight.kLnWt211;
	}

	internal static float _0023_003DzCO9z9YG_0024A6qTfyILw2qCj_0024c7cI9_0024(LineWeight _0023_003DzcONW7FA_003D)
	{
		float result = 0.5f;
		switch (_0023_003DzcONW7FA_003D)
		{
		case LineWeight.kLnWt000:
			result = 0.01f;
			break;
		case LineWeight.kLnWt005:
			result = 0.05f;
			break;
		case LineWeight.kLnWt009:
			result = 0.09f;
			break;
		case LineWeight.kLnWt013:
			result = 0.13f;
			break;
		case LineWeight.kLnWt015:
			result = 0.15f;
			break;
		case LineWeight.kLnWt018:
			result = 0.18f;
			break;
		case LineWeight.kLnWt020:
			result = 0.2f;
			break;
		case LineWeight.kLnWt025:
			result = 0.25f;
			break;
		case LineWeight.kLnWt030:
			result = 0.3f;
			break;
		case LineWeight.kLnWt035:
			result = 0.35f;
			break;
		case LineWeight.kLnWt040:
			result = 0.4f;
			break;
		case LineWeight.kLnWt050:
			result = 0.5f;
			break;
		case LineWeight.kLnWt053:
			result = 0.53f;
			break;
		case LineWeight.kLnWt060:
			result = 0.6f;
			break;
		case LineWeight.kLnWt070:
			result = 0.7f;
			break;
		case LineWeight.kLnWt080:
			result = 0.8f;
			break;
		case LineWeight.kLnWt100:
			result = 1f;
			break;
		case LineWeight.kLnWt106:
			result = 1.06f;
			break;
		case LineWeight.kLnWt120:
			result = 1.2f;
			break;
		case LineWeight.kLnWt140:
			result = 1.4f;
			break;
		case LineWeight.kLnWt158:
			result = 1.58f;
			break;
		case LineWeight.kLnWt200:
			result = 2f;
			break;
		case LineWeight.kLnWt211:
			result = 2.11f;
			break;
		case LineWeight.kLnWtByLwDefault:
			result = 0.25f;
			break;
		}
		return result;
	}

	internal static UnitsValue _0023_003DzC_A_00240jSUbYHi0SaUjw_003D_003D(linearUnitsType _0023_003DzarxsIPPJJ7HewnE21w_003D_003D)
	{
		return _0023_003DzarxsIPPJJ7HewnE21w_003D_003D switch
		{
			linearUnitsType.Inches => UnitsValue.kUnitsInches, 
			linearUnitsType.Feet => UnitsValue.kUnitsFeet, 
			linearUnitsType.Miles => UnitsValue.kUnitsMiles, 
			linearUnitsType.Millimeters => UnitsValue.kUnitsMillimeters, 
			linearUnitsType.Centimeters => UnitsValue.kUnitsCentimeters, 
			linearUnitsType.Meters => UnitsValue.kUnitsMeters, 
			linearUnitsType.Kilometers => UnitsValue.kUnitsKilometers, 
			linearUnitsType.Microinches => UnitsValue.kUnitsMicroinches, 
			linearUnitsType.Mils => UnitsValue.kUnitsMils, 
			linearUnitsType.Yards => UnitsValue.kUnitsYards, 
			linearUnitsType.Angstroms => UnitsValue.kUnitsAngstroms, 
			linearUnitsType.Nanometers => UnitsValue.kUnitsNanometers, 
			linearUnitsType.Microns => UnitsValue.kUnitsMicrons, 
			linearUnitsType.Decimeters => UnitsValue.kUnitsDecimeters, 
			linearUnitsType.Decameters => UnitsValue.kUnitsDekameters, 
			linearUnitsType.Hectometers => UnitsValue.kUnitsHectometers, 
			linearUnitsType.Gigameters => UnitsValue.kUnitsGigameters, 
			linearUnitsType.Astronomical => UnitsValue.kUnitsAstronomical, 
			linearUnitsType.LightYears => UnitsValue.kUnitsLightYears, 
			linearUnitsType.Parsecs => UnitsValue.kUnitsParsecs, 
			_ => UnitsValue.kUnitsUndefined, 
		};
	}

	internal static linearUnitsType _0023_003DzCpSZHkwMYNQHhZOwlA_003D_003D(UnitsValue _0023_003Dz78nzzMGxwmPE7bAICQ_003D_003D)
	{
		return _0023_003Dz78nzzMGxwmPE7bAICQ_003D_003D switch
		{
			UnitsValue.kUnitsInches => linearUnitsType.Inches, 
			UnitsValue.kUnitsFeet => linearUnitsType.Feet, 
			UnitsValue.kUnitsMiles => linearUnitsType.Miles, 
			UnitsValue.kUnitsMillimeters => linearUnitsType.Millimeters, 
			UnitsValue.kUnitsCentimeters => linearUnitsType.Centimeters, 
			UnitsValue.kUnitsMeters => linearUnitsType.Meters, 
			UnitsValue.kUnitsKilometers => linearUnitsType.Kilometers, 
			UnitsValue.kUnitsMicroinches => linearUnitsType.Microinches, 
			UnitsValue.kUnitsMils => linearUnitsType.Mils, 
			UnitsValue.kUnitsYards => linearUnitsType.Yards, 
			UnitsValue.kUnitsAngstroms => linearUnitsType.Angstroms, 
			UnitsValue.kUnitsNanometers => linearUnitsType.Nanometers, 
			UnitsValue.kUnitsMicrons => linearUnitsType.Microns, 
			UnitsValue.kUnitsDecimeters => linearUnitsType.Decimeters, 
			UnitsValue.kUnitsDekameters => linearUnitsType.Decameters, 
			UnitsValue.kUnitsHectometers => linearUnitsType.Hectometers, 
			UnitsValue.kUnitsGigameters => linearUnitsType.Gigameters, 
			UnitsValue.kUnitsAstronomical => linearUnitsType.Astronomical, 
			UnitsValue.kUnitsLightYears => linearUnitsType.LightYears, 
			UnitsValue.kUnitsParsecs => linearUnitsType.Parsecs, 
			UnitsValue.kUnitsUndefined => linearUnitsType.Unitless, 
			_ => linearUnitsType.NotSupported, 
		};
	}

	internal static OdDbMText_AttachmentPoint _0023_003DzGEpHBqC_0024YQsF4qanzQ_003D_003D(Text.alignmentType _0023_003Dz7_NmwEw_003D, out OdDb_TextHorzMode _0023_003Dzyzhw7idDjuhZ, out OdDb_TextVertMode _0023_003Dzi2NDvcXD_0024G65)
	{
		_0023_003Dzyzhw7idDjuhZ = OdDb_TextHorzMode.kTextAlign;
		_0023_003Dzi2NDvcXD_0024G65 = OdDb_TextVertMode.kTextBase;
		switch (_0023_003Dz7_NmwEw_003D)
		{
		case Text.alignmentType.BottomLeft:
			_0023_003Dzyzhw7idDjuhZ = OdDb_TextHorzMode.kTextLeft;
			_0023_003Dzi2NDvcXD_0024G65 = OdDb_TextVertMode.kTextBottom;
			return OdDbMText_AttachmentPoint.kBottomLeft;
		case Text.alignmentType.BottomCenter:
			_0023_003Dzyzhw7idDjuhZ = OdDb_TextHorzMode.kTextCenter;
			_0023_003Dzi2NDvcXD_0024G65 = OdDb_TextVertMode.kTextBottom;
			return OdDbMText_AttachmentPoint.kBottomCenter;
		case Text.alignmentType.BottomRight:
			_0023_003Dzyzhw7idDjuhZ = OdDb_TextHorzMode.kTextRight;
			_0023_003Dzi2NDvcXD_0024G65 = OdDb_TextVertMode.kTextBottom;
			return OdDbMText_AttachmentPoint.kBottomRight;
		case Text.alignmentType.BaselineLeft:
			_0023_003Dzyzhw7idDjuhZ = OdDb_TextHorzMode.kTextLeft;
			_0023_003Dzi2NDvcXD_0024G65 = OdDb_TextVertMode.kTextBase;
			return OdDbMText_AttachmentPoint.kBaseLeft;
		case Text.alignmentType.BaselineCenter:
			_0023_003Dzyzhw7idDjuhZ = OdDb_TextHorzMode.kTextCenter;
			_0023_003Dzi2NDvcXD_0024G65 = OdDb_TextVertMode.kTextBase;
			return OdDbMText_AttachmentPoint.kBaseCenter;
		case Text.alignmentType.BaselineRight:
			_0023_003Dzyzhw7idDjuhZ = OdDb_TextHorzMode.kTextRight;
			_0023_003Dzi2NDvcXD_0024G65 = OdDb_TextVertMode.kTextBase;
			return OdDbMText_AttachmentPoint.kBaseRight;
		case Text.alignmentType.MiddleLeft:
			_0023_003Dzyzhw7idDjuhZ = OdDb_TextHorzMode.kTextLeft;
			_0023_003Dzi2NDvcXD_0024G65 = OdDb_TextVertMode.kTextVertMid;
			return OdDbMText_AttachmentPoint.kMiddleLeft;
		case Text.alignmentType.MiddleCenter:
			_0023_003Dzyzhw7idDjuhZ = OdDb_TextHorzMode.kTextCenter;
			_0023_003Dzi2NDvcXD_0024G65 = OdDb_TextVertMode.kTextVertMid;
			return OdDbMText_AttachmentPoint.kMiddleCenter;
		case Text.alignmentType.MiddleRight:
			_0023_003Dzyzhw7idDjuhZ = OdDb_TextHorzMode.kTextRight;
			_0023_003Dzi2NDvcXD_0024G65 = OdDb_TextVertMode.kTextVertMid;
			return OdDbMText_AttachmentPoint.kMiddleRight;
		case Text.alignmentType.TopLeft:
			_0023_003Dzyzhw7idDjuhZ = OdDb_TextHorzMode.kTextLeft;
			_0023_003Dzi2NDvcXD_0024G65 = OdDb_TextVertMode.kTextTop;
			return OdDbMText_AttachmentPoint.kTopLeft;
		case Text.alignmentType.TopCenter:
			_0023_003Dzyzhw7idDjuhZ = OdDb_TextHorzMode.kTextCenter;
			_0023_003Dzi2NDvcXD_0024G65 = OdDb_TextVertMode.kTextTop;
			return OdDbMText_AttachmentPoint.kTopCenter;
		case Text.alignmentType.TopRight:
			_0023_003Dzyzhw7idDjuhZ = OdDb_TextHorzMode.kTextRight;
			_0023_003Dzi2NDvcXD_0024G65 = OdDb_TextVertMode.kTextTop;
			return OdDbMText_AttachmentPoint.kTopRight;
		default:
			return OdDbMText_AttachmentPoint.kBaseLeft;
		}
	}

	internal static Text.alignmentType _0023_003DzdLpU2S3dmXwJOMRc8w_003D_003D(OdDbMText_AttachmentPoint _0023_003Dz7_NmwEw_003D)
	{
		Text.alignmentType result = Text.alignmentType.BaselineLeft;
		switch (_0023_003Dz7_NmwEw_003D)
		{
		case OdDbMText_AttachmentPoint.kBottomLeft:
			result = Text.alignmentType.BottomLeft;
			break;
		case OdDbMText_AttachmentPoint.kBottomCenter:
			result = Text.alignmentType.BottomCenter;
			break;
		case OdDbMText_AttachmentPoint.kBottomRight:
			result = Text.alignmentType.BottomRight;
			break;
		case OdDbMText_AttachmentPoint.kBaseLeft:
		case OdDbMText_AttachmentPoint.kBaseAlign:
		case OdDbMText_AttachmentPoint.kBaseFit:
			result = Text.alignmentType.BaselineLeft;
			break;
		case OdDbMText_AttachmentPoint.kBaseCenter:
			result = Text.alignmentType.BaselineCenter;
			break;
		case OdDbMText_AttachmentPoint.kBaseRight:
			result = Text.alignmentType.BaselineRight;
			break;
		case OdDbMText_AttachmentPoint.kMiddleLeft:
			result = Text.alignmentType.MiddleLeft;
			break;
		case OdDbMText_AttachmentPoint.kMiddleCenter:
		case OdDbMText_AttachmentPoint.kBaseMid:
			result = Text.alignmentType.MiddleCenter;
			break;
		case OdDbMText_AttachmentPoint.kMiddleRight:
			result = Text.alignmentType.MiddleRight;
			break;
		case OdDbMText_AttachmentPoint.kTopLeft:
			result = Text.alignmentType.TopLeft;
			break;
		case OdDbMText_AttachmentPoint.kTopCenter:
			result = Text.alignmentType.TopCenter;
			break;
		case OdDbMText_AttachmentPoint.kTopRight:
			result = Text.alignmentType.TopRight;
			break;
		}
		return result;
	}

	internal static Text.alignmentType _0023_003DzdLpU2S3dmXwJOMRc8w_003D_003D(OdDb_CellAlignment _0023_003Dz7_NmwEw_003D)
	{
		return _0023_003Dz7_NmwEw_003D switch
		{
			OdDb_CellAlignment.kBottomLeft => Text.alignmentType.BottomLeft, 
			OdDb_CellAlignment.kBottomCenter => Text.alignmentType.BottomCenter, 
			OdDb_CellAlignment.kBottomRight => Text.alignmentType.BottomRight, 
			OdDb_CellAlignment.kMiddleLeft => Text.alignmentType.MiddleLeft, 
			OdDb_CellAlignment.kMiddleCenter => Text.alignmentType.MiddleCenter, 
			OdDb_CellAlignment.kMiddleRight => Text.alignmentType.MiddleRight, 
			OdDb_CellAlignment.kTopLeft => Text.alignmentType.TopLeft, 
			OdDb_CellAlignment.kTopCenter => Text.alignmentType.TopCenter, 
			OdDb_CellAlignment.kTopRight => Text.alignmentType.TopRight, 
			_ => Text.alignmentType.MiddleCenter, 
		};
	}

	internal static OdDb_CellAlignment _0023_003DzCZ9Tx9YR6Cws(Text.alignmentType _0023_003Dz7_NmwEw_003D)
	{
		return _0023_003Dz7_NmwEw_003D switch
		{
			Text.alignmentType.BottomLeft => OdDb_CellAlignment.kBottomLeft, 
			Text.alignmentType.BottomCenter => OdDb_CellAlignment.kBottomCenter, 
			Text.alignmentType.BottomRight => OdDb_CellAlignment.kBottomRight, 
			Text.alignmentType.MiddleLeft => OdDb_CellAlignment.kMiddleLeft, 
			Text.alignmentType.MiddleCenter => OdDb_CellAlignment.kMiddleCenter, 
			Text.alignmentType.MiddleRight => OdDb_CellAlignment.kMiddleRight, 
			Text.alignmentType.TopLeft => OdDb_CellAlignment.kTopLeft, 
			Text.alignmentType.TopCenter => OdDb_CellAlignment.kTopCenter, 
			Text.alignmentType.TopRight => OdDb_CellAlignment.kTopRight, 
			_ => OdDb_CellAlignment.kMiddleCenter, 
		};
	}

	internal static OdDbMText_AttachmentPoint _0023_003DzJnBzRfvPGuCd(OdDb_TextHorzMode _0023_003Dzyzhw7idDjuhZ, OdDb_TextVertMode _0023_003Dzi2NDvcXD_0024G65)
	{
		int num = (int)(Enum.IsDefined(typeof(OdDb_TextHorzMode), _0023_003Dzyzhw7idDjuhZ) ? _0023_003Dzyzhw7idDjuhZ : OdDb_TextHorzMode.kTextLeft);
		int num2 = (int)(Enum.IsDefined(typeof(OdDb_TextVertMode), _0023_003Dzi2NDvcXD_0024G65) ? _0023_003Dzi2NDvcXD_0024G65 : OdDb_TextVertMode.kTextBase);
		return _0023_003Dz_00242ondg2w093e[num2, num];
	}

	internal static OdDbObjectId _0023_003DzwVzVXv8_003D(OdDbDatabase _0023_003Dzd2hFvl0_003D, string _0023_003Dzxaw56Ac_003D)
	{
		return ((OdDbBlockTable)_0023_003Dzd2hFvl0_003D.getBlockTableId().openObject(OdDb_OpenMode.kForRead)).getAt(_0023_003Dzxaw56Ac_003D);
	}

	internal static void _0023_003DzEPkG1wlgZgNuz2UqZQ_003D_003D(OdDbPolyFaceMesh _0023_003DzU1gAWvc_003D, double _0023_003DzaG3DPu0_003D, double _0023_003DzROtQTt4_003D, double _0023_003DzoVpU9JU_003D)
	{
		OdDbPolyFaceMeshVertex odDbPolyFaceMeshVertex = OdDbPolyFaceMeshVertex.createObject();
		_0023_003DzU1gAWvc_003D.appendVertex(odDbPolyFaceMeshVertex);
		odDbPolyFaceMeshVertex.setPosition(new OdGePoint3d(_0023_003DzaG3DPu0_003D, _0023_003DzROtQTt4_003D, _0023_003DzoVpU9JU_003D));
	}

	internal static void _0023_003Dz_MjyAqUwv7sF(OdDbPolyFaceMesh _0023_003DzU1gAWvc_003D, short _0023_003Dz7R2VvKg_003D, short _0023_003DzZsO8xW8_003D, short _0023_003Dz7K6DZgk_003D)
	{
		OdDbFaceRecord odDbFaceRecord = OdDbFaceRecord.createObject();
		_0023_003DzU1gAWvc_003D.appendFaceRecord(odDbFaceRecord);
		odDbFaceRecord.setVertexAt(0, _0023_003Dz7R2VvKg_003D);
		odDbFaceRecord.setVertexAt(1, _0023_003DzZsO8xW8_003D);
		odDbFaceRecord.setVertexAt(2, _0023_003Dz7K6DZgk_003D);
	}

	internal static void _0023_003Dzp_0024lg_JOQ5rrz(Entity _0023_003Dzvyf_UNM_003D, IList<Point3D> _0023_003Dz4ykMYzdPSfyzSVFkKQ_003D_003D, IList<IndexTriangle> _0023_003DzVD9_0024zvn5OCy03qe7xQ_003D_003D, _0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		if (_0023_003Dz4ykMYzdPSfyzSVFkKQ_003D_003D == null || _0023_003DzVD9_0024zvn5OCy03qe7xQ_003D_003D == null)
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355520365));
		}
		if (_0023_003DzVD9_0024zvn5OCy03qe7xQ_003D_003D.Count <= 32767)
		{
			OdDbPolyFaceMesh odDbPolyFaceMesh = OdDbPolyFaceMesh.createObject();
			_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbPolyFaceMesh);
			for (int i = 0; i < _0023_003Dz4ykMYzdPSfyzSVFkKQ_003D_003D.Count; i++)
			{
				_0023_003DzEPkG1wlgZgNuz2UqZQ_003D_003D(odDbPolyFaceMesh, _0023_003Dz4ykMYzdPSfyzSVFkKQ_003D_003D[i].X, _0023_003Dz4ykMYzdPSfyzSVFkKQ_003D_003D[i].Y, _0023_003Dz4ykMYzdPSfyzSVFkKQ_003D_003D[i].Z);
			}
			for (int j = 0; j < _0023_003DzVD9_0024zvn5OCy03qe7xQ_003D_003D.Count; j++)
			{
				_0023_003Dz_MjyAqUwv7sF(odDbPolyFaceMesh, (short)(_0023_003DzVD9_0024zvn5OCy03qe7xQ_003D_003D[j].V1 + 1), (short)(_0023_003DzVD9_0024zvn5OCy03qe7xQ_003D_003D[j].V2 + 1), (short)(_0023_003DzVD9_0024zvn5OCy03qe7xQ_003D_003D[j].V3 + 1));
			}
			_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003Dzvyf_UNM_003D, odDbPolyFaceMesh, _0023_003DzwzL57J6ueMIu);
			_0023_003Dzl4Mp8rdL_0024AdqpoZ8MQ_003D_003D(_0023_003Dzvyf_UNM_003D, odDbPolyFaceMesh, _0023_003DzwzL57J6ueMIu);
			return;
		}
		int num = (int)Math.Ceiling((double)_0023_003DzVD9_0024zvn5OCy03qe7xQ_003D_003D.Count / 32767.0);
		List<IndexTriangle> list = new List<IndexTriangle>(32767);
		List<int> list2 = new List<int>(98301);
		int num2 = 0;
		int num3 = 0;
		while (num3 < num)
		{
			list.Clear();
			list2.Clear();
			int num4 = Math.Min(num2 + 32767, _0023_003DzVD9_0024zvn5OCy03qe7xQ_003D_003D.Count);
			for (int k = num2; k < num4; k++)
			{
				IndexTriangle indexTriangle = _0023_003DzVD9_0024zvn5OCy03qe7xQ_003D_003D[k];
				list.Add(new IndexTriangle(indexTriangle.V1, indexTriangle.V2, indexTriangle.V3));
				list2.Add(indexTriangle.V1);
				list2.Add(indexTriangle.V2);
				list2.Add(indexTriangle.V3);
			}
			list2.Sort();
			List<int> list3 = new List<int>(32767);
			int num5 = list2[0];
			list3.Add(num5);
			int num6 = 1;
			while (true)
			{
				if (num6 < list2.Count && list2[num6] == num5)
				{
					num6++;
					continue;
				}
				if (num6 == list2.Count)
				{
					break;
				}
				num5 = list2[num6];
				list3.Add(num5);
			}
			foreach (IndexTriangle item in list)
			{
				item.V1 = list3.BinarySearch(item.V1);
				item.V2 = list3.BinarySearch(item.V2);
				item.V3 = list3.BinarySearch(item.V3);
			}
			OdDbPolyFaceMesh odDbPolyFaceMesh2 = OdDbPolyFaceMesh.createObject();
			_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbPolyFaceMesh2);
			for (int l = 0; l < list3.Count; l++)
			{
				Point3D point3D = _0023_003Dz4ykMYzdPSfyzSVFkKQ_003D_003D[list3[l]];
				_0023_003DzEPkG1wlgZgNuz2UqZQ_003D_003D(odDbPolyFaceMesh2, point3D.X, point3D.Y, point3D.Z);
			}
			for (int m = 0; m < list.Count; m++)
			{
				_0023_003Dz_MjyAqUwv7sF(odDbPolyFaceMesh2, (short)(list[m].V1 + 1), (short)(list[m].V2 + 1), (short)(list[m].V3 + 1));
			}
			_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003Dzvyf_UNM_003D, odDbPolyFaceMesh2, _0023_003DzwzL57J6ueMIu);
			_0023_003Dzl4Mp8rdL_0024AdqpoZ8MQ_003D_003D(_0023_003Dzvyf_UNM_003D, odDbPolyFaceMesh2, _0023_003DzwzL57J6ueMIu);
			num3++;
			num2 += 32767;
		}
	}

	private static void _0023_003Dzl4Mp8rdL_0024AdqpoZ8MQ_003D_003D(Entity _0023_003Dzvyf_UNM_003D, OdDbPolyFaceMesh _0023_003DziasS_0024ijrMXxCk5wOjw_003D_003D, _0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		if (_0023_003Dzvyf_UNM_003D.ColorMethod == colorMethodType.byEntity && !_0023_003DzwzL57J6ueMIu._0023_003DzujvIJ3_tyt6U() && OdCmEntityColor.lookUpACI(_0023_003Dzvyf_UNM_003D.Color.R, _0023_003Dzvyf_UNM_003D.Color.G, _0023_003Dzvyf_UNM_003D.Color.B) == 7)
		{
			_0023_003DziasS_0024ijrMXxCk5wOjw_003D_003D.setColorIndex(255);
		}
	}
}
