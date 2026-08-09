using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdTextIterator : IDisposable
{
	public delegate char SwigDelegateOdTextIterator_0();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdTextIterator_0 swigDelegate0;

	private static Type[] swigMethodTypes0 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdTextIterator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdTextIterator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdTextIterator()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdTextIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	protected virtual char nextCharAsIs()
	{
		char result = (SwigDerivedClassHasMethod("nextCharAsIs", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdTextIterator_nextCharAsIsSwigExplicitOdTextIterator(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdTextIterator_nextCharAsIs(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string currPos()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdTextIterator_currPos(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdTextIterator()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdTextIterator__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdTextIterator) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdTextIterator(string str, int nLen, bool bRaw, OdCodePageId codepage, OdFont pFont, OdFont pBigFont)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdTextIterator__SWIG_1(str, nLen, bRaw, (int)codepage, OdFont.getCPtr(pFont), OdFont.getCPtr(pBigFont)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdTextIterator) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public char __ref__()
	{
		char result = TD_RootIntegrated_GlobalsPINVOKE.OdTextIterator___ref__(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCharacterProperties currProperties()
	{
		OdCharacterProperties result = new OdCharacterProperties(TD_RootIntegrated_GlobalsPINVOKE.OdTextIterator_currProperties(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public char nextChar()
	{
		char result = TD_RootIntegrated_GlobalsPINVOKE.OdTextIterator_nextChar(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool currIsToleranceDivider()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextIterator_currIsToleranceDivider(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setProcessToleranceDivider(bool b)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextIterator_setProcessToleranceDivider__SWIG_0(swigCPtr, b);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setProcessToleranceDivider()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextIterator_setProcessToleranceDivider__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getTextAsDByte(OdCharArray retArray, OdUInt16Array pFlagsArray)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextIterator_getTextAsDByte__SWIG_0(swigCPtr, OdCharArray.getCPtr(retArray), OdUInt16Array.getCPtr(pFlagsArray).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getTextAsDByte(OdCharArray retArray)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdTextIterator_getTextAsDByte__SWIG_1(swigCPtr, OdCharArray.getCPtr(retArray));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int breakSafely(int len, ref string s)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(s);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdTextIterator_breakSafely(swigCPtr, len, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				s = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void setProcessMIF(bool b)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdTextIterator_setProcessMIF(swigCPtr, b);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("nextCharAsIs", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodnextCharAsIs;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdTextIterator_director_connect(swigCPtr, swigDelegate0);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdTextIterator));
	}

	private char SwigDirectorMethodnextCharAsIs()
	{
		return nextCharAsIs();
	}
}
