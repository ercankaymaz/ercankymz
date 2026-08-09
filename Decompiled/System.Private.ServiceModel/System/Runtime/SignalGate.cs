using System.Threading;

namespace System.Runtime;

internal class SignalGate
{
	private static class GateState
	{
		public const int Locked = 0;

		public const int SignalPending = 1;

		public const int Unlocked = 2;

		public const int Signalled = 3;
	}

	private int _state;

	internal bool IsLocked => _state == 0;

	internal bool IsSignalled => _state == 3;

	public bool Signal()
	{
		int num = _state;
		if (num == 0)
		{
			num = Interlocked.CompareExchange(ref _state, 1, 0);
		}
		switch (num)
		{
		case 2:
			_state = 3;
			return true;
		default:
			ThrowInvalidSignalGateState();
			break;
		case 0:
			break;
		}
		return false;
	}

	public bool Unlock()
	{
		int num = _state;
		if (num == 0)
		{
			num = Interlocked.CompareExchange(ref _state, 2, 0);
		}
		switch (num)
		{
		case 1:
			_state = 3;
			return true;
		default:
			ThrowInvalidSignalGateState();
			break;
		case 0:
			break;
		}
		return false;
	}

	private void ThrowInvalidSignalGateState()
	{
		throw Fx.Exception.AsError(new InvalidOperationException(InternalSR.InvalidSemaphoreExit));
	}
}
internal class SignalGate<T> : SignalGate
{
	private T _result;

	public bool Signal(T result)
	{
		_result = result;
		return Signal();
	}

	public bool Unlock(out T result)
	{
		if (Unlock())
		{
			result = _result;
			return true;
		}
		result = default(T);
		return false;
	}
}
