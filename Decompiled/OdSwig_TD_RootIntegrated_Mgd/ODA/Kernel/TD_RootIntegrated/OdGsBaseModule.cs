using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsBaseModule : OdGsModule
{
	public class GsViewUpdateEvent : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GsViewUpdateEvent(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(GsViewUpdateEvent obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~GsViewUpdateEvent()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBaseModule_GsViewUpdateEvent(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public GsViewUpdateEvent(OdGsBaseModule pModule, OdGsView pView, int flags)
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBaseModule_GsViewUpdateEvent(OdGsBaseModule.getCPtr(pModule), OdGsView.getCPtr(pView), flags), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public delegate IntPtr SwigDelegateOdGsBaseModule_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsBaseModule_1();

	public delegate void SwigDelegateOdGsBaseModule_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGsBaseModule_3();

	public delegate void SwigDelegateOdGsBaseModule_4();

	public delegate void SwigDelegateOdGsBaseModule_5();

	public delegate void SwigDelegateOdGsBaseModule_6();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdGsBaseModule_7();

	public delegate IntPtr SwigDelegateOdGsBaseModule_8();

	public delegate IntPtr SwigDelegateOdGsBaseModule_9();

	public delegate void SwigDelegateOdGsBaseModule_10(IntPtr pReactor);

	public delegate void SwigDelegateOdGsBaseModule_11(IntPtr pReactor);

	public delegate IntPtr SwigDelegateOdGsBaseModule_12();

	public delegate IntPtr SwigDelegateOdGsBaseModule_13();

	public delegate IntPtr SwigDelegateOdGsBaseModule_14();

	public delegate IntPtr SwigDelegateOdGsBaseModule_15();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsBaseModule_0 swigDelegate0;

	private SwigDelegateOdGsBaseModule_1 swigDelegate1;

	private SwigDelegateOdGsBaseModule_2 swigDelegate2;

	private SwigDelegateOdGsBaseModule_3 swigDelegate3;

	private SwigDelegateOdGsBaseModule_4 swigDelegate4;

	private SwigDelegateOdGsBaseModule_5 swigDelegate5;

	private SwigDelegateOdGsBaseModule_6 swigDelegate6;

	private SwigDelegateOdGsBaseModule_7 swigDelegate7;

	private SwigDelegateOdGsBaseModule_8 swigDelegate8;

	private SwigDelegateOdGsBaseModule_9 swigDelegate9;

	private SwigDelegateOdGsBaseModule_10 swigDelegate10;

	private SwigDelegateOdGsBaseModule_11 swigDelegate11;

	private SwigDelegateOdGsBaseModule_12 swigDelegate12;

	private SwigDelegateOdGsBaseModule_13 swigDelegate13;

	private SwigDelegateOdGsBaseModule_14 swigDelegate14;

	private SwigDelegateOdGsBaseModule_15 swigDelegate15;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdGsReactor) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdGsReactor) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsBaseModule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsBaseModule obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsBaseModule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected virtual OdGsBaseVectorizeDevice createDeviceObject()
	{
		OdGsBaseVectorizeDevice rXObject = Helpers.GetRXObject<OdGsBaseVectorizeDevice>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_createDeviceObject(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected virtual OdGsViewImpl createViewObject()
	{
		OdGsViewImpl rXObject = Helpers.GetRXObject<OdGsViewImpl>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_createViewObject(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected virtual OdGsBaseVectorizeDevice createBitmapDeviceObject()
	{
		OdGsBaseVectorizeDevice rXObject = Helpers.GetRXObject<OdGsBaseVectorizeDevice>(SwigDerivedClassHasMethod("createBitmapDeviceObject", swigMethodTypes14) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_createBitmapDeviceObjectSwigExplicitOdGsBaseModule(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_createBitmapDeviceObject(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected virtual OdGsViewImpl createBitmapViewObject()
	{
		OdGsViewImpl rXObject = Helpers.GetRXObject<OdGsViewImpl>(SwigDerivedClassHasMethod("createBitmapViewObject", swigMethodTypes15) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_createBitmapViewObjectSwigExplicitOdGsBaseModule(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_createBitmapViewObject(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected OdGsBaseModule()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsBaseModule(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsBaseModule) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdGsBaseModule cast(OdRxObject pObj)
	{
		OdGsBaseModule rXObject = Helpers.GetRXObject<OdGsBaseModule>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_isASwigExplicitOdGsBaseModule(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_queryXSwigExplicitOdGsBaseModule(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGsBaseModule createObject()
	{
		OdGsBaseModule rXObject = Helpers.GetRXObject<OdGsBaseModule>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void fire_viewToBeDestroyed(OdGsView pView)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_fire_viewToBeDestroyed(swigCPtr, OdGsView.getCPtr(pView));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGsDevice createDevice()
	{
		OdGsDevice rXObject = Helpers.GetRXObject<OdGsDevice>(SwigDerivedClassHasMethod("createDevice", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_createDeviceSwigExplicitOdGsBaseModule(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_createDevice(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdGsDevice createBitmapDevice()
	{
		OdGsDevice rXObject = Helpers.GetRXObject<OdGsDevice>(SwigDerivedClassHasMethod("createBitmapDevice", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_createBitmapDeviceSwigExplicitOdGsBaseModule(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_createBitmapDevice(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsViewImpl createView()
	{
		OdGsViewImpl rXObject = Helpers.GetRXObject<OdGsViewImpl>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_createView(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsViewImpl createBitmapView()
	{
		OdGsViewImpl rXObject = Helpers.GetRXObject<OdGsViewImpl>(TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_createBitmapView(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void addReactor(OdGsReactor pReactor)
	{
		if (SwigDerivedClassHasMethod("addReactor", swigMethodTypes10))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_addReactorSwigExplicitOdGsBaseModule(swigCPtr, OdGsReactor.getCPtr(pReactor));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_addReactor(swigCPtr, OdGsReactor.getCPtr(pReactor));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void removeReactor(OdGsReactor pReactor)
	{
		if (SwigDerivedClassHasMethod("removeReactor", swigMethodTypes11))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_removeReactorSwigExplicitOdGsBaseModule(swigCPtr, OdGsReactor.getCPtr(pReactor));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_removeReactor(swigCPtr, OdGsReactor.getCPtr(pReactor));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void initApp()
	{
		if (SwigDerivedClassHasMethod("initApp", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_initAppSwigExplicitOdGsBaseModule(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_initApp(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void uninitApp()
	{
		if (SwigDerivedClassHasMethod("uninitApp", swigMethodTypes6))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_uninitAppSwigExplicitOdGsBaseModule(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_uninitApp(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		if (SwigDerivedClassHasMethod("createDevice", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodcreateDevice;
		}
		if (SwigDerivedClassHasMethod("createBitmapDevice", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodcreateBitmapDevice;
		}
		if (SwigDerivedClassHasMethod("addReactor", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodaddReactor;
		}
		if (SwigDerivedClassHasMethod("removeReactor", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodremoveReactor;
		}
		if (SwigDerivedClassHasMethod("createDeviceObject", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodcreateDeviceObject;
		}
		if (SwigDerivedClassHasMethod("createViewObject", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodcreateViewObject;
		}
		if (SwigDerivedClassHasMethod("createBitmapDeviceObject", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodcreateBitmapDeviceObject;
		}
		if (SwigDerivedClassHasMethod("createBitmapViewObject", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodcreateBitmapViewObject;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsBaseModule_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsBaseModule));
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

	private IntPtr SwigDirectorMethodcreateDevice()
	{
		return OdGsDevice.getCPtr(createDevice()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateBitmapDevice()
	{
		return OdGsDevice.getCPtr(createBitmapDevice()).Handle;
	}

	private void SwigDirectorMethodaddReactor(IntPtr pReactor)
	{
		try
		{
			addReactor(Helpers.GetRXObject<OdGsReactor>(pReactor, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodremoveReactor(IntPtr pReactor)
	{
		try
		{
			removeReactor(Helpers.GetRXObject<OdGsReactor>(pReactor, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodcreateDeviceObject()
	{
		return OdGsBaseVectorizeDevice.getCPtr(createDeviceObject()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateViewObject()
	{
		return OdGsViewImpl.getCPtr(createViewObject()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateBitmapDeviceObject()
	{
		return OdGsBaseVectorizeDevice.getCPtr(createBitmapDeviceObject()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateBitmapViewObject()
	{
		return OdGsViewImpl.getCPtr(createBitmapViewObject()).Handle;
	}
}
