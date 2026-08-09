using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbParametrizedSF : OdDbSelectionFilter
{
	public delegate IntPtr SwigDelegateOdDbParametrizedSF_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbParametrizedSF_1();

	public delegate void SwigDelegateOdDbParametrizedSF_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbParametrizedSF_3(IntPtr entityId);

	public delegate void SwigDelegateOdDbParametrizedSF_4(IntPtr arg0, IntPtr arg1);

	public delegate void SwigDelegateOdDbParametrizedSF_5(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdDbParametrizedSF_6();

	public delegate IntPtr SwigDelegateOdDbParametrizedSF_7();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbParametrizedSF_0 swigDelegate0;

	private SwigDelegateOdDbParametrizedSF_1 swigDelegate1;

	private SwigDelegateOdDbParametrizedSF_2 swigDelegate2;

	private SwigDelegateOdDbParametrizedSF_3 swigDelegate3;

	private SwigDelegateOdDbParametrizedSF_4 swigDelegate4;

	private SwigDelegateOdDbParametrizedSF_5 swigDelegate5;

	private SwigDelegateOdDbParametrizedSF_6 swigDelegate6;

	private SwigDelegateOdDbParametrizedSF_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdDbObjectId) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdResBuf),
		typeof(OdDbDatabase)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdResBuf) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbParametrizedSF(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParametrizedSF_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbParametrizedSF obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbParametrizedSF(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdDbParametrizedSF()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbParametrizedSF(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbParametrizedSF) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public static OdDbParametrizedSF createObject(OdResBuf pSpec, OdDbDatabase pDb)
	{
		OdDbParametrizedSF rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbParametrizedSF>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParametrizedSF_createObject(OdResBuf.getCPtr(pSpec), OdDbDatabase.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setSpecification(OdResBuf arg0, OdDbDatabase arg1)
	{
		if (SwigDerivedClassHasMethod("setSpecification", swigMethodTypes4))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParametrizedSF_setSpecificationSwigExplicitOdDbParametrizedSF__SWIG_0(swigCPtr, OdResBuf.getCPtr(arg0), OdDbDatabase.getCPtr(arg1));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParametrizedSF_setSpecification__SWIG_0(swigCPtr, OdResBuf.getCPtr(arg0), OdDbDatabase.getCPtr(arg1));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setSpecification(OdResBuf arg0)
	{
		if (SwigDerivedClassHasMethod("setSpecification", swigMethodTypes5))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParametrizedSF_setSpecificationSwigExplicitOdDbParametrizedSF__SWIG_1(swigCPtr, OdResBuf.getCPtr(arg0));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParametrizedSF_setSpecification__SWIG_1(swigCPtr, OdResBuf.getCPtr(arg0));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResBuf specification()
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(SwigDerivedClassHasMethod("specification", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParametrizedSF_specificationSwigExplicitOdDbParametrizedSF(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParametrizedSF_specification(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase database()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(SwigDerivedClassHasMethod("database", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParametrizedSF_databaseSwigExplicitOdDbParametrizedSF(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParametrizedSF_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParametrizedSF_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("accept", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodaccept;
		}
		if (SwigDerivedClassHasMethod("setSpecification", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetSpecification__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setSpecification", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetSpecification__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("specification", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodspecification;
		}
		if (SwigDerivedClassHasMethod("database", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethoddatabase;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParametrizedSF_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbParametrizedSF));
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

	private bool SwigDirectorMethodaccept(IntPtr entityId)
	{
		return accept(new OdDbObjectId(entityId, cMemoryOwn: false));
	}

	private void SwigDirectorMethodsetSpecification__SWIG_0(IntPtr arg0, IntPtr arg1)
	{
		try
		{
			setSpecification(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(arg0, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(arg1, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodsetSpecification__SWIG_1(IntPtr arg0)
	{
		try
		{
			setSpecification(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(arg0, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodspecification()
	{
		return OdResBuf.getCPtr(specification()).Handle;
	}

	private IntPtr SwigDirectorMethoddatabase()
	{
		return OdDbDatabase.getCPtr(database()).Handle;
	}
}
