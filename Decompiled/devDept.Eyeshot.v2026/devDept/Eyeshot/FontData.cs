using System;
using System.Collections.Generic;
using System.Diagnostics;
using devDept.Graphics;

namespace devDept.Eyeshot;

[Serializable]
public class FontData : Dictionary<fontStyle, FontStyleData>, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly object _0023_003DzVr9ZjZP3U3p2 = new object();

	public void Dispose()
	{
		foreach (FontStyleData value in base.Values)
		{
			value.Dispose();
		}
	}

	internal void _0023_003Dz2QgzNYs_003D(string _0023_003DzwyYng5o_003D, TextStyle _0023_003Dzgkctzk6d2IIh, RenderContextBase _0023_003DzQdnFby4_003D, bool _0023_003DzbamQ1mQWVhT9)
	{
		fontStyle key = ((!_0023_003Dzgkctzk6d2IIh.IsSHX()) ? _0023_003Dzgkctzk6d2IIh.Style : fontStyle.Regular);
		bool flag;
		lock (_0023_003DzVr9ZjZP3U3p2)
		{
			if (!ContainsKey(key))
			{
				Add(key, new FontStyleData(FontStyleCharData._0023_003Dzjfb687zJyEZd(_0023_003Dzgkctzk6d2IIh, _0023_003DzQdnFby4_003D)));
			}
			flag = base[key]._0023_003DzPJNpNF4_003D(_0023_003DzwyYng5o_003D, _0023_003Dzgkctzk6d2IIh, _0023_003DzQdnFby4_003D, _0023_003DzbamQ1mQWVhT9);
		}
		if (flag && !_0023_003Dzgkctzk6d2IIh.IsSHX())
		{
			base[key][_0023_003DzwyYng5o_003D]._0023_003Dz_0024bJolnrorj7wQsl7reNoxZw_003D();
		}
	}
}
