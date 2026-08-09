using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiDgLinetypeTraits : OdGiDrawableTraits
{
	public delegate IntPtr SwigDelegateOdGiDgLinetypeTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiDgLinetypeTraits_1();

	public delegate void SwigDelegateOdGiDgLinetypeTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiDgLinetypeTraits_3(IntPtr items);

	public delegate void SwigDelegateOdGiDgLinetypeTraits_4(IntPtr items);

	public delegate double SwigDelegateOdGiDgLinetypeTraits_5();

	public delegate void SwigDelegateOdGiDgLinetypeTraits_6(double dPatLen);

	public delegate double SwigDelegateOdGiDgLinetypeTraits_7();

	public delegate void SwigDelegateOdGiDgLinetypeTraits_8(double dScale);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiDgLinetypeTraits_0 swigDelegate0;

	private SwigDelegateOdGiDgLinetypeTraits_1 swigDelegate1;

	private SwigDelegateOdGiDgLinetypeTraits_2 swigDelegate2;

	private SwigDelegateOdGiDgLinetypeTraits_3 swigDelegate3;

	private SwigDelegateOdGiDgLinetypeTraits_4 swigDelegate4;

	private SwigDelegateOdGiDgLinetypeTraits_5 swigDelegate5;

	private SwigDelegateOdGiDgLinetypeTraits_6 swigDelegate6;

	private SwigDelegateOdGiDgLinetypeTraits_7 swigDelegate7;

	private SwigDelegateOdGiDgLinetypeTraits_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGiDgLinetypeItemArray) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGiDgLinetypeItemArray) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(double) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiDgLinetypeTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiDgLinetypeTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDgLinetypeTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiDgLinetypeTraits cast(OdRxObject pObj)
	{
		OdGiDgLinetypeTraits rXObject = Helpers.GetRXObject<OdGiDgLinetypeTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeTraits_isASwigExplicitOdGiDgLinetypeTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeTraits_queryXSwigExplicitOdGiDgLinetypeTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiDgLinetypeTraits createObject()
	{
		OdGiDgLinetypeTraits rXObject = Helpers.GetRXObject<OdGiDgLinetypeTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void Items(OdGiDgLinetypeItemArray items)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeTraits_Items(swigCPtr, OdGiDgLinetypeItemArray.getCPtr(items));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setItems(OdGiDgLinetypeItemArray items)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeTraits_setItems(swigCPtr, OdGiDgLinetypeItemArray.getCPtr(items));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double patternLength()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeTraits_patternLength(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPatternLength(double dPatLen)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeTraits_setPatternLength(swigCPtr, dPatLen);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double scale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeTraits_scale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setScale(double dScale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeTraits_setScale(swigCPtr, dScale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiDgLinetypeTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDgLinetypeTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiDgLinetypeTraits) != GetType();
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
		if (SwigDerivedClassHasMethod("Items", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodItems;
		}
		if (SwigDerivedClassHasMethod("setItems", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetItems;
		}
		if (SwigDerivedClassHasMethod("patternLength", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodpatternLength;
		}
		if (SwigDerivedClassHasMethod("setPatternLength", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetPatternLength;
		}
		if (SwigDerivedClassHasMethod("scale", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodscale;
		}
		if (SwigDerivedClassHasMethod("setScale", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetScale;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDgLinetypeTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiDgLinetypeTraits));
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

	private void SwigDirectorMethodItems(IntPtr items)
	{
		try
		{
			Items(new OdGiDgLinetypeItemArray(items, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetItems(IntPtr items)
	{
		try
		{
			setItems(new OdGiDgLinetypeItemArray(items, cMemoryOwn: false));
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

	private double SwigDirectorMethodpatternLength()
	{
		return patternLength();
	}

	private void SwigDirectorMethodsetPatternLength(double dPatLen)
	{
		try
		{
			setPatternLength(dPatLen);
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

	private double SwigDirectorMethodscale()
	{
		return scale();
	}

	private void SwigDirectorMethodsetScale(double dScale)
	{
		try
		{
			setScale(dScale);
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
}
