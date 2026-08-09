using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcBody : OdGiDrawable
{
	public delegate IntPtr SwigDelegateOdPrcBody_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcBody_1();

	public delegate void SwigDelegateOdPrcBody_2(IntPtr pSource);

	public delegate int SwigDelegateOdPrcBody_3();

	public delegate bool SwigDelegateOdPrcBody_4();

	public delegate IntPtr SwigDelegateOdPrcBody_5();

	public delegate void SwigDelegateOdPrcBody_6(IntPtr pGsNode);

	public delegate IntPtr SwigDelegateOdPrcBody_7();

	public delegate uint SwigDelegateOdPrcBody_8(IntPtr traits);

	public delegate bool SwigDelegateOdPrcBody_9(IntPtr wd);

	public delegate void SwigDelegateOdPrcBody_10(IntPtr vd);

	public delegate uint SwigDelegateOdPrcBody_11(IntPtr vd);

	public delegate uint SwigDelegateOdPrcBody_12();

	public delegate void SwigDelegateOdPrcBody_13(IntPtr pStream);

	public delegate void SwigDelegateOdPrcBody_14(IntPtr pStream);

	public delegate uint SwigDelegateOdPrcBody_15();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcBody_0 swigDelegate0;

	private SwigDelegateOdPrcBody_1 swigDelegate1;

	private SwigDelegateOdPrcBody_2 swigDelegate2;

	private SwigDelegateOdPrcBody_3 swigDelegate3;

	private SwigDelegateOdPrcBody_4 swigDelegate4;

	private SwigDelegateOdPrcBody_5 swigDelegate5;

	private SwigDelegateOdPrcBody_6 swigDelegate6;

	private SwigDelegateOdPrcBody_7 swigDelegate7;

	private SwigDelegateOdPrcBody_8 swigDelegate8;

	private SwigDelegateOdPrcBody_9 swigDelegate9;

	private SwigDelegateOdPrcBody_10 swigDelegate10;

	private SwigDelegateOdPrcBody_11 swigDelegate11;

	private SwigDelegateOdPrcBody_12 swigDelegate12;

	private SwigDelegateOdPrcBody_13 swigDelegate13;

	private SwigDelegateOdPrcBody_14 swigDelegate14;

	private SwigDelegateOdPrcBody_15 swigDelegate15;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGsCache) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdGiDrawableTraits) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGiWorldDraw) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdGiViewportDraw) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdGiViewportDraw) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdPrcCompressedFiler) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdPrcCompressedFiler) };

	private static Type[] swigMethodTypes15 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcBody(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcBody_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcBody obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcBody(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPrcBody()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcBody(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcBody) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPrcBody cast(OdRxObject pObj)
	{
		OdPrcBody rXObject = Helpers.GetRXObject<OdPrcBody>(OdPrcModule_GlobalsPINVOKE.OdPrcBody_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcBody_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcBody_isASwigExplicitOdPrcBody(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcBody_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcBody_queryXSwigExplicitOdPrcBody(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcBody_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPrcBody createObject()
	{
		OdPrcBody rXObject = Helpers.GetRXObject<OdPrcBody>(OdPrcModule_GlobalsPINVOKE.OdPrcBody_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void prcOut(OdPrcCompressedFiler pStream)
	{
		if (SwigDerivedClassHasMethod("prcOut", swigMethodTypes13))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcBody_prcOutSwigExplicitOdPrcBody(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcBody_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void prcIn(OdPrcCompressedFiler pStream)
	{
		if (SwigDerivedClassHasMethod("prcIn", swigMethodTypes14))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcBody_prcInSwigExplicitOdPrcBody(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcBody_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdPrcObjectId read(OdPrcCompressedFiler pStream)
	{
		OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcBody_read(OdPrcCompressedFiler.getCPtr(pStream)), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void readArray(OdPrcObjectIdArray array, OdPrcCompressedFiler pStream)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcBody_readArray(OdPrcObjectIdArray.getCPtr(array).Handle, OdPrcCompressedFiler.getCPtr(pStream));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setObjectId(OdDbStub stub)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcBody_setObjectId(swigCPtr, OdDbStub.getCPtr(stub));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcObjectId objectId()
	{
		OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcBody_objectId(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getSerialType()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcBody_getSerialType(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isPersistent()
	{
		bool result = (SwigDerivedClassHasMethod("isPersistent", swigMethodTypes4) ? OdPrcModule_GlobalsPINVOKE.OdPrcBody_isPersistentSwigExplicitOdPrcBody(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcBody_isPersistent(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbStub id()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("id", swigMethodTypes5) ? OdPrcModule_GlobalsPINVOKE.OdPrcBody_idSwigExplicitOdPrcBody(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcBody_id(swigCPtr));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setGsNode(OdGsCache pGsNode)
	{
		if (SwigDerivedClassHasMethod("setGsNode", swigMethodTypes6))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcBody_setGsNodeSwigExplicitOdPrcBody(swigCPtr, OdGsCache.getCPtr(pGsNode));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcBody_setGsNode(swigCPtr, OdGsCache.getCPtr(pGsNode));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGsCache gsNode()
	{
		OdGsCache rXObject = Helpers.GetRXObject<OdGsCache>(SwigDerivedClassHasMethod("gsNode", swigMethodTypes7) ? OdPrcModule_GlobalsPINVOKE.OdPrcBody_gsNodeSwigExplicitOdPrcBody(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcBody_gsNode(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected override uint subSetAttributes(OdGiDrawableTraits traits)
	{
		uint result = (SwigDerivedClassHasMethod("subSetAttributes", swigMethodTypes8) ? OdPrcModule_GlobalsPINVOKE.OdPrcBody_subSetAttributesSwigExplicitOdPrcBody(swigCPtr, OdGiDrawableTraits.getCPtr(traits)) : OdPrcModule_GlobalsPINVOKE.OdPrcBody_subSetAttributes(swigCPtr, OdGiDrawableTraits.getCPtr(traits)));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected override bool subWorldDraw(OdGiWorldDraw wd)
	{
		bool result = (SwigDerivedClassHasMethod("subWorldDraw", swigMethodTypes9) ? OdPrcModule_GlobalsPINVOKE.OdPrcBody_subWorldDrawSwigExplicitOdPrcBody(swigCPtr, OdGiWorldDraw.getCPtr(wd)) : OdPrcModule_GlobalsPINVOKE.OdPrcBody_subWorldDraw(swigCPtr, OdGiWorldDraw.getCPtr(wd)));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected override void subViewportDraw(OdGiViewportDraw vd)
	{
		if (SwigDerivedClassHasMethod("subViewportDraw", swigMethodTypes10))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcBody_subViewportDrawSwigExplicitOdPrcBody(swigCPtr, OdGiViewportDraw.getCPtr(vd));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcBody_subViewportDraw(swigCPtr, OdGiViewportDraw.getCPtr(vd));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcBody_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("drawableType", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddrawableType;
		}
		if (SwigDerivedClassHasMethod("isPersistent", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisPersistent;
		}
		if (SwigDerivedClassHasMethod("id", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodid;
		}
		if (SwigDerivedClassHasMethod("setGsNode", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetGsNode;
		}
		if (SwigDerivedClassHasMethod("gsNode", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgsNode;
		}
		if (SwigDerivedClassHasMethod("subSetAttributes", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsubSetAttributes;
		}
		if (SwigDerivedClassHasMethod("subWorldDraw", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsubWorldDraw;
		}
		if (SwigDerivedClassHasMethod("subViewportDraw", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsubViewportDraw;
		}
		if (SwigDerivedClassHasMethod("subViewportDrawLogicalFlags", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsubViewportDrawLogicalFlags;
		}
		if (SwigDerivedClassHasMethod("subRegenSupportFlags", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsubRegenSupportFlags;
		}
		if (SwigDerivedClassHasMethod("prcOut", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodprcOut;
		}
		if (SwigDerivedClassHasMethod("prcIn", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodprcIn;
		}
		if (SwigDerivedClassHasMethod("getSerialType", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetSerialType;
		}
		OdPrcModule_GlobalsPINVOKE.OdPrcBody_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcBody));
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethoddrawableType()
	{
		return (int)drawableType();
	}

	private bool SwigDirectorMethodisPersistent()
	{
		return isPersistent();
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
				OdPrcModule_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				OdPrcModule_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				OdPrcModule_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetGsNode(IntPtr pGsNode)
	{
		try
		{
			setGsNode(Helpers.GetRXObject<OdGsCache>(pGsNode, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgsNode()
	{
		return OdGsCache.getCPtr(gsNode()).Handle;
	}

	private uint SwigDirectorMethodsubSetAttributes(IntPtr traits)
	{
		return subSetAttributes(Helpers.GetRXObject<OdGiDrawableTraits>(traits, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsubWorldDraw(IntPtr wd)
	{
		return subWorldDraw(Helpers.GetRXObject<OdGiWorldDraw>(wd, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsubViewportDraw(IntPtr vd)
	{
		try
		{
			subViewportDraw(Helpers.GetRXObject<OdGiViewportDraw>(vd, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private uint SwigDirectorMethodsubViewportDrawLogicalFlags(IntPtr vd)
	{
		return subViewportDrawLogicalFlags(Helpers.GetRXObject<OdGiViewportDraw>(vd, bOwn: false, bTryAddToTransaction: false));
	}

	private uint SwigDirectorMethodsubRegenSupportFlags()
	{
		return subRegenSupportFlags();
	}

	private void SwigDirectorMethodprcOut(IntPtr pStream)
	{
		try
		{
			prcOut(Helpers.GetRXObject<OdPrcCompressedFiler>(pStream, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodprcIn(IntPtr pStream)
	{
		try
		{
			prcIn(Helpers.GetRXObject<OdPrcCompressedFiler>(pStream, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private uint SwigDirectorMethodgetSerialType()
	{
		return getSerialType();
	}
}
