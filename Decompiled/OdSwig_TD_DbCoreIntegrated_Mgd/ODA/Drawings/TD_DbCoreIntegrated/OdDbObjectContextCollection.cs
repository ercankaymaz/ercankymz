using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbObjectContextCollection : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbObjectContextCollection_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbObjectContextCollection_1();

	public delegate void SwigDelegateOdDbObjectContextCollection_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbObjectContextCollection_3();

	public delegate IntPtr SwigDelegateOdDbObjectContextCollection_4(IntPtr pRequestingObject);

	public delegate int SwigDelegateOdDbObjectContextCollection_5(IntPtr pContext);

	public delegate int SwigDelegateOdDbObjectContextCollection_6(IntPtr pContext);

	public delegate int SwigDelegateOdDbObjectContextCollection_7([MarshalAs(UnmanagedType.LPWStr)] string contextName);

	public delegate int SwigDelegateOdDbObjectContextCollection_8(IntPtr pContext);

	public delegate int SwigDelegateOdDbObjectContextCollection_9();

	public delegate bool SwigDelegateOdDbObjectContextCollection_10();

	public delegate IntPtr SwigDelegateOdDbObjectContextCollection_11([MarshalAs(UnmanagedType.LPWStr)] string contextName);

	public delegate bool SwigDelegateOdDbObjectContextCollection_12([MarshalAs(UnmanagedType.LPWStr)] string contextName);

	public delegate IntPtr SwigDelegateOdDbObjectContextCollection_13();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbObjectContextCollection_0 swigDelegate0;

	private SwigDelegateOdDbObjectContextCollection_1 swigDelegate1;

	private SwigDelegateOdDbObjectContextCollection_2 swigDelegate2;

	private SwigDelegateOdDbObjectContextCollection_3 swigDelegate3;

	private SwigDelegateOdDbObjectContextCollection_4 swigDelegate4;

	private SwigDelegateOdDbObjectContextCollection_5 swigDelegate5;

	private SwigDelegateOdDbObjectContextCollection_6 swigDelegate6;

	private SwigDelegateOdDbObjectContextCollection_7 swigDelegate7;

	private SwigDelegateOdDbObjectContextCollection_8 swigDelegate8;

	private SwigDelegateOdDbObjectContextCollection_9 swigDelegate9;

	private SwigDelegateOdDbObjectContextCollection_10 swigDelegate10;

	private SwigDelegateOdDbObjectContextCollection_11 swigDelegate11;

	private SwigDelegateOdDbObjectContextCollection_12 swigDelegate12;

	private SwigDelegateOdDbObjectContextCollection_13 swigDelegate13;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbObjectContext) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdDbObjectContext) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdDbObjectContext) };

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes13 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbObjectContextCollection(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbObjectContextCollection obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbObjectContextCollection(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbObjectContextCollection cast(OdRxObject pObj)
	{
		OdDbObjectContextCollection rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextCollection>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_isASwigExplicitOdDbObjectContextCollection(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_queryXSwigExplicitOdDbObjectContextCollection(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbObjectContextCollection createObject()
	{
		OdDbObjectContextCollection rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextCollection>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string name()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_name(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectContext currentContext(OdDbObject pRequestingObject)
	{
		OdDbObjectContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_currentContext(swigCPtr, OdDbObject.getCPtr(pRequestingObject)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult setCurrentContext(OdDbObjectContext pContext)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_setCurrentContext(swigCPtr, OdDbObjectContext.getCPtr(pContext));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult addContext(OdDbObjectContext pContext)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_addContext(swigCPtr, OdDbObjectContext.getCPtr(pContext));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult removeContext(string contextName)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_removeContext(swigCPtr, contextName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult lockContext(OdDbObjectContext pContext)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_lockContext(swigCPtr, OdDbObjectContext.getCPtr(pContext));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult unlockContext()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_unlockContext(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool locked()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_locked(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectContext getContext(string contextName)
	{
		OdDbObjectContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_getContext(swigCPtr, contextName), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool hasContext(string contextName)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_hasContext(swigCPtr, contextName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObjectContextCollectionIterator newIterator()
	{
		OdDbObjectContextCollectionIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContextCollectionIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_newIterator(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectContextCollection()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbObjectContextCollection(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbObjectContextCollection) != GetType();
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
		if (SwigDerivedClassHasMethod("name", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodname;
		}
		if (SwigDerivedClassHasMethod("currentContext", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodcurrentContext;
		}
		if (SwigDerivedClassHasMethod("setCurrentContext", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetCurrentContext;
		}
		if (SwigDerivedClassHasMethod("addContext", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodaddContext;
		}
		if (SwigDerivedClassHasMethod("removeContext", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodremoveContext;
		}
		if (SwigDerivedClassHasMethod("lockContext", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodlockContext;
		}
		if (SwigDerivedClassHasMethod("unlockContext", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodunlockContext;
		}
		if (SwigDerivedClassHasMethod("locked", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodlocked;
		}
		if (SwigDerivedClassHasMethod("getContext", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetContext;
		}
		if (SwigDerivedClassHasMethod("hasContext", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodhasContext;
		}
		if (SwigDerivedClassHasMethod("newIterator", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodnewIterator;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectContextCollection_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbObjectContextCollection));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodname()
	{
		return name();
	}

	private IntPtr SwigDirectorMethodcurrentContext(IntPtr pRequestingObject)
	{
		return OdDbObjectContext.getCPtr(currentContext(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pRequestingObject, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private int SwigDirectorMethodsetCurrentContext(IntPtr pContext)
	{
		return (int)setCurrentContext(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(pContext, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodaddContext(IntPtr pContext)
	{
		return (int)addContext(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(pContext, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodremoveContext([MarshalAs(UnmanagedType.LPWStr)] string contextName)
	{
		return (int)removeContext(contextName);
	}

	private int SwigDirectorMethodlockContext(IntPtr pContext)
	{
		return (int)lockContext(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectContext>(pContext, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodunlockContext()
	{
		return (int)unlockContext();
	}

	private bool SwigDirectorMethodlocked()
	{
		return locked();
	}

	private IntPtr SwigDirectorMethodgetContext([MarshalAs(UnmanagedType.LPWStr)] string contextName)
	{
		return OdDbObjectContext.getCPtr(getContext(contextName)).Handle;
	}

	private bool SwigDirectorMethodhasContext([MarshalAs(UnmanagedType.LPWStr)] string contextName)
	{
		return hasContext(contextName);
	}

	private IntPtr SwigDirectorMethodnewIterator()
	{
		return OdDbObjectContextCollectionIterator.getCPtr(newIterator()).Handle;
	}
}
