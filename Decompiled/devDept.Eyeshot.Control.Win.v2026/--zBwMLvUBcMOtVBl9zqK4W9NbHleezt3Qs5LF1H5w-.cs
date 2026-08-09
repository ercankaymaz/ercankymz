using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;

internal sealed class _0023_003DzBwMLvUBcMOtVBl9zqK4W9NbHleezt3Qs5LF1H5w_003D
{
	private sealed class _0023_003DzO6A4KkYerAWOznpLXQ_003D_003D
	{
		public int _0023_003Dzr8DRS_imooUv;

		internal bool _0023_003DzbGzkdGbbPYw8Rtu2jCps2J9EoMjm(HiddenLinesView.HdlCurve _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D.Entity.PrintOrder == _0023_003Dzr8DRS_imooUv;
		}

		internal bool _0023_003DzVr_0024Md18KOs8UpJB8gRooAW6XaM9v(HiddenLinesView.HdlCurve _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D.Entity.PrintOrder == _0023_003Dzr8DRS_imooUv;
		}

		internal bool _0023_003Dzi8fzP8Ek_0024lWsdbOiRdCty_qfJcW6(HiddenLinesView.HdlCurve _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D.Entity.PrintOrder == _0023_003Dzr8DRS_imooUv;
		}

		internal bool _0023_003DzGl0FTif2GUF2Dd_1eEv648L5FqaU(HiddenLinesView.HdlCurve _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D.Entity.PrintOrder == _0023_003Dzr8DRS_imooUv;
		}

		internal bool _0023_003Dzmy3ZOzmmYHI5qozIiKQ_yNjYbyAG(HiddenLinesView.HdlCurve _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D.Entity.PrintOrder == _0023_003Dzr8DRS_imooUv;
		}

		internal bool _0023_003Dzmy3ZOzmmYHI5qozIiKQ_yLgFoT6B(HiddenLinesView.HdlCurve _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D.Entity.PrintOrder == _0023_003Dzr8DRS_imooUv;
		}

		internal bool _0023_003DzSTf8Y22rafQuiQdJpQ0pzwUIV_0024C7(HiddenLinesView.HdlText _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D.Entity.PrintOrder == _0023_003Dzr8DRS_imooUv;
		}

		internal bool _0023_003DzJUvpaLhXfxyy44b_00244Fl7NGFaipSn(HiddenLinesView.HdlPicture _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D.Entity.PrintOrder == _0023_003Dzr8DRS_imooUv;
		}

		internal bool _0023_003DzAg5BEzIkQVC7CXPt99iWXE0hYCD6(SilhoWireAndTriangleData _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D.Entity.PrintOrder == _0023_003Dzr8DRS_imooUv;
		}
	}

	internal static void _0023_003Dz40b83AC2XYDJKEY7aG3nP94_003D(HiddenLinesViewSettingsEx _0023_003Dz6eJ7SoKZDs_0024_0024, Graphics _0023_003DzrV6eaSI_003D, float _0023_003Dz5keHpXqrJjAd, HiddenLinesView.HdlCurve[] _0023_003DzrlP0XU9Qy7PRzHrblw_003D_003D, HiddenLinesView.HdlCurve[] _0023_003DzsenC4xd7ckFK, HiddenLinesView.HdlCurve[] _0023_003DzJ9AmQcDUVNAX1zyGzw_003D_003D, HiddenLinesView.HdlCurve[] _0023_003Dzp8pQEF1ZMleUthGj0g_003D_003D, HiddenLinesView.HdlCurve[] _0023_003DzLu_0024ZHet7Gt3U, HiddenLinesView.HdlCurve[] _0023_003DzwaFViKNhMbz0QltaMQ_003D_003D, HiddenLinesView.HdlText[] _0023_003DzNJ7gLTJ5RK7q, HiddenLinesView.HdlPicture[] _0023_003DzYeAApFP2R3BmtcrTaw_003D_003D, HashSet<int> _0023_003DzdOMcOkxixOx2, List<SilhoWireAndTriangleData> _0023_003DzeSHtmJ_y2RU3NjYS4lEW0eA_003D, HiddenLinesView.HdlSection[] _0023_003DzBLT6VCI_003D, double _0023_003Dz6VaqBeg2493U)
	{
		List<int> list = _0023_003DzdOMcOkxixOx2.ToList();
		list.Sort();
		using List<int>.Enumerator enumerator = list.GetEnumerator();
		while (enumerator.MoveNext())
		{
			_0023_003DzO6A4KkYerAWOznpLXQ_003D_003D CS_0024_003C_003E8__locals10 = new _0023_003DzO6A4KkYerAWOznpLXQ_003D_003D();
			CS_0024_003C_003E8__locals10._0023_003Dzr8DRS_imooUv = enumerator.Current;
			_0023_003DzRJTFvAna_0024_0024JsgC82zw_003D_003D(_0023_003Dz6eJ7SoKZDs_0024_0024, _0023_003DzrV6eaSI_003D, _0023_003Dz5keHpXqrJjAd, _0023_003DzrlP0XU9Qy7PRzHrblw_003D_003D.Where(CS_0024_003C_003E8__locals10._0023_003DzbGzkdGbbPYw8Rtu2jCps2J9EoMjm).ToArray(), _0023_003DzsenC4xd7ckFK.Where((HiddenLinesView.HdlCurve _0023_003Dz8GBMuoM_003D) => _0023_003Dz8GBMuoM_003D.Entity.PrintOrder == CS_0024_003C_003E8__locals10._0023_003Dzr8DRS_imooUv).ToArray(), _0023_003DzJ9AmQcDUVNAX1zyGzw_003D_003D.Where((HiddenLinesView.HdlCurve _0023_003Dz8GBMuoM_003D) => _0023_003Dz8GBMuoM_003D.Entity.PrintOrder == CS_0024_003C_003E8__locals10._0023_003Dzr8DRS_imooUv).ToArray(), _0023_003Dzp8pQEF1ZMleUthGj0g_003D_003D.Where(CS_0024_003C_003E8__locals10._0023_003DzGl0FTif2GUF2Dd_1eEv648L5FqaU).ToArray(), _0023_003DzLu_0024ZHet7Gt3U.Where(CS_0024_003C_003E8__locals10._0023_003Dzmy3ZOzmmYHI5qozIiKQ_yNjYbyAG).ToArray(), _0023_003DzwaFViKNhMbz0QltaMQ_003D_003D.Where(CS_0024_003C_003E8__locals10._0023_003Dzmy3ZOzmmYHI5qozIiKQ_yLgFoT6B).ToArray(), _0023_003DzNJ7gLTJ5RK7q.Where((HiddenLinesView.HdlText _0023_003Dz8GBMuoM_003D) => _0023_003Dz8GBMuoM_003D.Entity.PrintOrder == CS_0024_003C_003E8__locals10._0023_003Dzr8DRS_imooUv).ToArray(), _0023_003DzYeAApFP2R3BmtcrTaw_003D_003D.Where((HiddenLinesView.HdlPicture _0023_003Dz8GBMuoM_003D) => _0023_003Dz8GBMuoM_003D.Entity.PrintOrder == CS_0024_003C_003E8__locals10._0023_003Dzr8DRS_imooUv).ToArray(), _0023_003DzeSHtmJ_y2RU3NjYS4lEW0eA_003D.Where(CS_0024_003C_003E8__locals10._0023_003DzAg5BEzIkQVC7CXPt99iWXE0hYCD6).ToArray(), _0023_003DzBLT6VCI_003D, _0023_003Dz6VaqBeg2493U);
		}
	}

	private static void _0023_003DzRJTFvAna_0024_0024JsgC82zw_003D_003D(HiddenLinesViewSettingsEx _0023_003Dz6eJ7SoKZDs_0024_0024, Graphics _0023_003DzrV6eaSI_003D, float _0023_003Dz5keHpXqrJjAd, IList<HiddenLinesView.HdlCurve> _0023_003DzrlP0XU9Qy7PRzHrblw_003D_003D, IList<HiddenLinesView.HdlCurve> _0023_003DzsenC4xd7ckFK, IList<HiddenLinesView.HdlCurve> _0023_003DzJ9AmQcDUVNAX1zyGzw_003D_003D, IList<HiddenLinesView.HdlCurve> _0023_003Dzp8pQEF1ZMleUthGj0g_003D_003D, IList<HiddenLinesView.HdlCurve> _0023_003DzLu_0024ZHet7Gt3U, IList<HiddenLinesView.HdlCurve> _0023_003DzwaFViKNhMbz0QltaMQ_003D_003D, IList<HiddenLinesView.HdlText> _0023_003DzNJ7gLTJ5RK7q, IList<HiddenLinesView.HdlPicture> _0023_003DzYeAApFP2R3BmtcrTaw_003D_003D, IList<SilhoWireAndTriangleData> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, IList<HiddenLinesView.HdlSection> _0023_003DzOvyKIffg34sc, double _0023_003Dz6VaqBeg2493U)
	{
		_0023_003Dz6eJ7SoKZDs_0024_0024._0023_003DzyiaK2qTugB_F(_0023_003DzrV6eaSI_003D, _0023_003DzYeAApFP2R3BmtcrTaw_003D_003D);
		SmoothingMode smoothingMode = _0023_003DzrV6eaSI_003D.SmoothingMode;
		_0023_003DzrV6eaSI_003D.SmoothingMode = SmoothingMode.HighQuality;
		if (_0023_003Dz6eJ7SoKZDs_0024_0024.KeepHiddenSegments)
		{
			_0023_003Dz6eJ7SoKZDs_0024_0024._0023_003DzFEchN98QAX8NauMzyw_003D_003D(_0023_003DzrV6eaSI_003D, _0023_003Dz6eJ7SoKZDs_0024_0024.PenHiddenSilhouette, _0023_003Dzp8pQEF1ZMleUthGj0g_003D_003D, _0023_003Dz5keHpXqrJjAd);
			_0023_003Dz6eJ7SoKZDs_0024_0024._0023_003DzFEchN98QAX8NauMzyw_003D_003D(_0023_003DzrV6eaSI_003D, _0023_003Dz6eJ7SoKZDs_0024_0024.PenHiddenEdge, _0023_003DzLu_0024ZHet7Gt3U, _0023_003Dz5keHpXqrJjAd);
			_0023_003Dz6eJ7SoKZDs_0024_0024._0023_003DzFEchN98QAX8NauMzyw_003D_003D(_0023_003DzrV6eaSI_003D, _0023_003Dz6eJ7SoKZDs_0024_0024.PenHiddenWire, _0023_003DzwaFViKNhMbz0QltaMQ_003D_003D, _0023_003Dz5keHpXqrJjAd);
		}
		_0023_003Dz6eJ7SoKZDs_0024_0024._0023_003DzFEchN98QAX8NauMzyw_003D_003D(_0023_003DzrV6eaSI_003D, _0023_003Dz6eJ7SoKZDs_0024_0024.PenSilhouette, _0023_003DzrlP0XU9Qy7PRzHrblw_003D_003D, _0023_003Dz5keHpXqrJjAd);
		_0023_003Dz6eJ7SoKZDs_0024_0024._0023_003DzFEchN98QAX8NauMzyw_003D_003D(_0023_003DzrV6eaSI_003D, _0023_003Dz6eJ7SoKZDs_0024_0024.PenEdge, _0023_003DzsenC4xd7ckFK, _0023_003Dz5keHpXqrJjAd);
		_0023_003Dz6eJ7SoKZDs_0024_0024._0023_003DzFEchN98QAX8NauMzyw_003D_003D(_0023_003DzrV6eaSI_003D, _0023_003Dz6eJ7SoKZDs_0024_0024.PenWire, _0023_003DzJ9AmQcDUVNAX1zyGzw_003D_003D, _0023_003Dz5keHpXqrJjAd);
		_0023_003Dz6eJ7SoKZDs_0024_0024._0023_003DzvH_4W62doY_C(_0023_003DzrV6eaSI_003D, _0023_003Dz6eJ7SoKZDs_0024_0024.PenWire, _0023_003DzNJ7gLTJ5RK7q);
		_0023_003Dz6eJ7SoKZDs_0024_0024._0023_003Dz8ic3vZey7H_00246(_0023_003DzrV6eaSI_003D, _0023_003Dz6eJ7SoKZDs_0024_0024.PenEdge, _0023_003Dz5keHpXqrJjAd, _0023_003DzOvyKIffg34sc, _0023_003Dz6VaqBeg2493U);
		_0023_003DzrV6eaSI_003D.SmoothingMode = smoothingMode;
		_0023_003DzUNsJlaF_0024l2jS1FWZLQ_003D_003D(_0023_003Dz6eJ7SoKZDs_0024_0024, _0023_003DzrV6eaSI_003D, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D);
	}

	private static void _0023_003DzUNsJlaF_0024l2jS1FWZLQ_003D_003D(HiddenLinesViewSettingsEx _0023_003Dz6eJ7SoKZDs_0024_0024, Graphics _0023_003DzVC9FBdo_003D, IList<SilhoWireAndTriangleData> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D)
	{
		if (_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D != null)
		{
			if (_0023_003Dz6eJ7SoKZDs_0024_0024.KeepEntityColor)
			{
				_0023_003Dz6eJ7SoKZDs_0024_0024._0023_003DzDUm62tZpEMC9sC3vHkKbYyU_003D(_0023_003DzVC9FBdo_003D, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D);
			}
			else
			{
				_0023_003Dz6eJ7SoKZDs_0024_0024._0023_003DzUNsJlaF_0024l2jS1FWZLQ_003D_003D(_0023_003DzVC9FBdo_003D, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D);
			}
		}
	}
}
