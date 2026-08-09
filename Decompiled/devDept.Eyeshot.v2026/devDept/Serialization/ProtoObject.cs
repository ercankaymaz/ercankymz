using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept.Serialization;

public sealed class ProtoObject
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object _0023_003DzzESunKQBdYQcOBhByw_003D_003D;

	public object Object
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzzESunKQBdYQcOBhByw_003D_003D;
		}
	}

	public ProtoObject(object obj)
	{
		_0023_003Dztdr5_gs_003D(obj);
	}

	internal void _0023_003Dztdr5_gs_003D(object _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzzESunKQBdYQcOBhByw_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public ProtoObjectSurrogate ConvertToSurrogate()
	{
		return new ProtoObjectSurrogate(this);
	}
}
