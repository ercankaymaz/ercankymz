using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbBaseLongTransactionPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbBaseLongTransactionPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbBaseLongTransactionPE_1();

	public delegate void SwigDelegateOdDbBaseLongTransactionPE_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdDbBaseLongTransactionPE_3(IntPtr pLT);

	public delegate IntPtr SwigDelegateOdDbBaseLongTransactionPE_4(IntPtr pLT);

	public delegate bool SwigDelegateOdDbBaseLongTransactionPE_5(IntPtr pLT, IntPtr pId);

	public delegate bool SwigDelegateOdDbBaseLongTransactionPE_6(IntPtr arg0, IntPtr arg1);

	public delegate IntPtr SwigDelegateOdDbBaseLongTransactionPE_7(IntPtr pLT, bool incRemoved, bool incSecondary);

	public delegate IntPtr SwigDelegateOdDbBaseLongTransactionPE_8(IntPtr pLT, bool incRemoved);

	public delegate IntPtr SwigDelegateOdDbBaseLongTransactionPE_9(IntPtr pLT);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbBaseLongTransactionPE_0 swigDelegate0;

	private SwigDelegateOdDbBaseLongTransactionPE_1 swigDelegate1;

	private SwigDelegateOdDbBaseLongTransactionPE_2 swigDelegate2;

	private SwigDelegateOdDbBaseLongTransactionPE_3 swigDelegate3;

	private SwigDelegateOdDbBaseLongTransactionPE_4 swigDelegate4;

	private SwigDelegateOdDbBaseLongTransactionPE_5 swigDelegate5;

	private SwigDelegateOdDbBaseLongTransactionPE_6 swigDelegate6;

	private SwigDelegateOdDbBaseLongTransactionPE_7 swigDelegate7;

	private SwigDelegateOdDbBaseLongTransactionPE_8 swigDelegate8;

	private SwigDelegateOdDbBaseLongTransactionPE_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes7 = new Type[3]
	{
		typeof(OdRxObject),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBaseLongTransactionPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBaseLongTransactionPE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbBaseLongTransactionPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbBaseLongTransactionPE cast(OdRxObject pObj)
	{
		OdDbBaseLongTransactionPE rXObject = Helpers.GetRXObject<OdDbBaseLongTransactionPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_isASwigExplicitOdDbBaseLongTransactionPE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_queryXSwigExplicitOdDbBaseLongTransactionPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseLongTransactionPE createObject()
	{
		OdDbBaseLongTransactionPE rXObject = Helpers.GetRXObject<OdDbBaseLongTransactionPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbStub destinationBlock(OdRxObject pLT)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_destinationBlock(swigCPtr, OdRxObject.getCPtr(pLT));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxObject getDatabase(OdRxObject pLT)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_getDatabase(swigCPtr, OdRxObject.getCPtr(pLT)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool workSetHas(OdRxObject pLT, OdDbStub pId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_workSetHas(swigCPtr, OdRxObject.getCPtr(pLT), OdDbStub.getCPtr(pId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool needsFading(OdRxObject arg0, OdDbStub arg1)
	{
		bool result = (SwigDerivedClassHasMethod("needsFading", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_needsFadingSwigExplicitOdDbBaseLongTransactionPE(swigCPtr, OdRxObject.getCPtr(arg0), OdDbStub.getCPtr(arg1)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_needsFading(swigCPtr, OdRxObject.getCPtr(arg0), OdDbStub.getCPtr(arg1)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxIterator newWorkSetIterator(OdRxObject pLT, bool incRemoved, bool incSecondary)
	{
		OdRxIterator rXObject = Helpers.GetRXObject<OdRxIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_newWorkSetIterator__SWIG_0(swigCPtr, OdRxObject.getCPtr(pLT), incRemoved, incSecondary), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxIterator newWorkSetIterator(OdRxObject pLT, bool incRemoved)
	{
		OdRxIterator rXObject = Helpers.GetRXObject<OdRxIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_newWorkSetIterator__SWIG_1(swigCPtr, OdRxObject.getCPtr(pLT), incRemoved), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxIterator newWorkSetIterator(OdRxObject pLT)
	{
		OdRxIterator rXObject = Helpers.GetRXObject<OdRxIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_newWorkSetIterator__SWIG_2(swigCPtr, OdRxObject.getCPtr(pLT)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbBaseLongTransactionPE()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbBaseLongTransactionPE(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbBaseLongTransactionPE) != GetType();
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
		if (SwigDerivedClassHasMethod("destinationBlock", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddestinationBlock;
		}
		if (SwigDerivedClassHasMethod("getDatabase", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetDatabase;
		}
		if (SwigDerivedClassHasMethod("workSetHas", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodworkSetHas;
		}
		if (SwigDerivedClassHasMethod("needsFading", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodneedsFading;
		}
		if (SwigDerivedClassHasMethod("newWorkSetIterator", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodnewWorkSetIterator__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("newWorkSetIterator", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodnewWorkSetIterator__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("newWorkSetIterator", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodnewWorkSetIterator__SWIG_2;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseLongTransactionPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbBaseLongTransactionPE));
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

	private IntPtr SwigDirectorMethoddestinationBlock(IntPtr pLT)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(destinationBlock(Helpers.GetRXObject<OdRxObject>(pLT, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodgetDatabase(IntPtr pLT)
	{
		return OdRxObject.getCPtr(getDatabase(Helpers.GetRXObject<OdRxObject>(pLT, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private bool SwigDirectorMethodworkSetHas(IntPtr pLT, IntPtr pId)
	{
		return workSetHas(Helpers.GetRXObject<OdRxObject>(pLT, bOwn: false, bTryAddToTransaction: false), (pId == IntPtr.Zero) ? null : new OdDbStub(pId, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodneedsFading(IntPtr arg0, IntPtr arg1)
	{
		return needsFading(Helpers.GetRXObject<OdRxObject>(arg0, bOwn: false, bTryAddToTransaction: false), (arg1 == IntPtr.Zero) ? null : new OdDbStub(arg1, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodnewWorkSetIterator__SWIG_0(IntPtr pLT, bool incRemoved, bool incSecondary)
	{
		return OdRxIterator.getCPtr(newWorkSetIterator(Helpers.GetRXObject<OdRxObject>(pLT, bOwn: false, bTryAddToTransaction: false), incRemoved, incSecondary)).Handle;
	}

	private IntPtr SwigDirectorMethodnewWorkSetIterator__SWIG_1(IntPtr pLT, bool incRemoved)
	{
		return OdRxIterator.getCPtr(newWorkSetIterator(Helpers.GetRXObject<OdRxObject>(pLT, bOwn: false, bTryAddToTransaction: false), incRemoved)).Handle;
	}

	private IntPtr SwigDirectorMethodnewWorkSetIterator__SWIG_2(IntPtr pLT)
	{
		return OdRxIterator.getCPtr(newWorkSetIterator(Helpers.GetRXObject<OdRxObject>(pLT, bOwn: false, bTryAddToTransaction: false))).Handle;
	}
}
