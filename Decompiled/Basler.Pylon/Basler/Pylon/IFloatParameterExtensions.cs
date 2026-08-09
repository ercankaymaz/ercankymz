using System;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public static class IFloatParameterExtensions
{
	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TrySetValue(this IFloatParameter parameter, double value, FloatValueCorrection correction)
	{
		ScopedLock scopedLock = null;
		if (correction == FloatValueCorrection.None)
		{
			return parameter.TrySetValue(value);
		}
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			if (parameter.IsWritable && parameter.IsReadable)
			{
				double minimum = parameter.GetMinimum();
				double maximum = parameter.GetMaximum();
				if (correction == FloatValueCorrection.ClipToRange)
				{
					double value2 = global::_003CModule_003E.gtl_002ECorrectDoubleValue(minimum, maximum, value);
					parameter.SetValue(value2);
				}
				else
				{
					parameter.SetValue(value);
				}
				goto IL_0075;
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
		IL_0075:
		((IDisposable)scopedLock).Dispose();
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TrySetValue(this IFloatParameter parameter, double value)
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

	public static double GetValueOrDefault(this IFloatParameter parameter, double defaultValue)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		double value;
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

	public static void SetValue(this IFloatParameter parameter, double value, FloatValueCorrection correction)
	{
		ScopedLock scopedLock = null;
		if (correction == FloatValueCorrection.None)
		{
			parameter.SetValue(value);
			return;
		}
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			double minimum = parameter.GetMinimum();
			double maximum = parameter.GetMaximum();
			if (correction == FloatValueCorrection.ClipToRange)
			{
				double value2 = global::_003CModule_003E.gtl_002ECorrectDoubleValue(minimum, maximum, value);
				parameter.SetValue(value2);
			}
			else
			{
				parameter.SetValue(value);
			}
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
	}

	public static double GetValuePercentOfRange(this IFloatParameter parameter)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		double minimum;
		double maximum;
		double value;
		try
		{
			scopedLock = scopedLock2;
			minimum = parameter.GetMinimum();
			maximum = parameter.GetMaximum();
			value = parameter.GetValue();
			if (minimum != maximum && value != maximum)
			{
				if (value != minimum)
				{
					goto IL_006c;
				}
				goto IL_005b;
			}
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
		return 100.0;
		IL_006c:
		double num2;
		try
		{
			double num = minimum * 0.5;
			num2 = (value * 0.5 - num) / (maximum * 0.5 - num) * 100.0;
			if (!(num2 <= 100.0))
			{
				num2 = 100.0;
			}
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
		return num2;
		IL_005b:
		((IDisposable)scopedLock).Dispose();
		return 0.0;
	}

	public static void SetValuePercentOfRange(this IFloatParameter parameter, double percentOfRange)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			global::_003CModule_003E.Basler_002EPylon_002ESetValuePercentOfRangeImpl(parameter, percentOfRange);
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TrySetValuePercentOfRange(this IFloatParameter parameter, double percentOfRange)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			if (parameter.IsWritable && parameter.IsReadable)
			{
				global::_003CModule_003E.Basler_002EPylon_002ESetValuePercentOfRangeImpl(parameter, percentOfRange);
				goto IL_0044;
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
		IL_0044:
		((IDisposable)scopedLock).Dispose();
		return true;
	}

	public static void SetToMaximum(this IFloatParameter parameter)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			double maximum = parameter.GetMaximum();
			parameter.SetValue(maximum);
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
	}

	public static void SetToMinimum(this IFloatParameter parameter)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			double minimum = parameter.GetMinimum();
			parameter.SetValue(minimum);
		}
		catch
		{
			//try-fault
			((IDisposable)scopedLock).Dispose();
			throw;
		}
		((IDisposable)scopedLock).Dispose();
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TrySetToMaximum(this IFloatParameter parameter)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			if (parameter.IsWritable && parameter.IsReadable)
			{
				double maximum = parameter.GetMaximum();
				parameter.SetValue(maximum);
				goto IL_004b;
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
		IL_004b:
		((IDisposable)scopedLock).Dispose();
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TrySetToMinimum(this IFloatParameter parameter)
	{
		ScopedLock scopedLock = null;
		ScopedLock scopedLock2 = new ScopedLock((parameter.Advanced == null) ? null : parameter.Advanced.GetLock());
		try
		{
			scopedLock = scopedLock2;
			if (parameter.IsWritable && parameter.IsReadable)
			{
				double minimum = parameter.GetMinimum();
				parameter.SetValue(minimum);
				goto IL_004b;
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
		IL_004b:
		((IDisposable)scopedLock).Dispose();
		return true;
	}
}
