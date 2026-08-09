using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept.Eyeshot.Control.Mouse3D;

public class DeviceInfo
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzXTIuXyISHwYu0LoL9Q_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IntPtr _0023_003Dzb8mE8Y75aEtwLaO7cKQZ8Zs_003D;

	public string DeviceName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzXTIuXyISHwYu0LoL9Q_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzXTIuXyISHwYu0LoL9Q_003D_003D = value;
		}
	}

	public IntPtr DeviceHandle
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzb8mE8Y75aEtwLaO7cKQZ8Zs_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzb8mE8Y75aEtwLaO7cKQZ8Zs_003D = value;
		}
	}
}
