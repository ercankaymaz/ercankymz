using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbSelectionSetIterator : OdSelectionSetIterator
{
	public delegate IntPtr SwigDelegateOdDbSelectionSetIterator_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbSelectionSetIterator_1();

	public delegate void SwigDelegateOdDbSelectionSetIterator_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdDbSelectionSetIterator_3();

	public delegate bool SwigDelegateOdDbSelectionSetIterator_4();

	public delegate bool SwigDelegateOdDbSelectionSetIterator_5();

	public delegate uint SwigDelegateOdDbSelectionSetIterator_6();

	public delegate bool SwigDelegateOdDbSelectionSetIterator_7(uint i, IntPtr path);

	public delegate IntPtr SwigDelegateOdDbSelectionSetIterator_8();

	public delegate IntPtr SwigDelegateOdDbSelectionSetIterator_9();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbSelectionSetIterator_0 swigDelegate0;

	private SwigDelegateOdDbSelectionSetIterator_1 swigDelegate1;

	private SwigDelegateOdDbSelectionSetIterator_2 swigDelegate2;

	private SwigDelegateOdDbSelectionSetIterator_3 swigDelegate3;

	private SwigDelegateOdDbSelectionSetIterator_4 swigDelegate4;

	private SwigDelegateOdDbSelectionSetIterator_5 swigDelegate5;

	private SwigDelegateOdDbSelectionSetIterator_6 swigDelegate6;

	private SwigDelegateOdDbSelectionSetIterator_7 swigDelegate7;

	private SwigDelegateOdDbSelectionSetIterator_8 swigDelegate8;

	private SwigDelegateOdDbSelectionSetIterator_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(uint),
		typeof(OdDbBaseFullSubentPath)
	};

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbSelectionSetIterator(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSetIterator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbSelectionSetIterator obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbSelectionSetIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbSelectionSetIterator cast(OdRxObject pObj)
	{
		OdDbSelectionSetIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionSetIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSetIterator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSetIterator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSetIterator_isASwigExplicitOdDbSelectionSetIterator(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSetIterator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSetIterator_queryXSwigExplicitOdDbSelectionSetIterator(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSetIterator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdDbSelectionSetIterator createObject()
	{
		OdDbSelectionSetIterator rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionSetIterator>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSetIterator_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbObjectId objectId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSetIterator_objectId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected OdDbSelectionSetIterator()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbSelectionSetIterator(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbSelectionSetIterator) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSetIterator_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("method", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodmethod;
		}
		if (SwigDerivedClassHasMethod("done", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddone;
		}
		if (SwigDerivedClassHasMethod("next", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodnext;
		}
		if (SwigDerivedClassHasMethod("subentCount", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsubentCount;
		}
		if (SwigDerivedClassHasMethod("getSubentity", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetSubentity;
		}
		if (SwigDerivedClassHasMethod("id", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodid;
		}
		if (SwigDerivedClassHasMethod("objectId", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodobjectId;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSelectionSetIterator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbSelectionSetIterator));
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

	private IntPtr SwigDirectorMethodmethod()
	{
		return OdDbSelectionMethod.getCPtr(method()).Handle;
	}

	private bool SwigDirectorMethoddone()
	{
		return done();
	}

	private bool SwigDirectorMethodnext()
	{
		return next();
	}

	private uint SwigDirectorMethodsubentCount()
	{
		return subentCount();
	}

	private bool SwigDirectorMethodgetSubentity(uint i, IntPtr path)
	{
		return getSubentity(i, new OdDbBaseFullSubentPath(path, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodid()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(id()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private IntPtr SwigDirectorMethodobjectId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbObjectId.getCPtr(objectId()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}
}
