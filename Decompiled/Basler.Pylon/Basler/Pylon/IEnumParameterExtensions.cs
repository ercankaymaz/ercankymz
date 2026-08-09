using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public static class IEnumParameterExtensions
{
	public static string GetValueOrDefault(this IEnumParameter parameter, string defaultValue)
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

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TrySetValue(this IEnumParameter parameter, IEnumerable<string> values)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			if (parameter.IsWritable)
			{
				parameter.SetValue(values);
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
	public static bool TrySetValue(this IEnumParameter parameter, string value)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			if (parameter.CanSetValue(value))
			{
				parameter.SetValue(value);
				goto IL_003b;
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
		IL_003b:
		((IDisposable)scopedLock).Dispose();
		return true;
	}

	public static void SetValue(this IEnumParameter parameter, IEnumerable<string> values)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			foreach (string value in values)
			{
				if (!parameter.CanSetValue(value))
				{
					continue;
				}
				parameter.SetValue(value);
				goto end_IL_001e;
			}
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AArgumentException_002Cclass_0020System_003A_003AString_0020_005E_003E(new ArgumentException("Invalid enumeration values.", "values"), parameter.FullName);
			end_IL_001e:;
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
		try
		{
			return;
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
	}
}
