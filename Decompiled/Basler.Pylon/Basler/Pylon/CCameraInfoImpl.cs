using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using Pylon;
using bclog;

namespace Basler.Pylon;

internal class CCameraInfoImpl : InfoImpl, ICameraInfo, IDisposable
{
	public unsafe CCameraInfoImpl(CDeviceInfo* di)
	{
		CDeviceInfo* ptr = (CDeviceInfo*)global::_003CModule_003E.@new(8u);
		CDeviceInfo* pInfo;
		try
		{
			if (ptr != null)
			{
				global::_003CModule_003E.Pylon_002ECDeviceInfo_002E_007Bctor_007D(ptr, di);
				*(int*)ptr = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_SCDeviceInfo_0040Pylon_0040_00406B_0040);
				pInfo = ptr;
			}
			else
			{
				pInfo = null;
			}
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.delete(ptr, 8u);
			throw;
		}
		base._002Ector((CInfoBase*)pInfo);
	}

	private void _007ECCameraInfoImpl()
	{
	}

	private void _0021CCameraInfoImpl()
	{
	}

	public unsafe CDeviceInfo* GetDeviceInfo()
	{
		CInfoBase* pInfo_nat = m_pInfo_nat;
		if (pInfo_nat == null)
		{
			global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetInfoCatID(), (LogLevel)512, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0CL_0040OHBEGOAC_0040Required_003F5device_003F5info_003F5object_003F5not_0040), __arglist());
			return null;
		}
		return (CDeviceInfo*)global::_003CModule_003E.__RTDynamicCast(pInfo_nat, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVCInfoBase_0040Pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVCDeviceInfo_0040Pylon_0040_0040_00408), 0);
	}

	[HandleProcessCorruptedStateExceptions]
	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				_007ECCameraInfoImpl();
				return;
			}
			finally
			{
				base.Dispose(A_0: true);
			}
		}
		try
		{
			_0021CCameraInfoImpl();
		}
		finally
		{
			base.Dispose(A_0: false);
		}
	}

	public virtual sealed void Dispose()
	{
		Dispose(A_0: true);
		GC.SuppressFinalize(this);
	}
}
