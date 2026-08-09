using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Xbim.IO.Step21;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;

internal sealed class _0023_003DzfqmL8TzDtVBDf6_u_0024A_003D_003D : _0023_003DzZblWR4M6qOLiy7U57TkX2pA_003D
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<_0023_003DzUTPND_0024PaoLcT45gigpwkrAY_003D, bool> _0023_003DzCrJzJ1fv7yio0ulh1w_003D_003D;

		internal bool _0023_003DzjPBn_0024fDKylABr2Cg7qsXZDo_003D(_0023_003DzUTPND_0024PaoLcT45gigpwkrAY_003D _0023_003DzeKd1WNM_003D)
		{
			return _0023_003DzeKd1WNM_003D._0023_003Dzt_0024XsrgUVsoDn() != null;
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dzy0H2hy2_4Jd42s_1gdOD024_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public XbimP21StringDecoder _0023_003DzoJIN5IQ_003D;
	}

	private List<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D> _0023_003Dzh6YNBZo_003D;

	private List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dzz7t9eZ3oRevB7WLFqFsvPz8MoBPS;

	private List<_0023_003DzW8zZzhCUviR_0024> _0023_003DzWTqwGQleZDfe;

	private double _0023_003DzfAW64ptugHc7 = 1.0;

	private double _0023_003Dz_00243V7Ggd4bnAF = 1.0;

	private string _0023_003Dzu97QPYFcxmdi;

	internal StringBuilder _0023_003DzqmF8XJ0_003D;

	private List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003Dz_0024tsMtQo_003D;

	private _0023_003DzdR99lgbR34Ip _0023_003DzBq5cSTMdhlT9;

	private Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dzw3_zM5Q_003D;

	private _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003Dz20MotOOKQrd2iDUoknubPNw_003D;

	private List<_0023_003DzkVp4tX004w2oJwpl6rG1Ieg_003D> _0023_003DzaAWQVszRwijTsnoq4g_003D_003D;

	private List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003DzaSEwpHnmS0FU;

	private List<_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D> _0023_003DzE4pCHfVSrHtv;

	private List<_0023_003DzYiQuDIbIKeJ_MKZwJg_003D_003D> _0023_003DzlOP6VaMU1vkU;

	private List<_0023_003DzXVg_o8eXCN5urKlG3c_AHLJ6Q9GB> _0023_003DzDD_00244lsO5bxkQ2RRbWA_003D_003D;

	private List<_0023_003DzemlTiYWC36sO_0024NbVtg_003D_003D> _0023_003DzBjSZpWXVuCCh;

	private List<_0023_003DzWeLcFNnq3Jd9ST_rNz_diLr6zZy4> _0023_003DzABr4NtFh0Gn9dc8ZO2ohkTWU_0024f3H;

	private List<_0023_003Dzjl_lT5RDLJuZp1ZdI5Sk9CA_003D> _0023_003DzkZsqISH5u_uSpo42Og_003D_003D;

	private List<_0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D> _0023_003DzwgOXK31uw2p6M8QC7Q_003D_003D;

	private List<_0023_003Dzqen9hYLr5EE5jkMh7zzOtlA_003D> _0023_003DziRRId2HNt0NygOhl5wX35Ew_003D;

	private List<_0023_003Dzykim6AWH_SwY_0024cfQ53xbHLLgRflt> _0023_003Dzacu0aYQFX8et1UdPbQ_003D_003D;

	private List<_0023_003DzAI9YqCWKp0mYYODw1A_003D_003D> _0023_003DzLwWu5qutzior5d8WvYp77qw_003D;

	private List<_0023_003Dz8M8UlaItmjTo_EcR1w_003D_003D> _0023_003DziVG7fzQMidan;

	private List<_0023_003DzmwEee3fUKhueUmNzTcE5YdHZjRJM> _0023_003Dzi3Kw0F1AGzWzCTCKqA_003D_003D;

	private List<_0023_003DzUTPND_0024PaoLcT45gigpwkrAY_003D> _0023_003Dzb99xLb_0024r9MP8qdgr6A_003D_003D;

	private List<_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D> _0023_003DzUadcn47MHAXU;

	private List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz2HZdVTY8us3b;

	private List<_0023_003DzzoqZ7r6_g11JF2TbYw_003D_003D> _0023_003DzgoyZECDmOlGR_0024XT_0024mg_003D_003D;

	private List<_0023_003DznsjBPaTUABFe8okkLB4jM_EmBrbb> _0023_003DzzEe3qdoUVj8l4V78d93K1ps_003D;

	private Dictionary<string, _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003Dz_bJZY76vDcwlGCIgGA_003D_003D;

	private Dictionary<string, _0023_003DzSwNzCUSMkuVSrWhDng_003D_003D> _0023_003DzAX0iigCEnhKp1e_0024AVw_003D_003D;

	private Dictionary<string, int> _0023_003DzoeXiThQ_0024bV6dYFdB1w_003D_003D;

	private linearUnitsType _0023_003DzmXe8ukNXQAuMEbK_0024tz7Jloo_003D;

	private angularUnitsType _0023_003DzH260tJ3BDelgmeyq1ZNQ_2U_003D;

	private _0023_003DzpG3knF8X_QXtui_hmA_003D_003D _0023_003DzFEKJk4nyKhr8SEjL8w_003D_003D;

	private int _0023_003DzJjVQTzpKI4Ni;

	private int _0023_003Dzc0bXpQg_mBG9T3tE_0024A_003D_003D;

	private int _0023_003DzZ3ZEoZVUz3dYtsTHhw_003D_003D;

	private bool _0023_003Dzm4CSmX5Y3o6Q;

	public _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzbPNup9w_003D;

	private int _0023_003DzckyvB_y9X6IplWWbBA_003D_003D;

	public string _0023_003Dz2tLFTBU_003D;

	public DateTime _0023_003Dzy1JXpLg_003D;

	public string _0023_003DzG44DSbY_003D;

	public string _0023_003DzhthqjT8_003D;

	public string _0023_003Dz74dsc2o_003D;

	public string _0023_003DzANNg5ZAGvZW6;

	public string _0023_003DzP6NWWAU_003D;

	public _0023_003DzfqmL8TzDtVBDf6_u_0024A_003D_003D()
	{
		_0023_003DzBq5cSTMdhlT9 = null;
		_0023_003Dzw3_zM5Q_003D = null;
		_0023_003Dzh6YNBZo_003D = null;
		_0023_003DzWTqwGQleZDfe = null;
		_0023_003Dz_0024tsMtQo_003D = null;
		_0023_003Dzz7t9eZ3oRevB7WLFqFsvPz8MoBPS = null;
		_0023_003DzaSEwpHnmS0FU = new List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>();
		_0023_003DzaAWQVszRwijTsnoq4g_003D_003D = new List<_0023_003DzkVp4tX004w2oJwpl6rG1Ieg_003D>();
		_0023_003DzE4pCHfVSrHtv = new List<_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D>();
		_0023_003DzlOP6VaMU1vkU = null;
		_0023_003DzDD_00244lsO5bxkQ2RRbWA_003D_003D = null;
		_0023_003DzBjSZpWXVuCCh = null;
		_0023_003DzABr4NtFh0Gn9dc8ZO2ohkTWU_0024f3H = null;
		_0023_003DzkZsqISH5u_uSpo42Og_003D_003D = null;
		_0023_003DzwgOXK31uw2p6M8QC7Q_003D_003D = null;
		_0023_003DzgoyZECDmOlGR_0024XT_0024mg_003D_003D = null;
		_0023_003Dz_bJZY76vDcwlGCIgGA_003D_003D = new Dictionary<string, _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D>(StringComparer.OrdinalIgnoreCase);
		_0023_003DzAX0iigCEnhKp1e_0024AVw_003D_003D = new Dictionary<string, _0023_003DzSwNzCUSMkuVSrWhDng_003D_003D>(StringComparer.OrdinalIgnoreCase);
		_0023_003DzzEe3qdoUVj8l4V78d93K1ps_003D = new List<_0023_003DznsjBPaTUABFe8okkLB4jM_EmBrbb>();
		_0023_003DzoeXiThQ_0024bV6dYFdB1w_003D_003D = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
		_0023_003DzqmF8XJ0_003D = new StringBuilder();
	}

	public linearUnitsType _0023_003DzGdfaeVqs6Ch4()
	{
		return _0023_003DzmXe8ukNXQAuMEbK_0024tz7Jloo_003D;
	}

	public void _0023_003DzCDCZPhS9OYQO(linearUnitsType _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzmXe8ukNXQAuMEbK_0024tz7Jloo_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public angularUnitsType _0023_003DzUgQenuNv91OE()
	{
		return _0023_003DzH260tJ3BDelgmeyq1ZNQ_2U_003D;
	}

	public void _0023_003Dzv_0024LHH24qrXtd(angularUnitsType _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzH260tJ3BDelgmeyq1ZNQ_2U_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public _0023_003DzpG3knF8X_QXtui_hmA_003D_003D _0023_003Dzys6Fn1UQ6mxr()
	{
		return _0023_003DzFEKJk4nyKhr8SEjL8w_003D_003D;
	}

	public void _0023_003DzU_k49O_ujEeJ(_0023_003DzpG3knF8X_QXtui_hmA_003D_003D _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzFEKJk4nyKhr8SEjL8w_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public void _0023_003DzaziuZpKBVG0K(StringCollection _0023_003DzcxcrDhg_003D, out string _0023_003DzQRmFkL41VtBq, out DateTime _0023_003Dz3KxzwrNGMDEk, out string _0023_003DzP7FoWTPYiff9, out string _0023_003DzxF_0024FM1Zg3jT7zfolB_0024FSGCE_003D, out string _0023_003DzbYQ6ImJ7Ebb_0024, out string _0023_003DzR4eGWVZhkltW)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		StringEnumerator enumerator = _0023_003DzcxcrDhg_003D.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				if (flag)
				{
					if (current.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302927372)) || current.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302919773)))
					{
						break;
					}
					stringBuilder.Append(current);
				}
				if (current.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302927614)))
				{
					flag = true;
					stringBuilder.Append(current);
				}
			}
		}
		finally
		{
			if (enumerator is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
		Match match = Regex.Match(Regex.Replace(stringBuilder.ToString(), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302927598), string.Empty, RegexOptions.Singleline), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302927582), RegexOptions.Singleline);
		if (match.Success)
		{
			_0023_003Dzy0H2hy2_4Jd42s_1gdOD024_003D _0023_003DzE1OtBpQ_003D = default(_0023_003Dzy0H2hy2_4Jd42s_1gdOD024_003D);
			_0023_003DzE1OtBpQ_003D._0023_003DzoJIN5IQ_003D = new XbimP21StringDecoder();
			_0023_003DzQRmFkL41VtBq = _0023_003DzE1OtBpQ_003D._0023_003DzoJIN5IQ_003D.Unescape(match.Groups[1].Value);
			string text = _0023_003DzE1OtBpQ_003D._0023_003DzoJIN5IQ_003D.Unescape(match.Groups[2].Value);
			if (!string.IsNullOrEmpty(text) && char.ToUpper(text[text.Length - 1]) == 'T')
			{
				text = text.Substring(0, text.Length - 1);
			}
			if (DateTime.TryParse(text, out var result))
			{
				_0023_003Dz3KxzwrNGMDEk = result;
			}
			else
			{
				_0023_003Dz3KxzwrNGMDEk = default(DateTime);
				_0023_003DzqmF8XJ0_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302928178));
			}
			_0023_003DzP7FoWTPYiff9 = string.Join(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962), _0023_003DqYr7sTziHmRRs4M1NuKCJ8DXM8UH2GYiYDfNUWbxPCRZ8Y_ZeXjmQb6_tIhaog8fV(match.Groups[3].Value, ref _0023_003DzE1OtBpQ_003D));
			_0023_003DzxF_0024FM1Zg3jT7zfolB_0024FSGCE_003D = string.Join(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962), _0023_003DqYr7sTziHmRRs4M1NuKCJ8DXM8UH2GYiYDfNUWbxPCRZ8Y_ZeXjmQb6_tIhaog8fV(match.Groups[4].Value, ref _0023_003DzE1OtBpQ_003D));
			_0023_003DzbYQ6ImJ7Ebb_0024 = _0023_003DzE1OtBpQ_003D._0023_003DzoJIN5IQ_003D.Unescape(match.Groups[5].Value);
			_0023_003DzR4eGWVZhkltW = _0023_003DzE1OtBpQ_003D._0023_003DzoJIN5IQ_003D.Unescape(match.Groups[6].Value);
		}
		else
		{
			_0023_003DzQRmFkL41VtBq = string.Empty;
			_0023_003Dz3KxzwrNGMDEk = default(DateTime);
			_0023_003DzP7FoWTPYiff9 = string.Empty;
			_0023_003DzxF_0024FM1Zg3jT7zfolB_0024FSGCE_003D = string.Empty;
			_0023_003DzbYQ6ImJ7Ebb_0024 = string.Empty;
			_0023_003DzR4eGWVZhkltW = string.Empty;
		}
	}

	public bool _0023_003DzL1pv4BgVH0z3(StringCollection _0023_003DzcxcrDhg_003D)
	{
		_0023_003DzJjVQTzpKI4Ni = 0;
		_0023_003Dzc0bXpQg_mBG9T3tE_0024A_003D_003D = 0;
		_0023_003DzZ3ZEoZVUz3dYtsTHhw_003D_003D = 0;
		_0023_003Dzm4CSmX5Y3o6Q = false;
		return _0023_003DzKfSsmwLRzer8(_0023_003DzcxcrDhg_003D);
	}

	private void _0023_003Dz681SFOmrKDsN(List<_0023_003Dz_HkpPpufGn2c90cjUA_003D_003D> _0023_003DzcDEsV8s_003D)
	{
		_0023_003DzpG3knF8X_QXtui_hmA_003D_003D _0023_003DzPzO_0024GUk_003D = new _0023_003DzpG3knF8X_QXtui_hmA_003D_003D(_0023_003DzcDEsV8s_003D);
		_0023_003DzU_k49O_ujEeJ(_0023_003DzPzO_0024GUk_003D);
	}

	public void _0023_003DzVqyekxQNS_00244Y()
	{
		_0023_003DzUadcn47MHAXU = new List<_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D>();
		foreach (KeyValuePair<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> item3 in _0023_003Dzw3_zM5Q_003D)
		{
			_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2 = new _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D();
			_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D value = item3.Value;
			if (!(value is _0023_003Dzqen9hYLr5EE5jkMh7zzOtlA_003D _0023_003DzhnYMaEezboJ2HGUbLQ_003D_003D))
			{
				if (!(value is _0023_003Dzykim6AWH_SwY_0024cfQ53xbHLLgRflt _0023_003Dz6lfFYNjkleEuJzRn5g_003D_003D))
				{
					if (!(value is _0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D _0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D2) || _0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D2._0023_003DzicQSqB0_003D[0]._0023_003DzQ4yTlf3MMmGo.Count <= 0)
					{
						continue;
					}
					_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D._0023_003DzCR8yxwe_0024nSm_bQ6UoQ_003D_003D(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2, _0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D2, _0023_003DzqmF8XJ0_003D);
					foreach (_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D item4 in _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003Dz0SpZWCCz_qrn)
					{
						_0023_003DzUadcn47MHAXU.Add(item4);
						if (_0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D2._0023_003Dzwtld1NM_003D != null && (item4._0023_003Dzwtld1NM_003D == null || item4._0023_003Dzwtld1NM_003D[0] == -1.0))
						{
							item4._0023_003Dzwtld1NM_003D = _0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D2._0023_003Dzwtld1NM_003D;
						}
					}
				}
				else
				{
					_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D._0023_003Dz96a2P1EpjvJpkA2QfQ_003D_003D(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2, _0023_003Dz6lfFYNjkleEuJzRn5g_003D_003D, _0023_003DzqmF8XJ0_003D);
					_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D item = _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003Dz5bVmMWCNZpiUDgO8rg_003D_003D()[0];
					_0023_003DzUadcn47MHAXU.Add(item);
				}
			}
			else
			{
				_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D._0023_003Dz_QX1FXJpfD4H(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2, _0023_003DzhnYMaEezboJ2HGUbLQ_003D_003D, _0023_003DzqmF8XJ0_003D);
				_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D item2 = _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003Dz5bVmMWCNZpiUDgO8rg_003D_003D()[0];
				_0023_003DzUadcn47MHAXU.Add(item2);
			}
		}
	}

	public void _0023_003Dzjy1J3S9O3LhX()
	{
		_0023_003Dz2HZdVTY8us3b = new List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>();
		foreach (KeyValuePair<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> item in _0023_003Dzw3_zM5Q_003D)
		{
			_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2 = new _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D();
			if (item.Value is _0023_003DzMm8M_0024rptDOeEFLoF_Mik_v6MUyc3alaHVw_003D_003D)
			{
				_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D._0023_003DzC0gOp2wBzm9LIQstWbrGS87DuOEG(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2, item.Value);
				_0023_003Dz2HZdVTY8us3b.AddRange(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzgqVFrJs0QtPIONrKBA_003D_003D());
			}
		}
	}

	public void _0023_003Dz84CxaAf_fB5FNFVv3A_003D_003D(ref List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003DztmmTsY1KYEGmCwEqcQ_003D_003D)
	{
		_0023_003Dzz7t9eZ3oRevB7WLFqFsvPz8MoBPS = new List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>();
		foreach (KeyValuePair<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> item in _0023_003Dzw3_zM5Q_003D)
		{
			_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D value = item.Value;
			if (!(value is _0023_003Dzss6PgCjYIzY9kelPFc5_0024jiI_003D _0023_003Dzss6PgCjYIzY9kelPFc5_0024jiI_003D2))
			{
				if (value is _0023_003DzvIQID_0024KC_OBm3i8fWRGKUyHCcX_7 _0023_003DzvIQID_0024KC_OBm3i8fWRGKUyHCcX_8)
				{
					_0023_003Dzz7t9eZ3oRevB7WLFqFsvPz8MoBPS.AddRange(_0023_003DzvIQID_0024KC_OBm3i8fWRGKUyHCcX_8._0023_003DzWQCyvnY_003D);
				}
			}
			else
			{
				_0023_003Dzz7t9eZ3oRevB7WLFqFsvPz8MoBPS.AddRange(_0023_003Dzss6PgCjYIzY9kelPFc5_0024jiI_003D2._0023_003DzWQCyvnY_003D);
			}
		}
		_0023_003DztmmTsY1KYEGmCwEqcQ_003D_003D = _0023_003Dzz7t9eZ3oRevB7WLFqFsvPz8MoBPS;
	}

	public void _0023_003DzdXJzlEd7nY1RxMIi0g_003D_003D(ref List<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D> _0023_003DzyUxFNVpGo2KvYBxjbQ_003D_003D)
	{
		if (_0023_003Dzh6YNBZo_003D == null)
		{
			_0023_003Dz75gufzcFRDgludX6vqKhy64_003D();
		}
		_0023_003DzyUxFNVpGo2KvYBxjbQ_003D_003D = _0023_003Dzh6YNBZo_003D;
	}

	public void _0023_003DzGbR9JPJ0aogC(ref List<_0023_003Dzg57a2G_0024kb4zJICTmUA_003D_003D> _0023_003DzeVF1vQYm3s4MoAJT9Q_003D_003D)
	{
		if (_0023_003DzUadcn47MHAXU == null)
		{
			_0023_003DzVqyekxQNS_00244Y();
		}
		_0023_003DzeVF1vQYm3s4MoAJT9Q_003D_003D = _0023_003DzUadcn47MHAXU;
	}

	public void _0023_003DzCi2ZprWO37C1(ref List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003DzRpG7MzWX9ONajaaI7Q_003D_003D)
	{
		if (_0023_003Dz2HZdVTY8us3b == null)
		{
			_0023_003Dzjy1J3S9O3LhX();
		}
		_0023_003DzRpG7MzWX9ONajaaI7Q_003D_003D = _0023_003Dz2HZdVTY8us3b;
	}

	public List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003DzlxKBCJ2zobwv()
	{
		_0023_003Dz_0024tsMtQo_003D = new List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D>();
		_0023_003DzlOP6VaMU1vkU = new List<_0023_003DzYiQuDIbIKeJ_MKZwJg_003D_003D>();
		_0023_003DzDD_00244lsO5bxkQ2RRbWA_003D_003D = new List<_0023_003DzXVg_o8eXCN5urKlG3c_AHLJ6Q9GB>();
		_0023_003DzBjSZpWXVuCCh = new List<_0023_003DzemlTiYWC36sO_0024NbVtg_003D_003D>();
		_0023_003DzABr4NtFh0Gn9dc8ZO2ohkTWU_0024f3H = new List<_0023_003DzWeLcFNnq3Jd9ST_rNz_diLr6zZy4>();
		_0023_003DzkZsqISH5u_uSpo42Og_003D_003D = new List<_0023_003Dzjl_lT5RDLJuZp1ZdI5Sk9CA_003D>();
		_0023_003DzwgOXK31uw2p6M8QC7Q_003D_003D = new List<_0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D>();
		_0023_003DziRRId2HNt0NygOhl5wX35Ew_003D = new List<_0023_003Dzqen9hYLr5EE5jkMh7zzOtlA_003D>();
		_0023_003Dzacu0aYQFX8et1UdPbQ_003D_003D = new List<_0023_003Dzykim6AWH_SwY_0024cfQ53xbHLLgRflt>();
		_0023_003DzLwWu5qutzior5d8WvYp77qw_003D = new List<_0023_003DzAI9YqCWKp0mYYODw1A_003D_003D>();
		_0023_003DziVG7fzQMidan = new List<_0023_003Dz8M8UlaItmjTo_EcR1w_003D_003D>();
		_0023_003Dzi3Kw0F1AGzWzCTCKqA_003D_003D = new List<_0023_003DzmwEee3fUKhueUmNzTcE5YdHZjRJM>();
		_0023_003Dzb99xLb_0024r9MP8qdgr6A_003D_003D = new List<_0023_003DzUTPND_0024PaoLcT45gigpwkrAY_003D>();
		_0023_003DzckyvB_y9X6IplWWbBA_003D_003D = 0;
		foreach (KeyValuePair<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> item16 in _0023_003Dzw3_zM5Q_003D)
		{
			_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D value = item16.Value;
			if (!(value is _0023_003DzLT03Ch1QxAXtdY3O67Esh9k_003D item))
			{
				if (!(value is _0023_003Dzqen9hYLr5EE5jkMh7zzOtlA_003D item2))
				{
					if (!(value is _0023_003Dzykim6AWH_SwY_0024cfQ53xbHLLgRflt item3))
					{
						if (!(value is _0023_003DzAI9YqCWKp0mYYODw1A_003D_003D item4))
						{
							if (!(value is _0023_003DzkVp4tX004w2oJwpl6rG1Ieg_003D item5))
							{
								if (!(value is _0023_003DzYiQuDIbIKeJ_MKZwJg_003D_003D item6))
								{
									if (!(value is _0023_003Dz8M8UlaItmjTo_EcR1w_003D_003D item7))
									{
										if (!(value is _0023_003DzmwEee3fUKhueUmNzTcE5YdHZjRJM item8))
										{
											if (!(value is _0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D item9))
											{
												if (!(value is _0023_003Dzjl_lT5RDLJuZp1ZdI5Sk9CA_003D item10))
												{
													if (!(value is _0023_003DzWeLcFNnq3Jd9ST_rNz_diLr6zZy4 item11))
													{
														if (!(value is _0023_003DzemlTiYWC36sO_0024NbVtg_003D_003D item12))
														{
															if (!(value is _0023_003DzXVg_o8eXCN5urKlG3c_AHLJ6Q9GB item13))
															{
																if (!(value is _0023_003DzUTPND_0024PaoLcT45gigpwkrAY_003D item14))
																{
																	if (value is _0023_003DznsjBPaTUABFe8okkLB4jM_EmBrbb item15)
																	{
																		_0023_003DzzEe3qdoUVj8l4V78d93K1ps_003D.Add(item15);
																	}
																}
																else
																{
																	_0023_003Dzb99xLb_0024r9MP8qdgr6A_003D_003D.Add(item14);
																}
															}
															else
															{
																_0023_003DzDD_00244lsO5bxkQ2RRbWA_003D_003D.Add(item13);
															}
														}
														else
														{
															_0023_003DzBjSZpWXVuCCh.Add(item12);
														}
													}
													else
													{
														_0023_003DzABr4NtFh0Gn9dc8ZO2ohkTWU_0024f3H.Add(item11);
													}
												}
												else
												{
													_0023_003DzkZsqISH5u_uSpo42Og_003D_003D.Add(item10);
												}
											}
											else
											{
												_0023_003DzwgOXK31uw2p6M8QC7Q_003D_003D.Add(item9);
											}
										}
										else
										{
											_0023_003Dzi3Kw0F1AGzWzCTCKqA_003D_003D.Add(item8);
										}
									}
									else
									{
										_0023_003DziVG7fzQMidan.Add(item7);
									}
								}
								else
								{
									_0023_003DzlOP6VaMU1vkU.Add(item6);
								}
							}
							else
							{
								_0023_003DzaAWQVszRwijTsnoq4g_003D_003D.Add(item5);
							}
						}
						else
						{
							_0023_003DzLwWu5qutzior5d8WvYp77qw_003D.Add(item4);
						}
					}
					else
					{
						_0023_003Dzacu0aYQFX8et1UdPbQ_003D_003D.Add(item3);
					}
				}
				else
				{
					_0023_003DziRRId2HNt0NygOhl5wX35Ew_003D.Add(item2);
				}
			}
			else
			{
				_0023_003DzaSEwpHnmS0FU.Add(item);
			}
		}
		if (_0023_003Dzb99xLb_0024r9MP8qdgr6A_003D_003D.Count((_0023_003DzUTPND_0024PaoLcT45gigpwkrAY_003D _0023_003DzeKd1WNM_003D) => _0023_003DzeKd1WNM_003D._0023_003Dzt_0024XsrgUVsoDn() != null) > 0 || _0023_003DziVG7fzQMidan.Count > 0 || _0023_003DzaAWQVszRwijTsnoq4g_003D_003D.Count > 0)
		{
			if (_0023_003DzaSEwpHnmS0FU.Count > 0 || _0023_003DziVG7fzQMidan.Count > 0)
			{
				_0023_003DzHAQnJ_E_0024pz73(_0023_003DzlOP6VaMU1vkU);
			}
		}
		else if (_0023_003DziRRId2HNt0NygOhl5wX35Ew_003D.Count > 0 || _0023_003Dzacu0aYQFX8et1UdPbQ_003D_003D.Count > 0 || _0023_003DzLwWu5qutzior5d8WvYp77qw_003D.Count > 0)
		{
			_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D._0023_003Dz7TdU2ZQ_003D(_0023_003Dzw3_zM5Q_003D, _0023_003Dz_0024tsMtQo_003D, _0023_003DzGdfaeVqs6Ch4(), _0023_003DzUgQenuNv91OE(), _0023_003DzoeXiThQ_0024bV6dYFdB1w_003D_003D, _0023_003Dz_bJZY76vDcwlGCIgGA_003D_003D, ref _0023_003DzbPNup9w_003D, _0023_003DzqmF8XJ0_003D, ref _0023_003DzckyvB_y9X6IplWWbBA_003D_003D);
		}
		return _0023_003Dz_0024tsMtQo_003D;
	}

	private void _0023_003DzHAQnJ_E_0024pz73(List<_0023_003DzYiQuDIbIKeJ_MKZwJg_003D_003D> _0023_003Dz2L50YLU_003D)
	{
		_0023_003Dz_0024tsMtQo_003D = new List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D>();
		foreach (_0023_003DzYiQuDIbIKeJ_MKZwJg_003D_003D item in _0023_003Dz2L50YLU_003D)
		{
			foreach (_0023_003DzXVg_o8eXCN5urKlG3c_AHLJ6Q9GB item2 in _0023_003DzDD_00244lsO5bxkQ2RRbWA_003D_003D)
			{
				if (item2 == null || item._0023_003DzkXQ_IWk_003D != item2._0023_003DzVAfW3FkxHlvz._0023_003DzkXQ_IWk_003D)
				{
					continue;
				}
				foreach (_0023_003DzemlTiYWC36sO_0024NbVtg_003D_003D item3 in _0023_003DzBjSZpWXVuCCh)
				{
					if (item3 == null || item2._0023_003DzkXQ_IWk_003D != item3._0023_003DzxmmtKwaHH_Gx5hWsqsr1_wo_003D._0023_003DzkXQ_IWk_003D)
					{
						continue;
					}
					foreach (_0023_003Dzjl_lT5RDLJuZp1ZdI5Sk9CA_003D item4 in _0023_003DzkZsqISH5u_uSpo42Og_003D_003D)
					{
						if (item4 == null || item4._0023_003Dz4h89SpjJsmqnhfZLgQ_003D_003D == null || item3._0023_003DzkXQ_IWk_003D != item4._0023_003Dz4h89SpjJsmqnhfZLgQ_003D_003D._0023_003DzkXQ_IWk_003D)
						{
							continue;
						}
						foreach (_0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D item5 in _0023_003DzwgOXK31uw2p6M8QC7Q_003D_003D)
						{
							if (item5 != null && item5._0023_003Dz84KwATjmsHCrNInHqg_003D_003D != null && item4._0023_003DzkXQ_IWk_003D == item5._0023_003Dz84KwATjmsHCrNInHqg_003D_003D._0023_003DzkXQ_IWk_003D)
							{
								_0023_003DzoW1KuezLmAUqaJzv_Q_003D_003D(item5, item, ref _0023_003DzckyvB_y9X6IplWWbBA_003D_003D);
							}
						}
					}
				}
				foreach (_0023_003DzWeLcFNnq3Jd9ST_rNz_diLr6zZy4 item6 in _0023_003DzABr4NtFh0Gn9dc8ZO2ohkTWU_0024f3H)
				{
					if (item6 == null || item2._0023_003DzkXQ_IWk_003D != item6._0023_003DzxmmtKwaHH_Gx5hWsqsr1_wo_003D._0023_003DzkXQ_IWk_003D)
					{
						continue;
					}
					foreach (_0023_003Dzjl_lT5RDLJuZp1ZdI5Sk9CA_003D item7 in _0023_003DzkZsqISH5u_uSpo42Og_003D_003D)
					{
						if (item7 == null || item7._0023_003DzZ3QlhPdVqw9why6QP68y2y0_003D == null || item6._0023_003DzkXQ_IWk_003D != item7._0023_003DzZ3QlhPdVqw9why6QP68y2y0_003D._0023_003DzkXQ_IWk_003D)
						{
							continue;
						}
						foreach (_0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D item8 in _0023_003DzwgOXK31uw2p6M8QC7Q_003D_003D)
						{
							if (item8 != null && item8._0023_003Dz84KwATjmsHCrNInHqg_003D_003D != null && item7._0023_003DzkXQ_IWk_003D == item8._0023_003Dz84KwATjmsHCrNInHqg_003D_003D._0023_003DzkXQ_IWk_003D)
							{
								_0023_003DzoW1KuezLmAUqaJzv_Q_003D_003D(item8, item, ref _0023_003DzckyvB_y9X6IplWWbBA_003D_003D);
							}
						}
					}
				}
			}
		}
	}

	private void _0023_003DzoW1KuezLmAUqaJzv_Q_003D_003D(_0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D _0023_003DzUu_0024TbPKbdn4s, _0023_003DzYiQuDIbIKeJ_MKZwJg_003D_003D _0023_003Dz2t9nEMs_003D, ref int _0023_003DzckyvB_y9X6IplWWbBA_003D_003D)
	{
		int _0023_003DzGGUd1aw_003D = -1;
		linearUnitsType _0023_003DzgjkdNj6Exo1g = linearUnitsType.Unitless;
		if (_0023_003DzUu_0024TbPKbdn4s._0023_003DzZOuko1840Cwyjmv91xpUjjI_003D != null)
		{
			_0023_003DzGGUd1aw_003D = _0023_003DzUu_0024TbPKbdn4s._0023_003DzZOuko1840Cwyjmv91xpUjjI_003D._0023_003DzkXQ_IWk_003D;
			_0023_003DzdoqmyeTsU8oa(_0023_003DzUu_0024TbPKbdn4s._0023_003DzZOuko1840Cwyjmv91xpUjjI_003D._0023_003DzNzjvfA4_003D, ref _0023_003DzgjkdNj6Exo1g);
		}
		else if (_0023_003DzUu_0024TbPKbdn4s._0023_003DzKhlUT1unKe_0024S != null)
		{
			_0023_003DzGGUd1aw_003D = _0023_003DzUu_0024TbPKbdn4s._0023_003DzKhlUT1unKe_0024S._0023_003DzkXQ_IWk_003D;
			_0023_003DzdoqmyeTsU8oa(_0023_003DzUu_0024TbPKbdn4s._0023_003DzKhlUT1unKe_0024S._0023_003DzNzjvfA4_003D, ref _0023_003DzgjkdNj6Exo1g);
		}
		else if (_0023_003DzUu_0024TbPKbdn4s._0023_003DzUfFDoQuH0SAmGE7Rb1miHokuulVx != null)
		{
			_0023_003DzGGUd1aw_003D = _0023_003DzUu_0024TbPKbdn4s._0023_003DzUfFDoQuH0SAmGE7Rb1miHokuulVx._0023_003DzkXQ_IWk_003D;
			_0023_003DzdoqmyeTsU8oa(_0023_003DzUu_0024TbPKbdn4s._0023_003DzUfFDoQuH0SAmGE7Rb1miHokuulVx._0023_003DzNzjvfA4_003D, ref _0023_003DzgjkdNj6Exo1g);
		}
		else if (_0023_003DzUu_0024TbPKbdn4s._0023_003DzlZD_hylEX450cUP_D6BBkaALJTzU != null)
		{
			_0023_003DzGGUd1aw_003D = _0023_003DzUu_0024TbPKbdn4s._0023_003DzlZD_hylEX450cUP_D6BBkaALJTzU._0023_003DzkXQ_IWk_003D;
			_0023_003DzdoqmyeTsU8oa(_0023_003DzUu_0024TbPKbdn4s._0023_003DzlZD_hylEX450cUP_D6BBkaALJTzU._0023_003DzNzjvfA4_003D, ref _0023_003DzgjkdNj6Exo1g);
		}
		else if (_0023_003DzUu_0024TbPKbdn4s._0023_003Dzrr53uPSSHlyaNG6tISqKaF0_003D != null)
		{
			_0023_003DzGGUd1aw_003D = _0023_003DzUu_0024TbPKbdn4s._0023_003Dzrr53uPSSHlyaNG6tISqKaF0_003D._0023_003DzkXQ_IWk_003D;
			_0023_003DzdoqmyeTsU8oa(_0023_003DzUu_0024TbPKbdn4s._0023_003Dzrr53uPSSHlyaNG6tISqKaF0_003D._0023_003DzNzjvfA4_003D, ref _0023_003DzgjkdNj6Exo1g);
		}
		else if (_0023_003DzUu_0024TbPKbdn4s._0023_003DzGb1ouzt7VNkoxHwM5hEd03OuZeog4Dc8Xg_003D_003D != null)
		{
			_0023_003DzGGUd1aw_003D = _0023_003DzUu_0024TbPKbdn4s._0023_003DzGb1ouzt7VNkoxHwM5hEd03OuZeog4Dc8Xg_003D_003D._0023_003DzkXQ_IWk_003D;
			_0023_003DzdoqmyeTsU8oa(_0023_003DzUu_0024TbPKbdn4s._0023_003DzGb1ouzt7VNkoxHwM5hEd03OuZeog4Dc8Xg_003D_003D._0023_003DzNzjvfA4_003D, ref _0023_003DzgjkdNj6Exo1g);
		}
		_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D._0023_003Dz7TdU2ZQ_003D(_0023_003Dzw3_zM5Q_003D, _0023_003Dz_0024tsMtQo_003D, _0023_003DzaAWQVszRwijTsnoq4g_003D_003D, _0023_003DzGGUd1aw_003D, _0023_003Dz2t9nEMs_003D._0023_003DzkXQ_IWk_003D, _0023_003Dz2t9nEMs_003D._0023_003DzS_00246o7tc_003D, _0023_003DzgjkdNj6Exo1g, angularUnitsType.Radians, _0023_003DzoeXiThQ_0024bV6dYFdB1w_003D_003D, _0023_003Dz_bJZY76vDcwlGCIgGA_003D_003D, _0023_003DzqmF8XJ0_003D, ref _0023_003DzckyvB_y9X6IplWWbBA_003D_003D);
	}

	private void _0023_003DzdoqmyeTsU8oa(_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003DzcmeyqyyqnxUC, ref linearUnitsType _0023_003DzgjkdNj6Exo1g)
	{
		if (!(_0023_003DzcmeyqyyqnxUC is _0023_003DzEaTthajmBHHE0KlkKQ_003D_003D { _0023_003Dz0_0024SAHCMLrScF: var _0023_003Dz0_0024SAHCMLrScF }) || _0023_003Dz0_0024SAHCMLrScF.Count <= 0)
		{
			return;
		}
		foreach (_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D item in _0023_003Dz0_0024SAHCMLrScF)
		{
			if (!(item is _0023_003DzA6hSOxR6Wul9LBkHyO8His8_003D _0023_003DzA6hSOxR6Wul9LBkHyO8His8_003D2))
			{
				continue;
			}
			List<_0023_003DzW8zZzhCUviR_0024> _0023_003DzcDEsV8s_003D = new List<_0023_003DzW8zZzhCUviR_0024>();
			_0023_003DzA6hSOxR6Wul9LBkHyO8His8_003D2._0023_003Dz0WeocAQ_003D(ref _0023_003DzcDEsV8s_003D);
			if (_0023_003DzcDEsV8s_003D.Count <= 0)
			{
				continue;
			}
			foreach (_0023_003DzW8zZzhCUviR_0024 item2 in _0023_003DzcDEsV8s_003D)
			{
				if (item2._0023_003DzTyy4_1TcvpZp())
				{
					_0023_003DzgjkdNj6Exo1g = item2._0023_003Dzq1yEAPmOKQgq();
				}
			}
		}
	}

	public void _0023_003Dz0aNZGVr8fjLT(ref _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzM0hK0I8ZSshU, ref List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003Dzs_0024KWQ4WSnUa9)
	{
		_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D _0023_003Dzcoe2_tewkWc = new _0023_003DzSwNzCUSMkuVSrWhDng_003D_003D();
		if (_0023_003Dzb99xLb_0024r9MP8qdgr6A_003D_003D.Count > 0)
		{
			if (_0023_003DzzEe3qdoUVj8l4V78d93K1ps_003D != null && _0023_003DzzEe3qdoUVj8l4V78d93K1ps_003D.Count > 0)
			{
				List<_0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D> _0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D = new List<_0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D>();
				_0023_003DzCN_Q5PCPRRzylY6TZs5PegKml7BIEkr1Bg_003D_003D(_0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D);
				_0023_003DzBq5cSTMdhlT9._0023_003Dz7dPSEBm0Rxr0YjSwOg_003D_003D = _0023_003DzmaY4VTFGWE5ttwe9ahplwaI_003D(_0023_003Dzb99xLb_0024r9MP8qdgr6A_003D_003D, _0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D);
			}
			_0023_003DzouoHX8YvRfpwmdYu4g_003D_003D(_0023_003Dzb99xLb_0024r9MP8qdgr6A_003D_003D, _0023_003Dzs_0024KWQ4WSnUa9, _0023_003DzE4pCHfVSrHtv, _0023_003DzwgOXK31uw2p6M8QC7Q_003D_003D);
			_0023_003DzYB6xX4Pxdbmx8GomuA_003D_003D(_0023_003Dzcoe2_tewkWc, _0023_003Dzs_0024KWQ4WSnUa9, _0023_003Dzb99xLb_0024r9MP8qdgr6A_003D_003D);
			_0023_003DzP9drcrcAYTb8(ref _0023_003DzM0hK0I8ZSshU, _0023_003Dzcoe2_tewkWc, _0023_003Dzs_0024KWQ4WSnUa9);
			_0023_003DzaQTO_4E_003D(ref _0023_003Dzs_0024KWQ4WSnUa9, _0023_003Dz_bJZY76vDcwlGCIgGA_003D_003D);
			_0023_003DznH6e08sFrmsWB0kB2w_003D_003D();
		}
		else if (_0023_003DziVG7fzQMidan.Count > 0 && _0023_003DzlOP6VaMU1vkU.Count > 1)
		{
			_0023_003DzouoHX8YvRfpwmdYu4g_003D_003D(_0023_003Dzs_0024KWQ4WSnUa9, _0023_003DzE4pCHfVSrHtv, _0023_003DzwgOXK31uw2p6M8QC7Q_003D_003D);
			_0023_003DzYB6xX4Pxdbmx8GomuA_003D_003D(_0023_003Dzcoe2_tewkWc, _0023_003Dzs_0024KWQ4WSnUa9, _0023_003DziVG7fzQMidan);
			_0023_003DzP9drcrcAYTb8(ref _0023_003DzM0hK0I8ZSshU, _0023_003Dzcoe2_tewkWc, _0023_003Dzs_0024KWQ4WSnUa9);
			_0023_003DzaQTO_4E_003D(ref _0023_003Dzs_0024KWQ4WSnUa9, _0023_003Dz_bJZY76vDcwlGCIgGA_003D_003D);
			_0023_003DznH6e08sFrmsWB0kB2w_003D_003D();
		}
		else if (_0023_003DziRRId2HNt0NygOhl5wX35Ew_003D.Count > 0 || _0023_003Dzacu0aYQFX8et1UdPbQ_003D_003D.Count > 0 || _0023_003DzLwWu5qutzior5d8WvYp77qw_003D.Count > 0)
		{
			_0023_003DzouoHX8YvRfpwmdYu4g_003D_003D(_0023_003Dzb99xLb_0024r9MP8qdgr6A_003D_003D, _0023_003Dzs_0024KWQ4WSnUa9, _0023_003DzE4pCHfVSrHtv, _0023_003DzwgOXK31uw2p6M8QC7Q_003D_003D);
			_0023_003DzaQTO_4E_003D(ref _0023_003Dzs_0024KWQ4WSnUa9, _0023_003Dz_bJZY76vDcwlGCIgGA_003D_003D);
			_0023_003DznH6e08sFrmsWB0kB2w_003D_003D();
		}
	}

	private bool _0023_003DzmaY4VTFGWE5ttwe9ahplwaI_003D(List<_0023_003DzUTPND_0024PaoLcT45gigpwkrAY_003D> _0023_003DznuekdtIHJg5l, List<_0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D> _0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D)
	{
		bool result = false;
		if (_0023_003DzzEe3qdoUVj8l4V78d93K1ps_003D != null)
		{
			foreach (_0023_003DznsjBPaTUABFe8okkLB4jM_EmBrbb item in _0023_003DzzEe3qdoUVj8l4V78d93K1ps_003D)
			{
				_0023_003Dzjl_lT5RDLJuZp1ZdI5Sk9CA_003D _0023_003Dz84KwATjmsHCrNInHqg_003D_003D = item._0023_003Dz84KwATjmsHCrNInHqg_003D_003D;
				if (_0023_003Dz84KwATjmsHCrNInHqg_003D_003D == null)
				{
					continue;
				}
				_0023_003DzBkRUjdfBubiQ6AtzDJO3GqP0hamB _0023_003Dzvf4IVQQf9FW4VgFctK_3Hi4_003D = _0023_003Dz84KwATjmsHCrNInHqg_003D_003D._0023_003Dzvf4IVQQf9FW4VgFctK_3Hi4_003D;
				if (_0023_003Dzvf4IVQQf9FW4VgFctK_3Hi4_003D == null)
				{
					continue;
				}
				_0023_003DzemlTiYWC36sO_0024NbVtg_003D_003D _0023_003DzXsZKUDzXNfOYX1y4VA_003D_003D = _0023_003Dzvf4IVQQf9FW4VgFctK_3Hi4_003D._0023_003DzXsZKUDzXNfOYX1y4VA_003D_003D;
				if (_0023_003DzXsZKUDzXNfOYX1y4VA_003D_003D == null || _0023_003DzO4U4mvqphKeAeRsVuA_003D_003D(_0023_003DzXsZKUDzXNfOYX1y4VA_003D_003D._0023_003DzkXQ_IWk_003D))
				{
					continue;
				}
				int num = _0023_003DzvANFRWRQTUBJIhNg_5zxLNI_003D(_0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D, _0023_003DzXsZKUDzXNfOYX1y4VA_003D_003D._0023_003DzkXQ_IWk_003D);
				foreach (_0023_003DzUTPND_0024PaoLcT45gigpwkrAY_003D item2 in _0023_003DznuekdtIHJg5l)
				{
					if (item2._0023_003DzclvzG0shJ5rHj6WXbQ_003D_003D() == num)
					{
						result = true;
						break;
					}
					if (item2._0023_003DzNNfjEv0NSylI0lqZBw_003D_003D() == num)
					{
						break;
					}
				}
				break;
			}
		}
		return result;
	}

	private int _0023_003DzvANFRWRQTUBJIhNg_5zxLNI_003D(List<_0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D> _0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D, int _0023_003DzOhplMuy4MHe7)
	{
		int result = -1;
		foreach (_0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D item in _0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D)
		{
			if (item._0023_003Dz84KwATjmsHCrNInHqg_003D_003D != null)
			{
				if (item._0023_003Dz84KwATjmsHCrNInHqg_003D_003D._0023_003Dz4h89SpjJsmqnhfZLgQ_003D_003D != null && item._0023_003Dz84KwATjmsHCrNInHqg_003D_003D._0023_003Dz4h89SpjJsmqnhfZLgQ_003D_003D._0023_003DzkXQ_IWk_003D == _0023_003DzOhplMuy4MHe7 && item._0023_003DzKhlUT1unKe_0024S != null)
				{
					result = item._0023_003DzKhlUT1unKe_0024S._0023_003DzkXQ_IWk_003D;
					break;
				}
			}
			else if (item._0023_003DzVOQvJ8rK11ua != null && item._0023_003DzVOQvJ8rK11ua._0023_003DzKbhWsdQJWQWL != null && item._0023_003DzVOQvJ8rK11ua._0023_003DzKbhWsdQJWQWL._0023_003DzkZhwhdTO59MoGIzcsA_003D_003D != null && item._0023_003DzVOQvJ8rK11ua._0023_003DzKbhWsdQJWQWL._0023_003DzkZhwhdTO59MoGIzcsA_003D_003D._0023_003Dz4h89SpjJsmqnhfZLgQ_003D_003D != null && item._0023_003DzVOQvJ8rK11ua._0023_003DzKbhWsdQJWQWL._0023_003DzkZhwhdTO59MoGIzcsA_003D_003D._0023_003Dz4h89SpjJsmqnhfZLgQ_003D_003D._0023_003DzkXQ_IWk_003D == _0023_003DzOhplMuy4MHe7)
			{
				result = item._0023_003DzKhlUT1unKe_0024S._0023_003DzkXQ_IWk_003D;
				break;
			}
		}
		return result;
	}

	private bool _0023_003DzO4U4mvqphKeAeRsVuA_003D_003D(int _0023_003DzlOO_OaWD9reu)
	{
		bool result = false;
		if (_0023_003DzzEe3qdoUVj8l4V78d93K1ps_003D != null)
		{
			foreach (_0023_003DznsjBPaTUABFe8okkLB4jM_EmBrbb item in _0023_003DzzEe3qdoUVj8l4V78d93K1ps_003D)
			{
				_0023_003Dzjl_lT5RDLJuZp1ZdI5Sk9CA_003D _0023_003Dz84KwATjmsHCrNInHqg_003D_003D = item._0023_003Dz84KwATjmsHCrNInHqg_003D_003D;
				if (_0023_003Dz84KwATjmsHCrNInHqg_003D_003D == null)
				{
					continue;
				}
				_0023_003DzBkRUjdfBubiQ6AtzDJO3GqP0hamB _0023_003Dzvf4IVQQf9FW4VgFctK_3Hi4_003D = _0023_003Dz84KwATjmsHCrNInHqg_003D_003D._0023_003Dzvf4IVQQf9FW4VgFctK_3Hi4_003D;
				if (_0023_003Dzvf4IVQQf9FW4VgFctK_3Hi4_003D != null)
				{
					_0023_003DzemlTiYWC36sO_0024NbVtg_003D_003D _0023_003Dz78SDh92WGTrddwkJyw_003D_003D = _0023_003Dzvf4IVQQf9FW4VgFctK_3Hi4_003D._0023_003Dz78SDh92WGTrddwkJyw_003D_003D;
					if (_0023_003Dz78SDh92WGTrddwkJyw_003D_003D != null && _0023_003DzlOO_OaWD9reu == _0023_003Dz78SDh92WGTrddwkJyw_003D_003D._0023_003DzkXQ_IWk_003D)
					{
						result = true;
						break;
					}
				}
			}
		}
		return result;
	}

	private void _0023_003DznH6e08sFrmsWB0kB2w_003D_003D()
	{
		List<string> list = new List<string>();
		foreach (string key in _0023_003DzoeXiThQ_0024bV6dYFdB1w_003D_003D.Keys)
		{
			if (!_0023_003Dz_bJZY76vDcwlGCIgGA_003D_003D.TryGetValue(key, out var _))
			{
				list.Add(key);
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		foreach (string item in list)
		{
			_0023_003DzoeXiThQ_0024bV6dYFdB1w_003D_003D.Remove(item);
		}
	}

	public static void _0023_003DzaQTO_4E_003D(ref List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003Dzs_0024KWQ4WSnUa9, Dictionary<string, _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003DzQbNzklbZKPsu)
	{
		if (_0023_003Dzs_0024KWQ4WSnUa9 == null || _0023_003Dzs_0024KWQ4WSnUa9.Count <= 0)
		{
			return;
		}
		bool flag = false;
		List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> list = new List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D>();
		foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item in _0023_003Dzs_0024KWQ4WSnUa9)
		{
			if (_0023_003DzmNBYS778gALc(item))
			{
				list.Add(item);
				continue;
			}
			_0023_003DzQbNzklbZKPsu.Remove(item._0023_003DzwKyKajk_003D());
			flag = true;
		}
		if (flag)
		{
			_0023_003Dzjr4L_kPldnrX(list, _0023_003DzQbNzklbZKPsu);
		}
		_0023_003Dzs_0024KWQ4WSnUa9 = list;
	}

	public static bool _0023_003DzmNBYS778gALc(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzLeyHB00_003D)
	{
		if (_0023_003DzLeyHB00_003D._0023_003DzvMlCLpDtkWKK.Count > 0 || _0023_003DzLeyHB00_003D._0023_003Dz0SpZWCCz_qrn.Count > 0 || _0023_003DzLeyHB00_003D._0023_003Dz6s4PD7bzjby3pa5Oc9DAJ_00240_003D.Count > 0 || _0023_003DzLeyHB00_003D._0023_003Dzh6YNBZo_003D.Count > 0 || _0023_003DzLeyHB00_003D._0023_003Dzj3ms8um3cUs7ghjFng_003D_003D.Count > 0 || _0023_003DzLeyHB00_003D._0023_003DzjaTJk2miWWCuYJkH8Uxb9yE_003D.Count > 0)
		{
			return true;
		}
		return false;
	}

	private static void _0023_003Dzjr4L_kPldnrX(List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003DznAF4fNkMjAgi, Dictionary<string, _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003DzQbNzklbZKPsu)
	{
		List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> list = new List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D>();
		foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item in _0023_003DznAF4fNkMjAgi)
		{
			if (item._0023_003DzvMlCLpDtkWKK == null || item._0023_003DzvMlCLpDtkWKK.Count <= 0)
			{
				continue;
			}
			List<_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D> list2 = new List<_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D>();
			foreach (_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D item2 in item._0023_003DzvMlCLpDtkWKK)
			{
				if (!_0023_003DzQbNzklbZKPsu.TryGetValue(item2._0023_003Dz7dWp4YQ_003D(), out var _))
				{
					list2.Add(item2);
				}
			}
			if (list2.Count > 0)
			{
				foreach (_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D item3 in list2)
				{
					item._0023_003DzvMlCLpDtkWKK.Remove(item3);
				}
			}
			if (!_0023_003DzmNBYS778gALc(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item4 in list)
		{
			_0023_003DznAF4fNkMjAgi.Remove(item4);
			_0023_003DzQbNzklbZKPsu.Remove(item4._0023_003DzwKyKajk_003D());
		}
		_0023_003Dzjr4L_kPldnrX(_0023_003DznAF4fNkMjAgi, _0023_003DzQbNzklbZKPsu);
	}

	public void _0023_003DzP9drcrcAYTb8(ref _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzM0hK0I8ZSshU, _0023_003DzSwNzCUSMkuVSrWhDng_003D_003D _0023_003Dzcoe2_tewkWc6, List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003Dzs_0024KWQ4WSnUa9)
	{
		foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item in _0023_003Dzs_0024KWQ4WSnUa9)
		{
			if (item._0023_003DzwKyKajk_003D() == _0023_003Dzcoe2_tewkWc6._0023_003Dz7dWp4YQ_003D())
			{
				_0023_003DzM0hK0I8ZSshU = item;
				_0023_003DzM0hK0I8ZSshU._0023_003Dzwtld1NM_003D = item._0023_003Dzwtld1NM_003D;
				break;
			}
		}
		foreach (_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D item2 in _0023_003DzM0hK0I8ZSshU._0023_003DzvMlCLpDtkWKK)
		{
			foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item3 in _0023_003Dzs_0024KWQ4WSnUa9)
			{
				if (item2._0023_003Dz7dWp4YQ_003D() == item3._0023_003DzwKyKajk_003D())
				{
					_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2 = new _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D();
					_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzvMlCLpDtkWKK = item3._0023_003DzvMlCLpDtkWKK;
					_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003Dzh6YNBZo_003D = item3._0023_003Dzh6YNBZo_003D;
					_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzyZFnD3E_003D(item3._0023_003DzwKyKajk_003D());
					_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003Dz0SpZWCCz_qrn = item3._0023_003Dz0SpZWCCz_qrn;
					_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003Dzwtld1NM_003D = item3._0023_003Dzwtld1NM_003D;
					if (_0023_003DzJhzE5gUExlKn(_0023_003DzM0hK0I8ZSshU._0023_003Dz_0024tsMtQo_003D, _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzwKyKajk_003D()))
					{
						_0023_003DzM0hK0I8ZSshU._0023_003Dz_0024tsMtQo_003D.Add(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2);
					}
					if (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzvMlCLpDtkWKK.Count > 0)
					{
						_0023_003DzthGWVlZA3x3bVXTO2Q_003D_003D(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2, _0023_003Dzs_0024KWQ4WSnUa9);
					}
				}
			}
		}
	}

	private void _0023_003DzthGWVlZA3x3bVXTO2Q_003D_003D(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzR01N9Pk_003D, List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003Dzs_0024KWQ4WSnUa9)
	{
		foreach (_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D item in _0023_003DzR01N9Pk_003D._0023_003DzvMlCLpDtkWKK)
		{
			foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item2 in _0023_003Dzs_0024KWQ4WSnUa9)
			{
				if (!(item._0023_003Dz7dWp4YQ_003D() == item2._0023_003DzwKyKajk_003D()))
				{
					continue;
				}
				_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2 = new _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D();
				_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzvMlCLpDtkWKK = item2._0023_003DzvMlCLpDtkWKK;
				_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003Dzh6YNBZo_003D = item2._0023_003Dzh6YNBZo_003D;
				_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzyZFnD3E_003D(item2._0023_003DzwKyKajk_003D());
				_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003Dz0SpZWCCz_qrn = item2._0023_003Dz0SpZWCCz_qrn;
				_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003Dzwtld1NM_003D = item2._0023_003Dzwtld1NM_003D;
				if (_0023_003DzJhzE5gUExlKn(_0023_003DzR01N9Pk_003D._0023_003Dz_0024tsMtQo_003D, _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzwKyKajk_003D()))
				{
					_0023_003DzR01N9Pk_003D._0023_003Dz_0024tsMtQo_003D.Add(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2);
				}
				foreach (_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D item3 in _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzvMlCLpDtkWKK)
				{
					foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item4 in _0023_003Dzs_0024KWQ4WSnUa9)
					{
						if (item3._0023_003Dz7dWp4YQ_003D() == item4._0023_003DzwKyKajk_003D())
						{
							_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D3 = new _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D();
							_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D3._0023_003DzvMlCLpDtkWKK = item4._0023_003DzvMlCLpDtkWKK;
							_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D3._0023_003Dzh6YNBZo_003D = item4._0023_003Dzh6YNBZo_003D;
							_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D3._0023_003DzyZFnD3E_003D(item4._0023_003DzwKyKajk_003D());
							_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D3._0023_003Dz0SpZWCCz_qrn = item4._0023_003Dz0SpZWCCz_qrn;
							_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D3._0023_003Dzwtld1NM_003D = item4._0023_003Dzwtld1NM_003D;
							if (_0023_003DzJhzE5gUExlKn(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003Dz_0024tsMtQo_003D, _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D3._0023_003DzwKyKajk_003D()))
							{
								_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003Dz_0024tsMtQo_003D.Add(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D3);
							}
							if (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D3._0023_003DzvMlCLpDtkWKK.Count > 0)
							{
								_0023_003DzthGWVlZA3x3bVXTO2Q_003D_003D(_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D3, _0023_003Dzs_0024KWQ4WSnUa9);
							}
						}
					}
				}
			}
		}
	}

	private bool _0023_003DzJhzE5gUExlKn(List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003Dzs_0024KWQ4WSnUa9, string _0023_003DznkMU43c_003D)
	{
		foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item in _0023_003Dzs_0024KWQ4WSnUa9)
		{
			if (item._0023_003DzwKyKajk_003D() == _0023_003DznkMU43c_003D)
			{
				return false;
			}
		}
		return true;
	}

	private void _0023_003DzYB6xX4Pxdbmx8GomuA_003D_003D(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D _0023_003Dzcoe2_tewkWc6, List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003DzsSVpuMepYZud, List<_0023_003DzUTPND_0024PaoLcT45gigpwkrAY_003D> _0023_003DzSH23NwFiLyAJ)
	{
		if (_0023_003DzSH23NwFiLyAJ.Count > 0)
		{
			foreach (KeyValuePair<string, _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> item in _0023_003Dz_bJZY76vDcwlGCIgGA_003D_003D)
			{
				_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D value = item.Value;
				if (!value._0023_003DzSxKSyExlVAOd() && value._0023_003DzvMlCLpDtkWKK.Count > 0)
				{
					_0023_003Dzcoe2_tewkWc6._0023_003Dz8oO_z_0024d8gNK7 = value._0023_003DzwKyKajk_003D();
				}
			}
			return;
		}
		foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item2 in _0023_003DzsSVpuMepYZud)
		{
			_0023_003Dzcoe2_tewkWc6._0023_003Dz8oO_z_0024d8gNK7 = item2._0023_003DzwKyKajk_003D();
		}
	}

	private void _0023_003DzYB6xX4Pxdbmx8GomuA_003D_003D(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D _0023_003Dzcoe2_tewkWc6, List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003DzsSVpuMepYZud, List<_0023_003Dz8M8UlaItmjTo_EcR1w_003D_003D> _0023_003DzSH23NwFiLyAJ)
	{
		if (_0023_003DzSH23NwFiLyAJ.Count > 0)
		{
			foreach (string key in _0023_003Dz_bJZY76vDcwlGCIgGA_003D_003D.Keys)
			{
				_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2 = _0023_003Dz_bJZY76vDcwlGCIgGA_003D_003D[key];
				if (!_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzSxKSyExlVAOd())
				{
					_0023_003Dzcoe2_tewkWc6._0023_003Dz8oO_z_0024d8gNK7 = _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzwKyKajk_003D();
				}
			}
			return;
		}
		foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item in _0023_003DzsSVpuMepYZud)
		{
			_0023_003Dzcoe2_tewkWc6._0023_003Dz8oO_z_0024d8gNK7 = item._0023_003DzwKyKajk_003D();
		}
	}

	private void _0023_003DzouoHX8YvRfpwmdYu4g_003D_003D(List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003DzsSVpuMepYZud, List<_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D> _0023_003DzbWocV7wXlk2P, List<_0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D> _0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D)
	{
		foreach (_0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D item in _0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D)
		{
			_0023_003DzmwEee3fUKhueUmNzTcE5YdHZjRJM _0023_003DzZOuko1840Cwyjmv91xpUjjI_003D = item._0023_003DzZOuko1840Cwyjmv91xpUjjI_003D;
			if (_0023_003DzZOuko1840Cwyjmv91xpUjjI_003D == null || _0023_003DzZOuko1840Cwyjmv91xpUjjI_003D._0023_003DzvfKpuZVU46uw.Count <= 0)
			{
				continue;
			}
			foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item2 in _0023_003DzsSVpuMepYZud)
			{
				if (_0023_003DzoeXiThQ_0024bV6dYFdB1w_003D_003D[item2._0023_003DzwKyKajk_003D()] != _0023_003DzZOuko1840Cwyjmv91xpUjjI_003D._0023_003DzkXQ_IWk_003D)
				{
					continue;
				}
				foreach (_0023_003Dz8M8UlaItmjTo_EcR1w_003D_003D item3 in _0023_003DzZOuko1840Cwyjmv91xpUjjI_003D._0023_003DzvfKpuZVU46uw)
				{
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D _0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2 = new _0023_003DzSwNzCUSMkuVSrWhDng_003D_003D();
					_0023_003DzWI_00246Yk1HGU_00240C_0024OPBA_003D_003D _0023_003DzmL6MYR21EsbWgXJ5pEv2kIIk7FDq = item3._0023_003DzmL6MYR21EsbWgXJ5pEv2kIIk7FDq;
					_0023_003DzmwEee3fUKhueUmNzTcE5YdHZjRJM _0023_003DzxR9_0024Kdkc8fWEM01J3E2sCEs_003D = _0023_003DzmL6MYR21EsbWgXJ5pEv2kIIk7FDq._0023_003DzxR9_0024Kdkc8fWEM01J3E2sCEs_003D;
					int _0023_003DzHcDdAHhUjvgJ = -1;
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003Dz8oO_z_0024d8gNK7 = _0023_003Dz501_0024J5eugueO67AOhQ_003D_003D(_0023_003DzxR9_0024Kdkc8fWEM01J3E2sCEs_003D._0023_003DzkXQ_IWk_003D, _0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D, ref _0023_003DzHcDdAHhUjvgJ);
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003DzY1QRy9wZxv4J = _0023_003DzxR9_0024Kdkc8fWEM01J3E2sCEs_003D._0023_003DzkXQ_IWk_003D;
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003DzVA0NQpw_003D = _0023_003DzHcDdAHhUjvgJ;
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003DzcZAIRzdqjLL3(_0023_003DzxR9_0024Kdkc8fWEM01J3E2sCEs_003D._0023_003DzS_00246o7tc_003D);
					if (_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003Dz4pmQ5h06_Snm().Trim() == string.Empty)
					{
						_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003DzcZAIRzdqjLL3(_0023_003DzHnsr_fDnno5vEnkLuQ_003D_003D(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2));
					}
					double[] _0023_003DzB65HsyI_003D = item3._0023_003Dz9AZ9H7drO_0024Yi._0023_003DzCGTSeY0_003D._0023_003Dzfj_WbJ59_mOa();
					double[] _0023_003DzqdOG1COev7La = item3._0023_003Dz9AZ9H7drO_0024Yi._0023_003Dz1_0024d_00248flwjiOW._0023_003DzqdOG1COev7La;
					double[] _0023_003DzqdOG1COev7La2 = item3._0023_003Dz9AZ9H7drO_0024Yi._0023_003DzHwk42AaBD9wG._0023_003DzqdOG1COev7La;
					double[] _0023_003DzjRTUPbA_003D = _0023_003DzmL6MYR21EsbWgXJ5pEv2kIIk7FDq._0023_003Dz9AZ9H7drO_0024Yi._0023_003DzCGTSeY0_003D._0023_003Dzfj_WbJ59_mOa();
					double[] _0023_003DzqdOG1COev7La3 = _0023_003DzmL6MYR21EsbWgXJ5pEv2kIIk7FDq._0023_003Dz9AZ9H7drO_0024Yi._0023_003Dz1_0024d_00248flwjiOW._0023_003DzqdOG1COev7La;
					double[] _0023_003DzqdOG1COev7La4 = _0023_003DzmL6MYR21EsbWgXJ5pEv2kIIk7FDq._0023_003Dz9AZ9H7drO_0024Yi._0023_003DzHwk42AaBD9wG._0023_003DzqdOG1COev7La;
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003DzXjOCl3g_003D(_0023_003DzB65HsyI_003D, _0023_003DzqdOG1COev7La, _0023_003DzqdOG1COev7La2, _0023_003DzjRTUPbA_003D, _0023_003DzqdOG1COev7La3, _0023_003DzqdOG1COev7La4);
					item2._0023_003DzvMlCLpDtkWKK.Add(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2);
					_0023_003DzbWocV7wXlk2P.Add(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2);
					_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2 = _0023_003Dz_bJZY76vDcwlGCIgGA_003D_003D[_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003Dz8oO_z_0024d8gNK7];
					if (!_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzSxKSyExlVAOd())
					{
						_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzszASiwEOY4IH(_0023_003DzPzO_0024GUk_003D: true);
					}
				}
			}
		}
	}

	private void _0023_003DzouoHX8YvRfpwmdYu4g_003D_003D(List<_0023_003DzUTPND_0024PaoLcT45gigpwkrAY_003D> _0023_003DzSH23NwFiLyAJ, List<_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D> _0023_003DzsSVpuMepYZud, List<_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D> _0023_003DzbWocV7wXlk2P, List<_0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D> _0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D)
	{
		if (!_0023_003DzBq5cSTMdhlT9._0023_003Dz7dPSEBm0Rxr0YjSwOg_003D_003D)
		{
			foreach (_0023_003DzUTPND_0024PaoLcT45gigpwkrAY_003D item in _0023_003DzSH23NwFiLyAJ)
			{
				foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item2 in _0023_003DzsSVpuMepYZud)
				{
					int num = _0023_003DzoeXiThQ_0024bV6dYFdB1w_003D_003D[item2._0023_003DzwKyKajk_003D()];
					if (item._0023_003DzNNfjEv0NSylI0lqZBw_003D_003D() != num)
					{
						continue;
					}
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D _0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2 = new _0023_003DzSwNzCUSMkuVSrWhDng_003D_003D();
					int _0023_003DzHcDdAHhUjvgJ = -1;
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003Dz8oO_z_0024d8gNK7 = _0023_003Dz501_0024J5eugueO67AOhQ_003D_003D(item._0023_003DzclvzG0shJ5rHj6WXbQ_003D_003D(), _0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D, ref _0023_003DzHcDdAHhUjvgJ);
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003DzY1QRy9wZxv4J = item._0023_003DzclvzG0shJ5rHj6WXbQ_003D_003D();
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003DzVA0NQpw_003D = item2._0023_003DzVA0NQpw_003D;
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003DzcZAIRzdqjLL3(_0023_003Dz0Q99_6LxfzShtem_00241w_003D_003D(item._0023_003DzkXQ_IWk_003D));
					if (_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003Dz4pmQ5h06_Snm().Trim() == string.Empty)
					{
						_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003DzcZAIRzdqjLL3(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003Dz8oO_z_0024d8gNK7);
					}
					try
					{
						_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003DzcZAIRzdqjLL3(_0023_003DzHnsr_fDnno5vEnkLuQ_003D_003D(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2));
						double[] _0023_003DzB65HsyI_003D = item._0023_003DzuWAbnpH4azwPp_FR_0024w_003D_003D()._0023_003DzBe_0024nQCB_0024uHrX._0023_003DzCGTSeY0_003D._0023_003Dzfj_WbJ59_mOa();
						double[] _0023_003DzqdOG1COev7La = item._0023_003DzuWAbnpH4azwPp_FR_0024w_003D_003D()._0023_003DzBe_0024nQCB_0024uHrX._0023_003Dz1_0024d_00248flwjiOW._0023_003DzqdOG1COev7La;
						double[] _0023_003DzqdOG1COev7La2 = item._0023_003DzuWAbnpH4azwPp_FR_0024w_003D_003D()._0023_003DzBe_0024nQCB_0024uHrX._0023_003DzHwk42AaBD9wG._0023_003DzqdOG1COev7La;
						double[] _0023_003DzjRTUPbA_003D = item._0023_003DzuWAbnpH4azwPp_FR_0024w_003D_003D()._0023_003Dzlo7hYAwmtsrQG2_efQ_003D_003D._0023_003DzCGTSeY0_003D._0023_003Dzfj_WbJ59_mOa();
						double[] _0023_003DzqdOG1COev7La3 = item._0023_003DzuWAbnpH4azwPp_FR_0024w_003D_003D()._0023_003Dzlo7hYAwmtsrQG2_efQ_003D_003D._0023_003Dz1_0024d_00248flwjiOW._0023_003DzqdOG1COev7La;
						double[] _0023_003DzqdOG1COev7La4 = item._0023_003DzuWAbnpH4azwPp_FR_0024w_003D_003D()._0023_003Dzlo7hYAwmtsrQG2_efQ_003D_003D._0023_003DzHwk42AaBD9wG._0023_003DzqdOG1COev7La;
						_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003DzXjOCl3g_003D(_0023_003DzB65HsyI_003D, _0023_003DzqdOG1COev7La, _0023_003DzqdOG1COev7La2, _0023_003DzjRTUPbA_003D, _0023_003DzqdOG1COev7La3, _0023_003DzqdOG1COev7La4);
						item2._0023_003DzvMlCLpDtkWKK.Add(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2);
						_0023_003DzbWocV7wXlk2P.Add(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2);
						_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2 = _0023_003Dz_bJZY76vDcwlGCIgGA_003D_003D[_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003Dz8oO_z_0024d8gNK7];
						_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003DzDSV3KvHUSDa4 = _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzDSV3KvHUSDa4;
						_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D2._0023_003DzrdvTjeaFTRlY = _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzrdvTjeaFTRlY;
						if (!_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzSxKSyExlVAOd())
						{
							_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzszASiwEOY4IH(_0023_003DzPzO_0024GUk_003D: true);
						}
					}
					catch (Exception)
					{
						_0023_003DzqmF8XJ0_003D.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302928153));
					}
				}
			}
		}
		if (!_0023_003DzBq5cSTMdhlT9._0023_003Dz7dPSEBm0Rxr0YjSwOg_003D_003D)
		{
			return;
		}
		foreach (_0023_003DzUTPND_0024PaoLcT45gigpwkrAY_003D item3 in _0023_003DzSH23NwFiLyAJ)
		{
			foreach (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D item4 in _0023_003DzsSVpuMepYZud)
			{
				int num2 = _0023_003DzoeXiThQ_0024bV6dYFdB1w_003D_003D[item4._0023_003DzwKyKajk_003D()];
				if (item3._0023_003DzclvzG0shJ5rHj6WXbQ_003D_003D() != num2)
				{
					continue;
				}
				_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D _0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3 = new _0023_003DzSwNzCUSMkuVSrWhDng_003D_003D();
				int _0023_003DzHcDdAHhUjvgJ2 = -1;
				_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3._0023_003Dz8oO_z_0024d8gNK7 = _0023_003Dz501_0024J5eugueO67AOhQ_003D_003D(item3._0023_003DzNNfjEv0NSylI0lqZBw_003D_003D(), _0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D, ref _0023_003DzHcDdAHhUjvgJ2);
				if (!string.IsNullOrEmpty(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3._0023_003Dz8oO_z_0024d8gNK7))
				{
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3._0023_003DzY1QRy9wZxv4J = item3._0023_003DzNNfjEv0NSylI0lqZBw_003D_003D();
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3._0023_003DzVA0NQpw_003D = _0023_003DzHcDdAHhUjvgJ2;
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3._0023_003DzcZAIRzdqjLL3(_0023_003Dz0Q99_6LxfzShtem_00241w_003D_003D(item3._0023_003DzkXQ_IWk_003D));
					if (_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3._0023_003Dz4pmQ5h06_Snm().Trim() == string.Empty)
					{
						_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3._0023_003DzcZAIRzdqjLL3(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3._0023_003Dz8oO_z_0024d8gNK7);
					}
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3._0023_003DzcZAIRzdqjLL3(_0023_003DzHnsr_fDnno5vEnkLuQ_003D_003D(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3));
					double[] _0023_003DzjRTUPbA_003D2 = item3._0023_003DzuWAbnpH4azwPp_FR_0024w_003D_003D()._0023_003DzBe_0024nQCB_0024uHrX._0023_003DzCGTSeY0_003D._0023_003Dzfj_WbJ59_mOa();
					double[] _0023_003DzqdOG1COev7La5 = item3._0023_003DzuWAbnpH4azwPp_FR_0024w_003D_003D()._0023_003DzBe_0024nQCB_0024uHrX._0023_003Dz1_0024d_00248flwjiOW._0023_003DzqdOG1COev7La;
					double[] _0023_003DzqdOG1COev7La6 = item3._0023_003DzuWAbnpH4azwPp_FR_0024w_003D_003D()._0023_003DzBe_0024nQCB_0024uHrX._0023_003DzHwk42AaBD9wG._0023_003DzqdOG1COev7La;
					double[] _0023_003DzB65HsyI_003D2 = item3._0023_003DzuWAbnpH4azwPp_FR_0024w_003D_003D()._0023_003Dzlo7hYAwmtsrQG2_efQ_003D_003D._0023_003DzCGTSeY0_003D._0023_003Dzfj_WbJ59_mOa();
					double[] _0023_003DzqdOG1COev7La7 = item3._0023_003DzuWAbnpH4azwPp_FR_0024w_003D_003D()._0023_003Dzlo7hYAwmtsrQG2_efQ_003D_003D._0023_003Dz1_0024d_00248flwjiOW._0023_003DzqdOG1COev7La;
					double[] _0023_003DzqdOG1COev7La8 = item3._0023_003DzuWAbnpH4azwPp_FR_0024w_003D_003D()._0023_003Dzlo7hYAwmtsrQG2_efQ_003D_003D._0023_003DzHwk42AaBD9wG._0023_003DzqdOG1COev7La;
					_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3._0023_003DzXjOCl3g_003D(_0023_003DzB65HsyI_003D2, _0023_003DzqdOG1COev7La7, _0023_003DzqdOG1COev7La8, _0023_003DzjRTUPbA_003D2, _0023_003DzqdOG1COev7La5, _0023_003DzqdOG1COev7La6);
					item4._0023_003DzvMlCLpDtkWKK.Add(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3);
					_0023_003DzbWocV7wXlk2P.Add(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3);
					_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D3 = _0023_003Dz_bJZY76vDcwlGCIgGA_003D_003D[_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3._0023_003Dz8oO_z_0024d8gNK7];
					if (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D3 != null)
					{
						_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3._0023_003DzDSV3KvHUSDa4 = _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D3._0023_003DzDSV3KvHUSDa4;
						_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D3._0023_003DzrdvTjeaFTRlY = _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D3._0023_003DzrdvTjeaFTRlY;
						_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D3._0023_003DzszASiwEOY4IH(_0023_003DzPzO_0024GUk_003D: true);
					}
				}
			}
		}
	}

	private string _0023_003Dz501_0024J5eugueO67AOhQ_003D_003D(int _0023_003DzoH9_0024SmM_003D, List<_0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D> _0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D, ref int _0023_003DzHcDdAHhUjvgJ)
	{
		foreach (_0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D item in _0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D)
		{
			_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 = null;
			if (item._0023_003DzKhlUT1unKe_0024S != null)
			{
				_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 = item._0023_003DzKhlUT1unKe_0024S;
			}
			else if (item._0023_003DzZOuko1840Cwyjmv91xpUjjI_003D != null)
			{
				_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 = item._0023_003DzZOuko1840Cwyjmv91xpUjjI_003D;
			}
			else if (item._0023_003DzUfFDoQuH0SAmGE7Rb1miHokuulVx != null)
			{
				_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 = item._0023_003DzUfFDoQuH0SAmGE7Rb1miHokuulVx;
			}
			else if (item._0023_003DzlZD_hylEX450cUP_D6BBkaALJTzU != null)
			{
				_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 = item._0023_003DzlZD_hylEX450cUP_D6BBkaALJTzU;
			}
			else if (item._0023_003Dzrr53uPSSHlyaNG6tISqKaF0_003D != null)
			{
				_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 = item._0023_003Dzrr53uPSSHlyaNG6tISqKaF0_003D;
			}
			else if (item._0023_003DzGb1ouzt7VNkoxHwM5hEd03OuZeog4Dc8Xg_003D_003D != null)
			{
				_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 = item._0023_003DzGb1ouzt7VNkoxHwM5hEd03OuZeog4Dc8Xg_003D_003D;
			}
			if (_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2 == null || _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D2._0023_003DzkXQ_IWk_003D != _0023_003DzoH9_0024SmM_003D)
			{
				continue;
			}
			_0023_003Dzjl_lT5RDLJuZp1ZdI5Sk9CA_003D _0023_003Dz84KwATjmsHCrNInHqg_003D_003D = item._0023_003Dz84KwATjmsHCrNInHqg_003D_003D;
			if (_0023_003Dz84KwATjmsHCrNInHqg_003D_003D == null)
			{
				continue;
			}
			_0023_003DzemlTiYWC36sO_0024NbVtg_003D_003D _0023_003Dz4h89SpjJsmqnhfZLgQ_003D_003D = _0023_003Dz84KwATjmsHCrNInHqg_003D_003D._0023_003Dz4h89SpjJsmqnhfZLgQ_003D_003D;
			_0023_003DzWeLcFNnq3Jd9ST_rNz_diLr6zZy4 _0023_003DzZ3QlhPdVqw9why6QP68y2y0_003D = _0023_003Dz84KwATjmsHCrNInHqg_003D_003D._0023_003DzZ3QlhPdVqw9why6QP68y2y0_003D;
			if (_0023_003Dz4h89SpjJsmqnhfZLgQ_003D_003D != null)
			{
				_0023_003DzXVg_o8eXCN5urKlG3c_AHLJ6Q9GB _0023_003DzxmmtKwaHH_Gx5hWsqsr1_wo_003D = _0023_003Dz4h89SpjJsmqnhfZLgQ_003D_003D._0023_003DzxmmtKwaHH_Gx5hWsqsr1_wo_003D;
				if (_0023_003DzxmmtKwaHH_Gx5hWsqsr1_wo_003D != null)
				{
					_0023_003DzYiQuDIbIKeJ_MKZwJg_003D_003D _0023_003DzVAfW3FkxHlvz = _0023_003DzxmmtKwaHH_Gx5hWsqsr1_wo_003D._0023_003DzVAfW3FkxHlvz;
					if (_0023_003DzVAfW3FkxHlvz != null)
					{
						_0023_003DzHcDdAHhUjvgJ = _0023_003DzVAfW3FkxHlvz._0023_003DzkXQ_IWk_003D;
						return _0023_003Dz0jS_RxOhV4vcV8_j1w_003D_003D(_0023_003DzHcDdAHhUjvgJ);
					}
				}
			}
			else
			{
				if (_0023_003DzZ3QlhPdVqw9why6QP68y2y0_003D == null)
				{
					continue;
				}
				_0023_003DzXVg_o8eXCN5urKlG3c_AHLJ6Q9GB _0023_003DzxmmtKwaHH_Gx5hWsqsr1_wo_003D2 = _0023_003DzZ3QlhPdVqw9why6QP68y2y0_003D._0023_003DzxmmtKwaHH_Gx5hWsqsr1_wo_003D;
				if (_0023_003DzxmmtKwaHH_Gx5hWsqsr1_wo_003D2 != null)
				{
					_0023_003DzYiQuDIbIKeJ_MKZwJg_003D_003D _0023_003DzVAfW3FkxHlvz2 = _0023_003DzxmmtKwaHH_Gx5hWsqsr1_wo_003D2._0023_003DzVAfW3FkxHlvz;
					if (_0023_003DzVAfW3FkxHlvz2 != null)
					{
						_0023_003DzHcDdAHhUjvgJ = _0023_003DzVAfW3FkxHlvz2._0023_003DzkXQ_IWk_003D;
						return _0023_003Dz0jS_RxOhV4vcV8_j1w_003D_003D(_0023_003DzHcDdAHhUjvgJ);
					}
				}
			}
		}
		return null;
	}

	private string _0023_003Dz0jS_RxOhV4vcV8_j1w_003D_003D(int _0023_003DzHcDdAHhUjvgJ)
	{
		string result = string.Empty;
		foreach (string key in _0023_003Dz_bJZY76vDcwlGCIgGA_003D_003D.Keys)
		{
			_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2 = _0023_003Dz_bJZY76vDcwlGCIgGA_003D_003D[key];
			if (_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2 != null && _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzVA0NQpw_003D == _0023_003DzHcDdAHhUjvgJ)
			{
				result = _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D2._0023_003DzwKyKajk_003D();
				break;
			}
		}
		return result;
	}

	private bool _0023_003DzKfSsmwLRzer8(StringCollection _0023_003DzcxcrDhg_003D)
	{
		bool result = false;
		_0023_003Dzu97QPYFcxmdi = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302928383);
		_0023_003DzBq5cSTMdhlT9 = new _0023_003DzdR99lgbR34Ip();
		_0023_003Dzw3_zM5Q_003D = new Dictionary<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D>();
		if (_0023_003DzBq5cSTMdhlT9._0023_003Dz4oHjx8Q_003D(_0023_003DzcxcrDhg_003D, this, ref _0023_003Dzw3_zM5Q_003D, ref _0023_003DzJjVQTzpKI4Ni, ref _0023_003Dzm4CSmX5Y3o6Q))
		{
			_0023_003DzjxWUtRTif70J();
			_0023_003DzgoyZECDmOlGR_0024XT_0024mg_003D_003D = new List<_0023_003DzzoqZ7r6_g11JF2TbYw_003D_003D>();
			foreach (_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D item in _0023_003DzBq5cSTMdhlT9._0023_003DzDA3ezQeXiz8G())
			{
				_0023_003DzzoqZ7r6_g11JF2TbYw_003D_003D _0023_003DzzoqZ7r6_g11JF2TbYw_003D_003D2 = item as _0023_003DzzoqZ7r6_g11JF2TbYw_003D_003D;
				if (_0023_003DzzoqZ7r6_g11JF2TbYw_003D_003D2 != null)
				{
					List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003DzF301AsR36CEG = _0023_003DzzoqZ7r6_g11JF2TbYw_003D_003D2._0023_003DzF301AsR36CEG;
					if (_0023_003DzF301AsR36CEG != null)
					{
						foreach (_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D item2 in _0023_003DzF301AsR36CEG)
						{
							item2._0023_003DzeX5b6QYO5pwg(_0023_003DzzoqZ7r6_g11JF2TbYw_003D_003D2);
							if (item2 is _0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D)
							{
								(item2 as _0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D)._0023_003Dz6YYH6PHygFqgZrANTA_003D_003D(_0023_003DzzoqZ7r6_g11JF2TbYw_003D_003D2, _0023_003Dzw3_zM5Q_003D);
							}
						}
					}
				}
				if (_0023_003DzzoqZ7r6_g11JF2TbYw_003D_003D2 != null)
				{
					_0023_003DzgoyZECDmOlGR_0024XT_0024mg_003D_003D.Add(_0023_003DzzoqZ7r6_g11JF2TbYw_003D_003D2);
				}
			}
			_0023_003Dz681SFOmrKDsN(_0023_003DzBq5cSTMdhlT9._0023_003DzaPVFvxmAjbS7());
			_0023_003Dz20MotOOKQrd2iDUoknubPNw_003D = _0023_003DzBq5cSTMdhlT9._0023_003DzY00lo3g_003D;
			_0023_003DzBV5xkUtSd6n7aiYIuw_003D_003D();
			result = true;
		}
		return result;
	}

	private void _0023_003DzBV5xkUtSd6n7aiYIuw_003D_003D()
	{
		_0023_003DzJuCd0lcgtX5EGU_Y8ov_wOBkghzkCSWeSQ_003D_003D _0023_003DzJuCd0lcgtX5EGU_Y8ov_wOBkghzkCSWeSQ_003D_003D2 = _0023_003Dz20MotOOKQrd2iDUoknubPNw_003D as _0023_003DzJuCd0lcgtX5EGU_Y8ov_wOBkghzkCSWeSQ_003D_003D;
		_0023_003DzmwEee3fUKhueUmNzTcE5YdHZjRJM _0023_003DzmwEee3fUKhueUmNzTcE5YdHZjRJM2 = _0023_003Dz20MotOOKQrd2iDUoknubPNw_003D as _0023_003DzmwEee3fUKhueUmNzTcE5YdHZjRJM;
		_0023_003DzJof2YYtOTREUAZk60vDz_0024iOSxAN4RN8kAA_003D_003D _0023_003DzJof2YYtOTREUAZk60vDz_0024iOSxAN4RN8kAA_003D_003D2 = _0023_003Dz20MotOOKQrd2iDUoknubPNw_003D as _0023_003DzJof2YYtOTREUAZk60vDz_0024iOSxAN4RN8kAA_003D_003D;
		_0023_003DzLT03Ch1QxAXtdY3O67Esh9k_003D _0023_003DzLT03Ch1QxAXtdY3O67Esh9k_003D2 = _0023_003Dz20MotOOKQrd2iDUoknubPNw_003D as _0023_003DzLT03Ch1QxAXtdY3O67Esh9k_003D;
		_0023_003DziF751hyvDYRHzDgUutJDJD_KKC_37opunQ_003D_003D _0023_003DziF751hyvDYRHzDgUutJDJD_KKC_37opunQ_003D_003D2 = _0023_003Dz20MotOOKQrd2iDUoknubPNw_003D as _0023_003DziF751hyvDYRHzDgUutJDJD_KKC_37opunQ_003D_003D;
		if (_0023_003DzmwEee3fUKhueUmNzTcE5YdHZjRJM2 != null || _0023_003DzJof2YYtOTREUAZk60vDz_0024iOSxAN4RN8kAA_003D_003D2 != null || _0023_003DzLT03Ch1QxAXtdY3O67Esh9k_003D2 != null || _0023_003DzJuCd0lcgtX5EGU_Y8ov_wOBkghzkCSWeSQ_003D_003D2 != null || _0023_003DziF751hyvDYRHzDgUutJDJD_KKC_37opunQ_003D_003D2 != null)
		{
			_0023_003DzEaTthajmBHHE0KlkKQ_003D_003D _0023_003DzEaTthajmBHHE0KlkKQ_003D_003D2 = null;
			if (_0023_003DzmwEee3fUKhueUmNzTcE5YdHZjRJM2 != null)
			{
				_0023_003Dzys6Fn1UQ6mxr()._0023_003DzcZAIRzdqjLL3(_0023_003DzmwEee3fUKhueUmNzTcE5YdHZjRJM2._0023_003DzS_00246o7tc_003D);
				_0023_003DzEaTthajmBHHE0KlkKQ_003D_003D2 = _0023_003DzmwEee3fUKhueUmNzTcE5YdHZjRJM2._0023_003DzNzjvfA4_003D as _0023_003DzEaTthajmBHHE0KlkKQ_003D_003D;
			}
			else if (_0023_003DzJof2YYtOTREUAZk60vDz_0024iOSxAN4RN8kAA_003D_003D2 != null)
			{
				_0023_003Dzys6Fn1UQ6mxr()._0023_003DzcZAIRzdqjLL3(_0023_003DzJof2YYtOTREUAZk60vDz_0024iOSxAN4RN8kAA_003D_003D2._0023_003DzS_00246o7tc_003D);
				_0023_003DzEaTthajmBHHE0KlkKQ_003D_003D2 = _0023_003DzJof2YYtOTREUAZk60vDz_0024iOSxAN4RN8kAA_003D_003D2._0023_003DzNzjvfA4_003D as _0023_003DzEaTthajmBHHE0KlkKQ_003D_003D;
			}
			else if (_0023_003DzLT03Ch1QxAXtdY3O67Esh9k_003D2 != null)
			{
				_0023_003Dzys6Fn1UQ6mxr()._0023_003DzcZAIRzdqjLL3(_0023_003DzLT03Ch1QxAXtdY3O67Esh9k_003D2._0023_003DzS_00246o7tc_003D);
				_0023_003DzEaTthajmBHHE0KlkKQ_003D_003D2 = _0023_003DzLT03Ch1QxAXtdY3O67Esh9k_003D2._0023_003DzNzjvfA4_003D as _0023_003DzEaTthajmBHHE0KlkKQ_003D_003D;
			}
			else if (_0023_003DzJuCd0lcgtX5EGU_Y8ov_wOBkghzkCSWeSQ_003D_003D2 != null)
			{
				_0023_003Dzys6Fn1UQ6mxr()._0023_003DzcZAIRzdqjLL3(_0023_003DzJuCd0lcgtX5EGU_Y8ov_wOBkghzkCSWeSQ_003D_003D2._0023_003DzS_00246o7tc_003D);
				_0023_003DzEaTthajmBHHE0KlkKQ_003D_003D2 = _0023_003DzJuCd0lcgtX5EGU_Y8ov_wOBkghzkCSWeSQ_003D_003D2._0023_003DzNzjvfA4_003D as _0023_003DzEaTthajmBHHE0KlkKQ_003D_003D;
			}
			else if (_0023_003DziF751hyvDYRHzDgUutJDJD_KKC_37opunQ_003D_003D2 != null)
			{
				_0023_003Dzys6Fn1UQ6mxr()._0023_003DzcZAIRzdqjLL3(_0023_003DziF751hyvDYRHzDgUutJDJD_KKC_37opunQ_003D_003D2._0023_003DzS_00246o7tc_003D);
				_0023_003DzEaTthajmBHHE0KlkKQ_003D_003D2 = _0023_003DziF751hyvDYRHzDgUutJDJD_KKC_37opunQ_003D_003D2._0023_003DzNzjvfA4_003D as _0023_003DzEaTthajmBHHE0KlkKQ_003D_003D;
			}
			if (_0023_003DzEaTthajmBHHE0KlkKQ_003D_003D2 == null)
			{
				return;
			}
			List<_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> _0023_003Dz0_0024SAHCMLrScF = _0023_003DzEaTthajmBHHE0KlkKQ_003D_003D2._0023_003Dz0_0024SAHCMLrScF;
			if (_0023_003Dz0_0024SAHCMLrScF != null)
			{
				if (_0023_003Dz0_0024SAHCMLrScF.Count > 2)
				{
					_0023_003Dzst3wBjo_003D(_0023_003Dz0_0024SAHCMLrScF[2]);
				}
				else
				{
					_0023_003Dzst3wBjo_003D(_0023_003Dz0_0024SAHCMLrScF[1]);
				}
			}
		}
		else
		{
			_0023_003Dzu97QPYFcxmdi = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302928365);
		}
	}

	private void _0023_003Dzst3wBjo_003D(_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D _0023_003DzGmhbLZBbMw7X)
	{
		if (_0023_003DzGmhbLZBbMw7X != null)
		{
			if (_0023_003DzGmhbLZBbMw7X is _0023_003DzA6hSOxR6Wul9LBkHyO8His8_003D _0023_003DzA6hSOxR6Wul9LBkHyO8His8_003D2)
			{
				_0023_003DzWTqwGQleZDfe = new List<_0023_003DzW8zZzhCUviR_0024>();
				_0023_003DzA6hSOxR6Wul9LBkHyO8His8_003D2._0023_003Dz0WeocAQ_003D(ref _0023_003DzWTqwGQleZDfe);
			}
			_0023_003DzbjJv7M_0Poi0();
		}
	}

	private void _0023_003DzbjJv7M_0Poi0()
	{
		double _0023_003DzrbIvx9sfBtxt = 1.0;
		_0023_003DzW8zZzhCUviR_0024 _0023_003DzrdvTjeaFTRlY = null;
		_0023_003DzW8zZzhCUviR_0024 _0023_003DzDSV3KvHUSDa = null;
		for (int i = 0; i < _0023_003DzWTqwGQleZDfe.Count; i++)
		{
			if (_0023_003DzWTqwGQleZDfe[i]._0023_003DzTyy4_1TcvpZp())
			{
				_0023_003DzrdvTjeaFTRlY = _0023_003DzWTqwGQleZDfe[i];
			}
			else if (_0023_003DzWTqwGQleZDfe[i]._0023_003DzYPlqaJLgOx10UASALg_003D_003D())
			{
				_0023_003DzDSV3KvHUSDa = _0023_003DzWTqwGQleZDfe[i];
			}
		}
		_0023_003DzJ_8OlxMXK6ec(_0023_003DzrdvTjeaFTRlY, ref _0023_003DzrbIvx9sfBtxt);
		_0023_003DzeK5Vqta9gfrzrjH4UA_003D_003D(_0023_003DzDSV3KvHUSDa, ref _0023_003DzrbIvx9sfBtxt);
	}

	private void _0023_003DzeK5Vqta9gfrzrjH4UA_003D_003D(_0023_003DzW8zZzhCUviR_0024 _0023_003DzDSV3KvHUSDa4, ref double _0023_003DzrbIvx9sfBtxt)
	{
		_0023_003Dzv_0024LHH24qrXtd(_0023_003DzDSV3KvHUSDa4._0023_003DzK_0024Gbdj2D7mDqLspljA_003D_003D(ref _0023_003DzrbIvx9sfBtxt));
		_0023_003Dz_00243V7Ggd4bnAF = _0023_003DzrbIvx9sfBtxt;
	}

	private void _0023_003DzJ_8OlxMXK6ec(_0023_003DzW8zZzhCUviR_0024 _0023_003DzrdvTjeaFTRlY, ref double _0023_003DzrbIvx9sfBtxt)
	{
		_0023_003DzCDCZPhS9OYQO(_0023_003DzrdvTjeaFTRlY._0023_003Dzf1U_0024Jh5J02zz(ref _0023_003DzrbIvx9sfBtxt));
		_0023_003DzfAW64ptugHc7 = _0023_003DzrbIvx9sfBtxt;
	}

	private void _0023_003DzjxWUtRTif70J()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> item in _0023_003Dzw3_zM5Q_003D)
		{
			item.Value._0023_003Dz9GKXKtrg_0024MPY(_0023_003Dzw3_zM5Q_003D, _0023_003Dzm4CSmX5Y3o6Q);
			if (item.Value is _0023_003Dz3jYLIbzYV_0024RS6maKEochFJ4_003D)
			{
				list.Add(item.Key);
			}
		}
		foreach (int item2 in list)
		{
			((_0023_003Dz3jYLIbzYV_0024RS6maKEochFJ4_003D)_0023_003Dzw3_zM5Q_003D[item2])._0023_003Dz9GKXKtrg_0024MPY(_0023_003Dzw3_zM5Q_003D, _0023_003Dzm4CSmX5Y3o6Q);
		}
	}

	private void _0023_003Dz75gufzcFRDgludX6vqKhy64_003D()
	{
		_0023_003Dzh6YNBZo_003D = new List<_0023_003DzbykJA36oCfUxYTgeaw_003D_003D>();
		foreach (KeyValuePair<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> item2 in _0023_003Dzw3_zM5Q_003D)
		{
			_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D value = item2.Value;
			if (!(value is _0023_003Dz5Jz5OGqW4jVrPMRtqmZyFNc_003D _0023_003DzHEpjcdg2hk9U))
			{
				if (!(value is _0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D _0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D2) || _0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D2._0023_003DzicQSqB0_003D[0]._0023_003Dz_lyH0ZGfMuyeQj1Y_0024g_003D_003D.Count <= 0)
				{
					continue;
				}
				_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D obj = new _0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D();
				_0023_003DzH88MvoFTpt3CJz7sfQ_003D_003D._0023_003DzCR8yxwe_0024nSm_bQ6UoQ_003D_003D(obj, _0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D2, _0023_003DzqmF8XJ0_003D);
				foreach (_0023_003DzbykJA36oCfUxYTgeaw_003D_003D item3 in obj._0023_003Dzh6YNBZo_003D)
				{
					item3._0023_003DzaROjBYA_003D = _0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D2._0023_003DzaROjBYA_003D;
					_0023_003Dzh6YNBZo_003D.Add(item3);
					if (_0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D2._0023_003Dzwtld1NM_003D != null && (item3._0023_003Dzwtld1NM_003D == null || item3._0023_003Dzwtld1NM_003D[0] == -1.0))
					{
						item3._0023_003Dzwtld1NM_003D = _0023_003Dzdueh_hpbwbsckZ1iox77qf0_003D2._0023_003Dzwtld1NM_003D;
					}
				}
			}
			else
			{
				_0023_003DzbykJA36oCfUxYTgeaw_003D_003D item = new _0023_003DzbykJA36oCfUxYTgeaw_003D_003D(_0023_003DzHEpjcdg2hk9U);
				_0023_003Dzh6YNBZo_003D.Add(item);
			}
		}
	}

	private string _0023_003Dz0Q99_6LxfzShtem_00241w_003D_003D(int _0023_003DzGYxU2RaGdg1N)
	{
		string result = string.Empty;
		foreach (_0023_003DznsjBPaTUABFe8okkLB4jM_EmBrbb item in _0023_003DzzEe3qdoUVj8l4V78d93K1ps_003D)
		{
			_0023_003DzUTPND_0024PaoLcT45gigpwkrAY_003D _0023_003DzmDgDSkLaIq = item._0023_003DzmDgDSkLaIq79;
			if (_0023_003DzmDgDSkLaIq != null && _0023_003DzmDgDSkLaIq._0023_003DzkXQ_IWk_003D == _0023_003DzGYxU2RaGdg1N)
			{
				_0023_003Dzjl_lT5RDLJuZp1ZdI5Sk9CA_003D _0023_003Dz84KwATjmsHCrNInHqg_003D_003D = item._0023_003Dz84KwATjmsHCrNInHqg_003D_003D;
				if (_0023_003Dz84KwATjmsHCrNInHqg_003D_003D != null && _0023_003Dz84KwATjmsHCrNInHqg_003D_003D._0023_003Dzvf4IVQQf9FW4VgFctK_3Hi4_003D != null)
				{
					result = _0023_003Dz84KwATjmsHCrNInHqg_003D_003D._0023_003Dzvf4IVQQf9FW4VgFctK_3Hi4_003D._0023_003Dz4pmQ5h06_Snm();
					break;
				}
			}
		}
		return result;
	}

	private void _0023_003DzCN_Q5PCPRRzylY6TZs5PegKml7BIEkr1Bg_003D_003D(List<_0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D> _0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D)
	{
		foreach (KeyValuePair<int, _0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D> item2 in _0023_003Dzw3_zM5Q_003D)
		{
			if (item2.Value is _0023_003DzvMcWdqoEPPfdHgIcxM9ex8Y_003D item)
			{
				_0023_003DzEI8YCjh4Ocm8_0024q09Cg_003D_003D.Add(item);
			}
		}
	}

	private string _0023_003DzHnsr_fDnno5vEnkLuQ_003D_003D(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D _0023_003Dzcoe2_tewkWc6)
	{
		if (!_0023_003DzAX0iigCEnhKp1e_0024AVw_003D_003D.ContainsKey(_0023_003Dzcoe2_tewkWc6._0023_003Dz4pmQ5h06_Snm()) && _0023_003Dzcoe2_tewkWc6._0023_003Dz4pmQ5h06_Snm().Trim() != string.Empty)
		{
			_0023_003DzAX0iigCEnhKp1e_0024AVw_003D_003D.Add(_0023_003Dzcoe2_tewkWc6._0023_003Dz4pmQ5h06_Snm(), _0023_003Dzcoe2_tewkWc6);
			return _0023_003Dzcoe2_tewkWc6._0023_003Dz4pmQ5h06_Snm();
		}
		_0023_003Dz1IF_0024i50dfi4kZaTPSQ_003D_003D(_0023_003Dzcoe2_tewkWc6);
		if (!_0023_003DzAX0iigCEnhKp1e_0024AVw_003D_003D.ContainsKey(_0023_003Dzcoe2_tewkWc6._0023_003Dz4pmQ5h06_Snm()) && _0023_003Dzcoe2_tewkWc6._0023_003Dz4pmQ5h06_Snm().Trim() != string.Empty)
		{
			_0023_003DzAX0iigCEnhKp1e_0024AVw_003D_003D.Add(_0023_003Dzcoe2_tewkWc6._0023_003Dz4pmQ5h06_Snm(), _0023_003Dzcoe2_tewkWc6);
			return _0023_003Dzcoe2_tewkWc6._0023_003Dz4pmQ5h06_Snm();
		}
		throw new Exception(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302928336));
	}

	private void _0023_003Dz1IF_0024i50dfi4kZaTPSQ_003D_003D(_0023_003DzSwNzCUSMkuVSrWhDng_003D_003D _0023_003Dzcoe2_tewkWc6)
	{
		string text = _0023_003Dzcoe2_tewkWc6._0023_003Dz4pmQ5h06_Snm();
		if (text.Trim() != string.Empty && _0023_003DzAX0iigCEnhKp1e_0024AVw_003D_003D[text] != null)
		{
			_0023_003Dzcoe2_tewkWc6._0023_003DzcZAIRzdqjLL3(text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915752) + _0023_003Dzc0bXpQg_mBG9T3tE_0024A_003D_003D++);
		}
	}

	public List<Entity> _0023_003DzYdnRH2i7V2MYsWcTs0KLmYuxuw_u6nrQxQ_003D_003D(BlockKeyedCollection _0023_003DzJO1FWlQ_003D, EntityList _0023_003Dzv7xH9gk_003D)
	{
		List<Entity> list = new List<Entity>();
		double num = -1.0;
		foreach (_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D value in _0023_003Dzw3_zM5Q_003D.Values)
		{
			if (!(value is _0023_003DzG1OO9rkHgtkrOQVgfAo7cmfTydnELSZ_0024ehIpImw_003D { _0023_003Dz_otMMV6hMYBrhC_00247haG4MurQZmXU: not null } _0023_003DzG1OO9rkHgtkrOQVgfAo7cmfTydnELSZ_0024ehIpImw_003D2))
			{
				continue;
			}
			foreach (_0023_003DzyJOsF5kmoztS1I0Xzw_003D_003D item in _0023_003DzG1OO9rkHgtkrOQVgfAo7cmfTydnELSZ_0024ehIpImw_003D2._0023_003Dz_otMMV6hMYBrhC_00247haG4MurQZmXU._0023_003DzhrgkevI_003D)
			{
				if (!(item is _0023_003Dz4q4OJlr9LtLgMwM4JSNEyaw_003D _0023_003Dz4q4OJlr9LtLgMwM4JSNEyaw_003D2))
				{
					continue;
				}
				Point3D _0023_003DzEebleSvLGrRJ = new Point3D(_0023_003Dz4q4OJlr9LtLgMwM4JSNEyaw_003D2._0023_003DzCGTSeY0_003D._0023_003Dzfj_WbJ59_mOa());
				double[] _0023_003DzqdOG1COev7La = _0023_003Dz4q4OJlr9LtLgMwM4JSNEyaw_003D2._0023_003DzHwk42AaBD9wG._0023_003DzqdOG1COev7La;
				double[] _0023_003DzqdOG1COev7La2 = _0023_003Dz4q4OJlr9LtLgMwM4JSNEyaw_003D2._0023_003Dz1_0024d_00248flwjiOW._0023_003DzqdOG1COev7La;
				Plane pln = ReadSTEP._0023_003DzNY5YUv279_SW(_0023_003DzEebleSvLGrRJ, _0023_003DzqdOG1COev7La, new double[3]
				{
					_0023_003DzqdOG1COev7La2[1] * _0023_003DzqdOG1COev7La[2] - _0023_003DzqdOG1COev7La2[2] * _0023_003DzqdOG1COev7La[1],
					_0023_003DzqdOG1COev7La2[2] * _0023_003DzqdOG1COev7La[0] - _0023_003DzqdOG1COev7La2[0] * _0023_003DzqdOG1COev7La[2],
					_0023_003DzqdOG1COev7La2[0] * _0023_003DzqdOG1COev7La[1] - _0023_003DzqdOG1COev7La2[1] * _0023_003DzqdOG1COev7La[0]
				}, _0023_003DzqdOG1COev7La2);
				if (num < 0.0)
				{
					Dictionary<string, Point3D[]> _0023_003DzUhW4aEj3QiQ72vNRgA_003D_003D = new Dictionary<string, Point3D[]>();
					double num2 = double.MaxValue;
					double num3 = double.MaxValue;
					double num4 = double.MaxValue;
					double num5 = double.MinValue;
					double num6 = double.MinValue;
					double num7 = double.MinValue;
					foreach (Entity item2 in _0023_003Dzv7xH9gk_003D)
					{
						Point3D[] array = item2._0023_003DzMHGsUs_0024dF1onGPMzUA_003D_003D(_0023_003DzJO1FWlQ_003D, null, _0023_003DzUhW4aEj3QiQ72vNRgA_003D_003D);
						foreach (Point3D point3D in array)
						{
							if (point3D.X < num2)
							{
								num2 = point3D.X;
							}
							if (point3D.Y < num3)
							{
								num3 = point3D.Y;
							}
							if (point3D.Z < num4)
							{
								num4 = point3D.Z;
							}
							if (point3D.X > num5)
							{
								num5 = point3D.X;
							}
							if (point3D.Y > num6)
							{
								num6 = point3D.Y;
							}
							if (point3D.Z > num7)
							{
								num7 = point3D.Z;
							}
						}
					}
					num = Point3D.Distance(new Point3D(num2, num3, num4), new Point3D(num5, num6, num7));
				}
				PlanarEntity planarEntity = new PlanarEntity(pln, num / 10.0);
				planarEntity.ColorMethod = colorMethodType.byEntity;
				planarEntity.Color = Color.Magenta;
				planarEntity.TranslationID = new TranslationIdentifier(_0023_003Dz4q4OJlr9LtLgMwM4JSNEyaw_003D2._0023_003DzkXQ_IWk_003D, _0023_003Dz4q4OJlr9LtLgMwM4JSNEyaw_003D2._0023_003DzS_00246o7tc_003D);
				list.Add(planarEntity);
			}
		}
		return list;
	}

	internal static string _0023_003DqYr7sTziHmRRs4M1NuKCJ8DXM8UH2GYiYDfNUWbxPCRZ8Y_ZeXjmQb6_tIhaog8fV(string _0023_003Dz0EsKsC8_003D, ref _0023_003Dzy0H2hy2_4Jd42s_1gdOD024_003D _0023_003DzE1OtBpQ_003D)
	{
		return _0023_003DzE1OtBpQ_003D._0023_003DzoJIN5IQ_003D.Unescape(Regex.Match(_0023_003Dz0EsKsC8_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302928278)).Groups[1].Value);
	}
}
