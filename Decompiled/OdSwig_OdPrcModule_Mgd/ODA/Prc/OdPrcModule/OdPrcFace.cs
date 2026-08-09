using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcFace : OdPrcTopoItem
{
	public delegate IntPtr SwigDelegateOdPrcFace_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcFace_1();

	public delegate void SwigDelegateOdPrcFace_2(IntPtr pSource);

	public delegate uint SwigDelegateOdPrcFace_3();

	public delegate void SwigDelegateOdPrcFace_4(IntPtr pStream);

	public delegate void SwigDelegateOdPrcFace_5(IntPtr pStream);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcFace_0 swigDelegate0;

	private SwigDelegateOdPrcFace_1 swigDelegate1;

	private SwigDelegateOdPrcFace_2 swigDelegate2;

	private SwigDelegateOdPrcFace_3 swigDelegate3;

	private SwigDelegateOdPrcFace_4 swigDelegate4;

	private SwigDelegateOdPrcFace_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdPrcCompressedFiler) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdPrcCompressedFiler) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcFace(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcFace_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcFace obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcFace(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPrcFace()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcFace(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcFace) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override uint prcType()
	{
		uint result = (SwigDerivedClassHasMethod("prcType", swigMethodTypes3) ? OdPrcModule_GlobalsPINVOKE.OdPrcFace_prcTypeSwigExplicitOdPrcFace(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcFace_prcType(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdPrcFace cast(OdRxObject pObj)
	{
		OdPrcFace rXObject = Helpers.GetRXObject<OdPrcFace>(OdPrcModule_GlobalsPINVOKE.OdPrcFace_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcFace_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcFace_isASwigExplicitOdPrcFace(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcFace_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcFace_queryXSwigExplicitOdPrcFace(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcFace_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPrcFace createObject()
	{
		OdPrcFace rXObject = Helpers.GetRXObject<OdPrcFace>(OdPrcModule_GlobalsPINVOKE.OdPrcFace_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void prcOut(OdPrcCompressedFiler pStream)
	{
		if (SwigDerivedClassHasMethod("prcOut", swigMethodTypes4))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFace_prcOutSwigExplicitOdPrcFace(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFace_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void prcIn(OdPrcCompressedFiler pStream)
	{
		if (SwigDerivedClassHasMethod("prcIn", swigMethodTypes5))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFace_prcInSwigExplicitOdPrcFace(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcFace_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addLoop(OdPrcLoop pLoop)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFace_addLoop(swigCPtr, OdPrcLoop.getCPtr(pLoop));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLoops(OdPrcLoopPtrArray arrLoops)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFace_setLoops(swigCPtr, OdPrcLoopPtrArray.getCPtr(arrLoops));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcLoopPtrArray loops()
	{
		OdPrcLoopPtrArray result = Helpers.GetObject<OdPrcLoopPtrArray>(OdPrcModule_GlobalsPINVOKE.OdPrcFace_loops(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSurfaceTrimDomain(OdPrcDomain pTrimDomain)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFace_setSurfaceTrimDomain(swigCPtr, OdPrcDomain.getCPtr(pTrimDomain));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcDomain surfaceTrimDomain()
	{
		IntPtr intPtr = OdPrcModule_GlobalsPINVOKE.OdPrcFace_surfaceTrimDomain(swigCPtr);
		OdPrcDomain result = ((intPtr == IntPtr.Zero) ? null : new OdPrcDomain(intPtr, cMemoryOwn: false));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcSurface baseSurface()
	{
		OdPrcSurface rXObject = Helpers.GetRXObject<OdPrcSurface>(OdPrcModule_GlobalsPINVOKE.OdPrcFace_baseSurface(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcBaseTopology baseTopology()
	{
		OdPrcBaseTopology result = new OdPrcBaseTopology(OdPrcModule_GlobalsPINVOKE.OdPrcFace_baseTopology__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setTolerance(double tolerance)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFace_setTolerance(swigCPtr, tolerance);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double tolerance()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcFace_tolerance(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasGraphics()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcFace_hasGraphics(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdPrcGraphics graphics()
	{
		IntPtr intPtr = OdPrcModule_GlobalsPINVOKE.OdPrcFace_graphics(swigCPtr);
		OdPrcGraphics result = ((intPtr == IntPtr.Zero) ? null : new OdPrcGraphics(intPtr, cMemoryOwn: false));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult setOuterLoopIndex(int nOuterLoopIndex)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcFace_setOuterLoopIndex(swigCPtr, nOuterLoopIndex);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public int getOuterLoopIndex()
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcFace_getOuterLoopIndex(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setGraphics(OdPrcGraphics faceGraphics)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFace_setGraphics(swigCPtr, OdPrcGraphics.getCPtr(faceGraphics));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearGraphics()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFace_clearGraphics(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcFace_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setbaseSurface(OdPrcSurface value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFace_setbaseSurface(swigCPtr, OdPrcSurface.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setorientationSurfaceWithShell(Orientation value)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFace_setorientationSurfaceWithShell(swigCPtr, (int)value);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public Orientation getorientationSurfaceWithShell()
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcFace_getorientationSurfaceWithShell(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (Orientation)result;
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
		if (SwigDerivedClassHasMethod("prcType", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodprcType;
		}
		if (SwigDerivedClassHasMethod("prcOut", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodprcOut;
		}
		if (SwigDerivedClassHasMethod("prcIn", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodprcIn;
		}
		OdPrcModule_GlobalsPINVOKE.OdPrcFace_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcFace));
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

	private uint SwigDirectorMethodprcType()
	{
		return prcType();
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
