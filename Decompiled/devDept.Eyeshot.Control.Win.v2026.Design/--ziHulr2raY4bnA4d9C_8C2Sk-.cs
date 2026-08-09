using System;
using System.Diagnostics;
using devDept;
using devDept.Diagnostic;
using devDept.Eyeshot;

internal sealed class _0023_003DziHulr2raY4bnA4d9C_8C2Sk_003D : IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003DzYopWT_A_003D;

	internal _0023_003DziHulr2raY4bnA4d9C_8C2Sk_003D()
	{
		_0023_003DzYopWT_A_003D = LicenseManager.ProductEdition == licenseType.Pro;
		if (_0023_003DzYopWT_A_003D)
		{
			Logger.Instance.stack.Push(item: true);
		}
	}

	public void Dispose()
	{
		if (_0023_003DzYopWT_A_003D)
		{
			Logger.Instance.stack.TryPop(out var _);
		}
	}
}
