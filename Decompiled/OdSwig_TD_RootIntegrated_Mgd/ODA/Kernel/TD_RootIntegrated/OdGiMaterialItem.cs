using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMaterialItem : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiMaterialItem_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiMaterialItem_1();

	public delegate void SwigDelegateOdGiMaterialItem_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiMaterialItem_3();

	public delegate IntPtr SwigDelegateOdGiMaterialItem_4();

	public delegate IntPtr SwigDelegateOdGiMaterialItem_5();

	public delegate void SwigDelegateOdGiMaterialItem_6();

	public delegate bool SwigDelegateOdGiMaterialItem_7();

	public delegate uint SwigDelegateOdGiMaterialItem_8(string pOrder, bool bCheckAny);

	public delegate uint SwigDelegateOdGiMaterialItem_9(string pOrder);

	public delegate uint SwigDelegateOdGiMaterialItem_10();

	public delegate IntPtr SwigDelegateOdGiMaterialItem_11();

	public delegate void SwigDelegateOdGiMaterialItem_12(IntPtr data);

	public delegate IntPtr SwigDelegateOdGiMaterialItem_13();

	public delegate void SwigDelegateOdGiMaterialItem_14(IntPtr matId);

	public delegate void SwigDelegateOdGiMaterialItem_15();

	public delegate bool SwigDelegateOdGiMaterialItem_16(IntPtr matId);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiMaterialItem_0 swigDelegate0;

	private SwigDelegateOdGiMaterialItem_1 swigDelegate1;

	private SwigDelegateOdGiMaterialItem_2 swigDelegate2;

	private SwigDelegateOdGiMaterialItem_3 swigDelegate3;

	private SwigDelegateOdGiMaterialItem_4 swigDelegate4;

	private SwigDelegateOdGiMaterialItem_5 swigDelegate5;

	private SwigDelegateOdGiMaterialItem_6 swigDelegate6;

	private SwigDelegateOdGiMaterialItem_7 swigDelegate7;

	private SwigDelegateOdGiMaterialItem_8 swigDelegate8;

	private SwigDelegateOdGiMaterialItem_9 swigDelegate9;

	private SwigDelegateOdGiMaterialItem_10 swigDelegate10;

	private SwigDelegateOdGiMaterialItem_11 swigDelegate11;

	private SwigDelegateOdGiMaterialItem_12 swigDelegate12;

	private SwigDelegateOdGiMaterialItem_13 swigDelegate13;

	private SwigDelegateOdGiMaterialItem_14 swigDelegate14;

	private SwigDelegateOdGiMaterialItem_15 swigDelegate15;

	private SwigDelegateOdGiMaterialItem_16 swigDelegate16;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdDbStub) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMaterialItem(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMaterialItem obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMaterialItem(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiMaterialItem cast(OdRxObject pObj)
	{
		OdGiMaterialItem rXObject = Helpers.GetRXObject<OdGiMaterialItem>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_isASwigExplicitOdGiMaterialItem(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_queryXSwigExplicitOdGiMaterialItem(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiMaterialItem createObject()
	{
		OdGiMaterialItem rXObject = Helpers.GetRXObject<OdGiMaterialItem>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureEntry diffuseTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_diffuseTexture__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureEntry createDiffuseTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_createDiffuseTexture(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void removeDiffuseTexture()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_removeDiffuseTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool haveDiffuseTexture()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_haveDiffuseTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint checkTexturesEnabled(string pOrder, bool bCheckAny)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_checkTexturesEnabled__SWIG_0(swigCPtr, pOrder, bCheckAny);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint checkTexturesEnabled(string pOrder)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_checkTexturesEnabled__SWIG_1(swigCPtr, pOrder);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint checkTexturesEnabled()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_checkTexturesEnabled__SWIG_2(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxObject cachedData()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_cachedData(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setCachedData(OdRxObject data)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_setCachedData(swigCPtr, OdRxObject.getCPtr(data));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbStub materialId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_materialId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setMaterialId(OdDbStub matId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_setMaterialId__SWIG_0(swigCPtr, OdDbStub.getCPtr(matId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMaterialId()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_setMaterialId__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isMaterialIdValid(OdDbStub matId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_isMaterialIdValid(swigCPtr, OdDbStub.getCPtr(matId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMaterialItem()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMaterialItem(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiMaterialItem) != GetType();
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
		if (SwigDerivedClassHasMethod("diffuseTexture", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddiffuseTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("diffuseTexture", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddiffuseTexture__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createDiffuseTexture", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcreateDiffuseTexture;
		}
		if (SwigDerivedClassHasMethod("removeDiffuseTexture", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodremoveDiffuseTexture;
		}
		if (SwigDerivedClassHasMethod("haveDiffuseTexture", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodhaveDiffuseTexture;
		}
		if (SwigDerivedClassHasMethod("checkTexturesEnabled", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodcheckTexturesEnabled__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("checkTexturesEnabled", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodcheckTexturesEnabled__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("checkTexturesEnabled", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcheckTexturesEnabled__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("cachedData", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodcachedData;
		}
		if (SwigDerivedClassHasMethod("setCachedData", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetCachedData;
		}
		if (SwigDerivedClassHasMethod("materialId", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodmaterialId;
		}
		if (SwigDerivedClassHasMethod("setMaterialId", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetMaterialId__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setMaterialId", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetMaterialId__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isMaterialIdValid", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodisMaterialIdValid;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialItem_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiMaterialItem));
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

	private IntPtr SwigDirectorMethoddiffuseTexture__SWIG_0()
	{
		return OdGiMaterialTextureEntry.getCPtr(diffuseTexture()).Handle;
	}

	private IntPtr SwigDirectorMethoddiffuseTexture__SWIG_1()
	{
		return OdGiMaterialTextureEntry.getCPtr(diffuseTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateDiffuseTexture()
	{
		return OdGiMaterialTextureEntry.getCPtr(createDiffuseTexture()).Handle;
	}

	private void SwigDirectorMethodremoveDiffuseTexture()
	{
		try
		{
			removeDiffuseTexture();
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

	private bool SwigDirectorMethodhaveDiffuseTexture()
	{
		return haveDiffuseTexture();
	}

	private uint SwigDirectorMethodcheckTexturesEnabled__SWIG_0(string pOrder, bool bCheckAny)
	{
		return checkTexturesEnabled(pOrder, bCheckAny);
	}

	private uint SwigDirectorMethodcheckTexturesEnabled__SWIG_1(string pOrder)
	{
		return checkTexturesEnabled(pOrder);
	}

	private uint SwigDirectorMethodcheckTexturesEnabled__SWIG_2()
	{
		return checkTexturesEnabled();
	}

	private IntPtr SwigDirectorMethodcachedData()
	{
		return OdRxObject.getCPtr(cachedData()).Handle;
	}

	private void SwigDirectorMethodsetCachedData(IntPtr data)
	{
		try
		{
			setCachedData(Helpers.GetRXObject<OdRxObject>(data, bOwn: true, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodmaterialId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(materialId()).Handle;
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

	private void SwigDirectorMethodsetMaterialId__SWIG_0(IntPtr matId)
	{
		try
		{
			setMaterialId((matId == IntPtr.Zero) ? null : new OdDbStub(matId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetMaterialId__SWIG_1()
	{
		try
		{
			setMaterialId();
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

	private bool SwigDirectorMethodisMaterialIdValid(IntPtr matId)
	{
		return isMaterialIdValid((matId == IntPtr.Zero) ? null : new OdDbStub(matId, cMemoryOwn: false));
	}
}
