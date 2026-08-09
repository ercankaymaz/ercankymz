using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPointCloudXformFilter : OdGiPointCloudFilter
{
	public delegate IntPtr SwigDelegateOdGiPointCloudXformFilter_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiPointCloudXformFilter_1();

	public delegate void SwigDelegateOdGiPointCloudXformFilter_2(IntPtr pSource);

	public delegate bool SwigDelegateOdGiPointCloudXformFilter_3(IntPtr pPoints, uint nArrays, uint compFlags, IntPtr pExtents);

	public delegate bool SwigDelegateOdGiPointCloudXformFilter_4(IntPtr bb);

	public delegate void SwigDelegateOdGiPointCloudXformFilter_5(IntPtr xForm);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiPointCloudXformFilter_0 swigDelegate0;

	private SwigDelegateOdGiPointCloudXformFilter_1 swigDelegate1;

	private SwigDelegateOdGiPointCloudXformFilter_2 swigDelegate2;

	private SwigDelegateOdGiPointCloudXformFilter_3 swigDelegate3;

	private SwigDelegateOdGiPointCloudXformFilter_4 swigDelegate4;

	private SwigDelegateOdGiPointCloudXformFilter_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[4]
	{
		typeof(OdGiPointCloud.ComponentsRaw).MakeByRefType(),
		typeof(uint).MakeByRefType(),
		typeof(uint).MakeByRefType(),
		typeof(OdGeBoundBlock3d)
	};

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGeBoundBlock3d) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGeMatrix3d) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPointCloudXformFilter(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPointCloudXformFilter obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPointCloudXformFilter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiPointCloudXformFilter cast(OdRxObject pObj)
	{
		OdGiPointCloudXformFilter rXObject = Helpers.GetRXObject<OdGiPointCloudXformFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_isASwigExplicitOdGiPointCloudXformFilter(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_queryXSwigExplicitOdGiPointCloudXformFilter(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected override bool filterPointsImpl(out OdGiPointCloud.ComponentsRaw pPoints, out uint nArrays, out uint compFlags, OdGeBoundBlock3d pExtents)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			bool result = (SwigDerivedClassHasMethod("filterPointsImpl", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_filterPointsImplSwigExplicitOdGiPointCloudXformFilter(swigCPtr, out jarg, out nArrays, out compFlags, pExtents) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_filterPointsImpl(swigCPtr, out jarg, out nArrays, out compFlags, pExtents));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdGiPointCloud.ComponentsRaw>(typeof(OdGiPointCloud.ComponentsRaw), jarg, bIsWrapperOwnNativeObject: true));
			pPoints = Helpers.odCreateObjectInternal<OdGiPointCloud.ComponentsRaw>(typeof(OdGiPointCloud.ComponentsRaw), jarg, currentTransaction == null);
		}
	}

	protected override bool filterBoundingBoxImpl(OdGeBoundBlock3d bb)
	{
		bool result = (SwigDerivedClassHasMethod("filterBoundingBoxImpl", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_filterBoundingBoxImplSwigExplicitOdGiPointCloudXformFilter(swigCPtr, OdGeBoundBlock3d.getCPtr(bb)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_filterBoundingBoxImpl(swigCPtr, OdGeBoundBlock3d.getCPtr(bb)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected override void extractTransformImpl(OdGeMatrix3d xForm)
	{
		if (SwigDerivedClassHasMethod("extractTransformImpl", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_extractTransformImplSwigExplicitOdGiPointCloudXformFilter(swigCPtr, OdGeMatrix3d.getCPtr(xForm));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_extractTransformImpl(swigCPtr, OdGeMatrix3d.getCPtr(xForm));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setXform(OdGeMatrix3d xForm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_setXform(swigCPtr, OdGeMatrix3d.getCPtr(xForm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addXform(OdGeMatrix3d xForm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_addXform(swigCPtr, OdGeMatrix3d.getCPtr(xForm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeMatrix3d getXform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_getXform(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void resetXform()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_resetXform(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool hasXform()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_hasXform(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d accessXform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_accessXform(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiPointCloudFilter createObject(OdGeMatrix3d xForm, OdGiPointCloudFilter pPrevFilter)
	{
		OdGiPointCloudFilter rXObject = Helpers.GetRXObject<OdGiPointCloudFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_createObject__SWIG_0(OdGeMatrix3d.getCPtr(xForm), OdGiPointCloudFilter.getCPtr(pPrevFilter)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiPointCloudFilter createObject(OdGeMatrix3d xForm)
	{
		OdGiPointCloudFilter rXObject = Helpers.GetRXObject<OdGiPointCloudFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_createObject__SWIG_1(OdGeMatrix3d.getCPtr(xForm)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiPointCloudXformFilter createObject()
	{
		OdGiPointCloudXformFilter rXObject = Helpers.GetRXObject<OdGiPointCloudXformFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_createObject__SWIG_2(), bOwn: true, bTryAddToTransaction: true);
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
		if (SwigDerivedClassHasMethod("filterPointsImpl", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodfilterPointsImpl;
		}
		if (SwigDerivedClassHasMethod("filterBoundingBoxImpl", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodfilterBoundingBoxImpl;
		}
		if (SwigDerivedClassHasMethod("extractTransformImpl", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodextractTransformImpl;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudXformFilter_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiPointCloudXformFilter));
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

	private bool SwigDirectorMethodfilterPointsImpl(IntPtr pPoints, uint nArrays, uint compFlags, IntPtr pExtents)
	{
		OdGiPointCloud.ComponentsRaw pArrays = new OdGiPointCloud.ComponentsRaw(pPoints, cMemoryOwn: true);
		OdGeBoundBlock3d pExtents2 = new OdGeBoundBlock3d(pExtents, cMemoryOwn: true);
		try
		{
			return filterPointsImpl(out pArrays, out nArrays, out compFlags, pExtents2);
		}
		finally
		{
			pPoints = OdGiPointCloud.ComponentsRaw.getCPtr(pArrays).Handle;
		}
	}

	private bool SwigDirectorMethodfilterBoundingBoxImpl(IntPtr bb)
	{
		return filterBoundingBoxImpl(new OdGeBoundBlock3d(bb, cMemoryOwn: false));
	}

	private void SwigDirectorMethodextractTransformImpl(IntPtr xForm)
	{
		try
		{
			extractTransformImpl(new OdGeMatrix3d(xForm, cMemoryOwn: false));
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
