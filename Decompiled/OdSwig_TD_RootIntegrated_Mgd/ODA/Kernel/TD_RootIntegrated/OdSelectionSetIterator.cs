using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdSelectionSetIterator : OdRxObject
{
	public delegate IntPtr SwigDelegateOdSelectionSetIterator_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdSelectionSetIterator_1();

	public delegate void SwigDelegateOdSelectionSetIterator_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdSelectionSetIterator_3();

	public delegate bool SwigDelegateOdSelectionSetIterator_4();

	public delegate bool SwigDelegateOdSelectionSetIterator_5();

	public delegate uint SwigDelegateOdSelectionSetIterator_6();

	public delegate bool SwigDelegateOdSelectionSetIterator_7(uint i, IntPtr path);

	public delegate IntPtr SwigDelegateOdSelectionSetIterator_8();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdSelectionSetIterator_0 swigDelegate0;

	private SwigDelegateOdSelectionSetIterator_1 swigDelegate1;

	private SwigDelegateOdSelectionSetIterator_2 swigDelegate2;

	private SwigDelegateOdSelectionSetIterator_3 swigDelegate3;

	private SwigDelegateOdSelectionSetIterator_4 swigDelegate4;

	private SwigDelegateOdSelectionSetIterator_5 swigDelegate5;

	private SwigDelegateOdSelectionSetIterator_6 swigDelegate6;

	private SwigDelegateOdSelectionSetIterator_7 swigDelegate7;

	private SwigDelegateOdSelectionSetIterator_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(uint),
		typeof(OdDbBaseFullSubentPath)
	};

	private static Type[] swigMethodTypes8 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSelectionSetIterator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSetIterator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSelectionSetIterator obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdSelectionSetIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdSelectionSetIterator cast(OdRxObject pObj)
	{
		OdSelectionSetIterator rXObject = Helpers.GetRXObject<OdSelectionSetIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSetIterator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSetIterator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSetIterator_isASwigExplicitOdSelectionSetIterator(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSetIterator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSetIterator_queryXSwigExplicitOdSelectionSetIterator(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSetIterator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdSelectionSetIterator createObject()
	{
		OdSelectionSetIterator rXObject = Helpers.GetRXObject<OdSelectionSetIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSetIterator_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbSelectionMethod method()
	{
		OdDbSelectionMethod rXObject = Helpers.GetRXObject<OdDbSelectionMethod>(TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSetIterator_method(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool done()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSetIterator_done(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool next()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSetIterator_next(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint subentCount()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSetIterator_subentCount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getSubentity(uint i, OdDbBaseFullSubentPath path)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSetIterator_getSubentity(swigCPtr, i, OdDbBaseFullSubentPath.getCPtr(path));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub id()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSetIterator_id(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected OdSelectionSetIterator()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSelectionSetIterator(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSelectionSetIterator) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSetIterator_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("method", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodmethod;
		}
		if (SwigDerivedClassHasMethod("done", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddone;
		}
		if (SwigDerivedClassHasMethod("next", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodnext;
		}
		if (SwigDerivedClassHasMethod("subentCount", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsubentCount;
		}
		if (SwigDerivedClassHasMethod("getSubentity", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetSubentity;
		}
		if (SwigDerivedClassHasMethod("id", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodid;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdSelectionSetIterator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdSelectionSetIterator));
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

	private IntPtr SwigDirectorMethodmethod()
	{
		return OdDbSelectionMethod.getCPtr(method()).Handle;
	}

	private bool SwigDirectorMethoddone()
	{
		return done();
	}

	private bool SwigDirectorMethodnext()
	{
		return next();
	}

	private uint SwigDirectorMethodsubentCount()
	{
		return subentCount();
	}

	private bool SwigDirectorMethodgetSubentity(uint i, IntPtr path)
	{
		return getSubentity(i, new OdDbBaseFullSubentPath(path, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodid()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(id()).Handle;
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
}
