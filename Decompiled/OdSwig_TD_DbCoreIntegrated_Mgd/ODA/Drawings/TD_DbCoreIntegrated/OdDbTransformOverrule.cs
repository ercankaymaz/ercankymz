using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbTransformOverrule : OdRxOverrule
{
	public delegate IntPtr SwigDelegateOdDbTransformOverrule_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbTransformOverrule_1();

	public delegate void SwigDelegateOdDbTransformOverrule_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbTransformOverrule_3(IntPtr pOverruledSubject);

	public delegate int SwigDelegateOdDbTransformOverrule_4(IntPtr pSubject, IntPtr xform);

	public delegate int SwigDelegateOdDbTransformOverrule_5(IntPtr pSubject, IntPtr xform, IntPtr pEnt);

	public delegate int SwigDelegateOdDbTransformOverrule_6(IntPtr pSubject, IntPtr entitySet);

	public delegate bool SwigDelegateOdDbTransformOverrule_7(IntPtr pSubject);

	public delegate bool SwigDelegateOdDbTransformOverrule_8(IntPtr pSubject);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbTransformOverrule_0 swigDelegate0;

	private SwigDelegateOdDbTransformOverrule_1 swigDelegate1;

	private SwigDelegateOdDbTransformOverrule_2 swigDelegate2;

	private SwigDelegateOdDbTransformOverrule_3 swigDelegate3;

	private SwigDelegateOdDbTransformOverrule_4 swigDelegate4;

	private SwigDelegateOdDbTransformOverrule_5 swigDelegate5;

	private SwigDelegateOdDbTransformOverrule_6 swigDelegate6;

	private SwigDelegateOdDbTransformOverrule_7 swigDelegate7;

	private SwigDelegateOdDbTransformOverrule_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(OdGeMatrix3d),
		typeof(OdDbEntity).MakeByRefType()
	};

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdRxObjectPtrArray)
	};

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdDbEntity) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdDbEntity) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbTransformOverrule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbTransformOverrule obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbTransformOverrule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbTransformOverrule()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbTransformOverrule(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbTransformOverrule cast(OdRxObject pObj)
	{
		OdDbTransformOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTransformOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_isASwigExplicitOdDbTransformOverrule(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_queryXSwigExplicitOdDbTransformOverrule(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbTransformOverrule createObject()
	{
		OdDbTransformOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbTransformOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult transformBy(OdDbEntity pSubject, OdGeMatrix3d xform)
	{
		int result = (SwigDerivedClassHasMethod("transformBy", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_transformBySwigExplicitOdDbTransformOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), OdGeMatrix3d.getCPtr(xform)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_transformBy(swigCPtr, OdDbEntity.getCPtr(pSubject), OdGeMatrix3d.getCPtr(xform)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getTransformedCopy(OdDbEntity pSubject, OdGeMatrix3d xform, ref OdDbEntity pEnt)
	{
		IntPtr jarg = ((pEnt == null) ? IntPtr.Zero : OdDbEntity.getCPtr(pEnt).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = (SwigDerivedClassHasMethod("getTransformedCopy", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_getTransformedCopySwigExplicitOdDbTransformOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), OdGeMatrix3d.getCPtr(xform), ref jarg) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_getTransformedCopy(swigCPtr, OdDbEntity.getCPtr(pSubject), OdGeMatrix3d.getCPtr(xform), ref jarg));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pEnt = null;
			}
			else if (jarg != intPtr)
			{
				pEnt = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult explode(OdDbEntity pSubject, OdRxObjectPtrArray entitySet)
	{
		int result = (SwigDerivedClassHasMethod("explode", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_explodeSwigExplicitOdDbTransformOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject), OdRxObjectPtrArray.getCPtr(entitySet).Handle) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_explode(swigCPtr, OdDbEntity.getCPtr(pSubject), OdRxObjectPtrArray.getCPtr(entitySet).Handle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool cloneMeForDragging(OdDbEntity pSubject)
	{
		bool result = (SwigDerivedClassHasMethod("cloneMeForDragging", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_cloneMeForDraggingSwigExplicitOdDbTransformOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_cloneMeForDragging(swigCPtr, OdDbEntity.getCPtr(pSubject)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool hideMeForDragging(OdDbEntity pSubject)
	{
		bool result = (SwigDerivedClassHasMethod("hideMeForDragging", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_hideMeForDraggingSwigExplicitOdDbTransformOverrule(swigCPtr, OdDbEntity.getCPtr(pSubject)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_hideMeForDragging(swigCPtr, OdDbEntity.getCPtr(pSubject)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("isApplicable", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodisApplicable;
		}
		if (SwigDerivedClassHasMethod("transformBy", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodtransformBy;
		}
		if (SwigDerivedClassHasMethod("getTransformedCopy", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetTransformedCopy;
		}
		if (SwigDerivedClassHasMethod("explode", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodexplode;
		}
		if (SwigDerivedClassHasMethod("cloneMeForDragging", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodcloneMeForDragging;
		}
		if (SwigDerivedClassHasMethod("hideMeForDragging", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodhideMeForDragging;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbTransformOverrule_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbTransformOverrule));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisApplicable(IntPtr pOverruledSubject)
	{
		return isApplicable(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pOverruledSubject, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethodtransformBy(IntPtr pSubject, IntPtr xform)
	{
		return (int)transformBy(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdGeMatrix3d(xform, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetTransformedCopy(IntPtr pSubject, IntPtr xform, IntPtr pEnt)
	{
		OdSwigDirectorHelper.director_UnpackData(pEnt, out var pOriginalObject, out var pFunction);
		OdDbEntity pEnt2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)getTransformedCopy(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdGeMatrix3d(xform, cMemoryOwn: false), ref pEnt2);
		}
		finally
		{
			IntPtr handle = OdDbEntity.getCPtr(pEnt2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pEnt);
		}
	}

	private int SwigDirectorMethodexplode(IntPtr pSubject, IntPtr entitySet)
	{
		return (int)explode(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false), new OdRxObjectPtrArray(entitySet, cMemoryOwn: true));
	}

	private bool SwigDirectorMethodcloneMeForDragging(IntPtr pSubject)
	{
		return cloneMeForDragging(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodhideMeForDragging(IntPtr pSubject)
	{
		return hideMeForDragging(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pSubject, bOwn: false, bTryAddToTransaction: false));
	}
}
