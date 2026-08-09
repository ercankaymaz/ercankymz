using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiGradientBackgroundTraits : OdGiDrawableTraits
{
	public delegate IntPtr SwigDelegateOdGiGradientBackgroundTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiGradientBackgroundTraits_1();

	public delegate void SwigDelegateOdGiGradientBackgroundTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiGradientBackgroundTraits_3(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiGradientBackgroundTraits_4();

	public delegate void SwigDelegateOdGiGradientBackgroundTraits_5(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiGradientBackgroundTraits_6();

	public delegate void SwigDelegateOdGiGradientBackgroundTraits_7(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiGradientBackgroundTraits_8();

	public delegate void SwigDelegateOdGiGradientBackgroundTraits_9(double horizon);

	public delegate double SwigDelegateOdGiGradientBackgroundTraits_10();

	public delegate void SwigDelegateOdGiGradientBackgroundTraits_11(double height);

	public delegate double SwigDelegateOdGiGradientBackgroundTraits_12();

	public delegate void SwigDelegateOdGiGradientBackgroundTraits_13(double rotation);

	public delegate double SwigDelegateOdGiGradientBackgroundTraits_14();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiGradientBackgroundTraits_0 swigDelegate0;

	private SwigDelegateOdGiGradientBackgroundTraits_1 swigDelegate1;

	private SwigDelegateOdGiGradientBackgroundTraits_2 swigDelegate2;

	private SwigDelegateOdGiGradientBackgroundTraits_3 swigDelegate3;

	private SwigDelegateOdGiGradientBackgroundTraits_4 swigDelegate4;

	private SwigDelegateOdGiGradientBackgroundTraits_5 swigDelegate5;

	private SwigDelegateOdGiGradientBackgroundTraits_6 swigDelegate6;

	private SwigDelegateOdGiGradientBackgroundTraits_7 swigDelegate7;

	private SwigDelegateOdGiGradientBackgroundTraits_8 swigDelegate8;

	private SwigDelegateOdGiGradientBackgroundTraits_9 swigDelegate9;

	private SwigDelegateOdGiGradientBackgroundTraits_10 swigDelegate10;

	private SwigDelegateOdGiGradientBackgroundTraits_11 swigDelegate11;

	private SwigDelegateOdGiGradientBackgroundTraits_12 swigDelegate12;

	private SwigDelegateOdGiGradientBackgroundTraits_13 swigDelegate13;

	private SwigDelegateOdGiGradientBackgroundTraits_14 swigDelegate14;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes14 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiGradientBackgroundTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiGradientBackgroundTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiGradientBackgroundTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiGradientBackgroundTraits cast(OdRxObject pObj)
	{
		OdGiGradientBackgroundTraits rXObject = Helpers.GetRXObject<OdGiGradientBackgroundTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_isASwigExplicitOdGiGradientBackgroundTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_queryXSwigExplicitOdGiGradientBackgroundTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiGradientBackgroundTraits createObject()
	{
		OdGiGradientBackgroundTraits rXObject = Helpers.GetRXObject<OdGiGradientBackgroundTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setColorTop(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_setColorTop(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmEntityColor colorTop()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_colorTop(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setColorMiddle(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_setColorMiddle(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmEntityColor colorMiddle()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_colorMiddle(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setColorBottom(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_setColorBottom(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdCmEntityColor colorBottom()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_colorBottom(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHorizon(double horizon)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_setHorizon(swigCPtr, horizon);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double horizon()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_horizon(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setHeight(double height)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_setHeight(swigCPtr, height);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double height()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_height(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setRotation(double rotation)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_setRotation(swigCPtr, rotation);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double rotation()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_rotation(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiGradientBackgroundTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiGradientBackgroundTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiGradientBackgroundTraits) != GetType();
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
		if (SwigDerivedClassHasMethod("setColorTop", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetColorTop;
		}
		if (SwigDerivedClassHasMethod("colorTop", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodcolorTop;
		}
		if (SwigDerivedClassHasMethod("setColorMiddle", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetColorMiddle;
		}
		if (SwigDerivedClassHasMethod("colorMiddle", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcolorMiddle;
		}
		if (SwigDerivedClassHasMethod("setColorBottom", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetColorBottom;
		}
		if (SwigDerivedClassHasMethod("colorBottom", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodcolorBottom;
		}
		if (SwigDerivedClassHasMethod("setHorizon", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetHorizon;
		}
		if (SwigDerivedClassHasMethod("horizon", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodhorizon;
		}
		if (SwigDerivedClassHasMethod("setHeight", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetHeight;
		}
		if (SwigDerivedClassHasMethod("height", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodheight;
		}
		if (SwigDerivedClassHasMethod("setRotation", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetRotation;
		}
		if (SwigDerivedClassHasMethod("rotation", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodrotation;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGradientBackgroundTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiGradientBackgroundTraits));
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

	private void SwigDirectorMethodsetColorTop(IntPtr color)
	{
		try
		{
			setColorTop(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodcolorTop()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(colorTop()).Handle;
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

	private void SwigDirectorMethodsetColorMiddle(IntPtr color)
	{
		try
		{
			setColorMiddle(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodcolorMiddle()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(colorMiddle()).Handle;
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

	private void SwigDirectorMethodsetColorBottom(IntPtr color)
	{
		try
		{
			setColorBottom(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodcolorBottom()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(colorBottom()).Handle;
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

	private void SwigDirectorMethodsetHorizon(double horizon)
	{
		try
		{
			setHorizon(horizon);
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

	private double SwigDirectorMethodhorizon()
	{
		return horizon();
	}

	private void SwigDirectorMethodsetHeight(double height)
	{
		try
		{
			setHeight(height);
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

	private double SwigDirectorMethodheight()
	{
		return height();
	}

	private void SwigDirectorMethodsetRotation(double rotation)
	{
		try
		{
			setRotation(rotation);
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

	private double SwigDirectorMethodrotation()
	{
		return rotation();
	}
}
