using System;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design.Model;

public abstract class ModelEditingScope : IDisposable
{
	private string _description;

	private bool _completed;

	private bool _reverted;

	public string Description
	{
		get
		{
			if (_description != null)
			{
				return _description;
			}
			return string.Empty;
		}
		set
		{
			_description = value;
		}
	}

	~ModelEditingScope()
	{
		Dispose(disposing: false);
	}

	public void Complete()
	{
		if (_reverted)
		{
			throw new InvalidOperationException(MS.Internal.Properties.Resources.Error_EditingScopeReverted);
		}
		if (_completed)
		{
			throw new InvalidOperationException(MS.Internal.Properties.Resources.Error_EdtingScopeCompleted);
		}
		if (CanComplete())
		{
			bool flag = false;
			_completed = true;
			try
			{
				OnComplete();
				flag = true;
				return;
			}
			finally
			{
				if (flag)
				{
					GC.SuppressFinalize(this);
				}
				else
				{
					_completed = false;
				}
			}
		}
		Revert();
	}

	public void Revert()
	{
		if (_completed)
		{
			throw new InvalidOperationException(MS.Internal.Properties.Resources.Error_EdtingScopeCompleted);
		}
		if (_reverted)
		{
			return;
		}
		bool flag = false;
		_reverted = true;
		try
		{
			OnRevert(finalizing: false);
			flag = true;
		}
		finally
		{
			if (flag)
			{
				GC.SuppressFinalize(this);
			}
			else
			{
				_reverted = false;
			}
		}
	}

	public virtual void Update()
	{
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_completed && !_reverted)
		{
			if (disposing)
			{
				Revert();
			}
			else
			{
				OnRevert(finalizing: true);
			}
		}
	}

	protected abstract void OnComplete();

	protected abstract bool CanComplete();

	protected abstract void OnRevert(bool finalizing);
}
