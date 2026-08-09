using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Microsoft.Extensions.Logging;

[ComVisible(true)]
public class LoggerExternalScopeProvider : IExternalScopeProvider
{
	private sealed class Scope : IDisposable
	{
		private readonly LoggerExternalScopeProvider _provider;

		private bool _isDisposed;

		public Scope Parent { get; }

		public object State { get; }

		internal Scope(LoggerExternalScopeProvider provider, object state, Scope parent)
		{
			_provider = provider;
			State = state;
			Parent = parent;
		}

		public override string ToString()
		{
			return State?.ToString();
		}

		public void Dispose()
		{
			if (!_isDisposed)
			{
				_provider._currentScope.Value = Parent;
				_isDisposed = true;
			}
		}
	}

	private readonly AsyncLocal<Scope> _currentScope = new AsyncLocal<Scope>();

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
	public void ForEachScope<[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] TState>([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(new byte[] { 1, 2, 1 })] Action<object, TState> callback, TState state)
	{
		Report(_currentScope.Value);
		void Report([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] Scope current)
		{
			if (current != null)
			{
				Report(current.Parent);
				callback(current.State, state);
			}
		}
	}

	[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
	public IDisposable Push([Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(2)] object state)
	{
		Scope value = _currentScope.Value;
		Scope scope = new Scope(this, state, value);
		_currentScope.Value = scope;
		return scope;
	}
}
