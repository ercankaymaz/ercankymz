using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbObjectContextInterface : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbObjectContextInterface_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbObjectContextInterface_1();

	public delegate void SwigDelegateOdDbObjectContextInterface_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbObjectContextInterface_3(IntPtr pObject, [MarshalAs(UnmanagedType.LPWStr)] string collectionName);

	public delegate bool SwigDelegateOdDbObjectContextInterface_4(IntPtr pObject, IntPtr context);

	public delegate int SwigDelegateOdDbObjectContextInterface_5(IntPtr pObject, IntPtr context);

	public delegate int SwigDelegateOdDbObjectContextInterface_6(IntPtr pObject, IntPtr context);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbObjectContextInterface_0 swigDelegate0;

	private SwigDelegateOdDbObjectContextInterface_1 swigDelegate1;

	private SwigDelegateOdDbObjectContextInterface_2 swigDelegate2;

	private SwigDelegateOdDbObjectContextInterface_3 swigDelegate3;

	private SwigDelegateOdDbObjectContextInterface_4 swigDelegate4;

	private SwigDelegateOdDbObjectContextInterface_5 swigDelegate5;

	private SwigDelegateOdDbObjectContextInterface_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(string)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObjectContext)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObjectContext)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObjectContext)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbObjectContextInterface(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextInterface_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbObjectContextInterface obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbObjectContextInterface(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbObjectContextInterface cast(OdRxObject pObj)
	{
		OdDbObjectContextInterface rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextInterface>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextInterface_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextInterface_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextInterface_isASwigExplicitOdDbObjectContextInterface(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextInterface_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextInterface_queryXSwigExplicitOdDbObjectContextInterface(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextInterface_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbObjectContextInterface createObject()
	{
		OdDbObjectContextInterface rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextInterface>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextInterface_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool supportsCollection(OdDbObject pObject, string collectionName)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextInterface_supportsCollection(swigCPtr, OdDbObject.getCPtr(pObject), collectionName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hasContext(OdDbObject pObject, OdDbObjectContext context)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextInterface_hasContext(swigCPtr, OdDbObject.getCPtr(pObject), OdDbObjectContext.getCPtr(context));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult addContext(OdDbObject pObject, OdDbObjectContext context)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextInterface_addContext(swigCPtr, OdDbObject.getCPtr(pObject), OdDbObjectContext.getCPtr(context));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult removeContext(OdDbObject pObject, OdDbObjectContext context)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextInterface_removeContext(swigCPtr, OdDbObject.getCPtr(pObject), OdDbObjectContext.getCPtr(context));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextInterface_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectContextInterface()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbObjectContextInterface(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbObjectContextInterface) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
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
		if (SwigDerivedClassHasMethod("supportsCollection", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsupportsCollection;
		}
		if (SwigDerivedClassHasMethod("hasContext", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodhasContext;
		}
		if (SwigDerivedClassHasMethod("addContext", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodaddContext;
		}
		if (SwigDerivedClassHasMethod("removeContext", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodremoveContext;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextInterface_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbObjectContextInterface));
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

	private bool SwigDirectorMethodsupportsCollection(IntPtr pObject, [MarshalAs(UnmanagedType.LPWStr)] string collectionName)
	{
		return supportsCollection(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false), collectionName);
	}

	private bool SwigDirectorMethodhasContext(IntPtr pObject, IntPtr context)
	{
		return hasContext(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(context, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodaddContext(IntPtr pObject, IntPtr context)
	{
		return (int)addContext(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(context, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodremoveContext(IntPtr pObject, IntPtr context)
	{
		return (int)removeContext(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObject, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(context, bOwn: false, bTryAddToTransaction: false));
	}
}
