using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcSurface : OdRxObject
{
	public delegate IntPtr SwigDelegateOdPrcSurface_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcSurface_1();

	public delegate void SwigDelegateOdPrcSurface_2(IntPtr pSource);

	public delegate void SwigDelegateOdPrcSurface_3(IntPtr pStream);

	public delegate void SwigDelegateOdPrcSurface_4(IntPtr pStream);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcSurface_0 swigDelegate0;

	private SwigDelegateOdPrcSurface_1 swigDelegate1;

	private SwigDelegateOdPrcSurface_2 swigDelegate2;

	private SwigDelegateOdPrcSurface_3 swigDelegate3;

	private SwigDelegateOdPrcSurface_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdPrcCompressedFiler) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdPrcCompressedFiler) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcSurface(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcSurface_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcSurface obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcSurface(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPrcSurface()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcSurface(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcSurface) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPrcSurface cast(OdRxObject pObj)
	{
		OdPrcSurface rXObject = Helpers.GetRXObject<OdPrcSurface>(OdPrcModule_GlobalsPINVOKE.OdPrcSurface_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcSurface_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcSurface_isASwigExplicitOdPrcSurface(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcSurface_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcSurface_queryXSwigExplicitOdPrcSurface(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcSurface_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdPrcSurface createObject()
	{
		OdPrcSurface rXObject = Helpers.GetRXObject<OdPrcSurface>(OdPrcModule_GlobalsPINVOKE.OdPrcSurface_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void prcOut(OdPrcCompressedFiler pStream)
	{
		if (SwigDerivedClassHasMethod("prcOut", swigMethodTypes3))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcSurface_prcOutSwigExplicitOdPrcSurface(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcSurface_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void prcIn(OdPrcCompressedFiler pStream)
	{
		if (SwigDerivedClassHasMethod("prcIn", swigMethodTypes4))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcSurface_prcInSwigExplicitOdPrcSurface(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcSurface_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeMatrix3d getGeMatrix3d()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(OdPrcModule_GlobalsPINVOKE.OdPrcSurface_getGeMatrix3d(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setTransformation(OdPrcTransformation3d trans)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcSurface_setTransformation(swigCPtr, OdPrcTransformation3d.getCPtr(trans));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdPrcTransformation3d transformation()
	{
		IntPtr intPtr = OdPrcModule_GlobalsPINVOKE.OdPrcSurface_transformation(swigCPtr);
		OdPrcTransformation3d result = ((intPtr == IntPtr.Zero) ? null : new OdPrcTransformation3d(intPtr, cMemoryOwn: false));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult getOdGeSurface(out OdGeSurface pGeSurface, OdGeTol tol)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcSurface_getOdGeSurface__SWIG_0(swigCPtr, out jarg, OdGeTol.getCPtr(tol));
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGeSurface>(typeof(OdGeSurface), jarg, bIsWrapperOwnNativeObject: true));
			pGeSurface = Helpers.odCreateObjectInternal<OdGeSurface>(typeof(OdGeSurface), jarg, currentTransaction == null);
		}
	}

	public OdResult getOdGeSurface(out OdGeSurface pGeSurface)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcSurface_getOdGeSurface__SWIG_1(swigCPtr, out jarg);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGeSurface>(typeof(OdGeSurface), jarg, bIsWrapperOwnNativeObject: true));
			pGeSurface = Helpers.odCreateObjectInternal<OdGeSurface>(typeof(OdGeSurface), jarg, currentTransaction == null);
		}
	}

	public OdResult setFromOdGeSurface(OdGeSurface geSurface, OdGeTol tol)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcSurface_setFromOdGeSurface__SWIG_0(swigCPtr, OdGeSurface.getCPtr(geSurface), OdGeTol.getCPtr(tol));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdResult setFromOdGeSurface(OdGeSurface geSurface)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcSurface_setFromOdGeSurface__SWIG_1(swigCPtr, OdGeSurface.getCPtr(geSurface));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdResult createFromOdGeSurface(OdGeSurface geSurface, ref OdPrcSurface pPrcSurface, OdGeTol tol)
	{
		IntPtr jarg = ((pPrcSurface == null) ? IntPtr.Zero : getCPtr(pPrcSurface).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcSurface_createFromOdGeSurface__SWIG_0(OdGeSurface.getCPtr(geSurface), ref jarg, OdGeTol.getCPtr(tol));
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
				pPrcSurface = null;
			}
			else if (jarg != intPtr)
			{
				pPrcSurface = Helpers.GetRXObject<OdPrcSurface>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdResult createFromOdGeSurface(OdGeSurface geSurface, ref OdPrcSurface pPrcSurface)
	{
		IntPtr jarg = ((pPrcSurface == null) ? IntPtr.Zero : getCPtr(pPrcSurface).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = OdPrcModule_GlobalsPINVOKE.OdPrcSurface_createFromOdGeSurface__SWIG_1(OdGeSurface.getCPtr(geSurface), ref jarg);
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
				pPrcSurface = null;
			}
			else if (jarg != intPtr)
			{
				pPrcSurface = Helpers.GetRXObject<OdPrcSurface>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdPrcUVParameterization uVParameterization()
	{
		OdPrcUVParameterization result = new OdPrcUVParameterization(OdPrcModule_GlobalsPINVOKE.OdPrcSurface_uVParameterization(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setUVParameterization(OdPrcUVParameterization uvparameterization)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcSurface_setUVParameterization(swigCPtr, OdPrcUVParameterization.getCPtr(uvparameterization));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public static OdPrcSurface readPtr(OdPrcCompressedFiler pStream)
	{
		OdPrcSurface rXObject = Helpers.GetRXObject<OdPrcSurface>(OdPrcModule_GlobalsPINVOKE.OdPrcSurface_readPtr(OdPrcCompressedFiler.getCPtr(pStream)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void writePtr(OdPrcSurface pSurface, OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcSurface_writePtr(getCPtr(pSurface), OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void readArray(OdPrcSurfacePtrArray array, OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcSurface_readArray(OdPrcSurfacePtrArray.getCPtr(array), OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void writeArray(OdPrcSurfacePtrArray array, OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcSurface_writeArray(OdPrcSurfacePtrArray.getCPtr(array), OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdPrcSurface read(OdPrcCompressedFiler pStream)
	{
		OdPrcSurface rXObject = Helpers.GetRXObject<OdPrcSurface>(OdPrcModule_GlobalsPINVOKE.OdPrcSurface_read(OdPrcCompressedFiler.getCPtr(pStream)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcContentSurface contentSurface()
	{
		OdPrcContentSurface result = new OdPrcContentSurface(OdPrcModule_GlobalsPINVOKE.OdPrcSurface_contentSurface__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcSurface_getRealClassName(ptr);
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
		OdPrcModule_GlobalsPINVOKE.OdPrcSurface_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcSurface));
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
}
