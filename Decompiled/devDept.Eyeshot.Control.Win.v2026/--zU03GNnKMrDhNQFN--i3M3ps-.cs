using System;
using System.Diagnostics;
using devDept;
using devDept.Diagnostic;
using devDept.Eyeshot;

internal sealed class _0023_003DzU03GNnKMrDhNQFN_0024_0024i3M3ps_003D : IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003Dz7VEML1w_003D;

	internal _0023_003DzU03GNnKMrDhNQFN_0024_0024i3M3ps_003D()
	{
		_0023_003Dz7VEML1w_003D = LicenseManager.ProductEdition == licenseType.Pro;
		if (_0023_003Dz7VEML1w_003D)
		{
			Logger.Instance.stack.Push(item: true);
		}
	}

	public void Dispose()
	{
		if (_0023_003Dz7VEML1w_003D)
		{
			Logger.Instance.stack.TryPop(out var _);
		}
	}
}
