using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace Basler.Pylon;

internal class CFileAdapterStreamList
{
	private static object s_listlock = new object();

	private static readonly SortedList s_list = new SortedList();

	internal unsafe static void Add(Camera camera, string filename)
	{
		Monitor.Enter(s_listlock);
		try
		{
			if (s_list.Contains(camera))
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_003E(new InvalidOperationException("Already openend a file on camera."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1CE_0040PJHNKPMC_0040_003F_0024AAF_003F_0024AAi_003F_0024AAl_003F_0024AAe_003F_0024AAA_003F_0024AAd_003F_0024AAa_003F_0024AAp_003F_0024AAt_003F_0024AAe_003F_0024AAr_003F_0024AAS_003F_0024AAt_003F_0024AAr_003F_0024AAe_0040));
			}
			s_list.Add(camera, filename);
		}
		finally
		{
			Monitor.Exit(s_listlock);
		}
	}

	internal static void Remove(Camera camera)
	{
		Monitor.Enter(s_listlock);
		try
		{
			if (camera != null && s_list.Contains(camera))
			{
				s_list.Remove(camera);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			Monitor.Exit(s_listlock);
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsInUse(Camera camera)
	{
		Monitor.Enter(s_listlock);
		try
		{
			return s_list.Contains(camera);
		}
		finally
		{
			Monitor.Exit(s_listlock);
		}
	}
}
