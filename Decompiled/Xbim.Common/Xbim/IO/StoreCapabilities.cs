namespace Xbim.IO;

public class StoreCapabilities
{
	public bool IsTransient { get; private set; }

	public bool SupportsTransactions { get; private set; }

	public StoreCapabilities(bool isTransient, bool supportsTransactions)
	{
		IsTransient = isTransient;
		SupportsTransactions = supportsTransactions;
	}
}
