using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbObjectId : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public static OdDbObjectId kNull
	{
		get
		{
			IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_kNull_get();
			OdDbObjectId result = ((intPtr == IntPtr.Zero) ? null : new OdDbObjectId(intPtr, cMemoryOwn: false));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbObjectId(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbObjectId obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbObjectId()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbObjectId(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public override bool Equals(object obj)
	{
		OdDbObjectId odDbObjectId = (OdDbObjectId)obj;
		if (odDbObjectId == null)
		{
			return false;
		}
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_IsEqual(swigCPtr, getCPtr(odDbObjectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override int GetHashCode()
	{
		return (int)getHandle().ToUInt64();
	}

	public OdDbObjectId()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbObjectId__SWIG_0(), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdDbObjectId(swigCPtr.Handle, cMemoryOwn: true));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId(OdDbStub objectId)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbObjectId__SWIG_1(OdDbStub.getCPtr(objectId)), MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryManager.GetMemoryManager().GetCurrentTransaction()?.AddObject(new OdDbObjectId(swigCPtr.Handle, cMemoryOwn: true));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isNull()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_isNull(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setNull()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_setNull(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isValid()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_isValid(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId AssignOdDbStub(OdDbStub objectId)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_AssignOdDbStub(swigCPtr, OdDbStub.getCPtr(objectId)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdDbObjectId objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_IsEqual(swigCPtr, getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdDbObjectId objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_IsNotEqual(swigCPtr, getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool logicalOperatorNot()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_logicalOperatorNot(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStub AsOdDbStubPointer()
	{
		IntPtr intPtr = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_AsOdDbStubPointer(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbDatabase database()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbDatabase originalDatabase()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_originalDatabase(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void convertToRedirectedId()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_convertToRedirectedId(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isErased()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_isErased(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEffectivelyErased()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_isEffectivelyErased(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool objectLeftOnDisk()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_objectLeftOnDisk(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbHandle getHandle()
	{
		OdDbHandle result = new OdDbHandle(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_getHandle(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbHandle getNonForwardedHandle()
	{
		OdDbHandle result = new OdDbHandle(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_getNonForwardedHandle(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult openObject(ref OdDbObject pObj, OdDb_OpenMode openMode, bool openErasedOne)
	{
		IntPtr jarg = ((pObj == null) ? IntPtr.Zero : OdDbObject.getCPtr(pObj).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_openObject__SWIG_0(swigCPtr, ref jarg, (int)openMode, openErasedOne);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
				pObj = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdResult openObject(ref OdDbObject pObj, OdDb_OpenMode openMode)
	{
		IntPtr jarg = ((pObj == null) ? IntPtr.Zero : OdDbObject.getCPtr(pObj).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_openObject__SWIG_1(swigCPtr, ref jarg, (int)openMode);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
				pObj = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdResult openObject(ref OdDbObject pObj)
	{
		IntPtr jarg = ((pObj == null) ? IntPtr.Zero : OdDbObject.getCPtr(pObj).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_openObject__SWIG_2(swigCPtr, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
				pObj = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdDbObject openObject(OdDb_OpenMode openMode, bool openErasedOne)
	{
		OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_openObject__SWIG_3(swigCPtr, (int)openMode, openErasedOne), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbObject openObject(OdDb_OpenMode openMode)
	{
		OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_openObject__SWIG_4(swigCPtr, (int)openMode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbObject openObject()
	{
		OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_openObject__SWIG_5(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbObject safeOpenObject(OdDb_OpenMode openMode, bool openErasedOne)
	{
		OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_safeOpenObject__SWIG_0(swigCPtr, (int)openMode, openErasedOne), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbObject safeOpenObject(OdDb_OpenMode openMode)
	{
		OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_safeOpenObject__SWIG_1(swigCPtr, (int)openMode), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbObject safeOpenObject()
	{
		OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_safeOpenObject__SWIG_2(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void bindObject(OdDbObject pObj)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_bindObject(swigCPtr, OdDbObject.getCPtr(pObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxClass objectClass()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_objectClass(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbObjectId Assign(OdDbObjectId objectId)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectId_Assign(swigCPtr, getCPtr(objectId)), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
