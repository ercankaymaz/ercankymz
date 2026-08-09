using System;

internal static class _0023_003DzkX_2lVwSsBM50m0cJwXvbJc_003D
{
	public static void _0023_003Dz0mdCzng_003D<TypeName>(ref TypeName _0023_003Dzb2InYPc_003D) where TypeName : class
	{
		if (_0023_003Dzb2InYPc_003D == null)
		{
			return;
		}
		if (_0023_003Dzb2InYPc_003D is IDisposable disposable)
		{
			try
			{
				disposable.Dispose();
			}
			catch
			{
			}
		}
		_0023_003Dzb2InYPc_003D = null;
	}
}
