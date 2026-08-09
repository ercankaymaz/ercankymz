using System;
using System.Threading;
using devDept;

internal abstract class _0023_003DzZblWR4M6qOLiy7U57TkX2pA_003D
{
	public bool _0023_003DzBcvxv10_003D;

	private WorkUnit.ProgressChangedEventHandler _0023_003DzVNCWkQY_003D;

	public void _0023_003DzgHO845XqWw4G(WorkUnit.ProgressChangedEventHandler _0023_003DzPzO_0024GUk_003D)
	{
		WorkUnit.ProgressChangedEventHandler progressChangedEventHandler = _0023_003DzVNCWkQY_003D;
		WorkUnit.ProgressChangedEventHandler progressChangedEventHandler2;
		do
		{
			progressChangedEventHandler2 = progressChangedEventHandler;
			WorkUnit.ProgressChangedEventHandler value = (WorkUnit.ProgressChangedEventHandler)Delegate.Combine(progressChangedEventHandler2, _0023_003DzPzO_0024GUk_003D);
			progressChangedEventHandler = Interlocked.CompareExchange(ref _0023_003DzVNCWkQY_003D, value, progressChangedEventHandler2);
		}
		while ((object)progressChangedEventHandler != progressChangedEventHandler2);
	}

	public void _0023_003Dz_0024G2PnkkLKrRc(WorkUnit.ProgressChangedEventHandler _0023_003DzPzO_0024GUk_003D)
	{
		WorkUnit.ProgressChangedEventHandler progressChangedEventHandler = _0023_003DzVNCWkQY_003D;
		WorkUnit.ProgressChangedEventHandler progressChangedEventHandler2;
		do
		{
			progressChangedEventHandler2 = progressChangedEventHandler;
			WorkUnit.ProgressChangedEventHandler value = (WorkUnit.ProgressChangedEventHandler)Delegate.Remove(progressChangedEventHandler2, _0023_003DzPzO_0024GUk_003D);
			progressChangedEventHandler = Interlocked.CompareExchange(ref _0023_003DzVNCWkQY_003D, value, progressChangedEventHandler2);
		}
		while ((object)progressChangedEventHandler != progressChangedEventHandler2);
	}

	public bool _0023_003DzI8SQX5cpoKsqrKUaAw_003D_003D(int _0023_003Dz3Ftsho0_003D, int _0023_003Dz13KtlVg_003D)
	{
		_0023_003DzVNCWkQY_003D?.Invoke(this, new WorkUnit.ProgressChangedEventArgs((int)(100.0 * (double)_0023_003Dz3Ftsho0_003D / (double)_0023_003Dz13KtlVg_003D), null));
		return !_0023_003DzBcvxv10_003D;
	}
}
