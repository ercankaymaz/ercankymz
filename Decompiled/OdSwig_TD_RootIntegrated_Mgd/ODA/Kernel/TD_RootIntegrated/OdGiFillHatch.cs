using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiFillHatch : OdGiHatchPattern
{
	public delegate IntPtr SwigDelegateOdGiFillHatch_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiFillHatch_1();

	public delegate void SwigDelegateOdGiFillHatch_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiFillHatch_3(IntPtr bytes);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiFillHatch_0 swigDelegate0;

	private SwigDelegateOdGiFillHatch_1 swigDelegate1;

	private SwigDelegateOdGiFillHatch_2 swigDelegate2;

	private SwigDelegateOdGiFillHatch_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdUInt8Array) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiFillHatch(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiFillHatch obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiFillHatch(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiFillHatch cast(OdRxObject pObj)
	{
		OdGiFillHatch rXObject = Helpers.GetRXObject<OdGiFillHatch>(TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_isASwigExplicitOdGiFillHatch(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_queryXSwigExplicitOdGiFillHatch(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiFillHatch()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiFillHatch(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiFillHatch) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override void copyFrom(OdRxObject pSource)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_copyFromSwigExplicitOdGiFillHatch(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool IsEqual(OdGiFill fill)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_IsEqual(swigCPtr, OdGiFill.getCPtr(fill));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool IsNotEqual(OdGiFill fill)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_IsNotEqual(swigCPtr, OdGiFill.getCPtr(fill));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new double deviation()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_deviation(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double viewRotation()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_viewRotation(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double elevation()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_elevation(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint hatchDensity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_hatchDensity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint pointLimit()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_pointLimit(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint maxDrawPoints()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_maxDrawPoints(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public short smoothHatch()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_smoothHatch(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isSolidFill()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_isSolidFill(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isHatchTooDense()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_isHatchTooDense(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isGradientFill()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_isGradientFill(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDrawCache()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_isDrawCache(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isMPolygon()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_isMPolygon(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isDBRO()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_isDBRO(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool hasCache()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_hasCache(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdResult getResult()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_getResult(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdGiFillHatch_EvaluateEnum getEvaluateData()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_getEvaluateData(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiFillHatch_EvaluateEnum)result;
	}

	public OdUInt32Array getLoopsFlags()
	{
		OdUInt32Array result = new OdUInt32Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_getLoopsFlags(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt32Array getLoopsMarker()
	{
		OdUInt32Array result = new OdUInt32Array(TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_getLoopsMarker(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeIslandStyle getStyle()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_getStyle(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGeIslandStyle)result;
	}

	public OdGeExtents3d getExtents()
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_getExtents(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeTol getTolerance()
	{
		OdGeTol result = new OdGeTol(TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_getTolerance(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getPoints(OdGePoint2dArray startPoints, OdGePoint2dArray endPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_getPoints(swigCPtr, OdGePoint2dArray.getCPtr(startPoints).Handle, OdGePoint2dArray.getCPtr(endPoints).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeShellData getShellData()
	{
		OdGeShellData result = Helpers.GetObject<OdGeShellData>(TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_getShellData(swigCPtr), bOwn: true, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new OdHatchPattern patternLines()
	{
		OdHatchPattern result = new OdHatchPattern(TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_patternLines(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void set(double dDeviation, double dViewRotation, double dElevation, uint maxHatchDensity, uint pointLimit, uint maxPointsToDraw, short nSmoothHatch, bool bHatchTooDense, bool bSolidFill, bool bGradientFill, bool bMPolygon, bool bDBRO, OdUInt32Array loopsFlags, OdUInt32Array loopsMarker, OdGeIslandStyle style, OdHatchPattern pattern)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_set(swigCPtr, dDeviation, dViewRotation, dElevation, maxHatchDensity, pointLimit, maxPointsToDraw, nSmoothHatch, bHatchTooDense, bSolidFill, bGradientFill, bMPolygon, bDBRO, OdUInt32Array.getCPtr(loopsFlags).Handle, OdUInt32Array.getCPtr(loopsMarker).Handle, (int)style, OdHatchPattern.getCPtr(pattern));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setHatchTooDense(bool bHatchTooDense)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_setHatchTooDense(swigCPtr, bHatchTooDense);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setResult(OdResult res)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_setResult(swigCPtr, (int)res);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setEvaluateData(OdGiFillHatch_EvaluateEnum eData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_setEvaluateData(swigCPtr, (int)eData);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLoopsFlags(OdUInt32Array loopsFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_setLoopsFlags(swigCPtr, OdUInt32Array.getCPtr(loopsFlags).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLoopsMarker(OdUInt32Array loopsMarker)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_setLoopsMarker(swigCPtr, OdUInt32Array.getCPtr(loopsMarker).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setExtents(OdGeExtents3d ext3d)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_setExtents(swigCPtr, OdGeExtents3d.getCPtr(ext3d));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDrawCache(bool bDrawCache)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_setDrawCache(swigCPtr, bDrawCache);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTolerance(OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_setTolerance(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPoints(OdGePoint2dArray startPoints, OdGePoint2dArray endPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_setPoints(swigCPtr, OdGePoint2dArray.getCPtr(startPoints).Handle, OdGePoint2dArray.getCPtr(endPoints).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setShellData(OdGeShellData arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_setShellData(swigCPtr, OdGeShellData.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiFillHatch createObject()
	{
		OdGiFillHatch rXObject = Helpers.GetRXObject<OdGiFillHatch>(TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		if (SwigDerivedClassHasMethod("saveBytes", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsaveBytes;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiFillHatch_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiFillHatch));
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

	private void SwigDirectorMethodsaveBytes(IntPtr bytes)
	{
		try
		{
			saveBytes(new OdUInt8Array(bytes, cMemoryOwn: true));
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
}
