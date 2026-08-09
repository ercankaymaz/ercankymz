using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public static class CastHelper
{
	public static TToType reinterpret_cast<TFromType, TToType>(TFromType from)
	{
		HandleRef handleRef = (HandleRef)typeof(TFromType).GetMethod("getCPtr", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[1] { from });
		return (TToType)typeof(TToType).GetConstructor(new Type[2]
		{
			typeof(IntPtr),
			typeof(bool)
		}).Invoke(new object[2] { handleRef.Handle, false });
	}
}
