using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPointCloudFilter : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiPointCloudFilter_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiPointCloudFilter_1();

	public delegate void SwigDelegateOdGiPointCloudFilter_2(IntPtr pSource);

	public delegate bool SwigDelegateOdGiPointCloudFilter_3(IntPtr pArrays, uint nArrays, uint compFlags, IntPtr pExtents);

	public delegate bool SwigDelegateOdGiPointCloudFilter_4(IntPtr bb);

	public delegate void SwigDelegateOdGiPointCloudFilter_5(IntPtr arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiPointCloudFilter_0 swigDelegate0;

	private SwigDelegateOdGiPointCloudFilter_1 swigDelegate1;

	private SwigDelegateOdGiPointCloudFilter_2 swigDelegate2;

	private SwigDelegateOdGiPointCloudFilter_3 swigDelegate3;

	private SwigDelegateOdGiPointCloudFilter_4 swigDelegate4;

	private SwigDelegateOdGiPointCloudFilter_5 swigDelegate5;

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
	public OdGiPointCloudFilter(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPointCloudFilter obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPointCloudFilter(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiPointCloudFilter cast(OdRxObject pObj)
	{
		OdGiPointCloudFilter rXObject = Helpers.GetRXObject<OdGiPointCloudFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_isASwigExplicitOdGiPointCloudFilter(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_queryXSwigExplicitOdGiPointCloudFilter(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiPointCloudFilter createObject()
	{
		OdGiPointCloudFilter rXObject = Helpers.GetRXObject<OdGiPointCloudFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void attachFilter(OdGiPointCloudFilter pFilter)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_attachFilter(swigCPtr, getCPtr(pFilter));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiPointCloudFilter detachFilter()
	{
		OdGiPointCloudFilter rXObject = Helpers.GetRXObject<OdGiPointCloudFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_detachFilter(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected virtual bool filterPointsImpl(out OdGiPointCloud.ComponentsRaw pArrays, out uint nArrays, out uint compFlags, OdGeBoundBlock3d pExtents)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_filterPointsImpl(swigCPtr, out jarg, out nArrays, out compFlags, pExtents);
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
			pArrays = Helpers.odCreateObjectInternal<OdGiPointCloud.ComponentsRaw>(typeof(OdGiPointCloud.ComponentsRaw), jarg, currentTransaction == null);
		}
	}

	protected virtual bool filterBoundingBoxImpl(OdGeBoundBlock3d bb)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_filterBoundingBoxImpl(swigCPtr, OdGeBoundBlock3d.getCPtr(bb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected virtual void extractTransformImpl(OdGeMatrix3d arg0)
	{
		if (SwigDerivedClassHasMethod("extractTransformImpl", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_extractTransformImplSwigExplicitOdGiPointCloudFilter(swigCPtr, OdGeMatrix3d.getCPtr(arg0));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_extractTransformImpl(swigCPtr, OdGeMatrix3d.getCPtr(arg0));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool filterBoundingBox(OdGeBoundBlock3d bb)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_filterBoundingBox(swigCPtr, OdGeBoundBlock3d.getCPtr(bb));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGeMatrix3d extractTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_extractTransform(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiPointCloudFilter previousFilter()
	{
		OdGiPointCloudFilter rXObject = Helpers.GetRXObject<OdGiPointCloudFilter>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_previousFilter(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_getRealClassName(ptr);
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloudFilter_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiPointCloudFilter));
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

	private bool SwigDirectorMethodfilterPointsImpl(IntPtr pArrays, uint nArrays, uint compFlags, IntPtr pExtents)
	{
		OdGiPointCloud.ComponentsRaw pArrays2 = new OdGiPointCloud.ComponentsRaw(pArrays, cMemoryOwn: true);
		OdGeBoundBlock3d pExtents2 = new OdGeBoundBlock3d(pExtents, cMemoryOwn: true);
		try
		{
			return filterPointsImpl(out pArrays2, out nArrays, out compFlags, pExtents2);
		}
		finally
		{
			pArrays = OdGiPointCloud.ComponentsRaw.getCPtr(pArrays2).Handle;
		}
	}

	private bool SwigDirectorMethodfilterBoundingBoxImpl(IntPtr bb)
	{
		return filterBoundingBoxImpl(new OdGeBoundBlock3d(bb, cMemoryOwn: false));
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
