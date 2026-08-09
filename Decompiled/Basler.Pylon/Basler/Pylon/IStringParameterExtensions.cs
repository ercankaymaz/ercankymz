using System;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public static class IStringParameterExtensions
{
	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TrySetValue(this IStringParameter parameter, string value)
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

	public static string GetValueOrDefault(this IStringParameter parameter, string defaultValue)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		string value;
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
