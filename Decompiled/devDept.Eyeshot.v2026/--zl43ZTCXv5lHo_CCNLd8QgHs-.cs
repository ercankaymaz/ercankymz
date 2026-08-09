using System.Globalization;
using System.Resources;
using System.Threading;

internal sealed class _0023_003Dzl43ZTCXv5lHo_CCNLd8QgHs_003D
{
	private static _0023_003Dzl43ZTCXv5lHo_CCNLd8QgHs_003D _0023_003DzY9lMfQI_003D;

	private ResourceManager _0023_003Dz4bTvLaE_003D;

	internal _0023_003Dzl43ZTCXv5lHo_CCNLd8QgHs_003D()
	{
		_0023_003Dz4bTvLaE_003D = new ResourceManager(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302660010), GetType().Assembly);
	}

	private static _0023_003Dzl43ZTCXv5lHo_CCNLd8QgHs_003D _0023_003Dzfnk_lu0_003D()
	{
		if (_0023_003DzY9lMfQI_003D == null)
		{
			_0023_003Dzl43ZTCXv5lHo_CCNLd8QgHs_003D value = new _0023_003Dzl43ZTCXv5lHo_CCNLd8QgHs_003D();
			Interlocked.CompareExchange(ref _0023_003DzY9lMfQI_003D, value, null);
		}
		return _0023_003DzY9lMfQI_003D;
	}

	private static CultureInfo _0023_003DzyOnYrP2_0024XheT()
	{
		return null;
	}

	public static ResourceManager _0023_003DzMHuDHXkg_0024pjc()
	{
		return _0023_003Dzfnk_lu0_003D()._0023_003Dz4bTvLaE_003D;
	}

	public static string _0023_003DzCSptaQY_003D(string _0023_003DzS_00246o7tc_003D, object[] _0023_003Dz53Cncpw_003D)
	{
		_0023_003Dzl43ZTCXv5lHo_CCNLd8QgHs_003D _0023_003Dzl43ZTCXv5lHo_CCNLd8QgHs_003D2 = _0023_003Dzfnk_lu0_003D();
		if (_0023_003Dzl43ZTCXv5lHo_CCNLd8QgHs_003D2 == null)
		{
			return null;
		}
		string text = _0023_003Dzl43ZTCXv5lHo_CCNLd8QgHs_003D2._0023_003Dz4bTvLaE_003D.GetString(_0023_003DzS_00246o7tc_003D, _0023_003DzyOnYrP2_0024XheT());
		if (_0023_003Dz53Cncpw_003D == null || _0023_003Dz53Cncpw_003D.Length == 0)
		{
			return text;
		}
		for (int i = 0; i < _0023_003Dz53Cncpw_003D.Length; i++)
		{
			if (_0023_003Dz53Cncpw_003D[i] is string { Length: >1024 } text2)
			{
				_0023_003Dz53Cncpw_003D[i] = text2.Substring(0, 1021) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302659969);
			}
		}
		return string.Format(CultureInfo.CurrentCulture, text, _0023_003Dz53Cncpw_003D);
	}

	public static string _0023_003DzCSptaQY_003D(string _0023_003DzS_00246o7tc_003D)
	{
		return _0023_003Dzfnk_lu0_003D()?._0023_003Dz4bTvLaE_003D.GetString(_0023_003DzS_00246o7tc_003D, _0023_003DzyOnYrP2_0024XheT());
	}

	public static string _0023_003DzCSptaQY_003D(string _0023_003DzS_00246o7tc_003D, out bool _0023_003Dz0M3DnTSVgF9_0024)
	{
		_0023_003Dz0M3DnTSVgF9_0024 = false;
		return _0023_003DzCSptaQY_003D(_0023_003DzS_00246o7tc_003D);
	}

	public static object _0023_003Dzhe1mJic_003D(string _0023_003DzS_00246o7tc_003D)
	{
		return _0023_003Dzfnk_lu0_003D()?._0023_003Dz4bTvLaE_003D.GetObject(_0023_003DzS_00246o7tc_003D, _0023_003DzyOnYrP2_0024XheT());
	}
}
