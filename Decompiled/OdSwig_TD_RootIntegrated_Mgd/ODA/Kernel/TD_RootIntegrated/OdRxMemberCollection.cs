using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxMemberCollection : IDisposable
{
	public delegate int SwigDelegateOdRxMemberCollection_0();

	public delegate IntPtr SwigDelegateOdRxMemberCollection_1(int index);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdRxMemberCollection_0 swigDelegate0;

	private SwigDelegateOdRxMemberCollection_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(int) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxMemberCollection(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxMemberCollection obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdRxMemberCollection()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxMemberCollection(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual int count()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberCollection_count(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxMember getAt(int index)
	{
		OdRxMember rXObject = Helpers.GetRXObject<OdRxMember>(TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberCollection_getAt(swigCPtr, index), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxMemberCollection()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxMemberCollection(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxMemberCollection) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("count", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodcount;
		}
		if (SwigDerivedClassHasMethod("getAt", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodgetAt;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberCollection_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxMemberCollection));
	}

	private int SwigDirectorMethodcount()
	{
		return count();
	}

	private IntPtr SwigDirectorMethodgetAt(int index)
	{
		return OdRxMember.getCPtr(getAt(index)).Handle;
	}
}
