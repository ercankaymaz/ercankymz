using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using bclog;

namespace Basler.Pylon;

internal class ParameterCollectionEnumerator(IParameterCollection parent, List<string> names) : IEnumerator<IParameter>
{
	private IParameterCollection m_parameterCollection = parent;

	private List<string> m_names = names;

	private int m_maxIndex = names.Count - 1;

	private int m_currentIndex = -1;

	public virtual object Current2 => Current;

	public unsafe virtual IParameter Current
	{
		get
		{
			int currentIndex = m_currentIndex;
			if (currentIndex > -1 && currentIndex <= m_maxIndex)
			{
				return m_parameterCollection[m_names[currentIndex]];
			}
			global::_003CModule_003E.bclog_002ELogTrace(global::_003CModule_003E.Basler_002EPylon_002EGetLibraryCatID(), (LogLevel)128, (sbyte*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_0DG_0040CCOAJJFO_0040Element_003F5is_003F5undefined_003F4_003F5Move_003F5inde_0040), __arglist());
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_003E(new InvalidOperationException("Element is undefined. Move index to a valid position."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1DM_0040GEPOEKKO_0040_003F_0024AAP_003F_0024AAa_003F_0024AAr_003F_0024AAa_003F_0024AAm_003F_0024AAe_003F_0024AAt_003F_0024AAe_003F_0024AAr_003F_0024AAC_003F_0024AAo_003F_0024AAl_003F_0024AAl_003F_0024AAe_003F_0024AAc_0040));
		}
	}

	private void _007EParameterCollectionEnumerator()
	{
	}

	private void _0021ParameterCollectionEnumerator()
	{
	}

	public virtual void Reset()
	{
		m_currentIndex = -1;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public virtual bool MoveNext()
	{
		int currentIndex = m_currentIndex;
		if (currentIndex >= m_maxIndex)
		{
			return false;
		}
		m_currentIndex = currentIndex + 1;
		return true;
	}

	[HandleProcessCorruptedStateExceptions]
	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (!A_0)
		{
			try
			{
			}
			finally
			{
				base.Finalize();
			}
		}
	}

	public virtual sealed void Dispose()
	{
		Dispose(A_0: true);
		GC.SuppressFinalize(this);
	}

	~ParameterCollectionEnumerator()
	{
		Dispose(A_0: false);
	}
}
