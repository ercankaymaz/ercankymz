using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using devDept;

internal static class _0023_003Dz_aiWmhxMnXuNnGauTQ_003D_003D
{
	public static void _0023_003Dz50jqvKw_003D(string _0023_003Dzg5oC_Hs_003D)
	{
		if (File.Exists(_0023_003Dzg5oC_Hs_003D))
		{
			File.SetAttributes(_0023_003Dzg5oC_Hs_003D, FileAttributes.Normal);
			File.Delete(_0023_003Dzg5oC_Hs_003D);
		}
	}

	public static void _0023_003DzQyR_E4w_003D(string _0023_003DzXQiLsCo_003D, string _0023_003Dzg5oC_Hs_003D)
	{
		if (File.Exists(_0023_003Dzg5oC_Hs_003D))
		{
			_0023_003Dz3qRlrdI_003D(_0023_003DzXQiLsCo_003D, _0023_003Dzg5oC_Hs_003D);
			return;
		}
		string directoryName = Path.GetDirectoryName(_0023_003Dzg5oC_Hs_003D);
		if (!Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		File.WriteAllText(_0023_003Dzg5oC_Hs_003D, _0023_003DzXQiLsCo_003D, Encoding.UTF8);
		_0023_003Dzm_9QnLQ_003D(_0023_003Dzg5oC_Hs_003D);
	}

	private static void _0023_003Dz3qRlrdI_003D(string _0023_003DzXQiLsCo_003D, string _0023_003Dzg5oC_Hs_003D)
	{
		File.SetAttributes(_0023_003Dzg5oC_Hs_003D, FileAttributes.Normal);
		string text = _0023_003Dzg5oC_Hs_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673709);
		string text2 = _0023_003Dzg5oC_Hs_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673691);
		try
		{
			File.WriteAllText(text, _0023_003DzXQiLsCo_003D);
			File.Replace(text, _0023_003Dzg5oC_Hs_003D, text2);
		}
		catch (Exception _0023_003DzSQYc_0024aE_003D)
		{
			LicenseManager._0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673672), TraceLevel.Error, _0023_003DzSQYc_0024aE_003D, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
		}
		finally
		{
			_0023_003Dzm_9QnLQ_003D(_0023_003Dzg5oC_Hs_003D);
			_0023_003Dz50jqvKw_003D(text);
			_0023_003Dz50jqvKw_003D(text2);
		}
	}

	private static void _0023_003Dzm_9QnLQ_003D(string _0023_003Dzg5oC_Hs_003D)
	{
		File.SetAttributes(_0023_003Dzg5oC_Hs_003D, FileAttributes.ReadOnly | FileAttributes.Hidden | FileAttributes.System);
	}
}
