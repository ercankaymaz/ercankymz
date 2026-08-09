using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdIBrMeshEntity : OdRxObject
{
	public delegate IntPtr SwigDelegateOdIBrMeshEntity_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateOdIBrMeshEntity_1();

	public delegate void SwigDelegateOdIBrMeshEntity_2(IntPtr pSource);

	public delegate int SwigDelegateOdIBrMeshEntity_3(IntPtr entity);

	public delegate bool SwigDelegateOdIBrMeshEntity_4();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdIBrMeshEntity_0 swigDelegate0;

	private SwigDelegateOdIBrMeshEntity_1 swigDelegate1;

	private SwigDelegateOdIBrMeshEntity_2 swigDelegate2;

	private SwigDelegateOdIBrMeshEntity_3 swigDelegate3;

	private SwigDelegateOdIBrMeshEntity_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdBrEntity).MakeByRefType() };

	private static Type[] swigMethodTypes4 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdIBrMeshEntity(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshEntity_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdIBrMeshEntity obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdIBrMeshEntity(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual OdBrErrorStatus getEntityAssociated(out OdBrEntity entity)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			int result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshEntity_getEntityAssociated(swigCPtr, out jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdBrErrorStatus)result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdBrEntity>(typeof(OdBrEntity), jarg, bIsWrapperOwnNativeObject: true));
			entity = Helpers.odCreateObjectInternal<OdBrEntity>(typeof(OdBrEntity), jarg, currentTransaction == null);
		}
	}

	public virtual bool brepChanged()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshEntity_brepChanged(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected OdIBrMeshEntity()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdIBrMeshEntity(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdIBrMeshEntity) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshEntity_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("getEntityAssociated", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetEntityAssociated;
		}
		if (SwigDerivedClassHasMethod("brepChanged", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodbrepChanged;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdIBrMeshEntity_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdIBrMeshEntity));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr pClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(pClass, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private int SwigDirectorMethodgetEntityAssociated(IntPtr entity)
	{
		OdBrEntity entity2 = new OdBrEntity(entity, cMemoryOwn: true);
		try
		{
			return (int)getEntityAssociated(out entity2);
		}
		finally
		{
			entity = OdBrEntity.getCPtr(entity2).Handle;
		}
	}

	private bool SwigDirectorMethodbrepChanged()
	{
		return brepChanged();
	}
}
