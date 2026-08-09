using System;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public static class ICommandParameterExtensions
{
	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TryExecute(this ICommandParameter parameter)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			if (parameter.IsWritable)
			{
				parameter.Execute();
				goto IL_0039;
			}
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
		return false;
		IL_0039:
		((IDisposable)scopedLock).Dispose();
		return true;
	}
}
