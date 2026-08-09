using System.Collections.Generic;

namespace Microsoft.Isam.Esent.Interop;

internal sealed class CallbackWrappers
{
	private readonly object lockObject = new object();

	private readonly List<JetCallbackWrapper> callbackWrappers = new List<JetCallbackWrapper>();

	public JetCallbackWrapper Add(JET_CALLBACK callback)
	{
		lock (lockObject)
		{
			if (!TryFindWrapperFor(callback, out var wrapper))
			{
				wrapper = new JetCallbackWrapper(callback);
				callbackWrappers.Add(wrapper);
			}
			return wrapper;
		}
	}

	public void Collect()
	{
		lock (lockObject)
		{
			callbackWrappers.RemoveAll((JetCallbackWrapper wrapper) => !wrapper.IsAlive);
		}
	}

	private bool TryFindWrapperFor(JET_CALLBACK callback, out JetCallbackWrapper wrapper)
	{
		foreach (JetCallbackWrapper callbackWrapper in callbackWrappers)
		{
			if (callbackWrapper.IsWrapping(callback))
			{
				wrapper = callbackWrapper;
				return true;
			}
		}
		wrapper = null;
		return false;
	}
}
