using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiDrawableImpl_OdGiDrawable : OdGiDrawable
{
	public delegate IntPtr SwigDelegateOdGiDrawableImpl_OdGiDrawable_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiDrawableImpl_OdGiDrawable_1();

	public delegate void SwigDelegateOdGiDrawableImpl_OdGiDrawable_2(IntPtr pSource);

	public delegate int SwigDelegateOdGiDrawableImpl_OdGiDrawable_3();

	public delegate bool SwigDelegateOdGiDrawableImpl_OdGiDrawable_4();

	public delegate IntPtr SwigDelegateOdGiDrawableImpl_OdGiDrawable_5();

	public delegate void SwigDelegateOdGiDrawableImpl_OdGiDrawable_6(IntPtr pGsNode);

	public delegate IntPtr SwigDelegateOdGiDrawableImpl_OdGiDrawable_7();

	public delegate uint SwigDelegateOdGiDrawableImpl_OdGiDrawable_8(IntPtr traits);

	public delegate bool SwigDelegateOdGiDrawableImpl_OdGiDrawable_9(IntPtr wd);

	public delegate void SwigDelegateOdGiDrawableImpl_OdGiDrawable_10(IntPtr arg0);

	public delegate uint SwigDelegateOdGiDrawableImpl_OdGiDrawable_11(IntPtr vd);

	public delegate uint SwigDelegateOdGiDrawableImpl_OdGiDrawable_12();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiDrawableImpl_OdGiDrawable_0 swigDelegate0;

	private SwigDelegateOdGiDrawableImpl_OdGiDrawable_1 swigDelegate1;

	private SwigDelegateOdGiDrawableImpl_OdGiDrawable_2 swigDelegate2;

	private SwigDelegateOdGiDrawableImpl_OdGiDrawable_3 swigDelegate3;

	private SwigDelegateOdGiDrawableImpl_OdGiDrawable_4 swigDelegate4;

	private SwigDelegateOdGiDrawableImpl_OdGiDrawable_5 swigDelegate5;

	private SwigDelegateOdGiDrawableImpl_OdGiDrawable_6 swigDelegate6;

	private SwigDelegateOdGiDrawableImpl_OdGiDrawable_7 swigDelegate7;

	private SwigDelegateOdGiDrawableImpl_OdGiDrawable_8 swigDelegate8;

	private SwigDelegateOdGiDrawableImpl_OdGiDrawable_9 swigDelegate9;

	private SwigDelegateOdGiDrawableImpl_OdGiDrawable_10 swigDelegate10;

	private SwigDelegateOdGiDrawableImpl_OdGiDrawable_11 swigDelegate11;

	private SwigDelegateOdGiDrawableImpl_OdGiDrawable_12 swigDelegate12;

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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiDrawableImpl_OdGiDrawable(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableImpl_OdGiDrawable_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiDrawableImpl_OdGiDrawable obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDrawableImpl_OdGiDrawable(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiDrawableImpl_OdGiDrawable()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDrawableImpl_OdGiDrawable(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiDrawableImpl_OdGiDrawable) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override void setGsNode(OdGsCache pGsNode)
	{
		if (SwigDerivedClassHasMethod("setGsNode", swigMethodTypes6))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableImpl_OdGiDrawable_setGsNodeSwigExplicitOdGiDrawableImpl_OdGiDrawable(swigCPtr, OdGsCache.getCPtr(pGsNode));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableImpl_OdGiDrawable_setGsNode(swigCPtr, OdGsCache.getCPtr(pGsNode));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override OdGsCache gsNode()
	{
		OdGsCache rXObject = Helpers.GetRXObject<OdGsCache>(SwigDerivedClassHasMethod("gsNode", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableImpl_OdGiDrawable_gsNodeSwigExplicitOdGiDrawableImpl_OdGiDrawable(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableImpl_OdGiDrawable_gsNode(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual void subViewportDraw(OdGiViewportDraw arg0)
	{
		if (SwigDerivedClassHasMethod("subViewportDraw", swigMethodTypes10))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableImpl_OdGiDrawable_subViewportDrawSwigExplicitOdGiDrawableImpl_OdGiDrawable(swigCPtr, OdGiViewportDraw.getCPtr(arg0));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableImpl_OdGiDrawable_subViewportDraw(swigCPtr, OdGiViewportDraw.getCPtr(arg0));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool isPersistent()
	{
		bool result = (SwigDerivedClassHasMethod("isPersistent", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableImpl_OdGiDrawable_isPersistentSwigExplicitOdGiDrawableImpl_OdGiDrawable(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableImpl_OdGiDrawable_isPersistent(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdDbStub id()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("id", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableImpl_OdGiDrawable_idSwigExplicitOdGiDrawableImpl_OdGiDrawable(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableImpl_OdGiDrawable_id(swigCPtr));
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDrawableImpl_OdGiDrawable_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiDrawableImpl_OdGiDrawable));
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

	private void SwigDirectorMethodsetGsNode(IntPtr pGsNode)
	{
		try
		{
			setGsNode(Helpers.GetRXObject<OdGsCache>(pGsNode, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodsubViewportDraw(IntPtr arg0)
	{
		try
		{
			subViewportDraw(Helpers.GetRXObject<OdGiViewportDraw>(arg0, bOwn: false, bTryAddToTransaction: false));
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

	private uint SwigDirectorMethodsubViewportDrawLogicalFlags(IntPtr vd)
	{
		return subViewportDrawLogicalFlags(Helpers.GetRXObject<OdGiViewportDraw>(vd, bOwn: false, bTryAddToTransaction: false));
	}

	private uint SwigDirectorMethodsubRegenSupportFlags()
	{
		return subRegenSupportFlags();
	}
}
