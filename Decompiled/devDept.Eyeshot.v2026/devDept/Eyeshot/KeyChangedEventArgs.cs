using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept.Eyeshot;

public class KeyChangedEventArgs : PropertyChangedEventArgs
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string _0023_003DzZzAL0Q0dsrpNwV9XHQ_003D_003D;

	public virtual string NewKey
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzZzAL0Q0dsrpNwV9XHQ_003D_003D;
		}
	}

	public KeyChangedEventArgs(string propertyName, string newKey)
		: base(propertyName)
	{
		_0023_003DzZzAL0Q0dsrpNwV9XHQ_003D_003D = newKey;
	}
}
