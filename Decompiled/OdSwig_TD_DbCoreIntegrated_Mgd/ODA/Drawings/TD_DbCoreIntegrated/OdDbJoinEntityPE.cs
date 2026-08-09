using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbJoinEntityPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbJoinEntityPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbJoinEntityPE_1();

	public delegate void SwigDelegateOdDbJoinEntityPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbJoinEntityPE_3(IntPtr primaryEntity, IntPtr otherEntities, IntPtr joinedEntityIndices);

	public delegate int SwigDelegateOdDbJoinEntityPE_4(IntPtr primaryEntity, IntPtr secondaryEntity);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbJoinEntityPE_0 swigDelegate0;

	private SwigDelegateOdDbJoinEntityPE_1 swigDelegate1;

	private SwigDelegateOdDbJoinEntityPE_2 swigDelegate2;

	private SwigDelegateOdDbJoinEntityPE_3 swigDelegate3;

	private SwigDelegateOdDbJoinEntityPE_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntityPtrArray),
		typeof(OdIntArray)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdDbEntity)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbJoinEntityPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbJoinEntityPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbJoinEntityPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbJoinEntityPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbJoinEntityPE cast(OdRxObject pObj)
	{
		OdDbJoinEntityPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbJoinEntityPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbJoinEntityPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbJoinEntityPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbJoinEntityPE_isASwigExplicitOdDbJoinEntityPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbJoinEntityPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbJoinEntityPE_queryXSwigExplicitOdDbJoinEntityPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbJoinEntityPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbJoinEntityPE createObject()
	{
		OdDbJoinEntityPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbJoinEntityPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbJoinEntityPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult joinEntities(OdDbEntity primaryEntity, OdDbEntityPtrArray otherEntities, OdIntArray joinedEntityIndices)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbJoinEntityPE_joinEntities(swigCPtr, OdDbEntity.getCPtr(primaryEntity), OdDbEntityPtrArray.getCPtr(otherEntities), OdIntArray.getCPtr(joinedEntityIndices).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult joinEntity(OdDbEntity primaryEntity, OdDbEntity secondaryEntity)
	{
		int result = (SwigDerivedClassHasMethod("joinEntity", swigMethodTypes4) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbJoinEntityPE_joinEntitySwigExplicitOdDbJoinEntityPE(swigCPtr, OdDbEntity.getCPtr(primaryEntity), OdDbEntity.getCPtr(secondaryEntity)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbJoinEntityPE_joinEntity(swigCPtr, OdDbEntity.getCPtr(primaryEntity), OdDbEntity.getCPtr(secondaryEntity)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbJoinEntityPE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbJoinEntityPE()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbJoinEntityPE(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbJoinEntityPE) != GetType();
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
		if (SwigDerivedClassHasMethod("joinEntities", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodjoinEntities;
		}
		if (SwigDerivedClassHasMethod("joinEntity", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodjoinEntity;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbJoinEntityPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbJoinEntityPE));
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

	private int SwigDirectorMethodjoinEntities(IntPtr primaryEntity, IntPtr otherEntities, IntPtr joinedEntityIndices)
	{
		return (int)joinEntities(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(primaryEntity, bOwn: true, bTryAddToTransaction: false), new OdDbEntityPtrArray(otherEntities, cMemoryOwn: false), new OdIntArray(joinedEntityIndices, cMemoryOwn: true));
	}

	private int SwigDirectorMethodjoinEntity(IntPtr primaryEntity, IntPtr secondaryEntity)
	{
		return (int)joinEntity(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(primaryEntity, bOwn: true, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(secondaryEntity, bOwn: true, bTryAddToTransaction: false));
	}
}
