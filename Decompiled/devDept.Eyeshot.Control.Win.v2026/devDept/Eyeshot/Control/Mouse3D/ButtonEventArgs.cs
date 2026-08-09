using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept.Eyeshot.Control.Mouse3D;

public class ButtonEventArgs : EventArgs
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DeviceInfo _0023_003DzIYSBIN5rnb7u;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button _0023_003DzgV2EfYc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private virtualKey _0023_003Dzhp_AXuZBWkeMgcjmrg_003D_003D;

	public Button Button
	{
		get
		{
			return _0023_003DzgV2EfYc_003D;
		}
		set
		{
			_0023_003DzgV2EfYc_003D = value;
		}
	}

	public virtualKey VirtualKey
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzhp_AXuZBWkeMgcjmrg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzhp_AXuZBWkeMgcjmrg_003D_003D = value;
		}
	}

	public DeviceInfo DeviceInfo
	{
		get
		{
			return _0023_003DzIYSBIN5rnb7u;
		}
		set
		{
			_0023_003DzIYSBIN5rnb7u = value;
		}
	}

	internal ButtonEventArgs(DeviceInfo _0023_003Dzopmfnqc_003D, Button _0023_003DzkGobcLg_003D)
	{
		_0023_003DzIYSBIN5rnb7u = _0023_003Dzopmfnqc_003D;
		_0023_003DzgV2EfYc_003D = _0023_003DzkGobcLg_003D;
		if (_0023_003DzkGobcLg_003D.Pressed == 0)
		{
			VirtualKey = virtualKey.V3DkInvalid;
		}
		else
		{
			VirtualKey = tdx._0023_003DzQrZIT4w_003D._0023_003Dz9mKByVHLf2A5(0u, (ushort)_0023_003DzkGobcLg_003D.Pressed);
		}
	}
}
