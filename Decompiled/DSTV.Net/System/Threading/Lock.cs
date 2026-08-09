namespace System.Threading;

internal sealed class Lock
{
	public readonly ref struct Scope
	{
		private readonly Lock _owner;

		internal Scope(Lock owner)
		{
			_owner = owner;
		}

		public void Dispose()
		{
			_owner.Exit();
		}
	}

	private readonly object _lockObject = new object();

	public bool IsHeldByCurrentThread => Monitor.IsEntered(_lockObject);

	public void Enter()
	{
		Monitor.Enter(_lockObject);
	}

	public bool TryEnter()
	{
		return Monitor.TryEnter(_lockObject);
	}

	public bool TryEnter(TimeSpan timeout)
	{
		return Monitor.TryEnter(_lockObject, timeout);
	}

	public bool TryEnter(int millisecondsTimeout)
	{
		return TryEnter(TimeSpan.FromMilliseconds(millisecondsTimeout));
	}

	public void Exit()
	{
		Monitor.Exit(_lockObject);
	}

	public Scope EnterScope()
	{
		Enter();
		return new Scope(this);
	}
}
