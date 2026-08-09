using System.Runtime.CompilerServices;

namespace System.Text.Json;

internal static class StackHelper
{
	public static bool TryEnsureSufficientExecutionStack()
	{
		try
		{
			RuntimeHelpers.EnsureSufficientExecutionStack();
			return true;
		}
		catch
		{
			return false;
		}
	}
}
