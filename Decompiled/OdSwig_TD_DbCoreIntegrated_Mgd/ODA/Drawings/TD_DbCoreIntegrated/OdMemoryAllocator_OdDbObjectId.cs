using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdMemoryAllocator_OdDbObjectId : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdMemoryAllocator_OdDbObjectId(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdMemoryAllocator_OdDbObjectId obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdMemoryAllocator_OdDbObjectId()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdMemoryAllocator_OdDbObjectId(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public static void copyAssignRangeDisjoint(OdDbObjectId pDestination, OdDbObjectId pSource, uint numElements)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdMemoryAllocator_OdDbObjectId_copyAssignRangeDisjoint(OdDbObjectId.getCPtr(pDestination), OdDbObjectId.getCPtr(pSource), numElements);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void moveAssignRangeDisjoint(OdDbObjectId pDestination, OdDbObjectId pSource, uint numElements)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdMemoryAllocator_OdDbObjectId_moveAssignRangeDisjoint(OdDbObjectId.getCPtr(pDestination), OdDbObjectId.getCPtr(pSource), numElements);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void copyAssignRange(OdDbObjectId pDestination, OdDbObjectId pSource, uint numElements)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdMemoryAllocator_OdDbObjectId_copyAssignRange(OdDbObjectId.getCPtr(pDestination), OdDbObjectId.getCPtr(pSource), numElements);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void moveAssignRange(OdDbObjectId pDestination, OdDbObjectId pSource, uint numElements)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdMemoryAllocator_OdDbObjectId_moveAssignRange(OdDbObjectId.getCPtr(pDestination), OdDbObjectId.getCPtr(pSource), numElements);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void defaultConstruct(OdDbObjectId arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdMemoryAllocator_OdDbObjectId_defaultConstruct(OdDbObjectId.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void copyConstruct(OdDbObjectId pElement, OdDbObjectId value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdMemoryAllocator_OdDbObjectId_copyConstruct(OdDbObjectId.getCPtr(pElement), OdDbObjectId.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void moveConstruct(OdDbObjectId pElement, OdDbObjectId value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdMemoryAllocator_OdDbObjectId_moveConstruct(OdDbObjectId.getCPtr(pElement), OdDbObjectId.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void copyConstructFill(OdDbObjectId pDestination, uint numElements, OdDbObjectId value)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdMemoryAllocator_OdDbObjectId_copyConstructFill(OdDbObjectId.getCPtr(pDestination), numElements, OdDbObjectId.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void copyConstructRange(OdDbObjectId pDestination, OdDbObjectId pSource, uint numElements)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdMemoryAllocator_OdDbObjectId_copyConstructRange(OdDbObjectId.getCPtr(pDestination), OdDbObjectId.getCPtr(pSource), numElements);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void moveConstructRange(OdDbObjectId pDestination, OdDbObjectId pSource, uint numElements)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdMemoryAllocator_OdDbObjectId_moveConstructRange(OdDbObjectId.getCPtr(pDestination), OdDbObjectId.getCPtr(pSource), numElements);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void defaultConstructFill(OdDbObjectId arg0, uint arg1)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdMemoryAllocator_OdDbObjectId_defaultConstructFill(OdDbObjectId.getCPtr(arg0), arg1);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void destroy(OdDbObjectId arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdMemoryAllocator_OdDbObjectId_destroy(OdDbObjectId.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void destroyRange(OdDbObjectId arg0, uint arg1)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdMemoryAllocator_OdDbObjectId_destroyRange(OdDbObjectId.getCPtr(arg0), arg1);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static bool useRealloc()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdMemoryAllocator_OdDbObjectId_useRealloc();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdMemoryAllocator_OdDbObjectId()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdMemoryAllocator_OdDbObjectId(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
