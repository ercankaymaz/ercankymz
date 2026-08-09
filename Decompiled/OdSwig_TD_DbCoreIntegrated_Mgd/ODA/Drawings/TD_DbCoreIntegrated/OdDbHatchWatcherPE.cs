using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbHatchWatcherPE : OdDbEvalWatcherPE
{
	public delegate IntPtr SwigDelegateOdDbHatchWatcherPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbHatchWatcherPE_1();

	public delegate void SwigDelegateOdDbHatchWatcherPE_2(IntPtr pSource);

	public delegate void SwigDelegateOdDbHatchWatcherPE_3(IntPtr pObj, IntPtr pAssocObj);

	public delegate void SwigDelegateOdDbHatchWatcherPE_4(IntPtr pObj, IntPtr pAssocObj);

	public delegate void SwigDelegateOdDbHatchWatcherPE_5(IntPtr pHatch);

	public delegate void SwigDelegateOdDbHatchWatcherPE_6(IntPtr pHatch, IntPtr assocObjIds);

	public delegate void SwigDelegateOdDbHatchWatcherPE_7(IntPtr pHatch, uint loopType, IntPtr objectIds, IntPtr edges);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbHatchWatcherPE_0 swigDelegate0;

	private SwigDelegateOdDbHatchWatcherPE_1 swigDelegate1;

	private SwigDelegateOdDbHatchWatcherPE_2 swigDelegate2;

	private SwigDelegateOdDbHatchWatcherPE_3 swigDelegate3;

	private SwigDelegateOdDbHatchWatcherPE_4 swigDelegate4;

	private SwigDelegateOdDbHatchWatcherPE_5 swigDelegate5;

	private SwigDelegateOdDbHatchWatcherPE_6 swigDelegate6;

	private SwigDelegateOdDbHatchWatcherPE_7 swigDelegate7;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObject)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDbObject)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbHatch) };

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdDbHatch),
		typeof(OdDbObjectIdArray)
	};

	private static Type[] swigMethodTypes7 = new Type[4]
	{
		typeof(OdDbHatch),
		typeof(uint).MakeByRefType(),
		typeof(OdDbObjectIdArray),
		typeof(OdArray_OdGeCurve2d__p_OdObjectsAllocator)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbHatchWatcherPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHatchWatcherPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbHatchWatcherPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbHatchWatcherPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override void modified(OdDbObject pObj, OdDbObject pAssocObj)
	{
		if (SwigDerivedClassHasMethod("modified", swigMethodTypes3))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHatchWatcherPE_modifiedSwigExplicitOdDbHatchWatcherPE(swigCPtr, OdDbObject.getCPtr(pObj), OdDbObject.getCPtr(pAssocObj));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHatchWatcherPE_modified(swigCPtr, OdDbObject.getCPtr(pObj), OdDbObject.getCPtr(pAssocObj));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void modifiedItself(OdDbHatch pHatch)
	{
		if (SwigDerivedClassHasMethod("modifiedItself", swigMethodTypes5))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHatchWatcherPE_modifiedItselfSwigExplicitOdDbHatchWatcherPE(swigCPtr, OdDbHatch.getCPtr(pHatch));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHatchWatcherPE_modifiedItself(swigCPtr, OdDbHatch.getCPtr(pHatch));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void evaluate(OdDbHatch pHatch, OdDbObjectIdArray assocObjIds)
	{
		if (SwigDerivedClassHasMethod("evaluate", swigMethodTypes6))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHatchWatcherPE_evaluateSwigExplicitOdDbHatchWatcherPE(swigCPtr, OdDbHatch.getCPtr(pHatch), OdDbObjectIdArray.getCPtr(assocObjIds));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHatchWatcherPE_evaluate(swigCPtr, OdDbHatch.getCPtr(pHatch), OdDbObjectIdArray.getCPtr(assocObjIds));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void getLoopFromIds(OdDbHatch pHatch, out uint loopType, OdDbObjectIdArray objectIds, OdArray_OdGeCurve2d__p_OdObjectsAllocator edges)
	{
		if (SwigDerivedClassHasMethod("getLoopFromIds", swigMethodTypes7))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHatchWatcherPE_getLoopFromIdsSwigExplicitOdDbHatchWatcherPE(swigCPtr, OdDbHatch.getCPtr(pHatch), out loopType, OdDbObjectIdArray.getCPtr(objectIds), OdArray_OdGeCurve2d__p_OdObjectsAllocator.getCPtr(edges).Handle);
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHatchWatcherPE_getLoopFromIds(swigCPtr, OdDbHatch.getCPtr(pHatch), out loopType, OdDbObjectIdArray.getCPtr(objectIds), OdArray_OdGeCurve2d__p_OdObjectsAllocator.getCPtr(edges).Handle);
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHatchWatcherPE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdDbHatchWatcherPE createObject()
	{
		OdDbHatchWatcherPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbHatchWatcherPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHatchWatcherPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbHatchWatcherPE()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbHatchWatcherPE(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbHatchWatcherPE) != GetType();
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
		if (SwigDerivedClassHasMethod("modified", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodmodified;
		}
		if (SwigDerivedClassHasMethod("openedForModify", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodopenedForModify;
		}
		if (SwigDerivedClassHasMethod("modifiedItself", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodmodifiedItself;
		}
		if (SwigDerivedClassHasMethod("evaluate", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodevaluate;
		}
		if (SwigDerivedClassHasMethod("getLoopFromIds", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetLoopFromIds;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbHatchWatcherPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbHatchWatcherPE));
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

	private void SwigDirectorMethodmodified(IntPtr pObj, IntPtr pAssocObj)
	{
		try
		{
			modified(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObj, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pAssocObj, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodopenedForModify(IntPtr pObj, IntPtr pAssocObj)
	{
		try
		{
			openedForModify(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pObj, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pAssocObj, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodmodifiedItself(IntPtr pHatch)
	{
		try
		{
			modifiedItself(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbHatch>(pHatch, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodevaluate(IntPtr pHatch, IntPtr assocObjIds)
	{
		try
		{
			evaluate(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbHatch>(pHatch, bOwn: false, bTryAddToTransaction: false), new OdDbObjectIdArray(assocObjIds, cMemoryOwn: false));
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

	private void SwigDirectorMethodgetLoopFromIds(IntPtr pHatch, uint loopType, IntPtr objectIds, IntPtr edges)
	{
		try
		{
			getLoopFromIds(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbHatch>(pHatch, bOwn: false, bTryAddToTransaction: false), out loopType, new OdDbObjectIdArray(objectIds, cMemoryOwn: false), new OdArray_OdGeCurve2d__p_OdObjectsAllocator(edges, cMemoryOwn: true));
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
}
