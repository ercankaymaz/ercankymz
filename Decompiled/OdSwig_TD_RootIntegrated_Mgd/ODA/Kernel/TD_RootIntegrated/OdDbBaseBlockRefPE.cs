using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbBaseBlockRefPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbBaseBlockRefPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbBaseBlockRefPE_1();

	public delegate void SwigDelegateOdDbBaseBlockRefPE_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdDbBaseBlockRefPE_3(IntPtr pBlockRef);

	public delegate IntPtr SwigDelegateOdDbBaseBlockRefPE_4(IntPtr pBlockRef);

	public delegate IntPtr SwigDelegateOdDbBaseBlockRefPE_5(IntPtr pBlockRef, bool bSkipErased);

	public delegate IntPtr SwigDelegateOdDbBaseBlockRefPE_6(IntPtr pBlockRef);

	public delegate bool SwigDelegateOdDbBaseBlockRefPE_7(IntPtr pAttrib);

	public delegate bool SwigDelegateOdDbBaseBlockRefPE_8(IntPtr pBlockRef);

	public delegate bool SwigDelegateOdDbBaseBlockRefPE_9(IntPtr pBlockRef);

	public delegate bool SwigDelegateOdDbBaseBlockRefPE_10(IntPtr pBlockRef);

	public delegate bool SwigDelegateOdDbBaseBlockRefPE_11(IntPtr pEntity);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbBaseBlockRefPE_0 swigDelegate0;

	private SwigDelegateOdDbBaseBlockRefPE_1 swigDelegate1;

	private SwigDelegateOdDbBaseBlockRefPE_2 swigDelegate2;

	private SwigDelegateOdDbBaseBlockRefPE_3 swigDelegate3;

	private SwigDelegateOdDbBaseBlockRefPE_4 swigDelegate4;

	private SwigDelegateOdDbBaseBlockRefPE_5 swigDelegate5;

	private SwigDelegateOdDbBaseBlockRefPE_6 swigDelegate6;

	private SwigDelegateOdDbBaseBlockRefPE_7 swigDelegate7;

	private SwigDelegateOdDbBaseBlockRefPE_8 swigDelegate8;

	private SwigDelegateOdDbBaseBlockRefPE_9 swigDelegate9;

	private SwigDelegateOdDbBaseBlockRefPE_10 swigDelegate10;

	private SwigDelegateOdDbBaseBlockRefPE_11 swigDelegate11;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdRxObject),
		typeof(bool)
	};

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbBaseBlockRefPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbBaseBlockRefPE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbBaseBlockRefPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbBaseBlockRefPE cast(OdRxObject pObj)
	{
		OdDbBaseBlockRefPE rXObject = Helpers.GetRXObject<OdDbBaseBlockRefPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_isASwigExplicitOdDbBaseBlockRefPE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_queryXSwigExplicitOdDbBaseBlockRefPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbBaseBlockRefPE createObject()
	{
		OdDbBaseBlockRefPE rXObject = Helpers.GetRXObject<OdDbBaseBlockRefPE>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbStub blockId(OdRxObject pBlockRef)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_blockId(swigCPtr, OdRxObject.getCPtr(pBlockRef));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d blockTransform(OdRxObject pBlockRef)
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_blockTransform(swigCPtr, OdRxObject.getCPtr(pBlockRef)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxIterator newAttribIterator(OdRxObject pBlockRef, bool bSkipErased)
	{
		OdRxIterator rXObject = Helpers.GetRXObject<OdRxIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_newAttribIterator__SWIG_0(swigCPtr, OdRxObject.getCPtr(pBlockRef), bSkipErased), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxIterator newAttribIterator(OdRxObject pBlockRef)
	{
		OdRxIterator rXObject = Helpers.GetRXObject<OdRxIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_newAttribIterator__SWIG_1(swigCPtr, OdRxObject.getCPtr(pBlockRef)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool isAttribute(OdRxObject pAttrib)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_isAttribute(swigCPtr, OdRxObject.getCPtr(pAttrib));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isGeneric(OdRxObject pBlockRef)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_isGeneric(swigCPtr, OdRxObject.getCPtr(pBlockRef));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isMInsert(OdRxObject pBlockRef)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_isMInsert(swigCPtr, OdRxObject.getCPtr(pBlockRef));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isBasic(OdRxObject pBlockRef)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_isBasic(swigCPtr, OdRxObject.getCPtr(pBlockRef));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isSelfReferential(OdRxObject pEntity)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_isSelfReferential(swigCPtr, OdRxObject.getCPtr(pEntity));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbBaseBlockRefPE()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbBaseBlockRefPE(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbBaseBlockRefPE) != GetType();
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
		if (SwigDerivedClassHasMethod("blockId", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodblockId;
		}
		if (SwigDerivedClassHasMethod("blockTransform", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodblockTransform;
		}
		if (SwigDerivedClassHasMethod("newAttribIterator", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodnewAttribIterator__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("newAttribIterator", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodnewAttribIterator__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isAttribute", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodisAttribute;
		}
		if (SwigDerivedClassHasMethod("isGeneric", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodisGeneric;
		}
		if (SwigDerivedClassHasMethod("isMInsert", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodisMInsert;
		}
		if (SwigDerivedClassHasMethod("isBasic", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodisBasic;
		}
		if (SwigDerivedClassHasMethod("isSelfReferential", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodisSelfReferential;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbBaseBlockRefPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbBaseBlockRefPE));
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

	private IntPtr SwigDirectorMethodblockId(IntPtr pBlockRef)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(blockId(Helpers.GetRXObject<OdRxObject>(pBlockRef, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodblockTransform(IntPtr pBlockRef)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(blockTransform(Helpers.GetRXObject<OdRxObject>(pBlockRef, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodnewAttribIterator__SWIG_0(IntPtr pBlockRef, bool bSkipErased)
	{
		return OdRxIterator.getCPtr(newAttribIterator(Helpers.GetRXObject<OdRxObject>(pBlockRef, bOwn: false, bTryAddToTransaction: false), bSkipErased)).Handle;
	}

	private IntPtr SwigDirectorMethodnewAttribIterator__SWIG_1(IntPtr pBlockRef)
	{
		return OdRxIterator.getCPtr(newAttribIterator(Helpers.GetRXObject<OdRxObject>(pBlockRef, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private bool SwigDirectorMethodisAttribute(IntPtr pAttrib)
	{
		return isAttribute(Helpers.GetRXObject<OdRxObject>(pAttrib, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisGeneric(IntPtr pBlockRef)
	{
		return isGeneric(Helpers.GetRXObject<OdRxObject>(pBlockRef, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisMInsert(IntPtr pBlockRef)
	{
		return isMInsert(Helpers.GetRXObject<OdRxObject>(pBlockRef, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisBasic(IntPtr pBlockRef)
	{
		return isBasic(Helpers.GetRXObject<OdRxObject>(pBlockRef, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodisSelfReferential(IntPtr pEntity)
	{
		return isSelfReferential(Helpers.GetRXObject<OdRxObject>(pEntity, bOwn: false, bTryAddToTransaction: false));
	}
}
