using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbAppInfoRecordSet : IDisposable
{
	public delegate uint SwigDelegateOdDbAppInfoRecordSet_0();

	public delegate IntPtr SwigDelegateOdDbAppInfoRecordSet_1();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdDbAppInfoRecordSet_0 swigDelegate0;

	private SwigDelegateOdDbAppInfoRecordSet_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbAppInfoRecordSet(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbAppInfoRecordSet obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbAppInfoRecordSet()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbAppInfoRecordSet(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual uint getNumberOfRecords()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecordSet_getNumberOfRecords(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbAppInfoRecordIterator getRecordIterator()
	{
		OdDbAppInfoRecordIterator result = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdDbAppInfoRecordIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecordSet_getRecordIterator(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecordSet_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbAppInfoRecordSet()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbAppInfoRecordSet(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbAppInfoRecordSet) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("getNumberOfRecords", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodgetNumberOfRecords;
		}
		if (SwigDerivedClassHasMethod("getRecordIterator", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodgetRecordIterator;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbAppInfoRecordSet_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbAppInfoRecordSet));
	}

	private uint SwigDirectorMethodgetNumberOfRecords()
	{
		return getNumberOfRecords();
	}

	private IntPtr SwigDirectorMethodgetRecordIterator()
	{
		return OdDbAppInfoRecordIterator.getCPtr(getRecordIterator()).Handle;
	}
}
