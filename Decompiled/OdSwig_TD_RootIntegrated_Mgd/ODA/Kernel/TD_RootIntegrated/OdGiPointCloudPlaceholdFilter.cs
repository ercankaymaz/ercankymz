using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPointCloudPlaceholdFilter : OdGiPointCloudFilter
{
	public delegate IntPtr SwigDelegateOdGiPointCloudPlaceholdFilter_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiPointCloudPlaceholdFilter_1();

	public delegate void SwigDelegateOdGiPointCloudPlaceholdFilter_2(IntPtr pSource);

	public delegate bool SwigDelegateOdGiPointCloudPlaceholdFilter_3(IntPtr arg0, uint arg1, uint arg2, IntPtr arg3);

	public delegate bool SwigDelegateOdGiPointCloudPlaceholdFilter_4(IntPtr arg0);

	public delegate void SwigDelegateOdGiPointCloudPlaceholdFilter_5(IntPtr arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiPointCloudPlaceholdFilter_0 swigDelegate0;

	private SwigDelegateOdGiPointCloudPlaceholdFilter_1 swigDelegate1;

	private SwigDelegateOdGiPointCloudPlaceholdFilter_2 swigDelegate2;

	private SwigDelegateOdGiPointCloudPlaceholdFilter_3 swigDelegate3;

	private SwigDelegateOdGiPointCloudPlaceholdFilter_4 swigDelegate4;

	private SwigDelegateOdGiPointCloudPlaceholdFilter_5 swigDelegate5;

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
	public OdGiPointCloudPlaceholdFilter(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudPlaceholdFilter_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPointCloudPlaceholdFilter obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPointCloudPlaceholdFilter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected override bool filterPointsImpl(out OdGiPointCloud.ComponentsRaw arg0, out uint arg1, out uint arg2, OdGeBoundBlock3d arg3)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			bool result = (SwigDerivedClassHasMethod("filterPointsImpl", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudPlaceholdFilter_filterPointsImplSwigExplicitOdGiPointCloudPlaceholdFilter(swigCPtr, out jarg, out arg1, out arg2, arg3) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudPlaceholdFilter_filterPointsImpl(swigCPtr, out jarg, out arg1, out arg2, arg3));
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
			arg0 = Helpers.odCreateObjectInternal<OdGiPointCloud.ComponentsRaw>(typeof(OdGiPointCloud.ComponentsRaw), jarg, currentTransaction == null);
		}
	}

	protected override bool filterBoundingBoxImpl(OdGeBoundBlock3d arg0)
	{
		bool result = (SwigDerivedClassHasMethod("filterBoundingBoxImpl", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudPlaceholdFilter_filterBoundingBoxImplSwigExplicitOdGiPointCloudPlaceholdFilter(swigCPtr, OdGeBoundBlock3d.getCPtr(arg0)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudPlaceholdFilter_filterBoundingBoxImpl(swigCPtr, OdGeBoundBlock3d.getCPtr(arg0)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiPointCloudFilter createObject(OdGiPointCloudFilter pPrevFilter, bool bForce)
	{
		OdGiPointCloudFilter rXObject = Helpers.GetRXObject<OdGiPointCloudFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudPlaceholdFilter_createObject__SWIG_0(OdGiPointCloudFilter.getCPtr(pPrevFilter), bForce), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiPointCloudFilter createObject(OdGiPointCloudFilter pPrevFilter)
	{
		OdGiPointCloudFilter rXObject = Helpers.GetRXObject<OdGiPointCloudFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudPlaceholdFilter_createObject__SWIG_1(OdGiPointCloudFilter.getCPtr(pPrevFilter)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudPlaceholdFilter_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiPointCloudPlaceholdFilter createObject()
	{
		OdGiPointCloudPlaceholdFilter rXObject = Helpers.GetRXObject<OdGiPointCloudPlaceholdFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudPlaceholdFilter_createObject__SWIG_2(), bOwn: true, bTryAddToTransaction: true);
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudPlaceholdFilter_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiPointCloudPlaceholdFilter));
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

	private bool SwigDirectorMethodfilterPointsImpl(IntPtr arg0, uint arg1, uint arg2, IntPtr arg3)
	{
		OdGiPointCloud.ComponentsRaw pArrays = new OdGiPointCloud.ComponentsRaw(arg0, cMemoryOwn: true);
		OdGeBoundBlock3d pExtents = new OdGeBoundBlock3d(arg3, cMemoryOwn: true);
		try
		{
			return filterPointsImpl(out pArrays, out arg1, out arg2, pExtents);
		}
		finally
		{
			arg0 = OdGiPointCloud.ComponentsRaw.getCPtr(pArrays).Handle;
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
