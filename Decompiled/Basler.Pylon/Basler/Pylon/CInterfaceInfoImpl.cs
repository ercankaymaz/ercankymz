using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using Pylon;
using bclog;

namespace Basler.Pylon;

internal class CInterfaceInfoImpl : InfoImpl, IInterfaceInfo, IDisposable
{
	public unsafe CInterfaceInfoImpl(CInterfaceInfo* interfaceInfo)
	{
		CInterfaceInfo* ptr = (CInterfaceInfo*)global::_003CModule_003E.@new(8u);
		CInterfaceInfo* pInfo;
		try
		{
			if (ptr != null)
			{
				global::_003CModule_003E.Pylon_002ECInterfaceInfo_002E_007Bctor_007D(ptr, interfaceInfo);
				*(int*)ptr = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_SCInterfaceInfo_0040Pylon_0040_00406B_0040);
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

	private void _007ECInterfaceInfoImpl()
	{
	}

	private void _0021CInterfaceInfoImpl()
	{
	}

	public unsafe CInterfaceInfo* GetInterfaceInfo()
	{
		CInfoBase* pInfo_nat = m_pInfo_nat;
		if (pInfo_nat == null)
		{
			global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetInfoCatID(), (LogLevel)512, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0CO_0040KNLMHBLD_0040Required_003F5interface_003F5info_003F5object_003F5_0040), __arglist());
			return null;
		}
		return (CInterfaceInfo*)global::_003CModule_003E.__RTDynamicCast(pInfo_nat, 0, System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVCInfoBase_0040Pylon_0040_0040_00408), System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_R0_003FAVCInterfaceInfo_0040Pylon_0040_0040_00408), 0);
	}

	[HandleProcessCorruptedStateExceptions]
	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				_007ECInterfaceInfoImpl();
				return;
			}
			finally
			{
				base.Dispose(A_0: true);
			}
		}
		try
		{
			_0021CInterfaceInfoImpl();
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
