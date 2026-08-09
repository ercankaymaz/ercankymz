using System;

namespace Microsoft.Windows.Design.Policies;

public class PolicyAddedEventArgs : EventArgs
{
	private ItemPolicy _policy;

	public ItemPolicy Policy => _policy;

	public PolicyAddedEventArgs(ItemPolicy policy)
	{
		if (policy == null)
		{
			throw new ArgumentNullException("policy");
		}
		_policy = policy;
	}
}
