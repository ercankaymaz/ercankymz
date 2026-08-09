using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPointCloudComponentsFilter : OdGiPointCloudFilter
{
	public delegate IntPtr SwigDelegateOdGiPointCloudComponentsFilter_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiPointCloudComponentsFilter_1();

	public delegate void SwigDelegateOdGiPointCloudComponentsFilter_2(IntPtr pSource);

	public delegate bool SwigDelegateOdGiPointCloudComponentsFilter_3(IntPtr pPoints, uint nArrays, uint compFlags, IntPtr pExtents);

	public delegate bool SwigDelegateOdGiPointCloudComponentsFilter_4(IntPtr arg0);

	public delegate void SwigDelegateOdGiPointCloudComponentsFilter_5(IntPtr arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiPointCloudComponentsFilter_0 swigDelegate0;

	private SwigDelegateOdGiPointCloudComponentsFilter_1 swigDelegate1;

	private SwigDelegateOdGiPointCloudComponentsFilter_2 swigDelegate2;

	private SwigDelegateOdGiPointCloudComponentsFilter_3 swigDelegate3;

	private SwigDelegateOdGiPointCloudComponentsFilter_4 swigDelegate4;

	private SwigDelegateOdGiPointCloudComponentsFilter_5 swigDelegate5;

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
	public OdGiPointCloudComponentsFilter(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPointCloudComponentsFilter obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPointCloudComponentsFilter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiPointCloudComponentsFilter cast(OdRxObject pObj)
	{
		OdGiPointCloudComponentsFilter rXObject = Helpers.GetRXObject<OdGiPointCloudComponentsFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_isASwigExplicitOdGiPointCloudComponentsFilter(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_queryXSwigExplicitOdGiPointCloudComponentsFilter(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
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
			bool result = (SwigDerivedClassHasMethod("filterPointsImpl", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_filterPointsImplSwigExplicitOdGiPointCloudComponentsFilter(swigCPtr, out jarg, out nArrays, out compFlags, pExtents) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_filterPointsImpl(swigCPtr, out jarg, out nArrays, out compFlags, pExtents));
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

	protected override bool filterBoundingBoxImpl(OdGeBoundBlock3d arg0)
	{
		bool result = (SwigDerivedClassHasMethod("filterBoundingBoxImpl", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_filterBoundingBoxImplSwigExplicitOdGiPointCloudComponentsFilter(swigCPtr, OdGeBoundBlock3d.getCPtr(arg0)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_filterBoundingBoxImpl(swigCPtr, OdGeBoundBlock3d.getCPtr(arg0)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setComponentsRequest(uint compFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_setComponentsRequest(swigCPtr, compFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint componentsRequest()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_componentsRequest(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiPointCloud_ComponentsArray components()
	{
		OdGiPointCloud_ComponentsArray result = new OdGiPointCloud_ComponentsArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_components(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiPointCloudFilter createObject(uint compFlags, OdGiPointCloudFilter pPrevFilter)
	{
		OdGiPointCloudFilter rXObject = Helpers.GetRXObject<OdGiPointCloudFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_createObject__SWIG_0(compFlags, OdGiPointCloudFilter.getCPtr(pPrevFilter)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiPointCloudFilter createObject(uint compFlags)
	{
		OdGiPointCloudFilter rXObject = Helpers.GetRXObject<OdGiPointCloudFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_createObject__SWIG_1(compFlags), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiPointCloudComponentsFilter createObject()
	{
		OdGiPointCloudComponentsFilter rXObject = Helpers.GetRXObject<OdGiPointCloudComponentsFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_createObject__SWIG_2(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiPointCloudComponentsFilter()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPointCloudComponentsFilter(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiPointCloudComponentsFilter) != GetType();
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudComponentsFilter_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiPointCloudComponentsFilter));
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

	private bool SwigDirectorMethodfilterBoundingBoxImpl(IntPtr arg0)
	{
		return filterBoundingBoxImpl(new OdGeBoundBlock3d(arg0, cMemoryOwn: false));
	}

	private void SwigDirectorMethodextractTransformImpl(IntPtr arg0)
	{
		try
		{
			extractTransformImpl(new OdGeMatrix3d(arg0, cMemoryOwn: false));
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
