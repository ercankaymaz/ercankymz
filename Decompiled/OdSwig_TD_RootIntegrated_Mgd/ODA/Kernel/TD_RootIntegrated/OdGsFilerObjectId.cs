using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsFilerObjectId : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsFilerObjectId(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsFilerObjectId obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsFilerObjectId()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsFilerObjectId(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public bool IsEqual(OdGsFilerObjectId oId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_IsEqual(swigCPtr, getCPtr(oId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdGsFilerObjectId oId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_IsNotEqual(swigCPtr, getCPtr(oId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsFilerObjectId()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerObjectId__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsFilerObjectId(OdGsFilerObjectId_ObjectType objType, OdDbStub pDbId)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerObjectId__SWIG_1((int)objType, OdDbStub.getCPtr(pDbId)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsFilerObjectId(OdGsFilerObjectId_ObjectType objType, IntPtr pId)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerObjectId__SWIG_2((int)objType, pId), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsFilerObjectId(OdGsFilerObjectId_ObjectType objType, uint nIndex)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerObjectId__SWIG_3((int)objType, nIndex), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsFilerObjectId(OdGsFilerObjectId_ObjectType objType, ulong nIndex)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerObjectId__SWIG_4((int)objType, nIndex), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsFilerObjectId(OdGsFilerObjectId_ObjectType objType, OdDbStub pDbId1, OdDbStub pDbId2)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerObjectId__SWIG_5((int)objType, OdDbStub.getCPtr(pDbId1), OdDbStub.getCPtr(pDbId2)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsFilerObjectId(OdGsFilerObjectId_ObjectType objType, OdDbStub pDbId, uint nIndex)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerObjectId__SWIG_6((int)objType, OdDbStub.getCPtr(pDbId), nIndex), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsFilerObjectId(OdGsFilerObjectId_ObjectType objType, OdDbStub pDbId, ulong nIndex)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerObjectId__SWIG_7((int)objType, OdDbStub.getCPtr(pDbId), nIndex), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasObject()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_hasObject(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setObjectType(OdGsFilerObjectId_ObjectType objType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_setObjectType(swigCPtr, (int)objType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsFilerObjectId_ObjectType objectType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_objectType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsFilerObjectId_ObjectType)result;
	}

	public int complexity()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_complexity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEmpty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_isEmpty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public byte serializeFlags()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_serializeFlags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void deserializeFlags(byte nFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_deserializeFlags(swigCPtr, nFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsFilerObjectId_IdType idType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_idType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsFilerObjectId_IdType)result;
	}

	public void setPersistentId(OdDbStub pDbId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_setPersistentId(swigCPtr, OdDbStub.getCPtr(pDbId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTransientId(IntPtr pId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_setTransientId(swigCPtr, pId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setIdIndex(uint nIndex)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_setIdIndex__SWIG_0(swigCPtr, nIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setIdIndex(ulong nIndex)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_setIdIndex__SWIG_1(swigCPtr, nIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbStub idAsPersistent()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_idAsPersistent(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr idAsTransient()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_idAsTransient(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint idAsIndex32()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_idAsIndex32(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ulong idAsIndex64()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_idAsIndex64(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsFilerObjectId_IdType subIdType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_subIdType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsFilerObjectId_IdType)result;
	}

	public void setPersistentSubId(OdDbStub pDbId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_setPersistentSubId(swigCPtr, OdDbStub.getCPtr(pDbId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTransientSubId(IntPtr pId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_setTransientSubId(swigCPtr, pId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSubIndex(uint nIndex)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_setSubIndex__SWIG_0(swigCPtr, nIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setSubIndex(ulong nIndex)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_setSubIndex__SWIG_1(swigCPtr, nIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbStub subIdAsPersistent()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_subIdAsPersistent(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr subIdAsTransient()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_subIdAsTransient(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint subIdAsIndex32()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_subIdAsIndex32(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ulong subIdAsIndex64()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_subIdAsIndex64(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsFilerObjectId_IdType indexType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_indexType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsFilerObjectId_IdType)result;
	}

	public void setIndex(uint nIndex)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_setIndex__SWIG_0(swigCPtr, nIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setIndex(ulong nIndex)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_setIndex__SWIG_1(swigCPtr, nIndex);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resetIndex()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_resetIndex(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint indexAs32()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_indexAs32(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ulong indexAs64()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerObjectId_indexAs64(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
