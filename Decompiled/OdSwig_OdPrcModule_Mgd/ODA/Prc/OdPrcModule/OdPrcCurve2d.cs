using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcCurve2d : OdPrcCurve
{
	public delegate IntPtr SwigDelegateOdPrcCurve2d_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcCurve2d_1();

	public delegate void SwigDelegateOdPrcCurve2d_2(IntPtr pSource);

	public delegate void SwigDelegateOdPrcCurve2d_3(IntPtr pStream);

	public delegate void SwigDelegateOdPrcCurve2d_4(IntPtr pStream);

	public delegate bool SwigDelegateOdPrcCurve2d_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcCurve2d_0 swigDelegate0;

	private SwigDelegateOdPrcCurve2d_1 swigDelegate1;

	private SwigDelegateOdPrcCurve2d_2 swigDelegate2;

	private SwigDelegateOdPrcCurve2d_3 swigDelegate3;

	private SwigDelegateOdPrcCurve2d_4 swigDelegate4;

	private SwigDelegateOdPrcCurve2d_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdPrcCompressedFiler) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdPrcCompressedFiler) };

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcCurve2d(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcCurve2d obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcCurve2d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPrcCurve2d()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcCurve2d(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcCurve2d) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPrcCurve2d cast(OdRxObject pObj)
	{
		OdPrcCurve2d rXObject = Helpers.GetRXObject<OdPrcCurve2d>(OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_isASwigExplicitOdPrcCurve2d(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_queryXSwigExplicitOdPrcCurve2d(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPrcCurve2d createObject()
	{
		OdPrcCurve2d rXObject = Helpers.GetRXObject<OdPrcCurve2d>(OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGeMatrix2d getGeMatrix2d()
	{
		OdGeMatrix2d result = new OdGeMatrix2d(OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_getGeMatrix2d(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setTransformation(OdPrcTransformation2d trans)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_setTransformation(swigCPtr, OdPrcTransformation2d.getCPtr(trans));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdPrcTransformation2d transformation()
	{
		IntPtr intPtr = OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_transformation(swigCPtr);
		OdPrcTransformation2d result = ((intPtr == IntPtr.Zero) ? null : new OdPrcTransformation2d(intPtr, cMemoryOwn: false));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool is3d()
	{
		bool result = (SwigDerivedClassHasMethod("is3d", swigMethodTypes5) ? OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_is3dSwigExplicitOdPrcCurve2d(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_is3d(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult getOdGeCurve(out OdGeCurve2d pGeCurve, OdGeTol tol)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_getOdGeCurve__SWIG_0(swigCPtr, out jarg, OdGeTol.getCPtr(tol));
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGeCurve2d>(typeof(OdGeCurve2d), jarg, bIsWrapperOwnNativeObject: true));
			pGeCurve = Helpers.odCreateObjectInternal<OdGeCurve2d>(typeof(OdGeCurve2d), jarg, currentTransaction == null);
		}
	}

	public OdResult getOdGeCurve(out OdGeCurve2d pGeCurve)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_getOdGeCurve__SWIG_1(swigCPtr, out jarg);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGeCurve2d>(typeof(OdGeCurve2d), jarg, bIsWrapperOwnNativeObject: true));
			pGeCurve = Helpers.odCreateObjectInternal<OdGeCurve2d>(typeof(OdGeCurve2d), jarg, currentTransaction == null);
		}
	}

	public OdResult setFromOdGeCurve(OdGeCurve2d geCurve, OdGeTol tol)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_setFromOdGeCurve__SWIG_0(swigCPtr, OdGeCurve2d.getCPtr(geCurve), OdGeTol.getCPtr(tol));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setFromOdGeCurve(OdGeCurve2d geCurve)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_setFromOdGeCurve__SWIG_1(swigCPtr, OdGeCurve2d.getCPtr(geCurve));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult createFromOdGeCurve(OdGeCurve2d geCurve, ref OdPrcCurve2d pPrcCurve, OdGeTol tol)
	{
		IntPtr jarg = ((pPrcCurve == null) ? IntPtr.Zero : getCPtr(pPrcCurve).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_createFromOdGeCurve__SWIG_0(OdGeCurve2d.getCPtr(geCurve), ref jarg, OdGeTol.getCPtr(tol));
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pPrcCurve = null;
			}
			else if (jarg != intPtr)
			{
				pPrcCurve = Helpers.GetRXObject<OdPrcCurve2d>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdResult createFromOdGeCurve(OdGeCurve2d geCurve, ref OdPrcCurve2d pPrcCurve)
	{
		IntPtr jarg = ((pPrcCurve == null) ? IntPtr.Zero : getCPtr(pPrcCurve).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_createFromOdGeCurve__SWIG_1(OdGeCurve2d.getCPtr(geCurve), ref jarg);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pPrcCurve = null;
			}
			else if (jarg != intPtr)
			{
				pPrcCurve = Helpers.GetRXObject<OdPrcCurve2d>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("prcOut", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodprcOut;
		}
		if (SwigDerivedClassHasMethod("prcIn", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodprcIn;
		}
		if (SwigDerivedClassHasMethod("is3d", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodis3d;
		}
		OdPrcModule_GlobalsPINVOKE.OdPrcCurve2d_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcCurve2d));
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodprcOut(IntPtr pStream)
	{
		try
		{
			prcOut(Helpers.GetRXObject<OdPrcCompressedFiler>(pStream, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodprcIn(IntPtr pStream)
	{
		try
		{
			prcIn(Helpers.GetRXObject<OdPrcCompressedFiler>(pStream, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodis3d()
	{
		return is3d();
	}
}
