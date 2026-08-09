using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsMaterialCache : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGsMaterialCache_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsMaterialCache_1();

	public delegate void SwigDelegateOdGsMaterialCache_2(IntPtr pSource);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsMaterialCache_0 swigDelegate0;

	private SwigDelegateOdGsMaterialCache_1 swigDelegate1;

	private SwigDelegateOdGsMaterialCache_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsMaterialCache(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsMaterialCache obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsMaterialCache(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGsMaterialCache()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsMaterialCache(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsMaterialCache) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdGsMaterialCache cast(OdRxObject pObj)
	{
		OdGsMaterialCache rXObject = Helpers.GetRXObject<OdGsMaterialCache>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_isASwigExplicitOdGsMaterialCache(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_queryXSwigExplicitOdGsMaterialCache(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setBaseModel(OdGsBaseModel pModel)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_setBaseModel(swigCPtr, OdGsBaseModel.getCPtr(pModel));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsBaseModel baseModel()
	{
		OdGsBaseModel rXObject = Helpers.GetRXObject<OdGsBaseModel>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_baseModel__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGsMaterialCache createObject(OdGsBaseModel pModel)
	{
		OdGsMaterialCache rXObject = Helpers.GetRXObject<OdGsMaterialCache>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_createObject__SWIG_0(OdGsBaseModel.getCPtr(pModel)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsMaterialNode searchNode(OdDbStub mtl)
	{
		OdGsMaterialNode rXObject = Helpers.GetRXObject<OdGsMaterialNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_searchNode(swigCPtr, OdDbStub.getCPtr(mtl)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsMaterialNode setMaterial(OdGsBaseVectorizer view, OdDbStub mtl, bool bDontReinit)
	{
		OdGsMaterialNode rXObject = Helpers.GetRXObject<OdGsMaterialNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_setMaterial__SWIG_0(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdDbStub.getCPtr(mtl), bDontReinit), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsMaterialNode setMaterial(OdGsBaseVectorizer view, OdDbStub mtl)
	{
		OdGsMaterialNode rXObject = Helpers.GetRXObject<OdGsMaterialNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_setMaterial__SWIG_1(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdDbStub.getCPtr(mtl)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool removeNode(OdDbStub mtl)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_removeNode__SWIG_0(swigCPtr, OdDbStub.getCPtr(mtl));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool removeNode(OdGsCache pCsh)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_removeNode__SWIG_1(swigCPtr, OdGsCache.getCPtr(pCsh));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint getCacheSize()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_getCacheSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsMaterialNode getCacheNode(uint n)
	{
		OdGsMaterialNode rXObject = Helpers.GetRXObject<OdGsMaterialNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_getCacheNode(swigCPtr, n), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void addNode(OdGsBaseVectorizer view, OdDbStub mtl)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_addNode(swigCPtr, OdGsBaseVectorizer.getCPtr(view), OdDbStub.getCPtr(mtl));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearCache()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_clearCache(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void invalidateCache(OdGsBaseModule pModule)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_invalidateCache__SWIG_0(swigCPtr, OdGsBaseModule.getCPtr(pModule));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void invalidateCache()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_invalidateCache__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool saveMaterialCache(OdGsFiler pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_saveMaterialCache(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool loadMaterialCache(OdGsFiler pFiler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_loadMaterialCache(swigCPtr, OdGsFiler.getCPtr(pFiler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGsMaterialCache createObject()
	{
		OdGsMaterialCache rXObject = Helpers.GetRXObject<OdGsMaterialCache>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_createObject__SWIG_1(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMaterialCache_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsMaterialCache));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}
