using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace buPop3.Pop3;

public abstract class Disposable : IDisposable
{
	[CompilerGenerated]
	private bool bool_0;

	protected bool IsDisposed
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		private set
		{
			bool_0 = value;
		}
	}

	~Disposable()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		if (!IsDisposed)
		{
			try
			{
				Dispose(disposing: true);
			}
			finally
			{
				IsDisposed = true;
				GC.SuppressFinalize(this);
			}
		}
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	protected void AssertDisposed()
	{
		if (IsDisposed)
		{
			string fullName = GetType().FullName;
			throw new ObjectDisposedException(fullName, string.Format(CultureInfo.InvariantCulture, "Cannot access a disposed {0}.", fullName));
		}
	}
}
