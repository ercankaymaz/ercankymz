using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

internal class DataContainerEnumerator : IEnumerator
{
	public DataContainer m_pContainer;

	public int m_currentIndex;

	public unsafe virtual object Current
	{
		get
		{
			DataContainer pContainer = m_pContainer;
			if (pContainer == null)
			{
				throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(new NullReferenceException("Container is null"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BM_0040IACFPHHC_0040_003F_0024AAD_003F_0024AAa_003F_0024AAt_003F_0024AAa_003F_0024AAC_003F_0024AAo_003F_0024AAn_003F_0024AAt_003F_0024AAa_003F_0024AAi_003F_0024AAn_003F_0024AAe_003F_0024AAr_0040));
			}
			return pContainer.get_Item(m_currentIndex);
		}
	}

	public DataContainerEnumerator(DataContainer container)
	{
		m_pContainer = container;
		m_currentIndex = -1;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe virtual bool MoveNext()
	{
		DataContainer pContainer = m_pContainer;
		if (pContainer == null)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(new NullReferenceException("Container is null"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BM_0040IACFPHHC_0040_003F_0024AAD_003F_0024AAa_003F_0024AAt_003F_0024AAa_003F_0024AAC_003F_0024AAo_003F_0024AAn_003F_0024AAt_003F_0024AAa_003F_0024AAi_003F_0024AAn_003F_0024AAe_003F_0024AAr_0040));
		}
		int num = pContainer.Count - 1;
		int currentIndex = m_currentIndex;
		if (currentIndex < num)
		{
			m_currentIndex = currentIndex + 1;
			return true;
		}
		return false;
	}

	public unsafe virtual void Reset()
	{
		if (m_pContainer == null)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANullReferenceException_003E(new NullReferenceException("Container is null"), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BM_0040IACFPHHC_0040_003F_0024AAD_003F_0024AAa_003F_0024AAt_003F_0024AAa_003F_0024AAC_003F_0024AAo_003F_0024AAn_003F_0024AAt_003F_0024AAa_003F_0024AAi_003F_0024AAn_003F_0024AAe_003F_0024AAr_0040));
		}
		m_currentIndex = 0;
	}
}
