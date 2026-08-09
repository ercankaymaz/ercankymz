using System.Threading;

namespace System.ServiceModel;

public sealed class OperationContextScope : IDisposable
{
	[ThreadStatic]
	private static OperationContextScope s_currentScope;

	private static AsyncLocal<OperationContextScope> s_asyncCurrentScope;

	private OperationContext _currentContext;

	private bool _disposed;

	private readonly OperationContext _originalContext = OperationContext.Current;

	private readonly OperationContextScope _originalScope = (OperationContext.DisableAsyncFlow ? s_currentScope : s_asyncCurrentScope.Value);

	static OperationContextScope()
	{
		if (!OperationContext.DisableAsyncFlow)
		{
			s_asyncCurrentScope = new AsyncLocal<OperationContextScope>();
		}
	}

	public OperationContextScope(IContextChannel channel)
	{
		PushContext(new OperationContext(channel));
	}

	public OperationContextScope(OperationContext context)
	{
		PushContext(context);
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_disposed = true;
			PopContext();
		}
	}

	private void PushContext(OperationContext context)
	{
		_currentContext = context;
		if (OperationContext.DisableAsyncFlow)
		{
			s_currentScope = this;
		}
		else
		{
			s_asyncCurrentScope.Value = this;
		}
		OperationContext.Current = _currentContext;
	}

	private void PopContext()
	{
		if ((OperationContext.DisableAsyncFlow ? s_currentScope : s_asyncCurrentScope.Value) != this)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxInterleavedContextScopes0));
		}
		if (OperationContext.Current != _currentContext)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxContextModifiedInsideScope0));
		}
		if (OperationContext.DisableAsyncFlow)
		{
			s_currentScope = _originalScope;
		}
		else
		{
			s_asyncCurrentScope.Value = _originalScope;
		}
		OperationContext.Current = _originalContext;
		if (_currentContext != null)
		{
			_currentContext.SetClientReply(null, closeMessage: false);
		}
	}
}
