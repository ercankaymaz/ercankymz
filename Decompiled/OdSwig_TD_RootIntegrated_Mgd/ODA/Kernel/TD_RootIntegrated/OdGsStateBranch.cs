using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsStateBranch : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsStateBranch(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsStateBranch obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsStateBranch()
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
		if (swigCPtr.Handle != IntPtr.Zero)
		{
			if (swigCMemOwn)
			{
				lock (locker)
				{
					if (swigCPtr.Handle != IntPtr.Zero && swigCMemOwn)
					{
						swigCMemOwn = false;
						throw new MethodAccessException("C++ destructor does not have public access");
					}
				}
				swigCMemOwn = false;
			}
			swigCPtr = new HandleRef(null, IntPtr.Zero);
		}
		GC.SuppressFinalize(this);
	}

	public static OdGsStateBranch create(OdDbStub pDrawableId, OdGsStateBranch_BranchType branchType, IntPtr marker, OdGsSimpleParam pData)
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_create__SWIG_0(OdDbStub.getCPtr(pDrawableId), (int)branchType, marker, OdGsSimpleParam.getCPtr(pData)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGsStateBranch create(OdDbStub pDrawableId, OdGsStateBranch_BranchType branchType, IntPtr marker)
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_create__SWIG_1(OdDbStub.getCPtr(pDrawableId), (int)branchType, marker), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGsStateBranch create(OdDbStub pDrawableId, OdGsStateBranch_BranchType branchType)
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_create__SWIG_2(OdDbStub.getCPtr(pDrawableId), (int)branchType), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGsStateBranch create(OdGiDrawable pTransDrawable, OdGsStateBranch_BranchType branchType, IntPtr marker, OdGsSimpleParam pData)
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_create__SWIG_3(OdGiDrawable.getCPtr(pTransDrawable), (int)branchType, marker, OdGsSimpleParam.getCPtr(pData)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGsStateBranch create(OdGiDrawable pTransDrawable, OdGsStateBranch_BranchType branchType, IntPtr marker)
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_create__SWIG_4(OdGiDrawable.getCPtr(pTransDrawable), (int)branchType, marker), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGsStateBranch create(OdGiDrawable pTransDrawable, OdGsStateBranch_BranchType branchType)
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_create__SWIG_5(OdGiDrawable.getCPtr(pTransDrawable), (int)branchType), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void destroy(OdGsStateBranch pStateBranch)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_destroy(getCPtr(pStateBranch));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsStateBranchPtrArray aChild()
	{
		OdGsStateBranchPtrArray result = new OdGsStateBranchPtrArray(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_aChild(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsMarkerSet markers()
	{
		return new OdGsMarkerSet(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_markers(swigCPtr), cMemoryOwn: false);
	}

	public uint markersSize()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_markersSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool markersEmpty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_markersEmpty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsStateBranch addChild(OdDbStub pDrawableId)
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_addChild__SWIG_0(swigCPtr, OdDbStub.getCPtr(pDrawableId)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsStateBranch addChild(OdGiDrawable pTransDrawable)
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_addChild__SWIG_1(swigCPtr, OdGiDrawable.getCPtr(pTransDrawable)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void removeChild(OdGsStateBranch pChild)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_removeChild(swigCPtr, getCPtr(pChild));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsStateBranch findChild(OdDbStub pDrawableId)
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_findChild__SWIG_0(swigCPtr, OdDbStub.getCPtr(pDrawableId)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsStateBranch findChild(OdGiDrawable pTransDrawable)
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_findChild__SWIG_1(swigCPtr, OdGiDrawable.getCPtr(pTransDrawable)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool addMarker(IntPtr marker, OdGsSimpleParam pData, bool bDiffParamSet)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_addMarker__SWIG_0(swigCPtr, marker, OdGsSimpleParam.getCPtr(pData), bDiffParamSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool addMarker(IntPtr marker, OdGsSimpleParam pData)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_addMarker__SWIG_1(swigCPtr, marker, OdGsSimpleParam.getCPtr(pData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool addMarker(IntPtr marker)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_addMarker__SWIG_2(swigCPtr, marker);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool removeMarker(IntPtr marker)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_removeMarker(swigCPtr, marker);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasMarker(IntPtr marker)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_hasMarker(swigCPtr, marker);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbStub id()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_id(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiDrawable drw()
	{
		OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_drw(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool isEmpty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_isEmpty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isPersistentId()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_isPersistentId(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsStateBranch_BranchType type()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_type(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsStateBranch_BranchType)result;
	}

	public void setNextTypeOfBranch(OdGsStateBranch pNext)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_setNextTypeOfBranch(swigCPtr, getCPtr(pNext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsStateBranch nextTypeOfBranch()
	{
		OdGsStateBranch result = Helpers.GetObject<OdGsStateBranch>(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_nextTypeOfBranch__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setReactor(OdGsStateBranchReactor pReactor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_setReactor(swigCPtr, OdGsStateBranchReactor.getCPtr(pReactor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsStateBranchReactor reactor()
	{
		OdGsStateBranchReactor rXObject = Helpers.GetRXObject<OdGsStateBranchReactor>(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_reactor(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool setData(OdGsSimpleParam pData)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_setData(swigCPtr, OdGsSimpleParam.getCPtr(pData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void resetData()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_resetData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsSimpleParam data()
	{
		OdGsSimpleParam rXObject = Helpers.GetRXObject<OdGsSimpleParam>(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_data(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool hasData()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_hasData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsSimpleParam markerData(IntPtr marker)
	{
		OdGsSimpleParam rXObject = Helpers.GetRXObject<OdGsSimpleParam>(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_markerData(swigCPtr, marker), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool hasMarkerData(IntPtr marker)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_hasMarkerData(swigCPtr, marker);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint dataAsInt()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_dataAsInt(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint markerDataAsInt(IntPtr marker)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_markerDataAsInt(swigCPtr, marker);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d dataAsMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_dataAsMatrix(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d markerDataAsMatrix(IntPtr marker)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_markerDataAsMatrix(swigCPtr, marker), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isValidMarker(IntPtr marker)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_isValidMarker(marker);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsStateBranch_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
