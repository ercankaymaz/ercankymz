using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcObjectId : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcObjectId(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcObjectId obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcObjectId()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcObjectId(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcObjectId()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcObjectId__SWIG_0(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcObjectId(OdDbStub objectId)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcObjectId__SWIG_1(OdDbStub.getCPtr(objectId)), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isNull()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_isNull(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNull()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_setNull(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isErased()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_isErased(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcObjectId Assign(OdPrcObjectId elementId)
	{
		OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_Assign__SWIG_0(swigCPtr, getCPtr(elementId)), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcObjectId Assign(OdDbStub objectId)
	{
		OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_Assign__SWIG_1(swigCPtr, OdDbStub.getCPtr(objectId)), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdPrcObjectId elementId)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_IsEqual(swigCPtr, getCPtr(elementId));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool logicalOperatorNot()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_logicalOperatorNot(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStub AsOdDbStubPointer()
	{
		IntPtr intPtr = OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_AsOdDbStubPointer(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxObject database()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbHandle getHandle()
	{
		OdDbHandle result = new OdDbHandle(OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_getHandle(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult openObject(ref OdRxObject pObj, OpenMode openMode, bool openErasedOne)
	{
		IntPtr jarg = ((pObj == null) ? IntPtr.Zero : OdRxObject.getCPtr(pObj).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_openObject__SWIG_0(swigCPtr, ref jarg, (int)openMode, openErasedOne);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pObj = null;
			}
			else if (jarg != intPtr)
			{
				pObj = Helpers.GetRXObject<OdRxObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdResult openObject(ref OdRxObject pObj, OpenMode openMode)
	{
		IntPtr jarg = ((pObj == null) ? IntPtr.Zero : OdRxObject.getCPtr(pObj).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_openObject__SWIG_1(swigCPtr, ref jarg, (int)openMode);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pObj = null;
			}
			else if (jarg != intPtr)
			{
				pObj = Helpers.GetRXObject<OdRxObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdResult openObject(ref OdRxObject pObj)
	{
		IntPtr jarg = ((pObj == null) ? IntPtr.Zero : OdRxObject.getCPtr(pObj).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_openObject__SWIG_2(swigCPtr, ref jarg);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pObj = null;
			}
			else if (jarg != intPtr)
			{
				pObj = Helpers.GetRXObject<OdRxObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdRxObject openObject(OpenMode openMode, bool openErasedOne)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_openObject__SWIG_3(swigCPtr, (int)openMode, openErasedOne), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxObject openObject(OpenMode openMode)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_openObject__SWIG_4(swigCPtr, (int)openMode), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxObject openObject()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_openObject__SWIG_5(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxObject safeOpenObject(OpenMode openMode, bool openErasedOne)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_safeOpenObject__SWIG_0(swigCPtr, (int)openMode, openErasedOne), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxObject safeOpenObject(OpenMode openMode)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_safeOpenObject__SWIG_1(swigCPtr, (int)openMode), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxObject safeOpenObject()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_safeOpenObject__SWIG_2(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdRxObject safeOpenObjectOdRx(OpenMode openMode, bool openErasedOne)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(OdPrcModule_GlobalsPINVOKE.OdPrcObjectId_safeOpenObjectOdRx(swigCPtr, (int)openMode, openErasedOne), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}
}
