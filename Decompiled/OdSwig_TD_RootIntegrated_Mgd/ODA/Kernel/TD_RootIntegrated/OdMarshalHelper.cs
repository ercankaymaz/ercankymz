using System;

namespace ODA.Kernel.TD_RootIntegrated;

public static class OdMarshalHelper
{
	public static IntPtr ObjectToPtr<TType>(object obj)
	{
		if (obj == null)
		{
			return IntPtr.Zero;
		}
		return Helpers.GetSwigCPtr(obj);
	}

	public static TType PtrToObject<TType>(IntPtr ptr)
	{
		if (ptr == IntPtr.Zero)
		{
			return default(TType);
		}
		return (TType)Activator.CreateInstance(typeof(TType), ptr, false);
	}
}
