using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbCompoundObjectId : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbCompoundObjectId_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbCompoundObjectId_1();

	public delegate void SwigDelegateOdDbCompoundObjectId_2(IntPtr pSource);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbCompoundObjectId_0 swigDelegate0;

	private SwigDelegateOdDbCompoundObjectId_1 swigDelegate1;

	private SwigDelegateOdDbCompoundObjectId_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbCompoundObjectId(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbCompoundObjectId obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbCompoundObjectId(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbCompoundObjectId cast(OdRxObject pObj)
	{
		OdDbCompoundObjectId rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCompoundObjectId>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_isASwigExplicitOdDbCompoundObjectId(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_queryXSwigExplicitOdDbCompoundObjectId(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbCompoundObjectId Assign(OdDbObjectId arg0)
	{
		OdDbCompoundObjectId rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCompoundObjectId>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_Assign__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(arg0)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbCompoundObjectId Assign(OdDbCompoundObjectId arg0)
	{
		OdDbCompoundObjectId rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCompoundObjectId>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_Assign__SWIG_1(swigCPtr, getCPtr(arg0)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool IsEqual(OdDbCompoundObjectId arg0)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_IsEqual(swigCPtr, getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdDbCompoundObjectId other)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_IsNotEqual(swigCPtr, getCPtr(other));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId topId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_topId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId leafId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_leafId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult getFullPath(OdDbObjectIdArray fullPath)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_getFullPath(swigCPtr, OdDbObjectIdArray.getCPtr(fullPath));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult getPath(OdDbObjectIdArray path)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_getPath(swigCPtr, OdDbObjectIdArray.getCPtr(path));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public void setEmpty()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_setEmpty(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult set(OdDbObjectId arg0, OdDbDatabase pHostDatabase)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_set__SWIG_0(swigCPtr, OdDbObjectId.getCPtr(arg0), OdDbDatabase.getCPtr(pHostDatabase));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdDbObjectId arg0)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_set__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdDbCompoundObjectId arg0, OdDbDatabase pHostDatabase)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_set__SWIG_2(swigCPtr, getCPtr(arg0), OdDbDatabase.getCPtr(pHostDatabase));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdDbCompoundObjectId arg0)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_set__SWIG_3(swigCPtr, getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdDbObjectId id, OdDbObjectIdArray path, OdDbDatabase pHostDatabase)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_set__SWIG_4(swigCPtr, OdDbObjectId.getCPtr(id), OdDbObjectIdArray.getCPtr(path), OdDbDatabase.getCPtr(pHostDatabase));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult set(OdDbObjectId id, OdDbObjectIdArray path)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_set__SWIG_5(swigCPtr, OdDbObjectId.getCPtr(id), OdDbObjectIdArray.getCPtr(path));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setFullPath(OdDbObjectIdArray fullPath, OdDbDatabase pHostDatabase)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_setFullPath__SWIG_0(swigCPtr, OdDbObjectIdArray.getCPtr(fullPath), OdDbDatabase.getCPtr(pHostDatabase));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setFullPath(OdDbObjectIdArray fullPath)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_setFullPath__SWIG_1(swigCPtr, OdDbObjectIdArray.getCPtr(fullPath));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public bool isEmpty()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_isEmpty(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isValid(int validityCheckingLevel)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_isValid__SWIG_0(swigCPtr, validityCheckingLevel);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isValid()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_isValid__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isExternal()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_isExternal(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSimpleObjectId()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_isSimpleObjectId(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult getTransform(OdGeMatrix3d trans)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_getTransform(swigCPtr, OdGeMatrix3d.getCPtr(trans));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public bool remap(OdDbIdMapping idMap)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_remap(swigCPtr, OdDbIdMapping.getCPtr(idMap));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult dwgOutFields(OdDbDwgFiler pFiler, OdDbDatabase pHostDatabase)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler), OdDbDatabase.getCPtr(pHostDatabase));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult dwgInFields(OdDbDwgFiler pFiler, int ownerVersion)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler), ownerVersion);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult dxfOutFields(OdDbDxfFiler pFiler, OdDbDatabase pHostDatabase)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler), OdDbDatabase.getCPtr(pHostDatabase));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult dxfInFields(OdDbDxfFiler pFiler, OdDbDatabase pHostDatabase, int ownerVersion)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler), OdDbDatabase.getCPtr(pHostDatabase), ownerVersion);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdDbCompoundObjectId nullId()
	{
		OdDbCompoundObjectId rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCompoundObjectId>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_nullId(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbCompoundObjectId createObject()
	{
		OdDbCompoundObjectId rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCompoundObjectId>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("queryX", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodqueryX;
		}
		if (SwigDerivedClassHasMethod("isA", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodisA;
		}
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodcopyFrom;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbCompoundObjectId_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbCompoundObjectId));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}
