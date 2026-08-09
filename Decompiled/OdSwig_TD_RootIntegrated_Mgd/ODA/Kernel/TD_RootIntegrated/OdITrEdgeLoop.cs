using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdITrEdgeLoop : OdIBaseTraverser
{
	public delegate IntPtr SwigDelegateOdITrEdgeLoop_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateOdITrEdgeLoop_1();

	public delegate void SwigDelegateOdITrEdgeLoop_2(IntPtr pSource);

	public delegate bool SwigDelegateOdITrEdgeLoop_3();

	public delegate void SwigDelegateOdITrEdgeLoop_4();

	public delegate void SwigDelegateOdITrEdgeLoop_5();

	public delegate bool SwigDelegateOdITrEdgeLoop_6(IntPtr pOther);

	public delegate bool SwigDelegateOdITrEdgeLoop_7();

	public delegate bool SwigDelegateOdITrEdgeLoop_8(IntPtr pParent, IntPtr pFirstChild, IntPtr pChild);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdITrEdgeLoop_0 swigDelegate0;

	private SwigDelegateOdITrEdgeLoop_1 swigDelegate1;

	private SwigDelegateOdITrEdgeLoop_2 swigDelegate2;

	private SwigDelegateOdITrEdgeLoop_3 swigDelegate3;

	private SwigDelegateOdITrEdgeLoop_4 swigDelegate4;

	private SwigDelegateOdITrEdgeLoop_5 swigDelegate5;

	private SwigDelegateOdITrEdgeLoop_6 swigDelegate6;

	private SwigDelegateOdITrEdgeLoop_7 swigDelegate7;

	private SwigDelegateOdITrEdgeLoop_8 swigDelegate8;

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
		typeof(OdIBrEdge),
		typeof(OdIBrCoedge),
		typeof(OdIBrCoedge)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdITrEdgeLoop(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdITrEdgeLoop obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdITrEdgeLoop(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdIBrCoedge getParent()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_getParent(swigCPtr);
		OdIBrCoedge result = ((intPtr == IntPtr.Zero) ? null : new OdIBrCoedge(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdIBrCoedge getCurrent()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_getCurrent__SWIG_0(swigCPtr);
		OdIBrCoedge result = ((intPtr == IntPtr.Zero) ? null : new OdIBrCoedge(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool init(OdIBrEdge pParent, OdIBrCoedge pFirstChild, OdIBrCoedge pChild)
	{
		bool result = (SwigDerivedClassHasMethod("init", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_initSwigExplicitOdITrEdgeLoop(swigCPtr, OdIBrEdge.getCPtr(pParent), OdIBrCoedge.getCPtr(pFirstChild), OdIBrCoedge.getCPtr(pChild)) : TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_init(swigCPtr, OdIBrEdge.getCPtr(pParent), OdIBrCoedge.getCPtr(pFirstChild), OdIBrCoedge.getCPtr(pChild)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool done()
	{
		bool result = (SwigDerivedClassHasMethod("done", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_doneSwigExplicitOdITrEdgeLoop(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_done(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void next()
	{
		if (SwigDerivedClassHasMethod("next", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_nextSwigExplicitOdITrEdgeLoop(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_next(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void restart()
	{
		if (SwigDerivedClassHasMethod("restart", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_restartSwigExplicitOdITrEdgeLoop(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_restart(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isEqualTo(OdIBaseTraverser pOther)
	{
		bool result = (SwigDerivedClassHasMethod("isEqualTo", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_isEqualToSwigExplicitOdITrEdgeLoop(swigCPtr, OdIBaseTraverser.getCPtr(pOther)) : TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_isEqualTo(swigCPtr, OdIBaseTraverser.getCPtr(pOther)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isNull()
	{
		bool result = (SwigDerivedClassHasMethod("isNull", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_isNullSwigExplicitOdITrEdgeLoop(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_isNull(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_getRealClassName(ptr);
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
		TD_RootIntegrated_GlobalsPINVOKE.OdITrEdgeLoop_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdITrEdgeLoop));
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
		return init((pParent == IntPtr.Zero) ? null : new OdIBrEdge(pParent, cMemoryOwn: false), (pFirstChild == IntPtr.Zero) ? null : new OdIBrCoedge(pFirstChild, cMemoryOwn: false), (pChild == IntPtr.Zero) ? null : new OdIBrCoedge(pChild, cMemoryOwn: false));
	}
}
