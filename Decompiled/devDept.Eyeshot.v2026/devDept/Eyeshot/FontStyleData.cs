using System;
using System.Collections.Generic;
using System.Diagnostics;
using devDept.Graphics;

namespace devDept.Eyeshot;

[Serializable]
public class FontStyleData : Dictionary<string, FontStyleCharData>, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz_0024x_00241n56dxWq2;

	public double ScaleToUnitSize => _0023_003Dz_0024x_00241n56dxWq2;

	internal FontStyleData(double _0023_003DzuCzANmziTJld)
	{
		_0023_003Dz_0024x_00241n56dxWq2 = _0023_003DzuCzANmziTJld;
	}

	public void Dispose()
	{
		foreach (FontStyleCharData value in base.Values)
		{
			value.Dispose();
		}
	}

	internal bool _0023_003DzPJNpNF4_003D(string _0023_003DzuwH5j5s_003D, TextStyle _0023_003Dzgkctzk6d2IIh, RenderContextBase _0023_003DzQdnFby4_003D, bool _0023_003DzbamQ1mQWVhT9)
	{
		try
		{
			if (!ContainsKey(_0023_003DzuwH5j5s_003D))
			{
				Add(_0023_003DzuwH5j5s_003D, new FontStyleCharData(_0023_003DzuwH5j5s_003D, _0023_003Dzgkctzk6d2IIh, _0023_003DzQdnFby4_003D, ScaleToUnitSize, _0023_003DzbamQ1mQWVhT9));
				return true;
			}
		}
		catch (Exception ex)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302986138) + _0023_003DzuwH5j5s_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985827) + _0023_003Dzgkctzk6d2IIh.FontFamilyName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985816) + _0023_003Dzgkctzk6d2IIh.Style.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302941696) + ex.Message, ex);
		}
		return false;
	}
}
