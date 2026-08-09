using System.Collections.Generic;
using System.Diagnostics;

namespace devDept.Eyeshot;

public class FontDataDictionary : Dictionary<string, FontData>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly object _0023_003DzVr9ZjZP3U3p2 = new object();

	public new FontData this[string name]
	{
		get
		{
			return base[name];
		}
		set
		{
			base[name] = value;
		}
	}

	public new void Add(string key, FontData data)
	{
		base.Add(key, data);
	}

	public void TryAdd(string key, FontData data)
	{
		lock (_0023_003DzVr9ZjZP3U3p2)
		{
			if (!ContainsKey(key))
			{
				base.Add(key, data);
			}
		}
	}
}
