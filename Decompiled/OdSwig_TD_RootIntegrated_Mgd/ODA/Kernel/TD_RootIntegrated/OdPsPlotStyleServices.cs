using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdPsPlotStyleServices : OdRxModule
{
	public delegate IntPtr SwigDelegateOdPsPlotStyleServices_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPsPlotStyleServices_1();

	public delegate void SwigDelegateOdPsPlotStyleServices_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdPsPlotStyleServices_3();

	public delegate void SwigDelegateOdPsPlotStyleServices_4();

	public delegate void SwigDelegateOdPsPlotStyleServices_5();

	public delegate void SwigDelegateOdPsPlotStyleServices_6();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdPsPlotStyleServices_7();

	public delegate IntPtr SwigDelegateOdPsPlotStyleServices_8();

	public delegate IntPtr SwigDelegateOdPsPlotStyleServices_9(IntPtr pStreamBuf);

	public delegate void SwigDelegateOdPsPlotStyleServices_10(IntPtr pBuf, IntPtr pPSTab);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPsPlotStyleServices_0 swigDelegate0;

	private SwigDelegateOdPsPlotStyleServices_1 swigDelegate1;

	private SwigDelegateOdPsPlotStyleServices_2 swigDelegate2;

	private SwigDelegateOdPsPlotStyleServices_3 swigDelegate3;

	private SwigDelegateOdPsPlotStyleServices_4 swigDelegate4;

	private SwigDelegateOdPsPlotStyleServices_5 swigDelegate5;

	private SwigDelegateOdPsPlotStyleServices_6 swigDelegate6;

	private SwigDelegateOdPsPlotStyleServices_7 swigDelegate7;

	private SwigDelegateOdPsPlotStyleServices_8 swigDelegate8;

	private SwigDelegateOdPsPlotStyleServices_9 swigDelegate9;

	private SwigDelegateOdPsPlotStyleServices_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(OdPsPlotStyleTable)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPsPlotStyleServices(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleServices_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPsPlotStyleServices obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdPsPlotStyleServices(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdPsPlotStyleServices cast(OdRxObject pObj)
	{
		OdPsPlotStyleServices rXObject = Helpers.GetRXObject<OdPsPlotStyleServices>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleServices_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleServices_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleServices_isASwigExplicitOdPsPlotStyleServices(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleServices_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleServices_queryXSwigExplicitOdPsPlotStyleServices(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleServices_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPsPlotStyleServices createObject()
	{
		OdPsPlotStyleServices rXObject = Helpers.GetRXObject<OdPsPlotStyleServices>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleServices_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdPsPlotStyleTable createPlotStyleTable()
	{
		OdPsPlotStyleTable rXObject = Helpers.GetRXObject<OdPsPlotStyleTable>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleServices_createPlotStyleTable(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdPsPlotStyleTable loadPlotStyleTable(OdStreamBuf pStreamBuf)
	{
		OdPsPlotStyleTable rXObject = Helpers.GetRXObject<OdPsPlotStyleTable>(TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleServices_loadPlotStyleTable(swigCPtr, OdStreamBuf.getCPtr(pStreamBuf)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void savePlotStyleTable(OdStreamBuf pBuf, OdPsPlotStyleTable pPSTab)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleServices_savePlotStyleTable(swigCPtr, OdStreamBuf.getCPtr(pBuf), OdPsPlotStyleTable.getCPtr(pPSTab));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleServices_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPsPlotStyleServices()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdPsPlotStyleServices(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPsPlotStyleServices) != GetType();
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
		if (SwigDerivedClassHasMethod("sysData", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsysData;
		}
		if (SwigDerivedClassHasMethod("deleteModule", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddeleteModule;
		}
		if (SwigDerivedClassHasMethod("initApp", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodinitApp;
		}
		if (SwigDerivedClassHasMethod("uninitApp", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoduninitApp;
		}
		if (SwigDerivedClassHasMethod("moduleName", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodmoduleName;
		}
		if (SwigDerivedClassHasMethod("createPlotStyleTable", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodcreatePlotStyleTable;
		}
		if (SwigDerivedClassHasMethod("loadPlotStyleTable", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodloadPlotStyleTable;
		}
		if (SwigDerivedClassHasMethod("savePlotStyleTable", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsavePlotStyleTable;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdPsPlotStyleServices_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPsPlotStyleServices));
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

	private IntPtr SwigDirectorMethodsysData()
	{
		return sysData();
	}

	private void SwigDirectorMethoddeleteModule()
	{
		try
		{
			deleteModule();
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

	private void SwigDirectorMethodinitApp()
	{
		try
		{
			initApp();
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

	private void SwigDirectorMethoduninitApp()
	{
		try
		{
			uninitApp();
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodmoduleName()
	{
		return moduleName();
	}

	private IntPtr SwigDirectorMethodcreatePlotStyleTable()
	{
		return OdPsPlotStyleTable.getCPtr(createPlotStyleTable()).Handle;
	}

	private IntPtr SwigDirectorMethodloadPlotStyleTable(IntPtr pStreamBuf)
	{
		return OdPsPlotStyleTable.getCPtr(loadPlotStyleTable(Helpers.GetRXObject<OdStreamBuf>(pStreamBuf, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private void SwigDirectorMethodsavePlotStyleTable(IntPtr pBuf, IntPtr pPSTab)
	{
		try
		{
			savePlotStyleTable(Helpers.GetRXObject<OdStreamBuf>(pBuf, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdPsPlotStyleTable>(pPSTab, bOwn: true, bTryAddToTransaction: false));
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
