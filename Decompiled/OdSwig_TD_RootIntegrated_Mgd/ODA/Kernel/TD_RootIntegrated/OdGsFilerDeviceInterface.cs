using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsFilerDeviceInterface : IDisposable
{
	public delegate bool SwigDelegateOdGsFilerDeviceInterface_0(IntPtr arg0, IntPtr arg1);

	public delegate bool SwigDelegateOdGsFilerDeviceInterface_1(IntPtr arg0);

	public delegate void SwigDelegateOdGsFilerDeviceInterface_2(IntPtr arg0);

	public delegate bool SwigDelegateOdGsFilerDeviceInterface_3(IntPtr arg0, IntPtr arg1, IntPtr arg2, IntPtr arg3);

	public delegate bool SwigDelegateOdGsFilerDeviceInterface_4(IntPtr arg0, IntPtr arg1, IntPtr arg2);

	public delegate bool SwigDelegateOdGsFilerDeviceInterface_5(IntPtr arg0, IntPtr arg1, IntPtr arg2, IntPtr arg3);

	public delegate bool SwigDelegateOdGsFilerDeviceInterface_6(IntPtr arg0, IntPtr arg1, IntPtr arg2, IntPtr arg3);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGsFilerDeviceInterface_0 swigDelegate0;

	private SwigDelegateOdGsFilerDeviceInterface_1 swigDelegate1;

	private SwigDelegateOdGsFilerDeviceInterface_2 swigDelegate2;

	private SwigDelegateOdGsFilerDeviceInterface_3 swigDelegate3;

	private SwigDelegateOdGsFilerDeviceInterface_4 swigDelegate4;

	private SwigDelegateOdGsFilerDeviceInterface_5 swigDelegate5;

	private SwigDelegateOdGsFilerDeviceInterface_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[2]
	{
		typeof(OdGsFiler),
		typeof(OdGsFilerLoadingReactor)
	};

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(OdGsFiler) };

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdGsFiler) };

	private static Type[] swigMethodTypes3 = new Type[4]
	{
		typeof(OdGsFiler),
		typeof(OdDbStub),
		typeof(OdGsModel),
		typeof(OdGsFilerObjectIdArray)
	};

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(OdGsFiler),
		typeof(OdGsFilerObjectId),
		typeof(OdGsFilerObjectIdArray)
	};

	private static Type[] swigMethodTypes5 = new Type[4]
	{
		typeof(OdGsFiler),
		typeof(OdGsFilerObjectId),
		typeof(OdGsFilerObjectIdArray),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes6 = new Type[4]
	{
		typeof(OdGsFiler),
		typeof(OdGsFilerObjectId),
		typeof(OdGsFilerObjectIdArray),
		typeof(IntPtr)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsFilerDeviceInterface(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsFilerDeviceInterface obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsFilerDeviceInterface()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsFilerDeviceInterface(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual bool prepareGsFiler(OdGsFiler arg0, OdGsFilerLoadingReactor arg1)
	{
		bool result = (SwigDerivedClassHasMethod("prepareGsFiler", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerDeviceInterface_prepareGsFilerSwigExplicitOdGsFilerDeviceInterface__SWIG_0(swigCPtr, OdGsFiler.getCPtr(arg0), OdGsFilerLoadingReactor.getCPtr(arg1)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerDeviceInterface_prepareGsFiler__SWIG_0(swigCPtr, OdGsFiler.getCPtr(arg0), OdGsFilerLoadingReactor.getCPtr(arg1)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool prepareGsFiler(OdGsFiler arg0)
	{
		bool result = (SwigDerivedClassHasMethod("prepareGsFiler", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerDeviceInterface_prepareGsFilerSwigExplicitOdGsFilerDeviceInterface__SWIG_1(swigCPtr, OdGsFiler.getCPtr(arg0)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerDeviceInterface_prepareGsFiler__SWIG_1(swigCPtr, OdGsFiler.getCPtr(arg0)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void flushGsFiler(OdGsFiler arg0)
	{
		if (SwigDerivedClassHasMethod("flushGsFiler", swigMethodTypes2))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerDeviceInterface_flushGsFilerSwigExplicitOdGsFilerDeviceInterface(swigCPtr, OdGsFiler.getCPtr(arg0));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerDeviceInterface_flushGsFiler(swigCPtr, OdGsFiler.getCPtr(arg0));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool prepareSaveObjects(OdGsFiler arg0, OdDbStub arg1, OdGsModel arg2, OdGsFilerObjectIdArray arg3)
	{
		bool result = (SwigDerivedClassHasMethod("prepareSaveObjects", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerDeviceInterface_prepareSaveObjectsSwigExplicitOdGsFilerDeviceInterface(swigCPtr, OdGsFiler.getCPtr(arg0), OdDbStub.getCPtr(arg1), OdGsModel.getCPtr(arg2), OdGsFilerObjectIdArray.getCPtr(arg3)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerDeviceInterface_prepareSaveObjects(swigCPtr, OdGsFiler.getCPtr(arg0), OdDbStub.getCPtr(arg1), OdGsModel.getCPtr(arg2), OdGsFilerObjectIdArray.getCPtr(arg3)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool saveObject(OdGsFiler arg0, OdGsFilerObjectId arg1, OdGsFilerObjectIdArray arg2)
	{
		bool result = (SwigDerivedClassHasMethod("saveObject", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerDeviceInterface_saveObjectSwigExplicitOdGsFilerDeviceInterface(swigCPtr, OdGsFiler.getCPtr(arg0), OdGsFilerObjectId.getCPtr(arg1), OdGsFilerObjectIdArray.getCPtr(arg2)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerDeviceInterface_saveObject(swigCPtr, OdGsFiler.getCPtr(arg0), OdGsFilerObjectId.getCPtr(arg1), OdGsFilerObjectIdArray.getCPtr(arg2)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool loadObject(OdGsFiler arg0, OdGsFilerObjectId arg1, OdGsFilerObjectIdArray arg2, IntPtr arg3)
	{
		bool result = (SwigDerivedClassHasMethod("loadObject", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerDeviceInterface_loadObjectSwigExplicitOdGsFilerDeviceInterface(swigCPtr, OdGsFiler.getCPtr(arg0), OdGsFilerObjectId.getCPtr(arg1), OdGsFilerObjectIdArray.getCPtr(arg2), arg3) : TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerDeviceInterface_loadObject(swigCPtr, OdGsFiler.getCPtr(arg0), OdGsFilerObjectId.getCPtr(arg1), OdGsFilerObjectIdArray.getCPtr(arg2), arg3));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool loadReferenced(OdGsFiler arg0, OdGsFilerObjectId arg1, OdGsFilerObjectIdArray arg2, IntPtr arg3)
	{
		bool result = (SwigDerivedClassHasMethod("loadReferenced", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerDeviceInterface_loadReferencedSwigExplicitOdGsFilerDeviceInterface(swigCPtr, OdGsFiler.getCPtr(arg0), OdGsFilerObjectId.getCPtr(arg1), OdGsFilerObjectIdArray.getCPtr(arg2), arg3) : TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerDeviceInterface_loadReferenced(swigCPtr, OdGsFiler.getCPtr(arg0), OdGsFilerObjectId.getCPtr(arg1), OdGsFilerObjectIdArray.getCPtr(arg2), arg3));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsFilerDeviceInterface()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerDeviceInterface(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsFilerDeviceInterface) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("prepareGsFiler", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodprepareGsFiler__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("prepareGsFiler", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodprepareGsFiler__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("flushGsFiler", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodflushGsFiler;
		}
		if (SwigDerivedClassHasMethod("prepareSaveObjects", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodprepareSaveObjects;
		}
		if (SwigDerivedClassHasMethod("saveObject", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsaveObject;
		}
		if (SwigDerivedClassHasMethod("loadObject", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodloadObject;
		}
		if (SwigDerivedClassHasMethod("loadReferenced", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodloadReferenced;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerDeviceInterface_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsFilerDeviceInterface));
	}

	private bool SwigDirectorMethodprepareGsFiler__SWIG_0(IntPtr arg0, IntPtr arg1)
	{
		return prepareGsFiler(Helpers.GetRXObject<OdGsFiler>(arg0, bOwn: false, bTryAddToTransaction: false), (arg1 == IntPtr.Zero) ? null : new OdGsFilerLoadingReactor(arg1, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodprepareGsFiler__SWIG_1(IntPtr arg0)
	{
		return prepareGsFiler(Helpers.GetRXObject<OdGsFiler>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodflushGsFiler(IntPtr arg0)
	{
		try
		{
			flushGsFiler(Helpers.GetRXObject<OdGsFiler>(arg0, bOwn: false, bTryAddToTransaction: false));
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

	private bool SwigDirectorMethodprepareSaveObjects(IntPtr arg0, IntPtr arg1, IntPtr arg2, IntPtr arg3)
	{
		return prepareSaveObjects(Helpers.GetRXObject<OdGsFiler>(arg0, bOwn: false, bTryAddToTransaction: false), (arg1 == IntPtr.Zero) ? null : new OdDbStub(arg1, cMemoryOwn: false), Helpers.GetRXObject<OdGsModel>(arg2, bOwn: false, bTryAddToTransaction: false), new OdGsFilerObjectIdArray(arg3, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodsaveObject(IntPtr arg0, IntPtr arg1, IntPtr arg2)
	{
		return saveObject(Helpers.GetRXObject<OdGsFiler>(arg0, bOwn: false, bTryAddToTransaction: false), new OdGsFilerObjectId(arg1, cMemoryOwn: false), new OdGsFilerObjectIdArray(arg2, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodloadObject(IntPtr arg0, IntPtr arg1, IntPtr arg2, IntPtr arg3)
	{
		return loadObject(Helpers.GetRXObject<OdGsFiler>(arg0, bOwn: false, bTryAddToTransaction: false), new OdGsFilerObjectId(arg1, cMemoryOwn: false), new OdGsFilerObjectIdArray(arg2, cMemoryOwn: false), arg3);
	}

	private bool SwigDirectorMethodloadReferenced(IntPtr arg0, IntPtr arg1, IntPtr arg2, IntPtr arg3)
	{
		return loadReferenced(Helpers.GetRXObject<OdGsFiler>(arg0, bOwn: false, bTryAddToTransaction: false), new OdGsFilerObjectId(arg1, cMemoryOwn: false), new OdGsFilerObjectIdArray(arg2, cMemoryOwn: false), arg3);
	}
}
