using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbObjectOverrule : OdRxOverrule
{
	public delegate IntPtr SwigDelegateOdDbObjectOverrule_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbObjectOverrule_1();

	public delegate void SwigDelegateOdDbObjectOverrule_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbObjectOverrule_3(IntPtr pOverruledSubject);

	public delegate int SwigDelegateOdDbObjectOverrule_4(IntPtr pSubject, int mode);

	public delegate int SwigDelegateOdDbObjectOverrule_5(IntPtr pSubject);

	public delegate int SwigDelegateOdDbObjectOverrule_6(IntPtr pSubject, bool erasing);

	public delegate IntPtr SwigDelegateOdDbObjectOverrule_7(IntPtr pSubject, IntPtr idMap, IntPtr pOwner, bool bPrimary);

	public delegate IntPtr SwigDelegateOdDbObjectOverrule_8(IntPtr pSubject, IntPtr idMap, IntPtr pOwner);

	public delegate IntPtr SwigDelegateOdDbObjectOverrule_9(IntPtr pSubject, IntPtr idMap, IntPtr pOwner, bool bPrimary);

	public delegate IntPtr SwigDelegateOdDbObjectOverrule_10(IntPtr pSubject, IntPtr idMap, IntPtr pOwner);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbObjectOverrule_0 swigDelegate0;

	private SwigDelegateOdDbObjectOverrule_1 swigDelegate1;

	private SwigDelegateOdDbObjectOverrule_2 swigDelegate2;

	private SwigDelegateOdDbObjectOverrule_3 swigDelegate3;

	private SwigDelegateOdDbObjectOverrule_4 swigDelegate4;

	private SwigDelegateOdDbObjectOverrule_5 swigDelegate5;

	private SwigDelegateOdDbObjectOverrule_6 swigDelegate6;

	private SwigDelegateOdDbObjectOverrule_7 swigDelegate7;

	private SwigDelegateOdDbObjectOverrule_8 swigDelegate8;

	private SwigDelegateOdDbObjectOverrule_9 swigDelegate9;

	private SwigDelegateOdDbObjectOverrule_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(OdDb_OpenMode)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdDbObject) };

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(OdDbObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes7 = new Type[4]
	{
		typeof(OdDbObject),
		typeof(OdDbIdMapping).MakeByRefType(),
		typeof(OdDbObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes8 = new Type[3]
	{
		typeof(OdDbObject),
		typeof(OdDbIdMapping).MakeByRefType(),
		typeof(OdDbObject)
	};

	private static Type[] swigMethodTypes9 = new Type[4]
	{
		typeof(OdDbObject),
		typeof(OdDbIdMapping).MakeByRefType(),
		typeof(OdDbObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes10 = new Type[3]
	{
		typeof(OdDbObject),
		typeof(OdDbIdMapping).MakeByRefType(),
		typeof(OdDbObject)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbObjectOverrule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbObjectOverrule obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbObjectOverrule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbObjectOverrule()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbObjectOverrule(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdDbObjectOverrule cast(OdRxObject pObj)
	{
		OdDbObjectOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_isASwigExplicitOdDbObjectOverrule(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_queryXSwigExplicitOdDbObjectOverrule(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbObjectOverrule createObject()
	{
		OdDbObjectOverrule rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectOverrule>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult open(OdDbObject pSubject, OdDb_OpenMode mode)
	{
		int result = (SwigDerivedClassHasMethod("open", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_openSwigExplicitOdDbObjectOverrule(swigCPtr, OdDbObject.getCPtr(pSubject), (int)mode) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_open(swigCPtr, OdDbObject.getCPtr(pSubject), (int)mode));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult close(OdDbObject pSubject)
	{
		int result = (SwigDerivedClassHasMethod("close", swigMethodTypes5) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_closeSwigExplicitOdDbObjectOverrule(swigCPtr, OdDbObject.getCPtr(pSubject)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_close(swigCPtr, OdDbObject.getCPtr(pSubject)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult erase(OdDbObject pSubject, bool erasing)
	{
		int result = (SwigDerivedClassHasMethod("erase", swigMethodTypes6) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_eraseSwigExplicitOdDbObjectOverrule(swigCPtr, OdDbObject.getCPtr(pSubject), erasing) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_erase(swigCPtr, OdDbObject.getCPtr(pSubject), erasing));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdDbObject deepClone(OdDbObject pSubject, ref OdDbIdMapping idMap, OdDbObject pOwner, bool bPrimary)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(SwigDerivedClassHasMethod("deepClone", swigMethodTypes7) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_deepCloneSwigExplicitOdDbObjectOverrule__SWIG_0(swigCPtr, OdDbObject.getCPtr(pSubject), ref jarg, OdDbObject.getCPtr(pOwner), bPrimary) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_deepClone__SWIG_0(swigCPtr, OdDbObject.getCPtr(pSubject), ref jarg, OdDbObject.getCPtr(pOwner), bPrimary), bOwn: true, bTryAddToTransaction: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				idMap = null;
			}
			if (jarg != intPtr)
			{
				idMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdDbObject deepClone(OdDbObject pSubject, ref OdDbIdMapping idMap, OdDbObject pOwner)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(SwigDerivedClassHasMethod("deepClone", swigMethodTypes8) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_deepCloneSwigExplicitOdDbObjectOverrule__SWIG_1(swigCPtr, OdDbObject.getCPtr(pSubject), ref jarg, OdDbObject.getCPtr(pOwner)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_deepClone__SWIG_1(swigCPtr, OdDbObject.getCPtr(pSubject), ref jarg, OdDbObject.getCPtr(pOwner)), bOwn: true, bTryAddToTransaction: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				idMap = null;
			}
			if (jarg != intPtr)
			{
				idMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdDbObject wblockClone(OdDbObject pSubject, ref OdDbIdMapping idMap, OdDbObject pOwner, bool bPrimary)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(SwigDerivedClassHasMethod("wblockClone", swigMethodTypes9) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_wblockCloneSwigExplicitOdDbObjectOverrule__SWIG_0(swigCPtr, OdDbObject.getCPtr(pSubject), ref jarg, OdDbObject.getCPtr(pOwner), bPrimary) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_wblockClone__SWIG_0(swigCPtr, OdDbObject.getCPtr(pSubject), ref jarg, OdDbObject.getCPtr(pOwner), bPrimary), bOwn: true, bTryAddToTransaction: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				idMap = null;
			}
			if (jarg != intPtr)
			{
				idMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdDbObject wblockClone(OdDbObject pSubject, ref OdDbIdMapping idMap, OdDbObject pOwner)
	{
		IntPtr jarg = ((idMap == null) ? IntPtr.Zero : OdDbIdMapping.getCPtr(idMap).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(SwigDerivedClassHasMethod("wblockClone", swigMethodTypes10) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_wblockCloneSwigExplicitOdDbObjectOverrule__SWIG_1(swigCPtr, OdDbObject.getCPtr(pSubject), ref jarg, OdDbObject.getCPtr(pOwner)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_wblockClone__SWIG_1(swigCPtr, OdDbObject.getCPtr(pSubject), ref jarg, OdDbObject.getCPtr(pOwner)), bOwn: true, bTryAddToTransaction: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				idMap = null;
			}
			if (jarg != intPtr)
			{
				idMap = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("open", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodopen;
		}
		if (SwigDerivedClassHasMethod("close", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodclose;
		}
		if (SwigDerivedClassHasMethod("erase", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoderase;
		}
		if (SwigDerivedClassHasMethod("deepClone", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethoddeepClone__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("deepClone", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethoddeepClone__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("wblockClone", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodwblockClone__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("wblockClone", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodwblockClone__SWIG_1;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectOverrule_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbObjectOverrule));
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

	private int SwigDirectorMethodopen(IntPtr pSubject, int mode)
	{
		return (int)open(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pSubject, bOwn: false, bTryAddToTransaction: false), (OdDb_OpenMode)mode);
	}

	private int SwigDirectorMethodclose(IntPtr pSubject)
	{
		return (int)close(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pSubject, bOwn: false, bTryAddToTransaction: false));
	}

	private int SwigDirectorMethoderase(IntPtr pSubject, bool erasing)
	{
		return (int)erase(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pSubject, bOwn: false, bTryAddToTransaction: false), erasing);
	}

	private IntPtr SwigDirectorMethoddeepClone__SWIG_0(IntPtr pSubject, IntPtr idMap, IntPtr pOwner, bool bPrimary)
	{
		OdSwigDirectorHelper.director_UnpackData(idMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping idMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return OdDbObject.getCPtr(deepClone(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pSubject, bOwn: false, bTryAddToTransaction: false), ref idMap2, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pOwner, bOwn: false, bTryAddToTransaction: false), bPrimary)).Handle;
		}
		finally
		{
			IntPtr handle = OdDbIdMapping.getCPtr(idMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(idMap);
		}
	}

	private IntPtr SwigDirectorMethoddeepClone__SWIG_1(IntPtr pSubject, IntPtr idMap, IntPtr pOwner)
	{
		OdSwigDirectorHelper.director_UnpackData(idMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping idMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return OdDbObject.getCPtr(deepClone(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pSubject, bOwn: false, bTryAddToTransaction: false), ref idMap2, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pOwner, bOwn: false, bTryAddToTransaction: false))).Handle;
		}
		finally
		{
			IntPtr handle = OdDbIdMapping.getCPtr(idMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(idMap);
		}
	}

	private IntPtr SwigDirectorMethodwblockClone__SWIG_0(IntPtr pSubject, IntPtr idMap, IntPtr pOwner, bool bPrimary)
	{
		OdSwigDirectorHelper.director_UnpackData(idMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping idMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return OdDbObject.getCPtr(wblockClone(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pSubject, bOwn: false, bTryAddToTransaction: false), ref idMap2, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pOwner, bOwn: false, bTryAddToTransaction: false), bPrimary)).Handle;
		}
		finally
		{
			IntPtr handle = OdDbIdMapping.getCPtr(idMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(idMap);
		}
	}

	private IntPtr SwigDirectorMethodwblockClone__SWIG_1(IntPtr pSubject, IntPtr idMap, IntPtr pOwner)
	{
		OdSwigDirectorHelper.director_UnpackData(idMap, out var pOriginalObject, out var pFunction);
		OdDbIdMapping idMap2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbIdMapping>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return OdDbObject.getCPtr(wblockClone(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pSubject, bOwn: false, bTryAddToTransaction: false), ref idMap2, ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(pOwner, bOwn: false, bTryAddToTransaction: false))).Handle;
		}
		finally
		{
			IntPtr handle = OdDbIdMapping.getCPtr(idMap2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(idMap);
		}
	}
}
