using System.Diagnostics.CodeAnalysis;
using System.Security.AccessControl;

namespace System.Threading;

public static class SemaphoreAcl
{
	public static Semaphore Create(int initialCount, int maximumCount, string? name, out bool createdNew, SemaphoreSecurity? semaphoreSecurity)
	{
		return new Semaphore(initialCount, maximumCount, name, out createdNew, semaphoreSecurity);
	}

	public static Semaphore OpenExisting(string name, SemaphoreRights rights)
	{
		return Semaphore.OpenExisting(name, rights);
	}

	public static bool TryOpenExisting(string name, SemaphoreRights rights, [NotNullWhen(true)] out Semaphore result)
	{
		return Semaphore.TryOpenExisting(name, rights, out result);
	}
}
