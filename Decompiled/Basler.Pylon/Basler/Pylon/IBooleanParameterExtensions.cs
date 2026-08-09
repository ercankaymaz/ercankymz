using System;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public static class IBooleanParameterExtensions
{
	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TrySetValue(this IBooleanParameter parameter, [MarshalAs(UnmanagedType.U1)] bool value)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			if (parameter.IsWritable)
			{
				parameter.SetValue(value);
				goto IL_003a;
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
		IL_003a:
		((IDisposable)scopedLock).Dispose();
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool GetValueOrDefault(this IBooleanParameter parameter, [MarshalAs(UnmanagedType.U1)] bool defaultValue)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		bool value;
		try
		{
			scopedLock = scopedLock2;
			if (parameter.IsReadable)
			{
				value = parameter.GetValue();
				goto IL_003a;
			}
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
		return defaultValue;
		IL_003a:
		((IDisposable)scopedLock).Dispose();
		return value;
	}
}
