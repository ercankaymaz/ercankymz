using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcPolyWire : OdPrcRepresentationItem
{
	public delegate IntPtr SwigDelegateOdPrcPolyWire_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcPolyWire_1();

	public delegate void SwigDelegateOdPrcPolyWire_2(IntPtr pSource);

	public delegate int SwigDelegateOdPrcPolyWire_3();

	public delegate bool SwigDelegateOdPrcPolyWire_4();

	public delegate IntPtr SwigDelegateOdPrcPolyWire_5();

	public delegate void SwigDelegateOdPrcPolyWire_6(IntPtr pGsNode);

	public delegate IntPtr SwigDelegateOdPrcPolyWire_7();

	public delegate uint SwigDelegateOdPrcPolyWire_8(IntPtr traits);

	public delegate bool SwigDelegateOdPrcPolyWire_9(IntPtr pWd);

	public delegate void SwigDelegateOdPrcPolyWire_10(IntPtr vd);

	public delegate uint SwigDelegateOdPrcPolyWire_11(IntPtr vd);

	public delegate uint SwigDelegateOdPrcPolyWire_12();

	public delegate void SwigDelegateOdPrcPolyWire_13(IntPtr pStream);

	public delegate void SwigDelegateOdPrcPolyWire_14(IntPtr pStream);

	public delegate uint SwigDelegateOdPrcPolyWire_15();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcPolyWire_0 swigDelegate0;

	private SwigDelegateOdPrcPolyWire_1 swigDelegate1;

	private SwigDelegateOdPrcPolyWire_2 swigDelegate2;

	private SwigDelegateOdPrcPolyWire_3 swigDelegate3;

	private SwigDelegateOdPrcPolyWire_4 swigDelegate4;

	private SwigDelegateOdPrcPolyWire_5 swigDelegate5;

	private SwigDelegateOdPrcPolyWire_6 swigDelegate6;

	private SwigDelegateOdPrcPolyWire_7 swigDelegate7;

	private SwigDelegateOdPrcPolyWire_8 swigDelegate8;

	private SwigDelegateOdPrcPolyWire_9 swigDelegate9;

	private SwigDelegateOdPrcPolyWire_10 swigDelegate10;

	private SwigDelegateOdPrcPolyWire_11 swigDelegate11;

	private SwigDelegateOdPrcPolyWire_12 swigDelegate12;

	private SwigDelegateOdPrcPolyWire_13 swigDelegate13;

	private SwigDelegateOdPrcPolyWire_14 swigDelegate14;

	private SwigDelegateOdPrcPolyWire_15 swigDelegate15;

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
	public OdPrcPolyWire(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcPolyWire obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcPolyWire(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPrcPolyWire()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcPolyWire(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcPolyWire) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override uint prcType()
	{
		uint result = (SwigDerivedClassHasMethod("prcType", swigMethodTypes15) ? OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_prcTypeSwigExplicitOdPrcPolyWire(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_prcType(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdPrcPolyWire cast(OdRxObject pObj)
	{
		OdPrcPolyWire rXObject = Helpers.GetRXObject<OdPrcPolyWire>(OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_isASwigExplicitOdPrcPolyWire(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_queryXSwigExplicitOdPrcPolyWire(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPrcPolyWire createObject()
	{
		OdPrcPolyWire rXObject = Helpers.GetRXObject<OdPrcPolyWire>(OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void prcOut(OdPrcCompressedFiler pStream)
	{
		if (SwigDerivedClassHasMethod("prcOut", swigMethodTypes13))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_prcOutSwigExplicitOdPrcPolyWire(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void prcIn(OdPrcCompressedFiler pStream)
	{
		if (SwigDerivedClassHasMethod("prcIn", swigMethodTypes14))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_prcInSwigExplicitOdPrcPolyWire(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected override uint subSetAttributes(OdGiDrawableTraits traits)
	{
		uint result = (SwigDerivedClassHasMethod("subSetAttributes", swigMethodTypes8) ? OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_subSetAttributesSwigExplicitOdPrcPolyWire(swigCPtr, OdGiDrawableTraits.getCPtr(traits)) : OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_subSetAttributes(swigCPtr, OdGiDrawableTraits.getCPtr(traits)));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected override bool subWorldDraw(OdGiWorldDraw pWd)
	{
		bool result = (SwigDerivedClassHasMethod("subWorldDraw", swigMethodTypes9) ? OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_subWorldDrawSwigExplicitOdPrcPolyWire(swigCPtr, OdGiWorldDraw.getCPtr(pWd)) : OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_subWorldDraw(swigCPtr, OdGiWorldDraw.getCPtr(pWd)));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("prcType", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodprcType;
		}
		OdPrcModule_GlobalsPINVOKE.OdPrcPolyWire_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcPolyWire));
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

	private bool SwigDirectorMethodsubWorldDraw(IntPtr pWd)
	{
		return subWorldDraw(Helpers.GetRXObject<OdGiWorldDraw>(pWd, bOwn: false, bTryAddToTransaction: false));
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

	private uint SwigDirectorMethodprcType()
	{
		return prcType();
	}
}
