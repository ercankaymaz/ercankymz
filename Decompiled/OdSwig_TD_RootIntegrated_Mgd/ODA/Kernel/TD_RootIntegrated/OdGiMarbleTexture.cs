using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMarbleTexture : OdGiProceduralTexture
{
	public delegate IntPtr SwigDelegateOdGiMarbleTexture_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiMarbleTexture_1();

	public delegate void SwigDelegateOdGiMarbleTexture_2(IntPtr pSource);

	public delegate int SwigDelegateOdGiMarbleTexture_3();

	public delegate void SwigDelegateOdGiMarbleTexture_4(IntPtr stoneColor);

	public delegate IntPtr SwigDelegateOdGiMarbleTexture_5();

	public delegate void SwigDelegateOdGiMarbleTexture_6(IntPtr veinColor);

	public delegate IntPtr SwigDelegateOdGiMarbleTexture_7();

	public delegate void SwigDelegateOdGiMarbleTexture_8(double veinSpacing);

	public delegate double SwigDelegateOdGiMarbleTexture_9();

	public delegate void SwigDelegateOdGiMarbleTexture_10(double veinWidth);

	public delegate double SwigDelegateOdGiMarbleTexture_11();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiMarbleTexture_0 swigDelegate0;

	private SwigDelegateOdGiMarbleTexture_1 swigDelegate1;

	private SwigDelegateOdGiMarbleTexture_2 swigDelegate2;

	private SwigDelegateOdGiMarbleTexture_3 swigDelegate3;

	private SwigDelegateOdGiMarbleTexture_4 swigDelegate4;

	private SwigDelegateOdGiMarbleTexture_5 swigDelegate5;

	private SwigDelegateOdGiMarbleTexture_6 swigDelegate6;

	private SwigDelegateOdGiMarbleTexture_7 swigDelegate7;

	private SwigDelegateOdGiMarbleTexture_8 swigDelegate8;

	private SwigDelegateOdGiMarbleTexture_9 swigDelegate9;

	private SwigDelegateOdGiMarbleTexture_10 swigDelegate10;

	private SwigDelegateOdGiMarbleTexture_11 swigDelegate11;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdGiMaterialColor) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGiMaterialColor) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes11 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMarbleTexture(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMarbleTexture obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMarbleTexture(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiMarbleTexture cast(OdRxObject pObj)
	{
		OdGiMarbleTexture rXObject = Helpers.GetRXObject<OdGiMarbleTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_isASwigExplicitOdGiMarbleTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_queryXSwigExplicitOdGiMarbleTexture(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiMarbleTexture()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMarbleTexture(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiMarbleTexture) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override OdGiProceduralTexture_Type type()
	{
		int result = (SwigDerivedClassHasMethod("type", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_typeSwigExplicitOdGiMarbleTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_type(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiProceduralTexture_Type)result;
	}

	public virtual void setStoneColor(OdGiMaterialColor stoneColor)
	{
		if (SwigDerivedClassHasMethod("setStoneColor", swigMethodTypes4))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_setStoneColorSwigExplicitOdGiMarbleTexture(swigCPtr, OdGiMaterialColor.getCPtr(stoneColor));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_setStoneColor(swigCPtr, OdGiMaterialColor.getCPtr(stoneColor));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialColor stoneColor()
	{
		OdGiMaterialColor result = new OdGiMaterialColor(SwigDerivedClassHasMethod("stoneColor", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_stoneColorSwigExplicitOdGiMarbleTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_stoneColor(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setVeinColor(OdGiMaterialColor veinColor)
	{
		if (SwigDerivedClassHasMethod("setVeinColor", swigMethodTypes6))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_setVeinColorSwigExplicitOdGiMarbleTexture(swigCPtr, OdGiMaterialColor.getCPtr(veinColor));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_setVeinColor(swigCPtr, OdGiMaterialColor.getCPtr(veinColor));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMaterialColor veinColor()
	{
		OdGiMaterialColor result = new OdGiMaterialColor(SwigDerivedClassHasMethod("veinColor", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_veinColorSwigExplicitOdGiMarbleTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_veinColor(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setVeinSpacing(double veinSpacing)
	{
		if (SwigDerivedClassHasMethod("setVeinSpacing", swigMethodTypes8))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_setVeinSpacingSwigExplicitOdGiMarbleTexture(swigCPtr, veinSpacing);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_setVeinSpacing(swigCPtr, veinSpacing);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double veinSpacing()
	{
		double result = (SwigDerivedClassHasMethod("veinSpacing", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_veinSpacingSwigExplicitOdGiMarbleTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_veinSpacing(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setVeinWidth(double veinWidth)
	{
		if (SwigDerivedClassHasMethod("setVeinWidth", swigMethodTypes10))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_setVeinWidthSwigExplicitOdGiMarbleTexture(swigCPtr, veinWidth);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_setVeinWidth(swigCPtr, veinWidth);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double veinWidth()
	{
		double result = (SwigDerivedClassHasMethod("veinWidth", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_veinWidthSwigExplicitOdGiMarbleTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_veinWidth(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool IsEqual(OdGiMaterialTexture texture)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_IsEqual(swigCPtr, OdGiMaterialTexture.getCPtr(texture));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMarbleTexture Assign(OdGiMarbleTexture texture)
	{
		OdGiMarbleTexture rXObject = Helpers.GetRXObject<OdGiMarbleTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_Assign(swigCPtr, getCPtr(texture)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void copyFrom(OdRxObject pSource)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_copyFromSwigExplicitOdGiMarbleTexture(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiMarbleTexture createObject()
	{
		OdGiMarbleTexture rXObject = Helpers.GetRXObject<OdGiMarbleTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		if (SwigDerivedClassHasMethod("type", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodtype;
		}
		if (SwigDerivedClassHasMethod("setStoneColor", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetStoneColor;
		}
		if (SwigDerivedClassHasMethod("stoneColor", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodstoneColor;
		}
		if (SwigDerivedClassHasMethod("setVeinColor", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetVeinColor;
		}
		if (SwigDerivedClassHasMethod("veinColor", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodveinColor;
		}
		if (SwigDerivedClassHasMethod("setVeinSpacing", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetVeinSpacing;
		}
		if (SwigDerivedClassHasMethod("veinSpacing", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodveinSpacing;
		}
		if (SwigDerivedClassHasMethod("setVeinWidth", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetVeinWidth;
		}
		if (SwigDerivedClassHasMethod("veinWidth", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodveinWidth;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMarbleTexture_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiMarbleTexture));
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

	private int SwigDirectorMethodtype()
	{
		return (int)type();
	}

	private void SwigDirectorMethodsetStoneColor(IntPtr stoneColor)
	{
		try
		{
			setStoneColor(new OdGiMaterialColor(stoneColor, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodstoneColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiMaterialColor.getCPtr(stoneColor()).Handle;
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

	private void SwigDirectorMethodsetVeinColor(IntPtr veinColor)
	{
		try
		{
			setVeinColor(new OdGiMaterialColor(veinColor, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodveinColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiMaterialColor.getCPtr(veinColor()).Handle;
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

	private void SwigDirectorMethodsetVeinSpacing(double veinSpacing)
	{
		try
		{
			setVeinSpacing(veinSpacing);
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

	private double SwigDirectorMethodveinSpacing()
	{
		return veinSpacing();
	}

	private void SwigDirectorMethodsetVeinWidth(double veinWidth)
	{
		try
		{
			setVeinWidth(veinWidth);
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

	private double SwigDirectorMethodveinWidth()
	{
		return veinWidth();
	}
}
