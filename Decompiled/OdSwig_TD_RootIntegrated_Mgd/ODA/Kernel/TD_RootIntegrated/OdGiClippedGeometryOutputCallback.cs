using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiClippedGeometryOutputCallback : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiClippedGeometryOutputCallback_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateOdGiClippedGeometryOutputCallback_1();

	public delegate void SwigDelegateOdGiClippedGeometryOutputCallback_2(IntPtr pSource);

	public delegate bool SwigDelegateOdGiClippedGeometryOutputCallback_3(IntPtr pGeomOutput, IntPtr pDrawContext);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiClippedGeometryOutputCallback_0 swigDelegate0;

	private SwigDelegateOdGiClippedGeometryOutputCallback_1 swigDelegate1;

	private SwigDelegateOdGiClippedGeometryOutputCallback_2 swigDelegate2;

	private SwigDelegateOdGiClippedGeometryOutputCallback_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdGiClippedGeometryOutput).MakeByRefType(),
		typeof(OdGiConveyorContext)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiClippedGeometryOutputCallback(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutputCallback_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiClippedGeometryOutputCallback obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiClippedGeometryOutputCallback(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiClippedGeometryOutputCallback()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiClippedGeometryOutputCallback(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiClippedGeometryOutputCallback) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual bool clippedGeometryOutputCallbackProc(ref OdGiClippedGeometryOutput pGeomOutput, OdGiConveyorContext pDrawContext)
	{
		IntPtr jarg = ((pGeomOutput == null) ? IntPtr.Zero : OdGiClippedGeometryOutput.getCPtr(pGeomOutput).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutputCallback_clippedGeometryOutputCallbackProc(swigCPtr, ref jarg, pDrawContext.GetInterfaceCPtr());
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pGeomOutput = null;
			}
			if (jarg != intPtr)
			{
				pGeomOutput = Helpers.GetRXObject<OdGiClippedGeometryOutput>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutputCallback_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("clippedGeometryOutputCallbackProc", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodclippedGeometryOutputCallbackProc;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryOutputCallback_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiClippedGeometryOutputCallback));
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

	private bool SwigDirectorMethodclippedGeometryOutputCallbackProc(IntPtr pGeomOutput, IntPtr pDrawContext)
	{
		OdSwigDirectorHelper.director_UnpackData(pGeomOutput, out var pOriginalObject, out var pFunction);
		OdGiClippedGeometryOutput pGeomOutput2 = Helpers.GetRXObject<OdGiClippedGeometryOutput>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return clippedGeometryOutputCallbackProc(ref pGeomOutput2, new OdGiConveyorContext_Internal(pDrawContext, cMemoryOwn: false));
		}
		finally
		{
			IntPtr handle = OdGiClippedGeometryOutput.getCPtr(pGeomOutput2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pGeomOutput);
		}
	}
}
