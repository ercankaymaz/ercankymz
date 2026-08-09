using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsCullingVolume : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGsCullingVolume_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsCullingVolume_1();

	public delegate void SwigDelegateOdGsCullingVolume_2(IntPtr pSource);

	public delegate int SwigDelegateOdGsCullingVolume_3();

	public delegate bool SwigDelegateOdGsCullingVolume_4(IntPtr prim);

	public delegate int SwigDelegateOdGsCullingVolume_5(IntPtr prim);

	public delegate void SwigDelegateOdGsCullingVolume_6(IntPtr xfm);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsCullingVolume_0 swigDelegate0;

	private SwigDelegateOdGsCullingVolume_1 swigDelegate1;

	private SwigDelegateOdGsCullingVolume_2 swigDelegate2;

	private SwigDelegateOdGsCullingVolume_3 swigDelegate3;

	private SwigDelegateOdGsCullingVolume_4 swigDelegate4;

	private SwigDelegateOdGsCullingVolume_5 swigDelegate5;

	private SwigDelegateOdGsCullingVolume_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGsCullingPrimitive) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGsCullingPrimitive) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGeMatrix3d) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsCullingVolume(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingVolume_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsCullingVolume obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsCullingVolume(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsCullingVolume cast(OdRxObject pObj)
	{
		OdGsCullingVolume rXObject = Helpers.GetRXObject<OdGsCullingVolume>(TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingVolume_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingVolume_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingVolume_isASwigExplicitOdGsCullingVolume(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingVolume_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingVolume_queryXSwigExplicitOdGsCullingVolume(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingVolume_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGsCullingVolume createObject()
	{
		OdGsCullingVolume rXObject = Helpers.GetRXObject<OdGsCullingVolume>(TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingVolume_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGsCullingVolume_ProjectionType projectionType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingVolume_projectionType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsCullingVolume_ProjectionType)result;
	}

	public virtual bool intersectWithOpt(OdGsCullingPrimitive prim)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingVolume_intersectWithOpt(swigCPtr, OdGsCullingPrimitive.getCPtr(prim));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGsCullingVolume_IntersectionStatus intersectWith(OdGsCullingPrimitive prim)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingVolume_intersectWith(swigCPtr, OdGsCullingPrimitive.getCPtr(prim));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsCullingVolume_IntersectionStatus)result;
	}

	public virtual void transformBy(OdGeMatrix3d xfm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingVolume_transformBy(swigCPtr, OdGeMatrix3d.getCPtr(xfm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingVolume_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsCullingVolume()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCullingVolume(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsCullingVolume) != GetType();
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
		if (SwigDerivedClassHasMethod("projectionType", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodprojectionType;
		}
		if (SwigDerivedClassHasMethod("intersectWithOpt", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodintersectWithOpt;
		}
		if (SwigDerivedClassHasMethod("intersectWith", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodintersectWith;
		}
		if (SwigDerivedClassHasMethod("transformBy", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodtransformBy;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsCullingVolume_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsCullingVolume));
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

	private int SwigDirectorMethodprojectionType()
	{
		return (int)projectionType();
	}

	private bool SwigDirectorMethodintersectWithOpt(IntPtr prim)
	{
		return intersectWithOpt(new OdGsCullingPrimitive(prim, cMemoryOwn: false));
	}

	private int SwigDirectorMethodintersectWith(IntPtr prim)
	{
		return (int)intersectWith(new OdGsCullingPrimitive(prim, cMemoryOwn: false));
	}

	private void SwigDirectorMethodtransformBy(IntPtr xfm)
	{
		try
		{
			transformBy(new OdGeMatrix3d(xfm, cMemoryOwn: false));
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
