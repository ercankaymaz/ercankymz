using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbBaseBlockPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbBaseBlockPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbBaseBlockPE_1();

	public delegate void SwigDelegateOdDbBaseBlockPE_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbBaseBlockPE_3(IntPtr pBlock);

	public delegate bool SwigDelegateOdDbBaseBlockPE_4(IntPtr pBlock);

	public delegate IntPtr SwigDelegateOdDbBaseBlockPE_5(IntPtr pBlock);

	public delegate IntPtr SwigDelegateOdDbBaseBlockPE_6(IntPtr pBlock);

	public delegate bool SwigDelegateOdDbBaseBlockPE_7(IntPtr pBlock);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbBaseBlockPE_8(IntPtr pBlock);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbBaseBlockPE_0 swigDelegate0;

	private SwigDelegateOdDbBaseBlockPE_1 swigDelegate1;

	private SwigDelegateOdDbBaseBlockPE_2 swigDelegate2;

	private SwigDelegateOdDbBaseBlockPE_3 swigDelegate3;

	private SwigDelegateOdDbBaseBlockPE_4 swigDelegate4;

	private SwigDelegateOdDbBaseBlockPE_5 swigDelegate5;

	private SwigDelegateOdDbBaseBlockPE_6 swigDelegate6;

	private SwigDelegateOdDbBaseBlockPE_7 swigDelegate7;

	private SwigDelegateOdDbBaseBlockPE_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBaseBlockPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBaseBlockPE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbBaseBlockPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbBaseBlockPE cast(OdRxObject pObj)
	{
		OdDbBaseBlockPE rXObject = Helpers.GetRXObject<OdDbBaseBlockPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockPE_isASwigExplicitOdDbBaseBlockPE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockPE_queryXSwigExplicitOdDbBaseBlockPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseBlockPE createObject()
	{
		OdDbBaseBlockPE rXObject = Helpers.GetRXObject<OdDbBaseBlockPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool isBlockReferenceAdded(OdRxObject pBlock)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockPE_isBlockReferenceAdded(swigCPtr, OdRxObject.getCPtr(pBlock));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isFromExternalReference(OdRxObject pBlock)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockPE_isFromExternalReference(swigCPtr, OdRxObject.getCPtr(pBlock));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxObject xrefDatabase(OdRxObject pBlock)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockPE_xrefDatabase(swigCPtr, OdRxObject.getCPtr(pBlock)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbStub getLayoutId(OdRxObject pBlock)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockPE_getLayoutId(swigCPtr, OdRxObject.getCPtr(pBlock));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isAnonymous(OdRxObject pBlock)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockPE_isAnonymous(swigCPtr, OdRxObject.getCPtr(pBlock));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getName(OdRxObject pBlock)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockPE_getName(swigCPtr, OdRxObject.getCPtr(pBlock));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockPE_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbBaseBlockPE()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbBaseBlockPE(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbBaseBlockPE) != GetType();
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
		if (SwigDerivedClassHasMethod("isBlockReferenceAdded", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodisBlockReferenceAdded;
		}
		if (SwigDerivedClassHasMethod("isFromExternalReference", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisFromExternalReference;
		}
		if (SwigDerivedClassHasMethod("xrefDatabase", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodxrefDatabase;
		}
		if (SwigDerivedClassHasMethod("getLayoutId", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetLayoutId;
		}
		if (SwigDerivedClassHasMethod("isAnonymous", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodisAnonymous;
		}
		if (SwigDerivedClassHasMethod("getName", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetName;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbBaseBlockPE));
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

	private bool SwigDirectorMethodisBlockReferenceAdded(IntPtr pBlock)
	{
		return isBlockReferenceAdded(Helpers.GetRXObject<OdRxObject>(pBlock, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisFromExternalReference(IntPtr pBlock)
	{
		return isFromExternalReference(Helpers.GetRXObject<OdRxObject>(pBlock, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodxrefDatabase(IntPtr pBlock)
	{
		return OdRxObject.getCPtr(xrefDatabase(Helpers.GetRXObject<OdRxObject>(pBlock, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodgetLayoutId(IntPtr pBlock)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(getLayoutId(Helpers.GetRXObject<OdRxObject>(pBlock, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private bool SwigDirectorMethodisAnonymous(IntPtr pBlock)
	{
		return isAnonymous(Helpers.GetRXObject<OdRxObject>(pBlock, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetName(IntPtr pBlock)
	{
		return getName(Helpers.GetRXObject<OdRxObject>(pBlock, bOwn: false, bTryAddToTransaction: false));
	}
}
