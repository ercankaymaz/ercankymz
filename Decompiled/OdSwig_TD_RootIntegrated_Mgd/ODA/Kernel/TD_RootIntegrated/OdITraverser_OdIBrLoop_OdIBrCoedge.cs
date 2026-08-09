using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdITraverser_OdIBrLoop_OdIBrCoedge : OdIBaseTraverser
{
	public delegate IntPtr SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_1();

	public delegate void SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_2(IntPtr pSource);

	public delegate bool SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_3();

	public delegate void SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_4();

	public delegate void SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_5();

	public delegate bool SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_6(IntPtr pOther);

	public delegate bool SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_7();

	public delegate bool SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_8(IntPtr pParent, IntPtr pFirstChild, IntPtr pChild);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_0 swigDelegate0;

	private SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_1 swigDelegate1;

	private SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_2 swigDelegate2;

	private SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_3 swigDelegate3;

	private SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_4 swigDelegate4;

	private SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_5 swigDelegate5;

	private SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_6 swigDelegate6;

	private SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_7 swigDelegate7;

	private SwigDelegateOdITraverser_OdIBrLoop_OdIBrCoedge_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdIBaseTraverser) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[3]
	{
		typeof(OdIBrLoop),
		typeof(OdIBrCoedge),
		typeof(OdIBrCoedge)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdITraverser_OdIBrLoop_OdIBrCoedge(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdITraverser_OdIBrLoop_OdIBrCoedge_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdITraverser_OdIBrLoop_OdIBrCoedge obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdITraverser_OdIBrLoop_OdIBrCoedge(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdITraverser_OdIBrLoop_OdIBrCoedge()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdITraverser_OdIBrLoop_OdIBrCoedge(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdITraverser_OdIBrLoop_OdIBrCoedge) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdIBrCoedge getCurrent()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdITraverser_OdIBrLoop_OdIBrCoedge_getCurrent__SWIG_0(swigCPtr);
		OdIBrCoedge result = ((intPtr == IntPtr.Zero) ? null : new OdIBrCoedge(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdIBrLoop getParent()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdITraverser_OdIBrLoop_OdIBrCoedge_getParent__SWIG_0(swigCPtr);
		OdIBrLoop result = ((intPtr == IntPtr.Zero) ? null : new OdIBrLoop(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool init(OdIBrLoop pParent, OdIBrCoedge pFirstChild, OdIBrCoedge pChild)
	{
		bool result = (SwigDerivedClassHasMethod("init", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdITraverser_OdIBrLoop_OdIBrCoedge_initSwigExplicitOdITraverser_OdIBrLoop_OdIBrCoedge(swigCPtr, OdIBrLoop.getCPtr(pParent), OdIBrCoedge.getCPtr(pFirstChild), OdIBrCoedge.getCPtr(pChild)) : TD_RootIntegrated_GlobalsPINVOKE.OdITraverser_OdIBrLoop_OdIBrCoedge_init(swigCPtr, OdIBrLoop.getCPtr(pParent), OdIBrCoedge.getCPtr(pFirstChild), OdIBrCoedge.getCPtr(pChild)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool done()
	{
		bool result = (SwigDerivedClassHasMethod("done", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdITraverser_OdIBrLoop_OdIBrCoedge_doneSwigExplicitOdITraverser_OdIBrLoop_OdIBrCoedge(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdITraverser_OdIBrLoop_OdIBrCoedge_done(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual void next()
	{
		if (SwigDerivedClassHasMethod("next", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdITraverser_OdIBrLoop_OdIBrCoedge_nextSwigExplicitOdITraverser_OdIBrLoop_OdIBrCoedge(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdITraverser_OdIBrLoop_OdIBrCoedge_next(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual void restart()
	{
		if (SwigDerivedClassHasMethod("restart", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdITraverser_OdIBrLoop_OdIBrCoedge_restartSwigExplicitOdITraverser_OdIBrLoop_OdIBrCoedge(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdITraverser_OdIBrLoop_OdIBrCoedge_restart(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual bool isEqualTo(OdIBaseTraverser pOther)
	{
		bool result = (SwigDerivedClassHasMethod("isEqualTo", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdITraverser_OdIBrLoop_OdIBrCoedge_isEqualToSwigExplicitOdITraverser_OdIBrLoop_OdIBrCoedge(swigCPtr, OdIBaseTraverser.getCPtr(pOther)) : TD_RootIntegrated_GlobalsPINVOKE.OdITraverser_OdIBrLoop_OdIBrCoedge_isEqualTo(swigCPtr, OdIBaseTraverser.getCPtr(pOther)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new virtual bool isNull()
	{
		bool result = (SwigDerivedClassHasMethod("isNull", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdITraverser_OdIBrLoop_OdIBrCoedge_isNullSwigExplicitOdITraverser_OdIBrLoop_OdIBrCoedge(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdITraverser_OdIBrLoop_OdIBrCoedge_isNull(swigCPtr));
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
		if (SwigDerivedClassHasMethod("done", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddone;
		}
		if (SwigDerivedClassHasMethod("next", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodnext;
		}
		if (SwigDerivedClassHasMethod("restart", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodrestart;
		}
		if (SwigDerivedClassHasMethod("isEqualTo", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodisEqualTo;
		}
		if (SwigDerivedClassHasMethod("isNull", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodisNull;
		}
		if (SwigDerivedClassHasMethod("init", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodinit;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdITraverser_OdIBrLoop_OdIBrCoedge_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdITraverser_OdIBrLoop_OdIBrCoedge));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr pClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(pClass, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private bool SwigDirectorMethoddone()
	{
		return done();
	}

	private void SwigDirectorMethodnext()
	{
		try
		{
			next();
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

	private void SwigDirectorMethodrestart()
	{
		try
		{
			restart();
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

	private bool SwigDirectorMethodisEqualTo(IntPtr pOther)
	{
		return isEqualTo(Helpers.GetRXObject<OdIBaseTraverser>(pOther, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisNull()
	{
		return isNull();
	}

	private bool SwigDirectorMethodinit(IntPtr pParent, IntPtr pFirstChild, IntPtr pChild)
	{
		return init((pParent == IntPtr.Zero) ? null : new OdIBrLoop(pParent, cMemoryOwn: false), (pFirstChild == IntPtr.Zero) ? null : new OdIBrCoedge(pFirstChild, cMemoryOwn: false), (pChild == IntPtr.Zero) ? null : new OdIBrCoedge(pChild, cMemoryOwn: false));
	}
}
